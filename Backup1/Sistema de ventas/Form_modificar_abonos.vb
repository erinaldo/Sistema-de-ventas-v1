Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_modificar_abonos

    Private Sub Form_modificar_abonos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_agregar_abonos.Enabled = True
        Form_agregar_abonos.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_modificar_abonos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_modificar_abonos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        dtp_emision.CustomFormat = "yyy-MM-dd"
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        'If combo_documento.Text = "" Then
        '    MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR" + Chr(13), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    combo_documento.Focus()
        '    Exit Sub
        'End If

        If txt_nro_doc.Text = "" Then
            MsgBox("CAMPO NRO. DOCUMENTO VACIO, FAVOR LLENAR" + Chr(13), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc.Focus()
            Exit Sub
        End If

        Dim valormensaje As Integer
        valormensaje = MsgBox("ESTA SEGURO DE MODIFICAR LA INFORMACION DEL DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "MODIFICAR")

        If valormensaje = vbYes Then

            SC.Connection = conexion
            SC.CommandText = "UPDATE ABONO SET n_ABONO='" & (txt_nro_doc.Text) & "', FECHA='" & (dtp_emision.Text) & "', usuario_responsable = '" & (miusuario) & "'  WHERE n_abono = '" & (Form_agregar_abonos.txt_n_abono.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            ' Form_agregar_abonos.Combo_tipo.Text = combo_documento.Text
            Form_agregar_abonos.dtp_emision.Text = dtp_emision.Text
            Form_agregar_abonos.txt_n_abono.Text = txt_nro_doc.Text

            Me.Close()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub txt_nro_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_doc.KeyPress
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

    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus

    End Sub

End Class