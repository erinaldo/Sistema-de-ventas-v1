Imports System.IO
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Form_seleccionar_documento_para_cambio_producto

    Dim cierre_iva_para_cambio_producto As Integer

    Private Sub Form_cargar_documento_cambio_producto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '  form_Menu_admin.WindowState = FormWindowState.Maximized
        Form_cambio_de_producto.Enabled = True
        Form_cambio_de_producto.WindowState = FormWindowState.Normal




        If Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Count = 0 Then
            Form_cambio_de_producto.controles(False, True)
            Form_cambio_de_producto.btn_nueva.Focus()
        Else
            Form_cambio_de_producto.txt_codigo.Focus()
        End If

    End Sub

    Private Sub Form_cargar_documento_cambio_producto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cargar_documento_cambio_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        combo_documento.SelectedItem = "BOLETA"
        llenar_combo_sucursales()
        txt_nro_documento.Focus()
        cargar_cierre_mes()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub


    Sub comprobar_estado_doc()
        If combo_documento.Text = "SALDO A FAVOR" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from saldo_a_favor where nro_saldo='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_referencia_saldo.Text = DS.Tables(DT.TableName).Rows(0).Item("nro_referencia")
            End If
            conexion.Close()



            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from vale_cambio where nro_vale='" & (txt_referencia_saldo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_estado_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("estado")
            End If
            conexion.Close()

            If txt_estado_doc.Text = "ANULADA" Then
                MsgBox("EL DOCUMENTO HA SIDO ANULADO", 0 + 16, "ERROR")
                Exit Sub
            Else
                mostrar_datos_documento()
                cargar_documento()
                Form_cambio_de_producto.calcular_totales_entra()
                Form_cambio_de_producto.txt_codigo.Focus()
                Form_cambio_de_producto.controles(True, False)

                Form_cambio_de_producto.revisar_traspaso()
                recuperar_conexion_actual()

                Form_cambio_de_producto.txt_codigo.Focus()
                Me.Close()
            End If
        End If


        If combo_documento.Text = "VALE DE CAMBIO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from vale_cambio where nro_vale='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_estado_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("estado")
            End If
            conexion.Close()

            If txt_estado_doc.Text = "ANULADA" Then
                MsgBox("EL DOCUMENTO HA SIDO ANULADO", 0 + 16, "ERROR")
                Exit Sub
            Else
                mostrar_datos_documento()
                cargar_documento()
                Form_cambio_de_producto.calcular_totales_entra()
                Form_cambio_de_producto.txt_codigo.Focus()
                Form_cambio_de_producto.controles(True, False)

                Form_cambio_de_producto.revisar_traspaso()
                recuperar_conexion_actual()

                Descontar_documento()


                Form_cambio_de_producto.txt_codigo.Focus()
                Me.Close()
            End If
        End If

        If combo_documento.Text = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from BOLETA where n_boleta='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_estado_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("estado")
            End If
            conexion.Close()

            If txt_estado_doc.Text = "ANULADA" Then
                MsgBox("EL DOCUMENTO HA SIDO ANULADO", 0 + 16, "ERROR")
                Exit Sub
            Else
                mostrar_datos_documento()
                cargar_documento()
                Form_cambio_de_producto.calcular_totales_entra()
                Form_cambio_de_producto.txt_codigo.Focus()
                Form_cambio_de_producto.controles(True, False)

                Form_cambio_de_producto.revisar_traspaso()
                recuperar_conexion_actual()

                Descontar_documento()

                Form_cambio_de_producto.txt_codigo.Focus()
                Me.Close()
            End If
        End If









        If combo_documento.Text = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from factura where n_factura='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_estado_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("estado")
            End If
            conexion.Close()

            If txt_estado_doc.Text = "ANULADA" Then
                MsgBox("EL DOCUMENTO HA SIDO ANULADO", 0 + 16, "ERROR")
                Exit Sub
            Else
                mostrar_datos_documento()
                cargar_documento()
                Form_cambio_de_producto.calcular_totales_entra()
                Form_cambio_de_producto.txt_codigo.Focus()
                Form_cambio_de_producto.controles(True, False)

                Form_cambio_de_producto.revisar_traspaso()
                recuperar_conexion_actual()

                Descontar_documento()

                Form_cambio_de_producto.txt_codigo.Focus()
                Me.Close()
            End If
        End If


        If combo_documento.Text = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from guia where n_guia='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_estado_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("estado")
            End If
            conexion.Close()

            If txt_estado_doc.Text = "ANULADA" Then
                MsgBox("EL DOCUMENTO HA SIDO ANULADO", 0 + 16, "ERROR")
                Exit Sub
            Else
                mostrar_datos_documento()
                cargar_documento()
                Form_cambio_de_producto.calcular_totales_entra()
                Form_cambio_de_producto.txt_codigo.Focus()
                Form_cambio_de_producto.controles(True, False)

                Form_cambio_de_producto.revisar_traspaso()
                recuperar_conexion_actual()

                Descontar_documento()

                Form_cambio_de_producto.txt_codigo.Focus()
                Me.Close()
            End If
        End If

    End Sub

    Sub cargar_cierre_mes()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select cierre_iva_para_cambio_producto from valores"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            cierre_iva_para_cambio_producto = DS2.Tables(DT2.TableName).Rows(0).Item("cierre_iva_para_cambio_producto")
        End If
        conexion.Close()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If combo_documento.Text = "" Then
            MsgBox("DEBE INGRESAR EL TIPO DE DOCUMENTO QUE AFECTA LA NC", 0 + 16, "ERROR")
            combo_documento.Focus()
            Exit Sub
        End If

        If txt_nro_documento.Text = "" Then
            MsgBox("DEBE INGRESAR EL NRO. DE DOCUMENTO QUE AFECTA LA NC", 0 + 16, "ERROR")
            txt_nro_documento.Focus()
            Exit Sub
        End If

        If Combo_sucursal.Text = "" Then
            MsgBox("CAMPO SUCURSAL VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_sucursal.Focus()
            Exit Sub
        End If

        If Combo_sucursal.Text = "-" Then
            MsgBox("CAMPO SUCURSAL VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_sucursal.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        'comprobar_estado_doc()

        If Combo_sucursal.Text = mirecintoempresa Then
            comprobar_estado_doc()
            Exit Sub
        End If

        'mostrar_datos_documento()
        'cargar_documento()
        'Form_cambio_de_producto.calcular_totales_entra()
        'Form_cambio_de_producto.txt_codigo.Focus()
        'Form_cambio_de_producto.controles(True, False)
        'Form_cambio_de_producto.txt_codigo.Focus()
        'Me.Close()

        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String

        For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1

            nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
            nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
            base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
            clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
            usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
            recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

            recinto = Trim(Replace(recinto, "'", "´"))

            If Combo_sucursal.Text = recinto Then

                conexion.Close()
                conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                Try

                    conexion.Open()
                    conexion.Close()

                    comprobar_estado_doc()
                    Form_cambio_de_producto.revisar_traspaso()
                    recuperar_conexion_actual()


                    Descontar_documento()


                    lbl_mensaje.Visible = False
                    Me.Enabled = True

                Catch mierror As MySqlException
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                Catch mierror As MissingManifestResourceException
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End Try
                Exit For
            End If
        Next


    End Sub










    Sub Descontar_documento()

        Dim nro_nc_descontar As String = ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from nota_credito where tipo_documento='" & (Me.combo_documento.Text) & "' and nro_documento='" & (Me.txt_nro_documento.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                nro_nc_descontar = DS.Tables(DT.TableName).Rows(i).Item("n_nota_credito")
                Descontar_documento_detalle(nro_nc_descontar)

            Next
        End If

    End Sub






    Sub Descontar_documento_detalle(ByVal nro_nc_descontar As String)

        Dim Cantidad_cargada As String
        Dim Codigo_cargada As Integer

        Dim Cantidad_descontar As String
        Dim Codigo_descontar As Integer


        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        SC.Connection = conexion
        SC2.CommandText = "select * from detalle_nota_credito where n_nota_credito='" & (nro_nc_descontar) & "'"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then

            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1

                Codigo_descontar = DS2.Tables(DT2.TableName).Rows(i).Item("cod_producto")
                Cantidad_descontar = DS2.Tables(DT2.TableName).Rows(i).Item("cantidad")

                For fila = 0 To Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Count - 1

                    Codigo_cargada = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(fila).Cells(0).Value.ToString
                    Cantidad_cargada = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(fila).Cells(4).Value.ToString



                    'VarCodProducto = grilla_detalle_venta_entra.Rows(fila).Cells(0).Value.ToString
                    'VarCantidad = grilla_detalle_venta_entra.Rows(fila).Cells(4).Value.ToString
                    'VarPrecio = grilla_detalle_venta_entra.Rows(fila).Cells(3).Value.ToString



                    If Codigo_cargada = Codigo_descontar Then

                        Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(fila).Cells(4).Value = Cantidad_cargada - Cantidad_descontar

                    End If

                Next

            Next

        End If


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

        Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Clear()

        If combo_documento.Text = "SALDO A FAVOR" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from saldo_a_favor where nro_saldo='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add("-", _
                                                      "SALDO A FAVOR NRO. " & DS.Tables(DT.TableName).Rows(i).Item("NRO_SALDO"), _
                                                      "FECHA " & DS.Tables(DT.TableName).Rows(i).Item("FECHA_SALDO"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("TOTAL_SALDO"), _
                                                        "1", _
                                                          "0", _
                                                           "0", _
                                                            DS.Tables(DT.TableName).Rows(i).Item("TOTAL_SALDO"), _
                                                             "0", _
                                                              "0", _
                                                               DS.Tables(DT.TableName).Rows(i).Item("TOTAL_SALDO"))
                Next
                conexion.Close()
            End If
        End If


        If combo_documento.Text = "VALE DE CAMBIO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_vale_cambio where detalle_vale_cambio.nro_vale='" & (txt_nro_documento.Text) & "' and movimiento='SALE'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    '   grilla_detalle_venta.Rows.Clear()
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
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
            End If
        End If


        If combo_documento.Text = "BOLETA" Then
            'conexion.Close()
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'SC.Connection = conexion
            'SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (txt_nro_documento.Text) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)
            'If DS.Tables(DT.TableName).Rows.Count > 0 Then
            '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '        VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
            '        varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
            '        vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
            '        VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
            '        VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
            '        VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
            '        VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
            '        VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
            '        VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
            '        VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
            '        VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
            '        conexion.Close()
            '        DS2.Tables.Clear()
            '        DT2.Rows.Clear()
            '        DT2.Columns.Clear()
            '        DS2.Clear()
            '        conexion.Open()
            '        SC2.Connection = conexion
            '        SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
            '        DA2.SelectCommand = SC2
            '        DA2.Fill(DT2)
            '        DS2.Tables.Add(DT2)
            '        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            '            VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
            '        End If
            '        conexion.Close()

            '        If VarPrecioReal = "0" Then
            '            VarPrecioReal = VarValorUnitario
            '        End If

            '        VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
            '        VarPorcentaje = 100 - VarPorcentaje
            '        VarDescuento = VarPrecioReal - VarValorUnitario
            '        VarValorUnitario = VarPrecioReal
            '        iva_valor = valor_iva / 100 + 1
            '        VarNeto = (VarTotal / iva_valor)
            '        VarIva = (VarNeto) * valor_iva / 100
            '        Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(VarCodProducto,
            '        varnombre,
            '        vartecnico,
            '        VarValorUnitario,
            '        VarCantidad,
            '        VarNeto,
            '        VarIva,
            '        VarSubtotal,
            '        VarPorcentaje,
            '        VarDescuento,
            '        VarTotal)
            '    Next
            'End If



























            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (txt_nro_documento.Text) & "'"
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
                    VarValorUnitario = VarPrecioReal
                    iva_valor = valor_iva / 100 + 1
                    VarNeto = (VarTotal / iva_valor)
                    VarIva = (VarNeto) * valor_iva / 100

                    If VarDescuento < 0 Then
                        VarDescuento = 0
                        VarPorcentaje = 0
                        VarValorUnitario = VarTotal / VarCantidad
                    End If

                    Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(VarCodProducto,
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

                If Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Count <> 0 Then
                    If Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(0).Width = 85 Then
                        Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(0).Width = 86
                    Else
                        Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(0).Width = 85
                    End If
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(1).Width = 220
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(2).Width = 195
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(3).Width = 85
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(4).Width = 85
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(5).Width = 85
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(6).Width = 85
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(7).Width = 85
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(8).Width = 36
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(9).Width = 85
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Columns(10).Width = 85
                End If






            End If
        End If

        If combo_documento.Text = "BOLETA DE CREDITO" Then
            '    conexion.Close()
            '    DS.Tables.Clear()
            '    DT.Rows.Clear()
            '    DT.Columns.Clear()
            '    DS.Clear()
            '    SC.Connection = conexion
            '    SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (txt_nro_documento.Text) & "'"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            '    DS.Tables.Add(DT)

            '    Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

            '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '            '   grilla_detalle_venta.Rows.Clear()
            '            Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
            '                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
            '                                            DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
            '                                             DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
            '                                              DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
            '                                               DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
            '                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
            '                                                 DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
            '                                                  DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
            '                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
            '                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
            '        Next
            '        conexion.Close()
            '    End If
            'End If
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
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
                    End If
                    conexion.Close()

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
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(VarCodProducto, _
                    varnombre, _
                    vartecnico, _
                    VarValorUnitario, _
                    VarCantidad, _
                    VarNeto, _
                    VarIva, _
                    VarSubtotal, _
                    VarPorcentaje, _
                    VarDescuento, _
                    VarTotal)
                Next
            End If
        End If

        'If combo_documento.Text = "BOLETA DE CREDITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    SC.Connection = conexion
        '    SC.CommandText = "select * from detalle_boleta_credito where detalle_boleta_credito.n_boleta_credito='" & (txt_nro_documento.Text) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)

        '    Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

        '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '            '  grilla_detalle_venta.Rows.Clear()
        '            Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
        '                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
        '                                            DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
        '                                             DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
        '                                              DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
        '                                               DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
        '                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
        '                                                 DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
        '                                                  DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
        '                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
        '                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
        '        Next

        '        conexion.Close()
        '    End If
        'End If

        If combo_documento.Text = "FACTURA" Then
            '    conexion.Close()
            '    DS.Tables.Clear()
            '    DT.Rows.Clear()
            '    DT.Columns.Clear()
            '    DS.Clear()
            '    SC.Connection = conexion
            '    SC.CommandText = "select * from detalle_factura where detalle_factura.n_factura='" & (txt_nro_documento.Text) & "'"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            '    DS.Tables.Add(DT)

            '    Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

            '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '            '  grilla_detalle_venta.Rows.Clear()
            '            Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
            '                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
            '                                            DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
            '                                             DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
            '                                              DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
            '                                               DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
            '                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
            '                                                 DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
            '                                                  DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
            '                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
            '                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
            '        Next
            '        conexion.Close()
            '    End If
            'End If
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura where detalle_factura.n_factura='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
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
                    End If
                    conexion.Close()

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
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(VarCodProducto, _
                    varnombre, _
                    vartecnico, _
                    VarValorUnitario, _
                    VarCantidad, _
                    VarNeto, _
                    VarIva, _
                    VarSubtotal, _
                    VarPorcentaje, _
                    VarDescuento, _
                    VarTotal)
                Next
            End If
        End If

        If combo_documento.Text = "FACTURA DE CREDITO" Then
            '    conexion.Close()
            '    DS.Tables.Clear()
            '    DT.Rows.Clear()
            '    DT.Columns.Clear()
            '    DS.Clear()
            '    SC.Connection = conexion
            '    SC.CommandText = "select * from detalle_factura where detalle_factura.n_factura='" & (txt_nro_documento.Text) & "'"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            '    DS.Tables.Add(DT)

            '    Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

            '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '            '  grilla_detalle_venta.Rows.Clear()
            '            Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
            '                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
            '                                            DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
            '                                             DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
            '                                              DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
            '                                               DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
            '                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
            '                                                 DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
            '                                                  DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
            '                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
            '                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
            '        Next
            '        conexion.Close()
            '    End If
            'End If
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta where detalle_factura.n_factura='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
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
                    End If
                    conexion.Close()

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
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(VarCodProducto, _
                    varnombre, _
                    vartecnico, _
                    VarValorUnitario, _
                    VarCantidad, _
                    VarNeto, _
                    VarIva, _
                    VarSubtotal, _
                    VarPorcentaje, _
                    VarDescuento, _
                    VarTotal)
                Next
            End If
        End If

        If combo_documento.Text = "COTIZACION" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_cotizacion where detalle_cotizacion.n_cotizacion='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    '  grilla_detalle_venta.Rows.Clear()
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
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
            End If
        End If

        If combo_documento.Text = "GUIA" Then
            '    conexion.Close()
            '    DS.Tables.Clear()
            '    DT.Rows.Clear()
            '    DT.Columns.Clear()
            '    DS.Clear()
            '    SC.Connection = conexion
            '    SC.CommandText = "select * from detalle_guia where detalle_guia.n_guia='" & (txt_nro_documento.Text) & "'"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            '    DS.Tables.Add(DT)

            '    Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

            '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '            ' grilla_detalle_venta.Rows.Clear()
            '            Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
            '                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
            '                                            DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
            '                                             DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
            '                                              DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
            '                                               DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
            '                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
            '                                                 DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
            '                                                  DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
            '                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
            '                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
            '        Next
            '        conexion.Close()
            '    End If
            'End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_guia where detalle_guia.n_guia='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
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
                    End If
                    conexion.Close()

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
                    Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(VarCodProducto, _
                    varnombre, _
                    vartecnico, _
                    VarValorUnitario, _
                    VarCantidad, _
                    VarNeto, _
                    VarIva, _
                    VarSubtotal, _
                    VarPorcentaje, _
                    VarDescuento, _
                    VarTotal)
                Next
            End If
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




    Sub mostrar_datos_documento()



        If combo_documento.Text = "SALDO A FAVOR" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from saldo_a_favor where nro_saldo='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Form_cambio_de_producto.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_saldo")
                dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_saldo")
                ' Form_cambio_de_producto.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                ' Form_cambio_de_producto.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_cambio_de_producto.txt_porcentaje_desc.Text = "0"
                Form_cambio_de_producto.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total_saldo")
                Form_cambio_de_producto.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_cambio_de_producto.txt_nro_doc_referencia.Text = txt_nro_documento.Text
                ' Form_cambio_de_producto.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text
                Form_cambio_de_producto.lbl_referencia.Text = combo_documento.Text & " NRO. " & txt_nro_documento.Text
                Form_cambio_de_producto.txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("usuario_responsable")
                Form_cambio_de_producto.txt_porcentaje_desc_entra.Text = "0"
            Else

                conexion.Close()
                Exit Sub
            End If
            conexion.Close()
        End If



        If combo_documento.Text = "VALE DE CAMBIO" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from vale_cambio where nro_vale='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Form_cambio_de_producto.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha")
                dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha")
                ' Form_cambio_de_producto.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                ' Form_cambio_de_producto.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_cambio_de_producto.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_cambio_de_producto.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total_positivo")
                Form_cambio_de_producto.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_cambio_de_producto.txt_nro_doc_referencia.Text = txt_nro_documento.Text
                ' Form_cambio_de_producto.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text
                Form_cambio_de_producto.lbl_referencia.Text = combo_documento.Text & " NRO. " & txt_nro_documento.Text
                Form_cambio_de_producto.txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("usuario_responsable")
                Form_cambio_de_producto.txt_porcentaje_desc_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
            Else

                conexion.Close()
                Exit Sub
            End If
            conexion.Close()
        End If



        If combo_documento.Text = "BOLETA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from BOLETA where n_boleta='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Form_cambio_de_producto.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                ' Form_cambio_de_producto.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_cambio_de_producto.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_cambio_de_producto.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_cambio_de_producto.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                Form_cambio_de_producto.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_cambio_de_producto.txt_nro_doc_referencia.Text = txt_nro_documento.Text
                ' Form_cambio_de_producto.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text
                Form_cambio_de_producto.lbl_referencia.Text = combo_documento.Text & " NRO. " & txt_nro_documento.Text
                Form_cambio_de_producto.txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("usuario_responsable")
                Form_cambio_de_producto.txt_porcentaje_desc_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
            Else

                conexion.Close()
                Exit Sub
            End If
            conexion.Close()
        End If

        If combo_documento.Text = "FACTURA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from factura where n_factura='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Form_cambio_de_producto.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                'Form_cambio_de_producto.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_cambio_de_producto.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_cambio_de_producto.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_cambio_de_producto.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                Form_cambio_de_producto.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_cambio_de_producto.txt_nro_doc_referencia.Text = txt_nro_documento.Text
                '   Form_cambio_de_producto.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text
                Form_cambio_de_producto.lbl_referencia.Text = combo_documento.Text & " NRO. " & txt_nro_documento.Text
                Form_cambio_de_producto.txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("usuario_responsable")
                Form_cambio_de_producto.txt_porcentaje_desc_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
            End If
            conexion.Close()
        End If


        If combo_documento.Text = "GUIA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from guia where n_guia='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Form_cambio_de_producto.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                '   Form_cambio_de_producto.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_cambio_de_producto.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_cambio_de_producto.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_cambio_de_producto.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                Form_cambio_de_producto.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_cambio_de_producto.txt_nro_doc_referencia.Text = txt_nro_documento.Text
                'Form_cambio_de_producto.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text
                Form_cambio_de_producto.lbl_referencia.Text = combo_documento.Text & " NRO. " & txt_nro_documento.Text
                Form_cambio_de_producto.txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("usuario_responsable")
                Form_cambio_de_producto.txt_porcentaje_desc_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub combo_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documento.SelectedIndexChanged
        txt_nro_documento.Focus()
    End Sub

    Private Sub txt_nro_documento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_documento.KeyPress
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
            btn_aceptar.Focus()
        End If
    End Sub

    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        btn_aceptar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub


    Private Sub txt_nro_documento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_documento.GotFocus
        txt_nro_documento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_documento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_documento.LostFocus
        txt_nro_documento.BackColor = Color.White
    End Sub


    Private Sub combo_documento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documento.GotFocus
        combo_documento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_documento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documento.LostFocus
        combo_documento.BackColor = Color.White
    End Sub

    Private Sub Combo_sucursal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_sucursal.GotFocus
        Combo_sucursal.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_sucursal.LostFocus
        Combo_sucursal.BackColor = Color.White
    End Sub

    Private Sub Combo_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_sucursal.SelectedIndexChanged

    End Sub

    Sub llenar_combo_sucursales()
        Combo_sucursal.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from sucursales order by nombre_sucursal"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        Combo_sucursal.Items.Add("-")

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
            Next
        End If
        Combo_sucursal.SelectedItem = mirecintoempresa
        conexion.Close()
    End Sub
End Class