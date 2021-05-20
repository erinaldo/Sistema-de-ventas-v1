Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Math
Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Form_pedidos_or
    Dim total_registros As Integer
    Dim varnumdoc As Integer
    Dim peso As String
    Dim pesos As String
    Dim sin_facturar As String
    Dim VarSeleccion As Integer
    Dim alto_cotizacion As String
    Private WithEvents Pd As New PrintDocument
    Dim cantidad_letras As Integer
    Dim ticket_de_cambio As String

    Private Sub Form_pedidos_or_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        recuperar_conexion()
        Form_menu_principal.WindowState = FormWindowState.Maximized
        Form_menu_principal.Enabled = True
    End Sub

    Private Sub Form_pedidos_or_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F1 Then
            txt_codigo.Focus()
        End If

        If e.KeyCode = Keys.F2 Then
            If grilla_detalle_venta.Rows.Count > 0 Then
                grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.CurrentRow)
                calcular_totales()
                txt_item.Text = grilla_detalle_venta.Rows.Count
                txt_codigo.Focus()
            End If
        End If

        If e.KeyCode = Keys.F5 Then
            txt_rut_cliente.Focus()
        End If

        If e.KeyCode = Keys.F9 Then
            txt_cargar.Focus()
        End If

        If e.KeyCode = Keys.F11 Then
            Combo_venta.Focus()
        End If

        If e.KeyCode = Keys.F12 Then
            If vuelto = "NO" Then
                If txt_porcentaje_desc.Focused = True Then
                    btn_grabar.PerformClick()
                    Exit Sub
                Else
                    txt_porcentaje_desc.Focus()
                    Exit Sub
                End If
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F3 Then
            Dim forms As FormCollection = Application.OpenForms
            Dim i As Integer
            For i = 0 To forms.Count - 1
                Try
                    For Each form As Form In forms
                        If TypeOf form Is Form_venta Then

                        Else
                            form.Close()
                        End If
                    Next
                Catch err As InvalidOperationException
                End Try
            Next i
            Me.Close()
        End If
    End Sub

    Private Sub Form_pedidos_or_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form_menu_principal.Enabled = False
        Try
            conexion.Close()
            conexion.ConnectionString = "server=" & ("orvaldivia.dyndns.org") & "; Database=" & ("bd_or_valdivia") & "; User Id=" & ("sistema_general") & ";Password=" & ("1234") & "; Convert Zero Datetime=True; default command timeout=3600"

            'conexion.Close()
            'conexion.ConnectionString = "Database=bd_papyrus; Data Source= localhost; User Id=root; Password=1234; Convert Zero Datetime=True; default command timeout=3600"


        Catch mierror As MySqlException
            conexion.Close()
            'conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
            'tipo_conexion = "REMOTA"
        Catch mierror As MissingManifestResourceException
            conexion.Close()
            'conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
            'tipo_conexion = "REMOTA"
        End Try


        'limpiar()
        cargar_logo()
        mostrar_datos_clientes()
        controles(False, True)
        'txt_porcentaje_desc.Text = valor_descuento_ventas

        'If mirecintoempresa <> "BDO. O´HIGGINS 441" Then
        '    Picture_call_center.Visible = False
        '    lbl_asistencia.Visible = False
        'End If

        'If mirecintoempresa = "BDO. O´HIGGINS 441" Then
        '    Picture_call_center.Visible = True
        '    lbl_asistencia.Visible = True
        '    Picture_call_center.Location = New Point(205, 4)
        '    lbl_asistencia.Location = New Point(260, 5)
        '    Picture_call_center.Enabled = True
        'End If

        'If mirutempresa = "81921000-4" Then
        txt_porcentaje_desc.Enabled = False
        Combo_venta.Items.Clear()
        Combo_venta.Items.Add("PEDIDO")


        Combo_venta.SelectedItem = "PEDIDO"
        'End If

        combo_condiciones.SelectedItem = "TRASLADO"

        'If mirutempresa <> "81921000-4" Then
        '    Combo_venta.Items.Clear()
        '    Combo_venta.Items.Add("BOLETA")
        '    Combo_venta.Items.Add("BOLETA DE CREDITO")
        '    Combo_venta.Items.Add("COTIZACION")
        '    Combo_venta.Items.Add("GUIA")
        '    Combo_venta.Items.Add("FACTURA")
        '    Combo_venta.Items.Add("FACTURA DE CREDITO")
        '    Combo_venta.SelectedItem = "BOLETA"
        'End If


        mostrar_datos_login()

        'cargar_documento_temporal()
        txt_codigo.Focus()
        'Timer_ventas.Start()
        dtp_fecha.CustomFormat = "yyy-MM-dd"
        Me.btn_nueva.PerformClick()
        'TextBox1.Text = ActiveControl.Name
    End Sub

    Sub mostrar_datos_login()
        Me.txt_nombre_usuario.Text = minombre
        Me.txt_rut_vendedor.Text = miusuario
    End Sub

    Sub llenar_combo_condiciones()
        combo_condiciones.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from combo_condiciones order by nombre"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            combo_condiciones.Items.Add("-")
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_condiciones.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre"))
            Next
        End If
        conexion.Close()

        If Combo_venta.Text = "PEDIDO" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("EFECTIVO")
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.Items.Add("TRANSFERENCIA")
            combo_condiciones.Items.Add("CHEQUE AL DIA")
            combo_condiciones.Items.Add("CHEQUE 15 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30 DIAS")
            combo_condiciones.Items.Add("CHEQUE 45 DIAS")
            combo_condiciones.Items.Add("CHEQUE 60 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30-60 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30-60-90 DIAS")
            combo_condiciones.Items.Add("CHEQUE 37-60-90 DIAS")
            combo_condiciones.Items.Add("CHEQUE 20-40 DIAS")
            combo_condiciones.Items.Add("-")
            combo_condiciones.SelectedItem = "-"
        End If

        If Combo_venta.Text = "FACTURA" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("EFECTIVO")
            combo_condiciones.Items.Add("ABCDIN")
            combo_condiciones.Items.Add("CENCOSUD")
            combo_condiciones.Items.Add("C&D")
            combo_condiciones.Items.Add("PRESTO")
            combo_condiciones.Items.Add("RIPLEY")
            combo_condiciones.Items.Add("VISA")
            combo_condiciones.Items.Add("MASTERCARD")
            combo_condiciones.Items.Add("BANCARIA")
            combo_condiciones.Items.Add("REDCOMPRA")
            combo_condiciones.Items.Add("TRANSFERENCIA")
            combo_condiciones.Items.Add("CHEQUE AL DIA")
            combo_condiciones.Items.Add("CHEQUE 15 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30 DIAS")
            combo_condiciones.Items.Add("CHEQUE 45 DIAS")
            combo_condiciones.Items.Add("CHEQUE 60 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30-60 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30-60-90 DIAS")
            combo_condiciones.Items.Add("CHEQUE 37-60-90 DIAS")
            combo_condiciones.Items.Add("CHEQUE 20-40 DIAS")
            combo_condiciones.Items.Add("PENDIENTE")
            combo_condiciones.Items.Add("LETRAS")
            combo_condiciones.Items.Add("-")
            combo_condiciones.SelectedItem = "-"
        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.SelectedItem = "CREDITO"
        End If


        If Combo_venta.SelectedItem = "GUIA" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.Items.Add("TRASLADO")
            combo_condiciones.SelectedItem = "CREDITO"
        End If

        If Combo_venta.Text = "BOLETA" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("EFECTIVO")
            combo_condiciones.Items.Add("ABCDIN")
            combo_condiciones.Items.Add("CENCOSUD")
            combo_condiciones.Items.Add("C&D")
            combo_condiciones.Items.Add("PRESTO")
            combo_condiciones.Items.Add("RIPLEY")
            combo_condiciones.Items.Add("VISA")
            combo_condiciones.Items.Add("MASTERCARD")
            combo_condiciones.Items.Add("BANCARIA")
            combo_condiciones.Items.Add("REDCOMPRA")
            combo_condiciones.Items.Add("TRANSFERENCIA")
            combo_condiciones.Items.Add("CHEQUE AL DIA")
            combo_condiciones.Items.Add("CHEQUE 15 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30 DIAS")
            combo_condiciones.Items.Add("CHEQUE 45 DIAS")
            combo_condiciones.Items.Add("CHEQUE 60 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30-60 DIAS")
            combo_condiciones.Items.Add("CHEQUE 30-60-90 DIAS")
            combo_condiciones.Items.Add("PENDIENTE")
            combo_condiciones.Items.Add("TRANSFERENCIA")
            combo_condiciones.Items.Add("LETRAS")
            combo_condiciones.Items.Add("-")
            combo_condiciones.SelectedItem = "-"
        End If

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.SelectedItem = "CREDITO"
        End If

        If Combo_venta.Text = "COTIZACION" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CONTADO")
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.Items.Add("CREDITO A 30 DIAS")
            combo_condiciones.Items.Add("CREDITO A 60 DIAS")
            combo_condiciones.Items.Add("CREDITO A 90 DIAS")
            combo_condiciones.SelectedItem = "CONTADO"
        End If
    End Sub

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

    Sub limpiar_datos_clientes()
        txt_nombre_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_descuento_cliente.Text = ""
        txt_giro_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_telefono.Text = ""
        txt_descuento_cliente_2.Text = ""
        txt_orden_de_compra.Text = ""
        txt_tipo_documento.Text = ""
        txt_saldo.Text = "0"
    End Sub

    Sub cargar_documento()
        Dim nombre As String
        Dim valor As String
        Dim descuento As String
        Dim total As String
        Dim subtotal As String
        grilla_detalle_venta.Rows.Clear()

        If Combo_venta.Text = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura where detalle_factura.n_factura='" & (txt_cargar.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    nombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    valor = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")

                    If nombre.Length > 4 Then
                        nombre = nombre.Substring(0, 4)
                    End If

                    If nombre Like "GUIA" Then
                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        descuento = 0
                        valor = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        subtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                    Else
                        valor = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        descuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                        subtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    End If

                    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                    valor, _
                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                    subtotal, _
                    DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                    descuento, _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from clientes, factura where cod_cliente = factura.codigo_cliente and factura.n_factura='" & (txt_cargar.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                    txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                    txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                    txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                    txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                    txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
                    txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
                    txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                    txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
                    txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                    txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                    txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                    txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                    txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                    txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                    txt_saldo.Text = Val(DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")) - Val(DS.Tables(DT.TableName).Rows(0).Item("saldo_cliente"))
                    conexion.Close()
                End If
            End If
        End If

        grilla_detalle_venta.Columns(0).Width = 85
        grilla_detalle_venta.Columns(1).Width = 220
        grilla_detalle_venta.Columns(2).Width = 195
        grilla_detalle_venta.Columns(3).Width = 85
        grilla_detalle_venta.Columns(4).Width = 85
        grilla_detalle_venta.Columns(5).Width = 85
        grilla_detalle_venta.Columns(6).Width = 85
        grilla_detalle_venta.Columns(7).Width = 85
        grilla_detalle_venta.Columns(8).Width = 36
        grilla_detalle_venta.Columns(9).Width = 85
        grilla_detalle_venta.Columns(10).Width = 85
    End Sub

    Sub mostrar_datos_clientes()
        conexion.Close()

        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from clientes where rut_cliente ='81921000-4' and direccion_cliente ='" & (mirecintoempresa) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count = 1 Then
            txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
            txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
            txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
            txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
            txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
            txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
            txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
            txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
            txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
            txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
            txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
            txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
            txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
            txt_saldo.Text = Val(DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")) - Val(DS.Tables(DT.TableName).Rows(0).Item("saldo_cliente"))

            If Val(txt_porcentaje_desc.Text) < Val(txt_descuento_cliente.Text) Then
                txt_porcentaje_desc.Text = txt_descuento_cliente.Text
            End If
            conexion.Close()
            btn_mensaje_cliente.PerformClick()
            Exit Sub
        ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
            conexion.Close()
            Form_seleccionar_cuenta.Show()
            Me.Enabled = False
            Exit Sub
        ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
            MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
            txt_rut_cliente.Focus()
            conexion.Close()
        End If

    End Sub

    Sub mostrar_datos_clientes_por_codigo()
        conexion.Close()
        If txt_cod_cliente.Text <> "" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes where cod_cliente ='" & (txt_cod_cliente.Text) & "' and rut_cliente='" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
                txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                txt_saldo.Text = Val(DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")) - Val(DS.Tables(DT.TableName).Rows(0).Item("saldo_cliente"))
            End If
        End If
    End Sub

    Sub mostrar_nombre_proveedor()
        conexion.Close()
        If txt_proveedor.Text <> "" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            txt_nombre_proveedor.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_productos()
        If txt_codigo.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
            End If
            conexion.Close()
        End If
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a
        combo_condiciones.Enabled = a
        txt_codigo.Enabled = a
        txt_rut_cliente.Enabled = a
        btn_grabar.Enabled = a
        btn_limpiar.Enabled = a
        btn_nueva.Enabled = b
        Combo_venta.Enabled = b
        btn_imagen.Enabled = a
        btn_buscar_clientes.Enabled = a
        btn_buscar_productos.Enabled = a
        btn_agregar_clientes.Enabled = a
        txt_cargar.Enabled = a
        txt_cantidad_agregar.Enabled = a
        txt_porcentaje_desc.Enabled = a
        txt_codigo.Enabled = a
        txt_rut_cliente.Enabled = a
        txt_nombre_producto.Enabled = a
        Combo_venta.Enabled = a
        txt_nro_orden_de_compra.Enabled = a
        txt_precio_modificado.Enabled = a
        GroupBox_cargar.Enabled = a
        GroupBox_clientes.Enabled = a
        GroupBox_descuento.Enabled = a
        GroupBox_producto.Enabled = a
        GroupBox_tipo_venta.Enabled = a
        GroupBox_totales.Enabled = a
        grilla_detalle_venta.Enabled = a

        If txt_precio_modificado.Enabled = True Then
            txt_precio_modificado.BackColor = Color.White
        Else
            txt_precio_modificado.BackColor = SystemColors.Control
        End If

        'If txt_rut_cliente.Enabled = True Then
        '    txt_rut_cliente.BackColor = Color.White
        'Else
        '    txt_rut_cliente.BackColor = SystemColors.Control
        'End If

        If txt_codigo.Enabled = True Then
            txt_codigo.BackColor = Color.White
        Else
            txt_codigo.BackColor = SystemColors.Control
        End If

        If txt_cantidad_agregar.Enabled = True Then
            txt_cantidad_agregar.BackColor = Color.White
        Else
            txt_cantidad_agregar.BackColor = SystemColors.Control
        End If

        If txt_cargar.Enabled = True Then
            txt_cargar.BackColor = Color.White
        Else
            txt_cargar.BackColor = SystemColors.Control
        End If

        If txt_porcentaje_desc.Enabled = True Then
            txt_porcentaje_desc.BackColor = Color.White
        Else
            txt_porcentaje_desc.BackColor = SystemColors.Control
        End If

        If combo_condiciones.Enabled = True Then
            combo_condiciones.BackColor = Color.White
        Else
            combo_condiciones.BackColor = SystemColors.Control
        End If

        If Combo_venta.Enabled = True Then
            Combo_venta.BackColor = Color.White
        Else
            Combo_venta.BackColor = SystemColors.Control
        End If
    End Sub

    Sub limpiar()
        txt_cantidad.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_iva.Text = ""
        txt_marca.Text = ""
        txt_neto.Text = ""
        lbl_codigo.Text = "nada"
        txt_nombre_cliente.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        txt_sub_total.Text = ""
        txt_factor.Text = ""
        txt_rut_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_codigo.Text = ""
        txt_descuento_cliente.Text = ""
        txt_desc.Text = ""
        txt_total.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_porcentaje_desc.Text = ""
        txt_rut_cliente.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_giro_cliente.Text = ""
        txt_telefono.Text = ""
        txt_ciudad_cliente.Text = ""
        txt_correo_cliente.Text = ""
        txt_aplicacion.Text = ""
        txt_descuento_cliente_2.Text = ""
        txt_nombre_usuario.Text = minombre
        txt_orden_de_compra.Text = ""
        grilla_detalle_venta.Rows.Clear()
        txt_item.Text = "0"
        txt_codigo.Text = ""
        txt_rut_cliente.Text = ""
        txt_tipo_documento.Text = ""
        Combo_venta.Text = ""
        combo_condiciones.Text = ""
        Combo_venta.Text = "BOLETA"
        combo_condiciones.Text = "EFECTIVO"
        txt_sub_total_millar.Text = ""
        txt_neto_millar.Text = ""
        txt_iva_millar.Text = ""
        txt_desc_millar.Text = ""
        txt_total_millar.Text = ""
        txt_desc_total.Text = "0"
        txt_saldo.Text = "0"
        txt_nro_orden_de_compra.Text = ""
        txt_codigo.Focus()
    End Sub

    Sub limpiar_datos_productos()
        txt_cantidad.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        txt_factor.Text = ""
        txt_numero_tecnico.Text = ""
        txt_marca.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
    End Sub

    Sub crear_numero_documento()
        If Combo_venta.Text = "COTIZACION" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from cotizacion"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
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
                SC.CommandText = "select n_cotizacion from cotizacion where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_cotizacion")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If


        If Combo_venta.Text = "PEDIDO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from pedidos_vendedor where tipo_impresion <> 'DIGITADA'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
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
                SC.CommandText = "select n_pedidos_vendedor from pedidos_vendedor where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_pedidos_vendedor")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If
    End Sub

    Private Sub combo_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
            limpiar_datos_productos()
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            txt_rut_cliente.Focus()

        ElseIf (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_productos()
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            txt_cantidad_agregar.Focus()
        End If
    End Sub

    Private Sub combo_codigo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_cantidad_real()
    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calcular_totales()
        controles(True, False)
        txt_codigo.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Sub venta()
        Dim iva As Long
        Dim neto As Long
        Dim total As Long
        Dim codigo As String
        Dim cantidad As Integer
        Dim desc As String
        Dim porcentaje_desc As String
        Dim subtotal As Long
        Dim iva_valor As String
        Dim precio_lista As String
        Dim cantidad_agregar As String = Trim(txt_cantidad_agregar.Text)

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Text = 0
        End If

        If txt_cantidad_agregar.Text = " " Then
            txt_cantidad_agregar.Text = 0
        End If

        If txt_cantidad_agregar.TextLength = 0 Then
            txt_cantidad_agregar.Text = 0
        End If
        If txt_cantidad_agregar.Text = " " Then
            txt_cantidad_agregar.Text = 0
        End If

        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))

        If txt_precio.Text = "NeuN" Then
            txt_precio.Text = "0"
        End If

        If txt_precio_modificado.Text = "NeuN" Then
            txt_precio_modificado.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "NeuN" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad.Text = "NeuN" Then
            txt_cantidad.Text = "0"
        End If

        If IsNumeric(txt_precio.Text) = False Then
            txt_precio.Text = "0"
        End If

        If IsNumeric(txt_precio_modificado.Text) = False Then
            txt_precio_modificado.Text = "0"
        End If

        If IsNumeric(txt_cantidad_agregar.Text) = False Then
            txt_cantidad_agregar.Text = "0"
        End If

        If IsNumeric(txt_cantidad.Text) = False Then
            txt_cantidad.Text = "0"
        End If

        If txt_precio.Text = "Infinito" Then
            txt_precio.Text = "0"
        End If

        If txt_precio_modificado.Text = "Infinito" Then
            txt_precio_modificado.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "Infinito" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad.Text = "Infinito" Then
            txt_cantidad.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "" Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = " " Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = " " Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = " " Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = "0" Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If

        If txt_nombre_producto.Text = "" Then
            MsgBox("VERIFIQUE EL CODIGO INGRESADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_producto.Focus()
            Exit Sub
        End If

        If txt_codigo.Text = "*" Then
            If txt_cantidad.Text = "" Then
                txt_cantidad.Text = "0"
            End If

            If txt_precio.Text = "" Then
                txt_precio.Text = "0"
            End If

            If txt_precio_modificado.Text = "" Then
                txt_precio_modificado.Text = "0"
            End If

            porcentaje_desc = "0"
            desc = "0"

            subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
            iva_valor = valor_iva / 100 + 1
            neto = (subtotal / iva_valor)
            iva = (neto) * valor_iva / 100
            total = subtotal - desc

            grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)
            calcular_totales()
            limpiar_datos_productos()
            txt_codigo.Text = ""
            txt_codigo.Focus()
            Exit Sub
        End If

        Try
            For i = 0 To grilla_detalle_venta.Rows.Count - 1
                codigo = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString

                cantidad = Val(grilla_detalle_venta.Rows(i).Cells(4).Value.ToString)
                If codigo = txt_codigo.Text Then
                    grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.Rows(i))

                    If ingreso_rapido = "SI" Then
                        txt_cantidad_agregar.Text = cantidad + CInt(txt_cantidad_agregar.Text)
                    End If
                    Exit For
                End If
            Next

            If txt_cantidad.Text = "" Then
                txt_cantidad.Text = "0"
            End If

            If txt_precio.Text = "" Then
                txt_precio.Text = "0"
            End If

            If txt_precio_modificado.Text = "" Then
                txt_precio_modificado.Text = "0"
            End If

            porcentaje_desc = "0"
            desc = "0"

            If Int(txt_precio.Text) > Int(txt_precio_modificado.Text) Then
                porcentaje_desc = (txt_precio.Text - txt_precio_modificado.Text)
                porcentaje_desc = (porcentaje_desc * 100)
                porcentaje_desc = (porcentaje_desc / txt_precio.Text)
                desc = (txt_precio.Text - txt_precio_modificado.Text)
                desc = (desc * txt_cantidad_agregar.Text)

                If porcentaje_desc.Length > 4 Then
                    porcentaje_desc = porcentaje_desc.Substring(0, 4)
                End If

                Dim porcentaje_desc_2 As Integer
                Dim porcentaje_desc_3 As String

                porcentaje_desc_2 = porcentaje_desc

                If porcentaje_desc_2 = "100" Then
                    MsgBox("EL PRECIO DE ESTE PRODUCTO NO PUEDE SER TAN BAJO", 0 + 16, "ERROR")
                    Exit Sub
                End If

                porcentaje_desc = porcentaje_desc_2
                porcentaje_desc_3 = porcentaje_desc_2 / 100
                porcentaje_desc_3 = 1 - porcentaje_desc_3
                txt_precio.Text = Int(txt_precio_modificado.Text / porcentaje_desc_3)

                If txt_precio.Text = "Infinito" Then
                    txt_precio.Text = "1"
                End If

                If txt_precio.Text = "NeuN" Then
                    txt_precio.Text = "1"
                End If

                desc = (txt_precio.Text - txt_precio_modificado.Text)
                desc = (desc * txt_cantidad_agregar.Text)

                If txt_precio.Text = "Infinito" Then
                    txt_precio.Text = "1"
                    desc = 0
                End If

                If txt_precio.Text = "NeuN" Then
                    txt_precio.Text = "1"
                    desc = 0
                End If
            End If

            If Int(txt_precio.Text) < Int(txt_precio_modificado.Text) Then
                subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
                precio_lista = txt_precio_modificado.Text
            Else
                subtotal = (txt_precio.Text * txt_cantidad_agregar.Text)
                precio_lista = txt_precio.Text
            End If

            iva_valor = valor_iva / 100 + 1
            neto = (subtotal / iva_valor)
            iva = (neto) * valor_iva / 100
            total = subtotal - desc

            grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, precio_lista, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

            calcular_totales()
            limpiar_datos_productos()
            txt_codigo.Text = ""
            txt_codigo.Focus()

        Catch err As InvalidCastException
            MsgBox("VERIFIQUE EL CODIGO INGRESADO", 0 + 16, "ERROR")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End Try
    End Sub

    Sub mostrar_cantidad_real()
        conexion.Close()
        Dim cantidad_caracteres As Integer
        cantidad_caracteres = Len(txt_codigo.Text)
        If cantidad_caracteres <= 6 Then
            If txt_codigo.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto='" & (txt_codigo.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                    txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                    txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    If grilla_detalle_venta.Rows.Count > 0 Then
                        For i = 0 To grilla_detalle_venta.Rows.Count - 1
                            Dim codigo = grilla_detalle_venta.Rows(i).Cells(0).Value
                            Dim cantidad2 = grilla_detalle_venta.Rows(i).Cells(4).Value
                            If codigo = txt_codigo.Text Then
                                txt_cantidad.Text = Int(txt_cantidad.Text) - Int(cantidad2)
                            End If
                        Next
                        conexion.Close()
                    End If
                End If
            End If
        Else
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from codigos_de_barra where codigo_barra='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_interno")
            End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                If grilla_detalle_venta.Rows.Count > 0 Then
                    For i = 0 To grilla_detalle_venta.Rows.Count - 1
                        Dim codigo = grilla_detalle_venta.Rows(i).Cells(0).Value
                        Dim cantidad2 = grilla_detalle_venta.Rows(i).Cells(4).Value
                        If codigo = txt_codigo.Text Then
                            txt_cantidad.Text = Int(txt_cantidad.Text) - Int(cantidad2)
                        End If
                    Next
                End If
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub btn_agregar_ChangeUICues(ByVal sender As Object, ByVal e As System.Windows.Forms.UICuesEventArgs) Handles btn_agregar.ChangeUICues
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim mensaje As String = ""

        Dim cadena As String = txt_cantidad_agregar.Text
        Dim inicioCadena As String = cadena(0).ToString()
        Dim finCadena As String = cadena(cadena.Length - 1).ToString()

        If Not IsNumeric(inicioCadena) Then
            MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If
        If Not IsNumeric(finCadena) Then
            MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txt_cantidad_agregar.Text) Then
            MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If


















        If txt_precio.Text = "NeuN" Then
            txt_precio.Text = "0"
        End If

        If txt_precio_modificado.Text = "NeuN" Then
            txt_precio_modificado.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "NeuN" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad.Text = "NeuN" Then
            txt_cantidad.Text = "0"
        End If

        If IsNumeric(txt_precio.Text) = False Then
            txt_precio.Text = "0"
        End If

        If IsNumeric(txt_precio_modificado.Text) = False Then
            txt_precio_modificado.Text = "0"
        End If

        If IsNumeric(txt_cantidad_agregar.Text) = False Then
            txt_cantidad_agregar.Text = "0"
        End If

        If IsNumeric(txt_cantidad.Text) = False Then
            txt_cantidad.Text = "0"
        End If

        If txt_precio.Text = "NeuNInfinito Then" Then
            txt_precio.Text = "0"
        End If

        If txt_precio_modificado.Text = "Infinito" Then
            txt_precio_modificado.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "Infinito" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad.Text = "Infinito" Then
            txt_cantidad.Text = "0"
        End If



        If txt_codigo.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = "" Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = "0" Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End If

        If txt_nombre_producto.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_venta.Text = "" Then
            mensaje = "CAMPO DOCUMENTO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            Combo_venta.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If Combo_venta.Text <> "BOLETA" And Combo_venta.Text <> "BOLETA DE CREDITO" And Combo_venta.Text <> "FACTURA" And Combo_venta.Text <> "FACTURA DE CREDITO" And Combo_venta.Text <> "GUIA" And Combo_venta.Text <> "COTIZACION" And Combo_venta.Text <> "ASISTENCIA" Then
        '    Combo_venta.Focus()
        '    MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If




        If txt_codigo.Text <> "*" Then
            If venta_sin_stock = "NO" Then
                If Val(txt_cantidad_agregar.Text) > Val(txt_cantidad.Text) Then
                    txt_cantidad_agregar.Text = ""
                    txt_cantidad_agregar.Focus()
                    MsgBox("SALDO STOCK NO ES SUFICIENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
            End If
        End If

        If txt_cantidad_agregar.Text = "*" Then
            If txt_nombre_producto.Text = "" Then
                txt_nombre_producto.Focus()
                MsgBox("CAMPO NOMBRE PRODUCTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_precio_modificado.Text = "" Then
                txt_precio_modificado.Focus()
                MsgBox("CAMPO PRECIO VENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_cantidad_agregar.Text = "" Then
                txt_cantidad_agregar.Focus()
                MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_codigo.Text = "*" Then
                Combo_venta.Text = "COTIZACION"
            End If















            If Combo_venta.Text = "COTIZACION" Then
                If grilla_detalle_venta.Rows.Count < limite_cotizacion Then
                    venta()
                    txt_item.Text = grilla_detalle_venta.Rows.Count
                    mostrar_cantidad_real()
                    txt_cantidad_agregar.Text = ""
                    Exit Sub
                Else
                    MsgBox("NO PUEDE AGREGAR MAS PRODUCTOS", 0 + 16, "ERROR")
                    Exit Sub
                End If
            End If
            Exit Sub
        End If

        If Combo_venta.Text = "PEDIDO" Then
            If grilla_detalle_venta.Rows.Count < limite_boletas Then
                venta()
                txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                Exit Sub
            Else
                MsgBox("NO PUEDE AGREGAR MAS PRODUCTOS", 0 + 16, "ERROR")
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "BOLETA" Then
            If grilla_detalle_venta.Rows.Count < limite_boletas Then
                venta()
                txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                Exit Sub
            Else
                MsgBox("NO PUEDE AGREGAR MAS PRODUCTOS", 0 + 16, "ERROR")
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "COTIZACION" Then
            If grilla_detalle_venta.Rows.Count < limite_cotizacion Then
                venta()
                txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                Exit Sub
            Else
                MsgBox("NO PUEDE AGREGAR MAS PRODUCTOS", 0 + 16, "ERROR")
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "FACTURA" Then
            If grilla_detalle_venta.Rows.Count < limite_facturas Then
                venta()
                txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                Exit Sub
            Else
                MsgBox("NO PUEDE AGREGAR MAS PRODUCTOS", 0 + 16, "ERROR")
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            If grilla_detalle_venta.Rows.Count < limite_facturas Then
                venta()
                txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                Exit Sub
            Else
                MsgBox("NO PUEDE AGREGAR MAS PRODUCTOS", 0 + 16, "ERROR")
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "GUIA" Then
            If grilla_detalle_venta.Rows.Count < limite_guias Then
                venta()
                txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                Exit Sub
            Else
                MsgBox("NO PUEDE AGREGAR MAS PRODUCTOS", 0 + 16, "ERROR")
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "ASISTENCIA" Then
            If grilla_detalle_venta.Rows.Count < limite_boletas Then
                venta()
                txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                Exit Sub
            Else
                MsgBox("NO PUEDE AGREGAR MAS PRODUCTOS", 0 + 16, "ERROR")
                Exit Sub
            End If
        End If
    End Sub

    Sub calcular_totales()
        Dim descgrilla As Long
        Dim netogrilla As Long
        Dim ivagrilla As Long
        Dim totalgrilla As Long
        Dim subtotalgrilla As Long

        'Calcular el descuento
        txt_desc_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            descgrilla = Val(grilla_detalle_venta.Rows(i).Cells(9).Value.ToString)
            txt_desc_total.Text = Val(txt_desc_total.Text) + Val(descgrilla)
        Next

        'Calcular el total neto
        txt_neto.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            netogrilla = Val(grilla_detalle_venta.Rows(i).Cells(5).Value.ToString)
            txt_neto.Text = Val(txt_neto.Text) + Val(netogrilla)
        Next

        'Calcular el total iva
        txt_iva.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            ivagrilla = Val(grilla_detalle_venta.Rows(i).Cells(6).Value.ToString)
            txt_iva.Text = Val(txt_iva.Text) + Val(ivagrilla)
        Next

        'Calcular el sub-total
        txt_sub_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            subtotalgrilla = Val(grilla_detalle_venta.Rows(i).Cells(10).Value.ToString)
            txt_sub_total.Text = Val(txt_sub_total.Text) + Val(subtotalgrilla)
        Next

        'Calcular el total general
        txt_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            totalgrilla = Val(grilla_detalle_venta.Rows(i).Cells(10).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        Dim descuento_porcentaje As Integer
        Dim porcentaje_desc As Integer

        If txt_porcentaje_desc.Text = "" Or txt_porcentaje_desc.Text = "-" Then
            porcentaje_desc = 0
        Else
            porcentaje_desc = txt_porcentaje_desc.Text
        End If

        Try
            descuento_porcentaje = ((txt_total.Text) * porcentaje_desc) / 100
            txt_desc.Text = descuento_porcentaje
            txt_total.Text = Int(txt_sub_total.Text) - Int(txt_desc.Text)
        Catch err As OverflowException
            txt_precio_modificado.Text = txt_precio.Text
            txt_cantidad_agregar.Text = "1"

            For i = 0 To grilla_detalle_venta.Rows.Count - 1
                Dim codigo As String
                codigo = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                If codigo = txt_codigo.Text Then
                    grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.Rows(i))
                    Exit For
                End If
            Next

            MsgBox("VERIFIQUE EL PRECIO Y LA CANTIDAD INGRESADA AL PRODUCTO", 0 + 16, "ERROR")
            calcular_totales()
            txt_precio_modificado.Focus()
            Exit Sub
        End Try

        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String

        Try
            iva_valor = valor_iva / 100 + 1
            neto = (txt_total.Text / iva_valor)
            Round(neto)
            txt_neto.Text = neto

            iva = ((txt_neto.Text) * valor_iva / 100)
            Round(iva)
            txt_iva.Text = iva

        Catch err As OverflowException
            txt_precio_modificado.Text = txt_precio.Text
            txt_cantidad_agregar.Text = "1"

            For i = 0 To grilla_detalle_venta.Rows.Count - 1
                Dim codigo As String
                codigo = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                If codigo = txt_codigo.Text Then
                    grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.Rows(i))
                    Exit For
                End If
            Next

            MsgBox("VERIFIQUE EL PRECIO Y LA CANTIDAD INGRESADA AL PRODUCTO", 0 + 16, "ERROR")
            calcular_totales()
            txt_precio_modificado.Focus()
            Exit Sub
        End Try

        redondear_documento()

        iva_valor = valor_iva / 100 + 1
        txt_neto.Text = Round(txt_total.Text / iva_valor)
        txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)
        txt_iva.Text = (txt_total.Text) - (txt_neto.Text)

        peso = " PESOS"
        If CInt(txt_total.Text) = 1000000 Then
            desglose_valor = Num2Text(txt_total.Text) & " DE PESOS"
        ElseIf CInt(txt_total.Text) = 2000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 3000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 4000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 5000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 6000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 7000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 8000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 9000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 10000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 11000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 12000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 13000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 14000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 15000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 16000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 17000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 18000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 19000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 20000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 21000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 22000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 23000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 24000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 25000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 26000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 27000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 28000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 29000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 30000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        Else
            desglose_valor = Num2Text(txt_total.Text) & peso
        End If

        If grilla_detalle_venta.Rows.Count <> 0 Then
            txt_item.Text = grilla_detalle_venta.Rows.Count
        End If

        If txt_sub_total.Text = "" Or txt_sub_total.Text = "0" Then
            txt_sub_total_millar.Text = "0"
        Else
            txt_sub_total_millar.Text = Format(Int(txt_sub_total.Text), "###,###,###")
        End If
        If txt_desc.Text = "" Or txt_desc.Text = "0" Then
            txt_desc_millar.Text = "0"
        Else
            txt_desc_millar.Text = Format(Int(txt_desc.Text), "###,###,###")
        End If
        If txt_neto.Text = "" Or txt_neto.Text = "0" Then
            txt_neto_millar.Text = "0"
        Else
            txt_neto_millar.Text = Format(Int(txt_neto.Text), "###,###,###")
        End If
        If txt_iva.Text = "" Or txt_iva.Text = "0" Then
            txt_iva_millar.Text = "0"
        Else
            txt_iva_millar.Text = Format(Int(txt_iva.Text), "###,###,###")
        End If
        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub

    Sub redondear_documento()
        If combo_condiciones.Text <> "PAGO COMBINADO" Then
            Dim iva_valor As String
            Dim valor_total As Integer
            valor_total = txt_total.Text
            Dim finTotal As Integer
            Dim numerofinal As Integer

            finTotal = Strings.Right(valor_total, 2)
            numerofinal = Strings.Right(valor_total, 1)

            If numerofinal = 0 Then
            End If

            If Combo_venta.Text <> "FACTURA DE CREDITO" And Combo_venta.Text <> "BOLETA DE CREDITO" And Combo_venta.Text <> "GUIA" Then
                valor_total = valor_total - numerofinal
                Round(valor_total)

                txt_desc.Text = txt_desc.Text + numerofinal
                txt_total.Text = valor_total

                'prueba de redondear descuento
                Dim valor_descuento_redondeado As String
                valor_descuento_redondeado = txt_desc.Text * 100
                valor_descuento_redondeado = valor_descuento_redondeado / txt_sub_total.Text

                If valor_descuento_redondeado.Length > 5 Then
                    valor_descuento_redondeado = valor_descuento_redondeado.Substring(0, 5)
                End If
            End If

            iva_valor = valor_iva / 100 + 1
            txt_neto.Text = Round(txt_total.Text / iva_valor)
            txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)
            txt_iva.Text = (txt_total.Text) - (txt_neto.Text)

            peso = " PESOS"

            If CInt(txt_total.Text) = 1000000 Then
                desglose_valor = Num2Text(txt_total.Text) & " DE PESOS"
            ElseIf CInt(txt_total.Text) = 2000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 3000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 4000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 5000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 6000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 7000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 8000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 9000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 10000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 11000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 12000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 13000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 14000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 15000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 16000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 17000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 18000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 19000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 20000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 21000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 22000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 23000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 24000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 25000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 26000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 27000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 28000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 29000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            ElseIf CInt(txt_total.Text) = 30000000 Then
                desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
            Else
                desglose_valor = Num2Text(txt_total.Text) & peso
            End If

            If grilla_detalle_venta.Rows.Count <> 0 Then
                txt_item.Text = grilla_detalle_venta.Rows.Count
            End If

            If txt_sub_total.Text = "" Or txt_sub_total.Text = "0" Then
                txt_sub_total_millar.Text = "0"
            Else
                txt_sub_total_millar.Text = Format(Int(txt_sub_total.Text), "###,###,###")
            End If
            If txt_desc.Text = "" Or txt_desc.Text = "0" Then
                txt_desc_millar.Text = "0"
            Else
                txt_desc_millar.Text = Format(Int(txt_desc.Text), "###,###,###")
            End If
            If txt_neto.Text = "" Or txt_neto.Text = "0" Then
                txt_neto_millar.Text = "0"
            Else
                txt_neto_millar.Text = Format(Int(txt_neto.Text), "###,###,###")
            End If
            If txt_iva.Text = "" Or txt_iva.Text = "0" Then
                txt_iva_millar.Text = "0"
            Else
                txt_iva_millar.Text = Format(Int(txt_iva.Text), "###,###,###")
            End If
            If txt_total.Text = "" Or txt_total.Text = "0" Then
                txt_total_millar.Text = "0"
            Else
                txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
            End If
        End If
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_detalle_venta.Rows.Count > 0 Then
            grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.CurrentRow)
            calcular_totales()
            txt_item.Text = grilla_detalle_venta.Rows.Count
            txt_codigo.Focus()
        End If
    End Sub

    Sub imprimir()
        Dim VarCantidadDesc As Integer
        Dim mensaje As String = ""
        VarCantidadDesc = 0

        If Combo_venta.Text = "" Then
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_venta.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "" Then
            MsgBox("CAMPO CONDICION DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            MsgBox("CAMPO CONDICION DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False







        Me.Enabled = False
        Me.crear_numero_documento()
        Me.grabar_factura()
        Me.grabar_detalle_factura()
        Form_autorizacion.Close()
        Me.limpiar()
        Me.controles(False, True)
        lbl_mensaje.Visible = False
        Me.Enabled = True
        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")


    End Sub

    Sub grabar_detalle_factura()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer

        If Combo_venta.Text = "PEDIDO" Then
            For i = 0 To grilla_detalle_venta.Rows.Count - 1
                VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_pedidos_vendedor (n_pedidos_vendedor, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'FACTURA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (dtp_fecha.Text) & "', '" & (txt_rut_vendedor.Text) & "' ,'EMITIDA')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
            Next
        End If
        If Combo_venta.Text = "COTIZACION" Then
            For i = 0 To grilla_detalle_venta.Rows.Count - 1
                VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_cotizacion (n_cotizacion, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'FACTURA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (dtp_fecha.Text) & "', '" & (txt_rut_vendedor.Text) & "' ,'EMITIDA')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
            Next
        End If
    End Sub


    Sub grabar_factura()
        If Combo_venta.Text = "PEDIDO" Then
            SC.Connection = conexion
            SC.CommandText = "insert into pedidos_vendedor(n_pedidos_vendedor, tipo, rut_cliente, codigo_cliente, fecha_venta,descuento,neto,iva,subtotal,total,condiciones,estado,usuario_responsable,rut_retira, nombre_retira, recinto, hora, porcentaje_desc, orden, tipo_impresion, pie, condicion_de_pago_pie, comision)values(" & (txt_factura.Text) & ",'" & ("PEDIDO") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'-','" & ("ACEPTADO") & "','" & (txt_rut_vendedor.Text) & "','-','-','" & (mirecintoempresa) & "','" & ("") & "','" & (txt_porcentaje_desc.Text) & "', '0','-', '0', '-', '0')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If Combo_venta.Text = "COTIZACION" Then
            SC.Connection = conexion
            SC.CommandText = "insert into cotizacion(n_cotizacion, tipo, rut_cliente, codigo_cliente, fecha_venta,descuento,neto,iva,subtotal,total,condiciones,estado,usuario_responsable,rut_retira, nombre_retira, recinto, hora, porcentaje_desc, orden, tipo_impresion, pie, condicion_de_pago_pie, comision)values(" & (txt_factura.Text) & ",'" & ("PEDIDO") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'-','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','-','-','" & (mirecintoempresa) & "','" & ("") & "','" & (txt_porcentaje_desc.Text) & "', '0','-', '0', '-', '0')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If
    End Sub

    Sub grabar_detalle_temporal()
        Dim VarCodProducto As Integer
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As Integer
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer

        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into factura_temporal (n_factura,documento, codigo_producto, nombre_producto, numero_tecnico, cantidad, precio, porcentaje_desc, subtotal_detalle, total_detalle, NOMBRE_VENDEDOR) values('" & (txt_factura.Text) & "', '" & (Combo_venta.Text) & "','" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarCantidad) & "," & (VarValorUnitario) & "," & (VarPorcentaje) & "," & (VarSubtotal) & "," & (VarTotal) & ",'" & (minombre) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub

    Sub grabar_documento_temporal()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As String
        Dim VarCantidad As String
        Dim VarPorcentaje As String
        Dim VarDescuento As String
        Dim VarNeto As String
        Dim VarIva As String
        Dim VarSubtotal As String
        Dim VarTotal As String

        If grilla_detalle_venta.Rows.Count = 0 Then
            Exit Sub
        End If

        SC.Connection = conexion
        SC.CommandText = "delete from documento_temporal where usuario = '" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into documento_temporal (cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, usuario, documento, condicion_venta, porcentaje_desc_total, rut_cliente, nombre_cliente, direccion_cliente, cod_cliente, descuento_1,descuento_2, giro_cliente, comuna_cliente, telefono_cliente, estado_cuenta, email_cliente, ciudad_cliente, rut_cliente_retira, nombre_cliente_retira, orden_de_compra, tipo_documento) values( '" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "','" & (VarValorUnitario) & "','" & (VarCantidad) & "','" & (VarPorcentaje) & "','" & (VarDescuento) & "','" & (VarNeto) & "', '" & (VarIva) & "','" & (VarSubtotal) & "','" & (VarTotal) & "','" & (miusuario) & "','" & (Combo_venta.Text) & "','" & (combo_condiciones.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (txt_rut_cliente.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_direccion_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (txt_descuento_cliente.Text) & "','" & (txt_descuento_cliente_2.Text) & "','" & (txt_giro_cliente.Text) & "','" & (txt_comuna_cliente.Text) & "','" & (txt_telefono.Text) & "','" & (txt_cuenta_cliente.Text) & "','" & (txt_correo_cliente.Text) & "','" & (txt_ciudad_cliente.Text) & "','-','-','" & (txt_orden_de_compra.Text) & "','" & (txt_tipo_documento.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next
    End Sub

    Sub cargar_documento_temporal()
        Try
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from documento_temporal where usuario='" & (miusuario) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                    DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                    DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next

                Combo_venta.Text = DS.Tables(DT.TableName).Rows(0).Item("documento")
                combo_condiciones.Text = DS.Tables(DT.TableName).Rows(0).Item("condicion_venta")
                txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc_total")
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_documento")
                txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                mostrar_datos_clientes_por_codigo()


            End If

            SC.Connection = conexion
            SC.CommandText = "delete from documento_temporal where usuario='" & (miusuario) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            calcular_totales()

        Catch err As InvalidCastException
            SC.Connection = conexion
            SC.CommandText = "delete from documento_temporal where usuario='" & (miusuario) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            calcular_totales()
            txt_codigo.Focus()

        Catch err As ArgumentException
            SC.Connection = conexion
            SC.CommandText = "delete from documento_temporal where usuario='" & (miusuario) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            calcular_totales()
            txt_codigo.Focus()
        End Try
    End Sub

    Sub descuento()
        Dim VarPorcentajeDesc As String
        Dim VarCantidadDesc As Integer
        Dim VarDescuentoCliente As Integer
        Dim porcentaje_desc As Integer
        Dim desc_final_maximo As Integer
        Dim mensaje_autorizacion As String

        mensaje_autorizacion = ""
        VarAutorizacionVenta = ""
        VarCantidadDesc = 0

        porcentaje_desc = Val(txt_porcentaje_desc.Text)
        VarDescuentoCliente = Val(txt_descuento_cliente.Text)

        If VarDescuentoCliente >= valor_descuento_maximo Then
            desc_final_maximo = VarDescuentoCliente
        Else
            desc_final_maximo = valor_descuento_maximo
        End If

        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarPorcentajeDesc = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            If VarPorcentajeDesc > Int(valor_descuento_maximo_columna) Then
                VarCantidadDesc = VarCantidadDesc + 1
            End If
        Next

        If Int(VarCantidadDesc) <> "0" Then
            mensaje_autorizacion = "SI"
        End If

        If Int(porcentaje_desc) > Int(desc_final_maximo) Then
            mensaje_autorizacion = "SI"
        End If

        If mirutempresa = "87686300-6" Then
            If combo_condiciones.Text = "CHEQUE 30-60 DIAS" Then
                If Int(txt_porcentaje_desc.Text) > Int(5) Then
                    mensaje_autorizacion = "SI"
                End If
            End If

            If combo_condiciones.Text = "CHEQUE 30-60-90 DIAS" Then
                If Int(txt_porcentaje_desc.Text) > Int(2) Then
                    mensaje_autorizacion = "SI"
                End If
            End If

            If combo_condiciones.Text = "PENDIENTE" Then
                mensaje_autorizacion = "SI"
            End If

            If combo_condiciones.Text = "LETRA" Then
                'If Int(txt_porcentaje_desc.Text) > Int(0) Then
                mensaje_autorizacion = "SI"
                'End If
            End If


            If combo_condiciones.Text = "TRASLADO" Then
                'If Int(txt_porcentaje_desc.Text) > Int(0) Then
                mensaje_autorizacion = "SI"
                'End If
            End If

            If combo_condiciones.Text = "CREDITO" Then
                If Int(txt_total.Text) > Int(txt_saldo.Text) Then
                    mensaje_autorizacion = "SI"
                End If
            End If

            If combo_condiciones.Text <> "-" And combo_condiciones.Text <> "EFECTIVO" And combo_condiciones.Text <> "TARJETA DEBITO" And combo_condiciones.Text <> "TARJETA CREDITO" And combo_condiciones.Text <> "CHEQUE AL DIA" And combo_condiciones.Text <> "CHEQUE 30 DIAS" And combo_condiciones.Text <> "CHEQUE 30-60 DIAS" And combo_condiciones.Text <> "CHEQUE 30-60-90 DIAS" And combo_condiciones.Text <> "TRANSFERENCIA" And combo_condiciones.Text <> "PENDIENTE" And combo_condiciones.Text <> "LETRA" And combo_condiciones.Text <> "OTRO MEDIO DE PAGO" And combo_condiciones.Text <> "CREDITO" Then
                mensaje_autorizacion = "SI"
            End If
        End If

        If mensaje_autorizacion = "SI" Then
            Form_autorizacion.Show()
            Me.Enabled = False

            If Int(VarCantidadDesc) <> "0" Then
                If VarCantidadDesc = 1 Then
                    Form_autorizacion.lbl_autorizacion.Text = "● SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO"
                Else
                    Form_autorizacion.lbl_autorizacion.Text = "● SE HA APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO"
                End If
                Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
            End If

            If Int(porcentaje_desc) > Int(desc_final_maximo) Then
                If Form_autorizacion.lbl_autorizacion.Text = "" Then
                    Form_autorizacion.lbl_autorizacion.Text = "● EL DESCUENTO FINAL EXCEDE EL MAXIMO"
                    Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                Else
                    Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● EL DESCUENTO FINAL EXCEDE EL MAXIMO"
                    Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleRight
                End If
            End If

            If combo_condiciones.Text = "CREDITO" Then
                If Int(txt_total.Text) > Int(txt_saldo.Text) Then
                    If Form_autorizacion.lbl_autorizacion.Text = "" Then
                        Form_autorizacion.lbl_autorizacion.Text = "● EL TOTAL ES MAYOR AL CUPO DISPONIBLE"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                    Else
                        Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● EL TOTAL ES MAYOR AL CUPO DISPONIBLE"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleRight
                    End If
                End If
            End If

            If mirutempresa = "81921000-4" Then
                If combo_condiciones.Text = "LETRA" Then
                    If Int(txt_total.Text) > Int(txt_saldo.Text) Then
                        If Form_autorizacion.lbl_autorizacion.Text = "" Then
                            Form_autorizacion.lbl_autorizacion.Text = "● EL TOTAL ES MAYOR AL CUPO DISPONIBLE"
                            Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                        Else
                            Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● EL TOTAL ES MAYOR AL CUPO DISPONIBLE"
                            Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleRight
                        End If

                    End If
                End If
            End If

            If mirutempresa = "87686300-6" Then
                If combo_condiciones.Text = "CHEQUE 30-60 DIAS" Then
                    If Int(txt_porcentaje_desc.Text) > Int(5) Then
                        If Form_autorizacion.lbl_autorizacion.Text = "" Then
                            Form_autorizacion.lbl_autorizacion.Text = "● CHEQUE 30-60-90 NO PERMITE ESTE %DCTO."
                            Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                        Else
                            Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● CHEQUE 30-60-90 NO PERMITE ESTE %DCTO."
                            Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleLeft
                        End If
                    End If
                End If

                If combo_condiciones.Text = "CHEQUE 30-60-90 DIAS" Then
                    If Int(txt_porcentaje_desc.Text) > Int(2) Then
                        If Form_autorizacion.lbl_autorizacion.Text = "" Then
                            Form_autorizacion.lbl_autorizacion.Text = "● CHEQUE 30-60-90 NO PERMITE ESTE %DCTO."
                            Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                        Else
                            Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● CHEQUE 30-60-90 NO PERMITE ESTE %DCTO."
                            Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleLeft
                        End If
                    End If
                End If

                If combo_condiciones.Text = "PENDIENTE" Then
                    If Form_autorizacion.lbl_autorizacion.Text = "" Then
                        Form_autorizacion.lbl_autorizacion.Text = "● VENTA PENDIENTE, SOLICITE AUTORIZACIÓN"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                    Else
                        Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● VENTA PENDIENTE, SOLICITE AUTORIZACIÓN"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleLeft
                    End If
                End If

                If combo_condiciones.Text = "LETRA" Then
                    'If Int(txt_porcentaje_desc.Text) > Int(0) Then
                    If Form_autorizacion.lbl_autorizacion.Text = "" Then
                        Form_autorizacion.lbl_autorizacion.Text = "● VENTA CON LETRA, SOLICITE AUTORIZACIÓN"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                    Else
                        Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● VENTA CON LETRA, SOLICITE AUTORIZACIÓN"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleLeft
                    End If
                    'End If
                End If

                If combo_condiciones.Text = "TRASLADO" Then
                    'If Int(txt_porcentaje_desc.Text) > Int(0) Then
                    If Form_autorizacion.lbl_autorizacion.Text = "" Then
                        Form_autorizacion.lbl_autorizacion.Text = "● TRASLADO, SOLICITE AUTORIZACIÓN"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                    Else
                        Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● VENTA CON LETRA, SOLICITE AUTORIZACIÓN"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleLeft
                    End If
                    'End If
                End If

                If combo_condiciones.Text <> "-" And combo_condiciones.Text <> "EFECTIVO" And combo_condiciones.Text <> "TARJETA DEBITO" And combo_condiciones.Text <> "TARJETA CREDITO" And combo_condiciones.Text <> "CHEQUE AL DIA" And combo_condiciones.Text <> "CHEQUE 30 DIAS" And combo_condiciones.Text <> "CHEQUE 30-60 DIAS" And combo_condiciones.Text <> "CHEQUE 30-60-90 DIAS" And combo_condiciones.Text <> "TRANSFERENCIA" And combo_condiciones.Text <> "PENDIENTE" And combo_condiciones.Text <> "LETRA" And combo_condiciones.Text <> "TRASLADO" And combo_condiciones.Text <> "OTRO MEDIO DE PAGO" And combo_condiciones.Text <> "CREDITO" Then
                    If Form_autorizacion.lbl_autorizacion.Text = "" Then
                        Form_autorizacion.lbl_autorizacion.Text = "● OTRO MEDIO DE PAGO, SOLICITE AUTORIZACIÓN"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                    Else
                        Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● MEDIO DE PAGO, SOLICITE AUTORIZACIÓN"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleLeft
                    End If
                End If
            End If
            Exit Sub
        End If
        VarAutorizacionVenta = "LISTO"
    End Sub

    'segun el TIPO de documento selecconado llama al sub grabar y verifica que la csantidad de items no sobrepase el limite.
    Private Sub btn_grabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If txt_porcentaje_desc.Text = "" Then
            txt_porcentaje_desc.Text = "0"
        End If

        If Combo_venta.Text = "PEDIDO" Then
            combo_condiciones.Text = "CREDITO"
        End If


        Dim VarCodProducto As String
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            If VarCodProducto = "*" And Combo_venta.Text <> "COTIZACION" Then
                MsgBox("EL CODIGO * SOLO PUEDE SER INGRESADO EN COTIZACIONES", MsgBoxStyle.Critical, "INFORMACION")
                ' combo_venta.Text = "COTIZACION"
                Exit Sub
            End If
        Next

        If grilla_detalle_venta.Rows.Count = 0 Then
            MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo.Focus()
            Exit Sub
        End If

        If Combo_venta.Text = "" Then
            MsgBox("CAMPO TIPO DE VENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_venta.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If






        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If

        If grilla_detalle_venta.Rows.Count > limite_facturas Then
            MsgBox("NO PUEDE AGREGAR MAS DE PRODUCTOS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
            txt_codigo.Focus()
            Exit Sub
        End If

        If valida_rut(txt_rut_cliente.Text) = False Then
            txt_rut_cliente.Focus()
            txt_rut_cliente.SelectAll()
            Exit Sub
        End If

        Dim valormensaje As Integer

        valormensaje = MsgBox("¿ESTA SEGURO DE GUARDAR?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")


        If valormensaje = vbYes Then
            descuento()

            If VarAutorizacionVenta = "" Then
                Exit Sub
            End If

            imprimir()
            VarAutorizacionVenta = ""
            Exit Sub
        End If

    End Sub

    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            combo_condiciones.Focus()
        End If
    End Sub

    Private Sub combo_venta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

        End If
    End Sub

    Private Sub combo_condiciones_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.GotFocus
        combo_condiciones.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_condiciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles combo_condiciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_grabar.Focus()
        End If
    End Sub

    Private Sub combo_condiciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_condiciones.KeyPress
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

    Private Sub combo_condiciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.LostFocus
        combo_condiciones.BackColor = Color.White
    End Sub

    'Private Sub Combo_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles
    ' combo_condiciones.BackColor = Color.LightBlue
    'End Sub

    'Private Sub Combo_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles
    ' combo_condiciones.BackColor = Color.LightBlue
    'End Sub

    'Private Sub Combo_cargar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_cargar.SelectedIndexChanged
    ' cargar_documento()
    ' calcular_totales()
    ' txt_item.Text = grilla_detalle.Rows.Count
    'End Sub

    Private Sub txt_cantidad_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White
    End Sub

    'Private Sub txt_rut_vendedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_vendedor.TextChanged
    ' ' mostrar_rut_vendedor()
    'End Sub

    'Sub para realizar el filtro de la busqueda de forma directa en el combobox.
    'Sub mostrar_rut_vendedor()
    ' DS.Tables.Clear()
    ' DT.Rows.Clear()
    ' DT.Columns.Clear()
    ' DS.Clear()
    ' conexion.Open()

    ' SC.Connection = conexion
    ' SC.CommandText = "select * from usuarios where rut_usuario like '" & (combo_vendedor.Text & "%") & "' and TIPO ='VENTAS'"
    ' DA.SelectCommand = SC
    ' DA.Fill(DT)
    ' DS.Tables.Add(DT)

    ' If DS.Tables(DT.TableName).Rows.Count > 0 Then
    ' combo_vendedor.Items.Clear()
    ' For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    ' combo_vendedor.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_usuario"))
    ' Next
    ' End If
    ' conexion.Close()
    'End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub





    Private Sub btn_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn_agregar.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_productos()
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            txt_cantidad_agregar.Focus()
            'condiciones()
            txt_codigo.Focus()
        End If
    End Sub

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.Click
        conexion.Close()
        Me.Enabled = False
        txt_rut_cliente.Focus()
        Form_buscador_clientes_ventas.Show()
        Form_buscador_clientes_ventas.txt_busqueda.Focus()
    End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Enabled = False
        txt_codigo.Focus()
        Form_buscador_productos_ventas.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lbl_codigo.Text = "nada" Then
            MsgBox("DEBE SELECCIONAR UN PRODUCTO", MsgBoxStyle.Critical, "INFORMACION")
            txt_codigo.Focus()
        Else
            Me.Enabled = False
            Form_imagen.Show()
            ' Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    'Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles
    ' txt_rut.BackColor = Color.LightBlue
    'End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress
        'txt_nombre_cliente.Text = ""

        '   limpiar_datos_clientes()

        If (e.KeyChar = Convert.ToChar(Keys.F4)) Then
            btn_buscar_clientes.PerformClick()
        End If

        'If (e.KeyChar = Convert.ToChar(Keys.Back)) Then
        '    limpiar_datos_clientes()
        'End If

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
            limpiar_datos_clientes()
            guion_rut_cliente()
            mostrar_datos_clientes()
            txt_codigo.Focus()
        End If
    End Sub


    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_cliente.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_cliente.Text = rut_cliente
            End If
        End If
    End Sub

    Private Sub txt_rut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut_cliente.KeyUp
        'If e.KeyCode = Keys.F8 Then
        ' Form_registro_clientes_ventas.Show()
        ' Me.WindowState = FormWindowState.Minimized
        'End If

        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_clientes_ventas.Show()
            Me.Enabled = False
        End If

        If e.KeyCode = Keys.F6 Then
            Form_registro_clientes_ventas.Show()
            Me.Enabled = False
        End If
    End Sub


    Private Sub txt_cantidad_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.GotFocus
        txt_cantidad_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_agregar_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_agregar.KeyPress
        'If Char.IsDigit(e.KeyChar) Then
        ' e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        ' e.Handled = False
        'Else
        ' e.Handled = True
        'End If


        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

        If e.KeyChar = "-" Then
            e.KeyChar = ""
        End If



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
            btn_agregar.PerformClick()
        End If
    End Sub

    Private Sub txt_cantidad_agregar_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White
    End Sub

    'Private Sub combo_retira_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_retira.GotFocus
    ' combo_retira.BackColor = Color.Yellow
    'End Sub

    Private Sub combo_retira_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txt_codigo.Focus()
        End If
    End Sub

    'Private Sub combo_retira_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_retira.KeyPress
    ' If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
    ' mostrar_datos_retira()
    ' ' combo_venta.Focus()
    ' End If

    ' If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
    ' e.Handled = False
    ' Else
    ' e.Handled = True
    ' End If
    'End Sub

    'Private Sub combo_retira_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_retira.LostFocus
    ' combo_retira.BackColor = Color.White
    'End Sub

    'Private Sub combo_retira_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_retira.SelectedIndexChanged
    ' mostrar_datos_retira()
    'End Sub

    Private Sub btn_agregar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_clientes.Click
        Me.Enabled = False
        Form_registro_clientes_ventas.Show()
        'Me.WindowState = FormWindowState.Minimized
    End Sub



    Private Sub txt_cargar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cargar.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

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
            lbl_mensaje.Visible = True
            Me.Enabled = False
            cargar_documento()
            calcular_totales()
            'cargar_nombre()
            txt_cargar.Text = ""
            txt_codigo.Focus()
            txt_item.Text = grilla_detalle_venta.Rows.Count
            lbl_mensaje.Visible = False
            Me.Enabled = True
            'lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
            'detalle_label()
        End If
    End Sub

    Private Sub txt_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cargar.LostFocus
        txt_cargar.BackColor = Color.White

    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.TabIndexChanged
        Combo_venta.Focus()
    End Sub




    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_nueva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Radio_codigo_barra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_codigo.Focus()
    End Sub

    Private Sub Radio_codigo_interno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_codigo.Focus()
    End Sub

    'Private Sub Radio_codigo_interno_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    ' Radio_codigo_interno.TabStop = False
    'End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    'Private Sub GroupBox2_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.TabIndexChanged
    ' Me.TabIndex = 50
    'End Sub

    'Private Sub Radio_codigo_barra_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    ' Radio_codigo_barra.TabStop = False
    'End Sub

    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_nueva.BackColor = Color.Transparent
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_porcentaje_desc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.Click
        txt_porcentaje_desc.SelectionStart = 0
        txt_porcentaje_desc.SelectionLength = Len(txt_porcentaje_desc.Text)
    End Sub





    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    ' If txt_total_final.Text = "0" Or txt_total_final.Text = "" Then
    ' MsgBox("AUN NO GENERA UNA VENTA", MsgBoxStyle.Critical, "INFORMACION")
    ' Else
    ' Form_vuelto.Show()
    ' controles_subpantalla(False, True)
    ' End If
    'End Sub

    Private Sub txt_descto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.GotFocus
        txt_porcentaje_desc.BackColor = Color.LightSkyBlue
    End Sub



    Private Sub txt_porcentaje_desc_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles txt_porcentaje_desc.Invalidated

    End Sub

    Private Sub txt_descto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_porcentaje_desc.KeyDown

    End Sub



    Private Sub txt_descto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_porcentaje_desc.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

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
            'guardar_descuento()
            'grilla_detalle_venta.Rows.Clear()
            'cargar_descuento()
            'calcular_totales()
            ''If txt_descto.Text = "" Then
            '' txt_descto.Text = "0"
            ''End If

            ''If txt_descto.Text = " " Then
            '' txt_descto.Text = "0"
            ''End If
            'btn_agregar.Focus()
















            calcular_totales()

            btn_grabar.Focus()

        End If


    End Sub




    'Private Sub btn_agregar_retira_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_retira.Click

    ' If lbl_rut.Text = "nada" Then
    ' 'MsgBox("SELECCIONE AL TITULAR DE LA CUENTA", 0 + 16, "Error")
    ' MsgBox("SELECCIONE AL TITULAR DE LA CUENTA", MsgBoxStyle.Critical, "INFORMACION")
    ' txt_rut.Focus()
    ' Else

    ' Form_registro_cliente_retira.Show()
    ' Form_registro_cliente_retira.combo_rut_empresa.Text = Me.txt_rut.Text
    ' Form_registro_cliente_retira.txt_nombre_empresa.Text = Me.txt_nombre_cliente.Text
    ' Me.WindowState = FormWindowState.Minimized
    ' End If
    'End Sub

    'Sub bixolon()

    ' Dim VarCodProducto As Integer
    ' Dim varnombre As String
    ' Dim vartecnico As String
    ' Dim VarValorUnitario As Integer
    ' Dim VarCantidad As Integer
    ' Dim VarPorcentaje As Integer
    ' Dim VarDescuento As Integer
    ' Dim VarNeto As Integer
    ' Dim VarIva As Integer
    ' Dim VarSubtotal As Integer
    ' Dim VarTotal As Integer
    ' Dim VarProveedor As String
    ' Dim VarCosto As Integer
    ' Dim VarSaldo As Integer
    ' Dim VarTipopago As Integer

    ' ''los pagos 0, 1, 2 vienen configurados como Efectivo, Cheque y Crédito.

    ' If combo_condiciones.Text = "EFECTIVO" Then
    ' VarTipopago = 0
    ' End If
    ' If combo_condiciones.Text = "TARJETA ABCDIN" Then
    ' VarTipopago = 2
    ' End If
    ' If combo_condiciones.Text = "TARJETA CENCOSUD" Then
    ' VarTipopago = 2
    ' End If
    ' If combo_condiciones.Text = "TARJETA C&D" Then
    ' VarTipopago = 2
    ' End If
    ' If combo_condiciones.Text = "TARJETA PRESTO" Then
    ' VarTipopago = 2
    ' End If
    ' If combo_condiciones.Text = "TARJETA RYPLEY" Then
    ' VarTipopago = 2
    ' End If
    ' If combo_condiciones.Text = "TARJETA DE CREDITO" Then
    ' VarTipopago = 2
    ' End If
    ' If combo_condiciones.Text = "TARJETA VISA" Then
    ' VarTipopago = 2
    ' End If
    ' If combo_condiciones.Text = "TARJETA MASTERCARD" Then
    ' VarTipopago = 2
    ' End If
    ' If combo_condiciones.Text = "TARJETA BANCARIA" Then
    ' VarTipopago = 2
    ' End If
    ' If combo_condiciones.Text = "CHEQUE AL DIA" Then
    ' VarTipopago = 1
    ' End If
    ' If combo_condiciones.Text = "CHEQUE 30 DIAS" Then
    ' VarTipopago = 1
    ' End If
    ' If combo_condiciones.Text = "CHEQUE 30-60 DIAS" Then
    ' VarTipopago = 1
    ' End If
    ' If combo_condiciones.Text = "CHEQUE 30-60-90 DIAS" Then
    ' VarTipopago = 1
    ' End If
    ' If combo_condiciones.Text = "CREDITO" Then
    ' VarTipopago = 3
    ' End If


    ' AxOcxsam3501.cargarlogo("misimagenes /nasna")

    ' AxOcxsam3501.init(1) '(abre el puerto)
    ' AxOcxsam3501.abrirBOLETA(0, 0) '(inicias una BOLETA)

    ' For i = 0 To grilla_detalle.Rows.Count - 1

    ' VarCodProducto = grilla_detalle.Rows(i).Cells(0).Value.ToString
    ' varnombre = grilla_detalle.Rows(i).Cells(1).Value.ToString
    ' vartecnico = grilla_detalle.Rows(i).Cells(2).Value.ToString
    ' VarValorUnitario = grilla_detalle.Rows(i).Cells(3).Value.ToString
    ' VarCantidad = grilla_detalle.Rows(i).Cells(4).Value.ToString
    ' VarPorcentaje = grilla_detalle.Rows(i).Cells(5).Value.ToString
    ' VarDescuento = grilla_detalle.Rows(i).Cells(6).Value.ToString
    ' VarNeto = grilla_detalle.Rows(i).Cells(7).Value.ToString
    ' VarIva = grilla_detalle.Rows(i).Cells(8).Value.ToString
    ' VarSubtotal = grilla_detalle.Rows(i).Cells(9).Value.ToString
    ' VarTotal = grilla_detalle.Rows(i).Cells(10).Value.ToString
    ' VarSaldo = grilla_detalle.Rows(i).Cells(11).Value.ToString
    ' VarProveedor = grilla_detalle.Rows(i).Cells(12).Value.ToString
    ' VarCosto = grilla_detalle.Rows(i).Cells(13).Value.ToString

    ' AxOcxsam3501.agregaitem(varnombre, VarValorUnitario, VarCantidad) '(agregas un producto, descripcion, cantidad, precio unitario)
    ' ' AxOcxsam3501.agregarecargo("Recargo", 20) ' (ingresas recargo si lo ay)
    ' AxOcxsam3501.agregadescuento("Descuento", txt_desc_total.Text) '(ingresas descuento si lo hay)
    ' AxOcxsam3501.agregapago(VarTipopago, txt_total_final.Text) '(ingresas el TIPO de pago y el pago) 'los pagos 0, 1, 2 vienen configurados como Efectivo, Cheque y Crédito.



    ' AxOcxsam3501.agregadonacion("donacion", 10) '//da 10 de donación
    ' Next

    ' AxOcxsam3501.cierraBOLETA(0) '(cierras la BOLETA)
    ' AxOcxsam3501.fini() '(cierras el puerto)


    'End Sub


    'Sub cargar_nombre()
    ' If combo_venta.Text = "FACTURA" Then

    ' DS.Tables.Clear()
    ' DT.Rows.Clear()
    ' DT.Columns.Clear()
    ' DS.Clear()
    ' conexion.Open()
    ' SC.Connection = conexion
    ' SC.CommandText = "select rut_cliente from factura where n_factura= '" & (txt_cargar.Text) & "'"
    ' DA.SelectCommand = SC
    ' DA.Fill(DT)
    ' DS.Tables.Add(DT)
    ' If DS.Tables(DT.TableName).Rows.Count > 0 Then
    ' For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    ' txt_rut.Text = (DS.Tables(DT.TableName).Rows(E).Item("rut_cliente"))
    ' Next
    ' End If
    ' conexion.Close()

    ' If txt_rut.Text <> "" Then
    ' mostrar_datos_clientes()
    ' 'DS.Tables.Clear()
    ' 'DT.Rows.Clear()
    ' 'DT.Columns.Clear()
    ' 'DS.Clear()
    ' 'conexion.Open()

    ' 'SC.Connection = conexion
    ' 'SC.CommandText = "select * from clientes where rut ='" & (txt_rut.Text) & "'"
    ' 'DA.SelectCommand = SC
    ' 'DA.Fill(DT)
    ' 'DS.Tables.Add(DT)

    ' 'If DS.Tables(DT.TableName).Rows.Count > 0 Then

    ' ' lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
    ' ' txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    ' ' txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
    ' ' txt_descto.Text = DS.Tables(DT.TableName).Rows(0).Item("dscto1")
    ' ' txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("giro")
    ' ' txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna")
    ' ' txt_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("cuenta")
    ' 'End If
    ' End If
    ' conexion.Close()
    ' End If

    ' If combo_venta.Text = "FACTURA DE CREDITO" Then

    ' DS.Tables.Clear()
    ' DT.Rows.Clear()
    ' DT.Columns.Clear()
    ' DS.Clear()
    ' conexion.Open()
    ' SC.Connection = conexion
    ' SC.CommandText = "select rut_cliente from factura_credito where n_factura_credito= '" & (txt_cargar.Text) & "'"
    ' DA.SelectCommand = SC
    ' DA.Fill(DT)
    ' DS.Tables.Add(DT)
    ' If DS.Tables(DT.TableName).Rows.Count > 0 Then
    ' For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    ' txt_rut.Text = (DS.Tables(DT.TableName).Rows(E).Item("rut_cliente"))
    ' Next
    ' End If
    ' conexion.Close()

    ' If txt_rut.Text <> "" Then
    ' mostrar_datos_clientes()
    ' 'DS.Tables.Clear()
    ' 'DT.Rows.Clear()
    ' 'DT.Columns.Clear()
    ' 'DS.Clear()
    ' 'conexion.Open()

    ' 'SC.Connection = conexion
    ' 'SC.CommandText = "select * from clientes where rut ='" & (txt_rut.Text) & "'"
    ' 'DA.SelectCommand = SC
    ' 'DA.Fill(DT)
    ' 'DS.Tables.Add(DT)

    ' 'If DS.Tables(DT.TableName).Rows.Count > 0 Then

    ' ' lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
    ' ' txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    ' ' txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
    ' ' txt_descto.Text = DS.Tables(DT.TableName).Rows(0).Item("dscto1")
    ' ' txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("giro")
    ' ' txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna")
    ' ' txt_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("cuenta")
    ' End If
    ' conexion.Close()
    ' End If

    ' 'End If

    ' If combo_venta.Text = "GUIA" Then

    ' DS.Tables.Clear()
    ' DT.Rows.Clear()
    ' DT.Columns.Clear()
    ' DS.Clear()
    ' conexion.Open()
    ' SC.Connection = conexion
    ' SC.CommandText = "select rut_cliente from GUIA where n_guia= '" & (txt_cargar.Text) & "'"
    ' DA.SelectCommand = SC
    ' DA.Fill(DT)
    ' DS.Tables.Add(DT)
    ' If DS.Tables(DT.TableName).Rows.Count > 0 Then
    ' For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    ' txt_rut.Text = (DS.Tables(DT.TableName).Rows(E).Item("rut_cliente"))
    ' Next
    ' End If
    ' conexion.Close()

    ' If txt_rut.Text <> "" Then
    ' mostrar_datos_clientes()
    ' 'DS.Tables.Clear()
    ' 'DT.Rows.Clear()
    ' 'DT.Columns.Clear()
    ' 'DS.Clear()
    ' 'conexion.Open()

    ' 'SC.Connection = conexion
    ' 'SC.CommandText = "select * from clientes where rut ='" & (txt_rut.Text) & "'"
    ' 'DA.SelectCommand = SC
    ' 'DA.Fill(DT)
    ' 'DS.Tables.Add(DT)

    ' 'If DS.Tables(DT.TableName).Rows.Count > 0 Then

    ' ' lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
    ' ' txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    ' ' txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
    ' ' txt_descto.Text = DS.Tables(DT.TableName).Rows(0).Item("dscto1")
    ' ' txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("giro")
    ' ' txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna")
    ' ' txt_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("cuenta")
    ' End If
    ' conexion.Close()
    ' End If

    ' End If
    '

    Private Sub combo_condiciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_condiciones.SelectedIndexChanged

    End Sub

    Private Sub txt_cantidad_agregar_ChangeUICues(ByVal sender As Object, ByVal e As System.Windows.Forms.UICuesEventArgs) Handles txt_cantidad_agregar.ChangeUICues
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
    End Sub

    Private Sub txt_cantidad_agregar_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.GotFocus
        txt_cantidad_agregar.BackColor = Color.LightSkyBlue
    End Sub



    'Private Sub txt_cantidad_agregar_KeyPress2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_agregar.KeyPress
    ' If Char.IsDigit(e.KeyChar) Then
    ' e.Handled = False
    ' ElseIf Char.IsControl(e.KeyChar) Then
    ' e.Handled = False
    ' Else
    ' e.Handled = True
    ' End If

    ' If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

    ' If txt_cantidad_agregar.Text = "" Then
    ' txt_cantidad_agregar.Text = 0
    ' End If

    ' If txt_cantidad_agregar.Text = " " Then
    ' txt_cantidad_agregar.Text = 0
    ' End If

    ' If txt_cantidad_agregar.TextLength = 0 Then
    ' txt_cantidad_agregar.Text = 0
    ' End If
    ' If txt_cantidad_agregar.Text = " " Then
    ' txt_cantidad_agregar.Text = 0
    ' End If
    ' If txt_descto.Text = "" Then
    ' txt_descto.Text = 0
    ' End If
    ' btn_agregar.Focus()
    ' End If
    'End Sub

    Private Sub txt_cantidad_agregar_LostFocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White


        'Dim primer_caracter As String
        'Dim ultimo_caracter As String
        'Dim total_caracter As String
        'total_caracter = ""

        'If txt_cantidad_agregar.Text = "" Then
        'primer_caracter = 0
        'ultimo_caracter = 0
        'Else
        'primer_caracter = txt_cantidad_agregar.Text.Length - txt_cantidad_agregar.Text.Length + 1
        'ultimo_caracter = txt_cantidad_agregar.Text.Length
        'total_caracter = txt_cantidad_agregar.Text
        'End If



        'Dim n1 As Byte, lMal As Boolean


        'If txt_cantidad_agregar.Text <> "" Then

        'For n1 = ultimo_caracter To ultimo_caracter
        'If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
        'MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
        'txt_cantidad_agregar.Focus()
        'lMal = True
        'Exit Sub
        'End If
        'Next

        'For n1 = 1 To 1
        'If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
        'MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
        'txt_cantidad_agregar.Focus()
        'lMal = True
        'Exit Sub

        'End If
        'Next
        'End If
    End Sub



    Private Sub txt_cantidad_agregar_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.TextChanged
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))

        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))

        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
    End Sub

    'Private Sub Combo_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    ' Combo_rut.BackColor = Color.LightBlue
    'End Sub

    'Private Sub Combo_rut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    ' If e.KeyCode = Keys.Enter Then
    ' If combo_retira.Enabled = True Then
    ' combo_retira.Focus()
    ' Else
    ' txt_codigo.Focus()
    ' End If
    ' End If
    'End Sub

    'Private Sub Combo_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    ' Combo_rut.BackColor = Color.White
    'End Sub



    Private Sub Combo_codigo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_productos()
            mostrar_cantidad_real()
            mostrar_nombre_proveedor()
            txt_cantidad_agregar.Text = ""
            ' Radio_codigo_interno.Checked = True
            txt_cantidad_agregar.Focus()
        End If

        'If Radio_codigo_interno.Checked = True Then
        ' If Char.IsDigit(e.KeyChar) Then
        ' e.Handled = False
        ' ElseIf Char.IsControl(e.KeyChar) Then
        ' e.Handled = False
        ' Else
        ' e.Handled = True
        ' End If
        ' txt_codigo.MaxLength = 6
        'Else
        ' txt_codigo.MaxLength = 30
        'End If
    End Sub

    'Private Sub Combo_codigo_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ' mostrar_cantidad_real()
    ' mostrar_nombre_proveedor()
    ' txt_cantidad_agregar.Text = ""
    ' Radio_codigo_interno.Checked = True
    ' txt_cantidad_agregar.Focus()

    ' If Radio_codigo_interno.Checked = True Then
    ' txt_codigo.MaxLength = 6
    ' Else
    ' txt_codigo.MaxLength = 30
    ' End If
    'End Sub

    Private Sub txt_descto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.LostFocus
        Me.txt_porcentaje_desc.Text = Trim(Replace(Me.txt_porcentaje_desc.Text, " ", ""))
        'If txt_porcentaje_desc.Text = "" Or txt_porcentaje_desc.Text = " " Or txt_porcentaje_desc.Text = " " Then
        ' txt_porcentaje_desc.Text = "0"
        'End If
        'If txt_porcentaje_desc.Text = Nothing Then
        ' txt_porcentaje_desc.Text = "0"
        'End If
        txt_porcentaje_desc.BackColor = Color.White
    End Sub

    Private Sub btn_agregar_clientes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_clientes.GotFocus
        btn_agregar_clientes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_clientes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.GotFocus
        btn_buscar_clientes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_productos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_buscar_productos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imagen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_imagen.BackColor = Color.Yellow
    End Sub

    Private Sub btn_agregar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_clientes.LostFocus
        btn_agregar_clientes.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.LostFocus
        btn_buscar_clientes.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_productos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_buscar_productos.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imagen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_imagen.BackColor = Color.Transparent
    End Sub

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

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txt_rut_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TabIndexChanged

    End Sub



    'Private Sub Panel_contenedor_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_contenedor.Paint

    'End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged
        'txt_descto.Text = "0"

        'If combo_venta.Text = "BOLETA" Then
        ' mostrar_datos_clientes()
        'End If

        'If combo_venta.Text = "BOLETA DE CREDITO" Then
        ' mostrar_datos_clientes()
        'End If

        'If combo_venta.Text = "FACTURA" Then
        ' mostrar_datos_clientes()
        'End If

        'If combo_venta.Text = "FACTURA DE CREDITO" Then
        ' mostrar_datos_cuentas_corrientes()
        'End If

        'If combo_venta.Text = "GUIA" Then
        ' mostrar_datos_cuentas_corrientes()
        'End If

        'If combo_venta.Text = "COTIZACION" Then
        ' mostrar_datos_clientes()
        'End If

        'llenar_combo_retira()
        'limpiar_datos_clientes_retira()
        'guardar_descuento()
        'grilla_detalle.Rows.Clear()
        'cargar_descuento()
        'calcular_totales()
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


    Private Sub txt_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cargar.GotFocus
        txt_cargar.BackColor = Color.LightSkyBlue
        Combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
        limpiar_datos_productos()

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

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If txt_codigo.Text = "" Then
                Exit Sub
            End If



            conexion.Close()
            Dim cantidad_caracteres As Integer
            cantidad_caracteres = Len(txt_codigo.Text)
            If cantidad_caracteres <= 5 Then
                Form_buscador_productos_ventas.Show()
                Form_buscador_productos_ventas.buscar_codigo()
                Exit Sub
            End If

            limpiar_datos_productos()
            mostrar_cantidad_real()
            mostrar_nombre_proveedor()




            If txt_nombre_producto.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MsgBoxStyle.Critical, "INFORMACION")
                txt_codigo.Focus()
                Exit Sub
            End If

            ' If ingreso_rapido = "NO" Then
            txt_cantidad_agregar.Text = "1"
            txt_precio_modificado.Focus()
            'End If

            'If ingreso_rapido = "SI" Then
            'txt_cantidad_agregar.Text = "1"
            'btn_agregar.PerformClick()
            'txt_codigo.Focus()
            'End If
        End If
    End Sub

    Private Sub txt_codigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_productos_ventas.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_codigo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
        If txt_codigo.Text = "*" Then
            limpiar_datos_productos()
            Combo_venta.Text = "COTIZACION"
            txt_codigo.Text = "*"
            txt_nombre_producto.ReadOnly = False
            txt_nombre_producto.BackColor = Color.White
            txt_precio_modificado.BackColor = Color.White
            txt_nombre_producto.Focus()
            Exit Sub
        Else
            txt_nombre_producto.ReadOnly = True
        End If
    End Sub

    Private Sub btn_buscar_productos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.Click
        Me.Enabled = False
        conexion.Close()
        txt_codigo.Focus()
        Form_buscar_productos_pedidos_or.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_imagen_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imagen.Click
        If lbl_codigo.Text = "nada" Then
            MsgBox("DEBE SELECCIONAR UN PRODUCTO", MsgBoxStyle.Critical, "INFORMACION")
            txt_codigo.Focus()
        Else
            Me.Enabled = False
            Form_imagen.Show()
        End If
    End Sub

    Private Sub btn_buscar_productos_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.GotFocus
        btn_buscar_productos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_productos_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.LostFocus
        btn_buscar_productos.BackColor = Color.Transparent
    End Sub


    Private Sub btn_imagen_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imagen.GotFocus
        btn_imagen.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imagen_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imagen.LostFocus
        btn_imagen.BackColor = Color.Transparent
    End Sub

    Private Sub grilla_detalle_venta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_detalle_venta.Click
        If grilla_detalle_venta.Rows.Count = 0 Then
            Exit Sub
        End If
        If grilla_detalle_venta.CurrentRow.Cells(0).Value() = "*" Then
            Exit Sub
        End If
        txt_codigo.Text = grilla_detalle_venta.CurrentRow.Cells(0).Value()

        mostrar_datos_productos()
        txt_precio_modificado.Text = grilla_detalle_venta.CurrentRow.Cells(7).Value()
        mostrar_nombre_proveedor()
        txt_cantidad_agregar.Focus()
    End Sub

    Private Sub grilla_detalle_venta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_detalle_venta.DoubleClick
        Dim columna_descuento As String
        Dim codigo_producto_descuento As String
        Dim nombre_producto_descuento As String
        Dim nro_tecnico_producto_descuento As String
        If grilla_detalle_venta.Rows.Count <> 0 Then
            columna_descuento = grilla_detalle_venta.CurrentRow.Cells(5).Value()
            codigo_producto_descuento = grilla_detalle_venta.CurrentRow.Cells(0).Value()
            nombre_producto_descuento = grilla_detalle_venta.CurrentRow.Cells(1).Value()
            nro_tecnico_producto_descuento = grilla_detalle_venta.CurrentRow.Cells(2).Value()

            If grilla_detalle_venta.CurrentRow.Cells(8).Selected Then
                Form_descuento.Show()
                Me.Enabled = False
            End If
        End If
    End Sub

    Private Sub txt_porcentaje_desc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.TextChanged
        calcular_totales()
    End Sub

    Private Sub txt_precio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.GotFocus
        txt_precio_modificado.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_precio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.LostFocus
        txt_precio_modificado.BackColor = Color.White
    End Sub

    Private Sub txt_precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio_modificado.KeyPress
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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_cantidad_agregar.Focus()
        End If
    End Sub

    Private Sub txt_nombre_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_producto.KeyPress
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
            txt_precio_modificado.Focus()
        End If
    End Sub

    Private Sub btn_mensaje_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txt_cod_cliente.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes where cod_cliente ='" & (txt_cod_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                If DS.Tables(DT.TableName).Rows(0).Item("mensaje") <> "SIN MENSAJE" Then
                    Form_mensaje_clientes.Show()
                    Me.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub btn_mensaje_cliente_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mensaje_cliente.Click
        If txt_cod_cliente.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes where cod_cliente ='" & (txt_cod_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                If DS.Tables(DT.TableName).Rows(0).Item("mensaje") <> "SIN MENSAJE" Then
                    Form_mensaje_clientes.Show()
                    Me.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        tipo_despacho = ""
        calcular_totales()
        controles(True, False)
        txt_codigo.Focus()
    End Sub

    Private Sub btn_nueva_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.GotFocus
        btn_nueva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nueva_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.LostFocus
        btn_nueva.BackColor = Color.Transparent
    End Sub

    Private Sub txt_nro_orden_de_compra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_orden_de_compra.GotFocus
        txt_nro_orden_de_compra.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_orden_de_compra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_orden_de_compra.LostFocus
        txt_nro_orden_de_compra.BackColor = Color.White
    End Sub

    Private Sub Combo_venta_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combo_venta.KeyDown
        If e.KeyCode = Keys.Enter Then
            combo_condiciones.Focus()
        End If
    End Sub

    Private Sub Combo_venta_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_venta.KeyPress
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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

        End If
    End Sub

    Private Sub Combo_venta_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_venta.LostFocus
        Combo_venta.BackColor = Color.White


    End Sub

    Private Sub Combo_venta_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_venta.SelectedIndexChanged

    End Sub

    Private Sub txt_efectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub ticket_cambio()
        With Pd.PrinterSettings
            .PrinterName = impresora_ticket
            .Copies = 1
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.Pd.PrintController = New StandardPrintController
                Me.Pd.DefaultPageSettings.Margins.Left = 10
                Me.Pd.DefaultPageSettings.Margins.Right = 10
                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()
            End If
        End With
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub recuperar_conexion()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String
        Try
            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

                If SucursalSeleccionada = recinto Then
                    Try
                        conexion.Close()
                        conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    Catch
                        conexion.Close()
                        conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    End Try
                End If
            Next
        Catch
            Me.Close()
            Form_menu_principal.Close()
        End Try
    End Sub
End Class