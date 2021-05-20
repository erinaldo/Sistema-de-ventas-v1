Public Class Form_seleccionar_documento_para_nota_credito_manuales

    Private Sub Form_seleccionar_documento_para_nota_credito_manuales_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_venta_manual.Enabled = True
        Form_venta_manual.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_seleccionar_documento_para_nota_credito_manuales_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_seleccionar_documento_para_nota_credito_manuales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        combo_documento.SelectedItem = "FACTURA"
        combo_documento.Focus()
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If combo_documento.Text = "" Then
            MsgBox("DEBE INGRESAR EL TIPO DE DOCUMENTO QUE AFECTA LA NOTA DE CREDITO", 0 + 16, "ERROR")
            combo_documento.Focus()
            Exit Sub
        End If
        If combo_documento.Text = "-" Then
            MsgBox("DEBE INGRESAR EL TIPO DE DOCUMENTO QUE AFECTA LA NOTA DE CREDITO", 0 + 16, "ERROR")
            combo_documento.Focus()
            Exit Sub
        End If
        If txt_nro_documento.Text = "" Then
            MsgBox("DEBE INGRESAR EL NUMERO DE DOCUMENTO QUE AFECTA LA NOTA DE CREDITO", 0 + 16, "ERROR")
            txt_nro_documento.Focus()
            Exit Sub
        End If


        grabar_nc()
        grabar_detalle_nc()
        MsgBox("SE HA GRABADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        Form_venta_manual.limpiar()
        Form_venta_manual.controles(False, True)
        Me.Close()

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub


    Sub grabar_nc()

        Dim mifecha As Date
        Dim mifecha2 As String
        mifecha = Form_venta_manual.dtp_fecha.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        If Form_venta_manual.combo_condiciones.Text = "CREDITO" Then
            If mirutempresa = "81921000-4" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE `creditos` SET `saldo`='0' WHERE rut_cliente='" & (Form_venta_manual.txt_rut_cliente.Text) & "' and tipo_detalle like '" & ("%" & combo_documento.Text & "%") & "' and tipo_detalle like '" & ("%" & txt_nro_documento.Text & "%") & "' and `cod_auto`<>'0';"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If mirutempresa <> "81921000-4" Then
                SC.Connection = conexion
                SC.CommandText = "insert into creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza, pie) values (" & (Form_venta_manual.txt_nro_doc_imprimir.Text) & ",'" & ("NOTA DE CREDITO") & "','" & ("NOTA DE CREDITO SIN IMPUTAR") & "','" & (Form_venta_manual.txt_rut_cliente.Text) & "','" & (Form_venta_manual.txt_cod_cliente.Text) & "','" & (Form_venta_manual.dtp_fecha.Text) & "'," & (Form_venta_manual.txt_desc.Text) & "," & (Form_venta_manual.txt_neto.Text) & "," & (Form_venta_manual.txt_iva.Text) & "," & (Form_venta_manual.txt_total.Text) & "," & ("-" & Form_venta_manual.txt_total.Text) & "," & ("-" & Form_venta_manual.txt_total.Text) & ",'" & (Form_venta_manual.combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (miusuario) & "','0','SIN IMPUTAR', '" & (mirecintoempresa) & "', '0000-00-00', '0000-00-00', '1', '1', '0', '0', '0')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        End If

        SC.Connection = conexion
        SC.CommandText = "insert into nota_credito (n_nota_credito, TIPO, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, tipo_documento, nro_documento, vendedor, fecha_ingreso, tipo_impresion, hora, porcentaje_desc, motivo) values (" & (Form_venta_manual.txt_nro_doc_imprimir.Text) & ",'" & ("NOTA DE CREDITO") & "','" & (Form_venta_manual.txt_rut_cliente.Text) & "','" & (Form_venta_manual.txt_cod_cliente.Text) & "', '" & (mifecha2) & "'," & (Form_venta_manual.txt_desc.Text) & "," & (Form_venta_manual.txt_neto.Text) & "," & (Form_venta_manual.txt_iva.Text) & "," & (Form_venta_manual.txt_sub_total.Text) & "," & (Form_venta_manual.txt_total.Text) & ",'" & (Form_venta_manual.combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (miusuario) & "','-','-','" & (mirecintoempresa) & "','" & (combo_documento.Text) & "','" & (txt_nro_documento.Text) & "','" & (Form_venta_manual.txt_rut_vendedor.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','DIGITADA','" & (Form_menu_principal.lbl_hora.Text) & "','" & (Form_venta_manual.txt_porcentaje_desc.Text) & "','-')"
        DA.SelectCommand = SC
        DA.Fill(DT)

    End Sub

    Sub grabar_detalle_nc()
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

        For i = 0 To Form_venta_manual.grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            VarCantidad = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = Form_venta_manual.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_nota_credito (n_nota_credito, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total ) values(" & (Form_venta_manual.txt_nro_doc_imprimir.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update productos set cantidad = cantidad + " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (Form_venta_manual.txt_nro_doc_imprimir.Text) & ",'NOTA DE CREDITO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & "," & (VarCantidad) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'ENTRA','" & (Form_venta_manual.dtp_fecha.Text) & "','" & (Form_venta_manual.txt_rut_vendedor.Text) & "','EMITIDA')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next
    End Sub
End Class