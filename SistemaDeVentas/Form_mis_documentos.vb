Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Form_mis_documentos
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim consulta_busqueda As String
    Private WithEvents Pd As New PrintDocument
    Dim alto_cotizacion As String
    Dim peso As String
    Dim cantidad_letras As Integer
    Dim desglose_palabras As String
    'Dim impreso As Integer = 0
    Dim impresora_ticket_cotizaciones As String
    Dim impresora_ticket_ventas As String

    Private Sub Form_mis_cotizaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_mis_cotizaciones_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_mis_cotizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_vendedor()
        combo_venta.SelectedItem = "COTIZACION"
        Combo_vendedor.SelectedItem = minombre
        grilla_documento.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        grilla_detalle_documento.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        If combo_venta.Text <> "COTIZACION" Then
            btn_imprimir.Enabled = False
        Else
            btn_imprimir.Enabled = True
        End If
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
            impresora_ticket_cotizaciones = DS.Tables(DT.TableName).Rows(0).Item("ticket_cotizaciones")
            impresora_ticket_ventas = DS.Tables(DT.TableName).Rows(0).Item("ticket_ventas")
        End If
        conexion.Close()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub llenar_combo_vendedor()
        Combo_vendedor.Items.Clear()
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
            Combo_vendedor.Items.Add("TODOS")
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        conexion.Close()
    End Sub

    
    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub



    Sub mostrar_malla()
        fecha()

        If combo_venta.Text = "COTIZACION" Then
            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            SC3.CommandText = "select  n_cotizacion as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', cotizacion.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from cotizacion, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and cotizacion.usuario_responsable=usuarios.rut_usuario and cotizacion.rut_cliente=clientes.rut_cliente group by n_cotizacion order by n_cotizacion desc"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_documento.Columns(3).Visible = False

            For i = 0 To grilla_documento.Rows.Count - 1
                If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                    grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            grilla_detalle_documento.Rows.Clear()

        End If

        If combo_venta.Text = "BOLETA" Then
            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            SC3.CommandText = "select  n_boleta as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', BOLETA.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from BOLETA, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and BOLETA.usuario_responsable=usuarios.rut_usuario and BOLETA.rut_cliente=clientes.rut_cliente group by n_boleta order by n_boleta desc"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_documento.Columns(3).Visible = False

            For i = 0 To grilla_documento.Rows.Count - 1
                If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                    grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            grilla_detalle_documento.Rows.Clear()

        End If

        If combo_venta.Text = "FACTURA" Then
            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            SC3.CommandText = "select  n_factura as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', factura.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from factura, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and factura.usuario_responsable=usuarios.rut_usuario and factura.rut_cliente=clientes.rut_cliente group by n_factura order by n_factura desc"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_documento.Columns(3).Visible = False

            For i = 0 To grilla_documento.Rows.Count - 1
                If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                    grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            grilla_detalle_documento.Rows.Clear()

        End If

        If combo_venta.Text = "GUIA" Then
            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            SC3.CommandText = "select  n_guia as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', guia.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from guia, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and guia.usuario_responsable=usuarios.rut_usuario and guia.rut_cliente=clientes.rut_cliente group by n_guia order by n_guia desc"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_documento.Columns(3).Visible = False

            For i = 0 To grilla_documento.Rows.Count - 1
                If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                    grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            grilla_detalle_documento.Rows.Clear()
        End If

        If combo_venta.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            SC3.CommandText = "select  n_nota_credito as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', nota_credito.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from nota_credito, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.usuario_responsable=usuarios.rut_usuario and nota_credito.rut_cliente=clientes.rut_cliente group by n_nota_credito order by n_nota_credito desc"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_documento.Columns(3).Visible = False

            For i = 0 To grilla_documento.Rows.Count - 1
                If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                    grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            grilla_detalle_documento.Rows.Clear()

        End If
    End Sub



    Sub mostrar_letra()
        Dim condicion As String
        condicion = grilla_documento.CurrentRow.Cells(1).Value
        Dim nro_doc As String
        nro_doc = grilla_documento.CurrentRow.Cells(0).Value

        If combo_venta.Text = "BOLETA" And condicion = "LETRA" Then


            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select  n_letra, cant_letras, DOC_REFEREnCIA,  NRO_REFEREnCIA, fecha AS FECHA, LETRAS.rut_cliente AS RUT_CLIENTE, nombre_cliente, TELEFONO_cliente, ciudad_cliente, DIRECCION_cliente, MONTO_LETRA, TOTAL_LETRA  from LETRAS, clientes  where LETRAS.rut_cliente=clientes.rut_cliente and doc_referencia='" & (combo_venta.Text) & "' and nro_referencia='" & (nro_doc) & "'"


            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_letra.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_letra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_letra"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cant_letras"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("DOC_REFEREnCIA"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("NRO_REFEREnCIA"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("FECHA"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("RUT_CLIENTE"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("TELEFONO_cliente"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("ciudad_cliente"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("DIRECCION_cliente"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("MONTO_LETRA"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("TOTAL_LETRA"))
                Next
            End If






        End If

        If combo_venta.Text = "FACTURA" And condicion = "LETRA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select  n_letra, cant_letras, DOC_REFEREnCIA,  NRO_REFEREnCIA, fecha AS FECHA, LETRAS.rut_cliente AS RUT_CLIENTE, nombre_cliente, TELEFONO_cliente, ciudad_cliente,  DIRECCION_cliente, MONTO_LETRA, TOTAL_LETRA  from LETRAS, clientes  where LETRAS.rut_cliente=clientes.rut_cliente and doc_referencia='" & (combo_venta.Text) & "' and nro_referencia='" & (nro_doc) & "'"


            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_letra.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_letra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_letra"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cant_letras"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("DOC_REFEREnCIA"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("NRO_REFEREnCIA"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("FECHA"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("RUT_CLIENTE"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("TELEFONO_cliente"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("ciudad_cliente"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("DIRECCION_cliente"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("MONTO_LETRA"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("TOTAL_LETRA"))
                Next
            End If
        End If
    End Sub





    Sub busqueda_por_descripcion()

        If combo_venta.Text = "COTIZACION" Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            If txt_buscar.Text <> "" Then

                consulta_busqueda = "select  cotizacion.n_cotizacion as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', cotizacion.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', cotizacion.porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from cotizacion, usuarios, clientes, DETALLE_COTIZACION  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and cotizacion.usuario_responsable=usuarios.rut_usuario and cotizacion.rut_cliente=clientes.rut_cliente AND cotizacion.n_cotizacion = detalle_cotizacion.n_cotizacion "

                Dim cadena As String
                Dim tabla() As String
                Dim n As Integer

                cadena = txt_buscar.Text

                tabla = Split(cadena, " ")

                For n = 0 To UBound(tabla, 1)
                    consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',detalle_cotizacion.COD_PRODUCTO, detalle_cotizacion.detalle_NOMBRE, detalle_cotizacion.NUMERO_TECNICO) LIKE '" & ("%" & tabla(n) & "%") & "'"
                Next

                consulta_busqueda = consulta_busqueda & " group by cotizacion.n_cotizacion order by cotizacion.n_cotizacion desc"

                grilla_documento.DataSource = Nothing

                Dim DT As New DataTable

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = consulta_busqueda
                DA.SelectCommand = SC

                DA.Fill(DT)
                DS.Tables.Add(DT)

                grilla_documento.DataSource = DS.Tables(DT.TableName)
                conexion.Close()

                grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                grilla_documento.Columns(3).Visible = False

                For i = 0 To grilla_documento.Rows.Count - 1
                    If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                        grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                    End If
                Next

                grilla_detalle_documento.Rows.Clear()

                lbl_mensaje.Visible = False
                Me.Enabled = True
            End If
        End If
















        If combo_venta.Text = "BOLETA" Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            If txt_buscar.Text <> "" Then

                consulta_busqueda = "select  BOLETA.n_boleta as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', BOLETA.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', BOLETA.porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from BOLETA, usuarios, clientes, DETALLE_boleta  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and BOLETA.usuario_responsable=usuarios.rut_usuario and BOLETA.rut_cliente=clientes.rut_cliente AND BOLETA.n_boleta = detalle_boleta.n_boleta "

                Dim cadena As String
                Dim tabla() As String
                Dim n As Integer

                cadena = txt_buscar.Text

                tabla = Split(cadena, " ")

                For n = 0 To UBound(tabla, 1)
                    consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',detalle_boleta.COD_PRODUCTO, detalle_boleta.detalle_NOMBRE, detalle_boleta.NUMERO_TECNICO) LIKE '" & ("%" & tabla(n) & "%") & "'"
                Next

                consulta_busqueda = consulta_busqueda & " group by BOLETA.n_boleta order by BOLETA.n_boleta desc"

                grilla_documento.DataSource = Nothing

                Dim DT As New DataTable

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = consulta_busqueda
                DA.SelectCommand = SC

                DA.Fill(DT)
                DS.Tables.Add(DT)

                grilla_documento.DataSource = DS.Tables(DT.TableName)
                conexion.Close()

                grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                grilla_documento.Columns(3).Visible = False

                For i = 0 To grilla_documento.Rows.Count - 1
                    If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                        grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                    End If
                Next

                grilla_detalle_documento.Rows.Clear()

            End If

            '  grilla_detalle_documento.Rows.Clear()

            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If


















        If combo_venta.Text = "FACTURA" Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            If txt_buscar.Text <> "" Then

                consulta_busqueda = "select  factura.n_factura as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', factura.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', factura.porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from factura, usuarios, clientes, DETALLE_factura  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and factura.usuario_responsable=usuarios.rut_usuario and factura.rut_cliente=clientes.rut_cliente AND factura.n_factura = detalle_factura.n_factura "

                Dim cadena As String
                Dim tabla() As String
                Dim n As Integer

                cadena = txt_buscar.Text

                tabla = Split(cadena, " ")

                For n = 0 To UBound(tabla, 1)
                    consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',detalle_factura.COD_PRODUCTO, detalle_factura.detalle_NOMBRE, detalle_factura.NUMERO_TECNICO) LIKE '" & ("%" & tabla(n) & "%") & "'"
                Next

                consulta_busqueda = consulta_busqueda & " group by factura.n_factura order by factura.n_factura desc"

                grilla_documento.DataSource = Nothing

                Dim DT As New DataTable

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = consulta_busqueda
                DA.SelectCommand = SC

                DA.Fill(DT)
                DS.Tables.Add(DT)

                grilla_documento.DataSource = DS.Tables(DT.TableName)
                conexion.Close()

                grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                grilla_documento.Columns(3).Visible = False

                For i = 0 To grilla_documento.Rows.Count - 1
                    If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                        grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                    End If
                Next

                grilla_detalle_documento.Rows.Clear()
            End If

            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If





















        If combo_venta.Text = "GUIA" Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            If txt_buscar.Text <> "" Then

                consulta_busqueda = "select  guia.n_guia as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', guia.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL',  guia.porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from guia, usuarios, clientes, DETALLE_guia  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and guia.usuario_responsable=usuarios.rut_usuario and guia.rut_cliente=clientes.rut_cliente AND guia.n_guia = detalle_guia.n_guia "

                Dim cadena As String
                Dim tabla() As String
                Dim n As Integer

                cadena = txt_buscar.Text

                tabla = Split(cadena, " ")

                For n = 0 To UBound(tabla, 1)
                    consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',detalle_guia.COD_PRODUCTO, detalle_guia.detalle_NOMBRE, detalle_guia.NUMERO_TECNICO) LIKE '" & ("%" & tabla(n) & "%") & "'"
                Next

                consulta_busqueda = consulta_busqueda & " group by guia.n_guia order by guia.n_guia desc"

                grilla_documento.DataSource = Nothing

                Dim DT As New DataTable

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = consulta_busqueda
                DA.SelectCommand = SC

                DA.Fill(DT)
                DS.Tables.Add(DT)

                grilla_documento.DataSource = DS.Tables(DT.TableName)
                conexion.Close()

                grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                grilla_documento.Columns(3).Visible = False

                For i = 0 To grilla_documento.Rows.Count - 1
                    If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                        grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                    End If
                Next

                grilla_detalle_documento.Rows.Clear()

            End If

            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If
























        If combo_venta.Text = "NOTA DE CREDITO" Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            If txt_buscar.Text <> "" Then

                consulta_busqueda = "select  nota_credito.n_nota_credito as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', nota_credito.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', nota_credito.porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from nota_credito, usuarios, clientes, DETALLE_nota_credito  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.usuario_responsable=usuarios.rut_usuario and nota_credito.rut_cliente=clientes.rut_cliente AND nota_credito.n_nota_credito = detalle_nota_credito.n_nota_credito "

                Dim cadena As String
                Dim tabla() As String
                Dim n As Integer

                cadena = txt_buscar.Text

                tabla = Split(cadena, " ")

                For n = 0 To UBound(tabla, 1)
                    consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',detalle_nota_credito.COD_PRODUCTO, detalle_nota_credito.detalle_NOMBRE, detalle_nota_credito.NUMERO_TECNICO) LIKE '" & ("%" & tabla(n) & "%") & "'"
                Next

                consulta_busqueda = consulta_busqueda & " group by nota_credito.n_nota_credito order by nota_credito.n_nota_credito desc"

                grilla_documento.DataSource = Nothing

                Dim DT As New DataTable

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = consulta_busqueda
                DA.SelectCommand = SC

                DA.Fill(DT)
                DS.Tables.Add(DT)

                grilla_documento.DataSource = DS.Tables(DT.TableName)
                conexion.Close()

                grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                grilla_documento.Columns(3).Visible = False

                For i = 0 To grilla_documento.Rows.Count - 1
                    If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                        grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                    End If
                Next

                grilla_detalle_documento.Rows.Clear()

            End If

            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If






    End Sub











    Sub mostrar_malla_detalle()
        If combo_venta.Text = "COTIZACION" Then
            Dim nro_doc As String
            nro_doc = grilla_documento.CurrentRow.Cells(0).Value

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_cotizacion  where n_cotizacion= '" & (nro_doc) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"))
                Next
            End If
        End If

        If combo_venta.Text = "BOLETA" Then
            Dim nro_doc As String
            nro_doc = grilla_documento.CurrentRow.Cells(0).Value

            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            SC2.Connection = conexion
            SC2.CommandText = "select * from detalle_boleta  where n_boleta= '" & (nro_doc) & "'"

            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            grilla_detalle_documento.Rows.Clear()

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then

                For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS2.Tables(DT2.TableName).Rows(i).Item("cod_producto"), _
                                                       DS2.Tables(DT2.TableName).Rows(i).Item("detalle_nombre"), _
                                                        DS2.Tables(DT2.TableName).Rows(i).Item("valor_unitario"), _
                                                         DS2.Tables(DT2.TableName).Rows(i).Item("cantidad"), _
                                                          DS2.Tables(DT2.TableName).Rows(i).Item("detalle_subtotal"), _
                                                           DS2.Tables(DT2.TableName).Rows(i).Item("detalle_descuento"), _
                                                            DS2.Tables(DT2.TableName).Rows(i).Item("detalle_neto"), _
                                                             DS2.Tables(DT2.TableName).Rows(i).Item("detalle_iva"), _
                                                              DS2.Tables(DT2.TableName).Rows(i).Item("detalle_total"), _
                                                               DS2.Tables(DT2.TableName).Rows(i).Item("numero_tecnico"))
                Next
            End If
        End If

        If combo_venta.Text = "FACTURA" Then
            Dim nro_doc As String
            nro_doc = grilla_documento.CurrentRow.Cells(0).Value

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura  where n_factura= '" & (nro_doc) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"))
                Next
            End If
        End If

        If combo_venta.Text = "GUIA" Then
            Dim nro_doc As String
            nro_doc = grilla_documento.CurrentRow.Cells(0).Value

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_guia  where n_guia= '" & (nro_doc) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"))
                Next
            End If
        End If

        If combo_venta.Text = "NOTA DE CREDITO" Then
            Dim nro_doc As String
            nro_doc = grilla_documento.CurrentRow.Cells(0).Value

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_nota_credito  where n_nota_credito= '" & (nro_doc) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"))
                Next
            End If
        End If
    End Sub

    Sub mostrar_datos_clientes()
        conexion.Close()
        If txt_rut_cliente.Text <> "" Then
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

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                conexion.Close()
                busqueda()
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
        End If
    End Sub

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub grilla_documento_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If grilla_documento.Rows.Count <> 0 Then
            mostrar_malla_detalle()
        End If
    End Sub

    Private Sub grilla_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub














    Sub busqueda()
        lbl_mensaje.Visible = True
        Me.Enabled = False





        fecha()

        If combo_venta.Text = "COTIZACION" Then

            Dim vendedor As String

            If Combo_vendedor.Text = "TODOS" Then
                vendedor = ""
            Else
                vendedor = Combo_vendedor.Text
            End If

            consulta_busqueda = "select  n_cotizacion as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', cotizacion.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from cotizacion, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and cotizacion.usuario_responsable=usuarios.rut_usuario and cotizacion.rut_cliente=clientes.rut_cliente "

            If Combo_vendedor.Text <> "TODOS" Then
                consulta_busqueda = consulta_busqueda & " and usuario_responsable ='" & (txt_rut_vendedor.Text) & "'"
            Else
                consulta_busqueda = consulta_busqueda
            End If

            If txt_rut_cliente.Text <> "" Then
                consulta_busqueda = consulta_busqueda & " and CLIENTES.rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            Else
                consulta_busqueda = consulta_busqueda
            End If

            consulta_busqueda = consulta_busqueda & " group by cotizacion.n_cotizacion order by cotizacion.n_cotizacion desc"

            grilla_detalle_documento.Rows.Clear()

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            SC3.CommandText = consulta_busqueda

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_documento.Columns(3).Visible = False

            For i = 0 To grilla_documento.Rows.Count - 1
                If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                    grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            grilla_detalle_documento.Rows.Clear()

            txt_buscar.Text = ""

            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If














        If combo_venta.Text = "BOLETA" Then
            Dim vendedor As String

            If Combo_vendedor.Text = "TODOS" Then
                vendedor = ""
            Else
                vendedor = Combo_vendedor.Text
            End If

            consulta_busqueda = "select  n_boleta as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', BOLETA.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from BOLETA, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and BOLETA.usuario_responsable=usuarios.rut_usuario and BOLETA.rut_cliente=clientes.rut_cliente"

            If vendedor <> "" Then
                consulta_busqueda = consulta_busqueda & " and usuario_responsable ='" & (txt_rut_vendedor.Text) & "'"
            Else
                consulta_busqueda = consulta_busqueda
            End If

            If txt_rut_cliente.Text <> "" Then
                consulta_busqueda = consulta_busqueda & " and CLIENTES.rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            Else
                consulta_busqueda = consulta_busqueda
            End If

            consulta_busqueda = consulta_busqueda & " group by BOLETA.n_boleta order by BOLETA.n_boleta desc"

            grilla_detalle_documento.Rows.Clear()

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            SC3.CommandText = consulta_busqueda

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_documento.Columns(3).Visible = False

            For i = 0 To grilla_documento.Rows.Count - 1
                If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                    grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            grilla_detalle_documento.Rows.Clear()

            txt_buscar.Text = ""

            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If















        If combo_venta.Text = "FACTURA" Then
            Dim vendedor As String

            If Combo_vendedor.Text = "TODOS" Then
                vendedor = ""
            Else
                vendedor = Combo_vendedor.Text
            End If

            consulta_busqueda = "select  n_factura as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', factura.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from factura, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and factura.usuario_responsable=usuarios.rut_usuario and factura.rut_cliente=clientes.rut_cliente "

            If vendedor <> "" Then
                consulta_busqueda = consulta_busqueda & " and usuario_responsable ='" & (txt_rut_vendedor.Text) & "'"
            Else
                consulta_busqueda = consulta_busqueda
            End If

            If txt_rut_cliente.Text <> "" Then
                consulta_busqueda = consulta_busqueda & " and CLIENTES.rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            Else
                consulta_busqueda = consulta_busqueda
            End If

            consulta_busqueda = consulta_busqueda & " group by factura.n_factura order by factura.n_factura desc"

            grilla_detalle_documento.Rows.Clear()

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            SC3.CommandText = consulta_busqueda

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_documento.Columns(3).Visible = False

            For i = 0 To grilla_documento.Rows.Count - 1
                If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                    grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            grilla_detalle_documento.Rows.Clear()

            txt_buscar.Text = ""

            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If
















        If combo_venta.Text = "GUIA" Then
            Dim vendedor As String

            If Combo_vendedor.Text = "TODOS" Then
                vendedor = ""
            Else
                vendedor = Combo_vendedor.Text
            End If

            consulta_busqueda = "select  n_guia as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', guia.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from guia, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and guia.usuario_responsable=usuarios.rut_usuario and guia.rut_cliente=clientes.rut_cliente "

            If vendedor <> "" Then
                consulta_busqueda = consulta_busqueda & " and usuario_responsable ='" & (txt_rut_vendedor.Text) & "'"
            Else
                consulta_busqueda = consulta_busqueda
            End If

            If txt_rut_cliente.Text <> "" Then
                consulta_busqueda = consulta_busqueda & " and CLIENTES.rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            Else
                consulta_busqueda = consulta_busqueda
            End If

            consulta_busqueda = consulta_busqueda & " group by guia.n_guia order by guia.n_guia desc"

            grilla_detalle_documento.Rows.Clear()

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            SC3.CommandText = consulta_busqueda

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_documento.Columns(3).Visible = False

            For i = 0 To grilla_documento.Rows.Count - 1
                If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                    grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            grilla_detalle_documento.Rows.Clear()

            txt_buscar.Text = ""

            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If














        If combo_venta.Text = "NOTA DE CREDITO" Then
            Dim vendedor As String

            If Combo_vendedor.Text = "TODOS" Then
                vendedor = ""
            Else
                vendedor = Combo_vendedor.Text
            End If

            consulta_busqueda = "select  n_nota_credito as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', nota_credito.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR' from nota_credito, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.usuario_responsable=usuarios.rut_usuario and nota_credito.rut_cliente=clientes.rut_cliente "

            If vendedor <> "" Then
                consulta_busqueda = consulta_busqueda & " and vendedor ='" & (txt_rut_vendedor.Text) & "'"
            Else
                consulta_busqueda = consulta_busqueda
            End If

            If txt_rut_cliente.Text <> "" Then
                consulta_busqueda = consulta_busqueda & " and CLIENTES.rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            Else
                consulta_busqueda = consulta_busqueda
            End If

            consulta_busqueda = consulta_busqueda & " group by nota_credito.n_nota_credito order by nota_credito.n_nota_credito desc"

            grilla_detalle_documento.Rows.Clear()

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            SC3.CommandText = consulta_busqueda

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_documento.Columns(3).Visible = False

            If Combo_vendedor.Text = "" Then
                Combo_vendedor.Text = "TODOS"
            End If

            grilla_documento.Columns(3).Visible = False

            For i = 0 To grilla_documento.Rows.Count - 1
                If minombre = grilla_documento.Rows(i).Cells(10).Value.ToString Then
                    grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            grilla_detalle_documento.Rows.Clear()

            txt_buscar.Text = ""

            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_vendedor.TextChanged

    End Sub

    Private Sub txt_rut_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress

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




        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            guion_rut_cliente()
            mostrar_datos_clientes()
            busqueda()
        End If
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

    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged

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


    End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        lbl_mensaje.Visible = True
        Me.Enabled = False
        mostrar_datos_vendedor()
        busqueda()



        If combo_venta.Text <> "COTIZACION" Then
            btn_imprimir.Enabled = False
        Else
            btn_imprimir.Enabled = True

        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True


    End Sub



    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        busqueda()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        busqueda()
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        Combo_vendedor.Text = "TODOS"
        busqueda_por_descripcion()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage

        'crear_numero_factura()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim VarValorUnitario As String
        Dim VarCantidad As String
        Dim VarDescuento As String
        Dim VarNeto As String
        Dim VarIva As String
        Dim VarSubtotal As String
        Dim VarTotal As String







        'Dim Font11 As New Font("Lucida Console", 11, FontStyle.Regular)
        'Dim Font10 As New Font("Lucida Console", 10, FontStyle.Regular)
        'Dim Font9 As New Font("Lucida Console", 9, FontStyle.Regular)
        'Dim Font8 As New Font("Lucida Console", 8, FontStyle.Regular)

        Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)



        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far





        Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        Dim Font2 As New Font("arial", 9, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        Dim im As Image


        Try
            im = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
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



        Dim rect1 As New Rectangle(10, 60, 270, 15)
        Dim rect2 As New Rectangle(10, 75, 270, 15)
        Dim rect3 As New Rectangle(10, 90, 270, 15)
        Dim rect4 As New Rectangle(10, 105, 270, 15)
        Dim rect5 As New Rectangle(10, 120, 270, 15)
        Dim rect6 As New Rectangle(10, 135, 270, 15)
        Dim rect7 As New Rectangle(10, 165, 270, 15)

        Dim nro_documento As String
        Dim fecha_documento As String

        nro_documento = grilla_documento.CurrentRow.Cells(0).Value
        fecha_documento = grilla_documento.CurrentRow.Cells(2).Value

        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

        e.Graphics.DrawString("COTIZACION", Font2, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("NRO. COTIZACION", Font3, Brushes.Black, 0, 195)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 195)
        e.Graphics.DrawString(nro_documento, Font4, Brushes.Black, 95, 195)
        e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 210)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 210)
        e.Graphics.DrawString(fecha_documento, Font3, Brushes.Black, 95, 210)
        e.Graphics.DrawString("VENDEDOR", Font3, Brushes.Black, 0, 225)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 225)
        e.Graphics.DrawString(minombre, Font3, Brushes.Black, 95, 225)
        e.Graphics.DrawString("TELEFONO", Font3, Brushes.Black, 0, 240)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 240)
        e.Graphics.DrawString(mitelefono, Font3, Brushes.Black, 95, 240)

        e.Graphics.DrawString("CODIGO", Font3, Brushes.Black, 0, 270)
        e.Graphics.DrawString("DESCRIPCION", Font3, Brushes.Black, 55, 270)
        e.Graphics.DrawString("CANT.", Font3, Brushes.Black, 200, 270)
        e.Graphics.DrawString("TOTAL", Font3, Brushes.Black, 250, 270)

        e.Graphics.DrawLine(Pens.Black, 1, 285, 295, 285)

        For i = 0 To grilla_detalle_documento.Rows.Count - 1



            VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
            VarValorUnitario = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
            VarCantidad = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
            VarSubtotal = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
            VarDescuento = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
            VarNeto = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
            VarIva = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
            VarTotal = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString



            Dim cantidad As String
            Dim total As String




            cantidad = VarCantidad
            total = VarTotal




            Dim descripcion As String

            descripcion = varnombre
            If varnombre.Length > 23 Then
                descripcion = varnombre.Substring(0, 24)
            End If
            '  codigo_producto = Format(Int(codigo_producto), "###,###,###")
            ' descripcion = Format(Int(descripcion), "###,###,###")
            '   cantidad = Format(Int(cantidad), "###,###,###")
            total = Format(Int(total), "###,###,###")



            e.Graphics.DrawString(VarCodProducto, Font3, Brushes.Gray, 0, 290 + (i * 15))
            e.Graphics.DrawString(descripcion, Font3, Brushes.Gray, 55, 290 + (i * 15))
            e.Graphics.DrawString(cantidad, Font3, Brushes.Gray, 235, 290 + (i * 15), format1)
            e.Graphics.DrawString(total, Font3, Brushes.Gray, 285, 290 + (i * 15), format1)
        Next





        Dim subtotal_millar As String
        Dim descuento_millar As String
        Dim total_millar As String


        descuento_millar = grilla_documento.CurrentRow.Cells(6).Value
        subtotal_millar = grilla_documento.CurrentRow.Cells(5).Value
        total_millar = grilla_documento.CurrentRow.Cells(9).Value

        subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        descuento_millar = Format(Int(descuento_millar), "###,###,###")
        total_millar = Format(Int(total_millar), "###,###,###")


        Dim var_grilla As Integer
        var_grilla = ((grilla_detalle_documento.Rows.Count - 1) * 15)


        e.Graphics.DrawString("SUBTOTAL", Font3, Brushes.Black, 160, var_grilla + 320)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 230, var_grilla + 320)
        e.Graphics.DrawString(subtotal_millar, Font3, Brushes.Black, 285, var_grilla + 320, format1)
        e.Graphics.DrawString("DESCUENTO", Font3, Brushes.Black, 160, var_grilla + 335)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 230, var_grilla + 335)
        e.Graphics.DrawString(descuento_millar, Font3, Brushes.Black, 285, var_grilla + 335, format1)
        e.Graphics.DrawString("TOTAL", Font3, Brushes.Black, 160, var_grilla + 350)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 230, var_grilla + 350)
        e.Graphics.DrawString(total_millar, Font3, Brushes.Black, 285, var_grilla + 350, format1)




















        Dim rect8 As New Rectangle(10, var_grilla + 380, 270, 15)

        e.Graphics.DrawString("COTIZACION VALIDA POR 10 DIAS", Font3, Brushes.Gray, rect8, stringFormat)
        e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, var_grilla + 450)
        alto_cotizacion = var_grilla + 470

    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click

        If grilla_documento.Rows.Count = 0 Then
            MsgBox("SELECCIONE UN DOCUMENTO", 0 + 16, "ERROR")
            Combo_vendedor.Focus()
            Exit Sub
        End If



        If grilla_detalle_documento.Rows.Count = 0 Then
            MsgBox("SELECCIONE UN DOCUMENTO", 0 + 16, "ERROR")
            Combo_vendedor.Focus()
            Exit Sub
        End If



        If combo_venta.Text = "COTIZACION" Then
            With Pd.PrinterSettings
                ' Especifico el nombre de la impresora 
                ' por donde deseo imprimir. 
                .PrinterName = impresora_ticket_cotizaciones
                ' Establezco el número de copias que se imprimirán 
                .Copies = 1
                ' Rango de páginas que se imprimirán 
                .PrintRange = PrintRange.AllPages
                If .IsValid Then

                    lbl_mensaje.Visible = True
                    Me.Enabled = False


                    Me.Pd.PrintController = New StandardPrintController
                    Me.Pd.DefaultPageSettings.Margins.Left = 10
                    Me.Pd.DefaultPageSettings.Margins.Right = 10
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, alto_cotizacion)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                    Pd.Print()

                    ' Form_desea_enviar_cotizacion.Show()
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                Else
                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End With
        End If

        Dim condicion As String
        condicion = grilla_documento.CurrentRow.Cells(1).Value

    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.White
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.White
    End Sub

    Private Sub Combo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.GotFocus
        Combo_vendedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.LostFocus
        Combo_vendedor.BackColor = Color.White
    End Sub

    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.GotFocus
        combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.LostFocus
        combo_venta.BackColor = Color.White
    End Sub

    Private Sub txt_rut_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub


    Private Sub txt_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_buscar.GotFocus
        txt_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_buscar.LostFocus
        txt_buscar.BackColor = Color.White
    End Sub

    Private Sub migrilla_documentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.Click

        Dim condicion As String

        If grilla_documento.Rows.Count <> 0 Then
            condicion = grilla_documento.CurrentRow.Cells(1).Value

            If combo_venta.Text <> "COTIZACION" Then
                btn_imprimir.Enabled = False
            Else
                btn_imprimir.Enabled = True
            End If

            If condicion <> "LETRA" Then
                btn_imprimir.Enabled = False
            Else
                btn_imprimir.Enabled = True
            End If
        End If






        If grilla_documento.Rows.Count <> 0 Then
            mostrar_malla_detalle()
            mostrar_letra()
        End If




        If grilla_letra.Rows.Count <> 0 Then
            txt_total.Text = grilla_letra.CurrentRow.Cells(11).Value

            peso = " PESOS"
            If CInt(txt_total.Text) = 1000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & " DE PESOS"
            ElseIf CInt(txt_total.Text) = 2000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 3000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 4000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 5000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 6000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 7000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 8000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 9000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 10000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 11000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 12000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 13000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 14000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 15000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 16000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 17000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 18000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 19000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 20000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 21000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 22000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 23000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 24000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 25000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 26000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 27000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 28000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 29000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 30000000 Then
                desglose_palabras = Num2Text(txt_total.Text) & "DE PESOS"
            Else
                desglose_palabras = Num2Text(txt_total.Text) & peso
            End If
        End If
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar.KeyPress
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


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            Combo_vendedor.SelectedItem = "TODOS"
            txt_rut_cliente.Text = ""
            txt_nombre_cliente.Text = ""

            busqueda_por_descripcion()
            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If
    End Sub

    Private Sub txt_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar.TextChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged



        busqueda()





        Dim condicion As String
        If grilla_documento.Rows.Count <> 0 Then
            condicion = grilla_documento.CurrentRow.Cells(1).Value

       
            If condicion <> "LETRA" Then
                btn_imprimir.Enabled = False
            Else
                btn_imprimir.Enabled = True
            End If


            If combo_venta.Text <> "COTIZACION" Then
                btn_imprimir.Enabled = False
            Else
                btn_imprimir.Enabled = True
            End If

        End If



    End Sub




    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nro_doc", GetType(String)))
    '    dt.Columns.Add(New DataColumn("documento_referencia", GetType(String)))
    '    dt.Columns.Add(New DataColumn("monto_total", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("nro_letra", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("ciudad_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("monto_letra", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("desglose", GetType(String)))
    '    dt.Columns.Add(New DataColumn("girador", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

    '    dr = dt.NewRow()

    '    Try
    '        dr("Imagen") = ImageToByte(Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg"))
    '    Catch
    '    End Try

    '    dr("nro_doc") = grilla_letra.CurrentRow.Cells(0).Value
    '    dr("nro_letra") = cantidad_letras & " DE " & grilla_letra.CurrentRow.Cells(1).Value
    '    dr("documento_referencia") = grilla_letra.CurrentRow.Cells(2).Value & " NRO. " & grilla_letra.CurrentRow.Cells(3).Value
    '    dr("fecha") = dtp_letra.Text
    '    dr("rut_cliente") = grilla_letra.CurrentRow.Cells(5).Value
    '    dr("nombre_cliente") = grilla_letra.CurrentRow.Cells(6).Value
    '    dr("telefono_cliente") = grilla_letra.CurrentRow.Cells(7).Value
    '    dr("ciudad_cliente") = grilla_letra.CurrentRow.Cells(8).Value
    '    dr("direccion_cliente") = grilla_letra.CurrentRow.Cells(9).Value

    '    dr("monto_letra") = grilla_letra.CurrentRow.Cells(10).Value

    '    dr("monto_total") = grilla_letra.CurrentRow.Cells(11).Value
    '    dr("desglose") = desglose_palabras
    '    dr("girador") = minombreempresa
    '    dr("nombre_empresa") = minombreempresa
    '    dr("giro_empresa") = migiroempresa
    '    dr("direccion_empresa") = midireccionempresa
    '    dr("comuna_empresa") = micomunaempresa
    '    dr("telefono_empresa") = mitelefonoempresa
    '    dr("correo_empresa") = micorreoempresa
    '    dr("rut_empresa") = mirutempresa
    '    dt.Rows.Add(dr)

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "Letra"

    '    Dim iDS As New dsletra

    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function

    Public Function ImageToByte(ByVal pImagen As Image) As Byte()
        Dim mImage() As Byte
        Try
            If Not IsNothing(pImagen) Then
                Dim ms As New System.IO.MemoryStream
                pImagen.Save(ms, pImagen.RawFormat)
                mImage = ms.GetBuffer
                ms.Close()
                Return mImage
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

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

    Private Sub grilla_documento_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.DoubleClick

        Dim valormensaje As Integer
        If grilla_documento.Rows.Count = 0 Then
            Exit Sub
        End If

        valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "IMPRIMIR")

        If valormensaje = vbYes Then
            lbl_mensaje.Visible = True
            Me.Enabled = False


            If combo_venta.Text <> "COTIZACION" Then
                With PrintDocument_ticket_interno.PrinterSettings
                    .PrinterName = impresora_ticket_ventas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.PrintDocument_ticket_interno.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.PrintDocument_ticket_interno.DefaultPageSettings.PaperSize = pkCustomSize1
                        PrintDocument_ticket_interno.PrintController = New System.Drawing.Printing.StandardPrintController()
                        PrintDocument_ticket_interno.Print()
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            End If

            If combo_venta.Text = "COTIZACION" Then
                With PrintDocument_cotizacion.PrinterSettings
                    .PrinterName = impresora_ticket_cotizaciones
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.PrintDocument_cotizacion.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.PrintDocument_cotizacion.DefaultPageSettings.PaperSize = pkCustomSize1
                        PrintDocument_cotizacion.PrintController = New System.Drawing.Printing.StandardPrintController()
                        PrintDocument_cotizacion.Print()
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            End If

            'If mirutempresa = "87686300-6" Then
            '    If combo_venta.Text = "COTIZACION" Then
            '        With Pd.PrinterSettings
            '            ' Especifico el nombre de la impresora 
            '            ' por donde deseo imprimir. 
            '            .PrinterName = impresora_ticket
            '            ' Establezco el número de copias que se imprimirán 
            '            .Copies = 1
            '            ' Rango de páginas que se imprimirán 
            '            .PrintRange = PrintRange.AllPages
            '            If .IsValid Then
            '                Try
            '                    Dim iReporte As New Form_informe_cotizacion_ticket_personalizado
            '                    Dim rpt As New Crystal_cotizacion_ticket_personalizado
            '                    rpt.Load()
            '                    rpt.SetDataSource(ReturnDataSetTicketInterno)
            '                    rpt.Refresh()
            '                    iReporte.Reporte = rpt
            '                    '  iReporte.ShowDialog()
            '                    rpt.PrintOptions.PrinterName = impresora_ticket
            '                    'rpt.PrintOptions.PrinterName = "Microsoft Print to PDF"
            '                    rpt.PrintToPrinter(2, False, 0, 0)
            '                Catch ex As Exception
            '                    MsgBox(ex.Message)
            '                End Try
            '            Else
            '                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
            '                lbl_mensaje.Visible = False
            '                Me.Enabled = True
            '                Exit Sub
            '            End If
            '        End With
            '    Else
            '        With Pd.PrinterSettings
            '            ' Especifico el nombre de la impresora 
            '            ' por donde deseo imprimir. 
            '            .PrinterName = impresora_ticket
            '            ' Establezco el número de copias que se imprimirán 
            '            .Copies = 1
            '            ' Rango de páginas que se imprimirán 
            '            .PrintRange = PrintRange.AllPages
            '            If .IsValid Then
            '                Try
            '                    Dim iReporte As New Form_informe_cotizacion_ticket_personalizado
            '                    Dim rpt As New Crystal_copia_documento
            '                    rpt.Load()
            '                    rpt.SetDataSource(ReturnDataSetTicketInterno2)
            '                    rpt.Refresh()
            '                    iReporte.Reporte = rpt
            '                    '  iReporte.ShowDialog()
            '                    rpt.PrintOptions.PrinterName = impresora_ticket
            '                    'rpt.PrintOptions.PrinterName = "Microsoft Print to PDF"
            '                    rpt.PrintToPrinter(1, False, 0, 0)
            '                Catch ex As Exception
            '                    MsgBox(ex.Message)
            '                End Try
            '            Else
            '                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
            '                lbl_mensaje.Visible = False
            '                Me.Enabled = True
            '                Exit Sub
            '            End If
            '        End With
            '    End If

            'Else

            '    With Pd.PrinterSettings
            '        ' Especifico el nombre de la impresora 
            '        ' por donde deseo imprimir. 
            '        .PrinterName = impresora_ticket
            '        ' Establezco el número de copias que se imprimirán 
            '        .Copies = 1
            '        ' Rango de páginas que se imprimirán 
            '        .PrintRange = PrintRange.AllPages
            '        If .IsValid Then
            '            Try
            '                Dim iReporte As New Form_informe_cotizacion_ticket_personalizado
            '                Dim rpt As New Crystal_cotizacion_ticket_personalizado
            '                rpt.Load()
            '                rpt.SetDataSource(ReturnDataSetTicketInterno)
            '                rpt.Refresh()
            '                iReporte.Reporte = rpt
            '                '  iReporte.ShowDialog()
            '                rpt.PrintOptions.PrinterName = impresora_ticket
            '                'rpt.PrintOptions.PrinterName = "Microsoft Print to PDF"
            '                rpt.PrintToPrinter(1, False, 0, 0)
            '            Catch ex As Exception
            '                MsgBox(ex.Message)
            '            End Try
            '        Else
            '            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
            '            lbl_mensaje.Visible = False
            '            Me.Enabled = True
            '            Exit Sub
            '        End If
            '    End With
            'End If


















            MsgBox("SE HA IMPRESO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub

        End If

        Dim condicion As String
        condicion = grilla_documento.CurrentRow.Cells(1).Value

    End Sub

    Private Function ReturnDataSetTicketInterno() As DataSet
        'Dim dt As New DataTable
        'Dim dr As DataRow
        'Dim ds As New DataSet

        'dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        'dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("nro_cotizacion", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha_cotizacion", GetType(String)))
        'dt.Columns.Add(New DataColumn("nombre_vendedor", GetType(String)))
        'dt.Columns.Add(New DataColumn("telefono_vendedor", GetType(String)))
        'dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        'dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        'dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("total", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("numero_tecnico", GetType(String)))
        'dt.Columns.Add(New DataColumn("subtotal_final", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("descuento_final", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("total_final", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("forma_de_pago", GetType(String)))
        'dt.Columns.Add(New DataColumn("precio", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("tipo_doc", GetType(String)))
        'dt.Columns.Add(New DataColumn("valido", GetType(String)))

        'Dim tipo_doc As String
        'Dim valido As String

        'If combo_venta.Text = "COTIZACION" Then
        '    tipo_doc = "COTIZACION"
        '    valido = "COTIZACION VALIDA POR 2 DIAS"
        'Else
        '    tipo_doc = "DETALLE DE " & combo_venta.Text
        '    valido = " "
        'End If

        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As String
        'Dim VarDescuento As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        'Dim VarTotal As Integer
        'Dim condicion_cotizacion As String
        'Dim fecha_cotizacion As String
        'Dim desc_cotizacion As String
        'Dim nro_cotizacion As String
        'Dim subtotal_cotizacion As String
        'Dim total_cotizacion As String
        'Dim vendedor_cotizacion As String

        'condicion_cotizacion = grilla_documento.CurrentRow.Cells(1).Value
        'fecha_cotizacion = grilla_documento.CurrentRow.Cells(2).Value
        'desc_cotizacion = grilla_documento.CurrentRow.Cells(7).Value
        'nro_cotizacion = grilla_documento.CurrentRow.Cells(0).Value
        'total_cotizacion = grilla_documento.CurrentRow.Cells(10).Value
        'subtotal_cotizacion = grilla_documento.CurrentRow.Cells(5).Value
        'vendedor_cotizacion = grilla_documento.CurrentRow.Cells(11).Value
        'vendedor_cotizacion = grilla_documento.CurrentRow.Cells(11).Value

        'For i = 0 To grilla_detalle_documento.Rows.Count - 1
        '    VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
        '    varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
        '    VarValorUnitario = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
        '    VarCantidad = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '    VarSubtotal = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '    VarDescuento = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '    VarNeto = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
        '    VarIva = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
        '    VarTotal = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
        '    vartecnico = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
        '    dr = dt.NewRow()

        '    Try
        '        dr("Imagen") = Imagen_ticket
        '    Catch
        '    End Try
        '    dr("nombre_empresa") = minombreempresa
        '    dr("giro_empresa") = migiroempresa
        '    dr("direccion_empresa") = midireccionempresa
        '    dr("comuna_empresa") = micomunaempresa
        '    dr("telefono_empresa") = mitelefonoempresa
        '    dr("correo_empresa") = micorreoempresa
        '    dr("rut_empresa") = mirutempresa
        '    dr("nro_cotizacion") = nro_cotizacion
        '    dr("fecha_cotizacion") = fecha_cotizacion
        '    dr("nombre_vendedor") = vendedor_cotizacion
        '    dr("telefono_vendedor") = mitelefono
        '    dr("codigo") = VarCodProducto
        '    dr("descripcion") = varnombre
        '    dr("cantidad") = " X " & VarCantidad & " ="
        '    dr("total") = VarTotal
        '    dr("numero_tecnico") = vartecnico
        '    dr("subtotal_final") = subtotal_cotizacion
        '    dr("descuento_final") = desc_cotizacion
        '    dr("total_final") = total_cotizacion
        '    dr("forma_de_pago") = condicion_cotizacion
        '    dr("precio") = VarValorUnitario
        '    dr("tipo_doc") = tipo_doc
        '    dr("valido") = valido
        '    dt.Rows.Add(dr)
        'Next

        'ds.Tables.Add(dt)
        'ds.Tables(0).TableName = "CotizacionTicket"
        'Dim iDS As New dsCotizacionTicket
        'iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        'Return iDS
        Return Nothing
    End Function


    'Private Function ReturnDataSetTicketInterno2() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    dt.Columns.Add(New DataColumn("logo_empresa", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("titulo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn1", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn2", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn3", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn4", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn5", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn6", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn7", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn8", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn9", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn10", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn11", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn12", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn13", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn14", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn15", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn16", GetType(String)))

    '    Dim tipo_doc As String
    '    Dim valido As String

    '    If combo_venta.Text = "COTIZACION" Then
    '        tipo_doc = "COTIZACION"
    '        valido = "COTIZACION VALIDA POR 2 DIAS"
    '    Else
    '        tipo_doc = "DETALLE DE " & combo_venta.Text
    '        valido = " "
    '    End If

    '    Dim VarCodProducto As String
    '    Dim varnombre As String
    '    Dim vartecnico As String
    '    Dim VarValorUnitario As Integer
    '    Dim VarCantidad As String
    '    Dim VarDescuento As Integer
    '    Dim VarNeto As Integer
    '    Dim VarIva As Integer
    '    Dim VarSubtotal As Integer
    '    Dim VarTotal As Integer
    '    Dim condicion_documento As String
    '    Dim fecha_documento As String
    '    Dim desc_cotizacion As String
    '    Dim nro_documento As String
    '    Dim subtotal_cotizacion As String
    '    Dim total_cotizacion As String
    '    Dim vendedor_documento As String
    '    Dim rut_cliente As String
    '    Dim nombre_cliente As String

    '    condicion_documento = grilla_documento.CurrentRow.Cells(1).Value
    '    fecha_documento = grilla_documento.CurrentRow.Cells(2).Value
    '    rut_cliente = grilla_documento.CurrentRow.Cells(3).Value
    '    nombre_cliente = grilla_documento.CurrentRow.Cells(4).Value
    '    desc_cotizacion = grilla_documento.CurrentRow.Cells(7).Value
    '    nro_documento = grilla_documento.CurrentRow.Cells(0).Value
    '    total_cotizacion = grilla_documento.CurrentRow.Cells(10).Value
    '    subtotal_cotizacion = grilla_documento.CurrentRow.Cells(5).Value
    '    vendedor_documento = grilla_documento.CurrentRow.Cells(11).Value
    '    vendedor_documento = grilla_documento.CurrentRow.Cells(11).Value

    '    For i = 0 To grilla_detalle_documento.Rows.Count - 1
    '        VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
    '        varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
    '        VarValorUnitario = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
    '        VarCantidad = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
    '        VarSubtotal = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
    '        VarDescuento = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
    '        VarNeto = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
    '        VarIva = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
    '        VarTotal = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
    '        vartecnico = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
    '        dr = dt.NewRow()

    '        Try
    '            dr("logo_empresa") = Imagen_ticket
    '        Catch
    '        End Try
    '        dr("nombre_empresa") = minombreempresa
    '        dr("giro_empresa") = migiroempresa
    '        dr("direccion_empresa") = midireccionempresa
    '        dr("comuna_empresa") = micomunaempresa
    '        dr("telefono_empresa") = mitelefonoempresa
    '        dr("correo_empresa") = micorreoempresa
    '        dr("rut_empresa") = mirutempresa

    '        dr("titulo") = tipo_doc

    '        dr("DataColumn1") = nro_documento
    '        dr("DataColumn2") = fecha_documento
    '        dr("DataColumn3") = rut_cliente
    '        dr("DataColumn4") = nombre_cliente
    '        dr("DataColumn5") = vendedor_documento
    '        dr("DataColumn7") = condicion_documento

    '        'dr("telefono_vendedor") = mitelefono
    '        dr("DataColumn8") = VarCodProducto
    '        dr("DataColumn9") = varnombre
    '        dr("DataColumn10") = vartecnico
    '        dr("DataColumn11") = VarValorUnitario
    '        dr("DataColumn12") = " X " & VarCantidad & " ="
    '        dr("DataColumn13") = VarTotal

    '        dr("DataColumn14") = subtotal_cotizacion
    '        dr("DataColumn15") = desc_cotizacion
    '        dr("DataColumn16") = total_cotizacion




    '        dt.Rows.Add(dr)
    '    Next

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "DS_reporte"
    '    Dim iDS As New DS_reporte
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.Click
        Form_buscador_clientes_documentos_emitidos.Show()
        Me.Enabled = False
    End Sub

    Private Sub PrintDocument_cotizacion_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument_cotizacion.PrintPage
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

        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        Dim condicion_documento As String
        Dim fecha_documento As String
        Dim desc_cotizacion As String
        Dim nro_documento As String
        Dim subtotal_cotizacion As String
        Dim total_cotizacion As String
        Dim vendedor_documento As String
        Dim rut_cliente As String
        Dim nombre_cliente As String
        Dim multiplicador_lineas As Integer = 45
        Dim numero_lineas As Integer = 0

        condicion_documento = grilla_documento.CurrentRow.Cells(1).Value
        fecha_documento = grilla_documento.CurrentRow.Cells(2).Value
        rut_cliente = grilla_documento.CurrentRow.Cells(3).Value
        nombre_cliente = grilla_documento.CurrentRow.Cells(4).Value
        desc_cotizacion = grilla_documento.CurrentRow.Cells(7).Value
        nro_documento = grilla_documento.CurrentRow.Cells(0).Value
        total_cotizacion = grilla_documento.CurrentRow.Cells(10).Value
        subtotal_cotizacion = grilla_documento.CurrentRow.Cells(5).Value
        vendedor_documento = grilla_documento.CurrentRow.Cells(11).Value

        e.Graphics.DrawString("COTIZACION", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NUMERO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 245)
        e.Graphics.DrawString(nro_documento, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 260)
        e.Graphics.DrawString(fecha_documento, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 260)

        e.Graphics.DrawString("VENDEDOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 275)
        e.Graphics.DrawString(vendedor_documento, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 275)

        e.Graphics.DrawString("TELEFONO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 290)
        e.Graphics.DrawString(mitelefono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 290)

        e.Graphics.DrawString("CONDICION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 305)
        e.Graphics.DrawString(condicion_documento, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 305)

        e.Graphics.DrawString("CODIGO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString("DESCRIPCION", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 335)
        e.Graphics.DrawString("CANT.", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 335)
        e.Graphics.DrawString("TOTAL", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 335, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 350, margen_izquierdo + 270, margen_superior + 350)

        For i = 0 To grilla_detalle_documento.Rows.Count - 1
            VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
            VarValorUnitario = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
            VarCantidad = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
            VarSubtotal = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
            VarDescuento = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
            VarNeto = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
            VarIva = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
            VarTotal = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
            vartecnico = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString

            Dim precio_detalle As String
            Dim descuento_detalle As String
            Dim precio_total As String

            'precio_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            'descuento_detalle = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            'descuento_detalle = Val(descuento_detalle) / VarCantidad

            'precio_detalle = VarValorUnitario
            'descuento_detalle = VarDescuento
            'descuento_detalle = Val(descuento_detalle) / VarCantidad

            'precio_detalle = Val(precio_detalle - descuento_detalle)
            'precio_total = VarTotal

            precio_total = VarTotal
            precio_detalle = Val(VarTotal) / Val(VarCantidad)
            descuento_detalle = VarDescuento



            If descuento_detalle = "" Or descuento_detalle = "0" Then
                descuento_detalle = "0"
            Else
                descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
            End If

            If precio_detalle = "" Or precio_detalle = "0" Then
                precio_detalle = "0"
            Else
                precio_detalle = Format(Int(precio_detalle), "###,###,###")
            End If

            If precio_total = "" Or precio_total = "0" Then
                precio_total = "0"
            Else
                precio_total = Format(Int(precio_total), "###,###,###")
            End If
            'If detalle_referencia.Length > 23 Then
            '    detalle_referencia = detalle_referencia.Substring(0, 23)
            'End If

            e.Graphics.DrawString(VarCodProducto, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(varnombre, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(vartecnico, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 370 + (i * multiplicador_lineas))
            'e.Graphics.DrawString(precio_detalle, Font_texto_detalle, Brushes.Black, margen_izquierdo + 285, margen_superior + 405 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_detalle & " X " & VarCantidad, Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 385 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_total, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 385 + (i * multiplicador_lineas), format1)
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + (i * multiplicador_lineas) + 398, margen_izquierdo + 270, margen_superior + (i * multiplicador_lineas) + 398)
        Next

        numero_lineas = ((grilla_detalle_documento.Rows.Count - 1) * multiplicador_lineas)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + numero_lineas + 398, margen_izquierdo + 270, margen_superior + numero_lineas + 398)

        Dim descuento_cotizacion As String

        total_cotizacion = grilla_documento.CurrentRow.Cells(10).Value
        subtotal_cotizacion = grilla_documento.CurrentRow.Cells(5).Value
        descuento_cotizacion = Val(subtotal_cotizacion) - Val(total_cotizacion)

        If total_cotizacion = "" Or total_cotizacion = "0" Then
            total_cotizacion = "0"
        Else
            total_cotizacion = Format(Int(total_cotizacion), "###,###,###")
        End If

        If subtotal_cotizacion = "" Or subtotal_cotizacion = "0" Then
            subtotal_cotizacion = "0"
        Else
            subtotal_cotizacion = Format(Int(subtotal_cotizacion), "###,###,###")
        End If

        If descuento_cotizacion = "" Or descuento_cotizacion = "0" Then
            descuento_cotizacion = "0"
        Else
            descuento_cotizacion = Format(Int(descuento_cotizacion), "###,###,###")
        End If

        e.Graphics.DrawString("SUBTOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 115, margen_superior + numero_lineas + 420)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 200, margen_superior + numero_lineas + 420)
        e.Graphics.DrawString(subtotal_cotizacion, Font_texto_totales, Brushes.Black, margen_izquierdo + 270, margen_superior + numero_lineas + 420, format1)

        e.Graphics.DrawString("DESCUENTO", Font_texto_totales, Brushes.Black, margen_izquierdo + 115, margen_superior + numero_lineas + 435)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 200, margen_superior + numero_lineas + 435)
        e.Graphics.DrawString(descuento_cotizacion, Font_texto_totales, Brushes.Black, margen_izquierdo + 270, margen_superior + numero_lineas + 435, format1)

        e.Graphics.DrawString("TOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 115, margen_superior + numero_lineas + 450)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 200, margen_superior + numero_lineas + 450)
        e.Graphics.DrawString(total_cotizacion, Font_texto_totales, Brushes.Black, margen_izquierdo + 270, margen_superior + numero_lineas + 450, format1)

        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 490, margen_izquierdo + 270, margen_superior + numero_lineas + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub

    Private Sub PrintDocument_ticket_interno_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument_ticket_interno.PrintPage
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

        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        Dim condicion_documento As String
        Dim fecha_documento As String
        Dim desc_cotizacion As String
        Dim nro_documento As String
        Dim subtotal_cotizacion As String
        Dim total_cotizacion As String
        Dim vendedor_documento As String
        Dim rut_cliente As String
        Dim nombre_cliente As String
        Dim multiplicador_lineas As Integer = 45
        Dim numero_lineas As Integer = 0

        condicion_documento = grilla_documento.CurrentRow.Cells(1).Value
        fecha_documento = grilla_documento.CurrentRow.Cells(2).Value
        rut_cliente = grilla_documento.CurrentRow.Cells(3).Value
        nombre_cliente = grilla_documento.CurrentRow.Cells(4).Value
        desc_cotizacion = grilla_documento.CurrentRow.Cells(7).Value
        nro_documento = grilla_documento.CurrentRow.Cells(0).Value
        total_cotizacion = grilla_documento.CurrentRow.Cells(10).Value
        subtotal_cotizacion = grilla_documento.CurrentRow.Cells(5).Value
        vendedor_documento = grilla_documento.CurrentRow.Cells(11).Value

        e.Graphics.DrawString("DETALLE DE " & Combo_venta.Text, Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NUMERO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 245)
        e.Graphics.DrawString(nro_documento, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 260)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 260)

        e.Graphics.DrawString("VENDEDOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 275)
        e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 275)

        e.Graphics.DrawString("TELEFONO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 290)
        e.Graphics.DrawString(mitelefono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 290)

        e.Graphics.DrawString("CONDICION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 305)
        e.Graphics.DrawString(condicion_documento, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 305)

        e.Graphics.DrawString("CODIGO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString("DESCRIPCION", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 335)
        e.Graphics.DrawString("CANT.", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 335)
        e.Graphics.DrawString("TOTAL", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 335, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 350, margen_izquierdo + 270, margen_superior + 350)

        Dim descuento_detalle As String
        Dim precio_detalle As String
        Dim precio_total As String

        For i = 0 To grilla_detalle_documento.Rows.Count - 1
            VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
            VarValorUnitario = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
            VarCantidad = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
            VarSubtotal = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
            VarDescuento = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
            VarNeto = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
            VarIva = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
            VarTotal = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
            vartecnico = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString

            'precio_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            'descuento_detalle = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            'descuento_detalle = Val(descuento_detalle) / VarCantidad

            'precio_detalle = Val(precio_detalle - descuento_detalle)

            precio_total = VarTotal
            precio_detalle = Val(VarTotal) / Val(VarCantidad)
            descuento_detalle = VarDescuento

            If descuento_detalle = "" Or descuento_detalle = "0" Then
                descuento_detalle = "0"
            Else
                descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
            End If

            If precio_detalle = "" Or precio_detalle = "0" Then
                precio_detalle = "0"
            Else
                precio_detalle = Format(Int(precio_detalle), "###,###,###")
            End If

            If precio_total = "" Or precio_total = "0" Then
                precio_total = "0"
            Else
                precio_total = Format(Int(precio_total), "###,###,###")
            End If
            'If detalle_referencia.Length > 23 Then
            '    detalle_referencia = detalle_referencia.Substring(0, 23)
            'End If

            e.Graphics.DrawString(VarCodProducto, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(varnombre, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(vartecnico, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 370 + (i * multiplicador_lineas))
            'e.Graphics.DrawString(precio_detalle, Font_texto_detalle, Brushes.Black, margen_izquierdo + 285, margen_superior + 405 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_detalle & " X " & VarCantidad, Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 385 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_total, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 385 + (i * multiplicador_lineas), format1)
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + (i * multiplicador_lineas) + 398, margen_izquierdo + 270, margen_superior + (i * multiplicador_lineas) + 398)
        Next

        numero_lineas = ((grilla_detalle_documento.Rows.Count - 1) * multiplicador_lineas)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + numero_lineas + 398, margen_izquierdo + 270, margen_superior + numero_lineas + 398)

        Dim descuento_cotizacion As String

        total_cotizacion = grilla_documento.CurrentRow.Cells(10).Value
        subtotal_cotizacion = grilla_documento.CurrentRow.Cells(5).Value
        descuento_cotizacion = Val(subtotal_cotizacion) - Val(total_cotizacion)

        If total_cotizacion = "" Or total_cotizacion = "0" Then
            total_cotizacion = "0"
        Else
            total_cotizacion = Format(Int(total_cotizacion), "###,###,###")
        End If

        If subtotal_cotizacion = "" Or subtotal_cotizacion = "0" Then
            subtotal_cotizacion = "0"
        Else
            subtotal_cotizacion = Format(Int(subtotal_cotizacion), "###,###,###")
        End If

        If descuento_cotizacion = "" Or descuento_cotizacion = "0" Then
            descuento_cotizacion = "0"
        Else
            descuento_cotizacion = Format(Int(descuento_cotizacion), "###,###,###")
        End If

        e.Graphics.DrawString("SUBTOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 420)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 420)
        e.Graphics.DrawString(subtotal_cotizacion, Font_texto_totales, Brushes.Black, margen_izquierdo + 270, margen_superior + numero_lineas + 420, format1)

        e.Graphics.DrawString("DESCUENTO", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 435)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 435)
        e.Graphics.DrawString(descuento_cotizacion, Font_texto_totales, Brushes.Black, margen_izquierdo + 270, margen_superior + numero_lineas + 435, format1)

        e.Graphics.DrawString("TOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 450)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 450)
        e.Graphics.DrawString(total_cotizacion, Font_texto_totales, Brushes.Black, margen_izquierdo + 270, margen_superior + numero_lineas + 450, format1)

        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 490, margen_izquierdo + 270, margen_superior + numero_lineas + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub

    Private Sub grilla_documento_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub
End Class