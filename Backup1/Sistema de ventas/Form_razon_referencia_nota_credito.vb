Imports System.IO
Public Class Form_razon_referencia_nota_credito

    Private Sub Form_razon_referencia_nota_credito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_impreso_corectamente.Visible = True Or Form_autorizacion.Visible = True Or Form_seleccionar_documento_para_nota_credito.Visible = True Then
            Form_nota_credito.Enabled = False
        Else
            Form_nota_credito.Enabled = True
            Form_nota_credito.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form_razon_referencia_nota_credito_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_razon_referencia_nota_credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If txt_razon_referencia.Text = "" Then
            MsgBox("DEBE INGRESAR UNA RAZON AL DE DOC. DE REFERENCIA", 0 + 16, "ERROR")
            Exit Sub
        End If

        'razon_referencia_nota_credito = txt_razon_referencia.Text
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub txt_razon_referencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_razon_referencia.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
    End Sub

    Private Sub txt_razon_referencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_razon_referencia.TextChanged

    End Sub
End Class