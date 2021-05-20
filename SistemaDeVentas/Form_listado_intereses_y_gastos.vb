Public Class Form_listado_intereses_y_gastos
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_listado_intereses_y_gastos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_listado_intereses_y_gastos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_listado_intereses_y_gastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        grilla_libro_compras.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub mostrar_malla_inventario()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT detalle_abono.nro_abono AS 'NRO.', fecha AS 'FECHA', detalle_abono.tipo_documento AS 'TIPO', detalle_abono.nro_documento AS 'DOCUMENTO', detalle_abono.fecha_vencimiento AS 'VENCIMIENTO', detalle_abono.interes AS 'INTERES', detalle_abono.gastos AS 'GASTOS', DATEDIFF(fecha, fecha_vencimiento) AS 'DIFERENCIA' FROM abono, detalle_abono WHERE abono.n_abono=detalle_abono.nro_abono and fecha_vencimiento < fecha and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' ORDER BY detalle_abono.cod_auto DESC;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("", "NRO.")
        grilla_libro_compras.Columns.Add("", "FECHA")
        grilla_libro_compras.Columns.Add("", "TIPO")
        grilla_libro_compras.Columns.Add("", "DOCUMENTO")
        grilla_libro_compras.Columns.Add("", "VENCIMIENTO")
        grilla_libro_compras.Columns.Add("", "INTERES")
        grilla_libro_compras.Columns.Add("", "GASTOS")
        grilla_libro_compras.Columns.Add("", "DIFERENCIA")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaEmision As Date
                Dim mifecha_emision2 As String
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("NRO."), _
                                               mifecha_emision2, _
                                                DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("VENCIMIENTO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("INTERES"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("GASTOS"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("DIFERENCIA"))
            Next
        End If

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
            grilla_libro_compras.Columns(1).Width = 100
            grilla_libro_compras.Columns(2).Width = 100
            grilla_libro_compras.Columns(3).Width = 100
            grilla_libro_compras.Columns(4).Width = 100
            grilla_libro_compras.Columns(5).Width = 100
            grilla_libro_compras.Columns(6).Width = 100
            grilla_libro_compras.Columns(7).Width = 100
            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla_inventario()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_libro_compras.Rows.Count = 0 Then
            dtp_desde.Focus()
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
            txt_gastos.Text = ""
            txt_interes.Text = ""
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

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        txt_gastos.Text = ""
        txt_interes.Text = ""
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub calcular_totales()

        Dim totalInteres As Long
        Dim totalGastos As Long

        'Calcular el total general
        txt_interes.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            totalInteres = Val(grilla_libro_compras.Rows(i).Cells(5).Value.ToString)
            txt_interes.Text = Val(txt_interes.Text) + Val(totalInteres)
        Next

        If txt_interes.Text = "" Or txt_interes.Text = "0" Then
            txt_interes.Text = "0"
        Else
            txt_interes.Text = Format(Int(txt_interes.Text), "###,###,###")
        End If

        txt_gastos.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            totalGastos = Val(grilla_libro_compras.Rows(i).Cells(6).Value.ToString)
            txt_gastos.Text = Val(txt_gastos.Text) + Val(totalGastos)
        Next

        If txt_gastos.Text = "" Or txt_gastos.Text = "0" Then
            txt_gastos.Text = "0"
        Else
            txt_gastos.Text = Format(Int(txt_gastos.Text), "###,###,###")
        End If
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        txt_gastos.Text = ""
        txt_interes.Text = ""
    End Sub

    Private Sub PictureBox_logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_logo.Click

    End Sub
End Class