Imports System.IO

Public Class Form_exportar_productos_pagina
    Dim consulta_busqueda As String

    Private Sub Form_exportar_productos_pagina_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_exportar_productos_pagina_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
            form_Ingreso.Show()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_exportar_productos_pagina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        txt_busqueda.Focus()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    'Sub llenar_combo_familia()
    '    conexion.Close()
    '    Combo_familia.Items.Clear()
    '    DS3.Tables.Clear()
    '    DT3.Rows.Clear()
    '    DT3.Columns.Clear()
    '    DS3.Clear()
    '    conexion.Open()

    '    SC3.Connection = conexion
    '    SC3.CommandText = "select * from familia order by nombre_familia"
    '    DA3.SelectCommand = SC3
    '    DA3.Fill(DT3)
    '    DS3.Tables.Add(DT3)

    '    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
    '            Combo_familia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_familia"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    Sub CORREGIR_busqueda()
        If txt_busqueda.Text <> "" Then
            Dim cadena_correccion As String
            Dim tabla_correccion() As String
            Dim n_correccion As Integer
            Dim cadena_buscada As String
            cadena_buscada = ""
            cadena_correccion = txt_busqueda.Text
            tabla_correccion = Split(cadena_correccion, " ")

            For n_correccion = 0 To UBound(tabla_correccion, 1)
                conexion.Close()
                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()

                SC3.Connection = conexion
                SC3.CommandText = " select * from diccionario_de_palabras WHERE PALABRA SOUNDS LIKE '" & ("%" & tabla_correccion(n_correccion)) & "%""'"
                DA3.SelectCommand = SC3
                DA3.Fill(DT3)
                DS3.Tables.Add(DT3)

                If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                    'For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                    cadena_buscada = cadena_buscada & " " & DS3.Tables(DT3.TableName).Rows(0).Item("palabra")
                Else
                    cadena_buscada = cadena_buscada & " " & (tabla_correccion(n_correccion))
                    ' Next
                End If
                conexion.Close()
            Next
            If cadena_buscada <> "" Then
                Dim valormensaje As Integer

                cadena_buscada = LTrim(Replace(cadena_buscada, " ", " "))
                cadena_buscada = LTrim(Replace(cadena_buscada, "  ", " "))
                cadena_buscada = LTrim(Replace(cadena_buscada, "   ", " "))
                cadena_buscada = LTrim(Replace(cadena_buscada, "    ", " "))
                cadena_buscada = LTrim(Replace(cadena_buscada, "     ", " "))
                cadena_buscada = LTrim(Replace(cadena_buscada, "      ", " "))
                cadena_buscada = LTrim(Replace(cadena_buscada, "       ", " "))
                cadena_buscada = LTrim(Replace(cadena_buscada, "        ", " "))
                cadena_buscada = LTrim(Replace(cadena_buscada, "         ", " "))

                cadena_buscada = RTrim(Replace(cadena_buscada, " ", " "))
                cadena_buscada = RTrim(Replace(cadena_buscada, "  ", " "))
                cadena_buscada = RTrim(Replace(cadena_buscada, "   ", " "))
                cadena_buscada = RTrim(Replace(cadena_buscada, "    ", " "))
                cadena_buscada = RTrim(Replace(cadena_buscada, "     ", " "))
                cadena_buscada = RTrim(Replace(cadena_buscada, "      ", " "))
                cadena_buscada = RTrim(Replace(cadena_buscada, "       ", " "))
                cadena_buscada = RTrim(Replace(cadena_buscada, "        ", " "))
                cadena_buscada = RTrim(Replace(cadena_buscada, "         ", " "))

                txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, " ", " "))
                txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "  ", " "))
                txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "   ", " "))
                txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "    ", " "))
                txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "     ", " "))
                txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "      ", " "))
                txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "       ", " "))
                txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "        ", " "))
                txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "         ", " "))

                txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, " ", " "))
                txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "  ", " "))
                txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "   ", " "))
                txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "    ", " "))
                txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "     ", " "))
                txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "      ", " "))
                txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "       ", " "))
                txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "        ", " "))
                txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "         ", " "))


                If txt_busqueda.Text <> cadena_buscada Then

                    valormensaje = MsgBox("QUIZAS QUISISTE DECIR: " & cadena_buscada, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "BUSCADOR")

                    If valormensaje = vbYes Then
                        txt_busqueda.Text = cadena_buscada
                        buscar()
                    Else
                        txt_busqueda.Text = txt_busqueda.Text
                        txt_busqueda.Focus()
                    End If
                End If

            End If
        End If
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

    'Sub llenar_combo_subfamilia()
    '    conexion.Close()
    '    Combo_subfamilia.Items.Clear()
    '    DS3.Tables.Clear()
    '    DT3.Rows.Clear()
    '    DT3.Columns.Clear()
    '    DS3.Clear()
    '    conexion.Open()

    '    SC3.Connection = conexion
    '    SC3.CommandText = "select * from subfamilia where nombre_familia='" & (Combo_familia.Text) & "' order by nombre_subfamilia"
    '    DA3.SelectCommand = SC3
    '    DA3.Fill(DT3)
    '    DS3.Tables.Add(DT3)

    '    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
    '            Combo_subfamilia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        buscar()
        'lbl_resultado.Location = New Point(1024 - lbl_resultado.Width - 7, 30)
    End Sub

    'Private Sub Combo_familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_familia.BackColor = Color.LightSkyBlue
    'End Sub

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

    'Private Sub Combo_familia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_familia.BackColor = Color.White
    'End Sub

    'Private Sub Combo_familia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    llenar_combo_subfamilia()
    'End Sub

    'Private Sub Combo_marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_marca.BackColor = Color.LightSkyBlue
    'End Sub

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

    'Private Sub Combo_marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_marca.BackColor = Color.White
    'End Sub



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



    'Private Sub txt_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_numero_proveedor.BackColor = Color.LightSkyBlue
    'End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_numero_proveedor.BackColor = Color.White
    'End Sub

    'Private Sub txt_numero_tecnico_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_numero_tecnico.BackColor = Color.LightSkyBlue
    'End Sub

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

    Private Sub txt_busqueda_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.Leave

    End Sub

    'Private Sub txt_aplicacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_aplicacion.BackColor = Color.White
    'End Sub

    'Private Sub txt_modelo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_modelo.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_numero_tecnico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_numero_tecnico.BackColor = Color.White
    'End Sub

    'Private Sub txt_aplicacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_aplicacion.BackColor = Color.LightSkyBlue
    'End Sub

    Private Sub txt_busqueda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.LostFocus
        txt_busqueda.BackColor = Color.White
    End Sub

    Private Sub txt_busqueda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.GotFocus
        txt_busqueda.BackColor = Color.LightSkyBlue
    End Sub

    'Private Sub txt_modelo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_modelo.BackColor = Color.White
    'End Sub

    'Private Sub txt_descripcion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_descripcion.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_descripcion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_descripcion.BackColor = Color.White
    'End Sub

    'Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
    '    btn_buscar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
    '    btn_buscar.BackColor = Color.Transparent
    'End Sub

    'Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_codigo.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_codigo.BackColor = Color.White
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



    Sub buscar()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim precio As String
        Dim descuento As String
        Dim medida_1 As String
        Dim medida_2 As String
        Dim medida_3 As String
        'Dim volumen As String
        If txt_busqueda.Text <> "" Then




            consulta_busqueda = "select cod_producto as SKU, nombre as NOMBRE, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION', cantidad as CANTIDAD, precio as PRECIO, familia.nombre_familia as 'FAMILIA', subfamilia.nombre_subfamilia as 'SUBFAMILIA', subfamilia_dos.nombre_subfamilia as 'SUBFAMILIA DOS' , subfamilia_dos.medida_1 as 'MEDIDA UNO' , subfamilia_dos.medida_2 as 'MEDIDA DOS' , subfamilia_dos.medida_1 as 'MEDIDA TRES'  , subfamilia_dos.m as 'M'  , subfamilia_dos.o as 'O' ,  subfamilia_dos.volumen as 'VOLUMEN' , subfamilia_dos.cod_auto as 'COD. SF2' from productos, proveedores, familia, subfamilia, subfamilia_dos where productos.familia=familia.codigo and productos.subfamilia=subfamilia.cod_auto and productos.subfamilia_dos=subfamilia_dos.cod_auto and proveedores.rut_proveedor=productos.proveedor and subfamilia_dos.o > '0' and  familia.nombre_familia = 'SKF' "
            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_busqueda.Text
            '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")

            For n = 0 To UBound(tabla, 1)
                'consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',COD_PRODUCTO, NOMBRE, APLICACION, NUMERO_TECNICO, nombre_proveedor) LIKE '" & ("%" & tabla(n) & "%") & "'"
                consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',cod_producto, nombre, numero_tecnico, aplicacion, cantidad, precio, proveedores.nombre_proveedor, productos.ultima_compra, productos.cantidad_ULTIMA_COMPRA, costo, cantidad_minima, familia.nombre_familia, subfamilia.nombre_subfamilia, subfamilia_dos.nombre_subfamilia) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next

            grilla_estado_de_cuenta.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = consulta_busqueda
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    precio = Val(DS.Tables(DT.TableName).Rows(i).Item("precio"))
                    medida_1 = Val(DS.Tables(DT.TableName).Rows(i).Item("MEDIDA UNO"))
                    medida_2 = Val(DS.Tables(DT.TableName).Rows(i).Item("MEDIDA DOS"))
                    medida_3 = Val(DS.Tables(DT.TableName).Rows(i).Item("MEDIDA TRES"))

                    If medida_1 = "" Then
                        medida_1 = "0"
                    End If

                    If medida_2 = "" Then
                        medida_2 = "0"
                    End If

                    If medida_3 = "" Then
                        medida_3 = "0"
                    End If

                    'descuento = Int(((precio) * valor_descuento_maximo) / 100)
                    descuento = Int(((precio) * "10") / 100)
                    precio = Int(precio) - Int(descuento)

                    grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("SKU"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("NOMBRE") & " " & DS.Tables(DT.TableName).Rows(i).Item("SUBFAMILIA DOS"), _
                                                       "<table><tbody><tr><td width='25%'><strong>Aplicación</strong></td><td width='75%'>" & DS.Tables(DT.TableName).Rows(i).Item("APLICACION") & "</td></tr><tr><td><strong>Numero técnico</strong></td><td>" & DS.Tables(DT.TableName).Rows(i).Item("NUMERO TECNICO") & "</td></tr></tbody></table>", _
                                                         DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                          precio, _
                                                           DS.Tables(DT.TableName).Rows(i).Item("FAMILIA") & " > " & DS.Tables(DT.TableName).Rows(i).Item("SUBFAMILIA DOS"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("SUBFAMILIA DOS"), _
                                                             medida_1, _
                                                               medida_2, _
                                                                medida_3, _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("VOLUMEN"), _
                                                                  "https://www.arana.cl/imagenes%20de%20productos/" & DS.Tables(DT.TableName).Rows(i).Item("COD. SF2") & ".jpg")
                Next
                grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grilla_estado_de_cuenta.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_estado_de_cuenta.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_estado_de_cuenta.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_estado_de_cuenta.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_estado_de_cuenta.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                'grilla_estado_de_cuenta.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                'grilla_estado_de_cuenta.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If

            If grilla_estado_de_cuenta.Rows.Count <> 0 Then
                If grilla_estado_de_cuenta.Columns(0).Width = 100 Then
                    grilla_estado_de_cuenta.Columns(0).Width = 99
                Else
                    grilla_estado_de_cuenta.Columns(0).Width = 100
                End If
                grilla_estado_de_cuenta.Columns(1).Width = 380
                grilla_estado_de_cuenta.Columns(2).Width = 500
                grilla_estado_de_cuenta.Columns(3).Width = 100
                grilla_estado_de_cuenta.Columns(4).Width = 100
                grilla_estado_de_cuenta.Columns(5).Width = 250
                grilla_estado_de_cuenta.Columns(6).Width = 250
                grilla_estado_de_cuenta.Columns(7).Width = 100
                grilla_estado_de_cuenta.Columns(8).Width = 100
                grilla_estado_de_cuenta.Columns(9).Width = 100
                grilla_estado_de_cuenta.Columns(10).Width = 100
                grilla_estado_de_cuenta.Columns(11).Width = 380
                'grilla_estado_de_cuenta.Columns(11).Width = 380
            End If


            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If

    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    'Sub ajustar()
    '    Dim margen_lateral_contenedor As String
    '    Dim margen_superior_contenedor As String
    '    Dim margen_lateral_detalle As String
    '    Dim tamaño_lateral_detalle As String

    '    ' margen_lateral_contenedor = (Me.Width - Panel_contenedor.Width) / 2
    '    ' margen_superior_contenedor = (Me.Height - Panel_contenedor.Height) / 2
    '    margen_lateral_detalle = (Me.Width - Panel_detalle.Width) / 2
    '    tamaño_lateral_detalle = (Me.Width - 20)

    '    'Panel_contenedor.Location = New Point(margen_lateral_contenedor - 3, margen_superior_contenedor + 11)
    '    Panel_detalle.Size = New Point(tamaño_lateral_detalle, 32)
    '    Panel_detalle.Location = New Point(11, 22)

    '    'panel_esc.Size = New Point(tamaño_lateral_detalle, 32)
    '    'panel_esc.Location = New Point(14, 0)
    'End Sub

    'Private Sub Form_buscar_productos2_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
    '    ajustar()
    'End Sub

    Private Sub migrilla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        'txt_aplicacion.Text = ""
        'txt_codigo.Text = ""
        'txt_descripcion.Text = ""
        'txt_modelo.Text = ""
        'txt_numero_tecnico.Text = ""
        'Combo_familia.Text = ""
        'Combo_marca.Text = ""
        'Combo_subfamilia.Text = ""
    End Sub




    Private Sub grilla_buscador_productos_ventas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub


    Private Sub grilla_buscador_productos_ventas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub



    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub
    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""

        Dim ruta_archivo As String
        Dim hora_sistema As String
        Dim fecha_sistema As String

        hora_sistema = Form_menu_principal.lbl_hora.Text
        hora_sistema = hora_sistema.Replace(":", " ")



        fecha_sistema = Format(Today.Date, "Long Date")

        fecha_sistema = fecha_sistema.Replace(",", " ")

        ruta_archivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & txt_busqueda.Text & " " & fecha_sistema & " " & hora_sistema & ".csv"



        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            txt_busqueda.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False

        'Dim save As New SaveFileDialog
        'save.Filter = "Archivo Excel | *.xlsx"
        ''save.FileName = ""
        '' If save.ShowDialog = Windows.Forms.DialogResult.OK Then
        'Exportar_Excel(Me.grilla_estado_de_cuenta, ruta_archivo)
        ''End If






        ' archivoguardar = InputBox("Ingrese el Nombre del archivo", "Nombre", "Cursos")
        'If Not archivoguardar = "" Then
        'If Not Exportar_Excel() Then
        'MsgBox("No se pudo ejecutar el archivo")
        ' End If
        Exportar_Excel()
        ' End If








        lbl_mensaje.Visible = False
        Me.Enabled = True


    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_estado_de_cuenta.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_estado_de_cuenta.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_estado_de_cuenta.RowCount - 1
            For c As Integer = 0 To grilla_estado_de_cuenta.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_estado_de_cuenta.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub


    Private Function exportar_excel() As Boolean


        Dim ruta_archivo As String
        Dim hora_sistema As String
        Dim fecha_sistema As String

        hora_sistema = Form_menu_principal.lbl_hora.Text
        hora_sistema = hora_sistema.Replace(":", " ")



        fecha_sistema = Format(Today.Date, "Long Date")

        fecha_sistema = fecha_sistema.Replace(",", " ")

        ruta_archivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & txt_busqueda.Text & " " & fecha_sistema & " " & hora_sistema & ".csv"





        'Dim cadenaubicacion As String
        'Dim directorio As New FolderBrowserDialog
        'If directorio.ShowDialog = DialogResult.OK Then
        '    cadenaubicacion = directorio.SelectedPath
        Try
            Dim stream As Stream
            Dim escritor As StreamWriter
            Dim fila = grilla_estado_de_cuenta.Rows.Count
            Dim columnas = grilla_estado_de_cuenta.Columns.Count
            Dim archivo As String = ruta_archivo
            Dim linea As String = ""
            Dim filadata, column As Int32

            File.Delete(archivo)
            stream = File.OpenWrite(archivo)
            escritor = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To columnas - 1
                linea = linea & grilla_estado_de_cuenta.Columns(column).HeaderText & ";"
            Next
            linea = Mid(CStr(linea), 1, linea.ToString.Length - 1)
            escritor.WriteLine(linea)
            linea = Nothing
            For filadata = 0 To fila - 1
                For column = 0 To columnas - 1
                    linea = linea & CStr(grilla_estado_de_cuenta.Item(column, filadata).Value) & ";"
                Next
                linea = Mid(CStr(linea), 1, linea.ToString.Length - 1)
                escritor.WriteLine(linea)
                linea = Nothing
            Next
            escritor.Close()
            Try
                ''Process.Start(archivo)
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        'End If
        'Return False
    End Function
End Class