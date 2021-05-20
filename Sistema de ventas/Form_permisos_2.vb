Public Class Form_permisos_2

    Private Sub Form_permisos_2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_permisos_2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F3 Then
            Dim forms As FormCollection = Application.OpenForms
            Dim i As Integer
            For i = 0 To forms.Count - 1
                Try
                    For Each form As Form In forms
                        If TypeOf form Is Form_menu_principal Then
                        Else
                            form.Close()
                        End If
                    Next
                Catch err As InvalidOperationException
                End Try
            Next i
            form_Ingreso.Show()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_permisos_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        malla_usuarios()
        Combo_modulo.Text = "ACCESOS A MODULOS"
        lbl_mensaje.Visible = True
        Me.Enabled = False
        lbl_mensaje.Visible = False
        Me.Enabled = True
        grilla_resumen.Font = New System.Drawing.Font("Arial", 10.25!, System.Drawing.FontStyle.Regular)
        btn_guardar.Enabled = False
        btn_cancelar.Enabled = False
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

 
    Sub malla_usuarios()
        grilla_usuarios.DataSource = Nothing
        conexion.Close()
        Dim DT As New DataTable
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        'SC.CommandText = "select nombre_usuario, rut_usuario from usuarios where rut_usuario <> '' and rut_usuario <> '" & (mirutempresa) & "' and activo ='SI' and tipo_usuario <> 'ADMINISTRADOR DEL SISTEMA'  order by nombre_usuario asc"
        SC.CommandText = "select nombre_usuario, rut_usuario from usuarios where rut_usuario <> '' and activo ='SI' and tipo_usuario <> 'ADMINISTRADOR DEL SISTEMA'  order by nombre_usuario asc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_usuarios.DataSource = DS.Tables(DT.TableName)
        conexion.Close()
    End Sub




         

    Private Sub RecorrerMenus(ByVal vLocOneItem As ToolStripItemCollection)
        Dim vLocElItem As ToolStripMenuItem
        Dim vGlovalor As String = ""

        Dim cadena_check_box As String = ""

        ' Dim DgvColumnCheck As DataGridViewCheckBoxColumn

        Dim nombre_columna As String
        'Dim i As Integer

        'If nombre_columna = "USUARIO" Then

        ' Try


        For Each vLocOtroItem As ToolStripItem In vLocOneItem
            If TypeOf vLocOtroItem Is ToolStripMenuItem Then
                nombre_columna = vLocOtroItem.Name
                nombre_columna = RTrim(Replace(nombre_columna, "_", " "))
                nombre_columna = RTrim(Replace(nombre_columna, "ToolStripMenuItem", " "))

                If nombre_columna <> "REPORTES ARANA" And nombre_columna <> "REPORTES OR" Then
                    Combo_permisos.Items.Add(nombre_columna)
                End If

                If nombre_columna = "REPORTES ARANA" And mirutempresa = "87686300-6" Then
                    Combo_permisos.Items.Add(nombre_columna)
                End If

                If nombre_columna = "REPORTES OR" And mirutempresa = "81921000-4" Then
                    Combo_permisos.Items.Add(nombre_columna)
                End If

                If nombre_columna <> "REPORTES ARANA" And nombre_columna <> "REPORTES OR" Then
                    If vLocOtroItem.IsOnDropDown Then
                        vLocElItem = vLocOtroItem
                        If vLocElItem.DropDownItems.Count > 0 Then
                            RecorrerMenus(vLocElItem.DropDownItems)
                        End If
                    End If
                End If

                If nombre_columna = "REPORTES ARANA" And mirutempresa = "87686300-6" Then
                    If vLocOtroItem.IsOnDropDown Then
                        vLocElItem = vLocOtroItem
                        If vLocElItem.DropDownItems.Count > 0 Then
                            RecorrerMenus(vLocElItem.DropDownItems)
                        End If
                    End If
                End If

                If nombre_columna = "REPORTES OR" And mirutempresa = "81921000-4" Then
                    If vLocOtroItem.IsOnDropDown Then
                        vLocElItem = vLocOtroItem
                        If vLocElItem.DropDownItems.Count > 0 Then
                            RecorrerMenus(vLocElItem.DropDownItems)
                        End If
                    End If
                End If

            End If
            Combo_permisos.Sorted = True
        Next


        Exit Sub





        '    For Each vLocOtroItem As ToolStripItem In vLocOneItem
        '        If TypeOf vLocOtroItem Is ToolStripMenuItem Then
        '            'vGlovalor &= vLocOtroItem.Text & ";"

        '            nombre_columna = vLocOtroItem.Name

        '            nombre_columna = RTrim(Replace(nombre_columna, "_", " "))
        '            nombre_columna = RTrim(Replace(nombre_columna, "ToolStripMenuItem", " "))
        '            'nombre_columna = RTrim(Replace(nombre_columna, " ", "_"))

        '            Combo_permisos.Items.Add(nombre_columna)


        '            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        '            checkBoxColumn.HeaderText = nombre_columna
        '            checkBoxColumn.Width = 170
        '            checkBoxColumn.Name = "checkBoxColumn"
        '            'grilla_resumen.Columns.Insert(i + 2, checkBoxColumn)
        '            'grilla_resumen.Columns(i + 2).ReadOnly = False

        '            grilla_resumen.Columns.Insert(i + 1, checkBoxColumn)
        '            grilla_resumen.Columns(i + 1).ReadOnly = False


        '            i = i + 1



































        '            If vLocOtroItem.IsOnDropDown Then
        '                vLocElItem = vLocOtroItem
        '                If vLocElItem.DropDownItems.Count > 0 Then
        '                    RecorrerMenus(vLocElItem.DropDownItems)
        '                End If
        '            End If
        '        End If
        '    Next
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub





   


    Sub revisar_permisos()




        Dim rut_usuario As String
        Dim permiso As String


        For e = 0 To grilla_resumen.Rows.Count - 1

            rut_usuario = grilla_resumen.Rows(e).Cells(1).Value.ToString

            For i = 2 To grilla_resumen.Columns.Count - 1
                Try
                    permiso = grilla_resumen.Columns.Item(i).HeaderText
                    'permiso = "" & permiso & ""
                    permiso = RTrim(Replace(permiso, " ", "_"))
                    'permiso = LCase(permiso)

                    ' permiso = grilla_resumen.Columns.Item(i).HeaderText
                    permiso = RTrim(Replace(permiso, " ", "_"))
                    'permiso = LCase(permiso)
                    permiso = permiso & "_ToolStripMenuItem"


                    conexion.Close()
                    DS3.Tables.Clear()
                    DT3.Rows.Clear()
                    DT3.Columns.Clear()
                    DS3.Clear()
                    conexion.Open()

                    SC3.Connection = conexion
                    SC3.CommandText = "select * from registro_de_permisos where modulo='" & (Combo_modulo.Text) & "' and permiso='" & (permiso) & "' and rut_usuario ='" & (rut_usuario) & "'"
                    DA3.SelectCommand = SC3
                    DA3.Fill(DT3)
                    DS3.Tables.Add(DT3)

                    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                        grilla_resumen.Rows(e).Cells(i).Value = True
                        grilla_resumen.Rows(e).Cells(i).Style.BackColor = Color.SkyBlue
                    Else
                        'estado_permiso = DS3.Tables(DT3.TableName).Rows(0).Item(permiso)
                        'If DS3.Tables(DT3.TableName).Rows(0).Item(permiso) = "HABILITADO" Then
                        '    grilla_resumen.Rows(e).Cells(i).Value = True
                        '    grilla_resumen.Rows(e).Cells(i).Style.BackColor = Color.SkyBlue
                        'Else
                        grilla_resumen.Rows(e).Cells(i).Value = False
                        grilla_resumen.Rows(e).Cells(i).Style.BackColor = Color.White
                        'End If
                    End If







                Catch
                End Try


            Next

        Next

















    End Sub


    Sub insertar_columnas()
        Dim nombre_columna As String

        For i = 0 To Combo_permisos.Items.Count - 1
            nombre_columna = Combo_permisos.Items(i)

            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
            checkBoxColumn.HeaderText = nombre_columna
            checkBoxColumn.Width = 200
            checkBoxColumn.Name = "checkBoxColumn"
            'grilla_resumen.Columns.Insert(i + 2, checkBoxColumn)
            'grilla_resumen.Columns(i + 2).ReadOnly = False
            grilla_resumen.Columns.Insert(2 + i, checkBoxColumn)
            grilla_resumen.Columns(2 + i).ReadOnly = False
        Next

    End Sub
    Sub grabar_permisos()

        Dim rut_usuario As String
        Dim permiso As String
        Dim cadena As String = ""



        SC.Connection = conexion
        SC.CommandText = "DELETE FROM `registro_de_permisos` WHERE `cod_auto`<>'0' and `modulo`='" & (Combo_modulo.Text) & "';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'Dim nro_columna As Integer
        ' nro_columna = 1

        For e = 0 To grilla_resumen.Rows.Count - 1
            ' rut_usuario = grilla_resumen.Rows(e).Cells(grilla_resumen.Columns.Count - 1).Value.ToString
            rut_usuario = grilla_resumen.Rows(e).Cells(1).Value.ToString

            'permiso = grilla_resumen.Columns.Item(e).HeaderText
            'permiso = RTrim(Replace(permiso, " ", "_"))
            'permiso = LCase(permiso)



            'Exit Sub

            For i = 2 To grilla_resumen.Columns.Count - 1
                permiso = grilla_resumen.Columns.Item(i).HeaderText
                permiso = RTrim(Replace(permiso, " ", "_"))
                'permiso = LCase(permiso)
                permiso = permiso & "_ToolStripMenuItem"

                If grilla_resumen.Rows(e).Cells(i).Value = True Then


                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `registro_de_permisos` (`rut_usuario`, `permiso`, `modulo`) VALUES ('" & (rut_usuario) & "', '" & (permiso) & "', '" & (Combo_modulo.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    '    If i = 2 Then
                    '        cadena = "UPDATE permisos SET " & permiso & "=" & "'HABILITADO'"
                    '    Else
                    '        cadena = cadena & ", " & permiso & "=" & "'HABILITADO'"
                    '    End If
                    'Else
                    '    If i = 2 Then
                    '        cadena = "UPDATE permisos SET " & permiso & "=" & "'DESHABILITADO'"
                    '    Else
                    '        cadena = cadena & ", " & permiso & "=" & "'DESHABILITADO'"
                    '    End If
                End If

            Next

            'cadena = cadena & "  WHERE rut_usuario='" & (rut_usuario) & "'"

            'SC.Connection = conexion
            'SC.CommandText = cadena
            'DA.SelectCommand = SC
            'DA.Fill(DT)

            'cadena = ""
        Next

    End Sub



    Private Sub grilla_resumen_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_resumen.CellContentClick

    End Sub

    Private Sub grilla_resumen_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_resumen.CellValueChanged

        If grilla_resumen.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim Celda As DataGridViewCell = Me.grilla_resumen.CurrentCell()
        Dim columna As Integer
        columna = Celda.ColumnIndex

        If columna <> 0 And columna <> 1 Then
            If grilla_resumen.CurrentRow.Cells(columna).Value = True Then
                grilla_resumen.CurrentRow.Cells(columna).Style.BackColor = Color.SkyBlue
            Else
                grilla_resumen.CurrentRow.Cells(columna).Value = False
                grilla_resumen.CurrentRow.Cells(columna).Style.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub grilla_resumen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_resumen.Click

        If grilla_resumen.Rows.Count = 0 Then
            Exit Sub
        End If

        txt_nombre.Text = grilla_resumen.CurrentRow.Cells(0).Value

        Dim Celda As DataGridViewCell = Me.grilla_resumen.CurrentCell()
        Dim columna As Integer
        columna = Celda.ColumnIndex

        If columna <> 0 And columna <> 1 Then
            If grilla_resumen.CurrentRow.Cells(columna).Value = True Then
                grilla_resumen.CurrentRow.Cells(columna).Style.BackColor = Color.SkyBlue
            Else
                grilla_resumen.CurrentRow.Cells(columna).Value = False
                grilla_resumen.CurrentRow.Cells(columna).Style.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        If Combo_modulo.Text = "" Then
            MsgBox("CAMPO MODULO VACIO, FAVOR LLENAR" + Chr(13), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_modulo.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        'nombre_columnas()
        'revisar_permisos()




        mostar_datos_modulo()

        insertar_columnas()

        'nombre_columnas()
        revisar_permisos()

        grilla_resumen.ReadOnly = True


        If grilla_resumen.Rows.Count <> 0 Then
            If grilla_resumen.Columns(0).Width = 180 Then
                grilla_resumen.Columns(0).Width = 179
            Else
                grilla_resumen.Columns(0).Width = 180
            End If
        End If

        grilla_resumen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter














        grilla_resumen.ReadOnly = False
        grilla_resumen.Columns(0).ReadOnly = True
        grilla_resumen.Columns(1).ReadOnly = True

        Combo_modulo.Enabled = False
        btn_modificar.Enabled = False
        btn_guardar.Enabled = True
        btn_cancelar.Enabled = True


        lbl_mensaje.Visible = False
        Me.Enabled = True



    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If grilla_resumen.Rows.Count = 0 Then
            MsgBox("MALLA DE PERMISOS VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_modulo.Focus()
            Exit Sub
        End If

        Dim valormensaje As Integer
        valormensaje = MsgBox("ESTA SEGURO DE MODIFICAR LOS PERMISOS?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

        If valormensaje = vbYes Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            grabar_permisos()

            grilla_resumen.ReadOnly = True

            Combo_modulo.Enabled = True
            btn_modificar.Enabled = True
            btn_guardar.Enabled = False
            btn_cancelar.Enabled = False

            lbl_mensaje.Visible = False
            Me.Enabled = True

            MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False






        mostar_datos_modulo()

        insertar_columnas()

        'nombre_columnas()
        revisar_permisos()

        grilla_resumen.ReadOnly = True


        If grilla_resumen.Rows.Count <> 0 Then
            If grilla_resumen.Columns(0).Width = 180 Then
                grilla_resumen.Columns(0).Width = 179
            Else
                grilla_resumen.Columns(0).Width = 180
            End If
        End If

        grilla_resumen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Combo_modulo.Enabled = True
        btn_modificar.Enabled = True
        btn_guardar.Enabled = False
        btn_cancelar.Enabled = False
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub
 
    Sub mostar_datos_modulo()
        grilla_resumen.Rows.Clear()
        grilla_resumen.Columns.Clear()
        Combo_permisos.Items.Clear()

        Dim nombre_usuario As String
        Dim rut_usuario As String

        grilla_resumen.Columns.Add("", "NOMBRE")
        grilla_resumen.Columns.Add("", "RUT")
        grilla_resumen.Columns(0).Width = 180
        grilla_resumen.Columns(0).ReadOnly = True
        grilla_resumen.Columns(0).Frozen = True
        grilla_resumen.Columns(0).Width = 180
        grilla_resumen.Columns(0).ReadOnly = False

        '  grilla_columnas.DataSource = Nothing
        If Combo_modulo.Text = "ACCESOS A MODULOS" Then
         
            Dim checkBoxColumn2 As New DataGridViewCheckBoxColumn()
            checkBoxColumn2.HeaderText = "MENU ADQUISICIONES"
            checkBoxColumn2.Width = 170
            checkBoxColumn2.Name = "checkBoxColumn"
            grilla_resumen.Columns.Insert(2, checkBoxColumn2)
            grilla_resumen.Columns(2).ReadOnly = False

            Dim checkBoxColumn3 As New DataGridViewCheckBoxColumn()
            checkBoxColumn3.HeaderText = "MENU ADMINISTRACION"
            checkBoxColumn3.Width = 170
            checkBoxColumn3.Name = "checkBoxColumn"
            grilla_resumen.Columns.Insert(3, checkBoxColumn3)
            grilla_resumen.Columns(3).ReadOnly = False

            Dim checkBoxColumn4 As New DataGridViewCheckBoxColumn()
            checkBoxColumn4.HeaderText = "MENU BODEGA"
            checkBoxColumn4.Width = 170
            checkBoxColumn4.Name = "checkBoxColumn"
            grilla_resumen.Columns.Insert(4, checkBoxColumn4)
            grilla_resumen.Columns(4).ReadOnly = False

            Dim checkBoxColumn5 As New DataGridViewCheckBoxColumn()
            checkBoxColumn5.HeaderText = "MENU CONFIGURACION"
            checkBoxColumn5.Width = 170
            checkBoxColumn5.Name = "checkBoxColumn"
            grilla_resumen.Columns.Insert(5, checkBoxColumn5)
            grilla_resumen.Columns(5).ReadOnly = False

            Dim checkBoxColumn6 As New DataGridViewCheckBoxColumn()
            checkBoxColumn6.HeaderText = "MENU MANTENEDORES"
            checkBoxColumn6.Width = 170
            checkBoxColumn6.Name = "checkBoxColumn"
            grilla_resumen.Columns.Insert(6, checkBoxColumn6)
            grilla_resumen.Columns(6).ReadOnly = False

            Dim checkBoxColumn7 As New DataGridViewCheckBoxColumn()
            checkBoxColumn7.HeaderText = "MENU VENTAS"
            checkBoxColumn7.Width = 170
            checkBoxColumn7.Name = "checkBoxColumn"
            grilla_resumen.Columns.Insert(7, checkBoxColumn7)
            grilla_resumen.Columns(7).ReadOnly = False

      
 



            For i = 0 To grilla_usuarios.Rows.Count - 1
                nombre_usuario = grilla_usuarios.Rows(i).Cells(0).Value.ToString
                rut_usuario = grilla_usuarios.Rows(i).Cells(1).Value.ToString
                grilla_resumen.Rows.Add(nombre_usuario, rut_usuario)
            Next

            Exit Sub










            Exit Sub

        End If

        If Combo_modulo.Text = "ADQUISICIONES" Then
            Dim vLocMnuOpciones As ToolStripMenuItem
            Dim vGlovalor As String = ""

            Try
                For Each vLocMnuOpciones In Form_menu_principal.MenuStrip1.Items
                    If vLocMnuOpciones.DropDownItems.Count > 0 Then
                        ' RecorrerMenus(vLocMnuOpciones.DropDownItems)
                        RecorrerMenus(Form_menu_principal.MENU_ADQUISICIONES_ToolStripMenuItem.DropDownItems)
                    End If

                    For i = 0 To grilla_usuarios.Rows.Count - 1
                        nombre_usuario = grilla_usuarios.Rows(i).Cells(0).Value.ToString
                        rut_usuario = grilla_usuarios.Rows(i).Cells(1).Value.ToString
                        grilla_resumen.Rows.Add(nombre_usuario, rut_usuario)
                    Next

                    Exit Sub
                Next

        
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        If Combo_modulo.Text = "ADMINISTRACION" Then
            Dim vLocMnuOpciones As ToolStripMenuItem
            Dim vGlovalor As String = ""

            Try
                For Each vLocMnuOpciones In Form_menu_principal.MenuStrip1.Items
                    If vLocMnuOpciones.DropDownItems.Count > 0 Then
                        ' RecorrerMenus(vLocMnuOpciones.DropDownItems)
                        RecorrerMenus(Form_menu_principal.MENU_ADMINISTRACION_ToolStripMenuItem.DropDownItems)
                    End If

                    For i = 0 To grilla_usuarios.Rows.Count - 1
                        nombre_usuario = grilla_usuarios.Rows(i).Cells(0).Value.ToString
                        rut_usuario = grilla_usuarios.Rows(i).Cells(1).Value.ToString
                        grilla_resumen.Rows.Add(nombre_usuario, rut_usuario)
                    Next

                    Exit Sub
                Next


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If


        If Combo_modulo.Text = "BODEGA" Then
            Dim vLocMnuOpciones As ToolStripMenuItem
            Dim vGlovalor As String = ""

            Try
                For Each vLocMnuOpciones In Form_menu_principal.MenuStrip1.Items
                    If vLocMnuOpciones.DropDownItems.Count > 0 Then
                        ' RecorrerMenus(vLocMnuOpciones.DropDownItems)
                        RecorrerMenus(Form_menu_principal.MENU_BODEGA_ToolStripMenuItem.DropDownItems)
                    End If

                    For i = 0 To grilla_usuarios.Rows.Count - 1
                        nombre_usuario = grilla_usuarios.Rows(i).Cells(0).Value.ToString
                        rut_usuario = grilla_usuarios.Rows(i).Cells(1).Value.ToString
                        grilla_resumen.Rows.Add(nombre_usuario, rut_usuario)
                    Next

                    Exit Sub
                Next

       
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        If Combo_modulo.Text = "CONFIGURACION" Then
            Dim vLocMnuOpciones As ToolStripMenuItem
            Dim vGlovalor As String = ""

            Try
                For Each vLocMnuOpciones In Form_menu_principal.MenuStrip1.Items
                    If vLocMnuOpciones.DropDownItems.Count > 0 Then
                        ' RecorrerMenus(vLocMnuOpciones.DropDownItems)
                        RecorrerMenus(Form_menu_principal.MENU_CONFIGURACION_ToolStripMenuItem.DropDownItems)
                    End If
                    For i = 0 To grilla_usuarios.Rows.Count - 1
                        nombre_usuario = grilla_usuarios.Rows(i).Cells(0).Value.ToString
                        rut_usuario = grilla_usuarios.Rows(i).Cells(1).Value.ToString
                        grilla_resumen.Rows.Add(nombre_usuario, rut_usuario)
                    Next

                    Exit Sub

                Next

          
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        If Combo_modulo.Text = "MANTENEDORES" Then
            Dim vLocMnuOpciones As ToolStripMenuItem
            Dim vGlovalor As String = ""

            Try
                For Each vLocMnuOpciones In Form_menu_principal.MenuStrip1.Items
                    If vLocMnuOpciones.DropDownItems.Count > 0 Then
                        ' RecorrerMenus(vLocMnuOpciones.DropDownItems)
                        RecorrerMenus(Form_menu_principal.MENU_MANTENEDORES_ToolStripMenuItem.DropDownItems)
                    End If
                    For i = 0 To grilla_usuarios.Rows.Count - 1
                        nombre_usuario = grilla_usuarios.Rows(i).Cells(0).Value.ToString
                        rut_usuario = grilla_usuarios.Rows(i).Cells(1).Value.ToString
                        grilla_resumen.Rows.Add(nombre_usuario, rut_usuario)
                    Next

                    Exit Sub
                Next

         
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        If Combo_modulo.Text = "VENTAS" Then
            Dim vLocMnuOpciones As ToolStripMenuItem
            Dim vGlovalor As String = ""

            Try
                For Each vLocMnuOpciones In Form_menu_principal.MenuStrip1.Items
                    If vLocMnuOpciones.DropDownItems.Count > 0 Then
                        ' RecorrerMenus(vLocMnuOpciones.DropDownItems)
                        RecorrerMenus(Form_menu_principal.MENU_VENTAS_ToolStripMenuItem.DropDownItems)
                    End If
                    For i = 0 To grilla_usuarios.Rows.Count - 1
                        nombre_usuario = grilla_usuarios.Rows(i).Cells(0).Value.ToString
                        rut_usuario = grilla_usuarios.Rows(i).Cells(1).Value.ToString
                        grilla_resumen.Rows.Add(nombre_usuario, rut_usuario)
                    Next

                    Exit Sub
                Next


       
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Combo_modulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_modulo.SelectedIndexChanged
        lbl_mensaje.Visible = True
        Me.Enabled = False



 


        mostar_datos_modulo()

        insertar_columnas()

        'nombre_columnas()
        revisar_permisos()

        grilla_resumen.ReadOnly = True


        If grilla_resumen.Rows.Count <> 0 Then
            If grilla_resumen.Columns(0).Width = 180 Then
                grilla_resumen.Columns(0).Width = 179
            Else
                grilla_resumen.Columns(0).Width = 180
            End If
        End If

        grilla_resumen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub Combo_modulo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_modulo.GotFocus
        Combo_modulo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_modulo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_modulo.LostFocus
        Combo_modulo.BackColor = Color.White
    End Sub
End Class