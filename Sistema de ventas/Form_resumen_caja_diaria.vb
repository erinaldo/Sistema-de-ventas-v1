Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Resources
Imports MySql.Data.MySqlClient

Public Class Form_resumen_caja_diaria
    Dim mifecha2 As String
    Dim nombre_sucursal As String

    Private Sub Form_resumen_caja_diaria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_resumen_caja_diaria_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_resumen_caja_diaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_sucursales()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
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
        combo_sucursal.Items.Add("MULTISUCURSAL")

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
            Next
        End If
        Combo_sucursal.SelectedItem = mirecintoempresa
        conexion.Close()
    End Sub

    Sub mostrar_caja()
        dtp_ingresar.Text = dtp_desde.Text

        While (dtp_ingresar.Value < dtp_hasta.Value)
            txt_boletas_contado.Text = "0"
            txt_boletas_credito.Text = "0"
            txt_boletas_cantidad.Text = "0"

            txt_facturas_contado.Text = "0"
            txt_facturas_credito.Text = "0"
            txt_facturas_cantidad.Text = "0"

            txt_guias_contado.Text = "0"
            txt_guias_credito.Text = "0"
            txt_guias_cantidad.Text = "0"

            txt_abonos_contado.Text = "0"
            txt_abonos_credito.Text = "0"
            'txt_abonos_cantidad.Text = "0"

            txt_egresos.Text = "0"

            Dim mifecha As Date
            mifecha = dtp_ingresar.Text
            mifecha2 = mifecha.ToString("yyy-MM-dd")

            'BOLETAS CONTADO
            txt_boletas_contado.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as BOLETAS from boleta where TIPO like '%BOLETA%' and fecha_venta ='" & (mifecha2) & "' and condiciones <>'CREDITO' and estado='EMITIDA' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_boletas_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("BOLETAS")
                Catch
                    txt_boletas_contado.Text = "0"
                End Try
            End If

            'FACTURAS CONTADO
            txt_facturas_contado.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as facturas from factura where TIPO like '%FACTURA%' and fecha_venta ='" & (mifecha2) & "' and condiciones <>'CREDITO' and estado='EMITIDA' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_facturas_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("facturas")
                Catch
                    txt_facturas_contado.Text = "0"
                End Try
            End If

            'GUIAS CONTADO
            txt_guias_contado.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as guias from guia where estado='SIN FACTURAR' and fecha_venta ='" & (mifecha2) & "' AND CONDICIONES <> 'TRASLADO' AND CONDICIONES <> 'CREDITO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_guias_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("guias")
                Catch
                    txt_guias_contado.Text = "0"
                End Try
            End If

            'ABONOS CONTADO
            txt_abonos_contado.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(monto_abono) as abonos from abono where TIPO like '%ABONO%'  and fecha ='" & (mifecha2) & "' and condicion_abono <>'CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_abonos_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("abonos")
                Catch
                    txt_abonos_contado.Text = "0"
                End Try
            End If

            'NDC CONTADO
            txt_ndc_contado.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where TIPO like '%NOTA DE CREDITO%' and fecha_venta ='" & (mifecha2) & "' and condiciones <>'CREDITO' and estado='EMITIDA' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_ndc_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                Catch
                    txt_ndc_contado.Text = "0"
                End Try
            End If

            'BOLETAS CREDITO
            txt_boletas_credito.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            'SC.CommandText = "select sum(total) as BOLETAs from BOLETA where TIPO like '%BOLETA%'  and fecha_venta ='" & (mifecha2) & "' and estado='EMITIDA'  and condiciones ='CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            SC.CommandText = "select sum(total) as BOLETAS from boleta where estado='EMITIDA' and fecha_venta ='" & (mifecha2) & "' AND CONDICIONES ='CREDITO'  "
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_boletas_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("BOLETAS")
                Catch
                    txt_boletas_credito.Text = "0"
                End Try
            End If

            'FACTURAS CREDITO
            txt_facturas_credito.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as facturas from factura where TIPO like '%FACTURA%'  and fecha_venta ='" & (mifecha2) & "' and estado='EMITIDA'  and condiciones ='CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_facturas_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("facturas")
                Catch
                    txt_facturas_credito.Text = "0"
                End Try
            End If

            'GUIAS CREDITO
            txt_guias_credito.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            'SC.CommandText = "select sum(total) as guias from guia where TIPO like '%GUIA%'  and fecha_venta ='" & (mifecha2) & "' AND CONDICIONES <> 'TRASLADO'  and condiciones ='CREDITO' and estado='SIN FACTURAR'"
            SC.CommandText = "select sum(total) as guias from guia where estado='SIN FACTURAR' and fecha_venta ='" & (mifecha2) & "' AND CONDICIONES <> 'TRASLADO' AND CONDICIONES = 'CREDITO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_guias_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("guias")
                Catch
                    txt_guias_credito.Text = "0"
                End Try
            End If

            'ABONOS CREDITO
            txt_abonos_credito.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(monto_abono) as abonos from abono where TIPO like '%ABONO%'  and fecha ='" & (mifecha2) & "' and condicion_abono ='CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_abonos_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("abonos")
                Catch
                    txt_abonos_credito.Text = "0"
                End Try
            End If

            'NDC CREDITO
            txt_ndc_credito.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where TIPO like '%NOTA DE CREDITO%'  and fecha_venta ='" & (mifecha2) & "' and estado='EMITIDA'  and condiciones ='CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_ndc_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                Catch
                    txt_ndc_credito.Text = "0"
                End Try
            End If

            'BOLETAS PIE
            txt_boletas_pie.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(pie) as BOLETAS_PIE from boleta where TIPO like '%BOLETA%' and estado='EMITIDA' and fecha_venta ='" & (mifecha2) & "' and condicion_de_pago_pie <>'CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_boletas_pie.Text = DS.Tables(DT.TableName).Rows(0).Item("BOLETAS_PIE")
                Catch
                    txt_boletas_pie.Text = "0"
                End Try
            End If

            txt_boletas_credito.Text = Val(txt_boletas_credito.Text) - Val(txt_boletas_pie.Text)



            'FACTURAS PIE
            txt_facturas_pie.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(pie) as facturas_pie from factura where TIPO like '%FACTURA%' and estado='EMITIDA' and fecha_venta ='" & (mifecha2) & "' and condicion_de_pago_pie <>'CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_facturas_pie.Text = DS.Tables(DT.TableName).Rows(0).Item("facturas_pie")
                Catch
                    txt_facturas_pie.Text = "0"
                End Try
            End If

            'GUIAS PIE
            txt_guias_pie.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select sum(pie) as guias_pie from guia where TIPO like '%GUIA%'   and estado='SIN FACTURAR' and fecha_venta ='" & (mifecha2) & "' and condicion_de_pago_pie <>'CREDITO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_guias_pie.Text = DS.Tables(DT.TableName).Rows(0).Item("guias_pie")
                Catch
                    txt_guias_pie.Text = "0"
                End Try
            End If

            'EGRESOS
            txt_egresos.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "SELECT SUM(monto) AS TOTAL FROM detalle_cuadratura_caja WHERE FECHA='" & (mifecha2) & "' and  monto < 0"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_egresos.Text = DS.Tables(DT.TableName).Rows(0).Item("TOTAL")
                Catch ex As InvalidCastException
                    txt_egresos.Text = "0"
                End Try
            End If

            'CANTIDAD BOLETAS
            txt_boletas_cantidad.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select count(cod_auto) as cantidad from boleta where TIPO <> 'AJUSTE' AND fecha_venta ='" & (mifecha2) & "' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_boletas_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
            End If

            'CANTIDAD FACTURAS
            txt_facturas_cantidad.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select count(cod_auto) as cantidad from factura where TIPO <> 'AJUSTE'AND fecha_venta ='" & (mifecha2) & "' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_facturas_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
            End If

            'CANTIDAD GUIAS
            txt_guias_cantidad.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select count(cod_auto) as cantidad from guia where TIPO <> 'AJUSTE' AND fecha_venta ='" & (mifecha2) & "' and estado = 'SIN FACTURAR'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_guias_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
            End If

            'CANTIDAD NDC
            txt_ndc_cantidad.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select count(cod_auto) as cantidad from nota_credito where TIPO <> 'AJUSTE'AND fecha_venta ='" & (mifecha2) & "' and estado <> 'ANULADA' and estado <> 'ANULADO'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_ndc_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
            End If


            'TOTAL EFECTIVO
            txt_total_efectivo.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "SELECT sum(valor) as efectivo FROM detalle_condicion_de_pago where condicion_de_pago='EFECTIVO' and fecha='" & (mifecha2) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_total_efectivo.Text = DS.Tables(DT.TableName).Rows(0).Item("efectivo")
                Catch
                    txt_total_efectivo.Text = "0"
                End Try
            End If

            'TOTAL CHEQUE AL DIA
            txt_total_cheque_al_dia.Text = "0"
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "SELECT sum(valor) as cheque_al_dia FROM detalle_condicion_de_pago where condicion_de_pago='CHEQUE AL DIA' and fecha='" & (mifecha2) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_total_cheque_al_dia.Text = DS.Tables(DT.TableName).Rows(0).Item("cheque_al_dia")
                Catch
                    txt_total_cheque_al_dia.Text = "0"
                End Try
            End If
            ''OTROS

            'conexion.Close()
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'SC.Connection = conexion

            'SC.CommandText = "select sum(valor) as OTROS from detalle_condicion_de_pago where  tipo_doc ='ABONO' AND fecha ='" & (mifecha2) & "' and condicion_de_pago <> 'EFECTIVO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"

            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            'If DS.Tables(DT.TableName).Rows.Count > 0 Then

            'txt_8.Text = DS.Tables(DT.TableName).Rows(0).Item("OTROS")

            'End If

            'grilla_libro_compras.Columns.Add("", "FECHA")
            'grilla_libro_compras.Columns.Add("", "SUCURSAL")
            'grilla_libro_compras.Columns.Add("", "CONTADO")
            'grilla_libro_compras.Columns.Add("", "CREDITO")
            'grilla_libro_compras.Columns.Add("", "CONTADO BOL.")
            'grilla_libro_compras.Columns.Add("", "CREDITO BOL.")
            'grilla_libro_compras.Columns.Add("", "CANT. BOL.")
            'grilla_libro_compras.Columns.Add("", "CONTADO FAC.")
            'grilla_libro_compras.Columns.Add("", "CREDITO FAC.")
            'grilla_libro_compras.Columns.Add("", "CANT. FAC.")
            'grilla_libro_compras.Columns.Add("", "CONTADO GUI.")
            'grilla_libro_compras.Columns.Add("", "CREDITO GUI.")
            'grilla_libro_compras.Columns.Add("", "CANT. GUI.")
            'grilla_libro_compras.Columns.Add("", "ABONOS")
            'grilla_libro_compras.Columns.Add("", "CANT. GUI.")
            'grilla_libro_compras.Columns.Add("", "PIE")


            Dim total_contado As Integer = 0
            Dim total_credito As Integer = 0
            Dim total_pie As Integer = 0

            total_contado = Val(txt_boletas_contado.Text) + Val(txt_facturas_contado.Text) + Val(txt_guias_contado.Text)
            total_credito = Val(txt_boletas_credito.Text) + Val(txt_facturas_credito.Text) + Val(txt_guias_credito.Text)
            total_pie = Val(txt_boletas_pie.Text) + Val(txt_facturas_pie.Text) + Val(txt_guias_pie.Text)

            total_credito = Val(total_credito) + Val(total_pie)

            Dim depositar As String
            depositar = Val(txt_boletas_contado.Text) + Val(txt_facturas_contado.Text) + Val(txt_guias_contado.Text) + Val(txt_abonos_contado.Text) + Val(txt_egresos.Text)

            'depositar = Val(txt_total_efectivo.Text) + Val(txt_total_cheque_al_dia.Text) + Val(txt_total_egresos.Text) + Val(txt_total_anticipos.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_pendientes.Text)


            'depositar = Val(txt_total_efectivo.Text) + Val(txt_total_cheque_al_dia.Text) + Val(txt_total_egresos.Text) + Val(txt_total_anticipos.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_pendientes.Text)

            depositar = Val(txt_total_efectivo.Text) + Val(txt_total_cheque_al_dia.Text) + Val(txt_egresos.Text)


            grilla_libro_compras.Rows.Add(dtp_ingresar.Text, nombre_sucursal, total_contado, total_credito, txt_boletas_contado.Text, txt_boletas_credito.Text, txt_boletas_cantidad.Text, txt_facturas_contado.Text, txt_facturas_credito.Text, txt_facturas_cantidad.Text, txt_guias_contado.Text, txt_guias_credito.Text, txt_guias_cantidad.Text, txt_abonos_contado.Text, total_pie, txt_egresos.Text, txt_ndc_contado.Text, txt_ndc_credito.Text, txt_ndc_cantidad.Text, depositar)

            dtp_ingresar.Value = dtp_ingresar.Value.AddDays(Val(+1))

        End While

    End Sub









    Sub ingresar_fechas()

        grilla_libro_compras.Rows.Clear()

        Dim contador As Integer
        contador = "1"

        dtp_ingresar.Text = dtp_desde.Text

        '   grilla_documento.Rows.Add(dtp_desde.Text)

        ' dtp_ingresar.Value = dtp_ingresar.Value.AddDays(Val(+1))

        While (dtp_ingresar.Value < dtp_hasta.Value)

            grilla_libro_compras.Rows.Add(dtp_ingresar.Text)
            dtp_ingresar.Value = dtp_ingresar.Value.AddDays(Val(+1))

        End While

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("", "FECHA")
        grilla_libro_compras.Columns.Add("", "SUCURSAL")
        grilla_libro_compras.Columns.Add("", "CONTADO")
        grilla_libro_compras.Columns.Add("", "CREDITO")
        grilla_libro_compras.Columns.Add("", "CONTADO BOL.")
        grilla_libro_compras.Columns.Add("", "CREDITO BOL.")
        grilla_libro_compras.Columns.Add("", "CANT. BOL.")
        grilla_libro_compras.Columns.Add("", "CONTADO FAC.")
        grilla_libro_compras.Columns.Add("", "CREDITO FAC.")
        grilla_libro_compras.Columns.Add("", "CANT. FAC.")
        grilla_libro_compras.Columns.Add("", "CONTADO GUI.")
        grilla_libro_compras.Columns.Add("", "CREDITO GUI.")
        grilla_libro_compras.Columns.Add("", "CANT. GUI.")
        grilla_libro_compras.Columns.Add("", "ABONOS")
        grilla_libro_compras.Columns.Add("", "PIE")
        grilla_libro_compras.Columns.Add("", "EGRESOS")

        grilla_libro_compras.Columns.Add("", "CONTADO NDC")
        grilla_libro_compras.Columns.Add("", "CREDITO NC")
        grilla_libro_compras.Columns.Add("", "CANT. NDC")
        grilla_libro_compras.Columns.Add("", "A DEPOSITAR")

        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String

        If combo_sucursal.Text = "MULTISUCURSAL" Then
            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString
                recinto = Trim(Replace(recinto, "'", "´"))

                If recinto <> "VALDIVIA 060" Then
                    conexion.Close()
                    conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    'Try
                    nombre_sucursal = recinto
                    mostrar_caja()
                    ' Catch mierror As MySqlException
                    'Catch mierror As MissingManifestResourceException
                    ' End Try
                End If
            Next
        End If

        If combo_sucursal.Text <> "MULTISUCURSAL" Then
            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString
                recinto = Trim(Replace(recinto, "'", "´"))

                If recinto = combo_sucursal.Text Then
                    conexion.Close()
                    conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    'Try
                    nombre_sucursal = recinto
                    mostrar_caja()
                    ' Catch mierror As MySqlException
                    'Catch mierror As MissingManifestResourceException
                    'End Try
                End If
            Next
        End If

        recuperar_conexion()

        'grilla_libro_compras.Columns(0).SortMode = True
        'grilla_libro_compras.Sort(grilla_libro_compras.Columns(0), System.ComponentModel.ListSortDirection.Ascending)


        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
            grilla_libro_compras.Columns(1).Width = 150
            grilla_libro_compras.Columns(2).Width = 136
            grilla_libro_compras.Columns(3).Width = 100
            grilla_libro_compras.Columns(4).Width = 100
            grilla_libro_compras.Columns(5).Width = 100
            grilla_libro_compras.Columns(6).Width = 100
            grilla_libro_compras.Columns(7).Width = 100
            grilla_libro_compras.Columns(8).Width = 100
            grilla_libro_compras.Columns(9).Width = 100
            grilla_libro_compras.Columns(10).Width = 100
            grilla_libro_compras.Columns(11).Width = 100
            grilla_libro_compras.Columns(12).Width = 100
            grilla_libro_compras.Columns(13).Width = 100
            grilla_libro_compras.Columns(14).Width = 100
            grilla_libro_compras.Columns(15).Width = 100
            grilla_libro_compras.Columns(16).Width = 100
            grilla_libro_compras.Columns(17).Width = 100
            grilla_libro_compras.Columns(18).Width = 100
            grilla_libro_compras.Columns(19).Width = 100
            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
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

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_libro_compras.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp_desde.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_libro_compras, save.FileName)
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True


    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_libro_compras.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_libro_compras.RowCount - 1
            For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_libro_compras.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_libro_compras.Columns.Clear()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_libro_compras.Columns.Clear()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        grilla_libro_compras.Columns.Clear()
        dtp_desde.Text = Date.Now
        dtp_hasta.Text = Date.Now
        dtp_ingresar.Text = Date.Now
    End Sub

    Private Sub combo_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_sucursal.SelectedIndexChanged
        grilla_libro_compras.Columns.Clear()
    End Sub
End Class