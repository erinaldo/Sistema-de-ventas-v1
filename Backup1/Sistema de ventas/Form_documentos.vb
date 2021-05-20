Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_documentos
    Dim total_registros As Integer
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_documentos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_anular_documentos.Enabled = True
        Form_anular_documentos.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_documentos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    'se llama al llenar comborut
    'se llama los sub fechas.
    Private Sub Form_documentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llenar_combo_rut()
        mostrar_datos_clientes()
        fecha()
        fecha2()
        cargar_logo()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut.Text = rut_cliente
            End If
        End If
    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha2 se le entrega el formato de fecha indicado.
    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp1.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha4 se le entrega el formato de fecha indicado.
    Sub fecha2()
        Dim mifecha1 As Date
        mifecha1 = dtp2.Text
        mifecha4 = mifecha1.ToString("yyy-MM-dd")
    End Sub

    'actualiza la tabla clientes
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

    ''llena el ocmbo rut.
    'Sub llenar_combo_rut()
    '    combo_rut.Items.Clear()
    '    actualizar_tabla_clientes()

    '    total_registros = DS.Tables(DT.TableName).Rows.Count()
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To total_registros - 1
    '            combo_rut.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    'muestra los datos de los clientes segun el documento.
    Sub mostrar_datos_clientes()
        If txt_rut.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
            End If
            conexion.Close()
        End If
    End Sub

    Sub limpiar_datos_clientes()
        txt_nombre_cliente.Text = ""
        txt_telefono.Text = ""
        txt_direccion.Text = ""
        txt_comuna.Text = ""
        migrilla.DataSource = Nothing
        migrilla_detalle.Rows.Clear()
    End Sub

    'este es el sub que permite realizar el fitrado segun lo que se digite en el texbox rut.
    'Sub mostrar_rut()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from clientes where rut like '" & (txt_rut.Text & "%") & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_rut.Items.Clear()
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            txt_rut.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    'se llama al sub mostrar rut.


    Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub



    'muestra la informacion general del documento seleccionado.
    Sub mostrar_malla()

        If combo_documentos.Text = "GUIA" Then
            conexion.Close()
            Dim DT As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion
            ' SC3.CommandText = "select clientes.rut_cliente AS RUT, clientes.nombre_cliente AS NOMBRE, SUM(guia.total) AS 'TOTAL GUIA',round(sum(guia.total) * clientes.descuento_2 / 100) AS DESCUENTO, round(SUM(guia.total)-SUM(guia.total) * (clientes.descuento_2) / 100) as 'TOTAL FACTURA', clientes.folio_cliente FOLIO from guia inner join clientes on clientes.rut_cliente =guia.rut_cliente where guia.estado= '" & ("SIN FACTURAR") & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND CONDICIONES <> 'TRASLADO'  GROUP BY clientes.rut_cliente  ORDER BY clientes.nombre_cliente ASC"
            SC3.CommandText = "select n_guia as 'NRO.', TIPO as 'TIPO', rut_cliente as 'RUT', descuento as 'DCTO.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', condiciones as 'CONDICION', Estado as 'ESTADO' from guia  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and rut_cliente = '" & (txt_rut.Text) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            migrilla.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            migrilla.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Exit Sub
        End If


        If combo_documentos.Text = "BOLETA" Then
            conexion.Close()
            Dim DT As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion
            ' SC3.CommandText = "select clientes.rut_cliente AS RUT, clientes.nombre_cliente AS NOMBRE, SUM(guia.total) AS 'TOTAL GUIA',round(sum(guia.total) * clientes.descuento_2 / 100) AS DESCUENTO, round(SUM(guia.total)-SUM(guia.total) * (clientes.descuento_2) / 100) as 'TOTAL FACTURA', clientes.folio_cliente FOLIO from guia inner join clientes on clientes.rut_cliente =guia.rut_cliente where guia.estado= '" & ("SIN FACTURAR") & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND CONDICIONES <> 'TRASLADO'  GROUP BY clientes.rut_cliente  ORDER BY clientes.nombre_cliente ASC"
            SC3.CommandText = "select n_boleta as 'NRO.', TIPO as 'TIPO', rut_cliente as 'RUT', descuento as 'DCTO.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', condiciones as 'CONDICION', Estado as 'ESTADO' from BOLETA  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and rut_cliente = '" & (txt_rut.Text) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            migrilla.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            migrilla.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Exit Sub
        End If

        If combo_documentos.Text = "FACTURA" Then
            conexion.Close()
            Dim DT As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion
            ' SC3.CommandText = "select clientes.rut_cliente AS RUT, clientes.nombre_cliente AS NOMBRE, SUM(guia.total) AS 'TOTAL GUIA',round(sum(guia.total) * clientes.descuento_2 / 100) AS DESCUENTO, round(SUM(guia.total)-SUM(guia.total) * (clientes.descuento_2) / 100) as 'TOTAL FACTURA', clientes.folio_cliente FOLIO from guia inner join clientes on clientes.rut_cliente =guia.rut_cliente where guia.estado= '" & ("SIN FACTURAR") & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND CONDICIONES <> 'TRASLADO'  GROUP BY clientes.rut_cliente  ORDER BY clientes.nombre_cliente ASC"
            SC3.CommandText = "select n_FACTURA as 'NRO.', TIPO as 'TIPO', rut_cliente as 'RUT', descuento as 'DCTO.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', condiciones as 'CONDICION', Estado as 'ESTADO' from FACTURA  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and rut_cliente = '" & (txt_rut.Text) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            migrilla.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            migrilla.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Exit Sub
        End If

        If combo_documentos.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            Dim DT As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion
            ' SC3.CommandText = "select clientes.rut_cliente AS RUT, clientes.nombre_cliente AS NOMBRE, SUM(guia.total) AS 'TOTAL GUIA',round(sum(guia.total) * clientes.descuento_2 / 100) AS DESCUENTO, round(SUM(guia.total)-SUM(guia.total) * (clientes.descuento_2) / 100) as 'TOTAL FACTURA', clientes.folio_cliente FOLIO from guia inner join clientes on clientes.rut_cliente =guia.rut_cliente where guia.estado= '" & ("SIN FACTURAR") & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND CONDICIONES <> 'TRASLADO'  GROUP BY clientes.rut_cliente  ORDER BY clientes.nombre_cliente ASC"
            SC3.CommandText = "select n_NOTA_CREDITO as 'NRO.', TIPO as 'TIPO', rut_cliente as 'RUT', descuento as 'DCTO.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', condiciones as 'CONDICION', Estado as 'ESTADO' from NOTA_CREDITO  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and rut_cliente = '" & (txt_rut.Text) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            migrilla.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            migrilla.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Exit Sub
        End If

    End Sub

    'se limpia el detalle y se llama al sub mostrar malla.
    Private Sub combo_documentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documentos.SelectedIndexChanged
        ' migrilla.Rows.Clear()
        ' migrilla_detalle.Rows.Clear()
        mostrar_malla()
    End Sub

    'segun el documento seleccionado se muestra el detalle del documento.
    Sub mostrar_malla_detalle()
        Dim TIPO As String
        columna_seleccionada = migrilla.CurrentRow.Cells(0).Value
        TIPO = migrilla.CurrentRow.Cells(1).Value

        If combo_documentos.Text = "TODOS" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_total where  n_total = '" & (columna_seleccionada) & "' and TIPO = '" & (TIPO) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            migrilla_detalle.Rows.Clear()
            migrilla_detalle.Columns.Clear()
            migrilla_detalle.Columns.Add("cod_producto", "CODIGO")
            migrilla_detalle.Columns.Add("nombre", "NOMBRE")
            migrilla_detalle.Columns.Add("valor_unitario", "VALOR")
            migrilla_detalle.Columns.Add("descuento", "DCTO.")
            migrilla_detalle.Columns.Add("cantidad", "CANTIDAD")
            migrilla_detalle.Columns.Add("total", "TOTAL")

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    migrilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"))
                Next
            End If







            migrilla_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight










            Exit Sub
        End If




        If combo_documentos.Text = "FACTURA" Then
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'conexion.Open()

            'SC.Connection = conexion
            'SC.CommandText = "select cod_producto as Codigo, detalle_nombre as Nombre, valor_unitario as Valor, cantidad as Cantidad, detalle_Neto as Neto, detalle_iva as IVA, detalle_total as Total from detalle_factura  where  n_factura = '" & (columna_seleccionada) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            'migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            'conexion.Close()



            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura  where  n_factura = '" & (columna_seleccionada) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            migrilla_detalle.Rows.Clear()
            migrilla_detalle.Columns.Clear()
            migrilla_detalle.Columns.Add("cod_producto", "CODIGO")
            migrilla_detalle.Columns.Add("detalle_nombre", "NOMBRE")
            migrilla_detalle.Columns.Add("valor_unitario", "VALOR")
            migrilla_detalle.Columns.Add("detalle_descuento", "DCTO.")
            migrilla_detalle.Columns.Add("cantidad", "CANTIDAD")
            migrilla_detalle.Columns.Add("detalle_total", "TOTAL")

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    migrilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If








            migrilla_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight






            Exit Sub
        End If

        If combo_documentos.Text = "FACTURA DE CREDITO" Then
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'conexion.Open()

            'SC.Connection = conexion
            'SC.CommandText = "select cod_producto as Codigo, detalle_nombre as Nombre, valor_unitario as Valor, cantidad as Cantidad, detalle_Neto as Neto, detalle_iva as IVA, detalle_total as Total from detalle_factura_credito  where  n_factura_credito = '" & (columna_seleccionada) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            'migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            'conexion.Close()



            conexion.Close()

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura_credito  where  n_factura_credito = '" & (columna_seleccionada) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            migrilla_detalle.Rows.Clear()
            migrilla_detalle.Columns.Clear()
            migrilla_detalle.Columns.Add("cod_producto", "CODIGO")
            migrilla_detalle.Columns.Add("detalle_nombre", "NOMBRE")
            migrilla_detalle.Columns.Add("valor_unitario", "VALOR")
            migrilla_detalle.Columns.Add("detalle_descuento", "DCTO.")
            migrilla_detalle.Columns.Add("cantidad", "CANTIDAD")
            migrilla_detalle.Columns.Add("detalle_total", "TOTAL")

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    migrilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If






            migrilla_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight







            Exit Sub
        End If




        If combo_documentos.Text = "NOTA DE CREDITO" Then
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'conexion.Open()

            'SC.Connection = conexion
            'SC.CommandText = "select cod_producto as Codigo, detalle_nombre as Nombre, valor_unitario as Valor, cantidad as Cantidad, detalle_Neto as Neto, detalle_iva as IVA, detalle_total as Total from detalle_nota_credito  where  n_nota_credito = '" & (columna_seleccionada) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            'migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            'conexion.Close()









            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_nota_credito  where  n_nota_credito = '" & (columna_seleccionada) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            migrilla_detalle.Rows.Clear()
            migrilla_detalle.Columns.Clear()
            migrilla_detalle.Columns.Add("cod_producto", "CODIGO")
            migrilla_detalle.Columns.Add("detalle_nombre", "NOMBRE")
            migrilla_detalle.Columns.Add("valor_unitario", "VALOR")
            migrilla_detalle.Columns.Add("detalle_descuento", "DCTO.")
            migrilla_detalle.Columns.Add("cantidad", "CANTIDAD")
            migrilla_detalle.Columns.Add("detalle_total", "TOTAL")

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    migrilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If




            migrilla_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight




            Exit Sub
        End If

        If combo_documentos.Text = "COMPRAS" Then
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'conexion.Open()

            'SC.Connection = conexion
            'SC.CommandText = "select cod_producto as Codigo, nombre as Nombre, valor_unitario as Valor, cantidad as Cantidad, Neto as Neto, iva as IVA, total as Total from detalle_compra  where  n_compra = '" & (columna_seleccionada) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            'migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            'conexion.Close()






            conexion.Close()

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_compra  where  n_compra = '" & (columna_seleccionada) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            migrilla_detalle.Rows.Clear()
            migrilla_detalle.Columns.Clear()
            migrilla_detalle.Columns.Add("cod_producto", "CODIGO")
            migrilla_detalle.Columns.Add("nombre", "NOMBRE")
            migrilla_detalle.Columns.Add("valor_unitario", "VALOR")
            migrilla_detalle.Columns.Add("descuento", "DCTO.")
            migrilla_detalle.Columns.Add("cantidad", "CANTIDAD")
            migrilla_detalle.Columns.Add("total", "TOTAL")

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    migrilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"))
                Next
            End If






            migrilla_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight






            Exit Sub
        End If

        If combo_documentos.Text = "GUIA" Then
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'conexion.Open()

            'SC.Connection = conexion
            'SC.CommandText = "select cod_producto as Codigo, detalle_nombre as Nombre, valor_unitario as Valor, cantidad as Cantidad, detalle_Neto as Neto, detalle_iva as IVA, detalle_total as Total from detalle_guia  where  n_guia = '" & (columna_seleccionada) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            'migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            'conexion.Close()







            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_guia  where  n_guia = '" & (columna_seleccionada) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            migrilla_detalle.Rows.Clear()
            migrilla_detalle.Columns.Clear()
            migrilla_detalle.Columns.Add("cod_producto", "CODIGO")
            migrilla_detalle.Columns.Add("detalle_nombre", "NOMBRE")
            migrilla_detalle.Columns.Add("valor_unitario", "VALOR")
            migrilla_detalle.Columns.Add("detalle_descuento", "DCTO.")
            migrilla_detalle.Columns.Add("cantidad", "CANTIDAD")
            migrilla_detalle.Columns.Add("detalle_total", "TOTAL")

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    migrilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If







            migrilla_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight










            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA" Then
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'conexion.Open()

            'SC.Connection = conexion
            'SC.CommandText = "select cod_producto as Codigo, detalle_nombre as Nombre, valor_unitario as Valor, cantidad as Cantidad, detalle_Neto as Neto, detalle_iva as IVA, detalle_total as Total from detalle_boleta  where  n_boleta = '" & (columna_seleccionada) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            'migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            'conexion.Close()




            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select *  from detalle_boleta  where  n_boleta = '" & (columna_seleccionada) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            migrilla_detalle.Rows.Clear()
            migrilla_detalle.Columns.Clear()
            migrilla_detalle.Columns.Add("cod_producto", "CODIGO")
            migrilla_detalle.Columns.Add("detalle_nombre", "NOMBRE")
            migrilla_detalle.Columns.Add("valor_unitario", "VALOR")
            migrilla_detalle.Columns.Add("detalle_descuento", "DCTO.")
            migrilla_detalle.Columns.Add("cantidad", "CANTIDAD")
            migrilla_detalle.Columns.Add("detalle_total", "TOTAL")

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    migrilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If






            migrilla_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight















            Exit Sub
        End If

        If combo_documentos.Text = "COTIZACION" Then
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'conexion.Open()

            'SC.Connection = conexion
            'SC.CommandText = "select * from detalle_cotizacion  where  n_cotizacion = '" & (columna_seleccionada) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            'migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            'conexion.Close()











            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_cotizacion  where  n_cotizacion = '" & (columna_seleccionada) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            migrilla_detalle.Rows.Clear()
            migrilla_detalle.Columns.Clear()
            migrilla_detalle.Columns.Add("cod_producto", "CODIGO")
            migrilla_detalle.Columns.Add("detalle_nombre", "NOMBRE")
            migrilla_detalle.Columns.Add("valor_unitario", "VALOR")
            migrilla_detalle.Columns.Add("detalle_descuento", "DCTO.")
            migrilla_detalle.Columns.Add("cantidad", "CANTIDAD")
            migrilla_detalle.Columns.Add("detalle_total", "TOTAL")

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    migrilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If






            migrilla_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight





            Exit Sub
        End If

    End Sub

    Private Sub migrilla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles migrilla.Click
        If migrilla.Rows.Count <> 0 Then
            mostrar_malla_detalle()
        End If
    End Sub

    Private Sub migrilla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles migrilla.DoubleClick
        If migrilla.Rows.Count <> 0 Then

            Dim estado As String
            Dim nro_guia As String
            Dim nro_factura As String
            ' Dim fecha_factura As String
            Dim tipo_doc As String

            nro_guia = migrilla.CurrentRow.Cells(0).Value
            tipo_doc = migrilla.CurrentRow.Cells(1).Value
            estado = migrilla.CurrentRow.Cells(8).Value

            If tipo_doc = "GUIA" And estado = "FACTURADA" Then

                conexion.Close()
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from detalle_factura where cod_producto ='" & (nro_guia) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    nro_factura = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
                    '    fecha_factura = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")


                    MsgBox("GUIA FACTURADA CON DOCUMENTO NUMERO: " & nro_factura, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                End If
                conexion.Close()
                'End If
            End If
        End If
    End Sub

    'se llama al sub que muestra el detalle de la grilla.
    Private Sub migrilla_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles migrilla.RowHeaderMouseClick
        mostrar_malla_detalle()
    End Sub

    'sale de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    'hace un delete en el documento.
    Sub eliminacion_documentos()
        Dim valormensaje As Integer
        codigo_documento = migrilla.CurrentRow.Cells(0).Value
        tipo_documento = migrilla.CurrentRow.Cells(1).Value

        If combo_documentos.Text = "FACTURA" Then
            valormensaje = MsgBox("¿desea eliminar esta factura de contado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")

            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from factura where rut = '" & (txt_rut.Text) & "' and n_factura = '" & (codigo_documento) & "' and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "delete from total where rut = '" & (txt_rut.Text) & "' and n_total = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            actualizar_tabla_factura()
            actualizar_tabla_totales()
            mostrar_malla()
            migrilla_detalle.DataSource = Nothing
            Exit Sub
        End If

        If combo_documentos.Text = "FACTURA CREDITO" Then
            valormensaje = MsgBox("¿desea eliminar esta factura de credito?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")

            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from factura_credito where rut = '" & (txt_rut.Text) & "' and n_factura_credito = '" & (codigo_documento) & "' and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "delete from total where rut = '" & (txt_rut.Text) & "' and n_total = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            actualizar_tabla_factura_credito()
            actualizar_tabla_totales()
            mostrar_malla()
            migrilla_detalle.DataSource = Nothing
            Exit Sub
        End If

        If combo_documentos.Text = "GUIA" Then
            valormensaje = MsgBox("¿desea eliminar esta guia?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")

            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from guia where rut = '" & (txt_rut.Text) & "' and n_guia = '" & (codigo_documento) & "' and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "delete from total where rut = '" & (txt_rut.Text) & "' and n_total = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            actualizar_tabla_factura()
            actualizar_tabla_totales()
            mostrar_malla()
            migrilla_detalle.DataSource = Nothing
            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA" Then
            valormensaje = MsgBox("¿desea eliminar esta BOLETA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")

            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from BOLETA where rut = '" & (txt_rut.Text) & "' and n_boleta = '" & (codigo_documento) & "' and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "delete from total where rut = '" & (txt_rut.Text) & "' and n_total = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            actualizar_tabla_factura()
            actualizar_tabla_totales()
            mostrar_malla()
            migrilla_detalle.DataSource = Nothing
            Exit Sub
        End If
    End Sub

    ' hace un update al estadodel documento dejandolo nulo.
    Sub anulacion_documentos()
        Dim valormensaje As Integer
        codigo_documento = migrilla.CurrentRow.Cells(0).Value
        tipo_documento = migrilla.CurrentRow.Cells(1).Value

        If combo_documentos.Text = "FACTURA" Then
            valormensaje = MsgBox("¿desea anular esta factura de contado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")

            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "update factura set estado = '" & ("anulada") & "' where rut = '" & (txt_rut.Text) & "' and n_factura = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update total set estado = '" & ("anulada") & "' where rut = '" & (txt_rut.Text) & "' and n_total = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            actualizar_tabla_factura()
            actualizar_tabla_totales()
            mostrar_malla()
            migrilla_detalle.DataSource = Nothing
            Exit Sub
        End If

        If combo_documentos.Text = "FACTURA CREDITO" Then
            valormensaje = MsgBox("¿desea anular esta factura de credito?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")

            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "update factura_credito set estado = '" & ("anulada") & "' where rut = '" & (txt_rut.Text) & "' and n_factura_credito = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update total set estado = '" & ("anulada") & "' where rut = '" & (txt_rut.Text) & "' and n_total = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            actualizar_tabla_factura_credito()
            actualizar_tabla_totales()
            mostrar_malla()
            migrilla_detalle.DataSource = Nothing
            Exit Sub
        End If

        If combo_documentos.Text = "GUIA" Then
            valormensaje = MsgBox("¿desea anular esta guia?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")

            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "update guia set estado = '" & ("anulada") & "' where rut = '" & (txt_rut.Text) & "' and n_guia = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update total set estado = '" & ("anulada") & "' where rut = '" & (txt_rut.Text) & "' and n_total = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            actualizar_tabla_factura()
            actualizar_tabla_totales()
            mostrar_malla()
            migrilla_detalle.DataSource = Nothing
            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA" Then
            valormensaje = MsgBox("¿desea anular esta BOLETA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")

            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "update BOLETA set estado = '" & ("anulada") & "' where rut = '" & (txt_rut.Text) & "' and n_boleta = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update total set estado = '" & ("anulada") & "' where rut = '" & (txt_rut.Text) & "' and n_total = '" & (codigo_documento) & "'  and TIPO  = '" & (tipo_documento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            actualizar_tabla_factura()
            actualizar_tabla_totales()
            mostrar_malla()
            migrilla_detalle.DataSource = Nothing
            Exit Sub
        End If
    End Sub

    'actualiza la tabla totales.
    Sub actualizar_tabla_totales()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from total"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    'actualiza la tabla factura.
    Sub actualizar_tabla_factura()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from factura"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    'actualiza la tabla factura de creidto.
    Sub actualizar_tabla_factura_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from factura_credito"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    'actualiza la tabla guia.
    Sub actualizar_tabla_guia()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from guia"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    'actualiza la tabla factura.
    Sub actualizar_tabla_boletas()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from BOLETA"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    'verifica si la grilla esta vacia, sino anula el documento.
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mensaje As String = ""
        If migrilla.Rows.Count = 0 Then
            mensaje = "grilla vacía, seleccione algun documento" + Chr(13)
            MsgBox(mensaje, MsgBoxStyle.Exclamation)
        Else
            anulacion_documentos()
        End If
    End Sub

    'verifica si la grilla esta vacia, sino elimina el documento.
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mensaje As String = ""
        If migrilla.Rows.Count = 0 Then
            mensaje = "grilla vacía, seleccione algun documento"
            MsgBox(mensaje, MsgBoxStyle.Exclamation)
        Else
            eliminacion_documentos()
        End If
    End Sub

    'se llama al sub fecha, fecha2 y el mostrar malla.
    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp1.ValueChanged
        fecha()
        fecha2()
        mostrar_malla()
    End Sub

    'se llama al sub fecha, fecha2 y el mostrar malla.
    Private Sub dtp2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp2.ValueChanged
        fecha()
        fecha2()
        mostrar_malla()
    End Sub

    'se limpia la pantalla para ingresar datos.
    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim mensaje As String = ""
        If migrilla.Rows.Count = 0 Then mensaje = "Grilla vacía, no hay nada que limpiar" + Chr(13) & mensaje

        If mensaje <> "" Then
            MsgBox(mensaje, MsgBoxStyle.OkOnly)
        Else
            migrilla.Rows.Clear()
            migrilla_detalle.Rows.Clear()
        End If
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.GotFocus
        txt_rut.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut.KeyPress
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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            guion_rut_cliente()
            mostrar_datos_clientes()
            mostrar_malla()
        End If

        If (e.KeyChar = Convert.ToChar(Keys.F4)) Then
            btn_buscar_clientes.PerformClick()
        End If
    End Sub


    Private Sub btn_volver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txt_rut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_clientes_documentos.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_volver_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_volver.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_volver_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_volver.BackColor = Color.Transparent
    'End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub migrilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles migrilla.CellContentClick

    End Sub

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.Click
        conexion.Close()
        Me.Enabled = False
        txt_rut.Focus()
        Form_buscador_clientes_documentos.Show()
        Form_buscador_clientes_documentos.txt_busqueda.Focus()
    End Sub

    Private Sub btn_buscar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.LostFocus

    End Sub

 

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class