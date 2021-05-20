Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_diferencia_compras
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_diferencia_compras_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_diferencia_compras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_diferencia_compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fecha()
        grilla_documento.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        combo_venta.Items.Clear()
        combo_venta.Items.Add("FACTURA")
        combo_venta.Items.Add("GUIA")
        combo_venta.Items.Add("-")
        combo_venta.SelectedItem = "-"

        cargar_logo()
        Me.Width = 1024
        Me.Height = 728
        Centrar()
    End Sub

    Public Sub Centrar()
        ' Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (My.Computer.Screen.Bounds.Width - Me.Width) \ 2
        Dim posicionY As Integer = (My.Computer.Screen.Bounds.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
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

        Dim Consulta_sql As String = ""

        Consulta_sql = "select compra.fecha_ingreso as ingreso, compra.tipo as 'TIPO', compra.n_compra as 'NRO.',compra.neto as 'NETO', compra.n_compra as 'NRO.',compra.total as 'TOTAL', compra.fecha_emision as 'EMISION', compra.total_automatico as 'TOTAL AUTOMATICO', compra.diferencia as 'DIFERENCIA', compra.porcentaje_diferencia as '% DIF.', hora as 'HORA', compra.rut_proveedor as 'RUT', nombre_proveedor as 'PROVEEDOR', usuarios.nombre_usuario usuario from compra , usuarios, proveedores where fecha_ingreso >='" & (mifecha2) & "' and fecha_ingreso <= '" & (mifecha4) & "' and usuarios.rut_usuario =compra.usuario_responsable and compra.rut_proveedor=proveedores.rut_proveedor "

        If combo_venta.Text <> "-" Then
            Consulta_sql = Consulta_sql & " and tipo like '" & (combo_venta.Text) & "%' "
        End If

        If txt_nro_doc.Text <> "" Then
            Consulta_sql = Consulta_sql & " and compra.n_compra='" & (txt_nro_doc.Text) & "'"
        End If

        Consulta_sql = Consulta_sql & " group by n_compra order by codigo_compra"


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = Consulta_sql
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
        grilla_documento.Columns.Add("", "TIPO")
        grilla_documento.Columns.Add("", "NRO.")
        grilla_documento.Columns.Add("", "NETO")
        grilla_documento.Columns.Add("", "TOTAL")
        grilla_documento.Columns.Add("", "EMISION")

        grilla_documento.Columns.Add("", "TOT. PROD.")
        grilla_documento.Columns.Add("", "DIFERENCIA")
        grilla_documento.Columns.Add("", "% DIF.")

        grilla_documento.Columns.Add("", "PROVEEDOR")
        grilla_documento.Columns.Add("", "USUARIO")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("NRO."),
                                            DS.Tables(DT.TableName).Rows(i).Item("NETO"),
                                             DS.Tables(DT.TableName).Rows(i).Item("TOTAL"),
                                              Format(CDate(DS.Tables(DT.TableName).Rows(i).Item("EMISION")), "yyyy-MM-dd"),
                                               DS.Tables(DT.TableName).Rows(i).Item("TOTAL AUTOMATICO"),
                                                DS.Tables(DT.TableName).Rows(i).Item("DIFERENCIA"),
                                                 DS.Tables(DT.TableName).Rows(i).Item("% DIF."),
                                                  DS.Tables(DT.TableName).Rows(i).Item("PROVEEDOR"),
                                                   DS.Tables(DT.TableName).Rows(i).Item("USUARIO"))
            Next
        End If

        If grilla_documento.Rows.Count <> 0 Then
            If grilla_documento.Columns(0).Width = 110 Then
                grilla_documento.Columns(0).Width = 109
            Else
                grilla_documento.Columns(0).Width = 110
            End If
            grilla_documento.Columns(1).Width = 110
            grilla_documento.Columns(2).Width = 110
            grilla_documento.Columns(3).Width = 110
            grilla_documento.Columns(4).Width = 110
            grilla_documento.Columns(5).Width = 110
            grilla_documento.Columns(6).Width = 110
            grilla_documento.Columns(7).Width = 110
            grilla_documento.Columns(8).Width = 160
            grilla_documento.Columns(9).Width = 160

            grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If
    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
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



        If grilla_documento.Rows.Count <> 0 Then

            lbl_mensaje.Visible = True
            Me.Enabled = False


            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Me.grilla_resumen, save.FileName)
            End If
            lbl_mensaje.Visible = False
            Me.Enabled = True

        End If

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
        combo_venta.Text = "-"
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        combo_venta.Text = "-"
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
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
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
    End Sub
End Class