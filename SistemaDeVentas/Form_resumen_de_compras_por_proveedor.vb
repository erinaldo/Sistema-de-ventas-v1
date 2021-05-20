Imports System.Math
Public Class Form_resumen_de_compras_por_proveedor
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_resumen_de_compras_por_proveedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_resumen_de_compras_por_proveedor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_resumen_de_compras_por_proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As DateTime = Now()

        'nombre_mes = d.ToString("MMMM") ' Te trae el nombre del mes que tenga d 

        'nro_mes = d.ToString("MM") ' Te trae el numero del mes con doble 0

        Combo_año.Text = Form_menu_principal.dtp_fecha.Value.Year()
        'Combo_mes.Text = "TODOS"

        cargar_logo()
        grilla_libro_compras.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        txt_productos.Text = ""
        txt_total.Text = ""
    End Sub
    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_total_compras()

        'Dim nro_mes As Integer

        'If Combo_mes.Text = "ENERO" Then
        '    nro_mes = 1
        'End If
        'If Combo_mes.Text = "FEBRERO" Then
        '    nro_mes = 2
        'End If
        'If Combo_mes.Text = "MARZO" Then
        '    nro_mes = 3
        'End If
        'If Combo_mes.Text = "ABRIL" Then
        '    nro_mes = 4
        'End If
        'If Combo_mes.Text = "MAYO" Then
        '    nro_mes = 5
        'End If
        'If Combo_mes.Text = "JUNIO" Then
        '    nro_mes = 6
        'End If
        'If Combo_mes.Text = "JULIO" Then
        '    nro_mes = 7
        'End If
        'If Combo_mes.Text = "AGOSTO" Then
        '    nro_mes = 8
        'End If
        'If Combo_mes.Text = "SEPTIEMBRE" Then
        '    nro_mes = 9
        'End If
        'If Combo_mes.Text = "OCTUBRE" Then
        '    nro_mes = 10
        'End If
        'If Combo_mes.Text = "NOVIEMBRE" Then
        '    nro_mes = 11
        'End If
        'If Combo_mes.Text = "DICIEMBRE" Then
        '    nro_mes = 12
        'End If

        If Combo_año.Text <> "-" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select sum(neto) as total from compra where YEAR(fecha_emision)='" & (Combo_año.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
            conexion.Close()
        End If



    End Sub

    Sub mostrar_malla_compras()

        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("", "RUT")
        grilla_libro_compras.Columns.Add("", "PROVEEDOR")
        grilla_libro_compras.Columns.Add("", "ENERO")
        grilla_libro_compras.Columns.Add("", "FEBRERO")
        grilla_libro_compras.Columns.Add("", "MARZO")
        grilla_libro_compras.Columns.Add("", "ABRIL")
        grilla_libro_compras.Columns.Add("", "MAYO")
        grilla_libro_compras.Columns.Add("", "JUNIO")
        grilla_libro_compras.Columns.Add("", "JULIO")
        grilla_libro_compras.Columns.Add("", "AGOSTO")
        grilla_libro_compras.Columns.Add("", "SEPTIEMBRE")
        grilla_libro_compras.Columns.Add("", "OCTUBRE")
        grilla_libro_compras.Columns.Add("", "NOVIEMBRE")
        grilla_libro_compras.Columns.Add("", "DICIEMBRE")
        grilla_libro_compras.Columns.Add("", "TOTAL")
        grilla_libro_compras.Columns.Add("", "%")

        'Dim nro_mes As Integer
        'Dim nro_dias As Integer
        Dim rut_proveedor As String
        Dim nombre_mes As String
        Dim rut_proveedor_anterior As String = ""
        Dim total_mes As String
        Dim total_proveedor As String = 0
        Dim contador As Integer = -1

        'If Combo_mes.Text = "ENERO" Then
        '    nro_mes = 1
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "FEBRERO" Then
        '    nro_mes = 2
        '    nro_dias = 28
        'End If
        'If Combo_mes.Text = "MARZO" Then
        '    nro_mes = 3
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "ABRIL" Then
        '    nro_mes = 4
        '    nro_dias = 30
        'End If
        'If Combo_mes.Text = "MAYO" Then
        '    nro_mes = 5
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "JUNIO" Then
        '    nro_mes = 6
        '    nro_dias = 30
        'End If
        'If Combo_mes.Text = "JULIO" Then
        '    nro_mes = 7
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "AGOSTO" Then
        '    nro_mes = 8
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "SEPTIEMBRE" Then
        '    nro_mes = 9
        '    nro_dias = 30
        'End If
        'If Combo_mes.Text = "OCTUBRE" Then
        '    nro_mes = 10
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "NOVIEMBRE" Then
        '    nro_mes = 11
        '    nro_dias = 30
        'End If
        'If Combo_mes.Text = "DICIEMBRE" Then
        '    nro_mes = 12
        '    nro_dias = 31
        'End If

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        'SC.CommandText = "SELECT compra.rut_proveedor, nombre_proveedor FROM `bd_or_valdivia`.`compra`, `bd_or_valdivia`.`proveedores` where YEAR(fecha_emision)='" & (Combo_año.Text) & "' and MONTH(fecha_emision)='" & (nro_mes) & "' and compra.rut_proveedor=proveedores.rut_proveedor group by rut_proveedor order by nombre_proveedor"

        SC.CommandText = "SELECT compra.rut_proveedor as proveedor, nombre_proveedor, sum(neto) as TOTAL,MonthName(fecha_emision) as nombre_mes FROM `bd_or_valdivia`.`compra`, `bd_or_valdivia`.`proveedores` where YEAR(fecha_emision)='" & (Combo_año.Text) & "' and compra.rut_proveedor=proveedores.rut_proveedor group by compra.rut_proveedor, MonthName(fecha_emision) order by nombre_proveedor, MonthName(fecha_emision) DESC"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                rut_proveedor = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
                nombre_mes = DS.Tables(DT.TableName).Rows(i).Item("nombre_mes")
                total_mes = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")




                If rut_proveedor = rut_proveedor_anterior Then

                    total_proveedor = Val(total_proveedor) + Val(total_mes)

                    'If total_mes = "" Or total_mes = "0" Then
                    '    total_mes = "0"
                    'Else
                    '    total_mes = Format(Int(total_mes), "###,###,###")
                    'End If

                    If nombre_mes = "January" Then
                        grilla_libro_compras.Rows(contador).Cells(2).Value = total_mes
                    End If
                    If nombre_mes = "February" Then
                        grilla_libro_compras.Rows(contador).Cells(3).Value = total_mes
                    End If
                    If nombre_mes = "March" Then
                        grilla_libro_compras.Rows(contador).Cells(4).Value = total_mes
                    End If
                    If nombre_mes = "April" Then
                        grilla_libro_compras.Rows(contador).Cells(5).Value = total_mes
                    End If
                    If nombre_mes = "May" Then
                        grilla_libro_compras.Rows(contador).Cells(6).Value = total_mes
                    End If
                    If nombre_mes = "June" Then
                        grilla_libro_compras.Rows(contador).Cells(7).Value = total_mes
                    End If
                    If nombre_mes = "July" Then
                        grilla_libro_compras.Rows(contador).Cells(8).Value = total_mes
                    End If
                    If nombre_mes = "August" Then
                        grilla_libro_compras.Rows(contador).Cells(9).Value = total_mes
                    End If
                    If nombre_mes = "September" Then
                        grilla_libro_compras.Rows(contador).Cells(10).Value = total_mes
                    End If
                    If nombre_mes = "October" Then
                        grilla_libro_compras.Rows(contador).Cells(11).Value = total_mes
                    End If
                    If nombre_mes = "November" Then
                        grilla_libro_compras.Rows(contador).Cells(12).Value = total_mes
                    End If
                    If nombre_mes = "December" Then
                        grilla_libro_compras.Rows(contador).Cells(13).Value = total_mes
                    End If

                Else
                    Try
                        'If total_proveedor = "" Or total_proveedor = "0" Then
                        '    total_proveedor = "0"
                        'Else
                        '    total_proveedor = Format(Int(total_proveedor), "###,###,###")
                        'End If

                        grilla_libro_compras.Rows(contador).Cells(14).Value = total_proveedor
                        Dim valor_porcentaje As Double
                        'Dim porcentaje_final As String
                        valor_porcentaje = (Val(total_proveedor) * 100) / Val(txt_total.Text)

                        'valor_porcentaje = Math.Round(valor_porcentaje, 2)
                        'porcentaje_final = valor_porcentaje

                        'If porcentaje_final.Length = 4 Then
                        '    porcentaje_final = "0" & porcentaje_final
                        'End If
                        'If porcentaje_final.Length = 1 Then
                        '    porcentaje_final = "0" & porcentaje_final & ",0"
                        'End If
                        'If porcentaje_final.Length = 3 Then
                        '    porcentaje_final = "0" & porcentaje_final & ",0"
                        'End If
                        grilla_libro_compras.Rows(contador).Cells(15).Value = valor_porcentaje
                    Catch
                    End Try

                    total_proveedor = 0
                    total_proveedor = Val(total_proveedor) + Val(total_mes)
                    contador = contador + 1
                    grilla_libro_compras.Rows.Add(rut_proveedor, DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0")


                    'If total_mes = "" Or total_mes = "0" Then
                    '    total_mes = "0"
                    'Else
                    '    total_mes = Format(Int(total_mes), "###,###,###")
                    'End If

                    If nombre_mes = "January" Then
                        grilla_libro_compras.Rows(contador).Cells(2).Value = total_mes
                    End If
                    If nombre_mes = "February" Then
                        grilla_libro_compras.Rows(contador).Cells(3).Value = total_mes
                    End If
                    If nombre_mes = "March" Then
                        grilla_libro_compras.Rows(contador).Cells(4).Value = total_mes
                    End If
                    If nombre_mes = "April" Then
                        grilla_libro_compras.Rows(contador).Cells(5).Value = total_mes
                    End If
                    If nombre_mes = "May" Then
                        grilla_libro_compras.Rows(contador).Cells(6).Value = total_mes
                    End If
                    If nombre_mes = "June" Then
                        grilla_libro_compras.Rows(contador).Cells(7).Value = total_mes
                    End If
                    If nombre_mes = "July" Then
                        grilla_libro_compras.Rows(contador).Cells(8).Value = total_mes
                    End If
                    If nombre_mes = "August" Then
                        grilla_libro_compras.Rows(contador).Cells(9).Value = total_mes
                    End If
                    If nombre_mes = "September" Then
                        grilla_libro_compras.Rows(contador).Cells(10).Value = total_mes
                    End If
                    If nombre_mes = "October" Then
                        grilla_libro_compras.Rows(contador).Cells(11).Value = total_mes
                    End If
                    If nombre_mes = "November" Then
                        grilla_libro_compras.Rows(contador).Cells(12).Value = total_mes
                    End If
                    If nombre_mes = "December" Then
                        grilla_libro_compras.Rows(contador).Cells(13).Value = total_mes
                    End If
                End If

                'grilla_libro_compras.Rows.Add(rut_proveedor, DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"))
                rut_proveedor_anterior = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
            Next

            Try
                'If total_proveedor = "" Or total_proveedor = "0" Then
                '    total_proveedor = "0"
                'Else
                '    total_proveedor = Format(Int(total_proveedor), "###,###,###")
                'End If

                grilla_libro_compras.Rows(contador).Cells(14).Value = total_proveedor
                Dim valor_porcentaje As Double
                'Dim porcentaje_final As String
                valor_porcentaje = (Val(total_proveedor) * 100) / Val(txt_total.Text)

                'valor_porcentaje = Math.Round(valor_porcentaje, 2)
                'porcentaje_final = valor_porcentaje

                'If porcentaje_final.Length = 4 Then
                '    porcentaje_final = "0" & porcentaje_final
                'End If
                'If porcentaje_final.Length = 1 Then
                '    porcentaje_final = "0" & porcentaje_final & ",0"
                'End If
                'If porcentaje_final.Length = 3 Then
                '    porcentaje_final = "0" & porcentaje_final & ",0"
                'End If
                grilla_libro_compras.Rows(contador).Cells(15).Value = valor_porcentaje
            Catch
            End Try
        End If










        txt_productos.Text = grilla_libro_compras.Rows.Count

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
            grilla_libro_compras.Columns(1).Width = 250
            grilla_libro_compras.Columns(2).Width = 100
            grilla_libro_compras.Columns(3).Width = 100
            grilla_libro_compras.Columns(4).Width = 100
            grilla_libro_compras.Columns(5).Width = 100
            grilla_libro_compras.Columns(6).Width = 100
            grilla_libro_compras.Columns(7).Width = 100
            grilla_libro_compras.Columns(8).Width = 100
            grilla_libro_compras.Columns(9).Width = 100
            grilla_libro_compras.Columns(10).Width = 100
            grilla_libro_compras.Columns(11).Width = 100
            grilla_libro_compras.Columns(12).Width = 100
            grilla_libro_compras.Columns(13).Width = 100
            grilla_libro_compras.Columns(14).Width = 100
            grilla_libro_compras.Columns(15).Width = 100
            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        mostrar_total_compras()
        mostrar_malla_compras()

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total.Text = "0"
        Else
            txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_libro_compras.Rows.Count = 0 Then

            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_libro_compras, save.FileName)
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
        For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_libro_compras.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_libro_compras.RowCount - 1
            For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_libro_compras.Item(c, r).Value
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
            grilla_libro_compras.Rows.Clear()
            grilla_libro_compras.Columns.Clear()
            txt_total.Text = ""
            txt_productos.Text = ""
        End If

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_libro_compras.Rows.Clear()
        txt_total.Text = ""
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub calcular_totales()

        'Dim totalgrilla As Long

        'txt_productos.Text = grilla_libro_compras.Rows.Count

        'If txt_productos.Text = "" Then
        '    txt_productos.Text = "0"
        'End If
        ''Calcular el total general
        'txt_total.Text = 0
        'For i = 0 To grilla_libro_compras.Rows.Count - 1
        '    totalgrilla = Val(grilla_libro_compras.Rows(i).Cells(8).Value.ToString)
        '    txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        'Next

        'If txt_total.Text = "" Or txt_total.Text = "0" Then
        '    txt_total.Text = "0"
        'Else
        '    txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        'End If

    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_libro_compras.Rows.Clear()
        txt_total.Text = ""
    End Sub

    Private Sub Combo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_año.SelectedIndexChanged
        grilla_libro_compras.Columns.Clear()
    End Sub

    Private Sub Combo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_libro_compras.Columns.Clear()
    End Sub
End Class