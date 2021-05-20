Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_traspaso_stock

    Private Sub Form_traspaso_stock_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_traspaso_stock_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_traspaso_stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
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
            Try
                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_cantidad_final.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                    txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    dtp_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
                    txt_cantidad_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
                    txt_codigo_2.Focus()
                Else
                    MsgBox("CODIGO NO EXISTENTE", 0 + 16, "ERROR")
                    conexion.Close()
                End If

            Catch err As InvalidCastException
                Exit Sub
            End Try
            conexion.Close()
        End If
    End Sub

    Sub calcular_cantidad()
        Dim cantidad_agregar_2 As Integer
        Dim cantidad_agregar_3 As Integer

        Dim cantidad_2 As Integer
        Dim cantidad_3 As Integer

        If txt_cantidad_agregar_dos.Text = "" Then
            cantidad_agregar_2 = 0
        Else
            cantidad_agregar_2 = txt_cantidad_agregar_dos.Text
        End If

        If txt_cantidad_agregar_tres.Text = "" Then
            cantidad_agregar_3 = 0
        Else
            cantidad_agregar_3 = txt_cantidad_agregar_tres.Text
        End If


        If txt_cantidad.Text = "" Then
            txt_cantidad.Text = "0"
        End If
        If txt_cantidad_2.Text = "" Then
            cantidad_2 = 0
        Else
            cantidad_2 = txt_cantidad_2.Text
        End If

        If txt_cantidad_3.Text = "" Then
            cantidad_3 = 0
        Else
            cantidad_3 = txt_cantidad_3.Text
        End If


        txt_cantidad_final.Text = txt_cantidad.Text - cantidad_agregar_2 - cantidad_agregar_3

        txt_cantidad_final_2.Text = (cantidad_2) + (cantidad_agregar_2)

        txt_cantidad_final_3.Text = (cantidad_3) + (cantidad_agregar_3)


    End Sub

    Sub mostrar_datos_productos_2()
        If txt_codigo.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_2.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_codigo_2.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_nombre_2.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_marca_2.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_aplicacion_2.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    txt_numero_tecnico_2.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    txt_cantidad_2.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_cantidad_final_2.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_costo_2.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                    txt_precio_2.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    dtp_ultima_compra_2.Text = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
                    txt_cantidad_ultima_compra_2.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
                    txt_cantidad_agregar_dos.Focus()
                Else
                    MsgBox("CODIGO NO EXISTENTE", 0 + 16, "ERROR")
                    conexion.Close()
                End If

            Catch err As InvalidCastException
                Exit Sub
            End Try
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_productos_3()
        If txt_codigo.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_3.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_codigo_3.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_nombre_3.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_marca_3.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_aplicacion_3.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    txt_numero_tecnico_3.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    txt_cantidad_3.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_cantidad_final_3.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_costo_3.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                    txt_precio_3.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    dtp_ultima_compra_3.Text = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
                    txt_cantidad_ultima_compra_3.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
                    txt_cantidad_agregar_tres.Focus()
                Else
                    MsgBox("CODIGO NO EXISTENTE", 0 + 16, "ERROR")
                    conexion.Close()
                End If

            Catch err As InvalidCastException
                Exit Sub
            End Try
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

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If



        limpiar_producto()


        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
            calcular_cantidad()
        End If
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub

    Private Sub txt_codigo_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_2.KeyPress
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





        limpiar_producto_2()


        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos_2()
            calcular_cantidad()
        End If
    End Sub

    Private Sub txt_codigo_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_2.TextChanged

    End Sub

    Private Sub txt_codigo_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_3.KeyPress
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
            mostrar_datos_productos_3()
            calcular_cantidad()
        End If
    End Sub



    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If txt_codigo.Text <> "" And txt_nombre.Text <> "" And txt_cantidad.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_codigo_2.Text <> "" And txt_nombre_2.Text <> "" And txt_cantidad_agregar_dos.Text = "" Then
            txt_codigo_2.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_codigo_3.Text <> "" And txt_nombre_3.Text <> "" And txt_cantidad_agregar_tres.Text = "" Then
            txt_codigo_3.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If



        If txt_codigo.Text = "" And txt_nombre.Text = "" And txt_cantidad.Text <> "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR O VACIAR EL CAMPO CANTIDAD", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_codigo_2.Text = "" And txt_nombre_2.Text = "" And txt_cantidad_agregar_dos.Text <> "" Then
            txt_codigo_2.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR O VACIAR EL CAMPO CANTIDAD", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_codigo_3.Text = "" And txt_nombre_3.Text = "" And txt_cantidad_agregar_tres.Text <> "" Then
            txt_codigo_3.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR O VACIAR EL CAMPO CANTIDAD", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        crear_nro_ajuste()

        If txt_codigo.Text <> "" And txt_nombre.Text <> "" And txt_cantidad_final.Text <> "" Then
            Try
                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET cantidad = '" & (txt_cantidad_final.Text) & "', precio = '" & (txt_precio.Text) & "' WHERE cod_producto = " & (txt_codigo.Text) & ""
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into ajustes_de_stock (n_ajuste, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado, hora) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (txt_codigo.Text) & "','" & (txt_nombre.Text) & "'," & (txt_precio.Text) & ",'" & (txt_cantidad_final.Text) & "','0','0','0','0','0','AJUSTE', '" & (Form_menu_principal.dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA', '" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Catch err As InvalidCastException

            End Try
        End If

        If txt_codigo_2.Text <> "" And txt_nombre_2.Text <> "" And txt_cantidad_final_2.Text <> "" Then
            Try
                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET cantidad = '" & (txt_cantidad_final_2.Text) & "', precio = '" & (txt_precio_2.Text) & "' WHERE cod_producto = " & (txt_codigo_2.Text) & ""
                DA.SelectCommand = SC
                DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (txt_codigo_2.Text) & "','" & (txt_nombre_2.Text) & "'," & (txt_precio_2.Text) & "," & (txt_cantidad_final_2.Text) & ",'0','0','0','0','0','AJUSTE')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into ajustes_de_stock (n_ajuste, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado, hora) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (txt_codigo_2.Text) & "','" & (txt_nombre_2.Text) & "'," & (txt_precio_2.Text) & ",'" & (txt_cantidad_final_2.Text) & "','0','0','0','0','0','AJUSTE', '" & (Form_menu_principal.dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA', '" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Catch err As InvalidCastException

            End Try
        End If

        If txt_codigo_3.Text <> "" And txt_nombre_3.Text <> "" And txt_cantidad_final_3.Text <> "" Then
            Try
                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET cantidad = '" & (txt_cantidad_final_3.Text) & "', precio = '" & (txt_precio_3.Text) & "' WHERE cod_producto = " & (txt_codigo_3.Text) & ""
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into ajustes_de_stock (n_ajuste, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado, hora) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (txt_codigo_3.Text) & "','" & (txt_nombre_3.Text) & "'," & (txt_precio_3.Text) & ",'" & (txt_cantidad_final_3.Text) & "','0','0','0','0','0','AJUSTE', '" & (Form_menu_principal.dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA', '" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)


            Catch err As InvalidCastException

            End Try
        End If

        MsgBox("STOCK ACTUALIZADO CON EXITO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

        limpiar()
    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad.TextChanged

    End Sub

    Private Sub txt_cantidad_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_2.TextChanged

    End Sub

    Private Sub txt_cantidad_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_3.TextChanged

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad.GotFocus
        txt_cantidad.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad.LostFocus
        txt_cantidad.BackColor = Color.White
    End Sub



    Private Sub txt_codigo_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_2.GotFocus
        txt_codigo_2.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_2.LostFocus
        txt_codigo_2.BackColor = Color.White
    End Sub

    Private Sub txt_codigo_3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_3.GotFocus
        txt_codigo_3.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_3.LostFocus
        txt_codigo_3.BackColor = Color.White
    End Sub


    Private Sub txt_precio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio.GotFocus
        txt_precio.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_precio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio.LostFocus
        txt_precio.BackColor = Color.White
    End Sub

    Private Sub txt_precio_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_2.GotFocus
        txt_precio_2.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_precio_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_2.LostFocus
        txt_precio_2.BackColor = Color.White
    End Sub

    Private Sub txt_precio_3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_3.GotFocus
        txt_precio_3.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_precio_3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_3.LostFocus
        txt_precio_3.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_agregar_dos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar_dos.GotFocus
        txt_cantidad_agregar_dos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar_dos.LostFocus
        txt_cantidad_agregar_dos.BackColor = Color.White
    End Sub



    Private Sub txt_cantidad_agregar_tres_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar_tres.GotFocus
        txt_cantidad_agregar_tres.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_agregar_tres_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar_tres.LostFocus
        txt_cantidad_agregar_tres.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_3.GotFocus
        txt_cantidad_3.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_3.LostFocus
        txt_cantidad_3.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_agregar_dos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_agregar_dos.KeyPress

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
            txt_codigo_3.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_agregar_dos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar_dos.TextChanged
        calcular_cantidad()
    End Sub

    Private Sub txt_cantidad_agregar_tres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_agregar_tres.KeyPress
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
    End Sub

    Private Sub txt_cantidad_agregar_tres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar_tres.TextChanged
        calcular_cantidad()
    End Sub

    Private Sub txt_cantidad_final_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_final_3.TextChanged
        calcular_cantidad()
    End Sub

    Sub limpiar_producto()
        txt_nombre.Text = ""
        txt_marca.Text = ""
        txt_aplicacion.Text = ""
        txt_precio.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad.Text = ""
        txt_costo.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_cantidad_final.Text = ""
    End Sub

    Sub limpiar_producto_2()
        txt_nombre_2.Text = ""
        txt_marca_2.Text = ""
        txt_aplicacion_2.Text = ""
        txt_precio_2.Text = ""
        txt_numero_tecnico_2.Text = ""
        txt_cantidad_2.Text = ""
        txt_costo_2.Text = ""
        txt_cantidad_ultima_compra_2.Text = ""
        dtp_ultima_compra_2.Text = ""
        txt_cantidad_ultima_compra_2.Text = ""
        txt_cantidad_final_2.Text = ""
        txt_cantidad_agregar_dos.Text = ""
    End Sub

    Sub limpiar_producto_3()
        txt_nombre_3.Text = ""
        txt_marca_3.Text = ""
        txt_aplicacion_3.Text = ""
        txt_precio_3.Text = ""
        txt_numero_tecnico_3.Text = ""
        txt_cantidad_3.Text = ""
        txt_costo_3.Text = ""
        txt_cantidad_ultima_compra_3.Text = ""
        dtp_ultima_compra_3.Text = ""
        txt_cantidad_ultima_compra_3.Text = ""
        txt_cantidad_final_3.Text = ""
        txt_cantidad_agregar_tres.Text = ""
    End Sub


    Sub limpiar()
        txt_codigo.Text = ""
        txt_codigo_2.Text = ""
        txt_codigo_3.Text = ""

        txt_nombre.Text = ""
        txt_marca.Text = ""
        txt_aplicacion.Text = ""
        txt_precio.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad.Text = ""
        txt_costo.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_cantidad_final.Text = ""

        txt_nombre_2.Text = ""
        txt_marca_2.Text = ""
        txt_aplicacion_2.Text = ""
        txt_precio_2.Text = ""
        txt_numero_tecnico_2.Text = ""
        txt_cantidad_2.Text = ""
        txt_costo_2.Text = ""
        txt_cantidad_ultima_compra_2.Text = ""
        dtp_ultima_compra_2.Text = ""
        txt_cantidad_ultima_compra_2.Text = ""
        txt_cantidad_final_2.Text = ""
        txt_cantidad_agregar_dos.Text = ""

        txt_nombre_3.Text = ""
        txt_marca_3.Text = ""
        txt_aplicacion_3.Text = ""
        txt_precio_3.Text = ""
        txt_numero_tecnico_3.Text = ""
        txt_cantidad_3.Text = ""
        txt_costo_3.Text = ""
        txt_cantidad_ultima_compra_3.Text = ""
        dtp_ultima_compra_3.Text = ""
        txt_cantidad_ultima_compra_3.Text = ""
        txt_cantidad_final_3.Text = ""
        txt_cantidad_agregar_tres.Text = ""

    End Sub
    Sub crear_nro_ajuste()
        Dim varnumajuste As Integer
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        Try
            SC.Connection = conexion
            SC.CommandText = "select max(n_total) as n_total from total where MOVIMIENTO= 'AJUSTE'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumajuste = DS.Tables(DT.TableName).Rows(0).Item("n_total")
                txt_nro_ajuste.Text = varnumajuste + 1
            End If
        Catch err As InvalidCastException
            txt_nro_ajuste.Text = 1
        End Try
        conexion.Close()
    End Sub

    Private Sub txt_precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio.KeyPress


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
    End Sub

    Private Sub txt_precio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio.TextChanged

    End Sub

    Private Sub txt_precio_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio_2.KeyPress
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
    End Sub

    Private Sub txt_precio_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio_2.TextChanged

    End Sub

    Private Sub txt_precio_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio_3.KeyPress
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
    End Sub

    Private Sub txt_precio_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio_3.TextChanged

    End Sub

    Private Sub txt_codigo_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_3.TextChanged

    End Sub

 
End Class