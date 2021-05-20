Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_registro_ruta_imagenes_sistema
    Dim VarSeleccion As Integer
    Dim MiPos As Integer

    Private Sub Form_registro_ruta_imagenes_sistema_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_registro_ruta_imagenes_sistema_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
            mostrar_cierre_sistema()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_registro_ruta_imagenes_sistema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actualizar_tabla()
        mostrar(0)
        controles(False, True)
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub



    Sub mostrar(ByVal i As Integer)
        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_ruta_imagen_menu.Text = DS.Tables(DT.TableName).Rows(i).Item("ruta_logo_empresa_menu")
                txt_ruta_imagen_ventana.Text = DS.Tables(DT.TableName).Rows(i).Item("ruta_logo_empresa_formulario")
                txt_ruta_imagen_reportes.Text = DS.Tables(DT.TableName).Rows(i).Item("ruta_logo_empresa_reportes")
                txt_ruta_imagen_ticket.Text = DS.Tables(DT.TableName).Rows(i).Item("ruta_logo_empresa_ticket")

                txt_ruta_carpeta_fotografias.Text = DS.Tables(DT.TableName).Rows(i).Item("ruta_imagen_producto")
                txt_ruta_carpeta_productos.Text = DS.Tables(DT.TableName).Rows(i).Item("ruta_imagen_fotografia")
            End If
        Catch
        End Try
    End Sub



    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        'btn_eliminar.Enabled = b

        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a
        btn_ruta_menu.Enabled = a
        btn_ruta_reporte.Enabled = a
        btn_ruta_ticket.Enabled = a
        btn_ruta_ventana.Enabled = a

        btn_ruta_carpeta_productos.Enabled = a
        btn_ruta_carpeta_fotografias.Enabled = a

        txt_ruta_imagen_menu.Enabled = a
        txt_ruta_imagen_reportes.Enabled = a
        txt_ruta_imagen_ticket.Enabled = a
        txt_ruta_imagen_ventana.Enabled = a

        txt_ruta_carpeta_fotografias.Enabled = a
        txt_ruta_carpeta_productos.Enabled = a
    End Sub

    Sub limpiar()
        txt_ruta_imagen_menu.Text = ""
        txt_ruta_imagen_reportes.Text = ""
        txt_ruta_imagen_ticket.Text = ""
        txt_ruta_imagen_ventana.Text = ""
        txt_ruta_carpeta_fotografias.Text = ""
        txt_ruta_carpeta_productos.Text = ""
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        'limpiar()
        controles(True, False)
        VarSeleccion = 1
        txt_ruta_imagen_menu.Focus()
    End Sub



    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If txt_ruta_imagen_menu.Text = "" Then
            MsgBox("CAMPO RUTA DE IMAGEN PARA MENU VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            txt_ruta_imagen_menu.Focus()
            Exit Sub
        End If

        If txt_ruta_imagen_reportes.Text = "" Then
            MsgBox("CAMPO RUTA DE IMAGEN PARA REPORTES VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            txt_ruta_imagen_reportes.Focus()
            Exit Sub
        End If

        If txt_ruta_imagen_ticket.Text = "" Then
            MsgBox("CAMPO RUTA DE IMAGEN PARA TICKET VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            txt_ruta_imagen_ticket.Focus()
            Exit Sub
        End If

        If txt_ruta_imagen_ventana.Text = "" Then
            MsgBox("CAMPO RUTA DE IMAGEN PARA FORMULARIOS VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            txt_ruta_imagen_ventana.Focus()
            Exit Sub
        End If

        If txt_ruta_carpeta_fotografias.Text = "" Then
            MsgBox("CAMPO RUTA DE CARPETA PARA FOTOGRAFIAS DE USUARIOS VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            txt_ruta_carpeta_fotografias.Focus()
            Exit Sub
        End If

        If txt_ruta_carpeta_productos.Text = "" Then
            MsgBox("CAMPO RUTA DE CARPETA PARA FOTOGRAFIAS DE PRODUCTOS VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            txt_ruta_carpeta_productos.Focus()
            Exit Sub
        End If

        txt_ruta_imagen_menu.Text = Trim(Replace(txt_ruta_imagen_menu.Text, "\", "\\"))
        txt_ruta_imagen_reportes.Text = Trim(Replace(txt_ruta_imagen_reportes.Text, "\", "\\"))
        txt_ruta_imagen_ticket.Text = Trim(Replace(txt_ruta_imagen_ticket.Text, "\", "\\"))
        txt_ruta_imagen_ventana.Text = Trim(Replace(txt_ruta_imagen_ventana.Text, "\", "\\"))
        txt_ruta_carpeta_fotografias.Text = Trim(Replace(txt_ruta_carpeta_fotografias.Text, "\", "\\"))
        txt_ruta_carpeta_productos.Text = Trim(Replace(txt_ruta_carpeta_productos.Text, "\", "\\"))

        SC.Connection = conexion
        SC.CommandText = "UPDATE rutas_imagenes SET ruta_logo_empresa_MENU='" & (txt_ruta_imagen_menu.Text) & "', ruta_logo_empresa_FORMULARIO='" & (txt_ruta_imagen_ventana.Text) & "', ruta_logo_empresa_ticket='" & (txt_ruta_imagen_ticket.Text) & "', ruta_logo_empresa_reportes='" & (txt_ruta_imagen_reportes.Text) & "', ruta_imagen_fotografia='" & (txt_ruta_carpeta_fotografias.Text) & "', ruta_imagen_producto='" & (txt_ruta_carpeta_productos.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)


        actualizar_tabla()
        controles(False, True)
        mostrar(0)

        MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
    End Sub



    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        MiPos = 0

        mostrar(MiPos)
    End Sub

    Private Sub btn_primero_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MiPos = 0
        mostrar(0)
        'mostrar_datos_especie_por_combo()
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
            ' mostrar_datos_especie_por_combo()
        End If

    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
            '   mostrar_datos_especie_por_combo()
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MiPos = DT.Rows.Count - 1
        mostrar(MiPos)
        ' mostrar_datos_especie_por_combo()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        ' form_Menu_admin.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    Sub actualizar_tabla()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from rutas_imagenes"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub

    Private Sub txt_costo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_minima_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub txt_marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txt_numero_tecnico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub





    Private Sub txt_ruta_imagen_menu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ruta_imagen_menu.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

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


    End Sub


    Private Sub txt_ruta_imagen_menu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_menu.GotFocus
        txt_ruta_imagen_menu.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_ruta_imagen_menu_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_menu.LostFocus
        txt_ruta_imagen_menu.BackColor = Color.White
    End Sub

    Private Sub txt_ruta_imagen_reportes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_reportes.GotFocus
        txt_ruta_imagen_reportes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_ruta_imagen_reportes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_reportes.LostFocus
        txt_ruta_imagen_reportes.BackColor = Color.White
    End Sub




    Private Sub txt_ruta_imagen_ticket_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_ticket.GotFocus
        txt_ruta_imagen_ticket.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_ruta_imagen_ticket_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_ticket.LostFocus
        txt_ruta_imagen_ticket.BackColor = Color.White
    End Sub


    Private Sub txt_ruta_imagen_ventana_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_ventana.GotFocus
        txt_ruta_imagen_ventana.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_ruta_imagen_ventana_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_ventana.LostFocus
        txt_ruta_imagen_ventana.BackColor = Color.White
    End Sub



    Private Sub txt_ruta_carpeta_productos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_carpeta_productos.GotFocus
        txt_ruta_carpeta_productos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_ruta_carpeta_productos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_carpeta_productos.LostFocus
        txt_ruta_carpeta_productos.BackColor = Color.White
    End Sub


    Private Sub txt_ruta_carpeta_fotografias_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_carpeta_fotografias.GotFocus
        txt_ruta_carpeta_fotografias.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_ruta_carpeta_fotografias_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_carpeta_fotografias.LostFocus
        txt_ruta_carpeta_fotografias.BackColor = Color.White
    End Sub


    Private Sub txt_ruta_imagen_ventana_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ruta_imagen_ventana.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

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


    End Sub








    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
    '    btn_modificar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
    '    btn_modificar.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'btn_eliminar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ' btn_eliminar.BackColor = Color.WhiteSmoke
    End Sub

    'Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
    '    btn_buscar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
    '    btn_buscar.BackColor = Color.WhiteSmoke
    'End Sub

    'Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
    '    btn_imprimir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
    '    btn_imprimir.BackColor = Color.WhiteSmoke
    'End Sub

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



    Private Sub txt_ruta_imagen_reportes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ruta_imagen_reportes.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

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


    End Sub




    Private Sub txt_ruta_imagen_ticket_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ruta_imagen_ticket.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

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


    End Sub





    Private Sub btn_ruta_menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ruta_menu.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            txt_ruta_imagen_menu.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btn_ruta_ventana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ruta_ventana.Click
        Dim result As DialogResult = OpenFileDialog2.ShowDialog()
        If result = DialogResult.OK Then
            txt_ruta_imagen_ventana.Text = OpenFileDialog2.FileName
        End If
    End Sub

    Private Sub btn_ruta_reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ruta_reporte.Click
        Dim result As DialogResult = OpenFileDialog3.ShowDialog()
        If result = DialogResult.OK Then
            txt_ruta_imagen_reportes.Text = OpenFileDialog3.FileName
        End If
    End Sub

    Private Sub btn_ruta_ticket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ruta_ticket.Click
        Dim result As DialogResult = OpenFileDialog4.ShowDialog()
        If result = DialogResult.OK Then
            txt_ruta_imagen_ticket.Text = OpenFileDialog4.FileName
        End If
    End Sub


    Private Sub btn_ruta_carpeta_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ruta_carpeta_productos.Click
        Try
            Dim openFileDialog5 As New OpenFileDialog()
            openFileDialog5.InitialDirectory = "C:\"
            openFileDialog5.FilterIndex = 4
            openFileDialog5.RestoreDirectory = True

            If openFileDialog5.ShowDialog() = DialogResult.OK Then
                Dim dir As String = OpenFileDialog1.FileName
                txt_ruta_carpeta_productos.Text = IO.Path.GetDirectoryName(openFileDialog5.FileName)
                'patch = openFileDialog1.FileName
                'File.Copy(dir, TextBox2.Text)
                txt_ruta_carpeta_productos.Text = txt_ruta_carpeta_productos.Text & "\"
            Else
                If String.IsNullOrEmpty(openFileDialog5.FileName) Then
                    MessageBox.Show("NO SE HA SELECCIONADO NINGUN PRODUCTO")
                    Return
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btn_ruta_carpeta_fotografias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ruta_carpeta_fotografias.Click
        Try
            Dim openFileDialog6 As New OpenFileDialog()
            openFileDialog6.InitialDirectory = "C:\"
            openFileDialog6.FilterIndex = 4
            openFileDialog6.RestoreDirectory = True

            If openFileDialog6.ShowDialog() = DialogResult.OK Then
                Dim dir As String = openFileDialog6.FileName
                txt_ruta_carpeta_fotografias.Text = IO.Path.GetDirectoryName(openFileDialog6.FileName)
                'patch = openFileDialog1.FileName
                'File.Copy(dir, TextBox2.Text)
                txt_ruta_carpeta_fotografias.Text = txt_ruta_carpeta_fotografias.Text & "\"
            Else
                If String.IsNullOrEmpty(openFileDialog6.FileName) Then
                    MessageBox.Show("NO SE HA SELECCIONADO NINGUN PRODUCTO")
                    Return
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub txt_ruta_carpeta_productos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ruta_carpeta_productos.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

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


    End Sub

    Private Sub txt_ruta_carpeta_productos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ruta_carpeta_productos.TextChanged

    End Sub

    Private Sub txt_ruta_carpeta_fotografias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ruta_carpeta_fotografias.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

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


    End Sub

    Private Sub txt_ruta_carpeta_fotografias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ruta_carpeta_fotografias.TextChanged

    End Sub

    Private Sub txt_ruta_imagen_menu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_menu.TextChanged

    End Sub

    Private Sub txt_ruta_imagen_ventana_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_ventana.TextChanged

    End Sub

    Private Sub txt_ruta_imagen_reportes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_reportes.TextChanged

    End Sub

    Private Sub txt_ruta_imagen_ticket_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ruta_imagen_ticket.TextChanged

    End Sub

End Class