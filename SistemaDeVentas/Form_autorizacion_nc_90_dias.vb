Public Class Form_autorizacion_nc_90_dias
    Dim autorizacion_nc As String = "NO"
    Private Sub Form_autorizacion_nc_90_dias_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If autorizacion_nc = "NO" Then
            Form_nota_credito.limpiar()
            Form_nota_credito.WindowState = FormWindowState.Normal
            Form_nota_credito.Enabled = True
        Else
            Form_nota_credito.WindowState = FormWindowState.Normal
            Form_nota_credito.Enabled = True
        End If
    End Sub

    Private Sub Form_autorizacion_nc_90_dias_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_autorizacion_nc_90_dias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl_autorizacion.Text = "LA FECHA DEL DOCUMENTO ES MAYOR A 90 DIAS, SOLICITE AUTORIZACION"
        Form_nota_credito.Enabled = False
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        ' SC.CommandText = "Select * from usuarios where Usuario = '" & (txt_usuario.Text) & "' and Clave ='" & (txt_clave.Text) & "' "
        SC.CommandText = "Select * from usuarios where Usuario = '" & (txt_usuario.Text) & "' and Clave ='" & (txt_clave.Text) & "' and autoriza_venta='SI' and tipo_usuario='ADMINISTRADOR DEL SISTEMA'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            autorizacion_nc = "SI"
            Form_nota_credito.WindowState = FormWindowState.Normal
            Form_nota_credito.Enabled = True
            Me.Close()
        Else
            MsgBox("USUARIO O CLAVE INCORRECTOS", 0 + 16, "ATENCION")
            txt_usuario.Text = ""
            txt_clave.Text = ""
            txt_usuario.Focus()
            conexion.Close()
            DS.Tables.Clear()
            Exit Sub
        End If

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        autorizacion_nc = "NO"
        Form_nota_credito.limpiar()
        Me.Close()
    End Sub
End Class