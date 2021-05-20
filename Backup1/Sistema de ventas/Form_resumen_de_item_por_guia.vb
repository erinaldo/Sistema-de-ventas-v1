Public Class Form_resumen_de_item_por_guia
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_resumen_de_item_por_guia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_resumen_de_item_por_guia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_resumen_de_item_por_guia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As DateTime = Now()
        Combo_año.Text = Form_menu_principal.dtp_fecha.Value.Year()
        cargar_logo()
        grilla_libro_compras.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        txt_productos.Text = ""
        txt_total.Text = ""
        llenar_combo_sucursal()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_datos_sucursal()
        If combo_sucursal.Text <> "-" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from sucursales where nombre_sucursal ='" & (combo_sucursal.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_sucursal.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
            End If
            conexion.Close()
        End If

        If combo_sucursal.Text = "-" Then
            txt_codigo_sucursal.Text = ""
        End If

    End Sub

    Sub llenar_combo_sucursal()
        combo_sucursal.Items.Clear()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select * from sucursales ORDER BY nombre_sucursal"

        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                combo_sucursal.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("nombre_sucursal"))
            Next
            conexion.Close()
        End If
        combo_sucursal.Items.Add("-")
        combo_sucursal.SelectedItem = "-"

    
    End Sub

    Sub mostrar_total_compras()

        If Combo_año.Text <> "-" Then
            If combo_sucursal.Text = "-" Then
                txt_total.Text = "0"
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select sum(neto) as total from guia where YEAR(fecha_venta)='" & (Combo_año.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_total.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                End If
                conexion.Close()
            Else
                txt_total.Text = "0"
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select sum(neto) as total from guia where YEAR(fecha_venta)='" & (Combo_año.Text) & "' and codigo_cliente='" & (txt_codigo_sucursal.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_total.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                End If
                conexion.Close()
            End If
        End If
  
    End Sub

    Sub mostrar_malla_compras()

        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("", "ITEM")
        grilla_libro_compras.Columns.Add("", "NOMBRE")
        grilla_libro_compras.Columns.Add("", "DESTINO")
        grilla_libro_compras.Columns.Add("", "APLICACION")
        grilla_libro_compras.Columns.Add("", "FAMILIA")
        grilla_libro_compras.Columns.Add("", "PRECIO")
        grilla_libro_compras.Columns.Add("", "COSTO")
        grilla_libro_compras.Columns.Add("", "NETO")
        grilla_libro_compras.Columns.Add("", "%")
        grilla_libro_compras.Columns.Add("", "INICIAL")
        grilla_libro_compras.Columns.Add("", "UNIDADES")
        grilla_libro_compras.Columns.Add("", "ACUM.")
        grilla_libro_compras.Columns.Add("", "FINAL")
        grilla_libro_compras.Columns.Add("", "ENE")
        grilla_libro_compras.Columns.Add("", "FEB")
        grilla_libro_compras.Columns.Add("", "MAR")
        grilla_libro_compras.Columns.Add("", "ABR")
        grilla_libro_compras.Columns.Add("", "MAY")
        grilla_libro_compras.Columns.Add("", "JUN")
        grilla_libro_compras.Columns.Add("", "JUL")
        grilla_libro_compras.Columns.Add("", "AGO")
        grilla_libro_compras.Columns.Add("", "SEP")
        grilla_libro_compras.Columns.Add("", "OCT")
        grilla_libro_compras.Columns.Add("", "NOV")
        grilla_libro_compras.Columns.Add("", "DIC")


        Dim cod_producto As String
        Dim nombre_mes As String
        Dim cod_producto_anterior As String = ""
        Dim total_mes As String
        Dim total_producto As String = 0
        Dim contador As Integer = -1
        Dim costo_producto As String
        Dim destino_producto As String
        Dim destino_producto_anterior As String = ""

        If combo_sucursal.Text = "-" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            'SC.CommandText = "SELECT detalle_compra.cod_producto AS CODIGO, nombre_proveedor AS PROVEEDOR, productos.nombre AS PRODUCTO, productos.aplicacion AS APLICACION, familia.nombre_familia AS FAMILIA, productos.PRECIO AS PRECIO, productos.costo AS COSTO, SUM(detalle_compra.neto) AS NETO, MonthName(COMPRA.fecha_emision) AS nombre_mes, sum(detalle_compra.cantidad) AS TOTAL FROM `compra`, `detalle_compra`, `productos`, `proveedores`, familia WHERE YEAR(fecha_emision)='" & (Combo_año.Text) & "' and COMPRA.N_COMPRA=DETALLE_COMPRA.N_COMPRA AND productos.familia=familia.codigo AND COMPRA.RUT_PROVEEDOR=DETALLE_COMPRA.RUT_PROVEEDOR AND DETALLE_COMPRA.cod_producto=productos.cod_producto AND productos.proveedor=proveedores.rut_proveedor and compra.rut_proveedor<>'81921000-4' GROUP BY DETALLE_COMPRA.COD_PRODUCTO, MonthName(fecha_emision) order by DETALLE_COMPRA.cod_producto;"
            SC.CommandText = "SELECT detalle_guia.cod_producto AS CODIGO, direccion_cliente AS DESTINO, productos.nombre AS PRODUCTO, productos.aplicacion AS APLICACION, familia.nombre_familia AS FAMILIA, productos.PRECIO AS PRECIO, productos.costo AS COSTO, SUM(detalle_guia.detalle_neto) AS NETO, MonthName(guia.fecha_venta) AS nombre_mes, sum(detalle_guia.cantidad) AS TOTAL FROM `guia`, `detalle_guia`, `productos`, `clientes`, familia WHERE YEAR(fecha_venta)='" & (Combo_año.Text) & "' and guia.N_guia=DETALLE_guia.N_guia AND productos.familia=familia.codigo AND guia.codigo_cliente=clientes.cod_cliente AND DETALLE_guia.cod_producto=productos.cod_producto GROUP BY DETALLE_guia.COD_PRODUCTO, MonthName(fecha_venta), codigo_cliente order by DETALLE_guia.cod_producto;"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    cod_producto = DS.Tables(DT.TableName).Rows(i).Item("CODIGO")
                    nombre_mes = DS.Tables(DT.TableName).Rows(i).Item("nombre_mes")
                    total_mes = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                    costo_producto = DS.Tables(DT.TableName).Rows(i).Item("COSTO")
                    destino_producto = DS.Tables(DT.TableName).Rows(i).Item("DESTINO")
                    'If cod_producto = "000138" Then
                    '    MsgBox("")
                    'End If

                    If cod_producto = cod_producto_anterior And destino_producto = destino_producto_anterior Then
                        total_producto = Val(total_producto) + Val(total_mes)

                        If nombre_mes = "January" Then
                            grilla_libro_compras.Rows(contador).Cells(13).Value = total_mes
                        End If
                        If nombre_mes = "February" Then
                            grilla_libro_compras.Rows(contador).Cells(14).Value = total_mes
                        End If
                        If nombre_mes = "March" Then
                            grilla_libro_compras.Rows(contador).Cells(15).Value = total_mes
                        End If
                        If nombre_mes = "April" Then
                            grilla_libro_compras.Rows(contador).Cells(16).Value = total_mes
                        End If
                        If nombre_mes = "May" Then
                            grilla_libro_compras.Rows(contador).Cells(17).Value = total_mes
                        End If
                        If nombre_mes = "June" Then
                            grilla_libro_compras.Rows(contador).Cells(18).Value = total_mes
                        End If
                        If nombre_mes = "July" Then
                            grilla_libro_compras.Rows(contador).Cells(19).Value = total_mes
                        End If
                        If nombre_mes = "August" Then
                            grilla_libro_compras.Rows(contador).Cells(20).Value = total_mes
                        End If
                        If nombre_mes = "September" Then
                            grilla_libro_compras.Rows(contador).Cells(21).Value = total_mes
                        End If
                        If nombre_mes = "October" Then
                            grilla_libro_compras.Rows(contador).Cells(22).Value = total_mes
                        End If
                        If nombre_mes = "November" Then
                            grilla_libro_compras.Rows(contador).Cells(23).Value = total_mes
                        End If
                        If nombre_mes = "December" Then
                            grilla_libro_compras.Rows(contador).Cells(24).Value = total_mes
                        End If

                    Else
                        Try
                            grilla_libro_compras.Rows(contador).Cells(10).Value = total_producto
                        Catch
                        End Try

                        'Try
                        '    grilla_libro_compras.Rows(contador).Cells(5).Value = total_producto * costo_producto
                        'Catch
                        'End Try

                        total_producto = 0
                        total_producto = Val(total_producto) + Val(total_mes)
                        contador = contador + 1

                        grilla_libro_compras.Rows.Add(cod_producto, DS.Tables(DT.TableName).Rows(i).Item("PRODUCTO"), DS.Tables(DT.TableName).Rows(i).Item("DESTINO"), DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), DS.Tables(DT.TableName).Rows(i).Item("COSTO"), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0")

                        If nombre_mes = "January" Then
                            grilla_libro_compras.Rows(contador).Cells(13).Value = total_mes
                        End If
                        If nombre_mes = "February" Then
                            grilla_libro_compras.Rows(contador).Cells(14).Value = total_mes
                        End If
                        If nombre_mes = "March" Then
                            grilla_libro_compras.Rows(contador).Cells(15).Value = total_mes
                        End If
                        If nombre_mes = "April" Then
                            grilla_libro_compras.Rows(contador).Cells(16).Value = total_mes
                        End If
                        If nombre_mes = "May" Then
                            grilla_libro_compras.Rows(contador).Cells(17).Value = total_mes
                        End If
                        If nombre_mes = "June" Then
                            grilla_libro_compras.Rows(contador).Cells(18).Value = total_mes
                        End If
                        If nombre_mes = "July" Then
                            grilla_libro_compras.Rows(contador).Cells(19).Value = total_mes
                        End If
                        If nombre_mes = "August" Then
                            grilla_libro_compras.Rows(contador).Cells(20).Value = total_mes
                        End If
                        If nombre_mes = "September" Then
                            grilla_libro_compras.Rows(contador).Cells(21).Value = total_mes
                        End If
                        If nombre_mes = "October" Then
                            grilla_libro_compras.Rows(contador).Cells(22).Value = total_mes
                        End If
                        If nombre_mes = "November" Then
                            grilla_libro_compras.Rows(contador).Cells(23).Value = total_mes
                        End If
                        If nombre_mes = "December" Then
                            grilla_libro_compras.Rows(contador).Cells(24).Value = total_mes
                        End If
                    End If

                    'grilla_libro_compras.Rows.Add(rut_proveedor, DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"))
                    cod_producto_anterior = DS.Tables(DT.TableName).Rows(i).Item("CODIGO")
                    destino_producto_anterior = DS.Tables(DT.TableName).Rows(i).Item("DESTINO")
                Next

                Try
                    grilla_libro_compras.Rows(contador).Cells(10).Value = total_producto
                Catch
                End Try
            End If



        Else



            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            'SC.CommandText = "SELECT detalle_compra.cod_producto AS CODIGO, nombre_proveedor AS PROVEEDOR, productos.nombre AS PRODUCTO, productos.aplicacion AS APLICACION, familia.nombre_familia AS FAMILIA, productos.PRECIO AS PRECIO, productos.costo AS COSTO, SUM(detalle_compra.neto) AS NETO, MonthName(COMPRA.fecha_emision) AS nombre_mes, sum(detalle_compra.cantidad) AS TOTAL FROM `compra`, `detalle_compra`, `productos`, `proveedores`, familia WHERE YEAR(fecha_emision)='" & (Combo_año.Text) & "' and COMPRA.N_COMPRA=DETALLE_COMPRA.N_COMPRA AND productos.familia=familia.codigo AND COMPRA.RUT_PROVEEDOR=DETALLE_COMPRA.RUT_PROVEEDOR AND DETALLE_COMPRA.cod_producto=productos.cod_producto AND productos.proveedor=proveedores.rut_proveedor and compra.rut_proveedor<>'81921000-4' GROUP BY DETALLE_COMPRA.COD_PRODUCTO, MonthName(fecha_emision) order by DETALLE_COMPRA.cod_producto;"
            SC.CommandText = "SELECT detalle_guia.cod_producto AS CODIGO, direccion_cliente AS DESTINO, productos.nombre AS PRODUCTO, productos.aplicacion AS APLICACION, familia.nombre_familia AS FAMILIA, productos.PRECIO AS PRECIO, productos.costo AS COSTO, SUM(detalle_guia.detalle_neto) AS NETO, MonthName(guia.fecha_venta) AS nombre_mes, sum(detalle_guia.cantidad) AS TOTAL FROM `guia`, `detalle_guia`, `productos`, `clientes`, familia WHERE guia.codigo_cliente='" & (txt_codigo_sucursal.Text) & "' and YEAR(fecha_venta)='" & (Combo_año.Text) & "' and guia.N_guia=DETALLE_guia.N_guia AND productos.familia=familia.codigo AND guia.codigo_cliente=clientes.cod_cliente AND DETALLE_guia.cod_producto=productos.cod_producto GROUP BY DETALLE_guia.COD_PRODUCTO, MonthName(fecha_venta), codigo_cliente order by DETALLE_guia.cod_producto;"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    cod_producto = DS.Tables(DT.TableName).Rows(i).Item("CODIGO")
                    nombre_mes = DS.Tables(DT.TableName).Rows(i).Item("nombre_mes")
                    total_mes = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                    costo_producto = DS.Tables(DT.TableName).Rows(i).Item("COSTO")
                    destino_producto = DS.Tables(DT.TableName).Rows(i).Item("DESTINO")
                    'If cod_producto = "000138" Then
                    '    MsgBox("")
                    'End If

                    If cod_producto = cod_producto_anterior And destino_producto = destino_producto_anterior Then
                        total_producto = Val(total_producto) + Val(total_mes)

                        If nombre_mes = "January" Then
                            grilla_libro_compras.Rows(contador).Cells(13).Value = total_mes
                        End If
                        If nombre_mes = "February" Then
                            grilla_libro_compras.Rows(contador).Cells(14).Value = total_mes
                        End If
                        If nombre_mes = "March" Then
                            grilla_libro_compras.Rows(contador).Cells(15).Value = total_mes
                        End If
                        If nombre_mes = "April" Then
                            grilla_libro_compras.Rows(contador).Cells(16).Value = total_mes
                        End If
                        If nombre_mes = "May" Then
                            grilla_libro_compras.Rows(contador).Cells(17).Value = total_mes
                        End If
                        If nombre_mes = "June" Then
                            grilla_libro_compras.Rows(contador).Cells(18).Value = total_mes
                        End If
                        If nombre_mes = "July" Then
                            grilla_libro_compras.Rows(contador).Cells(19).Value = total_mes
                        End If
                        If nombre_mes = "August" Then
                            grilla_libro_compras.Rows(contador).Cells(20).Value = total_mes
                        End If
                        If nombre_mes = "September" Then
                            grilla_libro_compras.Rows(contador).Cells(21).Value = total_mes
                        End If
                        If nombre_mes = "October" Then
                            grilla_libro_compras.Rows(contador).Cells(22).Value = total_mes
                        End If
                        If nombre_mes = "November" Then
                            grilla_libro_compras.Rows(contador).Cells(23).Value = total_mes
                        End If
                        If nombre_mes = "December" Then
                            grilla_libro_compras.Rows(contador).Cells(24).Value = total_mes
                        End If

                    Else
                        Try
                            grilla_libro_compras.Rows(contador).Cells(10).Value = total_producto
                        Catch
                        End Try

                        'Try
                        '    grilla_libro_compras.Rows(contador).Cells(5).Value = total_producto * costo_producto
                        'Catch
                        'End Try

                        total_producto = 0
                        total_producto = Val(total_producto) + Val(total_mes)
                        contador = contador + 1

                        grilla_libro_compras.Rows.Add(cod_producto, DS.Tables(DT.TableName).Rows(i).Item("PRODUCTO"), DS.Tables(DT.TableName).Rows(i).Item("DESTINO"), DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), DS.Tables(DT.TableName).Rows(i).Item("COSTO"), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0")

                        If nombre_mes = "January" Then
                            grilla_libro_compras.Rows(contador).Cells(13).Value = total_mes
                        End If
                        If nombre_mes = "February" Then
                            grilla_libro_compras.Rows(contador).Cells(14).Value = total_mes
                        End If
                        If nombre_mes = "March" Then
                            grilla_libro_compras.Rows(contador).Cells(15).Value = total_mes
                        End If
                        If nombre_mes = "April" Then
                            grilla_libro_compras.Rows(contador).Cells(16).Value = total_mes
                        End If
                        If nombre_mes = "May" Then
                            grilla_libro_compras.Rows(contador).Cells(17).Value = total_mes
                        End If
                        If nombre_mes = "June" Then
                            grilla_libro_compras.Rows(contador).Cells(18).Value = total_mes
                        End If
                        If nombre_mes = "July" Then
                            grilla_libro_compras.Rows(contador).Cells(19).Value = total_mes
                        End If
                        If nombre_mes = "August" Then
                            grilla_libro_compras.Rows(contador).Cells(20).Value = total_mes
                        End If
                        If nombre_mes = "September" Then
                            grilla_libro_compras.Rows(contador).Cells(21).Value = total_mes
                        End If
                        If nombre_mes = "October" Then
                            grilla_libro_compras.Rows(contador).Cells(22).Value = total_mes
                        End If
                        If nombre_mes = "November" Then
                            grilla_libro_compras.Rows(contador).Cells(23).Value = total_mes
                        End If
                        If nombre_mes = "December" Then
                            grilla_libro_compras.Rows(contador).Cells(24).Value = total_mes
                        End If
                    End If

                    'grilla_libro_compras.Rows.Add(rut_proveedor, DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"))
                    cod_producto_anterior = DS.Tables(DT.TableName).Rows(i).Item("CODIGO")
                    destino_producto_anterior = DS.Tables(DT.TableName).Rows(i).Item("DESTINO")
                Next

                Try
                    grilla_libro_compras.Rows(contador).Cells(10).Value = total_producto
                Catch
                End Try
            End If
        End If




        ' txt_productos.Text = grilla_libro_compras.Rows.Count

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 80 Then
                grilla_libro_compras.Columns(0).Width = 79
            Else
                grilla_libro_compras.Columns(0).Width = 80
            End If
            grilla_libro_compras.Columns(1).Width = 250
            grilla_libro_compras.Columns(2).Width = 250
            grilla_libro_compras.Columns(3).Width = 150
            grilla_libro_compras.Columns(4).Width = 150
            grilla_libro_compras.Columns(5).Width = 80
            grilla_libro_compras.Columns(6).Width = 80
            grilla_libro_compras.Columns(7).Width = 80
            grilla_libro_compras.Columns(8).Width = 80
            grilla_libro_compras.Columns(9).Width = 80
            grilla_libro_compras.Columns(10).Width = 80
            grilla_libro_compras.Columns(11).Width = 80
            grilla_libro_compras.Columns(12).Width = 80
            grilla_libro_compras.Columns(13).Width = 80
            grilla_libro_compras.Columns(14).Width = 80
            grilla_libro_compras.Columns(15).Width = 80

            grilla_libro_compras.Columns(16).Width = 80
            grilla_libro_compras.Columns(17).Width = 80
            grilla_libro_compras.Columns(18).Width = 80
            grilla_libro_compras.Columns(19).Width = 80
            grilla_libro_compras.Columns(20).Width = 80
            grilla_libro_compras.Columns(21).Width = 80

            grilla_libro_compras.Columns(22).Width = 80
            grilla_libro_compras.Columns(23).Width = 80
            grilla_libro_compras.Columns(24).Width = 80
            'grilla_libro_compras.Columns(25).Width = 80
            'grilla_libro_compras.Columns(26).Width = 100

            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            grilla_libro_compras.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_libro_compras.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_libro_compras.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        If Combo_año.Text = "-" Then
            MsgBox("CAMPO AÑO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_año.Focus()
            Exit Sub
        End If

        'If Combo_tipo.Text = "-" Then
        '    MsgBox("CAMPO TIPO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
        '    Combo_tipo.Focus()
        '    Exit Sub
        'End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        mostrar_total_compras()
        mostrar_malla_compras()

        revisar_columnas()
        calcular_totales()

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total.Text = "0"
        Else
            txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_libro_compras.Rows.Count = 0 Then

            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_libro_compras, save.FileName)
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
        For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_libro_compras.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_libro_compras.RowCount - 1
            For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_libro_compras.Item(c, r).Value
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
            grilla_libro_compras.Rows.Clear()
            grilla_libro_compras.Columns.Clear()
            txt_total.Text = ""
            txt_productos.Text = ""
        End If

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_informacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_informacion.GotFocus
        btn_informacion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_informacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_informacion.LostFocus
        btn_informacion.BackColor = Color.Transparent
    End Sub
    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_libro_compras.Rows.Clear()
        txt_total.Text = ""
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub calcular_totales()
        Dim totalgrilla As Long

        'Calcular el total general
        txt_productos.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            totalgrilla = Val(grilla_libro_compras.Rows(i).Cells(10).Value.ToString)
            txt_productos.Text = Val(txt_productos.Text) + Val(totalgrilla)
        Next

        If txt_productos.Text = "" Or txt_productos.Text = "0" Then
            txt_productos.Text = "0"
        Else
            txt_productos.Text = Format(Int(txt_productos.Text), "###,###,###")
        End If
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_libro_compras.Rows.Clear()
        txt_total.Text = ""

    End Sub

    Private Sub Combo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_año.SelectedIndexChanged
        grilla_libro_compras.Columns.Clear()
        txt_total.Text = ""
        txt_productos.Text = ""
    End Sub

    Private Sub Combo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_libro_compras.Columns.Clear()
    End Sub

    Sub revisar_columnas()
        Dim total_producto As String
        Dim costo_producto As String
        Dim porcentaje_producto As String
        Dim total_costo_producto As String

        For i = 0 To grilla_libro_compras.Rows.Count - 1
            total_producto = grilla_libro_compras.Rows(i).Cells(10).Value.ToString
            costo_producto = grilla_libro_compras.Rows(i).Cells(6).Value.ToString
            grilla_libro_compras.Rows(i).Cells(7).Value = Val(total_producto) * Val(costo_producto)

            total_costo_producto = grilla_libro_compras.Rows(i).Cells(7).Value.ToString

            porcentaje_producto = Val(total_costo_producto) * 100
            porcentaje_producto = Val(porcentaje_producto) / Val(txt_total.Text)

            If porcentaje_producto.Length > 4 Then
                porcentaje_producto = porcentaje_producto.Substring(0, 4)
            End If

            If costo_producto = "1" Then
                grilla_libro_compras.Rows(i).Cells(8).Value = "0,00"
            Else
                grilla_libro_compras.Rows(i).Cells(8).Value = porcentaje_producto
            End If
        Next

    End Sub

    Private Sub btn_informacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_informacion.Click

        MsgBox("COLUMNA 1: " & vbCrLf & "COLUMNA 2: " & vbCrLf & "COLUMNA 3: " & vbCrLf & "COLUMNA 4: " & vbCrLf & "COLUMNA 5: " & vbCrLf & "COLUMNA 6: " & vbCrLf & "COLUMNA 7: " & vbCrLf, 0 + 64, "INFORMACION")

    End Sub

    Private Sub combo_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_sucursal.SelectedIndexChanged
        mostrar_datos_sucursal()
        grilla_libro_compras.Columns.Clear()
        txt_total.Text = ""
        txt_productos.Text = ""
    End Sub
End Class