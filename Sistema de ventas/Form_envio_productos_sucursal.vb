Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Form_envio_productos_sucursal
    Private WithEvents Pd As New PrintDocument
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim mifecha6 As String


    Dim segundos_actualizar As Integer
    Private Sub Form_envio_productos_sucursal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_envio_productos_sucursal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

        If e.KeyCode = Keys.F1 Then
            txt_codigo.Focus()
        End If
    End Sub

    Private Sub Form_envio_productos_sucursal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_vendedor()
        'dtp_fecha.CustomFormat = "yyy-MM-dd"
        grilla_sale.Font = New System.Drawing.Font("Arial", 10.25!, System.Drawing.FontStyle.Regular)
        dtp_ultima_compra.CustomFormat = "yyy-MM-dd"
        grilla_entra.Font = New System.Drawing.Font("Arial", 10.25!, System.Drawing.FontStyle.Regular)


        llenar_combo_sucursales()
        Combo_sucursal.SelectedItem = "-"

        dtp_desde.Value = dtp_hasta.Value.AddDays(Val(-1))
        dtp_desde_sin_recibir.Value = dtp_hasta.Value.AddDays(Val(-30))


        fecha()

        mostrar_malla()

        grilla_entra.Columns(9).Visible = True

        Timer_cierre.Start()



        If mirutempresa = "87686300-6" Then
            Me.grilla_entra.Columns(9).Visible = False
        End If

        If mirutempresa = "87686300-6" Then
            btn_imprimir.Visible = True
        Else
            btn_imprimir.Visible = False
        End If
        llenar_malla_imprimir()

    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub llenar_combo_sucursales()
        Combo_sucursal.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from sucursales  where nombre_sucursal <> '" & (mirecintoempresa) & "'order by nombre_sucursal"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        Combo_sucursal.Items.Add("-")

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
            Next
        End If
        Combo_sucursal.SelectedItem = "-"
        conexion.Close()
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")

        Dim mifecha7 As Date
        mifecha7 = dtp_desde_sin_recibir.Text
        mifecha6 = mifecha7.ToString("yyy-MM-dd")
    End Sub

    Sub mostrar_malla()


        fecha()

        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'SC.Connection = conexion

        'SC.CommandText = "select * from vale, productos, USUARIOS  WHERE ESTADO <> 'ANULADA' and vale.codigo_producto=productos.cod_producto AND VALE.usuario_responsable=usuarios.rut_usuario AND VALE.FECHA >='" & (mifecha2) & "' and VALE.FECHA <= '" & (mifecha4) & "'  ORDER by n_vale desc"

        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'grilla_sale.Rows.Clear()

        'Dim fecha_envio As String

        'If DS.Tables(DT.TableName).Rows.Count > 0 Then


        '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

        '        fecha_envio = DS.Tables(DT.TableName).Rows(i).Item("fecha")

        '        If fecha_envio.Length > 10 Then
        '            fecha_envio = fecha_envio.Substring(0, 10)
        '        End If

        '        grilla_sale.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_producto"), _
        '                                        DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
        '                                         DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
        '                                          DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
        '                                           DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
        '                                            fecha_envio, _
        '                                             DS.Tables(DT.TableName).Rows(i).Item("hora"), _
        '                                              DS.Tables(DT.TableName).Rows(i).Item("despachador"), _
        '                                               DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
        '                                                DS.Tables(DT.TableName).Rows(i).Item("n_vale"), _
        '                                                 DS.Tables(DT.TableName).Rows(i).Item("sucursal"), _
        '                                                  DS.Tables(DT.TableName).Rows(i).Item("estado"))
        '    Next



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from vale, productos, USUARIOS  WHERE estado = 'EMITIDA' and vale.codigo_producto=productos.cod_producto AND vale.usuario_responsable=usuarios.rut_usuario AND vale.fecha >='" & (mifecha6) & "' and vale.fecha <= '" & (mifecha4) & "'  order by n_vale desc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_sale.Rows.Clear()

        Dim fecha_envio As String

        If DS.Tables(DT.TableName).Rows.Count > 0 Then


            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                fecha_envio = DS.Tables(DT.TableName).Rows(i).Item("fecha")

                If fecha_envio.Length > 10 Then
                    fecha_envio = fecha_envio.Substring(0, 10)
                End If

                grilla_sale.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                    fecha_envio, _
                                                     DS.Tables(DT.TableName).Rows(i).Item("hora"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("despachador"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("n_vale"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("sucursal"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("estado"))
            Next
        End If




        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from vale, productos, USUARIOS  WHERE ESTADO = 'RECIBIDO' and vale.codigo_producto=productos.cod_producto AND VALE.usuario_responsable=usuarios.rut_usuario AND VALE.FECHA >='" & (mifecha2) & "' and VALE.FECHA <= '" & (mifecha4) & "'  ORDER by n_vale desc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        ' grilla_sale.Rows.Clear()

        'Dim fecha_envio As String

        If DS.Tables(DT.TableName).Rows.Count > 0 Then


            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                fecha_envio = DS.Tables(DT.TableName).Rows(i).Item("fecha")

                If fecha_envio.Length > 10 Then
                    fecha_envio = fecha_envio.Substring(0, 10)
                End If

                grilla_sale.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                    fecha_envio, _
                                                     DS.Tables(DT.TableName).Rows(i).Item("hora"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("despachador"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("n_vale"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("sucursal"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("estado"))
            Next
        End If







        Me.grilla_sale.Columns(0).Width = grilla_sale.Columns(0).Width
        Me.grilla_sale.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.grilla_sale.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.grilla_sale.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.grilla_sale.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight



        Dim estado_revision As String

        For i = 0 To grilla_sale.Rows.Count - 1
            estado_revision = grilla_sale.Rows(i).Cells(11).Value.ToString

            If estado_revision = "RECIBIDO" Then
                grilla_sale.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

        Next



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from vale_traslado_recibidos, USUARIOS  WHERE ESTADO <> 'ANULADA' AND ESTADO <> 'RECIBIDO' AND vale_traslado_recibidos.usuario_responsable=usuarios.rut_usuario AND vale_traslado_recibidos.FECHA >='" & (mifecha6) & "' and vale_traslado_recibidos.FECHA <= '" & (mifecha4) & "' ORDER by estado asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_entra.Rows.Clear()



        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            Dim fecha_recibo As String
            fecha_recibo = DS.Tables(DT.TableName).Rows(0).Item("fecha")
            If fecha_recibo.Length > 10 Then
                fecha_recibo = fecha_recibo.Substring(0, 10)
            End If

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_producto"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("nro_tecnico"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     fecha_recibo, _
                                                      DS.Tables(DT.TableName).Rows(i).Item("hora"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("despachador"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("n_vale"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("sucursal"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("nro_tecnico"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("marca"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("cod_barra"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("familia"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("subfamilia"), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("subfamilia2"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("cantidad_minima"), _
                                                                    DS.Tables(DT.TableName).Rows(i).Item("precio"), _
                                                                     DS.Tables(DT.TableName).Rows(i).Item("tipo_precio"), _
                                                                      DS.Tables(DT.TableName).Rows(i).Item("factor"), _
                                                                       DS.Tables(DT.TableName).Rows(i).Item("costo"), _
                                                                        DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor"), _
                                                                         DS.Tables(DT.TableName).Rows(i).Item("fecha_ult_compra"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("cant_ult_compra"), _
                                                                           DS.Tables(DT.TableName).Rows(i).Item("tipo_doc"), _
                                                                            DS.Tables(DT.TableName).Rows(i).Item("nro_doc"), _
                                                                             DS.Tables(DT.TableName).Rows(i).Item("estado"))
            Next
        End If





        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from vale_traslado_recibidos, USUARIOS  WHERE ESTADO <> 'ANULADA' AND ESTADO = 'RECIBIDO' AND vale_traslado_recibidos.usuario_responsable=usuarios.rut_usuario AND vale_traslado_recibidos.FECHA >='" & (mifecha2) & "' and vale_traslado_recibidos.FECHA <= '" & (mifecha4) & "' ORDER by estado asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        ' grilla_entra.Rows.Clear()



        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            Dim fecha_recibo As String
            fecha_recibo = DS.Tables(DT.TableName).Rows(0).Item("fecha")
            If fecha_recibo.Length > 10 Then
                fecha_recibo = fecha_recibo.Substring(0, 10)
            End If

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_producto"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("nro_tecnico"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     fecha_recibo, _
                                                      DS.Tables(DT.TableName).Rows(i).Item("hora"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("despachador"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("n_vale"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("sucursal"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("nro_tecnico"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("marca"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("cod_barra"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("familia"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("subfamilia"), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("subfamilia2"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("cantidad_minima"), _
                                                                    DS.Tables(DT.TableName).Rows(i).Item("precio"), _
                                                                     DS.Tables(DT.TableName).Rows(i).Item("tipo_precio"), _
                                                                      DS.Tables(DT.TableName).Rows(i).Item("factor"), _
                                                                       DS.Tables(DT.TableName).Rows(i).Item("costo"), _
                                                                        DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor"), _
                                                                         DS.Tables(DT.TableName).Rows(i).Item("fecha_ult_compra"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("cant_ult_compra"), _
                                                                           DS.Tables(DT.TableName).Rows(i).Item("tipo_doc"), _
                                                                            DS.Tables(DT.TableName).Rows(i).Item("nro_doc"), _
                                                                             DS.Tables(DT.TableName).Rows(i).Item("estado"))
            Next
        End If








        ' Me.grilla_estado_de_cuenta_final.Columns(3).Visible = False
        Me.grilla_entra.Columns(0).Width = grilla_entra.Columns(0).Width
        Me.grilla_entra.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.grilla_entra.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.grilla_entra.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.grilla_entra.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight


        '  Dim estado_revision As String

        For i = 0 To grilla_entra.Rows.Count - 1
            estado_revision = grilla_entra.Rows(i).Cells(29).Value.ToString

            If estado_revision = "RECIBIDO" Then
                grilla_entra.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

        Next





    End Sub


    Sub llenar_combo_vendedor()
        Combo_vendedor.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios WHERE ACTIVO='SI' order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        Combo_vendedor.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        Combo_vendedor.SelectedItem = ("-")

        conexion.Close()
    End Sub

    Sub mostrar_datos_vendedor()
        conexion.Close()
        If Combo_vendedor.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where nombre_usuario ='" & (Combo_vendedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If

            conexion.Close()
        End If
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
                    txt_nombre_producto.Text = ""
                    txt_marca.Text = ""
                    txt_aplicacion.Text = ""
                    txt_numero_tecnico.Text = ""
                    'combo_familia.Text = ""
                    'combo_subfamilia.Text = ""
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


                    'combo_familia.Text = "-"
                    'combo_subfamilia.Text = "-"
                    'Combo_subfamilia_2.Text = "-"

                    txt_codigo_familia.Text = "-"
                    txt_codigo_subfamilia.Text = "-"
                    txt_codigo_subfamilia_2.Text = "-"

                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    'combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                    'combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                    txt_stock.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
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
                    txt_tipo_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_precio")

                    If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "1" Then
                        Combo_tipo_precio.Text = "FACTOR"
                    End If

                    If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "2" Then
                        Combo_tipo_precio.Text = "DIRECTO"
                    End If

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

    Sub limpiar_producto()

        txt_stock.Text = ""
        txt_marca.Text = ""
        txt_aplicacion.Text = ""
        txt_precio.Text = ""
        txt_numero_tecnico.Text = ""
        txt_factor.Text = ""
        txt_cantidad.Text = ""
        txt_costo.Text = ""
        txt_rut_proveedor.Text = ""
        txt_nombre_producto.Text = ""
        txt_codigo_barra.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_nro_doc.Text = ""
        txt_tipo_doc.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_nro_doc.Text = ""
        txt_tipo_doc.Text = ""
    End Sub

    Sub limpiar()

        Combo_vendedor.Text = "-"


        txt_nombre_producto.Text = ""
        txt_marca.Text = ""
        txt_aplicacion.Text = ""
        txt_precio.Text = ""
        txt_numero_tecnico.Text = ""
        txt_factor.Text = ""
        txt_cantidad.Text = ""
        txt_costo.Text = ""
        txt_rut_proveedor.Text = ""
        txt_proveedor.Text = ""
        txt_codigo_barra.Text = ""
        txt_codigo.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_nro_doc.Text = ""
        txt_tipo_doc.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_nro_doc.Text = ""
        txt_tipo_doc.Text = ""
        txt_stock.Text = ""
        Combo_sucursal.Text = "-"
        dtp_hasta.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_desde.Value = dtp_hasta.Value.AddDays(Val(-1))
        ' Combo_vendedor.SelectedItem = ("-")
    End Sub


    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress

        limpiar_producto()

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

            mostrar_datos_productos()
            mostrar_nombre_proveedor()
            '  txt_codigo.Enabled = False
            '    txt_nombre.Enabled = True
            ' txt_codigo_barra.Enabled = True
            '  COMBO.Focus()
            txt_cantidad.Focus()
        End If

    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress

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
            Combo_vendedor.Focus()
            'Combo_vendedor.DroppedDown = True
        End If
    End Sub


    Private Sub txt_cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad.TextChanged

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub






    Sub totales()
        txt_total.Text = Int(txt_cantidad.Text) - Int(txt_precio.Text)

        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        neto = (txt_total.Text / iva_valor)
        Round(neto)
        txt_neto.Text = neto

        iva = ((txt_neto.Text) * valor_iva / 100)
        Round(iva)
        txt_iva.Text = iva
    End Sub

    Sub recorrer_malla()
        Dim VarNroVale As String
        Dim VarDespachadoPor As String
        Dim VarCodProducto As String
        Dim VarCantidad As String
        Dim VarFecha As String
        Dim VarHora As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarAplicacion As String
        Dim VarGeneradoPor As String

        For i = 0 To grilla_sale.Rows.Count - 1



            VarCodProducto = Me.grilla_sale.Rows(i).Cells(0).Value.ToString
            varnombre = Me.grilla_sale.Rows(i).Cells(1).Value.ToString
            vartecnico = Me.grilla_sale.Rows(i).Cells(2).Value.ToString
            VarAplicacion = Me.grilla_sale.Rows(i).Cells(3).Value.ToString
            VarCantidad = Me.grilla_sale.Rows(i).Cells(4).Value.ToString
            VarFecha = Me.grilla_sale.Rows(i).Cells(5).Value.ToString
            VarHora = Me.grilla_sale.Rows(i).Cells(6).Value.ToString
            VarDespachadoPor = Me.grilla_sale.Rows(i).Cells(7).Value.ToString
            VarGeneradoPor = Me.grilla_sale.Rows(i).Cells(8).Value.ToString
            VarNroVale = Me.grilla_sale.Rows(i).Cells(9).Value.ToString





            If VarCodProducto = txt_codigo.Text And VarNroVale = txt_nro_vale.Text Then
                Me.Enabled = False
                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_ticket
                    '.PrinterName = "\\SERVER\HP LaserJet Professional P 1102w"
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then


                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
                Me.Enabled = True
            End If
        Next
    End Sub

    Sub crear_nro_vale()
        Dim VarNumVale As String

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        Try
            SC.Connection = conexion
            SC.CommandText = "select max(n_vale) as n_vale from vale"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarNumVale = DS.Tables(DT.TableName).Rows(0).Item("n_vale")
                txt_nro_vale.Text = VarNumVale + 1
            End If
        Catch err As InvalidCastException
            txt_nro_vale.Text = 1
        End Try
        conexion.Close()
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
        'Combo_vendedor.DroppedDown = True
    End Sub

    Private Sub Combo_vendedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.Click
        ' If Not Combo_vendedor.DroppedDown Then



    End Sub



    Private Sub Combo_vendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Combo_vendedor.KeyDown
        If e.KeyCode = Keys.Enter Then

            btn_agregar.Focus()

        End If
    End Sub

    Private Sub Combo_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.LostFocus
        If ActiveControl.Name <> "Combo_vendedor" Then
            Combo_vendedor.BackColor = Color.White
            Combo_vendedor.DroppedDown = False
        End If
    End Sub


    'Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_guardarR.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_guardarR.BackColor = Color.Transparent
    'End Sub

    'Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.Transparent
    'End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        btn_aceptar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_estado_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_estado.GotFocus
        btn_estado.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_estado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_estado.LostFocus
        btn_estado.BackColor = Color.Transparent
    End Sub

    Private Sub btn_agregar_entra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_entra.GotFocus
        btn_agregar_entra.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_entra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_entra.LostFocus
        btn_agregar_entra.BackColor = Color.Transparent
    End Sub
    Private Sub Combo_sucursal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_sucursal.GotFocus
        Combo_sucursal.BackColor = Color.LightSkyBlue
        Combo_sucursal.DroppedDown = True
    End Sub

    Private Sub Combo_sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_sucursal.KeyPress
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
            btn_agregar.Focus()
        End If
    End Sub

    Private Sub Combo_sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_sucursal.LostFocus
        Combo_sucursal.BackColor = Color.WhiteSmoke
        Combo_sucursal.DroppedDown = False
    End Sub

    Private Sub Combo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.GotFocus
        Combo_vendedor.BackColor = Color.LightSkyBlue

        ' Combo_vendedor.DroppedDown = True
        'If Not Combo_vendedor.DroppedDown Then
        '    Combo_vendedor.DroppedDown = True
        'End If

        'If Combo_vendedor.DroppedDown = False Then
        '    Combo_vendedor.DroppedDown = True
        '    Exit Sub
        'End If

        'If Not Combo_vendedor.DroppedDown Then
        '    Combo_vendedor.DroppedDown = True
        'End If

        Combo_vendedor.DroppedDown = True


    End Sub

    Private Sub CCombo_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.LostFocus




        If ActiveControl.Name <> "Combo_vendedor" Then
            Combo_vendedor.BackColor = Color.WhiteSmoke
            Combo_vendedor.DroppedDown = False
        End If
    End Sub

    'Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_quitar_elemento.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_quitar_elemento.BackColor = Color.Transparent
    'End Sub

    'Private Sub btn_quitar_entra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_quitar_entra.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_quitar_entra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_quitar_entra.BackColor = Color.Transparent
    'End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grilla_sale.Rows.Count > 0 Then
            Form_autorizacion_traspaso.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_codigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_productos_traspaso_sucursal.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        conexion.Close()
        Me.Enabled = False
        txt_codigo.Focus()
        Form_buscador_productos_traspaso_sucursal.Show()
        Form_buscador_productos_traspaso_sucursal.txt_busqueda.Focus()
    End Sub

    Private Sub grilla_estado_de_cuenta_final_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub grilla_estado_de_cuenta_final_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim valormensaje As Integer

        'If grilla_estado_de_cuenta_final.Rows.Count <> 0 Then
        '    valormensaje = MsgBox("¿DESEA REIMPRIMIR EL ENVIO A SUCURSAL?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        '    If valormensaje = vbYes Then
        '        Me.Enabled = False
        '        With Pd.PrinterSettings
        '            ' Especifico el nombre de la impresora 
        '            ' por donde deseo imprimir. 
        '            .PrinterName = impresora_ticket
        '            ' .PrinterName = "\\SERVER\HP LaserJet Professional P 1102w"
        '            ' Establezco el número de copias que se imprimirán 
        '            .Copies = 1
        '            ' Rango de páginas que se imprimirán 
        '            .PrintRange = PrintRange.AllPages
        '            If .IsValid Then


        '                Me.Pd.PrintController = New StandardPrintController
        '                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
        '                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
        '                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
        '                Pd.Print()
        '            Else
        '                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
        '                Me.Enabled = True
        '                Exit Sub
        '            End If
        '        End With
        '        Me.Enabled = True
        '    End If
        'End If
    End Sub

    ' '' '' '' '' '' '' ''Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage

    ' '' '' '' '' '' '' ''    Dim VarNroVale As String
    ' '' '' '' '' '' '' ''    Dim VarDespachadoPor As String
    ' '' '' '' '' '' '' ''    Dim VarCodProducto As String
    ' '' '' '' '' '' '' ''    Dim VarCantidad As String
    ' '' '' '' '' '' '' ''    Dim VarFecha As String
    ' '' '' '' '' '' '' ''    Dim VarHora As String
    ' '' '' '' '' '' '' ''    Dim varnombre As String
    ' '' '' '' '' '' '' ''    Dim vartecnico As String
    ' '' '' '' '' '' '' ''    Dim VarAplicacion As String
    ' '' '' '' '' '' '' ''    Dim VarGeneradoPor As String

    ' '' '' '' '' '' '' ''    Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
    ' '' '' '' '' '' '' ''    Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
    ' '' '' '' '' '' '' ''    Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
    ' '' '' '' '' '' '' ''    Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)



    ' '' '' '' '' '' '' ''    Dim format1 As New StringFormat(StringFormatFlags.NoClip)
    ' '' '' '' '' '' '' ''    format1.Alignment = StringAlignment.Far


    ' '' '' '' '' '' '' ''    Dim Font1 As New Font("arial", 7, FontStyle.Regular)
    ' '' '' '' '' '' '' ''    Dim Font2 As New Font("arial", 9, FontStyle.Bold)
    ' '' '' '' '' '' '' ''    Dim Font3 As New Font("arial", 7, FontStyle.Bold)
    ' '' '' '' '' '' '' ''    Dim Font4 As New Font("arial", 8, FontStyle.Bold)

    ' '' '' '' '' '' '' ''    Dim im As Image

    ' '' '' '' '' '' '' ''    Try
    ' '' '' '' '' '' '' ''        im = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
    ' '' '' '' '' '' '' ''        Dim p As New PointF(0, 0)
    ' '' '' '' '' '' '' ''        e.Graphics.DrawImage(im, p)
    ' '' '' '' '' '' '' ''    Catch
    ' '' '' '' '' '' '' ''    End Try

    ' '' '' '' '' '' '' ''    Dim stringFormat As New StringFormat()
    ' '' '' '' '' '' '' ''    stringFormat.Alignment = StringAlignment.Center
    ' '' '' '' '' '' '' ''    stringFormat.LineAlignment = StringAlignment.Center

    ' '' '' '' '' '' '' ''    Dim rect1 As New Rectangle(10, 60, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect2 As New Rectangle(10, 75, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect3 As New Rectangle(10, 90, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect4 As New Rectangle(10, 105, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect5 As New Rectangle(10, 120, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect6 As New Rectangle(10, 135, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect7 As New Rectangle(10, 165, 270, 15)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("ENVIO A SUCURSAL", Font2, Brushes.Black, rect7, stringFormat)





    ' '' '' '' '' '' '' ''    VarCodProducto = Me.grilla_sale.CurrentRow.Cells(0).Value
    ' '' '' '' '' '' '' ''    varnombre = Me.grilla_sale.CurrentRow.Cells(1).Value
    ' '' '' '' '' '' '' ''    vartecnico = Me.grilla_sale.CurrentRow.Cells(2).Value
    ' '' '' '' '' '' '' ''    VarAplicacion = Me.grilla_sale.CurrentRow.Cells(3).Value
    ' '' '' '' '' '' '' ''    VarCantidad = Me.grilla_sale.CurrentRow.Cells(4).Value
    ' '' '' '' '' '' '' ''    VarFecha = Me.grilla_sale.CurrentRow.Cells(5).Value
    ' '' '' '' '' '' '' ''    VarHora = Me.grilla_sale.CurrentRow.Cells(6).Value
    ' '' '' '' '' '' '' ''    VarDespachadoPor = Me.grilla_sale.CurrentRow.Cells(7).Value
    ' '' '' '' '' '' '' ''    VarGeneradoPor = Me.grilla_sale.CurrentRow.Cells(8).Value
    ' '' '' '' '' '' '' ''    VarNroVale = Me.grilla_sale.CurrentRow.Cells(9).Value






    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("NRO. VALE", Font3, Brushes.Black, 0, 195)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 195)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarNroVale, Font4, Brushes.Black, 95, 195)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 210)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 210)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarFecha & " " & VarHora, Font3, Brushes.Black, 95, 210)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("RETIRADO POR", Font3, Brushes.Black, 0, 225)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 225)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarDespachadoPor, Font3, Brushes.Black, 95, 225)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("GENERADO POR", Font3, Brushes.Black, 0, 240)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 240)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarGeneradoPor, Font3, Brushes.Black, 95, 240)


    ' '' '' '' '' '' '' ''    e.Graphics.DrawLine(Pens.Black, 1, 260, 295, 260)


    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("CODIGO", Font3, Brushes.Black, 0, 270)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 270)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarCodProducto, Font3, Brushes.Black, 95, 270)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("NOMBRE", Font3, Brushes.Black, 0, 285)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 285)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(varnombre, Font3, Brushes.Black, 95, 285)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("NRO. TECNICO", Font3, Brushes.Black, 0, 300)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 300)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(vartecnico, Font3, Brushes.Black, 95, 300)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("APLICACION", Font3, Brushes.Black, 0, 315)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 315)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarAplicacion, Font3, Brushes.Black, 95, 315)

    ' '' '' '' '' '' '' ''    Dim cantidad As String
    ' '' '' '' '' '' '' ''    cantidad = VarCantidad
    ' '' '' '' '' '' '' ''    cantidad = Format(Int(cantidad), "###,###,###")

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("CANT.", Font3, Brushes.Black, 0, 330)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 330)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(cantidad, Font3, Brushes.Black, 95, 330)


    ' '' '' '' '' '' '' ''    e.Graphics.DrawLine(Pens.Black, 1, 350, 295, 350)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawLine(Pens.Black, 1, 450, 295, 450)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, 508)

    ' '' '' '' '' '' '' ''End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged

    End Sub

    Private Sub txt_nombre_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_producto.KeyPress, txt_nombre_producto.KeyPress
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


    End Sub

    Private Sub txt_numero_tecnico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_tecnico.KeyPress
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


    End Sub

    Private Sub txt_numero_tecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.TextChanged

    End Sub

    Private Sub txt_aplicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_aplicacion.KeyPress
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


    End Sub

    Private Sub txt_aplicacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_aplicacion.TextChanged

    End Sub

    Private Sub GroupBox_vendedor_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Sub mostrar_nombre_proveedor()
        conexion.Close()
        If txt_rut_proveedor.Text <> "" Then
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
            txt_proveedor.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If txt_codigo.Text = "" Then
            MsgBox("CAMPO CODIGO PRODUCTO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_codigo.Focus()
            Exit Sub
        End If

        If txt_nombre_producto.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre_producto.Focus()
            Exit Sub
        End If

        If txt_cantidad.Text = "" Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_cantidad.Focus()
            Exit Sub
        End If

        If Combo_vendedor.Text = "" Then
            MsgBox("CAMPO DESPACHADOR VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_vendedor.Focus()
            Exit Sub
        End If

        If Combo_vendedor.Text = "-" Then
            MsgBox("CAMPO DESPACHADOR VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_vendedor.Focus()
            Exit Sub
        End If

        If Combo_sucursal.Text = "" Then
            MsgBox("CAMPO SUCURSAL VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_sucursal.Focus()
            Exit Sub
        End If

        If Combo_sucursal.Text = "-" Then
            MsgBox("CAMPO SUCURSAL VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_sucursal.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        totales()
        crear_nro_vale()

        With Pd.PrinterSettings
            .PrinterName = impresora_despacho
            .Copies = 2
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.Pd.PrintController = New StandardPrintController
                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End With


        SC.Connection = conexion
        SC.CommandText = "insert into vale (n_vale, despachador, codigo_producto, cantidad, fecha, hora, estado, usuario_responsable, sucursal, valor_unitario, nombre_producto) values(" & (txt_nro_vale.Text) & ", '" & (Combo_vendedor.Text) & "', '" & (txt_codigo.Text) & "','" & (txt_cantidad.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','EMITIDA','" & (miusuario) & "','" & (Combo_sucursal.Text) & "','" & (txt_precio.Text) & "','" & (txt_nombre_producto.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "update productos set cantidad = cantidad - " & (Int(txt_cantidad.Text)) & " where cod_producto = '" & (txt_codigo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (txt_nro_vale.Text) & ",'VALE DE TRASLADO', '" & (txt_codigo.Text) & "','" & (txt_nombre_producto.Text) & "'," & (txt_precio.Text) & ",'" & (txt_cantidad.Text) & "'," & (0) & "," & (txt_neto.Text) & ", " & (txt_iva.Text) & "," & (txt_total.Text) & "," & (txt_total.Text) & ",'SALE','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (miusuario) & "' ,'EMITIDA')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        crear_conexion()

        'SC.Connection = conexion
        'SC.CommandText = "insert into vale_traslado_recibidos (n_vale, despachador, codigo_producto, cantidad, fecha, hora, estado, usuario_responsable, sucursal, nombre, aplicacion, nro_tecnico, marca, cod_barra, familia, subfamilia, subfamilia2, cantidad_minima, precio, tipo_precio, factor, costo, rut_proveedor, fecha_ult_compra, cant_ult_compra, tipo_doc, nro_doc) values(" & (txt_nro_vale.Text) & ", '" & (Combo_vendedor.Text) & "', '" & (txt_codigo.Text) & "','" & (txt_cantidad.Text) & "','" & (form_Menu_admin.dtp_fecha.Text) & "','" & (form_Menu_admin.lbl_hora.Text) & "','EMITIDA','" & (miusuario) & "','" & (mirecintoempresa) & "', '" & (txt_nombre_producto.Text) & "', '" & (txt_aplicacion.Text) & "', '" & (txt_numero_tecnico.Text) & "', '" & (txt_marca.Text) & "', '" & (txt_codigo_barra.Text) & "', '" & (txt_codigo_familia.Text) & "', '" & (txt_codigo_subfamilia.Text) & "', '" & (txt_codigo_subfamilia_2.Text) & "', '" & (txt_cantidad_minima.Text) & "', '" & (txt_precio.Text) & "', '" & (txt_tipo_precio.Text) & "', '" & (txt_factor.Text) & "', '" & (txt_costo.Text) & "', '" & (txt_rut_proveedor.Text) & "', '" & (dtp_ultima_compra.Text) & "', '" & (txt_cantidad_ultima_compra.Text) & "', '" & (txt_tipo_doc.Text) & "', '" & (txt_nro_doc.Text) & "')"
        'DA.SelectCommand = SC
        'DA.Fill(DT)

        recuperar_conexion()
        limpiar()
        mostrar_malla()

        lbl_mensaje.Visible = False
        Me.Enabled = True

        MsgBox("ENVIO REALIZADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        txt_codigo.Focus()
    End Sub

    Private Sub dtp_fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        lbl_mensaje.Visible = True
        Me.Enabled = False

        fecha()
        mostrar_malla()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.Click
        conexion.Close()
        Me.Enabled = False
        txt_codigo.Focus()
        Form_buscador_productos_traspaso_sucursal.Show()
        Form_buscador_productos_traspaso_sucursal.txt_busqueda.Focus()
    End Sub

    Private Sub btn_agregar_entra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_entra.Click
        'Dim VarSucursal As String
        'Dim VarNrovale As String
        'Dim VarCodProducto As String

        If grilla_entra.Rows.Count > 0 Then
            For i = 0 To grilla_entra.Rows.Count - 1
                If grilla_entra.Rows(i).Cells(30).Value = True And grilla_entra.Rows(i).Cells(29).Value <> "RECIBIDO" Then
                    Form_autorizacion_traspaso.Show()
                    Me.Enabled = False
                    Exit Sub
                End If
            Next
        End If

    End Sub

    Private Sub btn_quitar_entra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grilla_entra.Rows.Count > 0 Then

            For i = 0 To grilla_entra.Rows.Count - 1
                If grilla_entra.Rows(i).Cells(29).Value = True Then
                    Form_autorizacion_traspaso.Show()
                    Me.Enabled = False
                    Exit Sub
                End If
            Next

        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        mostrar_malla()
        lbl_mensaje.Visible = False
        Me.Enabled = True
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

    Private Sub Timer_cierre_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_cierre.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub

    Private Sub Check_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_todos.CheckedChanged
        If Check_todos.Checked = True Then
            For i = 0 To grilla_entra.Rows.Count - 1
                If grilla_entra.Rows(i).Cells(29).Value <> "RECIBIDO" Then
                    grilla_entra.Rows(i).Cells(30).Value = True
                End If
            Next
        Else
            For i = 0 To grilla_entra.Rows.Count - 1
                grilla_entra.Rows(i).Cells(30).Value = False
            Next
        End If
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA IMPRIMIR LA GUIA DIARIA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then

            llenar_malla_imprimir()
            calcular_totales()
            'With Pd.PrinterSettings
            '    ' Especifico el nombre de la impresora 
            '    ' por donde deseo imprimir. 
            '    .PrinterName = impresora_guias
            '    '.PrinterName = "\\caja-pc\HP LaserJet Professional P 1102w"
            '    ' Establezco el número de copias que se imprimirán 
            '    .Copies = 1
            '    ' Rango de páginas que se imprimirán 
            '    .PrintRange = PrintRange.AllPages
            '    If .IsValid Then
            '        crear_numero_guia()
            '        grabar_guia()
            '        Me.Pd.PrintController = New StandardPrintController
            '        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
            '        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
            '        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
            '        Pd.Print()
            '        Me.Enabled = True
            '        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            '        Exit Sub
            '    Else
            '        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
            '        lbl_mensaje.Visible = False
            '        Me.Enabled = True
            '        Exit Sub
            '    End If
            'End With

            lbl_mensaje.Visible = True
            Me.Enabled = False

            If estado_guia_electronica = "NO" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_guias
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.crear_numero_guia()
                        Me.grabar_guia()
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        'Me.grabar_detalle_factura()
                        Me.crear_archivo_plano()
                        'Form_autorizacion.Close()
                        'Me.limpiar()
                        ' Me.controles(False, True)
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                Me.crear_numero_guia()
                Me.grabar_guia()
                'Me.grabar_detalle_factura()
                Me.crear_archivo_plano()
                'Form_autorizacion.Close()
                'Me.limpiar()
                'Me.controles(False, True)
                lbl_mensaje.Visible = False
                Me.Enabled = True
                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

        End If
    End Sub

    Sub grabar_guia()
        Dim neto As Integer
        Dim iva As Integer
        Dim subtotal As Integer
        Dim total As Integer

        neto = "1696050"
        iva = "322250"
        subtotal = "2018300"
        total = "2018300"

        SC.Connection = conexion
        SC.CommandText = "insert into guia (n_guia, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable,rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, vehiculo, patente, pie, condicion_de_pago_pie, comision) values (" & (txt_nro_guia.Text) & " , '" & ("GUIA") & "', '87686300-6','27216','" & (Form_menu_principal.dtp_fecha.Text) & "','0'," & (neto) & "," & (iva) & "," & (subtotal) & "," & (total) & ",'TRASLADO','" & ("SIN FACTURAR") & "','SISTEMA','-','-','" & (mirecintoempresa) & "','" & ("0") & "','" & (Form_menu_principal.lbl_hora.Text) & "','0','MANUAL', '-', '-', '0', '0', '0')"
        DA.SelectCommand = SC
        DA.Fill(DT)
    End Sub

    'Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
    '    Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
    '    Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
    '    Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
    '    Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

    '    Dim format1 As New StringFormat(StringFormatFlags.NoClip)
    '    format1.Alignment = StringAlignment.Far

    '    Dim Font1 As New Font("arial", 7, FontStyle.Regular)
    '    Dim Font2 As New Font("arial", 10, FontStyle.Bold)
    '    Dim Font3 As New Font("arial", 7, FontStyle.Bold)
    '    Dim Font4 As New Font("arial", 8, FontStyle.Regular)

    '    Dim stringFormat As New StringFormat()
    '    stringFormat.Alignment = StringAlignment.Center
    '    stringFormat.LineAlignment = StringAlignment.Center

    '    Dim rect7 As New Rectangle(10, 0, 270, 15)
    '    Dim rect8 As New Rectangle(10, 90, 270, 50)

    '    e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 100, 20)
    '    e.Graphics.DrawString(txt_nro_guia.Text, Font10, Brushes.Black, 550, 20, format1)
    '    e.Graphics.DrawString("RAFAEL ARANA Y CIA.", Font10, Brushes.Black, 100, 36)
    '    e.Graphics.DrawString("O'HIGGINS 452", Font10, Brushes.Black, 100, 52)
    '    e.Graphics.DrawString("REPUESTOS AUTOMOTRICES", Font10, Brushes.Black, 100, 68)
    '    e.Graphics.DrawString("", Font10, Brushes.Black, 100, 84)
    '    e.Graphics.DrawString("87686300-6", Font10, Brushes.Black, 655, 20)
    '    e.Graphics.DrawString("SAN FERNANDO", Font10, Brushes.Black, 655, 36)
    '    e.Graphics.DrawString("714173", Font10, Brushes.Black, 655, 52)
    '    e.Graphics.DrawString("TRASLADO", Font10, Brushes.Black, 655, 68)
    '    e.Graphics.DrawString(miusuario, Font10, Brushes.Black, 655, 84)
    '    e.Graphics.DrawString("01", Font8, Brushes.Black, 0, 145 + (1 * 15))
    '    e.Graphics.DrawString("FILTRO", Font8, Brushes.Black, 75, 145 + (1 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (1 * 15))
    '    e.Graphics.DrawString("12", Font8, Brushes.Black, 520, 145 + (1 * 15), format1)
    '    e.Graphics.DrawString("2.400", Font8, Brushes.Black, 600, 145 + (1 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (1 * 15), format1)
    '    e.Graphics.DrawString("28.800", Font8, Brushes.Black, 725, 145 + (1 * 15), format1)
    '    e.Graphics.DrawString("28.800", Font8, Brushes.Black, 792, 145 + (1 * 15), format1)
    '    e.Graphics.DrawString("02", Font8, Brushes.Black, 0, 145 + (2 * 15))
    '    e.Graphics.DrawString("ACEITE LUBRICANTE", Font8, Brushes.Black, 75, 145 + (2 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (2 * 15))
    '    e.Graphics.DrawString("18", Font8, Brushes.Black, 520, 145 + (2 * 15), format1)
    '    e.Graphics.DrawString("14.800", Font8, Brushes.Black, 600, 145 + (2 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (2 * 15), format1)
    '    e.Graphics.DrawString("266.400", Font8, Brushes.Black, 725, 145 + (2 * 15), format1)
    '    e.Graphics.DrawString("266.400", Font8, Brushes.Black, 792, 145 + (2 * 15), format1)
    '    e.Graphics.DrawString("03", Font8, Brushes.Black, 0, 145 + (3 * 15))
    '    e.Graphics.DrawString("BATERIA", Font8, Brushes.Black, 75, 145 + (3 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (3 * 15))
    '    e.Graphics.DrawString("12", Font8, Brushes.Black, 520, 145 + (3 * 15), format1)
    '    e.Graphics.DrawString("62.300", Font8, Brushes.Black, 600, 145 + (3 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (3 * 15), format1)
    '    e.Graphics.DrawString("747.600", Font8, Brushes.Black, 725, 145 + (3 * 15), format1)
    '    e.Graphics.DrawString("747.600", Font8, Brushes.Black, 792, 145 + (3 * 15), format1)
    '    e.Graphics.DrawString("04", Font8, Brushes.Black, 0, 145 + (4 * 15))
    '    e.Graphics.DrawString("AMPOLLETA", Font8, Brushes.Black, 75, 145 + (4 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (4 * 15))
    '    e.Graphics.DrawString("44", Font8, Brushes.Black, 520, 145 + (4 * 15), format1)
    '    e.Graphics.DrawString("100", Font8, Brushes.Black, 600, 145 + (4 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (4 * 15), format1)
    '    e.Graphics.DrawString("4.400", Font8, Brushes.Black, 725, 145 + (4 * 15), format1)
    '    e.Graphics.DrawString("4.400", Font8, Brushes.Black, 792, 145 + (4 * 15), format1)
    '    e.Graphics.DrawString("05", Font8, Brushes.Black, 0, 145 + (5 * 15))
    '    e.Graphics.DrawString("FUNDA", Font8, Brushes.Black, 75, 145 + (5 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (5 * 15))
    '    e.Graphics.DrawString("12", Font8, Brushes.Black, 520, 145 + (5 * 15), format1)
    '    e.Graphics.DrawString("8.540", Font8, Brushes.Black, 600, 145 + (5 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (5 * 15), format1)
    '    e.Graphics.DrawString("136.640", Font8, Brushes.Black, 725, 145 + (5 * 15), format1)
    '    e.Graphics.DrawString("136.640", Font8, Brushes.Black, 792, 145 + (5 * 15), format1)
    '    e.Graphics.DrawString("06", Font8, Brushes.Black, 0, 145 + (6 * 15))
    '    e.Graphics.DrawString("PLUMILLA", Font8, Brushes.Black, 75, 145 + (6 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (6 * 15))
    '    e.Graphics.DrawString("22", Font8, Brushes.Black, 520, 145 + (6 * 15), format1)
    '    e.Graphics.DrawString("4.320", Font8, Brushes.Black, 600, 145 + (6 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (6 * 15), format1)
    '    e.Graphics.DrawString("95.040", Font8, Brushes.Black, 725, 145 + (6 * 15), format1)
    '    e.Graphics.DrawString("95.040", Font8, Brushes.Black, 792, 145 + (6 * 15), format1)
    '    e.Graphics.DrawString("07", Font8, Brushes.Black, 0, 145 + (7 * 15))
    '    e.Graphics.DrawString("GUANTE", Font8, Brushes.Black, 75, 145 + (7 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (7 * 15))
    '    e.Graphics.DrawString("34", Font8, Brushes.Black, 520, 145 + (7 * 15), format1)
    '    e.Graphics.DrawString("1.800", Font8, Brushes.Black, 600, 145 + (7 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (7 * 15), format1)
    '    e.Graphics.DrawString("61.200", Font8, Brushes.Black, 725, 145 + (7 * 15), format1)
    '    e.Graphics.DrawString("61.200", Font8, Brushes.Black, 792, 145 + (7 * 15), format1)
    '    e.Graphics.DrawString("08", Font8, Brushes.Black, 0, 145 + (8 * 15))
    '    e.Graphics.DrawString("BUJIA", Font8, Brushes.Black, 75, 145 + (8 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (8 * 15))
    '    e.Graphics.DrawString("16", Font8, Brushes.Black, 520, 145 + (8 * 15), format1)
    '    e.Graphics.DrawString("1.200", Font8, Brushes.Black, 600, 145 + (8 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (8 * 15), format1)
    '    e.Graphics.DrawString("19.200", Font8, Brushes.Black, 725, 145 + (8 * 15), format1)
    '    e.Graphics.DrawString("19.200", Font8, Brushes.Black, 792, 145 + (8 * 15), format1)
    '    e.Graphics.DrawString("09", Font8, Brushes.Black, 0, 145 + (9 * 15))
    '    e.Graphics.DrawString("AGUA REFRIGERANTE", Font8, Brushes.Black, 75, 145 + (9 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (9 * 15))
    '    e.Graphics.DrawString("40", Font8, Brushes.Black, 520, 145 + (9 * 15), format1)
    '    e.Graphics.DrawString("2.400", Font8, Brushes.Black, 600, 145 + (9 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (9 * 15), format1)
    '    e.Graphics.DrawString("96.000", Font8, Brushes.Black, 725, 145 + (9 * 15), format1)
    '    e.Graphics.DrawString("96.000", Font8, Brushes.Black, 792, 145 + (9 * 15), format1)
    '    e.Graphics.DrawString("10", Font8, Brushes.Black, 0, 145 + (10 * 15))
    '    e.Graphics.DrawString("PIEZAS ELECTRICAS", Font8, Brushes.Black, 75, 145 + (10 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (10 * 15))
    '    e.Graphics.DrawString("22", Font8, Brushes.Black, 520, 145 + (10 * 15), format1)
    '    e.Graphics.DrawString("540", Font8, Brushes.Black, 600, 145 + (10 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (10 * 15), format1)
    '    e.Graphics.DrawString("11.880", Font8, Brushes.Black, 725, 145 + (10 * 15), format1)
    '    e.Graphics.DrawString("11.880", Font8, Brushes.Black, 792, 145 + (10 * 15), format1)
    '    e.Graphics.DrawString("11", Font8, Brushes.Black, 0, 145 + (11 * 15))
    '    e.Graphics.DrawString("SISTEMA DE AUDIO", Font8, Brushes.Black, 75, 145 + (11 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (11 * 15))
    '    e.Graphics.DrawString("6", Font8, Brushes.Black, 520, 145 + (11 * 15), format1)
    '    e.Graphics.DrawString("35.000", Font8, Brushes.Black, 600, 145 + (11 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (11 * 15), format1)
    '    e.Graphics.DrawString("210.000", Font8, Brushes.Black, 725, 145 + (11 * 15), format1)
    '    e.Graphics.DrawString("210.000", Font8, Brushes.Black, 792, 145 + (11 * 15), format1)
    '    e.Graphics.DrawString("12", Font8, Brushes.Black, 0, 145 + (12 * 15))
    '    e.Graphics.DrawString("SET DE SEGURIDAD", Font8, Brushes.Black, 75, 145 + (12 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (12 * 15))
    '    e.Graphics.DrawString("10", Font8, Brushes.Black, 520, 145 + (12 * 15), format1)
    '    e.Graphics.DrawString("7.500", Font8, Brushes.Black, 600, 145 + (12 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (12 * 15), format1)
    '    e.Graphics.DrawString("75.000", Font8, Brushes.Black, 725, 145 + (12 * 15), format1)
    '    e.Graphics.DrawString("75.000", Font8, Brushes.Black, 792, 145 + (12 * 15), format1)
    '    e.Graphics.DrawString("13", Font8, Brushes.Black, 0, 145 + (13 * 15))
    '    e.Graphics.DrawString("ACCESORIO AUTOMOVIL", Font8, Brushes.Black, 75, 145 + (13 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (13 * 15))
    '    e.Graphics.DrawString("12", Font8, Brushes.Black, 520, 145 + (13 * 15), format1)
    '    e.Graphics.DrawString("3.520", Font8, Brushes.Black, 600, 145 + (13 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (13 * 15), format1)
    '    e.Graphics.DrawString("42.240", Font8, Brushes.Black, 725, 145 + (13 * 15), format1)
    '    e.Graphics.DrawString("42.240", Font8, Brushes.Black, 792, 145 + (13 * 15), format1)
    '    e.Graphics.DrawString("14", Font8, Brushes.Black, 0, 145 + (14 * 15))
    '    e.Graphics.DrawString("HERRAMIENTA LLAVE", Font8, Brushes.Black, 75, 145 + (14 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (14 * 15))
    '    e.Graphics.DrawString("14", Font8, Brushes.Black, 520, 145 + (14 * 15), format1)
    '    e.Graphics.DrawString("4.850", Font8, Brushes.Black, 600, 145 + (14 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (14 * 15), format1)
    '    e.Graphics.DrawString("67.900", Font8, Brushes.Black, 725, 145 + (14 * 15), format1)
    '    e.Graphics.DrawString("67.900", Font8, Brushes.Black, 792, 145 + (14 * 15), format1)
    '    e.Graphics.DrawString("15", Font8, Brushes.Black, 0, 145 + (15 * 15))
    '    e.Graphics.DrawString("EMBELLECEDOR AUTOMOVIL", Font8, Brushes.Black, 75, 145 + (15 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (15 * 15))
    '    e.Graphics.DrawString("20", Font8, Brushes.Black, 520, 145 + (15 * 15), format1)
    '    e.Graphics.DrawString("1.950", Font8, Brushes.Black, 600, 145 + (15 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (15 * 15), format1)
    '    e.Graphics.DrawString("39.000", Font8, Brushes.Black, 725, 145 + (15 * 15), format1)
    '    e.Graphics.DrawString("39.000", Font8, Brushes.Black, 792, 145 + (15 * 15), format1)
    '    e.Graphics.DrawString("16", Font8, Brushes.Black, 0, 145 + (16 * 15))
    '    e.Graphics.DrawString("ADHESIVO", Font8, Brushes.Black, 75, 145 + (16 * 15))
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 335, 145 + (16 * 15))
    '    e.Graphics.DrawString("26", Font8, Brushes.Black, 520, 145 + (16 * 15), format1)
    '    e.Graphics.DrawString("4.500", Font8, Brushes.Black, 600, 145 + (16 * 15), format1)
    '    e.Graphics.DrawString("0", Font8, Brushes.Black, 640, 145 + (16 * 15), format1)
    '    e.Graphics.DrawString("117.000", Font8, Brushes.Black, 725, 145 + (16 * 15), format1)
    '    e.Graphics.DrawString("117.000", Font8, Brushes.Black, 792, 145 + (16 * 15), format1)
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 55, 540)
    '    e.Graphics.DrawString("", Font8, Brushes.Black, 265, 540)
    '    e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 510, 540)
    '    e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 797, 540, format1)
    'End Sub

    Sub crear_numero_guia()
        Dim varnumdoc As Integer

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from guia where tipo_impresion <> 'DIGITADA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_guia.Text = 1
            Exit Sub
        End Try
        conexion.Close()

        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select n_guia from guia where cod_auto='" & (varnumdoc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_guia")
                txt_nro_guia.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_guia.Text = 1
        End Try
        conexion.Close()
    End Sub

    Sub imprimir()
    End Sub

    Private Sub Combo_vendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_vendedor.KeyPress
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
            Combo_sucursal.Focus()
        End If
    End Sub

    Private Sub grilla_sale_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_sale.DoubleClick
        If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then

            Dim valormensaje As Integer
            valormensaje = MsgBox("¿DESEA REENVIAR ESTE ITEM?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            If valormensaje = vbYes Then

                lbl_mensaje.Visible = True
                Me.Enabled = False

                txt_nro_vale.Text = grilla_sale.CurrentRow.Cells(9).Value()
                Combo_vendedor.Text = grilla_sale.CurrentRow.Cells(7).Value()
                Combo_sucursal.Text = grilla_sale.CurrentRow.Cells(10).Value()
                txt_codigo.Text = grilla_sale.CurrentRow.Cells(0).Value()

                mostrar_datos_productos()
                mostrar_nombre_proveedor()

                txt_cantidad.Text = grilla_sale.CurrentRow.Cells(4).Value()

                Dim nombre_servidor As String
                Dim nombre_servidor_remoto As String
                Dim base_de_datos As String
                Dim clave_base_de_datos As String
                Dim usuario As String
                Dim recinto As String
                Dim rut_empresa As String

                For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1

                    nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                    nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                    base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                    clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                    usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                    recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                    rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

                    recinto = Trim(Replace(recinto, "'", "´"))

                    If Combo_sucursal.Text = recinto Then
                        conexion.Close()
                        conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        Try

                            SC.Connection = conexion
                            SC.CommandText = "insert into vale_traslado_recibidos (n_vale, despachador, codigo_producto, cantidad, fecha, hora, estado, usuario_responsable, sucursal, nombre, aplicacion, nro_tecnico, marca, cod_barra, familia, subfamilia, subfamilia2, cantidad_minima, precio, tipo_precio, factor, costo, rut_proveedor, fecha_ult_compra, cant_ult_compra, tipo_doc, nro_doc) values(" & (txt_nro_vale.Text) & ", '" & (Combo_vendedor.Text) & "', '" & (txt_codigo.Text) & "','" & (txt_cantidad.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','EMITIDA','" & (miusuario) & "','" & (mirecintoempresa) & "', '" & (txt_nombre_producto.Text) & "', '" & (txt_aplicacion.Text) & "', '" & (txt_numero_tecnico.Text) & "', '" & (txt_marca.Text) & "', '" & (txt_codigo_barra.Text) & "', '" & (txt_codigo_familia.Text) & "', '" & (txt_codigo_subfamilia.Text) & "', '" & (txt_codigo_subfamilia_2.Text) & "', '" & (txt_cantidad_minima.Text) & "', '" & (txt_precio.Text) & "', '" & (txt_tipo_precio.Text) & "', '" & (txt_factor.Text) & "', '" & (txt_costo.Text) & "', '" & (txt_rut_proveedor.Text) & "', '" & (dtp_ultima_compra.Text) & "', '" & (txt_cantidad_ultima_compra.Text) & "', '" & (txt_tipo_doc.Text) & "', '" & (txt_nro_doc.Text) & "')"
                            DA.SelectCommand = SC
                            DA.Fill(DT)

                        Catch
                            recuperar_conexion()
                            limpiar()
                            lbl_mensaje.Visible = False
                            Me.Enabled = True
                            Exit Sub
                        End Try

                        recuperar_conexion()
                        limpiar()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        MsgBox("REENVIO REALIZADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        txt_codigo.Focus()

                        Exit Sub
                    End If
                Next

                recuperar_conexion()
                limpiar()

                lbl_mensaje.Visible = False
                Me.Enabled = True

                MsgBox("REENVIO REALIZADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo.Focus()
            End If
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        conexion.Close()
        Form_enviar_documento.Show()
        Form_cargar_compra_documento.txt_rut_proveedor.Focus()
        Me.Enabled = False
    End Sub

    Sub crear_conexion()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String

        For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1

            nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
            nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
            base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
            clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
            usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
            recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

            recinto = Trim(Replace(recinto, "'", "´"))

            If Combo_sucursal.Text = recinto Then

                If recinto = "EXEQUIEL GONZALEZ 226" Then
                    conexion.Close()
                    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    Exit Sub
                End If
                If recinto = "EXEQUIEL GONZALEZ 366" Then
                    conexion.Close()
                    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    Exit Sub
                End If

                conexion.Close()
                conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                Try

                    conexion.Open()
                    conexion.Close()

                    SC.Connection = conexion
                    SC.CommandText = "insert into vale_traslado_recibidos (n_vale, despachador, codigo_producto, cantidad, fecha, hora, estado, usuario_responsable, sucursal, nombre, aplicacion, nro_tecnico, marca, cod_barra, familia, subfamilia, subfamilia2, cantidad_minima, precio, tipo_precio, factor, costo, rut_proveedor, fecha_ult_compra, cant_ult_compra, tipo_doc, nro_doc) values(" & (txt_nro_vale.Text) & ", '" & (Combo_vendedor.Text) & "', '" & (txt_codigo.Text) & "','" & (txt_cantidad.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','EMITIDA','" & (miusuario) & "','" & (mirecintoempresa) & "', '" & (txt_nombre_producto.Text) & "', '" & (txt_aplicacion.Text) & "', '" & (txt_numero_tecnico.Text) & "', '" & (txt_marca.Text) & "', '" & (txt_codigo_barra.Text) & "', '" & (txt_codigo_familia.Text) & "', '" & (txt_codigo_subfamilia.Text) & "', '" & (txt_codigo_subfamilia_2.Text) & "', '" & (txt_cantidad_minima.Text) & "', '" & (txt_precio.Text) & "', '" & (txt_tipo_precio.Text) & "', '" & (txt_factor.Text) & "', '" & (txt_costo.Text) & "', '" & (txt_rut_proveedor.Text) & "', '" & (dtp_ultima_compra.Text) & "', '" & (txt_cantidad_ultima_compra.Text) & "', '" & (txt_tipo_doc.Text) & "', '" & (txt_nro_doc.Text) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                Catch

                End Try
                Exit Sub
            End If
        Next
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

    Private Sub grilla_entra_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_entra.CellContentClick

    End Sub

    Private Sub grilla_sale_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_sale.CellContentClick

    End Sub

    Private Sub grilla_entra_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_entra.DoubleClick

    End Sub

    Private Sub btn_estado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_estado.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        malla_estado()
        cambiar_estado()
        recuperar_conexion()
        mostrar_malla()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub


    Sub malla_estado()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select n_vale, codigo_producto, sucursal from `vale` where estado <> 'recibido' ORDER by sucursal, n_vale desc;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_estado.Rows.Clear()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_estado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_vale"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("codigo_producto"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("sucursal"))
            Next
        End If

        If grilla_estado.Rows.Count <> 0 Then
            If grilla_estado.Columns(0).Width = 150 Then
                grilla_estado.Columns(0).Width = 149
            Else
                grilla_estado.Columns(0).Width = 150
            End If
        End If


    End Sub




    Sub cambiar_estado()
        Dim n_vale As String
        Dim codigo_producto As String
        Dim sucursal As String
        Dim estado_vale As String

        For u = 0 To grilla_estado.Rows.Count - 1

            n_vale = grilla_estado.Rows(u).Cells(0).Value.ToString
            codigo_producto = grilla_estado.Rows(u).Cells(1).Value.ToString
            sucursal = grilla_estado.Rows(u).Cells(2).Value.ToString

            Dim nombre_servidor As String
            Dim nombre_servidor_remoto As String
            Dim base_de_datos As String
            Dim clave_base_de_datos As String
            Dim usuario As String
            Dim recinto As String
            Dim rut_empresa As String

            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1

                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

                recinto = Trim(Replace(recinto, "'", "´"))

                If sucursal = recinto Then

                    If recinto = "EXEQUIEL GONZALEZ 226" Then
                        conexion.Close()
                        conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        Exit Sub
                    End If
                    If recinto = "EXEQUIEL GONZALEZ 366" Then
                        conexion.Close()
                        conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        Exit Sub
                    End If

                    conexion.Close()
                    conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    Try

                        conexion.Open()
                        conexion.Close()

                        conexion.Close()
                        DS.Tables.Clear()
                        DT.Rows.Clear()
                        DT.Columns.Clear()
                        DS.Clear()
                        conexion.Open()

                        SC.Connection = conexion
                        SC.CommandText = "select * from `vale_traslado_recibidos` where n_vale='" & (n_vale) & "' and codigo_producto='" & (codigo_producto) & "'"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        DS.Tables.Add(DT)

                        If DS.Tables(DT.TableName).Rows.Count > 0 Then
                            estado_vale = DS.Tables(DT.TableName).Rows(0).Item("estado")


                            If estado_vale = "RECIBIDO" Then
                                recuperar_conexion()

                                SC.Connection = conexion
                                SC.CommandText = "UPDATE vale SET estado='RECIBIDO' WHERE N_VALE = " & (n_vale) & "  AND CODIGO_PRODUCTO = " & (codigo_producto) & ""
                                DA.SelectCommand = SC
                                DA.Fill(DT)

                            End If
                        End If
                        conexion.Close()


                    Catch mierror As MySqlException
                        Exit Sub
                    Catch mierror As MissingManifestResourceException
                        Exit Sub
                    End Try
                    Exit For
                End If
            Next

        Next
    End Sub

    Private Sub Combo_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_sucursal.SelectedIndexChanged

    End Sub

    Private Sub Combo_vendedor_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.HandleCreated

    End Sub


    Private Function ReturnDataSet() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        'dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("hora", GetType(String)))
        dt.Columns.Add(New DataColumn("encargado", GetType(String)))
        dt.Columns.Add(New DataColumn("despachador", GetType(String)))
        dt.Columns.Add(New DataColumn("origen", GetType(String)))
        dt.Columns.Add(New DataColumn("destino", GetType(String)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(String)))


        'Dim Varcodigo As String
        'Dim Vardescripcion As String
        'Dim Varcantidad As String

        'For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
        '    Varcodigo = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
        '    Vardescripcion = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
        '    Varcantidad = grilla_estado_de_cuenta.Rows(i).Cells(2).Value

        dr = dt.NewRow()

        'Try
        '    dr("Imagen") = Imagen_reporte
        'Catch
        'End Try

        dr("numero") = txt_nro_vale.Text
        dr("fecha") = Form_menu_principal.dtp_fecha.Text
        dr("hora") = Form_menu_principal.lbl_hora.Text
        dr("encargado") = minombre
        dr("despachador") = Combo_vendedor.Text
        dr("origen") = mirecintoempresa
        dr("destino") = Combo_sucursal.Text
        dr("codigo") = txt_codigo.Text
        dr("descripcion") = txt_nombre_producto.Text & " " & txt_numero_tecnico.Text
        dr("cantidad") = txt_cantidad.Text

        dt.Rows.Add(dr)
        ' Next

        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "ticket_traspaso_sucursal"
        Dim iDS As New DS_ticket_traspaso_sucursal
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS
    End Function

    Private Sub txt_precio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_precio.TextChanged

    End Sub


    Sub crear_archivo_plano()
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        'Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String


        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer

        Dim neto As Integer
        Dim iva As Integer
        Dim subtotal As Integer
        Dim TOTAL As Integer

        neto = "1696050"
        iva = "322250"
        subtotal = "2018300"
        TOTAL = "2018300"




        Dim nro_linea As String

        Dim nombre_cliente As String
        nombre_cliente = txt_nombre_cliente.Text
        If nombre_cliente.Length > 40 Then
            nombre_cliente = nombre_cliente.Substring(0, 40)
        End If

        Dim giro_cliente As String
        giro_cliente = txt_giro_cliente.Text
        If giro_cliente.Length > 40 Then
            giro_cliente = giro_cliente.Substring(0, 40)
        End If

        Dim direccion_cliente As String
        direccion_cliente = txt_direccion_cliente.Text
        If direccion_cliente.Length > 59 Then
            direccion_cliente = direccion_cliente.Substring(0, 60)
        End If

        Dim comuna_cliente As String
        comuna_cliente = txt_comuna_cliente.Text
        If comuna_cliente.Length > 19 Then
            comuna_cliente = comuna_cliente.Substring(0, 20)
        End If

        Dim ciudad_cliente As String
        ciudad_cliente = txt_comuna_cliente.Text
        If ciudad_cliente.Length > 19 Then
            ciudad_cliente = ciudad_cliente.Substring(0, 20)
        End If

        Dim correo_cliente As String
        correo_cliente = txt_correo_cliente.Text
        If correo_cliente.Length > 199 Then
            correo_cliente = correo_cliente.Substring(0, 200)
        End If

        txt_telefono.Text = Trim(dejarNumerosPuntos(txt_telefono.Text))

        Dim telefono_cliente As String
        telefono_cliente = txt_telefono.Text
        If telefono_cliente.Length > 8 Then
            telefono_cliente = telefono_cliente.Substring(0, 8)
        End If

        If correo_cliente = "-" Then
            correo_cliente = ""
        End If

        'If txt_folio.Text = "-" Then
        '    txt_folio.Text = ""
        'End If

        Dim condicion As String

        condicion = "TRASLADO"

        'correcto sin modificaciones

        'Dim IndTraslado As Integer
        'If condicion = "TRASLADO" Then
        '    IndTraslado = 0
        'Else


        'End If


        Try
            If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(ruta_archivos_planos)
            End If

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            PathArchivo = ruta_archivos_planos & "\" & "Guia " & (txt_nro_guia.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo

            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

            'escribimos en el archivo
            strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
            & "52" & ";" & (txt_nro_guia.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & "1" & ";" & "5" & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (minombre) & ";" & (miusuario) & ";" & (minombre) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
            & "->Totales<-" & vbNewLine _
            & (0) & ";" & "0" & ";" & "0" & ";" & "0" & ";" & (txt_neto.Text) & ";" & "0" & ";" & (valor_iva) & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";1;" & vbNewLine _
            & "->Detalle<-")

            nro_linea = 0

            For i = 0 To grilla_detalle_venta.Rows.Count - 1
                nro_linea = nro_linea + 1
                VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                If VarCodProducto.Length > 34 Then
                    VarCodProducto = VarCodProducto.Substring(0, 35)
                End If

                If varnombre.Length > 79 Then
                    varnombre = varnombre.Substring(0, 80)
                End If

                varnombre = varnombre & " " & vartecnico

                If varnombre.Length > 52 Then
                    varnombre = varnombre.Substring(0, 52)
                End If

                VarCantidad = Replace(VarCantidad, ",", ".")
                VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & (VarPorcentaje) & ";" & (VarDescuento) & ";" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotal) & ";" & "INT11" & ";" & "UN" & ";" & ";")
            Next

            'If txt_nro_orden_de_compra.Text = "0" Then
            '    txt_nro_orden_de_compra.Text = ""
            'End If

            strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
            & "1" & ";" & "801" & ";"";;" & "0" & ";" & "-" & ";" & vbNewLine _
            & "->DescRec<-" & vbNewLine _
            & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & "0" & ";" & "0" & ";" & vbNewLine _
            & "->Observacion<-" & vbNewLine _
            & "" & ";" & condicion & ", " & mirecintoempresa & ";")
            strStreamWriter.Close() ' cerramos

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try

    End Sub

    Sub llenar_malla_imprimir()

        txt_nombre_cliente.Text = "RAFAEL ARANA Y CIA."
        txt_direccion_cliente.Text = "O'HIGGINS 452"
        txt_giro_cliente.Text = "REPUESTOS AUTOMOTRICES"
        txt_correo_cliente.Text = "CONTACTO@REPUESTOSARANA.CL"
        txt_rut_cliente.Text = "87686300-6"
        txt_comuna_cliente.Text = "SAN FERNANDO"
        txt_telefono.Text = "714173"

        grilla_detalle_venta.Rows.Clear()

        Dim iva As Long
        Dim neto As Long
        Dim total As Long
        Dim desc As String
        Dim porcentaje_desc As String
        Dim subtotal As Long
        Dim iva_valor As String

        txt_codigo.Text = "01"
        txt_nombre_producto.Text = "FILTRO"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "12"
        txt_precio_modificado.Text = "2400"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "02"
        txt_nombre_producto.Text = "ACEITE LUBRICANTE"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "12"
        txt_precio_modificado.Text = "14800"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "03"
        txt_nombre_producto.Text = "BATERIA"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "12"
        txt_precio_modificado.Text = "62300"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "04"
        txt_nombre_producto.Text = "AMPOLLETA"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "44"
        txt_precio_modificado.Text = "100"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "05"
        txt_nombre_producto.Text = "FUNDA"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "12"
        txt_precio_modificado.Text = "8540"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "06"
        txt_nombre_producto.Text = "PLUMILLA"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "22"
        txt_precio_modificado.Text = "4320"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "07"
        txt_nombre_producto.Text = "GUANTE"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "34"
        txt_precio_modificado.Text = "1800"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "08"
        txt_nombre_producto.Text = "BUJIA"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "16"
        txt_precio_modificado.Text = "1200"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "09"
        txt_nombre_producto.Text = "AGUA REFRIGERANTE"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "40"
        txt_precio_modificado.Text = "2400"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "10"
        txt_nombre_producto.Text = "PIEZAS ELECTRICAS"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "22"
        txt_precio_modificado.Text = "540"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "11"
        txt_nombre_producto.Text = "SISTEMA DE AUDIO"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "6"
        txt_precio_modificado.Text = "35000"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "12"
        txt_nombre_producto.Text = "SET DE SEGURIDAD"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "10"
        txt_precio_modificado.Text = "7500"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "13"
        txt_nombre_producto.Text = "ACCESORIO AUTOMOVIL"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "12"
        txt_precio_modificado.Text = "3520"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "14"
        txt_nombre_producto.Text = "HERRAMIENTA LLAVE"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "14"
        txt_precio_modificado.Text = "4850"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)


        txt_codigo.Text = "15"
        txt_nombre_producto.Text = "EMBELLECEDOR AUTOMOVIL"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "20"
        txt_precio_modificado.Text = "1950"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)

        txt_codigo.Text = "16"
        txt_nombre_producto.Text = "ADHESIVO"
        txt_numero_tecnico.Text = ""
        txt_cantidad_agregar.Text = "26"
        txt_precio_modificado.Text = "4500"
        porcentaje_desc = "0"
        desc = "0"
        subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
        iva_valor = valor_iva / 100 + 1
        neto = (subtotal / iva_valor)
        iva = (neto) * valor_iva / 100
        total = subtotal - desc

        grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio_modificado.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)
        txt_codigo.Text = ""
        txt_nombre_producto.Text = ""
    End Sub

    Sub calcular_totales()
        Dim descgrilla As Long
        Dim netogrilla As Long
        Dim ivagrilla As Long
        Dim totalgrilla As Long
        Dim subtotalgrilla As Long

        'Calcular el descuento
        txt_desc_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            descgrilla = Val(grilla_detalle_venta.Rows(i).Cells(9).Value.ToString)
            txt_desc_total.Text = Val(txt_desc_total.Text) + Val(descgrilla)
        Next

        'Calcular el total neto
        txt_neto.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            netogrilla = Val(grilla_detalle_venta.Rows(i).Cells(5).Value.ToString)
            txt_neto.Text = Val(txt_neto.Text) + Val(netogrilla)
        Next

        'Calcular el total iva
        txt_iva.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            ivagrilla = Val(grilla_detalle_venta.Rows(i).Cells(6).Value.ToString)
            txt_iva.Text = Val(txt_iva.Text) + Val(ivagrilla)
        Next

        'Calcular el sub-total
        txt_sub_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            subtotalgrilla = Val(grilla_detalle_venta.Rows(i).Cells(10).Value.ToString)
            txt_sub_total.Text = Val(txt_sub_total.Text) + Val(subtotalgrilla)
        Next

        'Calcular el total general
        txt_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            totalgrilla = Val(grilla_detalle_venta.Rows(i).Cells(10).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        'Dim iva As Integer
        'Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        txt_neto.Text = Round(txt_total.Text / iva_valor)
        txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)
        txt_iva.Text = (txt_total.Text) - (txt_neto.Text)
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)


        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), -74, 0, 440, 70)
        Catch
        End Try

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim stringFormat_left As New StringFormat()
        stringFormat_left.Alignment = StringAlignment.Near
        stringFormat_left.LineAlignment = StringAlignment.Near

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 270, margen_superior + 15)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 270, margen_superior + 15)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 270, margen_superior + 15)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 270, margen_superior + 15)
        Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 270, margen_superior + 15)
        Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 270, margen_superior + 15)
        Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 270, margen_superior + 15)
        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 270, margen_superior + 15)

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("TRASPASO A SUCURSAL", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NUMERO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 245)
        e.Graphics.DrawString(txt_nro_vale.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 260)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 260)

        e.Graphics.DrawString("HORA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 275)
        e.Graphics.DrawString(Form_menu_principal.lbl_hora.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 275)

        e.Graphics.DrawString("ENCARGADO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 290)
        e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 290)

        e.Graphics.DrawString("DESPACHADOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 305)
        e.Graphics.DrawString(Combo_vendedor.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 305)

        e.Graphics.DrawString("ORIGEN", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 320)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 320)
        e.Graphics.DrawString(mirecintoempresa, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 320)

        e.Graphics.DrawString("DESTINO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 335)
        e.Graphics.DrawString(Combo_sucursal.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 335)

        e.Graphics.DrawString("CODIGO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 365)
        e.Graphics.DrawString("DESCRIPCION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 365)
        e.Graphics.DrawString("CANTIDAD", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 280, margen_superior + 365, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 380, margen_izquierdo + 295, margen_superior + 380)

        e.Graphics.DrawString(txt_codigo.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 385)

        Dim rect_descripcion_producto As New Rectangle(margen_izquierdo + 75, margen_superior + 385, margen_izquierdo + 200, margen_superior + 60)
        e.Graphics.DrawString(txt_nombre_producto.Text, Font_texto_titulo_detalle, Brushes.Black, rect_descripcion_producto, stringFormat_left)

        e.Graphics.DrawString(txt_cantidad.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 280, margen_superior + 415, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 500, margen_izquierdo + 295, margen_superior + 500)
        Dim rect_firma As New Rectangle(margen_izquierdo + 10, margen_superior + 510, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("FIRMA RESPONSABLE", Font_texto_titulo_detalle, Brushes.Black, rect_firma, stringFormat)

        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + 550, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub
End Class