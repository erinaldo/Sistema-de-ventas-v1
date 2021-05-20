Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_exportar_detalle_compras

    Private Sub Form_exportar_detalle_compras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_detalle_compras.WindowState = FormWindowState.Normal
        Form_detalle_compras.Enabled = True
    End Sub

    Private Sub Form_exportar_detalle_compras_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_exportar_detalle_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click


        Me.Enabled = False

        If Radio_compra.Checked = True Then
            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Form_detalle_compras.grilla_documento, save.FileName)
            End If
        End If


        If Radio_detalle_compra.Checked = True Then
            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Form_detalle_compras.grilla_documento_detalle, save.FileName)
            End If
        End If

        Me.Close()


    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        If Radio_compra.Checked = True Then
            Dim xlApp As Object = CreateObject("Excel.Application")
            'crear una nueva hoja de calculo 
            Dim xlWB As Object = xlApp.WorkBooks.add
            Dim xlWS As Object = xlWB.WorkSheets(1)

            'exportamos los caracteres de las columnas 
            For c As Integer = 0 To Form_detalle_compras.grilla_documento.Columns.Count - 1
                xlWS.cells(1, c + 1).value = Form_detalle_compras.grilla_documento.Columns(c).HeaderText
            Next
            'exportamos las cabeceras de columnas 
            For r As Integer = 0 To Form_detalle_compras.grilla_documento.RowCount - 1
                For c As Integer = 0 To Form_detalle_compras.grilla_documento.Columns.Count - 1
                    xlWS.cells(r + 2, c + 1).value = Form_detalle_compras.grilla_documento.Item(c, r).Value
                Next
            Next
            'guardamos la hoja de calculo en la ruta especificada 
            xlWB.saveas(pth)
            xlWS = Nothing
            xlWB = Nothing
            xlApp.quit()
            xlApp = Nothing
        End If



        If Radio_detalle_compra.Checked = True Then
            Dim xlApp As Object = CreateObject("Excel.Application")
            'crear una nueva hoja de calculo 
            Dim xlWB As Object = xlApp.WorkBooks.add
            Dim xlWS As Object = xlWB.WorkSheets(1)

            'exportamos los caracteres de las columnas 
            For c As Integer = 0 To Form_detalle_compras.grilla_documento_detalle.Columns.Count - 1
                xlWS.cells(1, c + 1).value = Form_detalle_compras.grilla_documento_detalle.Columns(c).HeaderText
            Next
            'exportamos las cabeceras de columnas 
            For r As Integer = 0 To Form_detalle_compras.grilla_documento_detalle.RowCount - 1
                For c As Integer = 0 To Form_detalle_compras.grilla_documento_detalle.Columns.Count - 1
                    xlWS.cells(r + 2, c + 1).value = Form_detalle_compras.grilla_documento_detalle.Item(c, r).Value
                Next
            Next
            'guardamos la hoja de calculo en la ruta especificada 
            xlWB.saveas(pth)
            xlWS = Nothing
            xlWB = Nothing
            xlApp.quit()
            xlApp = Nothing
        End If
    End Sub
End Class