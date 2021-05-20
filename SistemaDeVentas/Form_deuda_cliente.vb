Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_deuda_cliente
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim mifecha6 As String

    Private Sub Form_deuda_cliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_deuda_cliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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


        Dim VarDoc As String
        Dim VarNro As String
        Dim VarFecha As String
        Dim VarTotal As String
        Dim VarSaldo As String
        Dim VarRut As String
        Dim VarNombre As String
        Dim estado As String
        Dim fecha_pago As String
        Dim fecha_vencimiento As String
        Dim dias As Integer

        If txt_rut.Text = "" Then
            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion
            SC3.CommandText = "select TIPO, n_creditos, fecha_venta, total, saldo, clientes.rut_cliente, nombre_cliente, historico_CREDITOS.FECHA_PAGO, historico_CREDITOS.FECHA_vencimiento from historico_creditos, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <='" & (mifecha4) & "' and ESTADO <> 'ANULADA' and ESTADO <> 'ANULADO' and historico_CREDITOS.rut_cliente=clientes.rut_cliente group by n_creditos, clientes.rut_cliente order by fecha_venta asc"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)

            DS3.Tables.Add(DT3)
            grilla_deuda.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_deuda_final.Rows.Clear()

            For i = 0 To grilla_deuda.Rows.Count - 1
                VarDoc = grilla_deuda.Rows(i).Cells(0).Value.ToString
                VarNro = grilla_deuda.Rows(i).Cells(1).Value.ToString
                VarFecha = grilla_deuda.Rows(i).Cells(2).Value.ToString
                VarTotal = grilla_deuda.Rows(i).Cells(3).Value.ToString
                VarSaldo = grilla_deuda.Rows(i).Cells(4).Value.ToString
                VarRut = grilla_deuda.Rows(i).Cells(5).Value.ToString
                VarNombre = grilla_deuda.Rows(i).Cells(6).Value.ToString
                fecha_pago = grilla_deuda.Rows(i).Cells(7).Value.ToString
                fecha_vencimiento = grilla_deuda.Rows(i).Cells(8).Value.ToString

                If fecha_pago.Length > 10 Then
                    fecha_pago = fecha_pago.Substring(0, 10)
                End If

                If fecha_vencimiento.Length > 10 Then
                    fecha_vencimiento = fecha_vencimiento.Substring(0, 10)
                End If

                If fecha_pago <> "01-01-0001" And fecha_vencimiento <> "01-01-0001" Then
                    dtp_pago.Text = fecha_pago
                    dtp_vencimiento.Text = fecha_vencimiento
                    dias = DateDiff(DateInterval.Day, dtp_vencimiento.Value, dtp_pago.Value)
                End If

                If VarSaldo <> 0 Then
                    estado = "EMITIDO"
                Else
                    estado = "PAGADO"
                End If

                If fecha_pago = "01-01-0001" Then
                    fecha_pago = "-"
                End If

                If fecha_vencimiento = "01-01-0001" Then
                    fecha_vencimiento = "-"
                End If

                grilla_deuda_final.Rows.Add(VarDoc, VarNro, VarFecha, VarTotal, VarSaldo, VarRut, VarNombre, estado, fecha_vencimiento, fecha_pago, dias)
            Next

            grilla_deuda_final.Columns(6).Width = 150

            grilla_deuda_final.Columns(5).Visible = True
            grilla_deuda_final.Columns(6).Visible = True

        Else

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion
            SC3.CommandText = "select TIPO, n_creditos, fecha_venta, total, saldo, clientes.rut_cliente, nombre_cliente, historico_creditos.FECHA_PAGO, historico_creditos.fecha_vencimiento  from historico_creditos, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <='" & (mifecha4) & "' and clientes.rut_cliente='" & (txt_rut.Text) & "' and ESTADO <> 'ANULADA' and ESTADO <> 'ANULADO' and historico_creditos.rut_cliente=clientes.rut_cliente group by TIPO, n_creditos order by fecha_venta asc"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)

            DS3.Tables.Add(DT3)
            grilla_deuda.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_deuda_final.Rows.Clear()

            For i = 0 To grilla_deuda.Rows.Count - 1

                VarDoc = grilla_deuda.Rows(i).Cells(0).Value.ToString
                VarNro = grilla_deuda.Rows(i).Cells(1).Value.ToString
                VarFecha = grilla_deuda.Rows(i).Cells(2).Value.ToString
                VarTotal = grilla_deuda.Rows(i).Cells(3).Value.ToString
                VarSaldo = grilla_deuda.Rows(i).Cells(4).Value.ToString
                VarRut = grilla_deuda.Rows(i).Cells(5).Value.ToString
                VarNombre = grilla_deuda.Rows(i).Cells(6).Value.ToString
                fecha_pago = grilla_deuda.Rows(i).Cells(7).Value.ToString
                fecha_vencimiento = grilla_deuda.Rows(i).Cells(8).Value.ToString

                If fecha_pago.Length > 10 Then
                    fecha_pago = fecha_pago.Substring(0, 10)
                End If

                If fecha_vencimiento.Length > 10 Then
                    fecha_vencimiento = fecha_vencimiento.Substring(0, 10)
                End If

                If fecha_pago.Length > 10 Then
                    fecha_pago = fecha_pago.Substring(0, 10)
                End If

                If fecha_vencimiento.Length > 10 Then
                    fecha_vencimiento = fecha_vencimiento.Substring(0, 10)
                End If

                dias = 0

                If fecha_pago <> "01-01-0001" And fecha_vencimiento <> "01-01-0001" Then
                    dtp_pago.Text = fecha_pago
                    dtp_vencimiento.Text = fecha_vencimiento
                    dias = DateDiff(DateInterval.Day, dtp_vencimiento.Value, dtp_pago.Value)
                End If

                If VarSaldo <> 0 Then
                    estado = "EMITIDO"
                Else
                    estado = "PAGADO"
                End If

                If fecha_pago = "01-01-0001" Then
                    fecha_pago = "-"
                End If

                If fecha_vencimiento = "01-01-0001" Then
                    fecha_vencimiento = "-"
                End If

                grilla_deuda_final.Rows.Add(VarDoc, VarNro, VarFecha, VarTotal, VarSaldo, VarRut, VarNombre, estado, fecha_vencimiento, fecha_pago, dias)

            Next

            grilla_deuda_final.Columns(6).Width = 150
            grilla_deuda_final.Columns(5).Visible = False
            grilla_deuda_final.Columns(6).Visible = False

        End If













    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_deuda.DataSource = Nothing
        fecha()
        mostrar_malla()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_deuda_final.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_deuda_final.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_deuda_final.RowCount - 1
            For c As Integer = 0 To grilla_deuda_final.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_deuda_final.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_exportar_excel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
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

    Sub guion()
        Dim rut As String
        Dim guion As String
        rut = txt_rut.Text
        If rut.Length > 2 Then

            guion = rut(rut.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut(rut.Length - 1).ToString()
                rut = Mid(rut, 1, Len(rut) - 1)
                rut = rut & "-" & fin_rut
                txt_rut.Text = rut
            End If
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        grilla_deuda.DataSource = Nothing
    End Sub



    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub


    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub


    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.GotFocus
        txt_rut.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut.KeyPress
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

        txt_nombre.Text = ""
        txt_total.Text = 0
        grilla_deuda_final.Rows.Clear()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            grilla_deuda.DataSource = Nothing
            grilla_deuda_final.Rows.Clear()
            guion()
            mostrar_datos_clientes()

            btn_mostrar.PerformClick()
        End If
    End Sub

    Sub mostrar_datos_clientes()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
        End If
        conexion.Close()
    End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
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

    Private Sub Form_deuda_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()

        dtp_desde.Value = dtp_desde.Value.AddYears(Val(-2))
        grilla_deuda_final.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub


    Sub calcular_totales()

        Dim totalgrilla As Long

        '//Calcular el total

        txt_total.Text = 0
        For i = 0 To grilla_deuda_final.Rows.Count - 1
            totalgrilla = Val(grilla_deuda_final.Rows(i).Cells(4).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total.Text = "0"
        Else
            txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub

    Private Sub grilla_deuda_final_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_deuda_final.CellContentClick

    End Sub

    Private Sub grilla_deuda_final_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_deuda_final.DoubleClick


        'If mirutempresa = "87686300-6" Then
        '    Dim nro_documento As String
        '    Dim tipo_documento As String
        '    Dim rut_documento As String
        '    Dim saldo_documento As String
        '    Dim total_documento As String



        '    nro_documento = grilla_deuda_final.CurrentRow.Cells(1).Value
        '    tipo_documento = grilla_deuda_final.CurrentRow.Cells(0).Value
        '    rut_documento = grilla_deuda_final.CurrentRow.Cells(5).Value
        '    total_documento = grilla_deuda_final.CurrentRow.Cells(3).Value
        '    saldo_documento = grilla_deuda_final.CurrentRow.Cells(4).Value

        '    Dim valormensaje As Integer
        '    valormensaje = MsgBox("¿ESTA SEGURO DE MODIFICAR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

        '    If valormensaje = vbYes Then
        '        If saldo_documento = 0 Then

        '            SC.Connection = conexion
        '            SC.CommandText = "  UPDATE creditos SET saldo='" & (total_documento) & "', estado='EMITIDA' WHERE n_creditos='" & (nro_documento) & "' and TIPO= '" & (tipo_documento) & "' and rut_cliente= '" & (rut_documento) & "'"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)

        '        Else

        '            SC.Connection = conexion
        '            SC.CommandText = "  UPDATE creditos SET saldo='0', estado='PAGADA' WHERE n_creditos='" & (nro_documento) & "' and TIPO= '" & (tipo_documento) & "' and rut_cliente= '" & (rut_documento) & "'"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)

        '        End If

        '        btn_mostrar.PerformClick()
        '    End If
        'End If
    End Sub


End Class