Public Class Form_motivo_eliminacion_de_documento

    Private Sub Form_motivo_elminacion_de_documento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_CORREGIR_numero_impresion.WindowState = FormWindowState.Normal
        Form_CORREGIR_numero_impresion.Enabled = True
    End Sub

    Private Sub Form_motivo_elminacion_de_documento_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_motivo_elminacion_de_documento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub Combo_codigo_referencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_codigo_referencia.GotFocus
        Combo_codigo_referencia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_codigo_referencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_codigo_referencia.LostFocus
        Combo_codigo_referencia.BackColor = Color.White
    End Sub

    Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.GotFocus
        btn_eliminar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.LostFocus
        btn_eliminar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If Combo_codigo_referencia.Text = "" Then
            Combo_codigo_referencia.Focus()
            MsgBox("CAMPO MOTIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR EL DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO `documentos_eliminados` (`nro_doc`, `tipo_doc`, `fecha_eliminacion`, `usuario_responsable`) VALUES ('" & (Form_CORREGIR_numero_impresion.txt_nro_doc.Text) & "', '" & (Form_CORREGIR_numero_impresion.combo_documentos.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (miusuario) & "');"
            DA.SelectCommand = SC
            DA.Fill(DT)

            Form_CORREGIR_numero_impresion.eliminar()
            Me.Close()
        End If
    End Sub
End Class