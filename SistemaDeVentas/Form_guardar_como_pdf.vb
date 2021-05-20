Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO



Public Class Form_guardar_como_pdf
    Dim desglose_total_cotizacion As String
    Dim peso As String
    Dim btn_impresion As String

    Private Sub Form_guardar_como_pdf_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_guardar_como_pdf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form_venta.crear_numero_documento()
        crear_pdf()
        Form_venta.grabar_factura()
        Form_venta.grabar_detalle_factura()
        Form_venta.limpiar()
        Me.Close()
    End Sub



    Sub crear_pdf()
        'Dim nombre_archivo As String
        'Dim ruta As String
        Dim nro_copia As Integer
        nro_copia = 0



        Dim savefiledialog As New SaveFileDialog
        Dim ruta As String
        With savefiledialog
            .Title = "GUARDAR"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Filter = "Archivos Adobe PDF (*.pdf)|*.pdf"
            .FileName = "COTIZACION NRO. " & Form_venta.txt_factura.Text & ".pdf"
            .OverwritePrompt = True
            .CheckPathExists = True
        End With

        If savefiledialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ruta = savefiledialog.FileName
        Else
            ruta = String.Empty
            Exit Sub
        End If








        'If Directory.Exists("C:\Cotizaciones") = False Then ' si no existe la carpeta se crea
        '    Directory.CreateDirectory("C:\Cotizaciones")
        'End If

        'nombre_archivo = "COTIZACION NRO. " & Form_venta.txt_factura.Text & ".pdf"

        'If nro_copia <> "0" Then
        '    nombre_archivo = "COTIZACION NRO. " & Form_venta.txt_factura.Text & "_" & nro_copia & ".pdf"
        'End If

        'Dim exists As Boolean
        'exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)

        'If exists = True Then
        '    nro_copia = nro_copia + 1

        '    nombre_archivo = "COTIZACION NRO. " & Form_venta.txt_factura.Text & "_" & nro_copia & ".pdf"

        '    exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)

        '    Dim index As Integer = 0
        '    Do While exists = True
        '        nombre_archivo = "COTIZACION NRO. " & Form_venta.txt_factura.Text & "_" & nro_copia & ".pdf"
        '        exists = System.IO.File.Exists("C:\Cotizaciones\" & nombre_archivo)

        '        If exists = False Then
        '            Exit Do
        '        End If

        '        nro_copia = nro_copia + 1
        '    Loop
        'End If

        'ruta = "C:\Cotizaciones\" & nombre_archivo

        Dim margen_izquierdo As Integer = 20
        Dim margen_superior As Integer = 0

        Dim alto_documento As Integer = 0
        alto_documento = (Form_venta.grilla_detalle_venta.Rows.Count * 35)
        alto_documento = alto_documento + 510

        Dim alto_documento_pie As Integer = alto_documento
        Try
            ' Dim document As New iTextSharp.text.Document(PageSize.LETTER, 36, 36, 36, 36)

            Dim tamaño_ticket As New iTextSharp.text.Rectangle(270, alto_documento)
            Dim document As New iTextSharp.text.Document(tamaño_ticket, 36, 36, 36, 36)



            'document.PageSize.Rotate()

            document.AddAuthor("")
            document.AddTitle("")

            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New System.IO.FileStream(ruta, System.IO.FileMode.Create))
            writer.ViewerPreferences = PdfWriter.PageLayoutSinglePage
            document.Open()



            Dim cb As PdfContentByte = writer.DirectContent

            Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)

            Dim bf_bold As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)




            Dim nombre_cliente As String
            Dim rut_cliente As String
            Dim direccion_cliente As String
            Dim comuna_cliente As String
            Dim vendedor As String
            Dim movil_vendedor As String
            Dim nro_cotizacion As String
            Dim forma_de_pago As String

            Dim subtotal As String
            Dim descuento As String
            Dim neto As String
            Dim iva As String
            Dim total As String
            Dim fecha_cotizacion As String

            Dim numero_lineas As Integer = 0
            Dim multiplicador_lineas As Integer = 10





            rut_cliente = Form_venta.txt_rut_cliente.Text
            nombre_cliente = Form_venta.txt_nombre_cliente.Text
            direccion_cliente = Form_venta.txt_direccion_cliente.Text
            comuna_cliente = Form_venta.txt_comuna_cliente.Text
            vendedor = minombre
            movil_vendedor = mitelefono
            nro_cotizacion = Form_venta.txt_factura.Text
            forma_de_pago = Form_venta.combo_condiciones.Text
            subtotal = Form_venta.txt_sub_total_millar.Text
            descuento = Form_venta.txt_desc_millar.Text
            neto = Form_venta.txt_neto_millar.Text
            iva = Form_venta.txt_iva_millar.Text
            total = Form_venta.txt_total_millar.Text
            fecha_cotizacion = Form_menu_principal.dtp_fecha.Text

            cb.BeginText()


            'posicionar y redimensionarfranja azul
            Dim imagen As iTextSharp.text.Image 'declaración de imagen
            imagen = iTextSharp.text.Image.GetInstance("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg") 'nombre y ruta de la imagen a insertar
            imagen.ScalePercent(115) 'escala al tamaño de la imagen
            imagen.SetAbsolutePosition(20, alto_documento - 70) 'posición en la que se inserta. 40 (de izquierda a derecha). 500 (de abajo hacia arriba)
            document.Add(imagen) 'se agrega la imagen al documento

            Dim Font_titulo = New Font(bf_bold, 12)
            Dim Font_fecha = New Font(bf, 10)
            Dim Font_datos_empresa = New Font(bf, 9)

            Dim Paragraph_titulo = New Paragraph("COTIZACION", Font_titulo)
            Paragraph_titulo.SpacingBefore = 50
            Paragraph_titulo.SpacingAfter = 0
            Paragraph_titulo.Alignment = 1 '0-Left, 1 middle,2 Right
            document.Add(Paragraph_titulo)

            fecha_cotizacion = Format(fecha_cotizacion, "Long Date")
            fecha_cotizacion = UCase(fecha_cotizacion)

            'Dim Paragraph_fecha = New Paragraph(fecha_cotizacion, Font_fecha)
            'Paragraph_fecha.SpacingBefore = 0
            'Paragraph_fecha.SpacingAfter = 40
            'Paragraph_fecha.Alignment = 1 '0-Left, 1 middle,2 Right
            'document.Add(Paragraph_fecha)

            Dim Paragraph_empresa_1 = New Paragraph(minombreempresa, Font_datos_empresa)
            Paragraph_empresa_1.SpacingBefore = 20
            Paragraph_empresa_1.SpacingAfter = 0
            Paragraph_empresa_1.Alignment = 1 '0-Left, 1 middle,2 Right
            document.Add(Paragraph_empresa_1)

            Dim Paragraph_empresa_2 = New Paragraph(mirutempresa, Font_datos_empresa)
            Paragraph_empresa_2.SpacingBefore = 0
            Paragraph_empresa_2.SpacingAfter = 0
            Paragraph_empresa_2.Alignment = 1 '0-Left, 1 middle,2 Right
            document.Add(Paragraph_empresa_2)

            Dim Paragraph_empresa_3 = New Paragraph(midireccionempresa, Font_datos_empresa)
            Paragraph_empresa_3.SpacingBefore = 0
            Paragraph_empresa_3.SpacingAfter = 0
            Paragraph_empresa_3.Alignment = 1 '0-Left, 1 middle,2 Right
            document.Add(Paragraph_empresa_3)

            Dim Paragraph_empresa_4 = New Paragraph(micomunaempresa, Font_datos_empresa)
            Paragraph_empresa_4.SpacingBefore = 0
            Paragraph_empresa_4.SpacingAfter = 0
            Paragraph_empresa_4.Alignment = 1 '0-Left, 1 middle,2 Right
            document.Add(Paragraph_empresa_4)

            Dim Paragraph_empresa_5 = New Paragraph(mitelefonoempresa, Font_datos_empresa)
            Paragraph_empresa_5.SpacingBefore = 0
            Paragraph_empresa_5.SpacingAfter = 0
            Paragraph_empresa_5.Alignment = 1 '0-Left, 1 middle,2 Right
            document.Add(Paragraph_empresa_5)

            Dim Paragraph_empresa_6 = New Paragraph(mirutempresa, Font_datos_empresa)
            Paragraph_empresa_6.SpacingBefore = 0
            Paragraph_empresa_6.SpacingAfter = 0
            Paragraph_empresa_6.Alignment = 1 '0-Left, 1 middle,2 Right
            document.Add(Paragraph_empresa_6)


            alto_documento = alto_documento - 220

            alto_documento = alto_documento - 15
            write_left(cb, "NUMERO", margen_izquierdo + 0, alto_documento, bf_bold, 10)
            write_left(cb, ": " & Form_venta.txt_factura.Text, margen_izquierdo + 60, alto_documento, bf, 10)

            alto_documento = alto_documento - 15
            write_left(cb, "FECHA", margen_izquierdo + 0, alto_documento, bf_bold, 10)
            write_left(cb, ": " & Form_menu_principal.dtp_fecha.Text, margen_izquierdo + 60, alto_documento, bf, 10)

            alto_documento = alto_documento - 15
            write_left(cb, "VENDEDOR", margen_izquierdo + 0, alto_documento, bf_bold, 10)
            write_left(cb, ": " & minombre, margen_izquierdo + 60, alto_documento, bf, 10)

            alto_documento = alto_documento - 15
            write_left(cb, "TELEFONO", margen_izquierdo + 0, alto_documento, bf_bold, 10)
            write_left(cb, ": " & mitelefono, margen_izquierdo + 60, alto_documento, bf, 10)

            alto_documento = alto_documento - 15
            write_left(cb, "CONDICION", margen_izquierdo + 0, alto_documento, bf_bold, 10)
            write_left(cb, ": " & Form_venta.combo_condiciones.Text, margen_izquierdo + 60, alto_documento, bf, 10)
            '********************************************************************


            alto_documento = alto_documento - 20

            write_left(cb, "__________________________________________", margen_izquierdo + 0, alto_documento, bf, 10)

            alto_documento = alto_documento - 15
            write_left(cb, "CODIGO", margen_izquierdo + 0, alto_documento, bf_bold, 9)
            write_left(cb, "DESCRIPCION", margen_izquierdo + 50, alto_documento, bf_bold, 9)
            write_right(cb, "CANT.", margen_izquierdo + 180, alto_documento, bf_bold, 9)
            write_right(cb, "TOTAL", margen_izquierdo + 230, alto_documento, bf_bold, 9)

            alto_documento = alto_documento - 5
            write_left(cb, "__________________________________________", margen_izquierdo + 0, alto_documento, bf, 10)

            Dim codigo As String
            Dim nombre As String
            Dim nro_tecnico As String
            Dim precio As String
            Dim cantidad As String
            Dim neto_detalle As String
            Dim iva_detalle As String
            Dim subtotal_detalle As String
            Dim porcentaje_desc As String
            Dim descuento_detalle As String
            Dim total_detalle As String

            alto_documento = alto_documento - 10

            For i = 0 To Form_venta.grilla_detalle_venta.Rows.Count - 1

                codigo = Form_venta.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                nombre = Form_venta.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                nro_tecnico = Form_venta.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                precio = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                cantidad = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                neto_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                iva_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                subtotal_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                porcentaje_desc = Form_venta.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                descuento_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                total_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                If nombre.Length > 33 Then
                    nombre = nombre.Substring(0, 33)
                End If

                If nro_tecnico.Length > 33 Then
                    nro_tecnico = nro_tecnico.Substring(0, 33)
                End If


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

                alto_documento = alto_documento - 10

                write_left(cb, codigo, margen_izquierdo + 0, alto_documento, bf, 9)
                write_left(cb, nombre, margen_izquierdo + 50, alto_documento, bf, 9)

                alto_documento = alto_documento - 10

                write_left(cb, nro_tecnico, margen_izquierdo + 50, alto_documento, bf, 9)

                alto_documento = alto_documento - 10

                write_right(cb, cantidad & " X " & precio, margen_izquierdo + 180, alto_documento, bf, 9)
                write_right(cb, total_detalle, margen_izquierdo + 230, alto_documento, bf, 9)

                alto_documento = alto_documento - 5

                write_left(cb, "__________________________________________", margen_izquierdo + 0, alto_documento, bf, 10)

                alto_documento = alto_documento - 5



            Next

            alto_documento = alto_documento + 5

            'alto_documento = alto_documento - 10
            'write_left(cb, "__________________________________________", margen_izquierdo + 0, alto_documento, bf, 10)


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

                alto_documento = alto_documento - 30
                write_left(cb, "SUBTOTAL", margen_izquierdo + 70, alto_documento, bf_bold, 10)
                write_left(cb, ":", margen_izquierdo + 140, alto_documento, bf, 10)
                write_right(cb, subtotal, margen_izquierdo + 230, alto_documento, bf, 10)

                alto_documento = alto_documento - 10
                write_left(cb, "DESCUENTO", margen_izquierdo + 70, alto_documento, bf_bold, 10)
                write_left(cb, ":", margen_izquierdo + 140, alto_documento, bf, 10)
                write_right(cb, descuento, margen_izquierdo + 230, alto_documento, bf, 10)

                alto_documento = alto_documento - 10
                write_left(cb, "NETO", margen_izquierdo + 70, alto_documento, bf_bold, 10)
                write_left(cb, ":", margen_izquierdo + 140, alto_documento, bf, 10)
                write_right(cb, neto, margen_izquierdo + 230, alto_documento, bf, 10)

                alto_documento = alto_documento - 10
                write_left(cb, "IVA", margen_izquierdo + 70, alto_documento, bf_bold, 10)
                write_left(cb, ":", margen_izquierdo + 140, alto_documento, bf, 10)
                write_right(cb, iva, margen_izquierdo + 230, alto_documento, bf, 10)

                alto_documento = alto_documento - 10
                write_left(cb, "TOTAL", margen_izquierdo + 70, alto_documento, bf_bold, 10)
                write_left(cb, ":", margen_izquierdo + 140, alto_documento, bf_bold, 10)
                write_right(cb, total, margen_izquierdo + 230, alto_documento, bf_bold, 10)

            Else

                'alto_documento = alto_documento - 30
                'write_left(cb, "NETO", margen_izquierdo + 70, alto_documento, bf_bold, 10)
                'write_left(cb, ":", margen_izquierdo + 140, alto_documento, bf, 10)
                'write_right(cb, neto, margen_izquierdo + 230, alto_documento, bf, 10)

                'alto_documento = alto_documento - 10
                'write_left(cb, "IVA", margen_izquierdo + 70, alto_documento, bf_bold, 10)
                'write_left(cb, ":", margen_izquierdo + 140, alto_documento, bf, 10)
                'write_right(cb, iva, margen_izquierdo + 230, alto_documento, bf, 10)

                alto_documento = alto_documento - 30
                write_left(cb, "TOTAL", margen_izquierdo + 95, alto_documento, bf_bold, 10)
                write_left(cb, ":", margen_izquierdo + 140, alto_documento, bf_bold, 10)
                write_right(cb, total, margen_izquierdo + 230, alto_documento, bf_bold, 10)

                'alto_documento = alto_documento - 10
                'write_left(cb, "TOTAL", margen_izquierdo + 70, alto_documento, bf_bold, 10)
                'write_left(cb, ":", margen_izquierdo + 140, alto_documento, bf, 10)
                'write_right(cb, total, margen_izquierdo + 230, alto_documento, bf, 10)

                alto_documento = alto_documento - 30
                write_right(cb, "DESCUENTOS YA APLICADOS", margen_izquierdo + 230, alto_documento, bf, 10)

                alto_documento = alto_documento - 10
                write_right(cb, "VALORES INCLUYEN IVA", margen_izquierdo + 230, alto_documento, bf, 10)

                alto_documento = alto_documento - 30
                write_right(cb, "COTIZACION VALIDA POR " & validez_cotizacion, margen_izquierdo + 230, alto_documento, bf, 10)

                alto_documento = alto_documento - 10
                write_right(cb, "DIAS A PARTIR DE LA FECHA DE EMISION", margen_izquierdo + 230, alto_documento, bf, 10)

            End If

            cb.EndText()
            document.Close()


            ' Process.Start(ruta)

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
End Class