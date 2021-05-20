Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Math
Imports Comun

Public Class Form_venta
    Dim total_registros As Integer
    Dim varnumdoc As Integer
    Dim peso As String
    Dim pesos As String
    Dim sin_facturar As String
    Dim VarSeleccion As Integer
    Dim alto_cotizacion As String

    Private WithEvents Pd As New PrintDocument
    Private WithEvents Pd_Ticket_Interno As New PrintDocument

    Dim cantidad_letras As Integer
    Dim ticket_de_cambio As String
    Dim hora_venta As String
    Dim redondear_venta As String
    Dim nro_venta As Integer = 1
    Dim impresora_ticket_cotizaciones As String
    Dim impresora_ticket_ventas As String
    Dim deuda As String = ""

    Private Sub Form_venta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

        'If e.KeyCode = Keys.F4 Then
        '    BUSCAR
        'End If

        If e.KeyCode = Keys.F5 Then
            txt_rut_cliente.Focus()
        End If

        If e.KeyCode = Keys.F6 Then
            txt_rut_retira.Focus()
        End If

        If e.KeyCode = Keys.F7 Then
            Dim total_opciones As Integer = combo_condiciones.Items.Count - 1
            Dim posicion As Integer = combo_condiciones.FindStringExact("OTRO MEDIO DE PAGO")
            'Dim posicion_vacio As Integer = combo_condiciones.FindStringExact("-")
            combo_condiciones.Focus()



            If combo_condiciones.SelectedIndex + 1 > total_opciones Then
                combo_condiciones.SelectedIndex = 0
            ElseIf combo_condiciones.SelectedIndex + 1 = posicion Then
                combo_condiciones.SelectedIndex = 1
            Else
                combo_condiciones.SelectedIndex = combo_condiciones.SelectedIndex + 1
            End If
        End If

        If e.KeyCode = Keys.F8 Then
            btn_agregar_retira.PerformClick()
        End If

        If e.KeyCode = Keys.F9 Then
            txt_cargar.Focus()
        End If

        If e.KeyCode = Keys.F11 Then
            Combo_venta.Focus()



            'Dim posicion As Integer = combo_condiciones.FindStringExact("OTRO MEDIO DE PAGO")
            Dim total_opciones As Integer = Combo_venta.Items.Count - 1
            'Dim posicion_vacio As Integer = combo_condiciones.FindStringExact("-")
            Combo_venta.Focus()




            If Combo_venta.SelectedIndex + 1 > total_opciones Then
                Combo_venta.SelectedIndex = 0
            Else
                Combo_venta.SelectedIndex = Combo_venta.SelectedIndex + 1
            End If




        End If

        If e.KeyCode = Keys.F10 Then
            combo_condiciones.Focus()
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

            If vuelto = "SI" Then
                If txt_efectivo.Focused = True Then
                    btn_grabar.PerformClick()
                    Exit Sub
                Else
                    txt_efectivo.Focus()
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

    Private Sub Form_venta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        grabar_documento_temporal()
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_venta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'dtp_fecha.CustomFormat = "yyy-MM-dd"

        limpiar()
        cargar_logo()
        valores()
        controles(False, True)
        revisar_vuelto()
        txt_porcentaje_desc.Text = valor_descuento_ventas

        If mirutempresa = "87686300-6" Then
            tipo_impresion_sistema = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ClickOffice\SistemaDeVentas\TipoImpresion", "TipoImpresion", Nothing)
        End If

        mostrar_valores()

        llenar_combo_venta()
        llenar_combo_condiciones()

        mostrar_datos_login()
        cargar_foto()
        cargar_documento_temporal()
        txt_codigo.Focus()
        Timer_ventas.Start()
        'Form_menu_principal.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.Value = dtp_vencimiento.Value.AddMonths(Val(+1))
        mostrar_impresora()

        Me.btn_nueva.PerformClick()

        nro_venta = 1

        CambiaColorFondo(btn_venta_1, mirutempresa)
        CambiaColorFondo(btn_nueva, mirutempresa)
        CambiaColorFondo(btn_limpiar, mirutempresa)
        CambiaColorFondo(btn_pdf, mirutempresa)
        CambiaColorFondo(btn_salir, mirutempresa)
        CambiaColorFondo(btn_grabar, mirutempresa)

        CambiaColorFondo(btn_agregar, mirutempresa)
        CambiaColorFondo(btn_quitar_elemento, mirutempresa)
        CambiaColorFondo(btn_buscar_clientes, mirutempresa)
        CambiaColorFondo(btn_buscar_productos, mirutempresa)
        CambiaColorFondo(btn_buscar_retira, mirutempresa)
        CambiaColorFondo(btn_agregar_clientes, mirutempresa)
        CambiaColorFondo(btn_agregar_retira, mirutempresa)
        CambiaColorFondo(btn_imagen, mirutempresa)
        CambiaColorFondo(btn_mensaje_cliente, mirutempresa)

        btn_venta_2.BackColor = SystemColors.Control
        btn_venta_3.BackColor = SystemColors.Control

        'btn_venta_1.BackColor = Color.DarkBlue
        'btn_venta_2.BackColor = SystemColors.Control
        'btn_venta_3.BackColor = SystemColors.Control
        btn_venta_1.ForeColor = Color.White
        btn_venta_2.ForeColor = Color.Black
        btn_venta_3.ForeColor = Color.Black

        Me.Width = 1024
        Me.Height = 728
        Centrar()

        grilla_detalle_venta.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)

        'If Combo_venta.Text = "GUIA" Then
        '    If combo_condiciones.Text = "CREDITO" Then
        '        txt_porcentaje_desc.Enabled = False
        '        txt_porcentaje_desc.Text = txt_descuento_cliente.Text
        '    Else
        '        txt_porcentaje_desc.Enabled = True
        '        txt_porcentaje_desc.Text = valor_descuento_ventas
        '    End If
        'End If




    End Sub

    Public Sub Centrar()
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (tamaño.Width - Me.Width) \ 2
        Dim posicionY As Integer = (tamaño.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
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
            impresora_ticket_cotizaciones = DS.Tables(DT.TableName).Rows(0).Item("ticket_cotizaciones")
            impresora_ticket_ventas = DS.Tables(DT.TableName).Rows(0).Item("ticket_ventas")
        End If
        conexion.Close()
    End Sub

    Sub mostrar_deuda_clientes()


        If mirutempresa = "87686300-6" And mirecintoempresa <> "BDO. O´HIGGINS 441" Then

            Try
                conexion.Close()
                conexion.ConnectionString = "server=servidorarana441.dyndns.org;Database=basededatos;User Id=sistema_general;Password=1234;Convert Zero Datetime=True;default command timeout=3600"
                conexion.Open()
                conexion.Close()

                LiberarMemoria()

            Catch ex As Exception

                'recuperar_conexion_actual()
                MsgBox(ex, 0 + 16, "ERROR")

            End Try

        End If

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "SELECT sum(saldo) as deuda FROM creditos where rut_cliente ='" & (txt_rut_cliente.Text) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                deuda = DS.Tables(DT.TableName).Rows(0).Item("deuda")
            End If
            conexion.Close()
        Catch err As InvalidCastException
            deuda = "0"

            recuperar_conexion_actual()

            Exit Sub
        End Try

        recuperar_conexion_actual()
    End Sub

    Sub mostrar_valores()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from valores"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            redondear_venta = DS.Tables(DT.TableName).Rows(0).Item("redondear_venta")
        End If
        conexion.Close()
    End Sub

    Sub mostrar_datos_login()
        lbl_usuario.Text = minombre & vbCrLf & miarea
        Me.txt_nombre_usuario.Text = minombre
        Me.txt_rut_vendedor.Text = miusuario
    End Sub

    Sub llenar_combo_venta()
        Combo_venta.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from formas_de_pago group by tipo_documento"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_venta.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("tipo_documento"))
            Next
        End If
        conexion.Close()

        Combo_venta.Items.Add("GUIA")

        If mirutempresa = "87686300-6" Then
            Combo_venta.Items.Add("FACTURA DE CREDITO")
            Combo_venta.Items.Add("BOLETA DE CREDITO")
        End If

        Combo_venta.SelectedItem = "BOLETA"
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
        SC3.CommandText = "select * from formas_de_pago where tipo_documento= '" & (Combo_venta.Text) & "'"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_condiciones.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("forma_de_pago"))
            Next
            combo_condiciones.Items.Add("OTRO MEDIO DE PAGO")
        End If
        conexion.Close()

        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()
        SC2.Connection = conexion
        SC2.CommandText = "select * from formas_de_pago where tipo_documento ='" & (Combo_venta.Text) & "' and por_defecto='SI'"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            combo_condiciones.SelectedItem = DS2.Tables(DT2.TableName).Rows(0).Item("forma_de_pago")
        Else
            combo_condiciones.Items.Add("-")
            combo_condiciones.SelectedItem = "-"
        End If
        conexion.Close()

        If Combo_venta.SelectedItem = "GUIA" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.Items.Add("TRASLADO")
            combo_condiciones.SelectedItem = "CREDITO"
        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.SelectedItem = "CREDITO"
        End If

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
            combo_condiciones.Items.Clear()
            combo_condiciones.Items.Add("CREDITO")
            combo_condiciones.SelectedItem = "CREDITO"
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
        txt_tipo_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_descuento_cliente.Text = ""
        txt_giro_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_telefono.Text = ""
        txt_folio.Text = ""
        txt_descuento_cliente_2.Text = ""
        txt_orden_de_compra.Text = ""
        txt_tipo_documento.Text = ""
        txt_cupo.Text = "0"
        'txt_pagare.Text = ""
    End Sub

    Sub limpiar_datos_clientes_retira()
        txt_rut_retira.Text = ""
        txt_nombre_retira.Text = ""
    End Sub

    Sub cargar_logo()
        Try
            'PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub cargar_foto()
        Dim ruta_fotografia As String = ""
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select ruta_imagen_fotografia from rutas_imagenes"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            ruta_fotografia = DS.Tables(DT.TableName).Rows(0).Item("ruta_imagen_fotografia")
            ruta_fotografia = ruta_fotografia & txt_rut_vendedor.Text & ".jpg"
        End If
        conexion.Close()
    End Sub

    Sub cargar_documento()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarTotal As Integer
        Dim VarPrecioReal As Integer
        Dim iva_valor As String
        'Dim nombre As String
        'Dim valor As String
        'Dim descuento As String
        'Dim total As String
        'Dim subtotal As String
        Dim VarUnidadMedida As String = ""

        grilla_detalle_venta.Rows.Clear()

        If Combo_venta.Text = "BOLETA" Or Combo_venta.Text = "BOLETA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (txt_cargar.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                        VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                    varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                    VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                    VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
                    VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                    VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                    VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                    VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")

                    VarValorUnitario = Val(VarTotal / VarCantidad)

                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                        VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                    VarPorcentaje = 100 - VarPorcentaje
                    VarDescuento = VarPrecioReal - VarValorUnitario

                    VarDescuento = VarDescuento * VarCantidad

                    VarValorUnitario = VarPrecioReal
                    iva_valor = valor_iva / 100 + 1
                    VarNeto = (VarTotal / iva_valor)
                    VarIva = (VarNeto) * valor_iva / 100



                    If VarDescuento < 0 Then
                        VarDescuento = 0
                        VarPorcentaje = 0
                        VarValorUnitario = VarTotal / VarCantidad
                    End If

                    grilla_detalle_venta.Rows.Add(VarCodProducto,
                    varnombre,
                    vartecnico,
                    VarValorUnitario,
                    VarCantidad,
                    VarNeto,
                    VarIva,
                    VarSubtotal,
                    VarPorcentaje,
                    VarDescuento,
                    VarTotal,
                    VarUnidadMedida)
                Next

                If grilla_detalle_venta.Rows.Count <> 0 Then
                    If grilla_detalle_venta.Columns(0).Width = 85 Then
                        grilla_detalle_venta.Columns(0).Width = 86
                    Else
                        grilla_detalle_venta.Columns(0).Width = 85
                    End If
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
                End If
            End If

            txt_porcentaje_desc.Text = "0"


            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from  boleta, clientes where n_boleta='" & (txt_cargar.Text) & "' and boleta.rut_cliente=clientes.rut_cliente"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            End If


            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes, boleta where clientes.rut_cliente = boleta.rut_cliente and boleta.n_boleta='" & (txt_cargar.Text) & "'"
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
                txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                'txt_pagare.Text = DS.Tables(DT.TableName).Rows(0).Item("pagare")
                txt_cupo.Text = Val(DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente"))
                txt_codigo.Focus()
                conexion.Close()
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

        End If

        If Combo_venta.Text = "FACTURA" Or Combo_venta.Text = "FACTURA DE CREDITO" Then
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
                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                        VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                    varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                    VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                    VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
                    VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                    VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                    VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                    VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")

                    VarValorUnitario = Val(VarTotal / VarCantidad)

                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                        VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                    VarPorcentaje = 100 - VarPorcentaje
                    VarDescuento = VarPrecioReal - VarValorUnitario

                    VarDescuento = VarDescuento * VarCantidad

                    VarValorUnitario = VarPrecioReal
                    iva_valor = valor_iva / 100 + 1
                    VarNeto = (VarTotal / iva_valor)
                    VarIva = (VarNeto) * valor_iva / 100



                    If VarDescuento < 0 Then
                        VarDescuento = 0
                        VarPorcentaje = 0
                        VarValorUnitario = VarTotal / VarCantidad
                    End If

                    grilla_detalle_venta.Rows.Add(VarCodProducto,
                    varnombre,
                    vartecnico,
                    VarValorUnitario,
                    VarCantidad,
                    VarNeto,
                    VarIva,
                    VarSubtotal,
                    VarPorcentaje,
                    VarDescuento,
                    VarTotal,
                    VarUnidadMedida)
                Next

                If grilla_detalle_venta.Rows.Count <> 0 Then
                    If grilla_detalle_venta.Columns(0).Width = 85 Then
                        grilla_detalle_venta.Columns(0).Width = 86
                    Else
                        grilla_detalle_venta.Columns(0).Width = 85
                    End If
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
                End If

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from  factura, clientes where n_factura='" & (txt_cargar.Text) & "' and factura.rut_cliente=clientes.rut_cliente"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                End If

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from clientes, factura where clientes.rut_cliente = factura.rut_cliente and factura.n_factura='" & (txt_cargar.Text) & "'"
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
                    txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                    txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                    txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                    txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                    txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                    txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                    txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                    'txt_pagare.Text = DS.Tables(DT.TableName).Rows(0).Item("pagare")
                    txt_cupo.Text = Val(DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente"))
                    txt_codigo.Focus()
                    conexion.Close()
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




            End If
        End If


        If Combo_venta.Text = "COTIZACION" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_cotizacion where detalle_cotizacion.n_cotizacion='" & (txt_cargar.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                        VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    '    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                    '    DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                    '    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                    '    DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                    '    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                    '    DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                    '    DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                    '    DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                    '    DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                    '    DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                    '    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                    '    VarUnidadMedida)
                    'Next
                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                    varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                    VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                    VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
                    VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                    VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                    VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                    VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")

                    'If VarCantidad = "0" Then
                    '    VarCantidad = "1"
                    'End If

                    VarValorUnitario = Val(VarTotal / VarCantidad)

                    If VarCodProducto <> "*" Then
                        conexion.Close()
                        DS2.Tables.Clear()
                        DT2.Rows.Clear()
                        DT2.Columns.Clear()
                        DS2.Clear()
                        conexion.Open()
                        SC2.Connection = conexion
                        SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                        DA2.SelectCommand = SC2
                        DA2.Fill(DT2)
                        DS2.Tables.Add(DT2)
                        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                            VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                            VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                        End If
                        conexion.Close()
                    Else
                        VarPrecioReal = VarValorUnitario
                        VarUnidadMedida = "UNIDAD"
                    End If

                    If VarPrecioReal = "0" Then
                        VarPrecioReal = VarValorUnitario
                    End If

                    VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                    VarPorcentaje = 100 - VarPorcentaje
                    VarDescuento = VarPrecioReal - VarValorUnitario
                    VarValorUnitario = VarPrecioReal
                    iva_valor = valor_iva / 100 + 1
                    VarNeto = (VarTotal / iva_valor)
                    VarIva = (VarNeto) * valor_iva / 100

                    VarDescuento = VarDescuento * VarCantidad

                    If VarDescuento < "0" Then
                        VarValorUnitario = VarTotal / VarCantidad
                        VarPrecioReal = VarValorUnitario
                        VarPorcentaje = "0"
                        VarDescuento = "0"
                    End If


                    grilla_detalle_venta.Rows.Add(VarCodProducto,
                    varnombre,
                    vartecnico,
                    VarValorUnitario,
                    VarCantidad,
                    VarNeto,
                    VarIva,
                    VarSubtotal,
                    VarPorcentaje,
                    VarDescuento,
                    VarTotal,
                    VarUnidadMedida)
                Next


                If grilla_detalle_venta.Rows.Count <> 0 Then
                    If grilla_detalle_venta.Columns(0).Width = 85 Then
                        grilla_detalle_venta.Columns(0).Width = 86
                    Else
                        grilla_detalle_venta.Columns(0).Width = 85
                    End If
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
                End If

                'conexion.Close()
                'DS.Tables.Clear()
                'DT.Rows.Clear()
                'DT.Columns.Clear()
                'DS.Clear()
                'conexion.Open()
                'SC.Connection = conexion
                'SC.CommandText = "select * from clientes, cotizacion where cod_cliente = cotizacion.codigo_cliente and cotizacion.n_cotizacion='" & (txt_cargar.Text) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
                'DS.Tables.Add(DT)

                'If DS.Tables(DT.TableName).Rows.Count > 0 Then
                '    txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                '    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                '    txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                '    txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                '    txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                '    txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                '    txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
                '    txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
                '    txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                '    txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
                '    txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                '    txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                '    txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                '    txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                '    txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                '    txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                '    txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                '    txt_pagare.Text = DS.Tables(DT.TableName).Rows(0).Item("pagare")
                '    txt_nro_cotizacion.Text = DS.Tables(DT.TableName).Rows(0).Item("n_cotizacion")
                '    txt_rut_asistente.Text = DS.Tables(DT.TableName).Rows(0).Item("usuario_responsable")
                '    Combo_nivel_asistencia.Text = DS.Tables(DT.TableName).Rows(0).Item("nivel_asistencia")

                '    txt_saldo.Text = Val(DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")) - Val(DS.Tables(DT.TableName).Rows(0).Item("saldo_cliente"))

                '    If Combo_nivel_asistencia.Text <> "-" Then
                '        conexion.Close()
                '        DS.Tables.Clear()
                '        DT.Rows.Clear()
                '        DT.Columns.Clear()
                '        DS.Clear()
                '        conexion.Open()

                '        SC.Connection = conexion
                '        SC.CommandText = "select * from usuarios where rut_usuario='" & (txt_rut_asistente.Text) & "'"
                '        DA.SelectCommand = SC
                '        DA.Fill(DT)
                '        DS.Tables.Add(DT)

                '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
                '            Me.lbl_asistencia.Text = "NIVEL DE ASISTENCIA " & Combo_nivel_asistencia.Text & vbCrLf & DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
                '        End If
                '    Else
                '        Me.lbl_asistencia.Text = "CALL CENTER" & vbCrLf & "-"
                '    End If
                conexion.Close()
                'End If
            End If

            txt_porcentaje_desc.Text = ""

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from  cotizacion, clientes where n_cotizacion='" & (txt_cargar.Text) & "' and cotizacion.rut_cliente=clientes.rut_cliente"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes, cotizacion where clientes.rut_cliente = cotizacion.rut_cliente and cotizacion.n_cotizacion='" & (txt_cargar.Text) & "'"
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
                txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                'txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                'txt_pagare.Text = DS.Tables(DT.TableName).Rows(0).Item("pagare")
                txt_cupo.Text = Val(DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente"))

                txt_porcentaje_desc.Text = ""

                If txt_rut_cliente.Text = "-" Then
                    txt_rut_cliente.Text = ""
                    limpiar_datos_clientes()
                End If



                txt_codigo.Focus()
                conexion.Close()
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




        End If

        If Combo_venta.Text = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_guia where detalle_guia.n_guia='" & (txt_cargar.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If

                    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"),
                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"),
                    DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"),
                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"),
                    DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"),
                    VarUnidadMedida)
                Next
            End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from  guia, clientes where n_guia='" & (txt_cargar.Text) & "' and guia.rut_cliente=clientes.rut_cliente"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes, guia where clientes.rut_cliente = guia.rut_cliente and guia.n_guia='" & (txt_cargar.Text) & "'"
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
                txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                'txt_pagare.Text = DS.Tables(DT.TableName).Rows(0).Item("pagare")
                txt_cupo.Text = Val(DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente"))
                txt_codigo.Focus()
                conexion.Close()
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

        End If

        If grilla_detalle_venta.Rows.Count <> 0 Then
            If grilla_detalle_venta.Columns(0).Width = 85 Then
                grilla_detalle_venta.Columns(0).Width = 86
            Else
                grilla_detalle_venta.Columns(0).Width = 85
            End If
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
        End If
    End Sub


    Sub mostrar_datos_clientes()
        conexion.Close()
        If txt_rut_cliente.Text <> "" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                txt_tipo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cliente")
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
                txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                'txt_pagare.Text = DS.Tables(DT.TableName).Rows(0).Item("pagare")
                'txt_cupo.Text = Val(DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")) - Val(DS.Tables(DT.TableName).Rows(0).Item("saldo_cliente"))
                txt_cupo.Text = DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")

                If Val(txt_porcentaje_desc.Text) < Val(txt_descuento_cliente.Text) Then
                    txt_porcentaje_desc.Text = txt_descuento_cliente.Text
                End If


                'If Combo_venta.Text = "GUIA" Then
                '    If combo_condiciones.Text = "CREDITO" Then
                '        txt_porcentaje_desc.Enabled = False
                '        txt_porcentaje_desc.Text = txt_descuento_cliente.Text
                '    Else
                '        txt_porcentaje_desc.Enabled = True
                '        txt_porcentaje_desc.Text = valor_descuento_ventas
                '    End If
                'End If


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
                txt_tipo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cliente")
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
                txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                'txt_pagare.Text = DS.Tables(DT.TableName).Rows(0).Item("pagare")
                'txt_cupo.Text = Val(DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")) - Val(DS.Tables(DT.TableName).Rows(0).Item("saldo_cliente"))
                txt_cupo.Text = DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")
            End If

            'If Combo_venta.Text = "GUIA" Then
            '    If combo_condiciones.Text = "CREDITO" Then
            '        txt_porcentaje_desc.Enabled = False
            '        txt_porcentaje_desc.Text = txt_descuento_cliente.Text
            '    Else
            '        txt_porcentaje_desc.Enabled = True
            '        txt_porcentaje_desc.Text = valor_descuento_ventas
            '    End If
            'End If

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
                'txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                txt_medida.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_medida")
            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_retira()
        If txt_rut_retira.Text <> "" Then
            conexion.Close()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion
            SC3.CommandText = "select * from clientes_retira where rut_cliente_retira ='" & (txt_rut_retira.Text) & "'"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                txt_nombre_retira.Text = DS3.Tables(DT3.TableName).Rows(0).Item("nombre_cliente_retira")
            Else
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_retira.Focus()
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
        btn_agregar_retira.Enabled = a
        btn_buscar_retira.Enabled = a
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
        txt_rut_retira.Enabled = a

        If txt_precio_modificado.Enabled = True Then
            txt_precio_modificado.BackColor = Color.White
        Else
            txt_precio_modificado.BackColor = SystemColors.Control
        End If

        If txt_rut_cliente.Enabled = True Then
            txt_rut_cliente.BackColor = Color.White
        Else
            txt_rut_cliente.BackColor = SystemColors.Control
        End If

        If txt_rut_retira.Enabled = True Then
            txt_rut_retira.BackColor = Color.White
        Else
            txt_rut_retira.BackColor = SystemColors.Control
        End If

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

        If mirutempresa = "81921000-4" Then
            PictureBox_imagen.Enabled = False
        Else
            PictureBox_imagen.Enabled = True
        End If
        If mirutempresa = "81921000-4" Then
            txt_porcentaje_desc.Enabled = False
        End If
    End Sub

    Sub limpiar()
        txt_medida.Text = ""
        txt_cod_auto_servicio.Text = ""
        txt_tipo_cliente.Text = ""
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
        'txt_factor.Text = ""
        txt_rut_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_codigo.Text = ""
        txt_descuento_cliente.Text = ""
        txt_desc.Text = ""
        txt_total.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_porcentaje_desc.Text = valor_descuento_ventas
        txt_nombre_retira.Text = ""
        txt_rut_retira.Text = ""
        txt_rut_cliente.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_giro_cliente.Text = ""
        txt_telefono.Text = ""
        txt_folio.Text = ""
        txt_ciudad_cliente.Text = ""
        txt_correo_cliente.Text = ""
        txt_aplicacion.Text = ""
        txt_descuento_cliente_2.Text = ""
        txt_nombre_usuario.Text = minombre
        cargar_foto()
        txt_orden_de_compra.Text = ""
        grilla_detalle_venta.Rows.Clear()
        txt_item.Text = "0"
        txt_codigo_convenio.Text = "0"
        txt_codigo.Text = ""
        txt_rut_cliente.Text = ""
        txt_tipo_documento.Text = ""
        Combo_venta.Text = ""
        combo_condiciones.Text = ""

        llenar_combo_venta()

        txt_sub_total_millar.Text = ""
        txt_neto_millar.Text = ""
        txt_iva_millar.Text = ""
        txt_desc_millar.Text = ""
        txt_total_millar.Text = ""

        txt_desc_total.Text = "0"
        txt_cupo.Text = "0"
        txt_nro_orden_de_compra.Text = ""
        'txt_nro_cotizacion.Text = ""

        txt_total_millar.Text = ""
        txt_efectivo.Text = ""
        txt_vuelto.Text = ""

        doc_otro = "-"

        nro_801 = "0"
        nro_802 = "0"
        nro_hes = "0"
        nro_otro = "0"
        codigo_doc_otro = "0"

        fecha_801 = "0000-00-00"
        fecha_802 = "0000-00-00"
        fecha_hes = "0000-00-00"
        fecha_otro = "0000-00-00"

        txt_codigo.Focus()
    End Sub

    Sub limpiar_datos_productos()
        txt_medida.Text = ""
        txt_cantidad.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        'txt_factor.Text = ""
        txt_numero_tecnico.Text = ""
        txt_marca.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
    End Sub

    'Sub crear_numero_cotizacion()
    'conexion.Close()
    'DS.Tables.Clear()
    'DT.Rows.Clear()
    'DT.Columns.Clear()
    'DS.Clear()
    'conexion.Open()
    'Try
    '    SC.Connection = conexion
    '    SC.CommandText = "select max(cod_auto) as cod_auto from cotizacion"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
    '    End If
    'Catch err As InvalidCastException
    '    txt_nro_cotizacion.Text = 1
    '    Exit Sub
    'End Try
    'conexion.Close()

    'DS.Tables.Clear()
    'DT.Rows.Clear()
    'DT.Columns.Clear()
    'DS.Clear()
    'conexion.Open()
    'Try
    '    SC.Connection = conexion
    '    SC.CommandText = "select n_cotizacion from cotizacion where cod_auto='" & (varnumdoc) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_cotizacion")
    '        txt_nro_cotizacion.Text = varnumdoc + 1
    '    End If
    'Catch err As InvalidCastException
    '    txt_nro_cotizacion.Text = 1
    'End Try
    'conexion.Close()
    'End Sub

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

        If tipo_impresion_sistema = "TICKET" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(n_ticket) as n_ticket from ticket_venta"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_ticket")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
                Exit Sub
            End Try
            conexion.Close()

            Exit Sub
        End If

        If Combo_venta.Text = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from factura where tipo_impresion <> 'DIGITADA'"
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
                SC.CommandText = "select n_factura from factura where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from factura where tipo_impresion <> 'DIGITADA'"
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
                SC.CommandText = "select n_factura from factura where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If

        If Combo_venta.Text = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from guia where tipo_impresion <> 'DIGITADA'"
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
                SC.CommandText = "select n_guia from guia where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_guia")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If

        If Combo_venta.Text = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from BOLETA where tipo_impresion <> 'DIGITADA'"
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
                SC.CommandText = "select n_boleta from BOLETA where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from BOLETA where tipo_impresion <> 'DIGITADA'"
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
                SC.CommandText = "select n_boleta from BOLETA where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
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

            txt_numero_tecnico.Text = txt_numero_tecnico.Text & " " & txt_aplicacion.Text

            If txt_numero_tecnico.Text.Length > 44 Then
                txt_numero_tecnico.Text = txt_numero_tecnico.Text.Substring(0, 44)
            End If

            grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total, txt_medida.Text)
            calcular_totales()
            limpiar_datos_productos()

            calcular_vuelto()

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

            txt_numero_tecnico.Text = txt_numero_tecnico.Text & " " & txt_aplicacion.Text

            If txt_numero_tecnico.Text.Length > 44 Then
                txt_numero_tecnico.Text = txt_numero_tecnico.Text.Substring(0, 44)
            End If

            grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, precio_lista, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total, txt_medida.Text)

            calcular_totales()
            limpiar_datos_productos()

            calcular_vuelto()

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
        Dim codigo_de_barras As String

        cantidad_caracteres = Len(txt_codigo.Text)
        codigo_de_barras = txt_codigo.Text

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
                    'txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                    txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                    txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    txt_medida.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_medida")

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
                txt_nombre_producto.Text = codigo_de_barras & " " & DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                'txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
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

        If Combo_venta.Text <> "BOLETA" And Combo_venta.Text <> "BOLETA DE CREDITO" And Combo_venta.Text <> "FACTURA" And Combo_venta.Text <> "FACTURA DE CREDITO" And Combo_venta.Text <> "GUIA" And Combo_venta.Text <> "COTIZACION" Then
            Combo_venta.Focus()
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If




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

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
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
        Try
            If redondear_venta = "SI" Then
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
            End If
        Catch
            limpiar()
        End Try
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_detalle_venta.Rows.Count > 0 Then
            grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.CurrentRow)
            calcular_totales()
            txt_item.Text = grilla_detalle_venta.Rows.Count
            txt_cod_auto_servicio.Text = ""
            txt_codigo.Focus()
        End If
    End Sub
    Sub garantia_zapatillas()
        Dim VarCodProducto As String
        Dim VarCodFamilia As String = ""
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            VarCodFamilia = ""
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarCodFamilia = DS.Tables(DT.TableName).Rows(0).Item("familia")
            End If
            conexion.Close()

            If VarCodFamilia = "1" Then

                With Print_garantia.PrinterSettings
                    .PrinterName = impresora_ticket_cotizaciones
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.Print_garantia.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Print_garantia.DefaultPageSettings.PaperSize = pkCustomSize1
                        Print_garantia.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Print_garantia.Print()
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                    End If
                End With

                Exit Sub
            End If
        Next

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

        If mirutempresa = "76313245-5" Then
            garantia_zapatillas()
        End If

        If mirutempresa = "87686300-6" Then
            If combo_condiciones.Text = "PENDIENTE" Then
                If Combo_venta.Text = "BOLETA" Then
                    Combo_venta.Text = "BOLETA DE CREDITO"
                End If
                If Combo_venta.Text = "FACTURA" Then
                    Combo_venta.Text = "FACTURA DE CREDITO"
                End If
            End If
        End If

        If Combo_venta.Text = "BOLETA" Then

            'ZAPATILLAS
            If mirutempresa = "76313245-5" Then
                crear_numero_documento()

                With pd_ticket_de_cambio.PrinterSettings
                    .PrinterName = impresora_boletas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.pd_ticket_de_cambio.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.pd_ticket_de_cambio.DefaultPageSettings.PaperSize = pkCustomSize1
                        pd_ticket_de_cambio.PrintController = New System.Drawing.Printing.StandardPrintController()
                        pd_ticket_de_cambio.Print()

                    Else

                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            End If




            If tipo_impresion_boleta = "INTERNA" Then
                With Pd_Ticket_Interno.PrinterSettings
                    .PrinterName = impresora_ticket_ventas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.crear_numero_documento()
                        Me.grabar_factura()
                        'Me.PrintDocument_ticket_interno.PrintController = New StandardPrintController
                        'Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        'Me.PrintDocument_ticket_interno.DefaultPageSettings.PaperSize = pkCustomSize1
                        'PrintDocument_ticket_interno.PrintController = New System.Drawing.Printing.StandardPrintController()
                        'PrintDocument_ticket_interno.Print()


                        Me.Pd_Ticket_Interno.PrintController = New StandardPrintController

                        Try
                            Pd_Ticket_Interno.DefaultPageSettings.Landscape = False
                        Catch ex As Exception
                            MsgBox(ex)
                        End Try

                        Pd_Ticket_Interno.PrinterSettings.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("1", 280, 13000)
                        Dim rollo As New PaperSize("New Long Roll", 280, 1900)
                        Pd_Ticket_Interno.DefaultPageSettings.PaperSize = rollo
                        Pd_Ticket_Interno.Print()




                        grabar_detalle_factura()
                        Me.crear_archivo_plano()
                        Form_autorizacion.Close()
                        Me.limpiar()
                        Form_tipo_despacho.Close()
                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With

            End If

            If tipo_impresion_boleta = "MANUAL" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_boletas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.Enabled = False
                        Me.crear_numero_documento()
                        Me.grabar_factura()
                        Me.Pd.PrintController = New StandardPrintController
                        Me.Pd.DefaultPageSettings.Margins.Left = 10
                        Me.Pd.DefaultPageSettings.Margins.Right = 10
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        Form_autorizacion.Close()
                        Me.grabar_detalle_factura()
                        ticket_de_cambio = "NO"
                        If mirutempresa = "76313245-5" Then
                            ticket_de_cambio = "SI"
                            ticket_cambio()
                            ticket_de_cambio = "NO"
                        End If
                        Me.limpiar()
                        Form_tipo_despacho.Close()
                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            End If

            If tipo_impresion_boleta = "ELECTRONICA" Then
                Me.Enabled = False
                If mirutempresa = "87686300-6" Then
                    malla_productos()
                End If
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                Me.crear_archivo_plano()
                Form_autorizacion.Close()
                Me.limpiar()
                Form_tipo_despacho.Close()
                lbl_mensaje.Visible = False
                Me.Enabled = True

                LiberarMemoria()

                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo.Focus()
                Exit Sub
            End If

            If tipo_impresion_boleta = "SIN IMPRESION" Then
                Me.Enabled = False
                If mirutempresa = "87686300-6" Then
                    malla_productos()
                End If
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                Form_autorizacion.Close()
                Me.limpiar()
                Form_tipo_despacho.Close()
                lbl_mensaje.Visible = False
                Me.Enabled = True

                LiberarMemoria()

                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo.Focus()
                Exit Sub
            End If


            'If tipo_impresion_sistema = "TICKET" Then
            '    With Pd.PrinterSettings
            '        'Especifico el nombre de la impresora
            '        'por donde deseo imprimir.
            '        .PrinterName = impresora_ticket_ventas
            '        'Establezco el número de copias que se imprimirán
            '        .Copies = 1
            '        'Rango de páginas que se imprimirán
            '        .PrintRange = PrintRange.AllPages
            '        If .IsValid Then
            '            Me.crear_numero_documento()
            '            Me.grabar_factura()
            '            Me.Pd.PrintController = New StandardPrintController
            '            Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
            '            Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
            '            Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
            '            Pd.Print()
            '            Me.grabar_detalle_factura()

            '            Me.crear_archivo_plano()
            '            Form_autorizacion.Close()

            '            Form_tipo_despacho.Close()

            '            lbl_mensaje.Visible = False
            '            Me.Enabled = True

            '            LiberarMemoria()

            '            MsgBox("EL NRO. DE TICKET ES: " & txt_factura.Text, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

            '            Me.limpiar()
            '            'Me.controles(False, True)
            '            'Me.controles(True, False)
            '            txt_codigo.Focus()

            '            Exit Sub
            '        Else
            '            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
            '            lbl_mensaje.Visible = False
            '            Me.Enabled = True
            '            Exit Sub
            '        End If
            '    End With
            'End If


            'If estado_boleta_electronica = "NO" Then
            '    If impresora_boletas = "TICKET INTERNO" Then



            '        With PrintDocument_ticket_interno.PrinterSettings
            '            .PrinterName = impresora_ticket_ventas
            '            .Copies = 1
            '            .PrintRange = PrintRange.AllPages
            '            If .IsValid Then
            '                Me.crear_numero_documento()
            '                Me.grabar_factura()
            '                Me.PrintDocument_ticket_interno.PrintController = New StandardPrintController
            '                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
            '                Me.PrintDocument_ticket_interno.DefaultPageSettings.PaperSize = pkCustomSize1
            '                PrintDocument_ticket_interno.PrintController = New System.Drawing.Printing.StandardPrintController()
            '                PrintDocument_ticket_interno.Print()
            '                grabar_detalle_factura()
            '                Me.crear_archivo_plano()
            '                Form_autorizacion.Close()
            '                Me.limpiar()
            '                'Me.controles(False, True)
            '                'Me.controles(True, False)
            '                'txt_codigo.Focus()

            '                Form_tipo_despacho.Close()

            '                lbl_mensaje.Visible = False
            '                Me.Enabled = True

            '                LiberarMemoria()

            '                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            '                txt_codigo.Focus()
            '                Exit Sub
            '            Else
            '                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
            '                lbl_mensaje.Visible = False
            '                Me.Enabled = True
            '                Exit Sub
            '            End If
            '        End With
            '    End If
            'End If


            'If estado_boleta_electronica = "NO" Then
            '    With Pd.PrinterSettings
            '        .PrinterName = impresora_boletas
            '        .Copies = 1
            '        .PrintRange = PrintRange.AllPages
            '        If .IsValid Then
            '            Me.Enabled = False
            '            Me.crear_numero_documento()
            '            Me.grabar_factura()
            '            Me.Pd.PrintController = New StandardPrintController
            '            Me.Pd.DefaultPageSettings.Margins.Left = 10
            '            Me.Pd.DefaultPageSettings.Margins.Right = 10
            '            Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
            '            Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
            '            Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
            '            Pd.Print()
            '            Form_autorizacion.Close()
            '            Me.grabar_detalle_factura()
            '            Me.crear_archivo_plano()
            '            ticket_de_cambio = "NO"
            '            If mirutempresa = "76313245-5" Then
            '                ticket_de_cambio = "SI"
            '                ticket_cambio()
            '                ticket_de_cambio = "NO"
            '            End If
            '            Me.limpiar()
            '            'Me.controles(False, True)
            '            'Me.controles(True, False)
            '            'txt_codigo.Focus()

            '            Form_tipo_despacho.Close()

            '            lbl_mensaje.Visible = False
            '            Me.Enabled = True

            '            LiberarMemoria()

            '            MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            '            txt_codigo.Focus()
            '            'End If
            '            Exit Sub
            '        Else
            '            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
            '            lbl_mensaje.Visible = False
            '            Me.Enabled = True
            '            Exit Sub
            '        End If
            '    End With
            'Else
            '    Me.Enabled = False
            '    If mirutempresa = "87686300-6" Then
            '        malla_productos()
            '    End If
            '    Me.crear_numero_documento()
            '    Me.grabar_factura()
            '    Me.grabar_detalle_factura()
            '    Me.crear_archivo_plano()
            '    Form_autorizacion.Close()
            '    Me.limpiar()
            '    'Me.controles(False, True)
            '    'Me.controles(True, False)
            '    'txt_codigo.Focus()

            '    Form_tipo_despacho.Close()

            '    lbl_mensaje.Visible = False
            '    Me.Enabled = True

            '    LiberarMemoria()

            '    MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            '    txt_codigo.Focus()
            '    Exit Sub
            'End If
        End If

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
            If tipo_impresion_sistema = "TICKET" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_ticket_ventas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.crear_numero_documento()
                        Me.grabar_factura()
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        Me.grabar_detalle_factura()

                        Me.crear_archivo_plano()
                        Form_autorizacion.Close()
                        Me.limpiar()
                        'Me.controles(False, True)
                        'Me.controles(True, False)
                        'txt_codigo.Focus()

                        Form_tipo_despacho.Close()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            End If

            If estado_boleta_electronica = "NO" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_boletas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.Enabled = False
                        Me.crear_numero_documento()
                        Me.grabar_factura()
                        Me.Pd.PrintController = New StandardPrintController
                        Me.Pd.DefaultPageSettings.Margins.Left = 10
                        Me.Pd.DefaultPageSettings.Margins.Right = 10
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        Me.grabar_detalle_factura()
                        Me.crear_archivo_plano()
                        Form_autorizacion.Close()
                        Me.limpiar()
                        'Me.controles(False, True)
                        'Me.controles(True, False)
                        'txt_codigo.Focus()

                        Form_tipo_despacho.Close()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                Me.Enabled = False
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                Me.crear_archivo_plano()
                Form_autorizacion.Close()
                Me.limpiar()
                'Me.controles(False, True)
                'Me.controles(True, False)
                'txt_codigo.Focus()

                Form_tipo_despacho.Close()

                lbl_mensaje.Visible = False
                Me.Enabled = True

                LiberarMemoria()

                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo.Focus()
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "GUIA" Then
            If tipo_impresion_sistema = "TICKET" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_ticket_ventas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.crear_numero_documento()
                        Me.grabar_factura()
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        Me.grabar_detalle_factura()

                        Me.crear_archivo_plano()
                        Form_autorizacion.Close()
                        Me.limpiar()
                        'Me.controles(False, True)
                        'Me.controles(True, False)
                        'txt_codigo.Focus()

                        Form_tipo_despacho.Close()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            End If

            If estado_guia_electronica = "NO" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_guias
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.crear_numero_documento()
                        Me.grabar_factura()
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        Me.grabar_detalle_factura()
                        Me.crear_archivo_plano()
                        Form_autorizacion.Close()
                        Me.limpiar()
                        'Me.controles(False, True)
                        'Me.controles(True, False)
                        'txt_codigo.Focus()

                        Form_tipo_despacho.Close()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                Me.crear_archivo_plano()
                Form_autorizacion.Close()
                Me.limpiar()
                'Me.controles(False, True)
                'Me.controles(True, False)
                'txt_codigo.Focus()

                Form_tipo_despacho.Close()

                lbl_mensaje.Visible = False
                Me.Enabled = True

                LiberarMemoria()

                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo.Focus()
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            If tipo_impresion_sistema = "TICKET" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_ticket_ventas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.crear_numero_documento()
                        Me.grabar_factura()
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        Me.grabar_detalle_factura()

                        Form_autorizacion.Close()
                        Me.limpiar()
                        'Me.controles(False, True)
                        'Me.controles(True, False)
                        'txt_codigo.Focus()

                        Form_tipo_despacho.Close()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            End If

            If estado_factura_electronica = "NO" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_facturas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.crear_numero_documento()
                        Me.grabar_factura()
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        Me.grabar_detalle_factura()
                        Me.crear_archivo_plano()
                        Form_autorizacion.Close()
                        Me.limpiar()
                        'Me.controles(False, True)
                        'Me.controles(True, False)
                        'txt_codigo.Focus()

                        Form_tipo_despacho.Close()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                Me.crear_archivo_plano()
                Form_autorizacion.Close()
                Me.limpiar()
                'Me.controles(False, True)
                'Me.controles(True, False)
                'txt_codigo.Focus()

                Form_tipo_despacho.Close()

                lbl_mensaje.Visible = False
                Me.Enabled = True

                LiberarMemoria()

                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo.Focus()
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "COTIZACION" Then
            Form_enviar_correo_cotizacion_ventas.txt_nombre_cliente.Text = txt_nombre_cliente.Text
            Me.Enabled = False

            'If mirutempresa = "87686300-6" Then
            '    malla_productos()
            'End If

            If txt_cod_cliente.Text = "" Then
                txt_rut_cliente.Text = "-"
                txt_cod_cliente.Text = "0"
            End If


            If mirutempresa = "87686300-6" Then
                malla_productos()
            End If

            With PrintDocument_cotizacion.PrinterSettings
                .PrinterName = impresora_ticket_cotizaciones
                .Copies = 1
                .PrintRange = PrintRange.AllPages



                If .IsValid Then
                    Me.crear_numero_documento()
                    Me.grabar_factura()
                    Me.PrintDocument_cotizacion.PrintController = New StandardPrintController

                    Try
                        PrintDocument_cotizacion.DefaultPageSettings.Landscape = False
                    Catch ex As Exception
                        MsgBox(ex)
                    End Try

                    PrintDocument_cotizacion.PrinterSettings.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("1", 280, 13000)
                    Dim rollo As New PaperSize("New Long Roll", 280, 1900)
                    PrintDocument_cotizacion.DefaultPageSettings.PaperSize = rollo
                    PrintDocument_cotizacion.Print()
                    grabar_detalle_factura()

                    LiberarMemoria()
                    grilla_detalle_venta.Rows.Clear()

                    Dim valormensaje As Integer
                    valormensaje = MsgBox("¿DESEA ENVIAR LA COTIZACION POR CORREO ELECTRONICO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "ATENCION")
                    If valormensaje = vbYes Then
                        Form_enviar_correo_cotizacion_ventas.Show()
                        Form_enviar_correo_cotizacion_ventas.txt_nro_cotizacion.Text = Me.txt_factura.Text

                        Me.limpiar()

                    Else
                        Me.limpiar()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        'Me.btn_nueva.Focus()
                        txt_codigo.Focus()
                        Exit Sub
                    End If
                    Exit Sub
                Else
                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End With



            'With PrintDocument_cotizacion.PrinterSettings
            '    .PrinterName = impresora_ticket
            '    .Copies = 1
            '    .PrintRange = PrintRange.AllPages
            '    If .IsValid Then
            '        'Me.crear_numero_documento()
            '        'Me.grabar_factura()
            '        Me.PrintDocument_cotizacion.PrintController = New StandardPrintController
            '        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
            '        Me.PrintDocument_cotizacion.DefaultPageSettings.PaperSize = pkCustomSize1
            '        PrintDocument_cotizacion.PrintController = New System.Drawing.Printing.StandardPrintController()
            '        PrintDocument_cotizacion.Print()
            '        grabar_detalle_factura()
            '        Dim valormensaje As Integer
            '        valormensaje = MsgBox("¿DESEA ENVIAR LA COTIZACION POR CORREO ELECTRONICO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            '        If valormensaje = vbYes Then
            '            Form_enviar_correo_cotizacion_ventas.Show()
            '            Form_enviar_correo_cotizacion_ventas.txt_nro_cotizacion.Text = Me.txt_factura.Text
            '        Else
            '            Me.limpiar()
            '            Me.controles(False, True)
            '            lbl_mensaje.Visible = False
            '            Me.Enabled = True
            '            Me.btn_nueva.Focus()
            '            Exit Sub
            '        End If
            '        Exit Sub
            '    Else
            '        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
            '        lbl_mensaje.Visible = False
            '        Me.Enabled = True
            '        Exit Sub
            '    End If
            'End With

            'With Pd.PrinterSettings
            '    .PrinterName = impresora_ticket_2
            '    .Copies = 1
            '    .PrintRange = PrintRange.AllPages
            '    If .IsValid Then
            '        Me.crear_numero_documento()
            '        Me.grabar_factura()

            '        Try
            '            Dim iReporte As New Form_informe_cotizacion_ticket_personalizado
            '            Dim rpt As New Crystal_cotizacion_ticket_personalizado

            '            rpt.Load()
            '            rpt.SetDataSource(ReturnDataSetCotizacion)
            '            rpt.Refresh()

            '            iReporte.Reporte = rpt
            '            rpt.PrintOptions.PrinterName = impresora_ticket
            '            rpt.PrintToPrinter(1, False, 0, 0)
            '            grabar_detalle_factura()
            '            Dim valormensaje As Integer
            '            valormensaje = MsgBox("¿DESEA ENVIAR LA COTIZACION POR CORREO ELECTRONICO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            '            If valormensaje = vbYes Then
            '                Form_enviar_correo_cotizacion_ventas.Show()
            '                Form_enviar_correo_cotizacion_ventas.txt_nro_cotizacion.Text = Me.txt_factura.Text
            '            Else
            '                Me.limpiar()
            '                Me.controles(False, True)
            '                lbl_mensaje.Visible = False
            '                Me.Enabled = True
            '                Me.btn_nueva.Focus()
            '                Exit Sub
            '            End If
            '            Exit Sub
            '        Catch ex As Exception
            '            MsgBox(ex.Message)
            '        End Try
            '    Else
            '        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
            '        lbl_mensaje.Visible = False
            '        Me.Enabled = True
            '        Exit Sub
            '    End If
            'End With
        End If

        If Combo_venta.Text = "ASISTENCIA" Then
            Me.Enabled = False
            If txt_cod_cliente.Text = "" Then
                txt_rut_cliente.Text = "-"
                txt_cod_cliente.Text = "0"
            End If








            With PrintDocument_cotizacion.PrinterSettings
                .PrinterName = impresora_ticket_cotizaciones
                .Copies = 2
                .PrintRange = PrintRange.AllPages
                If .IsValid Then
                    Me.crear_numero_documento()
                    Me.grabar_factura()
                    Me.PrintDocument_cotizacion.PrintController = New StandardPrintController
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                    Me.PrintDocument_cotizacion.DefaultPageSettings.PaperSize = pkCustomSize1
                    PrintDocument_cotizacion.PrintController = New System.Drawing.Printing.StandardPrintController()
                    PrintDocument_cotizacion.Print()
                    grabar_detalle_factura()

                    Me.limpiar()
                    'Me.controles(False, True)
                    'Me.controles(True, False)
                    'txt_codigo.Focus()

                    lbl_mensaje.Visible = False
                    Me.Enabled = True

                    LiberarMemoria()

                    'Me.btn_nueva.Focus()
                    txt_codigo.Focus()
                    Exit Sub

                Else
                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End With

            'With Pd.PrinterSettings
            '    .PrinterName = impresora_ticket_2
            '    .Copies = 1
            '    .PrintRange = PrintRange.AllPages
            '    If .IsValid Then

            '        Me.crear_numero_documento()
            '        Me.grabar_factura()
            '        Dim iReporte As New Form_informe_cotizacion_ticket_personalizado
            '        Dim rpt As New Crystal_cotizacion_ticket_personalizado

            '        rpt.Load()
            '        rpt.SetDataSource(ReturnDataSetCotizacion)
            '        rpt.Refresh()

            '        iReporte.Reporte = rpt
            '        rpt.PrintOptions.PrinterName = impresora_ticket
            '        rpt.PrintToPrinter(1, False, 0, 0)

            '        grabar_detalle_factura()
            '        Me.limpiar()
            '        Me.controles(False, True)
            '        lbl_mensaje.Visible = False
            '        Me.Enabled = True
            '        Me.btn_nueva.Focus()
            '    End If
            'End With
        End If

        If Combo_venta.Text = "FACTURA" Then
            If tipo_impresion_sistema = "TICKET" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_ticket_ventas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.crear_numero_documento()
                        Me.grabar_factura()
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        Me.grabar_detalle_factura()

                        Form_autorizacion.Close()
                        Me.limpiar()
                        'Me.controles(False, True)
                        'Me.controles(True, False)
                        'txt_codigo.Focus()

                        Form_tipo_despacho.Close()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            End If

            If estado_factura_electronica = "NO" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_facturas
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.Enabled = False
                        Me.crear_numero_documento()
                        Me.grabar_factura()
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        Me.grabar_detalle_factura()
                        Me.crear_archivo_plano()
                        Form_autorizacion.Close()
                        Me.limpiar()
                        'Me.controles(False, True)
                        'Me.controles(True, False)
                        'txt_codigo.Focus()

                        Form_tipo_despacho.Close()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        LiberarMemoria()

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                Me.Enabled = False
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                Me.crear_archivo_plano()


                Form_autorizacion.Close()
                Me.limpiar()
                'Me.controles(False, True)
                'Me.controles(True, False)
                'txt_codigo.Focus()

                Form_tipo_despacho.Close()

                lbl_mensaje.Visible = False
                Me.Enabled = True

                LiberarMemoria()

                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo.Focus()
                Exit Sub
            End If
        End If
    End Sub

    'Sub grabar_detalle_cotizacion()
    '    Dim VarCodProducto As String
    '    Dim varnombre As String
    '    Dim vartecnico As String
    '    Dim VarValorUnitario As Integer
    '    Dim VarCantidad As String
    '    Dim VarPorcentaje As Integer
    '    Dim VarDescuento As Integer
    '    Dim VarNeto As Integer
    '    Dim VarIva As Integer
    '    Dim VarSubtotal As Integer
    '    Dim VarTotal As Integer

    '    For i = 0 To grilla_detalle_venta.Rows.Count - 1
    '        VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
    '        varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
    '        vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
    '        VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
    '        VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
    '        VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
    '        VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
    '        VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
    '        VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
    '        VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
    '        VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_cotizacion (n_cotizacion, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_nro_cotizacion.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next
    'End Sub

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
        Dim VarTipoDoc As String = ""
        Dim VarTipoMedida As String = ""

        If Combo_venta.Text = "BOLETA" Then
            VarTipoDoc = "BOLETA"
        End If

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
            VarTipoDoc = "BOLETA"
        End If

        If Combo_venta.Text = "FACTURA" Then
            VarTipoDoc = "FACTURA"
        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            VarTipoDoc = "FACTURA"
        End If

        If Combo_venta.Text = "GUIA" Then
            VarTipoDoc = "GUIA"
        End If

        Dim VarFormaDePago As String
        Dim VarMonto As Integer

        If Combo_venta.Text <> "COTIZACION" And Combo_venta.Text <> "ASISTENCIA" Then
            If tipo_impresion_sistema = "TICKET" Then

                If combo_condiciones.Text = "PAGO COMBINADO" Then
                    For i = 0 To Form_pago_combinado.grilla_pago_combinado.Rows.Count - 1
                        VarFormaDePago = Form_pago_combinado.grilla_pago_combinado.Rows(i).Cells(0).Value.ToString
                        VarMonto = Form_pago_combinado.grilla_pago_combinado.Rows(i).Cells(1).Value.ToString

                        SC.Connection = conexion
                        SC.CommandText = "insert into detalle_condicion_de_pago_temporal (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (VarMonto) & "', '" & (VarFormaDePago) & "', 'EMITIDA', '" & (Form_menu_principal.dtp_fecha.Text) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                    Next
                    Form_pago_combinado.Close()
                End If

                If combo_condiciones.Text <> "PAGO COMBINADO" And combo_condiciones.Text <> "LETRA" And combo_condiciones.Text <> "CONVENIO" Then
                    SC.Connection = conexion
                    SC.CommandText = "insert into detalle_condicion_de_pago_temporal (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (txt_total.Text) & "', '" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (Form_menu_principal.dtp_fecha.Text) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

            Else

                If combo_condiciones.Text = "PAGO COMBINADO" Then
                    For i = 0 To Form_pago_combinado.grilla_pago_combinado.Rows.Count - 1
                        VarFormaDePago = Form_pago_combinado.grilla_pago_combinado.Rows(i).Cells(0).Value.ToString
                        VarMonto = Form_pago_combinado.grilla_pago_combinado.Rows(i).Cells(1).Value.ToString

                        SC.Connection = conexion
                        SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (VarMonto) & "', '" & (VarFormaDePago) & "', 'EMITIDA', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (nombre_pc) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                    Next
                    Form_pago_combinado.Close()
                End If


                If combo_condiciones.Text <> "PAGO COMBINADO" Then
                    SC.Connection = conexion
                    SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (txt_total.Text) & "', '" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (nombre_pc) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            End If
        End If

        If tipo_impresion_sistema = "TICKET" Then
            If Combo_venta.Text <> "COTIZACION" And Combo_venta.Text <> "ASISTENCIA" Then
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

                    If VarTipoMedida = "" Then
                        VarTipoMedida = "UNIDAD"
                    End If

                    SC.Connection = conexion
                    SC.CommandText = "insert into detalle_ticket_venta (n_ticket, cod_producto, detalle_nombre, numero_tecnico, precio_lista, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, precio_venta, detalle_total, hora, usuario_responsable, fecha_venta) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'" & (hora_venta) & "','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Next
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "FACTURA" Then
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
                VarTipoMedida = grilla_detalle_venta.Rows(i).Cells(11).Value.ToString

                If VarTipoMedida = "" Then
                    VarTipoMedida = "UNIDAD"
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_factura (n_factura, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)


                If mirutempresa = "76366176-8" Then
                    VarTipoMedida = "DECIMAL"
                End If


                If VarTipoMedida = "DECIMAL" Then
                    Dim cantidad_decimal As String = ""
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()
                    SC.Connection = conexion
                    SC.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    DS.Tables.Add(DT)
                    If DS.Tables(DT.TableName).Rows.Count > 0 Then
                        cantidad_decimal = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    End If
                    conexion.Close()

                    cantidad_decimal = Val(cantidad_decimal) - Val(VarCantidad)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = '" & (cantidad_decimal) & "' where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Else
                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'FACTURA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (txt_rut_vendedor.Text) & "' ,'EMITIDA')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
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
                VarTipoMedida = grilla_detalle_venta.Rows(i).Cells(11).Value.ToString

                If VarTipoMedida = "" Then
                    VarTipoMedida = "UNIDAD"
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_factura (n_factura, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)

                If mirutempresa = "76366176-8" Then
                    VarTipoMedida = "DECIMAL"
                End If


                If VarTipoMedida = "DECIMAL" Then
                    Dim cantidad_decimal As String = ""
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()
                    SC.Connection = conexion
                    SC.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    DS.Tables.Add(DT)
                    If DS.Tables(DT.TableName).Rows.Count > 0 Then
                        cantidad_decimal = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    End If
                    conexion.Close()

                    cantidad_decimal = Val(cantidad_decimal) - Val(VarCantidad)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = '" & (cantidad_decimal) & "' where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Else
                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'FACTURA DE CREDITO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (txt_rut_vendedor.Text) & "' ,'EMITIDA')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If

        If Combo_venta.Text = "GUIA" Then
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
                VarTipoMedida = grilla_detalle_venta.Rows(i).Cells(11).Value.ToString

                If VarTipoMedida = "" Then
                    VarTipoMedida = "UNIDAD"
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_guia (n_guia, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, detalle_descuento, porcentaje_desc, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarPorcentaje) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)

                If mirutempresa = "76366176-8" Then
                    VarTipoMedida = "DECIMAL"
                End If


                If VarTipoMedida = "DECIMAL" Then
                    Dim cantidad_decimal As String = ""
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()
                    SC.Connection = conexion
                    SC.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    DS.Tables.Add(DT)
                    If DS.Tables(DT.TableName).Rows.Count > 0 Then
                        cantidad_decimal = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    End If
                    conexion.Close()

                    cantidad_decimal = Val(cantidad_decimal) - Val(VarCantidad)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = '" & (cantidad_decimal) & "' where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Else
                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'GUIA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (txt_rut_vendedor.Text) & "' ,'EMITIDA')"
                DA.SelectCommand = SC
                DA.Fill(DT)
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
                SC.CommandText = "insert into detalle_cotizacion (n_cotizacion, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If

        If Combo_venta.Text = "BOLETA" Then
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
                VarTipoMedida = grilla_detalle_venta.Rows(i).Cells(11).Value.ToString

                If VarTipoMedida = "" Then
                    VarTipoMedida = "UNIDAD"
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_boleta (n_boleta, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)

                If mirutempresa = "76366176-8" Then
                    VarTipoMedida = "DECIMAL"
                End If


                If VarTipoMedida = "DECIMAL" Then
                    Dim cantidad_decimal As String = ""
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()
                    SC.Connection = conexion
                    SC.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    DS.Tables.Add(DT)
                    If DS.Tables(DT.TableName).Rows.Count > 0 Then
                        cantidad_decimal = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    End If
                    conexion.Close()

                    cantidad_decimal = Val(cantidad_decimal) - Val(VarCantidad)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = '" & (cantidad_decimal) & "' where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Else
                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'BOLETA', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (txt_rut_vendedor.Text) & "' ,'EMITIDA')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
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
                VarTipoMedida = grilla_detalle_venta.Rows(i).Cells(11).Value.ToString

                If VarTipoMedida = "" Then
                    VarTipoMedida = "UNIDAD"
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_boleta (n_boleta, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)

                If mirutempresa = "76366176-8" Then
                    VarTipoMedida = "DECIMAL"
                End If


                If VarTipoMedida = "DECIMAL" Then
                    Dim cantidad_decimal As String = ""
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()
                    SC.Connection = conexion
                    SC.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    DS.Tables.Add(DT)
                    If DS.Tables(DT.TableName).Rows.Count > 0 Then
                        cantidad_decimal = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    End If
                    conexion.Close()

                    cantidad_decimal = Val(cantidad_decimal) - Val(VarCantidad)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = '" & (cantidad_decimal) & "' where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Else
                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'BOLETA DE CREDITO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (txt_rut_vendedor.Text) & "' ,'EMITIDA')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If
    End Sub

    'Sub grabar_cotizacion()
    '    SC.Connection = conexion
    '    SC.CommandText = "insert into cotizacion (n_cotizacion, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, usuario_responsable, hora, porcentaje_desc) values (" & (txt_nro_cotizacion.Text) & " , '" & ("COTIZACION") & "', '11111111-1','0','" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (combo_condiciones.Text) & "','" & (miusuario) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "')"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    'End Sub

    Sub grabar_factura()

        Dim tipo_impresion As String = ""
        Dim valor_pie As String
        Dim tipo_pie As String

        hora_venta = Form_menu_principal.lbl_hora.Text

        valor_pie = "0"
        tipo_pie = "-"

        Dim condicion_doc = ""
        condicion_doc = combo_condiciones.Text

        If valor_pie = "" Then
            valor_pie = "0"
        End If

        If calculo_interes = "SI" Then
            If tipo_impresion_sistema <> "TICKET" Then
                If combo_condiciones.Text = "LETRA" Then
                    condicion_doc = "CREDITO"
                End If
            End If
        End If

        If mirutempresa = "87686300-6" Then
            Dim codigo_arriendo As String = ""
            Try
                codigo_arriendo = Form_pago_combinado.grilla_pago_combinado.Rows(0).Cells(0).Value.ToString

                If codigo_arriendo = "232332" Then
                    miusuario = miusuario
                End If

            Catch
            End Try
        End If




        If mirecintoempresa = "QUECHEREGUAS 856" Then
            If txt_cod_auto_servicio.Text <> "" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE servicios_lubricentro SET estado='LISTO', tipo_documento='" & (Combo_venta.Text) & "',nro_documento = '" & (txt_factura.Text) & "'WHERE cod_auto = '" & (txt_cod_auto_servicio.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                Form_ventas_lubricentro.mostrar_malla()
            End If
        End If

        If Combo_venta.Text = "COTIZACION" Then
            SC.Connection = conexion
            SC.CommandText = "insert into cotizacion (n_cotizacion, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, usuario_responsable, hora, porcentaje_desc) values (" & (txt_factura.Text) & " , '" & ("COTIZACION") & "', '" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & (txt_rut_vendedor.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If tipo_impresion_sistema = "TICKET" Then
            If Combo_venta.Text <> "COTIZACION" Then
                If txt_cargar.Text = "" Then
                    txt_cargar.Text = "0"
                End If

                If txt_rut_retira.Text = "" Then
                    txt_rut_retira.Text = "-"
                End If

                If txt_cod_cliente.Text = "" Or txt_rut_cliente.Text = "" Or txt_nombre_cliente.Text = "" Then
                    txt_rut_cliente.Text = "11111111-1"
                    txt_cod_cliente.Text = "0"
                    txt_nombre_cliente.Text = "SIN NOMBRE"
                    txt_direccion_cliente.Text = "SIN DIRECCION"
                    txt_giro_cliente.Text = "SIN GIRO"
                    txt_comuna_cliente.Text = "SIN COMUNA"
                    txt_telefono.Text = "000000"
                    txt_correo_cliente.Text = "SIN CORREO"
                    txt_ciudad_cliente.Text = "SIN CIUDAD"
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into ticket_venta (n_ticket, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones,estado, usuario_responsable, hora, porcentaje_desc, cantidad_cuotas, rut_retira, pie, convenio, condicion_de_pago_pie) values (" & (txt_factura.Text) & " , '" & (Combo_venta.Text) & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ", '" & (combo_condiciones.Text) & "','" & ("SIN EMITIR") & "','" & (txt_rut_vendedor.Text) & "','" & (hora_venta) & "','" & (txt_porcentaje_desc.Text) & "','" & (txt_cargar.Text) & "','" & (txt_rut_retira.Text) & "', '" & (valor_pie) & "', '" & (txt_codigo_convenio.Text) & "', '" & (tipo_pie) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
                Exit Sub
            End If
        End If

        'Dim descuento_comision As Integer
        Dim total_comision As Integer
        Dim porcentaje_asistencia As Integer

        'If Combo_nivel_asistencia.Text = "-" Then
        '    porcentaje_asistencia = 100
        'End If

        'If Combo_nivel_asistencia.Text = "" Then
        porcentaje_asistencia = 100
        'End If

        'If Combo_nivel_asistencia.Text = "BASICA" Then
        '    porcentaje_asistencia = 80
        'End If

        'If Combo_nivel_asistencia.Text = "MEDIA" Then
        '    porcentaje_asistencia = 50
        'End If

        'If Combo_nivel_asistencia.Text = "COMPLETA" Then
        '    porcentaje_asistencia = 20
        'End If

        total_comision = ((txt_total.Text) * porcentaje_asistencia) / 100

        If Combo_venta.Text = "GUIA" Then
            If estado_guia_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If

            If txt_orden_de_compra.Text <> "SI" Then
                txt_orden_de_compra.Text = "0"
            End If

            Dim porcentaje_desc_guia As Integer
            Dim descuento_guia As Integer
            Dim total_guia As Integer

            If txt_descuento_cliente_2.Text = "" Or txt_descuento_cliente_2.Text = "-" Then
                porcentaje_desc_guia = 0
            Else
                porcentaje_desc_guia = txt_descuento_cliente.Text
            End If

            descuento_guia = ((total_comision) * porcentaje_desc_guia) / 100
            total_comision = Int(total_comision) - Int(descuento_guia)

            SC.Connection = conexion
            SC.CommandText = "insert into guia_comisiones (n_guia, fecha_venta, porcentaje_desc, descuento, total, estado, usuario_responsable) values (" & (txt_factura.Text) & ", '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (porcentaje_desc_guia) & "', " & (descuento_guia) & ", " & (total_guia) & ", 'SIN FACTURAR', '" & (txt_rut_vendedor.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into guia (caja, n_guia, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable,rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, vehiculo, patente, pie, condicion_de_pago_pie, comision,  orden_de_compra ,  fecha_orden_de_compra ,  nro_atencion ,  fecha_nro_atencion ,  hoja_entrada ,  fecha_hoja_entrada ,  otra_referencia ,  nro_otra_referencia ,  fecha_otra_referencia) values ('" & (nombre_pc) & "', " & (txt_factura.Text) & " , '" & ("GUIA") & "', '" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("SIN FACTURAR") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (mirecintoempresa) & "','" & (txt_nro_orden_de_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '-', '-', '" & (valor_pie) & "', '" & (tipo_pie) & "', '" & (total_comision) & "', '" & (nro_801) & "', '" & (fecha_801) & "', '" & (nro_802) & "', '" & (fecha_802) & "', '" & (nro_hes) & "', '" & (fecha_hes) & "', '" & (codigo_doc_otro) & "', '" & (nro_otro) & "', '" & (fecha_otro) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            Try
                SC.Connection = conexion
                SC.CommandText = "insert into listado_documentos (codigo_documento, caja, nro_documento, documento, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, comision,  orden_de_compra ,  fecha_orden_de_compra ,  nro_atencion ,  fecha_nro_atencion ,  hoja_entrada ,  fecha_hoja_entrada ,  otra_referencia ,  nro_otra_referencia ,  fecha_otra_referencia, tipo_de_traslado, trasladado_por) values ('52', '" & (nombre_pc) & "', " & (txt_factura.Text) & ",'" & ("GUIA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (mirecintoempresa) & "','" & (txt_nro_orden_de_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '" & (total_comision) & "', '" & (nro_801) & "', '" & (fecha_801) & "', '" & (nro_802) & "', '" & (fecha_802) & "', '" & (nro_hes) & "', '" & (fecha_hes) & "', '" & (codigo_doc_otro) & "', '" & (nro_otro) & "', '" & (fecha_otro) & "', '" & ("Operación constituye venta") & "', '" & ("Receptor (cliente)") & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Catch
            End Try

        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            If estado_factura_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If

            If txt_orden_de_compra.Text <> "SI" Then
                If txt_nro_orden_de_compra.Text = "" Then
                    txt_nro_orden_de_compra.Text = "0"
                End If
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into factura (caja, n_factura, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision,  orden_de_compra ,  fecha_orden_de_compra ,  nro_atencion ,  fecha_nro_atencion ,  hoja_entrada ,  fecha_hoja_entrada ,  otra_referencia ,  nro_otra_referencia ,  fecha_otra_referencia) values ('" & (nombre_pc) & "', " & (txt_factura.Text) & ",'" & ("FACTURA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (mirecintoempresa) & "','" & (txt_nro_orden_de_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '" & (valor_pie) & "', '" & (tipo_pie) & "', '" & (total_comision) & "', '" & (nro_801) & "', '" & (fecha_801) & "', '" & (nro_802) & "', '" & (fecha_802) & "', '" & (nro_hes) & "', '" & (fecha_hes) & "', '" & (codigo_doc_otro) & "', '" & (nro_otro) & "', '" & (fecha_otro) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            Try
                SC.Connection = conexion
                SC.CommandText = "insert into listado_documentos (codigo_documento, caja, nro_documento, documento, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, comision,  orden_de_compra ,  fecha_orden_de_compra ,  nro_atencion ,  fecha_nro_atencion ,  hoja_entrada ,  fecha_hoja_entrada ,  otra_referencia ,  nro_otra_referencia ,  fecha_otra_referencia) values ('33', '" & (nombre_pc) & "', " & (txt_factura.Text) & ",'" & ("FACTURA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (mirecintoempresa) & "','" & (txt_nro_orden_de_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '" & (total_comision) & "', '" & (nro_801) & "', '" & (fecha_801) & "', '" & (nro_802) & "', '" & (fecha_802) & "', '" & (nro_hes) & "', '" & (fecha_hes) & "', '" & (codigo_doc_otro) & "', '" & (nro_otro) & "', '" & (fecha_otro) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Catch
            End Try

            SC.Connection = conexion
            SC.CommandText = "insert into creditos (n_creditos, tipo, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza, pie, convenio, condicion_de_pago_pie) values (" & (txt_factura.Text) & ",'" & ("FACTURA") & "','" & ("FACTURA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & "," & (txt_total.Text) & ",'" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_factura.Text) & "','FACTURA', '" & (mirecintoempresa) & "', '" & (dtp_vencimiento.Text) & "', '0000-00-00', '1', '1', '0', '0' , '" & (valor_pie) & "', '" & (txt_codigo_convenio.Text) & "' , '" & (tipo_pie) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update clientes set saldo_cliente = saldo_cliente - " & (Int(txt_total.Text)) & " where rut_cliente = '" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If Combo_venta.Text = "FACTURA" Then
            If estado_factura_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into factura(caja, n_factura, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total,condiciones,estado,usuario_responsable,rut_retira, nombre_retira, recinto, hora, porcentaje_desc, orden, tipo_impresion, pie, condicion_de_pago_pie, comision,  orden_de_compra ,  fecha_orden_de_compra ,  nro_atencion ,  fecha_nro_atencion ,  hoja_entrada ,  fecha_hoja_entrada ,  otra_referencia ,  nro_otra_referencia ,  fecha_otra_referencia)values('" & (nombre_pc) & "', " & (txt_factura.Text) & ",'" & ("FACTURA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (mirecintoempresa) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "', '0','" & (tipo_impresion) & "', '" & (valor_pie) & "', '" & (tipo_pie) & "', '" & (total_comision) & "', '" & (nro_801) & "', '" & (fecha_801) & "', '" & (nro_802) & "', '" & (fecha_802) & "', '" & (nro_hes) & "', '" & (fecha_hes) & "', '" & (codigo_doc_otro) & "', '" & (nro_otro) & "', '" & (fecha_otro) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            'Debe Generar el XML y Llenarla en la base de datos, Tabla xmldte



            Try
                SC.Connection = conexion
                SC.CommandText = "insert into listado_documentos (codigo_documento, caja, nro_documento, documento, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, comision,  orden_de_compra ,  fecha_orden_de_compra ,  nro_atencion ,  fecha_nro_atencion ,  hoja_entrada ,  fecha_hoja_entrada ,  otra_referencia ,  nro_otra_referencia ,  fecha_otra_referencia) values ('33', '" & (nombre_pc) & "', " & (txt_factura.Text) & ",'" & ("FACTURA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (mirecintoempresa) & "','" & (txt_nro_orden_de_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '" & (total_comision) & "', '" & (nro_801) & "', '" & (fecha_801) & "', '" & (nro_802) & "', '" & (fecha_802) & "', '" & (nro_hes) & "', '" & (fecha_hes) & "', '" & (codigo_doc_otro) & "', '" & (nro_otro) & "', '" & (fecha_otro) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Catch
            End Try

        End If

        If Combo_venta.Text = "BOLETA" Then
            If estado_boleta_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If

            If txt_cod_cliente.Text = "" Or txt_rut_cliente.Text = "" Or txt_nombre_cliente.Text = "" Then
                txt_rut_cliente.Text = "11111111-1"
                txt_cod_cliente.Text = "0"
                txt_nombre_cliente.Text = "SIN NOMBRE"
                txt_direccion_cliente.Text = "SIN DIRECCION"
                txt_giro_cliente.Text = "SIN GIRO"
                txt_comuna_cliente.Text = "SIN COMUNA"
                txt_telefono.Text = "000000"
                txt_correo_cliente.Text = "SIN CORREO"
                txt_ciudad_cliente.Text = "SIN CIUDAD"
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into BOLETA (caja, n_boleta, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones,estado, usuario_responsable, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_factura.Text) & " , 'BOLETA','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '" & (valor_pie) & "', '" & (tipo_pie) & "', '" & (total_comision) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)


            Try
                SC.Connection = conexion
                SC.CommandText = "insert into listado_documentos (codigo_documento, caja, nro_documento, documento, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, comision,  orden_de_compra ,  fecha_orden_de_compra ,  nro_atencion ,  fecha_nro_atencion ,  hoja_entrada ,  fecha_hoja_entrada ,  otra_referencia ,  nro_otra_referencia ,  fecha_otra_referencia) values ('39', '" & (nombre_pc) & "', " & (txt_factura.Text) & ",'" & ("BOLETA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (mirecintoempresa) & "','" & (txt_nro_orden_de_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '" & (total_comision) & "', '" & (nro_801) & "', '" & (fecha_801) & "', '" & (nro_802) & "', '" & (fecha_802) & "', '" & (nro_hes) & "', '" & (fecha_hes) & "', '" & (codigo_doc_otro) & "', '" & (nro_otro) & "', '" & (fecha_otro) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Catch
            End Try
        End If

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
            If estado_boleta_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into boleta (caja, n_boleta, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_factura.Text) & " , 'BOLETA DE CREDITO', '" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '" & (valor_pie) & "', '" & (tipo_pie) & "', '" & (total_comision) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into creditos (n_creditos, tipo, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza, pie, convenio, condicion_de_pago_pie) values (" & (txt_factura.Text) & " , '" & ("BOLETA") & "','" & ("BOLETA") & "', '" & (txt_rut_cliente.Text) & "', '" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ", " & (txt_total.Text) & ",'" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "'," & (txt_factura.Text) & " ,'BOLETA', '" & (mirecintoempresa) & "', '" & (dtp_vencimiento.Text) & "', '0000-00-00', '1', '1', '0', '0', '" & (valor_pie) & "', '" & (txt_codigo_convenio.Text) & "', '" & (tipo_pie) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update clientes set saldo_cliente = saldo_cliente - " & (Int(txt_total.Text)) & " where rut_cliente = '" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            Try
                SC.Connection = conexion
                SC.CommandText = "insert into listado_documentos (codigo_documento, caja, nro_documento, documento, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, comision,  orden_de_compra ,  fecha_orden_de_compra ,  nro_atencion ,  fecha_nro_atencion ,  hoja_entrada ,  fecha_hoja_entrada ,  otra_referencia ,  nro_otra_referencia ,  fecha_otra_referencia) values ('39', '" & (nombre_pc) & "', " & (txt_factura.Text) & ",'" & ("BOLETA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (mirecintoempresa) & "','" & (txt_nro_orden_de_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '" & (total_comision) & "', '" & (nro_801) & "', '" & (fecha_801) & "', '" & (nro_802) & "', '" & (fecha_802) & "', '" & (nro_hes) & "', '" & (fecha_hes) & "', '" & (codigo_doc_otro) & "', '" & (nro_otro) & "', '" & (fecha_otro) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Catch
            End Try

        End If
    End Sub

    Sub grabar_detalle_temporal()
        Dim VarCodProducto As Integer
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
        Dim VarUnidadMedida As String

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
            VarUnidadMedida = grilla_detalle_venta.Rows(i).Cells(11).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into factura_temporal (n_factura,documento, codigo_producto, nombre_producto, numero_tecnico, cantidad, precio, porcentaje_desc, subtotal_detalle, total_detalle, nombre_vendedor, unidad_medida) values('" & (txt_factura.Text) & "', '" & (Combo_venta.Text) & "','" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarCantidad) & "," & (VarValorUnitario) & "," & (VarPorcentaje) & "," & (VarSubtotal) & "," & (VarTotal) & ",'" & (minombre) & "','" & (VarUnidadMedida) & "')"
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
        Dim VarUnidadMedida As String

        If grilla_detalle_venta.Rows.Count = 0 Then
            Exit Sub
        End If

        SC.Connection = conexion
        SC.CommandText = "delete from documento_temporal where usuario = '" & (miusuario) & "' and nro_venta = '" & (nro_venta) & "'"
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
            VarUnidadMedida = grilla_detalle_venta.Rows(i).Cells(11).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into documento_temporal (cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, usuario, documento, condicion_venta, porcentaje_desc_total, rut_cliente, nombre_cliente, direccion_cliente, cod_cliente, descuento_1,descuento_2, giro_cliente, comuna_cliente, telefono_cliente, estado_cuenta, folio_cliente, email_cliente, ciudad_cliente, rut_cliente_retira, nombre_cliente_retira, orden_de_compra, tipo_documento, unidad_medida, nro_venta) values( '" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "','" & (VarValorUnitario) & "','" & (VarCantidad) & "','" & (VarPorcentaje) & "','" & (VarDescuento) & "','" & (VarNeto) & "', '" & (VarIva) & "','" & (VarSubtotal) & "','" & (VarTotal) & "','" & (miusuario) & "','" & (Combo_venta.Text) & "','" & (combo_condiciones.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (txt_rut_cliente.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_direccion_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (txt_descuento_cliente.Text) & "','" & (txt_descuento_cliente_2.Text) & "','" & (txt_giro_cliente.Text) & "','" & (txt_comuna_cliente.Text) & "','" & (txt_telefono.Text) & "','" & (txt_cuenta_cliente.Text) & "','" & (txt_folio.Text) & "','" & (txt_correo_cliente.Text) & "','" & (txt_ciudad_cliente.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (txt_orden_de_compra.Text) & "','" & (txt_tipo_documento.Text) & "','" & (VarUnidadMedida) & "','" & (nro_venta) & "')"
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
            SC.CommandText = "select * from documento_temporal where usuario='" & (miusuario) & "' and nro_venta='" & (nro_venta) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"),
                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"),
                    DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"),
                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"),
                    DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"),
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"),
                    DS.Tables(DT.TableName).Rows(i).Item("unidad_medida"))
                Next

                Combo_venta.Text = DS.Tables(DT.TableName).Rows(0).Item("documento")

                combo_condiciones.Text = DS.Tables(DT.TableName).Rows(0).Item("condicion_venta")

                txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc_total")
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_rut_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente_retira")
                txt_nombre_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente_retira")
                txt_rut_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente_retira")
                txt_nombre_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente_retira")
                txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_documento")
                txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                mostrar_datos_clientes_por_codigo()


            End If

            SC.Connection = conexion
            SC.CommandText = "delete from documento_temporal where usuario='" & (miusuario) & "' and nro_venta='" & (nro_venta) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            calcular_totales()

        Catch err As InvalidCastException
            SC.Connection = conexion
            SC.CommandText = "delete from documento_temporal where usuario='" & (miusuario) & "' and nro_venta='" & (nro_venta) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            calcular_totales()
            txt_codigo.Focus()

        Catch err As ArgumentException
            SC.Connection = conexion
            SC.CommandText = "delete from documento_temporal where usuario='" & (miusuario) & "' and nro_venta='" & (nro_venta) & "'"
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


        If Combo_venta.Text = "GUIA" Then
            If combo_condiciones.Text = "CREDITO" Then
                If Int(txt_descuento_cliente.Text) = 0 Then
                    If Int(txt_porcentaje_desc.Text) <> 0 Then
                        mensaje_autorizacion = "SI"
                    End If
                End If
            End If
        End If



        If Combo_venta.Text = "GUIA" And combo_condiciones.Text = "CREDITO" Then
            If Int(txt_porcentaje_desc.Text) > Int(txt_descuento_cliente.Text) Then
                mensaje_autorizacion = "SI"
            End If
        End If

        If Combo_venta.Text = "FACTURA" And combo_condiciones.Text = "CREDITO" Then
            If Int(txt_porcentaje_desc.Text) > Int(txt_descuento_cliente_2.Text) Then
                mensaje_autorizacion = "SI"
            End If
        End If


        If txt_tipo_cliente.Text = "EMPRESA" And Combo_venta.Text = "BOLETA" Then
            mensaje_autorizacion = "SI"
        End If

        If mirutempresa = "87686300-6" Then
            If Combo_venta.Text = "BOLETA" Then
                If Int(txt_porcentaje_desc.Text) >= Int("12") Then
                    mensaje_autorizacion = "SI"
                End If
            End If
        End If

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
                mostrar_deuda_clientes()
                Dim deuda_con_venta As String = "0"
                deuda_con_venta = Val(deuda) + Val(txt_total.Text)

                If Int(deuda_con_venta) > Int(txt_cupo.Text) Then
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

            If txt_tipo_cliente.Text = "EMPRESA" And Combo_venta.Text = "BOLETA" Then
                Form_autorizacion.lbl_autorizacion.Text = "● VENTA CON BOLETA A EMPRESA"
                Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
            End If

            If mirutempresa = "87686300-6" Then
                If Combo_venta.Text = "BOLETA" Then
                    If Int(txt_porcentaje_desc.Text) >= Int("12") Then
                        Form_autorizacion.lbl_autorizacion.Text = "● EL DESC. EXCEDE EL MAXIMO EN BOLETA"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                    End If
                End If
            End If

            If Combo_venta.Text = "GUIA" Then
                If combo_condiciones.Text = "CREDITO" Then
                    If Int(txt_descuento_cliente.Text) = 0 Then
                        If Int(txt_porcentaje_desc.Text) <> 0 Then

                            If Form_autorizacion.lbl_autorizacion.Text = "" Then
                                Form_autorizacion.lbl_autorizacion.Text = "● EL DESCUENTO FINAL EXCEDE EL MAXIMO"
                                Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                            Else
                                Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● EL DESCUENTO FINAL EXCEDE EL MAXIMO"
                                Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleRight
                            End If

                        End If
                    End If
                End If
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

                mostrar_deuda_clientes()
                Dim deuda_con_venta As String = "0"
                deuda_con_venta = Val(deuda) + Val(txt_total.Text)

                If Int(deuda_con_venta) > Int(txt_cupo.Text) Then
                    If Form_autorizacion.lbl_autorizacion.Text = "" Then
                        Form_autorizacion.lbl_autorizacion.Text = "● EL TOTAL ES MAYOR AL CUPO DISPONIBLE"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                    Else
                        Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● EL TOTAL ES MAYOR AL CUPO DISPONIBLE"
                        Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleRight
                    End If
                End If
            End If

            If mirutempresa = "87686300-6" Then

                If Combo_venta.Text = "GUIA" And combo_condiciones.Text = "CREDITO" Then
                    If Int(txt_porcentaje_desc.Text) > Int(txt_descuento_cliente.Text) Then
                        If Form_autorizacion.lbl_autorizacion.Text = "" Then
                            Form_autorizacion.lbl_autorizacion.Text = "● EL DESCUENTO FINAL EXCEDE EL MAXIMO"
                            Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                        Else
                            Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● EL DESCUENTO FINAL EXCEDE EL MAXIMO"
                            Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleLeft
                        End If
                    End If
                End If

                If Combo_venta.Text = "FACTURA" And combo_condiciones.Text = "CREDITO" Then
                    If Int(txt_porcentaje_desc.Text) > Int(txt_descuento_cliente.Text) Then
                        If Form_autorizacion.lbl_autorizacion.Text = "" Then
                            Form_autorizacion.lbl_autorizacion.Text = "● EL DESCUENTO FINAL EXCEDE EL MAXIMO"
                            Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleCenter
                        Else
                            Form_autorizacion.lbl_autorizacion.Text = Form_autorizacion.lbl_autorizacion.Text & vbCrLf & "● EL DESCUENTO FINAL EXCEDE EL MAXIMO"
                            Form_autorizacion.lbl_autorizacion.TextAlign = ContentAlignment.MiddleLeft
                        End If
                    End If
                End If

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

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            combo_condiciones.Text = "CREDITO"
        End If

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
            combo_condiciones.Text = "CREDITO"
        End If

        If Combo_venta.Text = "GUIA" And combo_condiciones.Text <> "TRASLADO" Then
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

        If txt_orden_de_compra.Text = "SI" And combo_condiciones.Text = "CREDITO" Then
            If txt_nro_orden_de_compra.Text = "" Then
                MsgBox("CAMPO ORDEN DE COMPRA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
                txt_nro_orden_de_compra.Focus()
                Exit Sub
            End If
        End If

        If mirutempresa = "87686300-6" Then

            If combo_condiciones.Text = "PENDIENTE" Then
                If txt_rut_cliente.Text = "" Then
                    MsgBox("CAMPO CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_rut_cliente.Focus()
                    Exit Sub
                End If
            End If

            If combo_condiciones.Text = "PENDIENTE" Then
                If txt_nombre_cliente.Text = "" Then
                    MsgBox("CAMPO CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_rut_cliente.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Combo_venta.Text = "BOLETA" Then

            If txt_rut_cliente.Text <> "" Then
                If valida_rut(txt_rut_cliente.Text) = False Then
                    txt_rut_cliente.Focus()
                    txt_rut_cliente.SelectAll()
                    Exit Sub
                End If
            End If

            If grilla_detalle_venta.Rows.Count > limite_boletas Then
                MsgBox("NO PUEDE AGREGAR MAS DE PRODUCTOS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
                txt_codigo.Focus()
                Exit Sub
            End If

            If combo_condiciones.Text = "PAGO COMBINADO" Then
                If Form_pago_combinado.Visible = False Then
                    Form_pago_combinado.Show()
                    Me.Enabled = False
                    Exit Sub
                End If
            End If

            Dim valormensaje As Integer
            If tipo_impresion_sistema = "TICKET" Then
                valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UN TICKET DE VENTA POR " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            Else
                valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            End If

            If valormensaje = vbYes Then
                descuento()

                If VarAutorizacionVenta = "" Then
                    Exit Sub
                End If












                If mirutempresa = "87686300-6" Then
                    Dim VarCodigoProducto As String
                    Dim varnombre As String

                    For i = 0 To grilla_detalle_venta.Rows.Count - 1
                        VarCodigoProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                        varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString

                        If VarCodigoProducto = "048145" Then
                            If Int(txt_total.Text) < "5000" Then
                                MsgBox("EL PRODUCTO " & varnombre & " NO PUEDE SER VENDIDO POR MENOS DE $5.000 PESOS", 0 + 16, "ERROR")
                                txt_codigo.Focus()
                                Exit Sub
                            End If
                        End If
                    Next
                End If











                imprimir()
                VarAutorizacionVenta = ""
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
            If txt_nombre_cliente.Text = "" Then
                MsgBox("CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_rut_cliente.Focus()
                Exit Sub
            End If

            'If txt_cuenta_cliente.Text = "CERRADA" Then
            'MsgBox("CUENTA CERRADA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            'txt_porcentaje_desc.Focus()
            'Exit Sub
            'End If

            If combo_condiciones.Text = "CREDITO" Then
                If txt_cuenta_cliente.Text <> "ABIERTA" Then
                    MsgBox("EL CLIENTE NO TIENE CUENTA ABIERTA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_rut_cliente.Focus()
                    Exit Sub
                End If
            End If


            If txt_cuenta_cliente.Text = "BLOQUEADA" Then
                MsgBox("CUENTA BLOQUEADA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                txt_porcentaje_desc.Focus()
                Exit Sub
            End If

            If txt_cuenta_cliente.Text = "SIN CUENTA" Then
                MsgBox("EL CLIENTE SELECCIONADO NO TIENE CUENTA CON LA EMPRESA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                txt_porcentaje_desc.Focus()
                Exit Sub
            End If

            If txt_cuenta_cliente.Text = "-" Then
                MsgBox("EL CLIENTE SELECCIONADO NO TIENE CUENTA CON LA EMPRESA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                txt_porcentaje_desc.Focus()
                Exit Sub
            End If

            If grilla_detalle_venta.Rows.Count > limite_boletas Then
                MsgBox("NO PUEDE AGREGAR MAS DE PRODUCTOS, ELIMINE ALGUNOS", 0 + 16, "ATENCION")
                txt_codigo.Focus()
                Exit Sub
            End If

            If (txt_tipo_documento.Text & " DE CREDITO") <> Combo_venta.Text Then
                If txt_tipo_documento.Text <> "MIXTA" Then
                    MsgBox("CLIENTE RETIRA CON " & txt_tipo_documento.Text, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                    Exit Sub
                End If
            End If

            If combo_condiciones.Text = "PAGO COMBINADO" Then
                If Form_pago_combinado.Visible = False Then
                    Form_pago_combinado.Show()
                    Me.Enabled = False
                    Exit Sub
                End If
            End If

            If valida_rut(txt_rut_cliente.Text) = False Then
                txt_rut_cliente.Focus()
                txt_rut_cliente.SelectAll()
                Exit Sub
            End If

            Dim valormensaje As Integer
            If tipo_impresion_sistema = "TICKET" Then
                valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UN TICKET DE VENTA POR " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            Else
                valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            End If

            If valormensaje = vbYes Then

                descuento()

                If VarAutorizacionVenta = "" Then
                    Exit Sub
                End If




                If mirutempresa = "87686300-6" Then
                    Dim VarCodigoProducto As String
                    Dim varnombre As String

                    For i = 0 To grilla_detalle_venta.Rows.Count - 1
                        VarCodigoProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                        varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString

                        If VarCodigoProducto = "048145" Then
                            If Int(txt_total.Text) < "5000" Then
                                MsgBox("EL PRODUCTO " & varnombre & " NO PUEDE SER VENDIDO POR MENOS DE $5.000 PESOS", 0 + 16, "ERROR")
                                txt_codigo.Focus()
                                Exit Sub
                            End If
                        End If
                    Next
                End If


                imprimir()
                VarAutorizacionVenta = ""

                Exit Sub
            End If
        End If

        If Combo_venta.Text = "GUIA" Then
            If txt_nombre_cliente.Text = "" Then
                MsgBox("CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_rut_cliente.Focus()
                Exit Sub
            End If

            If txt_nombre_retira.Text = "" Then
                MsgBox("CAMPO CLIENTE QUE RETIRA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_rut_retira.Focus()
                Exit Sub
            End If

            'If txt_cuenta_cliente.Text = "CERRADA" Then
            'MsgBox("CUENTA CERRADA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            'txt_porcentaje_desc.Focus()
            'Exit Sub
            'End If



            If combo_condiciones.Text = "CREDITO" Then
                If txt_cuenta_cliente.Text <> "ABIERTA" Then
                    MsgBox("EL CLIENTE NO TIENE CUENTA ABIERTA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_rut_cliente.Focus()
                    Exit Sub
                End If
            End If





            If txt_cuenta_cliente.Text = "BLOQUEADA" Then
                MsgBox("CUENTA BLOQUEADA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                txt_porcentaje_desc.Focus()
                Exit Sub
            End If

            If txt_cuenta_cliente.Text = "SIN CUENTA" Then
                MsgBox("EL CLIENTE SELECCIONADO NO TIENE CUENTA CON LA EMPRESA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                txt_porcentaje_desc.Focus()
                Exit Sub
            End If

            If txt_cuenta_cliente.Text = "-" Then
                MsgBox("EL CLIENTE SELECCIONADO NO TIENE CUENTA CON LA EMPRESA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                txt_porcentaje_desc.Focus()
                Exit Sub
            End If

            If grilla_detalle_venta.Rows.Count > limite_guias Then
                MsgBox("NO PUEDE AGREGAR MAS DE PRODUCTOS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
                txt_codigo.Focus()
                Exit Sub
            End If

            If combo_condiciones.Text = "PAGO COMBINADO" Then
                If Form_pago_combinado.Visible = False Then
                    Form_pago_combinado.Show()
                    Me.Enabled = False
                    Exit Sub
                End If
            End If

            If txt_tipo_documento.Text <> Combo_venta.Text Then
                If txt_tipo_documento.Text <> "MIXTA" Then
                    MsgBox("CLIENTE RETIRA CON " & txt_tipo_documento.Text, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                    Exit Sub
                End If
            End If

            If valida_rut(txt_rut_cliente.Text) = False Then
                txt_rut_cliente.Focus()
                txt_rut_cliente.SelectAll()
                Exit Sub
            End If






            If mirutempresa = "87686300-6" Then
                If combo_condiciones.Text = "CREDITO" Then
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    SC.Connection = conexion
                    SC.CommandText = "select * from clientes_que_retiran_por_empresas where rut_empresa='" & (txt_rut_cliente.Text) & "' and rut_cliente='" & (txt_rut_retira.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    DS.Tables.Add(DT)
                    If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    Else
                        MsgBox("LA PERSONA NO ESTÁ AUTORIZADA PARA RETIRAR POR ESTA EMPRESA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_rut_cliente.Focus()
                        Exit Sub
                    End If
                End If
            End If







            Dim valormensaje As Integer

            If tipo_impresion_sistema = "TICKET" Then
                valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UN TICKET DE VENTA POR " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            Else
                valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            End If

            If valormensaje = vbYes Then







                If mirutempresa = "87686300-6" Then
                    Dim VarCodigoProducto As String
                    Dim varnombre As String

                    For i = 0 To grilla_detalle_venta.Rows.Count - 1
                        VarCodigoProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                        varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString

                        If VarCodigoProducto = "048145" Then
                            If Int(txt_total.Text) < "5000" Then
                                MsgBox("EL PRODUCTO " & varnombre & " NO PUEDE SER VENDIDO POR MENOS DE $5.000 PESOS", 0 + 16, "ERROR")
                                txt_codigo.Focus()
                                Exit Sub
                            End If
                        End If
                    Next
                End If













                tipo_despacho = ""
                Form_tipo_despacho.Show()
                Me.Enabled = False

                If tipo_despacho = "" Then
                    Exit Sub
                End If

                descuento()

                If VarAutorizacionVenta = "" Then
                    Exit Sub
                End If

                imprimir()
                VarAutorizacionVenta = ""
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "FACTURA" Then
            If txt_nombre_cliente.Text = "" Then
                MsgBox("CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_rut_cliente.Focus()
                Exit Sub
            End If

            If txt_nombre_retira.Text = "" Then
                MsgBox("CAMPO CLIENTE QUE RETIRA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_rut_retira.Focus()
                Exit Sub
            End If

            If grilla_detalle_venta.Rows.Count > limite_facturas Then
                MsgBox("NO PUEDE AGREGAR MAS DE PRODUCTOS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
                txt_codigo.Focus()
                Exit Sub
            End If

            If combo_condiciones.Text = "PAGO COMBINADO" Then
                If Form_pago_combinado.Visible = False Then
                    Form_pago_combinado.Show()
                    Me.Enabled = False
                    Exit Sub
                End If
            End If

            If valida_rut(txt_rut_cliente.Text) = False Then
                txt_rut_cliente.Focus()
                txt_rut_cliente.SelectAll()
                Exit Sub
            End If

            Dim valormensaje As Integer
            If tipo_impresion_sistema = "TICKET" Then
                valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UN TICKET DE VENTA POR " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            Else
                valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            End If

            If valormensaje = vbYes Then
                descuento()

                If VarAutorizacionVenta = "" Then
                    Exit Sub
                End If








                If mirutempresa = "87686300-6" Then
                    Dim VarCodigoProducto As String
                    Dim varnombre As String

                    For i = 0 To grilla_detalle_venta.Rows.Count - 1
                        VarCodigoProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                        varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString

                        If VarCodigoProducto = "048145" Then
                            If Int(txt_total.Text) < "5000" Then
                                MsgBox("EL PRODUCTO " & varnombre & " NO PUEDE SER VENDIDO POR MENOS DE $5.000 PESOS", 0 + 16, "ERROR")
                                txt_codigo.Focus()
                                Exit Sub
                            End If
                        End If
                    Next
                End If

                imprimir()
                VarAutorizacionVenta = ""
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            If txt_nombre_cliente.Text = "" Then
                MsgBox("CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_rut_cliente.Focus()
                Exit Sub
            End If

            If txt_nombre_retira.Text = "" Then
                MsgBox("CAMPO CLIENTE QUE RETIRA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_rut_retira.Focus()
                Exit Sub
            End If

            'If txt_cuenta_cliente.Text = "CERRADA" Then
            '    MsgBox("CUENTA CERRADA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            '    txt_porcentaje_desc.Focus()
            '    Exit Sub
            'End If

            If combo_condiciones.Text = "CREDITO" Then
                If txt_cuenta_cliente.Text <> "ABIERTA" Then
                    MsgBox("EL CLIENTE NO TIENE CUENTA ABIERTA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_rut_cliente.Focus()
                    Exit Sub
                End If
            End If

            'If txt_cuenta_cliente.Text = "BLOQUEADA" Then
            '    MsgBox("CUENTA BLOQUEADA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            '    txt_porcentaje_desc.Focus()
            '    Exit Sub
            'End If

            If txt_cuenta_cliente.Text = "SIN CUENTA" Then
                MsgBox("EL CLIENTE SELECCIONADO NO TIENE CUENTA CON LA EMPRESA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                txt_porcentaje_desc.Focus()
                Exit Sub
            End If

            If txt_cuenta_cliente.Text = "-" Then
                MsgBox("EL CLIENTE SELECCIONADO NO TIENE CUENTA CON LA EMPRESA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                txt_porcentaje_desc.Focus()
                Exit Sub
            End If

            If combo_condiciones.Text = "PAGO COMBINADO" Then
                If Form_pago_combinado.Visible = False Then
                    Form_pago_combinado.Show()
                    Me.Enabled = False
                    Exit Sub
                End If
            End If

            If grilla_detalle_venta.Rows.Count > limite_facturas Then
                MsgBox("NO PUEDE AGREGAR MAS DE PRODUCTOS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
                txt_codigo.Focus()
                Exit Sub
            End If

            If mirutempresa = "87686300-6" Then
                If combo_condiciones.Text = "CREDITO" Then
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    SC.Connection = conexion
                    SC.CommandText = "select * from clientes_que_retiran_por_empresas where rut_empresa='" & (txt_rut_cliente.Text) & "' and rut_cliente='" & (txt_rut_retira.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    DS.Tables.Add(DT)
                    If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    Else
                        MsgBox("LA PERSONA NO ESTÁ AUTORIZADA PARA RETIRAR POR ESTA EMPRESA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_rut_cliente.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If valida_rut(txt_rut_cliente.Text) = False Then
                txt_rut_cliente.Focus()
                txt_rut_cliente.SelectAll()
                Exit Sub
            End If

            Dim tipo_combo_venta As String
            tipo_combo_venta = Combo_venta.Text
            tipo_combo_venta = tipo_combo_venta.Substring(0, 7)

            If txt_tipo_documento.Text <> tipo_combo_venta Then
                If txt_tipo_documento.Text <> "MIXTA" Then
                    MsgBox("CLIENTE RETIRA CON " & txt_tipo_documento.Text, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                    Exit Sub
                End If
            End If

            Dim valormensaje As Integer
            If tipo_impresion_sistema = "TICKET" Then
                valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UN TICKET DE VENTA POR " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            Else
                valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            End If

            If valormensaje = vbYes Then
                descuento()

                If VarAutorizacionVenta = "" Then
                    Exit Sub
                End If






                If mirutempresa = "87686300-6" Then
                    Dim VarCodigoProducto As String
                    Dim varnombre As String

                    For i = 0 To grilla_detalle_venta.Rows.Count - 1
                        VarCodigoProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                        varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString

                        If VarCodigoProducto = "048145" Then
                            If Int(txt_total.Text) < "5000" Then
                                MsgBox("EL PRODUCTO " & varnombre & " NO PUEDE SER VENDIDO POR MENOS DE $5.000 PESOS", 0 + 16, "ERROR")
                                txt_codigo.Focus()
                                Exit Sub
                            End If
                        End If
                    Next
                End If

                imprimir()
                VarAutorizacionVenta = ""
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "COTIZACION" Then
            If grilla_detalle_venta.Rows.Count > limite_cotizacion Then
                MsgBox("NO PUEDE AGREGAR MAS DE PRODUCTOS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
                txt_codigo.Focus()
                Exit Sub
            End If

            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")

            If valormensaje = vbYes Then
                imprimir()
                VarAutorizacionVenta = ""
                Exit Sub
            End If
        End If

        If Combo_venta.Text = "ASISTENCIA" Then
            If grilla_detalle_venta.Rows.Count > limite_cotizacion Then
                MsgBox("NO PUEDE AGREGAR MAS DE PRODUCTOS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
                txt_codigo.Focus()
                Exit Sub
            End If

            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA " & Combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")

            If valormensaje = vbYes Then
                imprimir()
                VarAutorizacionVenta = ""
                Exit Sub
            End If
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

    'muestra lso datos del cliente seleccionado.
    Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'llenar_combo_retira()
        limpiar_datos_clientes_retira()
    End Sub

    'Private Sub combo_retira_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    ' combo_retira.BackColor = Color.LightBlue
    'End Sub

    Private Sub combo_retira_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
            limpiar_datos_productos()
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            txt_rut_cliente.Focus()
        ElseIf (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_retira()
            txt_codigo.Focus()
        End If
    End Sub

    'Private Sub combo_retira_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    ' combo_retira.BackColor = Color.White
    'End Sub

    'le damos el valor del ocmbo al texbox.
    'mostramos los datos del lciente que retira seleccionado.
    'habilitamos los texbox y el combo.
    Private Sub combo_retira_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_datos_retira()
    End Sub

    'Private Sub txt_orden_de_compra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_orden_de_compra.GotFocus
    ' 'txt_orden_de_compra.BackColor = Color.LightBlue
    'End Sub

    ''valida solo el ingreso de numeros.
    'Private Sub txt_afecta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_afecta.KeyPress
    ' If Char.IsDigit(e.KeyChar) Then
    ' e.Handled = False
    ' ElseIf Char.IsControl(e.KeyChar) Then
    ' e.Handled = False
    ' Else
    ' e.Handled = True
    ' End If
    'End Sub

    'Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles
    ' Try
    ' Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
    ' Catch
    ' End Try
    'End Sub

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


    Private Sub btn_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn_agregar.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_productos()
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            txt_cantidad_agregar.Focus()
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

    Private Sub btn_agregar_retira_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_retira.Click
        Me.Enabled = False
        Form_registro_cliente_retira_ventas.Show()
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
        txt_nombre_cliente.Text = ""

        limpiar_datos_clientes()

        If (e.KeyChar = Convert.ToChar(Keys.F4)) Then
            btn_buscar_clientes.PerformClick()
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Back)) Then
            limpiar_datos_clientes()
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





        'If combo_retira.Enabled = True Then
        ' If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
        ' combo_retira.Focus()
        ' End If
        'End If

        'If combo_retira.Enabled = False Then
        ' If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
        ' txt_rut.Focus()
        ' End If
        'End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_clientes()
            ' txt_porcentaje_desc.Text = "0"


            guion_rut_cliente()

            mostrar_datos_clientes()

            limpiar_datos_clientes_retira()
            'guardar_descuento()
            'grilla_detalle_venta.Rows.Clear()
            'cargar_descuento()
            'calcular_totales()

            If Combo_venta.Text = "BOLETA" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_codigo.Focus()
                End If
            End If

            If Combo_venta.Text = "BOLETA DE CREDITO" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_codigo.Focus()
                End If
            End If

            If Combo_venta.Text = "COTIZACION" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_codigo.Focus()
                End If
            End If

            If Combo_venta.Text = "FACTURA" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_rut_retira.Focus()
                End If
            End If

            If Combo_venta.Text = "FACTURA DE CREDITO" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_rut_retira.Focus()
                End If
            End If

            If Combo_venta.Text = "GUIA" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_rut_retira.Focus()
                End If
            End If
        End If

        'If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
        ' e.Handled = False
        'Else
        ' e.Handled = True
        'End If

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

    Sub guion_rut_cliente_retira()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_retira.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_retira.Text = rut_cliente
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

        If e.KeyCode = Keys.F5 Then
            txt_rut_retira.Focus()
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

    Private Sub btn_quitar_elemento_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.TabIndexChanged
        Combo_venta.Focus()
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
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

    'Private Sub GroupBox2_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.TabIndexChanged
    ' Me.TabIndex = 50
    'End Sub

    'Private Sub Radio_codigo_barra_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    ' Radio_codigo_barra.TabStop = False
    'End Sub

    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_nueva.BackColor = Color.Transparent
    End Sub

    Private Sub txt_porcentaje_desc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.Click
        txt_porcentaje_desc.SelectionStart = 0
        txt_porcentaje_desc.SelectionLength = Len(txt_porcentaje_desc.Text)
    End Sub

    Private Sub txt_descto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.GotFocus
        txt_porcentaje_desc.BackColor = Color.LightSkyBlue
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

        'If Combo_venta.Text = "GUIA" Then
        '    If combo_condiciones.Text = "CREDITO" Then
        '        txt_porcentaje_desc.Enabled = False
        '        txt_porcentaje_desc.Text = txt_descuento_cliente.Text
        '    Else
        '        txt_porcentaje_desc.Enabled = True
        '        txt_porcentaje_desc.Text = valor_descuento_ventas
        '    End If
        'End If

        If combo_condiciones.Text = "OTRO MEDIO DE PAGO" Then
            Form_otro_medio_de_pago.Show()
            Me.Enabled = False
        End If
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

    Private Sub btn_agregar_retira_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_retira.GotFocus
        btn_agregar_retira.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_productos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_buscar_productos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imagen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_imagen.BackColor = Color.Yellow
    End Sub

    Private Sub btn_buscar_productos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_buscar_productos.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imagen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_imagen.BackColor = Color.Transparent

    End Sub

    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    Dim Total_letra As Integer
    '    Dim Comprobar_letra As Integer

    '    Total_letra = (txt_total.Text) / (txt_cargar.Text)
    '    Comprobar_letra = (Total_letra) * (txt_cargar.Text)
    '    Comprobar_letra = (txt_total.Text) - (Comprobar_letra)
    '    Total_letra = (Total_letra) + (Comprobar_letra)
    '    Round(Total_letra)

    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nro_doc", GetType(String)))
    '    dt.Columns.Add(New DataColumn("documento_referencia", GetType(String)))
    '    dt.Columns.Add(New DataColumn("monto_total", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("nro_letra", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("ciudad_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("monto_letra", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("desglose", GetType(String)))
    '    dt.Columns.Add(New DataColumn("girador", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

    '    dr = dt.NewRow()

    '    'Try
    '    '    dr("Imagen") = Imagen_reporte
    '    'Catch
    '    'End Try

    '    dr("nro_doc") = txt_nro_letra.Text
    '    dr("nro_letra") = cantidad_letras & " DE " & txt_cargar.Text
    '    dr("documento_referencia") = Combo_venta.Text & " NRO. " & txt_factura.Text
    '    dr("fecha") = dtp_letra.Text
    '    dr("rut_cliente") = txt_rut_cliente.Text
    '    dr("nombre_cliente") = txt_nombre_cliente.Text
    '    dr("telefono_cliente") = txt_telefono.Text
    '    dr("ciudad_cliente") = txt_ciudad_cliente.Text
    '    dr("direccion_cliente") = txt_direccion_cliente.Text

    '    dr("monto_letra") = Total_letra

    '    dr("monto_total") = txt_total.Text
    '    dr("desglose") = desglose_valor
    '    dr("girador") = minombreempresa
    '    dr("nombre_empresa") = minombreempresa
    '    dr("giro_empresa") = migiroempresa
    '    dr("direccion_empresa") = midireccionempresa
    '    dr("comuna_empresa") = micomunaempresa
    '    dr("telefono_empresa") = mitelefonoempresa
    '    dr("correo_empresa") = micorreoempresa
    '    dr("rut_empresa") = mirutempresa
    '    dt.Rows.Add(dr)

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "Letra"

    '    Dim iDS As New dsletra

    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function

    Private Function ReturnDataSetCotizacion() As DataSet
        'Dim dt As New DataTable
        'Dim dr As DataRow
        'Dim ds As New DataSet



        'dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))

        'dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

        'dt.Columns.Add(New DataColumn("nro_cotizacion", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha_cotizacion", GetType(String)))
        'dt.Columns.Add(New DataColumn("nombre_vendedor", GetType(String)))
        'dt.Columns.Add(New DataColumn("telefono_vendedor", GetType(String)))
        'dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        'dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        'dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("total", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("numero_tecnico", GetType(String)))
        'dt.Columns.Add(New DataColumn("subtotal_final", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("descuento_final", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("total_final", GetType(Integer)))

        'dt.Columns.Add(New DataColumn("forma_de_pago", GetType(String)))
        'dt.Columns.Add(New DataColumn("precio", GetType(Integer)))

        'dt.Columns.Add(New DataColumn("tipo_doc", GetType(String)))
        'dt.Columns.Add(New DataColumn("valido", GetType(String)))
        'dt.Columns.Add(New DataColumn("precio_detalle", GetType(String)))


        'Dim tipo_doc As String
        'Dim valido As String

        'If Combo_venta.Text = "COTIZACION" Then
        '    tipo_doc = "COTIZACION"
        '    valido = "COTIZACION VALIDA POR 2 DIAS"
        'Else
        '    tipo_doc = "DETALLE DE " & Combo_venta.Text
        '    valido = " "
        'End If











        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As String
        'Dim VarPorcentaje As Integer
        'Dim VarDescuento As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        'Dim VarTotal As Integer
        ''Dim VarProveedor As String
        ''Dim VarCosto As Integer
        ''Dim VarSaldo As Integer

        'Dim descuento_detalle As String
        'Dim precio_detalle As String

        'For i = 0 To grilla_detalle_venta.Rows.Count - 1

        '    VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
        '    varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
        '    vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
        '    VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
        '    VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
        '    VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
        '    VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
        '    VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
        '    VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '    VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
        '    VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

        '    precio_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
        '    descuento_detalle = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
        '    descuento_detalle = Val(descuento_detalle) / VarCantidad

        '    precio_detalle = Val(precio_detalle - descuento_detalle)

        '    If descuento_detalle = "" Or descuento_detalle = "0" Then
        '        descuento_detalle = "0"
        '    Else
        '        descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
        '    End If

        '    If precio_detalle = "" Or precio_detalle = "0" Then
        '        precio_detalle = "0"
        '    Else
        '        precio_detalle = Format(Int(precio_detalle), "###,###,###")
        '    End If

        '    dr = dt.NewRow()

        '    'Try
        '    '    dr("Imagen") = Imagen_reporte
        '    'Catch
        '    'End Try

        '    dr("nombre_empresa") = minombreempresa
        '    dr("giro_empresa") = migiroempresa
        '    dr("direccion_empresa") = midireccionempresa
        '    dr("comuna_empresa") = micomunaempresa
        '    dr("telefono_empresa") = mitelefonoempresa
        '    dr("correo_empresa") = micorreoempresa
        '    dr("rut_empresa") = mirutempresa
        '    dr("nro_cotizacion") = txt_factura.Text
        '    dr("fecha_cotizacion") = Form_menu_principal.dtp_fecha.Text
        '    dr("nombre_vendedor") = txt_nombre_usuario.Text
        '    dr("telefono_vendedor") = mitelefono
        '    dr("codigo") = VarCodProducto
        '    dr("descripcion") = varnombre
        '    dr("cantidad") = " X " & VarCantidad & " ="
        '    dr("total") = VarTotal
        '    dr("numero_tecnico") = vartecnico
        '    dr("subtotal_final") = txt_sub_total.Text
        '    dr("descuento_final") = txt_desc.Text
        '    dr("total_final") = txt_total.Text
        '    dr("forma_de_pago") = combo_condiciones.Text
        '    dr("precio") = VarValorUnitario
        '    dr("tipo_doc") = tipo_doc
        '    dr("valido") = valido

        '    'dr("precio_detalle") = Val(precio_detalle - descuento_detalle)
        '    dr("precio_detalle") = precio_detalle

        '    dt.Rows.Add(dr)
        'Next








        'ds.Tables.Add(dt)
        'ds.Tables(0).TableName = "CotizacionTicket"

        'Dim iDS As New dsCotizacionTicket
        'iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        'Return iDS
        Return Nothing
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

    Private Sub Pd_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
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
        Dim cantidad_detalle As String
        Dim valorUnitario_detalle As String
        Dim subtotal_detalle As String
        Dim total_detalle As String

        Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim valor_pie As String
        Dim tipo_pie As String

        valor_pie = ""
        tipo_pie = ""

        If Combo_venta.Text = "COTIZACION" Then
            'Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
            'Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
            'Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
            'Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)
            'Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far
            Dim Font1 As New Font("arial", 7, FontStyle.Regular)
            Dim Font2 As New Font("arial", 14, FontStyle.Regular)
            Dim Font3 As New Font("arial", 8, FontStyle.Regular)
            Dim Font4 As New Font("arial", 8, FontStyle.Bold)

            Try
                Dim p As New PointF(0, 0)
                e.Graphics.DrawImage(Bytes_Imagen(Imagen_ticket), p)
            Catch
            End Try

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            Dim rect1 As New Rectangle(10, 60, 270, 15)
            Dim rect2 As New Rectangle(10, 75, 270, 15)
            Dim rect3 As New Rectangle(10, 90, 270, 15)
            Dim rect4 As New Rectangle(10, 105, 270, 15)
            Dim rect5 As New Rectangle(10, 120, 270, 15)
            Dim rect6 As New Rectangle(10, 135, 270, 15)
            Dim rect7 As New Rectangle(10, 185, 270, 17)
            Dim rect15 As New Rectangle(10, 150, 270, 15)

            e.Graphics.DrawString(minombreempresa, Font3, Brushes.Black, rect1, stringFormat)
            e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect2, stringFormat)
            e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect3, stringFormat)
            e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect4, stringFormat)
            e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect5, stringFormat)
            e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect6, stringFormat)
            e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect15, stringFormat)

            e.Graphics.DrawString("COTIZACION", Font2, Brushes.Black, rect7, stringFormat)
            e.Graphics.DrawString("NRO. COT.", Font4, Brushes.Black, 0, 220)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 220)
            e.Graphics.DrawString(txt_factura.Text, Font3, Brushes.Black, 83, 220)
            e.Graphics.DrawString("FECHA", Font4, Brushes.Black, 0, 235)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 235)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font3, Brushes.Black, 83, 235)
            e.Graphics.DrawString("TELEFONO", Font4, Brushes.Black, 0, 250)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 250)
            e.Graphics.DrawString(mitelefono, Font3, Brushes.Black, 83, 250)
            e.Graphics.DrawString("VENDEDOR", Font4, Brushes.Black, 0, 265)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 265)
            e.Graphics.DrawString(minombre, Font3, Brushes.Black, 83, 265)
            Dim rect_ingresa As New Rectangle(15, 293, 270, 22)
            e.Graphics.DrawString("INGRESA", Font2, Brushes.Black, rect_ingresa, stringFormat)
            e.Graphics.DrawString("CODIGO", Font4, Brushes.Black, 0, 325)
            e.Graphics.DrawString("DESCRIPCION", Font4, Brushes.Black, 55, 325)
            e.Graphics.DrawString("CANT.", Font4, Brushes.Black, 200, 325)
            e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 245, 325)
            e.Graphics.DrawLine(Pens.Black, 1, 340, 295, 340)

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
                cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")

                Dim cantidad As String
                Dim total As String
                Dim descripcion As String

                cantidad = VarCantidad
                total = total_detalle
                descripcion = varnombre

                If varnombre.Length > 17 Then
                    descripcion = varnombre.Substring(0, 17)
                End If

                total = Format(Int(total), "###,###,###")
                VarSubtotal = Format(Int(VarSubtotal), "###,###,###")

                e.Graphics.DrawString(VarCodProducto, Font3, Brushes.Gray, 0, 343 + (i * 30))
                e.Graphics.DrawString(descripcion, Font3, Brushes.Gray, 55, 343 + (i * 30))
                e.Graphics.DrawString(vartecnico, Font3, Brushes.Gray, 55, 353 + (i * 30))
                e.Graphics.DrawString(VarSubtotal & " X " & cantidad, Font3, Brushes.Gray, 235, 353 + (i * 30), format1)
                e.Graphics.DrawString(total, Font3, Brushes.Gray, 285, 353 + (i * 30), format1)
                e.Graphics.DrawLine(Pens.Black, 1, 368 + (i * 30), 295, 368 + (i * 30))
                '  cuenta_ciclo = cuenta_ciclo + 1
            Next

            Dim subtotal_millar As String
            Dim descuento_millar As String
            Dim total_millar As String

            descuento_millar = txt_desc_total.Text
            subtotal_millar = txt_sub_total_millar.Text
            total_millar = txt_total_millar.Text

            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            Dim var_grilla As Integer
            var_grilla = ((grilla_detalle_venta.Rows.Count) * 30)

            e.Graphics.DrawString("SUBTOTAL", Font4, Brushes.Black, 160, var_grilla + 360)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + 360)
            e.Graphics.DrawString(subtotal_millar, Font3, Brushes.Black, 285, var_grilla + 360, format1)
            e.Graphics.DrawString("DESCUENTO", Font4, Brushes.Black, 160, var_grilla + 375)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + 375)
            e.Graphics.DrawString(descuento_millar, Font3, Brushes.Black, 285, var_grilla + 375, format1)
            e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 160, var_grilla + 390)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + 390)
            e.Graphics.DrawString(total_millar, Font3, Brushes.Black, 285, var_grilla + 390, format1)
            Dim rect_sale As New Rectangle(10, var_grilla + 420, 270, 17)
            e.Graphics.DrawString("SALE", Font2, Brushes.Black, rect_sale, stringFormat)
            e.Graphics.DrawString("CODIGO", Font4, Brushes.Black, 0, var_grilla + 450)
            e.Graphics.DrawString("DESCRIPCION", Font4, Brushes.Black, 55, var_grilla + 450)
            e.Graphics.DrawString("CANT.", Font4, Brushes.Black, 200, var_grilla + 450)
            e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 245, var_grilla + 450)
            e.Graphics.DrawLine(Pens.Black, 1, var_grilla + 465, 295, var_grilla + 465)
        End If

        If ticket_de_cambio = "SI" Then
            Dim Font1 As New Font("arial", 7, FontStyle.Regular)
            Dim Font2 As New Font("arial", 10, FontStyle.Bold)
            Dim Font3 As New Font("arial", 7, FontStyle.Bold)
            Dim Font4 As New Font("arial", 8, FontStyle.Regular)

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center
            Dim stringFormatJustificado As New StringFormat()
            stringFormatJustificado.Alignment = StringAlignment.Center
            stringFormatJustificado.LineAlignment = StringAlignment.Center

            Dim rect7 As New Rectangle(10, 0, 270, 15)
            Dim rect8 As New Rectangle(10, 90, 270, 50)
            Dim rect9 As New Rectangle(10, 240, 270, 50)
            Dim rect10 As New Rectangle(10, 125, 270, 150)

            e.Graphics.DrawString(minombreempresa, Font2, Brushes.Black, rect7, stringFormat)
            e.Graphics.DrawString("N. DOC.", Font4, Brushes.Black, 0, 30)
            e.Graphics.DrawString(":", Font4, Brushes.Black, 73, 30)

            Dim codigo As String = 0
            Dim valor As Integer
            codigo = txt_factura.Text
            Dim nro_ticket As String
            valor = codigo
            nro_ticket = String.Format("{0:000000}", valor)

            Dim mifecha As Date
            Dim fecha_doc As String
            mifecha = Form_menu_principal.dtp_fecha.Text
            fecha_doc = mifecha.ToString("dd-MM-yyy")

            e.Graphics.DrawString(Combo_venta.Text & ", " & txt_factura.Text, Font4, Brushes.Black, 80, 30)
            e.Graphics.DrawString("FECHA", Font4, Brushes.Black, 0, 45)
            e.Graphics.DrawString(":", Font4, Brushes.Black, 73, 45)
            e.Graphics.DrawString(fecha_doc, Font4, Brushes.Black, 80, 45)
            e.Graphics.DrawString("VENDEDOR", Font4, Brushes.Black, 0, 60)
            e.Graphics.DrawString(":", Font4, Brushes.Black, 73, 60)
            e.Graphics.DrawString(txt_nombre_usuario.Text, Font4, Brushes.Black, 80, 60)
            e.Graphics.DrawString("*" & (nro_ticket) & "*", New Font("C39HrP36DlTt", 34), Brushes.Black, rect8, stringFormat)
            e.Graphics.DrawString("TICKET PARA CAMBIO", Font2, Brushes.Black, rect9, stringFormat)
            e.Graphics.DrawString("SI QUIERES CAMBIAR EL PRODUCTO, PUEDE HACERLO DENTRO DE LOS 30 DIAS SIGUIENTES A LA FECHA EN QUE HA SIDO COMPRADO, EL PRODUCTO DEBE SER CAMBIADO SIN USO, CON SUS SELLOS Y EMBALAJES ORIGINALES, EN PERFECTO ESTADO.", Font4, Brushes.Black, rect10, stringFormatJustificado)
            e.Graphics.DrawString("-", Font3, Brushes.Gray, 150, 290)
            Exit Sub
        End If


        If tipo_impresion_sistema = "TICKET" Then
            Dim Font1 As New Font("arial", 7, FontStyle.Regular)
            Dim Font2 As New Font("arial", 10, FontStyle.Bold)
            Dim Font3 As New Font("arial", 7, FontStyle.Bold)
            Dim Font4 As New Font("arial", 8, FontStyle.Regular)

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            Dim rect7 As New Rectangle(10, 0, 270, 15)
            Dim rect8 As New Rectangle(10, 90, 270, 50)

            e.Graphics.DrawString("TICKET DE VENTA", Font2, Brushes.Black, rect7, stringFormat)
            e.Graphics.DrawString("NRO. TICKET", Font4, Brushes.Black, 0, 30)
            e.Graphics.DrawString(":", Font4, Brushes.Black, 73, 30)

            Dim codigo As String = 0
            Dim valor As Integer
            codigo = txt_factura.Text
            Dim nro_ticket As String
            valor = codigo
            nro_ticket = String.Format("{0:000000}", valor)

            Dim mifecha As Date
            Dim fecha_doc As String
            mifecha = Form_menu_principal.dtp_fecha.Text
            fecha_doc = mifecha.ToString("dd-MM-yyy")

            e.Graphics.DrawString(txt_factura.Text, Font4, Brushes.Black, 80, 30)
            e.Graphics.DrawString("FECHA", Font4, Brushes.Black, 0, 45)
            e.Graphics.DrawString(":", Font4, Brushes.Black, 73, 45)
            e.Graphics.DrawString(fecha_doc, Font4, Brushes.Black, 80, 45)
            e.Graphics.DrawString("VENDEDOR", Font4, Brushes.Black, 0, 60)
            e.Graphics.DrawString(":", Font4, Brushes.Black, 73, 60)
            e.Graphics.DrawString(txt_nombre_usuario.Text, Font4, Brushes.Black, 80, 60)
            e.Graphics.DrawString("*" & (nro_ticket) & "*", New Font("C39HrP36DlTt", 34), Brushes.Black, rect8, stringFormat)
            e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, 185)
            Exit Sub
        End If

        If Combo_venta.Text = "BOLETA" Then
            Dim margen As Integer
            margen = "45"

            If mirutempresa <> "81921000-4" Then
                e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, margen + 85, 5)
                e.Graphics.DrawString(combo_condiciones.Text, Font10, Brushes.Black, margen + 590, 5)

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
                    cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                    valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                    subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                    total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                    valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                    subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                    total_detalle = Format(Int(total_detalle), "###,###,###")

                    Dim descripcion_caracteres As String
                    descripcion_caracteres = varnombre & " " & vartecnico
                    If descripcion_caracteres.Length > 55 Then
                        descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                    End If

                    e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, margen + 50, 60 + (i * 15))
                    e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, margen + 120, 60 + (i * 15))
                    e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, margen + 565, 60 + (i * 15), format1)
                    e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, margen + 645, 60 + (i * 15), format1)
                    e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, margen + 725, 60 + (i * 15), format1)
                Next

                Dim descuento_millar As String
                Dim neto_millar As String
                Dim iva_millar As String
                Dim total_millar As String
                Dim subtotal_millar As String

                descuento_millar = txt_desc.Text
                neto_millar = txt_neto.Text
                iva_millar = txt_iva.Text
                subtotal_millar = txt_sub_total.Text
                total_millar = txt_total.Text

                descuento_millar = Format(Int(descuento_millar), "###,###,###")
                neto_millar = Format(Int(neto_millar), "###,###,###")
                iva_millar = Format(Int(iva_millar), "###,###,###")
                subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
                total_millar = Format(Int(total_millar), "###,###,###")

                Dim nombre_vendedor As String
                nombre_vendedor = txt_nombre_usuario.Text
                If nombre_vendedor.Length > 12 Then
                    nombre_vendedor = nombre_vendedor.Substring(0, 12)
                End If

                e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, margen + 60, 270)
                e.Graphics.DrawString(nombre_vendedor, Font10, Brushes.Black, margen + 215, 270)
                e.Graphics.DrawString(subtotal_millar, Font10, Brushes.Black, margen + 385, 270)
                e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, margen + 515, 270)
                e.Graphics.DrawString(total_millar, Font10, Brushes.Black, margen + 630, 270)
            End If
        End If

        If Combo_venta.Text = "BOLETA DE CREDITO" Then
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
            e.Graphics.DrawString(combo_condiciones.Text, Font10, Brushes.Black, 590, 5)
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
                cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")

                Dim descripcion_caracteres As String
                descripcion_caracteres = varnombre & " " & vartecnico
                If descripcion_caracteres.Length > 55 Then
                    descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                End If

                e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 50, 60 + (i * 15))
                e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, 60 + (i * 15))
                e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 565, 60 + (i * 15), format1)
                e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 645, 60 + (i * 15), format1)
                e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 725, 60 + (i * 15), format1)
            Next

            Dim descuento_millar As String
            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String
            Dim subtotal_millar As String

            descuento_millar = txt_desc.Text
            neto_millar = txt_neto.Text
            iva_millar = txt_iva.Text
            subtotal_millar = txt_sub_total.Text
            total_millar = txt_total.Text
            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            neto_millar = Format(Int(neto_millar), "###,###,###")
            iva_millar = Format(Int(iva_millar), "###,###,###")
            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            Dim nombre_vendedor As String
            nombre_vendedor = txt_nombre_usuario.Text
            If nombre_vendedor.Length > 12 Then
                nombre_vendedor = nombre_vendedor.Substring(0, 12)
            End If

            If txt_nombre_cliente.Text <> "SIN NOMBRE" And txt_nombre_cliente.Text <> "" Then
                e.Graphics.DrawString(txt_nombre_cliente.Text, Font10, Brushes.Black, 60, 190)
                e.Graphics.DrawString(txt_rut_cliente.Text, Font10, Brushes.Black, 60, 205)
                e.Graphics.DrawString(txt_direccion_cliente.Text, Font10, Brushes.Black, 60, 220)
                e.Graphics.DrawString(txt_comuna_cliente.Text, Font10, Brushes.Black, 60, 235)
                e.Graphics.DrawString(txt_telefono.Text, Font10, Brushes.Black, 60, 245)
            End If

            e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 60, 270)
            e.Graphics.DrawString(nombre_vendedor, Font10, Brushes.Black, 215, 270)
            e.Graphics.DrawString(subtotal_millar, Font10, Brushes.Black, 385, 270)
            e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, 515, 270)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 630, 270)
        End If

        If Combo_venta.Text = "FACTURA" Then
            e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 550, 10, format1)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 10)
            e.Graphics.DrawString(txt_nombre_cliente.Text, Font10, Brushes.Black, 85, 25)
            e.Graphics.DrawString(txt_direccion_cliente.Text, Font10, Brushes.Black, 85, 40)
            e.Graphics.DrawString(txt_giro_cliente.Text, Font10, Brushes.Black, 85, 55)
            e.Graphics.DrawString(txt_rut_cliente.Text, Font10, Brushes.Black, 665, 10)
            e.Graphics.DrawString(txt_comuna_cliente.Text, Font10, Brushes.Black, 665, 25)
            e.Graphics.DrawString(txt_telefono.Text, Font10, Brushes.Black, 665, 40)
            e.Graphics.DrawString(combo_condiciones.Text, Font10, Brushes.Black, 665, 55)

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
                cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")

                If varnombre.Length > 35 Then
                    varnombre = varnombre.Substring(0, 35)
                End If

                If vartecnico.Length > 22 Then
                    vartecnico = vartecnico.Substring(0, 22)
                End If

                e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 130 + (i * 15))
                e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 85, 130 + (i * 15))
                e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 340, 130 + (i * 15))
                e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 540, 130 + (i * 15), format1)
                e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 130 + (i * 15), format1)
                e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 650, 130 + (i * 15), format1)
                e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 730, 130 + (i * 15), format1)
                e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 800, 130 + (i * 15), format1)
            Next

            Dim descuento_millar As String
            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String
            Dim subtotal_millar As String

            descuento_millar = txt_desc.Text
            neto_millar = txt_neto.Text
            iva_millar = txt_iva.Text
            subtotal_millar = txt_sub_total.Text
            total_millar = txt_total.Text

            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            neto_millar = Format(Int(neto_millar), "###,###,###")
            iva_millar = Format(Int(iva_millar), "###,###,###")
            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            e.Graphics.DrawString(desglose_valor, Font9, Brushes.Black, 35, 670)
            e.Graphics.DrawString(txt_nombre_usuario.Text, Font9, Brushes.Black, 35, 690)
            e.Graphics.DrawString(txt_nombre_retira.Text, Font8, Brushes.Black, 50, 735)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 40, 755)
            e.Graphics.DrawString(txt_rut_retira.Text, Font8, Brushes.Black, 470, 735)
            e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 180, 755)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 680, format1)
            e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 725, format1)
            e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 765, format1)

            If descuento_millar <> "" Then
                If descuento_millar <> "0" Then
                    e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 800, 580, format1)
                    e.Graphics.DrawString("- " & descuento_millar, Font8, Brushes.Black, 800, 600, format1)
                    e.Graphics.DrawString("_________", Font8, Brushes.Black, 800, 602, format1)
                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 800, 620, format1)
                End If
            End If
        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 550, 10, format1)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 10)
            e.Graphics.DrawString(txt_nombre_cliente.Text, Font10, Brushes.Black, 85, 25)
            e.Graphics.DrawString(Me.txt_folio.Text, Font10, Brushes.Black, 550, 25, format1)
            e.Graphics.DrawString(txt_direccion_cliente.Text, Font10, Brushes.Black, 85, 40)
            e.Graphics.DrawString(txt_giro_cliente.Text, Font10, Brushes.Black, 85, 55)

            If txt_nro_orden_de_compra.Text <> "" Then
                If txt_nro_orden_de_compra.Text <> "0" Then
                    e.Graphics.DrawString("ORDEN DE COMPRA: " & txt_nro_orden_de_compra.Text, Font10, Brushes.Black, 50, 70)
                End If
            End If

            e.Graphics.DrawString(txt_rut_cliente.Text, Font10, Brushes.Black, 665, 10)
            e.Graphics.DrawString(txt_comuna_cliente.Text, Font10, Brushes.Black, 665, 25)
            e.Graphics.DrawString(txt_telefono.Text, Font10, Brushes.Black, 665, 40)
            e.Graphics.DrawString(combo_condiciones.Text, Font10, Brushes.Black, 665, 55)

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
                cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")

                If varnombre.Length > 35 Then
                    varnombre = varnombre.Substring(0, 35)
                End If

                If vartecnico.Length > 22 Then
                    vartecnico = vartecnico.Substring(0, 22)
                End If

                e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 130 + (i * 15))
                e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 85, 130 + (i * 15))
                e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 340, 130 + (i * 15))
                e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 540, 130 + (i * 15), format1)
                e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 130 + (i * 15), format1)
                e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 650, 130 + (i * 15), format1)
                e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 730, 130 + (i * 15), format1)
                e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 800, 130 + (i * 15), format1)
            Next

            Dim descuento_millar As String
            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String
            Dim subtotal_millar As String

            descuento_millar = txt_desc.Text
            neto_millar = txt_neto.Text
            iva_millar = txt_iva.Text
            subtotal_millar = txt_sub_total.Text
            total_millar = txt_total.Text

            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            neto_millar = Format(Int(neto_millar), "###,###,###")
            iva_millar = Format(Int(iva_millar), "###,###,###")
            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            e.Graphics.DrawString(desglose_valor, Font9, Brushes.Black, 35, 670)
            e.Graphics.DrawString(txt_nombre_usuario.Text, Font9, Brushes.Black, 35, 690)
            e.Graphics.DrawString(txt_nombre_retira.Text, Font8, Brushes.Black, 50, 735)
            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 40, 755)
            e.Graphics.DrawString(txt_rut_retira.Text, Font8, Brushes.Black, 470, 735)
            e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 180, 755)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 680, format1)
            e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 725, format1)
            e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 765, format1)

            If descuento_millar <> "" Then
                If descuento_millar <> "0" Then
                    e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 800, 580, format1)
                    e.Graphics.DrawString("- " & descuento_millar, Font8, Brushes.Black, 800, 600, format1)
                    e.Graphics.DrawString("_________", Font8, Brushes.Black, 800, 602, format1)
                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 800, 620, format1)
                End If
            End If
        End If

        If Me.Combo_venta.Text = "GUIA" Then
            If mirutempresa <> "81921000-4" Then
                e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 100, 20)
                e.Graphics.DrawString(Me.txt_factura.Text, Font10, Brushes.Black, 550, 20, format1)

                e.Graphics.DrawString(Me.txt_nombre_cliente.Text, Font10, Brushes.Black, 100, 36)
                e.Graphics.DrawString(Me.txt_folio.Text, Font10, Brushes.Black, 550, 36, format1)
                e.Graphics.DrawString(Me.txt_direccion_cliente.Text, Font10, Brushes.Black, 100, 52)

                If Me.txt_descuento_cliente_2.Text <> "0" Then
                    e.Graphics.DrawString("-" & Me.txt_descuento_cliente_2.Text & "%", Font10, Brushes.Black, 550, 52, format1)
                End If

                e.Graphics.DrawString(Me.txt_giro_cliente.Text, Font10, Brushes.Black, 100, 68)
                e.Graphics.DrawString(txt_nro_orden_de_compra.Text, Font10, Brushes.Black, 100, 84)

                e.Graphics.DrawString(Me.txt_rut_cliente.Text, Font10, Brushes.Black, 655, 20)
                e.Graphics.DrawString(Me.txt_comuna_cliente.Text, Font10, Brushes.Black, 655, 36)
                e.Graphics.DrawString(Me.txt_telefono.Text, Font10, Brushes.Black, 655, 52)
                e.Graphics.DrawString(Me.combo_condiciones.Text, Font10, Brushes.Black, 655, 68)
                e.Graphics.DrawString(txt_nombre_usuario.Text, Font10, Brushes.Black, 655, 84)

                For i = 0 To Me.grilla_detalle_venta.Rows.Count - 1
                    VarCodProducto = Me.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                    varnombre = Me.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                    vartecnico = Me.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                    VarValorUnitario = Me.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                    VarCantidad = Me.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                    VarNeto = Me.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                    VarIva = Me.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                    VarSubtotal = Me.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                    VarPorcentaje = Me.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                    VarDescuento = Me.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                    VarTotal = Me.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                    cantidad_detalle = Me.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                    valorUnitario_detalle = Me.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                    subtotal_detalle = Me.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                    total_detalle = Me.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                    valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                    subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                    total_detalle = Format(Int(total_detalle), "###,###,###")

                    If varnombre.Length > 35 Then
                        varnombre = varnombre.Substring(0, 35)
                    End If

                    If vartecnico.Length > 22 Then
                        vartecnico = vartecnico.Substring(0, 22)
                    End If

                    e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 0, 145 + (i * 15))
                    e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 75, 145 + (i * 15))
                    e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 335, 145 + (i * 15))
                    e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 520, 145 + (i * 15), format1)
                    e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 145 + (i * 15), format1)
                    e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 640, 145 + (i * 15), format1)
                    e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 725, 145 + (i * 15), format1)
                    e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 792, 145 + (i * 15), format1)
                Next

                Dim descuento_millar As String
                Dim neto_millar As String
                Dim iva_millar As String
                Dim total_millar As String
                Dim subtotal_millar As String

                descuento_millar = Me.txt_desc.Text
                neto_millar = Me.txt_neto.Text
                iva_millar = Me.txt_iva.Text
                subtotal_millar = Me.txt_sub_total.Text
                total_millar = Me.txt_total.Text

                descuento_millar = Format(Int(descuento_millar), "###,###,###")
                neto_millar = Format(Int(neto_millar), "###,###,###")
                iva_millar = Format(Int(iva_millar), "###,###,###")
                subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
                total_millar = Format(Int(total_millar), "###,###,###")

                e.Graphics.DrawString(Me.txt_nombre_retira.Text, Font8, Brushes.Black, 55, 540)
                e.Graphics.DrawString(Me.txt_rut_retira.Text, Font8, Brushes.Black, 265, 540)
                e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 510, 540)
                e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 797, 540, format1)

                If combo_condiciones.Text <> "TRASLADO" Then
                    If Me.txt_desc.Text = "0" Or Me.txt_desc.Text = "" Then
                        e.Graphics.DrawString("TOTAL $", Font8, Brushes.Black, 725, 400, format1)
                        e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 400, format1)
                    Else
                        e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 792, 400, format1)
                        e.Graphics.DrawString("-" & Me.txt_porcentaje_desc.Text & "%", Font8, Brushes.Black, 725, 415, format1)
                        e.Graphics.DrawString(descuento_millar, Font8, Brushes.Black, 792, 415, format1)
                        e.Graphics.DrawString("_________", Font8, Brushes.Black, 792, 417, format1)
                        e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 432, format1)
                    End If
                End If
            End If

            If mirutempresa = "81921000-4" Then
                'e.Graphics.DrawString("NRO. GUIA: " & txt_factura.Text & ", PROVIENE DE: " & mirecintoempresa & " , BULTOS: " & txt_productos.Text, Font10, Brushes.Black, 0, 0)
                e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 85, 0)
                e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Value.Day & "          " & Form_menu_principal.dtp_fecha.Value.Month & "         " & Form_menu_principal.dtp_fecha.Value.Year, Font10, Brushes.Black, 620, 0)
                e.Graphics.DrawString(txt_nombre_cliente.Text, Font10, Brushes.Black, 80, 40)
                e.Graphics.DrawString(txt_direccion_cliente.Text, Font10, Brushes.Black, 80, 57)
                e.Graphics.DrawString(txt_giro_cliente.Text, Font10, Brushes.Black, 80, 74)
                e.Graphics.DrawString(txt_telefono.Text, Font10, Brushes.Black, 80, 91)
                'e.Graphics.DrawString(Combo_vehiculo.Text, Font10, Brushes.Black, 80, 108)
                e.Graphics.DrawString(txt_rut_cliente.Text, Font10, Brushes.Black, 550, 40)
                e.Graphics.DrawString(txt_comuna_cliente.Text, Font10, Brushes.Black, 550, 57)
                e.Graphics.DrawString(txt_ciudad_cliente.Text, Font10, Brushes.Black, 550, 74)
                e.Graphics.DrawString(combo_condiciones.Text, Font10, Brushes.Black, 550, 91)
                'e.Graphics.DrawString(txt_patente.Text, Font10, Brushes.Black, 550, 108)

                For i = 0 To Me.grilla_detalle_venta.Rows.Count - 1
                    VarCodProducto = Me.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                    varnombre = Me.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                    vartecnico = Me.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                    VarValorUnitario = Me.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                    VarCantidad = Me.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                    VarNeto = Me.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                    VarIva = Me.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                    VarSubtotal = Me.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                    VarPorcentaje = Me.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                    VarDescuento = Me.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                    VarTotal = Me.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                    cantidad_detalle = Me.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                    valorUnitario_detalle = Me.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                    subtotal_detalle = Me.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                    total_detalle = Me.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                    valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                    subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                    total_detalle = Format(Int(total_detalle), "###,###,###")

                    If varnombre.Length > 35 Then
                        varnombre = varnombre.Substring(0, 35)
                    End If

                    If vartecnico.Length > 22 Then
                        vartecnico = vartecnico.Substring(0, 22)
                    End If

                    e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 190 + (i * 15))
                    e.Graphics.DrawString(varnombre & " " & vartecnico, Font8, Brushes.Black, 130, 190 + (i * 15))
                    e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 570, 190 + (i * 15), format1)
                    e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 730, 190 + (i * 15), format1)
                Next

                Dim descuento_millar As String
                Dim neto_millar As String
                Dim iva_millar As String
                Dim total_millar As String
                Dim subtotal_millar As String

                descuento_millar = Me.txt_desc.Text
                neto_millar = Me.txt_neto.Text
                iva_millar = Me.txt_iva.Text
                subtotal_millar = Me.txt_sub_total.Text
                total_millar = Me.txt_total.Text

                descuento_millar = Format(Int(descuento_millar), "###,###,###")
                neto_millar = Format(Int(neto_millar), "###,###,###")
                iva_millar = Format(Int(iva_millar), "###,###,###")
                subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
                total_millar = Format(Int(total_millar), "###,###,###")

                e.Graphics.DrawString(Me.txt_nombre_retira.Text, Font8, Brushes.Black, 55, 540)
                e.Graphics.DrawString(Me.txt_rut_retira.Text, Font8, Brushes.Black, 265, 540)
                e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 510, 540)
                e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 797, 540, format1)

                If combo_condiciones.Text <> "TRASLADO" Then
                    If Me.txt_desc.Text = "0" Or Me.txt_desc.Text = "" Then
                        e.Graphics.DrawString("TOTAL $", Font8, Brushes.Black, 725, 400, format1)
                        e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 400, format1)
                    Else
                        e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 792, 400, format1)
                        e.Graphics.DrawString("-" & Me.txt_porcentaje_desc.Text & "%", Font8, Brushes.Black, 725, 415, format1)
                        e.Graphics.DrawString(descuento_millar, Font8, Brushes.Black, 792, 415, format1)
                        e.Graphics.DrawString("_________", Font8, Brushes.Black, 792, 417, format1)
                        e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 432, format1)
                    End If
                End If
            End If
        End If

    End Sub



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

    Private Sub Timer_ventas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_ventas.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub

    Private Sub txt_rut_retira_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_retira.GotFocus
        txt_rut_retira.BackColor = Color.LightSkyBlue
    End Sub


    Private Sub txt_rut_retira_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_retira.KeyPress

        txt_nombre_retira.Text = ""

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
            txt_nombre_retira.Text = ""
            guion_rut_cliente_retira()
            mostrar_datos_retira()

            If txt_nombre_retira.Text = "" Then
                txt_rut_retira.Focus()
            Else
                txt_codigo.Focus()
            End If
        End If
    End Sub

    Sub valores()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select iva, factor from valores"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            valor_iva = DS2.Tables(DT2.TableName).Rows(0).Item("iva")
            valor_factor = DS2.Tables(DT2.TableName).Rows(0).Item("factor")
        End If
        conexion.Close()
    End Sub

    Sub revisar_vuelto()
        If vuelto = "SI" Then
            Me.txt_efectivo.Visible = True
            Me.txt_vuelto.Visible = True
            Me.lbl_1.Text = "$ MONTO:"
            Me.lbl_2.Text = "VUELTO:"

            'Me.lbl_1.Location = New Point(0, 28)
            'Me.lbl_2.Location = New Point(0, 59)
            'Me.lbl_3.Location = New Point(0, 90)

            'Form_venta.lbl_1.Location = New Point(8, 30)
            'Form_venta.lbl_2.Location = New Point(8, 61)
            'Form_venta.lbl_3.Location = New Point(8, 93)

            Me.txt_efectivo.Location = New Point(92, 27)
            'Me.txt_efectivo.Location = New Point(txt_sub_total_millar.Location)

            Me.txt_vuelto.Location = New Point(92, 61)
            'Me.txt_vuelto.Location = New Point(txt_porcentaje_desc.Location)

            Me.txt_neto_millar.Location = New Point(92, 27)
            Me.txt_iva_millar.Location = New Point(92, 61)

            Me.txt_total_millar.Location = New Point(92, 95)
            'Me.txt_total_millar.Location = New Point(txt_desc_millar.Location)
            Exit Sub
        End If

        If vuelto = "NO" Then
            Me.txt_efectivo.Visible = False
            Me.txt_vuelto.Visible = False
            Me.lbl_1.Text = "NETO:"
            Me.lbl_2.Text = "IVA:"
            'Form_venta.lbl_1.Location = New Point(0, 30)
            'Form_venta.lbl_2.Location = New Point(0, 61)
            'Form_venta.lbl_3.Location = New Point(0, 93)
            Me.txt_neto_millar.Location = New Point(92, 27)
            Me.txt_iva_millar.Location = New Point(92, 61)
            Me.txt_total_millar.Location = New Point(92, 95)
        End If
    End Sub

    Private Sub txt_rut_retira_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut_retira.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_clientes_retira.Show()
            Me.Enabled = False
        End If

        If e.KeyCode = Keys.F6 Then
            Form_registro_cliente_retira_ventas.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_rut_retira_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_retira.LostFocus
        txt_rut_retira.BackColor = Color.White
    End Sub
    Private Sub txt_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cargar.GotFocus
        txt_cargar.BackColor = Color.LightSkyBlue
        Combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Sub crear_archivo_plano()
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        Dim nro_linea As String
        Dim nombre_cliente As String

        nombre_cliente = txt_nombre_cliente.Text

        If nombre_cliente.Length > 40 Then
            nombre_cliente = nombre_cliente.Substring(0, 40)
        End If

        Dim giro_cliente As String
        giro_cliente = txt_giro_cliente.Text
        If giro_cliente.Length > 40 Then
            giro_cliente = giro_cliente.Substring(0, 40)
        End If

        Dim direccion_cliente As String
        direccion_cliente = txt_direccion_cliente.Text
        If direccion_cliente.Length > 59 Then
            direccion_cliente = direccion_cliente.Substring(0, 60)
        End If

        Dim comuna_cliente As String
        comuna_cliente = txt_comuna_cliente.Text
        If comuna_cliente.Length > 19 Then
            comuna_cliente = comuna_cliente.Substring(0, 20)
        End If

        Dim ciudad_cliente As String
        ciudad_cliente = txt_ciudad_cliente.Text
        If ciudad_cliente.Length > 19 Then
            ciudad_cliente = ciudad_cliente.Substring(0, 20)
        End If

        Dim correo_cliente As String
        correo_cliente = txt_correo_cliente.Text
        If correo_cliente.Length > 199 Then
            correo_cliente = correo_cliente.Substring(0, 200)
        End If

        txt_telefono.Text = Trim(dejarNumerosPuntos(txt_telefono.Text))

        Dim telefono_cliente As String
        telefono_cliente = txt_telefono.Text
        If telefono_cliente.Length > 8 Then
            telefono_cliente = telefono_cliente.Substring(0, 8)
        End If

        If correo_cliente = "-" Then
            correo_cliente = ""
        End If

        If txt_folio.Text = "-" Then
            txt_folio.Text = ""
        End If

        Dim condicion As String

        condicion = combo_condiciones.Text

        If combo_condiciones.Text = "EFECTIVO" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "ABCDIN" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CENCOSUD" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "C&D" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "PRESTO" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "RYPLEY" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "VISA" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "MASTERCARD" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "BANCARIA" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "REDCOMPRA" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "TRANSFERENCIA" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE AL DIA" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 15 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 30 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 45 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 60 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 30-60 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 30-60-90 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "PENDIENTE" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "TRANSFERENCIA" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CREDITO" Then
            condicion = "CREDITO " & "(" & combo_condiciones.Text & ")"
        End If


        ''correcto sin modificaciones
        'If Combo_venta.Text = "BOLETA" Then
        '    Try

        '        If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
        '            Directory.CreateDirectory(ruta_archivos_planos)
        '        End If

        '        'If Directory.Exists("C:\Carpeta Facturacion Electronica") = False Then ' si no existe la carpeta se crea
        '        ' Directory.CreateDirectory("C:\Carpeta Facturacion Electronica")
        '        'End If

        '        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        '        ' PathArchivo = "C:\carpeta\Archivo" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '        ' PathArchivo = "\\SERVER\Claudio Calderon R\Capeta\Archivo '" & (combo_venta.Text) & "'" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '        ' PathArchivo = "C:\Carpeta Facturacion Electronica\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '        PathArchivo = ruta_archivos_planos & "\" & "BOLETA " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

        '        'verificamos si existe el archivo

        '        If File.Exists(PathArchivo) Then
        '            strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
        '        Else
        '            strStreamW = File.Create(PathArchivo) ' lo creamos
        '        End If

        '        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

        '        'escribimos en el archivo
        '        strStreamWriter.WriteLine("->BOLETA<-" & vbNewLine _
        '        & ("39") & ";" & (txt_factura.Text) & ";" & (dtp_fecha.Text) & ";" & ("3") & ";" & ("0") & ";" & ("") & ";" & ("") & ";" & ("") & ";" & (txt_rut_cliente.Text) & ";" & (txt_cod_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (comuna_cliente) & ";" & (ciudad_cliente) & ";" & (correo_cliente) & ";" & vbNewLine _
        '        & "->BOLETATotales<-" & vbNewLine _
        '        & (txt_neto.Text) & ";" & ("0") & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & vbNewLine _
        '        & "->BOLETADetalle<-")

        '        nro_linea = 0
        '        For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '            nro_linea = nro_linea + 1
        '            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
        '            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
        '            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
        '            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
        '            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
        '            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
        '            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
        '            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
        '            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
        '            'VarDescuento = VarDescuento * VarCantidad
        '            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

        '            VarPorcentaje = 0
        '            VarDescuento = 0
        '            VarValorUnitario = VarSubtotal

        '            If VarCodProducto.Length > 34 Then
        '                VarCodProducto = VarCodProducto.Substring(0, 35)
        '            End If

        '            varnombre = varnombre & " " & vartecnico

        '            If varnombre.Length > 80 Then
        '                varnombre = varnombre.Substring(0, 80)
        '            End If

        '            varnombre = VarCodProducto & " - " & varnombre & " " & vartecnico

        '            If varnombre.Length > 52 Then
        '                varnombre = varnombre.Substring(0, 51)
        '            End If

        '            VarCantidad = Replace(VarCantidad, ",", ".")
        '            VarPorcentaje = Replace(VarPorcentaje, ",", ".")

        '            strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & ("0") & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & ("0") & ";" & (VarTotal) & ";" & ("INT11") & ";" & ("UN") & ";" & ("") & ";")
        '        Next

        '        If txt_nro_orden_de_compra.Text = "0" Then
        '            txt_nro_orden_de_compra.Text = ""
        '        End If

        '        strStreamWriter.WriteLine("->BOLETADescRec<-" & vbNewLine _
        '        & ("1") & ";" & ("D") & ";" & ("Descuento") & ";" & ("$") & ";" & (txt_desc.Text) & ";" & ("0") & ";" & vbNewLine _
        '        & "->BOLETAReferencia<-" & vbNewLine _
        '        & ("1") & ";" & ("") & ";" & ("") & ";" & vbNewLine _
        '        & "->Observacion<-" & vbNewLine _
        '        & (combo_condiciones.Text) & ", " & txt_nombre_usuario.Text & ", " & mirecintoempresa & ";")

        '        strStreamWriter.Close() ' cerramos

        '    Catch ex As Exception
        '        MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
        '        strStreamWriter.Close() ' cerramos
        '    End Try
        'End If





        'If Combo_venta.Text = "BOLETA DE CREDITO" Then
        '    Try

        '        If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
        '            Directory.CreateDirectory(ruta_archivos_planos)
        '        End If

        '        'If Directory.Exists("C:\Carpeta Facturacion Electronica") = False Then ' si no existe la carpeta se crea
        '        ' Directory.CreateDirectory("C:\Carpeta Facturacion Electronica")
        '        'End If

        '        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        '        ' PathArchivo = "C:\carpeta\Archivo" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '        ' PathArchivo = "\\SERVER\Claudio Calderon R\Capeta\Archivo '" & (combo_venta.Text) & "'" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '        ' PathArchivo = "C:\Carpeta Facturacion Electronica\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '        PathArchivo = ruta_archivos_planos & "\" & "BOLETA " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

        '        'verificamos si existe el archivo

        '        If File.Exists(PathArchivo) Then
        '            strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
        '        Else
        '            strStreamW = File.Create(PathArchivo) ' lo creamos
        '        End If

        '        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

        '        'escribimos en el archivo
        '        strStreamWriter.WriteLine("->BOLETA<-" & vbNewLine _
        '        & ("39") & ";" & (txt_factura.Text) & ";" & (dtp_fecha.Text) & ";" & ("3") & ";" & ("0") & ";" & ("") & ";" & ("") & ";" & ("") & ";" & (txt_rut_cliente.Text) & ";" & (txt_cod_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (comuna_cliente) & ";" & (ciudad_cliente) & ";" & (correo_cliente) & ";" & vbNewLine _
        '        & "->BOLETATotales<-" & vbNewLine _
        '        & (txt_neto.Text) & ";" & ("0") & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & vbNewLine _
        '        & "->BOLETADetalle<-")

        '        nro_linea = 0
        '        For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '            nro_linea = nro_linea + 1
        '            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
        '            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
        '            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
        '            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
        '            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
        '            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
        '            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
        '            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
        '            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
        '            'VarDescuento = VarDescuento * VarCantidad
        '            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

        '            VarPorcentaje = 0
        '            VarDescuento = 0
        '            VarValorUnitario = VarSubtotal

        '            If VarCodProducto.Length > 34 Then
        '                VarCodProducto = VarCodProducto.Substring(0, 35)
        '            End If

        '            varnombre = varnombre & " " & vartecnico

        '            If varnombre.Length > 80 Then
        '                varnombre = varnombre.Substring(0, 80)
        '            End If

        '            varnombre = VarCodProducto & " - " & varnombre & " " & vartecnico

        '            If varnombre.Length > 52 Then
        '                varnombre = varnombre.Substring(0, 51)
        '            End If

        '            VarCantidad = Replace(VarCantidad, ",", ".")
        '            VarPorcentaje = Replace(VarPorcentaje, ",", ".")

        '            strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & ("0") & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & ("0") & ";" & (VarTotal) & ";" & ("INT11") & ";" & ("UN") & ";" & ("") & ";")
        '        Next

        '        If txt_nro_orden_de_compra.Text = "0" Then
        '            txt_nro_orden_de_compra.Text = ""
        '        End If

        '        strStreamWriter.WriteLine("->BOLETADescRec<-" & vbNewLine _
        '        & ("1") & ";" & ("D") & ";" & ("Descuento") & ";" & ("$") & ";" & (txt_desc.Text) & ";" & ("0") & ";" & vbNewLine _
        '        & "->BOLETAReferencia<-" & vbNewLine _
        '        & ("1") & ";" & ("") & ";" & ("") & ";" & vbNewLine _
        '        & "->Observacion<-" & vbNewLine _
        '        & (combo_condiciones.Text) & ", " & txt_nombre_usuario.Text & ", " & mirecintoempresa & ";")

        '        strStreamWriter.Close() ' cerramos

        '    Catch ex As Exception
        '        MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
        '        strStreamWriter.Close() ' cerramos
        '    End Try
        'End If


        If Combo_venta.Text = "BOLETA" Then
            Try

                If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivos_planos)
                End If

                'If Directory.Exists("C:\Carpeta Facturacion Electronica") = False Then ' si no existe la carpeta se crea
                ' Directory.CreateDirectory("C:\Carpeta Facturacion Electronica")
                'End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                ' PathArchivo = "C:\carpeta\Archivo" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
                ' PathArchivo = "\\SERVER\Claudio Calderon R\Capeta\Archivo '" & (combo_venta.Text) & "'" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
                ' PathArchivo = "C:\Carpeta Facturacion Electronica\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual
                PathArchivo = ruta_archivos_planos & "\" & "Boleta " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

                'verificamos si existe el archivo

                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                'escribimos en el archivo
                strStreamWriter.WriteLine("->Boleta<-" & vbNewLine _
                & ("39") & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & ("3") & ";" & ("0") & ";" & ("") & ";" & ("") & ";" & ("") & ";" & (txt_rut_cliente.Text) & ";" & (txt_cod_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (comuna_cliente) & ";" & (ciudad_cliente) & ";" & (correo_cliente) & ";" & vbNewLine _
                & "->BoletaTotales<-" & vbNewLine _
                & (txt_neto.Text) & ";" & ("0") & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & vbNewLine _
                & "->BoletaDetalle<-")

                nro_linea = 0
                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    nro_linea = nro_linea + 1
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
                    'VarDescuento = VarDescuento * VarCantidad
                    VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                    VarPorcentaje = 0
                    VarDescuento = 0
                    VarValorUnitario = VarSubtotal

                    If VarCodProducto.Length > 34 Then
                        VarCodProducto = VarCodProducto.Substring(0, 35)
                    End If

                    varnombre = varnombre & " " & vartecnico

                    If varnombre.Length > 80 Then
                        varnombre = varnombre.Substring(0, 80)
                    End If

                    varnombre = VarCodProducto & " - " & varnombre & " " & vartecnico

                    If varnombre.Length > 52 Then
                        varnombre = varnombre.Substring(0, 51)
                    End If

                    VarCantidad = Replace(VarCantidad, ",", ".")
                    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & ("0") & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & ("0") & ";" & (VarTotal) & ";" & ("INT11") & ";" & ("UN") & ";" & ("") & ";")
                Next

                If txt_nro_orden_de_compra.Text = "0" Then
                    txt_nro_orden_de_compra.Text = ""
                End If

                strStreamWriter.WriteLine("->BoletaDescRec<-" & vbNewLine _
                & ("1") & ";" & ("D") & ";" & ("Descuento") & ";" & ("$") & ";" & (txt_desc.Text) & ";" & ("0") & ";" & vbNewLine _
                & "->BoletaReferencia<-" & vbNewLine _
                & ("1") & ";" & ("") & ";" & ("") & ";" & vbNewLine _
                & "->Observacion<-" & vbNewLine _
                & (combo_condiciones.Text) & ", " & txt_nombre_usuario.Text & ", " & mirecintoempresa & ";")

                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If





        If Combo_venta.Text = "BOLETA DE CREDITO" Then
            Try

                If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivos_planos)
                End If

                'If Directory.Exists("C:\Carpeta Facturacion Electronica") = False Then ' si no existe la carpeta se crea
                ' Directory.CreateDirectory("C:\Carpeta Facturacion Electronica")
                'End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                ' PathArchivo = "C:\carpeta\Archivo" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
                ' PathArchivo = "\\SERVER\Claudio Calderon R\Capeta\Archivo '" & (combo_venta.Text) & "'" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
                ' PathArchivo = "C:\Carpeta Facturacion Electronica\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual
                PathArchivo = ruta_archivos_planos & "\" & "Boleta " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

                'verificamos si existe el archivo

                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                'escribimos en el archivo
                strStreamWriter.WriteLine("->Boleta<-" & vbNewLine _
                & ("39") & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & ("3") & ";" & ("0") & ";" & ("") & ";" & ("") & ";" & ("") & ";" & (txt_rut_cliente.Text) & ";" & (txt_cod_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (comuna_cliente) & ";" & (ciudad_cliente) & ";" & (correo_cliente) & ";" & vbNewLine _
                & "->BoletaTotales<-" & vbNewLine _
                & (txt_neto.Text) & ";" & ("0") & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & vbNewLine _
                & "->BoletaDetalle<-")

                nro_linea = 0
                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    nro_linea = nro_linea + 1
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
                    'VarDescuento = VarDescuento * VarCantidad
                    VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                    VarPorcentaje = 0
                    VarDescuento = 0
                    VarValorUnitario = VarSubtotal

                    If VarCodProducto.Length > 34 Then
                        VarCodProducto = VarCodProducto.Substring(0, 35)
                    End If

                    varnombre = varnombre & " " & vartecnico

                    If varnombre.Length > 80 Then
                        varnombre = varnombre.Substring(0, 80)
                    End If

                    varnombre = VarCodProducto & " - " & varnombre & " " & vartecnico

                    If varnombre.Length > 52 Then
                        varnombre = varnombre.Substring(0, 51)
                    End If

                    VarCantidad = Replace(VarCantidad, ",", ".")
                    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & ("0") & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & ("0") & ";" & (VarTotal) & ";" & ("INT11") & ";" & ("UN") & ";" & ("") & ";")
                Next

                If txt_nro_orden_de_compra.Text = "0" Then
                    txt_nro_orden_de_compra.Text = ""
                End If

                strStreamWriter.WriteLine("->BoletaDescRec<-" & vbNewLine _
                & ("1") & ";" & ("D") & ";" & ("Descuento") & ";" & ("$") & ";" & (txt_desc.Text) & ";" & ("0") & ";" & vbNewLine _
                & "->BoletaReferencia<-" & vbNewLine _
                & ("1") & ";" & ("") & ";" & ("") & ";" & vbNewLine _
                & "->Observacion<-" & vbNewLine _
                & (combo_condiciones.Text) & ", " & txt_nombre_usuario.Text & ", " & mirecintoempresa & ";")

                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If






        If Combo_venta.Text = "FACTURA" Then
            Try
                If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivos_planos)
                End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                PathArchivo = ruta_archivos_planos & "\" & "Factura " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

                'verificamos si existe el archivo

                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

                'escribimos en el archivo
                strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
                & "33" & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & "0" & ";" & "0" & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (txt_nombre_usuario.Text) & ";" & (txt_rut_retira.Text) & ";" & (txt_nombre_retira.Text) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
                & "->Totales<-" & vbNewLine _
                & (0) & ";" & (txt_desc_total.Text) & ";" & "0" & ";" & "0" & ";" & (txt_neto.Text) & ";" & "0" & ";" & (valor_iva) & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";1;" & vbNewLine _
                & "->Detalle<-")

                nro_linea = 0

                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    nro_linea = nro_linea + 1
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

                    If VarCodProducto.Length > 34 Then
                        VarCodProducto = VarCodProducto.Substring(0, 35)
                    End If

                    If varnombre.Length > 79 Then
                        varnombre = varnombre.Substring(0, 80)
                    End If

                    varnombre = varnombre & " " & vartecnico

                    If varnombre.Length > 52 Then
                        varnombre = varnombre.Substring(0, 52)
                    End If

                    VarCantidad = Replace(VarCantidad, ",", ".")
                    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & (VarPorcentaje) & ";" & (VarDescuento) & ";" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotal) & ";" & "INT11" & ";" & "UN" & ";" & ";")

                Next

                If txt_nro_orden_de_compra.Text = "0" Then
                    txt_nro_orden_de_compra.Text = ""
                End If

                Dim orden_de_compra_referencia As String = ""

                'If txt_nro_orden_de_compra.Text <> "" Then
                orden_de_compra_referencia = "OC " & txt_nro_orden_de_compra.Text & ", FOLIO :" & txt_folio.Text & ", " & combo_condiciones.Text & ", " & mirecintoempresa
                ' End If

                strStreamWriter.WriteLine("->Referencia<-")

                Dim nro_linea_oc As Integer = 0

                If nro_801 <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & ("801") & ";" & (nro_801) & ";" & (fecha_801) & ";" & (0) & ";" & ("ORDEN DE COMPRA") & ";")
                End If

                If nro_802 <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & ("802") & ";" & (nro_802) & ";" & (fecha_802) & ";" & (0) & ";" & ("NRO DE ATENCION") & ";")
                End If

                If nro_hes <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & ("HES") & ";" & (nro_hes) & ";" & (fecha_hes) & ";" & (0) & ";" & ("HOJA DE ENTRADA") & ";")
                End If

                If nro_otro <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & (codigo_doc_otro) & ";" & (nro_otro) & ";" & (fecha_otro) & ";" & (0) & ";" & (doc_otro) & ";")
                End If

                strStreamWriter.WriteLine("->DescRec<-" & vbNewLine _
                & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & txt_desc.Text & ";" & "0" & ";" & vbNewLine _
                & "->Observacion<-" & vbNewLine _
                & txt_folio.Text & ";" & combo_condiciones.Text & ", " & mirecintoempresa & ";" & orden_de_compra_referencia & ";")
                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If

        If Combo_venta.Text = "FACTURA DE CREDITO" Then
            Try

                If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivos_planos)
                End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                PathArchivo = ruta_archivos_planos & "\" & "Factura " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

                strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
                & "33" & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & "0" & ";" & "0" & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (txt_nombre_usuario.Text) & ";" & (txt_rut_retira.Text) & ";" & (txt_nombre_retira.Text) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
                & "->Totales<-" & vbNewLine _
                & (0) & ";" & (txt_desc_total.Text) & ";" & "0" & ";" & "0" & ";" & (txt_neto.Text) & ";" & "0" & ";" & (valor_iva) & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";1;" & vbNewLine _
                & "->Detalle<-")

                nro_linea = 0

                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    nro_linea = nro_linea + 1
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

                    If VarCodProducto.Length > 34 Then
                        VarCodProducto = VarCodProducto.Substring(0, 35)
                    End If

                    If varnombre.Length > 79 Then
                        varnombre = varnombre.Substring(0, 80)
                    End If

                    varnombre = varnombre & " " & vartecnico

                    If varnombre.Length > 52 Then
                        varnombre = varnombre.Substring(0, 52)
                    End If

                    VarCantidad = Replace(VarCantidad, ",", ".")
                    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & (VarPorcentaje) & ";" & (VarDescuento) & ";" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotal) & ";" & "INT11" & ";" & "UN" & ";" & ";")
                Next

                If txt_nro_orden_de_compra.Text = "0" Then
                    txt_nro_orden_de_compra.Text = ""
                End If

                Dim orden_de_compra_referencia As String = ""

                'If txt_nro_orden_de_compra.Text <> "" Then
                ' orden_de_compra_referencia = "OC " & txt_nro_orden_de_compra.Text
                orden_de_compra_referencia = "OC " & txt_nro_orden_de_compra.Text & ", FOLIO :" & txt_folio.Text & ", " & combo_condiciones.Text & ", " & mirecintoempresa

                'End If

                'strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
                '& "1" & ";" & "801" & ";" & txt_nro_orden_de_compra.Text & ";;" & "0" & ";" & "-" & ";" & vbNewLine _


                strStreamWriter.WriteLine("->Referencia<-")
                Dim nro_linea_oc As Integer = 0

                If nro_801 <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & ("801") & ";" & (nro_801) & ";" & (fecha_801) & ";" & (0) & ";" & ("ORDEN DE COMPRA") & ";")
                End If

                If nro_802 <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & ("802") & ";" & (nro_802) & ";" & (fecha_802) & ";" & (0) & ";" & ("NRO DE ATENCION") & ";")
                End If

                If nro_hes <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & ("HES") & ";" & (nro_hes) & ";" & (fecha_hes) & ";" & (0) & ";" & ("HOJA DE ENTRADA") & ";")
                End If

                If nro_otro <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & (codigo_doc_otro) & ";" & (nro_otro) & ";" & (fecha_otro) & ";" & (0) & ";" & (doc_otro) & ";")
                End If


                strStreamWriter.WriteLine("->DescRec<-" & vbNewLine _
                & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & txt_desc.Text & ";" & "0" & ";" & vbNewLine _
                & "->Observacion<-" & vbNewLine _
                & orden_de_compra_referencia & ";" & combo_condiciones.Text & ", " & mirecintoempresa & ";" & txt_folio.Text & ";")
                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If


        If Combo_venta.Text = "GUIA" Then
            Dim IndTraslado As Integer
            If combo_condiciones.Text = "TRASLADO" Then
                IndTraslado = 0
            Else
                IndTraslado = 1
            End If

            Try
                If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivos_planos)
                End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                PathArchivo = ruta_archivos_planos & "\" & "Guia " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

                'verificamos si existe el archivo

                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

                'escribimos en el archivo
                strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
                & "52" & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & (tipo_despacho) & ";" & (IndTraslado) & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (txt_nombre_usuario.Text) & ";" & (txt_rut_retira.Text) & ";" & (txt_nombre_retira.Text) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
                & "->Totales<-" & vbNewLine _
                & (0) & ";" & (txt_desc_total.Text) & ";" & "0" & ";" & "0" & ";" & (txt_neto.Text) & ";" & "0" & ";" & (valor_iva) & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";1;" & vbNewLine _
                & "->Detalle<-")

                nro_linea = 0

                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    nro_linea = nro_linea + 1
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

                    If VarCodProducto.Length > 34 Then
                        VarCodProducto = VarCodProducto.Substring(0, 35)
                    End If

                    If varnombre.Length > 79 Then
                        varnombre = varnombre.Substring(0, 80)
                    End If

                    varnombre = varnombre & " " & vartecnico

                    If varnombre.Length > 52 Then
                        varnombre = varnombre.Substring(0, 52)
                    End If

                    VarCantidad = Replace(VarCantidad, ",", ".")
                    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & (VarPorcentaje) & ";" & (VarDescuento) & ";" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotal) & ";" & "INT11" & ";" & "UN" & ";" & ";")
                Next

                If txt_nro_orden_de_compra.Text = "0" Then
                    txt_nro_orden_de_compra.Text = ""
                End If

                Dim orden_de_compra_referencia As String = ""

                'If txt_nro_orden_de_compra.Text <> "" Then
                'orden_de_compra_referencia = "OC " & txt_nro_orden_de_compra.Text
                orden_de_compra_referencia = "OC " & txt_nro_orden_de_compra.Text & ", FOLIO :" & txt_folio.Text & ", " & combo_condiciones.Text & ", " & mirecintoempresa

                ' End If

                strStreamWriter.WriteLine("->Referencia<-")
                Dim nro_linea_oc As Integer = 0

                If nro_801 <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & ("801") & ";" & (nro_801) & ";" & (fecha_801) & ";" & (0) & ";" & ("ORDEN DE COMPRA") & ";")
                End If

                If nro_802 <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & ("802") & ";" & (nro_802) & ";" & (fecha_802) & ";" & (0) & ";" & ("NRO DE ATENCION") & ";")
                End If

                If nro_hes <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & ("HES") & ";" & (nro_hes) & ";" & (fecha_hes) & ";" & (0) & ";" & ("HOJA DE ENTRADA") & ";")
                End If

                If nro_otro <> "0" Then
                    nro_linea_oc = 1 + nro_linea_oc
                    strStreamWriter.WriteLine(nro_linea_oc & ";" & (codigo_doc_otro) & ";" & (nro_otro) & ";" & (fecha_otro) & ";" & (0) & ";" & (doc_otro) & ";")
                End If


                strStreamWriter.WriteLine("->DescRec<-" & vbNewLine _
                & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & txt_desc.Text & ";" & "0" & ";" & vbNewLine _
                & "->Observacion<-" & vbNewLine _
                & orden_de_compra_referencia & ";" & combo_condiciones.Text & ", " & mirecintoempresa & ";" & txt_folio.Text & ";")
                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If
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

        If txt_codigo.Text = "*" Then
            Combo_venta.Text = "COTIZACION"
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If txt_codigo.Text = "" Then
                Exit Sub
            End If

            If txt_codigo.Text = "*" Then
                limpiar_datos_productos()
                Combo_venta.Text = "COTIZACION"
                txt_codigo.Text = "*"

                txt_nombre_producto.ReadOnly = False
                txt_nombre_producto.BackColor = Color.White
                txt_nombre_producto.Focus()
                Exit Sub
            Else
                txt_nombre_producto.ReadOnly = True
                txt_nombre_producto.BackColor = SystemColors.Control
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

            If txt_codigo.Text <> "" And txt_nombre_producto.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MsgBoxStyle.Critical, "INFORMACION")
                txt_codigo.Focus()
            Else

                If ingreso_rapido = "NO" Then
                    txt_cantidad_agregar.Text = "1"
                    txt_precio_modificado.Focus()
                End If

                If ingreso_rapido = "SI" Then
                    txt_cantidad_agregar.Text = "1"
                    btn_agregar.PerformClick()
                    txt_codigo.Focus()
                End If
                Exit Sub
            End If
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
        Form_buscador_productos_ventas.Show()
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

    Private Sub btn_buscar_retira_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_retira.Click
        Me.Enabled = False
        conexion.Close()
        Form_buscador_clientes_retira.Show()
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

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        tipo_despacho = ""

        txt_total_millar.Text = ""
        txt_efectivo.Text = ""
        txt_vuelto.Text = ""

        calcular_totales()
        controles(True, False)
        txt_codigo.Focus()
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

        'If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
        '    condiciones()
        'End If
    End Sub

    Private Sub Combo_venta_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_venta.LostFocus
        Combo_venta.BackColor = Color.White
        'condiciones()

    End Sub

    Private Sub Combo_venta_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_venta.SelectedIndexChanged
        'condiciones()
        llenar_combo_condiciones()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        Form_call_center.Show()
    End Sub

    Private Sub PictureBox_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_imagen.Click
        Me.Enabled = False
        Form_cambiar_de_usuario.Show()
    End Sub

    Private Sub PictureBox_imagen_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox_imagen.MouseLeave
        lbl_usuario.ForeColor = Color.Black
    End Sub

    Private Sub PictureBox_imagen_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_imagen.MouseMove
        lbl_usuario.ForeColor = Color.White
    End Sub

    Sub malla_productos()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorLista As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarValorUnitario As Integer
        Dim VarTotal As Integer
        Dim porcentaje_total As String = ""
        Dim VarTipoMedidaTraspaso As String

        grilla_remplazo.Rows.Clear()

        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorLista = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
            VarTipoMedidaTraspaso = grilla_detalle_venta.Rows(i).Cells(11).Value.ToString

            grilla_remplazo.Rows.Add(VarCodProducto, varnombre, vartecnico, VarValorLista, VarCantidad, VarNeto, VarIva, VarValorUnitario, VarPorcentaje, VarDescuento, VarTotal, porcentaje_total, VarTipoMedidaTraspaso)

        Next

        grilla_detalle_venta.Rows.Clear()

        For i = 0 To grilla_remplazo.Rows.Count - 1
            VarCodProducto = grilla_remplazo.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_remplazo.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_remplazo.Rows(i).Cells(2).Value.ToString
            VarValorLista = grilla_remplazo.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_remplazo.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_remplazo.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_remplazo.Rows(i).Cells(6).Value.ToString
            VarValorUnitario = grilla_remplazo.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_remplazo.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_remplazo.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_remplazo.Rows(i).Cells(10).Value.ToString
            VarTipoMedidaTraspaso = grilla_remplazo.Rows(i).Cells(12).Value.ToString

            Dim iva As Long
            Dim neto As Long
            Dim iva_valor As String
            Dim descuento_porcentaje As String

            descuento_porcentaje = Round(((VarValorUnitario) * Val(txt_porcentaje_desc.Text)) / 100)
            VarValorUnitario = Val(VarValorUnitario) - Val(descuento_porcentaje)
            VarTotal = Val(VarValorUnitario) * (VarCantidad)

            iva_valor = valor_iva / 100 + 1
            neto = (VarTotal / iva_valor)
            iva = (neto) * valor_iva / 100
            'grilla_detalle_venta.Rows.Add(VarCodProducto, varnombre, vartecnico, VarValorUnitario, VarCantidad, neto, iva, VarValorUnitario, VarPorcentaje, VarDescuento, VarTotal, VarTipoMedidaTraspaso)
            grilla_detalle_venta.Rows.Add(VarCodProducto, varnombre, vartecnico, VarValorLista, VarCantidad, neto, iva, VarValorUnitario, VarPorcentaje, VarDescuento, VarTotal, VarTipoMedidaTraspaso)
        Next

        txt_porcentaje_desc.Text = "0"
        calcular_totales()
    End Sub

    Private Sub txt_efectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_efectivo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub calcular_vuelto()
        If grilla_detalle_venta.Rows.Count = 0 Then
            txt_vuelto.Text = "0"
            Exit Sub
        End If

        Dim total As Integer
        Dim vuelto As Long

        total = txt_total.Text

        vuelto = Val(txt_efectivo.Text) - Val(total)

        If vuelto < 0 Then
            txt_vuelto.Text = "0"
        Else
            txt_vuelto.Text = vuelto
        End If

        If txt_vuelto.Text = "" Or txt_vuelto.Text = "0" Then
            txt_vuelto.Text = "0"
        Else
            txt_vuelto.Text = Format(Int(txt_vuelto.Text), "###,###,###")
        End If
    End Sub

    Private Sub txt_efectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_efectivo.TextChanged
        calcular_vuelto()
    End Sub

    Private Sub txt_efectivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_efectivo.GotFocus
        txt_efectivo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_efectivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_efectivo.LostFocus
        txt_efectivo.BackColor = Color.White
    End Sub

    Sub ticket_cambio()
        With Pd.PrinterSettings
            .PrinterName = impresora_ticket_cotizaciones
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

    Private Function ReturnDataSetTicketInterno() As DataSet
        'Dim dt As New DataTable
        'Dim dr As DataRow
        'Dim ds As New DataSet

        'dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        'dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("nro_cotizacion", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha_cotizacion", GetType(String)))
        'dt.Columns.Add(New DataColumn("nombre_vendedor", GetType(String)))
        'dt.Columns.Add(New DataColumn("telefono_vendedor", GetType(String)))
        'dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        'dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        'dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("total", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("numero_tecnico", GetType(String)))
        'dt.Columns.Add(New DataColumn("subtotal_final", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("descuento_final", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("total_final", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("forma_de_pago", GetType(String)))
        'dt.Columns.Add(New DataColumn("precio", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("tipo_doc", GetType(String)))
        'dt.Columns.Add(New DataColumn("valido", GetType(String)))
        'dt.Columns.Add(New DataColumn("precio_detalle", GetType(String)))

        'Dim tipo_doc As String
        'Dim valido As String

        'If combo_venta.Text = "COTIZACION" Then
        '    tipo_doc = "COTIZACION"
        '    valido = "COTIZACION VALIDA POR 2 DIAS"
        'Else
        '    tipo_doc = "DETALLE DE " & combo_venta.Text
        '    valido = " "
        'End If

        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As String
        'Dim VarDescuento As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarPorcentaje As Integer
        'Dim VarSubtotal As Integer
        'Dim VarTotal As Integer
        'Dim condicion_cotizacion As String
        'Dim fecha_cotizacion As String
        'Dim desc_cotizacion As String
        'Dim nro_cotizacion As String
        'Dim subtotal_cotizacion As String
        'Dim total_cotizacion As String
        'Dim vendedor_cotizacion As String

        'Dim descuento_detalle As String
        'Dim precio_detalle As String

        'condicion_cotizacion = combo_condiciones.Text
        'fecha_cotizacion = Form_menu_principal.dtp_fecha.Text
        'desc_cotizacion = txt_desc.Text
        'nro_cotizacion = txt_factura.Text
        'total_cotizacion = txt_total.Text
        'subtotal_cotizacion = txt_sub_total.Text
        'vendedor_cotizacion = minombre

        'For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '    VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
        '    varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
        '    vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
        '    VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
        '    VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
        '    VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
        '    VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
        '    VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
        '    VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '    VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
        '    VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

        '    precio_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
        '    descuento_detalle = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
        '    descuento_detalle = Val(descuento_detalle) / VarCantidad

        '    precio_detalle = Val(precio_detalle - descuento_detalle)

        '    If descuento_detalle = "" Or descuento_detalle = "0" Then
        '        descuento_detalle = "0"
        '    Else
        '        descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
        '    End If

        '    If precio_detalle = "" Or precio_detalle = "0" Then
        '        precio_detalle = "0"
        '    Else
        '        precio_detalle = Format(Int(precio_detalle), "###,###,###")
        '    End If

        '    dr = dt.NewRow()

        '    Try
        '        dr("Imagen") = Imagen_ticket
        '    Catch
        '    End Try
        '    dr("nombre_empresa") = minombreempresa
        '    dr("giro_empresa") = migiroempresa
        '    dr("direccion_empresa") = midireccionempresa
        '    dr("comuna_empresa") = micomunaempresa
        '    dr("telefono_empresa") = mitelefonoempresa
        '    dr("correo_empresa") = micorreoempresa
        '    dr("rut_empresa") = mirutempresa
        '    dr("nro_cotizacion") = nro_cotizacion
        '    dr("fecha_cotizacion") = fecha_cotizacion
        '    dr("nombre_vendedor") = vendedor_cotizacion
        '    dr("telefono_vendedor") = mitelefono
        '    dr("codigo") = VarCodProducto
        '    dr("descripcion") = varnombre
        '    dr("cantidad") = " X " & VarCantidad & " ="
        '    dr("total") = VarTotal
        '    dr("numero_tecnico") = vartecnico
        '    dr("subtotal_final") = subtotal_cotizacion
        '    dr("descuento_final") = desc_cotizacion
        '    dr("total_final") = total_cotizacion
        '    dr("forma_de_pago") = condicion_cotizacion

        '    'If VarPorcentaje <> "0" Then
        '    '    dr("precio_detalle") = precio_detalle & " - " & descuento_detalle & " (" & VarPorcentaje & "%)"
        '    'Else
        '    '    dr("precio_detalle") = precio_detalle
        '    'End If

        '    'dr("precio_detalle") = Val(precio_detalle - descuento_detalle)
        '    dr("precio_detalle") = precio_detalle

        '    dr("tipo_doc") = tipo_doc
        '    dr("valido") = valido
        '    dt.Rows.Add(dr)
        'Next

        'ds.Tables.Add(dt)
        'ds.Tables(0).TableName = "CotizacionTicket"
        'Dim iDS As New dsCotizacionTicket
        'iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        'Return iDS
        Return Nothing
    End Function

    Private Sub PrintDocument_cotizacion_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument_cotizacion.PrintPage
        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        'If impreso = 0 Then
        '    Dim mPrintBitMap As Bitmap = Form_menu_principal.PictureBox_ticket.Image
        '    mPrintBitMap.RotateFlip(RotateFlipType.Rotate180FlipNone)
        '    ' Copy the form image into a bitmap.    
        '    mPrintBitMap = New Bitmap(Form_menu_principal.PictureBox_ticket.Width, Form_menu_principal.PictureBox_ticket.Height)
        '    Dim lRect As System.Drawing.Rectangle
        '    lRect.Width = Form_menu_principal.PictureBox_ticket.Width
        '    lRect.Height = Form_menu_principal.PictureBox_ticket.Height
        '    Me.DrawToBitmap(mPrintBitMap, lRect)
        'End If

        'impreso = 1

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

        e.Graphics.DrawString("COTIZACION", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NUMERO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 245)
        e.Graphics.DrawString(txt_factura.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 260)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 260)

        e.Graphics.DrawString("VENDEDOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 275)
        e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 275)

        e.Graphics.DrawString("TELEFONO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 290)
        e.Graphics.DrawString(mitelefono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 290)

        e.Graphics.DrawString("CONDICION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 305)
        e.Graphics.DrawString(combo_condiciones.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 305)

        e.Graphics.DrawString("CODIGO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString("DESCRIPCION", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 335)
        e.Graphics.DrawString("CANT.", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 335)
        e.Graphics.DrawString("TOTAL", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 265, margen_superior + 335, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 350, margen_izquierdo + 270, margen_superior + 350)

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
        Dim descuento_detalle As String
        Dim precio_detalle As String
        Dim precio_total As String
        Dim precio_lista As String

        Dim multiplicador_lineas As Integer = 45
        Dim numero_lineas As Integer = 0

        For i = 0 To grilla_detalle_venta.Rows.Count - 1

            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
            precio_lista = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString

            'precio_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            precio_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            descuento_detalle = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString

            'descuento_detalle = Val(descuento_detalle) / VarCantidad
            descuento_detalle = Val(descuento_detalle) / VarCantidad

            'precio_detalle = Val(precio_detalle - descuento_detalle)
            precio_detalle = Val(VarTotal / VarCantidad)

            precio_total = VarTotal
            If descuento_detalle = "" Or descuento_detalle = "0" Then
                descuento_detalle = "0"
            Else
                descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
            End If

            If precio_detalle = "" Or precio_detalle = "0" Then
                precio_detalle = "0"
            Else
                precio_detalle = Format(Int(precio_detalle), "###,###,###")
            End If

            If precio_total = "" Or precio_total = "0" Then
                precio_total = "0"
            Else
                precio_total = Format(Int(precio_total), "###,###,###")
            End If
            'If detalle_referencia.Length > 23 Then
            '    detalle_referencia = detalle_referencia.Substring(0, 23)
            'End If

            e.Graphics.DrawString(VarCodProducto, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(varnombre, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(vartecnico, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 370 + (i * multiplicador_lineas))
            'e.Graphics.DrawString(precio_detalle, Font_texto_detalle, Brushes.Black, margen_izquierdo + 285, margen_superior + 405 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_detalle & " X " & VarCantidad, Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 385 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_total, Font_texto_detalle, Brushes.Black, margen_izquierdo + 265, margen_superior + 385 + (i * multiplicador_lineas), format1)
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + (i * multiplicador_lineas) + 398, margen_izquierdo + 270, margen_superior + (i * multiplicador_lineas) + 398)
        Next

        numero_lineas = ((grilla_detalle_venta.Rows.Count - 1) * multiplicador_lineas)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + numero_lineas + 398, margen_izquierdo + 270, margen_superior + numero_lineas + 398)

        If mirutempresa <> "87686300-6" Then
            e.Graphics.DrawString("SUBTOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 420)
            e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 420)
            e.Graphics.DrawString(txt_sub_total_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 420, format1)

            e.Graphics.DrawString("DESCUENTO", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 435)
            e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 435)
            e.Graphics.DrawString(txt_desc_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 435, format1)

            e.Graphics.DrawString("TOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 450)
            e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 450)
            e.Graphics.DrawString(txt_total_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 450, format1)

            e.Graphics.DrawString("COTIZACION VALIDA POR " & validez_cotizacion & " DIAS", Font_texto_totales, Brushes.Black, margen_izquierdo + 40, margen_superior + numero_lineas + 480)
            e.Graphics.DrawString("-", Font_texto_totales, Brushes.Black, margen_izquierdo + 140, margen_superior + numero_lineas + 530)
        Else
            'e.Graphics.DrawString("SUBTOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 420)
            'e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 420)
            'e.Graphics.DrawString(txt_sub_total_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 420, format1)

            'e.Graphics.DrawString("DESCUENTO", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 435)
            'e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 435)
            'e.Graphics.DrawString(txt_desc_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 435, format1)

            e.Graphics.DrawString("TOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 420)
            e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 420)
            e.Graphics.DrawString(txt_total_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 420, format1)

            e.Graphics.DrawString("DESCUENTOS YA APLICADOS", Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 435, format1)
            e.Graphics.DrawString("IVA INCLUIDO", Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 450, format1)

            e.Graphics.DrawString("COTIZACION VALIDA POR " & validez_cotizacion & " DIAS", Font_texto_totales, Brushes.Black, margen_izquierdo + 35, margen_superior + numero_lineas + 495)
            e.Graphics.DrawString("-", Font_texto_totales, Brushes.Black, margen_izquierdo + 140, margen_superior + numero_lineas + 530)
        End If
        'Dim rect_validez_cotizacion As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 450, margen_izquierdo + 250, margen_superior + numero_lineas + 15)
        'e.Graphics.DrawString(validez_cotizacion, Font_texto_totales, Brushes.Gray, rect_validez_cotizacion, stringFormat)

        'Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 540, margen_izquierdo + 250, margen_superior + numero_lineas + 15)
        'e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub

    Private Sub PrintDocument_ticket_interno_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument_ticket_interno.PrintPage
        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        'If impreso = 0 Then
        '    Dim mPrintBitMap As Bitmap = Form_menu_principal.PictureBox_ticket.Image
        '    mPrintBitMap.RotateFlip(RotateFlipType.Rotate180FlipNone)
        '    ' Copy the form image into a bitmap.    
        '    mPrintBitMap = New Bitmap(Form_menu_principal.PictureBox_ticket.Width, Form_menu_principal.PictureBox_ticket.Height)
        '    Dim lRect As System.Drawing.Rectangle
        '    lRect.Width = Form_menu_principal.PictureBox_ticket.Width
        '    lRect.Height = Form_menu_principal.PictureBox_ticket.Height
        '    Me.DrawToBitmap(mPrintBitMap, lRect)
        'End If

        'impreso = 1

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

        e.Graphics.DrawString("DETALLE DE " & Combo_venta.Text, Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NUMERO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 245)
        e.Graphics.DrawString(txt_factura.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 260)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 260)

        e.Graphics.DrawString("VENDEDOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 275)
        e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 275)

        e.Graphics.DrawString("TELEFONO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 290)
        e.Graphics.DrawString(mitelefono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 290)

        e.Graphics.DrawString("CONDICION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 305)
        e.Graphics.DrawString(combo_condiciones.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 305)

        e.Graphics.DrawString("CODIGO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString("DESCRIPCION", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 335)
        e.Graphics.DrawString("CANT.", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 335)
        e.Graphics.DrawString("TOTAL", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 265, margen_superior + 335, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 350, margen_izquierdo + 270, margen_superior + 350)

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
        Dim descuento_detalle As String
        Dim precio_detalle As String
        Dim precio_total As String

        Dim multiplicador_lineas As Integer = 45
        Dim numero_lineas As Integer = 0

        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            precio_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            descuento_detalle = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            descuento_detalle = Val(descuento_detalle) / VarCantidad

            precio_detalle = Val(precio_detalle - descuento_detalle)
            precio_total = VarTotal
            If descuento_detalle = "" Or descuento_detalle = "0" Then
                descuento_detalle = "0"
            Else
                descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
            End If

            If precio_detalle = "" Or precio_detalle = "0" Then
                precio_detalle = "0"
            Else
                precio_detalle = Format(Int(precio_detalle), "###,###,###")
            End If

            If precio_total = "" Or precio_total = "0" Then
                precio_total = "0"
            Else
                precio_total = Format(Int(precio_total), "###,###,###")
            End If
            'If detalle_referencia.Length > 23 Then
            '    detalle_referencia = detalle_referencia.Substring(0, 23)
            'End If

            e.Graphics.DrawString(VarCodProducto, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(varnombre, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(vartecnico, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 370 + (i * multiplicador_lineas))
            'e.Graphics.DrawString(precio_detalle, Font_texto_detalle, Brushes.Black, margen_izquierdo + 285, margen_superior + 405 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_detalle & " X " & VarCantidad, Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 385 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_total, Font_texto_detalle, Brushes.Black, margen_izquierdo + 265, margen_superior + 385 + (i * multiplicador_lineas), format1)
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + (i * multiplicador_lineas) + 398, margen_izquierdo + 270, margen_superior + (i * multiplicador_lineas) + 398)
        Next

        numero_lineas = ((grilla_detalle_venta.Rows.Count - 1) * multiplicador_lineas)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + numero_lineas + 398, margen_izquierdo + 270, margen_superior + numero_lineas + 398)

        e.Graphics.DrawString("SUBTOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 420)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 420)
        e.Graphics.DrawString(txt_sub_total_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 420, format1)

        e.Graphics.DrawString("DESCUENTO", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 435)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 435)
        e.Graphics.DrawString(txt_desc_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 435, format1)

        e.Graphics.DrawString("TOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 450)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 450)
        e.Graphics.DrawString(txt_total_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 450, format1)

        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 490, margen_izquierdo + 250, margen_superior + numero_lineas + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub

    Private Sub Print_garantia_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Print_garantia.PrintPage

        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim stringFormat_left As New StringFormat()
        stringFormat_left.Alignment = StringAlignment.Near
        stringFormat_left.LineAlignment = StringAlignment.Near

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 30, margen_izquierdo + 270, margen_superior + 15)


        e.Graphics.DrawString("GARANTIA", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)


        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 45, margen_izquierdo + 270, margen_superior + 110)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 270, margen_superior + 100)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 250, margen_izquierdo + 270, margen_superior + 80)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 340, margen_izquierdo + 270, margen_superior + 30)

        Dim texto_garantia_1 As String
        Dim texto_garantia_2 As String
        Dim texto_garantia_3 As String
        Dim texto_garantia_4 As String

        texto_garantia_1 = "LA GARANTÍA ES EFECTIVA DENTRO DE UN PLAZO DE 90 DÍAS SIGUIENTES DE LA FECHA DE LA COMPRA, PARA HACER VALER SU DERECHO DEBE PRESENTAR LA BOLETA ORIGINAL, EL CAMBIO SE HARÁ SIEMPRE QUE EL PRODUCTO VENGA EN SU EMBALAJE ORIGINAL SIN USO."
        texto_garantia_2 = "LA GARANTÍA CUBRE DEFECTOS DE FÁBRICA DE LOS PRODUCTOS O FALLA DE SUS MATERIALES. LA GARANTÍA NO CUBRE DETERIOROS CAUSADOS POR EL MAL USO DEL PRODUCTO, COMO TAMPOCO ABUSOS A LOS MATERIALES DEL MISMO. TODA MERCADERÍA CON POSIBLE FALLA SERÁ RECIBIDA Y ENVIADA A EVALUACIÓN TÉCNICA, OBTENIENDO UNA RESPUESTA DESPUÉS DE 7 DÍAS HÁBILES."
        texto_garantia_3 = "LA GARANTÍA NO CUBRE PELADURAS, MAL CALCE, DAÑOS PROPIOS DEL USO, DESGASTE DE PLANTA NI TAPILLAS, ZAPATILLAS O CALZADOS LAVADOS, LUCES O ACCESORIOS."
        texto_garantia_4 = "LOS CAMBIOS SE EFECTÚAN DE LUNES A JUEVES SOLO CON LA BOLETA Y NO SE REALIZA DEVOLUCIÓN DEL DINERO."

        e.Graphics.DrawString(texto_garantia_1, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(texto_garantia_2, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(texto_garantia_3, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(texto_garantia_4, Font_texto_empresa, Brushes.Black, rect4, stringFormat)

        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + 530, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub

    Private Sub txt_cargar_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_cargar.KeyUp
        If e.KeyCode = Keys.F9 Then
            ' txt_nro_orden_de_compra.Focus()
        End If
    End Sub

    Private Sub txt_rut_cliente_LostFocus(sender As Object, e As EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub

    Private Sub pd_ticket_de_cambio_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pd_ticket_de_cambio.PrintPage

        Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        Dim Font2 As New Font("arial", 10, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center
        Dim stringFormatJustificado As New StringFormat()
        stringFormatJustificado.Alignment = StringAlignment.Center
        stringFormatJustificado.LineAlignment = StringAlignment.Center

        Dim rect7 As New Rectangle(10, 0, 270, 15)
        Dim rect8 As New Rectangle(10, 90, 270, 50)
        Dim rect9 As New Rectangle(10, 240, 270, 50)
        Dim rect10 As New Rectangle(10, 125, 270, 150)

        e.Graphics.DrawString(minombreempresa, Font2, Brushes.Black, rect7, stringFormat)
        e.Graphics.DrawString("N. DOC.", Font4, Brushes.Black, 0, 30)
        e.Graphics.DrawString(":", Font4, Brushes.Black, 73, 30)

        Dim codigo As String = 0
        Dim valor As Integer
        codigo = txt_factura.Text
        Dim nro_ticket As String
        valor = codigo
        nro_ticket = String.Format("{0:000000}", valor)

        Dim mifecha As Date
        Dim fecha_doc As String
        mifecha = Form_menu_principal.dtp_fecha.Text
        fecha_doc = mifecha.ToString("dd-MM-yyy")

        e.Graphics.DrawString(Combo_venta.Text & ", " & txt_factura.Text, Font4, Brushes.Black, 80, 30)
        e.Graphics.DrawString("FECHA", Font4, Brushes.Black, 0, 45)
        e.Graphics.DrawString(":", Font4, Brushes.Black, 73, 45)
        e.Graphics.DrawString(fecha_doc, Font4, Brushes.Black, 80, 45)
        e.Graphics.DrawString("VENDEDOR", Font4, Brushes.Black, 0, 60)
        e.Graphics.DrawString(":", Font4, Brushes.Black, 73, 60)
        e.Graphics.DrawString(txt_nombre_usuario.Text, Font4, Brushes.Black, 80, 60)
        e.Graphics.DrawString("*" & (nro_ticket) & "*", New Font("C39HrP36DlTt", 34), Brushes.Black, rect8, stringFormat)
        e.Graphics.DrawString("TICKET PARA CAMBIO", Font2, Brushes.Black, rect9, stringFormat)
        e.Graphics.DrawString("SI QUIERES CAMBIAR EL PRODUCTO, PUEDE HACERLO DENTRO DE LOS 30 DIAS SIGUIENTES A LA FECHA EN QUE HA SIDO COMPRADO, EL PRODUCTO DEBE SER CAMBIADO SIN USO, CON SUS SELLOS Y EMBALAJES ORIGINALES, EN PERFECTO ESTADO.", Font4, Brushes.Black, rect10, stringFormatJustificado)
        e.Graphics.DrawString("-", Font3, Brushes.Gray, 150, 290)
    End Sub

    Private Sub btn_venta_1_GotFocus(sender As Object, e As EventArgs) Handles btn_venta_1.GotFocus
        btn_venta_1.ForeColor = Color.White
        btn_venta_2.ForeColor = Color.Black
        btn_venta_3.ForeColor = Color.Black
        'btn_accesos_directos.ForeColor = Color.Black

        CambiaColorFondo(btn_venta_1, mirutempresa)
        'btn_venta_1.BackColor = Color.FromArgb(77, 96, 130)
        btn_venta_2.BackColor = SystemColors.Control
        btn_venta_3.BackColor = SystemColors.Control
        'btn_accesos_directos.BackColor = SystemColors.Control
    End Sub

    Private Sub btn_venta_2_GotFocus(sender As Object, e As EventArgs) Handles btn_venta_2.GotFocus
        btn_venta_1.ForeColor = Color.Black
        btn_venta_2.ForeColor = Color.White
        btn_venta_3.ForeColor = Color.Black
        'btn_accesos_directos.ForeColor = Color.Black

        btn_venta_1.BackColor = SystemColors.Control
        CambiaColorFondo(btn_venta_2, mirutempresa)
        'btn_venta_2.BackColor = Color.FromArgb(24, 49, 106)
        btn_venta_3.BackColor = SystemColors.Control
        ' btn_accesos_directos.BackColor = SystemColors.Control
    End Sub

    Private Sub btn_venta_3_GotFocus(sender As Object, e As EventArgs) Handles btn_venta_3.GotFocus

        btn_venta_1.ForeColor = Color.Black
        btn_venta_2.ForeColor = Color.Black
        btn_venta_3.ForeColor = Color.White
        'btn_accesos_directos.ForeColor = Color.Black

        btn_venta_1.BackColor = SystemColors.Control
        btn_venta_2.BackColor = SystemColors.Control
        CambiaColorFondo(btn_venta_3, mirutempresa)
        'btn_accesos_directos.BackColor = SystemColors.Control
    End Sub

    Private Sub btn_accesos_directos_GotFocus(sender As Object, e As EventArgs) Handles btn_accesos_directos.GotFocus



    End Sub

    Private Sub btn_accesos_directos_LostFocus(sender As Object, e As EventArgs) Handles btn_accesos_directos.LostFocus

    End Sub

    Private Sub btn_accesos_directos_MouseLeave(sender As Object, e As EventArgs) Handles btn_accesos_directos.MouseLeave
        btn_accesos_directos.ForeColor = Color.Black
        btn_accesos_directos.BackColor = SystemColors.Control
    End Sub

    Private Sub btn_accesos_directos_MouseMove(sender As Object, e As MouseEventArgs) Handles btn_accesos_directos.MouseMove
        btn_accesos_directos.ForeColor = Color.White
        CambiaColorFondo(btn_accesos_directos, mirutempresa)
    End Sub

    Private Sub btn_venta_1_Click(sender As Object, e As EventArgs) Handles btn_venta_1.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        grabar_documento_temporal()
        nro_venta = 1
        limpiar()
        cargar_documento_temporal()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_venta_2_Click(sender As Object, e As EventArgs) Handles btn_venta_2.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        grabar_documento_temporal()
        nro_venta = 2
        limpiar()
        cargar_documento_temporal()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_venta_3_Click(sender As Object, e As EventArgs) Handles btn_venta_3.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        grabar_documento_temporal()
        nro_venta = 3
        limpiar()
        cargar_documento_temporal()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub lbl_usuario_Click(sender As Object, e As EventArgs) Handles lbl_usuario.Click
        Me.Enabled = False
        Form_cambiar_de_usuario.Show()
    End Sub

    Private Sub lbl_usuario_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_usuario.MouseLeave
        'DESPUES DEL FOCO
        lbl_usuario.ForeColor = Color.Black
    End Sub

    Private Sub lbl_usuario_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_usuario.MouseMove
        'EN EL FOCO
        lbl_usuario.ForeColor = Color.White
    End Sub


    Private Sub Pd_Ticket_Interno_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd_Ticket_Interno.PrintPage

        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        'If impreso = 0 Then
        '    Dim mPrintBitMap As Bitmap = Form_menu_principal.PictureBox_ticket.Image
        '    mPrintBitMap.RotateFlip(RotateFlipType.Rotate180FlipNone)
        '    ' Copy the form image into a bitmap.    
        '    mPrintBitMap = New Bitmap(Form_menu_principal.PictureBox_ticket.Width, Form_menu_principal.PictureBox_ticket.Height)
        '    Dim lRect As System.Drawing.Rectangle
        '    lRect.Width = Form_menu_principal.PictureBox_ticket.Width
        '    lRect.Height = Form_menu_principal.PictureBox_ticket.Height
        '    Me.DrawToBitmap(mPrintBitMap, lRect)
        'End If

        'impreso = 1

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

        e.Graphics.DrawString("DETALLE DE " & Combo_venta.Text, Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NUMERO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 245)
        e.Graphics.DrawString(txt_factura.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 260)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 260)

        e.Graphics.DrawString("VENDEDOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 275)
        e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 275)

        e.Graphics.DrawString("TELEFONO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 290)
        e.Graphics.DrawString(mitelefono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 290)

        e.Graphics.DrawString("CONDICION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 305)
        e.Graphics.DrawString(combo_condiciones.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 305)

        e.Graphics.DrawString("CODIGO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString("DESCRIPCION", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 335)
        e.Graphics.DrawString("CANT.", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 335)
        e.Graphics.DrawString("TOTAL", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 265, margen_superior + 335, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 350, margen_izquierdo + 270, margen_superior + 350)

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
        Dim descuento_detalle As String
        Dim precio_detalle As String
        Dim precio_total As String

        Dim multiplicador_lineas As Integer = 45
        Dim numero_lineas As Integer = 0

        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            precio_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            descuento_detalle = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            descuento_detalle = Val(descuento_detalle) / VarCantidad

            precio_detalle = Val(precio_detalle - descuento_detalle)
            precio_total = VarTotal
            If descuento_detalle = "" Or descuento_detalle = "0" Then
                descuento_detalle = "0"
            Else
                descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
            End If

            If precio_detalle = "" Or precio_detalle = "0" Then
                precio_detalle = "0"
            Else
                precio_detalle = Format(Int(precio_detalle), "###,###,###")
            End If

            If precio_total = "" Or precio_total = "0" Then
                precio_total = "0"
            Else
                precio_total = Format(Int(precio_total), "###,###,###")
            End If
            'If detalle_referencia.Length > 23 Then
            '    detalle_referencia = detalle_referencia.Substring(0, 23)
            'End If

            e.Graphics.DrawString(VarCodProducto, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(varnombre, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(vartecnico, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 370 + (i * multiplicador_lineas))
            'e.Graphics.DrawString(precio_detalle, Font_texto_detalle, Brushes.Black, margen_izquierdo + 285, margen_superior + 405 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_detalle & " X " & VarCantidad, Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 385 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_total, Font_texto_detalle, Brushes.Black, margen_izquierdo + 265, margen_superior + 385 + (i * multiplicador_lineas), format1)
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + (i * multiplicador_lineas) + 398, margen_izquierdo + 270, margen_superior + (i * multiplicador_lineas) + 398)
        Next

        numero_lineas = ((grilla_detalle_venta.Rows.Count - 1) * multiplicador_lineas)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + numero_lineas + 398, margen_izquierdo + 270, margen_superior + numero_lineas + 398)

        e.Graphics.DrawString("SUBTOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 420)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 420)
        e.Graphics.DrawString(txt_sub_total_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 420, format1)

        e.Graphics.DrawString("DESCUENTO", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 435)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 435)
        e.Graphics.DrawString(txt_desc_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 435, format1)

        e.Graphics.DrawString("TOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 105, margen_superior + numero_lineas + 450)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 190, margen_superior + numero_lineas + 450)
        e.Graphics.DrawString(txt_total_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 265, margen_superior + numero_lineas + 450, format1)

        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 490, margen_izquierdo + 250, margen_superior + numero_lineas + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)

    End Sub

    Private Sub btn_pdf_Click(sender As Object, e As EventArgs) Handles btn_pdf.Click

        If txt_porcentaje_desc.Text = "" Then
            txt_porcentaje_desc.Text = "0"
        End If

        Combo_venta.Text = "COTIZACION"


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


        If mirutempresa = "87686300-6" Then

            If combo_condiciones.Text = "PENDIENTE" Then
                If txt_rut_cliente.Text = "" Then
                    MsgBox("CAMPO CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_rut_cliente.Focus()
                    Exit Sub
                End If
            End If

            If combo_condiciones.Text = "PENDIENTE" Then
                If txt_nombre_cliente.Text = "" Then
                    MsgBox("CAMPO CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_rut_cliente.Focus()
                    Exit Sub
                End If
            End If
        End If

        Dim valormensaje As Integer

        valormensaje = MsgBox("¿ESTA SEGURO DE GENERAR UNA COTIZACION EN FORMATO PDF?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")

        If valormensaje = vbYes Then

            If txt_cod_cliente.Text = "" Then
                txt_rut_cliente.Text = "-"
                txt_cod_cliente.Text = "0"
            End If

            If mirutempresa = "87686300-6" Then
                malla_productos()
            End If

            Form_guardar_como_pdf.Show()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'nro_801 = ""
        'nro_802 = ""
        'nro_hes = ""
        'nro_otro = ""
        'doc_otro = ""

        'fecha_801 = ""
        'fecha_802 = ""
        'fecha_hes = ""
        'fecha_otro = ""

        Dim ventana_venta_orden_de_compra As New Form_venta_orden_de_compra()
        ventana_venta_orden_de_compra.ShowDialog()
    End Sub

    Private Sub txt_nro_orden_de_compra_TextChanged(sender As Object, e As EventArgs) Handles txt_nro_orden_de_compra.TextChanged

    End Sub

    Private Sub txt_cargar_TextChanged(sender As Object, e As EventArgs) Handles txt_cargar.TextChanged

    End Sub

    Private Sub txt_precio_modificado_TextChanged(sender As Object, e As EventArgs) Handles txt_precio_modificado.TextChanged

    End Sub

    Private Sub grilla_detalle_venta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla_detalle_venta.CellContentClick

    End Sub

    Private Sub btn_accesos_directos_Click(sender As Object, e As EventArgs) Handles btn_accesos_directos.Click

        If lbl_f1.Visible = True Then
            lbl_f1.Visible = False
            lbl_f11.Visible = False
            lbl_f12.Visible = False
            lbl_f2.Visible = False
            lbl_f5_clientes.Visible = False
            lbl_f5_retira.Visible = False
            lbl_f7.Visible = False
            lbl_f9.Visible = False
        Else
            lbl_f1.Visible = True
            lbl_f11.Visible = True
            lbl_f12.Visible = True
            lbl_f2.Visible = True
            lbl_f5_clientes.Visible = True
            lbl_f5_retira.Visible = True
            lbl_f7.Visible = True
            lbl_f9.Visible = True
        End If
    End Sub

    Private Sub txt_codigo_TextChanged(sender As Object, e As EventArgs) Handles txt_codigo.TextChanged

    End Sub


End Class