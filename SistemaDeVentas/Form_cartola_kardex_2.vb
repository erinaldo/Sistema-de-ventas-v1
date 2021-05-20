Imports System.IO
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient
Imports System.Resources
Imports System.Drawing.Printing

Public Class Form_cartola_kardex_2
    Dim total_registros As Integer
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim numero_lineas_total As Integer = 0
    'Dim impreso As Integer = 0

    Private Sub Form_cartola_kardex_2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_cartola_kardex_2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F1 Then
            txt_codigo_producto.Focus()
        End If

        If e.KeyCode = Keys.F4 Then
            btn_buscar.PerformClick()
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
            mostrar_cierre_sistema()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_cartola_kardex_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        limpiar_producto()

        revizar_usuario_vacio()

        dtp_desde.Value = dtp_desde.Value.AddYears(Val(-1))
        llenar_combo_sucursales()
        txt_codigo_producto.Focus()
        Me.Width = 1024
        Me.Height = 728
        Centrar()
    End Sub

    Public Sub Centrar()
        ' Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (My.Computer.Screen.Bounds.Width - Me.Width) \ 2
        Dim posicionY As Integer = (My.Computer.Screen.Bounds.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha2 se le entrega el formato de fecha indicado.
    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha4 se le entrega el formato de fecha indicado.
    Sub fecha2()
        Dim mifecha1 As Date
        mifecha1 = dtp_hasta.Text
        mifecha4 = mifecha1.ToString("yyy-MM-dd")
    End Sub

    Sub revizar_usuario_vacio()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from usuarios where rut_usuario =''"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        Else
            SC.Connection = conexion
            SC.CommandText = " INSERT INTO usuarios (`rut_usuario`, `nombre_usuario`, `usuario`, `clave`, `tipo_usuario`, `pregunta_usuario`, `respuesta_usuario`, `area_usuario`, `telefono_usuario`, `autoriza_venta`, `tiempo_espera`, `fecha_modificacion`, `clave_autoriza`) VALUES ('', '-', '-', '-', 'USUARIO DEL SISTEMA', '-', '-', '-', '-', 'no', '0', '0000-00-00', '-');"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If
    End Sub
    ''actualizamos la tabla productos.
    'Sub actualizar_tabla_productos()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from productos"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    conexion.Close()
    'End Sub

    'Sub llenar_combo_codigo()
    '    actualizar_tabla_productos()

    '    total_registros = DS.Tables(DT.TableName).Rows.Count()
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To total_registros - 1
    '            combo_codigo.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    'sub para mostrar los datos de los productos.
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
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("PROVEEDOR")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                'txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
            End If
            conexion.Close()




            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from PROVEEDORES where rut_proveedor ='" & (txt_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            End If
            conexion.Close()
        End If




        If txt_precio.Text = "" Or txt_precio.Text = "0" Then
            txt_precio.Text = "0"
        Else
            txt_precio.Text = Format(Int(txt_precio.Text), "###,###,###")
        End If


        If txt_cantidad.Text = "" Or txt_cantidad.Text = "0" Then
            txt_cantidad.Text = "0"
        Else
            txt_cantidad.Text = Format(Int(txt_cantidad.Text), "###,###,###")
        End If

    End Sub

    'Sub mostrar_productos(ByVal i As Integer)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        combo_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
    '        txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    '        txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
    '        txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
    '        txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
    '        txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
    '        txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
    '    End If
    'End Sub

    Sub mostrar_malla()

        fecha()
        fecha2()

        grilla_kardex.Rows.Clear()
        grilla_kardex.Columns.Clear()
        grilla_kardex.Columns.Add("", "CODIGO")
        grilla_kardex.Columns.Add("", "NOMBRE")
        grilla_kardex.Columns.Add("", "MOVIMIENTO")
        grilla_kardex.Columns.Add("", "USUARIO")
        grilla_kardex.Columns.Add("", "TIPO")
        grilla_kardex.Columns.Add("", "CONDICION")
        grilla_kardex.Columns.Add("", "NUMERO")
        grilla_kardex.Columns.Add("", "FECHA")
        grilla_kardex.Columns.Add("", "CANTIDAD")
        grilla_kardex.Columns.Add("", "PRECIO")



        ''COMPRAS
        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'If Check_movimientos.Checked = False Then
        '    SC.Connection = conexion
        '    SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_compra.n_compra as NUMERO, fecha_emision as FECHA, cantidad as CANTIDAD, precio_venta as PRECIO from detalle_compra, compra, usuarios where compra.n_compra=detalle_compra.n_compra and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_compra.cod_producto= '" & (txt_codigo_producto.Text) & "' and fecha_emision >='" & (mifecha2) & "' and fecha_emision <= '" & (mifecha4) & "' AND compra.usuario_responsable= usuarios.rut_usuario order by fecha_emision desc"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Else
        '    SC.Connection = conexion
        '    SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_compra.n_compra as NUMERO, fecha_emision as FECHA, cantidad as CANTIDAD, precio_venta as PRECIO from detalle_compra, compra, usuarios where compra.n_compra=detalle_compra.n_compra and estado <> 'ANULADA' and estado <> 'ANULADO' and fecha_emision >='" & (mifecha2) & "' and fecha_emision <= '" & (mifecha4) & "' AND compra.usuario_responsable= usuarios.rut_usuario order by fecha_emision desc"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'End If

        'DS.Tables.Add(DT)
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '        Dim MiFechaKardex As Date
        '        Dim MiFechaKardex2 As String
        '        MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
        '        MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy")
        '        Dim DT_Fecha As Date
        '        DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
        '        CDate(DS.Tables(DT.TableName).Rows(i).Item("FECHA")).ToString("dd/MM/yyyy")
        '        grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
        '                                DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
        '                                 "ENTRA", _
        '                                  DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
        '                                   DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
        '                                   "-", _
        '                                    DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
        '                                     CDate(MiFechaKardex2), _
        '                                      DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
        '                                       DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
        '    Next
        'End If

        'BOLETAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_boleta.n_boleta as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_boleta, boleta, usuarios where boleta.n_boleta=detalle_boleta.n_boleta and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_boleta.cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND boleta.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_boleta.n_boleta as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_boleta, boleta, usuarios where boleta.n_boleta=detalle_boleta.n_boleta and estado <> 'ANULADA' and estado <> 'ANULADO' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND boleta.usuario_responsable= usuarios.rut_usuario order by fecha_venta desc"
            'SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_compra.n_compra as NUMERO, fecha_emision as FECHA, cantidad as CANTIDAD, precio_venta as PRECIO from detalle_compra, compra, usuarios where compra.n_compra=detalle_compra.n_compra and estado <> 'ANULADA' and estado <> 'ANULADO' and fecha_emision >='" & (mifecha2) & "' and fecha_emision <= '" & (mifecha4) & "' AND compra.usuario_responsable= usuarios.rut_usuario order by fecha_emision desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = " " & DS.Tables(DT.TableName).Rows(i).Item("HORA")
                'If MiHora.Length = 7 Then
                '    MiHora = "0" & MiHora
                'End If
                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA") & MiHora



                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If

                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                         "SALE", _
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("CONDICIONES"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                              CDate(MiFechaKardex2), _
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
                'grilla_kardex.Rows(i).Cells(6).Value = grilla_kardex.Rows(i).Cells(6).Value.Substring(0, 10)

            Next
        End If

        'FACTURAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_factura.n_factura as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_factura, factura, usuarios where factura.usuario_responsable <> 'SISTEMA' and factura.n_factura=detalle_factura.n_factura and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_factura.cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND factura.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_factura.n_factura as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_factura, factura, usuarios where factura.usuario_responsable <> 'SISTEMA' and factura.n_factura=detalle_factura.n_factura and estado <> 'ANULADA' and estado <> 'ANULADO' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND factura.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = " " & DS.Tables(DT.TableName).Rows(i).Item("HORA")
                'If MiHora.Length = 7 Then
                '    MiHora = "0" & MiHora
                'End If
                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA") & MiHora


                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                         "SALE", _
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("CONDICIONES"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                              CDate(MiFechaKardex2), _
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))

                'grilla_kardex.Rows(i).Cells(6).Value = grilla_kardex.Rows(i).Cells(6).Value.Substring(0, 10)

            Next
        End If

        'GUIAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_guia.n_guia as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_guia, guia, usuarios where guia.n_guia=detalle_guia.n_guia and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_guia.cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND guia.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_guia.n_guia as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_guia, guia, usuarios where guia.n_guia=detalle_guia.n_guia and estado <> 'ANULADA' and estado <> 'ANULADO' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND guia.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = " " & DS.Tables(DT.TableName).Rows(i).Item("HORA")
                'If MiHora.Length = 7 Then
                '    MiHora = "0" & MiHora
                'End If
                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA") & MiHora


                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                         "SALE", _
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("CONDICIONES"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                              CDate(MiFechaKardex2), _
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
                'grilla_kardex.Rows(i).Cells(6).Value = grilla_kardex.Rows(i).Cells(6).Value.Substring(0, 10)
            Next
        End If

        'NOTAS DE CREDITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_nota_credito.n_nota_credito as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_nota_credito, nota_credito, usuarios where nota_credito.n_nota_credito=detalle_nota_credito.n_nota_credito and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_nota_credito.cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND nota_credito.vendedor=usuarios.rut_usuario order by fecha_venta desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_nota_credito.n_nota_credito as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_nota_credito, nota_credito, usuarios where nota_credito.n_nota_credito=detalle_nota_credito.n_nota_credito and estado <> 'ANULADA' and estado <> 'ANULADO' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND nota_credito.vendedor=usuarios.rut_usuario order by fecha_venta desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = " " & DS.Tables(DT.TableName).Rows(i).Item("HORA")
                'If MiHora.Length = 7 Then
                '    MiHora = "0" & MiHora
                'End If
                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA") & MiHora


                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                         "ENTRA", _
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("CONDICIONES"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                              CDate(MiFechaKardex2), _
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
                'grilla_kardex.Rows(i).Cells(6).Value = grilla_kardex.Rows(i).Cells(6).Value.Substring(0, 10)
            Next
        End If


        'NOTAS DE DEBITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_nota_debito.n_nota_debito as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_nota_debito, nota_debito, usuarios where nota_debito.n_nota_debito=detalle_nota_debito.n_nota_debito and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_nota_debito.cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND nota_debito.vendedor=usuarios.rut_usuario order by fecha_venta desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_nota_debito.n_nota_debito as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_nota_debito, nota_debito, usuarios where nota_debito.n_nota_debito=detalle_nota_debito.n_nota_debito and estado <> 'ANULADA' and estado <> 'ANULADO' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND nota_debito.vendedor=usuarios.rut_usuario order by fecha_venta desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = " " & DS.Tables(DT.TableName).Rows(i).Item("HORA")
                'If MiHora.Length = 7 Then
                '    MiHora = "0" & MiHora
                'End If
                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA") & MiHora


                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"),
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"),
                                         "ENTRA",
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                            DS.Tables(DT.TableName).Rows(i).Item("CONDICIONES"),
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"),
                                                DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
                'grilla_kardex.Rows(i).Cells(6).Value = grilla_kardex.Rows(i).Cells(6).Value.Substring(0, 10)
            Next
        End If



        'VALES
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            SC.CommandText = "select codigo_producto as 'CODIGO', nombre_producto as 'NOMBRE', nombre_usuario as 'USUARIO', vale.n_vale as NUMERO, fecha as FECHA, cantidad as CANTIDAD, valor_unitario as PRECIO, HORA AS HORA from vale, usuarios where estado <> 'ANULADA' and estado <> 'ANULADO' and vale.codigo_producto= '" & (txt_codigo_producto.Text) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND vale.usuario_responsable=usuarios.rut_usuario order by fecha desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "select codigo_producto as 'CODIGO', nombre_producto as 'NOMBRE', nombre_usuario as 'USUARIO', vale.n_vale as NUMERO, fecha as FECHA, cantidad as CANTIDAD, valor_unitario as PRECIO, HORA AS HORA from vale, usuarios where estado <> 'ANULADA' and estado <> 'ANULADO' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND vale.usuario_responsable=usuarios.rut_usuario order by fecha desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                Try
                    MiHora = DS.Tables(DT.TableName).Rows(i).Item("HORA")
                Catch
                    MiHora = "00:00:00"
                End Try

                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA")


                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                         "SALE", _
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                           "VALE", _
                                            "TRASLADO", _
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                              CDate(MiFechaKardex2), _
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
                'grilla_kardex.Rows(i).Cells(6).Value = grilla_kardex.Rows(i).Cells(6).Value.Substring(0, 10)
            Next
        End If

        'VALE DE CAMBIO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_vale_cambio.nro_vale as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_vale_cambio, vale_cambio, usuarios where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_vale_cambio.cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND vale_cambio.usuario_responsable=usuarios.rut_usuario order by fecha desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_vale_cambio.nro_vale as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_vale_cambio, vale_cambio, usuarios where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale and estado <> 'ANULADA' and estado <> 'ANULADO' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND vale_cambio.usuario_responsable=usuarios.rut_usuario order by fecha desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                Try
                    MiHora = DS.Tables(DT.TableName).Rows(i).Item("HORA")
                Catch
                    MiHora = "00:00:00"
                End Try

                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA")


                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                         DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"), _
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            "-", _
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                              CDate(MiFechaKardex2), _
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
                'grilla_kardex.Rows(i).Cells(6).Value = grilla_kardex.Rows(i).Cells(6).Value.Substring(0, 10)
            Next
        End If


        'VALES DE TRASLADO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            'SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_factura.n_factura as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO from detalle_factura, factura, usuarios where factura.n_factura=detalle_factura.n_factura and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_factura.cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND factura.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, envios_recibidos.n_documento as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from envios_recibidos, usuarios where envios_recibidos.vendedor=usuarios.rut_usuario and estado <> 'ANULADA' and estado <> 'ANULADO' and cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP BY cod_detalle order by fecha desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            'SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_total.n_factura as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO from detalle_factura, factura, usuarios where factura.n_factura=detalle_factura.n_factura and estado <> 'ANULADA' and estado <> 'ANULADO' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND factura.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, envios_recibidos.n_documento as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from envios_recibidos, usuarios where envios_recibidos.vendedor=usuarios.rut_usuario and estado <> 'ANULADA' and estado <> 'ANULADO' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP BY cod_detalle order by fecha desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = DS.Tables(DT.TableName).Rows(i).Item("HORA")
                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA")


                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                         "ENTRA", _
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            "TRASLADO", _
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                              CDate(MiFechaKardex2), _
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
                'grilla_kardex.Rows(i).Cells(6).Value = grilla_kardex.Rows(i).Cells(6).Value.Substring(0, 10)
            Next
        End If


        'CONSUMO INTERNO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            'SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_factura.n_factura as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO from detalle_factura, factura, usuarios where factura.n_factura=detalle_factura.n_factura and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_factura.cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND factura.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_consumo_interno.n_documento as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_consumo_interno, usuarios where detalle_consumo_interno.vendedor=usuarios.rut_usuario and estado <> 'ANULADA' and estado <> 'ANULADO' and cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP BY cod_detalle order by fecha desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            'SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_total.n_factura as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO from detalle_factura, factura, usuarios where factura.n_factura=detalle_factura.n_factura and estado <> 'ANULADA' and estado <> 'ANULADO' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND factura.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_consumo_interno.n_documento as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_consumo_interno, usuarios where detalle_consumo_interno.vendedor=usuarios.rut_usuario and estado <> 'ANULADA' and estado <> 'ANULADO' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP BY cod_detalle order by fecha desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = DS.Tables(DT.TableName).Rows(i).Item("HORA")
                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora


                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                'grilla_kardex.Rows(0)("FECHA").Value = String.Format("{0:dd/MM/yyyy}", DT_Fecha)

                CDate(DS.Tables(DT.TableName).Rows(i).Item("FECHA")).ToString("dd-MM-yyyy")


                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                         DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"), _
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            "-", _
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                              CDate(MiFechaKardex2), _
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
                'grilla_kardex.Rows(i).Cells(6).Value = grilla_kardex.Rows(i).Cells(6).Value.Substring(0, 10)
            Next
        End If

        'AJUSTES DE STOCK
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            'SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_factura.n_factura as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO from detalle_factura, factura, usuarios where factura.n_factura=detalle_factura.n_factura and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_factura.cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND factura.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, ajustes_de_stock.n_ajuste as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from ajustes_de_stock, usuarios where ajustes_de_stock.vendedor=usuarios.rut_usuario and estado <> 'ANULADA' and estado <> 'ANULADO' and cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP BY cod_detalle order by fecha desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            'SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_total.n_factura as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO from detalle_factura, factura, usuarios where factura.n_factura=detalle_factura.n_factura and estado <> 'ANULADA' and estado <> 'ANULADO' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND factura.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
            SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, ajustes_de_stock.n_ajuste as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from ajustes_de_stock, usuarios where ajustes_de_stock.vendedor=usuarios.rut_usuario and estado <> 'ANULADA' and estado <> 'ANULADO' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP BY cod_detalle order by fecha desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = DS.Tables(DT.TableName).Rows(i).Item("HORA")
                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora


                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                'grilla_kardex.Rows(0)("FECHA").Value = String.Format("{0:dd/MM/yyyy}", DT_Fecha)

                CDate(DS.Tables(DT.TableName).Rows(i).Item("FECHA")).ToString("dd-MM-yyyy")


                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                         DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"), _
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            "-", _
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                              CDate(MiFechaKardex2), _
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
                'grilla_kardex.Rows(i).Cells(6).Value = grilla_kardex.Rows(i).Cells(6).Value.Substring(0, 10)
            Next
        End If


        'COMPRAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        If Check_movimientos.Checked = False Then
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', compra.TIPO as TIPO, detalle_compra.n_compra as NUMERO, fecha_emision as FECHA, cantidad as CANTIDAD, valor_unitario as PRECIO, HORA AS HORA from detalle_compra, compra, usuarios where compra.n_compra=detalle_compra.n_compra and compra.rut_proveedor=detalle_compra.rut_proveedor and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_compra.cod_producto= '" & (txt_codigo_producto.Text) & "' and fecha_emision >='" & (mifecha2) & "' and fecha_emision <= '" & (mifecha4) & "' AND compra.usuario_responsable= usuarios.rut_usuario group by detalle_compra.cod_auto order by fecha_emision desc "
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', compra.TIPO as TIPO, detalle_compra.n_compra as NUMERO, fecha_emision as FECHA, cantidad as CANTIDAD, valor_unitario as PRECIO, HORA AS HORA from detalle_compra, compra, usuarios where compra.n_compra=detalle_compra.n_compra and compra.rut_proveedor=detalle_compra.rut_proveedor and  estado <> 'ANULADA' and estado <> 'ANULADO' and fecha_emision >='" & (mifecha2) & "' and fecha_emision <= '" & (mifecha4) & "' AND compra.usuario_responsable= usuarios.rut_usuario group by detalle_compra.cod_auto order by fecha_emision desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = DS.Tables(DT.TableName).Rows(i).Item("HORA")
                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA")

                CDate(DS.Tables(DT.TableName).Rows(i).Item("FECHA")).ToString("dd/MM/yyyy")


                'If DS.Tables(DT.TableName).Rows(i).Item("NUMERO") = "449612" Then
                '    MsgBox("")
                'End If


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                         "ENTRA", _
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                           "-", _
                                            DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                             CDate(MiFechaKardex2), _
                                              DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
            Next
        End If
        grilla_kardex.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_kardex.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        grilla_kardex.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        grilla_kardex.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        grilla_kardex.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_kardex.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        Dim tipo_movimiento As String

        For i = 0 To grilla_kardex.Rows.Count - 1
            tipo_movimiento = grilla_kardex.Rows(i).Cells(2).Value.ToString
            If tipo_movimiento = "ENTRA" Then
                grilla_kardex.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue

                If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
                    grilla_kardex.Rows(i).Cells(9).Value = ""
                End If
            End If

            If tipo_movimiento = "AJUSTE" Then
                grilla_kardex.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next

        If grilla_kardex.Columns(0).Width = 100 Then
            grilla_kardex.Columns(0).Width = 99
        Else
            grilla_kardex.Columns(0).Width = 100
        End If


        ' grilla_kardex.Columns(5).SortMode = True

        grilla_kardex.Sort(grilla_kardex.Columns(7), System.ComponentModel.ListSortDirection.Descending)

        txt_cantidad_item.Text = grilla_kardex.Rows.Count

        'Dim VarMovimiento As String
        'Dim VarTipo As String
        'Dim VarNumero As String
        'Dim VarFecha As String
        'Dim VarCantidad As Integer
        'Dim VarCosto As String
        ''  Dim VarVenta As String
        'Dim VarSaldo As String
        'Dim VarCantidadAnterior As Integer

        'grilla_detalle.Rows.Clear()

        'For i = 0 To grilla_kardex.Rows.Count - 1

        '    VarMovimiento = grilla_kardex.Rows(i).Cells(0).Value.ToString
        '    VarTipo = grilla_kardex.Rows(i).Cells(1).Value.ToString
        '    VarNumero = grilla_kardex.Rows(i).Cells(2).Value.ToString
        '    VarFecha = grilla_kardex.Rows(i).Cells(3).Value
        '    VarCantidad = grilla_kardex.Rows(i).Cells(4).Value.ToString
        '    VarCosto = grilla_kardex.Rows(i).Cells(5).Value.ToString
        '    '   VarVenta = grilla_kardex.Rows(i).Cells(6).Value.ToString
        '    ' VarSaldo = 0

        '    If grilla_detalle.Rows.Count = 0 Then
        '        VarSaldo = VarCantidad
        '    ElseIf VarMovimiento = "ENTRA" Then
        '        VarSaldo = VarCantidadAnterior + VarCantidad
        '    ElseIf VarMovimiento = "SALE" Then
        '        VarSaldo = VarCantidadAnterior - VarCantidad
        '    End If




        '    grilla_detalle.Rows.Add(VarMovimiento, VarTipo, VarNumero, VarFecha, VarCantidad, VarCosto, VarSaldo)

        '    VarCantidadAnterior = VarSaldo
        'Next




        'grilla_kardex.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_kardex.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grilla_kardex.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_kardex.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '' grilla_kardex.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '' grilla_kardex.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight






        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'SC.Connection = conexion
        'SC.CommandText = "select movimiento as MOVIMIENTO, TIPO as TIPO, n_total as NUMERO, FECHA as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO  from detalle_total where estado <> 'ANULADA' and cod_producto= '" & (txt_codigo_producto.Text) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP BY cod_detalle"

        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'grilla_detalle.Rows.Clear()
        ''grilla_detalle.Columns.Clear()
        ''grilla_detalle.Columns.Add("movimiento", "MOVIMIENTO")
        ''grilla_detalle.Columns.Add("TIPO", "TIPO")
        ''grilla_kardex.Columns.Add("NUMERO", "NUMERO")
        ''grilla_kardex.Columns.Add("FECHA", "FECHA")
        ''grilla_kardex.Columns.Add("CANTIDAD", "CANTIDAD")
        ''grilla_kardex.Columns.Add("PRECIO", "PRECIO")
        ''grilla_kardex.Columns.Add("COSTO", "VENTA")
        ''grilla_kardex.Columns.Add("SALDO", "SALDO")

        '' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then

        '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '        grilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"), _
        '                                      DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
        '                                       DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
        '                                        DS.Tables(DT.TableName).Rows(i).Item("FECHA"), _
        '                                         DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
        '                                          DS.Tables(DT.TableName).Rows(i).Item("PRECIO"))
        '    Next
        'End If
    End Sub

    Private Sub combo_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    'Sub busca_fecha_minima()

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    Try
    '        SC.Connection = conexion
    '        SC.CommandText = "select min(total.fecha_venta) as fecha_venta from total, detalle_total where detalle_total.cod_producto='" & (txt_codigo_producto.Text) & "' and total.n_total=detalle_total.n_total"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            lbl_desde.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
    '        End If
    '    Catch err As InvalidCastException
    '        lbl_desde.Text = ""
    '    End Try
    '    conexion.Close()
    'End Sub

    'Sub busca_fecha_maxima()

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    Try
    '        SC.Connection = conexion
    '        SC.CommandText = "select max(total.fecha_venta) as fecha_venta from total, detalle_total where detalle_total.cod_producto='" & (txt_codigo_producto.Text) & "' and total.n_total=detalle_total.n_total"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            lbl_hasta.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
    '        End If
    '    Catch err As InvalidCastException
    '        lbl_hasta.Text = ""
    '    End Try
    '    conexion.Close()
    'End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        'Form_buscar_productos3.Show()
        Form_buscador_productos_cartola_kardex.Show()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub txt_codigo_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.GotFocus
        txt_codigo_producto.BackColor = Color.LightSkyBlue
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

        limpiar_producto()
        grilla_kardex.Rows.Clear()
        grilla_kardex.Columns.Clear()


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If Check_movimientos.Checked = False Then
                If txt_codigo_producto.Text = "" Then
                    MsgBox("SELECCIONE UN PRODUCTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Me.Enabled = True
                    lbl_mensaje.Visible = False
                    txt_codigo_producto.Focus()
                    Exit Sub
                End If
            End If

            lbl_mensaje.Visible = True
            Me.Enabled = False

            If Combo_sucursal.Text <> mirecintoempresa Then
                crear_conexion()
                mostrar_datos_productos()
                mostrar_malla()
                recuperar_conexion_actual()
            Else
                mostrar_datos_productos()
                mostrar_malla()
            End If

            txt_cantidad_item.Text = grilla_kardex.Rows.Count

            If txt_cantidad_item.Text = "" Or txt_cantidad_item.Text = "0" Then
                txt_cantidad_item.Text = "0"
            Else
                txt_cantidad_item.Text = Format(Int(txt_cantidad_item.Text), "###,###,###")
            End If

            grilla_kardex.Focus()

            lbl_mensaje.Visible = False
            Me.Enabled = True


        End If
    End Sub

    Sub limpiar()
        txt_cantidad.Text = ""
        txt_cantidad_item.Text = ""
        '   txt_codigo_producto.Text = ""
        'txt_factor.Text = ""
        txt_proveedor.Text = ""
        txt_nombre_producto.Text = ""
        txt_numero_tecnico.Text = ""
        txt_precio.Text = ""
        txt_proveedor.Text = ""
        txt_nombre_producto.Text = ""
        grilla_kardex.DataSource = Nothing

    End Sub

    Sub limpiar_producto()
        txt_cantidad.Text = ""
        txt_cantidad_item.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
        txt_proveedor.Text = ""
        txt_nombre_producto.Text = ""
        txt_numero_tecnico.Text = ""
        txt_precio.Text = ""
        txt_proveedor.Text = ""
        txt_nombre_producto.Text = ""
    End Sub

    Private Sub txt_codigo_producto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.LostFocus
        txt_codigo_producto.BackColor = Color.White
    End Sub


    Private Sub txt_codigo_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.TextChanged

    End Sub

    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_kardex.Rows.Clear()
        grilla_kardex.Columns.Clear()

        'If txt_codigo_producto.Text = "" Then
        '    MsgBox("SELECCIONE UN PRODUCTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    txt_codigo_producto.Focus()
        '    Exit Sub
        'End If


        ''fecha()
        ''fecha2()
        'mostrar_malla()
        'txt_cantidad_item.Text = grilla_kardex.Rows.Count
    End Sub

    Private Sub dtp2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged

        grilla_kardex.Rows.Clear()
        grilla_kardex.Columns.Clear()
        'If txt_codigo_producto.Text = "" Then
        '    MsgBox("SELECCIONE UN PRODUCTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    txt_codigo_producto.Focus()
        '    Exit Sub
        'End If
        ''fecha()
        ''fecha2()
        'mostrar_malla()
        'txt_cantidad_item.Text = grilla_kardex.Rows.Count
    End Sub


    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_revision_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_revision.GotFocus
        btn_revision.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_revision_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_revision.LostFocus
        btn_revision.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        grilla_kardex.Rows.Clear()
        grilla_kardex.Columns.Clear()

        If Check_movimientos.Checked = False Then
            If txt_codigo_producto.Text = "" Then
                MsgBox("SELECCIONE UN PRODUCTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Me.Enabled = True
                lbl_mensaje.Visible = False
                txt_codigo_producto.Focus()
                Exit Sub
            End If
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        If Combo_sucursal.Text <> mirecintoempresa Then
            crear_conexion()
            mostrar_datos_productos()
            mostrar_malla()
            recuperar_conexion_actual()
        Else
            mostrar_datos_productos()
            mostrar_malla()
        End If

        txt_cantidad_item.Text = grilla_kardex.Rows.Count

        If txt_cantidad_item.Text = "" Or txt_cantidad_item.Text = "0" Then
            txt_cantidad_item.Text = "0"
        Else
            txt_cantidad_item.Text = Format(Int(txt_cantidad_item.Text), "###,###,###")
        End If

        grilla_kardex.Focus()

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub





    Private Sub Check_movimientos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_movimientos.CheckedChanged
        limpiar_producto()
        txt_codigo_producto.Text = ""
    End Sub

    Private Sub grilla_kardex_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_kardex.CellContentClick

    End Sub

    Private Sub grilla_kardex_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_kardex.DoubleClick

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_kardex.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp_desde.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'Dim save As New SaveFileDialog
        'save.Filter = "Archivo Excel | *.xlsx"
        'If save.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Exportar_Excel(Me.grilla_kardex, save.FileName)
        'End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_kardex, save.FileName)
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub


    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_kardex.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_kardex.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_kardex.RowCount - 1
            For c As Integer = 0 To grilla_kardex.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_kardex.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    dt.Columns.Add(New DataColumn("logo_empresa", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("DataColumn1", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn2", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn3", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn4", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn5", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn6", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn7", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn8", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn9", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn10", GetType(String)))

    '    dt.Columns.Add(New DataColumn("titulo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fechas", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

    '    Dim DataColumn1 As String
    '    Dim DataColumn2 As String
    '    Dim DataColumn3 As String
    '    Dim DataColumn4 As String
    '    Dim DataColumn5 As String
    '    Dim DataColumn6 As String
    '    Dim DataColumn7 As String
    '    Dim DataColumn8 As String
    '    Dim DataColumn9 As String
    '    'Dim DataColumn10 As String

    '    For i = 0 To grilla_kardex.Rows.Count - 1
    '        DataColumn1 = grilla_kardex.Rows(i).Cells(0).Value.ToString
    '        DataColumn2 = grilla_kardex.Rows(i).Cells(1).Value.ToString
    '        DataColumn3 = grilla_kardex.Rows(i).Cells(2).Value.ToString
    '        DataColumn4 = grilla_kardex.Rows(i).Cells(3).Value.ToString
    '        DataColumn5 = grilla_kardex.Rows(i).Cells(4).Value.ToString
    '        DataColumn6 = grilla_kardex.Rows(i).Cells(6).Value.ToString
    '        DataColumn7 = grilla_kardex.Rows(i).Cells(7).Value.ToString
    '        DataColumn8 = grilla_kardex.Rows(i).Cells(8).Value.ToString
    '        DataColumn9 = grilla_kardex.Rows(i).Cells(9).Value.ToString
    '        'DataColumn10 = grilla_kardex.Rows(i).Cells(9).Value.ToString
    '        dr = dt.NewRow()

    '        'Try
    '        '    dr("logo_empresa") = Imagen_reporte
    '        'Catch
    '        'End Try



    '        dr("nombre_empresa") = minombreempresa
    '        dr("giro_empresa") = migiroempresa
    '        dr("direccion_empresa") = midireccionempresa
    '        dr("comuna_empresa") = micomunaempresa
    '        dr("telefono_empresa") = mitelefonoempresa
    '        dr("correo_empresa") = micorreoempresa
    '        dr("rut_empresa") = mirutempresa
    '        dr("titulo") = "CARTOLA CARDEX (" & txt_codigo_producto.Text & ")"
    '        dr("fechas") = "DESDE: " & dtp_hasta.Text & " HASTA: " & dtp_hasta.Text

    '        dr("DataColumn1") = DataColumn1
    '        dr("DataColumn2") = DataColumn2
    '        dr("DataColumn3") = DataColumn3
    '        dr("DataColumn4") = DataColumn4
    '        dr("DataColumn5") = DataColumn5
    '        dr("DataColumn6") = DataColumn6
    '        dr("DataColumn7") = DataColumn7
    '        dr("DataColumn8") = DataColumn8
    '        dr("DataColumn9") = DataColumn9
    '        'dr("DataColumn10") = DataColumn10


    '        dt.Rows.Add(dr)
    '    Next

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "DS_reporte"
    '    Dim iDS As New DS_reporte
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function

    'Public Function ImageToByte(ByVal pImagen As Image) As Byte()
    '    Dim mImage() As Byte
    '    Try
    '        If Not IsNothing(pImagen) Then
    '            Dim ms As New System.IO.MemoryStream
    '            pImagen.Save(ms, pImagen.RawFormat)
    '            mImage = ms.GetBuffer
    '            ms.Close()
    '            Return mImage
    '        Else
    '            Return Nothing
    '        End If
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = False
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        'Try
        '    Dim iReporte As New form_informe_estado_de_cuenta_personalizado
        '    Dim rpt As New Crystal_cartola_kardex

        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()

        '    iReporte.Reporte = rpt
        '    iReporte.ShowDialog()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        lbl_mensaje.Visible = False
        Me.Enabled = True
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
        SC3.CommandText = "select * from sucursales order by nombre_sucursal"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        ' Combo_sucursal.Items.Add("-")

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
            Next
        End If
        Combo_sucursal.SelectedItem = mirecintoempresa
        conexion.Close()


        If mirutempresa = "81921000-4" Then
            If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
                Combo_sucursal.Items.Clear()
                conexion.Close()
                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()

                SC3.Connection = conexion
                SC3.CommandText = "select * from sucursales order by nombre_sucursal"
                DA3.SelectCommand = SC3
                DA3.Fill(DT3)
                DS3.Tables.Add(DT3)
                ' Combo_sucursal.Items.Add("-")

                If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                    For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                        Combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
                    Next
                End If
                Combo_sucursal.SelectedItem = mirecintoempresa
            Else
                Combo_sucursal.Items.Clear()
                Combo_sucursal.Items.Add(mirecintoempresa)
                Combo_sucursal.SelectedItem = mirecintoempresa
            End If
        End If
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

                'If recinto = "EXEQUIEL GONZALEZ 226" Then
                '    conexion.Close()
                '    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                '    Exit Sub
                'End If
                'If recinto = "EXEQUIEL GONZALEZ 366" Then
                '    conexion.Close()
                '    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                '    Exit Sub
                'End If

                conexion.Close()
                conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                Try

                    conexion.Open()
                    conexion.Close()

                Catch
                    recuperar_conexion_actual()
                    Me.Close()
                End Try

                Exit Sub
            End If
        Next
    End Sub

    Private Sub Combo_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_sucursal.SelectedIndexChanged
        grilla_kardex.Rows.Clear()
        grilla_kardex.Columns.Clear()
    End Sub

    Private Sub btn_revision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_revision.Click
        If txt_codigo_producto.Text = "" Then
            txt_codigo_producto.Focus()
            MsgBox("CAMPO CODIGO PRODUCTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_nombre_producto.Text = "" Then
            txt_codigo_producto.Focus()
            MsgBox("CAMPO CODIGO PRODUCTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If grilla_kardex.Rows.Count = 0 Then
        '    MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    txt_codigo_producto.Focus()
        '    Exit Sub
        'End If

        Form_quiebre.Show()
        Me.Enabled = False
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 7, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 7, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Try
            Dim imagen_reporte As Image
            imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
            Dim posicion_imagen As New PointF(margen_izquierdo + 530, margen_superior + 10)
            e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 75, margen_izquierdo + 780, margen_superior + 45)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 780, margen_superior + 60)

        e.Graphics.DrawString("CARTOLA KARDEX", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 108, margen_izquierdo + 810, margen_superior + 108)
        e.Graphics.DrawString("DESDE EL " & dtp_desde.Text & " HASTA " & dtp_hasta.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 10, margen_superior + 140)
        e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 70, margen_superior + 140)
        e.Graphics.DrawString("MOV.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 270, margen_superior + 140)
        e.Graphics.DrawString("USUARIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 330, margen_superior + 140)
        e.Graphics.DrawString("TIPO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 470, margen_superior + 140)
        e.Graphics.DrawString("NUMERO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 560, margen_superior + 140)
        e.Graphics.DrawString("FECHA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 620, margen_superior + 140)
        e.Graphics.DrawString("CANT.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 700, margen_superior + 140)
        e.Graphics.DrawString("VALOR", Font_titulo_columna, Brushes.Black, margen_izquierdo + 770, margen_superior + 140)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 155, margen_izquierdo + 810, margen_superior + 155)

        Dim Var_codigo As String
        Dim Var_nombre As String
        Dim Var_movimiento As String
        Dim Var_usuario As String
        Dim Var_tipo As String
        Dim Var_numero As String
        Dim Var_fecha As String
        Dim Var_cantidad As String
        Dim Var_valor As String

        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10

        For i = numero_lineas_total To grilla_kardex.Rows.Count - 1

            Var_codigo = grilla_kardex.Rows(i).Cells(0).Value.ToString
            Var_nombre = grilla_kardex.Rows(i).Cells(1).Value.ToString
            Var_movimiento = grilla_kardex.Rows(i).Cells(2).Value.ToString
            Var_usuario = grilla_kardex.Rows(i).Cells(3).Value.ToString
            Var_tipo = grilla_kardex.Rows(i).Cells(4).Value.ToString
            Var_numero = grilla_kardex.Rows(i).Cells(6).Value.ToString
            Var_fecha = grilla_kardex.Rows(i).Cells(7).Value.ToString
            Var_cantidad = grilla_kardex.Rows(i).Cells(8).Value.ToString
            Var_valor = grilla_kardex.Rows(i).Cells(9).Value.ToString

            If Var_valor = "" Or Var_valor = "0" Then
                Var_valor = "0"
            Else
                Var_valor = Format(Int(Var_valor), "###,###,###")
            End If

            If Var_fecha.Length > 10 Then
                Var_fecha = Var_fecha.Substring(0, 10)
            End If

            If Var_nombre.Length > 28 Then
                Var_nombre = Var_nombre.Substring(0, 28)
            End If

            If Var_usuario.Length > 19 Then
                Var_usuario = Var_usuario.Substring(0, 19)
            End If

            If Var_tipo = "BOLETA DE CREDITO" Then
                Var_tipo = "BOLETA"
            End If

            If Var_tipo = "BOLETA DE CAMBIO" Then
                Var_tipo = "BOLETA"
            End If

            If Var_tipo = "FACTURA DE CREDITO" Then
                Var_tipo = "FACTURA"
            End If

            If Var_tipo = "NOTA DE CREDITO" Then
                Var_tipo = "NOTA DE C."
            End If

            If Var_tipo = "NOTA DE DEBITO" Then
                Var_tipo = "NOTA DE D."
            End If

            If Var_tipo = "CONSUMO INTERNO" Then
                Var_tipo = "CONSUMO INT."
            End If


            'e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 10, margen_superior + 120)
            'e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 70, margen_superior + 120)
            'e.Graphics.DrawString("MOV.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 270, margen_superior + 120)
            'e.Graphics.DrawString("USUARIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 330, margen_superior + 120)
            'e.Graphics.DrawString("TIPO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 470, margen_superior + 120)
            'e.Graphics.DrawString("NUMERO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 610, margen_superior + 120, format1)
            'e.Graphics.DrawString("FECHA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 580, margen_superior + 120)
            'e.Graphics.DrawString("CANT.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 780, margen_superior + 120, format1)
            'e.Graphics.DrawString("VALOR", Font_titulo_columna, Brushes.Black, margen_izquierdo + 740, margen_superior + 120, format1)
            e.Graphics.DrawString(Var_codigo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 10, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(Var_nombre, Font_texto_impresion, Brushes.Black, margen_izquierdo + 70, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(Var_movimiento, Font_texto_impresion, Brushes.Black, margen_izquierdo + 270, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(Var_usuario, Font_texto_impresion, Brushes.Black, margen_izquierdo + 330, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(Var_tipo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 470, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(Var_numero, Font_texto_impresion, Brushes.Black, margen_izquierdo + 610, margen_superior + 160 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(Var_fecha, Font_texto_impresion, Brushes.Black, margen_izquierdo + 620, margen_superior + 160 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(Var_cantidad, Font_texto_impresion, Brushes.Black, margen_izquierdo + 740, margen_superior + 160 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(Var_valor, Font_texto_impresion, Brushes.Black, margen_izquierdo + 810, margen_superior + 160 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 80 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 165 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 165 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 165 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 165 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0
    End Sub
End Class