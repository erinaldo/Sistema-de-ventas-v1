Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_permisos
    Dim MiPos As Integer
    Private Sub Form_permisos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_permisos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_permisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llenar_combo_usuario()
        'controles(False, True)
        'cargar_logo()


        controles(False, True)
        actualizar_permisos()
        'actualizar_tabla()
        mostrar(0)
        mostrar_datos_usuarios()
        cargar_logo()

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub actualizar_permisos()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from permisos, usuarios where usuarios.rut_usuario=permisos.rut_usuario order by nombre_usuario asc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub


    Sub mostrar(ByVal i As Integer)
        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut.Text = DS.Tables(DT.TableName).Rows(i).Item("rut_usuario")
            End If
        Catch
        End Try
    End Sub


    'Sub actualizar_tabla()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from permisos"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    conexion.Close()
    'End Sub




    Sub mostrar_datos_usuarios()
        If txt_rut.Text <> "" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from usuarios where rut_usuario ='" & (txt_rut.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then

                txt_nombre.Text = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_usuario")
                'txt_area.Text = DS.Tables(DT.TableName).Rows(0).Item("area")
                'txt_tipo.Text = DS.Tables(DT.TableName).Rows(0).Item("TIPO")
            End If
            conexion.Close()
        End If
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)

        Check_clientes.Enabled = a
        Check_usuarios.Enabled = a
        Check_proveedores.Enabled = a
        Check_productos.Enabled = a
        Check_retiradores.Enabled = a
        Check_ventas.Enabled = a
        Check_compras.Enabled = a
        Check_etiquetas.Enabled = a
        Check_cartola.Enabled = a
        'Check_cambio.Enabled = a
        Check_facturacion.Enabled = a
        Check_pagos.Enabled = a
        Check_estados.Enabled = a
        Check_deudores.Enabled = a
        Check_nota_de_credito.Enabled = a
        '  Check_garantias.Enabled = a
        Check_caja.Enabled = a
        Check_corregir.Enabled = a
        Check_comisiones.Enabled = a
        Check_stock_minimo.Enabled = a
        Check_vencidas.Enabled = a
        '  Check_credenciales.Enabled = a
        Check_numeracion.Enabled = a
        'Check_imputar.Enabled = a
        Check_estadistica.Enabled = a
        Check_impresoras.Enabled = a
        Check_familias.Enabled = a
        Check_subfamilias.Enabled = a
        Check_empresa.Enabled = a
        Check_respaldo.Enabled = a
        Check_buscar_facturas.Enabled = a

        Check_menu_adquisiciones.Enabled = a
        Check_menu_administracion.Enabled = a
        'Check_menu_contabilidad.Enabled = a
        Check_menu_configuracion.Enabled = a
        Check_menu_mantenedores.Enabled = a
        Check_menu_ventas.Enabled = a
        Check_menu_bodega.Enabled = a
        'Check_menu_ayuda.Enabled = a
        'Check_menu_acerca_de.Enabled = a


        Check_cuentas_corrientes.Enabled = a
        Check_libro_de_compra.Enabled = a
        'Check_libro_de_ventas.Enabled = a
        Check_resumen_libro_de_compra.Enabled = a
        '   Check_resumen_libro_de_ventas.Enabled = a

        Check_reporte_libro_de_compra.Enabled = a
        Check_realizar_pedidos.Enabled = a
        Check_mis_pedidos.Enabled = a
        Check_revision_de_pedidos.Enabled = a
        Check_confirmacion_de_llegada.Enabled = a

        ' Check_liquidaciones_de_sueldo.Enabled = a
        ' Check_impuesto_unico.Enabled = a
        ' Check_cargas_de_asignacion_familiar.Enabled = a


        Check_cotizacion_formal.Enabled = a
        Check_estados_cuenta_rango.Enabled = a
        Check_nota_de_credito.Enabled = a
        Check_ventas.Enabled = a
        Check_enviar_cotizacion.Enabled = a
        Check_stock_y_ubicaciones.Enabled = a
        ' Check_agregar_trabajadores.Enabled = a
        ' Check_agregar_empresas.Enabled = a
        Check_agregar_marcas.Enabled = a
        '  Check_reimprimir_liquidaciones.Enabled = a
        ' Check_control_de_meses.Enabled = a
        '  Check_libro_de_remuneraciones.Enabled = a
        Check_valores.Enabled = a
        '  Check_afp.Enabled = a


        Check_proveedores_mas_pedidos.Enabled = a



        Check_libro_de_ventas.Enabled = a
        Check_buscar_totales.Enabled = a
        Check_CORREGIR_numeros.Enabled = a
        Check_ingreso_manual_de_ventas.Enabled = a
        Check_ingreso_de_creditos.Enabled = a
        Check_agregar_abonos.Enabled = a
        Check_traspaso_de_stock.Enabled = a
        Check_imputar_notas_de_credito.Enabled = a
        Check_imputar_abono.Enabled = a
        Check_codigos_de_barra.Enabled = a

        Check_comision_servicios.Enabled = a



        Check_envio_a_sucursal.Enabled = a
        Check_inventario.Enabled = a
        Check_cambio_de_productos.Enabled = a
        Check_mis_cotizaciones.Enabled = a

        Check_ruta_para_archivos_planos.Enabled = a
        Check_ruta_para_imagenes_de_sistema.Enabled = a
        Check_bitacora_de_cambios.Enabled = a
        Check_detalle_de_ventas.Enabled = a
        Check_detalle_de_ventas_por_doc.Enabled = a
        Check_cuentas_por_cobrar.Enabled = a
        Check_historial_de_cuenta.Enabled = a
        Check_nota_de_debito.Enabled = a


        Check_ticket_de_ventas.Enabled = a
        Check_tarjetas_de_presentacion.Enabled = a
        Check_consultas.Enabled = a
        Check_personalizar_sistema.Enabled = a
        Check_estado_de_deudas.Enabled = a
        Check_reservas.Enabled = a


        Check_subfamilias2.Enabled = a
        Check_detalle_compras.Enabled = a
        Check_detalle_compras_por_doc.Enabled = a
        Check_guias_de_traslado.Enabled = a
        Check_registro_de_autorizaciones.Enabled = a


        Check_asignar_familias.Enabled = a
        Check_ventas_asistidas.Enabled = a


        Check_actualizar_stock.Enabled = a
        Check_traspaso_de_creditos_a_historico.Enabled = a
        Check_traspaso_de_stock.Enabled = a
        Check_adm_vales_de_cambio.Enabled = a













        btn_primero.Enabled = b
        btn_siguiente.Enabled = b
        btn_anterior.Enabled = b
        btn_ultimo.Enabled = b

        Panel_1.Enabled = a
        Panel_2.Enabled = a
        Panel_3.Enabled = a

        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a








        btn_modificar.Enabled = b
    End Sub

    Sub limpiar()
        Check_caja.Checked = False
        '   Check_cambio.Checked = False
        Check_cartola.Checked = False
        Check_clientes.Checked = False
        Check_comisiones.Checked = False
        Check_compras.Checked = False
        Check_corregir.Checked = False
        '    Check_credenciales.Checked = False
        Check_cuentas_corrientes.Checked = False
        Check_deudores.Checked = False
        Check_empresa.Checked = False
        Check_estadistica.Checked = False
        Check_estados.Checked = False
        Check_etiquetas.Checked = False
        Check_facturacion.Checked = False
        Check_familias.Checked = False
        '  Check_garantias.Checked = False
        Check_impresoras.Checked = False
        'Check_imputar.Checked = False
        Check_libro_de_compra.Checked = False
        ' Check_libro_de_ventas.Checked = False
        '   Check_menu_acerca_de.Checked = False
        Check_menu_administracion.Checked = False
        Check_menu_adquisiciones.Checked = False
        ' Check_menu_ayuda.Checked = False
        Check_menu_bodega.Checked = False
        Check_menu_configuracion.Checked = False
        'Check_menu_contabilidad.Checked = False
        Check_menu_mantenedores.Checked = False
        Check_menu_ventas.Checked = False
        Check_nota_de_credito.Checked = False
        Check_numeracion.Checked = False
        Check_pagos.Checked = False
        Check_productos.Checked = False
        Check_proveedores.Checked = False
        Check_respaldo.Checked = False
        Check_resumen_libro_de_compra.Checked = False
        '    Check_resumen_libro_de_ventas.Checked = False
        Check_retiradores.Checked = False
        Check_stock_minimo.Checked = False
        Check_subfamilias.Checked = False
        Check_usuarios.Checked = False
        Check_vencidas.Checked = False
        Check_ventas.Checked = False
        Check_reporte_libro_de_compra.Checked = False
        Check_realizar_pedidos.Checked = False
        Check_mis_pedidos.Checked = False
        Check_revision_de_pedidos.Checked = False
        Check_confirmacion_de_llegada.Checked = False
        Check_buscar_facturas.Checked = False
        ' Check_liquidaciones_de_sueldo.Checked = False
        'Check_impuesto_unico.Checked = False
        ' Check_cargas_de_asignacion_familiar.Checked = False




        Check_cotizacion_formal.Checked = False
        Check_estados_cuenta_rango.Checked = False
        Check_nota_de_credito.Checked = False
        Check_ventas.Checked = False
        Check_enviar_cotizacion.Checked = False
        Check_stock_y_ubicaciones.Checked = False
        '   Check_agregar_trabajadores.Enabled = False
        ' Check_agregar_empresas.Enabled = False
        Check_agregar_marcas.Checked = False
        '  Check_reimprimir_liquidaciones.Enabled = False
        '  Check_control_de_meses.Enabled = False
        ' Check_libro_de_remuneraciones.Enabled = False
        Check_valores.Enabled = False

        Check_proveedores_mas_pedidos.Checked = False




        Check_libro_de_ventas.Checked = False
        Check_buscar_totales.Checked = False
        Check_CORREGIR_numeros.Checked = False
        Check_ingreso_manual_de_ventas.Checked = False
        Check_ingreso_de_creditos.Checked = False
        Check_agregar_abonos.Checked = False
        Check_traspaso_de_stock.Checked = False
        Check_imputar_notas_de_credito.Checked = False
        Check_imputar_abono.Checked = False
        Check_codigos_de_barra.Checked = False
        Check_comision_servicios.Checked = False
        Check_cambio_de_productos.Checked = False


        Check_envio_a_sucursal.Checked = False
        Check_inventario.Checked = False
        Check_mis_cotizaciones.Checked = False




        Check_ruta_para_archivos_planos.Checked = False
        Check_ruta_para_imagenes_de_sistema.Checked = False
        Check_bitacora_de_cambios.Checked = False
        Check_detalle_de_ventas.Checked = False
        Check_detalle_de_ventas_por_doc.Checked = False
        Check_cuentas_por_cobrar.Checked = False
        Check_historial_de_cuenta.Checked = False
        Check_nota_de_debito.Checked = False




        Check_ticket_de_ventas.Checked = False
        Check_tarjetas_de_presentacion.Checked = False
        Check_consultas.Checked = False
        Check_personalizar_sistema.Checked = False
        Check_estado_de_deudas.Checked = False
        Check_reservas.Checked = False
        Check_guias_de_traslado.Checked = False
        Check_asignar_familias.Checked = False
        Check_ventas_asistidas.Checked = False



        Check_subfamilias2.Checked = False
        Check_detalle_compras.Checked = False
        Check_detalle_compras_por_doc.Checked = False
        Check_registro_de_autorizaciones.Checked = False


        Check_actualizar_stock.Checked = False
        Check_traspaso_de_creditos_a_historico.Checked = False
        check_traspasar_stock_fisico.Checked = False
        Check_adm_vales_de_cambio.Checked = False

    End Sub


    'Sub llenar_combo_usuario()
    '    DS3.Tables.Clear()
    '    DT3.Rows.Clear()
    '    DT3.Columns.Clear()
    '    DS3.Clear()
    '    conexion.Open()

    '    SC3.Connection = conexion
    '    SC3.CommandText = "select rut_usuario from usuarios where TIPO <> 'ADMINISTRADOR DEL SISTEMA'"
    '    DA3.SelectCommand = SC3
    '    DA3.Fill(DT3)
    '    DS3.Tables.Add(DT3)

    '    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
    '            combo_rut.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("rut_usuario"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub




    Sub mostrar_permisos()
        If txt_rut.Text <> "" Then
            conexion.Close()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion
            SC3.CommandText = "select * from permisos where rut_usuario ='" & (txt_rut.Text) & "'"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then


                If DS3.Tables(DT3.TableName).Rows(0).Item("clientes") = "HABILITADO" Then
                    Check_clientes.Checked = True
                Else
                    Check_clientes.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("usuarios") = "HABILITADO" Then
                    Check_usuarios.Checked = True
                Else
                    Check_usuarios.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("proveedores") = "HABILITADO" Then
                    Check_proveedores.Checked = True
                Else
                    Check_proveedores.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("productos") = "HABILITADO" Then
                    Check_productos.Checked = True
                Else
                    Check_productos.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("retiradores") = "HABILITADO" Then
                    Check_retiradores.Checked = True
                Else
                    Check_retiradores.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("ventas") = "HABILITADO" Then
                    Check_ventas.Checked = True
                Else
                    Check_ventas.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("compras") = "HABILITADO" Then
                    Check_compras.Checked = True
                Else
                    Check_compras.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("etiquetas") = "HABILITADO" Then
                    Check_etiquetas.Checked = True
                Else
                    Check_etiquetas.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("cartola_kardex") = "HABILITADO" Then
                    Check_cartola.Checked = True
                Else
                    Check_cartola.Checked = False
                End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("cambio_vendedor") = "HABILITADO" Then
                '    Check_cambio.Checked = True
                'Else
                '    Check_cambio.Checked = False
                'End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("facturacion") = "HABILITADO" Then
                    Check_facturacion.Checked = True
                Else
                    Check_facturacion.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("pagos") = "HABILITADO" Then
                    Check_pagos.Checked = True
                Else
                    Check_pagos.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("estados_decuenta") = "HABILITADO" Then
                    Check_estados.Checked = True
                Else
                    Check_estados.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("deudores") = "HABILITADO" Then
                    Check_deudores.Checked = True
                Else
                    Check_deudores.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("nota_de_credito") = "HABILITADO" Then
                    Check_nota_de_credito.Checked = True
                Else
                    Check_nota_de_credito.Checked = False
                End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("envio_garantias") = "HABILITADO" Then
                '    Check_garantias.Checked = True
                'Else
                '    Check_garantias.Checked = False
                'End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("caja_diaria") = "HABILITADO" Then
                    Check_caja.Checked = True
                Else
                    Check_caja.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("corregir_doc") = "HABILITADO" Then
                    Check_corregir.Checked = True
                Else
                    Check_corregir.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("comisiones") = "HABILITADO" Then
                    Check_comisiones.Checked = True
                Else
                    Check_comisiones.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("stock_minimo") = "HABILITADO" Then
                    Check_stock_minimo.Checked = True
                Else
                    Check_stock_minimo.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("fac_vencidas") = "HABILITADO" Then
                    Check_vencidas.Checked = True
                Else
                    Check_vencidas.Checked = False
                End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("credenciales") = "HABILITADO" Then
                '    Check_credenciales.Checked = True
                'Else
                '    Check_credenciales.Checked = False
                'End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("numeracion") = "HABILITADO" Then
                    Check_numeracion.Checked = True
                Else
                    Check_numeracion.Checked = False
                End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("imputar_pagos") = "HABILITADO" Then
                '    Check_imputar.Checked = True
                'Else
                '    Check_imputar.Checked = False
                'End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("estadisticas") = "HABILITADO" Then
                    Check_estadistica.Checked = True
                Else
                    Check_estadistica.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("impresoras") = "HABILITADO" Then
                    Check_impresoras.Checked = True
                Else
                    Check_impresoras.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("familias") = "HABILITADO" Then
                    Check_familias.Checked = True
                Else
                    Check_familias.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("subfamilias") = "HABILITADO" Then
                    Check_subfamilias.Checked = True
                Else
                    Check_subfamilias.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("empresa") = "HABILITADO" Then
                    Check_empresa.Checked = True
                Else
                    Check_empresa.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("respaldo") = "HABILITADO" Then
                    Check_respaldo.Checked = True
                Else
                    Check_respaldo.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("cuentas_corrientes") = "HABILITADO" Then
                    Check_cuentas_corrientes.Checked = True
                Else
                    Check_cuentas_corrientes.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("libro_de_compras") = "HABILITADO" Then
                    Check_libro_de_compra.Checked = True
                Else
                    Check_libro_de_compra.Checked = False
                End If
                'If DS3.Tables(DT3.TableName).Rows(0).Item("libro_de_ventas") = "HABILITADO" Then
                '    Check_libro_de_ventas.Checked = True
                'Else
                '    Check_libro_de_ventas.Checked = False
                'End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("resumen_libro_de_compras") = "HABILITADO" Then
                    Check_resumen_libro_de_compra.Checked = True
                Else
                    Check_resumen_libro_de_compra.Checked = False
                End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("resumen_libro_de_ventas") = "HABILITADO" Then
                '    Check_resumen_libro_de_ventas.Checked = True
                'Else
                '    Check_resumen_libro_de_ventas.Checked = False
                'End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("menu_adquisiciones") = "HABILITADO" Then
                    Check_menu_adquisiciones.Checked = True
                Else
                    Check_menu_adquisiciones.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("menu_administracion") = "HABILITADO" Then
                    Check_menu_administracion.Checked = True
                Else
                    Check_menu_administracion.Checked = False
                End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("menu_contabilidad") = "HABILITADO" Then
                '    Check_menu_contabilidad.Checked = True
                'Else
                '    Check_menu_contabilidad.Checked = False
                'End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("menu_configuracion") = "HABILITADO" Then
                    Check_menu_configuracion.Checked = True
                Else
                    Check_menu_configuracion.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("menu_mantenedores") = "HABILITADO" Then
                    Check_menu_mantenedores.Checked = True
                Else
                    Check_menu_mantenedores.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("menu_ventas") = "HABILITADO" Then
                    Check_menu_ventas.Checked = True
                Else
                    Check_menu_ventas.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("menu_bodega") = "HABILITADO" Then
                    Check_menu_bodega.Checked = True
                Else
                    Check_menu_bodega.Checked = False
                End If


                'If DS3.Tables(DT3.TableName).Rows(0).Item("menu_ayuda") = "HABILITADO" Then
                '    Check_menu_ayuda.Checked = True
                'Else
                '    Check_menu_ayuda.Checked = False
                'End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("menu_acerca_de") = "HABILITADO" Then
                '    Check_menu_acerca_de.Checked = True
                'Else
                '    Check_menu_acerca_de.Checked = False
                'End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("reporte_libro_de_compras") = "HABILITADO" Then
                    Check_reporte_libro_de_compra.Checked = True
                Else
                    Check_reporte_libro_de_compra.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("realizar_pedidos") = "HABILITADO" Then
                    Check_realizar_pedidos.Checked = True
                Else
                    Check_realizar_pedidos.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("mis_pedidos") = "HABILITADO" Then
                    Check_mis_pedidos.Checked = True
                Else
                    Check_mis_pedidos.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("revision_de_pedidos") = "HABILITADO" Then
                    Check_revision_de_pedidos.Checked = True
                Else
                    Check_revision_de_pedidos.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("confirmacion_de_llegada") = "HABILITADO" Then
                    Check_confirmacion_de_llegada.Checked = True
                Else
                    Check_confirmacion_de_llegada.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("buscar_facturas") = "HABILITADO" Then
                    Check_buscar_facturas.Checked = True
                Else
                    Check_buscar_facturas.Checked = False
                End If


                'If DS3.Tables(DT3.TableName).Rows(0).Item("liquidaciones_de_sueldo") = "HABILITADO" Then
                '    Check_liquidaciones_de_sueldo.Checked = True
                'Else
                '    Check_liquidaciones_de_sueldo.Checked = False
                'End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("impuesto_unico") = "HABILITADO" Then
                '    Check_impuesto_unico.Checked = True
                'Else
                '    Check_impuesto_unico.Checked = False
                'End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("cargas_de_asignacion_familiar") = "HABILITADO" Then
                '    Check_cargas_de_asignacion_familiar.Checked = True
                'Else
                '    Check_cargas_de_asignacion_familiar.Checked = False
                'End If











                If DS3.Tables(DT3.TableName).Rows(0).Item("cotizacion_formal") = "HABILITADO" Then
                    Check_cotizacion_formal.Checked = True
                Else
                    Check_cotizacion_formal.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("estado_de_cuenta_por_rango") = "HABILITADO" Then
                    Check_estados_cuenta_rango.Checked = True
                Else
                    Check_estados_cuenta_rango.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("notas_de_credito") = "HABILITADO" Then
                    Check_nota_de_credito.Checked = True
                Else
                    Check_nota_de_credito.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("ventas") = "HABILITADO" Then
                    Check_ventas.Checked = True
                Else
                    Check_ventas.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("enviar_cotizacion") = "HABILITADO" Then
                    Check_enviar_cotizacion.Checked = True
                Else
                    Check_enviar_cotizacion.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("stock_y_ubicaciones") = "HABILITADO" Then
                    Check_stock_y_ubicaciones.Checked = True
                Else
                    Check_stock_y_ubicaciones.Checked = False
                End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("trabajadores") = "HABILITADO" Then
                '    Check_agregar_trabajadores.Checked = True
                'Else
                '    Check_agregar_trabajadores.Checked = False
                'End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("empresas") = "HABILITADO" Then
                '    Check_agregar_empresas.Enabled = True
                'Else
                '    Check_agregar_empresas.Enabled = False
                'End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("marcas") = "HABILITADO" Then
                    Check_agregar_marcas.Checked = True
                Else
                    Check_agregar_marcas.Checked = False
                End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("reimprimir_liquidaciones_de_sueldo") = "HABILITADO" Then
                '    Check_reimprimir_liquidaciones.Checked = True
                'Else
                '    Check_reimprimir_liquidaciones.Checked = False
                'End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("control_meses") = "HABILITADO" Then
                '    Check_control_de_meses.Checked = True
                'Else
                '    Check_control_de_meses.Checked = False
                'End If

                'If DS3.Tables(DT3.TableName).Rows(0).Item("libro_remuneraciones") = "HABILITADO" Then
                '    Check_libro_de_remuneraciones.Checked = True
                'Else
                '    Check_libro_de_remuneraciones.Checked = False
                'End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("valores") = "HABILITADO" Then
                    Check_valores.Checked = True
                Else
                    Check_valores.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("proveedores_mas_pedidos") = "HABILITADO" Then
                    Check_proveedores_mas_pedidos.Checked = True
                Else
                    Check_proveedores_mas_pedidos.Checked = False
                End If








                If DS3.Tables(DT3.TableName).Rows(0).Item("libro_de_ventas") = "HABILITADO" Then
                    Check_libro_de_ventas.Checked = True
                Else
                    Check_libro_de_ventas.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("buscar_totales") = "HABILITADO" Then
                    Check_buscar_totales.Checked = True
                Else
                    Check_buscar_totales.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("CORREGIR_numeros") = "HABILITADO" Then
                    Check_CORREGIR_numeros.Checked = True
                Else
                    Check_CORREGIR_numeros.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("ingreso_manual_de_ventas") = "HABILITADO" Then
                    Check_ingreso_manual_de_ventas.Checked = True
                Else
                    Check_ingreso_manual_de_ventas.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("ingreso_de_creditos") = "HABILITADO" Then
                    Check_ingreso_de_creditos.Checked = True
                Else
                    Check_ingreso_de_creditos.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("agregar_abonos") = "HABILITADO" Then
                    Check_agregar_abonos.Checked = True
                Else
                    Check_agregar_abonos.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("traspaso_de_stock") = "HABILITADO" Then
                    Check_traspaso_de_stock.Checked = True
                Else
                    Check_traspaso_de_stock.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("imputar_notas_de_credito") = "HABILITADO" Then
                    Check_imputar_notas_de_credito.Checked = True
                Else
                    Check_imputar_notas_de_credito.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("imputar_abono") = "HABILITADO" Then
                    Check_imputar_abono.Checked = True
                Else
                    Check_imputar_abono.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("codigos_de_barra") = "HABILITADO" Then
                    Check_codigos_de_barra.Checked = True
                Else
                    Check_codigos_de_barra.Checked = False
                End If



                If DS3.Tables(DT3.TableName).Rows(0).Item("comision_servicios") = "HABILITADO" Then
                    Check_comision_servicios.Checked = True
                Else
                    Check_comision_servicios.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("envio_a_sucursal") = "HABILITADO" Then
                    Check_envio_a_sucursal.Checked = True
                Else
                    Check_envio_a_sucursal.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("inventario") = "HABILITADO" Then
                    Check_inventario.Checked = True
                Else
                    Check_inventario.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("cambio_de_productos") = "HABILITADO" Then
                    Check_cambio_de_productos.Checked = True
                Else
                    Check_cambio_de_productos.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("mis_cotizaciones") = "HABILITADO" Then
                    Check_mis_cotizaciones.Checked = True
                Else
                    Check_mis_cotizaciones.Checked = False
                End If




















                If DS3.Tables(DT3.TableName).Rows(0).Item("ruta_para_archivos_planos") = "HABILITADO" Then
                    Check_ruta_para_archivos_planos.Checked = True
                Else
                    Check_ruta_para_archivos_planos.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("ruta_para_imagenes_de_sistema") = "HABILITADO" Then
                    Check_ruta_para_imagenes_de_sistema.Checked = True
                Else
                    Check_ruta_para_imagenes_de_sistema.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("bitacora_de_cambios") = "HABILITADO" Then
                    Check_bitacora_de_cambios.Checked = True
                Else
                    Check_bitacora_de_cambios.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("detalle_de_ventas") = "HABILITADO" Then
                    Check_detalle_de_ventas.Checked = True
                Else
                    Check_detalle_de_ventas.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("detalle_de_ventas_por_doc") = "HABILITADO" Then
                    Check_detalle_de_ventas_por_doc.Checked = True
                Else
                    Check_detalle_de_ventas_por_doc.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("cuentas_por_cobrar") = "HABILITADO" Then
                    Check_cuentas_por_cobrar.Checked = True
                Else
                    Check_cuentas_por_cobrar.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("historial_de_cuenta") = "HABILITADO" Then
                    Check_historial_de_cuenta.Checked = True
                Else
                    Check_historial_de_cuenta.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("nota_de_debito") = "HABILITADO" Then
                    Check_nota_de_debito.Checked = True
                Else
                    Check_nota_de_debito.Checked = False
                End If



                If DS3.Tables(DT3.TableName).Rows(0).Item("ticket_de_ventas") = "HABILITADO" Then
                    Check_ticket_de_ventas.Checked = True
                Else
                    Check_ticket_de_ventas.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("tarjetas_de_presentacion") = "HABILITADO" Then
                    Check_tarjetas_de_presentacion.Checked = True
                Else
                    Check_tarjetas_de_presentacion.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("consultas_sql") = "HABILITADO" Then
                    Check_consultas.Checked = True
                Else
                    Check_consultas.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("personalizar_sistema") = "HABILITADO" Then
                    Check_personalizar_sistema.Checked = True
                Else
                    Check_personalizar_sistema.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("estado_de_deudas") = "HABILITADO" Then
                    Check_estado_de_deudas.Checked = True
                Else
                    Check_estado_de_deudas.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("estado_de_deudas") = "HABILITADO" Then
                    Check_estado_de_deudas.Checked = True
                Else
                    Check_estado_de_deudas.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("reservas") = "HABILITADO" Then
                    Check_reservas.Checked = True
                Else
                    Check_reservas.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("subfamilia2") = "HABILITADO" Then
                    Check_subfamilias2.Checked = True
                Else
                    Check_subfamilias2.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("detalle_compras") = "HABILITADO" Then
                    Check_detalle_compras.Checked = True
                Else
                    Check_detalle_compras.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("guia_de_traslado") = "HABILITADO" Then
                    Check_detalle_compras_por_doc.Checked = True
                Else
                    Check_detalle_compras_por_doc.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("guia_de_traslado") = "HABILITADO" Then
                    Check_guias_de_traslado.Checked = True
                Else
                    Check_guias_de_traslado.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("registro_de_autorizaciones") = "HABILITADO" Then
                    Check_registro_de_autorizaciones.Checked = True
                Else
                    Check_registro_de_autorizaciones.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("asignar_familias") = "HABILITADO" Then
                    Check_asignar_familias.Checked = True
                Else
                    Check_asignar_familias.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("ventas_asistidas") = "HABILITADO" Then
                    Check_ventas_asistidas.Checked = True
                Else
                    Check_ventas_asistidas.Checked = False
                End If


                If DS3.Tables(DT3.TableName).Rows(0).Item("actualizar_stock") = "HABILITADO" Then
                    Check_actualizar_stock.Checked = True
                Else
                    Check_actualizar_stock.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("traspaso_de_creditos_a_historico") = "HABILITADO" Then
                    Check_traspaso_de_creditos_a_historico.Checked = True
                Else
                    Check_traspaso_de_creditos_a_historico.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("traspasar_stock_fisico") = "HABILITADO" Then
                    check_traspasar_stock_fisico.Checked = True
                Else
                    check_traspasar_stock_fisico.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("adm_vales_de_cambio") = "HABILITADO" Then
                    Check_adm_vales_de_cambio.Checked = True
                Else
                    Check_adm_vales_de_cambio.Checked = False
                End If





                If DS3.Tables(DT3.TableName).Rows(0).Item("hojas_foleadas") = "HABILITADO" Then
                    Check_hojas_foleadas.Checked = True
                Else
                    Check_hojas_foleadas.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("servicios_de_lubricentro") = "HABILITADO" Then
                    CheckBox_servicios_de_lubricentro.Checked = True
                Else
                    CheckBox_servicios_de_lubricentro.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("administrar_servicios_de_lubricentro") = "HABILITADO" Then
                    CheckBox_adm_servicios_de_lubricentro.Checked = True
                Else
                    CheckBox_adm_servicios_de_lubricentro.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("existencias") = "HABILITADO" Then
                    Check_existencias.Checked = True
                Else
                    Check_existencias.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("registro_de_actualizaciones") = "HABILITADO" Then
                    Check_registro_de_actualizaciones.Checked = True
                Else
                    Check_registro_de_actualizaciones.Checked = False
                End If

                If DS3.Tables(DT3.TableName).Rows(0).Item("actualizar_sistema") = "HABILITADO" Then
                    Check_actualizar_sistema.Checked = True
                Else
                    Check_actualizar_sistema.Checked = False
                End If

            End If
            conexion.Close()
        End If
    End Sub



    Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub



    Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_datos_usuarios()
        mostrar_permisos()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        If txt_nombre.Text = "" Then
            MsgBox("SELECCIONA UN USUARIO PARA MODIFICAR SUS PERMISOS", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        Else
            mostrar_permisos()
            controles(True, False)
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        limpiar()

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim clientes As String
        Dim usuarios As String
        Dim proveedores As String
        Dim productos As String
        Dim retiradores As String
        '   Dim ventas As String
        Dim compras As String
        Dim etiquetas As String
        Dim cartola As String
        Dim cambio As String
        Dim facturacion As String
        Dim pagos As String
        Dim estados As String
        Dim deudores As String
        Dim notas As String
        Dim garantias As String
        Dim caja As String
        Dim corregir As String
        Dim comisiones As String
        Dim stock As String
        Dim vencidas As String
        Dim credenciales As String
        Dim numeracion As String
        Dim imputar_pagos As String
        Dim estadisticas As String
        Dim familias As String
        Dim subfamilias As String
        Dim impresoras As String
        Dim empresa As String
        Dim respaldo As String

        Dim cuentas_corrientes As String
        Dim libro_de_compras As String
        Dim resumen_libro_de_compras As String
        '  Dim libro_de_ventas As String
        Dim resumen_libro_de_ventas As String


        Dim menu_adquisiciones As String
        Dim menu_administracion As String
        Dim menu_contabilidad As String
        Dim menu_configuracion As String
        Dim menu_mantenedores As String
        Dim menu_ventas As String
        Dim menu_bodega As String
        Dim menu_ayuda As String
        Dim menu_acerca_de As String

        Dim reporte_libro_de_compra As String
        Dim realizar_pedidos As String
        Dim mis_pedidos As String
        Dim revision_de_pedidos As String
        Dim confirmacion_de_llegada As String
        Dim buscar_facturas As String

        Dim liquidaciones_de_sueldo As String
        Dim impuesto_unico As String
        Dim cargas_de_asignacion_familiar As String


        Dim cotizacion_formal As String
        Dim estado_de_cuenta_por_rango As String
        Dim notas_de_credito As String
        Dim ventas As String
        Dim enviarcotizacion As String
        Dim stocks_y_ubicaciones As String
        Dim agregar_trabajadores As String
        Dim agregar_empresas As String
        Dim agregar_marcas As String
        Dim reimprimir_liquidaciones As String
        Dim control_de_meses As String
        Dim libro_de_remuneraciones As String
        Dim valores As String

        Dim afp As String

        Dim proveedores_mas_pedidos As String





        Dim libro_de_ventas As String
        Dim buscar_totales As String
        Dim CORREGIR_numeros As String
        Dim ingreso_manual_de_ventas As String
        Dim ingreso_de_creditos As String
        Dim agregar_abonos As String
        Dim traspaso_de_stock As String
        Dim imputar_notas_de_credito As String
        Dim imputar_abono As String
        Dim codigos_de_barra As String
        Dim comision_servicios As String
        Dim envio_a_sucursal As String
        Dim inventario As String
        Dim cambio_de_producto As String
        Dim mis_cotizaciones As String

        Dim ruta_para_archivos_planos As String
        Dim ruta_para_imagenes_de_sistema As String
        Dim bitacora_de_cambios As String
        Dim detalle_de_ventas As String
        Dim detalle_de_ventas_por_doc As String
        Dim cuentas_por_cobrar As String
        Dim historial_de_cuenta As String
        Dim nota_de_debito As String






        Dim ticket_de_ventas As String
        Dim tarjetas_de_presentacion As String
        Dim consultas_sql As String
        Dim personalizar_sistema As String
        Dim estado_de_deudas As String
        Dim reservas As String


        Dim subfamilia2 As String
        Dim detalle_compras As String
        Dim detalle_compras_por_doc As String
        Dim guia_de_traslado As String
        Dim registro_de_autorizaciones As String

        Dim asignar_familias As String
        Dim ventas_asistidas As String




        Dim actualizar_stock As String
        Dim traspaso_de_creditos_a_historico As String
        Dim traspaso_de_stock_fisico As String
        Dim adm_vales_de_cambio As String





        Dim hojas_foleadas As String
        Dim servicios_de_lubricentro As String
        Dim adm_servicios_de_lubricentro As String
        Dim existencias As String
        Dim reposicion_de_ventas As String
        Dim registro_de_actualizaciones As String
        Dim actualizar_sistema As String



        clientes = ""
        usuarios = ""
        proveedores = ""
        productos = ""
        retiradores = ""
        compras = ""
        etiquetas = ""
        cartola = ""
        cambio = ""
        facturacion = ""
        pagos = ""
        estados = ""
        deudores = ""
        notas = ""
        garantias = ""
        caja = ""
        corregir = ""
        comisiones = ""
        stock = ""
        vencidas = ""
        credenciales = ""
        numeracion = ""
        imputar_pagos = ""
        estadisticas = ""
        familias = ""
        subfamilias = ""
        impresoras = ""
        empresa = ""
        respaldo = ""

        cuentas_corrientes = ""
        libro_de_compras = ""
        resumen_libro_de_compras = ""
        libro_de_ventas = ""
        resumen_libro_de_ventas = ""


        menu_adquisiciones = ""
        menu_administracion = ""
        menu_contabilidad = ""
        menu_configuracion = ""
        menu_mantenedores = ""
        menu_ventas = ""
        menu_bodega = ""
        menu_ayuda = ""
        menu_acerca_de = ""

        reporte_libro_de_compra = ""
        realizar_pedidos = ""
        mis_pedidos = ""
        revision_de_pedidos = ""
        confirmacion_de_llegada = ""
        buscar_facturas = ""

        liquidaciones_de_sueldo = ""
        impuesto_unico = ""
        cargas_de_asignacion_familiar = ""


        cotizacion_formal = ""
        estado_de_cuenta_por_rango = ""
        notas_de_credito = ""
        ventas = ""
        enviarcotizacion = ""
        stocks_y_ubicaciones = ""
        agregar_trabajadores = ""
        agregar_empresas = ""
        agregar_marcas = ""
        reimprimir_liquidaciones = ""
        control_de_meses = ""
        libro_de_remuneraciones = ""
        valores = ""

        afp = ""

        proveedores_mas_pedidos = ""





        libro_de_ventas = ""
        buscar_totales = ""
        CORREGIR_numeros = ""
        ingreso_manual_de_ventas = ""
        ingreso_de_creditos = ""
        agregar_abonos = ""
        traspaso_de_stock = ""
        imputar_notas_de_credito = ""
        imputar_abono = ""
        codigos_de_barra = ""
        comision_servicios = ""
        envio_a_sucursal = ""
        inventario = ""
        cambio_de_producto = ""
        mis_cotizaciones = ""

        ruta_para_archivos_planos = ""
        ruta_para_imagenes_de_sistema = ""
        bitacora_de_cambios = ""
        detalle_de_ventas = ""
        detalle_de_ventas_por_doc = ""
        cuentas_por_cobrar = ""
        historial_de_cuenta = ""
        nota_de_debito = ""






        ticket_de_ventas = ""
        tarjetas_de_presentacion = ""
        consultas_sql = ""
        personalizar_sistema = ""
        estado_de_deudas = ""
        reservas = ""


        subfamilia2 = ""
        detalle_compras = ""
        detalle_compras_por_doc = ""
        guia_de_traslado = ""
        registro_de_autorizaciones = ""

        asignar_familias = ""
        ventas_asistidas = ""




        actualizar_stock = ""
        traspaso_de_creditos_a_historico = ""
        traspaso_de_stock_fisico = ""
        adm_vales_de_cambio = ""





        hojas_foleadas = ""
        servicios_de_lubricentro = ""
        adm_servicios_de_lubricentro = ""
        existencias = ""
        reposicion_de_ventas = ""
        registro_de_actualizaciones = ""
        actualizar_sistema = ""



        If Check_clientes.Checked = True Then
            clientes = "HABILITADO"
        Else
            clientes = "DESHABILITADO"
        End If

        If Check_usuarios.Checked = True Then
            usuarios = "HABILITADO"
        Else
            usuarios = "DESHABILITADO"
        End If

        If Check_proveedores.Checked = True Then
            proveedores = "HABILITADO"
        Else
            proveedores = "DESHABILITADO"
        End If

        If Check_productos.Checked = True Then
            productos = "HABILITADO"
        Else
            productos = "DESHABILITADO"
        End If

        If Check_retiradores.Checked = True Then
            retiradores = "HABILITADO"
        Else
            retiradores = "DESHABILITADO"
        End If

        If Check_ventas.Checked = True Then
            ventas = "HABILITADO"
        Else
            ventas = "DESHABILITADO"
        End If

        If Check_compras.Checked = True Then
            compras = "HABILITADO"
        Else
            compras = "DESHABILITADO"
        End If

        If Check_etiquetas.Checked = True Then
            etiquetas = "HABILITADO"
        Else
            etiquetas = "DESHABILITADO"
        End If

        If Check_cartola.Checked = True Then
            cartola = "HABILITADO"
        Else
            cartola = "DESHABILITADO"
        End If

        'If Check_cambio.Checked = True Then
        '    cambio = "HABILITADO"
        'Else
        '    cambio = "DESHABILITADO"
        'End If

        If Check_facturacion.Checked = True Then
            facturacion = "HABILITADO"
        Else
            facturacion = "DESHABILITADO"
        End If

        If Check_pagos.Checked = True Then
            pagos = "HABILITADO"
        Else
            pagos = "DESHABILITADO"
        End If

        If Check_estados.Checked = True Then
            estados = "HABILITADO"
        Else
            estados = "DESHABILITADO"
        End If

        If Check_deudores.Checked = True Then
            deudores = "HABILITADO"
        Else
            deudores = "DESHABILITADO"
        End If

        If Check_nota_de_credito.Checked = True Then
            notas = "HABILITADO"
        Else
            notas = "DESHABILITADO"
        End If

        'If Check_garantias.Checked = True Then
        '    garantias = "HABILITADO"
        'Else
        '    garantias = "DESHABILITADO"
        'End If

        If Check_caja.Checked = True Then
            caja = "HABILITADO"
        Else
            caja = "DESHABILITADO"
        End If

        If Check_corregir.Checked = True Then
            corregir = "HABILITADO"
        Else
            corregir = "DESHABILITADO"
        End If

        If Check_comisiones.Checked = True Then
            comisiones = "HABILITADO"
        Else
            comisiones = "DESHABILITADO"
        End If

        If Check_stock_minimo.Checked = True Then
            stock = "HABILITADO"
        Else
            stock = "DESHABILITADO"
        End If

        If Check_vencidas.Checked = True Then
            vencidas = "HABILITADO"
        Else
            vencidas = "DESHABILITADO"
        End If

        'If Check_credenciales.Checked = True Then
        '    credenciales = "HABILITADO"
        'Else
        '    credenciales = "DESHABILITADO"
        'End If

        If Check_numeracion.Checked = True Then
            numeracion = "HABILITADO"
        Else
            numeracion = "DESHABILITADO"
        End If
        'If Check_imputar.Checked = True Then
        '    imputar_pagos = "HABILITADO"
        'Else
        '    imputar_pagos = "DESHABILITADO"
        'End If

        If Check_estadistica.Checked = True Then
            estadisticas = "HABILITADO"
        Else
            estadisticas = "DESHABILITADO"
        End If

        If Check_impresoras.Checked = True Then
            impresoras = "HABILITADO"
        Else
            impresoras = "DESHABILITADO"
        End If

        If Check_familias.Checked = True Then
            familias = "HABILITADO"
        Else
            familias = "DESHABILITADO"
        End If

        If Check_subfamilias.Checked = True Then
            subfamilias = "HABILITADO"
        Else
            subfamilias = "DESHABILITADO"
        End If

        If Check_empresa.Checked = True Then
            empresa = "HABILITADO"
        Else
            empresa = "DESHABILITADO"
        End If


        If Check_respaldo.Checked = True Then
            respaldo = "HABILITADO"
        Else
            respaldo = "DESHABILITADO"
        End If

        If Check_cuentas_corrientes.Checked = True Then
            cuentas_corrientes = "HABILITADO"
        Else
            cuentas_corrientes = "DESHABILITADO"
        End If

        If Check_libro_de_compra.Checked = True Then
            libro_de_compras = "HABILITADO"
        Else
            libro_de_compras = "DESHABILITADO"
        End If

        'If Check_libro_de_ventas.Checked = True Then
        '    libro_de_ventas = "HABILITADO"
        'Else
        '    libro_de_ventas = "DESHABILITADO"
        'End If

        If Check_resumen_libro_de_compra.Checked = True Then
            resumen_libro_de_compras = "HABILITADO"
        Else
            resumen_libro_de_compras = "DESHABILITADO"
        End If

        'If Check_resumen_libro_de_ventas.Checked = True Then
        '    resumen_libro_de_ventas = "HABILITADO"
        'Else
        '    resumen_libro_de_ventas = "DESHABILITADO"
        'End If

        If Check_menu_adquisiciones.Checked = True Then
            menu_adquisiciones = "HABILITADO"
        Else
            menu_adquisiciones = "DESHABILITADO"
        End If

        If Check_menu_administracion.Checked = True Then
            menu_administracion = "HABILITADO"
        Else
            menu_administracion = "DESHABILITADO"
        End If

        'If Check_menu_contabilidad.Checked = True Then
        '    menu_contabilidad = "HABILITADO"
        'Else
        '    menu_contabilidad = "DESHABILITADO"
        'End If

        If Check_menu_configuracion.Checked = True Then
            menu_configuracion = "HABILITADO"
        Else
            menu_configuracion = "DESHABILITADO"
        End If

        If Check_menu_mantenedores.Checked = True Then
            menu_mantenedores = "HABILITADO"
        Else
            menu_mantenedores = "DESHABILITADO"
        End If

        If Check_menu_ventas.Checked = True Then
            menu_ventas = "HABILITADO"
        Else
            menu_ventas = "DESHABILITADO"
        End If

        If Check_menu_bodega.Checked = True Then
            menu_bodega = "HABILITADO"
        Else
            menu_bodega = "DESHABILITADO"
        End If

        'If Check_afp.Checked = True Then
        '    afp = "HABILITADO"
        'Else
        '    afp = "DESHABILITADO"
        'End If


        'If Check_menu_ayuda.Checked = True Then
        '    menu_ayuda = "HABILITADO"
        'Else
        '    menu_ayuda = "DESHABILITADO"
        'End If

        'If Check_menu_acerca_de.Checked = True Then
        '    menu_acerca_de = "HABILITADO"
        'Else
        '    menu_acerca_de = "DESHABILITADO"
        'End If

        If Check_reporte_libro_de_compra.Checked = True Then
            reporte_libro_de_compra = "HABILITADO"
        Else
            reporte_libro_de_compra = "DESHABILITADO"
        End If

        If Check_realizar_pedidos.Checked = True Then
            realizar_pedidos = "HABILITADO"
        Else
            realizar_pedidos = "DESHABILITADO"
        End If

        If Check_mis_pedidos.Checked = True Then
            mis_pedidos = "HABILITADO"
        Else
            mis_pedidos = "DESHABILITADO"
        End If

        If Check_revision_de_pedidos.Checked = True Then
            revision_de_pedidos = "HABILITADO"
        Else
            revision_de_pedidos = "DESHABILITADO"
        End If

        If Check_confirmacion_de_llegada.Checked = True Then
            confirmacion_de_llegada = "HABILITADO"
        Else
            confirmacion_de_llegada = "DESHABILITADO"
        End If

        If Check_buscar_facturas.Checked = True Then
            buscar_facturas = "HABILITADO"
        Else
            buscar_facturas = "DESHABILITADO"
        End If











        If Check_hojas_foleadas.Checked = True Then
            hojas_foleadas = "HABILITADO"
        Else
            hojas_foleadas = "DESHABILITADO"
        End If

        If CheckBox_servicios_de_lubricentro.Checked = True Then
            servicios_de_lubricentro = "HABILITADO"
        Else
            servicios_de_lubricentro = "DESHABILITADO"
        End If

        If CheckBox_adm_servicios_de_lubricentro.Checked = True Then
            adm_servicios_de_lubricentro = "HABILITADO"
        Else
            adm_servicios_de_lubricentro = "DESHABILITADO"
        End If

        If Check_existencias.Checked = True Then
            existencias = "HABILITADO"
        Else
            existencias = "DESHABILITADO"
        End If
















        'If Check_liquidaciones_de_sueldo.Checked = True Then
        '    liquidaciones_de_sueldo = "HABILITADO"
        'Else
        '    liquidaciones_de_sueldo = "DESHABILITADO"
        'End If

        'If Check_impuesto_unico.Checked = True Then
        '    impuesto_unico = "HABILITADO"
        'Else
        '    impuesto_unico = "DESHABILITADO"
        'End If

        'If Check_cargas_de_asignacion_familiar.Checked = True Then
        '    cargas_de_asignacion_familiar = "HABILITADO"
        'Else
        '    cargas_de_asignacion_familiar = "DESHABILITADO"
        'End If















        If Check_cotizacion_formal.Checked = True Then
            cotizacion_formal = "HABILITADO"
        Else
            cotizacion_formal = "DESHABILITADO"
        End If


        If Check_estados_cuenta_rango.Checked = True Then
            estado_de_cuenta_por_rango = "HABILITADO"
        Else
            estado_de_cuenta_por_rango = "DESHABILITADO"
        End If


        If Check_nota_de_credito.Checked = True Then
            notas_de_credito = "HABILITADO"
        Else
            notas_de_credito = "DESHABILITADO"
        End If


        If Check_ventas.Checked = True Then
            ventas = "HABILITADO"
        Else
            ventas = "DESHABILITADO"
        End If


        If Check_enviar_cotizacion.Checked = True Then
            enviarcotizacion = "HABILITADO"
        Else
            enviarcotizacion = "DESHABILITADO"
        End If


        If Check_stock_y_ubicaciones.Checked = True Then
            stocks_y_ubicaciones = "HABILITADO"
        Else
            stocks_y_ubicaciones = "DESHABILITADO"
        End If


        'If Check_agregar_trabajadores.Checked = True Then
        '    agregar_trabajadores = "HABILITADO"
        'Else
        '    agregar_trabajadores = "DESHABILITADO"
        'End If


        'If Check_agregar_empresas.Checked = True Then
        '    agregar_empresas = "HABILITADO"
        'Else
        '    agregar_empresas = "DESHABILITADO"
        'End If


        If Check_agregar_marcas.Checked = True Then
            agregar_marcas = "HABILITADO"
        Else
            agregar_marcas = "DESHABILITADO"
        End If


        'If Check_reimprimir_liquidaciones.Checked = True Then
        '    reimprimir_liquidaciones = "HABILITADO"
        'Else
        '    reimprimir_liquidaciones = "DESHABILITADO"
        'End If


        'If Check_control_de_meses.Checked = True Then
        '    control_de_meses = "HABILITADO"
        'Else
        '    control_de_meses = "DESHABILITADO"
        'End If


        'If Check_libro_de_remuneraciones.Checked = True Then
        '    libro_de_remuneraciones = "HABILITADO"
        'Else
        '    libro_de_remuneraciones = "DESHABILITADO"
        'End If


        If Check_valores.Checked = True Then
            valores = "HABILITADO"
        Else
            valores = "DESHABILITADO"
        End If





        If Check_proveedores_mas_pedidos.Checked = True Then
            proveedores_mas_pedidos = "HABILITADO"
        Else
            proveedores_mas_pedidos = "DESHABILITADO"
        End If






        If Check_libro_de_ventas.Checked = True Then
            libro_de_ventas = "HABILITADO"
        Else
            libro_de_ventas = "DESHABILITADO"
        End If

        If Check_buscar_totales.Checked = True Then
            buscar_totales = "HABILITADO"
        Else
            buscar_totales = "DESHABILITADO"
        End If

        If Check_CORREGIR_numeros.Checked = True Then
            CORREGIR_numeros = "HABILITADO"
        Else
            CORREGIR_numeros = "DESHABILITADO"
        End If

        If Check_ingreso_manual_de_ventas.Checked = True Then
            ingreso_manual_de_ventas = "HABILITADO"
        Else
            ingreso_manual_de_ventas = "DESHABILITADO"
        End If

        If Check_ingreso_de_creditos.Checked = True Then
            ingreso_de_creditos = "HABILITADO"
        Else
            ingreso_de_creditos = "DESHABILITADO"
        End If

        If Check_agregar_abonos.Checked = True Then
            agregar_abonos = "HABILITADO"
        Else
            agregar_abonos = "DESHABILITADO"
        End If

        If Check_traspaso_de_stock.Checked = True Then
            traspaso_de_stock = "HABILITADO"
        Else
            traspaso_de_stock = "DESHABILITADO"
        End If

        If Check_imputar_notas_de_credito.Checked = True Then
            imputar_notas_de_credito = "HABILITADO"
        Else
            imputar_notas_de_credito = "DESHABILITADO"
        End If

        If Check_imputar_abono.Checked = True Then
            imputar_abono = "HABILITADO"
        Else
            imputar_abono = "DESHABILITADO"
        End If

        If Check_codigos_de_barra.Checked = True Then
            codigos_de_barra = "HABILITADO"
        Else
            codigos_de_barra = "DESHABILITADO"
        End If

        If Check_comision_servicios.Checked = True Then
            comision_servicios = "HABILITADO"
        Else
            comision_servicios = "DESHABILITADO"
        End If

        If Check_envio_a_sucursal.Checked = True Then
            envio_a_sucursal = "HABILITADO"
        Else
            envio_a_sucursal = "DESHABILITADO"
        End If

        If Check_inventario.Checked = True Then
            inventario = "HABILITADO"
        Else
            inventario = "DESHABILITADO"
        End If

        If Check_cambio_de_productos.Checked = True Then
            cambio_de_producto = "HABILITADO"
        Else
            cambio_de_producto = "DESHABILITADO"
        End If

        If Check_mis_cotizaciones.Checked = True Then
            mis_cotizaciones = "HABILITADO"
        Else
            mis_cotizaciones = "DESHABILITADO"
        End If













        If Check_ruta_para_archivos_planos.Checked = True Then
            ruta_para_archivos_planos = "HABILITADO"
        Else
            ruta_para_archivos_planos = "DESHABILITADO"
        End If


        If Check_ruta_para_imagenes_de_sistema.Checked = True Then
            ruta_para_imagenes_de_sistema = "HABILITADO"
        Else
            ruta_para_imagenes_de_sistema = "DESHABILITADO"
        End If


        If Check_bitacora_de_cambios.Checked = True Then
            bitacora_de_cambios = "HABILITADO"
        Else
            bitacora_de_cambios = "DESHABILITADO"
        End If


        If Check_detalle_de_ventas.Checked = True Then
            detalle_de_ventas = "HABILITADO"
        Else
            detalle_de_ventas = "DESHABILITADO"
        End If


        If Check_detalle_de_ventas_por_doc.Checked = True Then
            detalle_de_ventas_por_doc = "HABILITADO"
        Else
            detalle_de_ventas_por_doc = "DESHABILITADO"
        End If


        If Check_cuentas_por_cobrar.Checked = True Then
            cuentas_por_cobrar = "HABILITADO"
        Else
            cuentas_por_cobrar = "DESHABILITADO"
        End If


        If Check_historial_de_cuenta.Checked = True Then
            historial_de_cuenta = "HABILITADO"
        Else
            historial_de_cuenta = "DESHABILITADO"
        End If


        If Check_nota_de_debito.Checked = True Then
            nota_de_debito = "HABILITADO"
        Else
            nota_de_debito = "DESHABILITADO"
        End If



        If Check_ticket_de_ventas.Checked = True Then
            ticket_de_ventas = "HABILITADO"
        Else
            ticket_de_ventas = "DESHABILITADO"
        End If


        If Check_tarjetas_de_presentacion.Checked = True Then
            tarjetas_de_presentacion = "HABILITADO"
        Else
            tarjetas_de_presentacion = "DESHABILITADO"
        End If

        If Check_consultas.Checked = True Then
            consultas_sql = "HABILITADO"
        Else
            consultas_sql = "DESHABILITADO"
        End If

        If Check_personalizar_sistema.Checked = True Then
            personalizar_sistema = "HABILITADO"
        Else
            personalizar_sistema = "DESHABILITADO"
        End If

        If Check_estado_de_deudas.Checked = True Then
            estado_de_deudas = "HABILITADO"
        Else
            estado_de_deudas = "DESHABILITADO"
        End If


        If Check_estado_de_deudas.Checked = True Then
            estado_de_deudas = "HABILITADO"
        Else
            estado_de_deudas = "DESHABILITADO"
        End If

        If Check_reservas.Checked = True Then
            reservas = "HABILITADO"
        Else
            reservas = "DESHABILITADO"
        End If


        If Check_subfamilias2.Checked = True Then
            subfamilia2 = "HABILITADO"
        Else
            subfamilia2 = "DESHABILITADO"
        End If


        If Check_detalle_compras.Checked = True Then
            detalle_compras = "HABILITADO"
        Else
            detalle_compras = "DESHABILITADO"
        End If


        If Check_detalle_compras_por_doc.Checked = True Then
            detalle_compras_por_doc = "HABILITADO"
        Else
            detalle_compras_por_doc = "DESHABILITADO"
        End If

        If Check_guias_de_traslado.Checked = True Then
            guia_de_traslado = "HABILITADO"
        Else
            guia_de_traslado = "DESHABILITADO"
        End If

        If Check_registro_de_autorizaciones.Checked = True Then
            registro_de_autorizaciones = "HABILITADO"
        Else
            registro_de_autorizaciones = "DESHABILITADO"
        End If

        If Check_asignar_familias.Checked = True Then
            asignar_familias = "HABILITADO"
        Else
            asignar_familias = "DESHABILITADO"
        End If

        If Check_ventas_asistidas.Checked = True Then
            ventas_asistidas = "HABILITADO"
        Else
            ventas_asistidas = "DESHABILITADO"
        End If


        If Check_actualizar_stock.Checked = True Then
            actualizar_stock = "HABILITADO"
        Else
            actualizar_stock = "DESHABILITADO"
        End If

        If Check_traspaso_de_creditos_a_historico.Checked = True Then
            traspaso_de_creditos_a_historico = "HABILITADO"
        Else
            traspaso_de_creditos_a_historico = "DESHABILITADO"
        End If

        If check_traspasar_stock_fisico.Checked = True Then
            traspaso_de_stock_fisico = "HABILITADO"
        Else
            traspaso_de_stock_fisico = "DESHABILITADO"
        End If

        If Check_adm_vales_de_cambio.Checked = True Then
            adm_vales_de_cambio = "HABILITADO"
        Else
            adm_vales_de_cambio = "DESHABILITADO"
        End If

        If Check_registro_de_actualizaciones.Checked = True Then
            registro_de_actualizaciones = "HABILITADO"
        Else
            registro_de_actualizaciones = "DESHABILITADO"
        End If

        If Check_actualizar_sistema.Checked = True Then
            actualizar_sistema = "HABILITADO"
        Else
            actualizar_sistema = "DESHABILITADO"
        End If



        'Dim hojas_foleadas As String
        'Dim servicios_de_lubricentro As String
        'Dim adm_servicios_de_lubricentro As String
        'Dim existencias As String
        'Dim reposicion_de_ventas As String





        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "UPDATE permisos SET clientes='" & (clientes) & "', usuarios='" & (usuarios) & "', proveedores='" & (proveedores) & "',  productos= '" & (productos) & "', retiradores = '" & (retiradores) & "', ventas = '" & (ventas) & "', compras = '" & (compras) & "', etiquetas = '" & (etiquetas) & "', cartola_kardex = '" & (cartola) & "', cambio_vendedor = '" & (cambio) & "', facturacion = '" & (facturacion) & "', pagos = '" & (pagos) & "', estados_decuenta = '" & (estados) & "', deudores = '" & (deudores) & "', nota_de_credito = '" & (notas) & "', envio_garantias = '" & (garantias) & "', caja_diaria = '" & (caja) & "', corregir_doc = '" & (corregir) & "', comisiones = '" & (comisiones) & "' , stock_minimo = '" & (stock) & "' , fac_vencidas = '" & (vencidas) & "' , credenciales = '" & (credenciales) & "'   , numeracion = '" & (numeracion) & "'  , imputar_pagos = '" & (imputar_pagos) & "' , estadisticas = '" & (estadisticas) & "', impresoras = '" & (impresoras) & "', familias = '" & (familias) & "', subfamilias = '" & (subfamilias) & "', empresa = '" & (empresa) & "' , respaldo = '" & (respaldo) & "' , cuentas_corrientes = '" & (cuentas_corrientes) & "' , libro_de_compras = '" & (libro_de_compras) & "' , libro_de_ventas = '" & (libro_de_ventas) & "', resumen_libro_de_compras = '" & (resumen_libro_de_compras) & "' , resumen_libro_de_ventas = '" & (resumen_libro_de_ventas) & "', menu_adquisiciones = '" & (menu_adquisiciones) & "' ,menu_configuracion = '" & (menu_configuracion) & "' , menu_administracion = '" & (menu_administracion) & "', menu_contabilidad = '" & (menu_contabilidad) & "', menu_mantenedores= '" & (menu_mantenedores) & "', menu_bodega = '" & (menu_bodega) & "'   , menu_ventas = '" & (menu_ventas) & "', menu_ayuda = '" & (menu_ayuda) & "', menu_acerca_de = '" & (menu_acerca_de) & "' , reporte_libro_de_compras = '" & (reporte_libro_de_compra) & "', realizar_pedidos = '" & (realizar_pedidos) & "', mis_pedidos = '" & (mis_pedidos) & "', revision_de_pedidos = '" & (revision_de_pedidos) & "', confirmacion_de_llegada = '" & (confirmacion_de_llegada) & "', buscar_facturas = '" & (buscar_facturas) & "', liquidaciones_de_sueldo = '" & (liquidaciones_de_sueldo) & "', impuesto_unico = '" & (impuesto_unico) & "', cargas_de_asignacion_familiar = '" & (cargas_de_asignacion_familiar) & "', COTIZACION_FORMAL='" & (cotizacion_formal) & "',ESTADO_DE_CUENTA_POR_RANGO='" & (estado_de_cuenta_por_rango) & "',NOTAS_DE_CREDITO='" & (notas_de_credito) & "',VENTAS='" & (ventas) & "',ENVIAR_COTIZACION='" & (enviarcotizacion) & "',stock_y_ubicaciones='" & (stocks_y_ubicaciones) & "',TRABAJADORES='" & (agregar_trabajadores) & "',EMPRESAS='" & (agregar_empresas) & "',MARCAS='" & (agregar_marcas) & "',REIMPRIMIR_LIQUIDACIONES_DE_SUELDO='" & (reimprimir_liquidaciones) & "',CONTROL_MESES='" & (control_de_meses) & "',libro_remuneraciones='" & (libro_de_remuneraciones) & "',VALORES='" & (valores) & "',agregar_afp='" & (afp) & "', proveedores_mas_pedidos='" & (proveedores_mas_pedidos) & "' , libro_de_ventas ='" & (libro_de_ventas) & "',buscar_totales ='" & (buscar_totales) & "',CORREGIR_numeros ='" & (CORREGIR_numeros) & "',ingreso_manual_de_ventas ='" & (ingreso_manual_de_ventas) & "',ingreso_de_creditos ='" & (ingreso_de_creditos) & "',agregar_abonos ='" & (agregar_abonos) & "',traspaso_de_stock ='" & (traspaso_de_stock) & "',imputar_notas_de_credito ='" & (imputar_notas_de_credito) & "',imputar_abono ='" & (imputar_abono) & "',codigos_de_barra ='" & (codigos_de_barra) & "',comision_servicios ='" & (comision_servicios) & "' ,envio_a_sucursal ='" & (envio_a_sucursal) & "' ,inventario ='" & (inventario) & "', cambio_de_productos ='" & (cambio_de_producto) & "', mis_cotizaciones ='" & (mis_cotizaciones) & "', ruta_para_archivos_planos = '" & (ruta_para_archivos_planos) & "', ruta_para_imagenes_de_sistema = '" & (ruta_para_imagenes_de_sistema) & "', bitacora_de_cambios = '" & (bitacora_de_cambios) & "', detalle_de_ventas = '" & (detalle_de_ventas) & "', detalle_de_ventas_por_doc = '" & (detalle_de_ventas_por_doc) & "', cuentas_por_cobrar = '" & (cuentas_por_cobrar) & "', historial_de_cuenta = '" & (historial_de_cuenta) & "', nota_de_debito = '" & (nota_de_debito) & "', ticket_de_ventas='" & (ticket_de_ventas) & "',tarjetas_de_presentacion='" & (tarjetas_de_presentacion) & "', consultas_sql='" & (consultas_sql) & "',personalizar_sistema ='" & (personalizar_sistema) & "',estado_de_deudas ='" & (estado_de_deudas) & "',reservas ='" & (reservas) & "', subfamilia2 ='" & (subfamilia2) & "', detalle_compras ='" & (detalle_compras) & "', detalle_compras_por_doc ='" & (detalle_compras_por_doc) & "', guia_de_traslado ='" & (guia_de_traslado) & "', registro_de_autorizaciones ='" & (registro_de_autorizaciones) & "', ventas_asistidas ='" & (ventas_asistidas) & "', asignar_familias ='" & (asignar_familias) & "',actualizar_stock='" & (actualizar_stock) & "', traspaso_de_creditos_a_historico='" & (traspaso_de_creditos_a_historico) & "', traspasar_stock_fisico='" & (traspaso_de_stock_fisico) & "', adm_vales_de_cambio='" & (adm_vales_de_cambio) & "',hojas_foleadas='" & (hojas_foleadas) & "', servicios_de_lubricentro='" & (servicios_de_lubricentro) & "', administrar_servicios_de_lubricentro='" & (adm_servicios_de_lubricentro) & "', existencias='" & (existencias) & "', reposicion_de_ventas='" & (reposicion_de_ventas) & "', registro_de_actualizaciones='" & (registro_de_actualizaciones) & "', actualizar_sistema='" & (actualizar_sistema) & "' WHERE rut_usuario = '" & (txt_rut.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PERMISOS','MODIFICACION DE PERMISOS','" & (txt_nombre.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        conexion.Close()

        MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        actualizar_permisos()
        limpiar()
        controles(False, True)

    End Sub


    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btn_primero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_primero.Click
        MiPos = 0
        mostrar(0)
        mostrar_datos_usuarios()
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
            mostrar_datos_usuarios()
        End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
            mostrar_datos_usuarios()
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        MiPos = DT.Rows.Count - 1
        mostrar(MiPos)
        mostrar_datos_usuarios()
    End Sub










    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
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
        'TextBox1.Text = ActiveControl.Name
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


    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

End Class