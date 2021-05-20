Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_cambio_de_contraseña_asistente
    Dim estado_cierre As Integer
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        estado_cierre = 2
        Me.Close()
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        estado_cierre = 1
        Form_cambio_de_contraseña_pregunta_secreta.Show()
        Me.Close()
    End Sub

    Private Sub Form_asistente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If estado_cierre = 2 Then
            Form_menu_principal.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form_asistente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_asistente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.GotFocus
        btn_siguiente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_siguiente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.LostFocus
        btn_siguiente.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub
End Class