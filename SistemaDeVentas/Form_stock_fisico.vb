Imports System.IO
Public Class Form_stock_fisico

    Private Sub Form_stock_fisico_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_stock_fisico_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_stock_fisico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub malla_inv()
        conexion.Close()
        DS1.Tables.Clear()
        DT1.Rows.Clear()
        DT1.Columns.Clear()
        DS1.Clear()
        conexion.Open()
        SC1.Connection = conexion
        SC1.CommandText = "select  cod_producto as 'COD. PRODUCTO', nombre as 'NOMBRE PRODUCTO', numero_tecnico as 'NRO. TECNICO', stock_fisico as 'STOCK FISICO'  from productos where stock_fisico <> 0"
        DA1.SelectCommand = SC1
        DA1.Fill(DT1)
        DS1.Tables.Add(DT1)
        grilla_documento.DataSource = DS1.Tables(DT1.TableName)
        conexion.Close()

        grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        txt_item.Text = grilla_documento.Rows.Count
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        malla_inv()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_traspasar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_traspasar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA TRASPASAR EL STOCK FISICO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then

            lbl_mensaje.Visible = True
            Me.Enabled = False

            SC.Connection = conexion
            SC.CommandText = "update productos SET cantidad='0' WHERE cod_producto = '000040'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update productos SET cantidad='0' WHERE cod_producto <> '000040'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            Dim cod_producto As String
            Dim stock_fisico As String
           
            For i = 0 To grilla_documento.Rows.Count - 1
                cod_producto = grilla_documento.Rows(i).Cells(0).Value.ToString
                stock_fisico = grilla_documento.Rows(i).Cells(3).Value.ToString
                
                SC.Connection = conexion
                SC.CommandText = "update productos SET cantidad='" & (stock_fisico) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next

            lbl_mensaje.Visible = False
            Me.Enabled = True

            MsgBox("SE HA GRABADO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")

        End If
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR EL STOCK ACTUAL DE PRODUCTOS?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then

            lbl_mensaje.Visible = True
            Me.Enabled = False

            SC.Connection = conexion
            SC.CommandText = "update productos SET stock_fisico='0' WHERE cod_producto = '000040'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update productos SET stock_fisico='0' WHERE cod_producto <> '000040'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            lbl_mensaje.Visible = False
            Me.Enabled = True

        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_documento.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            btn_mostrar.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_documento, save.FileName)
        End If


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

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub
End Class