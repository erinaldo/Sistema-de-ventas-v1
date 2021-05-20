Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_autorizacion
    Private WithEvents Pd As New PrintDocument
    Dim impresora_ticket_ventas As String

    Private Sub Form_autorizacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Form_impreso_corectamente.Visible = True Then
            Form_venta.Enabled = False
        Else
            Form_venta.Enabled = True
            Form_venta.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form_autorizacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
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


            If Form_venta.combo_condiciones.Text = "PENDIENTE" And tipo_usuario_autoriza = "USUARIO DEL SISTEMA" Then
                MsgBox("ESTE DESCUENTO DEBE SER AUTORIZADO POR UN ADMINISTRADOR DE SISTEMA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If mirutempresa <> "81921000-4" Then


                'Form_venta.redondear_documento()
                Form_venta.crear_numero_documento()

                Dim VarCodigoDesc As String
                Dim VarPorcentajeDesc As Integer
                Dim VarValorPorcentajeDesc As Integer



                For i = 0 To Form_venta.grilla_detalle_venta.Rows.Count - 1

                    VarCodigoDesc = Form_venta.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                    VarPorcentajeDesc = Form_venta.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                    VarValorPorcentajeDesc = Form_venta.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString

                    If VarPorcentajeDesc > Int(0) And tipo_usuario_autoriza = "USUARIO DEL SISTEMA" Then
                        MsgBox("ESTE DESCUENTO DEBE SER AUTORIZADO POR UN ADMINISTRADOR DE SISTEMA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        Exit Sub
                    End If

                Next

                If Form_venta.txt_porcentaje_desc.Text > Int(12) And tipo_usuario_autoriza = "USUARIO DEL SISTEMA" Then
                    MsgBox("ESTE DESCUENTO DEBE SER AUTORIZADO POR UN ADMINISTRADOR DE SISTEMA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If












                For i = 0 To Form_venta.grilla_detalle_venta.Rows.Count - 1

                    VarCodigoDesc = Form_venta.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                    VarPorcentajeDesc = Form_venta.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                    VarValorPorcentajeDesc = Form_venta.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString

                    If VarPorcentajeDesc > Int(valor_descuento_maximo_columna) Then
                        SC.Connection = conexion
                        SC.CommandText = "insert registro_de_autorizaciones_ventas (usuario_responsable, fecha, tipo_descuento,tipo_doc, nro_doc, condicion_de_pago, rut_vendedor, nombre_vendedor, porcentaje_descuento, valor_descuento) values('" & (rut_usuario_autoriza) & "','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (VarCodigoDesc) & "', '" & (Form_venta.Combo_venta.Text) & "','" & (Form_venta.txt_factura.Text) & "','" & (Form_venta.combo_condiciones.Text) & "','" & (miusuario) & "','" & (minombre) & "','" & (VarPorcentajeDesc) & "','" & (VarValorPorcentajeDesc) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                    End If

                Next

                VarValorPorcentajeDesc = Val(Form_venta.txt_porcentaje_desc.Text)

                If VarValorPorcentajeDesc > valor_descuento_maximo Then

                    SC.Connection = conexion
                    SC.CommandText = "insert registro_de_autorizaciones_ventas (usuario_responsable, fecha, tipo_descuento,tipo_doc, nro_doc, condicion_de_pago, rut_vendedor, nombre_vendedor, porcentaje_descuento, valor_descuento) values('" & (rut_usuario_autoriza) & "','" & (Form_menu_principal.dtp_fecha.Text) & "', 'TOTAL', '" & (Form_venta.Combo_venta.Text) & "','" & (Form_venta.txt_factura.Text) & "','" & (Form_venta.combo_condiciones.Text) & "','" & (miusuario) & "','" & (minombre) & "','" & (Form_venta.txt_porcentaje_desc.Text) & "','" & (Form_venta.txt_desc.Text) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                End If


            End If



















            Form_venta.imprimir()

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







    Sub imprimir()


        If tipo_impresion_sistema = "TICKET" Then


            With Pd.PrinterSettings
                'Especifico el nombre de la impresora 
                'por donde deseo imprimir. 
                .PrinterName = impresora_ticket_ventas
                'Establezco el número de copias que se imprimirán 
                .Copies = 1
                'Rango de páginas que se imprimirán 
                .PrintRange = PrintRange.AllPages
                If .IsValid Then

                    Form_venta.crear_numero_documento()
                    Form_venta.grabar_factura()


                    Me.Pd.PrintController = New StandardPrintController
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                    Pd.Print()

                    Form_venta.grabar_detalle_factura()
                    Form_impreso_corectamente.Show()
                    Form_venta.crear_archivo_plano()

                    Form_venta.Enabled = True
                    Form_venta.controles(False, True)
                    Exit Sub
                Else
                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                    Me.Enabled = True
                    Exit Sub
                End If
            End With

        End If





        If Form_venta.Combo_venta.Text = "GUIA" Then

            If estado_guia_electronica = "NO" Then
                With Pd.PrinterSettings

                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_guias
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then

                        Form_venta.crear_numero_documento()
                        Form_venta.grabar_factura()

                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()

                        Form_venta.grabar_detalle_factura()
                        Form_impreso_corectamente.Show()
                        Form_venta.crear_archivo_plano()
                        ' Form_venta.limpiar()
                        Form_venta.controles(False, True)


                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Form_venta.Enabled = True
                        Exit Sub
                    End If
                End With

            Else
                Form_venta.crear_numero_documento()
                Form_venta.grabar_factura()
                Form_venta.grabar_detalle_factura()
                Form_impreso_corectamente.Show()
                Form_venta.crear_archivo_plano()
                '  Form_venta.limpiar()
                Form_venta.controles(False, True)
                Exit Sub
            End If
        End If























        If Form_venta.Combo_venta.Text = "FACTURA DE CREDITO" Then

            If estado_factura_electronica = "NO" Then

                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_facturas
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then

                        Form_venta.crear_numero_documento()
                        Form_venta.grabar_factura()


                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()

                        Form_venta.grabar_detalle_factura()
                        Form_impreso_corectamente.Show()
                        Form_venta.crear_archivo_plano()
                        ' Form_venta.limpiar()
                        Form_venta.controles(False, True)

                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Form_venta.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                Form_venta.crear_numero_documento()
                Form_venta.grabar_factura()
                Form_venta.grabar_detalle_factura()
                Form_impreso_corectamente.Show()
                Form_venta.crear_archivo_plano()
                ' Form_venta.limpiar()
                Form_venta.controles(False, True)
                Exit Sub
            End If
        End If


        If Form_venta.Combo_venta.Text = "FACTURA" Then

            If estado_factura_electronica = "NO" Then

                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_facturas
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then

                        Form_venta.redondear_documento()
                        Form_venta.crear_numero_documento()
                        Form_venta.grabar_factura()


                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()

                        Form_venta.grabar_detalle_factura()
                        Form_impreso_corectamente.Show()
                        Form_venta.crear_archivo_plano()
                        '  Form_venta.limpiar()
                        Form_venta.controles(False, True)

                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Form_venta.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                Form_venta.redondear_documento()
                Form_venta.crear_numero_documento()
                Form_venta.grabar_factura()
                Form_venta.grabar_detalle_factura()
                Form_impreso_corectamente.Show()
                Form_venta.crear_archivo_plano()
                '    Form_venta.limpiar()
                Form_venta.controles(False, True)
                Exit Sub
            End If
        End If







        If Form_venta.Combo_venta.Text = "BOLETA" Then

            If estado_boleta_electronica = "NO" Then

                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_boletas
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then

                        Form_venta.redondear_documento()
                        Form_venta.crear_numero_documento()
                        Form_venta.grabar_factura()


                        Me.Pd.PrintController = New StandardPrintController
                        Me.Pd.DefaultPageSettings.Margins.Left = 10
                        Me.Pd.DefaultPageSettings.Margins.Right = 10
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()

                        Form_venta.grabar_detalle_factura()
                        Form_impreso_corectamente.Show()
                        Form_venta.crear_archivo_plano()
                        '  Form_venta.limpiar()
                        Form_venta.controles(False, True)

                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Form_venta.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                Form_venta.redondear_documento()
                Form_venta.crear_numero_documento()
                Form_venta.grabar_factura()
                Form_venta.grabar_detalle_factura()
                Form_impreso_corectamente.Show()
                Form_venta.crear_archivo_plano()
                '  Form_venta.limpiar()
                Form_venta.controles(False, True)
                Exit Sub
            End If
        End If




        If Form_venta.Combo_venta.Text = "BOLETA DE CREDITO" Then

            If estado_boleta_electronica = "NO" Then

                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_boletas
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then

                        Form_venta.crear_numero_documento()
                        Form_venta.grabar_factura()


                        Me.Pd.PrintController = New StandardPrintController
                        Me.Pd.DefaultPageSettings.Margins.Left = 10
                        Me.Pd.DefaultPageSettings.Margins.Right = 10
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()

                        Form_venta.grabar_detalle_factura()
                        Form_impreso_corectamente.Show()
                        Form_venta.crear_archivo_plano()
                        '  Form_venta.limpiar()
                        Form_venta.controles(False, True)

                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Form_venta.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                Form_venta.crear_numero_documento()
                Form_venta.grabar_factura()
                Form_venta.grabar_detalle_factura()
                Form_impreso_corectamente.Show()
                Form_venta.crear_archivo_plano()
                ' Form_venta.limpiar()
                Form_venta.controles(False, True)
                Exit Sub
            End If
        End If


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


    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage

        'crear_numero_factura()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As String
        Dim VarCantidad As String
        Dim VarPorcentaje As String
        Dim VarDescuento As String
        Dim VarNeto As String
        Dim VarIva As String
        Dim VarSubtotal As String
        Dim VarTotal As String
        Dim cantidad_detalle As String
        Dim valorUnitario_detalle As String
        Dim subtotal_detalle As String
        Dim total_detalle As String

        'Dim Font11 As New Font("Lucida Console", 11, FontStyle.Regular)
        'Dim Font10 As New Font("Lucida Console", 10, FontStyle.Regular)
        'Dim Font9 As New Font("Lucida Console", 9, FontStyle.Regular)
        'Dim Font8 As New Font("Lucida Console", 8, FontStyle.Regular)

        Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)







        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far






        If tipo_impresion_sistema = "TICKET" Then

            Dim Font1 As New Font("arial", 7, FontStyle.Regular)
            Dim Font2 As New Font("arial", 9, FontStyle.Bold)
            Dim Font3 As New Font("arial", 7, FontStyle.Bold)
            Dim Font4 As New Font("arial", 8, FontStyle.Bold)

            'Dim im As Image


            Try
                'im = Image.FromFile(ruta_logo_empresa_ticket)
                Dim p As New PointF(0, 0)
                'e.Graphics.DrawImage(im, p)
                e.Graphics.DrawImage(Bytes_Imagen(Imagen_ticket), p)
            Catch
            End Try


            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center


            Dim rect1 As New Rectangle(10, 60, 270, 15)
            Dim rect2 As New Rectangle(10, 75, 270, 15)
            Dim rect3 As New Rectangle(10, 90, 270, 15)
            Dim rect4 As New Rectangle(10, 105, 270, 15)
            Dim rect5 As New Rectangle(10, 120, 270, 15)
            Dim rect6 As New Rectangle(10, 135, 270, 15)
            Dim rect7 As New Rectangle(10, 165, 270, 15)
            Dim rect8 As New Rectangle(10, 255, 270, 50)


            e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
            e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
            e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
            e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
            e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
            e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

            e.Graphics.DrawString("TICKET DE VENTA", Font2, Brushes.Black, rect7, stringFormat)

            e.Graphics.DrawString("NRO. TICKET", Font3, Brushes.Black, 0, 195)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 70, 195)



            Dim codigo As String = 0
            Dim valor As Integer
            codigo = Form_venta.txt_factura.Text
            Dim nro_ticket As String
            valor = codigo
            nro_ticket = String.Format("{0:000000}", valor)





            Dim mifecha As Date
            Dim fecha_doc As String
            mifecha = Form_menu_principal.dtp_fecha.Text
            fecha_doc = mifecha.ToString("dd-MM-yyy")


            e.Graphics.DrawString(Form_venta.txt_factura.Text, Font4, Brushes.Black, 80, 195)
            e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 210)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 70, 210)
            e.Graphics.DrawString(fecha_doc, Font3, Brushes.Black, 80, 210)
            e.Graphics.DrawString("VENDEDOR", Font3, Brushes.Black, 0, 225)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 70, 225)
            e.Graphics.DrawString(minombre, Font3, Brushes.Black, 80, 225)



            e.Graphics.DrawString("*" & (nro_ticket) & "*", New Font("C39HrP36DlTt", 30), Brushes.Black, rect8, stringFormat)

            e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, 350)
            Exit Sub
        End If

        If Form_venta.Combo_venta.Text = "BOLETA" Then
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
            e.Graphics.DrawString(Form_venta.combo_condiciones.Text, Font10, Brushes.Black, 590, 5)

            For i = 0 To Form_venta.grilla_detalle_venta.Rows.Count - 1
                VarCodProducto = Form_venta.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = Form_venta.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = Form_venta.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = Form_venta.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = Form_venta.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = Form_venta.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = Form_venta.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                cantidad_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                '   cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")

                Dim descripcion_caracteres As String
                descripcion_caracteres = varnombre & "        " & vartecnico
                If descripcion_caracteres.Length > 55 Then
                    descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                End If




                e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 50, 60 + (i * 15))
                e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, 60 + (i * 15))
                e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 565, 60 + (i * 15), format1)
                e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 645, 60 + (i * 15), format1)
                e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 725, 60 + (i * 15), format1)
            Next

            Dim descuento_millar As String
            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String
            Dim subtotal_millar As String

            descuento_millar = Form_venta.txt_desc.Text
            neto_millar = Form_venta.txt_neto.Text
            iva_millar = Form_venta.txt_iva.Text
            subtotal_millar = Form_venta.txt_sub_total.Text
            total_millar = Form_venta.txt_total.Text

            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            neto_millar = Format(Int(neto_millar), "###,###,###")
            iva_millar = Format(Int(iva_millar), "###,###,###")
            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")


            Dim nombre_vendedor As String
            nombre_vendedor = minombre
            If nombre_vendedor.Length > 12 Then
                nombre_vendedor = nombre_vendedor.Substring(0, 12)
            End If


            e.Graphics.DrawString(Form_venta.txt_factura.Text, Font10, Brushes.Black, 60, 270)
            e.Graphics.DrawString(nombre_vendedor, Font10, Brushes.Black, 215, 270)
            e.Graphics.DrawString(subtotal_millar, Font10, Brushes.Black, 385, 270)
            e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, 515, 270)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 630, 270)

            'Pd = New Printing.PrintDocument
            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 200)
            'Pd.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
        End If



        If Form_venta.Combo_venta.Text = "BOLETA DE CREDITO" Then
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
            e.Graphics.DrawString(Form_venta.combo_condiciones.Text, Font10, Brushes.Black, 590, 5)

            For i = 0 To Form_venta.grilla_detalle_venta.Rows.Count - 1
                VarCodProducto = Form_venta.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = Form_venta.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = Form_venta.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = Form_venta.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = Form_venta.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = Form_venta.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = Form_venta.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                cantidad_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                '  cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")

                Dim descripcion_caracteres As String
                descripcion_caracteres = varnombre & "        " & vartecnico
                If descripcion_caracteres.Length > 55 Then
                    descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                End If



                e.Graphics.DrawString(Form_venta.txt_nombre_cliente.Text, Font10, Brushes.Black, 60, 190)
                e.Graphics.DrawString(Form_venta.txt_rut_cliente.Text, Font10, Brushes.Black, 60, 205)
                e.Graphics.DrawString(Form_venta.txt_direccion_cliente.Text, Font10, Brushes.Black, 60, 220)
                e.Graphics.DrawString(Form_venta.txt_comuna_cliente.Text, Font10, Brushes.Black, 60, 235)

                e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 50, 60 + (i * 15))
                e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, 60 + (i * 15))
                e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 565, 60 + (i * 15), format1)
                e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 645, 60 + (i * 15), format1)
                e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 725, 60 + (i * 15), format1)
            Next

            Dim descuento_millar As String
            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String
            Dim subtotal_millar As String

            descuento_millar = Form_venta.txt_desc.Text
            neto_millar = Form_venta.txt_neto.Text
            iva_millar = Form_venta.txt_iva.Text
            subtotal_millar = Form_venta.txt_sub_total.Text
            total_millar = Form_venta.txt_total.Text

            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            neto_millar = Format(Int(neto_millar), "###,###,###")
            iva_millar = Format(Int(iva_millar), "###,###,###")
            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")


            Dim nombre_vendedor As String
            nombre_vendedor = minombre
            If nombre_vendedor.Length > 12 Then
                nombre_vendedor = nombre_vendedor.Substring(0, 12)
            End If


            e.Graphics.DrawString(Form_venta.txt_factura.Text, Font10, Brushes.Black, 60, 270)
            e.Graphics.DrawString(nombre_vendedor, Font10, Brushes.Black, 215, 270)
            e.Graphics.DrawString(subtotal_millar, Font10, Brushes.Black, 385, 270)
            e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, 515, 270)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 630, 270)

            'Pd = New Printing.PrintDocument
            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 200)
            'Pd.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
        End If




        If Form_venta.Combo_venta.Text = "FACTURA" Then
            e.Graphics.DrawString(Form_venta.txt_factura.Text, Font10, Brushes.Black, 550, 10, format1)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 10)
            e.Graphics.DrawString(Form_venta.txt_nombre_cliente.Text, Font10, Brushes.Black, 85, 25)
            e.Graphics.DrawString(Form_venta.txt_direccion_cliente.Text, Font10, Brushes.Black, 85, 40)
            e.Graphics.DrawString(Form_venta.txt_giro_cliente.Text, Font10, Brushes.Black, 85, 55)

            e.Graphics.DrawString(Form_venta.txt_rut_cliente.Text, Font10, Brushes.Black, 665, 10)
            e.Graphics.DrawString(Form_venta.txt_comuna_cliente.Text, Font10, Brushes.Black, 665, 25)
            e.Graphics.DrawString(Form_venta.txt_telefono.Text, Font10, Brushes.Black, 665, 40)
            e.Graphics.DrawString(Form_venta.combo_condiciones.Text, Font10, Brushes.Black, 665, 55)

            For i = 0 To Form_venta.grilla_detalle_venta.Rows.Count - 1
                VarCodProducto = Form_venta.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = Form_venta.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = Form_venta.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = Form_venta.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = Form_venta.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = Form_venta.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = Form_venta.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                cantidad_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString


                ' cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")



                If varnombre.Length > 35 Then
                    varnombre = varnombre.Substring(0, 35)
                End If

                If vartecnico.Length > 22 Then
                    vartecnico = vartecnico.Substring(0, 22)
                End If

                e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 130 + (i * 15))
                e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 85, 130 + (i * 15))
                e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 340, 130 + (i * 15))
                e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 540, 130 + (i * 15), format1)
                e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 130 + (i * 15), format1)
                e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 650, 130 + (i * 15), format1)
                e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 730, 130 + (i * 15), format1)
                e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 800, 130 + (i * 15), format1)

                'e.Graphics.DrawString(VarCodProducto, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 0, 140 + (i * 20))
                'e.Graphics.DrawString(varnombre, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 75, 140 + (i * 20))
                'e.Graphics.DrawString(vartecnico, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 335, 140 + (i * 20))
                'e.Graphics.DrawString(cantidad_detalle, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 510, 140 + (i * 20), format1)
                'e.Graphics.DrawString(valorUnitario_detalle, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 590, 140 + (i * 20), format1)
                'e.Graphics.DrawString(VarPorcentaje, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 640, 140 + (i * 20), format1)
                'e.Graphics.DrawString(VarSubtotal, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 710, 140 + (i * 20), format1)
                'e.Graphics.DrawString(VarTotal, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 780, 140 + (i * 20), format1)
            Next

            Dim descuento_millar As String
            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String
            Dim subtotal_millar As String

            descuento_millar = Form_venta.txt_desc_millar.Text
            neto_millar = Form_venta.txt_neto_millar.Text
            iva_millar = Form_venta.txt_iva_millar.Text
            subtotal_millar = Form_venta.txt_sub_total_millar.Text
            total_millar = Form_venta.txt_total_millar.Text

            'descuento_millar = Format(Int(descuento_millar), "###,###,###")
            'neto_millar = Format(Int(neto_millar), "###,###,###")
            'iva_millar = Format(Int(iva_millar), "###,###,###")
            'subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            'total_millar = Format(Int(total_millar), "###,###,###")

            e.Graphics.DrawString(desglose_valor, Font9, Brushes.Black, 35, 670)
            e.Graphics.DrawString(minombre, Font9, Brushes.Black, 35, 690)

            e.Graphics.DrawString(Form_venta.txt_nombre_retira.Text, Font8, Brushes.Black, 50, 735)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 40, 755)
            e.Graphics.DrawString(Form_venta.txt_rut_retira.Text, Font8, Brushes.Black, 470, 735)
            e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 180, 755)

            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 680, format1)
            '  e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, 792, 700, format1)
            e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 725, format1)
            e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 765, format1)

            If descuento_millar <> "" Then
                If descuento_millar <> "0" Then
                    e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 800, 580, format1)
                    e.Graphics.DrawString("-  " & descuento_millar, Font8, Brushes.Black, 800, 600, format1)
                    e.Graphics.DrawString("_________", Font8, Brushes.Black, 800, 602, format1)
                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 800, 620, format1)
                End If
            End If
            'e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 745, format1)
            'e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)











            'Pd = New Printing.PrintDocument
            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 200)
            'Pd.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
        End If



        If Form_venta.Combo_venta.Text = "FACTURA DE CREDITO" Then
            e.Graphics.DrawString(Form_venta.txt_factura.Text, Font10, Brushes.Black, 550, 10, format1)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 10)
            e.Graphics.DrawString(Form_venta.txt_nombre_cliente.Text, Font10, Brushes.Black, 85, 25)
            e.Graphics.DrawString(Form_venta.txt_folio.Text, Font10, Brushes.Black, 550, 25, format1)
            e.Graphics.DrawString(Form_venta.txt_direccion_cliente.Text, Font10, Brushes.Black, 85, 40)
            e.Graphics.DrawString(Form_venta.txt_giro_cliente.Text, Font10, Brushes.Black, 85, 55)



            If Form_venta.txt_nro_orden_de_compra.Text <> "" Then
                If Form_venta.txt_nro_orden_de_compra.Text <> "0" Then
                    e.Graphics.DrawString("ORDEN DE COMPRA: " & Form_venta.txt_nro_orden_de_compra.Text, Font10, Brushes.Black, 50, 70)
                End If
            End If

            e.Graphics.DrawString(Form_venta.txt_rut_cliente.Text, Font10, Brushes.Black, 665, 10)
            e.Graphics.DrawString(Form_venta.txt_comuna_cliente.Text, Font10, Brushes.Black, 665, 25)
            e.Graphics.DrawString(Form_venta.txt_telefono.Text, Font10, Brushes.Black, 665, 40)
            e.Graphics.DrawString(Form_venta.combo_condiciones.Text, Font10, Brushes.Black, 665, 55)

            For i = 0 To Form_venta.grilla_detalle_venta.Rows.Count - 1
                VarCodProducto = Form_venta.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = Form_venta.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = Form_venta.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = Form_venta.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = Form_venta.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = Form_venta.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = Form_venta.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                cantidad_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString


                ' cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")



                If varnombre.Length > 35 Then
                    varnombre = varnombre.Substring(0, 35)
                End If

                If vartecnico.Length > 22 Then
                    vartecnico = vartecnico.Substring(0, 22)
                End If

                e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 130 + (i * 15))
                e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 85, 130 + (i * 15))
                e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 340, 130 + (i * 15))
                e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 540, 130 + (i * 15), format1)
                e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 130 + (i * 15), format1)
                e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 650, 130 + (i * 15), format1)
                e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 730, 130 + (i * 15), format1)
                e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 800, 130 + (i * 15), format1)

                'e.Graphics.DrawString(VarCodProducto, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 0, 140 + (i * 20))
                'e.Graphics.DrawString(varnombre, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 75, 140 + (i * 20))
                'e.Graphics.DrawString(vartecnico, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 335, 140 + (i * 20))
                'e.Graphics.DrawString(cantidad_detalle, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 510, 140 + (i * 20), format1)
                'e.Graphics.DrawString(valorUnitario_detalle, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 590, 140 + (i * 20), format1)
                'e.Graphics.DrawString(VarPorcentaje, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 640, 140 + (i * 20), format1)
                'e.Graphics.DrawString(VarSubtotal, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 710, 140 + (i * 20), format1)
                'e.Graphics.DrawString(VarTotal, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 780, 140 + (i * 20), format1)
            Next

            Dim descuento_millar As String
            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String
            Dim subtotal_millar As String

            descuento_millar = Form_venta.txt_desc.Text
            neto_millar = Form_venta.txt_neto.Text
            iva_millar = Form_venta.txt_iva.Text
            subtotal_millar = Form_venta.txt_sub_total.Text
            total_millar = Form_venta.txt_total.Text

            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            neto_millar = Format(Int(neto_millar), "###,###,###")
            iva_millar = Format(Int(iva_millar), "###,###,###")
            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            e.Graphics.DrawString(desglose_valor, Font9, Brushes.Black, 35, 670)
            e.Graphics.DrawString(minombre, Font9, Brushes.Black, 35, 690)

            e.Graphics.DrawString(Form_venta.txt_nombre_retira.Text, Font8, Brushes.Black, 50, 735)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 40, 755)
            e.Graphics.DrawString(Form_venta.txt_rut_retira.Text, Font8, Brushes.Black, 470, 735)
            e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 180, 755)

            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 680, format1)
            '  e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, 792, 700, format1)
            e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 725, format1)
            e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 765, format1)

            If descuento_millar <> "" Then
                If descuento_millar <> "0" Then
                    e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 800, 580, format1)
                    e.Graphics.DrawString("-  " & descuento_millar, Font8, Brushes.Black, 800, 600, format1)
                    e.Graphics.DrawString("_________", Font8, Brushes.Black, 800, 602, format1)
                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 800, 620, format1)
                End If
            End If
            'e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 745, format1)
            'e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)











            'Pd = New Printing.PrintDocument
            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 200)
            'Pd.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
        End If

        If Form_venta.Combo_venta.Text = "GUIA" Then

            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 100, 20)
            e.Graphics.DrawString(Form_venta.txt_factura.Text, Font10, Brushes.Black, 550, 20, format1)

            e.Graphics.DrawString(Form_venta.txt_nombre_cliente.Text, Font10, Brushes.Black, 100, 36)
            e.Graphics.DrawString(Form_venta.txt_folio.Text, Font10, Brushes.Black, 550, 36, format1)
            e.Graphics.DrawString(Form_venta.txt_direccion_cliente.Text, Font10, Brushes.Black, 100, 52)

            If Form_venta.txt_descuento_cliente_2.Text <> "0" Then
                e.Graphics.DrawString("-" & Form_venta.txt_descuento_cliente_2.Text & "%", Font10, Brushes.Black, 550, 52, format1)
            End If


            e.Graphics.DrawString(Form_venta.txt_giro_cliente.Text, Font10, Brushes.Black, 100, 68)
            e.Graphics.DrawString(Form_venta.txt_nro_orden_de_compra.Text, Font10, Brushes.Black, 100, 84)



            e.Graphics.DrawString(Form_venta.txt_rut_cliente.Text, Font10, Brushes.Black, 655, 20)
            e.Graphics.DrawString(Form_venta.txt_comuna_cliente.Text, Font10, Brushes.Black, 655, 36)
            e.Graphics.DrawString(Form_venta.txt_telefono.Text, Font10, Brushes.Black, 655, 52)
            e.Graphics.DrawString(Form_venta.combo_condiciones.Text, Font10, Brushes.Black, 655, 68)
            e.Graphics.DrawString(minombre, Font10, Brushes.Black, 655, 84)

            For i = 0 To Form_venta.grilla_detalle_venta.Rows.Count - 1
                VarCodProducto = Form_venta.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = Form_venta.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = Form_venta.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = Form_venta.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = Form_venta.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = Form_venta.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = Form_venta.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                cantidad_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                ' cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")

                If varnombre.Length > 35 Then
                    varnombre = varnombre.Substring(0, 35)
                End If

                If vartecnico.Length > 22 Then
                    vartecnico = vartecnico.Substring(0, 22)
                End If

                e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 0, 145 + (i * 15))
                e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 75, 145 + (i * 15))
                e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 335, 145 + (i * 15))
                e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 520, 145 + (i * 15), format1)
                e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 145 + (i * 15), format1)
                e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 640, 145 + (i * 15), format1)
                e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 725, 145 + (i * 15), format1)
                e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 792, 145 + (i * 15), format1)

                'e.Graphics.DrawString(VarCodProducto, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 0, 140 + (i * 20))
                'e.Graphics.DrawString(varnombre, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 75, 140 + (i * 20))
                'e.Graphics.DrawString(vartecnico, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 335, 140 + (i * 20))
                'e.Graphics.DrawString(cantidad_detalle, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 510, 140 + (i * 20), format1)
                'e.Graphics.DrawString(valorUnitario_detalle, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 590, 140 + (i * 20), format1)
                'e.Graphics.DrawString(VarPorcentaje, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 640, 140 + (i * 20), format1)
                'e.Graphics.DrawString(VarSubtotal, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 710, 140 + (i * 20), format1)
                'e.Graphics.DrawString(VarTotal, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 780, 140 + (i * 20), format1)
            Next

            Dim descuento_millar As String
            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String
            Dim subtotal_millar As String

            descuento_millar = Form_venta.txt_desc.Text
            neto_millar = Form_venta.txt_neto.Text
            iva_millar = Form_venta.txt_iva.Text
            subtotal_millar = Form_venta.txt_sub_total.Text
            total_millar = Form_venta.txt_total.Text

            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            neto_millar = Format(Int(neto_millar), "###,###,###")
            iva_millar = Format(Int(iva_millar), "###,###,###")
            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            '    e.Graphics.DrawString(desglose_valor, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 35, 585)


            e.Graphics.DrawString(Form_venta.txt_nombre_retira.Text, Font8, Brushes.Black, 55, 540)
            e.Graphics.DrawString(Form_venta.txt_rut_retira.Text, Font8, Brushes.Black, 265, 540)
            e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 510, 540)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 797, 540, format1)

            'e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 465, format1)
            'e.Graphics.DrawString(descuento_millar, Font8, Brushes.Black, 792, 480, format1)



            If Form_venta.combo_condiciones.Text <> "TRASLADO" Then
                If Form_venta.txt_desc.Text = "0" Or Form_venta.txt_desc.Text = "" Then
                    e.Graphics.DrawString("TOTAL $", Font8, Brushes.Black, 725, 400, format1)
                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 400, format1)

                Else

                    e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 792, 400, format1)
                    e.Graphics.DrawString("-" & Form_venta.txt_porcentaje_desc.Text & "%", Font8, Brushes.Black, 725, 415, format1)
                    e.Graphics.DrawString(descuento_millar, Font8, Brushes.Black, 792, 415, format1)
                    e.Graphics.DrawString("_________", Font8, Brushes.Black, 792, 417, format1)
                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 432, format1)
                End If
            End If





            'e.Graphics.DrawString(neto_millar, New Font("Calibri (Cuerpo)", 11, FontStyle.Regular), Brushes.Black, 792, 625, format1)
            'e.Graphics.DrawString(iva_millar, New Font("Calibri (Cuerpo)", 11, FontStyle.Regular), Brushes.Black, 792, 645, format1)
            'e.Graphics.DrawString(total_millar, New Font("Calibri (Cuerpo)", 11, FontStyle.Regular), Brushes.Black, 792, 665, format1)

            'Pd = New Printing.PrintDocument
            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 200)
            'Pd.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
        End If



    End Sub

    Private Sub Form_autorizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mostrar_impresora()
        Timer_autorizacion.Start()
    End Sub

    Sub mostrar_impresora()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from impresoras"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            impresora_ticket_ventas = DS.Tables(DT.TableName).Rows(0).Item("ticket_ventas")
        End If
        conexion.Close()
    End Sub

    Private Sub txt_clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_clave.TextChanged

    End Sub
    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")> _
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Public Function GetInactiveTime() As Nullable(Of TimeSpan)
        Dim info As LASTINPUTINFO = New LASTINPUTINFO
        info.cbSize = CUInt(Marshal.SizeOf(info))
        If (GetLastInputInfo(info)) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
        Else
            Return Nothing
        End If
    End Function


    Private Sub Timer_autorizacion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_autorizacion.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
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
End Class