Imports System.Data.OleDb
Imports System.IO

Public Class Form_cargar_neumaticos
    Dim sku_producto As String

    Private Sub Form_cargar_neumaticos_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cargar_neumaticos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_cargar_neumaticos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CambiaColorFondo(btn_exportar_excel, mirutempresa)
        CambiaColorFondo(btn_guardar, mirutempresa)
        CambiaColorFondo(btn_salir, mirutempresa)
        CambiaColorFondo(btnAbrir, mirutempresa)
        CambiaColorFondo(Panel3, mirutempresa)

        cargar_logo()

        combo_tipo.Items.Clear()
        combo_tipo.Items.Add("NEUMACHILE")
        combo_tipo.Items.Add("OFF ROAD")
        combo_tipo.Items.Add("LUCAS BLANDFORD")
        combo_tipo.Items.Add("CAREN")
        combo_tipo.Items.Add("NEUMATICOS Y LLANTAS DEL PACIFICO")
        combo_tipo.Items.Add("NEUMASERVICE BRIDGESTONE")
        combo_tipo.Items.Add("ACTUALIZAR DATOS")




        combo_tipo.Items.Add("STOCK - NEUMACHILE")
        combo_tipo.Items.Add("STOCK - OFF ROAD")
        combo_tipo.Items.Add("STOCK - LUCAS BLANDFORD")
        combo_tipo.Items.Add("STOCK - CAREN")
        combo_tipo.Items.Add("STOCK - NEUMATICOS Y LLANTAS DEL PACIFICO")
        combo_tipo.Items.Add("STOCK - NEUMASERVICE BRIDGESTONE")



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
            PictureBox_logo.ImageLocation = "C: \Temp\" & mirutempresa & "\Logo-formulario.png"
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






    Sub Cargar(
        ByVal dgView As DataGridView,
        ByVal SLibro As String,
        ByVal sHoja As String)

        'HDR=YES : Con encabezado  
        Dim cs As String = "Provider=Microsoft.Jet.OLEDB.4.0;" &
                           "Data Source=" & SLibro & ";" &
                           "Extended Properties=""Excel 8.0;HDR=YES"""
        Try
            ' cadena de conexión  
            Dim cn As New OleDbConnection(cs)

            If Not System.IO.File.Exists(SLibro) Then
                MsgBox("No se encontró el Libro: " &
                        SLibro, MsgBoxStyle.Critical,
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


    Sub crear_sku()

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
                sku_producto = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                sku_producto = sku_producto + 1
            End If
        Catch err As InvalidCastException
            sku_producto = 100000
            Exit Sub
        End Try
        conexion.Close()

        Dim valor As Integer
        valor = sku_producto
        sku_producto = String.Format("{0:000000}", valor)



        'inicio_sugerir_codigo = 100000
        'Dim codigo As String
        'Dim valor As Integer

        'codigo = 100001

        'valor = codigo
        'codigo = String.Format("{0:000000}", valor)

        'conexion.Close()
        'DS1.Tables.Clear()
        'DT1.Rows.Clear()
        'DT1.Columns.Clear()
        'DS1.Clear()
        'conexion.Open()
        'SC1.Connection = conexion


        ''SC1.CommandText = "select cod_producto from productos order by cod_producto asc"
        'SC1.CommandText = "select cod_producto from productos where cod_producto >= '" & (codigo) & "' order by cod_producto asc"

        'DA1.SelectCommand = SC1
        'DA1.Fill(DT1)
        'DS1.Tables.Add(DT1)
        'grilla.DataSource = DS1.Tables(DT1.TableName)
        'conexion.Close()

        'Dim VarCodProducto As String

        'codigo = inicio_sugerir_codigo

        'valor = codigo
        'codigo = String.Format("{0:000000}", valor)

        'For i = 0 To grilla.Rows.Count - 1

        '    VarCodProducto = grilla.Rows(i).Cells(0).Value.ToString

        '    If codigo <> VarCodProducto Then
        '        sku_producto = codigo

        '        lbl_mensaje.Visible = False
        '        Me.Enabled = True



        '        Exit Sub
        '    End If

        '    codigo = codigo + 1
        '    valor = codigo
        '    codigo = String.Format("{0:000000}", valor)


        'Next

        'sku_producto = codigo

        'codigo = codigo + 1
        'valor = codigo
        'codigo = String.Format("{0:000000}", valor)


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




        Dim stock As String = ""
        Dim nombre As String = ""
        Dim precio As String = ""
        Dim marca As String = ""
        Dim origen As String = ""
        Dim sku_proveedor As String = ""
        Dim rut_proveedor As String = ""
        Dim indice_de_velocidad As String = ""
        Dim indice_de_carga As String = ""
        Dim Tipo_neumatico As String = ""
        Dim Medida_neumatico As String = ""
        Dim Modelo As String = ""
        Dim costo As String = ""

        Dim precio_oferta As String = ""
        Dim descuento As String = ""
        Dim precio_normal As String = ""
        Dim medida_aro As String = ""
        Dim peso_volumetrico As String = ""

        If combo_tipo.Text = "STOCK - NEUMASERVICE BRIDGESTONE" Then
            rut_proveedor = "76988976-0"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `productos` SET  `cantidad`='0' WHERE proveedor = '" & (rut_proveedor) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            For i = 0 To grilla_excel.Rows.Count - 1
                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                stock = grilla_excel.Rows(i).Cells(1).Value.ToString

                If sku_proveedor = "" Then
                    Exit Sub
                End If

                If stock = "-" Then
                    stock = "0"
                End If

                If stock = "" Then
                    stock = "0"
                End If

                ''If stock < 6 Then
                ''    stock = "0"
                ''End If

                ''If stock = "DISPONIBLE" Then
                ''    stock = "40"
                ''End If

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos` SET  `cantidad`='" & (stock) & "' WHERE numero_tecnico = '" & (sku_proveedor) & "' and proveedor='" & (rut_proveedor) & "' and cod_producto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next

        End If

        If combo_tipo.Text = "STOCK - LUCAS BLANDFORD MICHELIN" Then
            rut_proveedor = "92606000-7"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `productos` SET  `cantidad`='0' WHERE proveedor = '" & (rut_proveedor) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            For i = 0 To grilla_excel.Rows.Count - 1
                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                marca = grilla_excel.Rows(i).Cells(1).Value.ToString
                stock = grilla_excel.Rows(i).Cells(2).Value.ToString

                If sku_proveedor = "" Then
                    Exit Sub
                End If

                If marca.Length > 2 Then
                    marca = marca.Substring(0, 2)
                End If

                sku_proveedor = marca & sku_proveedor

                If stock = "" Then
                    stock = "0"
                End If

                If stock < 6 Then
                    stock = "0"
                End If

                If stock = "DISPONIBLE" Then
                    stock = "40"
                End If

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos` SET  `cantidad`='" & (stock) & "' WHERE numero_tecnico = '" & (sku_proveedor) & "' and proveedor='" & (rut_proveedor) & "' and cod_producto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next

        End If

        If combo_tipo.Text = "STOCK - LUCAS BLANDFORD MICHELIN" Then
            rut_proveedor = "92606000-7"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `productos` SET  `cantidad`='0' WHERE proveedor = '" & (rut_proveedor) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            For i = 0 To grilla_excel.Rows.Count - 1
                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                marca = grilla_excel.Rows(i).Cells(1).Value.ToString
                stock = grilla_excel.Rows(i).Cells(2).Value.ToString

                If sku_proveedor = "" Then
                    Exit Sub
                End If

                If marca.Length > 2 Then
                    marca = marca.Substring(0, 2)
                End If

                sku_proveedor = marca & sku_proveedor

                If stock = "" Then
                    stock = "0"
                End If

                If stock < 6 Then
                    stock = "0"
                End If

                If stock = "DISPONIBLE" Then
                    stock = "40"
                End If

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos` SET  `cantidad`='" & (stock) & "' WHERE numero_tecnico = '" & (sku_proveedor) & "' and proveedor='" & (rut_proveedor) & "' and cod_producto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next

        End If


        If combo_tipo.Text = "STOCK - LUCAS BLANDFORD INTERNA" Then
            rut_proveedor = "92606000-7"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `productos` SET  `cantidad`='0' WHERE proveedor = '" & (rut_proveedor) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            For i = 0 To grilla_excel.Rows.Count - 1
                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                stock = grilla_excel.Rows(i).Cells(1).Value.ToString

                If sku_proveedor = "" Then
                    Exit Sub
                End If

                If stock = "" Then
                    stock = "0"
                End If

                If stock < 6 Then
                    stock = "0"
                End If

                If stock = "DISPONIBLE" Then
                    stock = "40"
                End If

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos` SET  `cantidad`='" & (stock) & "' WHERE numero_tecnico = '" & (sku_proveedor) & "' and proveedor='" & (rut_proveedor) & "' and cod_producto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next

        End If


        If combo_tipo.Text = "STOCK - NEUMATICOS Y LLANTAS DEL PACIFICO" Then
            rut_proveedor = "77435230-9"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `productos` SET  `cantidad`='0' WHERE proveedor = '" & (rut_proveedor) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            For i = 0 To grilla_excel.Rows.Count - 1
                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                stock = grilla_excel.Rows(i).Cells(1).Value.ToString
                costo = grilla_excel.Rows(i).Cells(2).Value.ToString

                If sku_proveedor = "" Then
                    Exit Sub
                End If

                If stock = "" Then
                    stock = "0"
                End If

                If stock < 6 Then
                    stock = "0"
                End If

                If stock = "DISPONIBLE" Then
                    stock = "40"
                End If

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos` SET  `cantidad`='" & (stock) & "', `costo`='" & (costo) & "' WHERE numero_tecnico = '" & (sku_proveedor) & "' and proveedor='" & (rut_proveedor) & "' and cod_producto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next

        End If

        If combo_tipo.Text = "STOCK - NEUMACHILE" Then
            rut_proveedor = "79634430-K"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `productos` SET  `cantidad`='0' WHERE proveedor = '" & (rut_proveedor) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            For i = 0 To grilla_excel.Rows.Count - 1
                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                stock = grilla_excel.Rows(i).Cells(1).Value.ToString
                costo = grilla_excel.Rows(i).Cells(2).Value.ToString

                If sku_proveedor = "" Then
                    Exit Sub
                End If

                If stock = "" Then
                    stock = "0"
                End If

                If stock < 6 Then
                    stock = "0"
                End If

                If stock = "DISPONIBLE" Then
                    stock = "40"
                End If

                If sku_proveedor = "112492" Then
                    MsgBox("ddd")
                End If

                costo = Int(costo)

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos` SET  `cantidad`='" & (stock) & "', `costo`='" & (costo) & "' WHERE numero_tecnico = '" & (sku_proveedor) & "' and proveedor='" & (rut_proveedor) & "' and cod_producto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next

        End If

        If combo_tipo.Text = "STOCK - OFF ROAD" Then
            rut_proveedor = "76943150-0"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `productos` SET  `cantidad`='0' WHERE proveedor = '" & (rut_proveedor) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            For i = 0 To grilla_excel.Rows.Count - 1
                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                stock = grilla_excel.Rows(i).Cells(1).Value.ToString
                costo = grilla_excel.Rows(i).Cells(2).Value.ToString

                If sku_proveedor = "" Then
                    Exit Sub
                End If

                If stock = "" Then
                    stock = "0"
                End If

                If stock < 6 Then
                    stock = "0"
                End If

                If stock = "DISPONIBLE" Then
                    stock = "40"
                End If


                costo = Int(costo)

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos` SET  `cantidad`='" & (stock) & "', `costo`='" & (costo) & "' WHERE numero_tecnico = '" & (sku_proveedor) & "' and proveedor='" & (rut_proveedor) & "' and cod_producto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next

        End If

        If combo_tipo.Text = "STOCK - CAREN" Then
            rut_proveedor = "96794750-4"

            SC.Connection = conexion
            SC.CommandText = "UPDATE `productos` SET  `cantidad`='0' WHERE proveedor = '" & (rut_proveedor) & "';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            For i = 0 To grilla_excel.Rows.Count - 1
                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                stock = grilla_excel.Rows(i).Cells(1).Value.ToString
                costo = grilla_excel.Rows(i).Cells(2).Value.ToString

                If sku_proveedor = "" Then
                    Exit Sub
                End If

                If stock = "" Then
                    stock = "0"
                End If

                If stock < 6 Then
                    stock = "0"
                End If


                If stock = "DISPONIBLE" Then
                    stock = "40"
                End If

                costo = Int(costo)

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos` SET  `cantidad`='" & (stock) & "', `costo`='" & (costo) & "' WHERE numero_tecnico = '" & (sku_proveedor) & "' and proveedor='" & (rut_proveedor) & "' and cod_producto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next

        End If

        If combo_tipo.Text = "ACTUALIZAR DATOS" Then


            lbl_mensaje.Visible = True
            Me.Enabled = False

            Dim medida As String = ""
            'Dim modelo As String = ""
            Dim tipo As String = ""
            'Dim costo As String = ""
            Dim nombre_familia As String = ""
            Dim codigo_familia As String = ""
            Dim precio_final As String = ""
            Dim aro As String = ""
            'Dim peso_volumetrico As String = ""

            For i = 0 To grilla_excel.Rows.Count - 1

                sku_producto = grilla_excel.Rows(i).Cells(0).Value.ToString
                sku_proveedor = grilla_excel.Rows(i).Cells(1).Value.ToString
                medida = grilla_excel.Rows(i).Cells(2).Value.ToString
                aro = grilla_excel.Rows(i).Cells(3).Value.ToString
                Modelo = grilla_excel.Rows(i).Cells(4).Value.ToString
                marca = grilla_excel.Rows(i).Cells(5).Value.ToString
                indice_de_velocidad = grilla_excel.Rows(i).Cells(6).Value.ToString
                indice_de_carga = grilla_excel.Rows(i).Cells(7).Value.ToString
                tipo = grilla_excel.Rows(i).Cells(8).Value.ToString
                costo = grilla_excel.Rows(i).Cells(9).Value.ToString
                nombre_familia = grilla_excel.Rows(i).Cells(10).Value.ToString
                codigo_familia = grilla_excel.Rows(i).Cells(11).Value.ToString
                precio_final = grilla_excel.Rows(i).Cells(12).Value.ToString
                descuento = grilla_excel.Rows(i).Cells(13).Value.ToString
                precio_normal = grilla_excel.Rows(i).Cells(14).Value.ToString
                peso_volumetrico = grilla_excel.Rows(i).Cells(16).Value.ToString


                sku_proveedor = UCase(sku_proveedor)
                medida = UCase(medida)
                Modelo = UCase(Modelo)
                marca = UCase(marca)
                indice_de_velocidad = UCase(indice_de_velocidad)
                indice_de_carga = UCase(indice_de_carga)
                tipo = UCase(tipo)

                costo = Val(costo)
                precio_final = Val(precio_final)
                descuento = Val(descuento)
                precio_normal = Val(precio_normal)

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos` SET  `marca`='" & (marca) & "', `nombre`='" & (Modelo) & "', `aplicacion`='" & (medida) & "', `costo`='" & (costo) & "', `precio_normal`='" & (precio_normal) & "', `porcentaje_descuento`='" & (descuento) & "', `precio`='" & (precio_final) & "', `familia`='" & (codigo_familia) & "' WHERE cod_producto = '" & (sku_producto) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "UPDATE `productos_neumaticos` SET  `medida`='" & (medida) & "', `aro`='" & (aro) & "', `peso_volumetrico`='" & (peso_volumetrico) & "', `modelo`='" & (Modelo) & "', `marca`='" & (marca) & "', `indice_de_velocidad`='" & (indice_de_velocidad) & "', `indice_de_carga`='" & (indice_de_carga) & "' , `tipo`='" & (tipo) & "' WHERE cod_producto = '" & (sku_producto) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Next




        End If







        grilla_medidas()









        If combo_tipo.Text = "NEUMASERVICE BRIDGESTONE" Then

            rut_proveedor = "76988976-0"

            lbl_mensaje.Visible = True
            Me.Enabled = False


            For i = 0 To grilla_excel.Rows.Count - 1

                Medida_neumatico = grilla_excel.Rows(i).Cells(1).Value.ToString
                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(6).Value.ToString & " " & grilla_excel.Rows(i).Cells(7).Value.ToString & " " & grilla_excel.Rows(i).Cells(8).Value.ToString
                Modelo = grilla_excel.Rows(i).Cells(7).Value.ToString & " " & grilla_excel.Rows(i).Cells(8).Value.ToString
                marca = grilla_excel.Rows(i).Cells(6).Value.ToString
                indice_de_carga = grilla_excel.Rows(i).Cells(12).Value.ToString
                indice_de_velocidad = grilla_excel.Rows(i).Cells(14).Value.ToString
                Tipo_neumatico = grilla_excel.Rows(i).Cells(9).Value.ToString
                precio = grilla_excel.Rows(i).Cells(25).Value.ToString
                costo = grilla_excel.Rows(i).Cells(19).Value.ToString
                medida_aro = grilla_excel.Rows(i).Cells(2).Value.ToString


                descuento = grilla_excel.Rows(i).Cells(26).Value.ToString
                precio_normal = grilla_excel.Rows(i).Cells(27).Value.ToString

                stock = "0"

                precio = Int(precio)
                costo = Int(costo)


                nombre = UCase(nombre)
                Modelo = UCase(Modelo)
                marca = UCase(marca)
                indice_de_carga = UCase(indice_de_carga)
                indice_de_velocidad = UCase(indice_de_velocidad)

                nombre = nombre.Replace("  ", " ")
                Modelo = Modelo.Replace("  ", " ")
                marca = marca.Replace("  ", " ")
                indice_de_carga = indice_de_carga.Replace("  ", " ")
                indice_de_velocidad = indice_de_velocidad.Replace("  ", " ")


                nombre = LTrim(nombre)
                nombre = RTrim(nombre)

                Modelo = LTrim(Modelo)
                Modelo = RTrim(Modelo)

                marca = LTrim(marca)
                marca = RTrim(marca)

                indice_de_carga = LTrim(indice_de_carga)
                indice_de_carga = RTrim(indice_de_carga)

                indice_de_velocidad = LTrim(indice_de_velocidad)
                indice_de_velocidad = RTrim(indice_de_velocidad)


                If stock = "" Then
                    stock = 0
                End If

                If stock < 8 Then
                    stock = 0
                End If

                If stock = "DISPONIBLE" Then
                    stock = 50
                End If


                conexion.Close()
                Consultas_SQL("select * from productos where proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE `productos` SET `cantidad`='" & (stock) & "', `costo`='" & (costo) & "' WHERE proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "';"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                Else

                    crear_sku()

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `productos` (cod_producto, nombre, cantidad, costo, precio, porcentaje_descuento, precio_normal, proveedor, marca, numero_tecnico, aplicacion, usuario_responsable, fecha_modificacion) VALUES ('" & (sku_producto) & "', '" & (Modelo) & "', '" & (stock) & "',  '" & (costo) & "', '" & (precio) & "', '" & (rut_proveedor) & "', '" & (marca) & "', '" & (sku_proveedor) & "', '" & (Medida_neumatico) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `bd_neumapro`.`productos_neumaticos` (`cod_producto`, cod_proveedor, `medida`, `aro`,  `modelo`, `marca`, `indice_de_velocidad`, `indice_de_carga`, `tipo`, `proveedor`) VALUES ('" & (sku_producto) & "', '" & (sku_proveedor) & "', '" & (Medida_neumatico) & "',  '" & (medida_aro) & "', '" & (Modelo) & "', '" & (marca) & "', '" & (indice_de_velocidad) & "', '" & (indice_de_carga) & "', '" & (Tipo_neumatico) & "', '" & (rut_proveedor) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                End If

            Next
        End If



        If combo_tipo.Text = "NEUMATICOS Y LLANTAS DEL PACIFICO" Then

            rut_proveedor = "77435230-9"

            lbl_mensaje.Visible = True
            Me.Enabled = False


            For i = 0 To grilla_excel.Rows.Count - 1

                Medida_neumatico = grilla_excel.Rows(i).Cells(0).Value.ToString
                sku_proveedor = grilla_excel.Rows(i).Cells(1).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(2).Value.ToString
                Modelo = grilla_excel.Rows(i).Cells(3).Value.ToString
                marca = grilla_excel.Rows(i).Cells(4).Value.ToString
                indice_de_carga = grilla_excel.Rows(i).Cells(5).Value.ToString
                indice_de_velocidad = grilla_excel.Rows(i).Cells(6).Value.ToString
                Tipo_neumatico = grilla_excel.Rows(i).Cells(8).Value.ToString
                precio = grilla_excel.Rows(i).Cells(10).Value.ToString
                stock = "0"

                nombre = UCase(nombre)
                Modelo = UCase(Modelo)
                marca = UCase(marca)
                indice_de_carga = UCase(indice_de_carga)
                indice_de_velocidad = UCase(indice_de_velocidad)

                nombre = nombre.Replace("  ", " ")
                Modelo = Modelo.Replace("  ", " ")
                marca = marca.Replace("  ", " ")
                indice_de_carga = indice_de_carga.Replace("  ", " ")
                indice_de_velocidad = indice_de_velocidad.Replace("  ", " ")





                nombre = LTrim(nombre)
                nombre = RTrim(nombre)

                Modelo = LTrim(Modelo)
                Modelo = RTrim(Modelo)

                marca = LTrim(marca)
                marca = RTrim(marca)

                indice_de_carga = LTrim(indice_de_carga)
                indice_de_carga = RTrim(indice_de_carga)

                indice_de_velocidad = LTrim(indice_de_velocidad)
                indice_de_velocidad = RTrim(indice_de_velocidad)






                If stock = "" Then
                    stock = 0
                End If

                If stock < 8 Then
                    stock = 0
                End If

                If stock = "DISPONIBLE" Then
                    stock = 50
                End If




                indice_de_velocidad = ""

                For indice = 0 To 200


                    nombre = nombre.Replace("palabras", " ")
                    nombre = nombre.Replace("DSM413756", " ")
                    nombre = nombre.Replace("77 T", " ")
                    nombre = nombre.Replace("VER", " ")
                    nombre = nombre.Replace("CODI:111622", " ")
                    nombre = nombre.Replace("GOODDRIDE", " ")
                    nombre = nombre.Replace("GODDRIDE", " ")
                    nombre = nombre.Replace("DDRIDE", " ")
                    nombre = nombre.Replace(" STD ", " ")
                    nombre = nombre.Replace("DSM494228", " ")
                    nombre = nombre.Replace("AUTOGUARD", " ")
                    nombre = nombre.Replace("88H", " ")
                    nombre = nombre.Replace("88 H", " ")
                    nombre = nombre.Replace("DESC", " ")
                    nombre = nombre.Replace("A/T", " ")
                    nombre = nombre.Replace("DSM095898", " ")
                    nombre = nombre.Replace(" Z ", " ")
                    nombre = nombre.Replace("12PR", " ")
                    nombre = nombre.Replace("M/T", " ")
                    nombre = nombre.Replace("H/T", " ")
                    nombre = nombre.Replace(" Y ", " ")
                    nombre = nombre.Replace("DSRE.M079690", " ")
                    nombre = nombre.Replace("DSRE.M079690", " ")
                    nombre = nombre.Replace("DSRE.M446848", " ")
                    nombre = nombre.Replace("DSM102881", " ")
                    nombre = nombre.Replace("100/H", " ")
                    nombre = nombre.Replace("DSM641532", " ")
                    nombre = nombre.Replace("DSM085753", " ")
                    nombre = nombre.Replace("REM780164", " ")
                    nombre = nombre.Replace("M604092", " ")
                    nombre = nombre.Replace("DSM950525", " ")
                    nombre = nombre.Replace("DSREMM350721", " ")
                    nombre = nombre.Replace("NEUM.", " ")
                    nombre = nombre.Replace("6PR", " ")
                    nombre = nombre.Replace("8PR", " ")
                    nombre = nombre.Replace(" TL ", " ")
                    nombre = nombre.Replace(" LL ", " ")
                    nombre = nombre.Replace("10PR", " ")
                    nombre = nombre.Replace("4PR", " ")
                    nombre = nombre.Replace("(", " ")
                    nombre = nombre.Replace(")", " ")
                    nombre = nombre.Replace("New", " ")
                    nombre = nombre.Replace(" OE ", " ")
                    nombre = nombre.Replace("PORTER", " ")
                    nombre = nombre.Replace("(VERCODIGO:111622)", " ")
                    nombre = nombre.Replace("(TE301)", " ")
                    nombre = nombre.Replace(" STD ", " ")
                    nombre = nombre.Replace("(DS)M494228", " ")
                    nombre = nombre.Replace("*", " ")
                    nombre = nombre.Replace("(PARANIEVE)", " ")
                    nombre = nombre.Replace("(DESC)", " ")
                    nombre = nombre.Replace("(dsm095898)", " ")
                    nombre = nombre.Replace(" MI ", " ")
                    nombre = nombre.Replace(" BR ", " ")
                    nombre = nombre.Replace(" UL ", " ")
                    nombre = nombre.Replace("(DS)", " ")
                    nombre = nombre.Replace("VERM015289", " ")
                    nombre = nombre.Replace("XL", " ")
                    nombre = nombre.Replace("re.M079690", " ")
                    nombre = nombre.Replace(" LRC ", " ")
                    nombre = nombre.Replace(" GO ", " ")
                    nombre = nombre.Replace(" OWL ", " ")
                    nombre = nombre.Replace(" RO ", " ")
                    nombre = nombre.Replace(" MOE ", " ")
                    nombre = nombre.Replace("@", " ")
                    nombre = nombre.Replace("(D)", " ")
                    nombre = nombre.Replace("BCT", " ")
                    nombre = nombre.Replace("GOODYEAR", " ")
                    nombre = nombre.Replace("MAXXIS", " ")
                    nombre = nombre.Replace("APTANY", " ")
                    nombre = nombre.Replace("ATLAS", " ")
                    nombre = nombre.Replace("BFGOODRICH", " ")
                    nombre = nombre.Replace("BRIDGESTONE", " ")
                    nombre = nombre.Replace("CATCHLAND", " ")
                    nombre = nombre.Replace("CONTINENTAL", " ")
                    nombre = nombre.Replace("FEDERAL", " ")
                    nombre = nombre.Replace("GOODRIDE", " ")
                    nombre = nombre.Replace("GOODRIDETBR", " ")
                    nombre = nombre.Replace("GOODYEAR", " ")
                    nombre = nombre.Replace("LINGLONG", " ")
                    nombre = nombre.Replace("MICHELIN", " ")
                    nombre = nombre.Replace("NEXEN", " ")
                    nombre = nombre.Replace("ONYXPCR", " ")
                    nombre = nombre.Replace("OTRA", " ")
                    nombre = nombre.Replace("OTRASSALDOS", " ")
                    nombre = nombre.Replace("PIRELLIAUTO", " ")
                    nombre = nombre.Replace("ROADCLAW", " ")
                    nombre = nombre.Replace("SONAR", " ")
                    nombre = nombre.Replace("SUMITOMO", " ")
                    nombre = nombre.Replace("SUNNY", " ")
                    nombre = nombre.Replace("TRACMAX", " ")
                    nombre = nombre.Replace("TRIANGLE", " ")
                    nombre = nombre.Replace("WINDFORCE", " ")
                    nombre = nombre.Replace("WINRUN", " ")
                    nombre = nombre.Replace("YOKOHAMA", " ")
                    nombre = nombre.Replace(" TL", " ")
                    nombre = nombre.Replace(" UL", " ")
                    nombre = nombre.Replace("C ", " ")
                    nombre = nombre.Replace(" OE", " ")
                    nombre = nombre.Replace(" PCR", " ")
                    nombre = nombre.Replace(" MOE", " ")
                    nombre = nombre.Replace(" LL", " ")
                    nombre = nombre.Replace("CODIGO:111622", " ")
                    nombre = nombre.Replace("NEW", " ")







                    If nombre.Contains(indice & "A1 ") Then
                        indice_de_velocidad = indice & "A1"
                        nombre = nombre.Replace(" " & indice & "A1 ", " ")
                    End If


                    If nombre.Contains(indice & "A2 ") Then
                        indice_de_velocidad = indice & "A2"
                        nombre = nombre.Replace(" " & indice & "A2 ", " ")
                    End If


                    If nombre.Contains(indice & "A3 ") Then
                        indice_de_velocidad = indice & "A3"
                        nombre = nombre.Replace(" " & indice & "A3 ", " ")
                    End If


                    If nombre.Contains(indice & "A4 ") Then
                        indice_de_velocidad = indice & "A4"
                        nombre = nombre.Replace(" " & indice & "A4 ", " ")
                    End If

                    If nombre.Contains(indice & "A5 ") Then
                        indice_de_velocidad = indice & "A5"
                        nombre = nombre.Replace(" " & indice & "A5 ", " ")
                    End If

                    If nombre.Contains(indice & "A6 ") Then
                        indice_de_velocidad = indice & "A6"
                        nombre = nombre.Replace(" " & indice & "A6 ", " ")
                    End If

                    If nombre.Contains(indice & "A7 ") Then
                        indice_de_velocidad = indice & "A7"
                        nombre = nombre.Replace(" " & indice & "A7 ", " ")
                    End If

                    If nombre.Contains(indice & "A8 ") Then
                        indice_de_velocidad = indice & "A8"
                        nombre = nombre.Replace(" " & indice & "A8 ", " ")
                    End If






                    If nombre.Contains(indice & "A ") Then
                        indice_de_velocidad = indice & "A"
                        nombre = nombre.Replace(" " & indice & "A ", " ")
                    End If

                    If nombre.Contains(indice & "B ") Then
                        indice_de_velocidad = indice & "B"
                        nombre = nombre.Replace(" " & indice & "B ", " ")
                    End If

                    If nombre.Contains(indice & "C ") Then
                        indice_de_velocidad = indice & "C"
                        nombre = nombre.Replace(" " & indice & "C ", " ")
                    End If

                    If nombre.Contains(indice & "D ") Then
                        indice_de_velocidad = indice & "D"
                        nombre = nombre.Replace(" " & indice & "D ", " ")
                    End If


                    If nombre.Contains(indice & "E ") Then
                        indice_de_velocidad = indice & "E"
                        nombre = nombre.Replace(" " & indice & "E ", " ")
                    End If


                    If nombre.Contains(indice & "F ") Then
                        indice_de_velocidad = indice & "F"
                        nombre = nombre.Replace(" " & indice & "F ", " ")
                    End If


                    If nombre.Contains(indice & "G ") Then
                        indice_de_velocidad = indice & "G"
                        nombre = nombre.Replace(" " & indice & "G ", " ")
                    End If


                    If nombre.Contains(indice & "H ") Then
                        indice_de_velocidad = indice & "H"
                        nombre = nombre.Replace(" " & indice & "H ", " ")
                    End If

                    If nombre.Contains(indice & "I ") Then
                        indice_de_velocidad = indice & "I"
                        nombre = nombre.Replace(" " & indice & "I ", " ")
                    End If

                    If nombre.Contains(indice & "J ") Then
                        indice_de_velocidad = indice & "J"
                        nombre = nombre.Replace(" " & indice & "J ", " ")
                    End If


                    If nombre.Contains(indice & "K ") Then
                        indice_de_velocidad = indice & "K"
                        nombre = nombre.Replace(" " & indice & "K ", " ")
                    End If


                    If nombre.Contains(indice & "L ") Then
                        indice_de_velocidad = indice & "L"
                        nombre = nombre.Replace(" " & indice & "L ", " ")
                    End If


                    If nombre.Contains(indice & "M ") Then
                        indice_de_velocidad = indice & "M"
                        nombre = nombre.Replace(" " & indice & "M ", " ")
                    End If


                    If nombre.Contains(indice & "N ") Then
                        indice_de_velocidad = indice & "N"
                        nombre = nombre.Replace(" " & indice & "N ", " ")
                    End If


                    If nombre.Contains(indice & "O ") Then
                        indice_de_velocidad = indice & "O"
                        nombre = nombre.Replace(" " & indice & "O ", " ")
                    End If

                    If nombre.Contains(indice & "P ") Then
                        indice_de_velocidad = indice & "P"
                        nombre = nombre.Replace(" " & indice & "P ", " ")
                    End If


                    If nombre.Contains(indice & "Q ") Then
                        indice_de_velocidad = indice & "Q"
                        nombre = nombre.Replace(" " & indice & "Q ", " ")
                    End If


                    If nombre.Contains(indice & "R ") Then
                        indice_de_velocidad = indice & "R"
                        nombre = nombre.Replace(" " & indice & "R ", " ")
                    End If


                    If nombre.Contains(indice & "S ") Then
                        indice_de_velocidad = indice & "S"
                        nombre = nombre.Replace(" " & indice & "S ", " ")
                    End If


                    If nombre.Contains(indice & "T ") Then
                        indice_de_velocidad = indice & "T"
                        nombre = nombre.Replace(" " & indice & "T ", " ")
                    End If


                    If nombre.Contains(indice & "U ") Then
                        indice_de_velocidad = indice & "U"
                        nombre = nombre.Replace(" " & indice & "U ", " ")
                    End If


                    If nombre.Contains(indice & "H ") Then
                        indice_de_velocidad = indice & "H"
                        nombre = nombre.Replace(" " & indice & "H ", " ")
                    End If

                    If nombre.Contains(indice & "V ") Then
                        indice_de_velocidad = indice & "V"
                        nombre = nombre.Replace(" " & indice & "V ", " ")
                    End If

                    If nombre.Contains(indice & "ZR ") Then
                        indice_de_velocidad = indice & "ZR"
                        nombre = nombre.Replace(" " & indice & "ZR ", " ")
                    End If

                    If nombre.Contains(indice & "W ") Then
                        indice_de_velocidad = indice & "W"
                        nombre = nombre.Replace(" " & indice & "W ", " ")
                    End If

                    If nombre.Contains(indice & "X ") Then
                        indice_de_velocidad = indice & "X"
                        nombre = nombre.Replace(" " & indice & "X ", " ")
                    End If

                    If nombre.Contains(indice & "Y ") Then
                        indice_de_velocidad = indice & "Y"
                        nombre = nombre.Replace(" " & indice & "Y ", " ")
                    End If

                    If nombre.Contains(indice & "Z ") Then
                        indice_de_velocidad = indice & "Z"
                        nombre = nombre.Replace(" " & indice & "Z ", " ")
                    End If
                Next


                indice_de_carga = ""

                If indice_de_velocidad <> "" Then

                    indice_de_carga = indice_de_velocidad

                    If indice_de_carga.Contains("A") Then
                        indice_de_carga = indice_de_carga.Replace("A", "")
                    End If
                    If indice_de_carga.Contains("B") Then
                        indice_de_carga = indice_de_carga.Replace("B", "")
                    End If
                    If indice_de_carga.Contains("C") Then
                        indice_de_carga = indice_de_carga.Replace("C", "")
                    End If
                    If indice_de_carga.Contains("D") Then
                        indice_de_carga = indice_de_carga.Replace("D", "")
                    End If
                    If indice_de_carga.Contains("E") Then
                        indice_de_carga = indice_de_carga.Replace("E", "")
                    End If
                    If indice_de_carga.Contains("F") Then
                        indice_de_carga = indice_de_carga.Replace("F", "")
                    End If
                    If indice_de_carga.Contains("G") Then
                        indice_de_carga = indice_de_carga.Replace("G", "")
                    End If
                    If indice_de_carga.Contains("H") Then
                        indice_de_carga = indice_de_carga.Replace("H", "")
                    End If
                    If indice_de_carga.Contains("I") Then
                        indice_de_carga = indice_de_carga.Replace("I", "")
                    End If
                    If indice_de_carga.Contains("J") Then
                        indice_de_carga = indice_de_carga.Replace("J", "")
                    End If
                    If indice_de_carga.Contains("K") Then
                        indice_de_carga = indice_de_carga.Replace("K", "")
                    End If
                    If indice_de_carga.Contains("L") Then
                        indice_de_carga = indice_de_carga.Replace("L", "")
                    End If
                    If indice_de_carga.Contains("M") Then
                        indice_de_carga = indice_de_carga.Replace("M", "")
                    End If
                    If indice_de_carga.Contains("N") Then
                        indice_de_carga = indice_de_carga.Replace("N", "")
                    End If
                    If indice_de_carga.Contains("O") Then
                        indice_de_carga = indice_de_carga.Replace("O", "")
                    End If
                    If indice_de_carga.Contains("P") Then
                        indice_de_carga = indice_de_carga.Replace("P", "")
                    End If
                    If indice_de_carga.Contains("Q") Then
                        indice_de_carga = indice_de_carga.Replace("Q", "")
                    End If
                    If indice_de_carga.Contains("R") Then
                        indice_de_carga = indice_de_carga.Replace("R", "")
                    End If
                    If indice_de_carga.Contains("S") Then
                        indice_de_carga = indice_de_carga.Replace("S", "")
                    End If
                    If indice_de_carga.Contains("T") Then
                        indice_de_carga = indice_de_carga.Replace("T", "")
                    End If
                    If indice_de_carga.Contains("U") Then
                        indice_de_carga = indice_de_carga.Replace("U", "")
                    End If
                    If indice_de_carga.Contains("V") Then
                        indice_de_carga = indice_de_carga.Replace("V", "")
                    End If
                    If indice_de_carga.Contains("W") Then
                        indice_de_carga = indice_de_carga.Replace("W", "")
                    End If
                    If indice_de_carga.Contains("X") Then
                        indice_de_carga = indice_de_carga.Replace("X", "")
                    End If
                    If indice_de_carga.Contains("Y") Then
                        indice_de_carga = indice_de_carga.Replace("Y", "")
                    End If
                    If indice_de_carga.Contains("Z") Then
                        indice_de_carga = indice_de_carga.Replace("Z", "")
                    End If
                End If







                If indice_de_velocidad <> "" Then

                    If indice_de_velocidad.Contains("0") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("0", "")
                    End If

                    If indice_de_velocidad.Contains("1") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("1", "")
                    End If

                    If indice_de_velocidad.Contains("2") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("2", "")
                    End If

                    If indice_de_velocidad.Contains("3") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("3", "")
                    End If

                    If indice_de_velocidad.Contains("4") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("4", "")
                    End If

                    If indice_de_velocidad.Contains("5") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("5", "")
                    End If

                    If indice_de_velocidad.Contains("6") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("6", "")
                    End If

                    If indice_de_velocidad.Contains("7") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("7", "")
                    End If

                    If indice_de_velocidad.Contains("8") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("8", "")
                    End If

                    If indice_de_velocidad.Contains("9") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("9", "")
                    End If

                End If




                For aro = 0 To 30
                    nombre = Replace(nombre, " R " & aro, "R" & aro)
                    nombre = Replace(nombre, "R " & aro, "R" & aro)
                    nombre = Replace(nombre, " R" & aro, "R" & aro)
                Next







                Dim nombre_medida As String = ""
                For m = 0 To grilla_medida.Rows.Count - 1
                    nombre_medida = grilla_medida.Rows(m).Cells(0).Value.ToString

                    If nombre.Contains(nombre_medida) Then
                        medida_neumatico = nombre_medida
                    End If

                    nombre = nombre.Replace(nombre_medida, "")

                Next




                nombre = Replace(nombre, "'", "")
                nombre = Replace(nombre, "  ", " ")
                nombre = Replace(nombre, "   ", " ")
                nombre = Replace(nombre, "    ", " ")
                nombre = Replace(nombre, "     ", " ")
                nombre = Replace(nombre, "      ", " ")
                nombre = Replace(nombre, "       ", " ")
                nombre = Replace(nombre, "        ", " ")
                nombre = LTrim(nombre)
                nombre = RTrim(nombre)








                nombre = nombre.Replace("88/86Q", "")
                nombre = nombre.Replace("85/83Q", "")
                nombre = nombre.Replace("83/81Q", "")
                nombre = nombre.Replace("88/86Q", "")
                nombre = nombre.Replace("112/110 R", "")
                nombre = nombre.Replace("89/87R", "")
                nombre = nombre.Replace("89/87", "")
                nombre = nombre.Replace("98/96Q", "")
                nombre = nombre.Replace("101/99Q", "")
                nombre = nombre.Replace("103/102R", "")
                nombre = nombre.Replace("102/100R", "")
                nombre = nombre.Replace("106/104R", "")
                nombre = nombre.Replace("104/102R", "")
                nombre = nombre.Replace("107/105R", "")
                nombre = nombre.Replace("114/112L", "")
                nombre = nombre.Replace("110/108S", "")
                nombre = nombre.Replace("107/105T", "")
                nombre = nombre.Replace("104/102T", "")
                nombre = nombre.Replace("110/10R", "")
                nombre = nombre.Replace("112/110Q", "")
                nombre = nombre.Replace("109/107T", "")
                nombre = nombre.Replace("109/107S", "")
                nombre = nombre.Replace("109/107R", "")
                nombre = nombre.Replace("109/107", "")
                nombre = nombre.Replace("10/106T", "")
                nombre = nombre.Replace("100/97Q", "")
                nombre = nombre.Replace("113/111R", "")
                nombre = nombre.Replace("112/110R", "")
                nombre = nombre.Replace("102/99S", "")
                nombre = nombre.Replace("115/112S", "")
                nombre = nombre.Replace("118/116R", "")
                nombre = nombre.Replace("115/1123R", "")
                nombre = nombre.Replace("115/113R", "")
                nombre = nombre.Replace("104/101S", "")
                nombre = nombre.Replace("110/107Q", "")
                nombre = nombre.Replace("116/113S", "")
                nombre = nombre.Replace("104/101Q", "")
                nombre = nombre.Replace("104/101R", "")
                nombre = nombre.Replace("120/116Q", "")
                nombre = nombre.Replace("120/116S", "")
                nombre = nombre.Replace("120/116SS", "")
                nombre = nombre.Replace("120/116Q", "")
                nombre = nombre.Replace("113/110S", "")
                nombre = nombre.Replace("119/116S", "")
                nombre = nombre.Replace("119/116Q", "")
                nombre = nombre.Replace("120/116S", "")
                nombre = nombre.Replace("120/116Q", "")
                nombre = nombre.Replace("120/116R", "")
                nombre = nombre.Replace("120/116S", "")
                nombre = nombre.Replace("121/118S", "")
                nombre = nombre.Replace("112/110S", "")
                nombre = nombre.Replace("119/116S", "")
                nombre = nombre.Replace("121/118S", "")
                nombre = nombre.Replace("120/117S", "")
                nombre = nombre.Replace("121/118S", "")
                nombre = nombre.Replace("121/118Q", "")
                nombre = nombre.Replace("121/118Q", "")
                nombre = nombre.Replace("121/118Q", "")
                nombre = nombre.Replace("124/121S", "")
                nombre = nombre.Replace("123/120Q", "")
                nombre = nombre.Replace("123/120Q", "")
                nombre = nombre.Replace("104/104R", "")
                nombre = nombre.Replace("91/89R", "")







                nombre = Replace(nombre, "'", "")
                nombre = Replace(nombre, "  ", " ")
                nombre = Replace(nombre, "   ", " ")
                nombre = Replace(nombre, "    ", " ")
                nombre = Replace(nombre, "     ", " ")
                nombre = Replace(nombre, "      ", " ")
                nombre = Replace(nombre, "       ", " ")
                nombre = Replace(nombre, "        ", " ")
                nombre = LTrim(nombre)
                nombre = RTrim(nombre)











                Tipo_neumatico = ""
                If nombre.Contains(" AT") Then
                    Tipo_neumatico = "AT"
                End If
                If nombre.Contains(" MT") Then
                    Tipo_neumatico = "MT"
                End If
                If nombre.Contains(" HT") Then
                    Tipo_neumatico = "HT"
                End If




                Medida_neumatico = grilla_excel.Rows(i).Cells(0).Value.ToString
                Modelo = grilla_excel.Rows(i).Cells(3).Value.ToString
                indice_de_carga = grilla_excel.Rows(i).Cells(5).Value.ToString
                indice_de_velocidad = grilla_excel.Rows(i).Cells(6).Value.ToString


                nombre = UCase(nombre)
                Modelo = UCase(Modelo)
                marca = UCase(marca)
                indice_de_carga = UCase(indice_de_carga)
                indice_de_velocidad = UCase(indice_de_velocidad)

                Medida_neumatico = Medida_neumatico.Replace(" ", "")
                nombre = nombre.Replace("  ", " ")
                Modelo = Modelo.Replace("  ", " ")
                marca = marca.Replace("  ", " ")
                indice_de_carga = indice_de_carga.Replace("  ", " ")
                indice_de_velocidad = indice_de_velocidad.Replace("  ", " ")





                nombre = LTrim(nombre)
                nombre = RTrim(nombre)

                Modelo = LTrim(Modelo)
                Modelo = RTrim(Modelo)

                marca = LTrim(marca)
                marca = RTrim(marca)

                indice_de_carga = LTrim(indice_de_carga)
                indice_de_carga = RTrim(indice_de_carga)

                indice_de_velocidad = LTrim(indice_de_velocidad)
                indice_de_velocidad = RTrim(indice_de_velocidad)



                nombre = Modelo

                conexion.Close()
                Consultas_SQL("select * from productos where proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE `productos` SET `cantidad`='" & (stock) & "', `costo`='" & (precio) & "' WHERE proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "';"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                Else

                    crear_sku()

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `productos` (cod_producto, nombre, cantidad, costo, proveedor, marca, numero_tecnico, aplicacion, usuario_responsable, fecha_modificacion) VALUES ('" & (sku_producto) & "', '" & (nombre) & "', '" & (stock) & "',  '" & (precio) & "', '" & (rut_proveedor) & "', '" & (marca) & "', '" & (sku_proveedor) & "', '" & (medida_neumatico) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `bd_neumapro`.`productos_neumaticos` (`cod_producto`, cod_proveedor, `medida`, `modelo`, `marca`, `indice_de_velocidad`, `indice_de_carga`, `tipo`, `proveedor`) VALUES ('" & (sku_producto) & "', '" & (sku_proveedor) & "', '" & (medida_neumatico) & "', '" & (nombre) & "', '" & (marca) & "', '" & (indice_de_velocidad) & "', '" & (indice_de_carga) & "', '" & (Tipo_neumatico) & "', '" & (rut_proveedor) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                End If

            Next
        End If



        If combo_tipo.Text = "NEUMACHILE" Then

            rut_proveedor = "79634430-K"

            lbl_mensaje.Visible = True
            Me.Enabled = False


            For i = 0 To grilla_excel.Rows.Count - 1

                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(1).Value.ToString
                precio = grilla_excel.Rows(i).Cells(2).Value.ToString
                stock = grilla_excel.Rows(i).Cells(3).Value.ToString
                marca = grilla_excel.Rows(i).Cells(4).Value.ToString
                origen = grilla_excel.Rows(i).Cells(5).Value.ToString

                nombre = UCase(nombre)


                If stock = "" Then
                    stock = 0
                End If

                If stock < 8 Then
                    stock = 0
                End If

                If stock = "DISPONIBLE" Then
                    stock = 50
                End If




                indice_de_velocidad = ""

                For indice = 0 To 200


                    nombre = nombre.Replace("palabras", " ")
                    nombre = nombre.Replace("DSM413756", " ")
                    nombre = nombre.Replace("77 T", " ")
                    nombre = nombre.Replace("VER", " ")
                    nombre = nombre.Replace("CODI:111622", " ")
                    nombre = nombre.Replace("GOODDRIDE", " ")
                    nombre = nombre.Replace("GODDRIDE", " ")
                    nombre = nombre.Replace("DDRIDE", " ")
                    nombre = nombre.Replace(" STD ", " ")
                    nombre = nombre.Replace("DSM494228", " ")
                    nombre = nombre.Replace("AUTOGUARD", " ")
                    nombre = nombre.Replace("88H", " ")
                    nombre = nombre.Replace("88 H", " ")
                    nombre = nombre.Replace("DESC", " ")
                    nombre = nombre.Replace("A/T", " ")
                    nombre = nombre.Replace("DSM095898", " ")
                    nombre = nombre.Replace(" Z ", " ")
                    nombre = nombre.Replace("12PR", " ")
                    nombre = nombre.Replace("M/T", " ")
                    nombre = nombre.Replace("H/T", " ")
                    nombre = nombre.Replace(" Y ", " ")
                    nombre = nombre.Replace("DSRE.M079690", " ")
                    nombre = nombre.Replace("DSRE.M079690", " ")
                    nombre = nombre.Replace("DSRE.M446848", " ")
                    nombre = nombre.Replace("DSM102881", " ")
                    nombre = nombre.Replace("100/H", " ")
                    nombre = nombre.Replace("DSM641532", " ")
                    nombre = nombre.Replace("DSM085753", " ")
                    nombre = nombre.Replace("REM780164", " ")
                    nombre = nombre.Replace("M604092", " ")
                    nombre = nombre.Replace("DSM950525", " ")
                    nombre = nombre.Replace("DSREMM350721", " ")
                    nombre = nombre.Replace("NEUM.", " ")
                    nombre = nombre.Replace("6PR", " ")
                    nombre = nombre.Replace("8PR", " ")
                    nombre = nombre.Replace(" TL ", " ")
                    nombre = nombre.Replace(" LL ", " ")
                    nombre = nombre.Replace("10PR", " ")
                    nombre = nombre.Replace("4PR", " ")
                    nombre = nombre.Replace("(", " ")
                    nombre = nombre.Replace(")", " ")
                    nombre = nombre.Replace("New", " ")
                    nombre = nombre.Replace(" OE ", " ")
                    nombre = nombre.Replace("PORTER", " ")
                    nombre = nombre.Replace("(VERCODIGO:111622)", " ")
                    nombre = nombre.Replace("(TE301)", " ")
                    nombre = nombre.Replace(" STD ", " ")
                    nombre = nombre.Replace("(DS)M494228", " ")
                    nombre = nombre.Replace("*", " ")
                    nombre = nombre.Replace("(PARANIEVE)", " ")
                    nombre = nombre.Replace("(DESC)", " ")
                    nombre = nombre.Replace("(dsm095898)", " ")
                    nombre = nombre.Replace(" MI ", " ")
                    nombre = nombre.Replace(" BR ", " ")
                    nombre = nombre.Replace(" UL ", " ")
                    nombre = nombre.Replace("(DS)", " ")
                    nombre = nombre.Replace("VERM015289", " ")
                    nombre = nombre.Replace("XL", " ")
                    nombre = nombre.Replace("re.M079690", " ")
                    nombre = nombre.Replace(" LRC ", " ")
                    nombre = nombre.Replace(" GO ", " ")
                    nombre = nombre.Replace(" OWL ", " ")
                    nombre = nombre.Replace(" RO ", " ")
                    nombre = nombre.Replace(" MOE ", " ")
                    nombre = nombre.Replace("@", " ")
                    nombre = nombre.Replace("(D)", " ")
                    nombre = nombre.Replace("BCT", " ")
                    nombre = nombre.Replace("GOODYEAR", " ")
                    nombre = nombre.Replace("MAXXIS", " ")
                    nombre = nombre.Replace("APTANY", " ")
                    nombre = nombre.Replace("ATLAS", " ")
                    nombre = nombre.Replace("BFGOODRICH", " ")
                    nombre = nombre.Replace("BRIDGESTONE", " ")
                    nombre = nombre.Replace("CATCHLAND", " ")
                    nombre = nombre.Replace("CONTINENTAL", " ")
                    nombre = nombre.Replace("FEDERAL", " ")
                    nombre = nombre.Replace("GOODRIDE", " ")
                    nombre = nombre.Replace("GOODRIDETBR", " ")
                    nombre = nombre.Replace("GOODYEAR", " ")
                    nombre = nombre.Replace("LINGLONG", " ")
                    nombre = nombre.Replace("MICHELIN", " ")
                    nombre = nombre.Replace("NEXEN", " ")
                    nombre = nombre.Replace("ONYXPCR", " ")
                    nombre = nombre.Replace("OTRA", " ")
                    nombre = nombre.Replace("OTRASSALDOS", " ")
                    nombre = nombre.Replace("PIRELLIAUTO", " ")
                    nombre = nombre.Replace("ROADCLAW", " ")
                    nombre = nombre.Replace("SONAR", " ")
                    nombre = nombre.Replace("SUMITOMO", " ")
                    nombre = nombre.Replace("SUNNY", " ")
                    nombre = nombre.Replace("TRACMAX", " ")
                    nombre = nombre.Replace("TRIANGLE", " ")
                    nombre = nombre.Replace("WINDFORCE", " ")
                    nombre = nombre.Replace("WINRUN", " ")
                    nombre = nombre.Replace("YOKOHAMA", " ")
                    nombre = nombre.Replace(" TL", " ")
                    nombre = nombre.Replace(" UL", " ")
                    nombre = nombre.Replace("C ", " ")
                    nombre = nombre.Replace(" OE", " ")
                    nombre = nombre.Replace(" PCR", " ")
                    nombre = nombre.Replace(" MOE", " ")
                    nombre = nombre.Replace(" LL", " ")
                    nombre = nombre.Replace("CODIGO:111622", " ")
                    nombre = nombre.Replace("NEW", " ")







                    If nombre.Contains(indice & "A1 ") Then
                        indice_de_velocidad = indice & "A1"
                        nombre = nombre.Replace(" " & indice & "A1 ", " ")
                    End If


                    If nombre.Contains(indice & "A2 ") Then
                        indice_de_velocidad = indice & "A2"
                        nombre = nombre.Replace(" " & indice & "A2 ", " ")
                    End If


                    If nombre.Contains(indice & "A3 ") Then
                        indice_de_velocidad = indice & "A3"
                        nombre = nombre.Replace(" " & indice & "A3 ", " ")
                    End If


                    If nombre.Contains(indice & "A4 ") Then
                        indice_de_velocidad = indice & "A4"
                        nombre = nombre.Replace(" " & indice & "A4 ", " ")
                    End If

                    If nombre.Contains(indice & "A5 ") Then
                        indice_de_velocidad = indice & "A5"
                        nombre = nombre.Replace(" " & indice & "A5 ", " ")
                    End If

                    If nombre.Contains(indice & "A6 ") Then
                        indice_de_velocidad = indice & "A6"
                        nombre = nombre.Replace(" " & indice & "A6 ", " ")
                    End If

                    If nombre.Contains(indice & "A7 ") Then
                        indice_de_velocidad = indice & "A7"
                        nombre = nombre.Replace(" " & indice & "A7 ", " ")
                    End If

                    If nombre.Contains(indice & "A8 ") Then
                        indice_de_velocidad = indice & "A8"
                        nombre = nombre.Replace(" " & indice & "A8 ", " ")
                    End If






                    If nombre.Contains(indice & "A ") Then
                        indice_de_velocidad = indice & "A"
                        nombre = nombre.Replace(" " & indice & "A ", " ")
                    End If

                    If nombre.Contains(indice & "B ") Then
                        indice_de_velocidad = indice & "B"
                        nombre = nombre.Replace(" " & indice & "B ", " ")
                    End If

                    If nombre.Contains(indice & "C ") Then
                        indice_de_velocidad = indice & "C"
                        nombre = nombre.Replace(" " & indice & "C ", " ")
                    End If

                    If nombre.Contains(indice & "D ") Then
                        indice_de_velocidad = indice & "D"
                        nombre = nombre.Replace(" " & indice & "D ", " ")
                    End If


                    If nombre.Contains(indice & "E ") Then
                        indice_de_velocidad = indice & "E"
                        nombre = nombre.Replace(" " & indice & "E ", " ")
                    End If


                    If nombre.Contains(indice & "F ") Then
                        indice_de_velocidad = indice & "F"
                        nombre = nombre.Replace(" " & indice & "F ", " ")
                    End If


                    If nombre.Contains(indice & "G ") Then
                        indice_de_velocidad = indice & "G"
                        nombre = nombre.Replace(" " & indice & "G ", " ")
                    End If


                    If nombre.Contains(indice & "H ") Then
                        indice_de_velocidad = indice & "H"
                        nombre = nombre.Replace(" " & indice & "H ", " ")
                    End If

                    If nombre.Contains(indice & "I ") Then
                        indice_de_velocidad = indice & "I"
                        nombre = nombre.Replace(" " & indice & "I ", " ")
                    End If

                    If nombre.Contains(indice & "J ") Then
                        indice_de_velocidad = indice & "J"
                        nombre = nombre.Replace(" " & indice & "J ", " ")
                    End If


                    If nombre.Contains(indice & "K ") Then
                        indice_de_velocidad = indice & "K"
                        nombre = nombre.Replace(" " & indice & "K ", " ")
                    End If


                    If nombre.Contains(indice & "L ") Then
                        indice_de_velocidad = indice & "L"
                        nombre = nombre.Replace(" " & indice & "L ", " ")
                    End If


                    If nombre.Contains(indice & "M ") Then
                        indice_de_velocidad = indice & "M"
                        nombre = nombre.Replace(" " & indice & "M ", " ")
                    End If


                    If nombre.Contains(indice & "N ") Then
                        indice_de_velocidad = indice & "N"
                        nombre = nombre.Replace(" " & indice & "N ", " ")
                    End If


                    If nombre.Contains(indice & "O ") Then
                        indice_de_velocidad = indice & "O"
                        nombre = nombre.Replace(" " & indice & "O ", " ")
                    End If

                    If nombre.Contains(indice & "P ") Then
                        indice_de_velocidad = indice & "P"
                        nombre = nombre.Replace(" " & indice & "P ", " ")
                    End If


                    If nombre.Contains(indice & "Q ") Then
                        indice_de_velocidad = indice & "Q"
                        nombre = nombre.Replace(" " & indice & "Q ", " ")
                    End If


                    If nombre.Contains(indice & "R ") Then
                        indice_de_velocidad = indice & "R"
                        nombre = nombre.Replace(" " & indice & "R ", " ")
                    End If


                    If nombre.Contains(indice & "S ") Then
                        indice_de_velocidad = indice & "S"
                        nombre = nombre.Replace(" " & indice & "S ", " ")
                    End If


                    If nombre.Contains(indice & "T ") Then
                        indice_de_velocidad = indice & "T"
                        nombre = nombre.Replace(" " & indice & "T ", " ")
                    End If


                    If nombre.Contains(indice & "U ") Then
                        indice_de_velocidad = indice & "U"
                        nombre = nombre.Replace(" " & indice & "U ", " ")
                    End If


                    If nombre.Contains(indice & "H ") Then
                        indice_de_velocidad = indice & "H"
                        nombre = nombre.Replace(" " & indice & "H ", " ")
                    End If

                    If nombre.Contains(indice & "V ") Then
                        indice_de_velocidad = indice & "V"
                        nombre = nombre.Replace(" " & indice & "V ", " ")
                    End If

                    If nombre.Contains(indice & "ZR ") Then
                        indice_de_velocidad = indice & "ZR"
                        nombre = nombre.Replace(" " & indice & "ZR ", " ")
                    End If

                    If nombre.Contains(indice & "W ") Then
                        indice_de_velocidad = indice & "W"
                        nombre = nombre.Replace(" " & indice & "W ", " ")
                    End If

                    If nombre.Contains(indice & "X ") Then
                        indice_de_velocidad = indice & "X"
                        nombre = nombre.Replace(" " & indice & "X ", " ")
                    End If

                    If nombre.Contains(indice & "Y ") Then
                        indice_de_velocidad = indice & "Y"
                        nombre = nombre.Replace(" " & indice & "Y ", " ")
                    End If

                    If nombre.Contains(indice & "Z ") Then
                        indice_de_velocidad = indice & "Z"
                        nombre = nombre.Replace(" " & indice & "Z ", " ")
                    End If
                Next


                indice_de_carga = ""

                If indice_de_velocidad <> "" Then

                    indice_de_carga = indice_de_velocidad

                    If indice_de_carga.Contains("A") Then
                        indice_de_carga = indice_de_carga.Replace("A", "")
                    End If
                    If indice_de_carga.Contains("B") Then
                        indice_de_carga = indice_de_carga.Replace("B", "")
                    End If
                    If indice_de_carga.Contains("C") Then
                        indice_de_carga = indice_de_carga.Replace("C", "")
                    End If
                    If indice_de_carga.Contains("D") Then
                        indice_de_carga = indice_de_carga.Replace("D", "")
                    End If
                    If indice_de_carga.Contains("E") Then
                        indice_de_carga = indice_de_carga.Replace("E", "")
                    End If
                    If indice_de_carga.Contains("F") Then
                        indice_de_carga = indice_de_carga.Replace("F", "")
                    End If
                    If indice_de_carga.Contains("G") Then
                        indice_de_carga = indice_de_carga.Replace("G", "")
                    End If
                    If indice_de_carga.Contains("H") Then
                        indice_de_carga = indice_de_carga.Replace("H", "")
                    End If
                    If indice_de_carga.Contains("I") Then
                        indice_de_carga = indice_de_carga.Replace("I", "")
                    End If
                    If indice_de_carga.Contains("J") Then
                        indice_de_carga = indice_de_carga.Replace("J", "")
                    End If
                    If indice_de_carga.Contains("K") Then
                        indice_de_carga = indice_de_carga.Replace("K", "")
                    End If
                    If indice_de_carga.Contains("L") Then
                        indice_de_carga = indice_de_carga.Replace("L", "")
                    End If
                    If indice_de_carga.Contains("M") Then
                        indice_de_carga = indice_de_carga.Replace("M", "")
                    End If
                    If indice_de_carga.Contains("N") Then
                        indice_de_carga = indice_de_carga.Replace("N", "")
                    End If
                    If indice_de_carga.Contains("O") Then
                        indice_de_carga = indice_de_carga.Replace("O", "")
                    End If
                    If indice_de_carga.Contains("P") Then
                        indice_de_carga = indice_de_carga.Replace("P", "")
                    End If
                    If indice_de_carga.Contains("Q") Then
                        indice_de_carga = indice_de_carga.Replace("Q", "")
                    End If
                    If indice_de_carga.Contains("R") Then
                        indice_de_carga = indice_de_carga.Replace("R", "")
                    End If
                    If indice_de_carga.Contains("S") Then
                        indice_de_carga = indice_de_carga.Replace("S", "")
                    End If
                    If indice_de_carga.Contains("T") Then
                        indice_de_carga = indice_de_carga.Replace("T", "")
                    End If
                    If indice_de_carga.Contains("U") Then
                        indice_de_carga = indice_de_carga.Replace("U", "")
                    End If
                    If indice_de_carga.Contains("V") Then
                        indice_de_carga = indice_de_carga.Replace("V", "")
                    End If
                    If indice_de_carga.Contains("W") Then
                        indice_de_carga = indice_de_carga.Replace("W", "")
                    End If
                    If indice_de_carga.Contains("X") Then
                        indice_de_carga = indice_de_carga.Replace("X", "")
                    End If
                    If indice_de_carga.Contains("Y") Then
                        indice_de_carga = indice_de_carga.Replace("Y", "")
                    End If
                    If indice_de_carga.Contains("Z") Then
                        indice_de_carga = indice_de_carga.Replace("Z", "")
                    End If
                End If







                If indice_de_velocidad <> "" Then

                    If indice_de_velocidad.Contains("0") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("0", "")
                    End If

                    If indice_de_velocidad.Contains("1") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("1", "")
                    End If

                    If indice_de_velocidad.Contains("2") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("2", "")
                    End If

                    If indice_de_velocidad.Contains("3") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("3", "")
                    End If

                    If indice_de_velocidad.Contains("4") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("4", "")
                    End If

                    If indice_de_velocidad.Contains("5") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("5", "")
                    End If

                    If indice_de_velocidad.Contains("6") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("6", "")
                    End If

                    If indice_de_velocidad.Contains("7") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("7", "")
                    End If

                    If indice_de_velocidad.Contains("8") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("8", "")
                    End If

                    If indice_de_velocidad.Contains("9") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("9", "")
                    End If

                End If




                For aro = 0 To 30
                    nombre = Replace(nombre, " R " & aro, "R" & aro)
                    nombre = Replace(nombre, "R " & aro, "R" & aro)
                    nombre = Replace(nombre, " R" & aro, "R" & aro)
                Next






                Medida_neumatico = ""
                Dim nombre_medida As String = ""
                For m = 0 To grilla_medida.Rows.Count - 1
                    nombre_medida = grilla_medida.Rows(m).Cells(0).Value.ToString

                    If nombre.Contains(nombre_medida) Then
                        medida_neumatico = nombre_medida
                    End If

                    nombre = nombre.Replace(nombre_medida, "")

                Next




                nombre = Replace(nombre, "'", "")
                nombre = Replace(nombre, "  ", " ")
                nombre = Replace(nombre, "   ", " ")
                nombre = Replace(nombre, "    ", " ")
                nombre = Replace(nombre, "     ", " ")
                nombre = Replace(nombre, "      ", " ")
                nombre = Replace(nombre, "       ", " ")
                nombre = Replace(nombre, "        ", " ")
                nombre = LTrim(nombre)
                nombre = RTrim(nombre)








                nombre = nombre.Replace("88/86Q", "")
                nombre = nombre.Replace("85/83Q", "")
                nombre = nombre.Replace("83/81Q", "")
                nombre = nombre.Replace("88/86Q", "")
                nombre = nombre.Replace("112/110 R", "")
                nombre = nombre.Replace("89/87R", "")
                nombre = nombre.Replace("89/87", "")
                nombre = nombre.Replace("98/96Q", "")
                nombre = nombre.Replace("101/99Q", "")
                nombre = nombre.Replace("103/102R", "")
                nombre = nombre.Replace("102/100R", "")
                nombre = nombre.Replace("106/104R", "")
                nombre = nombre.Replace("104/102R", "")
                nombre = nombre.Replace("107/105R", "")
                nombre = nombre.Replace("114/112L", "")
                nombre = nombre.Replace("110/108S", "")
                nombre = nombre.Replace("107/105T", "")
                nombre = nombre.Replace("104/102T", "")
                nombre = nombre.Replace("110/10R", "")
                nombre = nombre.Replace("112/110Q", "")
                nombre = nombre.Replace("109/107T", "")
                nombre = nombre.Replace("109/107S", "")
                nombre = nombre.Replace("109/107R", "")
                nombre = nombre.Replace("109/107", "")
                nombre = nombre.Replace("10/106T", "")
                nombre = nombre.Replace("100/97Q", "")
                nombre = nombre.Replace("113/111R", "")
                nombre = nombre.Replace("112/110R", "")
                nombre = nombre.Replace("102/99S", "")
                nombre = nombre.Replace("115/112S", "")
                nombre = nombre.Replace("118/116R", "")
                nombre = nombre.Replace("115/1123R", "")
                nombre = nombre.Replace("115/113R", "")
                nombre = nombre.Replace("104/101S", "")
                nombre = nombre.Replace("110/107Q", "")
                nombre = nombre.Replace("116/113S", "")
                nombre = nombre.Replace("104/101Q", "")
                nombre = nombre.Replace("104/101R", "")
                nombre = nombre.Replace("120/116Q", "")
                nombre = nombre.Replace("120/116S", "")
                nombre = nombre.Replace("120/116SS", "")
                nombre = nombre.Replace("120/116Q", "")
                nombre = nombre.Replace("113/110S", "")
                nombre = nombre.Replace("119/116S", "")
                nombre = nombre.Replace("119/116Q", "")
                nombre = nombre.Replace("120/116S", "")
                nombre = nombre.Replace("120/116Q", "")
                nombre = nombre.Replace("120/116R", "")
                nombre = nombre.Replace("120/116S", "")
                nombre = nombre.Replace("121/118S", "")
                nombre = nombre.Replace("112/110S", "")
                nombre = nombre.Replace("119/116S", "")
                nombre = nombre.Replace("121/118S", "")
                nombre = nombre.Replace("120/117S", "")
                nombre = nombre.Replace("121/118S", "")
                nombre = nombre.Replace("121/118Q", "")
                nombre = nombre.Replace("121/118Q", "")
                nombre = nombre.Replace("121/118Q", "")
                nombre = nombre.Replace("124/121S", "")
                nombre = nombre.Replace("123/120Q", "")
                nombre = nombre.Replace("123/120Q", "")
                nombre = nombre.Replace("104/104R", "")
                nombre = nombre.Replace("91/89R", "")







                nombre = Replace(nombre, "'", "")
                nombre = Replace(nombre, "  ", " ")
                nombre = Replace(nombre, "   ", " ")
                nombre = Replace(nombre, "    ", " ")
                nombre = Replace(nombre, "     ", " ")
                nombre = Replace(nombre, "      ", " ")
                nombre = Replace(nombre, "       ", " ")
                nombre = Replace(nombre, "        ", " ")
                nombre = LTrim(nombre)
                nombre = RTrim(nombre)











                Tipo_neumatico = ""
                If nombre.Contains(" AT") Then
                    Tipo_neumatico = "AT"
                End If
                If nombre.Contains(" MT") Then
                    Tipo_neumatico = "MT"
                End If
                If nombre.Contains(" HT") Then
                    Tipo_neumatico = "HT"
                End If




                conexion.Close()
                Consultas_SQL("select * from productos where proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE `productos` SET `cantidad`='" & (stock) & "', `costo`='" & (precio) & "' WHERE proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "';"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                Else

                    crear_sku()

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `productos` (cod_producto, nombre, cantidad, costo, proveedor, marca, numero_tecnico, aplicacion, usuario_responsable, fecha_modificacion) VALUES ('" & (sku_producto) & "', '" & (nombre) & "', '" & (stock) & "',  '" & (precio) & "', '" & (rut_proveedor) & "', '" & (marca) & "', '" & (sku_proveedor) & "', '" & (medida_neumatico) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `bd_neumapro`.`productos_neumaticos` (`cod_producto`, cod_proveedor, `medida`, `modelo`, `marca`, `indice_de_velocidad`, `indice_de_carga`, `tipo`, `proveedor`) VALUES ('" & (sku_producto) & "', '" & (sku_proveedor) & "', '" & (medida_neumatico) & "', '" & (nombre) & "', '" & (marca) & "', '" & (indice_de_velocidad) & "', '" & (indice_de_carga) & "', '" & (Tipo_neumatico) & "', '" & (rut_proveedor) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                End If

            Next
        End If



        If combo_tipo.Text = "OFF ROAD" Then

            rut_proveedor = "76943150-0"

            lbl_mensaje.Visible = True
            Me.Enabled = False



            For i = 0 To grilla_excel.Rows.Count - 1

                marca = grilla_excel.Rows(i).Cells(0).Value.ToString
                sku_proveedor = grilla_excel.Rows(i).Cells(1).Value.ToString
                precio = grilla_excel.Rows(i).Cells(8).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(3).Value.ToString
                stock = grilla_excel.Rows(i).Cells(4).Value.ToString
                costo = grilla_excel.Rows(i).Cells(7).Value.ToString
                precio_oferta = grilla_excel.Rows(i).Cells(8).Value.ToString
                descuento = grilla_excel.Rows(i).Cells(9).Value.ToString
                precio_normal = grilla_excel.Rows(i).Cells(10).Value.ToString





                costo = Val(costo)
                precio_oferta = Val(precio_oferta)
                descuento = Val(descuento)
                precio_normal = Val(precio_normal)

                nombre = UCase(nombre)

                If stock = "" Then
                    stock = 0
                End If

                If stock < 8 Then
                    stock = 0
                End If

                If stock = "DISPONIBLE" Then
                    stock = 50
                End If


                If sku_proveedor = "" And nombre = "" Then
                    Exit For
                End If

                nombre = nombre.Replace("XL", " ")
                nombre = nombre.Replace("STD", " ")
                nombre = nombre.Replace("BLK", " ")
                nombre = nombre.Replace("(TOUR-HR)", " ")
                nombre = nombre.Replace("M/ T", " ")
                nombre = nombre.Replace(".10PR", " ")
                nombre = nombre.Replace("8PR", " ")
                nombre = nombre.Replace("6PR", " ")
                nombre = nombre.Replace(" MUD", " ")
                nombre = nombre.Replace("10PR", " ")

                indice_de_velocidad = ""

                For indice = 40 To 200





                    If nombre.Contains(indice & "A1") Then
                        indice_de_velocidad = indice & "A1"
                        nombre = nombre.Replace(" " & indice & "A1", " ")
                    End If


                    If nombre.Contains(indice & "A2") Then
                        indice_de_velocidad = indice & "A2"
                        nombre = nombre.Replace(" " & indice & "A2", " ")
                    End If


                    If nombre.Contains(indice & "A3") Then
                        indice_de_velocidad = indice & "A3"
                        nombre = nombre.Replace(" " & indice & "A3", " ")
                    End If


                    If nombre.Contains(indice & "A4") Then
                        indice_de_velocidad = indice & "A4"
                        nombre = nombre.Replace(" " & indice & "A4", " ")
                    End If

                    If nombre.Contains(indice & "A5") Then
                        indice_de_velocidad = indice & "A5"
                        nombre = nombre.Replace(" " & indice & "A5", " ")
                    End If

                    If nombre.Contains(indice & "A6") Then
                        indice_de_velocidad = indice & "A6"
                        nombre = nombre.Replace(" " & indice & "A6", " ")
                    End If

                    If nombre.Contains(indice & "A7") Then
                        indice_de_velocidad = indice & "A7"
                        nombre = nombre.Replace(" " & indice & "A7", " ")
                    End If

                    If nombre.Contains(indice & "A8") Then
                        indice_de_velocidad = indice & "A8"
                        nombre = nombre.Replace(" " & indice & "A8", " ")
                    End If






                    If nombre.Contains(indice & "A") Then
                        indice_de_velocidad = indice & "A"
                        nombre = nombre.Replace(" " & indice & "A", " ")
                    End If

                    If nombre.Contains(indice & "B") Then
                        indice_de_velocidad = indice & "B"
                        nombre = nombre.Replace(" " & indice & "B", " ")
                    End If

                    If nombre.Contains(indice & "C") Then
                        indice_de_velocidad = indice & "C"
                        nombre = nombre.Replace(" " & indice & "C", " ")
                    End If

                    If nombre.Contains(indice & "D") Then
                        indice_de_velocidad = indice & "D"
                        nombre = nombre.Replace(" " & indice & "D", " ")
                    End If


                    If nombre.Contains(indice & "E") Then
                        indice_de_velocidad = indice & "E"
                        nombre = nombre.Replace(" " & indice & "E", " ")
                    End If


                    If nombre.Contains(indice & "F") Then
                        indice_de_velocidad = indice & "F"
                        nombre = nombre.Replace(" " & indice & "F", " ")
                    End If


                    If nombre.Contains(indice & "G") Then
                        indice_de_velocidad = indice & "G"
                        nombre = nombre.Replace(" " & indice & "G", " ")
                    End If


                    If nombre.Contains(indice & "H") Then
                        indice_de_velocidad = indice & "H"
                        nombre = nombre.Replace(" " & indice & "H", " ")
                    End If

                    If nombre.Contains(indice & "I") Then
                        indice_de_velocidad = indice & "I"
                        nombre = nombre.Replace(" " & indice & "I", " ")
                    End If

                    If nombre.Contains(indice & "J") Then
                        indice_de_velocidad = indice & "J"
                        nombre = nombre.Replace(" " & indice & "J", " ")
                    End If


                    If nombre.Contains(indice & "K") Then
                        indice_de_velocidad = indice & "K"
                        nombre = nombre.Replace(" " & indice & "K", " ")
                    End If


                    If nombre.Contains(indice & "L") Then
                        indice_de_velocidad = indice & "L"
                        nombre = nombre.Replace(" " & indice & "L", " ")
                    End If


                    If nombre.Contains(indice & "M") Then
                        indice_de_velocidad = indice & "M"
                        nombre = nombre.Replace(" " & indice & "M", " ")
                    End If


                    If nombre.Contains(indice & "N") Then
                        indice_de_velocidad = indice & "N"
                        nombre = nombre.Replace(" " & indice & "N", " ")
                    End If


                    If nombre.Contains(indice & "O") Then
                        indice_de_velocidad = indice & "O"
                        nombre = nombre.Replace(" " & indice & "O", " ")
                    End If

                    If nombre.Contains(indice & "P") Then
                        indice_de_velocidad = indice & "P"
                        nombre = nombre.Replace(" " & indice & "P", " ")
                    End If


                    If nombre.Contains(indice & "Q") Then
                        indice_de_velocidad = indice & "Q"
                        nombre = nombre.Replace(" " & indice & "Q", " ")
                    End If


                    If nombre.Contains(indice & "R") Then
                        indice_de_velocidad = indice & "R"
                        nombre = nombre.Replace(" " & indice & "R", " ")
                    End If


                    If nombre.Contains(indice & "S") Then
                        indice_de_velocidad = indice & "S"
                        nombre = nombre.Replace(" " & indice & "S", " ")
                    End If


                    If nombre.Contains(indice & "T") Then
                        indice_de_velocidad = indice & "T"
                        nombre = nombre.Replace(" " & indice & "T", " ")
                    End If


                    If nombre.Contains(indice & "U") Then
                        indice_de_velocidad = indice & "U"
                        nombre = nombre.Replace(" " & indice & "U", " ")
                    End If


                    If nombre.Contains(indice & "H") Then
                        indice_de_velocidad = indice & "H"
                        nombre = nombre.Replace(" " & indice & "H", " ")
                    End If

                    If nombre.Contains(indice & "V") Then
                        indice_de_velocidad = indice & "V"
                        nombre = nombre.Replace(" " & indice & "V", " ")
                    End If

                    If nombre.Contains(indice & "ZR") Then
                        indice_de_velocidad = indice & "ZR"
                        nombre = nombre.Replace(" " & indice & "ZR", " ")
                    End If

                    If nombre.Contains(indice & "W") Then
                        indice_de_velocidad = indice & "W"
                        nombre = nombre.Replace(" " & indice & "W", " ")
                    End If

                    If nombre.Contains(indice & "X") Then
                        indice_de_velocidad = indice & "X"
                        nombre = nombre.Replace(" " & indice & "X", " ")
                    End If

                    If nombre.Contains(indice & "Y") Then
                        indice_de_velocidad = indice & "Y"
                        nombre = nombre.Replace(" " & indice & "Y", " ")
                    End If

                    If nombre.Contains(indice & "Z") Then
                        indice_de_velocidad = indice & "Z"
                        nombre = nombre.Replace(" " & indice & "Z", " ")
                    End If
                Next


                indice_de_carga = ""

                If indice_de_velocidad <> "" Then

                    indice_de_carga = indice_de_velocidad

                    If indice_de_carga.Contains("A") Then
                        indice_de_carga = indice_de_carga.Replace("A", "")
                    End If
                    If indice_de_carga.Contains("B") Then
                        indice_de_carga = indice_de_carga.Replace("B", "")
                    End If
                    If indice_de_carga.Contains("C") Then
                        indice_de_carga = indice_de_carga.Replace("C", "")
                    End If
                    If indice_de_carga.Contains("D") Then
                        indice_de_carga = indice_de_carga.Replace("D", "")
                    End If
                    If indice_de_carga.Contains("E") Then
                        indice_de_carga = indice_de_carga.Replace("E", "")
                    End If
                    If indice_de_carga.Contains("F") Then
                        indice_de_carga = indice_de_carga.Replace("F", "")
                    End If
                    If indice_de_carga.Contains("G") Then
                        indice_de_carga = indice_de_carga.Replace("G", "")
                    End If
                    If indice_de_carga.Contains("H") Then
                        indice_de_carga = indice_de_carga.Replace("H", "")
                    End If
                    If indice_de_carga.Contains("I") Then
                        indice_de_carga = indice_de_carga.Replace("I", "")
                    End If
                    If indice_de_carga.Contains("J") Then
                        indice_de_carga = indice_de_carga.Replace("J", "")
                    End If
                    If indice_de_carga.Contains("K") Then
                        indice_de_carga = indice_de_carga.Replace("K", "")
                    End If
                    If indice_de_carga.Contains("L") Then
                        indice_de_carga = indice_de_carga.Replace("L", "")
                    End If
                    If indice_de_carga.Contains("M") Then
                        indice_de_carga = indice_de_carga.Replace("M", "")
                    End If
                    If indice_de_carga.Contains("N") Then
                        indice_de_carga = indice_de_carga.Replace("N", "")
                    End If
                    If indice_de_carga.Contains("O") Then
                        indice_de_carga = indice_de_carga.Replace("O", "")
                    End If
                    If indice_de_carga.Contains("P") Then
                        indice_de_carga = indice_de_carga.Replace("P", "")
                    End If
                    If indice_de_carga.Contains("Q") Then
                        indice_de_carga = indice_de_carga.Replace("Q", "")
                    End If
                    If indice_de_carga.Contains("R") Then
                        indice_de_carga = indice_de_carga.Replace("R", "")
                    End If
                    If indice_de_carga.Contains("S") Then
                        indice_de_carga = indice_de_carga.Replace("S", "")
                    End If
                    If indice_de_carga.Contains("T") Then
                        indice_de_carga = indice_de_carga.Replace("T", "")
                    End If
                    If indice_de_carga.Contains("U") Then
                        indice_de_carga = indice_de_carga.Replace("U", "")
                    End If
                    If indice_de_carga.Contains("V") Then
                        indice_de_carga = indice_de_carga.Replace("V", "")
                    End If
                    If indice_de_carga.Contains("W") Then
                        indice_de_carga = indice_de_carga.Replace("W", "")
                    End If
                    If indice_de_carga.Contains("X") Then
                        indice_de_carga = indice_de_carga.Replace("X", "")
                    End If
                    If indice_de_carga.Contains("Y") Then
                        indice_de_carga = indice_de_carga.Replace("Y", "")
                    End If
                    If indice_de_carga.Contains("Z") Then
                        indice_de_carga = indice_de_carga.Replace("Z", "")
                    End If
                End If







                If indice_de_velocidad <> "" Then

                    If indice_de_velocidad.Contains("0") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("0", "")
                    End If

                    If indice_de_velocidad.Contains("1") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("1", "")
                    End If

                    If indice_de_velocidad.Contains("2") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("2", "")
                    End If

                    If indice_de_velocidad.Contains("3") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("3", "")
                    End If

                    If indice_de_velocidad.Contains("4") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("4", "")
                    End If

                    If indice_de_velocidad.Contains("5") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("5", "")
                    End If

                    If indice_de_velocidad.Contains("6") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("6", "")
                    End If

                    If indice_de_velocidad.Contains("7") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("7", "")
                    End If

                    If indice_de_velocidad.Contains("8") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("8", "")
                    End If

                    If indice_de_velocidad.Contains("9") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("9", "")
                    End If

                End If






                nombre = nombre.Replace("palabras", "")
                nombre = nombre.Replace("88/86Q", "")
                nombre = nombre.Replace("85/83Q", "")
                nombre = nombre.Replace("83/81Q", "")
                nombre = nombre.Replace("88/86Q", "")
                nombre = nombre.Replace("112/110 R", "")
                nombre = nombre.Replace("89/87R", "")
                nombre = nombre.Replace("89/87", "")
                nombre = nombre.Replace("98/96Q", "")
                nombre = nombre.Replace("101/99Q", "")
                nombre = nombre.Replace("103/102R", "")
                nombre = nombre.Replace("102/100R", "")
                nombre = nombre.Replace("106/104R", "")
                nombre = nombre.Replace("104/102R", "")
                nombre = nombre.Replace("107/105R", "")
                nombre = nombre.Replace("114/112L", "")
                nombre = nombre.Replace("110/108S", "")
                nombre = nombre.Replace("107/105T", "")
                nombre = nombre.Replace("104/102T", "")
                nombre = nombre.Replace("110/10R", "")
                nombre = nombre.Replace("112/110Q", "")
                nombre = nombre.Replace("109/107T", "")
                nombre = nombre.Replace("109/107S", "")
                nombre = nombre.Replace("109/107R", "")
                nombre = nombre.Replace("109/107", "")
                nombre = nombre.Replace("10/106T", "")
                nombre = nombre.Replace("100/97Q", "")
                nombre = nombre.Replace("113/111R", "")
                nombre = nombre.Replace("112/110R", "")
                nombre = nombre.Replace("102/99S", "")
                nombre = nombre.Replace("115/112S", "")
                nombre = nombre.Replace("118/116R", "")
                nombre = nombre.Replace("115/1123R", "")
                nombre = nombre.Replace("115/113R", "")
                nombre = nombre.Replace("104/101S", "")
                nombre = nombre.Replace("110/107Q", "")
                nombre = nombre.Replace("116/113S", "")
                nombre = nombre.Replace("104/101Q", "")
                nombre = nombre.Replace("104/101R", "")
                nombre = nombre.Replace("120/116Q", "")
                nombre = nombre.Replace("120/116S", "")
                nombre = nombre.Replace("120/116SS", "")
                nombre = nombre.Replace("120/116Q", "")
                nombre = nombre.Replace("113/110S", "")
                nombre = nombre.Replace("119/116S", "")
                nombre = nombre.Replace("119/116Q", "")
                nombre = nombre.Replace("120/116S", "")
                nombre = nombre.Replace("120/116Q", "")
                nombre = nombre.Replace("120/116R", "")
                nombre = nombre.Replace("120/116S", "")
                nombre = nombre.Replace("121/118S", "")
                nombre = nombre.Replace("112/110S", "")
                nombre = nombre.Replace("119/116S", "")
                nombre = nombre.Replace("121/118S", "")
                nombre = nombre.Replace("120/117S", "")
                nombre = nombre.Replace("121/118S", "")
                nombre = nombre.Replace("121/118Q", "")
                nombre = nombre.Replace("121/118Q", "")
                nombre = nombre.Replace("121/118Q", "")
                nombre = nombre.Replace("124/121S", "")
                nombre = nombre.Replace("123/120Q", "")
                nombre = nombre.Replace("123/120Q", "")
                nombre = nombre.Replace("104/104R", "")
                nombre = nombre.Replace("91/89R", "")
                nombre = nombre.Replace("120/117R", "")
                nombre = nombre.Replace("125/122Q", "")
                nombre = nombre.Replace("88/86P", "")
                nombre = nombre.Replace("94/93S", "")
                nombre = nombre.Replace("97/95S", "")
                nombre = nombre.Replace("106/101N", "")
                nombre = nombre.Replace("88/86P", "")
                nombre = nombre.Replace("100/97R", "")
                nombre = nombre.Replace("108/104R", "")
                nombre = nombre.Replace("123/120R", "")
                nombre = nombre.Replace("115/112R", "")
                nombre = nombre.Replace("108/104Q", "")
                nombre = nombre.Replace("115/112Q", "")
                nombre = nombre.Replace("122/119Q", "")
                nombre = nombre.Replace("120/117R", "")
                nombre = nombre.Replace("126/123R", "")
                nombre = nombre.Replace("104/110R", "")
                nombre = nombre.Replace("123/120N", "")
                nombre = nombre.Replace("108/104R", "")
                nombre = nombre.Replace("112/109R", "")
                nombre = nombre.Replace("121/118R", "")
                nombre = nombre.Replace("115/112R", "")
                nombre = nombre.Replace("112/109R", "")
                nombre = nombre.Replace("112/109N", "")
                nombre = nombre.Replace("123/120N", "")
                nombre = nombre.Replace("115/112N", "")
                nombre = nombre.Replace("120/116N", "")
                nombre = nombre.Replace("115/112Q", "")
                nombre = nombre.Replace("126/123Q", "")
                nombre = nombre.Replace("124/112Q", "")
                nombre = nombre.Replace("126/123Q", "")
                nombre = nombre.Replace("124/121Q", "")
                nombre = nombre.Replace("115/112Q", "")
                nombre = nombre.Replace("126/123Q", "")
                nombre = nombre.Replace("127/124Q", "")
                nombre = nombre.Replace("115/112Q", "")
                nombre = nombre.Replace("126/123R", "")
                nombre = nombre.Replace("116/113R", "")
                nombre = nombre.Replace("120/117Q", "")
                nombre = nombre.Replace("120/117Q", "")
                nombre = nombre.Replace("121/118R", "")
                nombre = nombre.Replace("112/109S", "")
                nombre = nombre.Replace("121/118R", "")
                nombre = nombre.Replace("121/118R", "")
                nombre = nombre.Replace("125/122S", "")
                nombre = nombre.Replace("124/121R", "")
                nombre = nombre.Replace("125/122Q", "")
                nombre = nombre.Replace("127/124N", "")
                nombre = nombre.Replace("125/122S", "")
                nombre = nombre.Replace("129/126Q", "")
                nombre = nombre.Replace("125/122P", "")
                nombre = nombre.Replace("125/122Q", "")
                nombre = nombre.Replace("127/124Q", "")
                nombre = nombre.Replace("126/123Q", "")
                nombre = nombre.Replace("124/121R", "")
                nombre = nombre.Replace("129/126P", "")
                nombre = nombre.Replace("125/122S", "")
                nombre = nombre.Replace("126/123S", "")
                nombre = nombre.Replace("126/123Q", "")
                nombre = nombre.Replace("122/119R", "")
                nombre = nombre.Replace("126/123S", "")
                nombre = nombre.Replace("121/118R", "")
                nombre = nombre.Replace("125/122Q", "")
                nombre = nombre.Replace("102/99R", "")
                nombre = nombre.Replace("125/122R", "")
                nombre = nombre.Replace("127/124N", "")
                nombre = nombre.Replace("126/123Q", "")
                nombre = nombre.Replace("125/122Q", "")
                nombre = nombre.Replace("125/122P", "")








                For aro = 0 To 30
                    nombre = Replace(nombre, " R " & aro, "R" & aro)
                    nombre = Replace(nombre, "R " & aro, "R" & aro)
                    nombre = Replace(nombre, " R" & aro, "R" & aro)
                Next







                Medida_neumatico = ""
                Dim nombre_medida As String = ""

                If nombre <> "" Then

                    For m = 0 To grilla_medida.Rows.Count - 1
                        nombre_medida = grilla_medida.Rows(m).Cells(0).Value.ToString

                        If nombre.Contains(nombre_medida) Then
                            medida_neumatico = nombre_medida
                        End If

                        nombre = nombre.Replace(nombre_medida, "")

                    Next

                End If



                nombre = Replace(nombre, "'", "")
                    nombre = Replace(nombre, "  ", " ")
                nombre = Replace(nombre, "   ", " ")
                nombre = Replace(nombre, "    ", " ")
                nombre = Replace(nombre, "     ", " ")
                nombre = Replace(nombre, "      ", " ")
                nombre = Replace(nombre, "       ", " ")
                nombre = Replace(nombre, "        ", " ")
                nombre = LTrim(nombre)
                nombre = RTrim(nombre)














                nombre = Replace(nombre, "'", "")
                nombre = Replace(nombre, "  ", " ")
                nombre = Replace(nombre, "   ", " ")
                nombre = Replace(nombre, "    ", " ")
                nombre = Replace(nombre, "     ", " ")
                nombre = Replace(nombre, "      ", " ")
                nombre = Replace(nombre, "       ", " ")
                nombre = Replace(nombre, "        ", " ")
                nombre = LTrim(nombre)
                nombre = RTrim(nombre)





                precio = Replace(precio, ",", "")

                precio = Val(precio)



                Tipo_neumatico = ""
                If nombre.Contains(" AT") Then
                    Tipo_neumatico = "AT"
                End If
                If nombre.Contains(" MT") Then
                    Tipo_neumatico = "MT"
                End If
                If nombre.Contains(" HT") Then
                    Tipo_neumatico = "HT"
                End If




                conexion.Close()
                Consultas_SQL("select * from productos where proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE `productos` SET `cantidad`='" & (stock) & "', `costo`='" & (costo) & "', `precio`='" & (precio_oferta) & "', `precio_normal`='" & (precio_normal) & "', `porcentaje_descuento`='" & (descuento) & "' WHERE proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "';"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                Else

                    crear_sku()

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `productos` (cod_producto, nombre, cantidad, costo, precio, precio_normal, porcentaje_descuento, proveedor, marca, numero_tecnico, aplicacion, usuario_responsable, fecha_modificacion) VALUES ('" & (sku_producto) & "', '" & (nombre) & "', '" & (stock) & "',  '" & (costo) & "',   '" & (precio_oferta) & "',   '" & (precio_normal) & "',   '" & (descuento) & "', '" & (rut_proveedor) & "', '" & (marca) & "', '" & (sku_proveedor) & "', '" & (Medida_neumatico) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `bd_neumapro`.`productos_neumaticos` (`cod_producto`, cod_proveedor, `medida`, `modelo`, `marca`, `indice_de_velocidad`, `indice_de_carga`, `tipo`, `proveedor`) VALUES ('" & (sku_producto) & "', '" & (sku_proveedor) & "', '" & (medida_neumatico) & "', '" & (nombre) & "', '" & (marca) & "', '" & (indice_de_velocidad) & "', '" & (indice_de_carga) & "', '" & (Tipo_neumatico) & "', '" & (rut_proveedor) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                End If

            Next
        End If



        If combo_tipo.Text = "CAREN" Then

            rut_proveedor = "96794750-4"



            lbl_mensaje.Visible = True
            Me.Enabled = False


            For i = 0 To grilla_excel.Rows.Count - 1

                sku_proveedor = grilla_excel.Rows(i).Cells(0).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(4).Value.ToString
                precio = grilla_excel.Rows(i).Cells(7).Value.ToString
                'stock = grilla_excel.Rows(i).Cells(4).Value.ToString
                marca = grilla_excel.Rows(i).Cells(3).Value.ToString

                indice_de_velocidad = grilla_excel.Rows(i).Cells(5).Value.ToString

                medida_neumatico = grilla_excel.Rows(i).Cells(1).Value.ToString

                stock = 4
                nombre = UCase(nombre)
                indice_de_carga = UCase(indice_de_carga)
                'indice_de_velocidad = UCase(indice_de_velocidad)
                medida_neumatico = UCase(medida_neumatico)

                If stock = "" Then
                    stock = 0
                End If

                If stock < 8 Then
                    stock = 0
                End If

                If stock = "DISPONIBLE" Then
                    stock = 50
                End If


                If sku_proveedor = "" And nombre = "" Then
                    Exit For
                End If

                medida_neumatico = medida_neumatico.Replace("C", "")

                'nombre = nombre.Replace("XL", " ")
                'nombre = nombre.Replace("STD", " ")
                'nombre = nombre.Replace("BLK", " ")
                'nombre = nombre.Replace("(TOUR-HR)", " ")
                'nombre = nombre.Replace("M/ T", " ")
                'nombre = nombre.Replace(".10PR", " ")
                'nombre = nombre.Replace("8PR", " ")
                'nombre = nombre.Replace("6PR", " ")
                'nombre = nombre.Replace(" MUD", " ")
                'nombre = nombre.Replace("10PR", " ")

                'indice_de_velocidad = ""



                indice_de_carga = ""

                If indice_de_velocidad <> "" Then

                    indice_de_carga = indice_de_velocidad

                    If indice_de_carga.Contains("A") Then
                        indice_de_carga = indice_de_carga.Replace("A", "")
                    End If
                    If indice_de_carga.Contains("B") Then
                        indice_de_carga = indice_de_carga.Replace("B", "")
                    End If
                    If indice_de_carga.Contains("C") Then
                        indice_de_carga = indice_de_carga.Replace("C", "")
                    End If
                    If indice_de_carga.Contains("D") Then
                        indice_de_carga = indice_de_carga.Replace("D", "")
                    End If
                    If indice_de_carga.Contains("E") Then
                        indice_de_carga = indice_de_carga.Replace("E", "")
                    End If
                    If indice_de_carga.Contains("F") Then
                        indice_de_carga = indice_de_carga.Replace("F", "")
                    End If
                    If indice_de_carga.Contains("G") Then
                        indice_de_carga = indice_de_carga.Replace("G", "")
                    End If
                    If indice_de_carga.Contains("H") Then
                        indice_de_carga = indice_de_carga.Replace("H", "")
                    End If
                    If indice_de_carga.Contains("I") Then
                        indice_de_carga = indice_de_carga.Replace("I", "")
                    End If
                    If indice_de_carga.Contains("J") Then
                        indice_de_carga = indice_de_carga.Replace("J", "")
                    End If
                    If indice_de_carga.Contains("K") Then
                        indice_de_carga = indice_de_carga.Replace("K", "")
                    End If
                    If indice_de_carga.Contains("L") Then
                        indice_de_carga = indice_de_carga.Replace("L", "")
                    End If
                    If indice_de_carga.Contains("M") Then
                        indice_de_carga = indice_de_carga.Replace("M", "")
                    End If
                    If indice_de_carga.Contains("N") Then
                        indice_de_carga = indice_de_carga.Replace("N", "")
                    End If
                    If indice_de_carga.Contains("O") Then
                        indice_de_carga = indice_de_carga.Replace("O", "")
                    End If
                    If indice_de_carga.Contains("P") Then
                        indice_de_carga = indice_de_carga.Replace("P", "")
                    End If
                    If indice_de_carga.Contains("Q") Then
                        indice_de_carga = indice_de_carga.Replace("Q", "")
                    End If
                    If indice_de_carga.Contains("R") Then
                        indice_de_carga = indice_de_carga.Replace("R", "")
                    End If
                    If indice_de_carga.Contains("S") Then
                        indice_de_carga = indice_de_carga.Replace("S", "")
                    End If
                    If indice_de_carga.Contains("T") Then
                        indice_de_carga = indice_de_carga.Replace("T", "")
                    End If
                    If indice_de_carga.Contains("U") Then
                        indice_de_carga = indice_de_carga.Replace("U", "")
                    End If
                    If indice_de_carga.Contains("V") Then
                        indice_de_carga = indice_de_carga.Replace("V", "")
                    End If
                    If indice_de_carga.Contains("W") Then
                        indice_de_carga = indice_de_carga.Replace("W", "")
                    End If
                    If indice_de_carga.Contains("X") Then
                        indice_de_carga = indice_de_carga.Replace("X", "")
                    End If
                    If indice_de_carga.Contains("Y") Then
                        indice_de_carga = indice_de_carga.Replace("Y", "")
                    End If
                    If indice_de_carga.Contains("Z") Then
                        indice_de_carga = indice_de_carga.Replace("Z", "")
                    End If
                End If







                If indice_de_velocidad <> "" Then

                    If indice_de_velocidad.Contains("0") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("0", "")
                    End If

                    If indice_de_velocidad.Contains("1") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("1", "")
                    End If

                    If indice_de_velocidad.Contains("2") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("2", "")
                    End If

                    If indice_de_velocidad.Contains("3") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("3", "")
                    End If

                    If indice_de_velocidad.Contains("4") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("4", "")
                    End If

                    If indice_de_velocidad.Contains("5") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("5", "")
                    End If

                    If indice_de_velocidad.Contains("6") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("6", "")
                    End If

                    If indice_de_velocidad.Contains("7") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("7", "")
                    End If

                    If indice_de_velocidad.Contains("8") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("8", "")
                    End If

                    If indice_de_velocidad.Contains("9") Then
                        indice_de_velocidad = indice_de_velocidad.Replace("9", "")
                    End If

                End If





                medida_neumatico = medida_neumatico.Replace(" ", "")




                medida_neumatico = Replace(medida_neumatico, "'", "")
                medida_neumatico = Replace(medida_neumatico, "  ", " ")
                medida_neumatico = Replace(medida_neumatico, "   ", " ")
                medida_neumatico = Replace(medida_neumatico, "    ", " ")
                medida_neumatico = Replace(medida_neumatico, "     ", " ")
                medida_neumatico = Replace(medida_neumatico, "      ", " ")
                medida_neumatico = Replace(medida_neumatico, "       ", " ")
                medida_neumatico = Replace(medida_neumatico, "        ", " ")
                medida_neumatico = LTrim(medida_neumatico)
                medida_neumatico = RTrim(medida_neumatico)

                nombre = Replace(nombre, "'", "")
                nombre = Replace(nombre, "  ", " ")
                nombre = Replace(nombre, "   ", " ")
                nombre = Replace(nombre, "    ", " ")
                nombre = Replace(nombre, "     ", " ")
                nombre = Replace(nombre, "      ", " ")
                nombre = Replace(nombre, "       ", " ")
                nombre = Replace(nombre, "        ", " ")
                nombre = LTrim(nombre)
                nombre = RTrim(nombre)














                nombre = Replace(nombre, "'", "")
                nombre = Replace(nombre, "  ", " ")
                nombre = Replace(nombre, "   ", " ")
                nombre = Replace(nombre, "    ", " ")
                nombre = Replace(nombre, "     ", " ")
                nombre = Replace(nombre, "      ", " ")
                nombre = Replace(nombre, "       ", " ")
                nombre = Replace(nombre, "        ", " ")
                nombre = LTrim(nombre)
                nombre = RTrim(nombre)





                precio = Replace(precio, ",", "")

                precio = Val(precio)



                Tipo_neumatico = ""
                If nombre.Contains(" AT") Then
                    Tipo_neumatico = "AT"
                End If
                If nombre.Contains(" MT") Then
                    Tipo_neumatico = "MT"
                End If
                If nombre.Contains(" HT") Then
                    Tipo_neumatico = "HT"
                End If

                indice_de_velocidad = indice_de_velocidad.Replace("/", "")
                indice_de_velocidad = indice_de_velocidad.Replace(" ", "")
                indice_de_carga = indice_de_carga.Replace(" ", "")


                conexion.Close()
                Consultas_SQL("select * from productos where proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE `productos` SET `cantidad`='" & (stock) & "', `costo`='" & (precio) & "' WHERE proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "';"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                Else

                    crear_sku()

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `productos` (cod_producto, nombre, cantidad, costo, proveedor, marca, numero_tecnico, aplicacion, usuario_responsable, fecha_modificacion) VALUES ('" & (sku_producto) & "', '" & (nombre) & "', '" & (stock) & "',  '" & (precio) & "', '" & (rut_proveedor) & "', '" & (marca) & "', '" & (sku_proveedor) & "', '" & (medida_neumatico) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `bd_neumapro`.`productos_neumaticos` (`cod_producto`, cod_proveedor, `medida`, `modelo`, `marca`, `indice_de_velocidad`, `indice_de_carga`, `tipo`, `proveedor`) VALUES ('" & (sku_producto) & "', '" & (sku_proveedor) & "', '" & (medida_neumatico) & "', '" & (nombre) & "', '" & (marca) & "', '" & (indice_de_velocidad) & "', '" & (indice_de_carga) & "', '" & (Tipo_neumatico) & "', '" & (rut_proveedor) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                End If

            Next
        End If



        If combo_tipo.Text = "LUCAS BLANDFORD" Then

            rut_proveedor = "92606000-7"

            lbl_mensaje.Visible = True
            Me.Enabled = False



            For i = 0 To grilla_excel.Rows.Count - 1

                sku_proveedor = grilla_excel.Rows(i).Cells(1).Value.ToString
                nombre = grilla_excel.Rows(i).Cells(3).Value.ToString
                precio = grilla_excel.Rows(i).Cells(8).Value.ToString
                stock = grilla_excel.Rows(i).Cells(4).Value.ToString
                marca = grilla_excel.Rows(i).Cells(0).Value.ToString


                indice_de_velocidad = grilla_excel.Rows(i).Cells(7).Value.ToString
                indice_de_carga = grilla_excel.Rows(i).Cells(6).Value.ToString

                medida_neumatico = grilla_excel.Rows(i).Cells(2).Value.ToString

                stock = 4
                nombre = UCase(nombre)
                indice_de_carga = UCase(indice_de_carga)
                'indice_de_velocidad = UCase(indice_de_velocidad)
                medida_neumatico = UCase(medida_neumatico)

                If stock = "" Then
                    stock = 0
                End If

                If stock < 8 Then
                    stock = 0
                End If

                If stock = "DISPONIBLE" Then
                    stock = 50
                End If


                If sku_proveedor = "" And nombre = "" Then
                    Exit For
                End If

                medida_neumatico = medida_neumatico.Replace("C", "")

                'nombre = nombre.Replace("XL", " ")
                'nombre = nombre.Replace("STD", " ")
                'nombre = nombre.Replace("BLK", " ")
                'nombre = nombre.Replace("(TOUR-HR)", " ")
                'nombre = nombre.Replace("M/ T", " ")
                'nombre = nombre.Replace(".10PR", " ")
                'nombre = nombre.Replace("8PR", " ")
                'nombre = nombre.Replace("6PR", " ")
                'nombre = nombre.Replace(" MUD", " ")
                'nombre = nombre.Replace("10PR", " ")

                'indice_de_velocidad = ""






                medida_neumatico = medida_neumatico.Replace(" ", "")




                medida_neumatico = Replace(medida_neumatico, "'", "")
                medida_neumatico = Replace(medida_neumatico, "  ", " ")
                medida_neumatico = Replace(medida_neumatico, "   ", " ")
                medida_neumatico = Replace(medida_neumatico, "    ", " ")
                medida_neumatico = Replace(medida_neumatico, "     ", " ")
                medida_neumatico = Replace(medida_neumatico, "      ", " ")
                medida_neumatico = Replace(medida_neumatico, "       ", " ")
                medida_neumatico = Replace(medida_neumatico, "        ", " ")
                medida_neumatico = LTrim(medida_neumatico)
                medida_neumatico = RTrim(medida_neumatico)

                nombre = Replace(nombre, "'", "")
                nombre = Replace(nombre, "  ", " ")
                nombre = Replace(nombre, "   ", " ")
                nombre = Replace(nombre, "    ", " ")
                nombre = Replace(nombre, "     ", " ")
                nombre = Replace(nombre, "      ", " ")
                nombre = Replace(nombre, "       ", " ")
                nombre = Replace(nombre, "        ", " ")
                nombre = LTrim(nombre)
                nombre = RTrim(nombre)














                nombre = Replace(nombre, "'", "")
                nombre = Replace(nombre, "  ", " ")
                nombre = Replace(nombre, "   ", " ")
                nombre = Replace(nombre, "    ", " ")
                nombre = Replace(nombre, "     ", " ")
                nombre = Replace(nombre, "      ", " ")
                nombre = Replace(nombre, "       ", " ")
                nombre = Replace(nombre, "        ", " ")
                nombre = LTrim(nombre)
                nombre = RTrim(nombre)



                precio = Val(precio)

                precio = Replace(precio, ",", "")




                Tipo_neumatico = ""
                If nombre.Contains(" AT") Then
                    Tipo_neumatico = "AT"
                End If
                If nombre.Contains(" MT") Then
                    Tipo_neumatico = "MT"
                End If
                If nombre.Contains(" HT") Then
                    Tipo_neumatico = "HT"
                End If

                indice_de_velocidad = indice_de_velocidad.Replace("/", "")
                indice_de_velocidad = indice_de_velocidad.Replace(" ", "")
                indice_de_carga = indice_de_carga.Replace(" ", "")


                conexion.Close()
                Consultas_SQL("select * from productos where proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE `productos` SET `cantidad`='" & (stock) & "', `costo`='" & (precio) & "' WHERE proveedor = '" & (rut_proveedor) & "' and numero_tecnico = '" & (sku_proveedor) & "';"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                Else

                    crear_sku()

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `productos` (cod_producto, nombre, cantidad, costo, proveedor, marca, numero_tecnico, aplicacion, usuario_responsable, fecha_modificacion) VALUES ('" & (sku_producto) & "', '" & (nombre) & "', '" & (stock) & "',  '" & (precio) & "', '" & (rut_proveedor) & "', '" & (marca) & "', '" & (sku_proveedor) & "', '" & (medida_neumatico) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO `bd_neumapro`.`productos_neumaticos` (`cod_producto`, cod_proveedor, `medida`, `modelo`, `marca`, `indice_de_velocidad`, `indice_de_carga`, `tipo`, `proveedor`) VALUES ('" & (sku_producto) & "', '" & (sku_proveedor) & "', '" & (medida_neumatico) & "', '" & (nombre) & "', '" & (marca) & "', '" & (indice_de_velocidad) & "', '" & (indice_de_carga) & "', '" & (Tipo_neumatico) & "', '" & (rut_proveedor) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                End If

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

        grilla_excel.DataSource = Nothing
        'archivo_ejemplo()

        'Dim save As New SaveFileDialog
        'save.Filter = "Archivo Excel | *.xlsx"
        'If save.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Exportar_Excel(Me.grilla_ejemplo, save.FileName)
        'End If

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

    Private Sub grilla_excel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla_excel.CellContentClick

    End Sub


    Sub grilla_medidas()

        grilla_medida.Rows.Clear()
        grilla_medida.Columns.Clear()
        grilla_medida.Columns.Add("", "MEDIDA")

        grilla_medida.Rows.Add("135/90R17")
        grilla_medida.Rows.Add("145/70R12")
        grilla_medida.Rows.Add("145/70R13")
        grilla_medida.Rows.Add("145R12")
        grilla_medida.Rows.Add("145R13")
        grilla_medida.Rows.Add("155/60R15")
        grilla_medida.Rows.Add("155/65R13")
        grilla_medida.Rows.Add("155/65R14")
        grilla_medida.Rows.Add("155/70R12")
        grilla_medida.Rows.Add("155/70R13")
        grilla_medida.Rows.Add("155/70R14")
        grilla_medida.Rows.Add("155/80R12")
        grilla_medida.Rows.Add("155/80R13")
        grilla_medida.Rows.Add("155R12")
        grilla_medida.Rows.Add("155R13")
        grilla_medida.Rows.Add("165/50R15")
        grilla_medida.Rows.Add("165/55R14")
        grilla_medida.Rows.Add("165/60R14")
        grilla_medida.Rows.Add("165/60R15")
        grilla_medida.Rows.Add("165/65R13")
        grilla_medida.Rows.Add("165/65R14")
        grilla_medida.Rows.Add("165/65R15")
        grilla_medida.Rows.Add("165/70R12")
        grilla_medida.Rows.Add("165/70R13")
        grilla_medida.Rows.Add("165/70R14")
        grilla_medida.Rows.Add("165/80R13")
        grilla_medida.Rows.Add("165/80R14")
        grilla_medida.Rows.Add("165R13")
        grilla_medida.Rows.Add("165R14")
        grilla_medida.Rows.Add("175/50R13")
        grilla_medida.Rows.Add("175/50R14")
        grilla_medida.Rows.Add("175/50R15")
        grilla_medida.Rows.Add("175/55R15")
        grilla_medida.Rows.Add("175/60R13")
        grilla_medida.Rows.Add("175/60R14")
        grilla_medida.Rows.Add("175/60R15")
        grilla_medida.Rows.Add("175/60R16")
        grilla_medida.Rows.Add("175/65R13")
        grilla_medida.Rows.Add("175/65R14")
        grilla_medida.Rows.Add("175/65R15")
        grilla_medida.Rows.Add("175/70R13")
        grilla_medida.Rows.Add("175/70R14")
        grilla_medida.Rows.Add("175/75R13")
        grilla_medida.Rows.Add("175/75R16")
        grilla_medida.Rows.Add("175/80R14")
        grilla_medida.Rows.Add("175R13")
        grilla_medida.Rows.Add("175R16")
        grilla_medida.Rows.Add("185/45R14")
        grilla_medida.Rows.Add("185/50R16")
        grilla_medida.Rows.Add("185/55R14")
        grilla_medida.Rows.Add("185/55R15")
        grilla_medida.Rows.Add("185/55R16")
        grilla_medida.Rows.Add("185/60R13")
        grilla_medida.Rows.Add("185/60R14")
        grilla_medida.Rows.Add("185/60R15")
        grilla_medida.Rows.Add("185/60R16")
        grilla_medida.Rows.Add("185/65R13")
        grilla_medida.Rows.Add("185/65R14")
        grilla_medida.Rows.Add("185/65R15")
        grilla_medida.Rows.Add("185/70R13")
        grilla_medida.Rows.Add("185/70R14")
        grilla_medida.Rows.Add("185/75R16")
        grilla_medida.Rows.Add("185/80R14")
        grilla_medida.Rows.Add("185/80R17")
        grilla_medida.Rows.Add("185R14")
        grilla_medida.Rows.Add("185R15")
        grilla_medida.Rows.Add("195/40R16")
        grilla_medida.Rows.Add("195/40R17")
        grilla_medida.Rows.Add("195/45R15")
        grilla_medida.Rows.Add("195/45R16")
        grilla_medida.Rows.Add("195/50R15")
        grilla_medida.Rows.Add("195/50R16")
        grilla_medida.Rows.Add("195/55R15")
        grilla_medida.Rows.Add("195/55R16")
        grilla_medida.Rows.Add("195/60R13")
        grilla_medida.Rows.Add("195/60R14")
        grilla_medida.Rows.Add("195/60R15")
        grilla_medida.Rows.Add("195/60R16")
        grilla_medida.Rows.Add("195/65R14")
        grilla_medida.Rows.Add("195/65R15")
        grilla_medida.Rows.Add("195/65R16")
        grilla_medida.Rows.Add("195/70R14")
        grilla_medida.Rows.Add("195/70R15")
        grilla_medida.Rows.Add("195/75R14")
        grilla_medida.Rows.Add("195/75R16")
        grilla_medida.Rows.Add("195/80R15")
        grilla_medida.Rows.Add("195/85R16")
        grilla_medida.Rows.Add("195R14")
        grilla_medida.Rows.Add("195R15")
        grilla_medida.Rows.Add("205/40R16")
        grilla_medida.Rows.Add("205/40R17")
        grilla_medida.Rows.Add("205/40R18")
        grilla_medida.Rows.Add("205/45R16")
        grilla_medida.Rows.Add("205/45R17")
        grilla_medida.Rows.Add("205/50R15")
        grilla_medida.Rows.Add("205/50R16")
        grilla_medida.Rows.Add("205/50R17")
        grilla_medida.Rows.Add("205/55R15")
        grilla_medida.Rows.Add("205/55R16")
        grilla_medida.Rows.Add("205/55R17")
        grilla_medida.Rows.Add("205/60R13")
        grilla_medida.Rows.Add("205/60R14")
        grilla_medida.Rows.Add("205/60R15")
        grilla_medida.Rows.Add("205/60R16")
        grilla_medida.Rows.Add("205/65R15")
        grilla_medida.Rows.Add("205/65R16")
        grilla_medida.Rows.Add("205/70R14")
        grilla_medida.Rows.Add("205/70R15")
        grilla_medida.Rows.Add("205/70R16")
        grilla_medida.Rows.Add("205/75R14")
        grilla_medida.Rows.Add("205/75R15")
        grilla_medida.Rows.Add("205/75R16")
        grilla_medida.Rows.Add("205/80R16")
        grilla_medida.Rows.Add("205/85R16")
        grilla_medida.Rows.Add("205R14")
        grilla_medida.Rows.Add("205R16")
        grilla_medida.Rows.Add("215/35R17")
        grilla_medida.Rows.Add("215/35R18")
        grilla_medida.Rows.Add("215/40R16")
        grilla_medida.Rows.Add("215/40R17")
        grilla_medida.Rows.Add("215/40R18")
        grilla_medida.Rows.Add("215/45R16")
        grilla_medida.Rows.Add("215/45R17")
        grilla_medida.Rows.Add("215/45R18")
        grilla_medida.Rows.Add("215/50R13")
        grilla_medida.Rows.Add("215/50R16")
        grilla_medida.Rows.Add("215/50R17")
        grilla_medida.Rows.Add("215/50R18")
        grilla_medida.Rows.Add("215/55R16")
        grilla_medida.Rows.Add("215/55R17")
        grilla_medida.Rows.Add("215/55R18")
        grilla_medida.Rows.Add("215/60R14")
        grilla_medida.Rows.Add("215/60R15")
        grilla_medida.Rows.Add("215/60R16")
        grilla_medida.Rows.Add("215/60R17")
        grilla_medida.Rows.Add("215/65R15")
        grilla_medida.Rows.Add("215/65R16")
        grilla_medida.Rows.Add("215/65R17")
        grilla_medida.Rows.Add("215/70R14")
        grilla_medida.Rows.Add("215/70R15")
        grilla_medida.Rows.Add("215/70R16")
        grilla_medida.Rows.Add("215/70R17")
        grilla_medida.Rows.Add("215/75R14")
        grilla_medida.Rows.Add("215/75R15")
        grilla_medida.Rows.Add("215/75R16")
        grilla_medida.Rows.Add("215/75R17")
        grilla_medida.Rows.Add("215/80R15")
        grilla_medida.Rows.Add("215/80R16")
        grilla_medida.Rows.Add("215/85R16")
        grilla_medida.Rows.Add("215R14")
        grilla_medida.Rows.Add("215R15")
        grilla_medida.Rows.Add("220/60R17")
        grilla_medida.Rows.Add("225/35R18")
        grilla_medida.Rows.Add("225/35R19")
        grilla_medida.Rows.Add("225/35R20")
        grilla_medida.Rows.Add("225/40R18")
        grilla_medida.Rows.Add("225/40R19")
        grilla_medida.Rows.Add("225/45R16")
        grilla_medida.Rows.Add("225/45R17")
        grilla_medida.Rows.Add("225/45R18")
        grilla_medida.Rows.Add("225/45R19")
        grilla_medida.Rows.Add("225/50R15")
        grilla_medida.Rows.Add("225/50R16")
        grilla_medida.Rows.Add("225/50R17")
        grilla_medida.Rows.Add("225/50R18")
        grilla_medida.Rows.Add("225/50R19")
        grilla_medida.Rows.Add("225/55R16")
        grilla_medida.Rows.Add("225/55R17")
        grilla_medida.Rows.Add("225/55R18")
        grilla_medida.Rows.Add("225/55R19")
        grilla_medida.Rows.Add("225/60R15")
        grilla_medida.Rows.Add("225/60R16")
        grilla_medida.Rows.Add("225/60R17")
        grilla_medida.Rows.Add("225/60R18")
        grilla_medida.Rows.Add("225/65R16")
        grilla_medida.Rows.Add("225/65R17")
        grilla_medida.Rows.Add("225/65R18")
        grilla_medida.Rows.Add("225/70R14")
        grilla_medida.Rows.Add("225/70R15")
        grilla_medida.Rows.Add("225/70R16")
        grilla_medida.Rows.Add("225/70R17")
        grilla_medida.Rows.Add("225/75R15")
        grilla_medida.Rows.Add("225/75R16")
        grilla_medida.Rows.Add("225/75R17")
        grilla_medida.Rows.Add("235/35R19")
        grilla_medida.Rows.Add("235/35R20")
        grilla_medida.Rows.Add("235/40R17")
        grilla_medida.Rows.Add("235/40R18")
        grilla_medida.Rows.Add("235/40R19")
        grilla_medida.Rows.Add("235/45R17")
        grilla_medida.Rows.Add("235/45R18")
        grilla_medida.Rows.Add("235/45R19")
        grilla_medida.Rows.Add("235/45R21")
        grilla_medida.Rows.Add("235/50R17")
        grilla_medida.Rows.Add("235/50R18")
        grilla_medida.Rows.Add("235/50R19")
        grilla_medida.Rows.Add("235/55R16")
        grilla_medida.Rows.Add("235/55R17")
        grilla_medida.Rows.Add("235/55R18")
        grilla_medida.Rows.Add("235/55R19")
        grilla_medida.Rows.Add("235/55R20")
        grilla_medida.Rows.Add("235/60R14")
        grilla_medida.Rows.Add("235/60R15")
        grilla_medida.Rows.Add("235/60R16")
        grilla_medida.Rows.Add("235/60R17")
        grilla_medida.Rows.Add("235/60R18")
        grilla_medida.Rows.Add("235/65R16")
        grilla_medida.Rows.Add("235/65R17")
        grilla_medida.Rows.Add("235/65R18")
        grilla_medida.Rows.Add("235/70R15")
        grilla_medida.Rows.Add("235/70R16")
        grilla_medida.Rows.Add("235/70R17")
        grilla_medida.Rows.Add("235/75R15")
        grilla_medida.Rows.Add("235/75R16")
        grilla_medida.Rows.Add("235/75R17")
        grilla_medida.Rows.Add("235/80R17")
        grilla_medida.Rows.Add("235/85R16")
        grilla_medida.Rows.Add("245/30R19")
        grilla_medida.Rows.Add("245/35R18")
        grilla_medida.Rows.Add("245/35R19")
        grilla_medida.Rows.Add("245/35R20")
        grilla_medida.Rows.Add("245/35R21")
        grilla_medida.Rows.Add("245/40R17")
        grilla_medida.Rows.Add("245/40R18")
        grilla_medida.Rows.Add("245/40R19")
        grilla_medida.Rows.Add("245/40R20")
        grilla_medida.Rows.Add("245/40R21")
        grilla_medida.Rows.Add("245/45R17")
        grilla_medida.Rows.Add("245/45R18")
        grilla_medida.Rows.Add("245/45R19")
        grilla_medida.Rows.Add("245/45R20")
        grilla_medida.Rows.Add("245/50R18")
        grilla_medida.Rows.Add("245/50R19")
        grilla_medida.Rows.Add("245/50R20")
        grilla_medida.Rows.Add("245/55R17")
        grilla_medida.Rows.Add("245/55R19")
        grilla_medida.Rows.Add("245/60R18")
        grilla_medida.Rows.Add("245/60R20")
        grilla_medida.Rows.Add("245/65R17")
        grilla_medida.Rows.Add("245/70R16")
        grilla_medida.Rows.Add("245/70R17")
        grilla_medida.Rows.Add("245/75R15")
        grilla_medida.Rows.Add("245/75R16")
        grilla_medida.Rows.Add("245/75R17")
        grilla_medida.Rows.Add("255/30R19")
        grilla_medida.Rows.Add("255/30R20")
        grilla_medida.Rows.Add("255/30R21")
        grilla_medida.Rows.Add("255/35R18")
        grilla_medida.Rows.Add("255/35R19")
        grilla_medida.Rows.Add("255/35R20")
        grilla_medida.Rows.Add("255/40R17")
        grilla_medida.Rows.Add("255/40R18")
        grilla_medida.Rows.Add("255/40R19")
        grilla_medida.Rows.Add("255/40R20")
        grilla_medida.Rows.Add("255/40R21")
        grilla_medida.Rows.Add("255/45R17")
        grilla_medida.Rows.Add("255/45R18")
        grilla_medida.Rows.Add("255/45R19")
        grilla_medida.Rows.Add("255/45R20")
        grilla_medida.Rows.Add("255/50R18")
        grilla_medida.Rows.Add("255/50R19")
        grilla_medida.Rows.Add("255/50R20")
        grilla_medida.Rows.Add("255/55R16")
        grilla_medida.Rows.Add("255/55R17")
        grilla_medida.Rows.Add("255/55R18")
        grilla_medida.Rows.Add("255/55R19")
        grilla_medida.Rows.Add("255/55R20")
        grilla_medida.Rows.Add("255/60R15")
        grilla_medida.Rows.Add("255/60R17")
        grilla_medida.Rows.Add("255/60R18")
        grilla_medida.Rows.Add("255/60R19")
        grilla_medida.Rows.Add("255/65R16")
        grilla_medida.Rows.Add("255/65R17")
        grilla_medida.Rows.Add("255/70R15")
        grilla_medida.Rows.Add("255/70R16")
        grilla_medida.Rows.Add("255/70R17")
        grilla_medida.Rows.Add("255/70R18")
        grilla_medida.Rows.Add("255/75R17")
        grilla_medida.Rows.Add("255/80R17")
        grilla_medida.Rows.Add("255/85R16")
        grilla_medida.Rows.Add("265/30R19")
        grilla_medida.Rows.Add("265/30R20")
        grilla_medida.Rows.Add("265/35R18")
        grilla_medida.Rows.Add("265/35R19")
        grilla_medida.Rows.Add("265/35R20")
        grilla_medida.Rows.Add("265/40R18")
        grilla_medida.Rows.Add("265/40R19")
        grilla_medida.Rows.Add("265/40R21")
        grilla_medida.Rows.Add("265/45R20")
        grilla_medida.Rows.Add("265/45R21")
        grilla_medida.Rows.Add("265/50R19")
        grilla_medida.Rows.Add("265/50R20")
        grilla_medida.Rows.Add("265/60R17")
        grilla_medida.Rows.Add("265/60R18")
        grilla_medida.Rows.Add("265/60R20")
        grilla_medida.Rows.Add("265/65R17")
        grilla_medida.Rows.Add("265/65R18")
        grilla_medida.Rows.Add("265/70R15")
        grilla_medida.Rows.Add("265/70R16")
        grilla_medida.Rows.Add("265/70R17")
        grilla_medida.Rows.Add("265/70R18")
        grilla_medida.Rows.Add("265/75R15")
        grilla_medida.Rows.Add("265/75R16")
        grilla_medida.Rows.Add("265/85R16")
        grilla_medida.Rows.Add("275/30R19")
        grilla_medida.Rows.Add("275/30R20")
        grilla_medida.Rows.Add("275/35R18")
        grilla_medida.Rows.Add("275/35R19")
        grilla_medida.Rows.Add("275/35R20")
        grilla_medida.Rows.Add("275/35R21")
        grilla_medida.Rows.Add("275/40R17")
        grilla_medida.Rows.Add("275/40R18")
        grilla_medida.Rows.Add("275/40R19")
        grilla_medida.Rows.Add("275/40R20")
        grilla_medida.Rows.Add("275/40R21")
        grilla_medida.Rows.Add("275/45R19")
        grilla_medida.Rows.Add("275/45R20")
        grilla_medida.Rows.Add("275/45R21")
        grilla_medida.Rows.Add("275/50R19")
        grilla_medida.Rows.Add("275/50R20")
        grilla_medida.Rows.Add("275/50R22")
        grilla_medida.Rows.Add("275/55R17")
        grilla_medida.Rows.Add("275/55R20")
        grilla_medida.Rows.Add("275/60R15")
        grilla_medida.Rows.Add("275/60R17")
        grilla_medida.Rows.Add("275/60R18")
        grilla_medida.Rows.Add("275/60R20")
        grilla_medida.Rows.Add("275/65R17")
        grilla_medida.Rows.Add("275/65R18")
        grilla_medida.Rows.Add("275/65R20")
        grilla_medida.Rows.Add("275/70R16")
        grilla_medida.Rows.Add("275/70R17")
        grilla_medida.Rows.Add("275/70R18")
        grilla_medida.Rows.Add("27X8.50R14")
        grilla_medida.Rows.Add("285/30R18")
        grilla_medida.Rows.Add("285/30R19")
        grilla_medida.Rows.Add("285/30R20")
        grilla_medida.Rows.Add("285/30R21")
        grilla_medida.Rows.Add("285/35R18")
        grilla_medida.Rows.Add("285/35R19")
        grilla_medida.Rows.Add("285/35R20")
        grilla_medida.Rows.Add("285/35R22")
        grilla_medida.Rows.Add("285/40R19")
        grilla_medida.Rows.Add("285/40R20")
        grilla_medida.Rows.Add("285/40R21")
        grilla_medida.Rows.Add("285/45R19")
        grilla_medida.Rows.Add("285/45R20")
        grilla_medida.Rows.Add("285/45R21")
        grilla_medida.Rows.Add("285/45R22")
        grilla_medida.Rows.Add("285/50R20")
        grilla_medida.Rows.Add("285/55R20")
        grilla_medida.Rows.Add("285/60R18")
        grilla_medida.Rows.Add("285/60R20")
        grilla_medida.Rows.Add("285/65R17")
        grilla_medida.Rows.Add("285/65R18")
        grilla_medida.Rows.Add("285/70R17")
        grilla_medida.Rows.Add("285/70R18")
        grilla_medida.Rows.Add("285/75R16")
        grilla_medida.Rows.Add("28X10.00R14")
        grilla_medida.Rows.Add("295/30R18")
        grilla_medida.Rows.Add("295/30R19")
        grilla_medida.Rows.Add("295/30R20")
        grilla_medida.Rows.Add("295/35R18")
        grilla_medida.Rows.Add("295/35R19")
        grilla_medida.Rows.Add("295/35R20")
        grilla_medida.Rows.Add("295/35R21")
        grilla_medida.Rows.Add("295/40R20")
        grilla_medida.Rows.Add("295/40R21")
        grilla_medida.Rows.Add("295/45R20")
        grilla_medida.Rows.Add("295/50R15")
        grilla_medida.Rows.Add("295/55R20")
        grilla_medida.Rows.Add("295/60R20")
        grilla_medida.Rows.Add("295/70R17")
        grilla_medida.Rows.Add("295/70R18")
        grilla_medida.Rows.Add("295/80R22.5")
        grilla_medida.Rows.Add("305/30R19")
        grilla_medida.Rows.Add("305/30R20")
        grilla_medida.Rows.Add("305/35R20")
        grilla_medida.Rows.Add("305/40R23")
        grilla_medida.Rows.Add("305/45R22")
        grilla_medida.Rows.Add("305/50R20")
        grilla_medida.Rows.Add("305/55R20")
        grilla_medida.Rows.Add("305/60R18")
        grilla_medida.Rows.Add("305/65R17")
        grilla_medida.Rows.Add("305/65R18")
        grilla_medida.Rows.Add("305/70R16")
        grilla_medida.Rows.Add("305/70R17")
        grilla_medida.Rows.Add("305/70R18")
        grilla_medida.Rows.Add("30X10.00R14")
        grilla_medida.Rows.Add("30X10.00R15")
        grilla_medida.Rows.Add("30X9.50R15")
        grilla_medida.Rows.Add("30x9.5R15")
        grilla_medida.Rows.Add("31/10.5R15")
        grilla_medida.Rows.Add("315/30R22")
        grilla_medida.Rows.Add("315/35R20")
        grilla_medida.Rows.Add("315/40R21")
        grilla_medida.Rows.Add("315/70R17")
        grilla_medida.Rows.Add("315/75R16")
        grilla_medida.Rows.Add("31X10.50R15")
        grilla_medida.Rows.Add("31X10.5R15")
        grilla_medida.Rows.Add("31X12.5R15")
        grilla_medida.Rows.Add("325/30R21")
        grilla_medida.Rows.Add("325/35R28")
        grilla_medida.Rows.Add("325/60R18")
        grilla_medida.Rows.Add("325/60R20")
        grilla_medida.Rows.Add("325/65R18")
        grilla_medida.Rows.Add("32X10.00R15")
        grilla_medida.Rows.Add("32X11.50R15")
        grilla_medida.Rows.Add("32x11.5R15")
        grilla_medida.Rows.Add("33/12.50R15")
        grilla_medida.Rows.Add("33/12.5R15")
        grilla_medida.Rows.Add("335/25R20")
        grilla_medida.Rows.Add("33X12.50R15")
        grilla_medida.Rows.Add("33X12.50R16")
        grilla_medida.Rows.Add("33X12.50R17")
        grilla_medida.Rows.Add("33X12.50R18")
        grilla_medida.Rows.Add("33X12.50R20")
        grilla_medida.Rows.Add("33X12.5R18")
        grilla_medida.Rows.Add("35/12.50R20")
        grilla_medida.Rows.Add("35/12.5R17")
        grilla_medida.Rows.Add("35X12.50R15")
        grilla_medida.Rows.Add("35X12.50R17")
        grilla_medida.Rows.Add("35X12.50R18")
        grilla_medida.Rows.Add("35X12.50R20")
        grilla_medida.Rows.Add("35X12.50R22")
        grilla_medida.Rows.Add("35x12.5R15")
        grilla_medida.Rows.Add("35x12.5R17")
        grilla_medida.Rows.Add("35X12.5R20")
        grilla_medida.Rows.Add("35X13.50R20")
        grilla_medida.Rows.Add("37X12.50R17")
        grilla_medida.Rows.Add("37X13.50R17")
        grilla_medida.Rows.Add("37X13.50R18")
        grilla_medida.Rows.Add("37X13.50R20")
        grilla_medida.Rows.Add("38X15.50R20")
        grilla_medida.Rows.Add("39X13.50R17")
        grilla_medida.Rows.Add("5.00R10")
        grilla_medida.Rows.Add("5.00R12")
        grilla_medida.Rows.Add("5.50R13")
        grilla_medida.Rows.Add("500R12")
        grilla_medida.Rows.Add("500R13")
        grilla_medida.Rows.Add("550R12")
        grilla_medida.Rows.Add("550R13")
        grilla_medida.Rows.Add("6.00R13")
        grilla_medida.Rows.Add("6.00R14")
        grilla_medida.Rows.Add("6.50R14")
        grilla_medida.Rows.Add("6.50R15")
        grilla_medida.Rows.Add("6.50R16")
        grilla_medida.Rows.Add("600R14")
        grilla_medida.Rows.Add("650R15")
        grilla_medida.Rows.Add("7.00R15")
        grilla_medida.Rows.Add("7.00R16")
        grilla_medida.Rows.Add("7.50R16")
        grilla_medida.Rows.Add("700R15")
        grilla_medida.Rows.Add("750R15")
        grilla_medida.Rows.Add("825R15")
        grilla_medida.Rows.Add("9.50R15")
        grilla_medida.Rows.Add("205/40 ZR16")
        grilla_medida.Rows.Add("205/40 ZR16 ")
        grilla_medida.Rows.Add("205/40 ZR17")
        grilla_medida.Rows.Add("205/40 ZR18")
        grilla_medida.Rows.Add("205/45 ZR16")
        grilla_medida.Rows.Add("205/45 ZR17")
        grilla_medida.Rows.Add("205/50 ZR17")
        grilla_medida.Rows.Add("205/55 ZR16")
        grilla_medida.Rows.Add("205/55 ZR17")
        grilla_medida.Rows.Add("205/70 15R")
        grilla_medida.Rows.Add("215/35 ZR18")
        grilla_medida.Rows.Add("215/40 ZR16")
        grilla_medida.Rows.Add("215/40 ZR17")
        grilla_medida.Rows.Add("215/40 ZR18")
        grilla_medida.Rows.Add("215/50 ZR17")
        grilla_medida.Rows.Add("215/55 ZR16")
        grilla_medida.Rows.Add("225/35 ZR19")
        grilla_medida.Rows.Add("225/35 ZR20")
        grilla_medida.Rows.Add("225/40 ZR18")
        grilla_medida.Rows.Add("225/40 ZR18")
        grilla_medida.Rows.Add("225/40 ZR18")
        grilla_medida.Rows.Add("225/40 ZR19")
        grilla_medida.Rows.Add("225/45 ZR17")
        grilla_medida.Rows.Add("225/45 ZR18")
        grilla_medida.Rows.Add("225/45 ZR19")
        grilla_medida.Rows.Add("235/40 ZR17")
        grilla_medida.Rows.Add("235/40 ZR18")
        grilla_medida.Rows.Add("235/40 ZR19")
        grilla_medida.Rows.Add("235/45 ZR17")
        grilla_medida.Rows.Add("235/45 ZR19")
        grilla_medida.Rows.Add("235/55 ZR17")
        grilla_medida.Rows.Add("245/35 ZR18")
        grilla_medida.Rows.Add("245/35 ZR18")
        grilla_medida.Rows.Add("245/35 ZR19")
        grilla_medida.Rows.Add("245/35 ZR20")
        grilla_medida.Rows.Add("245/40 ZR17")
        grilla_medida.Rows.Add("245/40 ZR17")
        grilla_medida.Rows.Add("245/40 ZR17")
        grilla_medida.Rows.Add("245/40 ZR18")
        grilla_medida.Rows.Add("245/40 ZR18")
        grilla_medida.Rows.Add("245/40 ZR18")
        grilla_medida.Rows.Add("245/40 ZR18")
        grilla_medida.Rows.Add("245/40 ZR19")
        grilla_medida.Rows.Add("245/40 ZR19")
        grilla_medida.Rows.Add("245/40 ZR19")
        grilla_medida.Rows.Add("245/40 ZR20")
        grilla_medida.Rows.Add("245/40 ZR20")
        grilla_medida.Rows.Add("245/45 ZR17")
        grilla_medida.Rows.Add("245/50 ZR18")
        grilla_medida.Rows.Add("255/35 ZR18")
        grilla_medida.Rows.Add("255/35 ZR18")
        grilla_medida.Rows.Add("255/35 ZR20")
        grilla_medida.Rows.Add("255/35 ZR20")
        grilla_medida.Rows.Add("255/40 ZR17")
        grilla_medida.Rows.Add("255/40 ZR19")
        grilla_medida.Rows.Add("255/40 ZR20")
        grilla_medida.Rows.Add("255/45 ZR17")
        grilla_medida.Rows.Add("265/35 ZR18")
        grilla_medida.Rows.Add("265/35 ZR18")
        grilla_medida.Rows.Add("265/40 ZR18")
        grilla_medida.Rows.Add("275/30 ZR19")
        grilla_medida.Rows.Add("275/35 ZR19")
        grilla_medida.Rows.Add("275/35 ZR20")
        grilla_medida.Rows.Add("275/40 ZR19")
        grilla_medida.Rows.Add("275/40 ZR20")
        grilla_medida.Rows.Add("295/30 ZR18")
        grilla_medida.Rows.Add("305/30 ZR19")
        grilla_medida.Rows.Add("30X9.50 R15")
        grilla_medida.Rows.Add("30x9.50 R15")
        grilla_medida.Rows.Add("30X9.50 R15")
        grilla_medida.Rows.Add("30X9.50 R15")
        grilla_medida.Rows.Add("30X9.50 R15")
        grilla_medida.Rows.Add("315/70 R17")
        grilla_medida.Rows.Add("315/70 R17")
        grilla_medida.Rows.Add("31X10.5 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("31X10.50 R15")
        grilla_medida.Rows.Add("32X11.50 R15")
        grilla_medida.Rows.Add("33X12.5 R18")
        grilla_medida.Rows.Add("33X12.50 R15 6R S-386")
        grilla_medida.Rows.Add("33X12.50 R15 T 2  ")
        grilla_medida.Rows.Add("35X12.5 R17 U  3")
        grilla_medida.Rows.Add("35X12.50 R17 T-10R () 121 RSSW /T")
        grilla_medida.Rows.Add("35X12.50 R17T-10R S369 121 R T U")
        grilla_medida.Rows.Add("35X12.50 R18T-10R S366 123 R T W")
        grilla_medida.Rows.Add("35X12.50 R20")
        grilla_medida.Rows.Add("37X12.50 R17")
        grilla_medida.Rows.Add("37X12.50 R17")
        grilla_medida.Rows.Add("5.00 R12")
        grilla_medida.Rows.Add("5.00 R12")
        grilla_medida.Rows.Add("5.00/10")
        grilla_medida.Rows.Add("5.00/12")
        grilla_medida.Rows.Add("5.00/12 8R  R 8 (S)")
        grilla_medida.Rows.Add("5.50 R13")
        grilla_medida.Rows.Add("5.50 R13")
        grilla_medida.Rows.Add("5.50/13")
        grilla_medida.Rows.Add("6.00/13")
        grilla_medida.Rows.Add("6.00/14")
        grilla_medida.Rows.Add("6.50 R15 10R")
        grilla_medida.Rows.Add("6.50 R16 10R")
        grilla_medida.Rows.Add("6.50 R16 10R")
        grilla_medida.Rows.Add("6.50 R16 10R")
        grilla_medida.Rows.Add("6.50 R16 10R")
        grilla_medida.Rows.Add("6.50/14")
        grilla_medida.Rows.Add("6.50/15")
        grilla_medida.Rows.Add("6.50/16")
        grilla_medida.Rows.Add("7.00 R15")
        grilla_medida.Rows.Add("7.00 R15")
        grilla_medida.Rows.Add("7.00 R16")
        grilla_medida.Rows.Add("7.00 R16")
        grilla_medida.Rows.Add("7.00 R16")
        grilla_medida.Rows.Add("7.00 R16")
        grilla_medida.Rows.Add("7.00 R16")
        grilla_medida.Rows.Add("7.00 R16")
        grilla_medida.Rows.Add("7.00 R16")
        grilla_medida.Rows.Add("7.00 R16")
        grilla_medida.Rows.Add("7.00 R16")
        grilla_medida.Rows.Add("7.00/15")
        grilla_medida.Rows.Add("7.00/15")
        grilla_medida.Rows.Add("7.00/16")
        grilla_medida.Rows.Add("7.00/16")
        grilla_medida.Rows.Add("7.00-16")
        grilla_medida.Rows.Add("7.50 R16")
        grilla_medida.Rows.Add("7.50 R16")
        grilla_medida.Rows.Add("7.50 R16")
        grilla_medida.Rows.Add("7.50 R16")
        grilla_medida.Rows.Add("7.50 R16")
        grilla_medida.Rows.Add("7.50 R16")
        grilla_medida.Rows.Add("7.50/15")
        grilla_medida.Rows.Add("7.50/16")
        grilla_medida.Rows.Add("7.50/16")
        grilla_medida.Rows.Add("7.50/16")
        grilla_medida.Rows.Add("7.50/16")
        grilla_medida.Rows.Add("Z165/60 R14")
        grilla_medida.Rows.Add("z185/60 R14")
        grilla_medida.Rows.Add("z185/65 R14")
        grilla_medida.Rows.Add("z185/65 R15")
        grilla_medida.Rows.Add("z195 R14")
        grilla_medida.Rows.Add("z195/55 R15")
        grilla_medida.Rows.Add("z205/40 ZR17")
        grilla_medida.Rows.Add("z215/65 R15")
        grilla_medida.Rows.Add("Z225/45 ZR18")
        grilla_medida.Rows.Add("z225/75 R15")
        grilla_medida.Rows.Add("z235/65 R17")
        grilla_medida.Rows.Add("z235/65 R17")
        grilla_medida.Rows.Add("z255/55 R18")
        grilla_medida.Rows.Add("z255/55 R19")

        grilla_medida.Rows.Add("195/45 ZR15")
        grilla_medida.Rows.Add("205/70 T15C")
        grilla_medida.Rows.Add("35X12.5R17")

    End Sub
End Class