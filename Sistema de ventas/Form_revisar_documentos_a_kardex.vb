Imports System.Math
Public Class Form_revisar_documentos_a_kardex
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim NroDocKardex As String
    Dim TipoDocKardex As String
    Dim Rut_proveedor As String

    Private Sub Form_revisar_kardex_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_revisar_kardex_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_revisar_kardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        combo_venta.SelectedItem = "-"
        mostrar_documentos_faltantes()
        txt_total_documentos.Text = grilla_documentos_faltantes.Rows.Count
        grilla_documentos.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        grilla_documentos_faltantes.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub mostrar_documentos()
        If combo_venta.Text = "COMPRA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from compra where usuario_responsable <> 'SISTEMA' and estado <> 'AJUSTE' and fecha_emision >='" & (mifecha2) & "' and fecha_emision <= '" & (mifecha4) & "' order by n_compra asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_emision")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_compra"), _
                                                 mifecha_emision2, _
                                                  DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("estado"))
                Next
            End If
        End If

        If combo_venta.Text = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from boleta where usuario_responsable <> 'SISTEMA' and estado <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' order by n_boleta asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("BOLETA", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_boleta"), _
                                                 mifecha_emision2, _
                                                  DS.Tables(DT.TableName).Rows(i).Item("usuario_responsable"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("estado"))
                Next
            End If
        End If

        If combo_venta.Text = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from guia where tipo <> 'GUIA DE GARANTIA' and usuario_responsable <> 'SISTEMA' and estado <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' order by n_guia asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("GUIA", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_guia"), _
                                                 mifecha_emision2, _
                                                  DS.Tables(DT.TableName).Rows(i).Item("usuario_responsable"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("estado"))
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
            SC.CommandText = "select * from factura where usuario_responsable <> 'SISTEMA' and estado <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' order by n_factura asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("FACTURA", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_factura"), _
                                                 mifecha_emision2, _
                                                  DS.Tables(DT.TableName).Rows(i).Item("usuario_responsable"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("estado"))
                Next
            End If
        End If

        If combo_venta.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from nota_credito where usuario_responsable <> 'SISTEMA' and estado <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' order by n_nota_credito asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("NOTA DE CREDITO", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_nota_credito"), _
                                                 mifecha_emision2, _
                                                  DS.Tables(DT.TableName).Rows(i).Item("usuario_responsable"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("estado"))
                Next
            End If
        End If

        If combo_venta.Text = "NOTA DE DEBITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from nota_debito where usuario_responsable <> 'SISTEMA' and estado <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' order by n_nota_debito asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("NOTA DE DEBITO", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_nota_debito"), _
                                                 mifecha_emision2, _
                                                  DS.Tables(DT.TableName).Rows(i).Item("usuario_responsable"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("estado"))
                Next
            End If
        End If
        grilla_documentos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documentos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documentos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documentos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documentos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If grilla_documentos.Rows.Count <> 0 Then
            If grilla_documentos.Columns(0).Width = 80 Then
                grilla_documentos.Columns(0).Width = 79
            Else
                grilla_documentos.Columns(0).Width = 80
            End If
        End If

        txt_total_documentos.Text = grilla_documentos.Rows.Count
    End Sub

    Sub mostrar_documentos_faltantes()
        grilla_documentos_faltantes.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from documentos_faltantes where usuario_responsable <> 'SISTEMA' and estado <> 'AJUSTE' order by tipo, numero asc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim MiFechaEmision As Date
                Dim mifecha_emision2 As String
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                grilla_documentos_faltantes.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("numero"), _
                                                       mifecha_emision2, _
                                                        DS.Tables(DT.TableName).Rows(i).Item("usuario_responsable"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("estado"))
            Next
        End If

        grilla_documentos_faltantes.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documentos_faltantes.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documentos_faltantes.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documentos_faltantes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documentos_faltantes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If grilla_documentos_faltantes.Rows.Count <> 0 Then
            If grilla_documentos_faltantes.Columns(0).Width = 80 Then
                grilla_documentos_faltantes.Columns(0).Width = 79
            Else
                grilla_documentos_faltantes.Columns(0).Width = 80
            End If
        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If combo_venta.Text = "" Then
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_venta.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        fecha()
        mostrar_documentos()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_documentos_faltantes.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            'dtp_desde.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_documentos_faltantes, save.FileName)
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
        For c As Integer = 0 To grilla_documentos_faltantes.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_documentos_faltantes.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_documentos_faltantes.RowCount - 1
            For c As Integer = 0 To grilla_documentos_faltantes.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_documentos_faltantes.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub grilla_documentos_faltantes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documentos_faltantes.CellContentClick

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If grilla_documentos_faltantes.Rows.Count = 0 Then
            MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            'txt_codigo.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        mostrar_documentos_faltantes()

        grabar_detalle_documento_en_kardex()

        lbl_mensaje.Visible = False
        Me.Enabled = True

        MsgBox("DATOS INGRESADOS AL KARDEX CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

    End Sub


    Sub cargar_documento()
        'Dim nombre As String
        Dim total As String
        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String

        grilla_detalle_venta.Rows.Clear()


        If TipoDocKardex.Contains("COMPRA ") Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_compra where detalle_compra.n_compra='" & (NroDocKardex) & "' and detalle_compra.rut_proveedor='" & (Rut_proveedor) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    total = DS.Tables(DT.TableName).Rows(i).Item("total")
                    iva_valor = valor_iva / 100 + 1
                    neto = (total / iva_valor)
                    Round(neto)
                    iva = ((neto) * valor_iva / 100)
                    Round(iva)

                    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                    "-", _
                    DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                    neto, _
                    iva, _
                    DS.Tables(DT.TableName).Rows(i).Item("subtotal"), _
                    "0", _
                    "0", _
                    DS.Tables(DT.TableName).Rows(i).Item("total"))
                Next
            End If

        Else




            If TipoDocKardex = "BOLETA" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (NroDocKardex) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        iva_valor = valor_iva / 100 + 1
                        neto = (total / iva_valor)
                        Round(neto)
                        iva = ((neto) * valor_iva / 100)
                        Round(iva)

                        grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                        DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                        DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                        DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                        neto, _
                        iva, _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                        DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                    Next
                End If
            End If

            If TipoDocKardex = "FACTURA" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                SC.CommandText = "select * from detalle_factura where detalle_factura.n_factura='" & (NroDocKardex) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        iva_valor = valor_iva / 100 + 1
                        neto = (total / iva_valor)
                        Round(neto)
                        iva = ((neto) * valor_iva / 100)
                        Round(iva)

                        grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                        DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                        DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                        DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                        neto, _
                        iva, _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                        DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                    Next
                End If
            End If

            If TipoDocKardex = "GUIA" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                SC.CommandText = "select * from detalle_guia where detalle_guia.n_guia='" & (NroDocKardex) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        iva_valor = valor_iva / 100 + 1
                        neto = (total / iva_valor)
                        Round(neto)
                        iva = ((neto) * valor_iva / 100)
                        Round(iva)

                        grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                        DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                        DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                        DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                        neto, _
                        iva, _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                        DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                        DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                    Next
                End If
            End If
        End If
        grilla_detalle_venta.Columns(0).Width = 85
        grilla_detalle_venta.Columns(1).Width = 220
        grilla_detalle_venta.Columns(2).Width = 195
        grilla_detalle_venta.Columns(3).Width = 85
        grilla_detalle_venta.Columns(4).Width = 85
        grilla_detalle_venta.Columns(5).Width = 85
        grilla_detalle_venta.Columns(6).Width = 85
        grilla_detalle_venta.Columns(7).Width = 85
        grilla_detalle_venta.Columns(8).Width = 36
        grilla_detalle_venta.Columns(9).Width = 85
        grilla_detalle_venta.Columns(10).Width = 85
    End Sub

    Private Sub btn_revisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_revisar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        revisar_documentos()


        MsgBox("DATOS REVISADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Sub revisar_documentos()
        Dim tipo As String
        Dim numero As String
        Dim fecha_doc As String
        Dim responsable_doc As String
        Dim estado_doc As String

        For i = 0 To grilla_documentos.Rows.Count - 1
            tipo = grilla_documentos.Rows(i).Cells(0).Value.ToString
            numero = grilla_documentos.Rows(i).Cells(1).Value.ToString
            fecha_doc = grilla_documentos.Rows(i).Cells(2).Value.ToString
            responsable_doc = grilla_documentos.Rows(i).Cells(3).Value.ToString
            estado_doc = grilla_documentos.Rows(i).Cells(4).Value.ToString

            If combo_venta.Text <> "COMPRA" Then
                conexion.Close()
                Consultas_SQL("select * from detalle_total where n_total = '" & (numero) & "' and tipo like '" & ("%" & tipo & "%") & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Else

                    Dim mifecha As Date
                    mifecha = fecha_doc
                    fecha_doc = mifecha.ToString("yyy-MM-dd")

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `documentos_faltantes` (`tipo`, `numero`, `fecha`, `usuario_responsable`, `estado`) VALUES ('" & (tipo) & "', '" & (numero) & "', '" & (fecha_doc) & "', '" & (responsable_doc) & "', '" & (estado_doc) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    grilla_detalle_venta.Rows.Add(tipo, numero, fecha_doc, responsable_doc)
                End If
            Else
                conexion.Close()
                Consultas_SQL("select * from detalle_total where n_total = '" & (numero) & "' and rut_proveedor = '" & (responsable_doc) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Else

                    Dim mifecha As Date
                    mifecha = fecha_doc
                    fecha_doc = mifecha.ToString("yyy-MM-dd")

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `documentos_faltantes` (`tipo`, `numero`, `fecha`, `usuario_responsable`, `estado`) VALUES ('" & ("COMPRA " & tipo) & "', '" & (numero) & "', '" & (fecha_doc) & "', '" & (responsable_doc) & "', '" & (estado_doc) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    grilla_detalle_venta.Rows.Add(tipo, numero, fecha_doc, responsable_doc)
                End If
            End If
        Next
    End Sub

    Sub grabar_detalle_documento_en_kardex()
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

        Dim tipo As String
        Dim numero As String
        Dim fecha_doc As String
        Dim responsable_doc As String
        Dim estado_doc As String

        For u = 0 To grilla_documentos_faltantes.Rows.Count - 1
            tipo = grilla_documentos_faltantes.Rows(u).Cells(0).Value.ToString
            numero = grilla_documentos_faltantes.Rows(u).Cells(1).Value.ToString
            fecha_doc = grilla_documentos_faltantes.Rows(u).Cells(2).Value.ToString
            responsable_doc = grilla_documentos_faltantes.Rows(u).Cells(3).Value.ToString
            estado_doc = grilla_documentos_faltantes.Rows(u).Cells(4).Value.ToString

            TipoDocKardex = grilla_documentos_faltantes.Rows(u).Cells(0).Value.ToString
            NroDocKardex = grilla_documentos_faltantes.Rows(u).Cells(1).Value.ToString
            Rut_proveedor = grilla_documentos_faltantes.Rows(u).Cells(3).Value.ToString

            Dim mifecha As Date
            mifecha = fecha_doc
            fecha_doc = mifecha.ToString("yyy-MM-dd")


            If tipo.Contains("COMPRA ") Then

                If estado_doc <> "ANULADA" Then
                    estado_doc = "EMITIDA"
                End If

                'TipoDocKardex = Trim(Replace(TipoDocKardex, "COMPRA ", ""))
                tipo = Trim(Replace(tipo, "COMPRA ", ""))
                cargar_documento()
                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                    varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                    vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                    VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                    VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                    VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                    VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                    'VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                    VarSubtotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                    VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                    VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                    VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                    SC.Connection = conexion
                    SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado, rut_proveedor) values(" & (numero) & ",'" & (tipo) & "', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'ENTRA','" & (fecha_doc) & "', '" & (miusuario) & "', '" & (estado_doc) & "', '" & (responsable_doc) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Next
            Else
                cargar_documento()
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
                    SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (numero) & ",'" & (tipo) & "', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (fecha_doc) & "', '" & (responsable_doc) & "', '" & (estado_doc) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Next
            End If
        Next
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        grilla_detalle_venta.Rows.Clear()
        grilla_documentos.Rows.Clear()
        grilla_documentos_faltantes.Rows.Clear()
        txt_total_documentos.Text = ""
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_detalle_venta.Rows.Clear()
        grilla_documentos.Rows.Clear()
        grilla_documentos_faltantes.Rows.Clear()
        txt_total_documentos.Text = ""
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_detalle_venta.Rows.Clear()
        grilla_documentos.Rows.Clear()
        grilla_documentos_faltantes.Rows.Clear()
        txt_total_documentos.Text = ""
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LOS REGISTROS FALTANTES?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then
            SC.Connection = conexion
            SC.CommandText = "DELETE FROM `documentos_faltantes` WHERE `cod_auto`='1136';"
            DA.SelectCommand = SC
            DA.Fill(DT)
            SC.Connection = conexion
            SC.CommandText = "DELETE FROM `documentos_faltantes` WHERE `cod_auto`<>'1136';"
            DA.SelectCommand = SC
            DA.Fill(DT)
            grilla_documentos_faltantes.Rows.Clear()
        End If
    End Sub
End Class