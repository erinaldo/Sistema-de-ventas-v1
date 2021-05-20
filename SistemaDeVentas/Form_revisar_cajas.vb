Public Class Form_revisar_cajas
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim NroDocKardex As String
    Dim TIPODocKardex As String
    Private Sub Form_revisar_cajas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_revisar_cajas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_revisar_cajas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
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
        If combo_venta.Text = "BOLETA" Then
            grilla_documentos.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from BOLETA where condiciones <> 'CREDITO' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' order by n_boleta asc"
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
                                                  DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("estado"))
                Next
            End If
        End If

        If combo_venta.Text = "ABONO" Then
            grilla_documentos.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from abono where condicion_abono <> 'CREDITO' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' order by n_abono asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("ABONO", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_abono"), _
                                                 mifecha_emision2, _
                                                  DS.Tables(DT.TableName).Rows(i).Item("condicion_abono"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("monto_abono"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("estado"))
                Next
            End If

        End If
        grilla_documentos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documentos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documentos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documentos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documentos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documentos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If grilla_documentos.Rows.Count <> 0 Then
            If grilla_documentos.Columns(0).Width = 80 Then
                grilla_documentos.Columns(0).Width = 79
            Else
                grilla_documentos.Columns(0).Width = 80
            End If
        End If

        txt_ventas.Text = grilla_documentos.Rows.Count
    End Sub

    Sub mostrar_documentos_pie()
        If combo_venta.Text = "BOLETA" Then
            grilla_pie.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from BOLETA where pie <> '0' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' order by n_boleta asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_pie.Rows.Add("BOLETA", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_boleta"), _
                                                 mifecha_emision2, _
                                                  DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago_pie"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("pie"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("estado"))
                Next
            End If
        End If
        grilla_pie.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_pie.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_pie.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_pie.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_pie.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_pie.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If grilla_pie.Rows.Count <> 0 Then
            If grilla_pie.Columns(0).Width = 80 Then
                grilla_pie.Columns(0).Width = 79
            Else
                grilla_pie.Columns(0).Width = 80
            End If
        End If

        txt_ventas.Text = Val(txt_ventas.Text) + grilla_pie.Rows.Count
    End Sub

    Sub mostrar_documentos_detalle()
        grilla_documentos_faltantes.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_condicion_de_pago where tipo_doc like '" & ("%" & combo_venta.Text & "%") & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' order by tipo_doc desc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim MiFechaEmision As Date
                Dim mifecha_emision2 As String
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                grilla_documentos_faltantes.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo_doc"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("nro_doc"), _
                                                       mifecha_emision2, _
                                                        DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("valor"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("estado"))
            Next
        End If

        grilla_documentos_faltantes.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documentos_faltantes.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documentos_faltantes.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documentos_faltantes.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documentos_faltantes.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
        mostrar_documentos_pie()
        mostrar_documentos_detalle()
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

        'grabar_detalle_factura()

        MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

    End Sub

    Private Sub btn_revisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_revisar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        revisar_documentos()

        lbl_mensaje.Visible = False
        Me.Enabled = True

        MsgBox("DATOS REVISADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

    End Sub

    Sub revisar_documentos()
        Dim tipo_doc As String
        Dim nro_doc As String
        Dim fecha_doc As String
        Dim valor As String
        Dim condicion_de_pago As String
        Dim estado As String

        For i = 0 To grilla_documentos.Rows.Count - 1
            tipo_doc = grilla_documentos.Rows(i).Cells(0).Value.ToString
            nro_doc = grilla_documentos.Rows(i).Cells(1).Value.ToString
            fecha_doc = grilla_documentos.Rows(i).Cells(2).Value.ToString
            condicion_de_pago = grilla_documentos.Rows(i).Cells(3).Value.ToString
            valor = grilla_documentos.Rows(i).Cells(4).Value.ToString
            estado = grilla_documentos.Rows(i).Cells(5).Value.ToString



            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_condicion_de_pago where nro_doc = '" & (nro_doc) & "' and valor = '" & (valor) & "' and tipo_doc like '" & ("%" & tipo_doc & "%") & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Dim mifecha As Date
                mifecha = fecha_doc
                fecha_doc = mifecha.ToString("yyy-MM-dd")
                SC.Connection = conexion
                SC.CommandText = "UPDATE `detalle_condicion_de_pago` SET `fecha`='" & (fecha_doc) & "' WHERE nro_doc = '" & (nro_doc) & "' and valor = '" & (valor) & "' and tipo_doc like '" & ("%" & tipo_doc & "%") & "' and `cod_auto`<>'0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Else
                Dim mifecha As Date
                mifecha = fecha_doc
                fecha_doc = mifecha.ToString("yyy-MM-dd")
                SC.Connection = conexion
                SC.CommandText = "INSERT INTO `detalle_condicion_de_pago` (`nro_doc`, `tipo_doc`, `valor`, `condicion_de_pago`, `estado`, `fecha`) VALUES ('" & (nro_doc) & "', '" & (tipo_doc) & "', '" & (valor) & "', '" & (condicion_de_pago) & "', '" & (estado) & "', '" & (fecha_doc) & "');"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        Next





















        For i = 0 To grilla_pie.Rows.Count - 1
            tipo_doc = grilla_pie.Rows(i).Cells(0).Value.ToString
            nro_doc = grilla_pie.Rows(i).Cells(1).Value.ToString
            fecha_doc = grilla_pie.Rows(i).Cells(2).Value.ToString
            condicion_de_pago = grilla_pie.Rows(i).Cells(3).Value.ToString
            valor = grilla_pie.Rows(i).Cells(4).Value.ToString
            estado = grilla_pie.Rows(i).Cells(5).Value.ToString

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_condicion_de_pago where nro_doc = '" & (nro_doc) & "' and valor = '" & (valor) & "' and tipo_doc like '" & ("%" & tipo_doc & "%") & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Dim mifecha As Date
                mifecha = fecha_doc
                fecha_doc = mifecha.ToString("yyy-MM-dd")
                SC.Connection = conexion
                SC.CommandText = "UPDATE `detalle_condicion_de_pago` SET `fecha`='" & (fecha_doc) & "' WHERE nro_doc = '" & (nro_doc) & "' and valor = '" & (valor) & "' and tipo_doc like '" & ("%" & tipo_doc & "%") & "' and `cod_auto`<>'0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Else
                Dim mifecha As Date
                mifecha = fecha_doc
                fecha_doc = mifecha.ToString("yyy-MM-dd")
                SC.Connection = conexion
                SC.CommandText = "INSERT INTO `detalle_condicion_de_pago` (`nro_doc`, `tipo_doc`, `valor`, `condicion_de_pago`, `estado`, `fecha`) VALUES ('" & (nro_doc) & "', '" & (tipo_doc) & "', '" & (valor) & "', '" & (condicion_de_pago) & "', '" & (estado) & "', '" & (fecha_doc) & "');"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        Next
    End Sub

    Sub grabar_detalle_factura()
        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As String
        'Dim VarPorcentaje As Integer
        'Dim VarDescuento As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        'Dim VarTotal As Integer
        'Dim VarTipoDoc As String = ""

        'Dim TIPO As String
        'Dim numero As String
        'Dim fecha_doc As String
        'Dim responsable_doc As String

        'For u = 0 To grilla_documentos.Rows.Count - 1
        '    TIPO = grilla_documentos.Rows(u).Cells(0).Value.ToString
        '    numero = grilla_documentos.Rows(u).Cells(1).Value.ToString
        '    fecha_doc = grilla_documentos.Rows(u).Cells(2).Value.ToString
        '    responsable_doc = grilla_documentos.Rows(u).Cells(3).Value.ToString

        '    TIPODocKardex = grilla_documentos.Rows(u).Cells(0).Value.ToString
        '    NroDocKardex = grilla_documentos.Rows(u).Cells(1).Value.ToString

        '    Dim mifecha As Date
        '    mifecha = fecha_doc
        '    fecha_doc = mifecha.ToString("yyy-MM-dd")

        '    SC.Connection = conexion
        '    'SC.CommandText = "INSERT INTO `detalle_condicion_de_pago` (`nro_doc`, `tipo_doc`, `valor`, `condicion_de_pago`, `estado`, `fecha`) VALUES ('" & (numero) & "', '" & (TIPO) & "', '" & (valor) & "', '" & (condicion) & "', '" & (estado_doc) & "', '" & (fecha_doc) & "');"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Next
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        grilla_documentos.Rows.Clear()
        grilla_documentos_faltantes.Rows.Clear()
        txt_ventas.Text = ""
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_documentos.Rows.Clear()
        grilla_documentos_faltantes.Rows.Clear()
        txt_ventas.Text = ""
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_documentos.Rows.Clear()
        grilla_documentos_faltantes.Rows.Clear()
        txt_ventas.Text = ""
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class