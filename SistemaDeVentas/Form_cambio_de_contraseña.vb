Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_cambio_de_contraseña
    Dim estado_cierre As Integer

    Private Sub Form_cambio_contraseña_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If estado_cierre = 2 Then
            Form_menu_principal.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form_cambio_contraseña_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cambio_contraseña_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtp_fecha.CustomFormat = "yyy-MM-dd"
        mostrar(0)
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar(ByVal i As Integer)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_usuario.Text = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
            txt_rut.Text = DS.Tables(DT.TableName).Rows(i).Item("rut_usuario")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If txt_contraseña1.Text = "" Then
            MsgBox("CAMPO CONTRASEÑA VACIO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            txt_contraseña1.Focus()
            Exit Sub
        End If

        If txt_contraseña2.Text = "" Then
            MsgBox("POR SEGURIDAD, REPITA SU CLAVE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            txt_contraseña2.Focus()
            Exit Sub
        End If

        If (txt_contraseña1.Text) = (txt_contraseña2.Text) Then
            ' conexion.Close()
            ' conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update usuarios set clave = '" & (txt_contraseña1.Text) & "', fecha_modificacion = '" & (dtp_fecha.Text) & "' where rut_usuario = '" & (txt_rut.Text) & "'"
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            '  conexion.Close()

            MsgBox("CONTRASEÑA RECUPERADA CON EXITO, AHORA PUEDE INICIAR SESION", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

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

        Else

            MsgBox("LAS CONTRASEÑAS NO COINCIDEN", MessageBoxIcon.Error + MsgBoxStyle.OkOnly, "ATENCION")

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub txt_contraseña1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_contraseña1.KeyPress
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

    Private Sub txt_contraseña1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_contraseña1.TextChanged

    End Sub

    Private Sub txt_contraseña2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_contraseña2.KeyPress
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

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_contraseña1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_contraseña1.GotFocus
        txt_contraseña1.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_contraseña1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_contraseña1.LostFocus
        txt_contraseña1.BackColor = Color.White
    End Sub

    Private Sub txt_contraseña2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_contraseña2.GotFocus
        txt_contraseña2.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_contraseña2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_contraseña2.LostFocus
        txt_contraseña2.BackColor = Color.White
    End Sub

    Private Sub txt_contraseña2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_contraseña2.TextChanged

    End Sub

End Class