Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_detalle_compras_por_documento
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_detalle_compras_por_documento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_detalle_compras_por_documento_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_compras_por_documento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        mostrar_malla()
        grilla_documento_detalle.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
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
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_malla()



        If combo_venta.Text = "FACTURA" Then
            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select COMPRA.TIPO as TIPO, COMPRA.n_COMPRA as 'NRO.', DETALLE_COMPRA.COD_PRODUCTO AS ITEM , DETALLE_COMPRA.CANTIDAD AS CANTIDAD, DETALLE_COMPRA.VALOR_UNITARIO AS PRECIO, COMPRA.FECHA_EMISION AS 'FECHA', HORA AS HORA,  NOMBRE_PROVEEDOR AS RUT, usuarios.nombre_usuario USUARIO from COMPRA , DETALLE_COMPRA, USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND TIPO LIKE 'FACTURA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.rut_PROVEEDOR =PROVEEDORES.rut_PROVEEDOR AND COMPRA.N_COMPRA=DETALLE_COMPRA.N_COMPRA ORDER BY COMPRA.N_COMPRA"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento_detalle.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()


            grilla_documento_detalle.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento_detalle.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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

            SC3.CommandText = "select COMPRA.TIPO as TIPO, COMPRA.n_COMPRA as 'NRO.', DETALLE_COMPRA.COD_PRODUCTO AS ITEM , DETALLE_COMPRA.CANTIDAD AS CANTIDAD, DETALLE_COMPRA.VALOR_UNITARIO AS PRECIO, COMPRA.FECHA_EMISION AS 'FECHA', HORA AS HORA,  NOMBRE_PROVEEDOR AS RUT, usuarios.nombre_usuario USUARIO from COMPRA , DETALLE_COMPRA, USUARIOS, PROVEEDORES where fecha_INGRESO >='" & (mifecha2) & "' and fecha_INGRESO <= '" & (mifecha4) & "' AND TIPO LIKE 'GUIA%' AND usuarios.rut_usuario =COMPRA.usuario_responsable AND COMPRA.rut_PROVEEDOR =PROVEEDORES.rut_PROVEEDOR AND COMPRA.N_COMPRA=DETALLE_COMPRA.N_COMPRA ORDER BY COMPRA.N_COMPRA"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento_detalle.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()


            grilla_documento_detalle.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento_detalle.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End If



    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        grilla_documento_detalle.DataSource = Nothing
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_documento_detalle.DataSource = Nothing
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



        If grilla_documento_detalle.Rows.Count = 0 Then
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
            Exportar_Excel(Me.grilla_documento_detalle, save.FileName)
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
        For c As Integer = 0 To grilla_documento_detalle.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_documento_detalle.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_documento_detalle.RowCount - 1
            For c As Integer = 0 To grilla_documento_detalle.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_documento_detalle.Item(c, r).Value
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
        grilla_documento_detalle.DataSource = Nothing
    End Sub



    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        combo_venta.Text = ""
        grilla_documento_detalle.DataSource = Nothing
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


End Class