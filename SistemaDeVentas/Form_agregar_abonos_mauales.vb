Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Imports System.Resources
Public Class Form_agregar_abonos_manuales

    Dim total_registros As Integer
    Dim varnumfactura As Integer
    Dim peso As String
    Dim pesos As String
    Dim mifecha2 As String
    Dim alto_cotizacion As String
    Private WithEvents Pd As New PrintDocument
    Dim mifecha_emision2 As String
    Dim mifecha_vencimiento2 As String
    Dim Imagen_propiedad As Byte()
    'Dim impreso As Integer = 0
    Dim impresora_ticket_abonos As String

    Private Sub Form_agregar_abonos_manuales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_agregar_abonos_manuales_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_agregar_abonos_manuales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form_agregar_abonos.Close()


        combo_condiciones.Items.Add("-")
        combo_condiciones.Items.Add("EFECTIVO")
        combo_condiciones.Items.Add("TARJETA DEBITO")
        combo_condiciones.Items.Add("TARJETA CREDITO")
        combo_condiciones.Items.Add("CHEQUE AL DIA")
        combo_condiciones.Items.Add("CHEQUE 30 DIAS")
        combo_condiciones.Items.Add("CHEQUE 30-60 DIAS")
        combo_condiciones.Items.Add("CHEQUE 30-60-90 DIAS")
        combo_condiciones.Items.Add("TRANSFERENCIA")
        combo_condiciones.Items.Add("PENDIENTE")
        combo_condiciones.Items.Add("LETRA")
        combo_condiciones.Items.Add("OTRO MEDIO DE PAGO")
        combo_condiciones.SelectedItem = "-"
        Combo_tipo.Items.Clear()
        Combo_tipo.Items.Add("-")
        Combo_tipo.SelectedItem = "-"
        controles(False, True)
        mostrar_datos_para_pago()
        calcular()
        cargar_logo()
        dtp_emision.CustomFormat = "yyy-MM-dd"
        mostrar_impresora()

        Me.Width = 1024
        Me.Height = 728
        Centrar()
    End Sub

    Public Sub Centrar()
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (tamaño.Width - Me.Width) \ 2
        Dim posicionY As Integer = (tamaño.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_impresora()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from impresoras"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            impresora_ticket_abonos = DS.Tables(DT.TableName).Rows(0).Item("ticket_abonos")
        End If
        conexion.Close()
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_emision.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    'permite bloquear o habilitar los controles.
    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_limpiar.Enabled = a
        btn_guardar.Enabled = a
        btn_cargar.Enabled = a
        btn_quitar_elemento.Enabled = a
        btn_agregar.Enabled = a
        grilla_abono.Enabled = a
        'Check_sin_imputar.Enabled = a
        btn_nuevo.Enabled = b
        txt_rut.Enabled = a

        txt_n_abono.Enabled = a

        ' combo_factura.Enabled = a
        ' Combo_tipo.Enabled = a
        Combo_cuotas.Enabled = a
        btn_limpiar.Enabled = a
        txt_abono.Enabled = a
        'txt_n_abono.Enabled = a
        '   dtp_emision.Enabled = a
        btn_buscar_clientes.Enabled = a
        btn_sugerir.Enabled = a
        combo_condiciones.Enabled = a
        txt_detalle_ingreso.Enabled = a
        GroupBox_condicion.Enabled = a
        GroupBox_detalle.Enabled = a
        GroupBox_documento.Enabled = a
        GroupBox_monto.Enabled = a
        GroupBox_nombre.Enabled = a
        GroupBox_vuelto.Enabled = a
        GroupBox_efectivo.Enabled = a
        GroupBox_total.Enabled = a
        GroupBox_total.Enabled = a
    End Sub

    Sub controles_sin_imputar(ByVal a As Boolean, ByVal b As Boolean)
        combo_factura.Enabled = a
        Combo_tipo.Enabled = a
    End Sub

    'permite mostrar los datos del cliente seleccionado.
    Sub mostrar_datos_clientes()
        If txt_rut.Text <> "" Then
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
            txt_codigo_cliente.Text = ""
            txt_nombre_cliente.Text = ""
            txt_telefono.Text = ""
            txt_direccion.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                ' txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
            End If
            conexion.Close()
        End If
    End Sub

    'mostramos el total y el saldo de la fatura seleccionada.
    Sub mostrar_datos_para_pago()
        combo_factura.Text = ""
        Combo_tipo.Text = ""
        txt_deuda_actual.Text = ""
        txt_fecha.Text = ""
        'txt_tipo.Text = ""
        txt_despues.Text = ""
        txt_vencimiento.Text = ""
        txt_nro_cuota.Text = ""
        txt_total_cuotas.Text = ""
        txt_recinto.Text = ""
        txt_saldo_millar.Text = ""
        txt_abono.Text = ""

        If txt_rut.Text <> "" And Combo_cuotas.Text <> "" And Combo_cuotas.Text <> "-" Then
            Dim tipo_doc As String
            Dim nro_doc As String
            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer
            tipo_doc = ""
            nro_doc = ""

            cadena = Combo_cuotas.Text

            tabla = Split(cadena, " ")
            For n = 0 To UBound(tabla, 1)
                tipo_doc = tabla(0)
                nro_doc = tabla(1)
            Next

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from creditos where TIPO='" & (tipo_doc) & "' and n_creditos='" & (nro_doc) & "' and rut_cliente='" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                combo_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("n_creditos")
                Combo_tipo.Text = DS.Tables(DT.TableName).Rows(0).Item("TIPO")
                txt_deuda_actual.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
                txt_fecha.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                txt_despues.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
                txt_vencimiento.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_vencimiento")
                txt_nro_cuota.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_cuota")
                txt_total_cuotas.Text = DS.Tables(DT.TableName).Rows(0).Item("total_cuotas")
                txt_recinto.Text = DS.Tables(DT.TableName).Rows(0).Item("recinto")
                If txt_deuda_actual.Text = "" Or txt_deuda_actual.Text = "0" Then
                    txt_saldo_millar.Text = "0"
                Else
                    txt_saldo_millar.Text = Format(Int(txt_deuda_actual.Text), "###,###,###")
                End If
                txt_abono.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
            End If
        End If
        conexion.Close()
    End Sub

    'actualizamos la tabla factura de credito, para que muestre los datos del cliente actualizados.
    Sub actualizar_tabla_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select n_creditos from creditos where rut = '" & (txt_rut.Text) & "' and saldo > '0' AND TIPO <> 'NOTA DE CREDITO'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub

    'llenamos el ocmbo facturas segun el rut que este escrito.
    Sub llenar_combo_facturas()
        If txt_rut.Text <> "" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from creditos where saldo <>'0'  and rut_cliente='" & (txt_rut.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                    Combo_cuotas.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("TIPO") & " " & DS2.Tables(DT2.TableName).Rows(i).Item("n_creditos"))
                Next
            End If
            conexion.Close()
        End If
    End Sub

    Sub llenar_combo_doc()
        conexion.Close()
        Combo_tipo.Items.Clear()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select TIPO from creditos  where rut_CLIENTE='" & (txt_rut.Text) & "' and TIPO<>'ABONO' and TIPO <>'NOTA DE CREDITO' group by TIPO"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                Combo_tipo.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("TIPO"))
            Next
        End If
        conexion.Close()
    End Sub

    'permite calcular en lo que quedara la deuda menos lo que se pague.
    Sub calcular()
        Dim bono1 As Integer
        Dim deuda1 As Integer

        If txt_deuda_actual.Text = "" Then
            deuda1 = 0
        Else
            deuda1 = txt_deuda_actual.Text
        End If

        If txt_abono.Text = "" Then
            bono1 = 0
        Else
            bono1 = txt_abono.Text
        End If
        txt_despues.Text = (deuda1) - (bono1)
    End Sub

    'actualiza el saldo en la tabla total y la tabla factura de credito ademas de guardar el registro de los abonos.
    Sub grabar_abono()
        fecha()

        SC.Connection = conexion
        SC.CommandText = "update clientes set saldo_cliente = saldo_cliente + " & (Int(txt_total_abono.Text)) & " where rut_cliente = '" & (txt_rut.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'If grilla_abono.Rows.Count <> 0 Then
        SC.Connection = conexion
            SC.CommandText = "insert into abono (n_abono, tipo, rut_cliente, codigo_cliente, nombre, fecha, monto_abono, usuario_responsable, condicion_abono, detalle_abono, estado, hora) values( '" & (txt_n_abono.Text) & "','ABONO', '" & (txt_rut.Text) & "', '" & (txt_codigo_cliente.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (mifecha2) & "','" & (txt_total_abono.Text) & "','" & (miusuario) & "','" & (combo_condiciones.Text) & "','" & (txt_detalle_ingreso.Text) & "', 'EMITIDO', '" & (Form_menu_principal.lbl_hora.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        'Else

        'End If


        grabar_detalle_abono()
    End Sub

    Sub grabar_detalle_abono()

        Dim VarDocumento As String
        Dim varNroDoc As String
        Dim VarAbono As Integer
        Dim VarSaldo As String
        Dim VarEstado As String
        Dim VarFechaVencimiento As String
        Dim VarNumeroCuotas As String
        Dim total_cuotas As String
        Dim VarRecinto As String

        SC.Connection = conexion
        SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values(" & (txt_n_abono.Text) & ", 'ABONO', '" & (txt_total_abono.Text) & "', '" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (nombre_pc) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        If grilla_abono.Rows.Count <> 0 Then
            For i = 0 To grilla_abono.Rows.Count - 1
                VarDocumento = grilla_abono.Rows(i).Cells(0).Value.ToString
                varNroDoc = grilla_abono.Rows(i).Cells(1).Value.ToString
                VarAbono = grilla_abono.Rows(i).Cells(2).Value.ToString
                VarSaldo = grilla_abono.Rows(i).Cells(3).Value.ToString
                VarEstado = grilla_abono.Rows(i).Cells(4).Value.ToString
                VarFechaVencimiento = grilla_abono.Rows(i).Cells(5).Value.ToString
                VarNumeroCuotas = grilla_abono.Rows(i).Cells(6).Value.ToString
                total_cuotas = grilla_abono.Rows(i).Cells(7).Value.ToString
                VarRecinto = grilla_abono.Rows(i).Cells(8).Value

                Dim mifecha As Date
                mifecha = VarFechaVencimiento
                VarFechaVencimiento = mifecha.ToString("yyy-MM-dd")

                If VarEstado = "SIN INGRESAR" Then

                    SC.Connection = conexion
                    SC.CommandText = "insert into detalle_abono (nro_abono, nro_documento, tipo_documento, monto_abono, saldo_documento, estado, fecha_vencimiento, numero_cuota, total_cuotas, interes, gastos) values('" & (txt_n_abono.Text) & "','" & (varNroDoc) & "', '" & (VarDocumento) & "','" & (VarAbono) & "','" & (VarSaldo) & "','" & (VarEstado) & "','" & (VarFechaVencimiento) & "','" & (VarNumeroCuotas) & "','" & (total_cuotas) & "', '0', '0')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update creditos set saldo = '" & (VarSaldo) & "', fecha_pago='" & (Form_menu_principal.dtp_fecha.Text) & "' where rut_cliente = '" & (txt_rut.Text) & "' and n_creditos ='" & (varNroDoc) & "'  and TIPO ='" & (VarDocumento) & "' and recinto = '" & (VarRecinto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    If VarSaldo = 0 Then
                        SC.Connection = conexion
                        SC.CommandText = "update creditos set estado = 'PAGADA' where rut_cliente = '" & (txt_rut.Text) & "' and CODIGO_AFECTA ='" & (varNroDoc) & "'  and NOMBRE_AFECTA ='" & (VarDocumento) & "'"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO NOMBRE CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_cliente.Focus()
            Exit Sub
        End If

        If txt_n_abono.Text = "" Then
            MsgBox("CAMPO NORO. ABONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_n_abono.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            MsgBox("CAMPO CONDICION DE INGRESO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        'If grilla_abono.Rows.Count = 0 Then
        '    MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    txt_n_abono.Focus()
        '    Exit Sub
        'End If

        conexion.Close()
        Consultas_SQL("select * from abono where n_abono = '" & (txt_n_abono.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            MsgBox("EL NRO. DE ABONO YA FUE INGRESADO", 0 + 16, "ERROR")
            txt_n_abono.Focus()
            Exit Sub
        End If

        fecha()

        Try
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from empresa"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

            Else
                MsgBox("NO HAY CONEXION CON EL SERVIDOR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
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
                Exit Sub
            End If
            conexion.Close()
        Catch
            MsgBox("NO HAY CONEXION CON EL SERVIDOR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
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
            Exit Sub
        End Try

        lbl_mensaje.Visible = True
        Me.Enabled = False

        If txt_detalle_ingreso.Text = "" Then
            txt_detalle_ingreso.Text = "-"
        End If

        With Pd.PrinterSettings
            .PrinterName = impresora_ticket_abonos
            .Copies = 2
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.Pd.PrintController = New StandardPrintController
                'Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)



                Pd.PrinterSettings.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("1", 280, 13000)

                Dim rollo As New PaperSize("New Long Roll", 280, 1900)

                Pd.DefaultPageSettings.PaperSize = rollo





                'Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End With

        lbl_mensaje.Visible = False
        Me.Enabled = True

        grabar_abono()

        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA IMPRIMIR UNA ESTADO DE LA CUENTA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then
            Form_estado_de_cuenta.Show()
            Form_estado_de_cuenta.txt_codigo_cliente.Text = txt_codigo_cliente.Text
            Form_estado_de_cuenta.mostrar_datos_clientes_codigo()
            Form_estado_de_cuenta.mostrar_malla_codigo()

            limpiar()
            controles(False, True)
            Me.Enabled = True

        End If
        If valormensaje = vbNo Then
            limpiar()
            controles(False, True)
            Me.Enabled = True
            MsgBox("ABONO GUARDADO CON EXITO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        End If
    End Sub


    '' carga la informacion de todas las facturas con saldo mayor a 0 del cliente.
    'Sub mostrar_malla()
    '    DS3.Tables.Clear()
    '    DT3.Rows.Clear()
    '    DT3.Columns.Clear()
    '    DS3.Clear()
    '    conexion.Open()
    '    fecha()
    '    SC3.Connection = conexion
    '    SC3.CommandText = "SELECT N_CREDITOS AS NUMERO, TIPO AS TIPO, FECHA_VENTA AS FECHA, NETO AS NETO, IVA AS IVA, TOTAL AS TOTAL, SALDO FROM CREDITOS  WHERE  RUT_CLIENTE = '" & (txt_rut.Text) & "'  AND SALDO > 0 AND TIPO <> 'NOTA DE CREDITO'"


    '    DA3.SelectCommand = SC3
    '    DA3.Fill(DT3)
    '    DS3.Tables.Add(DT3)

    '    migrilla.DataSource = DS3.Tables(DT3.TableName)
    '    conexion.Close()
    '    migrilla.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '    migrilla.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '    migrilla.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '    migrilla.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    'End Sub

    'muestra los datos del cliente seleccionado.
    Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_datos_clientes()
    End Sub

    Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'llenamos el combo factura.
    'llenamos el ocmbo rut.
    'mostramos los datos de los cliente.
    'le damos el valor del combo al texbox.
    Private Sub combo_rut_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        combo_factura.Items.Clear()
        'llenar_combo_facturas()
        llenar_combo_doc()
        ' llenar_combo_rut()
        mostrar_datos_clientes()
        ' combo_rut.Text = combo_rut.SelectedItem
        'mostrar_malla()
        Form_ver_pagos.Close()
        'mostrar_suma()
        'mostrar_deuda()
        'mostrar_malla()
    End Sub

    'limpia los datos de la pantalla.
    Sub limpiar()
        combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        txt_rut.Text = ""
        txt_nombre_cliente.Text = ""
        Combo_tipo.Text = ""
        txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_abono.Text = ""
        txt_total_abono.Text = "0"
        txt_invicible.Text = ""
        txt_despues.Text = "0"
        txt_deuda_actual.Text = "0"
        txt_n_abono.Text = ""
        txt_saldo_millar.Text = ""
        Combo_tipo.Items.Clear()
        Combo_tipo.Items.Add("-")
        Combo_tipo.SelectedItem = "-"
        txt_total_abono_millar.Text = ""
        'txt_deuda_menos_abonos.Text = "0"
        'txt_n_abono.Text = ""
        'Check_sin_imputar.Checked = False

        txt_folio.Text = ""

        combo_factura.Items.Clear()
        grilla_abono.DataSource = Nothing
        grilla_abono.Rows.Clear()
        'txt_deuda_cliente.Text = ""
        dtp_emision.Text = FormatDateTime(Now, DateFormat.ShortDate)
        Me.btn_modificar_abono.Enabled = False
        ' Me.txt_n_abono.Enabled = True
        Me.txt_rut.Enabled = True
        Me.txt_nombre_cliente.Enabled = True
        Me.txt_direccion.Enabled = True
        Me.dtp_emision.Enabled = True
        Me.txt_total_abono.Enabled = True
    End Sub

    Sub limpiar_datos_cliente()

        combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        '  txt_rut.Text = ""
        txt_nombre_cliente.Text = ""
        Combo_tipo.Text = ""
        txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_abono.Text = ""
        txt_total_abono.Text = "0"
        txt_invicible.Text = ""
        txt_despues.Text = "0"
        txt_deuda_actual.Text = "0"
        'txt_deuda_cliente.Text = ""
        'txt_deuda_menos_abonos.Text = "0"
        '  txt_n_abono.Text = ""
        'Check_imputar.Checked = False
        combo_factura.Items.Clear()
        grilla_abono.DataSource = Nothing
        btn_modificar_abono.Enabled = False
        txt_folio.Text = ""
    End Sub

    'limpia los datos de lapantalla.
    Sub limpiar_abono()
        combo_factura.Text = ""
        Combo_tipo.Text = ""
        'txt_deuda.Text = "0"
        txt_invicible.Text = ""
        txt_despues.Text = ""
        txt_deuda_actual.Text = ""
        'txt_deuda_menos_abonos.Text = ""
        txt_abono.Text = ""
        'combo_factura.Items.Clear()
        txt_saldo_millar.Text = ""
        If txt_despues.Text = "0" Then
            txt_despues.Text = ""
        End If
    End Sub

    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut.Text
        If txt_rut.Text.Contains("PROPIEDAD") = False Then
            If rut_cliente.Length > 2 Then

                guion = rut_cliente(rut_cliente.Length - 2).ToString()

                If guion <> "-" Then
                    Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                    rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                    rut_cliente = rut_cliente & "-" & fin_rut
                    txt_rut.Text = rut_cliente
                End If
            End If
        End If
    End Sub

    Private Sub combo_factura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_factura.GotFocus
        combo_factura.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_factura.KeyPress
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

    Private Sub combo_factura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_factura.LostFocus
        combo_factura.BackColor = Color.White
    End Sub

    'llama al sub de los datos para pago.
    Private Sub combo_factura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_factura.SelectedIndexChanged
        mostrar_datos_para_pago()
        txt_abono.Text = ""
        txt_abono.Focus()
    End Sub

    Private Sub txt_abono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_abono.GotFocus
        txt_abono.BackColor = Color.LightSkyBlue
    End Sub

    'llama al sub calcular.
    Private Sub txt_abono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_abono.TextChanged
        calcular()
    End Sub

    'valida el ingreso de solo numeros.
    Private Sub txt_abono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_abono.KeyPress

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

    'llama al sub limpiar.
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
            txt_rut.Focus()
        End If
    End Sub

    'llama al sub controles.
    ' llama al sub limpiar.
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
        controles(True, False)
        txt_rut.Focus()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub





    Private Sub migrilla_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_abono.CellClick

        'Dim numero_doc = migrilla.CurrentRow.Cells(0).Value
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()

        'conexion.Open()

        'SC.Connection = conexion
        'SC.CommandText = "select * from creditos where n_creditos ='" & (numero_doc) & "'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '    Try
        '        combo_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("n_factura_credito")
        '        txt_deuda_menos_abonos.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
        '        'txt_tipo.Text = DS.Tables(DT.TableName).Rows(0).Item("TIPO")
        '        txt_deuda_actual.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        txt_fecha.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
        '        txt_despues.Text = txt_deuda_menos_abonos.Text
        '    Catch
        '    End Try
        'End If
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()

        'SC.Connection = conexion
        'SC.CommandText = "select n_creditos as Numero,TIPO as TIPO, fecha_venta as Fecha, neto as Neto, iva as IVA, total as Total, saldo from creditos  where  rut = '" & (txt_rut.Text) & "'  and saldo > '0' and TIPO <> 'NOTA DE CREDITO'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'migrilla.DataSource = DS.Tables(DT.TableName)
        'conexion.Close()
    End Sub

    Private Sub Combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo.GotFocus
        Combo_tipo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo.LostFocus
        Combo_tipo.BackColor = Color.White
    End Sub

    Private Sub combo_condiciones_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.GotFocus
        combo_condiciones.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_condiciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.LostFocus
        combo_condiciones.BackColor = Color.White
    End Sub

    Private Sub txt_detalle_ingreso_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_detalle_ingreso.GotFocus
        txt_detalle_ingreso.BackColor = Color.LightSkyBlue
    End Sub



    Private Sub txt_detalle_ingreso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_detalle_ingreso.KeyPress

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

    Private Sub txt_detalle_ingreso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_detalle_ingreso.LostFocus
        txt_detalle_ingreso.BackColor = Color.White
    End Sub

    'Private Sub Combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_tipo.SelectedIndexChanged
    '    txt_deuda_actual.Text = ""
    '    txt_saldo_millar.Text = ""
    '    combo_factura.Text = ""
    '    txt_abono.Text = ""

    '    combo_factura.Items.Clear()
    '    llenar_combo_facturas()

    'End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub




    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

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

        combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        Combo_tipo.Text = ""
        txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_abono.Text = ""
        txt_total_abono.Text = "0"
        txt_invicible.Text = ""
        txt_despues.Text = "0"
        txt_deuda_actual.Text = "0"
        'txt_efectivo.Text = ""
        txt_detalle_ingreso.Text = ""
        txt_saldo_millar.Text = ""
        ' Combo_tipo.Items.Clear()
        Combo_tipo.Items.Add("-")
        Combo_tipo.SelectedItem = "-"
        combo_condiciones.SelectedItem = "-"
        txt_total_abono_millar.Text = ""
        ' combo_factura.Items.Clear()
        Combo_cuotas.Items.Clear()
        grilla_abono.Rows.Clear()
        dtp_emision.Text = FormatDateTime(Now, DateFormat.ShortDate)
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            If mirutempresa = "87686300-6" Then
                guion_rut_cliente()
                mostrar_datos_clientes()
                Form_ver_pagos.Close()
                Combo_cuotas.Items.Clear()
                consultar_sucursales()
                Combo_cuotas.Items.Add("-")
                Combo_cuotas.SelectedItem = "-"
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If

            guion_rut_cliente()
            mostrar_datos_clientes()
            Form_ver_pagos.Close()
            Combo_cuotas.Items.Clear()
            llenar_combo_facturas()
            cargar_documentos_vencidos()
            calcular_totales()
            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If
    End Sub



    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub



    Private Sub btn_buscar_clientes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.GotFocus
        btn_buscar_clientes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.LostFocus
        btn_buscar_clientes.BackColor = Color.Transparent
    End Sub


    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.LostFocus
        btn_cargar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.GotFocus
        btn_cargar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_ver_pagos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_ver_pagos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
        ' TextBox1.Text = ActiveControl.Name
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_sugerir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_sugerir.GotFocus
        btn_sugerir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_sugerir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_sugerir.LostFocus
        btn_sugerir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_rut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_clientes_abonos.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged
        grilla_abono.Rows.Clear()
        Combo_cuotas.Items.Clear()
    End Sub

    Private Sub txt_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_abono.LostFocus
        txt_abono.BackColor = Color.White
    End Sub

    Private Sub txt_n_abono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_n_abono.KeyPress

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

    'Private Sub Check_imputar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Check_imputar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub Check_imputar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Check_imputar.BackColor = Color.Transparent
    'End Sub

    Private Sub txt_n_abono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_n_abono.TextChanged

    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click


        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If

        If Combo_tipo.Text = "" Then
            MsgBox("CAMPO TIPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_tipo.Focus()
            Exit Sub
        End If

        If combo_factura.Text = "" Then
            MsgBox("CAMPO NRO. DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_factura.Focus()
            Exit Sub
        End If

        If txt_abono.Text = "" Then
            MsgBox("CAMPO ABONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_abono.Focus()
            Exit Sub
        End If

        If txt_despues.Text = "" Then
            MsgBox("CAMPO SALDO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_despues.Focus()
            Exit Sub
        End If

        If txt_despues.Text < 0 Then
            MsgBox("EL MONTO DEL BONO ES MAYOR AL SALDO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_abono.Focus()
            Exit Sub
        End If


        For i = 0 To grilla_abono.Rows.Count - 1

            Dim tipo_documento As String
            Dim numero_documento As String
            Dim estado As String

            tipo_documento = grilla_abono.Rows(i).Cells(0).Value.ToString
            numero_documento = grilla_abono.Rows(i).Cells(1).Value.ToString
            estado = grilla_abono.Rows(i).Cells(4).Value.ToString

            If tipo_documento = Combo_tipo.Text And numero_documento = combo_factura.Text Then
                grilla_abono.Rows.Remove(grilla_abono.Rows(i))
                grilla_abono.Rows.Add(Combo_tipo.Text, combo_factura.Text, txt_abono.Text, txt_despues.Text, "SIN INGRESAR", txt_vencimiento.Text, txt_nro_cuota.Text, txt_total_cuotas.Text, txt_recinto.Text)
                calcular_totales()
                limpiar_abono()
                revizar_vencimiento()
                Exit Sub
            End If


        Next

        grilla_abono.Rows.Add(Combo_tipo.Text, combo_factura.Text, txt_abono.Text, txt_despues.Text, "SIN INGRESAR", txt_vencimiento.Text, txt_nro_cuota.Text, txt_total_cuotas.Text, txt_recinto.Text)
        calcular_totales()
        limpiar_abono()
        revizar_vencimiento()
    End Sub


    Sub calcular_totales()
        '//Calcular el total general

        Dim totalabono As String
        txt_total_abono.Text = 0
        For i = 0 To grilla_abono.Rows.Count - 1
            totalabono = Val(grilla_abono.Rows(i).Cells(2).Value.ToString)
            txt_total_abono.Text = Val(txt_total_abono.Text) + Val(totalabono)
        Next


        If txt_total_abono.Text = "" Or txt_total_abono.Text = "0" Then
            txt_total_abono_millar.Text = "0"
        Else
            txt_total_abono_millar.Text = Format(Int(txt_total_abono.Text), "###,###,###")
        End If
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        Dim VarEstado As String
        Dim VarNroDocumento As String
        Dim VarTipoDocumento As String
        Dim VarTotalDocumento As String

        If grilla_abono.Rows.Count > 0 Then

            VarEstado = grilla_abono.CurrentRow.Cells(4).Value
            VarNroDocumento = grilla_abono.CurrentRow.Cells(1).Value
            VarTipoDocumento = grilla_abono.CurrentRow.Cells(0).Value
            VarTotalDocumento = grilla_abono.CurrentRow.Cells(2).Value

            If VarEstado = "SIN INGRESAR" Then
                grilla_abono.Rows.Remove(grilla_abono.CurrentRow)
                calcular_totales()
                combo_factura.Focus()
                'Else

                '    Dim valormensaje As Integer
                '    valormensaje = MsgBox("EL ABONO SELECCIONADO YA FUE INGRESADO AL SISTEMA ¿ESTA SEGURO DE ELIMINAR EL MOVIMIENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

                '    If valormensaje = vbYes Then
                '        Dim Var_codigo_producto_eliminar As String
                '        Dim Var_cantidad_producto_eliminar As Integer
                '        Var_codigo_producto_eliminar = grilla_abono.CurrentRow.Cells(0).Value
                '        Var_cantidad_producto_eliminar = grilla_abono.CurrentRow.Cells(2).Value

                '        SC.Connection = conexion
                '        SC.CommandText = "delete from detalle_abono where nro_documento = '" & (VarNroDocumento) & "' and tipo_documento = '" & (VarTipoDocumento) & "' and nro_abono= '" & (txt_n_abono.Text) & "'"
                '        DA.SelectCommand = SC
                '        DA.Fill(DT)

                '        SC.Connection = conexion
                '        SC.CommandText = "update abono set monto_abono = monto_abono - " & (VarTotalDocumento) & " where n_abono = '" & (txt_n_abono.Text) & "'"
                '        DA.SelectCommand = SC
                '        DA.Fill(DT)

                '        SC.Connection = conexion
                '        SC.CommandText = "update creditos set saldo = saldo + " & (VarTotalDocumento) & ",  ESTADO = 'EMITIDA' where rut_cliente = '" & (txt_rut.Text) & "'  and n_creditos ='" & (VarNroDocumento) & "'  and tipo_detalle ='" & (VarTipoDocumento) & "'"
                '        DA.SelectCommand = SC
                '        DA.Fill(DT)

                '        SC.Connection = conexion
                '        SC.CommandText = "delete from creditos where TIPO = 'ABONO' and rut_cliente = '" & (txt_rut.Text) & "' and  codigo_afecta= '" & (VarNroDocumento) & "' and nombre_afecta= '" & (VarTipoDocumento) & "' and n_creditos= '" & (txt_n_abono.Text) & "'"
                '        DA.SelectCommand = SC
                '        DA.Fill(DT)

                '        ' VarTotalDocumento = abs(VarTotalDocumento)

                'grilla_abono.Rows.Remove(grilla_abono.CurrentRow)
                combo_factura.Focus()
            End If
            ' combo_factura.Focus()
        End If
        '  End If
    End Sub

    Private Sub txt_deuda_actual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_deuda_actual.TextChanged

    End Sub


    Private Sub btn_modificar_abono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar_abono.Click
        conexion.Close()
        ' Form_modificar_abonos.combo_documento.Text = Combo_tipo.Text
        Form_modificar_abonos.dtp_emision.Text = dtp_emision.Text
        Form_modificar_abonos.txt_nro_doc.Text = txt_n_abono.Text


        Form_modificar_abonos.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar.Click
        conexion.Close()
        Form_cargar_abono.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub






    Private Sub txt_detalle_ingreso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_detalle_ingreso.TextChanged

    End Sub


    'Private Function ReturnDataSetAbonoTicket() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("ciudad_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nro_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("detalle_referencia", GetType(String)))
    '    dt.Columns.Add(New DataColumn("abono", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("total_abono", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("condicion_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("detalle_condicion_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("cajero_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("titulo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_cliente", GetType(String)))

    '    Dim detalle_referencia As String
    '    Dim detalle_abono As String
    '    Dim detalle_saldo As String
    '    Dim nro_abono As String
    '    Dim fecha_abono As String
    '    Dim rut_abono As String
    '    Dim nombre_abono As String
    '    Dim total_abono As String
    '    Dim condicion_abono As String
    '    Dim detalle_condicion_abono As String
    '    Dim cajero_abono As String

    '    nro_abono = txt_n_abono.Text
    '    fecha_abono = dtp_emision.Text
    '    rut_abono = txt_rut.Text
    '    nombre_abono = txt_nombre_cliente.Text
    '    total_abono = txt_total_abono.Text
    '    condicion_abono = combo_condiciones.Text
    '    detalle_condicion_abono = txt_detalle_ingreso.Text
    '    cajero_abono = minombre

    '    For i = 0 To grilla_abono.Rows.Count - 1
    '        detalle_referencia = grilla_abono.Rows(i).Cells(0).Value.ToString & " NRO. " & grilla_abono.Rows(i).Cells(1).Value.ToString
    '        detalle_abono = grilla_abono.Rows(i).Cells(2).Value.ToString
    '        detalle_saldo = grilla_abono.Rows(i).Cells(3).Value.ToString
    '        dr = dt.NewRow()

    '        If txt_rut.Text.Contains("PROPIEDAD") Then
    '            imagen_inmobiliaria()
    '            Try
    '                dr("Imagen") = Imagen_propiedad
    '            Catch
    '            End Try
    '            dr("nombre_empresa") = "INMOBILIARIA ARANA"
    '            dr("giro_empresa") = "ARRIENDO DE BIENES RAICES"
    '            dr("direccion_empresa") = midireccionempresa
    '            dr("ciudad_empresa") = micomunaempresa
    '            dr("telefono_empresa") = mitelefonoempresa
    '            dr("correo_empresa") = micorreoempresa
    '            dr("rut_empresa") = mirutempresa
    '            dr("direccion_cliente") = txt_direccion.Text
    '        Else
    '            Try
    '                dr("Imagen") = Imagen_ticket
    '            Catch
    '            End Try
    '            dr("nombre_empresa") = minombreempresa
    '            dr("giro_empresa") = migiroempresa
    '            dr("direccion_empresa") = midireccionempresa
    '            dr("ciudad_empresa") = micomunaempresa
    '            dr("telefono_empresa") = mitelefonoempresa
    '            dr("correo_empresa") = micorreoempresa
    '            dr("rut_empresa") = mirutempresa
    '        End If

    '        dr("nro_abono") = nro_abono
    '        dr("fecha_abono") = fecha_abono
    '        dr("nombre_cliente") = nombre_abono
    '        dr("rut_cliente") = rut_abono
    '        dr("detalle_referencia") = detalle_referencia
    '        dr("abono") = detalle_abono
    '        dr("saldo") = detalle_saldo
    '        dr("total_abono") = total_abono
    '        dr("condicion_abono") = condicion_abono
    '        dr("detalle_condicion_abono") = "(" & txt_folio.Text & ") " & detalle_condicion_abono
    '        dr("cajero_abono") = cajero_abono
    '        dr("titulo") = "COMPROBANTE DE INGRESO"
    '        dt.Rows.Add(dr)
    '    Next

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "Abono"
    '    Dim iDS As New dsAbono
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function


    Public Function ImageToByte(ByVal pImagen As Image) As Byte()
        Dim mImage() As Byte
        Try
            If Not IsNothing(pImagen) Then
                Dim ms As New System.IO.MemoryStream
                pImagen.Save(ms, pImagen.RawFormat)
                mImage = ms.GetBuffer
                ms.Close()
                Return mImage
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



    'Sub cargar_documentos()
    '    grilla_abono.Rows.Clear()

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    '  SC.CommandText = "select * from creditos  where rut_CLIENTE='" & (txt_rut.Text) & "' and TIPO <> 'ABONO' and TIPO <> 'NOTA DE CREDITO' and estado= 'EMITIDA'"
    '    SC.CommandText = "select * from creditos  where  rut_cliente = '" & (txt_rut.Text) & "'  and saldo <> '0'  and TIPO <> 'ABONO' and TIPO <> 'NOTA DE CREDITO' order by fecha_venta asc"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    '  Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            '   grilla_detalle_venta.Rows.Clear()
    '            grilla_abono.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
    '                                   DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
    '                                    DS.Tables(DT.TableName).Rows(i).Item("saldo"), _
    '                                     "0", _
    '                                      "SIN INGRESAR")
    '        Next
    '    End If

    '    grilla_abono.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    grilla_abono.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    grilla_abono.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '    calcular_totales()

    'End Sub

    Private Sub grilla_abono_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_abono.CellContentClick

    End Sub

    Private Sub grilla_abono_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_abono.DoubleClick

        If grilla_abono.Rows.Count <> 0 Then
            Combo_tipo.Text = grilla_abono.CurrentRow.Cells(0).Value
            combo_factura.Text = grilla_abono.CurrentRow.Cells(1).Value


            mostrar_datos_para_pago()

            txt_abono.Text = grilla_abono.CurrentRow.Cells(2).Value
            txt_abono.Focus()

        End If


    End Sub

    Private Sub btn_sugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sugerir.Click
        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        grilla_estado_de_cuenta.Rows.Clear()

        'If grilla_abono.Rows.Count = 0 Then
        '    MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    txt_rut.Focus()
        '    Exit Sub
        'End If

        If txt_abono.Text = "" Then
            MsgBox("CAMPO MONTO ABONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_abono.Focus()
            Exit Sub
        End If

        mostrar_malla()

        sugerir_pago()
        calcular_totales()
        revizar_vencimiento()
        txt_despues.Text = "0"

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Sub mostrar_malla()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from creditos  where TIPO NOT LIKE '%ABONO%' and TIPO NOT LIKE '%NOTA DE CREDITO%' and TIPO NOT LIKE '%NOTA DE DEBITO%' and rut_cliente = '" & (txt_rut.Text) & "'  and saldo <> '0' order by fecha_venta asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        ''''''''''''''    grilla_estado_de_cuenta.Rows.Clear()
        'grilla_estado_de_cuenta.Columns.Clear()
        'grilla_estado_de_cuenta.Columns.Add("n_creditos", "NRO.")
        'grilla_estado_de_cuenta.Columns.Add("tipo_detalle", "TIPO")
        'grilla_estado_de_cuenta.Columns.Add("fecha_venta", "FECHA")
        'grilla_estado_de_cuenta.Columns.Add("fecha_vncimiento", "VENCIMIENTO")
        'grilla_estado_de_cuenta.Columns.Add("RECINTO", "RECINTO")
        'grilla_estado_de_cuenta.Columns.Add("total", "TOTAL")
        'grilla_estado_de_cuenta.Columns.Add("saldo", "SALDO")
        'grilla_estado_de_cuenta.Columns.Add("saldo", "SALDO FINAL")

        '  Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_total_deuda.Text = 0
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1


                Dim MiFechaEmision As Date
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")


                Dim MiFechaVencimiento As Date
                MiFechaVencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                mifecha_vencimiento2 = MiFechaVencimiento.ToString("dd-MM-yyy")

                Dim tipo_detalle As String
                tipo_detalle = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")

                If tipo_detalle = "ABONO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE CREDITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE DEBITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"),
                                                  DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                                   mifecha_emision2,
                                                    DS.Tables(DT.TableName).Rows(i).Item("recinto"),
                                                     mifecha_vencimiento2,
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"),
                                                       DS.Tables(DT.TableName).Rows(i).Item("saldo"),
                                                        DS.Tables(DT.TableName).Rows(i).Item("saldo") + Val(txt_total_deuda.Text),
                                                         DS.Tables(DT.TableName).Rows(i).Item("recinto"),
                txt_total_deuda.Text = txt_total_deuda.Text + DS.Tables(DT.TableName).Rows(i).Item("saldo"))
            Next


            'Dim Varcoddocumento As Integer
            'Dim VarTipo As String
            'Dim Varfecha As String
            'Dim VarRecinto As String
            'Dim VarVencimiento As String
            'Dim vartotal As Integer
            'Dim varsaldo As Integer
            ''Dim totalsaldo As Integer
            ''Dim vartotalsaldo As Integer
            'txt_total_deuda.Text = "0"

            'For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

            '    Varcoddocumento = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
            '    VarTipo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
            '    Varfecha = grilla_estado_de_cuenta.Rows(i).Cells(2).Value
            '    VarRecinto = grilla_estado_de_cuenta.Rows(i).Cells(3).Value
            '    VarVencimiento = grilla_estado_de_cuenta.Rows(i).Cells(4).Value
            '    vartotal = grilla_estado_de_cuenta.Rows(i).Cells(5).Value.ToString
            '    varsaldo = grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString


            '    ' For e = 0 To migrilla.Rows.Count - 1

            '    Dim descripcion_tipo As String
            '    descripcion_tipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")

            '    If descripcion_tipo.Length > 15 Then
            '        descripcion_tipo = descripcion_tipo.Substring(0, 15)
            '    End If

            '    If descripcion_tipo = "NOTA DE CREDITO" Then

            '        If VarTipo <> "NOTA DE CREDITO SIN IMPUTAR" Then


            '            VarTipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")


            '            varsaldo = 0
            '        Else
            '            varsaldo = DS.Tables(DT.TableName).Rows(i).Item("saldo")
            '        End If
            '    End If






            '    descripcion_tipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")
            '    If descripcion_tipo.Length > 5 Then
            '        descripcion_tipo = descripcion_tipo.Substring(0, 5)
            '    End If

            '    If descripcion_tipo = "ABONO" Then

            '        If VarTipo <> "ABONO SIN IMPUTAR" Then

            '            VarTipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")





            '            If descripcion_tipo = "ABONO" Then
            '                varsaldo = 0
            '            Else
            '                varsaldo = DS.Tables(DT.TableName).Rows(i).Item("saldo")
            '            End If
            '        End If
            '    End If


            '    txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(DS.Tables(DT.TableName).Rows(i).Item("saldo"))

            '    grilla_estado_de_cuenta_final.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
            '                              DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"), _
            '                               DS.Tables(DT.TableName).Rows(i).Item("fecha_venta"), _
            '                                DS.Tables(DT.TableName).Rows(i).Item("total"), _
            '                                    DS.Tables(DT.TableName).Rows(i).Item("saldo"), _
            'txt_total_deuda.Text)

            'Next



            grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            'grilla_estado_de_cuenta.Columns(0).Width = 10
            'grilla_estado_de_cuenta.Columns(1).Width = 20
            'grilla_estado_de_cuenta.Columns(2).Width = 10
            'grilla_estado_de_cuenta.Columns(3).Width = 10
            'grilla_estado_de_cuenta.Columns(4).Width = 10
            'grilla_estado_de_cuenta.Columns(5).Width = 10
            'grilla_estado_de_cuenta.Columns(6).Width = 10
            'grilla_estado_de_cuenta.Columns(7).Width = 10

            txt_total_deuda.Text = Format(Int(txt_total_deuda.Text), "###,###,###")

        End If

    End Sub

    Sub sugerir_pago()
        Dim VarNroDoc As String
        Dim VarTipoDoc As String
        Dim VarSaldoDoc As String
        Dim VarSucursal As String
        Dim VarAbonoDoc As String
        '  Dim tipo_nota_credito As String

        Dim total_abono As Integer

        grilla_abono.Rows.Clear()

        total_abono = txt_abono.Text

        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

            VarNroDoc = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
            VarTipoDoc = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
            VarSucursal = grilla_estado_de_cuenta.Rows(i).Cells(3).Value.ToString
            VarSaldoDoc = grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString





            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from creditos where n_creditos ='" & (VarNroDoc) & "' AND TIPO ='" & (VarTipoDoc) & "' and rut_cliente='" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_vencimiento.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_vencimiento")
                txt_nro_cuota.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_cuota")
                txt_total_cuotas.Text = DS.Tables(DT.TableName).Rows(0).Item("total_cuotas")
                txt_recinto.Text = DS.Tables(DT.TableName).Rows(0).Item("recinto")
            End If
            conexion.Close()












            If VarTipoDoc = "BOLETA" Or VarTipoDoc = "FACTURA" Or VarTipoDoc = "LETRA" Then
                If VarSaldoDoc <= total_abono Then

                    VarAbonoDoc = VarSaldoDoc

                    grilla_abono.Rows.Add(VarTipoDoc, VarNroDoc, VarAbonoDoc, "0", "SIN INGRESAR", txt_vencimiento.Text, txt_nro_cuota.Text, txt_total_cuotas.Text, txt_recinto.Text)

                    total_abono = total_abono - VarSaldoDoc

                    If total_abono <= 0 Then
                        Exit Sub
                    End If
                Else

                    VarAbonoDoc = total_abono

                    VarSaldoDoc = VarSaldoDoc - total_abono

                    grilla_abono.Rows.Add(VarTipoDoc, VarNroDoc, VarAbonoDoc, VarSaldoDoc, "SIN INGRESAR", txt_vencimiento.Text, txt_nro_cuota.Text, txt_total_cuotas.Text, txt_recinto.Text)

                    Exit Sub

                End If

                calcular_totales()


            End If
        Next
        txt_despues.Text = "0"
        calcular_totales()
        limpiar_abono()

    End Sub


    Private Sub combo_condiciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_condiciones.SelectedIndexChanged
        If combo_condiciones.Text = "OTRO MEDIO DE PAGO" Then
            Form_otro_medio_de_pago_abonos.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.Click
        conexion.Close()
        Me.Enabled = False
        txt_rut.Focus()
        Form_buscador_clientes_abonos.Show()
        Form_buscador_clientes_abonos.txt_busqueda.Focus()
    End Sub

    Private Sub txt_vuelto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_efectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txt_efectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calcular_vuelto()
    End Sub

    Sub calcular_vuelto()
        'If grilla_abono.Rows.Count = 0 Then
        '    txt_vuelto.Text = "0"
        '    Exit Sub
        'End If

        'Dim total As Integer
        'Dim vuelto As Long

        'total = txt_total_abono.Text

        'vuelto = Val(txt_efectivo.Text) - Val(total)

        'If vuelto < 0 Then
        '    txt_vuelto.Text = "0"
        'Else
        '    txt_vuelto.Text = vuelto
        'End If

        'If txt_vuelto.Text = "" Or txt_vuelto.Text = "0" Then
        '    txt_vuelto.Text = "0"
        'Else
        '    txt_vuelto.Text = Format(Int(txt_vuelto.Text), "###,###,###")
        'End If
    End Sub

    Private Sub txt_n_abono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_n_abono.Click
        txt_n_abono.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_n_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_n_abono.Click
        txt_n_abono.BackColor = Color.White
    End Sub

    Private Sub txt_saldo_millar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_saldo_millar.Click
        If txt_deuda_actual.Text <> "" And txt_deuda_actual.Text <> "0" Then
            txt_abono.Text = txt_deuda_actual.Text
            txt_abono.Focus()
        End If
    End Sub

    Private Sub txt_saldo_millar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_saldo_millar.TextChanged




    End Sub











    Sub cargar_documentos_vencidos()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        ' SC.CommandText = "select * from creditos  where TIPO NOT LIKE '%ABONO%' and TIPO NOT LIKE '%NOTA DE CREDITO%' and TIPO NOT LIKE '%NOTA DE DEBITO%' and rut_cliente = '" & (txt_rut.Text) & "' and fecha_vencimiento < '" & (form_Menu_admin.dtp_fecha.Text) & "'  and saldo <> '0' order by fecha_venta asc"
        SC.CommandText = "select * from creditos  where TIPO NOT LIKE '%ABONO%' and TIPO NOT LIKE '%NOTA DE CREDITO%' and TIPO NOT LIKE '%NOTA DE DEBITO%' and rut_cliente = '" & (txt_rut.Text) & "' and saldo <> '0' order by fecha_venta asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        '     grilla_abono.Rows.Clear()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_total_deuda.Text = 0
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaEmision As Date
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                Dim MiFechaVencimiento As Date
                MiFechaVencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                mifecha_vencimiento2 = MiFechaVencimiento.ToString("dd-MM-yyy")

                Dim tipo_detalle As String
                tipo_detalle = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")

                If tipo_detalle = "ABONO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE CREDITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE DEBITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                grilla_abono.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                                 DS.Tables(DT.TableName).Rows(i).Item("n_creditos"),
                                                  DS.Tables(DT.TableName).Rows(i).Item("saldo"),
                                                   "0",
                                                    "SIN INGRESAR",
                                                    mifecha_vencimiento2,
                                                     "1",
                                                      "1",
                                                       DS.Tables(DT.TableName).Rows(i).Item("recinto"))
            Next




        End If




        revizar_vencimiento()

        If grilla_abono.Rows.Count <> 0 Then
            If grilla_abono.Columns(0).Width = 150 Then
                grilla_abono.Columns(0).Width = 149
            Else
                grilla_abono.Columns(0).Width = 150
            End If
            grilla_abono.Columns(1).Width = 150
            grilla_abono.Columns(2).Width = 150
            grilla_abono.Columns(3).Width = 150
            grilla_abono.Columns(4).Width = 150
            grilla_abono.Columns(5).Width = 150
            grilla_abono.Columns(6).Width = 150
            grilla_abono.Columns(7).Width = 150
        End If
    End Sub

    Private Sub Combo_cuotas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_cuotas.SelectedIndexChanged
        mostrar_datos_para_pago()
        txt_abono.Focus()
    End Sub

    Sub revizar_vencimiento()
        Dim mifecha As Date
        Dim vencimiento As String

        For i = 0 To grilla_abono.Rows.Count - 1
            mifecha = grilla_abono.Rows(i).Cells(5).Value.ToString
            vencimiento = mifecha.ToString("yyy-MM-dd")

            If vencimiento < Form_menu_principal.dtp_fecha.Text Then
                grilla_abono.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If
        Next
    End Sub

    Sub consultar_sucursales()
        llenar_combo_facturas()
        cargar_documentos_vencidos()
        calcular_totales()
    End Sub


    Sub imagen_inmobiliaria()


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from imagenes_de_sistema where cod_auto <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            lector = SC.ExecuteReader
            While lector.Read
                Imagen_propiedad = lector("logo_inmobiliaria")
            End While
        End If
        conexion.Close()



    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        If txt_direccion.Text.Length > 23 Then
            txt_direccion.Text = txt_direccion.Text.Substring(0, 23)
        End If

        If txt_rut.Text.Contains("PROPIEDAD") = False Then
            Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
            Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
            Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
            Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
            Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
            Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim margen_izquierdo As Integer
            Dim margen_superior As Integer

            margen_izquierdo = 0
            margen_superior = 0

            Try
                Dim imagen_reporte As Image
                imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
                Dim posicion_imagen As New PointF(margen_izquierdo + 0, margen_superior + 0)
                e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
            Catch
            End Try

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 250, margen_superior + 15)
            Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 250, margen_superior + 15)
            Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 250, margen_superior + 15)
            Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 250, margen_superior + 15)
            Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 250, margen_superior + 15)
            Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 250, margen_superior + 15)
            Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 250, margen_superior + 15)
            Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 250, margen_superior + 15)

            e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
            e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
            e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
            e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
            e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
            e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
            e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

            e.Graphics.DrawString("COMPROBANTE DE INGRESO", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

            e.Graphics.DrawString("NRO. ABONO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 245)
            e.Graphics.DrawString(txt_n_abono.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 245)

            e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 260)
            e.Graphics.DrawString(dtp_emision.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 260)

            e.Graphics.DrawString("NOMBRE CLIENTE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 275)
            e.Graphics.DrawString(txt_nombre_cliente.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 275)

            e.Graphics.DrawString("FORMA DE PAGO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 290)
            e.Graphics.DrawString(combo_condiciones.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 290)

            e.Graphics.DrawString("DETALLE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 305)
            e.Graphics.DrawString(txt_detalle_ingreso.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 305)

            e.Graphics.DrawString("USUARIO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 320)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 320)
            e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 320)

            e.Graphics.DrawString("DIRECCION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 335)
            e.Graphics.DrawString(txt_direccion.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 335)

            e.Graphics.DrawString("DETALLE REFERENCIA", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 370)
            e.Graphics.DrawString("ABONO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 170, margen_superior + 370)
            e.Graphics.DrawString("SALDO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 370, format1)

            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 385, margen_izquierdo + 270, margen_superior + 385)

            Dim detalle_referencia As String
            Dim detalle_abono As String
            Dim detalle_saldo As String
            Dim multiplicador_lineas As Integer = 15
            Dim numero_lineas As Integer = 0

            For i = 0 To grilla_abono.Rows.Count - 1
                detalle_referencia = grilla_abono.Rows(i).Cells(0).Value.ToString & " NRO. " & grilla_abono.Rows(i).Cells(1).Value.ToString
                detalle_abono = grilla_abono.Rows(i).Cells(2).Value.ToString
                detalle_saldo = grilla_abono.Rows(i).Cells(3).Value.ToString

                If detalle_abono = "" Or detalle_abono = "0" Then
                    detalle_abono = "0"
                Else
                    detalle_abono = Format(Int(detalle_abono), "###,###,###")
                End If

                If detalle_saldo = "" Or detalle_saldo = "0" Then
                    detalle_saldo = "0"
                Else
                    detalle_saldo = Format(Int(detalle_saldo), "###,###,###")
                End If

                If detalle_referencia.Length > 23 Then
                    detalle_referencia = detalle_referencia.Substring(0, 23)
                End If

                e.Graphics.DrawString(detalle_referencia, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 390 + (i * multiplicador_lineas))
                e.Graphics.DrawString(detalle_abono, Font_texto_detalle, Brushes.Black, margen_izquierdo + 210, margen_superior + 390 + (i * multiplicador_lineas), format1)
                e.Graphics.DrawString(detalle_saldo, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 390 + (i * multiplicador_lineas), format1)
            Next

            numero_lineas = ((grilla_abono.Rows.Count - 1) * multiplicador_lineas)

            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + numero_lineas + 405, margen_izquierdo + 270, margen_superior + numero_lineas + 405)

            'e.Graphics.DrawString("TOTAL INGRESO", Font_texto_totales, Brushes.Black, margen_izquierdo + 100, margen_superior + numero_lineas + 320)
            'e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 200, margen_superior + numero_lineas + 320)
            e.Graphics.DrawString("TOTAL INGRESO: " & txt_total_abono_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 270, margen_superior + numero_lineas + 425, format1)

            Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 480, margen_izquierdo + 250, margen_superior + numero_lineas + 15)
            e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
        End If

        If txt_rut.Text.Contains("PROPIEDAD") = True Then
            imagen_inmobiliaria()

            Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
            Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
            Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
            Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
            Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
            Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim margen_izquierdo As Integer
            Dim margen_superior As Integer

            margen_izquierdo = 5
            margen_superior = 0

            Try
                Dim imagen_reporte As Image
                imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
                Dim posicion_imagen As New PointF(margen_izquierdo + 0, margen_superior + 0)
                e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
            Catch
            End Try

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 250, margen_superior + 15)
            Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 250, margen_superior + 15)
            Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 250, margen_superior + 15)
            Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 250, margen_superior + 15)
            Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 250, margen_superior + 15)
            Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 250, margen_superior + 15)
            Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 250, margen_superior + 15)
            Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 250, margen_superior + 15)

            e.Graphics.DrawString("INMOBILIARIA ARANA", Font_texto_empresa, Brushes.Black, rect1, stringFormat)
            e.Graphics.DrawString("ARRIENDO DE BIENES RAICES", Font_texto_empresa, Brushes.Black, rect2, stringFormat)
            e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
            e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
            e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
            e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
            e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

            e.Graphics.DrawString("COMPROBANTE DE INGRESO", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

            e.Graphics.DrawString("NRO. ABONO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 245)
            e.Graphics.DrawString(txt_n_abono.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 245)

            e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 260)
            e.Graphics.DrawString(dtp_emision.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 260)

            e.Graphics.DrawString("NOMBRE CLIENTE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 275)
            e.Graphics.DrawString(txt_nombre_cliente.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 275)

            e.Graphics.DrawString("FORMA DE PAGO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 290)
            e.Graphics.DrawString(combo_condiciones.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 290)

            e.Graphics.DrawString("DETALLE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 305)
            e.Graphics.DrawString(txt_detalle_ingreso.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 305)

            e.Graphics.DrawString("USUARIO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 320)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 320)
            e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 320)

            e.Graphics.DrawString("DIRECCION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 335)
            e.Graphics.DrawString(txt_direccion.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 335)

            e.Graphics.DrawString("DETALLE REFERENCIA", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 370)
            e.Graphics.DrawString("ABONO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 170, margen_superior + 370)
            e.Graphics.DrawString("SALDO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 370, format1)

            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 385, margen_izquierdo + 270, margen_superior + 385)

            Dim detalle_referencia As String
            Dim detalle_abono As String
            Dim detalle_saldo As String
            Dim multiplicador_lineas As Integer = 15
            Dim numero_lineas As Integer = 0

            For i = 0 To grilla_abono.Rows.Count - 1
                detalle_referencia = grilla_abono.Rows(i).Cells(0).Value.ToString & " NRO. " & grilla_abono.Rows(i).Cells(1).Value.ToString
                detalle_abono = grilla_abono.Rows(i).Cells(2).Value.ToString
                detalle_saldo = grilla_abono.Rows(i).Cells(3).Value.ToString

                If detalle_abono = "" Or detalle_abono = "0" Then
                    detalle_abono = "0"
                Else
                    detalle_abono = Format(Int(detalle_abono), "###,###,###")
                End If

                If detalle_saldo = "" Or detalle_saldo = "0" Then
                    detalle_saldo = "0"
                Else
                    detalle_saldo = Format(Int(detalle_saldo), "###,###,###")
                End If

                If detalle_referencia.Length > 23 Then
                    detalle_referencia = detalle_referencia.Substring(0, 23)
                End If

                e.Graphics.DrawString(detalle_referencia, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 390 + (i * multiplicador_lineas))
                e.Graphics.DrawString(detalle_abono, Font_texto_detalle, Brushes.Black, margen_izquierdo + 210, margen_superior + 390 + (i * multiplicador_lineas), format1)
                e.Graphics.DrawString(detalle_saldo, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 390 + (i * multiplicador_lineas), format1)
            Next

            numero_lineas = ((grilla_abono.Rows.Count - 1) * multiplicador_lineas)

            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + numero_lineas + 405, margen_izquierdo + 270, margen_superior + numero_lineas + 405)

            'e.Graphics.DrawString("TOTAL INGRESO", Font_texto_totales, Brushes.Black, margen_izquierdo + 100, margen_superior + numero_lineas + 320)
            'e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 200, margen_superior + numero_lineas + 320)
            e.Graphics.DrawString("TOTAL INGRESO: " & txt_total_abono_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 270, margen_superior + numero_lineas + 425, format1)

            Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 480, margen_izquierdo + 250, margen_superior + numero_lineas + 15)
            e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
        End If
    End Sub


End Class