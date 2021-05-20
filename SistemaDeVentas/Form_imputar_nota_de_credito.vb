Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Resources

Public Class Form_imputar_nota_de_credito
    Dim total_registros As Integer
    Dim varnumfactura As Integer
    Dim peso As String
    Dim pesos As String
    Private Sub Form_imputar_nota_de_credito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_imputar_nota_de_credito_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_imputar_nota_de_credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        controles(False, True)
        mostrar_datos_para_pago()
        mostrar_deuda()
        calcular()
        cargar_logo()
        dtp_emision.CustomFormat = "yyy-MM-dd"
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub


    Sub consultar_sucursales()

        If mirutempresa = "87686300-6" Then

              llenar_combo_facturas()

            calcular_totales()

        End If

    End Sub
    'permite bloquear o habilitar los controles.
    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_limpiar.Enabled = a
        btn_guardar.Enabled = a
        btn_cargar.Enabled = a
        '  btn_modificar_abono.Enabled = a

        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a
        grilla_imputar.Enabled = a

        btn_nuevo.Enabled = b
        ' txt_rut.Enabled = a
        combo_factura.Enabled = a
        Combo_tipo.Enabled = a
        btn_limpiar.Enabled = a
        txt_abono.Enabled = a
        Combo_cuotas.Enabled = a
        btn_sugerir.Enabled = a
        grilla_imputar.Enabled = a

        GroupBox1.Enabled = a
        GroupBox2.Enabled = a
        GroupBox3.Enabled = a
        GroupBox4.Enabled = a
        GroupBox5.Enabled = a
        GroupBox6.Enabled = a
        GroupBox7.Enabled = a
        GroupBox8.Enabled = a
        GroupBox9.Enabled = a

        ' txt_n_abono.Enabled = a
        '  dtp_emision.Enabled = a
        'Check_imputar.Enabled = a
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
            ' txt_direccion.Text = ""

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                ' txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                '  txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            End If
            conexion.Close()
        End If
    End Sub

    'mostramos el total y el saldo de la fatura seleccionada.
    Sub mostrar_datos_para_pago()
        combo_factura.Text = ""
        Combo_tipo.Text = ""
        If Combo_cuotas.SelectedItem <> "-" And Combo_cuotas.SelectedItem <> "" Then


            Dim tipo_doc As String = ""
            Dim nro_doc As String = ""

            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = Combo_cuotas.Text

            If Combo_cuotas.Text.Contains("NOTA DE DEBITO") Then
                tabla = Split(cadena, " ")
                For n = 0 To UBound(tabla, 1)
                    tipo_doc = "NOTA DE DEBITO"
                    nro_doc = tabla(3)
                Next
            Else
                tabla = Split(cadena, " ")
                For n = 0 To UBound(tabla, 1)
                    tipo_doc = tabla(0)
                    nro_doc = tabla(1)
                Next
            End If


            'tabla = Split(cadena, " ")
            'For n = 0 To UBound(tabla, 1)
            '    tipo_doc = tabla(0)
            '    nro_doc = tabla(1)
            'Next

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from creditos where n_creditos ='" & (nro_doc) & "' AND TIPO ='" & (tipo_doc) & "' AND rut_cliente ='" & (txt_rut.Text) & "' "
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                combo_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("n_creditos")
                Combo_tipo.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo")
                '   txt_deuda_menos_abonos.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
                txt_deuda_actual.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
                txt_fecha.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                ' txt_tipo.Text = DS.Tables(DT.TableName).Rows(0).Item("TIPO")
                txt_despues.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
                txt_recinto.Text = DS.Tables(DT.TableName).Rows(0).Item("recinto")

                If txt_deuda_actual.Text = "" Or txt_deuda_actual.Text = "0" Then
                    txt_deuda_actual_millar.Text = "0"
                Else
                    txt_deuda_actual_millar.Text = Format(Int(txt_deuda_actual.Text), "###,###,###")
                End If



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

    'llenamos el ocmbo facturas segun el rut que este escrito.
    Sub llenar_combo_facturas()
        ' Dim valor_combo_cuota As String
        Combo_cuotas.Items.Clear()

        'If Combo_cuotas.Text <> "" And Combo_cuotas.Text <> "-" Then
        '    valor_combo_cuota = Combo_cuotas.Text
        'End If


        If txt_rut.Text <> "" Then
            conexion.Close()
            ' combo_factura.Items.Clear()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from creditos where saldo <>'0'  and rut_cliente='" & (txt_rut.Text) & "' and TIPO <> 'ABONO' and TIPO <> 'NOTA DE CREDITO'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                    '  combo_factura.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("n_creditos"))

                    Combo_cuotas.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("TIPO") & " " & DS2.Tables(DT2.TableName).Rows(i).Item("n_creditos"))

                Next
            End If
            conexion.Close()
        End If

        'If Combo_cuotas.Text <> "" And Combo_cuotas.Text <> "-" Then
        '    Combo_cuotas.Text = valor_combo_cuota
        'End If

    End Sub

    'llena el combo rut.
    'Sub llenar_combo_rut()
    '    DS2.Tables.Clear()
    '    DT2.Rows.Clear()
    '    DT2.Columns.Clear()
    '    DS2.Clear()
    '    conexion.Open()

    '    SC2.Connection = conexion
    '    SC2.CommandText = "select * from clientes"
    '    DA2.SelectCommand = SC2
    '    DA2.Fill(DT2)
    '    DS2.Tables.Add(DT2)

    '    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
    '            combo_rut.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("rut"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    Sub llenar_combo_doc()
        conexion.Close()
        Combo_tipo.Items.Clear()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select TIPO from creditos  where rut_CLIENTE='" & (txt_rut.Text) & "' and TIPO<>'ABONO' and TIPO<>'NOTA DE CREDITO' group by TIPO"
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

    'selecciona toda la informacion de la factura de credito donde rut sea = al digitado y el saldo sea mayor a 0.
    'Sub actualizar_tabla_clientes()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select n_credito from creditos where rut = '" & (txt_rut.Text) & "' and saldo > '0' "
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    conexion.Close()
    'End Sub

    'obtenemos el total de las facturas adeudadas mediente un sum.
    'Sub mostrar_suma()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select sum(total) as mitotal from creditos where rut_cliente= '" & (txt_rut.Text) & "' and estado='EMITIDA' and saldo > 0 "

    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If TypeOf (DS.Tables(DT.TableName).Rows(0).Item("mitotal")) Is DBNull Then
    '        txt_deuda.Text = 0
    '    Else
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            txt_deuda.Text = DS.Tables(DT.TableName).Rows(0).Item("mitotal")
    '        End If
    '    End If
    '    conexion.Close()
    'End Sub

    'obtenemos el total de las facturas adeudadas mediente un sum. y los cargamos en un texbox invicible.
    Sub mostrar_deuda()
        conexion.Close()
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




        If txt_despues.Text = "" Or txt_despues.Text = "0" Then
            txt_despues_millar.Text = "0"
        Else
            txt_despues_millar.Text = Format(Int(txt_despues.Text), "###,###,###")
        End If



    End Sub

    'crea el numero coorrelativo para el abono.
    Sub crear_numero_abono()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(n_abono) as n_abono from abono"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumfactura = DS.Tables(DT.TableName).Rows(0).Item("n_abono")
                txt_n_nota_credito.Text = varnumfactura + 1
            End If
        Catch err As InvalidCastException
            txt_n_nota_credito.Text = 1
        End Try
        conexion.Close()
    End Sub

    'actualiza el saldo en la tabla total y la tabla factura de credito ademas de guardar el registro de los abonos.
    Sub grabar_abono()

        Dim saldo_nota_credito As Integer

        saldo_nota_credito = Val(txt_total_nota_credito.Text) - Val(txt_total_imputado.Text)


        If saldo_nota_credito = 0 Then
            SC.Connection = conexion
            SC.CommandText = "update creditos set  saldo = '0' AND  estado = 'PAGADA' where rut_cliente = '" & (txt_rut.Text) & "' and TIPO ='NOTA DE CREDITO' and n_creditos ='" & (txt_n_nota_credito.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

        Else

            SC.Connection = conexion
            SC.CommandText = "update creditos set  saldo = '" & (saldo_nota_credito) & "' where rut_cliente = '" & (txt_rut.Text) & "' and TIPO ='NOTA DE CREDITO' and n_creditos ='" & (txt_n_nota_credito.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        grabar_detalle_abono()
    End Sub

    Sub grabar_detalle_abono()
        Dim VarDocumento As String
        Dim varNroDoc As String
        Dim VarAbono As Integer
        Dim VarSaldo As String
        Dim VarEstado As String
        Dim VarRecinto As String

        For i = 0 To grilla_imputar.Rows.Count - 1
            VarDocumento = grilla_imputar.Rows(i).Cells(0).Value.ToString
            varNroDoc = grilla_imputar.Rows(i).Cells(1).Value.ToString
            VarAbono = grilla_imputar.Rows(i).Cells(2).Value.ToString
            VarSaldo = grilla_imputar.Rows(i).Cells(3).Value.ToString
            VarEstado = grilla_imputar.Rows(i).Cells(4).Value.ToString
            VarRecinto = grilla_imputar.Rows(i).Cells(5).Value.ToString

            If VarEstado = "SIN INGRESAR" Then
                SC.Connection = conexion
                SC.CommandText = "insert into detalle_imputar_nota_credito (nro_nota_credito, nro_documento, tipo_documento, monto_abono, saldo_documento, estado, sucursal) values('" & (txt_n_nota_credito.Text) & "','" & (varNroDoc) & "', '" & (VarDocumento) & "','" & (VarAbono) & "','" & (VarSaldo) & "','" & (VarEstado) & "','" & (VarRecinto) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update creditos set saldo = '" & (VarSaldo) & "', fecha_pago='" & (Form_menu_principal.dtp_fecha.Text) & "' where rut_cliente = '" & (txt_rut.Text) & "' and n_creditos ='" & (varNroDoc) & "'  and tipo ='" & (VarDocumento) & "' and recinto ='" & (VarRecinto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                If VarSaldo = 0 Then
                    SC.Connection = conexion
                    SC.CommandText = "update creditos set estado = 'PAGADA' where rut_cliente = '" & (txt_rut.Text) & "' and CODIGO_AFECTA ='" & (varNroDoc) & "'  and NOMBRE_AFECTA ='" & (VarDocumento) & "' and recinto ='" & (VarRecinto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            End If
        Next
    End Sub

    'sale de la pantalla.
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub



    'si el saldo de la factura es menor a  0 no puede guardarlo.
    'sies amyor o = a 0 graba el pago
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim mensaje As String = ""
        Dim tipo_abono As String


        tipo_abono = "NOTA DE CREDITO" & " A " & (Combo_tipo.Text) & " Nº " & (combo_factura.Text)

        If grilla_imputar.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_n_nota_credito.Focus()
            Exit Sub
        End If

        If txt_n_nota_credito.Text = "" Then
            MsgBox("CAMPO NRO. NOTA DE CREDITO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_n_nota_credito.Focus()
            Exit Sub
        End If

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

        If txt_total_imputado.Text > txt_total_nota_credito.Text Then
            MsgBox("EL TOTAL IMPUTADO NO PUEDE SER MAYOR AL TOTAL DEL DOCUMENTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_cliente.Focus()
            Exit Sub
        End If


        'conexion.Close()
        'Consultas_SQL("select * from abono where n_abono = '" & (txt_n_nota_credito.Text) & "'")
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '    Dim valormensaje As Integer
        '    valormensaje = MsgBox("NRO. DE ABONO YA EXISTENTE, ¿DESEA ACTUALIZAR EL ABONO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")

        '    If valormensaje = vbYes Then


        lbl_mensaje.Visible = True
        Me.Enabled = False

        grabar_abono()

        MsgBox("REGISTRO IMPUTADO CON EXITO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")

        limpiar()
        controles(False, True)

        lbl_mensaje.Visible = False
        Me.Enabled = True

        '    End If
        'End If
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

    ''llenamos el combo factura.
    ''llenamos el ocmbo rut.
    ''mostramos los datos de los cliente.
    ''le damos el valor del combo al texbox.
    'Private Sub combo_rut_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    combo_factura.Items.Clear()
    '    'llenar_combo_facturas()
    '    llenar_combo_doc()
    '    ' llenar_combo_rut()
    '    mostrar_datos_clientes()
    '    ' combo_rut.Text = combo_rut.SelectedItem
    '    'mostrar_malla()
    '    Form_ver_pagos.Close()




    '    'mostrar_suma()
    '    mostrar_deuda()
    '    'mostrar_malla()
    'End Sub

    'limpia los datos de la pantalla.
    Sub limpiar()
        combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        txt_rut.Text = ""
        txt_nombre_cliente.Text = ""
        Combo_tipo.Text = ""
        'txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_abono.Text = ""

        txt_total_imputado.Text = "0"
        txt_total_imputado_millar.Text = ""
        txt_invicible.Text = ""

        txt_despues.Text = "0"
        txt_despues_millar.Text = ""
        txt_deuda_actual.Text = "0"
        txt_deuda_actual_millar.Text = ""
        'txt_deuda_menos_abonos.Text = "0"
        txt_n_nota_credito.Text = ""
        'Check_imputar.Checked = False
        combo_factura.Items.Clear()
        grilla_imputar.DataSource = Nothing
        grilla_imputar.Rows.Clear()

        dtp_emision.Text = FormatDateTime(Now, DateFormat.ShortDate)
        ' Me.btn_modificar_abono.Enabled = False
        '  Me.txt_n_nota_credito.Enabled = True
        Me.txt_rut.Enabled = True
        Me.txt_nombre_cliente.Enabled = True
        '  Me.txt_direccion.Enabled = True
        ' Me.dtp_emision.Enabled = True
        Me.txt_total_imputado.Enabled = True
    End Sub

    Sub limpiar_datos_cliente()

        combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        '  txt_rut.Text = ""
        txt_nombre_cliente.Text = ""
        Combo_tipo.Text = ""
        'txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_abono.Text = ""
        txt_total_imputado.Text = "0"
        txt_invicible.Text = ""
        txt_despues.Text = "0"
        txt_deuda_actual.Text = "0"
        'txt_deuda_menos_abonos.Text = "0"
        txt_n_nota_credito.Text = ""
        'Check_imputar.Checked = False
        combo_factura.Items.Clear()
        grilla_imputar.DataSource = Nothing
        'btn_modificar_abono.Enabled = False
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

        If txt_despues.Text = "0" Then
            txt_despues.Text = ""
        End If
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
        controles(True, False)
        limpiar()
        btn_cargar.PerformClick()
        ' txt_rut.Focus()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub





    Private Sub migrilla_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_imputar.CellClick

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

    Private Sub Combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_tipo.SelectedIndexChanged
        'llenar_combo_facturas()
    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub




    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.GotFocus
        txt_rut.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_ImeModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.ImeModeChanged

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




        limpiar_datos_cliente()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            combo_factura.Items.Clear()
            llenar_combo_doc()
            guion_rut_cliente()
            mostrar_datos_clientes()
            Form_ver_pagos.Close()
            mostrar_deuda()
        End If
    End Sub



    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
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

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub txt_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_abono.LostFocus
        txt_abono.BackColor = Color.White
    End Sub

    Private Sub txt_n_abono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_n_nota_credito.KeyPress

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

    Private Sub txt_n_abono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_n_nota_credito.TextChanged

    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click


        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If


        If Combo_cuotas.Text = "" Then
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_cuotas.Focus()
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
            MsgBox("EL VALOR IMPUTADO ES MAYOR AL DOCUMENTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_abono.Focus()
            Exit Sub
        End If


        For i = 0 To grilla_imputar.Rows.Count - 1

            Dim tipo_documento As String
            Dim numero_documento As String
            Dim estado As String

            tipo_documento = grilla_imputar.Rows(i).Cells(0).Value.ToString
            numero_documento = grilla_imputar.Rows(i).Cells(1).Value.ToString
            estado = grilla_imputar.Rows(i).Cells(4).Value.ToString

            If tipo_documento = Combo_tipo.Text And numero_documento = combo_factura.Text Then
                grilla_imputar.Rows.Remove(grilla_imputar.CurrentRow)
                grilla_imputar.Rows.Add(Combo_tipo.Text, combo_factura.Text, txt_abono.Text, txt_despues.Text, "SIN INGRESAR", txt_recinto.Text)
                calcular_totales()
                limpiar_abono()
                Exit Sub
            End If


        Next

        grilla_imputar.Rows.Add(Combo_tipo.Text, combo_factura.Text, txt_abono.Text, txt_despues.Text, "SIN INGRESAR", txt_recinto.Text)
        calcular_totales()
        limpiar_abono()
    End Sub


    Sub calcular_totales()
        ''//Calcular el total general

        'Dim totalabono As String
        'Dim EstadoAbono As String

        'txt_total_imputado.Text = 0
        'For i = 0 To migrilla.Rows.Count - 1
        '    EstadoAbono = migrilla.Rows(i).Cells(4).Value.ToString

        '    If EstadoAbono = "SIN INGRESAR" Then
        '        totalabono = Val(migrilla.Rows(i).Cells(2).Value.ToString)
        '        txt_total_imputado.Text = Val(txt_total_imputado.Text) + Val(totalabono)
        '    End If
        'Next




        '//Calcular el total general
        Dim totalabono As String
        Dim VarIngresoAbono As String
        txt_total_imputado.Text = 0
        For i = 0 To grilla_imputar.Rows.Count - 1
            totalabono = Val(grilla_imputar.Rows(i).Cells(2).Value.ToString)
            VarIngresoAbono = grilla_imputar.Rows(i).Cells(4).Value.ToString

            If VarIngresoAbono = "SIN INGRESAR" Then
                txt_total_imputado.Text = Val(txt_total_imputado.Text) + Val(totalabono)
            End If
        Next





        If txt_total_imputado.Text = "" Or txt_total_imputado.Text = "0" Then
            txt_total_imputado_millar.Text = "0"
        Else
            txt_total_imputado_millar.Text = Format(Int(txt_total_imputado.Text), "###,###,###")
        End If
    End Sub
    ' End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        Dim VarEstado As String
        Dim VarNroDocumento As String
        Dim VarTipoDocumento As String
        Dim VarTotalDocumento As String

        If grilla_imputar.Rows.Count > 0 Then

            VarEstado = grilla_imputar.CurrentRow.Cells(4).Value
            VarNroDocumento = grilla_imputar.CurrentRow.Cells(1).Value
            VarTipoDocumento = grilla_imputar.CurrentRow.Cells(0).Value
            VarTotalDocumento = grilla_imputar.CurrentRow.Cells(2).Value

            If VarEstado = "SIN INGRESAR" Then
                grilla_imputar.Rows.Remove(grilla_imputar.CurrentRow)
                calcular_totales()
                combo_factura.Focus()
            Else

                Dim valormensaje As Integer
                valormensaje = MsgBox("EL ABONO SELECCIONADO YA FUE INGRESADO AL SISTEMA ¿ESTA SEGURO DE ELIMINAR EL MOVIMIENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

                If valormensaje = vbYes Then
                    Dim Var_codigo_producto_eliminar As String
                    Dim Var_cantidad_producto_eliminar As Integer
                    Var_codigo_producto_eliminar = grilla_imputar.CurrentRow.Cells(0).Value
                    Var_cantidad_producto_eliminar = grilla_imputar.CurrentRow.Cells(2).Value

                    SC.Connection = conexion
                    SC.CommandText = "delete from detalle_imputar_nota_credito where nro_docUMENTO = '" & (VarNroDocumento) & "' and tipo_documento = '" & (VarTipoDocumento) & "' and nRO_nota_credito= '" & (txt_n_nota_credito.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    'SC.Connection = conexion
                    'SC.CommandText = "update abono set monto_abono = monto_abono - " & (VarTotalDocumento) & " where n_abono = '" & (txt_n_nota_credito.Text) & "'"
                    'DA.SelectCommand = SC
                    'DA.Fill(DT)


                    SC.Connection = conexion
                    SC.CommandText = "update creditos set saldo = saldo + " & (VarTotalDocumento) & ",  ESTADO = 'EMITIDA' where rut_cliente = '" & (txt_rut.Text) & "'  and n_creditos ='" & (VarNroDocumento) & "'  and TIPO ='" & (VarTipoDocumento) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    txt_total_nota_credito.Text = Val(txt_total_nota_credito.Text) + (VarTotalDocumento)

                    SC.Connection = conexion
                    SC.CommandText = "update creditos set saldo = '" & ("-" & txt_total_nota_credito.Text) & "' ,  ESTADO = 'EMITIDA' where rut_cliente = '" & (txt_rut.Text) & "'  and n_creditos ='" & (txt_n_nota_credito.Text) & "' and TIPO ='NOTA DE CREDITO'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)



                    SC.Connection = conexion
                    SC.CommandText = "delete from creditos where TIPO = 'ABONO' and rut_cliente = '" & (txt_rut.Text) & "' and  codigo_afecta= '" & (VarNroDocumento) & "' and nombre_afecta= '" & (VarTipoDocumento) & "' and n_creditos= '" & (txt_n_nota_credito.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    ' VarTotalDocumento = abs(VarTotalDocumento)

                    grilla_imputar.Rows.Remove(grilla_imputar.CurrentRow)
                    combo_factura.Focus()
                End If
                combo_factura.Focus()
            End If
        End If
    End Sub

    Private Sub txt_deuda_actual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_deuda_actual.TextChanged

    End Sub




    Private Sub btn_cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar.Click
        conexion.Close()
        Form_cargar_nota_de_credito.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub










    Private Sub btn_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.GotFocus
        btn_cargar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.LostFocus
        btn_cargar.BackColor = Color.WhiteSmoke
    End Sub


    Private Sub panel_esc_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub btn_sugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sugerir.Click
        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If

        mostrar_malla()

        If grilla_estado_de_cuenta_final.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If

        If txt_total_imputado.Text = "" Then
            MsgBox("CAMPO MONTO ABONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total_imputado.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        sugerir_pago()
        calcular_totales()
        txt_despues.Text = "0"

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub


    Sub mostrar_malla()

        grilla_estado_de_cuenta_final.DataSource = Nothing
        grilla_estado_de_cuenta_final.Rows.Clear()


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from creditos  where  rut_cliente = '" & (txt_rut.Text) & "'  and saldo <> '0' order by fecha_venta asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_estado_de_cuenta.Rows.Clear()
        grilla_estado_de_cuenta.Columns.Clear()
        grilla_estado_de_cuenta.Columns.Add("n_creditos", "NRO.")
        grilla_estado_de_cuenta.Columns.Add("tipo_detalle", "TIPO")
        grilla_estado_de_cuenta.Columns.Add("fecha_venta", "FECHA")
        grilla_estado_de_cuenta.Columns.Add("total", "TOTAL")
        grilla_estado_de_cuenta.Columns.Add("saldo", "SALDO")
        grilla_estado_de_cuenta.Columns.Add("saldo", "SALDO FINAL")

        Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_total_deuda.Text = 0
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("fecha_venta"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("saldo"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("saldo") + Val(txt_total_deuda.Text))

                txt_total_deuda.Text = DS.Tables(DT.TableName).Rows(i).Item("saldo")

            Next


            Dim Varcoddocumento As Integer
            Dim VarTipo As String
            Dim Varfecha As String
            Dim vartotal As Integer
            Dim varsaldo As Integer
            'Dim totalsaldo As Integer
            'Dim vartotalsaldo As Integer
            txt_total_deuda.Text = "0"

            For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

                Varcoddocumento = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
                VarTipo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
                Varfecha = grilla_estado_de_cuenta.Rows(i).Cells(2).Value
                vartotal = grilla_estado_de_cuenta.Rows(i).Cells(3).Value.ToString
                varsaldo = grilla_estado_de_cuenta.Rows(i).Cells(4).Value.ToString


                ' For e = 0 To migrilla.Rows.Count - 1

                Dim descripcion_tipo As String
                descripcion_tipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")

                If descripcion_tipo.Length > 15 Then
                    descripcion_tipo = descripcion_tipo.Substring(0, 15)
                End If

                If descripcion_tipo = "NOTA DE CREDITO" Then

                    If VarTipo <> "NOTA DE CREDITO SIN IMPUTAR" Then


                        VarTipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")


                        varsaldo = 0
                    Else
                        varsaldo = DS.Tables(DT.TableName).Rows(i).Item("saldo")
                    End If
                End If






                descripcion_tipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")
                If descripcion_tipo.Length > 5 Then
                    descripcion_tipo = descripcion_tipo.Substring(0, 5)
                End If

                If descripcion_tipo = "ABONO" Then

                    If VarTipo <> "ABONO SIN IMPUTAR" Then

                        VarTipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")





                        If descripcion_tipo = "ABONO" Then
                            varsaldo = 0
                        Else
                            varsaldo = DS.Tables(DT.TableName).Rows(i).Item("saldo")
                        End If
                    End If
                End If


                txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(DS.Tables(DT.TableName).Rows(i).Item("saldo"))

                grilla_estado_de_cuenta_final.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
                                          DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("fecha_venta"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("saldo"), _
            txt_total_deuda.Text)

            Next



            grilla_estado_de_cuenta_final.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta_final.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta_final.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta_final.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta_final.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            grilla_estado_de_cuenta.Columns(0).Width = 100
            grilla_estado_de_cuenta.Columns(1).Width = 200
            grilla_estado_de_cuenta.Columns(2).Width = 100
            grilla_estado_de_cuenta.Columns(3).Width = 100
            grilla_estado_de_cuenta.Columns(4).Width = 100

            txt_total_deuda.Text = Format(Int(txt_total_deuda.Text), "###,###,###")

        End If
    End Sub

    Sub sugerir_pago()
        Dim VarNroDoc As String
        Dim VarTipoDoc As String
        Dim VarSaldoDoc As String

        Dim VarAbonoDoc As String
        '  Dim tipo_nota_credito As String

        Dim total_abono As Integer

        grilla_imputar.Rows.Clear()

        total_abono = txt_total_nota_credito.Text

        For i = 0 To grilla_estado_de_cuenta_final.Rows.Count - 1
            VarNroDoc = grilla_estado_de_cuenta_final.Rows(i).Cells(0).Value.ToString
            VarTipoDoc = grilla_estado_de_cuenta_final.Rows(i).Cells(1).Value.ToString
            VarSaldoDoc = grilla_estado_de_cuenta_final.Rows(i).Cells(4).Value.ToString

            If VarTipoDoc = "BOLETA" Or VarTipoDoc = "FACTURA" Then
                If VarSaldoDoc <= total_abono Then

                    VarAbonoDoc = VarSaldoDoc

                    grilla_imputar.Rows.Add(VarTipoDoc, VarNroDoc, VarAbonoDoc, "0", "SIN INGRESAR")

                    total_abono = total_abono - VarSaldoDoc

                    If total_abono <= 0 Then
                        Exit Sub
                    End If
                Else

                    VarAbonoDoc = total_abono

                    VarSaldoDoc = VarSaldoDoc - total_abono

                    grilla_imputar.Rows.Add(VarTipoDoc, VarNroDoc, VarAbonoDoc, VarSaldoDoc, "SIN INGRESAR", mirecintoempresa)

                    Exit Sub

                End If

                calcular_totales()


            End If
        Next

        calcular_totales()
        limpiar_abono()

    End Sub



    Private Sub Combo_cuotas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_cuotas.SelectedIndexChanged
        lbl_mensaje.Visible = True
        Me.Enabled = False

        txt_recinto.Text = ""
        txt_deuda_actual.Text = ""
        txt_deuda_actual_millar.Text = ""

        mostrar_datos_para_pago()

        If Combo_cuotas.Text <> "" And Combo_cuotas.Text <> "-" And txt_recinto.Text = "" Then
            mostrar_datos_para_pago_sucursales()

        End If

        '  txt_abono.Text = ""

        lbl_mensaje.Visible = False
        Me.Enabled = True

        txt_abono.Focus()
    End Sub

    Sub mostrar_datos_para_pago_sucursales()

        combo_factura.Text = ""
        Combo_tipo.Text = ""
        txt_deuda_actual.Text = ""
        txt_fecha.Text = ""
        'txt_tipo.Text = ""
        txt_despues.Text = ""
        ' txt_vencimiento.Text = ""
        ' txt_nro_cuota.Text = ""
        ' txt_total_cuotas.Text = ""
        ' txt_recinto.Text = ""
        'txt_saldo_millar.Text = ""
        txt_abono.Text = ""
        txt_recinto.Text = ""


        If Combo_cuotas.SelectedItem <> "-" Then

            Dim tipo_doc As String = ""
            Dim nro_doc As String = ""
            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = Combo_cuotas.Text

            If Combo_cuotas.Text.Contains("NOTA DE DEBITO") Then
                tabla = Split(cadena, " ")
                For n = 0 To UBound(tabla, 1)
                    tipo_doc = "NOTA DE DEBITO"
                    nro_doc = tabla(3)
                Next
            Else
                tabla = Split(cadena, " ")
                For n = 0 To UBound(tabla, 1)
                    tipo_doc = tabla(0)
                    nro_doc = tabla(1)
                Next
            End If

            'tabla = Split(cadena, " ")
            'For n = 0 To UBound(tabla, 1)
            '    tipo_doc = tabla(0)
            '    nro_doc = tabla(1)
            'Next

            If txt_rut.Text <> "" And txt_recinto.Text = "" And Combo_cuotas.Text <> "-" Then


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
                    '  txt_vencimiento.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_vencimiento")
                    ' txt_nro_cuota.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_cuota")
                    '  txt_total_cuotas.Text = DS.Tables(DT.TableName).Rows(0).Item("total_cuotas")
                    '  txt_recinto.Text = DS.Tables(DT.TableName).Rows(0).Item("recinto")

                    ' ''If txt_deuda_actual.Text = "" Or txt_deuda_actual.Text = "0" Then
                    ' ''    txt_saldo_millar.Text = "0"
                    ' ''Else
                    ' ''    txt_saldo_millar.Text = Format(Int(txt_deuda_actual.Text), "###,###,###")
                    ' ''End If
                    txt_recinto.Text = DS.Tables(DT.TableName).Rows(0).Item("recinto")
                    txt_abono.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
                    ' txt_recinto.Text = DS.Tables(DT.TableName).Rows(0).Item("recinto")

                    If txt_deuda_actual.Text = "" Or txt_deuda_actual.Text = "0" Then
                        txt_deuda_actual_millar.Text = "0"
                    Else
                        txt_deuda_actual_millar.Text = Format(Int(txt_deuda_actual.Text), "###,###,###")
                    End If

                End If

            End If
            conexion.Close()

        End If

    End Sub




End Class