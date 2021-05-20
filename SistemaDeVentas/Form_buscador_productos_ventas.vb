Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_buscador_productos_ventas
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
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_buscar_productos2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_venta.Enabled = True
        Form_venta.WindowState = FormWindowState.Normal

        If Form_venta.txt_nombre_producto.Text = "" And Form_venta.txt_numero_tecnico.Text = "" And Form_venta.txt_precio_modificado.Text = "" Then
            Form_venta.txt_codigo.Focus()
        Else
            Form_venta.txt_cantidad_agregar.Text = "1"
            Form_venta.txt_precio_modificado.Focus()
        End If
    End Sub

    Private Sub Form_buscar_productos2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llenar_combo_familia()
        'llenar_combo_marca()

        cargar_logo()
        dtp_desde.Value = dtp_desde.Value.AddYears(Val(-1))

        grilla_buscador_productos_ventas.Width = "1006"
        Panel1.Location = New Point(5000, 5000)

        txt_busqueda.Focus()
        Timer_inactividad_buscar_productos_ventas.Start()
        'Combo_marca.Focus()
        'f1.PerformClick()
    End Sub

    Private Sub Form_buscar_productos2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub migrilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla_buscador_productos_ventas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim codigo As String
            Dim valor As Integer
            If grilla_buscador_productos_ventas.Rows.Count <= 0 Then
                Form_venta.txt_codigo.Focus()
                Me.Close()
                Exit Sub
            End If

            codigo = grilla_buscador_productos_ventas.CurrentRow.Cells(0).Value
            valor = codigo
            codigo = String.Format("{0:000000}", valor)
            Form_venta.txt_codigo.Text = codigo
            Form_venta.limpiar_datos_productos()
            Form_venta.mostrar_cantidad_real()
            Form_venta.mostrar_nombre_proveedor()
            Form_venta.txt_cantidad_agregar.Text = ""
            Form_venta.txt_cantidad_agregar.Focus()
            Me.Close()
        End If
    End Sub

    Private Sub migrilla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_buscador_productos_ventas.DoubleClick

        If grilla_buscador_productos_ventas.Rows.Count <> 0 Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            Form_stock_sucursales.Show()
        End If

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
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
        grilla_kardex.Columns.Clear()

        grilla_buscador_productos_ventas.Width = "1006"
        Panel1.Location = New Point(5000, 5000)

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

            grilla_buscador_productos_ventas.Width = "1006"
            Panel1.Location = New Point(5000, 5000)

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

            consulta_busqueda = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', productos.ULTIMA_COMPRA AS 'ULTIMA COMPRA', productos.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA' from productos, proveedores where proveedores.rut_proveedor=productos.proveedor and productos.activo='SI' "
            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_busqueda.Text
            '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")

            For n = 0 To UBound(tabla, 1)
                consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',COD_PRODUCTO, NOMBRE, APLICACION, NUMERO_TECNICO, marca, nombre_proveedor) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next

            consulta_busqueda = consulta_busqueda & " order by productos.ultima_compra desc"

            grilla_buscador_productos_ventas.DataSource = Nothing

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

            grilla_buscador_productos_ventas.DataSource = DS.Tables(DT.TableName)
            conexion.Close()

            If grilla_buscador_productos_ventas.Rows.Count = 0 Then
                CORREGIR_busqueda()
            End If

            grilla_buscador_productos_ventas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_buscador_productos_ventas.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            lbl_resultado.Visible = True

            lbl_resultado.Text = "SE ENCONTRARON " & grilla_buscador_productos_ventas.Rows.Count & " RESULTADOS"

            If grilla_buscador_productos_ventas.Rows.Count = 0 Then
                lbl_resultado.ForeColor = Color.Red
                lbl_resultado.Text = "NO SE ENCONTRARON RESULTADOS"
            ElseIf grilla_buscador_productos_ventas.Rows.Count = 1 Then
                lbl_resultado.Text = "SE ENCONTRO 1 RESULTADO"
                lbl_resultado.ForeColor = Color.Black
            Else
                lbl_resultado.ForeColor = Color.Black
            End If


            'lbl_resultado.Location = New Point(1024 - lbl_resultado.Width - 7, 30)

            lbl_mensaje.Visible = False
            Me.Enabled = True

            If grilla_buscador_productos_ventas.Rows.Count > 0 Then
                grilla_buscador_productos_ventas.Focus()
            End If

            Exit Sub
        End If



        '    lbl_resultado.Visible = False
        lbl_mensaje.Visible = False
        Me.Enabled = True



        ' Me.Enabled = True
        grilla_buscador_productos_ventas.Focus()
        Exit Sub
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

    Private Sub migrilla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grilla_buscador_productos_ventas.KeyPress
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


        SC.CommandText = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', PRODUCTOS.ULTIMA_COMPRA AS 'ULTIMA COMPRA', PRODUCTOS.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA' from productos, proveedores where proveedores.rut_proveedor=productos.proveedor  and productos.activo='SI' and cod_producto > '" & (Form_venta.txt_codigo.Text) & "'  Limit 1000"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_buscador_productos_ventas.DataSource = DS.Tables(DT.TableName)
        conexion.Close()

        lbl_resultado.Visible = True
        lbl_resultado.Text = "SE ENCONTRARON " & grilla_buscador_productos_ventas.Rows.Count & " RESULTADOS"

        If grilla_buscador_productos_ventas.Rows.Count = 0 Then
            lbl_resultado.ForeColor = Color.Red
            lbl_resultado.Text = "NO SE ENCONTRARON RESULTADOS"
        ElseIf grilla_buscador_productos_ventas.Rows.Count = 1 Then
            lbl_resultado.Text = "SE ENCONTRO 1 RESULTADO"
            lbl_resultado.ForeColor = Color.Black
        Else
            lbl_resultado.ForeColor = Color.Black
        End If

        grilla_buscador_productos_ventas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos_ventas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos_ventas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos_ventas.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_buscador_productos_ventas.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos_ventas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Me.Enabled = True
        grilla_buscador_productos_ventas.Focus()
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

    Private Sub Timer_inactividad_buscar_productos_ventas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_inactividad_buscar_productos_ventas.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub

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




    Private Sub grilla_buscador_productos_ventas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_buscador_productos_ventas.CellContentClick

    End Sub


    Private Sub grilla_buscador_productos_ventas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grilla_buscador_productos_ventas.MouseUp

    End Sub



    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub PictureBox_logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_logo.Click

    End Sub

    Private Sub lbl_mensaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mensaje.Click

    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub lbl_resultado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_resultado.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If grilla_buscador_productos_ventas.Rows.Count = 0 Then
            MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_busqueda.Focus()
            Exit Sub
        End If

        grilla_buscador_productos_ventas.Width = "500"
        Panel1.Location = New Point(512, 131)

        lbl_mensaje.Visible = True
        Me.Enabled = False

        mostrar_malla_kardex()

        lbl_mensaje.Visible = False
        Me.Enabled = True

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

    Sub mostrar_malla_kardex()

        Dim VarCodProducto As String

        VarCodProducto = grilla_buscador_productos_ventas.CurrentRow.Cells(0).Value

        fecha()
        fecha2()

        grilla_kardex.Rows.Clear()
        grilla_kardex.Columns.Clear()
        'grilla_kardex.Columns.Add("", "CODIGO")
        'grilla_kardex.Columns.Add("", "NOMBRE")
        grilla_kardex.Columns.Add("", "MOV.")
        grilla_kardex.Columns.Add("", "USER")
        grilla_kardex.Columns.Add("", "TIPO")
        'grilla_kardex.Columns.Add("", "CONDICION")
        grilla_kardex.Columns.Add("", "NRO.")
        grilla_kardex.Columns.Add("", "FECHA")
        grilla_kardex.Columns.Add("", "CANT.")
        'grilla_kardex.Columns.Add("", "PRECIO")


        'BOLETAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        SC.Connection = conexion
        SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_boleta.n_boleta as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_boleta, boleta, usuarios where boleta.n_boleta=detalle_boleta.n_boleta and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_boleta.cod_producto= '" & (VarCodProducto) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND boleta.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
        DA.SelectCommand = SC
        DA.Fill(DT)

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = " " & DS.Tables(DT.TableName).Rows(i).Item("HORA")

                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA") & MiHora

                grilla_kardex.Rows.Add("SALE",
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If

        'FACTURAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        SC.Connection = conexion
        SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_factura.n_factura as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_factura, factura, usuarios where factura.usuario_responsable <> 'SISTEMA' and factura.n_factura=detalle_factura.n_factura and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_factura.cod_producto= '" & (VarCodProducto) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND factura.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
        DA.SelectCommand = SC
        DA.Fill(DT)

        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaKardex As Date
                Dim MiFechaKardex2 As String
                Dim MiHora As String
                MiFechaKardex = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                MiHora = " " & DS.Tables(DT.TableName).Rows(i).Item("HORA")

                MiFechaKardex2 = MiFechaKardex.ToString("dd-MM-yyy") & " " & MiHora

                Dim DT_Fecha As Date
                DT_Fecha = DS.Tables(DT.TableName).Rows(i).Item("FECHA") & MiHora

                grilla_kardex.Rows.Add("SALE",
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If

        'GUIAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()


        SC.Connection = conexion
        SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_guia.n_guia as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_guia, guia, usuarios where guia.n_guia=detalle_guia.n_guia and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_guia.cod_producto= '" & (VarCodProducto) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND guia.usuario_responsable=usuarios.rut_usuario order by fecha_venta desc"
        DA.SelectCommand = SC
        DA.Fill(DT)

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


                grilla_kardex.Rows.Add("SALE",
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If

        'NOTAS DE CREDITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()


        SC.Connection = conexion
        SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_nota_credito.n_nota_credito as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_nota_credito, nota_credito, usuarios where nota_credito.n_nota_credito=detalle_nota_credito.n_nota_credito and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_nota_credito.cod_producto= '" & (VarCodProducto) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND nota_credito.vendedor=usuarios.rut_usuario order by fecha_venta desc"
        DA.SelectCommand = SC
        DA.Fill(DT)


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


                grilla_kardex.Rows.Add("ENTRA",
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If


        'NOTAS DE DEBITO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()


        SC.Connection = conexion
        SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', detalle_nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, condiciones as CONDICIONES, detalle_nota_debito.n_nota_debito as NUMERO, FECHA_venta as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_nota_debito, nota_debito, usuarios where nota_debito.n_nota_debito=detalle_nota_debito.n_nota_debito and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_nota_debito.cod_producto= '" & (VarCodProducto) & "' AND fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND nota_debito.vendedor=usuarios.rut_usuario order by fecha_venta desc"
        DA.SelectCommand = SC
        DA.Fill(DT)

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


                grilla_kardex.Rows.Add("ENTRA",
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If



        'VALES
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()


        SC.Connection = conexion
        SC.CommandText = "select codigo_producto as 'CODIGO', nombre_producto as 'NOMBRE', nombre_usuario as 'USUARIO', vale.n_vale as NUMERO, fecha as FECHA, cantidad as CANTIDAD, valor_unitario as PRECIO, HORA AS HORA from vale, usuarios where estado <> 'ANULADA' and estado <> 'ANULADO' and vale.codigo_producto= '" & (VarCodProducto) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND vale.usuario_responsable=usuarios.rut_usuario order by fecha desc"
        DA.SelectCommand = SC
        DA.Fill(DT)


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


                grilla_kardex.Rows.Add("SALE",
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           "VALE",
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If

        'VALE DE CAMBIO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        SC.Connection = conexion
        SC.CommandText = "select cod_producto as 'CODIGO', detalle_nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_vale_cambio.nro_vale as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_vale_cambio, vale_cambio, usuarios where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_vale_cambio.cod_producto= '" & (VarCodProducto) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND vale_cambio.usuario_responsable=usuarios.rut_usuario order by fecha desc"
        DA.SelectCommand = SC
        DA.Fill(DT)

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


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"),
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If


        'VALES DE TRASLADO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()


        SC.Connection = conexion
        SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, envios_recibidos.n_documento as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from envios_recibidos, usuarios where envios_recibidos.vendedor=usuarios.rut_usuario and estado <> 'ANULADA' and estado <> 'ANULADO' and cod_producto= '" & (VarCodProducto) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP BY cod_detalle order by fecha desc"
        DA.SelectCommand = SC
        DA.Fill(DT)


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

                grilla_kardex.Rows.Add("ENTRA",
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If


        'CONSUMO INTERNO
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        SC.Connection = conexion
        SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, detalle_consumo_interno.n_documento as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from detalle_consumo_interno, usuarios where detalle_consumo_interno.vendedor=usuarios.rut_usuario and estado <> 'ANULADA' and estado <> 'ANULADO' and cod_producto= '" & (VarCodProducto) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP BY cod_detalle order by fecha desc"
        DA.SelectCommand = SC
        DA.Fill(DT)


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


                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"),
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If

        'AJUSTES DE STOCK
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        SC.Connection = conexion
        SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', movimiento as MOVIMIENTO, nombre_usuario as 'USUARIO', TIPO as TIPO, ajustes_de_stock.n_ajuste as NUMERO, fecha as FECHA, cantidad as CANTIDAD, VALOR_UNITARIO as PRECIO, HORA AS HORA from ajustes_de_stock, usuarios where ajustes_de_stock.vendedor=usuarios.rut_usuario and estado <> 'ANULADA' and estado <> 'ANULADO' and cod_producto= '" & (VarCodProducto) & "' AND fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' GROUP BY cod_detalle order by fecha desc"
        DA.SelectCommand = SC
        DA.Fill(DT)

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

                CDate(DS.Tables(DT.TableName).Rows(i).Item("FECHA")).ToString("dd-MM-yyyy")

                grilla_kardex.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("MOVIMIENTO"),
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                             DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                              CDate(MiFechaKardex2),
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If


        'COMPRAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()

        SC.Connection = conexion
        SC.CommandText = "select cod_producto as 'CODIGO', nombre as 'NOMBRE', nombre as MOVIMIENTO, nombre_usuario as 'USUARIO', compra.TIPO as TIPO, detalle_compra.n_compra as NUMERO, fecha_emision as FECHA, cantidad as CANTIDAD, valor_unitario as PRECIO, HORA AS HORA from detalle_compra, compra, usuarios where compra.n_compra=detalle_compra.n_compra and compra.rut_proveedor=detalle_compra.rut_proveedor and estado <> 'ANULADA' and estado <> 'ANULADO' and detalle_compra.cod_producto= '" & (VarCodProducto) & "' and fecha_emision >='" & (mifecha2) & "' and fecha_emision <= '" & (mifecha4) & "' AND compra.usuario_responsable= usuarios.rut_usuario group by detalle_compra.cod_auto order by fecha_emision desc "
        DA.SelectCommand = SC
        DA.Fill(DT)

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

                grilla_kardex.Rows.Add("ENTRA",
                                          DS.Tables(DT.TableName).Rows(i).Item("USUARIO"),
                                           DS.Tables(DT.TableName).Rows(i).Item("TIPO"),
                                            DS.Tables(DT.TableName).Rows(i).Item("NUMERO"),
                                             CDate(MiFechaKardex2),
                                              DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
            Next
        End If

        grilla_kardex.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_kardex.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_kardex.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_kardex.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_kardex.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_kardex.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        Dim tipo_movimiento As String

        For i = 0 To grilla_kardex.Rows.Count - 1
            tipo_movimiento = grilla_kardex.Rows(i).Cells(0).Value.ToString
            If tipo_movimiento = "ENTRA" Then
                grilla_kardex.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue

                'If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
                '    grilla_kardex.Rows(i).Cells(9).Value = ""
                'End If
            End If

            If tipo_movimiento = "AJUSTE" Then
                grilla_kardex.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next

        If grilla_kardex.Rows.Count <> 0 Then
            If grilla_kardex.Columns(0).Width = 70 Then
                grilla_kardex.Columns(0).Width = 69
            Else
                grilla_kardex.Columns(0).Width = 70
            End If
            grilla_kardex.Columns(1).Width = 70
            grilla_kardex.Columns(2).Width = 70
            grilla_kardex.Columns(3).Width = 70
            grilla_kardex.Columns(4).Width = 100
            grilla_kardex.Columns(5).Width = 70
        End If

        grilla_kardex.Sort(grilla_kardex.Columns(4), System.ComponentModel.ListSortDirection.Descending)

    End Sub

    Private Sub grilla_buscador_productos_ventas_Click(sender As Object, e As EventArgs) Handles grilla_buscador_productos_ventas.Click
        grilla_kardex.Columns.Clear()
        grilla_buscador_productos_ventas.Width = "1006"
        Panel1.Location = New Point(5000, 5000)
    End Sub
End Class