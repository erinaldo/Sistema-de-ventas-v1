Imports System.IO

Public Class Form_nueva_orden_de_trabajo
    Private Sub Form_nueva_orden_de_trabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Private Sub Form_nueva_orden_de_trabajo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_orden_de_trabajo.Enabled = True
    End Sub

    Private Sub Form_nueva_orden_de_trabajo_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub




    Sub color_foco()


        Dim controlcito As Control
        Dim controlChild As Control


        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).ReadOnly = False Then
                    CType(controlcito, TextBox).BackColor = Color.White
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                CType(controlcito, ComboBox).BackColor = Color.White
            End If

            If TypeOf controlcito Is Button Then
                CType(controlcito, Button).BackColor = Color.Transparent
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).ReadOnly = False Then
                            CType(controlChild, TextBox).BackColor = Color.White
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        CType(controlChild, ComboBox).BackColor = Color.White
                    End If

                    If TypeOf controlChild Is Button Then
                        CType(controlChild, Button).BackColor = Color.Transparent
                    End If
                Next
            End If

            If TypeOf controlcito Is Panel Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).ReadOnly = False Then
                            CType(controlChild, TextBox).BackColor = Color.White
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        CType(controlChild, ComboBox).BackColor = Color.White
                    End If

                    If TypeOf controlChild Is Button Then
                        CType(controlChild, Button).BackColor = Color.Transparent
                    End If
                Next
            End If

        Next











        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).Focused Then
                    If CType(controlcito, TextBox).ReadOnly = False Then
                        CType(controlcito, TextBox).BackColor = Color.LightSkyBlue
                        Exit Sub
                    End If
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                If CType(controlcito, ComboBox).Focused Then
                    CType(controlcito, ComboBox).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is Button Then
                If CType(controlcito, Button).Focused Then
                    CType(controlcito, Button).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).Focused Then
                            If CType(controlChild, TextBox).ReadOnly = False Then
                                CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
                                Exit Sub
                            End If
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        If CType(controlChild, ComboBox).Focused Then
                            CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If

                    If TypeOf controlChild Is Button Then
                        If CType(controlChild, Button).Focused Then
                            CType(controlChild, Button).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If
                Next
            End If


            If TypeOf controlcito Is Panel Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).Focused Then
                            If CType(controlChild, TextBox).ReadOnly = False Then
                                CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
                                Exit Sub
                            End If
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        If CType(controlChild, ComboBox).Focused Then
                            CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If

                    If TypeOf controlChild Is Button Then
                        If CType(controlChild, Button).Focused Then
                            CType(controlChild, Button).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If
                Next
            End If

        Next
    End Sub


    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If txt_rut.Text = "" Then
            MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If
        If txt_nombre.Text = "" Then
            MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre.Focus()
            Exit Sub
        End If
        If txt_telefono.Text = "" Then
            MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_telefono.Focus()
            Exit Sub
        End If
        If txt_comentario.Text = "" Then
            MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_comentario.Focus()
            Exit Sub
        End If

        Me.Enabled = False

        SC.Connection = conexion
        SC.CommandText = "insert into orden_de_trabajo (rut_cliente, nombre_cliente, telefono_cliente, comentario, codigo_1, codigo_2, codigo_3, codigo_4, codigo_5, codigo_6, codigo_7, codigo_8, codigo_9, codigo_10, codigo_11, codigo_12, codigo_13, codigo_14, codigo_15, nombre_1, nombre_2, nombre_3,  nombre_4, nombre_5, nombre_6, nombre_7, nombre_8, nombre_9, nombre_10, nombre_11, nombre_12, nombre_13, nombre_14, nombre_15, cantidad_1, cantidad_2, cantidad_3, cantidad_4, cantidad_5, cantidad_6, cantidad_7,cantidad_8, cantidad_9, cantidad_10, cantidad_11, cantidad_12, cantidad_13, cantidad_14, cantidad_15, rut_mecanico, usuario_responsable, fecha, estado, tipo_documento, nro_documento, hora) values('" & (txt_rut.Text) & "', '" & (txt_nombre.Text) & "', '" & (txt_telefono.Text) & "', '" & (txt_comentario.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_1.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_2.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_3.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_4.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_5.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_6.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_7.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_8.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_9.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_10.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_11.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_12.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_13.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_14.Text) & "', '" & (Form_orden_de_trabajo.txt_codigo_15.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_1.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_2.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_3.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_4.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_5.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_6.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_7.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_8.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_9.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_10.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_11.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_12.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_13.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_14.Text) & "', '" & (Form_orden_de_trabajo.txt_nombre_15.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_1.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_2.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_3.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_4.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_5.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_6.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_7.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_8.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_9.Text) & "','" & (Form_orden_de_trabajo.txt_cantidad_10.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_11.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_12.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_13.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_14.Text) & "', '" & (Form_orden_de_trabajo.txt_cantidad_15.Text) & "', '" & (Form_orden_de_trabajo.txt_rut_vendedor.Text) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "', 'PENDIENTE', '', '', '" & (Form_menu_principal.lbl_hora.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        Form_orden_de_trabajo.limpiar()



        Form_orden_de_trabajo.txt_codigo_1.Focus()
        Form_orden_de_trabajo.mostrar_malla()
        Me.Close()
    End Sub

    Private Sub txt_comentario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_comentario.GotFocus
        color_foco()
    End Sub

    Private Sub txt_comentario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_comentario.KeyPress
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            btn_grabar.Focus()

        End If
    End Sub

    Private Sub txt_rut_TextChanged(sender As Object, e As EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub txt_rut_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_rut.KeyUp

    End Sub

    Private Sub txt_rut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_rut.KeyPress
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            txt_nombre.Focus()

        End If
    End Sub

    Private Sub txt_nombre_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre.TextChanged

    End Sub

    Private Sub txt_nombre_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_nombre.KeyUp

    End Sub

    Private Sub txt_nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nombre.KeyPress
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            txt_telefono.Focus()

        End If
    End Sub

    Private Sub txt_telefono_TextChanged(sender As Object, e As EventArgs) Handles txt_telefono.TextChanged

    End Sub

    Private Sub txt_telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_telefono.KeyPress
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            txt_comentario.Focus()

        End If
    End Sub

    Private Sub txt_comentario_TextChanged(sender As Object, e As EventArgs) Handles txt_comentario.TextChanged

    End Sub

    Private Sub txt_comentario_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_comentario.KeyDown

    End Sub
End Class