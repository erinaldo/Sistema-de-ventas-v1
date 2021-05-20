Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D

Public Class Form_registro_clientes_abono
    Dim peso As String
    Dim pesos As String
    Private WithEvents Pd As New PrintDocument
    Dim impresora_ticket_pedidos As String

    Private Sub Form_pregunta_pedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nombre_vendedor()
        cargar_logo()
        mostrar_impresora()
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
            impresora_ticket_pedidos = DS.Tables(DT.TableName).Rows(0).Item("ticket_pedidos")
        End If
        conexion.Close()
    End Sub

    Sub desglose_abono()
        peso = " PESOS"
        If CInt(txt_abono.Text) = 1000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & " DE PESOS"
        ElseIf CInt(txt_abono.Text) = 2000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 3000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 4000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 5000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 6000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 7000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 8000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 9000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 10000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 11000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 12000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 13000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 14000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 15000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 16000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 17000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 18000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 19000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 20000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 21000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 22000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 23000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 24000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 25000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 26000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 27000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 28000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 29000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"
        ElseIf CInt(txt_abono.Text) = 30000000 Then
            txt_desglose.Text = Num2Text(txt_abono.Text) & "DE PESOS"

        Else
            txt_desglose.Text = Num2Text(txt_abono.Text) & peso
        End If
    End Sub
    Sub grabar_detalle_pedido()
        Dim codigo_producto As String
        Dim proveedor As String
        Dim cantidad As String
        Dim descripcion As String
        Dim comentario As String
        Dim estado As String
        'Dim prioridad As String
        Dim fecha_llegada As String

        For i = 0 To Form_pedidos.grilla_pedidos.Rows.Count - 1
            codigo_producto = Form_pedidos.grilla_pedidos.Rows(i).Cells(0).Value.ToString
            proveedor = Form_pedidos.grilla_pedidos.Rows(i).Cells(7).Value.ToString
            cantidad = Form_pedidos.grilla_pedidos.Rows(i).Cells(2).Value.ToString
            descripcion = Form_pedidos.grilla_pedidos.Rows(i).Cells(3).Value.ToString
            comentario = Form_pedidos.grilla_pedidos.Rows(i).Cells(4).Value.ToString
            estado = Form_pedidos.grilla_pedidos.Rows(i).Cells(5).Value.ToString
            'prioridad = Form_pedidos.grilla_detalle.Rows(i).Cells(5).Value.ToString
            fecha_llegada = Form_pedidos.grilla_pedidos.Rows(i).Cells(6).Value.ToString

            If descripcion = "" Then
                descripcion = "-"
            End If
            If descripcion = " " Then
                descripcion = "-"
            End If
            If descripcion = "  " Then
                descripcion = "-"
            End If
            If descripcion = "   " Then
                descripcion = "-"
            End If

            If comentario = "" Then
                comentario = "-"
            End If
            If comentario = " " Then
                comentario = "-"
            End If
            If comentario = "  " Then
                comentario = "-"
            End If
            If comentario = "   " Then
                comentario = "-"
            End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_pedido (codigo_producto, proveedor, cantidad, descripcion, comentario, estado, prioridad, codigo_pedido, fecha_llegada) values('" & (codigo_producto) & "', '" & (proveedor) & "', '" & (cantidad) & "','" & (descripcion) & "','" & (comentario) & "','EN ESPERA', '" & (Form_pedidos.Combo_prioridad.Text) & "',  '" & (Form_pedidos.txt_codigo_pedido.Text) & "','" & (fecha_llegada) & "')"
            ' SC.CommandText = "insert into detalle_pedido (                                                                                                             codigo_producto,             proveedor,             cantidad,           descripcion,      comentario,        estado,              prioridad,                   codigo_pedido) values('" & (codigo_producto) & "', '" & (proveedor) & "', '" & (cantidad) & "','" & (descripcion) & "','" & (comentario) & "','EN ESPERA', '" & (prioridad) & "',  '" & (Form_pedidos.txt_codigo_pedido.Text) & "', '" & (miusuario) & "')"

            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub

    Sub grabar_deposito_repuesto_temporal()
        Dim codigo_producto As String
        Dim cantidad As String
        Dim descripcion As String
        Dim fecha_llegada As String
        Dim nombre_vendedor As String
        Dim telefono_vendedor As String

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "Select * from usuarios where rut_usuario = '" & (miusuario) & "'  "
        DA.SelectCommand = SC
        DA.Fill(DT)

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            nombre_vendedor = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
            telefono_vendedor = DS.Tables(DT.TableName).Rows(0).Item("telefono_usuario")
        End If
        conexion.Close()

        desglose_abono()



        For i = 0 To Form_pedidos.grilla_pedidos.Rows.Count - 1
            codigo_producto = Form_pedidos.grilla_pedidos.Rows(i).Cells(0).Value.ToString
            descripcion = Form_pedidos.grilla_pedidos.Rows(i).Cells(3).Value.ToString
            cantidad = Form_pedidos.grilla_pedidos.Rows(i).Cells(2).Value.ToString
            fecha_llegada = Form_pedidos.grilla_pedidos.Rows(i).Cells(6).Value.ToString

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            '  SC.CommandText = "insert into deposito_para_repuesto_temporal (codigo_pedido, nombre_cliente, nombre_vendedor, telefono_vendedor, rut_cliente, telefono_cliente, direccion_cliente, fecha_pedido, abono, codigo_producto, nombre_producto, cantidad_producto, fecha_llegada, desglose_abono) values('" & (Form_pedidos.txt_codigo_pedido.Text) & "', '" & (txt_nombre_cliente.Text) & "', '" & (nombre_vendedor) & "','" & (telefono_vendedor) & "','" & (txt_rut_cliente.Text) & "','" & (txt_telefono_cliente.Text) & "', '" & (txt_direccion_cliente.Text) & "',  '" & (Form_pedidos.dtp_fecha_pedido.Text) & "','" & (txt_abono.Text) & "' ,'" & (codigo_producto) & "','" & (descripcion) & "','" & (cantidad) & "','" & (fecha_llegada) & "','" & (txt_desglose.Text) & "' )"

            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub

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

    Sub grabar_pedido()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "insert into pedido (codigo_pedido, nombre_cliente,telefono_cliente, abono, fecha_pedido, usuario_responsable, rut_cliente, hora) values('" & (Form_pedidos.txt_codigo_pedido.Text) & "', '" & (txt_nombre_cliente.Text) & "', '" & (txt_telefono_cliente.Text) & "', '" & (txt_abono.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "','" & (miusuario) & "', '-', '" & (Form_menu_principal.lbl_hora.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        conexion.Close()
    End Sub


    'Sub llenar_combo_rut_cliente()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from clientes"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            Combo_rut_cliente.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub




    Private Sub Form_pregunta_pedido_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_pedidos.Enabled = True
        Form_pedidos.WindowState = FormWindowState.Normal
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub nombre_vendedor()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "Select * from usuarios where rut_usuario = '" & (miusuario) & "'  "
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            minombre = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
            mitelefono = DS.Tables(DT.TableName).Rows(0).Item("telefono_usuario")
        End If
        conexion.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Combo_prioridad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub



    'Private Sub txt_abono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_abono.BackColor = Color.LightBlue
    'End Sub

    Private Sub txt_abono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'Private Sub txt_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_abono.BackColor = Color.White
    'End Sub

    Private Sub txt_abono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_aceptar.BackColor = Color.LightBlue
    'End Sub

    'Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_aceptar.BackColor = Color.WhiteSmoke
    'End Sub

    'Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_cancelar.BackColor = Color.LightBlue
    'End Sub

    'Private Sub btn_cancelar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    'End Sub

    'Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_cancelar.BackColor = Color.WhiteSmoke
    'End Sub





    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_aceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim mensaje As String = ""
        If txt_nombre_cliente.Text = "" Then
            mensaje = "CAMPO NOMBRE CLIENTE VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            txt_nombre_cliente.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_telefono_cliente.Text = "" Then
            mensaje = "CAMPO TELEFONO CLIENTE VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            txt_telefono_cliente.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_abono.Text = "" Then
            mensaje = "CAMPO ABONO CLIENTE VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            txt_abono.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If


        lbl_mensaje.Visible = True
        Me.Enabled = False


        Form_pedidos.crear_codigo_pedido()
        grabar_pedido()
        grabar_detalle_pedido()
        'grabar_deposito_repuesto_temporal()
        desglose_abono()


        With Pd.PrinterSettings

            ' Especifico el nombre de la impresora 
            ' por donde deseo imprimir. 
            .PrinterName = impresora_ticket_pedidos
            ' Establezco el número de copias que se imprimirán 
            .Copies = 1
            ' Rango de páginas que se imprimirán 
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()
            Else
                MsgBox("LA IMPRESORA DE BOLETAS NO ES VALIDA", 0 + 16, "ERROR")
                Exit Sub
            End If

        End With



        With Pd.PrinterSettings

            ' Especifico el nombre de la impresora 
            ' por donde deseo imprimir. 
            .PrinterName = impresora_ticket_pedidos
            ' Establezco el número de copias que se imprimirán 
            .Copies = 1
            ' Rango de páginas que se imprimirán 
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()
            Else
                MsgBox("LA IMPRESORA DE BOLETAS NO ES VALIDA", 0 + 16, "ERROR")
                Exit Sub
            End If

        End With

        'With Pd.PrinterSettings

        '    ' Especifico el nombre de la impresora 
        '    ' por donde deseo imprimir. 
        '    .PrinterName = impresora_ticket
        '    ' Establezco el número de copias que se imprimirán 
        '    .Copies = 1
        '    ' Rango de páginas que se imprimirán 
        '    .PrintRange = PrintRange.AllPages
        '    If .IsValid Then
        '        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
        '        Pd.Print()
        '    Else
        '        MsgBox("LA IMPRESORA DE BOLETAS NO ES VALIDA", 0 + 16, "ERROR")
        '        Exit Sub
        '    End If
        'End With










        Form_pedidos.limpiar()

        Me.Enabled = True
        lbl_mensaje.Visible = False

        '  MsgBox("SE HA INGRESADO CORRECTAMENTE EL PEDIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        Form_pedidos.controles(False, True)
        Me.Close()
    End Sub

    'Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
    '    Dim format1 As New StringFormat(StringFormatFlags.NoClip)
    '    format1.Alignment = StringAlignment.Far

    '    Dim Font1 As New Font("arial", 7, FontStyle.Regular)
    '    Dim Font2 As New Font("arial", 9, FontStyle.Bold)
    '    Dim Font3 As New Font("arial", 7, FontStyle.Bold)
    '    Dim Font4 As New Font("arial", 8, FontStyle.Bold)

    '    Dim im As Image
    '    im = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
    '    Dim p As New PointF(0, 0)
    '    e.Graphics.DrawImage(im, p)

    '    e.Graphics.DrawString("             " & migiroempresa, Font3, Brushes.Black, 30, 60)
    '    e.Graphics.DrawString("      " & midireccionempresa, Font3, Brushes.Black, 30, 75)
    '    e.Graphics.DrawString("                       " & miciudadempresa, Font3, Brushes.Black, 30, 90)
    '    e.Graphics.DrawString("  " & mitelefonoempresa, Font3, Brushes.Black, 30, 105)
    '    e.Graphics.DrawString("      " & micorreoempresa, Font3, Brushes.Black, 30, 120)
    '    e.Graphics.DrawString("                           " & mirutempresa, Font3, Brushes.Black, 30, 135)

    '    e.Graphics.DrawString("DEPOSITO PARA ENCARGAR REPUESTO", Font2, Brushes.Black, 15, 165)

    '    e.Graphics.DrawString("COD. PREDIDO", Font3, Brushes.Black, 0, 195)
    '    e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 195)
    '    e.Graphics.DrawString(Form_pedidos.txt_codigo_pedido.Text, Font4, Brushes.Black, 80, 195)
    '    e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 210)
    '    e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 210)
    '    e.Graphics.DrawString(Form_pedidos.dtp_fecha_pedido.Text, Font1, Brushes.Black, 80, 210)
    '    e.Graphics.DrawString("CLIENTE", Font3, Brushes.Black, 0, 225)
    '    e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 225)
    '    e.Graphics.DrawString(txt_nombre_cliente.Text, Font1, Brushes.Black, 80, 225)
    '    e.Graphics.DrawString("TELEFONO", Font3, Brushes.Black, 0, 240)
    '    e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 240)
    '    e.Graphics.DrawString(txt_telefono_cliente.Text, Font1, Brushes.Black, 80, 240)
    '    'e.Graphics.DrawString("DIRECCION", Font3, Brushes.Black, 0, 255)
    '    'e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 255)
    '    'e.Graphics.DrawString(txt_direccion_cliente.Text, Font1, Brushes.Black, 80, 255)
    '    e.Graphics.DrawString("VENDEDOR", Font3, Brushes.Black, 0, 255)
    '    e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 255)
    '    e.Graphics.DrawString(minombre, Font1, Brushes.Black, 80, 255)
    '    e.Graphics.DrawString("TELEFONO", Font3, Brushes.Black, 0, 270)
    '    e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 270)
    '    e.Graphics.DrawString(mitelefono, Font1, Brushes.Black, 80, 270)
    '    e.Graphics.DrawString("ABONO", Font3, Brushes.Black, 0, 285)
    '    e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 285)
    '    e.Graphics.DrawString("$ " & txt_abono.Text, Font4, Brushes.Black, 80, 285)
    '    e.Graphics.DrawString("DESGLOSE", Font3, Brushes.Black, 0, 300)
    '    e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 300)
    '    e.Graphics.DrawString(txt_desglose.Text, Font1, Brushes.Black, 80, 300)

    '    e.Graphics.DrawString("CODIGO", Font3, Brushes.Black, 0, 330)
    '    e.Graphics.DrawString("DESCRIPCION", Font3, Brushes.Black, 65, 330)
    '    e.Graphics.DrawString("CANT.", Font3, Brushes.Black, 190, 330)
    '    e.Graphics.DrawString("LLEGADA", Font3, Brushes.Black, 230, 330)

    '    e.Graphics.DrawLine(Pens.Black, 1, 345, 300, 345)

    '    Dim codigo_producto As String
    '    Dim proveedor As String
    '    Dim cantidad As String
    '    Dim descripcion As String
    '    Dim comentario As String
    '    Dim estado As String

    '    Dim fecha_llegada As String

    '    For i = 0 To Form_pedidos.grilla_detalle.Rows.Count - 1
    '        codigo_producto = Form_pedidos.grilla_detalle.Rows(i).Cells(0).Value.ToString
    '        proveedor = Form_pedidos.grilla_detalle.Rows(i).Cells(7).Value.ToString
    '        cantidad = Form_pedidos.grilla_detalle.Rows(i).Cells(2).Value.ToString
    '        descripcion = Form_pedidos.grilla_detalle.Rows(i).Cells(3).Value.ToString
    '        comentario = Form_pedidos.grilla_detalle.Rows(i).Cells(4).Value.ToString
    '        estado = Form_pedidos.grilla_detalle.Rows(i).Cells(5).Value.ToString
    '        fecha_llegada = Form_pedidos.grilla_detalle.Rows(i).Cells(6).Value.ToString

    '        e.Graphics.DrawString(codigo_producto, Font1, Brushes.Gray, 0, 350 + (i * 15))
    '        e.Graphics.DrawString(descripcion, Font1, Brushes.Gray, 65, 350 + (i * 15))
    '        e.Graphics.DrawString(cantidad, Font1, Brushes.Gray, 218, 350 + (i * 15), format1)
    '        e.Graphics.DrawString(fecha_llegada, Font1, Brushes.Gray, 230, 350 + (i * 15))
    '    Next

    '    Dim var_grilla As Integer
    '    var_grilla = ((Form_pedidos.grilla_detalle.Rows.Count - 1) * 15)

    '    e.Graphics.DrawString("CONFIRME LA FECHA DE LLEGADA CON SU VENDEDOR", Font3, Brushes.Gray, 5, var_grilla + 600)
    '    e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, var_grilla + 660)
    'End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_pedidos.crear_codigo_pedido()
        desglose_abono()

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub


    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        Dim Font2 As New Font("arial", 10, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        'Dim im As Image

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Try
            Dim imagen_reporte As Image
            imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
            Dim posicion_imagen As New PointF(margen_izquierdo + 0, margen_superior + 0)
            e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
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



        'Dim rect1 As New Rectangle(10, 60, 270, 15)
        'Dim rect2 As New Rectangle(10, 75, 270, 15)
        'Dim rect3 As New Rectangle(10, 90, 270, 15)
        'Dim rect4 As New Rectangle(10, 105, 270, 15)
        'Dim rect5 As New Rectangle(10, 120, 270, 15)
        'Dim rect6 As New Rectangle(10, 135, 270, 15)

        'e.Graphics.DrawString(migiroempresa, Font4, Brushes.Black, rect1, stringFormat)
        'e.Graphics.DrawString(midireccionempresa, Font4, Brushes.Black, rect2, stringFormat)
        'e.Graphics.DrawString(miciudadempresa, Font4, Brushes.Black, rect3, stringFormat)
        'e.Graphics.DrawString(mitelefonoempresa, Font4, Brushes.Black, rect4, stringFormat)
        'e.Graphics.DrawString(micorreoempresa, Font4, Brushes.Black, rect5, stringFormat)
        'e.Graphics.DrawString(mirutempresa, Font4, Brushes.Black, rect6, stringFormat)



        Dim rect1 As New Rectangle(10, 90, 270, 15)
        Dim rect2 As New Rectangle(10, 105, 270, 15)
        Dim rect3 As New Rectangle(10, 120, 270, 15)
        Dim rect4 As New Rectangle(10, 135, 270, 15)
        Dim rect5 As New Rectangle(10, 150, 270, 15)
        Dim rect6 As New Rectangle(10, 165, 270, 15)

        e.Graphics.DrawString(migiroempresa, Font4, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font4, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font4, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font4, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font4, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font4, Brushes.Black, rect6, stringFormat)





        e.Graphics.DrawString("ABONO PARA ENCARGAR REPUESTO", Font2, Brushes.Black, 15, 195)

        e.Graphics.DrawString("COD. PEDIDO", Font3, Brushes.Black, 0, 225)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 225)
        e.Graphics.DrawString(Form_pedidos.txt_codigo_pedido.Text, Font3, Brushes.Black, 80, 225)

        e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 240)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 240)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font3, Brushes.Black, 80, 240)

        e.Graphics.DrawString("CLIENTE", Font3, Brushes.Black, 0, 255)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 255)
        e.Graphics.DrawString(txt_nombre_cliente.Text, Font3, Brushes.Black, 80, 255)

        e.Graphics.DrawString("TELEFONO", Font3, Brushes.Black, 0, 270)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 270)
        e.Graphics.DrawString(txt_telefono_cliente.Text, Font3, Brushes.Black, 80, 270)

        e.Graphics.DrawString("VENDEDOR", Font3, Brushes.Black, 0, 285)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 285)
        e.Graphics.DrawString(minombre, Font3, Brushes.Black, 80, 285)

        e.Graphics.DrawString("TELEFONO", Font3, Brushes.Black, 0, 300)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 300)
        e.Graphics.DrawString(mitelefono, Font3, Brushes.Black, 80, 300)

        e.Graphics.DrawString("ABONO", Font3, Brushes.Black, 0, 315)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 315)
        e.Graphics.DrawString("$ " & txt_abono.Text, Font3, Brushes.Black, 80, 315)

        e.Graphics.DrawString("DESGLOSE", Font3, Brushes.Black, 0, 330)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 330)
        e.Graphics.DrawString(txt_desglose.Text, Font3, Brushes.Black, 80, 330)

        e.Graphics.DrawString("CODIGO", Font3, Brushes.Black, 0, 360)
        e.Graphics.DrawString("DESCRIPCION", Font3, Brushes.Black, 65, 360)
        e.Graphics.DrawString("CANT.", Font3, Brushes.Black, 190, 360)
        e.Graphics.DrawString("LLEGADA", Font3, Brushes.Black, 230, 360)

        e.Graphics.DrawLine(Pens.Black, 1, 375, 300, 375)

        Dim codigo_producto As String
        Dim proveedor As String
        Dim cantidad As String
        Dim descripcion As String
        Dim comentario As String
        Dim estado As String

        Dim fecha_llegada As String

        For i = 0 To Form_pedidos.grilla_pedidos.Rows.Count - 1
            codigo_producto = Form_pedidos.grilla_pedidos.Rows(i).Cells(0).Value.ToString
            proveedor = Form_pedidos.grilla_pedidos.Rows(i).Cells(7).Value.ToString
            cantidad = Form_pedidos.grilla_pedidos.Rows(i).Cells(2).Value.ToString
            descripcion = Form_pedidos.grilla_pedidos.Rows(i).Cells(3).Value.ToString
            comentario = Form_pedidos.grilla_pedidos.Rows(i).Cells(4).Value.ToString
            estado = Form_pedidos.grilla_pedidos.Rows(i).Cells(5).Value.ToString
            fecha_llegada = Form_pedidos.grilla_pedidos.Rows(i).Cells(6).Value.ToString

            Dim descripcion_caracteres As String
            descripcion_caracteres = descripcion
            If descripcion.Length > 18 Then
                descripcion_caracteres = descripcion.Substring(0, 18)
            End If

            e.Graphics.DrawString(codigo_producto, Font3, Brushes.Gray, 0, 380 + (i * 15))
            e.Graphics.DrawString(descripcion_caracteres, Font3, Brushes.Gray, 65, 380 + (i * 15))
            e.Graphics.DrawString(cantidad, Font3, Brushes.Gray, 218, 380 + (i * 15), format1)
            e.Graphics.DrawString(fecha_llegada, Font3, Brushes.Gray, 230, 380 + (i * 15))
        Next

        Dim var_grilla As Integer
        var_grilla = ((Form_pedidos.grilla_pedidos.Rows.Count - 1) * 15)



        Dim rect12 As New Rectangle(10, var_grilla + 630, 275, 15)

        'e.Graphics.DrawString("CONFIRME LA LLEGADA CON SU VENDEDOR.", Font4, Brushes.Gray, 5, var_grilla + 600)
        e.Graphics.DrawString("CONFIRME LA LLEGADA CON SU VENDEDOR.", Font4, Brushes.Gray, rect12, stringFormat)



        'e.Graphics.DrawString("PARA COBRAR ESTE ABONO AL MOMENTO", Font2, Brushes.Black, 5, var_grilla + 630)
        'e.Graphics.DrawString("DE LA ENTREGA DE LA MERCADERÍA, SOLO", Font2, Brushes.Black, 5, var_grilla + 645)
        'e.Graphics.DrawString("SE RECIBE ESTE BOLETO ORIGINAL TIMBRADO,", Font2, Brushes.Black, 5, var_grilla + 660)
        'e.Graphics.DrawString("NO UNA COPIA NI OTRO MEDIO DONDE SE VEA", Font2, Brushes.Black, 5, var_grilla + 675)
        'e.Graphics.DrawString("LA IMAGEN.", Font2, Brushes.Black, 5, var_grilla + 690)


        Dim rect7 As New Rectangle(10, var_grilla + 660, 275, 15)
        Dim rect8 As New Rectangle(10, var_grilla + 675, 275, 15)
        Dim rect9 As New Rectangle(10, var_grilla + 690, 275, 15)
        Dim rect10 As New Rectangle(10, var_grilla + 705, 275, 15)
        Dim rect11 As New Rectangle(10, var_grilla + 720, 275, 15)



        e.Graphics.DrawString("DE LA ENTREGA DE LA MERCADERÍA, SOLO SE", Font4, Brushes.Black, rect8, stringFormat)
        e.Graphics.DrawString("RECIBE ESTE BOLETO ORIGINAL TIMBRADO,", Font4, Brushes.Black, rect9, stringFormat)
        e.Graphics.DrawString("NO UNA COPIA NI OTRO MEDIO DONDE SE VEA", Font4, Brushes.Black, rect10, stringFormat)
        e.Graphics.DrawString("LA IMAGEN.", Font4, Brushes.Black, rect11, stringFormat)




        e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, var_grilla + 770)
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
            txt_telefono_cliente.Focus()
        End If
    End Sub

    Private Sub txt_nombre_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.TextChanged

    End Sub

    Private Sub txt_telefono_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_telefono_cliente.KeyPress
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
            txt_abono.Focus()
        End If
    End Sub

    Private Sub txt_telefono_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telefono_cliente.TextChanged

    End Sub

    Private Sub txt_abono_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_abono.KeyPress
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
            btn_aceptar.Focus()
        End If
    End Sub

    Private Sub txt_abono_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_abono.TextChanged

    End Sub

    Private Sub btn_cancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub


    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        btn_aceptar.BackColor = Color.Transparent
    End Sub


    Private Sub txt_abono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_abono.GotFocus
        txt_abono.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_abono.LostFocus
        txt_abono.BackColor = Color.White
    End Sub

    Private Sub txt_nombre_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.GotFocus
        txt_nombre_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nombre_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.LostFocus
        txt_nombre_cliente.BackColor = Color.White
    End Sub

    Private Sub txt_telefono_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_telefono_cliente.GotFocus
        txt_telefono_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_telefono_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_telefono_cliente.LostFocus
        txt_telefono_cliente.BackColor = Color.White
    End Sub

    Private Sub lbl_mensaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mensaje.Click

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

    End Sub
End Class