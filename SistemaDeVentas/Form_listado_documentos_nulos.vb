Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_listado_documentos_nulos
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_listado_documentos_nulos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal

    End Sub

    Private Sub Form_listado_documentos_nulos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_listado_documentos_nulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        mostrar_malla()
        grilla_documento.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()
        Combo_documento.SelectedItem = "-"
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
        If Combo_documento.Text = "BOLETA" Then

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select BOLETA.TIPO as TIPO, BOLETA.n_boleta as 'NRO.', usuarios.nombre_usuario NOMBRE, BOLETA.FECHA_VENTA AS 'FECHA', HORA AS HORA, BOLETA.CONDICIONES AS 'CONDICION', BOLETA.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', fecha_anulacion AS 'ANULACION' , total_anulacion AS 'TOTAL' from BOLETA , boleta_nula, USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'BOLETA%' AND usuarios.rut_usuario =BOLETA.usuario_responsable AND BOLETA.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE and BOLETA.estado='ANULADA' and TIPO <> 'AJUSTE' and BOLETA.n_boleta=boleta_nula.n_boleta and boleta_nula.documento='BOLETA' GROUP BY BOLETA.N_boleta ORDER BY BOLETA.N_boleta"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            'grilla_documento.Columns(0).Visible = False
            'grilla_documento.Columns(2).Visible = False
            'grilla_documento.Columns(3).Visible = False
            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If


        If Combo_documento.Text = "FACTURA" Then


            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion


            SC3.CommandText = "select FACTURA.TIPO as TIPO, FACTURA.N_FACTURA as 'NRO.', usuarios.nombre_usuario NOMBRE, FACTURA.FECHA_VENTA AS 'FECHA', HORA AS HORA, FACTURA.CONDICIONES AS 'CONDICION', FACTURA.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', fecha_anulacion AS 'ANULACION', total_anulacion AS 'TOTAL'   from FACTURA , boleta_nula, USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'FACTURA%' AND usuarios.rut_usuario =FACTURA.usuario_responsable AND FACTURA.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE and estado='ANULADA'  and TIPO <> 'AJUSTE'  and FACTURA.n_FACTURA=boleta_nula.n_boleta and boleta_nula.documento='FACTURA'GROUP BY N_FACTURA ORDER BY N_FACTURA"


            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If




        If Combo_documento.Text = "GUIA" Then

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select GUIA.TIPO as TIPO, GUIA.N_GUIA as 'NRO.', usuarios.nombre_usuario NOMBRE, GUIA.FECHA_VENTA AS 'FECHA', HORA AS HORA, GUIA.CONDICIONES AS 'CONDICION', GUIA.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', fecha_anulacion AS 'ANULACION', total_anulacion AS 'TOTAL'   from GUIA , boleta_nula, USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'GUIA%' AND usuarios.rut_usuario =GUIA.usuario_responsable AND GUIA.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE and estado='ANULADA'  and TIPO <> 'AJUSTE'  and GUIA.n_GUIA=boleta_nula.n_boleta and boleta_nula.documento='GUIA' GROUP BY N_GUIA ORDER BY N_GUIA"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If




        If Combo_documento.Text = "NOTA DE CREDITO" Then

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion


            SC3.CommandText = "select NOTA_CREDITO.TIPO as TIPO, NOTA_CREDITO.N_NOTA_CREDITO as 'NRO.', usuarios.nombre_usuario NOMBRE, NOTA_CREDITO.FECHA_VENTA AS 'FECHA', HORA AS HORA, NOTA_CREDITO.CONDICIONES AS 'CONDICION', NOTA_CREDITO.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', fecha_anulacion AS 'ANULACION', total_anulacion AS 'TOTAL'   from NOTA_CREDITO , boleta_nula, USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'NOTA DE CREDITO%' AND usuarios.rut_usuario =NOTA_CREDITO.usuario_responsable AND NOTA_CREDITO.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE GROUP BY N_NOTA_CREDITO and estado='ANULADA' and TIPO <> 'AJUSTE'  and NOTA_CREDITO.n_NOTA_CREDITO=boleta_nula.n_boleta and boleta_nula.documento='NOTA DE CREDITO' ORDER BY N_NOTA_CREDITO"


            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If Combo_documento.Text = "NOTA DE DEBITO" Then

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select NOTA_DEBITO.TIPO as TIPO, NOTA_DEBITO.N_NOTA_DEBITO as 'NRO.', usuarios.nombre_usuario NOMBRE, NOTA_DEBITO.FECHA_VENTA AS 'FECHA', HORA AS HORA, NOTA_DEBITO.CONDICIONES AS 'CONDICION', NOTA_DEBITO.RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', fecha_anulacion AS 'ANULACION', total_anulacion AS 'TOTAL'   from NOTA_DEBITO , boleta_nula, USUARIOS, CLIENTES where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND TIPO LIKE 'NOTA DE DEBITO%' AND usuarios.rut_usuario =NOTA_DEBITO.usuario_responsable AND NOTA_DEBITO.RUT_CLIENTE=CLIENTEs.RUT_CLIENTE GROUP BY N_NOTA_DEBITO and estado='ANULADA'  and TIPO <> 'AJUSTE'  and NOTA_DEBITO.n_NOTA_DEBITO=boleta_nula.n_boleta and boleta_nula.documento='NOTA DE DEBITO' ORDER BY N_NOTA_DEBITO"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_documento.SelectedIndexChanged
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
        Combo_documento.Text = ""
        grilla_documento.DataSource = Nothing
    End Sub



    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        Combo_documento.Text = ""
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

    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_documento.GotFocus
        Combo_documento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_documento.LostFocus
        Combo_documento.BackColor = Color.White
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
            grilla_documento.DataSource = Nothing
            Combo_documento.SelectedItem = "-"
        End If
    End Sub
End Class