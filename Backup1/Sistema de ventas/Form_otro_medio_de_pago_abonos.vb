Imports System.IO
Imports System.Drawing.Drawing2D
Public Class Form_otro_medio_de_pago_abonos

    Private Sub Form_otro_medio_de_pago_abonos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If txt_medio_pago.Text = "" Then
            Form_agregar_abonos.combo_condiciones.SelectedItem = "-"
        End If
        Form_agregar_abonos.WindowState = FormWindowState.Normal
        Form_agregar_abonos.Enabled = True
    End Sub

    Private Sub Form_otro_medio_de_pago_abonos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_otro_medio_de_pago_abonos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub


    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If txt_medio_pago.Text = "" Then
            MsgBox("CAMPO MEDIO DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_medio_pago.Focus()
            Exit Sub
        End If

        Form_agregar_abonos.combo_condiciones.Items.Add(txt_medio_pago.Text)
        Form_agregar_abonos.combo_condiciones.SelectedItem = txt_medio_pago.Text
        Me.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click

        If txt_medio_pago.Text = "" Then
            Form_agregar_abonos.combo_condiciones.SelectedItem = "-"
        End If
        Me.Close()
    End Sub

    Private Sub txt_medio_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_medio_pago.GotFocus
        txt_medio_pago.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_medio_pago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_medio_pago.LostFocus
        txt_medio_pago.BackColor = Color.White
    End Sub



    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        btn_aceptar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub txt_medio_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_medio_pago.KeyPress
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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_aceptar.PerformClick()
        End If

    End Sub

    Private Sub txt_medio_pago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_medio_pago.TextChanged

    End Sub
End Class