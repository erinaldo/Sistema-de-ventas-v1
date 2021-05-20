Imports System.Net.Mail
Imports System.Drawing.Drawing2D
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Form_enviar_correo_cotizacion
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

    Private Sub Form_enviar_correo_cotizacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_enviar_correo_cotizacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    Private Sub Form_enviar_correo_cotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        correo_foco = ""

        SetDefaultPrinter(impresora_guias)

        'txt_nombre_pc.Text = My.Computer.Name
        'cargar_documento()

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

        txt_nro_cotizacion.Focus()
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

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
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
                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("pc"),
                                                                DS.Tables(DT.TableName).Rows(i).Item("correo"),
                                                                 DS.Tables(DT.TableName).Rows(i).Item("clave"))
            Next
        End If
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar.Click
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

        'Dim nro_copia As Integer
        'nro_copia = 0

        'Dim nombre_archivo As String
        'nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & ".pdf"

        'If nro_copia <> "0" Then
        '    nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf"
        'End If

        'Dim exists As Boolean
        'exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)

        'If exists = True Then
        '    nro_copia = nro_copia + 1

        '    nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf"

        '    exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)

        '    Dim index As Integer = 0
        '    Do While exists = True
        '        nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf"
        '        exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)

        '        If exists = False Then
        '            Exit Do
        '        End If

        '        nro_copia = nro_copia + 1
        '    Loop
        'End If

        grilla_documento.Rows.Clear()
        grilla_detalle_documento.Rows.Clear()

        mostrar_malla()
        mostrar_malla_detalle()
        crear_pdf()

        '    Dim iReporte As New Form_informe_cotizacion_personalizado
        '    Dim rpt As New Crystal_cotizacion_personalizado
        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()
        '    iReporte.Reporte = rpt
        '    If Directory.Exists("C:\Cotizaciones") = False Then ' si no existe la carpeta se crea
        '        Directory.CreateDirectory("C:\Cotizaciones")
        '    End If
        '    Dim CrExportOptions As ExportOptions
        '    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        '    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        '    CrDiskFileDestinationOptions.DiskFileName = "C:\Cotizaciones\" & nombre_archivo
        '    CrExportOptions = rpt.ExportOptions
        '    With CrExportOptions
        '        .ExportDestinationType = ExportDestinationType.DiskFile
        '        .ExportFormatType = ExportFormatType.PortableDocFormat
        '        .DestinationOptions = CrDiskFileDestinationOptions
        '        .FormatOptions = CrFormatTypeOptions
        '    End With
        '    rpt.Export()

        'Try

        mostrar_datos_cotizacion()

            If txt_fecha_cotizacion.Text = "" And txt_monto_cotizacion.Text = "" Then
                Me.Enabled = True
                lbl_correo.Visible = False
                Exit Sub
            End If

            Dim adjunto As System.Net.Mail.Attachment
            adjunto = Nothing
            adjunto = New System.Net.Mail.Attachment("C:\Cotizaciones\" & nombre_archivo)
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

            message.Body = vbNewLine &
            "<table>" & vbNewLine &
            "<tr>" & vbNewLine &
            "<td width='55' align='left'>Señores</td>" & vbNewLine &
            "<td>:</td>" & vbNewLine &
            "<th> " & (txt_nombre_cliente.Text) & " </th>" & vbNewLine &
            "</tr>" & vbNewLine &
            "</table>" & vbNewLine &
            "<br> </br>" & vbNewLine &
            "Adjunto le enviamos la siguiente cotizacion:<br></br>" & vbNewLine &
              "<br> </br>" & vbNewLine &
            "<table>" & vbNewLine &
            "<tr>" & vbNewLine &
            "<td width='55'>Folio</td>" & vbNewLine &
            "<td>:</td>" & vbNewLine &
            "<td> " & (txt_nro_cotizacion.Text) & " </td>" & vbNewLine &
            "</tr>" & vbNewLine &
            "<tr>" & vbNewLine &
            "<td width='55'>Fecha</td>" & vbNewLine &
            "<td>:</td>" & vbNewLine &
            "<td> " & (txt_fecha_cotizacion.Text) & " </td>" & vbNewLine &
            "</tr>" & vbNewLine &
            "<tr>" & vbNewLine &
            "<td width='55'>Monto</td>" & vbNewLine &
            "<td>:</td>" & vbNewLine &
            "<td> " & (txt_monto_cotizacion.Text) & " </td>" & vbNewLine &
            "</tr>" & vbNewLine &
            "<tr>" & vbNewLine &
            "<td></td>" & vbNewLine &
            "<td></td>" & vbNewLine &
            "<td></td>" & vbNewLine &
            "</tr>" & vbNewLine &
            "<tr>" & vbNewLine &
            "<td>Nota</td>" & vbNewLine &
            "<td>:</td>" & vbNewLine &
            "<td> " & (txt_nota.Text) & " </td>" & vbNewLine &
            "</tr>" & vbNewLine &
            "</table>" & vbNewLine &
            vbNewLine &
            "<br/></br>Le saluda atentamente" & "<br></br/><br>" & minombre & "</br/>" & vbNewLine & "<br>" & mitelefono & "</br>" & vbNewLine & "<br>" & miarea & "</br>" & vbNewLine & "<br>" & minombreempresa & "</br>"

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



        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        Me.Enabled = True

        '' '' ''Dim sRenglon As String = Nothing
        '' '' ''Dim strStreamW As Stream = Nothing
        '' '' ''Dim strStreamWriter As StreamWriter = Nothing
        '' '' ''Dim ContenidoArchivo As String = Nothing
        ' '' '' '' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        '' '' ''Dim PathArchivo As String

        ' '' ''If txt_nombre_cliente.Text = "" Then
        ' '' ''    MsgBox("CAMPO NOMBRE CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        ' '' ''    txt_nombre_cliente.Focus()
        ' '' ''    Exit Sub
        ' '' ''End If

        ' '' ''If txt_nro_cotizacion.Text = "" Then
        ' '' ''    MsgBox("CAMPO NRO DE COTIZACION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        ' '' ''    txt_nro_cotizacion.Focus()
        ' '' ''    Exit Sub
        ' '' ''End If

        ' '' ''If txt_correo.Text = "" Then
        ' '' ''    MsgBox("CAMPO CORREO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        ' '' ''    txt_correo.Focus()
        ' '' ''    Exit Sub
        ' '' ''End If


        ' '' ''If ValidEmail(txt_correo.Text & "@" & txt_dominio_correo.Text) = False Then
        ' '' ''    txt_correo.Focus()
        ' '' ''    txt_correo.SelectAll()
        ' '' ''    Exit Sub
        ' '' ''End If

        ' '' ''If txt_correo_copia.Text <> "" Then
        ' '' ''    If ValidEmail(txt_correo_copia.Text & "@" & txt_dominio_correo_copia.Text) = False Then
        ' '' ''        txt_correo_copia.Focus()
        ' '' ''        txt_correo_copia.SelectAll()
        ' '' ''        Exit Sub
        ' '' ''    End If
        ' '' ''End If

        ' '' ''conexion.Close()
        ' '' ''Consultas_SQL("select * from cotizacion where n_cotizacion = '" & (txt_nro_cotizacion.Text) & "'")
        ' '' ''If DS.Tables(DT.TableName).Rows.Count = 0 Then
        ' '' ''    MsgBox("NUMERO DE COTIZACION NO EXISTE", 0 + 16, "ATENCION")
        ' '' ''    Exit Sub
        ' '' ''End If


        ' '' ''lbl_correo.Visible = True
        ' '' ''Me.Enabled = False



        '' '' ''conexion.Close()
        '' '' ''DS.Tables.Clear()
        '' '' ''DT.Rows.Clear()
        '' '' ''DT.Columns.Clear()

        '' '' ''DS.Clear()
        '' '' ''conexion.Open()
        '' '' ''SC.Connection = conexion

        '' '' ''SC.CommandText = "select  empresa.rut_empresa, empresa.correo_empresa, empresa.nombre_empresa, empresa.direccion_empresa, empresa.telefono_empresa, empresa.giro_empresa, empresa.comuna_empresa, empresa.recinto_empresa, clientes.nombre_cliente, clientes.direccion_cliente, clientes.rut_cliente, clientes.comuna_cliente, cotizacion.condiciones, cotizacion.usuario_responsable, cotizacion.fecha_venta, cotizacion.descuento,cotizacion.neto, cotizacion.iva,  cotizacion.subtotal, cotizacion.total, cotizacion.desglose, cotizacion.n_cotizacion,  usuarios.telefono_usuario, usuarios.nombre_usuario, detalle_cotizacion.cod_producto, detalle_cotizacion.detalle_nombre, detalle_cotizacion.numero_tecnico, detalle_cotizacion.valor_unitario, detalle_cotizacion.cantidad,  detalle_cotizacion.porcentaje_desc, detalle_cotizacion.detalle_subtotal,detalle_cotizacion.detalle_descuento, detalle_cotizacion.detalle_total from clientes, empresa, cotizacion, usuarios, detalle_cotizacion where clientes.cod_cliente=cotizacion.codigo_cliente and cotizacion.usuario_responsable=usuarios.rut_usuario and cotizacion.n_cotizacion=detalle_cotizacion.n_cotizacion and cotizacion.n_cotizacion='" & (txt_nro_cotizacion.Text) & "'"

        '' '' ''DA.SelectCommand = SC
        '' '' ''DA.Fill(DT)
        '' '' ''DS.Tables.Add(DT)
        '' '' ''conexion.Close()

        '' '' ''Dim rpt As New Crystal_cotizacion

        '' '' ''rpt.SetDataSource(DS.Tables(DT.TableName))
        '' '' ''Form_informe_cotizacion.rpt_cotizacion.ReportSource = rpt


        '' '' ''conexion.Close()

        ' '' ''Dim nro_copia As Integer
        ' '' ''nro_copia = 1

        ' '' ''While Directory.Exists("C:\Cotizaciones\" & "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf") = True

        ' '' ''    nro_copia = nro_copia + 1

        ' '' ''End While



        '' '' '' Me.Enabled = False
        ' '' ''grilla_documento.Rows.Clear()
        ' '' ''grilla_detalle_documento.Rows.Clear()

        ' '' ''mostrar_malla()
        ' '' ''mostrar_malla_detalle()

        ' '' ''Try
        ' '' ''    Dim iReporte As New Form_informe_cotizacion_personalizado
        ' '' ''    Dim rpt As New Crystal_cotizacion_personalizado

        ' '' ''    rpt.Load()
        ' '' ''    rpt.SetDataSource(ReturnDataSet)
        ' '' ''    rpt.Refresh()

        ' '' ''    iReporte.Reporte = rpt
        ' '' ''    'iReporte.ShowDialog()











        ' '' ''    If Directory.Exists("C:\Cotizaciones") = False Then ' si no existe la carpeta se crea
        ' '' ''        Directory.CreateDirectory("C:\Cotizaciones")
        ' '' ''    End If




        ' '' ''    Try
        ' '' ''        Dim CrExportOptions As ExportOptions
        ' '' ''        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        ' '' ''        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        ' '' ''        ' CrDiskFileDestinationOptions.DiskFileName = ""
        ' '' ''        CrDiskFileDestinationOptions.DiskFileName = "C:\Cotizaciones\" & "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf"
        ' '' ''        CrExportOptions = rpt.ExportOptions

        ' '' ''        With CrExportOptions
        ' '' ''            .ExportDestinationType = ExportDestinationType.DiskFile
        ' '' ''            .ExportFormatType = ExportFormatType.PortableDocFormat
        ' '' ''            .DestinationOptions = CrDiskFileDestinationOptions
        ' '' ''            .FormatOptions = CrFormatTypeOptions
        ' '' ''        End With

        ' '' ''        rpt.Export()

        ' '' ''    Catch ex As Exception
        ' '' ''        MsgBox("LA COTIZACION NRO. " & txt_nro_cotizacion.Text & " AUN ESTA SIENDO ENVIADA", MsgBoxStyle.Critical, "INFORMACION")
        ' '' ''        Me.Enabled = True
        ' '' ''        lbl_correo.Visible = False
        ' '' ''        Exit Sub
        ' '' ''    End Try

        ' '' ''    mostrar_datos_cotizacion()


        ' '' ''    If txt_fecha_cotizacion.Text = "" And txt_monto_cotizacion.Text = "" Then
        ' '' ''        Me.Enabled = True
        ' '' ''        lbl_correo.Visible = False
        ' '' ''        Exit Sub
        ' '' ''    End If

        ' '' ''    Dim adjunto As System.Net.Mail.Attachment
        ' '' ''    adjunto = Nothing
        ' '' ''    adjunto = New System.Net.Mail.Attachment("C:\Cotizaciones\" & "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf")
        ' '' ''    message.From = New MailAddress(micorreoempresa)

        ' '' ''    If txt_correo_copia.Text = "" Then
        ' '' ''        message.To.Add(txt_correo.Text & "@" & txt_dominio_correo.Text)
        ' '' ''    Else
        ' '' ''        message.To.Add(txt_correo.Text & "@" & txt_dominio_correo.Text)

        ' '' ''        message.To.Add(txt_correo_copia.Text & "@" & txt_dominio_correo_copia.Text)
        ' '' ''    End If
        ' '' ''    message.IsBodyHtml = True

        ' '' ''    message.Body = vbNewLine & _
        ' '' ''    "<table>" & vbNewLine & _
        ' '' ''    "<tr>" & vbNewLine & _
        ' '' ''    "<td width='55' align='left'>Señores</td>" & vbNewLine & _
        ' '' ''    "<td>:</td>" & vbNewLine & _
        ' '' ''    "<th> " & (txt_nombre_cliente.Text) & " </th>" & vbNewLine & _
        ' '' ''    "</tr>" & vbNewLine & _
        ' '' ''    "</table>" & vbNewLine & _
        ' '' ''    "<br> </br>" & vbNewLine & _
        ' '' ''    "Adjunto le enviamos la siguiente cotizacion:<br></br>" & vbNewLine & _
        ' '' ''      "<br> </br>" & vbNewLine & _
        ' '' ''    "<table>" & vbNewLine & _
        ' '' ''    "<tr>" & vbNewLine & _
        ' '' ''    "<td width='55'>Folio</td>" & vbNewLine & _
        ' '' ''    "<td>:</td>" & vbNewLine & _
        ' '' ''    "<td> " & (txt_nro_cotizacion.Text) & " </td>" & vbNewLine & _
        ' '' ''    "</tr>" & vbNewLine & _
        ' '' ''    "<tr>" & vbNewLine & _
        ' '' ''    "<td width='55'>Fecha</td>" & vbNewLine & _
        ' '' ''    "<td>:</td>" & vbNewLine & _
        ' '' ''    "<td> " & (txt_fecha_cotizacion.Text) & " </td>" & vbNewLine & _
        ' '' ''    "</tr>" & vbNewLine & _
        ' '' ''    "<tr>" & vbNewLine & _
        ' '' ''    "<td width='55'>Monto</td>" & vbNewLine & _
        ' '' ''    "<td>:</td>" & vbNewLine & _
        ' '' ''    "<td> " & (txt_monto_cotizacion.Text) & " </td>" & vbNewLine & _
        ' '' ''    "</tr>" & vbNewLine & _
        ' '' ''    "<tr>" & vbNewLine & _
        ' '' ''    "<td></td>" & vbNewLine & _
        ' '' ''    "<td></td>" & vbNewLine & _
        ' '' ''    "<td></td>" & vbNewLine & _
        ' '' ''    "</tr>" & vbNewLine & _
        ' '' ''    "<tr>" & vbNewLine & _
        ' '' ''    "<td>Nota</td>" & vbNewLine & _
        ' '' ''    "<td>:</td>" & vbNewLine & _
        ' '' ''    "<td> " & (txt_nota.Text) & " </td>" & vbNewLine & _
        ' '' ''    "</tr>" & vbNewLine & _
        ' '' ''    "</table>" & vbNewLine & _
        ' '' ''    vbNewLine & _
        ' '' ''    "<br/></br>Le saluda atentamente" & "<br></br/><br>" & minombre & "</br/>" & vbNewLine & "<br>" & mitelefono & "</br>" & vbNewLine & "<br>" & miarea & "</br>" & vbNewLine & "<br>" & minombreempresa & "</br>"


        ' '' ''    message.Subject = "COTIZACION NRO. " & txt_nro_cotizacion.Text
        ' '' ''    message.Priority = MailPriority.Normal

        ' '' ''    message.Attachments.Add(adjunto)











        ' '' ''    smtp.EnableSsl = True
        ' '' ''    smtp.Port = "587"
        ' '' ''    smtp.Host = "smtp.gmail.com"
        ' '' ''    smtp.Credentials = New Net.NetworkCredential(micorreoempresa, miclavecorreoempresa)
        ' '' ''    smtp.Send(message)
        ' '' ''    Me.Enabled = True
        ' '' ''    lbl_correo.Visible = False
        ' '' ''    limpiar()

        ' '' ''    Me.Close()



        ' '' ''    adjunto = Nothing

        ' '' ''Catch ex As Exception
        ' '' ''    MsgBox(ex.Message)
        ' '' ''End Try
        ' '' ''Me.Enabled = True






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
        correo_foco = "NUMERO"
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

    'Private Sub txt_dominio_correo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_dominio_correo.BackColor = Color.LightSkyBlue
    'End Sub

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
        correo_foco = ""
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
        correo_foco = ""
    End Sub

    Private Sub btn_arroba_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_arroba.GotFocus
        btn_arroba.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_arroba_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_arroba.LostFocus
        btn_arroba.BackColor = Color.Transparent
        correo_foco = ""
    End Sub

    Private Sub txt_dominio_correo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub txt_correo_copia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_correo_copia.GotFocus
        txt_correo_copia.BackColor = Color.LightSkyBlue
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
        correo_foco = ""
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





    Private Sub txt_correo_copia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_correo_copia.TextChanged

    End Sub

    Private Sub txt_dominio_correo_copia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_nota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nota.TextChanged

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
        'Dim dt As New DataTable
        'Dim dr As DataRow
        'Dim ds As New DataSet

        'dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        'dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("direccion_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("comuna_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("ciudad_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("vendedor", GetType(String)))
        'dt.Columns.Add(New DataColumn("movil_vendedor", GetType(String)))
        'dt.Columns.Add(New DataColumn("nro_cotizacion", GetType(String)))
        'dt.Columns.Add(New DataColumn("forma_de_pago", GetType(String)))
        'dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        'dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        'dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("precio", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("subtotal_detalle", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("porcentaje_desc", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("descuento_detalle", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("neto_detalle", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("iva_detalle", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("total_detalle", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("desglose_palabras", GetType(String)))
        'dt.Columns.Add(New DataColumn("subtotal", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("descuento", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("neto", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("iva", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("total", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

        'Dim nombre_cliente As String
        'Dim rut_cliente As String
        'Dim direccion_cliente As String
        'Dim comuna_cliente As String
        'Dim vendedor As String
        'Dim movil_vendedor As String
        'Dim nro_cotizacion As String
        'Dim forma_de_pago As String
        'Dim codigo As String
        'Dim nombre As String
        'Dim cantidad As String
        'Dim precio As String
        'Dim subtotal_detalle As String
        'Dim porcentaje_desc As String
        'Dim descuento_detalle As String
        'Dim neto_detalle As String
        'Dim iva_detalle As String
        'Dim total_detalle As String
        'Dim subtotal As String
        'Dim descuento As String
        'Dim neto As String
        'Dim iva As String
        'Dim total As String

        'nombre_cliente = grilla_documento.CurrentRow.Cells(1).Value
        'rut_cliente = grilla_documento.CurrentRow.Cells(0).Value
        'direccion_cliente = grilla_documento.CurrentRow.Cells(2).Value
        'comuna_cliente = grilla_documento.CurrentRow.Cells(3).Value
        'vendedor = grilla_documento.CurrentRow.Cells(4).Value
        'movil_vendedor = grilla_documento.CurrentRow.Cells(5).Value
        'forma_de_pago = grilla_documento.CurrentRow.Cells(7).Value
        'nro_cotizacion = grilla_documento.CurrentRow.Cells(6).Value
        'subtotal = grilla_documento.CurrentRow.Cells(8).Value
        'descuento = grilla_documento.CurrentRow.Cells(9).Value
        'neto = grilla_documento.CurrentRow.Cells(10).Value
        'iva = grilla_documento.CurrentRow.Cells(11).Value
        'total = grilla_documento.CurrentRow.Cells(12).Value

        'For i = 0 To grilla_detalle_documento.Rows.Count - 1
        '    codigo = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
        '    nombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
        '    cantidad = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '    precio = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
        '    subtotal_detalle = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '    porcentaje_desc = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '    descuento_detalle = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
        '    neto_detalle = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
        '    iva_detalle = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
        '    total_detalle = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString

        '    dr = dt.NewRow()

        '    Try
        '        dr("Imagen") = ImageToByte(Image.FromFile("C:\Sistema de ventas\Sucursales\" & SucursalSeleccionada & "\Logo de empresa\logo_crystal.jpg"))
        '        ' dr("Imagen") = ImageToByte(Image.FromFile(ruta_logo_empresa_reportes))
        '    Catch
        '    End Try
        '    'dr("nombre_empresa") = minombreempresa
        '    dr("nombre_cliente") = nombre_cliente
        '    dr("rut_cliente") = rut_cliente
        '    dr("direccion_cliente") = direccion_cliente
        '    dr("comuna_cliente") = comuna_cliente
        '    dr("vendedor") = vendedor
        '    dr("movil_vendedor") = movil_vendedor
        '    dr("nro_cotizacion") = nro_cotizacion
        '    dr("forma_de_pago") = forma_de_pago
        '    '  dr("forma_de_pago") = forma_de_pago
        '    dr("codigo") = codigo
        '    dr("nombre") = nombre
        '    dr("cantidad") = cantidad
        '    dr("precio") = precio
        '    dr("subtotal_detalle") = subtotal_detalle
        '    dr("porcentaje_desc") = porcentaje_desc
        '    dr("descuento_detalle") = descuento_detalle
        '    dr("neto_detalle") = neto_detalle
        '    dr("iva_detalle") = iva_detalle
        '    dr("total_detalle") = total_detalle
        '    dr("desglose_palabras") = desglose_total_cotizacion
        '    dr("subtotal") = subtotal
        '    dr("descuento") = descuento
        '    dr("neto") = neto
        '    dr("iva") = iva
        '    dr("total") = total
        '    dr("nombre_empresa") = minombreempresa
        '    dr("giro_empresa") = migiroempresa
        '    dr("direccion_empresa") = midireccionempresa
        '    dr("comuna_empresa") = micomunaempresa
        '    dr("telefono_empresa") = mitelefonoempresa
        '    dr("correo_empresa") = micorreoempresa
        '    dr("rut_empresa") = mirutempresa
        '    dt.Rows.Add(dr)
        'Next

        'ds.Tables.Add(dt)
        'ds.Tables(0).TableName = "Cotizacion"

        'Dim iDS As New dsCotizacion

        'iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        'Return iDS
        Return Nothing
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
        SC.CommandText = "select  n_cotizacion as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', cotizacion.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', comuna_cliente as 'COMUNA CLIENTE', direccion_cliente as 'DIRECCION CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR', telefono_usuario as 'TELEFONO VENDEDOR' , fecha_venta as 'FECHA' from cotizacion, usuarios, clientes  where n_cotizacion= '" & (txt_nro_cotizacion.Text) & "' and cotizacion.usuario_responsable=usuarios.rut_usuario and cotizacion.rut_cliente=clientes.rut_cliente"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_documento.Rows.Clear()
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT CLIENTE"),
                           DS.Tables(DT.TableName).Rows(i).Item("CLIENTE"),
                            DS.Tables(DT.TableName).Rows(i).Item("DIRECCION CLIENTE"),
                             DS.Tables(DT.TableName).Rows(i).Item("COMUNA CLIENTE"),
                              DS.Tables(DT.TableName).Rows(i).Item("VENDEDOR"),
                               DS.Tables(DT.TableName).Rows(i).Item("TELEFONO VENDEDOR"),
                                DS.Tables(DT.TableName).Rows(i).Item("NRO."),
                                 DS.Tables(DT.TableName).Rows(i).Item("CONDIC."),
                                  DS.Tables(DT.TableName).Rows(i).Item("SUBTOTAL"),
                                   DS.Tables(DT.TableName).Rows(i).Item("DESC."),
                                    DS.Tables(DT.TableName).Rows(i).Item("NETO"),
                                     DS.Tables(DT.TableName).Rows(i).Item("IVA"),
                                      DS.Tables(DT.TableName).Rows(i).Item("TOTAL"),
                                       DS.Tables(DT.TableName).Rows(i).Item("%"),
                                        DS.Tables(DT.TableName).Rows(i).Item("FECHA"))
            Next
        End If

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
    End Sub

    Sub mostrar_malla_detalle()

        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarTotal As Integer
        Dim VarPrecioReal As Integer
        Dim iva_valor As String

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_cotizacion where detalle_cotizacion.n_cotizacion='" & (txt_nro_cotizacion.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
                VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                VarValorUnitario = Val(VarTotal / VarCantidad)

                If VarCodProducto <> "*" Then
                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                    End If
                    conexion.Close()
                Else
                    VarPrecioReal = VarValorUnitario
                End If

                If VarPrecioReal = "0" Then
                    VarPrecioReal = VarValorUnitario
                End If

                VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                VarPorcentaje = 100 - VarPorcentaje
                VarDescuento = VarPrecioReal - VarValorUnitario
                VarValorUnitario = VarPrecioReal
                iva_valor = valor_iva / 100 + 1
                VarNeto = (VarTotal / iva_valor)
                VarIva = (VarNeto) * valor_iva / 100


                If VarDescuento < "0" Then
                    VarValorUnitario = VarTotal / VarCantidad
                    VarPrecioReal = VarValorUnitario
                    VarPorcentaje = "0"
                    VarDescuento = "0"
                End If

                grilla_detalle_documento.Rows.Add(VarCodProducto,
varnombre & " " & vartecnico,
VarValorUnitario,
VarCantidad,
VarSubtotal,
VarPorcentaje,
VarDescuento,
VarNeto,
VarIva,
VarTotal)
            Next
        End If


        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'SC.Connection = conexion
        'SC.CommandText = "select * from detalle_cotizacion where n_cotizacion= '" & (txt_nro_cotizacion.Text) & "'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'grilla_detalle_documento.Rows.Clear()
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '        grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"),
        '                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre") & " " & DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"),
        '                                       DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"),
        '                                        DS.Tables(DT.TableName).Rows(i).Item("cantidad"),
        '                                         DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"),
        '                                          DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"),
        '                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"),
        '                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"),
        '                                             DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"),
        '                                              DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
        '    Next
        'End If
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

    Sub crear_pdf()
        Dim ruta As String
        Dim nro_copia As Integer
        nro_copia = 0

        If Directory.Exists("C:\Cotizaciones") = False Then ' si no existe la carpeta se crea
            Directory.CreateDirectory("C:\Cotizaciones")
        End If

        nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & ".pdf"

        If nro_copia <> "0" Then
            nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf"
        End If

        Dim exists As Boolean
        exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)

        If exists = True Then
            nro_copia = nro_copia + 1

            nombre_archivo = "COTIZACION NRO. " & txt_nro_cotizacion.Text & "_" & nro_copia & ".pdf"

            exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)

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

        ruta = "C:\Cotizaciones\" & nombre_archivo

        Dim margen_izquierdo As Integer = 20
        Dim margen_superior As Integer = -10

        Try
            Dim document As New iTextSharp.text.Document(PageSize.LETTER, 36, 36, 36, 36)

            ' document.PageSize.Rotate()

            document.AddAuthor("")
            document.AddTitle("")

            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New System.IO.FileStream(ruta, System.IO.FileMode.Create))
            writer.ViewerPreferences = PdfWriter.PageLayoutSinglePage
            document.Open()



            Dim cb As PdfContentByte = writer.DirectContent

            Dim bf As BaseFont = BaseFont.CreateFont("c:\windows\fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
            'Dim bf_negrita As BaseFont = BaseFont.CreateFont("c:\windows\fonts\arial negrita.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED)

            'Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)


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
            Dim fecha_cotizacion As String

            Dim numero_lineas As Integer = 0
            Dim multiplicador_lineas As Integer = 10



            'write_right(cb, "852828528", margen_izquierdo + 530, margen_superior + 600, bf, 10)
            'write_right(cb, "8528528", margen_izquierdo + 560, margen_superior + 590, bf, 10)
            'write_right(cb, "828528", margen_izquierdo + 560, margen_superior + 580, bf, 10)
            'write_right(cb, "852828528", margen_izquierdo + 560, margen_superior + 570, bf, 10)

            rut_cliente = grilla_documento.CurrentRow.Cells(0).Value
            nombre_cliente = grilla_documento.CurrentRow.Cells(1).Value
            direccion_cliente = grilla_documento.CurrentRow.Cells(2).Value
            comuna_cliente = grilla_documento.CurrentRow.Cells(3).Value
            vendedor = grilla_documento.CurrentRow.Cells(4).Value
            movil_vendedor = grilla_documento.CurrentRow.Cells(5).Value
            nro_cotizacion = grilla_documento.CurrentRow.Cells(6).Value
            forma_de_pago = grilla_documento.CurrentRow.Cells(7).Value
            subtotal = grilla_documento.CurrentRow.Cells(8).Value
            descuento = grilla_documento.CurrentRow.Cells(9).Value
            neto = grilla_documento.CurrentRow.Cells(10).Value
            iva = grilla_documento.CurrentRow.Cells(11).Value
            total = grilla_documento.CurrentRow.Cells(12).Value
            fecha_cotizacion = grilla_documento.CurrentRow.Cells(14).Value

            cb.BeginText()

            'For i = numero_lineas_total To grilla_detalle_documento.Rows.Count - 1
            For i = numero_lineas_total To grilla_detalle_documento.Rows.Count - 1
                ' linea = linea * i
                'write_right(cb, "852828528", margen_izquierdo + 560, margen_superior + 600 - (linea * i), bf, 10)

                'If i = 40 Then
                '    document.NewPage()
                'End If

                'e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 10)
                'e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 20)
                'e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 30)
                'e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 40)
                'e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 50)
                'e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 60)

                If numero_lineas = 0 Then
                    write_left(cb, minombreempresa, margen_izquierdo + 0, margen_superior + 780, bf, 7)
                    write_left(cb, migiroempresa, margen_izquierdo + 0, margen_superior + 770, bf, 7)
                    write_left(cb, midireccionempresa, margen_izquierdo + 0, margen_superior + 760, bf, 7)
                    write_left(cb, micomunaempresa, margen_izquierdo + 0, margen_superior + 750, bf, 7)
                    write_left(cb, mitelefonoempresa, margen_izquierdo + 0, margen_superior + 740, bf, 7)
                    write_left(cb, mirutempresa, margen_izquierdo + 0, margen_superior + 730, bf, 7)

                    'posicionar y redimensionarfranja azul
                    Dim imagen As iTextSharp.text.Image 'declaración de imagen
                    imagen = iTextSharp.text.Image.GetInstance("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg") 'nombre y ruta de la imagen a insertar
                    imagen.ScalePercent(100) 'escala al tamaño de la imagen
                    imagen.SetAbsolutePosition(margen_izquierdo + 365, margen_superior + 730) 'posición en la que se inserta. 40 (de izquierda a derecha). 500 (de abajo hacia arriba)
                    document.Add(imagen) 'se agrega la imagen al documento

                    Dim Font_titulo = New Font(bf, 14)
                    Dim Font_fecha = New Font(bf, 10)

                    Dim para = New Paragraph("COTIZACION", Font_titulo)
                    para.SpacingBefore = 33
                    para.SpacingAfter = 20
                    para.Alignment = 1 '0-Left, 1 middle,2 Right
                    document.Add(para)



                    fecha_cotizacion = Format(fecha_cotizacion, "Long Date")
                    fecha_cotizacion = UCase(fecha_cotizacion)

                    Dim Paragraph_fecha = New Paragraph(fecha_cotizacion, Font_fecha)
                    Paragraph_fecha.SpacingBefore = -19
                    Paragraph_fecha.SpacingAfter = 20
                    Paragraph_fecha.Alignment = 1 '0-Left, 1 middle,2 Right
                    document.Add(Paragraph_fecha)


                    'write_left(cb, "COTIZACION", margen_izquierdo + 240, margen_superior + 710, bf, 15)
                    write_left(cb, "______________________________________________________________________________________________________", margen_izquierdo + 0, margen_superior + 709, bf, 10)

                    write_left(cb, "RUT", margen_izquierdo + 0, margen_superior + 670, bf, 10)
                    write_left(cb, ": " & rut_cliente, margen_izquierdo + 60, margen_superior + 670, bf, 10)
                    write_left(cb, "NOMBRE", margen_izquierdo + 0, margen_superior + 655, bf, 10)
                    write_left(cb, ": " & nombre_cliente, margen_izquierdo + 60, margen_superior + 655, bf, 10)
                    write_left(cb, "DIRECCION", margen_izquierdo + 0, margen_superior + 640, bf, 10)
                    write_left(cb, ": " & direccion_cliente, margen_izquierdo + 60, margen_superior + 640, bf, 10)
                    write_left(cb, "COMUNA", margen_izquierdo + 0, margen_superior + 625, bf, 10)
                    write_left(cb, ": " & comuna_cliente, margen_izquierdo + 60, margen_superior + 625, bf, 10)
                    '********************************************************************
                    write_left(cb, "VENDEDOR", margen_izquierdo + 340, margen_superior + 670, bf, 10)
                    write_left(cb, ": " & vendedor, margen_izquierdo + 455, margen_superior + 670, bf, 10)
                    write_left(cb, "TELEFONO VENDEDOR", margen_izquierdo + 340, margen_superior + 655, bf, 10)
                    write_left(cb, ": " & movil_vendedor, margen_izquierdo + 455, margen_superior + 655, bf, 10)
                    write_left(cb, "NRO. COTIZACION", margen_izquierdo + 340, margen_superior + 640, bf, 10)
                    write_left(cb, ": " & nro_cotizacion, margen_izquierdo + 455, margen_superior + 640, bf, 10)
                    write_left(cb, "FORMA DE PAGO", margen_izquierdo + 340, margen_superior + 625, bf, 10)
                    write_left(cb, ": " & forma_de_pago, margen_izquierdo + 455, margen_superior + 625, bf, 10)

                    write_left(cb, "CODIGO", margen_izquierdo + 0, margen_superior + 595 - (numero_lineas * multiplicador_lineas), bf, 9)
                    write_left(cb, "NOMBRE", margen_izquierdo + 60, margen_superior + 595 - (numero_lineas * multiplicador_lineas), bf, 9)
                    write_right(cb, "CANT.", margen_izquierdo + 310, margen_superior + 595 - (numero_lineas * multiplicador_lineas), bf, 9)
                    write_right(cb, "PRECIO", margen_izquierdo + 360, margen_superior + 595 - (numero_lineas * multiplicador_lineas), bf, 9)
                    write_right(cb, "% DESC.", margen_izquierdo + 410, margen_superior + 595 - (numero_lineas * multiplicador_lineas), bf, 9)
                    write_right(cb, "DESC.", margen_izquierdo + 460, margen_superior + 595 - (numero_lineas * multiplicador_lineas), bf, 9)
                    write_right(cb, "SUBTOTAL", margen_izquierdo + 510, margen_superior + 595 - (numero_lineas * multiplicador_lineas), bf, 9)
                    write_right(cb, "TOTAL", margen_izquierdo + 560, margen_superior + 595 - (numero_lineas * multiplicador_lineas), bf, 9)

                    write_left(cb, "______________________________________________________________________________________________________", margen_izquierdo + 0, margen_superior + 594, bf, 10)
                End If



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

                If precio = "" Or precio = "0" Then
                    precio = "0"
                Else
                    precio = Format(Int(precio), "###,###,###")
                End If

                If subtotal_detalle = "" Or subtotal_detalle = "0" Then
                    subtotal_detalle = "0"
                Else
                    subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                End If

                If descuento_detalle = "" Or descuento_detalle = "0" Then
                    descuento_detalle = "0"
                Else
                    descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
                End If

                If total_detalle = "" Or total_detalle = "0" Then
                    total_detalle = "0"
                Else
                    total_detalle = Format(Int(total_detalle), "###,###,###")
                End If

                'If fecha_detalle.Length > 10 Then
                '    fecha_detalle = fecha_detalle.Substring(0, 10)
                'End If

                If nombre.Length > 30 Then
                    nombre = nombre.Substring(0, 30)
                End If



                write_left(cb, codigo, margen_izquierdo + 0, margen_superior + 580 - (numero_lineas * multiplicador_lineas), bf, 9)
                write_left(cb, nombre, margen_izquierdo + 60, margen_superior + 580 - (numero_lineas * multiplicador_lineas), bf, 9)
                write_right(cb, cantidad, margen_izquierdo + 310, margen_superior + 580 - (numero_lineas * multiplicador_lineas), bf, 9)
                write_right(cb, precio, margen_izquierdo + 360, margen_superior + 580 - (numero_lineas * multiplicador_lineas), bf, 9)
                write_right(cb, porcentaje_desc, margen_izquierdo + 410, margen_superior + 580 - (numero_lineas * multiplicador_lineas), bf, 9)
                write_right(cb, descuento_detalle, margen_izquierdo + 460, margen_superior + 580 - (numero_lineas * multiplicador_lineas), bf, 9)
                write_right(cb, subtotal_detalle, margen_izquierdo + 510, margen_superior + 580 - (numero_lineas * multiplicador_lineas), bf, 9)
                write_right(cb, total_detalle, margen_izquierdo + 560, margen_superior + 580 - (numero_lineas * multiplicador_lineas), bf, 9)

                numero_lineas = numero_lineas + 1
                numero_lineas_total = numero_lineas_total + 1

                If numero_lineas > 45 Then
                    'Linea horizontal

                    write_left(cb, "______________________________________________________________________________________________________", margen_izquierdo + 0, margen_superior + 588 - (numero_lineas * multiplicador_lineas), bf, 10)


                    cb.EndText()

                    document.NewPage()

                    cb.BeginText()

                    numero_lineas = 0
                    ' Exit Sub
                End If





            Next
            write_left(cb, "______________________________________________________________________________________________________", margen_izquierdo + 0, margen_superior + 588 - (numero_lineas * multiplicador_lineas), bf, 10)

            write_left(cb, "COTIZACION VALIDA POR " & validez_cotizacion & " DIAS A PARTIR DE LA FECHA DE EMISION", margen_izquierdo + 0, margen_superior + 560 - (numero_lineas * multiplicador_lineas), bf, 10)




            If subtotal = "" Or subtotal = "0" Then
                subtotal = "0"
            Else
                subtotal = Format(Int(subtotal), "###,###,###")
            End If

            If descuento = "" Or descuento = "0" Then
                descuento = "0"
            Else
                descuento = Format(Int(descuento), "###,###,###")
            End If

            If neto = "" Or neto = "0" Then
                neto = "0"
            Else
                neto = Format(Int(neto), "###,###,###")
            End If

            If iva = "" Or iva = "0" Then
                iva = "0"
            Else
                iva = Format(Int(iva), "###,###,###")
            End If

            If total = "" Or total = "0" Then
                total = "0"
            Else
                total = Format(Int(total), "###,###,###")
            End If










            If mirutempresa <> "87686300-6" Then
                write_left(cb, "SUBTOTAL", margen_izquierdo + 430, margen_superior + 560 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, "DESCUENTO", margen_izquierdo + 430, margen_superior + 545 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, "NETO", margen_izquierdo + 430, margen_superior + 530 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, "IVA", margen_izquierdo + 430, margen_superior + 515 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, "TOTAL", margen_izquierdo + 430, margen_superior + 500 - (numero_lineas * multiplicador_lineas), bf, 10)

                write_left(cb, ":", margen_izquierdo + 500, margen_superior + 560 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, ":", margen_izquierdo + 500, margen_superior + 545 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, ":", margen_izquierdo + 500, margen_superior + 530 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, ":", margen_izquierdo + 500, margen_superior + 515 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, ":", margen_izquierdo + 500, margen_superior + 500 - (numero_lineas * multiplicador_lineas), bf, 10)

                write_right(cb, subtotal, margen_izquierdo + 560, margen_superior + 560 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_right(cb, descuento, margen_izquierdo + 560, margen_superior + 545 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_right(cb, neto, margen_izquierdo + 560, margen_superior + 530 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_right(cb, iva, margen_izquierdo + 560, margen_superior + 515 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_right(cb, total, margen_izquierdo + 560, margen_superior + 500 - (numero_lineas * multiplicador_lineas), bf, 10)
            Else
                write_left(cb, "NETO", margen_izquierdo + 430, margen_superior + 560 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, "IVA", margen_izquierdo + 430, margen_superior + 545 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, "TOTAL", margen_izquierdo + 430, margen_superior + 530 - (numero_lineas * multiplicador_lineas), bf, 10)

                write_left(cb, ":", margen_izquierdo + 500, margen_superior + 560 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, ":", margen_izquierdo + 500, margen_superior + 545 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_left(cb, ":", margen_izquierdo + 500, margen_superior + 530 - (numero_lineas * multiplicador_lineas), bf, 10)

                write_right(cb, neto, margen_izquierdo + 560, margen_superior + 560 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_right(cb, iva, margen_izquierdo + 560, margen_superior + 545 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_right(cb, total, margen_izquierdo + 560, margen_superior + 530 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_right(cb, "DESCUENTOS YA APLICADOS", margen_izquierdo + 560, margen_superior + 515 - (numero_lineas * multiplicador_lineas), bf, 10)
                write_right(cb, "VALORES INCLUYEN IVA", margen_izquierdo + 560, margen_superior + 500 - (numero_lineas * multiplicador_lineas), bf, 10)
            End If

            cb.EndText()
            numero_lineas_total = 0
            document.Close()

        Catch ex As Exception
            MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
        End Try
    End Sub

    Public Shared Sub write_center(ByVal cb As PdfContentByte, ByVal Text As String, ByVal X As Integer, ByVal Y As Integer, ByVal font As BaseFont, ByVal Size As Integer)
        cb.SetFontAndSize(font, Size)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Text, 0, Y, 0)
    End Sub

    Public Shared Sub write_left(ByVal cb As PdfContentByte, ByVal Text As String, ByVal X As Integer, ByVal Y As Integer, ByVal font As BaseFont, ByVal Size As Integer)
        cb.SetFontAndSize(font, Size)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Text, X, Y, 0)
    End Sub

    Public Shared Sub write_right(ByVal cb As PdfContentByte, ByVal Text As String, ByVal X As Integer, ByVal Y As Integer, ByVal font As BaseFont, ByVal Size As Integer)
        cb.SetFontAndSize(font, Size)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Text, X, Y, 0)
    End Sub

    Private Sub lbl_correo_Click(sender As Object, e As EventArgs) Handles lbl_correo.Click

    End Sub
End Class