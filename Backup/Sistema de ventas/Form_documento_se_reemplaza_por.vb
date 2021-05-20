Public Class Form_documento_se_reemplaza_por

    Private Sub Form_documento_se_reemplaza_por_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_nota_credito.Enabled = True
        Form_nota_credito.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_documento_se_reemplaza_por_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_documento_se_reemplaza_por_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        combo_documento.SelectedItem = "FACTURA"
        combo_documento.Focus()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If combo_documento.Text = "" Then
            MsgBox("DEBE INGRESAR EL TIPO DE DOCUMENTO QUE AFECTA LA NOTA DE CREDITO", 0 + 16, "ERROR")
            combo_documento.Focus()
            Exit Sub
        End If

        If combo_documento.Text <> "SIN IMPUTAR" Then
            If txt_nro_documento.Text = "" Then
                MsgBox("DEBE INGRESAR EL NRO. DE DOCUMENTO QUE AFECTA LA NOTA DE CREDITO", 0 + 16, "ERROR")
                txt_nro_documento.Focus()
                Exit Sub
            End If
        End If
        Me.Enabled = False

        Dim tipo_doc As String = ""

        tipo_doc = combo_documento.Text

        If tipo_doc = "FACTURA" Then
            tipo_doc = "FAC."
        End If

        If tipo_doc = "BOLETA" Then
            tipo_doc = "BOL."
        End If

        Form_nota_credito.Combo_motivo.Items.Add("SE REEMPLAZA POR " & tipo_doc & " NRO. " & txt_nro_documento.Text)
        Form_nota_credito.Combo_motivo.Text = "SE REEMPLAZA POR " & tipo_doc & " NRO. " & txt_nro_documento.Text
        Me.Close()
    End Sub





    Private Sub txt_orden_de_compra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_nro_documento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_orden_de_compra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
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


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
        Form_nota_credito.Close()
    End Sub

    Private Sub txt_orden_de_compra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_nro_documento.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        btn_aceptar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub combo_documento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles combo_documento.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_nro_documento.Focus()
        End If
    End Sub

    Private Sub combo_documento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_documento.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
    End Sub

    Private Sub txt_nro_documento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub combo_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documento.SelectedIndexChanged


        'If combo_documento.Text = "FACTURA ELECTRONICA" Then
        '    txt_tipo_dte.Text = "33"
        'End If



        'If combo_documento.Text = "BOLETA ELECTRONICA" Then
        '    txt_tipo_dte.Text = "39"
        'End If

        txt_nro_documento.Focus()
    End Sub

    Private Sub combo_documento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documento.TextChanged
        If combo_documento.Text = "SIN IMPUTAR" Then
            txt_nro_documento.Enabled = False
        Else
            txt_nro_documento.Enabled = True
        End If
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

    Private Sub txt_nro_documento_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_documento.TextChanged

    End Sub

    Private Sub txt_nro_documento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_documento.GotFocus
        txt_nro_documento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_documento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_documento.LostFocus
        txt_nro_documento.BackColor = Color.White
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
        'Dim tipo_impresion As String
        'Dim nombre As String
        'Dim valor As String
        'Dim descuento As String
        'Dim total As String
        'Dim subtotal As String

        'Dim VarTotalDesc As String

        Form_nota_credito.grilla_detalle_venta.Rows.Clear()

        If combo_documento.Text = "BOLETA" Then
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

                    If VarValorUnitario > VarPrecioReal Then
                        VarPrecioReal = VarValorUnitario
                    End If

                    If Form_nota_credito.txt_tipo_impresion.Text = "ELECTRONICA" Then
                        VarPrecioReal = VarValorUnitario
                        'VarSubtotal = VarPrecioReal * VarCantidad
                        VarSubtotal = VarPrecioReal

                        conexion.Close()
                        VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                        VarPorcentaje = 100 - VarPorcentaje

                        VarDescuento = VarPrecioReal - VarValorUnitario

                        VarSubtotal = VarSubtotal - VarDescuento

                        VarDescuento = VarDescuento * VarCantidad

                        VarValorUnitario = VarPrecioReal
                        iva_valor = valor_iva / 100 + 1
                        VarNeto = (VarTotal / iva_valor)
                        VarIva = (VarNeto) * valor_iva / 100
                    End If

                    If Form_nota_credito.txt_tipo_impresion.Text = "DIGITADA" Then
                        VarPrecioReal = VarValorUnitario
                        'VarSubtotal = VarPrecioReal * VarCantidad
                        VarSubtotal = VarPrecioReal

                        conexion.Close()
                        VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                        VarPorcentaje = 100 - VarPorcentaje

                        VarDescuento = VarPrecioReal - VarValorUnitario

                        VarSubtotal = VarSubtotal - VarDescuento

                        VarDescuento = VarDescuento * VarCantidad

                        VarValorUnitario = VarPrecioReal
                        iva_valor = valor_iva / 100 + 1
                        VarNeto = (VarTotal / iva_valor)
                        VarIva = (VarNeto) * valor_iva / 100
                    End If

                    Form_nota_credito.grilla_detalle_venta.Rows.Add(VarCodProducto, _
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
                    'Next

                    'Form_nota_credito.grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                    '                               DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                    '                                DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                    '                                 DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                    '                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                    '                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                    '                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                    '                                     DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                    '                                      DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                    '                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                    '                                        DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If




        If combo_documento.Text = "FACTURA" Then
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

                    If VarValorUnitario > VarPrecioReal Then
                        VarPrecioReal = VarValorUnitario
                    End If

                    VarPrecioReal = VarValorUnitario

                    'VarSubtotal = VarPrecioReal * VarCantidad
                    VarSubtotal = VarPrecioReal
                    Dim VarPrecioRealTotal As String

                    VarPrecioRealTotal = VarPrecioReal * VarCantidad

                    VarPorcentaje = Val(VarTotal) * 100 / Val(VarPrecioRealTotal)
                    VarPorcentaje = 100 - VarPorcentaje
                    VarDescuento = VarPrecioRealTotal - VarTotal

                    VarSubtotal = VarSubtotal - VarDescuento


                    VarDescuento = VarDescuento * VarCantidad

                    VarValorUnitario = VarPrecioReal
                    iva_valor = valor_iva / 100 + 1
                    VarNeto = (VarTotal / iva_valor)
                    VarIva = (VarNeto) * valor_iva / 100
                    Form_nota_credito.grilla_detalle_venta.Rows.Add(VarCodProducto, _
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



End Class