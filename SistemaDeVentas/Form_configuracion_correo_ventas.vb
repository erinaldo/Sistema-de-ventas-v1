Imports System.IO
Public Class Form_configuracion_correo_ventas

    Private Sub Form_configuracion_correo_ventas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_configuracion_correo_ventas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_configuracion_correo_ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        combo_seguridad_ssl.Text = "-"
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from correo_de_ventas"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        mostrar(0)
        conexion.Close()
        controles(False, True)
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar(ByVal i As Integer)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_email.Text = DS.Tables(DT.TableName).Rows(i).Item("correo")
            txt_clave_email.Text = DS.Tables(DT.TableName).Rows(i).Item("clave_correo")
            txt_clave_email_repetir.Text = DS.Tables(DT.TableName).Rows(i).Item("clave_correo")
            combo_seguridad_ssl.Text = DS.Tables(DT.TableName).Rows(i).Item("seguridad_ssl")
            txt_puerto_smtp.Text = DS.Tables(DT.TableName).Rows(i).Item("puerto_smtp")
            txt_servidor_smtp.Text = DS.Tables(DT.TableName).Rows(i).Item("servidor_smtp")
        End If
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_modificar.Enabled = b
        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a
        txt_email.Enabled = a
        txt_clave_email.Enabled = a
        txt_clave_email_repetir.Enabled = a
        combo_seguridad_ssl.Enabled = a
        txt_puerto_smtp.Enabled = a
        txt_servidor_smtp.Enabled = a
    End Sub

    Sub limpiar()
        txt_email.Text = ""
        txt_clave_email.Text = ""
        txt_clave_email_repetir.Text = ""
        combo_seguridad_ssl.Text = "-"
        txt_puerto_smtp.Text = ""
        txt_servidor_smtp.Text = ""
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        controles(True, False)
        txt_email.Focus()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        mostrar(0)
        controles(False, True)
    End Sub

    Sub actualizar_tabla()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from correo_de_ventas"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If txt_email.Text = "" Then
            txt_email.Focus()
            MsgBox("CAMPO CORREO DE VENTAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_clave_email.Text = "" Then
            txt_clave_email.Focus()
            MsgBox("CAMPO CLAVE DE CORREO DE VENTAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_clave_email_repetir.Text = "" Then
            txt_clave_email_repetir.Focus()
            MsgBox("CAMPO CLAVE DE CORREO DE VENTAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_seguridad_ssl.Text = "-" Then
            combo_seguridad_ssl.Focus()
            MsgBox("CAMPO SEGURIDAD SSL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_puerto_smtp.Text = "" Then
            txt_puerto_smtp.Focus()
            MsgBox("CAMPO PUERTO SMTP VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_servidor_smtp.Text = "" Then
            txt_servidor_smtp.Focus()
            MsgBox("CAMPO SERVIDOR SMTP VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_clave_email.Text <> txt_clave_email_repetir.Text Then
            txt_clave_email.Focus()
            MsgBox("LAS CLAVES NO COINCIDEN DE VENTAS, FAVOR VERIFICAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If ValidEmail(txt_email.Text) = False Then
            txt_email.Focus()
            txt_email.SelectAll()
            Exit Sub
        End If

        SC.Connection = conexion
        SC.CommandText = "DELETE FROM `correo_de_ventas`"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `correo_de_ventas` (`correo`, `clave_correo`, `seguridad_ssl`, `puerto_smtp`, `servidor_smtp`) VALUES ('" & (txt_email.Text) & "', '" & (txt_clave_email.Text) & "', '" & (combo_seguridad_ssl.Text) & "', '" & (txt_puerto_smtp.Text) & "', '" & (txt_servidor_smtp.Text) & "');"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, tipo, usuario_responsable) values('CORREO','MODIFICACION DE CORREO','" & (txt_email.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        conexion.Close()
        MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        actualizar_tabla()

        micorreoempresa = txt_email.Text
        miclavecorreoempresa = txt_clave_email.Text

        controles(False, True)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_clave_email_repetir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave_email_repetir.GotFocus
        txt_clave_email_repetir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_clave_email_repetir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave_email_repetir.LostFocus
        txt_clave_email_repetir.BackColor = Color.White
    End Sub

    Private Sub txt_puerto_smtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_puerto_smtp.GotFocus
        txt_puerto_smtp.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_puerto_smtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_puerto_smtp.LostFocus
        txt_puerto_smtp.BackColor = Color.White
    End Sub

    Private Sub combo_seguridad_ssl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_seguridad_ssl.GotFocus
        combo_seguridad_ssl.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_seguridad_ssl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_seguridad_ssl.LostFocus
        combo_seguridad_ssl.BackColor = Color.White
    End Sub

    Private Sub txt_servidor_smtp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_servidor_smtp.GotFocus
        txt_servidor_smtp.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_servidor_smtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_servidor_smtp.KeyPress
        'e.KeyChar = e.KeyChar.ToString.ToUpper

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

    Private Sub txt_servidor_smtp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_servidor_smtp.LostFocus
        txt_servidor_smtp.BackColor = Color.White
    End Sub

    Private Sub txt_email_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_email.KeyPress
        'e.KeyChar = e.KeyChar.ToString.ToUpper

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

    Private Sub txt_clave_email_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_clave_email.KeyPress
        'e.KeyChar = e.KeyChar.ToString.ToUpper

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

    Private Sub txt_clave_email_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave_email.GotFocus
        txt_clave_email.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_clave_email_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave_email.LostFocus
        txt_clave_email.BackColor = Color.White
    End Sub

    Private Sub txt_email_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_email.GotFocus
        txt_email.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_email_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_email.LostFocus
        txt_email.BackColor = Color.White
    End Sub

    Private Sub txt_clave_email_repetir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_clave_email_repetir.KeyPress
        'e.KeyChar = e.KeyChar.ToString.ToUpper

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

    Private Sub txt_puerto_smtp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_puerto_smtp.KeyPress
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

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_email_TextChanged(sender As Object, e As EventArgs) Handles txt_email.TextChanged

    End Sub

    Private Sub txt_clave_email_TextChanged(sender As Object, e As EventArgs) Handles txt_clave_email.TextChanged

    End Sub

    Private Sub txt_clave_email_repetir_TextChanged(sender As Object, e As EventArgs) Handles txt_clave_email_repetir.TextChanged

    End Sub

    Private Sub txt_servidor_smtp_TextChanged(sender As Object, e As EventArgs) Handles txt_servidor_smtp.TextChanged

    End Sub
End Class