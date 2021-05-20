Imports System.IO
Imports System.Data.OleDb
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Form_libro_de_compras_impresion
    Dim numero_lineas_total As Integer = 0
    'Dim impreso As Integer = 0

    Private Sub Form_libro_de_compras_impresion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_libro_de_compras_impresion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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


    Private Sub Form_libro_de_compras_impresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_libro_de_compras()
        cargar_logo()
        'dtp1.CustomFormat = "yyy-MM-dd"
        'dtp2.CustomFormat = "yyy-MM-dd"

        dtp1.CustomFormat = "MM-yyy"
        'dtp2.CustomFormat = "MM-yyy"


        calcular_totales()


        If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
            btn_cerrar_mes.Enabled = True
        Else
            btn_cerrar_mes.Enabled = False
        End If

        grilla_libro_compras.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub
    Sub cargar_libro_de_compras()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select codigo_folio, periodo_tributario,documento, DOCUMENTO, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, nombre_proveedor, libro_de_compras.rut_proveedor, exentas, neto, iva, total, fecha_vencimiento from libro_de_compras, proveedores where periodo_tributario ='" & (dtp1.Text) & "' AND proveedores.rut_proveedor=libro_de_compras.rut_proveedor"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("codigo_folio", "FOLIO")
        grilla_libro_compras.Columns.Add("periodo_tributario", "PERIODO")
        grilla_libro_compras.Columns.Add("documento", "DOCUMENTO")
        grilla_libro_compras.Columns.Add("_tipo_documento", "TIPO")
        grilla_libro_compras.Columns.Add("fecha_factura", "EMISION")
        grilla_libro_compras.Columns.Add("nro_factura", "NRO.")
        grilla_libro_compras.Columns.Add("clasificacion_cuenta", "CUENTA")
        grilla_libro_compras.Columns.Add("nombre_proveedor", "PROVEEDOR")
        grilla_libro_compras.Columns.Add("rut_proveedor", "RUT")
        grilla_libro_compras.Columns.Add("exentas", "EXENTAS")
        grilla_libro_compras.Columns.Add("neto", "NETO")
        grilla_libro_compras.Columns.Add("iva", "IVA")
        grilla_libro_compras.Columns.Add("total", "TOTAL")
        grilla_libro_compras.Columns.Add("fecha_vencimiento", "VENCIMIENTO")
        'Form_libro_de_compras.grilla_libro_compras.Columns(13).Visible = False
        grilla_libro_compras.Columns(0).Visible = True
        grilla_libro_compras.Columns(1).Visible = True
        grilla_libro_compras.Columns(2).Visible = True
        grilla_libro_compras.Columns(3).Visible = True
        grilla_libro_compras.Columns(4).Visible = True
        grilla_libro_compras.Columns(5).Visible = True
        grilla_libro_compras.Columns(6).Visible = True
        grilla_libro_compras.Columns(7).Visible = True
        grilla_libro_compras.Columns(8).Visible = True
        grilla_libro_compras.Columns(9).Visible = True
        grilla_libro_compras.Columns(10).Visible = True
        grilla_libro_compras.Columns(11).Visible = True
        grilla_libro_compras.Columns(12).Visible = True
        grilla_libro_compras.Columns(13).Visible = False

        'Form_libro_de_compras.grilla_libro_compras.Columns(0).Width = 85

        Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_folio"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("periodo_tributario"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("documento"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("tipo_documento"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("fecha_factura"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("nro_factura"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("clasificacion_cuenta"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("exentas"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento"))
                'DS.Tables(DT.TableName).Rows(i).Item("costo"))
            Next
        End If






        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
        End If



        grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_libro_compras.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Sub calcular_totales()
        Dim exentogrilla As Long
        Dim netogrilla As Long
        Dim ivagrilla As Long
        Dim totalgrilla As Long


        '//Calcular el exento
        txt_exentas_total.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            exentogrilla = Val(grilla_libro_compras.Rows(i).Cells(9).Value.ToString)
            txt_exentas_total.Text = Val(txt_exentas_total.Text) + Val(exentogrilla)
        Next

        '//Calcular el total neto
        txt_neto_total.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            netogrilla = Val(grilla_libro_compras.Rows(i).Cells(10).Value.ToString)
            txt_neto_total.Text = Val(txt_neto_total.Text) + Val(netogrilla)
        Next

        '//Calcular el total iva
        txt_iva_total.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            ivagrilla = Val(grilla_libro_compras.Rows(i).Cells(11).Value.ToString)
            txt_iva_total.Text = Val(txt_iva_total.Text) + Val(ivagrilla)
        Next

        '//Calcular el total general

        txt_total_general.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            totalgrilla = Val(grilla_libro_compras.Rows(i).Cells(12).Value.ToString)
            txt_total_general.Text = Val(txt_total_general.Text) + Val(totalgrilla)
        Next




        If txt_exentas_total.Text = "" Or txt_exentas_total.Text = "0" Then
            txt_exentas_total_millar.Text = "0"
        Else
            txt_exentas_total_millar.Text = Format(Int(txt_exentas_total.Text), "###,###,###")
        End If



        If txt_neto_total.Text = "" Or txt_neto_total.Text = "0" Then
            txt_neto_total_millar.Text = "0"
        Else
            txt_neto_total_millar.Text = Format(Int(txt_neto_total.Text), "###,###,###")
        End If



        If txt_iva_total.Text = "" Or txt_iva_total.Text = "0" Then
            txt_iva_total_millar.Text = "0"
        Else
            txt_iva_total_millar.Text = Format(Int(txt_iva_total.Text), "###,###,###")
        End If


        If txt_total_general.Text = "" Or txt_total_general.Text = "0" Then
            txt_total_general_millar.Text = "0"
        Else
            txt_total_general_millar.Text = Format(Int(txt_total_general.Text), "###,###,###")
        End If
    End Sub

    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp1.ValueChanged
        limpiar()
    End Sub

    Private Sub dtp2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cargar_libro_de_compras()
        calcular_totales()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click


        If grilla_libro_compras.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            dtp1.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = True
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = True
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True


        'lbl_mensaje.Visible = True
        'Me.Enabled = False

        'grabar_libro_de_compras()
        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'SC.Connection = conexion
        'SC.CommandText = "select * from libro_de_compras_temporal, empresa"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'Dim rpt As New Crystal_libro_de_compra
        'rpt.SetDataSource(DS.Tables(DT.TableName))
        'Form_informe_libro_de_compras_temporal.rpt_libro_de_compras_temporal.ReportSource = rpt
        'Form_informe_libro_de_compras_temporal.Show()
        'conexion.Close()

        'lbl_mensaje.Visible = False
        'Me.Enabled = True


    End Sub

    Sub grabar_libro_de_compras()

        Dim folio As String
        Dim periodo_tributario As String
        Dim documento As String
        Dim tipo_documento As String
        Dim fecha_factura As String
        Dim numero_factura As String
        Dim clasificacion_cuenta As String
        Dim proveedor As String
        Dim rut_proveedor As String
        Dim exentas As String
        Dim neto As String
        Dim iva As String
        Dim total As String


        SC.Connection = conexion
        SC.CommandText = "delete from libro_de_compras_temporal"
        DA.SelectCommand = SC
        DA.Fill(DT)


        For i = 0 To grilla_libro_compras.Rows.Count - 1
            folio = grilla_libro_compras.Rows(i).Cells(0).Value.ToString
            periodo_tributario = grilla_libro_compras.Rows(i).Cells(1).Value.ToString
            documento = grilla_libro_compras.Rows(i).Cells(2).Value.ToString
            tipo_documento = grilla_libro_compras.Rows(i).Cells(3).Value.ToString
            fecha_factura = grilla_libro_compras.Rows(i).Cells(4).Value.ToString
            numero_factura = grilla_libro_compras.Rows(i).Cells(5).Value.ToString
            clasificacion_cuenta = grilla_libro_compras.Rows(i).Cells(6).Value.ToString
            proveedor = grilla_libro_compras.Rows(i).Cells(7).Value.ToString
            rut_proveedor = grilla_libro_compras.Rows(i).Cells(8).Value.ToString
            exentas = grilla_libro_compras.Rows(i).Cells(9).Value.ToString
            neto = grilla_libro_compras.Rows(i).Cells(10).Value.ToString
            iva = grilla_libro_compras.Rows(i).Cells(11).Value.ToString
            total = grilla_libro_compras.Rows(i).Cells(12).Value.ToString

            If exentas = "" Then
                exentas = 0
            End If

            If neto = "" Then
                neto = 0
            End If

            If iva = "" Then
                iva = 0
            End If

            If total = "" Then
                total = 0
            End If
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "insert into libro_de_compras_temporal (folio, periodo_tributario, documento, tipo_documento, fecha_factura, numero_factura, clasificacion_cuenta, proveedor, rut_proveedor, exentas, neto, iva, total,desde, hasta, total_exento, total_neto, total_iva, total_final) values('" & (folio) & "', '" & (periodo_tributario) & "', '" & (documento) & "', '" & (tipo_documento) & "', '" & (fecha_factura) & "', '" & (numero_factura) & "', '" & (clasificacion_cuenta) & "', '" & (proveedor) & "', '" & (rut_proveedor) & "', '" & (exentas) & "', '" & (neto) & "', '" & (iva) & "', '" & (total) & "', '" & (dtp1.Text) & "', '" & (dtp1.Text) & "', '" & (txt_exentas_total.Text) & "', '" & (txt_neto_total.Text) & "', '" & (txt_iva_total.Text) & "', '" & (txt_total_general.Text) & "')"
            'SC.CommandText = "insert into libro_de_compras_temporal (                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      valor_neto_de_documentos_electronicos,                    existencias,                         activo_fijo,                            gastos_generales,                      total_neto,                     factura_de_compra_cantidad,                     factura_de_compra_exento,                      factura_de_compra_neto,                     factura_de_compra_iva,                    factura_de_compra_total,                     factura_de_activo_fijo_cantidad,                        factura_de_activo_fijo_exento,                  factura_de_activo_fijo_neto,                        factura_de_activo_fijo_iva,                 factura_de_activo_fijo_total,                           factura_de_gastos_generales_cantidad,                       factura_de_gastos_generales_exento,                 factura_de_gastos_generales_neto,                   factura_de_gastos_generales_iba,                    factura_de_gastos_generales_total,                   nota_de_debito_cantidad,                   nota_de_debito_exento,                          nota_de_debito_neto,                        nota_de_debito_iva,                     nota_de_debito_total,                    nota_de_credito_cantidad,                   nota_de_credito_exento,                    nota_de_credito_neto,                   nota_de_credito_iva,                        nota_de_credito_total) values('" & (txt_total_documentos_electronicos_neto.Text) & "','" & (txt_total_existencias.Text) & "','" & (txt_total_activo_fijo.Text) & "'," & (txt_total_gastos_generales.Text) & ",'" & (txt_total_neto.Text) & "','" & (txt_factura_de_compra_cantidad.Text) & "','" & (txt_factura_de_compra_exento.Text) & "','" & (txt_factura_de_compra_neto.Text) & "'," & (txt_factura_de_compra_iva.Text) & ",'" & (0) & "','" & (txt_factura_de_compra_total.Text) & "'," & (txt_factura_de_activo_fijo_cantidad.Text) & ",'" & (txt_factura_de_activo_fijo_exento.Text) & "','" & (txt_factura_de_activo_fijo_neto.Text) & "','" & (txt_factura_de_activo_fijo_iva.Text) & "','" & (txt_factura_de_activo_fijo_total.Text) & "','" & (txt_factura_de_gastos_generales_cantidad.Text) & "','" & (txt_factura_de_gastos_generales_exento.Text) & "','" & (txt_factura_de_gastos_generales_neto.Text) & "','" & (txt_factura_de_gastos_generales_iva.Text) & "','" & (txt_factura_de_gastos_generales_total.Text) & "','" & (txt_nota_de_debito_cantidad.Text) & "','" & (txt_nota_de_debito_exento.Text) & "','" & (txt_nota_de_debito_neto.Text) & "','" & (txt_nota_de_debito_iva.Text) & "','" & (txt_nota_de_debito_total.Text) & "','" & (txt_nota_de_credito_cantidad.Text) & "','" & (txt_nota_de_credito_exento.Text) & "','" & (txt_nota_de_credito_neto.Text) & "','" & (txt_nota_de_credito_iva.Text) & "','" & (txt_nota_de_credito_total.Text) & "')"

            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click

        Dim mensaje As String = ""



        If grilla_libro_compras.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp1.Focus()
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

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub



    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub


    Sub limpiar()

        txt_exentas_total_millar.Text = ""
        txt_neto_total_millar.Text = ""
        txt_iva_total_millar.Text = ""
        txt_total_general_millar.Text = ""
        ' grilla_stock.DataSource = Nothing
        grilla_libro_compras.Rows.Clear()
        grilla_documentos.Rows.Clear()
    End Sub

    Private Sub btn_cerrar_mes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar_mes.Click
        Form_control_meses.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_cerrar_mes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cerrar_mes.GotFocus
        btn_cerrar_mes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cerrar_mes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cerrar_mes.LostFocus
        btn_cerrar_mes.BackColor = Color.Transparent
    End Sub

    Sub malla_resumen()
        Dim valor As String

        grilla_documentos.Rows.Clear()
        grilla_documentos.Rows.Add("CANTIDAD", "0", "0", "0", "0")
        grilla_documentos.Rows.Add("EXENTO", "0", "0", "0", "0")
        grilla_documentos.Rows.Add("NETO", "0", "0", "0", "0")
        grilla_documentos.Rows.Add("IVA", "0", "0", "0", "0")
        grilla_documentos.Rows.Add("TOTAL", "0", "0", "0", "0")

        'TOTAL FACTURAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='FACTURA'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(0).Cells(1).Value = valor
            Next
        End If

        'TOTAL NOTAS DE CREDITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='NOTA DE CREDITO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(0).Cells(2).Value = valor
            Next
        End If

        'TOTAL NOTAS DE DEBITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='NOTA DE DEBITO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(0).Cells(3).Value = valor
            Next
        End If

        'TOTAL DOCUMENTOS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(0).Cells(4).Value = valor
            Next
        End If




        'EXENTAS
        'EXENTAS FACTURAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(exentas) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='FACTURA'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(1).Cells(1).Value = valor
            Next
        End If

        'EXENTAS NOTAS DE CREDITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(exentas) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='NOTA DE CREDITO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(1).Cells(2).Value = valor
            Next
        End If

        'EXENTAS NOTAS DE DEBITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(exentas) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='NOTA DE DEBITO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(1).Cells(3).Value = valor
            Next
        End If

        'EXENTAS TOTAL DOCUMENTOS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(exentas) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(1).Cells(4).Value = valor
            Next
        End If








        'NETO
        'NETO FACTURAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(neto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='FACTURA'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(2).Cells(1).Value = valor
            Next
        End If

        'NETO NOTAS DE CREDITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(neto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='NOTA DE CREDITO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(2).Cells(2).Value = valor
            Next
        End If

        'NETO NOTAS DE DEBITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(neto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='NOTA DE DEBITO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(2).Cells(3).Value = valor
            Next
        End If

        'NETO DOCUMENTOS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(neto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(2).Cells(4).Value = valor
            Next
        End If















        'IVA
        'IVA FACTURAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(iva) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='FACTURA'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(3).Cells(1).Value = valor
            Next
        End If

        'IVA NOTAS DE CREDITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(iva) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='NOTA DE CREDITO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(3).Cells(2).Value = valor
            Next
        End If

        'IVA NOTAS DE DEBITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(iva) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='NOTA DE DEBITO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(3).Cells(3).Value = valor
            Next
        End If

        'IVA DOCUMENTOS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(iva) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(3).Cells(4).Value = valor
            Next
        End If









        'TOTALES
        'TOTAL FACTURAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='FACTURA'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(4).Cells(1).Value = valor
            Next
        End If

        'TOTAL NOTAS DE CREDITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='NOTA DE CREDITO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(4).Cells(2).Value = valor
            Next
        End If

        'TOTAL NOTAS DE DEBITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND documento='NOTA DE DEBITO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(4).Cells(3).Value = valor
            Next
        End If

        'TOTAL DOCUMENTOS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                grilla_documentos.Rows(4).Cells(4).Value = valor
            Next
        End If
    End Sub





    Sub malla_resumen_clasificacion()
        Dim valor As String

        malla_clasificacion.Rows.Clear()
        malla_clasificacion.Rows.Add("CANTIDAD", "0", "0", "0", "0")
        malla_clasificacion.Rows.Add("EXENTO", "0", "0", "0", "0")
        malla_clasificacion.Rows.Add("NETO", "0", "0", "0", "0")
        malla_clasificacion.Rows.Add("IVA", "0", "0", "0", "0")
        malla_clasificacion.Rows.Add("TOTAL", "0", "0", "0", "0")

        'TOTAL ACTIVO FIJO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='ACTIVO FIJO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(0).Cells(1).Value = valor
            Next
        End If

        'TOTAL EXISTENCIAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='EXISTENCIAS'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(0).Cells(2).Value = valor
            Next
        End If

        'TOTAL GASTOS GENERALES
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='GASTOS GENERALES'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(0).Cells(3).Value = valor
            Next
        End If

        'TOTAL DOCUMENTOS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT count(cod_auto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(0).Cells(4).Value = valor
            Next
        End If




        'EXENTAS
        'EXENTAS ACTIVO FIJO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(exentas) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='ACTIVO FIJO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(1).Cells(1).Value = valor
            Next
        End If

        'EXENTAS EXISTENCIAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(exentas) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='EXISTENCIAS'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(1).Cells(2).Value = valor
            Next
        End If

        'EXENTAS GASTOS GENERALES
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(exentas) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='GASTOS GENERALES'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(1).Cells(3).Value = valor
            Next
        End If

        'EXENTAS TOTAL DOCUMENTOS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(exentas) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(1).Cells(4).Value = valor
            Next
        End If








        'NETO
        'NETO ACTIVO FIJO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(neto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='ACTIVO FIJO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(2).Cells(1).Value = valor
            Next
        End If

        'NETO EXISTENCIAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(neto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='EXISTENCIAS'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(2).Cells(2).Value = valor
            Next
        End If

        'NETO GASTOS GENERALES
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(neto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='GASTOS GENERALES'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(2).Cells(3).Value = valor
            Next
        End If

        'NETO DOCUMENTOS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(neto) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(2).Cells(4).Value = valor
            Next
        End If















        'IVA
        'IVA ACTIVO FIJO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(iva) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='ACTIVO FIJO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(3).Cells(1).Value = valor
            Next
        End If

        'IVA EXISTENCIAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(iva) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='EXISTENCIAS'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(3).Cells(2).Value = valor
            Next
        End If

        'IVA GASTOS GENERALES
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(iva) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='GASTOS GENERALES'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(3).Cells(3).Value = valor
            Next
        End If

        'IVA DOCUMENTOS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(iva) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(3).Cells(4).Value = valor
            Next
        End If









        'TOTALES
        'TOTAL ACTIVO FIJO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='ACTIVO FIJO'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(4).Cells(1).Value = valor
            Next
        End If

        'TOTAL EXISTENCIAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='EXISTENCIAS'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(4).Cells(2).Value = valor
            Next
        End If

        'TOTAL GASTOS GENERALES
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "' AND clasificacion_cuenta='GASTOS GENERALES'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(4).Cells(3).Value = valor
            Next
        End If

        'TOTAL DOCUMENTOS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT sum(total) as valor FROM `libro_de_compras` WHERE periodo_tributario='" & (dtp1.Text) & "'"
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

                If valor = "" Or valor = "0" Then
                    valor = "0"
                Else
                    valor = Format(Int(valor), "###,###,###")
                End If

                malla_clasificacion.Rows(4).Cells(4).Value = valor
            Next
        End If
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

    '    dt.Columns.Add(New DataColumn("DataColumn38", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn39", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn40", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn41", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn42", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn43", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn44", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn45", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn46", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn47", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn48", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn49", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn50", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn51", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn52", GetType(String)))

    '    Dim DataColumn0 As String
    '    Dim DataColumn1 As String
    '    Dim DataColumn2 As String
    '    Dim DataColumn3 As String
    '    Dim DataColumn4 As String
    '    Dim DataColumn5 As String
    '    Dim DataColumn6 As String
    '    Dim DataColumn7 As String
    '    Dim DataColumn8 As String
    '    Dim DataColumn9 As String
    '    Dim DataColumn10 As String
    '    Dim DataColumn11 As String
    '    Dim DataColumn12 As String
    '    Dim DataColumn13 As String
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
    '    'Dim DataColumn29 As String
    '    'Dim DataColumn30 As String

    '    For i = 0 To grilla_libro_compras.Rows.Count - 1
    '        DataColumn0 = grilla_libro_compras.Rows(i).Cells(0).Value.ToString
    '        DataColumn1 = grilla_libro_compras.Rows(i).Cells(1).Value.ToString
    '        DataColumn2 = grilla_libro_compras.Rows(i).Cells(2).Value.ToString
    '        DataColumn3 = grilla_libro_compras.Rows(i).Cells(3).Value.ToString
    '        DataColumn4 = grilla_libro_compras.Rows(i).Cells(4).Value.ToString
    '        DataColumn5 = grilla_libro_compras.Rows(i).Cells(5).Value.ToString
    '        DataColumn6 = grilla_libro_compras.Rows(i).Cells(6).Value.ToString
    '        DataColumn7 = grilla_libro_compras.Rows(i).Cells(7).Value.ToString
    '        DataColumn8 = grilla_libro_compras.Rows(i).Cells(8).Value.ToString
    '        DataColumn9 = grilla_libro_compras.Rows(i).Cells(9).Value.ToString
    '        DataColumn10 = grilla_libro_compras.Rows(i).Cells(10).Value.ToString
    '        DataColumn11 = grilla_libro_compras.Rows(i).Cells(11).Value.ToString
    '        DataColumn12 = grilla_libro_compras.Rows(i).Cells(12).Value.ToString
    '        DataColumn13 = grilla_libro_compras.Rows(i).Cells(13).Value.ToString

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
    '            dr("DataColumn0") = DataColumn0
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
    '            dr("DataColumn9") = DataColumn9
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn10") = DataColumn10
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn11") = DataColumn11
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn12") = DataColumn12
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn13") = DataColumn13
    '        Catch
    '        End Try





    '        Try
    '            dr("DataColumn13") = grilla_documentos.Rows(0).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn14") = grilla_documentos.Rows(0).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn15") = grilla_documentos.Rows(0).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn16") = grilla_documentos.Rows(0).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn17") = grilla_documentos.Rows(1).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn18") = grilla_documentos.Rows(1).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn19") = grilla_documentos.Rows(1).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn20") = grilla_documentos.Rows(1).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn21") = grilla_documentos.Rows(2).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn22") = grilla_documentos.Rows(2).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn23") = grilla_documentos.Rows(2).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn24") = grilla_documentos.Rows(2).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn25") = grilla_documentos.Rows(3).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn26") = grilla_documentos.Rows(3).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn27") = grilla_documentos.Rows(3).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn28") = grilla_documentos.Rows(3).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn29") = grilla_documentos.Rows(4).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn30") = grilla_documentos.Rows(4).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn31") = grilla_documentos.Rows(4).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn32") = grilla_documentos.Rows(4).Cells(4).Value
    '        Catch
    '        End Try







    '        Try
    '            dr("DataColumn33") = malla_clasificacion.Rows(0).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn34") = malla_clasificacion.Rows(0).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn35") = malla_clasificacion.Rows(0).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn36") = malla_clasificacion.Rows(0).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn37") = malla_clasificacion.Rows(1).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn38") = malla_clasificacion.Rows(1).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn39") = malla_clasificacion.Rows(1).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn40") = malla_clasificacion.Rows(1).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn41") = malla_clasificacion.Rows(2).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn42") = malla_clasificacion.Rows(2).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn43") = malla_clasificacion.Rows(2).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn44") = malla_clasificacion.Rows(2).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn45") = malla_clasificacion.Rows(3).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn46") = malla_clasificacion.Rows(3).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn47") = malla_clasificacion.Rows(3).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn48") = malla_clasificacion.Rows(3).Cells(4).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn49") = malla_clasificacion.Rows(4).Cells(1).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn50") = malla_clasificacion.Rows(4).Cells(2).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn51") = malla_clasificacion.Rows(4).Cells(3).Value
    '        Catch
    '        End Try
    '        Try
    '            dr("DataColumn52") = malla_clasificacion.Rows(4).Cells(4).Value
    '        Catch
    '        End Try











    '        dr("fechas") = "PERIODO TRIBUTARIO " & dtp1.Text
    '        dr("titulo") = "LIBRO DE COMPRAS (" & mirecintoempresa & ")"


    '        dt.Rows.Add(dr)
    '    Next

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "DS_reporte"

    '    Dim iDS As New DS_reporte
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        cargar_libro_de_compras()
        malla_resumen_clasificacion()
        malla_resumen()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
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
            Dim posicion_imagen As New PointF(margen_izquierdo + 840, margen_superior + 10)
            e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 65, margen_izquierdo + 1100, margen_superior + 55)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 80, margen_izquierdo + 1100, margen_superior + 70)

        e.Graphics.DrawString("LIBRO DE COMPRAS", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 103, margen_izquierdo + 1120, margen_superior + 103)
        e.Graphics.DrawString("PERIODO TRIBUTARIO " & dtp1.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        e.Graphics.DrawString("FOLIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 130)
        e.Graphics.DrawString("P. TRIB.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 100, margen_superior + 130)
        e.Graphics.DrawString("DOC", Font_titulo_columna, Brushes.Black, margen_izquierdo + 160, margen_superior + 130)
        e.Graphics.DrawString("TIPO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 260, margen_superior + 130)
        e.Graphics.DrawString("FECHA DOC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 340, margen_superior + 130)
        e.Graphics.DrawString("NRO. DOC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 410, margen_superior + 130)
        e.Graphics.DrawString("CLASIFICACION", Font_titulo_columna, Brushes.Black, margen_izquierdo + 480, margen_superior + 130)
        e.Graphics.DrawString("NOMBRE PROV.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 600, margen_superior + 130)
        e.Graphics.DrawString("RUT PROV.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 765, margen_superior + 130)
        e.Graphics.DrawString("EXENTO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 890, margen_superior + 130, format1)
        e.Graphics.DrawString("NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 960, margen_superior + 130, format1)
        e.Graphics.DrawString("IVA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 1030, margen_superior + 130, format1)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 1100, margen_superior + 130, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 145, margen_izquierdo + 1120, margen_superior + 145)

        Dim folio As String
        Dim periodo As String
        Dim documento As String
        Dim tipo_doc As String
        Dim fecha_doc As String
        Dim nro_doc As String
        Dim clasificacion As String
        Dim nombre_prov As String
        Dim rut_prov As String
        Dim excento As String
        Dim neto As String
        Dim iva As String
        Dim total As String
        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10

        For i = numero_lineas_total To grilla_libro_compras.Rows.Count - 1
            folio = grilla_libro_compras.Rows(i).Cells(0).Value.ToString
            periodo = grilla_libro_compras.Rows(i).Cells(1).Value.ToString
            documento = grilla_libro_compras.Rows(i).Cells(2).Value.ToString
            tipo_doc = grilla_libro_compras.Rows(i).Cells(3).Value.ToString
            fecha_doc = grilla_libro_compras.Rows(i).Cells(4).Value.ToString
            nro_doc = grilla_libro_compras.Rows(i).Cells(5).Value.ToString
            clasificacion = grilla_libro_compras.Rows(i).Cells(6).Value.ToString
            nombre_prov = grilla_libro_compras.Rows(i).Cells(7).Value.ToString
            rut_prov = grilla_libro_compras.Rows(i).Cells(8).Value.ToString
            excento = grilla_libro_compras.Rows(i).Cells(9).Value.ToString
            neto = grilla_libro_compras.Rows(i).Cells(10).Value.ToString
            iva = grilla_libro_compras.Rows(i).Cells(11).Value.ToString
            total = grilla_libro_compras.Rows(i).Cells(12).Value.ToString

            If excento = "" Or excento = "0" Then
                excento = "0"
            Else
                excento = Format(Int(excento), "###,###,###")
            End If

            If neto = "" Or neto = "0" Then
                neto = "0"
            Else
                neto = Format(Int(neto), "###,###,###")
            End If

            If iva = "" Or iva = "0" Then
                iva = "0"
            Else
                iva = Format(Int(iva), "###,###,###")
            End If

            If total = "" Or total = "0" Then
                total = "0"
            Else
                total = Format(Int(total), "###,###,###")
            End If

            If fecha_doc.Length > 10 Then
                fecha_doc = fecha_doc.Substring(0, 10)
            End If

            If nombre_prov.Length > 25 Then
                nombre_prov = nombre_prov.Substring(0, 25)
            End If

            e.Graphics.DrawString(folio, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 150 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(periodo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 100, margen_superior + 150 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(documento, Font_texto_impresion, Brushes.Black, margen_izquierdo + 160, margen_superior + 150 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(tipo_doc, Font_texto_impresion, Brushes.Black, margen_izquierdo + 260, margen_superior + 150 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(fecha_doc, Font_texto_impresion, Brushes.Black, margen_izquierdo + 340, margen_superior + 150 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(nro_doc, Font_texto_impresion, Brushes.Black, margen_izquierdo + 410, margen_superior + 150 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(clasificacion, Font_texto_impresion, Brushes.Black, margen_izquierdo + 480, margen_superior + 150 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(nombre_prov, Font_texto_impresion, Brushes.Black, margen_izquierdo + 600, margen_superior + 150 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(rut_prov, Font_texto_impresion, Brushes.Black, margen_izquierdo + 765, margen_superior + 150 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(excento, Font_texto_impresion, Brushes.Black, margen_izquierdo + 890, margen_superior + 150 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(neto, Font_texto_impresion, Brushes.Black, margen_izquierdo + 960, margen_superior + 150 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(iva, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1030, margen_superior + 150 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(total, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1100, margen_superior + 150 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 64 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 155 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 1120, margen_superior + 155 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 155 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 1120, margen_superior + 155 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0

        Dim clasificacion_cantidad_1 As String
        Dim clasificacion_cantidad_2 As String
        Dim clasificacion_cantidad_3 As String
        Dim clasificacion_cantidad_4 As String

        Dim clasificacion_exento_1 As String
        Dim clasificacion_exento_2 As String
        Dim clasificacion_exento_3 As String
        Dim clasificacion_exento_4 As String

        Dim clasificacion_neto_1 As String
        Dim clasificacion_neto_2 As String
        Dim clasificacion_neto_3 As String
        Dim clasificacion_neto_4 As String

        Dim clasificacion_iva_1 As String
        Dim clasificacion_iva_2 As String
        Dim clasificacion_iva_3 As String
        Dim clasificacion_iva_4 As String

        Dim clasificacion_total_1 As String
        Dim clasificacion_total_2 As String
        Dim clasificacion_total_3 As String
        Dim clasificacion_total_4 As String

        clasificacion_cantidad_1 = malla_clasificacion.Rows(0).Cells(1).Value
        clasificacion_cantidad_2 = malla_clasificacion.Rows(0).Cells(2).Value
        clasificacion_cantidad_3 = malla_clasificacion.Rows(0).Cells(3).Value
        clasificacion_cantidad_4 = malla_clasificacion.Rows(0).Cells(4).Value

        clasificacion_exento_1 = malla_clasificacion.Rows(1).Cells(1).Value
        clasificacion_exento_2 = malla_clasificacion.Rows(1).Cells(2).Value
        clasificacion_exento_3 = malla_clasificacion.Rows(1).Cells(3).Value
        clasificacion_exento_4 = malla_clasificacion.Rows(1).Cells(4).Value

        clasificacion_neto_1 = malla_clasificacion.Rows(2).Cells(1).Value
        clasificacion_neto_2 = malla_clasificacion.Rows(2).Cells(2).Value
        clasificacion_neto_3 = malla_clasificacion.Rows(2).Cells(3).Value
        clasificacion_neto_4 = malla_clasificacion.Rows(2).Cells(4).Value

        clasificacion_iva_1 = malla_clasificacion.Rows(3).Cells(1).Value
        clasificacion_iva_2 = malla_clasificacion.Rows(3).Cells(2).Value
        clasificacion_iva_3 = malla_clasificacion.Rows(3).Cells(3).Value
        clasificacion_iva_4 = malla_clasificacion.Rows(3).Cells(4).Value

        clasificacion_total_1 = malla_clasificacion.Rows(4).Cells(1).Value
        clasificacion_total_2 = malla_clasificacion.Rows(4).Cells(2).Value
        clasificacion_total_3 = malla_clasificacion.Rows(4).Cells(3).Value
        clasificacion_total_4 = malla_clasificacion.Rows(4).Cells(4).Value

        e.Graphics.DrawString("ACT. FIJO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 200, margen_superior + 190 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString("EXISTENCIAS", Font_titulo_columna, Brushes.Black, margen_izquierdo + 300, margen_superior + 190 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString("G. GENERALES", Font_titulo_columna, Brushes.Black, margen_izquierdo + 400, margen_superior + 190 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 500, margen_superior + 190 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 205 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 510, margen_superior + 205 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 210 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("EXENTO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 225 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("IVA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 255 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 270 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString(clasificacion_cantidad_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 200, margen_superior + 210 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_cantidad_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 300, margen_superior + 210 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_cantidad_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 400, margen_superior + 210 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_cantidad_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 500, margen_superior + 210 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(clasificacion_exento_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 200, margen_superior + 225 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_exento_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 300, margen_superior + 225 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_exento_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 400, margen_superior + 225 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_exento_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 500, margen_superior + 225 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(clasificacion_neto_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 200, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_neto_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 300, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_neto_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 400, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_neto_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 500, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(clasificacion_iva_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 200, margen_superior + 255 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_iva_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 300, margen_superior + 255 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_iva_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 400, margen_superior + 255 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_iva_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 500, margen_superior + 255 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(clasificacion_total_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 200, margen_superior + 270 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_total_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 300, margen_superior + 270 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_total_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 400, margen_superior + 270 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(clasificacion_total_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 500, margen_superior + 270 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 285 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 510, margen_superior + 285 + (numero_lineas * multiplicador_lineas))


        '***************************************************************************************************************************************************
        Dim documentos_cantidad_1 As String
        Dim documentos_cantidad_2 As String
        Dim documentos_cantidad_3 As String
        Dim documentos_cantidad_4 As String

        Dim documentos_exento_1 As String
        Dim documentos_exento_2 As String
        Dim documentos_exento_3 As String
        Dim documentos_exento_4 As String

        Dim documentos_neto_1 As String
        Dim documentos_neto_2 As String
        Dim documentos_neto_3 As String
        Dim documentos_neto_4 As String

        Dim documentos_iva_1 As String
        Dim documentos_iva_2 As String
        Dim documentos_iva_3 As String
        Dim documentos_iva_4 As String

        Dim documentos_total_1 As String
        Dim documentos_total_2 As String
        Dim documentos_total_3 As String
        Dim documentos_total_4 As String

        documentos_cantidad_1 = grilla_documentos.Rows(0).Cells(1).Value
        documentos_cantidad_2 = grilla_documentos.Rows(0).Cells(2).Value
        documentos_cantidad_3 = grilla_documentos.Rows(0).Cells(3).Value
        documentos_cantidad_4 = grilla_documentos.Rows(0).Cells(4).Value

        documentos_exento_1 = grilla_documentos.Rows(1).Cells(1).Value
        documentos_exento_2 = grilla_documentos.Rows(1).Cells(2).Value
        documentos_exento_3 = grilla_documentos.Rows(1).Cells(3).Value
        documentos_exento_4 = grilla_documentos.Rows(1).Cells(4).Value

        documentos_neto_1 = grilla_documentos.Rows(2).Cells(1).Value
        documentos_neto_2 = grilla_documentos.Rows(2).Cells(2).Value
        documentos_neto_3 = grilla_documentos.Rows(2).Cells(3).Value
        documentos_neto_4 = grilla_documentos.Rows(2).Cells(4).Value

        documentos_iva_1 = grilla_documentos.Rows(3).Cells(1).Value
        documentos_iva_2 = grilla_documentos.Rows(3).Cells(2).Value
        documentos_iva_3 = grilla_documentos.Rows(3).Cells(3).Value
        documentos_iva_4 = grilla_documentos.Rows(3).Cells(4).Value

        documentos_total_1 = grilla_documentos.Rows(4).Cells(1).Value
        documentos_total_2 = grilla_documentos.Rows(4).Cells(2).Value
        documentos_total_3 = grilla_documentos.Rows(4).Cells(3).Value
        documentos_total_4 = grilla_documentos.Rows(4).Cells(4).Value

        e.Graphics.DrawString("FACTURAS", Font_titulo_columna, Brushes.Black, margen_izquierdo + 800, margen_superior + 190 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString("NOTAS DE CRED.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 900, margen_superior + 190 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString("NOTAS DE DEB.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 1000, margen_superior + 190 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 1100, margen_superior + 190 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 640, margen_superior + 205 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 1120, margen_superior + 205 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 650, margen_superior + 210 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("EXENTO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 650, margen_superior + 225 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("NETO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 650, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("IVA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 650, margen_superior + 255 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 650, margen_superior + 270 + (numero_lineas * multiplicador_lineas))

        e.Graphics.DrawString(documentos_cantidad_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 800, margen_superior + 210 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_cantidad_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 900, margen_superior + 210 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_cantidad_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1000, margen_superior + 210 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_cantidad_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1100, margen_superior + 210 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(documentos_exento_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 800, margen_superior + 225 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_exento_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 900, margen_superior + 225 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_exento_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1000, margen_superior + 225 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_exento_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1100, margen_superior + 225 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(documentos_neto_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 800, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_neto_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 900, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_neto_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1000, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_neto_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1100, margen_superior + 240 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(documentos_iva_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 800, margen_superior + 255 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_iva_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 900, margen_superior + 255 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_iva_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1000, margen_superior + 255 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_iva_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1100, margen_superior + 255 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString(documentos_total_1, Font_texto_impresion, Brushes.Black, margen_izquierdo + 800, margen_superior + 270 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_total_2, Font_texto_impresion, Brushes.Black, margen_izquierdo + 900, margen_superior + 270 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_total_3, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1000, margen_superior + 270 + (numero_lineas * multiplicador_lineas), format1)
        e.Graphics.DrawString(documentos_total_4, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1100, margen_superior + 270 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 640, margen_superior + 285 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 1120, margen_superior + 285 + (numero_lineas * multiplicador_lineas))

    End Sub
End Class