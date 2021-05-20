Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Resources

Public Class Form_imputar_abonos
    Dim total_registros As Integer
    Dim varnumfactura As Integer
    Dim peso As String
    Dim pesos As String
    Private WithEvents Pd As New PrintDocument
    Private Sub Form_imputar_abonos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_imputar_abonos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_imputar_abonos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        controles(False, True)
        mostrar_datos_para_pago()
        mostrar_deuda()
        calcular()
        cargar_logo()
        dtp_emision.CustomFormat = "yyy-MM-dd"

        'TextBox1.Text = ActiveControl.Name
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    'permite bloquear o habilitar los controles.
    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_limpiar.Enabled = a
        btn_guardar.Enabled = a
        btn_cargar.Enabled = a
        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a
        grilla_imputar.Enabled = a

        btn_sugerir.Enabled = a

        btn_nuevo.Enabled = b
        Combo_cuotas.Enabled = a
        combo_factura.Enabled = a
        Combo_tipo.Enabled = a
        btn_limpiar.Enabled = a
        txt_abono.Enabled = a


        GroupBox1.Enabled = a
        GroupBox2.Enabled = a
        GroupBox3.Enabled = a
        GroupBox4.Enabled = a
        GroupBox5.Enabled = a
        GroupBox6.Enabled = a
        GroupBox7.Enabled = a
        GroupBox8.Enabled = a
        GroupBox9.Enabled = a
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
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
            End If
            conexion.Close()
        End If

        If Me.txt_total_abono.Text = "" Or Me.txt_total_abono.Text = "0" Then
            Me.txt_total_abono_millar.Text = "0"
        Else
            Me.txt_total_abono_millar.Text = Format(Int(Me.txt_total_abono.Text), "###,###,###")
        End If
    End Sub

    'mostramos el total y el saldo de la fatura seleccionada.
    Sub mostrar_datos_para_pago()
        'If combo_factura.Text <> "" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    SC.CommandText = "select * from creditos where n_creditos ='" & (combo_factura.Text) & "' AND TIPO ='" & (Combo_tipo.Text) & "' "
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)

        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        txt_deuda_actual.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
        '        txt_fecha.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
        '        txt_despues.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
        '    End If
        '    conexion.Close()
        'End If







        Combo_cuotas.Text = ""
        combo_factura.Text = ""
        Combo_tipo.Text = ""
        txt_deuda_actual.Text = ""
        txt_fecha.Text = ""
        'txt_tipo.Text = ""
        txt_despues.Text = ""
        ' txt_total_abono_millar.Text = ""
        ''txt_vencimiento.Text = ""
        ''txt_nro_cuota.Text = ""
        ''txt_total_cuotas.Text = ""
        ''txt_recinto.Text = ""
        ''txt_saldo_millar.Text = ""
        txt_abono.Text = ""
        txt_recinto.Text = ""
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

            SC.CommandText = "select * from creditos where tipo='" & (tipo_doc) & "' and n_creditos='" & (nro_doc) & "' and rut_cliente='" & (txt_rut.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                combo_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("n_creditos")
                Combo_tipo.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo")
                txt_deuda_actual.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
                txt_fecha.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                txt_despues.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
                ''txt_vencimiento.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_vencimiento")
                ''txt_nro_cuota.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_cuota")
                ''txt_total_cuotas.Text = DS.Tables(DT.TableName).Rows(0).Item("total_cuotas")
                ''txt_recinto.Text = DS.Tables(DT.TableName).Rows(0).Item("recinto")

                ''If txt_deuda_actual.Text = "" Or txt_deuda_actual.Text = "0" Then
                ''    txt_saldo_millar.Text = "0"
                ''Else
                ''    txt_saldo_millar.Text = Format(Int(txt_deuda_actual.Text), "###,###,###")
                ''End If

                txt_abono.Text = DS.Tables(DT.TableName).Rows(0).Item("saldo")
                txt_recinto.Text = DS.Tables(DT.TableName).Rows(0).Item("recinto")


                If txt_deuda_actual.Text = "" Or txt_deuda_actual.Text = "0" Then
                    txt_deuda_actual_millar.Text = "0"
                Else
                    txt_deuda_actual_millar.Text = Format(Int(txt_deuda_actual.Text), "###,###,###")
                End If



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
        SC.CommandText = "select n_creditos from creditos where rut = '" & (txt_rut.Text) & "' and saldo > '0' AND tipo <> 'NOTA DE CREDITO'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    'llenamos el ocmbo facturas segun el rut que este escrito.
    Sub llenar_combo_facturas()



        If txt_rut.Text <> "" Then
            conexion.Close()
            ' combo_factura.Items.Clear()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from creditos where saldo <>'0'  and rut_cliente='" & (txt_rut.Text) & "' and tipo <> 'ABONO' and tipo <> 'NOTA DE CREDITO' and tipo <> 'NOTA DE DEBITO'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                    '  combo_factura.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("n_creditos"))

                    Combo_cuotas.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("tipo") & " " & DS2.Tables(DT2.TableName).Rows(i).Item("n_creditos"))

                Next
            End If
            conexion.Close()
        End If

        'Combo_cuotas.Items.Add("-")
        'Combo_cuotas.SelectedItem = "-"











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
        SC2.CommandText = "select tipo from creditos  where rut_CLIENTE='" & (txt_rut.Text) & "' and TIPO<>'ABONO' and TIPO<>'NOTA DE CREDITO' group by TIPO"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                Combo_tipo.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("tipo"))
            Next
        End If
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
                txt_n_abono.Text = varnumfactura + 1
            End If
        Catch err As InvalidCastException
            txt_n_abono.Text = 1
        End Try
        conexion.Close()
    End Sub


    'Sub crear_numero_documento()
    '    Dim varnumdoc As Integer
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()
    '    Try
    '        SC.Connection = conexion
    '        SC.CommandText = "select max(cod_auto) as cod_auto from abono"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
    '            'txt_factura.Text = varnumdoc + 1
    '        End If
    '    Catch err As InvalidCastException
    '        txt_numero_abono.Text = 1
    '        Exit Sub
    '    End Try
    '    conexion.Close()

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()
    '    Try
    '        SC.Connection = conexion
    '        SC.CommandText = "select n_abono from abono where cod_auto='" & (varnumdoc) & "'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_abono")
    '            txt_numero_abono.Text = varnumdoc + 1
    '        End If
    '    Catch err As InvalidCastException
    '        txt_numero_abono.Text = 1
    '    End Try
    '    conexion.Close()

    'End Sub

    'actualiza el saldo en la tabla total y la tabla factura de credito ademas de guardar el registro de los abonos.
    Sub grabar_abono()
        Dim saldo_abono As String

        saldo_abono = Val(txt_total_abono.Text) - Val(txt_total_imputado.Text)

        If saldo_abono <> 0 Then

            saldo_abono = "-" & saldo_abono
        End If



        SC.Connection = conexion
        SC.CommandText = "update creditos set saldo =  '" & (saldo_abono) & "' where n_creditos = '" & (txt_n_abono.Text) & "' and rut_cliente = '" & (txt_rut.Text) & "' and cod_auto= '" & (txt_cod_auto.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)


        'SC.Connection = conexion
        'SC.CommandText = "update abono set monto_abono =  '" & (saldo_abono) & "' where n_abono = '" & (txt_n_abono.Text) & "'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)

        ' grabar_detalle_abono()

    End Sub

    Sub grabar_detalle_abono()
        Dim VarDocumento As String
        Dim varNroDoc As String
        Dim VarAbono As Integer
        Dim VarSaldo As String
        Dim VarEstado As String
        Dim VarRecinto As String
        '  Dim tipo_nota_credito As String

        For i = 0 To grilla_imputar.Rows.Count - 1
            VarDocumento = grilla_imputar.Rows(i).Cells(0).Value.ToString
            varNroDoc = grilla_imputar.Rows(i).Cells(1).Value.ToString
            VarAbono = grilla_imputar.Rows(i).Cells(2).Value.ToString
            VarSaldo = grilla_imputar.Rows(i).Cells(3).Value.ToString
            VarEstado = grilla_imputar.Rows(i).Cells(4).Value.ToString
            VarRecinto = grilla_imputar.Rows(i).Cells(5).Value.ToString

            If VarEstado = "SIN INGRESAR" Then
                ' tipo_nota_credito = "ABONO A " & (VarDocumento) & " Nº " & (varNroDoc)


                SC.Connection = conexion
                SC.CommandText = "insert into detalle_abono (nro_abono, nro_documento, tipo_documento, monto_abono, saldo_documento, estado, sucursal) values('" & (txt_n_abono.Text) & "','" & (varNroDoc) & "', '" & (VarDocumento) & "','" & (VarAbono) & "','" & (VarSaldo) & "','" & (VarEstado) & "','" & (VarRecinto) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "update creditos set saldo = '" & (VarSaldo) & "' where rut_cliente = '" & (txt_rut.Text) & "' and rut_cliente = '" & (txt_rut.Text) & "' and n_creditos ='" & (varNroDoc) & "'  and TIPO ='" & (VarDocumento) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                'If VarSaldo = 0 Then
                '    SC.Connection = conexion
                '    SC.CommandText = "update creditos set estado = 'PAGADA' where rut_cliente = '" & (txt_rut.Text) & "' and n_creditos ='" & (varNroDoc) & "'  and tipo ='" & (VarDocumento) & "'"
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)
                'End If

                'Dim total_saldo_abono As String

                'total_saldo_abono = Int(txt_total_abono.Text) - Int(txt_total_imputado.Text)

                'total_saldo_abono = "-" & total_saldo_abono
                'SC.Connection = conexion
                'SC.CommandText = "update creditos set SALDO = '" & (total_saldo_abono) & "' where rut_cliente = '" & (txt_rut.Text) & "' and tipo ='ABONO'  and n_creditos ='" & (txt_n_abono.Text) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                'If Int(txt_total_abono.Text) = Int(txt_total_imputado.Text) Then
                '    SC.Connection = conexion
                '    SC.CommandText = "update creditos set  estado = 'PAGADA', SALDO = '0' where rut_cliente = '" & (txt_rut.Text) & "' and n_creditos ='" & (txt_n_abono.Text) & "'  and tipo ='ABONO'"
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)
                'End If




                SC.Connection = conexion
                SC.CommandText = "update creditos set saldo = '" & (VarSaldo) & "', fecha_pago='" & (Form_menu_principal.dtp_fecha.Text) & "' where rut_cliente = '" & (txt_rut.Text) & "' and n_creditos ='" & (varNroDoc) & "'  and tipo ='" & (VarDocumento) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                If VarSaldo = 0 Then
                    SC.Connection = conexion
                    SC.CommandText = "update creditos set estado = 'PAGADA' where rut_cliente = '" & (txt_rut.Text) & "' and CODIGO_AFECTA ='" & (varNroDoc) & "'  and NOMBRE_AFECTA ='" & (VarDocumento) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                '    recuperar_conexion()

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
        ' Dim tipo_abono As String

        '  tipo_abono = "ABONO" & " A " & (Combo_tipo.Text) & " Nº " & (combo_factura.Text)

        If grilla_imputar.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_n_abono.Focus()
            Exit Sub
        End If

        If txt_n_abono.Text = "" Then
            MsgBox("CAMPO NRO. ABONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_n_abono.Focus()
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


        If Int(txt_total_imputado.Text) > Int(txt_total_abono.Text) Then
            MsgBox("EL VALOR IMPUTADO NO PUEDE SER MAYOR AL DEL ABONO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_cliente.Focus()
            Exit Sub
        End If


        lbl_mensaje.Visible = True
        Me.Enabled = False

        grabar_abono()
        grabar_detalle_abono()

        limpiar()
        controles(False, True)

        lbl_mensaje.Visible = False
        Me.Enabled = True

        MsgBox("ABONO GUARDADO CON EXITO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")


    End Sub

    'muestra los datos del cliente seleccionado.
    Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_datos_clientes()
    End Sub

    Private Sub combo_rut_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        combo_factura.Items.Clear()
        Combo_cuotas.Items.Clear()
        llenar_combo_doc()
        mostrar_datos_clientes()
        Form_ver_pagos.Close()
        mostrar_deuda()
    End Sub

    'limpia los datos de la pantalla.
    Sub limpiar()
        combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        txt_rut.Text = ""
        txt_nombre_cliente.Text = ""
        Combo_tipo.Text = ""
        txt_telefono.Text = ""
        txt_abono.Text = ""
        txt_invicible.Text = ""

        txt_total_imputado.Text = "0"
        txt_despues.Text = "0"
        txt_deuda_actual.Text = "0"


        txt_total_imputado_millar.Text = ""
        txt_despues_millar.Text = ""
        txt_deuda_actual_millar.Text = ""



        txt_total_abono_millar.Text = ""


        txt_n_abono.Text = ""
        Combo_cuotas.Items.Clear()
        combo_factura.Items.Clear()
        grilla_imputar.DataSource = Nothing
        grilla_imputar.Rows.Clear()
        dtp_emision.Text = FormatDateTime(Now, DateFormat.ShortDate)
        Me.txt_n_abono.Enabled = True
        Me.txt_rut.Enabled = True
        Me.txt_nombre_cliente.Enabled = True
        '  Me.dtp_emision.Enabled = True
        Me.txt_total_imputado.Enabled = True
    End Sub

    Sub limpiar_datos_cliente()
        Combo_cuotas.Items.Clear()
        combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        Combo_tipo.Text = ""
        txt_telefono.Text = ""
        txt_abono.Text = ""
        txt_total_imputado.Text = "0"
        txt_invicible.Text = ""
        txt_despues.Text = "0"
        txt_deuda_actual.Text = "0"
        txt_n_abono.Text = ""
        combo_factura.Items.Clear()
        grilla_imputar.DataSource = Nothing





        txt_total_imputado_millar.Text = ""
        txt_despues_millar.Text = ""
        txt_deuda_actual_millar.Text = ""
    End Sub

    'limpia los datos de lapantalla.
    Sub limpiar_abono()
        Combo_cuotas.Text = "-"
        Combo_cuotas.Text = "-"
        combo_factura.Text = ""
        Combo_tipo.Text = ""
        txt_invicible.Text = ""
        txt_despues.Text = ""
        txt_deuda_actual.Text = ""
        txt_abono.Text = ""
        If txt_despues.Text = "0" Then
            txt_despues.Text = ""
        End If



        txt_despues.Text = "0"
        txt_deuda_actual.Text = "0"



        txt_despues_millar.Text = ""
        txt_deuda_actual_millar.Text = ""
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






        Dim detalle_referencia As String
        Dim detalle_abono As String
        Dim detalle_saldo As String




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
        condicion_abono = txt_condicion_abono.Text
        detalle_condicion_abono = "DOCUMENTO IMPUTADO"
        cajero_abono = minombre


        If grilla_imputar.Rows.Count = 0 Then
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



        Else




            For i = 0 To grilla_imputar.Rows.Count - 1

                detalle_referencia = grilla_imputar.Rows(i).Cells(0).Value.ToString & " NRO. " & grilla_imputar.Rows(i).Cells(1).Value.ToString
                detalle_abono = grilla_imputar.Rows(i).Cells(2).Value.ToString
                detalle_saldo = grilla_imputar.Rows(i).Cells(3).Value.ToString

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

                dr("detalle_referencia") = detalle_referencia
                dr("abono") = detalle_abono
                dr("saldo") = detalle_saldo
                dr("total_abono") = total_abono


                dr("condicion_abono") = condicion_abono
                dr("detalle_condicion_abono") = detalle_condicion_abono
                dr("cajero_abono") = cajero_abono


                dt.Rows.Add(dr)

            Next
        End If

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

    Private Sub combo_factura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        combo_factura.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub combo_factura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        combo_factura.BackColor = Color.White
    End Sub

    'llama al sub de los datos para pago.
    Private Sub combo_factura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mostrar_datos_para_pago()
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

    Private Sub Combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo_tipo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo_tipo.BackColor = Color.White
    End Sub

    Private Sub Combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'llenar_combo_facturas()
    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.GotFocus
        'txt_rut.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut.KeyPress
        'e.KeyChar = e.KeyChar.ToString.ToUpper

        'If e.KeyChar = "'" Then
        '    e.KeyChar = "´"
        'End If

        'If e.KeyChar = "&" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = Chr(34) Then
        '    e.KeyChar = "´´"
        'End If

        'If e.KeyChar = "\" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "|" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "¿" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "?" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "}" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "{" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "<" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = ">" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "*" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "+" Then
        '    e.KeyChar = ""
        'End If



        'limpiar_datos_cliente()

        'If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
        '    combo_factura.Items.Clear()
        '    llenar_combo_doc()
        '    guion_rut_cliente()
        '    mostrar_datos_clientes()

        '    mostrar_malla()

        '    Form_ver_pagos.Close()
        '    mostrar_deuda()


        'End If
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

    Private Sub btn_ver_pagos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_ver_pagos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
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

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        'txt_rut.BackColor = Color.White
    End Sub

    Private Sub txt_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_abono.LostFocus
        txt_abono.BackColor = Color.White
    End Sub


    Private Sub txt_n_abono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_n_abono.GotFocus
        'txt_n_abono.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_n_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_n_abono.LostFocus
        'txt_n_abono.BackColor = Color.White
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

                    'SC.Connection = conexion
                    'SC.CommandText = "delete from detalle_imputar_ABONO where nro_doc = '" & (VarNroDocumento) & "' and tipo_documento = '" & (VarTipoDocumento) & "' and n_ABONO= '" & (txt_n_abono.Text) & "'"
                    'DA.SelectCommand = SC
                    'DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "delete from detalle_abono where nro_documento = '" & (VarNroDocumento) & "' and tipo_documento = '" & (VarTipoDocumento) & "' and nro_abono= '" & (txt_n_abono.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update abono set monto_abono = monto_abono - " & (VarTotalDocumento) & " where n_abono = '" & (txt_n_abono.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update creditos set saldo = saldo + " & (VarTotalDocumento) & ",  ESTADO = 'EMITIDA' where rut_cliente = '" & (txt_rut.Text) & "'  and n_creditos ='" & (VarNroDocumento) & "'  and tipo_detalle ='" & (VarTipoDocumento) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "delete from creditos where tipo = 'ABONO' and rut_cliente = '" & (txt_rut.Text) & "' and  codigo_afecta= '" & (VarNroDocumento) & "' and nombre_afecta= '" & (VarTipoDocumento) & "' and n_creditos= '" & (txt_n_abono.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    grilla_imputar.Rows.Remove(grilla_imputar.CurrentRow)
                    combo_factura.Focus()
                End If
                combo_factura.Focus()
            End If
        End If
    End Sub

    Private Sub btn_cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar.Click
        conexion.Close()
        Form_cargar_abono_imputar.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub txt_n_abono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_n_abono.TextChanged

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

        If txt_total_abono.Text = "" Then
            MsgBox("CAMPO MONTO ABONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total_abono.Focus()
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

        total_abono = txt_total_abono.Text

        For i = 0 To grilla_estado_de_cuenta_final.Rows.Count - 1
            VarNroDoc = grilla_estado_de_cuenta_final.Rows(i).Cells(0).Value.ToString
            VarTipoDoc = grilla_estado_de_cuenta_final.Rows(i).Cells(1).Value.ToString
            VarSaldoDoc = grilla_estado_de_cuenta_final.Rows(i).Cells(4).Value.ToString

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
                'txt_vencimiento.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_vencimiento")
                'txt_nro_cuota.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_cuota")
                'txt_total_cuotas.Text = DS.Tables(DT.TableName).Rows(0).Item("total_cuotas")
                txt_recinto.Text = DS.Tables(DT.TableName).Rows(0).Item("recinto")
            End If
            conexion.Close()



            If VarTipoDoc = "BOLETA" Or VarTipoDoc = "FACTURA" Then
                If VarSaldoDoc <= total_abono Then

                    VarAbonoDoc = VarSaldoDoc

                    grilla_imputar.Rows.Add(VarTipoDoc, VarNroDoc, VarAbonoDoc, "0", "SIN INGRESAR", txt_recinto.Text)

                    total_abono = total_abono - VarSaldoDoc

                    If total_abono <= 0 Then
                        Exit Sub
                    End If
                Else

                    VarAbonoDoc = total_abono

                    VarSaldoDoc = VarSaldoDoc - total_abono

                    grilla_imputar.Rows.Add(VarTipoDoc, VarNroDoc, VarAbonoDoc, VarSaldoDoc, "SIN INGRESAR", txt_recinto.Text)

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










    Sub consultar_sucursales()

        If mirutempresa = "87686300-6" Then

            llenar_combo_facturas()
            'cargar_documentos_vencidos()
            calcular_totales()


        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_despues_millar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_despues_millar.TextChanged

    End Sub
End Class