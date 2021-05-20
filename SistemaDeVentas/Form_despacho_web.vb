Imports System.Net.Mail
Imports System.Drawing.Drawing2D
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Form_despacho_web
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean
    Dim message As New MailMessage
    Dim smtp As New SmtpClient
    Dim correo_foco As String
    Dim desglose_total_cotizacion As String
    Dim peso As String

    Dim email As String
    Dim clave_email As String
    Dim seguridad_ssl As String
    Dim puerto_smtp As String
    Dim servidor_smtp As String
    Dim numero_lineas_total As Integer = 0
    Dim nombre_archivo As String

    Private Sub Form_despacho_web_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()

        SetDefaultPrinter(impresora_guias)

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from correos_electronicos"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        If DS.Tables(DT.TableName).Rows.Count > 0 Then


            For i = 0 To DS.Tables(0).Rows.Count - 1
                col.Add(DS.Tables(0).Rows(i)("correo_electronico").ToString())
            Next
            txt_correo.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_correo.AutoCompleteCustomSource = col
            txt_correo.AutoCompleteMode = AutoCompleteMode.Suggest

            txt_correo_copia.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_correo_copia.AutoCompleteCustomSource = col
            txt_correo_copia.AutoCompleteMode = AutoCompleteMode.Suggest
        End If

        txt_correo.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_correo.AutoCompleteCustomSource = col
        txt_correo.AutoCompleteMode = AutoCompleteMode.Suggest

        txt_correo_copia.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_correo_copia.AutoCompleteCustomSource = col
        txt_correo_copia.AutoCompleteMode = AutoCompleteMode.Suggest

        mostrar_datos_correo()


        combo_tipo.Text = "BOLETA"
        Combo_transporte.Text = "CHILEXPRESS"
        txt_nro_doc.Focus()
    End Sub

    Private Sub Form_despacho_web_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_despacho_web_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Sub mostrar_datos_correo()

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
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            email = DS.Tables(DT.TableName).Rows(0).Item("correo")
            clave_email = DS.Tables(DT.TableName).Rows(0).Item("clave_correo")
            seguridad_ssl = DS.Tables(DT.TableName).Rows(0).Item("seguridad_ssl")
            puerto_smtp = DS.Tables(DT.TableName).Rows(0).Item("puerto_smtp")
            servidor_smtp = DS.Tables(DT.TableName).Rows(0).Item("servidor_smtp")
        End If
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar.Click

        If combo_tipo.Text = "-" Then
            MsgBox("CAMPO TIPO DOC. VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_tipo.Focus()
            Exit Sub
        End If

        If txt_nro_doc.Text = "" Then
            MsgBox("CAMPO NRO. DOC. VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc.Focus()
            Exit Sub
        End If

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO NOMBRE CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_cliente.Focus()
            Exit Sub
        End If

        If txt_correo.Text = "" Then
            MsgBox("CAMPO CORREO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_correo.Focus()
            Exit Sub
        End If

        If ValidEmail(txt_correo.Text) = False Then
            txt_correo.Focus()
            txt_correo.SelectAll()
            Exit Sub
        End If

        If txt_correo_copia.Text <> "" Then
            If ValidEmail(txt_correo_copia.Text) = False Then
                txt_correo_copia.Focus()
                txt_correo_copia.SelectAll()
                Exit Sub
            End If
        End If

        If Combo_transporte.Text = "-" Then
            MsgBox("CAMPO TRANSPORTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_transporte.Focus()
            Exit Sub
        End If

        If txt_nro_ot.Text = "" Then
            MsgBox("CAMPO NRO. OT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_ot.Focus()
            Exit Sub
        End If

        If combo_tipo.Text = "BOLETA" Then
            conexion.Close()
            Consultas_SQL("select * from boleta where n_boleta = '" & (txt_nro_doc.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count = 0 Then
                MsgBox("NUMERO DE BOLETA NO EXISTE", 0 + 16, "ATENCION")
                Exit Sub
            End If
        End If

        If combo_tipo.Text = "FACTURA" Then
            conexion.Close()
            Consultas_SQL("select * from factura where n_factura = '" & (txt_nro_doc.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count = 0 Then
                MsgBox("NUMERO DE FACTURA NO EXISTE", 0 + 16, "ATENCION")
                Exit Sub
            End If
        End If

        lbl_correo.Visible = True
        Me.Enabled = False

        conexion.Close()
        Consultas_SQL("select * from correos_electronicos where correo_electronico = '" & (txt_correo.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

        Else
            SC.Connection = conexion
            SC.CommandText = "INSERT INTO correos_electronicos (correo_electronico) VALUES ('" & (txt_correo.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If


        'Dim adjunto As System.Net.Mail.Attachment
        'adjunto = Nothing
        'adjunto = New System.Net.Mail.Attachment("C:\Cotizaciones\" & nombre_archivo)
        message.From = New MailAddress(email)

        If txt_correo_copia.Text = "" Then
            message.To.Add(txt_correo.Text)
            message.To.Add(email)
        Else
            message.To.Add(txt_correo.Text)
            message.To.Add(txt_correo_copia.Text)
            message.To.Add(email)
        End If

        message.IsBodyHtml = True

        Dim link_seguimiento As String = ""

        If Combo_transporte.Text = "CHILEXPRESS" Then
            link_seguimiento = "El pedido web N° " & txt_nro_pedido.Text & " ya ha sido entregado al courier CHILEXPRESS. Puedes ver el estado del envío en la web del courier <a href='https://www.chilexpress.cl' target='_blank'>Chilexpress</a> buscando con el número de seguimiento " & txt_nro_ot.Text & "."
        End If

        If Combo_transporte.Text = "CORREOS" Then
            link_seguimiento = "El pedido web N° " & txt_nro_pedido.Text & " ya ha sido entregado al courier CORREOS. Puedes ver el estado del envío en la web del courier <a href='https://www.correos.cl' target='_blank'>Correos</a> buscando con el número de seguimiento " & txt_nro_ot.Text & "."
        End If

        If Combo_transporte.Text = "STARKEN" Then
            link_seguimiento = "Tu orden ha sido enviada.  <br>" & "El pedido web N° " & txt_nro_pedido.Text & " ya ha sido entregado al courier STARKEN. Puedes ver el estado del envío en la web del courier <a href='https://www.starken.cl' target='_blank'>Starken</a> buscando con el número de seguimiento " & txt_nro_ot.Text & "."
        End If

        If Combo_transporte.Text = "FEDEX/TNT" Then
            link_seguimiento = "Tu orden ha sido enviada.  <br>" & "El pedido web N° " & txt_nro_pedido.Text & " ya ha sido entregado al courier FEDEX/TNT. Puedes ver el estado del envío en la web del courier <a href='https://www.tnt.com/express/es_cl/site/home.html' target='_blank'>FEDEX/TNT</a> buscando con el número de seguimiento " & txt_nro_ot.Text & "."
        End If

        If Combo_transporte.Text = "PULLMAN" Then
            link_seguimiento = "Tu orden ha sido enviada.  <br>" & "El pedido web N° " & txt_nro_pedido.Text & " ya ha sido entregado al courier PULLMAN. Puedes ver el estado del envío en la web del courier <a href='http://www.pullmancargo.cl/WEB/seguimiento.html' target='_blank'>PULLMAN</a> buscando con el número de seguimiento " & txt_nro_ot.Text & "."
        End If

        If Combo_transporte.Text = "RETIRO EN TIENDA" Then
            link_seguimiento = "El pedido web N° " & txt_nro_pedido.Text & " ya ha sido procesado. Puedes venir a retirarlo en Bernardo O'Higgins 441, San Fernando."
        End If

        If Combo_transporte.Text = "TRANSPORTE PROPIO" Then
            link_seguimiento = "Tu orden ha sido enviada.  <br>" & "El pedido web N° " & txt_nro_pedido.Text & " ya ha sido entregado a nuestros despachadores, pronto estarás recibiéndolo en tu domicilio."
        End If


        message.Body = "Hola " & txt_nombre_cliente.Text & ", <br>" & vbNewLine &
        vbNewLine &
        link_seguimiento & " <br>" & vbNewLine &
        vbNewLine &
        "<br>Le saluda atentamente  <br> " & "<br>" & "ÁREA DE DESPACHO" & "<br>" & "ARANA Y CIA LIMITADA" & "<br>"
        message.Subject = "[REPUESTOS ARANA] Tu orden ha sido enviada - N° pedido: #" & txt_nro_pedido.Text
        message.Priority = MailPriority.Normal
        'message.Attachments.Add(adjunto)
        If seguridad_ssl = "SI" Then
            smtp.EnableSsl = True
        Else
            smtp.EnableSsl = False
        End If

        smtp.Port = puerto_smtp
        smtp.Host = servidor_smtp
        smtp.Credentials = New Net.NetworkCredential(email, clave_email)
        smtp.Send(message)



        SC.Connection = conexion
        SC.CommandText = "insert into pedidos_web (tipo_doc, nro_doc, nro_pedido, transporte, nro_seguimiento, cliente, nota, usuario_responsable, fecha_modificacion) values('" & (combo_tipo.Text) & "','" & (txt_nro_doc.Text) & "','" & (txt_nro_pedido.Text) & "','" & (Combo_transporte.Text) & "','" & (txt_nro_ot.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_nota.Text) & "','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        MsgBox("EL CORREO FUE ENVIADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        'Me.Close()
        limpiar()

        Me.Enabled = True
        lbl_correo.Visible = False

    End Sub

    Private Sub txt_nombre_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_cliente.KeyPress

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
            txt_correo.Focus()
        End If
    End Sub

    Private Sub txt_nro_cotizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_doc.KeyPress

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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_clientes()
            txt_nro_pedido.Focus()

        End If
    End Sub

    Private Sub txt_correo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_correo.KeyPress
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
            txt_correo_copia.Focus()
        End If
    End Sub

    Function ValidEmail(ByVal agEmail As String, Optional ByVal agMsge As Boolean = True) As Boolean
        Dim mSubCad As String
        Dim mCadInd As Integer
        Dim mCanChar As Integer
        Dim mCanDup As Integer
        Dim mCanPunt As Integer
        Dim mEmailOk As Boolean = False
        Dim mMaskChar As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVW XYZ0123456789-_.@"
        If agEmail.Length > 0 Then mEmailOk = True
        If mEmailOk Then
            mSubCad = agEmail.Substring(0, 1)
            If mSubCad = "." OrElse mSubCad = "@" Then mEmailOk = False
        End If
        If mEmailOk Then
            mSubCad = agEmail.Substring(agEmail.Length - 1, 1)
            If mSubCad = "." Or mSubCad = "@" Or mSubCad = "_" Or mSubCad = "-" Then mEmailOk = False
        End If
        If mEmailOk Then
            mCanChar = 0
            mCanDup = 0 'cantidad @. duplicados
            mCanPunt = 0 'cantidad de puntos despues de @
            For mCadInd = 0 To agEmail.Length - 1
                mSubCad = agEmail.Substring(mCadInd, 1)
                If mSubCad = "@" Then
                    mCanChar += 1
                    'primer punto despues de @
                    mCanPunt = agEmail.IndexOf(".", mCadInd)
                Else
                    If mMaskChar.IndexOf(mSubCad, 0) < 0 Then
                        'Caracter inválido, rompe bucle
                        mEmailOk = False
                        Exit For
                    End If
                End If
                If mCadInd < agEmail.Length - 1 And (mSubCad = "@" OrElse mSubCad = ".") Then
                    If agEmail.Substring(mCadInd + 1, 1) = "@" OrElse agEmail.Substring(mCadInd + 1, 1) = "." Then
                        mCanDup += 1
                    End If
                End If
            Next
            If mCanChar <> 1 Or mCanDup > 0 Or mCanPunt < 1 Then mEmailOk = False
        End If
        If agMsge AndAlso Not mEmailOk Then
            MessageBox.Show("DIRECCION DE CORREO ELECTRONICO INCORRECTA" &
            System.Environment.NewLine & "FORMATO: USUARIO@DOMINIO[.PAIS]", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '  txt_correo.Focus()
        Else
            'MessageBox.Show("Dirección de correo electrónico correcta !" & _
            'System.Environment.NewLine & "Formato: usuario@dominio[.país]", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return mEmailOk
    End Function

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub txt_dominio_correo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            txt_correo_copia.Focus()
        End If
    End Sub

    Private Sub txt_nota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nota.KeyPress
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
            btn_enviar.Focus()
        End If
    End Sub

    Private Sub txt_correo_copia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_correo_copia.KeyPress
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
            txt_nota.Focus()
        End If
    End Sub

    Private Sub txt_dominio_correo_copia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            txt_nota.Focus()
        End If
    End Sub

    Sub limpiar()
        combo_tipo.Text = "BOLETA"
        txt_nro_doc.Text = ""
        txt_nombre_cliente.Text = ""
        txt_correo.Text = ""
        txt_correo_copia.Text = ""
        Combo_transporte.Text = "CHILEXPRESS"
        txt_nro_ot.Text = ""
        txt_nota.Text = ""
        txt_nro_pedido.Text = ""
        txt_nro_doc.Focus()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub btn_arroba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_arroba.Click
        If correo_foco = "CORREO" Then
            txt_correo.Text = txt_correo.Text & "@"
            txt_correo.Focus()
            txt_correo.SelectionStart = txt_correo.TextLength
            txt_correo.Focus()
            Exit Sub
        End If

        If correo_foco = "CORREO COPIA" Then
            txt_correo_copia.Text = txt_correo_copia.Text & "@"
            txt_correo_copia.Focus()
            txt_correo_copia.SelectionStart = txt_correo_copia.TextLength
            txt_correo_copia.Focus()
            Exit Sub
        End If

        If correo_foco = "NUMERO" Then
            txt_nro_doc.Focus()
            Exit Sub
        End If

        If correo_foco = "NOMBRE" Then
            txt_nombre_cliente.Focus()
            Exit Sub
        End If

        If correo_foco = "NOTA" Then
            txt_nota.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_nro_ot_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nro_ot.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub combo_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_tipo.SelectedIndexChanged
        txt_nro_doc.Focus()
    End Sub

    Private Sub Combo_transporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_transporte.SelectedIndexChanged
        txt_nro_ot.Focus()
    End Sub

    Private Sub txt_nro_doc_TextChanged(sender As Object, e As EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub txt_nro_pedido_TextChanged(sender As Object, e As EventArgs) Handles txt_nro_pedido.TextChanged

    End Sub

    Private Sub txt_nro_pedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nro_pedido.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub mostrar_datos_clientes()
        txt_nombre_cliente.Text = ""
        txt_correo.Text = ""
        Dim Rut_cliente As String = ""

        If combo_tipo.Text = "BOLETA" Then
            conexion.Close()
            If txt_nro_doc.Text <> "" Then
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from boleta where n_boleta ='" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count = 1 Then
                    Rut_cliente = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                End If
            End If
        End If
        If combo_tipo.Text = "FACTURA" Then
            conexion.Close()
            If txt_nro_doc.Text <> "" Then
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from factura where n_factura ='" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count = 1 Then
                    Rut_cliente = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                End If
            End If
        End If

        conexion.Close()
        If txt_nro_doc.Text <> "" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (Rut_cliente) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_correo.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
            End If
        End If
    End Sub
End Class
