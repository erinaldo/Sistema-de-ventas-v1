Imports System.IO

Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_buscador_subfamilia_dos
    Dim mitexto As String
    Dim micampo As String
    Dim mitexto_2 As String
    Dim micampo_2 As String
    Dim campo_marca As String
    Dim campo_aplicacion As String
    Dim campo_numero_tecnico As String
    Dim campo_descripcion As String
    Dim campo_modelo As String
    Dim campo_codigo As String
    Dim campo_numero_proveedor As String
    Dim consulta_busqueda As String
    Private Sub Form_buscador_subfamilia_dos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_registro_subfamilia_2_arana.Enabled = True
        Form_registro_subfamilia_2_arana.WindowState = FormWindowState.Normal
        Form_registro_subfamilia_2_arana.btn_buscar.Focus()
    End Sub

    Private Sub Form_buscador_subfamilia_dos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F1 Then
            txt_busqueda.Focus()
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

    Private Sub Form_buscador_subfamilia_dos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        txt_busqueda.Focus()
    End Sub

    Private Sub migrilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla_buscador_productos.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Dim codigo As String
            'Dim valor As Integer
            If grilla_buscador_productos.Rows.Count <= 0 Then
                Form_registro_subfamilia_2_arana.combo_familia.Focus()
                Me.Close()
                Exit Sub
            End If

            'Form_registro_subfamilia_2_arana.txt_m.Text = grilla_buscador_productos.CurrentRow.Cells(6).Value.ToString
            'Form_registro_subfamilia_2_arana.txt_o.Text = grilla_buscador_productos.CurrentRow.Cells(7).Value.ToString
            'Form_registro_subfamilia_2_arana.txt_volumen.Text = grilla_buscador_productos.CurrentRow.Cells(8).Value.ToString

            'Form_registro_subfamilia_2_arana.combo_familia.Text = grilla_buscador_productos.CurrentRow.Cells(1).Value.ToString
            'Form_registro_subfamilia_2_arana.txt_codigo_familia.Text = grilla_buscador_productos.CurrentRow.Cells(0).Value.ToString

            'Form_registro_subfamilia_2_arana.Combo_subfamilia.Text = grilla_buscador_productos.CurrentRow.Cells(3).Value.ToString
            'Form_registro_subfamilia_2_arana.txt_codigo_subfamilia.Text = grilla_buscador_productos.CurrentRow.Cells(2).Value.ToString

            'Form_registro_subfamilia_2_arana.txt_nombre_subfamilia_dos.Text = grilla_buscador_productos.CurrentRow.Cells(5).Value.ToString
            'Form_registro_subfamilia_2_arana.txt_codigo_subfamilia_2.Text = grilla_buscador_productos.CurrentRow.Cells(4).Value.ToString

            Dim combo_familia As String
            Dim codigo_familia As String
            Dim Combo_subfamilia As String
            Dim codigo_subfamilia As String
            Dim nombre_subfamilia_dos As String
            Dim codigo_subfamilia_2 As String
            Dim o As String
            Dim m As String
            Dim medida_1 As String
            Dim medida_2 As String
            Dim medida_3 As String
            Dim volumen As String


            combo_familia = grilla_buscador_productos.CurrentRow.Cells(1).Value.ToString
            codigo_familia = grilla_buscador_productos.CurrentRow.Cells(0).Value.ToString
            Combo_subfamilia = grilla_buscador_productos.CurrentRow.Cells(3).Value.ToString
            codigo_subfamilia = grilla_buscador_productos.CurrentRow.Cells(2).Value.ToString
            nombre_subfamilia_dos = grilla_buscador_productos.CurrentRow.Cells(5).Value.ToString
            codigo_subfamilia_2 = grilla_buscador_productos.CurrentRow.Cells(4).Value.ToString
            o = grilla_buscador_productos.CurrentRow.Cells(7).Value.ToString
            m = grilla_buscador_productos.CurrentRow.Cells(6).Value.ToString
            medida_1 = grilla_buscador_productos.CurrentRow.Cells(8).Value.ToString
            medida_2 = grilla_buscador_productos.CurrentRow.Cells(9).Value.ToString
            medida_3 = grilla_buscador_productos.CurrentRow.Cells(10).Value.ToString
            volumen = grilla_buscador_productos.CurrentRow.Cells(11).Value.ToString

            Form_registro_subfamilia_2_arana.combo_familia.Text = combo_familia
            Form_registro_subfamilia_2_arana.txt_codigo_familia.Text = codigo_familia

            Form_registro_subfamilia_2_arana.Combo_subfamilia.Text = Combo_subfamilia
            Form_registro_subfamilia_2_arana.txt_codigo_subfamilia.Text = codigo_subfamilia

            Form_registro_subfamilia_2_arana.txt_nombre_subfamilia_dos.Text = nombre_subfamilia_dos
            Form_registro_subfamilia_2_arana.txt_codigo_subfamilia_2.Text = codigo_subfamilia_2

            Form_registro_subfamilia_2_arana.txt_m.Text = m
            Form_registro_subfamilia_2_arana.txt_o.Text = o

            Form_registro_subfamilia_2_arana.txt_medida_1.Text = medida_1
            Form_registro_subfamilia_2_arana.txt_medida_2.Text = medida_2
            Form_registro_subfamilia_2_arana.txt_medida_3.Text = medida_3

            Form_registro_subfamilia_2_arana.txt_volumen.Text = volumen
            Me.Close()
        End If
    End Sub

    Private Sub migrilla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_buscador_productos.DoubleClick

        'Dim codigo As String
        'Dim valor As Integer
        If grilla_buscador_productos.Rows.Count <= 0 Then
            Form_registro_subfamilia_2_arana.combo_familia.Focus()
            Me.Close()
            Exit Sub
        End If

        'codigo = grilla_buscador_productos.CurrentRow.Cells(0).Value
        'valor = codigo

        Dim combo_familia As String
        Dim codigo_familia As String
        Dim Combo_subfamilia As String
        Dim codigo_subfamilia As String
        Dim nombre_subfamilia_dos As String
        Dim codigo_subfamilia_2 As String
        Dim o As String
        Dim m As String
        Dim medida_1 As String
        Dim medida_2 As String
        Dim medida_3 As String
        Dim volumen As String


        combo_familia = grilla_buscador_productos.CurrentRow.Cells(1).Value.ToString
        codigo_familia = grilla_buscador_productos.CurrentRow.Cells(0).Value.ToString
        Combo_subfamilia = grilla_buscador_productos.CurrentRow.Cells(3).Value.ToString
        codigo_subfamilia = grilla_buscador_productos.CurrentRow.Cells(2).Value.ToString
        nombre_subfamilia_dos = grilla_buscador_productos.CurrentRow.Cells(5).Value.ToString
        codigo_subfamilia_2 = grilla_buscador_productos.CurrentRow.Cells(4).Value.ToString
        o = grilla_buscador_productos.CurrentRow.Cells(7).Value.ToString
        m = grilla_buscador_productos.CurrentRow.Cells(6).Value.ToString
        medida_1 = grilla_buscador_productos.CurrentRow.Cells(8).Value.ToString
        medida_2 = grilla_buscador_productos.CurrentRow.Cells(9).Value.ToString
        medida_3 = grilla_buscador_productos.CurrentRow.Cells(10).Value.ToString
        volumen = grilla_buscador_productos.CurrentRow.Cells(11).Value.ToString

        Form_registro_subfamilia_2_arana.combo_familia.Text = combo_familia
        Form_registro_subfamilia_2_arana.txt_codigo_familia.Text = codigo_familia

        Form_registro_subfamilia_2_arana.Combo_subfamilia.Text = Combo_subfamilia
        Form_registro_subfamilia_2_arana.txt_codigo_subfamilia.Text = codigo_subfamilia

        Form_registro_subfamilia_2_arana.txt_nombre_subfamilia_dos.Text = nombre_subfamilia_dos
        Form_registro_subfamilia_2_arana.txt_codigo_subfamilia_2.Text = codigo_subfamilia_2

        Form_registro_subfamilia_2_arana.txt_m.Text = m
        Form_registro_subfamilia_2_arana.txt_o.Text = o

        Form_registro_subfamilia_2_arana.txt_medida_1.Text = medida_1
        Form_registro_subfamilia_2_arana.txt_medida_2.Text = medida_2
        Form_registro_subfamilia_2_arana.txt_medida_3.Text = medida_3

        Form_registro_subfamilia_2_arana.txt_volumen.Text = volumen

        'codigo = String.Format("{0:000000}", valor)
        'Form_Compra.limpiar_producto()
        'Form_Compra.txt_codigo_producto.Text = codigo
        'Form_Compra.mostrar_datos_productos()
        'Form_Compra.txt_cantidad_agregar.Focus()

        Me.Close()

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    'Sub llenar_combo_marca()
    '    conexion.Close()
    '    Combo_marca.Items.Clear()
    '    DS3.Tables.Clear()
    '    DT3.Rows.Clear()
    '    DT3.Columns.Clear()
    '    DS3.Clear()
    '    conexion.Open()

    '    SC3.Connection = conexion
    '    SC3.CommandText = "select * from marcas_productos"
    '    DA3.SelectCommand = SC3
    '    DA3.Fill(DT3)
    '    DS3.Tables.Add(DT3)

    '    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
    '            Combo_marca.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_marca"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub



    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        buscar()
        'lbl_resultado.Location = New Point(1024 - lbl_resultado.Width - 7, 30)
    End Sub

    Private Sub Combo_familia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            buscar()
        End If
    End Sub

    Private Sub Combo_familia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub


    Private Sub Combo_marca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            buscar()
        End If
    End Sub

    Private Sub Combo_marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            buscar()
        End If
    End Sub

    Private Sub Combo_subfamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            buscar()
        End If
    End Sub

    Private Sub Combo_subfamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    Private Sub txt_numero_tecnico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            buscar()
        End If
    End Sub

    Private Sub txt_aplicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            buscar()
        End If
    End Sub



    Private Sub txt_numero_tecnico_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub txt_busqueda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.LostFocus
        txt_busqueda.BackColor = Color.White
    End Sub

    Private Sub txt_busqueda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.GotFocus
        txt_busqueda.BackColor = Color.LightSkyBlue
    End Sub


    'Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
    '    btn_buscar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
    '    btn_buscar.BackColor = Color.Transparent
    'End Sub

    Private Sub txt_busqueda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_busqueda.KeyPress
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
            buscar()
        End If
    End Sub

    Private Sub txt_modelo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            buscar()
        End If
    End Sub

    Private Sub txt_descripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            buscar()
        End If
    End Sub

    'Sub separar_silaba()
    '    consulta_busqueda = "select PALABRA from diccionario_de_palabras where"
    '    Dim cadena As String
    '    Dim cantidad As Integer

    '    cantidad = (txt_busqueda.TextLength / 2) + 1
    '    Dim silaba As String

    '    For i = 0 To ((cantidad) - 1)
    '        silaba = Mid(txt_busqueda.Text, 1, 2)

    '        cadena = cadena & " " & silaba

    '        txt_busqueda.Text = Mid(txt_busqueda.Text, 3)
    '    Next

    '    cadena = LTrim(Replace(cadena, " ", " "))
    '    cadena = LTrim(Replace(cadena, "  ", " "))
    '    cadena = LTrim(Replace(cadena, "   ", " "))
    '    cadena = LTrim(Replace(cadena, "    ", " "))
    '    cadena = LTrim(Replace(cadena, "     ", " "))
    '    cadena = LTrim(Replace(cadena, "      ", " "))
    '    cadena = LTrim(Replace(cadena, "       ", " "))
    '    cadena = LTrim(Replace(cadena, "        ", " "))
    '    cadena = LTrim(Replace(cadena, "         ", " "))

    '    cadena = RTrim(Replace(cadena, " ", " "))
    '    cadena = RTrim(Replace(cadena, "  ", " "))
    '    cadena = RTrim(Replace(cadena, "   ", " "))
    '    cadena = RTrim(Replace(cadena, "    ", " "))
    '    cadena = RTrim(Replace(cadena, "     ", " "))
    '    cadena = RTrim(Replace(cadena, "      ", " "))
    '    cadena = RTrim(Replace(cadena, "       ", " "))
    '    cadena = RTrim(Replace(cadena, "        ", " "))
    '    cadena = RTrim(Replace(cadena, "         ", " "))

    '    Dim tabla() As String
    '    Dim n As Integer
    '    tabla = Split(cadena, " ")

    '    For n = 0 To UBound(tabla, 1)
    '        Dim fin_consulta As String
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)

    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "where" Then
    '            consulta_busqueda = consulta_busqueda & " PALABRA LIKE '" & ("%" & tabla(n) & "%") & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " AND PALABRA LIKE '" & ("%" & tabla(n) & "%") & "'"
    '        End If
    '    Next
    'End Sub

    Sub buscar()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        If txt_busqueda.Text <> "" Then

            'consulta_busqueda = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', productos.ULTIMA_COMPRA AS 'ULTIMA COMPRA', productos.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA' from productos, proveedores where proveedores.rut_proveedor=productos.proveedor and productos.activo='SI' "
            consulta_busqueda = "SELECT familia.codigo as 'CODIGO F', familia.nombre_familia as 'NOMBRE F', subfamilia.cod_auto as 'CODIGO SF', subfamilia.nombre_subfamilia as 'NOMBRE SF', subfamilia_dos.cod_auto as 'CODIGO SF2', subfamilia_dos.nombre_subfamilia as 'NOMBRE SF2', subfamilia_dos.m as 'M', subfamilia_dos.o as 'O', subfamilia_dos.medida_1 as 'MEDIDA 1', subfamilia_dos.medida_2 as 'MEDIDA 2' , subfamilia_dos.medida_3 as 'MEDIDA 3' , subfamilia_dos.volumen as 'VOLUMEN' FROM familia, subfamilia, subfamilia_dos where familia.codigo= subfamilia.codigo_familia and subfamilia.cod_auto= subfamilia_dos.codigo_subfamilia "

            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_busqueda.Text
            '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")

            For n = 0 To UBound(tabla, 1)
                consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ', familia.codigo , familia.nombre_familia, subfamilia.cod_auto, subfamilia.nombre_subfamilia, subfamilia_dos.cod_auto, subfamilia_dos.nombre_subfamilia, subfamilia_dos.m, subfamilia_dos.o) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next

            grilla_buscador_productos.DataSource = Nothing

            Dim DT As New DataTable

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = consulta_busqueda
            DA.SelectCommand = SC

            DA.Fill(DT)
            DS.Tables.Add(DT)

            grilla_buscador_productos.DataSource = DS.Tables(DT.TableName)
            conexion.Close()

            'grilla_buscador_productos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_buscador_productos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_buscador_productos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_buscador_productos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grilla_buscador_productos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_buscador_productos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            lbl_resultado.Visible = True

            lbl_resultado.Text = "SE ENCONTRARON " & grilla_buscador_productos.Rows.Count & " RESULTADOS"

            If grilla_buscador_productos.Rows.Count = 0 Then
                lbl_resultado.ForeColor = Color.Red
                lbl_resultado.Text = "NO SE ENCONTRARON RESULTADOS"
            ElseIf grilla_buscador_productos.Rows.Count = 1 Then
                lbl_resultado.Text = "SE ENCONTRO 1 RESULTADO"
                lbl_resultado.ForeColor = Color.Black
            Else
                lbl_resultado.ForeColor = Color.Black
            End If
            lbl_mensaje.Visible = False
            Me.Enabled = True

            If grilla_buscador_productos.Rows.Count > 0 Then
                grilla_buscador_productos.Focus()
            End If

            Exit Sub
        End If



        lbl_resultado.Visible = False
        lbl_mensaje.Visible = False
        Me.Enabled = True



        ' Me.Enabled = True
        grilla_buscador_productos.Focus()
        Exit Sub
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    Private Sub migrilla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grilla_buscador_productos.KeyPress
        'If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
        '    Dim codigo As String
        '    Dim valor As Integer
        '    If migrilla.Rows.Count <= 0 Then
        '        Me.Close()
        '        Form_venta.txt_codigo.Focus()
        '        Me.Close()
        '    End If

        '    If migrilla.CurrentRow.Index = migrilla.Rows.Count - 1 Then
        '        codigo = migrilla.CurrentRow.Cells(0).Value
        '        valor = codigo
        '        codigo = String.Format("{0:000000}", valor)
        '        Form_venta.txt_codigo.Text = codigo
        '        Form_venta.limpiar_datos_productos_enter()
        '        Form_venta.mostrar_cantidad_real()
        '        Form_venta.mostrar_nombre_proveedor()
        '        Form_venta.txt_cantidad_agregar.Text = ""
        '        Form_venta.Radio_codigo_interno.Checked = True
        '        Form_venta.txt_cantidad_agregar.Focus()
        '        Me.Close()
        '        Exit Sub
        '    End If

        '    If migrilla.Rows.Count = 1 Then
        '        codigo = migrilla.CurrentRow.Cells(0).Value
        '        valor = codigo
        '        codigo = String.Format("{0:000000}", valor)
        '        Form_venta.txt_codigo.Text = codigo
        '        Form_venta.limpiar_datos_productos_enter()
        '        Form_venta.mostrar_cantidad_real()
        '        Form_venta.mostrar_nombre_proveedor()
        '        Form_venta.txt_cantidad_agregar.Text = ""
        '        Form_venta.Radio_codigo_interno.Checked = True
        '        Form_venta.txt_cantidad_agregar.Focus()
        '        Me.Close()
        '    Else
        '        codigo = Convert.ToInt32(migrilla.Item(0, migrilla.CurrentRow.Index - 1).Value.ToString)
        '        valor = codigo
        '        codigo = String.Format("{0:000000}", valor)
        '        Form_venta.txt_codigo.Text = codigo
        '        Form_venta.limpiar_datos_productos_enter()
        '        Form_venta.mostrar_cantidad_real()
        '        Form_venta.mostrar_nombre_proveedor()
        '        Form_venta.txt_cantidad_agregar.Text = ""
        '        Form_venta.Radio_codigo_interno.Checked = True
        '        Form_venta.txt_cantidad_agregar.Focus()
        '        Me.Close()
        '    End If
        'End If
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
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



    Private Sub Combo_busqueda_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub txt_aplicacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_busqueda.Text = ""
    End Sub

    Private Sub txt_descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_busqueda.Text = ""
    End Sub

    Private Sub txt_modelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_busqueda.Text = ""
    End Sub

    Private Sub Combo_marca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_busqueda.Text = ""
    End Sub

    Private Sub Combo_marca_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_busqueda.Text = ""
    End Sub

    Private Sub txt_numero_tecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_busqueda.Text = ""
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_busqueda.Text = ""
    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub grilla_buscador_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_buscador_productos.CellContentClick

    End Sub
End Class