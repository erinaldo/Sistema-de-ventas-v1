Public Class Form_editar_ofertas_productos
    Dim precio_final As Integer = 0

    Private Sub Form_editar_ofertas_productos_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_editar_ofertas_productos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_revision_cotizaciones.WindowState = FormWindowState.Normal
        Form_revision_cotizaciones.Enabled = True
        Form_revision_cotizaciones.busqueda()
    End Sub

    Private Sub Form_editar_ofertas_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_proveedores()
        mostrar_malla_ofertas()
        grilla_ofertas.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
        Combo_tipo_precio.Text = "-"

        lbl_marca.Text = Form_revision_cotizaciones.grilla_revision_pedidos.CurrentRow.Cells(3).Value
        Combo_proveedor.Text = "-"

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_quitar_Click(sender As Object, e As EventArgs) Handles btn_quitar.Click
        If grilla_ofertas.Rows.Count > 0 Then
            grilla_ofertas.Rows.Remove(grilla_ofertas.CurrentRow)
        End If


    End Sub

    Sub mostrar_malla_ofertas()

        Dim nro_pedido As String = ""
        Dim nro_pedido_detalle As String = ""

        nro_pedido = Form_revision_cotizaciones.grilla_revision_pedidos.CurrentRow.Cells(0).Value
        nro_pedido_detalle = Form_revision_cotizaciones.grilla_revision_pedidos.CurrentRow.Cells(2).Value

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT cod_auto, proveedor, tipo_precio, costo, porcentaje_desc, precio, estado, comentario FROM ofertas_cotizaciones where nro_pedido='" & (nro_pedido) & "' and  nro_pedido_detalle='" & (nro_pedido_detalle) & "';"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_ofertas.Rows.Clear()
        grilla_ofertas.Columns.Clear()
        grilla_ofertas.Columns.Add("", "CODIGO")
        grilla_ofertas.Columns.Add("", "PROVEEDOR")
        grilla_ofertas.Columns.Add("", "TIPO PRECIO")
        grilla_ofertas.Columns.Add("", "COSTO")
        grilla_ofertas.Columns.Add("", "% DESC.")
        grilla_ofertas.Columns.Add("", "PRECIO")
        grilla_ofertas.Columns.Add("", "COMENTARIO")
        grilla_ofertas.Columns.Add("", "ESTADO")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_ofertas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"),
                                                   DS.Tables(DT.TableName).Rows(i).Item("proveedor"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("tipo_precio"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("costo"),
                                                      DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"),
                                                       DS.Tables(DT.TableName).Rows(i).Item("precio"),
                                                        DS.Tables(DT.TableName).Rows(i).Item("comentario"),
                                                         DS.Tables(DT.TableName).Rows(i).Item("estado"))
            Next
        End If

        'If grilla_ofertas.Rows.Count <> 0 Then
        '    If grilla_ofertas.Columns(0).Width = 100 Then
        '        grilla_ofertas.Columns(0).Width = 99
        '    Else
        '        grilla_ofertas.Columns(0).Width = 100
        '    End If
        '    grilla_ofertas.Columns(1).Width = 230
        '    grilla_ofertas.Columns(2).Width = 150
        '    grilla_ofertas.Columns(3).Width = 380
        '    'grilla_ofertas.Columns(4).Width = 255

        '    grilla_ofertas.Columns(0).Visible = False

        grilla_ofertas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_ofertas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_ofertas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_ofertas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_ofertas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_ofertas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_ofertas.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'End If
        grilla_ofertas.ClearSelection()

        grilla_ofertas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        If Combo_proveedor.Text = "-" Then
            Combo_proveedor.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If Combo_tipo_precio.Text = "-" Then
            Combo_tipo_precio.Focus()
            MsgBox("CAMPO TIPO PRECIO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_costo.Text = "" Then
            txt_costo.Focus()
            MsgBox("CAMPO COSTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_porcentaje_desc.Text = "" Then
            txt_porcentaje_desc.Text = "0"
        End If

        If txt_precio.Text = "" Then
            txt_precio.Text = "0"
        End If
        'If txt_comentario.Text = "" Then
        '    txt_comentario.Focus()
        '    MsgBox("CAMPO COMENTARIO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        Dim rut_proveedor As String = ""
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select rut_proveedor from proveedores where nombre_proveedor='" & (Combo_proveedor.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            rut_proveedor = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
        End If
        conexion.Close()

        Dim nro_pedido As String = ""
        Dim nro_pedido_detalle As String = ""

        nro_pedido = Form_revision_cotizaciones.grilla_revision_pedidos.CurrentRow.Cells(0).Value
        nro_pedido_detalle = Form_revision_cotizaciones.grilla_revision_pedidos.CurrentRow.Cells(2).Value

        'SC.Connection = conexion
        'SC.CommandText = "Update `detalle_pedido` Set `PRIORIDAD`='COTIZADO', `comentario`='" & (txt_comentario.Text) & "' WHERE `codigo_auto`='" & (nro_pedido_detalle) & "';"
        'DA.SelectCommand = SC
        'DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `detalle_pedido` Set `ESTADO`='COTIZADO' WHERE `codigo_auto`='" & (nro_pedido_detalle) & "';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "INSERT INTO ofertas_cotizaciones(nro_pedido, nro_pedido_detalle, rut_proveedor, proveedor, tipo_precio, costo, porcentaje_desc, precio, comentario, usuario_responsable, fecha_modificacion) VALUES ('" & (nro_pedido) & "','" & (nro_pedido_detalle) & "','" & (rut_proveedor) & "', '" & (Combo_proveedor.Text) & "', '" & (Combo_tipo_precio.Text) & "', '" & (txt_costo.Text) & "',  '" & (txt_porcentaje_desc.Text) & "',  '" & (txt_precio.Text) & "', '" & (txt_comentario.Text) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)


        mostrar_malla_ofertas()
        'Form_revision_cotizaciones.busqueda()

        txt_comentario.Text = ""
        txt_costo.Text = ""
        txt_porcentaje_desc.Text = ""
        txt_precio.Text = ""
        Combo_proveedor.Text = "-"
        Combo_tipo_precio.Text = "-"



    End Sub


    Sub llenar_combo_proveedores()
        Combo_proveedor.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from proveedores_cotizaciones WHERE nombre_fantasia_proveedor <> '-' order by nombre_proveedor"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_proveedor"))
            Next
            Combo_proveedor.Items.Add("-")
        End If
        conexion.Close()
    End Sub

    Private Sub txt_comentario_TextChanged(sender As Object, e As EventArgs) Handles txt_comentario.TextChanged

    End Sub

    Private Sub txt_comentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_comentario.KeyPress
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
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub txt_costo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_costo.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub Combo_proveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_proveedor.SelectedIndexChanged

    End Sub

    Private Sub Combo_proveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Combo_proveedor.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub txt_porcentaje_desc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_porcentaje_desc.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Combo_tipo_precio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_tipo_precio.SelectedIndexChanged
        precio()
    End Sub

    Private Sub Combo_tipo_precio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Combo_tipo_precio.KeyPress

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txt_costo_TextChanged(sender As Object, e As EventArgs) Handles txt_costo.TextChanged

        precio()

    End Sub

    Sub precio()
        txt_porcentaje_desc.Text = ""

        If Combo_tipo_precio.Text = "CON IVA" Then
            Dim valor_iva_margen As String
            Dim precio_venta As Integer

            Try

                valor_iva_margen = valor_iva / 100 + 1

                precio_venta = Val(txt_costo.Text) / (valor_iva_margen)

                txt_precio.Text = precio_venta

                precio_final = Val(txt_precio.Text)

            Catch ex As Exception
                Exit Sub
            End Try
        Else
            txt_precio.Text = Val(txt_costo.Text)
            precio_final = Val(txt_costo.Text)
        End If

    End Sub

    Private Sub txt_porcentaje_desc_TextChanged(sender As Object, e As EventArgs) Handles txt_porcentaje_desc.TextChanged
        calcular_descuento()
    End Sub

    Sub calcular_descuento()
        Dim descuento_porcentaje As Integer
        Dim porcentaje_desc As Integer


        If txt_porcentaje_desc.Text = "" Or txt_porcentaje_desc.Text = "-" Then
            porcentaje_desc = 0
        Else
            porcentaje_desc = txt_porcentaje_desc.Text
        End If

        Try
            descuento_porcentaje = ((precio_final) * porcentaje_desc) / 100
            txt_precio.Text = Int(precio_final) - Int(descuento_porcentaje)
        Catch
        End Try

    End Sub
End Class