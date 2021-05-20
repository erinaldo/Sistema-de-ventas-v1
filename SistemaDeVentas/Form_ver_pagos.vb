
Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_ver_pagos



    Sub mostrar(ByVal i As Integer)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            'txt_rut.Text = DS.Tables(DT.TableName).Rows(i).Item("rut")
            txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
            txt_direccion.Text = DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente")
            txt_telefono.Text = DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente")
        End If
    End Sub

    Private Sub Form_ver_pagos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_agregar_abonos_sin_imputar.WindowState = FormWindowState.Normal
        Form_agregar_abonos_sin_imputar.Enabled = True
    End Sub

    Private Sub Form_ver_pagos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_ver_pagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llenar_combo_rut()
        mostrar_datos_clientes()
        mostrar_malla_pago()
        '  mostrar(0)
        cargar_logo()
        txt_rut.Focus()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
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
            txt_direccion.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                ' txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            End If
            conexion.Close()
        End If
    End Sub

    ' Sub que filtra lo que ingremos en el combo.
    'Sub mostrar_rut()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from clientes where rut like '" & (txt_rut.Text & "%") & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        combo_rut.Items.Clear()
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            combo_rut.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    'Sub llenar_combo_rut()
    '    DS2.Tables.Clear()
    '    DT2.Rows.Clear()
    '    DT2.Columns.Clear()
    '    DS2.Clear()
    '    conexion.Open()

    '    SC2.Connection = conexion
    '    SC2.CommandText = "select * from clientes"
    '    DA2.SelectCommand = SC2
    '    DA2.Fill(DT2)
    '    DS2.Tables.Add(DT2)

    '    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
    '            txt_rutcombo_rut.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("rut"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    'selecciona toda la informacion de la factura de credito donde rut sea = al digitado y el saldo sea mayor a 0.
    Sub actualizar_tabla_clientes()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from clientes"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    Sub mostrar_malla_pago()
        'DS2.Tables.Clear()
        'DT2.Rows.Clear()
        'DT2.Columns.Clear()
        'DS2.Clear()
        'conexion.Open()

        'SC2.Connection = conexion
        'SC2.CommandText = "select n_abono as 'NRO. DE ABONO', fecha AS 'FECHA DE ABONO', tipo_documento AS 'TIPO DE DOC.', nro_documento AS 'NRO. DE DOC.', fecha_documento AS 'FECHA DE DOC.', valor_documento 'VALOR DE DOC.', monto_abono 'MONTO DE ABONO', saldo AS SALDO from abono where rut_cliente = '" & (txt_rut.Text) & "'"
        'DA2.SelectCommand = SC2
        'DA2.Fill(DT2)
        'DS2.Tables.Add(DT2)

        'migrilla_ver_pago.DataSource = DS2.Tables(DT2.TableName)
        'conexion.Close()







        'DS1.Tables.Clear()
        'DT1.Rows.Clear()
        'DT1.Columns.Clear()
        'DS1.Clear()
        'conexion.Open()

        'SC1.Connection = conexion
        'SC1.CommandText = "select desde, hasta, factor, cantidad_a_rebajar from impuesto_unico"
        'DA1.SelectCommand = SC1
        'DA1.Fill(DT1)
        'DS1.Tables.Add(DT1)

        'grilla_detalle.DataSource = DS1.Tables(DT1.TableName)
        'conexion.Close()

        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        SC4.Connection = conexion
        SC4.CommandText = "select n_creditos as 'NRO. DE DOC', tipo_detalle AS 'DETALLE', fecha_venta AS 'FECHA VENTA', TOTAL AS 'TOTAL', SALDO 'SALDO' from CREDITOS where rut_cliente = '" & (txt_rut.Text) & "'"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)
        grilla_detalle.Rows.Clear()
        grilla_detalle.Columns.Clear()


        grilla_detalle.Columns.Add("n_creditos", "NRO. DE DOC")
        grilla_detalle.Columns.Add("DETALLE_DOC", "DETALLE")
        grilla_detalle.Columns.Add("fecha_venta", "FECHA VENTA")
        grilla_detalle.Columns.Add("TOTAL", "TOTAL")
        grilla_detalle.Columns.Add("SALDO", "SALDO")

        grilla_detalle.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        grilla_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        grilla_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        grilla_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
            For i = 0 To DS4.Tables(DT4.TableName).Rows.Count - 1
                grilla_detalle.Rows.Add(DS4.Tables(DT4.TableName).Rows(i).Item("NRO. DE DOC"), _
                                                     DS4.Tables(DT4.TableName).Rows(i).Item("DETALLE"), _
                                                          DS4.Tables(DT4.TableName).Rows(i).Item("FECHA VENTA"), _
                                                                DS4.Tables(DT4.TableName).Rows(i).Item("TOTAL"), _
                                                                    DS4.Tables(DT4.TableName).Rows(i).Item("SALDO"))
            Next
        End If
        conexion.Close()
    End Sub









    Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub



    Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


        mostrar_datos_clientes()
        mostrar_malla_pago()

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click

        Me.Close()

    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click

        'Dim mensaje As String = ""
        'If migrilla_ver_pago.Rows.Count = 0 Then mensaje = "GRILLA VACÍA" + Chr(13) & mensaje
        'If txt_rut.Text = "" Then mensaje = "CAMPO RUT VACÍO" + Chr(13) & mensaje

        'If mensaje <> "" Then
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        'Else

        '    Me.Enabled = False
        '    Dim Varpago As Integer
        '    Varpago = migrilla_ver_pago.CurrentRow.Cells(0).Value
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    ' SC.CommandText = "select * from abono where n_abono='" & (Varpago) & "'"
        '    SC.CommandText = "SELECT empresa.rut_empresa, empresa.nombre_empresa, empresa.direccion_empresa, empresa.telefono_empresa, empresa.giro_empresa, empresa.comuna_empresa, empresa.correo_empresa, `abono`.`n_abono`, `abono`.`rut`, `abono`.`nombre`, `abono`.`fecha`, `abono`.`n_factura`, `abono`.`valor_factura`, `abono`.`fecha_factura`, `abono`.`monto_abono`, `abono`.`saldo` FROM  abono, empresa where n_abono='" & (Varpago) & "'"

        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)

        '    '  MsgBox("Abono guardado con exito")
        '    '  Dim rpt As New Crystal_abono_copia_sistema

        '    'rpt.SetDataSource(DS.Tables(DT.TableName))
        '    'Form_informe_abono.rpt_abono.ReportSource = rpt
        '    Form_informe_abono.Show()
        '    conexion.Close()
        '    Me.Enabled = True
        'End If
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut.KeyPress

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_clientes()
            mostrar_malla_pago()
        End If
    End Sub



    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.GotFocus
        txt_rut.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub



    Sub crear_numero_abono()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "select sum(n_abono) as n_abono from CREDITOS where "
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)

        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        varnumabono = DS.Tables(DT.TableName).Rows(0).Item("n_abono")
        '        txt_n_abono.Text = varnumabono + 1
        '    End If
        'Catch err As InvalidCastException
        '    txt_n_abono.Text = 1
        'End Try
        'conexion.Close()
    End Sub















    Private Sub btn_anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_anular.Click
        Dim mensaje As String = ""
        Dim valormensaje As Integer
        If migrilla_ver_pago.Rows.Count = 0 Then mensaje = "GRILLA VACIA, SELECCIONE ALGUN ABONO" + Chr(13) & mensaje
        If txt_rut.Text = "" Then mensaje = "COMBO DOCUMENTOS VACIO, SELECCIONE UN CLIENTE" + Chr(13) & mensaje
        If txt_nombre_cliente.Text = "" Then mensaje = "CAMPO RUT VACIO, SELECCIONE UN CLIENTE" + Chr(13) & mensaje

        If mensaje <> "" Then
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        Else
            valormensaje = MsgBox("¿DESEA ANULAR ESTE ABONO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ANULAR")
            If valormensaje = vbYes Then
                'devolver_productos()
                'anulacion_documentos()


                Dim Varpago As Integer
                Dim detalle As Integer
                Varpago = migrilla_ver_pago.CurrentRow.Cells(0).Value
                detalle = migrilla_ver_pago.CurrentRow.Cells(0).Value


                If detalle <> "ABONO SIN IMPUTAR" Then
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    SC.Connection = conexion
                    SC.CommandText = "update creditos set total='" & (Varpago) & "' + saldo where tipo = 'FACTURA' and n_creditos ='" & (Varpago) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    conexion.Close()

                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    SC.Connection = conexion
                    SC.CommandText = "update creditos set estado='ANULADO', TOTAL='0', SALDO='0' where tipo = 'ABONO' and n_creditos ='" & (Varpago) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    conexion.Close()

                End If









            End If
        End If
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub


End Class