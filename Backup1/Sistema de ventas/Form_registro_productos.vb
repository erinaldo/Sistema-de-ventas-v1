Imports System.IO
Imports System.Drawing.Drawing2D

Public Class form_registro_productos
    ' Dim VarSeleccion As Integer
    Dim MiPos As Integer
    Dim mifecha2 As String
    Dim varnumajuste As Integer


    Dim ModificacionNombre As String
    Dim ModificacionAplicacion As String
    Dim ModificacionNroTecnico As String
    Dim ModificacionMarca As String
    Dim ModificacionCodBarra As String
    Dim ModificacionFamilia As String
    Dim ModificacionSubFamilia As String
    Dim ModificacionSubFamilia2 As String
    Dim ModificacionCantidad As String
    Dim ModificacionPrecio As String
    Dim ModificacionTipoPrecio As String
    Dim ModificacionCosto As String
    Dim ModificacionProveedor As String
    Dim ModificacionActivo As String

    Private Sub form_registro_productos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub form_registro_productos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub form_clientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'actualizar_tabla()
        'mostrar(0)

        'mostrar_datos_productos_codigo_minimo()
        'mostrar_datos_productos()
        'mostrar_datos_proveedores()

        controles(False, True)
        llenar_combo_familia()
        'llenar_combo_marca()
        cargar_logo()
        dtp_fecha.CustomFormat = "yyy-MM-dd"



        If mirutempresa = "81921000-4" Then
            If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
                btn_modificar.Enabled = True
            Else
                btn_modificar.Enabled = False
                If miusuario = "13099870-4" Then
                    btn_modificar.Enabled = True
                End If
            End If
        End If


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select nombre_marca from marcas_productos"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        If DS.Tables(DT.TableName).Rows.Count > 0 Then


            For i = 0 To DS.Tables(0).Rows.Count - 1
                col.Add(DS.Tables(0).Rows(i)("nombre_marca").ToString())
            Next
            txt_marca.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_marca.AutoCompleteCustomSource = col
            txt_marca.AutoCompleteMode = AutoCompleteMode.Suggest
        End If




        txt_marca.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_marca.AutoCompleteCustomSource = col
        txt_marca.AutoCompleteMode = AutoCompleteMode.SuggestAppend


        conexion.Close()

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub crear_nro_ajuste()
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
                    txt_nombre.Text = ""
                    txt_marca.Text = ""
                    txt_aplicacion.Text = ""
                    txt_numero_tecnico.Text = ""
                    combo_familia.Text = ""
                    combo_subfamilia.Text = ""
                    txt_cantidad.Text = ""
                    txt_factor.Text = ""
                    txt_costo.Text = ""
                    txt_rut_proveedor.Text = ""
                    txt_precio.Text = ""
                    txt_codigo_barra.Text = ""
                    dtp_ultima_compra.Text = ""
                    txt_cantidad_ultima_compra.Text = ""
                    txt_nro_doc.Text = ""
                    txt_tipo_doc.Text = ""
                    txt_cantidad_minima.Text = ""
                    Combo_tipo_medida.Text = "UNIDAD"

                    Combo_familia.Text = "SIN FAMILIA"
                    Combo_subfamilia.Text = "SIN SUB FAMILIA"
                    Combo_subfamilia_2.Text = "SIN SUB FAMILIA DOS"
                    txt_codigo_familia.Text = "0"
                    txt_codigo_subfamilia.Text = "0"
                    txt_codigo_subfamilia_2.Text = "0"

                    Combo_activo.Text = "SI"

                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    'combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                    'combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                    txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                    txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                    txt_rut_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                    txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    txt_codigo_barra.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_barra")
                    dtp_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
                    txt_cantidad_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
                    txt_nro_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("nro_doc")
                    txt_tipo_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_doc")
                    txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")
                    txt_codigo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                    txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                    txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
                    Combo_activo.Text = DS.Tables(DT.TableName).Rows(0).Item("activo")
                    Combo_tipo_medida.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_medida")

                    If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "1" Then
                        Combo_tipo_precio.Text = "FACTOR"
                    End If

                    If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "2" Then
                        Combo_tipo_precio.Text = "DIRECTO"
                    End If

                    'Try
                    '    Combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                    '    Combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                    'Catch
                    'End Try

                    mostrar_familia()
                    llenar_combo_subfamilia()
                    txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                    mostrar_subfamilia()
                    llenar_combo_subfamilia2()
                    txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
                    mostrar_subfamilia_dos()


                    ModificacionNombre = txt_nombre.Text
                    ModificacionAplicacion = txt_aplicacion.Text
                    ModificacionNroTecnico = txt_numero_tecnico.Text
                    ModificacionMarca = txt_marca.Text
                    ModificacionCodBarra = txt_codigo_barra.Text
                    ModificacionFamilia = Combo_familia.Text
                    ModificacionSubFamilia = Combo_subfamilia.Text
                    ModificacionSubFamilia2 = Combo_subfamilia_2.Text
                    ModificacionCantidad = txt_cantidad.Text
                    ModificacionPrecio = txt_precio.Text
                    ModificacionTIPOPrecio = Combo_tipo_precio.Text
                    ModificacionCosto = txt_costo.Text
                    ModificacionProveedor = txt_rut_proveedor.Text
                    ModificacionActivo = Combo_activo.Text













                Else
                    MsgBox("CODIGO NO EXISTENTE", 0 + 16, "ERROR")
                    conexion.Close()
                End If

            Catch err As InvalidCastException
                '    txt_factura.Text = 1
                conexion.Close()
                Exit Sub
            End Try
            conexion.Close()
        End If
    End Sub

    Sub mostrar_cantidad_minima()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select cantidad_minima from valores"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_cantidad_minima.Text = "0"
                txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")
            End If

        Catch err As InvalidCastException
            txt_cantidad_minima.Text = "0"
            conexion.Close()
            Exit Sub
        End Try
        conexion.Close()

    End Sub



    Sub mostrar_datos_productos_mas_1()

        If txt_codigo.Text <> "" Then
            txt_codigo.Text = txt_codigo.Text + 1

            Dim codigo_producto As Integer
            codigo_producto = txt_codigo.Text
            txt_codigo.Text = String.Format("{0:000000}", codigo_producto)
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
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                Combo_tipo_medida.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_medida")

                'txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_rut_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_codigo_barra.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_barra")


                dtp_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
                txt_cantidad_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
                txt_nro_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("nro_doc")
                txt_tipo_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_doc")
                txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")

                txt_codigo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
                Combo_activo.Text = DS.Tables(DT.TableName).Rows(0).Item("activo")

                If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "1" Then
                    Combo_tipo_precio.Text = "FACTOR"
                End If

                If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "2" Then
                    Combo_tipo_precio.Text = "DIRECTO"
                End If

                Try
                    Combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                    Combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                Catch
                End Try

                mostrar_familia()
                llenar_combo_subfamilia()
                txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                mostrar_subfamilia()
                llenar_combo_subfamilia2()
                txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
                mostrar_subfamilia_dos()

            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_productos_menos_1()

        If txt_codigo.Text <> "" Then
            txt_codigo.Text = txt_codigo.Text - 1

            Dim codigo_producto As Integer
            codigo_producto = txt_codigo.Text

            ' txt_codigo.Text = codigo_producto
            txt_codigo.Text = String.Format("{0:000000}", codigo_producto)
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

                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                'combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                'combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                'txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_rut_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_codigo_barra.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_barra")
                Combo_tipo_medida.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_medida")

                dtp_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
                txt_cantidad_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
                txt_nro_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("nro_doc")
                txt_tipo_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_doc")
                txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")

                txt_codigo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
                Combo_activo.Text = DS.Tables(DT.TableName).Rows(0).Item("activo")

                If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "1" Then
                    Combo_tipo_precio.Text = "FACTOR"
                End If

                If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "2" Then
                    Combo_tipo_precio.Text = "DIRECTO"
                End If

                Try
                    Combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                    Combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                Catch
                End Try

                mostrar_familia()
                llenar_combo_subfamilia()
                txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                mostrar_subfamilia()
                llenar_combo_subfamilia2()
                txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
                mostrar_subfamilia_dos()


            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_productos_codigo_minimo()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select min(cod_producto) as cod_producto from productos"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        End If
        conexion.Close()



        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from productos where cod_producto= '" & (txt_codigo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
            txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
            txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
            txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
            txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            'combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
            'combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
            'txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")
            txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
            txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
            txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
            txt_rut_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
            txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
            txt_codigo_barra.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_barra")
            Combo_tipo_medida.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_medida")

            dtp_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
            txt_cantidad_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
            txt_nro_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("nro_doc")
            txt_tipo_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_doc")
            txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")

            txt_codigo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
            txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
            txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
            Combo_activo.Text = DS.Tables(DT.TableName).Rows(0).Item("activo")

            If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "1" Then
                Combo_tipo_precio.Text = "FACTOR"
            End If

            If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "2" Then
                Combo_tipo_precio.Text = "DIRECTO"
            End If

            Try
                Combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                Combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
            Catch
            End Try

            mostrar_familia()
            llenar_combo_subfamilia()
            txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
            mostrar_subfamilia()
            llenar_combo_subfamilia2()
            txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
            mostrar_subfamilia_dos()

        End If
        conexion.Close()
    End Sub

    Sub mostrar_datos_productos_codigo_maximo()

        ' If txt_codigo.Text <> "" Then
        ' txt_codigo.Text = txt_codigo.Text - 1
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select max(cod_producto) as cod_producto from productos"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        End If
        conexion.Close()



        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from productos where cod_producto= '" & (txt_codigo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
            txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
            txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
            txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
            txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            'combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
            'combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
            'txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")
            txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
            txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
            txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
            txt_rut_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
            txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
            txt_codigo_barra.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_barra")
            Combo_tipo_medida.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_medida")

            dtp_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
            txt_cantidad_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
            txt_nro_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("nro_doc")
            txt_tipo_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_doc")
            txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")

            txt_codigo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
            txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
            txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
            Combo_activo.Text = DS.Tables(DT.TableName).Rows(0).Item("activo")

            If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "1" Then
                Combo_tipo_precio.Text = "FACTOR"
            End If

            If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "2" Then
                Combo_tipo_precio.Text = "DIRECTO"
            End If

            'Try
            '    Combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
            '    Combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
            'Catch
            'End Try

            mostrar_familia()
            llenar_combo_subfamilia()
            txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
            mostrar_subfamilia()
            llenar_combo_subfamilia2()
            txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
            mostrar_subfamilia_dos()

        End If
        conexion.Close()
    End Sub


    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_fecha.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub



    'Private Sub form_registro_productos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from productos where cod_producto ='" & (codbuscado) & "'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        mostrar(0)
    '        conexion.Close()

    '        actualizar_tabla()
    '    End If
    'End Sub

    Sub crear_codigo()
        Dim varcodigo As Integer

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_producto) as cod_producto from productos"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varcodigo = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_codigo.Text = varcodigo + 1
            End If
        Catch err As InvalidCastException
            txt_codigo.Text = 1
        End Try
        conexion.Close()
    End Sub

    Sub mostrar(ByVal i As Integer)
        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                txt_nombre.Text = DS.Tables(DT.TableName).Rows(i).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(i).Item("marca")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(i).Item("aplicacion")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                combo_familia.Text = DS.Tables(DT.TableName).Rows(i).Item("familia")
                combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(i).Item("subfamilia")
                'txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(i).Item("cantidad_minima")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                txt_factor.Text = DS.Tables(DT.TableName).Rows(i).Item("factor")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(i).Item("costo")
                txt_rut_proveedor.Text = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(i).Item("precio")
                txt_codigo_barra.Text = DS.Tables(DT.TableName).Rows(i).Item("codigo_barra")
                txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(i).Item("cantidad_minima")

                txt_codigo_familia.Text = DS.Tables(DT.TableName).Rows(i).Item("familia")
                txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(i).Item("subfamilia")
                txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(i).Item("subfamilia_dos")
                Combo_activo.Text = DS.Tables(DT.TableName).Rows(i).Item("activo")
                Combo_tipo_medida.Text = DS.Tables(DT.TableName).Rows(i).Item("tipo_medida")

                If DS.Tables(DT.TableName).Rows(i).Item("tipo_precio") = "1" Then
                    Combo_tipo_precio.Text = "FACTOR"
                End If

                If DS.Tables(DT.TableName).Rows(i).Item("tipo_precio") = "2" Then
                    Combo_tipo_precio.Text = "DIRECTO"
                End If



                'mostrar_familia()
                'llenar_combo_subfamilia()
                'mostrar_subfamilia()
                'llenar_combo_subfamilia2()
                'mostrar_subfamilia_dos()

                mostrar_familia()
                llenar_combo_subfamilia()
                txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(i).Item("subfamilia")
                mostrar_subfamilia()
                llenar_combo_subfamilia2()
                txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(i).Item("subfamilia_dos")
                mostrar_subfamilia_dos()


            End If
        Catch
        End Try
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        'btn_imprimir.Enabled = b
        'btn_eliminar.Enabled = b
        btn_modificar.Enabled = b
        btn_buscar.Enabled = b
        btn_guardar.Enabled = a
        '  btn_agregar.Enabled = a
        '  btn_quitar_elemento.Enabled = a
        btn_cancelar.Enabled = a
        btn_sugerir.Enabled = a
        btn_especifico.Enabled = b
        Combo_activo.Enabled = a
        txt_codigo.Enabled = a
        txt_marca.Enabled = a
        txt_aplicacion.Enabled = a
        txt_cantidad.Enabled = a
        txt_precio.Enabled = a
        txt_numero_tecnico.Enabled = a
        txt_cantidad.Enabled = a
        '  txt_modelo_auto.Enabled = a
        'txt_cantidad_minima.Enabled = a
        txt_codigo_barra.Enabled = a
        txt_costo.Enabled = a
        '  txt_factor.Enabled = a
        Combo_tipo_precio.Enabled = a
        Combo_tipo_medida.Enabled = a
        txt_nombre.Enabled = a
        'Combo_marca_automovil.Enabled = a
        combo_familia.Enabled = a
        combo_subfamilia.Enabled = a
        txt_cantidad_minima.Enabled = a
        'grilla_producto.Enabled = a


        combo_familia.Enabled = a
        combo_subfamilia.Enabled = a
        Combo_subfamilia_2.Enabled = a

        btn_primero.Enabled = b
        btn_ultimo.Enabled = b
        btn_siguiente.Enabled = b
        btn_anterior.Enabled = b













        If mirutempresa = "81921000-4" Then
            If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
                btn_modificar.Enabled = True
            Else
                btn_modificar.Enabled = False
            End If
        End If



        If mirutempresa = "87686300-6" Then
            If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
                Combo_familia.Enabled = True
                Combo_subfamilia.Enabled = True
                Combo_subfamilia_2.Enabled = True
            Else
                Combo_familia.Enabled = False
                Combo_subfamilia.Enabled = False
                Combo_subfamilia_2.Enabled = False
            End If
        End If
    End Sub

    Sub limpiar()
        Combo_activo.Text = "SI"
        txt_codigo.Text = ""
        txt_nombre.Text = ""
        txt_marca.Text = ""
        txt_aplicacion.Text = ""
        txt_precio.Text = ""
        txt_numero_tecnico.Text = ""
        txt_factor.Text = ""
        txt_cantidad.Text = ""
        txt_costo.Text = ""
        Combo_tipo_precio.Text = "-"
        txt_rut_proveedor.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_codigo_barra.Text = ""

        txt_cantidad_minima.Text = ""

        Combo_familia.Text = "SIN FAMILIA"
        Combo_subfamilia.Text = "SIN SUB FAMILIA"
        Combo_subfamilia_2.Text = "SIN SUB FAMILIA DOS"

        Combo_tipo_medida.Text = "UNIDAD"

        Combo_activo.Text = "-"

        txt_cantidad_ultima_compra.Text = ""
        txt_tipo_doc.Text = ""
        txt_nro_doc.Text = ""
        dtp_ultima_compra.Text = FormatDateTime(Now, DateFormat.ShortDate)

        ' txt_modelo_auto.Text = ""
        ' Combo_marca_automovil.Text = ""
        '  combo_familia.Items.Clear()
        'grilla_producto.Rows.Clear()
    End Sub

    Sub limpiar_producto()
        Combo_activo.Text = "SI"
        '  txt_codigo.Text = ""
        Combo_activo.Text = "-"
        txt_nombre.Text = ""
        txt_marca.Text = ""
        txt_aplicacion.Text = ""
        txt_precio.Text = ""
        txt_numero_tecnico.Text = ""
        txt_factor.Text = ""
        txt_cantidad.Text = ""
        txt_costo.Text = ""
        'txt_cantidad_minima.Text = ""
        txt_rut_proveedor.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_codigo_barra.Text = ""
        txt_cantidad_minima.Text = ""
        'txt_modelo_auto.Text = ""
        ' Combo_marca_automovil.Text = ""
        Combo_tipo_precio.Text = "-"
        'Combo_familia.Text = "-"
        'Combo_subfamilia.Text = "-"
        Combo_tipo_medida.Text = "UNIDAD"
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_nro_doc.Text = ""
        txt_tipo_doc.Text = ""


        Combo_familia.Text = "SIN FAMILIA"
        Combo_subfamilia.Text = "SIN SUB FAMILIA"
        Combo_subfamilia_2.Text = "SIN SUB FAMILIA DOS"

        txt_cantidad_ultima_compra.Text = ""
        txt_tipo_doc.Text = ""
        txt_nro_doc.Text = ""
        dtp_ultima_compra.Text = FormatDateTime(Now, DateFormat.ShortDate)

        ' grilla_producto.Rows.Clear()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
        controles(True, False)
        VarSeleccionproducto = 1
        ' crear_codigo()
        ' combo_familia.SelectedItem = "SELECCIONE UNA FAMILIA"
        'llenar_combo_nombre()
        txt_cantidad.Enabled = False
        txt_precio.Enabled = False
        txt_costo.Enabled = False
        Combo_tipo_precio.Enabled = False
        'txt_factor.Enabled = False
        txt_cantidad.Text = "0"
        txt_precio.Text = "0"
        txt_costo.Text = "0"
        txt_factor.Text = "0"
        txt_rut_proveedor.Text = "-"
        txt_nombre_proveedor.Text = "-"
        Combo_activo.Text = "SI"
        Combo_tipo_precio.Text = "-"

        txt_cantidad_ultima_compra.Text = "0"
        txt_tipo_doc.Text = "-"
        txt_nro_doc.Text = "0"
        dtp_ultima_compra.Text = FormatDateTime(Now, DateFormat.ShortDate)


        combo_familia.Text = "-"
        combo_subfamilia.Text = "-"
        Combo_subfamilia_2.Text = "-"


        If mirutempresa = "16621207-3" Then
            txt_cantidad.Enabled = True
            txt_cantidad_minima.Enabled = True
            txt_precio.Enabled = True
        End If

        If mirutempresa = "76820004-1" Then
            txt_cantidad.Enabled = True
            txt_cantidad_minima.Enabled = True
            txt_precio.Enabled = True
        End If

        If mirutempresa = "76366176-8" Then
            txt_cantidad.Enabled = True
            txt_cantidad_minima.Enabled = True
            txt_precio.Enabled = True
        End If

        mostrar_cantidad_minima()





        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'SC.Connection = conexion
        'SC.CommandText = "select nombre_marca from marcas_productos"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'Dim col As New AutoCompleteStringCollection
        'Dim i As Integer
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then


        '    For i = 0 To DS.Tables(0).Rows.Count - 1
        '        col.Add(DS.Tables(0).Rows(i)("nombre_marca").ToString())
        '    Next
        '    txt_marca.AutoCompleteSource = AutoCompleteSource.CustomSource
        '    txt_marca.AutoCompleteCustomSource = col
        '    txt_marca.AutoCompleteMode = AutoCompleteMode.Suggest
        'End If




        'txt_marca.AutoCompleteSource = AutoCompleteSource.CustomSource
        'txt_marca.AutoCompleteCustomSource = col
        'txt_marca.AutoCompleteMode = AutoCompleteMode.SuggestAppend


        conexion.Close()













        txt_codigo.Focus()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        controles(True, False)
        VarSeleccionproducto = 2
        '{ limpiar_producto()
        txt_codigo.Enabled = True
        txt_nombre.Enabled = False
        txt_marca.Enabled = False
        txt_aplicacion.Enabled = False
        txt_numero_tecnico.Enabled = False
        txt_factor.Enabled = False
        txt_costo.Enabled = False
        'txt_cantidad_minima.Enabled = False
        txt_rut_proveedor.Enabled = False
        txt_codigo_barra.Enabled = False
        ' txt_modelo_auto.Enabled = False
        ' Combo_marca_automovil.Enabled = False
        combo_familia.Enabled = False
        combo_subfamilia.Enabled = False
        Combo_tipo_precio.Enabled = False
        Combo_activo.Enabled = False
        combo_familia.Enabled = False
        combo_subfamilia.Enabled = False
        Combo_subfamilia_2.Enabled = False
        Combo_tipo_precio.Enabled = False
        '  btn_quitar_elemento.Enabled = False
        '  grilla_producto.Enabled = False
        Combo_tipo_medida.Enabled = False
        txt_cantidad.Enabled = False
        txt_cantidad_minima.Enabled = False
        txt_precio.Enabled = False

        txt_codigo.Focus()
    End Sub



    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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




            conexion.Close()
            Dim cantidad_caracteres As Integer
            cantidad_caracteres = Len(txt_codigo.Text)
            If cantidad_caracteres <= 5 Then
                Form_buscador_productos_registro.Show()
                Form_buscador_productos_registro.txt_codigo.Text = txt_codigo.Text
                Form_buscador_productos_registro.buscar_codigo()
                Exit Sub
            End If
















            If VarSeleccionproducto = 1 Then
                txt_nombre.Focus()
            End If
            If VarSeleccionproducto = 2 Then
                limpiar_producto()
                mostrar_datos_productos()
                mostrar_datos_proveedores()

                txt_codigo.Enabled = False
                txt_nombre.Enabled = True
                txt_marca.Enabled = True
                txt_aplicacion.Enabled = True
                'txt_precio.Enabled = True
                txt_numero_tecnico.Enabled = True
                'txt_factor.Enabled = True
                'txt_cantidad.Enabled = True
                'txt_costo.Enabled = True
                ' txt_cantidad_minima.Enabled = True
                ' txt_rut_proveedor.Enabled = True
                txt_codigo_barra.Enabled = True
                'txt_modelo_auto.Enabled = True
                '  Combo_marca_automovil.Enabled = True
                combo_familia.Enabled = True
                combo_subfamilia.Enabled = True
                Combo_subfamilia_2.Enabled = True
                Combo_activo.Enabled = True
                Combo_tipo_medida.Enabled = True


                If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
                    txt_cantidad.Enabled = True
                    txt_cantidad_minima.Enabled = True
                    txt_precio.Enabled = True
                Else
                    txt_cantidad.Enabled = False
                    txt_cantidad_minima.Enabled = False
                    txt_precio.Enabled = False
                End If




                If mirutempresa = "87686300-6" Then
                    If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
                        Combo_familia.Enabled = True
                        Combo_subfamilia.Enabled = True
                        Combo_subfamilia_2.Enabled = True
                    Else
                        Combo_familia.Enabled = False
                        Combo_subfamilia.Enabled = False
                        Combo_subfamilia_2.Enabled = False
                    End If
                End If

                If mirutempresa = "16621207-3" Then
                    txt_cantidad.Enabled = True
                    txt_cantidad_minima.Enabled = True
                    txt_precio.Enabled = True
                End If

                If mirutempresa = "76820004-1" Then
                    txt_cantidad.Enabled = True
                    txt_cantidad_minima.Enabled = True
                    txt_precio.Enabled = True
                End If

                If mirutempresa = "76366176-8" Then
                    txt_cantidad.Enabled = True
                    txt_cantidad_minima.Enabled = True
                    txt_precio.Enabled = True
                End If

                '    Combo_tipo_precio.Enabled = True
                'dtp_ultima_compra.Enabled = True
                'txt_cantidad_ultima_compra.Enabled = True
                'txt_nro_doc.Enabled = True
                'txt_tipo_doc.Enabled = True

                '  btn_agregar.Enabled = True
                ' btn_quitar_elemento.Enabled = True
                ' grilla_producto.Enabled = True




                txt_nombre.Focus()
            End If

            If VarSeleccionproducto = 3 Then
                mostrar_datos_productos()
                mostrar_datos_proveedores()
            End If
        End If
    End Sub

    Private Sub txt_codigo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.Validated

        If txt_codigo.Text <> "" Then
            If IsNumeric(txt_codigo.Text) = False Then
                MsgBox("Campo codigo: Ingrese solo numeros")
                txt_codigo.Focus()
                txt_codigo.Text = ""
            End If
        End If

    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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


        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

        'If Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
    End Sub

    Private Sub txt_cantidad_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad.Validated
        If txt_cantidad.Text <> "" Then
            If IsNumeric(txt_cantidad.Text) = False Then
                MsgBox("Campo cantidad: Ingrese solo numeros")
                txt_cantidad.Focus()
                txt_cantidad.Text = ""
            End If
        End If
    End Sub

    Private Sub txt_precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

    Private Sub txt_precio_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio.Validated
        If txt_precio.Text <> "" Then
            If IsNumeric(txt_precio.Text) = False Then
                MsgBox("Campo precio: Ingrese solo numeros")
                txt_precio.Focus()
                txt_precio.Text = ""
            End If
        End If
    End Sub




    'Sub mostrar_malla_productos()

    '    grilla_producto.Rows.Clear()
    '    grilla_producto.Columns.Clear()

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    SC.CommandText = "select * from detalle_producto where codigo_producto='" & (txt_codigo.Text) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    'grilla_producto.Columns.Add("marca_automovil", "MARCA AUTOMOVIL")
    '    '    grilla_producto.Columns.Add("modelo_automovil", "MODELO AUTOMOVIL")

    '    Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_producto.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("marca_automovil"), _
    '                                                        DS.Tables(DT.TableName).Rows(i).Item("modelo_automovil"))
    '        Next
    '    End If
    'End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim valormensaje As Integer

        valormensaje = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")


        If valormensaje = vbYes Then
            SC.Connection = conexion
            SC.CommandText = "delete from productos where cod_producto = '" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        actualizar_tabla()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            mostrar(0)
        Else
            limpiar()
        End If

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        'controles(False, True)
        'MiPos = 0
        'mostrar(MiPos)

        'actualizar_tabla()
        'mostrar(0)

        controles(False, True)
        txt_cantidad.Enabled = False
        txt_precio.Enabled = False






        Combo_activo.Enabled = False
        Combo_tipo_precio.Enabled = False
        txt_codigo.Enabled = False
        txt_nombre.Enabled = False
        txt_marca.Enabled = False
        txt_aplicacion.Enabled = False
        txt_precio.Enabled = False
        txt_numero_tecnico.Enabled = False
        'txt_factor.Enabled = False
        txt_cantidad.Enabled = False
        txt_costo.Enabled = False
        'txt_cantidad_minima.Enabled = False
        txt_rut_proveedor.Enabled = False
        txt_codigo_barra.Enabled = False

        ' txt_modelo_auto.Enabled = False
        'Combo_marca_automovil.Enabled = False
        combo_familia.Enabled = False
        combo_subfamilia.Enabled = False
        Combo_subfamilia_2.Enabled = False
        ' btn_agregar.Enabled = False
        ' btn_quitar_elemento.Enabled = False
        'grilla_producto.Enabled = False





        Combo_tipo_medida.Enabled = False






    End Sub

    Private Sub btn_primero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.Click
        'MiPos = 0
        'mostrar(0)
        limpiar_producto()
        mostrar_datos_productos_codigo_minimo()
        ' mostrar_datos_productos()
        mostrar_datos_proveedores()
        'mostrar_malla_productos()
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        If txt_codigo.Text = "" Then
            txt_codigo.Text = "000001"
        End If
        If txt_codigo.Text <= 0 Then
            mostrar_datos_productos_codigo_minimo()
            '  mostrar_datos_productos()
            mostrar_datos_proveedores()
            '    mostrar_malla_productos()
            Exit Sub
        End If
        limpiar_producto()
        mostrar_datos_productos_menos_1()
        ' mostrar_datos_productos()
        mostrar_datos_proveedores()
        '    mostrar_malla_productos()
        'End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        If txt_codigo.Text = "" Then
            txt_codigo.Text = "000001"
        End If
        'If MiPos < DT.Rows.Count - 1 Then
        '    MiPos += 1
        '    mostrar(MiPos)
        limpiar_producto()
        mostrar_datos_productos_mas_1()
        mostrar_datos_proveedores()
        'mostrar_malla_productos()
        'End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        'MiPos = DT.Rows.Count - 1
        'mostrar(MiPos)
        limpiar_producto()
        mostrar_datos_productos_codigo_maximo()
        ' mostrar_datos_productos()
        mostrar_datos_proveedores()
        'mostrar_malla_productos()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Form_buscador_productos_registro.Show()

        Me.WindowState = FormWindowState.Minimized

    End Sub



    Sub actualizar_tabla()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from productos"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub

    Private Sub txt_costo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_costo.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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



    Private Sub txt_cantidad_minima_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txt_marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_marca.KeyPress, txt_aplicacion.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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


    End Sub

    Private Sub txt_numero_tecnico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_tecnico.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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


    End Sub

    Private Sub combo_familia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        llenar_combo_subfamilia()
        'combo_subfamilia.Items.Clear()
        ' familia()
    End Sub

    'Sub llenar_combo_marca()

    '    Combo_marca_automovil.Items.Clear()
    '    DS3.Tables.Clear()
    '    DT3.Rows.Clear()
    '    DT3.Columns.Clear()
    '    DS3.Clear()
    '    conexion.Open()

    '    SC3.Connection = conexion
    '    SC3.CommandText = "select * from marcas_automoviles order by nombre_marca"
    '    DA3.SelectCommand = SC3
    '    DA3.Fill(DT3)
    '    DS3.Tables.Add(DT3)

    '    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
    '            Combo_marca_automovil.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_marca"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub



    Sub llenar_combo_familia()
        combo_familia.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from familia order by nombre_familia"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        'Combo_familia.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_familia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_familia"))
            Next
        End If
        Combo_familia.SelectedItem = "SIN FAMILIA"
        conexion.Close()
    End Sub

    Sub mostrar_codigo_familia()
        If Combo_familia.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from familia where nombre_familia ='" & (Combo_familia.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_codigo_familia.Text = DS2.Tables(DT2.TableName).Rows(0).Item("codigo")
            End If

            conexion.Close()
        End If
    End Sub


    Sub mostrar_familia()
        If txt_codigo_familia.Text <> "" And txt_codigo_familia.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from familia where codigo ='" & (txt_codigo_familia.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                Combo_familia.SelectedItem = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_familia")
            End If

            conexion.Close()
        End If
    End Sub

    Sub mostrar_subfamilia()
        If txt_codigo_subfamilia.Text <> "" And txt_codigo_subfamilia.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia where cod_auto ='" & (txt_codigo_subfamilia.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                Combo_subfamilia.SelectedItem = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_subfamilia")
            End If

            conexion.Close()
        End If
    End Sub


    Sub mostrar_subfamilia_dos()
        If txt_codigo_subfamilia_2.Text <> "" And txt_codigo_subfamilia_2.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia_dos where cod_auto ='" & (txt_codigo_subfamilia_2.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                Combo_subfamilia_2.SelectedItem = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_subfamilia")
            End If

            conexion.Close()
        End If
    End Sub



    'Sub llenar_combo_nombre()
    '    Combo_nombre.Items.Clear()
    '    DS3.Tables.Clear()
    '    DT3.Rows.Clear()
    '    DT3.Columns.Clear()
    '    DS3.Clear()
    '    conexion.Open()

    '    SC3.Connection = conexion
    '    SC3.CommandText = "select * from productos where nombre <> 'TODOS' order by nombre"
    '    DA3.SelectCommand = SC3
    '    DA3.Fill(DT3)
    '    DS3.Tables.Add(DT3)

    '    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
    '            Combo_nombre.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub


    Sub llenar_combo_subfamilia()
        conexion.Close()
        combo_subfamilia.Items.Clear()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from subfamilia where codigo_familia='" & (txt_codigo_familia.Text) & "' order by nombre_subfamilia"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        Combo_subfamilia.Items.Add("SIN SUB FAMILIA")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_subfamilia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
            Next
        End If
        Combo_subfamilia.SelectedItem = "SIN SUB FAMILIA"
        conexion.Close()
    End Sub

    Sub mostrar_codigo_subfamilia()
        If Combo_subfamilia.Text <> "-" Then
            conexion.Close()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion
            SC3.CommandText = "select * from subfamilia where codigo_familia='" & (txt_codigo_familia.Text) & "' and nombre_subfamilia ='" & (Combo_subfamilia.Text) & "'"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia.Text = DS3.Tables(DT3.TableName).Rows(0).Item("cod_auto")
            End If

            conexion.Close()
        End If
    End Sub




    Sub llenar_combo_subfamilia2()
        conexion.Close()
        Combo_subfamilia_2.Items.Clear()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from subfamilia_dos where codigo_subfamilia='" & (txt_codigo_subfamilia.Text) & "' order by nombre_subfamilia"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        Combo_subfamilia_2.Items.Add("SIN SUB FAMILIA DOS")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_subfamilia_2.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
            Next
        End If
        Combo_subfamilia_2.SelectedItem = "SIN SUB FAMILIA DOS"
        conexion.Close()
    End Sub

    Sub mostrar_codigo_subfamilia2()
        If Combo_subfamilia_2.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia_dos where nombre_subfamilia ='" & (Combo_subfamilia_2.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia_2.Text = DS2.Tables(DT2.TableName).Rows(0).Item("cod_auto")
            End If

            conexion.Close()
        End If
    End Sub



    Sub familia()
        If combo_familia.SelectedItem = "ACCESORIOS" Then
            combo_subfamilia.Items.Add("ACCESORIOS EN GENERAL")
            combo_subfamilia.Items.Add("COOLANT")
            combo_subfamilia.Items.Add("FLEXIBLES DE ESCAPE")
            combo_subfamilia.Items.Add("VARIOS REFRIGERACION")
            combo_subfamilia.Items.Add("VELLUMOIDE")
        End If

        If combo_familia.SelectedItem = "AMORTIGUADORES" Then
            combo_subfamilia.Items.Add("AMORTIGUADORES")
        End If

        If combo_familia.SelectedItem = "BATERIAS" Then
            combo_subfamilia.Items.Add("BATERIAS")
        End If

        If combo_familia.SelectedItem = "CHASIS" Then
            combo_subfamilia.Items.Add("CABLES DE CONTROL")
            combo_subfamilia.Items.Add("CAJAS DE CAMBIO")
            combo_subfamilia.Items.Add("CARROCERIA EN GENERAL")
            combo_subfamilia.Items.Add("CRUCETAS")
            combo_subfamilia.Items.Add("DIFERENCIAL")
            combo_subfamilia.Items.Add("HOMOCINETICA")
            combo_subfamilia.Items.Add("MANILLAS")
        End If

        If combo_familia.SelectedItem = "CORREAS" Then
            combo_subfamilia.Items.Add("CORREAS EN V")
            combo_subfamilia.Items.Add("CORREAS PK")
        End If

        If combo_familia.SelectedItem = "DIESEL" Then
            combo_subfamilia.Items.Add("BUJIAS INCANDESCENTES")
        End If

        If combo_familia.SelectedItem = "ELECTRICO" Then
            combo_subfamilia.Items.Add("ALTERNADORES")
            combo_subfamilia.Items.Add("AMPOLLETAS")
            combo_subfamilia.Items.Add("ARRANQUES")
            combo_subfamilia.Items.Add("BENDIX")
            combo_subfamilia.Items.Add("BULBOS")
            combo_subfamilia.Items.Add("CARBONES")
            combo_subfamilia.Items.Add("CHAPAS DE CONTACTO")
            combo_subfamilia.Items.Add("FUSIBLES")
            combo_subfamilia.Items.Add("INTERRUPTORES")
            combo_subfamilia.Items.Add("LUCES Y FAROLES")
            combo_subfamilia.Items.Add("MODULOS")
            combo_subfamilia.Items.Add("REGULADORES")
            combo_subfamilia.Items.Add("RELAIS")
            combo_subfamilia.Items.Add("SOLENOIDES")
            combo_subfamilia.Items.Add("VARIOS ELECTRICOS")
        End If

        If combo_familia.SelectedItem = "EMBRAGUE" Then
            combo_subfamilia.Items.Add("BOMBAS DE EMBRAGUE")
            combo_subfamilia.Items.Add("DISCOS DE EMBRAGUE")
            combo_subfamilia.Items.Add("EMBRAGUES VARIOS")
            combo_subfamilia.Items.Add("KIT DE EMBRAGUE")
            combo_subfamilia.Items.Add("PRENSAS DE EMBRAGUE")
            combo_subfamilia.Items.Add("RODAMIENTOS DE EMBRAGUE")
        End If

        If combo_familia.SelectedItem = "ENCENDIDO" Then
            combo_subfamilia.Items.Add("BOBINAS")
            combo_subfamilia.Items.Add("BUJIAS")
            combo_subfamilia.Items.Add("CABLES DE ENCENDIDO")
            combo_subfamilia.Items.Add("CONDENSADORES")
            combo_subfamilia.Items.Add("DISTRIBUIDOR")
            combo_subfamilia.Items.Add("PLATINOS")
            combo_subfamilia.Items.Add("ROTORES DISTRIBUIDOR")
            combo_subfamilia.Items.Add("TAPAS DISTRIBUIDOR")
        End If

        If combo_familia.SelectedItem = "FILTROS" Then
            combo_subfamilia.Items.Add("FILTROS ACEITE")
            combo_subfamilia.Items.Add("FILTROS AGUA")
            combo_subfamilia.Items.Add("FILTROS AIRE")
            combo_subfamilia.Items.Add("FILTROS BENCINA")
            combo_subfamilia.Items.Add("FILTROS CAJA CAMBIO")
            combo_subfamilia.Items.Add("FILTROS PETROLEO")
        End If

        If combo_familia.SelectedItem = "FRENOS" Then
            combo_subfamilia.Items.Add("DISCOS DE FRENO")
            combo_subfamilia.Items.Add("FRENOS HIDRAULICOS")
            combo_subfamilia.Items.Add("PASTILLAS DE FRENO")
            combo_subfamilia.Items.Add("PATINES DE FRENO")
            combo_subfamilia.Items.Add("TAMBORES DE FRENO")
        End If

        If combo_familia.SelectedItem = "HERRAMIENTAS" Then
            combo_subfamilia.Items.Add("HERRAMIENTAS")
        End If

        If combo_familia.SelectedItem = "GASOLINA" Then
            combo_subfamilia.Items.Add("BOMBAS DE BENCINA")
            combo_subfamilia.Items.Add("INYECTORES")
            combo_subfamilia.Items.Add("REPARACION CARBURADOR")
        End If

        If combo_familia.SelectedItem = "LUBRICANTES" Then
            combo_subfamilia.Items.Add("LUBRICANTES OTROS")
        End If

        If combo_familia.SelectedItem = "MOTOR" Then
            combo_subfamilia.Items.Add("ANILLOS")
            combo_subfamilia.Items.Add("BOMBA DE AGUA")
            combo_subfamilia.Items.Add("BOMBAS DE ACEITE Y REPARACIONES")
            combo_subfamilia.Items.Add("CADENAS")
            combo_subfamilia.Items.Add("CAMISAS")
            combo_subfamilia.Items.Add("CIGÜEÑAL")
            combo_subfamilia.Items.Add("CONJUNTO MOTOR")
            combo_subfamilia.Items.Add("CULATAS")
            combo_subfamilia.Items.Add("EJE LEVA")
            combo_subfamilia.Items.Add("EMPAQUETADURAS")
            combo_subfamilia.Items.Add("GUIAS DE VALVULA")
            combo_subfamilia.Items.Add("GUIS Y TENSORES")
            combo_subfamilia.Items.Add("KIT Y TAPAS DE DISTRIBUCION")
            combo_subfamilia.Items.Add("METALES")
            combo_subfamilia.Items.Add("PIÑONES")
            combo_subfamilia.Items.Add("PISTONES")
            combo_subfamilia.Items.Add("RADIADORES")
            combo_subfamilia.Items.Add("RETENES")
            combo_subfamilia.Items.Add("TERMOSTATOS")
            combo_subfamilia.Items.Add("VALVULAS")
        End If

        If combo_familia.SelectedItem = "NEUMATICOS" Then
            combo_subfamilia.Items.Add("NEUMATICOS")
        End If

        If combo_familia.SelectedItem = "RODAMIENTOS" Then
            combo_subfamilia.Items.Add("RODAMIENTOS")
        End If

        If combo_familia.SelectedItem = "SUSPENSION/DIRECCION" Then
            combo_subfamilia.Items.Add("BUJES/SOPORTES/CAZOLETAS")
            combo_subfamilia.Items.Add("SUSPENSIÓN/DIRECCIÓN")
        End If
    End Sub












    Sub mostrar_datos_proveedores()
        If txt_rut_proveedor.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            End If
            conexion.Close()
        End If
    End Sub

    'Sub grabar_detalle_producto()
    '    ' Dim VarCodProducto As Integer
    '    Dim varmarcaautomovil As String
    '    Dim varmodeloautomovil As String

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "delete from detalle_producto where codigo_producto = '" & (txt_codigo.Text) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    conexion.Close()



    '    If grilla_producto.Rows.Count > 0 Then
    '        For i = 0 To grilla_producto.Rows.Count - 1

    '            varmarcaautomovil = grilla_producto.Rows(i).Cells(0).Value.ToString
    '            varmodeloautomovil = grilla_producto.Rows(i).Cells(1).Value.ToString

    '            DS.Tables.Clear()
    '            DT.Rows.Clear()
    '            DT.Columns.Clear()
    '            DS.Clear()
    '            conexion.Open()

    '            SC.Connection = conexion
    '            SC.CommandText = "insert into detalle_producto (codigo_producto, marca_automovil, modelo_automovil) values(" & (txt_codigo.Text) & ",'" & (varmarcaautomovil) & "','" & (varmodeloautomovil) & "')"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '            conexion.Close()

    '        Next
    '    End If
    'End Sub



    'Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim mensaje As String = ""

    '    If Combo_marca_automovil.Text = "" Then mensaje = "CAMPO MARCA AUTOMOVIL VACIO, FAVOR LLENAR" + Chr(13) & mensaje
    '    If txt_modelo_auto.Text = "" Then mensaje = "CAMPO MODELO AUTOMOVIL VACIO, FAVOR LLENAR" + Chr(13) & mensaje

    '    If mensaje <> "" Then
    '        MsgBox(mensaje, MessageBoxIcon.Information, "ATENCION")

    '    Else



    '        Dim marca_automovil As String
    '        Dim modelo_automovil As String



    '        For i = 0 To grilla_producto.Rows.Count - 1
    '            marca_automovil = grilla_producto.Rows(i).Cells(0).Value.ToString

    '            modelo_automovil = grilla_producto.Rows(i).Cells(1).Value.ToString
    '            If marca_automovil = Combo_marca_automovil.Text And modelo_automovil = txt_modelo_auto.Text Then
    '                grilla_producto.Rows.Remove(grilla_producto.Rows(i))

    '                grilla_producto.Rows.Add(Combo_marca_automovil.Text, txt_modelo_auto.Text)

    '                Combo_marca_automovil.Text = ""
    '                txt_modelo_auto.Text = ""
    '                Exit Sub
    '            End If
    '        Next


    '        grilla_producto.Rows.Add(Combo_marca_automovil.Text, txt_modelo_auto.Text)

    '        Combo_marca_automovil.Text = ""
    '        txt_modelo_auto.Text = ""





































    '    End If
    'End Sub





    Private Sub txt_rut_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_proveedor.KeyPress
        If e.KeyChar = ";" Then
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



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_nombre_proveedor.Text = ""
            mostrar_datos_proveedores()
            If txt_nombre_proveedor.Text = "" Then
                txt_rut_proveedor.Focus()
            End If
        End If

    End Sub

    Private Sub txt_nombre_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre.GotFocus
        txt_nombre.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nombre_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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


    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 11, FontStyle.Regular)
        Dim Font2 As New Font("arial", 12, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        Dim im As Image
        Try
            im = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
            Dim p As New PointF(535, 10)
            e.Graphics.DrawImage(im, p)
        Catch
        End Try

        Dim rect1 As New Rectangle(10, 15, 250, 15)
        Dim rect2 As New Rectangle(10, 30, 250, 15)
        Dim rect3 As New Rectangle(10, 45, 250, 15)
        Dim rect4 As New Rectangle(10, 60, 250, 15)
        Dim rect5 As New Rectangle(10, 75, 250, 15)
        Dim rect6 As New Rectangle(10, 90, 250, 15)
        Dim rect_titulo As New Rectangle(10, 130, 830, 30)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim stringFormat_logo As New StringFormat()
        stringFormat_logo.Alignment = StringAlignment.Center
        stringFormat_logo.LineAlignment = StringAlignment.Far

        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

        e.Graphics.DrawString("DATOS PRODUCTO", Font2, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawLine(Pens.Black, 10, 160, 820, 160)

        e.Graphics.DrawString("CODIGO", Font1, Brushes.Black, 30, 200)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 200)
        e.Graphics.DrawString(txt_codigo.Text, Font1, Brushes.Gray, 200, 200)
        e.Graphics.DrawString("NOMBRE", Font1, Brushes.Black, 30, 220)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 220)
        e.Graphics.DrawString(txt_nombre.Text, Font1, Brushes.Gray, 200, 220)
        e.Graphics.DrawString("MARCA", Font1, Brushes.Black, 30, 240)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 240)
        e.Graphics.DrawString(txt_marca.Text, Font1, Brushes.Gray, 200, 240)
        e.Graphics.DrawString("APLICACION", Font1, Brushes.Black, 30, 260)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 260)
        e.Graphics.DrawString(txt_aplicacion.Text, Font1, Brushes.Gray, 200, 260)
        e.Graphics.DrawString("FAMILIA", Font1, Brushes.Black, 30, 280)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 280)
        e.Graphics.DrawString(combo_familia.Text, Font1, Brushes.Gray, 200, 280)
        e.Graphics.DrawString("SUBFAMILIA", Font1, Brushes.Black, 30, 300)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 300)
        e.Graphics.DrawString(combo_subfamilia.Text, Font1, Brushes.Gray, 200, 300)
        'e.Graphics.DrawString("CANT. MINIMA", Font1, Brushes.Black, 30, 320)
        'e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 320)
        'e.Graphics.DrawString(txt_cantidad_minima.Text, Font1, Brushes.Gray, 200, 320)
        e.Graphics.DrawString("N° TECNICO", Font1, Brushes.Black, 30, 340)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 340)
        e.Graphics.DrawString(txt_numero_tecnico.Text, Font1, Brushes.Gray, 200, 340)
        e.Graphics.DrawString("RUT PROVEEDOR", Font1, Brushes.Black, 30, 360)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 360)
        e.Graphics.DrawString(txt_rut_proveedor.Text, Font1, Brushes.Gray, 200, 360)
        e.Graphics.DrawString("NOMBRE PROV.", Font1, Brushes.Black, 30, 380)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 380)
        e.Graphics.DrawString(txt_nombre_proveedor.Text, Font1, Brushes.Gray, 200, 380)
        e.Graphics.DrawString("PRECIO", Font1, Brushes.Black, 30, 400)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 400)
        e.Graphics.DrawString(txt_precio.Text, Font1, Brushes.Gray, 200, 400)
        e.Graphics.DrawString("COSTO", Font1, Brushes.Black, 30, 420)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 420)
        e.Graphics.DrawString(txt_costo.Text, Font1, Brushes.Gray, 200, 420)
        e.Graphics.DrawString("CANTIDAD", Font1, Brushes.Black, 30, 440)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 440)
        e.Graphics.DrawString(txt_cantidad.Text, Font1, Brushes.Gray, 200, 440)
        e.Graphics.DrawString("FACTOR", Font1, Brushes.Black, 30, 460)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 460)
        e.Graphics.DrawString(txt_factor.Text, Font1, Brushes.Gray, 200, 460)
    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_nombre.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nombre_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_nombre.BackColor = Color.White
    End Sub

    Private Sub txt_marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_marca.GotFocus
        txt_marca.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_marca_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_marca.LostFocus
        txt_marca.BackColor = Color.White
    End Sub

    Private Sub txt_aplicacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_aplicacion.GotFocus
        txt_aplicacion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_aplicacion_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_aplicacion.LostFocus
        txt_aplicacion.BackColor = Color.White
    End Sub

    Private Sub txt_numero_tecnico_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.GotFocus
        txt_numero_tecnico.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_numero_tecnico_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.LostFocus
        txt_numero_tecnico.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_minima_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_minima.GotFocus
        txt_cantidad_minima.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_minima_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_minima.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_minima_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_minima.LostFocus
        txt_cantidad_minima.BackColor = Color.White
    End Sub

    'Private Sub combo_familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_familia.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub combo_familia_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_familia.BackColor = Color.White
    'End Sub





    Private Sub txt_cantidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad.GotFocus
        txt_cantidad.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad.LostFocus
        txt_cantidad.BackColor = Color.White
    End Sub

    Private Sub txt_precio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio.GotFocus
        txt_precio.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_precio_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio.LostFocus
        txt_precio.BackColor = Color.White
    End Sub



    'Private Sub txt_cantidad_minima_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_cantidad_minima.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_cantidad_minima_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_cantidad_minima.BackColor = Color.White
    'End Sub

    Private Sub txt_codigo_barra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_barra.GotFocus
        txt_codigo_barra.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_barra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_barra.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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


    End Sub

    Private Sub txt_codigo_barra_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_barra.LostFocus
        txt_codigo_barra.BackColor = Color.White
    End Sub

    Private Sub txt_rut_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.GotFocus
        txt_rut_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.LostFocus
        txt_rut_proveedor.BackColor = Color.White
    End Sub




    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_eliminar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_eliminar.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_sugerir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_sugerir.GotFocus
        btn_sugerir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_sugerir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_sugerir.LostFocus
        btn_sugerir.BackColor = Color.Transparent
    End Sub



    Private Sub btn_especifico_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_especifico.GotFocus
        btn_especifico.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_especifico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_especifico.LostFocus
        btn_especifico.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imprimir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imprimir.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_primero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.GotFocus
        btn_primero.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_primero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.LostFocus
        btn_primero.BackColor = Color.Transparent
    End Sub

    Private Sub btn_anterior_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.GotFocus
        btn_anterior.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_anterior_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.LostFocus
        btn_anterior.BackColor = Color.Transparent
    End Sub

    Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.GotFocus
        btn_siguiente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_siguiente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.LostFocus
        btn_siguiente.BackColor = Color.Transparent
    End Sub

    Private Sub btn_ultimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.GotFocus
        btn_ultimo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_ultimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.LostFocus
        btn_ultimo.BackColor = Color.Transparent
    End Sub

    Private Sub txt_nombre_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre.LostFocus
        txt_nombre.BackColor = Color.White
    End Sub

    Private Sub txt_rut_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.TextChanged

    End Sub


    Private Sub txt_cantidad_minima_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre.TextChanged

    End Sub

    Private Sub txt_marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_marca.TextChanged

    End Sub

    Private Sub txt_aplicacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_aplicacion.TextChanged

    End Sub

    Private Sub txt_codigo_barra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_barra.TextChanged

    End Sub

    Private Sub txt_numero_tecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.TextChanged

    End Sub

    Private Sub txt_nombre_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_proveedor.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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


    End Sub

    Private Sub txt_nombre_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_proveedor.TextChanged

    End Sub

    Private Sub txt_precio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio.TextChanged
        If Combo_tipo_precio.Text = "FACTOR" Then
            Dim factor As Decimal
            Try
                factor = txt_precio.Text / valor_factor
                factor = factor.ToString("##,000.00")
                txt_factor.Text = factor
            Catch err As InvalidCastException
                txt_factor.Text = 0
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub txt_cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad.TextChanged

    End Sub

    Private Sub txt_costo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_costo.TextChanged

    End Sub

    Private Sub txt_factor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_factor.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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


    End Sub

    Private Sub txt_factor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_factor.TextChanged

    End Sub



    Private Sub btn_sugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sugerir.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim codigo As String
        Dim valor As Integer

        codigo = inicio_sugerir_codigo

        valor = codigo
        codigo = String.Format("{0:000000}", valor)

        conexion.Close()
        DS1.Tables.Clear()
        DT1.Rows.Clear()
        DT1.Columns.Clear()
        DS1.Clear()
        conexion.Open()
        SC1.Connection = conexion


        'SC1.CommandText = "select cod_producto from productos order by cod_producto asc"
        SC1.CommandText = "select cod_producto from productos where cod_producto >= '" & (codigo) & "' order by cod_producto asc"

        DA1.SelectCommand = SC1
        DA1.Fill(DT1)
        DS1.Tables.Add(DT1)
        grilla.DataSource = DS1.Tables(DT1.TableName)
        conexion.Close()

        Dim VarCodProducto As String

        codigo = inicio_sugerir_codigo

        valor = codigo
        codigo = String.Format("{0:000000}", valor)

        For i = 0 To grilla.Rows.Count - 1

            VarCodProducto = grilla.Rows(i).Cells(0).Value.ToString

            If codigo <> VarCodProducto Then
                txt_codigo.Text = codigo

                lbl_mensaje.Visible = False
                Me.Enabled = True

                txt_nombre.Focus()

                Exit Sub
            End If

            codigo = codigo + 1
            valor = codigo
            codigo = String.Format("{0:000000}", valor)

            txt_nombre.Focus()
        Next
        txt_codigo.Text = codigo

        codigo = codigo + 1
        valor = codigo
        codigo = String.Format("{0:000000}", valor)

        txt_nombre.Focus()

        Me.Enabled = True
        lbl_mensaje.Visible = False
        Exit Sub

    End Sub



    Private Sub btn_especifico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_especifico.Click
        controles(True, False)
        VarSeleccionproducto = 3
        txt_cantidad_minima.Enabled = False
        txt_codigo.Enabled = True
        txt_nombre.Enabled = False
        txt_marca.Enabled = False
        txt_aplicacion.Enabled = False
        txt_precio.Enabled = False
        txt_numero_tecnico.Enabled = False
        'txt_factor.Enabled = False
        txt_cantidad.Enabled = False
        txt_costo.Enabled = False
        txt_rut_proveedor.Enabled = False
        txt_codigo_barra.Enabled = False
        combo_familia.Enabled = False
        combo_subfamilia.Enabled = False
        Combo_subfamilia_2.Enabled = False
        btn_sugerir.Enabled = False
        btn_guardar.Enabled = False
        Combo_activo.Enabled = False
        Combo_tipo_precio.Enabled = False
        txt_codigo.Focus()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub



    Private Sub lbl_mensaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mensaje.Click

    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub

    Private Sub txt_cantidad_ultima_compra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_ultima_compra.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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


    End Sub

    Private Sub txt_cantidad_ultima_compra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_ultima_compra.TextChanged

    End Sub

    Private Sub txt_nro_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_doc.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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


    End Sub

    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub txt_tipo_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_tipo_doc.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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


    End Sub

    Private Sub txt_tipo_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tipo_doc.TextChanged

    End Sub



    Private Sub txt_cantidad_minima_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_minima.TextChanged

    End Sub



    Private Sub Combo_tipo_precio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo_precio.GotFocus
        Combo_tipo_precio.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_tipo_precio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo_precio.LostFocus
        Combo_tipo_precio.BackColor = Color.White
    End Sub

    Private Sub Combo_familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_familia.GotFocus
        Combo_familia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_familia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_familia.LostFocus
        Combo_familia.BackColor = Color.White
    End Sub

    Private Sub Combo_subfamilia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.GotFocus
        Combo_subfamilia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_subfamilia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.LostFocus
        Combo_subfamilia.BackColor = Color.White
    End Sub

    Private Sub Combo_subfamilia_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_subfamilia_2.GotFocus
        Combo_subfamilia_2.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_subfamilia_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_subfamilia_2.LostFocus
        Combo_subfamilia_2.BackColor = Color.White
    End Sub

    Private Sub Combo_tipo_precio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_tipo_precio.SelectedIndexChanged

    End Sub

    Private Sub Combo_subfamilia_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia_2.SelectedIndexChanged

        mostrar_codigo_subfamilia2()
    End Sub

    Private Sub Combo_familia_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_familia.SelectedIndexChanged

        'txt_codigo_subfamilia.Text = "-"
        'txt_codigo_subfamilia_2.Text = "-"
        mostrar_codigo_familia()
        llenar_combo_subfamilia()
    End Sub

    Private Sub Combo_subfamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.SelectedIndexChanged

        mostrar_codigo_subfamilia()
        llenar_combo_subfamilia2()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_posicion.Click
        Form_posicion_producto.Show()

        Me.Enabled = False
    End Sub

    Private Sub btn_posicion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_posicion.GotFocus
        btn_posicion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_posicion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_posicion.LostFocus
        btn_posicion.BackColor = Color.Transparent
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If txt_codigo.Text = "" Then
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_codigo.Focus()
            Exit Sub
        End If

        If VarSeleccionproducto = 1 Then
            conexion.Close()
            Consultas_SQL("select * from productos where cod_producto = '" & (txt_codigo.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                MsgBox("CODIGO DE PRODUCTO YA EXISTENTE", 0 + 16, "ERROR")
                Exit Sub
            End If
        End If

        If txt_nombre.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre.Focus()
            Exit Sub
        End If

        If txt_aplicacion.Text = "" Then
            MsgBox("CAMPO APLICACION VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_aplicacion.Focus()
            Exit Sub
        End If

        If txt_numero_tecnico.Text = "" Then
            MsgBox("CAMPO NRO. TECNICO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_numero_tecnico.Focus()
            Exit Sub
        End If

        If txt_marca.Text = "" Then
            MsgBox("CAMPO MARCA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_marca.Focus()
            Exit Sub
        End If

        If txt_codigo_barra.Text = "" Then
            MsgBox("CAMPO CODIGO DE BARRA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_codigo_barra.Focus()
            Exit Sub
        End If

        If txt_cantidad_minima.Text = "" Then
            MsgBox("CAMPO CANTIDAD MINIMA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_cantidad_minima.Focus()
            Exit Sub
        End If

        If txt_precio.Text = "" Then
            MsgBox("CAMPO PRECIO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_precio.Focus()
            Exit Sub
        End If

        If txt_cantidad.Text = "" Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_cantidad.Focus()
            Exit Sub
        End If

        If txt_costo.Text = "" Then
            MsgBox("CAMPO COSTO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_costo.Focus()
            Exit Sub
        End If

        If txt_factor.Text = "" Then
            MsgBox("CAMPO FACTOR VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_factor.Focus()
            Exit Sub
        End If

        If Combo_activo.Text = "-" Then
            MsgBox("CAMPO ACTIVO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_activo.Focus()
            Exit Sub
        End If

        If Combo_tipo_medida.Text = "-" Then
            MsgBox("CAMPO TIPO MEDIDA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_tipo_medida.Focus()
            Exit Sub
        End If

        If Combo_familia.SelectedItem = "-" Then
            txt_codigo_familia.Text = "-"
        End If

        If Combo_subfamilia.SelectedItem = "-" Then
            txt_codigo_subfamilia.Text = "-"
        End If

        If Combo_subfamilia_2.SelectedItem = "-" Then
            txt_codigo_subfamilia_2.Text = "-"
        End If

        Dim codigo As String = 0
        Dim valor As Integer
        codigo = txt_codigo.Text

        valor = codigo
        txt_codigo.Text = String.Format("{0:000000}", valor)

        If VarSeleccionproducto = 1 Then



            'If Combo_tipo_precio.Text = "" Then
            '    MsgBox("CAMPO TIPO PRECIO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            '    Combo_tipo_precio.Focus()
            '    Exit Sub
            'End If

            'If Combo_tipo_precio.Text = "-" Then
            '    MsgBox("CAMPO TIPO PRECIO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            '    Combo_tipo_precio.Focus()
            '    Exit Sub
            'End If

            'Dim tipo_precio As String
            'If Combo_tipo_precio.Text = "FACTOR" Then
            '    tipo_precio = "1"
            'End If
            'If Combo_tipo_precio.Text = "DIRECTO" Then
            '    tipo_precio = "2"
            'End If





            conexion.Close()
            Consultas_SQL("select * from productos where cod_producto = '" & (txt_codigo.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                MsgBox("CODIGO DE PRODUCTO YA EXISTENTE", 0 + 16, "ERROR")
                controles(True, False)

            Else

                Dim mifecha2 As String
                Dim mifecha As Date
                mifecha = dtp_ultima_compra.Text
                mifecha2 = mifecha.ToString("yyy-MM-dd")

                txt_rut_proveedor.Text = "11111111-1"

                SC.Connection = conexion
                SC.CommandText = "INSERT INTO productos(cod_producto, nombre, marca, aplicacion, numero_tecnico, cantidad, precio, costo, factor, familia, subfamilia, subfamilia_dos, proveedor, codigo_barra, ultima_compra, cantidad_ultima_compra, nro_doc, tipo_doc, cantidad_minima, fecha_modificacion, margen, numero_proveedor, tipo_precio, estado_producto, activo, tipo_medida) VALUES ('" & (txt_codigo.Text) & "','" & (txt_nombre.Text) & "','" & (txt_marca.Text) & "','" & (txt_aplicacion.Text) & "','" & (txt_numero_tecnico.Text) & "','" & (txt_cantidad.Text) & "','" & (txt_precio.Text) & "','" & (txt_costo.Text) & "','" & (txt_factor.Text) & "','" & (txt_codigo_familia.Text) & "','" & (txt_codigo_subfamilia.Text) & "','" & (txt_codigo_subfamilia_2.Text) & "','" & (txt_rut_proveedor.Text) & "','" & (txt_codigo_barra.Text) & "', '" & (mifecha2) & "','" & (txt_cantidad_ultima_compra.Text) & "', '" & (txt_nro_doc.Text) & "', '" & (txt_tipo_doc.Text) & "', '" & (txt_cantidad_minima.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "', '0', '-', '0', '-', '" & (Combo_activo.Text) & "', '" & (Combo_tipo_medida.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "INSERT INTO codigos_de_barra(codigo_barra, codigo_interno) VALUES ('" & (txt_codigo_barra.Text) & "','" & (txt_codigo.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','CREACION DE PRODUCTOS','" & (txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                controles(False, True)

                MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            End If

        ElseIf VarSeleccionproducto = 2 Then

            If txt_precio.Text = "" Then
                txt_precio.Text = "0"
            End If
            If txt_cantidad.Text = "" Then
                txt_cantidad.Text = "0"
            End If

            If txt_costo.Text = "" Then
                txt_costo.Text = "0"
            End If

            crear_nro_ajuste()
            fecha()

            If ModificacionNombre <> txt_nombre.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS','" & ("SE MODIFICO EL NOMBRE AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionAplicacion <> txt_aplicacion.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS','" & ("SE MODIFICO LA APLICACION AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionNroTecnico <> txt_numero_tecnico.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS', '" & ("SE MODIFICO EL NRO. TECNICO AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionMarca <> txt_marca.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS','" & ("SE MODIFICO LA MARCA AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionCodBarra <> txt_codigo_barra.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS','" & ("SE MODIFICO EL CODIGO DE BARRA AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionFamilia <> Combo_familia.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS','" & ("SE MODIFICO LA FAMILIA AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionSubFamilia <> Combo_subfamilia.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS','" & ("SE MODIFICO LA SUBFAMILIA AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionSubFamilia2 <> Combo_subfamilia_2.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS','" & ("SE MODIFICO LA SUBFAMILIA 2 AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionCantidad <> txt_cantidad.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS', '" & ("SE MODIFICO LA CANTIDAD AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionPrecio <> txt_precio.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS', '" & ("SE MODIFICO EL PRECIO AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionTIPOPrecio <> Combo_tipo_precio.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS', '" & ("SE MODIFICO EL TIPO DE PRECIO AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionCosto <> txt_costo.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS', '" & ("SE MODIFICO EL COSTO AL CODIGO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionProveedor <> txt_rut_proveedor.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS', '" & ("SE MODIFICO EL PROVEEDOR " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            If ModificacionActivo <> Combo_activo.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE PRODUCTOS', '" & ("SE MODIFICO ESTADO " & txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            SC.Connection = conexion
            SC.CommandText = "UPDATE  productos SET NOMBRE='" & (txt_nombre.Text) & "', marca='" & (txt_marca.Text) & "',aplicacion='" & (txt_aplicacion.Text) & "', numero_tecnico = '" & (txt_numero_tecnico.Text) & "', familia = '" & (txt_codigo_familia.Text) & "', subfamilia = '" & (txt_codigo_subfamilia.Text) & "',  subfamilia_dos = '" & (txt_codigo_subfamilia_2.Text) & "', cantidad = '" & (txt_cantidad.Text) & "' , precio = '" & (txt_precio.Text) & "' ,  COSTO = '" & (txt_costo.Text) & "' , factor = '" & (txt_factor.Text) & "' ,  codigo_barra = '" & (txt_codigo_barra.Text) & "',  fecha_modificacion ='" & (Form_menu_principal.dtp_fecha.Text) & "',  cantidad_minima ='" & (txt_cantidad_minima.Text) & "',activo ='" & (Combo_activo.Text) & "',  tipo_medida ='" & (Combo_tipo_medida.Text) & "' WHERE cod_producto = " & (txt_codigo.Text) & ""
            DA.SelectCommand = SC
            DA.Fill(DT)

            If ModificacionCodBarra <> txt_codigo_barra.Text Then
                SC.Connection = conexion
                SC.CommandText = "INSERT INTO  codigos_de_barra(codigo_barra, codigo_interno) VALUES ('" & (txt_codigo_barra.Text) & "','" & (txt_codigo.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If ModificacionCantidad <> txt_cantidad.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into  detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (txt_codigo.Text) & "','" & (txt_nombre.Text) & "'," & (txt_precio.Text) & ",'" & (txt_cantidad.Text) & "','0','0','0','0','0','AJUSTE', '" & (dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into ajustes_de_stock (n_ajuste, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (txt_codigo.Text) & "','" & (txt_nombre.Text) & "'," & (txt_precio.Text) & ",'" & (txt_cantidad.Text) & "','0','0','0','0','0','AJUSTE', '" & (dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'Dim diferencia_total As Integer

                'If ModificacionCantidad > txt_cantidad.Text Then
                '    diferencia_total = Val(ModificacionCantidad) - Val(txt_cantidad.Text)
                'End If

                'If ModificacionCantidad < txt_cantidad.Text Then
                '    diferencia_total = Val(txt_cantidad.Text) - Val(ModificacionCantidad)
                'End If

                'If txt_cantidad.Text = "0" Then
                '    diferencia_total = ModificacionCantidad
                'End If

                'If ModificacionCantidad > txt_cantidad.Text Then
                '    SC.Connection = conexion
                '    SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (txt_codigo.Text) & "','" & (txt_nombre.Text) & "'," & (txt_precio.Text) & "," & (txt_cantidad.Text) & ",'0','0','0','0','0','SALE', '" & (dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)

                '    SC.Connection = conexion
                '    SC.CommandText = "insert into ajustes_de_stock (n_ajuste, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (txt_codigo.Text) & "','" & (txt_nombre.Text) & "'," & (txt_precio.Text) & "," & (txt_cantidad.Text) & ",'0','0','0','0','0','SALE', '" & (dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)
                'ElseIf ModificacionCantidad < txt_cantidad.Text Then
                '    SC.Connection = conexion
                '    SC.CommandText = "insert into  detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (txt_codigo.Text) & "','" & (txt_nombre.Text) & "'," & (txt_precio.Text) & "," & (txt_cantidad.Text) & ",'0','0','0','0','0','ENTRA', '" & (dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)

                '    SC.Connection = conexion
                '    SC.CommandText = "insert into ajustes_de_stock (n_ajuste, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (txt_codigo.Text) & "','" & (txt_nombre.Text) & "'," & (txt_precio.Text) & "," & (txt_cantidad.Text) & ",'0','0','0','0','0','ENTRA', '" & (dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)
                'End If
            End If

            MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            controles(False, True)
        End If
    End Sub
End Class