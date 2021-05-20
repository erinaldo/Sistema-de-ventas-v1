Imports System.IO
Imports System.Drawing.Printing
Imports System.Math
Imports System.Drawing.Drawing2D

Public Class Form_enviar_documento
    Dim total_registros As Integer
    Dim varnumfactura As Integer
    Dim peso As String
    Dim pesos As String
    Dim mifecha2 As String
    ' Dim mifecha4 As String
    ' Dim mifecha2 As String
    'Dim mifecha4 As String
    ' Dim mifecha6 As String
    Dim txt_factor_ingresar As String
    Private WithEvents Pd As New PrintDocument
    'Dim impreso As Integer = 0
    Dim impresora_envios_sucursal As String

    Private Sub Form_enviar_documento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_envio_productos_sucursal.WindowState = FormWindowState.Normal
        Form_envio_productos_sucursal.Enabled = True
        'grabar_documento_temporal()
    End Sub

    Private Sub Form_enviar_documento_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp


        If e.KeyCode = Keys.F5 Then
            txt_rut_proveedor.Focus()
        End If


        If e.KeyCode = Keys.F9 Then
            btn_cargar.PerformClick()
        End If

        If e.KeyCode = Keys.F12 Then
            btn_grabar.PerformClick()
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
            '    form_Menu_admin.Enabled = False
            Form_menu_principal.Close()

        End If

    End Sub
    Private Sub Form_enviar_documento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        controles(True, False)

        'TextBox1.Text = ActiveControl.Name

        'fecha()
        'fecha2()
        llenar_combo_vendedor()
        '   dtp_emision.CustomFormat = "yyy-MM-dd"
        valores()
        'llenar_combo_rut()
        cargar_logo()
        '  cargar_compra_temporal()


        grilla_detalle.Columns(6).Visible = False
        grilla_detalle.Columns(7).Visible = False
        grilla_detalle.Columns(8).Visible = False







        grilla_detalle.Columns(12).Visible = False

        grilla_detalle.Columns(14).Visible = False

        grilla_detalle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)




        llenar_combo_sucursales()




        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'SC.Connection = conexion
        'SC.CommandText = "select * from proveedores"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'Dim col As New AutoCompleteStringCollection
        'Dim i As Integer
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then


        '    For i = 0 To DS.Tables(0).Rows.Count - 1
        '        col.Add(DS.Tables(0).Rows(i)("rut_proveedor").ToString())
        '    Next
        '    txt_rut_proveedor.AutoCompleteSource = AutoCompleteSource.CustomSource
        '    txt_rut_proveedor.AutoCompleteCustomSource = col
        '    txt_rut_proveedor.AutoCompleteMode = AutoCompleteMode.Suggest
        'End If




        'txt_rut_proveedor.AutoCompleteSource = AutoCompleteSource.CustomSource
        'txt_rut_proveedor.AutoCompleteCustomSource = col
        'txt_rut_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend


        conexion.Close()











        If grilla_detalle.Rows.Count = 0 Then
            controles(False, True)
            'btn_modificar_doc.Enabled = False
            Form_cargar_compra_documento.Show()
            Me.Enabled = False
            Form_cargar_compra_documento.txt_rut_proveedor.Focus()

        End If



        grilla_detalle.Columns(0).ReadOnly = True
        grilla_detalle.Columns(1).ReadOnly = True
        grilla_detalle.Columns(2).ReadOnly = True
        grilla_detalle.Columns(3).ReadOnly = False
        grilla_detalle.Columns(4).ReadOnly = True
        grilla_detalle.Columns(5).ReadOnly = True
        grilla_detalle.Columns(6).ReadOnly = True
        grilla_detalle.Columns(7).ReadOnly = True
        grilla_detalle.Columns(8).ReadOnly = True
        grilla_detalle.Columns(9).ReadOnly = True
        grilla_detalle.Columns(10).ReadOnly = True
        grilla_detalle.Columns(11).ReadOnly = True
        grilla_detalle.Columns(12).ReadOnly = True
        grilla_detalle.Columns(13).ReadOnly = True
        grilla_detalle.Columns(14).ReadOnly = True
        grilla_detalle.Columns(15).ReadOnly = True
        grilla_detalle.Columns(16).ReadOnly = True
        grilla_detalle.Columns(17).ReadOnly = True
        grilla_detalle.Columns(18).ReadOnly = True
        grilla_detalle.Columns(19).ReadOnly = False
        'grilla_detalle.Columns(20).ReadOnly = True

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
            impresora_envios_sucursal = DS.Tables(DT.TableName).Rows(0).Item("ticket_envios_sucursal")
        End If
        conexion.Close()
    End Sub

    Sub llenar_combo_sucursales()
        Combo_sucursal.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from sucursales  where nombre_sucursal <> '" & (mirecintoempresa) & "' order by nombre_sucursal"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        Combo_sucursal.Items.Add("-")

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
            Next
        End If
        Combo_sucursal.SelectedItem = "-"
        conexion.Close()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
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

    'Sub crear_codigo_ingreso()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    Try
    '        SC.Connection = conexion
    '        SC.CommandText = "select max(codigo) as codigo from compra"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)

    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            ' lbl_ingreso.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo")
    '            'lbl_ingreso.Text = varnumfactura + 1
    '        End If
    '    Catch err As InvalidCastException
    '        'lbl_ingreso.Text = 1
    '    End Try
    '    conexion.Close()

    'End Sub

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
            'lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
            txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            'txt_telefono_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_proveedor")
            'txt_ciudad.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_proveedor")
            'txt_direcion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_proveedor")
            'txt_codigo_producto.Focus()
        Else
            '     MsgBox("RUT NO ENCONTRADO", 0 + 16, "ERROR")
            txt_rut_proveedor.Focus()
        End If
        conexion.Close()
        ' End If
    End Sub

    Sub mostrar_datos_proveedores_combo()
        If txt_rut_proveedor.Text <> "" Then
            'limpiar_proveedor()
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
                'lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
                txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
                'txt_telefono_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_proveedor")
            End If
            conexion.Close()
        End If
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

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
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
                                                        DS.Tables(DT.TableName).Rows(i).Item("margen_anterior"))
            Next
            'txt_codigo_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_compra")
            r_margen = DS.Tables(DT.TableName).Rows(0).Item("radio_margen")
            r_neto = DS.Tables(DT.TableName).Rows(0).Item("radio_neto")
            'txt_descuento1.Text = DS.Tables(DT.TableName).Rows(0).Item("campo_descuento")
            'txt_descuento2.Text = DS.Tables(DT.TableName).Rows(0).Item("campo_descuento2")
            'txt_descuento3.Text = DS.Tables(DT.TableName).Rows(0).Item("campo_descuento3")
            'txt_descuento4.Text = DS.Tables(DT.TableName).Rows(0).Item("campo_descuento4")
            'txt_emision.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_emision")
            txt_nro_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_documento")
            'txt_tipo_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_documento")
            'txt_total.Text = DS.Tables(DT.TableName).Rows(0).Item("total_documento")
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
        'txt_emision.Enabled = a
        ''btn_agregar.Enabled = a
        ''btn_quitar_elemento.Enabled = a
        'btn_grabar.Enabled = a
        ''btn_limpiar.Enabled = a
        ''btn_agregar_producto.Enabled = a
        ''btn_agregar_proveedor.Enabled = a
        'btn_cargar.Enabled = a
        ''btn_nueva.Enabled = b
        ''btn_buscar_productos.Enabled = a

        ''  btn_modificar_doc.Enabled = a
        ''btn_cargar_transporte.Enabled = a

        ''txt_cantidad_etiquetas.Enabled = a


        'GroupBox_tipo.Enabled = a

        'txt_nro_doc.Enabled = a

        'txt_costo_actual.Enabled = a

        'txt_total_producto.Enabled = a

        ''txt_cantidad_agregar.Enabled = a
        'txt_precio_venta_producto.Enabled = a
        ''txt_descuento1.Enabled = a
        ''txt_descuento2.Enabled = a
        ''txt_descuento3.Enabled = a
        ''txt_descuento4.Enabled = a
        'txt_rut_proveedor.Enabled = a
        ''txt_codigo_producto.Enabled = a
        'txt_neto.Enabled = a
        'txt_iva.Enabled = a
        'txt_total.Enabled = a
        'txt_precio_venta_producto.Enabled = a
        ''txt_precio_unitario_producto.Enabled = a
        'txt_factor.Enabled = a

        'Check_descuentos.Enabled = a
        'Check_factor.Enabled = a
        'Check_margen.Enabled = a

        'txt_tipo_doc.Enabled = a
        'txt_emision.Enabled = a
        'Radio_margen.Enabled = a
        'Radio_precio_venta.Enabled = a
        'grilla_detalle.Enabled = a

        ''GroupBox_descuento.Enabled = a
        'GroupBox_documento.Enabled = a
        ''GroupBox_ingreso.Enabled = a
        ''GroupBox_producto.Enabled = a
        'GroupBox_proveedor.Enabled = a
        'GroupBox_tipo_precio.Enabled = a
        'GroupBox_totales.Enabled = a

        'GroupBox_columnas.Enabled = a
        'GroupBox_valores.Enabled = a
        ''GroupBox_etiquetas.Enabled = a

        'Radio_neto.Checked = True
        'Radio_margen.Checked = True

        ''If txt_rut_proveedor.Enabled = True Then
        ''    txt_rut_proveedor.BackColor = Color.White
        ''Else
        ''    txt_rut_proveedor.BackColor = SystemColors.Control
        ''End If

        ''If txt_nro_doc.Enabled = True Then
        ''    txt_nro_doc.BackColor = Color.White
        ''Else
        ''    txt_nro_doc.BackColor = SystemColors.Control
        ''End If

        ''If txt_cantidad_agregar.Enabled = True Then
        ''    txt_cantidad_agregar.BackColor = Color.White
        ''Else
        ''    txt_cantidad_agregar.BackColor = SystemColors.Control
        ''End If

        ''If txt_precio_venta_producto.Enabled = True Then
        ''    txt_precio_venta_producto.BackColor = Color.White
        ''Else
        ''    txt_precio_venta_producto.BackColor = SystemColors.Control
        ''End If

        ''If txt_descuento1.Enabled = True Then
        ''    txt_descuento1.BackColor = Color.White
        ''Else
        ''    txt_descuento1.BackColor = SystemColors.Control
        ''End If

        ''If txt_descuento2.Enabled = True Then
        ''    txt_descuento2.BackColor = Color.White
        ''Else
        ''    txt_descuento2.BackColor = SystemColors.Control
        ''End If

        ''If txt_descuento3.Enabled = True Then
        ''    txt_descuento3.BackColor = Color.White
        ''Else
        ''    txt_descuento3.BackColor = SystemColors.Control
        ''End If

        ''If txt_descuento4.Enabled = True Then
        ''    txt_descuento4.BackColor = Color.White
        ''Else
        ''    txt_descuento4.BackColor = SystemColors.Control
        ''End If

        ''If txt_rut_proveedor.Enabled = True Then
        ''    txt_rut_proveedor.BackColor = Color.White
        ''Else
        ''    txt_rut_proveedor.BackColor = SystemColors.Control
        ''End If

        ''If txt_codigo_producto.Enabled = True Then
        ''    txt_codigo_producto.BackColor = Color.White
        ''Else
        ''    txt_codigo_producto.BackColor = SystemColors.Control
        ''End If

        ''If txt_total.Enabled = True Then
        ''    txt_total.BackColor = Color.White
        ''Else
        ''    txt_total.BackColor = SystemColors.Control
        ''End If

        ''If txt_cantidad_etiquetas.Enabled = True Then
        ''    txt_cantidad_etiquetas.BackColor = Color.White
        ''Else
        ''    txt_cantidad_etiquetas.BackColor = SystemColors.Control
        ''End If

        ''If combo_documento.Enabled = True Then
        ''    combo_documento.BackColor = Color.White
        ''Else
        ''    combo_documento.BackColor = SystemColors.Control
        ''End If

        ''If txt_precio_venta_producto.Enabled = True Then
        ''    txt_precio_venta_producto.BackColor = Color.White
        ''Else
        ''    txt_precio_venta_producto.BackColor = SystemColors.Control
        ''End If

        ''If txt_precio_unitario_producto.Enabled = True Then
        ''    txt_precio_unitario_producto.BackColor = Color.White
        ''Else
        ''    txt_precio_unitario_producto.BackColor = SystemColors.Control
        ''End If

    End Sub






    'Sub imprimir_etiquetas()
    '    Dim cantidad_etiquetas As Integer

    '    If txt_cantidad_etiquetas.Text = "0" Or txt_cantidad_etiquetas.Text = "" Then
    '        cantidad_etiquetas = 0
    '    Else
    '        cantidad_etiquetas = txt_cantidad_etiquetas.Text
    '    End If

    '    If cantidad_etiquetas <> "0" Then


    '        With Pd.PrinterSettings
    '            ' Especifico el nombre de la impresora 
    '            ' por donde deseo imprimir. 

    '            If Radio_impresora_1.Checked = True Then
    '                .PrinterName = impresora_etiquetas
    '            Else
    '                .PrinterName = impresora_etiquetas_2
    '            End If



    '            'If Radio_impresora_1.Checked = True Then
    '            '    .PrinterName = "ZDesigner LP 2824"
    '            'Else
    '            '    .PrinterName = "ZDesigner LP 2824"
    '            'End If
    '            ' Establezco el número de copias que se imprimirán 

    '            .Copies = cantidad_etiquetas
    '            ' Rango de páginas que se imprimirán 
    '            .PrintRange = PrintRange.AllPages
    '            If .IsValid Then
    '                Me.Pd.PrintController = New StandardPrintController
    '                Dim pkCustomSize1 As New PaperSize("New Long Roll", 300, 99)
    '                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

    '                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
    '                Pd.Print()
    '            Else
    '            End If
    '        End With

    '    End If
    'End Sub

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
            btn_cargar.Focus()
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

        If txt_nro_doc.Text = "" Then
            MsgBox("CAMPO NRO. DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc.Focus()
            Exit Sub
        End If

        If Combo_sucursal.Text = "" Then
            MsgBox("CAMPO SUCURSAL VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_sucursal.Focus()
            Exit Sub
        End If

        If Combo_sucursal.Text = "-" Then
            MsgBox("CAMPO SUCURSAL VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_sucursal.Focus()
            Exit Sub
        End If

        If Combo_vendedor.Text = "" Then
            MsgBox("CAMPO DESPACHADOR VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_vendedor.Focus()
            Exit Sub
        End If

        If Combo_vendedor.Text = "-" Then
            MsgBox("CAMPO DESPACHADOR VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_vendedor.Focus()
            Exit Sub
        End If

        'ElseIf combo_condiciones.Text = "" Then
        '    mensaje = "CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '    combo_condiciones.Focus()
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

        Dim valormensaje As Integer
        'valormensaje = MsgBox("¿Esta seguro que estos datos son los correctos?: " & vbCrLf & "" & vbCrLf & "TIPO      : " & (combo_documento.Text) & " " & vbCrLf & "Fecha     : " & (dtp1.Text) & " " & vbCrLf & "Numero : " & (txt_nro_doc.Text) & " " & vbCrLf & "Total         : " & (txt_total_final.Text) & " ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Verificar datos del documento")


        valormensaje = MsgBox("¿ESTA SEGURO QUE ESTOS DATOS SON LOS CORRECTOS?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        'fecha2()
        If valormensaje = vbYes Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            totales()
            Form_envio_productos_sucursal.crear_nro_vale()

            'fecha2()
            'crear_codigo_compra()
            'grabar_factura()

            With Pd.PrinterSettings
                .PrinterName = impresora_envios_sucursal
                .Copies = 1
                .PrintRange = PrintRange.AllPages
                If .IsValid Then
                    Me.Pd.PrintController = New StandardPrintController
                    'Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 4000)
                    'Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

                    Pd.PrinterSettings.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("1", 280, 13000)

                    Dim rollo As New PaperSize("New Long Roll", 280, 1900)

                    Pd.DefaultPageSettings.PaperSize = rollo

                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                    Pd.Print()
                Else
                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End With

            grabar_detalle_factura()
            ' MsgBox("DOCUMENTO GRABADO CON EXITO")
            MsgBox("DOCUMENTO ENVIADO CON EXITO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            Me.Close()
            controles(False, True)

            txt_rut_proveedor.Enabled = False
            txt_nro_doc.Enabled = False

            lbl_mensaje.Visible = False
            Me.Enabled = True


        End If

    End Sub


    Sub totales()
        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String
        Dim preciogrilla As Long
        Dim cantidadgrilla As Long
        Dim totalgrilla As Long

        txt_total.Text = 0
        For i = 0 To grilla_detalle.Rows.Count - 1
            cantidadgrilla = grilla_detalle.Rows(i).Cells(3).Value.ToString
            preciogrilla = grilla_detalle.Rows(i).Cells(4).Value.ToString
            totalgrilla = cantidadgrilla * preciogrilla
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next


        iva_valor = valor_iva / 100 + 1
        neto = (txt_total.Text / iva_valor)
        Round(neto)
        txt_neto.Text = neto

        iva = ((txt_neto.Text) * valor_iva / 100)
        Round(iva)
        txt_iva.Text = iva
    End Sub

    'graba el detalle de la factura y actualiza la antidad de productos.
    Sub grabar_detalle_factura()

        Dim VarCodProducto As String
        Dim varnombre As String
        Dim VarCantidad As Integer
        'Dim VarCantidadEnviada As Integer
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

        ' Dim VarSaldo As Integer
        'Dim VarCantidadProducto As Integer
        VarMargen = ""

        'fecha2()

        For i = 0 To grilla_detalle.Rows.Count - 1
            If grilla_detalle.Rows(i).Cells(19).Value = True Then
                VarCodProducto = grilla_detalle.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle.Rows(i).Cells(1).Value.ToString
                'VarCantidad = grilla_detalle.Rows(i).Cells(2).Value.ToString
                VarCantidad = grilla_detalle.Rows(i).Cells(3).Value.ToString
                VarPrecioUnitario = grilla_detalle.Rows(i).Cells(4).Value.ToString
                VarCosto = grilla_detalle.Rows(i).Cells(5).Value.ToString
                VarDescuento = grilla_detalle.Rows(i).Cells(6).Value.ToString
                VarDescuento2 = grilla_detalle.Rows(i).Cells(7).Value.ToString
                VarDescuento3 = grilla_detalle.Rows(i).Cells(8).Value.ToString
                ' VarDescuento4 = grilla_detalle.Rows(i).Cells(8).Value.ToString
                VarNeto = grilla_detalle.Rows(i).Cells(9).Value.ToString
                VarIva = grilla_detalle.Rows(i).Cells(10).Value.ToString
                VarTotal = grilla_detalle.Rows(i).Cells(11).Value.ToString
                varFactor = grilla_detalle.Rows(i).Cells(12).Value.ToString
                VarPrecioVenta = grilla_detalle.Rows(i).Cells(13).Value.ToString

                If VarMargen = "" Then
                    VarMargen = "0"
                End If

                VarMargen = grilla_detalle.Rows(i).Cells(14).Value.ToString
                VarEstado = grilla_detalle.Rows(i).Cells(15).Value.ToString
                VarPrecioAnterior = grilla_detalle.Rows(i).Cells(16).Value.ToString
                VarMargenAnterior = grilla_detalle.Rows(i).Cells(17).Value.ToString

                Form_envio_productos_sucursal.txt_codigo.Text = VarCodProducto
                Form_envio_productos_sucursal.mostrar_datos_productos()
                Form_envio_productos_sucursal.txt_cantidad.Text = VarCantidad
                Form_envio_productos_sucursal.Combo_sucursal.Text = Combo_sucursal.Text







                SC.Connection = conexion
                SC.CommandText = "insert into vale (n_vale, despachador, codigo_producto, cantidad, fecha, hora, estado, usuario_responsable, sucursal) values(" & (Form_envio_productos_sucursal.txt_nro_vale.Text) & ", '" & (Combo_vendedor.Text) & "', '" & (Form_envio_productos_sucursal.txt_codigo.Text) & "','" & (Form_envio_productos_sucursal.txt_cantidad.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','EMITIDA','" & (miusuario) & "','" & (Combo_sucursal.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (Form_envio_productos_sucursal.txt_nro_vale.Text) & ",'VALE DE TRASLADO', '" & (Form_envio_productos_sucursal.txt_codigo.Text) & "','" & (Form_envio_productos_sucursal.txt_nombre_producto.Text) & "'," & (Form_envio_productos_sucursal.txt_precio.Text) & ",'" & (Form_envio_productos_sucursal.txt_cantidad.Text) & "'," & (0) & "," & (Form_envio_productos_sucursal.txt_neto.Text) & ", " & (Form_envio_productos_sucursal.txt_iva.Text) & "," & (Form_envio_productos_sucursal.txt_total.Text) & "," & (Form_envio_productos_sucursal.txt_total.Text) & ",'SALE','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (miusuario) & "' ,'EMITIDA')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                Form_envio_productos_sucursal.crear_conexion()

                'SC.Connection = conexion
                'SC.CommandText = "insert into vale_traslado_recibidos (n_vale, despachador, codigo_producto, cantidad, fecha, hora, estado, usuario_responsable, sucursal, nombre, aplicacion, nro_tecnico, marca, cod_barra, familia, subfamilia, subfamilia2, cantidad_minima, precio, tipo_precio, factor, costo, rut_proveedor, fecha_ult_compra, cant_ult_compra, tipo_doc, nro_doc) values(" & (Form_envio_productos_sucursal.txt_nro_vale.Text) & ", '" & (Form_envio_productos_sucursal.Combo_vendedor.Text) & "', '" & (Form_envio_productos_sucursal.txt_codigo.Text) & "','" & (Form_envio_productos_sucursal.txt_cantidad.Text) & "','" & (form_Menu_admin.dtp_fecha.Text) & "','" & (form_Menu_admin.lbl_hora.Text) & "','EMITIDA','" & (miusuario) & "','" & (mirecintoempresa) & "', '" & (Form_envio_productos_sucursal.txt_nombre_producto.Text) & "', '" & (Form_envio_productos_sucursal.txt_aplicacion.Text) & "', '" & (Form_envio_productos_sucursal.txt_numero_tecnico.Text) & "', '" & (Form_envio_productos_sucursal.txt_marca.Text) & "', '" & (Form_envio_productos_sucursal.txt_codigo_barra.Text) & "', '" & (Form_envio_productos_sucursal.txt_codigo_familia.Text) & "', '" & (Form_envio_productos_sucursal.txt_codigo_subfamilia.Text) & "', '" & (Form_envio_productos_sucursal.txt_codigo_subfamilia_2.Text) & "', '" & (Form_envio_productos_sucursal.txt_cantidad_minima.Text) & "', '" & (Form_envio_productos_sucursal.txt_precio.Text) & "', '" & (Form_envio_productos_sucursal.txt_tipo_precio.Text) & "', '" & (Form_envio_productos_sucursal.txt_factor.Text) & "', '" & (Form_envio_productos_sucursal.txt_costo.Text) & "', '" & (Form_envio_productos_sucursal.txt_rut_proveedor.Text) & "', '" & (Form_envio_productos_sucursal.dtp_ultima_compra.Text) & "', '" & (Form_envio_productos_sucursal.txt_cantidad_ultima_compra.Text) & "', '" & (Form_envio_productos_sucursal.txt_tipo_doc.Text) & "', '" & (Form_envio_productos_sucursal.txt_nro_doc.Text) & "')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                recuperar_conexion_actual()
                Form_envio_productos_sucursal.limpiar()
                Form_envio_productos_sucursal.mostrar_malla()

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

    End Sub




    Private Sub combo_documento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txt_nro_doc.Focus()
        End If
    End Sub

    Private Sub combo_documento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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





    Private Sub txt_factura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.LostFocus
        txt_nro_doc.BackColor = Color.White
    End Sub

 

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

  


    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar.Click
        conexion.Close()
        Form_cargar_compra_documento.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.GotFocus
        btn_cargar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.LostFocus
        btn_cargar.BackColor = Color.Transparent
    End Sub

    Private Sub txt_total_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

        If e.KeyChar = Chr(13) Then
            e.Handled = True
        End If
    End Sub

    Sub cargar_compra()
        Me.grilla_detalle.Rows.Clear()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        ' SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (txt_cargar.Text) & "'"
        SC.CommandText = "select cod_producto, nombre, cantidad,precio_unitario,  valor_unitario, detalle_compra.descuento, detalle_compra.descuento2, detalle_compra.descuento3, detalle_compra.neto, detalle_compra.iva, detalle_compra.total, factor, precio_venta, margen, detalle_compra.precio_ANTERIOR, detalle_compra.margen_ANTERIOR , detalle_compra.cod_auto  from detalle_compra,COMPRA where compra.n_compra=detalle_compra.n_compra and compra.n_compra='" & (Form_cargar_compra_documento.txt_nro_doc.Text) & "' and compra.rut_proveedor='" & (Form_cargar_compra_documento.txt_rut_proveedor.Text) & "' and detalle_compra.rut_proveedor='" & (Form_cargar_compra_documento.txt_rut_proveedor.Text) & "' group by cod_producto"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)


        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Me.grilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD_PRODUCTO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
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
                                                            DS.Tables(DT.TableName).Rows(i).Item("COD_AUTO"))
            Next
        End If

     






        If grilla_detalle.Rows.Count <> 0 Then
            If grilla_detalle.Columns(0).Width = 90 Then
                grilla_detalle.Columns(0).Width = 89
            Else
                grilla_detalle.Columns(0).Width = 90
            End If
        End If

    End Sub



   

   














    Private Sub Label28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    TextBox1.Text = ActiveControl.Name
    'End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Radio_neto_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_neto.CheckedChanged

    End Sub






    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    'dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("numero", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("hora", GetType(String)))
    '    dt.Columns.Add(New DataColumn("encargado", GetType(String)))
    '    dt.Columns.Add(New DataColumn("despachador", GetType(String)))
    '    dt.Columns.Add(New DataColumn("origen", GetType(String)))
    '    dt.Columns.Add(New DataColumn("destino", GetType(String)))
    '    dt.Columns.Add(New DataColumn("codigo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
    '    dt.Columns.Add(New DataColumn("numero_tecnico", GetType(String)))

    '    Dim Varcodigo As String
    '    Dim Vardescripcion As String
    '    Dim Varcantidad As String
    '    Dim numero_tecnico As String

    '    For i = 0 To grilla_detalle.Rows.Count - 1
    '        If grilla_detalle.Rows(i).Cells(19).Value = True Then
    '            Varcodigo = grilla_detalle.Rows(i).Cells(0).Value.ToString
    '            Vardescripcion = grilla_detalle.Rows(i).Cells(1).Value.ToString
    '            Varcantidad = grilla_detalle.Rows(i).Cells(2).Value

    '            conexion.Close()
    '            DS3.Tables.Clear()
    '            DT3.Rows.Clear()
    '            DT3.Columns.Clear()
    '            DS3.Clear()
    '            conexion.Open()
    '            SC3.Connection = conexion
    '            SC3.CommandText = "select * from productos where cod_producto ='" & (Varcodigo) & "'"
    '            DA3.SelectCommand = SC3
    '            DA3.Fill(DT3)
    '            DS3.Tables.Add(DT3)
    '            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
    '                numero_tecnico = DS3.Tables(DT3.TableName).Rows(0).Item("numero_tecnico")
    '            End If
    '            conexion.Close()

    '            dr = dt.NewRow()

    '            'Try
    '            '    dr("Imagen") = Imagen_reporte
    '            'Catch
    '            'End Try

    '            dr("numero") = Form_envio_productos_sucursal.txt_nro_vale.Text
    '            dr("fecha") = Form_menu_principal.dtp_fecha.Text
    '            dr("hora") = Form_menu_principal.lbl_hora.Text
    '            dr("encargado") = minombre
    '            dr("despachador") = Combo_vendedor.Text
    '            dr("origen") = mirecintoempresa
    '            dr("destino") = Combo_sucursal.Text
    '            dr("codigo") = Varcodigo
    '            dr("descripcion") = Vardescripcion & " " & ""
    '            dr("cantidad") = Varcantidad
    '            dr("numero_tecnico") = numero_tecnico

    '            dt.Rows.Add(dr)
    '        End If
    '    Next

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "ticket_traspaso_sucursal"
    '    Dim iDS As New DS_ticket_traspaso_sucursal
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function

    Sub llenar_combo_vendedor()
        Combo_vendedor.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios WHERE ACTIVO='SI' order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        Combo_vendedor.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        Combo_vendedor.SelectedItem = ("-")

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

        e.KeyChar = e.KeyChar.ToString.ToUpper

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Combo_sucursal.Focus()
            Combo_sucursal.DroppedDown = True
        End If
    End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        mostrar_datos_vendedor()
    End Sub

    Private Sub grilla_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_detalle.CellContentClick

    End Sub

    Private Sub grilla_detalle_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_detalle.CellValueChanged




        If grilla_detalle.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim cantidad As Integer
        Dim cantidad_enviar As Integer
        cantidad = Val(grilla_detalle.CurrentRow.Cells(2).Value)
        cantidad_enviar = Val(grilla_detalle.CurrentRow.Cells(3).Value)

        ' obtener indice de la columna  
        Dim columna As Integer = grilla_detalle.CurrentCell.ColumnIndex

    
        cantidad_enviar = Val(grilla_detalle.CurrentRow.Cells(3).Value)

        If Val(cantidad) < Val(cantidad_enviar) Then
            MsgBox("LA CANTIDAD ES MAYOR A LA INDICADA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            grilla_detalle.CurrentRow.Cells(3).Value = grilla_detalle.CurrentRow.Cells(2).Value
            Exit Sub
        End If


    End Sub

    Private Sub grilla_detalle_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grilla_detalle.EditingControlShowing

        Dim validar As TextBox = CType(e.Control, TextBox)

        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress




    End Sub


    Private Sub validar_Keypress( _
       ByVal sender As Object, _
       ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim cantidad As Integer
        Dim cantidad_enviar As Integer
        cantidad = Val(grilla_detalle.CurrentRow.Cells(2).Value)
        cantidad_enviar = Val(grilla_detalle.CurrentRow.Cells(3).Value)

        ' obtener indice de la columna  
        Dim columna As Integer = grilla_detalle.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna 1 o 3  
        If columna = 3 Then
            cantidad_enviar = Val(grilla_detalle.CurrentRow.Cells(3).Value)

            If Val(cantidad) < Val(cantidad_enviar) Then
                MsgBox("LA CANTIDAD ES MAYOR A LA INDICADA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                grilla_detalle.CurrentRow.Cells(3).Value = grilla_detalle.CurrentRow.Cells(2).Value
                Exit Sub
            End If
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' comprobar si el caracter es un número o el retroceso  
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar  
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub


    Private Sub grilla_detalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grilla_detalle.KeyPress
        'e.KeyChar = e.KeyChar.ToString.ToUpper

        'If e.KeyChar = "'" Then
        '    e.KeyChar = "´"
        'End If

        'If e.KeyChar = "&" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = Chr(34) Then
        '    e.KeyChar = "´´"
        'End If

        'If e.KeyChar = "\" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "|" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "¿" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "?" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "}" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "{" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "<" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = ">" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "*" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "+" Then
        '    e.KeyChar = ""
        'End If




        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If



    End Sub

    Private Sub Check_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_todos.CheckedChanged
        If Check_todos.Checked = True Then
            For i = 0 To grilla_detalle.Rows.Count - 1
                grilla_detalle.Rows(i).Cells(19).Value = True
            Next
        Else
            For i = 0 To grilla_detalle.Rows.Count - 1
                grilla_detalle.Rows(i).Cells(19).Value = False
            Next
        End If
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

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

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim stringFormat_left As New StringFormat()
        stringFormat_left.Alignment = StringAlignment.Near
        stringFormat_left.LineAlignment = StringAlignment.Near

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 250, margen_superior + 15)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 250, margen_superior + 15)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 250, margen_superior + 15)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 250, margen_superior + 15)
        Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 250, margen_superior + 15)
        Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 250, margen_superior + 15)
        Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 250, margen_superior + 15)
        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 250, margen_superior + 15)

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("TRASPASO A SUCURSAL", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NUMERO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 245)
        e.Graphics.DrawString(Form_envio_productos_sucursal.txt_nro_vale.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 260)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 260)

        e.Graphics.DrawString("HORA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 275)
        e.Graphics.DrawString(Form_menu_principal.lbl_hora.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 275)

        e.Graphics.DrawString("ENCARGADO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 290)
        e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 290)

        e.Graphics.DrawString("DESPACHADOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 305)
        e.Graphics.DrawString(Combo_vendedor.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 305)

        e.Graphics.DrawString("ORIGEN", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 320)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 320)
        e.Graphics.DrawString(mirecintoempresa, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 320)

        e.Graphics.DrawString("DESTINO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 335)
        e.Graphics.DrawString(Combo_sucursal.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 335)

        e.Graphics.DrawString("CODIGO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 365)
        e.Graphics.DrawString("DESCRIPCION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 365)
        e.Graphics.DrawString("CANTIDAD", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 265, margen_superior + 365, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 380, margen_izquierdo + 270, margen_superior + 380)








        Dim Varcodigo As String = ""
        Dim Vardescripcion As String = ""
        Dim Varcantidad As String = ""
        Dim numero_tecnico As String = ""
        Dim multiplicador_lineas As Integer = 30
        Dim numero_lineas As Integer = 0

        For i = 0 To grilla_detalle.Rows.Count - 1
            If grilla_detalle.Rows(i).Cells(19).Value = True Then
                Varcodigo = grilla_detalle.Rows(i).Cells(0).Value.ToString
                Vardescripcion = grilla_detalle.Rows(i).Cells(1).Value.ToString
                Varcantidad = grilla_detalle.Rows(i).Cells(2).Value

                conexion.Close()
                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()
                SC3.Connection = conexion
                SC3.CommandText = "select * from productos where cod_producto ='" & (Varcodigo) & "'"
                DA3.SelectCommand = SC3
                DA3.Fill(DT3)
                DS3.Tables.Add(DT3)
                If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                    numero_tecnico = DS3.Tables(DT3.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If Vardescripcion.Length > 20 Then
                    Vardescripcion = Vardescripcion.Substring(0, 20)
                End If

                'dr("numero") = Form_envio_productos_sucursal.txt_nro_vale.Text
                'dr("fecha") = Form_menu_principal.dtp_fecha.Text
                'dr("hora") = Form_menu_principal.lbl_hora.Text
                'dr("encargado") = minombre
                'dr("despachador") = Combo_vendedor.Text
                'dr("origen") = mirecintoempresa
                'dr("destino") = Combo_sucursal.Text
                'dr("codigo") = Varcodigo
                'dr("descripcion") = Vardescripcion & " " & ""
                'dr("cantidad") = Varcantidad
                'dr("numero_tecnico") = numero_tecnico

                'e.Graphics.DrawString(Varcodigo, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 385)

                'Dim rect_descripcion_producto As New Rectangle(margen_izquierdo + 75, margen_superior + 385 + (i * multiplicador_lineas), margen_izquierdo + 200, margen_superior + 60)
                'e.Graphics.DrawString(Vardescripcion, Font_texto_titulo_detalle, Brushes.Black, rect_descripcion_producto, stringFormat_left)

                'e.Graphics.DrawString(Varcantidad, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 280, margen_superior + 415, format1)
                'e.Graphics.DrawString(Varcodigo, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 385 + (i * multiplicador_lineas))

                'Dim rect_descripcion_producto As New Rectangle(margen_izquierdo + 75, margen_superior + 385 + (i * multiplicador_lineas), margen_izquierdo + 200, margen_superior + 60)
                'e.Graphics.DrawString(Vardescripcion, Font_texto_titulo_detalle, Brushes.Black, rect_descripcion_producto, stringFormat_left)


                ''e.Graphics.DrawString(Vardescripcion, Font_texto_detalle, Brushes.Black, margen_izquierdo + 210, margen_superior + 385 + (i * multiplicador_lineas))
                'e.Graphics.DrawString(Varcantidad, Font_texto_detalle, Brushes.Black, margen_izquierdo + 265, margen_superior + 385 + (i * multiplicador_lineas), format1)



                e.Graphics.DrawString(Varcodigo, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 385 + (i * multiplicador_lineas))
                e.Graphics.DrawString(Vardescripcion, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 385 + (i * multiplicador_lineas))

                'Dim rect_descripcion_producto As New Rectangle(margen_izquierdo + 75, margen_superior + 385, margen_izquierdo + 200, margen_superior + 60)
                'e.Graphics.DrawString(txt_nombre_producto.Text, Font_texto_titulo_detalle, Brushes.Black, rect_descripcion_producto, stringFormat_left)

                e.Graphics.DrawString(numero_tecnico, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 400 + (i * multiplicador_lineas))
                e.Graphics.DrawString(Varcantidad, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 270, margen_superior + 400 + (i * multiplicador_lineas), format1)


            End If
        Next






        numero_lineas = ((grilla_detalle.Rows.Count - 1) * multiplicador_lineas)






        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + numero_lineas + 415, margen_izquierdo + 270, margen_superior + numero_lineas + 415)


        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + numero_lineas + 530, margen_izquierdo + 270, margen_superior + numero_lineas + 530)


        e.Graphics.DrawString("FIRMA RESPONSABLE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 80, margen_superior + 545 + numero_lineas)

        e.Graphics.DrawString("-", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + 600 + numero_lineas)
    End Sub
End Class