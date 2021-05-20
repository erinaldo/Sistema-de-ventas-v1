Imports System.IO
Imports System.Math
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Form_libro_de_ventas
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim numero_lineas_total As Integer = 0
    'Dim impreso As Integer = 0

    Private Sub Form_libro_de_ventas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '  form_Menu_admin.Enabled = True
        Form_menu_principal.WindowState = FormWindowState.Normal
        '  form_Menu_admin.txt_rut_cliente.Focus()
    End Sub

    Private Sub Form_libro_de_ventas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_libro_de_ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dtp_desde.CustomFormat = "yyy-MM-dd"
        'dtp_fin_mes.CustomFormat = "yyy-MM-dd"

        'Dim fecha As Date = Today.Date
        'lbl_fecha.Text = Format(dtp_venta.Text, "Long Date")
        'lbl_fecha.Text = UCase(lbl_fecha.Text)
        cargar_logo()
        limpiar()

        grilla_libro.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)

    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub limpiar()





        '  grilla_libro.Rows.Clear()
    End Sub

    Sub mostrar_malla()
        grilla_libro.Rows.Clear()

        'boletaS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select tipo, fecha_venta, n_boleta, condiciones,  nombre_cliente, boleta.rut_cliente, neto, iva, total, estado    from boleta, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and boleta.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by n_boleta order by n_boleta asc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        ' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Dim fecha_venta As String
            Dim condicion As String
            Dim estado As String
            Dim nombre_cliente As String
            Dim rut_cliente As String
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                condicion = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                If fecha_venta.Length > 10 Then
                    fecha_venta = fecha_venta.Substring(0, 10)
                End If
                If condicion <> "CREDITO" Then
                    condicion = "CONTADO"
                End If
                If estado = "ANULADA" Then
                    nombre_cliente = "DOCUMENTO ANULADO"
                    rut_cliente = "-"
                End If
                grilla_libro.Rows.Add("BOLETA", _
                                       fecha_venta, _
                                        DS.Tables(DT.TableName).Rows(i).Item("n_boleta"), _
                                         condicion, _
                                          nombre_cliente, _
                                           rut_cliente, _
                                            DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("total"))
            Next
        End If

        'FACTURAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select tipo, fecha_venta, n_factura, condiciones,  nombre_cliente, factura.rut_cliente, neto, iva, total, estado  from factura, clientes  where   fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  and factura.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by N_FACTURA order by N_FACTURA aSC"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Dim fecha_venta As String
            Dim condicion As String
            Dim estado As String
            Dim nombre_cliente As String
            Dim rut_cliente As String
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                condicion = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                If fecha_venta.Length > 10 Then
                    fecha_venta = fecha_venta.Substring(0, 10)
                End If
                If condicion <> "CREDITO" Then
                    condicion = "CONTADO"
                End If
                If estado = "ANULADA" Then
                    nombre_cliente = "DOCUMENTO ANULADO"
                    rut_cliente = "-"
                End If
                grilla_libro.Rows.Add("FACTURA", _
                                       fecha_venta, _
                                        DS.Tables(DT.TableName).Rows(i).Item("n_factura"), _
                                         condicion, _
                                          nombre_cliente, _
                                           rut_cliente, _
                                            DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("total"))
            Next
        End If

        'NOTAS DE CREDITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select tipo, fecha_venta, n_nota_credito, condiciones,  nombre_cliente, nota_credito.rut_cliente, neto, iva, total, estado    from nota_credito, clientes  where   fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  and nota_credito.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by N_nota_credito order by N_nota_credito aSC"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        'Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Dim fecha_venta As String
            Dim condicion As String
            Dim estado As String
            Dim nombre_cliente As String
            Dim rut_cliente As String
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                condicion = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                If fecha_venta.Length > 10 Then
                    fecha_venta = fecha_venta.Substring(0, 10)
                End If
                If condicion <> "CREDITO" Then
                    condicion = "CONTADO"
                End If
                If estado = "ANULADA" Then
                    nombre_cliente = "DOCUMENTO ANULADO"
                    rut_cliente = "-"
                End If
                grilla_libro.Rows.Add("NOTA DE CREDITO", _
                                       fecha_venta, _
                                        DS.Tables(DT.TableName).Rows(i).Item("n_nota_credito"), _
                                         condicion, _
                                          nombre_cliente, _
                                           rut_cliente, _
                                            DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("total"))
            Next
        End If

        'NOTAS DE DEBITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select tipo, fecha_venta, n_nota_debito, condiciones,  nombre_cliente, nota_debito.rut_cliente, neto, iva, total, estado from nota_debito, clientes  where  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  and nota_debito.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by n_nota_debito order by n_nota_debito aSC"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)


        ' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            Dim fecha_venta As String
            Dim condicion As String
            Dim estado As String
            Dim nombre_cliente As String
            Dim rut_cliente As String

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                condicion = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")

                If fecha_venta.Length > 10 Then
                    fecha_venta = fecha_venta.Substring(0, 10)
                End If

                If condicion <> "CREDITO" Then
                    condicion = "CONTADO"
                End If

                If estado = "ANULADA" Then
                    nombre_cliente = "DOCUMENTO ANULADO"
                    rut_cliente = "-"
                End If

                grilla_libro.Rows.Add("NOTA DE DEBITO", _
                                       fecha_venta, _
                                        DS.Tables(DT.TableName).Rows(i).Item("n_nota_debito"), _
                                         condicion, _
                                          nombre_cliente, _
                                           rut_cliente, _
                                            DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("total"))
            Next
        End If


        If grilla_libro.Rows.Count <> 0 Then
            If grilla_libro.Columns(0).Width = 90 Then
                grilla_libro.Columns(0).Width = 89
            Else
                grilla_libro.Columns(0).Width = 90
            End If
        End If
        grilla_libro.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_libro.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub





    'Sub mostrar_malla_mes()


    '    'Dim desde As String
    '    'Dim hasta As String

    '    'desde = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("01")
    '    'hasta = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("31")


    '    'SC2.CommandText = "select fecha_venta, n_factura, condiciones,  nombre_cliente, boleta.rut_cliente, neto, iva, total, estado    from factura, clientes  where   fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and factura.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by n_factura order by n_factura aSC"
    '    'SC2.CommandText = "select fecha_venta, n_boleta, condiciones,  nombre_cliente, boleta.rut_cliente, neto, iva, total, estado    from boleta, clientes  where   fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and boleta.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by N_boleta order by N_boleta aSC"


    '    grilla_estado_de_cuenta_mes.Rows.Clear()

    '    If combo_venta.Text = "FACTURAS" Then
    '        conexion.Close()
    '        DS2.Tables.Clear()
    '        DT2.Rows.Clear()
    '        DT2.Columns.Clear()
    '        DS2.Clear()
    '        SC2.Connection = conexion
    '        SC2.CommandText = "select fecha_venta, n_factura, condiciones,  nombre_cliente, factura.rut_cliente, neto, iva, total, estado  from factura, clientes  where MONTH (fecha_venta)='" & (dtp_venta.Value.Month()) & "' and factura.codigo_cliente=clientes.cod_cliente  AND tipo <> 'AJUSTE' GROUP by N_FACTURA order by N_FACTURA aSC"

    '        DA2.SelectCommand = SC2
    '        DA2.Fill(DT2)
    '        DS2.Tables.Add(DT2)


    '        'Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
    '        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then

    '            Dim fecha_venta As String
    '            Dim condicion As String
    '            Dim estado As String
    '            Dim nombre_cliente As String
    '            Dim rut_cliente As String

    '            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
    '                fecha_venta = DS2.Tables(DT2.TableName).Rows(i).Item("fecha_venta")
    '                condicion = DS2.Tables(DT2.TableName).Rows(i).Item("condiciones")
    '                estado = DS2.Tables(DT2.TableName).Rows(i).Item("estado")
    '                nombre_cliente = DS2.Tables(DT2.TableName).Rows(i).Item("nombre_cliente")
    '                rut_cliente = DS2.Tables(DT2.TableName).Rows(i).Item("rut_cliente")

    '                If fecha_venta.Length > 10 Then
    '                    fecha_venta = fecha_venta.Substring(0, 10)
    '                End If

    '                If condicion <> "CREDITO" Then
    '                    condicion = "CONTADO"
    '                End If

    '                If estado = "ANULADA" Then
    '                    nombre_cliente = "DOCUMENTO ANULADO"
    '                    rut_cliente = "-"
    '                End If

    '                grilla_estado_de_cuenta_mes.Rows.Add(fecha_venta, _
    '                                   DS2.Tables(DT2.TableName).Rows(i).Item("n_factura"), _
    '                                    condicion, _
    '                                     nombre_cliente, _
    '                                      rut_cliente, _
    '                                        DS2.Tables(DT2.TableName).Rows(i).Item("neto"), _
    '                                         DS2.Tables(DT2.TableName).Rows(i).Item("iva"), _
    '                                          DS2.Tables(DT2.TableName).Rows(i).Item("total"))
    '            Next
    '        End If


    '    Else

    '        conexion.Close()
    '        DS2.Tables.Clear()
    '        DT2.Rows.Clear()
    '        DT2.Columns.Clear()
    '        DS2.Clear()
    '        SC2.Connection = conexion
    '        SC2.CommandText = "select fecha_venta, n_boleta, condiciones,  nombre_cliente, boleta.rut_cliente, neto, iva, total, estado    from boleta, clientes  where MONTH (fecha_venta)='" & (dtp_venta.Value.Month()) & "' and boleta.codigo_cliente=clientes.cod_cliente  AND tipo <> 'AJUSTE' GROUP by N_boleta order by N_boleta aSC"

    '        DA2.SelectCommand = SC2
    '        DA2.Fill(DT2)
    '        DS2.Tables.Add(DT2)


    '        ' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
    '        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then

    '            Dim fecha_venta As String
    '            Dim condicion As String
    '            Dim estado As String
    '            Dim nombre_cliente As String
    '            Dim rut_cliente As String

    '            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
    '                fecha_venta = DS2.Tables(DT2.TableName).Rows(i).Item("fecha_venta")
    '                condicion = DS2.Tables(DT2.TableName).Rows(i).Item("condiciones")
    '                estado = DS2.Tables(DT2.TableName).Rows(i).Item("estado")
    '                nombre_cliente = DS2.Tables(DT2.TableName).Rows(i).Item("nombre_cliente")
    '                rut_cliente = DS2.Tables(DT2.TableName).Rows(i).Item("rut_cliente")

    '                If fecha_venta.Length > 10 Then
    '                    fecha_venta = fecha_venta.Substring(0, 10)
    '                End If

    '                If condicion <> "CREDITO" Then
    '                    condicion = "CONTADO"
    '                End If

    '                If estado = "ANULADA" Then
    '                    nombre_cliente = "DOCUMENTO ANULADO"
    '                    rut_cliente = "-"
    '                End If

    '                grilla_estado_de_cuenta_mes.Rows.Add(fecha_venta, _
    '                                   DS2.Tables(DT2.TableName).Rows(i).Item("n_boleta"), _
    '                                    condicion, _
    '                                     nombre_cliente, _
    '                                      rut_cliente, _
    '                                        DS2.Tables(DT2.TableName).Rows(i).Item("neto"), _
    '                                         DS2.Tables(DT2.TableName).Rows(i).Item("iva"), _
    '                                          DS2.Tables(DT2.TableName).Rows(i).Item("total"))
    '            Next
    '        End If

    '        grilla_estado_de_cuenta_mes.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        grilla_estado_de_cuenta_mes.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        grilla_estado_de_cuenta_mes.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        grilla_estado_de_cuenta_mes.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        grilla_estado_de_cuenta_mes.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    End If

    'End Sub

    Sub total_documentos()
        'txt_total_documentos.Text = grilla_libro.Rows.Count

        'conexion.Close()
        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'Try
        '    SC.Connection = conexion
        '    '   SC.CommandText = "select max(cod_auto) as cod_auto from factura where desglose <> 'MANUAL'"
        '    SC.CommandText = "select sum(total)  from factura  where month (fecha_venta)='" & (dtp_venta.Value.Month()) & "' and tipo <> 'ajuste' group by tipo order by n_factura asc"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        txt_total_documentos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        'txt_factura.Text = varnumdoc + 1
        '    End If
        'Catch err As InvalidCastException
        '    txt_total_documentos_mes.Text = 1
        '    Exit Sub
        'End Try
        'conexion.Close()

    End Sub


    Sub total_documentos_mes()
        '   txt_total_documentos_mes.Text = grilla_estado_de_cuenta_mes.Rows.Count




        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'Try
        '    SC.Connection = conexion
        '    '   SC.CommandText = "select max(cod_auto) as cod_auto from factura where desglose <> 'MANUAL'"
        '    SC.CommandText = "select sum(total) AS TOTAL from factura  where month (fecha_venta)='" & (dtp_venta.Value.Month()) & "' and tipo <> 'ajuste' group by tipo order by n_factura asc"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        txt_total_documentos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        'txt_factura.Text = varnumdoc + 1
        '    End If
        'Catch err As InvalidCastException
        '    txt_total_documentos_mes.Text = 1
        '    Exit Sub
        'End Try
        'conexion.Close()






    End Sub



    Sub total_documentos_mes_credito()

        'txt_total_documentos_credito_mes.Text = Val(txt_nulas_credito_mes.Text) + Val(txt_emitidas_credito_mes.Text)

    End Sub

    Sub total_documentos_mes_contado()

        'txt_total_documentos_contado_mes.Text = Val(txt_nulas_contado_mes.Text) + Val(txt_emitidas_contado_mes.Text)

    End Sub


    Sub total_documentos_nulos()


        ''//Calcular el total nulas
        'Dim NulasGrillas As String
        'txt_total_documentos_nulos.Text = 0
        'For i = 0 To grilla_libro.Rows.Count - 1
        '    NulasGrillas = grilla_libro.Rows(i).Cells(3).Value.ToString
        '    If NulasGrillas = "DOCUMENTO ANULADO" Then
        '        txt_total_documentos_nulos.Text = Val(txt_total_documentos_nulos.Text) + 1
        '    End If
        'Next

        ''conexion.Close()
        ''conexion.Close()
        ''DS.Tables.Clear()
        ''DT.Rows.Clear()
        ''DT.Columns.Clear()
        ''DS.Clear()
        ''conexion.Open()
        ''Try
        ''    SC.Connection = conexion
        ''    '   SC.CommandText = "select max(cod_auto) as cod_auto from factura where desglose <> 'MANUAL'"
        ''    SC.CommandText = "select count(condiciones) as condicion  from factura  where month (fecha_venta)='10' and tipo <> 'ajuste' AND condiciones='ANULADA'"
        ''    DA.SelectCommand = SC
        ''    DA.Fill(DT)
        ''    DS.Tables.Add(DT)
        ''    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        ''        txt_total_documentos_nulos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("condiciones")
        ''        'txt_factura.Text = varnumdoc + 1
        ''    End If
        ''Catch err As InvalidCastException
        ''    txt_total_documentos_nulos_mes.Text = 1
        ''    Exit Sub
        ''End Try
        ''conexion.Close()
    End Sub


    Sub total_documentos_nulos_mes()
        ' ''//Calcular el total nulas
        ''Dim NulasGrillas As String
        ''txt_total_documentos_nulos_mes.Text = 0
        ''For i = 0 To grilla_libro_mes.Rows.Count - 1
        ''    NulasGrillas = grilla_libro_mes.Rows(i).Cells(3).Value.ToString
        ''    If NulasGrillas = "DOCUMENTO ANULADO" Then
        ''        txt_total_documentos_nulos_mes.Text = Val(txt_total_documentos_nulos_mes.Text) + 1
        ''    End If
        ''Next

        'Dim desde As String
        'Dim hasta As String

        'desde = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("01")
        'hasta = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("31")


        ''SC2.CommandText = "select fecha_venta, n_factura, condiciones,  nombre_cliente, boleta.rut_cliente, neto, iva, total, estado    from factura, clientes  where   fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and factura.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by n_factura order by n_factura aSC"
        ''SC2.CommandText = "select fecha_venta, n_boleta, condiciones,  nombre_cliente, boleta.rut_cliente, neto, iva, total, estado    from boleta, clientes  where   fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and boleta.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by N_boleta order by N_boleta aSC"




        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "select count(n_boleta) as n_boleta from boleta where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' AND ESTADO='ANULADA'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        txt_total_documentos_nulos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
        '        'txt_factura.Text = varnumdoc + 1
        '    End If
        'Catch err As InvalidCastException
        '    txt_total_documentos_nulos_mes.Text = 0
        '    Exit Sub
        'End Try
        'conexion.Close()



        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "select count(n_factura) as n_factura from factura where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' AND ESTADO='ANULADA'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        txt_total_documentos_nulos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
        '        'txt_factura.Text = varnumdoc + 1
        '    End If
        'Catch err As InvalidCastException
        '    txt_total_documentos_nulos_mes.Text = 0
        '    Exit Sub
        'End Try
        'conexion.Close()




        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "select count(n_nota_credito) as n_nota_credito from nota_credito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' AND ESTADO='ANULADA'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        txt_total_documentos_nulos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_credito")
        '        'txt_factura.Text = varnumdoc + 1
        '    End If
        'Catch err As InvalidCastException
        '    txt_total_documentos_nulos_mes.Text = 0
        '    Exit Sub
        'End Try
        'conexion.Close()
        'End If


        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "select count(n_nota_debito) as n_nota_debito from nota_debito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' AND ESTADO='ANULADA'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        txt_total_documentos_nulos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_debito")
        '        'txt_factura.Text = varnumdoc + 1
        '    End If
        'Catch err As InvalidCastException
        '    txt_total_documentos_nulos_mes.Text = 0
        '    Exit Sub
        'End Try
        'conexion.Close()
        'End If
    End Sub

    Sub total_documentos_nulos_mes_credito()


        'Dim desde As String
        'Dim hasta As String

        'desde = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("01")
        'hasta = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("31")


        'If combo_venta.Text = "boletaS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_boleta) as n_boleta from boleta where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones = 'CREDITO' AND ESTADO='ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_nulas_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_nulas_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If


        'If combo_venta.Text = "FACTURAS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_factura) as n_factura from factura where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones = 'CREDITO' AND ESTADO='ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_nulas_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_nulas_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "NOTAS DE CREDITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_nota_credito) as n_nota_credito from nota_credito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones = 'CREDITO' AND ESTADO='ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_nulas_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_credito")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_nulas_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "NOTAS DE DEBITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_nota_debito) as n_nota_debito from nota_debito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones = 'CREDITO' AND ESTADO='ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_nulas_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_debito")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_nulas_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If
    End Sub


    Sub total_documentos_nulos_mes_contado()


        'Dim desde As String
        'Dim hasta As String

        'desde = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("01")
        'hasta = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("31")


        'If combo_venta.Text = "boletaS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_boleta) as n_boleta from boleta where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones <> 'CREDITO' AND ESTADO='ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_nulas_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_nulas_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If


        'If combo_venta.Text = "FACTURAS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_factura) as n_factura from factura where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones <> 'CREDITO' AND ESTADO='ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_nulas_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_nulas_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "NOTAS DE CREDITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_nota_credito) as n_nota_credito from nota_credito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones <> 'CREDITO' AND ESTADO='ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_nulas_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_credito")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_nulas_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "NOTAS DE DEBITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_nota_debito) as n_nota_debito from nota_debito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones <> 'CREDITO' AND ESTADO='ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_nulas_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_debito")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_nulas_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If
    End Sub


    Sub total_documentos_emitidos()
        ''//Calcular el total emitidos
        'Dim EmitidosGrillas As String
        'txt_total_documentos_emitidos.Text = 0
        'For i = 0 To grilla_libro.Rows.Count - 1
        '    EmitidosGrillas = grilla_libro.Rows(i).Cells(3).Value.ToString
        '    If EmitidosGrillas <> "DOCUMENTO ANULADO" Then
        '        txt_total_documentos_emitidos.Text = Val(txt_total_documentos_emitidos.Text) + 1
        '    End If
        'Next





    End Sub

    Sub total_documentos_emitidos_mes()
        ' ''//Calcular el total emitidos
        ''Dim EmitidosGrillas As String
        ''txt_total_documentos_emitidos_mes.Text = 0
        ''For i = 0 To grilla_libro_mes.Rows.Count - 1
        ''    EmitidosGrillas = grilla_libro_mes.Rows(i).Cells(3).Value.ToString
        ''    If EmitidosGrillas <> "DOCUMENTO ANULADO" Then
        ''        txt_total_documentos_emitidos_mes.Text = Val(txt_total_documentos_emitidos_mes.Text) + 1
        ''    End If
        ''Next
        ' ''  MsgBox("")


        'Dim desde As String
        'Dim hasta As String

        'desde = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("01")
        'hasta = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("31")


        ''SC2.CommandText = "select fecha_venta, n_factura, condiciones,  nombre_cliente, boleta.rut_cliente, neto, iva, total, estado    from factura, clientes  where   fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and factura.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by n_factura order by n_factura aSC"
        ''SC2.CommandText = "select fecha_venta, n_boleta, condiciones,  nombre_cliente, boleta.rut_cliente, neto, iva, total, estado    from boleta, clientes  where   fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and boleta.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by N_boleta order by N_boleta aSC"



        'If combo_venta.Text = "boletaS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_boleta) as n_boleta from boleta where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE'  and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_documentos_emitidos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
        '            'txt_factura.Text = varnumdoc + 1
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_documentos_emitidos_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "FACTURAS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_factura) as n_factura from factura where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_documentos_emitidos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
        '            'txt_factura.Text = varnumdoc + 1
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_documentos_emitidos_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If


        'If combo_venta.Text = "NOTAS DE CREDITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_nota_credito) as n_nota_credito from nota_credito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_documentos_emitidos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_credito")
        '            'txt_factura.Text = varnumdoc + 1
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_documentos_emitidos_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "NOTAS DE DEBITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_nota_debito) as n_nota_debito from nota_debito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_documentos_emitidos_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_debito")
        '            'txt_factura.Text = varnumdoc + 1
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_documentos_emitidos_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If
    End Sub

    Sub total_documentos_emitidos_mes_credito()

        'Dim desde As String
        'Dim hasta As String

        'desde = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("01")
        'hasta = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("31")

        'If combo_venta.Text = "boletaS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_boleta) as n_boleta from boleta where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones = 'CREDITO' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_emitidas_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_emitidas_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "FACTURAS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_factura) as n_factura from factura where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones = 'CREDITO' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_emitidas_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_emitidas_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "NOTAS DE CREDITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_nota_credito) as n_nota_credito from nota_credito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones = 'CREDITO' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_emitidas_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_credito")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_emitidas_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "NOTAS DE DEBITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_nota_debito) as n_nota_debito from nota_debito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones = 'CREDITO' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_emitidas_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_debito")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_emitidas_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If
    End Sub


    Sub total_documentos_emitidos_mes_contado()

        'Dim desde As String
        'Dim hasta As String

        'desde = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("01")
        'hasta = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("31")

        'If combo_venta.Text = "boletaS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_boleta) as n_boleta from boleta where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones <> 'CREDITO' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_emitidas_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_emitidas_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "FACTURAS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_factura) as n_factura from factura where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones <> 'CREDITO' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_emitidas_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_emitidas_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If


        'If combo_venta.Text = "NOTAS DE CREDITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_nota_credito) as n_nota_credito from nota_credito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones <> 'CREDITO' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_emitidas_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_credito")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_emitidas_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "NOTAS DE DEBITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select count(n_nota_debito) as n_nota_debito from nota_debito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and condiciones <> 'CREDITO' and ESTADO <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_emitidas_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_debito")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_emitidas_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If
    End Sub



    Sub total_dinero_mes()
        ' ''//Calcular el total emitidos
        ''Dim EmitidosGrillas As String
        ''txt_total_documentos_emitidos_mes.Text = 0
        ''For i = 0 To grilla_libro_mes.Rows.Count - 1
        ''    EmitidosGrillas = grilla_libro_mes.Rows(i).Cells(3).Value.ToString
        ''    If EmitidosGrillas <> "DOCUMENTO ANULADO" Then
        ''        txt_total_documentos_emitidos_mes.Text = Val(txt_total_documentos_emitidos_mes.Text) + 1
        ''    End If
        ''Next
        ' ''  MsgBox("")


        'Dim desde As String
        'Dim hasta As String

        'desde = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("01")
        'hasta = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("31")


        ''SC2.CommandText = "select fecha_venta, n_factura, condiciones,  nombre_cliente, boleta.rut_cliente, neto, iva, total, estado    from factura, clientes  where   fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and factura.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by n_factura order by n_factura aSC"
        ''SC2.CommandText = "select fecha_venta, n_boleta, condiciones,  nombre_cliente, boleta.rut_cliente, neto, iva, total, estado    from boleta, clientes  where   fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and boleta.rut_cliente=clientes.rut_cliente  AND tipo <> 'AJUSTE' GROUP by N_boleta order by N_boleta aSC"



        'If combo_venta.Text = "boletaS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from boleta where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '            'txt_factura.Text = varnumdoc + 1
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'If combo_venta.Text = "FACTURAS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from factura where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '            'txt_factura.Text = varnumdoc + 1
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If


        'If combo_venta.Text = "NOTAS DE CREDITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '            'txt_factura.Text = varnumdoc + 1
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If


        'If combo_venta.Text = "NOTAS DE DEBITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '            'txt_factura.Text = varnumdoc + 1
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If




        'Dim iva_valor As String





        'iva_valor = 0

        'iva_valor = valor_iva / 100 + 1

        'Me.txt_neto_mes.Text = Round(txt_total_mes.Text / iva_valor)

        'Me.txt_iva_mes.Text = (((txt_neto_mes.Text) * valor_iva) / 100)

        'Me.txt_iva_mes.Text = (txt_total_mes.Text) - (txt_neto_mes.Text)







        ''If txt_neto.Text = "" Or txt_neto.Text = "0" Then
        ''    txt_neto_millar.Text = "0"
        ''Else
        ''    txt_neto_millar.Text = Format(Int(txt_neto.Text), "###,###,###")
        ''End If


        ''If txt_iva.Text = "" Or txt_iva.Text = "0" Then
        ''    txt_iva_millar.Text = "0"
        ''Else
        ''    txt_iva_millar.Text = Format(Int(txt_iva.Text), "###,###,###")
        ''End If


        ''If txt_total.Text = "" Or txt_total.Text = "0" Then
        ''    txt_total_millar.Text = "0"
        ''Else
        ''    txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        ''End If

    End Sub




    Sub total_dinero_mes_credito()

        'Dim desde As String
        'Dim hasta As String

        'desde = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("01")
        'hasta = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("31")

        'If combo_venta.Text = "boletaS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from boleta where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA' and condiciones = 'CREDITO'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If



        'If combo_venta.Text = "FACTURAS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from factura where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA' and condiciones = 'CREDITO'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If


        'If combo_venta.Text = "NOTAS DE CREDITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA' and condiciones = 'CREDITO'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If


        'If combo_venta.Text = "NOTAS DE DEBITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA' and condiciones = 'CREDITO'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_credito_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_credito_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If
        'Dim iva_valor As String

        'iva_valor = 0
        'iva_valor = valor_iva / 100 + 1

        'Me.txt_neto_credito_mes.Text = Round(txt_total_credito_mes.Text / iva_valor)
        'Me.txt_iva_credito_mes.Text = (((txt_neto_credito_mes.Text) * valor_iva) / 100)
        'Me.txt_iva_credito_mes.Text = (txt_total_credito_mes.Text) - (txt_neto_credito_mes.Text)

    End Sub



    Sub total_dinero_mes_contado()

        'Dim desde As String
        'Dim hasta As String

        'desde = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("01")
        'hasta = (dtp_venta.Value.Year) & "-" & (dtp_venta.Value.Month) & "-" & ("31")

        'If combo_venta.Text = "boletaS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from boleta where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA' and condiciones <> 'CREDITO'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If



        'If combo_venta.Text = "FACTURAS" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from factura where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA' and condiciones <> 'CREDITO'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If



        'If combo_venta.Text = "NOTAS DE CREDITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA' and condiciones <> 'CREDITO'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If


        'If combo_venta.Text = "NOTAS DE DEBITO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta >='" & (desde) & "' and fecha_venta <='" & (hasta) & "' and tipo <> 'AJUSTE' and estado <> 'ANULADA' and condiciones <> 'CREDITO'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_total_contado_mes.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_total_contado_mes.Text = 0
        '        Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'Dim iva_valor As String

        'iva_valor = 0
        'iva_valor = valor_iva / 100 + 1

        'Me.txt_neto_contado_mes.Text = Round(txt_total_contado_mes.Text / iva_valor)
        'Me.txt_iva_contado_mes.Text = (((txt_neto_contado_mes.Text) * valor_iva) / 100)
        'Me.txt_iva_contado_mes.Text = (txt_total_contado_mes.Text) - (txt_neto_contado_mes.Text)

    End Sub




    Sub calcular_totales()
        'Dim netogrilla As Long
        'Dim ivagrilla As Long
        'Dim totalgrilla As Long

        ''//Calcular el total neto
        'txt_neto.Text = 0
        'For i = 0 To grilla_libro.Rows.Count - 1
        '    netogrilla = Val(grilla_libro.Rows(i).Cells(6).Value.ToString)
        '    txt_neto.Text = Val(txt_neto.Text) + Val(netogrilla)
        'Next


        ''//Calcular el total iva
        'txt_iva.Text = 0
        'For i = 0 To grilla_libro.Rows.Count - 1
        '    ivagrilla = Val(grilla_libro.Rows(i).Cells(7).Value.ToString)
        '    txt_iva.Text = Val(txt_iva.Text) + Val(ivagrilla)
        'Next


        ''//Calcular el total general
        'txt_total.Text = 0
        'For i = 0 To grilla_libro.Rows.Count - 1
        '    totalgrilla = Val(grilla_libro.Rows(i).Cells(8).Value.ToString)
        '    txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        'Next






        'Dim iva_valor As String





        ''iva_valor = valor_iva / 100 + 1

        ''txt_neto.Text = (txt_total.Text) / (iva_valor)

        ''txt_iva.Text = Round((txt_neto.Text) * valor_iva / 100)

        ''txt_neto.Text = Int(txt_total.Text) - (txt_iva.Text)




        ''Dim netogrillames As Long
        ''Dim ivagrillames As Long
        ''Dim totalgrillames As Long

        ' ''//Calcular el total neto mes
        ''txt_neto_mes.Text = 0
        ''For i = 0 To grilla_libro_mes.Rows.Count - 1
        ''    netogrillames = Val(grilla_libro_mes.Rows(i).Cells(5).Value.ToString)
        ''    txt_neto_mes.Text = Val(txt_neto_mes.Text) + Val(netogrillames)
        ''Next


        ' ''//Calcular el total iva mes
        ''txt_iva_mes.Text = 0
        ''For i = 0 To grilla_libro_mes.Rows.Count - 1
        ''    ivagrillames = Val(grilla_libro_mes.Rows(i).Cells(6).Value.ToString)
        ''    txt_iva_mes.Text = Val(txt_iva_mes.Text) + Val(ivagrillames)
        ''Next


        ' ''//Calcular el total general mes
        ''txt_total_mes.Text = 0
        ''For i = 0 To grilla_libro_mes.Rows.Count - 1
        ''    totalgrillames = Val(grilla_libro_mes.Rows(i).Cells(7).Value.ToString)
        ''    txt_total_mes.Text = Val(txt_total_mes.Text) + Val(totalgrillames)
        ''Next

        '' Dim iva_valor As String






        ''iva_valor = valor_iva / 100 + 1

        ''txt_neto_mes.Text = (txt_total_mes.Text) / (iva_valor)

        ''txt_iva_mes.Text = Round((txt_neto_mes.Text) * valor_iva / 100)

        ''txt_neto_mes.Text = Int(txt_total_mes.Text) - (txt_iva_mes.Text)



        'iva_valor = 0

        'iva_valor = valor_iva / 100 + 1

        'Me.txt_neto.Text = Round(txt_total.Text / iva_valor)

        'Me.txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)

        'Me.txt_iva.Text = (txt_total.Text) - (txt_neto.Text)














        'If txt_neto.Text = "" Or txt_neto.Text = "0" Then
        '    txt_neto_millar.Text = "0"
        'Else
        '    txt_neto_millar.Text = Format(Int(txt_neto.Text), "###,###,###")
        'End If


        'If txt_iva.Text = "" Or txt_iva.Text = "0" Then
        '    txt_iva_millar.Text = "0"
        'Else
        '    txt_iva_millar.Text = Format(Int(txt_iva.Text), "###,###,###")
        'End If


        'If txt_total.Text = "" Or txt_total.Text = "0" Then
        '    txt_total_millar.Text = "0"
        'Else
        '    txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        'End If


    End Sub

    ' se graba el estado de cuenta mediante un ciclo for en una tabla temporal.
    Sub grabar_libro_ventas()
        'Dim VarFecha As String
        'Dim VarNumero As String
        'Dim VarCondicion As String
        'Dim VarNombre As String
        'Dim VarRut As String
        'Dim VarNeto As String
        'Dim VarIva As String
        'Dim VarTotal As String
        'Dim titulo As String

        'SC.Connection = conexion
        'SC.CommandText = "delete from libro_de_ventas"
        'DA.SelectCommand = SC
        'DA.Fill(DT)

        'For i = 0 To grilla_libro.Rows.Count - 1
        '    VarFecha = grilla_libro.Rows(i).Cells(0).Value.ToString
        '    VarNumero = grilla_libro.Rows(i).Cells(1).Value.ToString
        '    VarCondicion = grilla_libro.Rows(i).Cells(2).Value.ToString
        '    VarNombre = grilla_libro.Rows(i).Cells(3).Value.ToString
        '    VarRut = grilla_libro.Rows(i).Cells(4).Value.ToString
        '    VarNeto = grilla_libro.Rows(i).Cells(5).Value.ToString
        '    VarIva = grilla_libro.Rows(i).Cells(6).Value.ToString
        '    VarTotal = grilla_libro.Rows(i).Cells(7).Value.ToString

        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion

        '    Dim fecha As Date = Today.Date
        '    lbl_fecha.Text = Format(dtp_venta.Text, "Long Date")
        '    lbl_fecha.Text = UCase(lbl_fecha.Text)

        '    'If dtp_venta.Text = dtp_fin_mes.Text Then
        '    '    titulo = "LIBRO MENSUAL DE " & combo_venta.Text & " DE VENTAS " & "(" & mirecintoempresa & ")"
        '    'Else
        '    '    titulo = "LIBRO DIARIO DE " & combo_venta.Text & " DE VENTAS " & "(" & mirecintoempresa & ")"
        '    'End If

        '    titulo = "LIBRO DIARIO DE VENTAS " & "(" & mirecintoempresa & ")"

        '    SC.CommandText = "insert into libro_de_ventas (fecha, numero_documento, condicion, nombre_cliente,rut_cliente, neto, iva, total, tipo_documento, fecha_libro, total_nulas, total_emitidas, total_documentos, total_neto, total_iva, total_venta, recinto, total_neto_mes, total_iva_mes, total_venta_mes, total_nulas_mes, total_emitidas_mes, total_documentos_mes, total_nulas_credito, total_emitidas_credito, total_documentos_credito, neto_credito,  iva_credito,  total_credito, total_nulas_contado, total_emitidas_contado, total_documentos_contado, neto_contado,  iva_contado,  total_contado) values('" & (VarFecha) & "','" & (VarNumero) & "','" & (VarCondicion) & "','" & (VarNombre) & "','" & (VarRut) & "','" & (VarNeto) & "','" & (VarIva) & "','" & (VarTotal) & "','" & (titulo) & "','" & (lbl_fecha.Text) & "','" & (txt_total_documentos_nulos.Text) & "','" & (txt_total_documentos_emitidos.Text) & "','" & (txt_total_documentos.Text) & "','" & (txt_neto.Text) & "','" & (txt_iva.Text) & "','" & (txt_total.Text) & "','" & (mirecintoempresa) & "','" & (txt_neto_mes.Text) & "','" & (txt_iva_mes.Text) & "','" & (txt_total_mes.Text) & "','" & (txt_total_documentos_nulos_mes.Text) & "','" & (txt_total_documentos_emitidos_mes.Text) & "' ,'" & (txt_total_documentos_mes.Text) & "' ,'" & (txt_nulas_credito_mes.Text) & "','" & (txt_emitidas_credito_mes.Text) & "','" & (txt_total_documentos_credito_mes.Text) & "','" & (txt_neto_credito_mes.Text) & "','" & (txt_iva_credito_mes.Text) & "','" & (txt_total_credito_mes.Text) & "'                ,'" & (txt_nulas_contado_mes.Text) & "','" & (txt_emitidas_contado_mes.Text) & "','" & (txt_total_documentos_contado_mes.Text) & "','" & (txt_neto_contado_mes.Text) & "','" & (txt_iva_contado_mes.Text) & "','" & (txt_total_contado_mes.Text) & "' )"

        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    conexion.Close()
        'Next


    End Sub


    Private Sub combo_venta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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


    Private Sub combo_venta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        limpiar()
        fecha()

        If grilla_libro.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            dtp_desde.Focus()
            Exit Sub
        End If
        'If combo_venta.Text = "" Then
        '    MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    combo_venta.Focus()
        '    Exit Sub
        'End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = False
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If
        'Try
        '    Dim iReporte As New form_informe_estado_de_cuenta_personalizado
        '    Dim rpt As New Crystal_libro_de_ventas

        '    form_informe_estado_de_cuenta_personalizado.Text = "LIBRO DE VENTAS"
        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()

        '    iReporte.Reporte = rpt
        '    iReporte.ShowDialog()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        lbl_mensaje.Visible = False
        Me.Enabled = True
        'lbl_mensaje.Visible = True
        'Me.Enabled = False
        'grabar_libro_ventas()
        'imprimir_libro_ventas_diario()
        'combo_venta.Text = ""
        'lbl_mensaje.Visible = False
        'Me.Enabled = True
    End Sub


    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    dt.Columns.Add(New DataColumn("logo_empresa", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fechas", GetType(String)))
    '    dt.Columns.Add(New DataColumn("titulo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn0", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn1", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn2", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn3", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn4", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn5", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn6", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn7", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn8", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn9", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn10", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn11", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn12", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn13", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn14", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn15", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn16", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn17", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn18", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn19", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn20", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn21", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn22", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn23", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn24", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn25", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn26", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn27", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn28", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn29", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn30", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn31", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn32", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn33", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn34", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn35", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn36", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn37", GetType(String)))

    '    'Dim DataColumn0 As String
    '    Dim DataColumn1 As String
    '    Dim DataColumn2 As String
    '    Dim DataColumn3 As String
    '    Dim DataColumn4 As String
    '    Dim DataColumn5 As String
    '    Dim DataColumn6 As String
    '    Dim DataColumn7 As String
    '    Dim DataColumn8 As String
    '    'Dim DataColumn9 As String
    '    'Dim DataColumn10 As String
    '    'Dim DataColumn11 As String
    '    'Dim DataColumn12 As String
    '    'Dim DataColumn13 As String
    '    'Dim DataColumn14 As String
    '    'Dim DataColumn15 As String
    '    'Dim DataColumn16 As String
    '    'Dim DataColumn17 As String
    '    'Dim DataColumn18 As String
    '    'Dim DataColumn19 As String
    '    'Dim DataColumn20 As String
    '    'Dim DataColumn21 As String
    '    'Dim DataColumn22 As String
    '    'Dim DataColumn23 As String
    '    'Dim DataColumn24 As String
    '    'Dim DataColumn25 As String
    '    'Dim DataColumn26 As String
    '    'Dim DataColumn27 As String
    '    'Dim DataColumn28 As String
    '    Dim DataColumn29 As String
    '    'Dim DataColumn30 As String

    '    For i = 0 To grilla_libro.Rows.Count - 1
    '        DataColumn29 = grilla_libro.Rows(i).Cells(0).Value.ToString
    '        DataColumn1 = grilla_libro.Rows(i).Cells(1).Value.ToString
    '        DataColumn2 = grilla_libro.Rows(i).Cells(2).Value.ToString
    '        DataColumn3 = grilla_libro.Rows(i).Cells(3).Value.ToString
    '        DataColumn4 = grilla_libro.Rows(i).Cells(4).Value.ToString
    '        DataColumn5 = grilla_libro.Rows(i).Cells(5).Value.ToString
    '        DataColumn6 = grilla_libro.Rows(i).Cells(6).Value.ToString
    '        DataColumn7 = grilla_libro.Rows(i).Cells(7).Value.ToString
    '        DataColumn8 = grilla_libro.Rows(i).Cells(8).Value.ToString
    '        'DataColumn8 = grilla_libro.Rows(i).Cells(8).Value.ToString


    '        dr = dt.NewRow()

    '        'Try
    '        '    dr("logo_empresa") = Imagen_reporte
    '        'Catch
    '        'End Try

    '        dr("nombre_empresa") = minombreempresa
    '        dr("giro_empresa") = migiroempresa
    '        dr("direccion_empresa") = midireccionempresa
    '        dr("comuna_empresa") = micomunaempresa
    '        dr("telefono_empresa") = mitelefonoempresa
    '        dr("correo_empresa") = micorreoempresa
    '        dr("rut_empresa") = mirutempresa


    '        Try
    '            dr("DataColumn29") = DataColumn29
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn1") = DataColumn1
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn2") = DataColumn2
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn3") = DataColumn3
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn4") = DataColumn4
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn5") = DataColumn5
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn6") = DataColumn6
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn7") = DataColumn7
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn8") = DataColumn8
    '        Catch
    '        End Try




    '        Try
    '            dr("DataColumn9") = grilla_estado_de_cuenta.Rows(0).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn10") = grilla_estado_de_cuenta.Rows(0).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn11") = grilla_estado_de_cuenta.Rows(0).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn12") = grilla_estado_de_cuenta.Rows(0).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn13") = grilla_estado_de_cuenta.Rows(0).Cells(5).Value
    '        Catch
    '        End Try


    '        Try
    '            dr("DataColumn14") = grilla_estado_de_cuenta.Rows(1).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn15") = grilla_estado_de_cuenta.Rows(1).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn16") = grilla_estado_de_cuenta.Rows(1).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn17") = grilla_estado_de_cuenta.Rows(1).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn18") = grilla_estado_de_cuenta.Rows(1).Cells(5).Value
    '        Catch
    '        End Try



    '        Try
    '            dr("DataColumn19") = grilla_estado_de_cuenta.Rows(2).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn20") = grilla_estado_de_cuenta.Rows(2).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn21") = grilla_estado_de_cuenta.Rows(2).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn22") = grilla_estado_de_cuenta.Rows(2).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn23") = grilla_estado_de_cuenta.Rows(2).Cells(5).Value
    '        Catch
    '        End Try


    '        Try
    '            dr("DataColumn24") = grilla_estado_de_cuenta.Rows(3).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn25") = grilla_estado_de_cuenta.Rows(3).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn26") = grilla_estado_de_cuenta.Rows(3).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn27") = grilla_estado_de_cuenta.Rows(3).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn28") = grilla_estado_de_cuenta.Rows(3).Cells(5).Value
    '        Catch
    '        End Try


    '        dr("fechas") = "DESDE " & dtp_desde.Text & " HASTA " & dtp_hasta.Text

    '        dr("titulo") = "LIBRO DE VENTAS(" & mirecintoempresa & ")"

    '        dt.Rows.Add(dr)
    '    Next

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "DS_reporte"

    '    Dim iDS As New DS_reporte
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function

    'Sub imprimir_libro_ventas_mensual()

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion

    '    SC.CommandText = " select * FROM `libro_de_ventas`"

    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    Dim rpt As New Crystal_libro_de_ventas_mensual_credito_contado

    '    rpt.SetDataSource(DS.Tables(DT.TableName))
    '    Form_informe_estado_de_cuenta.rpt_estado_de_cuenta.ReportSource = rpt
    '    Form_informe_estado_de_cuenta.Show()
    '    conexion.Close()

    '    SC.Connection = conexion
    '    SC.CommandText = "delete from libro_de_ventas"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    'End Sub









    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub dtp_venta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged

        grilla_libro.Rows.Clear()
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        '     grilla_libro.Rows.Clear()
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_libro.Rows.Clear()
            grilla_estado_de_cuenta.Rows.Clear()
            limpiar()

            'txt_total_documentos_nulos.Text = "0"
            'txt_total_documentos_emitidos.Text = "0"
            'txt_total_documentos.Text = "0"
            'txt_neto_millar.Text = "0"
            'txt_iva_millar.Text = "0"
            'txt_total_millar.Text = "0"

        End If
    End Sub

    Private Sub Timer_inactividad_libro_ventas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_inactividad_libro_ventas.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
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


    Private Sub panel_esc_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
        'mostrar_malla()
        'calcular_totales()
    End Sub

    Private Sub combo_venta_TextUpdate(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_libro.Rows.Count = 0 Then
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
            Exportar_Excel(Me.grilla_libro, save.FileName)
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
        For c As Integer = 0 To grilla_libro.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_libro.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_libro.RowCount - 1
            For c As Integer = 0 To grilla_libro.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_libro.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub





    'Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    combo_venta.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub combo_venta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    combo_venta.BackColor = Color.White
    '    ' Combo_condicion.Text = ActiveControl.Name
    'End Sub

    'Private Sub Combo_condicion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_condicion.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub Combo_condicion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_condicion.BackColor = Color.White
    'End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_grabar_mes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_grabar_mes.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_grabar_mes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_grabar_mes.BackColor = Color.Transparent
    'End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Sub malla_resumen()
        Dim valor As String

        grilla_estado_de_cuenta.Rows.Clear()
        grilla_estado_de_cuenta.Rows.Add("CANTIDAD", "0", "0", "0", "0")
        grilla_estado_de_cuenta.Rows.Add("NETO", "0", "0", "0", "0")
        grilla_estado_de_cuenta.Rows.Add("IVA", "0", "0", "0", "0")
        grilla_estado_de_cuenta.Rows.Add("TOTAL", "0", "0", "0", "0")

        'CANTIDAD boletaS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `boleta` WHERE fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  AND tipo <> 'AJUSTE' "
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Try
                    valor = DS.Tables(DT.TableName).Rows(0).Item("valor")
                Catch
                    valor = "0"
                End Try

                'If valor = "" Or valor = "0" Then
                '    valor = "0"
                'Else
                '    valor = Format(Int(valor), "###,###,###")
                'End If

                grilla_estado_de_cuenta.Rows(0).Cells(1).Value = valor
            Next
        End If

        'CANTIDAD FACTURAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `factura` WHERE fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo <> 'AJUSTE' "
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Try
                    valor = DS.Tables(DT.TableName).Rows(0).Item("valor")
                Catch
                    valor = "0"
                End Try

                'If valor = "" Or valor = "0" Then
                '    valor = "0"
                'Else
                '    valor = Format(Int(valor), "###,###,###")
                'End If

                grilla_estado_de_cuenta.Rows(0).Cells(2).Value = valor
            Next
        End If

        'CANTIDAD NOTAS DE CREDITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `nota_credito` WHERE fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  AND tipo <> 'AJUSTE'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Try
                    valor = DS.Tables(DT.TableName).Rows(0).Item("valor")
                Catch
                    valor = "0"
                End Try

                'If valor = "" Or valor = "0" Then
                '    valor = "0"
                'Else
                '    valor = Format(Int(valor), "###,###,###")
                'End If

                grilla_estado_de_cuenta.Rows(0).Cells(3).Value = valor
            Next
        End If

        'CANTIDAD NOTAS DE DEBITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `nota_debito` WHERE fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo <> 'AJUSTE'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Try
                    valor = DS.Tables(DT.TableName).Rows(0).Item("valor")
                Catch
                    valor = "0"
                End Try

                'If valor = "" Or valor = "0" Then
                '    valor = "0"
                'Else
                '    valor = Format(Int(valor), "###,###,###")
                'End If

                grilla_estado_de_cuenta.Rows(0).Cells(4).Value = valor
            Next
        End If

        'CANTIDAD DOCUMENTOS
        Try
            grilla_estado_de_cuenta.Rows(0).Cells(5).Value = Val(grilla_estado_de_cuenta.Rows(0).Cells(1).Value) + Val(grilla_estado_de_cuenta.Rows(0).Cells(2).Value) + Val(grilla_estado_de_cuenta.Rows(0).Cells(3).Value) + Val(grilla_estado_de_cuenta.Rows(0).Cells(4).Value)



        Catch
        End Try

        'TOTALES
        'TOTAL boletaS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `boleta` WHERE fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo <> 'AJUSTE'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Try
                    valor = DS.Tables(DT.TableName).Rows(0).Item("valor")
                Catch
                    valor = "0"
                End Try

                'If valor = "" Or valor = "0" Then
                '    valor = "0"
                'Else
                '    valor = Format(Int(valor), "###,###,###")
                'End If

                grilla_estado_de_cuenta.Rows(3).Cells(1).Value = valor
            Next
        End If

        'Exit Sub

        'TOTAL FACTURAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `factura` WHERE fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo <> 'AJUSTE'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Try
                    valor = DS.Tables(DT.TableName).Rows(0).Item("valor")
                Catch
                    valor = "0"
                End Try

                'If valor = "" Or valor = "0" Then
                '    valor = "0"
                'Else
                '    valor = Format(Int(valor), "###,###,###")
                'End If

                grilla_estado_de_cuenta.Rows(3).Cells(2).Value = valor
            Next
        End If

        'TOTAL NOTAS DE CREDITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `nota_credito` WHERE fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo <> 'AJUSTE'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Try
                    valor = DS.Tables(DT.TableName).Rows(0).Item("valor")
                Catch
                    valor = "0"
                End Try

                'If valor = "" Or valor = "0" Then
                '    valor = "0"
                'Else
                '    valor = Format(Int(valor), "###,###,###")
                'End If

                grilla_estado_de_cuenta.Rows(3).Cells(3).Value = valor
            Next
        End If

        'TOTAL NOTAS DE DEBITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `nota_debito` WHERE fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo <> 'AJUSTE'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Try
                    valor = DS.Tables(DT.TableName).Rows(0).Item("valor")
                Catch
                    valor = "0"
                End Try

                'If valor = "" Or valor = "0" Then
                '    valor = "0"
                'Else
                '    valor = Format(Int(valor), "###,###,###")
                'End If

                grilla_estado_de_cuenta.Rows(3).Cells(4).Value = valor
            Next
        End If

        'TOTAL DOCUMENTOS
        Try
            grilla_estado_de_cuenta.Rows(3).Cells(5).Value = Val(grilla_estado_de_cuenta.Rows(3).Cells(1).Value) + Val(grilla_estado_de_cuenta.Rows(3).Cells(2).Value) + Val(grilla_estado_de_cuenta.Rows(3).Cells(3).Value) + Val(grilla_estado_de_cuenta.Rows(3).Cells(4).Value)

            'valor = grilla_estado_de_cuenta.Rows(3).Cells(5).Value
            'If valor = "" Or valor = "0" Then
            '    valor = "0"
            'Else
            '    valor = Format(Int(valor), "###,###,###")
            'End If
            'grilla_estado_de_cuenta.Rows(3).Cells(5).Value = valor

        Catch
        End Try








        Dim iva_valor As String




        iva_valor = 0
        iva_valor = valor_iva / 100 + 1

        Dim neto_resumen As String = 0
        Dim iva_resumen As String = 0
        Dim total_resumen As String = 0

        neto_resumen = 0
        iva_resumen = 0
        total_resumen = 0

        'boletaS
        Try
            total_resumen = grilla_estado_de_cuenta.Rows(3).Cells(1).Value
        Catch
            total_resumen = 0
        End Try

        neto_resumen = Round(total_resumen / iva_valor)
        iva_resumen = (((neto_resumen) * valor_iva) / 100)
        iva_resumen = (total_resumen) - (neto_resumen)

        'If neto_resumen = "" Or neto_resumen = "0" Then
        '    neto_resumen = "0"
        'Else
        '    neto_resumen = Format(Int(neto_resumen), "###,###,###")
        'End If
        'If iva_resumen = "" Or iva_resumen = "0" Then
        '    iva_resumen = "0"
        'Else
        '    iva_resumen = Format(Int(iva_resumen), "###,###,###")
        'End If








        grilla_estado_de_cuenta.Rows(1).Cells(1).Value = neto_resumen
        grilla_estado_de_cuenta.Rows(2).Cells(1).Value = iva_resumen

        neto_resumen = 0
        iva_resumen = 0
        total_resumen = 0

        'FACTURAS
        Try
            total_resumen = grilla_estado_de_cuenta.Rows(3).Cells(2).Value
        Catch
            total_resumen = 0
        End Try
        neto_resumen = Round(total_resumen / iva_valor)
        iva_resumen = (((neto_resumen) * valor_iva) / 100)
        iva_resumen = (total_resumen) - (neto_resumen)

        'If neto_resumen = "" Or neto_resumen = "0" Then
        '    neto_resumen = "0"
        'Else
        '    neto_resumen = Format(Int(neto_resumen), "###,###,###")
        'End If
        'If iva_resumen = "" Or iva_resumen = "0" Then
        '    iva_resumen = "0"
        'Else
        '    iva_resumen = Format(Int(iva_resumen), "###,###,###")
        'End If

        grilla_estado_de_cuenta.Rows(1).Cells(2).Value = neto_resumen
        grilla_estado_de_cuenta.Rows(2).Cells(2).Value = iva_resumen

        'NC
        Try
            total_resumen = grilla_estado_de_cuenta.Rows(3).Cells(3).Value
        Catch
            total_resumen = 0
        End Try
        neto_resumen = Round(total_resumen / iva_valor)
        iva_resumen = (((neto_resumen) * valor_iva) / 100)
        iva_resumen = (total_resumen) - (neto_resumen)

        'If neto_resumen = "" Or neto_resumen = "0" Then
        '    neto_resumen = "0"
        'Else
        '    neto_resumen = Format(Int(neto_resumen), "###,###,###")
        'End If
        'If iva_resumen = "" Or iva_resumen = "0" Then
        '    iva_resumen = "0"
        'Else
        '    iva_resumen = Format(Int(iva_resumen), "###,###,###")
        'End If

        grilla_estado_de_cuenta.Rows(1).Cells(3).Value = neto_resumen
        grilla_estado_de_cuenta.Rows(2).Cells(3).Value = iva_resumen

        'ND
        Try
            total_resumen = grilla_estado_de_cuenta.Rows(3).Cells(4).Value
        Catch
            total_resumen = 0
        End Try

        neto_resumen = Round(total_resumen / iva_valor)
        iva_resumen = (((neto_resumen) * valor_iva) / 100)
        iva_resumen = (total_resumen) - (neto_resumen)


        'If neto_resumen = "" Or neto_resumen = "0" Then
        '    neto_resumen = "0"
        'Else
        '    neto_resumen = Format(Int(neto_resumen), "###,###,###")
        'End If
        'If iva_resumen = "" Or iva_resumen = "0" Then
        '    iva_resumen = "0"
        'Else
        '    iva_resumen = Format(Int(iva_resumen), "###,###,###")
        'End If

        grilla_estado_de_cuenta.Rows(1).Cells(4).Value = neto_resumen
        grilla_estado_de_cuenta.Rows(2).Cells(4).Value = iva_resumen












        Try
            grilla_estado_de_cuenta.Rows(1).Cells(5).Value = Val(grilla_estado_de_cuenta.Rows(1).Cells(1).Value) + Val(grilla_estado_de_cuenta.Rows(1).Cells(2).Value) + Val(grilla_estado_de_cuenta.Rows(1).Cells(3).Value) + Val(grilla_estado_de_cuenta.Rows(1).Cells(4).Value)

            'valor = grilla_estado_de_cuenta.Rows(1).Cells(5).Value
            'If valor = "" Or valor = "0" Then
            '    valor = "0"
            'Else
            '    valor = Format(Int(valor), "###,###,###")
            'End If
            'grilla_estado_de_cuenta.Rows(1).Cells(5).Value = valor


        Catch
        End Try

        Try
            grilla_estado_de_cuenta.Rows(2).Cells(5).Value = Val(grilla_estado_de_cuenta.Rows(2).Cells(1).Value) + Val(grilla_estado_de_cuenta.Rows(2).Cells(2).Value) + Val(grilla_estado_de_cuenta.Rows(2).Cells(3).Value) + Val(grilla_estado_de_cuenta.Rows(2).Cells(4).Value)

            'valor = grilla_estado_de_cuenta.Rows(2).Cells(5).Value
            'If valor = "" Or valor = "0" Then
            '    valor = "0"
            'Else
            '    valor = Format(Int(valor), "###,###,###")
            'End If
            'grilla_estado_de_cuenta.Rows(2).Cells(5).Value = valor


        Catch
        End Try












        valor = grilla_estado_de_cuenta.Rows(0).Cells(1).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(0).Cells(1).Value = valor


        valor = grilla_estado_de_cuenta.Rows(0).Cells(2).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(0).Cells(2).Value = valor


        valor = grilla_estado_de_cuenta.Rows(0).Cells(3).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(0).Cells(3).Value = valor


        valor = grilla_estado_de_cuenta.Rows(0).Cells(4).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(0).Cells(4).Value = valor


        valor = grilla_estado_de_cuenta.Rows(0).Cells(5).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(0).Cells(5).Value = valor







        valor = grilla_estado_de_cuenta.Rows(1).Cells(1).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(1).Cells(1).Value = valor


        valor = grilla_estado_de_cuenta.Rows(1).Cells(2).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(1).Cells(2).Value = valor


        valor = grilla_estado_de_cuenta.Rows(1).Cells(3).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(1).Cells(3).Value = valor


        valor = grilla_estado_de_cuenta.Rows(1).Cells(4).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(1).Cells(4).Value = valor


        valor = grilla_estado_de_cuenta.Rows(1).Cells(5).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(1).Cells(5).Value = valor






        valor = grilla_estado_de_cuenta.Rows(2).Cells(1).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(2).Cells(1).Value = valor


        valor = grilla_estado_de_cuenta.Rows(2).Cells(2).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(2).Cells(2).Value = valor


        valor = grilla_estado_de_cuenta.Rows(2).Cells(3).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(2).Cells(3).Value = valor


        valor = grilla_estado_de_cuenta.Rows(2).Cells(4).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(2).Cells(4).Value = valor


        valor = grilla_estado_de_cuenta.Rows(2).Cells(5).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(2).Cells(5).Value = valor






        valor = grilla_estado_de_cuenta.Rows(3).Cells(1).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(3).Cells(1).Value = valor


        valor = grilla_estado_de_cuenta.Rows(3).Cells(2).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(3).Cells(2).Value = valor


        valor = grilla_estado_de_cuenta.Rows(3).Cells(3).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(3).Cells(3).Value = valor


        valor = grilla_estado_de_cuenta.Rows(3).Cells(4).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(3).Cells(4).Value = valor


        valor = grilla_estado_de_cuenta.Rows(3).Cells(5).Value
        If valor = "" Or valor = "0" Then
            valor = "0"
        Else
            valor = Format(Int(valor), "###,###,###")
        End If
        grilla_estado_de_cuenta.Rows(3).Cells(5).Value = valor
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Private Sub grilla_libro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_libro.CellContentClick

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla()
        malla_resumen()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_libro.Rows.Clear()
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 6.5, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 6.5, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Try
            Dim imagen_reporte As Image
            imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
            Dim posicion_imagen As New PointF(margen_izquierdo + 530, margen_superior + 10)
            e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 75, margen_izquierdo + 780, margen_superior + 45)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 780, margen_superior + 60)

        e.Graphics.DrawString("LIBRO DE VENTAS (" & mirecintoempresa & ")", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 108, margen_izquierdo + 810, margen_superior + 108)
        e.Graphics.DrawString("DESDE " & dtp_desde.Text & " HASTA " & dtp_hasta.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        'If txt_nombre_cliente.Text.Length > 23 Then
        '    txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 23)
        'End If

        'e.Graphics.DrawString("DESDE: " & dtp_desde.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 120)
        'e.Graphics.DrawString("HASTA: " & dtp_hasta.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 250, margen_superior + 120)
        'e.Graphics.DrawString("CODIGO: " & txt_codigo.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 450, margen_superior + 120)
        'e.Graphics.DrawString("USUARIO: " & Combo_vendedor.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 650, margen_superior + 120)

        e.Graphics.DrawString("TIPO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 10, margen_superior + 140)
        e.Graphics.DrawString("FECHA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 110, margen_superior + 140)
        e.Graphics.DrawString("NRO.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 180, margen_superior + 140)
        e.Graphics.DrawString("CONDICION", Font_titulo_columna, Brushes.Black, margen_izquierdo + 240, margen_superior + 140)
        e.Graphics.DrawString("NOMBRE CLIENTE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 310, margen_superior + 140)
        e.Graphics.DrawString("RUT", Font_titulo_columna, Brushes.Black, margen_izquierdo + 530, margen_superior + 140)
        e.Graphics.DrawString("NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 670, margen_superior + 140, format1)
        e.Graphics.DrawString("IVA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 740, margen_superior + 140, format1)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 810, margen_superior + 140, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 155, margen_izquierdo + 810, margen_superior + 155)

        Dim tipo_detalle As String
        Dim fecha_detalle As String
        Dim numero_detalle As String
        Dim condicion_detalle As String
        Dim nombre_detalle As String
        Dim rut_detalle As String
        Dim neto_detalle As String
        Dim iva_detalle As String
        Dim total_detalle As String

        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10

        For i = numero_lineas_total To grilla_libro.Rows.Count - 1
            tipo_detalle = grilla_libro.Rows(i).Cells(0).Value.ToString
            fecha_detalle = grilla_libro.Rows(i).Cells(1).Value.ToString
            numero_detalle = grilla_libro.Rows(i).Cells(2).Value.ToString
            condicion_detalle = grilla_libro.Rows(i).Cells(3).Value.ToString
            nombre_detalle = grilla_libro.Rows(i).Cells(4).Value.ToString
            rut_detalle = grilla_libro.Rows(i).Cells(5).Value.ToString
            neto_detalle = grilla_libro.Rows(i).Cells(6).Value.ToString
            iva_detalle = grilla_libro.Rows(i).Cells(7).Value.ToString
            total_detalle = grilla_libro.Rows(i).Cells(8).Value.ToString

            If neto_detalle = "" Or neto_detalle = "0" Then
                neto_detalle = "0"
            Else
                neto_detalle = Format(Int(neto_detalle), "###,###,###")
            End If

            If iva_detalle = "" Or iva_detalle = "0" Then
                iva_detalle = "0"
            Else
                iva_detalle = Format(Int(iva_detalle), "###,###,###")
            End If

            If total_detalle = "" Or total_detalle = "0" Then
                total_detalle = "0"
            Else
                total_detalle = Format(Int(total_detalle), "###,###,###")
            End If

            If fecha_detalle.Length > 10 Then
                fecha_detalle = fecha_detalle.Substring(0, 10)
            End If

            If nombre_detalle.Length > 35 Then
                nombre_detalle = nombre_detalle.Substring(0, 35)
            End If

            If fecha_detalle.Length > 10 Then
                fecha_detalle = fecha_detalle.Substring(0, 10)
            End If

            e.Graphics.DrawString(tipo_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 10, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(fecha_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 110, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(numero_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 180, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(condicion_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 240, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(nombre_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 310, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(rut_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 530, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(neto_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 670, margen_superior + 160 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(iva_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 740, margen_superior + 160 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(total_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 810, margen_superior + 160 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************


            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 85 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 165 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 165 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 165 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 165 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0

        Dim cantidad_1 As String
        Dim cantidad_2 As String
        Dim cantidad_3 As String
        Dim cantidad_4 As String
        Dim cantidad_5 As String

        Dim neto_1 As String
        Dim neto_2 As String
        Dim neto_3 As String
        Dim neto_4 As String
        Dim neto_5 As String

        Dim iva_1 As String
        Dim iva_2 As String
        Dim iva_3 As String
        Dim iva_4 As String
        Dim iva_5 As String

        Dim total_1 As String
        Dim total_2 As String
        Dim total_3 As String
        Dim total_4 As String
        Dim total_5 As String

        cantidad_1 = grilla_estado_de_cuenta.Rows(0).Cells(1).Value
        cantidad_2 = grilla_estado_de_cuenta.Rows(0).Cells(2).Value
        cantidad_3 = grilla_estado_de_cuenta.Rows(0).Cells(3).Value
        cantidad_4 = grilla_estado_de_cuenta.Rows(0).Cells(4).Value
        cantidad_5 = grilla_estado_de_cuenta.Rows(0).Cells(5).Value

        neto_1 = grilla_estado_de_cuenta.Rows(1).Cells(1).Value
        neto_2 = grilla_estado_de_cuenta.Rows(1).Cells(2).Value
        neto_3 = grilla_estado_de_cuenta.Rows(1).Cells(3).Value
        neto_4 = grilla_estado_de_cuenta.Rows(1).Cells(4).Value
        neto_5 = grilla_estado_de_cuenta.Rows(1).Cells(5).Value

        iva_1 = grilla_estado_de_cuenta.Rows(2).Cells(1).Value
        iva_2 = grilla_estado_de_cuenta.Rows(2).Cells(2).Value
        iva_3 = grilla_estado_de_cuenta.Rows(2).Cells(3).Value
        iva_4 = grilla_estado_de_cuenta.Rows(2).Cells(4).Value
        iva_5 = grilla_estado_de_cuenta.Rows(2).Cells(5).Value

        total_1 = grilla_estado_de_cuenta.Rows(3).Cells(1).Value
        total_2 = grilla_estado_de_cuenta.Rows(3).Cells(2).Value
        total_3 = grilla_estado_de_cuenta.Rows(3).Cells(3).Value
        total_4 = grilla_estado_de_cuenta.Rows(3).Cells(4).Value
        total_5 = grilla_estado_de_cuenta.Rows(3).Cells(5).Value

        e.Graphics.DrawString("BOLETAS", Font_titulo_columna, Brushes.Black, margen_izquierdo + 410, margen_superior + 200 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString("FACTURAS", Font_titulo_columna, Brushes.Black, margen_izquierdo + 510, margen_superior + 200 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString("NOTAS DE CRED.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 610, margen_superior + 200 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString("NOTAS DE DEB.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 710, margen_superior + 200 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 810, margen_superior + 200 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 250, margen_superior + 215 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 215 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 260, margen_superior + 220 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 260, margen_superior + 235 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("IVA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 260, margen_superior + 250 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 260, margen_superior + 265 + (numero_lineas * multiplicador_lineas))
        'e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 280 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 700, margen_superior + 280 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString(cantidad_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 410, margen_superior + 220 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(cantidad_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 510, margen_superior + 220 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(cantidad_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 610, margen_superior + 220 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(cantidad_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 710, margen_superior + 220 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(cantidad_5, Font_texto_impresion, Brushes.Black, margen_izquierdo + 810, margen_superior + 220 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(neto_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 410, margen_superior + 235 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(neto_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 510, margen_superior + 235 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(neto_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 610, margen_superior + 235 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(neto_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 710, margen_superior + 235 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(neto_5, Font_texto_impresion, Brushes.Black, margen_izquierdo + 810, margen_superior + 235 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(iva_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 410, margen_superior + 250 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(iva_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 510, margen_superior + 250 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(iva_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 610, margen_superior + 250 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(iva_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 710, margen_superior + 250 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(iva_5, Font_texto_impresion, Brushes.Black, margen_izquierdo + 810, margen_superior + 250 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(total_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 410, margen_superior + 265 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(total_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 510, margen_superior + 265 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(total_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 610, margen_superior + 265 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(total_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 710, margen_superior + 265 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(total_5, Font_texto_impresion, Brushes.Black, margen_izquierdo + 810, margen_superior + 265 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 250, margen_superior + 280 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 280 + (numero_lineas * multiplicador_lineas))



    End Sub
End Class