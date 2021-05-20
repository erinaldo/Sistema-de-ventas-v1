Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_stock_acumulado
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_stock_acumulado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_stock_acumulado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
            '    form_Menu_admin.Enabled = False
            Form_menu_principal.Close()

        End If
    End Sub
    Private Sub Form_stock_acumulado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        Combo_movimiento.SelectedItem = "SALE"
        combo_venta.SelectedItem = "TODOS"
        Combo_año.Text = Form_menu_principal.dtp_fecha.Value.Year()

        mostrar_malla()
        mostrar_meses()

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub limpiar()
        grilla_estado_de_cuenta.Rows.Clear()
        Combo_movimiento.SelectedItem = "SALE"
        combo_venta.SelectedItem = "TODOS"
        Combo_año.Text = Form_menu_principal.dtp_fecha.Value.Year()
    End Sub






    Sub mostrar_malla()


        '  Dim columna As Integer
        Dim mes As Integer


        mes = 1
        ' columna = 7

        Do While mes < 12

            If combo_venta.Text = "TODOS" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion

                SC.CommandText = "select cod_producto, detalle_nombre, numero_tecnico, sum(cantidad) as cant from detalle_factura, factura where year(fecha_venta)='" & (Combo_año.Text) & "' and month(fecha_venta)='" & (mes) & "' and factura.n_factura=detalle_factura.n_factura group by cod_producto, recinto;"

                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1


                        grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("cant"), _
                                                             mirecintoempresa, _
                                                               mes)

                    Next

                    ' grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
            End If



            If combo_venta.Text <> "TODOS" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion

                SC.CommandText = "select cod_producto, detalle_nombre, numero_tecnico, sum(cantidad) as cant, from detalle_factura, factura where year(fecha_venta)='" & (Combo_año.Text) & "' and month(fecha_venta)='" & (mes) & "' AND DETALLE_FACTURA.TIPO=='" & (combo_venta.Text) & "' and factura.n_factura=detalle_factura.n_factura group by cod_producto, recinto;"

                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1


                        grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("cant"), _
                                                             mirecintoempresa, _
                                                               mes)

                    Next

                    ' grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
            End If

            mes = mes + 1


        Loop


        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 80 Then
                grilla_estado_de_cuenta.Columns(0).Width = 79
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 80
            End If
        End If

    End Sub



    Sub mostrar_meses()

        'Dim columna As Integer
        'Dim mes As Integer
        'Dim VarCodProducto As String

        'mes = 1
        'columna = 7

        'Do While mes < 12



        '    For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

        '        VarCodProducto = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString



        '        If combo_venta.Text = "TODOS" Then
        '            conexion.Close()
        '            DS.Tables.Clear()
        '            DT.Rows.Clear()
        '            DT.Columns.Clear()
        '            DS.Clear()

        '            SC.Connection = conexion
        '            SC.CommandText = "select sum(cantidad) AS CANTIDAD from detalle_total WHERE month(fecha)='" & (mes) & "' and year(fecha)='" & (Combo_año.Text) & "' AND movimiento='" & (Combo_movimiento.Text) & "' and cod_producto='" & (VarCodProducto) & "' group by detalle_total.cod_producto order by detalle_total.cod_producto"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)

        '            DS.Tables.Add(DT)

        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                grilla_estado_de_cuenta.Item(columna, i).Value = DS.Tables(DT.TableName).Rows(0).Item("CANTIDAD")
        '            End If
        '        End If

        '        If combo_venta.Text <> "TODOS" Then
        '            conexion.Close()
        '            DS.Tables.Clear()
        '            DT.Rows.Clear()
        '            DT.Columns.Clear()
        '            DS.Clear()

        '            SC.Connection = conexion
        '            SC.CommandText = "select sum(cantidad) AS CANTIDAD from detalle_total WHERE month(fecha)='" & (mes) & "' and year(fecha)='" & (Combo_año.Text) & "' AND movimiento='" & (Combo_movimiento.Text) & "' and cod_producto='" & (VarCodProducto) & "' AND TIPO='" & (combo_venta.Text) & "' group by detalle_total.cod_producto order by detalle_total.cod_producto"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)

        '            DS.Tables.Add(DT)

        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                grilla_estado_de_cuenta.Item(columna, i).Value = DS.Tables(DT.TableName).Rows(0).Item("CANTIDAD")
        '            End If
        '        End If



        '    Next

        '    mes = mes + 1
        '    columna = columna + 1

        'Loop


    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        If Combo_año.Text = "" Then
            MsgBox("CAMPO AÑO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_año.Focus()
            Exit Sub
        End If

        If combo_venta.Text = "" Then
            MsgBox("CAMPO AÑO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_venta.Focus()
            Exit Sub
        End If

        If Combo_movimiento.Text = "" Then
            MsgBox("CAMPO MOVIMIENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_movimiento.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_estado_de_cuenta.Rows.Clear()
        mostrar_malla()
        mostrar_meses()

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            Combo_año.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_estado_de_cuenta, save.FileName)
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
        For c As Integer = 0 To grilla_estado_de_cuenta.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_estado_de_cuenta.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_estado_de_cuenta.RowCount - 1
            For c As Integer = 0 To grilla_estado_de_cuenta.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_estado_de_cuenta.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub Combo_movimiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_movimiento.SelectedIndexChanged
        Combo_año.Text = Form_menu_principal.dtp_fecha.Value.Year()
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        Combo_año.Text = Form_menu_principal.dtp_fecha.Value.Year()
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    Private Sub Combo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_año.SelectedIndexChanged
        Combo_año.Text = Form_menu_principal.dtp_fecha.Value.Year()
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub
End Class