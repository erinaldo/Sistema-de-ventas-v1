Imports System.IO

Imports System.Math
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_comision_servicios
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_comision_servicios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
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
            mostrar_cierre_sistema()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_comision_servicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        Timer_comisiones_servicios.Start()

        dtp_desde.Value = dtp_desde.Value.AddMonths(Val(-1))
        dtp_hasta.Value = dtp_desde.Value
        dtp_hasta.Value = dtp_hasta.Value.AddMonths(Val(+1))
        dtp_desde.Value = "26" & "-" & dtp_desde.Value.Month & "-" & dtp_desde.Value.Year
        dtp_hasta.Value = "25" & "-" & dtp_hasta.Value.Month & "-" & dtp_hasta.Value.Year
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
        grilla_estado_de_cuenta.Rows.Clear()

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
        Dim iva_valor As String
        Dim VarCantidadServicio As Integer
        Dim VarTotalServicio As Integer

        '//Calcular el neto de las facturas
        txt_total.Text = 0
        txt_cantidad.Text = 0
        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            VarCantidadServicio = Val(grilla_estado_de_cuenta.Rows(i).Cells(5).Value.ToString)
            VarTotalServicio = Val(grilla_estado_de_cuenta.Rows(i).Cells(8).Value.ToString)

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
        grilla_estado_de_cuenta.Rows.Clear()
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
        grilla_estado_de_cuenta.Rows.Clear()

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

        If grilla_estado_de_cuenta.Rows.Count = 0 Then
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

    Sub mostrar_malla()
        Dim cadena As String
        Dim tabla() As String
        Dim n As Integer
        Dim consulta_busqueda As String

        grilla_estado_de_cuenta.Rows.Clear()

        'BOLETAS
        consulta_busqueda = "select nombre_usuario as 'USUARIO', detalle_boleta.n_boleta as NUMERO, fecha_venta as FECHA, detalle_boleta.cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, boleta.porcentaje_desc as 'DESCUENTO', detalle_total as TOTAL from boleta, detalle_boleta, usuarios, productos where estado <> 'ANULADA' and detalle_boleta.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <='" & (mifecha4) & "' AND usuario_responsable= usuarios.rut_usuario  AND boleta.n_boleta= detalle_boleta.n_boleta "

        If txt_codigo.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " And detalle_boleta.cod_producto Like '" & (txt_codigo.Text & "%") & "'"
        End If

        If txt_numero_tecnico.Text <> "" Then
            cadena = txt_numero_tecnico.Text
            tabla = Split(cadena, " ")
            For n = 0 To UBound(tabla, 1)
                Dim fin_consulta As String
                fin_consulta = Strings.Right(consulta_busqueda, 5)
                consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ', detalle_boleta.detalle_nombre,  productos.numero_tecnico) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next
        End If

        consulta_busqueda = consulta_busqueda & " GROUP BY detalle_boleta.cod_auto"

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta_busqueda
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim Mi_Fecha_date As Date
                Dim Mi_Fecha_string As String
                Mi_Fecha_date = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                Mi_Fecha_string = Mi_Fecha_date.ToString("dd-MM-yyy")

                grilla_estado_de_cuenta.Rows.Add("SALE",
                                                  DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                                   "BOLETA",
                                                    DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                                     Mi_Fecha_string,
                                                      DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"),
                                                       DS.Tables(DT.TableName).Rows(i).Item("PRECIO"),
                                                        DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"),
                                                         DS.Tables(DT.TableName).Rows(i).Item("TOTAL"))
            Next
        End If

        'FACTURAS
        consulta_busqueda = "select nombre_usuario as 'USUARIO', detalle_factura.n_factura as NUMERO, fecha_venta as FECHA, detalle_factura.cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, factura.porcentaje_desc as 'DESCUENTO', detalle_total as TOTAL   from factura, detalle_factura, usuarios, productos where estado <> 'ANULADA' and detalle_factura.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <='" & (mifecha4) & "' AND usuario_responsable= usuarios.rut_usuario  AND factura.n_factura = detalle_factura.n_factura "

        If txt_codigo.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " And detalle_factura.cod_producto Like '" & (txt_codigo.Text & "%") & "'"
        End If

        If txt_numero_tecnico.Text <> "" Then
            cadena = txt_numero_tecnico.Text
            tabla = Split(cadena, " ")
            For n = 0 To UBound(tabla, 1)
                Dim fin_consulta As String
                fin_consulta = Strings.Right(consulta_busqueda, 5)
                consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ', detalle_factura.detalle_nombre,  productos.numero_tecnico) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next
        End If

        consulta_busqueda = consulta_busqueda & " GROUP BY detalle_factura.cod_auto"

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta_busqueda
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim Mi_Fecha_date As Date
                Dim Mi_Fecha_string As String
                Mi_Fecha_date = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                Mi_Fecha_string = Mi_Fecha_date.ToString("dd-MM-yyy")

                grilla_estado_de_cuenta.Rows.Add("SALE",
                                                      DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                                       "BOLETA",
                                                        DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                                         Mi_Fecha_string,
                                                          DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"),
                                                           DS.Tables(DT.TableName).Rows(i).Item("PRECIO"),
                                                            DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"),
                                                             DS.Tables(DT.TableName).Rows(i).Item("TOTAL"))
            Next
        End If

        'GUIAS
        consulta_busqueda = "select nombre_usuario as 'USUARIO', detalle_guia.n_guia as NUMERO, fecha_venta as FECHA, detalle_guia.cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, guia.porcentaje_desc as 'DESCUENTO', detalle_total as TOTAL   from guia, detalle_guia, usuarios, productos where estado <> 'ANULADA' and detalle_guia.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <='" & (mifecha4) & "' AND usuario_responsable= usuarios.rut_usuario  AND guia.n_guia = detalle_guia.n_guia "

        If txt_codigo.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " And detalle_guia.cod_producto Like '" & (txt_codigo.Text & "%") & "'"
        End If

        If txt_numero_tecnico.Text <> "" Then
            cadena = txt_numero_tecnico.Text
            tabla = Split(cadena, " ")
            For n = 0 To UBound(tabla, 1)
                Dim fin_consulta As String
                fin_consulta = Strings.Right(consulta_busqueda, 5)
                consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ', detalle_guia.detalle_nombre,  productos.numero_tecnico) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next
        End If

        consulta_busqueda = consulta_busqueda & " GROUP BY detalle_guia.cod_auto"

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta_busqueda
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim Mi_Fecha_date As Date
                Dim Mi_Fecha_string As String
                Mi_Fecha_date = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                Mi_Fecha_string = Mi_Fecha_date.ToString("dd-MM-yyy")

                grilla_estado_de_cuenta.Rows.Add("SALE",
                                                      DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                                       "BOLETA",
                                                        DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                                         Mi_Fecha_string,
                                                          DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"),
                                                           DS.Tables(DT.TableName).Rows(i).Item("PRECIO"),
                                                            DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"),
                                                             DS.Tables(DT.TableName).Rows(i).Item("TOTAL"))
            Next
        End If

        'NOTA DE CREDITO
        consulta_busqueda = "select nombre_usuario as 'USUARIO', nota_credito.n_nota_credito as NUMERO, fecha_venta as FECHA, detalle_nota_credito.cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, nota_credito.porcentaje_desc as 'DESCUENTO', detalle_total as TOTAL   from nota_credito, detalle_nota_credito, usuarios, productos where estado <> 'ANULADA' and detalle_nota_credito.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <='" & (mifecha4) & "' AND usuario_responsable= usuarios.rut_usuario  AND nota_credito.n_nota_credito = detalle_nota_credito.n_nota_credito "

        If txt_codigo.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " And detalle_nota_credito.cod_producto Like '" & (txt_codigo.Text & "%") & "'"
        End If

        If txt_numero_tecnico.Text <> "" Then
            cadena = txt_numero_tecnico.Text
            tabla = Split(cadena, " ")
            For n = 0 To UBound(tabla, 1)
                Dim fin_consulta As String
                fin_consulta = Strings.Right(consulta_busqueda, 5)
                consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ', detalle_nota_credito.detalle_nombre,  productos.numero_tecnico) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next
        End If

        consulta_busqueda = consulta_busqueda & " GROUP BY detalle_nota_credito.cod_auto"

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta_busqueda
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim Mi_Fecha_date As Date
                Dim Mi_Fecha_string As String
                Mi_Fecha_date = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                Mi_Fecha_string = Mi_Fecha_date.ToString("dd-MM-yyy")

                grilla_estado_de_cuenta.Rows.Add("SALE",
                                                      DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                                       "BOLETA",
                                                        DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                                         Mi_Fecha_string,
                                                          DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"),
                                                           DS.Tables(DT.TableName).Rows(i).Item("PRECIO"),
                                                            DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"),
                                                             DS.Tables(DT.TableName).Rows(i).Item("TOTAL"))
            Next
        End If

        'NOTA DE DEBITO
        consulta_busqueda = "select nombre_usuario as 'USUARIO', nota_debito.n_nota_debito as NUMERO, fecha_venta as FECHA, detalle_nota_debito.cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, nota_debito.porcentaje_desc as 'DESCUENTO', detalle_total as TOTAL   from nota_debito, detalle_nota_debito, usuarios, productos where estado <> 'ANULADA' and detalle_nota_debito.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <='" & (mifecha4) & "' AND usuario_responsable= usuarios.rut_usuario  AND nota_debito.n_nota_debito = detalle_nota_debito.n_nota_debito "

        If txt_codigo.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " And detalle_nota_debito.cod_producto Like '" & (txt_codigo.Text & "%") & "'"
        End If

        If txt_numero_tecnico.Text <> "" Then
            cadena = txt_numero_tecnico.Text
            tabla = Split(cadena, " ")
            For n = 0 To UBound(tabla, 1)
                Dim fin_consulta As String
                fin_consulta = Strings.Right(consulta_busqueda, 5)
                consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ', detalle_nota_debito.detalle_nombre,  productos.numero_tecnico) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next
        End If

        consulta_busqueda = consulta_busqueda & " GROUP BY detalle_nota_debito.cod_auto"

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta_busqueda
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim Mi_Fecha_date As Date
                Dim Mi_Fecha_string As String
                Mi_Fecha_date = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                Mi_Fecha_string = Mi_Fecha_date.ToString("dd-MM-yyy")

                grilla_estado_de_cuenta.Rows.Add("SALE",
                                                      DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                                       "BOLETA",
                                                        DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                                         Mi_Fecha_string,
                                                          DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"),
                                                           DS.Tables(DT.TableName).Rows(i).Item("PRECIO"),
                                                            DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"),
                                                             DS.Tables(DT.TableName).Rows(i).Item("TOTAL"))
            Next
        End If

        'VALE DE CAMBIO
        consulta_busqueda = "select nombre_usuario as 'USUARIO', vale_cambio.nro_vale as NUMERO, fecha as FECHA, detalle_vale_cambio.cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, vale_cambio.porcentaje_desc as 'DESCUENTO', detalle_total as TOTAL   from vale_cambio, detalle_vale_cambio, usuarios, productos where estado <> 'ANULADA' and detalle_vale_cambio.cod_producto=productos.cod_producto and fecha >='" & (mifecha2) & "' and fecha <='" & (mifecha4) & "' AND usuario_responsable= usuarios.rut_usuario  AND vale_cambio.nro_vale = detalle_vale_cambio.nro_vale "

        If txt_codigo.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " And detalle_vale_cambio.cod_producto Like '" & (txt_codigo.Text & "%") & "'"
        End If

        If txt_numero_tecnico.Text <> "" Then
            cadena = txt_numero_tecnico.Text
            tabla = Split(cadena, " ")
            For n = 0 To UBound(tabla, 1)
                Dim fin_consulta As String
                fin_consulta = Strings.Right(consulta_busqueda, 5)
                consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ', detalle_vale_cambio.detalle_nombre,  productos.numero_tecnico) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next
        End If

        consulta_busqueda = consulta_busqueda & " GROUP BY detalle_vale_cambio.cod_auto"

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta_busqueda
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim Mi_Fecha_date As Date
                Dim Mi_Fecha_string As String
                Mi_Fecha_date = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                Mi_Fecha_string = Mi_Fecha_date.ToString("dd-MM-yyy")

                grilla_estado_de_cuenta.Rows.Add("SALE",
                                                      DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                                       "BOLETA",
                                                        DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                                         Mi_Fecha_string,
                                                          DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"),
                                                           DS.Tables(DT.TableName).Rows(i).Item("PRECIO"),
                                                            DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"),
                                                             DS.Tables(DT.TableName).Rows(i).Item("TOTAL"))
            Next
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 100 Then
                grilla_estado_de_cuenta.Columns(0).Width = 99
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 100
            End If
        End If

        grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Sub revisar_descuentos()
        Dim VarTipoDoc As String
        Dim VarNroDoc As String
        Dim varDescuento As String
        Dim varPrecio As String
        Dim varPorcentajeDescuento As String = ""

        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            VarTipoDoc = grilla_estado_de_cuenta.Rows(i).Cells(2).Value.ToString
            VarNroDoc = grilla_estado_de_cuenta.Rows(i).Cells(3).Value.ToString
            varPrecio = grilla_estado_de_cuenta.Rows(i).Cells(8).Value.ToString

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

            grilla_estado_de_cuenta.Rows(i).Cells(7).Value = varPorcentajeDescuento

            varDescuento = Val(varPrecio) * Val(varPorcentajeDescuento) / 100
            grilla_estado_de_cuenta.Rows(i).Cells(8).Value = varPrecio - varDescuento
        Next
    End Sub
End Class