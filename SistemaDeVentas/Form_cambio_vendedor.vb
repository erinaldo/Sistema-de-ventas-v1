Imports System.Drawing.Drawing2D

Public Class Form_cambio_vendedor



    Private Sub Form_cambio_vendedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_cambio_vendedor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    'llamamaos al sub fecha.
    'llenamos el combo vendedor con todos los usuarios que sean TIPO ventas.

    Private Sub Form_cambio_vendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        llenar_combo_vendedor()
        combo_vendedor.Enabled = False

        txt_nombre_vendedor.Enabled = False
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    'actualizamos la tabla usuarios.
    Sub actualizar_tabla_usuarios()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from usuarios"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    'limpamos la pantalla.
    Sub limpiar()
        txt_rut.Text = ""
        txt_direccion.Text = ""
        txt_nombre_cliente.Text = ""
        txt_direccion.Text = ""
        txt_telefono.Text = ""

        txt_rut_vendedor_erroneo.Text = ""
        combo_vendedor.Text = ""
        txt_nombre_vendedor_erroneo.Text = ""
        txt_nombre_vendedor.Text = ""
        combo_documentos.Text = ""
        combo_numero.Text = ""

        migrilla.DataSource = Nothing
        migrilla_detalle.DataSource = Nothing
    End Sub

    'llamamos al sub fecha.
    'llenamos el combo numero segun la seleccion del documento que realicemos.
    'limpiamos el lbl datos o le ingresamos el mensaje segun la seleccion.
    'limpiamos el combo numero.
    Private Sub combo_documentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documentos.SelectedIndexChanged
        If combo_documentos.Text = "FACTURA" Then

            limpiar()
            llenar_combo_numero_factura()
            lbl_datos.Text = ""
            combo_numero.Text = ""
            Exit Sub
        End If

        If combo_documentos.Text = "FACTURA CREDITO" Then
            'fecha()
            limpiar()
            llenar_combo_numero_factura_credito()

            lbl_datos.Text = ""
            combo_numero.Text = ""
            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA" Then
            'fecha()
            limpiar()
            llenar_combo_numero_boletas()
            lbl_datos.Text = "* EN BOLETAS NO SE GRABAN DATOS DE LOS CLIENTES"
            combo_numero.Text = ""
            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA CREDITO" Then
            'fecha()
            limpiar()
            llenar_combo_numero_guias()
            lbl_datos.Text = ""
            combo_numero.Text = ""
            Exit Sub
        End If
        If combo_documentos.Text = "GUIA" Then
            'fecha()
            limpiar()
            llenar_combo_numero_guias()
            lbl_datos.Text = ""
            combo_numero.Text = ""
            Exit Sub
        End If

        If combo_documentos.Text = "COTIZACION" Then
            'fecha()
            limpiar()
            llenar_combo_numero_cotizacion()
            lbl_datos.Text = ""
            combo_numero.Text = ""
            Exit Sub
        End If
        If combo_documentos.Text = "NOTA DE CREDITO" Then
            'fecha()
            llenar_combo_numero_nota_credito()
            lbl_datos.Text = ""
            combo_numero.Text = ""
            Exit Sub
        End If
    End Sub

    'realizamos la consulta sql para seleccionar el rango de numeros segun la fecha del dia en q se ejecute.
    Sub llenar_combo_numero_factura()
        ' fecha()
        combo_numero.Items.Clear()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from factura where fecha_venta = '" & (Form_menu_principal.dtp_fecha.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                combo_numero.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("n_factura"))
            Next
        End If
        conexion.Close()
    End Sub

    'realizamos la consulta sql para seleccionar el rango de numeros segun la fecha del dia en q se ejecute.
    Sub llenar_combo_numero_factura_credito()
        'fecha()
        combo_numero.Items.Clear()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from factura_credito where fecha_venta = '" & (Form_menu_principal.dtp_fecha.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                combo_numero.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("n_factura_credito"))
            Next
        End If
        conexion.Close()
    End Sub

    'realizamos la consulta sql para seleccionar el rango de numeros segun la fecha del dia en q se ejecute.
    Sub llenar_combo_numero_guias()
        'fecha()
        combo_numero.Items.Clear()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from guia where fecha_venta = '" & (Form_menu_principal.dtp_fecha.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                combo_numero.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("n_guia"))
            Next
        End If
        conexion.Close()
    End Sub

    'realizamos la consulta sql para seleccionar el rango de numeros segun la fecha del dia en q se ejecute.
    Sub llenar_combo_numero_boletas()
        'fecha()
        combo_numero.Items.Clear()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from BOLETA where fecha_venta = '" & (Form_menu_principal.dtp_fecha.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                combo_numero.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("n_boleta"))
            Next
        End If
        conexion.Close()
    End Sub

    'realizamos la consulta sql para seleccionar el rango de numeros segun la fecha del dia en q se ejecute.
    Sub llenar_combo_numero_boleta_credito()
        ' fecha()
        combo_numero.Items.Clear()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from boleta_credito where fecha_venta = '" & (Form_menu_principal.dtp_fecha.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                combo_numero.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("n_boleta_credito"))
            Next
        End If
        conexion.Close()
    End Sub

    'realizamos la consulta sql para seleccionar el rango de numeros segun la fecha del dia en q se ejecute.
    Sub llenar_combo_numero_nota_credito()
        'fecha()
        combo_numero.Items.Clear()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from nota_credito where fecha = '" & (Form_menu_principal.dtp_fecha.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                combo_numero.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("n_nota_credito"))
            Next
        End If
        conexion.Close()
    End Sub

    'realizamos la consulta sql para seleccionar el rango de numeros segun la fecha del dia en q se ejecute.
    Sub llenar_combo_numero_cotizacion()
        'fecha()
        combo_numero.Items.Clear()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from cotizacion where fecha_venta = '" & (Form_menu_principal.dtp_fecha.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                combo_numero.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("n_cotizacion"))
            Next
        End If
        conexion.Close()
    End Sub

    'mostramos los datos de el cliente del documento seleccionado.
    'mostramos la malla general y la malla detalle del documento.
    'llenamos el combo con la info del vendedor que hara la venta.
    ' habilitamos el combo y el texbox del vendedor.
    Private Sub combo_numero_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_numero.SelectedIndexChanged
        mostrar_datos_clientes()
        mostrar_malla()
        mostrar_malla_detalle()
        llenar_combo_vendedor()
        combo_vendedor.Enabled = True

    End Sub

    'segun el documento seleccionado en el combo documento y el numero seleccionado en el combo numero llenamos la informacion del cliente que coresponda.
    Sub mostrar_datos_clientes()
        If combo_documentos.Text = "FACTURA" Then
            If combo_numero.Text <> "" Then
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from clientes, usuarios, factura where clientes.rut= factura.rut and usuarios.rut_usuario= factura.usuario and factura.n_factura ='" & (combo_numero.Text) & "'"

                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
                    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono")
                    txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
                    txt_rut_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
                    txt_nombre_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
                End If
                conexion.Close()
            End If
            Exit Sub
        End If

        If combo_documentos.Text = "FACTURA CREDITO" Then
            If combo_numero.Text <> "" Then
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from clientes, usuarios, factura_credito where clientes.rut= factura_credito.rut and usuarios.rut_usuario= factura_credito.usuario and factura_credito.n_factura_credito ='" & (combo_numero.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
                    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono")
                    txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
                    txt_rut_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
                    txt_nombre_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
                End If
                conexion.Close()
            End If
            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA CREDITO" Then
            If combo_numero.Text <> "" Then
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from clientes, usuarios, boleta_credito where clientes.rut= boleta_credito.rut and usuarios.rut_usuario= boleta_credito.usuario and boleta_credito.n_boleta_credito ='" & (combo_numero.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
                    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono")
                    txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
                    txt_rut_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
                    txt_nombre_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
                End If
                conexion.Close()
            End If
            Exit Sub
        End If

        If combo_documentos.Text = "COTIZACION" Then
            If combo_numero.Text <> "" Then
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from clientes, usuarios, cotizacion where clientes.rut= cotizacion.rut and usuarios.rut_usuario= cotizacion.usuario and cotizacion.n_cotizacion ='" & (combo_numero.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
                    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono")
                    txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
                    txt_rut_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
                    txt_nombre_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
                End If
                conexion.Close()
            End If
            Exit Sub
        End If

        If combo_documentos.Text = "NOTA DE CREDITO" Then
            If combo_numero.Text <> "" Then
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from clientes, usuarios, nota_credito where clientes.rut= nota_credito.rut and usuarios.rut_usuario= nota_credito.usuario and nota_credito.n_nota_credito ='" & (combo_numero.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
                    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono")
                    txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
                    txt_rut_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
                    txt_nombre_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
                End If
                conexion.Close()
            End If
            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA" Then
            If combo_numero.Text <> "" Then
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from usuarios, BOLETA where usuarios.rut_usuario= BOLETA.usuario and BOLETA.n_boleta ='" & (combo_numero.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then


                    txt_rut_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
                    txt_nombre_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
                End If
                conexion.Close()
            End If
            Exit Sub
        End If

        If combo_documentos.Text = "GUIA" Then
            If combo_numero.Text <> "" Then
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from clientes, usuarios, guia where clientes.rut= guia.rut and usuarios.rut_usuario= guia.usuario and guia.n_guia ='" & (combo_numero.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut")
                    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono")
                    txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion")
                    txt_rut_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
                    txt_nombre_vendedor_erroneo.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
                End If
                conexion.Close()
            End If
            Exit Sub
        End If
    End Sub

    'llenamos el combo vendedor con todos los usuarios donde el TIPO sea igual a VENTAS.
    Sub llenar_combo_vendedor()
        combo_vendedor.Items.Clear()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios where area='" & ("VENTAS") & "'"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("rut_usuario"))
            Next
        End If
        conexion.Close()
    End Sub

    'verificamos que la grilla este cargada con alguna venta.
    'si la grilla esta cargada llamamos a grabar el cambio.
    'limpiamos la pantalla.
    'actualizamos la tabla usurios.

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        Dim mensaje As String = ""
        If migrilla.Rows.Count = 0 Then mensaje = "NO HAY DCUMENTOS CARGADOS" + Chr(13) & mensaje
        If mensaje <> "" Then
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        Else
            grabar_cambio()
            MsgBox("CAMBIO GRABADO CON EXITO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            limpiar()
            actualizar_tabla_usuarios()
        End If
    End Sub

    'se llena la malla general del producto donde el documento y el numero sean iguales a los seleccionados.
    Sub mostrar_malla()
        If combo_documentos.Text = "FACTURA" Then
            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select n_factura as Numero, TIPO as TIPO, rut as Rut, descuento as Descuento, neto as Neto, iva as IVA, total as Total, condiciones as Condicion, Estado as Estado from factura  where  n_factura = '" & (combo_numero.Text) & "'"
            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            migrilla.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()
            '  Exit Sub
        End If

        If combo_documentos.Text = "FACTURA CREDITO" Then
            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select n_factura_credito as Numero, TIPO as TIPO, rut as Rut, descuento as Descuento, neto as Neto, iva as IVA, total as Total, condiciones as Condicion, Estado as Estado from factura_credito  where  n_factura_credito = '" & (combo_numero.Text) & "'"
            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            migrilla.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()
            '    Exit Sub
        End If

        If combo_documentos.Text = "GUIA" Then
            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select n_guia as Numero, TIPO as TIPO, rut as Rut, descuento as Descuento, neto as Neto, iva as IVA, total as Total, condiciones as Condicion, Estado as Estado from guia where  n_guia= '" & (combo_numero.Text) & "'"
            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            migrilla.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()
            '   Exit Sub
        End If

        If combo_documentos.Text = "NOTA DE CREDITO" Then
            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select n_nota_credito as Numero, TIPO as TIPO, rut as Rut, descuento as Descuento, neto as Neto, iva as IVA, total as Total, condiciones as Condicion, estado as Estado from nota_credito  where  n_nota_credito = '" & (combo_numero.Text) & "'"

            ' SC4.CommandText = "select      n_factura as Numero, TIPO as TIPO, rut as Rut, descuento as Descuento, neto as Neto, iva as IVA, total as Total, condiciones as Condicion, Estado as Estado from factura  where  n_factura = '" & (combo_numero.Text) & "'"



            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            migrilla.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()
            '   Exit Sub
        End If

        If combo_documentos.Text = "BOLETA CREDITO" Then
            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select n_boleta_credito as Numero, TIPO as TIPO, rut as Rut, descuento as Descuento, neto as Neto, iva as IVA, total as Total, condiciones as Condicion, Estado as Estado from boleta_credito  where  n_boleta_credito = '" & (combo_numero.Text) & "'"
            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            migrilla.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()
            '  Exit Sub
        End If
        If combo_documentos.Text = "BOLETA" Then
            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select n_boleta as Numero, TIPO as TIPO, descuento as Descuento, neto as Neto, iva as IVA, total as Total, condiciones as Condicion, Estado as Estado from BOLETA where  n_boleta = '" & (combo_numero.Text) & "'"
            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            migrilla.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()
            '   Exit Sub
        End If

        If combo_documentos.Text = "COTIZACION" Then
            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select n_cotizacion as Numero, TIPO as TIPO, descuento as Descuento, neto as Neto, iva as IVA, total as Total, condiciones as Condicion, Estado as Estado from cotizacion where  n_cotizacion = '" & (combo_numero.Text) & "'"
            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            migrilla.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()
            '  Exit Sub
        End If

        If combo_documentos.Text = "COMPRAS" Then
            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select n_compra as Numero, TIPO as TIPO, descuento as Descuento, neto as Neto, iva as IVA, total as Total, condiciones as Condicion, Estado as Estado from compra where  n_compra = '" & (combo_numero.Text) & "'"
            DA4.SelectCommand = SC4
            DA4.Fill(DT3)
            DS4.Tables.Add(DT4)

            migrilla.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()
            '  Exit Sub
        End If
    End Sub

    'llenamos la malla detalle donde el documento y el numero sean iguales a los seleccionados.
    Sub mostrar_malla_detalle()
        If combo_documentos.Text = "FACTURA" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select cod_producto as Codigo, detalle_nombre as Nombre, valor_unitario as Valor, cantidad as Cantidad, detalle_Neto as Neto, detalle_iva as IVA, detalle_total as Total  from detalle_factura  where  n_factura = '" & (combo_numero.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            conexion.Close()
            Exit Sub
        End If

        If combo_documentos.Text = "FACTURA CREDITO" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select cod_producto as Codigo, detalle_nombre as Nombre, valor_unitario as Valor, cantidad as Cantidad, detalle_Neto as Neto, detalle_iva as IVA, detalle_total as Total from detalle_factura_credito  where  n_factura_credito = '" & (combo_numero.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            conexion.Close()
            Exit Sub
        End If

        If combo_documentos.Text = "GUIA" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select cod_producto as Codigo, detalle_nombre as Nombre, valor_unitario as Valor, cantidad as Cantidad, detalle_Neto as Neto, detalle_iva as IVA, detalle_total as Total from detalle_guia  where  n_guia = '" & (combo_numero.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            conexion.Close()
            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select cod_producto as Codigo, detalle_nombre as Nombre, valor_unitario as Valor, cantidad as Cantidad, detalle_Neto as Neto, detalle_iva as IVA, detalle_total as Total from detalle_boleta where n_boleta = '" & (combo_numero.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            conexion.Close()
            Exit Sub
        End If

        If combo_documentos.Text = "COTIZACION" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from detalle_cotizacion  where  n_cotizacion = '" & (combo_numero.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            migrilla_detalle.DataSource = DS.Tables(DT.TableName)
            conexion.Close()
            Exit Sub
        End If
    End Sub

    'le otorgamos el valor del combobox al texbox.
    '  mostramos los datos del vendedor.
    Private Sub combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_vendedor.SelectedIndexChanged

        mostrar_datos_vendedor()
    End Sub

    'llenamos el campo nombre del vendedor segun el rut seleccionado.
    Sub mostrar_datos_vendedor()
        If combo_vendedor.Text <> "" Then
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from usuarios where rut_usuario ='" & (combo_vendedor.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_nombre_vendedor.Text = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_usuario")
            End If
            conexion.Close()
        End If
    End Sub

    'permite filtar el rut del usuario segun lo que vayamos escribiendo en el texbox.
    Sub mostrar_rut()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from usuarios where rut_usuario like '" & (txt_rut.Text & "%") & "' and TIPO ='VENTAS'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            combo_vendedor.Items.Clear()
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                combo_vendedor.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_usuario"))
            Next
        End If
        conexion.Close()
    End Sub

    'hacemos la actualziacion del vendedor segun el documento seleccionado.
    Sub grabar_cambio()
        If combo_documentos.Text = "BOLETA" Then
            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update BOLETA set usuario = '" & (combo_vendedor.Text) & "' where n_boleta = '" & (combo_numero.Text) & "'"
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()

            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update total set usuario = '" & (combo_vendedor.Text) & "' where n_total = '" & (combo_numero.Text) & "' and TIPO='BOLETA' "
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()
            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA CREDITO" Then
            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update boleta_credito set usuario = '" & (combo_vendedor.Text) & "' where n_boleta_credito = '" & (combo_numero.Text) & "'"
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()

            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update total set usuario = '" & (combo_vendedor.Text) & "' where n_total = '" & (combo_numero.Text) & "' and TIPO='BOLETA CREDITO' "
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()
            Exit Sub



            Exit Sub
        End If

        If combo_documentos.Text = "FACTURA CONTADO" Then
            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update factura set usuario = '" & (combo_vendedor.Text) & "' where n_factura = '" & (combo_numero.Text) & "'"
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()

            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update total set usuario = '" & (combo_vendedor.Text) & "' where n_total = '" & (combo_numero.Text) & "' and TIPO='FACTURA CONTADO' "
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()
            Exit Sub

        End If

        If combo_documentos.Text = "FACTURA CREDITO" Then
            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update factura_credito set usuario = '" & (combo_vendedor.Text) & "' where n_factura_credito = '" & (combo_numero.Text) & "'"
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()


            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update total set usuario = '" & (combo_vendedor.Text) & "' where n_total = '" & (combo_numero.Text) & "' and TIPO='FACTURA CREDITO' "
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()

            Exit Sub
        End If

        If combo_documentos.Text = "NOTA DE CREDITO" Then
            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update nota_credito set usuario = '" & (combo_vendedor.Text) & "' where n_nota_credito = '" & (combo_numero.Text) & "'"
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()


            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update total set usuario = '" & (combo_vendedor.Text) & "' where n_total = '" & (combo_numero.Text) & "' and TIPO='NOTA DE CREDITO' "
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()
            Exit Sub
        End If
        If combo_documentos.Text = "GUIA" Then
            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update guia set usuario = '" & (combo_vendedor.Text) & "' where n_guia = '" & (combo_numero.Text) & "'"
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()


            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update total set usuario = '" & (combo_vendedor.Text) & "' where n_total = '" & (combo_numero.Text) & "' and TIPO='GUIA' "
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()
            Exit Sub
        End If

        If combo_documentos.Text = "COTIZACION" Then
            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update cotizacion set usuario = '" & (combo_vendedor.Text) & "' where n_cotizacion = '" & (combo_numero.Text) & "'"
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()


            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion
            SC1.CommandText = "update total set usuario = '" & (combo_vendedor.Text) & "' where n_total = '" & (combo_numero.Text) & "' and TIPO='COTIZACION' "
            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()
            Exit Sub
        End If

    End Sub

    'salimos de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    'limpiamos los datos de la pantalla.
    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        limpiar()
    End Sub

    Private Sub AyudaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

End Class