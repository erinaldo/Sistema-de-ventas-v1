Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_solicitar_cotizacion
    Dim varcodpedido As Integer
    Private WithEvents Pd As New PrintDocument
    Dim impresora_ticket_pedidos As String

    Private Sub Form_solicitar_cotizacion_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F12 Then
            btn_guardar.Focus()
        End If

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

    Private Sub Form_solicitar_cotizacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_solicitar_cotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()
        'mostrar_datos_login()
        'dtp_fecha_pedido.CustomFormat = "yyy-MM-dd"
        dtp_fecha_llegada.CustomFormat = "yyy-MM-dd"
        mostrar_impresora()

        grilla_pedidos.Columns(0).Visible = False
        grilla_pedidos.Columns(1).Visible = False
        grilla_pedidos.Columns(4).Visible = False
        grilla_pedidos.Columns(5).Visible = False
        grilla_pedidos.Columns(6).Visible = False
        grilla_pedidos.Columns(7).Visible = False
        grilla_pedidos.Columns(2).Width = 100
        Form_datos_solicitud_cotizacion.Show()
        Me.Enabled = False


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

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    'Sub mostrar_datos_login()
    '    lbl_usuario_conectado.Text = minombre
    'End Sub

    'Sub llenar_combo_proveedores_mas_pedidos()
    '    Combo_proveedor.Items.Clear()
    '    conexion.Close()
    '    DS3.Tables.Clear()
    '    DT3.Rows.Clear()
    '    DT3.Columns.Clear()
    '    DS3.Clear()
    '    conexion.Open()

    '    SC3.Connection = conexion
    '    SC3.CommandText = "select * from proveedores_Mas_pedidos order by nombre_proveedor"
    '    DA3.SelectCommand = SC3
    '    DA3.Fill(DT3)
    '    DS3.Tables.Add(DT3)

    '    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
    '            Combo_proveedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_proveedor"))
    '        Next
    '        Combo_proveedor.Items.Add("OTROS")
    '    End If
    '    conexion.Close()
    'End Sub

    'Sub impresoras()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select ticket_de_deposito from impresoras"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_impresora_deposito.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_de_deposito")
    '    End If
    '    conexion.Close()
    'End Sub

    'Sub controles(ByVal a As Boolean, ByVal b As Boolean)
    '    btn_agregar.Enabled = a
    '    btn_quitar_elemento.Enabled = a
    '    btn_guardar.Enabled = a
    '    'btn_nueva.Enabled = b

    '    'Combo_prioridad.Enabled = a
    '    'Combo_proveedor.Enabled = a

    '    txt_cantidad_producto.Enabled = a
    '    txt_codigo_pedido.Enabled = a
    '    txt_codigo_producto.Enabled = a
    '    txt_comentario_producto.Enabled = a
    '    txt_descripcion_producto.Enabled = a
    '    grilla_pedidos.Enabled = a

    'End Sub

    Sub limpiar_datos()

        'Combo_prioridad.Text = ""
        'Combo_proveedor.Text = ""
        txt_codigo_pedido.Text = ""
        txt_codigo_producto.Text = ""
        txt_cantidad_producto.Text = ""
        'txt_descripcion_producto.Text = ""
        'txt_comentario_general.Text = ""
    End Sub

    Sub limpiar()
        'Combo_prioridad.Text = ""
        'Combo_proveedor.Text = ""
        txt_codigo_pedido.Text = ""
        txt_codigo_producto.Text = ""
        'txt_descripcion_producto.Text = ""
        'txt_comentario_general.Text = ""
        txt_cantidad_producto.Text = ""
        grilla_pedidos.Rows.Clear()


        txt_marca_vehiculo.Text = ""
        txt_modelo_vehiculo.Text = ""
        Combo_tipo_motor.Text = ""
        txt_cilindrada.Text = ""
        txt_nro_chasis.Text = ""
        txt_nro_motor.Text = ""
        txt_observacion.Text = ""
        txt_nombre_cliente.Text = ""
        txt_telefono_cliente.Text = ""


        Form_datos_solicitud_cotizacion.Show()


    End Sub

    'Sub llenar_combo_proveedor()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from proveedores order by nombre_proveedor"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            Combo_proveedor.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    'Sub nombre_vendedor()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()
    '    SC.Connection = conexion
    '    SC.CommandText = "Select * from usuarios where rut_usuario = '" & (miusuario) & "'  "
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        minombre = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
    '    End If
    '    conexion.Close()
    'End Sub

    Sub grabar_detalle_pedido()
        Dim codigo_producto As String
        Dim proveedor As String
        Dim cantidad As String
        Dim descripcion As String
        Dim comentario As String
        Dim estado As String
        '  Dim prioridad As String
        Dim fecha_llegada As String

        For i = 0 To grilla_pedidos.Rows.Count - 1
            codigo_producto = grilla_pedidos.Rows(i).Cells(0).Value.ToString
            proveedor = grilla_pedidos.Rows(i).Cells(7).Value.ToString
            cantidad = grilla_pedidos.Rows(i).Cells(2).Value.ToString
            descripcion = grilla_pedidos.Rows(i).Cells(3).Value.ToString
            comentario = grilla_pedidos.Rows(i).Cells(4).Value.ToString
            estado = grilla_pedidos.Rows(i).Cells(5).Value.ToString
            ' prioridad = grilla_detalle.Rows(i).Cells(6).Value.ToString
            fecha_llegada = grilla_pedidos.Rows(i).Cells(6).Value.ToString



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
            SC.CommandText = "insert into detalle_pedido (codigo_producto, proveedor, cantidad, descripcion, comentario, estado, prioridad, codigo_pedido, fecha_llegada) values('" & (codigo_producto) & "', '" & (proveedor) & "', '" & (cantidad) & "','" & (descripcion) & "','" & (comentario) & "','POR COTIZAR', '" & ("EN ESPERA") & "',  '" & (txt_codigo_pedido.Text) & "',  '" & (fecha_llegada) & "')"

            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub

    Sub grabar_pedido()
        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "insert into pedido (codigo_pedido, rut_cliente, nombre_cliente, telefono_cliente, abono, fecha_pedido, usuario_responsable, hora) values('" & (txt_codigo_pedido.Text) & "', '-','" & (txt_nombre_cliente.Text) & "','" & (txt_telefono_cliente.Text) & "', '0', '" & (Form_menu_principal.dtp_fecha.Text) & "','" & (miusuario) & "', '" & (Form_menu_principal.lbl_hora.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into solicitar_cotizacion (codigo_pedido, fecha_pedido, marca_vehiculo, modelo_vehiculo, tipo_motor, year, cilindrada, nro_chasis, nro_motor, nombre_cliente, telefono_cliente, observacion, usuario_responsable, hora) values('" & (txt_codigo_pedido.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "','" & (txt_marca_vehiculo.Text) & "','" & (txt_modelo_vehiculo.Text) & "','" & (Combo_tipo_motor.Text) & "','" & (txt_año.Text) & "','" & (txt_cilindrada.Text) & "','" & (txt_nro_chasis.Text) & "','" & (txt_nro_motor.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_telefono_cliente.Text) & "', '" & (txt_observacion.Text) & "','" & (miusuario) & "', '" & (Form_menu_principal.lbl_hora.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'conexion.Close()
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Dim mensaje As String = ""

        If txt_codigo_producto.Text = "" Then
            mensaje = "CAMPO DESCRIPCION VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            txt_codigo_producto.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_cantidad_producto.Text = "" Then
            mensaje = "CAMPO CANTIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            txt_cantidad_producto.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If txt_descripcion_producto.Text = "" Then
        '    mensaje = "CAMPO COMENTARIO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '    txt_descripcion_producto.Focus()
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        crear_codigo_pedido()


        grilla_pedidos.Rows.Add(txt_marca_vehiculo.Text & "-" & txt_modelo_vehiculo.Text, "EN ESPERA", txt_cantidad_producto.Text, txt_codigo_producto.Text, "", "COTIZAR", dtp_fecha_llegada.Text, "EN ESPERA")
        limpiar_datos()
        txt_cantidad_producto.Focus()

        grilla_pedidos.Columns(0).Visible = False
        grilla_pedidos.Columns(1).Visible = False
        grilla_pedidos.Columns(5).Visible = False
        grilla_pedidos.Columns(6).Visible = False
        grilla_pedidos.Columns(7).Visible = False

    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        Dim codigo_pedido As String
        Dim valormensaje As Integer
        Dim mensaje As String = ""

        If grilla_pedidos.Rows.Count = 0 Then
            MsgBox("SELECCIONE UN PEDIDO", 0 + 16, "ERROR")
        Else

            valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR EL PEDIDO SELECCIONADO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

            If valormensaje = vbYes Then

                valormensaje = MsgBox("¿ESTA REALMENTE SEGURO DE ELIMINAR EL PEDIDO SELECCIONADO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

                If valormensaje = vbYes Then
                    codigo_pedido = grilla_pedidos.CurrentRow.Cells(0).Value

                    If grilla_pedidos.Rows.Count > 0 Then

                        'DS.Tables.Clear()
                        'DT.Rows.Clear()
                        'DT.Columns.Clear()
                        'DS.Clear()
                        'conexion.Open()

                        ''SC.Connection = conexion
                        ''SC.CommandText = "insert into registro_de_eliminaciones (tipo_eliminacion,detalle, codigo, fecha_eliminacion, usuario_responsable) values('LIBRO DE COMPRAS','" & (documento) & "','" & (folio) & "','" & (dtp3.Text) & "','" & (miusuario) & "')"
                        ''DA.SelectCommand = SC
                        ''DA.Fill(DT)

                        'SC.Connection = conexion
                        'SC.CommandText = "delete from pedidos where codigo_pedido = '" & (codigo_pedido) & "' "
                        'DA.SelectCommand = SC
                        'DA.Fill(DT)

                        'conexion.Close()

                        grilla_pedidos.Rows.Remove(grilla_pedidos.CurrentRow)

                        'Combo_proveedor.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txt_codigo_producto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_producto.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_codigo_producto.Focus()
        End If
    End Sub

    Private Sub txt_codigo_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_producto.KeyPress
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
            btn_agregar.Focus()
        End If
    End Sub

    Sub crear_codigo_pedido()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        Try
            SC.Connection = conexion
            SC.CommandText = "select max(codigo_pedido) as codigo_pedido from pedido"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varcodpedido = DS.Tables(DT.TableName).Rows(0).Item("codigo_pedido")
                txt_codigo_pedido.Text = varcodpedido + 1
            End If
        Catch err As InvalidCastException
            txt_codigo_pedido.Text = 1
        End Try
        conexion.Close()

    End Sub

    Sub mostrar_datos_productos()
        'If txt_codigo_producto.Text <> "" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_producto.Text) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)

        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        txt_descripcion_producto.Text = (DS.Tables(DT.TableName).Rows(0).Item("NOMBRE")) & " " & (DS.Tables(DT.TableName).Rows(0).Item("APLICACION")) & " " & (DS.Tables(DT.TableName).Rows(0).Item("NUMERO_TECNICO"))

        '    End If
        '    conexion.Close()
        'End If

        'If txt_descripcion_producto.Text = "" Then
        'End If
    End Sub

    Private Sub txt_cantidad_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_producto.KeyPress

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

        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_codigo_producto.Focus()
        End If
    End Sub

    Private Sub txt_comentario_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_observacion.KeyPress
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
            btn_agregar.Focus()
        End If
    End Sub

    Private Sub btn_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn_agregar.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_quitar_elemento.Focus()
        End If
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn_quitar_elemento.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            'Combo_proveedor.Focus()
        End If
    End Sub


    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        ' Dim valormensaje As Integer
        Dim mensaje As String = ""

        If grilla_pedidos.Rows.Count = 0 Then
            mensaje = "MALLA DE PEDIDO VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            txt_codigo_producto.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If Combo_prioridad.Text = "URGENTE" Then
        '    valormensaje = MsgBox("¿DESEA AGREGAR UN ABONO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ABONO")
        '    If valormensaje = vbYes Then
        '        Form_registro_clientes_abono.Show()
        '        Me.Enabled = False
        '        Exit Sub

        '    Else

        lbl_mensaje.Visible = True
        Me.Enabled = False



        crear_codigo_pedido()
        grabar_pedido()
        grabar_detalle_pedido()








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

        MsgBox("SE HA INGRESADO CORRECTAMENTE EL PEDIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        '    End If
        'End If



        'If Combo_prioridad.Text <> "URGENTE" And Combo_prioridad.Text <> "" Then

        '    lbl_mensaje.Visible = True
        '    Me.Enabled = False



        '    crear_codigo_pedido()
        '    grabar_pedido()
        '    grabar_detalle_pedido()
        '    'limpiar()
        '    controles(False, True)
        '    MsgBox("SE HA INGRESADO CORRECTAMENTE EL PEDIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        'End If

        limpiar()
        Me.Enabled = True
        lbl_mensaje.Visible = False

    End Sub

    Sub grabar_deposito_repuesto_temporal()
        Dim codigo_producto As String
        Dim cantidad As String
        Dim descripcion As String
        Dim fecha_llegada As String
        Dim nombre_vendedor As String
        Dim telefono_vendedor As String

        nombre_vendedor = ""
        telefono_vendedor = ""

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





        For i = 0 To grilla_pedidos.Rows.Count - 1
            codigo_producto = grilla_pedidos.Rows(i).Cells(0).Value.ToString
            descripcion = grilla_pedidos.Rows(i).Cells(3).Value.ToString
            cantidad = grilla_pedidos.Rows(i).Cells(2).Value.ToString
            fecha_llegada = grilla_pedidos.Rows(i).Cells(6).Value.ToString

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "insert into deposito_para_repuesto_temporal (codigo_pedido, nombre_vendedor, telefono_vendedor, fecha_pedido, codigo_producto, nombre_producto, cantidad_producto, fecha_llegada) values('" & (txt_codigo_pedido.Text) & "', '" & (nombre_vendedor) & "','" & (telefono_vendedor) & "',  '" & (Form_menu_principal.dtp_fecha.Text) & "' ,'" & (codigo_producto) & "','" & (descripcion) & "','" & (cantidad) & "','" & (fecha_llegada) & "' )"
            ' SC.CommandText = "insert into detalle_pedido (                                                                                                             codigo_producto,             proveedor,             cantidad,           descripcion,      comentario,        estado,              prioridad,                   codigo_pedido) values('" & (codigo_producto) & "', '" & (proveedor) & "', '" & (cantidad) & "','" & (descripcion) & "','" & (comentario) & "','EN ESPERA', '" & (prioridad) & "',  '" & (Form_pedidos.txt_codigo_pedido.Text) & "', '" & (miusuario) & "')"

            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub





    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        Dim Font2 As New Font("arial", 9, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        Try
            Dim im As Image = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
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

        'Dim rect1 As New Rectangle(10, 60, 270, 15)
        'Dim rect2 As New Rectangle(10, 75, 270, 15)
        'Dim rect3 As New Rectangle(10, 90, 270, 15)
        'Dim rect4 As New Rectangle(10, 105, 270, 15)
        'Dim rect5 As New Rectangle(10, 120, 270, 15)
        'Dim rect6 As New Rectangle(10, 135, 270, 15)


        Dim rect1 As New Rectangle(10, 90, 270, 15)
        Dim rect2 As New Rectangle(10, 105, 270, 15)
        Dim rect3 As New Rectangle(10, 120, 270, 15)
        Dim rect4 As New Rectangle(10, 135, 270, 15)
        Dim rect5 As New Rectangle(10, 150, 270, 15)
        Dim rect6 As New Rectangle(10, 165, 270, 15)

        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

        e.Graphics.DrawString("ENCARGO DE REPUESTOS", Font2, Brushes.Black, 60, 195)

        e.Graphics.DrawString("COD. PEDIDO", Font3, Brushes.Black, 0, 225)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 225)
        e.Graphics.DrawString(txt_codigo_pedido.Text, Font4, Brushes.Black, 80, 225)

        e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 240)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 240)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font1, Brushes.Black, 80, 240)

        e.Graphics.DrawString("VENDEDOR", Font3, Brushes.Black, 0, 255)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 255)
        e.Graphics.DrawString(minombre, Font1, Brushes.Black, 80, 255)

        e.Graphics.DrawString("TELEFONO", Font3, Brushes.Black, 0, 270)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 270)
        e.Graphics.DrawString(mitelefono, Font1, Brushes.Black, 80, 270)

        e.Graphics.DrawString("CODIGO", Font3, Brushes.Black, 0, 300)
        e.Graphics.DrawString("DESCRIPCION", Font3, Brushes.Black, 65, 300)
        'e.Graphics.DrawString("CANT.", Font3, Brushes.Black, 190, 255)
        e.Graphics.DrawString("CANTIDAD", Font3, Brushes.Black, 230, 300)

        e.Graphics.DrawLine(Pens.Black, 1, 315, 300, 315)

        Dim codigo_producto As String
        Dim proveedor As String
        Dim cantidad As String
        Dim descripcion As String
        Dim comentario As String
        Dim estado As String

        ' Dim fecha_llegada As String

        For i = 0 To grilla_pedidos.Rows.Count - 1
            codigo_producto = grilla_pedidos.Rows(i).Cells(0).Value.ToString
            proveedor = grilla_pedidos.Rows(i).Cells(7).Value.ToString
            cantidad = grilla_pedidos.Rows(i).Cells(2).Value.ToString
            descripcion = grilla_pedidos.Rows(i).Cells(3).Value.ToString
            comentario = grilla_pedidos.Rows(i).Cells(4).Value.ToString
            estado = grilla_pedidos.Rows(i).Cells(5).Value.ToString
            'fecha_llegada = grilla_pedidos.Rows(i).Cells(6).Value.ToString



            Dim descripcion_caracteres As String
            descripcion_caracteres = descripcion
            If descripcion.Length > 18 Then
                descripcion_caracteres = descripcion.Substring(0, 18)
            End If




            e.Graphics.DrawString(codigo_producto, Font1, Brushes.Gray, 0, 320 + (i * 15))
            e.Graphics.DrawString(descripcion_caracteres, Font1, Brushes.Gray, 65, 320 + (i * 15))
            'e.Graphics.DrawString(cantidad, Font1, Brushes.Gray, 218, 265 + (i * 15), format1)
            e.Graphics.DrawString(cantidad, Font1, Brushes.Gray, 230, 320 + (i * 15), format1)
        Next

        Dim var_grilla As Integer
        var_grilla = ((grilla_pedidos.Rows.Count - 1) * 15)

        e.Graphics.DrawString("CONFIRME LA FECHA DE LLEGADA CON SU VENDEDOR", Font3, Brushes.Gray, 5, var_grilla + 350)
        e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, var_grilla + 410)
    End Sub

    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")>
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

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click

        Form_datos_solicitud_cotizacion.txt_marca_automovil.Text = txt_marca_vehiculo.Text
        Form_datos_solicitud_cotizacion.txt_modelo_vehiculo.Text = txt_modelo_vehiculo.Text
        Form_datos_solicitud_cotizacion.Combo_tipo_motor.SelectedItem = Combo_tipo_motor.Text

        Form_datos_solicitud_cotizacion.txt_año.Text = txt_año.Text
        Form_datos_solicitud_cotizacion.txt_cilindrada.Text = txt_cilindrada.Text
        Form_datos_solicitud_cotizacion.txt_nro_chasis.Text = txt_nro_chasis.Text
        Form_datos_solicitud_cotizacion.txt_nro_motor.Text = txt_nro_motor.Text
        Form_datos_solicitud_cotizacion.txt_observacion.Text = txt_observacion.Text
        Form_datos_solicitud_cotizacion.txt_nombre_cliente.Text = txt_nombre_cliente.Text
        Form_datos_solicitud_cotizacion.txt_telefono_cliente.Text = txt_telefono_cliente.Text
        Form_datos_solicitud_cotizacion.Show()
        Me.Enabled = False
    End Sub

    Private Sub txt_codigo_producto_TextChanged(sender As Object, e As EventArgs) Handles txt_codigo_producto.TextChanged

    End Sub

    Private Sub txt_descripcion_producto_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_descripcion_producto_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    Private Sub txt_cantidad_producto_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_producto.TextChanged

    End Sub
End Class