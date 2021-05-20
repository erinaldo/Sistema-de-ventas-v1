Public Class Form_venta_orden_de_compra

    Private Sub Form_venta_orden_de_compra_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_venta_orden_de_compra_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_venta.txt_nro_orden_de_compra.Text = nro_801

        If combo_documento.Text = "801" Then
            doc_otro = "ORDEN DE COMPRA"
        End If
        If combo_documento.Text = "802" Then
            doc_otro = "NUMERO DE ATENCION"
        End If
        If combo_documento.Text = "HES" Then
            doc_otro = "HOJA DE ENTRADA"
        End If

        nro_801 = txt_801.Text
        nro_802 = txt_802.Text
        nro_hes = txt_hes.Text
        nro_otro = txt_otro.Text
        codigo_doc_otro = combo_documento.Text

        fecha_801 = Format(CDate(dtp_801.Text), "yyyy-MM-dd")
        fecha_802 = Format(CDate(dtp_802.Text), "yyyy-MM-dd")
        fecha_hes = Format(CDate(dtp_hes.Text), "yyyy-MM-dd")
        fecha_otro = Format(CDate(dtp_otro.Text), "yyyy-MM-dd")

        If nro_801 = "" Then
            nro_801 = "0"
            fecha_801 = "0000-00-00"
        End If
        If nro_802 = "" Then
            nro_802 = "0"
            fecha_802 = "0000-00-00"
        End If
        If nro_hes = "" Then
            nro_hes = "0"
            fecha_hes = "0000-00-00"
        End If
        If nro_otro = "" Then
            nro_otro = "0"
            codigo_doc_otro = "-"
            fecha_otro = "0000-00-00"
        End If

    End Sub

    Private Sub Form_venta_orden_de_compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo_documento.Text = "801"

        If nro_801 <> "0" Then
            txt_801.Text = nro_801
            dtp_801.Text = fecha_801
        End If

        If nro_802 <> "0" Then
            txt_802.Text = nro_802
            dtp_802.Text = fecha_802
        End If

        If nro_hes <> "0" Then
            txt_hes.Text = nro_hes
            dtp_hes.Text = fecha_hes
        End If

        If nro_otro <> "0" Then
            txt_otro.Text = nro_otro
            dtp_801.Text = fecha_otro
            combo_documento.Text = codigo_doc_otro
        End If

    End Sub

    Private Sub txt_801_TextChanged(sender As Object, e As EventArgs) Handles txt_801.TextChanged

    End Sub

    Private Sub txt_801_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_801.KeyPress

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

    Private Sub txt_802_TextChanged(sender As Object, e As EventArgs) Handles txt_802.TextChanged

    End Sub

    Private Sub txt_802_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_802.KeyPress

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

    Private Sub txt_hes_TextChanged(sender As Object, e As EventArgs) Handles txt_hes.TextChanged

    End Sub

    Private Sub txt_hes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_hes.KeyPress

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

    Private Sub txt_otro_TextChanged(sender As Object, e As EventArgs) Handles txt_otro.TextChanged

    End Sub

    Private Sub txt_otro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_otro.KeyPress

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

    Private Sub btn_aceptar_Click_1(sender As Object, e As EventArgs) Handles btn_aceptar.Click
        If combo_documento.Text = "801" Then
            doc_otro = "ORDEN DE COMPRA"
        End If
        If combo_documento.Text = "802" Then
            doc_otro = "NUMERO DE ATENCION"
        End If
        If combo_documento.Text = "HES" Then
            doc_otro = "HOJA DE ENTRADA"
        End If

        nro_801 = txt_801.Text
        nro_802 = txt_802.Text
        nro_hes = txt_hes.Text
        nro_otro = txt_otro.Text
        codigo_doc_otro = combo_documento.Text

        fecha_801 = Format(CDate(dtp_801.Text), "yyyy-MM-dd")
        fecha_802 = Format(CDate(dtp_802.Text), "yyyy-MM-dd")
        fecha_hes = Format(CDate(dtp_hes.Text), "yyyy-MM-dd")
        fecha_otro = Format(CDate(dtp_otro.Text), "yyyy-MM-dd")
        Me.Close()
    End Sub
End Class