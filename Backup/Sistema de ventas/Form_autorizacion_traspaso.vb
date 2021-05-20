Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Form_autorizacion_traspaso
    Dim alto_cotizacion As String
    Private WithEvents Pd As New PrintDocument

    Private Sub Form_autorizacion_traspaso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_envio_productos_sucursal.WindowState = FormWindowState.Normal
        Form_envio_productos_sucursal.Enabled = True
    End Sub

    Private Sub Form_autorizacion_traspaso_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_autorizacion_traspaso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        'asdasd()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "Select * from usuarios where Usuario = '" & (txt_usuario.Text) & "' and Clave ='" & (txt_clave.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then




            Dim VarCodProducto As String
            Dim varnombre As String
            Dim vartecnico As String
            Dim VarNrotecnico As String
            Dim VarAplicacion As String
            Dim VarCantidad As String
            Dim Varfecha As String
            Dim Varhora As String
            Dim VarDespachador As String
            Dim VarUsuario As String
            Dim VarNrovale As String
            Dim VarSucursal As String
            Dim VarNombreproducto As String
            Dim VarAplicacionproducto As String
            Dim VarMarca As String
            Dim varCodbarra As String
            Dim varFamilia As String
            Dim VarSubfamilia As String
            Dim VarSubfamilia2 As String
            Dim VarCantidadminima As String
            Dim VarPrecio As String
            Dim VarTipoprecio As String
            Dim VarFactor As String
            Dim VarCosto As String
            Dim VarRutproveedor As String
            Dim VarFechaultcompra As String
            Dim VarCantultcompra As String
            Dim VarTipodoc As String
            Dim VarNrodoc As String

            For i = 0 To Form_envio_productos_sucursal.grilla_entra.Rows.Count - 1

                VarCodProducto = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(0).Value.ToString
                varnombre = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(1).Value.ToString
                vartecnico = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(2).Value.ToString
                VarAplicacion = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(3).Value.ToString
                VarCantidad = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(4).Value.ToString
                Varfecha = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(5).Value.ToString
                Varhora = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(6).Value.ToString
                VarDespachador = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(7).Value.ToString
                VarUsuario = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(8).Value.ToString
                VarNrovale = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(9).Value.ToString
                VarSucursal = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(10).Value.ToString
                VarNombreproducto = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(11).Value.ToString
                VarAplicacionproducto = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(12).Value.ToString
                VarNrotecnico = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(13).Value.ToString
                VarMarca = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(14).Value.ToString
                varCodbarra = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(15).Value.ToString
                varFamilia = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(16).Value.ToString
                VarSubfamilia = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(17).Value.ToString
                VarSubfamilia2 = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(18).Value.ToString
                VarCantidadminima = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(19).Value.ToString
                VarPrecio = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(20).Value.ToString
                VarTipoprecio = "1"
                VarFactor = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(22).Value.ToString
                VarCosto = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(23).Value.ToString
                VarRutproveedor = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(24).Value.ToString
                VarFechaultcompra = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(25).Value.ToString
                VarCantultcompra = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(26).Value.ToString
                VarTipodoc = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(27).Value.ToString
                VarNrodoc = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(28).Value.ToString
                '  varRevizar = Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(30).Value.ToString


                Dim mifecha3 As Date
                mifecha3 = VarFechaultcompra
                VarFechaultcompra = mifecha3.ToString("yyy-MM-dd")


                If Form_envio_productos_sucursal.grilla_entra.Rows(i).Cells(30).Value = True Then



                    Consultas_SQL("select * from productos where cod_producto = '" & (VarCodProducto) & "'")

                    If DS.Tables(DT.TableName).Rows.Count = 0 Then

                        SC.Connection = conexion
                        SC.CommandText = "INSERT INTO productos(cod_producto, nombre, marca, aplicacion, numero_tecnico, cantidad, precio, costo, factor, familia, subfamilia, subfamilia_dos, proveedor, codigo_barra,   ultima_compra, cantidad_ultima_compra, nro_doc, tipo_doc, cantidad_minima, fecha_modificacion, tipo_precio, activo) VALUES ('" & (VarCodProducto) & "','" & (VarNombreproducto) & "','" & (VarMarca) & "','" & (VarAplicacionproducto) & "','" & (VarNrotecnico) & "','" & (VarCantidad) & "','" & (VarPrecio) & "','" & (VarCosto) & "','" & (VarFactor) & "','" & (varFamilia) & "','" & (VarSubfamilia) & "','" & (VarSubfamilia2) & "','" & (VarRutproveedor) & "','" & (varCodbarra) & "', '" & (VarFechaultcompra) & "','" & (VarCantultcompra) & "', '" & (VarNrodoc) & "', '" & (VarTipodoc) & "', '" & (VarCantidadminima) & "', '0000-00-00', '" & (VarTipoprecio) & "','SI')"

                        DA.SelectCommand = SC
                        DA.Fill(DT)

                        SC.Connection = conexion
                        SC.CommandText = "INSERT INTO codigos_de_barra(codigo_barra, codigo_interno) VALUES ('" & (varCodbarra) & "','" & (VarCodProducto) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                    Else

                        SC.Connection = conexion
                        SC.CommandText = "UPDATE  productos SET NOMBRE='" & (VarNombreproducto) & "', marca='" & (VarMarca) & "',aplicacion='" & (VarAplicacionproducto) & "', numero_tecnico = '" & (VarNrotecnico) & "', familia = '" & (varFamilia) & "', subfamilia = '" & (VarSubfamilia) & "',  subfamilia_dos = '" & (VarSubfamilia2) & "', cantidad = cantidad + '" & (VarCantidad) & "' , precio = '" & (VarPrecio) & "' ,  COSTO = '" & (VarCosto) & "' , factor = '" & (VarFactor) & "' ,  codigo_barra = '" & (varCodbarra) & "',  fecha_modificacion ='0000-00-00', tipo_precio= '1', ACTIVO= 'SI' WHERE cod_producto = " & (VarCodProducto) & ""
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                    End If

                    SC.Connection = conexion
                    SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (VarNrovale) & ",'VALE DE TRASLADO', '" & (VarCodProducto) & "','" & (VarNombreproducto) & "'," & (VarPrecio) & ",'" & (VarCantidad) & "'," & (0) & "," & (0) & ", " & (0) & "," & (Val(VarCantidad) * Val(VarPrecio)) & "," & (Val(VarCantidad) * Val(VarPrecio)) & ",'ENTRA','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (miusuario) & "' ,'EMITIDA')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    Try
                        SC.Connection = conexion
                        SC.CommandText = "insert into envios_recibidos (n_documento, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (VarNrovale) & ",'VALE DE TRASLADO', '" & (VarCodProducto) & "','" & (VarNombreproducto) & "'," & (VarPrecio) & ",'" & (VarCantidad) & "'," & (0) & "," & (0) & ", " & (0) & "," & (Val(VarCantidad) * Val(VarPrecio)) & "," & (Val(VarCantidad) * Val(VarPrecio)) & ",'ENTRA','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (miusuario) & "' ,'EMITIDA')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                    Catch
                    End Try

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE  vale_traslado_recibidos SET estado='RECIBIDO' WHERE N_VALE = " & (VarNrovale) & " AND CODIGO_PRODUCTO = " & (VarCodProducto) & ""
                    DA.SelectCommand = SC
                    DA.Fill(DT)



                    'Dim nombre_servidor As String
                    'Dim nombre_servidor_remoto As String
                    'Dim base_de_datos As String
                    'Dim clave_base_de_datos As String
                    'Dim usuario As String
                    'Dim recinto As String
                    'Dim rut_empresa As String

                    'For u = 0 To form_Menu_admin.grilla_conexiones.Rows.Count - 1
                    '    nombre_servidor = form_Menu_admin.grilla_conexiones.Rows(u).Cells(0).Value.ToString
                    '    nombre_servidor_remoto = form_Menu_admin.grilla_conexiones.Rows(u).Cells(1).Value.ToString
                    '    base_de_datos = form_Menu_admin.grilla_conexiones.Rows(u).Cells(2).Value.ToString
                    '    clave_base_de_datos = form_Menu_admin.grilla_conexiones.Rows(u).Cells(3).Value.ToString
                    '    usuario = form_Menu_admin.grilla_conexiones.Rows(u).Cells(4).Value.ToString
                    '    recinto = form_Menu_admin.grilla_conexiones.Rows(u).Cells(5).Value.ToString
                    '    rut_empresa = form_Menu_admin.grilla_conexiones.Rows(u).Cells(6).Value.ToString

                    '    recinto = Trim(Replace(recinto, "'", "´"))

                    '    If VarSucursal = recinto Then

                    '        conexion.Close()
                    '        conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                    '        Try

                    '            conexion.Open()
                    '            conexion.Close()

                    '        Catch mierror As MySqlException
                    '            conexion.Close()
                    '            conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    '        Catch mierror As MissingManifestResourceException
                    '            conexion.Close()
                    '            conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    '        End Try
                    '        Exit For
                    '    End If
                    'Next

                    'SC.Connection = conexion
                    'SC.CommandText = "UPDATE vale SET estado='RECIBIDO' WHERE N_VALE = " & (VarNrovale) & "  AND CODIGO_PRODUCTO = " & (VarCodProducto) & ""
                    'DA.SelectCommand = SC
                    'DA.Fill(DT)

                    'recuperar_conexion()

                End If
            Next













            Form_envio_productos_sucursal.mostrar_malla()

            Form_envio_productos_sucursal.txt_codigo.Focus()


            Me.Close()

        Else
            MsgBox("USUARIO O CLAVE INCORRECTOS", 0 + 16, "ATENCION")

            txt_usuario.Text = ""
            txt_clave.Text = ""
            txt_usuario.Focus()
            conexion.Close()
            DS.Tables.Clear()
            Exit Sub
        End If


    End Sub



    Private Sub txt_clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_clave.KeyPress
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
            btn_aceptar.PerformClick()
        End If
    End Sub


    Private Sub txt_clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_clave.TextChanged

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub txt_usuario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_usuario.GotFocus
        txt_usuario.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_usuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_usuario.KeyPress
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
            txt_clave.Focus()
        End If
    End Sub

    Private Sub txt_usuario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_usuario.LostFocus
        txt_usuario.BackColor = Color.White
    End Sub

    Private Sub txt_clave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave.GotFocus
        txt_clave.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_clave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave.LostFocus
        txt_clave.BackColor = Color.White
    End Sub

    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        btn_aceptar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Sub recuperar_conexion()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String
        Try
            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

                If SucursalSeleccionada = recinto Then
                    Try
                        conexion.Close()
                        conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    Catch
                        conexion.Close()
                        conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    End Try
                End If
            Next
        Catch
            Me.Close()
            Form_menu_principal.Close()
        End Try
    End Sub
End Class