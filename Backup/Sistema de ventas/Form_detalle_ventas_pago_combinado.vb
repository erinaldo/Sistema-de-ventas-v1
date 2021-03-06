Imports CrystalDecisions.CrystalReports.Engine
Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_detalle_ventas_pago_combinado
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_detalle_ventas_pago_combinado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_detalle_ventas_pago_combinado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_ventas_pago_combinado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        mostrar_malla()
        grilla_documento.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()
        combo_venta.SelectedItem = "-"
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

            ' SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, DETALLE_boleta.COD_PRODUCTO AS ITEM, DETALLE_boleta.detalle_nombre AS 'NOMBRE ITEM', DETALLE_boleta.CANTIDAD AS CANTIDAD, DETALLE_boleta.VALOR_UNITARIO AS PRECIO, BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', RUT_CLIENTE AS RUT from BOLETA , DETALLE_boleta, USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.N_boleta=DETALLE_boleta.N_boleta ORDER BY BOLETA.N_boleta"
            SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, BOLETA.sUBtotal AS SUBTOTAL , BOLETA.DESCUENTO AS 'DESC.' , BOLETA.total AS TOTAL,BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', BOLETA.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from BOLETA , USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE AND CONDICIONES = 'PAGO COMBINADO' GROUP BY N_boleta ORDER BY N_boleta"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()


            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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

            ' SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, DETALLE_boleta.COD_PRODUCTO AS ITEM, DETALLE_boleta.detalle_nombre AS 'NOMBRE ITEM', DETALLE_boleta.CANTIDAD AS CANTIDAD, DETALLE_boleta.VALOR_UNITARIO AS PRECIO, BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', RUT_CLIENTE AS RUT from BOLETA , DETALLE_boleta, USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.N_boleta=DETALLE_boleta.N_boleta ORDER BY BOLETA.N_boleta"
            SC3.CommandText = "select factura.TIPO as TIPO, factura.n_factura as 'NRO.', usuarios.nombre_usuario NOMBRE, factura.sUBtotal AS SUBTOTAL , factura.DESCUENTO AS 'DESC.' , factura.total AS TOTAL, factura.FECHA_VENTA AS 'FECHA', HORA AS HORA, factura.CONDICIONES AS 'CONDICION', factura.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from factura , USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'factura%' AND usuarios.rut_usuario =factura.usuario_responsable AND factura.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE AND  CONDICIONES = 'PAGO COMBINADO' GROUP BY N_factura ORDER BY N_factura"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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

            ' SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, DETALLE_boleta.COD_PRODUCTO AS ITEM, DETALLE_boleta.detalle_nombre AS 'NOMBRE ITEM', DETALLE_boleta.CANTIDAD AS CANTIDAD, DETALLE_boleta.VALOR_UNITARIO AS PRECIO, BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', RUT_CLIENTE AS RUT from BOLETA , DETALLE_boleta, USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.N_boleta=DETALLE_boleta.N_boleta ORDER BY BOLETA.N_boleta"
            SC3.CommandText = "select guia.TIPO as TIPO, guia.n_guia as 'NRO.', usuarios.nombre_usuario NOMBRE, guia.sUBtotal AS SUBTOTAL , guia.DESCUENTO AS 'DESC.' , guia.total AS TOTAL, guia.FECHA_VENTA AS 'FECHA', HORA AS HORA, guia.CONDICIONES AS 'CONDICION', guia.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from guia , USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'guia%' AND usuarios.rut_usuario =guia.usuario_responsable AND guia.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE AND  CONDICIONES = 'PAGO COMBINADO' GROUP BY N_guia ORDER BY N_guia"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End If
    End Sub



    Sub mostrar_malla_pago_combinado()
        If combo_venta.Text = "BOLETA" Then

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            ' SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, DETALLE_boleta.COD_PRODUCTO AS ITEM, DETALLE_boleta.detalle_nombre AS 'NOMBRE ITEM', DETALLE_boleta.CANTIDAD AS CANTIDAD, DETALLE_boleta.VALOR_UNITARIO AS PRECIO, BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', RUT_CLIENTE AS RUT from BOLETA , DETALLE_boleta, USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.N_boleta=DETALLE_boleta.N_boleta ORDER BY BOLETA.N_boleta"
            SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, BOLETA.subtotal AS SUBTOTAL , BOLETA.DESCUENTO AS 'DESC.' , BOLETA.total AS TOTAL,BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', BOLETA.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from BOLETA , USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE AND CONDICIONES = 'PAGO COMBINADO' GROUP BY N_boleta ORDER BY N_boleta"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()


            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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

            ' SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, DETALLE_boleta.COD_PRODUCTO AS ITEM, DETALLE_boleta.detalle_nombre AS 'NOMBRE ITEM', DETALLE_boleta.CANTIDAD AS CANTIDAD, DETALLE_boleta.VALOR_UNITARIO AS PRECIO, BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', RUT_CLIENTE AS RUT from BOLETA , DETALLE_boleta, USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.N_boleta=DETALLE_boleta.N_boleta ORDER BY BOLETA.N_boleta"
            SC3.CommandText = "select factura.TIPO as TIPO, factura.n_factura as 'NRO.', usuarios.nombre_usuario NOMBRE, factura.sUBtotal AS SUBTOTAL , factura.DESCUENTO AS 'DESC.' , factura.total AS TOTAL, factura.FECHA_VENTA AS 'FECHA', HORA AS HORA, factura.CONDICIONES AS 'CONDICION', factura.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from factura , USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'factura%' AND usuarios.rut_usuario =factura.usuario_responsable AND factura.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE AND  CONDICIONES = 'PAGO COMBINADO' GROUP BY N_factura ORDER BY N_factura"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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

            ' SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, DETALLE_boleta.COD_PRODUCTO AS ITEM, DETALLE_boleta.detalle_nombre AS 'NOMBRE ITEM', DETALLE_boleta.CANTIDAD AS CANTIDAD, DETALLE_boleta.VALOR_UNITARIO AS PRECIO, BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', RUT_CLIENTE AS RUT from BOLETA , DETALLE_boleta, USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.N_boleta=DETALLE_boleta.N_boleta ORDER BY BOLETA.N_boleta"
            SC3.CommandText = "select guia.TIPO as TIPO, guia.n_guia as 'NRO.', usuarios.nombre_usuario NOMBRE, guia.sUBtotal AS SUBTOTAL , guia.DESCUENTO AS 'DESC.' , guia.total AS TOTAL, guia.FECHA_VENTA AS 'FECHA', HORA AS HORA, guia.CONDICIONES AS 'CONDICION', guia.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from guia , USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'guia%' AND usuarios.rut_usuario =guia.usuario_responsable AND guia.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE AND  CONDICIONES = 'PAGO COMBINADO' GROUP BY N_guia ORDER BY N_guia"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End If
    End Sub



    Sub mostrar_malla_detalle()

        Dim nro_doc As String

        nro_doc = ""

        If grilla_documento.Rows.Count <> 0 Then
            nro_doc = grilla_documento.CurrentRow.Cells(1).Value
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

            ' SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, DETALLE_boleta.COD_PRODUCTO AS ITEM, DETALLE_boleta.detalle_nombre AS 'NOMBRE ITEM', DETALLE_boleta.CANTIDAD AS CANTIDAD, DETALLE_boleta.VALOR_UNITARIO AS PRECIO, BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', RUT_CLIENTE AS RUT from BOLETA , DETALLE_boleta, USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.N_boleta=DETALLE_boleta.N_boleta ORDER BY BOLETA.N_boleta"
            SC3.CommandText = "select nro_doc as NUMERO, tipo_doc as 'TIPO',VALOR, CONDICION_DE_PAGO AS 'CONDICION DE PAGO' from detalle_condicion_de_pago where tipo_doc ='BOLETA' and NRO_DOC = '" & (nro_doc) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_detalle_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()


            grilla_detalle_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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

            ' SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, DETALLE_boleta.COD_PRODUCTO AS ITEM, DETALLE_boleta.detalle_nombre AS 'NOMBRE ITEM', DETALLE_boleta.CANTIDAD AS CANTIDAD, DETALLE_boleta.VALOR_UNITARIO AS PRECIO, BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', RUT_CLIENTE AS RUT from BOLETA , DETALLE_boleta, USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.N_boleta=DETALLE_boleta.N_boleta ORDER BY BOLETA.N_boleta"
            SC3.CommandText = "select nro_doc as NUMERO, tipo_doc as 'TIPO',VALOR, CONDICION_DE_PAGO AS 'CONDICION DE PAGO' from detalle_condicion_de_pago where tipo_doc ='FACTURA' and NRO_DOC = '" & (nro_doc) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_detalle_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()


            grilla_detalle_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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

            ' SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, DETALLE_boleta.COD_PRODUCTO AS ITEM, DETALLE_boleta.detalle_nombre AS 'NOMBRE ITEM', DETALLE_boleta.CANTIDAD AS CANTIDAD, DETALLE_boleta.VALOR_UNITARIO AS PRECIO, BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', RUT_CLIENTE AS RUT from BOLETA , DETALLE_boleta, USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.N_boleta=DETALLE_boleta.N_boleta ORDER BY BOLETA.N_boleta"
            SC3.CommandText = "select nro_doc as NUMERO, tipo_doc as 'TIPO',VALOR, CONDICION_DE_PAGO AS 'CONDICION DE PAGO' from detalle_condicion_de_pago where tipo_doc ='GUIA' and NRO_DOC = '" & (nro_doc) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_detalle_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()


            grilla_detalle_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        End If
    End Sub


    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
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

    End Sub

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub

    Private Sub grilla_documento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.Click
  
        If grilla_documento.Rows.Count <> 0 Then
            mostrar_malla_detalle()
        End If

    End Sub
End Class