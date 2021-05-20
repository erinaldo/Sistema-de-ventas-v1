Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
'Imports System.Drawing.Printing
Imports System.IO
Imports System.Drawing.Drawing2D

'Imports System.Math


Public Class Form_enviar_correo_cotizacion_ventas
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean
    Dim message As New MailMessage
    Dim smtp As New SmtpClient

    Dim desglose_total_cotizacion As String
    Dim peso As String
    Dim correo_foco As String

    Dim email As String
    Dim clave_email As String
    Dim seguridad_ssl As String
    Dim puerto_smtp As String
    Dim servidor_smtp As String

    Private Sub Form_enviar_correo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Form_venta.WindowState = FormWindowState.Normal
        Form_venta.limpiar()
        Form_venta.controles(False, True)
        Form_venta.lbl_mensaje.Visible = False
        Form_venta.Enabled = True
        Form_venta.btn_nueva.Focus()

    End Sub

    Private Sub Form_enviar_correo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_enviar_correo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form_venta.Enabled = False
        cargar_logo()
        SetDefaultPrinter(impresora_guias)
        datos_usuario()

        'txt_nombre_pc.Text = My.Computer.Name

        'cargar_documento()

        correo_foco = ""


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
        txt_nombre_cliente.Focus()
    End Sub

    Sub mostrar_datos_correo()
        'Dim email As String
        'Dim clave_email As String
        'Dim seguridad_ssl As String
        'Dim puerto_smtp As String
        'Dim servidor_smtp As String

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

    Sub cargar_documento()

        grilla_estado_de_cuenta.Rows.Clear()


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from correos_meson"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)


        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("pc"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("correo"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("clave"))
            Next
        End If

    End Sub

    Sub comprobar_correo()

        If mirutempresa = "87686300-6" Then
            Dim nombre_pc As String
            Dim correo_pc As String
            Dim clave_pc As String

            txt_nombre_pc.Text = UCase(txt_nombre_pc.Text)

            For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

                nombre_pc = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
                correo_pc = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
                clave_pc = grilla_estado_de_cuenta.Rows(i).Cells(2).Value.ToString

                nombre_pc = UCase(nombre_pc)

                If txt_nombre_pc.Text = nombre_pc Then

                    micorreoempresa = correo_pc
                    miclavecorreoempresa = clave_pc
                    Exit Sub
                End If
            Next
        End If

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar.Click

        'Dim sRenglon As String = Nothing
        'Dim strStreamW As Stream = Nothing
        'Dim strStreamWriter As StreamWriter = Nothing
        'Dim ContenidoArchivo As String = Nothing
        '' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        'Dim PathArchivo As String

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO NOMBRE CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_cliente.Focus()
            Exit Sub
        End If

        If txt_nro_cotizacion.Text = "" Then
            MsgBox("CAMPO NRO DE COTIZACION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_cotizacion.Focus()
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

        conexion.Close()
        Consultas_SQL("select * from cotizacion where n_cotizacion = '" & (txt_nro_cotizacion.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count = 0 Then
            MsgBox("NUMERO DE COTIZACION NO EXISTE", 0 + 16, "ATENCION")
            Exit Sub
        End If

        lbl_correo.Visible = True
        Me.Enabled = False


        'comprobar_correo()


        conexion.Close()
        Consultas_SQL("select * from correos_electronicos where correo_electronico = '" & (txt_correo.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

        Else
            SC.Connection = conexion
            SC.CommandText = "INSERT INTO correos_electronicos (correo_electronico) VALUES ('" & (txt_correo.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If txt_correo_copia.Text <> "" Then
            conexion.Close()
            Consultas_SQL("select * from correos_electronicos where correo_electronico = '" & (txt_correo_copia.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

            Else
                SC.Connection = conexion
                SC.CommandText = "INSERT INTO correos_electronicos (correo_electronico) VALUES ('" & (txt_correo_copia.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        End If





        Dim nro_copia As Integer
        nro_copia = 0


        Dim nombre_archivo As String
        nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & ".pdf"

        If nro_copia <> "0" Then
            nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf"
        End If

        Dim exists As Boolean
        exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)


        exists = True

        If exists = True Then


            nro_copia = nro_copia + 1

            '  nombre_archivo = nombre_archivo & "_" & nro_copia

            nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf"

            exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)


            'While Directory.Exists("C:\Cotizaciones\" & nombre_archivo) = True

            'End While



            Dim index As Integer = 0
            Do While exists = True

                nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf"

                exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)

                If exists = False Then
                    Exit Do
                End If

                nro_copia = nro_copia + 1

            Loop






        End If













        'Me.Enabled = False
        grilla_documento.Rows.Clear()
        grilla_detalle_documento.Rows.Clear()

        mostrar_malla()
        mostrar_malla_detalle()

        Try
            Dim iReporte As New Form_informe_cotizacion_personalizado
            Dim rpt As New Crystal_cotizacion_personalizado

            rpt.Load()
            rpt.SetDataSource(ReturnDataSet)
            rpt.Refresh()

            iReporte.Reporte = rpt
            'iReporte.ShowDialog()


            If Directory.Exists("C:\Cotizaciones") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory("C:\Cotizaciones")
            End If




            'Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            ' CrDiskFileDestinationOptions.DiskFileName = "C:\Cotizaciones\" & "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf"
            CrDiskFileDestinationOptions.DiskFileName = "C:\Cotizaciones\" & nombre_archivo
            CrExportOptions = rpt.ExportOptions

            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            rpt.Export()

            'Catch ex As Exception
            '    MsgBox("LA COTIZACION NRO. " & txt_nro_cotizacion.Text & " AUN ESTA SIENDO ENVIADA", MsgBoxStyle.Critical, "INFORMACION")
            '    Me.Enabled = True
            '    lbl_correo.Visible = False
            '    Exit Sub
            'End Try

            mostrar_datos_cotizacion()


            If txt_fecha_cotizacion.Text = "" And txt_monto_cotizacion.Text = "" Then
                Me.Enabled = True
                lbl_correo.Visible = False
                Exit Sub
            End If

            Dim adjunto As System.Net.Mail.Attachment
            adjunto = Nothing
            ' adjunto = New System.Net.Mail.Attachment("C:\Cotizaciones\" & "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf")
            adjunto = New System.Net.Mail.Attachment("C:\Cotizaciones\" & nombre_archivo)
            message.From = New MailAddress(micorreoempresa)

            If txt_correo_copia.Text = "" Then
                message.To.Add(txt_correo.Text)
            Else
                message.To.Add(txt_correo.Text)

                message.To.Add(txt_correo_copia.Text)
            End If

            message.IsBodyHtml = True

            message.Body = vbNewLine & _
            "<table>" & vbNewLine & _
            "<tr>" & vbNewLine & _
            "<td width='55' align='left'>Señores</td>" & vbNewLine & _
            "<td>:</td>" & vbNewLine & _
            "<th> " & (txt_nombre_cliente.Text) & " </th>" & vbNewLine & _
            "</tr>" & vbNewLine & _
            "</table>" & vbNewLine & _
            "<br> </br>" & vbNewLine & _
            "Adjunto le enviamos la siguiente cotizacion:<br></br>" & vbNewLine & _
              "<br> </br>" & vbNewLine & _
            "<table>" & vbNewLine & _
            "<tr>" & vbNewLine & _
            "<td width='55'>Folio</td>" & vbNewLine & _
            "<td>:</td>" & vbNewLine & _
            "<td> " & (txt_nro_cotizacion.Text) & " </td>" & vbNewLine & _
            "</tr>" & vbNewLine & _
            "<tr>" & vbNewLine & _
            "<td width='55'>Fecha</td>" & vbNewLine & _
            "<td>:</td>" & vbNewLine & _
            "<td> " & (txt_fecha_cotizacion.Text) & " </td>" & vbNewLine & _
            "</tr>" & vbNewLine & _
            "<tr>" & vbNewLine & _
            "<td width='55'>Monto</td>" & vbNewLine & _
            "<td>:</td>" & vbNewLine & _
            "<td> " & (txt_monto_cotizacion.Text) & " </td>" & vbNewLine & _
            "</tr>" & vbNewLine & _
            "<tr>" & vbNewLine & _
            "<td></td>" & vbNewLine & _
            "<td></td>" & vbNewLine & _
            "<td></td>" & vbNewLine & _
            "</tr>" & vbNewLine & _
            "<tr>" & vbNewLine & _
            "<td>Nota</td>" & vbNewLine & _
            "<td>:</td>" & vbNewLine & _
            "<td> " & (txt_nota.Text) & " </td>" & vbNewLine & _
            "</tr>" & vbNewLine & _
            "</table>" & vbNewLine & _
            vbNewLine & _
            "<br/></br>Le saluda atentamente" & "<br></br/><br>" & txt_nombre_usuario.Text & "</br/>" & vbNewLine & "<br>" & txt_telefono_usuario.Text & "</br>" & vbNewLine & "<br>" & txt_area_usuario.Text & "</br>" & vbNewLine & "<br>" & minombreempresa & "</br>"

            message.Subject = "COTIZACION NRO. " & txt_nro_cotizacion.Text
            message.Priority = MailPriority.Normal
            message.Attachments.Add(adjunto)
            If seguridad_ssl = "SI" Then
                smtp.EnableSsl = True
            Else
                smtp.EnableSsl = False
            End If

            smtp.Port = puerto_smtp
            smtp.Host = servidor_smtp
            smtp.Credentials = New Net.NetworkCredential(email, clave_email)
            smtp.Send(message)
            Me.Enabled = True
            lbl_correo.Visible = False
            limpiar()
            ' MsgBox("EL CORREO FUE ENVIADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            Me.Close()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Enabled = True

    End Sub



    Sub mostrar_datos_cotizacion()
        conexion.Close()
        If txt_nro_cotizacion.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from cotizacion where n_cotizacion ='" & (txt_nro_cotizacion.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_fecha_cotizacion.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                txt_monto_cotizacion.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                conexion.Close()


                Dim MONTO As String
                MONTO = txt_monto_cotizacion.Text
                txt_monto_cotizacion.Text = Format(Int(MONTO), "###,###,###")






                Exit Sub
            Else
                MsgBox("NRO. DE COTIZACION NO ENCONTRADO", 0 + 16, "ERROR")
                conexion.Close()
            End If
        End If
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

    Private Sub txt_nombre_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.TextChanged

    End Sub

    Private Sub txt_nro_cotizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_cotizacion.KeyPress
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
            txt_nombre_cliente.Focus()
        End If
    End Sub

    Private Sub txt_nro_cotizacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_cotizacion.TextChanged

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

    Private Sub txt_correo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_correo.TextChanged

    End Sub

    'Private Sub txt_correo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_correo.Validated
    '    ValidEmail(txt_correo.Text)
    'End Sub

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
            MessageBox.Show("DIRECCION DE CORREO ELECTRONICO INCORRECTA" & _
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

    Private Sub txt_nro_cotizacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_cotizacion.GotFocus
        txt_nro_cotizacion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_cotizacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_cotizacion.LostFocus
        txt_nro_cotizacion.BackColor = Color.White
    End Sub

    Private Sub txt_nombre_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.GotFocus
        txt_nombre_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nombre_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.LostFocus
        txt_nombre_cliente.BackColor = Color.White
        correo_foco = "NOMBRE"
    End Sub

    Private Sub txt_correo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_correo.GotFocus
        txt_correo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_correo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_correo.LostFocus
        txt_correo.BackColor = Color.White
        correo_foco = "CORREO"
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

    'Private Sub txt_dominio_correo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_dominio_correo.BackColor = Color.White
    'End Sub

    Private Sub btn_enviar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_enviar.GotFocus
        btn_enviar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_enviar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_enviar.LostFocus
        btn_enviar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_dominio_correo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    'End Sub

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

    Private Sub txt_nota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nota.TextChanged

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

    Private Sub txt_dominio_correo_copia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub txt_correo_copia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_correo_copia.TextChanged

    End Sub


    Private Sub txt_correo_copia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_correo_copia.GotFocus
        txt_correo_copia.BackColor = Color.LightSkyBlue
    End Sub



    Private Sub txt_correo_copia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_correo_copia.LostFocus
        txt_correo_copia.BackColor = Color.White
        correo_foco = "CORREO COPIA"
    End Sub

    'Private Sub txt_dominio_correo_copia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_dominio_correo_copia.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_dominio_correo_copia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_dominio_correo_copia.BackColor = Color.White
    'End Sub

    Private Sub txt_nota_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nota.GotFocus
        txt_nota.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nota_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nota.LostFocus
        txt_nota.BackColor = Color.White
        correo_foco = "NOTA"
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Sub limpiar()
        txt_correo.Text = ""
        txt_correo_copia.Text = ""
        'txt_dominio_correo.Text = ""
        'txt_dominio_correo_copia.Text = ""
        txt_nombre_cliente.Text = ""
        txt_nota.Text = ""
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub






    Private Function ReturnDataSet() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet


        dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("ciudad_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("movil_vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("nro_cotizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("forma_de_pago", GetType(String)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))


        dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
        dt.Columns.Add(New DataColumn("precio", GetType(Integer)))
        dt.Columns.Add(New DataColumn("subtotal_detalle", GetType(Integer)))
        dt.Columns.Add(New DataColumn("porcentaje_desc", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descuento_detalle", GetType(Integer)))
        dt.Columns.Add(New DataColumn("neto_detalle", GetType(Integer)))
        dt.Columns.Add(New DataColumn("iva_detalle", GetType(Integer)))
        dt.Columns.Add(New DataColumn("total_detalle", GetType(Integer)))
        dt.Columns.Add(New DataColumn("desglose_palabras", GetType(String)))
        dt.Columns.Add(New DataColumn("subtotal", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descuento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("neto", GetType(Integer)))
        dt.Columns.Add(New DataColumn("iva", GetType(Integer)))
        dt.Columns.Add(New DataColumn("total", GetType(Integer)))

        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))









        Dim nombre_cliente As String
        Dim rut_cliente As String
        Dim direccion_cliente As String
        Dim comuna_cliente As String
        Dim vendedor As String
        Dim movil_vendedor As String
        Dim nro_cotizacion As String
        Dim forma_de_pago As String
        Dim codigo As String
        Dim nombre As String
        Dim cantidad As String
        Dim precio As String
        Dim subtotal_detalle As String
        Dim porcentaje_desc As String
        Dim descuento_detalle As String
        Dim neto_detalle As String
        Dim iva_detalle As String
        Dim total_detalle As String
        Dim subtotal As String
        Dim descuento As String
        Dim neto As String
        Dim iva As String
        Dim total As String

        nombre_cliente = grilla_documento.CurrentRow.Cells(1).Value
        rut_cliente = grilla_documento.CurrentRow.Cells(0).Value
        direccion_cliente = grilla_documento.CurrentRow.Cells(2).Value
        comuna_cliente = grilla_documento.CurrentRow.Cells(3).Value
        vendedor = grilla_documento.CurrentRow.Cells(4).Value
        movil_vendedor = grilla_documento.CurrentRow.Cells(5).Value
        forma_de_pago = grilla_documento.CurrentRow.Cells(7).Value
        nro_cotizacion = grilla_documento.CurrentRow.Cells(6).Value
        subtotal = grilla_documento.CurrentRow.Cells(8).Value
        descuento = grilla_documento.CurrentRow.Cells(9).Value
        neto = grilla_documento.CurrentRow.Cells(10).Value
        iva = grilla_documento.CurrentRow.Cells(11).Value
        total = grilla_documento.CurrentRow.Cells(12).Value


        For i = 0 To grilla_detalle_documento.Rows.Count - 1


            codigo = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
            nombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
            cantidad = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
            precio = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
            subtotal_detalle = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
            porcentaje_desc = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
            descuento_detalle = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
            neto_detalle = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
            iva_detalle = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
            total_detalle = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString


            dr = dt.NewRow()

            Try
                dr("Imagen") = Imagen_reporte
            Catch
            End Try
            'dr("nombre_empresa") = minombreempresa
            dr("nombre_cliente") = nombre_cliente
            dr("rut_cliente") = rut_cliente
            dr("direccion_cliente") = direccion_cliente
            dr("comuna_cliente") = comuna_cliente
            dr("vendedor") = vendedor
            dr("movil_vendedor") = movil_vendedor
            dr("nro_cotizacion") = nro_cotizacion
            dr("forma_de_pago") = forma_de_pago
            '  dr("forma_de_pago") = forma_de_pago

            dr("codigo") = codigo
            dr("nombre") = nombre
            dr("cantidad") = cantidad
            dr("precio") = precio
            dr("subtotal_detalle") = subtotal_detalle
            dr("porcentaje_desc") = porcentaje_desc
            dr("descuento_detalle") = descuento_detalle
            dr("neto_detalle") = neto_detalle
            dr("iva_detalle") = iva_detalle
            dr("total_detalle") = total_detalle
            dr("desglose_palabras") = desglose_total_cotizacion
            dr("subtotal") = subtotal
            dr("descuento") = descuento
            dr("neto") = neto
            dr("iva") = iva
            dr("total") = total

            dr("nombre_empresa") = minombreempresa
            dr("giro_empresa") = migiroempresa
            dr("direccion_empresa") = midireccionempresa
            dr("comuna_empresa") = micomunaempresa
            dr("telefono_empresa") = mitelefonoempresa
            dr("correo_empresa") = micorreoempresa
            dr("rut_empresa") = mirutempresa
            dt.Rows.Add(dr)




        Next





        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "Cotizacion"

        Dim iDS As New dsCotizacion

        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS
    End Function



    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function


    Sub mostrar_malla()


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from cotizacion, usuarios, clientes where n_cotizacion= '" & (txt_nro_cotizacion.Text) & "' and cotizacion.usuario_responsable=usuarios.rut_usuario and cotizacion.rut_cliente=clientes.rut_cliente"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_documento.Rows.Clear()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                'Dim fecha_guia As String
                'fecha_guia = DS.Tables(DT.TableName).Rows(i).Item("n_cotizacion")
                grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("n_cotizacion"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("subtotal"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("total"))
            Next




            Dim total As String

            total = grilla_documento.CurrentRow.Cells(12).Value

            peso = " PESOS"
            If CInt(total) = 1000000 Then
                desglose_total_cotizacion = Num2Text(total) & " DE PESOS"
            ElseIf CInt(total) = 2000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 3000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 4000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 5000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 6000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 7000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 8000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 9000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 10000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 11000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 12000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 13000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 14000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 15000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 16000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 17000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 18000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 19000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 20000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 21000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 22000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 23000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 24000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 25000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 26000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 27000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 28000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 29000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            ElseIf CInt(total) = 30000000 Then
                desglose_total_cotizacion = Num2Text(total) & "DE PESOS"
            Else
                desglose_total_cotizacion = Num2Text(total) & peso
            End If

        End If
    End Sub

    Sub mostrar_malla_detalle()


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_cotizacion  where n_cotizacion= '" & (txt_nro_cotizacion.Text) & "'"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_detalle_documento.Rows.Clear()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                'Dim fecha_guia As String
                'fecha_guia = DS.Tables(DT.TableName).Rows(i).Item("n_cotizacion")
                grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre") & " " & DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
            Next
        End If
    End Sub

    Public Function ImageToByte(ByVal pImagen As Image) As Byte()
        Dim mImage() As Byte
        Try
            If Not IsNothing(pImagen) Then
                Dim ms As New System.IO.MemoryStream
                pImagen.Save(ms, pImagen.RawFormat)
                mImage = ms.GetBuffer
                ms.Close()
                Return mImage
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



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
            txt_nro_cotizacion.Focus()
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

    Private Sub btn_arroba_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_arroba.GotFocus
        btn_arroba.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_arroba_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_arroba.LostFocus
        btn_arroba.BackColor = Color.Transparent
        correo_foco = ""
    End Sub

    Sub datos_usuario()

        conexion.Close()
        If Form_venta.txt_rut_vendedor.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where rut_usuario ='" & (Form_venta.txt_rut_vendedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_usuario.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
                txt_telefono_usuario.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_usuario")
                txt_area_usuario.Text = DS.Tables(DT.TableName).Rows(0).Item("area_usuario")
            End If

            conexion.Close()
        End If
    End Sub


End Class