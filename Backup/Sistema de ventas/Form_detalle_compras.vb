Imports CrystalDecisions.CrystalReports.Engine
Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_detalle_compras
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_detalle_compras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_detalle_compras_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        mostrar_malla()
        grilla_documento.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        combo_venta.SelectedItem = "-"
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


        If combo_venta.Text = "TODO" Then

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            If txt_nro_doc.Text = "" Then
                SC3.CommandText = "select compra.fecha_ingreso as INGRESO, compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'EMISION', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"
            End If

            If txt_nro_doc.Text <> "" Then
                SC3.CommandText = "select compra.fecha_ingreso as INGRESO, compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'EMISION', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR AND COMPRA.N_COMPRA='" & (txt_nro_doc.Text) & "' GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"
            End If
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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

            'If mirutempresa <> "81921000-4" Then
            If txt_nro_doc.Text = "" Then
                SC3.CommandText = "select compra.fecha_ingreso as INGRESO, compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'EMISION', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND TIPO LIKE 'FACTURA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"
            End If

            If txt_nro_doc.Text <> "" Then
                SC3.CommandText = "select compra.fecha_ingreso as INGRESO, compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'EMISION', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND TIPO LIKE 'FACTURA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR AND COMPRA.N_COMPRA='" & (txt_nro_doc.Text) & "' GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"
            End If
            'End If

            'If mirutempresa = "81921000-4" Then
            '    If txt_nro_doc.Text = "" Then
            '        SC3.CommandText = "select compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'FECHA', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_emision >='" & (mifecha2) & "' and fecha_emision <= '" & (mifecha4) & "' AND TIPO LIKE 'FACTURA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"
            '    End If

            '    If txt_nro_doc.Text <> "" Then
            '        SC3.CommandText = "select compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'FECHA', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_emision >='" & (mifecha2) & "' and fecha_emision <= '" & (mifecha4) & "' AND TIPO LIKE 'FACTURA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR AND COMPRA.N_COMPRA='" & (txt_nro_doc.Text) & "' GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"
            '    End If
            'End If

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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

            '  SC3.CommandText = "select compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'FECHA', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND TIPO LIKE 'GUIA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"

            If txt_nro_doc.Text = "" Then
                SC3.CommandText = "select compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'FECHA', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND TIPO LIKE 'GUIA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"
            End If

            If txt_nro_doc.Text <> "" Then
                SC3.CommandText = "select compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'FECHA', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND TIPO LIKE 'GUIA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR AND COMPRA.N_COMPRA='" & (txt_nro_doc.Text) & "'  GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"
            End If

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End If



        'If combo_venta.Text = "NOTA DE CREDITO" Then

        '    conexion.Close()
        '    Dim DT3 As New DataTable
        '    DS3.Tables.Clear()
        '    DT3.Rows.Clear()
        '    DT3.Columns.Clear()
        '    DS3.Clear()
        '    conexion.Open()
        '    SC3.Connection = conexion

        '    ' SC3.CommandText = "select NOTA_CREDITO.TIPO as TIPO, NOTA_CREDITO.N_NOTA_CREDITO as 'NRO.', usuarios.nombre_usuario NOMBRE, NOTA_CREDITO.sUBtotal AS SUBTOTAL , NOTA_CREDITO.DESCUENTO AS 'DESC.' , NOTA_CREDITO.total AS TOTAL, NOTA_CREDITO.FECHA_VENTA AS 'FECHA', HORA AS HORA, NOTA_CREDITO.CONDICIONES AS 'CONDICION', NOTA_CREDITO.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from NOTA_CREDITO , USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'NOTA DE CREDITO%' AND usuarios.rut_usuario =NOTA_CREDITO.usuario_responsable AND NOTA_CREDITO.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE GROUP BY N_NOTA_CREDITO ORDER BY N_NOTA_CREDITO"
        '    SC3.CommandText = "select compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'FECHA', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND TIPO LIKE 'NOTA DE CREDITO%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"

        '    DA3.SelectCommand = SC3
        '    DA3.Fill(DT3)
        '    DS3.Tables.Add(DT3)
        '    grilla_documento.DataSource = DS3.Tables(DT3.TableName)
        '    conexion.Close()

        '    grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'End If

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
        grilla_documento_detalle.DataSource = Nothing
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



        If grilla_documento.Rows.Count <> 0 Then

            lbl_mensaje.Visible = True
            Me.Enabled = False

            mostrar_malla_resumen()

            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Me.grilla_resumen, save.FileName)
            End If
            lbl_mensaje.Visible = False
            Me.Enabled = True



        End If

        'lbl_mensaje.Visible = True
        'Me.Enabled = False
        'Dim save As New SaveFileDialog
        'save.Filter = "Archivo Excel | *.xls"
        'If save.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Exportar_Excel(Me.grilla_documento, save.FileName)
        'End If
        'lbl_mensaje.Visible = False
        'Me.Enabled = True


    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_resumen.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_resumen.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_resumen.RowCount - 1
            For c As Integer = 0 To grilla_resumen.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_resumen.Item(c, r).Value
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

    Private Sub txt_nro_doc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.GotFocus
        txt_nro_doc.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_doc_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.LostFocus
        txt_nro_doc.BackColor = Color.White
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
        grilla_documento.DataSource = Nothing
        grilla_documento_detalle.DataSource = Nothing
    End Sub

    Sub mostrar_malla_detalle()
        Dim tipo_doc As String
        Dim nro_doc As String
        Dim proveedor_doc As String

        If combo_venta.Text <> "GUIA" Then
            tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
            nro_doc = grilla_documento.CurrentRow.Cells(2).Value
            proveedor_doc = grilla_documento.CurrentRow.Cells(6).Value
        Else
            tipo_doc = grilla_documento.CurrentRow.Cells(0).Value
            nro_doc = grilla_documento.CurrentRow.Cells(1).Value
            proveedor_doc = grilla_documento.CurrentRow.Cells(5).Value
        End If

        conexion.Close()
        Dim DT3 As New DataTable

        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion

        SC3.CommandText = "SELECT DETALLE_COMPRA.COD_PRODUCTO AS ITEM , productos.NOMBRE, productos.aplicacion AS APLICACION, DETALLE_COMPRA.CANTIDAD AS CANTIDAD, DETALLE_COMPRA.VALOR_UNITARIO AS COSTO ,DETALLE_COMPRA.FACTOR, DETALLE_COMPRA.MARGEN, DETALLE_COMPRA.PRECIO_VENTA AS PRECIO , DETALLE_COMPRA.MARGEN_ANTERIOR AS 'MAR. ANT.', DETALLE_COMPRA.PRECIO_ANTERIOR AS 'PRE. ANT.', PRODUCTOS.CODIGO_BARRA AS 'COD. BARRA' FROM compra, DETALLE_COMPRA , productos where compra.n_compra = detalle_compra.n_compra and detalle_compra.cod_producto = productos.cod_producto and detalle_compra.rut_proveedor ='" & (proveedor_doc) & "' and detalle_compra.n_compra = '" & (nro_doc) & "' and compra.TIPO = '" & (tipo_doc) & "' and  compra.rut_proveedor = '" & (proveedor_doc) & "'"

        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        grilla_documento_detalle.DataSource = DS3.Tables(DT3.TableName)
        conexion.Close()

        grilla_documento_detalle.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' grilla_documento_detalle.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        If grilla_documento_detalle.Rows.Count <> 0 Then
            grilla_documento_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            If grilla_documento_detalle.Columns(0).Width = 100 Then
                grilla_documento_detalle.Columns(0).Width = 99
            Else
                grilla_documento_detalle.Columns(0).Width = 100
            End If
            grilla_documento_detalle.Columns(1).Width = 200
            grilla_documento_detalle.Columns(2).Width = 150
            grilla_documento_detalle.Columns(3).Width = 100
            grilla_documento_detalle.Columns(4).Width = 100
            grilla_documento_detalle.Columns(5).Width = 100
            grilla_documento_detalle.Columns(6).Width = 100
            grilla_documento_detalle.Columns(7).Width = 100
            grilla_documento_detalle.Columns(8).Width = 100
            grilla_documento_detalle.Columns(9).Width = 100
        End If


    End Sub

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub

    Private Sub grilla_documento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.Click
        If grilla_documento.Rows.Count = 0 Then
            Exit Sub
        End If
        grilla_documento_detalle.DataSource = Nothing
        mostrar_malla_detalle()

    End Sub





    Sub mostrar_malla_resumen()

        grilla_resumen.DataSource = Nothing

        If combo_venta.Text = "TODO" Then

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'FECHA', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO, DETALLE_COMPRA.COD_PRODUCTO AS ITEM , DETALLE_COMPRA.NOMBRE AS NOMBRE, productoS.numero_tecnico as 'NRO. TECNICO', productos.aplicacion as 'APLICACION', DETALLE_COMPRA.CANTIDAD AS CANTIDAD, DETALLE_COMPRA.VALOR_UNITARIO AS COSTO ,DETALLE_COMPRA.FACTOR AS FACTOR, DETALLE_COMPRA.MARGEN AS MARGEN, DETALLE_COMPRA.PRECIO_VENTA AS PRECIO , DETALLE_COMPRA.MARGEN_ANTERIOR AS 'MAR. ANT.', DETALLE_COMPRA.PRECIO_ANTERIOR AS 'PRE. ANT.', productos.codigo_barra as 'CODIGO DE BARRA' from compra , detalle_compra, USUARIOS, PROVEEDORES, PRODUCTOS where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "'  and compra.n_compra=detalle_compra.n_compra and compra.rut_proveedor=detalle_compra.rut_proveedor AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR AND PRODUCTOS.COD_PRODUCTO=DETALLE_COMPRA.COD_PRODUCTO ORDER BY compra.CODIGO_COMPRA"
            ' SC3.CommandText = "SELECT DETALLE_COMPRA.COD_PRODUCTO AS ITEM , NOMBRE, DETALLE_COMPRA.CANTIDAD AS CANTIDAD, DETALLE_COMPRA.VALOR_UNITARIO AS COSTO ,FACTOR, MARGEN, DETALLE_COMPRA.PRECIO_VENTA AS PRECIO , DETALLE_COMPRA.MARGEN_ANTERIOR AS 'MAR. ANT.', DETALLE_COMPRA.PRECIO_ANTERIOR AS 'PRE. ANT.' FROM DETALLE_COMPRA where detalle_compra.rut_proveedor ='" & (proveedor_doc) & "' and detalle_compra.n_compra = '" & (nro_doc) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_resumen.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            'grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '' grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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

            SC3.CommandText = "select compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'FECHA', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO, DETALLE_COMPRA.COD_PRODUCTO AS ITEM , DETALLE_COMPRA.NOMBRE AS NOMBRE, productoS.numero_tecnico as 'NRO. TECNICO', productos.aplicacion as 'APLICACION', DETALLE_COMPRA.CANTIDAD AS CANTIDAD, DETALLE_COMPRA.VALOR_UNITARIO AS COSTO ,DETALLE_COMPRA.FACTOR AS FACTOR, DETALLE_COMPRA.MARGEN AS MARGEN, DETALLE_COMPRA.PRECIO_VENTA AS PRECIO , DETALLE_COMPRA.MARGEN_ANTERIOR AS 'MAR. ANT.', DETALLE_COMPRA.PRECIO_ANTERIOR AS 'PRE. ANT.', productos.codigo_barra as 'CODIGO DE BARRA'  from compra , detalle_compra, USUARIOS, PROVEEDORES, PRODUCTOS where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "'  and compra.n_compra=detalle_compra.n_compra and compra.rut_proveedor=detalle_compra.rut_proveedor AND compra.TIPO LIKE 'FACTURA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR AND PRODUCTOS.COD_PRODUCTO=DETALLE_COMPRA.COD_PRODUCTO ORDER BY compra.CODIGO_COMPRA"
            ' SC3.CommandText = "SELECT DETALLE_COMPRA.COD_PRODUCTO AS ITEM , NOMBRE, DETALLE_COMPRA.CANTIDAD AS CANTIDAD, DETALLE_COMPRA.VALOR_UNITARIO AS COSTO ,FACTOR, MARGEN, DETALLE_COMPRA.PRECIO_VENTA AS PRECIO , DETALLE_COMPRA.MARGEN_ANTERIOR AS 'MAR. ANT.', DETALLE_COMPRA.PRECIO_ANTERIOR AS 'PRE. ANT.' FROM DETALLE_COMPRA where detalle_compra.rut_proveedor ='" & (proveedor_doc) & "' and detalle_compra.n_compra = '" & (nro_doc) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_resumen.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            'grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '' grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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

            SC3.CommandText = "select compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'FECHA', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO, DETALLE_COMPRA.COD_PRODUCTO AS ITEM , DETALLE_COMPRA.NOMBRE AS NOMBRE, productoS.numero_tecnico as 'NRO. TECNICO', productos.aplicacion as 'APLICACION',  DETALLE_COMPRA.CANTIDAD AS CANTIDAD, DETALLE_COMPRA.VALOR_UNITARIO AS COSTO ,DETALLE_COMPRA.FACTOR AS FACTOR, DETALLE_COMPRA.MARGEN AS MARGEN, DETALLE_COMPRA.PRECIO_VENTA AS PRECIO , DETALLE_COMPRA.MARGEN_ANTERIOR AS 'MAR. ANT.', DETALLE_COMPRA.PRECIO_ANTERIOR AS 'PRE. ANT.', productos.codigo_barra as 'CODIGO DE BARRA'  from compra , detalle_compra, USUARIOS, PROVEEDORES, PRODUCTOS where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' and compra.n_compra=detalle_compra.n_compra and compra.rut_proveedor=detalle_compra.rut_proveedor AND compra.TIPO LIKE 'GUIA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR  AND PRODUCTOS.COD_PRODUCTO=DETALLE_COMPRA.COD_PRODUCTO ORDER BY compra.CODIGO_COMPRA"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_resumen.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()
        End If



        'If combo_venta.Text = "NOTA DE CREDITO" Then

        '    conexion.Close()
        '    Dim DT3 As New DataTable
        '    DS3.Tables.Clear()
        '    DT3.Rows.Clear()
        '    DT3.Columns.Clear()
        '    DS3.Clear()
        '    conexion.Open()
        '    SC3.Connection = conexion

        '    ' SC3.CommandText = "select NOTA_CREDITO.TIPO as TIPO, NOTA_CREDITO.N_NOTA_CREDITO as 'NRO.', usuarios.nombre_usuario NOMBRE, NOTA_CREDITO.sUBtotal AS SUBTOTAL , NOTA_CREDITO.DESCUENTO AS 'DESC.' , NOTA_CREDITO.total AS TOTAL, NOTA_CREDITO.FECHA_VENTA AS 'FECHA', HORA AS HORA, NOTA_CREDITO.CONDICIONES AS 'CONDICION', NOTA_CREDITO.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE' from NOTA_CREDITO , USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'NOTA DE CREDITO%' AND usuarios.rut_usuario =NOTA_CREDITO.usuario_responsable AND NOTA_CREDITO.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE GROUP BY N_NOTA_CREDITO ORDER BY N_NOTA_CREDITO"
        '    SC3.CommandText = "select compra.TIPO as TIPO, compra.n_compra as 'NRO.',compra.total AS TOTAL, compra.fecha_emision AS 'FECHA', HORA AS HORA, compra.rut_proveedor AS RUT, NOMBRE_proveedor AS 'PROVEEDOR', usuarios.nombre_usuario USUARIO from compra , USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND TIPO LIKE 'NOTA DE CREDITO%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.RUT_PROVEEDOR=PROVEEDORES.RUT_PROVEEDOR GROUP BY N_COMPRA ORDER BY CODIGO_COMPRA"

        '    DA3.SelectCommand = SC3
        '    DA3.Fill(DT3)
        '    DS3.Tables.Add(DT3)
        '    grilla_documento.DataSource = DS3.Tables(DT3.TableName)
        '    conexion.Close()

        '    grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'End If

    End Sub

    Private Sub txt_nro_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_doc.KeyPress
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
    End Sub

    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub
End Class