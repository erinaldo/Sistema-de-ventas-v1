Imports System.IO

Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_registro_de_facturas
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim mifecha6 As String

    Private Sub Form_facturas_vencidas_2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_facturas_vencidas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F4 Then
            Form_buscador_proveedores_registro_facturas.Show()
            Me.Enabled = False
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

    Private Sub Form_facturas_vencidas_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        fecha2()
        combo_estado.SelectedItem = "TODOS"
        'Combo_fecha.SelectedItem = "EMISION"
        mostrar()
        calcular_totales()
        Timer_registro_facturas.Start()
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha2 se le entrega el formato de fecha indicado.
    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha2 se le entrega el formato de fecha indicado.
    Sub fecha2()
        Dim mifecha1 As Date
        mifecha1 = dtp_hasta.Text
        mifecha4 = mifecha1.ToString("yyy-MM-dd")
    End Sub



    Sub mostrar()
        fecha()
        fecha2()
        conexion.Close()

        Dim estado_revision As String

        If txt_nro_factura.Text <> "" Then
            grilla_facturas.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select documento, nro_factura, total, fecha_factura, proveedores.nombre_proveedor as proveedor, LIBRO_DE_COMPRAS.RUT_PROVEEDOR,estado, codigo_folio, PERIODO_TRIBUTARIO from LIBRO_DE_compraS, proveedores where LIBRO_DE_compraS.rut_PROVEEDOR=proveedores.rut_PROVEEDOR and nro_factura='" & (txt_nro_factura.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim TIPO As String
                Dim numero As String
                Dim total As String
                Dim vencimiento As String
                Dim proveedor As String
                Dim estado As String
                Dim rut_proveedor As String
                Dim codigo_folio As String
                Dim fecha_factura As String

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    TIPO = DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO")
                    numero = DS.Tables(DT.TableName).Rows(i).Item("nRO_FACTURA")
                    total = DS.Tables(DT.TableName).Rows(i).Item("total")
                    vencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_factura")
                    proveedor = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
                    rut_proveedor = DS.Tables(DT.TableName).Rows(i).Item("RUT_PROVEEDOR")
                    estado = DS.Tables(DT.TableName).Rows(i).Item("ESTADO")
                    codigo_folio = DS.Tables(DT.TableName).Rows(i).Item("codigo_folio")
                    fecha_factura = DS.Tables(DT.TableName).Rows(i).Item("periodo_tributario")
                    grilla_facturas.Rows.Add(TIPO, estado, proveedor, total, vencimiento, numero, rut_proveedor, codigo_folio, fecha_factura)
                Next
            End If
            conexion.Close()



            If grilla_facturas.Rows.Count <> 0 Then
                If grilla_facturas.Columns(0).Width = 120 Then
                    grilla_facturas.Columns(0).Width = 119
                Else
                    grilla_facturas.Columns(0).Width = 120
                End If
            End If


            'estado_revision = grilla1.CurrentRow.Cells(9).Value
            For i = 0 To grilla_facturas.Rows.Count - 1
                estado_revision = grilla_facturas.Rows(i).Cells(1).Value.ToString
                If estado_revision = "PAGADA" Then
                    grilla_facturas.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next
            Exit Sub
        End If







        If txt_rut_proveedor.Text = "" Then
            If combo_estado.Text = "TODOS" Then
                grilla_facturas.Rows.Clear()

                conexion.Close()
                DS.Tables.Clear()
                DT.Columns.Clear()
                DT.Rows.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select documento, nro_factura, total, fecha_factura, proveedores.nombre_proveedor as proveedor, LIBRO_DE_COMPRAS.RUT_PROVEEDOR,estado,codigo_folio, PERIODO_TRIBUTARIO from LIBRO_DE_compraS, proveedores where fecha_factura >='" & (mifecha2) & "' and fecha_factura <='" & (mifecha4) & "' and LIBRO_DE_compraS.rut_PROVEEDOR=proveedores.rut_PROVEEDOR  group by NRO_FACTURA"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    Dim TIPO As String
                    Dim numero As String
                    Dim total As String
                    Dim vencimiento As String
                    Dim proveedor As String
                    Dim estado As String
                    Dim rut_proveedor As String
                    Dim codigo_folio As String
                    Dim fecha_factura As String

                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        TIPO = DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO")
                        numero = DS.Tables(DT.TableName).Rows(i).Item("nRO_FACTURA")
                        total = DS.Tables(DT.TableName).Rows(i).Item("total")
                        vencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_factura")
                        proveedor = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
                        rut_proveedor = DS.Tables(DT.TableName).Rows(i).Item("RUT_PROVEEDOR")
                        estado = DS.Tables(DT.TableName).Rows(i).Item("ESTADO")
                        codigo_folio = DS.Tables(DT.TableName).Rows(i).Item("codigo_folio")
                        fecha_factura = DS.Tables(DT.TableName).Rows(i).Item("periodo_tributario")


                        'Dim codigo_folio_completo As String
                        'codigo_folio_completo = codigo_folio
                        'codigo_folio = String.Format("{0:000000}", codigo_folio_completo)

                        grilla_facturas.Rows.Add(TIPO, estado, proveedor, total, vencimiento, numero, rut_proveedor, codigo_folio, fecha_factura)
                    Next
                End If
                conexion.Close()

                If grilla_facturas.Rows.Count <> 0 Then
                    If grilla_facturas.Columns(0).Width = 120 Then
                        grilla_facturas.Columns(0).Width = 119
                    Else
                        grilla_facturas.Columns(0).Width = 120
                    End If
                End If

            ElseIf combo_estado.Text <> "TODOS" Then
                grilla_facturas.Rows.Clear()

                conexion.Close()
                DS.Tables.Clear()
                DT.Columns.Clear()
                DT.Rows.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select documento, nro_factura, total, fecha_factura, proveedores.nombre_proveedor as proveedor, LIBRO_DE_COMPRAS.RUT_PROVEEDOR, estado,codigo_folio, PERIODO_TRIBUTARIO from LIBRO_DE_compraS, proveedores where fecha_factura >='" & (mifecha2) & "' and fecha_factura <='" & (mifecha4) & "' and LIBRO_DE_compraS.rut_PROVEEDOR=proveedores.rut_PROVEEDOR  AND ESTADO='" & (combo_estado.Text) & "' group by NRO_FACTURA"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    Dim TIPO As String
                    Dim numero As String
                    Dim total As String
                    Dim vencimiento As String
                    Dim proveedor As String
                    Dim estado As String
                    Dim rut_proveedor As String
                    Dim codigo_folio As String
                    Dim fecha_factura As String

                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        TIPO = DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO")
                        numero = DS.Tables(DT.TableName).Rows(i).Item("nRO_FACTURA")
                        total = DS.Tables(DT.TableName).Rows(i).Item("total")
                        vencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_factura")
                        proveedor = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
                        rut_proveedor = DS.Tables(DT.TableName).Rows(i).Item("RUT_PROVEEDOR")
                        estado = DS.Tables(DT.TableName).Rows(i).Item("ESTADO")
                        codigo_folio = DS.Tables(DT.TableName).Rows(i).Item("codigo_folio")
                        fecha_factura = DS.Tables(DT.TableName).Rows(i).Item("periodo_tributario")
                        grilla_facturas.Rows.Add(TIPO, estado, proveedor, total, vencimiento, numero, rut_proveedor, codigo_folio, fecha_factura)
                    Next
                End If
                conexion.Close()
            End If
        End If

        If grilla_facturas.Rows.Count <> 0 Then
            If grilla_facturas.Columns(0).Width = 120 Then
                grilla_facturas.Columns(0).Width = 119
            Else
                grilla_facturas.Columns(0).Width = 120
            End If
        End If

        If txt_rut_proveedor.Text <> "" Then
            If combo_estado.Text = "TODOS" Then
                grilla_facturas.Rows.Clear()

                conexion.Close()
                DS.Tables.Clear()
                DT.Columns.Clear()
                DT.Rows.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select documento, nro_factura, total, fecha_factura, proveedores.nombre_proveedor as proveedor, LIBRO_DE_COMPRAS.RUT_PROVEEDOR, estado,codigo_folio, PERIODO_TRIBUTARIO from LIBRO_DE_compraS, proveedores where fecha_factura >='" & (mifecha2) & "' and fecha_factura <='" & (mifecha4) & "' and LIBRO_DE_compraS.rut_PROVEEDOR='" & (txt_rut_proveedor.Text) & "' and LIBRO_DE_compraS.rut_PROVEEDOR=proveedores.rut_PROVEEDOR  group by NRO_FACTURA"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    Dim TIPO As String
                    Dim numero As String
                    Dim total As String
                    Dim vencimiento As String
                    Dim proveedor As String
                    Dim estado As String
                    Dim rut_proveedor As String
                    Dim codigo_folio As String
                    Dim fecha_factura As String

                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        TIPO = DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO")
                        numero = DS.Tables(DT.TableName).Rows(i).Item("nRO_FACTURA")
                        total = DS.Tables(DT.TableName).Rows(i).Item("total")
                        vencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_factura")
                        proveedor = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
                        rut_proveedor = DS.Tables(DT.TableName).Rows(i).Item("RUT_PROVEEDOR")
                        estado = DS.Tables(DT.TableName).Rows(i).Item("ESTADO")
                        codigo_folio = DS.Tables(DT.TableName).Rows(i).Item("codigo_folio")
                        fecha_factura = DS.Tables(DT.TableName).Rows(i).Item("periodo_tributario")
                        grilla_facturas.Rows.Add(TIPO, estado, proveedor, total, vencimiento, numero, rut_proveedor, codigo_folio, fecha_factura)
                    Next
                End If
                conexion.Close()

                If grilla_facturas.Rows.Count <> 0 Then
                    If grilla_facturas.Columns(0).Width = 120 Then
                        grilla_facturas.Columns(0).Width = 119
                    Else
                        grilla_facturas.Columns(0).Width = 120
                    End If
                End If

            ElseIf combo_estado.Text <> "TODOS" Then
                grilla_facturas.Rows.Clear()
                conexion.Close()
                DS.Tables.Clear()
                DT.Columns.Clear()
                DT.Rows.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select documento, nro_factura, total, fecha_factura, proveedores.nombre_proveedor as proveedor, LIBRO_DE_COMPRAS.RUT_PROVEEDOR, estado,codigo_folio, PERIODO_TRIBUTARIO from LIBRO_DE_compraS, proveedores where fecha_factura >='" & (mifecha2) & "' and fecha_factura <='" & (mifecha4) & "' and LIBRO_DE_compraS.rut_PROVEEDOR='" & (txt_rut_proveedor.Text) & "' and LIBRO_DE_compraS.rut_PROVEEDOR=proveedores.rut_PROVEEDOR AND ESTADO='" & (combo_estado.Text) & "' group by NRO_FACTURA"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    Dim TIPO As String
                    Dim numero As String
                    Dim total As String
                    Dim vencimiento As String
                    Dim proveedor As String
                    Dim estado As String
                    Dim rut_proveedor As String
                    Dim codigo_folio As String
                    Dim fecha_factura As String

                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        TIPO = DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO")
                        numero = DS.Tables(DT.TableName).Rows(i).Item("nRO_FACTURA")
                        total = DS.Tables(DT.TableName).Rows(i).Item("total")
                        vencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_factura")
                        proveedor = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
                        rut_proveedor = DS.Tables(DT.TableName).Rows(i).Item("RUT_PROVEEDOR")
                        estado = DS.Tables(DT.TableName).Rows(i).Item("ESTADO")
                        codigo_folio = DS.Tables(DT.TableName).Rows(i).Item("codigo_folio")
                        fecha_factura = DS.Tables(DT.TableName).Rows(i).Item("periodo_tributario")
                        grilla_facturas.Rows.Add(TIPO, estado, proveedor, total, vencimiento, numero, rut_proveedor, codigo_folio, fecha_factura)
                    Next
                End If
                conexion.Close()
            End If
        End If


        If grilla_facturas.Rows.Count <> 0 Then
            If grilla_facturas.Columns(0).Width = 120 Then
                grilla_facturas.Columns(0).Width = 119
            Else
                grilla_facturas.Columns(0).Width = 120
            End If
        End If







        ' Dim estado_revision As String
        'estado_revision = grilla1.CurrentRow.Cells(9).Value
        For i = 0 To grilla_facturas.Rows.Count - 1
            estado_revision = grilla_facturas.Rows(i).Cells(1).Value.ToString
            If estado_revision = "PAGADA" Then
                grilla_facturas.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next
    End Sub

    Private Sub dtp1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.GotFocus
        dtp_desde.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_desde.KeyPress
        grilla_facturas.Rows.Clear()
        calcular_totales()
    End Sub

    Private Sub dtp1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.LostFocus
        dtp_desde.BackColor = Color.White
    End Sub

    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_facturas.Rows.Clear()
        calcular_totales()
    End Sub

    Private Sub dtp2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.GotFocus
        dtp_hasta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_hasta.KeyPress
        grilla_facturas.Rows.Clear()
        fecha()
        fecha2()
        mostrar()
        calcular_totales()
    End Sub

    Private Sub dtp2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.LostFocus
        dtp_hasta.BackColor = Color.White
    End Sub

    Private Sub dtp2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_facturas.Rows.Clear()
        calcular_totales()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cambiar.Click
        'Dim estado As String
        'Dim valormensaje As Integer
        'Dim Varnumero As Integer
        'Dim rut_proveedor As String
        Dim mensaje As String = ""

        If grilla_facturas.Rows.Count = 0 Then
            MsgBox("SELECCIONE UN DOCUMENTO", 0 + 16, "ERROR")
        Else
            'If grilla1.CurrentRow.Cells(7).Value = True Then
            '    valormensaje = MsgBox("¿ESTA SEGURO DE CAMBIAR EL ESTADO DE LAS FACTURAS?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "MODIFICAR")
            '    fecha()
            '    fecha2()
            '    fecha3()
            '    If valormensaje = vbYes Then
            '        For i = 0 To grilla1.Rows.Count - 1
            '            estado = grilla1.Rows(i).Cells(5).Value.ToString
            '            Varnumero = grilla1.Rows(i).Cells(1).Value.ToString
            '            rut_proveedor = grilla1.Rows(i).Cells(6).Value.ToString
            '            If estado = "IMPAGA" And grilla1.Rows(i).Cells(7).Value = True Then
            '                DS.Tables.Clear()
            '                DT.Rows.Clear()
            '                DT.Columns.Clear()
            '                DS.Clear()
            '                conexion.Open()

            '                SC.Connection = conexion
            '                SC.CommandText = "UPDATE LIBRO_DE_COMPRAs SET estado= 'PAGADA', fecha_de_pago= '" & (mifecha6) & "' where NRO_FACTURA='" & (Varnumero) & "' and  rut_proveedor= '" & (rut_proveedor) & "' "
            '                DA.SelectCommand = SC
            '                DA.Fill(DT)
            '                conexion.Close()
            '                '  Next
            '            End If
            '            If estado = "PAGADA" And grilla1.Rows(i).Cells(7).Value = True Then
            '                ' For i = 0 To grilla1.Rows.Count - 1
            '                Varnumero = grilla1.Rows(i).Cells(1).Value.ToString
            '                estado = grilla1.Rows(i).Cells(5).Value.ToString
            '                rut_proveedor = grilla1.Rows(i).Cells(6).Value.ToString
            '                DS.Tables.Clear()
            '                DT.Rows.Clear()
            '                DT.Columns.Clear()
            '                DS.Clear()
            '                conexion.Open()

            '                SC.Connection = conexion
            '                SC.CommandText = "UPDATE LIBRO_DE_COMPRAs SET estado= 'IMPAGA', fecha_de_pago= '" & (mifecha6) & "' where n_compra='" & (Varnumero) & "' and  rut_proveedor= '" & (rut_proveedor) & "' "
            '                DA.SelectCommand = SC
            '                DA.Fill(DT)
            '                conexion.Close()

            '            End If
            '        Next
            '        mostrar()
            '        calcular_totales()

            '    End If
            'ElseIf grilla1.CurrentRow.Cells(6).Value = False Then
            '    MsgBox("SELECCIONE UN DOCUMENTO", 0 + 16, "ERROR")


            'End If








            For i = 0 To grilla_facturas.Rows.Count - 1
                If grilla_facturas.Rows(i).Cells(9).Value = True Then
                    Form_detalle_pago_facturas.Show()
                    Me.Enabled = False
                    Exit Sub
                End If
            Next

        End If
    End Sub

    Sub calcular_totales()
        Dim totalfacturas_adeudadas As Integer
        '//Calcular el total de las facturas vencidas
        txt_total.Text = 0
        For i = 0 To grilla_facturas.Rows.Count - 1
            totalfacturas_adeudadas = Val(grilla_facturas.Rows(i).Cells(3).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalfacturas_adeudadas)
        Next

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fecha()
        fecha2()
        mostrar()
        calcular_totales()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mensaje As String = ""
        If grilla_facturas.Rows.Count = 0 Then mensaje = "GRILLA VACIA" + Chr(13) & mensaje
        If mensaje <> "" Then
            MsgBox(mensaje, 0 + 16, "ERROR")
        Else

            txt_total.Text = "0"
            'combo_rut.Text = "TODOS"
            grilla_facturas.Rows.Clear()

            ' txt_rut.Text = ""
        End If
    End Sub

    'sub que graba la informacion de la comision.
    Sub grabar_facturas()
        Dim VarTipo As String
        Dim Varnumero As String
        Dim Vartotal As String
        Dim Varfecha As String
        Dim Varnombre As String
        Dim Varestado As String

        For i = 0 To grilla_facturas.Rows.Count - 1

            VarTipo = grilla_facturas.Rows(i).Cells(0).Value.ToString
            Varnumero = grilla_facturas.Rows(i).Cells(5).Value.ToString
            Vartotal = grilla_facturas.Rows(i).Cells(3).Value.ToString
            Varfecha = grilla_facturas.Rows(i).Cells(4).Value.ToString
            Varnombre = grilla_facturas.Rows(i).Cells(2).Value.ToString
            Varestado = grilla_facturas.Rows(i).Cells(1).Value.ToString

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "insert into facturas_vencidas (TIPO, n_compra, total, fecha_vencimiento, nombre, total_facturas, estado) values('" & (VarTipo) & "','" & (Varnumero) & "','" & (Vartotal) & "','" & (Varfecha) & "','" & (Varnombre) & "'," & (txt_total.Text) & ",'" & (Varestado) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Close()
        Next
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        Dim mensaje As String = ""
        If grilla_facturas.Rows.Count = 0 Then mensaje = "GRILLA VACIA" + Chr(13) & mensaje

        If mensaje <> "" Then
            MsgBox(mensaje, 0 + 16, "ERROR")
        Else

            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized
            PrintPreviewDialog1.ShowDialog()
        End If
        '    grabar_facturas()

        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()



        '    Dim rpt As New Crystal_factura_compra_sistema

        '    rpt.SetDataSource(DS.Tables(DT.TableName))
        '    Form_informe_facturas_vencidas.rpt_facturas_vencidas.ReportSource = rpt
        '    Form_informe_facturas_vencidas.Show()
        '    conexion.Close()

        '    SC.Connection = conexion
        '    SC.CommandText = "delete from facturas_vencidas"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'End If






        'Dim TIPO As String
        'Dim numero As String
        'Dim total As String
        'Dim vencimiento As String
        'Dim proveedor As String
        'Dim estado As String
        'Dim rut_proveedor As String
        'Dim codigo_folio As String
        'Dim fecha_factura As String

        'For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '    TIPO = grilla_facturas.Rows(i).Cells(0).Value.ToString
        '    numero = grilla_facturas.Rows(i).Cells(0).Value.ToString
        '    total = grilla_facturas.Rows(i).Cells(0).Value.ToString
        '    vencimiento = grilla_facturas.Rows(i).Cells(0).Value.ToString
        '    proveedor = grilla_facturas.Rows(i).Cells(0).Value.ToString
        '    rut_proveedor = grilla_facturas.Rows(i).Cells(0).Value.ToString
        '    estado = grilla_facturas.Rows(i).Cells(0).Value.ToString
        '    codigo_folio = grilla_facturas.Rows(i).Cells(0).Value.ToString
        '    fecha_factura = grilla_facturas.Rows(i).Cells(0).Value.ToString


        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    SC.CommandText = "insert into facturas_vencidas (TIPO, n_compra, total, fecha_vencimiento, nombre, total_facturas, estado) values('" & (VarTipo) & "','" & (Varnumero) & "','" & (Vartotal) & "','" & (Varfecha) & "','" & (Varnombre) & "'," & (txt_total.Text) & ",'" & (Varestado) & "')"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    conexion.Close()

        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Close()
        'Next
    End Sub

    Private Sub combo_estado_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_estado.GotFocus
        combo_estado.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_estado.KeyPress
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

    Private Sub combo_estado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_estado.LostFocus
        combo_estado.BackColor = Color.White
    End Sub

    Private Sub combo_estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_estado.SelectedIndexChanged
        grilla_facturas.Rows.Clear()
        calcular_totales()
        Check_folio.Checked = False
        Check_periodo_tributario.Checked = False
        Check_rut.Checked = False
    End Sub

    Private Sub grilla1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_facturas.CellContentClick

    End Sub

    Private Sub txt_rut_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.GotFocus
        txt_rut_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_proveedor.KeyPress
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
            grilla_facturas.Rows.Clear()
            calcular_totales()
            Check_folio.Checked = False
            Check_periodo_tributario.Checked = False
            Check_rut.Checked = False
        End If
    End Sub

    Private Sub txt_rut_proveedor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut_proveedor.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_proveedores_registro_facturas.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_rut_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.LostFocus
        txt_rut_proveedor.BackColor = Color.White
    End Sub

    Private Sub txt_rut_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar.Click
        Form_cargar_detalle_facturas.Show()
        Me.Enabled = False
    End Sub

    Private Sub grilla_facturas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_facturas.Click
        If grilla_facturas.Rows.Count <= 0 Then
            Exit Sub
        End If
        txt_rut_proveedor.Text = grilla_facturas.CurrentRow.Cells(6).Value()
        '   End If
    End Sub

    Private Sub grilla_facturas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_facturas.DoubleClick

        If grilla_facturas.Rows.Count = 0 Then
            Exit Sub
        End If
        mostrar_datos_factura()
    End Sub

    Sub mostrar_datos_factura()
        'Dim fecha_de_pago As String
        'Dim forma_de_pago As String
        'Dim detalle_de_pago As String
        Dim rut_proveedor As String
        Dim nro_factura As String

        Dim estado As String

        rut_proveedor = grilla_facturas.CurrentRow.Cells(6).Value()
        nro_factura = grilla_facturas.CurrentRow.Cells(5).Value()
        estado = grilla_facturas.CurrentRow.Cells(1).Value()

        If estado = "PAGADA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select fecha_de_pago,forma_de_pago, detalle_de_pago from libro_de_compras where rut_proveedor= '" & (rut_proveedor) & "' and nro_factura= '" & (nro_factura) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Form_info_factura_pagada.txt_fecha_de_pago.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_de_pago")
                Form_info_factura_pagada.txt_forma_de_pago.Text = DS.Tables(DT.TableName).Rows(0).Item("forma_de_pago")
                Form_info_factura_pagada.txt_detalle_de_pago.Text = DS.Tables(DT.TableName).Rows(0).Item("detalle_de_pago")

                Me.Enabled = False
                Form_info_factura_pagada.Show()
                '  MsgBox("FECHA DE PAGO '" & (fecha_de_pago) & "'" & vbNewLine & "FORMA DE PAGO:'" & (forma_de_pago) & "'" & vbNewLine & "DETALLE:'" & (detalle_de_pago) & "'", "ATENCION")

                ' MsgBox("FECHA DE PAGO '" & (fecha_de_pago) & "'" & vbCrLf & "FORMA DE PAGO:'" & (forma_de_pago) & "'" & vbCrLf & "DETALLE:'" & (detalle_de_pago) & "'")

            End If
            conexion.Close()
        End If
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_nro_factura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_factura.GotFocus
        txt_nro_factura.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_factura.KeyPress
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
            If txt_nro_factura.Text = "" Then
                MsgBox("CAMPO NRO. FACTURA VACIO", 0 + 16, "ERROR")
                Exit Sub
            End If
            grilla_facturas.Rows.Clear()
            calcular_totales()
            Check_folio.Checked = False
            Check_periodo_tributario.Checked = False
            Check_rut.Checked = False
        End If
    End Sub

    Private Sub txt_nro_factura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_factura.LostFocus
        txt_nro_factura.BackColor = Color.White
    End Sub

    Private Sub txt_nro_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_factura.TextChanged

    End Sub




    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        Dim Font2 As New Font("arial", 9, FontStyle.Regular)
        Dim Font3 As New Font("arial", 7, FontStyle.Regular)
        Dim Font4 As New Font("arial", 8, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        '  Dim rect1 As New Rectangle(0, 0, 270, 15)


        Dim nombre_proveedor As String
        nombre_proveedor = grilla_facturas.CurrentRow.Cells(2).Value

        If txt_forma_de_pago.TextLength > 2 Then
            txt_forma_de_pago.Text = txt_forma_de_pago.Text.Substring(0, 2)
        End If

        '  nombre_proveedor = nombre_proveedor.Substring(0, 20)
        If nombre_proveedor.Length > 20 Then
            nombre_proveedor = nombre_proveedor.Substring(0, 20)
        End If

        nombre_proveedor = StrConv(nombre_proveedor, vbProperCase)

        e.Graphics.DrawString(txt_forma_de_pago.Text & ". " & txt_detalle_de_pago.Text, Font2, Brushes.Black, 0, 0)

        e.Graphics.DrawString(nombre_proveedor, Font2, Brushes.Black, 0, 22)


        'e.Graphics.DrawLine(Pens.Black, 1, 360, 300, 270)
        Dim TIPO As String
        Dim NRO_FACTURA As String
        Dim TOTAL_FACTURA As String
        Dim FOLIO_FACTURA As String
        Dim MES_FACTURA As String
        'Dim TOTAL_FACTURAS As String


        For i = 0 To grilla_facturas.Rows.Count - 1
            TIPO = grilla_facturas.Rows(i).Cells(0).Value.ToString
            NRO_FACTURA = grilla_facturas.Rows(i).Cells(5).Value.ToString
            TOTAL_FACTURA = grilla_facturas.Rows(i).Cells(3).Value.ToString
            FOLIO_FACTURA = grilla_facturas.Rows(i).Cells(7).Value.ToString
            MES_FACTURA = grilla_facturas.Rows(i).Cells(8).Value.ToString

            '  e.Graphics.DrawString("NRO.", Font2, Brushes.Black, 26, 35)
            ' e.Graphics.DrawString("TOTAL", Font2, Brushes.Black, 90, 35)
            '  e.Graphics.DrawString("FOLIO", Font1, Brushes.Black, 110, 35)

            If TIPO = "FACTURA" Then
                e.Graphics.DrawString("F", Font2, Brushes.Black, 0, 35 + (i * 10))
            End If

            If TIPO = "NOTA DE CREDITO" Then
                e.Graphics.DrawString("NC", Font2, Brushes.Black, 0, 35 + (i * 10))
            End If

            Dim cadena As String
            cadena = MES_FACTURA
            MES_FACTURA = Mid(cadena, 1, 2)

            Dim TOTAL_MILLAR As String
            TOTAL_MILLAR = TOTAL_FACTURA
            TOTAL_MILLAR = Format(Int(TOTAL_FACTURA), "###,###,###")

            e.Graphics.DrawString(NRO_FACTURA, Font2, Brushes.Black, 20, 35 + (i * 10))
            e.Graphics.DrawString(TOTAL_MILLAR, Font2, Brushes.Black, 138, 35 + (i * 10), format1)
            ' e.Graphics.DrawString(FOLIO_FACTURA, Font1, Brushes.Black, 130, 50 + (i * 10), format1)
            ' e.Graphics.DrawString(MES_FACTURA, Font1, Brushes.Black, 135, 50 + (i * 10))
            ' e.Graphics.DrawString("-", Font1, Brushes.Black, 130, 50 + (i * 10))
        Next

        Dim var_grilla As Integer
        var_grilla = ((grilla_facturas.Rows.Count - 1) * 10)

        '  e.Graphics.DrawString("TOTAL:", Font2, Brushes.Black, 0, var_grilla + 50)

        Dim TOTALES_MILLAR As String
        TOTALES_MILLAR = txt_total.Text
        TOTALES_MILLAR = Format(Int(txt_total.Text), "###,###,###")
        e.Graphics.DrawString("$" & TOTALES_MILLAR, Font2, Brushes.Black, 138, var_grilla + 47, format1)
    End Sub

    Private Sub Check_rut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_rut.CheckedChanged
        If Check_rut.Checked = True Then
            grilla_facturas.Columns(6).Visible = True
        Else
            grilla_facturas.Columns(6).Visible = False
        End If
    End Sub

    Private Sub Check_folio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_folio.CheckedChanged
        If Check_folio.Checked = True Then
            grilla_facturas.Columns(7).Visible = True
        Else
            grilla_facturas.Columns(7).Visible = False
        End If
    End Sub


    Private Sub Check_periodo_tributario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_periodo_tributario.CheckedChanged
        If Check_periodo_tributario.Checked = True Then
            grilla_facturas.Columns(8).Visible = True
        Else
            grilla_facturas.Columns(8).Visible = False
        End If
    End Sub

    Private Sub txt_total_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.GotFocus
        txt_total.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_total_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total.KeyPress
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

    Private Sub txt_total_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.LostFocus
        txt_total.BackColor = Color.White
    End Sub

    Private Sub txt_total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total.TextChanged

    End Sub


    Private Sub btn_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.GotFocus
        btn_cargar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.LostFocus
        btn_cargar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cambiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambiar.GotFocus
        btn_cambiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cambiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambiar.LostFocus
        btn_cambiar.BackColor = Color.Transparent
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

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
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

    Private Sub Timer_registro_facturas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_registro_facturas.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub

    Private Sub Combo_fecha_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar()
        calcular_totales()
        Check_folio.Checked = False
        Check_periodo_tributario.Checked = False
        Check_rut.Checked = False
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        buscar_proveedores = "1"
        Form_buscador_proveedores_registro_facturas.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox_logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_logo.Click

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        fecha2()
        mostrar()
        calcular_totales()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub Check_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_todos.CheckedChanged
        If Check_todos.Checked = True Then
            For i = 0 To grilla_facturas.Rows.Count - 1
                grilla_facturas.Rows(i).Cells(9).Value = True
            Next
        Else
            For i = 0 To grilla_facturas.Rows.Count - 1
                grilla_facturas.Rows(i).Cells(9).Value = False
            Next
        End If
    End Sub
End Class