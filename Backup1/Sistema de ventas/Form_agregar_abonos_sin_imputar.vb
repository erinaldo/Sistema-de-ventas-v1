Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_agregar_abonos_sin_imputar
    Dim total_registros As Integer
    Dim varnumfactura As Integer
    Dim peso As String
    Dim pesos As String
    Dim mifecha2 As String

    'Dim mifecha2 As String
    'Dim mifecha4 As String
    Dim alto_cotizacion As String
    Private WithEvents Pd As New PrintDocument

    Private Sub Form_pago_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_pago_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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


    'llamamos a los sub que queremos quye partan con la panmtalla.
    Private Sub Form_pago_prestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        'controles(False, True)
        crear_numero_documento()
        Lblfecha.Text = FormatDateTime(Now, DateFormat.ShortDate)
        'fecha()
        'mostrar_malla()
        cargar_logo()
        '  dtp_emision.CustomFormat = "yyy-MM-dd"

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub
    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_emision.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    Sub crear_numero_documento()
        Dim varnumdoc As Integer
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from abono"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_n_abono.Text = 1
            Exit Sub
        End Try
        conexion.Close()

        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select n_abono from abono where cod_auto='" & (varnumdoc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_abono")
                txt_n_abono.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_n_abono.Text = 1
        End Try
        conexion.Close()

    End Sub


    ''permite bloquear o habilitar los controles.
    'Sub controles(ByVal a As Boolean, ByVal b As Boolean)
    '    btn_limpiar.Enabled = a
    '    btn_guardar.Enabled = a
    '    'btn_nuevo.Enabled = b
    '    txt_rut.Enabled = a
    '    '   combo_factura.Enabled = a
    '    ' Combo_tipo.Enabled = a
    '    btn_limpiar.Enabled = a
    '    txt_abono.Enabled = a
    '    Check_imputar.Enabled = a
    'End Sub

    Sub controles_sin_imputar(ByVal a As Boolean, ByVal b As Boolean)


        '   combo_factura.Enabled = a
        '  Combo_tipo.Enabled = a


    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha2 se le entrega el formato de fecha indicado.
    'Sub fecha()
    '    Dim mifecha As Date
    '    mifecha = Lblfecha.Text
    '    mifecha2 = mifecha.ToString("yyy-MM-dd")
    'End Sub

    ''se declara la variable mifecha.
    ''se le entrega el valor de la variable al label.
    ''a la variable mi fecha2 se le entrega el formato de fecha indicado.
    'Sub fecha2()
    '    Dim mifecha2 As Date
    '    mifecha2 = txt_fecha.Text
    '    mifecha4 = mifecha2.ToString("yyy-MM-dd")
    'End Sub

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
            txt_folio.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                ' txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                txt_n_abono.Focus()
            End If
            conexion.Close()
        End If
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



    'obtenemos el total de las facturas adeudadas mediente un sum. y los cargamos en un texbox invicible.
    Sub mostrar_deuda()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion

        SC.CommandText = "select sum(total) as mitotal from creditos where rut_cliente= '" & (txt_rut.Text) & "' and estado='EMITIDA'"
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If TypeOf (DS.Tables(DT.TableName).Rows(0).Item("mitotal")) Is DBNull Then
            txt_invicible.Text = 0
        Else
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_invicible.Text = DS.Tables(DT.TableName).Rows(0).Item("mitotal")
            End If
        End If
        conexion.Close()
    End Sub



    'actualiza el saldo en la tabla total y la tabla factura de credito ademas de guardar el registro de los abonos.
    Sub grabar_pago()

        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        conexion.Open()

        SC4.Connection = conexion
        SC4.CommandText = "select * from abono where n_abono ='" & (txt_n_abono.Text) & "'"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)

        If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
            MsgBox("EL  DOCUMENTO YA FUE INGRESADO", 0 + 16, "ERROR")
            Me.Enabled = True
            conexion.Close()
            Exit Sub
        End If
        conexion.Close()

        fecha()
        SC.Connection = conexion
        SC.CommandText = "insert into abono (n_abono, TIPO, rut_cliente, codigo_cliente, nombre, fecha, monto_abono, usuario_responsable, condicion_abono, detalle_abono, estado, hora) values( '" & (txt_n_abono.Text) & "','ABONO', '" & (txt_rut.Text) & "', '" & (txt_codigo_cliente.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (mifecha2) & "','" & (txt_total_abono.Text) & "','" & (miusuario) & "','" & (combo_condiciones.Text) & "','" & (txt_detalle_ingreso.Text) & "', 'EMITIDO', '" & (Form_menu_principal.lbl_hora.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)



        SC.Connection = conexion
        SC.CommandText = "insert into creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza, pie) values (" & (txt_n_abono.Text) & ",'" & ("ABONO") & "','ABONO SIN IMPUTAR','" & (txt_rut.Text) & "','" & (txt_codigo_cliente.Text) & "','" & (mifecha2) & "','0','0','0','0','" & "-" & (txt_total_abono.Text) & "','" & "-" & (txt_total_abono.Text) & "','" & (combo_condiciones.Text) & "','EMITIDA','" & (miusuario) & "','0','SIN IMPUTAR', '" & (mirecintoempresa) & "', '0000-00-00', '0000-00-00', '1', '1', '0', '0', '0')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "update clientes set saldo_cliente = saldo_cliente + " & (Int(txt_total_abono.Text)) & " where rut_cliente = '" & (txt_rut.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)



        SC.Connection = conexion
        SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values(" & (txt_n_abono.Text) & ", 'ABONO', '" & (txt_total_abono.Text) & "', '" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (nombre_pc) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)
    End Sub



    'sale de la pantalla.
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub





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
        ' combo_factura.Items.Clear()
        'llenar_combo_facturas()
        ' llenar_combo_doc()
        ' llenar_combo_rut()
        mostrar_datos_clientes()
        ' combo_rut.Text = combo_rut.SelectedItem
        'mostrar_malla()
        Form_ver_pagos.Close()




        'mostrar_suma()
        mostrar_deuda()
        ' mostrar_malla()
    End Sub

    'limpia los datos de la pantalla.
    Sub limpiar()
        ' combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        txt_rut.Text = ""
        txt_nombre_cliente.Text = ""
        'Combo_tipo.Text = ""
        txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_total_abono.Text = ""
        '    txt_deuda.Text = "0"
        txt_invicible.Text = ""
        '    txt_despues.Text = "0"
        '    txt_deuda_actual.Text = "0"
        '   txt_deuda_menos_abonos.Text = "0"
        'txt_n_abono.Text = ""
        combo_condiciones.SelectedItem = "-"
        txt_detalle_ingreso.Text = "-"
        'Check_imputar.Checked = False
        '   combo_factura.Items.Clear()
        txt_folio.Text = ""
        '   migrilla.DataSource = Nothing
    End Sub

    Sub limpiar_datos_clientes()

        txt_codigo_cliente.Text = ""
        ' txt_rut.Text = ""
        txt_nombre_cliente.Text = ""
        txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_folio.Text = ""
    End Sub

    'limpia los datos de lapantalla.
    Sub limpiar_sin_imputar()

        ' combo_factura.Text = ""


        ' Combo_tipo.Text = ""
        ' txt_deuda.Text = "0"
        txt_invicible.Text = ""
        ' txt_despues.Text = "0"
        ' txt_deuda_actual.Text = "0"
        ' txt_deuda_menos_abonos.Text = "0"

        'combo_factura.Items.Clear()
    End Sub



    Private Sub combo_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
    End Sub

    Private Sub combo_factura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ' combo_factura.BackColor = Color.White
    End Sub

    'llama al sub de los datos para pago.
    Private Sub combo_factura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  mostrar_datos_para_pago()
        txt_total_abono.Focus()
    End Sub

    Private Sub txt_abono_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total_abono.GotFocus
        txt_total_abono.BackColor = Color.LightSkyBlue
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

    'llama al sub calcular.
    Private Sub txt_abono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_abono.TextChanged
        'calcular()
    End Sub

    'valida el ingreso de solo numeros.
    Private Sub txt_abono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total_abono.KeyPress

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


    'llama al sub controles.
    ' llama al sub limpiar.
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'controles(True, False)
        limpiar()
        txt_rut.Focus()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub



    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        Form_ver_pagos.txt_rut.Text = txt_rut.Text
        Form_ver_pagos.Show()
        Form_ver_pagos.txt_rut.Focus()
    End Sub

    Private Sub migrilla_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

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

    'Private Sub Combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_tipo.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub Combo_tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_tipo.BackColor = Color.White
    'End Sub

    'Private Sub Combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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




        limpiar_datos_clientes()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            ' combo_factura.Items.Clear()
            ' llenar_combo_doc()
            guion_rut_cliente()
            mostrar_datos_clientes()
            'mostrar_malla()
            Form_ver_pagos.Close()
            '  mostrar_suma()
            mostrar_deuda()
            'mostrar_malla()
        End If
    End Sub



    'Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_nuevo.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'btn_nuevo.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent

    End Sub

    Private Sub btn_ver_pagos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ' btn_ver_pagos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_ver_pagos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'btn_ver_pagos.BackColor = Color.WhiteSmoke
        ' TextBox1.Text = ActiveControl.Name
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub txt_rut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_clientes_abonos_sin_imputar.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub

    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut.Text = rut_cliente
            End If
        End If
    End Sub

    Private Sub txt_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total_abono.LostFocus
        txt_total_abono.BackColor = Color.White
    End Sub

    Private Sub txt_n_abono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_n_abono.GotFocus
        txt_n_abono.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_abono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_n_abono.KeyPress

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




        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            dtp_emision.Focus()
        End If
    End Sub

    Private Sub txt_n_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_n_abono.LostFocus
        txt_n_abono.BackColor = Color.White
    End Sub

    Private Sub dtp_emision_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_emision.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_total_abono.Focus()
        End If
    End Sub

    Private Sub combo_condiciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_condiciones.SelectedIndexChanged
        If combo_condiciones.Text = "OTRO MEDIO DE PAGO" Then
            Form_otro_medio_de_pago_abonos_sin_imputar.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub combo_condiciones_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.GotFocus
        combo_condiciones.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_condiciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.LostFocus
        combo_condiciones.BackColor = Color.White
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
            txt_rut.Focus()
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_cliente.Focus()
            Exit Sub
        End If

        If txt_n_abono.Text = "" Then
            MsgBox("CAMPO NRO. ABONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_n_abono.Focus()
            Exit Sub
        End If

        If txt_total_abono.Text = "" Then
            MsgBox("CAMPO TOTAL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total_abono.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            MsgBox("CAMPO CONDICION DE INGRESO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        If txt_detalle_ingreso.Text = "" Then
            txt_detalle_ingreso.Text = "-"
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        crear_numero_documento()

        With Pd.PrinterSettings
            .PrinterName = impresora_ticket
            .Copies = 2
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.Pd.PrintController = New StandardPrintController
                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()
                'MsgBox("ABONO GUARDADO CON EXITO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                'lbl_mensaje.Visible = False
                'Me.Enabled = True
                'Exit Sub
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End With

        grabar_pago()
        MsgBox("ABONO GUARDADO CON EXITO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        limpiar()
        lbl_mensaje.Visible = False
        Me.Enabled = True
        txt_rut.Focus()
    End Sub

    Private Function ReturnDataSetAbonoTicket() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ciudad_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

        dt.Columns.Add(New DataColumn("nro_abono", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_abono", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))

        dt.Columns.Add(New DataColumn("detalle_referencia", GetType(String)))
        dt.Columns.Add(New DataColumn("abono", GetType(Integer)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("total_abono", GetType(Integer)))

        dt.Columns.Add(New DataColumn("condicion_abono", GetType(String)))
        dt.Columns.Add(New DataColumn("detalle_condicion_abono", GetType(String)))
        dt.Columns.Add(New DataColumn("cajero_abono", GetType(String)))
        dt.Columns.Add(New DataColumn("titulo", GetType(String)))
        'Dim detalle_referencia As String
        'Dim detalle_abono As String
        'Dim detalle_saldo As String

        Dim nro_abono As String
        Dim fecha_abono As String
        Dim rut_abono As String
        Dim nombre_abono As String
        Dim total_abono As String
        Dim condicion_abono As String
        Dim detalle_condicion_abono As String
        Dim cajero_abono As String

        nro_abono = txt_n_abono.Text
        fecha_abono = dtp_emision.Text
        rut_abono = txt_rut.Text
        nombre_abono = txt_nombre_cliente.Text
        total_abono = txt_total_abono.Text
        condicion_abono = combo_condiciones.Text
        detalle_condicion_abono = txt_detalle_ingreso.Text
        cajero_abono = minombre

        dr = dt.NewRow()

        Try
            dr("Imagen") = Imagen_ticket
        Catch
        End Try

        dr("nombre_empresa") = minombreempresa
        dr("giro_empresa") = migiroempresa
        dr("direccion_empresa") = midireccionempresa
        dr("ciudad_empresa") = micomunaempresa
        dr("telefono_empresa") = mitelefonoempresa
        dr("correo_empresa") = micorreoempresa
        dr("rut_empresa") = mirutempresa
        dr("nro_abono") = nro_abono
        dr("fecha_abono") = fecha_abono
        dr("nombre_cliente") = nombre_abono
        dr("rut_cliente") = rut_abono
        dr("detalle_referencia") = "(" & txt_folio.Text & ")"
        dr("abono") = "0"
        dr("saldo") = "0"
        dr("total_abono") = txt_total_abono.Text
        dr("condicion_abono") = condicion_abono
        dr("detalle_condicion_abono") = detalle_condicion_abono
        dr("cajero_abono") = cajero_abono
        dr("titulo") = "COMPROBANTE DE INGRESO"
        dt.Rows.Add(dr)
        dr = dt.NewRow()

        Try
            dr("Imagen") = Imagen_ticket
        Catch
        End Try

        dr("nombre_empresa") = minombreempresa
        dr("giro_empresa") = migiroempresa
        dr("direccion_empresa") = midireccionempresa
        dr("ciudad_empresa") = micomunaempresa
        dr("telefono_empresa") = mitelefonoempresa
        dr("correo_empresa") = micorreoempresa
        dr("rut_empresa") = mirutempresa

        dr("nro_abono") = nro_abono
        dr("fecha_abono") = fecha_abono
        dr("nombre_cliente") = nombre_abono
        dr("rut_cliente") = rut_abono

        dr("detalle_referencia") = "-"
        dr("abono") = "0"
        dr("saldo") = "0"
        dr("total_abono") = total_abono


        dr("condicion_abono") = condicion_abono
        dr("detalle_condicion_abono") = detalle_condicion_abono
        dr("cajero_abono") = cajero_abono


        dt.Rows.Add(dr)




        ds.Tables.Add(dt)

        ds.Tables(0).TableName = "Abono"

        Dim iDS As New dsAbono
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS

    End Function


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


    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.Click
        conexion.Close()
        Me.Enabled = False
        txt_rut.Focus()
        Form_buscador_clientes_abonos_sin_imputar.Show()
        Form_buscador_clientes_abonos_sin_imputar.txt_busqueda.Focus()
    End Sub

    Private Sub btn_buscar_clientes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.GotFocus
        btn_buscar_clientes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.LostFocus
        btn_buscar_clientes.BackColor = Color.Transparent
    End Sub


    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        If txt_direccion.Text.Length > 23 Then
            txt_direccion.Text = txt_direccion.Text.Substring(0, 30)
        End If

        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), -74, 0, 440, 70)
        Catch
        End Try

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 270, margen_superior + 15)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 270, margen_superior + 15)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 270, margen_superior + 15)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 270, margen_superior + 15)
        Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 270, margen_superior + 15)
        Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 270, margen_superior + 15)
        Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 270, margen_superior + 15)
        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 270, margen_superior + 15)

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
        e.Graphics.DrawString("SALDO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 245, margen_superior + 370)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 385, margen_izquierdo + 295, margen_superior + 385)
        e.Graphics.DrawString("SIN DOCUMENTOS IMPUTADOS", Font_texto_totales, Brushes.Black, margen_izquierdo + 50, margen_superior + 390)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 410, margen_izquierdo + 295, margen_superior + 410)

        Dim total_abono As String = txt_total_abono.Text

        If total_abono = "" Or total_abono = "0" Then
            total_abono = "0"
        Else
            total_abono = Format(Int(total_abono), "###,###,###")
        End If
        e.Graphics.DrawString("TOTAL INGRESO: " & total_abono, Font_texto_totales, Brushes.Black, margen_izquierdo + 295, margen_superior + 430, format1)


        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + 490, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub
End Class