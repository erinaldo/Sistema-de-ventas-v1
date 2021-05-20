Imports System.IO

Public Class Form_nuevo_servicio_lubricentro

    Private Sub Form_nuevo_servicio_lubricentro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_ventas_lubricentro.Enabled = True
    End Sub

    Private Sub Form_nuevo_servicio_lubricentro_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_nuevo_servicio_lubricentro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
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
        If txt_modelo.Text = "" Then
            MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_modelo.Focus()
            Exit Sub
        End If

        If txt_comentario.Text = "" Then
            MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_comentario.Focus()
            Exit Sub
        End If

        Me.Enabled = False

        SC.Connection = conexion
        SC.CommandText = "insert into servicios_lubricentro (patente, modelo, codigo_1, filtro_de_aceite, codigo_2, aceite_de_motor, codigo_3, filtro_de_aire, codigo_4, filtro_de_combustible, codigo_5, aceite_de_caja, codigo_6, aceite_diferencial, codigo_7, otros_1, codigo_8, otros_2, codigo_9, otros_3,  codigo_10, otros_4,kilometraje, cantidad_1, cantidad_2, cantidad_3, cantidad_4, cantidad_5, cantidad_6, cantidad_7,cantidad_8, cantidad_9,cantidad_10, rut_mecanico, usuario_responsable, fecha, estado, tipo_documento, nro_documento, hora, comentario) values('" & (Form_ventas_lubricentro.txt_codigo_patente.Text) & "', '" & (txt_modelo.Text) & "', '" & (Form_ventas_lubricentro.txt_codigo_6.Text) & "', '" & (Form_ventas_lubricentro.txt_nombre_6.Text) & "', '" & (Form_ventas_lubricentro.txt_codigo_1.Text) & "', '" & (Form_ventas_lubricentro.txt_nombre_1.Text) & "', '" & (Form_ventas_lubricentro.txt_codigo_7.Text) & "', '" & (Form_ventas_lubricentro.txt_nombre_7.Text) & "', '" & (Form_ventas_lubricentro.txt_codigo_8.Text) & "', '" & (Form_ventas_lubricentro.txt_nombre_8.Text) & "', '" & (Form_ventas_lubricentro.txt_codigo_4.Text) & "', '" & (Form_ventas_lubricentro.txt_nombre_4.Text) & "', '" & (Form_ventas_lubricentro.txt_codigo_3.Text) & "', '" & (Form_ventas_lubricentro.txt_nombre_3.Text) & "', '" & (Form_ventas_lubricentro.txt_codigo_9.Text) & "', '" & (Form_ventas_lubricentro.txt_nombre_9.Text) & "', '" & (Form_ventas_lubricentro.txt_codigo_2.Text) & "', '" & (Form_ventas_lubricentro.txt_nombre_2.Text) & "', '" & (Form_ventas_lubricentro.txt_codigo_5.Text) & "', '" & (Form_ventas_lubricentro.txt_nombre_5.Text) & "', '" & (Form_ventas_lubricentro.txt_codigo_10.Text) & "', '" & (Form_ventas_lubricentro.txt_nombre_10.Text) & "','" & (Form_ventas_lubricentro.txt_kilometraje.Text) & "', '" & (Form_ventas_lubricentro.txt_cantidad_6.Text) & "', '" & (Form_ventas_lubricentro.txt_cantidad_1.Text) & "', '" & (Form_ventas_lubricentro.txt_cantidad_7.Text) & "', '" & (Form_ventas_lubricentro.txt_cantidad_8.Text) & "', '" & (Form_ventas_lubricentro.txt_cantidad_4.Text) & "', '" & (Form_ventas_lubricentro.txt_cantidad_3.Text) & "', '" & (Form_ventas_lubricentro.txt_cantidad_9.Text) & "', '" & (Form_ventas_lubricentro.txt_cantidad_2.Text) & "', '" & (Form_ventas_lubricentro.txt_cantidad_5.Text) & "','" & (Form_ventas_lubricentro.txt_cantidad_10.Text) & "', '" & (Form_ventas_lubricentro.txt_rut_vendedor.Text) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "', 'PENDIENTE', '', '', '" & (Form_menu_principal.lbl_hora.Text) & "', '" & (txt_comentario.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)


        Form_ventas_lubricentro.limpiar()



        Form_ventas_lubricentro.txt_codigo_6.Focus()
        Form_ventas_lubricentro.mostrar_malla()
        Me.Close()
    End Sub

    Private Sub txt_comentario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_comentario.GotFocus
        color_foco()
    End Sub

    Private Sub txt_comentario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_comentario.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        '  txt_nombre_aceite_diferencial.Text = ""
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

    Private Sub txt_comentario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comentario.TextChanged

    End Sub

    Private Sub txt_modelo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_modelo.GotFocus
        color_foco()
    End Sub

    Private Sub txt_modelo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_modelo.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        '  txt_nombre_aceite_diferencial.Text = ""
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

    Private Sub txt_modelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_modelo.TextChanged

    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        color_foco()
    End Sub
End Class