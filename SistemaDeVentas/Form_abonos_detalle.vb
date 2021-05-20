Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class Form_abonos_detalle
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim alto_cotizacion As String
    Private WithEvents Pd As New PrintDocument
    Dim numero_lineas_total As Integer = 0
    Dim tipo_impresion As Integer = 0
    'Dim impreso As Integer = 0

    Private Sub Form_abonos_detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_abonos_detalle_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_abonos_detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        'mostrar_malla()
        'calcular_totales()
        txt_rut_cliente.Focus()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub



    Sub limpiar()
        txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        grilla_documento.DataSource = Nothing
        dtp_desde.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_hasta.Text = FormatDateTime(Now, DateFormat.ShortDate)
        txt_rut_cliente.Focus()
    End Sub


    Sub mostrar_datos_clientes()
        conexion.Close()
        If txt_rut_cliente.Text <> "" Then
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_nombre_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_cliente")
                conexion.Close()
                Exit Sub
            ElseIf DS2.Tables(DT2.TableName).Rows.Count < 1 Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
        End If
    End Sub


    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_cliente.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_cliente.Text = rut_cliente
            End If
        End If
    End Sub
    Sub mostrar_malla()

        lbl_mensaje.Visible = True
        Me.Enabled = False




        If txt_nombre_cliente.Text = "" Then

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            ' SC3.CommandText = "select abono.fecha as 'FECHA',  clientes.nombre_cliente as 'CLIENTE', abono.rut_cliente as 'RUT', abono.n_abono as 'NRO.', abono.condicion_abono as 'CONDIC.', abono.detalle_abono as 'DETALLE',  ABONO.estado as 'ESTADO', DETALLE_ABONO.monto_abono as 'TOTAL', DETALLE_ABONO.tipo_docUMENTO AS 'TIPO DOC.', DETALLE_ABONO.NRO_DOCUMENTO AS 'NRO DOC.', DETALLE_ABONO.FECHA_VENCIMIENTO AS 'VENC.', detalle_abono.NUMERO_CUOTA AS 'NRO. CUOTA', detalle_abono.TOTAL_CUOTAS AS 'TOTAL CUOTAS',  usuarios.nombre_usuario as 'USUARIO' from abono, DETALLE_ABONO, usuarios, clientes  where abono.fecha >='" & (mifecha2) & "' and abono.fecha <= '" & (mifecha4) & "' and abono.usuario_responsable=usuarios.rut_usuario and abono.rut_cliente=clientes.rut_cliente  and abono.N_ABONO=detalle_abono.nro_abono order by n_abono asc"
            SC3.CommandText = "select abono.fecha as 'FECHA',  nombre as 'CLIENTE', abono.rut_cliente as 'RUT', abono.n_abono as 'NRO.', abono.condicion_abono as 'CONDIC.', abono.detalle_abono as 'DETALLE',  ABONO.estado as 'ESTADO', DETALLE_ABONO.monto_abono as 'TOTAL', DETALLE_ABONO.tipo_docUMENTO AS 'TIPO DOC.', DETALLE_ABONO.NRO_DOCUMENTO AS 'NRO DOC.', DETALLE_ABONO.FECHA_VENCIMIENTO AS 'VENC.', detalle_abono.NUMERO_CUOTA AS 'NRO. CUOTA', detalle_abono.TOTAL_CUOTAS AS 'TOTAL CUOTAS',  usuarios.nombre_usuario as 'USUARIO' from abono, DETALLE_ABONO, usuarios where abono.fecha >='" & (mifecha2) & "' and abono.fecha <= '" & (mifecha4) & "' and abono.usuario_responsable=usuarios.rut_usuario and abono.N_ABONO=detalle_abono.nro_abono order by n_abono asc"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If

        If txt_nombre_cliente.Text <> "" Then

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            ' SC3.CommandText = "select fecha as 'FECHA', n_abono as 'NRO.', condicion_abono as 'CONDIC.',   detalle_abono as 'DETALLE',estado as 'ESTADO',  nombre_cliente as 'CLIENTE', abono.rut_cliente as 'RUT', monto_abono as 'TOTAL', nombre_usuario as 'USUARIO' from abono, usuarios, clientes  where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and abono.usuario_responsable=usuarios.rut_usuario and abono.rut_cliente=clientes.rut_cliente  and abono.rut_cliente = '" & (txt_rut_cliente.Text) & "' order by n_abono desc"
            SC3.CommandText = "select abono.fecha as 'FECHA',  nombre as 'CLIENTE', abono.rut_cliente as 'RUT', abono.n_abono as 'NRO.', abono.condicion_abono as 'CONDIC.', abono.detalle_abono as 'DETALLE',  ABONO.estado as 'ESTADO', DETALLE_ABONO.monto_abono as 'TOTAL', DETALLE_ABONO.tipo_docUMENTO AS 'TIPO DOC.', DETALLE_ABONO.NRO_DOCUMENTO AS 'NRO DOC.', DETALLE_ABONO.FECHA_VENCIMIENTO AS 'VENC.', detalle_abono.NUMERO_CUOTA AS 'NRO. CUOTA', detalle_abono.TOTAL_CUOTAS AS 'TOTAL CUOTAS',  usuarios.nombre_usuario as 'USUARIO' from abono, DETALLE_ABONO, usuarios  where abono.fecha >='" & (mifecha2) & "' and abono.fecha <= '" & (mifecha4) & "' and abono.usuario_responsable=usuarios.rut_usuario and abono.N_ABONO=detalle_abono.nro_abono   and abono.rut_cliente = '" & (txt_rut_cliente.Text) & "'  order by n_abono asc"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If
    End Sub

    Private Sub txt_rut_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress

        txt_nombre_cliente.Text = ""

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

        grilla_documento.DataSource = Nothing
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            guion_rut_cliente()
            mostrar_datos_clientes()
        End If

    End Sub

    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged

    End Sub

    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet


    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("desde", GetType(String)))
    '    dt.Columns.Add(New DataColumn("hasta", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("numero", GetType(String)))
    '    dt.Columns.Add(New DataColumn("condicion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("cliente_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("total", GetType(String)))
    '    dt.Columns.Add(New DataColumn("usuario", GetType(String)))

    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("ciudad_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))






    '    Dim fecha As String
    '    Dim nuumero As String
    '    Dim condicion As String
    '    Dim detalle As String
    '    Dim cliente As String
    '    Dim rut_cliente As String
    '    Dim total As String
    '    Dim usuario As String




    '    For i = 0 To grilla_documento.Rows.Count - 1


    '        fecha = grilla_documento.Rows(i).Cells(0).Value.ToString
    '        nuumero = grilla_documento.Rows(i).Cells(1).Value.ToString
    '        condicion = grilla_documento.Rows(i).Cells(3).Value.ToString
    '        detalle = grilla_documento.Rows(i).Cells(2).Value.ToString
    '        cliente = grilla_documento.Rows(i).Cells(4).Value.ToString
    '        rut_cliente = grilla_documento.Rows(i).Cells(5).Value.ToString
    '        total = grilla_documento.Rows(i).Cells(6).Value.ToString
    '        usuario = grilla_documento.Rows(i).Cells(7).Value.ToString

    '        dr = dt.NewRow()

    '        Try
    '            dr("Imagen") = ImageToByte(Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_crystal.jpg"))
    '        Catch
    '        End Try

    '        dr("nombre_cliente") = txt_nombre_cliente.Text
    '        dr("rut_cliente") = txt_rut_cliente.Text
    '        dr("desde") = dtp_desde.Text
    '        dr("hasta") = dtp_hasta.Text
    '        dr("fecha") = fecha
    '        dr("numero") = nuumero
    '        dr("condicion") = condicion
    '        dr("detalle") = detalle
    '        dr("cliente_detalle") = cliente
    '        dr("rut_detalle") = rut_cliente
    '        dr("total") = total
    '        dr("usuario") = usuario

    '        dr("nombre_empresa") = minombreempresa
    '        dr("giro_empresa") = migiroempresa
    '        dr("direccion_empresa") = midireccionempresa
    '        dr("ciudad_empresa") = micomunaempresa
    '        dr("telefono_empresa") = mitelefonoempresa
    '        dr("correo_empresa") = micorreoempresa
    '        dr("rut_empresa") = mirutempresa
    '    Next





    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "ListadoAbonos"

    '    Dim iDS As New dsListadoAbonos

    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function
















    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nro_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("condicion_pago", GetType(String)))
    '    dt.Columns.Add(New DataColumn("detalle_condicion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("estado", GetType(String)))
    '    dt.Columns.Add(New DataColumn("total", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("tipo_doc", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nro_doc", GetType(String)))
    '    dt.Columns.Add(New DataColumn("vencimiento", GetType(String)))
    '    dt.Columns.Add(New DataColumn("cuota", GetType(String)))
    '    dt.Columns.Add(New DataColumn("usuario", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("titulo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("recinto_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("total_final", GetType(Integer)))

    '    'Dim Imagen As String
    '    Dim fecha As String
    '    Dim nombre_cliente As String
    '    Dim rut_cliente As String
    '    Dim nro_abono As String
    '    Dim condicion_pago As String
    '    Dim detalle_condicion As String
    '    Dim estado As String
    '    Dim total As String
    '    Dim tipo_doc As String
    '    Dim nro_doc As String
    '    Dim vencimiento As String
    '    Dim cuota As String
    '    Dim usuario As String

    '    'Dim titulo As String
    '    'Dim recinto_empresa As String
    '    ' Dim total_final As String

    '    For i = 0 To grilla_documento.Rows.Count - 1

    '        fecha = grilla_documento.Rows(i).Cells(0).Value.ToString
    '        nombre_cliente = grilla_documento.Rows(i).Cells(1).Value.ToString
    '        rut_cliente = grilla_documento.Rows(i).Cells(2).Value.ToString
    '        nro_abono = grilla_documento.Rows(i).Cells(3).Value.ToString
    '        condicion_pago = grilla_documento.Rows(i).Cells(4).Value.ToString
    '        detalle_condicion = grilla_documento.Rows(i).Cells(5).Value.ToString
    '        estado = grilla_documento.Rows(i).Cells(6).Value.ToString
    '        total = grilla_documento.Rows(i).Cells(7).Value.ToString
    '        tipo_doc = grilla_documento.Rows(i).Cells(8).Value.ToString
    '        nro_doc = grilla_documento.Rows(i).Cells(9).Value.ToString
    '        vencimiento = grilla_documento.Rows(i).Cells(10).Value.ToString
    '        cuota = grilla_documento.Rows(i).Cells(11).Value.ToString & " DE " & grilla_documento.Rows(i).Cells(11).Value.ToString
    '        usuario = grilla_documento.Rows(i).Cells(13).Value.ToString


    '        dr = dt.NewRow()

    '        Try
    '            dr("Imagen") = Imagen_ticket
    '        Catch
    '        End Try

    '        dr("titulo") = "LIBRO DE DEUDORES " & mirecintoempresa & ""
    '        dr("recinto_empresa") = "DESDE " & dtp_desde.Text & " HASTA " & dtp_hasta.Text



    '        dr("fecha") = fecha
    '        dr("nombre_cliente") = nombre_cliente
    '        dr("rut_cliente") = rut_cliente
    '        dr("nro_abono") = nro_abono
    '        dr("condicion_pago") = condicion_pago
    '        dr("detalle_condicion") = detalle_condicion
    '        dr("estado") = estado
    '        dr("total") = total
    '        dr("tipo_doc") = tipo_doc
    '        dr("nro_doc") = nro_doc
    '        dr("vencimiento") = vencimiento
    '        dr("cuota") = cuota
    '        dr("usuario") = usuario
    '        dr("nombre_empresa") = minombreempresa
    '        dr("giro_empresa") = migiroempresa
    '        dr("direccion_empresa") = midireccionempresa
    '        dr("comuna_empresa") = micomunaempresa
    '        dr("telefono_empresa") = mitelefonoempresa
    '        dr("correo_empresa") = micorreoempresa
    '        dr("rut_empresa") = mirutempresa

    '        dr("total_final") = txt_total.Text
    '        dt.Rows.Add(dr)

    '    Next

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "DetalleAbonos"

    '    Dim iDS As New DsDetalleAbonos
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS

    'End Function


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


    Sub calcular_totales()


        Dim totalgrilla As Long



        '//Calcular el total general
        txt_total.Text = 0
        For i = 0 To grilla_documento.Rows.Count - 1
            totalgrilla = Val(grilla_documento.Rows(i).Cells(7).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total.Text = "0"
        Else
            txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        If grilla_documento.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        calcular_totales()

        tipo_impresion = 1
        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = True
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = True
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub


    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub


    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub



    Private Sub txt_rut_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_documento.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp_desde.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_documento, save.FileName)
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True


    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)


        'xlApp.Range("F1:I1").Merge(True)
        'xlApp.Range("F1:I1").value = "ORDEN DE TRABAJO"
        'xlApp.Range("F1:I1").rowheight = 65
        'xlApp.Range("F1:I1").Font.Size = 12

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_documento.Columns.Count - 1
            xlWS.cells(3, c + 1).value = grilla_documento.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_documento.RowCount - 1
            For c As Integer = 0 To grilla_documento.Columns.Count - 1
                xlWS.cells(r + 4, c + 1).value = grilla_documento.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
       grilla_documento.DataSource = Nothing
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
      grilla_documento.DataSource = Nothing
    End Sub

  

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub

    Private Sub grilla_documento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.Click

    End Sub

    Private Sub grilla_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.DoubleClick

     
    End Sub





    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_documento.DataSource = Nothing
        fecha()
        mostrar_malla()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If tipo_impresion = 1 Then
            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
            Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
            Dim Font_titulo_columna As New Font("verdana", 6.5, FontStyle.Bold)
            Dim Font_texto_impresion As New Font("verdana", 6.5, FontStyle.Regular)
            Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
            Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            Dim margen_izquierdo As Integer
            Dim margen_superior As Integer

            margen_izquierdo = 0
            margen_superior = 0

            Try
                Dim imagen_reporte As Image
                imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
                Dim posicion_imagen As New PointF(margen_izquierdo + 845, margen_superior + 10)
                e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
            Catch
            End Try

            e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
            e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
            e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
            e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
            e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
            e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

            Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 65, margen_izquierdo + 1100, margen_superior + 55)
            Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 80, margen_izquierdo + 1100, margen_superior + 70)

            e.Graphics.DrawString("LISTADO DE ABONOS", Font_titulo, Brushes.Black, rect1, stringFormat)
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 103, margen_izquierdo + 1120, margen_superior + 103)
            e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

            If txt_nombre_cliente.Text.Length > 23 Then
                txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 23)
            End If

            e.Graphics.DrawString("DESDE: " & dtp_desde.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 130)
            e.Graphics.DrawString("HASTA: " & dtp_hasta.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 300, margen_superior + 130)
            e.Graphics.DrawString("RUT: " & txt_rut_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 550, margen_superior + 130)
            e.Graphics.DrawString("NOMBRE: " & txt_nombre_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 800, margen_superior + 130)

            e.Graphics.DrawString("FECHA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 160)
            e.Graphics.DrawString("CLIENTE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 130, margen_superior + 160)
            e.Graphics.DrawString("RUT", Font_titulo_columna, Brushes.Black, margen_izquierdo + 320, margen_superior + 160)
            e.Graphics.DrawString("ABONO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 400, margen_superior + 160)
            e.Graphics.DrawString("CONDICION", Font_titulo_columna, Brushes.Black, margen_izquierdo + 470, margen_superior + 160)
            e.Graphics.DrawString("ESTADO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 580, margen_superior + 160)
            e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 690, margen_superior + 160, format1)
            e.Graphics.DrawString("DOC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 730, margen_superior + 160)
            e.Graphics.DrawString("NRO.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 810, margen_superior + 160)
            e.Graphics.DrawString("VENC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 890, margen_superior + 160)
            e.Graphics.DrawString("USUARIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 970, margen_superior + 160)

            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 175, margen_izquierdo + 1120, margen_superior + 175)

            If txt_rut_cliente.Text = "" Then
                txt_rut_cliente.Text = "TODOS"
            End If

            If txt_nombre_cliente.Text = "" Then
                txt_nombre_cliente.Text = "TODOS"
            End If

            Dim fecha As String
            Dim nombre_cliente As String
            Dim rut_cliente As String
            Dim nro_abono As String
            Dim condicion_pago As String
            Dim detalle_condicion As String
            Dim estado As String
            Dim total As String
            Dim tipo_doc As String
            Dim nro_doc As String
            Dim vencimiento As String
            Dim cuota As String
            Dim usuario As String
            Dim numero_lineas As Integer = 0
            Dim multiplicador_lineas As Integer = 10

            For i = numero_lineas_total To grilla_documento.Rows.Count - 1
                fecha = grilla_documento.Rows(i).Cells(0).Value.ToString
                nombre_cliente = grilla_documento.Rows(i).Cells(1).Value.ToString
                rut_cliente = grilla_documento.Rows(i).Cells(2).Value.ToString
                nro_abono = grilla_documento.Rows(i).Cells(3).Value.ToString
                condicion_pago = grilla_documento.Rows(i).Cells(4).Value.ToString
                detalle_condicion = grilla_documento.Rows(i).Cells(5).Value.ToString
                estado = grilla_documento.Rows(i).Cells(6).Value.ToString
                total = grilla_documento.Rows(i).Cells(7).Value.ToString
                tipo_doc = grilla_documento.Rows(i).Cells(8).Value.ToString
                nro_doc = grilla_documento.Rows(i).Cells(9).Value.ToString
                vencimiento = grilla_documento.Rows(i).Cells(10).Value.ToString
                cuota = grilla_documento.Rows(i).Cells(11).Value.ToString & " DE " & grilla_documento.Rows(i).Cells(11).Value.ToString
                usuario = grilla_documento.Rows(i).Cells(13).Value.ToString

                If total = "" Or total = "0" Then
                    total = "0"
                Else
                    total = Format(Int(total), "###,###,###")
                End If

                If fecha.Length > 10 Then
                    fecha = fecha.Substring(0, 10)
                End If

                If vencimiento.Length > 10 Then
                    vencimiento = vencimiento.Substring(0, 10)
                End If

                If nombre_cliente.Length > 30 Then
                    nombre_cliente = nombre_cliente.Substring(0, 30)
                End If

                If usuario.Length > 20 Then
                    usuario = usuario.Substring(0, 20)
                End If

                e.Graphics.DrawString(fecha, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 180 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(nombre_cliente, Font_texto_impresion, Brushes.Black, margen_izquierdo + 130, margen_superior + 180 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(rut_cliente, Font_texto_impresion, Brushes.Black, margen_izquierdo + 320, margen_superior + 180 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(nro_abono, Font_texto_impresion, Brushes.Black, margen_izquierdo + 400, margen_superior + 180 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(condicion_pago, Font_texto_impresion, Brushes.Black, margen_izquierdo + 470, margen_superior + 180 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(estado, Font_texto_impresion, Brushes.Black, margen_izquierdo + 580, margen_superior + 180 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(total, Font_texto_impresion, Brushes.Black, margen_izquierdo + 690, margen_superior + 180 + (numero_lineas * multiplicador_lineas), format1)
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(tipo_doc, Font_texto_impresion, Brushes.Black, margen_izquierdo + 730, margen_superior + 180 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(nro_doc, Font_texto_impresion, Brushes.Black, margen_izquierdo + 810, margen_superior + 180 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(vencimiento, Font_texto_impresion, Brushes.Black, margen_izquierdo + 890, margen_superior + 180 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(usuario, Font_texto_impresion, Brushes.Black, margen_izquierdo + 970, margen_superior + 180 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                numero_lineas = numero_lineas + 1
                numero_lineas_total = numero_lineas_total + 1

                If numero_lineas > 85 Then
                    'Linea horizontal
                    e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 185 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 1120, margen_superior + 185 + (numero_lineas * multiplicador_lineas))
                    '***************************************************************************************************************************************************
                    e.HasMorePages = True ' Todavia faltan mas paginas
                    Exit Sub
                Else
                    e.HasMorePages = False
                End If
            Next

            'Linea horizontal
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 185 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 1120, margen_superior + 185 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            numero_lineas_total = 0

            e.Graphics.DrawString("TOTALES: " & txt_total.Text, Font_texto_impresion, Brushes.Black, margen_izquierdo + 690, margen_superior + 190 + (numero_lineas * multiplicador_lineas), format1)

        End If

        If tipo_impresion = 2 Then
            'Dim nro_abono As String
            'Dim fecha_abono As String
            'Dim rut_abono As String
            'Dim nombre_abono As String
            'Dim total_abono As String

            'nro_abono = grilla_documento.CurrentRow.Cells(1).Value
            'fecha_abono = grilla_documento.CurrentRow.Cells(0).Value
            'rut_abono = grilla_documento.CurrentRow.Cells(6).Value
            'nombre_abono = grilla_documento.CurrentRow.Cells(5).Value
            'total_abono = grilla_documento.CurrentRow.Cells(7).Value

            'Dim detalle_referencia As String
            'Dim detalle_abono As String
            'Dim detalle_saldo As String

            'Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
            'Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
            'Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
            'Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

            'Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            'format1.Alignment = StringAlignment.Far

            'Dim Font1 As New Font("arial", 7, FontStyle.Regular)
            'Dim Font2 As New Font("arial", 9, FontStyle.Bold)
            'Dim Font3 As New Font("arial", 7, FontStyle.Bold)
            'Dim Font4 As New Font("arial", 8, FontStyle.Bold)

            'Try
            '    'im = Image.FromFile(ruta_logo_empresa_ticket)
            '    Dim p As New PointF(0, 0)
            '    'e.Graphics.DrawImage(im, p)
            '    e.Graphics.DrawImage(Bytes_Imagen(Imagen_ticket), p)
            'Catch
            'End Try

            'Dim stringFormat As New StringFormat()
            'stringFormat.Alignment = StringAlignment.Center
            'stringFormat.LineAlignment = StringAlignment.Center

            'Dim rect1 As New Rectangle(10, 60, 270, 15)
            'Dim rect2 As New Rectangle(10, 75, 270, 15)
            'Dim rect3 As New Rectangle(10, 90, 270, 15)
            'Dim rect4 As New Rectangle(10, 105, 270, 15)
            'Dim rect5 As New Rectangle(10, 120, 270, 15)
            'Dim rect6 As New Rectangle(10, 135, 270, 15)
            'Dim rect7 As New Rectangle(10, 165, 270, 15)

            'e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
            'e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
            'e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
            'e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
            'e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
            'e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

            'e.Graphics.DrawString("COMPROBANTE DE INGRESO", Font2, Brushes.Black, rect7, stringFormat)

            'e.Graphics.DrawString("NRO. ABONO", Font3, Brushes.Black, 0, 195)
            'e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 195)
            'e.Graphics.DrawString(nro_abono, Font4, Brushes.Black, 95, 195)
            'e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 210)
            'e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 210)
            'e.Graphics.DrawString(fecha_abono, Font3, Brushes.Black, 95, 210)
            'e.Graphics.DrawString("NOMBRE CLIENTE", Font3, Brushes.Black, 0, 225)
            'e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 225)
            'e.Graphics.DrawString(nombre_abono, Font3, Brushes.Black, 95, 225)
            'e.Graphics.DrawString("RUT CLIENTE", Font3, Brushes.Black, 0, 240)
            'e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 240)
            'e.Graphics.DrawString(rut_abono, Font3, Brushes.Black, 95, 240)

            'e.Graphics.DrawString("DETALLE REFERENCIA", Font3, Brushes.Black, 0, 270)

            'e.Graphics.DrawString("ABONO", Font3, Brushes.Black, 170, 270)
            'e.Graphics.DrawString("SALDO", Font3, Brushes.Black, 245, 270)
            'e.Graphics.DrawLine(Pens.Black, 1, 285, 295, 285)

            'If grilla_abono.Rows.Count <> 0 Then
            '    For i = 0 To grilla_abono.Rows.Count - 1
            '        detalle_referencia = grilla_abono.Rows(i).Cells(0).Value.ToString & " NRO. " & grilla_abono.Rows(i).Cells(1).Value.ToString
            '        detalle_abono = grilla_abono.Rows(i).Cells(2).Value.ToString
            '        detalle_saldo = grilla_abono.Rows(i).Cells(3).Value.ToString

            '        Dim saldo As Integer
            '        Dim abono As Integer

            '        saldo = detalle_saldo
            '        abono = detalle_abono

            '        Dim descripcion As String

            '        descripcion = detalle_referencia
            '        If detalle_referencia.Length > 23 Then
            '            descripcion = detalle_referencia.Substring(0, 24)
            '        End If
            '        If abono <> 0 Then
            '            abono = Format(Int(abono), "###,###,###")
            '        Else
            '            abono = 0
            '        End If

            '        If saldo <> 0 Then
            '            saldo = Format(Int(saldo), "###,###,###")
            '        Else
            '            saldo = 0
            '        End If

            '        e.Graphics.DrawString(descripcion, Font3, Brushes.Gray, 0, 290 + (i * 15))
            '        e.Graphics.DrawString(abono, Font3, Brushes.Gray, 210, 290 + (i * 15), format1)
            '        e.Graphics.DrawString(saldo, Font3, Brushes.Gray, 285, 290 + (i * 15), format1)
            '    Next

            'Else
            '    e.Graphics.DrawString("SIN DOCUMENTOS IMPUTADOS", Font3, Brushes.Black, 0, 290)
            'End If

            'Dim total_millar As String

            'total_millar = total_abono
            'total_millar = Format(Int(total_millar), "###,###,###")

            'Dim var_grilla As Integer
            'var_grilla = ((grilla_abono.Rows.Count - 1) * 15)

            'e.Graphics.DrawString("TOTAL INGRESO", Font2, Brushes.Black, 100, var_grilla + 320)
            'e.Graphics.DrawString(":", Font2, Brushes.Black, 200, var_grilla + 320)
            'e.Graphics.DrawString(total_millar, Font2, Brushes.Black, 285, var_grilla + 320, format1)

            'Dim rect8 As New Rectangle(10, var_grilla + 380, 270, 15)

            'e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, var_grilla + 580)
            'alto_cotizacion = var_grilla + 470
        End If
    End Sub
End Class