Imports System.IO

Imports System
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing.Drawing2D

Imports System.Math
Imports System.Data.OleDb

Public Class Form_archivo_dbf
    'Dim mifecha2 As String
    'Dim mifecha2_pago As String
    'Dim mifecha2_emision As String
    'Dim mifecha2_vencimiento As String

    'Private Sub btnExaminar_Click(ByVal sender As Object, _
    '                                ByVal e As EventArgs) _
    '                                Handles btnExaminar.Click
    '    Dim oFD As New OpenFileDialog
    '    With oFD
    '        .Filter = "Ficheros DBF (*.dbf)|*.dbf|Todos (*.*)|*.*"
    '        .FileName = txtFic.Text
    '        If .ShowDialog = DialogResult.OK Then
    '            txtFic.Text = .FileName
    '            ' El nombre del fichero
    '            txtSelect.Text = System.IO.Path.GetFileNameWithoutExtension(txtFic.Text)
    '            ' btnAbrir_Click(Nothing, Nothing)
    '        End If
    '    End With
    'End Sub

    'Private Sub btnAbrir_Click(ByVal sender As Object, _
    '                         ByVal e As EventArgs) _
    '                         Handles btnAbrir.Click

    '    If txtSelect.Text = "" Then
    '        lbl_mensaje.Visible = False
    '        Me.Enabled = True
    '        Exit Sub
    '    End If

    '    lbl_mensaje.Visible = True
    '    Me.Enabled = False

    '    Dim sBase As String = txtFic.Text
    '    Dim sSelect As String = "SELECT * FROM " & txtSelect.Text
    '    Dim sConn As String


    '    sConn = "Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;dbq=" & _
    '            System.IO.Path.GetDirectoryName(sBase) & ";"

    '    Using dbConn As New System.Data.Odbc.OdbcConnection(sConn)
    '        Try
    '            dbConn.Open()

    '            Dim da As New System.Data.Odbc.OdbcDataAdapter(sSelect, dbConn)
    '            Dim dt As New DataTable

    '            da.Fill(dt)

    '            dgvDiarios.DataSource = dt

    '            dbConn.Close()

    '        Catch ex As Exception
    '            MessageBox.Show("Error al abrir la base de datos" & vbCrLf & ex.Message)
    '            Exit Sub
    '        End Try
    '    End Using
    '    txt_item.Text = dgvDiarios.Rows.Count

    '    lbl_mensaje.Visible = False
    '    Me.Enabled = True
    'End Sub

    'Private Sub Form1_DragDrop(ByVal sender As Object, _
    '                           ByVal e As DragEventArgs) _
    '                           Handles Me.DragDrop, txtFic.DragDrop
    '    ' Drag & Drop, aceptar el primer fichero
    '    If e.Data.GetDataPresent("FileDrop") Then
    '        txtFic.Text = CType(e.Data.GetData("FileDrop", True), String())(0)
    '        txtSelect.Text = System.IO.Path.GetFileNameWithoutExtension(txtFic.Text)
    '    End If
    'End Sub

    'Private Sub Form1_DragEnter(ByVal sender As Object, _
    '                            ByVal e As DragEventArgs) _
    '                            Handles Me.DragEnter, txtFic.DragEnter
    '    ' Drag & Drop, comprobar con DataFormats
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        e.Effect = DragDropEffects.Copy
    '    End If
    'End Sub

    'Private Sub Form_exportar_dbf_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    form_Menu_admin.WindowState = FormWindowState.Maximized
    'End Sub

    'Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    '    If e.KeyCode = Keys.Escape Then
    '        Me.Close()
    '    End If

    '    If e.KeyCode = Keys.F3 Then
    '        Dim forms As FormCollection = Application.OpenForms
    '        Dim i As Integer
    '        For i = 0 To forms.Count - 1
    '            Try
    '                For Each form As Form In forms
    '                    If TypeOf form Is form_Menu_admin Then

    '                    Else
    '                        form.Close()
    '                    End If
    '                Next
    '            Catch err As InvalidOperationException
    '            End Try
    '        Next i
    '        mostrar_cierre_sistema()
    '        '    form_Menu_admin.Enabled = False
    '        form_Menu_admin.Close()

    '    End If
    'End Sub

    'Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    cargar_logo()

    'End Sub

    'Sub cargar_logo()
    '    Try
    '        PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
    '    Catch
    '    End Try
    'End Sub

    'Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
    '    lbl_mensaje.Visible = True
    '    Me.Enabled = False
    '    If txtSelect.Text = "PRODUCTO" Then
    '        '/para productos
    '        Dim cod_producto As String
    '        Dim nombre As String
    '        Dim marca As String
    '        Dim aplicacion As String
    '        Dim cantidad As String
    '        Dim precio As String
    '        Dim costo As String
    '        Dim factor As String
    '        Dim numero_tecnico As String
    '        Dim cantidad_minima As String
    '        Dim proveedor As String
    '        Dim margen As String
    '        Dim familia As String
    '        Dim subfamilia As String
    '        Dim codigo_barra As String
    '        Dim ultima_compra As String
    '        Dim numero_proveedor As String
    '        Dim TIPO As String
    '        Dim cantidad_ultima_compra As String
    '        'Dim FECHA_EMISION As String
    '        Dim tipo_doc As String

    '        Dim nro_doc As String

    '        'Dim codigo_reparar As String
    '        'Dim factor_reparar As String
    '        'Dim precio_reparar As String


    '        cod_producto = 100000


    '        Dim codigo As String = 0
    '        Dim valor As Integer






    '        For i = 0 To dgvDiarios.Rows.Count - 1



    '            codigo = cod_producto

    '            valor = codigo
    '            cod_producto = String.Format("{0:000000}", valor)


    '            ' cod_producto = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            nombre = dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            marca = dgvDiarios.Rows(i).Cells(4).Value.ToString
    '            aplicacion = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            cantidad = dgvDiarios.Rows(i).Cells(20).Value.ToString
    '            precio = dgvDiarios.Rows(i).Cells(7).Value.ToString
    '            costo = dgvDiarios.Rows(i).Cells(9).Value.ToString
    '            '  factor = dgvDiarios.Rows(i).Cells(24).Value.ToString
    '            numero_tecnico = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            '  proveedor = dgvDiarios.Rows(i).Cells(21).Value.ToString
    '            ultima_compra = dgvDiarios.Rows(i).Cells(14).Value.ToString
    '            '  numero_proveedor = dgvDiarios.Rows(i).Cells(29).Value.ToString
    '            '  TIPO = dgvDiarios.Rows(i).Cells(25).Value.ToString
    '            '  cantidad_ultima_compra = dgvDiarios.Rows(i).Cells(7).Value.ToString
    '            '  margen = dgvDiarios.Rows(i).Cells(11).Value.ToString
    '            '  codigo_barra = dgvDiarios.Rows(i).Cells(14).Value.ToString
    '            '  tipo_doc = dgvDiarios.Rows(i).Cells(19).Value.ToString
    '            '  nro_doc = dgvDiarios.Rows(i).Cells(9).Value.ToString


    '            cantidad_minima = 0
    '            margen = 0
    '            familia = "-"
    '            subfamilia = "-"
    '            codigo_barra = "-"

    '            If nombre = "" Then
    '                nombre = "-"
    '            End If

    '            If marca = "" Then
    '                marca = "-"
    '            End If

    '            If aplicacion = "" Then
    '                aplicacion = "-"
    '            End If

    '            If cantidad = "" Then
    '                cantidad = "0"
    '            End If

    '            If precio = "" Then
    '                precio = "0"
    '            End If

    '            If costo = "" Then
    '                costo = "0"
    '            End If

    '            'If factor = "" Then
    '            '    factor = "-"
    '            'End If

    '            If numero_tecnico = "" Then
    '                numero_tecnico = "-"
    '            End If

    '            'If proveedor = "" Then
    '            '    proveedor = "-"
    '            'End If

    '            If ultima_compra = "" Then
    '                ultima_compra = "2014-08-25"
    '            End If

    '            'If numero_proveedor = "" Then
    '            '    numero_proveedor = "-"
    '            'End If

    '            If codigo_barra = "" Then
    '                codigo_barra = "-"
    '            End If



    '            If margen = "" Then
    '                margen = "0"
    '            End If


    '            'If cantidad_ultima_compra = "" Then
    '            '    cantidad_ultima_compra = "0"
    '            'End If

    '            'If tipo_doc = "" Then
    '            '    tipo_doc = "G"
    '            'End If

    '            cod_producto = Replace(cod_producto, "'", "´")
    '            cod_producto = Replace(cod_producto, Chr(34), "´´")
    '            cod_producto = Replace(cod_producto, "&", " ")
    '            cod_producto = Replace(cod_producto, "\", " ")

    '            nombre = Replace(nombre, "'", "´")
    '            nombre = Replace(nombre, Chr(34), "´´")
    '            nombre = Replace(nombre, "&", " ")
    '            nombre = Replace(nombre, "\", " ")

    '            marca = Replace(marca, "'", "´")
    '            marca = Replace(marca, Chr(34), "´´")
    '            marca = Replace(marca, "&", " ")
    '            marca = Replace(marca, "\", " ")

    '            aplicacion = Replace(aplicacion, "'", "´")
    '            aplicacion = Replace(aplicacion, Chr(34), "´´")
    '            aplicacion = Replace(aplicacion, "&", " ")
    '            aplicacion = Replace(aplicacion, "\", " ")

    '            cantidad = Replace(cantidad, "'", "´")
    '            cantidad = Replace(cantidad, Chr(34), "´´")
    '            cantidad = Replace(cantidad, "&", " ")
    '            cantidad = Replace(cantidad, "\", " ")

    '            costo = Replace(costo, "'", "´")
    '            costo = Replace(costo, Chr(34), "´´")
    '            costo = Replace(costo, "&", " ")
    '            costo = Replace(costo, "\", " ")

    '            'factor = Replace(factor, "'", "´")
    '            'factor = Replace(factor, Chr(34), "´´")
    '            'factor = Replace(factor, "&", " ")
    '            'factor = Replace(factor, "\", " ")

    '            numero_tecnico = Replace(numero_tecnico, "'", "´")
    '            numero_tecnico = Replace(numero_tecnico, Chr(34), "´´")
    '            numero_tecnico = Replace(numero_tecnico, "&", " ")
    '            numero_tecnico = Replace(numero_tecnico, "\", " ")
    '            cantidad_minima = Replace(cantidad_minima, "'", "´")
    '            cantidad_minima = Replace(cantidad_minima, Chr(34), "´´")
    '            cantidad_minima = Replace(cantidad_minima, "&", " ")
    '            cantidad_minima = Replace(cantidad_minima, "\", " ")

    '            'proveedor = Replace(proveedor, "'", "´")
    '            'proveedor = Replace(proveedor, Chr(34), "´´")
    '            'proveedor = Replace(proveedor, "&", " ")
    '            'proveedor = Replace(proveedor, "\", " ")

    '            codigo_barra = Replace(codigo_barra, "'", "´")
    '            codigo_barra = Replace(codigo_barra, Chr(34), "´´")
    '            codigo_barra = Replace(codigo_barra, "&", " ")
    '            codigo_barra = Replace(codigo_barra, "\", " ")

    '            ultima_compra = Replace(ultima_compra, "'", "´")
    '            ultima_compra = Replace(ultima_compra, Chr(34), "´´")
    '            ultima_compra = Replace(ultima_compra, "&", " ")
    '            ultima_compra = Replace(ultima_compra, "\", " ")

    '            'TIPO = Replace(TIPO, "'", "´")
    '            'TIPO = Replace(TIPO, Chr(34), "´´")
    '            'TIPO = Replace(TIPO, "&", " ")
    '            'TIPO = Replace(TIPO, "\", " ")

    '            'cantidad_ultima_compra = Replace(cantidad_ultima_compra, "'", "´")
    '            'cantidad_ultima_compra = Replace(cantidad_ultima_compra, Chr(34), "´´")
    '            'cantidad_ultima_compra = Replace(cantidad_ultima_compra, "&", " ")
    '            'cantidad_ultima_compra = Replace(cantidad_ultima_compra, "\", " ")

    '            cod_producto = LTrim(Replace(cod_producto, " ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "  ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "   ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "    ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "     ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "      ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "       ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "        ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "         ", " "))

    '            cod_producto = RTrim(Replace(cod_producto, " ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "  ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "   ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "    ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "     ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "      ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "       ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "        ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "         ", " "))

    '            nombre = LTrim(Replace(nombre, " ", " "))
    '            nombre = LTrim(Replace(nombre, "  ", " "))
    '            nombre = LTrim(Replace(nombre, "   ", " "))
    '            nombre = LTrim(Replace(nombre, "    ", " "))
    '            nombre = LTrim(Replace(nombre, "     ", " "))
    '            nombre = LTrim(Replace(nombre, "      ", " "))
    '            nombre = LTrim(Replace(nombre, "       ", " "))
    '            nombre = LTrim(Replace(nombre, "        ", " "))
    '            nombre = LTrim(Replace(nombre, "         ", " "))

    '            nombre = RTrim(Replace(nombre, " ", " "))
    '            nombre = RTrim(Replace(nombre, "  ", " "))
    '            nombre = RTrim(Replace(nombre, "   ", " "))
    '            nombre = RTrim(Replace(nombre, "    ", " "))
    '            nombre = RTrim(Replace(nombre, "     ", " "))
    '            nombre = RTrim(Replace(nombre, "      ", " "))
    '            nombre = RTrim(Replace(nombre, "       ", " "))
    '            nombre = RTrim(Replace(nombre, "        ", " "))
    '            nombre = RTrim(Replace(nombre, "         ", " "))

    '            aplicacion = LTrim(Replace(aplicacion, " ", " "))
    '            aplicacion = LTrim(Replace(aplicacion, "  ", " "))
    '            aplicacion = LTrim(Replace(aplicacion, "   ", " "))
    '            aplicacion = LTrim(Replace(aplicacion, "    ", " "))
    '            aplicacion = LTrim(Replace(aplicacion, "     ", " "))
    '            aplicacion = LTrim(Replace(aplicacion, "      ", " "))
    '            aplicacion = LTrim(Replace(aplicacion, "       ", " "))
    '            aplicacion = LTrim(Replace(aplicacion, "        ", " "))
    '            aplicacion = LTrim(Replace(aplicacion, "         ", " "))

    '            aplicacion = RTrim(Replace(aplicacion, " ", " "))
    '            aplicacion = RTrim(Replace(aplicacion, "  ", " "))
    '            aplicacion = RTrim(Replace(aplicacion, "   ", " "))
    '            aplicacion = RTrim(Replace(aplicacion, "    ", " "))
    '            aplicacion = RTrim(Replace(aplicacion, "     ", " "))
    '            aplicacion = RTrim(Replace(aplicacion, "      ", " "))
    '            aplicacion = RTrim(Replace(aplicacion, "       ", " "))
    '            aplicacion = RTrim(Replace(aplicacion, "        ", " "))
    '            aplicacion = RTrim(Replace(aplicacion, "         ", " "))

    '            numero_tecnico = LTrim(Replace(numero_tecnico, " ", " "))
    '            numero_tecnico = LTrim(Replace(numero_tecnico, "  ", " "))
    '            numero_tecnico = LTrim(Replace(numero_tecnico, "    ", " "))
    '            numero_tecnico = LTrim(Replace(numero_tecnico, "     ", " "))
    '            numero_tecnico = LTrim(Replace(numero_tecnico, "      ", " "))
    '            numero_tecnico = LTrim(Replace(numero_tecnico, "       ", " "))
    '            numero_tecnico = LTrim(Replace(numero_tecnico, "        ", " "))
    '            numero_tecnico = LTrim(Replace(numero_tecnico, "         ", " "))

    '            numero_tecnico = RTrim(Replace(numero_tecnico, " ", " "))
    '            numero_tecnico = RTrim(Replace(numero_tecnico, "  ", " "))
    '            numero_tecnico = RTrim(Replace(numero_tecnico, "   ", " "))
    '            numero_tecnico = RTrim(Replace(numero_tecnico, "    ", " "))
    '            numero_tecnico = RTrim(Replace(numero_tecnico, "     ", " "))
    '            numero_tecnico = RTrim(Replace(numero_tecnico, "      ", " "))
    '            numero_tecnico = RTrim(Replace(numero_tecnico, "       ", " "))
    '            numero_tecnico = RTrim(Replace(numero_tecnico, "        ", " "))
    '            numero_tecnico = RTrim(Replace(numero_tecnico, "         ", " "))

    '            numero_proveedor = LTrim(Replace(numero_proveedor, " ", " "))
    '            numero_proveedor = LTrim(Replace(numero_proveedor, "  ", " "))
    '            numero_proveedor = LTrim(Replace(numero_proveedor, "   ", " "))
    '            numero_proveedor = LTrim(Replace(numero_proveedor, "    ", " "))
    '            numero_proveedor = LTrim(Replace(numero_proveedor, "     ", " "))
    '            numero_proveedor = LTrim(Replace(numero_proveedor, "      ", " "))
    '            numero_proveedor = LTrim(Replace(numero_proveedor, "       ", " "))
    '            numero_proveedor = LTrim(Replace(numero_proveedor, "        ", " "))
    '            numero_proveedor = LTrim(Replace(numero_proveedor, "         ", " "))

    '            numero_proveedor = RTrim(Replace(numero_proveedor, " ", " "))
    '            numero_proveedor = RTrim(Replace(numero_proveedor, "  ", " "))
    '            numero_proveedor = RTrim(Replace(numero_proveedor, "   ", " "))
    '            numero_proveedor = RTrim(Replace(numero_proveedor, "    ", " "))
    '            numero_proveedor = RTrim(Replace(numero_proveedor, "     ", " "))
    '            numero_proveedor = RTrim(Replace(numero_proveedor, "      ", " "))
    '            numero_proveedor = RTrim(Replace(numero_proveedor, "       ", " "))
    '            numero_proveedor = RTrim(Replace(numero_proveedor, "        ", " "))
    '            numero_proveedor = RTrim(Replace(numero_proveedor, "         ", " "))

    '            costo = LTrim(Replace(costo, " ", " "))
    '            costo = LTrim(Replace(costo, "  ", " "))
    '            costo = LTrim(Replace(costo, "   ", " "))
    '            costo = LTrim(Replace(costo, "    ", " "))
    '            costo = LTrim(Replace(costo, "     ", " "))
    '            costo = LTrim(Replace(costo, "      ", " "))
    '            costo = LTrim(Replace(costo, "       ", " "))
    '            costo = LTrim(Replace(costo, "        ", " "))
    '            costo = LTrim(Replace(costo, "         ", " "))

    '            costo = RTrim(Replace(costo, " ", " "))
    '            costo = RTrim(Replace(costo, "  ", " "))
    '            costo = RTrim(Replace(costo, "   ", " "))
    '            costo = RTrim(Replace(costo, "    ", " "))
    '            costo = RTrim(Replace(costo, "     ", " "))
    '            costo = RTrim(Replace(costo, "      ", " "))
    '            costo = RTrim(Replace(costo, "       ", " "))
    '            costo = RTrim(Replace(costo, "        ", " "))
    '            costo = RTrim(Replace(costo, "         ", " "))

    '            precio = LTrim(Replace(precio, " ", " "))
    '            precio = LTrim(Replace(precio, "  ", " "))
    '            precio = LTrim(Replace(precio, "   ", " "))
    '            precio = LTrim(Replace(precio, "    ", " "))
    '            precio = LTrim(Replace(precio, "     ", " "))
    '            precio = LTrim(Replace(precio, "      ", " "))
    '            precio = LTrim(Replace(precio, "       ", " "))
    '            precio = LTrim(Replace(precio, "        ", " "))
    '            precio = LTrim(Replace(precio, "         ", " "))

    '            precio = RTrim(Replace(precio, " ", " "))
    '            precio = RTrim(Replace(precio, "  ", " "))
    '            precio = RTrim(Replace(precio, "   ", " "))
    '            precio = RTrim(Replace(precio, "    ", " "))
    '            precio = RTrim(Replace(precio, "     ", " "))
    '            precio = RTrim(Replace(precio, "      ", " "))
    '            precio = RTrim(Replace(precio, "       ", " "))
    '            precio = RTrim(Replace(precio, "        ", " "))
    '            precio = RTrim(Replace(precio, "         ", " "))

    '            cantidad = LTrim(Replace(cantidad, " ", " "))
    '            cantidad = LTrim(Replace(cantidad, "  ", " "))
    '            cantidad = LTrim(Replace(cantidad, "   ", " "))
    '            cantidad = LTrim(Replace(cantidad, "    ", " "))
    '            cantidad = LTrim(Replace(cantidad, "     ", " "))
    '            cantidad = LTrim(Replace(cantidad, "      ", " "))
    '            cantidad = LTrim(Replace(cantidad, "       ", " "))
    '            cantidad = LTrim(Replace(cantidad, "        ", " "))
    '            cantidad = LTrim(Replace(cantidad, "         ", " "))

    '            cantidad = RTrim(Replace(cantidad, " ", " "))
    '            cantidad = RTrim(Replace(cantidad, "  ", " "))
    '            cantidad = RTrim(Replace(cantidad, "   ", " "))
    '            cantidad = RTrim(Replace(cantidad, "    ", " "))
    '            cantidad = RTrim(Replace(cantidad, "     ", " "))
    '            cantidad = RTrim(Replace(cantidad, "      ", " "))
    '            cantidad = RTrim(Replace(cantidad, "       ", " "))
    '            cantidad = RTrim(Replace(cantidad, "        ", " "))
    '            cantidad = RTrim(Replace(cantidad, "         ", " "))

    '            marca = LTrim(Replace(marca, " ", " "))
    '            marca = LTrim(Replace(marca, "  ", " "))
    '            marca = LTrim(Replace(marca, "   ", " "))
    '            marca = LTrim(Replace(marca, "    ", " "))
    '            marca = LTrim(Replace(marca, "     ", " "))
    '            marca = LTrim(Replace(marca, "      ", " "))
    '            marca = LTrim(Replace(marca, "       ", " "))
    '            marca = LTrim(Replace(marca, "        ", " "))
    '            marca = LTrim(Replace(marca, "         ", " "))

    '            marca = RTrim(Replace(marca, " ", " "))
    '            marca = RTrim(Replace(marca, "  ", " "))
    '            marca = RTrim(Replace(marca, "   ", " "))
    '            marca = RTrim(Replace(marca, "    ", " "))
    '            marca = RTrim(Replace(marca, "     ", " "))
    '            marca = RTrim(Replace(marca, "      ", " "))
    '            marca = RTrim(Replace(marca, "       ", " "))
    '            marca = RTrim(Replace(marca, "        ", " "))
    '            marca = RTrim(Replace(marca, "         ", " "))

    '            'proveedor = Trim(Replace(proveedor, " ", " "))
    '            'proveedor = Trim(Replace(proveedor, "  ", " "))
    '            'proveedor = Trim(Replace(proveedor, "   ", " "))
    '            'proveedor = Trim(Replace(proveedor, "    ", " "))
    '            'proveedor = Trim(Replace(proveedor, "     ", " "))
    '            'proveedor = Trim(Replace(proveedor, "      ", " "))
    '            'proveedor = Trim(Replace(proveedor, "       ", " "))
    '            'proveedor = Trim(Replace(proveedor, "        ", " "))
    '            'proveedor = Trim(Replace(proveedor, "         ", " "))

    '            proveedor = Trim(Replace(proveedor, " ", " "))
    '            proveedor = Trim(Replace(proveedor, "  ", " "))
    '            proveedor = Trim(Replace(proveedor, "   ", " "))
    '            proveedor = Trim(Replace(proveedor, "    ", " "))
    '            proveedor = Trim(Replace(proveedor, "     ", " "))
    '            proveedor = Trim(Replace(proveedor, "      ", " "))
    '            proveedor = Trim(Replace(proveedor, "       ", " "))
    '            proveedor = Trim(Replace(proveedor, "        ", " "))
    '            proveedor = Trim(Replace(proveedor, "         ", " "))

    '            proveedor = LTrim(Replace(proveedor, " ", " "))
    '            proveedor = LTrim(Replace(proveedor, "  ", " "))
    '            proveedor = LTrim(Replace(proveedor, "   ", " "))
    '            proveedor = LTrim(Replace(proveedor, "    ", " "))
    '            proveedor = LTrim(Replace(proveedor, "     ", " "))
    '            proveedor = LTrim(Replace(proveedor, "      ", " "))
    '            proveedor = LTrim(Replace(proveedor, "       ", " "))
    '            proveedor = LTrim(Replace(proveedor, "        ", " "))
    '            proveedor = LTrim(Replace(proveedor, "         ", " "))

    '            proveedor = RTrim(Replace(proveedor, " ", " "))
    '            proveedor = RTrim(Replace(proveedor, "  ", " "))
    '            proveedor = RTrim(Replace(proveedor, "   ", " "))
    '            proveedor = RTrim(Replace(proveedor, "    ", " "))
    '            proveedor = RTrim(Replace(proveedor, "     ", " "))
    '            proveedor = RTrim(Replace(proveedor, "      ", " "))
    '            proveedor = RTrim(Replace(proveedor, "       ", " "))
    '            proveedor = RTrim(Replace(proveedor, "        ", " "))
    '            proveedor = RTrim(Replace(proveedor, "         ", " "))

    '            cantidad_ultima_compra = Trim(Replace(cantidad_ultima_compra, " ", " "))
    '            cantidad_ultima_compra = Trim(Replace(cantidad_ultima_compra, "  ", " "))
    '            cantidad_ultima_compra = Trim(Replace(cantidad_ultima_compra, "   ", " "))
    '            cantidad_ultima_compra = Trim(Replace(cantidad_ultima_compra, "    ", " "))
    '            cantidad_ultima_compra = Trim(Replace(cantidad_ultima_compra, "     ", " "))
    '            cantidad_ultima_compra = Trim(Replace(cantidad_ultima_compra, "      ", " "))
    '            cantidad_ultima_compra = Trim(Replace(cantidad_ultima_compra, "       ", " "))
    '            cantidad_ultima_compra = Trim(Replace(cantidad_ultima_compra, "        ", " "))
    '            cantidad_ultima_compra = Trim(Replace(cantidad_ultima_compra, "         ", " "))

    '            cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, " ", " "))
    '            cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "  ", " "))
    '            cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "   ", " "))
    '            cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "    ", " "))
    '            cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "     ", " "))
    '            cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "      ", " "))
    '            cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "       ", " "))
    '            cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "        ", " "))
    '            cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "         ", " "))

    '            cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, " ", " "))
    '            cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "  ", " "))
    '            cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "   ", " "))
    '            cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "    ", " "))
    '            cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "     ", " "))
    '            cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "      ", " "))
    '            cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "       ", " "))
    '            cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "        ", " "))
    '            cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "         ", " "))


    '            'tipo_doc = LTrim(Replace(tipo_doc, " ", " "))
    '            'tipo_doc = LTrim(Replace(tipo_doc, "  ", " "))
    '            'tipo_doc = LTrim(Replace(tipo_doc, "   ", " "))
    '            'tipo_doc = LTrim(Replace(tipo_doc, "    ", " "))
    '            'tipo_doc = LTrim(Replace(tipo_doc, "     ", " "))
    '            'tipo_doc = LTrim(Replace(tipo_doc, "      ", " "))
    '            'tipo_doc = LTrim(Replace(tipo_doc, "       ", " "))
    '            'tipo_doc = LTrim(Replace(tipo_doc, "        ", " "))
    '            'tipo_doc = LTrim(Replace(tipo_doc, "         ", " "))

    '            tipo_doc = RTrim(Replace(tipo_doc, " ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "  ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "   ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "    ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "     ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "      ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "       ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "        ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "         ", " "))


    '            nro_doc = LTrim(Replace(nro_doc, " ", " "))
    '            nro_doc = LTrim(Replace(nro_doc, "  ", " "))
    '            nro_doc = LTrim(Replace(nro_doc, "   ", " "))
    '            nro_doc = LTrim(Replace(nro_doc, "    ", " "))
    '            nro_doc = LTrim(Replace(nro_doc, "     ", " "))
    '            nro_doc = LTrim(Replace(nro_doc, "      ", " "))
    '            nro_doc = LTrim(Replace(nro_doc, "       ", " "))
    '            nro_doc = LTrim(Replace(nro_doc, "        ", " "))
    '            nro_doc = LTrim(Replace(nro_doc, "         ", " "))

    '            nro_doc = RTrim(Replace(nro_doc, " ", " "))
    '            nro_doc = RTrim(Replace(nro_doc, "  ", " "))
    '            nro_doc = RTrim(Replace(nro_doc, "   ", " "))
    '            nro_doc = RTrim(Replace(nro_doc, "    ", " "))
    '            nro_doc = RTrim(Replace(nro_doc, "     ", " "))
    '            nro_doc = RTrim(Replace(nro_doc, "      ", " "))
    '            nro_doc = RTrim(Replace(nro_doc, "       ", " "))
    '            nro_doc = RTrim(Replace(nro_doc, "        ", " "))
    '            nro_doc = RTrim(Replace(nro_doc, "         ", " "))

    '            If proveedor <> "-" Then
    '                Dim finCadena As String = proveedor(proveedor.Length - 1).ToString()
    '                proveedor = Mid(proveedor, 1, Len(proveedor) - 1)
    '                proveedor = proveedor & "-" & finCadena
    '            End If

    '            cod_producto = UCase(cod_producto)
    '            nombre = UCase(nombre)
    '            marca = UCase(marca)
    '            aplicacion = UCase(aplicacion)
    '            cantidad = UCase(cantidad)
    '            precio = UCase(precio)
    '            costo = UCase(costo)
    '            factor = UCase(factor)
    '            numero_tecnico = UCase(numero_tecnico)
    '            cantidad_minima = UCase(cantidad_minima)
    '            proveedor = UCase(proveedor)
    '            familia = UCase(familia)
    '            subfamilia = UCase(subfamilia)
    '            codigo_barra = UCase(codigo_barra)
    '            numero_proveedor = UCase(numero_proveedor)

    '            If TIPO <> "1" Then
    '                TIPO = "2"
    '            End If

    '            If tipo_doc = "V" Then
    '                tipo_doc = "VALE"
    '            End If

    '            If tipo_doc = "F" Then
    '                tipo_doc = "FACTURA"
    '            End If

    '            If tipo_doc = "G" Then
    '                tipo_doc = "GUIA"
    '            End If 'If TIPO = "" Then
    '            '    TIPO = "2"
    '            'End If

    '            If nro_doc = "" Then
    '                nro_doc = "0"
    '            End If

    '            Dim mifecha As Date
    '            mifecha = ultima_compra
    '            mifecha2 = mifecha.ToString("yyy-MM-dd")


    '            '   If TIPO = "1" Then
    '            '   precio = (factor * 2500)



    '            'SC2.CommandText = "UPDATE productos SET  CANTIDAD_ULTIMA_COMPRA='" & (cantidad) & "', NRO_DOC='" & (nro_doc) & "' , tipo_doc='" & (tipo_doc) & "', ULTIMA_COMPRA='" & (mifecha2) & "'  WHERE cod_producto = " & (cod_producto) & ""
    '            'DA2.SelectCommand = SC2
    '            'DA2.Fill(DT2)

    '            If cantidad <> 0 Then
    '                conexion.Close()
    '                DS.Tables.Clear()
    '                DT.Rows.Clear()
    '                DT.Columns.Clear()
    '                DS.Clear()
    '                conexion.Open()

    '                SC.Connection = conexion
    '                SC.CommandText = "select * from productos where numero_tecnico = '" & (numero_tecnico) & "'"
    '                DA.SelectCommand = SC
    '                DA.Fill(DT)
    '                DS.Tables.Add(DT)



    '                If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '                    'SC2.Connection = conexion
    '                    'SC2.CommandText = "UPDATE productos SET  CANTIDAD_ULTIMA_COMPRA='" & (cantidad_ultima_compra) & "', NRO_DOC='" & (nro_doc) & "' , tipo_doc='" & (tipo_doc) & "', ULTIMA_COMPRA='" & (mifecha2) & "'  WHERE cod_producto = '" & (cod_producto) & "'"
    '                    'DA2.SelectCommand = SC2
    '                    'DA2.Fill(DT2)

    '                    ' '' '' ''SC2.Connection = conexion
    '                    ' '' '' ''SC2.CommandText = "UPDATE productos SET NOMBRE='" & (nombre) & "', marca='" & (marca) & "',aplicacion='" & (aplicacion) & "', numero_tecnico = '" & (numero_tecnico) & "', familia = '" & (familia) & "', subfamilia = '" & (subfamilia) & "',  subfamilia_dos = '" & (subfamilia) & "', cantidad = '" & (cantidad) & "' , precio = '" & (precio) & "' ,  COSTO = '" & (costo) & "' , factor = '" & (factor) & "' ,  codigo_barra = '" & (codigo_barra) & "',  fecha_modificacion ='" & (form_Menu_admin.dtp_fecha.Text) & "',  cantidad_minima ='" & (cantidad_minima) & "' WHERE cod_producto = " & (codigo) & ""
    '                    ' '' '' ''DA2.SelectCommand = SC2
    '                    ' '' '' ''DA2.Fill(DT2)

    '                    SC2.Connection = conexion
    '                    SC2.CommandText = "UPDATE productos SET cantidad = '" & (cantidad) & "' WHERE numero_tecnico = '" & (numero_tecnico) & "'"
    '                    DA2.SelectCommand = SC2
    '                    DA2.Fill(DT2)
    '                    'Else
    '                    '    SC2.Connection = conexion
    '                    '    SC2.CommandText = "insert into productos (cod_producto, nombre, marca, aplicacion, cantidad, precio, costo, factor, numero_tecnico, cantidad_minima, proveedor, margen, codigo_barra, familia, subfamilia, ULTIMA_COMPRA, NUMERO_PROVEEDOR, cantidad_ultima_compra) values ('" & (cod_producto) & "','" & (nombre) & "',      '" & (marca) & "',       '" & (aplicacion) & "',           '" & (cantidad) & "',         '" & Int(precio) & "',            '" & Int(costo) & "',      '" & (factor) & "',          '" & (numero_tecnico) & "',                  '" & (cantidad_minima) & "',                      '" & (proveedor) & "',                '" & (factor) & "',       '" & (codigo_barra) & "' ,                     '" & (familia) & "',           '" & (subfamilia) & "',             '" & (mifecha2) & "',                 '" & (numero_proveedor) & "',                   '" & (cantidad_ultima_compra) & "')"
    '                    '    ' SC2.CommandText = "insert into producto (                                                                                                                                                                                                                                      cod_producto,        nombre,                    marca,                       aplicacion,                     cantidad,                      precio,                         costo,              factor,                         numero_tecnico,                         cantidad_minima,                                        proveedor,                          margen,                     codigo_barra,                                familia,                       subfamilia,                     ULTIMA_COMPRA,                              NUMERO_PROVEEDOR,                            cantidad_ultima_compra) values ('" & (cod_producto) & "','" & (nombre) & "',      '" & (marca) & "',       '" & (aplicacion) & "',           '" & (cantidad) & "',         '" & (precio) & "',            '" & (costo) & "',      '" & (factor) & "',          '" & (numero_tecnico) & "',                  '" & (cantidad_minima) & "',                      '" & (proveedor) & "',                '" & (factor) & "',       '" & (codigo_barra) & "' ,                     '" & (familia) & "',           '" & (subfamilia) & "',             '" & (mifecha2) & "',                 '" & (numero_proveedor) & "',                   '" & (cantidad_ultima_compra) & "')"
    '                    '    DA2.SelectCommand = SC2
    '                    '    DA2.Fill(DT2)
    '                    ' conexion.Close()
    '                End If
    '                conexion.Close()
    '            End If
    '            '  End If
    '            'If TIPO = "2" Then
    '            '    conexion.Close()
    '            '    DS.Tables.Clear()
    '            '    DT.Rows.Clear()
    '            '    DT.Columns.Clear()
    '            '    DS.Clear()
    '            '    conexion.Open()

    '            '    SC.Connection = conexion
    '            '            SC.CommandText = "select * from productos where cod_producto = '" & (cod_producto) & "'"
    '            '    DA.SelectCommand = SC
    '            '    DA.Fill(DT)
    '            '    DS.Tables.Add(DT)

    '            '    If DS.Tables(DT.TableName).Rows.Count > 0 Then


    '            '        SC2.Connection = conexion

    '            '                SC2.CommandText = "UPDATE productos SET  NOMBRE='" & (nombre) & "', marca='" & (marca) & "',aplicacion='" & (aplicacion) & "', cantidad = '" & (cantidad) & "',precio = '" & Int(precio) & "', costo = " & Int(costo) & ", factor = '" & (factor) & "', numero_tecnico = '" & (numero_tecnico) & "' , cantidad_minima = '" & (cantidad_minima) & "' , proveedor = '" & (proveedor) & "' ,  factor = '" & (factor) & "' , codigo_barra = '" & (codigo_barra) & "' ,  familia = '" & (familia) & "', subfamilia = '" & (subfamilia) & "' , ultima_compra = '" & (mifecha2) & "', numero_proveedor = '" & (numero_proveedor) & "', cantidad_ultima_compra = '" & (cantidad_ultima_compra) & "' WHERE cod_producto = " & (cod_producto) & ""

    '            '        DA2.SelectCommand = SC2
    '            '        DA2.Fill(DT2)

    '            '    Else
    '            '                SC2.CommandText = "insert into productos (cod_producto, nombre, marca, aplicacion, cantidad, precio, costo, factor, numero_tecnico, cantidad_minima, proveedor, margen, codigo_barra, familia, subfamilia, ULTIMA_COMPRA, NUMERO_PROVEEDOR, cantidad_ultima_compra) values ('" & (cod_producto) & "','" & (nombre) & "','" & (marca) & "','" & (aplicacion) & "','" & (cantidad) & "','" & Int(precio) & "','" & Int(costo) & "','" & (factor) & "','" & (numero_tecnico) & "','" & (cantidad_minima) & "','" & (proveedor) & "','" & (factor) & "','" & (codigo_barra) & "' ,'" & (familia) & "','" & (subfamilia) & "','" & (mifecha2) & "','" & (numero_proveedor) & "','" & (cantidad_ultima_compra) & "')"

    '            '        SC2.Connection = conexion
    '            '        DA2.SelectCommand = SC2
    '            '        DA2.Fill(DT2)

    '            '    End If
    '            '    conexion.Close()
    '            'End If
    '            '  cod_producto = cod_producto + 1
    '        Next
    '    End If



    '    '   Next
























    '    If txtSelect.Text = "BARRA" Then
    '        ''/para productos
    '        Dim cod_barra As String
    '        Dim cod_producto As String


    '        For i = 0 To dgvDiarios.Rows.Count - 1
    '            cod_barra = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            cod_producto = dgvDiarios.Rows(i).Cells(1).Value.ToString

    '            If cod_barra = "" Then
    '                cod_barra = "-"
    '            End If

    '            If cod_producto = "" Then
    '                cod_producto = "-"
    '            End If

    '            cod_barra = Replace(cod_barra, "'", "´")
    '            cod_barra = Replace(cod_barra, "/", " ")
    '            cod_barra = Replace(cod_barra, Chr(34), "´´")
    '            cod_barra = Replace(cod_barra, "&", " ")
    '            cod_barra = Replace(cod_barra, "\", " ")

    '            cod_producto = Replace(cod_producto, "'", "´")
    '            cod_producto = Replace(cod_producto, "/", " ")
    '            cod_producto = Replace(cod_producto, Chr(34), "´´")
    '            cod_producto = Replace(cod_producto, "&", " ")
    '            cod_producto = Replace(cod_producto, "\", " ")

    '            cod_producto = LTrim(Replace(cod_producto, " ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "  ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "   ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "    ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "     ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "      ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "       ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "        ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "         ", " "))

    '            cod_producto = RTrim(Replace(cod_producto, " ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "  ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "   ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "    ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "     ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "      ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "       ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "        ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "         ", " "))

    '            cod_barra = LTrim(Replace(cod_barra, " ", " "))
    '            cod_barra = LTrim(Replace(cod_barra, "  ", " "))
    '            cod_barra = LTrim(Replace(cod_barra, "   ", " "))
    '            cod_barra = LTrim(Replace(cod_barra, "    ", " "))
    '            cod_barra = LTrim(Replace(cod_barra, "     ", " "))
    '            cod_barra = LTrim(Replace(cod_barra, "      ", " "))
    '            cod_barra = LTrim(Replace(cod_barra, "       ", " "))
    '            cod_barra = LTrim(Replace(cod_barra, "        ", " "))
    '            cod_barra = LTrim(Replace(cod_barra, "         ", " "))

    '            cod_barra = RTrim(Replace(cod_barra, " ", " "))
    '            cod_barra = RTrim(Replace(cod_barra, "  ", " "))
    '            cod_barra = RTrim(Replace(cod_barra, "   ", " "))
    '            cod_barra = RTrim(Replace(cod_barra, "    ", " "))
    '            cod_barra = RTrim(Replace(cod_barra, "     ", " "))
    '            cod_barra = RTrim(Replace(cod_barra, "      ", " "))
    '            cod_barra = RTrim(Replace(cod_barra, "       ", " "))
    '            cod_barra = RTrim(Replace(cod_barra, "        ", " "))
    '            cod_barra = RTrim(Replace(cod_barra, "         ", " "))

    '            cod_producto = UCase(cod_producto)
    '            cod_barra = UCase(cod_barra)

    '            DS.Tables.Clear()
    '            DT.Rows.Clear()
    '            DT.Columns.Clear()
    '            DS.Clear()
    '            conexion.Open()

    '            SC.Connection = conexion
    '            SC.CommandText = "insert into codigos_de_barra (codigo_barra, codigo_interno) values ('" & (cod_barra) & "','" & (cod_producto) & "')"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '            conexion.Close()
    '        Next
    '    End If


    '    If txtSelect.Text = "MAECLI" Then
    '        ''/para productos
    '        Dim rut_cliente As String
    '        Dim nombre_cliente As String
    '        Dim direccion_cliente As String
    '        Dim telefono_cliente As String
    '        Dim ciudad_cliente As String
    '        Dim comuna_cliente As String
    '        Dim giro_cliente As String
    '        Dim email_cliente As String
    '        Dim tipo_cliente As String
    '        Dim descuento_1 As String
    '        Dim descuento_2 As String
    '        Dim cuenta_cliente As String
    '        Dim tipo_cuenta As String
    '        Dim folio_cliente As String
    '        Dim estado_cuenta As String

    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            rut_cliente = dgvDiarios.Rows(i).Cells(0).Value.ToString & "-" & dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            nombre_cliente = dgvDiarios.Rows(i).Cells(2).Value.ToString
    '            direccion_cliente = dgvDiarios.Rows(i).Cells(3).Value.ToString
    '            telefono_cliente = dgvDiarios.Rows(i).Cells(5).Value.ToString
    '            ciudad_cliente = dgvDiarios.Rows(i).Cells(4).Value.ToString
    '            comuna_cliente = "-"
    '            giro_cliente = dgvDiarios.Rows(i).Cells(21).Value.ToString
    '            email_cliente = "-"
    '            ' tipo_cliente = dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            ' descuento_1 = dgvDiarios.Rows(i).Cells(15).Value.ToString
    '            descuento_1 = "0"
    '            descuento_2 = "0"
    '            cuenta_cliente = "NO"
    '            tipo_cuenta = "-"
    '            folio_cliente = "-"
    '            estado_cuenta = "SIN CUENTA"


    '            If nombre_cliente = "" Then
    '                nombre_cliente = "-"
    '            End If

    '            If direccion_cliente = "" Then
    '                direccion_cliente = "-"
    '            End If

    '            If telefono_cliente = "" Then
    '                telefono_cliente = "-"
    '            End If

    '            If ciudad_cliente = "" Then
    '                ciudad_cliente = "0"
    '            End If

    '            If comuna_cliente = "" Then
    '                comuna_cliente = "0"
    '            End If

    '            If giro_cliente = "" Then
    '                giro_cliente = "0"
    '            End If

    '            If email_cliente = "" Then
    '                email_cliente = "-"
    '            End If

    '            'If tipo_cliente = "" Then
    '            '    tipo_cliente = "-"
    '            'End If

    '            If descuento_1 = "" Then
    '                descuento_1 = "-"
    '            End If

    '            If descuento_2 = "" Then
    '                descuento_2 = "2014-08-25"
    '            End If

    '            If cuenta_cliente = "" Then
    '                cuenta_cliente = "-"
    '            End If

    '            If tipo_cuenta = "" Then
    '                tipo_cuenta = "-"
    '            End If

    '            If folio_cliente = "" Then
    '                folio_cliente = "-"
    '            End If

    '            If estado_cuenta = "" Then
    '                estado_cuenta = "-"
    '            End If

    '            rut_cliente = Replace(rut_cliente, "'", "´")
    '            rut_cliente = Replace(rut_cliente, "/", " ")
    '            rut_cliente = Replace(rut_cliente, Chr(34), "´´")
    '            rut_cliente = Replace(rut_cliente, "&", " ")
    '            rut_cliente = Replace(rut_cliente, "\", " ")

    '            nombre_cliente = Replace(nombre_cliente, "'", "´")
    '            nombre_cliente = Replace(nombre_cliente, "/", " ")
    '            nombre_cliente = Replace(nombre_cliente, Chr(34), "´´")
    '            nombre_cliente = Replace(nombre_cliente, "&", " ")
    '            nombre_cliente = Replace(nombre_cliente, "\", " ")

    '            direccion_cliente = Replace(direccion_cliente, "'", "´")
    '            direccion_cliente = Replace(direccion_cliente, "/", " ")
    '            direccion_cliente = Replace(direccion_cliente, Chr(34), "´´")
    '            direccion_cliente = Replace(direccion_cliente, "&", " ")
    '            direccion_cliente = Replace(direccion_cliente, "\", " ")

    '            telefono_cliente = Replace(telefono_cliente, "'", "´")
    '            telefono_cliente = Replace(telefono_cliente, "/", " ")
    '            telefono_cliente = Replace(telefono_cliente, Chr(34), "´´")
    '            telefono_cliente = Replace(telefono_cliente, "&", " ")
    '            telefono_cliente = Replace(telefono_cliente, "\", " ")

    '            ciudad_cliente = Replace(ciudad_cliente, "'", "´")
    '            ciudad_cliente = Replace(ciudad_cliente, "/", " ")
    '            ciudad_cliente = Replace(ciudad_cliente, Chr(34), "´´")
    '            ciudad_cliente = Replace(ciudad_cliente, "&", " ")
    '            ciudad_cliente = Replace(ciudad_cliente, "\", " ")

    '            comuna_cliente = Replace(comuna_cliente, "'", "´")
    '            comuna_cliente = Replace(comuna_cliente, "/", " ")
    '            comuna_cliente = Replace(comuna_cliente, Chr(34), "´´")
    '            comuna_cliente = Replace(comuna_cliente, "&", " ")
    '            comuna_cliente = Replace(comuna_cliente, "\", " ")

    '            giro_cliente = Replace(giro_cliente, "'", "´")
    '            giro_cliente = Replace(giro_cliente, "/", " ")
    '            giro_cliente = Replace(giro_cliente, Chr(34), "´´")
    '            giro_cliente = Replace(giro_cliente, "&", " ")
    '            giro_cliente = Replace(giro_cliente, "\", " ")

    '            email_cliente = Replace(email_cliente, "'", "´")
    '            email_cliente = Replace(email_cliente, "/", " ")
    '            email_cliente = Replace(email_cliente, Chr(34), "´´")
    '            email_cliente = Replace(email_cliente, "&", " ")
    '            email_cliente = Replace(email_cliente, "\", " ")

    '            'tipo_cliente = Replace(tipo_cliente, "'", "´")
    '            'tipo_cliente = Replace(tipo_cliente, "/", " ")
    '            'tipo_cliente = Replace(tipo_cliente, Chr(34), "´´")
    '            'tipo_cliente = Replace(tipo_cliente, "&", " ")
    '            'tipo_cliente = Replace(tipo_cliente, "\", " ")

    '            descuento_1 = Replace(descuento_1, "'", "´")
    '            descuento_1 = Replace(descuento_1, "/", " ")
    '            descuento_1 = Replace(descuento_1, Chr(34), "´´")
    '            descuento_1 = Replace(descuento_1, "&", " ")
    '            descuento_1 = Replace(descuento_1, "\", " ")

    '            descuento_2 = Replace(descuento_2, "'", "´")
    '            descuento_2 = Replace(descuento_2, "/", " ")
    '            descuento_2 = Replace(descuento_2, Chr(34), "´´")
    '            descuento_2 = Replace(descuento_2, "&", " ")
    '            descuento_2 = Replace(descuento_2, "\", " ")

    '            cuenta_cliente = Replace(cuenta_cliente, "'", "´")
    '            cuenta_cliente = Replace(cuenta_cliente, "/", " ")
    '            cuenta_cliente = Replace(cuenta_cliente, Chr(34), "´´")
    '            cuenta_cliente = Replace(cuenta_cliente, "&", " ")
    '            cuenta_cliente = Replace(cuenta_cliente, "\", " ")

    '            tipo_cuenta = Replace(tipo_cuenta, "'", "´")
    '            tipo_cuenta = Replace(tipo_cuenta, "/", " ")
    '            tipo_cuenta = Replace(tipo_cuenta, Chr(34), "´´")
    '            tipo_cuenta = Replace(tipo_cuenta, "&", " ")
    '            tipo_cuenta = Replace(tipo_cuenta, "\", " ")

    '            folio_cliente = Replace(folio_cliente, "'", "´")
    '            folio_cliente = Replace(folio_cliente, "/", " ")
    '            folio_cliente = Replace(folio_cliente, Chr(34), "´´")
    '            folio_cliente = Replace(folio_cliente, "&", " ")
    '            folio_cliente = Replace(folio_cliente, "\", " ")

    '            estado_cuenta = Replace(estado_cuenta, "'", "´")
    '            estado_cuenta = Replace(estado_cuenta, "/", " ")
    '            estado_cuenta = Replace(estado_cuenta, Chr(34), "´´")
    '            estado_cuenta = Replace(estado_cuenta, "&", " ")
    '            estado_cuenta = Replace(estado_cuenta, "\", " ")

    '            rut_cliente = LTrim(Replace(rut_cliente, " ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "  ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "   ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "    ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "     ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "      ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "       ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "        ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "         ", " "))

    '            nombre_cliente = RTrim(Replace(nombre_cliente, " ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "  ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "   ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "    ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "     ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "      ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "       ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "        ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "         ", " "))

    '            direccion_cliente = LTrim(Replace(direccion_cliente, " ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "  ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "   ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "    ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "     ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "      ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "       ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "        ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "         ", " "))

    '            telefono_cliente = RTrim(Replace(telefono_cliente, " ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "  ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "   ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "    ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "     ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "      ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "       ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "        ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "         ", " "))

    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, " ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "  ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "   ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "    ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "     ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "      ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "       ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "        ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "         ", " "))

    '            comuna_cliente = RTrim(Replace(comuna_cliente, " ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "  ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "   ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "    ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "     ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "      ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "       ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "        ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "         ", " "))

    '            giro_cliente = LTrim(Replace(giro_cliente, " ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "  ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "   ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "    ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "     ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "      ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "       ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "        ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "         ", " "))

    '            tipo_cliente = LTrim(Replace(tipo_cliente, " ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "  ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "   ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "    ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "     ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "      ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "       ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "        ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "         ", " "))

    '            descuento_1 = RTrim(Replace(descuento_1, " ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "  ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "   ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "    ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "     ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "      ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "       ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "        ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "         ", " "))

    '            descuento_2 = LTrim(Replace(descuento_2, " ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "  ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "   ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "    ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "     ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "      ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "       ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "        ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "         ", " "))

    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, " ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "  ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "   ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "    ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "     ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "      ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "       ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "        ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "         ", " "))

    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, " ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "  ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "   ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "    ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "     ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "      ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "       ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "        ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "         ", " "))

    '            folio_cliente = RTrim(Replace(folio_cliente, " ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "  ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "   ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "    ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "     ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "      ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "       ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "        ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "         ", " "))

    '            estado_cuenta = LTrim(Replace(estado_cuenta, " ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "  ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "   ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "    ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "     ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "      ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "       ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "        ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "         ", " "))

    '            'If rut_cliente <> "-" Then
    '            '    Dim finCadena As String = rut_cliente(rut_cliente.Length - 1).ToString()
    '            '    rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
    '            '    rut_cliente = rut_cliente & "-" & finCadena
    '            'End If

    '            rut_cliente = UCase(rut_cliente)
    '            nombre_cliente = UCase(nombre_cliente)
    '            direccion_cliente = UCase(direccion_cliente)
    '            telefono_cliente = UCase(telefono_cliente)
    '            ciudad_cliente = UCase(ciudad_cliente)
    '            comuna_cliente = UCase(comuna_cliente)
    '            giro_cliente = UCase(giro_cliente)
    '            email_cliente = UCase(email_cliente)
    '            tipo_cliente = UCase(tipo_cliente)
    '            descuento_1 = UCase(descuento_1)
    '            descuento_2 = UCase(descuento_2)
    '            cuenta_cliente = UCase(cuenta_cliente)
    '            tipo_cuenta = UCase(tipo_cuenta)
    '            folio_cliente = UCase(folio_cliente)
    '            estado_cuenta = UCase(estado_cuenta)

    '            If tipo_cliente = "1" Then
    '                tipo_cliente = "EMPRESA"
    '            Else
    '                tipo_cliente = "PERSONA"
    '            End If

    '            'DS.Tables.Clear()
    '            'DT.Rows.Clear()
    '            'DT.Columns.Clear()
    '            'DS.Clear()
    '            'conexion.Open()

    '            'SC.Connection = conexion

    '            'SC.CommandText = "INSERT INTO clientes (tipo_CLIENTE, Rut_cliente, nombre_cliente, direccion_cliente, telefono_cliente, EMAIL_CLIENTE, comuna_cliente, giro_cliente, DESCUENTO_1, CIUDAD_CLIENTE, DESCUENTO_2, FOLIO_CLIENTE, ESTADO_CUENTA, tipo_cuenta, cuenta_cliente) VALUES  ('" & (tipo_cliente) & "','" & (rut_cliente) & "','" & (nombre_cliente) & "','" & (direccion_cliente) & "','" & (telefono_cliente) & "','" & (email_cliente) & "','" & (comuna_cliente) & "','" & (giro_cliente) & "','" & (descuento_1) & "','" & (ciudad_cliente) & "','0','-','SIN CUENTA', '-', 'NO')"
    '            '' SC.CommandText = "INSERT INTO cliente (                                                                                                                                                                                                                                                tipo_CLIENTE,            Rut_cliente,           nombre_cliente,             direccion_cliente,              telefono_cliente,           EMAIL_CLIENTE,      comuna_cliente,            giro_cliente,                DESCUENTO_1,           CIUDAD_CLIENTE, DESCUENTO_2, FOLIO_CLIENTE, ESTADO_CUENTA, tipo_cuenta, cuenta_cliente) VALUES  ('" & (tipo_cliente) & "','" & (rut_cliente) & "','" & (nombre_cliente) & "','" & (direccion_cliente) & "','" & (telefono_cliente) & "','" & (email_cliente) & "','" & (tipo_cliente) & "','" & (giro_cliente) & "','" & (descuento_1) & "','" & (ciudad_cliente) & "','0','-','SIN CUENTA', '-', 'NO')"

    '            'DA.SelectCommand = SC
    '            'DA.Fill(DT)
    '            'conexion.Close()





    '            DS.Tables.Clear()
    '            DT.Rows.Clear()
    '            DT.Columns.Clear()
    '            DS.Clear()
    '            conexion.Open()

    '            SC.Connection = conexion
    '            Consultas_SQL("select * from clienteS where rut_cliente = '" & (rut_cliente) & "'")
    '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '                '  SC.CommandText = "UPDATE productos SET  NOMBRE='" & (nombre) & "', marca='" & (marca) & "',aplicacion='" & (aplicacion) & "', cantidad = '" & (cantidad) & "',precio = '" & (precio) & "', costo = " & (costo) & ", factor = '" & (factor) & "', numero_tecnico = '" & (numero_tecnico) & "' , cantidad_minima = '" & (cantidad_minima) & "' , proveedor = '" & (proveedor) & "' ,  factor = '" & (factor) & "' , codigo_barra = '" & (codigo_barra) & "' ,  familia = '" & (familia) & "', subfamilia = '" & (subfamilia) & "' , ultima_compra = '" & (mifecha2) & "', numero_proveedor = '" & (numero_proveedor) & "', cantidad_ultima_compra = '" & (cantidad_ultima_compra) & "' WHERE cod_producto = " & (cod_producto) & ""
    '            Else
    '                ' SC.CommandText = "insert into productos (cod_producto, nombre, marca, aplicacion, cantidad, precio, costo, factor, numero_tecnico, cantidad_minima, proveedor, margen, codigo_barra, familia, subfamilia, ULTIMA_COMPRA, NUMERO_PROVEEDOR, cantidad_ultima_compra) values ('" & (cod_producto) & "','" & (nombre) & "','" & (marca) & "','" & (aplicacion) & "','" & (cantidad) & "','" & (precio) & "','" & (costo) & "','" & (factor) & "','" & (numero_tecnico) & "','" & (cantidad_minima) & "','" & (proveedor) & "','" & (factor) & "','" & (codigo_barra) & "' ,'" & (familia) & "','" & (subfamilia) & "','" & (mifecha2) & "','" & (numero_proveedor) & "','" & (cantidad_ultima_compra) & "')"
    '                SC.CommandText = "INSERT INTO clienteS (tipo_CLIENTE, Rut_cliente, nombre_cliente, direccion_cliente, telefono_cliente, EMAIL_CLIENTE, comuna_cliente, giro_cliente, DESCUENTO_1, CIUDAD_CLIENTE, DESCUENTO_2, FOLIO_CLIENTE, ESTADO_CUENTA, tipo_cuenta, cuenta_cliente, ORDEN_DE_COMPRA, MENSAJE) VALUES  ('" & (tipo_cliente) & "','" & (rut_cliente) & "','" & (nombre_cliente) & "','" & (direccion_cliente) & "','" & (telefono_cliente) & "','" & (email_cliente) & "','" & (comuna_cliente) & "','" & (giro_cliente) & "','" & (descuento_1) & "','" & (ciudad_cliente) & "','0','-','SIN CUENTA', '-', 'NO', 'NO', 'SIN MENSAJE')"

    '                DA.SelectCommand = SC
    '                DA.Fill(DT)
    '                conexion.Close()
    '            End If














    '            'Consultas_SQL("select * from product where cod_producto = '" & (item) & "'")
    '            'If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            'SC.CommandText = "UPDATE product SET cantidad='" & (cantidad) & "'  WHERE cod_producto = '" & (item) & "'"

    '            'DS.Tables.Clear()
    '            'DT.Rows.Clear()
    '            'DT.Columns.Clear()
    '            'DS.Clear()
    '            'conexion.Open()

    '            'SC.Connection = conexion
    '            'SC.CommandText = "UPDATE pedido SET nombre_cliente='" & (nombre_cliente) & "', telefono_cliente='" & (telefono_cliente) & "'  WHERE codigo_pedido = '" & (codigo_pedido) & "'"
    '            'DA.SelectCommand = SC
    '            'DA.Fill(DT)
    '            'conexion.Close()
    '        Next

    '        'Consultas_SQL("select * from product where cod_producto = '" & (item) & "'")
    '        'If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        '    SC.CommandText = "UPDATE product SET cantidad='" & (cantidad) & "'  WHERE cod_producto = '" & (item) & "'"

    '        '    DS.Tables.Clear()
    '        '    DT.Rows.Clear()
    '        '    DT.Columns.Clear()
    '        '    DS.Clear()
    '        '    conexion.Open()

    '        '    SC.Connection = conexion
    '        '    SC.CommandText = "UPDATE pedido SET nombre_cliente='" & (nombre_cliente) & "', telefono_cliente='" & (telefono_cliente) & "'  WHERE codigo_pedido = '" & (codigo_pedido) & "'"
    '        '    DA.SelectCommand = SC
    '        '    DA.Fill(DT)
    '        '    conexion.Close()
    '        'End If
    '    End If





    '    If txtSelect.Text = "MAECLIEN" Then
    '        ''/para productos
    '        Dim rut_cliente As String
    '        Dim nombre_cliente As String
    '        Dim direccion_cliente As String
    '        Dim telefono_cliente As String
    '        Dim ciudad_cliente As String
    '        Dim comuna_cliente As String
    '        Dim giro_cliente As String
    '        Dim email_cliente As String
    '        Dim tipo_cliente As String
    '        Dim descuento_1 As String
    '        Dim descuento_2 As String
    '        Dim cuenta_cliente As String
    '        Dim tipo_cuenta As String
    '        Dim folio_cliente As String
    '        Dim estado_cuenta As String
    '        Dim tipo_descuento As String
    '        Dim descuento As String
    '        Dim memo As String
    '        Dim orden_c As String
    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            rut_cliente = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            nombre_cliente = dgvDiarios.Rows(i).Cells(2).Value.ToString
    '            direccion_cliente = dgvDiarios.Rows(i).Cells(3).Value.ToString
    '            telefono_cliente = dgvDiarios.Rows(i).Cells(6).Value.ToString
    '            ciudad_cliente = dgvDiarios.Rows(i).Cells(4).Value.ToString
    '            comuna_cliente = dgvDiarios.Rows(i).Cells(5).Value.ToString
    '            giro_cliente = dgvDiarios.Rows(i).Cells(8).Value.ToString
    '            email_cliente = "-"
    '            tipo_cliente = dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            descuento = dgvDiarios.Rows(i).Cells(17).Value.ToString
    '            cuenta_cliente = "SI"
    '            tipo_cuenta = dgvDiarios.Rows(i).Cells(14).Value.ToString
    '            memo = dgvDiarios.Rows(i).Cells(15).Value.ToString
    '            folio_cliente = dgvDiarios.Rows(i).Cells(20).Value.ToString
    '            estado_cuenta = dgvDiarios.Rows(i).Cells(12).Value.ToString
    '            tipo_descuento = dgvDiarios.Rows(i).Cells(13).Value.ToString
    '            orden_c = dgvDiarios.Rows(i).Cells(21).Value.ToString

    '            If nombre_cliente = "" Then
    '                nombre_cliente = "-"
    '            End If

    '            If direccion_cliente = "" Then
    '                direccion_cliente = "-"
    '            End If

    '            If telefono_cliente = "" Then
    '                telefono_cliente = "-"
    '            End If

    '            If ciudad_cliente = "" Then
    '                ciudad_cliente = "0"
    '            End If

    '            If comuna_cliente = "" Then
    '                comuna_cliente = "0"
    '            End If

    '            If giro_cliente = "" Then
    '                giro_cliente = "0"
    '            End If

    '            If email_cliente = "" Then
    '                email_cliente = "-"
    '            End If

    '            If tipo_cliente = "" Then
    '                tipo_cliente = "-"
    '            End If

    '            If descuento = "" Then
    '                descuento = "0"
    '            End If

    '            'If descuento_2 = "" Then
    '            '    descuento_2 = "0"
    '            'End If

    '            If cuenta_cliente = "" Then
    '                cuenta_cliente = "-"
    '            End If

    '            If tipo_cuenta = "" Then
    '                tipo_cuenta = "-"
    '            End If

    '            If folio_cliente = "" Then
    '                folio_cliente = "-"
    '            End If

    '            If estado_cuenta = "" Then
    '                estado_cuenta = "-"
    '            End If

    '            If orden_c = "" Then
    '                orden_c = "1"
    '            End If

    '            If orden_c = "1" Then
    '                orden_c = "SI"
    '            End If
    '            If orden_c = "2" Then
    '                orden_c = "NO"
    '            End If

    '            rut_cliente = Replace(rut_cliente, "'", "´")
    '            rut_cliente = Replace(rut_cliente, "/", " ")
    '            rut_cliente = Replace(rut_cliente, Chr(34), "´´")
    '            rut_cliente = Replace(rut_cliente, "&", " ")
    '            rut_cliente = Replace(rut_cliente, "\", " ")

    '            nombre_cliente = Replace(nombre_cliente, "'", "´")
    '            nombre_cliente = Replace(nombre_cliente, "/", " ")
    '            nombre_cliente = Replace(nombre_cliente, Chr(34), "´´")
    '            nombre_cliente = Replace(nombre_cliente, "&", " ")
    '            nombre_cliente = Replace(nombre_cliente, "\", " ")

    '            direccion_cliente = Replace(direccion_cliente, "'", "´")
    '            direccion_cliente = Replace(direccion_cliente, "/", " ")
    '            direccion_cliente = Replace(direccion_cliente, Chr(34), "´´")
    '            direccion_cliente = Replace(direccion_cliente, "&", " ")
    '            direccion_cliente = Replace(direccion_cliente, "\", " ")

    '            telefono_cliente = Replace(telefono_cliente, "'", "´")
    '            telefono_cliente = Replace(telefono_cliente, "/", " ")
    '            telefono_cliente = Replace(telefono_cliente, Chr(34), "´´")
    '            telefono_cliente = Replace(telefono_cliente, "&", " ")
    '            telefono_cliente = Replace(telefono_cliente, "\", " ")

    '            ciudad_cliente = Replace(ciudad_cliente, "'", "´")
    '            ciudad_cliente = Replace(ciudad_cliente, "/", " ")
    '            ciudad_cliente = Replace(ciudad_cliente, Chr(34), "´´")
    '            ciudad_cliente = Replace(ciudad_cliente, "&", " ")
    '            ciudad_cliente = Replace(ciudad_cliente, "\", " ")

    '            comuna_cliente = Replace(comuna_cliente, "'", "´")
    '            comuna_cliente = Replace(comuna_cliente, "/", " ")
    '            comuna_cliente = Replace(comuna_cliente, Chr(34), "´´")
    '            comuna_cliente = Replace(comuna_cliente, "&", " ")
    '            comuna_cliente = Replace(comuna_cliente, "\", " ")

    '            giro_cliente = Replace(giro_cliente, "'", "´")
    '            giro_cliente = Replace(giro_cliente, "/", " ")
    '            giro_cliente = Replace(giro_cliente, Chr(34), "´´")
    '            giro_cliente = Replace(giro_cliente, "&", " ")
    '            giro_cliente = Replace(giro_cliente, "\", " ")

    '            email_cliente = Replace(email_cliente, "'", "´")
    '            email_cliente = Replace(email_cliente, "/", " ")
    '            email_cliente = Replace(email_cliente, Chr(34), "´´")
    '            email_cliente = Replace(email_cliente, "&", " ")
    '            email_cliente = Replace(email_cliente, "\", " ")

    '            tipo_cliente = Replace(tipo_cliente, "'", "´")
    '            tipo_cliente = Replace(tipo_cliente, "/", " ")
    '            tipo_cliente = Replace(tipo_cliente, Chr(34), "´´")
    '            tipo_cliente = Replace(tipo_cliente, "&", " ")
    '            tipo_cliente = Replace(tipo_cliente, "\", " ")

    '            'descuento_1 = Replace(descuento_1, "'", "´")
    '            'descuento_1 = Replace(descuento_1, "/", " ")
    '            'descuento_1 = Replace(descuento_1, Chr(34), "´´")
    '            'descuento_1 = Replace(descuento_1, "&", " ")
    '            'descuento_1 = Replace(descuento_1, "\", " ")

    '            'descuento_2 = Replace(descuento_2, "'", "´")
    '            'descuento_2 = Replace(descuento_2, "/", " ")
    '            'descuento_2 = Replace(descuento_2, Chr(34), "´´")
    '            'descuento_2 = Replace(descuento_2, "&", " ")
    '            'descuento_2 = Replace(descuento_2, "\", " ")

    '            cuenta_cliente = Replace(cuenta_cliente, "'", "´")
    '            cuenta_cliente = Replace(cuenta_cliente, "/", " ")
    '            cuenta_cliente = Replace(cuenta_cliente, Chr(34), "´´")
    '            cuenta_cliente = Replace(cuenta_cliente, "&", " ")
    '            cuenta_cliente = Replace(cuenta_cliente, "\", " ")

    '            tipo_cuenta = Replace(tipo_cuenta, "'", "´")
    '            tipo_cuenta = Replace(tipo_cuenta, "/", " ")
    '            tipo_cuenta = Replace(tipo_cuenta, Chr(34), "´´")
    '            tipo_cuenta = Replace(tipo_cuenta, "&", " ")
    '            tipo_cuenta = Replace(tipo_cuenta, "\", " ")

    '            folio_cliente = Replace(folio_cliente, "'", "´")
    '            folio_cliente = Replace(folio_cliente, "/", " ")
    '            folio_cliente = Replace(folio_cliente, Chr(34), "´´")
    '            folio_cliente = Replace(folio_cliente, "&", " ")
    '            folio_cliente = Replace(folio_cliente, "\", " ")

    '            estado_cuenta = Replace(estado_cuenta, "'", "´")
    '            estado_cuenta = Replace(estado_cuenta, "/", " ")
    '            estado_cuenta = Replace(estado_cuenta, Chr(34), "´´")
    '            estado_cuenta = Replace(estado_cuenta, "&", " ")
    '            estado_cuenta = Replace(estado_cuenta, "\", " ")

    '            rut_cliente = LTrim(Replace(rut_cliente, " ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "  ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "   ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "    ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "     ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "      ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "       ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "        ", " "))
    '            rut_cliente = LTrim(Replace(rut_cliente, "         ", " "))

    '            nombre_cliente = RTrim(Replace(nombre_cliente, " ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "  ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "   ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "    ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "     ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "      ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "       ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "        ", " "))
    '            nombre_cliente = RTrim(Replace(nombre_cliente, "         ", " "))

    '            direccion_cliente = LTrim(Replace(direccion_cliente, " ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "  ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "   ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "    ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "     ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "      ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "       ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "        ", " "))
    '            direccion_cliente = LTrim(Replace(direccion_cliente, "         ", " "))

    '            telefono_cliente = RTrim(Replace(telefono_cliente, " ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "  ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "   ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "    ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "     ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "      ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "       ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "        ", " "))
    '            telefono_cliente = RTrim(Replace(telefono_cliente, "         ", " "))

    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, " ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "  ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "   ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "    ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "     ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "      ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "       ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "        ", " "))
    '            ciudad_cliente = LTrim(Replace(ciudad_cliente, "         ", " "))

    '            comuna_cliente = RTrim(Replace(comuna_cliente, " ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "  ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "   ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "    ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "     ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "      ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "       ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "        ", " "))
    '            comuna_cliente = RTrim(Replace(comuna_cliente, "         ", " "))

    '            giro_cliente = LTrim(Replace(giro_cliente, " ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "  ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "   ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "    ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "     ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "      ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "       ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "        ", " "))
    '            giro_cliente = LTrim(Replace(giro_cliente, "         ", " "))

    '            tipo_cliente = LTrim(Replace(tipo_cliente, " ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "  ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "   ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "    ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "     ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "      ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "       ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "        ", " "))
    '            tipo_cliente = LTrim(Replace(tipo_cliente, "         ", " "))

    '            descuento_1 = RTrim(Replace(descuento_1, " ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "  ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "   ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "    ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "     ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "      ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "       ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "        ", " "))
    '            descuento_1 = RTrim(Replace(descuento_1, "         ", " "))

    '            descuento_2 = LTrim(Replace(descuento_2, " ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "  ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "   ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "    ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "     ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "      ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "       ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "        ", " "))
    '            descuento_2 = LTrim(Replace(descuento_2, "         ", " "))

    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, " ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "  ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "   ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "    ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "     ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "      ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "       ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "        ", " "))
    '            cuenta_cliente = RTrim(Replace(cuenta_cliente, "         ", " "))

    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, " ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "  ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "   ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "    ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "     ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "      ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "       ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "        ", " "))
    '            tipo_cuenta = LTrim(Replace(tipo_cuenta, "         ", " "))

    '            folio_cliente = RTrim(Replace(folio_cliente, " ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "  ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "   ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "    ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "     ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "      ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "       ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "        ", " "))
    '            folio_cliente = RTrim(Replace(folio_cliente, "         ", " "))

    '            estado_cuenta = LTrim(Replace(estado_cuenta, " ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "  ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "   ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "    ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "     ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "      ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "       ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "        ", " "))
    '            estado_cuenta = LTrim(Replace(estado_cuenta, "         ", " "))


    '            tipo_descuento = RTrim(Replace(tipo_descuento, " ", " "))
    '            tipo_descuento = RTrim(Replace(tipo_descuento, "  ", " "))
    '            tipo_descuento = RTrim(Replace(tipo_descuento, "   ", " "))
    '            tipo_descuento = RTrim(Replace(tipo_descuento, "    ", " "))
    '            tipo_descuento = RTrim(Replace(tipo_descuento, "     ", " "))
    '            tipo_descuento = RTrim(Replace(tipo_descuento, "      ", " "))
    '            tipo_descuento = RTrim(Replace(tipo_descuento, "       ", " "))
    '            tipo_descuento = RTrim(Replace(tipo_descuento, "        ", " "))
    '            tipo_descuento = RTrim(Replace(tipo_descuento, "         ", " "))

    '            tipo_descuento = LTrim(Replace(tipo_descuento, " ", " "))
    '            tipo_descuento = LTrim(Replace(tipo_descuento, "  ", " "))
    '            tipo_descuento = LTrim(Replace(tipo_descuento, "   ", " "))
    '            tipo_descuento = LTrim(Replace(tipo_descuento, "    ", " "))
    '            tipo_descuento = LTrim(Replace(tipo_descuento, "     ", " "))
    '            tipo_descuento = LTrim(Replace(tipo_descuento, "      ", " "))
    '            tipo_descuento = LTrim(Replace(tipo_descuento, "       ", " "))
    '            tipo_descuento = LTrim(Replace(tipo_descuento, "        ", " "))
    '            tipo_descuento = LTrim(Replace(tipo_descuento, "         ", " "))



    '            If rut_cliente <> "-" Then
    '                Dim finCadena As String = rut_cliente(rut_cliente.Length - 1).ToString()
    '                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
    '                rut_cliente = rut_cliente & "-" & finCadena
    '            End If

    '            rut_cliente = UCase(rut_cliente)
    '            nombre_cliente = UCase(nombre_cliente)
    '            direccion_cliente = UCase(direccion_cliente)
    '            telefono_cliente = UCase(telefono_cliente)
    '            ciudad_cliente = UCase(ciudad_cliente)
    '            comuna_cliente = UCase(comuna_cliente)
    '            giro_cliente = UCase(giro_cliente)
    '            email_cliente = UCase(email_cliente)
    '            tipo_cliente = UCase(tipo_cliente)
    '            descuento_1 = UCase(descuento_1)
    '            descuento_2 = UCase(descuento_2)
    '            cuenta_cliente = UCase(cuenta_cliente)
    '            tipo_cuenta = UCase(tipo_cuenta)
    '            folio_cliente = UCase(folio_cliente)
    '            estado_cuenta = UCase(estado_cuenta)

    '            If estado_cuenta = "0" Then
    '                estado_cuenta = "ABIERTA"
    '            Else
    '                estado_cuenta = "CERRADA"
    '            End If

    '            If tipo_cuenta = "G" Then
    '                tipo_cuenta = "FACTURA"
    '            Else
    '                tipo_cuenta = "BOLETA"
    '            End If

    '            If tipo_cliente = "1" Then
    '                tipo_cliente = "EMPRESA"
    '            Else
    '                tipo_cliente = "PERSONA"
    '            End If

    '            If memo = "" Then
    '                memo = "-"
    '            End If

    '            'If rut_cliente = "76481310-3" Then
    '            '    '  rut_cliente = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            '    rut_cliente = "76481310-3"
    '            'End If

    '            If tipo_descuento = "1" Then
    '                descuento_1 = "0"
    '                descuento_2 = descuento
    '            ElseIf tipo_descuento = "0" Then
    '                descuento_1 = descuento
    '                descuento_2 = "0"
    '            Else
    '                descuento_1 = "0"
    '                descuento_2 = descuento
    '            End If



    '            If orden_c = "0" Then
    '                orden_c = "NO"
    '            End If

    '            DS.Tables.Clear()
    '            DT.Rows.Clear()
    '            DT.Columns.Clear()
    '            DS.Clear()
    '            conexion.Open()

    '            SC.Connection = conexion

    '            SC.CommandText = " UPDATE clientes SET `orden_de_compra`= '" & (orden_c) & "' WHERE `rut_cliente`='" & (rut_cliente) & "'"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '            conexion.Close()

    '        Next

    '    End If


    '    If txtSelect.Text = "MAEMOV" Then
    '        ''/para productos
    '        Dim movimiento As String
    '        Dim tipo_doc As String
    '        Dim numero_doc As String
    '        Dim cod_producto As String
    '        Dim cantidad As String
    '        Dim precio As String
    '        Dim fecha As String
    '        Dim rut As String

    '        For i = 0 To dgvDiarios.Rows.Count - 1
    '            movimiento = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            tipo_doc = dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            numero_doc = dgvDiarios.Rows(i).Cells(2).Value.ToString
    '            cod_producto = dgvDiarios.Rows(i).Cells(3).Value.ToString
    '            cantidad = dgvDiarios.Rows(i).Cells(5).Value.ToString
    '            precio = dgvDiarios.Rows(i).Cells(6).Value.ToString
    '            fecha = dgvDiarios.Rows(i).Cells(8).Value.ToString
    '            rut = dgvDiarios.Rows(i).Cells(9).Value.ToString



    '            If movimiento = "" Then
    '                movimiento = "-"
    '            End If

    '            If tipo_doc = "" Then
    '                tipo_doc = "-"
    '            End If

    '            If numero_doc = "" Then
    '                numero_doc = "-"
    '            End If

    '            If cod_producto = "" Then
    '                cod_producto = "-"
    '            End If

    '            If cantidad = "" Then
    '                cantidad = "0"
    '            End If

    '            If precio = "" Then
    '                precio = "0"
    '            End If

    '            If fecha = "" Then
    '                fecha = "-"
    '            End If

    '            If rut = "" Then
    '                rut = "-"
    '            End If

    '            movimiento = Replace(movimiento, "'", "´")
    '            movimiento = Replace(movimiento, Chr(34), "´´")
    '            movimiento = Replace(movimiento, "&", " ")
    '            movimiento = Replace(movimiento, "\", " ")

    '            tipo_doc = Replace(tipo_doc, "'", "´")
    '            tipo_doc = Replace(tipo_doc, Chr(34), "´´")
    '            tipo_doc = Replace(tipo_doc, "&", " ")
    '            tipo_doc = Replace(tipo_doc, "\", " ")

    '            numero_doc = Replace(numero_doc, "'", "´")
    '            numero_doc = Replace(numero_doc, Chr(34), "´´")
    '            numero_doc = Replace(numero_doc, "&", " ")
    '            numero_doc = Replace(numero_doc, "\", " ")

    '            cod_producto = Replace(cod_producto, "'", "´")
    '            cod_producto = Replace(cod_producto, Chr(34), "´´")
    '            cod_producto = Replace(cod_producto, "&", " ")
    '            cod_producto = Replace(cod_producto, "\", " ")

    '            cantidad = Replace(cantidad, "'", "´")
    '            cantidad = Replace(cantidad, Chr(34), "´´")
    '            cantidad = Replace(cantidad, "&", " ")
    '            cantidad = Replace(cantidad, "\", " ")

    '            precio = Replace(precio, "'", "´")
    '            precio = Replace(precio, Chr(34), "´´")
    '            precio = Replace(precio, "&", " ")
    '            precio = Replace(precio, "\", " ")

    '            fecha = Replace(fecha, "'", "´")
    '            fecha = Replace(fecha, Chr(34), "´´")
    '            fecha = Replace(fecha, "&", " ")
    '            fecha = Replace(fecha, "\", " ")

    '            rut = Replace(rut, "'", "´")
    '            rut = Replace(rut, Chr(34), "´´")
    '            rut = Replace(rut, "&", " ")
    '            rut = Replace(rut, "\", " ")

    '            Dim mifecha As Date
    '            mifecha = fecha
    '            mifecha2 = mifecha.ToString("yyy-MM-dd")

    '            movimiento = LTrim(Replace(movimiento, " ", " "))
    '            movimiento = LTrim(Replace(movimiento, "  ", " "))
    '            movimiento = LTrim(Replace(movimiento, "   ", " "))
    '            movimiento = LTrim(Replace(movimiento, "    ", " "))
    '            movimiento = LTrim(Replace(movimiento, "     ", " "))
    '            movimiento = LTrim(Replace(movimiento, "      ", " "))
    '            movimiento = LTrim(Replace(movimiento, "       ", " "))
    '            movimiento = LTrim(Replace(movimiento, "        ", " "))
    '            movimiento = LTrim(Replace(movimiento, "         ", " "))

    '            movimiento = RTrim(Replace(movimiento, " ", " "))
    '            movimiento = RTrim(Replace(movimiento, "  ", " "))
    '            movimiento = RTrim(Replace(movimiento, "   ", " "))
    '            movimiento = RTrim(Replace(movimiento, "    ", " "))
    '            movimiento = RTrim(Replace(movimiento, "     ", " "))
    '            movimiento = RTrim(Replace(movimiento, "      ", " "))
    '            movimiento = RTrim(Replace(movimiento, "       ", " "))
    '            movimiento = RTrim(Replace(movimiento, "        ", " "))
    '            movimiento = RTrim(Replace(movimiento, "         ", " "))


    '            tipo_doc = LTrim(Replace(tipo_doc, " ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "  ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "   ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "    ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "     ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "      ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "       ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "        ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "         ", " "))

    '            tipo_doc = RTrim(Replace(tipo_doc, " ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "  ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "   ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "    ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "     ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "      ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "       ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "        ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "         ", " "))


    '            numero_doc = LTrim(Replace(numero_doc, " ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "  ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "   ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "    ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "     ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "      ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "       ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "        ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "         ", " "))

    '            numero_doc = RTrim(Replace(numero_doc, " ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "  ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "   ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "    ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "     ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "      ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "       ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "        ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "         ", " "))


    '            cod_producto = LTrim(Replace(cod_producto, " ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "  ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "   ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "    ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "     ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "      ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "       ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "        ", " "))
    '            cod_producto = LTrim(Replace(cod_producto, "         ", " "))

    '            cod_producto = RTrim(Replace(cod_producto, " ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "  ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "   ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "    ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "     ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "      ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "       ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "        ", " "))
    '            cod_producto = RTrim(Replace(cod_producto, "         ", " "))



    '            cantidad = LTrim(Replace(cantidad, " ", " "))
    '            cantidad = LTrim(Replace(cantidad, "  ", " "))
    '            cantidad = LTrim(Replace(cantidad, "   ", " "))
    '            cantidad = LTrim(Replace(cantidad, "    ", " "))
    '            cantidad = LTrim(Replace(cantidad, "     ", " "))
    '            cantidad = LTrim(Replace(cantidad, "      ", " "))
    '            cantidad = LTrim(Replace(cantidad, "       ", " "))
    '            cantidad = LTrim(Replace(cantidad, "        ", " "))
    '            cantidad = LTrim(Replace(cantidad, "         ", " "))

    '            cantidad = RTrim(Replace(cantidad, " ", " "))
    '            cantidad = RTrim(Replace(cantidad, "  ", " "))
    '            cantidad = RTrim(Replace(cantidad, "   ", " "))
    '            cantidad = RTrim(Replace(cantidad, "    ", " "))
    '            cantidad = RTrim(Replace(cantidad, "     ", " "))
    '            cantidad = RTrim(Replace(cantidad, "      ", " "))
    '            cantidad = RTrim(Replace(cantidad, "       ", " "))
    '            cantidad = RTrim(Replace(cantidad, "        ", " "))
    '            cantidad = RTrim(Replace(cantidad, "         ", " "))


    '            precio = LTrim(Replace(precio, " ", " "))
    '            precio = LTrim(Replace(precio, "  ", " "))
    '            precio = LTrim(Replace(precio, "   ", " "))
    '            precio = LTrim(Replace(precio, "    ", " "))
    '            precio = LTrim(Replace(precio, "     ", " "))
    '            precio = LTrim(Replace(precio, "      ", " "))
    '            precio = LTrim(Replace(precio, "       ", " "))
    '            precio = LTrim(Replace(precio, "        ", " "))
    '            precio = LTrim(Replace(precio, "         ", " "))

    '            precio = RTrim(Replace(precio, " ", " "))
    '            precio = RTrim(Replace(precio, "  ", " "))
    '            precio = RTrim(Replace(precio, "   ", " "))
    '            precio = RTrim(Replace(precio, "    ", " "))
    '            precio = RTrim(Replace(precio, "     ", " "))
    '            precio = RTrim(Replace(precio, "      ", " "))
    '            precio = RTrim(Replace(precio, "       ", " "))
    '            precio = RTrim(Replace(precio, "        ", " "))
    '            precio = RTrim(Replace(precio, "         ", " "))


    '            fecha = LTrim(Replace(fecha, " ", " "))
    '            fecha = LTrim(Replace(fecha, "  ", " "))
    '            fecha = LTrim(Replace(fecha, "   ", " "))
    '            fecha = LTrim(Replace(fecha, "    ", " "))
    '            fecha = LTrim(Replace(fecha, "     ", " "))
    '            fecha = LTrim(Replace(fecha, "      ", " "))
    '            fecha = LTrim(Replace(fecha, "       ", " "))
    '            fecha = LTrim(Replace(fecha, "        ", " "))
    '            fecha = LTrim(Replace(fecha, "         ", " "))

    '            fecha = RTrim(Replace(fecha, " ", " "))
    '            fecha = RTrim(Replace(fecha, "  ", " "))
    '            fecha = RTrim(Replace(fecha, "   ", " "))
    '            fecha = RTrim(Replace(fecha, "    ", " "))
    '            fecha = RTrim(Replace(fecha, "     ", " "))
    '            fecha = RTrim(Replace(fecha, "      ", " "))
    '            fecha = RTrim(Replace(fecha, "       ", " "))
    '            fecha = RTrim(Replace(fecha, "        ", " "))
    '            fecha = RTrim(Replace(fecha, "         ", " "))


    '            rut = LTrim(Replace(rut, " ", " "))
    '            rut = LTrim(Replace(rut, "  ", " "))
    '            rut = LTrim(Replace(rut, "   ", " "))
    '            rut = LTrim(Replace(rut, "    ", " "))
    '            rut = LTrim(Replace(rut, "     ", " "))
    '            rut = LTrim(Replace(rut, "      ", " "))
    '            rut = LTrim(Replace(rut, "       ", " "))
    '            rut = LTrim(Replace(rut, "        ", " "))
    '            rut = LTrim(Replace(rut, "         ", " "))

    '            rut = RTrim(Replace(rut, " ", " "))
    '            rut = RTrim(Replace(rut, "  ", " "))
    '            rut = RTrim(Replace(rut, "   ", " "))
    '            rut = RTrim(Replace(rut, "    ", " "))
    '            rut = RTrim(Replace(rut, "     ", " "))
    '            rut = RTrim(Replace(rut, "      ", " "))
    '            rut = RTrim(Replace(rut, "       ", " "))
    '            rut = RTrim(Replace(rut, "        ", " "))
    '            rut = RTrim(Replace(rut, "         ", " "))


    '            If rut <> "-" Then
    '                Dim finCadena As String = rut(rut.Length - 1).ToString()
    '                rut = Mid(rut, 1, Len(rut) - 1)
    '                rut = rut & "-" & finCadena
    '            End If

    '            movimiento = UCase(movimiento)
    '            tipo_doc = UCase(tipo_doc)
    '            numero_doc = UCase(numero_doc)
    '            cod_producto = UCase(cod_producto)
    '            cantidad = UCase(cantidad)
    '            precio = UCase(precio)
    '            fecha = UCase(fecha)
    '            rut = UCase(rut)


    '            If movimiento = "S" Then
    '                movimiento = "SALE"
    '            End If

    '            If movimiento = "E" Then
    '                movimiento = "ENTRA"
    '            End If

    '            If tipo_doc = "B" Then
    '                tipo_doc = "BOLETA"
    '            End If

    '            If tipo_doc = "C" Then
    '                tipo_doc = "NOTA DE CREDITO"
    '            End If

    '            If tipo_doc = "F" Then
    '                tipo_doc = "FACTURA"
    '            End If

    '            If tipo_doc = "G" Then
    '                tipo_doc = "GUIA"
    '            End If

    '            If tipo_doc = "V" Then
    '                tipo_doc = "VALE"
    '            End If

    '            If tipo_doc = "P" Then
    '                tipo_doc = "COTIZACION"
    '            End If

    '            SC.Connection = conexion
    '            cantidad = Int(cantidad)
    '            SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, FECHA) values('" & (numero_doc) & "','" & (tipo_doc) & "', '" & (cod_producto) & "','-','" & (precio) & "','" & (cantidad) & "','0','0', '0','0','0','" & (movimiento) & "','" & (mifecha2) & "')"

    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '            conexion.Close()
    '            '  End If       
    '        Next

    '    End If






















    '    If txtSelect.Text = "VENTAS" Then
    '        ''/para productos
    '        Dim movimiento As String
    '        Dim tipo_doc As String
    '        Dim numero_doc As String
    '        Dim vendedor As String
    '        Dim subtotal As String
    '        Dim descuento As String
    '        Dim total As String
    '        Dim condicion As String
    '        Dim fecha As String
    '        Dim rut As String
    '        Dim hora As String


    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            movimiento = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            tipo_doc = dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            numero_doc = dgvDiarios.Rows(i).Cells(2).Value.ToString
    '            vendedor = dgvDiarios.Rows(i).Cells(3).Value.ToString
    '            subtotal = dgvDiarios.Rows(i).Cells(4).Value.ToString
    '            descuento = dgvDiarios.Rows(i).Cells(5).Value.ToString
    '            total = dgvDiarios.Rows(i).Cells(6).Value.ToString
    '            condicion = dgvDiarios.Rows(i).Cells(8).Value.ToString
    '            fecha = dgvDiarios.Rows(i).Cells(9).Value.ToString
    '            rut = dgvDiarios.Rows(i).Cells(10).Value.ToString
    '            hora = dgvDiarios.Rows(i).Cells(11).Value.ToString



    '            If movimiento = "" Then
    '                movimiento = "-"
    '            End If

    '            If tipo_doc = "" Then
    '                tipo_doc = "-"
    '            End If

    '            If numero_doc = "" Then
    '                numero_doc = "-"
    '            End If

    '            If vendedor = "" Then
    '                vendedor = "-"
    '            End If

    '            If subtotal = "" Then
    '                subtotal = "0"
    '            End If

    '            If descuento = "" Then
    '                descuento = "0"
    '            End If

    '            If total = "" Then
    '                total = "-"
    '            End If

    '            If condicion = "" Then
    '                condicion = "-"
    '            End If

    '            If fecha = "" Then
    '                fecha = "-"
    '            End If

    '            If rut = "" Then
    '                rut = "-"
    '            End If

    '            If hora = "" Then
    '                hora = "-"
    '            End If

    '            movimiento = Replace(movimiento, "'", "´")
    '            movimiento = Replace(movimiento, Chr(34), "´´")
    '            movimiento = Replace(movimiento, "&", " ")
    '            movimiento = Replace(movimiento, "\", " ")

    '            tipo_doc = Replace(tipo_doc, "'", "´")
    '            tipo_doc = Replace(tipo_doc, Chr(34), "´´")
    '            tipo_doc = Replace(tipo_doc, "&", " ")
    '            tipo_doc = Replace(tipo_doc, "\", " ")

    '            numero_doc = Replace(numero_doc, "'", "´")
    '            numero_doc = Replace(numero_doc, Chr(34), "´´")
    '            numero_doc = Replace(numero_doc, "&", " ")
    '            numero_doc = Replace(numero_doc, "\", " ")

    '            vendedor = Replace(vendedor, "'", "´")
    '            vendedor = Replace(vendedor, Chr(34), "´´")
    '            vendedor = Replace(vendedor, "&", " ")
    '            vendedor = Replace(vendedor, "\", " ")

    '            subtotal = Replace(subtotal, "'", "´")
    '            subtotal = Replace(subtotal, Chr(34), "´´")
    '            subtotal = Replace(subtotal, "&", " ")
    '            subtotal = Replace(subtotal, "\", " ")

    '            descuento = Replace(descuento, "'", "´")
    '            descuento = Replace(descuento, Chr(34), "´´")
    '            descuento = Replace(descuento, "&", " ")
    '            descuento = Replace(descuento, "\", " ")

    '            total = Replace(total, "'", "´")
    '            total = Replace(total, Chr(34), "´´")
    '            total = Replace(total, "&", " ")
    '            total = Replace(total, "\", " ")

    '            condicion = Replace(condicion, "'", "´")
    '            condicion = Replace(condicion, Chr(34), "´´")
    '            condicion = Replace(condicion, "&", " ")
    '            condicion = Replace(condicion, "\", " ")

    '            fecha = Replace(fecha, "'", "´")
    '            fecha = Replace(fecha, Chr(34), "´´")
    '            fecha = Replace(fecha, "&", " ")
    '            fecha = Replace(fecha, "\", " ")

    '            rut = Replace(rut, "'", "´")
    '            rut = Replace(rut, Chr(34), "´´")
    '            rut = Replace(rut, "&", " ")
    '            rut = Replace(rut, "\", " ")

    '            hora = Replace(hora, "'", "´")
    '            hora = Replace(hora, Chr(34), "´´")
    '            hora = Replace(hora, "&", " ")
    '            hora = Replace(hora, "\", " ")

    '            Dim mifecha As Date
    '            mifecha = fecha
    '            mifecha2 = mifecha.ToString("yyy-MM-dd")

    '            movimiento = LTrim(Replace(movimiento, " ", " "))
    '            movimiento = LTrim(Replace(movimiento, "  ", " "))
    '            movimiento = LTrim(Replace(movimiento, "   ", " "))
    '            movimiento = LTrim(Replace(movimiento, "    ", " "))
    '            movimiento = LTrim(Replace(movimiento, "     ", " "))
    '            movimiento = LTrim(Replace(movimiento, "      ", " "))
    '            movimiento = LTrim(Replace(movimiento, "       ", " "))
    '            movimiento = LTrim(Replace(movimiento, "        ", " "))
    '            movimiento = LTrim(Replace(movimiento, "         ", " "))

    '            movimiento = RTrim(Replace(movimiento, " ", " "))
    '            movimiento = RTrim(Replace(movimiento, "  ", " "))
    '            movimiento = RTrim(Replace(movimiento, "   ", " "))
    '            movimiento = RTrim(Replace(movimiento, "    ", " "))
    '            movimiento = RTrim(Replace(movimiento, "     ", " "))
    '            movimiento = RTrim(Replace(movimiento, "      ", " "))
    '            movimiento = RTrim(Replace(movimiento, "       ", " "))
    '            movimiento = RTrim(Replace(movimiento, "        ", " "))
    '            movimiento = RTrim(Replace(movimiento, "         ", " "))


    '            tipo_doc = LTrim(Replace(tipo_doc, " ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "  ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "   ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "    ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "     ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "      ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "       ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "        ", " "))
    '            tipo_doc = LTrim(Replace(tipo_doc, "         ", " "))

    '            tipo_doc = RTrim(Replace(tipo_doc, " ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "  ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "   ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "    ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "     ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "      ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "       ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "        ", " "))
    '            tipo_doc = RTrim(Replace(tipo_doc, "         ", " "))


    '            numero_doc = LTrim(Replace(numero_doc, " ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "  ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "   ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "    ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "     ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "      ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "       ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "        ", " "))
    '            numero_doc = LTrim(Replace(numero_doc, "         ", " "))

    '            numero_doc = RTrim(Replace(numero_doc, " ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "  ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "   ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "    ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "     ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "      ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "       ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "        ", " "))
    '            numero_doc = RTrim(Replace(numero_doc, "         ", " "))


    '            vendedor = LTrim(Replace(vendedor, " ", " "))
    '            vendedor = LTrim(Replace(vendedor, "  ", " "))
    '            vendedor = LTrim(Replace(vendedor, "   ", " "))
    '            vendedor = LTrim(Replace(vendedor, "    ", " "))
    '            vendedor = LTrim(Replace(vendedor, "     ", " "))
    '            vendedor = LTrim(Replace(vendedor, "      ", " "))
    '            vendedor = LTrim(Replace(vendedor, "       ", " "))
    '            vendedor = LTrim(Replace(vendedor, "        ", " "))
    '            vendedor = LTrim(Replace(vendedor, "         ", " "))

    '            vendedor = RTrim(Replace(vendedor, " ", " "))
    '            vendedor = RTrim(Replace(vendedor, "  ", " "))
    '            vendedor = RTrim(Replace(vendedor, "   ", " "))
    '            vendedor = RTrim(Replace(vendedor, "    ", " "))
    '            vendedor = RTrim(Replace(vendedor, "     ", " "))
    '            vendedor = RTrim(Replace(vendedor, "      ", " "))
    '            vendedor = RTrim(Replace(vendedor, "       ", " "))
    '            vendedor = RTrim(Replace(vendedor, "        ", " "))
    '            vendedor = RTrim(Replace(vendedor, "         ", " "))


    '            subtotal = LTrim(Replace(subtotal, " ", " "))
    '            subtotal = LTrim(Replace(subtotal, "  ", " "))
    '            subtotal = LTrim(Replace(subtotal, "   ", " "))
    '            subtotal = LTrim(Replace(subtotal, "    ", " "))
    '            subtotal = LTrim(Replace(subtotal, "     ", " "))
    '            subtotal = LTrim(Replace(subtotal, "      ", " "))
    '            subtotal = LTrim(Replace(subtotal, "       ", " "))
    '            subtotal = LTrim(Replace(subtotal, "        ", " "))
    '            subtotal = LTrim(Replace(subtotal, "         ", " "))

    '            subtotal = RTrim(Replace(subtotal, " ", " "))
    '            subtotal = RTrim(Replace(subtotal, "  ", " "))
    '            subtotal = RTrim(Replace(subtotal, "   ", " "))
    '            subtotal = RTrim(Replace(subtotal, "    ", " "))
    '            subtotal = RTrim(Replace(subtotal, "     ", " "))
    '            subtotal = RTrim(Replace(subtotal, "      ", " "))
    '            subtotal = RTrim(Replace(subtotal, "       ", " "))
    '            subtotal = RTrim(Replace(subtotal, "        ", " "))
    '            subtotal = RTrim(Replace(subtotal, "         ", " "))


    '            descuento = LTrim(Replace(descuento, " ", " "))
    '            descuento = LTrim(Replace(descuento, "  ", " "))
    '            descuento = LTrim(Replace(descuento, "   ", " "))
    '            descuento = LTrim(Replace(descuento, "    ", " "))
    '            descuento = LTrim(Replace(descuento, "     ", " "))
    '            descuento = LTrim(Replace(descuento, "      ", " "))
    '            descuento = LTrim(Replace(descuento, "       ", " "))
    '            descuento = LTrim(Replace(descuento, "        ", " "))
    '            descuento = LTrim(Replace(descuento, "         ", " "))

    '            descuento = RTrim(Replace(descuento, " ", " "))
    '            descuento = RTrim(Replace(descuento, "  ", " "))
    '            descuento = RTrim(Replace(descuento, "   ", " "))
    '            descuento = RTrim(Replace(descuento, "    ", " "))
    '            descuento = RTrim(Replace(descuento, "     ", " "))
    '            descuento = RTrim(Replace(descuento, "      ", " "))
    '            descuento = RTrim(Replace(descuento, "       ", " "))
    '            descuento = RTrim(Replace(descuento, "        ", " "))
    '            descuento = RTrim(Replace(descuento, "         ", " "))

    '            total = LTrim(Replace(total, " ", " "))
    '            total = LTrim(Replace(total, "  ", " "))
    '            total = LTrim(Replace(total, "   ", " "))
    '            total = LTrim(Replace(total, "    ", " "))
    '            total = LTrim(Replace(total, "     ", " "))
    '            total = LTrim(Replace(total, "      ", " "))
    '            total = LTrim(Replace(total, "       ", " "))
    '            total = LTrim(Replace(total, "        ", " "))
    '            total = LTrim(Replace(total, "         ", " "))

    '            total = RTrim(Replace(total, " ", " "))
    '            total = RTrim(Replace(total, "  ", " "))
    '            total = RTrim(Replace(total, "   ", " "))
    '            total = RTrim(Replace(total, "    ", " "))
    '            total = RTrim(Replace(total, "     ", " "))
    '            total = RTrim(Replace(total, "      ", " "))
    '            total = RTrim(Replace(total, "       ", " "))
    '            total = RTrim(Replace(total, "        ", " "))
    '            total = RTrim(Replace(total, "         ", " "))


    '            condicion = LTrim(Replace(condicion, " ", " "))
    '            condicion = LTrim(Replace(condicion, "  ", " "))
    '            condicion = LTrim(Replace(condicion, "   ", " "))
    '            condicion = LTrim(Replace(condicion, "    ", " "))
    '            condicion = LTrim(Replace(condicion, "     ", " "))
    '            condicion = LTrim(Replace(condicion, "      ", " "))
    '            condicion = LTrim(Replace(condicion, "       ", " "))
    '            condicion = LTrim(Replace(condicion, "        ", " "))
    '            condicion = LTrim(Replace(condicion, "         ", " "))

    '            condicion = RTrim(Replace(condicion, " ", " "))
    '            condicion = RTrim(Replace(condicion, "  ", " "))
    '            condicion = RTrim(Replace(condicion, "   ", " "))
    '            condicion = RTrim(Replace(condicion, "    ", " "))
    '            condicion = RTrim(Replace(condicion, "     ", " "))
    '            condicion = RTrim(Replace(condicion, "      ", " "))
    '            condicion = RTrim(Replace(condicion, "       ", " "))
    '            condicion = RTrim(Replace(condicion, "        ", " "))
    '            condicion = RTrim(Replace(condicion, "         ", " "))


    '            fecha = LTrim(Replace(fecha, " ", " "))
    '            fecha = LTrim(Replace(fecha, "  ", " "))
    '            fecha = LTrim(Replace(fecha, "   ", " "))
    '            fecha = LTrim(Replace(fecha, "    ", " "))
    '            fecha = LTrim(Replace(fecha, "     ", " "))
    '            fecha = LTrim(Replace(fecha, "      ", " "))
    '            fecha = LTrim(Replace(fecha, "       ", " "))
    '            fecha = LTrim(Replace(fecha, "        ", " "))
    '            fecha = LTrim(Replace(fecha, "         ", " "))

    '            fecha = RTrim(Replace(fecha, " ", " "))
    '            fecha = RTrim(Replace(fecha, "  ", " "))
    '            fecha = RTrim(Replace(fecha, "   ", " "))
    '            fecha = RTrim(Replace(fecha, "    ", " "))
    '            fecha = RTrim(Replace(fecha, "     ", " "))
    '            fecha = RTrim(Replace(fecha, "      ", " "))
    '            fecha = RTrim(Replace(fecha, "       ", " "))
    '            fecha = RTrim(Replace(fecha, "        ", " "))
    '            fecha = RTrim(Replace(fecha, "         ", " "))


    '            rut = LTrim(Replace(rut, " ", " "))
    '            rut = LTrim(Replace(rut, "  ", " "))
    '            rut = LTrim(Replace(rut, "   ", " "))
    '            rut = LTrim(Replace(rut, "    ", " "))
    '            rut = LTrim(Replace(rut, "     ", " "))
    '            rut = LTrim(Replace(rut, "      ", " "))
    '            rut = LTrim(Replace(rut, "       ", " "))
    '            rut = LTrim(Replace(rut, "        ", " "))
    '            rut = LTrim(Replace(rut, "         ", " "))

    '            rut = RTrim(Replace(rut, " ", " "))
    '            rut = RTrim(Replace(rut, "  ", " "))
    '            rut = RTrim(Replace(rut, "   ", " "))
    '            rut = RTrim(Replace(rut, "    ", " "))
    '            rut = RTrim(Replace(rut, "     ", " "))
    '            rut = RTrim(Replace(rut, "      ", " "))
    '            rut = RTrim(Replace(rut, "       ", " "))
    '            rut = RTrim(Replace(rut, "        ", " "))
    '            rut = RTrim(Replace(rut, "         ", " "))


    '            hora = LTrim(Replace(hora, " ", " "))
    '            hora = LTrim(Replace(hora, "  ", " "))
    '            hora = LTrim(Replace(hora, "   ", " "))
    '            hora = LTrim(Replace(hora, "    ", " "))
    '            hora = LTrim(Replace(hora, "     ", " "))
    '            hora = LTrim(Replace(hora, "      ", " "))
    '            hora = LTrim(Replace(hora, "       ", " "))
    '            hora = LTrim(Replace(hora, "        ", " "))
    '            hora = LTrim(Replace(hora, "         ", " "))

    '            hora = RTrim(Replace(hora, " ", " "))
    '            hora = RTrim(Replace(hora, "  ", " "))
    '            hora = RTrim(Replace(hora, "   ", " "))
    '            hora = RTrim(Replace(hora, "    ", " "))
    '            hora = RTrim(Replace(hora, "     ", " "))
    '            hora = RTrim(Replace(hora, "      ", " "))
    '            hora = RTrim(Replace(hora, "       ", " "))
    '            hora = RTrim(Replace(hora, "        ", " "))
    '            hora = RTrim(Replace(hora, "         ", " "))

    '            If rut <> "-" Then
    '                Dim finCadena As String = rut(rut.Length - 1).ToString()
    '                rut = Mid(rut, 1, Len(rut) - 1)
    '                rut = rut & "-" & finCadena
    '            End If

    '            movimiento = UCase(movimiento)
    '            tipo_doc = UCase(tipo_doc)
    '            numero_doc = UCase(numero_doc)
    '            vendedor = UCase(vendedor)
    '            subtotal = UCase(subtotal)
    '            descuento = UCase(descuento)
    '            total = UCase(total)
    '            condicion = UCase(condicion)
    '            fecha = UCase(fecha)
    '            rut = UCase(rut)
    '            hora = UCase(hora)

    '            If movimiento = "S" Then
    '                movimiento = "SALE"
    '            End If

    '            If movimiento = "E" Then
    '                movimiento = "ENTRA"
    '            End If

    '            If tipo_doc = "B" Then
    '                tipo_doc = "BOLETA"
    '            End If

    '            If tipo_doc = "C" Then
    '                tipo_doc = "NOTA DE CREDITO"
    '            End If

    '            If tipo_doc = "F" Then
    '                tipo_doc = "FACTURA"
    '            End If

    '            If tipo_doc = "G" Then
    '                tipo_doc = "GUIA"
    '            End If

    '            If tipo_doc = "V" Then
    '                tipo_doc = "VALE"
    '            End If


    '            SC.Connection = conexion
    '            SC.CommandText = "insert into total (n_total, TIPO, rut,codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, desglose, condiciones, estado, usuario_responsable, movimiento, hora, porcentaje_desc) values (" & (numero_doc) & " , '" & (tipo_doc) & "', '" & (rut) & "', '-','" & (mifecha2) & "'," & (descuento) & ",'0','0'," & (subtotal) & "," & (total) & ", '-','" & (condicion) & "','" & ("SIN FACTURAR") & "','" & (vendedor) & "','" & (movimiento) & "','" & (hora) & "','0')"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '        Next

    '    End If







    '    If txtSelect.Text = "Detlet" Then
    '        ''/para productos
    '        Dim n_creditos As Integer
    '        Dim TIPO As String
    '        Dim tipo_detalle As String
    '        Dim codigo_cliente As String
    '        Dim rut_cliente As String
    '        Dim fecha_vencimiento As String
    '        Dim total As String
    '        Dim saldo As String

    '        Dim condiciones As String
    '        Dim estado As String
    '        Dim codigo_afecta As String
    '        Dim nombre_afecta As String
    '        Dim recinto As String
    '        Dim nro_cuota As String
    '        Dim total_cuotas As String
    '        Dim interes As String
    '        Dim gastos_de_cobranza As String
    '        Dim fecha_pago As String
    '        Dim nro_doc As String
    '        Dim fecha_emision As String
    '        Dim haber As String
    '        n_creditos = 1

    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            TIPO = "BOLETA"
    '            tipo_detalle = "BOLETA"
    '            codigo_cliente = "-"
    '            rut_cliente = dgvDiarios.Rows(i).Cells(0).Value.ToString & "-" & dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            nro_doc = dgvDiarios.Rows(i).Cells(2).Value.ToString
    '            fecha_emision = dgvDiarios.Rows(i).Cells(3).Value.ToString
    '            nro_cuota = dgvDiarios.Rows(i).Cells(4).Value.ToString
    '            total_cuotas = dgvDiarios.Rows(i).Cells(5).Value.ToString
    '            fecha_vencimiento = dgvDiarios.Rows(i).Cells(6).Value.ToString
    '            total = dgvDiarios.Rows(i).Cells(7).Value.ToString
    '            interes = dgvDiarios.Rows(i).Cells(8).Value.ToString
    '            gastos_de_cobranza = dgvDiarios.Rows(i).Cells(9).Value.ToString
    '            haber = dgvDiarios.Rows(i).Cells(10).Value.ToString
    '            fecha_pago = dgvDiarios.Rows(i).Cells(11).Value.ToString
    '            saldo = dgvDiarios.Rows(i).Cells(12).Value.ToString
    '            condiciones = "CREDITO"

    '            estado = "EMITIDA"

    '            codigo_afecta = dgvDiarios.Rows(i).Cells(2).Value.ToString
    '            nombre_afecta = "BOLETA"
    '            recinto = "BOLETA"

    '            tipo_detalle = "BOLETA " & codigo_afecta & " CUOTA " & dgvDiarios.Rows(i).Cells(4).Value.ToString
    '            If total = "" Then
    '                total = "0"
    '            End If

    '            If saldo = "" Then
    '                saldo = "0"
    '            End If

    '            If fecha_pago <> "" Then
    '                Dim mifechapago As Date
    '                mifechapago = fecha_pago
    '                fecha_pago = mifechapago.ToString("yyy-MM-dd")
    '            End If

    '            If fecha_emision <> "" Then
    '                Dim mifechaemision As Date
    '                mifechaemision = fecha_emision
    '                fecha_emision = mifechaemision.ToString("yyy-MM-dd")
    '            End If

    '            If fecha_vencimiento <> "" Then
    '                Dim mifechavencimiento As Date
    '                mifechavencimiento = fecha_vencimiento
    '                fecha_vencimiento = mifechavencimiento.ToString("yyy-MM-dd")
    '            End If

    '            If fecha_emision = "" Then
    '                fecha_emision = "000-00-00"
    '            End If

    '            If fecha_vencimiento = "" Then
    '                fecha_vencimiento = "000-00-00"
    '            End If

    '            If fecha_pago = "" Then
    '                fecha_pago = "000-00-00"
    '            End If


    '            If interes = "" Then
    '                interes = "0"
    '            End If

    '            If gastos_de_cobranza = "" Then
    '                gastos_de_cobranza = "0"
    '            End If

    '            If nro_doc <> 0 Then
    '                saldo = Int(total) + Int(interes) + Int(gastos_de_cobranza) - haber


    '                'If nro_doc = "785737" Then
    '                '    MsgBox("f")
    '                'End If


    '                conexion.Close()
    '                Consultas_SQL("select * from creditos where codigo_afecta = '" & (nro_doc) & "' and numero_cuota ='" & (nro_cuota) & "' AND rut_cliente ='" & (rut_cliente) & "'")
    '                If DS.Tables(DT.TableName).Rows.Count <> 0 Then


    '                    SC.Connection = conexion
    '                    SC.CommandText = "update creditos set saldo = saldo -" & (Int(haber)) & " where codigo_afecta = '" & (nro_doc) & "' and numero_cuota ='" & (nro_cuota) & "' and saldo <> 0   and rut_cliente ='" & (rut_cliente) & "'"
    '                    DA.SelectCommand = SC
    '                    DA.Fill(DT)


    '                Else

    '                    SC.Connection = conexion
    '                    SC.CommandText = "insert into  creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, desglose, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza) values (" & (n_creditos) & ",'" & ("BOLETA") & "','" & (tipo_detalle) & "','" & (rut_cliente) & "','-','" & (fecha_emision) & "','0','0','0','0'," & (total) & "," & (saldo) & ",'-','CREDITO','" & ("EMITIDA") & "','" & (miusuario) & "','" & (nro_doc) & "','BOLETA','MANUEL RODRIGUEZ', '" & (fecha_vencimiento) & "','" & (fecha_pago) & "','" & (nro_cuota) & "','" & (total_cuotas) & "','" & (interes) & "','" & (gastos_de_cobranza) & "')"
    '                    DA.SelectCommand = SC
    '                    DA.Fill(DT)

    '                End If
    '                SC.Connection = conexion
    '                SC.CommandText = "update creditos set saldo = 0 where saldo < 0"
    '                DA.SelectCommand = SC
    '                DA.Fill(DT)

    '                n_creditos = n_creditos + 1

    '            End If
    '        Next

    '    End If



    '    If txtSelect.Text = "MAEDAT" Then
    '        ''/para productos
    '        Dim rut_proveedor As String
    '        Dim nombre_proveedor As String
    '        Dim direccion_proveedor As String
    '        Dim ciudad_proveedor As String
    '        Dim comuna_proveedor As String
    '        Dim telefono_proveedor As String
    '        Dim giro_proveedor As String
    '        Dim representante_proveedor As String




    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            rut_proveedor = dgvDiarios.Rows(i).Cells(0).Value.ToString & "-" & dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            nombre_proveedor = dgvDiarios.Rows(i).Cells(2).Value.ToString
    '            direccion_proveedor = dgvDiarios.Rows(i).Cells(5).Value.ToString
    '            ciudad_proveedor = dgvDiarios.Rows(i).Cells(6).Value.ToString
    '            comuna_proveedor = "-"
    '            telefono_proveedor = dgvDiarios.Rows(i).Cells(7).Value.ToString
    '            giro_proveedor = dgvDiarios.Rows(i).Cells(4).Value.ToString
    '            representante_proveedor = "-"





    '            If rut_proveedor = "" Then
    '                rut_proveedor = "-"
    '            End If

    '            If nombre_proveedor = "" Then
    '                nombre_proveedor = "-"
    '            End If

    '            If direccion_proveedor = "" Then
    '                direccion_proveedor = "-"
    '            End If

    '            If ciudad_proveedor = "" Then
    '                ciudad_proveedor = "-"
    '            End If

    '            If comuna_proveedor = "" Then
    '                comuna_proveedor = "0"
    '            End If

    '            If telefono_proveedor = "" Then
    '                telefono_proveedor = "0"
    '            End If

    '            If giro_proveedor = "" Then
    '                giro_proveedor = "-"
    '            End If

    '            If representante_proveedor = "" Then
    '                representante_proveedor = "-"
    '            End If


    '            rut_proveedor = Replace(rut_proveedor, "'", "´")
    '            rut_proveedor = Replace(rut_proveedor, Chr(34), "´´")
    '            rut_proveedor = Replace(rut_proveedor, "&", " ")
    '            rut_proveedor = Replace(rut_proveedor, "\", " ")

    '            nombre_proveedor = Replace(nombre_proveedor, "'", "´")
    '            nombre_proveedor = Replace(nombre_proveedor, Chr(34), "´´")
    '            nombre_proveedor = Replace(nombre_proveedor, "&", " ")
    '            nombre_proveedor = Replace(nombre_proveedor, "\", " ")

    '            direccion_proveedor = Replace(direccion_proveedor, "'", "´")
    '            direccion_proveedor = Replace(direccion_proveedor, Chr(34), "´´")
    '            direccion_proveedor = Replace(direccion_proveedor, "&", " ")
    '            direccion_proveedor = Replace(direccion_proveedor, "\", " ")

    '            ciudad_proveedor = Replace(ciudad_proveedor, "'", "´")
    '            ciudad_proveedor = Replace(ciudad_proveedor, Chr(34), "´´")
    '            ciudad_proveedor = Replace(ciudad_proveedor, "&", " ")
    '            ciudad_proveedor = Replace(ciudad_proveedor, "\", " ")

    '            comuna_proveedor = Replace(comuna_proveedor, "'", "´")
    '            comuna_proveedor = Replace(comuna_proveedor, Chr(34), "´´")
    '            comuna_proveedor = Replace(comuna_proveedor, "&", " ")
    '            comuna_proveedor = Replace(comuna_proveedor, "\", " ")

    '            telefono_proveedor = Replace(telefono_proveedor, "'", "´")
    '            telefono_proveedor = Replace(telefono_proveedor, Chr(34), "´´")
    '            telefono_proveedor = Replace(telefono_proveedor, "&", " ")
    '            telefono_proveedor = Replace(telefono_proveedor, "\", " ")

    '            giro_proveedor = Replace(giro_proveedor, "'", "´")
    '            giro_proveedor = Replace(giro_proveedor, Chr(34), "´´")
    '            giro_proveedor = Replace(giro_proveedor, "&", " ")
    '            giro_proveedor = Replace(giro_proveedor, "\", " ")

    '            representante_proveedor = Replace(representante_proveedor, "'", "´")
    '            representante_proveedor = Replace(representante_proveedor, Chr(34), "´´")
    '            representante_proveedor = Replace(representante_proveedor, "&", " ")
    '            representante_proveedor = Replace(representante_proveedor, "\", " ")


    '            rut_proveedor = LTrim(Replace(rut_proveedor, " ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "  ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "   ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "    ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "     ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "      ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "       ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "        ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "         ", " "))

    '            rut_proveedor = RTrim(Replace(rut_proveedor, " ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "  ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "   ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "    ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "     ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "      ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "       ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "        ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "         ", " "))


    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, " ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "  ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "   ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "    ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "     ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "      ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "       ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "        ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "         ", " "))

    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, " ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "  ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "   ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "    ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "     ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "      ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "       ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "        ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "         ", " "))


    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, " ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "  ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "   ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "    ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "     ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "      ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "       ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "        ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "         ", " "))

    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, " ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "  ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "   ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "    ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "     ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "      ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "       ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "        ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "         ", " "))

    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, " ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "  ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "   ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "    ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "     ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "      ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "       ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "        ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "         ", " "))

    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, " ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "  ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "   ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "    ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "     ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "      ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "       ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "        ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "         ", " "))

    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, " ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "  ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "   ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "    ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "     ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "      ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "       ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "        ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "         ", " "))

    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, " ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "  ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "   ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "    ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "     ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "      ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "       ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "        ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "         ", " "))


    '            giro_proveedor = LTrim(Replace(giro_proveedor, " ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "  ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "   ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "    ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "     ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "      ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "       ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "        ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "         ", " "))

    '            giro_proveedor = RTrim(Replace(giro_proveedor, " ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "  ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "   ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "    ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "     ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "      ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "       ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "        ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "         ", " "))

    '            representante_proveedor = LTrim(Replace(representante_proveedor, " ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "  ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "   ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "    ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "     ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "      ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "       ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "        ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "         ", " "))

    '            representante_proveedor = RTrim(Replace(representante_proveedor, " ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "  ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "   ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "    ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "     ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "      ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "       ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "        ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "         ", " "))

    '            'If rut_proveedor <> "-" Then
    '            '    Dim finCadena As String = rut_proveedor(rut_proveedor.Length - 1).ToString()
    '            '    rut_proveedor = Mid(rut_proveedor, 1, Len(rut_proveedor) - 1)
    '            '    rut_proveedor = rut_proveedor & "-" & finCadena
    '            'End If

    '            rut_proveedor = UCase(rut_proveedor)
    '            nombre_proveedor = UCase(nombre_proveedor)
    '            direccion_proveedor = UCase(direccion_proveedor)
    '            ciudad_proveedor = UCase(ciudad_proveedor)
    '            comuna_proveedor = UCase(comuna_proveedor)
    '            telefono_proveedor = UCase(telefono_proveedor)
    '            giro_proveedor = UCase(giro_proveedor)
    '            representante_proveedor = UCase(representante_proveedor)










    '            DS.Tables.Clear()
    '            DT.Rows.Clear()
    '            DT.Columns.Clear()
    '            DS.Clear()
    '            conexion.Open()

    '            SC.Connection = conexion
    '            Consultas_SQL("select * from proveedores where rut_proveedor = '" & (rut_proveedor) & "'")
    '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '                SC.CommandText = "UPDATE PROVEEDORES SET NOMBRE_PROVEEDOR='" & (nombre_proveedor) & "', DIRECCION_PROVEEDOR='" & (direccion_proveedor) & "', TELEFONO_PROVEEDOR = '" & (telefono_proveedor) & "', EMAIL_PROVEEDOR = '-', CIUDAD_PROVEEDOR = '" & (ciudad_proveedor) & "', COMUNA_PROVEEDOR = '" & (comuna_proveedor) & "', GIRO_PROVEEDOR = '" & (giro_proveedor) & "', REPRESENTANTE_PROVEEDOR = '" & (representante_proveedor) & "', CREDITO_PROVEEDOR = '0' WHERE RUT_PROVEEDOR = '" & (rut_proveedor) & "'"
    '                DA.SelectCommand = SC
    '                DA.Fill(DT)
    '                conexion.Close()

    '                '  SC.CommandText = "UPDATE productos SET  NOMBRE='" & (nombre) & "', marca='" & (marca) & "',aplicacion='" & (aplicacion) & "', cantidad = '" & (cantidad) & "',precio = '" & (precio) & "', costo = " & (costo) & ", factor = '" & (factor) & "', numero_tecnico = '" & (numero_tecnico) & "' , cantidad_minima = '" & (cantidad_minima) & "' , proveedor = '" & (proveedor) & "' ,  factor = '" & (factor) & "' , codigo_barra = '" & (codigo_barra) & "' ,  familia = '" & (familia) & "', subfamilia = '" & (subfamilia) & "' , ultima_compra = '" & (mifecha2) & "', numero_proveedor = '" & (numero_proveedor) & "', cantidad_ultima_compra = '" & (cantidad_ultima_compra) & "' WHERE cod_producto = " & (cod_producto) & ""
    '            Else
    '                ' SC.CommandText = "insert into productos (cod_producto, nombre, marca, aplicacion, cantidad, precio, costo, factor, numero_tecnico, cantidad_minima, proveedor, margen, codigo_barra, familia, subfamilia, ULTIMA_COMPRA, NUMERO_PROVEEDOR, cantidad_ultima_compra) values ('" & (cod_producto) & "','" & (nombre) & "','" & (marca) & "','" & (aplicacion) & "','" & (cantidad) & "','" & (precio) & "','" & (costo) & "','" & (factor) & "','" & (numero_tecnico) & "','" & (cantidad_minima) & "','" & (proveedor) & "','" & (factor) & "','" & (codigo_barra) & "' ,'" & (familia) & "','" & (subfamilia) & "','" & (mifecha2) & "','" & (numero_proveedor) & "','" & (cantidad_ultima_compra) & "')"
    '                '  SC.CommandText = "INSERT INTO cliente (tipo_CLIENTE, Rut_cliente, nombre_cliente, direccion_cliente, telefono_cliente, EMAIL_CLIENTE, comuna_cliente, giro_cliente, DESCUENTO_1, CIUDAD_CLIENTE, DESCUENTO_2, FOLIO_CLIENTE, ESTADO_CUENTA, tipo_cuenta, cuenta_cliente) VALUES  ('" & (tipo_cliente) & "','" & (rut_cliente) & "','" & (nombre_cliente) & "','" & (direccion_cliente) & "','" & (telefono_cliente) & "','" & (email_cliente) & "','" & (comuna_cliente) & "','" & (giro_cliente) & "','" & (descuento_1) & "','" & (ciudad_cliente) & "','0','-','SIN CUENTA', '-', 'NO')"
    '                SC.CommandText = "INSERT INTO PROVEEDORES (RUT_PROVEEDOR, NOMBRE_PROVEEDOR, DIRECCION_PROVEEDOR, TELEFONO_PROVEEDOR, EMAIL_PROVEEDOR, CIUDAD_PROVEEDOR, COMUNA_PROVEEDOR, GIRO_PROVEEDOR, REPRESENTANTE_PROVEEDOR, CREDITO_PROVEEDOR, LLEGADA_PRODUCTOS) VALUES ('" & (rut_proveedor) & "','" & (nombre_proveedor) & "','" & (direccion_proveedor) & "','" & (telefono_proveedor) & "','-','" & (ciudad_proveedor) & "','" & (comuna_proveedor) & "','" & (giro_proveedor) & "','" & (representante_proveedor) & "','0','5')"

    '                DA.SelectCommand = SC
    '                DA.Fill(DT)
    '                conexion.Close()
    '            End If











    '        Next

    '    End If






    '    If txtSelect.Text = "MAEPROV" Then
    '        ''/para productos
    '        Dim rut_proveedor As String
    '        Dim nombre_proveedor As String
    '        Dim direccion_proveedor As String
    '        Dim ciudad_proveedor As String
    '        Dim comuna_proveedor As String
    '        Dim telefono_proveedor As String
    '        Dim giro_proveedor As String
    '        Dim representante_proveedor As String




    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            rut_proveedor = dgvDiarios.Rows(i).Cells(0).Value.ToString & "-" & dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            nombre_proveedor = dgvDiarios.Rows(i).Cells(2).Value.ToString
    '            direccion_proveedor = dgvDiarios.Rows(i).Cells(5).Value.ToString
    '            ciudad_proveedor = dgvDiarios.Rows(i).Cells(6).Value.ToString
    '            comuna_proveedor = "-"
    '            telefono_proveedor = dgvDiarios.Rows(i).Cells(7).Value.ToString
    '            giro_proveedor = dgvDiarios.Rows(i).Cells(4).Value.ToString
    '            representante_proveedor = "-"





    '            If rut_proveedor = "" Then
    '                rut_proveedor = "-"
    '            End If

    '            If nombre_proveedor = "" Then
    '                nombre_proveedor = "-"
    '            End If

    '            If direccion_proveedor = "" Then
    '                direccion_proveedor = "-"
    '            End If

    '            If ciudad_proveedor = "" Then
    '                ciudad_proveedor = "-"
    '            End If

    '            If comuna_proveedor = "" Then
    '                comuna_proveedor = "0"
    '            End If

    '            If telefono_proveedor = "" Then
    '                telefono_proveedor = "0"
    '            End If

    '            If giro_proveedor = "" Then
    '                giro_proveedor = "-"
    '            End If

    '            If representante_proveedor = "" Then
    '                representante_proveedor = "-"
    '            End If


    '            rut_proveedor = Replace(rut_proveedor, "'", "´")
    '            rut_proveedor = Replace(rut_proveedor, Chr(34), "´´")
    '            rut_proveedor = Replace(rut_proveedor, "&", " ")
    '            rut_proveedor = Replace(rut_proveedor, "\", " ")

    '            nombre_proveedor = Replace(nombre_proveedor, "'", "´")
    '            nombre_proveedor = Replace(nombre_proveedor, Chr(34), "´´")
    '            nombre_proveedor = Replace(nombre_proveedor, "&", " ")
    '            nombre_proveedor = Replace(nombre_proveedor, "\", " ")

    '            direccion_proveedor = Replace(direccion_proveedor, "'", "´")
    '            direccion_proveedor = Replace(direccion_proveedor, Chr(34), "´´")
    '            direccion_proveedor = Replace(direccion_proveedor, "&", " ")
    '            direccion_proveedor = Replace(direccion_proveedor, "\", " ")

    '            ciudad_proveedor = Replace(ciudad_proveedor, "'", "´")
    '            ciudad_proveedor = Replace(ciudad_proveedor, Chr(34), "´´")
    '            ciudad_proveedor = Replace(ciudad_proveedor, "&", " ")
    '            ciudad_proveedor = Replace(ciudad_proveedor, "\", " ")

    '            comuna_proveedor = Replace(comuna_proveedor, "'", "´")
    '            comuna_proveedor = Replace(comuna_proveedor, Chr(34), "´´")
    '            comuna_proveedor = Replace(comuna_proveedor, "&", " ")
    '            comuna_proveedor = Replace(comuna_proveedor, "\", " ")

    '            telefono_proveedor = Replace(telefono_proveedor, "'", "´")
    '            telefono_proveedor = Replace(telefono_proveedor, Chr(34), "´´")
    '            telefono_proveedor = Replace(telefono_proveedor, "&", " ")
    '            telefono_proveedor = Replace(telefono_proveedor, "\", " ")

    '            giro_proveedor = Replace(giro_proveedor, "'", "´")
    '            giro_proveedor = Replace(giro_proveedor, Chr(34), "´´")
    '            giro_proveedor = Replace(giro_proveedor, "&", " ")
    '            giro_proveedor = Replace(giro_proveedor, "\", " ")

    '            representante_proveedor = Replace(representante_proveedor, "'", "´")
    '            representante_proveedor = Replace(representante_proveedor, Chr(34), "´´")
    '            representante_proveedor = Replace(representante_proveedor, "&", " ")
    '            representante_proveedor = Replace(representante_proveedor, "\", " ")


    '            rut_proveedor = LTrim(Replace(rut_proveedor, " ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "  ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "   ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "    ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "     ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "      ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "       ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "        ", " "))
    '            rut_proveedor = LTrim(Replace(rut_proveedor, "         ", " "))

    '            rut_proveedor = RTrim(Replace(rut_proveedor, " ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "  ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "   ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "    ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "     ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "      ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "       ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "        ", " "))
    '            rut_proveedor = RTrim(Replace(rut_proveedor, "         ", " "))


    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, " ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "  ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "   ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "    ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "     ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "      ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "       ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "        ", " "))
    '            direccion_proveedor = LTrim(Replace(direccion_proveedor, "         ", " "))

    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, " ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "  ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "   ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "    ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "     ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "      ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "       ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "        ", " "))
    '            direccion_proveedor = RTrim(Replace(direccion_proveedor, "         ", " "))


    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, " ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "  ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "   ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "    ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "     ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "      ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "       ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "        ", " "))
    '            nombre_proveedor = LTrim(Replace(nombre_proveedor, "         ", " "))

    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, " ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "  ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "   ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "    ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "     ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "      ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "       ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "        ", " "))
    '            nombre_proveedor = RTrim(Replace(nombre_proveedor, "         ", " "))

    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, " ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "  ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "   ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "    ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "     ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "      ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "       ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "        ", " "))
    '            ciudad_proveedor = LTrim(Replace(ciudad_proveedor, "         ", " "))

    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, " ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "  ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "   ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "    ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "     ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "      ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "       ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "        ", " "))
    '            ciudad_proveedor = RTrim(Replace(ciudad_proveedor, "         ", " "))

    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, " ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "  ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "   ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "    ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "     ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "      ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "       ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "        ", " "))
    '            comuna_proveedor = LTrim(Replace(comuna_proveedor, "         ", " "))

    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, " ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "  ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "   ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "    ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "     ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "      ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "       ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "        ", " "))
    '            comuna_proveedor = RTrim(Replace(comuna_proveedor, "         ", " "))


    '            giro_proveedor = LTrim(Replace(giro_proveedor, " ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "  ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "   ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "    ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "     ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "      ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "       ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "        ", " "))
    '            giro_proveedor = LTrim(Replace(giro_proveedor, "         ", " "))

    '            giro_proveedor = RTrim(Replace(giro_proveedor, " ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "  ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "   ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "    ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "     ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "      ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "       ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "        ", " "))
    '            giro_proveedor = RTrim(Replace(giro_proveedor, "         ", " "))

    '            representante_proveedor = LTrim(Replace(representante_proveedor, " ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "  ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "   ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "    ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "     ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "      ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "       ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "        ", " "))
    '            representante_proveedor = LTrim(Replace(representante_proveedor, "         ", " "))

    '            representante_proveedor = RTrim(Replace(representante_proveedor, " ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "  ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "   ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "    ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "     ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "      ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "       ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "        ", " "))
    '            representante_proveedor = RTrim(Replace(representante_proveedor, "         ", " "))

    '            'If rut_proveedor <> "-" Then
    '            '    Dim finCadena As String = rut_proveedor(rut_proveedor.Length - 1).ToString()
    '            '    rut_proveedor = Mid(rut_proveedor, 1, Len(rut_proveedor) - 1)
    '            '    rut_proveedor = rut_proveedor & "-" & finCadena
    '            'End If

    '            rut_proveedor = UCase(rut_proveedor)
    '            nombre_proveedor = UCase(nombre_proveedor)
    '            direccion_proveedor = UCase(direccion_proveedor)
    '            ciudad_proveedor = UCase(ciudad_proveedor)
    '            comuna_proveedor = UCase(comuna_proveedor)
    '            telefono_proveedor = UCase(telefono_proveedor)
    '            giro_proveedor = UCase(giro_proveedor)
    '            representante_proveedor = UCase(representante_proveedor)










    '            DS.Tables.Clear()
    '            DT.Rows.Clear()
    '            DT.Columns.Clear()
    '            DS.Clear()
    '            conexion.Open()

    '            SC.Connection = conexion
    '            Consultas_SQL("select * from proveedores where rut_proveedor = '" & (rut_proveedor) & "'")
    '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '                SC.CommandText = "UPDATE PROVEEDORES SET NOMBRE_PROVEEDOR='" & (nombre_proveedor) & "', DIRECCION_PROVEEDOR='" & (direccion_proveedor) & "', TELEFONO_PROVEEDOR = '" & (telefono_proveedor) & "', EMAIL_PROVEEDOR = '-', CIUDAD_PROVEEDOR = '" & (ciudad_proveedor) & "', COMUNA_PROVEEDOR = '" & (comuna_proveedor) & "', GIRO_PROVEEDOR = '" & (giro_proveedor) & "', REPRESENTANTE_PROVEEDOR = '" & (representante_proveedor) & "', CREDITO_PROVEEDOR = '0' WHERE RUT_PROVEEDOR = '" & (rut_proveedor) & "'"
    '                DA.SelectCommand = SC
    '                DA.Fill(DT)
    '                conexion.Close()

    '                '  SC.CommandText = "UPDATE productos SET  NOMBRE='" & (nombre) & "', marca='" & (marca) & "',aplicacion='" & (aplicacion) & "', cantidad = '" & (cantidad) & "',precio = '" & (precio) & "', costo = " & (costo) & ", factor = '" & (factor) & "', numero_tecnico = '" & (numero_tecnico) & "' , cantidad_minima = '" & (cantidad_minima) & "' , proveedor = '" & (proveedor) & "' ,  factor = '" & (factor) & "' , codigo_barra = '" & (codigo_barra) & "' ,  familia = '" & (familia) & "', subfamilia = '" & (subfamilia) & "' , ultima_compra = '" & (mifecha2) & "', numero_proveedor = '" & (numero_proveedor) & "', cantidad_ultima_compra = '" & (cantidad_ultima_compra) & "' WHERE cod_producto = " & (cod_producto) & ""
    '            Else
    '                ' SC.CommandText = "insert into productos (cod_producto, nombre, marca, aplicacion, cantidad, precio, costo, factor, numero_tecnico, cantidad_minima, proveedor, margen, codigo_barra, familia, subfamilia, ULTIMA_COMPRA, NUMERO_PROVEEDOR, cantidad_ultima_compra) values ('" & (cod_producto) & "','" & (nombre) & "','" & (marca) & "','" & (aplicacion) & "','" & (cantidad) & "','" & (precio) & "','" & (costo) & "','" & (factor) & "','" & (numero_tecnico) & "','" & (cantidad_minima) & "','" & (proveedor) & "','" & (factor) & "','" & (codigo_barra) & "' ,'" & (familia) & "','" & (subfamilia) & "','" & (mifecha2) & "','" & (numero_proveedor) & "','" & (cantidad_ultima_compra) & "')"
    '                '  SC.CommandText = "INSERT INTO cliente (tipo_CLIENTE, Rut_cliente, nombre_cliente, direccion_cliente, telefono_cliente, EMAIL_CLIENTE, comuna_cliente, giro_cliente, DESCUENTO_1, CIUDAD_CLIENTE, DESCUENTO_2, FOLIO_CLIENTE, ESTADO_CUENTA, tipo_cuenta, cuenta_cliente) VALUES  ('" & (tipo_cliente) & "','" & (rut_cliente) & "','" & (nombre_cliente) & "','" & (direccion_cliente) & "','" & (telefono_cliente) & "','" & (email_cliente) & "','" & (comuna_cliente) & "','" & (giro_cliente) & "','" & (descuento_1) & "','" & (ciudad_cliente) & "','0','-','SIN CUENTA', '-', 'NO')"
    '                SC.CommandText = "INSERT INTO PROVEEDORES (RUT_PROVEEDOR, NOMBRE_PROVEEDOR, DIRECCION_PROVEEDOR, TELEFONO_PROVEEDOR, EMAIL_PROVEEDOR, CIUDAD_PROVEEDOR, COMUNA_PROVEEDOR, GIRO_PROVEEDOR, REPRESENTANTE_PROVEEDOR, CREDITO_PROVEEDOR, LLEGADA_PRODUCTOS) VALUES ('" & (rut_proveedor) & "','" & (nombre_proveedor) & "','" & (direccion_proveedor) & "','" & (telefono_proveedor) & "','-','" & (ciudad_proveedor) & "','" & (comuna_proveedor) & "','" & (giro_proveedor) & "','" & (representante_proveedor) & "','0','5')"
    '                DA.SelectCommand = SC
    '                DA.Fill(DT)

    '                conexion.Close()

    '            End If

    '        Next

    '    End If
















    '    If txtSelect.Text = "ESTADO" Then
    '        ''/para productos
    '        Dim rut_cliente As String

    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            rut_cliente = dgvDiarios.Rows(i).Cells(0).Value.ToString & "-" & dgvDiarios.Rows(i).Cells(1).Value.ToString

    '            'conexion.Close()
    '            'Consultas_SQL("select * from CLIENTES where RUT_CLIENTE = '" & (rut_cliente) & "'")
    '            'If DS.Tables(DT.TableName).Rows.Count <> 0 Then

    '            SC.Connection = conexion
    '            SC.CommandText = "update CLIENTES set CUENTA_CLIENTE = 'SI', ESTADO_CUENTA='ABIERTA', tipo_CUENTA='BOLETA' where rut_cliente ='" & (rut_cliente) & "'"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)

    '            '  End If
    '        Next
    '    End If














    '    If txtSelect.Text = "DETGIAS1" Then
    '        ''/para productos
    '        Dim rut_cliente As String

    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            Dim VarCodProducto As String
    '            Dim varnombre As String
    '            Dim vartecnico As String
    '            Dim VarValorUnitario As Integer
    '            Dim VarCantidad As String
    '            Dim VarPorcentaje As Integer
    '            Dim VarDescuento As Integer
    '            Dim VarNeto As Integer
    '            Dim VarIva As Integer
    '            Dim VarSubtotal As Integer
    '            Dim VarTotal As Integer

    '            vartecnico = dgvDiarios.Rows(i).Cells(3).Value.ToString

    '            conexion.Close()
    '            DS.Tables.Clear()
    '            DT.Rows.Clear()
    '            DT.Columns.Clear()
    '            DS.Clear()
    '            conexion.Open()

    '            SC.Connection = conexion
    '            SC.CommandText = "select cod_producto, nombre from productos where numero_tecnico='" & (vartecnico) & "'"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '            DS.Tables.Add(DT)

    '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '                VarCodProducto = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
    '                varnombre = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    '            End If
    '            conexion.Close()

    '            VarValorUnitario = dgvDiarios.Rows(i).Cells(5).Value.ToString
    '            VarCantidad = dgvDiarios.Rows(i).Cells(4).Value.ToString
    '            VarNeto = 0
    '            VarIva = 0
    '            VarSubtotal = dgvDiarios.Rows(i).Cells(6).Value.ToString
    '            VarPorcentaje = 0
    '            VarDescuento = 0
    '            VarTotal = dgvDiarios.Rows(i).Cells(6).Value.ToString

    '            SC.Connection = conexion
    '            SC.CommandText = "insert into detalle_boleta (n_boleta, cod_producto, detalle_nombre,  numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (dgvDiarios.Rows(i).Cells(0).Value.ToString) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & ", " & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)

    '        Next
    '    End If




























    '    If txtSelect.Text = "nulas" Then

    '        Dim nro_doc As String
    '        Dim rut_cliente As String

    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            rut_cliente = dgvDiarios.Rows(i).Cells(0).Value.ToString & "-" & dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            nro_doc = dgvDiarios.Rows(i).Cells(2).Value.ToString

    '            SC.Connection = conexion
    '            SC.CommandText = "update creditos set saldo = '0', estado='ANULADA' where tipo_detalle LIKE '" & "%" & (nro_doc) & "%" & "' and rut_cliente ='" & (rut_cliente) & "'"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)

    '        Next
    '    End If












    '    If txtSelect.Text = "CIUDAD" Then

    '        Dim ciudad As String
    '        Dim cod_ciudad As String

    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            cod_ciudad = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            ciudad = dgvDiarios.Rows(i).Cells(2).Value.ToString



    '            cod_ciudad = Replace(cod_ciudad, "'", "´")
    '            cod_ciudad = Replace(cod_ciudad, Chr(34), "´´")
    '            cod_ciudad = Replace(cod_ciudad, "&", " ")
    '            cod_ciudad = Replace(cod_ciudad, "\", " ")

    '            ciudad = Replace(ciudad, "'", "´")
    '            ciudad = Replace(ciudad, Chr(34), "´´")
    '            ciudad = Replace(ciudad, "&", " ")
    '            ciudad = Replace(ciudad, "\", " ")


    '            'cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, " ", " "))
    '            'cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "  ", " "))
    '            'cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "   ", " "))
    '            'cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "    ", " "))
    '            'cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "     ", " "))
    '            'cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "      ", " "))
    '            'cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "       ", " "))
    '            'cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "        ", " "))
    '            'cantidad_ultima_compra = LTrim(Replace(cantidad_ultima_compra, "         ", " "))

    '            'cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, " ", " "))
    '            'cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "  ", " "))
    '            'cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "   ", " "))
    '            'cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "    ", " "))
    '            'cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "     ", " "))
    '            'cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "      ", " "))
    '            'cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "       ", " "))
    '            'cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "        ", " "))
    '            'cantidad_ultima_compra = RTrim(Replace(cantidad_ultima_compra, "         ", " "))

    '            ciudad = UCase(ciudad)
    '            cod_ciudad = UCase(cod_ciudad)



    '            SC2.Connection = conexion
    '            SC2.CommandText = "UPDATE clientes SET  comuna_cliente='" & (ciudad) & "'  WHERE ciudad_cliente = '" & (cod_ciudad) & "' and cod_cliente <> '0'"
    '            DA2.SelectCommand = SC2
    '            DA2.Fill(DT2)

    '            SC2.Connection = conexion
    '            SC2.CommandText = "UPDATE proveedores SET  ciudad_proveedor='" & (ciudad) & "'  WHERE ciudad_proveedor = '" & (cod_ciudad) & "' and rut_proveedor <> '0'"
    '            DA2.SelectCommand = SC2
    '            DA2.Fill(DT2)

    '        Next
    '    End If









    '    If txtSelect.Text = "GIROCOM" Then

    '        Dim giro As String
    '        Dim cod_giro As String

    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            cod_giro = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            giro = dgvDiarios.Rows(i).Cells(1).Value.ToString

    '            cod_giro = Replace(cod_giro, "'", "´")
    '            cod_giro = Replace(cod_giro, Chr(34), "´´")
    '            cod_giro = Replace(cod_giro, "&", " ")
    '            cod_giro = Replace(cod_giro, "\", " ")

    '            giro = Replace(giro, "'", "´")
    '            giro = Replace(giro, Chr(34), "´´")
    '            giro = Replace(giro, "&", " ")
    '            giro = Replace(giro, "\", " ")

    '            giro = UCase(giro)
    '            cod_giro = UCase(cod_giro)

    '            SC2.Connection = conexion
    '            SC2.CommandText = "UPDATE clientes SET  giro_cliente='" & (giro) & "'  WHERE giro_cliente = '" & (cod_giro) & "' and cod_cliente <> '0'"
    '            DA2.SelectCommand = SC2
    '            DA2.Fill(DT2)


    '            SC2.Connection = conexion
    '            SC2.CommandText = "UPDATE proveedores SET  giro_proveedor='" & (giro) & "'  WHERE giro_proveedor = '" & (cod_giro) & "' and rut_proveedor <> '-'"
    '            DA2.SelectCommand = SC2
    '            DA2.Fill(DT2)

    '        Next
    '    End If


    '    If txtSelect.Text = "MARCAS" Then








    '        Dim marca As String
    '        Dim cod_marca As String

    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            cod_marca = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            marca = dgvDiarios.Rows(i).Cells(1).Value.ToString

    '            cod_marca = Replace(cod_marca, "'", "´")
    '            cod_marca = Replace(cod_marca, Chr(34), "´´")
    '            cod_marca = Replace(cod_marca, "&", " ")
    '            cod_marca = Replace(cod_marca, "\", " ")

    '            marca = Replace(marca, "'", "´")
    '            marca = Replace(marca, Chr(34), "´´")
    '            marca = Replace(marca, "&", " ")
    '            marca = Replace(marca, "\", " ")

    '            marca = UCase(marca)
    '            cod_marca = UCase(cod_marca)

    '            SC2.Connection = conexion
    '            SC2.CommandText = "UPDATE productos SET  marca='" & (marca) & "'  WHERE marca = '" & (cod_marca) & "'"
    '            DA2.SelectCommand = SC2
    '            DA2.Fill(DT2)

    '        Next


    '        SC.Connection = conexion
    '        SC.CommandText = "DELETE FROM marcas_productos WHERE cod_auto <> '1'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        SC.Connection = conexion
    '        SC.CommandText = "DELETE FROM marcas_productos WHERE cod_auto = '1'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)






    '        DS3.Tables.Clear()
    '        DT3.Rows.Clear()
    '        DT3.Columns.Clear()
    '        DS3.Clear()
    '        conexion.Open()
    '        SC3.Connection = conexion

    '        SC3.CommandText = "select marca from productos GROUP BY marca ORDER BY marca"

    '        DA3.SelectCommand = SC3
    '        DA3.Fill(DT3)
    '        DS3.Tables.Add(DT3)
    '        dgvDiarios.DataSource = DS3.Tables(DT3.TableName)
    '        conexion.Close()





    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            marca = dgvDiarios.Rows(i).Cells(0).Value.ToString


    '            marca = Replace(marca, "'", "´")
    '            marca = Replace(marca, Chr(34), "´´")
    '            marca = Replace(marca, "&", " ")
    '            marca = Replace(marca, "\", " ")

    '            marca = UCase(marca)
    '            ' cod_marca = UCase(cod_marca)

    '            SC.Connection = conexion
    '            SC.CommandText = "insert into marcas_productos (nombre_marca) values ('" & (marca) & "')"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '        Next



    '    End If















    '    'CON BOL GRABO BOLETAS CON DETBOL GRABO DETALLES BOLETAS

    '    If txtSelect.Text = "BOL" Then
    '        Dim tipo_impresion As String

    '        tipo_impresion = "MANUAL"

    '        Dim nro_boleta As String
    '        Dim fecha_boleta As String
    '        Dim fecha As Date
    '        Dim rut_boleta As String
    '        Dim total_boleta As Integer
    '        Dim neto_boleta As String
    '        Dim iva_boleta As String
    '        Dim codigo_boleta As String

    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            nro_boleta = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            fecha_boleta = dgvDiarios.Rows(i).Cells(1).Value.ToString
    '            rut_boleta = dgvDiarios.Rows(i).Cells(2).Value.ToString
    '            total_boleta = dgvDiarios.Rows(i).Cells(7).Value.ToString


    '            fecha = fecha_boleta
    '            fecha_boleta = fecha.ToString("yyy-MM-dd")

    '            Dim iva As Integer
    '            Dim neto As Integer
    '            Dim iva_valor As String

    '            iva_valor = valor_iva / 100 + 1
    '            neto = (total_boleta / iva_valor)
    '            Round(neto)
    '            neto_boleta = neto

    '            iva = ((neto_boleta) * valor_iva / 100)
    '            Round(iva)
    '            'iva_boleta = iva
    '            iva_boleta = total_boleta - neto_boleta

    '            If rut_boleta <> "1" Then
    '                conexion.Close()
    '                DS.Tables.Clear()
    '                DT.Rows.Clear()
    '                DT.Columns.Clear()
    '                DS.Clear()
    '                conexion.Open()

    '                SC.Connection = conexion
    '                SC.CommandText = "select rut_cliente, cod_cliente from clientes where rut_cliente  like '" & ("%" & rut_boleta & "%") & "'"
    '                DA.SelectCommand = SC
    '                DA.Fill(DT)
    '                DS.Tables.Add(DT)

    '                If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '                    rut_boleta = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
    '                    codigo_boleta = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
    '                End If
    '            Else
    '                rut_boleta = "11111111-1"
    '                codigo_boleta = "0"
    '            End If

    '            conexion.Close()

    '            SC.Connection = conexion
    '            SC.CommandText = "insert into BOLETA (n_boleta, TIPO,rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva,  subtotal, total, condiciones,estado, usuario_responsable, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie) values (" & (nro_boleta) & " , 'BOLETA', '" & (rut_boleta) & "', '0', '" & (fecha_boleta) & "'," & (0) & ", " & (neto_boleta) & ", " & (iva_boleta) & ", " & (total_boleta) & ", " & (total_boleta) & ", '-', '" & ("EMITIDA") & "', 'SISTEMA', '00:00:00', '0', '" & (tipo_impresion) & "', '0', '-')"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '        Next
    '    End If


    '    If txtSelect.Text = "DETBOL" Then

    '        Dim nro_boleta As String
    '        Dim cod_producto As String
    '        Dim cantidad_producto As Integer
    '        Dim precio_producto As String
    '        Dim total_producto As String
    '        Dim neto_producto As String
    '        Dim iva_producto As String
    '        Dim nombre_producto As String
    '        Dim numero_tecnico_producto As String

    '        For i = 0 To dgvDiarios.Rows.Count - 1

    '            nro_boleta = dgvDiarios.Rows(i).Cells(0).Value.ToString
    '            cod_producto = dgvDiarios.Rows(i).Cells(3).Value.ToString
    '            cantidad_producto = dgvDiarios.Rows(i).Cells(4).Value.ToString
    '            precio_producto = dgvDiarios.Rows(i).Cells(5).Value.ToString
    '            total_producto = dgvDiarios.Rows(i).Cells(6).Value.ToString

    '            Dim iva As Integer
    '            Dim neto As Integer
    '            Dim iva_valor As String

    '            iva_valor = valor_iva / 100 + 1
    '            neto = (total_producto / iva_valor)
    '            Round(neto)
    '            neto_producto = neto

    '            iva = ((neto_producto) * valor_iva / 100)
    '            Round(iva)


    '            iva_producto = total_producto - neto_producto


    '            conexion.Close()
    '            DS.Tables.Clear()
    '            DT.Rows.Clear()
    '            DT.Columns.Clear()
    '            DS.Clear()
    '            conexion.Open()

    '            SC.Connection = conexion
    '            SC.CommandText = "select cod_producto, nombre, numero_tecnico from productos where numero_tecnico  like '" & ("%" & cod_producto & "%") & "'"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '            DS.Tables.Add(DT)

    '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '                cod_producto = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
    '                nombre_producto = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    '                numero_tecnico_producto = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
    '            End If


    '            conexion.Close()

    '            SC.Connection = conexion
    '            SC.CommandText = "insert into detalle_boleta (n_boleta, cod_producto, detalle_nombre,  numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (nro_boleta) & ",'" & (cod_producto) & "','" & (nombre_producto) & "','" & (numero_tecnico_producto) & "'," & (precio_producto) & ",'" & (cantidad_producto) & "'," & ("0") & ", " & ("0") & "," & (neto_producto) & ", " & (iva_producto) & "," & (total_producto) & "," & (total_producto) & ")"
    '            DA.SelectCommand = SC
    '            DA.Fill(DT)
    '        Next
    '    End If















    '    lbl_mensaje.Visible = False
    '    Me.Enabled = True
    '    MsgBox("ARCHIVO ACTUALIZADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly)
    'End Sub

    'Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
    '    Me.Close()
    'End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

    End Sub

    Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click

    End Sub
End Class