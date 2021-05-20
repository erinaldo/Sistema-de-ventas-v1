Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Public Class Form_mis_pedidos_en_espera
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim consulta_busqueda As String
    Private WithEvents Pd As New PrintDocument
    Dim alto_cotizacion As String
    Dim peso As String
    Dim cantidad_letras As Integer
    Dim desglose_palabras As String
    Private Sub Form_mis_pedidos_en_espera_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_mis_pedidos_en_espera_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_mis_pedidos_en_espera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        grilla_documento.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        grilla_detalle_documento.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
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

    Sub mostrar_malla_detalle()
        Dim nro_doc As String
        nro_doc = grilla_documento.CurrentRow.Cells(0).Value
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_pedidos_vendedor  where n_pedidos_vendedor= '" & (nro_doc) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_detalle_documento.Rows.Clear()
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"))
            Next
        End If
    End Sub

    Sub mostrar_datos_clientes()
        conexion.Close()
        If txt_rut_cliente.Text <> "" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                conexion.Close()
                busqueda()
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
        End If
    End Sub

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub grilla_documento_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If grilla_documento.Rows.Count <> 0 Then
            mostrar_malla_detalle()
        End If
    End Sub

    Private Sub grilla_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub














    Sub busqueda()
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        consulta_busqueda = "select n_pedidos_vendedor as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', pedidos_vendedor.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', total as 'TOTAL', nombre_usuario as 'VENDEDOR', estado as 'ESTADO' from pedidos_vendedor, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and pedidos_vendedor.usuario_responsable=usuarios.rut_usuario and pedidos_vendedor.rut_cliente=clientes.rut_cliente "

        If txt_rut_cliente.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and clientes.rut_cliente ='" & (txt_rut_cliente.Text) & "'"
        Else
            consulta_busqueda = consulta_busqueda
        End If
        consulta_busqueda = consulta_busqueda & " group by pedidos_vendedor.n_pedidos_vendedor order by pedidos_vendedor.n_pedidos_vendedor desc"
        grilla_detalle_documento.Rows.Clear()
        conexion.Close()
        Dim DT3 As New DataTable
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = consulta_busqueda
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        grilla_documento.DataSource = DS3.Tables(DT3.TableName)
        conexion.Close()
        grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Try
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch
        End Try
        grilla_documento.Columns(3).Visible = False
        grilla_detalle_documento.Rows.Clear()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            guion_rut_cliente()
            mostrar_datos_clientes()
            busqueda()
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

    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged

    End Sub

    Private Sub Combo_vendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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


    End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False

        busqueda()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub



    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_documento.DataSource = Nothing
        grilla_detalle_documento.Rows.Clear()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_documento.DataSource = Nothing
        grilla_detalle_documento.Rows.Clear()
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage

        'crear_numero_factura()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim VarValorUnitario As String
        Dim VarCantidad As String
        Dim VarDescuento As String
        Dim VarNeto As String
        Dim VarIva As String
        Dim VarSubtotal As String
        Dim VarTotal As String







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





        Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        Dim Font2 As New Font("arial", 9, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        Dim im As Image


        Try
            im = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
            Dim p As New PointF(0, 0)
            e.Graphics.DrawImage(im, p)
        Catch
        End Try
        'e.Graphics.DrawString("             " & migiroempresa, Font3, Brushes.Black, 30, 60)
        'e.Graphics.DrawString("      " & midireccionempresa, Font3, Brushes.Black, 30, 75)
        'e.Graphics.DrawString("                       " & miciudadempresa, Font3, Brushes.Black, 30, 90)
        'e.Graphics.DrawString("  " & mitelefonoempresa, Font3, Brushes.Black, 30, 105)
        'e.Graphics.DrawString("      " & micorreoempresa, Font3, Brushes.Black, 30, 120)
        'e.Graphics.DrawString("                           " & mirutempresa, Font3, Brushes.Black, 30, 135)










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

        Dim nro_documento As String
        Dim fecha_documento As String

        nro_documento = grilla_documento.CurrentRow.Cells(0).Value
        fecha_documento = grilla_documento.CurrentRow.Cells(2).Value

        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

        e.Graphics.DrawString("COTIZACION", Font2, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("NRO. COTIZACION", Font3, Brushes.Black, 0, 195)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 195)
        e.Graphics.DrawString(nro_documento, Font4, Brushes.Black, 95, 195)
        e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 210)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 210)
        e.Graphics.DrawString(fecha_documento, Font3, Brushes.Black, 95, 210)
        e.Graphics.DrawString("VENDEDOR", Font3, Brushes.Black, 0, 225)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 225)
        e.Graphics.DrawString(minombre, Font3, Brushes.Black, 95, 225)
        e.Graphics.DrawString("TELEFONO", Font3, Brushes.Black, 0, 240)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 240)
        e.Graphics.DrawString(mitelefono, Font3, Brushes.Black, 95, 240)

        e.Graphics.DrawString("CODIGO", Font3, Brushes.Black, 0, 270)
        e.Graphics.DrawString("DESCRIPCION", Font3, Brushes.Black, 55, 270)
        e.Graphics.DrawString("CANT.", Font3, Brushes.Black, 200, 270)
        e.Graphics.DrawString("TOTAL", Font3, Brushes.Black, 250, 270)

        e.Graphics.DrawLine(Pens.Black, 1, 285, 295, 285)

        For i = 0 To grilla_detalle_documento.Rows.Count - 1



            VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
            VarValorUnitario = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
            VarCantidad = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
            VarSubtotal = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
            VarDescuento = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
            VarNeto = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
            VarIva = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
            VarTotal = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString



            Dim cantidad As String
            Dim total As String




            cantidad = VarCantidad
            total = VarTotal




            Dim descripcion As String

            descripcion = varnombre
            If varnombre.Length > 23 Then
                descripcion = varnombre.Substring(0, 24)
            End If
            '  codigo_producto = Format(Int(codigo_producto), "###,###,###")
            ' descripcion = Format(Int(descripcion), "###,###,###")
            '   cantidad = Format(Int(cantidad), "###,###,###")
            total = Format(Int(total), "###,###,###")



            e.Graphics.DrawString(VarCodProducto, Font3, Brushes.Gray, 0, 290 + (i * 15))
            e.Graphics.DrawString(descripcion, Font3, Brushes.Gray, 55, 290 + (i * 15))
            e.Graphics.DrawString(cantidad, Font3, Brushes.Gray, 235, 290 + (i * 15), format1)
            e.Graphics.DrawString(total, Font3, Brushes.Gray, 285, 290 + (i * 15), format1)
        Next





        Dim subtotal_millar As String
        Dim descuento_millar As String
        Dim total_millar As String


        descuento_millar = grilla_documento.CurrentRow.Cells(6).Value
        subtotal_millar = grilla_documento.CurrentRow.Cells(5).Value
        total_millar = grilla_documento.CurrentRow.Cells(9).Value

        subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        descuento_millar = Format(Int(descuento_millar), "###,###,###")
        total_millar = Format(Int(total_millar), "###,###,###")


        Dim var_grilla As Integer
        var_grilla = ((grilla_detalle_documento.Rows.Count - 1) * 15)


        e.Graphics.DrawString("SUBTOTAL", Font3, Brushes.Black, 160, var_grilla + 320)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 230, var_grilla + 320)
        e.Graphics.DrawString(subtotal_millar, Font3, Brushes.Black, 285, var_grilla + 320, format1)
        e.Graphics.DrawString("DESCUENTO", Font3, Brushes.Black, 160, var_grilla + 335)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 230, var_grilla + 335)
        e.Graphics.DrawString(descuento_millar, Font3, Brushes.Black, 285, var_grilla + 335, format1)
        e.Graphics.DrawString("TOTAL", Font3, Brushes.Black, 160, var_grilla + 350)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 230, var_grilla + 350)
        e.Graphics.DrawString(total_millar, Font3, Brushes.Black, 285, var_grilla + 350, format1)




















        Dim rect8 As New Rectangle(10, var_grilla + 380, 270, 15)

        e.Graphics.DrawString("COTIZACION VALIDA POR 10 DIAS", Font3, Brushes.Gray, rect8, stringFormat)
        e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, var_grilla + 450)
        alto_cotizacion = var_grilla + 470
    End Sub

    Private Sub txt_rut_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub

    Private Sub migrilla_documentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.Click
        If grilla_documento.Rows.Count <> 0 Then
            mostrar_malla_detalle()
        End If
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            txt_rut_cliente.Text = ""
            txt_nombre_cliente.Text = ""
            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If
    End Sub

    Private Sub txt_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        grilla_documento.DataSource = Nothing
        grilla_detalle_documento.Rows.Clear()

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

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_buscador_clientes_documentos_emitidos.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        busqueda()
    End Sub

    Private Sub btn_buscar_clientes_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.Click
        Form_buscador_clientes_documentos_emitidos.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_mostrar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        busqueda()
    End Sub

    Private Sub btn_salir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub grilla_documento_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub

    Private Sub grilla_documento_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.DoubleClick
        If grilla_documento.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim codigo_pedido As String
        Dim estado As String

        codigo_pedido = grilla_documento.CurrentRow.Cells(0).Value
        estado = grilla_documento.CurrentRow.Cells(10).Value
       
        If estado = "EN ESPERA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "UPDATE pedidos_vendedor SET `estado`='ACEPTADO' , usuario_responsable = '" & (miusuario) & "' WHERE `n_pedidos_vendedor`= '" & (codigo_pedido) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
            grilla_documento.CurrentRow.Cells(10).Value = "ACEPTADO"
            'grilla_detalle_documento.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
        End If
        If estado = "ACEPTADO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "UPDATE pedidos_vendedor SET `estado`='RECHAZADO' , usuario_responsable = '" & (miusuario) & "' WHERE `n_pedidos_vendedor`= '" & (codigo_pedido) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
            grilla_documento.CurrentRow.Cells(10).Value = "RECHAZADO"
            'grilla_detalle_documento.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
        End If
        If estado = "RECHAZADO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "UPDATE pedidos_vendedor SET `estado`='EN ESPERA' , usuario_responsable = '" & (miusuario) & "' WHERE `n_pedidos_vendedor`= '" & (codigo_pedido) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
            grilla_documento.CurrentRow.Cells(10).Value = "EN ESPERA"
            'grilla_detalle_documento.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click

    End Sub
End Class