Imports System.Data.OleDb
Imports System.IO

Public Class Form_excel

    Private Sub Form_excel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_excel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
            '    form_Menu_admin.Enabled = False
            Form_menu_principal.Close()

        End If
    End Sub

    Private Sub Form_excel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        If miusuario <> "16972940-9" Then
            If mirutempresa = "87686300-6" Then

                combo_tipo.Items.Clear()
                combo_tipo.Items.Add("CREAR FAMILIA")
                combo_tipo.Items.Add("CREAR SUBFAMILIA")
                combo_tipo.Items.Add("CREAR SUBFAMILIA 2")
                combo_tipo.Items.Add("ACTUALIZAR SUBFAMILIA M")
                combo_tipo.Items.Add("ACTUALIZAR SUBFAMILIA O")
                combo_tipo.Items.Add("ACTUALIZAR SUBFAMILIA 2")
                combo_tipo.Items.Add("ACTUALIZAR PRECIO")
                combo_tipo.Items.Add("INGRESAR PEDIDO")
                combo_tipo.Items.Add("CAMBIAR ESTADO DE GUIAS")
                combo_tipo.Items.Add("INGRESAR CLIENTES COPEUCH")
            End If
        End If

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

    Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oFD As New OpenFileDialog
        With oFD
            ' .Filter = "Ficheros DBF (*.dbf)|*.dbf|Todos (*.*)|*.*"
            .FileName = txtFic.Text
            If .ShowDialog = DialogResult.OK Then
                txtFic.Text = .FileName
                ' El nombre del fichero
                txtSelect.Text = System.IO.Path.GetFileNameWithoutExtension(txtFic.Text)
                ' btnAbrir_Click(Nothing, Nothing)
            End If
        End With
    End Sub






    Sub Cargar( _
        ByVal dgView As DataGridView, _
        ByVal SLibro As String, _
        ByVal sHoja As String)

        'HDR=YES : Con encabezado  
        Dim cs As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                           "Data Source=" & SLibro & ";" & _
                           "Extended Properties=""Excel 8.0;HDR=YES"""
        Try
            ' cadena de conexión  
            Dim cn As New OleDbConnection(cs)

            If Not System.IO.File.Exists(SLibro) Then
                MsgBox("No se encontró el Libro: " & _
                        SLibro, MsgBoxStyle.Critical, _
                        "Ruta inválida")
                Exit Sub
            End If

            ' se conecta con la hoja sheet 1  
            Dim dAdapter As New OleDbDataAdapter("Select * From [" & sHoja & "$]", cs)

            Dim datos As New DataSet

            ' agrega los datos  
            dAdapter.Fill(datos)

            With grilla_excel
                ' llena el DataGridView  
                .DataSource = datos.Tables(0)

                ' DefaultCellStyle: formato currency   
                'para los encabezados 1,2 y 3 del DataGrid  
                .Columns(1).DefaultCellStyle.Format = "c"
                .Columns(2).DefaultCellStyle.Format = "c"
                .Columns(3).DefaultCellStyle.Format = "c"
            End With
        Catch oMsg As Exception
            MsgBox(oMsg.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        If combo_tipo.Text = "-" Then
            combo_tipo.Focus()
            MsgBox("CAMPO TIPO ARCHIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If combo_tipo.Text = "" Then
            combo_tipo.Focus()
            MsgBox("CAMPO TIPO ARCHIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        grilla_excel.Columns.Clear()
        grilla_excel.DataSource = Nothing
        txt_item.Text = ""
        txtFic.Text = ""
        txtSelect.Text = ""

        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                stRuta = .FileName
            End If
        End With


        Try
            Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (stRuta & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";"))) 'este es el codigo que funciona para office 2007 y 2010 
            Dim cnConex As New OleDbConnection(stConexion)
            Dim Cmd As New OleDbCommand("Select * From [Hoja1$]")
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable
            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)
            Me.grilla_excel.Columns.Clear()
            Me.grilla_excel.DataSource = Dt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        txt_item.Text = grilla_excel.Rows.Count
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If combo_tipo.Text = "-" Then
            combo_tipo.Focus()
            MsgBox("CAMPO TIPO ARCHIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If combo_tipo.Text = "" Then
            combo_tipo.Focus()
            MsgBox("CAMPO TIPO ARCHIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If grilla_excel.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_tipo.Focus()
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim cod_producto As String
        Dim cantidad As String
        Dim estado As String





        Dim nombre As String
        Dim marca As String
        Dim aplicacion As String

        Dim precio As String
        Dim costo As String
        Dim factor As String
        Dim numero_tecnico As String
        Dim proveedor As String
        Dim familia As String
        Dim subfamilia As String
        Dim subfamilia_dos As String
        Dim ultima_compra As String
        Dim cantidad_ultima_compra As String
        Dim tipo_doc As String
        Dim nro_doc As String

        Dim cod_cliente As String
        Dim rut_cliente As String
        Dim rut_retira As String
        Dim nombre_retira As String
        Dim codigo_barra As String
        Dim codigo_familia As String
        Dim codigo_subfamilia As String
        Dim M As String
        Dim O As String



        Dim rut_proveedor As String
        'Dim nombre_proveedor As String
        Dim fecha As String
        'Dim codigo_interno As String
        'Dim codigo_barra As String
        'Dim marca As String
        'Dim nombre As String
        'Dim numero_tecnico As String
        'Dim aplicacion As String
        'Dim nombre_familia As String
        'Dim costo As String
        'Dim precio As String
        'Dim precio_venta_sugerido As String
        ' Dim margen_1 As String
        'Dim margen_2 As String
        'Dim margen_3 As String
        'Dim margen_4 As String
        'Dim margen_5 As String
        'Dim maestra As String
        Dim codigo_pedido As Integer
        Dim varcodpedido As Integer
        Dim fecha_llegada_pedido As Date
        Dim nombre_fantasia_proveedor As String
        'Dim saldo_cliente As String
        codigo_pedido = 1

        Dim fecha_lleg_pedido As String
        Dim volumen As String

        If combo_tipo.Text = "VOLUMEN" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                codigo_subfamilia = grilla_excel.Rows(i).Cells(0).Value.ToString
                volumen = grilla_excel.Rows(i).Cells(1).Value.ToString

                'conexion.Close()
                'Consultas_SQL("select * from subfamilia_dos where codigo_subfamilia = '" & (codigo_subfamilia) & "' AND  o = '" & (O) & "' ")
                'If DS.Tables(DT.TableName).Rows.Count > 0 Then

                'Else
                SC.Connection = conexion
                SC.CommandText = "UPDATE subfamilia_dos SET `volumen`='" & (volumen) & "' WHERE `cod_auto`='" & (codigo_subfamilia) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE SUBFAMILIA O','" & (codigo_subfamilia) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
                'End If
            Next
        End If


        If combo_tipo.Text = "ACTUALIZAR PRECIO" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                precio = grilla_excel.Rows(i).Cells(1).Value.ToString


                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET precio='" & (precio) & "', fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "', activo='SI' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                'If precio <> 0 Then
                '    SC.Connection = conexion
                '    SC.CommandText = "UPDATE productos SET activo='SI' WHERE cod_producto = '" & (cod_producto) & "'"
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)
                'End If


                'crear_nro_ajuste()

                'SC.Connection = conexion
                'SC.CommandText = "insert into  detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (cod_producto) & "','" & (nombre) & "'," & (precio) & "," & (cantidad) & ",'0','0','0','0','0','ENTRA', '" & (Form_menu_principal.dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "insert into  detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (cod_producto) & "','" & (nombre) & "'," & (precio) & "," & (cantidad) & ",'0','0','0','0','0','AJUSTE', '" & (form_Menu_admin.dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)



            Next


            lbl_mensaje.Visible = False
            Me.Enabled = True

            MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            Exit Sub

        End If



        If combo_tipo.Text = "ACTUALIZAR NOMBRE FANTASIA PROVEEDOR" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                rut_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                nombre_fantasia_proveedor = grilla_excel.Rows(i).Cells(1).Value.ToString

                SC.Connection = conexion
                SC.CommandText = "UPDATE proveedores SET nombre_fantasia_proveedor='" & (nombre_fantasia_proveedor) & "' WHERE `rut_proveedor`='" & (rut_proveedor) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next
        End If

        If combo_tipo.Text = "ELIMINAR SUBFAMILIAS" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                codigo_subfamilia = grilla_excel.Rows(i).Cells(0).Value.ToString

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM `subfamilia` WHERE `cod_auto`='" & (codigo_subfamilia) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM `subfamilia_dos` WHERE `codigo_subfamilia`='" & (codigo_subfamilia) & "' and cod_auto <> '0'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If

        If combo_tipo.Text = "ELIMINAR SUBFAMILIAS DOS" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                codigo_subfamilia = grilla_excel.Rows(i).Cells(0).Value.ToString

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM `subfamilia_dos` WHERE `cod_auto`='" & (codigo_subfamilia) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If

        If combo_tipo.Text = "ACTUALIZAR CUPO" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                'rut_cliente = grilla_excel.Rows(i).Cells(0).Value.ToString
                'cupo = grilla_excel.Rows(i).Cells(1).Value.ToString

                'conexion.Close()
                'DS3.Tables.Clear()
                'DT3.Rows.Clear()
                'DT3.Columns.Clear()
                'DS3.Clear()
                'conexion.Open()
                'Try
                '    SC3.Connection = conexion
                '    SC3.CommandText = "select sum(saldo) as saldo from creditos  where saldo <> '0' and rut_cliente='" & (rut_cliente) & "'"
                '    DA3.SelectCommand = SC3
                '    DA3.Fill(DT3)
                '    DS3.Tables.Add(DT3)

                '    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                '        saldo_cliente = DS3.Tables(DT3.TableName).Rows(0).Item("saldo")
                '    End If
                'Catch err As InvalidCastException
                '    saldo_cliente = 0
                'End Try
                'conexion.Close()

                'SC.Connection = conexion
                'SC.CommandText = " UPDATE `clientes` SET `cupo_cliente`='" & (cupo) & "',`saldo_cliente`='" & (saldo_cliente) & "', `fecha_modificacion`='2019-03-22' WHERE rut_cliente='" & (rut_cliente) & "' and `cod_auto`<>'0';"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

            Next
        End If

        If combo_tipo.Text = "1" Then

            lbl_mensaje.Visible = True
            Me.Enabled = False


            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(1).Value.ToString
                precio = grilla_excel.Rows(i).Cells(2).Value.ToString
                familia = grilla_excel.Rows(i).Cells(3).Value.ToString

                nombre = UCase(nombre)

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "INSERT INTO `basededatos`.`productos` (`cod_producto`, `nombre`, `precio`, `familia`) VALUES ('" & (cod_producto) & "', '" & (nombre) & "', '" & (precio) & "', '" & (familia) & "');"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next
        End If



        If combo_tipo.Text = "INGRESAR MEDIDAS SUBFAMILIAS 2" Then






            lbl_mensaje.Visible = True
            Me.Enabled = False

            Dim m1 As String
            Dim m2 As String
            Dim m3 As String
            For i = 0 To grilla_excel.Rows.Count - 1
                codigo_subfamilia = grilla_excel.Rows(i).Cells(0).Value.ToString
                m1 = grilla_excel.Rows(i).Cells(1).Value.ToString
                m2 = grilla_excel.Rows(i).Cells(2).Value.ToString
                m3 = grilla_excel.Rows(i).Cells(3).Value.ToString

                SC.Connection = conexion
                SC.CommandText = "UPDATE `subfamilia_dos` SET `medida_1`='" & (m1) & "', `medida_2`='" & (m2) & "', `medida_3`='" & (m3) & "' WHERE `cod_auto`='" & (codigo_subfamilia) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next
        End If



        If combo_tipo.Text = "INGRESAR CLIENTES COPEUCH" Then






            lbl_mensaje.Visible = True
            Me.Enabled = False

            Dim apellido_materno As String
            Dim apellido_paterno As String

            For i = 0 To grilla_excel.Rows.Count - 1
                rut_cliente = grilla_excel.Rows(i).Cells(0).Value.ToString & "-" & grilla_excel.Rows(i).Cells(1).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(2).Value.ToString & " " & grilla_excel.Rows(i).Cells(3).Value.ToString & " " & grilla_excel.Rows(i).Cells(4).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(2).Value.ToString & " " & grilla_excel.Rows(i).Cells(3).Value.ToString & " " & grilla_excel.Rows(i).Cells(4).Value.ToString

                nombre = grilla_excel.Rows(i).Cells(2).Value.ToString & " " & grilla_excel.Rows(i).Cells(3).Value.ToString & " " & grilla_excel.Rows(i).Cells(4).Value.ToString

                apellido_paterno = grilla_excel.Rows(i).Cells(2).Value.ToString
                apellido_paterno = apellido_paterno.Replace(" "c, String.Empty)

                apellido_materno = grilla_excel.Rows(i).Cells(3).Value.ToString
                apellido_materno = apellido_materno.Replace(" "c, String.Empty)

                nombre = grilla_excel.Rows(i).Cells(4).Value.ToString
                nombre = nombre.Replace(" "c, String.Empty)

                nombre = apellido_paterno & " " & apellido_materno & " " & nombre

                'cadena = cadena.Replace(" "c, String.Empty)

                conexion.Close()
                Consultas_SQL("select * from clientes_copeuch where rut_cliente = '" & (rut_cliente) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Else

                    crear_codigo_cliente()

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO clientes_copeuch (cod_cliente, tipo_cliente, Rut_cliente, nombre_cliente, direccion_cliente, telefono_cliente, EMAIL_CLIENTE, comuna_cliente, giro_cliente, DESCUENTO_1, CIUDAD_CLIENTE, DESCUENTO_2, FOLIO_CLIENTE, ESTADO_CUENTA, cuenta_cliente, tipo_cuenta, orden_de_compra, mensaje, cupo_cliente, saldo_cliente, fecha_modificacion, ACTIVO) VALUES  ('" & (txt_codigo_cliente.Text) & "','" & ("PERSONA") & "','" & (rut_cliente) & "','" & (nombre) & "','" & ("-") & "','" & ("-") & "','" & ("-") & "','" & ("-") & "','" & ("COPEUCH") & "','" & ("12") & "','" & ("-") & "','" & ("0") & "','" & ("-") & "','" & ("SIN CUENTA") & "', 'NO', '-', 'NO', 'SIN MENSAJE','0','0','" & (Form_menu_principal.dtp_fecha.Text) & "','" & ("SI") & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

            Next
        End If







        'Dim n_letra As String
        'Dim tipo As String
        'Dim tipo_detalle As String
        'Dim n_boleta As String

        'If combo_tipo.Text = "ACTUALIZAR LETRA" Then



        '    For i = 0 To grilla_excel.Rows.Count - 1
        '        'codigo_pedido = grilla_excel.Rows(i).Cells(0).Value.ToString
        '        n_letra = grilla_excel.Rows(i).Cells(0).Value.ToString
        '        tipo = grilla_excel.Rows(i).Cells(1).Value.ToString
        '        tipo_detalle = grilla_excel.Rows(i).Cells(2).Value.ToString
        '        fecha = grilla_excel.Rows(i).Cells(3).Value.ToString

        '        Dim mifecha As Date
        '        mifecha = fecha
        '        fecha = mifecha.ToString("yyy-MM-dd")



        '        Dim cadena As String
        '        Dim tabla() As String
        '        Dim n As Integer


        '        cadena = tipo_detalle

        '        tabla = Split(cadena, " ")
        '        For n = 0 To UBound(tabla, 1)
        '            n_boleta = tabla(1)
        '        Next
        '        '" & (nombre) & "'
        '        SC.Connection = conexion
        '        SC.CommandText = "UPDATE `letras` SET `nro_referencia`='" & (n_boleta) & "' WHERE `n_letra`='" & (n_letra) & "' and `cod_auto`<>'0';"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Next
        'End If



        If combo_tipo.Text = "AGREGAR TIPO EMISION A COMPRAS" Then
            Dim tipo_emision As String = ""
            Dim fecha_doc As String = ""

            For i = 0 To grilla_excel.Rows.Count - 1
                rut_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                tipo_documento = grilla_excel.Rows(i).Cells(1).Value.ToString
                nro_doc = grilla_excel.Rows(i).Cells(3).Value.ToString
                tipo_emision = grilla_excel.Rows(i).Cells(2).Value.ToString
                fecha_doc = grilla_excel.Rows(i).Cells(4).Value.ToString

                Dim mifecha As Date
                mifecha = fecha_doc
                fecha_doc = mifecha.ToString("yyy-MM-dd")

                SC.Connection = conexion
                SC.CommandText = "UPDATE `compra` SET `tipo_emision`='" & (tipo_emision) & "' WHERE `rut_proveedor`='" & (rut_proveedor) & "' and `tipo`='" & (tipo_documento) & "' and `n_compra`='" & (nro_doc) & "'  and `fecha_emision`='" & (fecha_doc) & "' and `codigo_compra`<>'0';"
                DA.SelectCommand = SC
                DA.Fill(DT)


            Next

        End If

        If combo_tipo.Text = "CAMBIAR ESTADO DE GUIAS" Then






            Dim nro_guia As String

            For i = 0 To grilla_excel.Rows.Count - 1
                nro_guia = grilla_excel.Rows(i).Cells(0).Value.ToString

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

        End If




        If combo_tipo.Text = "INGRESAR PEDIDO" Then


            Dim mifecha As Date
            mifecha = Form_menu_principal.dtp_fecha.Text
            fecha = mifecha.ToString("yyy-MM-dd")
            fecha_llegada_pedido = mifecha.AddDays(1)

            fecha_lleg_pedido = fecha_llegada_pedido.ToString("yyy-MM-dd")

            For i = 0 To grilla_excel.Rows.Count - 1
                'codigo_pedido = grilla_excel.Rows(i).Cells(0).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(0).Value.ToString
                proveedor = grilla_excel.Rows(i).Cells(1).Value.ToString
                cantidad = grilla_excel.Rows(i).Cells(2).Value.ToString



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
                        varcodpedido = varcodpedido + 1
                    End If
                Catch err As InvalidCastException
                    varcodpedido = 1
                End Try
                conexion.Close()

                SC.Connection = conexion
                SC.CommandText = "insert into pedido (codigo_pedido, rut_cliente, nombre_cliente, telefono_cliente, abono, fecha_pedido, usuario_responsable, hora) values('" & (varcodpedido) & "', '-','-','-', '0', '" & (fecha) & "','" & (miusuario) & "', '" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "INSERT INTO `detalle_pedido` (`codigo_producto`, `proveedor`, `cantidad`, `descripcion`, `comentario`, `estado`, `prioridad`, `codigo_pedido`, `fecha_llegada`, usuario_responsable, hora) VALUES ('" & (codigo_pedido) & "', '" & (proveedor) & "', '" & (cantidad) & "', '" & (nombre) & "', '-', 'EN ESPERA', 'REPOSICION', '" & (varcodpedido) & "', '" & (fecha_lleg_pedido) & "', '" & (miusuario) & "', '" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                codigo_pedido = codigo_pedido + 1
            Next
        End If





        If combo_tipo.Text = "ACTUALIZAR SUBFAMILIA M" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                codigo_subfamilia = grilla_excel.Rows(i).Cells(0).Value.ToString
                M = grilla_excel.Rows(i).Cells(1).Value.ToString

                'conexion.Close()
                'Consultas_SQL("select * from subfamilia_dos where codigo_subfamilia = '" & (codigo_subfamilia) & "' AND  m = '" & (M) & "' ")
                'If DS.Tables(DT.TableName).Rows.Count > 0 Then

                'Else
                'subfamilia_dos = UCase(subfamilia_dos)
                'SC.CommandText = "INSERT INTO subfamilia_dos(codigo_subfamilia, nombre_subfamilia) VALUES ('" & (codigo_subfamilia) & "','" & (subfamilia_dos) & "')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "UPDATE subfamilia_dos SET `m`='" & (M) & "' WHERE `cod_auto`='" & (codigo_subfamilia) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)


                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE SUBFAMILIA M','" & (codigo_subfamilia) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
                ' End If
            Next
        End If


        If combo_tipo.Text = "ACTUALIZAR SUBFAMILIA O" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                codigo_subfamilia = grilla_excel.Rows(i).Cells(0).Value.ToString
                O = grilla_excel.Rows(i).Cells(1).Value.ToString

                'conexion.Close()
                'Consultas_SQL("select * from subfamilia_dos where codigo_subfamilia = '" & (codigo_subfamilia) & "' AND  o = '" & (O) & "' ")
                'If DS.Tables(DT.TableName).Rows.Count > 0 Then

                'Else
                SC.Connection = conexion
                SC.CommandText = "UPDATE subfamilia_dos SET `o`='" & (O) & "' WHERE `cod_auto`='" & (codigo_subfamilia) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE SUBFAMILIA O','" & (codigo_subfamilia) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
                'End If
            Next
        End If

        If combo_tipo.Text = "CREAR FAMILIA" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                familia = grilla_excel.Rows(i).Cells(0).Value.ToString

                conexion.Close()
                Consultas_SQL("select * from familia where nombre_familia = '" & (familia) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Else

                    Dim cod_auto_familia As Integer
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()
                    Try
                        SC.Connection = conexion
                        SC.CommandText = "select max(codigo) as codigo from familia"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        DS.Tables.Add(DT)
                        If DS.Tables(DT.TableName).Rows.Count > 0 Then
                            cod_auto_familia = DS.Tables(DT.TableName).Rows(0).Item("codigo")
                            cod_auto_familia = cod_auto_familia + 1
                        End If
                    Catch err As InvalidCastException
                        cod_auto_familia = 1
                    End Try
                    conexion.Close()

                    familia = UCase(familia)
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO familia(codigo, nombre_familia, fecha_modificacion) VALUES ('" & (cod_auto_familia) & "','" & (familia) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','CREACION DE FAMILIA','" & (familia) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next
        End If

        If combo_tipo.Text = "CREAR SUBFAMILIA" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                codigo_familia = grilla_excel.Rows(i).Cells(0).Value.ToString
                subfamilia = grilla_excel.Rows(i).Cells(1).Value.ToString

                conexion.Close()
                Consultas_SQL("select * from subfamilia where CODIGO_FAMILIA = '" & (codigo_familia) & "' AND  nombre_subfamilia = '" & (subfamilia) & "' ")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Else

                    Dim cod_auto_subfamilia As Integer
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()
                    Try
                        SC.Connection = conexion
                        SC.CommandText = "select max(cod_auto) as cod_auto from subfamilia"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        DS.Tables.Add(DT)
                        If DS.Tables(DT.TableName).Rows.Count > 0 Then
                            cod_auto_subfamilia = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                            cod_auto_subfamilia = cod_auto_subfamilia + 1
                        End If
                    Catch err As InvalidCastException
                        cod_auto_subfamilia = 1
                    End Try
                    conexion.Close()


                    subfamilia = UCase(subfamilia)
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO subfamilia(cod_auto, codigo_familia, nombre_subfamilia, fecha_modificacion) VALUES ('" & (cod_auto_subfamilia) & "', '" & (codigo_familia) & "','" & (subfamilia) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','CREACION DE SUBFAMILIA','" & (subfamilia) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next
        End If

        If combo_tipo.Text = "CREAR SUBFAMILIA 2" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                codigo_subfamilia = grilla_excel.Rows(i).Cells(0).Value.ToString
                subfamilia_dos = grilla_excel.Rows(i).Cells(1).Value.ToString

                conexion.Close()
                Consultas_SQL("select * from subfamilia_dos where codigo_subfamilia = '" & (codigo_subfamilia) & "' AND  nombre_subfamilia = '" & (subfamilia_dos) & "' ")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Else

                    Dim codigo_subfamilia_dos As Integer
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()
                    Try
                        SC.Connection = conexion
                        SC.CommandText = "select max(cod_auto) as cod_auto from subfamilia_dos"
                        DA.SelectCommand = SC
                        DA.Fill(DT)
                        DS.Tables.Add(DT)
                        If DS.Tables(DT.TableName).Rows.Count > 0 Then
                            codigo_subfamilia_dos = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                            codigo_subfamilia_dos = codigo_subfamilia_dos + 1
                        End If
                    Catch err As InvalidCastException
                        codigo_subfamilia_dos = 1
                    End Try
                    conexion.Close()

                    subfamilia_dos = UCase(subfamilia_dos)
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO subfamilia_dos(cod_auto, codigo_subfamilia, nombre_subfamilia, fecha_modificacion) VALUES ('" & (codigo_subfamilia_dos) & "', '" & (codigo_subfamilia) & "','" & (subfamilia_dos) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','CREACION DE SUBFAMILIA','" & (subfamilia_dos) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next
        End If

        If combo_tipo.Text = "INGRESAR CODIGOS DE BARRA" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                codigo_barra = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET codigo_barra='" & (codigo_barra) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If



        If combo_tipo.Text = "ACTUALIZAR ULTIMA COMPRA" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                cantidad_ultima_compra = grilla_excel.Rows(i).Cells(1).Value.ToString
                ultima_compra = grilla_excel.Rows(i).Cells(2).Value.ToString
                costo = grilla_excel.Rows(i).Cells(3).Value.ToString
                nro_doc = grilla_excel.Rows(i).Cells(4).Value.ToString
                tipo_doc = grilla_excel.Rows(i).Cells(5).Value.ToString
                proveedor = grilla_excel.Rows(i).Cells(6).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                Dim mifecha As Date
                mifecha = ultima_compra
                ultima_compra = mifecha.ToString("yyy-MM-dd")

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET cantidad_ultima_compra='" & (cantidad_ultima_compra) & "', ultima_compra='" & (ultima_compra) & "', costo='" & (costo) & "', nro_doc='" & (nro_doc) & "', tipo_doc='" & (tipo_doc) & "', proveedor='" & (proveedor) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next
        End If


        If combo_tipo.Text = "ASOCIAR CLIENTES A EMPRESAS" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                cod_cliente = grilla_excel.Rows(i).Cells(0).Value.ToString
                rut_cliente = grilla_excel.Rows(i).Cells(1).Value.ToString
                rut_retira = grilla_excel.Rows(i).Cells(2).Value.ToString
                nombre_retira = grilla_excel.Rows(i).Cells(3).Value.ToString

                Consultas_SQL("select * from clientes_que_retiran_por_empresas where rut_empresa = '" & (rut_cliente) & "' and rut_cliente = '" & (rut_retira) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    'MsgBox("REGISTRO YA EXISTENTE", 0 + 16, "ERROR")
                Else
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO clientes_que_retiran_por_empresas (codigo_empresa, rut_empresa, rut_cliente, nombre_cliente, usuario_responsable, fecha_modificacion) VALUES  ('" & (cod_cliente) & "','" & (rut_cliente) & "','" & (rut_retira) & "','" & (nombre_retira) & "','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next
        End If

        If combo_tipo.Text = "ACTUALIZAR ULTIMA COMPRA" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                ultima_compra = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                Dim mifecha As Date
                mifecha = ultima_compra
                ultima_compra = mifecha.ToString("yyy-MM-dd")

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET ultima_compra='" & (ultima_compra) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next
        End If



        If combo_tipo.Text = "ACTUALIZAR COSTOS" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                costo = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                Dim valor_costo As Integer

                valor_costo = 0

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    valor_costo = DS.Tables(DT.TableName).Rows(0).Item("costo")
                End If

                If valor_costo <= 1 Then
                    SC.Connection = conexion
                    SC.CommandText = "UPDATE productos SET costo='" & (costo) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If

            Next
        End If







        If combo_tipo.Text = "ACTUALIZAR STOCK" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                cantidad = grilla_excel.Rows(i).Cells(1).Value.ToString

                Try
                    nombre = grilla_excel.Rows(i).Cells(2).Value.ToString
                Catch
                    nombre = "-"
                End Try

                Try
                    precio = grilla_excel.Rows(i).Cells(3).Value.ToString
                Catch
                    precio = "0"
                End Try

                'nomprecio = "0"bre = "-"
                '

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET cantidad='" & (cantidad) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                If cantidad <> 0 Then
                    SC.Connection = conexion
                    SC.CommandText = "UPDATE productos SET activo='SI' WHERE cod_producto = '" & (cod_producto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If


                crear_nro_ajuste()


                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    precio = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    nombre = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                End If

                SC.Connection = conexion
                SC.CommandText = "insert into ajustes_de_stock (n_ajuste, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado, hora) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (cod_producto) & "','" & (nombre) & "'," & (precio) & ",'" & (cantidad) & "','0','0','0','0','0','AJUSTE', '" & (Form_menu_principal.dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA', '" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "insert into  detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (cod_producto) & "','" & (nombre) & "'," & (precio) & "," & (cantidad) & ",'0','0','0','0','0','ENTRA', '" & (Form_menu_principal.dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                'SC.Connection = conexion
                'SC.CommandText = "insert into  detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (cod_producto) & "','" & (nombre) & "'," & (precio) & "," & (cantidad) & ",'0','0','0','0','0','AJUSTE', '" & (form_Menu_admin.dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
            Next
        End If


        If combo_tipo.Text = "ACTUALIZAR NOMBRE" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET nombre='" & (nombre) & "', fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next

            lbl_mensaje.Visible = False
            Me.Enabled = True

            MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            Exit Sub
        End If


        If combo_tipo.Text = "ACTUALIZAR NUMERO TECNICO" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                numero_tecnico = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET numero_tecnico='" & (numero_tecnico) & "', fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
            lbl_mensaje.Visible = False
            Me.Enabled = True

            MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            Exit Sub
        End If


        If combo_tipo.Text = "ACTUALIZAR APLICACION" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                aplicacion = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET aplicacion='" & (aplicacion) & "',fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "'  WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
            lbl_mensaje.Visible = False
            Me.Enabled = True

            MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            Exit Sub
        End If


        If combo_tipo.Text = "ACTUALIZAR FAMILIA" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                familia = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET familia='" & (familia) & "',fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "', activo='SI'  WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If


        If combo_tipo.Text = "ACTUALIZAR SUBFAMILIA" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                subfamilia = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                familia = ""

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from subfamilia where cod_auto ='" & (subfamilia) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    familia = DS.Tables(DT.TableName).Rows(0).Item("codigo_familia")
                End If

                SC.Connection = conexion
                'SC.CommandText = "UPDATE productos SET familia='" & (familia) & "', subfamilia='" & (subfamilia) & "',fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "', activo='SI'  WHERE cod_producto = '" & (cod_producto) & "'"
                SC.CommandText = "UPDATE productos SET subfamilia='" & (subfamilia) & "',fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "', activo='SI'  WHERE cod_producto = '" & (cod_producto) & "'"

                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If

        If combo_tipo.Text = "ACTUALIZAR NOMBRE SUBFAMILIA 2" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                codigo_subfamilia = grilla_excel.Rows(i).Cells(0).Value.ToString
                subfamilia_dos = grilla_excel.Rows(i).Cells(1).Value.ToString

                SC.Connection = conexion
                SC.CommandText = "UPDATE subfamilia_dos SET nombre_subfamilia='" & (subfamilia_dos) & "',fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE cod_auto = '" & (codigo_subfamilia) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next

            lbl_mensaje.Visible = False
            Me.Enabled = True

            MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            Exit Sub

        End If


        If combo_tipo.Text = "ACTUALIZAR SUBFAMILIA 2" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                subfamilia_dos = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)




                subfamilia = ""
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from subfamilia_dos where cod_auto ='" & (subfamilia_dos) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    subfamilia = DS.Tables(DT.TableName).Rows(0).Item("codigo_subfamilia")
                End If

                familia = ""
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from subfamilia where cod_auto ='" & (subfamilia) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    familia = DS.Tables(DT.TableName).Rows(0).Item("codigo_familia")
                End If







                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET familia='" & (familia) & "',subfamilia='" & (subfamilia) & "',subfamilia_dos='" & (subfamilia_dos) & "',fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "', activo='SI'  WHERE cod_producto = '" & (cod_producto) & "'"
                'SC.CommandText = "UPDATE productos SET subfamilia_dos='" & (subfamilia_dos) & "',fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "', activo='SI'  WHERE cod_producto = '" & (cod_producto) & "'"

                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If

        If combo_tipo.Text = "ACTUALIZAR MARCA" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                marca = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET marca='" & (marca) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If


        If combo_tipo.Text = "ACTUALIZAR STOCK MINIMO" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                cantidad = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET cantidad_minima='" & (cantidad) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Next
        End If

        If combo_tipo.Text = "ACTUALIZAR ESTADO DEL PRODUCTO" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                estado = grilla_excel.Rows(i).Cells(1).Value.ToString

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE productos SET activo='" & (estado) & "' WHERE cod_producto = '" & (cod_producto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next
        End If







        If combo_tipo.Text = "ACTUALIZAR DATOS DEL PRODUCTO" Then
            For i = 0 To grilla_excel.Rows.Count - 1

                cod_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(1).Value.ToString
                marca = grilla_excel.Rows(i).Cells(2).Value.ToString
                aplicacion = grilla_excel.Rows(i).Cells(3).Value.ToString
                precio = grilla_excel.Rows(i).Cells(4).Value.ToString
                costo = grilla_excel.Rows(i).Cells(5).Value.ToString
                factor = grilla_excel.Rows(i).Cells(6).Value.ToString
                numero_tecnico = grilla_excel.Rows(i).Cells(7).Value.ToString
                proveedor = grilla_excel.Rows(i).Cells(8).Value.ToString
                familia = grilla_excel.Rows(i).Cells(9).Value.ToString
                subfamilia = grilla_excel.Rows(i).Cells(10).Value.ToString
                subfamilia_dos = grilla_excel.Rows(i).Cells(11).Value.ToString
                ultima_compra = grilla_excel.Rows(i).Cells(12).Value.ToString
                cantidad_ultima_compra = grilla_excel.Rows(i).Cells(13).Value.ToString
                tipo_doc = grilla_excel.Rows(i).Cells(14).Value.ToString
                nro_doc = grilla_excel.Rows(i).Cells(15).Value.ToString
                estado = grilla_excel.Rows(i).Cells(16).Value.ToString

                Dim mifecha As Date
                mifecha = ultima_compra
                ultima_compra = mifecha.ToString("yyy-MM-dd")

                Dim valor As Integer
                valor = cod_producto
                cod_producto = String.Format("{0:000000}", valor)

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos` SET `nombre`='" & (nombre) & "', `marca`='" & (marca) & "', `aplicacion`='" & (aplicacion) & "', `precio`='" & (precio) & "', `costo`='" & (costo) & "', `factor`='" & (factor) & "', `numero_tecnico`='" & (numero_tecnico) & "', `proveedor`='" & (proveedor) & "', `familia`='" & (familia) & "', `subfamilia`='" & (subfamilia) & "', `subfamilia_dos`='" & (subfamilia_dos) & "', `ultima_compra`='" & (ultima_compra) & "', `cantidad_ultima_compra`='" & (cantidad_ultima_compra) & "', `tipo_doc`='" & (tipo_doc) & "', `nro_doc`='" & (nro_doc) & "', `activo`='" & (estado) & "' WHERE `cod_producto`='" & (cod_producto) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

                'crear_nro_ajuste()

                'SC.Connection = conexion
                'SC.CommandText = "insert into  detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_ajuste.Text) & ", '" & ("AJUSTE POR: " & miusuario) & "', '" & (cod_producto) & "','" & (nombre) & "'," & (precio) & "," & (cantidad) & ",'0','0','0','0','0','AJUSTE', '" & (form_Menu_admin.dtp_fecha.Text) & "',  '" & (miusuario) & "',  'EMITIDA')"
                'DA.SelectCommand = SC
                'DA.Fill(DT)
            Next
        End If

        'lbl_mensaje.Visible = False
        'Me.Enabled = True

        'Dim nro_recepcion As String
        'Dim fecha_recepcion As String
        'Dim hora As String
        'Dim rut As String
        'Dim nombre_rececepcion As String
        'Dim direccion As String
        'Dim telefono As String
        'Dim celular As String
        'Dim diagnostico_cliente As String
        'Dim diagnostico_tecnico As String
        'Dim pc As String
        'Dim contraseña_bios As String
        'Dim contraseña_windows As String
        'Dim notebook As String
        'Dim impresora As String
        'Dim pantalla As String
        'Dim scanner As String
        'Dim teclado As String
        'Dim mouse As String
        'Dim fuente_de_poder As String
        'Dim unidad_optica As String
        'Dim disco_duro As String
        'Dim otros As String
        'Dim total_presupuesto As String
        'Dim forma_de_pago As String
        'Dim estado_recepcion As String
        'Dim pago_parcial As String
        'Dim retirado As String
        'Dim cancelado As String









        'If combo_tipo.Text = "PRESUPUESTO" Then
        '    For i = 0 To grilla_excel.Rows.Count - 1
        '        nro_recepcion = grilla_excel.Rows(i).Cells(0).Value.ToString
        '        fecha_recepcion = grilla_excel.Rows(i).Cells(1).Value.ToString
        '        hora = grilla_excel.Rows(i).Cells(2).Value.ToString
        '        rut = grilla_excel.Rows(i).Cells(3).Value.ToString
        '        nombre_rececepcion = grilla_excel.Rows(i).Cells(4).Value.ToString
        '        direccion = grilla_excel.Rows(i).Cells(5).Value.ToString
        '        telefono = grilla_excel.Rows(i).Cells(6).Value.ToString
        '        celular = grilla_excel.Rows(i).Cells(7).Value.ToString
        '        diagnostico_cliente = grilla_excel.Rows(i).Cells(8).Value.ToString
        '        diagnostico_tecnico = grilla_excel.Rows(i).Cells(9).Value.ToString
        '        pc = grilla_excel.Rows(i).Cells(10).Value.ToString
        '        contraseña_bios = grilla_excel.Rows(i).Cells(11).Value.ToString
        '        contraseña_windows = grilla_excel.Rows(i).Cells(12).Value.ToString
        '        notebook = grilla_excel.Rows(i).Cells(12).Value.ToString
        '        impresora = grilla_excel.Rows(i).Cells(14).Value.ToString
        '        pantalla = grilla_excel.Rows(i).Cells(15).Value.ToString
        '        scanner = grilla_excel.Rows(i).Cells(16).Value.ToString
        '        teclado = grilla_excel.Rows(i).Cells(17).Value.ToString
        '        mouse = grilla_excel.Rows(i).Cells(18).Value.ToString
        '        fuente_de_poder = grilla_excel.Rows(i).Cells(19).Value.ToString
        '        unidad_optica = grilla_excel.Rows(i).Cells(20).Value.ToString
        '        disco_duro = grilla_excel.Rows(i).Cells(21).Value.ToString
        '        otros = grilla_excel.Rows(i).Cells(22).Value.ToString
        '        total_presupuesto = grilla_excel.Rows(i).Cells(23).Value.ToString
        '        forma_de_pago = grilla_excel.Rows(i).Cells(24).Value.ToString
        '        estado_recepcion = grilla_excel.Rows(i).Cells(25).Value.ToString
        '        pago_parcial = grilla_excel.Rows(i).Cells(26).Value.ToString
        '        retirado = grilla_excel.Rows(i).Cells(27).Value.ToString
        '        cancelado = grilla_excel.Rows(i).Cells(28).Value.ToString

        '        If fecha_recepcion = "" Then
        '            fecha_recepcion = "1950-01-01"
        '        End If

        '        Dim mifecha As Date
        '        mifecha = fecha_recepcion
        '        fecha_recepcion = mifecha.ToString("yyy-MM-dd")

        '        If contraseña_bios <> "" Then
        '            diagnostico_cliente = diagnostico_cliente & ", CONTRASEÑA BIOS: " & contraseña_bios
        '        End If

        '        If contraseña_windows <> "" Then
        '            diagnostico_cliente = diagnostico_cliente & ", CONTRASEÑA WINDOWS: " & contraseña_windows
        '        End If

        '        If rut = "NINGUNO" Then
        '            rut = "11111111-1"
        '        End If

        '        If rut = "" Then
        '            rut = "11111111-1"
        '        End If

        '        If total_presupuesto = "" Then
        '            total_presupuesto = "0"
        '        End If

        '        If total_presupuesto = "GARANTIA" Then
        '            total_presupuesto = "0"
        '        End If

        '        If total_presupuesto = "ENGARANTIA" Then
        '            total_presupuesto = "0"
        '        End If

        '        If pago_parcial = "" Then
        '            pago_parcial = "0"
        '        End If

        '        If retirado <> "" Then
        '            retirado = "SI"
        '        Else
        '            retirado = "NO"
        '        End If

        '        If cancelado <> "" Then
        '            cancelado = "SI"
        '        Else
        '            cancelado = "NO"
        '        End If

        '        total_presupuesto = Trim(Replace(total_presupuesto, ".", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "-", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "$", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "*", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "+", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, " ", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "/", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "CAJAP", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "REVISI", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "SINI", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "IVA", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "COMP", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "ENGARANTI", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "ON", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "GARANTIA", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "VA", ""))
        '        total_presupuesto = Trim(Replace(total_presupuesto, "AQ", ""))

        '        pago_parcial = Trim(Replace(pago_parcial, ".", ""))
        '        pago_parcial = Trim(Replace(pago_parcial, "-", ""))
        '        pago_parcial = Trim(Replace(pago_parcial, "$", ""))
        '        pago_parcial = Trim(Replace(pago_parcial, "*", ""))
        '        pago_parcial = Trim(Replace(pago_parcial, "+", ""))
        '        pago_parcial = Trim(Replace(pago_parcial, " ", ""))
        '        pago_parcial = Trim(Replace(pago_parcial, "/", ""))
        '        pago_parcial = Trim(Replace(pago_parcial, "TRANSFERE", ""))
        '        pago_parcial = Trim(Replace(pago_parcial, "CIA", ""))

        '        If total_presupuesto.Length > 9 Then
        '            total_presupuesto = total_presupuesto.Substring(0, 9)
        '        End If

        '        If pago_parcial.Length > 9 Then
        '            pago_parcial = pago_parcial.Substring(0, 9)
        '        End If

        '        If forma_de_pago.Length > 90 Then
        '            forma_de_pago = forma_de_pago.Substring(0, 90)
        '        End If

        '        estado_recepcion = UCase(estado_recepcion)
        '        diagnostico_cliente = UCase(diagnostico_cliente)
        '        diagnostico_tecnico = UCase(diagnostico_tecnico)
        '        forma_de_pago = UCase(forma_de_pago)

        '        If total_presupuesto = "" Then
        '            total_presupuesto = "0"
        '        End If

        '        If pago_parcial = "" Then
        '            pago_parcial = "0"
        '        End If

        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `recepcion_de_trabajos` (`n_recepcion`, `rut_cliente`, `diagnostico_tecnico`, `diagnostico_cliente`, `detalle_pago`, `cancelado`, `retirado`, `total_presupuesto`, `pago_parcial`, `estado`, `usuario_responsable`, `fecha`, `hora`) VALUES ('" & (nro_recepcion) & "', '" & (rut) & "', '" & (diagnostico_tecnico) & "', '" & (diagnostico_cliente) & "', '" & (forma_de_pago) & "', '" & (cancelado) & "', '" & (retirado) & "', '" & (total_presupuesto) & "', '" & (pago_parcial) & "', '" & (estado_recepcion) & "', '" & (miusuario) & "', '" & (fecha_recepcion) & "', '" & (hora) & "');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)

        '        If otros <> "" Then
        '            SC3.Connection = conexion
        '            SC3.CommandText = "INSERT INTO detalle_recepcion_de_trabajos (`hardware`, `nro_recepcion`) VALUES ('OTROS', '" & (nro_recepcion) & "');"
        '            DA3.SelectCommand = SC3
        '            DA3.Fill(DT3)
        '        End If

        '        If disco_duro <> "" Then
        '            SC3.Connection = conexion
        '            SC3.CommandText = "INSERT INTO detalle_recepcion_de_trabajos (`hardware`, `nro_recepcion`) VALUES ('DISCO DURO', '" & (nro_recepcion) & "');"
        '            DA3.SelectCommand = SC3
        '            DA3.Fill(DT3)
        '        End If

        '        If unidad_optica <> "" Then
        '            SC3.Connection = conexion
        '            SC3.CommandText = "INSERT INTO detalle_recepcion_de_trabajos (`hardware`, `nro_recepcion`) VALUES ('UNIDAD OPTICA', '" & (nro_recepcion) & "');"
        '            DA3.SelectCommand = SC3
        '            DA3.Fill(DT3)
        '        End If

        '        If fuente_de_poder <> "" Then
        '            SC3.Connection = conexion
        '            SC3.CommandText = "INSERT INTO detalle_recepcion_de_trabajos (`hardware`, `nro_recepcion`) VALUES ('FUENTE DE PODER', '" & (nro_recepcion) & "');"
        '            DA3.SelectCommand = SC3
        '            DA3.Fill(DT3)
        '        End If

        '        If mouse <> "" Then
        '            SC3.Connection = conexion
        '            SC3.CommandText = "INSERT INTO detalle_recepcion_de_trabajos (`hardware`, `nro_recepcion`) VALUES ('MOUSE', '" & (nro_recepcion) & "');"
        '            DA3.SelectCommand = SC3
        '            DA3.Fill(DT3)
        '        End If

        '        If teclado <> "" Then
        '            SC3.Connection = conexion
        '            SC3.CommandText = "INSERT INTO detalle_recepcion_de_trabajos (`hardware`, `nro_recepcion`) VALUES ('TECLADO', '" & (nro_recepcion) & "');"
        '            DA3.SelectCommand = SC3
        '            DA3.Fill(DT3)
        '        End If

        '        If scanner <> "" Then
        '            SC3.Connection = conexion
        '            SC3.CommandText = "INSERT INTO detalle_recepcion_de_trabajos (`hardware`, `nro_recepcion`) VALUES ('SCANNER', '" & (nro_recepcion) & "');"
        '            DA3.SelectCommand = SC3
        '            DA3.Fill(DT3)
        '        End If

        '        If pantalla <> "" Then
        '            SC3.Connection = conexion
        '            SC3.CommandText = "INSERT INTO detalle_recepcion_de_trabajos (`hardware`, `nro_recepcion`) VALUES ('PANTALLA', '" & (nro_recepcion) & "');"
        '            DA3.SelectCommand = SC3
        '            DA3.Fill(DT3)
        '        End If

        '        If impresora <> "" Then
        '            SC3.Connection = conexion
        '            SC3.CommandText = "INSERT INTO detalle_recepcion_de_trabajos (`hardware`, `nro_recepcion`) VALUES ('IMPRESORA', '" & (nro_recepcion) & "');"
        '            DA3.SelectCommand = SC3
        '            DA3.Fill(DT3)
        '        End If
        '    Next
        'End If






        'If combo_tipo.Text = "PRODUCTOS CV" Then






        '    lbl_mensaje.Visible = True
        '    Me.Enabled = False



        '    Dim codigo As String
        '    Dim cant As String
        '    Dim articulo As String
        '    Dim valor As String
        '    Dim compra As String
        '    'Dim numero_tecnico As String
        '    ' Dim marca As String
        '    'Dim rut As String
        '    Dim rut_proveedor As String
        '    Dim nombre_prov As String
        '    Dim factura As String
        '    Dim fecha_fact As String
        '    Dim codigo_familia As String = ""
        '    Dim codigo_subfamilia As String = ""




        '    For i = 0 To grilla_excel.Rows.Count - 1

        '        codigo = grilla_excel.Rows(i).Cells(0).Value.ToString
        '        cant = grilla_excel.Rows(i).Cells(1).Value.ToString
        '        articulo = grilla_excel.Rows(i).Cells(2).Value.ToString
        '        valor = Int(grilla_excel.Rows(i).Cells(3).Value.ToString)
        '        compra = Int(grilla_excel.Rows(i).Cells(4).Value.ToString)
        '        numero_tecnico = grilla_excel.Rows(i).Cells(5).Value.ToString
        '        marca = grilla_excel.Rows(i).Cells(6).Value.ToString
        '        rut_proveedor = grilla_excel.Rows(i).Cells(7).Value.ToString
        '        nombre_prov = grilla_excel.Rows(i).Cells(8).Value.ToString
        '        factura = grilla_excel.Rows(i).Cells(9).Value.ToString
        '        fecha_fact = grilla_excel.Rows(i).Cells(10).Value.ToString
        '        familia = grilla_excel.Rows(i).Cells(11).Value.ToString
        '        subfamilia = grilla_excel.Rows(i).Cells(12).Value.ToString


        '        Dim valor_6 As Integer
        '        valor_6 = codigo
        '        codigo = String.Format("{0:000000}", valor_6)

        '        conexion.Close()
        '        Consultas_SQL("select * from familia where nombre_familia = '" & (familia) & "'")
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            codigo_familia = DS.Tables(DT.TableName).Rows(0).Item("codigo")
        '        Else
        '            SC.Connection = conexion
        '            SC.CommandText = "INSERT INTO familia (nombre_familia) VALUES ('" & (familia) & "')"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)

        '            conexion.Close()
        '            Consultas_SQL("select * from familia where nombre_familia = '" & (familia) & "'")
        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                codigo_familia = DS.Tables(DT.TableName).Rows(0).Item("codigo")
        '            End If
        '        End If

        '        conexion.Close()
        '        Consultas_SQL("select * from proveedores where rut_proveedor = '" & (rut_proveedor) & "'")
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then

        '        Else
        '            SC.Connection = conexion
        '            SC.CommandText = "INSERT INTO proveedores(rut_proveedor, nombre_proveedor, direccion_proveedor, telefono_proveedor, email_proveedor, ciudad_proveedor, comuna_proveedor, giro_proveedor, representante_proveedor) VALUES ('" & (rut_proveedor) & "', '" & (nombre_prov) & "', '-', '0', '-', '-', '-', '-', '-')"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        End If

        '        conexion.Close()
        '        Consultas_SQL("select * from subfamilia where codigo_familia = '" & (codigo_familia) & "' and nombre_subfamilia = '" & (subfamilia) & "'")
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            codigo_subfamilia = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
        '        Else
        '            SC.Connection = conexion
        '            SC.CommandText = "INSERT INTO subfamilia(codigo_familia, nombre_subfamilia) VALUES ('" & (codigo_familia) & "', '" & (subfamilia) & "')"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)

        '            conexion.Close()
        '            Consultas_SQL("select * from subfamilia where codigo_familia = '" & (codigo_familia) & "' and nombre_subfamilia = '" & (subfamilia) & "'")
        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                codigo_subfamilia = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
        '            End If
        '        End If



        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `productos` (`cod_producto`, `nombre`, `marca`, `aplicacion`, `cantidad`, `precio`, `costo`, `factor`, `numero_tecnico`, `cantidad_minima`, `proveedor`, `margen`, `familia`, `subfamilia`, `subfamilia_dos`, `codigo_barra`, `ultima_compra`, `numero_proveedor`, `ultima_revision`, `revisado_por`, `cantidad_ultima_compra`, `posicion_1`, `posicion_2`, `tipo_doc`, `nro_doc`, `fecha_modificacion`, `tipo_precio`, `estado_producto`, `activo`) VALUES ('" & (codigo) & "', '" & (articulo) & "', '" & (marca) & "', '" & (familia) & "', '" & (cant) & "', '" & (valor) & "', '" & (compra) & "', '-', '" & (numero_tecnico) & "', '0', '" & (rut_proveedor) & "', '0', '" & (codigo_familia) & "', '" & (codigo_subfamilia) & "', '0', '-', '2000-01-01', '-', '2017-06-01', '-', '0', '-', '-', '-', '" & (factura) & "', '2017-06-01', '-', '-', 'SI');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)

        '    Next
        'End If






        'If combo_tipo.Text = "RECEPCIONES ANTIGUAS" Then






        '    lbl_mensaje.Visible = True
        '    Me.Enabled = False



        '    'Dim nro_recepcion As String
        '    'Dim rut As String
        '    'Dim nombre As String
        '    'Dim fecha_recepcion As String
        '    'Dim hora As String





        '    For i = 0 To grilla_excel.Rows.Count - 1

        '        nro_recepcion = grilla_excel.Rows(i).Cells(0).Value.ToString
        '        rut = grilla_excel.Rows(i).Cells(1).Value.ToString
        '        nombre = grilla_excel.Rows(i).Cells(2).Value.ToString
        '        fecha_recepcion = grilla_excel.Rows(i).Cells(3).Value.ToString
        '        hora = grilla_excel.Rows(i).Cells(4).Value.ToString

        '        If fecha_recepcion = "" Then
        '            fecha_recepcion = "2000-01-01"
        '        End If

        '        Dim mifecha As Date
        '        mifecha = fecha_recepcion
        '        fecha_recepcion = mifecha.ToString("yyy-MM-dd")


        '        rut = UCase(rut)
        '        nombre = UCase(nombre)

        '        rut = Trim(Replace(rut, ".", ""))
        '        rut = Trim(Replace(rut, ",", ""))
        '        nombre = Trim(Replace(nombre, "'", ""))
        '        nombre = Trim(Replace(nombre, "/", " "))

        '        If nombre.Length > 45 Then
        '            nombre = nombre.Substring(0, 45)
        '        End If

        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `casa_bravo_520`.`recepciones_antiguas` (`nro_recepcion`, `rut_cliente`, `nombre_cliente`, `fecha`, `hora`) VALUES ('" & (nro_recepcion) & "', '" & (rut) & "', '" & (nombre) & "', '" & (fecha_recepcion) & "', '" & (hora) & "');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)

        '    Next
        'End If

















        'If combo_tipo.Text = "CLIENTES CV" Then
        '    lbl_mensaje.Visible = True
        '    Me.Enabled = False

        '    Dim rut_cliente As String
        '    Dim nombre_cliente As String
        '    Dim dreccion_cliente As String
        '    Dim telefono_cliente As String
        '    Dim ciudad_cliente As String
        '    Dim giro_cliente As String




        '    For i = 0 To grilla_excel.Rows.Count - 1

        '        rut_cliente = grilla_excel.Rows(i).Cells(1).Value.ToString
        '        nombre_cliente = grilla_excel.Rows(i).Cells(0).Value.ToString
        '        dreccion_cliente = grilla_excel.Rows(i).Cells(2).Value.ToString
        '        telefono_cliente = grilla_excel.Rows(i).Cells(5).Value.ToString
        '        ciudad_cliente = grilla_excel.Rows(i).Cells(3).Value.ToString
        '        giro_cliente = grilla_excel.Rows(i).Cells(4).Value.ToString



        '        rut_cliente = UCase(rut_cliente)
        '        nombre_cliente = UCase(nombre_cliente)
        '        dreccion_cliente = UCase(dreccion_cliente)
        '        telefono_cliente = UCase(telefono_cliente)
        '        ciudad_cliente = UCase(ciudad_cliente)
        '        giro_cliente = UCase(giro_cliente)

        '        rut_cliente = Trim(Replace(rut_cliente, ".", ""))
        '        rut_cliente = Trim(Replace(rut_cliente, ",", ""))
        '        dreccion_cliente = Trim(Replace(dreccion_cliente, "'", ""))

        '        If telefono_cliente = "" Then
        '            telefono_cliente = "0"
        '        End If

        '        If giro_cliente.Length > 45 Then
        '            giro_cliente = giro_cliente.Substring(0, 45)
        '        End If

        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `casa_bravo_520`.`clientes` (`rut_cliente`, `nombre_cliente`, `direccion_cliente`, `telefono_cliente`, `ciudad_cliente`, `comuna_cliente`, `giro_cliente`, `email_cliente`, `tipo_cliente`, `descuento_1`, `descuento_2`, `cuenta_cliente`, `tipo_cuenta`, `folio_cliente`, `estado_cuenta`, `orden_de_compra`, `mensaje`, `cupo_cliente`, `saldo_cliente`, `fecha_modificacion`, `activo`, `pagare`) VALUES ('" & (rut_cliente) & "', '" & (nombre_cliente) & "', '" & (dreccion_cliente) & "', '" & (telefono_cliente) & "', '" & (ciudad_cliente) & "', '" & (ciudad_cliente) & "', '" & (giro_cliente) & "', '-', 'EMPRESA', '0', '0', 'NO', '-', '-', 'SIN CUENTA', 'NO', 'SIN MENSAJE', '0', '0', '2017-06-16', 'SI', '0');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)

        '    Next
        'End If







        If combo_tipo.Text = "PERMISOS DE USUARIOS" Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            'Dim rut_cliente As String
            Dim permiso As String
            Dim modulo As String

            For i = 0 To grilla_excel.Rows.Count - 1

                rut_cliente = grilla_excel.Rows(i).Cells(0).Value.ToString
                permiso = grilla_excel.Rows(i).Cells(1).Value.ToString
                modulo = grilla_excel.Rows(i).Cells(2).Value.ToString

                SC.Connection = conexion
                SC.CommandText = "INSERT INTO `registro_de_permisos` (`rut_usuario`, `permiso`, `modulo`) VALUES ('" & (rut_cliente) & "', '" & (permiso) & "', '" & (modulo) & "');"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next
        End If


        If combo_tipo.Text = "ANULAR CREDITOS" Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            'Dim rut_cliente As String
            Dim documento As String
            Dim nro_documento As String

            For i = 0 To grilla_excel.Rows.Count - 1

                rut_cliente = grilla_excel.Rows(i).Cells(0).Value.ToString
                documento = grilla_excel.Rows(i).Cells(1).Value.ToString
                nro_documento = grilla_excel.Rows(i).Cells(2).Value.ToString

                SC.Connection = conexion
                SC.CommandText = "UPDATE `creditos` SET `saldo`='0', doc_referencia='MASIVO' WHERE rut_cliente='" & (rut_cliente) & "' and tipo_detalle like '" & ("%" & documento & "%") & "' and tipo_detalle like '" & ("%" & nro_documento & "%") & "' and `cod_auto`<>'0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next
        End If
























        lbl_mensaje.Visible = False
        Me.Enabled = True

        MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_excel.DataSource = Nothing
        txt_item.Text = ""
        txtFic.Text = ""
        txtSelect.Text = ""
    End Sub

    Private Sub combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_tipo.SelectedIndexChanged
        grilla_excel.DataSource = Nothing
        grilla_ejemplo.Columns.Clear()
        txt_item.Text = ""
        txtFic.Text = ""
        txtSelect.Text = ""
        archivo_ejemplo()
    End Sub

    Sub archivo_ejemplo()

        If combo_tipo.Text = "CAMBIAR ESTADO DE GUIAS" Then
            grilla_excel.Columns.Clear()
            grilla_excel.Columns.Add("", "NUMERO DE GUIA")
            grilla_excel.Rows.Add("1988")
        End If

        If combo_tipo.Text = "INGRESAR MEDIDAS SUBFAMILIAS 2" Then

            grilla_excel.Columns.Clear()
            grilla_excel.Columns.Add("", "CODIGO SUBFAMILIA 2")
            grilla_excel.Columns.Add("", "MEDIDA 1")
            grilla_excel.Columns.Add("", "MEDIDA 2")
            grilla_excel.Columns.Add("", "MEDIDA 3")
            grilla_excel.Rows.Add("CODIGO SUBFAMILIA 2", "MEDIDA 1", "MEDIDA 2", "MEDIDA 3")

            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO SUBFAMILIA 2")
            grilla_ejemplo.Columns.Add("", "MEDIDA 1")
            grilla_ejemplo.Columns.Add("", "MEDIDA 2")
            grilla_ejemplo.Columns.Add("", "MEDIDA 3")
            grilla_ejemplo.Rows.Add("CODIGO SUBFAMILIA 2", "MEDIDA 1", "MEDIDA 2", "MEDIDA 3")
        End If

        If combo_tipo.Text = "INGRESAR PEDIDO" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "NOMBRE")
            grilla_ejemplo.Columns.Add("", "PROVEEDOR")
            grilla_ejemplo.Columns.Add("", "CANTIDAD")
            grilla_ejemplo.Rows.Add("VKC 2516 C", "SKF", "5")
        End If

        If combo_tipo.Text = "CREAR FAMILIA" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "NOMBRE FAMILIA")
            grilla_ejemplo.Rows.Add("AQUI EL NOMBRE DE LA FAMILIA ")
        End If

        If combo_tipo.Text = "CREAR SUBFAMILIA" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO FAMILIA")
            grilla_ejemplo.Columns.Add("", "NOMBRE SUBFAMILIA")
            grilla_ejemplo.Rows.Add("AQUI EL CODIGO DE LA FAMILIA ", "AQUI EL NOMBRE DE LA SUBFAMILIA")
        End If


        If combo_tipo.Text = "CREAR SUBFAMILIA 2" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO SUBFAMILIA")
            grilla_ejemplo.Columns.Add("", "NOMBRE SUBFAMILIA DOS")
            grilla_ejemplo.Rows.Add("AQUI EL CODIGO DE LA SUBFAMILIA ", "AQUI EL NOMBRE DE LA SUBFAMILIA DOS")
        End If








        If combo_tipo.Text = "ACTUALIZAR STOCK" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "CANTIDAD")
            grilla_ejemplo.Rows.Add("000000", "1")
        End If
        If combo_tipo.Text = "ACTUALIZAR STOCK MINIMO" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "CANTIDAD")
            grilla_ejemplo.Rows.Add("000000", "1")
        End If
        If combo_tipo.Text = "ACTUALIZAR ESTADO DEL PRODUCTO" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "ESTADO")
            grilla_ejemplo.Rows.Add("000000", "SI")
        End If

        If combo_tipo.Text = "ACTUALIZAR DATOS DEL PRODUCTO" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "NOMBRE")
            grilla_ejemplo.Columns.Add("", "MARCA")
            grilla_ejemplo.Columns.Add("", "APLICACIÓN")
            grilla_ejemplo.Columns.Add("", "PRECIO")
            grilla_ejemplo.Columns.Add("", "COSTO")
            grilla_ejemplo.Columns.Add("", "FACTOR")
            grilla_ejemplo.Columns.Add("", "NUMERO TÉCNICO")
            grilla_ejemplo.Columns.Add("", "RUT PROVEEDOR")
            grilla_ejemplo.Columns.Add("", "FAMILIA")
            grilla_ejemplo.Columns.Add("", "SUBFAMILIA")
            grilla_ejemplo.Columns.Add("", "SUBFAMILIA DOS")
            grilla_ejemplo.Columns.Add("", "FECHA ÚLT. COMPRA")
            grilla_ejemplo.Columns.Add("", "CANT. ÚLT. COMPRA")
            grilla_ejemplo.Columns.Add("", "DOC. ÚLT. COMPRA")
            grilla_ejemplo.Columns.Add("", "NRO. DOC. COMPRA")
            grilla_ejemplo.Columns.Add("", "ACTIVO")
        End If

        If combo_tipo.Text = "INGRESAR CODIGOS DE BARRA" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "CODIGO DE BARRA")
            grilla_ejemplo.Rows.Add("000000", "1123644569")
        End If

        If combo_tipo.Text = "ACTUALIZAR ULTIMA COMPRA" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "CANTIDAD ULTIMA COMPRA")
            grilla_ejemplo.Columns.Add("", "FECHA ULT. COMPRA")
            grilla_ejemplo.Columns.Add("", "COSTO")
            grilla_ejemplo.Columns.Add("", "NRO. DOC.")
            grilla_ejemplo.Columns.Add("", "TIPO DOC.")
            grilla_ejemplo.Columns.Add("", "RUT PROV.")
        End If



        If combo_tipo.Text = "ASOCIAR CLIENTES A EMPRESAS" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO CLIENTE")
            grilla_ejemplo.Columns.Add("", "RUT CLIENTE")
            grilla_ejemplo.Columns.Add("", "RUT RETIRA")
            grilla_ejemplo.Columns.Add("", "NOMBRE RETIRA")
            grilla_ejemplo.Rows.Add("1", "16972940-9", "16972940-9", "CLAUDIO CALDERON")
        End If

        If combo_tipo.Text = "ACTUALIZAR ULTIMA COMPRA" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "FECHA ULTIMA COMPRA")
            grilla_ejemplo.Rows.Add("000000", "2017-01-01")
        End If



        If combo_tipo.Text = "ACTUALIZAR COSTOS" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "COSTO")
            grilla_ejemplo.Rows.Add("000000", "1000")
        End If



        If combo_tipo.Text = "ACTUALIZAR STOCK" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "CANTIDAD")
            grilla_ejemplo.Rows.Add("000000", "1")
        End If


        If combo_tipo.Text = "ACTUALIZAR NOMBRE" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "NOMBRE DE PRODUCTO")
            grilla_ejemplo.Rows.Add("000000", "NOMBRE DEL PRODUCTO")
        End If


        If combo_tipo.Text = "ACTUALIZAR NUMERO TECNICO" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "NUMERO TECNICO")
            grilla_ejemplo.Rows.Add("000000", "NRO. TECNICO")
        End If


        If combo_tipo.Text = "ACTUALIZAR APLICACION" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "APLICACION")
            grilla_ejemplo.Rows.Add("000000", "APLICACION DEL PRODUCTO")
        End If

        If combo_tipo.Text = "ACTUALIZAR FAMILIA" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "FAMILIA")
            grilla_ejemplo.Rows.Add("000000", "1")
        End If

        If combo_tipo.Text = "ACTUALIZAR SUBFAMILIA" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "SUBFAMILIA")
            grilla_ejemplo.Rows.Add("000000", "1")
        End If

        If combo_tipo.Text = "ACTUALIZAR SUBFAMILIA 2" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "CODIGO SUBFAMILIA 2")
            grilla_ejemplo.Rows.Add("000000", "1")
        End If

        If combo_tipo.Text = "ACTUALIZAR MARCA" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "MARCA")
            grilla_ejemplo.Rows.Add("000000", "MARCA DEL PRODUCTO")
        End If

        If combo_tipo.Text = "ACTUALIZAR STOCK MINIMO" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "STOCK MINIMO")
            grilla_ejemplo.Rows.Add("000000", "1")
        End If

        If combo_tipo.Text = "ACTUALIZAR ESTADO DEL PRODUCTO" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "ESTADO")
            grilla_ejemplo.Rows.Add("000000", "SI")
        End If

        If combo_tipo.Text = "ACTUALIZAR DATOS DEL PRODUCTO" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Columns.Add("", "NOMBRE")
            grilla_ejemplo.Columns.Add("", "MARCA")
            grilla_ejemplo.Columns.Add("", "APLICACION")
            grilla_ejemplo.Columns.Add("", "PRECIO")
            grilla_ejemplo.Columns.Add("", "COSTO")
            grilla_ejemplo.Columns.Add("", "FACTOR")
            grilla_ejemplo.Columns.Add("", "NUMERO TECNICO")
            grilla_ejemplo.Columns.Add("", "PROVEEDOR")
            grilla_ejemplo.Columns.Add("", "FAMILIA")
            grilla_ejemplo.Columns.Add("", "SUBFAMILIA")
            grilla_ejemplo.Columns.Add("", "SUBFAMILIA 2")
            grilla_ejemplo.Columns.Add("", "ULTIMA COMPRA")
            grilla_ejemplo.Columns.Add("", "CANTIDAD ULTIMA COMPRA")
            grilla_ejemplo.Columns.Add("", "TIPO DOC.")
            grilla_ejemplo.Columns.Add("", "NRO. DOC.")
            grilla_ejemplo.Columns.Add("", "ESTADO")

            grilla_ejemplo.Rows.Add("", "CODIGO", "NOMBRE", "MARCA", "APLICACION", "PRECIO", "COSTO", "FACTOR", "NUMERO TECNICO", "PROVEEDOR", "FAMILIA", "SUBFAMILIA", "SUBFAMILIA 2", "ULTIMA COMPRA", "CANTIDAD ULTIMA COMPRA", "TIPO DOC.", "NRO. DOC.", "ESTADO")
        End If


        If combo_tipo.Text = "ELIMINAR SUBFAMILIAS" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Rows.Add("", "CODIGO SUBFAMILIA")
        End If

        If combo_tipo.Text = "ELIMINAR SUBFAMILIAS DOS" Then
            grilla_ejemplo.Columns.Clear()
            grilla_ejemplo.Columns.Add("", "CODIGO")
            grilla_ejemplo.Rows.Add("", "CODIGO SUBFAMILIA DOS")
        End If



    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If combo_tipo.Text = "-" Then
            combo_tipo.Focus()
            MsgBox("CAMPO TIPO ARCHIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If combo_tipo.Text = "" Then
            combo_tipo.Focus()
            MsgBox("CAMPO TIPO ARCHIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        archivo_ejemplo()

        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_ejemplo, save.FileName)
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
        For c As Integer = 0 To grilla_ejemplo.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_ejemplo.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_ejemplo.RowCount - 1
            For c As Integer = 0 To grilla_ejemplo.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_ejemplo.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub


    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
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

    Private Sub btnAbrir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbrir.GotFocus
        btnAbrir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btnAbrir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbrir.LostFocus
        btnAbrir.BackColor = Color.Transparent
    End Sub

    Private Sub combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.GotFocus
        combo_tipo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.LostFocus
        combo_tipo.BackColor = Color.White
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

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub





    Sub crear_codigo_cliente()
        'Dim varnumdoc As Integer
        'conexion.Close()
        'DS2.Tables.Clear()
        'DT2.Rows.Clear()
        'DT2.Columns.Clear()
        'DS2.Clear()
        'conexion.Open()
        'Try
        '    SC2.Connection = conexion
        '    SC2.CommandText = "select max(cod_cliente) as cod_cliente from clientes where cod_cliente >= '" & (inicio_codigo_cliente) & "'"
        '    DA2.SelectCommand = SC2
        '    DA2.Fill(DT2)
        '    DS2.Tables.Add(DT2)
        '    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
        '        varnumdoc = DS2.Tables(DT2.TableName).Rows(0).Item("cod_cliente")
        '        txt_codigo_cliente.Text = varnumdoc + 1
        '    End If
        'Catch err As InvalidCastException
        '    txt_codigo_cliente.Text = inicio_codigo_cliente
        '    Exit Sub
        'End Try
        'conexion.Close()




        Dim VarCodProducto As String

        Dim VarCodBuscar As String


        conexion.Close()
        DS1.Tables.Clear()
        DT1.Rows.Clear()
        DT1.Columns.Clear()
        DS1.Clear()
        conexion.Open()
        SC1.Connection = conexion

        SC1.CommandText = "select cod_cliente from clientes where cod_cliente >= '" & (inicio_codigo_cliente) & "' order by cod_cliente asc"

        DA1.SelectCommand = SC1
        DA1.Fill(DT1)
        DS1.Tables.Add(DT1)
        grilla.DataSource = DS1.Tables(DT1.TableName)
        conexion.Close()


        VarCodBuscar = inicio_codigo_cliente

        For i = 0 To grilla.Rows.Count - 1

            VarCodProducto = grilla.Rows(i).Cells(0).Value.ToString

            If VarCodBuscar <> VarCodProducto Then
                txt_codigo_cliente.Text = VarCodBuscar
                Exit Sub
            End If

            VarCodBuscar = VarCodBuscar + 1

        Next

        'VarCodBuscar = VarCodBuscar + 1

        txt_codigo_cliente.Text = VarCodBuscar

        Exit Sub

    End Sub

    Private Sub txtSelect_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSelect.TextChanged

    End Sub
End Class