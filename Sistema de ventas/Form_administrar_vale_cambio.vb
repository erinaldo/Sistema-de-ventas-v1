Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Public Class Form_administrar_vale_cambio
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim consulta_busqueda As String
    Private WithEvents Pd As New PrintDocument
    Dim alto_cotizacion As String
    Dim peso As String
    Dim cantidad_letras As Integer
    Dim desglose_palabras As String
    Private Sub Form_administrar_vale_cambio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_administrar_vale_cambio_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_administrar_vale_cambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_vendedor()

        Combo_vendedor.SelectedItem = minombre
        grilla_documento.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        grilla_detalle_documento.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        mostrar_malla()

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub llenar_combo_vendedor()
        Combo_vendedor.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            Combo_vendedor.Items.Add("TODOS")
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        conexion.Close()
    End Sub


    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub



    Sub mostrar_malla()
        fecha()


        conexion.Close()
        Dim DT3 As New DataTable

        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion

        SC3.CommandText = "select  NRO_VALE as 'CAMBIO', FECHA as 'FECHA', TOTAL_POSITIVO as 'ENTRA', TOTAL_NEGATIVO as 'SALE', SALDO_FAVOR_CLIENTE as 'SALDO', DOCUMENTO_REFERENCIA as 'DOC.', NRO_REFERENCIA 'NRO.', HORA as 'HORA', ESTADO as 'ESTADO', NOMBRE_USUARIO AS VENDEDOR, USUARIO_RESPONSABLE as 'RESPONSABLE', VENDEDOR_ENTRA as 'VENDEDOR ENTRA' from vale_cambio, usuarios, clientes  where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and vale_cambio.usuario_responsable=usuarios.rut_usuario group by nro_vale order by nro_vale desc"

        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        grilla_documento.DataSource = DS3.Tables(DT3.TableName)
        conexion.Close()

           grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_documento.Columns(4).Visible = False
        grilla_documento.Columns(10).Visible = False
        grilla_documento.Columns(11).Visible = False

        'For i = 0 To grilla_documento.Rows.Count - 1
        '    If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
        '        grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
        '    End If
        'Next

        grilla_detalle_documento.Rows.Clear()

      
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
        SC.CommandText = "select * from detalle_vale_cambio  where nro_vale= '" & (nro_doc) & "'"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_detalle_documento.Rows.Clear()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("movimiento"))
            Next
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

















    Sub mostrar_datos_vendedor()
        conexion.Close()
        If Combo_vendedor.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where nombre_usuario ='" & (Combo_vendedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If

            conexion.Close()
        End If
    End Sub



    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Combo_vendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_vendedor.KeyPress
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

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        lbl_mensaje.Visible = True
        Me.Enabled = False
        mostrar_datos_vendedor()


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

   





    Private Sub Combo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.GotFocus
        Combo_vendedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.LostFocus
        Combo_vendedor.BackColor = Color.White
    End Sub


    Private Sub migrilla_documentos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub

    Private Sub migrilla_documentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.Click

        Dim condicion As String


        If grilla_documento.Rows.Count <> 0 Then
            condicion = grilla_documento.CurrentRow.Cells(1).Value

         
        End If






        If grilla_documento.Rows.Count <> 0 Then
            mostrar_malla_detalle()
        End If



    End Sub









    Private Sub grilla_documento_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.DoubleClick


        If grilla_documento.Rows.Count = 0 Then
            Exit Sub
        End If

























        Dim condicion As String
        condicion = grilla_documento.CurrentRow.Cells(1).Value








    End Sub








    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub
End Class