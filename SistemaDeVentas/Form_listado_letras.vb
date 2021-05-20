Imports System.IO
Imports System.Drawing.Drawing2D
Public Class Form_listado_letras
    Dim peso As String
    Dim pesos As String
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_listado_letras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_listado_letras_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_listado_letras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        cargar_logo()
        grilla_deudores.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
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
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        fecha()
        SC.Connection = conexion
        ' SC.CommandText = "select n_factura_credito as Numero, factura_credito.rut as RUT, clientes.nombre as Nombre,fecha_venta  as Fecha, descuento as Descuento, neto as Neto, iva as IVA, subtotal Subtotal, total Total, saldo as Saldo from factura_credito,clientes where saldo > 0 and factura_credito.rut=clientes.rut"
        '  SC.CommandText = "select n_CREDITOS as NUMERO,TIPO as TIPO, CREDITOS.rut_CLIENTE as RUT, clientes.nombre_CLIENTE as NOMBRE,fecha_venta  as FECHA,total TOTAL, saldo as SALDO from CREDITOS,clientes where  CREDITOS.ESTADO= 'EMITIDA' and CREDITOS.saldo <> '0' and CREDITOS.rut_CLIENTE=clientes.rut_CLIENTE and  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  order by fecha_venta asc"
        SC.CommandText = "select N_LETRA as 'NRO. LETRA', CANT_LETRAS as 'CANT.',  orden_letras as 'ORDEN', DOC_REFERENCIA as 'DOC.', NRO_REFERENCIA as 'NRO. DOC.', FECHA as 'EMISION', LETRAS.RUT_CLIENTE as 'RUT', CLIENTES.NOMBRE_CLIENTE as 'NOMBRE',  MONTO_LETRA as 'MONTO', FECHA_vencimiento as 'VENCIMIENTO'  from  LETRAS, clientes where LETRAS.rut_cliente=clientes.rut_cliente and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP by n_LETRA order by n_LETRA"
        'SC.CommandText = "select N_CREDITOS as 'NRO. LETRA', CANT_LETRAS as 'CANT.',  orden_letras as 'ORDEN', DOC_REFERENCIA as 'DOC.', NRO_REFERENCIA as 'NRO. DOC.', FECHA as 'EMISION', LETRAS.RUT_CLIENTE as 'RUT', CLIENTES.NOMBRE_CLIENTE as 'NOMBRE',  MONTO_LETRA as 'MONTO', FECHA_vencimiento as 'VENCIMIENTO'  from  letras, creditos, clientes where letras.n_letra=creditos.n_creditos and letras.rut_cliente=clientes.rut_cliente and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP by n_letra order by n_letra"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_deudores.DataSource = DS.Tables(DT.TableName)
        conexion.Close()

        grilla_deudores.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_deudores.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_deudores.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_deudores.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_deudores.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_deudores.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_deudores.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_deudores.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_deudores.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_deudores.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'grilla_deuda.Rows.Clear()
        'Dim VarTotal As String
        'VarTotal = 0

        'Dim VarRut As String
        'Dim varNombre As String
        'Dim VarDireccion As String
        'Dim VarCiudad As String
        'Dim VarTelefono As String
        'Dim VarCuota As String
        'Dim VarCuotas As String
        'Dim VarEmision As String
        'Dim VarVencimiento As String
        'Dim VarSaldo As String

        'Dim VarRutRevision As String

        'For i = 0 To grilla_deudores.Rows.Count - 1

        '    VarRut = grilla_deudores.Rows(i).Cells(0).Value.ToString
        '    varNombre = grilla_deudores.Rows(i).Cells(1).Value.ToString
        '    VarDireccion = grilla_deudores.Rows(i).Cells(2).Value.ToString
        '    VarCiudad = grilla_deudores.Rows(i).Cells(3).Value.ToString
        '    VarTelefono = grilla_deudores.Rows(i).Cells(4).Value.ToString
        '    VarCuota = grilla_deudores.Rows(i).Cells(5).Value.ToString
        '    VarCuotas = grilla_deudores.Rows(i).Cells(6).Value.ToString
        '    VarEmision = grilla_deudores.Rows(i).Cells(7).Value.ToString
        '    VarVencimiento = grilla_deudores.Rows(i).Cells(8).Value.ToString
        '    VarSaldo = grilla_deudores.Rows(i).Cells(9).Value.ToString

        '    VarCuota = grilla_deudores.Rows(i).Cells(5).Value.ToString




        '    Dim codigo As String = 0
        '    Dim valor As Integer
        '    codigo = VarCuota

        '    valor = codigo
        '    VarCuota = String.Format("{0:00}", valor)


        '    Dim codigo2 As String = 0
        '    Dim valor2 As Integer
        '    codigo2 = VarCuotas

        '    valor2 = codigo2
        '    VarCuotas = String.Format("{0:00}", valor2)









        '    VarCuotas = VarCuota & " DE " & VarCuotas

        '    If VarEmision.Length > 10 Then
        '        VarEmision = VarEmision.Substring(0, 10)
        '        Dim mifechaEmision As Date
        '        mifechaEmision = VarEmision
        '        VarEmision = mifechaEmision.ToString("dd-MM-yyy")
        '    End If

        '    If VarVencimiento.Length > 10 Then
        '        VarVencimiento = VarVencimiento.Substring(0, 10)
        '        Dim mifechaVencimiento As Date
        '        mifechaVencimiento = VarVencimiento
        '        VarVencimiento = mifechaVencimiento.ToString("dd-MM-yyy")

        '    End If


        '    If i = "0" Then
        '        VarRutRevision = grilla_deudores.Rows(i).Cells(0).Value.ToString
        '    End If


        '    'If VarRutRevision = "14520084-9" Then
        '    '    MsgBox("FFFFFFFFFF")

        '    'End If


        '    If VarRutRevision = VarRut Then
        '        grilla_deuda.Rows.Add(VarRut, varNombre, VarDireccion, VarCiudad, VarTelefono, VarCuotas, VarEmision, VarVencimiento, VarSaldo)
        '        VarTotal = Val(VarTotal) + Val(VarSaldo)
        '    Else
        '        grilla_deuda.Rows.Add("", "", "", "", "", "", "", "TOTAL", VarTotal)
        '        VarTotal = "0"
        '        grilla_deuda.Rows.Add(VarRut, varNombre, VarDireccion, VarCiudad, VarTelefono, VarCuotas, VarEmision, VarVencimiento, VarSaldo)
        '        VarTotal = Val(VarTotal) + Val(VarSaldo)
        '    End If

        '    VarRutRevision = grilla_deudores.Rows(i).Cells(0).Value.ToString


        'Next

        'grilla_deuda.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grilla_deuda.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grilla_deuda.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grilla_deuda.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ''  grilla_deuda.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'If grilla_deudores.Rows.Count <> "0" Then
        '    '        VarTotal = Val(VarTotal) + Val(VarSaldo)
        '    grilla_deuda.Rows.Add("", "", "", "", "", "", "", "TOTAL", VarTotal)
        'End If



        'If grilla_deuda.Rows.Count <> 0 Then

        '    If grilla_deuda.Columns(0).Width = 100 Then
        '        grilla_deuda.Columns(0).Width = 99
        '    Else
        '        grilla_deuda.Columns(0).Width = 100
        '    End If

        'End If

    End Sub

    'selecciona los clientes con deuda con cuenta abierta.
    Sub mostrar_malla_activos()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        fecha()
        SC.Connection = conexion
        ' SC.CommandText = "select n_factura_credito as Numero, factura_credito.rut as RUT, clientes.nombre as Nombre,fecha_venta  as Fecha, descuento as Descuento, neto as Neto, iva as IVA, subtotal Subtotal, total Total, saldo as Saldo from factura_credito,clientes where saldo > 0 and factura_credito.rut=clientes.rut"
        SC.CommandText = "select n_CREDITOS as NUMERO,TIPO as TIPO, CREDITOS.rut_CLIENTE as RUT, clientes.nombre_CLIENTE as NOMBRE,fecha_venta  as FECHA,total TOTAL, saldo as SALDO from CREDITOS,clientes where  CREDITOS.ESTADO= 'EMITIDA' and CREDITOS.saldo <> '0' and CREDITOS.rut_CLIENTE=clientes.rut_CLIENTE AND CLIENTES.ESTADO_CUENTA='ABIERTA' and  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  order by fecha_venta asc"
        '    SC.CommandText = "select * from creditos  where  rut_cliente = '" & (txt_rut_cliente.Text) & "' and ESTADO= 'EMITIDA'  and saldo <> '0' order by fecha_venta asc,  codigo_afecta asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_deudores.DataSource = DS.Tables(DT.TableName)
        conexion.Close()

        grilla_deudores.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_deudores.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_deudores.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub



    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub


    'selecciona los clientes con cuenta cerrada.
    Sub mostrar_malla_rezagados()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        fecha()
        SC.Connection = conexion
        ' SC.CommandText = "select n_factura_credito as Numero, factura_credito.rut as RUT, clientes.nombre as Nombre,fecha_venta  as Fecha, descuento as Descuento, neto as Neto, iva as IVA, subtotal Subtotal, total Total, saldo as Saldo from factura_credito,clientes where saldo > 0 and factura_credito.rut=clientes.rut"
        SC.CommandText = "select n_CREDITOS as NUMERO,TIPO as TIPO, CREDITOS.rut_CLIENTE as RUT, clientes.nombre_CLIENTE as NOMBRE,fecha_venta  as FECHA,total TOTAL, saldo as SALDO from CREDITOS,clientes where  CREDITOS.ESTADO= 'EMITIDA' and CREDITOS.saldo <> '0' and CREDITOS.rut_CLIENTE=clientes.rut_CLIENTE AND CLIENTES.ESTADO_CUENTA='CERRADA' and  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  order by fecha_venta asc"
        '    SC.CommandText = "select * from creditos  where  rut_cliente = '" & (txt_rut_cliente.Text) & "' and ESTADO= 'EMITIDA'  and saldo <> '0' order by fecha_venta asc,  codigo_afecta asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_deudores.DataSource = DS.Tables(DT.TableName)
        conexion.Close()

        grilla_deudores.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_deudores.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_deudores.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Sub grabar_deudores()
        Dim Varnumero As Integer
        Dim Varrut As String
        Dim Varnombre As String
        Dim varfecha As String
        Dim vardescuento As Integer
        Dim varneto As Integer
        Dim variva As Integer
        Dim varsubtotal As Integer
        Dim vartotal As Integer
        Dim varsaldo As Integer


        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "delete from deudores_temporal"
        DA.SelectCommand = SC
        DA.Fill(DT)

        '  conexion.Close()


        For i = 0 To grilla_deudores.Rows.Count - 1

            Varnumero = grilla_deudores.Rows(i).Cells(0).Value
            Varrut = grilla_deudores.Rows(i).Cells(1).Value.ToString
            Varnombre = grilla_deudores.Rows(i).Cells(2).Value.ToString
            varfecha = grilla_deudores.Rows(i).Cells(3).Value.ToString
            vardescuento = grilla_deudores.Rows(i).Cells(4).Value.ToString
            varneto = grilla_deudores.Rows(i).Cells(5).Value.ToString
            variva = grilla_deudores.Rows(i).Cells(6).Value.ToString
            varsubtotal = grilla_deudores.Rows(i).Cells(7).Value.ToString
            vartotal = grilla_deudores.Rows(i).Cells(8).Value.ToString
            varsaldo = grilla_deudores.Rows(i).Cells(9).Value.ToString

            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'conexion.Open()

            SC.Connection = conexion
            '  SC.CommandText = "insert into deudores_temporal (numero, rut, nombre, fecha,descuento, neto, iva, subtotal, total, saldo, tipo_informe, desglose, total_informe) values('" & (Varnumero) & "','" & (Varrut) & "','" & (Varnombre) & "','" & (varfecha) & "'," & (vardescuento) & ",'" & (varneto) & "'," & (variva) & "," & (varsubtotal) & ",'" & (vartotal) & "'," & (varsaldo) & ",'" & (combo_cuenta.Text) & "','" & (txt_desglose.Text) & "'," & (txt_total_final.Text) & ")"
            '    SC.CommandText = "insert into deudores_temporal (                                                                                                                               numero,              rut,               nombre,         fecha,                 descuento,               neto,           iva,               subtotal,            total,                  saldo,             tipo_informe,               desglose,                    total_informe) values('" & (Varnumero) & "','" & (Varnombre) & "','" & (varfecha) & "'," & (vardescuento) & ",'" & (varneto) & "'," & (variva) & "," & (varsubtotal) & ",'" & (vartotal) & "'," & (varsaldo) & ",'" & (combo_cuenta.Text) & "','" & (txt_desglose.Text) & "'," & (txt_total_final.Text) & ")"


            DA.SelectCommand = SC
            DA.Fill(DT)
            ' conexion.Close()
        Next
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
        For i = 0 To grilla_deudores.Rows.Count - 1
            totalgrilla = Val(grilla_deudores.Rows(i).Cells(8).Value.ToString)
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
        If grilla_deudores.Rows.Count = 0 Then
            dtp_desde.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_deudores, save.FileName)
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
        For c As Integer = 0 To grilla_deudores.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_deudores.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_deudores.RowCount - 1
            For c As Integer = 0 To grilla_deudores.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_deudores.Item(c, r).Value
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
        grilla_deudores.DataSource = Nothing
        grilla_deudores.Rows.Clear()
        txt_total.Text = 0
        txt_total_millar.Text = 0
        'combo_cuenta.SelectedItem = "TODOS"
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False
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