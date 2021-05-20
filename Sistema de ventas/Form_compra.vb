Imports System.IO

Imports System.Drawing.Printing
Imports System.Math
Imports System.Drawing.Drawing2D

Public Class Form_Compra
    Dim total_registros As Integer
    Dim varnumfactura As Integer
    Dim peso As String
    Dim pesos As String
    Dim mifecha2 As String
    Dim mifecha4 As String
    ' Dim mifecha2 As String
    'Dim mifecha4 As String
    ' Dim mifecha6 As String
    Dim txt_factor_ingresar As String
    Private WithEvents Pd As New PrintDocument

    Private Sub Form_Compra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
        grabar_documento_temporal()
    End Sub

    Private Sub Form_Compra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim valormensaje As Integer
        'valormensaje = MsgBox("¿DESEA CERRAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CERRAR")
        'If valormensaje = vbNo Then
        '    e.Cancel = True
        'Else
        '    txt_margen_producto.Text = ""
        'End If
    End Sub

    Private Sub Form_Compra_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F11 Then
            combo_documento.Focus()
        End If

        If e.KeyCode = Keys.F2 Then
            txt_total.Focus()
        End If

        If e.KeyCode = Keys.F1 Then
            txt_codigo_producto.Focus()
        End If

        If e.KeyCode = Keys.F4 Then
            btn_buscar_productos.PerformClick()
        End If

        If e.KeyCode = Keys.F5 Then
            txt_rut_proveedor.Focus()
        End If

        If e.KeyCode = Keys.F6 Then
            btn_agregar_proveedor.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            btn_agregar_producto.PerformClick()
        End If

        If e.KeyCode = Keys.F8 Then
            txt_cantidad_agregar.Focus()
        End If

        If e.KeyCode = Keys.F9 Then
            btn_cargar.PerformClick()
        End If

        If e.KeyCode = Keys.F12 Then
            btn_grabar.PerformClick()
        End If

        If e.KeyCode = Keys.F11 Then
            combo_documento.Focus()
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
            '    form_Menu_admin.Enabled = False
            Form_menu_principal.Close()

        End If

    End Sub

    Private Sub Form_Compra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        controles(True, False)

        'TextBox1.Text = ActiveControl.Name

        'fecha()
        'fecha2()

        '   dtp_emision.CustomFormat = "yyy-MM-dd"
        dtp_ingreso.CustomFormat = "yyy-MM-dd"
        valores()
        'llenar_combo_rut()
        cargar_logo()
        limpiar_producto()
        cargar_compra_temporal()

        If Check_descuentos.Checked = True Then
            grilla_detalle.Columns(5).Visible = True
            grilla_detalle.Columns(6).Visible = True
            grilla_detalle.Columns(7).Visible = True
            ' grilla_detalle.Columns(8).Visible = True
        Else
            grilla_detalle.Columns(5).Visible = False
            grilla_detalle.Columns(6).Visible = False
            grilla_detalle.Columns(7).Visible = False
            ' grilla_detalle.Columns(8).Visible = False
        End If
        If Check_factor.Checked = True Then
            grilla_detalle.Columns(11).Visible = True
        Else
            grilla_detalle.Columns(11).Visible = False
        End If
        If Check_margen.Checked = True Then
            grilla_detalle.Columns(13).Visible = True
        Else
            grilla_detalle.Columns(13).Visible = False
        End If

        grilla_detalle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
        combo_documento.Focus()










        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from proveedores"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        If DS.Tables(DT.TableName).Rows.Count > 0 Then


            For i = 0 To DS.Tables(0).Rows.Count - 1
                col.Add(DS.Tables(0).Rows(i)("rut_proveedor").ToString())
            Next
            txt_rut_proveedor.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_rut_proveedor.AutoCompleteCustomSource = col
            txt_rut_proveedor.AutoCompleteMode = AutoCompleteMode.Suggest
        End If




        txt_rut_proveedor.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_rut_proveedor.AutoCompleteCustomSource = col
        txt_rut_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend


        conexion.Close()











        If grilla_detalle.Rows.Count = 0 Then
            controles(False, True)
            btn_modificar_doc.Enabled = False
            Form_cargar_compra.Show()
            Me.Enabled = False

        End If















    End Sub

    Sub desglose_factura()
        Dim iva As Long
        Dim neto As Long
        Dim total As Long
        total = 0
        If txt_total.Text = "" Then
            total = 0
        End If

        Try

            If txt_total.Text = "" Then
                total = 0
                neto = 0
                iva = 0
                txt_iva.Text = ""
                txt_neto.Text = ""

            End If

            total = txt_total.Text

            neto = (total / 1.19)
            iva = (neto) * 19 / 100

            txt_neto.Text = neto
            txt_iva.Text = iva

            If total = 0 Then
                txt_total.Text = ""
            End If


        Catch err As InvalidCastException

        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_emision.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub


    Sub fecha2()
        Dim mifecha As Date
        mifecha = dtp_ingreso.Text
        mifecha4 = mifecha.ToString("yyy-MM-dd")
    End Sub
    'permite crear el numero correlativo segun el documento que seleccionemos.
    Sub crear_codigo_compra()
        Dim VarNumCompra As Integer
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        Try
            SC.Connection = conexion
            SC.CommandText = "select max(codigo_compra) as codigo_compra from compra"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarNumCompra = DS.Tables(DT.TableName).Rows(0).Item("codigo_compra")
                txt_codigo_compra.Text = VarNumCompra + 1
            End If
        Catch err As InvalidCastException
            txt_codigo_compra.Text = 1
        End Try
        conexion.Close()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub
    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha2 se le entrega el formato de fecha indicado.
    'Sub fecha()
    '    Dim mifecha As Date
    '    mifecha = dtp_emision.Text
    '    mifecha2 = mifecha.ToString("yyy-MM-dd")
    'End Sub

    Sub crear_codigo_ingreso()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        Try
            SC.Connection = conexion
            SC.CommandText = "select max(codigo) as codigo from compra"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                lbl_ingreso.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo")
                lbl_ingreso.Text = varnumfactura + 1
            End If
        Catch err As InvalidCastException
            lbl_ingreso.Text = 1
        End Try
        conexion.Close()

    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha4 se le entrega el formato de fecha indicado.
    'Sub fecha2()
    '    Dim mifecha1 As Date
    '    mifecha1 = dtp2.Text
    '    mifecha4 = mifecha1.ToString("yyy-MM-dd")
    'End Sub

    'Sub fecha4()
    '    Dim mifecha2 As Date
    '    mifecha2 = dtp3.Text
    '    mifecha6 = mifecha2.ToString("yyy-MM-dd")
    'End Sub

    'limpia la pantalla.
    Sub limpiar()
        txt_cantidad_producto_anterior.Text = ""
        txt_codigo_producto.Text = ""
        txt_iva.Text = ""
        txt_neto.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_producto_anterior.Text = ""
        txt_telefono_proveedor.Text = ""
        txt_precio_unitario_producto.Text = ""
        txt_aplicacion.Text = ""
        'txt_ciudad.Text = ""


        txt_item.Text = ""
        txt_margen_anterior.Text = ""

        txt_rut_proveedor.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_nro_doc.Text = ""
        txt_total.Text = ""
        txt_descuento1.Text = ""
        'combo_documento.Items.Clear()
        'combo_documento.Items.Add("FACTURA")
        'combo_documento.Items.Add("GUIA")
        combo_documento.Text = ""
        txt_numero_tecnico_producto.Text = ""
        txt_precio_venta_producto.Text = ""
        txt_factor.Text = ""
        txt_costo_actual.Text = ""
        txt_total_producto.Text = ""
        txt_precio_venta_producto.Text = ""


        grilla_detalle.Rows.Clear()


        combo_documento.Enabled = True
        dtp_emision.Enabled = True
        txt_rut_proveedor.Enabled = True
        txt_nro_doc.Enabled = True
        txt_total.Enabled = True
        ' btn_modificar_doc.Enabled = falsse
    End Sub

    'limpia la informacion del producto.
    Sub limpiar_producto()
        txt_cantidad_producto_anterior.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_producto_anterior.Text = ""
        txt_codigo_producto.Text = ""
        txt_precio_venta_producto.Text = ""
        txt_numero_tecnico_producto.Text = ""
        txt_aplicacion.Text = ""
        txt_precio_unitario_producto.Text = ""
        txt_cantidad_etiquetas.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_costo_anterior.Text = ""
        txt_margen_anterior.Text = ""
        txt_costo_actual.Text = ""
        txt_total_producto.Text = ""

        If txt_descuento1.Text = "0" Then
            txt_descuento1.Text = ""
        End If

        If txt_descuento2.Text = "0" Then
            txt_descuento2.Text = ""
        End If

        If txt_descuento3.Text = "0" Then
            txt_descuento3.Text = ""
        End If

        'If txt_descuento4.Text = "0" Then
        '    txt_descuento4.Text = ""
        'End If


        If txt_costo_actual.Text = "NeuN" Then
            txt_costo_actual.Text = "0"
        End If

    End Sub

    Sub limpiar_producto_enter()
        txt_cantidad_producto_anterior.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_producto_anterior.Text = ""
        txt_factor.Text = ""
        txt_precio_venta_producto.Text = ""
        txt_numero_tecnico_producto.Text = ""
        txt_aplicacion.Text = ""
        txt_precio_unitario_producto.Text = ""
        txt_cantidad_etiquetas.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_costo_anterior.Text = ""
        txt_margen_anterior.Text = ""
        txt_costo_actual.Text = ""
        txt_total_producto.Text = ""

        If txt_descuento1.Text = "0" Then
            txt_descuento1.Text = ""
        End If

        If txt_descuento2.Text = "0" Then
            txt_descuento2.Text = ""
        End If

        If txt_descuento3.Text = "0" Then
            txt_descuento3.Text = ""
        End If

        'If txt_descuento4.Text = "0" Then
        '    txt_descuento4.Text = ""
        'End If


        If txt_costo_actual.Text = "NeuN" Then
            txt_costo_actual.Text = "0"
        End If

    End Sub


    Sub limpiar_proveedor()

        lbl_rut.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_telefono_proveedor.Text = ""
        'txt_ciudad.Text = ""
    End Sub

    Sub limpiar_proveedor_enter()


        txt_nombre_proveedor.Text = ""
        txt_telefono_proveedor.Text = ""
        'txt_ciudad.Text = ""
    End Sub

    'actualiza la tabla d elos proveedores.
    Sub actualizar_tabla_proveedores()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from proveedores"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    'actualiza la tabla de los productos.
    Sub actualizar_tabla_productos()
        conexion.Close()
        DS1.Tables.Clear()
        DT1.Rows.Clear()
        DT1.Columns.Clear()
        DS1.Clear()
        conexion.Open()

        SC1.Connection = conexion
        SC1.CommandText = "select * from productos"
        DA1.SelectCommand = SC1
        DA1.Fill(DT1)
        DS1.Tables.Add(DT1)

        conexion.Close()
    End Sub

    'se llena el combo rut.
    'Sub llenar_combo_rut()
    '    DS2.Tables.Clear()
    '    DT2.Rows.Clear()
    '    DT2.Columns.Clear()
    '    DS2.Clear()
    '    conexion.Open()

    '    SC2.Connection = conexion
    '    SC2.CommandText = "select * from proveedores where rut_proveedor <> 'TODOS'"
    '    DA2.SelectCommand = SC2
    '    DA2.Fill(DT2)
    '    DS2.Tables.Add(DT2)

    '    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
    '            txt_rut_proveedor.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("rut_proveedor"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    'muestra los datos de los proveedores.
    Sub mostrar_datos_proveedores()
        'If Combo_rut.Text <> "" Then
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut_proveedor.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
            txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            txt_telefono_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_proveedor")
            'txt_ciudad.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_proveedor")
            txt_codigo_producto.Focus()
        Else
            '     MsgBox("RUT NO ENCONTRADO", 0 + 16, "ERROR")
            txt_rut_proveedor.Focus()
        End If
        conexion.Close()
        ' End If
    End Sub

    Sub mostrar_datos_proveedores_combo()
        If txt_rut_proveedor.Text <> "" Then
            limpiar_proveedor()
            '            conexion.Close()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
                txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
                txt_telefono_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_proveedor")
            End If
            conexion.Close()
        End If
    End Sub

    'muestra los datos de los productos.
    Sub mostrar_datos_productos()
        Dim cantidad_caracteres As Integer

        If txt_codigo_producto.Text <> "" Then
            cantidad_caracteres = Len(txt_codigo_producto.Text)
            If cantidad_caracteres <= 6 Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_producto.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                Try
                    If DS.Tables(DT.TableName).Rows.Count > 0 Then
                        txt_codigo_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("COD_PRODUCTO")
                        txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                        txt_numero_tecnico_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                        txt_cantidad_producto_anterior.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                        txt_precio_producto_anterior.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                        txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                        txt_costo_anterior.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                        txt_margen_anterior.Text = DS.Tables(DT.TableName).Rows(0).Item("margen")
                        txt_medida.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_medida")

                        If Radio_precio_venta.Checked = True Then
                            txt_precio_venta_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                        End If

                        txt_cantidad_agregar.Focus()

                    ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                        Dim valormensaje As Integer
                        valormensaje = MsgBox("CODIGO NO ENCONTRADO ¿DESDEA INGRESARLO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

                        If valormensaje = vbYes Then
                            Form_registro_productos_compra.Show()
                            Form_registro_productos_compra.btn_nuevo.PerformClick()

                            Form_registro_productos_compra.txt_codigo.Text = Me.txt_codigo_producto.Text

                            Form_registro_productos_compra.txt_codigo.Focus()


                        End If
                    End If
                Catch
                End Try
                conexion.Close()
            Else
                If txt_codigo_producto.Text <> "" Then
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    SC.Connection = conexion
                    SC.CommandText = "select * from productos where codigo_barra ='" & (txt_codigo_producto.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    DS.Tables.Add(DT)

                    Try
                        If DS.Tables(DT.TableName).Rows.Count > 0 Then
                            txt_codigo_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                            txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                            txt_numero_tecnico_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                            txt_cantidad_producto_anterior.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                            txt_precio_producto_anterior.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                            txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                            txt_costo_anterior.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                            txt_margen_anterior.Text = DS.Tables(DT.TableName).Rows(0).Item("margen")

                            If Radio_precio_venta.Checked = True Then
                                txt_precio_venta_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                            End If

                            txt_cantidad_agregar.Focus()
                        ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                            MsgBox("CODIGO NO ENCONTRADO", 0 + 16, "ERROR")
                            txt_codigo_producto.Focus()
                        End If
                    Catch
                    End Try
                    conexion.Close()
                End If
            End If
        End If
    End Sub

    Sub grabar_documento_temporal()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim VarCantidad As String
        Dim VarPrecioUnitario As String
        Dim VarCosto As String
        Dim VarDescuento As String
        Dim VarDescuento2 As String
        Dim VarDescuento3 As String
        '  Dim VarDescuento4 As String
        Dim VarNeto As String
        Dim VarIva As String
        Dim VarTotal As String
        Dim varFactor As String
        Dim VarPrecioVenta As String
        Dim VarMargen As String
        Dim VarEstado As String

        Dim VarMargenAnterior As String
        Dim VarPrecioAnterior As String


        If grilla_detalle.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim r_margen As String
        Dim r_neto As String

        If Radio_margen.Checked = True Then
            r_margen = "SELECCIONADO"
        Else
            r_margen = "NO SELECCIONADO"
        End If

        If Radio_neto.Checked = True Then
            r_neto = "SELECCIONADO"
        Else
            r_neto = "NO SELECCIONADO"
        End If

        For i = 0 To grilla_detalle.Rows.Count - 1

            VarCodProducto = grilla_detalle.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle.Rows(i).Cells(1).Value.ToString
            VarCantidad = grilla_detalle.Rows(i).Cells(2).Value.ToString
            VarPrecioUnitario = grilla_detalle.Rows(i).Cells(3).Value.ToString
            VarCosto = grilla_detalle.Rows(i).Cells(4).Value.ToString
            VarDescuento = grilla_detalle.Rows(i).Cells(5).Value.ToString
            VarDescuento2 = grilla_detalle.Rows(i).Cells(6).Value.ToString
            VarDescuento3 = grilla_detalle.Rows(i).Cells(7).Value.ToString
            VarNeto = grilla_detalle.Rows(i).Cells(8).Value.ToString
            VarIva = grilla_detalle.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle.Rows(i).Cells(10).Value.ToString
            varFactor = grilla_detalle.Rows(i).Cells(11).Value.ToString
            VarPrecioVenta = grilla_detalle.Rows(i).Cells(12).Value.ToString
            VarMargen = grilla_detalle.Rows(i).Cells(13).Value.ToString
            VarEstado = grilla_detalle.Rows(i).Cells(14).Value.ToString


            VarPrecioAnterior = grilla_detalle.Rows(i).Cells(15).Value.ToString
            VarMargenAnterior = grilla_detalle.Rows(i).Cells(16).Value.ToString


            SC.Connection = conexion
            SC.CommandText = "insert into documento_temporal_compras (cod_producto, nombre, cantidad, valor_unitario, descuento, descuento_2, descuento_3, neto, iva, total, factor, precio_venta, margen, rut_proveedor, total_documento, tipo_documento,  numero_documento,precio_unitario, fecha_emision, campo_descuento, campo_descuento2, campo_descuento3, radio_margen,  radio_neto, usuario, estado_ingreso, codigo_compra, precio_anterior, margen_anterior) values( '" & (VarCodProducto) & "','" & (varnombre) & "','" & (VarCantidad) & "','" & (VarCosto) & "','" & (VarDescuento) & "','" & (VarDescuento2) & "','" & (VarDescuento3) & "','" & (VarNeto) & "', '" & (VarIva) & "','" & (VarTotal) & "','" & (varFactor) & "','" & (VarPrecioVenta) & "','" & (VarMargen) & "','" & (txt_rut_proveedor.Text) & "','" & (txt_total.Text) & "', '" & (combo_documento.Text) & "', '" & (txt_nro_doc.Text) & "', '" & (VarPrecioUnitario) & "', '" & (dtp_emision.Text) & "', '" & (txt_descuento1.Text) & "', '" & (txt_descuento2.Text) & "', '" & (txt_descuento3.Text) & "','" & (r_margen) & "','" & (r_neto) & "','" & (miusuario) & "','" & (VarEstado) & "','" & (txt_codigo_compra.Text) & "','" & (VarPrecioAnterior) & "','" & (VarMargenAnterior) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

        Next
    End Sub

    Sub cargar_compra_temporal()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select cod_producto, nombre, cantidad, precio_unitario, valor_unitario, descuento, descuento_2, descuento_3, neto, iva, total, factor, precio_venta, margen, rut_proveedor, total_documento, tipo_documento, numero_documento, fecha_emision, fecha_emision, campo_descuento, campo_descuento2, campo_descuento3,campo_descuento4, radio_margen, radio_neto, estado_ingreso, codigo_compra, precio_anterior, margen_anterior from documento_temporal_compras where usuario='" & (miusuario) & "' "
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_detalle.Rows.Clear()

        Dim r_margen As String
        Dim r_neto As String

        '    Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim cod_producto As String = ""
                Dim tipo_medida As String = ""

                cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

                conexion.Close()
                DS2.Tables.Clear()
                DT2.Rows.Clear()
                DT2.Columns.Clear()
                DS2.Clear()
                conexion.Open()
                SC2.Connection = conexion
                SC2.CommandText = "select * from productos where cod_producto ='" & (cod_producto) & "'"
                DA2.SelectCommand = SC2
                DA2.Fill(DT2)
                DS2.Tables.Add(DT2)
                If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                    tipo_medida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                End If
                conexion.Close()

                grilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD_PRODUCTO"), _
                                         DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                          DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("PRECIO_UNITARIO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("VALOR_UNITARIO"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO_2"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO_3"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("NETO"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("IVA"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("FACTOR"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("PRECIO_venta"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("MARGEN"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("estado_ingreso"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("precio_anterior"), _
                                                        tipo_medida, _
                                                         DS.Tables(DT.TableName).Rows(i).Item("margen_anterior"))

            Next
            txt_codigo_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_compra")
            r_margen = DS.Tables(DT.TableName).Rows(0).Item("radio_margen")
            r_neto = DS.Tables(DT.TableName).Rows(0).Item("radio_neto")
            txt_descuento1.Text = DS.Tables(DT.TableName).Rows(0).Item("campo_descuento")
            txt_descuento2.Text = DS.Tables(DT.TableName).Rows(0).Item("campo_descuento2")
            txt_descuento3.Text = DS.Tables(DT.TableName).Rows(0).Item("campo_descuento3")
            'txt_descuento4.Text = DS.Tables(DT.TableName).Rows(0).Item("campo_descuento4")
            dtp_emision.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_emision")
            txt_nro_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_documento")
            combo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_documento")
            txt_total.Text = DS.Tables(DT.TableName).Rows(0).Item("total_documento")
            txt_rut_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")

            If r_margen = "SELECCIONADO" Then
                Radio_margen.Checked = True
            Else
                Radio_precio_venta.Checked = True
            End If

            If r_neto = "SELECCIONADO" Then
                Radio_neto.Checked = True
            Else
                Radio_iva.Checked = True
            End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "delete from documento_temporal_compras where usuario='" & (miusuario) & "'"
            DA.Fill(DT)
            conexion.Close()
        End If


        Dim estado_ingreso As String

        For i = 0 To grilla_detalle.Rows.Count - 1
            estado_ingreso = grilla_detalle.Rows(i).Cells(14).Value.ToString
            If estado_ingreso = "INGRESADO" Then
                grilla_detalle.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
            End If
        Next

    End Sub

    'permite bloquear o desbloquear los controles.
    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        dtp_emision.Enabled = a
        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a
        btn_grabar.Enabled = a
        btn_limpiar.Enabled = a
        btn_agregar_producto.Enabled = a
        btn_agregar_proveedor.Enabled = a
        btn_cargar.Enabled = a
        btn_nueva.Enabled = b
        btn_buscar_productos.Enabled = a

        '  btn_modificar_doc.Enabled = a
        'btn_cargar_transporte.Enabled = a

        txt_cantidad_etiquetas.Enabled = a

        txt_item.Enabled = a
        lbl_item.Enabled = a

        GroupBox_tipo.Enabled = a

        txt_nro_doc.Enabled = a

        txt_costo_actual.Enabled = a

        txt_total_producto.Enabled = a

        txt_cantidad_agregar.Enabled = a
        txt_precio_venta_producto.Enabled = a
        txt_descuento1.Enabled = a
        txt_descuento2.Enabled = a
        txt_descuento3.Enabled = a
        'txt_descuento4.Enabled = a
        txt_rut_proveedor.Enabled = a
        txt_codigo_producto.Enabled = a
        txt_neto.Enabled = a
        txt_iva.Enabled = a
        txt_total.Enabled = a
        txt_precio_venta_producto.Enabled = a
        txt_precio_unitario_producto.Enabled = a
        txt_factor.Enabled = a

        Check_descuentos.Enabled = a
        Check_factor.Enabled = a
        Check_margen.Enabled = a

        combo_documento.Enabled = a
        dtp_emision.Enabled = a
        Radio_margen.Enabled = a
        Radio_precio_venta.Enabled = a
        grilla_detalle.Enabled = a

        GroupBox_descuento.Enabled = a
        GroupBox_documento.Enabled = a
        GroupBox_ingreso.Enabled = a
        GroupBox_producto.Enabled = a
        GroupBox_proveedor.Enabled = a
        GroupBox_tipo_precio.Enabled = a
        GroupBox_totales.Enabled = a

        GroupBox_columnas.Enabled = a
        GroupBox_valores.Enabled = a
        'GroupBox_etiquetas.Enabled = a

        Radio_neto.Checked = True
        Radio_margen.Checked = True

        'If txt_rut_proveedor.Enabled = True Then
        '    txt_rut_proveedor.BackColor = Color.White
        'Else
        '    txt_rut_proveedor.BackColor = SystemColors.Control
        'End If

        'If txt_nro_doc.Enabled = True Then
        '    txt_nro_doc.BackColor = Color.White
        'Else
        '    txt_nro_doc.BackColor = SystemColors.Control
        'End If

        'If txt_cantidad_agregar.Enabled = True Then
        '    txt_cantidad_agregar.BackColor = Color.White
        'Else
        '    txt_cantidad_agregar.BackColor = SystemColors.Control
        'End If

        'If txt_precio_venta_producto.Enabled = True Then
        '    txt_precio_venta_producto.BackColor = Color.White
        'Else
        '    txt_precio_venta_producto.BackColor = SystemColors.Control
        'End If

        'If txt_descuento1.Enabled = True Then
        '    txt_descuento1.BackColor = Color.White
        'Else
        '    txt_descuento1.BackColor = SystemColors.Control
        'End If

        'If txt_descuento2.Enabled = True Then
        '    txt_descuento2.BackColor = Color.White
        'Else
        '    txt_descuento2.BackColor = SystemColors.Control
        'End If

        'If txt_descuento3.Enabled = True Then
        '    txt_descuento3.BackColor = Color.White
        'Else
        '    txt_descuento3.BackColor = SystemColors.Control
        'End If

        'If txt_descuento4.Enabled = True Then
        '    txt_descuento4.BackColor = Color.White
        'Else
        '    txt_descuento4.BackColor = SystemColors.Control
        'End If

        'If txt_rut_proveedor.Enabled = True Then
        '    txt_rut_proveedor.BackColor = Color.White
        'Else
        '    txt_rut_proveedor.BackColor = SystemColors.Control
        'End If

        'If txt_codigo_producto.Enabled = True Then
        '    txt_codigo_producto.BackColor = Color.White
        'Else
        '    txt_codigo_producto.BackColor = SystemColors.Control
        'End If

        'If txt_total.Enabled = True Then
        '    txt_total.BackColor = Color.White
        'Else
        '    txt_total.BackColor = SystemColors.Control
        'End If

        'If txt_cantidad_etiquetas.Enabled = True Then
        '    txt_cantidad_etiquetas.BackColor = Color.White
        'Else
        '    txt_cantidad_etiquetas.BackColor = SystemColors.Control
        'End If

        'If combo_documento.Enabled = True Then
        '    combo_documento.BackColor = Color.White
        'Else
        '    combo_documento.BackColor = SystemColors.Control
        'End If

        'If txt_precio_venta_producto.Enabled = True Then
        '    txt_precio_venta_producto.BackColor = Color.White
        'Else
        '    txt_precio_venta_producto.BackColor = SystemColors.Control
        'End If

        'If txt_precio_unitario_producto.Enabled = True Then
        '    txt_precio_unitario_producto.BackColor = Color.White
        'Else
        '    txt_precio_unitario_producto.BackColor = SystemColors.Control
        'End If

    End Sub

    'se limpian los datos.
    'se habilitan controles.
    'se llena el combo documento.
    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
        '  controles(True, False)

        btn_modificar_doc.Enabled = False

        txt_precio_venta_producto.BackColor = SystemColors.Control
        combo_documento.Focus()

        conexion.Close()


        Form_cargar_compra.Show()
        Me.Enabled = False
    End Sub

    Private Sub combo_codigo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_datos_productos()
        txt_cantidad_agregar.Enabled = True
        txt_descuento1.Enabled = True
        btn_agregar.Enabled = True
        btn_quitar_elemento.Enabled = True
    End Sub


    Sub datos_producto_venta()
        Dim desc As Long
        Dim desc2 As Long
        Dim desc3 As Long
        'Dim desc4 As Long
        'Dim iva As Integer
        Dim neto As Integer

        If txt_descuento1.Text = "" Then
            txt_descuento1.Text = "0"
        End If

        If txt_descuento2.Text = "" Then
            txt_descuento2.Text = "0"
        End If

        If txt_descuento3.Text = "" Then
            txt_descuento3.Text = "0"
        End If
        'If txt_descuento4.Text = "" Then
        '    txt_descuento4.Text = "0"
        'End If

        If txt_precio_unitario_producto.Text = "" Then
            txt_precio_unitario_producto.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_factor.Text = "" Then
            txt_factor.Text = "0"
        End If



        If txt_costo_actual.Text = "" Then
            txt_costo_actual.Text = "0"
        End If

        If txt_total_producto.Text = "" Then
            txt_total_producto.Text = "0"
        End If


        If txt_costo_actual.Text = "NeuN" Then
            txt_costo_actual.Text = "0"
        End If

        If txt_total_producto.Text = "NeuN" Then
            txt_total_producto.Text = "0"
        End If

        If IsNumeric(txt_descuento1.Text) = False Then
            txt_descuento1.Text = "0"
        End If


        If IsNumeric(txt_descuento2.Text) = False Then
            txt_descuento2.Text = "0"
        End If

        If IsNumeric(txt_descuento3.Text) = False Then
            txt_descuento3.Text = "0"
        End If

        'If IsNumeric(txt_descuento4.Text) = False Then
        '    txt_descuento4.Text = "0"
        'End If


        If txt_cantidad_agregar.Text = "NeuN" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If IsNumeric(txt_cantidad_agregar.Text) = False Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "Infinito" Then
            txt_cantidad_agregar.Text = "0"
        End If





        If txt_precio_unitario_producto.Text = "NeuN" Then
            txt_precio_unitario_producto.Text = "0"
        End If

        If IsNumeric(txt_precio_unitario_producto.Text) = False Then
            txt_precio_unitario_producto.Text = "0"
        End If

        If txt_precio_unitario_producto.Text = "Infinito" Then
            txt_precio_unitario_producto.Text = "0"
        End If



        desc = ((txt_precio_unitario_producto.Text * txt_cantidad_agregar.Text) * txt_descuento1.Text) / 100
        desc2 = ((txt_precio_unitario_producto.Text * txt_cantidad_agregar.Text - desc) * txt_descuento2.Text) / 100
        desc3 = (((txt_precio_unitario_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) * txt_descuento3.Text) / 100
        ' desc4 = (((((txt_precio_unitario_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) - desc3) * txt_descuento4.Text) / 100)
        neto = (((((txt_cantidad_agregar.Text * txt_precio_unitario_producto.Text) - desc) - desc2) - desc3))

        txt_costo_actual.Text = Round((neto / Int(txt_cantidad_agregar.Text)))

        If txt_costo_actual.Text = "NeuN" Then
            txt_costo_actual.Text = "0"
        End If

        txt_total_producto.Text = Round(neto)

        If Radio_margen.Checked = True Then
            Dim valor_iva_margen As String
            Dim precio_venta As Integer
            Dim margen As String
            Dim factor As Decimal
            Try

                valor_iva_margen = valor_iva / 100 + 1

                precio_venta = (txt_costo_actual.Text) * (valor_iva_margen)
                If txt_precio_venta_producto.Text = "" Then
                    txt_precio_venta_producto.Text = 0
                End If
                If txt_precio_venta_producto.Text <> 0 Then
                    margen = txt_precio_venta_producto.Text
                    margen = margen / 100
                    margen = margen + 1
                    precio_venta = (precio_venta) * (margen)
                Else
                    margen = 0
                End If

            Catch err As InvalidCastException
                MsgBox("VERIFIQUE EL MARGEN INGRESADO", 0 + 16, "ERROR")
                txt_precio_venta_producto.Focus()
                Exit Sub
            End Try

            factor = precio_venta / valor_factor
            txt_factor.Text = factor.ToString("##,00.00")
            '      txt_factor_ingresar = factor_ingresar
        End If


        If txt_costo_actual.Text = "" Then
            txt_costo_actual.Text = "0"
        End If

        If txt_total_producto.Text = "" Then
            txt_total_producto.Text = "0"
        End If


        If txt_costo_actual.Text = "NeuN" Then
            txt_costo_actual.Text = "0"
        End If

        If txt_total_producto.Text = "NeuN" Then
            txt_total_producto.Text = "0"
        End If
    End Sub








    'agrega los productos a la grilla para grabarlos al stock.
    Private Sub btn_agregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        'Dim desc As Integer
        'Dim desc2 As Integer
        'Dim desc3 As Integer
        'Dim desc4 As Integer
        ' Dim iva As Integer
        ' Dim neto As Integer
        ' Dim subtotal As Integer
        'Dim total As Integer
        Dim codigo As String
        ' Dim cantidad As Integer
        ' Dim saldo As Integer
        'Dim factor As Decimal
        '  Dim precioventa As Decimal
        ' Dim factor_ingresar As Decimal
        ' Dim precio_venta As Integer
        '  Dim mensaje As String = ""
        '  Dim margen As String
        Dim iva_valor As String
        'Dim costo_producto As Integer
        ' Dim cantidad_etiquetas As Integer

        If txt_codigo_producto.Text = "" Then
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo_producto.Focus()
            Exit Sub
        End If

        If txt_precio_unitario_producto.Text = "" Or txt_precio_unitario_producto.Text = "0" Then
            MsgBox("CAMPO COSTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_precio_unitario_producto.Focus()
            Exit Sub
        End If

        If txt_nombre_producto.Text = "" Then
            MsgBox("CAMPO NOMBRE PRODUCTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_producto.Focus()
            Exit Sub
        End If

        If Radio_margen.Checked = True Then
            If txt_precio_venta_producto.Text = "" Or txt_precio_venta_producto.Text = "0" Then
                MsgBox("CAMPO MARGEN VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_precio_venta_producto.Focus()
                Exit Sub
            End If
        End If

        If Radio_precio_venta.Checked = True Then
            If txt_precio_venta_producto.Text = "" Or txt_precio_venta_producto.Text = "0" Then
                MsgBox("CAMPO PRECIO VENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_precio_venta_producto.Focus()
                Exit Sub
            End If
        End If

        If txt_cantidad_agregar.Text = "" Then
            MsgBox("CAMPO CANTIDAD A AGREGAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = "0" Then
            MsgBox("CAMPO CANTIDAD A AGREGAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If


        iva_valor = valor_iva / 100 + 1

        '  If Radio_precio_venta.Checked = True Then

        If txt_descuento1.Text = "" Then
            txt_descuento1.Text = "0"
        End If

        If txt_descuento2.Text = "" Then
            txt_descuento2.Text = "0"
        End If

        If txt_descuento3.Text = "" Then
            txt_descuento3.Text = "0"
        End If

        'If txt_descuento4.Text = "" Then
        '    txt_descuento4.Text = "0"
        'End If

        If txt_cantidad_producto_anterior.Text = "" Then
            txt_cantidad_producto_anterior.Text = "0"
        End If




        For i = 0 To grilla_detalle.Rows.Count - 1
            Dim valor As Integer = 6
            ' codigo = grilla_detalle.Rows(i).Cells(0).Value
            codigo = grilla_detalle.Rows(i).Cells(0).Value.ToString

            codigo = String.Format("{0:000000}", codigo)
            If codigo = txt_codigo_producto.Text Then
                ' grilla_detalle.Rows.Remove(grilla_detalle.Rows(i))

                Dim VarEstado As String
                ' If grilla_detalle.Rows.Count > 0 Then


                Dim valormensaje As Integer
                valormensaje = MsgBox("EL PRODUCTO DIGITADO YA FUE AGREGADO A LA MALLA ¿ESTA SEGURO DE REEMPLAZARLO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

                If valormensaje = vbNo Then
                    Exit Sub
                End If

                If valormensaje = vbYes Then





                    VarEstado = grilla_detalle.Rows(i).Cells(14).Value.ToString
                    If VarEstado = "SIN INGRESAR" Then

                        ' grilla_detalle.Rows.Remove(grilla_detalle.CurrentRow)

                        grilla_detalle.Rows.Remove(grilla_detalle.Rows(i))
                        'btn_agregar.PerformClick()
                        'txt_cantidad_etiquetas.Focus()
                        '   Exit Sub
                    End If


                    If VarEstado = "INGRESADO" Then

                        'Dim valormensaje As Integer
                        'valormensaje = MsgBox("EL PRODUCTO SELECCIONADO YA FUE INGRESADO AL SISTEMA ¿ESTA SEGURO DE ELIMINAR EL MOVIMIENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

                        'If valormensaje = vbYes Then
                        Dim Var_codigo_producto_eliminar As String
                        Dim Var_cantidad_producto_eliminar As String
                        Dim Var_codigo_auto_eliminar As String
                        Dim Var_medida_eliminar As String

                        ' Var_codigo_producto_eliminar = grilla_detalle.CurrentRow.Cells(0).Value
                        Var_codigo_producto_eliminar = grilla_detalle.Rows(i).Cells(0).Value
                        'Var_cantidad_producto_eliminar = grilla_detalle.CurrentRow.Cells(2).Value
                        Var_cantidad_producto_eliminar = grilla_detalle.Rows(i).Cells(2).Value

                        Var_medida_eliminar = grilla_detalle.Rows(i).Cells(17).Value

                        Var_codigo_auto_eliminar = grilla_detalle.Rows(i).Cells(18).Value

                        SC.Connection = conexion
                        SC.CommandText = "delete from detalle_compra where n_compra = '" & (txt_nro_doc.Text) & "' AND rut_proveedor = '" & (txt_rut_proveedor.Text) & "' and cod_producto= '" & (Var_codigo_producto_eliminar) & "'"
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                        If Var_medida_eliminar = "DECIMAL" Then



                            Dim cantidad_decimal As String = ""
                            conexion.Close()
                            DS.Tables.Clear()
                            DT.Rows.Clear()
                            DT.Columns.Clear()
                            DS.Clear()
                            conexion.Open()
                            SC.Connection = conexion
                            SC.CommandText = "select * from productos where cod_producto ='" & (Var_codigo_producto_eliminar) & "'"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                            DS.Tables.Add(DT)
                            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                                cantidad_decimal = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                            End If
                            conexion.Close()

                            cantidad_decimal = Val(cantidad_decimal) - Val(Var_cantidad_producto_eliminar)

                            SC.Connection = conexion
                            SC.CommandText = "update productos set cantidad = '" & (cantidad_decimal) & "' where cod_producto = '" & (Var_codigo_producto_eliminar) & "'"
                            DA.SelectCommand = SC
                            DA.Fill(DT)

                        Else
                            SC.Connection = conexion
                            SC.CommandText = "update productos set cantidad = cantidad - " & (Var_cantidad_producto_eliminar) & " where cod_producto = '" & (Var_codigo_producto_eliminar) & "'"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                        End If

                        SC.Connection = conexion
                        SC.CommandText = "delete from detalle_total where n_total='" & (txt_nro_doc.Text) & "'  AND rut_proveedor = '" & (txt_rut_proveedor.Text) & "' and movimiento='ENTRA' AND cod_producto='" & (Var_codigo_producto_eliminar) & "' "
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        conexion.Close()

                        ' grilla_detalle.Rows.Remove(grilla_detalle.CurrentRow)
                        grilla_detalle.Rows.Remove(grilla_detalle.Rows(i))
                        ' txt_codigo_producto.Focus()
                    End If



                    agregar_compra()
                    imprimir_etiquetas()



                    txt_cantidad_agregar.Text = 0
                    limpiar_producto()
                    txt_item.Text = grilla_detalle.Rows.Count
                    txt_codigo_producto.Focus()
                    'Else


                    '    MsgBox("DEBE INGRESAR UNA CANTIDAD", 0 + 16, "ERROR")


                    If mirutempresa = "81921000-4" Then
                        calcular_totales()
                    End If




                    Exit Sub
                End If








            End If


            '  End If
            ' End If
            ' Exit Sub
        Next
        '  End If







        agregar_compra()













        imprimir_etiquetas()








        If mirutempresa = "81921000-4" Then
            calcular_totales()
        End If








        txt_cantidad_agregar.Text = 0
        'calcular_totales()
        limpiar_producto()
        txt_item.Text = grilla_detalle.Rows.Count
        txt_codigo_producto.Focus()


        combo_documento.Enabled = True


    End Sub

    Sub agregar_compra()

        Dim desc As Integer
        Dim desc2 As Integer
        Dim desc3 As Integer
        '  Dim desc4 As Integer
        Dim iva As Integer
        Dim neto As Integer
        ' Dim subtotal As Integer
        Dim total As Integer
        ' Dim codigo As String
        'Dim cantidad As Integer
        'Dim saldo As Integer
        Dim factor As Decimal
        '  Dim precioventa As Decimal
        Dim factor_ingresar As Decimal
        Dim precio_venta As Integer
        '  Dim mensaje As String = ""
        Dim margen As String
        Dim iva_valor As String
        Dim costo_producto As Integer
        'Dim cantidad_etiquetas As Integer

        iva_valor = valor_iva / 100 + 1

        desc = ((txt_precio_unitario_producto.Text * txt_cantidad_agregar.Text) * txt_descuento1.Text) / 100
        desc2 = ((txt_precio_unitario_producto.Text * txt_cantidad_agregar.Text - desc) * txt_descuento2.Text) / 100
        desc3 = (((txt_precio_unitario_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) * txt_descuento3.Text) / 100
        '  Desc4 = (((((txt_precio_unitario_producto.Text * txt_cantidad_agregar.Text - desc) - Desc2) - Desc3) * txt_descuento4.Text) / 100)
        neto = (((((txt_cantidad_agregar.Text * txt_precio_unitario_producto.Text) - desc) - desc2) - desc3))

        If Radio_neto.Checked = True Then
            neto = (txt_cantidad_agregar.Text * txt_precio_unitario_producto.Text)
            Round(neto)
            neto = (((((neto) - desc) - desc2) - desc3))
            Round(neto)
            iva = (neto * valor_iva) / 100
            Round(iva)
            total = iva + neto
            Round(total)
            costo_producto = (neto / txt_cantidad_agregar.Text)
            Round(costo_producto)
        End If

        If Radio_iva.Checked = True Then
            neto = (txt_precio_unitario_producto.Text / iva_valor)
            Round(neto)
            iva = ((neto) * valor_iva / 100)
            Round(iva)
            total = iva + neto
            Round(total)

            neto = (neto * txt_cantidad_agregar.Text)
            Round(neto)
            iva = (iva * txt_cantidad_agregar.Text)
            Round(iva)
            total = (total * txt_cantidad_agregar.Text)
            Round(total)

            total = (((((total) - desc) - desc2) - desc3))
            Round(total)
            neto = (total / iva_valor)
            Round(neto)
            iva = ((neto) * valor_iva / 100)
            Round(iva)
            costo_producto = (neto / txt_cantidad_agregar.Text)
            Round(costo_producto)
        End If


        If Radio_margen.Checked = True Then
            Try
                Dim valor_iva_margen As String
                valor_iva_margen = valor_iva / 100 + 1

                precio_venta = (costo_producto) * (valor_iva_margen)

                If txt_precio_venta_producto.Text <> 0 Then
                    margen = txt_precio_venta_producto.Text / 100
                    margen = margen + 1
                    precio_venta = (precio_venta) * (margen)
                End If

            Catch err As InvalidCastException
                MsgBox("VERIFIQUE EL MARGEN INGRESADO", 0 + 16, "ERROR")
                txt_precio_venta_producto.Focus()
                Exit Sub
            End Try

            factor = precio_venta / valor_factor
            factor_ingresar = factor.ToString("##,000.00")
            txt_factor_ingresar = factor_ingresar
        End If


        If Radio_precio_venta.Checked = True Then
            txt_factor_ingresar = "0"
            '   txt_precio_venta_producto.Text = 0
            precio_venta = txt_precio_venta_producto.Text
        End If




        If Radio_margen.Checked = False Then
            margen = 0
        Else
            margen = txt_precio_venta_producto.Text
        End If



        grilla_detalle.Rows.Add(txt_codigo_producto.Text, txt_nombre_producto.Text, txt_cantidad_agregar.Text, txt_precio_unitario_producto.Text, costo_producto, desc, desc2, desc3, neto, iva, total, txt_factor_ingresar, precio_venta, margen, "SIN INGRESAR", txt_precio_producto_anterior.Text, txt_margen_anterior.Text, txt_medida.Text)





    End Sub

    Sub imprimir_etiquetas()
        Dim cantidad_etiquetas As Integer

        If txt_cantidad_etiquetas.Text = "0" Or txt_cantidad_etiquetas.Text = "" Then
            cantidad_etiquetas = 0
        Else
            cantidad_etiquetas = txt_cantidad_etiquetas.Text
        End If

        If cantidad_etiquetas <> "0" Then


            With Pd.PrinterSettings
                ' Especifico el nombre de la impresora 
                ' por donde deseo imprimir. 

                If Radio_impresora_1.Checked = True Then
                    .PrinterName = impresora_etiquetas
                Else
                    .PrinterName = impresora_etiquetas_2
                End If



                'If Radio_impresora_1.Checked = True Then
                '    .PrinterName = "ZDesigner LP 2824"
                'Else
                '    .PrinterName = "ZDesigner LP 2824"
                'End If
                ' Establezco el número de copias que se imprimirán 

                .Copies = cantidad_etiquetas
                ' Rango de páginas que se imprimirán 
                .PrintRange = PrintRange.AllPages
                If .IsValid Then
                    Me.Pd.PrintController = New StandardPrintController
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 300, 99)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                    Pd.Print()
                Else
                End If
            End With

        End If
    End Sub

    'se calcula el neto, el iva, el total y descuento del documento.
    'Sub calcular_totales()
    '    Dim descgrilla As Integer
    '    Dim netogrilla As Integer
    '    Dim ivagrilla As Integer
    '    Dim totalgrilla As Integer
    '    ' Dim subtotalgrilla As Integer

    '    '//Calcular el descuento
    '    txt_desc_1.Text = 0
    '    For i = 0 To grilla_detalle.Rows.Count - 1
    '        descgrilla = Val(grilla_detalle.Rows(i).Cells(4).Value.ToString)
    '        txt_desc_1.Text = Val(txt_desc_4.Text) + Val(descgrilla)
    '    Next

    '    '//Calcular el descuento 2
    '    txt_desc_2.Text = 0
    '    For i = 0 To grilla_detalle.Rows.Count - 1
    '        descgrilla = Val(grilla_detalle.Rows(i).Cells(5).Value.ToString)
    '        txt_desc_2.Text = Val(txt_desc_4.Text) + Val(descgrilla)
    '    Next
    '    '//Calcular el descuento 3
    '    txt_desc_3.Text = 0
    '    For i = 0 To grilla_detalle.Rows.Count - 1
    '        descgrilla = Val(grilla_detalle.Rows(i).Cells(6).Value.ToString)
    '        txt_desc_3.Text = Val(txt_desc_4.Text) + Val(descgrilla)
    '    Next
    '    '//Calcular el descuento 4
    '    txt_desc_4.Text = 0
    '    For i = 0 To grilla_detalle.Rows.Count - 1
    '        descgrilla = Val(grilla_detalle.Rows(i).Cells(7).Value.ToString)
    '        txt_desc_4.Text = Val(txt_desc_4.Text) + Val(descgrilla)
    '    Next

    '    '//Calcular el descuento 4
    '    txt_desc_total.Text = 0
    '    txt_desc_total.Text = Val(txt_desc_1.Text) + Val(txt_desc_2.Text) + Val(txt_desc_3.Text) + Val(txt_desc_4.Text)


    '    '//Calcular el total neto
    '    txt_neto.Text = 0
    '    For i = 0 To grilla_detalle.Rows.Count - 1
    '        netogrilla = Val(grilla_detalle.Rows(i).Cells(8).Value.ToString)
    '        txt_neto.Text = Val(txt_neto.Text) + Val(netogrilla)
    '    Next

    '    '//Calcular el total iva
    '    txt_iva.Text = 0
    '    For i = 0 To grilla_detalle.Rows.Count - 1
    '        ivagrilla = Val(grilla_detalle.Rows(i).Cells(9).Value.ToString)
    '        txt_iva.Text = Val(txt_iva.Text) + Val(ivagrilla)
    '    Next

    '    '//Calcular el sub-total 
    '    'txt_total.Text = 0
    '    'For i = 0 To grilla_detalle.Rows.Count - 1
    '    'subtotalgrilla = Val(grilla_detalle.Rows(i).Cells(7).Value.ToString)
    '    'txt_total.Text = Val(txt_total.Text) + Val(subtotalgrilla)
    '    ' Next
    '    '
    '    '//Calcular el total general

    '    txt_total_final.Text = 0
    '    For i = 0 To grilla_detalle.Rows.Count - 1
    '        totalgrilla = Val(grilla_detalle.Rows(i).Cells(10).Value.ToString)
    '        txt_total_final.Text = Val(txt_total_final.Text) + Val(totalgrilla)
    '    Next

    '    'peso = " PESOS"
    '    'If CInt(txt_total_final.Text) < 1000000 Then
    '    '    txt_desglose.Text = Num2Text(txt_total_final.Text) & peso
    '    'Else
    '    '    txt_desglose.Text = Num2Text(txt_total_final.Text)
    '    'End If
    'End Sub

    'Sub valores()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from valores"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_valor_iva.Text = DS.Tables(DT.TableName).Rows(0).Item("iva")
    '        txt_valor_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
    '    End If
    '    conexion.Close()
    'End Sub

    'quita el elemento de la grilla.
    Private Sub btn_quitar_elemento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        Dim VarEstado As String
        If grilla_detalle.Rows.Count > 0 Then

            VarEstado = grilla_detalle.CurrentRow.Cells(14).Value

            If VarEstado = "SIN INGRESAR" Then
                grilla_detalle.Rows.Remove(grilla_detalle.CurrentRow)
                txt_item.Text = grilla_detalle.Rows.Count
                txt_codigo_producto.Focus()
            Else

                Dim valormensaje As Integer
                valormensaje = MsgBox("EL PRODUCTO SELECCIONADO YA FUE INGRESADO AL SISTEMA ¿ESTA SEGURO DE ELIMINAR EL MOVIMIENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")


                If valormensaje = vbYes Then
                    Dim Var_codigo_producto_eliminar As String
                    Dim Var_cantidad_producto_eliminar As String
                    Dim Var_codigo_auto_eliminar As String
                    Dim Var_tipo_decimal_eliminar As String

                    Var_codigo_producto_eliminar = grilla_detalle.CurrentRow.Cells(0).Value
                    Var_cantidad_producto_eliminar = grilla_detalle.CurrentRow.Cells(2).Value
                    Var_tipo_decimal_eliminar = grilla_detalle.CurrentRow.Cells(17).Value
                    Var_codigo_auto_eliminar = grilla_detalle.CurrentRow.Cells(18).Value

                    SC.Connection = conexion
                    SC.CommandText = "delete from detalle_compra where n_compra='" & (txt_nro_doc.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "' and cod_producto= '" & (Var_codigo_producto_eliminar) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    If Var_tipo_decimal_eliminar = "DECIMAL" Then
                        Dim cantidad_decimal As String = ""
                        conexion.Close()
                        DS.Tables.Clear()
                        DT.Rows.Clear()
                        DT.Columns.Clear()
                        DS.Clear()
                        conexion.Open()
                        SC.Connection = conexion
                        SC.CommandText = "select * from productos where cod_producto ='" & (Var_codigo_producto_eliminar) & "'"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        DS.Tables.Add(DT)
                        If DS.Tables(DT.TableName).Rows.Count > 0 Then
                            cantidad_decimal = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                        End If
                        conexion.Close()

                        cantidad_decimal = Val(cantidad_decimal) - Val(Var_cantidad_producto_eliminar)

                        SC.Connection = conexion
                        SC.CommandText = "update productos set cantidad = '" & (cantidad_decimal) & "' where cod_producto = '" & (Var_codigo_producto_eliminar) & "'"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                    Else
                        SC.Connection = conexion
                        SC.CommandText = "update productos set cantidad = cantidad - " & (Var_cantidad_producto_eliminar) & " where cod_producto = '" & (Var_codigo_producto_eliminar) & "'"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                    End If

                    SC.Connection = conexion
                    SC.CommandText = "delete from detalle_total where n_total='" & (txt_nro_doc.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "' and movimiento='ENTRA' AND cod_producto='" & (Var_codigo_producto_eliminar) & "' "
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    conexion.Close()

                    grilla_detalle.Rows.Remove(grilla_detalle.CurrentRow)
                    txt_item.Text = grilla_detalle.Rows.Count
                    txt_codigo_producto.Focus()
                End If
                    txt_codigo_producto.Focus()
                End If
        End If
        txt_item.Text = grilla_detalle.Rows.Count

        If mirutempresa = "81921000-4" Then
            calcular_totales()
        End If
    End Sub

    'graba la informacion general de la compra.
    Sub grabar_factura()
        fecha()
        If txt_descuento1.Text = "" Then
            txt_descuento1.Text = "0"
        End If
        If txt_descuento2.Text = "" Then
            txt_descuento2.Text = "0"
        End If
        If txt_descuento3.Text = "" Then
            txt_descuento3.Text = "0"
        End If





        If combo_documento.Text = "FACTURA ELECTRONICA" Then
            conexion.Close()
            Consultas_SQL("select * from compra where tipo = 'FACTURA' and  tipo_emision = 'ELECTRONICA' and n_compra = '" & (txt_nro_doc.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Exit Sub
            Else
                SC.Connection = conexion
                SC.CommandText = "insert into compra (n_compra, tipo, tipo_emision, rut_proveedor, neto, iva, total, fecha_emision, fecha_vencimiento, fecha_ingreso, estado, usuario_responsable, codigo_compra, hora) values (" & (txt_nro_doc.Text) & " , 'FACTURA',  'ELECTRONICA', '" & (txt_rut_proveedor.Text) & "', " & (txt_neto.Text) & ", " & (txt_iva.Text) & "," & (txt_total.Text) & ", '" & (mifecha2) & "','" & (mifecha2) & "','" & (dtp_ingreso.Text) & "','IMPAGA','" & (miusuario) & "','" & (txt_codigo_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        End If




        If combo_documento.Text = "FACTURA MANUAL" Then
            conexion.Close()
            Consultas_SQL("select * from compra where tipo = 'FACTURA' and  tipo_emision = 'MANUAL' and n_compra = '" & (txt_nro_doc.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Exit Sub
            Else
                SC.Connection = conexion
                SC.CommandText = "insert into compra (n_compra, tipo, tipo_emision, rut_proveedor, neto, iva, total, fecha_emision, fecha_vencimiento, fecha_ingreso, estado, usuario_responsable, codigo_compra, hora) values (" & (txt_nro_doc.Text) & " , 'FACTURA',  'MANUAL', '" & (txt_rut_proveedor.Text) & "', " & (txt_neto.Text) & ", " & (txt_iva.Text) & "," & (txt_total.Text) & ", '" & (mifecha2) & "','" & (mifecha2) & "','" & (dtp_ingreso.Text) & "','IMPAGA','" & (miusuario) & "','" & (txt_codigo_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        End If






        If combo_documento.Text = "GUIA ELECTRONICA" Then
            conexion.Close()
            Consultas_SQL("select * from compra where tipo = 'GUIA' and  tipo_emision = 'ELECTRONICA' and n_compra = '" & (txt_nro_doc.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Exit Sub
            Else

                SC.Connection = conexion
                SC.CommandText = "insert into compra (n_compra, tipo, tipo_emision, rut_proveedor, neto, iva, total, fecha_emision, fecha_vencimiento, fecha_ingreso, estado, usuario_responsable, codigo_compra, hora) values (" & (txt_nro_doc.Text) & " , 'GUIA',  'ELECTRONICA', '" & (txt_rut_proveedor.Text) & "', " & (txt_neto.Text) & ", " & (txt_iva.Text) & "," & (txt_total.Text) & ", '" & (mifecha2) & "','" & (mifecha2) & "','" & (dtp_ingreso.Text) & "','IMPAGA','" & (miusuario) & "','" & (txt_codigo_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        End If

        If combo_documento.Text = "GUIA MANUAL" Then
            conexion.Close()
            Consultas_SQL("select * from compra where tipo = 'GUIA' and  tipo_emision = 'MANUAL' and n_compra = '" & (txt_nro_doc.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Exit Sub
            Else

                SC.Connection = conexion
                SC.CommandText = "insert into compra (n_compra, tipo, tipo_emision, rut_proveedor, neto, iva, total, fecha_emision, fecha_vencimiento, fecha_ingreso, estado, usuario_responsable, codigo_compra, hora) values (" & (txt_nro_doc.Text) & " , 'GUIA',  'MANUAL', '" & (txt_rut_proveedor.Text) & "', " & (txt_neto.Text) & ", " & (txt_iva.Text) & "," & (txt_total.Text) & ", '" & (mifecha2) & "','" & (mifecha2) & "','" & (dtp_ingreso.Text) & "','IMPAGA','" & (miusuario) & "','" & (txt_codigo_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        End If
    End Sub

    ' verifica que los campos no esten vacios y llama al grabar y grabar detalle.
    Private Sub btn_grabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        Dim mensaje As String = ""

        'If grilla_detalle.Rows.Count = 0 Then mensaje = "Grilla vacía, favor llenar" + Chr(13) & mensaje
        'If txt_rut.Text = "" Then mensaje = "Campo rut vacío, favor llenar" + Chr(13) & mensaje
        'If combo_documento.Text = "" Then mensaje = "Campo TIPO documento vacío, favor llenar" + Chr(13) & mensaje
        'If txt_factura.Text = "" Then mensaje = "Campo numero documento vacío, favor llenar" + Chr(13) & mensaje
        'If mensaje <> "" Then
        '    MsgBox(mensaje, MsgBoxStyle.OkOnly)



        If grilla_detalle.Rows.Count = 0 Then
            MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo_producto.Focus()
            Exit Sub
        End If

        If txt_rut_proveedor.Text = "" Then
            MsgBox("CAMPO PROVEEDOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_proveedor.Focus()
            Exit Sub
        End If

        If txt_nombre_proveedor.Text = "" Then
            MsgBox("CAMPO NOMBRE PROVEEDOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_proveedor.Focus()
            Exit Sub
        End If

        If combo_documento.Text = "" Then
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_documento.Focus()
            Exit Sub
        End If

        If txt_nro_doc.Text = "" Then
            MsgBox("CAMPO NRO. DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc.Focus()
            Exit Sub
        End If

        If txt_total.Text = "" Then
            MsgBox("CAMPO TOTAL FACTURA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total.Focus()
            Exit Sub
        End If

        If txt_iva.Text = "" Then
            MsgBox("CAMPO IVA FACTURA VACIO, VUELA A DIGITAR EL TOTAL Y ESTE CAMPO SE CALCULARA AUTOMATICAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total.Focus()
            Exit Sub
        End If

        If txt_neto.Text = "" Then
            MsgBox("CAMPO NETO FACTURA VACIO, VUELA A DIGITAR EL TOTAL Y ESTE CAMPO SE CALCULARA AUTOMATICAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total.Focus()
            Exit Sub
        End If
        'ElseIf combo_condiciones.Text = "" Then
        '    mensaje = "CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '    combo_condiciones.Focus()
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")


        Dim valormensaje As Integer
        'valormensaje = MsgBox("¿Esta seguro que estos datos son los correctos?: " & vbCrLf & "" & vbCrLf & "TIPO      : " & (combo_documento.Text) & " " & vbCrLf & "Fecha     : " & (dtp1.Text) & " " & vbCrLf & "Numero : " & (txt_nro_doc.Text) & " " & vbCrLf & "Total         : " & (txt_total_final.Text) & " ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Verificar datos del documento")

        valormensaje = MsgBox("¿ESTA SEGURO QUE ESTOS DATOS SON LOS CORRECTOS?: " & vbCrLf & "" & vbCrLf & "TIPO: " & (combo_documento.Text) & ", FECHA: " & (dtp_emision.Text) & ", NUMERO: " & (txt_nro_doc.Text) & ", TOTAL: " & (txt_total.Text), MsgBoxStyle.YesNo + MsgBoxStyle.Question, "VERIFICAR DATOS DEL DOCUMENTO")


        'fecha2()
        If valormensaje = vbYes Then
            Me.Enabled = False
            fecha()
            fecha2()
            crear_codigo_compra()
            grabar_factura()

            grabar_detalle_factura()
            ' MsgBox("DOCUMENTO GRABADO CON EXITO")
            MsgBox("DOCUMENTO GRABADO CON EXITO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            controles(False, True)

            limpiar()
            btn_modificar_doc.Enabled = False
            txt_rut_proveedor.Enabled = False
            txt_nro_doc.Enabled = False
            Me.Enabled = True
            btn_nueva.Focus()
        End If

    End Sub

    'graba el detalle de la factura y actualiza la antidad de productos.
    Sub grabar_detalle_factura()

        Dim VarCodProducto As String
        Dim varnombre As String
        Dim VarCantidad As String
        Dim VarPrecioUnitario As String
        Dim VarCosto As String
        Dim VarDescuento As String
        Dim VarDescuento2 As String
        Dim VarDescuento3 As String
        ' Dim VarDescuento4 As String
        Dim VarNeto As String
        Dim VarIva As String
        Dim VarTotal As String
        Dim varFactor As String
        Dim VarPrecioVenta As String
        Dim VarMargen As String
        Dim VarEstado As String

        Dim VarMargenAnterior As String
        Dim VarPrecioAnterior As String
        Dim VarTipoMedida As String

        ' Dim VarSaldo As Integer
        'Dim VarCantidadProducto As Integer
        VarMargen = ""

        fecha2()

        For i = 0 To grilla_detalle.Rows.Count - 1

            VarCodProducto = grilla_detalle.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle.Rows(i).Cells(1).Value.ToString
            VarCantidad = grilla_detalle.Rows(i).Cells(2).Value.ToString
            VarPrecioUnitario = grilla_detalle.Rows(i).Cells(3).Value.ToString
            VarCosto = grilla_detalle.Rows(i).Cells(4).Value.ToString
            VarDescuento = grilla_detalle.Rows(i).Cells(5).Value.ToString
            VarDescuento2 = grilla_detalle.Rows(i).Cells(6).Value.ToString
            VarDescuento3 = grilla_detalle.Rows(i).Cells(7).Value.ToString
            ' VarDescuento4 = grilla_detalle.Rows(i).Cells(8).Value.ToString
            VarNeto = grilla_detalle.Rows(i).Cells(8).Value.ToString
            VarIva = grilla_detalle.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle.Rows(i).Cells(10).Value.ToString
            varFactor = grilla_detalle.Rows(i).Cells(11).Value.ToString
            VarPrecioVenta = grilla_detalle.Rows(i).Cells(12).Value.ToString
            

            If VarMargen = "" Then
                VarMargen = "0"
            End If

            'Me.Close()

            VarMargen = grilla_detalle.Rows(i).Cells(13).Value.ToString
            VarEstado = grilla_detalle.Rows(i).Cells(14).Value.ToString

            VarPrecioAnterior = grilla_detalle.Rows(i).Cells(15).Value.ToString
            VarMargenAnterior = grilla_detalle.Rows(i).Cells(16).Value.ToString
            VarTipoMedida = grilla_detalle.Rows(i).Cells(17).Value.ToString

            'Dim valor As Integer

            If VarEstado = "SIN INGRESAR" Then

                If combo_documento.Text = "FACTURA ELECTRONICA" Then
                    SC.Connection = conexion
                    SC.CommandText = "insert into detalle_compra (tipo, tipo_emision, n_compra, rut_proveedor, cod_producto, nombre, precio_unitario, valor_unitario, cantidad, descuento,descuento2,descuento3, neto, iva, total, factor, precio_venta, margen, estado_ingreso, codigo_compra, precio_anterior, margen_anterior) values('FACTURA', 'ELECTRONICA', " & (txt_nro_doc.Text) & ",'" & (txt_rut_proveedor.Text) & "','" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarPrecioUnitario) & ", " & (VarCosto) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarDescuento2) & "," & (VarDescuento3) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarTotal) & ",'" & (varFactor) & "','" & (VarPrecioVenta) & "','" & (VarMargen) & "','INGRESADO','" & (txt_codigo_compra.Text) & "','" & (VarPrecioAnterior) & "','" & (VarMargenAnterior) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                If combo_documento.Text = "FACTURA MANUAL" Then
                    SC.Connection = conexion
                    SC.CommandText = "insert into detalle_compra (tipo, tipo_emision, n_compra, rut_proveedor, cod_producto, nombre, precio_unitario, valor_unitario, cantidad, descuento,descuento2,descuento3, neto, iva, total, factor, precio_venta, margen, estado_ingreso, codigo_compra, precio_anterior, margen_anterior) values('FACTURA', 'MANUAL', " & (txt_nro_doc.Text) & ",'" & (txt_rut_proveedor.Text) & "','" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarPrecioUnitario) & ", " & (VarCosto) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarDescuento2) & "," & (VarDescuento3) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarTotal) & ",'" & (varFactor) & "','" & (VarPrecioVenta) & "','" & (VarMargen) & "','INGRESADO','" & (txt_codigo_compra.Text) & "','" & (VarPrecioAnterior) & "','" & (VarMargenAnterior) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                If combo_documento.Text = "GUIA ELECTRONICA" Then
                    SC.Connection = conexion
                    SC.CommandText = "insert into detalle_compra (tipo, tipo_emision, n_compra, rut_proveedor, cod_producto, nombre, precio_unitario, valor_unitario, cantidad, descuento,descuento2,descuento3, neto, iva, total, factor, precio_venta, margen, estado_ingreso, codigo_compra, precio_anterior, margen_anterior) values('GUIA', 'ELECTRONICA', " & (txt_nro_doc.Text) & ",'" & (txt_rut_proveedor.Text) & "','" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarPrecioUnitario) & ", " & (VarCosto) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarDescuento2) & "," & (VarDescuento3) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarTotal) & ",'" & (varFactor) & "','" & (VarPrecioVenta) & "','" & (VarMargen) & "','INGRESADO','" & (txt_codigo_compra.Text) & "','" & (VarPrecioAnterior) & "','" & (VarMargenAnterior) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                If combo_documento.Text = "GUIA MANUAL" Then
                    SC.Connection = conexion
                    SC.CommandText = "insert into detalle_compra (tipo, tipo_emision, n_compra, rut_proveedor, cod_producto, nombre, precio_unitario, valor_unitario, cantidad, descuento,descuento2,descuento3, neto, iva, total, factor, precio_venta, margen, estado_ingreso, codigo_compra, precio_anterior, margen_anterior) values('GUIA', 'MANUAL', " & (txt_nro_doc.Text) & ",'" & (txt_rut_proveedor.Text) & "','" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarPrecioUnitario) & ", " & (VarCosto) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarDescuento2) & "," & (VarDescuento3) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarTotal) & ",'" & (varFactor) & "','" & (VarPrecioVenta) & "','" & (VarMargen) & "','INGRESADO','" & (txt_codigo_compra.Text) & "','" & (VarPrecioAnterior) & "','" & (VarMargenAnterior) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                Dim tipo_precio As String
                If varFactor = "0" Then
                    tipo_precio = "2"
                Else
                    tipo_precio = "1"
                End If

                If VarTipoMedida = "DECIMAL" Then
                    Dim cantidad_decimal As String = ""
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()
                    SC.Connection = conexion
                    SC.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    DS.Tables.Add(DT)
                    If DS.Tables(DT.TableName).Rows.Count > 0 Then
                        cantidad_decimal = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    End If
                    conexion.Close()

                    cantidad_decimal = CDbl(cantidad_decimal) + CDbl(VarCantidad)

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE productos SET cantidad_ultima_compra='" & (VarCantidad) & "', costo=" & (VarCosto) & ", margen='" & (VarMargen) & "', factor = '" & (varFactor) & "', cantidad ='" & (cantidad_decimal) & "' , precio = '" & (VarPrecioVenta) & "', proveedor = '" & (txt_rut_proveedor.Text) & "', ultima_compra = '" & (mifecha2) & "', tipo_doc = '" & (combo_documento.Text) & "', nro_doc = '" & (txt_nro_doc.Text) & "', tipo_precio = '" & (tipo_precio) & "', estado_producto = '-', fecha_modificacion = '" & (Form_menu_principal.dtp_fecha.Text) & "', activo='SI' WHERE cod_producto = " & (VarCodProducto) & ""
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Else
                    SC.Connection = conexion
                    SC.CommandText = "UPDATE productos SET cantidad_ultima_compra='" & (VarCantidad) & "', costo=" & (VarCosto) & ", margen='" & (VarMargen) & "', factor = '" & (varFactor) & "', cantidad = cantidad + " & (VarCantidad) & " , precio = '" & (VarPrecioVenta) & "', proveedor = '" & (txt_rut_proveedor.Text) & "', ultima_compra = '" & (mifecha2) & "', tipo_doc = '" & (combo_documento.Text) & "', nro_doc = '" & (txt_nro_doc.Text) & "', tipo_precio = '" & (tipo_precio) & "', estado_producto = '-', fecha_modificacion = '" & (Form_menu_principal.dtp_fecha.Text) & "', activo='SI' WHERE cod_producto = " & (VarCodProducto) & ""
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado, rut_proveedor) values(" & (txt_nro_doc.Text) & ",'" & (combo_documento.Text) & "', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarCosto) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarTotal) & "," & (VarTotal) & ", 'ENTRA','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA', '" & (txt_rut_proveedor.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If

        Next


    End Sub

    ''muestra el desglose del total en palabras.
    'Public Function Num2Text(ByVal value As Double) As String
    '    peso = " PESOS"
    '    pesos = " DE PESOS"
    '    Select Case value
    '        Case 0 : Num2Text = "CERO"
    '        Case 1 : Num2Text = "UN"
    '        Case 2 : Num2Text = "DOS"
    '        Case 3 : Num2Text = "TRES"
    '        Case 4 : Num2Text = "CUATRO"
    '        Case 5 : Num2Text = "CINCO"
    '        Case 6 : Num2Text = "SEIS"
    '        Case 7 : Num2Text = "SIETE"
    '        Case 8 : Num2Text = "OCHO"
    '        Case 9 : Num2Text = "NUEVE"
    '        Case 10 : Num2Text = "DIEZ"
    '        Case 11 : Num2Text = "ONCE"
    '        Case 12 : Num2Text = "DOCE"
    '        Case 13 : Num2Text = "TRECE"
    '        Case 14 : Num2Text = "CATORCE"
    '        Case 15 : Num2Text = "QUINCE"
    '        Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
    '        Case 20 : Num2Text = "VEINTE"
    '        Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
    '        Case 30 : Num2Text = "TREINTA"
    '        Case 40 : Num2Text = "CUARENTA"
    '        Case 50 : Num2Text = "CINCUENTA"
    '        Case 60 : Num2Text = "SESENTA"
    '        Case 70 : Num2Text = "SETENTA"
    '        Case 80 : Num2Text = "OCHENTA"
    '        Case 90 : Num2Text = "NOVENTA"
    '        Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
    '        Case 100 : Num2Text = "CIEN"
    '        Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
    '        Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
    '        Case 500 : Num2Text = "QUINIENTOS"
    '        Case 700 : Num2Text = "SETECIENTOS"
    '        Case 900 : Num2Text = "NOVECIENTOS"
    '        Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
    '        Case 1000 : Num2Text = "MIL"
    '        Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
    '        Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
    '            If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
    '        Case 1000000 : Num2Text = "UN MILLON" & pesos
    '        Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
    '        Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES " & pesos
    '            If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
    '        Case 1000000000000.0# : Num2Text = "UN BILLON" & pesos
    '        Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
    '        Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES" & pesos
    '            If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
    '    End Select
    'End Function

    'salir de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txt_precio_venta_producto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_venta_producto.Click
        txt_precio_venta_producto.SelectionStart = 0
        txt_precio_venta_producto.SelectionLength = Len(txt_precio_venta_producto.Text)
    End Sub

    Private Sub txt_precio_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_venta_producto.GotFocus
        txt_precio_venta_producto.BackColor = Color.LightSkyBlue
    End Sub



    Private Sub txt_cantidad_agregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.Click
        txt_cantidad_agregar.SelectionStart = 0
        txt_cantidad_agregar.SelectionLength = Len(txt_cantidad_agregar.Text)
    End Sub

    Private Sub txt_cantidad_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.GotFocus
        txt_cantidad_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_descuento2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento2.Click
        txt_descuento2.SelectionStart = 0
        txt_descuento2.SelectionLength = Len(txt_descuento2.Text)
    End Sub



    Private Sub txt_descuento2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento2.GotFocus
        txt_descuento2.BackColor = Color.LightSkyBlue
        'If txt_descuento1.Text = "" Or txt_descuento1.Text = "0" Then
        '    txt_descuento1.Focus()
        '    txt_descuento1.SelectAll()
        '    txt_descuento2.Text = ""
        '    txt_descuento3.Text = ""
        '    txt_descuento4.Text = ""
        'End If
    End Sub

    Private Sub txt_descuento3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento3.Click
        txt_descuento3.SelectionStart = 0
        txt_descuento3.SelectionLength = Len(txt_descuento3.Text)
    End Sub

    Private Sub txt_descuento3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento3.GotFocus
        txt_descuento3.BackColor = Color.LightSkyBlue
        'If txt_descuento2.Text = "" Or txt_descuento2.Text = "0" Then
        '    txt_descuento2.Focus()
        '    txt_descuento2.SelectAll()
        '    txt_descuento3.Text = ""
        '    txt_descuento4.Text = ""
        'End If
    End Sub

    'Private Sub txt_descuento4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_descuento4.SelectionStart = 0
    '    txt_descuento4.SelectionLength = Len(txt_descuento4.Text)
    'End Sub

    'Private Sub txt_descuento4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_descuento4.BackColor = Color.LightSkyBlue
    '    'If txt_descuento3.Text = "" Or txt_descuento3.Text = "0" Then
    '    '    txt_descuento3.Focus()
    '    '    txt_descuento3.SelectAll()
    '    '    txt_descuento4.Text = ""
    '    'End If
    'End Sub

    Private Sub txt_factura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.GotFocus
        txt_nro_doc.BackColor = Color.LightSkyBlue
    End Sub

    'valida la informacion de solo numeros.
    Private Sub txt_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_doc.KeyPress
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

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            dtp_emision.Focus()
        End If
    End Sub

    Private Sub combo_documento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documento.GotFocus
        combo_documento.BackColor = Color.LightSkyBlue
    End Sub




    Private Sub combo_documento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles combo_documento.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_nro_doc.Focus()
        End If
    End Sub

    Private Sub combo_documento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_documento.KeyPress
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




    '    Private Sub combo_documento_KeyPress(ByVal sender As Object, _
    'ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_documento.KeyPress
    '        If Asc(e.KeyChar) = Keys.Enter Then
    '            txt_nro_doc.Focus()
    '        End If
    '    End Sub



    Private Sub combo_documento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documento.LostFocus
        combo_documento.BackColor = Color.White
    End Sub


    'se llama al mostrar datos productos.
    'se hablita el textbox cantidad agregar, descuento, agregar, y el boton quitar elemento.
    ' se le da el valor del ocmbo al texbox.
    Private Sub combo_codigo_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_datos_productos()
        txt_cantidad_agregar.Focus()
    End Sub

    'se limpia la pantalla.
    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()

            controles(False, True)

            btn_modificar_doc.Enabled = False

            conexion.Close()
            Form_cargar_compra.Show()
            Me.Enabled = False

        End If
    End Sub

    Private Sub dtp1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        dtp_emision.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        dtp_emision.BackColor = Color.White
    End Sub

    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'credito()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub txt_precio_unitario_producto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_unitario_producto.Click
        txt_precio_unitario_producto.SelectionStart = 0
        txt_precio_unitario_producto.SelectionLength = Len(txt_precio_unitario_producto.Text)
    End Sub

    Private Sub txt_costo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_unitario_producto.GotFocus
        txt_precio_unitario_producto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_costo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio_unitario_producto.KeyPress

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
            '    If Radio_margen.Checked = True Then
            '        txt_margen_producto.Focus()
            '    Else
            txt_descuento1.Focus()
            '    End If
        End If
    End Sub

    Private Sub txt_descuento2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento2.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

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
            'If txt_descuento2.Text <> "" And txt_descuento2.Text <> "0" Then
            txt_descuento3.Focus()
            'Else
            ' btn_agregar.Focus()
            ' End If
        End If
    End Sub

    Private Sub txt_descuento3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento3.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

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
            'If txt_descuento3.Text <> "" And txt_descuento3.Text <> "0" Then
            txt_precio_venta_producto.Focus()
            ' Else
            '   btn_agregar.Focus()
            ' End If
        End If
    End Sub

    Private Sub txt_descuento4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

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
            txt_precio_venta_producto.Focus()
        End If

    End Sub

    Private Sub txt_descuento1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento1.Click
        txt_descuento1.SelectionStart = 0
        txt_descuento1.SelectionLength = Len(txt_descuento1.Text)
    End Sub

    Private Sub txt_descuento1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento1.GotFocus
        txt_descuento1.BackColor = Color.LightSkyBlue
        If txt_descuento1.Text = "" Or txt_descuento1.Text = "0" Then
            txt_descuento1.Focus()
            txt_descuento1.SelectAll()
            txt_descuento1.Text = ""
            txt_descuento2.Text = ""
            txt_descuento3.Text = ""
            'txt_descuento4.Text = ""
        End If
    End Sub

    'Private Sub txt_margen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_margen_producto.BackColor = Color.LightSkyBlue
    'End Sub

    Private Sub txt_margen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If


        e.KeyChar = e.KeyChar.ToString.ToUpper

        'If e.KeyChar = "'" Then
        '    e.KeyChar = "´"
        'End If

        'If e.KeyChar = "&" Then
        '    e.KeyChar = " "
        'End If

        'If e.KeyChar = Chr(34) Then
        '    e.KeyChar = "´´"
        'End If

        'If e.KeyChar = "\" Then
        '    e.KeyChar = " "
        'End If


        'If e.KeyChar = "," And Not txt_margen_producto.Text.IndexOf(",") Then
        '    e.Handled = True
        'ElseIf e.KeyChar = "," Then
        '    e.Handled = False
        'End If

        'If e.KeyChar = "." And Not txt_margen_producto.Text.IndexOf(".") Then
        '    e.Handled = True
        'ElseIf e.KeyChar = "." Then
        '    e.Handled = False
        'End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_cantidad_agregar.Focus()
        End If

        'If e.KeyChar = "." Then
        '    e.KeyChar = ","
        'End If


    End Sub

    Private Sub btn_agregar_proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_proveedor.Click
        Me.Enabled = False
        conexion.Close()
        Form_registro_proveedores_compra.txt_rut.Text = Me.txt_rut_proveedor.Text()
        Form_registro_proveedores_compra.Show()
    End Sub

    Private Sub btn_agregar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_producto.Click
        Me.Enabled = False
        conexion.Close()
        Form_registro_productos_compra.txt_codigo.Text = Me.txt_codigo_producto.Text()
        Form_registro_productos_compra.Show()
    End Sub





    Private Sub txt_precio_venta_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio_venta_producto.KeyPress
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
            txt_cantidad_etiquetas.Focus()
            ' txt_cantidad_agregar.Focus()
        End If
    End Sub

    Private Sub txt_precio_venta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_venta_producto.LostFocus
        txt_precio_venta_producto.BackColor = Color.White
    End Sub


    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        txt_nombre_proveedor.Text = ""
        'txt_direccion_proveedor.Text = ""
        ' txt_credito_proveedor.Text = ""
        txt_telefono_proveedor.Text = ""

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            guion_rut()
            'mostrar_datos_proveedores()
            'credito()
            ' txt_codigo_producto.Focus()

            'If txt_nombre_proveedor.Text = "" Then
            '    txt_rut_proveedor.Focus()
            'Else
            '    txt_codigo_producto.Focus()
            'End If
        End If
    End Sub

    Sub guion_rut()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_proveedor.Text
        If rut_cliente.Length > 2 Then
            guion = rut_cliente(rut_cliente.Length - 2).ToString()
            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_proveedor.Text = rut_cliente
            End If
        End If
    End Sub



    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.GotFocus
        txt_codigo_producto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_producto.KeyPress

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




        limpiar_producto_enter()

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



        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If



        'If txt_codigo_producto.Text <> "" Then

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then


            If txt_codigo_producto.Text = "" Then
                Exit Sub
            End If

            conexion.Close()
            Dim cantidad_caracteres As Integer
            cantidad_caracteres = Len(txt_codigo_producto.Text)
            If cantidad_caracteres <= 5 Then
                Form_buscador_productos_compras.Show()
                Form_buscador_productos_compras.txt_codigo.Text = txt_codigo_producto.Text
                Form_buscador_productos_compras.buscar_codigo()
                Exit Sub
            End If










            mostrar_datos_productos()


            '    If Radio_precio_venta.Checked = True Then
            '        txt_precio_venta_producto.Enabled = True
            '        txt_margen_producto.Enabled = False
            '        txt_margen_producto.BackColor = SystemColors.Control
            '    End If

            '    If Radio_margen.Checked = True Then
            '        txt_margen_producto.Enabled = True
            '        txt_precio_venta_producto.Enabled = False
            '        txt_precio_venta_producto.BackColor = SystemColors.Control
            '    End If
        End If


        'Else
        '    txt_costo_producto.Focus()
        'End If





    End Sub

    Private Sub txt_codigo_producto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_producto.KeyUp

    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.LostFocus
        txt_codigo_producto.BackColor = Color.White
        'TextBox1.Text = ActiveControl.Name
    End Sub

    Private Sub txt_costo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_unitario_producto.LostFocus
        txt_precio_unitario_producto.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_etiquetas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_etiquetas.Click
        txt_cantidad_etiquetas.SelectionStart = 0
        txt_cantidad_etiquetas.SelectionLength = Len(txt_cantidad_etiquetas.Text)
    End Sub

    Private Sub txt_cantidad_etiquetas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_etiquetas.GotFocus
        txt_cantidad_etiquetas.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_etiquetas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_etiquetas.LostFocus
        txt_cantidad_etiquetas.BackColor = Color.White
    End Sub



    'Private Sub txt_margen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_margen_producto.BackColor = Color.White

    '    Dim primer_caracter As String
    '    Dim ultimo_caracter As String
    '    Dim total_caracter As String

    '    If txt_margen_producto.Text = "" Then
    '        primer_caracter = 0
    '        ultimo_caracter = 0
    '    Else
    '        primer_caracter = txt_margen_producto.Text.Length - txt_margen_producto.Text.Length + 1
    '        ultimo_caracter = txt_margen_producto.Text.Length
    '        total_caracter = txt_margen_producto.Text
    '    End If



    '    Dim n1 As Byte, lMal As Boolean


    '    If txt_margen_producto.Text <> "" Then

    '        For n1 = ultimo_caracter To ultimo_caracter
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_margen_producto.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next

    '        For n1 = 1 To 1
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_margen_producto.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub txt_cantidad_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_agregar.KeyPress
        If txt_cantidad_agregar.Text.Contains(",") Then
            txt_cantidad_agregar.MaxLength = "6"
        Else
            txt_cantidad_agregar.MaxLength = "5"
        End If

        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_precio_unitario_producto.Focus()
            '  txt_cantidad_agregar.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White
    End Sub

    Private Sub txt_descuento1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento1.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

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
            '  If txt_descuento1.Text <> "" And txt_descuento1.Text <> "0" Then
            txt_descuento2.Focus()
            '  Else
            '  btn_agregar.Focus()
            ' End If
        End If



    End Sub

    Private Sub txt_descuento1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento1.LostFocus
        txt_descuento1.BackColor = Color.White

        Dim primer_caracter As String
        Dim ultimo_caracter As String
        Dim total_caracter As String

        total_caracter = ""

        If txt_descuento1.Text = "" Then
            primer_caracter = 0
            ultimo_caracter = 0
        Else
            primer_caracter = txt_descuento1.Text.Length - txt_descuento1.Text.Length + 1
            ultimo_caracter = txt_descuento1.Text.Length
            total_caracter = txt_descuento1.Text
        End If



        Dim n1 As Byte, lMal As Boolean


        If txt_descuento1.Text <> "" Then

            For n1 = ultimo_caracter To ultimo_caracter
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_descuento1.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next

            For n1 = 1 To 1
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_descuento1.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next
        End If




        'If txt_descuento1.Text <> "" And txt_descuento1.Text <> "0" Then
        '  txt_descuento2.Focus()
        'Else
        '    txt_cantidad_etiquetas.Focus()
        'End If






    End Sub

    Private Sub txt_descuento2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento2.LostFocus
        txt_descuento2.BackColor = Color.White

        Dim primer_caracter As String
        Dim ultimo_caracter As String
        Dim total_caracter As String

        total_caracter = ""

        If txt_descuento2.Text = "" Then
            primer_caracter = 0
            ultimo_caracter = 0
        Else
            primer_caracter = txt_descuento2.Text.Length - txt_descuento2.Text.Length + 1
            ultimo_caracter = txt_descuento2.Text.Length
            total_caracter = txt_descuento2.Text
        End If



        Dim n1 As Byte, lMal As Boolean


        If txt_descuento2.Text <> "" Then

            For n1 = ultimo_caracter To ultimo_caracter
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_descuento2.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next

            For n1 = 1 To 1
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_descuento2.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next
        End If






        'If txt_descuento2.Text <> "" And txt_descuento2.Text <> "0" Then
        '    txt_descuento3.Focus()
        'Else
        '    txt_cantidad_etiquetas.Focus()
        'End If



    End Sub

    Private Sub txt_descuento3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento3.LostFocus
        txt_descuento3.BackColor = Color.White

        Dim primer_caracter As String
        Dim ultimo_caracter As String
        Dim total_caracter As String


        total_caracter = ""
        If txt_descuento3.Text = "" Then
            primer_caracter = 0
            ultimo_caracter = 0
        Else
            primer_caracter = txt_descuento3.Text.Length - txt_descuento3.Text.Length + 1
            ultimo_caracter = txt_descuento3.Text.Length
            total_caracter = txt_descuento3.Text
        End If



        Dim n1 As Byte, lMal As Boolean


        If txt_descuento3.Text <> "" Then

            For n1 = ultimo_caracter To ultimo_caracter
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_descuento3.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next

            For n1 = 1 To 1
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_descuento3.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next
        End If


        'If txt_descuento3.Text <> "" And txt_descuento3.Text <> "0" Then
        '    txt_descuento4.Focus()
        'Else
        '    txt_cantidad_etiquetas.Focus()
        'End If
    End Sub

    'Private Sub txt_descuento4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_descuento4.BackColor = Color.White

    '    Dim primer_caracter As String
    '    Dim ultimo_caracter As String
    '    Dim total_caracter As String

    '    If txt_descuento4.Text = "" Then
    '        primer_caracter = 0
    '        ultimo_caracter = 0
    '    Else
    '        primer_caracter = txt_descuento4.Text.Length - txt_descuento4.Text.Length + 1
    '        ultimo_caracter = txt_descuento4.Text.Length
    '        total_caracter = txt_descuento4.Text
    '    End If



    '    Dim n1 As Byte, lMal As Boolean


    '    If txt_descuento4.Text <> "" Then

    '        For n1 = ultimo_caracter To ultimo_caracter
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_descuento4.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next

    '        For n1 = 1 To 1
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_descuento4.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_factura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.LostFocus
        txt_nro_doc.BackColor = Color.White
    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_nueva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    'Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn_agregar.KeyPress
    '    If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
    '        Dim desc As Integer
    '        Dim desc2 As Integer
    '        Dim desc3 As Integer
    '        Dim desc4 As Integer
    '        Dim iva As Integer
    '        Dim neto As Integer
    '        ' Dim subtotal As Integer
    '        Dim total As Integer
    '        Dim codigo As String
    '        Dim cantidad As Integer
    '        Dim saldo As Integer
    '        Dim factor As Decimal
    '        Dim precioventa As Decimal
    '        Dim factor_ingresar As Decimal
    '        Dim precio_venta As Integer
    '        Dim mensaje As String = ""

    '        If Radio_precio2.Checked = True Then
    '            If txt_codigo_producto.Text = "" Or txt_codigo_producto.Text = "0" Then mensaje = "Campo codigo vacío, favor llenar" + Chr(13) & mensaje
    '            If txt_costo_producto.Text = "" Or txt_costo_producto.Text = "0" Then mensaje = "Campo costo vacío, favor llenar" + Chr(13) & mensaje
    '            If txt_precio_venta_producto.Text = "" Or txt_precio_venta_producto.Text = "0" Then mensaje = "Campo precio venta vacío, favor llenar" + Chr(13) & mensaje
    '            If txt_cantidad_agregar.Text = "" Or txt_cantidad_agregar.Text = "0" Then mensaje = "Campo cantidad a agregar vacío, favor llenar" + Chr(13) & mensaje
    '            If txt_descuento1.Text = "" Then txt_descuento1.Text = "0"
    '            If txt_descuento2.Text = "" Then txt_descuento2.Text = "0"
    '            If txt_descuento3.Text = "" Then txt_descuento3.Text = "0"
    '            If txt_descuento4.Text = "" Then txt_descuento4.Text = "0"
    '            If txt_cantidad_producto.Text = "" Then txt_cantidad_producto.Text = "0"
    '            If mensaje <> "" Then
    '                MsgBox(mensaje, MsgBoxStyle.OkOnly)
    '            Else

    '                If txt_cantidad_agregar.Text <> "" And txt_cantidad_agregar.Text <> 0 Then

    '                    For i = 0 To grilla_detalle.Rows.Count - 1
    '                        codigo = Val(grilla_detalle.Rows(i).Cells(0).Value.ToString)
    '                        cantidad = Val(grilla_detalle.Rows(i).Cells(2).Value.ToString)
    '                        saldo = Val(grilla_detalle.Rows(i).Cells(14).Value.ToString)
    '                        If codigo = txt_codigo_producto.Text Then
    '                            grilla_detalle.Rows.Remove(grilla_detalle.Rows(i))
    '                            cantidad = cantidad + CInt(txt_cantidad_agregar.Text)
    '                            saldo = saldo + CInt(txt_cantidad_agregar.Text)
    '                            desc = ((txt_costo_producto.Text * txt_cantidad_agregar.Text) * txt_descuento1.Text) / 100
    '                            desc2 = ((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) * txt_descuento2.Text) / 100
    '                            desc3 = (((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) * txt_descuento3.Text) / 100
    '                            desc4 = (((((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) - desc3) * txt_descuento4.Text) / 100)
    '                            neto = (((((txt_cantidad_agregar.Text * txt_costo_producto.Text) - desc) - desc2) - desc3) - desc4)
    '                            iva = (neto * 19) / 100
    '                            total = iva + neto
    '                            'total = subtotal - desc
    '                            total = iva + neto
    '                            factor_ingresar = "0"

    '                            grilla_detalle.Rows.Add(txt_codigo_producto.Text, txt_nombre_producto.Text, cantidad, txt_costo_producto.Text, desc, desc2, desc3, desc4, neto, iva, total, factor_ingresar, txt_precio_venta_producto.Text, txt_rut_proveedor.Text, saldo, "0")

    '                            txt_cantidad_agregar.Text = 0
    '                            calcular_totales()
    '                            Exit Sub
    '                        End If
    '                    Next
    '                    desc = ((txt_costo_producto.Text * txt_cantidad_agregar.Text) * txt_descuento1.Text) / 100
    '                    desc2 = ((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) * txt_descuento2.Text) / 100
    '                    desc3 = (((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) * txt_descuento3.Text) / 100
    '                    desc4 = (((((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) - desc3) * txt_descuento4.Text) / 100)
    '                    neto = (((((txt_cantidad_agregar.Text * txt_costo_producto.Text) - desc) - desc2) - desc3) - desc4)
    '                    iva = (neto * 19) / 100
    '                    total = iva + neto
    '                    'total = subtotal - desc
    '                    saldo = Int(txt_cantidad_agregar.Text) + Int(txt_cantidad_producto.Text)

    '                    factor_ingresar = "0"

    '                    grilla_detalle.Rows.Add(txt_codigo_producto.Text, txt_nombre_producto.Text, txt_cantidad_agregar.Text, txt_costo_producto.Text, desc, desc2, desc3, desc4, neto, iva, total, factor_ingresar, txt_precio_venta_producto.Text, txt_rut_proveedor.Text, saldo, "0")
    '                    txt_cantidad_agregar.Text = 0
    '                    calcular_totales()
    '                    limpiar_producto()
    '                    txt_codigo_producto.Focus()
    '                Else
    '                    MsgBox("Debe ingresar una cantidad", 0 + 16, "Error")
    '                End If

    '                combo_documento.Enabled = True
    '            End If

    '        Else

    '            If txt_codigo_producto.Text = "" Then mensaje = "Campo codigo vacío, favor llenar" + Chr(13) & mensaje
    '            If txt_costo_producto.Text = "" Then mensaje = "Campo costo vacío, favor llenar" + Chr(13) & mensaje
    '            If txt_margen_producto.Text = "" Then mensaje = "Campo margen vacío, favor llenar" + Chr(13) & mensaje
    '            If txt_cantidad_agregar.Text = "" Then mensaje = "Campo cantidad a agregar vacío, favor llenar" + Chr(13) & mensaje
    '            If txt_descuento1.Text = "" Then txt_descuento1.Text = "0"
    '            If txt_descuento2.Text = "" Then txt_descuento2.Text = "0"
    '            If txt_descuento3.Text = "" Then txt_descuento3.Text = "0"
    '            If txt_descuento4.Text = "" Then txt_descuento4.Text = "0"
    '            If txt_cantidad_producto.Text = "" Then txt_cantidad_producto.Text = "0"
    '            If mensaje <> "" Then
    '                MsgBox(mensaje, MsgBoxStyle.OkOnly)
    '            Else

    '                If txt_cantidad_agregar.Text <> "" And txt_cantidad_agregar.Text <> 0 Then

    '                    For i = 0 To grilla_detalle.Rows.Count - 1
    '                        codigo = Val(grilla_detalle.Rows(i).Cells(0).Value.ToString)
    '                        cantidad = Val(grilla_detalle.Rows(i).Cells(2).Value.ToString)
    '                        saldo = Val(grilla_detalle.Rows(i).Cells(14).Value.ToString)
    '                        If codigo = txt_codigo_producto.Text Then
    '                            grilla_detalle.Rows.Remove(grilla_detalle.Rows(i))
    '                            cantidad = cantidad + CInt(txt_cantidad_agregar.Text)
    '                            saldo = saldo + CInt(txt_cantidad_agregar.Text)
    '                            desc = ((txt_costo_producto.Text * txt_cantidad_agregar.Text) * txt_descuento1.Text) / 100
    '                            desc2 = ((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) * txt_descuento2.Text) / 100
    '                            desc3 = (((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) * txt_descuento3.Text) / 100
    '                            desc4 = (((((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) - desc3) * txt_descuento4.Text) / 100)
    '                            neto = (((((txt_cantidad_agregar.Text * txt_costo_producto.Text) - desc) - desc2) - desc3) - desc4)
    '                            iva = (neto * 19) / 100
    '                            total = iva + neto
    '                            'total = subtotal - desc
    '                            total = iva + neto

    '                            precioventa = (txt_costo_producto.Text) * 1.19 * (txt_margen_producto.Text)
    '                            factor = precioventa / 2200
    '                            factor_ingresar = factor.ToString("##,000.00")
    '                            precio_venta = CInt(txt_costo_producto.Text) * 1.19 * (txt_margen_producto.Text)

    '                            grilla_detalle.Rows.Add(txt_codigo_producto.Text, txt_nombre_producto.Text, cantidad, txt_costo_producto.Text, desc, desc2, desc3, desc4, neto, iva, total, factor_ingresar, precio_venta, txt_rut_proveedor.Text, saldo, txt_margen_producto.Text)

    '                            txt_cantidad_agregar.Text = 0
    '                            calcular_totales()
    '                            txt_codigo_producto.Focus()
    '                            Exit Sub
    '                        End If
    '                    Next
    '                    desc = ((txt_costo_producto.Text * txt_cantidad_agregar.Text) * txt_descuento1.Text) / 100
    '                    desc2 = ((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) * txt_descuento2.Text) / 100
    '                    desc3 = (((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) * txt_descuento3.Text) / 100
    '                    desc4 = (((((txt_costo_producto.Text * txt_cantidad_agregar.Text - desc) - desc2) - desc3) * txt_descuento4.Text) / 100)
    '                    neto = (((((txt_cantidad_agregar.Text * txt_costo_producto.Text) - desc) - desc2) - desc3) - desc4)
    '                    iva = (neto * 19) / 100
    '                    total = iva + neto
    '                    'total = subtotal - desc
    '                    saldo = Int(txt_cantidad_agregar.Text) + Int(txt_cantidad_producto.Text)
    '                    precioventa = (txt_costo_producto.Text) * 1.19 * (txt_margen_producto.Text)
    '                    factor = precioventa / 2200
    '                    factor_ingresar = factor.ToString("##,000.00")
    '                    precio_venta = CInt(txt_costo_producto.Text) * 1.19 * (txt_margen_producto.Text)
    '                    grilla_detalle.Rows.Add(txt_codigo_producto.Text, txt_nombre_producto.Text, txt_cantidad_agregar.Text, txt_costo_producto.Text, desc, desc2, desc3, desc4, neto, iva, total, factor_ingresar, precio_venta, txt_rut_proveedor.Text, saldo, txt_margen_producto.Text)
    '                    txt_cantidad_agregar.Text = 0
    '                    calcular_totales()
    '                    limpiar_producto()
    '                    txt_codigo_producto.Focus()
    '                Else
    '                    MsgBox("Debe ingresar una cantidad", 0 + 16, "Error")
    '                End If
    '                combo_documento.Enabled = True
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub

    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_nueva.BackColor = Color.Transparent
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.White
    '    'TextBox1.Text = ActiveControl.Name
    'End Sub

    Private Sub Radio_precio1_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Radio_margen.TabStopChanged
        Radio_margen.TabStop = False
    End Sub

    Private Sub Radio_precio2_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Radio_precio_venta.TabStopChanged
        Radio_precio_venta.TabStop = False
    End Sub

    Private Sub GroupBox2_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox_producto.TabStopChanged
        GroupBox_producto.TabStop = False
    End Sub

    Private Sub GroupBox1_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox_proveedor.TabStopChanged
        GroupBox_proveedor.TabStop = False
    End Sub

    Private Sub GroupBox6_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox_ingreso.TabStopChanged
        GroupBox_ingreso.TabStop = False
    End Sub

    Private Sub GroupBox9_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox_descuento.Enter
        GroupBox_descuento.TabStop = False
    End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.Click

        Me.Enabled = False
        conexion.Close()
        ' Form_buscar_productos_compras.Show()
        Form_buscador_productos_compras.Show()

    End Sub

    Private Sub Radio_codigo_interno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_codigo_producto.Focus()
    End Sub

    Private Sub Radio_codigo_barra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_codigo_producto.Focus()
    End Sub

    'Private Sub Radio_codigo_interno_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Radio_codigo_interno.TabStop = False
    'End Sub






    'Private Sub txt_desc_total_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_desc_total.BackColor = Color.LightBlue
    'End Sub

    'Private Sub txt_desc_total_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_desc_total.BackColor = Color.White
    'End Sub




    Private Sub txt_total_final_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_rut_proveedor.Focus()
        End If
    End Sub





    Private Sub txt_codigo_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.TextChanged

    End Sub

    Private Sub txt_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar.Click
        conexion.Close()
        Form_cargar_compra.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.GotFocus
        btn_cargar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_proveedor.GotFocus
        btn_agregar_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_producto.GotFocus
        btn_agregar_producto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_productos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.GotFocus
        btn_buscar_productos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.LostFocus
        btn_cargar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_agregar_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_proveedor.LostFocus
        btn_agregar_proveedor.BackColor = Color.Transparent
    End Sub

    Private Sub btn_agregar_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_producto.LostFocus
        btn_agregar_producto.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_productos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.LostFocus
        btn_buscar_productos.BackColor = Color.Transparent
    End Sub

    Private Sub txt_total_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.GotFocus
        txt_total.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_total_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total.KeyPress

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
            txt_rut_proveedor.Focus()
        End If

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_total_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.LostFocus
        txt_total.BackColor = Color.WhiteSmoke
    End Sub






    Private Sub txt_descuento1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento1.TextChanged
        datos_producto_venta()
        If txt_descuento1.Text = "0" Then
            txt_descuento1.SelectionStart = 0
            txt_descuento1.SelectionLength = Len(txt_descuento1.Text)
        End If
    End Sub

    Private Sub txt_costo_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio_unitario_producto.TextChanged
        datos_producto_venta()
        If txt_precio_unitario_producto.Text = "0" Then
            txt_precio_unitario_producto.SelectionStart = 0
            txt_precio_unitario_producto.SelectionLength = Len(txt_precio_unitario_producto.Text)
        End If
    End Sub

    Private Sub txt_descuento3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento3.TextChanged
        datos_producto_venta()
        If txt_descuento3.Text = "0" Then
            txt_descuento3.SelectionStart = 0
            txt_descuento3.SelectionLength = Len(txt_descuento3.Text)
        End If
    End Sub

    Private Sub txt_descuento4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        datos_producto_venta()
    End Sub

    Private Sub txt_cantidad_agregar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.TextChanged


        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))

        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))

        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))

        datos_producto_venta()

        If txt_cantidad_agregar.Text = "0" Then
            txt_cantidad_agregar.SelectionStart = 0
            txt_cantidad_agregar.SelectionLength = Len(txt_cantidad_agregar.Text)
        End If
    End Sub

    Private Sub dtp1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_emision.Enter

    End Sub

    Private Sub dtp1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_emision.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_total.Focus()
        End If
    End Sub

    Private Sub dtp1_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_emision.LostFocus
        'TextBox1.Text = ActiveControl.Name
    End Sub

    Private Sub dtp1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_emision.ValueChanged

    End Sub

    Private Sub combo_documento_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles combo_documento.MouseMove

    End Sub

    Private Sub combo_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documento.SelectedIndexChanged

    End Sub

    Private Sub txt_descuento2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento2.TextChanged
        datos_producto_venta()

        If txt_descuento2.Text = "0" Then
            txt_descuento2.SelectionStart = 0
            txt_descuento2.SelectionLength = Len(txt_descuento2.Text)
        End If
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        Dim Fuente As Font
        Fuente = New Font("GothicE", 50, FontStyle.Bold)
        Dim Fuente1 As Font
        Fuente1 = New Font("Arial", 12, FontStyle.Bold)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        'Dim rect1 As New Rectangle(5, 1, 294, 10)
        ''(left,top,whidth,height )
        'Dim rect2 As New Rectangle(5, 54, 294, 40)

        'e.Graphics.DrawString(txt_empresa.Text, New Font("ARIAL", 8, FontStyle.Bold), Brushes.Black, -10, 1)
        'e.Graphics.DrawString(txt_nombre_producto.Text, New Font("ARIAL", 8), Brushes.Black, 1, 13)
        'e.Graphics.DrawString(txt_aplicacion.Text, New Font("ARIAL", 8), Brushes.Black, 1, 25)
        'e.Graphics.DrawString(txt_numero_tecnico.Text, New Font("ARIAL", 8), Brushes.Black, 1, 37)
        'e.Graphics.DrawString(txt_factor.Text, New Font("ARIAL", 8), Brushes.Black, 50, 37)
        'e.Graphics.DrawString("*" & (lbl_codigo.Text) & "*", New Font("C39HrP36DlTt", 30), Brushes.Black, 1, 49)
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim margen As String

        If Radio_impresora_1.Checked = True Then
            margen = margen_etiqueta_1
        Else
            margen = margen_etiqueta_2
        End If

        ' margen = -35

        Dim rect1 As New Rectangle(margen + 5, 1, 294, 10)
        '(left,top,whidth,height )
        Dim rect2 As New Rectangle(margen + 5, 54, 294, 40)

        e.Graphics.DrawString(mititularetiquetaempresa, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, rect1, stringFormat)

        Dim descripcion_caracteres As String
        descripcion_caracteres = txt_nombre_producto.Text
        If descripcion_caracteres.Length > 34 Then
            descripcion_caracteres = descripcion_caracteres.Substring(0, 34)
        End If

        Dim descripcion_aplicacion As String
        descripcion_aplicacion = txt_aplicacion.Text
        If descripcion_aplicacion.Length > 34 Then
            descripcion_aplicacion = descripcion_aplicacion.Substring(0, 34)
        End If

        Dim descripcion_tecnico As String
        descripcion_tecnico = txt_numero_tecnico_producto.Text
        If descripcion_tecnico.Length > 27 Then
            descripcion_tecnico = descripcion_tecnico.Substring(0, 27)
        End If

        e.Graphics.DrawString(descripcion_caracteres, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 15)
        e.Graphics.DrawString(descripcion_aplicacion, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 27)
        e.Graphics.DrawString(descripcion_tecnico, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 39)

  


        If Radio_margen.Checked = True Then
            If txt_factor.Text <> "0" And txt_factor.Text <> "" Then
                e.Graphics.DrawString(txt_factor.Text, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 242, 39, format1)
            End If
        End If


        If radio_solo_numeros.Checked = True Then
            e.Graphics.DrawString((txt_codigo_producto.Text), New Font("ARIAL", 30), Brushes.Black, rect2, stringFormat)
        Else
            e.Graphics.DrawString("*" & (txt_codigo_producto.Text) & "*", New Font("C39HrP36DlTt", 30), Brushes.Black, rect2, stringFormat)
        End If
      


        'Indica que no hay más hojas para imprimir, por lo que no se ejecutará nuevamente este procedimiento
        e.HasMorePages = False
        'Fuerza a que se liberen los recursos.
        Fuente.Dispose()
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Sub valores()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select iva,factor from valores"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            valor_iva = DS2.Tables(DT2.TableName).Rows(0).Item("iva")
            valor_factor = DS2.Tables(DT2.TableName).Rows(0).Item("factor")
            'tiempo_espera = DS2.Tables(DT2.TableName).Rows(0).Item("tiempo_espera")
            ' sueldo_minimo = DS2.Tables(DT2.TableName).Rows(0).Item("sueldo_minimo")
            'valor_uf = DS2.Tables(DT2.TableName).Rows(0).Item("uf")
            ' valor_seguro_cesantia = DS2.Tables(DT2.TableName).Rows(0).Item("seguro_cesantia")
            '  valor_salud_fonasa = DS2.Tables(DT2.TableName).Rows(0).Item("salud_fonasa")
            ' valor_hora_extra_calcular = DS2.Tables(DT2.TableName).Rows(0).Item("valor_hora_extra")
        End If
        conexion.Close()
    End Sub

    Private Sub Check_descuentos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_descuentos.CheckedChanged
        If Check_descuentos.Checked = True Then
            grilla_detalle.Columns(5).Visible = True
            grilla_detalle.Columns(6).Visible = True
            grilla_detalle.Columns(7).Visible = True
            '   grilla_detalle.Columns(8).Visible = True
        Else
            grilla_detalle.Columns(5).Visible = False
            grilla_detalle.Columns(6).Visible = False
            grilla_detalle.Columns(7).Visible = False
            ' grilla_detalle.Columns(8).Visible = False
        End If
    End Sub

    Private Sub Check_factor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_factor.CheckedChanged
        If Check_factor.Checked = True Then
            grilla_detalle.Columns(11).Visible = True
        Else
            grilla_detalle.Columns(11).Visible = False
        End If
    End Sub

    Private Sub Check_margen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_margen.CheckedChanged
        If Check_margen.Checked = True Then
            grilla_detalle.Columns(13).Visible = True
        Else
            grilla_detalle.Columns(13).Visible = False
        End If
    End Sub

    Private Sub Combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

        ' mostrar_datos_proveedores()
        'If e.KeyCode = Keys.Enter Then
        '    'Combo_rut.Text = Combo_rut.Text
        '    txt_codigo_producto.Focus()

        'End If

        If e.KeyChar = Chr(13) Then
            e.Handled = True


            moverEnfoque()
        End If
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    '    e.Handled = True


        '    '    moverEnfoque()
        'End If


        'If Asc(e.KeyChar) = 13 Then

        '    Combo_rut.Text = Combo_rut.Items(1)
        'End If


    End Sub

    Private Sub moverEnfoque()
        SendKeys.Send("{TAB}")
    End Sub




    Private Sub txt_descuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub txt_porcentaje_desc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.txt_porcentaje_desc.Text = Trim(Replace(Me.txt_porcentaje_desc.Text, " ", ""))
    '    desglose_factura()
    'End Sub



    Private Sub Radio_mas_iva_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_cantidad_agregar.Focus()
    End Sub

    Private Sub Radio_neto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_cantidad_agregar.Focus()
    End Sub

    Private Sub GroupBox_totales_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox_totales.Enter

    End Sub

    Private Sub txt_total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total.TextChanged
        Me.txt_total.Text = Trim(Replace(Me.txt_total.Text, " ", ""))
        desglose_factura()
    End Sub

    Private Sub Radio_neto_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '  Me.Radio_neto_TabStopChanged = False
        Radio_neto.TabStop = False
    End Sub

    Private Sub Combo_rut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    'Combo_rut.Text = Combo_rut.Text
        '    'txt_codigo_producto.Focus()

        'End If 'If e.KeyCode = Keys.Enter Then

        '    txt_codigo_producto.Focus()
        'End If
    End Sub

    Private Sub btn_actualizar_descuentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub btn_actualizar_descuentos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_actualizar_descuentos.BackColor = Color.LightSkyBlue
    'End Sub


    'Private Sub btn_actualizar_descuentos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_actualizar_descuentos.BackColor = Color.WhiteSmoke
    'End Sub



    Private Sub txt_cantidad_etiquetas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_etiquetas.KeyPress


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
            btn_agregar.PerformClick()
        End If
    End Sub

    'Private Sub Radio_precio_venta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_precio_venta.CheckedChanged
    '    txt_margen_producto.Enabled = False
    '    txt_margen_producto.BackColor = SystemColors.Control
    '    txt_precio_venta_producto.Enabled = True
    '    txt_precio_venta_producto.Focus()
    'End Sub

    'Private Sub Radio_margen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_margen.CheckedChanged
    '    txt_margen_producto.Enabled = True
    '    txt_precio_venta_producto.Enabled = False
    '    txt_precio_venta_producto.BackColor = SystemColors.Control
    '    txt_margen_producto.Focus()
    'End Sub

    Private Sub txt_cantidad_etiquetas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_etiquetas.TextChanged
        If txt_cantidad_etiquetas.Text = "0" Then
            txt_cantidad_etiquetas.SelectionStart = 0
            txt_cantidad_etiquetas.SelectionLength = Len(txt_cantidad_etiquetas.Text)
        End If
    End Sub

    Private Sub Radio_precio_venta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_precio_venta.CheckedChanged
        txt_cantidad_agregar.Focus()
        txt_precio_venta_producto.Text = "0"
        txt_factor.Text = "0"
        txt_precio_venta_producto.Width = (68)
        txt_precio_venta_producto.MaxLength = (11)
        lbl_venta.Text = "P. VENTA:"
    End Sub

    Private Sub Radio_margen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_margen.CheckedChanged

        txt_cantidad_agregar.Focus()
        txt_precio_venta_producto.Text = "0"
        txt_precio_venta_producto.Width = (54)
        txt_precio_venta_producto.MaxLength = (5)
        lbl_venta.Text = "MARGEN:"
    End Sub

    Private Sub Combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label26.Click

    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub



    Private Sub txt_rut_proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut_proveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_codigo_producto.Focus()
        End If
    End Sub

    Private Sub txt_rut_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_proveedor.KeyPress

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




        limpiar_proveedor_enter()
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            guion_rut()
            txt_codigo_producto.Focus()
        End If
    End Sub



    Private Sub txt_rut_proveedor_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.TextChanged
        mostrar_datos_proveedores_combo()
    End Sub

    Private Sub txt_rut_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.GotFocus
        txt_rut_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.LostFocus
        txt_rut_proveedor.BackColor = Color.White
    End Sub

    Private Sub btn_modificar_doc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar_doc.Click
        conexion.Close()
        Form_modificar_doc_compras.combo_documento.Text = combo_documento.Text
        Form_modificar_doc_compras.dtp_emision.Text = dtp_emision.Text
        Form_modificar_doc_compras.txt_rut_proveedor.Text = txt_rut_proveedor.Text
        Form_modificar_doc_compras.txt_nro_doc.Text = txt_nro_doc.Text
        Form_modificar_doc_compras.txt_total.Text = txt_total.Text

        Form_modificar_doc_compras.combo_documento_real.Text = combo_documento.Text
        Form_modificar_doc_compras.dtp_emision_real.Text = dtp_emision.Text
        Form_modificar_doc_compras.txt_rut_proveedor_real.Text = txt_rut_proveedor.Text
        Form_modificar_doc_compras.txt_nro_doc_real.Text = txt_nro_doc.Text
        Form_modificar_doc_compras.txt_total_real.Text = txt_total.Text

        Form_modificar_doc_compras.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_cargar_transporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Form_cargar_trasporte.Show()
        'Me.Enabled = False
    End Sub

    'Private Sub btn_cargar_transporte_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_cargar_transporte.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_cargar_transporte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_cargar_transporte.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_modificar_doc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar_doc.GotFocus
        btn_modificar_doc.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar_doc.LostFocus
        btn_modificar_doc.BackColor = Color.WhiteSmoke
    End Sub

    'Private Sub btn_salir_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_salir_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.WhiteSmoke
    'End Sub



    Private Sub btn_salir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    'Private Sub btn_salir_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_salir_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub txt_precio_venta_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio_venta_producto.TextChanged
        datos_producto_venta()
        If txt_precio_venta_producto.Text = "0" Then
            txt_precio_venta_producto.SelectionStart = 0
            txt_precio_venta_producto.SelectionLength = Len(txt_precio_venta_producto.Text)
        End If
    End Sub

    Private Sub txt_costo_actual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_costo_actual.TextChanged

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Sub cargar_compra()
        Me.grilla_detalle.Rows.Clear()

        If Form_cargar_compra.combo_documento.Text = "FACTURA ELECTRONICA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select cod_producto, nombre, cantidad,precio_unitario,  valor_unitario, detalle_compra.descuento, detalle_compra.descuento2, detalle_compra.descuento3, detalle_compra.neto, detalle_compra.iva, detalle_compra.total, factor, precio_venta, margen, detalle_compra.precio_anterior, detalle_compra.margen_anterior, detalle_compra.cod_auto from detalle_compra, compra where compra.tipo='FACTURA' and compra.tipo_emision='ELECTRONICA' and compra.n_compra=detalle_compra.n_compra and compra.n_compra='" & (Form_cargar_compra.txt_nro_doc.Text) & "' and compra.rut_proveedor='" & (Form_cargar_compra.txt_rut_proveedor.Text) & "' and detalle_compra.rut_proveedor='" & (Form_cargar_compra.txt_rut_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim cod_producto As String = ""
                    Dim tipo_medida As String = ""

                    cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (cod_producto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        tipo_medida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    Me.grilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("precio_unitario"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("descuento2"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("descuento3"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("factor"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("precio_venta"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("margen"), _
                                                             "INGRESADO", _
                                                              DS.Tables(DT.TableName).Rows(i).Item("precio_anterior"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("margen_anterior"), _
                                                                tipo_medida, _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("cod_auto"))
                Next
            End If
        End If

        If Form_cargar_compra.combo_documento.Text = "GUIA ELECTRONICA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select cod_producto, nombre, cantidad,precio_unitario,  valor_unitario, detalle_compra.descuento, detalle_compra.descuento2, detalle_compra.descuento3, detalle_compra.neto, detalle_compra.iva, detalle_compra.total, factor, precio_venta, margen, detalle_compra.precio_anterior, detalle_compra.margen_anterior, detalle_compra.cod_auto from detalle_compra, compra where compra.tipo='GUIA' and compra.tipo_emision='ELECTRONICA' and compra.n_compra=detalle_compra.n_compra and compra.n_compra='" & (Form_cargar_compra.txt_nro_doc.Text) & "' and compra.rut_proveedor='" & (Form_cargar_compra.txt_rut_proveedor.Text) & "' and detalle_compra.rut_proveedor='" & (Form_cargar_compra.txt_rut_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    Dim cod_producto As String = ""
                    Dim tipo_medida As String = ""

                    cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (cod_producto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        tipo_medida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    Me.grilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD_PRODUCTO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("PRECIO_UNITARIO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("VALOR_UNITARIO"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO2"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO3"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("NETO"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("IVA"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("FACTOR"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("PRECIO_venta"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("MARGEN"), _
                                                             "INGRESADO", _
                                                              DS.Tables(DT.TableName).Rows(i).Item("PRECIO_ANTERIOR"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("MARGEN_ANTERIOR"), _
                                                                tipo_medida, _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("cod_auto"))
                Next
            End If
        End If





        If Form_cargar_compra.combo_documento.Text = "FACTURA MANUAL" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select cod_producto, nombre, cantidad,precio_unitario,  valor_unitario, detalle_compra.descuento, detalle_compra.descuento2, detalle_compra.descuento3, detalle_compra.neto, detalle_compra.iva, detalle_compra.total, factor, precio_venta, margen, detalle_compra.precio_anterior, detalle_compra.margen_anterior, detalle_compra.cod_auto from detalle_compra, compra where compra.tipo='FACTURA' and compra.tipo_emision='MANUAL' and compra.n_compra=detalle_compra.n_compra and compra.n_compra='" & (Form_cargar_compra.txt_nro_doc.Text) & "' and compra.rut_proveedor='" & (Form_cargar_compra.txt_rut_proveedor.Text) & "' and detalle_compra.rut_proveedor='" & (Form_cargar_compra.txt_rut_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    Dim cod_producto As String = ""
                    Dim tipo_medida As String = ""

                    cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (cod_producto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        tipo_medida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    Me.grilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD_PRODUCTO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("PRECIO_UNITARIO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("VALOR_UNITARIO"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO2"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO3"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("NETO"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("IVA"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("FACTOR"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("PRECIO_venta"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("MARGEN"), _
                                                             "INGRESADO", _
                                                              DS.Tables(DT.TableName).Rows(i).Item("PRECIO_ANTERIOR"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("MARGEN_ANTERIOR"), _
                                                                tipo_medida, _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("cod_auto"))
                Next
            End If
        End If

        If Form_cargar_compra.combo_documento.Text = "GUIA MANUAL" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select cod_producto, nombre, cantidad,precio_unitario,  valor_unitario, detalle_compra.descuento, detalle_compra.descuento2, detalle_compra.descuento3, detalle_compra.neto, detalle_compra.iva, detalle_compra.total, factor, precio_venta, margen, detalle_compra.precio_anterior, detalle_compra.margen_anterior, detalle_compra.cod_auto from detalle_compra, compra where compra.tipo='GUIA' and compra.tipo_emision='MANUAL' and compra.n_compra=detalle_compra.n_compra and compra.n_compra='" & (Form_cargar_compra.txt_nro_doc.Text) & "' and compra.rut_proveedor='" & (Form_cargar_compra.txt_rut_proveedor.Text) & "' and detalle_compra.rut_proveedor='" & (Form_cargar_compra.txt_rut_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    Dim cod_producto As String = ""
                    Dim tipo_medida As String = ""

                    cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (cod_producto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        tipo_medida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    Me.grilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD_PRODUCTO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("PRECIO_UNITARIO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("VALOR_UNITARIO"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO2"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO3"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("NETO"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("IVA"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("FACTOR"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("PRECIO_venta"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("MARGEN"), _
                                                             "INGRESADO", _
                                                              DS.Tables(DT.TableName).Rows(i).Item("PRECIO_ANTERIOR"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("MARGEN_ANTERIOR"), _
                                                                tipo_medida, _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("cod_auto"))
                Next
            End If
        End If
        txt_item.Text = grilla_detalle.Rows.Count

        If grilla_detalle.Rows.Count <> 0 Then
            If grilla_detalle.Columns(0).Width = 90 Then
                grilla_detalle.Columns(0).Width = 89
            Else
                grilla_detalle.Columns(0).Width = 90
            End If
        End If

        Dim estado_ingreso As String

        For i = 0 To grilla_detalle.Rows.Count - 1
            estado_ingreso = grilla_detalle.Rows(i).Cells(14).Value.ToString
            If estado_ingreso = "INGRESADO" Then
                grilla_detalle.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        limpiar()
        '  controles(True, False)

        btn_modificar_doc.Enabled = False

        txt_precio_venta_producto.BackColor = SystemColors.Control
        combo_documento.Focus()

        conexion.Close()


        Form_cargar_compra.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_nueva_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.GotFocus
        btn_nueva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nueva_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.LostFocus
        btn_nueva.BackColor = Color.White
    End Sub



    Private Sub grilla_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_detalle.CellContentClick

    End Sub

    Private Sub grilla_detalle_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles grilla_detalle.CellValueNeeded

    End Sub

    Private Sub grilla_detalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_detalle.Click
        If grilla_detalle.Rows.Count = 0 Then
            Exit Sub
        End If

        'If grilla_detalle.CurrentRow.Cells(0).Value() = "*" Then
        '    Exit Sub
        'End If

        txt_codigo_producto.Text = grilla_detalle.CurrentRow.Cells(0).Value()
        txt_cantidad_agregar.Text = grilla_detalle.CurrentRow.Cells(2).Value()
        txt_precio_unitario_producto.Text = grilla_detalle.CurrentRow.Cells(3).Value()

        Dim total_descuento_decimal As String
        Dim total_descuento As Integer

        total_descuento_decimal = txt_cantidad_agregar.Text * txt_precio_unitario_producto.Text
        total_descuento_decimal = grilla_detalle.CurrentRow.Cells(5).Value() * 100 / total_descuento_decimal
        total_descuento = total_descuento_decimal
        Round(total_descuento)
        txt_descuento1.Text = total_descuento

        total_descuento_decimal = txt_cantidad_agregar.Text * txt_precio_unitario_producto.Text
        total_descuento_decimal = grilla_detalle.CurrentRow.Cells(6).Value() * 100 / total_descuento_decimal
        total_descuento = total_descuento_decimal
        Round(total_descuento)
        txt_descuento2.Text = total_descuento

        total_descuento_decimal = txt_cantidad_agregar.Text * txt_precio_unitario_producto.Text
        total_descuento_decimal = grilla_detalle.CurrentRow.Cells(7).Value() * 100 / total_descuento_decimal
        total_descuento = total_descuento_decimal
        Round(total_descuento)
        txt_descuento3.Text = total_descuento

        'total_descuento_decimal = txt_cantidad_agregar.Text * txt_precio_unitario_producto.Text
        'total_descuento_decimal = grilla_detalle.CurrentRow.Cells(8).Value() * 100 / total_descuento_decimal
        'total_descuento = total_descuento_decimal
        'Round(total_descuento)
        'txt_descuento4.Text = total_descuento

        txt_costo_actual.Text = grilla_detalle.CurrentRow.Cells(4).Value()
        txt_total_producto.Text = grilla_detalle.CurrentRow.Cells(8).Value()
        txt_precio_venta_producto.Text = grilla_detalle.CurrentRow.Cells(13).Value()

        mostrar_datos_productos()
        ' txt_precio_modificado.Text = grilla_detalle.CurrentRow.Cells(7).Value()
        'mostrar_nombre_proveedor()
        txt_cantidad_agregar.Focus()
    End Sub












    'va generando el calculo del neto iva total y descuento del documento, es decir de la suma de todos los productos ingresados.
    Sub calcular_totales()
        'Dim descgrilla As Integer
        'Dim netogrilla As Integer
        'Dim ivagrilla As Integer
        'Dim totalgrilla As Integer
        'Dim subtotalgrilla As Integer
        'Dim VarCantidad As Long
        'Dim descgrilla As Long
        'Dim netogrilla As Long
        'Dim ivagrilla As Long
        Dim totalgrilla As Long
        'Dim subtotalgrilla As Long
        'Dim ProductosGrilla As Long


        '//Calcular el total general
        txt_total.Text = 0
        For i = 0 To grilla_detalle.Rows.Count - 1
            totalgrilla = Val(grilla_detalle.Rows(i).Cells(10).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        '' '' ''txt_productos.Text = 0
        '' '' ''For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '' '' ''    ProductosGrilla = Val(grilla_detalle_venta.Rows(i).Cells(4).Value.ToString)
        '' '' ''    txt_productos.Text = Val(txt_productos.Text) + Val(ProductosGrilla)
        '' '' ''Next



        'Dim iva As Integer
        'Dim neto As Integer
        'Dim iva_valor As String

        'iva_valor = valor_iva / 100 + 1
        'neto = (txt_total.Text / iva_valor)
        'Round(neto)
        'txt_neto.Text = neto

        'iva = ((txt_neto.Text) * valor_iva / 100)
        'Round(iva)
        'txt_iva.Text = iva






        'iva_valor = valor_iva / 100 + 1

        'txt_neto.Text = Round(txt_total.Text / iva_valor)

        'txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)

        'txt_iva.Text = (txt_total.Text) - (txt_neto.Text)

    End Sub
End Class