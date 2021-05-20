Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_autorizacion_cambio_producto

    Private Sub Form_autorizacion_cambio_producto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Form_impreso_corectamente.Visible = True Then
            Form_cambio_de_producto.Enabled = False
        Else
            Form_cambio_de_producto.Enabled = True
            Form_cambio_de_producto.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form_autorizacion_cambio_producto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_autorizacion_cambio_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        ' SC.CommandText = "Select * from usuarios where Usuario = '" & (txt_usuario.Text) & "' and Clave ='" & (txt_clave.Text) & "' "
        SC.CommandText = "Select * from usuarios where Usuario = '" & (txt_usuario.Text) & "' and Clave ='" & (txt_clave.Text) & "' and autoriza_venta='SI' "
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            Dim rut_usuario_autoriza As String
            Dim tipo_usuario_autoriza As String
            rut_usuario_autoriza = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            tipo_usuario_autoriza = DS.Tables(DT.TableName).Rows(0).Item("tipo_usuario")

            If Form_cambio_de_producto.txt_porcentaje_desc.Text > Int(12) And tipo_usuario_autoriza = "USUARIO DEL SISTEMA" Then
                MsgBox("ESTE DESCUENTO DEBE SER AUTORIZADO POR UN ADMINISTRADOR DE SISTEMA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('AUTORIZACION','" & ("AUTORIZACION PARA CAMBIO" & Form_cambio_de_producto.txt_tipo_doc_referencia.Text & " " & Form_cambio_de_producto.txt_nro_doc_referencia.Text) & "','" & (Form_cambio_de_producto.txt_tipo_doc_referencia.Text & " " & Form_cambio_de_producto.txt_nro_doc_referencia.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','AUTORIZACION','" & (rut_usuario_autoriza) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            conexion.Close()

            Form_cambio_de_producto.redondear_documento()
            Form_cambio_de_producto.calcular_totales_entra()
            Form_cambio_de_producto.calcular_totales_sale()

            Form_cambio_de_producto.imprimir()

            Form_cambio_de_producto.Close()
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
        Me.Close()
    End Sub

    Private Sub txt_clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_clave.KeyPress

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

    Private Sub txt_usuario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_usuario.GotFocus
        txt_usuario.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_usuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_usuario.KeyPress
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
            txt_clave.Focus()
        End If
    End Sub

    Private Sub txt_usuario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_usuario.LostFocus
        txt_usuario.BackColor = Color.White
    End Sub

    Private Sub txt_clave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave.GotFocus
        txt_clave.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_clave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave.LostFocus
        txt_clave.BackColor = Color.White
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


    Private Sub txt_usuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_usuario.TextChanged

    End Sub

    Private Sub txt_clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_clave.TextChanged

    End Sub
End Class