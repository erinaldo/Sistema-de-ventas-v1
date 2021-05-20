Imports System.Drawing.Printing
Imports System.Math

Public Class Form_orden_de_compra
    Private WithEvents Pd As New PrintDocument
    Dim numero_lineas_total As Integer = 0

    Private Sub Form_orden_de_compra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_orden_de_compra_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_orden_de_compra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        cargar_logo()
        valores()
        controles(False, True)
        combo_condiciones.SelectedItem = "GARANTIA"
        txt_codigo.Focus()
        grilla_detalle_venta.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
        dtp_fecha_diaria.CustomFormat = "yyy-MM-dd"
        If mirutempresa = "81921000-4" Then
            combo_condiciones.Enabled = False
            btn_agregar.Enabled = False
            btn_quitar_elemento.Enabled = False
        End If
    End Sub
    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
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
            lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
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

    Sub limpiar_datos_clientes()
        lbl_rut.Text = "nada"
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
        txt_representante.Text = ""
    End Sub

    Sub limpiar_datos_clientes_enter()
        lbl_rut.Text = "nada"
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
        lbl_codigo.Text = "nada"
        txt_nombre_producto.Text = ""
        txt_marca.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad.Text = ""
        Combo_orden_de_compra.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        txt_costo.Text = ""
        txt_proveedor.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
        Combo_orden_de_compra.Items.Clear()
    End Sub

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
                txt_representante.Text = DS.Tables(DT.TableName).Rows(0).Item("representante_proveedor")
                txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_proveedor")
                txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_proveedor")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_proveedor")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_proveedor")
                txt_rut_cliente.Focus()
            Else
                txt_rut_cliente.Focus()
            End If
            conexion.Close()
        End If
    End Sub

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
                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
            End If
            conexion.Close()
            llenar_combo_codigo_de_barra()
        End If
    End Sub

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
        txt_precio_modificado.Enabled = a
        txt_factura.Enabled = a
        Combo_comentarios.Enabled = a
        GroupBox_clientes.Enabled = a
        GroupBox_condicion.Enabled = a
        GroupBox_descuento.Enabled = a
        GroupBox_ingreso.Enabled = a
        GroupBox_producto.Enabled = a
        GroupBox_comentarios.Enabled = a
        GroupBox_totales.Enabled = a
        GroupBox_vendedor.Enabled = a
    End Sub

    Sub limpiar()
        txt_cantidad.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_comuna_cliente.Text = ""
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
        Combo_orden_de_compra.Text = "-"
        txt_rut_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_codigo.Text = ""
        txt_descuento_cliente.Text = ""
        txt_desc.Text = ""
        txt_total.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_porcentaje_desc.Text = ""
        txt_rut_cliente.Text = ""
        txt_factura.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_giro_cliente.Text = ""
        txt_telefono.Text = ""
        txt_folio.Text = ""
        txt_ciudad_cliente.Text = ""
        txt_correo_cliente.Text = ""
        txt_representante.Text = ""
        grilla_detalle_venta.Rows.Clear()
        txt_item.Text = "0"
        txt_codigo.Text = ""
        txt_rut_cliente.Text = ""
        txt_proveedor.Text = ""
        combo_condiciones.Text = "GARANTIA"
        txt_aplicacion.Text = ""
        txt_neto.Text = ""
        txt_iva.Text = ""
        txt_sub_total.Text = ""
        txt_total.Text = ""
        Combo_comentarios.Text = ""
        txt_codigo.Text = ""
        txt_rut_cliente.Text = ""
        txt_proveedor.Text = ""
        Combo_comentarios.Text = "-"
        txt_sub_total_millar.Text = ""
        txt_neto_millar.Text = ""
        txt_iva_millar.Text = ""
        txt_desc_millar.Text = ""
        txt_total_millar.Text = ""
        combo_condiciones.Text = "-"
    End Sub

    Sub limpiar_producto()
        lbl_codigo.Text = "nada"
        txt_codigo.Text = ""
        txt_codigo.Text = ""
        txt_cantidad.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        Combo_orden_de_compra.Text = "-"
        txt_codigo.Text = ""
        txt_numero_tecnico.Text = ""
        txt_marca.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_proveedor.Text = ""
        txt_aplicacion.Text = ""
    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        controles(True, False)
        'dtp_ingreso.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Sub venta()
        Dim iva As Long
        Dim neto As Long
        Dim total As Long
        Dim codigo As Long
        Dim cantidad As Integer
        Dim desc As String
        Dim porcentaje_desc As String
        Dim subtotal As Long
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

        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))

        If txt_codigo.Text = "*" Then
            Try
                If txt_cantidad_agregar.Text <> "" And txt_cantidad_agregar.Text <> " " And txt_cantidad_agregar.Text <> "  " And txt_cantidad_agregar.Text <> 0 Then
                    If txt_cantidad.Text = "" Then
                        txt_cantidad.Text = "0"
                    End If

                    If txt_precio.Text = "" Then
                        txt_precio.Text = "0"
                    End If

                    If txt_precio_modificado.Text = "" Then
                        txt_precio_modificado.Text = "0"
                    End If

                    porcentaje_desc = "0"
                    desc = "0"

                    subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
                    iva_valor = valor_iva / 100 + 1
                    neto = (subtotal / iva_valor)
                    iva = (neto) * valor_iva / 100
                    total = subtotal - desc

                    grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, Combo_orden_de_compra.Text, txt_precio.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)
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

                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    codigo = Val(grilla_detalle_venta.Rows(i).Cells(0).Value.ToString)

                    cantidad = Val(grilla_detalle_venta.Rows(i).Cells(4).Value.ToString)
                    If codigo = txt_codigo.Text Then
                        grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.Rows(i))
                        Exit For
                    End If
                Next

                If txt_cantidad.Text = "" Then
                    txt_cantidad.Text = "0"
                End If

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
                    desc = (txt_precio.Text - txt_precio_modificado.Text)
                    desc = (desc * txt_cantidad_agregar.Text)
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

                grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, Combo_orden_de_compra.Text, precio_lista, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)
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
            SC.CommandText = "select max(cod_auto) as cod_auto from orden_de_compra where tipo_impresion <> 'DIGITADA'"
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
            SC.CommandText = "select n_orden_de_compra from orden_de_compra where cod_auto='" & (varnumdoc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_orden_de_compra")
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
                    lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")

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


                        conexion.Close()
                    End If
                    llenar_combo_codigo_de_barra()
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




        'If grilla_detalle_venta.Rows.Count < 22 Then
        '    venta()
        '    txt_item.Text = grilla_detalle_venta.Rows.Count
        '    mostrar_cantidad_real()
        '    txt_cantidad_agregar.Text = ""
        '    'detalle_label()
        '    Exit Sub
        'Else
        '    MsgBox("EN UNA NOTA DE CREDITO NO PUEDE AGREGAR MAS DE 22 ITEMS", 0 + 16, "ERROR")
        '    Exit Sub
        'End If

        venta()
        mostrar_cantidad_real()




















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
            SC.CommandText = "insert into detalle_orden_de_compra (n_orden_de_compra, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, detalle_descuento, porcentaje_desc, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarPorcentaje) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next
    End Sub

    Sub grabar_factura()
        SC.Connection = conexion
        SC.CommandText = "insert into orden_de_compra (n_orden_de_compra, TIPO, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable,rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion) values (" & (txt_factura.Text) & " , '" & ("GUIA DE GARANTIA") & "', '" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','0'," & (txt_neto.Text) & "," & (txt_iva.Text) & ",'0'," & (txt_total.Text) & ",'" & (combo_condiciones.Text) & "','EMITIDA','" & (miusuario) & "','-','-','" & (mirecintoempresa) & "','" & ("0") & "','" & (Form_menu_principal.lbl_hora.Text) & "','0','-')"
        DA.SelectCommand = SC
        DA.Fill(DT)
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

        If Combo_comentarios.Text = "" Then
            MsgBox("CAMPO COMENTARIOS VACIO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo.Focus()
            Exit Sub
        End If

        If Combo_comentarios.Text = "-" Then
            MsgBox("COMBO CODIGO DE REFERENCIA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_comentarios.Focus()
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

        If valida_rut(txt_rut_cliente.Text) = False Then
            txt_rut_cliente.Focus()
            txt_rut_cliente.SelectAll()
            Exit Sub
        End If

        Dim valormensaje As Integer
        valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR LA ORDEN DE COMPRA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
        If valormensaje = vbYes Then
            If txt_porcentaje_desc.Text = "" Then
                txt_porcentaje_desc.Text = "0"
            End If



            lbl_mensaje.Visible = True
            Me.Enabled = False

            Me.crear_numero_documento()
            Me.grabar_factura()
            Me.grabar_detalle_factura()

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

            Me.limpiar()
            controles(False, True)
            lbl_mensaje.Visible = False
            Me.Enabled = True

            'MsgBox("IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            'Me.controles(False, True)
            'Exit Sub
        End If


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

            'controles(False, True)
            'Form_seleccionar_documento_para_garantias.Show()

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

    Private Sub Combo_codigo_referencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_comentarios.GotFocus
        Combo_comentarios.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_codigo_referencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_comentarios.LostFocus
        Combo_comentarios.BackColor = Color.White
    End Sub

    Private Sub txt_precio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.GotFocus
        txt_precio_modificado.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_precio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.LostFocus
        txt_precio_modificado.BackColor = Color.White
    End Sub

    Private Sub Combo_codigo_referencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_comentarios.KeyPress
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



    Private Sub Combo_codigo_referencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_comentarios.SelectedIndexChanged
        If Combo_comentarios.Text = "SIN CODIGO DE REFERENCIA" Then
            txt_codigo_referencia.Text = "0"
        End If
        If Combo_comentarios.Text = "ANULA DOCUMENTO DE REFERENCIA" Then
            txt_codigo_referencia.Text = "1"
        End If
        If Combo_comentarios.Text = "CORRIGE TEXTO DOCUMENTO DE REFERENCIA" Then
            txt_codigo_referencia.Text = "2"
        End If
        If Combo_comentarios.Text = "CORRIGE MONTOS" Then
            txt_codigo_referencia.Text = "3"
        End If
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

    Private Function ReturnDataSet() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        dt.Columns.Add(New DataColumn("logo_empresa", GetType(Byte())))
        dt.Columns.Add(New DataColumn("DataColumn1", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn2", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn3", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn4", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn5", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn6", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn7", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn8", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn9", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn10", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn11", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn12", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn13", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn14", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn15", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn16", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn17", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn18", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn19", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn20", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn21", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn22", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn23", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn24", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn25", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn26", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn27", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn28", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn29", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn30", GetType(String)))

        dt.Columns.Add(New DataColumn("titulo", GetType(String)))
        dt.Columns.Add(New DataColumn("fechas", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

        Dim DataColumn1 As String
        Dim DataColumn2 As String
        Dim DataColumn3 As String
        Dim DataColumn4 As String
        Dim DataColumn5 As String
        Dim DataColumn6 As String
        Dim DataColumn7 As String
        Dim DataColumn8 As String
        Dim DataColumn9 As String
        'Dim DataColumn10 As String

        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            DataColumn1 = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            DataColumn2 = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            DataColumn3 = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            DataColumn4 = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            DataColumn5 = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            DataColumn6 = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            DataColumn7 = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            DataColumn8 = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            DataColumn9 = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
            'DataColumn10 = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            dr = dt.NewRow()

            Try
                dr("logo_empresa") = Imagen_reporte
            Catch
            End Try



            dr("nombre_empresa") = minombreempresa
            dr("giro_empresa") = migiroempresa
            dr("direccion_empresa") = midireccionempresa
            dr("comuna_empresa") = micomunaempresa
            dr("telefono_empresa") = mitelefonoempresa
            dr("correo_empresa") = micorreoempresa
            dr("rut_empresa") = mirutempresa

            dr("DataColumn1") = DataColumn1
            dr("DataColumn2") = DataColumn2
            dr("DataColumn3") = DataColumn3
            dr("DataColumn4") = DataColumn4
            dr("DataColumn5") = DataColumn5
            dr("DataColumn6") = DataColumn6
            dr("DataColumn7") = DataColumn7
            dr("DataColumn8") = DataColumn8
            dr("DataColumn9") = DataColumn9

            dr("DataColumn10") = txt_nombre_cliente.Text
            dr("DataColumn11") = txt_direccion_cliente.Text
            dr("DataColumn12") = txt_giro_cliente.Text
            dr("DataColumn13") = txt_factura.Text
            dr("DataColumn14") = Form_menu_principal.dtp_fecha.Text
            dr("DataColumn15") = txt_rut_cliente.Text
            dr("DataColumn16") = txt_telefono.Text
            dr("DataColumn17") = combo_condiciones.Text
            dr("DataColumn18") = txt_representante.Text
            dr("DataColumn19") = txt_nombre_cliente.Text
            dr("DataColumn20") = txt_sub_total_millar.Text
            dr("DataColumn21") = txt_porcentaje_desc.Text
            dr("DataColumn22") = txt_desc_millar.Text
            dr("DataColumn23") = txt_neto_millar.Text
            dr("DataColumn24") = txt_iva_millar.Text
            dr("DataColumn25") = txt_total_millar.Text
            dr("DataColumn26") = Combo_comentarios.Text
            dr("DataColumn27") = minombre
            dt.Rows.Add(dr)
        Next

        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "DS_reporte"
        Dim iDS As New DS_reporte
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS
    End Function

    Sub llenar_combo_codigo_de_barra()
        Combo_orden_de_compra.Items.Clear()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()
        SC2.Connection = conexion
        SC2.CommandText = "select codigo_barra from  codigos_de_barra where codigo_interno = '" & (txt_codigo.Text) & "' ORDER BY codigo_barra"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                Combo_orden_de_compra.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("codigo_barra"))
            Next
            conexion.Close()
        End If
        Combo_orden_de_compra.Items.Add("-")
        Combo_orden_de_compra.SelectedItem = "-"
        txt_cantidad_agregar.Focus()
    End Sub

    Private Sub Combo_familia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_orden_de_compra.SelectedIndexChanged
        txt_cantidad_agregar.Focus()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 6.5, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 6.5, FontStyle.Regular)
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

        e.Graphics.DrawString("ORDEN DE COMPRA", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 105, margen_izquierdo + 865, margen_superior + 105)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        'If txt_nombre_cliente.Text.Length > 23 Then
        '    txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 23)
        'End If

        e.Graphics.DrawString("NOMBRE", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 130)
        e.Graphics.DrawString("DIRECCION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 145)
        e.Graphics.DrawString("GIRO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 160)
        e.Graphics.DrawString("ORDEN DE COMPRA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 175)
        e.Graphics.DrawString("FECHA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 190)

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 170, margen_superior + 130)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 170, margen_superior + 145)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 170, margen_superior + 130)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 170, margen_superior + 175)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 170, margen_superior + 190)

        e.Graphics.DrawString(txt_nombre_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 180, margen_superior + 130)
        e.Graphics.DrawString(txt_direccion_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 180, margen_superior + 145)
        e.Graphics.DrawString(txt_giro_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 180, margen_superior + 160)
        e.Graphics.DrawString(txt_factura.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 180, margen_superior + 175)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 180, margen_superior + 190)

        e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 130)
        e.Graphics.DrawString("COMUNA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 145)
        e.Graphics.DrawString("TELEFONO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 160)
        e.Graphics.DrawString("CONDICIONES", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 175)
        e.Graphics.DrawString("ATENCION SEÑOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 190)

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 130)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 145)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 160)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 175)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 190)

        e.Graphics.DrawString(txt_rut_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 130)
        e.Graphics.DrawString(txt_comuna_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 145)
        e.Graphics.DrawString(txt_telefono.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 160)
        e.Graphics.DrawString(combo_condiciones.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 175)
        e.Graphics.DrawString(txt_representante.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 620, margen_superior + 190)

        e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 220)
        e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 100, margen_superior + 220)
        e.Graphics.DrawString("COD. BARRA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 310, margen_superior + 220)
        e.Graphics.DrawString("COSTO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 500, margen_superior + 220, format1)
        e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 570, margen_superior + 220, format1)
        e.Graphics.DrawString("SUBTOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 640, margen_superior + 220, format1)
        e.Graphics.DrawString("%", Font_titulo_columna, Brushes.Black, margen_izquierdo + 710, margen_superior + 220, format1)
        e.Graphics.DrawString("DESC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 780, margen_superior + 220, format1)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 850, margen_superior + 220, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 235, margen_izquierdo + 865, margen_superior + 235)

        Dim codigo_detalle As String
        Dim nombre_detalle As String
        Dim codigo_barra_detalle As String
        Dim costo_detalle As String
        Dim cantidad_detalle As String
        Dim subtotal_detalle As String
        Dim porcentaje_detalle As String
        Dim descuento_detalle As String
        Dim total_detalle As String
        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10

        For i = numero_lineas_total To grilla_detalle_venta.Rows.Count - 1
            codigo_detalle = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            nombre_detalle = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            codigo_barra_detalle = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            costo_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            porcentaje_detalle = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            descuento_detalle = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            If costo_detalle = "" Or costo_detalle = "0" Then
                costo_detalle = "0"
            Else
                costo_detalle = Format(Int(costo_detalle), "###,###,###")
            End If

            If cantidad_detalle = "" Or cantidad_detalle = "0" Then
                cantidad_detalle = "0"
            Else
                cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
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

            If nombre_detalle.Length > 20 Then
                nombre_detalle = nombre_detalle.Substring(0, 20)
            End If

            e.Graphics.DrawString(codigo_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(nombre_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 100, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(codigo_barra_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 310, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(costo_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 500, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(cantidad_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 570, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(subtotal_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 640, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(porcentaje_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 710, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(descuento_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 780, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(total_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 850, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 85 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 250 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 250 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 250 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 250 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0

        e.Graphics.DrawString("COMENTARIOS:", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 270 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(Combo_comentarios.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 280 + (numero_lineas * multiplicador_lineas))

        Dim rect_titulo_firma As New Rectangle(margen_izquierdo + 40, margen_superior + 210 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 280, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
        Dim rect_firma As New Rectangle(margen_izquierdo + 40, margen_superior + 260 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 280, margen_superior + 250 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString("FIRMA", Font_campos_superiores, Brushes.Black, rect_titulo_firma, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 390 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 300, margen_superior + 390 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(minombre, Font_campos_superiores, Brushes.Black, rect_firma, stringFormat)

        e.Graphics.DrawString("SUBTOTAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 315 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("% DESCUENTO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 330 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("DESCUENTO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 345 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("NETO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 360 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("IVA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 375 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("TOTAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 670, margen_superior + 390 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 315 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 330 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 345 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 360 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 375 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 760, margen_superior + 390 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString(txt_sub_total_millar.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 315 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(txt_porcentaje_desc.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 330 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(txt_desc_millar.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 345 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(txt_neto_millar.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 360 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(txt_iva_millar.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 375 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(txt_total_millar.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 860, margen_superior + 390 + (numero_lineas * multiplicador_lineas), format1)
    End Sub
End Class