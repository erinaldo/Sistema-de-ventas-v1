Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_autorizacion_caja
    Dim mifecha2 As String
    Private Sub Form_autorizacion_caja_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_detalle_cuadratura_caja.Visible = True Then
            Form_detalle_cuadratura_caja.WindowState = FormWindowState.Normal
            Form_detalle_cuadratura_caja.Enabled = True
        End If
    End Sub

    Private Sub Form_autorizacion_caja_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_autorizacion_caja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_fecha_caja_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
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


            If Me.lbl_autorizacion.Text = "PARA AGREGAR UN MOVIMIENTO CON OTRA FECHA, SOLICITE AUTORIZACION" Then

                fecha()

                Form_detalle_cuadratura_caja.txt_monto.Text = Trim(Replace(Form_detalle_cuadratura_caja.txt_monto.Text, "-", ""))
                Form_detalle_cuadratura_caja.txt_monto.Text = Trim(Replace(Form_detalle_cuadratura_caja.txt_monto.Text, "-", ""))
                Form_detalle_cuadratura_caja.txt_monto.Text = Trim(Replace(Form_detalle_cuadratura_caja.txt_monto.Text, "-", ""))
                Form_detalle_cuadratura_caja.txt_monto.Text = Trim(Replace(Form_detalle_cuadratura_caja.txt_monto.Text, "-", ""))

                If Form_detalle_cuadratura_caja.combo_tipo.Text = "EGRESO" Then
                    Form_detalle_cuadratura_caja.txt_monto.Text = "-" & Form_detalle_cuadratura_caja.txt_monto.Text
                End If
                If Form_detalle_cuadratura_caja.combo_tipo.Text = "ANTICIPOS" Then
                    Form_detalle_cuadratura_caja.txt_monto.Text = "-" & Form_detalle_cuadratura_caja.txt_monto.Text
                End If
                If Form_detalle_cuadratura_caja.combo_tipo.Text = "EGRESOS CON BOLETA" Then
                    Form_detalle_cuadratura_caja.txt_monto.Text = "-" & Form_detalle_cuadratura_caja.txt_monto.Text
                End If
                If Form_detalle_cuadratura_caja.combo_tipo.Text = "EGRESOS CON FACTURA" Then
                    Form_detalle_cuadratura_caja.txt_monto.Text = "-" & Form_detalle_cuadratura_caja.txt_monto.Text
                End If
                If Form_detalle_cuadratura_caja.combo_tipo.Text = "OTROS EGRESOS CON FACTURA" Then
                    Form_detalle_cuadratura_caja.txt_monto.Text = "-" & Form_detalle_cuadratura_caja.txt_monto.Text
                End If
                If Form_detalle_cuadratura_caja.combo_tipo.Text = "PENDIENTE" Then
                    Form_detalle_cuadratura_caja.txt_monto.Text = "-" & Form_detalle_cuadratura_caja.txt_monto.Text
                End If




                SC.Connection = conexion
                SC.CommandText = "insert into detalle_cuadratura_caja (detalle, monto, fecha, TIPO, usuario_responsable, hora) values ('" & (Form_detalle_cuadratura_caja.Combo_detalle.Text) & "' , '" & (Form_detalle_cuadratura_caja.txt_monto.Text) & "', '" & (mifecha2) & "','" & (Form_detalle_cuadratura_caja.combo_tipo.Text) & "','" & (miusuario) & "','" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                Form_detalle_cuadratura_caja.cargar_detalle()

                Form_detalle_cuadratura_caja.Combo_detalle.Text = ""
                Form_detalle_cuadratura_caja.txt_monto.Text = ""
                Form_detalle_cuadratura_caja.combo_tipo.SelectedItem = "-"

                Form_detalle_cuadratura_caja.Combo_detalle.Focus()
                Me.Close()
            End If


            If Me.lbl_autorizacion.Text = "PARA CAMBIAR LA FECHA SOLICITE AUTORIZACION" Then
                Form_detalle_cuadratura_caja.cargar_detalle()
                Me.Close()
            End If




            If Form_detalle_cuadratura_caja.Visible = True Then
                If Me.lbl_autorizacion.Text = "PARA ELIMINAR UN MOVIMIENTO SOLICITE AUTORIZACION" Then
                    Me.Enabled = False

                    Dim VarDetalle As String
                    Dim VarMonto As Integer
                    Dim VarTipo As String

                    VarDetalle = Form_detalle_cuadratura_caja.grilla_detalle_cuadratura.CurrentRow.Cells(0).Value
                    VarMonto = Form_detalle_cuadratura_caja.grilla_detalle_cuadratura.CurrentRow.Cells(1).Value
                    VarTipo = Form_detalle_cuadratura_caja.grilla_detalle_cuadratura.CurrentRow.Cells(3).Value



                    SC.Connection = conexion
                    SC.CommandText = "delete from detalle_cuadratura_caja where cod_auto = '" & (Form_detalle_cuadratura_caja.txt_cod_auto.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    Form_detalle_cuadratura_caja.txt_cod_auto.Text = ""
                    Form_detalle_cuadratura_caja.txt_monto.Text = ""
                    Form_detalle_cuadratura_caja.Combo_detalle.Text = ""
                    Form_detalle_cuadratura_caja.combo_tipo.Text = "-"

                    Form_detalle_cuadratura_caja.grilla_detalle_cuadratura.Rows.Remove(Form_detalle_cuadratura_caja.grilla_detalle_cuadratura.CurrentRow)
                    Form_detalle_cuadratura_caja.Combo_detalle.Focus()
                    Me.Close()
                End If
            End If
        Else
            MsgBox("USUARIO O CLAVE INCORRECTOS", 0 + 16, "ATENCION")
            txt_usuario.Text = ""
            txt_clave.Text = ""
            txt_usuario.Focus()
            conexion.Close()
            DS.Tables.Clear()
            Exit Sub
        End If
        Me.Enabled = False
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

    Private Sub txt_usuario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_usuario.LostFocus
        txt_usuario.BackColor = Color.White
    End Sub

    Private Sub txt_clave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave.GotFocus
        txt_clave.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_clave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave.LostFocus
        txt_clave.BackColor = Color.White
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

    Private Sub txt_usuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_usuario.TextChanged

    End Sub

    Private Sub txt_clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_clave.TextChanged

    End Sub
End Class