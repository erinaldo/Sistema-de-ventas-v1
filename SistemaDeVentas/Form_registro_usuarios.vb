Imports System.IO
Imports System.Drawing.Drawing2D

Public Class form_registro_usuarios
    Dim VarSeleccion As Integer
    Dim MiPos As Integer

    Private Sub form_registro_usuarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub form_registro_usuarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenar_combo_area()
        actualizar_tabla()
        mostrar(0)
        conexion.Close()
        controles(False, True)
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
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



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If VarSeleccion = 1 Then
                guion_rut()
                txt_nombre.Focus()
            End If
            If VarSeleccion = 2 Then
                guion_rut()
                mostrar_datos_usuarios()
            End If
        End If
    End Sub

    Sub guion_rut()
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

    Sub llenar_combo_area()
        Combo_area.Items.Clear()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select nombre_area from area_usuario ORDER BY nombre_area"

        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                Combo_area.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("nombre_area"))
            Next
            Combo_area.Items.Add("-")
            Combo_area.SelectedItem = "-"
            conexion.Close()
        End If
    End Sub



    Private Sub txt_rut_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.Validated
        'If valida_rut(txt_rut.Text) = False Then
        '    txt_rut.Focus()
        '    txt_rut.SelectAll()
        'End If
    End Sub

    Sub mostrar(ByVal i As Integer)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_rut.Text = DS.Tables(DT.TableName).Rows(i).Item("Rut_usuario")
            txt_nombre.Text = DS.Tables(DT.TableName).Rows(i).Item("Nombre_usuario")
            txt_login.Text = DS.Tables(DT.TableName).Rows(i).Item("Usuario")
            txt_clave.Text = DS.Tables(DT.TableName).Rows(i).Item("Clave")
            txt_repita_clave.Text = DS.Tables(DT.TableName).Rows(i).Item("Clave")
            combo_tipo.Text = DS.Tables(DT.TableName).Rows(i).Item("tipo_usuario")
            Combo_area.Text = DS.Tables(DT.TableName).Rows(i).Item("area_usuario")
            combo_pregunta.Text = DS.Tables(DT.TableName).Rows(i).Item("pregunta_usuario")
            txt_respuesta.Text = DS.Tables(DT.TableName).Rows(i).Item("respuesta_usuario")
            txt_telefono.Text = DS.Tables(DT.TableName).Rows(i).Item("telefono_usuario")
            Try
                Combo_autoriza_venta.Text = DS.Tables(DT.TableName).Rows(i).Item("autoriza_venta")
            Catch
                Combo_autoriza_venta.Text = "-"
            End Try
            Try
                txt_tiempo_espera.Text = DS.Tables(DT.TableName).Rows(i).Item("tiempo_espera")
            Catch
                txt_tiempo_espera.Text = "99"
            End Try
            Try
                Combo_activo.Text = DS.Tables(DT.TableName).Rows(i).Item("activo")
            Catch
                Combo_activo.Text = "SI"
            End Try
        End If
    End Sub

    Sub mostrar_datos_usuarios()

        If txt_rut.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where rut_usuario ='" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("Rut_usuario")
                txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("Nombre_usuario")
                txt_login.Text = DS.Tables(DT.TableName).Rows(0).Item("Usuario")
                txt_clave.Text = DS.Tables(DT.TableName).Rows(0).Item("Clave")
                txt_repita_clave.Text = DS.Tables(DT.TableName).Rows(0).Item("Clave")
                combo_tipo.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_usuario")
                Combo_area.Text = DS.Tables(DT.TableName).Rows(0).Item("area_usuario")
                combo_pregunta.Text = DS.Tables(DT.TableName).Rows(0).Item("pregunta_usuario")
                txt_respuesta.Text = DS.Tables(DT.TableName).Rows(0).Item("respuesta_usuario")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_usuario")
                Combo_autoriza_venta.Text = DS.Tables(DT.TableName).Rows(0).Item("autoriza_venta")
                txt_tiempo_espera.Text = DS.Tables(DT.TableName).Rows(0).Item("tiempo_espera")
                Combo_activo.Text = DS.Tables(DT.TableName).Rows(0).Item("activo")
                txt_rut.Enabled = False

                txt_login.Enabled = False
                combo_tipo.Enabled = False



                '  txt_rut.Enabled = False
                ' txt_login.Enabled = False
                txt_nombre.Enabled = True
                txt_telefono.Enabled = True
                combo_pregunta.Enabled = True
                txt_clave.Enabled = True
                txt_repita_clave.Enabled = True
                ' combo_tipo.Enabled = False

                Combo_autoriza_venta.Enabled = True
                txt_tiempo_espera.Enabled = True


                Combo_activo.Enabled = True
                Combo_area.Enabled = True
                txt_respuesta.Enabled = True
                combo_pregunta.Enabled = True
                btn_guardar.Enabled = True
                txt_rut.Focus()
                txt_nombre.Focus()
            Else
                MsgBox("RUT DE USUARIO NO EXISTENTE", 0 + 16, "ERROR")
                conexion.Close()
                Exit Sub
            End If
            conexion.Close()
        End If
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        btn_eliminar.Enabled = b
        btn_modificar.Enabled = b
        'btn_buscar.Enabled = b
        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a
        btn_imprimir.Enabled = b
        combo_tipo.Enabled = a
        txt_rut.Enabled = a
        txt_login.Enabled = a
        txt_nombre.Enabled = a
        txt_telefono.Enabled = a
        combo_pregunta.Enabled = a
        txt_clave.Enabled = a
        txt_repita_clave.Enabled = a
        combo_tipo.Enabled = a
        Combo_area.Enabled = a
        txt_respuesta.Enabled = a
        combo_pregunta.Enabled = a
        Combo_autoriza_venta.Enabled = a
        txt_tiempo_espera.Enabled = a
        Combo_activo.Enabled = a
        btn_primero.Enabled = b
        btn_ultimo.Enabled = b
        btn_siguiente.Enabled = b
        btn_anterior.Enabled = b
    End Sub

    Sub limpiar()
        txt_rut.Text = ""
        txt_nombre.Text = ""
        txt_login.Text = ""
        txt_clave.Text = ""
        txt_repita_clave.Text = ""
        combo_tipo.Text = ""
        Combo_area.Text = ""
        txt_respuesta.Text = ""
        combo_pregunta.Text = ""
        combo_tipo.Text = ""
        txt_telefono.Text = ""
        Combo_autoriza_venta.Text = ""
        txt_tiempo_espera.Text = "60"
        Combo_activo.Text = "SI"
    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
        controles(True, False)
        VarSeleccion = 1
        txt_rut.Focus()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        controles(True, False)

        VarSeleccion = 2
        txt_rut.Enabled = True
        txt_login.Enabled = False
        combo_tipo.Enabled = False



        ' txt_rut.Enabled = False
        ' txt_login.Enabled = False
        txt_nombre.Enabled = False
        txt_telefono.Enabled = False
        combo_pregunta.Enabled = False
        txt_clave.Enabled = False
        txt_repita_clave.Enabled = False
        ' combo_tipo.Enabled = False
        Combo_area.Enabled = False
        txt_respuesta.Enabled = False
        combo_pregunta.Enabled = False
        btn_guardar.Enabled = False
        Combo_autoriza_venta.Enabled = False
        txt_tiempo_espera.Enabled = False
        Combo_activo.Enabled = False
        txt_rut.Focus()









    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_rut.Focus()
            Exit Sub
        End If

        If txt_nombre.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre.Focus()
            Exit Sub
        End If

        If txt_login.Text = "" Then
            MsgBox("CAMPO LOGIN VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_login.Focus()
            Exit Sub
        End If

        If txt_clave.Text = "" Then
            MsgBox("CAMPO CLAVE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_clave.Focus()
            Exit Sub
        End If

        If txt_repita_clave.Text = "" Then
            MsgBox("POR SEGURIDAD, REPITA SU CLAVE", 0 + 16, "ERROR")
            txt_repita_clave.Focus()
            Exit Sub
        End If

        If txt_clave.Text <> txt_repita_clave.Text Then
            MsgBox("LAS CLAVES NO COINCIDEN", 0 + 16, "ERROR")
            txt_clave.Text = ""
            txt_repita_clave.Text = ""
            txt_clave.Focus()
            Exit Sub
        End If

        If txt_telefono.Text = "" Then
            MsgBox("CAMPO AREA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_telefono.Focus()
            Exit Sub
        End If


        If combo_tipo.Text = "" Then
            MsgBox("CAMPO TIPO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_tipo.Focus()
            Exit Sub
        End If

        If Combo_area.Text = "" Then
            MsgBox("CAMPO AREA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_area.Focus()
            Exit Sub
        End If

        If combo_pregunta.Text = "" Then
            MsgBox("CAMPO PREGUNTA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_pregunta.Focus()
            Exit Sub
        End If

        If txt_respuesta.Text = "" Then
            MsgBox("CAMPO RESPUESTA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_respuesta.Focus()
            Exit Sub
        End If

        If Combo_autoriza_venta.Text = "" Then
            MsgBox("CAMPO AUTORIZA VENTA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_autoriza_venta.Focus()
            Exit Sub
        End If

        If txt_tiempo_espera.Text = "" Then
            MsgBox("CAMPO TIEMPO DE ESPERA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_tiempo_espera.Focus()
            Exit Sub
        End If

        If Combo_activo.Text = "" Then
            MsgBox("CAMPO ESTADO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_activo.Focus()
            Exit Sub
        End If








        If VarSeleccion = 1 Then
            conexion.Close()
            Consultas_SQL("select * from usuarios where rut_usuario = '" & (txt_rut.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                MsgBox("RUT DE USUARIO EXISTENTE", 0 + 16, "Error")
                controles(True, False)
                Exit Sub
            End If


            conexion.Close()
            Consultas_SQL("select * from usuarios where usuario = '" & (txt_login.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                MsgBox("RUT DE USUARIO EXISTENTE", 0 + 16, "Error")
                controles(True, False)
                Exit Sub
            End If



            If valida_rut(txt_rut.Text) = False Then
                txt_rut.Focus()
                txt_rut.SelectAll()
                Exit Sub
            End If









            SC.Connection = conexion
            SC.CommandText = "INSERT INTO  usuarios (rut_usuario, nombre_usuario, usuario, clave, tipo_usuario, area_usuario, pregunta_usuario, respuesta_usuario, telefono_usuario, autoriza_venta, tiempo_espera, fecha_modificacion, activo) VALUES ('" & (txt_rut.Text) & "','" & (txt_nombre.Text) & "','" & (txt_login.Text) & "','" & (txt_clave.Text) & "','" & (combo_tipo.Text) & "','" & (Combo_area.Text) & "','" & (combo_pregunta.Text) & "','" & (txt_respuesta.Text) & "','" & (txt_telefono.Text) & "','" & (Combo_autoriza_venta.Text) & "','" & (txt_tiempo_espera.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (Combo_activo.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('USUARIOS','CREACION DE USUARIO','" & (txt_nombre.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            actualizar_tabla()
            controles(False, True)
            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            If combo_tipo.Text = "USUARIO DEL SISTEMA" Then
                'SC.CommandText = "INSERT INTO  usuarios (rut_usuario, nombre_usuario, usuario, clave, TIPO, area, pregunta, respuesta, telefono) VALUES ('" & (txt_rut.Text) & "','" & (txt_nombre.Text) & "','" & (txt_login.Text) & "','" & (txt_clave.Text) & "','" & (combo_tipo.Text) & "','" & (Combo_area.Text) & "','" & (combo_pregunta.Text) & "','" & (txt_respuesta.Text) & "','" & (txt_telefono.Text) & "')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "insert into permisos (rut_usuario, clientes, usuarios, proveedores,  productos, retiradores, ventas, compras, etiquetas, cartola_kardex, cambio_vendedor, facturacion, pagos, estados_decuenta, deudores, nota_de_credito, envio_garantias, caja_diaria, corregir_doc, comisiones, stock_minimo, fac_vencidas, credenciales, permisos, numeracion, imputar_pagos, estadisticas, impresoras, familias, subfamilias, empresa, respaldo, cuentas_corrientes, libro_de_compras, resumen_libro_de_compras, libro_de_ventas, resumen_libro_de_ventas , menu_adquisiciones , menu_administracion, menu_contabilidad, menu_mantenedores, menu_bodega, menu_ventas, menu_configuracion, menu_ayuda, menu_acerca_de, reporte_libro_de_compras, realizar_pedidos, mis_pedidos, revision_de_pedidos, confirmacion_de_llegada, buscar_facturas,liquidaciones_de_sueldo, impuesto_unico, cargas_de_asignacion_familiar,cotizacion_formal,estado_de_cuenta_por_rango,notas_de_credito,enviar_cotizacion,stock_y_ubicaciones,trabajadores,empresas,marcas, reimprimir_liquidaciones_de_sueldo,control_meses,libro_remuneraciones,valores, agregar_afp, proveedores_mas_pedidos,buscar_totales, CORREGIR_numeros, ingreso_manual_de_ventas, ingreso_de_creditos,  agregar_abonos, traspaso_de_stock, imputar_notas_de_credito, imputar_abono, codigos_de_barra, comision_servicios, envio_a_sucursal, inventario, cambio_de_productos, mis_cotizaciones, ruta_para_archivos_planos, ruta_para_imagenes_de_sistema, bitacora_de_cambios, detalle_de_ventas, detalle_de_ventas_por_doc, cuentas_por_cobrar, historial_de_cuenta, nota_de_debito, ticket_de_ventas, tarjetas_de_presentacion, consultas_sql, personalizar_sistema, estado_de_deudas, reservas, subfamilia2, detalle_compras, detalle_compras_por_doc, guia_de_traslado, registro_de_autorizaciones, ventas_asistidas, asignar_familias, actualizar_stock, traspaso_de_creditos_a_historico,traspasar_stock_fisico, adm_vales_de_cambio,hojas_foleadas, administrar_servicios_de_lubricentro, servicios_de_lubricentro, existencias, reposicion_de_ventas) values('" & (txt_rut.Text) & "','DESHABILITADO','DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO',  'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO', 'DESHABILITADO',  'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO' ,  'DESHABILITADO' ,  'DESHABILITADO' ,  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO',  'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO', 'DESHABILITADO')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into permisos (rut_usuario) values('" & (txt_rut.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                '  MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

                'Else
                '    If combo_tipo.Text = "ADMINISTRADOR DEL SISTEMA" Then

                '        SC.CommandText = "INSERT INTO  usuarios (rut_usuario, nombre_usuario, usuario, clave, TIPO, area, pregunta, respuesta, telefono) VALUES ('" & (txt_rut.Text) & "','" & (txt_nombre.Text) & "','" & (txt_login.Text) & "','" & (txt_clave.Text) & "','" & (combo_tipo.Text) & "','" & (Combo_area.Text) & "','" & (combo_pregunta.Text) & "','" & (txt_respuesta.Text) & "','" & (txt_telefono.Text) & "')"
                '        DA.SelectCommand = SC
                '        DA.Fill(DT)
                '        actualizar_tabla()
                '        controles(False, True)

                '        SC.CommandText = "insert into permisos (rut_usuario, clientes, usuarios, proveedores,  productos, retiradores, ventas, compras, etiquetas, cartola_kardex, cambio_vendedor, facturacion, pagos, estados_decuenta, deudores, nota_de_credito, envio_garantias, caja_diaria, corregir_doc, comisiones, stock_minimo, fac_vencidas, credenciales, permisos, numeracion, imputar_pagos, estadisticas) values('" & (txt_rut.Text) & "','HABILITADO','HABILITADO', 'HABILITADO', 'HABILITADO', 'HABILITADO', 'HABILITADO', 'HABILITADO',  'HABILITADO', 'HABILITADO', 'HABILITADO',  'HABILITADO',  'HABILITADO',  'HABILITADO',  'HABILITADO',  'HABILITADO', 'HABILITADO',  'HABILITADO', 'HABILITADO', 'HABILITADO' ,  'HABILITADO' ,  'HABILITADO' ,  'HABILITADO',  'HABILITADO',  'HABILITADO',  'HABILITADO',  'HABILITADO')"
                '        DA.SelectCommand = SC
                '        DA.Fill(DT)
                '        MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")


            End If
        End If

        '  End If


        If VarSeleccion = 2 Then

            'Consultas_SQL("select * from usuarios where usuario = '" & (txt_login.Text) & "'")
            'If DS.Tables(DT.TableName).Rows.Count > 0 Then
            '    MsgBox("LOGIN DE USUARIO EXISTENTE", 0 + 16, "ERROR")
            '    controles(True, False)
            'Else

            SC.CommandText = "UPDATE usuarios SET NOMBRE_USUARIO='" & (txt_nombre.Text) & "', Usuario='" & (txt_login.Text) & "',Clave = '" & (txt_clave.Text) & "',tipo_usuario = '" & (combo_tipo.Text) & "',area_usuario = '" & (Combo_area.Text) & "', respuesta_usuario = '" & (txt_respuesta.Text) & "' ,telefono_usuario = '" & (txt_telefono.Text) & "' ,pregunta_usuario = '" & (combo_pregunta.Text) & "',autoriza_venta = '" & (Combo_autoriza_venta.Text) & "',tiempo_espera = '" & (txt_tiempo_espera.Text) & "',activo = '" & (Combo_activo.Text) & "', fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "'   WHERE RUT_USUARIO = '" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('USUARIOS','MODIFICACION DE USUARIO','" & (txt_nombre.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            actualizar_tabla()
            controles(False, True)
        End If
        ' End If
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

        If valormensaje = vbYes Then
            SC.Connection = conexion
            SC.CommandText = "delete from usuarios where rut_usuario = '" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "delete from permisos where rut_usuario = '" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)


            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('USUARIOS','ELIMINACION DE USUARIO','" & (txt_nombre.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','ELIMINACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        actualizar_tabla()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            mostrar(0)
        Else
            limpiar()
        End If

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        actualizar_tabla()
        mostrar(0)
    End Sub

    Private Sub btn_primero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.Click
        MiPos = 0
        mostrar(MiPos)
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        MiPos = DT.Rows.Count - 1
        mostrar(MiPos)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_buscador_usuarios.Show()
        Me.WindowState = FormWindowState.Minimized
        Form_buscador_usuarios.txt_buscar.Focus()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Me.Enabled = False
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()

        'conexion.Open()

        'SC.Connection = conexion
        'SC.CommandText = "select * from clientes, EMPRESA where rut = '" & (txt_rut.Text) & "'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'Dim rpt As New Crystal_clientes_sistema

        'rpt.SetDataSource(DS.Tables(DT.TableName))
        'form_informe_clientes.rpt_clientes.ReportSource = rpt
        'form_informe_clientes.Show()
        'conexion.Close()
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()

        Me.Enabled = True
    End Sub

    Sub actualizar_tabla()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from usuarios where rut_usuario <> '' order by nombre_usuario"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub

    Private Sub combo_pregunta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_pregunta.GotFocus
        combo_pregunta.BackColor = Color.LightBlue
    End Sub

    Private Sub combo_pregunta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_pregunta.LostFocus
        combo_pregunta.BackColor = Color.White
    End Sub


    Private Sub combo_pregunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_pregunta.SelectedIndexChanged

    End Sub



    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub





    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre.KeyPress
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

    Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre.TextChanged

    End Sub



    Private Sub grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub



    Private Sub txt_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_telefono.KeyPress

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



        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If



    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.GotFocus
        txt_rut.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre.GotFocus
        txt_nombre.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_login_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_login.GotFocus
        txt_login.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_clave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave.GotFocus
        txt_clave.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_telefono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_telefono.GotFocus
        txt_telefono.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.GotFocus
        combo_tipo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_area_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_area.GotFocus
        Combo_area.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_respuesta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_respuesta.GotFocus
        txt_respuesta.BackColor = Color.LightSkyBlue
    End Sub








    Private Sub txt_rut_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
    End Sub

    Private Sub txt_nombre_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre.LostFocus
        txt_nombre.BackColor = Color.White
    End Sub

    Private Sub txt_login_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_login.KeyPress

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

    Private Sub txt_login_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_login.LostFocus
        txt_login.BackColor = Color.White
    End Sub

    Private Sub txt_clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_clave.KeyPress

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

    Private Sub txt_clave_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave.LostFocus
        txt_clave.BackColor = Color.White
    End Sub

    Private Sub txt_telefono_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_telefono.LostFocus
        txt_telefono.BackColor = Color.White
    End Sub

    Private Sub combo_tipo_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.LostFocus
        combo_tipo.BackColor = Color.White
    End Sub

    Private Sub Combo_area_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_area.LostFocus
        Combo_area.BackColor = Color.White
    End Sub

    Private Sub txt_respuesta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_respuesta.KeyPress

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

    Private Sub txt_respuesta_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_respuesta.LostFocus
        txt_respuesta.BackColor = Color.White
    End Sub



    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 11, FontStyle.Regular)
        Dim Font2 As New Font("arial", 12, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        Dim im As Image
        im = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
        Dim p As New PointF(535, 10)
        e.Graphics.DrawImage(im, p)

        Dim rect1 As New Rectangle(10, 15, 250, 15)
        Dim rect2 As New Rectangle(10, 30, 250, 15)
        Dim rect3 As New Rectangle(10, 45, 250, 15)
        Dim rect4 As New Rectangle(10, 60, 250, 15)
        Dim rect5 As New Rectangle(10, 75, 250, 15)
        Dim rect6 As New Rectangle(10, 90, 250, 15)
        Dim rect_titulo As New Rectangle(10, 130, 830, 30)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim stringFormat_logo As New StringFormat()
        stringFormat_logo.Alignment = StringAlignment.Center
        stringFormat_logo.LineAlignment = StringAlignment.Far

        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

        e.Graphics.DrawString("DATOS USUARIO", Font2, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawLine(Pens.Black, 10, 160, 820, 160)

        e.Graphics.DrawString("RUT", Font1, Brushes.Black, 30, 200)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 200)
        e.Graphics.DrawString(txt_rut.Text, Font1, Brushes.Gray, 200, 200)
        e.Graphics.DrawString("NOMBRE", Font1, Brushes.Black, 30, 220)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 220)
        e.Graphics.DrawString(txt_nombre.Text, Font1, Brushes.Gray, 200, 220)
        e.Graphics.DrawString("USUARIO", Font1, Brushes.Black, 30, 240)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 240)
        e.Graphics.DrawString(txt_login.Text, Font1, Brushes.Gray, 200, 240)
        e.Graphics.DrawString("TELEFONO", Font1, Brushes.Black, 30, 260)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 260)
        e.Graphics.DrawString(txt_telefono.Text, Font1, Brushes.Gray, 200, 260)
        e.Graphics.DrawString("TIPO", Font1, Brushes.Black, 30, 280)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 280)
        e.Graphics.DrawString(combo_tipo.Text, Font1, Brushes.Gray, 200, 280)
        e.Graphics.DrawString("AREA", Font1, Brushes.Black, 30, 300)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 300)
        e.Graphics.DrawString(Combo_area.Text, Font1, Brushes.Gray, 200, 300)
    End Sub

    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.GotFocus
        btn_eliminar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.LostFocus
        btn_eliminar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_primero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.GotFocus
        btn_primero.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_primero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.LostFocus
        btn_primero.BackColor = Color.Transparent
    End Sub

    Private Sub btn_anterior_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.GotFocus
        btn_anterior.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_anterior_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.LostFocus
        btn_anterior.BackColor = Color.Transparent
    End Sub

    Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.GotFocus
        btn_siguiente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_siguiente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.LostFocus
        btn_siguiente.BackColor = Color.Transparent
    End Sub

    Private Sub btn_ultimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.GotFocus
        btn_ultimo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_ultimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.LostFocus
        btn_ultimo.BackColor = Color.Transparent
    End Sub

    Private Sub txt_repita_clave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_repita_clave.GotFocus
        txt_repita_clave.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_repita_clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_repita_clave.KeyPress
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

    Private Sub txt_repita_clave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_repita_clave.LostFocus
        txt_repita_clave.BackColor = Color.White
    End Sub

    Private Sub txt_tiempo_espera_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_tiempo_espera.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_tiempo_espera_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_tiempo_espera.BackColor = Color.White
    End Sub

    Private Sub txt_repita_clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_repita_clave.TextChanged

    End Sub

    Private Sub form_registro_usuarios_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub txt_tiempo_espera_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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


    Private Sub txt_tiempo_espera_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub txt_login_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_login.TextChanged

    End Sub

    Private Sub txt_clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_clave.TextChanged

    End Sub

    Private Sub txt_telefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telefono.TextChanged

    End Sub

    Private Sub txt_respuesta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_respuesta.TextChanged

    End Sub

 
End Class
