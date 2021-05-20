Imports System.IO

Public Class Form_reporte_de_egresos
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_reporte_de_egresos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_reporte_de_egresos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_reporte_de_egresos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        mostrar_malla()
        calcular_totales()
        grilla_detalle.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()

        If mirutempresa <> "87686300-6" Then
            combo_tipo.Items.Clear()
            combo_tipo.Items.Add("-")
            combo_tipo.Items.Add("ANTICIPO")
            combo_tipo.Items.Add("SUELDO")
            combo_tipo.Items.Add("EGRESO CON BOLETA")
            combo_tipo.Items.Add("EGRESO CON FACTURA")
            combo_tipo.Items.Add("OTRO EGRESO")
            combo_tipo.Items.Add("INGRESO")
            combo_tipo.Items.Add("TODOS")
        Else
            combo_tipo.Items.Clear()
            combo_tipo.Items.Add("-")
            combo_tipo.Items.Add("FACTURA")
            combo_tipo.Items.Add("BOLETA")
            combo_tipo.Items.Add("RETIRO")
            combo_tipo.Items.Add("BOLETA HONORARIOS")
            combo_tipo.Items.Add("OTROS EGRESOS")
            combo_tipo.Items.Add("ANTICIPOS")
            combo_tipo.Items.Add("TODOS")
        End If
        combo_tipo.Text = "TODOS"
    End Sub

    Sub calcular_totales()
        Dim totalgrilla As Long

        txt_total_millar.Text = 0
        For i = 0 To grilla_detalle.Rows.Count - 1
            totalgrilla = Val(grilla_detalle.Rows(i).Cells(3).Value.ToString)
            txt_total_millar.Text = Val(txt_total_millar.Text) + Val(totalgrilla)
        Next

        If txt_total_millar.Text = "" Or txt_total_millar.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total_millar.Text), "###,###,###")
        End If
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
        If combo_tipo.Text = "TODOS" Then
            grilla_detalle.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from detalle_cuadratura_caja where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' order by TIPO asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim fecha As String
                Dim TIPO As String
                Dim detalle As String
                Dim monto As String

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                    TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    detalle = DS.Tables(DT.TableName).Rows(i).Item("detalle")
                    monto = DS.Tables(DT.TableName).Rows(i).Item("monto")

                    If mirutempresa <> "87686300-6" Then
                        If TIPO = "ANTICIPO" Then
                            TIPO = "SUELDO"
                        End If
                    End If

                    grilla_detalle.Rows.Add(fecha, TIPO, detalle, monto)
                Next
            End If
        End If

        If combo_tipo.Text <> "TODOS" Then
            Dim tipo_seleccion As String
            tipo_seleccion = combo_tipo.Text

            If mirutempresa <> "87686300-6" Then
                If tipo_seleccion = "ANTICIPO" Then
                    tipo_seleccion = "SUELDO"
                End If
            End If

            grilla_detalle.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from detalle_cuadratura_caja where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO= '" & (tipo_seleccion) & "' order by TIPO asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim fecha As String
                Dim TIPO As String
                Dim detalle As String
                Dim monto As String

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                    TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    detalle = DS.Tables(DT.TableName).Rows(i).Item("detalle")
                    monto = DS.Tables(DT.TableName).Rows(i).Item("monto")

                    If mirutempresa <> "87686300-6" Then
                        If TIPO = "ANTICIPO" Then
                            TIPO = "SUELDO"
                        End If
                    End If

                    grilla_detalle.Rows.Add(fecha, TIPO, detalle, monto)
                Next
            End If
        End If

        If grilla_detalle.Rows.Count <> 0 Then
            grilla_detalle.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_detalle.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        fecha()
        mostrar_malla()
        calcular_totales()
    End Sub


    Sub traspasar()

        'grilla_egresos_final.Rows.Clear()



        'Dim columna0 As String
        'Dim columna1 As String
        'Dim columna2 As String
        'Dim columna3 As String
        'Dim columna4 As String
        'Dim columna5 As String
        'Dim columna6 As String
        'Dim columna7 As String

        'For i = 0 To grilla_egresos.Rows.Count - 1
        '    columna0 = grilla_egresos.Rows(i).Cells(0).Value.ToString
        '    columna1 = Val(grilla_egresos.Rows(i).Cells(1).Value.ToString)
        '    columna2 = Val(grilla_egresos.Rows(i).Cells(2).Value.ToString)
        '    columna3 = Val(grilla_egresos.Rows(i).Cells(3).Value.ToString)
        '    columna4 = Val(grilla_egresos.Rows(i).Cells(4).Value.ToString)
        '    columna5 = Val(grilla_egresos.Rows(i).Cells(5).Value.ToString)
        '    columna6 = Val(grilla_egresos.Rows(i).Cells(6).Value.ToString)
        '    ' columna7 = Val(grilla_egresos.Rows(i).Cells(7).Value.ToString)

        '    If columna1 = "" Or columna1 = "0" Then
        '        columna1 = "0"
        '    Else
        '        columna1 = Format(Int(columna1), "###,###,###")
        '    End If

        '    If columna2 = "" Or columna2 = "0" Then
        '        columna2 = "0"
        '    Else
        '        columna2 = Format(Int(columna2), "###,###,###")
        '    End If

        '    If columna3 = "" Or columna3 = "0" Then
        '        columna3 = "0"
        '    Else
        '        columna3 = Format(Int(columna3), "###,###,###")
        '    End If

        '    If columna4 = "" Or columna4 = "0" Then
        '        columna4 = "0"
        '    Else
        '        columna4 = Format(Int(columna4), "###,###,###")
        '    End If

        '    If columna5 = "" Or columna5 = "0" Then
        '        columna5 = "0"
        '    Else
        '        columna5 = Format(Int(columna5), "###,###,###")
        '    End If

        '    If columna6 = "" Or columna6 = "0" Then
        '        columna6 = "0"
        '    Else
        '        columna6 = Format(Int(columna6), "###,###,###")
        '    End If

        '    'If columna7 = "" Or columna7 = "0" Then
        '    '    columna7 = "0"
        '    'Els9,
        '    '    columna7 = Format(Int(columna7), "###,###,###")
        '    'End If

        '    grilla_egresos_final.Rows.Add(columna0, columna1, columna2, columna3, columna4, columna5, columna6)
        'Next
    End Sub




    Sub traspasar_excel()

        'grilla_excel.Rows.Clear()



        'Dim columna0 As String
        'Dim columna1 As String
        'Dim columna2 As String
        'Dim columna3 As String
        'Dim columna4 As String
        'Dim columna5 As String
        'Dim columna6 As String
        'Dim columna7 As String

        'For i = 0 To grilla_egresos_final.Rows.Count - 1
        '    columna0 = grilla_egresos_final.Rows(i).Cells(0).Value.ToString
        '    columna1 = grilla_egresos_final.Rows(i).Cells(1).Value.ToString
        '    columna2 = grilla_egresos_final.Rows(i).Cells(2).Value.ToString
        '    columna3 = grilla_egresos_final.Rows(i).Cells(3).Value.ToString
        '    columna4 = grilla_egresos_final.Rows(i).Cells(4).Value.ToString
        '    columna5 = grilla_egresos_final.Rows(i).Cells(5).Value.ToString
        '    columna6 = grilla_egresos_final.Rows(i).Cells(6).Value.ToString
        '    ' columna7 = Val(grilla_egresos.Rows(i).Cells(7).Value.ToString)


        '    grilla_excel.Rows.Add(columna0, columna1, columna2, columna3, columna4, columna5, columna6)
        'Next

        'grilla_excel.Rows.Add("")
        'grilla_excel.Rows.Add("DETALLE", "", "", "", "")
        'grilla_excel.Rows.Add("")

        'For i = 0 To grilla_detalle.Rows.Count - 1
        '    columna0 = grilla_detalle.Rows(i).Cells(0).Value.ToString
        '    columna1 = grilla_detalle.Rows(i).Cells(1).Value.ToString
        '    columna2 = grilla_detalle.Rows(i).Cells(2).Value.ToString
        '    columna3 = grilla_detalle.Rows(i).Cells(3).Value.ToString
        '    columna4 = grilla_detalle.Rows(i).Cells(4).Value.ToString
        '    '  columna5 = grilla_detalle.Rows(i).Cells(5).Value.ToString

        '    ' columna7 = Val(grilla_egresos.Rows(i).Cells(7).Value.ToString)

        '    'If columna1 = "" Or columna1 = "0" Then
        '    '    columna1 = "0"
        '    'Else
        '    '    columna1 = Format(Int(columna1), "###,###,###")
        '    'End If

        '    'If columna2 = "" Or columna2 = "0" Then
        '    '    columna2 = "0"
        '    'Else
        '    '    columna2 = Format(Int(columna2), "###,###,###")
        '    'End If

        '    'If columna3 = "" Or columna3 = "0" Then
        '    '    columna3 = "0"
        '    'Else
        '    '    columna3 = Format(Int(columna3), "###,###,###")
        '    'End If

        '    If columna4 = "" Or columna4 = "0" Then
        '        columna4 = "0"
        '    Else
        '        columna4 = Format(Int(columna4), "###,###,###")
        '    End If

        '    'If columna5 = "" Or columna5 = "0" Then
        '    '    columna5 = "0"
        '    'Else
        '    '    columna5 = Format(Int(columna5), "###,###,###")
        '    'End If

        '    'If columna6 = "" Or columna6 = "0" Then
        '    '    columna6 = "0"
        '    'Else
        '    '    columna6 = Format(Int(columna6), "###,###,###")
        '    'End If

        '    ''If columna7 = "" Or columna7 = "0" Then
        '    ''    columna7 = "0"
        '    ''Els9,
        '    ''    columna7 = Format(Int(columna7), "###,###,###")
        '    'End If

        '    grilla_excel.Rows.Add(columna0, columna1, columna2, columna3, columna4)
        'Next
    End Sub




    Sub cargar_detalle()

        'Dim recinto As String
        Dim fecha As String
        Dim TIPO As String
        Dim detalle As String
        Dim monto As String

        grilla_detalle.Rows.Clear()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO <> 'INGRESO' order by TIPO"


        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        'Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1




                'recinto = DS.Tables(DT.TableName).Rows(i).Item("recinto")
                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                detalle = DS.Tables(DT.TableName).Rows(i).Item("detalle")
                monto = DS.Tables(DT.TableName).Rows(i).Item("monto")

                If TIPO = "ANTICIPOS" Then
                    TIPO = "SUELDOS"
                End If

                'grilla_detalle.Rows.Add(recinto, fecha, TIPO, detalle, monto)
                grilla_detalle.Rows.Add(fecha, TIPO, detalle, monto)
            Next
        End If

    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_detalle.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp_desde.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False

        traspasar_excel()

        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_detalle, save.FileName)
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
        For c As Integer = 0 To grilla_detalle.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_detalle.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_detalle.RowCount - 1
            For c As Integer = 0 To grilla_detalle.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_detalle.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_detalle.Rows.Clear()
            txt_total_millar.Text = ""
            combo_tipo.Text = "TODOS"
            dtp_desde.Text = Form_menu_principal.dtp_fecha.Text
            dtp_hasta.Text = Form_menu_principal.dtp_fecha.Text
        End If
    End Sub


    Sub color_foco()
        Dim controlcito As Control
        Dim controlChild As Control

        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).ReadOnly = False Then
                    CType(controlcito, TextBox).BackColor = Color.White
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                CType(controlcito, ComboBox).BackColor = Color.White
            End If

            If TypeOf controlcito Is Button Then
                CType(controlcito, Button).BackColor = Color.Transparent
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).ReadOnly = False Then
                            CType(controlChild, TextBox).BackColor = Color.White
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        CType(controlChild, ComboBox).BackColor = Color.White
                    End If

                    If TypeOf controlChild Is Button Then
                        CType(controlChild, Button).BackColor = Color.Transparent
                    End If
                Next
            End If
        Next

        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).Focused Then
                    If CType(controlcito, TextBox).ReadOnly = False Then
                        CType(controlcito, TextBox).BackColor = Color.LightSkyBlue
                        Exit Sub
                    End If
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                If CType(controlcito, ComboBox).Focused Then
                    CType(controlcito, ComboBox).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is Button Then
                If CType(controlcito, Button).Focused Then
                    CType(controlcito, Button).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).Focused Then
                            If CType(controlChild, TextBox).ReadOnly = False Then
                                CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
                                Exit Sub
                            End If
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        If CType(controlChild, ComboBox).Focused Then
                            CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If

                    If TypeOf controlChild Is Button Then
                        If CType(controlChild, Button).Focused Then
                            CType(controlChild, Button).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub GroupBox_totales_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox_totales.Enter

    End Sub

    Private Sub combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.GotFocus
        color_foco()
    End Sub

    Private Sub combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_tipo.SelectedIndexChanged

    End Sub

    Private Sub dtp_desde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.GotFocus
        color_foco()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged

    End Sub

    Private Sub dtp_hasta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.GotFocus
        color_foco()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged

    End Sub

    Private Sub txt_total_millar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total_millar.GotFocus
        color_foco()
    End Sub

    Private Sub txt_total_millar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_millar.TextChanged

    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click

    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        color_foco()
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        color_foco()
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        color_foco()
    End Sub
End Class