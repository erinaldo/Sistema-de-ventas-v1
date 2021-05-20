Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_reservas

    Private Sub Form_reservas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_reservas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If


        If e.KeyCode = Keys.F4 Then
            Form_buscador_productos_reservas.Show()
            conexion.Close()
            Me.Enabled = False
            Form_buscador_productos_reservas.Show()
            Form_buscador_productos_reservas.txt_busqueda.Focus()
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

    Private Sub Form_reservas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        cargar_foto()
        mostrar_datos_login()
        dtp_desde.CustomFormat = "yyy-MM-dd"
        dtp_hasta.CustomFormat = "yyy-MM-dd"
        cargar_reservas()
        calcular_totales()
    End Sub

    Sub mostrar_datos_login()
        lbl_usuario_conectado.Text = minombre
    End Sub

    Sub cargar_foto()
        Dim ruta_fotografia As String
        ruta_fotografia = ""

        conexion.Close()

        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select ruta_imagen_fotografia from rutas_imagenes"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            ruta_fotografia = DS.Tables(DT.TableName).Rows(0).Item("ruta_imagen_fotografia")
        End If
        conexion.Close()

        Try
            PictureBox_imagen.ImageLocation = ruta_fotografia & miusuario & ".jpg"
        Catch
        End Try

    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_datos_productos()
        If txt_codigo.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                ' txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                txt_cantidad_agregar.Text = "1"
                txt_cantidad_agregar.Focus()
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress

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

        'If e.KeyChar = "*" Then
        '    e.KeyChar = ""
        'End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If


        limpiar_producto()
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_codigo.Text = "" Then
                Exit Sub
            End If



            limpiar_producto()
            mostrar_datos_productos()
            mostrar_nombre_proveedor()






        End If


    End Sub

    Sub mostrar_nombre_proveedor()
        conexion.Close()
        If txt_proveedor.Text <> "" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            txt_nombre_proveedor.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            End If
            conexion.Close()
        End If
    End Sub


    Sub limpiar_producto()
        'lbl_codigo.Text = "nada"
        'txt_codigo.Text = ""
        'txt_codigo.Text = ""
        txt_cantidad.Text = ""
        txt_nombre_producto.Text = ""
        'txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        txt_factor.Text = ""
        '  txt_codigo.Text = ""
        txt_numero_tecnico.Text = ""
        txt_marca.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If txt_codigo.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO PRODUCTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_nombre_producto.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO PRODUCTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = "0" Then
            txt_cantidad_agregar.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim total As String
        total = (txt_precio.Text * txt_cantidad_agregar.Text)

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_cantidad_agregar.Text, txt_precio.Text, total, Form_menu_principal.dtp_fecha.Text)


        SC.Connection = conexion
        SC.CommandText = "insert into  reservas (cod_producto, cantidad, precio, total, fecha, usuario_responsable, nombre_producto, numero_tecnico) values ('" & (txt_codigo.Text) & "','" & (txt_cantidad_agregar.Text) & "','" & (txt_precio.Text) & "','" & (total) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (miusuario) & "','" & (txt_nombre_producto.Text) & "','" & (txt_numero_tecnico.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        limpiar_producto()
        txt_codigo.Text = ""
        txt_cantidad_agregar.Text = ""
        calcular_totales()
        txt_codigo.Focus()
    End Sub


    Sub cargar_reservas()

        dtp_desde.Value = dtp_desde.Value.AddDays(Val(-7))

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from reservas where fecha >='" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and usuario_responsable= '" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        ' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                '   grilla_detalle_venta.Rows.Clear()


                Dim fecha_reserva As String

                fecha_reserva = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                If fecha_reserva.Length > 10 Then
                    fecha_reserva = fecha_reserva.Substring(0, 10)
                End If


                grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("nombre_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("precio"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                    fecha_reserva)
            Next
        End If

    End Sub

    Sub calcular_totales()

        Dim totalgrilla As Long

        '//Calcular el descuento
        lbl_venta.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            totalgrilla = Val(grilla_detalle_venta.Rows(i).Cells(5).Value.ToString)
            lbl_venta.Text = Val(lbl_venta.Text) + Val(totalgrilla)
        Next

        If lbl_venta.Text = "" Or lbl_venta.Text = "0" Then
            lbl_venta.Text = "$0"
        Else
            lbl_venta.Text = "$" & Format(Int(lbl_venta.Text), "###,###,###")
        End If


        lbl_venta.Location = New Point(1024 - lbl_venta.Width - 7, 30)
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_detalle_venta.Rows.Count > 0 Then

            Dim codigo_reserva As String
            Dim cantidad_reserva As String
            Dim fecha_reserva As Date

            codigo_reserva = grilla_detalle_venta.CurrentRow.Cells(0).Value
            cantidad_reserva = grilla_detalle_venta.CurrentRow.Cells(3).Value
            fecha_reserva = grilla_detalle_venta.CurrentRow.Cells(6).Value

            fecha_reserva = fecha_reserva.ToString("yyy-MM-dd")

            Dim mifecha2 As String
            Dim mifecha As Date
            mifecha = fecha_reserva
            mifecha2 = mifecha.ToString("yyy-MM-dd")

            SC.Connection = conexion
            SC.CommandText = "delete from reservas where cod_producto = '" & (codigo_reserva) & "' and cantidad = '" & (cantidad_reserva) & "' and fecha = '" & (mifecha2) & "' and usuario_responsable = '" & (miusuario) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.CurrentRow)
            calcular_totales()
            txt_codigo.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_agregar.KeyPress

        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

        If e.KeyChar = "-" Then
            e.KeyChar = ""
        End If



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



        If IsNumeric(txt_cantidad_agregar.Text) = False Then
            txt_cantidad_agregar.Text = "0"
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_agregar.PerformClick()
        End If
    End Sub

    Private Sub txt_cantidad_agregar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.TextChanged
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, "  ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, "   ", ""))
        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, "    ", ""))

        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, "  ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, "   ", ""))
        Me.txt_cantidad_agregar.Text = LTrim(Replace(Me.txt_cantidad_agregar.Text, "    ", ""))

        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, "  ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, "   ", ""))
        Me.txt_cantidad_agregar.Text = RTrim(Replace(Me.txt_cantidad_agregar.Text, "    ", ""))
    End Sub


    Private Sub txt_cantidad_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.GotFocus
        txt_cantidad_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White


        Dim primer_caracter As String
        Dim ultimo_caracter As String
        Dim total_caracter As String
        total_caracter = ""

        If txt_cantidad_agregar.Text = "" Then
            primer_caracter = 0
            ultimo_caracter = 0
        Else
            primer_caracter = txt_cantidad_agregar.Text.Length - txt_cantidad_agregar.Text.Length + 1
            ultimo_caracter = txt_cantidad_agregar.Text.Length
            total_caracter = txt_cantidad_agregar.Text
        End If



        Dim n1 As Byte, lMal As Boolean


        If txt_cantidad_agregar.Text <> "" Then

            For n1 = ultimo_caracter To ultimo_caracter
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("DIGITO INCORRECTO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_cantidad_agregar.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next

            For n1 = 1 To 1
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("DIGITO INCORRECTO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_cantidad_agregar.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next



        End If
    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_productos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.GotFocus
        btn_buscar_productos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub bbtn_buscar_productos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.LostFocus
        btn_buscar_productos.BackColor = Color.Transparent
    End Sub






    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.Click
        Form_buscador_productos_reservas.Show()
        conexion.Close()
        ' txt_codigo.Focus()
        '   Me.WindowState = FormWindowState.Minimized
        Me.Enabled = False
        Form_buscador_productos_reservas.Show()
        Form_buscador_productos_reservas.txt_busqueda.Focus()


    End Sub


End Class