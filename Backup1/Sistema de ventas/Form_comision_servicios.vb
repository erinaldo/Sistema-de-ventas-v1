Imports System.IO

Imports System.Math
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_comision_servicios
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_comision_servicios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_comision_servicios_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
            form_Ingreso.Show()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_comision_servicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        Timer_comisiones_servicios.Start()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    Sub fecha2()
        Dim mifecha1 As Date
        mifecha1 = dtp_hasta.Text
        mifecha4 = mifecha1.ToString("yyy-MM-dd")
    End Sub

    'Sub mostrar_malla_total()
    '    If txt_codigo.Text <> "" And txt_numero_tecnico.Text = "" Then
    '        conexion.Close()
    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()
    '        Try
    '            SC.Connection = conexion
    '            SC.CommandText = "select sum(total) as total_venta from detalle_total where detalle_total.cod_producto LIKE '" & (txt_codigo.Text & "%") & "' and fecha >= '" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and estado <> 'ANULADA' AND movimiento='SALE'"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '            DS.Tables.Add(DT)

    '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '                txt_total.Text = DS.Tables(DT.TableName).Rows(0).Item("total_venta")

    '            End If

    '            conexion.Close()

    '        Catch err As InvalidCastException
    '            txt_total.Text = 0
    '            conexion.Close()
    '            Exit Sub
    '        End Try

    '        calcular_totales()



    '        conexion.Close()
    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()
    '        Try
    '            SC.Connection = conexion
    '            SC.CommandText = "select count(detalle_total.cantidad) as cantidad from detalle_total where detalle_total.cod_producto LIKE '" & (txt_codigo.Text & "%") & "' and fecha >= '" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and estado <> 'ANULADA' AND movimiento='SALE'"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '            DS.Tables.Add(DT)

    '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
    '            End If

    '            conexion.Close()

    '        Catch err As InvalidCastException
    '            txt_cantidad.Text = 0
    '            conexion.Close()
    '            Exit Sub
    '        End Try

    '    End If









































    '    If txt_codigo.Text <> "" And txt_numero_tecnico.Text <> "" Then

    '        conexion.Close()
    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()
    '        Try
    '            SC.Connection = conexion
    '            SC.CommandText = "select SUM(total) as total_venta from detalle_total, productos where detalle_total.cod_producto LIKE '" & (txt_codigo.Text & "%") & "' and fecha >= '" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and estado <> 'ANULADA' AND productos.cod_producto=detalle_total.cod_producto and numero_tecnico LIKE '" & ("%" & txt_numero_tecnico.Text & "%") & "'"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '            DS.Tables.Add(DT)

    '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '                txt_total.Text = DS.Tables(DT.TableName).Rows(0).Item("total_venta")
    '            End If

    '            conexion.Close()

    '        Catch err As InvalidCastException
    '            txt_total.Text = 0
    '            conexion.Close()
    '            Exit Sub
    '        End Try


    '        calcular_totales()



    '        conexion.Close()
    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()
    '        Try
    '            SC.Connection = conexion
    '            SC.CommandText = "select count(detalle_total.cantidad) as cantidad from detalle_total, productos where detalle_total.cod_producto LIKE '" & (txt_codigo.Text & "%") & "' and fecha >= '" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and estado <> 'ANULADA' AND productos.cod_producto=detalle_total.cod_producto and numero_tecnico LIKE '" & ("%" & txt_numero_tecnico.Text & "%") & "'"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '            DS.Tables.Add(DT)

    '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
    '            End If

    '            conexion.Close()

    '        Catch err As InvalidCastException
    '            txt_cantidad.Text = 0
    '            conexion.Close()
    '            Exit Sub
    '        End Try
    '    End If



    'End Sub



    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
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



        txt_cantidad.Text = ""
        txt_neto.Text = ""
        txt_iva.Text = ""
        txt_total.Text = ""
        txt_numero_tecnico.Text = ""
        grilla_kardex.DataSource = Nothing

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If txt_codigo.Text = "" Then
                Exit Sub
            End If
            'fecha()
            'fecha2()
            'mostrar_malla()
            'calcular_totales()

            btn_mostrar.PerformClick()
        End If
    End Sub


    Sub calcular_totales()
        'Dim iva As Integer
        'Dim neto As Integer
        Dim iva_valor As String











        Dim VarCantidadServicio As Integer
        Dim VarTotalServicio As Integer



        '//Calcular el neto de las facturas
        txt_total.Text = 0
        txt_cantidad.Text = 0
        For i = 0 To grilla_kardex.Rows.Count - 1
            VarCantidadServicio = Val(grilla_kardex.Rows(i).Cells(5).Value.ToString)
            VarTotalServicio = Val(grilla_kardex.Rows(i).Cells(8).Value.ToString)

            txt_total.Text = Val(txt_total.Text) + Val(VarTotalServicio)

            txt_cantidad.Text = Val((txt_cantidad.Text) + Val(VarCantidadServicio))
        Next






























        iva_valor = valor_iva / 100 + 1

        txt_neto.Text = Round(txt_total.Text / iva_valor)

        txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)

        txt_iva.Text = (txt_total.Text) - (txt_neto.Text)


        If txt_neto.Text = "" Or txt_neto.Text = "0" Then
            txt_neto.Text = "0"
        Else
            txt_neto.Text = Format(Int(txt_neto.Text), "###,###,###")
        End If


        If txt_iva.Text = "" Or txt_iva.Text = "0" Then
            txt_iva.Text = "0"
        Else
            txt_iva.Text = Format(Int(txt_iva.Text), "###,###,###")
        End If


        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total.Text = "0"
        Else
            txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        End If

    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub

    Private Sub txt_numero_tecnico_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.GotFocus
        txt_numero_tecnico.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_numero_tecnico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.LostFocus
        txt_numero_tecnico.BackColor = Color.White
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If txt_codigo.Text = "" Then
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        fecha()
        fecha2()

        mostrar_malla()

        revisar_descuentos()

        calcular_totales()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub


    Sub limpiar()
        txt_cantidad.Text = ""
        txt_codigo.Text = ""
        txt_iva.Text = ""
        txt_neto.Text = ""
        txt_total.Text = ""
        txt_numero_tecnico.Text = ""
        ' grilla_kardex.Rows.Clear()
        grilla_kardex.DataSource = Nothing
        txt_codigo.Focus()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
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

    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")> _
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Public Function GetInactiveTime() As Nullable(Of TimeSpan)
        Dim info As LASTINPUTINFO = New LASTINPUTINFO
        info.cbSize = CUInt(Marshal.SizeOf(info))
        If (GetLastInputInfo(info)) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
        Else
            Return Nothing
        End If
    End Function

    Private Sub Timer_comisiones_servicios_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_comisiones_servicios.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub

    Private Sub GroupBox8_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox8.Enter

    End Sub

    Private Sub txt_numero_tecnico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_tecnico.KeyPress
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



        txt_cantidad.Text = ""
        txt_neto.Text = ""
        txt_iva.Text = ""
        txt_total.Text = ""
        grilla_kardex.DataSource = Nothing

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If txt_codigo.Text = "" Then
                Exit Sub
            End If
            'fecha()
            'fecha2()
            'mostrar_malla()
            'calcular_totales()

            btn_mostrar.PerformClick()
        End If
    End Sub

    Private Sub txt_numero_tecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.TextChanged

    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_kardex.Rows.Count = 0 Then
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
            Exportar_Excel(Me.grilla_kardex, save.FileName)
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
        For c As Integer = 0 To grilla_kardex.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_kardex.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_kardex.RowCount - 1
            For c As Integer = 0 To grilla_kardex.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_kardex.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Sub mostrar_malla()
        Dim consulta_busqueda As String
        If txt_codigo.Text <> "" And txt_numero_tecnico.Text = "" Then
            Dim DT1 As New DataTable
            conexion.Close()
            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()
            SC1.Connection = conexion
            'SC1.CommandText = "select movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, n_total as NUMERO, FECHA as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, descuento as DESCUENTO, total as TOTAL from detalle_total, usuarios where estado <> 'ANULADA' and movimiento='SALE' and detalle_total.cod_producto LIKE '" & (txt_codigo.Text & "%") & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND VENDEDOR= USUARIOS.RUT_USUARIO and TIPO <> 'VALE' GROUP BY detalle_total.cod_detalle"
            SC1.CommandText = "select movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, n_total as NUMERO, FECHA as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, descuento as 'DCTO. %', total as TOTAL from detalle_total, usuarios where estado <> 'ANULADA' and movimiento='SALE' and detalle_total.cod_producto LIKE '" & (txt_codigo.Text & "%") & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND VENDEDOR= USUARIOS.RUT_USUARIO and TIPO <> 'VALE' GROUP BY detalle_total.cod_detalle"
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            DS1.Tables.Add(DT1)
            grilla_kardex.DataSource = DS1.Tables(DT1.TableName)
            conexion.Close()
        ElseIf txt_codigo.Text <> "" And txt_numero_tecnico.Text <> "" Then
            Dim DT1 As New DataTable
            conexion.Close()
            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()
            'consulta_busqueda = "select movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, n_total as NUMERO, FECHA as FECHA, detalle_total.cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, descuento as DESCUENTO, total as TOTAL   from detalle_total, usuarios, productos where estado <> 'ANULADA' and movimiento='SALE' and detalle_total.cod_producto=productos.cod_producto and detalle_total.cod_producto LIKE '" & (txt_codigo.Text & "%") & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND VENDEDOR= USUARIOS.RUT_USUARIO "
            consulta_busqueda = "select movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, n_total as NUMERO, FECHA as FECHA, detalle_total.cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, descuento as 'DCTO. %', total as TOTAL   from detalle_total, usuarios, productos where estado <> 'ANULADA' and movimiento='SALE' and detalle_total.cod_producto=productos.cod_producto and detalle_total.cod_producto LIKE '" & (txt_codigo.Text & "%") & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND VENDEDOR= USUARIOS.RUT_USUARIO "
            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer
            cadena = txt_numero_tecnico.Text
            tabla = Split(cadena, " ")
            For n = 0 To UBound(tabla, 1)
                Dim fin_consulta As String
                fin_consulta = Strings.Right(consulta_busqueda, 5)
                consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ', detalle_total.nombre,  productos.numero_tecnico) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next
            consulta_busqueda = consulta_busqueda & "and TIPO <> 'VALE' GROUP BY detalle_total.cod_detalle"
            SC1.Connection = conexion
            SC1.CommandText = consulta_busqueda
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            DS1.Tables.Add(DT1)
            grilla_kardex.DataSource = DS1.Tables(DT1.TableName)
            conexion.Close()
        End If
        grilla_kardex.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_kardex.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_kardex.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_kardex.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_kardex.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Sub revisar_descuentos()
        Dim VarTipoDoc As String
        Dim VarNroDoc As String
        Dim varDescuento As String
        Dim varPrecio As String
        Dim varPorcentajeDescuento As String = ""
        'Exit Sub
        For i = 0 To grilla_kardex.Rows.Count - 1
            VarTipoDoc = grilla_kardex.Rows(i).Cells(2).Value.ToString
            VarNroDoc = grilla_kardex.Rows(i).Cells(3).Value.ToString
            varPrecio = grilla_kardex.Rows(i).Cells(8).Value.ToString

            If VarTipoDoc = "BOLETA" Then
                conexion.Close()
                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()
                SC3.Connection = conexion
                SC3.CommandText = "select * from BOLETA where n_boleta ='" & (VarNroDoc) & "'"
                DA3.SelectCommand = SC3
                DA3.Fill(DT3)
                DS3.Tables.Add(DT3)
                If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                    varPorcentajeDescuento = DS3.Tables(DT3.TableName).Rows(0).Item("porcentaje_desc")
                End If
                conexion.Close()
            End If
            If VarTipoDoc = "BOLETA DE CREDITO" Then
                conexion.Close()
                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()
                SC3.Connection = conexion
                SC3.CommandText = "select * from BOLETA where n_boleta ='" & (VarNroDoc) & "'"
                DA3.SelectCommand = SC3
                DA3.Fill(DT3)
                DS3.Tables.Add(DT3)
                If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                    varPorcentajeDescuento = DS3.Tables(DT3.TableName).Rows(0).Item("porcentaje_desc")
                End If
                conexion.Close()
            End If
            If VarTipoDoc = "FACTURA" Then
                conexion.Close()
                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()
                SC3.Connection = conexion
                SC3.CommandText = "select * from factura where n_factura ='" & (VarNroDoc) & "'"
                DA3.SelectCommand = SC3
                DA3.Fill(DT3)
                DS3.Tables.Add(DT3)
                If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                    varPorcentajeDescuento = DS3.Tables(DT3.TableName).Rows(0).Item("porcentaje_desc")
                End If
                conexion.Close()
            End If
            If VarTipoDoc = "FACTURA DE CREDITO" Then
                conexion.Close()
                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()
                SC3.Connection = conexion
                SC3.CommandText = "select * from factura where n_factura ='" & (VarNroDoc) & "'"
                DA3.SelectCommand = SC3
                DA3.Fill(DT3)
                DS3.Tables.Add(DT3)
                If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                    varPorcentajeDescuento = DS3.Tables(DT3.TableName).Rows(0).Item("porcentaje_desc")
                End If
                conexion.Close()
            End If
            If VarTipoDoc = "GUIA" Then
                conexion.Close()
                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()
                SC3.Connection = conexion
                SC3.CommandText = "select * from guia where n_guia ='" & (VarNroDoc) & "'"
                DA3.SelectCommand = SC3
                DA3.Fill(DT3)
                DS3.Tables.Add(DT3)
                If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                    varPorcentajeDescuento = DS3.Tables(DT3.TableName).Rows(0).Item("porcentaje_desc")
                End If
                conexion.Close()
            End If

            grilla_kardex.Rows(i).Cells(7).Value = varPorcentajeDescuento

            varDescuento = Val(varPrecio) * Val(varPorcentajeDescuento) / 100
            grilla_kardex.Rows(i).Cells(8).Value = varPrecio - varDescuento
        Next
    End Sub


End Class