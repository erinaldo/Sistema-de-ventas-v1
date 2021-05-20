Public Class Form_agregar_propiedades
    Private Sub Form_agregar_propiedades_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_agregar_propiedades_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_agregar_propiedades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_rut()
        cargar_propiedades()
        grilla_propiedades.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub llenar_combo_rut()
        conexion.Close()
        txt_rut.Items.Clear()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()
        SC2.Connection = conexion
        SC2.CommandText = "select * from clientes  where rut_cliente like '%PROPIEDAD%' ORDER by rut_cliente"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                txt_rut.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("rut_cliente"))
            Next
        End If
        conexion.Close()
        txt_rut.Items.Add("-")
        txt_rut.SelectedItem = "-"
    End Sub

    Sub mostrar_datos_clientes()
        If txt_rut.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            txt_codigo_cliente.Text = ""
            txt_nombre_cliente.Text = ""
            txt_direccion.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            End If
            conexion.Close()
        End If
    End Sub

    Sub cargar_propiedades()
        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        SC4.Connection = conexion
        SC4.CommandText = "select propiedades.cod_cliente AS CODIGO, propiedades.rut_cliente AS RUT, clientes.nombre_cliente AS NOMBRE, clientes.direccion_cliente AS DIRECCION, monto AS MONTO from propiedades, clientes where propiedades.rut_cliente=clientes.rut_cliente order by propiedades.rut_cliente"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)
        grilla_propiedades.Rows.Clear()
        grilla_propiedades.Columns.Clear()
        grilla_propiedades.Columns.Add("CODIGO", "CODIGO")
        grilla_propiedades.Columns.Add("RUT", "RUT")
        grilla_propiedades.Columns.Add("NOMBRE", "NOMBRE")
        grilla_propiedades.Columns.Add("DIRECCION", "DIRECCION")
        grilla_propiedades.Columns.Add("MONTO", "MONTO")
        If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
            For i = 0 To DS4.Tables(DT4.TableName).Rows.Count - 1
                grilla_propiedades.Rows.Add(DS4.Tables(DT4.TableName).Rows(i).Item("CODIGO"), _
                                                DS4.Tables(DT4.TableName).Rows(i).Item("RUT"), _
                                                 DS4.Tables(DT4.TableName).Rows(i).Item("NOMBRE"), _
                                                  DS4.Tables(DT4.TableName).Rows(i).Item("DIRECCION"), _
                                                   DS4.Tables(DT4.TableName).Rows(i).Item("MONTO"))
            Next
        End If
        conexion.Close()

        If grilla_propiedades.Rows.Count <> 0 Then

            If grilla_propiedades.Columns(0).Width = 100 Then
                grilla_propiedades.Columns(0).Width = 99
            Else
                grilla_propiedades.Columns(0).Width = 100
            End If

            grilla_propiedades.Columns(1).Width = 120
            grilla_propiedades.Columns(2).Width = 325
            grilla_propiedades.Columns(3).Width = 319
            grilla_propiedades.Columns(4).Width = 100
        End If

        grilla_propiedades.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_propiedades.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_propiedades.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_propiedades.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_propiedades.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub btn_quitar_entrada_remuneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.Click
        Dim codigo_cliente As String

        If grilla_propiedades.Rows.Count > 0 Then
            codigo_cliente = grilla_propiedades.CurrentRow.Cells(1).Value

            SC3.Connection = conexion
            SC3.CommandText = "delete from propiedades where cod_cliente='" & (codigo_cliente) & "' and cod_auto <> '0'"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)

            grilla_propiedades.Rows.Remove(grilla_propiedades.CurrentRow)
        End If
    End Sub

    Private Sub btn_agregar_entrada_remuneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.Click
        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If

        If txt_monto.Text = "" Then
            MsgBox("CAMPO MONTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_monto.Focus()
            Exit Sub
        End If

        Dim codigo_cliente As String
        Dim rut_cliente As String
        Dim nombre_cliente As String
        Dim direccion_cliente As String

        For i = 0 To grilla_propiedades.Rows.Count - 1
            codigo_cliente = grilla_propiedades.Rows(i).Cells(0).Value.ToString
            rut_cliente = grilla_propiedades.Rows(i).Cells(1).Value.ToString
            nombre_cliente = grilla_propiedades.Rows(i).Cells(2).Value.ToString
            direccion_cliente = grilla_propiedades.Rows(i).Cells(3).Value.ToString

            If codigo_cliente = txt_codigo_cliente.Text And rut_cliente = txt_rut.Text And nombre_cliente = txt_nombre_cliente.Text And direccion_cliente = txt_direccion.Text Then
                grilla_propiedades.Rows.Remove(grilla_propiedades.Rows(i))
                Exit For
            End If
        Next

        grilla_propiedades.Rows.Add(txt_codigo_cliente.Text, txt_rut.Text, txt_nombre_cliente.Text, txt_direccion.Text, txt_monto.Text)

        SC3.Connection = conexion
        SC3.CommandText = "delete from propiedades where cod_cliente='" & (txt_codigo_cliente.Text) & "' and cod_auto <> '0'"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)

        SC3.Connection = conexion
        SC3.CommandText = "insert into propiedades (cod_cliente, rut_cliente, monto, fecha_modificacion, usuario_responsable) values('" & (txt_codigo_cliente.Text) & "','" & (txt_rut.Text) & "','" & (txt_monto.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (miusuario) & "')"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)

        txt_rut.Text = "-"
        txt_codigo_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        txt_direccion.Text = ""
        txt_monto.Text = ""
        txt_rut.Focus()
    End Sub

    Private Sub txt_rebajar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_monto.GotFocus
        txt_monto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rebajar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_monto.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "|" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "¿" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "?" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "}" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "{" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "<" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ">" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_agregar_entrada_remuneracion.Focus()
        End If
    End Sub

    Private Sub btn_agregar_entrada_remuneracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.GotFocus
        btn_agregar_entrada_remuneracion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_entrada_remuneracion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.LostFocus
        btn_agregar_entrada_remuneracion.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_entrada_remuneracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.GotFocus
        btn_quitar_entrada_remuneracion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_entrada_remuneracion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.LostFocus
        btn_quitar_entrada_remuneracion.BackColor = Color.Transparent
    End Sub

    Private Sub txt_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.SelectedIndexChanged
        mostrar_datos_clientes()
        txt_monto.Focus()
    End Sub
End Class