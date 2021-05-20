Imports System.Data.OleDb
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.DirectoryServices
Imports System.Resources

Public Class Form_pruebas
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_pruebas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_pruebas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_pruebas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()

        dtp_fecha_caja_hasta.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_fecha_caja_desde.Value = dtp_fecha_caja_hasta.Value.AddDays(Val(-4))

        fecha()




        malla_prueba()

    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_fecha_caja_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_fecha_caja_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub malla_prueba()
        'SC.Connection = conexion
        'SC.CommandText = "DELETE FROM detalle_condicion_de_pago WHERE `cod_auto`<> '9999999999' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "';"
        'DA.SelectCommand = SC
        'DA.Fill(DT)

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        'SC.CommandText = "SELECT  cod_producto, cantidad, n_total, TIPO, fecha FROM ( SELECT * FROM detalle_total where movimiento='ENTRA' AND TIPO <> 'VALE DE TRASLADO' AND TIPO <> 'VALE DE CAMBIO' ORDER BY fecha DESC )sub GROUP BY cod_producto"
        'SC.CommandText = "SELECT n_compra, rut_proveedor FROM compra;"
        'SC.CommandText = "SELECT n_boleta, total, condiciones, estado, fecha_venta FROM BOLETA where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones <> 'CREDITO';"
        'SC.CommandText = "select detalle_compra.n_compra, TIPO, cod_producto, nombre, precio_unitario, cantidad, detalle_compra.descuento, detalle_compra.neto, detalle_compra.iva,detalle_compra.subtotal, detalle_compra.total, fecha_emision, usuario_responsable, estado, compra.rut_proveedor from compra, detalle_compra where compra.n_compra= detalle_compra.n_compra and compra.rut_proveedor= detalle_compra.rut_proveedor"
        'SC.CommandText = "select * FROM `bd_lubrioil`.FAMILIA"
        'SC.CommandText = "select cod_auto, fecha_venta, total, saldo FROM  `creditos` WHERE SALDO > TOTAL order by fecha_venta desc;"
        'SC.CommandText = "SELECT codigo, fecha FROM `bitacora_de_cambios`,`clientes` where bitacora_de_cambios.codigo=clientes.rut_cliente and clientes.pagare <> '0' and detalle='MODIFICACION DE CLIENTES CREDITO' and fecha >='2017-01-01' and fecha <= '2017-08-20' GROUP BY codigo ORDER BY fecha DESC"
        'SC.CommandText = "SELECT  cod_producto, cantidad, fecha, valor_unitario, n_total, TIPO, rut_proveedor FROM ( SELECT * FROM detalle_total where movimiento='ENTRA' AND TIPO <> 'VALE DE TRASLADO' AND TIPO <> 'VALE DE CAMBIO'  AND TIPO <> 'AJUSTE POR: 16972940-9' and rut_proveedor<>'81921000-4' ORDER BY fecha DESC )sub GROUP BY cod_producto"
        'SC.CommandText = "SELECT rut_cliente, detalle_abono.nro_documento, detalle_abono.saldo_documento, detalle_abono.fecha_vencimiento from `detalle_abono`,`abono` where detalle_abono.nro_abono=abono.n_abono and detalle_abono.saldo_documento <> '0';"
        'SC.CommandText = "select * from `guia` where condiciones='TRASLADO';"
        'SC.CommandText = "SELECT n_total, cod_producto, nombre, valor_unitario FROM detalle_total where tipo='VALE DE TRASLADO' and movimiento='SALE';"
        'SC.CommandText = "SELECT * FROM letras where doc_referencia <> 'AJUSTE' AND year(fecha)='2017';"
        SC.CommandText = " SELECT * FROM letras  where nro_referencia='0' and doc_referencia<>'AJUSTE' order by fecha asc;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_pruebas.DataSource = DS.Tables(DT.TableName)
        conexion.Close()

        txt_item.Text = grilla_pruebas.Rows.Count

    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ejecutar.Click




        lbl_mensaje.Visible = True
        Me.Enabled = False

        'Dim cod_auto As String
        'Dim nro_guia As String

        Dim nro_letra As String = ""
        'Dim documento As String
        'Dim numero As String
        Dim rut_cliente As String
        'Dim total As String
        'Dim fecha As String


        Dim n_letra As String
        'Dim tipo As String
        Dim tipo_detalle As String = ""
        Dim n_boleta As String = ""
        Dim cod_auto As String

        For i = 0 To grilla_pruebas.Rows.Count - 1
            'nro_letra = grilla_pruebas.Rows(i).Cells(1).Value.ToString
            'documento = grilla_pruebas.Rows(i).Cells(3).Value.ToString
            'numero = grilla_pruebas.Rows(i).Cells(4).Value.ToString
            'rut_cliente = grilla_pruebas.Rows(i).Cells(6).Value.ToString
            'total = grilla_pruebas.Rows(i).Cells(7).Value.ToString
            'fecha = grilla_pruebas.Rows(i).Cells(5).Value.ToString

            cod_auto = grilla_pruebas.Rows(i).Cells(0).Value.ToString
            n_letra = grilla_pruebas.Rows(i).Cells(1).Value.ToString
            rut_cliente = grilla_pruebas.Rows(i).Cells(6).Value.ToString


            tipo_detalle = ""
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            'SC2.CommandText = "select * from creditos  where n_creditos='" & (nro_letra) & "' and rut_cliente='" & (rut_cliente) & "'"
            SC2.CommandText = "select * from creditos  where n_creditos='" & (n_letra) & "' and rut_cliente='" & (rut_cliente) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                tipo_detalle = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_detalle")
            End If
            conexion.Close()

            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer


            If tipo_detalle <> "" Then
                cadena = tipo_detalle

                tabla = Split(cadena, " ")
                For n = 0 To UBound(tabla, 1)
                    n_boleta = tabla(1)
                Next
                '" & (nombre) & "'
                SC.Connection = conexion
                SC.CommandText = "UPDATE `letras` SET `nro_referencia`='" & (n_boleta) & "' WHERE `cod_auto`='" & (cod_auto) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        Next


        'For i = 0 To grilla_pruebas.Rows.Count - 1

        '    nro_vale = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    cod_producto = grilla_pruebas.Rows(i).Cells(1).Value.ToString
        '    nombre = grilla_pruebas.Rows(i).Cells(2).Value.ToString
        '    precio = grilla_pruebas.Rows(i).Cells(3).Value.ToString

        '    SC2.Connection = conexion
        '    SC2.CommandText = "UPDATE `vale` SET nombre_producto='" & (nombre) & "',valor_unitario='" & (precio) & "' WHERE n_vale = '" & (nro_vale) & "' and codigo_producto = '" & (cod_producto) & "' and cod_auto <>'0';"
        '    DA2.SelectCommand = SC2
        '    DA2.Fill(DT2)

        'Next


        'Try
        '    For i = 0 To grilla_clientes.Rows.Count - 1
        '        rut_cliente = grilla_clientes.Rows(i).Cells(0).Value.ToString
        '        deuda = grilla_clientes.Rows(i).Cells(1).Value.ToString

        '        conexion.Close()
        '        DS.Tables.Clear()
        '        DT.Rows.Clear()
        '        DT.Columns.Clear()
        '        DS.Clear()
        '        conexion.Open()
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(saldo) as saldo from creditos  where saldo <> '0' and rut_cliente='" & (rut_cliente) & "'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then

        '            Try
        '                deuda = DS.Tables(DT.TableName).Rows(0).Item("saldo")
        '            Catch mierror As InvalidCastException
        '                deuda = 0
        '            End Try


        '            Try
        '                grilla_clientes.Item(1, i).Value = Val(grilla_clientes.Item(1, i).Value) + Val(deuda)
        '            Catch mierror As NullReferenceException
        '                grilla_clientes.Item(1, i).Value = Val(0) + Val(deuda)
        '            End Try

        '        End If
        '        conexion.Close()
        '    Next

        'Catch mierror As MissingManifestResourceException
        'Catch mierror As MySqlException
        'End Try



        'Try
        '    For i = 0 To grilla_clientes.Rows.Count - 1
        '        rut_cliente = grilla_clientes.Rows(i).Cells(0).Value.ToString
        '        deuda = grilla_clientes.Rows(i).Cells(1).Value.ToString
        '        SC.Connection = conexion
        '        SC.CommandText = "update clientes set saldo_cliente = '" & (deuda) & "' where rut_cliente = '" & (rut_cliente) & "'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Next
        'Catch mierror As MissingManifestResourceException
        'Catch mierror As MySqlException
        'End Try





        'Dim n_doc As String
        'Dim total_doc As String
        'Dim condicion_doc As String
        'Dim estado_doc As String
        'Dim fecha_doc As String
        'Dim mifecha2222 As String

        'For i = 0 To grilla_pruebas.Rows.Count - 1
        '    n_doc = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    total_doc = grilla_pruebas.Rows(i).Cells(1).Value.ToString
        '    condicion_doc = grilla_pruebas.Rows(i).Cells(2).Value.ToString
        '    estado_doc = grilla_pruebas.Rows(i).Cells(3).Value.ToString
        '    fecha_doc = grilla_pruebas.Rows(i).Cells(4).Value.ToString

        '    Dim mifecha As Date
        '    mifecha = fecha_doc
        '    mifecha2222 = mifecha.ToString("yyy-MM-dd")

        '    SC4.Connection = conexion
        '    SC4.CommandText = "INSERT INTO detalle_condicion_de_pago (`nro_doc`, `tipo_doc`, `valor`, `condicion_de_pago`, `estado`, `fecha`) VALUES ('" & (n_doc) & "', '" & ("BOLETA") & "', '" & (total_doc) & "', '" & (condicion_doc) & "', '" & (estado_doc) & "', '" & (mifecha2222) & "');"
        '    DA4.SelectCommand = SC4
        '    DA4.Fill(DT4)
        'Next


        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'SC.Connection = conexion
        'SC.CommandText = "SELECT n_boleta, pie, condicion_de_pago_pie, estado, fecha_venta FROM BOLETA where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "';"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'grilla_pruebas.DataSource = DS.Tables(DT.TableName)
        'conexion.Close()

        'txt_item.Text = grilla_pruebas.Rows.Count

        'For i = 0 To grilla_pruebas.Rows.Count - 1
        '    n_doc = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    total_doc = grilla_pruebas.Rows(i).Cells(1).Value.ToString
        '    condicion_doc = grilla_pruebas.Rows(i).Cells(2).Value.ToString
        '    estado_doc = grilla_pruebas.Rows(i).Cells(3).Value.ToString
        '    fecha_doc = grilla_pruebas.Rows(i).Cells(4).Value.ToString

        '    Dim mifecha As Date
        '    mifecha = fecha_doc
        '    mifecha2222 = mifecha.ToString("yyy-MM-dd")

        '    SC4.Connection = conexion
        '    SC4.CommandText = "INSERT INTO detalle_condicion_de_pago (`nro_doc`, `tipo_doc`, `valor`, `condicion_de_pago`, `estado`, `fecha`) VALUES ('" & (n_doc) & "', '" & ("BOLETA") & "', '" & (total_doc) & "', '" & (condicion_doc) & "', '" & (estado_doc) & "', '" & (mifecha2222) & "');"
        '    DA4.SelectCommand = SC4
        '    DA4.Fill(DT4)
        'Next




        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'SC.Connection = conexion
        'SC.CommandText = "SELECT n_abono, monto_abono, condicion_abono, estado, fecha FROM abono where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "';"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'grilla_pruebas.DataSource = DS.Tables(DT.TableName)
        'conexion.Close()

        'txt_item.Text = grilla_pruebas.Rows.Count

        'For i = 0 To grilla_pruebas.Rows.Count - 1
        '    n_doc = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    total_doc = grilla_pruebas.Rows(i).Cells(1).Value.ToString
        '    condicion_doc = grilla_pruebas.Rows(i).Cells(2).Value.ToString
        '    estado_doc = grilla_pruebas.Rows(i).Cells(3).Value.ToString
        '    fecha_doc = grilla_pruebas.Rows(i).Cells(4).Value.ToString

        '    Dim mifecha As Date
        '    mifecha = fecha_doc
        '    mifecha2222 = mifecha.ToString("yyy-MM-dd")

        '    SC4.Connection = conexion
        '    SC4.CommandText = "INSERT INTO detalle_condicion_de_pago (`nro_doc`, `tipo_doc`, `valor`, `condicion_de_pago`, `estado`, `fecha`) VALUES ('" & (n_doc) & "', '" & ("ABONO") & "', '" & (total_doc) & "', '" & (condicion_doc) & "', '" & (estado_doc) & "', '" & (mifecha2222) & "');"
        '    DA4.SelectCommand = SC4
        '    DA4.Fill(DT4)
        'Next













        'Dim n_compra As String
        'Dim rut_proveedor As String

        'For i = 0 To grilla_pruebas.Rows.Count - 1
        '    n_compra = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    rut_proveedor = grilla_pruebas.Rows(i).Cells(1).Value.ToString


        '    SC4.Connection = conexion
        '    SC4.CommandText = "UPDATE detalle_compra SET rut_proveedor='" & (rut_proveedor) & "' WHERE N_COMPRA='" & (n_compra) & "';"
        '    'SC4.CommandText = "UPDATE productos SET ultima_compra='" & (mifecha2) & "', cantidad_ultima_compra='" & (cantidad) & "', tipo_doc='" & (TIPO) & "', nro_doc='" & (n_total) & "' WHERE cod_producto='" & (cod_producto) & "'"
        '    DA4.SelectCommand = SC4
        '    DA4.Fill(DT4)
        'Next





        'Dim cod_producto As String
        'Dim cantidad As String
        'Dim n_total As String
        'Dim TIPO As String
        'Dim fecha As String

        'For i = 0 To grilla_pruebas.Rows.Count - 1
        '    cod_producto = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    cantidad = grilla_pruebas.Rows(i).Cells(1).Value.ToString
        '    n_total = grilla_pruebas.Rows(i).Cells(4).Value.ToString
        '    TIPO = grilla_pruebas.Rows(i).Cells(5).Value.ToString
        '    fecha = grilla_pruebas.Rows(i).Cells(2).Value.ToString

        '    Dim valor As Integer
        '    valor = cod_producto
        '    cod_producto = String.Format("{0:000000}", valor)

        '    Dim mifecha As Date
        '    mifecha = fecha
        '    mifecha2 = mifecha.ToString("yyy-MM-dd")

        '    SC4.Connection = conexion
        '    SC4.CommandText = "UPDATE productos SET ultima_compra='" & (mifecha2) & "', cantidad_ultima_compra='" & (cantidad) & "', tipo_doc='" & (TIPO) & "', nro_doc='" & (n_total) & "' WHERE cod_producto='" & (cod_producto) & "'"
        '    DA4.SelectCommand = SC4
        '    DA4.Fill(DT4)
        'Next












        'Dim n_compra As String
        'Dim TIPO As String
        'Dim cod_producto As String
        'Dim nombre As String
        'Dim precio_unitario As String
        'Dim cantidad As String
        'Dim descuento_detalle As String
        'Dim neto_detalle As String
        'Dim iva_detalle As String
        'Dim subtotal_detalle As String
        'Dim total_detalle As String
        'Dim fecha_emision As String
        'Dim usuario_responsable As String
        'Dim estado As String
        'Dim rut_proveedor As String


        'For i = 0 To grilla_pruebas.Rows.Count - 1
        '    n_compra = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    TIPO = grilla_pruebas.Rows(i).Cells(1).Value.ToString
        '    cod_producto = grilla_pruebas.Rows(i).Cells(2).Value.ToString
        '    nombre = grilla_pruebas.Rows(i).Cells(3).Value.ToString
        '    precio_unitario = grilla_pruebas.Rows(i).Cells(4).Value.ToString
        '    cantidad = grilla_pruebas.Rows(i).Cells(5).Value.ToString
        '    descuento_detalle = grilla_pruebas.Rows(i).Cells(6).Value.ToString
        '    neto_detalle = grilla_pruebas.Rows(i).Cells(7).Value.ToString
        '    iva_detalle = grilla_pruebas.Rows(i).Cells(8).Value.ToString
        '    subtotal_detalle = grilla_pruebas.Rows(i).Cells(9).Value.ToString
        '    total_detalle = grilla_pruebas.Rows(i).Cells(10).Value.ToString
        '    fecha_emision = grilla_pruebas.Rows(i).Cells(11).Value.ToString
        '    usuario_responsable = grilla_pruebas.Rows(i).Cells(12).Value.ToString
        '    estado = grilla_pruebas.Rows(i).Cells(13).Value.ToString
        '    rut_proveedor = grilla_pruebas.Rows(i).Cells(14).Value.ToString

        '    Dim mifecha As Date
        '    mifecha = fecha_emision
        '    mifecha2 = mifecha.ToString("yyy-MM-dd")



        '    conexion.Close()
        '    DS3.Tables.Clear()
        '    DT3.Rows.Clear()
        '    DT3.Columns.Clear()
        '    DS3.Clear()
        '    conexion.Open()
        '    SC3.Connection = conexion
        '    SC3.CommandText = "select * from detalle_total where n_total='" & (n_compra) & "' and movimiento='ENTRA' AND rut_proveedor='" & (rut_proveedor) & "'"
        '    DA3.SelectCommand = SC3
        '    DA3.Fill(DT3)
        '    DS3.Tables.Add(DT3)
        '    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
        '        ' MsgBox("CODIGO DE PRODUCTO YA EXISTENTE", 0 + 16, "ERROR")
        '    Else
        '        SC.Connection = conexion
        '        SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado, rut_proveedor) values(" & (n_compra) & ",'" & (TIPO) & "', '" & (cod_producto) & "','" & (nombre) & "'," & (precio_unitario) & "," & (cantidad) & "," & (descuento_detalle) & "," & (neto_detalle) & ", " & (iva_detalle) & "," & (total_detalle) & "," & (total_detalle) & ", 'ENTRA','" & (mifecha2) & "', '" & (usuario_responsable) & "' ,'EMITIDA', '" & (rut_proveedor) & "')"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    End If
        '    conexion.Close()
        'Next







        'Dim nombre_familia As String
        'Dim codigo_familia As String


        'For i = 0 To grilla_pruebas.Rows.Count - 1
        '    codigo_familia = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    nombre_familia = grilla_pruebas.Rows(i).Cells(1).Value.ToString

        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `bd_lubrioil`.`subfamilia` SET `codigo_familia`='" & (codigo_familia) & "' WHERE `nombre_familia`='" & (nombre_familia) & "' and `cod_auto`<>'0';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Next

        'Dim cod_auto As String
        'Dim fecha As String
        'Dim total As String
        'Dim saldo As String

        'For i = 0 To grilla_pruebas.Rows.Count - 1
        '    cod_auto = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    fecha = grilla_pruebas.Rows(i).Cells(1).Value.ToString
        '    total = grilla_pruebas.Rows(i).Cells(2).Value.ToString
        '    saldo = grilla_pruebas.Rows(i).Cells(3).Value.ToString

        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `creditos` SET `saldo`='" & (total) & "' WHERE `cod_auto`='" & (cod_auto) & "';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Next


        'Dim rut As String
        'Dim fecha As String

        'For i = 0 To grilla_pruebas.Rows.Count - 1
        '    rut = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    fecha = grilla_pruebas.Rows(i).Cells(1).Value.ToString

        '    Dim mifecha As Date
        '    mifecha = fecha
        '    fecha = mifecha.ToString("yyy-MM-dd")

        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `clientes` SET `fecha_pagare`='" & (fecha) & "' WHERE `rut_cliente`='" & (rut) & "';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Next


        'Dim rut_cliente As String
        'Dim nro_documento As String
        'Dim saldo_documento As String
        'Dim fecha_vencimiento As String

        'For i = 0 To grilla_pruebas.Rows.Count - 1
        '    rut_cliente = grilla_pruebas.Rows(i).Cells(0).Value.ToString
        '    nro_documento = grilla_pruebas.Rows(i).Cells(1).Value.ToString
        '    saldo_documento = grilla_pruebas.Rows(i).Cells(2).Value.ToString
        '    fecha_vencimiento = grilla_pruebas.Rows(i).Cells(3).Value.ToString

        '    Dim mifecha As Date
        '    mifecha = fecha_vencimiento
        '    fecha_vencimiento = mifecha.ToString("yyy-MM-dd")

        '    grilla_det.Rows.Clear()
        '    conexion.Close()
        '    DS1.Tables.Clear()
        '    DT1.Rows.Clear()
        '    DT1.Columns.Clear()
        '    DS1.Clear()
        '    SC1.Connection = conexion

        '    SC1.CommandText = "select detalle_abono.fecha_vencimiento as venc,detalle_abono.nro_documento as nro, detalle_abono.saldo_documento as saldo from `detalle_abono`,`abono` where detalle_abono.nro_abono=abono.n_abono and  detalle_abono.nro_documento = '" & (nro_documento) & "'  and detalle_abono.fecha_vencimiento = '" & (fecha_vencimiento) & "' and rut_cliente='" & (rut_cliente) & "' and detalle_abono.cod_auto <> '0' order by detalle_abono.cod_auto asc"

        '    DA1.SelectCommand = SC1
        '    DA1.Fill(DT1)
        '    DS1.Tables.Add(DT1)

        '    If DS1.Tables(DT1.TableName).Rows.Count > 0 Then
        '        For u = 0 To DS1.Tables(DT1.TableName).Rows.Count - 1
        '            Dim MiFechaEmision As Date
        '            Dim mifecha_emision2 As String
        '            MiFechaEmision = DS1.Tables(DT1.TableName).Rows(u).Item("venc")
        '            mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

        '            grilla_det.Rows.Add(DS1.Tables(DT1.TableName).Rows(u).Item("nro"), _
        '                                 DS1.Tables(DT1.TableName).Rows(u).Item("saldo"), _
        '                                  fecha_vencimiento)
        '        Next
        '    End If
        '    ' Exit Sub
        '    If nro_documento = "1749684" Then
        '        Exit Sub
        '    End If




        '    For o = 0 To grilla_det.Rows.Count - 1
        '        nro_documento = grilla_det.Rows(o).Cells(0).Value.ToString
        '        saldo_documento = grilla_det.Rows(o).Cells(1).Value.ToString
        '        fecha_vencimiento = grilla_det.Rows(o).Cells(2).Value.ToString

        '        mifecha = fecha_vencimiento
        '        fecha_vencimiento = mifecha.ToString("yyy-MM-dd")

        '        'SC.Connection = conexion
        '        'SC.CommandText = "UPDATE `creditos` SET `saldo`='" & (saldo_documento) & "' WHERE where  nro_documento = '" & (nro_documento) & "'  and fecha_vencimiento = '" & (fecha_vencimiento) & "' and rut_cliente='" & (rut_cliente) & "' and cod_auto <> '0';"
        '        'DA.SelectCommand = SC
        '        'DA.Fill(DT)
        '    Next

        'Next














        lbl_mensaje.Visible = False
        Me.Enabled = True




        MsgBox("PROCESO TERMINADO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
    End Sub


End Class