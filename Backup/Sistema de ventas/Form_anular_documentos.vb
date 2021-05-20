Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_anular_documentos
    Private WithEvents Pd As New PrintDocument
    Dim total_anular As String

    Private Sub anular_documentos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_anular_documentos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    'le entregamos el formato de fecha al label y se le dice que tome la fehca de ahora.
    'se llama al sub fecha.
    Private Sub anular_documentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lbl_fecha.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_hoy.CustomFormat = "yyy-MM-dd"
        cargar_logo()

        If mirutempresa = "87686300-6" Then
            If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
                btn_anular.Enabled = False
            End If
        End If
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    'limpiamos los campos mencionados.
    Sub limpiar()
        txt_rut.Text = ""
        txt_nombre_cliente.Text = ""
        txt_telefono.Text = ""
        txt_direccion.Text = ""
        txt_nro_doc.Text = ""

        grilla_documento.DataSource = Nothing
        grilla_detalle_documento.DataSource = Nothing
        grilla_documento.Rows.Clear()
        grilla_detalle_documento.Rows.Clear()
    End Sub


    Sub cargar_cambio()
        Dim cadena As String
        Dim tabla() As String
        Dim n As Integer





        Dim cadena_cambio As String

        Dim nro_cambio As String

        cadena_cambio = grilla_detalle_documento.CurrentRow.Cells(1).Value


        nro_cambio = ""

        cadena = cadena_cambio
        tabla = Split(cadena, "CAMBIO DE PRODUCTO, VALE NRO. ")
        For n = 0 To UBound(tabla, 1)
            If tabla(n) <> "BOLETA" Then
                nro_cambio = nro_cambio & tabla(n)
            End If
        Next

        grilla_detalle_documento.Height = "173"

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_vale_cambio  where  nro_vale = '" & (nro_cambio) & "'"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_cambio.Rows.Clear()
        grilla_cambio.Columns.Clear()
        grilla_cambio.Columns.Add("cod_producto", "CODIGO")
        grilla_cambio.Columns.Add("detalle_nombre", "NOMBRE")
        grilla_cambio.Columns.Add("valor_unitario", "VALOR")
        grilla_cambio.Columns.Add("cantidad", "CANT.")
        grilla_cambio.Columns.Add("detalle_Neto", "NETO")
        grilla_cambio.Columns.Add("detalle_iva", "IVA")
        grilla_cambio.Columns.Add("detalle_total", "TOTAL")
        grilla_cambio.Columns.Add("movimiento", "MOV.")

        '  Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_cambio.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"))

            Next
        End If

        grilla_cambio.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_cambio.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_cambio.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_cambio.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_cambio.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    'se definen 3 variables previas, varcodproducto y varcantidad indican la posicion del dato en la grilla.
    'la variable estado indica el dato que tiene grabado.
    'si la variable estado es igual a EMITIDA o SIN FACTURAR entonces el ciclo recorre la grilla y se actualizan los productos.
    Sub devolver_productos()
        Dim VarCodProducto As String
        Dim VarCantidad As Integer
        ' Dim estado As String
        Dim VarMovimiento As String


        Dim nro_doc As String
        Dim tipo_doc As String
        Dim rut_doc As String
        Dim descuento_doc As String
        Dim neto_doc As String
        Dim iva_doc As String
        Dim total_doc As String
        Dim condicion_doc As String
        Dim estado_doc As String
        Dim fecha_doc As String
        Dim impresion_doc As String
        Dim usuario_doc As String

        nro_doc = grilla_documento.CurrentRow.Cells(0).Value
        tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        rut_doc = grilla_documento.CurrentRow.Cells(2).Value
        descuento_doc = grilla_documento.CurrentRow.Cells(3).Value
        neto_doc = grilla_documento.CurrentRow.Cells(4).Value
        iva_doc = grilla_documento.CurrentRow.Cells(5).Value
        total_doc = grilla_documento.CurrentRow.Cells(6).Value
        condicion_doc = grilla_documento.CurrentRow.Cells(7).Value
        estado_doc = grilla_documento.CurrentRow.Cells(8).Value
        fecha_doc = grilla_documento.CurrentRow.Cells(9).Value
        impresion_doc = grilla_documento.CurrentRow.Cells(10).Value
        usuario_doc = grilla_documento.CurrentRow.Cells(11).Value






        mostrar_malla()
        mostrar_malla_detalle()
        If combo_documentos.Text <> "COMPRAS" And combo_documentos.Text <> "ABONO" Then
            ' estado = grilla_documento.CurrentRow.Cells(8).Value

            If combo_documentos.Text = "VALE DE CAMBIO" Then
                estado_doc = grilla_documento.CurrentRow.Cells(7).Value
                If estado_doc = "EMITIDA" Or estado_doc = "EMITIDO" Then
                    For i = 0 To grilla_detalle_documento.Rows.Count - 1

                        VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value
                        VarCantidad = grilla_detalle_documento.Rows(i).Cells(3).Value
                        VarMovimiento = grilla_detalle_documento.Rows(i).Cells(7).Value

                        If VarMovimiento = "ENTRA" Then





                            If txt_doc_referencia.Text = "BOLETA" Then

                                conexion.Close()
                                DS.Tables.Clear()
                                DT.Rows.Clear()
                                DT.Columns.Clear()
                                DS.Clear()
                                conexion.Open()

                                SC.Connection = conexion
                                SC.CommandText = "select * from BOLETA where n_boleta='" & (txt_nro_doc_referencia.Text) & "'"

                                DA.SelectCommand = SC
                                DA.Fill(DT)
                                DS.Tables.Add(DT)

                                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                                    txt_estado_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("estado")
                                End If
                                conexion.Close()

                                If txt_estado_doc_referencia.Text <> "ANULADA" Then
                                    SC.Connection = conexion
                                    SC.CommandText = "update detalle_boleta set cantidad = " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "' and n_boleta='" & (txt_nro_doc_referencia.Text) & "'"
                                    DA.SelectCommand = SC
                                    DA.Fill(DT)
                                End If
                            End If

                            If txt_doc_referencia.Text = "FACTURA" Then

                                conexion.Close()
                                DS.Tables.Clear()
                                DT.Rows.Clear()
                                DT.Columns.Clear()
                                DS.Clear()
                                conexion.Open()

                                SC.Connection = conexion
                                SC.CommandText = "select * from factura where n_factura='" & (txt_nro_doc_referencia.Text) & "'"

                                DA.SelectCommand = SC
                                DA.Fill(DT)
                                DS.Tables.Add(DT)

                                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                                    txt_estado_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("estado")
                                End If
                                conexion.Close()

                                If txt_estado_doc_referencia.Text <> "ANULADA" Then
                                    SC.Connection = conexion
                                    SC.CommandText = "update detalle_factura set cantidad = " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "' and n_factura='" & (txt_nro_doc_referencia.Text) & "'"
                                    DA.SelectCommand = SC
                                    DA.Fill(DT)
                                End If
                            End If

                            If txt_doc_referencia.Text = "GUIA" Then

                                conexion.Close()
                                DS.Tables.Clear()
                                DT.Rows.Clear()
                                DT.Columns.Clear()
                                DS.Clear()
                                conexion.Open()

                                SC.Connection = conexion
                                SC.CommandText = "select * from guia where n_guia='" & (txt_nro_doc_referencia.Text) & "'"

                                DA.SelectCommand = SC
                                DA.Fill(DT)
                                DS.Tables.Add(DT)

                                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                                    txt_estado_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("estado")
                                End If
                                conexion.Close()

                                If txt_estado_doc_referencia.Text <> "ANULADA" Then
                                    SC.Connection = conexion
                                    SC.CommandText = "update detalle_guia set cantidad = " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "' and n_guia='" & (txt_nro_doc_referencia.Text) & "'"
                                    DA.SelectCommand = SC
                                    DA.Fill(DT)
                                End If
                            End If



                            SC.Connection = conexion
                            SC.CommandText = "update productos set cantidad = cantidad - " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                        End If

                        If VarMovimiento = "SALE" Then
                            SC.Connection = conexion
                            SC.CommandText = "update productos set cantidad = cantidad + " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                        End If

                    Next

                    mostrar_malla()
                    mostrar_malla_detalle()

                    Exit Sub
                End If
            End If


            If estado_doc = "EMITIDA" Or estado_doc = "EMITIDO" Then
                For i = 0 To grilla_detalle_documento.Rows.Count - 1

                    VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value
                    VarCantidad = grilla_detalle_documento.Rows(i).Cells(3).Value
                    '   estado = migrilla.Rows(i).Cells(7).Value

                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad + " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    conexion.Close()
                Next

                mostrar_malla()
                mostrar_malla_detalle()

                Exit Sub
            End If

            If estado_doc = "SIN FACTURAR" Then
                For i = 0 To grilla_detalle_documento.Rows.Count - 1
                    VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value
                    VarCantidad = grilla_detalle_documento.Rows(i).Cells(3).Value
                    '  estado = grilla_detalle_documento.Rows(i).Cells(7).Value


                    Dim codigo As String = 0
                    Dim valor As Integer
                    codigo = VarCodProducto

                    valor = codigo
                    VarCodProducto = String.Format("{0:000000}", valor)

                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad + " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    conexion.Close()


                Next
                Exit Sub
            End If


        End If





        If combo_documentos.Text = "COMPRAS" Then
            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value
                VarCantidad = grilla_detalle_documento.Rows(i).Cells(3).Value
                'estado = migrilla.Rows(i).Cells(7).Value

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "update productos set cantidad = cantidad - " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                conexion.Close()
            Next
        End If
        Exit Sub
    End Sub

    ' muestra los datos del cliente al cual se le emitio el  documento, atraves de una consulta sql.
    Sub mostrar_datos_clientes()
        Dim nro_doc As String
        Dim tipo_doc As String
        Dim rut_doc As String
        Dim descuento_doc As Integer
        Dim neto_doc As String
        Dim iva_doc As String
        Dim total_doc As String
        Dim condicion_doc As String
        Dim estado_doc As String
        Dim fecha_doc As String
        Dim impresion_doc As String
        Dim usuario_doc As String

        nro_doc = grilla_documento.CurrentRow.Cells(0).Value
        tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        rut_doc = grilla_documento.CurrentRow.Cells(12).Value
        descuento_doc = grilla_documento.CurrentRow.Cells(3).Value
        neto_doc = grilla_documento.CurrentRow.Cells(4).Value
        iva_doc = grilla_documento.CurrentRow.Cells(5).Value
        total_doc = grilla_documento.CurrentRow.Cells(6).Value
        condicion_doc = grilla_documento.CurrentRow.Cells(7).Value
        estado_doc = grilla_documento.CurrentRow.Cells(8).Value
        fecha_doc = grilla_documento.CurrentRow.Cells(9).Value
        impresion_doc = grilla_documento.CurrentRow.Cells(10).Value
        usuario_doc = grilla_documento.CurrentRow.Cells(11).Value


        If combo_documentos.Text = "VALE DE CAMBIO" Then
            Exit Sub
        End If

        If grilla_documento.Rows.Count > 0 Then
            ' rut_doc = grilla_documento.CurrentRow.Cells(2).Value

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes where cod_cliente ='" & (rut_doc) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
            End If
            conexion.Close()
        End If
    End Sub

    'muestra la informacion general en la grilla segun el numero que se seleccione previamente en el combobox de nombre numero.
    Sub mostrar_malla()
        grilla_detalle_documento.Height = 366

        If combo_documentos.Text = "ABONO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from abono, usuarios where n_abono =" & (txt_nro_doc.Text) & " and usuarios.rut_usuario= abono.usuario_responsable and TIPO <> 'AJUSTE'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim fecha_abono As String

                    fecha_abono = DS.Tables(DT.TableName).Rows(i).Item("fecha")

                    If fecha_abono.Length > 10 Then
                        fecha_abono = fecha_abono.Substring(0, 10)
                    End If
                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_abono"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                 "0", _
                                                  "0", _
                                                   "0", _
                                                    DS.Tables(DT.TableName).Rows(i).Item("monto_abono"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("condicion_abono"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("Estado"), _
                                                       fecha_abono, _
                                                        "-", _
                                                         DS.Tables(DT.TableName).Rows(i).Item("usuario_responsable"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"))
                Next

            End If
        End If


        If combo_documentos.Text = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from factura, usuarios where n_factura =" & (txt_nro_doc.Text) & " and usuarios.rut_usuario= factura.usuario_responsable and TIPO <> 'AJUSTE'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Dim fecha_venta As String
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    If fecha_venta.Length > 10 Then
                        fecha_venta = fecha_venta.Substring(0, 10)
                    End If

                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_factura"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("Estado"), _
                                                       fecha_venta, _
                                                        DS.Tables(DT.TableName).Rows(i).Item("tipo_impresion"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"))
                Next

            End If
        End If


        If combo_documentos.Text = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from BOLETA, usuarios where n_boleta ='" & (txt_nro_doc.Text) & "' and usuarios.rut_usuario= BOLETA.usuario_responsable and TIPO <> 'AJUSTE'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Dim fecha_venta As String
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    If fecha_venta.Length > 10 Then
                        fecha_venta = fecha_venta.Substring(0, 10)
                    End If

                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_boleta"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("Estado"), _
                                                       fecha_venta, _
                                                        DS.Tables(DT.TableName).Rows(i).Item("tipo_impresion"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"))
                Next

            End If
        End If


        If combo_documentos.Text = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from guia, usuarios where n_guia =" & (txt_nro_doc.Text) & " and usuarios.rut_usuario= guia.usuario_responsable and TIPO <> 'AJUSTE'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Dim fecha_venta As String
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    If fecha_venta.Length > 10 Then
                        fecha_venta = fecha_venta.Substring(0, 10)
                    End If

                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_guia"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("Estado"), _
                                                       fecha_venta, _
                                                        DS.Tables(DT.TableName).Rows(i).Item("tipo_impresion"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"))
                Next

            End If
        End If


        If combo_documentos.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from nota_credito, usuarios where n_nota_credito =" & (txt_nro_doc.Text) & " and usuarios.rut_usuario= nota_credito.usuario_responsable and TIPO <> 'AJUSTE'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Dim fecha_venta As String
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    If fecha_venta.Length > 10 Then
                        fecha_venta = fecha_venta.Substring(0, 10)
                    End If

                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_nota_credito"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("Estado"), _
                                                       fecha_venta, _
                                                        DS.Tables(DT.TableName).Rows(i).Item("tipo_impresion"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"))
                Next

            End If
        End If


        If combo_documentos.Text = "NOTA DE DEBITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from nota_debito, usuarios where n_nota_debito =" & (txt_nro_doc.Text) & " and usuarios.rut_usuario= nota_debito.usuario_responsable and TIPO <> 'AJUSTE'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Dim fecha_venta As String
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    If fecha_venta.Length > 10 Then
                        fecha_venta = fecha_venta.Substring(0, 10)
                    End If

                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_nota_debito"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("Estado"), _
                                                       fecha_venta, _
                                                        DS.Tables(DT.TableName).Rows(i).Item("tipo_impresion"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"))
                Next

            End If
        End If


        If combo_documentos.Text = "COMPRAS" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from compra, usuarios where n_compra =" & (txt_nro_doc.Text) & " and usuarios.rut_usuario= compra.usuario_responsable"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Dim fecha_venta As String
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_emision")
                    If fecha_venta.Length > 10 Then
                        fecha_venta = fecha_venta.Substring(0, 10)
                    End If

                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_compra"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                     "-", _
                                                      DS.Tables(DT.TableName).Rows(i).Item("Estado"), _
                                                       fecha_venta, _
                                                        "-", _
                                                         "-")
                Next

            End If
        End If


        If combo_documentos.Text = "VALE DE CAMBIO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from vale_cambio, usuarios where nro_vale =" & (txt_nro_doc.Text) & " and usuarios.rut_usuario= vale_cambio.usuario_responsable"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Dim fecha_venta As String
                txt_nro_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("documento_referencia")
                txt_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("nro_referencia")

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                    If fecha_venta.Length > 10 Then
                        fecha_venta = fecha_venta.Substring(0, 10)
                    End If

                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nro_vale"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                "-", _
                                                 DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("total_positivo"), _
                                                     "-", _
                                                      DS.Tables(DT.TableName).Rows(i).Item("Estado"), _
                                                       fecha_venta, _
                                                        "-", _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                          "-")
                Next

            End If
        End If




        If grilla_documento.Rows.Count = 0 Then
            MsgBox("EL DOCUMENTO NO FUE REGISTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc.Focus()
            Exit Sub
        Else
            mostrar_malla_detalle()
            mostrar_datos_clientes()
        End If










    End Sub


    'muestra la informacion detallada del documento segun el numero seleccionado en el combobox numero.
    Sub mostrar_malla_letras()

        If combo_documentos.Text = "BOLETA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from LETRAS  where  nro_referencia = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_letras.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_letras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_letra"))
                Next

            End If

        End If
    End Sub

    Sub mostrar_malla_convenio()

        If combo_documentos.Text = "BOLETA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from cuotas  where  nro_referencia = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_convenios.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_convenios.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_cuota"))
                Next

            End If

        End If
    End Sub


    'muestra la informacion detallada del documento segun el numero seleccionado en el combobox numero.
    Sub mostrar_malla_detalle()

        If combo_documentos.Text = "ABONO" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_abono  where  nro_abono = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()
            grilla_detalle_documento.Columns.Clear()
            grilla_detalle_documento.Columns.Add("nro_abono", "NRO. ABONO")
            grilla_detalle_documento.Columns.Add("nro_documento", "NRO. DOC.")
            grilla_detalle_documento.Columns.Add("tipo_documento", "TIPO DOC.")
            grilla_detalle_documento.Columns.Add("monto_abono", "MONTO")
            grilla_detalle_documento.Columns.Add("saldo_documento", "SALDO")

            'Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nro_abono"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("nro_documento"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("tipo_documento"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("monto_abono"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("saldo_documento"))

                Next
            End If

            grilla_detalle_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            Exit Sub

        End If






        If combo_documentos.Text = "FACTURA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura  where  n_factura = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()
            grilla_detalle_documento.Columns.Clear()
            grilla_detalle_documento.Columns.Add("cod_producto", "CODIGO")
            grilla_detalle_documento.Columns.Add("detalle_nombre", "NOMBRE")
            grilla_detalle_documento.Columns.Add("valor_unitario", "VALOR")
            grilla_detalle_documento.Columns.Add("cantidad", "CANT.")
            grilla_detalle_documento.Columns.Add("detalle_Neto", "NETO")
            grilla_detalle_documento.Columns.Add("detalle_iva", "IVA")
            grilla_detalle_documento.Columns.Add("detalle_total", "TOTAL")

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))

                Next
            End If

            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Exit Sub

        End If


        If combo_documentos.Text = "BOLETA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta  where  n_boleta = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()
            grilla_detalle_documento.Columns.Clear()
            grilla_detalle_documento.Columns.Add("cod_producto", "CODIGO")
            grilla_detalle_documento.Columns.Add("detalle_nombre", "NOMBRE")
            grilla_detalle_documento.Columns.Add("valor_unitario", "VALOR")
            grilla_detalle_documento.Columns.Add("cantidad", "CANT.")
            grilla_detalle_documento.Columns.Add("detalle_Neto", "NETO")
            grilla_detalle_documento.Columns.Add("detalle_iva", "IVA")
            grilla_detalle_documento.Columns.Add("detalle_total", "TOTAL")


            'Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))

                Next
            End If
            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Exit Sub
        End If



        If combo_documentos.Text = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_guia  where  n_guia = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()
            grilla_detalle_documento.Columns.Clear()
            grilla_detalle_documento.Columns.Add("cod_producto", "CODIGO")
            grilla_detalle_documento.Columns.Add("detalle_nombre", "NOMBRE")
            grilla_detalle_documento.Columns.Add("valor_unitario", "VALOR")
            grilla_detalle_documento.Columns.Add("cantidad", "CANT.")
            grilla_detalle_documento.Columns.Add("detalle_Neto", "NETO")
            grilla_detalle_documento.Columns.Add("detalle_iva", "IVA")
            grilla_detalle_documento.Columns.Add("detalle_total", "TOTAL")


            ' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))

                Next
            End If

            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Exit Sub
        End If

        If combo_documentos.Text = "COTIZACION" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_cotizacion  where  n_cotizacion = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()
            grilla_detalle_documento.Columns.Clear()

            grilla_detalle_documento.Columns.Add("cod_producto", "CODIGO")
            grilla_detalle_documento.Columns.Add("detalle_nombre", "NOMBRE")
            grilla_detalle_documento.Columns.Add("valor_unitario", "VALOR")
            grilla_detalle_documento.Columns.Add("cantidad", "CANT.")
            grilla_detalle_documento.Columns.Add("detalle_Neto", "NETO")
            grilla_detalle_documento.Columns.Add("detalle_iva", "IVA")
            grilla_detalle_documento.Columns.Add("detalle_total", "TOTAL")


            ' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))

                Next
            End If

            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Exit Sub
        End If

        If combo_documentos.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_nota_credito where  n_nota_credito = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()
            grilla_detalle_documento.Columns.Clear()
            grilla_detalle_documento.Columns.Add("cod_producto", "CODIGO")
            grilla_detalle_documento.Columns.Add("detalle_nombre", "NOMBRE")
            grilla_detalle_documento.Columns.Add("valor_unitario", "VALOR")
            grilla_detalle_documento.Columns.Add("cantidad", "CANT.")
            grilla_detalle_documento.Columns.Add("detalle_Neto", "NETO")
            grilla_detalle_documento.Columns.Add("detalle_iva", "IVA")
            grilla_detalle_documento.Columns.Add("detalle_total", "TOTAL")


            ' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))

                Next
            End If
            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Exit Sub
        End If


        If combo_documentos.Text = "NOTA DE DEBITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_nota_debito where  n_nota_debito = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()
            grilla_detalle_documento.Columns.Clear()
            grilla_detalle_documento.Columns.Add("cod_producto", "CODIGO")
            grilla_detalle_documento.Columns.Add("detalle_nombre", "NOMBRE")
            grilla_detalle_documento.Columns.Add("valor_unitario", "VALOR")
            grilla_detalle_documento.Columns.Add("cantidad", "CANT.")
            grilla_detalle_documento.Columns.Add("detalle_Neto", "NETO")
            grilla_detalle_documento.Columns.Add("detalle_iva", "IVA")
            grilla_detalle_documento.Columns.Add("detalle_total", "TOTAL")


            ' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))

                Next
            End If
            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Exit Sub
        End If


        If combo_documentos.Text = "COMPRAS" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_compra  where  n_compra = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()
            grilla_detalle_documento.Columns.Clear()
            grilla_detalle_documento.Columns.Add("cod_producto", "CODIGO")
            grilla_detalle_documento.Columns.Add("detalle_nombre", "NOMBRE")
            grilla_detalle_documento.Columns.Add("valor_unitario", "VALOR")
            grilla_detalle_documento.Columns.Add("cantidad", "CANT.")
            grilla_detalle_documento.Columns.Add("detalle_Neto", "NETO")
            grilla_detalle_documento.Columns.Add("detalle_iva", "IVA")
            grilla_detalle_documento.Columns.Add("detalle_total", "TOTAL")


            ' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("Neto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("total"))

                Next
            End If
            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Exit Sub
        End If






        If combo_documentos.Text = "VALE DE CAMBIO" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_vale_cambio  where  nro_vale = '" & (txt_nro_doc.Text) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()
            grilla_detalle_documento.Columns.Clear()
            grilla_detalle_documento.Columns.Add("cod_producto", "CODIGO")
            grilla_detalle_documento.Columns.Add("detalle_nombre", "NOMBRE")
            grilla_detalle_documento.Columns.Add("valor_unitario", "VALOR")
            grilla_detalle_documento.Columns.Add("cantidad", "CANT.")
            grilla_detalle_documento.Columns.Add("detalle_Neto", "NETO")
            grilla_detalle_documento.Columns.Add("detalle_iva", "IVA")
            grilla_detalle_documento.Columns.Add("detalle_total", "TOTAL")
            grilla_detalle_documento.Columns.Add("movimiento", "MOV.")

            '  Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"))

                Next
            End If

            grilla_detalle_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Exit Sub

        End If
    End Sub

    Private Sub combo_documentos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documentos.GotFocus
        combo_documentos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_documentos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documentos.LostFocus
        combo_documentos.BackColor = Color.White
    End Sub

    'segun el valor que se seleccione en el combo documento se haran las sifuientes acciones:
    'se llama a el sub fecha.
    'se llena combo numero segun el valor seleccionado.
    'se limpian los datos anteriores de los clientes.
    'se limpia el lbl_datos, que indica cuando se selecciona BOLETAs que estas no graban informacion del cliente.
    'se cambia el estado del boton anular segun el TIPO de documento.
    Private Sub combo_documentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documentos.SelectedIndexChanged
        txt_nro_doc.Enabled = True
        limpiar()
        txt_nro_doc.Focus()

        If combo_documentos.Text = "BOLETA" Then
            'lbl_datos.Text = "* EN BOLETAS NO SE GRABAN DATOS DE LOS CLIENTES"
            btn_anular.Enabled = True
            Exit Sub
        Else
            'lbl_datos.Text = ""
            '  btn_anular.Enabled = True
            Exit Sub
        End If

        If combo_documentos.Text = "COMPRAS" Then

            btn_anular.Enabled = False
        Else
            btn_anular.Enabled = True
        End If
    End Sub

    'anula el documento seleccionado dependiendo de la comprovacion del estado que tenga. hace una actualizacion al estado en la tabla especifica del documento y la general.
    'se actualiza la tabla especifica del documento y la tabla general de documentos.
    'se llama em mostrar malla y el mostrar malla detalle.
    Sub anulacion_documentos()
        Dim tipo_nombre As String
        Dim numero_guia As String
        Dim nro_doc As String
        Dim tipo_doc As String
        Dim rut_doc As String
        Dim descuento_doc As String
        Dim neto_doc As String
        Dim iva_doc As String
        Dim total_doc As String
        Dim condicion_doc As String
        Dim estado_doc As String
        Dim fecha_doc As String
        Dim impresion_doc As String
        Dim usuario_doc As String

        nro_doc = grilla_documento.CurrentRow.Cells(0).Value
        tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        rut_doc = grilla_documento.CurrentRow.Cells(2).Value
        descuento_doc = grilla_documento.CurrentRow.Cells(3).Value
        neto_doc = grilla_documento.CurrentRow.Cells(4).Value
        iva_doc = grilla_documento.CurrentRow.Cells(5).Value
        total_doc = grilla_documento.CurrentRow.Cells(6).Value
        condicion_doc = grilla_documento.CurrentRow.Cells(7).Value
        estado_doc = grilla_documento.CurrentRow.Cells(8).Value
        fecha_doc = grilla_documento.CurrentRow.Cells(9).Value
        impresion_doc = grilla_documento.CurrentRow.Cells(10).Value
        usuario_doc = grilla_documento.CurrentRow.Cells(11).Value

        SC.Connection = conexion
        SC.CommandText = "update detalle_condicion_de_pago set estado = 'ANULADA', VALOR = '0' where nro_doc = '" & (txt_nro_doc.Text) & "' and tipo_doc  = '" & (combo_documentos.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        If combo_documentos.Text = "ABONO" Then
            If estado_doc = "EMITIDA" Or estado_doc = "EMITIDO" Then
                SC.Connection = conexion
                SC.CommandText = "update ABONO set estado = 'ANULADO', MONTO_abono = '0', usuario_responsable= '" & (miusuario) & "' where n_abono = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update creditos set descuento= '0', neto= '0', iva= '0', subtotal= '0', total= '0', saldo= '0', desglose= '-', condiciones = '-', estado = 'ANULADO', usuario_responsable = '" & (miusuario) & "', codigo_afecta='0', nombre_afecta='-' where n_creditos = '" & (txt_nro_doc.Text) & "' and TIPO  = 'ABONO'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update letras set estado = 'ANULADA', monto_letra = '0', total_letra = '0' where nro_referencia = '" & (txt_nro_doc.Text) & "' and doc_referencia  = 'FACTURA'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                Dim nro_abono As String
                Dim nro_doc_abono As String
                Dim tipo_doc_abono As String
                Dim monto_abono As String

                For i = 0 To grilla_detalle_documento.Rows.Count - 1
                    nro_abono = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
                    nro_doc_abono = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
                    tipo_doc_abono = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
                    monto_abono = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString

                    SC.Connection = conexion
                    SC.CommandText = "update creditos set saldo = saldo + " & (monto_abono) & ",  ESTADO = 'EMITIDA' where rut_cliente = '" & (txt_rut.Text) & "'  and n_creditos ='" & (nro_doc_abono) & "'  and TIPO ='" & (tipo_doc_abono) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update clientes set saldo_cliente = saldo_cliente + " & (Int(monto_abono)) & " where rut_cliente = '" & (txt_rut.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update  detalle_abono set monto_abono = '0' , saldo_documento = '0' where nro_abono= '" & (txt_nro_doc.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "delete from creditos where TIPO = 'ABONO' and rut_cliente = '" & (txt_rut.Text) & "' and n_creditos= '" & (txt_nro_doc.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Next

                mostrar_malla()
                mostrar_malla_detalle()
                Exit Sub
            End If
        End If

        If combo_documentos.Text = "FACTURA" Then
            If estado_doc = "EMITIDA" Or estado_doc = "EMITIDO" Then
                SC.Connection = conexion
                SC.CommandText = "update factura set estado = '" & ("ANULADA") & "', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0', comision = '0', usuario_responsable= '" & (miusuario) & "' where n_factura = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update total set estado = '" & ("ANULADA") & "' , descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0', usuario_responsable= '" & (miusuario) & "' where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("FACTURA") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update detalle_factura set valor_unitario = '0', cantidad = '0', detalle_descuento = '0', detalle_neto = '0' ,detalle_iva = '0',detalle_subtotal = '0' , detalle_total = '0' where n_factura = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update detalle_total set estado = 'ANULADA', valor_unitario = '0', cantidad = '0', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0' where n_total = '" & (txt_nro_doc.Text) & "' and TIPO like 'FACTURA%'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update creditos set fecha_venta= '" & (Form_menu_principal.dtp_fecha.Text) & "', descuento= '0', neto= '0', iva= '0', subtotal= '0', total= '0', saldo= '0', desglose= '-', condiciones = '-', estado = 'ANULADA', usuario_responsable = '" & (miusuario) & "', codigo_afecta='0', nombre_afecta='-' where n_creditos = '" & (txt_nro_doc.Text) & "' and TIPO  = 'FACTURA'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update letras set estado = 'ANULADA', monto_letra = '0', total_letra = '0' where nro_referencia = '" & (txt_nro_doc.Text) & "' and doc_referencia  = 'FACTURA'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                If condicion_doc = "CREDITO" Then
                    SC.Connection = conexion
                    SC.CommandText = "update clientes set saldo_cliente = saldo_cliente + " & (Int(total_doc)) & " where rut_cliente = '" & (txt_rut.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update creditos set descuento= '0', neto= '0', iva= '0', subtotal= '0', total= '0', saldo= '0', condiciones = '-', estado = 'ANULADA', usuario_responsable = '" & (miusuario) & "', codigo_afecta='0', nombre_afecta='-' where n_creditos = '" & (txt_nro_doc.Text) & "' and TIPO= 'FACTURA'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update letras set estado = 'ANULADA', monto_letra = '0', total_letra = '0' where nro_referencia = '" & (txt_nro_doc.Text) & "' and doc_referencia  = 'FACTURA'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If


                For i = 0 To grilla_detalle_documento.Rows.Count - 1
                    numero_guia = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
                    tipo_nombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString

                    If tipo_nombre = "GUIA" Then
                        quitar_facturacion_de_guias()
                        Exit For
                    End If
                Next

                mostrar_malla()
                mostrar_malla_detalle()
                Exit Sub
            End If
        End If


        If combo_documentos.Text = "GUIA" And estado_doc = "SIN FACTURAR" Then
            If estado_doc = "SIN FACTURAR" Then

                SC.Connection = conexion
                SC.CommandText = "update guia_comisiones set estado = 'ANULADA', porcentaje_desc = '0', descuento = '0', total = '0', usuario_responsable= '" & (miusuario) & "' where n_guia = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update guia set estado = 'ANULADA', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0', comision = '0', usuario_responsable= '" & (miusuario) & "' where n_guia = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update total set estado = 'ANULADA', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0', usuario_responsable= '" & (miusuario) & "' where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("GUIA") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update detalle_guia set valor_unitario = '0', cantidad = '0', detalle_descuento = '0', detalle_neto = '0' ,detalle_iva = '0',detalle_subtotal = '0' , detalle_total = '0' where n_guia = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update detalle_total set  estado = 'ANULADA', valor_unitario = '0', cantidad = '0', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0' where n_total = '" & (txt_nro_doc.Text) & "' and TIPO like 'GUIA%'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                mostrar_malla()
                mostrar_malla_detalle()
                Exit Sub
            End If
        End If















        If combo_documentos.Text = "BOLETA" And estado_doc = "EMITIDA" Then

            'Dim total_boleta As Integer
            'Dim condicion_boleta As String

            'total_boleta = grilla_documento.CurrentRow.Cells(6).Value
            'condicion_boleta = grilla_documento.CurrentRow.Cells(7).Value

            SC.Connection = conexion
            SC.CommandText = "update BOLETA set estado = '" & ("ANULADA") & "', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0' , comision = '0', usuario_responsable= '" & (miusuario) & "' where n_boleta = '" & (txt_nro_doc.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update detalle_boleta set valor_unitario = '0', cantidad = '0', detalle_descuento = '0', detalle_neto = '0' ,detalle_iva = '0',detalle_subtotal = '0' , detalle_total = '0' where n_boleta = '" & (txt_nro_doc.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update detalle_total set  estado = 'ANULADA', valor_unitario = '0', cantidad = '0', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0' where n_total = '" & (txt_nro_doc.Text) & "' and TIPO like 'BOLETA%'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            If condicion_doc = "CREDITO" Then

                SC.Connection = conexion
                SC.CommandText = "update clientes set saldo_cliente = saldo_cliente + " & (Int(total_doc)) & " where rut_cliente = '" & (txt_rut.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update creditos set descuento= '0', neto= '0', iva= '0', subtotal= '0', total= '0', saldo= '0', condiciones = '-', estado = 'ANULADA', usuario_responsable = '" & (miusuario) & "', codigo_afecta='0', nombre_afecta='-' where n_creditos = '" & (txt_nro_doc.Text) & "' and TIPO  = 'BOLETA'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update letras set estado = 'ANULADA', monto_letra = '0', total_letra = '0' where nro_referencia = '" & (txt_nro_doc.Text) & "' and doc_referencia  = 'BOLETA'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If

            '' ''SC.Connection = conexion
            '' ''SC.CommandText = "insert into boleta_nula (n_boleta, fecha_anulacion, hora_anulacion, total_anulacion) values (" & (txt_nro_doc.Text) & " , '" & (form_Menu_admin.dtp_fecha.Text) & "', '" & (form_Menu_admin.lbl_hora.Text) & "', '" & (total_doc) & "')"
            '' ''DA.SelectCommand = SC
            '' ''DA.Fill(DT)

            mostrar_malla()
            mostrar_malla_detalle()
            Exit Sub

        End If






        If combo_documentos.Text = "NOTA DE CREDITO" Then
            If estado_doc = "EMITIDA" Or estado_doc = "EMITIDO" Then
                SC.Connection = conexion
                SC.CommandText = "update nota_credito set estado = '" & ("ANULADA") & "', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0', usuario_responsable= '" & (miusuario) & "' where nota_credito.n_nota_credito = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update total set estado = '" & ("ANULADA") & "', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0', usuario_responsable= '" & (miusuario) & "' where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("NOTA DE CREDITO") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update detalle_nota_credito set valor_unitario = '0', cantidad = '0', detalle_descuento = '0', detalle_neto = '0' ,detalle_iva = '0', detalle_subtotal = '0' , detalle_total = '0' where n_nota_credito = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update detalle_total set  estado = 'ANULADA', valor_unitario = '0', cantidad = '0', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0' where n_total = '" & (txt_nro_doc.Text) & "' and TIPO like 'NOTA DE CREDITO%'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                mostrar_malla()
                mostrar_malla_detalle()
                Exit Sub
            End If
        End If




        If combo_documentos.Text = "VALE DE CAMBIO" Then
            If estado_doc = "EMITIDA" Or estado_doc = "EMITIDO" Then
                SC.Connection = conexion
                SC.CommandText = "update vale_cambio set estado = '" & ("ANULADA") & "', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total_positivo = '0' , usuario_responsable= '" & (miusuario) & "' where nro_vale = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update detalle_vale_cambio set valor_unitario = '0', cantidad = '0', detalle_descuento = '0', detalle_neto = '0' ,detalle_iva = '0',detalle_subtotal = '0' , detalle_total = '0' where nro_vale = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "update detalle_total set  estado = '" & ("ANULADA") & "', valor_unitario = '0', cantidad = '0', descuento = '0', neto = '0' ,iva = '0',subtotal = '0' , total = '0' where n_total = '" & (txt_nro_doc.Text) & "' and TIPO  = '" & ("VALE DE CAMBIO") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                mostrar_malla()
                mostrar_malla_detalle()
                Exit Sub
            End If
        End If








    End Sub













    Sub anular_credito()
        Dim nro As Integer
        For i = 0 To grilla_letras.Rows.Count - 1
            nro = grilla_letras.Rows(i).Cells(0).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "update creditos set saldo = '0',  ESTADO = 'ANULADA' where rut_cliente = '" & (txt_rut.Text) & "'  and n_creditos ='" & (nro) & "'  and TIPO ='LETRA'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update letras set monto_letra = '0', total_letra = '0', estado = 'ANULADA'  where NRO_REFERENCIA = '" & (txt_nro_doc.Text) & "' and rut_cliente= '" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

        For i = 0 To grilla_convenios.Rows.Count - 1
            nro = grilla_convenios.Rows(i).Cells(0).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "update creditos set saldo = '0',  ESTADO = 'ANULADA' where rut_cliente = '" & (txt_rut.Text) & "'  and n_creditos ='" & (nro) & "'  and TIPO ='CUOTA'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update CUOTAS set monto_cuota = '0', total_cuota = '0', estado = 'ANULADA'  where NRO_REFERENCIA = '" & (txt_nro_doc.Text) & "' and rut_cliente= '" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next
    End Sub






    Sub anular_cambio()

        If combo_documentos.Text = "BOLETA" Then

            conexion.Close()
            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select * from boleta_cambio where n_boleta ='" & (txt_nro_doc.Text) & "'"
            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            Dim n_cambio As Integer

            If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
                n_cambio = DS4.Tables(DT4.TableName).Rows(0).Item("n_cambio")

                Dim valormensaje As Integer
                valormensaje = MsgBox("AL ANULAR LA BOLETA TAMBIEN ANULARA EL VALE DE CAMBIO NRO. " & n_cambio & " ¿DESEA CONTINUAR?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
                If valormensaje = vbYes Then
                    devolver_productos()
                    anulacion_documentos()


                    combo_documentos.SelectedItem = "VALE DE CAMBIO"
                    txt_nro_doc.Text = n_cambio

                    grilla_documento.Rows.Clear()
                    grilla_detalle_documento.Rows.Clear()

                    mostrar_malla()
                    mostrar_malla_detalle()
                    mostrar_datos_clientes()

                    devolver_productos()
                    anulacion_documentos()

                    mostrar_malla()
                    mostrar_malla_detalle()
                End If
                conexion.Close()
                Exit Sub

            Else

                devolver_productos()
                anulacion_documentos()




            End If
            conexion.Close()
        End If


        'If combo_documentos.Text = "VALE DE CAMBIO" Then

        '    conexion.Close()
        '    DS4.Tables.Clear()
        '    DT4.Rows.Clear()
        '    DT4.Columns.Clear()
        '    DS4.Clear()
        '    conexion.Open()

        '    SC4.Connection = conexion
        '    SC4.CommandText = "select * from boleta_cambio where n_cambio ='" & (txt_nro_doc.Text) & "'"
        '    DA4.SelectCommand = SC4
        '    DA4.Fill(DT4)
        '    DS4.Tables.Add(DT4)

        '    Dim n_boleta As Integer

        '    If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
        '        n_boleta = DS4.Tables(DT4.TableName).Rows(0).Item("n_boleta")

        '        Dim valormensaje As Integer
        '        valormensaje = MsgBox("AL ANULAR EL VALE DE CAMBIO TAMBIEN ANULARA LA BOLETA NRO. " & n_boleta & " ¿DESEA CONTINUAR?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        '        If valormensaje = vbYes Then
        '            devolver_productos()
        '            anulacion_documentos()

        '            combo_documentos.SelectedItem = "BOLETA"
        '            txt_nro_doc.Text = n_boleta

        '            grilla_documento.Rows.Clear()
        '            grilla_detalle_documento.Rows.Clear()

        '            mostrar_malla()
        '            mostrar_malla_detalle()
        '            mostrar_datos_clientes()

        '            devolver_productos()
        '            anulacion_documentos()

        '            mostrar_malla()
        '            mostrar_malla_detalle()
        '        End If
        '        conexion.Close()
        '        Exit Sub

        '    Else

        'devolver_productos()
        'anulacion_documentos()
        '    End If
        'conexion.Close()
        'End If

    End Sub

    'elimina el documento seleccionado. hace una delete del documento en la tabla especifica del documento y la general segun el numero de documento que se selecciono.
    'se actualiza la tabla especifica del documento y la tabla general de documentos.
    'se llama em mostrar malla y el mostrar malla detalle.
    Sub eliminacion_documentos()
        Dim valormensaje As Integer
        codigo_documento = grilla_documento.CurrentRow.Cells(0).Value
        tipo_documento = grilla_documento.CurrentRow.Cells(1).Value

        If combo_documentos.Text = "FACTURA CONTADO" Then
            valormensaje = MsgBox("¿desea eliminar esta factura de contado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")
            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from factura where n_factura = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                SC.Connection = conexion
                SC.CommandText = "delete from total where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("FACTURA") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            'combo_numero.Items.Clear()
            txt_nro_doc.Text = ""
            ' llenar_combo_numero_factura()
            mostrar_malla()
            mostrar_malla_detalle()
            Exit Sub
        End If

        If combo_documentos.Text = "FACTURA DE CREDITO" Then
            valormensaje = MsgBox("¿desea eliminar esta factura de credito?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")
            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from factura_credito where n_factura_credito = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                SC.Connection = conexion
                SC.CommandText = "delete from total where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("FACTURA CREDITO") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            'combo_numero.Items.Clear()
            txt_nro_doc.Text = ""
            'llenar_combo_numero_factura_credito()
            mostrar_malla()
            mostrar_malla_detalle()
            Exit Sub
        End If

        If combo_documentos.Text = "GUIA" Then
            valormensaje = MsgBox("¿desea eliminar esta guia?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")
            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from guia where n_guia = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                SC.Connection = conexion
                SC.CommandText = "delete from total where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("GUIA") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            ' combo_numero.Items.Clear()
            txt_nro_doc.Text = ""
            'llenar_combo_numero_guias()
            mostrar_malla()
            mostrar_malla_detalle()
            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA" Then
            valormensaje = MsgBox("¿desea eliminar esta BOLETA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")
            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from BOLETA where n_boleta = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                SC.Connection = conexion
                SC.CommandText = "delete from total where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("BOLETA") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            'combo_numero.Items.Clear()
            txt_nro_doc.Text = ""
            'llenar_combo_numero_boletas()
            mostrar_malla()
            mostrar_malla_detalle()
            Exit Sub
        End If

        If combo_documentos.Text = "BOLETA DE CREDITO" Then
            valormensaje = MsgBox("¿desea eliminar esta boleta_credito?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")
            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from boleta_credito where n_boleta_credito = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                SC.Connection = conexion
                SC.CommandText = "delete from total where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("BOLETA CREDITO") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            ' combo_numero.Items.Clear()
            txt_nro_doc.Text = ""
            'llenar_combo_numero_boleta_credito()
            mostrar_malla()
            mostrar_malla_detalle()
            Exit Sub
        End If

        If combo_documentos.Text = "NOTA DE CREDITO" Then
            valormensaje = MsgBox("¿desea eliminar esta nota de credito?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")
            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from nota_credito where n_nota_credito = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                SC.Connection = conexion
                SC.CommandText = "delete from total where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("NOTA DE CREDITO") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            'combo_numero.Items.Clear()
            txt_nro_doc.Text = ""
            'llenar_combo_numero_nota_credito()
            mostrar_malla()
            mostrar_malla_detalle()
            Exit Sub
        End If

        If combo_documentos.Text = "COMPRAS" Then
            valormensaje = MsgBox("¿DESEA ELIMINAR ESTA COMPRA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")
            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from compra where n_compra = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "delete from total where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("COMPRA") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            ' combo_numero.Items.Clear()
            txt_nro_doc.Text = ""
            'llenar_combo_numero_compras()
            mostrar_malla()
            mostrar_malla_detalle()
            Exit Sub
        End If

        If combo_documentos.Text = "COTIZACION" Then
            valormensaje = MsgBox("¿desea eliminar esta cotizacion?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")
            If valormensaje = vbYes Then
                SC.Connection = conexion
                SC.CommandText = "delete from cotizacion where n_cotizacion = '" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                SC.Connection = conexion
                SC.CommandText = "delete from total where n_total = '" & (txt_nro_doc.Text) & "'  and TIPO  = '" & ("COTIZACION") & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            mostrar_malla()
            mostrar_malla_detalle()
            Exit Sub
        End If
    End Sub

    'codigo para salir de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    'redireccionamos a la pantalla de buscar documentos.
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Me.Enabled = False
        Form_documentos.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'verificamos que los campos principales estes cargados para no cometer errores en la anulacion, si es asi se llama el devolver productos y anulamos el documento.
    Private Sub btn_anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_anular.Click
        If grilla_documento.Rows.Count = 0 Then
            MsgBox("GRILLA VACIA, SELECCIONE ALGUN DOCUMENTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_documentos.Focus()
            Exit Sub
        End If

        If combo_documentos.Text = "" Then
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_documentos.Focus()
            Exit Sub
        End If

        If txt_nro_doc.Text = "" Then
            MsgBox("CAMPO NUMERO DOC. VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc.Focus()
            Exit Sub
        End If

        If mirutempresa <> "81921000-4" Then
            If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
                If combo_documentos.Text = "NOTA DE CREDITO" Then
                    MsgBox("NO PUEDE ANULAR NOTAS DE CREDITO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_nro_doc.Focus()
                    Exit Sub
                End If
            End If
        End If

        Dim impresion_doc As String
        Dim fecha_doc As String
        Dim dias As Integer

        impresion_doc = grilla_documento.CurrentRow.Cells(10).Value
        total_anular = grilla_documento.CurrentRow.Cells(6).Value
        fecha_doc = grilla_documento.CurrentRow.Cells(9).Value


        If fecha_doc.Length > 10 Then
            fecha_doc = fecha_doc.Substring(0, 10)
        End If



        If fecha_doc <> "01-01-0001" Then
            dtp_hoy.Text = fecha_doc
            dias = DateDiff(DateInterval.Day, dtp_hoy.Value, Form_menu_principal.dtp_fecha.Value)
        End If

        If mirutempresa = "81921000-4" Then
            If dias <> "0" Then
                If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
                    MsgBox("NO PUEDE ANULAR ESTE DOCUMENTO POR LA FECHA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_nro_doc.Focus()
                    Exit Sub
                End If
            End If
        End If
        If mirutempresa <> "81921000-4" Then
            If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
                If dias <> "0" Then
                    MsgBox("NO PUEDE ANULAR ESTE DOCUMENTO POR LA FECHA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_nro_doc.Focus()
                    Exit Sub
                End If
            End If
        End If

        If impresion_doc = "ELECTRONICA" Then
            Me.Enabled = False
            Form_autorizacion_anular.Show()
            Form_autorizacion_anular.lbl_autorizacion.Text = "EL DOCUMENTO ES ELECTRONICO, SOLICITE AUTORIZACION"
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        If combo_documentos.SelectedItem = "BOLETA" Or combo_documentos.SelectedItem = "VALE DE CAMBIO" Then
            devolver_productos()
            anulacion_documentos()
            anular_cambio()
        Else
            devolver_productos()
            anulacion_documentos()
        End If

        SC.Connection = conexion
        SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('DOCUMENTOS','ANULACION DE DOCUMENTOS','" & (combo_documentos.Text & " " & txt_nro_doc.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','ANULACION','" & (miusuario) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into boleta_nula (n_boleta, fecha_anulacion, hora_anulacion, total_anulacion, documento) values (" & (txt_nro_doc.Text) & " , '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (Form_menu_principal.lbl_hora.Text) & "', '" & (total_anular) & "', '" & (combo_documentos.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        anular_credito()

        combo_documentos.Enabled = True
        txt_nro_doc.Enabled = True
        txt_nro_doc.Focus()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    'verificamos que los campos principales estes cargados para no cometer errores en la eliminacion, si es asi se llama el devolver productos y eliminamos el documento.
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mensaje As String = ""
        If grilla_documento.Rows.Count = 0 Then mensaje = "GRILLA VACÍA, SELECCIONE ALGUN DOCUMENTO" + Chr(13) & mensaje
        If combo_documentos.Text = "" Then mensaje = "COMBO DOCUMENTOS VACÍO, SELECCIONE ALGUN DOCUMENTO" + Chr(13) & mensaje
        If grilla_documento.Rows.Count = 0 Then mensaje = "COMBO NUMERO DOCUMENTO VACÍO, SELECCIONE ALGUN DOCUMENTO" + Chr(13) & mensaje

        If mensaje <> "" Then
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        Else
            devolver_productos()
            eliminacion_documentos()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_listado.Click
        Me.Enabled = False
        Form_listado_documentos.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txt_nro_doc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.GotFocus
        txt_nro_doc.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_doc.KeyPress
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




        grilla_detalle_documento.Height = 366
        grilla_documento.Rows.Clear()
        grilla_detalle_documento.Rows.Clear()

        txt_rut.Text = ""
        txt_nombre_cliente.Text = ""
        txt_telefono.Text = ""
        txt_direccion.Text = ""
        txt_codigo_cliente.Text = ""

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            'mostrar_malla()
            'mostrar_malla_detalle()
            'mostrar_datos_clientes()
            btn_mostrar.PerformClick()
            ' txt_nro_doc.Enabled = False
        End If
    End Sub

    Private Sub txt_nro_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.LostFocus
        txt_nro_doc.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_listado_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_listado.GotFocus
        btn_listado.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_listado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_listado.LostFocus
        btn_listado.BackColor = Color.Transparent
    End Sub

    Private Sub btn_anular_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anular.GotFocus
        btn_anular.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_anular_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anular.LostFocus
        btn_anular.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut.KeyPress

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

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub combo_documentos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documentos.TextChanged
        If combo_documentos.Text = "COMPRAS" Then

            btn_anular.Enabled = False
        Else
            btn_anular.Enabled = True
        End If
    End Sub

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub

    Private Sub grilla_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.DoubleClick






        If grilla_documento.Rows.Count <> 0 Then

            Dim estado As String
            Dim nro_factura As String


            ' nro_guia = grilla_listado.CurrentRow.Cells(1).Value
            estado = grilla_documento.CurrentRow.Cells(8).Value

            If combo_documentos.Text = "GUIA" And estado = "FACTURADA" Then

                conexion.Close()
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from detalle_factura where cod_producto ='" & (txt_nro_doc.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    nro_factura = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
                    '    fecha_factura = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")


                    MsgBox("GUIA FACTURADA CON DOCUMENTO NUMERO: " & nro_factura, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                End If
                conexion.Close()
                'End If
            End If
        End If
    End Sub

    Private Sub txt_codigo_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_cliente.TextChanged

    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage



        'Dim detalle_referencia As String
        'Dim detalle_abono As String
        'Dim detalle_total As String
        'Dim detalle_saldo As String
        'Dim Font11 As New Font("Lucida Console", 11, FontStyle.Regular)
        'Dim Font10 As New Font("Lucida Console", 10, FontStyle.Regular)
        'Dim Font9 As New Font("Lucida Console", 9, FontStyle.Regular)
        'Dim Font8 As New Font("Lucida Console", 8, FontStyle.Regular)

        Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)



        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far














        Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        Dim Font2 As New Font("arial", 9, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        'Dim im As Image


        Try
            'im = Image.FromFile(ruta_logo_empresa_ticket)
            Dim p As New PointF(0, 0)
            ' e.Graphics.DrawImage(im, p)
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_ticket), p)
        Catch
        End Try


        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center



        Dim rect1 As New Rectangle(10, 60, 270, 15)
        Dim rect2 As New Rectangle(10, 75, 270, 15)
        Dim rect3 As New Rectangle(10, 90, 270, 15)
        Dim rect4 As New Rectangle(10, 105, 270, 15)
        Dim rect5 As New Rectangle(10, 120, 270, 15)
        Dim rect6 As New Rectangle(10, 135, 270, 15)
        Dim rect7 As New Rectangle(10, 165, 270, 15)


        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

        e.Graphics.DrawString("COMPROBANTE DE INGRESO", Font2, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("NRO. ABONO", Font3, Brushes.Black, 0, 195)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 195)
        e.Graphics.DrawString(txt_n_abono.Text, Font4, Brushes.Black, 95, 195)
        e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 210)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 210)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font3, Brushes.Black, 95, 210)
        e.Graphics.DrawString("NOMBRE CLIENTE", Font3, Brushes.Black, 0, 225)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 225)
        e.Graphics.DrawString(txt_nombre_cliente.Text, Font3, Brushes.Black, 95, 225)
        e.Graphics.DrawString("RUT CLIENTE", Font3, Brushes.Black, 0, 240)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 240)
        e.Graphics.DrawString(txt_rut.Text, Font3, Brushes.Black, 95, 240)

        e.Graphics.DrawString("DETALLE REFERENCIA", Font3, Brushes.Black, 0, 270)
        e.Graphics.DrawString("ABONO", Font3, Brushes.Black, 170, 270)
        e.Graphics.DrawString("SALDO", Font3, Brushes.Black, 245, 270)

        e.Graphics.DrawLine(Pens.Black, 1, 285, 295, 285)


        e.Graphics.DrawString("SIN DOCUMENTOS IMPUTADOS", Font3, Brushes.Gray, 0, 290)

        Dim total_millar As String

        Dim total_boleta As Integer

        total_boleta = grilla_documento.CurrentRow.Cells(6).Value

        total_millar = total_boleta

        total_millar = Format(Int(total_millar), "###,###,###")

        e.Graphics.DrawString("TOTAL INGRESO", Font2, Brushes.Black, 100, 320)
        e.Graphics.DrawString(":", Font2, Brushes.Black, 200, 320)
        e.Graphics.DrawString(total_millar, Font2, Brushes.Black, 285, 320, format1)

        Dim rect8 As New Rectangle(10, 380, 270, 15)

        e.Graphics.DrawString("-", Font2, Brushes.Black, 135, 580)

    End Sub


    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If combo_documentos.Text = "" Then
            combo_documentos.Focus()
            MsgBox("CAMPO TIPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_nro_doc.Text = "" Then
            txt_nro_doc.Focus()
            MsgBox("CAMPO NUMERO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        grilla_documento.Rows.Clear()
        grilla_detalle_documento.Rows.Clear()
        grilla_letras.Rows.Clear()

        mostrar_malla()

        mostrar_malla_letras()
        mostrar_malla_convenio()
    End Sub














    Private Function ReturnDataSetAbonoTicket() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet




        dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ciudad_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

        dt.Columns.Add(New DataColumn("nro_abono", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_abono", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))

        dt.Columns.Add(New DataColumn("detalle_referencia", GetType(String)))
        dt.Columns.Add(New DataColumn("abono", GetType(Integer)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("total_abono", GetType(Integer)))

        dt.Columns.Add(New DataColumn("condicion_abono", GetType(String)))
        dt.Columns.Add(New DataColumn("detalle_condicion_abono", GetType(String)))
        dt.Columns.Add(New DataColumn("cajero_abono", GetType(String)))



        Dim nro_doc As String
        Dim tipo_doc As String
        Dim rut_doc As String
        Dim descuento_doc As String
        Dim neto_doc As String
        Dim iva_doc As String
        Dim total_doc As String
        Dim condicion_doc As String
        Dim estado_doc As String
        Dim fecha_doc As String
        Dim impresion_doc As String
        Dim usuario_doc As String

        nro_doc = grilla_documento.CurrentRow.Cells(0).Value
        tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        rut_doc = grilla_documento.CurrentRow.Cells(2).Value
        descuento_doc = grilla_documento.CurrentRow.Cells(3).Value
        neto_doc = grilla_documento.CurrentRow.Cells(4).Value
        iva_doc = grilla_documento.CurrentRow.Cells(5).Value
        total_doc = grilla_documento.CurrentRow.Cells(6).Value
        condicion_doc = grilla_documento.CurrentRow.Cells(7).Value
        estado_doc = grilla_documento.CurrentRow.Cells(8).Value
        fecha_doc = grilla_documento.CurrentRow.Cells(9).Value
        impresion_doc = grilla_documento.CurrentRow.Cells(10).Value
        usuario_doc = grilla_documento.CurrentRow.Cells(11).Value


        'Dim detalle_referencia As String
        'Dim detalle_abono As String
        'Dim detalle_saldo As String




        Dim nro_abono As String
        Dim fecha_abono As String
        Dim rut_abono As String
        Dim nombre_abono As String
        Dim total_abono As String
        Dim condicion_abono As String
        Dim detalle_condicion_abono As String
        Dim cajero_abono As String

        nro_abono = txt_n_abono.Text
        fecha_abono = Form_menu_principal.dtp_fecha.Text
        rut_abono = txt_rut.Text
        nombre_abono = txt_nombre_cliente.Text

        total_abono = Val(total_doc) - Val(txt_saldo.Text)

        condicion_abono = "CREDITO"
        detalle_condicion_abono = "ANULACION DE BOLETA " & txt_nro_doc.Text
        cajero_abono = minombre


        dr = dt.NewRow()

        Try
            dr("Imagen") = Imagen_ticket
        Catch
        End Try

        dr("nombre_empresa") = minombreempresa
        dr("giro_empresa") = migiroempresa
        dr("direccion_empresa") = midireccionempresa
        dr("ciudad_empresa") = micomunaempresa
        dr("telefono_empresa") = mitelefonoempresa
        dr("correo_empresa") = micorreoempresa
        dr("rut_empresa") = mirutempresa

        dr("nro_abono") = nro_abono
        dr("fecha_abono") = fecha_abono
        dr("nombre_cliente") = nombre_abono
        dr("rut_cliente") = rut_abono

        dr("detalle_referencia") = "-"
        dr("abono") = "0"
        dr("saldo") = "0"
        dr("total_abono") = total_abono


        dr("condicion_abono") = condicion_abono
        dr("detalle_condicion_abono") = detalle_condicion_abono
        dr("cajero_abono") = cajero_abono


        dt.Rows.Add(dr)



        ds.Tables.Add(dt)

        ds.Tables(0).TableName = "Abono"

        Dim iDS As New dsAbono
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS

    End Function


    Public Function ImageToByte(ByVal pImagen As Image) As Byte()
        Dim mImage() As Byte
        Try
            If Not IsNothing(pImagen) Then
                Dim ms As New System.IO.MemoryStream
                pImagen.Save(ms, pImagen.RawFormat)
                mImage = ms.GetBuffer
                ms.Close()
                Return mImage
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub grilla_detalle_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_detalle_documento.CellContentClick

    End Sub

    Private Sub grilla_detalle_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_detalle_documento.DoubleClick

        If grilla_detalle_documento.Rows.Count <> 0 Then
            If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
                If combo_documentos.Text = "FACTURA" Then
                    Dim nro_guia As String
                    nro_guia = grilla_detalle_documento.CurrentRow.Cells(0).Value

                    conexion.Close()
                    conexion.ConnectionString = "server=servidorarana441.dyndns.org; Database=basededatos; User Id=sistema_general;Password=1234; Convert Zero Datetime=True; default command timeout=3600"

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE `guia` SET `estado`='SIN FACTURAR' WHERE n_guia='" & (nro_guia) & "' and `cod_auto`<>'0';"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    conexion.Close()
                    conexion.ConnectionString = "server=servidorarana441.dyndns.org; Database=basededatos; User Id=sistema_general;Password=1234; Convert Zero Datetime=True; default command timeout=3600"

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE `guia` SET `estado`='SIN FACTURAR' WHERE n_guia='" & (nro_guia) & "' and `cod_auto`<>'0';"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    conexion.Close()
                    conexion.ConnectionString = "server=servidorarana441.dyndns.org; Database=basededatos; User Id=sistema_general;Password=1234; Convert Zero Datetime=True; default command timeout=3600"

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE `guia` SET `estado`='SIN FACTURAR' WHERE n_guia='" & (nro_guia) & "' and `cod_auto`<>'0';"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    Exit Sub
                End If
            End If
        End If

        'If grilla_detalle_documento.Rows.Count <> 0 Then

        '    Dim codigo_producto As String


        '    codigo_producto = grilla_detalle_documento.CurrentRow.Cells(0).Value

        '    If codigo_producto = "999999" Then
        '        cargar_cambio()
        '        Exit Sub
        '    End If
        'End If

    End Sub

    Sub quitar_facturacion_de_guias()
        Dim nro_guia As String

        For i = 0 To grilla_letras.Rows.Count - 1
            nro_guia = grilla_letras.Rows(i).Cells(0).Value.ToString

            conexion.Close()
            conexion.ConnectionString = "server=servidorarana441.dyndns.org; Database=basededatos; User Id=sistema_general;Password=1234; Convert Zero Datetime=True; default command timeout=3600"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `guia` SET `estado`='SIN FACTURAR' WHERE n_guia='" & (nro_guia) & "' and `cod_auto`<>'0';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            conexion.Close()
            conexion.ConnectionString = "server=servidorarana441.dyndns.org; Database=sucursal; User Id=sistema_general;Password=1234; Convert Zero Datetime=True; default command timeout=3600"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `guia` SET `estado`='SIN FACTURAR' WHERE n_guia='" & (nro_guia) & "' and `cod_auto`<>'0';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            conexion.Close()
            conexion.ConnectionString = "server=servidorarana452.dyndns.org; Database=basededatos; User Id=sistema_general;Password=1234; Convert Zero Datetime=True; default command timeout=3600"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `guia` SET `estado`='SIN FACTURAR' WHERE n_guia='" & (nro_guia) & "' and `cod_auto`<>'0';"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next
        recuperar_conexion()
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
                recinto = Trim(Replace(recinto, "'", "´"))

                If mirecintoempresa = recinto Then
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