Imports System.IO

Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_asignar_familias
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

    Private Sub Form_asignar_familias_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_asignar_familias_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    Private Sub Form_asignar_familias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_familia()
        txt_busqueda.Focus()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

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
        Combo_familia.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_familia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_familia"))
            Next

        End If


        Combo_familia.SelectedItem = "-"

        conexion.Close()
    End Sub

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
        Combo_subfamilia.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_subfamilia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
            Next
        End If


        Combo_subfamilia.SelectedItem = "-"

        conexion.Close()
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
        Combo_subfamilia_2.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_subfamilia_2.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
            Next
        End If


        Combo_subfamilia_2.SelectedItem = "-"

        conexion.Close()
    End Sub

    Sub mostrar_codigo_familia()
        If Combo_familia.Text <> "-" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from familia where nombre_familia ='" & (Combo_familia.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo")
            End If

            conexion.Close()
        End If
    End Sub

    Sub mostrar_codigo_subfamilia()
        If Combo_subfamilia.Text <> "-" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from subfamilia where nombre_subfamilia ='" & (Combo_subfamilia.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
            End If

            conexion.Close()
        End If
    End Sub

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

    Private Sub txt_busqueda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.LostFocus
        txt_busqueda.BackColor = Color.White
    End Sub

    Private Sub txt_busqueda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.GotFocus
        color_foco()
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

    Private Sub txt_modelo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub


    'Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
    '    btn_buscar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
    '    btn_buscar.BackColor = Color.Transparent
    'End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_codigo.BackColor = Color.White
    End Sub

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

    Sub separar_silaba()
        consulta_busqueda = "select PALABRA from diccionario_de_palabras where"
        Dim cadena As String
        Dim cantidad As Integer
        cadena = ""

        cantidad = (txt_busqueda.TextLength / 2) + 1
        Dim silaba As String

        For i = 0 To ((cantidad) - 1)
            silaba = Mid(txt_busqueda.Text, 1, 2)

            cadena = cadena & " " & silaba

            txt_busqueda.Text = Mid(txt_busqueda.Text, 3)
        Next

        cadena = LTrim(Replace(cadena, " ", " "))
        cadena = LTrim(Replace(cadena, "  ", " "))
        cadena = LTrim(Replace(cadena, "   ", " "))
        cadena = LTrim(Replace(cadena, "    ", " "))
        cadena = LTrim(Replace(cadena, "     ", " "))
        cadena = LTrim(Replace(cadena, "      ", " "))
        cadena = LTrim(Replace(cadena, "       ", " "))
        cadena = LTrim(Replace(cadena, "        ", " "))
        cadena = LTrim(Replace(cadena, "         ", " "))

        cadena = RTrim(Replace(cadena, " ", " "))
        cadena = RTrim(Replace(cadena, "  ", " "))
        cadena = RTrim(Replace(cadena, "   ", " "))
        cadena = RTrim(Replace(cadena, "    ", " "))
        cadena = RTrim(Replace(cadena, "     ", " "))
        cadena = RTrim(Replace(cadena, "      ", " "))
        cadena = RTrim(Replace(cadena, "       ", " "))
        cadena = RTrim(Replace(cadena, "        ", " "))
        cadena = RTrim(Replace(cadena, "         ", " "))

        Dim tabla() As String
        Dim n As Integer
        tabla = Split(cadena, " ")

        For n = 0 To UBound(tabla, 1)
            Dim fin_consulta As String
            fin_consulta = Strings.Right(consulta_busqueda, 5)

            fin_consulta = Strings.Right(consulta_busqueda, 5)
            If fin_consulta = "where" Then
                consulta_busqueda = consulta_busqueda & " PALABRA LIKE '" & ("%" & tabla(n) & "%") & "'"
            Else
                consulta_busqueda = consulta_busqueda & " AND PALABRA LIKE '" & ("%" & tabla(n) & "%") & "'"
            End If
        Next
    End Sub

    Sub buscar()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        If txt_busqueda.Text <> "" Then

            consulta_busqueda = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', productos.ULTIMA_COMPRA AS 'ULTIMA COMPRA', productos.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA' from productos, proveedores where proveedores.rut_proveedor=productos.proveedor "
            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_busqueda.Text
            '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")

            For n = 0 To UBound(tabla, 1)
                consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',COD_PRODUCTO, NOMBRE, APLICACION, NUMERO_TECNICO, nombre_proveedor) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next

            grilla_buscador_productos.DataSource = Nothing


            conexion.Close()
            Dim DT As New DataTable
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

            If grilla_buscador_productos.Rows.Count = 0 Then
                CORREGIR_busqueda()
            End If




            If grilla_buscador_productos.Rows.Count = 0 Then
                Combo_familia.Enabled = False
                Combo_subfamilia.Enabled = False
                Combo_subfamilia_2.Enabled = False
                btn_grabar.Enabled = False
            Else
                Combo_familia.Enabled = True
                Combo_subfamilia.Enabled = True
                Combo_subfamilia_2.Enabled = True
                btn_grabar.Enabled = True
            End If









            grilla_buscador_productos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_buscador_productos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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




    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            buscar_codigo()
        End If
    End Sub


    Sub buscar_codigo()

        lbl_resultado.Visible = True
        lbl_resultado.Text = "ESPERE POR FAVOR..."
        Me.Enabled = False

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion


        SC.CommandText = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', PRODUCTOS.ULTIMA_COMPRA AS 'ULTIMA COMPRA', PRODUCTOS.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA' from productos, proveedores where proveedores.rut_proveedor=productos.proveedor and cod_producto > '" & (txt_codigo.Text) & "'  Limit 1000"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_buscador_productos.DataSource = DS.Tables(DT.TableName)
        conexion.Close()

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

        grilla_buscador_productos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_buscador_productos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Me.Enabled = True
        grilla_buscador_productos.Focus()
        Exit Sub

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
        color_foco()
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub Combo_familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_familia.GotFocus
        color_foco()
        Combo_familia.DroppedDown = True
    End Sub

    Private Sub Combo_familia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_familia.SelectedIndexChanged
        mostrar_codigo_familia()
        llenar_combo_subfamilia()
    End Sub

    Private Sub Combo_subfamilia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.GotFocus
        color_foco()
        Combo_subfamilia.DroppedDown = True
    End Sub

    Private Sub Combo_subfamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.SelectedIndexChanged
        mostrar_codigo_subfamilia()
        llenar_combo_subfamilia2()
    End Sub

    Private Sub Combo_subfamilia_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_subfamilia_2.GotFocus
        color_foco()
        Combo_subfamilia_2.DroppedDown = True
    End Sub

    Private Sub Combo_subfamilia_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia_2.SelectedIndexChanged
        mostrar_codigo_subfamilia2()
    End Sub

    Sub mostrar_codigo_subfamilia2()
        If Combo_subfamilia_2.Text <> "-" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from subfamilia_dos where nombre_subfamilia ='" & (Combo_subfamilia_2.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
            End If

            conexion.Close()
        End If
    End Sub











    Sub color_foco()
        Dim controlcito As Control
        Dim controlChild As Control

        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).ReadOnly = False Then
                    CType(controlcito, TextBox).BackColor = Color.White
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                CType(controlcito, ComboBox).BackColor = Color.White
            End If

            If TypeOf controlcito Is Button Then
                CType(controlcito, Button).BackColor = Color.Transparent
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).ReadOnly = False Then
                            CType(controlChild, TextBox).BackColor = Color.White
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        CType(controlChild, ComboBox).BackColor = Color.White
                    End If

                    If TypeOf controlChild Is Button Then
                        CType(controlChild, Button).BackColor = Color.Transparent
                    End If
                Next
            End If
        Next

        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).Focused Then
                    If CType(controlcito, TextBox).ReadOnly = False Then
                        CType(controlcito, TextBox).BackColor = Color.LightSkyBlue
                        Exit Sub
                    End If
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                If CType(controlcito, ComboBox).Focused Then
                    CType(controlcito, ComboBox).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is Button Then
                If CType(controlcito, Button).Focused Then
                    CType(controlcito, Button).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).Focused Then
                            If CType(controlChild, TextBox).ReadOnly = False Then
                                CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
                                Exit Sub
                            End If
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        If CType(controlChild, ComboBox).Focused Then
                            CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If

                    If TypeOf controlChild Is Button Then
                        If CType(controlChild, Button).Focused Then
                            CType(controlChild, Button).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        grilla_buscador_productos.DataSource = Nothing

        Combo_familia.Enabled = False
        Combo_subfamilia.Enabled = False
        Combo_subfamilia_2.Enabled = False
        btn_grabar.Enabled = False

    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click

        If grilla_buscador_productos.Rows.Count = 0 Then
            MsgBox("MALLA PRODUCTOS VACIA, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_familia.Focus()
            Exit Sub
        End If

        Dim VarCodProducto As String

        For i = 0 To grilla_buscador_productos.Rows.Count - 1
            VarCodProducto = grilla_buscador_productos.Rows(i).Cells(0).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "UPDATE  productos SET familia = '" & (txt_codigo_familia.Text) & "', subfamilia = '" & (txt_codigo_subfamilia.Text) & "',  subfamilia_dos = '" & (txt_codigo_subfamilia_2.Text) & "' WHERE cod_producto = " & (VarCodProducto) & ""
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

        MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

        Combo_familia.SelectedItem = "-"
        Combo_subfamilia.SelectedItem = "-"
        Combo_subfamilia_2.SelectedItem = "-"

        grilla_buscador_productos.DataSource = Nothing

    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        color_foco()
    End Sub
End Class