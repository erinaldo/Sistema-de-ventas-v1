Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Math
Public Class Form_venta_manual
    Dim total_registros As Integer
    Dim varnumdoc As Integer
    Dim mifecha2 As String
    Dim sin_facturar As String
    Dim VarSeleccion As Integer

    Dim alto_cotizacion As String
    Private WithEvents Pd As New PrintDocument

    Private Sub Form_venta_manual_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_venta_manual_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

    Private Sub Form_venta_manual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        cargar_logo()
        valores()
        txt_fecha.Text = FormatDateTime(Now, DateFormat.ShortDate)
        controles(False, True)
        condiciones()

        llenar_combo_vendedor()
        dtp_vencimiento.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.Value = dtp_vencimiento.Value.AddMonths(Val(+1))

        txt_codigo.Focus()
        Timer_ventas.Start()


        If mirutempresa = "81921000-4" Then
            txt_pie.Visible = True
            lbl_pie.Visible = True
        End If


        Me.btn_nueva.PerformClick()
    End Sub



    Sub llenar_combo_vendedor()
        Combo_vendedor.Items.Clear()
        Combo_vendedor.Items.Add("-")
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
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If

        Combo_vendedor.SelectedItem = "-"
        conexion.Close()
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













    Private Sub Form_venta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Dim valormensaje As Integer
        'valormensaje = MsgBox("¿DESEA CERRAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CERRAR")
        'If valormensaje = vbNo Then
        '    e.Cancel = True
        'End If
    End Sub


    'Sub ajustar_a_documento()
    '    If combo_venta.Text = "BOLETA" Then
    '        'Me.Enabled = False
    '        GroupBox_producto.Location = New Point(0, 3)
    '        btn_agregar.Location = New Point(788, 117)
    '        btn_quitar_elemento.Location = New Point(893, 117)
    '        'btn_agregar.Location = New Point(788, 224)
    '        'btn_quitar_elemento.Location = New Point(893, 224)

    '        lbl_precio.Location = New Point(10, 129)
    '        txt_precio_modificado.Location = New Point(70, 126)

    '        lbl_cantidad_agregar.Location = New Point(188, 129)
    '        txt_cantidad_agregar.Location = New Point(338, 126)

    '        '  lbl_descto.Location = New Point(225, 126)
    '        grilla_detalle_venta.Location = New Point(0, 163)
    '        grilla_detalle_venta.Height = (339)
    '        '  Me.Enabled = True
    '        GroupBox_clientes.Enabled = False
    '        'GroupBox_retira.Enabled = False
    '        Exit Sub
    '    End If

    '    If combo_venta.Text <> "BOLETA" Then
    '        ' Me.Enabled = False
    '        GroupBox_producto.Location = New Point(0, 3)
    '        GroupBox_producto.Location = New Point(0, 112)
    '        btn_agregar.Location = New Point(788, 224)
    '        btn_quitar_elemento.Location = New Point(893, 224)

    '        lbl_precio.Location = New Point(10, 235)
    '        txt_precio_modificado.Location = New Point(70, 232)

    '        lbl_cantidad_agregar.Location = New Point(188, 235)
    '        txt_cantidad_agregar.Location = New Point(338, 232)

    '        '  lbl_descto.Location = New Point(225, 235)
    '        grilla_detalle_venta.Location = New Point(0, 268)
    '        grilla_detalle_venta.Height = (235)
    '        '  Me.Enabled = True
    '        GroupBox_clientes.Enabled = True
    '        'GroupBox_retira.Enabled = True
    '    End If



    '    'If combo_venta.Text = "FACTURA" Then
    '    '    ' Me.Enabled = False
    '    '    GroupBox_producto.Location = New Point(0, 3)
    '    '    GroupBox_producto.Location = New Point(0, 112)
    '    '    btn_agregar.Location = New Point(788, 224)
    '    '    btn_quitar_elemento.Location = New Point(893, 224)

    '    '    lbl_precio.Location = New Point(10, 235)
    '    '    txt_precio_modificado.Location = New Point(70, 232)

    '    '    lbl_cantidad_agregar.Location = New Point(188, 235)
    '    '    txt_cantidad_agregar.Location = New Point(338, 232)

    '    '    '  lbl_descto.Location = New Point(225, 235)
    '    '    grilla_detalle_venta.Location = New Point(0, 268)
    '    '    grilla_detalle_venta.Height = (235)
    '    '    '  Me.Enabled = True
    '    '    GroupBox_clientes.Enabled = True
    '    '    GroupBox_retira.Enabled = True
    '    'End If
    '    'If combo_venta.Text = "FACTURA DE CREDITO" Then
    '    '    ' Me.Enabled = False
    '    '    GroupBox_producto.Location = New Point(0, 3)
    '    '    GroupBox_producto.Location = New Point(0, 112)
    '    '    btn_agregar.Location = New Point(788, 224)
    '    '    btn_quitar_elemento.Location = New Point(893, 224)

    '    '    lbl_precio.Location = New Point(10, 235)
    '    '    txt_precio_modificado.Location = New Point(70, 232)

    '    '    lbl_cantidad_agregar.Location = New Point(188, 235)
    '    '    txt_cantidad_agregar.Location = New Point(338, 232)

    '    '    '  lbl_descto.Location = New Point(225, 235)
    '    '    grilla_detalle_venta.Location = New Point(0, 268)
    '    '    grilla_detalle_venta.Height = (235)
    '    '    '  Me.Enabled = True
    '    '    GroupBox_clientes.Enabled = True
    '    '    GroupBox_retira.Enabled = True
    '    'End If

    '    'If combo_venta.Text = "GUIA" Then
    '    '    ' Me.Enabled = False
    '    '    GroupBox_producto.Location = New Point(0, 3)
    '    '    GroupBox_producto.Location = New Point(0, 112)
    '    '    btn_agregar.Location = New Point(788, 224)
    '    '    btn_quitar_elemento.Location = New Point(893, 224)

    '    '    lbl_precio.Location = New Point(10, 235)
    '    '    txt_precio_modificado.Location = New Point(70, 232)

    '    '    lbl_cantidad_agregar.Location = New Point(188, 235)
    '    '    txt_cantidad_agregar.Location = New Point(338, 232)

    '    '    '  lbl_descto.Location = New Point(225, 235)
    '    '    grilla_detalle_venta.Location = New Point(0, 268)
    '    '    grilla_detalle_venta.Height = (235)
    '    '    '  Me.Enabled = True
    '    '    GroupBox_clientes.Enabled = True
    '    '    GroupBox_retira.Enabled = True
    '    'End If

    '    'If combo_venta.Text = "BOLETA DE CREDITO" Then
    '    '    ' Me.Enabled = False
    '    '    GroupBox_producto.Location = New Point(0, 3)
    '    '    GroupBox_producto.Location = New Point(0, 112)
    '    '    btn_agregar.Location = New Point(788, 224)
    '    '    btn_quitar_elemento.Location = New Point(893, 224)

    '    '    lbl_precio.Location = New Point(10, 235)
    '    '    txt_precio_modificado.Location = New Point(70, 232)

    '    '    lbl_cantidad_agregar.Location = New Point(188, 235)
    '    '    txt_cantidad_agregar.Location = New Point(338, 232)

    '    '    '  lbl_descto.Location = New Point(225, 235)
    '    '    grilla_detalle_venta.Location = New Point(0, 268)
    '    '    grilla_detalle_venta.Height = (235)
    '    '    '  Me.Enabled = True
    '    '    GroupBox_clientes.Enabled = True
    '    '    GroupBox_retira.Enabled = True
    '    'End If

    '    If txt_rut_cliente.Enabled = True Then
    '        txt_rut_cliente.BackColor = Color.White
    '    Else
    '        txt_rut_cliente.BackColor = SystemColors.Control
    '    End If

    '    'If txt_rut_retira.Enabled = True Then
    '    '    txt_rut_retira.BackColor = Color.White
    '    'Else
    '    '    txt_rut_retira.BackColor = SystemColors.Control
    '    'End If
    'End Sub


    'Private Sub Form_venta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    '    If e.KeyCode = Keys.F1 Then
    '        txt_codigo.Focus()
    '    End If

    '    If e.KeyCode = Keys.F2 Then
    '        ' txt_rut_retira.Focus()
    '        If grilla_detalle_venta.Rows.Count > 0 Then
    '            grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.CurrentRow)
    '            calcular_totales()
    '            txt_item.Text = grilla_detalle_venta.Rows.Count
    '            'lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
    '            detalle_label()
    '            txt_codigo.Focus()
    '        End If
    '    End If

    '    If e.KeyCode = Keys.F3 Then


    '        Form_buscar_productos_ventas.Close()
    '        Form_registro_cliente_retira_ventas.Close()
    '        Form_registro_clientes_ventas.Close()
    '        Me.Close()
    '        form_Menu_admin.Enabled = False
    '        form_Ingreso.Show()

    '    End If




    '    If e.KeyCode = Keys.F4 Then
    '        btn_buscar_productos.PerformClick()
    '    End If

    '    If e.KeyCode = Keys.F5 Then
    '        txt_rut_cliente.Focus()
    '    End If

    '    If e.KeyCode = Keys.F6 Then
    '        btn_agregar_clientes.PerformClick()
    '    End If

    '    If e.KeyCode = Keys.F7 Then
    '        btn_buscar_clientes.PerformClick()
    '    End If

    '    If e.KeyCode = Keys.F8 Then
    '        btn_agregar_retira.PerformClick()
    '    End If

    '    If e.KeyCode = Keys.F9 Then
    '        txt_cargar.Focus()
    '    End If

    '    'If e.KeyCode = Keys.F10 Then
    '    '    txt_porcentaje_desc.Focus()
    '    'End If

    '    If e.KeyCode = Keys.F11 Then
    '        combo_venta.Focus()
    '    End If

    '    If e.KeyCode = Keys.F12 Then
    '        '  TextBox1.Text = ActiveControl.Name
    '        If txt_porcentaje_desc.Focused = True Then
    '            btn_grabar.PerformClick()
    '            Exit Sub
    '        Else

    '            txt_porcentaje_desc.Focus()
    '            Exit Sub
    '        End If


    '        ' btn_grabar.PerformClick()
    '    End If

    '    If e.KeyCode = Keys.Escape Then
    '        Me.Close()
    '    End If

    '    If e.KeyCode = 18 Then
    '        If Me.WindowState = FormWindowState.Maximized Then
    '            Me.WindowState = FormWindowState.Normal
    '            Exit Sub
    '        End If
    '        If Me.WindowState = FormWindowState.Normal Then
    '            Me.WindowState = FormWindowState.Maximized
    '            Exit Sub
    '        End If

    '    End If
    'End Sub



    'Sub ajustar()
    '    Dim margen_lateral_contenedor As String
    '    Dim margen_superior_contenedor As String

    '    margen_lateral_contenedor = (Me.Width - Panel_contenedor.Width) / 2
    '    margen_superior_contenedor = (Me.Height - Panel_contenedor.Height) / 2

    '    'Panel_contenedor.Location = New Point(margen_lateral_contenedor - 3, margen_superior_contenedor + 11)



    '    'panel_esc.Size = New Point(Me.Width, 23)
    '    'panel_esc.Location = New Point(-1, -1)
    'End Sub



    'Sub mostrar(ByVal i As Integer)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
    '        txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
    '        txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
    '        txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
    '        txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
    '        txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
    '        txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
    '        txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
    '        txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
    '    End If
    'End Sub

    Sub limpiar_datos_clientes()
        lbl_rut.Text = "nada"
        ' txt_rut_cliente.Text = ""
        ' txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        ' txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_folio.Text = ""
        txt_telefono.Text = ""
        txt_giro_cliente.Text = ""
    End Sub

    Sub limpiar_datos_clientes_enter()
        lbl_rut.Text = "nada"
        txt_nombre_cliente.Text = ""
        'txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        '  txt_descuento_cliente.Text = ""
        ' txt_giro_cliente.Text = ""
        ' txt_comuna_cliente.Text = ""
        ' txt_cuenta_cliente.Text = ""
        ' txt_telefono.Text = ""
        '  txt_folio.Text = ""
        ' txt_descuento_cliente_2.Text = ""

        '  txt_orden_de_compra.Text = ""
    End Sub

    Sub limpiar_datos_productos_enter()
        lbl_codigo.Text = "nada"
        txt_nombre_producto.Text = ""
        txt_marca.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad.Text = ""
        txt_factor.Text = ""
        txt_precio_modificado.Text = ""
        txt_costo.Text = ""
        txt_proveedor.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
        txt_proveedor.Text = ""
    End Sub

    'Sub limpiar_datos_clientes_retira()
    '    txt_rut_retira.Text = ""
    '    txt_nombre_retira.Text = ""
    'End Sub

    'Sub mostrar_retira(ByVal i As Integer)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_rut_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
    '        txt_nombre_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_retira")
    '    End If
    'End Sub

    'Sub mostrar_productos(ByVal i As Integer)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
    '        txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
    '        txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    '        txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
    '        txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
    '        txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
    '        txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
    '        txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
    '        txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
    '        txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
    '        txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
    '        txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")

    '    End If
    'End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha2 se le entrega el formato de fecha indicado.
    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_fecha.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

    End Sub

    ''actualizamos la tabla clientes.
    'Sub actualizar_tabla_clientes()
    '    conexion.Close()
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

    '    conexion.Close()
    'End Sub

    'actualizamos la tabla productos.
    'Sub actualizar_tabla_productos()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from productos"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    conexion.Close()
    'End Sub

    'actualizamos la tabla cliente_retira()
    'Sub actualizar_tabla_retira()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from clientes_retira"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    conexion.Close()
    'End Sub

    'sub para mostrar los datos de los clientes.
    Sub mostrar_datos_clientes()
        conexion.Close()
        If txt_rut_cliente.Text <> "" Then
            conexion.Close()
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

            ' If DS.Tables(DT.TableName).Rows.Count > 0 Then
            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                '  txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                ' txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
                txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
                txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                ' txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                ' txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                ' txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                ' txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                'End If
                txt_codigo.Focus()
                conexion.Close()
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
                conexion.Close()
                Form_seleccionar_cuenta_ingreso_manual_de_ventas.Show()
                Me.Enabled = False
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                'If txt_rut.Text <> "" And txt_nombre_cliente.Text = "" Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
                'Else
                '    txt_rut_retira.Focus()
                '    Exit Sub
            End If
        End If
    End Sub

    'sub para mostrar los datos de los clientes.
    Sub mostrar_nombre_proveedor()
        conexion.Close()
        If txt_proveedor.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            txt_nombre_proveedor.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            End If
            conexion.Close()
        End If
    End Sub

    'Sub mostrar_datos_clientes2()

    '    If txt_rut_cliente.Text <> "" Then
    '        conexion.Close()
    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from clientes where rut ='" & (rutbuscado) & "'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)

    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
    '            lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
    '            txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
    '            txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
    '            txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
    '            txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
    '            txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
    '            txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
    '            txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
    '            txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
    '            txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
    '            txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
    '            txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
    '            txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
    '        End If
    '        conexion.Close()
    '    End If
    'End Sub

    'sub para mostrar los datos de los productos.
    Sub mostrar_datos_productos()
        If txt_codigo.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
            End If
            conexion.Close()
        End If
    End Sub



    'como se debe llenar el combo condiciones segun el documento elegido y los campos que habilita.
    Sub condiciones()
        If combo_venta.Text = "FACTURA" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("-")
            combo_condiciones.Items.Add("EFECTIVO")
            combo_condiciones.Items.Add("TARJETA DEBITO")
            combo_condiciones.Items.Add("TARJETA CREDITO")
            combo_condiciones.Items.Add("CHEQUE AL DIA")
            combo_condiciones.Items.Add("CHEQUE 30 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30-60 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30-60-90 DIAS")
            combo_condiciones.Items.Add("TRANSFERENCIA")
            combo_condiciones.Items.Add("PENDIENTE")
            combo_condiciones.Items.Add("LETRA")
            combo_condiciones.Items.Add("OTRO MEDIO DE PAGO")
            combo_condiciones.SelectedItem = "-"
            '  GroupBox_retira.Enabled = True
        End If

        If combo_venta.Text = "FACTURA DE CREDITO" Then

            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.SelectedItem = "CREDITO"
            ' GroupBox_retira.Enabled = True
        End If

        If combo_venta.SelectedItem = "GUIA" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.Items.Add("TRASLADO")
            combo_condiciones.SelectedItem = "CREDITO"
            ' GroupBox_retira.Enabled = True
        End If

        If combo_venta.Text = "BOLETA" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("-")
            combo_condiciones.Items.Add("EFECTIVO")
            combo_condiciones.Items.Add("TARJETA DEBITO")
            combo_condiciones.Items.Add("TARJETA CREDITO")
            combo_condiciones.Items.Add("CHEQUE AL DIA")
            combo_condiciones.Items.Add("CHEQUE 30 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30-60 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30-60-90 DIAS")
            combo_condiciones.Items.Add("TRANSFERENCIA")
            combo_condiciones.Items.Add("PENDIENTE")
            combo_condiciones.Items.Add("LETRA")
            combo_condiciones.Items.Add("OTRO MEDIO DE PAGO")
            combo_condiciones.SelectedItem = "-"
            'GroupBox_retira.Enabled = False
        End If

        If combo_venta.Text = "BOLETA DE CREDITO" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.SelectedItem = "CREDITO"
            ' GroupBox_retira.Enabled = False
        End If

        If combo_venta.Text = "COTIZACION" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.Items.Add("CONTADO")
            combo_condiciones.SelectedItem = "CONTADO"
            ' GroupBox_clientes.Enabled = True
            ' GroupBox_retira.Enabled = False
        End If
    End Sub

    'sub controles, permite cambiar el estado cuando lo necesitemos.
    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a
        combo_condiciones.Enabled = a
        txt_codigo.Enabled = a
        txt_rut_cliente.Enabled = a
        btn_grabar.Enabled = a
        btn_limpiar.Enabled = a
        btn_nueva.Enabled = b
        combo_venta.Enabled = b
        'btn_imagen.Enabled = a
        'btn_buscar_clientes.Enabled = a
        'btn_buscar_productos.Enabled = a
        'btn_agregar_clientes.Enabled = a
        'btn_agregar_retira.Enabled = a
        'btn_buscar_retira.Enabled = a

        ' txt_cargar.Enabled = a
        txt_cantidad_agregar.Enabled = a
        txt_porcentaje_desc.Enabled = a
        txt_codigo.Enabled = a
        txt_rut_cliente.Enabled = a
        txt_nombre_producto.Enabled = a
        combo_venta.Enabled = a



        txt_precio_modificado.Enabled = a


        '  GroupBox_cargar.Enabled = a
        GroupBox_clientes.Enabled = a
        GroupBox_descuento.Enabled = a
        'GroupBox_item.Enabled = a
        GroupBox_producto.Enabled = a
        GroupBox_tipo_venta.Enabled = a
        GroupBox_totales.Enabled = a

        GroupBox_nro_doc.Enabled = a
        GroupBox_fecha.Enabled = a
        GroupBox_vendedor.Enabled = a

        grilla_detalle_venta.Enabled = a









        'Radio_codigo_barra.Enabled = a
        'Radio_codigo_interno.Enabled = a

        '  txt_rut_retira.Enabled = a


        If txt_precio_modificado.Enabled = True Then
            txt_precio_modificado.BackColor = Color.White
        Else
            txt_precio_modificado.BackColor = SystemColors.Control
        End If

        If txt_rut_cliente.Enabled = True Then
            txt_rut_cliente.BackColor = Color.White
        Else
            txt_rut_cliente.BackColor = SystemColors.Control
        End If

        'If txt_rut_retira.Enabled = True Then
        '    txt_rut_retira.BackColor = Color.White
        'Else
        '    txt_rut_retira.BackColor = SystemColors.Control
        'End If

        If txt_codigo.Enabled = True Then
            txt_codigo.BackColor = Color.White
        Else
            txt_codigo.BackColor = SystemColors.Control
        End If

        If txt_cantidad_agregar.Enabled = True Then
            txt_cantidad_agregar.BackColor = Color.White
        Else
            txt_cantidad_agregar.BackColor = SystemColors.Control
        End If



        If txt_porcentaje_desc.Enabled = True Then
            txt_porcentaje_desc.BackColor = Color.White
        Else
            txt_porcentaje_desc.BackColor = SystemColors.Control
        End If


        If combo_condiciones.Enabled = True Then
            combo_condiciones.BackColor = Color.White
        Else
            combo_condiciones.BackColor = SystemColors.Control
        End If

        If combo_venta.Enabled = True Then
            combo_venta.BackColor = Color.White
        Else
            combo_venta.BackColor = SystemColors.Control
        End If













    End Sub

    'nos permite limpiar los campos de la pantalla cuando lo necesitemos.
    Sub limpiar()
        txt_cantidad.Text = ""
        'txt_desglose.Text = ""
        ' txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        ' txt_comuna_cliente.Text = ""
        txt_iva.Text = ""
        txt_marca.Text = ""
        txt_neto.Text = ""
        lbl_rut.Text = "nada"
        lbl_codigo.Text = "nada"
        txt_nombre_cliente.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        txt_sub_total.Text = ""
        txt_factor.Text = ""
        txt_rut_cliente.Text = ""
        'txt_cuenta_cliente.Text = ""
        txt_codigo.Text = ""
        ' txt_descuento_cliente.Text = ""
        txt_desc.Text = ""
        txt_total.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_porcentaje_desc.Text = ""
        'txt_nombre_retira.Text = ""
        '  txt_rut_retira.Text = ""
        txt_rut_cliente.Text = ""
        txt_nro_doc_imprimir.Text = ""
        txt_nombre_proveedor.Text = ""
        'txt_giro_cliente.Text = ""
        'txt_telefono.Text = ""
        'txt_folio.Text = ""
        'txt_ciudad_cliente.Text = ""
        'txt_correo_cliente.Text = ""
        txt_aplicacion.Text = ""
        'txt_descuento_cliente_2.Text = ""

        'txt_orden_de_compra.Text = ""
        grilla_detalle_venta.Rows.Clear()
        'txt_item.Text = "0"

        txt_codigo.Text = ""
        txt_rut_cliente.Text = ""

        combo_venta.Text = ""
        combo_condiciones.Text = ""
        combo_venta.Text = "BOLETA"
        condiciones()
        combo_condiciones.Text = "EFECTIVO"
        'lbl_venta.Text = "BOLETA $: 0"

        txt_sub_total_millar.Text = ""
        txt_neto_millar.Text = ""
        txt_iva_millar.Text = ""
        txt_desc_millar.Text = ""
        txt_total_millar.Text = ""

        txt_comuna_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_folio.Text = ""
        txt_telefono.Text = ""
        txt_giro_cliente.Text = ""

        txt_rut_vendedor.Text = ""
        Combo_vendedor.Text = ""
        Combo_vendedor.SelectedItem = "-"

        ' detalle_label()
        txt_codigo.Focus()
    End Sub

    'limpiar producto se utiliza cuando agregamos el producto a la grilla.
    Sub limpiar_producto()
        lbl_codigo.Text = "nada"
        txt_codigo.Text = ""
        txt_codigo.Text = ""
        txt_cantidad.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        txt_factor.Text = ""
        txt_codigo.Text = ""
        txt_numero_tecnico.Text = ""
        txt_marca.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
        txt_proveedor.Text = ""
    End Sub



    Private Sub combo_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
            limpiar_datos_productos_enter()
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            txt_rut_cliente.Focus()
            'condiciones()

        ElseIf (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_productos_enter()
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            'condiciones()
            txt_cantidad_agregar.Focus()
        End If
    End Sub

    'llamamos al sub mostrar productos.
    'habilitamos los texbox.
    'le damos el valor del combo al textbox.
    'limpiamos el texbox.
    Private Sub combo_codigo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_cantidad_real()
        'txt_cantidad_agregar.Text = ""
        ' condiciones()
    End Sub
    'limpiamos la pantalla.
    'habilitamos los campos.
    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        '    limpiar()
        'llenar_combo_ventas()
        'combo_venta.SelectedItem = "BOLETA"
        '  txt_porcentaje_desc.Text = "0"
        calcular_totales()
        controles(True, False)
        txt_codigo.Focus()
    End Sub



    'salimos de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        'Dim valormensaje As Integer
        'valormensaje = MsgBox("¿DESEA CERRAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        'If valormensaje = vbYes Then
        '    form_Menu_admin.WindowState = FormWindowState.Normal
        '    Form_orden_de_compra.Close()
        Me.Close()
        'End If
    End Sub

    'funcion para realizar el desglose en palabras de la cifra que se indica en el txt_total.
    ''los datos que se llenan en el comboventa cuando se limpia el mismo.
    'Sub llenar_combo_ventas()
    '    combo_venta.Items.Add("BOLETA")
    '    combo_venta.Items.Add("BOLETA DE CREDITO")
    '    combo_venta.Items.Add("COTIZACION")
    '    combo_venta.Items.Add("FACTURA")
    '    combo_venta.Items.Add("FACTURA DE CREDITO")
    '    combo_venta.Items.Add("GUIA")
    'End Sub
    'calcula el neto iva total y descuento de los productos mediante se vana gregando al sistema.
    Sub venta()
        Dim iva As Long
        Dim neto As Long
        Dim total As Long
        Dim codigo As Long
        Dim cantidad As Integer
        Dim desc As String
        Dim porcentaje_desc As String
        Dim subtotal As Long
        ' Dim saldo As Integer
        Dim iva_valor As String
        Dim precio_lista As String

        Dim cantidad_agregar As String = Trim(txt_cantidad_agregar.Text)

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Text = 0
        End If

        If txt_cantidad_agregar.Text = " " Then
            txt_cantidad_agregar.Text = 0
        End If

        If txt_cantidad_agregar.TextLength = 0 Then
            txt_cantidad_agregar.Text = 0
        End If
        If txt_cantidad_agregar.Text = "  " Then
            txt_cantidad_agregar.Text = 0
        End If
        'If txt_porcentaje_desc.Text = "" Then
        '    txt_porcentaje_desc.Text = "0"
        'End If
        'If txt_porcentaje_desc.Text = " " Then
        '    txt_porcentaje_desc.Text = "0"
        'End If
        'If txt_porcentaje_desc.Text = "  " Then
        '    txt_porcentaje_desc.Text = "0"
        'End If



        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        'Me.txt_porcentaje_desc.Text = Trim(Replace(Me.txt_porcentaje_desc.Text, " ", ""))





        If txt_codigo.Text = "*" Then
            Try
                If txt_cantidad_agregar.Text <> "" And txt_cantidad_agregar.Text <> " " And txt_cantidad_agregar.Text <> "  " And txt_cantidad_agregar.Text <> 0 Then


                    If txt_cantidad.Text = "" Then
                        txt_cantidad.Text = "0"
                    End If

                    'porcentaje_desc = (txt_precio_modificado.Text * 100)
                    'porcentaje_desc = (porcentaje_desc / txt_precio.Text)
                    'porcentaje_desc = (100 - porcentaje_desc)

                    'desc = (porcentaje_desc * txt_precio.Text)
                    'desc = (desc / 100)
                    If txt_precio.Text = "" Then
                        txt_precio.Text = "0"
                    End If

                    If txt_precio_modificado.Text = "" Then
                        txt_precio_modificado.Text = "0"
                    End If

                    porcentaje_desc = "0"
                    desc = "0"

                    'If Int(txt_precio.Text) > Int(txt_precio_modificado.Text) Then

                    '    porcentaje_desc = (txt_precio.Text - txt_precio_modificado.Text)
                    '    porcentaje_desc = (porcentaje_desc * 100)
                    '    porcentaje_desc = (porcentaje_desc / txt_precio.Text)
                    '    'porcentaje_desc = (100 - porcentaje_desc)

                    '    desc = (txt_precio.Text - txt_precio_modificado.Text)
                    '    desc = (desc * txt_cantidad_agregar.Text)

                    '    ' factor = precio_venta / valor_factor
                    '    If porcentaje_desc.Length > 4 Then
                    '        porcentaje_desc = porcentaje_desc.Substring(0, 4)
                    '    End If

                    'End If



                    subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
                    iva_valor = valor_iva / 100 + 1
                    neto = (subtotal / iva_valor)
                    iva = (neto) * valor_iva / 100
                    total = subtotal - desc
                    'saldo = (txt_cantidad.Text - txt_cantidad_agregar.Text)


                    grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)
                    calcular_totales()
                    limpiar_producto()
                    txt_codigo.Focus()


                Else
                    MsgBox("DEBE INGRESAR UNA CANTIDAD", 0 + 16, "ERROR")
                    txt_cantidad_agregar.Focus()
                End If



            Catch err As InvalidCastException
                MsgBox("VERIFIQUE EL CODIGO INGRESADO", 0 + 16, "ERROR")
                txt_cantidad_agregar.Focus()
                Exit Sub
            End Try



            Exit Sub
        End If


























        Try
            If txt_cantidad_agregar.Text <> "" And txt_cantidad_agregar.Text <> " " And txt_cantidad_agregar.Text <> "  " And txt_cantidad_agregar.Text <> 0 Then
                ' If Val(txt_cantidad_agregar.Text) <= Val(txt_cantidad.Text) Then

                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    codigo = Val(grilla_detalle_venta.Rows(i).Cells(0).Value.ToString)

                    cantidad = Val(grilla_detalle_venta.Rows(i).Cells(4).Value.ToString)
                    If codigo = txt_codigo.Text Then
                        grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.Rows(i))
                        Exit For
                        '    cantidad = cantidad + CInt(txt_cantidad_agregar.Text)
                        '    'desc = ((txt_precio.Text * cantidad) * txt_porcentaje_desc.Text) / 100
                    End If

                    '    'porcentaje_desc = (txt_precio_modificado.Text * 100)
                    '    'porcentaje_desc = (porcentaje_desc / txt_precio.Text)
                    '    'porcentaje_desc = (100 - porcentaje_desc)

                    '    'desc = (porcentaje_desc * txt_precio.Text)
                    '    'desc = (desc / 100)

                    '    If txt_precio.Text = "" Then
                    '        txt_precio.Text = "0"
                    '    End If

                    '    If txt_precio_modificado.Text = "" Then
                    '        txt_precio_modificado.Text = "0"
                    '    End If


                    '    porcentaje_desc = "0"
                    '    desc = "0"

                    '    If Int(txt_precio.Text) > Int(txt_precio_modificado.Text) Then

                    '        porcentaje_desc = (txt_precio.Text - txt_precio_modificado.Text)
                    '        porcentaje_desc = (porcentaje_desc * 100)
                    '        porcentaje_desc = (porcentaje_desc / txt_precio.Text)
                    '        'porcentaje_desc = (100 - porcentaje_desc)

                    '        desc = (txt_precio.Text - txt_precio_modificado.Text)
                    '        desc = (desc * txt_cantidad_agregar.Text)


                    '        ' factor = precio_venta / valor_factor
                    '        If porcentaje_desc.Length > 4 Then
                    '            porcentaje_desc = porcentaje_desc.Substring(0, 4)
                    '        End If

                    '    End If



                    '    subtotal = (cantidad * txt_precio.Text)

                    '    iva_valor = valor_iva / 100 + 1

                    '    neto = (subtotal / iva_valor)
                    '    iva = (neto) * valor_iva / 100
                    '    total = subtotal - desc

                    '    'saldo = (txt_cantidad.Text - txt_cantidad_agregar.Text)



                    '    'If txt_precio.Text = "" Or txt_precio.Text = "0" Then
                    '    '    txt_precio.Text = "0"
                    '    'Else
                    '    '    txt_precio.Text = Format(Int(txt_precio.Text), "###,###,###")
                    '    'End If

                    '    'If cantidad = "" Or cantidad = "0" Then
                    '    '    cantidad = "0"
                    '    'Else
                    '    '    cantidad = Format(Int(cantidad), "###,###,###")
                    '    'End If

                    '    'If neto = "" Or neto = "0" Then
                    '    '    neto = "0"
                    '    'Else
                    '    '    neto = Format(Int(neto), "###,###,###")
                    '    'End If

                    '    'If iva = "" Or iva = "0" Then
                    '    '    iva = "0"
                    '    'Else
                    '    '    iva = Format(Int(iva), "###,###,###")
                    '    'End If

                    '    'If subtotal = "" Or subtotal = "0" Then
                    '    '    subtotal = "0"
                    '    'Else
                    '    '    subtotal = Format(Int(subtotal), "###,###,###")
                    '    'End If

                    '    'If total = "" Or total = "0" Then
                    '    '    total = "0"
                    '    'Else
                    '    '    total = Format(Int(total), "###,###,###")
                    '    'End If








                    '    grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio.Text, cantidad, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)
                    '    txt_cantidad_agregar.Text = 0
                    '    calcular_totales()
                    '    limpiar_producto()
                    '    txt_codigo.Focus()
                    '    Exit Sub
                    'End If
                Next


                If txt_cantidad.Text = "" Then
                    txt_cantidad.Text = "0"
                End If




                'porcentaje_desc = (txt_precio_modificado.Text * 100)
                'porcentaje_desc = (porcentaje_desc / txt_precio.Text)
                'porcentaje_desc = (100 - porcentaje_desc)

                'desc = (porcentaje_desc * txt_precio.Text)
                'desc = (desc / 100)


                If txt_precio.Text = "" Then
                    txt_precio.Text = "0"
                End If

                If txt_precio_modificado.Text = "" Then
                    txt_precio_modificado.Text = "0"
                End If

                porcentaje_desc = "0"
                desc = "0"

                If Int(txt_precio.Text) > Int(txt_precio_modificado.Text) Then

                    porcentaje_desc = (txt_precio.Text - txt_precio_modificado.Text)
                    porcentaje_desc = (porcentaje_desc * 100)
                    porcentaje_desc = (porcentaje_desc / txt_precio.Text)
                    'porcentaje_desc = (100 - porcentaje_desc)

                    desc = (txt_precio.Text - txt_precio_modificado.Text)
                    desc = (desc * txt_cantidad_agregar.Text)


                    ' factor = precio_venta / valor_factor
                    If porcentaje_desc.Length > 4 Then
                        porcentaje_desc = porcentaje_desc.Substring(0, 4)
                    End If

                End If

                'desc = ((txt_precio.Text * txt_cantidad_agregar.Text) * txt_porcentaje_desc.Text) / 100


                If Int(txt_precio.Text) < Int(txt_precio_modificado.Text) Then
                    subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
                    precio_lista = txt_precio_modificado.Text
                Else
                    subtotal = (txt_precio.Text * txt_cantidad_agregar.Text)
                    precio_lista = txt_precio.Text
                End If

                iva_valor = valor_iva / 100 + 1
                neto = (subtotal / iva_valor)
                iva = (neto) * valor_iva / 100
                total = subtotal - desc








                grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, precio_lista, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)
                ' txt_cantidad_agregar.Text = 0
                calcular_totales()
                limpiar_producto()
                txt_codigo.Focus()
                'Else
                '    MsgBox("NO PUEDE AGREGAR UNA CANTIDAD MAYOR A LA DISPONIBLE", 0 + 16, "ERROR")
                '    txt_cantidad_agregar.Focus()
                'End If






            Else
                MsgBox("DEBE INGRESAR UNA CANTIDAD", 0 + 16, "ERROR")
                txt_cantidad_agregar.Focus()
            End If



        Catch err As InvalidCastException
            MsgBox("VERIFIQUE EL CODIGO INGRESADO", 0 + 16, "ERROR")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End Try

    End Sub

    'a traves de este sub puedo descontar las cantidades que agregue a la grilla cuando el mismo codigo del producto ya fue agregado.
    Sub mostrar_cantidad_real()
        conexion.Close()
        Dim cantidad_caracteres As Integer
        cantidad_caracteres = Len(txt_codigo.Text)
        If cantidad_caracteres <= 6 Then

            If txt_codigo.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto='" & (txt_codigo.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                    txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                    txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    If grilla_detalle_venta.Rows.Count > 0 Then
                        For i = 0 To grilla_detalle_venta.Rows.Count - 1
                            Dim codigo = grilla_detalle_venta.Rows(i).Cells(0).Value
                            Dim cantidad2 = grilla_detalle_venta.Rows(i).Cells(4).Value
                            If codigo = txt_codigo.Text Then
                                txt_cantidad.Text = Int(txt_cantidad.Text) - Int(cantidad2)
                            End If
                        Next
                        ' txt_cantidad_agregar.Focus()
                        conexion.Close()
                    End If
                End If
            End If
        Else




            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from codigos_de_barra where codigo_barra='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_interno")
            End If


            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")

                If grilla_detalle_venta.Rows.Count > 0 Then
                    For i = 0 To grilla_detalle_venta.Rows.Count - 1
                        Dim codigo = grilla_detalle_venta.Rows(i).Cells(0).Value
                        Dim cantidad2 = grilla_detalle_venta.Rows(i).Cells(4).Value
                        If codigo = txt_codigo.Text Then
                            txt_cantidad.Text = Int(txt_cantidad.Text) - Int(cantidad2)
                        End If
                    Next
                End If


                ' txt_cantidad_agregar.Focus()
            End If
            conexion.Close()
        End If

        '    Else
        '        If lbl_codigo.Text <> "" Then
        '            conexion.Close()
        '            DS.Tables.Clear()
        '            DT.Rows.Clear()
        '            DT.Columns.Clear()
        '            DS.Clear()
        '            conexion.Open()

        '            SC.Connection = conexion
        '            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo.Text) & "'"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '            DS.Tables.Add(DT)

        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                Try
        '                    lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                    txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
        '                    txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
        '                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                    txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
        '                    txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
        '                    txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                    txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                    txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
        '                    txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
        '                    txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
        '                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")

        '                Catch
        '                End Try
        '            End If
        '            ' txt_cantidad_agregar.Focus()
        '            conexion.Close()
        '        Else
        '            conexion.Close()
        '            DS.Tables.Clear()
        '            DT.Rows.Clear()
        '            DT.Columns.Clear()
        '            DS.Clear()
        '            conexion.Open()

        '            SC.Connection = conexion
        '            SC.CommandText = "select * from productos where cod_producto='" & (txt_codigo.Text) & "'"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '            DS.Tables.Add(DT)

        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
        '                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
        '                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
        '                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
        '                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
        '                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
        '                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
        '                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")

        '                For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '                    Dim codigo = grilla_detalle_venta.Rows(i).Cells(0).Value
        '                    Dim cantidad2 = grilla_detalle_venta.Rows(i).Cells(4).Value
        '                    If codigo = txt_codigo.Text Then
        '                        txt_cantidad.Text = Int(txt_cantidad.Text) - Int(cantidad2)
        '                    End If
        '                Next
        '                ' txt_cantidad_agregar.Focus()
        '            End If
        '            conexion.Close()
        '        End If

        '    End If



        'Else


        '    If grilla_detalle_venta.Rows.Count > 0 Then
        '        If txt_codigo.Text <> "" Then
        '            conexion.Close()
        '            DS.Tables.Clear()
        '            DT.Rows.Clear()
        '            DT.Columns.Clear()
        '            DS.Clear()
        '            conexion.Open()

        '            SC.Connection = conexion
        '            SC.CommandText = "select * from productos where codigo_barra='" & (txt_codigo.Text) & "'"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '            DS.Tables.Add(DT)

        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
        '                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
        '                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
        '                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
        '                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
        '                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
        '                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
        '                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")



        '                For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '                    Dim codigo = grilla_detalle_venta.Rows(i).Cells(0).Value
        '                    Dim cantidad2 = grilla_detalle_venta.Rows(i).Cells(4).Value
        '                    If codigo = txt_codigo.Text Then
        '                        txt_cantidad.Text = Int(txt_cantidad.Text) - Int(cantidad2)
        '                    End If

        '                Next
        '                ' txt_cantidad_agregar.Focus()
        '                conexion.Close()
        '            End If
        '        Else
        '            conexion.Close()
        '            DS.Tables.Clear()
        '            DT.Rows.Clear()
        '            DT.Columns.Clear()
        '            DS.Clear()
        '            conexion.Open()

        '            SC.Connection = conexion
        '            SC.CommandText = "select * from productos where codigo_barra='" & (txt_codigo.Text) & "'"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '            DS.Tables.Add(DT)

        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
        '                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
        '                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
        '                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
        '                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
        '                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
        '                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
        '                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")


        '                For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '                    Dim codigo = grilla_detalle_venta.Rows(i).Cells(0).Value
        '                    Dim cantidad2 = grilla_detalle_venta.Rows(i).Cells(4).Value
        '                    If codigo = txt_codigo.Text Then
        '                        txt_cantidad.Text = Int(txt_cantidad.Text) - Int(cantidad2)
        '                    End If
        '                Next
        '                'txt_cantidad_agregar.Focus()
        '            End If

        '            conexion.Close()
        '        End If

        '    Else
        '        If txt_codigo.Text <> "" Then
        '            conexion.Close()
        '            DS.Tables.Clear()
        '            DT.Rows.Clear()
        '            DT.Columns.Clear()
        '            DS.Clear()
        '            conexion.Open()

        '            SC.Connection = conexion
        '            SC.CommandText = "select * from productos where codigo_barra ='" & (txt_codigo.Text) & "'"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '            DS.Tables.Add(DT)

        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                txt_codigo.Text = ""

        '                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
        '                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
        '                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
        '                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
        '                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
        '                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
        '                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
        '                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
        '            End If
        '            ' txt_cantidad_agregar.Focus()
        '            conexion.Close()
        '        Else
        '            conexion.Close()
        '            DS.Tables.Clear()
        '            DT.Rows.Clear()
        '            DT.Columns.Clear()
        '            DS.Clear()
        '            conexion.Open()

        '            SC.Connection = conexion
        '            SC.CommandText = "select * from productos where codigo_barra='" & (txt_codigo.Text) & "'"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '            DS.Tables.Add(DT)

        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
        '                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
        '                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        '                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
        '                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
        '                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
        '                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
        '                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
        '                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
        '                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")

        '                For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '                    Dim codigo = grilla_detalle_venta.Rows(i).Cells(0).Value
        '                    Dim cantidad2 = grilla_detalle_venta.Rows(i).Cells(4).Value
        '                    If codigo = txt_codigo.Text Then
        '                        txt_cantidad.Text = Int(txt_cantidad.Text) - Int(cantidad2)
        '                    End If
        '                Next
        '                '  txt_cantidad_agregar.Focus()
        '            End If
        '            conexion.Close()
        '        End If
        '    End If
        '   End If
        'txt_cantidad_agregar.Focus()
        'If txt_codigo.Text <> "" And txt_nombre_producto.Text = "" Then
        '    MsgBox("CODIGO NO ENCONTRADO", MsgBoxStyle.Critical, "INFORMACION")
        '    txt_codigo.Focus()
        '    Exit Sub
        ' End If
    End Sub

    Private Sub btn_agregar_ChangeUICues(ByVal sender As Object, ByVal e As System.Windows.Forms.UICuesEventArgs) Handles btn_agregar.ChangeUICues
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
    End Sub

    'verificamos que la cantidad de items corresponda al limite maximo que tiene cada TIPO de documentos.
    'llamamos al sub venta.
    ' indicamos la cantidad de elementos de la grilla en el txtbox.
    Private Sub btn_agregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Dim mensaje As String = ""

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_codigo.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Text = ""
            txt_cantidad_agregar.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        'If txt_porcentaje_desc.Text = "" Then
        '    mensaje = "CAMPO CANTIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '    txt_porcentaje_desc.Text = ""
        '    txt_porcentaje_desc.Focus()
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If
        'If txt_porcentaje_desc.Text = " " Then
        '    mensaje = "CAMPO CANTIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '    txt_porcentaje_desc.Text = ""
        '    txt_porcentaje_desc.Focus()
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If
        If txt_nombre_producto.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If


        If combo_venta.Text = "" Then
            mensaje = "CAMPO DOCUMENTO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            combo_venta.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_venta.Text <> "NOTA DE CREDITO" And combo_venta.Text <> "BOLETA" And combo_venta.Text <> "BOLETA DE CREDITO" And combo_venta.Text <> "FACTURA" And combo_venta.Text <> "FACTURA DE CREDITO" And combo_venta.Text <> "GUIA" And combo_venta.Text <> "COTIZACION" Then
            combo_venta.Focus()
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If mensaje <> "" Then
        '    MsgBox(mensaje, MessageBoxIcon.Information, "ATENCION")
        'Else





        If txt_cantidad_agregar.Text = "*" Then

            If txt_nombre_producto.Text = "" Then
                txt_nombre_producto.Focus()
                MsgBox("CAMPO NOMBRE PRODUCTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_precio_modificado.Text = "" Then
                txt_precio_modificado.Focus()
                MsgBox("CAMPO PRECIO VENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_cantidad_agregar.Text = "" Then
                txt_cantidad_agregar.Focus()
                MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_codigo.Text = "*" Then
                combo_venta.Text = "COTIZACION"
            End If

            'If combo_venta.Text = "COTIZACION" Then
            '    If grilla_detalle_venta.Rows.Count < 100 Then
            '        venta()
            '        'txt_item.Text = grilla_detalle_venta.Rows.Count
            '        mostrar_cantidad_real()
            '        txt_cantidad_agregar.Text = ""
            '        'detalle_label()
            '        Exit Sub
            '    Else
            '        MsgBox("EN UNA COTIZACION NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
            '        Exit Sub
            '    End If
            'End If


            Exit Sub
        End If






        'If txt_cantidad_agregar.Text = "" Then
        '    mensaje = "CAMPO CANTIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '    txt_cantidad_agregar.Focus()
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_codigo.Text = "" Then
        '    mensaje = "CAMPO CODIGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '    txt_codigo.Focus()
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_cantidad_agregar.Text = "" Then
        '    mensaje = "CAMPO CANTIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '    txt_cantidad_agregar.Text = ""
        '    txt_cantidad_agregar.Focus()
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_nombre_producto.Text = "" Then
        '    mensaje = "CAMPO CODIGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '    txt_codigo.Focus()
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If
        If combo_venta.Text = "NOTA DE CREDITO" Then
            'If grilla_detalle_venta.Rows.Count < 10 Then
            venta()
            'txt_item.Text = grilla_detalle_venta.Rows.Count
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            ' detalle_label()
            Exit Sub
            'Else
            '    MsgBox("EN UNA BOLETA NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
            '    Exit Sub
            'End If
        End If

        If combo_venta.Text = "BOLETA DE CREDITO" Then
            'If grilla_detalle_venta.Rows.Count < 10 Then
            venta()
            'txt_item.Text = grilla_detalle_venta.Rows.Count
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            ' detalle_label()
            Exit Sub
            'Else
            '    MsgBox("EN UNA BOLETA NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
            '    Exit Sub
            'End If
        End If

        If combo_venta.Text = "BOLETA" Then
            'If grilla_detalle_venta.Rows.Count < 13 Then
            venta()
            '   txt_item.Text = grilla_detalle_venta.Rows.Count
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            ' detalle_label()
            Exit Sub
            'Else
            '    MsgBox("EN UNA BOLETA NO PUEDE AGREGAR MAS DE 13 ITEMS", 0 + 16, "ERROR")
            '    Exit Sub
            'End If
        End If

        If combo_venta.Text = "COTIZACION" Then
            'If grilla_detalle_venta.Rows.Count < 100 Then
            venta()
            '   txt_item.Text = grilla_detalle_venta.Rows.Count
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            ' detalle_label()
            Exit Sub
            'Else
            '    MsgBox("EN UNA COTIZACION NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
            '    Exit Sub
            'End If
        End If


        If combo_venta.Text = "FACTURA" Then
            'If grilla_detalle_venta.Rows.Count < 29 Then
            venta()
            '  txt_item.Text = grilla_detalle_venta.Rows.Count
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            ' detalle_label()
            Exit Sub
            'Else
            '    MsgBox("EN UNA FACTURA NO PUEDE AGREGAR MAS DE 28 ITEMS", 0 + 16, "ERROR")
            '    Exit Sub
            'End If
        End If

        If combo_venta.Text = "FACTURA DE CREDITO" Then
            'If grilla_detalle_venta.Rows.Count < 29 Then
            venta()
            '   txt_item.Text = grilla_detalle_venta.Rows.Count
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            ' detalle_label()
            Exit Sub
            'Else
            '    MsgBox("EN UNA FACTURA NO PUEDE AGREGAR MAS DE 28 ITEMS", 0 + 16, "ERROR")
            '    Exit Sub
            'End If
        End If

        If combo_venta.Text = "GUIA" Then
            'If grilla_detalle_venta.Rows.Count < 29 Then
            venta()
            '    txt_item.Text = grilla_detalle_venta.Rows.Count
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            '   detalle_label()
            '    Exit Sub
            'Else
            '    MsgBox("EN UNA GUIA NO PUEDE AGREGAR MAS DE 28 ITEMS", 0 + 16, "ERROR")
            '    Exit Sub
            'End If
        End If

























        'If combo_venta.Text = "BOLETA DE CREDITO" Then
        '    If grilla_detalle_venta.Rows.Count < 10 Then
        '        venta()
        '        txt_item.Text = grilla_detalle_venta.Rows.Count
        '        mostrar_cantidad_real()
        '        txt_cantidad_agregar.Text = ""
        '        'lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
        '        detalle_label()
        '    Else
        '        MsgBox("EN UNA BOLETA NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
        '    End If
        'Else
        '    If combo_venta.Text = "BOLETA" Then
        '        If grilla_detalle_venta.Rows.Count < 10 Then
        '            venta()
        '            txt_item.Text = grilla_detalle_venta.Rows.Count
        '            mostrar_cantidad_real()
        '            txt_cantidad_agregar.Text = ""
        '            'lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
        '            detalle_label()
        '        Else
        '            MsgBox("EN UNA BOLETA NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
        '        End If
        '    Else
        '        If combo_venta.Text = "COTIZACION" Then
        '            If grilla_detalle_venta.Rows.Count < 100 Then
        '                venta()
        '                txt_item.Text = grilla_detalle_venta.Rows.Count
        '                mostrar_cantidad_real()
        '                txt_cantidad_agregar.Text = ""
        '                'lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
        '                detalle_label()
        '            Else
        '                MsgBox("EN UNA COTIZACION NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
        '            End If

        '        Else

        '            If combo_venta.Text = "FACTURA" Then
        '                If grilla_detalle_venta.Rows.Count < 29 Then
        '                    venta()
        '                    txt_item.Text = grilla_detalle_venta.Rows.Count
        '                    mostrar_cantidad_real()
        '                    txt_cantidad_agregar.Text = ""
        '                    'lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
        '                    detalle_label()
        '                Else
        '                    MsgBox("EN UNA FACTURA NO PUEDE AGREGAR MAS DE 28 ITEMS", 0 + 16, "Error")
        '                End If
        '            Else

        '                If combo_venta.Text = "FACTURA DE CREDITO" Then
        '                    If grilla_detalle_venta.Rows.Count < 29 Then
        '                        venta()
        '                        txt_item.Text = grilla_detalle_venta.Rows.Count
        '                        mostrar_cantidad_real()
        '                        txt_cantidad_agregar.Text = ""
        '                        'lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
        '                        detalle_label()
        '                    Else
        '                        MsgBox("EN UNA FACTURA NO PUEDE AGREGAR MAS DE 28 ITEMS", 0 + 16, "Error")
        '                    End If
        '                Else
        '                    If combo_venta.Text = "GUIA" Then
        '                        If grilla_detalle_venta.Rows.Count < 29 Then
        '                            venta()
        '                            txt_item.Text = grilla_detalle_venta.Rows.Count
        '                            mostrar_cantidad_real()
        '                            txt_cantidad_agregar.Text = ""
        '                            ' lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
        '                            detalle_label()
        '                        Else
        '                            MsgBox("EN UNA GUIA NO PUEDE AGREGAR MAS DE 28 ITEMS", 0 + 16, "Error")
        '                        End If
        '                    Else

        '                        If combo_venta.Text = "" Then
        '                            If grilla_detalle_venta.Rows.Count < 15 Then
        '                                venta()
        '                                txt_item.Text = grilla_detalle_venta.Rows.Count
        '                                mostrar_cantidad_real()
        '                            End If
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
        'End If
    End Sub

    'va generando el calculo del neto iva total y descuento del documento, es decir de la suma de todos los productos ingresados.
    Sub calcular_totales()
        'Dim descgrilla As Integer
        'Dim netogrilla As Integer
        'Dim ivagrilla As Integer
        'Dim totalgrilla As Integer
        'Dim subtotalgrilla As Integer

        Dim descgrilla As Long
        Dim netogrilla As Long
        Dim ivagrilla As Long
        Dim totalgrilla As Long
        Dim subtotalgrilla As Long

        '//Calcular el descuento
        txt_desc.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            descgrilla = Val(grilla_detalle_venta.Rows(i).Cells(9).Value.ToString)
            txt_desc.Text = Val(txt_desc.Text) + Val(descgrilla)
        Next

        '//Calcular el total neto
        txt_neto.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            netogrilla = Val(grilla_detalle_venta.Rows(i).Cells(5).Value.ToString)
            txt_neto.Text = Val(txt_neto.Text) + Val(netogrilla)
        Next

        '//Calcular el total iva
        txt_iva.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            ivagrilla = Val(grilla_detalle_venta.Rows(i).Cells(6).Value.ToString)
            txt_iva.Text = Val(txt_iva.Text) + Val(ivagrilla)
        Next

        '//Calcular el sub-total 
        txt_sub_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            subtotalgrilla = Val(grilla_detalle_venta.Rows(i).Cells(10).Value.ToString)
            txt_sub_total.Text = Val(txt_sub_total.Text) + Val(subtotalgrilla)
        Next

        '//Calcular el total general
        txt_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            totalgrilla = Val(grilla_detalle_venta.Rows(i).Cells(10).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next


        Dim descuento_porcentaje As Integer
        Dim porcentaje_desc As Integer

        If txt_porcentaje_desc.Text = "" Or txt_porcentaje_desc.Text = "-" Then
            porcentaje_desc = 0
        Else
            porcentaje_desc = txt_porcentaje_desc.Text
        End If
        ' porcentaje_desc = txt_porcentaje_desc.Text

        'If porcentaje_desc = 0 Then
        '    porcentaje_desc = "0"
        'End If

        descuento_porcentaje = ((txt_total.Text) * porcentaje_desc) / 100
        txt_desc.Text = descuento_porcentaje

        txt_total.Text = Int(txt_sub_total.Text) - Int(txt_desc.Text)

        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        neto = (txt_total.Text / iva_valor)
        Round(neto)
        txt_neto.Text = neto

        iva = ((txt_neto.Text) * valor_iva / 100)
        Round(iva)
        txt_iva.Text = iva



        iva_valor = valor_iva / 100 + 1

        neto = (txt_total.Text / iva_valor)
        Round(neto)
        txt_neto.Text = neto

        iva = ((txt_neto.Text) * valor_iva / 100)
        Round(iva)
        txt_iva.Text = iva





        'Dim valor_total As Integer
        'valor_total = txt_total.Text
        'Dim finTotal As Integer
        'Dim numerofinal As Integer

        'finTotal = Strings.Right(valor_total, 2)
        'numerofinal = Strings.Right(valor_total, 1)

        'If numerofinal = 0 Then
        '    '  Exit Sub
        'End If


        'If combo_venta.Text <> "FACTURA DE CREDITO" And combo_venta.Text <> "BOLETA DE CREDITO" And combo_venta.Text <> "GUIA" Then
        '    valor_total = valor_total - numerofinal
        '    txt_desc.Text = txt_desc.Text + numerofinal
        '    txt_total.Text = valor_total
        'End If

        iva_valor = valor_iva / 100 + 1

        neto = (txt_total.Text / iva_valor)
        Round(neto)
        txt_neto.Text = neto

        iva = ((txt_neto.Text) * valor_iva / 100)
        Round(iva)
        txt_iva.Text = iva


        ' Strings.Right(TextBox1.Text, 1)

        If grilla_detalle_venta.Rows.Count <> 0 Then
            'txt_item.Text = grilla_detalle_venta.Rows.Count
        End If

        If txt_sub_total.Text = "" Or txt_sub_total.Text = "0" Then
            txt_sub_total_millar.Text = "0"
        Else
            txt_sub_total_millar.Text = Format(Int(txt_sub_total.Text), "###,###,###")
        End If
        If txt_desc.Text = "" Or txt_desc.Text = "0" Then
            txt_desc_millar.Text = "0"
        Else
            txt_desc_millar.Text = Format(Int(txt_desc.Text), "###,###,###")
        End If
        If txt_neto.Text = "" Or txt_neto.Text = "0" Then
            txt_neto_millar.Text = "0"
        Else
            txt_neto_millar.Text = Format(Int(txt_neto.Text), "###,###,###")
        End If
        If txt_iva.Text = "" Or txt_iva.Text = "0" Then
            txt_iva_millar.Text = "0"
        Else
            txt_iva_millar.Text = Format(Int(txt_iva.Text), "###,###,###")
        End If
        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub


    'Sub redondear_documento()
    '    Dim iva As Integer
    '    Dim neto As Integer
    '    Dim iva_valor As String

    '    Dim valor_total As Integer
    '    valor_total = txt_total.Text
    '    Dim finTotal As Integer
    '    Dim numerofinal As Integer

    '    finTotal = Strings.Right(valor_total, 2)
    '    numerofinal = Strings.Right(valor_total, 1)

    '    If numerofinal = 0 Then
    '        '  Exit Sub
    '    End If


    '    If combo_venta.Text <> "FACTURA DE CREDITO" And combo_venta.Text <> "BOLETA DE CREDITO" And combo_venta.Text <> "GUIA" Then
    '        valor_total = valor_total - numerofinal

    '        Round(valor_total)


    '        txt_desc.Text = txt_desc.Text + numerofinal
    '        txt_total.Text = valor_total
    '    End If

    '    iva_valor = valor_iva / 100 + 1

    '    neto = (txt_total.Text / iva_valor)
    '    Round(neto)
    '    txt_neto.Text = neto

    '    iva = ((txt_neto.Text) * valor_iva / 100)
    '    Round(iva)
    '    txt_iva.Text = iva

    '    peso = " PESOS"
    '    If CInt(txt_total.Text) = 1000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & " DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 2000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 3000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 4000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 5000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 6000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 7000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 8000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 9000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 10000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 11000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 12000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 13000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 14000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 15000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 16000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 17000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 18000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 19000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 20000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 21000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 22000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 23000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 24000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 25000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 26000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 27000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 28000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 29000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    ElseIf CInt(txt_total.Text) = 30000000 Then
    '        desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
    '    Else
    '        desglose_valor = Num2Text(txt_total.Text) & peso
    '    End If
    '    ' Strings.Right(TextBox1.Text, 1)

    '    If grilla_detalle_venta.Rows.Count <> 0 Then
    '        'txt_item.Text = grilla_detalle_venta.Rows.Count
    '    End If

    '    If txt_sub_total.Text = "" Or txt_sub_total.Text = "0" Then
    '        txt_sub_total_millar.Text = "0"
    '    Else
    '        txt_sub_total_millar.Text = Format(Int(txt_sub_total.Text), "###,###,###")
    '    End If
    '    If txt_desc.Text = "" Or txt_desc.Text = "0" Then
    '        txt_desc_millar.Text = "0"
    '    Else
    '        txt_desc_millar.Text = Format(Int(txt_desc.Text), "###,###,###")
    '    End If
    '    If txt_neto.Text = "" Or txt_neto.Text = "0" Then
    '        txt_neto_millar.Text = "0"
    '    Else
    '        txt_neto_millar.Text = Format(Int(txt_neto.Text), "###,###,###")
    '    End If
    '    If txt_iva.Text = "" Or txt_iva.Text = "0" Then
    '        txt_iva_millar.Text = "0"
    '    Else
    '        txt_iva_millar.Text = Format(Int(txt_iva.Text), "###,###,###")
    '    End If
    '    If txt_total.Text = "" Or txt_total.Text = "0" Then
    '        txt_total_millar.Text = "0"
    '    Else
    '        txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
    '    End If
    'End Sub



    'al presionarlo quita el elemento seleccionado de la grilla.
    Private Sub btn_quitar_elemento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_detalle_venta.Rows.Count > 0 Then
            grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.CurrentRow)
            calcular_totales()
            'txt_item.Text = grilla_detalle_venta.Rows.Count
            'lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
            'detalle_label()
            txt_codigo.Focus()
        End If
    End Sub

    'Sub impresoras()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from impresoras"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_impresora_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("BOLETA")
    '        txt_impresora_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("guia")
    '        txt_impresora_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("factura")
    '        txt_impresora_factura_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("factura_de_credito")
    '        txt_impresora_cotizacion.Text = DS.Tables(DT.TableName).Rows(0).Item("cotizacion")
    '    End If
    '    conexion.Close()
    'End Sub
    Sub redondear_documento()
        'Dim iva As Integer
        'Dim neto As Integer
        Dim iva_valor As String

        Dim valor_total As Integer
        valor_total = txt_total.Text
        Dim finTotal As Integer
        Dim numerofinal As Integer

        finTotal = Strings.Right(valor_total, 2)
        numerofinal = Strings.Right(valor_total, 1)

        If numerofinal = 0 Then
            '  Exit Sub
        End If


        If combo_venta.Text <> "FACTURA DE CREDITO" And combo_venta.Text <> "BOLETA DE CREDITO" And combo_venta.Text <> "GUIA" Then
            valor_total = valor_total - numerofinal

            Round(valor_total)


            txt_desc.Text = txt_desc.Text + numerofinal
            txt_total.Text = valor_total






            '\\prueba de redondear descuento
            Dim valor_descuento_redondeado As String

            valor_descuento_redondeado = txt_desc.Text * 100
            valor_descuento_redondeado = valor_descuento_redondeado / txt_sub_total.Text




            If valor_descuento_redondeado.Length > 5 Then
                valor_descuento_redondeado = valor_descuento_redondeado.Substring(0, 5)
            End If
            '           txt_porcentaje_desc.Text = valor_descuento_redondeado

        End If

        'iva_valor = valor_iva / 100 + 1

        'neto = (txt_total.Text / iva_valor)
        'Round(neto)
        'txt_neto.Text = neto

        'iva = ((txt_neto.Text) * valor_iva / 100)
        'Round(iva)
        'txt_iva.Text = iva

        iva_valor = valor_iva / 100 + 1

        txt_neto.Text = Round(txt_total.Text / iva_valor)

        txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)

        txt_iva.Text = (txt_total.Text) - (txt_neto.Text)

        'txt_neto.Text = Int(txt_total.Text) - (txt_iva.Text)


        ' Strings.Right(TextBox1.Text, 1)

        'If grilla_detalle_venta.Rows.Count <> 0 Then
        '    txt_item.Text = grilla_detalle_venta.Rows.Count
        'End If

        If txt_sub_total.Text = "" Or txt_sub_total.Text = "0" Then
            txt_sub_total_millar.Text = "0"
        Else
            txt_sub_total_millar.Text = Format(Int(txt_sub_total.Text), "###,###,###")
        End If
        If txt_desc.Text = "" Or txt_desc.Text = "0" Then
            txt_desc_millar.Text = "0"
        Else
            txt_desc_millar.Text = Format(Int(txt_desc.Text), "###,###,###")
        End If
        If txt_neto.Text = "" Or txt_neto.Text = "0" Then
            txt_neto_millar.Text = "0"
        Else
            txt_neto_millar.Text = Format(Int(txt_neto.Text), "###,###,###")
        End If
        If txt_iva.Text = "" Or txt_iva.Text = "0" Then
            txt_iva_millar.Text = "0"
        Else
            txt_iva_millar.Text = Format(Int(txt_iva.Text), "###,###,###")
        End If
        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub


    Sub imprimir()
        'Dim VarPorcentajeDesc As String
        Dim VarCantidadDesc As Integer
        'Dim VarDescuentoCliente As Integer
        'Dim porcentaje_desc As Integer
        Dim mensaje As String = ""
        VarCantidadDesc = 0
        fecha()

        If combo_venta.Text = "" Then
            mensaje = "CAMPO DOCUMENTO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            combo_venta.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_vendedor.Text = "-" Then
            mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            Combo_vendedor.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_venta.Text <> "BOLETA" And combo_venta.Text <> "BOLETA DE CREDITO" And combo_venta.Text <> "FACTURA" And combo_venta.Text <> "FACTURA DE CREDITO" And combo_venta.Text <> "GUIA" And combo_venta.Text <> "COTIZACION" Then
            combo_venta.Focus()
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_venta.Text = "GUIA" Then

            If grilla_detalle_venta.Rows.Count = 0 Then
                mensaje = "MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR" + Chr(13) & mensaje
                txt_codigo.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
            If txt_rut_cliente.Text = "" Then
                mensaje = "CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_rut_cliente.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If combo_venta.Text = "" Then
                mensaje = "CAMPO TIPO DE VENTA VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                combo_venta.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
            If combo_condiciones.Text = "" Then
                mensaje = "CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                combo_condiciones.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If


            If txt_rut_vendedor.Text = "" Then
                mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_vendedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If Combo_vendedor.Text = "" Then
                mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_vendedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            'If grilla_detalle_venta.Rows.Count > 16 Then
            '    MsgBox("EN UNA GUIA NO PUEDE AGREGAR MAS DE 16 ITEMS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
            '    txt_codigo.Focus()
            '    Exit Sub
            'End If






            VarCantidadDesc = 0

            If combo_venta.Text = "" Then
                Exit Sub
            End If





            Me.fecha()




            Me.grabar_factura()
            Me.grabar_detalle_factura()
            Me.Enabled = False


            Me.limpiar()
            Me.controles(False, True)
            MsgBox("SE HA GRABADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

            Me.Enabled = True

            Exit Sub
        End If





        If combo_venta.Text = "FACTURA DE CREDITO" Then

            If grilla_detalle_venta.Rows.Count = 0 Then
                mensaje = "MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR" + Chr(13) & mensaje
                txt_codigo.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_rut_cliente.Text = "" Then
                mensaje = "CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_rut_cliente.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If combo_venta.Text = "" Then
                mensaje = "CAMPO TIPO DE VENTA VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                combo_venta.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If combo_condiciones.Text = "" Then
                mensaje = "CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                combo_condiciones.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_rut_vendedor.Text = "" Then
                mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_vendedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If Combo_vendedor.Text = "" Then
                mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_vendedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If


            'If grilla_detalle_venta.Rows.Count > 22 Then
            '    MsgBox("EN UNA FACTURA NO PUEDE AGREGAR MAS DE 22 ITEMS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
            '    txt_codigo.Focus()
            '    Exit Sub
            'End If


            Dim tipo_combo_venta As String
            tipo_combo_venta = combo_venta.Text
            ' If tipo_combo_venta.Length > 12 Then
            tipo_combo_venta = tipo_combo_venta.Substring(0, 7)
            'End If





            Me.Enabled = False


            grabar_factura()
            grabar_detalle_factura()

            Me.Enabled = False
            ' Form_impreso_corectamente.Show()


            limpiar()
            controles(False, True)
            Me.Enabled = True
            MsgBox("SE HA GRABADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

            Exit Sub
        End If






        If combo_venta.Text = "BOLETA" Then

            If grilla_detalle_venta.Rows.Count = 0 Then
                MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo.Focus()
                Exit Sub
            End If

            If combo_venta.Text = "" Then
                MsgBox("CAMPO TIPO DE VENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                combo_venta.Focus()
                Exit Sub
            End If

            If combo_condiciones.Text = "" Then
                MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                combo_condiciones.Focus()
                Exit Sub
            End If

            If txt_rut_vendedor.Text = "" Then
                mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_vendedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If Combo_vendedor.Text = "" Then
                mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_vendedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            'If grilla_detalle_venta.Rows.Count > 12 Then
            '    MsgBox("EN UNA BOLETA NO PUEDE AGREGAR MAS DE 12 ITEMS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
            '    txt_codigo.Focus()
            '    Exit Sub
            'End If


            VarCantidadDesc = 0

            If combo_venta.Text = "" Then
                Exit Sub
            End If











            Me.Enabled = False





            redondear_documento()

            grabar_factura()
            grabar_detalle_factura()
            '  Form_impreso_corectamente.Show()
            Me.Enabled = False


            limpiar()
            controles(False, True)
            '  Me.Enabled = True
            MsgBox("SE HA GRABADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

            Me.Enabled = True
        End If




        If combo_venta.Text = "BOLETA DE CREDITO" Then


            If grilla_detalle_venta.Rows.Count = 0 Then
                MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo.Focus()
                Exit Sub
            End If

            If txt_rut_cliente.Text = "" Then
                MsgBox("CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_rut_cliente.Focus()
                Exit Sub
            End If


            If combo_venta.Text = "" Then
                MsgBox("CAMPO TIPO DE VENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                combo_venta.Focus()
                Exit Sub
            End If


            If combo_condiciones.Text = "" Then
                MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                combo_condiciones.Focus()
                Exit Sub
            End If

            If txt_rut_vendedor.Text = "" Then
                mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_vendedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If Combo_vendedor.Text = "" Then
                mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_vendedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If


            'If grilla_detalle_venta.Rows.Count > 7 Then
            '    MsgBox("EN UNA BOLETA DE CREDITO NO PUEDE AGREGAR MAS DE 7 ITEMS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
            '    txt_codigo.Focus()
            '    Exit Sub
            'End If








            grabar_factura()
            grabar_detalle_factura()
            ' Form_impreso_corectamente.Show()
            Me.Enabled = False


            limpiar()
            controles(False, True)

            '  Me.Enabled = True
            'llenar_combo_ventas()
            ' controles(False, True)
            MsgBox("SE HA GRABADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

            Me.Enabled = True
        End If






        If combo_venta.Text = "FACTURA" Then

            If grilla_detalle_venta.Rows.Count = 0 Then
                MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo.Focus()
                Exit Sub
            End If

            If txt_rut_cliente.Text = "" Then
                MsgBox("CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_rut_cliente.Focus()
                Exit Sub
            End If

            If combo_venta.Text = "" Then
                MsgBox("CAMPO TIPO DE VENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                combo_venta.Focus()
                Exit Sub
            End If

            If combo_condiciones.Text = "" Then
                MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                combo_condiciones.Focus()
                Exit Sub
            End If

            If txt_rut_vendedor.Text = "" Then
                mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_vendedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If Combo_vendedor.Text = "" Then
                mensaje = "CAMPO VENDEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_vendedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            'If grilla_detalle_venta.Rows.Count > 22 Then
            '    MsgBox("EN UNA FACTURA NO PUEDE AGREGAR MAS DE 22 ITEMS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
            '    txt_codigo.Focus()
            '    Exit Sub
            'End If






            Me.Enabled = False

            redondear_documento()


            grabar_factura()
            grabar_detalle_factura()

            Me.Enabled = False
            '  Form_impreso_corectamente.Show()


            limpiar()
            controles(False, True)
            MsgBox("SE HA GRABADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

            Me.Enabled = True
        End If


    End Sub



    'Sub guardar_descuento()
    '    Dim VarCodProducto As String
    '    Dim varnombre As String
    '    Dim vartecnico As String
    '    Dim VarValorUnitario As Integer
    '    Dim VarCantidad As Integer
    '    Dim VarPorcentaje As Integer
    '    Dim VarDescuento As Integer
    '    Dim VarNeto As Integer
    '    Dim VarIva As Integer
    '    Dim VarSubtotal As Integer
    '    Dim VarTotal As Integer
    '    Dim VarProveedor As String
    '    Dim VarCosto As Integer
    '    Dim VarSaldo As Integer
    '    Dim desc As Integer
    '    Dim subtotal As Integer
    '    Dim neto As Integer
    '    Dim IVA As Integer
    '    Dim total As Integer

    '    'Me.txt_porcentaje_desc.Text = Trim(Replace(Me.txt_porcentaje_desc.Text, " ", ""))
    '    'Me.txt_porcentaje_desc.Text = Trim(Replace(Me.txt_porcentaje_desc.Text, "  ", ""))
    '    'Me.txt_porcentaje_desc.Text = Trim(Replace(Me.txt_porcentaje_desc.Text, "   ", ""))
    '    'Me.txt_porcentaje_desc.Text = Trim(Replace(Me.txt_porcentaje_desc.Text, "    ", ""))

    '    'Me.txt_porcentaje_desc.Text = LTrim(Replace(Me.txt_porcentaje_desc.Text, " ", ""))
    '    'Me.txt_porcentaje_desc.Text = LTrim(Replace(Me.txt_porcentaje_desc.Text, "  ", ""))
    '    'Me.txt_porcentaje_desc.Text = LTrim(Replace(Me.txt_porcentaje_desc.Text, "   ", ""))
    '    'Me.txt_porcentaje_desc.Text = LTrim(Replace(Me.txt_porcentaje_desc.Text, "    ", ""))

    '    'Me.txt_porcentaje_desc.Text = RTrim(Replace(Me.txt_porcentaje_desc.Text, " ", ""))
    '    'Me.txt_porcentaje_desc.Text = RTrim(Replace(Me.txt_porcentaje_desc.Text, "  ", ""))
    '    'Me.txt_porcentaje_desc.Text = RTrim(Replace(Me.txt_porcentaje_desc.Text, "   ", ""))
    '    'Me.txt_porcentaje_desc.Text = RTrim(Replace(Me.txt_porcentaje_desc.Text, "    ", ""))

    '    'If txt_porcentaje_desc.Text = "" Then
    '    '    txt_porcentaje_desc.Text = "0"
    '    'End If

    '    For i = 0 To grilla_detalle_venta.Rows.Count - 1

    '        VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value
    '        varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value
    '        vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value
    '        VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value
    '        VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value
    '        VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value
    '        VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value
    '        VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value
    '        VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value
    '        VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value
    '        VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value
    '        'VarSaldo = grilla_detalle.Rows(i).Cells(11).Value
    '        'VarProveedor = grilla_detalle.Rows(i).Cells(12).Value
    '        'VarCosto = grilla_detalle.Rows(i).Cells(13).Value

    '        'grilla_detalle.Rows.Remove(grilla_detalle.Rows(i))
    '        ' grilla_detalle.Rows.RemoveAt(i)
    '        desc = ((VarValorUnitario * VarCantidad) * txt_porcentaje_desc.Text) / 100
    '        subtotal = (VarValorUnitario * VarCantidad)
    '        neto = (subtotal / 1.19)
    '        IVA = (neto) * 19 / 100
    '        total = subtotal - desc

    '        'grilla_detalle.Rows.Add(VarCodProducto, varnombre, vartecnico, VarValorUnitario, VarCantidad, lbl_descto.Text, desc, neto, IVA, subtotal, total, VarSaldo, VarProveedor, VarCosto)
    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_ajuste (cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, saldo ,proveedor, costo) values('" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (txt_porcentaje_desc.Text) & "," & (desc) & "," & (neto) & ", " & (IVA) & "," & (subtotal) & "," & (total) & "," & (VarSaldo) & ",'" & (VarProveedor) & "','" & (VarCosto) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        conexion.Close()


    '    Next
    'End Sub

    'Sub cargar_descuento()

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    SC.CommandText = "select * from detalle_ajuste"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    'grilla_detalle_venta.Rows.Clear()
    '    'grilla_detalle_venta.Columns.Clear()
    '    'grilla_detalle_venta.Columns.Add("Cod_producto", "CODIGO")
    '    'grilla_detalle_venta.Columns.Add("nombre", "NOMBRE")
    '    'grilla_detalle_venta.Columns.Add("numero_tecnico", "N° TECNICO")
    '    'grilla_detalle_venta.Columns.Add("valor_unitario", "VALOR")
    '    'grilla_detalle_venta.Columns.Add("cantidad", "CANT.")
    '    'grilla_detalle_venta.Columns.Add("neto", "NETO")
    '    'grilla_detalle_venta.Columns.Add("iva", "IVA")
    '    'grilla_detalle_venta.Columns.Add("subtotal", "SUB-TOT.")
    '    'grilla_detalle_venta.Columns.Add("porcentaje_desc", "    %")
    '    'grilla_detalle_venta.Columns.Add("descuento", " DESC.")
    '    'grilla_detalle_venta.Columns.Add("total", "TOTAL")

    '    'grilla_detalle_venta.Columns(0).Visible = True
    '    'grilla_detalle_venta.Columns(1).Visible = True
    '    'grilla_detalle_venta.Columns(2).Visible = True
    '    'grilla_detalle_venta.Columns(3).Visible = True
    '    'grilla_detalle_venta.Columns(4).Visible = True
    '    'grilla_detalle_venta.Columns(5).Visible = False
    '    'grilla_detalle_venta.Columns(6).Visible = False
    '    'grilla_detalle_venta.Columns(7).Visible = True
    '    'grilla_detalle_venta.Columns(8).Visible = True
    '    'grilla_detalle_venta.Columns(9).Visible = True
    '    'grilla_detalle_venta.Columns(10).Visible = True

    '    'grilla_detalle_venta.Columns(0).Width = 85
    '    'grilla_detalle_venta.Columns(1).Width = 210
    '    'grilla_detalle_venta.Columns(2).Width = 180
    '    'grilla_detalle_venta.Columns(3).Width = 85
    '    'grilla_detalle_venta.Columns(4).Width = 85
    '    'grilla_detalle_venta.Columns(5).Width = 85
    '    'grilla_detalle_venta.Columns(6).Width = 85
    '    'grilla_detalle_venta.Columns(7).Width = 85
    '    'grilla_detalle_venta.Columns(8).Width = 62
    '    'grilla_detalle_venta.Columns(9).Width = 85
    '    'grilla_detalle_venta.Columns(10).Width = 85








    '    Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
    '                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
    '                                            DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
    '                                             DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
    '                                              DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
    '                                               DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
    '                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
    '                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
    '                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
    '        Next
    '    End If



    '    'grilla_detalle_venta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'grilla_detalle_venta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'grilla_detalle_venta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'grilla_detalle_venta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'grilla_detalle_venta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'grilla_detalle_venta.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'grilla_detalle_venta.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'grilla_detalle_venta.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight








    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "delete from detalle_ajuste"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    conexion.Close()



    'End Sub


    'segun el documento seleccionado graba el detalle de este mediante un ciclo for.
    'disminuye la cantidad de los productos que se agregaron.
    Sub grabar_detalle_factura()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer




        Dim VarTipoDoc As String
        VarTipoDoc = ""
        If combo_venta.Text = "BOLETA" Then
            VarTipoDoc = "BOLETA"
        End If

        If combo_venta.Text = "BOLETA DE CREDITO" Then
            VarTipoDoc = "BOLETA"
        End If

        If combo_venta.Text = "FACTURA" Then
            VarTipoDoc = "FACTURA"
        End If

        If combo_venta.Text = "FACTURA DE CREDITO" Then
            VarTipoDoc = "FACTURA"
        End If

        If combo_venta.Text = "GUIA" Then
            VarTipoDoc = "GUIA"
        End If

        Dim VarFormaDePago As String
        Dim VarMonto As Integer

        'If tipo_impresion_sistema = "TICKET" Then
        '    If combo_venta.Text <> "COTIZACION" Then
        '        If combo_condiciones.Text = "PAGO COMBINADO" Then
        '            For i = 0 To Form_pago_combinado.grilla_pago_combinado.Rows.Count - 1
        '                VarFormaDePago = Form_pago_combinado.grilla_pago_combinado.Rows(i).Cells(0).Value.ToString
        '                VarMonto = Form_pago_combinado.grilla_pago_combinado.Rows(i).Cells(1).Value.ToString

        '                SC.Connection = conexion
        '                SC.CommandText = "insert into detalle_condicion_de_pago_temporal (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (VarMonto) & "', '" & (VarFormaDePago) & "', 'EMITIDA', '" & (form_Menu_admin.dtp_fecha.Text) & "')"
        '                DA.SelectCommand = SC
        '                DA.Fill(DT)
        '            Next
        '            Form_pago_combinado.Close()
        '        End If

        '        If combo_condiciones.Text = "LETRA" Then
        '            SC.Connection = conexion
        '            SC.CommandText = "insert into detalle_condicion_de_pago_temporal (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (Form_calcular.txt_total.Text) & "', 'CREDITO', 'EMITIDA', '" & (form_Menu_admin.dtp_fecha.Text) & "')"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)

        '            If Val(Form_calcular.txt_pie.Text) <> 0 Then
        '                SC.Connection = conexion
        '                SC.CommandText = "insert into detalle_condicion_de_pago_temporal (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (Form_calcular.txt_pie.Text) & "', '" & (Form_calcular.combo_condiciones.Text) & "', 'EMITIDA', '" & (form_Menu_admin.dtp_fecha.Text) & "')"
        '                DA.SelectCommand = SC
        '                DA.Fill(DT)
        '            End If
        '        End If

        '        If combo_condiciones.Text = "CONVENIO" Then
        '            SC.Connection = conexion
        '            SC.CommandText = "insert into detalle_condicion_de_pago_temporal (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (Form_convenios.txt_total.Text) & "', 'CREDITO', 'EMITIDA', '" & (form_Menu_admin.dtp_fecha.Text) & "')"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)

        '            If Val(Form_convenios.txt_pie.Text) <> 0 Then
        '                SC.Connection = conexion
        '                SC.CommandText = "insert into detalle_condicion_de_pago_temporal (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (Form_convenios.txt_pie.Text) & "', '" & (Form_convenios.combo_condiciones.Text) & "', 'EMITIDA', '" & (form_Menu_admin.dtp_fecha.Text) & "')"
        '                DA.SelectCommand = SC
        '                DA.Fill(DT)
        '            End If
        '        End If

        '        If combo_condiciones.Text <> "PAGO COMBINADO" And combo_condiciones.Text <> "LETRA" And combo_condiciones.Text <> "CONVENIO" Then
        '            SC.Connection = conexion
        '            SC.CommandText = "insert into detalle_condicion_de_pago_temporal (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (txt_total.Text) & "', '" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (form_Menu_admin.dtp_fecha.Text) & "')"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        End If

        '    Else


        If combo_condiciones.Text = "PAGO COMBINADO" Then
            'For i = 0 To Form_pago_combinado.grilla_pago_combinado.Rows.Count - 1
            '    VarFormaDePago = Form_pago_combinado.grilla_pago_combinado.Rows(i).Cells(0).Value.ToString
            '    VarMonto = Form_pago_combinado.grilla_pago_combinado.Rows(i).Cells(1).Value.ToString

            '    SC.Connection = conexion
            '    SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_nro_doc_imprimir.Text) & ", '" & (VarTipoDoc) & "', '" & (VarMonto) & "', '" & (VarFormaDePago) & "', 'EMITIDA', '" & (mifecha2) & "')"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'Next
            'Form_pago_combinado.Close()
        End If

        If combo_condiciones.Text = "LETRA" Then
            'SC.Connection = conexion
            'SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_nro_doc_imprimir.Text) & ", '" & (VarTipoDoc) & "', '" & (Form_calcular.txt_total.Text) & "', 'CREDITO', 'EMITIDA', '" & (mifecha2) & "')"
            'DA.SelectCommand = SC
            'DA.Fill(DT)

            If Val(txt_pie.Text) <> 0 Then
                SC.Connection = conexion
                SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values(" & (txt_nro_doc_imprimir.Text) & ", '" & (VarTipoDoc) & "', '" & (txt_pie.Text) & "', '" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (mifecha2) & "', '" & (nombre_pc) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        End If

        If combo_condiciones.Text = "CONVENIO" Then
            'SC.Connection = conexion
            'SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_nro_doc_imprimir.Text) & ", '" & (VarTipoDoc) & "', '" & (Form_convenios.txt_total.Text) & "', 'CREDITO', 'EMITIDA', '" & (mifecha2) & "')"
            'DA.SelectCommand = SC
            'DA.Fill(DT)

            If Val(txt_pie.Text) <> 0 Then
                SC.Connection = conexion
                SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values(" & (txt_nro_doc_imprimir.Text) & ", '" & (VarTipoDoc) & "', '" & (txt_pie.Text) & "', '" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (mifecha2) & "', '" & (nombre_pc) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        End If

        If combo_condiciones.Text <> "PAGO COMBINADO" And combo_condiciones.Text <> "LETRA" And combo_condiciones.Text <> "CONVENIO" Then
            'SC.Connection = conexion
            'SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_nro_doc_imprimir.Text) & ", '" & (VarTipoDoc) & "', '" & (txt_total.Text) & "', '" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (mifecha2) & "')"
            'DA.SelectCommand = SC
            'DA.Fill(DT)
        End If
        'End If
        ' End If



        If combo_venta.Text = "FACTURA" Then

            For i = 0 To grilla_detalle_venta.Rows.Count - 1

                VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                'conexion.Close()
                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                'SC.Connection = conexion
                'SC.CommandText = "select cantidad, proveedor, costo from productos where cod_producto='" & (VarCodProducto) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
                'DS.Tables.Add(DT)

                'If DS.Tables(DT.TableName).Rows.Count > 0 Then
                '    VarSaldo = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                '    VarProveedor = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                '    VarCosto = DS.Tables(DT.TableName).Rows(0).Item("costo")
                '    VarSaldo = VarSaldo - VarCantidad
                'End If
                'conexion.Close()



                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_factura (n_factura, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_nro_doc_imprimir.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()

                SC.Connection = conexion
                SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()

                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (txt_nro_doc_imprimir.Text) & ",'FACTURA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"
                ' SC.CommandText = "insert into detalle_total (                                                                                                                                                      n_total,                 TIPO,           cod_producto,           nombre,                valor_unitario,              cantidad,          descuento,               neto,              iva,                subtotal,        total,      movimiento,  fecha,                vendedor, estado) values(" & (txt_factura.Text) & ",'FACTURA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE'," & (VarSaldo) & ",'" & (VarProveedor) & "','" & (VarCosto) & "','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"

                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()
            Next
        End If


        If combo_venta.Text = "FACTURA DE CREDITO" Then
            For i = 0 To grilla_detalle_venta.Rows.Count - 1

                VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                'conexion.Close()
                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                'SC.Connection = conexion
                'SC.CommandText = "select cantidad, proveedor, costo from productos where cod_producto='" & (VarCodProducto) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
                'DS.Tables.Add(DT)

                'If DS.Tables(DT.TableName).Rows.Count > 0 Then
                '    VarSaldo = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                '    VarProveedor = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                '    VarCosto = DS.Tables(DT.TableName).Rows(0).Item("costo")
                '    VarSaldo = VarSaldo - VarCantidad
                'End If
                'conexion.Close()

                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                SC.Connection = conexion
                '  SC.CommandText = "insert into detalle_factura_credito (n_factura_credito, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, saldo ,proveedor, costo) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & "," & (VarSaldo) & ",'" & (VarProveedor) & "','" & (VarCosto) & "')"

                '   SC.CommandText = "insert into detalle_factura (n_factura, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, saldo ,proveedor, costo) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & "," & (VarSaldo) & ",'" & (VarProveedor) & "','" & (VarCosto) & "')"
                SC.CommandText = "insert into detalle_factura (n_factura, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_nro_doc_imprimir.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()

                SC.Connection = conexion
                SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()


                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_doc_imprimir.Text) & ",'FACTURA DE CREDITO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"
                '   SC.CommandText = "insert into detalle_total (                                                                                                                                                      n_total,             TIPO,                      cod_producto,               nombre,                 valor_unitario,             cantidad,           descuento,               neto,              iva,             subtotal,              total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'FACTURA DE CREDITO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE'," & (VarSaldo) & ",'" & (VarProveedor) & "','" & (VarCosto) & "','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"

                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()


            Next
        End If

        If combo_venta.Text = "GUIA" Then
            For i = 0 To grilla_detalle_venta.Rows.Count - 1


                VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                'conexion.Close()
                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                'SC.Connection = conexion
                'SC.CommandText = "select cantidad, proveedor, costo from productos where cod_producto='" & (VarCodProducto) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
                'DS.Tables.Add(DT)

                'If DS.Tables(DT.TableName).Rows.Count > 0 Then
                '    VarSaldo = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                '    VarProveedor = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                '    VarCosto = DS.Tables(DT.TableName).Rows(0).Item("costo")
                '    VarSaldo = VarSaldo - VarCantidad
                'End If
                'conexion.Close()


                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_guia (n_guia, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, detalle_descuento, porcentaje_desc, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_nro_doc_imprimir.Text) & "," & (VarCodProducto) & ",'" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()

                SC.Connection = conexion
                SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()


                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_doc_imprimir.Text) & ",'GUIA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"
                ' SC.CommandText = "insert into detalle_total (                                                                                                                                                          n_total,             TIPO,          cod_producto,           nombre,                 valor_unitario,         cantidad,           descuento,              neto,                iva,           subtotal,               total,   movimiento,     fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'GUIA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE'," & (VarSaldo) & ",'" & (VarProveedor) & "','" & (VarCosto) & "','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"


                DA.SelectCommand = SC
                DA.Fill(DT)
                conexion.Close()
            Next
        End If



        If combo_venta.Text = "COTIZACION" Then

            For i = 0 To grilla_detalle_venta.Rows.Count - 1

                VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                'conexion.Close()
                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                'SC.Connection = conexion
                'SC.CommandText = "select cantidad, proveedor, costo from productos where cod_producto='" & (VarCodProducto) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
                'DS.Tables.Add(DT)

                'If DS.Tables(DT.TableName).Rows.Count > 0 Then
                '    VarSaldo = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                '    VarProveedor = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                '    VarCosto = DS.Tables(DT.TableName).Rows(0).Item("costo")
                '    VarSaldo = VarSaldo - VarCantidad
                'End If
                'conexion.Close()

                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_cotizacion (n_cotizacion, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_nro_doc_imprimir.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()
            Next
        End If

        If combo_venta.Text = "BOLETA" Then
            For i = 0 To grilla_detalle_venta.Rows.Count - 1

                VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                'conexion.Close()
                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                'SC.Connection = conexion
                'SC.CommandText = "select cantidad, proveedor, costo from productos where cod_producto='" & (VarCodProducto) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
                'DS.Tables.Add(DT)

                'If DS.Tables(DT.TableName).Rows.Count > 0 Then
                '    VarSaldo = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                '    VarProveedor = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                '    VarCosto = DS.Tables(DT.TableName).Rows(0).Item("costo")
                '    VarSaldo = VarSaldo - VarCantidad
                'End If
                'conexion.Close()


                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_boleta (n_boleta, cod_producto, detalle_nombre,  numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_nro_doc_imprimir.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()

                SC.Connection = conexion
                SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()

                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()
                ' varnombre.Length
                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_doc_imprimir.Text) & ",'BOLETA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"
                ' SC.CommandText = "insert into detalle_total (                                                                                                                                                      n_total,                TIPO,       cod_producto,                nombre,                 valor_unitario,            cantidad,           descuento,               neto,           iva,               subtotal,           total, movimiento,         fecha,           vendedor, estado) values(" & (txt_factura.Text) & ",'BOLETA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE'," & (VarSaldo) & ",'" & (VarProveedor) & "','" & (VarCosto) & "','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"




                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()
            Next
        End If

        If combo_venta.Text = "BOLETA DE CREDITO" Then




            For i = 0 To grilla_detalle_venta.Rows.Count - 1

                VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                'conexion.Close()
                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                'SC.Connection = conexion
                'SC.CommandText = "select cantidad, proveedor, costo from productos where cod_producto='" & (VarCodProducto) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
                'DS.Tables.Add(DT)

                'If DS.Tables(DT.TableName).Rows.Count > 0 Then
                '    VarSaldo = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                '    VarProveedor = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                '    VarCosto = DS.Tables(DT.TableName).Rows(0).Item("costo")
                '    VarSaldo = VarSaldo - VarCantidad
                'End If
                'conexion.Close()

                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_boleta (n_boleta, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc,  detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_nro_doc_imprimir.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                ' SC.CommandText = "insert into detalle_boleta (                                                                                                                                                                                                                         n_boleta,            cod_producto,              detalle_nombre,          numero_tecnico,         valor_unitario,             cantidad,          porcentaje_desc,         detalle_descuento,      detalle_neto,      detalle_iva,    detalle_subtotal,    detalle_total, saldo ,proveedor, costo) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & "," & (VarSaldo) & ",'" & (VarProveedor) & "','" & (VarCosto) & "')"

                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()



                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                'SC.Connection = conexion
                'SC.CommandText = "insert into detalle_boleta_credito (n_boleta_credito, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc,  detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, saldo ,proveedor, costo) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & "," & (VarSaldo) & ",'" & (VarProveedor) & "','" & (VarCosto) & "')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
                'conexion.Close()



                SC.Connection = conexion
                SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()

                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_doc_imprimir.Text) & ",'BOLETA DE CREDITO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"
                ' SC.CommandText = "insert into detalle_total (                                                                                                                                                                              n_total,                TIPO,                   cod_producto,                nombre,             valor_unitario,            cantidad,           descuento,                  neto,                iva,           subtotal,               total,   movimiento, saldo ,proveedor, costo, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'BOLETA DE CREDITO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE'," & (VarSaldo) & ",'" & (VarProveedor) & "','" & (VarCosto) & "','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"


                DA.SelectCommand = SC
                DA.Fill(DT)
                'conexion.Close()
            Next
        End If
    End Sub






    Sub grabar_factura()
        If combo_venta.Text = "GUIA" Then
            SC.Connection = conexion
            SC.CommandText = "insert into guia (caja, n_guia, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable,rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, vehiculo, patente, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_nro_doc_imprimir.Text) & " , '" & ("GUIA") & "', '" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (mifecha2) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ", '" & (combo_condiciones.Text) & "','" & ("SIN FACTURAR") & "','" & (txt_rut_vendedor.Text) & "','-','-','" & (mirecintoempresa) & "','0','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "', 'DIGITADA', '-', '-', '0', '-'," & (txt_total.Text) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If combo_venta.Text = "FACTURA DE CREDITO" Then
            SC.Connection = conexion
            SC.CommandText = "insert into factura (caja, n_factura, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_nro_doc_imprimir.Text) & ",'" & ("FACTURA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "', '" & (mifecha2) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ", '" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','-','-','" & (mirecintoempresa) & "','0','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "', 'DIGITADA', '0', '-'," & (txt_total.Text) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into creditos (n_creditos, tipo, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza, pie, condicion_de_pago_pie) values (" & (txt_nro_doc_imprimir.Text) & ",'" & ("FACTURA") & "','" & ("FACTURA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (mifecha2) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & "," & (txt_total.Text) & ", '" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_nro_doc_imprimir.Text) & "','FACTURA', '" & (mirecintoempresa) & "', '" & (dtp_vencimiento.Text) & "', '0000-00-00', '1', '1', '0', '0',  '0',  '-')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If


        If combo_venta.Text = "BOLETA" Then
            SC.Connection = conexion
            SC.CommandText = "insert into BOLETA (caja, n_boleta, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva,  subtotal, total, condiciones,estado, usuario_responsable, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_nro_doc_imprimir.Text) & " , 'BOLETA','11111111-1','0','" & (mifecha2) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ", '" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "', 'DIGITADA', '0', '-'," & (txt_total.Text) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If


        If combo_venta.Text = "BOLETA DE CREDITO" Then

            SC.Connection = conexion
            SC.CommandText = "insert into BOLETA (caja, n_boleta, tipo, rut_cliente,  codigo_cliente,  fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_nro_doc_imprimir.Text) & " , 'BOLETA DE CREDITO', '" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (mifecha2) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ", '" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "', 'DIGITADA', '0', '-'," & (txt_total.Text) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza, pie, condicion_de_pago_pie) values (" & (txt_nro_doc_imprimir.Text) & " , '" & ("BOLETA") & "','" & ("BOLETA") & "', '" & (txt_rut_cliente.Text) & "', '" & (txt_cod_cliente.Text) & "','" & (mifecha2) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ", " & (txt_total.Text) & ", '" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "'," & (txt_nro_doc_imprimir.Text) & " ,'BOLETA', '" & (mirecintoempresa) & "', '" & (dtp_vencimiento.Text) & "', '0000-00-00', '1', '1', '0', '0', '0', '-')"
            DA.SelectCommand = SC
            DA.Fill(DT)

        End If





        If combo_venta.Text = "FACTURA" Then

            SC.Connection = conexion
            SC.CommandText = "insert into factura(caja, n_factura, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto,iva, subtotal,total,condiciones,estado,usuario_responsable,rut_retira, nombre_retira, recinto, hora, porcentaje_desc, orden, tipo_impresion, pie, condicion_de_pago_pie, comision)values('" & (nombre_pc) & "', " & (txt_nro_doc_imprimir.Text) & ",'" & ("FACTURA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (mifecha2) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ", '" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','-','-','" & (mirecintoempresa) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "', '0', 'DIGITADA', '0', '-'," & (txt_total.Text) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)

        End If
    End Sub



























    Sub grabar_detalle_temporal()
        Dim VarCodProducto As Integer
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As Integer
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        Dim VarProveedor As String
        Dim VarCosto As Integer
        Dim VarSaldo As Integer

        fecha()
        For i = 0 To grilla_detalle_venta.Rows.Count - 1

            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select cantidad, proveedor , costo from productos where cod_producto='" & (VarCodProducto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarSaldo = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                VarProveedor = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                VarCosto = DS.Tables(DT.TableName).Rows(0).Item("costo")
                VarSaldo = VarSaldo - VarCantidad
            End If
            conexion.Close()






            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "insert into factura_temporal (n_factura,documento, codigo_producto, nombre_producto, numero_tecnico, cantidad, precio, porcentaje_desc, subtotal_detalle, total_detalle, NOMBRE_VENDEDOR) values('" & (txt_nro_doc_imprimir.Text) & "', '" & (combo_venta.Text) & "','" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarCantidad) & "," & (VarValorUnitario) & "," & (VarPorcentaje) & "," & (VarSubtotal) & "," & (VarTotal) & ",'" & (minombre) & "')"

            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub




    'segun el TIPO de documento selecconado llama al sub grabar y verifica que la csantidad de items no sobrepase el limite.
    Private Sub btn_grabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.Click

        If txt_porcentaje_desc.Text = "" Then
            txt_porcentaje_desc.Text = "0"
        End If

        If txt_pie.Text = "" Then
            txt_pie.Text = "0"
        End If


        If txt_nro_doc_imprimir.Text = "" Then
            MsgBox("CAMPO NRO. DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc_imprimir.Focus()
            Exit Sub
        Else
            If combo_venta.Text = "BOLETA" Then
                Consultas_SQL("select * from BOLETA where n_boleta = '" & (txt_nro_doc_imprimir.Text) & "' and TIPO <> 'AJUSTE'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    MsgBox("NRO. DE DOCUMENTO YA EXISTENTE", 0 + 16, "ERROR")
                    Exit Sub
                End If
            End If

            If combo_venta.Text = "BOLETA DE CREDITO" Then
                Consultas_SQL("select * from BOLETA where n_boleta = '" & (txt_nro_doc_imprimir.Text) & "' and TIPO <> 'AJUSTE'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    MsgBox("NRO. DE DOCUMENTO YA EXISTENTE", 0 + 16, "ERROR")
                    Exit Sub
                End If
            End If

            If combo_venta.Text = "FACTURA" Then
                Consultas_SQL("select * from factura where n_factura = '" & (txt_nro_doc_imprimir.Text) & "' and TIPO <> 'AJUSTE'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    MsgBox("NRO. DE DOCUMENTO YA EXISTENTE", 0 + 16, "ERROR")
                    Exit Sub
                End If
            End If


            If combo_venta.Text = "FACTURA DE CREDITO" Then
                Consultas_SQL("select * from factura where n_factura = '" & (txt_nro_doc_imprimir.Text) & "' and TIPO <> 'AJUSTE'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    MsgBox("NRO. DE DOCUMENTO YA EXISTENTE", 0 + 16, "ERROR")
                    Exit Sub
                End If
            End If

            If combo_venta.Text = "GUIA" Then
                Consultas_SQL("select * from guia where n_guia = '" & (txt_nro_doc_imprimir.Text) & "' and TIPO <> 'AJUSTE'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    MsgBox("NRO. DE DOCUMENTO YA EXISTENTE", 0 + 16, "ERROR")
                    Exit Sub
                End If
            End If


            If combo_venta.Text = "NOTA DE CREDITO" Then
                Form_seleccionar_documento_para_nota_credito_manuales.Show()
                Me.Enabled = False
                Exit Sub
            End If

            imprimir()


        End If





        'Dim VarPorcentajeDesc As String
        'Dim VarCantidadDesc As Integer
        'Dim VarDescuentoCliente As Integer
        'Dim porcentaje_desc As Integer
        'Dim mensaje As String = ""

        'If combo_venta.Text = "GUIA" Or combo_venta.Text = "FACTURA" Or combo_venta.Text = "FACTURA DE CREDITO" Then
        '    If grilla_detalle_venta.Rows.Count = 0 Then
        '        mensaje = "MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR" + Chr(13) & mensaje
        '        txt_codigo.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    ElseIf txt_rut.Text = "" Then
        '        mensaje = "CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '        txt_rut.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    ElseIf txt_nombre_retira.Text = "" Then
        '        mensaje = "CAMPO CLIENTE QUE RETIRA VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '        txt_rut_retira.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    ElseIf combo_venta.Text = "" Then
        '        mensaje = "CAMPO TIPO DE VENTA VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '        combo_venta.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    ElseIf combo_condiciones.Text = "" Then
        '        mensaje = "CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '        combo_condiciones.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Else

        '        VarCantidadDesc = 0

        '        If combo_venta.Text = "" Then
        '            Exit Sub
        '        End If

        '        If txt_porcentaje_desc.Text = "" Then
        '            porcentaje_desc = 0
        '        Else
        '            porcentaje_desc = txt_porcentaje_desc.Text
        '        End If

        '        If txt_descuento_cliente.Text = "" Then
        '            VarDescuentoCliente = 0
        '        Else
        '            VarDescuentoCliente = txt_descuento_cliente.Text
        '        End If

        '        For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '            VarPorcentajeDesc = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '            If VarPorcentajeDesc <> "0" Then
        '                VarCantidadDesc = VarCantidadDesc + 1
        '            End If
        '        Next

        '        If combo_venta.Text = "FACTURA" Or combo_venta.Text = "BOLETA" Or combo_venta.Text = "COTIZACION" Then
        '            If Int(VarCantidadDesc) <> "0" And Int(porcentaje_desc) > Int(valor_descuento_maximo) Then

        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(VarCantidadDesc) <> "0" Then
        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(porcentaje_desc) > Int(valor_descuento_maximo) Then
        '                Form_autorizacion.Show()
        '                Form_autorizacion.lbl_autorizacion.Text = "EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Me.Enabled = False
        '                Exit Sub
        '            End If
        '        End If

        '        If combo_venta.Text = "GUIA" Or combo_venta.Text = "FACTURA DE CREDITO" Or combo_venta.Text = "BOLETA DE CREDITO" Then
        '            If Int(VarCantidadDesc) <> "0" And Int(porcentaje_desc) > Int(VarDescuentoCliente) Then

        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(VarCantidadDesc) <> "0" Then
        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(porcentaje_desc) > Int(VarDescuentoCliente) Then
        '                Form_autorizacion.Show()
        '                Form_autorizacion.lbl_autorizacion.Text = "EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Me.Enabled = False
        '                Exit Sub
        '            End If
        '        End If

        '    End If
        '    crear_numero_factura()
        '    imprimir()
        '    crear_archivo_plano()
        '    controles(False, True)

        '    Exit Sub
        'End If















        'If combo_venta.Text = "BOLETA" Or combo_venta.Text = "COTIZACION" Then
        '    If grilla_detalle_venta.Rows.Count = 0 Then
        '        mensaje = "MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR" + Chr(13) & mensaje
        '        txt_codigo.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    ElseIf combo_venta.Text = "" Then
        '        mensaje = "CAMPO TIPO DE VENTA VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '        combo_venta.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    ElseIf combo_condiciones.Text = "" Then
        '        mensaje = "CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '        combo_condiciones.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Else

        '        VarCantidadDesc = 0

        '        If combo_venta.Text = "" Then
        '            Exit Sub
        '        End If

        '        If txt_porcentaje_desc.Text = "" Then
        '            porcentaje_desc = 0
        '        Else
        '            porcentaje_desc = txt_porcentaje_desc.Text
        '        End If

        '        If txt_descuento_cliente.Text = "" Then
        '            VarDescuentoCliente = 0
        '        Else
        '            VarDescuentoCliente = txt_descuento_cliente.Text
        '        End If

        '        For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '            VarPorcentajeDesc = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '            If VarPorcentajeDesc <> "0" Then
        '                VarCantidadDesc = VarCantidadDesc + 1
        '            End If
        '        Next

        '        If combo_venta.Text = "FACTURA" Or combo_venta.Text = "BOLETA" Or combo_venta.Text = "COTIZACION" Then
        '            If Int(VarCantidadDesc) <> "0" And Int(porcentaje_desc) > Int(valor_descuento_maximo) Then

        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(VarCantidadDesc) <> "0" Then
        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(porcentaje_desc) > Int(valor_descuento_maximo) Then
        '                Form_autorizacion.Show()
        '                Form_autorizacion.lbl_autorizacion.Text = "EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Me.Enabled = False
        '                Exit Sub
        '            End If
        '        End If

        '        If combo_venta.Text = "GUIA" Or combo_venta.Text = "FACTURA DE CREDITO" Or combo_venta.Text = "BOLETA DE CREDITO" Then
        '            If Int(VarCantidadDesc) <> "0" And Int(porcentaje_desc) > Int(VarDescuentoCliente) Then

        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(VarCantidadDesc) <> "0" Then
        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(porcentaje_desc) > Int(VarDescuentoCliente) Then
        '                Form_autorizacion.Show()
        '                Form_autorizacion.lbl_autorizacion.Text = "EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Me.Enabled = False
        '                Exit Sub
        '            End If
        '        End If

        '    End If
        '    crear_numero_factura()
        '    imprimir()
        '    crear_archivo_plano()
        '    controles(False, True)
        '    limpiar()
        '    Exit Sub
        'End If











        'If combo_venta.Text = "BOLETA DE CREDITO" Then
        '    If grilla_detalle_venta.Rows.Count = 0 Then
        '        mensaje = "MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR" + Chr(13) & mensaje
        '        txt_codigo.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    ElseIf txt_rut.Text = "" Then
        '        mensaje = "CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '        txt_rut.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    ElseIf combo_venta.Text = "" Then
        '        mensaje = "CAMPO TIPO DE VENTA VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '        combo_venta.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    ElseIf combo_condiciones.Text = "" Then
        '        mensaje = "CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '        combo_condiciones.Focus()
        '        MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Else

        '        VarCantidadDesc = 0

        '        If combo_venta.Text = "" Then
        '            Exit Sub
        '        End If

        '        If txt_porcentaje_desc.Text = "" Then
        '            porcentaje_desc = 0
        '        Else
        '            porcentaje_desc = txt_porcentaje_desc.Text
        '        End If

        '        If txt_descuento_cliente.Text = "" Then
        '            VarDescuentoCliente = 0
        '        Else
        '            VarDescuentoCliente = txt_descuento_cliente.Text
        '        End If

        '        For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '            VarPorcentajeDesc = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '            If VarPorcentajeDesc <> "0" Then
        '                VarCantidadDesc = VarCantidadDesc + 1
        '            End If
        '        Next

        '        If combo_venta.Text = "FACTURA" Or combo_venta.Text = "BOLETA" Or combo_venta.Text = "COTIZACION" Then
        '            If Int(VarCantidadDesc) <> "0" And Int(porcentaje_desc) > Int(valor_descuento_maximo) Then

        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(VarCantidadDesc) <> "0" Then
        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(porcentaje_desc) > Int(valor_descuento_maximo) Then
        '                Form_autorizacion.Show()
        '                Form_autorizacion.lbl_autorizacion.Text = "EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Me.Enabled = False
        '                Exit Sub
        '            End If
        '        End If

        '        If combo_venta.Text = "GUIA" Or combo_venta.Text = "FACTURA DE CREDITO" Or combo_venta.Text = "BOLETA DE CREDITO" Then
        '            If Int(VarCantidadDesc) <> "0" And Int(porcentaje_desc) > Int(VarDescuentoCliente) Then

        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(VarCantidadDesc) <> "0" Then
        '                Form_autorizacion.Show()
        '                If VarCantidadDesc = 1 Then
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO"
        '                Else
        '                    Form_autorizacion.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO"
        '                End If
        '                Me.Enabled = False
        '                Exit Sub
        '            End If

        '            If Int(porcentaje_desc) > Int(VarDescuentoCliente) Then
        '                Form_autorizacion.Show()
        '                Form_autorizacion.lbl_autorizacion.Text = "EL DESCUENTO FINAL EXCEDE EL MAXIMO"
        '                Me.Enabled = False
        '                Exit Sub
        '            End If
        '        End If

        '    End If
        '    crear_numero_factura()
        '    imprimir()
        '    crear_archivo_plano()
        '    controles(False, True)
        '    limpiar()
        '    Exit Sub
        'End If
    End Sub






    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.GotFocus
        combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles combo_venta.KeyDown
        'ajustar_a_documento()
        If e.KeyCode = Keys.Enter Then

            ' ajustar_a_documento()
            combo_condiciones.Focus()
            'detalle_label()
        End If
    End Sub

    Private Sub combo_venta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_venta.KeyPress
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
        'combo_venta.BackColor = Color.LightBlue
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            'lbl_descto.Text = "10"
            'lbl_venta.Text = combo_venta.SelectedItem
            condiciones()
            'If combo_venta.Text = "BOLETA" Then
            '    combo_retira.Enabled = False
            'End If

            'If combo_venta.Text = "BOLETA DE CREDITO" Then
            '    combo_retira.Enabled = False
            'End If

            'If combo_venta.Text = "FACTURA" Then
            '    combo_retira.Enabled = True
            'End If

            'If combo_venta.Text = "FACTURA DE CREDITO" Then
            '    combo_retira.Enabled = True
            'End If

            'If combo_venta.Text = "GUIA" Then
            '    combo_retira.Enabled = True
            'End If

            'If combo_venta.Text = "COTIZACION" Then
            '    combo_retira.Enabled = False
            'End If
            'combo_condiciones.Focus()
        End If
    End Sub

    Private Sub combo_venta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.LostFocus
        combo_venta.BackColor = Color.White
        condiciones()

        'ajustar_a_documento()
        ' lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
        'detalle_label()


        Dim VarCodProducto As String
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            If VarCodProducto = "*" And combo_venta.Text <> "COTIZACION" Then
                MsgBox("EL CODIGO * SOLO PUEDE SER INGRESADO EN COTIZACIONES ", MsgBoxStyle.Critical, "INFORMACION")
                combo_venta.Text = "COTIZACION"
                Exit Sub
            End If
        Next


        'TextBox1.Text = Me.ActiveControl.Name
    End Sub







    'llamamos al sub condiciones.
    'decimos que el descuento por defecto es 10, este puede cambir segun el que tenga guardado en sus datos.
    'habilitamos el combo condiciones.
    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        'ajustar_a_documento()
        ' lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
        'detalle_label()

        'crear_numero_documento()
        'lbl_venta.TextAlign = ContentAlignment.TopCenter
        'lbl_venta.Width = 700

        'If combo_venta.Text = "BOLETA" Then
        '    combo_retira.Enabled = False
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cliente()
        'End If

        'If combo_venta.Text = "BOLETA DE CREDITO" Then
        '    combo_retira.Enabled = False
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cliente()
        'End If

        'If combo_venta.Text = "FACTURA" Then
        '    combo_retira.Enabled = True
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cliente()
        '    Exit Sub
        'End If

        'If combo_venta.Text = "FACTURA DE CREDITO" Then

        '    combo_retira.Enabled = True
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cuentas_corrientes()
        'End If

        'If combo_venta.Text = "GUIA" Then
        '    combo_retira.Enabled = True
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cuentas_corrientes()
        'End If

        'If combo_venta.Text = "COTIZACION" Then
        '    combo_retira.Enabled = False
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cliente()
        'End If


        'condiciones()
        'cuentas()

        Dim VarCodProducto As String
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            If VarCodProducto = "*" And combo_venta.Text <> "COTIZACION" Then
                MsgBox("EL CODIGO * SOLO PUEDE SER INGRESADO EN COTIZACIONES ", MsgBoxStyle.Critical, "INFORMACION")
                combo_venta.Text = "COTIZACION"
                Exit Sub
            End If
        Next


    End Sub






    'Private Sub combo_vendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_vendedor.KeyPress
    '    If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then

    '        combo_condiciones.Focus()



    '    ElseIf (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

    '        mostrar_datos_vendedor()
    '        txt_codigo.Focus()
    '    End If
    'End Sub



    'mostramos los datos del vendedor seleccionado.
    'habilitamos el boton grabar.
    ''le damos el valor del combo al texbox.
    'Private Sub combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_vendedor.SelectedIndexChanged
    '    mostrar_datos_vendedor()
    'End Sub



    'valida solo el ingreso de numeros.
    'Private Sub txt_cantidad_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    'If Char.IsDigit(e.KeyChar) Then
    '    '    e.Handled = False
    '    'ElseIf Char.IsControl(e.KeyChar) Then
    '    '    e.Handled = False
    '    'Else
    '    '    e.Handled = True
    '    'End If

    '    'If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
    '    '    'limpiar_producto()
    '    '    mostrar_cantidad_real()
    '    '    'txt_cantidad_agregar.Text = ""
    '    '    txt_codigo.Focus()
    '    '    'condiciones()

    '    If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
    '        ' limpiar_producto()
    '        mostrar_cantidad_real()
    '        'txt_cantidad_agregar.Text = ""

    '        'condiciones()
    '        btn_agregar.Focus()
    '    End If

    '    If e.KeyChar = "." Then
    '        e.KeyChar = ","
    '    End If

    'End Sub

    Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_clientes_enter()
            '  txt_porcentaje_desc.Text = "0"
            mostrar_datos_clientes()
            ' llenar_combo_retira()
            'limpiar_datos_clientes_retira()
            ' txt_rut_retira.Focus()
            'guardar_descuento()
            ' grilla_detalle_venta.Rows.Clear()
            'cargar_descuento()
        End If
    End Sub


    'muestra lso datos del cliente seleccionado.
    Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'llenar_combo_retira()
        'limpiar_datos_clientes_retira()
    End Sub

    'Private Sub combo_retira_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    combo_retira.BackColor = Color.LightBlue
    'End Sub

    Private Sub combo_retira_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
            limpiar_datos_productos_enter()
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            txt_rut_cliente.Focus()
        ElseIf (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            'mostrar_datos_retira()
            txt_codigo.Focus()
        End If
    End Sub

    'Private Sub combo_retira_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    combo_retira.BackColor = Color.White
    'End Sub

    'le damos el valor del ocmbo al texbox.
    'mostramos los datos del lciente que retira seleccionado.
    'habilitamos los texbox y el combo.
    Private Sub combo_retira_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mostrar_datos_retira()
    End Sub

    'Private Sub txt_orden_de_compra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_orden_de_compra.GotFocus
    '    'txt_orden_de_compra.BackColor = Color.LightBlue
    'End Sub

    ''valida solo el ingreso de numeros.
    'Private Sub txt_afecta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_afecta.KeyPress
    '    If Char.IsDigit(e.KeyChar) Then
    '        e.Handled = False
    '    ElseIf Char.IsControl(e.KeyChar) Then
    '        e.Handled = False
    '    Else
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 
    '    Try
    '        Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
    '    Catch
    '    End Try
    'End Sub

    Private Sub combo_condiciones_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.GotFocus
        combo_condiciones.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_condiciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles combo_condiciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_grabar.Focus()
        End If
    End Sub

    Private Sub combo_condiciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_condiciones.KeyPress
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

    Private Sub combo_condiciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.LostFocus
        combo_condiciones.BackColor = Color.White
    End Sub

    'Private Sub Combo_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles 
    '    combo_condiciones.BackColor = Color.LightBlue
    'End Sub

    'Private Sub Combo_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles 
    '    combo_condiciones.BackColor = Color.LightBlue
    'End Sub

    'Private Sub Combo_cargar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_cargar.SelectedIndexChanged
    '    cargar_documento()
    '    calcular_totales()
    '    txt_item.Text = grilla_detalle.Rows.Count
    'End Sub

    Private Sub txt_cantidad_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White
    End Sub

    'Private Sub txt_rut_vendedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_vendedor.TextChanged
    '    ' mostrar_rut_vendedor()
    'End Sub

    'Sub para realizar el filtro de la busqueda de forma directa en el combobox.
    'Sub mostrar_rut_vendedor()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from usuarios where rut_usuario like '" & (combo_vendedor.Text & "%") & "' and TIPO ='VENTAS'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        combo_vendedor.Items.Clear()
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            combo_vendedor.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_usuario"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn_agregar.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_producto()
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            txt_cantidad_agregar.Focus()
            'condiciones()
            txt_codigo.Focus()
        End If
    End Sub

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        txt_rut_cliente.Focus()
        Form_buscador_clientes_ventas.Show()
        Form_buscador_clientes_ventas.txt_busqueda.Focus()
    End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Enabled = False
        txt_codigo.Focus()
        Form_buscador_productos_ventas.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_agregar_retira_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        Form_registro_cliente_retira_ventas.Show()
    End Sub

    Private Sub btn_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lbl_codigo.Text = "nada" Then
            MsgBox("DEBE SELECCIONAR UN PRODUCTO", MsgBoxStyle.Critical, "INFORMACION")
            txt_codigo.Focus()
        Else
            Me.Enabled = False
            Form_imagen.Show()
            '   Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    'Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles 
    '    txt_rut.BackColor = Color.LightBlue
    'End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress
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


        limpiar_datos_clientes()

        'If combo_retira.Enabled = True Then
        '    If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
        '        combo_retira.Focus()
        '    End If
        'End If

        'If combo_retira.Enabled = False Then
        '    If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
        '        txt_rut.Focus()
        '    End If
        'End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_clientes_enter()
            '  txt_porcentaje_desc.Text = "0"


            guion_rut_cliente()

            mostrar_datos_clientes()

            'limpiar_datos_clientes_retira()
            'guardar_descuento()
            'grilla_detalle_venta.Rows.Clear()
            'cargar_descuento()
            'calcular_totales()


            'If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            '    e.Handled = False
            'Else
            '    e.Handled = True
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

    Private Sub txt_rut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut_cliente.KeyUp
        If e.KeyCode = Keys.F8 Then
            Form_registro_clientes_ventas.Show()
            Me.WindowState = FormWindowState.Minimized
        End If

        If e.KeyCode = Keys.F9 Then
            Form_buscador_clientes_abonos.Show()
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.GotFocus
        txt_cantidad_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_agregar_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_agregar.KeyPress
        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If


        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

        If e.KeyChar = "-" Then
            e.KeyChar = ""
        End If



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
            Dim mensaje As String = ""

            If txt_cantidad_agregar.Text = "" Then
                mensaje = "CAMPO CANTIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_cantidad_agregar.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_codigo.Text = "" Then
                mensaje = "CAMPO CODIGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_codigo.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_cantidad_agregar.Text = "" Then
                mensaje = "CAMPO CANTIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_cantidad_agregar.Text = ""
                txt_cantidad_agregar.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_nombre_producto.Text = "" Then
                mensaje = "CAMPO CODIGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_codigo.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If combo_venta.Text = "BOLETA DE CREDITO" Then
                'If grilla_detalle_venta.Rows.Count < 10 Then
                venta()
                '     txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                'detalle_label()
                Exit Sub
                'Else
                '    MsgBox("EN UNA BOLETA NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
                '    Exit Sub
                'End If
            End If

            If combo_venta.Text = "BOLETA" Then
                'If grilla_detalle_venta.Rows.Count < 10 Then
                venta()
                '   txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                'detalle_label()
                Exit Sub
                'Else
                '    MsgBox("EN UNA BOLETA NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
                '    Exit Sub
                'End If
            End If

            If combo_venta.Text = "COTIZACION" Then
                'If grilla_detalle_venta.Rows.Count < 100 Then
                venta()
                'txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                ' detalle_label()
                Exit Sub
                'Else
                '    MsgBox("EN UNA COTIZACION NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
                '    Exit Sub
                'End If
            End If


            If combo_venta.Text = "FACTURA" Then
                'If grilla_detalle_venta.Rows.Count < 29 Then
                venta()
                ' txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                ' detalle_label()
                Exit Sub
                'Else
                '    MsgBox("EN UNA FACTURA NO PUEDE AGREGAR MAS DE 28 ITEMS", 0 + 16, "ERROR")
                '    Exit Sub
                'End If
            End If

            If combo_venta.Text = "FACTURA DE CREDITO" Then
                'If grilla_detalle_venta.Rows.Count < 29 Then
                venta()
                '    txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                ' detalle_label()
                Exit Sub
                'Else
                '    MsgBox("EN UNA FACTURA NO PUEDE AGREGAR MAS DE 28 ITEMS", 0 + 16, "ERROR")
                '    Exit Sub
                'End If
            End If

            If combo_venta.Text = "GUIA" Then
                'If grilla_detalle_venta.Rows.Count < 29 Then
                venta()
                '   txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                ' detalle_label()
                Exit Sub
                'Else
                '    MsgBox("EN UNA GUIA NO PUEDE AGREGAR MAS DE 28 ITEMS", 0 + 16, "ERROR")
                '    Exit Sub
                'End If
            End If
        End If
    End Sub

    Private Sub txt_cantidad_agregar_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White
    End Sub

    'Private Sub combo_retira_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_retira.GotFocus
    '    combo_retira.BackColor = Color.Yellow
    'End Sub

    Private Sub combo_retira_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txt_codigo.Focus()
        End If
    End Sub

    'Private Sub combo_retira_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_retira.KeyPress
    '    If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
    '        mostrar_datos_retira()
    '        ' combo_venta.Focus()
    '    End If

    '    If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
    '        e.Handled = False
    '    Else
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub combo_retira_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_retira.LostFocus
    '    combo_retira.BackColor = Color.White
    'End Sub

    'Private Sub combo_retira_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_retira.SelectedIndexChanged
    '    mostrar_datos_retira()
    'End Sub

    Private Sub btn_agregar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        Form_registro_clientes_ventas.Show()
        'Me.WindowState = FormWindowState.Minimized
    End Sub



    Private Sub txt_cargar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            ' cargar_documento()
            calcular_totales()
            'cargar_nombre()
            'txt_cargar.Text = ""
            txt_codigo.Focus()
            '  txt_item.Text = grilla_detalle_venta.Rows.Count
            'lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
            'detalle_label()
        End If
    End Sub

    'Private Sub txt_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_cargar.BackColor = Color.White
    'End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.TabIndexChanged
        combo_venta.Focus()
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.GotFocus
        btn_nueva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Radio_codigo_barra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_codigo.Focus()
    End Sub

    Private Sub Radio_codigo_interno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_codigo.Focus()
    End Sub

    'Private Sub Radio_codigo_interno_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Radio_codigo_interno.TabStop = False
    'End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    'Private Sub GroupBox2_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.TabIndexChanged
    '    Me.TabIndex = 50
    'End Sub

    'Private Sub Radio_codigo_barra_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Radio_codigo_barra.TabStop = False
    'End Sub

    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.LostFocus
        btn_nueva.BackColor = Color.Transparent
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub





    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If txt_total_final.Text = "0" Or txt_total_final.Text = "" Then
    '        MsgBox("AUN NO GENERA UNA VENTA", MsgBoxStyle.Critical, "INFORMACION")
    '    Else
    '        Form_vuelto.Show()
    '        controles_subpantalla(False, True)
    '    End If
    'End Sub

    Private Sub txt_descto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.GotFocus
        txt_porcentaje_desc.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_descto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_porcentaje_desc.KeyDown

    End Sub



    Private Sub txt_descto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_porcentaje_desc.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

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
            'guardar_descuento()
            'grilla_detalle_venta.Rows.Clear()
            'cargar_descuento()
            'calcular_totales()
            ''If txt_descto.Text = "" Then
            ''    txt_descto.Text = "0"
            ''End If

            ''If txt_descto.Text = " " Then
            ''    txt_descto.Text = "0"
            ''End If
            'btn_agregar.Focus()
















            calcular_totales()

            btn_grabar.Focus()

        End If


    End Sub




    'Private Sub btn_agregar_retira_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_retira.Click

    '    If lbl_rut.Text = "nada" Then
    '        'MsgBox("SELECCIONE AL TITULAR DE LA CUENTA", 0 + 16, "Error")
    '        MsgBox("SELECCIONE AL TITULAR DE LA CUENTA", MsgBoxStyle.Critical, "INFORMACION")
    '        txt_rut.Focus()
    '    Else

    '        Form_registro_cliente_retira.Show()
    '        Form_registro_cliente_retira.combo_rut_empresa.Text = Me.txt_rut.Text
    '        Form_registro_cliente_retira.txt_nombre_empresa.Text = Me.txt_nombre_cliente.Text
    '        Me.WindowState = FormWindowState.Minimized
    '    End If
    'End Sub

    'Sub bixolon()

    '    Dim VarCodProducto As Integer
    '    Dim varnombre As String
    '    Dim vartecnico As String
    '    Dim VarValorUnitario As Integer
    '    Dim VarCantidad As Integer
    '    Dim VarPorcentaje As Integer
    '    Dim VarDescuento As Integer
    '    Dim VarNeto As Integer
    '    Dim VarIva As Integer
    '    Dim VarSubtotal As Integer
    '    Dim VarTotal As Integer
    '    Dim VarProveedor As String
    '    Dim VarCosto As Integer
    '    Dim VarSaldo As Integer
    '    Dim VarTipopago As Integer

    '    ''los pagos 0, 1, 2 vienen configurados como Efectivo, Cheque y Crédito.

    '    If combo_condiciones.Text = "EFECTIVO" Then
    '        VarTipopago = 0
    '    End If
    '    If combo_condiciones.Text = "TARJETA ABCDIN" Then
    '        VarTipopago = 2
    '    End If
    '    If combo_condiciones.Text = "TARJETA CENCOSUD" Then
    '        VarTipopago = 2
    '    End If
    '    If combo_condiciones.Text = "TARJETA C&D" Then
    '        VarTipopago = 2
    '    End If
    '    If combo_condiciones.Text = "TARJETA PRESTO" Then
    '        VarTipopago = 2
    '    End If
    '    If combo_condiciones.Text = "TARJETA RYPLEY" Then
    '        VarTipopago = 2
    '    End If
    '    If combo_condiciones.Text = "TARJETA DE CREDITO" Then
    '        VarTipopago = 2
    '    End If
    '    If combo_condiciones.Text = "TARJETA VISA" Then
    '        VarTipopago = 2
    '    End If
    '    If combo_condiciones.Text = "TARJETA MASTERCARD" Then
    '        VarTipopago = 2
    '    End If
    '    If combo_condiciones.Text = "TARJETA BANCARIA" Then
    '        VarTipopago = 2
    '    End If
    '    If combo_condiciones.Text = "CHEQUE AL DIA" Then
    '        VarTipopago = 1
    '    End If
    '    If combo_condiciones.Text = "CHEQUE 30 DIAS" Then
    '        VarTipopago = 1
    '    End If
    '    If combo_condiciones.Text = "CHEQUE 30-60 DIAS" Then
    '        VarTipopago = 1
    '    End If
    '    If combo_condiciones.Text = "CHEQUE 30-60-90 DIAS" Then
    '        VarTipopago = 1
    '    End If
    '    If combo_condiciones.Text = "CREDITO" Then
    '        VarTipopago = 3
    '    End If


    '    AxOcxsam3501.cargarlogo("misimagenes /nasna")

    '    AxOcxsam3501.init(1) '(abre el puerto)
    '    AxOcxsam3501.abrirBOLETA(0, 0)  '(inicias una BOLETA)

    '    For i = 0 To grilla_detalle.Rows.Count - 1

    '        VarCodProducto = grilla_detalle.Rows(i).Cells(0).Value.ToString
    '        varnombre = grilla_detalle.Rows(i).Cells(1).Value.ToString
    '        vartecnico = grilla_detalle.Rows(i).Cells(2).Value.ToString
    '        VarValorUnitario = grilla_detalle.Rows(i).Cells(3).Value.ToString
    '        VarCantidad = grilla_detalle.Rows(i).Cells(4).Value.ToString
    '        VarPorcentaje = grilla_detalle.Rows(i).Cells(5).Value.ToString
    '        VarDescuento = grilla_detalle.Rows(i).Cells(6).Value.ToString
    '        VarNeto = grilla_detalle.Rows(i).Cells(7).Value.ToString
    '        VarIva = grilla_detalle.Rows(i).Cells(8).Value.ToString
    '        VarSubtotal = grilla_detalle.Rows(i).Cells(9).Value.ToString
    '        VarTotal = grilla_detalle.Rows(i).Cells(10).Value.ToString
    '        VarSaldo = grilla_detalle.Rows(i).Cells(11).Value.ToString
    '        VarProveedor = grilla_detalle.Rows(i).Cells(12).Value.ToString
    '        VarCosto = grilla_detalle.Rows(i).Cells(13).Value.ToString

    '        AxOcxsam3501.agregaitem(varnombre, VarValorUnitario, VarCantidad)   '(agregas un producto, descripcion, cantidad, precio unitario)
    '        ' AxOcxsam3501.agregarecargo("Recargo", 20) ' (ingresas recargo si lo ay)
    '        AxOcxsam3501.agregadescuento("Descuento", txt_desc_total.Text)  '(ingresas descuento si lo hay)
    '        AxOcxsam3501.agregapago(VarTipopago, txt_total_final.Text) '(ingresas el TIPO de  pago y el  pago) 'los pagos 0, 1, 2 vienen configurados como Efectivo, Cheque y Crédito.



    '        AxOcxsam3501.agregadonacion("donacion", 10) '//da 10 de donación       
    '    Next

    '    AxOcxsam3501.cierraBOLETA(0) '(cierras la BOLETA)
    '    AxOcxsam3501.fini() '(cierras el puerto)


    'End Sub


    'Sub cargar_nombre()
    '    If combo_venta.Text = "FACTURA" Then

    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()
    '        SC.Connection = conexion
    '        SC.CommandText = "select rut_cliente from factura where n_factura= '" & (txt_cargar.Text) & "'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                txt_rut.Text = (DS.Tables(DT.TableName).Rows(E).Item("rut_cliente"))
    '            Next
    '        End If
    '        conexion.Close()

    '        If txt_rut.Text <> "" Then
    '            mostrar_datos_clientes()
    '            'DS.Tables.Clear()
    '            'DT.Rows.Clear()
    '            'DT.Columns.Clear()
    '            'DS.Clear()
    '            'conexion.Open()

    '            'SC.Connection = conexion
    '            'SC.CommandText = "select * from clientes where rut ='" & (txt_rut.Text) & "'"
    '            'DA.SelectCommand = SC
    '            'DA.Fill(DT)
    '            'DS.Tables.Add(DT)

    '            'If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '            '    lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
    '            '    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    '            '    txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
    '            '    txt_descto.Text = DS.Tables(DT.TableName).Rows(0).Item("dscto1")
    '            '    txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("giro")
    '            '    txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna")
    '            '    txt_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("cuenta")
    '            'End If
    '        End If
    '        conexion.Close()
    '    End If

    '    If combo_venta.Text = "FACTURA DE CREDITO" Then

    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()
    '        SC.Connection = conexion
    '        SC.CommandText = "select rut_cliente from factura_credito where n_factura_credito= '" & (txt_cargar.Text) & "'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                txt_rut.Text = (DS.Tables(DT.TableName).Rows(E).Item("rut_cliente"))
    '            Next
    '        End If
    '        conexion.Close()

    '        If txt_rut.Text <> "" Then
    '            mostrar_datos_clientes()
    '            'DS.Tables.Clear()
    '            'DT.Rows.Clear()
    '            'DT.Columns.Clear()
    '            'DS.Clear()
    '            'conexion.Open()

    '            'SC.Connection = conexion
    '            'SC.CommandText = "select * from clientes where rut ='" & (txt_rut.Text) & "'"
    '            'DA.SelectCommand = SC
    '            'DA.Fill(DT)
    '            'DS.Tables.Add(DT)

    '            'If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '            '    lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
    '            '    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    '            '    txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
    '            '    txt_descto.Text = DS.Tables(DT.TableName).Rows(0).Item("dscto1")
    '            '    txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("giro")
    '            '    txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna")
    '            '    txt_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("cuenta")
    '        End If
    '        conexion.Close()
    '    End If

    '    'End If

    '    If combo_venta.Text = "GUIA" Then

    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()
    '        SC.Connection = conexion
    '        SC.CommandText = "select rut_cliente from GUIA where n_guia= '" & (txt_cargar.Text) & "'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                txt_rut.Text = (DS.Tables(DT.TableName).Rows(E).Item("rut_cliente"))
    '            Next
    '        End If
    '        conexion.Close()

    '        If txt_rut.Text <> "" Then
    '            mostrar_datos_clientes()
    '            'DS.Tables.Clear()
    '            'DT.Rows.Clear()
    '            'DT.Columns.Clear()
    '            'DS.Clear()
    '            'conexion.Open()

    '            'SC.Connection = conexion
    '            'SC.CommandText = "select * from clientes where rut ='" & (txt_rut.Text) & "'"
    '            'DA.SelectCommand = SC
    '            'DA.Fill(DT)
    '            'DS.Tables.Add(DT)

    '            'If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '            '    lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
    '            '    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    '            '    txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
    '            '    txt_descto.Text = DS.Tables(DT.TableName).Rows(0).Item("dscto1")
    '            '    txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("giro")
    '            '    txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna")
    '            '    txt_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("cuenta")
    '        End If
    '        conexion.Close()
    '    End If

    ' End If
    '


    Private Sub txt_cantidad_agregar_ChangeUICues(ByVal sender As Object, ByVal e As System.Windows.Forms.UICuesEventArgs) Handles txt_cantidad_agregar.ChangeUICues
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
    End Sub

    Private Sub txt_cantidad_agregar_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.GotFocus
        txt_cantidad_agregar.BackColor = Color.LightSkyBlue
    End Sub

    'Private Sub txt_cantidad_agregar_KeyPress2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_agregar.KeyPress
    '    If Char.IsDigit(e.KeyChar) Then
    '        e.Handled = False
    '    ElseIf Char.IsControl(e.KeyChar) Then
    '        e.Handled = False
    '    Else
    '        e.Handled = True
    '    End If

    '    If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

    '        If txt_cantidad_agregar.Text = "" Then
    '            txt_cantidad_agregar.Text = 0
    '        End If

    '        If txt_cantidad_agregar.Text = " " Then
    '            txt_cantidad_agregar.Text = 0
    '        End If

    '        If txt_cantidad_agregar.TextLength = 0 Then
    '            txt_cantidad_agregar.Text = 0
    '        End If
    '        If txt_cantidad_agregar.Text = "  " Then
    '            txt_cantidad_agregar.Text = 0
    '        End If
    '        If txt_descto.Text = "" Then
    '            txt_descto.Text = 0
    '        End If
    '        btn_agregar.Focus()
    '    End If
    'End Sub

    Private Sub txt_cantidad_agregar_LostFocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White


        Dim primer_caracter As String
        Dim ultimo_caracter As String
        Dim total_caracter As String
        total_caracter = ""
        If txt_cantidad_agregar.Text = "" Then
            primer_caracter = 0
            ultimo_caracter = 0
        Else
            primer_caracter = txt_cantidad_agregar.Text.Length - txt_cantidad_agregar.Text.Length + 1
            ultimo_caracter = txt_cantidad_agregar.Text.Length
            total_caracter = txt_cantidad_agregar.Text
        End If



        Dim n1 As Byte, lMal As Boolean


        If txt_cantidad_agregar.Text <> "" Then

            For n1 = ultimo_caracter To ultimo_caracter
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_cantidad_agregar.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next

            For n1 = 1 To 1
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_cantidad_agregar.Focus()
                    lMal = True
                    Exit Sub

                End If
            Next
        End If
    End Sub



    Private Sub txt_cantidad_agregar_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.TextChanged
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, "  ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, "   ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, "    ", ""))

        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, "  ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, "   ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, "    ", ""))

        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, "  ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, "   ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, "    ", ""))
    End Sub

    'Private Sub Combo_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_rut.BackColor = Color.LightBlue
    'End Sub

    'Private Sub Combo_rut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        If combo_retira.Enabled = True Then
    '            combo_retira.Focus()
    '        Else
    '            txt_codigo.Focus()
    '        End If
    '    End If
    'End Sub

    'Private Sub Combo_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_rut.BackColor = Color.White
    'End Sub



    Private Sub Combo_codigo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_productos_enter()
            mostrar_cantidad_real()
            mostrar_nombre_proveedor()
            txt_cantidad_agregar.Text = ""
            ' Radio_codigo_interno.Checked = True
            txt_cantidad_agregar.Focus()
        End If

        'If Radio_codigo_interno.Checked = True Then
        '    If Char.IsDigit(e.KeyChar) Then
        '        e.Handled = False
        '    ElseIf Char.IsControl(e.KeyChar) Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        '    txt_codigo.MaxLength = 6
        'Else
        '    txt_codigo.MaxLength = 30
        'End If
    End Sub

    'Private Sub Combo_codigo_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    mostrar_cantidad_real()
    '    mostrar_nombre_proveedor()
    '    txt_cantidad_agregar.Text = ""
    '    Radio_codigo_interno.Checked = True
    '    txt_cantidad_agregar.Focus()

    '    If Radio_codigo_interno.Checked = True Then
    '        txt_codigo.MaxLength = 6
    '    Else
    '        txt_codigo.MaxLength = 30
    '    End If
    'End Sub

    Private Sub txt_descto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.LostFocus
        Me.txt_porcentaje_desc.Text = Trim(Replace(Me.txt_porcentaje_desc.Text, " ", ""))
        'If txt_porcentaje_desc.Text = "" Or txt_porcentaje_desc.Text = " " Or txt_porcentaje_desc.Text = "  " Then
        '    txt_porcentaje_desc.Text = "0"
        'End If
        'If txt_porcentaje_desc.Text = Nothing Then
        '    txt_porcentaje_desc.Text = "0"
        'End If
        txt_porcentaje_desc.BackColor = Color.White
    End Sub

    'Private Sub btn_agregar_clientes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_agregar_clientes.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_buscar_clientes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_buscar_clientes.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_agregar_retira_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_agregar_retira.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_buscar_productos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_buscar_productos.BackColor = Color.LightSkyBlue
    'End Sub

    ''Private Sub btn_imagen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    btn_imagen.BackColor = Color.Yellow
    ''End Sub

    'Private Sub btn_agregar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_agregar_clientes.BackColor = Color.WhiteSmoke
    'End Sub



    'Private Sub btn_agregar_retira_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_agregar_retira.BackColor = Color.WhiteSmoke
    'End Sub

    'Private Sub btn_buscar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_buscar_clientes.BackColor = Color.WhiteSmoke
    'End Sub

    'Private Sub btn_buscar_productos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_buscar_productos.BackColor = Color.WhiteSmoke
    'End Sub

    'Private Sub btn_imagen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imagen.BackColor = Color.WhiteSmoke
    'End Sub




    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txt_rut_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TabIndexChanged

    End Sub



    'Private Sub Panel_contenedor_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_contenedor.Paint

    'End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged
        'txt_descto.Text = "0"

        'If combo_venta.Text = "BOLETA" Then
        '    mostrar_datos_clientes()
        'End If

        'If combo_venta.Text = "BOLETA DE CREDITO" Then
        '    mostrar_datos_clientes()
        'End If

        'If combo_venta.Text = "FACTURA" Then
        '    mostrar_datos_clientes()
        'End If

        'If combo_venta.Text = "FACTURA DE CREDITO" Then
        '    mostrar_datos_cuentas_corrientes()
        'End If

        'If combo_venta.Text = "GUIA" Then
        '    mostrar_datos_cuentas_corrientes()
        'End If

        'If combo_venta.Text = "COTIZACION" Then
        '    mostrar_datos_clientes()
        'End If

        'llenar_combo_retira()
        'limpiar_datos_clientes_retira()
        'guardar_descuento()
        'grilla_detalle.Rows.Clear()
        'cargar_descuento()
        'calcular_totales()
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

    Private Sub Timer_ventas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_ventas.Tick

    End Sub



    'Private Sub txt_rut_retira_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_rut_retira.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_rut_retira_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    txt_nombre_retira.Text = ""

    '    e.KeyChar = e.KeyChar.ToString.ToUpper

    '    If e.KeyChar = "'" Then
    '        e.KeyChar = "´"
    '    End If

    '    If e.KeyChar = "&" Then
    '        e.KeyChar = " "
    '    End If

    '    If e.KeyChar = Chr(34) Then
    '        e.KeyChar = "´´"
    '    End If

    '    If e.KeyChar = "\" Then
    '        e.KeyChar = " "
    '    End If

    '    If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
    '        ' txt_nombre_retira.Text = ""
    '        guion_rut_cliente_retira()
    '        ' mostrar_datos_retira()

    '        'If txt_nombre_retira.Text = "" Then
    '        '    txt_rut_retira.Focus()
    '        'Else
    '        '    txt_codigo.Focus()
    '        'End If

    '    End If
    'End Sub

    Sub valores()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select iva, factor from valores"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            valor_iva = DS2.Tables(DT2.TableName).Rows(0).Item("iva")
            valor_factor = DS2.Tables(DT2.TableName).Rows(0).Item("factor")
            ' tiempo_espera = DS2.Tables(DT2.TableName).Rows(0).Item("tiempo_espera")
            ' sueldo_minimo = DS2.Tables(DT2.TableName).Rows(0).Item("sueldo_minimo")
            ' valor_uf = DS2.Tables(DT2.TableName).Rows(0).Item("uf")
            ' valor_seguro_cesantia = DS2.Tables(DT2.TableName).Rows(0).Item("seguro_cesantia")
            ' valor_salud_fonasa = DS2.Tables(DT2.TableName).Rows(0).Item("salud_fonasa")
            ' valor_hora_extra_calcular = DS2.Tables(DT2.TableName).Rows(0).Item("valor_hora_extra")
        End If
        conexion.Close()
    End Sub

    Private Sub txt_rut_retira_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'txt_rut_retira.BackColor = Color.White
    End Sub
    'Private Sub txt_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_cargar.BackColor = Color.LightSkyBlue
    'End Sub

    Private Sub txt_rut_retira_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_cargar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

















    Private Sub txt_codigo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress

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




        If txt_codigo.Text = "*" Then
            combo_venta.Text = "COTIZACION"
        End If



        limpiar_datos_productos_enter()





        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then













            If txt_codigo.Text = "" Then
                Exit Sub
            End If




            If txt_codigo.Text = "*" Then
                limpiar_producto()
                combo_venta.Text = "COTIZACION"
                txt_codigo.Text = "*"
                ' txt_nombre_producto.Enabled = True
                ' txt_precio.Enabled = True
                txt_nombre_producto.ReadOnly = False
                '  txt_precio.ReadOnly = False

                txt_nombre_producto.BackColor = Color.White
                ' txt_precio.BackColor = Color.White

                txt_nombre_producto.Focus()
                Exit Sub
            Else
                ' txt_nombre_producto.Enabled = False
                ' txt_precio.Enabled = False
                txt_nombre_producto.ReadOnly = True
                '  txt_precio.ReadOnly = True
                '  txt_nombre_producto.BackColor = Color.Gainsboro


                txt_nombre_producto.BackColor = SystemColors.Control

                '  txt_precio.BackColor = SystemColors.Control
            End If











            conexion.Close()
            Dim cantidad_caracteres As Integer
            cantidad_caracteres = Len(txt_codigo.Text)
            If cantidad_caracteres <= 5 Then
                Form_buscador_productos_ventas.Show()
                '  Form_buscar_productos_ventas.txt_codigo.Text = txt_codigo.Text
                Form_buscador_productos_ventas.buscar()
                Exit Sub
            End If
















            limpiar_datos_productos_enter()
            mostrar_cantidad_real()
            mostrar_nombre_proveedor()



            If txt_codigo.Text <> "" And txt_nombre_producto.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MsgBoxStyle.Critical, "INFORMACION")
                txt_codigo.Focus()
            Else
                ' txt_cantidad_agregar.Focus()
                txt_cantidad_agregar.Text = "1"
                txt_precio_modificado.Focus()

                Exit Sub
            End If


        End If



    End Sub



    Private Sub txt_codigo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White

        If txt_codigo.Text = "*" Then
            limpiar_producto()
            combo_venta.Text = "COTIZACION"
            txt_codigo.Text = "*"
            ' txt_nombre_producto.Enabled = True
            ' txt_precio.Enabled = True
            txt_nombre_producto.ReadOnly = False
            'txt_precio.ReadOnly = False

            txt_nombre_producto.BackColor = Color.White
            txt_precio_modificado.BackColor = Color.White

            txt_nombre_producto.Focus()
            Exit Sub
        Else
            ' txt_nombre_producto.Enabled = False
            ' txt_precio.Enabled = False
            txt_nombre_producto.ReadOnly = True
            '  txt_precio.ReadOnly = True
            'txt_nombre_producto.BackColor = Color.Gainsboro
            'txt_precio.BackColor = Color.Gainsboro
        End If


    End Sub



    Private Sub btn_buscar_productos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        txt_codigo.Focus()
        Form_buscador_productos_ventas.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_imagen_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lbl_codigo.Text = "nada" Then
            MsgBox("DEBE SELECCIONAR UN PRODUCTO", MsgBoxStyle.Critical, "INFORMACION")
            txt_codigo.Focus()
        Else
            Me.Enabled = False
            Form_imagen.Show()
            '   Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    'Private Sub btn_buscar_productos_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_buscar_productos.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_buscar_productos_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_buscar_productos.BackColor = Color.White
    'End Sub

    'Private Sub btn_imagen_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imagen.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_imagen_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imagen.BackColor = Color.White
    'End Sub

    Private Sub grilla_detalle_venta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_detalle_venta.Click
        If grilla_detalle_venta.Rows.Count <= 0 Then
            Exit Sub
        End If
        If grilla_detalle_venta.CurrentRow.Cells(0).Value() = "*" Then
            Exit Sub
        End If
        txt_codigo.Text = grilla_detalle_venta.CurrentRow.Cells(0).Value()

        mostrar_datos_productos()
        txt_precio_modificado.Text = grilla_detalle_venta.CurrentRow.Cells(7).Value()
        mostrar_nombre_proveedor()
        txt_cantidad_agregar.Focus()
    End Sub

    'Private Sub grilla_detalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)



    '    Dim columna_descuento As String
    '    Dim codigo_producto_descuento As String
    '    Dim nombre_producto_descuento As String
    '    Dim nro_tecnico_producto_descuento As String
    '    If grilla_detalle_venta.Rows.Count <> 0 Then
    '        ' codigo_pedido = grilla_detalle_venta.CurrentRow.Cells(0).Value()
    '        columna_descuento = grilla_detalle_venta.CurrentRow.Cells(5).Value()
    '        codigo_producto_descuento = grilla_detalle_venta.CurrentRow.Cells(0).Value()
    '        nombre_producto_descuento = grilla_detalle_venta.CurrentRow.Cells(1).Value()
    '        nro_tecnico_producto_descuento = grilla_detalle_venta.CurrentRow.Cells(2).Value()


    '        If grilla_detalle_venta.CurrentRow.Cells(8).Selected Then
    '            ' Form_descuento.lbl_codigo.Text = codigo_producto_descuento & ", " & nombre_producto_descuento


    '            Form_descuento.Show()







    '            Me.Enabled = False
    '            'valormensaje = MsgBox("¿DESEA AGREGAR UN DESCUENTO AL PRODUCTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "DESCUENTO")
    '            'If valormensaje = vbYes Then

    '            'End If

    '        End If
    '    End If
    'End Sub



    Private Sub grilla_detalle_venta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_detalle_venta.DoubleClick
        Dim columna_descuento As String
        Dim codigo_producto_descuento As String
        Dim nombre_producto_descuento As String
        Dim nro_tecnico_producto_descuento As String
        If grilla_detalle_venta.Rows.Count <> 0 Then

            If grilla_detalle_venta.CurrentRow.Cells(0).Value = "*" Then
                Exit Sub
            End If

            ' codigo_pedido = grilla_detalle_venta.CurrentRow.Cells(0).Value()
            columna_descuento = grilla_detalle_venta.CurrentRow.Cells(5).Value()
            codigo_producto_descuento = grilla_detalle_venta.CurrentRow.Cells(0).Value()
            nombre_producto_descuento = grilla_detalle_venta.CurrentRow.Cells(1).Value()
            nro_tecnico_producto_descuento = grilla_detalle_venta.CurrentRow.Cells(2).Value()


            'If grilla_detalle_venta.CurrentRow.Cells(8).Selected Then
            '    ' Form_descuento.lbl_codigo.Text = codigo_producto_descuento & ", " & nombre_producto_descuento

            '    Form_descuento.Show()

            '    Me.Enabled = False
            '    'valormensaje = MsgBox("¿DESEA AGREGAR UN DESCUENTO AL PRODUCTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "DESCUENTO")
            '    'If valormensaje = vbYes Then

            '    'End If

            'End If
        End If
    End Sub

    Private Sub txt_porcentaje_desc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.TextChanged
        calcular_totales()
        'detalle_label()
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub

    Private Sub txt_precio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.GotFocus
        txt_precio_modificado.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio_modificado.KeyPress
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
            txt_cantidad_agregar.Focus()
        End If
    End Sub

    Private Sub txt_precio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.LostFocus
        txt_precio_modificado.BackColor = Color.White
    End Sub

    Private Sub txt_precio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.TextChanged

    End Sub

    Private Sub txt_nombre_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_producto.KeyPress
        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_precio_modificado.Focus()
        End If

    End Sub

    Private Sub txt_nombre_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_producto.TextChanged

    End Sub




    Private Sub combo_venta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.TextChanged
        'ajustar_a_documento()
        ' lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
        'detalle_label()
        'lbl_venta.TextAlign = ContentAlignment.TopCenter
        'lbl_venta.Width = 700

        'If combo_venta.Text = "BOLETA" Then
        '    combo_retira.Enabled = False
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cliente()
        'End If

        'If combo_venta.Text = "BOLETA DE CREDITO" Then
        '    combo_retira.Enabled = False
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cliente()
        'End If

        'If combo_venta.Text = "FACTURA" Then
        '    combo_retira.Enabled = True
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cliente()
        '    Exit Sub
        'End If

        'If combo_venta.Text = "FACTURA DE CREDITO" Then

        '    combo_retira.Enabled = True
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cuentas_corrientes()
        'End If

        'If combo_venta.Text = "GUIA" Then
        '    combo_retira.Enabled = True
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cuentas_corrientes()
        'End If

        'If combo_venta.Text = "COTIZACION" Then
        '    combo_retira.Enabled = False
        '    limpiar_datos_clientes()
        '    'llenar_combo_rut_cliente()
        'End If


        'condiciones()
        'cuentas()

        Dim VarCodProducto As String
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            If VarCodProducto = "*" And combo_venta.Text <> "COTIZACION" Then
                MsgBox("EL CODIGO * SOLO PUEDE SER INGRESADO EN COTIZACIONES ", MsgBoxStyle.Critical, "INFORMACION")
                combo_venta.Text = "COTIZACION"
                Exit Sub
            End If
        Next
    End Sub

    'Private Sub Panel_contenedor_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_contenedor.Paint

    'End Sub




    Private Sub Panel_contenedor_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub grilla_detalle_venta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_detalle_venta.CellContentClick

    End Sub


    Private Sub btn_buscar_retira_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        Form_buscador_clientes_retira.Show()
    End Sub

    Private Sub txt_nro_doc_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc_imprimir.GotFocus
        txt_nro_doc_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_doc_imprimir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_doc_imprimir.KeyPress
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
    End Sub

    Private Sub txt_nro_doc_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc_imprimir.LostFocus
        txt_nro_doc_imprimir.BackColor = Color.White
    End Sub

   
    Private Sub txt_nro_doc_imprimir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc_imprimir.TextChanged

    End Sub

    Private Sub combo_condiciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_condiciones.SelectedIndexChanged

    End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        mostrar_datos_vendedor()
        If Combo_vendedor.SelectedItem = "-" Then
            txt_rut_vendedor.Text = ""
        End If
    End Sub


    Private Sub GroupBox_totales_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox_totales.Enter

    End Sub

    Private Sub txt_pie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pie.KeyPress
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


    End Sub

    Private Sub txt_pie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pie.TextChanged

    End Sub
End Class