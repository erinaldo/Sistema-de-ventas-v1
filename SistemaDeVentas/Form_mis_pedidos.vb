Imports System.IO

Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D

Public Class Form_mis_pedidos
    Dim peso As String
    Dim pesos As String
    Dim consulta_busqueda As String
    Private WithEvents Pd As New PrintDocument
    Dim xp As New System.Drawing.Printing.PrintDocument
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim impresora_ticket_pedidos As String

    Private Sub Form_mis_pedidos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_mis_pedidos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_mis_pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtp_desde.Value = dtp_desde.Value.AddDays(Val(-1))
        llenar_combo_vendedor()
        cargar_logo()
        Combo_vendedor.Text = minombre
        llenar_combo_proveedores_mas_pedidos()
        Timer_inactividad_mis_pedidos.Start()
        mostrar_impresora()
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
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

    Sub llenar_combo_proveedores_mas_pedidos()
        Combo_proveedor.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from proveedores_Mas_pedidos order by nombre_proveedor"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_proveedor"))
            Next
            Combo_proveedor.Items.Add("OTROS")
        End If
        conexion.Close()
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
        End If
        conexion.Close()
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

    Sub desglose_abono()
        peso = " PESOS"

        Dim abono As String
        abono = grilla_mis_pedidos.CurrentRow.Cells(10).Value()

        txt_abono.Text = abono

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

    Sub grabar_deposito_repuesto_temporal()




        Dim codigo_pedido As String
        Dim VarCodPedido As String
        Dim vendedor As String
        Dim codigo As String
        Dim proveedor As String
        Dim cantidad As String
        Dim descripcion As String
        Dim comentario As String
        Dim prioridad As String
        Dim fecha As String
        Dim estado As String
        Dim abono As String
        Dim fecha_llegada As String
        Dim telefono_vendedor As String
        Dim direccion_cliente As String
        Dim telefono_cliente As String
        Dim rut_cliente As String
        Dim nombre_cliente As String

        rut_cliente = ""
        direccion_cliente = ""

        VarCodPedido = grilla_mis_pedidos.CurrentRow.Cells(0).Value()

        For i = 0 To grilla_mis_pedidos.Rows.Count - 1
            codigo_pedido = grilla_mis_pedidos.Rows(i).Cells(0).Value
            vendedor = grilla_mis_pedidos.Rows(i).Cells(1).Value.ToString
            codigo = grilla_mis_pedidos.Rows(i).Cells(2).Value.ToString
            proveedor = grilla_mis_pedidos.Rows(i).Cells(3).Value.ToString
            cantidad = grilla_mis_pedidos.Rows(i).Cells(4).Value.ToString
            estado = grilla_mis_pedidos.Rows(i).Cells(5).Value.ToString
            descripcion = grilla_mis_pedidos.Rows(i).Cells(6).Value.ToString
            comentario = grilla_mis_pedidos.Rows(i).Cells(7).Value.ToString
            prioridad = grilla_mis_pedidos.Rows(i).Cells(8).Value.ToString
            fecha = grilla_mis_pedidos.Rows(i).Cells(9).Value.ToString
            abono = grilla_mis_pedidos.Rows(i).Cells(10).Value.ToString
            fecha_llegada = grilla_mis_pedidos.Rows(i).Cells(11).Value.ToString
            telefono_vendedor = grilla_mis_pedidos.Rows(i).Cells(12).Value.ToString
            telefono_cliente = grilla_mis_pedidos.Rows(i).Cells(13).Value.ToString
            nombre_cliente = grilla_mis_pedidos.Rows(i).Cells(14).Value.ToString

            If codigo_pedido = VarCodPedido Then


                desglose_abono()
                conexion.Close()
                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()

                SC3.Connection = conexion
                SC3.CommandText = "insert into deposito_para_repuesto_temporal (codigo_pedido, nombre_cliente, nombre_vendedor, telefono_vendedor, rut_cliente, telefono_cliente, direccion_cliente, fecha_pedido, abono, codigo_producto, nombre_producto, cantidad_producto, fecha_llegada, desglose_abono) values('" & (codigo_pedido) & "', '" & (nombre_cliente) & "', '" & (vendedor) & "','" & (telefono_vendedor) & "','" & (rut_cliente) & "','" & (telefono_cliente) & "', '" & (direccion_cliente) & "',  '" & (fecha) & "','" & (abono) & "' ,'" & (codigo) & "','" & (descripcion) & "','" & (cantidad) & "','" & (fecha_llegada) & "','" & (txt_desglose.Text) & "' )"
                ' SC.CommandText = "insert into detalle_pedido (                                                                                                             codigo_producto,             proveedor,             cantidad,           descripcion,      comentario,        estado,              prioridad,                   codigo_pedido) values('" & (codigo_producto) & "', '" & (proveedor) & "', '" & (cantidad) & "','" & (descripcion) & "','" & (comentario) & "','EN ESPERA', '" & (prioridad) & "',  '" & (Form_pedidos.txt_codigo_pedido.Text) & "', '" & (miusuario) & "')"

                DA3.SelectCommand = SC3
                DA3.Fill(DT3)
                conexion.Close()
            End If
        Next
    End Sub



    'Sub mostrar_pedidos()
    '    grilla_pedido.Rows.Clear()
    '    DS.Tables.Clear()
    '    DT.Columns.Clear()
    '    DT.Rows.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores, clientes where fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.rut_cliente=clientes.rut  and detalle_pedido.proveedor=proveedores.rut_proveedor  order by pedido.codigo_pedido asc"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        Dim codigo_pedido As String
    '        Dim vendedor As String
    '        Dim codigo As String
    '        Dim proveedor As String
    '        Dim cantidad As String
    '        Dim descripcion As String
    '        Dim comentario As String
    '        Dim prioridad As String
    '        Dim fecha As String
    '        Dim estado As String
    '        Dim abono As String
    '        Dim fecha_llegada As String
    '        Dim telefono_vendedor As String
    '        Dim direccion_cliente As String
    '        Dim telefono_cliente As String
    '        Dim rut_cliente As String
    '        Dim nombre_cliente As String

    '        Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '            vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '            codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '            proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '            cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '            descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '            comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '            prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '            fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '            estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '            abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '            fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '            telefono_vendedor = DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario")
    '            direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion")
    '            telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono")
    '            rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut")
    '            nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre")


    '            grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, estado, descripcion, comentario, prioridad, fecha, abono, fecha_llegada, telefono_vendedor, direccion_cliente, telefono_cliente, rut_cliente, nombre_cliente)
    '        Next
    '    End If
    '    conexion.Close()

    '    Dim estado_revision As String
    '    estado_revision = grilla1.CurrentRow.Cells(9).Value
    '    For i = 0 To grilla_pedido.Rows.Count - 1
    '        estado_revision = grilla_pedido.Rows(i).Cells(5).Value.ToString
    '        If estado_revision = "RECEPCIONADO" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
    '        End If

    '        If estado_revision = "ENCARGADO" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '        End If

    '        If estado_revision = "NO DISPONIBLE" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '        End If
    '    Next
    'End Sub

    'Sub mostrar_pedidos_por_codigo()
    '    grilla_pedido.Rows.Clear()
    '    DS.Tables.Clear()
    '    DT.Columns.Clear()
    '    DT.Rows.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from pedido, detalle_pedido, usuarios, clientes, proveedores where pedido.codigo_pedido ='" & (txt_codigo_pedido.Text) & "'  and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.rut_cliente=clientes.rut and detalle_pedido.proveedor=proveedores.rut_proveedor  order by pedido.codigo_pedido asc"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        Dim codigo_pedido As String
    '        Dim vendedor As String
    '        Dim codigo As String
    '        Dim proveedor As String
    '        Dim cantidad As String
    '        Dim descripcion As String
    '        Dim comentario As String
    '        Dim prioridad As String
    '        Dim fecha As String
    '        Dim estado As String
    '        Dim abono As String
    '        Dim fecha_llegada As String
    '        Dim telefono_vendedor As String
    '        Dim direccion_cliente As String
    '        Dim telefono_cliente As String
    '        Dim rut_cliente As String
    '        Dim nombre_cliente As String

    '        Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '            vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '            codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '            proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '            cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '            descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '            comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '            prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '            fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '            estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '            abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '            fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '            telefono_vendedor = DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario")
    '            direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion")
    '            telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono")
    '            rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut")
    '            nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre")


    '            grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, estado, descripcion, comentario, prioridad, fecha, abono, fecha_llegada, telefono_vendedor, direccion_cliente, telefono_cliente, rut_cliente, nombre_cliente)
    '        Next
    '    End If
    '    conexion.Close()

    '    Dim estado_revision As String
    '    estado_revision = grilla1.CurrentRow.Cells(9).Value
    '    For i = 0 To grilla_pedido.Rows.Count - 1
    '        estado_revision = grilla_pedido.Rows(i).Cells(5).Value.ToString
    '        If estado_revision = "RECEPCIONADO" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
    '        End If
    '        If estado_revision = "ENCARGADO" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '        End If
    '        If estado_revision = "NO DISPONIBLE" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '        End If
    '    Next
    'End Sub

    'Sub mostrar_pedidos_por_vendedor()
    '    If Combo_vendedor.Text <> "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, clientes, proveedores where nombre_usuario ='" & (Combo_vendedor.Text) & "' and  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.rut_cliente=clientes.rut  and detalle_pedido.proveedor=proveedores.rut_proveedor order by pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String

    '            Dim fecha_llegada As String
    '            Dim telefono_vendedor As String
    '            Dim direccion_cliente As String
    '            Dim telefono_cliente As String
    '            Dim rut_cliente As String
    '            Dim nombre_cliente As String

    '            Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                telefono_vendedor = DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario")
    '                direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion")
    '                telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono")
    '                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut")
    '                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre")

    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, estado, descripcion, comentario, prioridad, fecha, abono, fecha_llegada, telefono_vendedor, direccion_cliente, telefono_cliente, rut_cliente, nombre_cliente)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(5).Value.ToString
    '            If estado_revision = "RECEPCIONADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
    '            End If
    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If

    '    If Combo_vendedor.Text = "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, clientes, proveedores where  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.rut_cliente=clientes.rut  and detalle_pedido.proveedor=proveedores.rut_proveedor order by pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String

    '            Dim fecha_llegada As String
    '            Dim telefono_vendedor As String
    '            Dim direccion_cliente As String
    '            Dim telefono_cliente As String
    '            Dim rut_cliente As String
    '            Dim nombre_cliente As String

    '            Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                telefono_vendedor = DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario")
    '                direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion")
    '                telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono")
    '                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut")
    '                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre")

    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, estado, descripcion, comentario, prioridad, fecha, abono, fecha_llegada, telefono_vendedor, direccion_cliente, telefono_cliente, rut_cliente, nombre_cliente)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(5).Value.ToString
    '            If estado_revision = "RECEPCIONADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
    '            End If
    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If
    'End Sub

    'Sub mostrar_pedidos_por_proveedor()
    '    If Combo_proveedor.Text <> "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, clientes, proveedores where nombre_PROVEEDOR ='" & (Combo_proveedor.Text) & "' and  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.rut_cliente=clientes.rut   and detalle_pedido.proveedor=proveedores.rut_proveedor   order by pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String

    '            Dim fecha_llegada As String
    '            Dim telefono_vendedor As String
    '            Dim direccion_cliente As String
    '            Dim telefono_cliente As String
    '            Dim rut_cliente As String
    '            Dim nombre_cliente As String

    '            Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                telefono_vendedor = DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario")
    '                direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion")
    '                telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono")
    '                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut")
    '                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre")

    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, estado, descripcion, comentario, prioridad, fecha, abono, fecha_llegada, telefono_vendedor, direccion_cliente, telefono_cliente, rut_cliente, nombre_cliente)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(5).Value.ToString
    '            If estado_revision = "RECEPCIONADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
    '            End If

    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If

    '    If Combo_proveedor.Text = "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, clientes, proveedores where  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.rut_cliente=clientes.rut   and detalle_pedido.proveedor=proveedores.rut_proveedor   order by pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String

    '            Dim fecha_llegada As String
    '            Dim telefono_vendedor As String
    '            Dim direccion_cliente As String
    '            Dim telefono_cliente As String
    '            Dim rut_cliente As String
    '            Dim nombre_cliente As String

    '            Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                telefono_vendedor = DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario")
    '                direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion")
    '                telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono")
    '                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut")
    '                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre")

    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, estado, descripcion, comentario, prioridad, fecha, abono, fecha_llegada, telefono_vendedor, direccion_cliente, telefono_cliente, rut_cliente, nombre_cliente)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(5).Value.ToString
    '            If estado_revision = "RECEPCIONADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
    '            End If

    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If
    'End Sub

    'Sub mostrar_pedidos_por_prioridad()
    '    If Combo_prioridad.Text <> "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, clientes, proveedores where prioridad ='" & (Combo_prioridad.Text) & "' and  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.rut_cliente=clientes.rut  and detalle_pedido.proveedor=proveedores.rut_proveedor   order by pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String

    '            Dim fecha_llegada As String
    '            Dim telefono_vendedor As String
    '            Dim direccion_cliente As String
    '            Dim telefono_cliente As String
    '            Dim rut_cliente As String
    '            Dim nombre_cliente As String

    '            Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                telefono_vendedor = DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario")
    '                direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion")
    '                telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono")
    '                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut")
    '                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre")

    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, estado, descripcion, comentario, prioridad, fecha, abono, fecha_llegada, telefono_vendedor, direccion_cliente, telefono_cliente, rut_cliente, nombre_cliente)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(5).Value.ToString
    '            If estado_revision = "RECEPCIONADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
    '            End If

    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If

    '    If Combo_prioridad.Text = "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, clientes, proveedores where  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.rut_cliente=clientes.rut  and detalle_pedido.proveedor=proveedores.rut_proveedor   order by pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String

    '            Dim fecha_llegada As String
    '            Dim telefono_vendedor As String
    '            Dim direccion_cliente As String
    '            Dim telefono_cliente As String
    '            Dim rut_cliente As String
    '            Dim nombre_cliente As String

    '            Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                telefono_vendedor = DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario")
    '                direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion")
    '                telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono")
    '                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut")
    '                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre")

    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, estado, descripcion, comentario, prioridad, fecha, abono, fecha_llegada, telefono_vendedor, direccion_cliente, telefono_cliente, rut_cliente, nombre_cliente)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(5).Value.ToString
    '            If estado_revision = "RECEPCIONADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
    '            End If

    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If
    'End Sub


    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        'mostrar_pedidos()
        'Combo_vendedor.Text = ""
        'Combo_proveedor.Text = ""
        'Combo_prioridad.Text = ""
        'txt_codigo_pedido.Text = ""

        'If Combo_vendedor.Text = "" And Combo_proveedor.Text = "" And Combo_prioridad.Text = "" And txt_codigo_pedido.Text = "" Then
        '    mostrar_pedidos()
        'End If

        'If Combo_vendedor.Text <> "" Then
        '    mostrar_pedidos_por_vendedor()
        'End If
        'If Combo_proveedor.Text <> "" Then
        '    mostrar_pedidos_por_proveedor()
        'End If
        'If Combo_prioridad.Text <> "" Then
        '    mostrar_pedidos_por_prioridad()
        'End If
        'If txt_codigo_pedido.Text <> "" Then
        '    mostrar_pedidos_por_codigo()
        'End If
        fecha()
        busqueda()
    End Sub

    Private Sub dtp2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        'mostrar_pedidos()
        'Combo_vendedor.Text = ""
        'Combo_proveedor.Text = ""
        'Combo_prioridad.Text = ""
        'txt_codigo_pedido.Text = ""

        'If Combo_vendedor.Text = "" And Combo_proveedor.Text = "" And Combo_prioridad.Text = "" And txt_codigo_pedido.Text = "" Then
        '    mostrar_pedidos()
        'End If

        'If Combo_vendedor.Text <> "" Then
        '    mostrar_pedidos_por_vendedor()
        'End If
        'If Combo_proveedor.Text <> "" Then
        '    mostrar_pedidos_por_proveedor()
        'End If
        'If Combo_prioridad.Text <> "" Then
        '    mostrar_pedidos_por_prioridad()
        'End If
        'If txt_codigo_pedido.Text <> "" Then
        '    mostrar_pedidos_por_codigo()
        'End If

        fecha()
        busqueda()
    End Sub

    Sub llenar_combo_proveedor()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from proveedores order by nombre_proveedor"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Combo_proveedor.Items.Add("TODOS")
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"))
            Next
        End If
        conexion.Close()
    End Sub

    Sub llenar_combo_vendedor()
        Try
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where ACTIVO='SI' order by nombre_usuario"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Combo_vendedor.Items.Add("TODOS")
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Combo_vendedor.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))
                Next
            End If
            'Combo_vendedor.Items.Add("TODOS")
            conexion.Close()



            conexion.Close()
        Catch err As InvalidCastException
            conexion.Close()
        End Try
    End Sub

    Private Sub grilla1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub txt_codigo_pedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_pedido.KeyPress
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
            mostrar_pedidos_por_codigo()
            Combo_vendedor.Text = ""
            Combo_proveedor.Text = ""
            Combo_prioridad.Text = ""
        End If
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    'Sub busqueda()

    '    'opciones()
    '    grilla_pedido.Rows.Clear()
    '    DS.Tables.Clear()
    '    DT.Columns.Clear()
    '    DT.Rows.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores, clientes where fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.rut_cliente=clientes.rut  and detalle_pedido.proveedor=proveedores.rut_proveedor  and detalle_pedido.descripcion Like '" & ("%" & txt_buscar.Text & "%") & "'  order by pedido.codigo_pedido asc"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        Dim codigo_pedido As String
    '        Dim vendedor As String
    '        Dim codigo As String
    '        Dim proveedor As String
    '        Dim cantidad As String
    '        Dim descripcion As String
    '        Dim comentario As String
    '        Dim prioridad As String
    '        Dim fecha As String
    '        Dim estado As String
    '        Dim abono As String
    '        Dim fecha_llegada As String
    '        Dim telefono_vendedor As String
    '        Dim direccion_cliente As String
    '        Dim telefono_cliente As String
    '        Dim rut_cliente As String
    '        Dim nombre_cliente As String

    '        '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '            vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '            codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '            proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '            cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '            descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '            comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '            prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '            fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '            estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '            abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '            fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '            telefono_vendedor = DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario")
    '            direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion")
    '            telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono")
    '            rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut")
    '            nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre")


    '            grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, estado, descripcion, comentario, prioridad, fecha, abono, fecha_llegada, telefono_vendedor, direccion_cliente, telefono_cliente, rut_cliente, nombre_cliente)
    '        Next
    '    End If
    '    conexion.Close()

    '    Dim estado_revision As String
    '    'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '    For i = 0 To grilla_pedido.Rows.Count - 1
    '        estado_revision = grilla_pedido.Rows(i).Cells(5).Value.ToString
    '        If estado_revision = "RECEPCIONADO" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
    '        End If

    '        If estado_revision = "ENCARGADO" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '        End If

    '        If estado_revision = "NO DISPONIBLE" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '        End If
    '    Next
    'End Sub















    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        busqueda_por_descripcion()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar.KeyPress
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
            lbl_mensaje.Visible = True
            Me.Enabled = False
            busqueda_por_descripcion()
            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If
    End Sub

    Sub busqueda()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim texto_estado As String
        Dim texto_prioridad As String
        Dim texto_proveedor As String
        Dim texto_vendedor As String

        texto_estado = Combo_estado.Text
        texto_prioridad = Combo_prioridad.Text
        texto_proveedor = Combo_proveedor.Text
        texto_vendedor = Combo_vendedor.Text

        If Combo_estado.Text = "TODOS" Then
            Combo_estado.Text = ""
        End If
        If Combo_prioridad.Text = "TODOS" Then
            Combo_prioridad.Text = ""
        End If
        If Combo_proveedor.Text = "TODOS" Then
            Combo_proveedor.Text = ""
        End If
        If Combo_vendedor.Text = "TODOS" Then
            Combo_vendedor.Text = ""
        End If



        If Combo_vendedor.Text <> "" Then
            consulta_busqueda = "select  PEDIDO.codigo_pedido AS 'PEDIDO', nombre_usuario AS 'VENDEDOR',codigo_producto AS 'COD. PRODUCTO', PROVEEDOR AS 'PROVEEDOR', cantidad AS 'CANT.', estado AS 'ESTADO', descripcion AS 'DESCRIPCION', comentario AS 'COMENTARIO',prioridad AS 'PRIORIDAD', fecha_pedido AS 'FECHA', abono AS 'ABONO', fecha_llegada AS 'LLEGADA', telefono_usuario AS 'TELEFONO VENDEDOR',  pedido.telefono_cliente AS 'TELEFONO CLIENTE', pedido.nombre_cliente AS  CLIENTE, PEDIDO.hora as 'HORA' from pedido, detalle_pedido, usuarios where fecha_pedido >='" & (mifecha2) & "' and fecha_pedido <= '" & (mifecha4) & "' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and nombre_usuario ='" & (Combo_vendedor.Text) & "'"
        Else
            consulta_busqueda = "select  PEDIDO.codigo_pedido AS 'PEDIDO', nombre_usuario AS 'VENDEDOR',codigo_producto AS 'COD. PRODUCTO', PROVEEDOR AS 'PROVEEDOR', cantidad AS 'CANT.', estado AS 'ESTADO', descripcion AS 'DESCRIPCION', comentario AS 'COMENTARIO',prioridad AS 'PRIORIDAD', fecha_pedido AS 'FECHA', abono AS 'ABONO', fecha_llegada AS 'LLEGADA', telefono_usuario AS 'TELEFONO VENDEDOR',  pedido.telefono_cliente AS 'TELEFONO CLIENTE', pedido.nombre_cliente AS  CLIENTE , PEDIDO.hora as 'HORA'from pedido, detalle_pedido, usuarios where fecha_pedido >='" & (mifecha2) & "' and fecha_pedido <= '" & (mifecha4) & "' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario"
        End If

        If Combo_proveedor.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and proveedor ='" & (Combo_proveedor.Text) & "'"
        Else
            consulta_busqueda = consulta_busqueda
        End If

        If Combo_estado.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and estado ='" & (Combo_estado.Text) & "'"
        Else
            consulta_busqueda = consulta_busqueda
        End If

        If Combo_prioridad.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and prioridad ='" & (Combo_prioridad.Text) & "'"
        Else
            consulta_busqueda = consulta_busqueda
        End If

        conexion.Close()
        Dim DT4 As New DataTable
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        conexion.Open()

        SC4.Connection = conexion
        SC4.CommandText = consulta_busqueda
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)

        grilla_mis_pedidos.DataSource = DS4.Tables(DT4.TableName)
        conexion.Close()

        Dim estado_revision As String
        For i = 0 To grilla_mis_pedidos.Rows.Count - 1
            estado_revision = grilla_mis_pedidos.Rows(i).Cells(5).Value.ToString
            If estado_revision = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If estado_revision = "RECEPCIONADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

            If estado_revision = "ENCARGADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

            If estado_revision = "NO DISPONIBLE" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If

            If estado_revision = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            Dim prioridad As String
            prioridad = grilla_mis_pedidos.Rows(i).Cells(8).Value.ToString

            If prioridad = "COTIZAR" Then

                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If

            If prioridad = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If
        Next

        Combo_estado.Text = texto_estado
        Combo_prioridad.Text = texto_prioridad
        Combo_proveedor.Text = texto_proveedor
        Combo_vendedor.Text = texto_vendedor

        'For Each col As DataGridViewColumn In Me.grilla_mis_pedidos.Columns
        '    ' Las columnas sólo se pueden ordenar mediante programaciòn.
        '    col.SortMode = DataGridViewColumnSortMode.NotSortable
        'Next
        grilla_mis_pedidos.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        grilla_mis_pedidos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_mis_pedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_mis_pedidos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_mis_pedidos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_mis_pedidos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_mis_pedidos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        lbl_mensaje.Visible = False
        Me.Enabled = True
        Exit Sub
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

    Private Sub Combo_vendedor_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        fecha()
        busqueda()
    End Sub

    Private Sub Combo_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_proveedor.KeyPress
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

    Private Sub Combo_proveedor_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_proveedor.SelectedIndexChanged
        fecha()
        busqueda()
    End Sub

    Private Sub Combo_estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_estado.KeyPress
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

    Private Sub Combo_estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_estado.SelectedIndexChanged
        fecha()
        busqueda()
    End Sub

    Private Sub Combo_prioridad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_prioridad.KeyPress
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

    Private Sub Combo_prioridad_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_prioridad.SelectedIndexChanged
        fecha()
        busqueda()
    End Sub

    Sub mostrar_pedidos_por_codigo()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        consulta_busqueda = "select  PEDIDO.codigo_pedido AS 'COD. PEDIDO', nombre_usuario AS 'VENDEDOR',codigo_producto AS 'COD. PRODUCTO', PROVEEDOR AS 'PROVEEDOR', cantidad AS 'CANT.', estado AS 'ESTADO', descripcion AS 'DESCRIPCION', comentario AS 'COMENTARIO',prioridad AS 'PRIORIDAD', fecha_pedido AS 'FECHA', abono AS 'ABONO', fecha_llegada AS 'LLEGADA', telefono_usuario AS 'TELEFONO VENDEDOR', PEDIDO.telefono_cliente AS 'TELEFONO CLIENTE', PEDIDO.nombre_cliente AS 'NOMBRE CLIENTE', PEDIDO.hora as 'HORA PEDIDO' from pedido, detalle_pedido, usuarios  where pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.codigo_pedido ='" & (txt_codigo_pedido.Text) & "'"

        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()

        'SC.Connection = conexion
        'SC.CommandText = consulta_busqueda
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'grilla_estado_de_cuenta_final.DataSource = DS.Tables(DT.TableName)
        'conexion.Close()




        conexion.Close()
        Dim DT4 As New DataTable

        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        conexion.Open()

        SC4.Connection = conexion
        SC4.CommandText = consulta_busqueda
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)

        grilla_mis_pedidos.DataSource = DS4.Tables(DT4.TableName)
        conexion.Close()





















        Dim prioridad As String
        Dim estado_revision As String



        For i = 0 To grilla_mis_pedidos.Rows.Count - 1
            estado_revision = grilla_mis_pedidos.Rows(i).Cells(5).Value.ToString
            prioridad = grilla_mis_pedidos.Rows(i).Cells(8).Value.ToString

            If estado_revision = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If estado_revision = "RECEPCIONADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

            If estado_revision = "ENCARGADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

            If estado_revision = "NO DISPONIBLE" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If

            If estado_revision = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If prioridad = "COTIZAR" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If

            If prioridad = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If
        Next









        'For Each col As DataGridViewColumn In Me.grilla_mis_pedidos.Columns
        '    ' Las columnas sólo se pueden ordenar mediante programaciòn.
        '    col.SortMode = DataGridViewColumnSortMode.NotSortable
        'Next
        grilla_mis_pedidos.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        grilla_mis_pedidos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_mis_pedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_mis_pedidos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_mis_pedidos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_mis_pedidos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_mis_pedidos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter







        lbl_mensaje.Visible = False
        Me.Enabled = True
        Exit Sub
    End Sub

    Private Sub migrilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub migrilla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Sub busqueda_por_descripcion()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        'consulta_busqueda = "select  PEDIDO.codigo_pedido AS 'COD. PEDIDO', nombre_usuario AS 'VENDEDOR',codigo_producto AS 'COD. PRODUCTO', proveedor AS 'PROVEEDOR', cantidad AS 'CANT.', estado AS 'ESTADO', descripcion AS 'DESCRIPCION', comentario AS 'COMENTARIO',prioridad AS 'PRIORIDAD', fecha_pedido AS 'FECHA', abono AS 'ABONO', fecha_llegada AS 'LLEGADA', telefono_usuario AS 'TELEFONO VENDEDOR', pedido.telefono_cliente AS 'TELEFONO CLIENTE', pedido.nombre_cliente AS 'NOMBRE CLIENTE' from pedido, detalle_pedido, usuarios where  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.descripcion Like '" & ("%" & txt_buscar.Text & "%") & "'"






        'conexion.Close()
        'DS4.Tables.Clear()
        'DT4.Rows.Clear()
        'DT4.Columns.Clear()
        'DS4.Clear()
        'conexion.Open()

        'SC4.Connection = conexion
        'SC4.CommandText = consulta_busqueda
        'DA4.SelectCommand = SC4
        'DA4.Fill(DT4)
        'DS4.Tables.Add(DT4)

        'grilla_mis_pedidos.DataSource = DS4.Tables(DT4.TableName)
        'conexion.Close()





        'Dim prioridad As String
        'Dim estado_revision As String



        'For i = 0 To grilla_mis_pedidos.Rows.Count - 1
        '    estado_revision = grilla_mis_pedidos.Rows(i).Cells(5).Value.ToString
        '    prioridad = grilla_mis_pedidos.Rows(i).Cells(8).Value.ToString

        '    If estado_revision = "COTIZADO" Then
        '        grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
        '    End If

        '    If estado_revision = "RECEPCIONADO" Then
        '        grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
        '    End If

        '    If estado_revision = "ENCARGADO" Then
        '        grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
        '    End If

        '    If estado_revision = "NO DISPONIBLE" Then
        '        grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
        '    End If

        '    If estado_revision = "COTIZADO" Then
        '        grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
        '    End If

        '    If prioridad = "COTIZAR" Then
        '        grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
        '    End If

        '    If prioridad = "COTIZADO" Then
        '        grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
        '    End If
        'Next








        ''For Each col As DataGridViewColumn In Me.grilla_mis_pedidos.Columns
        ''    ' Las columnas sólo se pueden ordenar mediante programaciòn.
        ''    col.SortMode = DataGridViewColumnSortMode.NotSortable
        ''Next
        'grilla_mis_pedidos.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        'grilla_mis_pedidos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_mis_pedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_mis_pedidos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grilla_mis_pedidos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_mis_pedidos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter







































        consulta_busqueda = "select  PEDIDO.codigo_pedido AS 'COD. PEDIDO', nombre_usuario AS 'VENDEDOR',codigo_producto AS 'COD. PRODUCTO', proveedor AS 'PROVEEDOR', cantidad AS 'CANT.', estado AS 'ESTADO', descripcion AS 'DESCRIPCION', comentario AS 'COMENTARIO',prioridad AS 'PRIORIDAD', fecha_pedido AS 'FECHA', abono AS 'ABONO', fecha_llegada AS 'LLEGADA', telefono_usuario AS 'TELEFONO VENDEDOR', pedido.telefono_cliente AS 'TELEFONO CLIENTE', pedido.nombre_cliente AS 'NOMBRE CLIENTE', PEDIDO.hora as 'HORA PEDIDO' from pedido, detalle_pedido, usuarios where  fecha_pedido >='" & (mifecha2) & "' and fecha_pedido <= '" & (mifecha4) & "' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario "



        ' consulta_busqueda = "select PEDIDO.codigo_pedido as 'COD. PEDIDO',USUARIOS.nombre_usuario as 'VENDEDOR',DETALLE_PEDIDO.codigo_producto as 'COD. PRODUCTO',proveedor as 'PROVEEDOR',DETALLE_PEDIDO.cantidad as 'CANT.',DETALLE_PEDIDO.descripcion as 'DESCRIP.',DETALLE_PEDIDO.comentario as 'COMENT.',DETALLE_PEDIDO.prioridad as 'PRIORIDAD',PEDIDO.fecha_pedido as 'FECHA PEDIDO',DETALLE_PEDIDO.estado as 'ESTADO',PEDIDO.abono as 'ABONO',DETALLE_PEDIDO.fecha_llegada as 'LLEGADA' from pedido, detalle_pedido, usuarios where fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "' AND ESTADO <> 'EN ESPERA' AND ESTADO <> 'NO DISPONIBLE' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario "


        Dim cadena As String
        Dim tabla() As String
        Dim n As Integer

        cadena = txt_buscar.Text
        '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
        tabla = Split(cadena, " ")

        For n = 0 To UBound(tabla, 1)
            consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',DETALLE_PEDIDO.codigo_producto, PROVEEDOR, DETALLE_PEDIDO.descripcion, DETALLE_PEDIDO.comentario) LIKE '" & ("%" & tabla(n) & "%") & "'"
        Next

        grilla_mis_pedidos.DataSource = Nothing

        Dim DT As New DataTable

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = consulta_busqueda
        DA.SelectCommand = SC

        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_mis_pedidos.DataSource = DS.Tables(DT.TableName)
        conexion.Close()















        Dim prioridad As String
        Dim estado_revision As String



        For i = 0 To grilla_mis_pedidos.Rows.Count - 1
            estado_revision = grilla_mis_pedidos.Rows(i).Cells(5).Value.ToString
            prioridad = grilla_mis_pedidos.Rows(i).Cells(8).Value.ToString

            If estado_revision = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If estado_revision = "RECEPCIONADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

            If estado_revision = "ENCARGADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

            If estado_revision = "NO DISPONIBLE" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If

            If estado_revision = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If prioridad = "COTIZAR" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If

            If prioridad = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If
        Next











        'For Each col As DataGridViewColumn In Me.grilla_mis_pedidos.Columns
        '    ' Las columnas sólo se pueden ordenar mediante programaciòn.
        '    col.SortMode = DataGridViewColumnSortMode.NotSortable
        'Next
        grilla_mis_pedidos.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        grilla_mis_pedidos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_mis_pedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_mis_pedidos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_mis_pedidos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_mis_pedidos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_mis_pedidos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



















        lbl_mensaje.Visible = False
        Me.Enabled = True
        Exit Sub


    End Sub

    'Private Structure LASTINPUTINFO
    '    Public cbSize As UInteger
    '    Public dwTime As UInteger
    'End Structure

    '<DllImport("User32.dll")> _
    'Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    'End Function

    'Public Function GetInactiveTime() As Nullable(Of TimeSpan)
    '    Dim info As LASTINPUTINFO = New LASTINPUTINFO
    '    info.cbSize = CUInt(Marshal.SizeOf(info))
    '    If (GetLastInputInfo(info)) Then
    '        Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    ''Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ''    Timer1.Start()
    ''End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Dim inactiveTime = GetInactiveTime()

    '    If (inactiveTime Is Nothing) Then
    '        Me.BackColor = Color.Yellow
    '    ElseIf (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
    '        If Application.OpenForms.Count = 2 Then
    '            form_Menu_admin.Enabled = False
    '            mostrar_cierre_sistema()
    '            form_Ingreso.txt_usuario.Focus()
    '            Me.Close()
    '        Else
    '            Me.Close()
    '        End If
    '    End If
    'End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        Dim Font2 As New Font("arial", 9, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)




















        Dim codigo_pedido As String
        Dim VarCodPedido As String
        Dim vendedor As String
        Dim codigo As String
        Dim proveedor As String
        Dim cantidad As String
        Dim descripcion As String
        Dim comentario As String
        Dim prioridad As String
        Dim fecha As String
        Dim estado As String
        Dim abono As String
        Dim fecha_llegada As String
        Dim telefono_vendedor As String
        'Dim direccion_cliente As String
        Dim telefono_cliente As String
        'Dim rut_cliente As String
        Dim nombre_cliente As String









        'Dim var_grilla As Integer
        'var_grilla = ((total_grilla) * 15)


        VarCodPedido = grilla_mis_pedidos.CurrentRow.Cells(0).Value()
        Dim total_grilla As Integer
        For i = 0 To grilla_mis_pedidos.Rows.Count - 1
            codigo_pedido = grilla_mis_pedidos.Rows(i).Cells(0).Value
            vendedor = grilla_mis_pedidos.Rows(i).Cells(1).Value.ToString
            codigo = grilla_mis_pedidos.Rows(i).Cells(2).Value.ToString
            proveedor = grilla_mis_pedidos.Rows(i).Cells(3).Value.ToString
            cantidad = grilla_mis_pedidos.Rows(i).Cells(4).Value.ToString
            estado = grilla_mis_pedidos.Rows(i).Cells(5).Value.ToString
            descripcion = grilla_mis_pedidos.Rows(i).Cells(6).Value.ToString
            comentario = grilla_mis_pedidos.Rows(i).Cells(7).Value.ToString
            prioridad = grilla_mis_pedidos.Rows(i).Cells(8).Value.ToString
            fecha = grilla_mis_pedidos.Rows(i).Cells(9).Value.ToString
            abono = grilla_mis_pedidos.Rows(i).Cells(10).Value.ToString
            fecha_llegada = grilla_mis_pedidos.Rows(i).Cells(11).Value.ToString
            telefono_vendedor = grilla_mis_pedidos.Rows(i).Cells(12).Value.ToString
            telefono_cliente = grilla_mis_pedidos.Rows(i).Cells(13).Value.ToString
            nombre_cliente = grilla_mis_pedidos.Rows(i).Cells(14).Value.ToString

            If codigo_pedido = VarCodPedido Then


                total_grilla = total_grilla + 1

                desglose_abono()



                Try
                    'im = Image(ruta_logo_empresa_ticket)
                    Dim p As New PointF(0, 0)
                    e.Graphics.DrawImage(Bytes_Imagen(Imagen_ticket), p)
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

                e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
                e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
                e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
                e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
                e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
                e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)








                e.Graphics.DrawString("DEPOSITO PARA ENCARGAR PRODUCTO", Font2, Brushes.Black, 15, 165)

                e.Graphics.DrawString("COD. PREDIDO", Font3, Brushes.Black, 0, 195)
                e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 195)
                e.Graphics.DrawString(codigo_pedido, Font4, Brushes.Black, 80, 195)
                e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 210)
                e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 210)
                e.Graphics.DrawString(fecha, Font1, Brushes.Black, 80, 210)
                e.Graphics.DrawString("CLIENTE", Font3, Brushes.Black, 0, 225)
                e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 225)
                e.Graphics.DrawString(nombre_cliente, Font1, Brushes.Black, 80, 225)
                e.Graphics.DrawString("TELEFONO", Font3, Brushes.Black, 0, 240)
                e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 240)
                e.Graphics.DrawString(telefono_cliente, Font1, Brushes.Black, 80, 240)

                e.Graphics.DrawString("VENDEDOR", Font3, Brushes.Black, 0, 255)
                e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 255)
                e.Graphics.DrawString(vendedor, Font1, Brushes.Black, 80, 255)
                e.Graphics.DrawString("TELEFONO", Font3, Brushes.Black, 0, 270)
                e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 270)
                e.Graphics.DrawString(telefono_vendedor, Font1, Brushes.Black, 80, 270)
                e.Graphics.DrawString("ABONO", Font3, Brushes.Black, 0, 285)
                e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 285)
                e.Graphics.DrawString("$ " & abono, Font4, Brushes.Black, 80, 285)
                e.Graphics.DrawString("DESGLOSE", Font3, Brushes.Black, 0, 300)
                e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 300)
                e.Graphics.DrawString(txt_desglose.Text, Font1, Brushes.Black, 80, 300)

                e.Graphics.DrawString("CODIGO", Font3, Brushes.Black, 0, 330)
                e.Graphics.DrawString("DESCRIPCION", Font3, Brushes.Black, 65, 330)
                e.Graphics.DrawString("CANT.", Font3, Brushes.Black, 190, 330)
                e.Graphics.DrawString("LLEGADA", Font3, Brushes.Black, 230, 330)

                e.Graphics.DrawLine(Pens.Black, 1, 345, 300, 345)

                Dim descripcion_caracteres As String
                descripcion_caracteres = descripcion
                If descripcion.Length > 18 Then
                    descripcion_caracteres = descripcion.Substring(0, 18)
                End If

                e.Graphics.DrawString(codigo, Font1, Brushes.Gray, 0, 335 + (total_grilla * 15))
                e.Graphics.DrawString(descripcion_caracteres, Font1, Brushes.Gray, 65, 335 + (total_grilla * 15))
                e.Graphics.DrawString(cantidad, Font1, Brushes.Gray, 218, 335 + (total_grilla * 15), format1)
                e.Graphics.DrawString(fecha_llegada, Font1, Brushes.Gray, 230, 335 + (total_grilla * 15))

            End If

        Next

        e.Graphics.DrawString("CONFIRME LA FECHA DE LLEGADA CON SU VENDEDOR", Font3, Brushes.Gray, 5, total_grilla * 15 + 600)
        e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, total_grilla * 15 + 660)


        'If Me.WindowState = FormWindowState.Minimized Then
        '    Me.WindowState = FormWindowState.Normal
        'End If

    End Sub

    Private Sub Form_mis_pedidos_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

        'If Me.WindowState = FormWindowState.Minimized Then
        '    Me.WindowState = FormWindowState.Normal
        'End If
    End Sub

    Private Sub txt_codigo_pedido_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_pedido.GotFocus
        txt_codigo_pedido.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_pedido_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_pedido.LostFocus
        txt_codigo_pedido.BackColor = Color.White
    End Sub

    Private Sub Combo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.GotFocus
        Combo_vendedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.LostFocus
        Combo_vendedor.BackColor = Color.White
    End Sub

    Private Sub Combo_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_proveedor.GotFocus
        Combo_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_proveedor.LostFocus
        Combo_proveedor.BackColor = Color.White
    End Sub

    Private Sub Combo_estado_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_estado.GotFocus
        Combo_estado.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_estado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_estado.LostFocus
        Combo_estado.BackColor = Color.White
    End Sub

    Private Sub Combo_prioridad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_prioridad.GotFocus
        Combo_prioridad.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_prioridad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_prioridad.LostFocus
        Combo_prioridad.BackColor = Color.White
    End Sub


    Private Sub txt_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_buscar.GotFocus
        txt_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_buscar.LostFocus
        txt_buscar.BackColor = Color.White
    End Sub

    Private Sub dtp1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.GotFocus
        dtp_desde.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.LostFocus
        dtp_desde.BackColor = Color.White
    End Sub

    Private Sub dtp2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.GotFocus
        dtp_hasta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.LostFocus
        dtp_hasta.BackColor = Color.White
    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub txt_codigo_pedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_pedido.TextChanged

    End Sub

    Private Sub grilla_mis_pedidos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub grilla_mis_pedidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim valormensaje As Integer
        Dim codigo_pedido As String
        Dim abono_pedido As String
        Dim estado_pedido As String
        Dim prioridad As String
        If grilla_mis_pedidos.Rows.Count <> 0 Then
            codigo_pedido = grilla_mis_pedidos.CurrentRow.Cells(0).Value()
            estado_pedido = grilla_mis_pedidos.CurrentRow.Cells(5).Value()
            abono_pedido = grilla_mis_pedidos.CurrentRow.Cells(10).Value()

            prioridad = grilla_mis_pedidos.CurrentRow.Cells(8).Value()

            If prioridad = "COTIZADO" Then

                valormensaje = MsgBox("¿DESEA ENCARGAR EL PRODUCTO YA COTIZADO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ENCARGAR")
                If valormensaje = vbYes Then
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE DETALLE_pedido SET `prioridad`='URGENTE' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' "
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    conexion.Close()
                    busqueda()
                End If

            End If













            If abono_pedido <> 0 Then



                valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "IMPRIMIR")
                If valormensaje = vbYes Then





                    lbl_mensaje.Visible = True
                    Me.Enabled = False

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
                            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                            Exit Sub
                        End If

                    End With




                    If Me.WindowState = FormWindowState.Minimized Then
                        Me.WindowState = FormWindowState.Normal
                    End If





                    lbl_mensaje.Visible = False
                    Me.Enabled = True


                    If Me.WindowState = FormWindowState.Minimized Then
                        Me.WindowState = FormWindowState.Normal
                    End If



                    MsgBox("SE HA IMPRESO CORRECTAMENTE EL PEDIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")

                    If Me.WindowState = FormWindowState.Minimized Then
                        Me.WindowState = FormWindowState.Normal
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub lbl_mensaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mensaje.Click

    End Sub

    Private Sub migrilla_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub migrilla_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim valormensaje As Integer
        Dim codigo_pedido As String
        Dim abono_pedido As String
        Dim estado_pedido As String
        Dim prioridad As String
        If grilla_mis_pedidos.Rows.Count <> 0 Then
            codigo_pedido = grilla_mis_pedidos.CurrentRow.Cells(0).Value()
            estado_pedido = grilla_mis_pedidos.CurrentRow.Cells(5).Value()
            abono_pedido = grilla_mis_pedidos.CurrentRow.Cells(10).Value()

            prioridad = grilla_mis_pedidos.CurrentRow.Cells(8).Value()

            If prioridad = "COTIZADO" Then

                valormensaje = MsgBox("¿DESEA ENCARGAR EL PRODUCTO YA COTIZADO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ENCARGAR")
                If valormensaje = vbYes Then
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE DETALLE_pedido SET `prioridad`='URGENTE' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' "
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    conexion.Close()
                    busqueda()
                End If

            End If













            If abono_pedido <> 0 Then



                valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "IMPRIMIR")
                If valormensaje = vbYes Then





                    lbl_mensaje.Visible = True
                    Me.Enabled = False

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
                            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                            Exit Sub
                        End If

                    End With




                    If Me.WindowState = FormWindowState.Minimized Then
                        Me.WindowState = FormWindowState.Normal
                    End If





                    lbl_mensaje.Visible = False
                    Me.Enabled = True


                    If Me.WindowState = FormWindowState.Minimized Then
                        Me.WindowState = FormWindowState.Normal
                    End If



                    MsgBox("SE HA IMPRESO CORRECTAMENTE EL PEDIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")

                    If Me.WindowState = FormWindowState.Minimized Then
                        Me.WindowState = FormWindowState.Normal
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub migrilla_CellContentClick_2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub migrilla_DoubleClick2(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim valormensaje As Integer
        Dim codigo_pedido As String
        Dim abono_pedido As String
        Dim estado_pedido As String
        Dim prioridad As String
        If grilla_mis_pedidos.Rows.Count <> 0 Then
            codigo_pedido = grilla_mis_pedidos.CurrentRow.Cells(0).Value()
            estado_pedido = grilla_mis_pedidos.CurrentRow.Cells(5).Value()
            abono_pedido = grilla_mis_pedidos.CurrentRow.Cells(10).Value()

            prioridad = grilla_mis_pedidos.CurrentRow.Cells(8).Value()

            If prioridad = "COTIZADO" Then

                valormensaje = MsgBox("¿DESEA ENCARGAR EL PRODUCTO YA COTIZADO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ENCARGAR")
                If valormensaje = vbYes Then
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE DETALLE_pedido SET `prioridad`='URGENTE' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' "
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    conexion.Close()
                    busqueda()
                End If

            End If













            If abono_pedido <> 0 Then



                valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "IMPRIMIR")
                If valormensaje = vbYes Then





                    lbl_mensaje.Visible = True
                    Me.Enabled = False

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
                            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                            Exit Sub
                        End If
                    End With




                    If Me.WindowState = FormWindowState.Minimized Then
                        Me.WindowState = FormWindowState.Normal
                    End If





                    lbl_mensaje.Visible = False
                    Me.Enabled = True


                    If Me.WindowState = FormWindowState.Minimized Then
                        Me.WindowState = FormWindowState.Normal
                    End If



                    MsgBox("SE HA IMPRESO CORRECTAMENTE EL PEDIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")

                    If Me.WindowState = FormWindowState.Minimized Then
                        Me.WindowState = FormWindowState.Normal
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub migrilla_CellContentClick_3(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_mis_pedidos.CellContentClick

    End Sub

    Private Sub migrilla_DoubleClick3(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_mis_pedidos.DoubleClick
        Dim valormensaje As Integer
        Dim codigo_pedido As String
        Dim abono_pedido As String
        Dim estado_pedido As String
        Dim prioridad As String
        If grilla_mis_pedidos.Rows.Count <> 0 Then
            codigo_pedido = grilla_mis_pedidos.CurrentRow.Cells(0).Value()
            estado_pedido = grilla_mis_pedidos.CurrentRow.Cells(5).Value()
            abono_pedido = grilla_mis_pedidos.CurrentRow.Cells(10).Value()

            prioridad = grilla_mis_pedidos.CurrentRow.Cells(8).Value()


            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from solicitar_cotizacion where codigo_pedido ='" & (codigo_pedido) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Form_revision_cotizaciones.Show()
                Form_revision_cotizaciones.txt_codigo_pedido.Text = codigo_pedido
                Form_revision_cotizaciones.mostrar_pedidos_por_codigo()

            End If


            If prioridad = "COTIZADO" Then

                'valormensaje = MsgBox("¿DESEA ENCARGAR EL PRODUCTO YA COTIZADO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ENCARGAR")
                'If valormensaje = vbYes Then
                '    'DS.Tables.Clear()
                '    'DT.Rows.Clear()
                '    'DT.Columns.Clear()
                '    'DS.Clear()
                '    'conexion.Open()
                '    fghf
                '    SC.Connection = conexion
                '    SC.CommandText = "UPDATE DETALLE_pedido SET `prioridad`='URGENTE' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' "
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)


                '    busqueda()
                'End If

            End If













                If abono_pedido <> 0 Then



                    valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "IMPRIMIR")
                    If valormensaje = vbYes Then





                        lbl_mensaje.Visible = True
                        Me.Enabled = False

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
                                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                                Exit Sub
                            End If

                        End With




                        If Me.WindowState = FormWindowState.Minimized Then
                            Me.WindowState = FormWindowState.Normal
                        End If





                        lbl_mensaje.Visible = False
                        Me.Enabled = True


                        If Me.WindowState = FormWindowState.Minimized Then
                            Me.WindowState = FormWindowState.Normal
                        End If



                        MsgBox("SE HA IMPRESO CORRECTAMENTE EL PEDIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCION")

                        If Me.WindowState = FormWindowState.Minimized Then
                            Me.WindowState = FormWindowState.Normal
                        End If
                    End If
                End If
            End If
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

    Private Sub Timer_inactividad_pedidos_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_inactividad_mis_pedidos.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub

    Private Sub txt_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar.TextChanged

    End Sub

    Private Sub grilla_mis_pedidos_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_mis_pedidos.Sorted
        Dim prioridad As String
        Dim estado_revision As String



        For i = 0 To grilla_mis_pedidos.Rows.Count - 1
            estado_revision = grilla_mis_pedidos.Rows(i).Cells(5).Value.ToString
            prioridad = grilla_mis_pedidos.Rows(i).Cells(8).Value.ToString

            If estado_revision = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If estado_revision = "RECEPCIONADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

            If estado_revision = "ENCARGADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

            If estado_revision = "NO DISPONIBLE" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If

            If estado_revision = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If prioridad = "COTIZAR" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If

            If prioridad = "COTIZADO" Then
                grilla_mis_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If
        Next
    End Sub


End Class