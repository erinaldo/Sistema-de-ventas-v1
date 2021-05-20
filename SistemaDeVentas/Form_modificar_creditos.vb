Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Imports System.Resources
Public Class Form_modificar_creditos
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

    Private Sub Form_modificar_creditos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_modificar_creditos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_modificar_creditos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Combo_tipo.Items.Clear()
        Combo_tipo.Items.Add("-")
        Combo_tipo.SelectedItem = "-"
        llenar_combo_rut()
        controles(False, True)
        mostrar_datos_para_pago()
        cargar_logo()
        dtp_emision.CustomFormat = "yyy-MM-dd"
        txt_rut.SelectedItem = "-"
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_emision.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    'permite bloquear o habilitar los controles.
    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_guardar.Enabled = a
        btn_cargar.Enabled = a
        btn_nuevo.Enabled = b
        txt_rut.Enabled = a
        Combo_cuotas.Enabled = a
        txt_abono.Enabled = a
        GroupBox_documento.Enabled = a
        GroupBox_monto.Enabled = a
        GroupBox_nombre.Enabled = a
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
            txt_direccion.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
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
        txt_vencimiento.Text = ""
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
                txt_vencimiento.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_vencimiento")
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
            ' combo_factura.Items.Clear()
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
                    '  combo_factura.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("n_creditos"))
                    Combo_cuotas.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("TIPO") & " " & DS2.Tables(DT2.TableName).Rows(i).Item("n_creditos"))
                Next
            End If
            conexion.Close()
        End If
    End Sub

    Sub llenar_combo_rut()
        conexion.Close()
        txt_rut.Items.Clear()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()
        SC2.Connection = conexion
        SC2.CommandText = "select * from clientes  where rut_cliente like '%PROPIEDAD%' ORDER by rut_cliente"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                txt_rut.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("rut_cliente"))
            Next
        End If
        conexion.Close()
        txt_rut.Items.Add("-")
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

    'actualiza el saldo en la tabla total y la tabla factura de credito ademas de guardar el registro de los abonos.
    Sub grabar_abono()
        fecha()
        SC.Connection = conexion
        SC.CommandText = "update creditos set total= '" & (txt_abono.Text) & "', saldo= '" & (txt_abono.Text) & "' where rut_cliente = '" & (txt_rut.Text) & "' and n_creditos ='" & (combo_factura.Text) & "'  and tipo ='" & (Combo_tipo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
    End Sub

    'si el saldo de la factura es menor a  0 no puede guardarlo.
    'sies amyor o = a 0 graba el pago
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
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
 
        grabar_abono()
        MsgBox("ABONO GUARDADO CON EXITO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        Me.Enabled = True
        limpiar()
    End Sub

    'limpia los datos de la pantalla.
    Sub limpiar()

        combo_factura.Text = "-"
        txt_fecha.Text = ""
        combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        txt_rut.Text = "-"
        txt_nombre_cliente.Text = ""
        Combo_tipo.Text = ""
        txt_direccion.Text = ""
        txt_abono.Text = ""
        txt_invicible.Text = ""
        txt_deuda_actual.Text = "0"
        txt_saldo_millar.Text = ""
        Combo_tipo.Items.Clear()
        Combo_tipo.Items.Add("-")
        Combo_tipo.SelectedItem = "-"
        combo_factura.Items.Clear()
        dtp_emision.Text = FormatDateTime(Now, DateFormat.ShortDate)
        Me.btn_modificar_abono.Enabled = False
        Me.txt_rut.Enabled = True
        Me.txt_nombre_cliente.Enabled = True
        Me.txt_direccion.Enabled = True
        Me.dtp_emision.Enabled = True
    End Sub

    Sub limpiar_datos_cliente()
        combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        Combo_tipo.Text = ""
        txt_direccion.Text = ""
        txt_abono.Text = ""
        txt_invicible.Text = ""
        txt_deuda_actual.Text = "0"
        combo_factura.Items.Clear()
        btn_modificar_abono.Enabled = False
    End Sub

    'limpia los datos de lapantalla.
    Sub limpiar_abono()
        combo_factura.Text = ""
        Combo_tipo.Text = ""
        txt_invicible.Text = ""
        txt_deuda_actual.Text = ""
        txt_abono.Text = ""
        txt_saldo_millar.Text = ""
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
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub Combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo.GotFocus
        Combo_tipo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo.LostFocus
        Combo_tipo.BackColor = Color.White
    End Sub

    Private Sub txt_detalle_ingreso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_rut.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_n_abono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_n_abono.GotFocus
        txt_n_abono.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_n_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_n_abono.LostFocus
        txt_n_abono.BackColor = Color.White
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        txt_abono.Text = ""
        txt_invicible.Text = ""
        txt_deuda_actual.Text = "0"
        txt_saldo_millar.Text = ""
        Combo_tipo.Items.Add("-")
        Combo_tipo.SelectedItem = "-"
        Combo_cuotas.Items.Clear()
        dtp_emision.Text = FormatDateTime(Now, DateFormat.ShortDate)
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            If mirutempresa = "87686300-6" Then
                guion_rut_cliente()
                mostrar_datos_clientes()
                Form_ver_pagos.Close()
                Combo_cuotas.Items.Clear()
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

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
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

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_rut.BackColor = Color.White
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        conexion.Close()
        Me.Enabled = False
        txt_rut.Focus()
        Form_buscador_clientes_abonos.Show()
        Form_buscador_clientes_abonos.txt_busqueda.Focus()
    End Sub

    Private Sub txt_saldo_millar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_saldo_millar.Click
        If txt_deuda_actual.Text <> "" And txt_deuda_actual.Text <> "0" Then
            txt_abono.Text = txt_deuda_actual.Text
            txt_abono.Focus()
        End If
    End Sub

    Private Sub Combo_cuotas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_cuotas.SelectedIndexChanged
        mostrar_datos_para_pago()
        txt_abono.Focus()
    End Sub

    Private Sub txt_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.SelectedIndexChanged
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Combo_cuotas.Items.Clear()
        combo_factura.Text = ""
        txt_codigo_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        Combo_tipo.Text = ""
        txt_direccion.Text = ""
        txt_abono.Text = ""
        txt_invicible.Text = ""
        txt_deuda_actual.Text = "0"
        txt_saldo_millar.Text = ""
        Combo_tipo.Items.Add("-")
        Combo_tipo.SelectedItem = "-"
        Combo_cuotas.Items.Clear()
        dtp_emision.Text = FormatDateTime(Now, DateFormat.ShortDate)
        If mirutempresa = "87686300-6" Then
            mostrar_datos_clientes()
            Combo_cuotas.Items.Clear()
            Combo_cuotas.Items.Add("-")
            Combo_cuotas.SelectedItem = "-"
            llenar_combo_facturas()
            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If

        guion_rut_cliente()
        mostrar_datos_clientes()
        Form_ver_pagos.Close()
        Combo_cuotas.Items.Clear()
        llenar_combo_facturas()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub
End Class