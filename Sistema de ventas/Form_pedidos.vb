Imports System.IO

Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_pedidos
    Dim varcodpedido As Integer
    Private Sub Form_pedidos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub Form_pedidos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim valormensaje As Integer

        'If grilla_detalle.Rows.Count <> 0 Then
        '    valormenwhitessaje = MsgBox("¿DESEA SALIR SIN GUARDAR EL PEDIDO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CERRAR")
        '    If valormensaje = vbNo Then
        '        e.Cancel = True
        '    End If
        'End If
    End Sub

    Private Sub Form_pedidos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F12 Then
            btn_guardar.Focus()
        End If

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

    Private Sub Form_pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'llenar_combo_proveedor()
        'nombre_vendedor()
        cargar_logo()
        'mostrar_datos_login()
        dtp_fecha_pedido.CustomFormat = "yyy-MM-dd"
        dtp_fecha_llegada.CustomFormat = "yyy-MM-dd"
        'impresoras()
        'mostrar_datos_login()
        llenar_combo_proveedores_mas_pedidos()
        controles(True, False)
        Combo_prioridad.SelectedItem = "REPOSICION"
        Timer_inactividad_pedidos.Start()
        'Me.BackColor = Color.FromArgb(color_fondo)
        'Me.ForeColor = Color.FromArgb(color_texto)
        'Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        'Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    'Sub mostrar_datos_login()
    '    lbl_usuario_conectado.Text = minombre
    'End Sub

    Sub llenar_combo_proveedores_mas_pedidos()
        Combo_proveedor.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from proveedores_Mas_pedidos order by nombre_proveedor"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_proveedor"))
            Next
            Combo_proveedor.Items.Add("OTROS")
        End If
        conexion.Close()
    End Sub

    'Sub impresoras()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select ticket_de_deposito from impresoras"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_impresora_deposito.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_de_deposito")
    '    End If
    '    conexion.Close()
    'End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a
        btn_guardar.Enabled = a
        btn_nueva.Enabled = b

        Combo_prioridad.Enabled = a
        Combo_proveedor.Enabled = a

        txt_cantidad_producto.Enabled = a
        txt_codigo_pedido.Enabled = a
        txt_codigo_producto.Enabled = a
        txt_comentario_producto.Enabled = a
        txt_descripcion_producto.Enabled = a
        grilla_pedidos.Enabled = a

    End Sub

    Sub limpiar_datos()

        'Combo_prioridad.Text = ""
        'Combo_proveedor.Text = ""
        txt_codigo_pedido.Text = ""
        txt_codigo_producto.Text = ""
        txt_cantidad_producto.Text = ""
        txt_descripcion_producto.Text = ""
        txt_comentario_producto.Text = ""
    End Sub

    Sub limpiar()
        Combo_prioridad.Text = ""
        Combo_proveedor.Text = ""
        txt_codigo_pedido.Text = ""
        txt_codigo_producto.Text = ""
        txt_descripcion_producto.Text = ""
        txt_comentario_producto.Text = ""
        txt_cantidad_producto.Text = ""
        grilla_pedidos.Rows.Clear()
    End Sub

    Sub llenar_combo_proveedor()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from proveedores order by nombre_proveedor"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"))
            Next
        End If
        conexion.Close()
    End Sub

    'Sub nombre_vendedor()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()
    '    SC.Connection = conexion
    '    SC.CommandText = "Select * from usuarios where rut_usuario = '" & (miusuario) & "'  "
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        minombre = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
    '    End If
    '    conexion.Close()
    'End Sub

    Sub grabar_detalle_pedido()
        Dim codigo_producto As String
        Dim proveedor As String
        Dim cantidad As String
        Dim descripcion As String
        Dim comentario As String
        Dim estado As String
        '  Dim prioridad As String
        Dim fecha_llegada As String

        For i = 0 To grilla_pedidos.Rows.Count - 1
            codigo_producto = grilla_pedidos.Rows(i).Cells(0).Value.ToString
            proveedor = grilla_pedidos.Rows(i).Cells(7).Value.ToString
            cantidad = grilla_pedidos.Rows(i).Cells(2).Value.ToString
            descripcion = grilla_pedidos.Rows(i).Cells(3).Value.ToString
            comentario = grilla_pedidos.Rows(i).Cells(4).Value.ToString
            estado = grilla_pedidos.Rows(i).Cells(5).Value.ToString
            ' prioridad = grilla_detalle.Rows(i).Cells(6).Value.ToString
            fecha_llegada = grilla_pedidos.Rows(i).Cells(6).Value.ToString



            If descripcion = "" Then
                descripcion = "-"
            End If
            If descripcion = " " Then
                descripcion = "-"
            End If
            If descripcion = "  " Then
                descripcion = "-"
            End If
            If descripcion = "   " Then
                descripcion = "-"
            End If

            If comentario = "" Then
                comentario = "-"
            End If
            If comentario = " " Then
                comentario = "-"
            End If
            If comentario = "  " Then
                comentario = "-"
            End If
            If comentario = "   " Then
                comentario = "-"
            End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_pedido (codigo_producto, proveedor, cantidad, descripcion, comentario, estado, prioridad, codigo_pedido, fecha_llegada) values('" & (codigo_producto) & "', '" & (proveedor) & "', '" & (cantidad) & "','" & (descripcion) & "','" & (comentario) & "','EN ESPERA', '" & (Combo_prioridad.Text) & "',  '" & (txt_codigo_pedido.Text) & "',  '" & (fecha_llegada) & "')"

            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub

    Sub grabar_pedido()
        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "insert into pedido (codigo_pedido, rut_cliente, nombre_cliente, telefono_cliente, abono, fecha_pedido, usuario_responsable, hora) values('" & (txt_codigo_pedido.Text) & "', '-','-','-', '0', '" & (dtp_fecha_pedido.Text) & "','" & (miusuario) & "', '" & (Form_menu_principal.lbl_hora.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)
        'conexion.Close()
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Dim mensaje As String = ""
        If Combo_proveedor.Text <> "SKF" And Combo_proveedor.Text <> "J. RIVEROS" Then
            If Combo_proveedor.Text = "" Then
                mensaje = "CAMPO PROVEEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_proveedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_codigo_producto.Text = "" Then
                mensaje = "CAMPO CODIGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_codigo_producto.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_cantidad_producto.Text = "" Then
                mensaje = "CANTIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_cantidad_producto.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If Combo_prioridad.Text = "" Then
                mensaje = "COMBO PRIORIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_prioridad.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_descripcion_producto.Text = "" Then
                'If txt_descripcion_producto.Text = "" Or txt_descripcion_producto.Text = " " Or txt_descripcion_producto.Text = "  " Then
                mensaje = "CAMPO DESCRIPCION VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_descripcion_producto.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
            'End If

            'Dim proveedor As String
            'Dim codigo As String
            'Dim estado As String

            crear_codigo_pedido()

            'For i = 0 To grilla_detalle.Rows.Count - 1

            '    proveedor = grilla_detalle.Rows(i).Cells(1).Value.ToString
            '    codigo = grilla_detalle.Rows(i).Cells(0).Value.ToString
            '    estado = grilla_detalle.Rows(i).Cells(2).Value.ToString

            '    If proveedor = Combo_proveedor.Text And codigo = txt_codigo_producto.Text And estado = "EN ESPERA" Then
            '        grilla_detalle.Rows.Remove(grilla_detalle.Rows(i))
            '        grilla_detalle.Rows.Add(txt_codigo_producto.Text, Combo_proveedor.Text, txt_cantidad_producto.Text, txt_descripcion_producto.Text, txt_comentario_producto.Text, "EN ESPERA", dtp_fecha_llegada.Text, txt_rut_proveedor.Text)
            '        limpiar_datos()
            '        txt_codigo_producto.Focus()

            '        Exit Sub
            '    End If
            'Next
            If Combo_prioridad.Text = "COTIZAR" Then
                grilla_pedidos.Rows.Add(txt_codigo_producto.Text, Combo_proveedor.Text, txt_cantidad_producto.Text, txt_descripcion_producto.Text, txt_comentario_producto.Text, "COTIZAR", dtp_fecha_llegada.Text, Combo_proveedor.Text)
                limpiar_datos()
                txt_codigo_producto.Focus()
            Else
                grilla_pedidos.Rows.Add(txt_codigo_producto.Text, Combo_proveedor.Text, txt_cantidad_producto.Text, txt_descripcion_producto.Text, txt_comentario_producto.Text, "EN ESPERA", dtp_fecha_llegada.Text, Combo_proveedor.Text)
                limpiar_datos()
                txt_codigo_producto.Focus()
            End If
        End If

        If Combo_proveedor.Text = "SKF" Then
            If Combo_proveedor.Text = "" Then
                mensaje = "CAMPO PROVEEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_proveedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_codigo_producto.Text = "" Then
                mensaje = "CAMPO CODIGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_codigo_producto.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_cantidad_producto.Text = "" Then
                mensaje = "CANTIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_cantidad_producto.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If Combo_prioridad.Text = "" Then
                mensaje = "COMBO PRIORIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_prioridad.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            'If txt_descripcion_producto.Text = "" Then
            '    'If txt_descripcion_producto.Text = "" Or txt_descripcion_producto.Text = " " Or txt_descripcion_producto.Text = "  " Then
            '    mensaje = "CAMPO DESCRIPCION VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            '    txt_descripcion_producto.Focus()
            '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            '    Exit Sub
            'End If
            'End If

            'Dim proveedor As String
            'Dim codigo As String
            'Dim estado As String

            crear_codigo_pedido()

            'For i = 0 To grilla_detalle.Rows.Count - 1

            '    proveedor = grilla_detalle.Rows(i).Cells(1).Value.ToString
            '    codigo = grilla_detalle.Rows(i).Cells(0).Value.ToString
            '    estado = grilla_detalle.Rows(i).Cells(2).Value.ToString

            '    If proveedor = Combo_proveedor.Text And codigo = txt_codigo_producto.Text And estado = "EN ESPERA" Then
            '        grilla_detalle.Rows.Remove(grilla_detalle.Rows(i))
            '        grilla_detalle.Rows.Add(txt_codigo_producto.Text, Combo_proveedor.Text, txt_cantidad_producto.Text, txt_descripcion_producto.Text, txt_comentario_producto.Text, "EN ESPERA", dtp_fecha_llegada.Text, txt_rut_proveedor.Text)
            '        limpiar_datos()
            '        txt_codigo_producto.Focus()

            '        Exit Sub
            '    End If
            'Next


            If Combo_prioridad.Text = "COTIZAR" Then
                grilla_pedidos.Rows.Add(txt_codigo_producto.Text, Combo_proveedor.Text, txt_cantidad_producto.Text, txt_descripcion_producto.Text, txt_comentario_producto.Text, "COTIZAR", dtp_fecha_llegada.Text, Combo_proveedor.Text)
                limpiar_datos()
                txt_codigo_producto.Focus()
            Else

                grilla_pedidos.Rows.Add(txt_codigo_producto.Text, Combo_proveedor.Text, txt_cantidad_producto.Text, txt_descripcion_producto.Text, txt_comentario_producto.Text, "EN ESPERA", dtp_fecha_llegada.Text, Combo_proveedor.Text)
                limpiar_datos()
                txt_codigo_producto.Focus()
            End If
        End If


        If Combo_proveedor.Text = "J. RIVEROS" Then
            If Combo_proveedor.Text = "" Then
                mensaje = "CAMPO PROVEEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_proveedor.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_codigo_producto.Text = "" Then
                mensaje = "CAMPO CODIGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_codigo_producto.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_cantidad_producto.Text = "" Then
                mensaje = "CANTIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                txt_cantidad_producto.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If Combo_prioridad.Text = "" Then
                mensaje = "COMBO PRIORIDAD VACIO, FAVOR LLENAR" + Chr(13) & mensaje
                Combo_prioridad.Focus()
                MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            'If txt_descripcion_producto.Text = "" Then
            '    'If txt_descripcion_producto.Text = "" Or txt_descripcion_producto.Text = " " Or txt_descripcion_producto.Text = "  " Then
            '    mensaje = "CAMPO DESCRIPCION VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            '    txt_descripcion_producto.Focus()
            '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            '    Exit Sub
            'End If
            'End If

            'Dim proveedor As String
            'Dim codigo As String
            'Dim estado As String

            crear_codigo_pedido()

            'For i = 0 To grilla_detalle.Rows.Count - 1

            '    proveedor = grilla_detalle.Rows(i).Cells(1).Value.ToString
            '    codigo = grilla_detalle.Rows(i).Cells(0).Value.ToString
            '    estado = grilla_detalle.Rows(i).Cells(2).Value.ToString

            '    If proveedor = Combo_proveedor.Text And codigo = txt_codigo_producto.Text And estado = "EN ESPERA" Then
            '        grilla_detalle.Rows.Remove(grilla_detalle.Rows(i))
            '        grilla_detalle.Rows.Add(txt_codigo_producto.Text, Combo_proveedor.Text, txt_cantidad_producto.Text, txt_descripcion_producto.Text, txt_comentario_producto.Text, "EN ESPERA", dtp_fecha_llegada.Text, txt_rut_proveedor.Text)
            '        limpiar_datos()
            '        txt_codigo_producto.Focus()

            '        Exit Sub
            '    End If
            'Next
            If Combo_prioridad.Text = "COTIZAR" Then
                grilla_pedidos.Rows.Add(txt_codigo_producto.Text, Combo_proveedor.Text, txt_cantidad_producto.Text, txt_descripcion_producto.Text, txt_comentario_producto.Text, "COTIZAR", dtp_fecha_llegada.Text, Combo_proveedor.Text)
                limpiar_datos()
                txt_codigo_producto.Focus()
            Else
                grilla_pedidos.Rows.Add(txt_codigo_producto.Text, Combo_proveedor.Text, txt_cantidad_producto.Text, txt_descripcion_producto.Text, txt_comentario_producto.Text, "EN ESPERA", dtp_fecha_llegada.Text, Combo_proveedor.Text)
                limpiar_datos()
                txt_codigo_producto.Focus()
            End If
        End If
    End Sub

    Private Sub grilla_detalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_pedidos.CellContentClick

    End Sub

    Private Sub Combo_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_proveedor.GotFocus
        Combo_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combo_proveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_codigo_producto.Focus()
        End If



    End Sub

    Private Sub Combo_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_proveedor.KeyPress
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
            txt_codigo_producto.Focus()
        End If
    End Sub

    Private Sub Combo_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_proveedor.LostFocus
        Combo_proveedor.BackColor = Color.White

    End Sub



    Private Sub Combo_proveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_proveedor.SelectedIndexChanged
        'mostrar_datos_proveedor()
        dtp_fecha_llegada.Value = dtp_fecha_pedido.Value
        dtp_fecha_llegada.Value = dtp_fecha_llegada.Value.AddDays(Val(txt_llegada_producto.Text))
        txt_codigo_producto.Text = ""
        'txt_codigo_producto.Focus()
        Dim mensaje As String
        mensaje = ""
        If Combo_proveedor.Text = "ALSACIA" Then
            mensaje = "CODIGO ALSACIA:"
        End If

        If Combo_proveedor.Text = "GIMPORT" Then
            mensaje = "CODIGO GIMPORT:"
        End If

        If Combo_proveedor.Text = "J. RIVEROS" Then
            mensaje = "CODIGO J.RIVEROS:"
        End If

        If Combo_proveedor.Text = "MANNHEIM" Then
            mensaje = "CODIGO MANNHEIM:"

        End If

        If Combo_proveedor.Text = "NORIEGA" Then
            mensaje = "CODIGO NORIEGA:"
        End If

        If Combo_proveedor.Text = "REFAX" Then
            mensaje = "CODIGO REFAX:"
        End If

        If Combo_proveedor.Text = "SKF" Then
            mensaje = "NOMBRE SKF:"
        End If

        If Combo_proveedor.Text = "SIN PROVEEDOR" Then
            mensaje = "CODIGO:"
        End If


        lbl_codigo.Text = mensaje

    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        Dim codigo_pedido As String
        Dim valormensaje As Integer
        Dim mensaje As String = ""

        If grilla_pedidos.Rows.Count = 0 Then
            MsgBox("SELECCIONE UN PEDIDO", 0 + 16, "ERROR")
        Else

            valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR EL PEDIDO SELECCIONADO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

            If valormensaje = vbYes Then

                valormensaje = MsgBox("¿ESTA REALMENTE SEGURO DE ELIMINAR EL PEDIDO SELECCIONADO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

                If valormensaje = vbYes Then
                    codigo_pedido = grilla_pedidos.CurrentRow.Cells(0).Value

                    If grilla_pedidos.Rows.Count > 0 Then

                        'DS.Tables.Clear()
                        'DT.Rows.Clear()
                        'DT.Columns.Clear()
                        'DS.Clear()
                        'conexion.Open()

                        ''SC.Connection = conexion
                        ''SC.CommandText = "insert into registro_de_eliminaciones (tipo_eliminacion,detalle, codigo, fecha_eliminacion, usuario_responsable) values('LIBRO DE COMPRAS','" & (documento) & "','" & (folio) & "','" & (dtp3.Text) & "','" & (miusuario) & "')"
                        ''DA.SelectCommand = SC
                        ''DA.Fill(DT)

                        'SC.Connection = conexion
                        'SC.CommandText = "delete from pedidos where codigo_pedido = '" & (codigo_pedido) & "' "
                        'DA.SelectCommand = SC
                        'DA.Fill(DT)

                        'conexion.Close()

                        grilla_pedidos.Rows.Remove(grilla_pedidos.CurrentRow)

                        Combo_proveedor.Focus()
                    End If
                End If
            End If
        End If
    End Sub



    Private Sub Combo_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txt_codigo_producto.Focus()
        End If
    End Sub

    Private Sub Combo_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_codigo_producto.Focus()
        End If
    End Sub



    Private Sub Combo_codigo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        txt_cantidad_producto.Text = ""
        txt_codigo_producto.Text = ""
        txt_comentario_producto.Text = ""
        txt_descripcion_producto.Text = ""
        'txt_abono.Text = ""
    End Sub

    Private Sub txt_codigo_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.GotFocus
        txt_codigo_producto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_producto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_producto.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_codigo_producto.Focus()
        End If
    End Sub

    Private Sub txt_codigo_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_producto.KeyPress
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



        'If Combo_proveedor.Text = "REFAX" Then
        '    txt_codigo_producto.MaxLength = 7
        'End If

        'If Combo_proveedor.Text = "NORIEGA" Then
        '    txt_codigo_producto.MaxLength = 6

        '    If Char.IsDigit(e.KeyChar) Then
        '        e.Handled = False
        '    ElseIf Char.IsControl(e.KeyChar) Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'End If


        'If Combo_proveedor.Text = "MANNHEIM" Then
        '    txt_codigo_producto.MaxLength = 15

        'End If



        'If Combo_proveedor.Text = "SKF" Then
        '    txt_codigo_producto.MaxLength = 22

        'End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_cantidad_producto.Focus()
        End If
    End Sub

    Private Sub txt_codigo_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.LostFocus
        txt_codigo_producto.BackColor = Color.White
    End Sub

    Private Sub txt_codigo_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.TextChanged
        txt_descripcion_producto.Text = ""




    End Sub



    Sub crear_codigo_pedido()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        Try
            SC.Connection = conexion
            SC.CommandText = "select max(codigo_pedido) as codigo_pedido from pedido"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varcodpedido = DS.Tables(DT.TableName).Rows(0).Item("codigo_pedido")
                txt_codigo_pedido.Text = varcodpedido + 1
            End If
        Catch err As InvalidCastException
            txt_codigo_pedido.Text = 1
        End Try
        conexion.Close()

    End Sub

    Sub mostrar_datos_productos()
        If txt_codigo_producto.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_producto.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_descripcion_producto.Text = (DS.Tables(DT.TableName).Rows(0).Item("NOMBRE")) & " " & (DS.Tables(DT.TableName).Rows(0).Item("APLICACION")) & " " & (DS.Tables(DT.TableName).Rows(0).Item("NUMERO_TECNICO"))

            End If
            conexion.Close()
        End If

        If txt_descripcion_producto.Text = "" Then
        End If
    End Sub

    'Sub mostrar_datos_proveedor()
    '    If Combo_proveedor.Text <> "" Then
    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from proveedores where nombre_proveedor ='" & (Combo_proveedor.Text) & "'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)

    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            txt_rut_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
    '            txt_llegada_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("llegada_productos")
    '        End If
    '        conexion.Close()
    '    End If

    '    If txt_descripcion_producto.Text = "" Then
    '    End If
    'End Sub

    Private Sub txt_cantidad_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_producto.GotFocus
        txt_cantidad_producto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_producto.KeyPress

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

        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Combo_prioridad.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_producto.LostFocus
        txt_cantidad_producto.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_producto.TextChanged

    End Sub

    'Private Sub txt_abono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_abono.BackColor = Color.LightBlue
    'End Sub

    Private Sub txt_abono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_abono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'txt_abono.BackColor = Color.White
    End Sub

    Private Sub txt_abono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_descripcion_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descripcion_producto.GotFocus
        txt_descripcion_producto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_descripcion_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descripcion_producto.KeyPress
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
            txt_comentario_producto.Focus()
        End If
    End Sub

    Private Sub txt_descripcion_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descripcion_producto.LostFocus
        txt_descripcion_producto.BackColor = Color.White
    End Sub

    Private Sub txt_descripcion_producto_RegionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descripcion_producto.RegionChanged

    End Sub

    Private Sub txt_descripcion_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descripcion_producto.TextChanged

    End Sub

    Private Sub txt_comentario_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_comentario_producto.GotFocus
        txt_comentario_producto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_comentario_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_comentario_producto.KeyPress
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
            btn_agregar.Focus()
        End If
    End Sub

    Private Sub txt_comentario_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_comentario_producto.LostFocus
        txt_comentario_producto.BackColor = Color.White
    End Sub

    Private Sub txt_comentario_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comentario_producto.TextChanged

    End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn_agregar.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_quitar_elemento.Focus()
        End If
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn_quitar_elemento.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Combo_proveedor.Focus()
        End If
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    'Private Sub CheckBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
    '        If CheckBox1.Checked = True Then
    '            CheckBox1.Checked = False
    '        Else
    '            CheckBox1.Checked = True
    '        End If
    '    End If
    'End Sub

    'Private Sub CheckBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CheckBox1.ForeColor = Color.Black
    'End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim valormensaje As Integer
        Dim mensaje As String = ""

        If grilla_pedidos.Rows.Count = 0 Then
            mensaje = "MALLA DE PEDIDO VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            txt_codigo_producto.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_prioridad.Text = "URGENTE" Then
            valormensaje = MsgBox("¿DESEA AGREGAR UN ABONO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ABONO")
            If valormensaje = vbYes Then
                Form_registro_clientes_abono.Show()
                Me.Enabled = False
                Exit Sub

            Else

                lbl_mensaje.Visible = True
                Me.Enabled = False



                crear_codigo_pedido()
                grabar_pedido()
                grabar_detalle_pedido()
                'limpiar()
                controles(False, True)


         

        

                MsgBox("SE HA INGRESADO CORRECTAMENTE EL PEDIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            End If
        End If



        If Combo_prioridad.Text <> "URGENTE" And Combo_prioridad.Text <> "" Then

            lbl_mensaje.Visible = True
            Me.Enabled = False



            crear_codigo_pedido()
            grabar_pedido()
            grabar_detalle_pedido()
            'limpiar()
            controles(False, True)
            MsgBox("SE HA INGRESADO CORRECTAMENTE EL PEDIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        End If

        limpiar()
        Me.Enabled = True
        lbl_mensaje.Visible = False

    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        controles(True, False)
        Combo_proveedor.Focus()
    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.GotFocus
        btn_nueva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.LostFocus
        btn_nueva.BackColor = Color.Transparent
    End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub Combo_prioridad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_prioridad.GotFocus
        Combo_prioridad.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_prioridad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combo_prioridad.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txt_descripcion_producto.Enabled = True Then
                txt_descripcion_producto.Focus()
            Else
                txt_comentario_producto.Focus()
            End If
        End If
    End Sub

    Private Sub Combo_prioridad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_prioridad.KeyPress
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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If txt_descripcion_producto.Enabled = True Then
                txt_descripcion_producto.Focus()
            Else
                txt_comentario_producto.Focus()
            End If
        End If
    End Sub

    Private Sub Combo_prioridad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_prioridad.LostFocus
        Combo_prioridad.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub Combo_prioridad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_prioridad.SelectedIndexChanged

    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Sub grabar_deposito_repuesto_temporal()
        Dim codigo_producto As String
        Dim cantidad As String
        Dim descripcion As String
        Dim fecha_llegada As String
        Dim nombre_vendedor As String
        Dim telefono_vendedor As String

        nombre_vendedor = ""
        telefono_vendedor = ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "Select * from usuarios where rut_usuario = '" & (miusuario) & "'  "
        DA.SelectCommand = SC
        DA.Fill(DT)

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            nombre_vendedor = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
            telefono_vendedor = DS.Tables(DT.TableName).Rows(0).Item("telefono_usuario")
        End If
        conexion.Close()





        For i = 0 To grilla_pedidos.Rows.Count - 1
            codigo_producto = grilla_pedidos.Rows(i).Cells(0).Value.ToString
            descripcion = grilla_pedidos.Rows(i).Cells(3).Value.ToString
            cantidad = grilla_pedidos.Rows(i).Cells(2).Value.ToString
            fecha_llegada = grilla_pedidos.Rows(i).Cells(6).Value.ToString

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "insert into deposito_para_repuesto_temporal (codigo_pedido, nombre_vendedor, telefono_vendedor, fecha_pedido, codigo_producto, nombre_producto, cantidad_producto, fecha_llegada) values('" & (txt_codigo_pedido.Text) & "', '" & (nombre_vendedor) & "','" & (telefono_vendedor) & "',  '" & (dtp_fecha_pedido.Text) & "' ,'" & (codigo_producto) & "','" & (descripcion) & "','" & (cantidad) & "','" & (fecha_llegada) & "' )"
            ' SC.CommandText = "insert into detalle_pedido (                                                                                                             codigo_producto,             proveedor,             cantidad,           descripcion,      comentario,        estado,              prioridad,                   codigo_pedido) values('" & (codigo_producto) & "', '" & (proveedor) & "', '" & (cantidad) & "','" & (descripcion) & "','" & (comentario) & "','EN ESPERA', '" & (prioridad) & "',  '" & (Form_pedidos.txt_codigo_pedido.Text) & "', '" & (miusuario) & "')"

            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
    End Sub

    'Sub mostrar_datos_login()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from usuarios where rut_usuario ='" & (miusuario) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        lbl_usuario_conectado.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario") & "  (" & DS.Tables(DT.TableName).Rows(0).Item("area_usuario") & ")"
    '    End If
    '    conexion.Close()
    'End Sub





    'Private Structure LASTINPUTINFO
    '    Public cbSize As UInteger
    '    Public dwTime As UInteger
    'End Structure

    '<DllImport("User32.dll")> _
    'Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    'End Function

    'Public Function GetInactiveTime() As Nullable(Of TimeSpan)
    '    Dim info As LASTINPUTINFO = New LASTINPUTINFO
    '    info.cbSize = CUInt(Marshal.SizeOf(info))
    '    If (GetLastInputInfo(info)) Then
    '        Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    ''Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ''    Timer1.Start()
    ''End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Dim inactiveTime = GetInactiveTime()

    '    If (inactiveTime Is Nothing) Then
    '        Me.BackColor = Color.Yellow
    '    ElseIf (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
    '        If Application.OpenForms.Count = 2 Then
    '            form_Menu_admin.Enabled = False
    '            form_Ingreso.Show()
    '            form_Ingreso.txt_usuario.Focus()
    '            Me.Close()
    '        Else
    '            Me.Close()
    '        End If
    '    End If
    'End Sub


    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        Dim Font2 As New Font("arial", 9, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        Try
            Dim im As Image = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
            Dim p As New PointF(0, 0)
            e.Graphics.DrawImage(im, p)
        Catch
        End Try

        'e.Graphics.DrawString("             " & migiroempresa, Font3, Brushes.Black, 30, 60)
        'e.Graphics.DrawString("      " & midireccionempresa, Font3, Brushes.Black, 30, 75)
        'e.Graphics.DrawString("                       " & miciudadempresa, Font3, Brushes.Black, 30, 90)
        'e.Graphics.DrawString("  " & mitelefonoempresa, Font3, Brushes.Black, 30, 105)
        'e.Graphics.DrawString("      " & micorreoempresa, Font3, Brushes.Black, 30, 120)
        'e.Graphics.DrawString("                           " & mirutempresa, Font3, Brushes.Black, 30, 135)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim rect1 As New Rectangle(10, 60, 270, 15)
        Dim rect2 As New Rectangle(10, 75, 270, 15)
        Dim rect3 As New Rectangle(10, 90, 270, 15)
        Dim rect4 As New Rectangle(10, 105, 270, 15)
        Dim rect5 As New Rectangle(10, 120, 270, 15)
        Dim rect6 As New Rectangle(10, 135, 270, 15)

        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

        e.Graphics.DrawString("TICKET DE ENCARGO PARA REPUESTO", Font2, Brushes.Black, 15, 165)

        e.Graphics.DrawString("COD. PREDIDO", Font3, Brushes.Black, 0, 195)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 195)
        e.Graphics.DrawString(txt_codigo_pedido.Text, Font4, Brushes.Black, 80, 195)
        e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 210)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 210)
        e.Graphics.DrawString(dtp_fecha_pedido.Text, Font1, Brushes.Black, 80, 210)
        e.Graphics.DrawString("VENDEDOR", Font3, Brushes.Black, 0, 225)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 225)
        e.Graphics.DrawString(minombre, Font1, Brushes.Black, 80, 225)
        e.Graphics.DrawString("TELEFONO", Font3, Brushes.Black, 0, 240)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 75, 240)
        e.Graphics.DrawString(mitelefono, Font1, Brushes.Black, 80, 240)

        e.Graphics.DrawString("CODIGO", Font3, Brushes.Black, 0, 255)
        e.Graphics.DrawString("DESCRIPCION", Font3, Brushes.Black, 65, 255)
        e.Graphics.DrawString("CANT.", Font3, Brushes.Black, 190, 255)
        e.Graphics.DrawString("LLEGADA", Font3, Brushes.Black, 230, 255)

        e.Graphics.DrawLine(Pens.Black, 1, 360, 300, 270)

        Dim codigo_producto As String
        Dim proveedor As String
        Dim cantidad As String
        Dim descripcion As String
        Dim comentario As String
        Dim estado As String

        Dim fecha_llegada As String

        For i = 0 To grilla_pedidos.Rows.Count - 1
            codigo_producto = grilla_pedidos.Rows(i).Cells(0).Value.ToString
            proveedor = grilla_pedidos.Rows(i).Cells(7).Value.ToString
            cantidad = grilla_pedidos.Rows(i).Cells(2).Value.ToString
            descripcion = grilla_pedidos.Rows(i).Cells(3).Value.ToString
            comentario = grilla_pedidos.Rows(i).Cells(4).Value.ToString
            estado = grilla_pedidos.Rows(i).Cells(5).Value.ToString
            fecha_llegada = grilla_pedidos.Rows(i).Cells(6).Value.ToString



            Dim descripcion_caracteres As String
            descripcion_caracteres = descripcion
            If descripcion.Length > 18 Then
                descripcion_caracteres = descripcion.Substring(0, 18)
            End If




            e.Graphics.DrawString(codigo_producto, Font1, Brushes.Gray, 0, 265 + (i * 15))
            e.Graphics.DrawString(descripcion_caracteres, Font1, Brushes.Gray, 65, 265 + (i * 15))
            e.Graphics.DrawString(cantidad, Font1, Brushes.Gray, 218, 265 + (i * 15), format1)
            e.Graphics.DrawString(fecha_llegada, Font1, Brushes.Gray, 230, 265 + (i * 15))
        Next

        Dim var_grilla As Integer
        var_grilla = ((grilla_pedidos.Rows.Count - 1) * 15)

        e.Graphics.DrawString("CONFIRME LA FECHA DE LLEGADA CON SU VENDEDOR", Font3, Brushes.Gray, 5, var_grilla + 600)
        e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, var_grilla + 660)
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

    Private Sub Timer_inactividad_pedidos_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_inactividad_pedidos.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub


End Class