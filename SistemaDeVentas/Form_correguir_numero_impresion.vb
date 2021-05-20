Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_CORREGIR_numero_impresion

    Private Sub Form_CORREGIR_numero_impresion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_CORREGIR_numero_impresion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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


    Private Sub Form_CORREGIR_numero_impresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtp1.CustomFormat = "yyy-MM-dd"
        cargar_logo()
        grilla_documento.Columns(0).Visible = False
        grilla_detalle_documento.Columns(0).Visible = False
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
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



    ' muestra los datos del cliente al cual se le emitio el  documento, atraves de una consulta sql.
    Sub mostrar_datos_clientes()
        Dim var_rut As String

        If grilla_documento.Rows.Count > 0 Then
            var_rut = grilla_documento.CurrentRow.Cells(2).Value

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (var_rut) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            End If
            conexion.Close()
        End If
    End Sub



    'muestra la informacion general en la grilla segun el numero que se seleccione previamente en el combobox de nombre numero.
    Sub mostrar_credito()
        'grilla_credito.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Columns.Clear()
        DT.Rows.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from BOLETA, usuarios where n_boleta ='" & (txt_nro_doc.Text) & "' and usuarios.rut_usuario= BOLETA.usuario_responsable and TIPO <> 'AJUSTE'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Dim cod_auto As String
            Dim n_boleta As String
            Dim TIPO As String
            Dim rut_cliente As String
            Dim descuento As String
            Dim neto As String
            Dim iva As String
            Dim total As String
            Dim condiciones As String
            Dim estado As String
            Dim nombre_usuario As String
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                cod_auto = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                n_boleta = DS.Tables(DT.TableName).Rows(i).Item("n_boleta")
                TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                descuento = DS.Tables(DT.TableName).Rows(i).Item("descuento")
                neto = DS.Tables(DT.TableName).Rows(i).Item("neto")
                iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
                total = DS.Tables(DT.TableName).Rows(i).Item("total")
                condiciones = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                nombre_usuario = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
                grilla_documento.Rows.Add(cod_auto, n_boleta, TIPO, rut_cliente, descuento, neto, iva, total, condiciones, estado, nombre_usuario)
            Next
        End If
        conexion.Close()
        grilla_documento.Columns(0).Visible = False
    End Sub







    'muestra la informacion general en la grilla segun el numero que se seleccione previamente en el combobox de nombre numero.
    Sub mostrar_malla()


        If combo_documentos.Text = "BOLETA" Then

            grilla_documento.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion

            SC.CommandText = "select * from BOLETA, usuarios where n_boleta ='" & (txt_nro_doc.Text) & "' and usuarios.rut_usuario= BOLETA.usuario_responsable and TIPO <> 'AJUSTE'"


            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim cod_auto As String
                Dim n_boleta As String
                Dim TIPO As String
                Dim rut_cliente As String
                Dim descuento As String
                Dim neto As String
                Dim iva As String
                Dim total As String
                Dim condiciones As String
                Dim estado As String
                Dim nombre_usuario As String

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    cod_auto = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                    n_boleta = DS.Tables(DT.TableName).Rows(i).Item("n_boleta")
                    TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                    descuento = DS.Tables(DT.TableName).Rows(i).Item("descuento")
                    neto = DS.Tables(DT.TableName).Rows(i).Item("neto")
                    iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
                    total = DS.Tables(DT.TableName).Rows(i).Item("total")
                    condiciones = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                    estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                    nombre_usuario = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")


                    'Dim codigo_folio_completo As String
                    'codigo_folio_completo = codigo_folio
                    'codigo_folio = String.Format("{0:000000}", codigo_folio_completo)

                    grilla_documento.Rows.Add(cod_auto, n_boleta, TIPO, rut_cliente, descuento, neto, iva, total, condiciones, estado, nombre_usuario)
                Next
            End If
            conexion.Close()
            grilla_documento.Columns(0).Visible = False
        End If



        If combo_documentos.Text = "FACTURA" Then

            grilla_documento.Rows.Clear()

            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion

            SC.CommandText = "select * from factura, usuarios where n_factura ='" & (txt_nro_doc.Text) & "' and usuarios.rut_usuario= factura.usuario_responsable and TIPO <> 'AJUSTE'"


            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim cod_auto As String
                Dim n_boleta As String
                Dim TIPO As String
                Dim rut_cliente As String
                Dim descuento As String
                Dim neto As String
                Dim iva As String
                Dim total As String
                Dim condiciones As String
                Dim estado As String
                Dim nombre_usuario As String

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    cod_auto = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                    n_boleta = DS.Tables(DT.TableName).Rows(i).Item("n_factura")
                    TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                    descuento = DS.Tables(DT.TableName).Rows(i).Item("descuento")
                    neto = DS.Tables(DT.TableName).Rows(i).Item("neto")
                    iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
                    total = DS.Tables(DT.TableName).Rows(i).Item("total")
                    condiciones = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                    estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                    nombre_usuario = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")


                    'Dim codigo_folio_completo As String
                    'codigo_folio_completo = codigo_folio
                    'codigo_folio = String.Format("{0:000000}", codigo_folio_completo)

                    grilla_documento.Rows.Add(cod_auto, n_boleta, TIPO, rut_cliente, descuento, neto, iva, total, condiciones, estado, nombre_usuario)
                Next
            End If
            conexion.Close()
            grilla_documento.Columns(0).Visible = False
        End If



        If combo_documentos.Text = "GUIA" Then
            conexion.Close()
            grilla_documento.Rows.Clear()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion

            SC.CommandText = "select * from guia, usuarios where n_guia ='" & (txt_nro_doc.Text) & "' and usuarios.rut_usuario= guia.usuario_responsable and TIPO <> 'AJUSTE'"


            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim cod_auto As String
                Dim n_boleta As String
                Dim TIPO As String
                Dim rut_cliente As String
                Dim descuento As String
                Dim neto As String
                Dim iva As String
                Dim total As String
                Dim condiciones As String
                Dim estado As String
                Dim nombre_usuario As String

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    cod_auto = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                    n_boleta = DS.Tables(DT.TableName).Rows(i).Item("n_guia")
                    TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                    descuento = DS.Tables(DT.TableName).Rows(i).Item("descuento")
                    neto = DS.Tables(DT.TableName).Rows(i).Item("neto")
                    iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
                    total = DS.Tables(DT.TableName).Rows(i).Item("total")
                    condiciones = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                    estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                    nombre_usuario = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")


                    'Dim codigo_folio_completo As String
                    'codigo_folio_completo = codigo_folio
                    'codigo_folio = String.Format("{0:000000}", codigo_folio_completo)

                    grilla_documento.Rows.Add(cod_auto, n_boleta, TIPO, rut_cliente, descuento, neto, iva, total, condiciones, estado, nombre_usuario)
                Next
            End If
        End If










        If combo_documentos.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            grilla_documento.Rows.Clear()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion

            SC.CommandText = "select * from nota_credito, usuarios where n_nota_credito ='" & (txt_nro_doc.Text) & "' and usuarios.rut_usuario= nota_credito.usuario_responsable and TIPO <> 'AJUSTE'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim cod_auto As String
                Dim n_nota_credito As String
                Dim TIPO As String
                Dim rut_cliente As String
                Dim descuento As String
                Dim neto As String
                Dim iva As String
                Dim total As String
                Dim condiciones As String
                Dim estado As String
                Dim nombre_usuario As String

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    cod_auto = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                    n_nota_credito = DS.Tables(DT.TableName).Rows(i).Item("n_nota_credito")
                    TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                    descuento = DS.Tables(DT.TableName).Rows(i).Item("descuento")
                    neto = DS.Tables(DT.TableName).Rows(i).Item("neto")
                    iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
                    total = DS.Tables(DT.TableName).Rows(i).Item("total")
                    condiciones = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                    estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                    nombre_usuario = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")


                    'Dim codigo_folio_completo As String
                    'codigo_folio_completo = codigo_folio
                    'codigo_folio = String.Format("{0:000000}", codigo_folio_completo)

                    grilla_documento.Rows.Add(cod_auto, n_nota_credito, TIPO, rut_cliente, descuento, neto, iva, total, condiciones, estado, nombre_usuario)
                Next
            End If

            conexion.Close()
        End If


        If combo_documentos.Text = "NOTA DE DEBITO" Then
            conexion.Close()
            grilla_documento.Rows.Clear()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion

            SC.CommandText = "select * from nota_debito, usuarios where n_nota_debito ='" & (txt_nro_doc.Text) & "' and usuarios.rut_usuario= nota_debito.usuario_responsable and TIPO <> 'AJUSTE'"


            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim cod_auto As String
                Dim n_nota_credito As String
                Dim TIPO As String
                Dim rut_cliente As String
                Dim descuento As String
                Dim neto As String
                Dim iva As String
                Dim total As String
                Dim condiciones As String
                Dim estado As String
                Dim nombre_usuario As String

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    cod_auto = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                    n_nota_credito = DS.Tables(DT.TableName).Rows(i).Item("n_nota_debito")
                    TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                    descuento = DS.Tables(DT.TableName).Rows(i).Item("descuento")
                    neto = DS.Tables(DT.TableName).Rows(i).Item("neto")
                    iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
                    total = DS.Tables(DT.TableName).Rows(i).Item("total")
                    condiciones = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                    estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                    nombre_usuario = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")


                    'Dim codigo_folio_completo As String
                    'codigo_folio_completo = codigo_folio
                    'codigo_folio = String.Format("{0:000000}", codigo_folio_completo)

                    grilla_documento.Rows.Add(cod_auto, n_nota_credito, TIPO, rut_cliente, descuento, neto, iva, total, condiciones, estado, nombre_usuario)
                Next
            End If

            conexion.Close()
        End If

        grilla_documento.Columns(0).Visible = False

















        If combo_documentos.Text = "COMPRA" Then

            grilla_documento.Rows.Clear()

            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion

            SC.CommandText = "select * from compra, usuarios where n_compra ='" & (txt_nro_doc.Text) & "' and usuarios.rut_usuario= compra.usuario_responsable and TIPO <> 'AJUSTE'"


            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim cod_auto As String
                Dim n_boleta As String
                Dim TIPO As String
                Dim rut_cliente As String
                Dim descuento As String
                Dim neto As String
                Dim iva As String
                Dim total As String
                Dim condiciones As String = ""
                Dim estado As String
                Dim nombre_usuario As String

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    cod_auto = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                    n_boleta = DS.Tables(DT.TableName).Rows(i).Item("n_compra")
                    TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor")
                    Try
                        descuento = DS.Tables(DT.TableName).Rows(i).Item("descuento")
                    Catch err As InvalidCastException
                        descuento = 0
                    End Try

                    neto = DS.Tables(DT.TableName).Rows(i).Item("neto")
                    iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
                    total = DS.Tables(DT.TableName).Rows(i).Item("total")

                    Try
                    Catch err As ArgumentException
                        condiciones = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                    End Try
                    estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                    nombre_usuario = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")


                    'Dim codigo_folio_completo As String
                    'codigo_folio_completo = codigo_folio
                    'codigo_folio = String.Format("{0:000000}", codigo_folio_completo)

                    grilla_documento.Rows.Add(cod_auto, n_boleta, TIPO, rut_cliente, descuento, neto, iva, total, condiciones, estado, nombre_usuario)
                Next
            End If
            conexion.Close()
            grilla_documento.Columns(0).Visible = False
        End If

    End Sub




























    Sub mostrar_malla_creditos()
        grilla_creditos.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Columns.Clear()
        DT.Rows.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from creditos, usuarios where n_creditos ='" & (txt_nro_doc.Text) & "' and tipo ='" & (combo_documentos.Text) & "' and usuarios.rut_usuario= creditos.usuario_responsable and TIPO <> 'AJUSTE'"
        'SC.CommandText = "select * from creditos, usuarios where tipo_detalle like '" & ("%" & txt_nro_doc.Text & "%") & "' and tipo_detalle like '" & ("%" & combo_documentos.Text & "%") & "' and usuarios.rut_usuario= creditos.usuario_responsable and TIPO <> 'AJUSTE'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Dim cod_auto As String
            Dim n_creditos As String
            Dim tipo As String
            Dim rut_cliente As String
            Dim descuento As String
            Dim neto As String
            Dim iva As String
            Dim total As String
            Dim condiciones As String
            Dim estado As String
            Dim nombre_usuario As String
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                cod_auto = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                n_creditos = DS.Tables(DT.TableName).Rows(i).Item("n_creditos")
                TIPO = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                descuento = DS.Tables(DT.TableName).Rows(i).Item("descuento")
                neto = DS.Tables(DT.TableName).Rows(i).Item("neto")
                iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
                total = DS.Tables(DT.TableName).Rows(i).Item("total")
                condiciones = DS.Tables(DT.TableName).Rows(i).Item("condiciones")
                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                nombre_usuario = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
                grilla_creditos.Rows.Add(cod_auto, n_creditos, tipo, rut_cliente, descuento, neto, iva, total, condiciones, estado, nombre_usuario)
            Next
        End If
        conexion.Close()
        grilla_creditos.Columns(0).Visible = False
    End Sub

    'muestra la informacion detallada del documento segun el numero seleccionado en el combobox numero.
    Sub mostrar_malla_detalle()
        Dim cod_detalle As String
        Dim cod_producto As String
        Dim detalle_nombre As String
        Dim valor_unitario As String
        Dim cantidad As String
        Dim detalle_Neto As String
        Dim detalle_iva As String
        Dim detalle_total As String

        If combo_documentos.Text = "BOLETA" Then
            conexion.Close()
            grilla_detalle_documento.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta  where  n_boleta = '" & (txt_nro_doc.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                cod_detalle = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                detalle_nombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                valor_unitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                detalle_Neto = DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto")
                detalle_iva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                detalle_total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                grilla_detalle_documento.Rows.Add(cod_detalle, cod_producto, detalle_nombre, valor_unitario, cantidad, detalle_Neto, detalle_iva, detalle_total)
            Next
            conexion.Close()
        End If

        If combo_documentos.Text = "VALE DE TRASLADO" Then
            conexion.Close()
            grilla_detalle_documento.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_total  where  n_total = '" & (txt_nro_doc.Text) & "' and TIPO='VALE DE TRASLADO' order by cod_producto"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                cod_detalle = DS.Tables(DT.TableName).Rows(i).Item("cod_detalle")
                cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                detalle_nombre = DS.Tables(DT.TableName).Rows(i).Item("nombre")
                valor_unitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                detalle_Neto = DS.Tables(DT.TableName).Rows(i).Item("neto")
                detalle_iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
                detalle_total = DS.Tables(DT.TableName).Rows(i).Item("total")
                grilla_detalle_documento.Rows.Add(cod_detalle, cod_producto, detalle_nombre, valor_unitario, cantidad, detalle_Neto, detalle_iva, detalle_total)
            Next
            conexion.Close()
        End If

        If combo_documentos.Text = "FACTURA" Then
            conexion.Close()
            grilla_detalle_documento.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura  where  n_factura = '" & (txt_nro_doc.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                cod_detalle = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                detalle_nombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                valor_unitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                detalle_Neto = DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto")
                detalle_iva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                detalle_total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                grilla_detalle_documento.Rows.Add(cod_detalle, cod_producto, detalle_nombre, valor_unitario, cantidad, detalle_Neto, detalle_iva, detalle_total)
            Next
            conexion.Close()
        End If

        If combo_documentos.Text = "GUIA" Then
            conexion.Close()
            grilla_detalle_documento.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_guia  where  n_guia = '" & (txt_nro_doc.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                cod_detalle = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                detalle_nombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                valor_unitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                detalle_Neto = DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto")
                detalle_iva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                detalle_total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                grilla_detalle_documento.Rows.Add(cod_detalle, cod_producto, detalle_nombre, valor_unitario, cantidad, detalle_Neto, detalle_iva, detalle_total)
            Next
            conexion.Close()
        End If

        If combo_documentos.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            grilla_detalle_documento.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_nota_credito  where  n_nota_credito = '" & (txt_nro_doc.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                cod_detalle = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                detalle_nombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                valor_unitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                detalle_Neto = DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto")
                detalle_iva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                detalle_total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                grilla_detalle_documento.Rows.Add(cod_detalle, cod_producto, detalle_nombre, valor_unitario, cantidad, detalle_Neto, detalle_iva, detalle_total)
            Next
            conexion.Close()
        End If

        If combo_documentos.Text = "NOTA DE DEBITO" Then
            conexion.Close()
            grilla_detalle_documento.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_nota_debito  where  n_nota_debito = '" & (txt_nro_doc.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                cod_detalle = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                detalle_nombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                valor_unitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                detalle_Neto = DS.Tables(DT.TableName).Rows(i).Item("detalle_Neto")
                detalle_iva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                detalle_total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                grilla_detalle_documento.Rows.Add(cod_detalle, cod_producto, detalle_nombre, valor_unitario, cantidad, detalle_Neto, detalle_iva, detalle_total)
            Next
            conexion.Close()
        End If


        grilla_detalle_documento.Columns(0).Visible = False
        grilla_detalle_documento.Columns(0).Visible = True

        If combo_documentos.Text = "COMPRA" Then
            conexion.Close()
            grilla_detalle_documento.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_compra  where  n_compra = '" & (txt_nro_doc.Text) & "' order by cod_producto"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                cod_detalle = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                detalle_nombre = DS.Tables(DT.TableName).Rows(i).Item("nombre")
                valor_unitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                detalle_Neto = DS.Tables(DT.TableName).Rows(i).Item("Neto")
                detalle_iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
                detalle_total = DS.Tables(DT.TableName).Rows(i).Item("total")
                grilla_detalle_documento.Rows.Add(cod_detalle, cod_producto, detalle_nombre, valor_unitario, cantidad, detalle_Neto, detalle_iva, detalle_total)
            Next
            conexion.Close()
        End If
    End Sub

    Sub mostrar_malla_detalle_kardex()
        'Dim cod_detalle As String
        'Dim cod_producto As String
        'Dim detalle_nombre As String
        'Dim valor_unitario As String
        'Dim cantidad As String
        'Dim detalle_Neto As String
        'Dim detalle_iva As String
        'Dim detalle_total As String

        'conexion.Close()
        'grilla_detalle_kardex.Rows.Clear()
        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Columns.Clear()
        'DT.Rows.Clear()
        'DS.Clear()
        'conexion.Open()
        'SC.Connection = conexion
        'SC.CommandText = "select * from detalle_total  where tipo like '" & ("%" & combo_documentos.Text & "%") & "' and n_total = '" & (txt_nro_doc.Text) & "'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '    cod_detalle = DS.Tables(DT.TableName).Rows(i).Item("cod_detalle")
        '    cod_producto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
        '    detalle_nombre = DS.Tables(DT.TableName).Rows(i).Item("nombre")
        '    valor_unitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
        '    cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
        '    detalle_Neto = DS.Tables(DT.TableName).Rows(i).Item("neto")
        '    detalle_iva = DS.Tables(DT.TableName).Rows(i).Item("iva")
        '    detalle_total = DS.Tables(DT.TableName).Rows(i).Item("total")
        '    grilla_detalle_kardex.Rows.Add(cod_detalle, cod_producto, detalle_nombre, valor_unitario, cantidad, detalle_Neto, detalle_iva, detalle_total)
        'Next
        'conexion.Close()
    End Sub

    'segun el valor que se seleccione en el combo documento se haran las sifuientes acciones:
    'se llama a el sub fecha.
    'se llena combo numero segun el valor seleccionado.
    'se limpian los datos anteriores de los clientes.
    'se limpia el lbl_datos, que indica cuando se selecciona BOLETAs que estas no graban informacion del cliente.
    'se cambia el estado del boton anular segun el TIPO de documento.
    Private Sub combo_documentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documentos.SelectedIndexChanged
        'txt_nro_doc.Enabled = True
        limpiar()
        txt_nro_doc.Focus()


    End Sub


    'codigo para salir de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    'redireccionamos a la pantalla de buscar documentos.
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        Form_documentos.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub




    Private Sub ACercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        Form_listado_documentos.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txt_nro_doc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.GotFocus
        txt_nro_doc.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.LostFocus
        txt_nro_doc.BackColor = Color.White
    End Sub


    Private Sub txt_nro_nuevo_doc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_nuevo_doc.GotFocus
        txt_nro_nuevo_doc.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_nuevo_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_nuevo_doc.KeyPress
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

    Private Sub txt_nro_nuevo_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_nuevo_doc.LostFocus
        txt_nro_nuevo_doc.BackColor = Color.White
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


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_mostrar.PerformClick()
        End If
    End Sub



    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub






    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub


    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.GotFocus
        btn_eliminar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.LostFocus
        btn_eliminar.BackColor = Color.Transparent
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

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Dim nro_doc As String
        Dim nro_doc_detalle As String
        ' nro_doc = grilla_documento.CurrentRow.Cells(0).Value

        'If grilla_documento.Rows.Count = 0 Then
        '    MsgBox("SELECCIONE UN DOCUMENTO", 0 + 16, "ERROR")
        '    Exit Sub
        'End If

        If grilla_detalle_documento.Rows.Count = 0 Then
            MsgBox("SELECCIONE UN DOCUMENTO", 0 + 16, "ERROR")
            Exit Sub
        End If


        lbl_mensaje.Visible = True
        Me.Enabled = False

        If combo_documentos.Text = "BOLETA" Then
            For i = 0 To grilla_documento.Rows.Count - 1
                nro_doc = grilla_documento.Rows(i).Cells(0).Value

                If grilla_documento.Rows(i).Cells(11).Value = True Then
                    SC.CommandText = "UPDATE BOLETA SET n_boleta='" & (txt_nro_nuevo_doc.Text) & "' where cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

                Dim condicion As String
                condicion = grilla_documento.Rows(i).Cells(8).Value
                Dim total As String
                total = grilla_documento.Rows(i).Cells(7).Value

                If condicion = "CREDITO" Then
                    SC.CommandText = "UPDATE  creditos SET n_creditos='" & (txt_nro_nuevo_doc.Text) & "', codigo_afecta='" & (txt_nro_nuevo_doc.Text) & "' where n_creditos='" & (txt_nro_doc.Text) & "' and codigo_afecta='" & (txt_nro_doc.Text) & "'and total='" & (total) & "' and TIPO='BOLETA'  and tipo_detalle='BOLETA' "
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next


            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                nro_doc_detalle = grilla_detalle_documento.Rows(i).Cells(0).Value

                If grilla_detalle_documento.Rows(i).Cells(8).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "update detalle_boleta set n_boleta = '" & (txt_nro_nuevo_doc.Text) & "' where cod_auto = '" & (nro_doc_detalle) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

        End If


        If combo_documentos.Text = "FACTURA" Then
            For i = 0 To grilla_documento.Rows.Count - 1
                nro_doc = grilla_documento.Rows(i).Cells(0).Value
                Dim condicion As String
                condicion = grilla_documento.Rows(i).Cells(8).Value
                Dim total As String
                total = grilla_documento.Rows(i).Cells(7).Value
                If grilla_documento.Rows(i).Cells(11).Value = True Then
                    SC.CommandText = "UPDATE factura SET n_factura='" & (txt_nro_nuevo_doc.Text) & "' where cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    If condicion = "CREDITO" Then
                        SC.CommandText = "UPDATE  creditos SET n_creditos='" & (txt_nro_nuevo_doc.Text) & "', codigo_afecta='" & (txt_nro_nuevo_doc.Text) & "' where n_creditos='" & (txt_nro_doc.Text) & "' and codigo_afecta='" & (txt_nro_doc.Text) & "'and total='" & (total) & "' and TIPO='FACTURA'  and tipo_detalle='FACTURA' "
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                    End If
                End If
            Next


            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                nro_doc_detalle = grilla_detalle_documento.Rows(i).Cells(0).Value

                If grilla_detalle_documento.Rows(i).Cells(8).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "update detalle_factura set n_factura = '" & (txt_nro_nuevo_doc.Text) & "' where cod_auto = '" & (nro_doc_detalle) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next


        End If


        If combo_documentos.Text = "GUIA" Then
            For i = 0 To grilla_documento.Rows.Count - 1
                nro_doc = grilla_documento.Rows(i).Cells(0).Value

                If grilla_documento.Rows(i).Cells(11).Value = True Then
                    SC.CommandText = "UPDATE guia SET n_guia='" & (txt_nro_nuevo_doc.Text) & "' where cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next


            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                nro_doc_detalle = grilla_detalle_documento.Rows(i).Cells(0).Value

                If grilla_detalle_documento.Rows(i).Cells(8).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "update detalle_guia set n_guia = '" & (txt_nro_nuevo_doc.Text) & "' where cod_auto = '" & (nro_doc_detalle) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next


        End If



        'For i = 0 To grilla_creditos.Rows.Count - 1
        '    nro_doc_detalle = grilla_creditos.Rows(i).Cells(0).Value

        '    If grilla_detalle_kardex.Rows(i).Cells(8).Value = True Then
        '        SC.Connection = conexion
        '        SC.CommandText = "update detalle_total set n_total = '" & (txt_nro_nuevo_doc.Text) & "' where cod_detalle = '" & (nro_doc_detalle) & "'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    End If
        'Next

        'For i = 0 To grilla_detalle_kardex.Rows.Count - 1
        '    nro_doc_detalle = grilla_detalle_kardex.Rows(i).Cells(0).Value

        '    If grilla_detalle_kardex.Rows(i).Cells(8).Value = True Then
        '        SC.Connection = conexion
        '        SC.CommandText = "update detalle_total set n_total = '" & (txt_nro_nuevo_doc.Text) & "' where cod_detalle = '" & (nro_doc_detalle) & "'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    End If
        'Next


        MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        grilla_documento.Rows.Clear()
        grilla_detalle_documento.Rows.Clear()
        grilla_creditos.Rows.Clear()
        'grilla_detalle_kardex.Rows.Clear()
        txt_nro_doc.Focus()

        lbl_mensaje.Visible = False
        Me.Enabled = True










    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If grilla_detalle_documento.Rows.Count = 0 And grilla_documento.Rows.Count = 0 And grilla_creditos.Rows.Count = 0 Then
            MsgBox("SELECCIONE UN DOCUMENTO", 0 + 16, "ERROR")
            Exit Sub
        End If

        'If grilla_detalle_documento.Rows.Count = 0 Then
        '    MsgBox("SELECCIONE UN DOCUMENTO", 0 + 16, "ERROR")
        '    Exit Sub
        'End If


        If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
            MsgBox("SOLO UN ADMINISTRADOR DE SISTEMA PUEDE ELIMINAR DOCUMENTOS", 0 + 16, "ERROR")
            Exit Sub
        End If


        Form_motivo_eliminacion_de_documento.Show()
        Me.Enabled = False
    End Sub

    Sub eliminar()
        Dim nro_doc As String
        Dim nro_doc_detalle As String
        Dim VarCantidad As Integer
        Dim VarCodProducto As String
        Dim tipo_doc As String

        lbl_mensaje.Visible = True
        Me.Enabled = False

        If combo_documentos.Text = "VALE DE TRASLADO" Then
            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                nro_doc_detalle = grilla_detalle_documento.Rows(i).Cells(0).Value
                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value
                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(1).Value
                If grilla_detalle_documento.Rows(i).Cells(8).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM `detalle_total` WHERE TIPO ='VALE DE TRASLADO' and n_total = '" & (txt_nro_doc.Text) & "' and cod_detalle='" & (nro_doc_detalle) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad - " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next
        End If



        If combo_documentos.Text = "BOLETA" Then
            For i = 0 To grilla_documento.Rows.Count - 1
                nro_doc = grilla_documento.Rows(i).Cells(0).Value
                If grilla_documento.Rows(i).Cells(11).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM BOLETA WHERE cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            For i = 0 To grilla_creditos.Rows.Count - 1
                nro_doc = grilla_creditos.Rows(i).Cells(0).Value
                If grilla_creditos.Rows(i).Cells(11).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM creditos WHERE cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                nro_doc_detalle = grilla_detalle_documento.Rows(i).Cells(0).Value
                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value
                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(1).Value
                If grilla_detalle_documento.Rows(i).Cells(8).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM detalle_boleta WHERE cod_auto='" & (nro_doc_detalle) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad + " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            'For i = 0 To grilla_detalle_kardex.Rows.Count - 1
            '    nro_doc_detalle = grilla_detalle_kardex.Rows(i).Cells(0).Value
            '    VarCantidad = grilla_detalle_kardex.Rows(i).Cells(4).Value
            '    VarCodProducto = grilla_detalle_kardex.Rows(i).Cells(1).Value
            '    If grilla_detalle_kardex.Rows(i).Cells(8).Value = True Then
            '        SC.Connection = conexion
            '        SC.CommandText = "DELETE FROM detalle_total WHERE cod_detalle='" & (nro_doc_detalle) & "'"
            '        DA.SelectCommand = SC
            '        DA.Fill(DT)
            '    End If
            'Next
        End If

        If combo_documentos.Text = "GUIA" Then
            For i = 0 To grilla_documento.Rows.Count - 1
                nro_doc = grilla_documento.Rows(i).Cells(0).Value
                If grilla_documento.Rows(i).Cells(11).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM guia WHERE cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                nro_doc_detalle = grilla_detalle_documento.Rows(i).Cells(0).Value
                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value
                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(1).Value
                If grilla_detalle_documento.Rows(i).Cells(8).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM detalle_guia WHERE cod_auto='" & (nro_doc_detalle) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad + " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            'For i = 0 To grilla_detalle_kardex.Rows.Count - 1
            '    nro_doc_detalle = grilla_detalle_kardex.Rows(i).Cells(0).Value
            '    VarCantidad = grilla_detalle_kardex.Rows(i).Cells(4).Value
            '    VarCodProducto = grilla_detalle_kardex.Rows(i).Cells(1).Value
            '    If grilla_detalle_kardex.Rows(i).Cells(8).Value = True Then
            '        SC.Connection = conexion
            '        SC.CommandText = "DELETE FROM detalle_total WHERE cod_detalle='" & (nro_doc_detalle) & "'"
            '        DA.SelectCommand = SC
            '        DA.Fill(DT)
            '    End If
            'Next
        End If

        If combo_documentos.Text = "FACTURA" Then
            For i = 0 To grilla_documento.Rows.Count - 1
                nro_doc = grilla_documento.Rows(i).Cells(0).Value
                If grilla_documento.Rows(i).Cells(11).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM factura WHERE cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            For i = 0 To grilla_creditos.Rows.Count - 1
                nro_doc = grilla_creditos.Rows(i).Cells(0).Value
                If grilla_creditos.Rows(i).Cells(11).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM creditos WHERE cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                nro_doc_detalle = grilla_detalle_documento.Rows(i).Cells(0).Value
                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value
                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(1).Value
                If grilla_detalle_documento.Rows(i).Cells(8).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM detalle_factura WHERE cod_auto='" & (nro_doc_detalle) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad + " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            'For i = 0 To grilla_detalle_kardex.Rows.Count - 1
            '    nro_doc_detalle = grilla_detalle_kardex.Rows(i).Cells(0).Value
            '    VarCantidad = grilla_detalle_kardex.Rows(i).Cells(4).Value
            '    VarCodProducto = grilla_detalle_kardex.Rows(i).Cells(1).Value
            '    If grilla_detalle_kardex.Rows(i).Cells(8).Value = True Then
            '        SC.Connection = conexion
            '        SC.CommandText = "DELETE FROM detalle_total WHERE cod_detalle='" & (nro_doc_detalle) & "'"
            '        DA.SelectCommand = SC
            '        DA.Fill(DT)
            '    End If
            'Next
        End If

        If combo_documentos.Text = "NOTA DE DEBITO" Then
            For i = 0 To grilla_documento.Rows.Count - 1
                nro_doc = grilla_documento.Rows(i).Cells(0).Value
                If grilla_documento.Rows(i).Cells(11).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM nota_debito WHERE cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            For i = 0 To grilla_creditos.Rows.Count - 1
                nro_doc = grilla_creditos.Rows(i).Cells(0).Value
                If grilla_creditos.Rows(i).Cells(11).Value = True Then
                    SC.CommandText = "DELETE FROM creditos WHERE cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                nro_doc_detalle = grilla_detalle_documento.Rows(i).Cells(0).Value
                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value
                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(1).Value
                If grilla_detalle_documento.Rows(i).Cells(8).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM detalle_nota_debito WHERE cod_auto='" & (nro_doc_detalle) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad + " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            'For i = 0 To grilla_detalle_kardex.Rows.Count - 1
            '    nro_doc_detalle = grilla_detalle_kardex.Rows(i).Cells(0).Value
            '    VarCantidad = grilla_detalle_kardex.Rows(i).Cells(4).Value
            '    VarCodProducto = grilla_detalle_kardex.Rows(i).Cells(1).Value
            '    If grilla_detalle_kardex.Rows(i).Cells(8).Value = True Then
            '        SC.Connection = conexion
            '        SC.CommandText = "DELETE FROM detalle_total WHERE cod_detalle='" & (nro_doc_detalle) & "'"
            '        DA.SelectCommand = SC
            '        DA.Fill(DT)
            '    End If
            'Next
        End If

        If combo_documentos.Text = "NOTA DE CREDITO" Then
            For i = 0 To grilla_documento.Rows.Count - 1
                nro_doc = grilla_documento.Rows(i).Cells(0).Value
                If grilla_documento.Rows(i).Cells(11).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM nota_credito WHERE cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            For i = 0 To grilla_creditos.Rows.Count - 1
                nro_doc = grilla_creditos.Rows(i).Cells(0).Value
                If grilla_creditos.Rows(i).Cells(11).Value = True Then
                    SC.CommandText = "DELETE FROM creditos WHERE cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                nro_doc_detalle = grilla_detalle_documento.Rows(i).Cells(0).Value
                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value
                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(1).Value
                If grilla_detalle_documento.Rows(i).Cells(8).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM detalle_nota_credito WHERE cod_auto='" & (nro_doc_detalle) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad - " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next

            'For i = 0 To grilla_detalle_kardex.Rows.Count - 1
            '    nro_doc_detalle = grilla_detalle_kardex.Rows(i).Cells(0).Value
            '    VarCantidad = grilla_detalle_kardex.Rows(i).Cells(4).Value
            '    VarCodProducto = grilla_detalle_kardex.Rows(i).Cells(1).Value
            '    If grilla_detalle_kardex.Rows(i).Cells(8).Value = True Then
            '        SC.Connection = conexion
            '        SC.CommandText = "DELETE FROM detalle_total WHERE cod_detalle='" & (nro_doc_detalle) & "'"
            '        DA.SelectCommand = SC
            '        DA.Fill(DT)
            '    End If
            'Next
        End If











        If combo_documentos.Text = "COMPRA" Then
            For i = 0 To grilla_documento.Rows.Count - 1
                nro_doc = grilla_documento.Rows(i).Cells(0).Value
                tipo_doc = grilla_documento.Rows(i).Cells(2).Value

                If grilla_documento.Rows(i).Cells(11).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM compra WHERE cod_auto='" & (nro_doc) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    'SC.Connection = conexion
                    'SC.CommandText = "DELETE FROM detalle_total WHERE movimiento ='ENTRA' and TIPO ='" & (tipo_doc) & "' and n_total = '" & (txt_nro_doc.Text) & "' and cod_detalle <> '0'"
                    'DA.SelectCommand = SC
                    'DA.Fill(DT)
                End If
            Next

            For i = 0 To grilla_detalle_documento.Rows.Count - 1
                nro_doc_detalle = grilla_detalle_documento.Rows(i).Cells(0).Value
                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value
                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(1).Value
                If grilla_detalle_documento.Rows(i).Cells(8).Value = True Then
                    SC.Connection = conexion
                    SC.CommandText = "DELETE FROM detalle_compra WHERE cod_auto='" & (nro_doc_detalle) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "update productos set cantidad = cantidad - " & (VarCantidad) & " where cod_producto = '" & (VarCodProducto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    'SC.Connection = conexion
                    'SC.CommandText = "DELETE FROM detalle_total WHERE movimiento ='ENTRA' and TIPO ='" & (tipo_doc) & "' and n_total = '" & (txt_nro_doc.Text) & "' and cod_detalle <> '0'"
                    'DA.SelectCommand = SC
                    'DA.Fill(DT)
                End If
            Next
        End If












        lbl_mensaje.Visible = False
        Me.Enabled = True

        MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        grilla_documento.Rows.Clear()
        grilla_detalle_documento.Rows.Clear()
        txt_nro_doc.Focus()
    End Sub

    Private Sub txt_nro_nuevo_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_nuevo_doc.TextChanged

    End Sub

    Private Sub combo_documentos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documentos.GotFocus
        combo_documentos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_documentos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documentos.LostFocus
        combo_documentos.BackColor = Color.White
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





        lbl_mensaje.Visible = True
        Me.Enabled = False

        mostrar_malla()
        mostrar_malla_detalle()
        mostrar_malla_creditos()
        mostrar_datos_clientes()
        mostrar_malla_detalle_kardex()
        txt_nro_nuevo_doc.Focus()

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub
End Class