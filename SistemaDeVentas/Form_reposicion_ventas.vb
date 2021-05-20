Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_reposicion_ventas
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_reposicion_ventas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_reposicion_ventas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_reposicion_ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        combo_venta.Text = "TODOS"
    End Sub


    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_malla()

        Dim descuento_porcentaje As Integer
        Dim descuento_total As Integer
        Dim precio_producto As Integer

        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
        grilla_documento.Columns.Add("", "CODIGO")
        grilla_documento.Columns.Add("", "NOMBRE")
        grilla_documento.Columns.Add("", "NRO. TECNICO")
        grilla_documento.Columns.Add("", "APLICACION")
        grilla_documento.Columns.Add("", "FAMILIA")
        grilla_documento.Columns.Add("", "MOVIMIENTO")
        grilla_documento.Columns.Add("", "ORIGEN")
        grilla_documento.Columns.Add("", "DOCUMENTO")
        grilla_documento.Columns.Add("", "NUMERO")
        grilla_documento.Columns.Add("", "FECHA")
        grilla_documento.Columns.Add("", "CANTIDAD")
        grilla_documento.Columns.Add("", "COSTO")
        grilla_documento.Columns.Add("", "ULT. COMPRA")
        grilla_documento.Columns.Add("", "PRECIO")
        grilla_documento.Columns.Add("", "DET. %")
        grilla_documento.Columns.Add("", "DET. DESC.")
        grilla_documento.Columns.Add("", "DET. PRECIO")
        grilla_documento.Columns.Add("", "%")
        grilla_documento.Columns.Add("", "TOTAL DESC.")
        grilla_documento.Columns.Add("", "PRECIO FINAL")


        Dim MiFechaVenta As Date
        Dim MiFechaEmision As String

  

        If combo_venta.Text = "TODOS" Then
            'Boletas
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_boleta.cod_producto as 'CODIGO', detalle_boleta.detalle_nombre AS NOMBRE, detalle_boleta.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_boleta.n_boleta AS NUMERO, fecha_venta as FECHA, detalle_boleta.CANTIDAD AS CANTIDAD,detalle_boleta.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_boleta.porcentaje_desc AS 'DET. %',  detalle_boleta.detalle_descuento AS 'DET. DESC.', detalle_boleta.detalle_total AS 'DET. PRECIO', boleta.porcentaje_desc as '%' FROM boleta, detalle_boleta, PRODUCTOS, EMPRESA where boleta.n_boleta=detalle_boleta.n_boleta AND detalle_boleta.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and boleta.estado <> 'ANULADA' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_boleta.cod_producto as 'CODIGO', detalle_boleta.detalle_nombre AS NOMBRE, detalle_boleta.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_boleta.n_boleta AS NUMERO, fecha_venta as FECHA, detalle_boleta.CANTIDAD AS CANTIDAD,detalle_boleta.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_boleta.porcentaje_desc AS 'DET. %',  detalle_boleta.detalle_descuento AS 'DET. DESC.', detalle_boleta.detalle_total AS 'DET. PRECIO', boleta.porcentaje_desc as '%' FROM boleta, detalle_boleta, PRODUCTOS, EMPRESA where boleta.n_boleta=detalle_boleta.n_boleta AND detalle_boleta.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and boleta.estado <> 'ANULADA' and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            'Facturas
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_factura.cod_producto as 'CODIGO', detalle_factura.detalle_nombre AS NOMBRE, detalle_factura.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_factura.n_factura AS NUMERO, fecha_venta as FECHA, detalle_factura.CANTIDAD AS CANTIDAD,detalle_factura.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_factura.porcentaje_desc AS 'DET. %',  detalle_factura.detalle_descuento AS 'DET. DESC.', detalle_factura.detalle_total AS 'DET. PRECIO', factura.porcentaje_desc as '%' FROM factura, detalle_factura, PRODUCTOS, EMPRESA where factura.n_factura=detalle_factura.n_factura AND detalle_factura.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and factura.estado <> 'ANULADA' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_factura.cod_producto as 'CODIGO', detalle_factura.detalle_nombre AS NOMBRE, detalle_factura.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_factura.n_factura AS NUMERO, fecha_venta as FECHA, detalle_factura.CANTIDAD AS CANTIDAD,detalle_factura.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_factura.porcentaje_desc AS 'DET. %',  detalle_factura.detalle_descuento AS 'DET. DESC.', detalle_factura.detalle_total AS 'DET. PRECIO', factura.porcentaje_desc as '%' FROM factura, detalle_factura, PRODUCTOS, EMPRESA where factura.n_factura=detalle_factura.n_factura AND detalle_factura.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and factura.estado <> 'ANULADA' and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            'Guias
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_guia.cod_producto as 'CODIGO', detalle_guia.detalle_nombre AS NOMBRE, detalle_guia.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_guia.n_guia AS NUMERO, fecha_venta as FECHA, detalle_guia.CANTIDAD AS CANTIDAD,detalle_guia.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_guia.porcentaje_desc AS 'DET. %',  detalle_guia.detalle_descuento AS 'DET. DESC.', detalle_guia.detalle_total AS 'DET. PRECIO', guia.porcentaje_desc as '%' FROM guia, detalle_guia, PRODUCTOS, EMPRESA where guia.n_guia=detalle_guia.n_guia AND detalle_guia.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and guia.estado <> 'ANULADA' and estado <> 'AJUSTE' and condiciones <> 'TRASLADO';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_guia.cod_producto as 'CODIGO', detalle_guia.detalle_nombre AS NOMBRE, detalle_guia.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_guia.n_guia AS NUMERO, fecha_venta as FECHA, detalle_guia.CANTIDAD AS CANTIDAD,detalle_guia.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_guia.porcentaje_desc AS 'DET. %',  detalle_guia.detalle_descuento AS 'DET. DESC.', detalle_guia.detalle_total AS 'DET. PRECIO', guia.porcentaje_desc as '%' FROM guia, detalle_guia, PRODUCTOS, EMPRESA where guia.n_guia=detalle_guia.n_guia AND detalle_guia.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and guia.estado <> 'ANULADA' and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and estado <> 'AJUSTE' and condiciones <> 'TRASLADO';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            'Notas de credito
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_nota_credito.cod_producto as 'CODIGO', detalle_nota_credito.detalle_nombre AS NOMBRE, detalle_nota_credito.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_nota_credito.n_nota_credito AS NUMERO, fecha_venta as FECHA, detalle_nota_credito.CANTIDAD AS CANTIDAD,detalle_nota_credito.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_nota_credito.porcentaje_desc AS 'DET. %',  detalle_nota_credito.detalle_descuento AS 'DET. DESC.', detalle_nota_credito.detalle_total AS 'DET. PRECIO', nota_credito.porcentaje_desc as '%' FROM nota_credito, detalle_nota_credito, PRODUCTOS, EMPRESA where nota_credito.n_nota_credito=detalle_nota_credito.n_nota_credito AND detalle_nota_credito.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.estado <> 'ANULADA' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "ENTRA", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_nota_credito.cod_producto as 'CODIGO', detalle_nota_credito.detalle_nombre AS NOMBRE, detalle_nota_credito.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_nota_credito.n_nota_credito AS NUMERO, fecha_venta as FECHA, detalle_nota_credito.CANTIDAD AS CANTIDAD,detalle_nota_credito.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_nota_credito.porcentaje_desc AS 'DET. %',  detalle_nota_credito.detalle_descuento AS 'DET. DESC.', detalle_nota_credito.detalle_total AS 'DET. PRECIO', nota_credito.porcentaje_desc as '%' FROM nota_credito, detalle_nota_credito, PRODUCTOS, EMPRESA where nota_credito.n_nota_credito=detalle_nota_credito.n_nota_credito AND detalle_nota_credito.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.estado <> 'ANULADA' and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "ENTRA", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If






            'Envios recibidos
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                'SC.CommandText = "SELECT detalle_nota_credito.cod_producto as 'CODIGO', detalle_nota_credito.detalle_nombre AS NOMBRE, detalle_nota_credito.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_nota_credito.n_nota_credito AS NUMERO, fecha_venta as FECHA, detalle_nota_credito.CANTIDAD AS CANTIDAD,detalle_nota_credito.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_nota_credito.porcentaje_desc AS 'DET. %',  detalle_nota_credito.detalle_descuento AS 'DET. DESC.', detalle_nota_credito.detalle_total AS 'DET. PRECIO', nota_credito.porcentaje_desc as '%' FROM nota_credito, detalle_nota_credito, PRODUCTOS, EMPRESA where nota_credito.n_nota_credito=detalle_nota_credito.n_nota_credito AND detalle_nota_credito.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.estado <> 'ANULADA' and estado <> 'AJUSTE';"
                SC.CommandText = "SELECT envios_recibidos.cod_producto as 'CODIGO', envios_recibidos.nombre AS NOMBRE, productos.numero_tecnico as 'NRO. TECNICO', productos.aplicacion as 'APLICACION', productos.familia as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, envios_recibidos.n_documento AS NUMERO, fecha as FECHA, envios_recibidos.CANTIDAD AS CANTIDAD, envios_recibidos.valor_unitario as PRECIO, productos.costo as COSTO, productos.ultima_compra AS 'ULT. COMPRA', envios_recibidos.cod_producto as 'CODIGO', envios_recibidos.cod_producto as 'CODIGO', envios_recibidos.cod_producto as 'CODIGO', envios_recibidos.cod_producto as 'CODIGO' FROM envios_recibidos, productos, empresa where envios_recibidos.cod_producto=productos.cod_producto and fecha >= '" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and envios_recibidos.estado <> 'ANULADA' and envios_recibidos.estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "ENTRA", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                "0", _
                                                                 "0", _
                                                                  "0", _
                                                                   "0", _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                'SC.CommandText = "SELECT detalle_nota_credito.cod_producto as 'CODIGO', detalle_nota_credito.detalle_nombre AS NOMBRE, detalle_nota_credito.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_nota_credito.n_nota_credito AS NUMERO, fecha_venta as FECHA, detalle_nota_credito.CANTIDAD AS CANTIDAD,detalle_nota_credito.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_nota_credito.porcentaje_desc AS 'DET. %',  detalle_nota_credito.detalle_descuento AS 'DET. DESC.', detalle_nota_credito.detalle_total AS 'DET. PRECIO', nota_credito.porcentaje_desc as '%' FROM nota_credito, detalle_nota_credito, PRODUCTOS, EMPRESA where nota_credito.n_nota_credito=detalle_nota_credito.n_nota_credito AND detalle_nota_credito.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.estado <> 'ANULADA' and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and estado <> 'AJUSTE';"
                SC.CommandText = "SELECT envios_recibidos.cod_producto as 'CODIGO', envios_recibidos.nombre AS NOMBRE, productos.numero_tecnico as 'NRO. TECNICO', productos.aplicacion as 'APLICACION', productos.familia as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, envios_recibidos.n_documento AS NUMERO, fecha as FECHA, envios_recibidos.CANTIDAD AS CANTIDAD, envios_recibidos.valor_unitario as PRECIO, productos.costo as COSTO, productos.ultima_compra AS 'ULT. COMPRA', envios_recibidos.cod_producto as 'CODIGO', envios_recibidos.cod_producto as 'CODIGO', envios_recibidos.cod_producto as 'CODIGO', envios_recibidos.cod_producto as 'CODIGO' FROM bd_or_chacabuco.envios_recibidos, bd_or_chacabuco.productos, bd_or_chacabuco.empresa where envios_recibidos.cod_producto=productos.cod_producto and fecha >= '" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and envios_recibidos.estado <> 'ANULADA' and envios_recibidos.estado <> 'AJUSTE' and envios_recibidos.cod_producto = '" & (txt_codigo_producto.Text) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "ENTRA", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                "0", _
                                                                 "0", _
                                                                  "0", _
                                                                   "0", _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("PRECIO")) - descuento_total)
                    Next
                End If
            End If








































          
           

            'VALE DE CAMBIO

            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_vale_cambio.cod_producto as 'CODIGO', detalle_vale_cambio.detalle_nombre AS NOMBRE, detalle_vale_cambio.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', MOVIMIENTO as 'MOVIMIENTO', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_vale_cambio.nro_vale AS NUMERO, fecha as FECHA, detalle_vale_cambio.CANTIDAD AS CANTIDAD, detalle_vale_cambio.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_vale_cambio.porcentaje_desc AS 'DET. %',  detalle_vale_cambio.detalle_descuento AS 'DET. DESC.', detalle_vale_cambio.detalle_total AS 'DET. PRECIO', vale_cambio.porcentaje_desc as '%' FROM vale_cambio, detalle_vale_cambio, PRODUCTOS, EMPRESA where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale AND detalle_vale_cambio.cod_producto=productos.cod_producto and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and vale_cambio.estado <> 'ANULADA' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_vale_cambio.cod_producto as 'CODIGO', detalle_vale_cambio.detalle_nombre AS NOMBRE, detalle_vale_cambio.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', MOVIMIENTO as 'MOVIMIENTO', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_vale_cambio.nro_vale AS NUMERO, fecha as FECHA, detalle_vale_cambio.CANTIDAD AS CANTIDAD, detalle_vale_cambio.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_vale_cambio.porcentaje_desc AS 'DET. %',  detalle_vale_cambio.detalle_descuento AS 'DET. DESC.', detalle_vale_cambio.detalle_total AS 'DET. PRECIO', vale_cambio.porcentaje_desc as '%' FROM vale_cambio, detalle_vale_cambio, PRODUCTOS, EMPRESA where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale AND detalle_vale_cambio.cod_producto=productos.cod_producto and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and vale_cambio.estado <> 'ANULADA' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If
        End If

        If combo_venta.Text = "BOLETA" Then
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_boleta.cod_producto as 'CODIGO', detalle_boleta.detalle_nombre AS NOMBRE, detalle_boleta.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_boleta.n_boleta AS NUMERO, fecha_venta as FECHA, detalle_boleta.CANTIDAD AS CANTIDAD,detalle_boleta.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_boleta.porcentaje_desc AS 'DET. %',  detalle_boleta.detalle_descuento AS 'DET. DESC.', detalle_boleta.detalle_total AS 'DET. PRECIO', boleta.porcentaje_desc as '%' FROM boleta, detalle_boleta, PRODUCTOS, EMPRESA where boleta.n_boleta=detalle_boleta.n_boleta AND detalle_boleta.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and boleta.estado <> 'ANULADA' and boleta.estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_boleta.cod_producto as 'CODIGO', detalle_boleta.detalle_nombre AS NOMBRE, detalle_boleta.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_boleta.n_boleta AS NUMERO, fecha_venta as FECHA, detalle_boleta.CANTIDAD AS CANTIDAD,detalle_boleta.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_boleta.porcentaje_desc AS 'DET. %',  detalle_boleta.detalle_descuento AS 'DET. DESC.', detalle_boleta.detalle_total AS 'DET. PRECIO', boleta.porcentaje_desc as '%' FROM boleta, detalle_boleta, PRODUCTOS, EMPRESA where boleta.n_boleta=detalle_boleta.n_boleta AND detalle_boleta.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and boleta.estado <> 'ANULADA' and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and boleta.estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If
        End If

        If combo_venta.Text = "NOTA DE CREDITO" Then
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_nota_credito.cod_producto as 'CODIGO', detalle_nota_credito.detalle_nombre AS NOMBRE, detalle_nota_credito.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_nota_credito.n_nota_credito AS NUMERO, fecha_venta as FECHA, detalle_nota_credito.CANTIDAD AS CANTIDAD,detalle_nota_credito.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_nota_credito.porcentaje_desc AS 'DET. %',  detalle_nota_credito.detalle_descuento AS 'DET. DESC.', detalle_nota_credito.detalle_total AS 'DET. PRECIO', nota_credito.porcentaje_desc as '%' FROM nota_credito, detalle_nota_credito, PRODUCTOS, EMPRESA where nota_credito.n_nota_credito=detalle_nota_credito.n_nota_credito AND detalle_nota_credito.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.estado <> 'ANULADA' and nota_credito.estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_nota_credito.cod_producto as 'CODIGO', detalle_nota_credito.detalle_nombre AS NOMBRE, detalle_nota_credito.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_nota_credito.n_nota_credito AS NUMERO, fecha_venta as FECHA, detalle_nota_credito.CANTIDAD AS CANTIDAD,detalle_nota_credito.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_nota_credito.porcentaje_desc AS 'DET. %',  detalle_nota_credito.detalle_descuento AS 'DET. DESC.', detalle_nota_credito.detalle_total AS 'DET. PRECIO', nota_credito.porcentaje_desc as '%' FROM nota_credito, detalle_nota_credito, PRODUCTOS, EMPRESA where nota_credito.n_nota_credito=detalle_nota_credito.n_nota_credito AND detalle_nota_credito.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.estado <> 'ANULADA' and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and nota_credito.estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If
        End If

        If combo_venta.Text = "BOLETA SIN CAMBIO" Then
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_boleta.cod_producto as 'CODIGO', detalle_boleta.detalle_nombre AS NOMBRE, detalle_boleta.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_boleta.n_boleta AS NUMERO, fecha_venta as FECHA, detalle_boleta.CANTIDAD AS CANTIDAD,detalle_boleta.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_boleta.porcentaje_desc AS 'DET. %',  detalle_boleta.detalle_descuento AS 'DET. DESC.', detalle_boleta.detalle_total AS 'DET. PRECIO', boleta.porcentaje_desc as '%' FROM boleta, detalle_boleta, PRODUCTOS, EMPRESA where boleta.tipo <> 'BOLETA DE CAMBIO' and boleta.n_boleta=detalle_boleta.n_boleta AND detalle_boleta.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and boleta.estado <> 'ANULADA' and boleta.estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_boleta.cod_producto as 'CODIGO', detalle_boleta.detalle_nombre AS NOMBRE, detalle_boleta.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_boleta.n_boleta AS NUMERO, fecha_venta as FECHA, detalle_boleta.CANTIDAD AS CANTIDAD,detalle_boleta.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_boleta.porcentaje_desc AS 'DET. %',  detalle_boleta.detalle_descuento AS 'DET. DESC.', detalle_boleta.detalle_total AS 'DET. PRECIO', boleta.porcentaje_desc as '%' FROM boleta, detalle_boleta, PRODUCTOS, EMPRESA where boleta.tipo <> 'BOLETA DE CAMBIO' and boleta.n_boleta=detalle_boleta.n_boleta AND detalle_boleta.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and boleta.estado <> 'ANULADA' and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and boleta.estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If
        End If

        If combo_venta.Text = "GUIA" Then
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_guia.cod_producto as 'CODIGO', detalle_guia.detalle_nombre AS NOMBRE, detalle_guia.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_guia.n_guia AS NUMERO, fecha_venta as FECHA, detalle_guia.CANTIDAD AS CANTIDAD,detalle_guia.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_guia.porcentaje_desc AS 'DET. %',  detalle_guia.detalle_descuento AS 'DET. DESC.', detalle_guia.detalle_total AS 'DET. PRECIO', guia.porcentaje_desc as '%' FROM guia, detalle_guia, PRODUCTOS, EMPRESA where guia.n_guia=detalle_guia.n_guia AND detalle_guia.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and guia.estado <> 'ANULADA' and estado <> 'AJUSTE' and condiciones <> 'TRASLADO';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_guia.cod_producto as 'CODIGO', detalle_guia.detalle_nombre AS NOMBRE, detalle_guia.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_guia.n_guia AS NUMERO, fecha_venta as FECHA, detalle_guia.CANTIDAD AS CANTIDAD,detalle_guia.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_guia.porcentaje_desc AS 'DET. %',  detalle_guia.detalle_descuento AS 'DET. DESC.', detalle_guia.detalle_total AS 'DET. PRECIO', guia.porcentaje_desc as '%' FROM guia, detalle_guia, PRODUCTOS, EMPRESA where guia.n_guia=detalle_guia.n_guia AND detalle_guia.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and guia.estado <> 'ANULADA' and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and estado <> 'AJUSTE' and condiciones <> 'TRASLADO';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If
        End If

        If combo_venta.Text = "FACTURA" Then
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_factura.cod_producto as 'CODIGO', detalle_factura.detalle_nombre AS NOMBRE, detalle_factura.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_factura.n_factura AS NUMERO, fecha_venta as FECHA, detalle_factura.CANTIDAD AS CANTIDAD,detalle_factura.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_factura.porcentaje_desc AS 'DET. %',  detalle_factura.detalle_descuento AS 'DET. DESC.', detalle_factura.detalle_total AS 'DET. PRECIO', factura.porcentaje_desc as '%' FROM factura, detalle_factura, PRODUCTOS, EMPRESA where factura.n_factura=detalle_factura.n_factura AND detalle_factura.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and factura.estado <> 'ANULADA' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_factura.cod_producto as 'CODIGO', detalle_factura.detalle_nombre AS NOMBRE, detalle_factura.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_factura.n_factura AS NUMERO, fecha_venta as FECHA, detalle_factura.CANTIDAD AS CANTIDAD,detalle_factura.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_factura.porcentaje_desc AS 'DET. %',  detalle_factura.detalle_descuento AS 'DET. DESC.', detalle_factura.detalle_total AS 'DET. PRECIO', factura.porcentaje_desc as '%' FROM factura, detalle_factura, PRODUCTOS, EMPRESA where factura.n_factura=detalle_factura.n_factura AND detalle_factura.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and factura.estado <> 'ANULADA' and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       "SALE", _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If
        End If
































        If combo_venta.Text = "VALE DE CAMBIO" Then
            If txt_codigo_producto.Text = "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_vale_cambio.cod_producto as 'CODIGO', detalle_vale_cambio.detalle_nombre AS NOMBRE, detalle_vale_cambio.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', MOVIMIENTO as 'MOVIMIENTO', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_vale_cambio.nro_vale AS NUMERO, fecha as FECHA, detalle_vale_cambio.CANTIDAD AS CANTIDAD, detalle_vale_cambio.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_vale_cambio.porcentaje_desc AS 'DET. %',  detalle_vale_cambio.detalle_descuento AS 'DET. DESC.', detalle_vale_cambio.detalle_total AS 'DET. PRECIO', vale_cambio.porcentaje_desc as '%' FROM vale_cambio, detalle_vale_cambio, PRODUCTOS, EMPRESA where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale AND detalle_vale_cambio.cod_producto=productos.cod_producto and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and vale_cambio.estado <> 'ANULADA' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If

            If txt_codigo_producto.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "SELECT detalle_vale_cambio.cod_producto as 'CODIGO', detalle_vale_cambio.detalle_nombre AS NOMBRE, detalle_vale_cambio.numero_tecnico as 'NRO. TECNICO', aplicacion as 'APLICACION', FAMILIA as 'FAMILIA', MOVIMIENTO as 'MOVIMIENTO', DIRECCION_EMPRESA AS ORIGEN, TIPO AS DOCUMENTO, detalle_vale_cambio.nro_vale AS NUMERO, fecha as FECHA, detalle_vale_cambio.CANTIDAD AS CANTIDAD, detalle_vale_cambio.valor_unitario as PRECIO, costo, ultima_compra AS 'ULT. COMPRA', detalle_vale_cambio.porcentaje_desc AS 'DET. %',  detalle_vale_cambio.detalle_descuento AS 'DET. DESC.', detalle_vale_cambio.detalle_total AS 'DET. PRECIO', vale_cambio.porcentaje_desc as '%' FROM vale_cambio, detalle_vale_cambio, PRODUCTOS, EMPRESA where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale AND detalle_vale_cambio.cod_producto=productos.cod_producto and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and productos.cod_producto = '" & (txt_codigo_producto.Text) & "' and vale_cambio.estado <> 'ANULADA' and estado <> 'AJUSTE';"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        MiFechaVenta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                        MiFechaEmision = MiFechaVenta.ToString("dd-MM-yyy")
                        Try
                            descuento_porcentaje = DS.Tables(DT.TableName).Rows(i).Item("%")
                        Catch
                            descuento_porcentaje = 0
                        End Try
                        precio_producto = DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")
                        descuento_total = (precio_producto * descuento_porcentaje) / 100
                        grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("ORIGEN"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                                           MiFechaEmision, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("COSTO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("DET. %"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("DET. DESC."), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("%"), _
                                                                    descuento_total, _
                                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("DET. PRECIO")) - descuento_total)
                    Next
                End If
            End If
        End If













        grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_documento.Columns(0).Width = 100
        grilla_documento.Columns(1).Width = 243
        grilla_documento.Columns(2).Width = 243
        grilla_documento.Columns(3).Width = 100
        grilla_documento.Columns(4).Width = 250
        grilla_documento.Columns(5).Width = 100
        grilla_documento.Columns(6).Width = 100
        grilla_documento.Columns(7).Width = 100
        grilla_documento.Columns(8).Width = 100
        grilla_documento.Columns(9).Width = 100
        grilla_documento.Columns(10).Width = 100
        grilla_documento.Columns(11).Width = 130
        grilla_documento.Columns(12).Width = 130
        grilla_documento.Columns(13).Width = 130
        grilla_documento.Columns(14).Width = 130
        grilla_documento.Columns(15).Width = 130
        grilla_documento.Columns(16).Width = 130
        grilla_documento.Columns(17).Width = 130
        grilla_documento.Columns(18).Width = 130
        grilla_documento.Columns(19).Width = 130

        If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
            grilla_documento.Columns(0).Visible = True
            grilla_documento.Columns(1).Visible = True
            grilla_documento.Columns(2).Visible = False
            grilla_documento.Columns(3).Visible = False
            grilla_documento.Columns(4).Visible = False
            grilla_documento.Columns(5).Visible = True
            grilla_documento.Columns(6).Visible = False
            grilla_documento.Columns(7).Visible = True
            grilla_documento.Columns(8).Visible = True
            grilla_documento.Columns(9).Visible = True
            grilla_documento.Columns(10).Visible = True
            grilla_documento.Columns(11).Visible = True
            grilla_documento.Columns(12).Visible = False
            grilla_documento.Columns(13).Visible = False
        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        fecha()
        mostrar_malla()

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_documento.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp_desde.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_documento, save.FileName)
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True


    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_documento.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_documento.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_documento.RowCount - 1
            For c As Integer = 0 To grilla_documento.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_documento.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_documento.Rows.Clear()
            grilla_documento.Columns.Clear()
            ' grilla_existencias.Rows.Clear()
            combo_venta.SelectedItem = "TODOS"
        End If
    End Sub





    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub



    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.GotFocus
        combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.LostFocus
        combo_venta.BackColor = Color.White
    End Sub

    Private Sub dtp_desde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.GotFocus
        dtp_desde.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp_desde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.LostFocus
        dtp_desde.BackColor = Color.White
    End Sub

    Private Sub dtp_hasta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.GotFocus
        dtp_hasta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp_hasta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.LostFocus
        dtp_hasta.BackColor = Color.White
    End Sub


    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
    End Sub

    Private Sub txt_codigo_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_producto.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()

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

        txt_nombre_producto.Text = ""
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            lbl_mensaje.Visible = True
            Me.Enabled = False
            If txt_codigo_producto.Text = "" Then
                MsgBox("SELECCIONE UN PRODUCTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                txt_codigo_producto.Focus()
                Exit Sub
            End If

            lbl_mensaje.Visible = True
            Me.Enabled = False
            mostrar_datos_productos()
            lbl_mensaje.Visible = False
            Me.Enabled = True



        End If

    End Sub

    Private Sub txt_codigo_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.TextChanged
        grilla_documento.DataSource = Nothing
    End Sub

    Sub mostrar_datos_productos()
        If txt_codigo_producto.Text <> "" Then
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

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
    End Sub
End Class