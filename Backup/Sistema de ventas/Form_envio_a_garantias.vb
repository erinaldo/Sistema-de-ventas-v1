Imports System.Drawing.Printing
Imports System.IO
Imports System.Math
Imports System.Drawing.Drawing2D
Public Class Form_envio_a_garantias
    Dim total_registros As Integer
    Dim varnumfactura As Integer
    Dim peso As String
    Dim pesos As String
    Dim sin_facturar As String
    Dim VarSeleccion As Integer
    Dim alto_cotizacion As String
    Private WithEvents Pd As New PrintDocument
    Dim estado_impresion As String

    Private Sub Form_envio_a_garantias_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_envio_a_garantias_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F1 Then
            txt_codigo.Focus()
        End If

        If e.KeyCode = Keys.F2 Then
            If grilla_detalle_venta.Rows.Count > 0 Then
                grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.CurrentRow)
                calcular_totales()
                txt_item.Text = grilla_detalle_venta.Rows.Count
                txt_codigo.Focus()
            End If
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
            form_Ingreso.Show()
            'form_Menu_admin.Enabled = False
            Form_menu_principal.Close()

        End If

        If e.KeyCode = Keys.F5 Then
            txt_rut_cliente.Focus()
        End If

        If e.KeyCode = Keys.F8 Then
            'btn_agregar_retira.PerformClick()
        End If

        If e.KeyCode = Keys.F12 Then
            If txt_porcentaje_desc.Focused = True Then
                btn_grabar.PerformClick()
                Exit Sub
            Else
                txt_porcentaje_desc.Focus()
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Form_envio_a_garantias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        cargar_logo()
        valores()
        txt_fecha.Text = FormatDateTime(Now, DateFormat.ShortDate)
        controles(False, True)
        combo_condiciones.SelectedItem = "GARANTIA"
        txt_codigo.Focus()
        'detalle_label()
        llenar_combo_vendedor()
        grilla_detalle_venta.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
        'dtp_ingreso.CustomFormat = "yyy-MM-dd"
        dtp_fecha_diaria.CustomFormat = "yyy-MM-dd"
        dtp_fecha_doc_referencia.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.Value = dtp_vencimiento.Value.AddMonths(Val(+1))


        If mirutempresa = "81921000-4" Then
            Combo_vendedor.Enabled = False
            combo_condiciones.Enabled = False
            btn_agregar.Enabled = False
            btn_quitar_elemento.Enabled = False
            'Combo_codigo_referencia.Enabled = False
        End If







        Combo_vendedor.SelectedItem = "-"


        If mirecintoempresa <> "VALDIVIA 060" Then
            Form_seleccionar_documento_para_garantias.Show()
            mostrar_datos_clientes_or()
            GroupBox_clientes.Enabled = False
            Me.Enabled = False
        End If












    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub


    Sub mostrar_datos_clientes_or()
        conexion.Close()

        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from clientes where rut_cliente ='81921000-4' and direccion_cliente ='VALDIVIA 060'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
            txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
            txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
            txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
            txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
            txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
            txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
            txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
            txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
            txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
            conexion.Close()
        End If

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

    Sub mostrar(ByVal i As Integer)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            'lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
            txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
            txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
            txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
            txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
            txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
        End If
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

    Sub limpiar_datos_clientes()
        'lbl_rut.Text = "nada"
        txt_rut_cliente.Text = ""
        txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_descuento_cliente.Text = ""
        txt_giro_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_telefono.Text = ""
        txt_folio.Text = ""
    End Sub

    Sub limpiar_datos_clientes_enter()
        'lbl_rut.Text = "nada"
        txt_nombre_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_descuento_cliente.Text = ""
        txt_giro_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_telefono.Text = ""
        txt_folio.Text = ""
    End Sub

    Sub limpiar_datos_productos_enter()
        'lbl_codigo.Text = "nada"
        txt_nombre_producto.Text = ""
        txt_marca.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad.Text = ""
        txt_factor.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        txt_costo.Text = ""
        txt_proveedor.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
    End Sub

    'actualizamos la tabla clientes.
    Sub actualizar_tabla_clientes()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from clientes"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    'actualizamos la tabla productos.
    Sub actualizar_tabla_productos()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from productos"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    'actualizamos la tabla cliente_retira()
    Sub actualizar_tabla_retira()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from clientes_retira"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

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
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_proveedor")
                'txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_proveedor")
                txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_proveedor")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_proveedor")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_proveedor")

                txt_rut_cliente.Focus()
            Else
                '     MsgBox("RUT NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
            End If
            conexion.Close()
        End If
    End Sub

    'sub para mostrar los datos de los clientes.
    Sub mostrar_nombre_proveedor()
        conexion.Close()
        If txt_proveedor.Text <> "" Then
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
                'lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
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
        grilla_detalle_venta.Enabled = a
        txt_cantidad_agregar.Enabled = a
        txt_porcentaje_desc.Enabled = a
        txt_codigo.Enabled = a
        txt_rut_cliente.Enabled = a
        txt_nombre_producto.Enabled = a
        'dtp_ingreso.Enabled = a
        txt_precio_modificado.Enabled = a
        txt_factura.Enabled = a
        Combo_vendedor.Enabled = a
        'Combo_codigo_referencia.Enabled = a
        GroupBox_clientes.Enabled = a
        GroupBox_condicion.Enabled = a
        GroupBox_descuento.Enabled = a
        GroupBox_ingreso.Enabled = a
        'GroupBox_nro_doc.Enabled = a
        GroupBox_producto.Enabled = a
        'GroupBox_referencia.Enabled = a
        GroupBox_totales.Enabled = a
        GroupBox_vendedor.Enabled = a
        If mirutempresa = "81921000-4" Then
            Combo_vendedor.Enabled = False
            If mirecintoempresa <> "VALDIVIA 060" Then
                GroupBox_producto.Enabled = False
            End If
            combo_condiciones.Enabled = False
            'btn_quitar_elemento.Enabled = False
            'Combo_codigo_referencia.Enabled = False
        End If
    End Sub

    'nos permite limpiar los campos de la pantalla cuando lo necesitemos.
    Sub limpiar()
        txt_pie.Text = ""
        txt_cantidad.Text = ""
        'txt_desglose.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_iva.Text = ""
        txt_marca.Text = ""
        txt_neto.Text = ""
        'lbl_rut.Text = "nada"
        'lbl_codigo.Text = "nada"
        txt_nombre_cliente.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        txt_sub_total.Text = ""
        txt_factor.Text = ""
        txt_rut_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_codigo.Text = ""
        txt_descuento_cliente.Text = ""
        txt_desc.Text = ""
        txt_total.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_porcentaje_desc.Text = ""
        ' txt_nombre_retira.Text = ""
        'txt_rut_retira.Text = ""
        txt_rut_cliente.Text = ""
        txt_factura.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_giro_cliente.Text = ""
        txt_telefono.Text = ""
        txt_folio.Text = ""
        txt_ciudad_cliente.Text = ""
        txt_correo_cliente.Text = ""

        Combo_vendedor.Text = ""
        txt_rut_vendedor.Text = ""

        grilla_detalle_venta.Rows.Clear()
        txt_item.Text = "0"

        txt_codigo.Text = ""
        txt_rut_cliente.Text = ""
        txt_proveedor.Text = ""
        'combo_venta.Text = ""
        combo_condiciones.Text = "GARANTIA"
        txt_aplicacion.Text = ""

        txt_neto.Text = ""
        txt_iva.Text = ""
        txt_sub_total.Text = ""
        txt_total.Text = ""
        'Combo_codigo_referencia.Text = ""

        txt_codigo.Text = ""
        txt_rut_cliente.Text = ""
        txt_proveedor.Text = ""

        'Combo_codigo_referencia.Text = "-"
        Combo_vendedor.SelectedItem = "-"

        txt_sub_total_millar.Text = ""
        txt_neto_millar.Text = ""
        txt_iva_millar.Text = ""
        txt_desc_millar.Text = ""
        txt_total_millar.Text = ""

        combo_condiciones.Text = "GARANTIA"


        'Radio_electronica.Checked = True
        txt_codigo.Focus()
    End Sub

    'limpiar producto se utiliza cuando agregamos el producto a la grilla.
    Sub limpiar_producto()
        'lbl_codigo.Text = "nada"
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
        txt_proveedor.Text = ""
        txt_aplicacion.Text = ""
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

        If mirecintoempresa <> "VALDIVIA 060" Then
            Form_seleccionar_documento_para_garantias.Show()
            mostrar_datos_clientes_or()
            GroupBox_clientes.Enabled = False
            Me.Enabled = False
        Else

            controles(True, False)
            Combo_vendedor.Text = minombre
            txt_rut_cliente.Focus()
        End If
        'Form_seleccionar_documento_para_garantias.Show()
        'Me.Enabled = False
        'combo_venta.SelectedItem = "BOLETA"
        'calcular_totales()
        'controles(True, False)
        'dtp_ingreso.Focus()
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


                    Dim porcentaje_desc_2 As Integer
                    Dim porcentaje_desc_3 As String

                    porcentaje_desc_2 = porcentaje_desc

                    porcentaje_desc = porcentaje_desc_2
                    porcentaje_desc_3 = porcentaje_desc_2 / 100

                    porcentaje_desc_3 = 1 - porcentaje_desc_3

                    txt_precio.Text = Int(txt_precio_modificado.Text / porcentaje_desc_3)

                    desc = (txt_precio.Text - txt_precio_modificado.Text)
                    desc = (desc * txt_cantidad_agregar.Text)




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


    Sub crear_numero_documento()
        Dim varnumdoc As Integer

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from guia where tipo_impresion <> 'DIGITADA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
            End If
        Catch err As InvalidCastException
            txt_factura.Text = 1
            Exit Sub
        End Try

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select n_guia from guia where cod_auto='" & (varnumdoc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_guia")
                txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_factura.Text = 1
        End Try
        conexion.Close()
        Exit Sub
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
                    'lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
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
                'lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
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
            End If
            conexion.Close()
        End If
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

        Dim cadena As String = txt_cantidad_agregar.Text
        Dim inicioCadena As String = cadena(0).ToString()
        Dim finCadena As String = cadena(cadena.Length - 1).ToString()



        If Not IsNumeric(inicioCadena) Then
            MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If
        If Not IsNumeric(finCadena) Then
            MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txt_cantidad_agregar.Text) Then
            MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If






        If IsNumeric(txt_precio.Text) = False Then
            txt_precio.Text = "0"
        End If

        If IsNumeric(txt_precio_modificado.Text) = False Then
            txt_precio_modificado.Text = "0"
        End If

        If IsNumeric(txt_cantidad_agregar.Text) = False Then
            txt_cantidad_agregar.Text = "0"
        End If

        If IsNumeric(txt_cantidad.Text) = False Then
            txt_cantidad.Text = "0"
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






            Exit Sub
        End If




        If grilla_detalle_venta.Rows.Count < 22 Then
            venta()
            txt_item.Text = grilla_detalle_venta.Rows.Count
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            'detalle_label()
            Exit Sub
        Else
            MsgBox("EN UNA NOTA DE CREDITO NO PUEDE AGREGAR MAS DE 22 ITEMS", 0 + 16, "ERROR")
            Exit Sub
        End If























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
        'Dim VarCantidad As Long
        '//Calcular el descuento
        txt_desc.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1

            descgrilla = Val(grilla_detalle_venta.Rows(i).Cells(9).Value.ToString)
            txt_desc.Text = Val(txt_desc.Text) + Val(descgrilla)



        Next

        '//Calcular el descuento
        txt_desc_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            descgrilla = Val(grilla_detalle_venta.Rows(i).Cells(9).Value.ToString)
            '  VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            '   descgrilla = descgrilla * VarCantidad
            txt_desc_total.Text = Val(txt_desc_total.Text) + Val(descgrilla)
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


        If txt_porcentaje_desc.Text = "" Then
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



        'Dim iva As Integer
        'Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        txt_neto.Text = Round(txt_total.Text / iva_valor)
        txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)
        txt_iva.Text = (txt_total.Text) - (txt_neto.Text)



        'Dim valor_total As Integer
        'valor_total = txt_total_final.Text
        'Dim finTotal As Integer
        'Dim numerofinal As Integer

        'finTotal = Strings.Right(valor_total, 2)
        'numerofinal = Strings.Right(valor_total, 1)

        'If numerofinal = 0 Then
        '    Exit Sub
        'End If




        'If combo_venta.Text <> "FACTURA DE CREDITO" And combo_venta.Text <> "BOLETA DE CREDITO" And combo_venta.Text <> "GUIA" Then
        '    valor_total = valor_total - numerofinal
        '    txt_desc.Text = txt_desc.Text + numerofinal
        '    txt_total_final.Text = valor_total
        'End If











        peso = " PESOS"
        If CInt(txt_total.Text) = 1000000 Then
            desglose_valor = Num2Text(txt_total.Text) & " DE PESOS"
        ElseIf CInt(txt_total.Text) = 2000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 3000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 4000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 5000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 6000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 7000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 8000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 9000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 10000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 11000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 12000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 13000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 14000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 15000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 16000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 17000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 18000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 19000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 20000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 21000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 22000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 23000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 24000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 25000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 26000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 27000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 28000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 29000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 30000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        Else
            desglose_valor = Num2Text(txt_total.Text) & peso
        End If
        ' Strings.Right(TextBox1.Text, 1)



        'Dim valor_total As Integer
        'valor_total = txt_total_final.Text
        'Dim finTotal As Integer

        'finTotal = Strings.Right(valor_total, 2)

        'If finTotal = 50 Then
        '    Exit Sub
        'End If

        'If finTotal > 0 And finTotal < 50 Then
        '    valor_total = valor_total - finTotal
        'End If

        'If finTotal > 50 Then
        '    finTotal = finTotal - 50
        '    valor_total = valor_total - finTotal
        'End If

        'txt_desc_total.Text = txt_desc_total.Text + finTotal
        'txt_total_final.Text = valor_total


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

    'al presionarlo quita el elemento seleccionado de la grilla.
    Private Sub btn_quitar_elemento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_detalle_venta.Rows.Count > 0 Then
            grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.CurrentRow)
            calcular_totales()
            txt_item.Text = grilla_detalle_venta.Rows.Count
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

    Sub imprimir()

        ' Dim mensaje As String = ""

        'fecha()




        'If Combo_codigo_referencia.Text = "" Then
        '    MsgBox("COMBO CODIGO DE REFERENCIA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Combo_codigo_referencia.Focus()
        '    Exit Sub
        'End If

        'If Combo_codigo_referencia.Text = "-" Then
        '    MsgBox("COMBO CODIGO DE REFERENCIA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Combo_codigo_referencia.Focus()
        '    Exit Sub
        'End If

        If txt_factura.Text = "" Then
            MsgBox("NRO. DOC. VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_factura.Focus()
            Exit Sub
        End If


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

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If


        If combo_condiciones.Text = "" Then
            MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        If Combo_vendedor.Text = "" Then
            MsgBox("CAMPO VENDEDOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_vendedor.Focus()
            Exit Sub
        End If

        If Combo_vendedor.Text = "-" Then
            MsgBox("CAMPO VENDEDOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_vendedor.Focus()
            Exit Sub
        End If

        If txt_rut_vendedor.Text = "" Then
            MsgBox("CAMPO VENDEDOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_vendedor.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            MsgBox("CAMPO CONDICIONES VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_vendedor.Focus()
            Exit Sub
        End If

        'If Combo_codigo_referencia.Text = "-" Then
        '    MsgBox("CAMPO CONDICIONES VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Combo_vendedor.Focus()
        '    Exit Sub
        'End If

        If grilla_detalle_venta.Rows.Count > 22 Then
            MsgBox("NO PUEDE AGREGAR MAS DE 22 ITEMS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
            txt_codigo.Focus()
            Exit Sub
        End If

        If valida_rut(txt_rut_cliente.Text) = False Then
            txt_rut_cliente.Focus()
            txt_rut_cliente.SelectAll()
            Exit Sub
        End If




        Me.Enabled = False

        crear_numero_documento()
        '   If Radio_electronica.Checked = True Then
        'conexion.Close()
        'DS4.Tables.Clear()
        'DT4.Rows.Clear()
        'DT4.Columns.Clear()
        'DS4.Clear()
        'conexion.Open()

        'SC4.Connection = conexion
        'SC4.CommandText = "select * from nota_credito where n_nota_credito ='" & (txt_factura.Text) & "' and tipo_impresion='ELECTRONICA'"
        'DA4.SelectCommand = SC4
        'DA4.Fill(DT4)
        'DS4.Tables.Add(DT4)

        'If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
        '    MsgBox("EL  DOCUMENTO YA FUE INGRESADO", 0 + 16, "ERROR")
        '    Me.Enabled = True
        '    conexion.Close()
        '    Exit Sub
        'End If
        'conexion.Close()

        Dim valormensaje As Integer

        valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA GUIA DE GARANTIA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")

        If valormensaje = vbYes Then
            If txt_porcentaje_desc.Text = "" Then
                txt_porcentaje_desc.Text = "0"
            End If


            If estado_guia_electronica = "NO" Then
                If impresora_guias <> "SIN IMPRESION" Then
                    With Pd.PrinterSettings
                        ' Especifico el nombre de la impresora 
                        ' por donde deseo imprimir. 
                        .PrinterName = impresora_guias
                        ' Establezco el número de copias que se imprimirán 
                        .Copies = 1
                        ' Rango de páginas que se imprimirán 
                        .PrintRange = PrintRange.AllPages
                        If .IsValid Then
                            Me.Enabled = False
                            Me.crear_numero_documento()
                            Me.grabar_factura()
                            Me.Pd.PrintController = New StandardPrintController
                            Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                            Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                            Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                            Pd.Print()
                            Me.grabar_detalle_factura()
                            Me.crear_archivo_plano()
                            MsgBox("IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                            Me.limpiar()
                            Me.Enabled = True
                            Me.controles(False, True)
                            Exit Sub
                        Else
                            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                            Me.Enabled = True
                            Exit Sub
                        End If
                    End With
                End If
                If impresora_guias = "SIN IMPRESION" Then
                    Me.Enabled = False
                    Me.crear_numero_documento()
                    Me.grabar_factura()
                    Me.grabar_detalle_factura()
                    MsgBox("IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                    Me.limpiar()
                    Me.Enabled = True
                    Me.controles(False, True)
                End If
            Else
                Me.Enabled = False
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                Me.crear_archivo_plano()
                MsgBox("IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                Me.limpiar()
                Me.Enabled = True
                Me.controles(False, True)
                Exit Sub
            End If
        Else
            Me.Enabled = True
        End If






    End Sub




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
        'Dim fecha_traspaso As String
        'Dim hora_traspaso As String
        'Dim estado_traspaso As String
        'Dim usuario_responsable_traspaso As String
        'Dim sucursal_traspaso As String
        'Dim nombre_traspaso As String
        'Dim aplicacion_traspaso As String
        'Dim nro_tecnico_traspaso As String
        'Dim marca_traspaso As String
        ''Dim cod_barra_traspaso As String
        'Dim familia_traspaso As String
        'Dim subfamilia_traspaso As String
        'Dim subfamilia2_traspaso As String
        'Dim cantidad_minima_traspaso As String
        'Dim precio_traspaso As String
        'Dim tipo_precio_traspaso As String
        'Dim factor_traspaso As String
        'Dim costo_traspaso As String
        'Dim rut_proveedor_traspaso As String
        'Dim fecha_ult_compra_traspaso As String
        'Dim cant_ult_compra_traspaso As String
        'Dim tipo_doc_traspaso As String
        'Dim nro_doc_traspaso As String
        'Dim codigo_familia_traspaso As String
        'Dim codigo_subfamilia_traspaso As String
        'Dim codigo_subfamilia_2_traspaso As String
        'Dim cantidad_ultima_compra_traspaso As String
        'Dim ultima_compra_traspaso As String
        'Dim codigo_barra_traspaso As String

        'If combo_venta.Text = "GUIA" Then
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

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_guia (n_guia, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, detalle_descuento, porcentaje_desc, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarPorcentaje) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)

            'SC.Connection = conexion
            'SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)

            'SC.Connection = conexion
            'SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'GUIA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (dtp_fecha.Text) & "', '" & (miusuario) & "' ,'EMITIDA')"
            'DA.SelectCommand = SC
            'DA.Fill(DT)


        Next
        'End If

        'grabar_detalle_factura_remoto()
        'recupera




















        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As Integer
        'Dim VarPorcentaje As Integer
        'Dim VarDescuento As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        'Dim VarTotal As Integer

        'For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '    VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
        '    varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
        '    vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
        '    VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
        '    VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
        '    VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
        '    VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
        '    VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
        '    VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '    VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
        '    VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

        '    SC.Connection = conexion
        '    SC.CommandText = "insert into detalle_envio_garantias (n_envio_garantia, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total ) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Next
    End Sub

    Sub grabar_factura()


        Dim tipo_impresion As String
        tipo_impresion = ""



        If estado_guia_electronica = "SI" Then
            tipo_impresion = "ELECTRONICA"
        Else
            tipo_impresion = "MANUAL"
        End If




        'SC.Connection = conexion
        'SC.CommandText = "INSERT INTO `folio_cambio` (`nro_cambio`, `nro_guia`) VALUES ('" & (txt_folio_cambio.Text) & "', '" & (txt_factura.Text) & "');"
        'DA.SelectCommand = SC
        'DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into guia (n_guia, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable,rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, desglose, vehiculo, patente) values (" & (txt_factura.Text) & " , '" & ("GUIA DE GARANTIA") & "', '" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','0'," & (txt_neto.Text) & "," & (txt_iva.Text) & ",'0'," & (txt_total.Text) & ",'TRASLADO','" & ("SIN FACTURAR") & "','" & (miusuario) & "','-','-','" & (mirecintoempresa) & "','" & ("0") & "','" & (Form_menu_principal.lbl_hora.Text) & "','0','" & (tipo_impresion) & "', '-','-','-')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'SC.Connection = conexion
        'SC.CommandText = "insert into guia (n_envio_garantia, TIPO, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, tipo_documento, nro_documento, vendedor, fecha_ingreso, hora, porcentaje_desc) values (" & (txt_factura.Text) & ",'" & ("NOTA DE CREDITO") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "', '" & (dtp_ingreso.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (miusuario) & "','-','-','" & (mirecintoempresa) & "','" & (txt_tipo_doc_referencia.Text) & "','" & (txt_nro_doc_referencia.Text) & "','" & (txt_rut_vendedor.Text) & "','" & (dtp_fecha_diaria.Text) & "','" & (form_Menu_admin.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "')"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
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

        'fecha()
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


            conexion.Close()
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





            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "insert into factura_temporal (n_factura,documento, codigo_producto, nombre_producto, numero_tecnico, cantidad, precio, porcentaje_desc, subtotal_detalle, total_detalle, NOMBRE_VENDEDOR) values('" & (txt_factura.Text) & "', 'NOTA DE CREDITO','" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarCantidad) & "," & (VarValorUnitario) & "," & (VarPorcentaje) & "," & (VarSubtotal) & "," & (VarTotal) & ",'" & (minombre) & "')"

            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub

    Sub grabar_documento_temporal()
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

        If grilla_detalle_venta.Rows.Count = 0 Then
            Exit Sub
        End If

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

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "insert into documento_temporal (cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, usuario) values( '" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "','" & (VarValorUnitario) & "','" & (VarCantidad) & "','" & (VarPorcentaje) & "','" & (VarDescuento) & "','" & (VarNeto) & "', '" & (VarIva) & "','" & (VarSubtotal) & "','" & (VarTotal) & "','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub

    Sub cargar_documento_temporal()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from documento_temporal where usuario='" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)


        Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
            Next
        End If


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "delete from documento_temporal where usuario='" & (miusuario) & "'"
        DA.Fill(DT)
        conexion.Close()
        calcular_totales()
    End Sub


    'segun el TIPO de documento selecconado llama al sub grabar y verifica que la csantidad de items no sobrepase el limite.
    Private Sub btn_grabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If combo_condiciones.Text = "" Then
            MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        If txt_folio_cambio.Text = "-" Then
            MsgBox("CAMPO FOLIO CAMBIO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_folio_cambio.Focus()
            Exit Sub
        End If

        Dim valor_total As Integer
        '  Dim finTotal As Integer
        Dim numerofinal As Integer

        If combo_condiciones.Text <> "CREDITO" Then

            valor_total = txt_total.Text
            numerofinal = 0
            '  finTotal = Strings.Right(valor_total, 2)
            numerofinal = Strings.Right(valor_total, 1)

            valor_total = valor_total - numerofinal
            Round(valor_total)

        ElseIf combo_condiciones.Text = "CREDITO" Then

            valor_total = txt_total.Text

        End If




        'If Combo_codigo_referencia.Text = "ANULA DOCUMENTO DE REFERENCIA" And txt_total_doc_referencia.Text <> valor_total Then
        '    MsgBox("EL TOTAL DE LA NOTA DE CREDITO ES DISTINTO AL TOTAL DEL DOC. DE REFERENCIA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    txt_codigo.Focus()
        '    Exit Sub
        'End If


        If txt_tipo_doc_referencia.Text = "FACTURA" And txt_rut_doc_referencia.Text <> txt_rut_cliente.Text Then
            MsgBox("EL RUT DE LA NOTA DE CREDITO ES DISTINTO AL RUT DE LA FACTURA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo.Focus()
            Exit Sub
        End If



        'If Combo_codigo_referencia.Text = "CORRIGE TEXTO DOCUMENTO DE REFERENCIA" And grilla_detalle_venta.Rows.Count <> 0 Then
        '    MsgBox("AL CORREGIR TEXTO DEL DOC. DE REFERENCIA NO PUEDES INGRESAR PRODUCTOS EN LA NOTA DE CREDITO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    txt_codigo.Focus()
        '    Exit Sub
        'End If




        imprimir()


    End Sub








    Private Sub combo_venta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            combo_condiciones.Focus()
        End If
    End Sub

    Private Sub combo_venta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'combo_venta.BackColor = Color.LightBlue
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            'lbl_descto.Text = "10"
            'lbl_venta.Text = combo_venta.SelectedItem

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









    'llamamos al sub condiciones.
    'decimos que el descuento por defecto es 10, este puede cambir segun el que tenga guardado en sus datos.
    'habilitamos el combo condiciones.
    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub txt_cantidad_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_agregar.KeyPress



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




        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If

        'If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
        '    'limpiar_producto()
        '    mostrar_cantidad_real()
        '    'txt_cantidad_agregar.Text = ""
        '    txt_codigo.Focus()
        '    'condiciones()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            ' limpiar_producto()

            'txt_cantidad_agregar.Text = ""

            'condiciones()
            btn_agregar.PerformClick()
        End If

        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

    End Sub

    Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_clientes_enter()
            '  txt_porcentaje_desc.Text = "0"
            mostrar_datos_clientes()
            ' llenar_combo_retira()
            'limpiar_datos_clientes_retira()
            ' txt_rut_retira.Focus()
            'guardar_descuento()
            grilla_detalle_venta.Rows.Clear()
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
            '    mostrar_datos_retira()
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

    Private Sub combo_condiciones_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.GotFocus
        combo_condiciones.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_condiciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles combo_condiciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_grabar.Focus()
        End If
    End Sub

    Private Sub combo_condiciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_condiciones.KeyPress

    End Sub

    Private Sub combo_condiciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.LostFocus
        combo_condiciones.BackColor = Color.White
    End Sub



    Private Sub txt_cantidad_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White
    End Sub



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

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub



    'Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles 
    '    txt_rut.BackColor = Color.LightBlue
    'End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress
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



        limpiar_datos_clientes_enter()




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

    'Sub guion_rut_cliente_retira()
    '    Dim rut_cliente As String
    '    Dim guion As String
    '    rut_cliente = txt_rut_retira.Text
    '    If rut_cliente.Length > 2 Then

    '        guion = rut_cliente(rut_cliente.Length - 2).ToString()

    '        If guion <> "-" Then
    '            Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
    '            rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
    '            rut_cliente = rut_cliente & "-" & fin_rut
    '            txt_rut_retira.Text = rut_cliente
    '        End If
    '    End If
    'End Sub


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

    Private Sub txt_cantidad_agregar_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White
    End Sub

    Private Sub txt_factura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_factura.GotFocus
        txt_factura.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_factura_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_factura.LostFocus
        txt_factura.BackColor = Color.White
    End Sub

    Private Sub combo_retira_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txt_codigo.Focus()
        End If
    End Sub


    Private Sub btn_agregar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        Form_registro_clientes_ventas.Show()
        'Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()

            controles(False, True)
            Form_seleccionar_documento_para_garantias.Show()

        End If
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
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



    Private Sub txt_folio_cambio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_folio_cambio.GotFocus
        txt_folio_cambio.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_folio_cambio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_folio_cambio.LostFocus
        txt_folio_cambio.BackColor = Color.White
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

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

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

    Private Sub txt_descto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.GotFocus
        txt_porcentaje_desc.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_descto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_porcentaje_desc.KeyPress


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

    Private Sub combo_condiciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_condiciones.SelectedIndexChanged
        ' lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
        'detalle_label()
    End Sub

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


        'Dim primer_caracter As String
        'Dim ultimo_caracter As String
        'Dim total_caracter As String

        'If txt_cantidad_agregar.Text = "" Then
        '    primer_caracter = 0
        '    ultimo_caracter = 0
        'Else
        '    primer_caracter = txt_cantidad_agregar.Text.Length - txt_cantidad_agregar.Text.Length + 1
        '    ultimo_caracter = txt_cantidad_agregar.Text.Length
        '    total_caracter = txt_cantidad_agregar.Text
        'End If



        'Dim n1 As Byte, lMal As Boolean

        'total_caracter = ""
        'If txt_cantidad_agregar.Text <> "" Then

        '    For n1 = ultimo_caracter To ultimo_caracter
        '        If Not IsNumeric(Mid(txt_cantidad_agregar.Text, n1, 1)) Then
        '            MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
        '            txt_cantidad_agregar.Focus()
        '            lMal = True
        '            Exit For
        '        End If
        '    Next

        '    For n1 = 1 To 1
        '        If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
        '            MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
        '            txt_cantidad_agregar.Focus()
        '            lMal = True
        '            Exit For
        '        End If
        '    Next
        'End If
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

    'Private Sub btn_imagen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imagen.BackColor = Color.Yellow
    'End Sub

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
    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage


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

        Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        'If Me.combo_venta.Text = "GUIA" Then
        If mirutempresa = "87686300-6" Then
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 100, 20)
            e.Graphics.DrawString(Me.txt_factura.Text, Font10, Brushes.Black, 550, 20, format1)
            e.Graphics.DrawString(Me.txt_nombre_cliente.Text, Font10, Brushes.Black, 100, 36)
            e.Graphics.DrawString(Me.txt_folio.Text, Font10, Brushes.Black, 550, 36, format1)
            e.Graphics.DrawString(Me.txt_direccion_cliente.Text, Font10, Brushes.Black, 100, 52)


            e.Graphics.DrawString(Me.txt_giro_cliente.Text, Font10, Brushes.Black, 100, 68)
            e.Graphics.DrawString(Me.txt_rut_cliente.Text, Font10, Brushes.Black, 655, 20)
            e.Graphics.DrawString(Me.txt_comuna_cliente.Text, Font10, Brushes.Black, 655, 36)
            e.Graphics.DrawString(Me.txt_telefono.Text, Font10, Brushes.Black, 655, 52)
            e.Graphics.DrawString(Me.combo_condiciones.Text, Font10, Brushes.Black, 655, 68)
            e.Graphics.DrawString(minombre, Font10, Brushes.Black, 655, 84)

            For i = 0 To Me.grilla_detalle_venta.Rows.Count - 1
                VarCodProducto = Me.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = Me.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = Me.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = Me.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = Me.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = Me.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = Me.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = Me.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = Me.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = Me.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = Me.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                cantidad_detalle = Me.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = Me.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = Me.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = Me.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
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
            Next

            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String

            neto_millar = Me.txt_neto.Text
            iva_millar = Me.txt_iva.Text
            total_millar = Me.txt_total.Text

            neto_millar = Format(Int(neto_millar), "###,###,###")
            iva_millar = Format(Int(iva_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            ' e.Graphics.DrawString(Me.txt_nombre_retira.Text, Font8, Brushes.Black, 55, 540)
            ' e.Graphics.DrawString(Me.txt_rut_retira.Text, Font8, Brushes.Black, 265, 540)
            e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 510, 540)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 797, 540, format1)
        End If

        If mirutempresa = "81921000-4" Then
            e.Graphics.DrawString("NRO. GUIA: " & txt_factura.Text & ", PROVIENE DE: " & mirecintoempresa, Font10, Brushes.Black, 0, 0)
            'e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 85, 0)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Value.Day & "          " & Form_menu_principal.dtp_fecha.Value.Month & "         " & Form_menu_principal.dtp_fecha.Value.Year, Font10, Brushes.Black, 620, 0)
            e.Graphics.DrawString(txt_nombre_cliente.Text, Font10, Brushes.Black, 80, 40)
            e.Graphics.DrawString(txt_direccion_cliente.Text, Font10, Brushes.Black, 80, 57)
            e.Graphics.DrawString(txt_giro_cliente.Text, Font10, Brushes.Black, 80, 74)
            e.Graphics.DrawString(txt_telefono.Text, Font10, Brushes.Black, 80, 91)
            'e.Graphics.DrawString(Combo_vehiculo.Text, Font10, Brushes.Black, 80, 108)
            e.Graphics.DrawString(txt_rut_cliente.Text, Font10, Brushes.Black, 550, 40)
            e.Graphics.DrawString(txt_comuna_cliente.Text, Font10, Brushes.Black, 550, 57)
            e.Graphics.DrawString(txt_ciudad_cliente.Text, Font10, Brushes.Black, 550, 74)
            e.Graphics.DrawString(combo_condiciones.Text, Font10, Brushes.Black, 550, 91)
            'e.Graphics.DrawString(txt_patente.Text, Font10, Brushes.Black, 550, 108)

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
                cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")

                If varnombre.Length > 35 Then
                    varnombre = varnombre.Substring(0, 35)
                End If

                If vartecnico.Length > 22 Then
                    vartecnico = vartecnico.Substring(0, 22)
                End If

                e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 190 + (i * 15))
                e.Graphics.DrawString(varnombre & " " & vartecnico, Font8, Brushes.Black, 130, 190 + (i * 15))
                e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 570, 190 + (i * 15), format1)
                ' e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 730, 190 + (i * 15), format1)
            Next

            e.Graphics.DrawString("GUIA DE GARANTIA, NO CONSTITUYE VENTA", Font9, Brushes.Black, 35, 650)
            'e.Graphics.DrawString("NOMBRE: " & txt_nombre_retira.Text & , Font9, Brushes.Black, 35, 670)
        End If

    End Sub



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




    'Private Sub Timer_ventas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_ventas.Tick
    '    Dim inactiveTime = GetInactiveTime()

    '    If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
    '        If Application.OpenForms.Count = 2 Then
    '            form_Menu_admin.Enabled = False
    '            form_Ingreso.Show()
    '            form_Ingreso.txt_usuario.Focus()
    '            Me.Close()
    '        Else
    '            Me.Close()
    '        End If
    '    End If
    'End Sub



    Private Sub txt_rut_retira_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'txt_rut_retira.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_retira_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            '
            txt_codigo.Focus()
            ' End If

        End If
    End Sub

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

    Sub crear_archivo_plano()
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String




        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer


        Dim nro_linea As String

        Dim nombre_cliente As String
        nombre_cliente = txt_nombre_cliente.Text
        If nombre_cliente.Length > 99 Then
            nombre_cliente = nombre_cliente.Substring(0, 100)
        End If

        Dim giro_cliente As String
        giro_cliente = txt_giro_cliente.Text
        If giro_cliente.Length > 39 Then
            giro_cliente = giro_cliente.Substring(0, 40)
        End If

        Dim direccion_cliente As String
        direccion_cliente = txt_direccion_cliente.Text
        If direccion_cliente.Length > 59 Then
            direccion_cliente = direccion_cliente.Substring(0, 60)
        End If

        Dim comuna_cliente As String
        comuna_cliente = txt_comuna_cliente.Text
        If comuna_cliente.Length > 19 Then
            comuna_cliente = comuna_cliente.Substring(0, 20)
        End If

        Dim ciudad_cliente As String
        ciudad_cliente = txt_ciudad_cliente.Text
        If ciudad_cliente.Length > 19 Then
            ciudad_cliente = ciudad_cliente.Substring(0, 20)
        End If

        Dim correo_cliente As String
        correo_cliente = txt_correo_cliente.Text
        If correo_cliente.Length > 199 Then
            correo_cliente = correo_cliente.Substring(0, 200)
        End If

        Dim telefono_cliente As String
        telefono_cliente = txt_telefono.Text
        If telefono_cliente.Length > 8 Then
            telefono_cliente = telefono_cliente.Substring(0, 8)
        End If



        If correo_cliente = "-" Then
            correo_cliente = ""
        End If

        If txt_folio.Text = "-" Then
            txt_folio.Text = ""
        End If

        '  Dim i As Integer



        Dim condicion As String
        condicion = combo_condiciones.Text








        'Try

        '    'If Directory.Exists("C:\Capeta") = False Then ' si no existe la carpeta se crea
        '    '    Directory.CreateDirectory("C:\carpeta")
        '    'End If

        '    If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
        '        Directory.CreateDirectory(ruta_archivos_planos)
        '    End If

        '    'If Directory.Exists("C:\Carpeta Facturacion Electronica") = False Then ' si no existe la carpeta se crea
        '    '    Directory.CreateDirectory("C:\Carpeta Facturacion Electronica")
        '    'End If

        '    Windows.Forms.Cursor.Current = Cursors.WaitCursor
        '    ' PathArchivo = "C:\carpeta\Archivo" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '    ' PathArchivo = "\\SERVER\Claudio Calderon R\Capeta\Archivo '" & (combo_venta.Text) & "'" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '    ' PathArchivo = "C:\Carpeta Facturacion Electronica\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '    PathArchivo = ruta_archivos_planos & "\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

        '    'verificamos si existe el archivo

        '    If File.Exists(PathArchivo) Then
        '        strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
        '    Else
        '        strStreamW = File.Create(PathArchivo) ' lo creamos
        '    End If

        '    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura


        '    'escribimos en el archivo

        '    strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
        '                            & "33" & ";" & (txt_factura.Text) & ";" & (dtp_ingreso.Text) & ";" & "0" & ";" & "0" & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (minombre) & ";"";"";" & (mirecintoempresa) & ";;" & vbNewLine _
        '                            & "->Totales<-" & vbNewLine _
        '                             & (txt_porcentaje_desc.Text) & ";" & (txt_desc.Text) & ";" & "0" & ";" & "0" & ";" & (txt_neto.Text) & ";" & "0" & ";" & (valor_iva) & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";1;" & vbNewLine _
        '                             & "->Detalle<-")

        '    '  strStreamWriter.Close() ' ce

        '    nro_linea = 0

        '    For i = 0 To grilla_detalle_venta.Rows.Count - 1


        '        nro_linea = nro_linea + 1
        '        VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
        '        varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
        '        vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
        '        VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
        '        VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
        '        VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
        '        VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
        '        VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
        '        VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '        VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
        '        VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString


        '        If VarCodProducto.Length > 34 Then
        '            VarCodProducto = VarCodProducto.Substring(0, 35)
        '        End If


        '        If varnombre.Length > 79 Then
        '            varnombre = varnombre.Substring(0, 80)
        '        End If

        '        varnombre = varnombre & " " & vartecnico

        '        If varnombre.Length > 79 Then
        '            varnombre = varnombre.Substring(0, 80)
        '        End If


        '        VarCantidad = Replace(VarCantidad, ",", ".")
        '        VarPorcentaje = Replace(VarPorcentaje, ",", ".")

        '        strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & (VarPorcentaje) & ";" & (VarDescuento) & ";" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotal) & ";" & "INT11" & ";" & "UN" & ";" & ";")


        '    Next

        '    If orden_de_compra = "" Then
        '        orden_de_compra = "-"
        '    End If


        '    strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
        '                                & "1" & ";" & Form_detalle_nota_credito.txt_tipo_dte.Text & ";" & Form_detalle_nota_credito.txt_nro_documento.Text & ";" & Form_detalle_nota_credito.dtp_fecha_documento.Text & ";" & txt_codigo_referencia.Text & ";" & Combo_codigo_referencia.Text & ";" & vbNewLine _
        '                            & "->Observacion<-" & vbNewLine _
        '                                & txt_folio.Text & ";" & combo_condiciones.Text & ";")
        '    strStreamWriter.Close() ' cerramos

        'Catch ex As Exception
        '    MsgBox("Error al Guardar la informacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
        '    strStreamWriter.Close() ' cerramos
        'End Try






































        Try

            'If Directory.Exists("C:\Capeta") = False Then ' si no existe la carpeta se crea
            '    Directory.CreateDirectory("C:\carpeta")
            'End If

            If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(ruta_archivos_planos)
            End If

            'If Directory.Exists("C:\Carpeta Facturacion Electronica") = False Then ' si no existe la carpeta se crea
            '    Directory.CreateDirectory("C:\Carpeta Facturacion Electronica")
            'End If

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            ' PathArchivo = "C:\carpeta\Archivo" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
            ' PathArchivo = "\\SERVER\Claudio Calderon R\Capeta\Archivo '" & (combo_venta.Text) & "'" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
            ' PathArchivo = "C:\Carpeta Facturacion Electronica\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual
            PathArchivo = ruta_archivos_planos & "\" & "Nota de credito " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo

            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura


            'escribimos en el archivo

            strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
                                       & "61" & ";" & (txt_factura.Text) & ";" & ("") & ";" & "0" & ";" & "0" & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (Combo_vendedor.Text) & ";;;" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
                                       & "->Totales<-" & vbNewLine _
                                        & (0) & ";" & (txt_desc_total.Text) & ";" & "0" & ";" & "0" & ";" & (txt_neto.Text) & ";" & "0" & ";" & (valor_iva) & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";1;" & vbNewLine _
                                        & "->Detalle<-")

            '  strStreamWriter.Close() ' ce

            nro_linea = 0

            For i = 0 To grilla_detalle_venta.Rows.Count - 1


                nro_linea = nro_linea + 1
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

                '      VarDescuento = VarDescuento * VarCantidad

                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString


                If VarCodProducto.Length > 34 Then
                    VarCodProducto = VarCodProducto.Substring(0, 35)
                End If


                If varnombre.Length > 79 Then
                    varnombre = varnombre.Substring(0, 80)
                End If

                varnombre = varnombre & " " & vartecnico

                If varnombre.Length > 52 Then
                    varnombre = varnombre.Substring(0, 52)
                End If


                VarCantidad = Replace(VarCantidad, ",", ".")
                VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & (VarPorcentaje) & ";" & (VarDescuento) & ";" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotal) & ";" & "INT11" & ";" & "UN" & ";" & ";")
            Next




            strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
                                        & "1" & ";" & txt_codigo_doc_referencia.Text & ";" & txt_nro_doc_referencia.Text & ";" & dtp_fecha_doc_referencia.Text & ";'0';'0';" & vbNewLine _
                                        & "->DescRec<-" & vbNewLine _
                                        & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & txt_desc.Text & ";" & "0" & ";" & vbNewLine _
                                        & "->Observacion<-" & vbNewLine _
                                        & txt_folio.Text & ";" & combo_condiciones.Text & ", " & mirecintoempresa & ";")





            strStreamWriter.Close() ' cerramos

        Catch ex As Exception
            MsgBox("Error al Guardar la informacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try





















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



        limpiar_datos_productos_enter()













        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_codigo.Text = "" Then
                Exit Sub
            End If
            conexion.Close()
            Dim cantidad_caracteres As Integer
            cantidad_caracteres = Len(txt_codigo.Text)
            If cantidad_caracteres <= 5 Then
                Form_buscador_productos_ventas.Show()
                ' Form_buscar_productos_ventas.txt_codigo.Text = txt_codigo.Text
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
                txt_precio_modificado.Focus()
                Exit Sub
            End If


        End If



    End Sub



    Private Sub txt_codigo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub



    Private Sub btn_buscar_productos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        txt_codigo.Focus()
        Form_buscador_productos_ventas.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub grilla_detalle_venta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_detalle_venta.Click
        If grilla_detalle_venta.Rows.Count = 0 Then
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

    'Private Sub Combo_codigo_referencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_codigo_referencia.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub Combo_codigo_referencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_codigo_referencia.BackColor = Color.White
    'End Sub

    Private Sub Combo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.GotFocus
        Combo_vendedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_vendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_vendedor.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub Combo_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.LostFocus
        Combo_vendedor.BackColor = Color.White
    End Sub

    Private Sub txt_precio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.GotFocus
        txt_precio_modificado.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_precio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.LostFocus
        txt_precio_modificado.BackColor = Color.White
    End Sub

    Private Sub Combo_codigo_referencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
    End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        mostrar_datos_vendedor()
    End Sub

    Private Sub Panel_contenedor_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

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

    Private Sub txt_precio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio.TextChanged

    End Sub

    Private Sub txt_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_factura.KeyPress
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
            txt_rut_cliente.Focus()
        End If
    End Sub

    Private Sub txt_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_factura.TextChanged

    End Sub

    Private Sub GroupBox_nro_doc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dtp_ingreso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_factura.Focus()
        End If
    End Sub

    Private Sub dtp_ingreso_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub grilla_detalle_venta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_detalle_venta.CellContentClick

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_folio_cambio.KeyPress
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


    'Private Sub Radio_electronica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Radio_electronica.Checked = True Then
    '        txt_factura.Enabled = False
    '        dtp_ingreso.Enabled = False
    '        dtp_ingreso.Text = FormatDateTime(Now, DateFormat.ShortDate)
    '    Else
    '        txt_factura.Enabled = True
    '        dtp_ingreso.Enabled = True
    '    End If

    '    txt_rut_cliente.Focus()
    'End Sub

    'Private Sub Radio_manual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Radio_electronica.Checked = True Then
    '        txt_factura.Enabled = False
    '        crear_numero_documento()
    '    Else
    '        txt_factura.Enabled = True
    '        txt_factura.Text = ""
    '    End If

    '    txt_rut_cliente.Focus()
    'End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_folio_cambio.TextChanged

    End Sub
End Class