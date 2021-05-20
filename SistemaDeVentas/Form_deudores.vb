Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_deudores

    Dim peso As String
    Dim pesos As String
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_deudores_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_deudores_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    'se llama al dub fecha.
    Private Sub Form_deudores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        cargar_logo()
        grilla_deuda.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        ' combo_cuenta.SelectedItem = "TODOS"
        dtp_desde.Text = "01-01-" & dtp_desde.Value.Year
        Combo_estado.Text = "TODAS"
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha2 se le entrega el formato de fecha indicado.
    'Sub fecha()
    '    Dim mifecha As Date
    '    lblfecha.Text = FormatDateTime(Now, DateFormat.ShortDate)
    '    mifecha = lblfecha.Text
    '    mifecha2 = mifecha.ToString("yyy-MM-dd")
    'End Sub

    'selecciona todos los clientes con deuddas.
    Sub mostrar_malla()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        If Combo_estado.Text = "TODAS" Then
            SC.CommandText = "select * from  creditos where creditos.fecha_venta >='" & (mifecha2) & "' and creditos.fecha_venta <= '" & (mifecha4) & "' group by creditos.cod_auto order by fecha_venta;"
        End If

        If Combo_estado.Text = "IMPAGA" Then
            SC.CommandText = "select * from  creditos  where creditos.saldo <>'0' and  creditos.fecha_venta >='" & (mifecha2) & "' and creditos.fecha_venta <= '" & (mifecha4) & "' group by creditos.cod_auto order by fecha_venta;"
        End If

        If Combo_estado.Text = "PAGADA" Then
            SC.CommandText = "select * from  creditos where creditos.saldo ='0' and creditos.fecha_venta >='" & (mifecha2) & "' and creditos.fecha_venta <= '" & (mifecha4) & "' group by creditos.cod_auto order by fecha_venta;"
        End If

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_deuda.Rows.Clear()
        grilla_deuda.Columns.Clear()
        grilla_deuda.Columns.Add("", "N. CREDITO")
        grilla_deuda.Columns.Add("", "TIPO")
        grilla_deuda.Columns.Add("", "DETALLE")
        grilla_deuda.Columns.Add("", "RUT CLIENTE")
        grilla_deuda.Columns.Add("", "FECHA VENTA")
        grilla_deuda.Columns.Add("", "DESCUENTO")
        grilla_deuda.Columns.Add("", "NETO")
        grilla_deuda.Columns.Add("", "IVA")
        grilla_deuda.Columns.Add("", "SUBTOTAL")
        grilla_deuda.Columns.Add("", "TOTAL")
        grilla_deuda.Columns.Add("", "SALDO")
        grilla_deuda.Columns.Add("", "ESTADO")
        grilla_deuda.Columns.Add("", "RECINTO")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_deuda.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"),
                                       DS.Tables(DT.TableName).Rows(i).Item("tipo"),
                                        DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"),
                                         DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"),
                                          DS.Tables(DT.TableName).Rows(i).Item("fecha_venta"),
                                           DS.Tables(DT.TableName).Rows(i).Item("descuento"),
                                            DS.Tables(DT.TableName).Rows(i).Item("neto"),
                                             DS.Tables(DT.TableName).Rows(i).Item("iva"),
                                              DS.Tables(DT.TableName).Rows(i).Item("subtotal"),
                                               DS.Tables(DT.TableName).Rows(i).Item("total"),
                                                DS.Tables(DT.TableName).Rows(i).Item("saldo"),
                                                 DS.Tables(DT.TableName).Rows(i).Item("estado"),
                                                  DS.Tables(DT.TableName).Rows(i).Item("recinto"))
            Next
        End If

        If grilla_deuda.Rows.Count <> 0 Then
            If grilla_deuda.Columns(0).Width = 100 Then
                grilla_deuda.Columns(0).Width = 99
            Else
                grilla_deuda.Columns(0).Width = 100
            End If
            grilla_deuda.Columns(1).Width = 100
            grilla_deuda.Columns(2).Width = 100
            grilla_deuda.Columns(3).Width = 100
            grilla_deuda.Columns(4).Width = 100
            grilla_deuda.Columns(5).Width = 100
            grilla_deuda.Columns(6).Width = 100
            grilla_deuda.Columns(7).Width = 100
            grilla_deuda.Columns(8).Width = 100
            grilla_deuda.Columns(9).Width = 100
            grilla_deuda.Columns(10).Width = 100
            grilla_deuda.Columns(11).Width = 100
            grilla_deuda.Columns(12).Width = 100
            grilla_deuda.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_deuda.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_deuda.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_deuda.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_deuda.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_deuda.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_deuda.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_deuda.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_deuda.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_deuda.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_deuda.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_deuda.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_deuda.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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

    'funcion para realizar el desglose en palabras de la cifra que se indica en el txt_total.
    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function

    'calcula el total de la deuda de todos los clientes.
    Sub calcular_total()
        Dim totalgrilla As Integer

        '//Calcular el total general
        txt_total.Text = 0
        For i = 0 To grilla_deuda.Rows.Count - 1
            totalgrilla = Val(grilla_deuda.Rows(i).Cells(10).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next


        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If

    End Sub

    'segun el valor del combo se mostra una malla distinta.
    Private Sub combo_cuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LIMPIAR()
    End Sub

    'salir de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

 


    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_deuda.Rows.Count = 0 Then
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
            Exportar_Excel(Me.grilla_deuda, save.FileName)
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
        For c As Integer = 0 To grilla_deuda.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_deuda.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_deuda.RowCount - 1
            For c As Integer = 0 To grilla_deuda.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_deuda.Item(c, r).Value
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
            LIMPIAR()
        End If
    End Sub
    Sub LIMPIAR()
        grilla_deuda.Rows.Clear()
        txt_total.Text = 0
        txt_total_millar.Text = 0
        'combo_cuenta.SelectedItem = "TODOS"
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla()
        calcular_total()
        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        LIMPIAR()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        LIMPIAR()
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
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

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    'Private Sub combo_cuenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    combo_cuenta.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub combo_cuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    combo_cuenta.BackColor = Color.White

    '    '''Muestra el objeto que tiene el foco
    '    'For Each ctrl As Control In Me.Controls
    '    '    If ctrl.Focused Then txt_total_millar.Text = ctrl.Name
    '    'Next
    'End Sub
    Private Sub btn_salir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub




End Class