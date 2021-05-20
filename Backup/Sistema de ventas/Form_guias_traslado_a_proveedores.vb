Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Math
Public Class Form_guias_traslado_a_proveedores
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
    Private Sub Form_guias_traslado_a_proveedores_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        grabar_documento_temporal()
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_guias_traslado_a_proveedores_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

        If e.KeyCode = Keys.F6 Then
            txt_rut_retira.Focus()
        End If

        If e.KeyCode = Keys.F12 Then
            If vuelto = "NO" Then
                btn_grabar.PerformClick()
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
            form_Ingreso.Show()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_guias_traslado_a_proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grabar_documento_temporal()
        Form_menu_principal.WindowState = FormWindowState.Maximized
        limpiar()
        cargar_logo()
        valores()
        controles(False, True)
        mostrar_datos_login()
        cargar_foto()
        cargar_documento_temporal()
        txt_codigo.Focus()
        Timer_ventas.Start()
        Me.btn_nueva.PerformClick()
        'TextBox1.Text = ActiveControl.Name
    End Sub

    Sub mostrar_datos_login()
        lbl_usuario.Text = minombre & vbCrLf & miarea
        Me.txt_nombre_usuario.Text = minombre
        Me.txt_rut_vendedor.Text = miusuario
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
        txt_giro_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_telefono.Text = ""
    End Sub

    Sub limpiar_datos_clientes_retira()
        txt_rut_retira.Text = ""
        txt_nombre_retira.Text = ""
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
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

    Sub mostrar_datos_clientes()
        'conexion.Close()
        'If txt_rut_cliente.Text <> "" Then
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    SC.Connection = conexion
        '    SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut_cliente.Text) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    If DS.Tables(DT.TableName).Rows.Count = 1 Then
        '        txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
        '        txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
        '        txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
        '        txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
        '        txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
        '        txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
        '        txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
        '        txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
        '        conexion.Close()
        '        btn_mensaje_cliente.PerformClick()
        '        Exit Sub
        '    ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
        '        conexion.Close()
        '        Form_seleccionar_cuenta.Show()
        '        Me.Enabled = False
        '        Exit Sub
        '    ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
        '        MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
        '        txt_rut_cliente.Focus()
        '        conexion.Close()
        '    End If
        'End If

        If txt_rut_cliente.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_proveedor")
                'txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_proveedor")
                txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_proveedor")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_proveedor")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_proveedor")

                txt_rut_cliente.Focus()
            Else
                '     MsgBox("RUT NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
            End If
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
                txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
                txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
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
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                If txt_rut_cliente.Text = "" Then
                    txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")

                    If txt_codigo.Text = "000038" Then
                        conexion.Close()
                        Exit Sub
                    End If

                    If txt_codigo.Text = "000380" Then
                        conexion.Close()
                        Exit Sub
                    End If




                    mostrar_datos_clientes()
                End If
            End If
            conexion.Close()
        End If

        ' End If
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
        txt_codigo.Enabled = a
        txt_rut_cliente.Enabled = a
        btn_grabar.Enabled = a
        btn_limpiar.Enabled = a
        btn_nueva.Enabled = b
        btn_buscar_clientes.Enabled = a
        'btn_buscar_productos.Enabled = a
        btn_buscar_retira.Enabled = a
        txt_cantidad_agregar.Enabled = a
        txt_codigo.Enabled = a
        txt_rut_cliente.Enabled = a
        txt_nombre_producto.Enabled = a
        txt_costo.Enabled = a
        GroupBox_clientes.Enabled = a
        GroupBox_producto.Enabled = a
        GroupBox_totales.Enabled = a
        grilla_detalle_venta.Enabled = a
        txt_rut_retira.Enabled = a
        If txt_costo.Enabled = True Then
            txt_costo.BackColor = Color.White
        Else
            txt_costo.BackColor = SystemColors.Control
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

        'If txt_rut_cliente.Enabled = True Then
        '    txt_rut_cliente.ReadOnly = True
        'Else
        '    txt_rut_cliente.ReadOnly = False
        'End If

        If txt_nombre_cliente.Enabled = True Then
            txt_nombre_cliente.ReadOnly = False
        End If

        If txt_direccion_cliente.Enabled = True Then
            txt_direccion_cliente.ReadOnly = False
        End If

        If txt_comuna_cliente.Enabled = True Then
            txt_comuna_cliente.ReadOnly = False
        End If

        If txt_telefono.Enabled = True Then
            txt_telefono.ReadOnly = False
        End If

        If txt_correo_cliente.Enabled = True Then
            txt_correo_cliente.ReadOnly = False
        End If

        If txt_giro_cliente.Enabled = True Then
            txt_giro_cliente.ReadOnly = False
        End If
    End Sub

    Sub limpiar()
        Combo_motivo.Text = ""
        Combo_solicitud.Text = ""
        txt_proveedor.Text = ""
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
        txt_costo.Text = ""
        txt_costo.Text = ""
        txt_sub_total.Text = ""
        txt_factor.Text = ""
        txt_rut_cliente.Text = ""
        txt_codigo.Text = ""
        txt_desc.Text = ""
        txt_total.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_nombre_retira.Text = ""
        txt_rut_retira.Text = ""
        txt_rut_cliente.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_giro_cliente.Text = ""
        txt_telefono.Text = ""
        txt_correo_cliente.Text = ""
        txt_aplicacion.Text = ""
        txt_nombre_usuario.Text = minombre
        cargar_foto()
        grilla_detalle_venta.Rows.Clear()
        txt_item.Text = "0"
        txt_codigo.Text = ""
        txt_rut_cliente.Text = ""
        txt_neto_millar.Text = ""
        txt_iva_millar.Text = ""
        txt_total_millar.Text = ""
        txt_desc_total.Text = "0"
        txt_nro_cotizacion.Text = ""
        If mirutempresa <> "87686300-6" Then
            txt_nro_cotizacion.Visible = False
        Else
            txt_nro_cotizacion.Visible = True
        End If
        txt_codigo.Focus()
    End Sub

    Sub limpiar_datos_productos()
        txt_cantidad.Text = ""
        txt_nombre_producto.Text = ""
        txt_costo.Text = ""
        txt_costo.Text = ""
        txt_factor.Text = ""
        txt_numero_tecnico.Text = ""
        txt_marca.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
        txt_proveedor.Text = ""
    End Sub

    Sub crear_numero_documento()
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

        If txt_costo.Text = "NeuN" Then
            txt_costo.Text = "0"
        End If

        If txt_costo.Text = "NeuN" Then
            txt_costo.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "NeuN" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad.Text = "NeuN" Then
            txt_cantidad.Text = "0"
        End If

        If IsNumeric(txt_costo.Text) = False Then
            txt_costo.Text = "0"
        End If

        If IsNumeric(txt_costo.Text) = False Then
            txt_costo.Text = "0"
        End If

        If IsNumeric(txt_cantidad_agregar.Text) = False Then
            txt_cantidad_agregar.Text = "0"
        End If

        If IsNumeric(txt_cantidad.Text) = False Then
            txt_cantidad.Text = "0"
        End If

        If txt_costo.Text = "Infinito" Then
            txt_costo.Text = "0"
        End If

        If txt_costo.Text = "Infinito" Then
            txt_costo.Text = "0"
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

            If txt_costo.Text = "" Then
                txt_costo.Text = "0"
            End If

            If txt_costo.Text = "" Then
                txt_costo.Text = "0"
            End If

            porcentaje_desc = "0"
            desc = "0"

            subtotal = (txt_costo.Text * txt_cantidad_agregar.Text)
            iva_valor = valor_iva / 100 + 1
            neto = (subtotal / iva_valor)
            iva = (neto) * valor_iva / 100
            total = subtotal - desc

            grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_costo.Text, txt_cantidad_agregar.Text, neto, iva, txt_costo.Text, porcentaje_desc, desc, total)
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

            If txt_costo.Text = "" Then
                txt_costo.Text = "0"
            End If

            If txt_costo.Text = "" Then
                txt_costo.Text = "0"
            End If

            porcentaje_desc = "0"
            desc = "0"

            If Int(txt_costo.Text) > Int(txt_costo.Text) Then
                porcentaje_desc = (txt_costo.Text - txt_costo.Text)
                porcentaje_desc = (porcentaje_desc * 100)
                porcentaje_desc = (porcentaje_desc / txt_costo.Text)
                desc = (txt_costo.Text - txt_costo.Text)
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
                txt_costo.Text = Int(txt_costo.Text / porcentaje_desc_3)

                If txt_costo.Text = "Infinito" Then
                    txt_costo.Text = "1"
                End If

                If txt_costo.Text = "NeuN" Then
                    txt_costo.Text = "1"
                End If

                desc = (txt_costo.Text - txt_costo.Text)
                desc = (desc * txt_cantidad_agregar.Text)

                If txt_costo.Text = "Infinito" Then
                    txt_costo.Text = "1"
                    desc = 0
                End If

                If txt_costo.Text = "NeuN" Then
                    txt_costo.Text = "1"
                    desc = 0
                End If
            End If

            If Int(txt_costo.Text) < Int(txt_costo.Text) Then
                subtotal = (txt_costo.Text * txt_cantidad_agregar.Text)
                precio_lista = txt_costo.Text
            Else
                subtotal = (txt_costo.Text * txt_cantidad_agregar.Text)
                precio_lista = txt_costo.Text
            End If

            iva_valor = valor_iva / 100 + 1
            neto = (subtotal / iva_valor)
            iva = (neto) * valor_iva / 100
            total = subtotal - desc

            grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, precio_lista, txt_cantidad_agregar.Text, neto, iva, txt_costo.Text, porcentaje_desc, desc, total)

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

                    txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                    txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")

                    If txt_rut_cliente.Text = "" Then
                        txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")

                        If txt_codigo.Text = "000038" Then
                            conexion.Close()
                            Exit Sub
                        End If

                        If txt_codigo.Text = "000380" Then
                            conexion.Close()
                            Exit Sub
                        End If


                        mostrar_datos_clientes()
                    End If

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

        If txt_costo.Text = "NeuN" Then
            txt_costo.Text = "0"
        End If

        If txt_costo.Text = "NeuN" Then
            txt_costo.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "NeuN" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad.Text = "NeuN" Then
            txt_cantidad.Text = "0"
        End If

        If IsNumeric(txt_costo.Text) = False Then
            txt_costo.Text = "0"
        End If

        If IsNumeric(txt_costo.Text) = False Then
            txt_costo.Text = "0"
        End If

        If IsNumeric(txt_cantidad_agregar.Text) = False Then
            txt_cantidad_agregar.Text = "0"
        End If

        If IsNumeric(txt_cantidad.Text) = False Then
            txt_cantidad.Text = "0"
        End If

        If txt_costo.Text = "NeuNInfinito Then" Then
            txt_costo.Text = "0"
        End If

        If txt_costo.Text = "Infinito" Then
            txt_costo.Text = "0"
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


        If txt_codigo.Text = "000038" Then
            txt_proveedor.Text = txt_rut_cliente.Text
        End If

        If txt_codigo.Text = "000380" Then
            txt_proveedor.Text = txt_rut_cliente.Text
        End If

        If UCase(txt_rut_cliente.Text) <> UCase(txt_proveedor.Text) Then
            'If txt_codigo.Text <> "000380" Or txt_codigo.Text <> "000038" Then
            txt_rut_cliente.Focus()
            MsgBox("EL PROVEEDOR DEL PRODUCTO DEBE SER EL SELECCIONADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
            'End If
        End If


        If grilla_detalle_venta.Rows.Count < 6 Then
            venta()
            txt_item.Text = grilla_detalle_venta.Rows.Count
            mostrar_cantidad_real()
            txt_cantidad_agregar.Text = ""
            Exit Sub
        Else
            MsgBox("NO PUEDE AGREGAR MAS PRODUCTOS", 0 + 16, "ERROR")
            Exit Sub
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



        Try
            descuento_porcentaje = ((txt_total.Text) * porcentaje_desc) / 100
            txt_desc.Text = descuento_porcentaje
            txt_total.Text = Int(txt_sub_total.Text) - Int(txt_desc.Text)
        Catch err As OverflowException
            txt_costo.Text = txt_costo.Text
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
            txt_costo.Focus()
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
            txt_costo.Text = txt_costo.Text
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
            txt_costo.Focus()
            Exit Sub
        End Try


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

        lbl_mensaje.Visible = True
        Me.Enabled = False

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
                    Me.controles(False, True)
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
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
            Me.controles(False, True)
            lbl_mensaje.Visible = False
            Me.Enabled = True
            MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

    End Sub

    Sub grabar_detalle_cotizacion()
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
            SC.CommandText = "insert into detalle_cotizacion (n_cotizacion, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_nro_cotizacion.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next
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
        Dim VarTipoDoc As String = ""






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
            SC.CommandText = "insert into detalle_guia (n_guia, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, detalle_descuento, porcentaje_desc, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarPorcentaje) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'GUIA DE TRASLADO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (txt_rut_vendedor.Text) & "' ,'EMITIDA')"
            DA.SelectCommand = SC
            DA.Fill(DT)



            If varnombre.Length > 20 Then
                varnombre = varnombre.Substring(0, 20)
                grilla_detalle_venta.Rows(i).Cells(1).Value = varnombre
            End If


            Dim tipo_doc As String
            Dim nro_doc As String
            Dim fecha_doc As String

            tipo_doc = ""
            nro_doc = ""
            fecha_doc = ""

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
                tipo_doc = DS.Tables(DT.TableName).Rows(0).Item("tipo_doc")
                nro_doc = DS.Tables(DT.TableName).Rows(0).Item("nro_doc")
                fecha_doc = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
            End If
            conexion.Close()

            Dim mensaje_guia As String

            If tipo_doc = "FACTURA" Then
                tipo_doc = "FAC."
            End If
            mensaje_guia = "DE " & tipo_doc & " " & nro_doc & " DEL " & fecha_doc

            If VarCodProducto = "000038" Then
                mensaje_guia = ""
            End If

            If VarCodProducto = "000380" Then
                mensaje_guia = ""
            End If

            grilla_detalle_venta.Rows(i).Cells(2).Value = mensaje_guia
        Next


    End Sub



    Sub grabar_factura()
        Dim tipo_impresion As String = ""

        Dim condicion_doc = ""
        condicion_doc = "TRASLADO"

        If estado_guia_electronica = "SI" Then
            tipo_impresion = "ELECTRONICA"
        Else
            tipo_impresion = "MANUAL"
        End If

        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `guias_de_traslado_a_proveedores` (`n_guia`, `motivo`, `solicitud`) VALUES ('" & (txt_factura.Text) & "', '" & (Combo_motivo.Text) & "', '" & (Combo_solicitud.Text) & "');"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into guia (n_guia, TIPO, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable,rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, vehiculo, patente, pie, condicion_de_pago_pie, comision) values (" & (txt_factura.Text) & " , '" & ("GUIA") & "', '" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "'," & (txt_desc.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & (condicion_doc) & "','" & ("SIN FACTURAR") & "','" & (txt_rut_vendedor.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (mirecintoempresa) & "','" & ("0") & "','" & (Form_menu_principal.lbl_hora.Text) & "','0','" & (tipo_impresion) & "', '-', '-', '0', '-', '0')"
        DA.SelectCommand = SC
        DA.Fill(DT)
    End Sub

    Sub grabar_detalle_temporal()
        'Dim VarCodProducto As Integer
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As Integer
        'Dim VarPorcentaje As Integer
        'Dim VarDescuento As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        'Dim VarTotal As Integer

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

        '    SC.Connection = conexion
        '    SC.CommandText = "insert into factura_temporal (n_factura,documento, codigo_producto, nombre_producto, numero_tecnico, cantidad, precio, porcentaje_desc, subtotal_detalle, total_detalle, NOMBRE_VENDEDOR) values('" & (txt_factura.Text) & "', 'GUIA','" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarCantidad) & "," & (VarValorUnitario) & "," & (VarPorcentaje) & "," & (VarSubtotal) & "," & (VarTotal) & ",'" & (minombre) & "')"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    conexion.Close()
        'Next
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
            Try
                SC.Connection = conexion
                SC.CommandText = "insert into documento_temporal (cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, usuario, documento, condicion_venta, porcentaje_desc_total, rut_cliente, nombre_cliente, direccion_cliente, cod_cliente, descuento_1,descuento_2, giro_cliente, comuna_cliente, telefono_cliente, estado_cuenta, folio_cliente, email_cliente, ciudad_cliente, rut_cliente_retira, nombre_cliente_retira, orden_de_compra, tipo_documento) values( '" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "','" & (VarValorUnitario) & "','" & (VarCantidad) & "','" & (VarPorcentaje) & "','" & (VarDescuento) & "','" & (VarNeto) & "', '" & (VarIva) & "','" & (VarSubtotal) & "','" & (VarTotal) & "','" & (miusuario) & "','GUIA','TRASLADO','0','" & (txt_rut_cliente.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_direccion_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','0','0,'" & (txt_giro_cliente.Text) & "','" & (txt_comuna_cliente.Text) & "','" & (txt_telefono.Text) & "','-','-','" & (txt_correo_cliente.Text) & "','-','-','" & (txt_nombre_retira.Text) & "','0','-')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Catch
            End Try

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


                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_rut_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente_retira")
                txt_nombre_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente_retira")
                txt_rut_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente_retira")
                txt_nombre_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente_retira")

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


    'segun el TIPO de documento selecconado llama al sub grabar y verifica que la csantidad de items no sobrepase el limite.
    Private Sub btn_grabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.Click

        If grilla_detalle_venta.Rows.Count = 0 Then
            MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo.Focus()
            Exit Sub
        End If

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

        If grilla_detalle_venta.Rows.Count > limite_guias Then
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

        valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA GUIA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")


        If valormensaje = vbYes Then
            imprimir()
            VarAutorizacionVenta = ""
            Exit Sub
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



    Private Sub combo_condiciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btn_grabar.Focus()
        End If
    End Sub

    Private Sub combo_condiciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        Form_buscador_proveedor_garantias.Show()
        Form_buscador_proveedor_garantias.txt_busqueda.Focus()
    End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Enabled = False
        txt_codigo.Focus()
        Form_buscador_productos_ventas.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_agregar_retira_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

        If (e.KeyChar = Convert.ToChar(Keys.F4)) Then
            btn_buscar_clientes.PerformClick()
        End If

        txt_nombre_cliente.Text = ""

        limpiar_datos_clientes()
        grilla_detalle_venta.Rows.Clear()

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
            Form_buscador_proveedor_garantias.Show()
            Me.Enabled = False
        End If

    End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
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

    Private Sub btn_agregar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        Form_registro_clientes_ventas.Show()
        'Me.WindowState = FormWindowState.Minimized
    End Sub



    Private Sub txt_cargar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

            calcular_totales()
            'cargar_nombre()

            txt_codigo.Focus()
            txt_item.Text = grilla_detalle_venta.Rows.Count
            lbl_mensaje.Visible = False
            Me.Enabled = True
            'lbl_venta.Text = (combo_venta.SelectedItem) & " (" & (combo_condiciones.SelectedItem) & ") $: " & (txt_total_final.Text)
            'detalle_label()
        End If
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


    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    ' If txt_total_final.Text = "0" Or txt_total_final.Text = "" Then
    ' MsgBox("AUN NO GENERA UNA VENTA", MsgBoxStyle.Critical, "INFORMACION")
    ' Else
    ' Form_vuelto.Show()
    ' controles_subpantalla(False, True)
    ' End If
    'End Sub


    Private Sub txt_porcentaje_desc_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs)

    End Sub

    Private Sub txt_descto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub



    Private Sub txt_descto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub btn_buscar_clientes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.GotFocus
        btn_buscar_clientes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.LostFocus
        btn_buscar_clientes.BackColor = Color.Transparent
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
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


        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 100, 20)
        e.Graphics.DrawString(Me.txt_factura.Text, Font10, Brushes.Black, 550, 20, format1)
        e.Graphics.DrawString(Me.txt_nombre_cliente.Text, Font10, Brushes.Black, 100, 36)
        'e.Graphics.DrawString(Me.txt_folio.Text, Font10, Brushes.Black, 550, 36, format1)
        e.Graphics.DrawString(Me.txt_direccion_cliente.Text, Font10, Brushes.Black, 100, 52)
        e.Graphics.DrawString(Me.txt_giro_cliente.Text, Font10, Brushes.Black, 100, 68)
        e.Graphics.DrawString(Me.txt_rut_cliente.Text, Font10, Brushes.Black, 655, 20)
        e.Graphics.DrawString(Me.txt_comuna_cliente.Text, Font10, Brushes.Black, 655, 36)
        e.Graphics.DrawString(Me.txt_telefono.Text, Font10, Brushes.Black, 655, 52)
        e.Graphics.DrawString("TRASLADO", Font10, Brushes.Black, 655, 68)
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

            Dim tipo_doc As String
            Dim nro_doc As String
            Dim fecha_doc As String

            tipo_doc = ""
            nro_doc = ""
            fecha_doc = ""

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
                tipo_doc = DS.Tables(DT.TableName).Rows(0).Item("tipo_doc")
                nro_doc = DS.Tables(DT.TableName).Rows(0).Item("nro_doc")
                fecha_doc = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
            End If
            conexion.Close()

            e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 0, 145 + (i * 45))
            e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 75, 145 + (i * 45))
            e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 335, 145 + (i * 45))
            e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 520, 145 + (i * 45), format1)
            e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 145 + (i * 45), format1)
            e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 640, 145 + (i * 45), format1)
            e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 725, 145 + (i * 45), format1)
            e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 792, 145 + (i * 45), format1)

            Dim mensaje_guia As String

            mensaje_guia = "PROVIENE DE " & tipo_doc & " " & nro_doc & " DEL " & fecha_doc

            If txt_codigo.Text = "000038" Then
                mensaje_guia = ""
            End If

            If txt_codigo.Text = "000380" Then
                mensaje_guia = ""
            End If

            e.Graphics.DrawString(mensaje_guia, Font8, Brushes.Black, 75, 145 + (i * 45 + 15))

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


        e.Graphics.DrawString("ENVIA", Font8, Brushes.Black, 0, 430)
        e.Graphics.DrawString("MOTIVO", Font8, Brushes.Black, 0, 445)
        e.Graphics.DrawString("SOLICITUD", Font8, Brushes.Black, 0, 460)

        e.Graphics.DrawString(":", Font8, Brushes.Black, 65, 430)
        e.Graphics.DrawString(":", Font8, Brushes.Black, 65, 445)
        e.Graphics.DrawString(":", Font8, Brushes.Black, 65, 460)

        e.Graphics.DrawString(minombre, Font8, Brushes.Black, 80, 430)
        e.Graphics.DrawString(Combo_motivo.Text, Font8, Brushes.Black, 80, 445)
        e.Graphics.DrawString(Combo_solicitud.Text, Font8, Brushes.Black, 80, 460)

        e.Graphics.DrawString(Me.txt_nombre_retira.Text, Font8, Brushes.Black, 55, 540)
        e.Graphics.DrawString(Me.txt_rut_retira.Text, Font8, Brushes.Black, 265, 540)
        e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 510, 540)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 797, 540, format1)

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

    Private Sub txt_rut_retira_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut_retira.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_clientes_retira_proveedores_garantias.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_rut_retira_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_retira.LostFocus
        txt_rut_retira.BackColor = Color.White
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

            If txt_codigo.Text <> "" And txt_nombre_producto.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MsgBoxStyle.Critical, "INFORMACION")
                txt_codigo.Focus()
            Else

                If ingreso_rapido = "NO" Then
                    txt_cantidad_agregar.Text = "1"
                    txt_costo.Focus()
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
        'If e.KeyCode = Keys.F4 Then
        '    conexion.Close()
        '    Form_buscar_productos_ventas.Show()
        '    Me.Enabled = False
        'End If
    End Sub

    Private Sub txt_codigo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub

    Private Sub btn_buscar_productos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        conexion.Close()
        txt_codigo.Focus()
        Form_buscador_productos_ventas.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_imagen_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        txt_costo.Text = grilla_detalle_venta.CurrentRow.Cells(7).Value()
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

    Private Sub txt_porcentaje_desc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calcular_totales()
    End Sub

    Private Sub txt_precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            txt_costo.Focus()
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
        Form_buscador_clientes_retira_proveedores_garantias.Show()
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

            grilla_remplazo.Rows.Add(VarCodProducto, varnombre, vartecnico, VarValorLista, VarCantidad, VarNeto, VarIva, VarValorUnitario, VarPorcentaje, VarDescuento, VarTotal, porcentaje_total)
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

            Dim iva As Long
            Dim neto As Long
            Dim iva_valor As String



            VarTotal = Val(VarValorUnitario) * (VarCantidad)

            iva_valor = valor_iva / 100 + 1
            neto = (VarTotal / iva_valor)
            iva = (neto) * valor_iva / 100

            grilla_detalle_venta.Rows.Add(VarCodProducto, varnombre, vartecnico, VarValorUnitario, VarCantidad, neto, iva, VarValorUnitario, VarPorcentaje, VarDescuento, VarTotal)
        Next


        calcular_totales()
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

    Private Sub Combo_motivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_motivo.GotFocus
        Combo_motivo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_motivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_motivo.KeyPress
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
    'Private Sub Combo_motivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_motivo.LostFocus
    '    Combo_motivo.BackColor = Color.White
    'End Sub

    'Private Sub Combo_solicitud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_solicitud.GotFocus
    '    Combo_solicitud.BackColor = Color.LightSkyBlue
    'End Sub

    Private Sub Combo_solicitud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_solicitud.KeyPress
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
    'Private Sub Combo_solicitud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_solicitud.LostFocus
    '    Combo_solicitud.BackColor = Color.White
    'End Sub

    Private Sub Combo_motivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_motivo.SelectedIndexChanged

    End Sub

    Private Sub Combo_solicitud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_solicitud.SelectedIndexChanged

    End Sub

    Private Sub txt_costo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_costo.KeyPress
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




    Private Sub txt_costo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_costo.TextChanged

    End Sub

    Private Sub txt_costo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_costo.GotFocus
        txt_costo.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub txt_costo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_costo.LostFocus
        txt_costo.BackColor = Color.White
    End Sub

    Private Sub Combo_motivo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_motivo.GotFocus
        Combo_motivo.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub Combo_motivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_motivo.LostFocus
        Combo_motivo.BackColor = Color.White
    End Sub

    Private Sub Combo_solicitud_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_solicitud.GotFocus
        Combo_solicitud.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub Combo_solicitud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_solicitud.LostFocus
        Combo_solicitud.BackColor = Color.White
    End Sub

    Sub crear_archivo_plano()
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        'Donde guardamos los paths de los archivos que vamos a estar utilizando ..
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
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer

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
        ciudad_cliente = txt_comuna_cliente.Text
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

        'If txt_folio.Text = "-" Then
        '    txt_folio.Text = ""
        'End If

        Dim condicion As String

        condicion = "TRASLADO"

        'correcto sin modificaciones



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
            & "52" & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & "2" & ";" & "7" & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (txt_nombre_usuario.Text) & ";" & (txt_rut_retira.Text) & ";" & (txt_nombre_retira.Text) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
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

            'If txt_nro_orden_de_compra.Text = "0" Then
            '    txt_nro_orden_de_compra.Text = ""
            'End If

            strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
            & "1" & ";" & "801" & ";"";;" & "0" & ";" & "-" & ";" & vbNewLine _
            & "->DescRec<-" & vbNewLine _
            & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & txt_desc.Text & ";" & "0" & ";" & vbNewLine _
            & "->Observacion<-" & vbNewLine _
            & "MOTIVO: " & Combo_motivo.Text & ", SOLICITUD: " & Combo_solicitud.Text & ";")
            strStreamWriter.Close() ' cerramos

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try

    End Sub
End Class