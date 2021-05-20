Imports System.IO

Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_libro_de_compras
    Dim mifecha2 As String
    Dim mifecha3 As String
    Dim varnumfolio As Integer

    Private Sub Form_libro_de_compras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_libro_de_compras_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        'Dim valormensaje As Integer
        'valormensaje = MsgBox("¿DESEA CERRAR LA PANTALLA SIN GUARDAR CAMBIOS?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CERRAR")
        'If valormensaje = vbNo Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub Form_libro_de_compras_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_libro_de_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        'llenar_combo_rut_proveedor()

        'mifecha = DateTimePicker1.Text
        'mifecha = mifecha.ToString("yyy-MM")
        dtp_tributario.CustomFormat = "MM-yyy"
        dtp3.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.CustomFormat = "yyy-MM-dd"
        dtp_fecha_de_ingreso.CustomFormat = "yyy-MM-dd"
        dtp_emision.CustomFormat = "yyy-MM-dd"
        controles(False, True)
        Timer_inactividad_libro_compra.Start()
        grilla_libro_compras.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)


        grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub guion_rut_proveedor()
        Dim rut_proveedor As String
        Dim guion As String
        rut_proveedor = txt_rut_proveedor.Text
        If rut_proveedor.Length > 2 Then

            guion = rut_proveedor(rut_proveedor.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_proveedor(rut_proveedor.Length - 1).ToString()
                rut_proveedor = Mid(rut_proveedor, 1, Len(rut_proveedor) - 1)
                rut_proveedor = rut_proveedor & "-" & fin_rut
                txt_rut_proveedor.Text = rut_proveedor
            End If
        End If
    End Sub

    Sub limpiar()
        txt_documento.Text = ""
        txt_exentas_total.Text = ""
        txt_folio.Text = ""
        txt_impuesto_especifico.Text = ""
        txt_iva.Text = ""
        txt_iva_total.Text = ""
        txt_neto.Text = ""
        txt_neto_total.Text = ""
        txt_tipo_documento.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_numero_factura.Text = ""
        txt_total_general.Text = ""
        txt_tipo_documento.Text = ""
        Combo_clasificacion_cuenta.Text = ""
        txt_rut_proveedor.Text = ""
        Combo_tipo_documento.Text = ""
        Combo_tipo_factura.Text = ""
        txt_credito_proveedor.Text = ""
        txt_total.Text = ""
        grilla_libro_compras.Rows.Clear()


        txt_exentas_total_millar.Text = ""
        txt_iva_total_millar.Text = ""
        txt_neto_total_millar.Text = ""
        txt_total_general_millar.Text = ""
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a
        btn_limpiar.Enabled = a
        btn_cargar.Enabled = a
        btn_nueva.Enabled = b


        Label1.Enabled = a

        'Panel1.Enabled = a
        GroupBox1.Enabled = a
        GroupBox2.Enabled = a
        GroupBox3.Enabled = a
        GroupBox4.Enabled = a
        GroupBox5.Enabled = a
        GroupBox6.Enabled = a
        GroupBox7.Enabled = a
        GroupBox8.Enabled = a
        GroupBox9.Enabled = a
        GroupBox10.Enabled = a
        GroupBox11.Enabled = a
        ' GroupBox12.Enabled = a
        GroupBox13.Enabled = a


        dtp_emision.Enabled = a
        dtp_tributario.Enabled = a
        txt_total.Enabled = a
        txt_neto.Enabled = a
        txt_iva.Enabled = a
        txt_documento.Enabled = a
        '  txt_exentas_total.Enabled = a
        txt_folio.Enabled = a
        ' txt_impuesto_especifico.Enabled = a
        'txt_iva.Enabled = a
        ' txt_iva_total.Enabled = a
        ' txt_neto.Enabled = a
        txt_folio.Enabled = a
        txt_tipo_documento.Enabled = a

        txt_numero_factura.Enabled = a
        ' txt_total_general.Enabled = a
        txt_tipo_documento.Enabled = a
        Combo_clasificacion_cuenta.Enabled = a
        txt_rut_proveedor.Enabled = a
        Combo_tipo_documento.Enabled = a
        Combo_tipo_factura.Enabled = a
        grilla_libro_compras.Enabled = a

        Check_limpiar.Enabled = a


    End Sub

    Sub crear_folio()
        If txt_folio.Text = "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            Try
                SC.Connection = conexion
                SC.CommandText = "select max(codigo_folio) as codigo_folio from libro_de_compras where periodo_tributario='" & (dtp_tributario.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumfolio = DS.Tables(DT.TableName).Rows(0).Item("codigo_folio")
                    txt_folio.Text = varnumfolio + 1
                End If
            Catch err As InvalidCastException
                txt_folio.Text = 1
            End Try
            conexion.Close()
        End If
    End Sub

    'Sub llenar_combo_rut_proveedor()
    '    Combo_rut_proveedor.Items.Clear()
    '    DS3.Tables.Clear()
    '    DT3.Rows.Clear()
    '    DT3.Columns.Clear()
    '    DS3.Clear()
    '    conexion.Open()

    '    SC3.Connection = conexion
    '    SC3.CommandText = "select * from proveedores"
    '    DA3.SelectCommand = SC3
    '    DA3.Fill(DT3)
    '    DS3.Tables.Add(DT3)

    '    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
    '            Combo_rut_proveedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("rut_PROVEEDOR"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    Sub mostrar_datos_proveedores()
        If txt_rut_proveedor.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
                txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
                txt_credito_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("credito_proveedor")
                txt_numero_factura.Focus()
            Else
                MsgBox("NO SE ENCONTRO EL PROVEEDOR", 0 + 16, "ERROR")
            End If
            conexion.Close()
        End If
    End Sub

    Sub desglose_factura()
        Dim iva As Long
        Dim neto As Long
        Dim total As Long

        If txt_total.Text = "" Then
            txt_total.Text = 0
        End If

        total = txt_total.Text
        neto = (total / 1.19)
        iva = (neto) * 19 / 100

        txt_neto.Text = neto
        txt_iva.Text = iva
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_emision.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    Sub fecha2()
        Dim mifecha As Date
        mifecha = dtp_tributario.Text
        mifecha3 = mifecha.ToString("yyy-MM-dd")
    End Sub

    Sub verificacion_periodo_tribuario()
        Dim fecha_factura As Date
        Dim fecha_periodo As Date
        Dim mes_factura As String
        Dim mes_periodo As String
        Dim año_factura As String
        Dim año_periodo As String
        Dim comparacion_meses As String
        Dim comparacion_años As String

        fecha_factura = dtp_emision.Text
        mifecha2 = fecha_factura.ToString("yyy-MM-dd")

        fecha_periodo = dtp_tributario.Text
        mifecha3 = fecha_periodo.ToString("yyy-MM-dd")

        mes_factura = fecha_factura.ToString("MM")

        mes_periodo = fecha_periodo.ToString("MM")

        año_factura = fecha_factura.ToString("yyy")

        año_periodo = fecha_periodo.ToString("yyy")

        comparacion_meses = Val(mes_periodo) - Val(mes_factura)

        comparacion_años = Val(año_periodo) - Val(año_factura)
    End Sub

    Sub calcular_totales()
        Dim exentogrilla As Long
        Dim netogrilla As Long
        Dim ivagrilla As Long
        Dim totalgrilla As Long


        '//Calcular el exento
        txt_exentas_total.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            exentogrilla = Val(grilla_libro_compras.Rows(i).Cells(9).Value.ToString)
            txt_exentas_total.Text = Val(txt_exentas_total.Text) + Val(exentogrilla)
        Next

        '//Calcular el total neto
        txt_neto_total.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            netogrilla = Val(grilla_libro_compras.Rows(i).Cells(10).Value.ToString)
            txt_neto_total.Text = Val(txt_neto_total.Text) + Val(netogrilla)
        Next

        '//Calcular el total iva
        txt_iva_total.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            ivagrilla = Val(grilla_libro_compras.Rows(i).Cells(11).Value.ToString)
            txt_iva_total.Text = Val(txt_iva_total.Text) + Val(ivagrilla)
        Next

        '//Calcular el total general

        txt_total_general.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            totalgrilla = Val(grilla_libro_compras.Rows(i).Cells(12).Value.ToString)
            txt_total_general.Text = Val(txt_total_general.Text) + Val(totalgrilla)
        Next
















        If txt_exentas_total.Text = "" Or txt_exentas_total.Text = "0" Then
            txt_exentas_total_millar.Text = "0"
        Else
            txt_exentas_total_millar.Text = Format(Int(txt_exentas_total.Text), "###,###,###")
        End If

        If txt_neto_total.Text = "" Or txt_neto_total.Text = "0" Then
            txt_neto_total_millar.Text = "0"
        Else
            txt_neto_total_millar.Text = Format(Int(txt_neto_total.Text), "###,###,###")
        End If

        If txt_iva_total.Text = "" Or txt_iva_total.Text = "0" Then
            txt_iva_total_millar.Text = "0"
        Else
            txt_iva_total_millar.Text = Format(Int(txt_iva_total.Text), "###,###,###")
        End If

        If txt_total_general.Text = "" Or txt_total_general.Text = "0" Then
            txt_total_general_millar.Text = "0"
        Else
            txt_total_general_millar.Text = Format(Int(txt_total_general.Text), "###,###,###")
        End If

    End Sub


    Sub limpiar_datos()
        txt_iva.Text = ""
        txt_neto.Text = ""
        txt_total.Text = ""
        txt_folio.Text = ""
        txt_impuesto_especifico.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_numero_factura.Text = ""
        txt_total.Text = ""
        Combo_clasificacion_cuenta.Text = ""
        Combo_tipo_documento.Text = ""
        txt_rut_proveedor.Text = ""
        Combo_tipo_factura.Text = ""
        txt_documento.Text = ""
        txt_credito_proveedor.Text = ""
    End Sub

    Private Sub txt_rut_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_rut_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_rut_proveedor.BackColor = Color.White
    End Sub


    Private Sub Combo_rut_proveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_datos_proveedores()
        credito_proveedor()
    End Sub

    Private Sub txt_total_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.GotFocus
        txt_total.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_total_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total.KeyPress
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


        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If


        If Combo_tipo_factura.Text = "" Then
            MsgBox("SELECCIONE UN TIPO DE FACTURA", 0 + 16, "ERROR")
            txt_total.Text = ""
            Combo_tipo_factura.Focus()
        End If
    End Sub

    Private Sub txt_total_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.LostFocus
        txt_total.BackColor = Color.White
        'TextBox1.Text = ActiveControl.Name
    End Sub

    Private Sub txt_total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total.TextChanged
        If Combo_tipo_factura.Text = "CON IMP. CORRIENTE" Then
            desglose_factura()
        Else
            txt_neto.Text = ""
            txt_iva.Text = ""
            txt_impuesto_especifico.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Dim numero_factura As String
        Dim rut_proveedor As String


        Dim valor_mes As String
        Dim valor As Integer
        valor_mes = dtp_tributario.Value.Month

        valor = valor_mes
        valor_mes = String.Format("{0:00}", valor)

        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()
        SC2.Connection = conexion
        SC2.CommandText = "select * from control_meses_libro_de_compras where mensual ='" & (valor_mes) & "' and  anual ='" & (dtp_tributario.Value.Year) & "'"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            valor_mes = DS2.Tables(DT2.TableName).Rows(0).Item("estado")
            If valor_mes = "CERRADO" Then
                MsgBox("ESTE MES SE ENCUENTRA CERRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                dtp_tributario.Focus()
                Exit Sub
            End If
        End If










        If Combo_tipo_factura.Text = "" Then
            MsgBox("CAMPO TIPO INGRESO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_tipo_factura.Focus()
            Exit Sub
        End If

        If Combo_tipo_documento.Text = "" Then
            MsgBox("CAMPO TIPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_tipo_documento.Focus()
            Exit Sub
        End If

        If Combo_clasificacion_cuenta.Text = "" Then
            MsgBox("CAMPO CLASIFICACION DE CUENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_clasificacion_cuenta.Focus()
            Exit Sub
        End If

        If txt_rut_proveedor.Text = "" Then
            MsgBox("CAMPO RUT PROVEEDOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_proveedor.Focus()
            Exit Sub
        End If

        If txt_nombre_proveedor.Text = "" Then
            MsgBox("CAMPO NOMBRE PROVEEDOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_proveedor.Focus()
            Exit Sub
        End If

        If txt_numero_factura.Text = "" Then
            MsgBox("CAMPO RUT PROVEEDOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_numero_factura.Focus()
            Exit Sub
        End If

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            MsgBox("CAMPO TOTAL DOC. VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total.Text = ""
            txt_total.Focus()
            Exit Sub
        End If


        If Combo_tipo_factura.Text = "CON IMP. ESPECIFICO" And txt_neto.Text = "" Then
            MsgBox("CAMPO NETO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_neto.Focus()
            Exit Sub
        End If

        If Combo_tipo_factura.Text = "CON IMP. ESPECIFICO" And txt_iva.Text = "" Then
            MsgBox("CAMPO IVA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_iva.Focus()
            Exit Sub

        End If

        If Combo_tipo_factura.Text = "CON IMP. ESPECIFICO" And txt_impuesto_especifico.Text = "" Then
            MsgBox("CAMPO I. ESPECIFICO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_impuesto_especifico.Focus()
            Exit Sub
        End If






        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from libro_de_compras where nro_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "' and  documento = '" & (txt_documento.Text) & "' and  tipo_documento = '" & (txt_tipo_documento.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            MsgBox("ESTA DOCUMENTO YA FUE INGRESADO", 0 + 16, "ERROR")
            If Check_limpiar.Checked = False Then
                limpiar_datos()
                conexion.Close()
                Exit Sub
            Else
                txt_numero_factura.Focus()
                conexion.Close()
                Exit Sub
            End If
        Else
            conexion.Close()
            Consultas_SQL("select * from libro_de_compras where codigo_folio = '" & (txt_folio.Text) & "' and periodo_tributario = '" & (dtp_tributario.Text) & "' and  tipo_documento = '" & (txt_tipo_documento.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                MsgBox("ESTE FOLIO YA FUE INGRESADO EN ESTE PERIODO", 0 + 16, "ERROR")
                If Check_limpiar.Checked = False Then
                    limpiar_datos()
                    conexion.Close()
                    Exit Sub
                Else
                    txt_folio.Focus()
                    conexion.Close()
                    Exit Sub
                End If

            Else



                crear_folio()

                If txt_documento.Text = "NOTA DE CREDITO" Then
                    txt_total.Text = "-" & txt_total.Text
                End If



                If Combo_tipo_factura.Text = "CON IMP. CORRIENTE" And txt_documento.Text <> "NOTA DE CREDITO" Then

                    fecha()
                    fecha2()
                    Dim fecha_factura As Date
                    Dim fecha_periodo As Date
                    Dim mes_factura As String
                    Dim mes_periodo As String
                    Dim año_factura As String
                    Dim año_periodo As String
                    'Dim comparacion_meses As String
                    'Dim comparacion_años As String



                    fecha_factura = dtp_emision.Text
                    mifecha2 = fecha_factura.ToString("yyy-MM-dd")
                    fecha_periodo = dtp_tributario.Text
                    mifecha3 = fecha_periodo.ToString("yyy-MM-dd")
                    mes_factura = fecha_factura.ToString("MM")
                    mes_periodo = fecha_periodo.ToString("MM")
                    año_factura = fecha_factura.ToString("yyy")
                    año_periodo = fecha_periodo.ToString("yyy")


                    Dim meses As String

                    meses = DateDiff("m", mifecha2, Form_menu_principal.dtp_fecha.Text)



                    'comparacion_meses = Val(mes_periodo) - Val(mes_factura)
                    'comparacion_años = Val(año_periodo) - Val(año_factura)
                    If txt_total.Text <> "" And txt_total.Text <> 0 Then

                        If meses <= 3 Then

                            For i = 0 To grilla_libro_compras.Rows.Count - 1
                                numero_factura = Val(grilla_libro_compras.Rows(i).Cells(5).Value.ToString)
                                rut_proveedor = grilla_libro_compras.Rows(i).Cells(8).Value.ToString

                                If numero_factura = txt_numero_factura.Text And rut_proveedor = txt_rut_proveedor.Text Then
                                    grilla_libro_compras.Rows.Remove(grilla_libro_compras.Rows(i))
                                    grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, txt_rut_proveedor.Text, "", txt_neto.Text, txt_iva.Text, txt_total.Text, dtp_vencimiento.Text)

                                    conexion.Close()
                                    DS.Tables.Clear()
                                    DT.Rows.Clear()
                                    DT.Columns.Clear()
                                    DS.Clear()
                                    conexion.Open()

                                    SC.Connection = conexion
                                    SC.CommandText = "delete from libro_de_compras where nro_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "'"
                                    DA.SelectCommand = SC
                                    DA.Fill(DT)

                                    SC.Connection = conexion
                                    SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable, estado, fecha_de_pago, forma_de_pago, detalle_de_pago, fecha_de_ingreso) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (txt_rut_proveedor.Text) & "', '" & ("") & "', '" & (txt_neto.Text) & "', '" & (txt_iva.Text) & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "', 'IMPAGA', '" & (dtp_emision.Text) & "', '-', '-', '" & (dtp_fecha_de_ingreso.Text) & "')"
                                    DA.SelectCommand = SC
                                    DA.Fill(DT)
                                    conexion.Close()




                                    'DS.Tables.Clear()
                                    'DT.Rows.Clear()
                                    'DT.Columns.Clear()
                                    'DS.Clear()
                                    'conexion.Open()

                                    'SC.Connection = conexion
                                    'SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total) values()"
                                    'DA.SelectCommand = SC
                                    'DA.Fill(DT)
                                    'conexion.Close()




                                    If Check_limpiar.Checked = False Then
                                        limpiar_datos()
                                    Else
                                        txt_folio.Text = ""
                                        txt_total.Text = ""
                                        txt_neto.Text = ""
                                        txt_iva.Text = ""
                                        txt_impuesto_especifico.Text = ""
                                        txt_numero_factura.Text = ""
                                        txt_numero_factura.Focus()
                                    End If
                                    calcular_totales()

                                    If Check_limpiar.Checked = True Then
                                        txt_numero_factura.Focus()
                                    Else
                                        Combo_tipo_factura.Focus()
                                    End If
                                    Exit Sub
                                End If
                            Next

                            grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, txt_rut_proveedor.Text, "", txt_neto.Text, txt_iva.Text, txt_total.Text, dtp_vencimiento.Text)

                            conexion.Close()
                            DS.Tables.Clear()
                            DT.Rows.Clear()
                            DT.Columns.Clear()
                            DS.Clear()
                            conexion.Open()

                            SC.Connection = conexion
                            SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable, estado, fecha_de_pago, forma_de_pago, detalle_de_pago, fecha_de_ingreso) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (txt_rut_proveedor.Text) & "','" & ("") & "', '" & (txt_neto.Text) & "', '" & (txt_iva.Text) & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "', 'IMPAGA', '" & (dtp_emision.Text) & "', '-', '-', '" & (dtp_fecha_de_ingreso.Text) & "')"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                            conexion.Close()


                            If Check_limpiar.Checked = False Then
                                limpiar_datos()
                            Else
                                txt_folio.Text = ""
                                txt_total.Text = ""
                                txt_neto.Text = ""
                                txt_iva.Text = ""
                                txt_impuesto_especifico.Text = ""
                                txt_numero_factura.Text = ""
                                txt_numero_factura.Focus()
                            End If
                            calcular_totales()

                            If Check_limpiar.Checked = True Then
                                txt_numero_factura.Focus()
                            Else
                                Combo_tipo_factura.Focus()
                            End If

                        Else

                            For i = 0 To grilla_libro_compras.Rows.Count - 1
                                numero_factura = Val(grilla_libro_compras.Rows(i).Cells(5).Value.ToString)
                                rut_proveedor = grilla_libro_compras.Rows(i).Cells(8).Value.ToString

                                If numero_factura = txt_numero_factura.Text And rut_proveedor = txt_rut_proveedor.Text Then
                                    grilla_libro_compras.Rows.Remove(grilla_libro_compras.Rows(i))
                                    grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, txt_rut_proveedor.Text, txt_iva.Text, txt_neto.Text, "", txt_total.Text, dtp_vencimiento.Text)

                                    conexion.Close()
                                    DS.Tables.Clear()
                                    DT.Rows.Clear()
                                    DT.Columns.Clear()
                                    DS.Clear()
                                    conexion.Open()

                                    SC.Connection = conexion
                                    SC.CommandText = "delete from libro_de_compras where nro_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "'"
                                    DA.SelectCommand = SC
                                    DA.Fill(DT)



                                    SC.Connection = conexion
                                    SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable, estado, fecha_de_pago, forma_de_pago, detalle_de_pago, fecha_de_ingreso) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (txt_rut_proveedor.Text) & "','" & (txt_iva.Text) & "', '" & (txt_neto.Text) & "', '" & ("") & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "', 'IMPAGA', '" & (dtp_emision.Text) & "', '-', '-', '" & (dtp_fecha_de_ingreso.Text) & "')"
                                    DA.SelectCommand = SC
                                    DA.Fill(DT)
                                    conexion.Close()



                                    If Check_limpiar.Checked = False Then
                                        limpiar_datos()
                                    Else
                                        txt_folio.Text = ""
                                        txt_total.Text = ""
                                        txt_neto.Text = ""
                                        txt_iva.Text = ""
                                        txt_impuesto_especifico.Text = ""
                                        txt_numero_factura.Text = ""
                                        txt_numero_factura.Focus()
                                    End If
                                    calcular_totales()

                                    If Check_limpiar.Checked = True Then
                                        txt_numero_factura.Focus()
                                    Else
                                        Combo_tipo_factura.Focus()
                                    End If
                                    Exit Sub
                                End If
                            Next

                            grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, txt_rut_proveedor.Text, txt_iva.Text, txt_neto.Text, "", txt_total.Text, dtp_vencimiento.Text)
                            conexion.Close()
                            DS.Tables.Clear()
                            DT.Rows.Clear()
                            DT.Columns.Clear()
                            DS.Clear()
                            conexion.Open()

                            'SC.Connection = conexion
                            'SC.CommandText = "delete from libro_de_compras where numero_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (Combo_rut_proveedor.Text) & "'"
                            'DA.SelectCommand = SC
                            'DA.Fill(DT)

                            SC.Connection = conexion
                            SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable, estado, fecha_de_pago, forma_de_pago, detalle_de_pago, fecha_de_ingreso) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (txt_rut_proveedor.Text) & "','" & (txt_iva.Text) & "', '" & (txt_neto.Text) & "', '" & ("") & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "', 'IMPAGA', '" & (dtp_emision.Text) & "', '-', '-', '" & (dtp_fecha_de_ingreso.Text) & "')"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                            conexion.Close()

                            If Check_limpiar.Checked = False Then
                                limpiar_datos()
                            Else
                                txt_folio.Text = ""
                                txt_total.Text = ""
                                txt_neto.Text = ""
                                txt_iva.Text = ""
                                txt_impuesto_especifico.Text = ""
                                txt_numero_factura.Text = ""
                                txt_numero_factura.Focus()
                            End If
                            calcular_totales()

                            If Check_limpiar.Checked = True Then
                                txt_numero_factura.Focus()
                            Else
                                Combo_tipo_factura.Focus()
                            End If
                        End If
                    End If
                End If




                If Combo_tipo_factura.Text = "CON IMP. CORRIENTE" Then

                    fecha()
                    fecha2()
                    Dim fecha_factura As Date
                    Dim fecha_periodo As Date
                    'Dim mes_factura As String
                    'Dim mes_periodo As String
                    'Dim año_factura As String
                    'Dim año_periodo As String
                    'Dim comparacion_meses As String
                    'Dim comparacion_años As String

                    fecha_factura = dtp_emision.Text
                    mifecha2 = fecha_factura.ToString("yyy-MM-dd")
                    fecha_periodo = dtp_tributario.Text
                    'mifecha3 = fecha_periodo.ToString("yyy-MM-dd")
                    'mes_factura = fecha_factura.ToString("MM")
                    'mes_periodo = fecha_periodo.ToString("MM")
                    'año_factura = fecha_factura.ToString("yyy")
                    'año_periodo = fecha_periodo.ToString("yyy")
                    'comparacion_meses = Val(mes_periodo) - Val(mes_factura)
                    'comparacion_años = Val(año_periodo) - Val(año_factura)
                    If txt_total.Text <> "" And txt_total.Text <> 0 Then
                        'If comparacion_meses <= 3 And comparacion_años = 0 Then

                        For i = 0 To grilla_libro_compras.Rows.Count - 1
                            numero_factura = Val(grilla_libro_compras.Rows(i).Cells(5).Value.ToString)
                            rut_proveedor = grilla_libro_compras.Rows(i).Cells(8).Value.ToString

                            If numero_factura = txt_numero_factura.Text And rut_proveedor = txt_rut_proveedor.Text Then
                                grilla_libro_compras.Rows.Remove(grilla_libro_compras.Rows(i))
                                grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, txt_rut_proveedor.Text, "", txt_neto.Text, txt_iva.Text, txt_total.Text, dtp_vencimiento.Text)

                                conexion.Close()
                                DS.Tables.Clear()
                                DT.Rows.Clear()
                                DT.Columns.Clear()
                                DS.Clear()
                                conexion.Open()

                                SC.Connection = conexion
                                SC.CommandText = "delete from libro_de_compras where nro_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "'"
                                DA.SelectCommand = SC
                                DA.Fill(DT)

                                SC.Connection = conexion
                                SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable, estado, fecha_de_pago, forma_de_pago, detalle_de_pago, fecha_de_ingreso) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (txt_rut_proveedor.Text) & "', '" & ("") & "', '" & (txt_neto.Text) & "', '" & (txt_iva.Text) & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "', 'IMPAGA', '" & (dtp_emision.Text) & "', '-', '-', '" & (dtp_fecha_de_ingreso.Text) & "')"
                                DA.SelectCommand = SC
                                DA.Fill(DT)
                                conexion.Close()




                                'DS.Tables.Clear()
                                'DT.Rows.Clear()
                                'DT.Columns.Clear()
                                'DS.Clear()
                                'conexion.Open()

                                'SC.Connection = conexion
                                'SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total) values()"
                                'DA.SelectCommand = SC
                                'DA.Fill(DT)
                                'conexion.Close()




                                If Check_limpiar.Checked = False Then
                                    limpiar_datos()
                                Else
                                    txt_folio.Text = ""
                                    txt_total.Text = ""
                                    txt_neto.Text = ""
                                    txt_iva.Text = ""
                                    txt_impuesto_especifico.Text = ""
                                    txt_numero_factura.Text = ""
                                    txt_numero_factura.Focus()
                                End If
                                calcular_totales()

                                If Check_limpiar.Checked = True Then
                                    txt_numero_factura.Focus()
                                Else
                                    Combo_tipo_factura.Focus()
                                End If
                                Exit Sub
                            End If
                        Next

                        grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, txt_rut_proveedor.Text, "", txt_neto.Text, txt_iva.Text, txt_total.Text, dtp_vencimiento.Text)

                        conexion.Close()
                        DS.Tables.Clear()
                        DT.Rows.Clear()
                        DT.Columns.Clear()
                        DS.Clear()
                        conexion.Open()

                        SC.Connection = conexion
                        SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable, estado, fecha_de_pago, forma_de_pago, detalle_de_pago, fecha_de_ingreso) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (txt_rut_proveedor.Text) & "','" & ("") & "', '" & (txt_neto.Text) & "', '" & (txt_iva.Text) & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "', 'IMPAGA', '" & (dtp_emision.Text) & "', '-', '-', '" & (dtp_fecha_de_ingreso.Text) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        conexion.Close()


                        If Check_limpiar.Checked = False Then
                            limpiar_datos()
                        Else
                            txt_folio.Text = ""
                            txt_total.Text = ""
                            txt_neto.Text = ""
                            txt_iva.Text = ""
                            txt_impuesto_especifico.Text = ""
                            txt_numero_factura.Text = ""
                            txt_numero_factura.Focus()
                        End If
                        calcular_totales()

                        If Check_limpiar.Checked = True Then
                            txt_numero_factura.Focus()
                        Else
                            Combo_tipo_factura.Focus()
                        End If

                        'Else

                        '    For i = 0 To grilla_libro_compras.Rows.Count - 1
                        '        numero_factura = Val(grilla_libro_compras.Rows(i).Cells(5).Value.ToString)
                        '        rut_proveedor = grilla_libro_compras.Rows(i).Cells(8).Value.ToString

                        '        If numero_factura = txt_numero_factura.Text And rut_proveedor = Combo_rut_proveedor.Text Then
                        '            grilla_libro_compras.Rows.Remove(grilla_libro_compras.Rows(i))
                        '            grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, Combo_rut_proveedor.Text, txt_iva.Text, txt_neto.Text, "", txt_total.Text, dtp_vencimiento.Text)


                        '            DS.Tables.Clear()
                        '            DT.Rows.Clear()
                        '            DT.Columns.Clear()
                        '            DS.Clear()
                        '            conexion.Open()

                        '            SC.Connection = conexion
                        '            SC.CommandText = "delete from libro_de_compras where nro_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (Combo_rut_proveedor.Text) & "'"
                        '            DA.SelectCommand = SC
                        '            DA.Fill(DT)



                        '            SC.Connection = conexion
                        '            SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (Combo_rut_proveedor.Text) & "','" & (txt_iva.Text) & "', '" & (txt_neto.Text) & "', '" & ("") & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "')"
                        '            DA.SelectCommand = SC
                        '            DA.Fill(DT)
                        '            conexion.Close()



                        '            If Check_limpiar.Checked = False Then
                        '                limpiar_datos()
                        '            Else
                        '                txt_folio.Text = ""
                        '                txt_total.Text = ""
                        '                txt_neto.Text = ""
                        '                txt_iva.Text = ""
                        '                txt_impuesto_especifico.Text = ""
                        '                txt_numero_factura.Text = ""
                        '                txt_numero_factura.Focus()
                        '            End If
                        '            calcular_totales()

                        '            If Check_limpiar.Checked = True Then
                        '                txt_numero_factura.Focus()
                        '            Else
                        '                Combo_tipo_factura.Focus()
                        '            End If
                        '            Exit Sub
                        '        End If
                        '    Next

                        '    grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, Combo_rut_proveedor.Text, txt_iva.Text, txt_neto.Text, "", txt_total.Text, dtp_vencimiento.Text)

                        '    DS.Tables.Clear()
                        '    DT.Rows.Clear()
                        '    DT.Columns.Clear()
                        '    DS.Clear()
                        '    conexion.Open()

                        '    'SC.Connection = conexion
                        '    'SC.CommandText = "delete from libro_de_compras where numero_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (Combo_rut_proveedor.Text) & "'"
                        '    'DA.SelectCommand = SC
                        '    'DA.Fill(DT)

                        '    SC.Connection = conexion
                        '    SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (Combo_rut_proveedor.Text) & "','" & (txt_iva.Text) & "', '" & (txt_neto.Text) & "', '" & ("") & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "')"
                        '    DA.SelectCommand = SC
                        '    DA.Fill(DT)
                        '    conexion.Close()

                        '    If Check_limpiar.Checked = False Then
                        '        limpiar_datos()
                        '    Else
                        '        txt_folio.Text = ""
                        '        txt_total.Text = ""
                        '        txt_neto.Text = ""
                        '        txt_iva.Text = ""
                        '        txt_impuesto_especifico.Text = ""
                        '        txt_numero_factura.Text = ""
                        '        txt_numero_factura.Focus()
                        '    End If
                        '    calcular_totales()

                        '    If Check_limpiar.Checked = True Then
                        '        txt_numero_factura.Focus()
                        '    Else
                        '        Combo_tipo_factura.Focus()
                        '    End If
                        ' End If
                    End If
                End If




                If Combo_tipo_factura.Text = "SIN DESGLOSAR" Then

                    fecha()
                    fecha2()

                    If txt_total.Text <> "" And txt_total.Text <> 0 Then

                        For i = 0 To grilla_libro_compras.Rows.Count - 1
                            numero_factura = Val(grilla_libro_compras.Rows(i).Cells(5).Value.ToString)
                            rut_proveedor = grilla_libro_compras.Rows(i).Cells(8).Value.ToString

                            If numero_factura = txt_numero_factura.Text And rut_proveedor = txt_rut_proveedor.Text Then
                                grilla_libro_compras.Rows.Remove(grilla_libro_compras.Rows(i))
                                grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, txt_rut_proveedor.Text, txt_total.Text, "", "", txt_total.Text, dtp_vencimiento.Text)

                                conexion.Close()
                                DS.Tables.Clear()
                                DT.Rows.Clear()
                                DT.Columns.Clear()
                                DS.Clear()
                                conexion.Open()

                                SC.Connection = conexion
                                SC.CommandText = "delete from libro_de_compras where numero_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "'"
                                DA.SelectCommand = SC
                                DA.Fill(DT)

                                SC.Connection = conexion
                                SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable, estado, fecha_de_pago, forma_de_pago, detalle_de_pago, fecha_de_ingreso) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (txt_rut_proveedor.Text) & "', '" & (txt_total.Text) & "', '" & ("") & "', '" & ("") & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "', 'IMPAGA', '" & (dtp_emision.Text) & "', '-', '-', '" & (dtp_fecha_de_ingreso.Text) & "')"
                                DA.SelectCommand = SC
                                DA.Fill(DT)
                                conexion.Close()



                                If Check_limpiar.Checked = False Then
                                    limpiar_datos()
                                Else
                                    txt_folio.Text = ""
                                    txt_total.Text = ""
                                    txt_neto.Text = ""
                                    txt_iva.Text = ""
                                    txt_impuesto_especifico.Text = ""
                                    txt_numero_factura.Text = ""
                                    txt_numero_factura.Focus()
                                End If
                                calcular_totales()

                                If Check_limpiar.Checked = True Then
                                    txt_numero_factura.Focus()
                                Else
                                    Combo_tipo_factura.Focus()
                                End If
                                Exit Sub
                            End If
                        Next

                        grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, txt_rut_proveedor.Text, txt_total.Text, "", "", txt_total.Text, dtp_vencimiento.Text)

                        conexion.Close()
                        DS.Tables.Clear()
                        DT.Rows.Clear()
                        DT.Columns.Clear()
                        DS.Clear()
                        conexion.Open()

                        'SC.Connection = conexion
                        'SC.CommandText = "delete from libro_de_compras where numero_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (Combo_rut_proveedor.Text) & "'"
                        'DA.SelectCommand = SC
                        'DA.Fill(DT)

                        SC.Connection = conexion
                        SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable, estado, fecha_de_pago, forma_de_pago, detalle_de_pago, fecha_de_ingreso) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (txt_rut_proveedor.Text) & "', '" & (txt_total.Text) & "', '" & ("") & "', '" & ("") & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "', 'IMPAGA', '" & (dtp_emision.Text) & "', '-', '-', '" & (dtp_fecha_de_ingreso.Text) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        conexion.Close()

                        If Check_limpiar.Checked = False Then
                            limpiar_datos()
                        Else
                            txt_folio.Text = ""
                            txt_total.Text = ""
                            txt_neto.Text = ""
                            txt_iva.Text = ""
                            txt_impuesto_especifico.Text = ""
                            txt_numero_factura.Text = ""
                            txt_numero_factura.Focus()
                        End If
                        calcular_totales()

                        If Check_limpiar.Checked = True Then
                            txt_numero_factura.Focus()
                        Else
                            Combo_tipo_factura.Focus()
                        End If

                    End If
                End If



                If Combo_tipo_factura.Text = "CON IMP. ESPECIFICO" Then
                    fecha()
                    fecha2()

                    If txt_total.Text <> "" And txt_total.Text <> 0 Then

                        For i = 0 To grilla_libro_compras.Rows.Count - 1
                            numero_factura = Val(grilla_libro_compras.Rows(i).Cells(5).Value.ToString)
                            rut_proveedor = grilla_libro_compras.Rows(i).Cells(8).Value.ToString

                            If numero_factura = txt_numero_factura.Text And rut_proveedor = txt_rut_proveedor.Text Then
                                grilla_libro_compras.Rows.Remove(grilla_libro_compras.Rows(i))
                                grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, txt_rut_proveedor.Text, txt_impuesto_especifico.Text, txt_neto.Text, txt_iva.Text, txt_total.Text, dtp_vencimiento.Text)

                                conexion.Close()
                                DS.Tables.Clear()
                                DT.Rows.Clear()
                                DT.Columns.Clear()
                                DS.Clear()
                                conexion.Open()

                                SC.Connection = conexion
                                SC.CommandText = "delete from libro_de_compras where numero_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (txt_rut_proveedor.Text) & "'"
                                DA.SelectCommand = SC
                                DA.Fill(DT)

                                SC.Connection = conexion
                                SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable, estado, fecha_de_pago, forma_de_pago, detalle_de_pago, fecha_de_ingreso) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (txt_rut_proveedor.Text) & "', '" & (txt_impuesto_especifico.Text) & "',  '" & (txt_neto.Text) & "',  '" & (txt_iva.Text) & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "', 'IMPAGA', '" & (dtp_emision.Text) & "', '-', '-', '" & (dtp_fecha_de_ingreso.Text) & "')"
                                DA.SelectCommand = SC
                                DA.Fill(DT)
                                conexion.Close()



                                If Check_limpiar.Checked = False Then
                                    limpiar_datos()
                                Else
                                    txt_folio.Text = ""
                                    txt_total.Text = ""
                                    txt_neto.Text = ""
                                    txt_iva.Text = ""
                                    txt_impuesto_especifico.Text = ""
                                    txt_numero_factura.Text = ""
                                    txt_numero_factura.Focus()
                                End If
                                calcular_totales()
                                'txt_impuesto_especifico.Enabled = False
                                'txt_iva.Enabled = False
                                'txt_neto.Enabled = False


                                If Check_limpiar.Checked = True Then
                                    txt_numero_factura.Focus()
                                Else
                                    Combo_tipo_factura.Focus()
                                End If
                                Exit Sub
                            End If
                        Next

                        grilla_libro_compras.Rows.Add(txt_folio.Text, dtp_tributario.Text, txt_documento.Text, txt_tipo_documento.Text, mifecha2, txt_numero_factura.Text, Combo_clasificacion_cuenta.Text, txt_nombre_proveedor.Text, txt_rut_proveedor.Text, txt_impuesto_especifico.Text, txt_neto.Text, txt_iva.Text, txt_total.Text, dtp_vencimiento.Text)


                        conexion.Close()
                        DS.Tables.Clear()
                        DT.Rows.Clear()
                        DT.Columns.Clear()
                        DS.Clear()
                        conexion.Open()

                        'SC.Connection = conexion
                        'SC.CommandText = "delete from libro_de_compras where numero_factura = '" & (txt_numero_factura.Text) & "' and rut_proveedor = '" & (Combo_rut_proveedor.Text) & "'"
                        'DA.SelectCommand = SC
                        'DA.Fill(DT)

                        SC.Connection = conexion
                        SC.CommandText = "insert into libro_de_compras (codigo_folio, periodo_tributario, documento, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, rut_proveedor, exentas, neto, iva, total, fecha_vencimiento, usuario_responsable, estado, fecha_de_pago, forma_de_pago, detalle_de_pago, fecha_de_ingreso) values('" & (txt_folio.Text) & "', '" & (dtp_tributario.Text) & "', '" & (txt_documento.Text) & "', '" & (txt_tipo_documento.Text) & "', '" & (mifecha2) & "', '" & (txt_numero_factura.Text) & "', '" & (Combo_clasificacion_cuenta.Text) & "', '" & (txt_rut_proveedor.Text) & "', '" & (txt_impuesto_especifico.Text) & "',  '" & (txt_neto.Text) & "',  '" & (txt_iva.Text) & "', '" & (txt_total.Text) & "', '" & (dtp_vencimiento.Text) & "', '" & (miusuario) & "', 'IMPAGA', '" & (dtp_emision.Text) & "', '-', '-', '" & (dtp_fecha_de_ingreso.Text) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        conexion.Close()


                        If Check_limpiar.Checked = False Then
                            limpiar_datos()
                        Else
                            txt_folio.Text = ""
                            txt_total.Text = ""
                            txt_neto.Text = ""
                            txt_iva.Text = ""
                            txt_impuesto_especifico.Text = ""
                            txt_numero_factura.Text = ""
                            txt_numero_factura.Focus()
                        End If

                        calcular_totales()
                        'txt_impuesto_especifico.Enabled = False
                        'txt_iva.Enabled = False
                        'txt_neto.Enabled = False

                        If Check_limpiar.Checked = True Then
                            txt_numero_factura.Focus()
                        Else
                            Combo_tipo_factura.Focus()
                        End If

                    End If
                End If
            End If
        End If

    End Sub



    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        Dim nro_factura As String
        Dim rut_proveedor As String
        Dim folio As String
        Dim documento As String
        Dim valormensaje As Integer
        Dim mensaje As String = ""

        If grilla_libro_compras.Rows.Count = 0 Then
            MsgBox("SELECCIONE UN DOCUMENTO", 0 + 16, "ERROR")
            Exit Sub
        End If







        Dim valor_mes As String
        'Dim valor As Integer
        Dim valor_anual As String

        valor_mes = grilla_libro_compras.CurrentRow.Cells(1).Value

        'valor = valor_mes
        'valor_mes = String.Format("{0:00}", valor)


        If valor_mes.Length > 2 Then
            valor_mes = valor_mes.Substring(0, 2)
        End If

        valor_anual = grilla_libro_compras.CurrentRow.Cells(1).Value
        valor_anual = Mid(valor_anual, 4, Len(valor_anual) - 3)

        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()
        SC2.Connection = conexion
        SC2.CommandText = "select * from control_meses_libro_de_compras where mensual ='" & (valor_mes) & "' and  anual ='" & (valor_anual) & "'"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            valor_mes = DS2.Tables(DT2.TableName).Rows(0).Item("estado")
            If valor_mes = "CERRADO" Then
                MsgBox("ESTE MES SE ENCUENTRA CERRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                dtp_tributario.Focus()
                Exit Sub
            End If
        End If
















        valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR LA FACTURA SELECCIONADA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

        If valormensaje = vbYes Then

            valormensaje = MsgBox("¿ESTA REALMENTE SEGURO DE ELIMINAR LA FACTURA SELECCIONADA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

            If valormensaje = vbYes Then
                folio = grilla_libro_compras.CurrentRow.Cells(0).Value
                nro_factura = grilla_libro_compras.CurrentRow.Cells(5).Value
                rut_proveedor = grilla_libro_compras.CurrentRow.Cells(8).Value
                documento = grilla_libro_compras.CurrentRow.Cells(2).Value
                If grilla_libro_compras.Rows.Count > 0 Then


                    SC.Connection = conexion
                    SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('LIBRO DE COMPRAS','" & (documento) & "','" & (folio) & "','" & (dtp3.Text) & "','ELIMINACION','" & (miusuario) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "delete from libro_de_compras where nro_factura = '" & (nro_factura) & "' and rut_proveedor = '" & (rut_proveedor) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    conexion.Close()

                    grilla_libro_compras.Rows.Remove(grilla_libro_compras.CurrentRow)
                    calcular_totales()
                    txt_folio.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub btn_agregar_proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        form_registro_proveedores.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txt_numero_factura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_factura.GotFocus
        txt_numero_factura.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_numero_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_factura.KeyPress

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



        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_numero_factura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_factura.LostFocus
        txt_numero_factura.BackColor = Color.White
    End Sub


    Private Sub txt_numero_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_factura.TextChanged

    End Sub

    Private Sub txt_neto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_neto.GotFocus
        txt_neto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_neto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_neto.KeyPress

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



        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_neto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_neto.LostFocus
        txt_neto.BackColor = Color.White
    End Sub

    Private Sub txt_neto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_neto.TextChanged

    End Sub

    Private Sub txt_iva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_iva.GotFocus
        txt_iva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_iva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_iva.KeyPress

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



        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_iva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_iva.LostFocus
        txt_iva.BackColor = Color.White
    End Sub

    Private Sub txt_iva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_iva.TextChanged

    End Sub

    Private Sub grilla_libro_compras_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_libro_compras.CellContentClick

    End Sub

    Private Sub Combo_tipo_factura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo_factura.GotFocus
        Combo_tipo_factura.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_tipo_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_tipo_factura.KeyPress
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


    End Sub

    Private Sub Combo_tipo_factura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo_factura.LostFocus
        Combo_tipo_factura.BackColor = Color.White
    End Sub

    Private Sub Combo_tipo_factura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_tipo_factura.SelectedIndexChanged
        If Combo_tipo_factura.Text = "SIN DESGLOSAR" Then
            txt_impuesto_especifico.Enabled = False
            'txt_neto.Enabled = False
            'txt_iva.Enabled = False
            txt_total.Text = ""
            txt_neto.Text = ""
            txt_iva.Text = ""
            txt_impuesto_especifico.Text = ""
            Exit Sub
        ElseIf Combo_tipo_factura.Text = "CON IMP. ESPECIFICO" Then
            txt_impuesto_especifico.Enabled = True
            'txt_neto.Enabled = True
            'txt_iva.Enabled = True
            txt_total.Text = ""
            txt_neto.Text = ""
            txt_iva.Text = ""
            txt_impuesto_especifico.Text = ""
            Exit Sub
        ElseIf Combo_tipo_factura.Text = "CON IMP. CORRIENTE" Then
            txt_impuesto_especifico.Enabled = False
            'txt_neto.Enabled = False
            'txt_iva.Enabled = False
            txt_total.Text = ""
            txt_neto.Text = ""
            txt_iva.Text = ""
            txt_impuesto_especifico.Text = ""
            desglose_factura()
        End If
    End Sub

    Private Sub Combo_tipo_documento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo_documento.GotFocus
        Combo_tipo_documento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_tipo_documento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_tipo_documento.KeyPress
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


    End Sub

    Private Sub Combo_tipo_documento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo_documento.LostFocus
        Combo_tipo_documento.BackColor = Color.White
    End Sub

    Private Sub Combo_tipo_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_tipo_documento.SelectedIndexChanged

        If Combo_tipo_documento.Text = "FACTURA MANUAL" Then
            txt_documento.Text = "FACTURA"
            txt_tipo_documento.Text = "MANUAL"
        End If

        If Combo_tipo_documento.Text = "FACTURA ELECTRONICA" Then
            txt_documento.Text = "FACTURA"
            txt_tipo_documento.Text = "ELECTRONICA"
        End If

        If Combo_tipo_documento.Text = "NOTA DE CREDITO MANUAL" Then
            txt_documento.Text = "NOTA DE CREDITO"
            txt_tipo_documento.Text = "MANUAL"
        End If

        If Combo_tipo_documento.Text = "NOTA DE CREDITO ELECTRONICA" Then
            txt_documento.Text = "NOTA DE CREDITO"
            txt_tipo_documento.Text = "ELECTRONICA"
        End If
        If Combo_tipo_documento.Text = "NOTA DE DEBITO MANUAL" Then
            txt_documento.Text = "NOTA DE DEBITO"
            txt_tipo_documento.Text = "MANUAL"
        End If

        If Combo_tipo_documento.Text = "NOTA DE DEBITO ELECTRONICA" Then
            txt_documento.Text = "NOTA DE DEBITO"
            txt_tipo_documento.Text = "ELECTRONICA"
        End If

    End Sub

    Private Sub Combo_clasificacion_cuenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_clasificacion_cuenta.GotFocus
        Combo_clasificacion_cuenta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_clasificacion_cuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_clasificacion_cuenta.KeyPress
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


    End Sub

    Private Sub Combo_clasificacion_cuenta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combo_clasificacion_cuenta.KeyUp

    End Sub

    Private Sub Combo_clasificacion_cuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_clasificacion_cuenta.LostFocus
        Combo_clasificacion_cuenta.BackColor = Color.White
    End Sub

    Private Sub Combo_clasificacion_cuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_clasificacion_cuenta.SelectedIndexChanged

    End Sub

    Private Sub dtp1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_emision.GotFocus
        dtp_emision.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_emision.LostFocus
        dtp_emision.BackColor = Color.White
    End Sub

    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_emision.ValueChanged
        credito_proveedor()
    End Sub


    Sub credito_proveedor()
        dtp_vencimiento.Value = dtp_emision.Value.AddDays(Val(txt_credito_proveedor.Text))
    End Sub

    Private Sub txt_impuesto_especifico_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_impuesto_especifico.GotFocus
        txt_impuesto_especifico.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_impuesto_especifico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_impuesto_especifico.KeyPress
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


    End Sub

    Private Sub txt_impuesto_especifico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_impuesto_especifico.LostFocus
        txt_impuesto_especifico.BackColor = Color.White
    End Sub

    Private Sub txt_impuesto_especifico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_impuesto_especifico.TextChanged

    End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub






    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub



    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub btn_cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar.Click
        Form_cargar_libro_de_compra.Show()
        '' Me.Enabled = False
        'cargar_libro_de_compras()
        ''  Me.Enabled = True
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        controles(True, False)
        Combo_tipo_factura.Focus()
    End Sub


    'Sub cargar_libro_de_compras()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    SC.CommandText = "select codigo_folio, periodo_tributario,documento, DOCUMENTO, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, nombre_proveedor, libro_de_compras.rut_proveedor, exentas, neto, iva, total, fecha_vencimiento from libro_de_compras, proveedores where periodo_tributario >='" & (dtp1.Text) & "' AND proveedores.rut_proveedor=libro_de_compras.rut_proveedor"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    grilla_libro_compras.Rows.Clear()
    '    grilla_libro_compras.Columns.Clear()
    '    grilla_libro_compras.Columns.Add("codigo_folio", "FOLIO")
    '    grilla_libro_compras.Columns.Add("periodo_tributario", "PERIODO TRIBUTARIO")
    '    grilla_libro_compras.Columns.Add("documento", "DOCUMENTO")
    '    grilla_libro_compras.Columns.Add("_tipo_documento", "TIPO DOCUMENTO")
    '    grilla_libro_compras.Columns.Add("fecha_factura", "FECHA FACT.")
    '    grilla_libro_compras.Columns.Add("nro_factura", "NRO. FACTURA")
    '    grilla_libro_compras.Columns.Add("clasificacion_cuenta", "CLASIFICACION DE CUENTA")
    '    grilla_libro_compras.Columns.Add("nombre_proveedor", "PROVEEDOR")
    '    grilla_libro_compras.Columns.Add("rut_proveedor", "RUT PROVEEDOR")
    '    grilla_libro_compras.Columns.Add("exentas", "EXENTAS")
    '    grilla_libro_compras.Columns.Add("neto", "NETO")
    '    grilla_libro_compras.Columns.Add("iva", "IVA")
    '    grilla_libro_compras.Columns.Add("total", "TOTAL COMPRAS")
    '    grilla_libro_compras.Columns.Add("fecha_vencimiento", "VENCIMIENTO")
    '    'Form_libro_de_compras.grilla_libro_compras.Columns(13).Visible = False
    '    grilla_libro_compras.Columns(0).Visible = True
    '    grilla_libro_compras.Columns(1).Visible = True
    '    grilla_libro_compras.Columns(2).Visible = True
    '    grilla_libro_compras.Columns(3).Visible = True
    '    grilla_libro_compras.Columns(4).Visible = True
    '    grilla_libro_compras.Columns(5).Visible = True
    '    grilla_libro_compras.Columns(6).Visible = True
    '    grilla_libro_compras.Columns(7).Visible = True
    '    grilla_libro_compras.Columns(8).Visible = True
    '    grilla_libro_compras.Columns(9).Visible = True
    '    grilla_libro_compras.Columns(10).Visible = True
    '    grilla_libro_compras.Columns(11).Visible = True
    '    grilla_libro_compras.Columns(12).Visible = True
    '    grilla_libro_compras.Columns(13).Visible = False

    '    'Form_libro_de_compras.grilla_libro_compras.Columns(0).Width = 85

    '    Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_folio"), _
    '                                            DS.Tables(DT.TableName).Rows(i).Item("periodo_tributario"), _
    '                                             DS.Tables(DT.TableName).Rows(i).Item("documento"), _
    '                                              DS.Tables(DT.TableName).Rows(i).Item("tipo_documento"), _
    '                                               DS.Tables(DT.TableName).Rows(i).Item("fecha_factura"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("nro_factura"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("clasificacion_cuenta"), _
    '                                                  DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"), _
    '                                                   DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor"), _
    '                                                    DS.Tables(DT.TableName).Rows(i).Item("exentas"), _
    '                                                     DS.Tables(DT.TableName).Rows(i).Item("neto"), _
    '                                                      DS.Tables(DT.TableName).Rows(i).Item("iva"), _
    '                                                       DS.Tables(DT.TableName).Rows(i).Item("total"), _
    '                                                        DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento"))
    '            'DS.Tables(DT.TableName).Rows(i).Item("costo"))
    '        Next
    '    End If
    'End Sub



    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txt_rut_proveedor_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.GotFocus
        txt_rut_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_proveedor.KeyPress
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



        txt_nombre_proveedor.Text = ""

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_nombre_proveedor.Text = ""
            guion_rut_proveedor()
            mostrar_datos_proveedores()
            credito_proveedor()
        End If
    End Sub

    Private Sub txt_rut_proveedor_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.LostFocus
        txt_rut_proveedor.BackColor = Color.White
    End Sub

    Private Sub txt_rut_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.TextChanged

    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.GotFocus
        btn_nueva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.LostFocus
        btn_nueva.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.GotFocus
        btn_cargar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.LostFocus
        btn_cargar.BackColor = Color.Transparent
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

    Private Sub txt_folio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_folio.TextChanged

    End Sub

    Private Sub txt_folio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_folio.GotFocus
        txt_folio.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_folio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_folio.LostFocus
        txt_folio.BackColor = Color.WhiteSmoke
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

    Private Sub Timer_inactividad_libro_compra_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_inactividad_libro_compra.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub



    Private Sub grilla_libro_compras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_libro_compras.Click

        If grilla_libro_compras.Rows.Count = 0 Then
            Exit Sub
        End If

        txt_folio.Text = grilla_libro_compras.CurrentRow.Cells(0).Value()
        Combo_clasificacion_cuenta.Text = grilla_libro_compras.CurrentRow.Cells(6).Value()
        txt_rut_proveedor.Text = grilla_libro_compras.CurrentRow.Cells(8).Value()
        txt_nombre_proveedor.Text = grilla_libro_compras.CurrentRow.Cells(7).Value()
        txt_numero_factura.Text = grilla_libro_compras.CurrentRow.Cells(5).Value()
        dtp_emision.Text = grilla_libro_compras.CurrentRow.Cells(4).Value()
        dtp_tributario.Text = grilla_libro_compras.CurrentRow.Cells(1).Value()
        txt_total.Text = grilla_libro_compras.CurrentRow.Cells(12).Value()
        txt_neto.Text = grilla_libro_compras.CurrentRow.Cells(10).Value()
        txt_iva.Text = grilla_libro_compras.CurrentRow.Cells(11).Value()
        txt_impuesto_especifico.Text = grilla_libro_compras.CurrentRow.Cells(9).Value()
        Combo_tipo_documento.Text = grilla_libro_compras.CurrentRow.Cells(2).Value() & " " & grilla_libro_compras.CurrentRow.Cells(3).Value()


        If txt_total.Text = "0" Then
            txt_total.Text = ""
        End If

        If txt_neto.Text = "0" Then
            txt_neto.Text = ""
        End If

        If txt_iva.Text = "0" Then
            txt_iva.Text = ""
        End If

        If txt_impuesto_especifico.Text = "0" Then
            txt_impuesto_especifico.Text = ""
        End If

        If txt_total.Text <> "" And txt_neto.Text <> "" And txt_iva.Text <> "" And txt_impuesto_especifico.Text = "" Then
            Combo_tipo_factura.Text = "CON IMP. CORRIENTE"
        End If

        If txt_total.Text <> "" And txt_neto.Text = "" And txt_iva.Text = "" And txt_impuesto_especifico.Text <> "" Then
            Combo_tipo_factura.Text = "SIN DESGLOSAR"
        End If

        If txt_total.Text <> "" And txt_neto.Text <> "" And txt_iva.Text <> "" And txt_impuesto_especifico.Text <> "" Then
            Combo_tipo_factura.Text = "CON IMP. ESPECIFICO"
        End If



        txt_total.Text = grilla_libro_compras.CurrentRow.Cells(12).Value()
        txt_neto.Text = grilla_libro_compras.CurrentRow.Cells(10).Value()
        txt_iva.Text = grilla_libro_compras.CurrentRow.Cells(11).Value()
        txt_impuesto_especifico.Text = grilla_libro_compras.CurrentRow.Cells(9).Value()



        If txt_total.Text = "0" Then
            txt_total.Text = ""
        End If

        If txt_neto.Text = "0" Then
            txt_neto.Text = ""
        End If

        If txt_iva.Text = "0" Then
            txt_iva.Text = ""
        End If

        If txt_impuesto_especifico.Text = "0" Then
            txt_impuesto_especifico.Text = ""
        End If
    End Sub
End Class