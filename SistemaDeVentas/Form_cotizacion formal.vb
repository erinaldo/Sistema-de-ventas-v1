Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Form_cotizacion_formal
    Dim desglose_total_cotizacion As String
    Dim peso As String
    Dim btn_impresion As String
    Dim numero_lineas_total As Integer = 0
    'Dim impreso As Integer = 0

    Private Sub Form_cotizacion_formal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_cotizacion_formal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cotizacion_formal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
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
        'dt.Columns.Add(New DataColumn("fecha", GetType(String)))

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

        'If impreso = 0 Then
        '    Dim mPrintBitMap As Bitmap = Form_menu_principal.PictureBox_reporte.Image
        '    mPrintBitMap.RotateFlip(RotateFlipType.Rotate180FlipNone)
        '    ' Copy the form image into a bitmap.    
        '    mPrintBitMap = New Bitmap(Form_menu_principal.PictureBox_reporte.Width, Form_menu_principal.PictureBox_reporte.Height)
        '    Dim lRect As System.Drawing.Rectangle
        '    lRect.Width = Form_menu_principal.PictureBox_reporte.Width
        '    lRect.Height = Form_menu_principal.PictureBox_reporte.Height
        '    Me.DrawToBitmap(mPrintBitMap, lRect)
        'End If

        'Try
        '    E.Graphics.DrawImage(Form_menu_principal.PictureBox_reporte.Image, 1060, 80, -260, -70)
        'Catch
        'End Try

        'dr("nombre_empresa") = minombreempresa
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
        '    dr("fecha") = UCase(Form_menu_principal.lbl_fecha.Text)

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









    Private Function ReturnDataSet_Neto() As DataSet
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
        'dt.Columns.Add(New DataColumn("fecha", GetType(String)))

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
        'Dim porcentaje_desc_total As String

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
        'porcentaje_desc_total = grilla_documento.CurrentRow.Cells(13).Value

        'txt_neto.Text = 0

        'txt_subtotal_neto.Text = 0
        'txt_descuento.Text = 0
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

        '    Dim neto_valor As Integer
        '    Dim iva_valor As String

        '    iva_valor = valor_iva / 100 + 1

        '    neto_valor = (precio / iva_valor)
        '    Round(neto_valor)
        '    precio = neto_valor
        '    subtotal_detalle = precio * cantidad

        '    Dim descuento_porcentaje As Integer

        '    descuento_porcentaje = ((subtotal_detalle) * porcentaje_desc) / 100
        '    descuento_detalle = descuento_porcentaje
        '    total_detalle = Int(subtotal_detalle) - Int(descuento_porcentaje)
        '    '  txt_neto.Text = Val(txt_neto.Text) + Val(total_detalle)
        '    txt_subtotal_neto.Text = Val(txt_subtotal_neto.Text) + Val(total_detalle)
        '    '  txt_descuento.Text = Val(txt_neto.Text) + Val(total_detalle)
        '    txt_descuento.Text = 0
        '    txt_descuento.Text = Int(((txt_subtotal_neto.Text) * porcentaje_desc_total) / 100)
        '    txt_neto.Text = 0
        '    txt_neto.Text = Val(txt_subtotal_neto.Text) - Val(txt_descuento.Text)

        '    dr = dt.NewRow()

        '    'Try
        '    '    dr("Imagen") = Imagen_reporte
        '    'Catch
        '    'End Try

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
        '    dr("subtotal") = txt_subtotal_neto.Text
        '    dr("descuento") = txt_descuento.Text
        '    dr("neto") = neto
        '    dr("iva") = iva
        '    ' dr("total") = total
        '    dr("total") = txt_neto.Text
        '    dr("fecha") = UCase(Form_menu_principal.lbl_fecha.Text)

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

        If btn_impresion = "TOTAL" Then
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

        If btn_impresion = "NETO" Then
            Dim neto As String
            neto = grilla_documento.CurrentRow.Cells(10).Value

            peso = " PESOS"
            If CInt(neto) = 1000000 Then
                desglose_total_cotizacion = Num2Text(neto) & " DE PESOS"
            ElseIf CInt(neto) = 2000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 3000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 4000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 5000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 6000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 7000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 8000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 9000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 10000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 11000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 12000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 13000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 14000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 15000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 16000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 17000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 18000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 19000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 20000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 21000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 22000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 23000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 24000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 25000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 26000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 27000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 28000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 29000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            ElseIf CInt(neto) = 30000000 Then
                desglose_total_cotizacion = Num2Text(neto) & "DE PESOS"
            Else
                desglose_total_cotizacion = Num2Text(neto) & peso
            End If
        End If
    End Sub

    Sub mostrar_malla_detalle()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As Integer
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

                VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                VarPorcentaje = 100 - VarPorcentaje
                VarDescuento = VarPrecioReal - VarValorUnitario
                VarValorUnitario = VarPrecioReal
                iva_valor = valor_iva / 100 + 1
                VarNeto = (VarTotal / iva_valor)
                VarIva = (VarNeto) * valor_iva / 100

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


    Public Function ImageToByte(ByVal pImagen As Image) As Byte()
        'Dim mImage() As Byte
        'Try
        '    If Not IsNothing(pImagen) Then
        '        Dim ms As New System.IO.MemoryStream
        '        pImagen.Save(ms, pImagen.RawFormat)
        '        mImage = ms.GetBuffer
        '        ms.Close()
        '        Return mImage
        '    Else
        '        Return Nothing
        '    End If
        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return Nothing
    End Function






















    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click

        If txt_nro_cotizacion.Text = "" Then
            MsgBox("CAMPO NRO DE COTIZACION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_cotizacion.Focus()
            Exit Sub
        End If

        conexion.Close()
        Consultas_SQL("select * from cotizacion where n_cotizacion = '" & (txt_nro_cotizacion.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count = 0 Then
            MsgBox("NUMERO DE COTIZACION NO EXISTE", 0 + 16, "ATENCION")
            txt_nro_cotizacion.Focus()
            Exit Sub
        End If





        Me.Enabled = False
        grilla_documento.Rows.Clear()
        grilla_detalle_documento.Rows.Clear()

        'btn_impresion = "TOTAL"

        mostrar_malla()
        mostrar_malla_detalle()

        crear_pdf()


        'PrintDialog1.Document = PrintDocument1

        'If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    PrintDocument1.DefaultPageSettings.Landscape = False
        '    PrintDocument1.Print()

        '    Try
        '        PrintDocument1.DefaultPageSettings.Landscape = False
        '        PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
        '        PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
        '    Catch
        '    End Try
        'End If

        Me.Enabled = True

    End Sub



    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        txt_nro_cotizacion.Text = ""
        txt_nro_cotizacion.Focus()
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub


    Private Sub btn_imprimir_neto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir_neto.GotFocus
        btn_imprimir_neto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_neto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir_neto.LostFocus
        btn_imprimir_neto.BackColor = Color.Transparent
    End Sub



    Private Sub txt_nro_cotizacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_cotizacion.GotFocus
        txt_nro_cotizacion.BackColor = Color.LightSkyBlue
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



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If txt_nro_cotizacion.Text <> "" Then
                '  btn_grabar.Focus()
                btn_grabar.PerformClick()
            End If
        End If
    End Sub

    Private Sub txt_nro_cotizacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_cotizacion.LostFocus
        txt_nro_cotizacion.BackColor = Color.White
    End Sub

    Private Sub txt_nro_cotizacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_cotizacion.TextChanged

    End Sub




    Private Sub btn_imprimir_neto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir_neto.Click

        If txt_nro_cotizacion.Text = "" Then
            MsgBox("CAMPO NRO DE COTIZACION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_cotizacion.Focus()
            Exit Sub
        End If

        conexion.Close()
        Consultas_SQL("select * from cotizacion where n_cotizacion = '" & (txt_nro_cotizacion.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count = 0 Then
            MsgBox("NUMERO DE COTIZACION NO EXISTE", 0 + 16, "ATENCION")
            txt_nro_cotizacion.Focus()
            Exit Sub
        End If

        Me.Enabled = False
        grilla_documento.Rows.Clear()
        grilla_detalle_documento.Rows.Clear()

        btn_impresion = "NETO"

        mostrar_malla()
        mostrar_malla_detalle()

        PrintDialog1.Document = PrintDocument_neto

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument_neto.DefaultPageSettings.Landscape = False
            PrintDocument_neto.Print()

            Try
                PrintDocument_neto.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        'Try
        '    Dim iReporte As New Form_informe_cotizacion_personalizado
        '    Dim rpt As New Crystal_cotizacion_neto_personalizado

        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet_Neto)
        '    rpt.Refresh()

        '    iReporte.Reporte = rpt
        '    iReporte.ShowDialog()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        Me.Enabled = True

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        'format1.Alignment = StringAlignment.Far

        'Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        'Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        'Dim Font_titulo_columna As New Font("verdana", 8, FontStyle.Bold)
        'Dim Font_texto_impresion As New Font("verdana", 8, FontStyle.Regular)
        'Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        'Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        'Dim stringFormat As New StringFormat()
        'stringFormat.Alignment = StringAlignment.Center
        'stringFormat.LineAlignment = StringAlignment.Center

        'Dim margen_izquierdo As Integer
        'Dim margen_superior As Integer

        'margen_izquierdo = 0
        'margen_superior = 0

        'Try
        '    Dim imagen_reporte As Image
        '    imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
        '    Dim posicion_imagen As New PointF(margen_izquierdo + 530, margen_superior + 10)
        '    e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        'Catch
        'End Try

        'e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 10)
        'e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 20)
        'e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 30)
        'e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 40)
        'e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 50)
        'e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 60)

        'Dim rect1 As New Rectangle(margen_izquierdo + 20, margen_superior + 75, margen_izquierdo + 780, margen_superior + 55)
        'Dim rect2 As New Rectangle(margen_izquierdo + 20, margen_superior + 90, margen_izquierdo + 780, margen_superior + 70)

        'e.Graphics.DrawString("COTIZACION", Font_titulo, Brushes.Black, rect1, stringFormat)
        'e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 115, margen_izquierdo + 810, margen_superior + 115)
        'e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

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
        'Dim numero_lineas As Integer = 0
        'Dim multiplicador_lineas As Integer = 10

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


        'e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 140)
        'e.Graphics.DrawString("NOMBRE", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 155)
        'e.Graphics.DrawString("DIRECCION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 170)
        'e.Graphics.DrawString("COMUNA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 185)

        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 90, margen_superior + 140)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 90, margen_superior + 155)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 90, margen_superior + 170)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 90, margen_superior + 185)

        'e.Graphics.DrawString(rut_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 140)
        'e.Graphics.DrawString(nombre_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 155)
        'e.Graphics.DrawString(direccion_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 170)
        'e.Graphics.DrawString(comuna_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 185)

        'e.Graphics.DrawString("VENDEDOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 460, margen_superior + 140)
        'e.Graphics.DrawString("MOVIL VENDEDOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 460, margen_superior + 155)
        'e.Graphics.DrawString("COTIZACION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 460, margen_superior + 170)
        'e.Graphics.DrawString("FORMA DE PAGO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 460, margen_superior + 185)

        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 140)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 155)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 170)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 185)

        'e.Graphics.DrawString(vendedor, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 140)
        'e.Graphics.DrawString(movil_vendedor, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 155)
        'e.Graphics.DrawString(nro_cotizacion, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 170)
        'e.Graphics.DrawString(forma_de_pago, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 185)

        'e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 10, margen_superior + 220)
        'e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 80, margen_superior + 220)
        'e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 320, margen_superior + 220, format1)
        'e.Graphics.DrawString("PRECIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 420, margen_superior + 220, format1)
        'e.Graphics.DrawString("SUBTOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 520, margen_superior + 220, format1)
        'e.Graphics.DrawString("% DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 620, margen_superior + 220, format1)
        'e.Graphics.DrawString("DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 720, margen_superior + 220, format1)
        'e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 810, margen_superior + 220, format1)
        'e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 235, margen_izquierdo + 810, margen_superior + 235)

        'For i = numero_lineas_total To grilla_detalle_documento.Rows.Count - 1

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

        '    If precio = "" Or precio = "0" Then
        '        precio = "0"
        '    Else
        '        precio = Format(Int(precio), "###,###,###")
        '    End If

        '    If subtotal_detalle = "" Or subtotal_detalle = "0" Then
        '        subtotal_detalle = "0"
        '    Else
        '        subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '    End If

        '    If descuento_detalle = "" Or descuento_detalle = "0" Then
        '        descuento_detalle = "0"
        '    Else
        '        descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
        '    End If

        '    If total_detalle = "" Or total_detalle = "0" Then
        '        total_detalle = "0"
        '    Else
        '        total_detalle = Format(Int(total_detalle), "###,###,###")
        '    End If

        '    If nombre.Length > 20 Then
        '        nombre = nombre.Substring(0, 20)
        '    End If

        '    e.Graphics.DrawString(codigo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 10, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(nombre, Font_texto_impresion, Brushes.Black, margen_izquierdo + 80, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(cantidad, Font_texto_impresion, Brushes.Black, margen_izquierdo + 320, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(precio, Font_texto_impresion, Brushes.Black, margen_izquierdo + 420, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(subtotal_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 520, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(porcentaje_desc, Font_texto_impresion, Brushes.Black, margen_izquierdo + 620, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(descuento_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 720, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(total_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 810, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    numero_lineas = numero_lineas + 1
        '    numero_lineas_total = numero_lineas_total + 1

        '    If numero_lineas > 85 Then
        '        'Linea horizontal
        '        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 250 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 250 + (numero_lineas * multiplicador_lineas))
        '        '***************************************************************************************************************************************************
        '        e.HasMorePages = True ' Todavia faltan mas paginas
        '        Exit Sub
        '    Else
        '        e.HasMorePages = False
        '    End If
        'Next

        ''Linea horizontal
        'e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 250 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 250 + (numero_lineas * multiplicador_lineas))
        ''***************************************************************************************************************************************************

        'numero_lineas_total = 0

        'e.Graphics.DrawString("DESGLOSE:", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 270 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString(desglose_total_cotizacion, Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 285 + (numero_lineas * multiplicador_lineas))

        'e.Graphics.DrawString("SUBTOTAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 640, margen_superior + 270 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString("DESCUENTO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 640, margen_superior + 285 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString("NETO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 640, margen_superior + 300 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString("IVA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 640, margen_superior + 315 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString("TOTAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 640, margen_superior + 330 + (numero_lineas * multiplicador_lineas))

        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 720, margen_superior + 270 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 720, margen_superior + 285 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 720, margen_superior + 300 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 720, margen_superior + 315 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 720, margen_superior + 330 + (numero_lineas * multiplicador_lineas))

        'If subtotal = "" Or subtotal = "0" Then
        '    subtotal = "0"
        'Else
        '    subtotal = Format(Int(subtotal), "###,###,###")
        'End If

        'If descuento = "" Or descuento = "0" Then
        '    descuento = "0"
        'Else
        '    descuento = Format(Int(descuento), "###,###,###")
        'End If

        'If neto = "" Or neto = "0" Then
        '    neto = "0"
        'Else
        '    neto = Format(Int(neto), "###,###,###")
        'End If

        'If iva = "" Or iva = "0" Then
        '    iva = "0"
        'Else
        '    iva = Format(Int(iva), "###,###,###")
        'End If

        'If total = "" Or total = "0" Then
        '    total = "0"
        'Else
        '    total = Format(Int(total), "###,###,###")
        'End If

        'e.Graphics.DrawString(subtotal, Font_campos_superiores, Brushes.Black, margen_izquierdo + 810, margen_superior + 270 + (numero_lineas * multiplicador_lineas), format1)
        'e.Graphics.DrawString(descuento, Font_campos_superiores, Brushes.Black, margen_izquierdo + 810, margen_superior + 285 + (numero_lineas * multiplicador_lineas), format1)
        'e.Graphics.DrawString(neto, Font_campos_superiores, Brushes.Black, margen_izquierdo + 810, margen_superior + 300 + (numero_lineas * multiplicador_lineas), format1)
        'e.Graphics.DrawString(iva, Font_campos_superiores, Brushes.Black, margen_izquierdo + 810, margen_superior + 315 + (numero_lineas * multiplicador_lineas), format1)
        'e.Graphics.DrawString(total, Font_campos_superiores, Brushes.Black, margen_izquierdo + 810, margen_superior + 330 + (numero_lineas * multiplicador_lineas), format1)
    End Sub

    Private Sub PrintDocument_neto_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument_neto.PrintPage
        'Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        'format1.Alignment = StringAlignment.Far

        'Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        'Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        'Dim Font_titulo_columna As New Font("verdana", 8, FontStyle.Bold)
        'Dim Font_texto_impresion As New Font("verdana", 8, FontStyle.Regular)
        'Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        'Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        'Dim stringFormat As New StringFormat()
        'stringFormat.Alignment = StringAlignment.Center
        'stringFormat.LineAlignment = StringAlignment.Center

        'Dim margen_izquierdo As Integer
        'Dim margen_superior As Integer

        'margen_izquierdo = 0
        'margen_superior = 0

        'Try
        '    Dim imagen_reporte As Image
        '    imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
        '    Dim posicion_imagen As New PointF(margen_izquierdo + 530, margen_superior + 10)
        '    e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        'Catch
        'End Try

        'e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 10)
        'e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 20)
        'e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 30)
        'e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 40)
        'e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 50)
        'e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 60)

        'Dim rect1 As New Rectangle(margen_izquierdo + 20, margen_superior + 75, margen_izquierdo + 780, margen_superior + 55)
        'Dim rect2 As New Rectangle(margen_izquierdo + 20, margen_superior + 90, margen_izquierdo + 780, margen_superior + 70)

        'e.Graphics.DrawString("COTIZACION", Font_titulo, Brushes.Black, rect1, stringFormat)
        'e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 115, margen_izquierdo + 810, margen_superior + 115)
        'e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

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
        'Dim porcentaje_desc_total As String

        'Dim numero_lineas As Integer = 0
        'Dim multiplicador_lineas As Integer = 10

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
        'porcentaje_desc_total = grilla_documento.CurrentRow.Cells(13).Value

        'e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 140)
        'e.Graphics.DrawString("NOMBRE", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 155)
        'e.Graphics.DrawString("DIRECCION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 170)
        'e.Graphics.DrawString("COMUNA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 185)

        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 90, margen_superior + 140)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 90, margen_superior + 155)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 90, margen_superior + 170)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 90, margen_superior + 185)

        'e.Graphics.DrawString(rut_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 140)
        'e.Graphics.DrawString(nombre_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 155)
        'e.Graphics.DrawString(direccion_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 170)
        'e.Graphics.DrawString(comuna_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 185)

        'e.Graphics.DrawString("VENDEDOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 460, margen_superior + 140)
        'e.Graphics.DrawString("MOVIL VENDEDOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 460, margen_superior + 155)
        'e.Graphics.DrawString("COTIZACION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 460, margen_superior + 170)
        'e.Graphics.DrawString("FORMA DE PAGO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 460, margen_superior + 185)

        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 140)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 155)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 170)
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 185)

        'e.Graphics.DrawString(vendedor, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 140)
        'e.Graphics.DrawString(movil_vendedor, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 155)
        'e.Graphics.DrawString(nro_cotizacion, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 170)
        'e.Graphics.DrawString(forma_de_pago, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 185)

        'e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 10, margen_superior + 220)
        'e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 80, margen_superior + 220)
        'e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 320, margen_superior + 220, format1)
        'e.Graphics.DrawString("PRECIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 420, margen_superior + 220, format1)
        'e.Graphics.DrawString("SUBTOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 520, margen_superior + 220, format1)
        'e.Graphics.DrawString("% DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 620, margen_superior + 220, format1)
        'e.Graphics.DrawString("DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 720, margen_superior + 220, format1)
        'e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 810, margen_superior + 220, format1)
        'e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 235, margen_izquierdo + 810, margen_superior + 235)

        'For i = numero_lineas_total To grilla_detalle_documento.Rows.Count - 1
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




        '    Dim neto_valor As Integer
        '    Dim iva_valor As String

        '    iva_valor = valor_iva / 100 + 1

        '    neto_valor = (precio / iva_valor)
        '    Round(neto_valor)
        '    precio = neto_valor
        '    subtotal_detalle = precio * cantidad

        '    Dim descuento_porcentaje As Integer

        '    descuento_porcentaje = ((subtotal_detalle) * porcentaje_desc) / 100
        '    descuento_detalle = descuento_porcentaje
        '    total_detalle = Int(subtotal_detalle) - Int(descuento_porcentaje)
        '    txt_subtotal_neto.Text = Val(txt_subtotal_neto.Text) + Val(total_detalle)
        '    txt_descuento.Text = 0
        '    txt_descuento.Text = Int(((txt_subtotal_neto.Text) * porcentaje_desc_total) / 100)
        '    txt_neto.Text = 0
        '    txt_neto.Text = Val(txt_subtotal_neto.Text) - Val(txt_descuento.Text)

        '    If precio = "" Or precio = "0" Then
        '        precio = "0"
        '    Else
        '        precio = Format(Int(precio), "###,###,###")
        '    End If

        '    If subtotal_detalle = "" Or subtotal_detalle = "0" Then
        '        subtotal_detalle = "0"
        '    Else
        '        subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '    End If

        '    If descuento_detalle = "" Or descuento_detalle = "0" Then
        '        descuento_detalle = "0"
        '    Else
        '        descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
        '    End If

        '    If total_detalle = "" Or total_detalle = "0" Then
        '        total_detalle = "0"
        '    Else
        '        total_detalle = Format(Int(total_detalle), "###,###,###")
        '    End If

        '    If nombre.Length > 20 Then
        '        nombre = nombre.Substring(0, 20)
        '    End If

        '    e.Graphics.DrawString(codigo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 10, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(nombre, Font_texto_impresion, Brushes.Black, margen_izquierdo + 80, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(cantidad, Font_texto_impresion, Brushes.Black, margen_izquierdo + 320, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(precio, Font_texto_impresion, Brushes.Black, margen_izquierdo + 420, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(subtotal_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 520, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(porcentaje_desc, Font_texto_impresion, Brushes.Black, margen_izquierdo + 620, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(descuento_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 720, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    e.Graphics.DrawString(total_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 810, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        '    '***************************************************************************************************************************************************

        '    numero_lineas = numero_lineas + 1
        '    numero_lineas_total = numero_lineas_total + 1

        '    If numero_lineas > 85 Then
        '        'Linea horizontal
        '        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 250 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 250 + (numero_lineas * multiplicador_lineas))
        '        '***************************************************************************************************************************************************
        '        e.HasMorePages = True ' Todavia faltan mas paginas
        '        Exit Sub
        '    Else
        '        e.HasMorePages = False
        '    End If
        'Next

        ''Linea horizontal
        'e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 250 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 250 + (numero_lineas * multiplicador_lineas))
        ''***************************************************************************************************************************************************

        'numero_lineas_total = 0
        'e.Graphics.DrawString("LOS PRECIOS INDICADOS CORRESPONDEN A VALORES NETOS.", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 270 + (numero_lineas * multiplicador_lineas))

        'e.Graphics.DrawString("DESGLOSE:", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 300 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString(desglose_total_cotizacion, Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 315 + (numero_lineas * multiplicador_lineas))


        'e.Graphics.DrawString("VALORES NETOS", Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 270 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString("SUBTOTAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 300 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString("DESCUENTO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 315 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString("TOTAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 330 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 720, margen_superior + 300 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 720, margen_superior + 315 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 720, margen_superior + 330 + (numero_lineas * multiplicador_lineas))

        'If subtotal = "" Or subtotal = "0" Then
        '    subtotal = "0"
        'Else
        '    subtotal = Format(Int(subtotal), "###,###,###")
        'End If

        'If descuento = "" Or descuento = "0" Then
        '    descuento = "0"
        'Else
        '    descuento = Format(Int(descuento), "###,###,###")
        'End If

        'If neto = "" Or neto = "0" Then
        '    neto = "0"
        'Else
        '    neto = Format(Int(neto), "###,###,###")
        'End If

        'If iva = "" Or iva = "0" Then
        '    iva = "0"
        'Else
        '    iva = Format(Int(iva), "###,###,###")
        'End If

        'If total = "" Or total = "0" Then
        '    total = "0"
        'Else
        '    total = Format(Int(total), "###,###,###")
        'End If

        'subtotal = txt_subtotal_neto.Text
        'descuento = txt_descuento.Text
        'neto = neto

        'If subtotal = "" Or subtotal = "0" Then
        '    subtotal = "0"
        'Else
        '    subtotal = Format(Int(subtotal), "###,###,###")
        'End If

        'If descuento = "" Or descuento = "0" Then
        '    descuento = "0"
        'Else
        '    descuento = Format(Int(descuento), "###,###,###")
        'End If

        'If neto = "" Or neto = "0" Then
        '    neto = "0"
        'Else
        '    neto = Format(Int(neto), "###,###,###")
        'End If
        'e.Graphics.DrawString(subtotal, Font_campos_superiores, Brushes.Black, margen_izquierdo + 810, margen_superior + 300 + (numero_lineas * multiplicador_lineas), format1)
        'e.Graphics.DrawString(descuento, Font_campos_superiores, Brushes.Black, margen_izquierdo + 810, margen_superior + 315 + (numero_lineas * multiplicador_lineas), format1)
        'e.Graphics.DrawString(neto, Font_campos_superiores, Brushes.Black, margen_izquierdo + 810, margen_superior + 330 + (numero_lineas * multiplicador_lineas), format1)
    End Sub


    Sub crear_pdf()

        Dim savefiledialog As New SaveFileDialog
        Dim ruta As String
        With savefiledialog
            .Title = "GUARDAR"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Filter = "Archivos Adobe PDF (*.pdf)|*.pdf"
            .FileName = "COTIZACION NRO. " & txt_nro_cotizacion.Text & ".pdf"
            .OverwritePrompt = True
            .CheckPathExists = True
        End With

        If savefiledialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ruta = savefiledialog.FileName
        Else
            ruta = String.Empty
            Exit Sub
        End If




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
                write_right(cb, precio, margen_izquierdo + 360, margen_superior + 580 - (numero_lineas * multiplicador_lineas), bf, 10)
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
End Class