Imports System.IO
Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Form_cotizacion_formal
    Dim desglose_total_cotizacion As String
    Dim peso As String
    Dim btn_impresion As String
    Dim numero_lineas_total As Integer = 0

    Private Sub Form_cotizacion_formal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
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
            form_Ingreso.Show()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_cotizacion_formal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
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
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))

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
            dr("fecha") = UCase(Form_menu_principal.lbl_fecha.Text)

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









    Private Function ReturnDataSet_Neto() As DataSet
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
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))

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
        Dim porcentaje_desc_total As String

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
        porcentaje_desc_total = grilla_documento.CurrentRow.Cells(13).Value

        txt_neto.Text = 0

        txt_subtotal_neto.Text = 0
        txt_descuento.Text = 0
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

            Dim neto_valor As Integer
            Dim iva_valor As String

            iva_valor = valor_iva / 100 + 1

            neto_valor = (precio / iva_valor)
            Round(neto_valor)
            precio = neto_valor
            subtotal_detalle = precio * cantidad

            Dim descuento_porcentaje As Integer

            descuento_porcentaje = ((subtotal_detalle) * porcentaje_desc) / 100
            descuento_detalle = descuento_porcentaje
            total_detalle = Int(subtotal_detalle) - Int(descuento_porcentaje)
            '  txt_neto.Text = Val(txt_neto.Text) + Val(total_detalle)
            txt_subtotal_neto.Text = Val(txt_subtotal_neto.Text) + Val(total_detalle)
            '  txt_descuento.Text = Val(txt_neto.Text) + Val(total_detalle)
            txt_descuento.Text = 0
            txt_descuento.Text = Int(((txt_subtotal_neto.Text) * porcentaje_desc_total) / 100)
            txt_neto.Text = 0
            txt_neto.Text = Val(txt_subtotal_neto.Text) - Val(txt_descuento.Text)

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
            dr("subtotal") = txt_subtotal_neto.Text
            dr("descuento") = txt_descuento.Text
            dr("neto") = neto
            dr("iva") = iva
            ' dr("total") = total
            dr("total") = txt_neto.Text
            dr("fecha") = UCase(Form_menu_principal.lbl_fecha.Text)

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
        SC.CommandText = "select * from cotizacion, usuarios, clientes where n_cotizacion= '" & (txt_nro_cotizacion.Text) & "' and cotizacion.usuario_responsable=usuarios.rut_usuario and cotizacion.codigo_cliente=clientes.cod_cliente"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_documento.Rows.Clear()
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
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
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"))
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

        btn_impresion = "TOTAL"

        mostrar_malla()
        mostrar_malla_detalle()

        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = False
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        'Try
        '    Dim iReporte As New Form_informe_cotizacion_personalizado
        '    Dim rpt As New Crystal_cotizacion_personalizado

        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()

        '    iReporte.Reporte = rpt
        '    iReporte.ShowDialog()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        Me.Enabled = True



        'Me.Enabled = False
        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()

        'DS.Clear()
        'conexion.Open()
        'SC.Connection = conexion

        'SC.CommandText = "select  empresa.rut_empresa, empresa.correo_empresa, empresa.nombre_empresa, empresa.direccion_empresa, empresa.telefono_empresa, empresa.giro_empresa, empresa.comuna_empresa, empresa.recinto_empresa, clientes.nombre_cliente, clientes.direccion_cliente, clientes.rut_cliente, clientes.comuna_cliente, cotizacion.condiciones, cotizacion.usuario_responsable, cotizacion.fecha_venta, cotizacion.descuento,cotizacion.neto, cotizacion.iva,  cotizacion.subtotal, cotizacion.total, cotizacion.desglose, cotizacion.n_cotizacion,  usuarios.telefono_usuario, usuarios.nombre_usuario, detalle_cotizacion.cod_producto, detalle_cotizacion.detalle_nombre, detalle_cotizacion.numero_tecnico, detalle_cotizacion.valor_unitario, detalle_cotizacion.cantidad,  detalle_cotizacion.porcentaje_desc, detalle_cotizacion.detalle_subtotal,detalle_cotizacion.detalle_descuento, detalle_cotizacion.detalle_total from clientes, empresa, cotizacion, usuarios, detalle_cotizacion where clientes.cod_cliente=cotizacion.codigo_cliente and cotizacion.usuario_responsable=usuarios.rut_usuario and cotizacion.n_cotizacion=detalle_cotizacion.n_cotizacion and cotizacion.n_cotizacion='" & (txt_nro_cotizacion.Text) & "'"

        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'conexion.Close()

        'Dim rpt As New Crystal_cotizacion

        'rpt.SetDataSource(DS.Tables(DT.TableName))
        'Form_informe_cotizacion.rpt_cotizacion.ReportSource = rpt
        'Form_informe_cotizacion.Show()

        'conexion.Close()
        'Me.Enabled = True


        ''Dim rpt As New Crystal_cotizacion
        ''rpt.SetDataSource(DS.Tables(DT.TableName))
        ''Form_informe_cotizacion.rpt_cotizacion.ReportSource = rpt
        ''rpt.PrintOptions.PrinterName = "\\cuentas\HP Deskjet 1000 J110 series"
        ''rpt.DiskFileName = "c:\crystalExport.pdf"
        ''rpt.PrintToPrinter(1, False, 0, 0)
        ''conexion.Close()
        ''MsgBox("Se ha impreso correctamente", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Info")
        'Try

        '    Dim CrExportOptions As ExportOptions

        '    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()

        '    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

        '    CrDiskFileDestinationOptions.DiskFileName = "C:\Cotizaciones\" & "Cotizacion nro. " & txt_nro_cotizacion.Text & ".pdf"

        '    CrExportOptions = rpt.ExportOptions

        '    With CrExportOptions

        '        .ExportDestinationType = ExportDestinationType.DiskFile

        '        .ExportFormatType = ExportFormatType.PortableDocFormat

        '        .DestinationOptions = CrDiskFileDestinationOptions

        '        .FormatOptions = CrFormatTypeOptions

        '    End With

        '    rpt.Export()

        'Catch ex As Exception

        '    MsgBox(ex.ToString)

        'End Try





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

        PrintDialog1.Document = PrintDocument1

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
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 8, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = -30
        margen_superior = 0

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), 560, 10, 260, 70)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 65, margen_izquierdo + 810, margen_superior + 55)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 80, margen_izquierdo + 810, margen_superior + 70)

        e.Graphics.DrawString("COTIZACION", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 105, margen_izquierdo + 865, margen_superior + 105)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        'If txt_nombre_cliente.Text.Length > 23 Then
        '    txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 23)
        'End If

       

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
        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10
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


        e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 130)
        e.Graphics.DrawString("NOMBRE", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 145)
        e.Graphics.DrawString("DIRECCION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 160)
        e.Graphics.DrawString("COMUNA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 175)

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 130)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 145)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 160)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 175)
       
        e.Graphics.DrawString(rut_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 140, margen_superior + 130)
        e.Graphics.DrawString(nombre_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 140, margen_superior + 145)
        e.Graphics.DrawString(direccion_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 140, margen_superior + 160)
        e.Graphics.DrawString(comuna_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 140, margen_superior + 175)
        
        e.Graphics.DrawString("VENDEDOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 130)
        e.Graphics.DrawString("MOVIL VENDEDOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 145)
        e.Graphics.DrawString("COTIZACION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 160)
        e.Graphics.DrawString("FORMA DE PAGO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 175)

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 130)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 145)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 160)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 175)

        e.Graphics.DrawString(vendedor, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 130)
        e.Graphics.DrawString(movil_vendedor, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 145)
        e.Graphics.DrawString(nro_cotizacion, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 160)
        e.Graphics.DrawString(forma_de_pago, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 175)

        e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 210)
        e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 120, margen_superior + 210)
        e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 360, margen_superior + 210, format1)
        e.Graphics.DrawString("PRECIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 460, margen_superior + 210, format1)
        e.Graphics.DrawString("SUBTOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 560, margen_superior + 210, format1)
        e.Graphics.DrawString("% DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 660, margen_superior + 210, format1)
        e.Graphics.DrawString("DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 760, margen_superior + 210, format1)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 860, margen_superior + 210, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 225, margen_izquierdo + 865, margen_superior + 225)

        For i = numero_lineas_total To grilla_detalle_documento.Rows.Count - 1

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

            If nombre.Length > 20 Then
                nombre = nombre.Substring(0, 20)
            End If

            e.Graphics.DrawString(codigo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(nombre, Font_texto_impresion, Brushes.Black, margen_izquierdo + 120, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(cantidad, Font_texto_impresion, Brushes.Black, margen_izquierdo + 360, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(precio, Font_texto_impresion, Brushes.Black, margen_izquierdo + 460, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(subtotal_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 560, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(porcentaje_desc, Font_texto_impresion, Brushes.Black, margen_izquierdo + 660, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(descuento_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 760, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(total_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 860, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 85 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 240 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 240 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0

        e.Graphics.DrawString("DESGLOSE:", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 260 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(desglose_total_cotizacion, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 275 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString("SUBTOTAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 260 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("DESCUENTO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 275 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("NETO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 290 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("IVA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 305 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("TOTAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 320 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 260 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 275 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 290 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 305 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 320 + (numero_lineas * multiplicador_lineas))

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

        e.Graphics.DrawString(subtotal, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 260 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(descuento, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 275 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(neto, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 290 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(iva, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 305 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(total, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 320 + (numero_lineas * multiplicador_lineas), format1)
    End Sub

    Private Sub PrintDocument_neto_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument_neto.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 8, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = -30
        margen_superior = 0

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), 560, 10, 260, 70)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 65, margen_izquierdo + 810, margen_superior + 55)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 80, margen_izquierdo + 810, margen_superior + 70)

        e.Graphics.DrawString("COTIZACION", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 105, margen_izquierdo + 865, margen_superior + 105)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        'If txt_nombre_cliente.Text.Length > 23 Then
        '    txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 23)
        'End If

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
        Dim porcentaje_desc_total As String

        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10

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
        porcentaje_desc_total = grilla_documento.CurrentRow.Cells(13).Value

        e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 130)
        e.Graphics.DrawString("NOMBRE", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 145)
        e.Graphics.DrawString("DIRECCION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 160)
        e.Graphics.DrawString("COMUNA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 175)

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 130)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 145)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 160)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 175)

        e.Graphics.DrawString(rut_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 140, margen_superior + 130)
        e.Graphics.DrawString(nombre_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 140, margen_superior + 145)
        e.Graphics.DrawString(direccion_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 140, margen_superior + 160)
        e.Graphics.DrawString(comuna_cliente, Font_campos_superiores, Brushes.Black, margen_izquierdo + 140, margen_superior + 175)

        e.Graphics.DrawString("VENDEDOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 130)
        e.Graphics.DrawString("MOVIL VENDEDOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 145)
        e.Graphics.DrawString("COTIZACION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 160)
        e.Graphics.DrawString("FORMA DE PAGO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 175)

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 130)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 145)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 160)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 175)

        e.Graphics.DrawString(vendedor, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 130)
        e.Graphics.DrawString(movil_vendedor, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 145)
        e.Graphics.DrawString(nro_cotizacion, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 160)
        e.Graphics.DrawString(forma_de_pago, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 175)

        e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 210)
        e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 120, margen_superior + 210)
        e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 360, margen_superior + 210, format1)
        e.Graphics.DrawString("NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 460, margen_superior + 210, format1)
        e.Graphics.DrawString("SUBT. NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 560, margen_superior + 210, format1)
        e.Graphics.DrawString("% DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 660, margen_superior + 210, format1)
        e.Graphics.DrawString("DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 760, margen_superior + 210, format1)
        e.Graphics.DrawString("TOT. NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 860, margen_superior + 210, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 225, margen_izquierdo + 865, margen_superior + 225)

        For i = numero_lineas_total To grilla_detalle_documento.Rows.Count - 1
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




            Dim neto_valor As Integer
            Dim iva_valor As String

            iva_valor = valor_iva / 100 + 1

            neto_valor = (precio / iva_valor)
            Round(neto_valor)
            precio = neto_valor
            subtotal_detalle = precio * cantidad

            Dim descuento_porcentaje As Integer

            descuento_porcentaje = ((subtotal_detalle) * porcentaje_desc) / 100
            descuento_detalle = descuento_porcentaje
            total_detalle = Int(subtotal_detalle) - Int(descuento_porcentaje)
            '  txt_neto.Text = Val(txt_neto.Text) + Val(total_detalle)
            txt_subtotal_neto.Text = Val(txt_subtotal_neto.Text) + Val(total_detalle)
            '  txt_descuento.Text = Val(txt_neto.Text) + Val(total_detalle)
            txt_descuento.Text = 0
            txt_descuento.Text = Int(((txt_subtotal_neto.Text) * porcentaje_desc_total) / 100)
            txt_neto.Text = 0
            txt_neto.Text = Val(txt_subtotal_neto.Text) - Val(txt_descuento.Text)



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

            If nombre.Length > 20 Then
                nombre = nombre.Substring(0, 20)
            End If

            'dr("codigo") = codigo
            'dr("nombre") = nombre
            'dr("cantidad") = cantidad
            'dr("precio") = precio
            'dr("subtotal_detalle") = subtotal_detalle
            'dr("porcentaje_desc") = porcentaje_desc
            'dr("descuento_detalle") = descuento_detalle
            'dr("neto_detalle") = neto_detalle
            'dr("iva_detalle") = iva_detalle
            'dr("total_detalle") = total_detalle
            'dr("desglose_palabras") = desglose_total_cotizacion
            'dr("subtotal") = txt_subtotal_neto.Text
            'dr("descuento") = txt_descuento.Text
            'dr("neto") = neto
            'dr("iva") = iva
            'dr("total") = txt_neto.Text
            'dr("fecha") = UCase(Form_menu_principal.lbl_fecha.Text)
            'dr("nombre_empresa") = minombreempresa
            'dr("giro_empresa") = migiroempresa
            'dr("direccion_empresa") = midireccionempresa
            'dr("comuna_empresa") = micomunaempresa
            'dr("telefono_empresa") = mitelefonoempresa
            'dr("correo_empresa") = micorreoempresa
            'dr("rut_empresa") = mirutempresa


            'e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 210)
            'e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 120, margen_superior + 210)
            'e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 360, margen_superior + 210, format1)
            'e.Graphics.DrawString("NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 460, margen_superior + 210, format1)
            'e.Graphics.DrawString("SUBT. NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 560, margen_superior + 210, format1)
            'e.Graphics.DrawString("% DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 660, margen_superior + 210, format1)
            'e.Graphics.DrawString("DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 760, margen_superior + 210, format1)
            'e.Graphics.DrawString("TOT. NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 860, margen_superior + 210, format1)

            e.Graphics.DrawString(codigo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(nombre, Font_texto_impresion, Brushes.Black, margen_izquierdo + 120, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(cantidad, Font_texto_impresion, Brushes.Black, margen_izquierdo + 360, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(precio, Font_texto_impresion, Brushes.Black, margen_izquierdo + 460, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(subtotal_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 560, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(porcentaje_desc, Font_texto_impresion, Brushes.Black, margen_izquierdo + 660, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(descuento_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 760, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(total_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 860, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 85 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 240 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 240 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0
        e.Graphics.DrawString("LOS PRECIOS INDICADOS CORRESPONDEN A VALORES NETOS.", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 260 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString("DESGLOSE:", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 290 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(desglose_total_cotizacion, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 305 + (numero_lineas * multiplicador_lineas))


        e.Graphics.DrawString("VALORES NETOS", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 260 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("SUBTOTAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 290 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("DESCUENTO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 305 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("TOTAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 320 + (numero_lineas * multiplicador_lineas))

        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 260 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 275 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 290 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 305 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 320 + (numero_lineas * multiplicador_lineas))

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

        'Dim neto_valor As Integer
        'Dim iva_valor As String

        'iva_valor = valor_iva / 100 + 1

        'neto_valor = (precio / iva_valor)
        'Round(neto_valor)
        'precio = neto_valor
        'subtotal_detalle = precio * cantidad

        'Dim descuento_porcentaje As Integer

        'descuento_porcentaje = ((subtotal_detalle) * porcentaje_desc) / 100
        'descuento_detalle = descuento_porcentaje
        'total_detalle = Int(subtotal_detalle) - Int(descuento_porcentaje)
        'txt_subtotal_neto.Text = Val(txt_subtotal_neto.Text) + Val(total_detalle)
        'txt_descuento.Text = 0
        'txt_descuento.Text = Int(((txt_subtotal_neto.Text) * porcentaje_desc_total) / 100)
        'txt_neto.Text = 0
        'txt_neto.Text = Val(txt_subtotal_neto.Text) - Val(txt_descuento.Text)


        'dr("desglose_palabras") = desglose_total_cotizacion
        'dr("subtotal") = txt_subtotal_neto.Text
        'dr("descuento") = txt_descuento.Text
        'dr("neto") = neto
        'dr("iva") = iva
        '' dr("total") = total
        'dr("total") = txt_neto.Text







        subtotal = txt_subtotal_neto.Text
        descuento = txt_descuento.Text
        neto = neto

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

        'e.Graphics.DrawString(subtotal, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 260 + (numero_lineas * multiplicador_lineas), format1)
        'e.Graphics.DrawString(descuento, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 275 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(subtotal, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 290 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(descuento, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 305 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(neto, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 320 + (numero_lineas * multiplicador_lineas), format1)
    End Sub
End Class