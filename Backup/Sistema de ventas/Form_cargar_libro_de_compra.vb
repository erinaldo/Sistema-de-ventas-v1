Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_cargar_libro_de_compra

    Private Sub Form_cargar_libro_de_compra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_libro_de_compras.Enabled = True
    End Sub

    Private Sub Form_cargar_libro_de_compra_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cargar_libro_de_compra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        dtp_periodo_tributario.CustomFormat = "MM-yyy"
        dtp_fecha_de_ingreso.CustomFormat = "yyy-MM-dd"
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub cargar_periodo_tributario()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select codigo_folio, periodo_tributario,documento, DOCUMENTO, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, nombre_proveedor, libro_de_compras.rut_proveedor, exentas, neto, iva, total, fecha_vencimiento from libro_de_compras, proveedores where periodo_tributario='" & (dtp_periodo_tributario.Text) & "' AND proveedores.rut_proveedor=libro_de_compras.rut_proveedor order by codigo_folio"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        Form_libro_de_compras.grilla_libro_compras.Rows.Clear()
        Form_libro_de_compras.grilla_libro_compras.Columns.Clear()
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("codigo_folio", "FOLIO")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("periodo_tributario", "PERIODO")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("documento", "DOCUMENTO")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("_tipo_documento", "TIPO")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("fecha_factura", "EMISION")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("nro_factura", "NRO.")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("clasificacion_cuenta", "CLASIFICACION")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("nombre_proveedor", "PROVEEDOR")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("rut_proveedor", "RUT")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("exentas", "EXENTAS")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("neto", "NETO")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("iva", "IVA")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("total", "TOTAL")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("fecha_vencimiento", "VENCIMIENTO")
        'Form_libro_de_compras.grilla_libro_compras.Columns(13).Visible = False
        Form_libro_de_compras.grilla_libro_compras.Columns(0).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(1).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(2).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(3).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(4).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(5).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(6).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(7).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(8).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(9).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(10).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(11).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(12).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(13).Visible = False

        'Form_libro_de_compras.grilla_libro_compras.Columns(0).Width = 85

        Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Form_libro_de_compras.grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_folio"), _
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

            Form_libro_de_compras.grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form_libro_de_compras.grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Form_libro_de_compras.grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Form_libro_de_compras.grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form_libro_de_compras.grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form_libro_de_compras.grilla_libro_compras.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form_libro_de_compras.grilla_libro_compras.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form_libro_de_compras.grilla_libro_compras.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        End If
    End Sub

    Sub cargar_fecha_de_ingreso()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select codigo_folio, periodo_tributario,documento, DOCUMENTO, tipo_documento, fecha_factura, nro_factura, clasificacion_cuenta, nombre_proveedor, libro_de_compras.rut_proveedor, exentas, neto, iva, total, fecha_vencimiento from libro_de_compras, proveedores where fecha_de_ingreso='" & (dtp_fecha_de_ingreso.Text) & "' AND proveedores.rut_proveedor=libro_de_compras.rut_proveedor"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        Form_libro_de_compras.grilla_libro_compras.Rows.Clear()
        Form_libro_de_compras.grilla_libro_compras.Columns.Clear()
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("codigo_folio", "FOLIO")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("periodo_tributario", "PERIODO")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("documento", "DOCUMENTO")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("_tipo_documento", "TIPO")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("fecha_factura", "EMISION")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("nro_factura", "NRO.")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("clasificacion_cuenta", "CLASIFICACION")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("nombre_proveedor", "PROVEEDOR")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("rut_proveedor", "RUT")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("exentas", "EXENTAS")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("neto", "NETO")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("iva", "IVA")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("total", "TOTAL")
        Form_libro_de_compras.grilla_libro_compras.Columns.Add("fecha_vencimiento", "VENCIMIENTO")
        'Form_libro_de_compras.grilla_libro_compras.Columns(13).Visible = False
        Form_libro_de_compras.grilla_libro_compras.Columns(0).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(1).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(2).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(3).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(4).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(5).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(6).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(7).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(8).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(9).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(10).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(11).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(12).Visible = True
        Form_libro_de_compras.grilla_libro_compras.Columns(13).Visible = False

        'Form_libro_de_compras.grilla_libro_compras.Columns(0).Width = 85

        Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Form_libro_de_compras.grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_folio"), _
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


            Form_libro_de_compras.grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form_libro_de_compras.grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Form_libro_de_compras.grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Form_libro_de_compras.grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form_libro_de_compras.grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form_libro_de_compras.grilla_libro_compras.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form_libro_de_compras.grilla_libro_compras.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Form_libro_de_compras.grilla_libro_compras.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If Radio_periodo_tributario.Checked = True Then
            cargar_periodo_tributario()
            Form_libro_de_compras.calcular_totales()
            Me.Close()
        End If

        If Radio_fecha_de_ingreso.Checked = True Then
            cargar_fecha_de_ingreso()
            Form_libro_de_compras.calcular_totales()
            Me.Close()
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus

    End Sub

    Private Sub Radio_fecha_de_ingreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_fecha_de_ingreso.CheckedChanged
        If Radio_fecha_de_ingreso.Checked = True Then
            dtp_periodo_tributario.Enabled = False
            dtp_fecha_de_ingreso.Enabled = True
        End If
    End Sub

    Private Sub Radio_periodo_tributario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_periodo_tributario.CheckedChanged
        If Radio_periodo_tributario.Checked = True Then
            dtp_periodo_tributario.Enabled = True
            dtp_fecha_de_ingreso.Enabled = False
        End If
    End Sub


End Class