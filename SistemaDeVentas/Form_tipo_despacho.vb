Public Class Form_tipo_despacho

    Private Sub Form_tipo_despacho_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_venta.Enabled = True
        Form_venta.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_tipo_despacho_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_tipo_despacho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        combo_documento.Text = "-"
        tipo_documento = ""
        'combo_documento.DroppedDown = True
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If combo_documento.Text = "-" Then
            combo_documento.Focus()
            MsgBox("DEBE SELECCIONAR UN A OPCION", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If combo_documento.Text = "" Then
            combo_documento.Focus()
            MsgBox("DEBE SELECCIONAR UN A OPCION", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If combo_documento.Text = "SIN DESPACHO" Then
        '    tipo_despacho = "0"
        'End If
        'If combo_documento.Text = "DESPACHO POR CUENTA DEL RECEPTOR DEL DOCUMENTO" Then
        '    tipo_despacho = "1"
        'End If
        'If combo_documento.Text = "DESPACHO POR CUENTA DEL EMISOR A INSTALACIONES DEL CLIENTE" Then
        '    tipo_despacho = "2"
        'End If
        'If combo_documento.Text = "DESPACHO POR CUENTA DEL EMISOR A OTRAS INSTALACIONES" Then
        '    tipo_despacho = "3"
        'End If
        'If combo_documento.Text = "DESPACHO POR CUENTA DEL EMISOR A OTRAS INSTALACIONES" Then
        '    tipo_despacho = "3"
        'End If


        If combo_documento.Text = "RETIRA CLIENTE" Then
            tipo_despacho = "1"
        End If

        If combo_documento.Text = "ENVIO A DOMICILIO" Then
            tipo_despacho = "2"
        End If

        Form_venta.descuento()

        If VarAutorizacionVenta = "" Then
            Exit Sub
        End If

        Form_venta.imprimir()
        VarAutorizacionVenta = ""
        Me.Close()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub combo_documento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_documento.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_agregar.Focus()
        End If
    End Sub

    Private Sub combo_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documento.SelectedIndexChanged

    End Sub
End Class