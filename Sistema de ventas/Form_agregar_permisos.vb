Public Class Form_agregar_permisos

    Private Sub Form_agregar_permisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_combo_area()
        malla_columnas()
        llenar_combo_campo()
        ConsultaMenus()
        grilla_estado_de_cuenta.Font = New System.Drawing.Font("Arial", 10.25!, System.Drawing.FontStyle.Regular)
    End Sub

    Sub llenar_combo_area()
        'Combo_area.Items.Clear()
        'conexion.Close()
        'DS2.Tables.Clear()
        'DT2.Rows.Clear()
        'DT2.Columns.Clear()
        'DS2.Clear()
        'conexion.Open()

        'SC2.Connection = conexion
        'SC2.CommandText = "select area from  areas ORDER BY area"

        'DA2.SelectCommand = SC2
        'DA2.Fill(DT2)
        'DS2.Tables.Add(DT2)

        'If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
        '    For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
        '        Combo_area.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("area"))
        '    Next
        '    Combo_area.Items.Add("-")
        '    Combo_area.SelectedItem = "-"
        '    conexion.Close()
        'End If
    End Sub

    Sub llenar_combo_campo()

        Dim nombre_columna As String
        Combo_campo.Items.Clear()
        For i = 0 To grilla_resumen.Rows.Count - 1
            nombre_columna = grilla_resumen.Rows(i).Cells(0).Value.ToString
            If nombre_columna <> "rut_usuario" Then
                Combo_campo.Items.Add(nombre_columna)
            End If
        Next
        Combo_campo.Items.Add("-")
        Combo_campo.SelectedItem = "-"
    End Sub

    Sub malla_columnas()

        grilla_resumen.DataSource = Nothing
        conexion.Close()
        Dim DT As New DataTable

        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "SHOW COLUMNS FROM permisos"

        DA.SelectCommand = SC

        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_resumen.DataSource = DS.Tables(DT.TableName)
        conexion.Close()


        'If nro_columna <= (grilla_proforma.ColumnCount - 2) Then
        '    nro_columna = nro_columna + 1
        '    titulo_15 = grilla_proforma.Columns.Item(nro_columna).HeaderText
        'End If

    End Sub



    Sub llenar_combo_menu()

    End Sub

    Private Sub ConsultaMenus()
        Combo_menu.Items.Clear()

        Dim vLocMnuOpciones As ToolStripMenuItem
        Dim vGlovalor As String = ""

        Try
            For Each vLocMnuOpciones In Form_menu_principal.MenuStrip1.Items
                If vLocMnuOpciones.DropDownItems.Count > 0 Then
                    ' RecorrerMenus(vLocMnuOpciones.DropDownItems)
                    RecorrerMenus(Form_menu_principal.MENU_ADMINISTRACION_ToolStripMenuItem.DropDownItems)
                End If
                Exit Sub
            Next


            vGlovalor = vGlovalor.TrimEnd(";")
            MsgBox(vGlovalor)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub RecorrerMenus(ByVal vLocOneItem As ToolStripItemCollection)
        Dim vLocElItem As ToolStripMenuItem
        Dim vGlovalor As String = ""
        Try
            For Each vLocOtroItem As ToolStripItem In vLocOneItem
                If TypeOf vLocOtroItem Is ToolStripMenuItem Then
                    ' vGlovalor &= vLocOtroItem.Text & ";"
                    Combo_menu.Items.Add(vLocOtroItem.Name)
                    If vLocOtroItem.IsOnDropDown Then
                        vLocElItem = vLocOtroItem
                        If vLocElItem.DropDownItems.Count > 0 Then
                            RecorrerMenus(vLocElItem.DropDownItems)
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If Combo_modulo.Text = "" Then
            MsgBox("CAMPO MODULO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_modulo.Focus()
            Exit Sub
        End If

        If Combo_campo.Text = "0" Then
            MsgBox("CAMPO CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_campo.Focus()
            Exit Sub
        End If

        If Combo_menu.Text = "" Then
            MsgBox("CAMPO MENU VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_menu.Focus()
            Exit Sub
        End If

        conexion.Close()
        Consultas_SQL("select * from control_pemisos  where  campo = '" & (Combo_campo.Text) & "' order by campo asc")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Dim modulo As String
            modulo = DS.Tables(DT.TableName).Rows(0).Item("modulo")
            MsgBox("LA PANTALLA AGREGADA YA ESTA AGREGADA EN " & modulo, 0 + 16, "ERROR")
            Combo_modulo.Focus()
            Exit Sub
        End If

        grilla_estado_de_cuenta.Rows.Add(Combo_modulo.Text, Combo_campo.Text, Combo_menu.Text)

        'Combo_modulo.Text = "-"
        Combo_campo.Text = ""
        Combo_menu.Text = ""
        Combo_campo.Focus()
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_estado_de_cuenta.Rows.Count > 0 Then
            grilla_estado_de_cuenta.Rows.Remove(grilla_estado_de_cuenta.CurrentRow)
            Combo_modulo.Focus()
        End If
    End Sub


    Sub grabar_permisos()
        Dim VarModulo As String = ""
        Dim VarCampo As String = ""
        Dim VarMenu As String = ""


        SC.Connection = conexion
        SC.CommandText = "  DELETE FROM `control_pemisos` WHERE `modulo`='" & (Combo_modulo.Text) & "';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            VarModulo = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
            VarCampo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
            VarMenu = grilla_estado_de_cuenta.Rows(i).Cells(2).Value.ToString

            SC.Connection = conexion
            SC.CommandText = " INSERT INTO control_pemisos (`modulo`, `campo`, `menu`) VALUES ('" & (VarModulo) & "', '" & (VarCampo) & "', '" & (VarMenu) & "');"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_modulo.Focus()
            Exit Sub
        End If
        grabar_permisos()

        Combo_modulo.Text = "-"
        Combo_campo.Text = ""
        Combo_menu.Text = ""
        grilla_estado_de_cuenta.Rows.Clear()

        MsgBox("SE HA GRABADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
    End Sub

    Sub mostrar_malla()
        grilla_estado_de_cuenta.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from control_pemisos  where  modulo = '" & (Combo_modulo.Text) & "' order by campo asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("modulo"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("campo"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("menu"))

            Next
            grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 300 Then
                grilla_estado_de_cuenta.Columns(0).Width = 299
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 300
            End If
        End If
    End Sub

    Private Sub Combo_modulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_modulo.SelectedIndexChanged

        mostrar_malla()
    End Sub
End Class