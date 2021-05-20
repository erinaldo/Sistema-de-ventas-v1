Imports CrystalDecisions.CrystalReports.Engine
Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_detalle_ventas_documentos
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_detalle_ventas_documentos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_detalle_ventas_documentos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_ventas_documentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dtp_desde.CustomFormat = "yyy-MM-dd"
        ' dtp_hasta.CustomFormat = "yyy-MM-dd"
        fecha()
        mostrar_malla()
        grilla_documento.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()
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
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_malla()
        If combo_venta.Text = "BOLETA" Then

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', BOLETA.subtotal as 'SUBTOTAL', BOLETA.descuento as 'DCTO.', BOLETA.total as 'TOTAL', usuarios.nombre_usuario NOMBRE, DETALLE_boleta.COD_PRODUCTO AS ITEM, DETALLE_boleta.detalle_nombre AS 'NOMBRE ITEM', DETALLE_boleta.NUMERO_TECNICO AS 'NRO. TECNICO', DETALLE_boleta.CANTIDAD AS CANTIDAD, DETALLE_boleta.VALOR_UNITARIO AS PRECIO, DETALLE_boleta.DETALLE_DESCUENTO AS 'DCTO.', DETALLE_boleta.DETALLE_TOTAL AS 'TOTAL', BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', CLIENTES.RUT_CLIENTE AS RUT, CLIENTES.nombre_cliente as CLIENTE, CLIENTES.ciudad_cliente AS CIUDAD, CLIENTES.direccion_cliente AS DIRECCION from BOLETA , DETALLE_boleta, USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.N_boleta=DETALLE_boleta.N_boleta AND BOLETA.CODIGO_CLIENTE=CLIENTES.COD_CLIENTE ORDER BY BOLETA.N_boleta"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()



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

            'SC3.CommandText = "select FACTURA.TIPO as TIPO, FACTURA.n_FACTURA as 'NRO.',  FACTURA.subtotal as 'SUBTOTAL', FACTURA.descuento as 'DCTO.', FACTURA.total as 'TOTAL',usuarios.nombre_usuario NOMBRE, DETALLE_FACTURA.COD_PRODUCTO AS ITEM,  DETALLE_FACTURA.detalle_nombre AS 'NOMBRE ITEM', DETALLE_FACTURA.NUMERO_TECNICO AS 'NRO. TECNICO', DETALLE_FACTURA.CANTIDAD AS CANTIDAD, DETALLE_FACTURA.VALOR_UNITARIO AS PRECIO, FACTURA.FECHA_VENTA AS 'FECHA', HORA AS HORA, FACTURA.CONDICIONES AS 'CONDICION', CLIENTES.RUT_CLIENTE AS RUT, CLIENTES.nombre_cliente as CLIENTE, CLIENTES.ciudad_cliente AS CIUDAD, CLIENTES.direccion_cliente AS DIRECCION from FACTURA , DETALLE_FACTURA, USUARIOS, CLIENTES  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'FACTURA%' AND usuarios.rut_usuario =FACTURA.usuario_responsable AND FACTURA.N_FACTURA=DETALLE_FACTURA.N_FACTURA AND FACTURA.CODIGO_CLIENTE=CLIENTES.COD_CLIENTE and FACTURA.usuario_responsable='SISTEMA' ORDER BY FACTURA.N_FACTURA"
            SC3.CommandText = "select FACTURA.TIPO as TIPO, FACTURA.n_FACTURA as 'NRO.',  FACTURA.subtotal as 'SUBTOTAL', FACTURA.descuento as 'DCTO.', FACTURA.total as 'TOTAL',usuarios.nombre_usuario NOMBRE, DETALLE_FACTURA.COD_PRODUCTO AS ITEM,  DETALLE_FACTURA.detalle_nombre AS 'NOMBRE ITEM', DETALLE_FACTURA.NUMERO_TECNICO AS 'NRO. TECNICO', DETALLE_FACTURA.CANTIDAD AS CANTIDAD, DETALLE_FACTURA.VALOR_UNITARIO AS PRECIO, FACTURA.FECHA_VENTA AS 'FECHA', HORA AS HORA, FACTURA.CONDICIONES AS 'CONDICION', CLIENTES.RUT_CLIENTE AS RUT, CLIENTES.nombre_cliente as CLIENTE, CLIENTES.ciudad_cliente AS CIUDAD, CLIENTES.direccion_cliente AS DIRECCION from FACTURA , DETALLE_FACTURA, USUARIOS, CLIENTES  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'FACTURA%' AND usuarios.rut_usuario =FACTURA.usuario_responsable AND FACTURA.N_FACTURA=DETALLE_FACTURA.N_FACTURA AND FACTURA.CODIGO_CLIENTE=CLIENTES.COD_CLIENTE ORDER BY FACTURA.N_FACTURA"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()




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

            SC3.CommandText = "select GUIA.TIPO as TIPO, GUIA.n_GUIA as 'NRO.',  GUIA.subtotal as 'SUBTOTAL', GUIA.descuento as 'DCTO.', GUIA.total as 'TOTAL',usuarios.nombre_usuario NOMBRE, DETALLE_GUIA.COD_PRODUCTO AS ITEM ,  DETALLE_GUIA.detalle_nombre AS 'NOMBRE ITEM', DETALLE_GUIA.NUMERO_TECNICO AS 'NRO. TECNICO', DETALLE_GUIA.CANTIDAD AS CANTIDAD, DETALLE_GUIA.VALOR_UNITARIO AS PRECIO, GUIA.FECHA_VENTA AS 'FECHA', HORA AS HORA, GUIA.CONDICIONES AS 'CONDICION', CLIENTES.RUT_CLIENTE  AS RUT, CLIENTES.nombre_cliente as CLIENTE, CLIENTES.ciudad_cliente AS CIUDAD, CLIENTES.direccion_cliente AS DIRECCION from GUIA , DETALLE_GUIA, USUARIOS, CLIENTES  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'GUIA%' AND usuarios.rut_usuario =GUIA.usuario_responsable AND GUIA.N_GUIA=DETALLE_GUIA.N_GUIA  AND GUIA.CODIGO_CLIENTE=CLIENTES.COD_CLIENTE ORDER BY GUIA.N_GUIA"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()



        End If

        If combo_venta.Text = "COTIZACION" Then

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select COTIZACION.TIPO as TIPO, COTIZACION.n_COTIZACION as 'NRO.',  COTIZACION.subtotal as 'SUBTOTAL', COTIZACION.descuento as 'DCTO.', COTIZACION.total as 'TOTAL',usuarios.nombre_usuario NOMBRE, DETALLE_COTIZACION.COD_PRODUCTO AS ITEM ,  DETALLE_COTIZACION.detalle_nombre AS 'NOMBRE ITEM',  DETALLE_boleta.NUMERO_TECNICO AS 'NRO. TECNICO',DETALLE_COTIZACION.CANTIDAD AS CANTIDAD, DETALLE_COTIZACION.VALOR_UNITARIO AS PRECIO, COTIZACION.FECHA_VENTA AS 'FECHA', HORA AS HORA, COTIZACION.CONDICIONES AS 'CONDICION', CLIENTES.RUT_CLIENTE AS RUT, CLIENTES.nombre_cliente as CLIENTE, CLIENTES.ciudad_cliente AS CIUDAD, CLIENTES.direccion_cliente AS CLIENTES.DIRECCION from COTIZACION , DETALLE_COTIZACION, USUARIOS, CLIENTES  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'COTIZACION%' AND usuarios.rut_usuario =COTIZACION.usuario_responsable AND COTIZACION.N_COTIZACION=DETALLE_COTIZACION.N_COTIZACION  AND COTIZACION.CODIGO_CLIENTE=CLIENTES.COD_CLIENTE ORDER BY COTIZACION.N_COTIZACION"


            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()



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

            SC3.CommandText = "select NOTA_CREDITO.TIPO as TIPO, NOTA_CREDITO.n_NOTA_CREDITO as 'NRO.',  NOTA_CREDITO.subtotal as 'SUBTOTAL', NOTA_CREDITO.descuento as 'DCTO.', NOTA_CREDITO.total as 'TOTAL', usuarios.nombre_usuario NOMBRE, DETALLE_NOTA_CREDITO.COD_PRODUCTO AS ITEM ,  DETALLE_NOTA_CREDITO.detalle_nombre AS 'NOMBRE ITEM',  DETALLE_NOTA_CREDITO.NUMERO_TECNICO AS 'NRO. TECNICO',DETALLE_NOTA_CREDITO.CANTIDAD AS CANTIDAD, DETALLE_NOTA_CREDITO.VALOR_UNITARIO AS PRECIO, NOTA_CREDITO.FECHA_VENTA AS 'FECHA', HORA AS HORA, NOTA_CREDITO.CONDICIONES AS 'CONDICION', CLIENTES.RUT_CLIENTE  AS RUT, CLIENTES.nombre_cliente as CLIENTE, CLIENTES.ciudad_cliente AS CIUDAD, CLIENTES.direccion_cliente AS DIRECCION from NOTA_CREDITO , DETALLE_NOTA_CREDITO, USUARIOS, CLIENTES  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'NOTA DE CREDITO%' AND usuarios.rut_usuario =NOTA_CREDITO.usuario_responsable AND NOTA_CREDITO.N_NOTA_CREDITO=DETALLE_NOTA_CREDITO.N_NOTA_CREDITO  AND NOTA_CREDITO.CODIGO_CLIENTE=CLIENTES.COD_CLIENTE ORDER BY NOTA_CREDITO.N_NOTA_CREDITO"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()



        End If


        If grilla_documento.Rows.Count <> 0 Then
            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If


    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        grilla_documento.DataSource = Nothing
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_documento.DataSource = Nothing
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

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        combo_venta.Text = ""
        grilla_documento.DataSource = Nothing
    End Sub



    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        combo_venta.Text = ""
        grilla_documento.DataSource = Nothing
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


    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            combo_venta.SelectedItem = "TODOS"
            dtp_desde.Text = FormatDateTime(Now, DateFormat.ShortDate)
            dtp_hasta.Text = FormatDateTime(Now, DateFormat.ShortDate)
            grilla_documento.DataSource = Nothing
        End If
    End Sub
End Class