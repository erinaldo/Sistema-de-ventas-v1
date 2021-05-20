Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Form_detalle_ventas
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim numero_lineas_total As Integer = 0
    'Dim impreso As Integer = 0

    Private Sub Form_detalle_ventas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_detalle_ventas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dtp_desde.CustomFormat = "yyy-MM-dd"
        ' dtp_hasta.CustomFormat = "yyy-MM-dd"
        fecha()
        llenar_combo_cajas()
        combo_venta.SelectedItem = "-"
        Combo_condicion.SelectedItem = "-"
        mostrar_malla()
        grilla_documento.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()

        ' fecha()
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

    Sub llenar_combo_cajas()
        Combo_caja.Items.Clear()
        Combo_caja.Items.Add("TODAS")
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from equipos_de_cajas order by nombre_caja"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_caja.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_caja"))
            Next
        End If
        Combo_caja.SelectedItem = "TODAS"
        conexion.Close()
    End Sub

    Sub mostrar_malla()
        Dim consulta As String

        If combo_venta.Text = "BOLETA" Then

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            consulta = "select boleta.tipo as tipo, boleta.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, boleta.sUBtotal AS SUBTOTAL , boleta.DESCUENTO AS 'DESC.' , boleta.total AS TOTAL, boleta.FECHA_VENTA AS 'FECHA', HORA AS HORA, boleta.CONDICIONES AS 'CONDICION', boleta.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', CAJA from boleta , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo LIKE 'boleta%' and usuarios.rut_usuario =boleta.usuario_responsable and boleta.rut_cliente=clientes.rut_cliente "

            If Combo_condicion.Text = "-" Then
                consulta = consulta
            End If

            If Combo_condicion.Text = "CREDITO" Then
                consulta = consulta & " and boleta.condiciones = 'CREDITO' "
            End If


            If Combo_condicion.Text = "TRASLADO" Then
                consulta = consulta & " and boleta.condiciones = 'TRASLADO' "
            End If

            If Combo_condicion.Text = "CONTADO" Then
                consulta = consulta & " and boleta.condiciones <> 'CREDITO' "
            End If

            If Combo_caja.Text <> "TODAS" Then
                consulta = consulta & " and boleta.caja ='" & (Combo_caja.Text) & "' "
            End If

            consulta = consulta & " GROUP BY n_boleta ORDER BY n_boleta"

            SC3.CommandText = consulta
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_documento.Columns(9).Visible = False
        End If


        If combo_venta.Text = "FACTURA" Then

            'consulta = "select boleta.tipo as tipo, boleta.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, boleta.sUBtotal AS SUBTOTAL , boleta.DESCUENTO AS 'DESC.' , boleta.total AS TOTAL, boleta.FECHA_VENTA AS 'FECHA', HORA AS HORA, boleta.CONDICIONES AS 'CONDICION', boleta.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from boleta , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo LIKE 'boleta%' and usuarios.rut_usuario =boleta.usuario_responsable and boleta.rut_cliente=clientes.rut_cliente "
            consulta = "select factura.tipo as tipo, factura.n_factura as 'NRO.', usuarios.nombre_usuario NOMBRE, factura.sUBtotal AS SUBTOTAL , factura.DESCUENTO AS 'DESC.' , factura.total AS TOTAL, factura.FECHA_VENTA AS 'FECHA', HORA AS HORA, factura.CONDICIONES AS 'CONDICION', factura.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', CAJA from factura , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo LIKE 'factura%' and usuarios.rut_usuario =factura.usuario_responsable and factura.rut_cliente=clientes.rut_cliente "


            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            If Combo_condicion.Text = "-" Then
                SC3.CommandText = "select factura.tipo as tipo, factura.n_factura as 'NRO.', usuarios.nombre_usuario NOMBRE, factura.sUBtotal AS SUBTOTAL , factura.DESCUENTO AS 'DESC.' , factura.total AS TOTAL, factura.FECHA_VENTA AS 'FECHA', HORA AS HORA, factura.CONDICIONES AS 'CONDICION', factura.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from factura , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'factura%' AND usuarios.rut_usuario =factura.usuario_responsable AND factura.rut_cliente=clientes.rut_cliente GROUP BY N_factura ORDER BY N_factura"
                consulta = consulta
            End If

            If Combo_condicion.Text = "CREDITO" Then
                consulta = consulta & " and factura.condiciones = 'CREDITO' "
            End If

            If Combo_condicion.Text = "TRASLADO" Then
                consulta = consulta & " and factura.condiciones = 'TRASLADO' "
            End If

            If Combo_condicion.Text = "CONTADO" Then
                consulta = consulta & " and factura.condiciones <> 'CREDITO' "
            End If

            If Combo_caja.Text <> "TODAS" Then
                consulta = consulta & " and factura.caja ='" & (Combo_caja.Text) & "' "
            End If

            consulta = consulta & " GROUP BY n_factura ORDER BY n_factura"

            SC3.CommandText = consulta
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If




        If combo_venta.Text = "GUIA" Then

            'consulta = "select boleta.tipo as tipo, boleta.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, boleta.sUBtotal AS SUBTOTAL , boleta.DESCUENTO AS 'DESC.' , boleta.total AS TOTAL, boleta.FECHA_VENTA AS 'FECHA', HORA AS HORA, boleta.CONDICIONES AS 'CONDICION', boleta.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from boleta , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo LIKE 'boleta%' and usuarios.rut_usuario =boleta.usuario_responsable and boleta.rut_cliente=clientes.rut_cliente "
            consulta = "select guia.tipo as tipo, guia.N_guia as 'NRO.', usuarios.nombre_usuario NOMBRE, guia.sUBtotal AS SUBTOTAL , guia.DESCUENTO AS 'DESC.' , guia.total AS TOTAL, guia.FECHA_VENTA AS 'FECHA', HORA AS HORA, guia.CONDICIONES AS 'CONDICION', guia.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', CAJA from guia , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'guia%' AND usuarios.rut_usuario =guia.usuario_responsable AND guia.rut_cliente=clientes.rut_cliente "

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            If Combo_condicion.Text = "-" Then
                consulta = consulta
            End If

            If Combo_condicion.Text = "CREDITO" Then
                consulta = consulta & " and guia.condiciones = 'CREDITO' "
            End If

            If Combo_condicion.Text = "TRASLADO" Then
                consulta = consulta & " and guia.condiciones = 'TRASLADO' "
            End If

            If Combo_condicion.Text = "CONTADO" Then
                consulta = consulta & " and guia.condiciones <> 'CREDITO'  and guia.condiciones <> 'TRASLADO' "
            End If

            If Combo_caja.Text <> "TODAS" Then
                consulta = consulta & " and guia.caja ='" & (Combo_caja.Text) & "' "
            End If

            consulta = consulta & " GROUP BY n_guia ORDER BY n_guia"

            SC3.CommandText = consulta
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If combo_venta.Text = "COTIZACION" Then

            'consulta = "select nota_debito.tipo as tipo, nota_debito.N_nota_debito as 'NRO.', usuarios.nombre_usuario NOMBRE, nota_debito.sUBtotal AS SUBTOTAL , nota_debito.DESCUENTO AS 'DESC.' , nota_debito.total AS TOTAL, nota_debito.FECHA_VENTA AS 'FECHA', HORA AS HORA, nota_debito.CONDICIONES AS 'CONDICION', nota_debito.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from nota_debito , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'NOTA DE DEBITO%' AND usuarios.rut_usuario =nota_debito.usuario_responsable AND nota_debito.rut_cliente=clientes.rut_cliente "
            consulta = "select COTIZACION.tipo as tipo, COTIZACION.N_COTIZACION as 'NRO.', usuarios.nombre_usuario NOMBRE, COTIZACION.sUBtotal AS SUBTOTAL , COTIZACION.DESCUENTO AS 'DESC.' , COTIZACION.total AS TOTAL, COTIZACION.FECHA_VENTA AS 'FECHA', HORA AS HORA, COTIZACION.CONDICIONES AS 'CONDICION', COTIZACION.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', CAJA from COTIZACION , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'COTIZACION%' AND usuarios.rut_usuario =COTIZACION.usuario_responsable AND COTIZACION.rut_cliente=clientes.rut_cliente "

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            If Combo_condicion.Text = "-" Then
                SC3.CommandText = "select cotizacion.tipo as tipo, cotizacion.n_cotizacion as 'NRO.', usuarios.nombre_usuario NOMBRE, cotizacion.subtotal AS SUBTOTAL , cotizacion.DESCUENTO AS 'DESC.' , cotizacion.total AS TOTAL, cotizacion.FECHA_VENTA AS 'FECHA', HORA AS HORA, COTIZACION.CONDICIONES AS 'CONDICION', COTIZACION.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from COTIZACION , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'COTIZACION%' AND usuarios.rut_usuario =COTIZACION.usuario_responsable AND COTIZACION.rut_cliente=clientes.rut_cliente GROUP BY N_COTIZACION ORDER BY N_COTIZACION"
                consulta = consulta
            End If

            If Combo_condicion.Text = "CREDITO" Then
                consulta = consulta & " and cotizacion.condiciones = 'CREDITO' "
            End If

            If Combo_condicion.Text = "TRASLADO" Then
                consulta = consulta & " and cotizacion.condiciones = 'TRASLADO' "
            End If

            If Combo_condicion.Text = "CONTADO" Then
                consulta = consulta & " and cotizacion.condiciones <> 'CREDITO' "
            End If

            If Combo_caja.Text <> "TODAS" Then
                consulta = consulta & " and cotizacion.caja ='" & (Combo_caja.Text) & "' "
            End If

            consulta = consulta & " GROUP BY n_cotizacion ORDER BY n_cotizacion"

            SC3.CommandText = consulta
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If


        If combo_venta.Text = "NOTA DE CREDITO" Then

            'consulta = "select guia.tipo as tipo, guia.N_guia as 'NRO.', usuarios.nombre_usuario NOMBRE, guia.sUBtotal AS SUBTOTAL , guia.DESCUENTO AS 'DESC.' , guia.total AS TOTAL, guia.FECHA_VENTA AS 'FECHA', HORA AS HORA, guia.CONDICIONES AS 'CONDICION', guia.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from guia , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'guia%' AND usuarios.rut_usuario =guia.usuario_responsable AND guia.rut_cliente=clientes.rut_cliente "
            consulta = "select nota_credito.tipo as tipo, nota_credito.N_nota_credito as 'NRO.', usuarios.nombre_usuario NOMBRE, nota_credito.sUBtotal AS SUBTOTAL , nota_credito.DESCUENTO AS 'DESC.' , nota_credito.total AS TOTAL, nota_credito.FECHA_VENTA AS 'FECHA', HORA AS HORA, nota_credito.CONDICIONES AS 'CONDICION', nota_credito.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', MOTIVO AS 'MOTIVO', CAJA from nota_credito , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'NOTA DE CREDITO%' AND usuarios.rut_usuario =nota_credito.usuario_responsable AND nota_credito.rut_cliente=clientes.rut_cliente "

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            If Combo_condicion.Text = "-" Then
                consulta = consulta
            End If

            If Combo_condicion.Text = "CREDITO" Then
                consulta = consulta & " and nota_credito.condiciones = 'CREDITO' "
            End If

            If Combo_condicion.Text = "TRASLADO" Then
                consulta = consulta & " and nota_credito.condiciones = 'TRASLADO' "
            End If

            If Combo_condicion.Text = "CONTADO" Then
                consulta = consulta & " and nota_credito.condiciones <> 'CREDITO' "
            End If

            If Combo_caja.Text <> "TODAS" Then
                consulta = consulta & " and nota_credito.caja ='" & (Combo_caja.Text) & "' "
            End If

            consulta = consulta & " GROUP BY N_nota_credito ORDER BY N_nota_credito"

            SC3.CommandText = consulta
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If combo_venta.Text = "NOTA DE DEBITO" Then

            'consulta = "select nota_credito.tipo as tipo, nota_credito.N_nota_credito as 'NRO.', usuarios.nombre_usuario NOMBRE, nota_credito.sUBtotal AS SUBTOTAL , nota_credito.DESCUENTO AS 'DESC.' , nota_credito.total AS TOTAL, nota_credito.FECHA_VENTA AS 'FECHA', HORA AS HORA, nota_credito.CONDICIONES AS 'CONDICION', nota_credito.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', MOTIVO AS 'MOTIVO' from nota_credito , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'NOTA DE CREDITO%' AND usuarios.rut_usuario =nota_credito.usuario_responsable AND nota_credito.rut_cliente=clientes.rut_cliente "
            consulta = "select nota_debito.tipo as tipo, nota_debito.N_nota_debito as 'NRO.', usuarios.nombre_usuario NOMBRE, nota_debito.sUBtotal AS SUBTOTAL , nota_debito.DESCUENTO AS 'DESC.' , nota_debito.total AS TOTAL, nota_debito.FECHA_VENTA AS 'FECHA', HORA AS HORA, nota_debito.CONDICIONES AS 'CONDICION', nota_debito.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', CAJA from nota_debito , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'NOTA DE DEBITO%' AND usuarios.rut_usuario =nota_debito.usuario_responsable AND nota_debito.rut_cliente=clientes.rut_cliente "

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            If Combo_condicion.Text = "-" Then
                consulta = consulta
            End If

            If Combo_condicion.Text = "CREDITO" Then
                consulta = consulta & " and nota_debito.condiciones = 'CREDITO' "
            End If

            If Combo_condicion.Text = "TRASLADO" Then
                consulta = consulta & " and nota_debito.condiciones = 'TRASLADO' "
            End If

            If Combo_condicion.Text = "CONTADO" Then
                consulta = consulta & " and nota_debito.condiciones <> 'CREDITO' "
            End If

            If Combo_caja.Text <> "TODAS" Then
                consulta = consulta & " and nota_debito.caja ='" & (Combo_caja.Text) & "' "
            End If

            consulta = consulta & " GROUP BY N_nota_debito ORDER BY N_nota_debito"

            SC3.CommandText = consulta
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        grilla_documento.DataSource = Nothing
        '    combo_venta.SelectedItem = "-"
        Combo_condicion.SelectedItem = "-"
        calcular_totales()
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_documento.DataSource = Nothing

        fecha()
        mostrar_malla()
        calcular_totales()

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

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        combo_venta.SelectedItem = "-"
        Combo_condicion.SelectedItem = "-"
        grilla_documento.DataSource = Nothing
        calcular_totales()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        combo_venta.SelectedItem = "-"
        Combo_condicion.SelectedItem = "-"
        grilla_documento.DataSource = Nothing
        calcular_totales()
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

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
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

    Private Sub GroupBox_tipo_venta_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox_tipo_venta.Enter

    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_documento.DataSource = Nothing
            Combo_condicion.SelectedItem = "-"
            combo_venta.SelectedItem = "-"
        End If
    End Sub



    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click

        If grilla_documento.Rows.Count = 0 Then
            MsgBox("NO SE HAN ENCONTRADO DOCUMENTOS, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            btn_imprimir.Focus()
            Exit Sub
        End If



        lbl_mensaje.Visible = True
        Me.Enabled = False





        'With PrintDocument1.PrinterSettings
        '    .PrinterName = "Microsoft Print to PDF"
        '    .Copies = 1
        '    .PrintRange = PrintRange.AllPages
        '    If .IsValid Then
        '        Me.PrintDocument1.PrintController = New StandardPrintController

        '        Try
        '            PrintDocument1.DefaultPageSettings.Landscape = False
        '            PrintDocument1.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
        '            PrintDocument1.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
        '        Catch
        '        End Try

        '        PrintDocument1.PrintController = New System.Drawing.Printing.StandardPrintController()
        '        PrintDocument1.Print()

        '        Dim FileName As String = "ResultsSheet" & "dfgdgfd" & ".pdf"

        '        'Wait until the file shows up before closing PDF Creator
        '        Do
        '            My.Application.DoEvents()
        '        Loop Until Dir("C:\Users\claud\Desktop\" & FileName) = FileName

        '    Else
        '        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
        '        lbl_mensaje.Visible = False
        '        Me.Enabled = True
        '        Exit Sub
        '    End If
        'End With

        'lbl_mensaje.Visible = False
        'Me.Enabled = True











        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = True
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = True
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet




    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("tipo_doc", GetType(String)))
    '    dt.Columns.Add(New DataColumn("numero_doc", GetType(String)))
    '    dt.Columns.Add(New DataColumn("usuario", GetType(String)))
    '    dt.Columns.Add(New DataColumn("subtotal", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("descuento", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("total", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("hora", GetType(String)))
    '    dt.Columns.Add(New DataColumn("condicion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

    '    dt.Columns.Add(New DataColumn("titulo", GetType(String)))


    '    dt.Columns.Add(New DataColumn("recinto_empresa", GetType(String)))

    '    dt.Columns.Add(New DataColumn("subtotal_final", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("descuento_final", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("total_final", GetType(Integer)))

    '    Dim Vartipo As String
    '    Dim VarNro As String
    '    Dim VarUsuario As String
    '    Dim VarSubtotal As String
    '    Dim VarDescuento As String
    '    Dim VarTotal As String
    '    Dim VarFecha As String
    '    Dim VarHora As String
    '    Dim VarCondicion As String
    '    Dim VarRut As String
    '    Dim VarNombre As String


    '    For i = 0 To grilla_documento.Rows.Count - 1


    '        Vartipo = grilla_documento.Rows(i).Cells(0).Value.ToString
    '        VarNro = grilla_documento.Rows(i).Cells(1).Value.ToString
    '        VarUsuario = grilla_documento.Rows(i).Cells(2).Value.ToString
    '        VarSubtotal = grilla_documento.Rows(i).Cells(3).Value.ToString
    '        VarDescuento = grilla_documento.Rows(i).Cells(4).Value.ToString
    '        VarTotal = grilla_documento.Rows(i).Cells(5).Value.ToString
    '        VarFecha = grilla_documento.Rows(i).Cells(6).Value.ToString
    '        VarHora = grilla_documento.Rows(i).Cells(7).Value.ToString
    '        VarCondicion = grilla_documento.Rows(i).Cells(8).Value.ToString
    '        VarRut = grilla_documento.Rows(i).Cells(9).Value.ToString
    '        VarNombre = grilla_documento.Rows(i).Cells(10).Value.ToString


    '        dr = dt.NewRow()

    '        'Try
    '        '    dr("Imagen") = Imagen_reporte
    '        'Catch
    '        'End Try



    '        'dr("titulo") = "<font color='#08088A'><P ALIGN=center>DETALLE DE VENTAS (" & mirecintoempresa & ") </P></font>"
    '        If combo_venta.Text = "" Then
    '            dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & ""
    '        End If

    '        If combo_venta.Text = "-" Then
    '            dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & ""
    '        End If

    '        If combo_venta.Text = "boleta" Then
    '            dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & " (boletaS)"

    '            If Combo_condicion.Text <> "" And Combo_condicion.Text <> "-" Then
    '                dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & " (boletaS " & Combo_condicion.Text & ")"
    '            End If

    '        End If

    '        If combo_venta.Text = "factura" Then
    '            dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & " (facturaS)"

    '            If Combo_condicion.Text <> "" And Combo_condicion.Text <> "-" Then
    '                dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & " (facturaS " & Combo_condicion.Text & ")"
    '            End If
    '        End If

    '        If combo_venta.Text = "NOTA DE CREDITO" Then
    '            dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & " (NOTAS DE CREDITO)"

    '            If Combo_condicion.Text <> "" And Combo_condicion.Text <> "-" Then
    '                dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & " (NOTAS DE CREDITO " & Combo_condicion.Text & ")"
    '            End If
    '        End If

    '        If combo_venta.Text = "NOTA DE DEBITO" Then
    '            dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & " (NOTAS DE CREDITO)"

    '            If Combo_condicion.Text <> "" And Combo_condicion.Text <> "-" Then
    '                dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & " (NOTAS DE CREDITO " & Combo_condicion.Text & ")"
    '            End If
    '        End If


    '        If combo_venta.Text = "guia" Then
    '            dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & " (guiaS)"

    '            If Combo_condicion.Text <> "" And Combo_condicion.Text <> "-" Then
    '                dr("titulo") = "DETALLE DE VENTAS " & mirecintoempresa & " (guiaS " & Combo_condicion.Text & ")"
    '            End If
    '        End If
    '        'dr("recinto") = "<B>DESDE <B>" & dtp_fecha_caja_desde.Text & "</B> HASTA <B>" & dtp_fecha_caja_hasta.Text
    '        dr("recinto_empresa") = "DESDE " & dtp_desde.Text & " HASTA " & dtp_hasta.Text
















    '        dr("tipo_doc") = Vartipo
    '        dr("numero_doc") = VarNro
    '        dr("usuario") = VarUsuario
    '        dr("subtotal") = VarSubtotal
    '        dr("descuento") = VarDescuento
    '        dr("total") = VarTotal
    '        dr("fecha") = VarFecha
    '        dr("hora") = VarHora
    '        dr("condicion") = VarCondicion
    '        dr("rut_cliente") = VarRut
    '        dr("nombre_cliente") = VarNombre
    '        dr("nombre_empresa") = minombreempresa
    '        dr("giro_empresa") = migiroempresa
    '        dr("direccion_empresa") = midireccionempresa
    '        dr("comuna_empresa") = micomunaempresa
    '        dr("telefono_empresa") = mitelefonoempresa
    '        dr("correo_empresa") = micorreoempresa
    '        dr("rut_empresa") = mirutempresa

    '        dr("subtotal_final") = txt_subtotal.Text
    '        dr("descuento_final") = txt_descuento.Text
    '        dr("total_final") = txt_total.Text
    '        ' dr("recinto_empresa") = mirecintoempresa

    '        dt.Rows.Add(dr)

    '    Next












    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "DetalleVentas"

    '    Dim iDS As New DsDetalleVentas
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


    Sub calcular_totales()
        'Dim descgrilla As Integer
        'Dim netogrilla As Integer
        'Dim ivagrilla As Integer
        'Dim totalgrilla As Integer
        'Dim subtotalgrilla As Integer
        'Dim VarCantidad As Long
        Dim descgrilla As Long
        'Dim netogrilla As Long
        'Dim ivagrilla As Long
        Dim totalgrilla As Long
        Dim subtotalgrilla As Long


        '//Calcular el sub-total 
        txt_subtotal.Text = 0
        For i = 0 To grilla_documento.Rows.Count - 1
            subtotalgrilla = Val(grilla_documento.Rows(i).Cells(3).Value.ToString)
            txt_subtotal.Text = Val(txt_subtotal.Text) + Val(subtotalgrilla)
        Next

        '//Calcular el descuento
        txt_descuento.Text = 0
        For i = 0 To grilla_documento.Rows.Count - 1
            descgrilla = Val(grilla_documento.Rows(i).Cells(4).Value.ToString)
            '  VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            '   descgrilla = descgrilla * VarCantidad
            txt_descuento.Text = Val(txt_descuento.Text) + Val(descgrilla)
        Next

        '//Calcular el total general
        txt_total.Text = 0
        For i = 0 To grilla_documento.Rows.Count - 1
            totalgrilla = Val(grilla_documento.Rows(i).Cells(5).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next




        If txt_subtotal.Text = "" Or txt_subtotal.Text = "0" Then
            txt_subtotal_millar.Text = "0"
        Else
            txt_subtotal_millar.Text = Format(Int(txt_subtotal.Text), "###,###,###")
        End If

        If txt_descuento.Text = "" Or txt_descuento.Text = "0" Then
            txt_descuento_millar.Text = "0"
        Else
            txt_descuento_millar.Text = Format(Int(txt_descuento.Text), "###,###,###")
        End If

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If

       
    End Sub

    Private Sub Combo_condicion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_condicion.SelectedIndexChanged
        grilla_documento.DataSource = Nothing
        calcular_totales()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 7, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 7, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center



        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Try
            Dim imagen_reporte As Image
            imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
            Dim posicion_imagen As New PointF(margen_izquierdo + 840, margen_superior + 10)
            e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        Catch
        End Try

        'Try
        '    e.Graphics.DrawImage(Form_menu_principal.PictureBox_reporte.Image, 810, 10, 260, 70)
        'Catch
        'End Try



        'Try
        '    e.Graphics.DrawImage(Form_menu_principal.PictureBox_reporte.Image, 1090 + margen_izquierdo, 80 + margen_superior, -230 + margen_izquierdo, -70 + margen_superior)
        'Catch
        'End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 75, margen_izquierdo + 1100, margen_superior + 45)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 90, margen_izquierdo + 1100, margen_superior + 60)

        e.Graphics.DrawString("DETALLE DE VENTAS", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 108, margen_izquierdo + 1120, margen_superior + 108)
        e.Graphics.DrawString(mirecintoempresa, Font_subtitulo, Brushes.Gray, rect2, stringFormat)


        e.Graphics.DrawString("TIPO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 140)
        e.Graphics.DrawString("NRO. DOC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 120, margen_superior + 140)
        e.Graphics.DrawString("USUARIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 190, margen_superior + 140)
        e.Graphics.DrawString("SUBTOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 340, margen_superior + 140)
        e.Graphics.DrawString("DESCUENTO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 420, margen_superior + 140)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 500, margen_superior + 140)
        e.Graphics.DrawString("FECHA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 580, margen_superior + 140)
        e.Graphics.DrawString("HORA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 660, margen_superior + 140)
        e.Graphics.DrawString("CONDICION", Font_titulo_columna, Brushes.Black, margen_izquierdo + 730, margen_superior + 140)
        e.Graphics.DrawString("RUT", Font_titulo_columna, Brushes.Black, margen_izquierdo + 840, margen_superior + 140)
        e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 920, margen_superior + 140)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 155, margen_izquierdo + 1120, margen_superior + 155)

        Dim Vartipo As String
        Dim VarNro As String
        Dim VarUsuario As String
        Dim VarSubtotal As String
        Dim VarDescuento As String
        Dim VarTotal As String
        Dim VarFecha As String
        Dim VarHora As String
        Dim VarCondicion As String
        Dim VarRut As String
        Dim VarNombre As String

        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10

        For i = numero_lineas_total To grilla_documento.Rows.Count - 1

            Vartipo = grilla_documento.Rows(i).Cells(0).Value.ToString
            VarNro = grilla_documento.Rows(i).Cells(1).Value.ToString
            VarUsuario = grilla_documento.Rows(i).Cells(2).Value.ToString
            VarSubtotal = grilla_documento.Rows(i).Cells(3).Value.ToString
            VarDescuento = grilla_documento.Rows(i).Cells(4).Value.ToString
            VarTotal = grilla_documento.Rows(i).Cells(5).Value.ToString
            VarFecha = grilla_documento.Rows(i).Cells(6).Value.ToString
            VarHora = grilla_documento.Rows(i).Cells(7).Value.ToString
            VarCondicion = grilla_documento.Rows(i).Cells(8).Value.ToString
            VarRut = grilla_documento.Rows(i).Cells(9).Value.ToString
            VarNombre = grilla_documento.Rows(i).Cells(10).Value.ToString

            If VarSubtotal = "" Or VarSubtotal = "0" Then
                VarSubtotal = "0"
            Else
                VarSubtotal = Format(Int(VarSubtotal), "###,###,###")
            End If

            If VarDescuento = "" Or VarDescuento = "0" Then
                VarDescuento = "0"
            Else
                VarDescuento = Format(Int(VarDescuento), "###,###,###")
            End If

            If VarTotal = "" Or VarTotal = "0" Then
                VarTotal = "0"
            Else
                VarTotal = Format(Int(VarTotal), "###,###,###")
            End If

            If VarFecha.Length > 10 Then
                VarFecha = VarFecha.Substring(0, 10)
            End If

            If VarNombre.Length > 29 Then
                VarNombre = VarNombre.Substring(0, 29)
            End If

            If Vartipo = "BOLETA DE CREDITO" Then
                Vartipo = "BOLETA"
            End If

            If Vartipo = "BOLETA DE CAMBIO" Then
                Vartipo = "BOLETA"
            End If

            If Vartipo = "FACTURA DE CREDITO" Then
                Vartipo = "FACTURA"
            End If

            If Vartipo = "NOTA DE CREDITO" Then
                Vartipo = "NOTA DE C."
            End If

            If Vartipo = "NOTA DE DEBITO" Then
                Vartipo = "NOTA DE D."
            End If

            e.Graphics.DrawString(Vartipo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarNro, Font_texto_impresion, Brushes.Black, margen_izquierdo + 120, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarUsuario, Font_texto_impresion, Brushes.Black, margen_izquierdo + 190, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarSubtotal, Font_texto_impresion, Brushes.Black, margen_izquierdo + 400, margen_superior + 160 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarDescuento, Font_texto_impresion, Brushes.Black, margen_izquierdo + 480, margen_superior + 160 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarTotal, Font_texto_impresion, Brushes.Black, margen_izquierdo + 560, margen_superior + 160 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarFecha, Font_texto_impresion, Brushes.Black, margen_izquierdo + 580, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarHora, Font_texto_impresion, Brushes.Black, margen_izquierdo + 660, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarCondicion, Font_texto_impresion, Brushes.Black, margen_izquierdo + 730, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarRut, Font_texto_impresion, Brushes.Black, margen_izquierdo + 840, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarNombre, Font_texto_impresion, Brushes.Black, margen_izquierdo + 920, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************


            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 62 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 165 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 1120, margen_superior + 165 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 165 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 1120, margen_superior + 165 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        e.Graphics.DrawString("TOTALES:             " & txt_subtotal_millar.Text, Font_texto_impresion, Brushes.Black, margen_izquierdo + 400, margen_superior + 170 + (numero_lineas * multiplicador_lineas), format1)
        '***************************************************************************************************************************************************

        e.Graphics.DrawString(txt_descuento_millar.Text, Font_texto_impresion, Brushes.Black, margen_izquierdo + 480, margen_superior + 170 + (numero_lineas * multiplicador_lineas), format1)
        '***************************************************************************************************************************************************

        e.Graphics.DrawString(txt_total_millar.Text, Font_texto_impresion, Brushes.Black, margen_izquierdo + 560, margen_superior + 170 + (numero_lineas * multiplicador_lineas), format1)
        '***************************************************************************************************************************************************

        numero_lineas_total = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Vartipo As String = ""
        Dim VarNro As String = ""
        Dim VarResultado As String = ""

        Dim VarFecha As String
        Dim VarHora As String

        For i = 0 To grilla_documento.Rows.Count - 1

            Vartipo = grilla_documento.Rows(i).Cells(0).Value.ToString
            VarNro = grilla_documento.Rows(i).Cells(1).Value.ToString
            VarFecha = grilla_documento.Rows(i).Cells(6).Value.ToString
            VarHora = grilla_documento.Rows(i).Cells(7).Value.ToString

            VarFecha = Format(CDate(VarFecha), "yyyy-MM-dd")

            If VarHora.Length = 7 Then
                VarHora = "0" & VarHora
            End If

            VarFecha = VarFecha & " " & VarHora

            If Vartipo.Contains("BOLETA") Then

                SC.Connection = conexion
                SC.CommandText = "Update detalle_boleta Set fecha='" & (VarFecha) & "' WHERE n_boleta ='" & (VarNro) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If

            If Vartipo.Contains("FACTURA") Then

                SC.Connection = conexion
                SC.CommandText = "Update detalle_factura Set fecha='" & (VarFecha) & "' WHERE n_factura ='" & (VarNro) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If

            If Vartipo.Contains("NOTA DE CREDITO") Then

                SC.Connection = conexion
                SC.CommandText = "Update detalle_nota_credito Set fecha='" & (VarFecha) & "' WHERE n_nota_credito ='" & (VarNro) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If

            If Vartipo.Contains("NOTA DE DEBITO") Then

                SC.Connection = conexion
                SC.CommandText = "Update detalle_nota_debito Set fecha='" & (VarFecha) & "' WHERE n_nota_debito ='" & (VarNro) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If

            If Vartipo.Contains("GUIA") Then

                SC.Connection = conexion
                SC.CommandText = "Update detalle_guia Set fecha='" & (VarFecha) & "' WHERE n_guia ='" & (VarNro) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If

        Next

        MsgBox(VarResultado)
    End Sub
End Class