Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Math
Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Form_guias_traslado
    Dim total_registros As Integer
    Dim varnumdoc As Integer
    Dim peso As String
    Dim pesos As String
    Dim sin_facturar As String
    Dim VarSeleccion As Integer
    Dim estado_impresion As String
    Private WithEvents Pd As New PrintDocument
    Dim cantidad_letras As Integer

    Private Sub Form_guias_traslado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        grabar_documento_temporal()
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_guias_traslado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

        If e.KeyCode = Keys.F9 Then
            txt_cargar.Focus()
        End If

        If e.KeyCode = Keys.F11 Then
            combo_venta.Focus()
        End If

        If e.KeyCode = Keys.F12 Then
            btn_grabar.PerformClick()
            Exit Sub
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

    Private Sub Form_guias_traslado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        cargar_logo()
        valores()
        controles(False, True)
        cargar_foto()
        cargar_documento_temporal()
        mostrar_datos_login()
        txt_codigo.Focus()
        Timer_ventas.Start()
        dtp_fecha.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.Value = dtp_vencimiento.Value.AddMonths(Val(+1))
        Me.btn_nueva.PerformClick()

        Me.ToolTip1.SetToolTip(btn_buscar_clientes, "BUSCADOR DE CLIENTES.")
        Me.ToolTip1.SetToolTip(btn_buscar_productos, "BUSCADOR DE PRODUCTOS.")
        Me.ToolTip1.SetToolTip(btn_imagen, "VISUALIZAR IMAGEN DEL PRODUCTO.")
        Me.ToolTip1.SetToolTip(btn_agregar, "AGREGAR ITEM A LA MALLA DE VENTAS.")
        Me.ToolTip1.SetToolTip(btn_quitar_elemento, "QUITAR ITEM DE LA MALLA DE VENTAS.")
        Me.ToolTip1.SetToolTip(txt_cargar, "CARGAR UN DOCUMENTO.")
        Me.ToolTip1.SetToolTip(btn_grabar, "IMPRIMIR LA VENTA.")
        Me.ToolTip1.SetToolTip(btn_limpiar, "BORRAR TODOS LOS DATOS INGRESADOS EN LA PANTALLA.")
        Me.ToolTip1.SetToolTip(btn_salir, "CERRAR LA PANTALLA DE VENTAS.")
        Me.ToolTip1.SetToolTip(btn_nueva, "DESBLOQUEAR LOS CAMPOS PARA INICIAR UNA VENTA.")
        Me.ToolTip1.SetToolTip(txt_cantidad_agregar, "INGRESE LA CANTIDAD A VENDER.")
        Me.ToolTip1.SetToolTip(txt_codigo, "INGRESE EL CODIGO DEL ITEM.")
        Me.ToolTip1.SetToolTip(txt_rut_cliente, "INGRESE RUT DEL CLIENTE TITULAR DE LA CUENTA.")
        Me.ToolTip1.SetToolTip(txt_rut_retira, "INGRESE RUT DEL CLIENTE QUE RETIRA EL DOCUMENTO.")
        Me.ToolTip1.SetToolTip(combo_venta, "SELECCIONE EL TIPO DE DOCUMENTO.")
        Me.ToolTip1.SetToolTip(combo_condiciones, "SELECCIONE LA CONDICION DE VENTA.")
        Me.ToolTip1.IsBalloon = True
    End Sub

    Sub mostrar_datos_login()
        lbl_usuario_conectado.Text = minombre
    End Sub

    Sub grabar_letras()
        dtp_letra.Text = FormatDateTime(Now, DateFormat.ShortDate)

        Dim Total_letra As Integer
        Dim Neto_letra As Integer
        Dim Iva_letra As Integer
        Dim Comprobar_letra As Integer

        Total_letra = Val(txt_total.Text) / Val(txt_cargar.Text)
        Comprobar_letra = (Total_letra) * (txt_cargar.Text)
        Comprobar_letra = (txt_total.Text) - (Comprobar_letra)
        Total_letra = (Total_letra) + (Comprobar_letra)
        Round(Total_letra)

        'Dim iva As Integer
        'Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        Neto_letra = Round(Total_letra / iva_valor)
        Iva_letra = (((Neto_letra) * valor_iva) / 100)
        Iva_letra = (Total_letra) - (Neto_letra)

        If combo_venta.Text = "BOLETA" Then
            SC.Connection = conexion
            SC.CommandText = "insert into  creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, desglose, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto) values (" & (txt_nro_letra.Text) & ",'" & ("LETRA") & "','" & ("LETRA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (dtp_letra.Text) & "','0'," & (Neto_letra) & "," & (Iva_letra) & "," & (Total_letra) & "," & (Total_letra) & "," & (Total_letra) & ",'-','" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (miusuario) & "','" & (txt_factura.Text) & "','BOLETA','" & (mirecintoempresa) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into letras (n_letra, cant_letras, doc_referencia, nro_referencia, fecha, rut_cliente, monto_letra, total_letra, estado, usuario_responsable) values (" & (txt_nro_letra.Text) & " , '" & (txt_cargar.Text) & "', '" & (combo_venta.Text) & "','" & (txt_factura.Text) & "','" & (dtp_fecha.Text) & "','" & (txt_rut_cliente.Text) & "'," & (Total_letra) & "," & (txt_total.Text) & ", 'EMITIDA', '" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If combo_venta.Text = "FACTURA" Then
            SC.Connection = conexion
            SC.CommandText = "insert into  creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, desglose, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto) values (" & (txt_factura.Text) & ",'" & ("LETRA") & "','" & ("LETRA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (dtp_letra.Text) & "','0'," & (Neto_letra) & "," & (Iva_letra) & "," & (Total_letra) & "," & (Total_letra) & "," & (Total_letra) & ",'-','" & (combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (miusuario) & "','" & (txt_factura.Text) & "','FACTURA','" & (mirecintoempresa) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into letras (n_letra, cant_letras, doc_referencia, nro_referencia, fecha, rut_cliente, monto_letra, total_letra, estado, usuario_responsable) values (" & (txt_nro_letra.Text) & " , '" & (txt_cargar.Text) & "', '" & (combo_venta.Text) & "','" & (txt_factura.Text) & "','" & (dtp_fecha.Text) & "','" & (txt_rut_cliente.Text) & "'," & (Total_letra) & "," & (txt_total.Text) & ", 'EMITIDA', '" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
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
        txt_folio.Text = ""
        txt_descuento_cliente_2.Text = ""
        txt_orden_de_compra.Text = ""
        txt_tipo_documento.Text = ""
        txt_saldo.Text = "0"
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
        Dim ruta_fotografia As String
        ruta_fotografia = ""

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
        End If
        conexion.Close()

        Try
            If File.Exists(ruta_fotografia & miusuario & ".jpg") = False Then
                PictureBox_imagen.ImageLocation = "C:\Sistema de ventas\Imagenes de usuarios\Usuario.jpg"
            Else
                PictureBox_imagen.ImageLocation = ruta_fotografia & miusuario & ".jpg"
            End If
        Catch
        End Try
    End Sub

    Sub cargar_documento()
        grilla_detalle_venta.Rows.Clear()
        If combo_venta.Text = "BOLETA" Then
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
            End If
        End If

        If combo_venta.Text = "BOLETA DE CREDITO" Then
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
            End If
        End If

        If combo_venta.Text = "BOLETA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta_credito where detalle_boleta_credito.n_boleta_credito='" & (txt_cargar.Text) & "'"
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
            End If
        End If

        If combo_venta.Text = "FACTURA" Then
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

                Dim nombre As String
                Dim valor As String
                Dim descuento As String
                Dim total As String
                Dim subtotal As String

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
                    txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                    txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                    txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                    txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                    txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                    txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                    conexion.Close()
                    Exit Sub
                End If
            End If
        End If

        If combo_venta.Text = "FACTURA DE CREDITO" Then
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

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Dim nombre As String
                Dim valor As String
                Dim descuento As String
                Dim total As String
                Dim subtotal As String

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
                    txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                    txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                    txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                    txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                    txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                    txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                    conexion.Close()
                    Exit Sub
                End If
            End If
        End If

        If combo_venta.Text = "COTIZACION" Then
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
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from clientes, cotizacion where cod_cliente = cotizacion.codigo_cliente and cotizacion.n_cotizacion='" & (txt_cargar.Text) & "'"
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
                    txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                    txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                    txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                    txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                    txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                    txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                    conexion.Close()
                    Exit Sub
                End If
            End If
        End If

        If combo_venta.Text = "GUIA" Then
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

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
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

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from clientes, guia where cod_cliente = guia.codigo_cliente and guia.n_guia='" & (txt_cargar.Text) & "'"
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
                    txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                    txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                    txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                    txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                    txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                    txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                    conexion.Close()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    'sub para mostrar los datos de los clientes.
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
                txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                txt_saldo.Text = DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")
                conexion.Close()
                Exit Sub

            ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
                conexion.Close()
                Form_seleccionar_cuenta_guias_de_traslado.Show()
                Me.Enabled = False
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
        End If
    End Sub

    'sub para mostrar los datos de los clientes.
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

    'sub para mostrar los datos de los productos.
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

    'Sub para mostrar los datos del cliente que retira documentos.
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

    'sub controles, permite cambiar el estado cuando lo necesitemos.
    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a
        combo_condiciones.Enabled = a
        txt_codigo.Enabled = a
        txt_rut_cliente.Enabled = a
        btn_grabar.Enabled = a
        btn_limpiar.Enabled = a
        btn_nueva.Enabled = b
        combo_venta.Enabled = b
        btn_imagen.Enabled = a
        btn_buscar_clientes.Enabled = a
        btn_buscar_productos.Enabled = a
        txt_cantidad_etiquetas.Enabled = a
        txt_cargar.Enabled = a
        txt_cantidad_agregar.Enabled = a
        Combo_vehiculo.Enabled = a
        txt_patente.Enabled = a
        txt_codigo.Enabled = a
        txt_rut_cliente.Enabled = a
        txt_nombre_producto.Enabled = a
        combo_venta.Enabled = a
        'txt_precio_modificado.Enabled = a
        txt_productos.Enabled = a
        GroupBox_cargar.Enabled = a
        GroupBox_clientes.Enabled = a
        GroupBox_producto.Enabled = a
        GroupBox_tipo_venta.Enabled = a
        GroupBox_totales.Enabled = a
        grilla_detalle_venta.Enabled = a
        txt_rut_retira.Enabled = a
        'If txt_precio_modificado.Enabled = True Then
        '    txt_precio_modificado.BackColor = Color.White
        'Else
        '    txt_precio_modificado.BackColor = SystemColors.Control
        'End If
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
        If combo_condiciones.Enabled = True Then
            combo_condiciones.BackColor = Color.White
        Else
            combo_condiciones.BackColor = SystemColors.Control
        End If
        If combo_venta.Enabled = True Then
            combo_venta.BackColor = Color.White
        Else
            combo_venta.BackColor = SystemColors.Control
        End If
    End Sub

    'nos permite limpiar los campos de la pantalla cuando lo necesitemos.
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
        txt_costo.Text = ""
        txt_factor.Text = ""
        txt_rut_cliente.Text = ""
        txt_cuenta_cliente.Text = ""
        txt_codigo.Text = ""
        txt_descuento_cliente.Text = ""
        txt_total.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_nombre_retira.Text = ""
        txt_rut_retira.Text = ""
        txt_rut_cliente.Text = ""
        txt_factura.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_giro_cliente.Text = ""
        txt_telefono.Text = ""
        txt_folio.Text = ""
        txt_ciudad_cliente.Text = ""
        txt_correo_cliente.Text = ""
        txt_aplicacion.Text = ""
        txt_descuento_cliente_2.Text = ""
        txt_orden_de_compra.Text = ""
        grilla_detalle_venta.Rows.Clear()
        txt_item.Text = "0"
        txt_codigo.Text = ""
        txt_rut_cliente.Text = ""
        txt_tipo_documento.Text = ""
        combo_venta.Text = "GUIA"
        combo_condiciones.SelectedItem = "TRASLADO"
        txt_neto_millar.Text = ""
        txt_iva_millar.Text = ""
        Combo_vehiculo.SelectedItem = "-"
        txt_patente.Text = ""
        txt_total_millar.Text = ""
        txt_desc_total.Text = "0"
        txt_saldo.Text = "0"
        txt_cantidad_etiquetas.Text = ""
        txt_productos.Text = ""
        txt_codigo.Focus()
    End Sub

    'limpiar producto se utiliza cuando agregamos el producto a la grilla.
    Sub limpiar_datos_productos()
        txt_cantidad.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        txt_factor.Text = ""
        txt_costo.Text = ""
        txt_numero_tecnico.Text = ""
        txt_marca.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
        txt_cantidad_etiquetas.Text = ""
    End Sub

    'permite crear el numero correlativo segun el documento que seleccionemos.
    Sub crear_numero_documento()
        If combo_venta.Text = "FACTURA" Then
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

        If combo_venta.Text = "FACTURA DE CREDITO" Then
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

        If combo_venta.Text = "GUIA" Then
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

        If combo_venta.Text = "BOLETA" Then
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

        If combo_venta.Text = "BOLETA DE CREDITO" Then
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


        If combo_venta.Text = "COTIZACION" Then
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
            'condiciones()
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
        Dim codigo As Long
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
        If txt_cantidad_agregar.Text = "  " Then
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

        If txt_codigo.Text = "*" Then
            Try
                If txt_cantidad_agregar.Text <> "" And txt_cantidad_agregar.Text <> " " And txt_cantidad_agregar.Text <> "  " And txt_cantidad_agregar.Text <> 0 Then

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
                    imprimir_etiquetas()
                    limpiar_datos_productos()
                    txt_codigo.Text = ""
                    txt_codigo.Focus()
                Else
                    MsgBox("DEBE INGRESAR UNA CANTIDAD", 0 + 16, "ERROR")
                    txt_cantidad_agregar.Focus()
                End If

            Catch err As InvalidCastException
                MsgBox("VERIFIQUE EL CODIGO INGRESADO", 0 + 16, "ERROR")
                txt_cantidad_agregar.Focus()
                Exit Sub
            End Try
            Exit Sub
        End If

        Try
            If txt_cantidad_agregar.Text <> "" And txt_cantidad_agregar.Text <> " " And txt_cantidad_agregar.Text <> "  " And txt_cantidad_agregar.Text <> 0 Then
                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    codigo = Val(grilla_detalle_venta.Rows(i).Cells(0).Value.ToString)
                    cantidad = Val(grilla_detalle_venta.Rows(i).Cells(4).Value.ToString)
                    If codigo = txt_codigo.Text Then
                        grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.Rows(i))
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
                imprimir_etiquetas()
                limpiar_datos_productos()
                txt_codigo.Text = ""
                txt_codigo.Focus()
            Else
                MsgBox("DEBE INGRESAR UNA CANTIDAD", 0 + 16, "ERROR")
                txt_cantidad_agregar.Focus()
            End If

        Catch err As InvalidCastException
            MsgBox("VERIFIQUE EL CODIGO INGRESADO", 0 + 16, "ERROR")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End Try
    End Sub

    'a traves de este sub puedo descontar las cantidades que agregue a la grilla cuando el mismo codigo del producto ya fue agregado.
    Sub mostrar_cantidad_real()
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


        Dim mensaje As String = ""

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

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

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

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_codigo.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Text = ""
            txt_cantidad_agregar.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Val(txt_cantidad_agregar.Text) > Val(txt_cantidad.Text) Then
            txt_cantidad_agregar.Text = ""
            txt_cantidad_agregar.Focus()
            MsgBox("SALDO STOCK NO ES SUFICIENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_nombre_producto.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_venta.Text = "" Then
            mensaje = "CAMPO DOCUMENTO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            combo_venta.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_venta.Text <> "BOLETA" And combo_venta.Text <> "BOLETA DE CREDITO" And combo_venta.Text <> "FACTURA" And combo_venta.Text <> "FACTURA DE CREDITO" And combo_venta.Text <> "GUIA" And combo_venta.Text <> "COTIZACION" Then
            combo_venta.Focus()
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
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
                combo_venta.Text = "COTIZACION"
            End If

            If combo_venta.Text = "COTIZACION" Then
                If grilla_detalle_venta.Rows.Count < 100 Then
                    venta()
                    txt_item.Text = grilla_detalle_venta.Rows.Count
                    mostrar_cantidad_real()
                    txt_cantidad_agregar.Text = ""
                    Exit Sub
                Else
                    MsgBox("EN UNA COTIZACION NO PUEDE AGREGAR MAS DE 10 ITEMS", 0 + 16, "ERROR")
                    Exit Sub
                End If
            End If


            Exit Sub
        End If

        If combo_venta.Text = "GUIA" Then
            If grilla_detalle_venta.Rows.Count < 31 Then
                venta()
                txt_item.Text = grilla_detalle_venta.Rows.Count
                mostrar_cantidad_real()
                txt_cantidad_agregar.Text = ""
                estado_impresion = ""
                Exit Sub
            Else
                MsgBox("EN UNA GUIA NO PUEDE AGREGAR MAS DE 16 ITEMS", 0 + 16, "ERROR")
                Exit Sub
            End If
        End If
    End Sub

    'va generando el calculo del neto iva total y descuento del documento, es decir de la suma de todos los productos ingresados.
    Sub calcular_totales()
        'Dim VarCantidad As Long
        Dim descgrilla As Long
        Dim netogrilla As Long
        Dim ivagrilla As Long
        Dim totalgrilla As Long
        'Dim subtotalgrilla As Long
        Dim ProductosGrilla As Long

        '//Calcular el descuento
        txt_desc_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            descgrilla = Val(grilla_detalle_venta.Rows(i).Cells(9).Value.ToString)
            '  VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            '   descgrilla = descgrilla * VarCantidad
            txt_desc_total.Text = Val(txt_desc_total.Text) + Val(descgrilla)
        Next

        '//Calcular el total neto
        txt_neto.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            netogrilla = Val(grilla_detalle_venta.Rows(i).Cells(5).Value.ToString)
            txt_neto.Text = Val(txt_neto.Text) + Val(netogrilla)
        Next

        '//Calcular el total iva
        txt_iva.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            ivagrilla = Val(grilla_detalle_venta.Rows(i).Cells(6).Value.ToString)
            txt_iva.Text = Val(txt_iva.Text) + Val(ivagrilla)
        Next

        '//Calcular el total general
        txt_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            totalgrilla = Val(grilla_detalle_venta.Rows(i).Cells(10).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        txt_productos.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            ProductosGrilla = Val(grilla_detalle_venta.Rows(i).Cells(4).Value.ToString)
            txt_productos.Text = Val(txt_productos.Text) + Val(ProductosGrilla)
        Next

        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        neto = (txt_total.Text / iva_valor)
        Round(neto)
        txt_neto.Text = neto

        iva = ((txt_neto.Text) * valor_iva / 100)
        Round(iva)
        txt_iva.Text = iva

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
        'Dim VarPorcentajeDesc As String
        Dim VarCantidadDesc As Integer
        'Dim VarDescuentoCliente As Integer
        'Dim porcentaje_desc As Integer
        Dim mensaje As String = ""
        VarCantidadDesc = 0

        If combo_venta.Text = "" Then
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_venta.Focus()
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

        If combo_venta.Text = "GUIA" Then
            If txt_rut_cliente.Text = "" Then
                mensaje = "CAMPO CLIENTE TITULAR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_rut_cliente.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_nombre_retira.Text = "" Then
                mensaje = "CAMPO CLIENTE QUE RETIRA VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_rut_retira.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If grilla_detalle_venta.Rows.Count > 31 Then
                MsgBox("EN UNA GUIA NO PUEDE AGREGAR MAS DE 16 ITEMS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
                txt_codigo.Focus()
                Exit Sub
            End If

            If valida_rut(txt_rut_cliente.Text) = False Then
                txt_rut_cliente.Focus()
                txt_rut_cliente.SelectAll()
                Exit Sub
            End If

            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA " & combo_venta.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")

            If valormensaje = vbYes Then

                VarCantidadDesc = 0

                If combo_venta.Text = "" Then
                    Exit Sub
                End If

                estado_impresion = "LISTO"

                If estado_guia_electronica = "NO" Then

                    With Pd.PrinterSettings
                        ' Especifico el nombre de la impresora 
                        ' por donde deseo imprimir. 
                        .PrinterName = impresora_guias
                        ' Establezco el número de copias que se imprimirán 
                        .Copies = 1
                        ' Rango de páginas que se imprimirán 
                        .PrintRange = PrintRange.AllPages
                        If .IsValid Then

                            Me.Enabled = False
                            Me.crear_numero_documento()
                            Me.grabar_factura()

                            If mirutempresa = "87686300-6" Then
                                Me.Pd.PrintController = New StandardPrintController
                                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                                Pd.Print()
                            End If

                            If mirutempresa = "81921000-4" Then
                                Me.Pd.PrintController = New StandardPrintController
                                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                                Pd.Print()
                            End If

                            Me.grabar_detalle_factura()
                            MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                            Me.crear_archivo_plano()
                            Me.limpiar()
                            Me.Enabled = True
                            Me.controles(False, True)
                            Exit Sub
                        Else
                            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                            Me.Enabled = True
                            Exit Sub
                        End If
                    End With

                Else

                    Me.Enabled = False
                    Me.crear_numero_documento()
                    Me.grabar_factura()
                    Me.grabar_detalle_factura()
                    MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Me.crear_archivo_plano()
                    Me.limpiar()
                    Me.Enabled = True
                    Me.controles(False, True)
                    Exit Sub
                End If
            End If
        End If
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
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer
        'Dim fecha_traspaso As String
        'Dim hora_traspaso As String
        'Dim estado_traspaso As String
        'Dim usuario_responsable_traspaso As String
        'Dim sucursal_traspaso As String
        Dim nombre_traspaso As String
        Dim aplicacion_traspaso As String
        Dim nro_tecnico_traspaso As String
        Dim marca_traspaso As String
        'Dim cod_barra_traspaso As String
        Dim familia_traspaso As String
        Dim subfamilia_traspaso As String
        'Dim subfamilia2_traspaso As String
        Dim cantidad_minima_traspaso As String
        Dim precio_traspaso As String
        Dim tipo_precio_traspaso As String
        Dim factor_traspaso As String
        Dim costo_traspaso As String
        Dim rut_proveedor_traspaso As String
        'Dim fecha_ult_compra_traspaso As String
        'Dim cant_ult_compra_traspaso As String
        Dim tipo_doc_traspaso As String
        Dim nro_doc_traspaso As String
        Dim codigo_familia_traspaso As String
        Dim codigo_subfamilia_traspaso As String
        Dim codigo_subfamilia_2_traspaso As String
        Dim cantidad_ultima_compra_traspaso As String
        Dim ultima_compra_traspaso As String
        Dim codigo_barra_traspaso As String

        If combo_venta.Text = "GUIA" Then
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
                SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'GUIA DE TRASLADO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (dtp_fecha.Text) & "', '" & (miusuario) & "' ,'EMITIDA')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                If mirutempresa = "81921000-4" Then
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    Try
                        SC.Connection = conexion
                        SC.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        DS.Tables.Add(DT)

                        If DS.Tables(DT.TableName).Rows.Count > 0 Then
                            nombre_traspaso = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                            marca_traspaso = DS.Tables(DT.TableName).Rows(0).Item("marca")
                            aplicacion_traspaso = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                            nro_tecnico_traspaso = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                            familia_traspaso = DS.Tables(DT.TableName).Rows(0).Item("familia")
                            subfamilia_traspaso = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                            factor_traspaso = DS.Tables(DT.TableName).Rows(0).Item("factor")
                            costo_traspaso = DS.Tables(DT.TableName).Rows(0).Item("costo")
                            rut_proveedor_traspaso = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                            precio_traspaso = DS.Tables(DT.TableName).Rows(0).Item("precio")
                            codigo_barra_traspaso = DS.Tables(DT.TableName).Rows(0).Item("codigo_barra")
                            ultima_compra_traspaso = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
                            cantidad_ultima_compra_traspaso = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
                            nro_doc_traspaso = DS.Tables(DT.TableName).Rows(0).Item("nro_doc")
                            tipo_doc_traspaso = DS.Tables(DT.TableName).Rows(0).Item("tipo_doc")
                            cantidad_minima_traspaso = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")
                            codigo_familia_traspaso = DS.Tables(DT.TableName).Rows(0).Item("familia")
                            codigo_subfamilia_traspaso = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                            codigo_subfamilia_2_traspaso = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")

                            Dim mifecha As Date
                            mifecha = ultima_compra_traspaso
                            ultima_compra_traspaso = mifecha.ToString("yyy-MM-dd")

                            If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "1" Then
                                tipo_precio_traspaso = "FACTOR"
                            End If

                            If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "2" Then
                                tipo_precio_traspaso = "DIRECTO"
                            End If
                        End If

                    Catch err As InvalidCastException
                        conexion.Close()
                    End Try

                    'SC.Connection = conexion
                    'SC.CommandText = "insert into vale (n_vale, despachador, codigo_producto, cantidad, fecha, hora, estado, usuario_responsable, sucursal) values(" & (txt_factura.Text) & ", '" & (minombre) & "', '" & (VarCodProducto) & "','" & (VarCantidad) & "','" & (form_Menu_admin.dtp_fecha.Text) & "','" & (form_Menu_admin.lbl_hora.Text) & "','EMITIDA','" & (miusuario) & "','" & (txt_direccion_cliente.Text) & "')"
                    'DA.SelectCommand = SC
                    'DA.Fill(DT)
                End If
            Next
        End If

        'grabar_detalle_factura_remoto()
        'recuperar_conexion()
    End Sub

    Sub grabar_detalle_factura_remoto()
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
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer
        'Dim fecha_traspaso As String
        'Dim hora_traspaso As String
        'Dim estado_traspaso As String
        'Dim usuario_responsable_traspaso As String
        'Dim sucursal_traspaso As String
        Dim nombre_traspaso As String
        Dim aplicacion_traspaso As String
        Dim nro_tecnico_traspaso As String
        Dim marca_traspaso As String
        'Dim cod_barra_traspaso As String
        Dim familia_traspaso As String
        Dim subfamilia_traspaso As String
        'Dim subfamilia2_traspaso As String
        Dim cantidad_minima_traspaso As String
        Dim precio_traspaso As String
        Dim tipo_precio_traspaso As String
        Dim factor_traspaso As String
        Dim costo_traspaso As String
        Dim rut_proveedor_traspaso As String
        'Dim fecha_ult_compra_traspaso As String
        'Dim cant_ult_compra_traspaso As String
        Dim tipo_doc_traspaso As String
        Dim nro_doc_traspaso As String
        Dim codigo_familia_traspaso As String
        Dim codigo_subfamilia_traspaso As String
        Dim codigo_subfamilia_2_traspaso As String
        Dim cantidad_ultima_compra_traspaso As String
        Dim ultima_compra_traspaso As String
        Dim codigo_barra_traspaso As String

        VarCodProducto = ""
        varnombre = ""
        vartecnico = ""
        VarValorUnitario = 0
        VarCantidad = ""
        VarPorcentaje = 0
        VarDescuento = 0
        VarNeto = 0
        VarIva = 0
        VarSubtotal = 0
        VarTotal = 0
        nombre_traspaso = ""
        aplicacion_traspaso = ""
        nro_tecnico_traspaso = ""
        marca_traspaso = ""
        familia_traspaso = ""
        subfamilia_traspaso = ""
        cantidad_minima_traspaso = ""
        precio_traspaso = ""
        tipo_precio_traspaso = ""
        factor_traspaso = ""
        costo_traspaso = ""
        rut_proveedor_traspaso = ""
        tipo_doc_traspaso = ""
        nro_doc_traspaso = ""
        codigo_familia_traspaso = ""
        codigo_subfamilia_traspaso = ""
        codigo_subfamilia_2_traspaso = ""
        cantidad_ultima_compra_traspaso = ""
        ultima_compra_traspaso = ""
        codigo_barra_traspaso = ""

        If combo_venta.Text = "GUIA" Then
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

                If mirutempresa = "81921000-4" Then
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()
                    Try
                        SC.Connection = conexion
                        SC.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        DS.Tables.Add(DT)

                        If DS.Tables(DT.TableName).Rows.Count > 0 Then
                            nombre_traspaso = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                            marca_traspaso = DS.Tables(DT.TableName).Rows(0).Item("marca")
                            aplicacion_traspaso = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                            nro_tecnico_traspaso = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                            familia_traspaso = DS.Tables(DT.TableName).Rows(0).Item("familia")
                            subfamilia_traspaso = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                            factor_traspaso = DS.Tables(DT.TableName).Rows(0).Item("factor")
                            costo_traspaso = DS.Tables(DT.TableName).Rows(0).Item("costo")
                            rut_proveedor_traspaso = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                            precio_traspaso = DS.Tables(DT.TableName).Rows(0).Item("precio")
                            codigo_barra_traspaso = DS.Tables(DT.TableName).Rows(0).Item("codigo_barra")
                            ultima_compra_traspaso = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
                            cantidad_ultima_compra_traspaso = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
                            nro_doc_traspaso = DS.Tables(DT.TableName).Rows(0).Item("nro_doc")
                            tipo_doc_traspaso = DS.Tables(DT.TableName).Rows(0).Item("tipo_doc")
                            cantidad_minima_traspaso = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")
                            codigo_familia_traspaso = DS.Tables(DT.TableName).Rows(0).Item("familia")
                            codigo_subfamilia_traspaso = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                            codigo_subfamilia_2_traspaso = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")

                            Dim mifecha As Date
                            mifecha = ultima_compra_traspaso
                            ultima_compra_traspaso = mifecha.ToString("yyy-MM-dd")

                            If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "1" Then
                                tipo_precio_traspaso = "FACTOR"
                            End If

                            If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "2" Then
                                tipo_precio_traspaso = "DIRECTO"
                            End If
                        End If

                    Catch err As InvalidCastException
                        conexion.Close()
                    End Try

                    Dim nombre_servidor As String
                    Dim nombre_servidor_remoto As String
                    Dim base_de_datos As String
                    Dim clave_base_de_datos As String
                    Dim usuario As String
                    Dim recinto As String
                    Dim rut_empresa As String

                    For u = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                        nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(u).Cells(0).Value.ToString
                        nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(u).Cells(1).Value.ToString
                        base_de_datos = Form_menu_principal.grilla_conexiones.Rows(u).Cells(2).Value.ToString
                        clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(u).Cells(3).Value.ToString
                        usuario = Form_menu_principal.grilla_conexiones.Rows(u).Cells(4).Value.ToString
                        recinto = Form_menu_principal.grilla_conexiones.Rows(u).Cells(5).Value.ToString
                        rut_empresa = Form_menu_principal.grilla_conexiones.Rows(u).Cells(6).Value.ToString
                        recinto = Trim(Replace(recinto, "'", "´"))

                        If txt_direccion_cliente.Text = recinto Then
                            conexion.Close()
                            conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                            Try
                                SC.Connection = conexion
                                SC.CommandText = "insert into vale_traslado_recibidos (n_vale, despachador, codigo_producto, cantidad, fecha, hora, estado, usuario_responsable, sucursal, nombre, aplicacion, nro_tecnico, marca, cod_barra, familia, subfamilia, subfamilia2, cantidad_minima, precio, tipo_precio, factor, costo, rut_proveedor, fecha_ult_compra, cant_ult_compra, tipo_doc, nro_doc) values(" & (txt_factura.Text) & ", '" & (minombre) & "', '" & (VarCodProducto) & "','" & (VarCantidad) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','EMITIDA','" & (miusuario) & "','" & (mirecintoempresa) & "', '" & (nombre_traspaso) & "', '" & (aplicacion_traspaso) & "', '" & (nro_tecnico_traspaso) & "', '" & (marca_traspaso) & "', '" & (codigo_barra_traspaso) & "', '" & (codigo_familia_traspaso) & "', '" & (codigo_subfamilia_traspaso) & "', '" & (codigo_subfamilia_2_traspaso) & "', '" & (cantidad_minima_traspaso) & "', '" & (precio_traspaso) & "', '" & (tipo_precio_traspaso) & "', '" & (factor_traspaso) & "', '" & (costo_traspaso) & "', '" & (rut_proveedor_traspaso) & "', '" & (ultima_compra_traspaso) & "', '" & (cantidad_ultima_compra_traspaso) & "', '" & (tipo_doc_traspaso) & "', '" & (nro_doc_traspaso) & "')"
                                DA.SelectCommand = SC
                                DA.Fill(DT)

                            Catch mierror As MySqlException

                            Catch mierror As MissingManifestResourceException

                            End Try
                        End If
                    Next
                End If
            Next
        End If

        recuperar_conexion()
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

    Sub grabar_factura()
        Dim tipo_impresion As String
        tipo_impresion = ""

        If combo_venta.Text = "GUIA" Then

            If estado_guia_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If

            If txt_orden_de_compra.Text <> "SI" Then
                txt_orden_de_compra.Text = "0"
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into guia (n_guia, TIPO, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable,rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, desglose, vehiculo, patente) values (" & (txt_factura.Text) & " , '" & ("GUIA") & "', '" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (dtp_fecha.Text) & "','0'," & (txt_neto.Text) & "," & (txt_iva.Text) & ",'0'," & (txt_total.Text) & ",'" & (combo_condiciones.Text) & "','" & ("SIN FACTURAR") & "','" & (miusuario) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (mirecintoempresa) & "','" & ("0") & "','" & (Form_menu_principal.lbl_hora.Text) & "','0','" & (tipo_impresion) & "', '-','" & (Combo_vehiculo.Text) & "','" & (txt_patente.Text) & "')"
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
        Dim VarProveedor As String
        Dim VarCosto As Integer
        Dim VarSaldo As Integer

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

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select cantidad, proveedor , costo from productos where cod_producto='" & (VarCodProducto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarSaldo = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                VarProveedor = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                VarCosto = DS.Tables(DT.TableName).Rows(0).Item("costo")
                VarSaldo = VarSaldo - VarCantidad
            End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "insert into factura_temporal (n_factura,documento, codigo_producto, nombre_producto, numero_tecnico, cantidad, precio, porcentaje_desc, subtotal_detalle, total_detalle, NOMBRE_VENDEDOR) values('" & (txt_factura.Text) & "', '" & (combo_venta.Text) & "','" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarCantidad) & "," & (VarValorUnitario) & "," & (VarPorcentaje) & "," & (VarSubtotal) & "," & (VarTotal) & ",'" & (minombre) & "')"
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

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "insert into documento_temporal (cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, usuario, documento, condicion_venta, porcentaje_desc_total, rut_cliente, nombre_cliente, direccion_cliente, cod_cliente, descuento_1,descuento_2, giro_cliente, comuna_cliente, telefono_cliente, estado_cuenta, folio_cliente, email_cliente, ciudad_cliente, rut_cliente_retira, nombre_cliente_retira, orden_de_compra, tipo_documento) values( '" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "','" & (VarValorUnitario) & "','" & (VarCantidad) & "','" & (VarPorcentaje) & "','" & (VarDescuento) & "','" & (VarNeto) & "', '" & (VarIva) & "','" & (VarSubtotal) & "','" & (VarTotal) & "','" & (miusuario) & "','" & (combo_venta.Text) & "','" & (combo_condiciones.Text) & "','0','" & (txt_rut_cliente.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_direccion_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (txt_descuento_cliente.Text) & "','" & (txt_descuento_cliente_2.Text) & "','" & (txt_giro_cliente.Text) & "','" & (txt_comuna_cliente.Text) & "','" & (txt_telefono.Text) & "','" & (txt_cuenta_cliente.Text) & "','" & (txt_folio.Text) & "','" & (txt_correo_cliente.Text) & "','" & (txt_ciudad_cliente.Text) & "','" & (txt_rut_retira.Text) & "','" & (txt_nombre_retira.Text) & "','" & (txt_orden_de_compra.Text) & "','" & (txt_tipo_documento.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
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
                combo_venta.Text = DS.Tables(DT.TableName).Rows(0).Item("documento")
                combo_condiciones.Text = DS.Tables(DT.TableName).Rows(0).Item("condicion_venta")
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
                txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
                txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_rut_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente_retira")
                txt_nombre_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente_retira")
                txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_documento")
                txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
            End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "delete from documento_temporal where usuario='" & (miusuario) & "'"
            DA.Fill(DT)
            conexion.Close()
            calcular_totales()

        Catch err As InvalidCastException
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "delete from documento_temporal where usuario='" & (miusuario) & "'"
            DA.Fill(DT)
            conexion.Close()
            calcular_totales()
            txt_codigo.Focus()

        Catch err As ArgumentException
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "delete from documento_temporal where usuario='" & (miusuario) & "'"
            DA.Fill(DT)
            conexion.Close()
            calcular_totales()
            txt_codigo.Focus()
        End Try
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.Click

        Dim VarCodProducto As String
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            If VarCodProducto = "*" And combo_venta.Text <> "COTIZACION" Then
                MsgBox("EL CODIGO * SOLO PUEDE SER INGRESADO EN COTIZACIONES ", MsgBoxStyle.Critical, "INFORMACION")
                Exit Sub
            End If
        Next

        If grilla_detalle_venta.Rows.Count = 0 Then
            MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo.Focus()
            Exit Sub
        End If

        If combo_venta.Text = "" Then
            MsgBox("CAMPO TIPO DE VENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_venta.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        If Combo_vehiculo.Text = "" Then
            MsgBox("CAMPO VEHICULO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_vehiculo.Focus()
            Exit Sub
        End If

        If Combo_vehiculo.Text = "-" Then
            MsgBox("CAMPO VEHICULO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_vehiculo.Focus()
            Exit Sub
        End If

        If txt_patente.Text = "" Then
            MsgBox("CAMPO PATENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_patente.Focus()
            Exit Sub
        End If

        crear_numero_documento()
        imprimir()
    End Sub

    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.GotFocus
        combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles combo_venta.KeyDown
        If e.KeyCode = Keys.Enter Then
            combo_condiciones.Focus()
        End If
    End Sub

    Private Sub combo_venta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_venta.KeyPress
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

    Private Sub combo_venta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.LostFocus
        combo_venta.BackColor = Color.White
        If combo_venta.Text = "FACTURA DE CREDITO" Then
            combo_condiciones.Text = "CREDITO"
        End If

        If combo_venta.Text = "BOLETA DE CREDITO" Then
            combo_condiciones.Text = "CREDITO"
        End If

        If combo_venta.Text = "GUIA" And combo_condiciones.Text <> "TRASLADO" Then
            combo_condiciones.Text = "CREDITO"
        End If
    End Sub

    Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_clientes()
            mostrar_datos_clientes()
            limpiar_datos_clientes_retira()
            txt_rut_retira.Focus()
            grilla_detalle_venta.Rows.Clear()
        End If
    End Sub

    Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar_datos_clientes_retira()
    End Sub

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

    Private Sub combo_retira_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_datos_retira()
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

    Private Sub txt_cantidad_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White
    End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

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
        Form_buscador_clientes_guias_traslado.Show()
        Form_buscador_clientes_guias_traslado.txt_busqueda.Focus()
    End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        txt_codigo.Focus()
        Form_buscador_productos_guia_traslado.Show()
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
        End If
    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_clientes()
            guion_rut_cliente()
            mostrar_datos_clientes()
            limpiar_datos_clientes_retira()

            If combo_venta.Text = "BOLETA" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_codigo.Focus()
                End If
            End If

            If combo_venta.Text = "BOLETA DE CREDITO" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_codigo.Focus()
                End If
            End If

            If combo_venta.Text = "COTIZACION" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_codigo.Focus()
                End If
            End If

            If combo_venta.Text = "FACTURA" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_rut_retira.Focus()
                End If
            End If

            If combo_venta.Text = "FACTURA DE CREDITO" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_rut_retira.Focus()
                End If
            End If

            If combo_venta.Text = "GUIA" Then
                If txt_nombre_cliente.Text = "" And txt_direccion_cliente.Text = "" And txt_cod_cliente.Text = "" And txt_comuna_cliente.Text = "" Then
                    txt_rut_cliente.Focus()
                Else
                    txt_rut_retira.Focus()
                End If
            End If
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
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_clientes_guias_traslado.Show()
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
            txt_cantidad_etiquetas.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_agregar_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White
    End Sub

    Sub combo_retira_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txt_codigo.Focus()
        End If
    End Sub

    Private Sub btn_agregar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        Form_registro_clientes_ventas.Show()
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
            cargar_documento()
            calcular_totales()
            txt_cargar.Text = ""
            txt_codigo.Focus()
            txt_item.Text = grilla_detalle_venta.Rows.Count
        End If
    End Sub

    Private Sub txt_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cargar.LostFocus
        txt_cargar.BackColor = Color.White
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
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
        combo_venta.Focus()
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

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

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
            calcular_totales()
            btn_grabar.Focus()
        End If
    End Sub

    Private Sub combo_condiciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_condiciones.SelectedIndexChanged
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

    Private Sub txt_cantidad_agregar_LostFocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White

        Dim primer_caracter As String
        Dim ultimo_caracter As String
        Dim total_caracter As String
        total_caracter = ""

        If txt_cantidad_agregar.Text = "" Then
            primer_caracter = 0
            ultimo_caracter = 0
        Else
            primer_caracter = txt_cantidad_agregar.Text.Length - txt_cantidad_agregar.Text.Length + 1
            ultimo_caracter = txt_cantidad_agregar.Text.Length
            total_caracter = txt_cantidad_agregar.Text
        End If

        Dim n1 As Byte, lMal As Boolean

        If txt_cantidad_agregar.Text <> "" Then
            For n1 = ultimo_caracter To ultimo_caracter
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_cantidad_agregar.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next

            For n1 = 1 To 1
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_cantidad_agregar.Focus()
                    lMal = True
                    Exit Sub

                End If
            Next
        End If
    End Sub

    Private Sub txt_cantidad_agregar_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.TextChanged
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, "  ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, "   ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, "    ", ""))

        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, "  ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, "   ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, "    ", ""))

        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, "  ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, "   ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, "    ", ""))

        If txt_cantidad_agregar.Text = "0" Then
            txt_cantidad_agregar.SelectionStart = 0
            txt_cantidad_agregar.SelectionLength = Len(txt_cantidad_agregar.Text)
        End If
    End Sub

    Private Sub Combo_codigo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_productos()
            mostrar_cantidad_real()
            mostrar_nombre_proveedor()
            txt_cantidad_agregar.Text = ""
            ' Radio_codigo_interno.Checked = True
            txt_cantidad_agregar.Focus()
        End If
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

    Private Sub btn_buscar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.LostFocus
        btn_buscar_clientes.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_productos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_buscar_productos.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imagen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_imagen.BackColor = Color.Transparent
    End Sub

    Private Function ReturnDataSet() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet
        Dim Total_letra As Integer
        Dim Comprobar_letra As Integer

        Total_letra = (txt_total.Text) / (txt_cargar.Text)
        Comprobar_letra = (Total_letra) * (txt_cargar.Text)
        Comprobar_letra = (txt_total.Text) - (Comprobar_letra)
        Total_letra = (Total_letra) + (Comprobar_letra)
        Round(Total_letra)

        dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nro_doc", GetType(String)))
        dt.Columns.Add(New DataColumn("documento_referencia", GetType(String)))
        dt.Columns.Add(New DataColumn("monto_total", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nro_letra", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("ciudad_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("monto_letra", GetType(Integer)))
        dt.Columns.Add(New DataColumn("desglose", GetType(String)))
        dt.Columns.Add(New DataColumn("girador", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
        dr = dt.NewRow()

        Try
            dr("Imagen") = ImageToByte(Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg"))
        Catch
        End Try

        dr("nro_doc") = txt_nro_letra.Text
        dr("nro_letra") = cantidad_letras & " DE " & txt_cargar.Text
        dr("documento_referencia") = combo_venta.Text & " NRO. " & txt_factura.Text
        dr("fecha") = dtp_letra.Text
        dr("rut_cliente") = txt_rut_cliente.Text
        dr("nombre_cliente") = txt_nombre_cliente.Text
        dr("telefono_cliente") = txt_telefono.Text
        dr("ciudad_cliente") = txt_ciudad_cliente.Text
        dr("direccion_cliente") = txt_direccion_cliente.Text
        dr("monto_letra") = Total_letra
        dr("monto_total") = txt_total.Text
        dr("desglose") = desglose_valor
        dr("girador") = minombreempresa
        dr("nombre_empresa") = minombreempresa
        dr("giro_empresa") = migiroempresa
        dr("direccion_empresa") = midireccionempresa
        dr("comuna_empresa") = micomunaempresa
        dr("telefono_empresa") = mitelefonoempresa
        dr("correo_empresa") = micorreoempresa
        dr("rut_empresa") = mirutempresa
        dt.Rows.Add(dr)
        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "Letra"

        Dim iDS As New dsletra
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS
    End Function

    Private Function ReturnDataSetCotizacion() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("nro_cotizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_cotizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
        dt.Columns.Add(New DataColumn("total", GetType(Integer)))
        dt.Columns.Add(New DataColumn("numero_tecnico", GetType(String)))
        dt.Columns.Add(New DataColumn("subtotal_final", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descuento_final", GetType(Integer)))
        dt.Columns.Add(New DataColumn("total_final", GetType(Integer)))
        dt.Columns.Add(New DataColumn("forma_de_pago", GetType(String)))
        dt.Columns.Add(New DataColumn("precio", GetType(Integer)))

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
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer

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
            dr = dt.NewRow()

            Try
                dr("Imagen") = ImageToByte(Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg"))
            Catch
            End Try

            dr("nombre_empresa") = minombreempresa
            dr("giro_empresa") = migiroempresa
            dr("direccion_empresa") = midireccionempresa
            dr("comuna_empresa") = micomunaempresa
            dr("telefono_empresa") = mitelefonoempresa
            dr("correo_empresa") = micorreoempresa
            dr("rut_empresa") = mirutempresa
            dr("nro_cotizacion") = txt_factura.Text
            dr("fecha_cotizacion") = Form_menu_principal.dtp_fecha.Text
            dr("nombre_vendedor") = minombre
            dr("telefono_vendedor") = mitelefono
            dr("codigo") = VarCodProducto
            dr("descripcion") = varnombre
            dr("cantidad") = " X " & VarCantidad & " ="
            dr("total") = VarTotal
            dr("numero_tecnico") = vartecnico
            dr("total_final") = txt_total.Text
            dr("forma_de_pago") = combo_condiciones.Text
            dr("precio") = VarValorUnitario
            dt.Rows.Add(dr)
        Next

        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "CotizacionTicket"
        Dim iDS As New dsCotizacionTicket
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

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage

        If estado_impresion <> "LISTO" Then
            Dim Fuente As Font
            Fuente = New Font("GothicE", 50, FontStyle.Bold)
            Dim Fuente1 As Font
            Fuente1 = New Font("Arial", 12, FontStyle.Bold)
            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center
            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far
            Dim margen As String
            margen = margen_etiqueta_1
            Dim rect1 As New Rectangle(margen + 5, 1, 294, 10)
            '(left,top,whidth,height )
            Dim rect2 As New Rectangle(margen + 5, 54, 294, 40)
            e.Graphics.DrawString(mititularetiquetaempresa, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, rect1, stringFormat)
            Dim descripcion_caracteres As String
            descripcion_caracteres = txt_nombre_producto.Text

            If descripcion_caracteres.Length > 34 Then
                descripcion_caracteres = descripcion_caracteres.Substring(0, 34)
            End If

            Dim descripcion_aplicacion As String
            descripcion_aplicacion = txt_aplicacion.Text
            If descripcion_aplicacion.Length > 34 Then
                descripcion_aplicacion = descripcion_aplicacion.Substring(0, 34)
            End If

            Dim descripcion_tecnico As String
            descripcion_tecnico = txt_numero_tecnico.Text
            If descripcion_tecnico.Length > 27 Then
                descripcion_tecnico = descripcion_tecnico.Substring(0, 27)
            End If

            e.Graphics.DrawString(descripcion_caracteres, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 15)
            e.Graphics.DrawString(descripcion_aplicacion, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 27)
            e.Graphics.DrawString(descripcion_tecnico, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 39)

            If txt_factor.Text <> "0" And txt_factor.Text <> "" Then
                e.Graphics.DrawString(txt_factor.Text, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 242, 39, format1)
            End If

            e.Graphics.DrawString("*" & (txt_codigo.Text) & "*", New Font("C39HrP36DlTt", 30), Brushes.Black, rect2, stringFormat)

            e.HasMorePages = False
            'Fuerza a que se liberen los recursos.
            Fuente.Dispose()
            Exit Sub
        End If

        If estado_impresion = "LISTO" Then
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

            If Me.combo_venta.Text = "GUIA" Then
                If mirutempresa = "87686300-6" Then
                    e.Graphics.DrawString(Me.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 100, 20)
                    e.Graphics.DrawString(Me.txt_factura.Text, Font10, Brushes.Black, 550, 20, format1)
                    e.Graphics.DrawString(Me.txt_nombre_cliente.Text, Font10, Brushes.Black, 100, 36)
                    e.Graphics.DrawString(Me.txt_folio.Text, Font10, Brushes.Black, 550, 36, format1)
                    e.Graphics.DrawString(Me.txt_direccion_cliente.Text, Font10, Brushes.Black, 100, 52)

                    If Me.txt_descuento_cliente_2.Text <> "0" Then
                        e.Graphics.DrawString("-" & Me.txt_descuento_cliente_2.Text & "%", Font10, Brushes.Black, 550, 52, format1)
                    End If

                    e.Graphics.DrawString(Me.txt_giro_cliente.Text, Font10, Brushes.Black, 100, 68)
                    e.Graphics.DrawString(Me.txt_rut_cliente.Text, Font10, Brushes.Black, 655, 20)
                    e.Graphics.DrawString(Me.txt_comuna_cliente.Text, Font10, Brushes.Black, 655, 36)
                    e.Graphics.DrawString(Me.txt_telefono.Text, Font10, Brushes.Black, 655, 52)
                    e.Graphics.DrawString(Me.combo_condiciones.Text, Font10, Brushes.Black, 655, 68)
                    e.Graphics.DrawString(minombre, Font10, Brushes.Black, 655, 84)

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

                    Dim neto_millar As String
                    Dim iva_millar As String
                    Dim total_millar As String

                    neto_millar = Me.txt_neto.Text
                    iva_millar = Me.txt_iva.Text
                    total_millar = Me.txt_total.Text

                    neto_millar = Format(Int(neto_millar), "###,###,###")
                    iva_millar = Format(Int(iva_millar), "###,###,###")
                    total_millar = Format(Int(total_millar), "###,###,###")

                    e.Graphics.DrawString(Me.txt_nombre_retira.Text, Font8, Brushes.Black, 55, 540)
                    e.Graphics.DrawString(Me.txt_rut_retira.Text, Font8, Brushes.Black, 265, 540)
                    e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 510, 540)
                    e.Graphics.DrawString(Me.dtp_fecha.Text, Font8, Brushes.Black, 797, 540, format1)
                End If

                If mirutempresa = "81921000-4" Then
                    e.Graphics.DrawString("NRO. GUIA: " & txt_factura.Text & ", PROVIENE DE: " & mirecintoempresa & " , BULTOS: " & txt_productos.Text, Font10, Brushes.Black, 0, 0)
                    'e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 85, 0)
                    e.Graphics.DrawString(dtp_fecha.Value.Day & "          " & dtp_fecha.Value.Month & "         " & dtp_fecha.Value.Year, Font10, Brushes.Black, 620, 0)
                    e.Graphics.DrawString(txt_nombre_cliente.Text, Font10, Brushes.Black, 80, 40)
                    e.Graphics.DrawString(txt_direccion_cliente.Text, Font10, Brushes.Black, 80, 57)
                    e.Graphics.DrawString(txt_giro_cliente.Text, Font10, Brushes.Black, 80, 74)
                    e.Graphics.DrawString(txt_telefono.Text, Font10, Brushes.Black, 80, 91)
                    e.Graphics.DrawString(Combo_vehiculo.Text, Font10, Brushes.Black, 80, 108)
                    e.Graphics.DrawString(txt_rut_cliente.Text, Font10, Brushes.Black, 550, 40)
                    e.Graphics.DrawString(txt_comuna_cliente.Text, Font10, Brushes.Black, 550, 57)
                    e.Graphics.DrawString(txt_ciudad_cliente.Text, Font10, Brushes.Black, 550, 74)
                    e.Graphics.DrawString(combo_condiciones.Text, Font10, Brushes.Black, 550, 91)
                    e.Graphics.DrawString(txt_patente.Text, Font10, Brushes.Black, 550, 108)

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

                        e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 190 + (i * 15))
                        e.Graphics.DrawString(varnombre & " " & vartecnico, Font8, Brushes.Black, 130, 190 + (i * 15))
                        e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 570, 190 + (i * 15), format1)
                        e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 730, 190 + (i * 15), format1)
                    Next

                    e.Graphics.DrawString("GUIA DE TRANSPORTE, NO CONSTITUYE VENTA", Font9, Brushes.Black, 35, 650)
                    e.Graphics.DrawString("NOMBRE: " & txt_nombre_retira.Text & " RUT: " & txt_rut_retira.Text, Font9, Brushes.Black, 35, 670)
                End If
            End If
        End If
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
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
            Form_buscador_clientes_retira_guias_traslado.Show()
            Me.Enabled = False
        End If

        If e.KeyCode = Keys.F6 Then
            Form_registro_cliente_retira_guias_traslado.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_rut_retira_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_retira.LostFocus
        txt_rut_retira.BackColor = Color.White
    End Sub
    Private Sub txt_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cargar.GotFocus
        txt_cargar.BackColor = Color.LightSkyBlue
        combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_retira_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_retira.TextChanged

    End Sub

    Private Sub txt_cargar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cargar.TextChanged

    End Sub

    Sub crear_archivo_plano()
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
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
        If nombre_cliente.Length > 99 Then
            nombre_cliente = nombre_cliente.Substring(0, 100)
        End If

        Dim giro_cliente As String
        giro_cliente = txt_giro_cliente.Text
        If giro_cliente.Length > 39 Then
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

        If combo_venta.Text = "FACTURA" Then
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
                                           & "33" & ";" & (txt_factura.Text) & ";" & (dtp_fecha.Text) & ";" & "0" & ";" & "0" & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (minombre) & ";" & (txt_rut_retira.Text) & ";" & (txt_nombre_retira.Text) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
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

                strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
                                            & "1" & ";" & "801" & ";0;;" & "0" & ";" & "-" & ";" & vbNewLine _
                                            & "->DescRec<-" & vbNewLine _
                                            & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";'0';" & "0" & ";" & vbNewLine _
                                            & "->Observacion<-" & vbNewLine _
                                            & txt_folio.Text & ";" & combo_condiciones.Text & ";")

                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("Error al Guardar la informacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If

        If combo_venta.Text = "FACTURA DE CREDITO" Then
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
                                           & "33" & ";" & (txt_factura.Text) & ";" & (dtp_fecha.Text) & ";" & "0" & ";" & "0" & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (minombre) & ";" & (txt_rut_retira.Text) & ";" & (txt_nombre_retira.Text) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
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

                strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
                                            & "1" & ";" & "801" & ";0;;" & "0" & ";" & "-" & ";" & vbNewLine _
                                            & "->DescRec<-" & vbNewLine _
                                            & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";0;" & "0" & ";" & vbNewLine _
                                            & "->Observacion<-" & vbNewLine _
                                            & txt_folio.Text & ";" & combo_condiciones.Text & ";")
                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("Error al Guardar la informacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If
    End Sub

    Sub crear_encabezado()
        Dim encabezado As String
        encabezado = ""

        If combo_venta.Text = " FACTURA" Then
            encabezado = "30"
        End If
        If combo_venta.Text = "FACTURA EXENTA" Then
            encabezado = "32"
        End If
        If combo_venta.Text = "FACTURA ELECTRONICA" Then
            encabezado = "33"
        End If
        If combo_venta.Text = "FACTURA EXENTA ELECTRONICA" Then
            encabezado = "34"
        End If
        If combo_venta.Text = "LIQUIDACION FACTURA" Then
            encabezado = "40"
        End If
        If combo_venta.Text = "FACTURA DE COMPRA" Then
            encabezado = "45"
        End If
        If combo_venta.Text = "FACTURA DE COMPRA ELECTRONICA" Then
            encabezado = "46"
        End If
        If combo_venta.Text = "GUIA DE DESPACHO" Then
            encabezado = "50"
        End If
        If combo_venta.Text = "GUIA DE DESPACHO ELECTRONICA" Then
            encabezado = "52"
        End If
        If combo_venta.Text = "NOTA DE DEBITO" Then
            encabezado = "55"
        End If
        If combo_venta.Text = "NOTA DE DEBITO ELECTRONICA" Then
            encabezado = "56"
        End If
        If combo_venta.Text = "NOTA DE CREDITO" Then
            encabezado = "60"
        End If
        If combo_venta.Text = "NOTA DE CREDITO ELECTRONICA" Then
            encabezado = "61"
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

        'If e.KeyChar = "*" Then
        '    e.KeyChar = ""
        'End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If

        If txt_codigo.Text = "*" Then
            combo_venta.Text = "COTIZACION"
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If txt_codigo.Text = "" Then
                Exit Sub
            End If

            If txt_codigo.Text = "*" Then
                limpiar_datos_productos()
                combo_venta.Text = "COTIZACION"
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
                Form_buscador_productos_guia_traslado.Show()
                Form_buscador_productos_guia_traslado.buscar_codigo()
                Exit Sub
            End If

            limpiar_datos_productos()
            mostrar_cantidad_real()
            mostrar_nombre_proveedor()

            If txt_codigo.Text <> "" And txt_nombre_producto.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MsgBoxStyle.Critical, "INFORMACION")
                txt_codigo.Focus()
            Else
                txt_cantidad_agregar.Text = "1"
                txt_cantidad_agregar.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_codigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_productos_guia_traslado.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_codigo_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
        If txt_codigo.Text = "*" Then
            limpiar_datos_productos()
            combo_venta.Text = "COTIZACION"
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

    Private Sub btn_buscar_productos_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_buscar_productos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_productos_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_buscar_productos.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imagen_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_imagen.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imagen_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
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

    Private Sub txt_porcentaje_desc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calcular_totales()
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

    Private Sub txt_precio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.TextChanged
        If txt_precio_modificado.Text = "0" Then
            txt_precio_modificado.SelectionStart = 0
            txt_precio_modificado.SelectionLength = Len(txt_precio_modificado.Text)
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

    Private Sub btn_buscar_retira_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        conexion.Close()
        Form_buscador_clientes_retira.Show()
    End Sub

    Private Sub btn_mensaje_cliente_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub txt_patente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_patente.GotFocus
        txt_patente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_patente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_patente.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txt_patente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_patente.LostFocus
        txt_patente.BackColor = Color.White
    End Sub

    Private Sub Combo_vehiculo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vehiculo.GotFocus
        Combo_vehiculo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_vehiculo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vehiculo.LostFocus
        Combo_vehiculo.BackColor = Color.White
    End Sub

    Private Sub btn_agregar_retira_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_retira.Click
        Me.Enabled = False
        Form_registro_cliente_retira_guias_traslado.Show()
    End Sub

    Private Sub btn_buscar_retira_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_retira.Click
        Me.Enabled = False
        conexion.Close()
        Form_buscador_clientes_retira_guias_traslado.Show()
    End Sub

    Private Sub txt_cantidad_etiquetas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_etiquetas.GotFocus
        txt_cantidad_etiquetas.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_etiquetas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_etiquetas.KeyPress
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
            btn_agregar.PerformClick()
        End If
    End Sub

    Private Sub txt_cantidad_etiquetas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_etiquetas.LostFocus
        txt_cantidad_etiquetas.BackColor = Color.White
    End Sub

    Sub imprimir_etiquetas()
        Dim cantidad_etiquetas As Integer

        If txt_cantidad_etiquetas.Text = "0" Or txt_cantidad_etiquetas.Text = "" Then
            cantidad_etiquetas = 0
        Else
            cantidad_etiquetas = txt_cantidad_etiquetas.Text
        End If

        If cantidad_etiquetas <> "0" Then
            With Pd.PrinterSettings
                .PrinterName = impresora_etiquetas
                .Copies = cantidad_etiquetas
                .PrintRange = PrintRange.AllPages
                If .IsValid Then
                    Me.Pd.PrintController = New StandardPrintController
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 300, 99)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                    Pd.Print()
                Else
                End If
            End With
        End If
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub


    Private Sub btn_imagen_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_buscar_productos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.Click
        Me.Enabled = False
        conexion.Close()
        txt_codigo.Focus()
        Form_buscador_productos_guia_traslado.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class