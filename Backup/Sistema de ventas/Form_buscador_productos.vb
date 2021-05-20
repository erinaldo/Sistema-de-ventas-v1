Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_buscador_productos
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

    Private Sub Form_buscador_productos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_buscador_productos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    Private Sub Form_buscador_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llenar_combo_familia()
        'llenar_combo_marca()
        '     combo_conexion.SelectedItem = mi_conexion_actual
        cargar_logo()
        'combo_conexion.SelectedItem = mi_conexion_actual
        txt_busqueda.Focus()
        'Timer_inactividad_buscar_productos_ventas.Start()
        'Combo_marca.Focus()
        'f1.PerformClick()
    End Sub
    Private Sub migrilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla_buscador_productos_ventas.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    Dim codigo As String
        '    Dim valor As Integer
        '    If grilla_buscador_productos_ventas.Rows.Count <= 0 Then
        '        Form_venta.txt_codigo.Focus()
        '        Me.Close()
        '        Exit Sub
        '    End If



        '    codigo = grilla_buscador_productos_ventas.CurrentRow.Cells(0).Value
        '    valor = codigo
        '    codigo = String.Format("{0:000000}", valor)
        '    Form_venta.txt_codigo.Text = codigo
        '    Form_venta.limpiar_datos_productos()
        '    Form_venta.mostrar_cantidad_real()
        '    Form_venta.mostrar_nombre_proveedor()
        '    Form_venta.txt_cantidad_agregar.Text = ""
        '    Form_venta.txt_cantidad_agregar.Focus()
        '    Me.Close()
        'End If
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
        'If txt_busqueda.Text <> "" Then
        '    Dim cadena_correccion As String
        '    Dim tabla_correccion() As String
        '    Dim n_correccion As Integer
        '    Dim cadena_buscada As String
        '    cadena_buscada = ""
        '    cadena_correccion = txt_busqueda.Text
        '    tabla_correccion = Split(cadena_correccion, " ")

        '    For n_correccion = 0 To UBound(tabla_correccion, 1)
        '        conexion.Close()
        '        DS3.Tables.Clear()
        '        DT3.Rows.Clear()
        '        DT3.Columns.Clear()
        '        DS3.Clear()
        '        conexion.Open()

        '        SC3.Connection = conexion
        '        SC3.CommandText = " select * from diccionario_de_palabras WHERE PALABRA SOUNDS LIKE '" & ("%" & tabla_correccion(n_correccion)) & "%""'"
        '        DA3.SelectCommand = SC3
        '        DA3.Fill(DT3)
        '        DS3.Tables.Add(DT3)

        '        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
        '            'For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
        '            cadena_buscada = cadena_buscada & " " & DS3.Tables(DT3.TableName).Rows(0).Item("palabra")
        '        Else
        '            cadena_buscada = cadena_buscada & " " & (tabla_correccion(n_correccion))
        '            ' Next
        '        End If
        '        conexion.Close()
        '    Next
        '    If cadena_buscada <> "" Then
        '        Dim valormensaje As Integer

        '        cadena_buscada = LTrim(Replace(cadena_buscada, " ", " "))
        '        cadena_buscada = LTrim(Replace(cadena_buscada, "  ", " "))
        '        cadena_buscada = LTrim(Replace(cadena_buscada, "   ", " "))
        '        cadena_buscada = LTrim(Replace(cadena_buscada, "    ", " "))
        '        cadena_buscada = LTrim(Replace(cadena_buscada, "     ", " "))
        '        cadena_buscada = LTrim(Replace(cadena_buscada, "      ", " "))
        '        cadena_buscada = LTrim(Replace(cadena_buscada, "       ", " "))
        '        cadena_buscada = LTrim(Replace(cadena_buscada, "        ", " "))
        '        cadena_buscada = LTrim(Replace(cadena_buscada, "         ", " "))

        '        cadena_buscada = RTrim(Replace(cadena_buscada, " ", " "))
        '        cadena_buscada = RTrim(Replace(cadena_buscada, "  ", " "))
        '        cadena_buscada = RTrim(Replace(cadena_buscada, "   ", " "))
        '        cadena_buscada = RTrim(Replace(cadena_buscada, "    ", " "))
        '        cadena_buscada = RTrim(Replace(cadena_buscada, "     ", " "))
        '        cadena_buscada = RTrim(Replace(cadena_buscada, "      ", " "))
        '        cadena_buscada = RTrim(Replace(cadena_buscada, "       ", " "))
        '        cadena_buscada = RTrim(Replace(cadena_buscada, "        ", " "))
        '        cadena_buscada = RTrim(Replace(cadena_buscada, "         ", " "))

        '        txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, " ", " "))
        '        txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "  ", " "))
        '        txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "   ", " "))
        '        txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "    ", " "))
        '        txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "     ", " "))
        '        txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "      ", " "))
        '        txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "       ", " "))
        '        txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "        ", " "))
        '        txt_busqueda.Text = LTrim(Replace(txt_busqueda.Text, "         ", " "))

        '        txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, " ", " "))
        '        txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "  ", " "))
        '        txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "   ", " "))
        '        txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "    ", " "))
        '        txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "     ", " "))
        '        txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "      ", " "))
        '        txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "       ", " "))
        '        txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "        ", " "))
        '        txt_busqueda.Text = RTrim(Replace(txt_busqueda.Text, "         ", " "))


        '        If txt_busqueda.Text <> cadena_buscada Then

        '            valormensaje = MsgBox("QUIZAS QUISISTE DECIR: " & cadena_buscada, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "BUSCADOR")

        '            If valormensaje = vbYes Then
        '                txt_busqueda.Text = cadena_buscada
        '                buscar()
        '            Else
        '                txt_busqueda.Text = txt_busqueda.Text
        '                txt_busqueda.Focus()
        '            End If
        '        End If

        '    End If
        'End If
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

        If txt_busqueda.Text <> "" Then

            If Check_item.Checked = False Then
                consulta_busqueda = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', productos.ULTIMA_COMPRA AS 'ULTIMA COMPRA', productos.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA', COSTO AS 'COSTO', CANTIDAD_MINIMA AS 'STOCK MIN.', familia.nombre_familia as 'FAMILIA', subfamilia.nombre_subfamilia as 'SUBFAMILIA', subfamilia_dos.nombre_subfamilia as 'SUBFAMILIA DOS' , subfamilia_dos.medida_1 as 'MEDIDA UNO' , subfamilia_dos.medida_2 as 'MEDIDA DOS' , subfamilia_dos.medida_3 as 'MEDIDA TRES'  , subfamilia_dos.m as 'M'  , subfamilia_dos.o as 'O' from productos, proveedores, familia, subfamilia, subfamilia_dos where productos.familia=familia.codigo and productos.subfamilia=subfamilia.cod_auto and productos.subfamilia_dos=subfamilia_dos.cod_auto and proveedores.rut_proveedor=productos.proveedor "
            Else
                consulta_busqueda = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', productos.ULTIMA_COMPRA AS 'ULTIMA COMPRA', productos.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA', COSTO AS 'COSTO', CANTIDAD_MINIMA AS 'STOCK MIN.', familia.nombre_familia as 'FAMILIA', subfamilia.nombre_subfamilia as 'SUBFAMILIA', subfamilia_dos.nombre_subfamilia as 'SUBFAMILIA DOS' , subfamilia_dos.medida_1 as 'MEDIDA UNO' , subfamilia_dos.medida_2 as 'MEDIDA DOS' , subfamilia_dos.medida_3 as 'MEDIDA TRES'  , subfamilia_dos.m as 'M'  , subfamilia_dos.o as 'O' from productos, proveedores, familia, subfamilia, subfamilia_dos where productos.subfamilia_dos <> '0' and productos.familia=familia.codigo and productos.subfamilia=subfamilia.cod_auto and productos.subfamilia_dos=subfamilia_dos.cod_auto and proveedores.rut_proveedor=productos.proveedor "
            End If

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
            grilla_buscador_productos_ventas.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_buscador_productos_ventas.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_buscador_productos_ventas.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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


        'SC.CommandText = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', PRODUCTOS.ULTIMA_COMPRA AS 'ULTIMA COMPRA', PRODUCTOS.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA', COSTO AS 'COSTO', CANTIDAD_MINIMA AS 'STOCK MIN.'  from productos, proveedores where proveedores.rut_proveedor=productos.proveedor and cod_producto > '" & (Form_venta.txt_codigo.Text) & "'  Limit 1000"
        SC.CommandText = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', productos.ULTIMA_COMPRA AS 'ULTIMA COMPRA', productos.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA', COSTO AS 'COSTO', CANTIDAD_MINIMA AS 'STOCK MIN.', familia.nombre_familia as 'FAMILIA', subfamilia.nombre_subfamilia as 'SUBFAMILIA', subfamilia_dos.nombre_subfamilia as 'SUBFAMILIA DOS' from productos, proveedores, familia, subfamilia, subfamilia_dos where productos.familia=familia.codigo and productos.subfamilia=subfamilia.cod_auto and productos.subfamilia_dos=subfamilia_dos.cod_auto and proveedores.rut_proveedor=productos.proveedor and cod_producto > '" & (Form_venta.txt_codigo.Text) & "'  Limit 1000"

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
        grilla_buscador_productos_ventas.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos_ventas.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'grilla_buscador_productos_ventas.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_buscador_productos_ventas.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_buscador_productos_ventas.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_buscador_productos_ventas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Me.Enabled = True
        grilla_buscador_productos_ventas.Focus()
        Exit Sub

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
    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_buscador_productos_ventas.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            txt_busqueda.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_buscador_productos_ventas, save.FileName)
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
        For c As Integer = 0 To grilla_buscador_productos_ventas.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_buscador_productos_ventas.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_buscador_productos_ventas.RowCount - 1
            For c As Integer = 0 To grilla_buscador_productos_ventas.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_buscador_productos_ventas.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub Check_item_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_item.CheckedChanged
        grilla_buscador_productos_ventas.DataSource = Nothing
        lbl_resultado.Text = ""
    End Sub
End Class