Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_buscador_inteligente
    Dim consulta_busqueda As String

    Private Sub Form_buscador_inteligente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_ventas_lubricentro.WindowState = FormWindowState.Normal
        Form_ventas_lubricentro.Enabled = True

        If buscar_ventas_lubricentro = "FILTRO DE ACEITE" Then
            Form_ventas_lubricentro.txt_codigo_filtro_aceite.Focus()
        End If

        If buscar_ventas_lubricentro = "ACEITE DE MOTOR" Then
            Form_ventas_lubricentro.txt_codigo_aceite_motor.Focus()
        End If

        If buscar_ventas_lubricentro = "FILTRO DE AIRE" Then
            Form_ventas_lubricentro.txt_codigo_filtro_aire.Focus()
        End If

        If buscar_ventas_lubricentro = "ACEITE DE COMBUSTIBLE" Then
            Form_ventas_lubricentro.txt_codigo_aceite_combustible.Focus()
        End If

        If buscar_ventas_lubricentro = "ACEITE DE CAJA" Then
            Form_ventas_lubricentro.txt_codigo_aceite_caja.Focus()
        End If

        If buscar_ventas_lubricentro = "ACEITE DIFERENCIAL" Then
            Form_ventas_lubricentro.txt_codigo_aceite_diferencial.Focus()
        End If

        If buscar_ventas_lubricentro = "OTROS 1" Then
            Form_ventas_lubricentro.txt_codigo_otros_1.Focus()
        End If

        If buscar_ventas_lubricentro = "OTROS 2" Then
            Form_ventas_lubricentro.txt_codigo_otros_2.Focus()
        End If
    End Sub

    Private Sub Form_buscador_inteligente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    Private Sub Form_buscador_inteligente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        buscar()
        'lbl_resultado.Location = New Point(1024 - lbl_resultado.Width - 7, 30)
    End Sub







    'Sub buscar()

    '    'If txt_comuna.Text = "" And txt_correo.Text = "" And txt_direccion.Text = "" And txt_giro.Text = "" And txt_nombre.Text = "" And txt_rut.Text = "" And txt_telefono.Text = "" And Combo_tipo.Text = "" Then
    '    '    Exit Sub
    '    'End If

    '    'If txt_nombre.Text = "" Then
    '    '    'MsgBox("COMO MINIMO DEBE ASIGNAR UN NOMBRE A LA BUSQUEDA", MsgBoxStyle.Critical, "INFORMACION")
    '    '    'txt_nombre.Focus()
    '    '    'Exit Sub
    '    '    ' txt_nombre.Text = "*"
    '    'End If


    '    lbl_resultado.Visible = True
    '    lbl_resultado.Text = "ESPERE POR FAVOR..."
    '    Me.Enabled = False

    '    If txt_nombre.Text <> "" Then
    '        campo_nombre = "%" & txt_nombre.Text & "%"
    '    End If

    '    If txt_direccion.Text <> "" Then
    '        campo_direccion = "%" & txt_direccion.Text & "%"
    '    End If

    '    If txt_comuna.Text <> "" Then
    '        campo_comuna = "%" & txt_comuna.Text & "%"
    '    End If

    '    If txt_rut.Text <> "" Then
    '        campo_rut = "%" & txt_rut.Text & "%"
    '    End If

    '    If txt_giro.Text <> "" Then
    '        campo_giro = "%" & txt_giro.Text & "%"
    '    End If

    '    If txt_correo.Text <> "" Then
    '        campo_correo = "%" & txt_correo.Text & "%"
    '    End If

    '    If txt_telefono.Text <> "" Then
    '        campo_telefono = "%" & txt_telefono.Text & "%"
    '    End If

    '    If Combo_tipo.Text <> "" Then
    '        campo_tipo = "%" & Combo_tipo.Text & "%"
    '    End If


    '    consulta_busqueda = "SELECT RUT_CLIENTE AS RUT,  cod_CLIENTE AS 'COD. CLIENTE', NOMBRE_CLIENTE AS NOMBRE, DIRECCION_CLIENTE AS DIRECCION, EMAIL_CLIENTE AS EMAIL, COMUNA_CLIENTE AS COMUNA, TELEFONO_CLIENTE AS TELEFONO,  GIRO_CLIENTE AS GIRO, CIUDAD_CLIENTE AS CIUDAD FROM CLIENTES WHERE"


    '    Dim fin_consulta As String

    '    fin_consulta = Strings.Right(consulta_busqueda, 5)
    '    'If fin_consulta = "WHERE" Then
    '    '    Exit Sub
    '    'End If


    '    ' If txt_nombre.Text <> "" Then
    '    ' End If

    '    'If txt_nombre.Text <> "" Then




    '    '    ' consulta_busqueda = consulta_busqueda & " and NOMBRE_CLIENTE like '" & (campo_nombre) & "'"
    '    'End If


    '    If txt_nombre.Text <> "" Then

    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " NOMBRE_CLIENTE like '" & (campo_nombre) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and NOMBRE_CLIENTE like '" & (campo_nombre) & "'"
    '        End If
    '        '  consulta_busqueda = consulta_busqueda & " and direccion_CLIENTE= '" & (campo_direccion) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If




    '    If txt_direccion.Text <> "" Then

    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " direccion_CLIENTE like '" & (campo_direccion) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and direccion_CLIENTE like '" & (campo_direccion) & "'"
    '        End If
    '        '  consulta_busqueda = consulta_busqueda & " and direccion_CLIENTE= '" & (campo_direccion) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If


    '    If txt_comuna.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " COMUNA_CLIENTE like '" & (campo_comuna) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and COMUNA_CLIENTE like '" & (campo_comuna) & "'"
    '        End If

    '        ' consulta_busqueda = consulta_busqueda & " and COMUNA_CLIENTE like '" & (campo_comuna) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If


    '    If txt_rut.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " rut_CLIENTE like '" & (campo_rut) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and rut_CLIENTE like '" & (campo_rut) & "'"
    '        End If

    '        ' consulta_busqueda = consulta_busqueda & " and rut_CLIENTE like '" & (campo_rut) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If

    '    If txt_giro.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " giro_CLIENTE like '" & (campo_giro) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and giro_CLIENTE like '" & (campo_giro) & "'"
    '        End If

    '        'consulta_busqueda = consulta_busqueda & " and giro_CLIENTE like '" & (campo_giro) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If

    '    If txt_correo.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " EMAIL_CLIENTE like '" & (campo_correo) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and EMAIL_CLIENTE like '" & (campo_correo) & "'"
    '        End If

    '        '  consulta_busqueda = consulta_busqueda & " and EMAIL_CLIENTE like '" & (campo_correo) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If



    '    If txt_telefono.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " telefono_CLIENTE like '" & (campo_telefono) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and telefono_CLIENTE like '" & (campo_telefono) & "'"
    '        End If


    '        '   consulta_busqueda = consulta_busqueda & " and telefono_CLIENTE like '" & (campo_telefono) & "'"

    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If

    '    If Combo_tipo.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " tipo_CLIENTE like '" & (campo_tipo) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and tipo_CLIENTE like '" & (campo_tipo) & "'"
    '        End If

    '        ' consulta_busqueda = consulta_busqueda & " and tipo_CLIENTE like '" & (campo_tipo) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If

    '    ' consulta_busqueda = consulta_busqueda & " group by cod_producto"

    '    fin_consulta = Strings.Right(consulta_busqueda, 5)

    '    If fin_consulta = "WHERE" Then
    '        Me.Enabled = True
    '        lbl_resultado.Visible = False
    '        txt_nombre.Focus()
    '        Exit Sub
    '    End If







    '    Dim DT As New DataTable

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = consulta_busqueda
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    migrilla.DataSource = DS.Tables(DT.TableName)
    '    conexion.Close()

    '    lbl_resultado.Visible = True
    '    lbl_resultado.Text = "SE ENCONTRARON " & migrilla.Rows.Count & " RESULTADOS"

    '    If migrilla.Rows.Count = 0 Then
    '        lbl_resultado.ForeColor = Color.Red
    '        lbl_resultado.Text = "NO SE ENCONTRARON RESULTADOS"
    '    ElseIf migrilla.Rows.Count = 1 Then
    '        lbl_resultado.Text = "SE ENCONTRO 1 RESULTADO"
    '        lbl_resultado.ForeColor = Color.Black
    '    Else
    '        lbl_resultado.ForeColor = Color.Black
    '    End If

    '    Combo_tipo.Text = ""

    '    txt_comuna.Text = ""
    '    txt_correo.Text = ""
    '    txt_direccion.Text = ""
    '    txt_giro.Text = ""
    '    txt_nombre.Text = ""
    '    txt_rut.Text = ""
    '    txt_telefono.Text = ""

    '    ' lbl_mensaje.Visible = False
    '    'For i = 0 To migrilla.Rows.Count - 1
    '    '    migrilla.CurrentRow.Cells(0).Selected = True
    '    '    migrilla.Focus()


    '    Me.Enabled = True
    '    migrilla.Focus()
    '    Exit Sub
    'End Sub



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

            migrilla.DataSource = Nothing

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

            migrilla.DataSource = DS.Tables(DT.TableName)
            conexion.Close()

            If migrilla.Rows.Count = 0 Then
                CORREGIR_busqueda()
            End If

            migrilla.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            migrilla.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            migrilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            lbl_resultado.Visible = True

            lbl_resultado.Text = "SE ENCONTRARON " & migrilla.Rows.Count & " RESULTADOS"

            If migrilla.Rows.Count = 0 Then
                lbl_resultado.ForeColor = Color.Red
                lbl_resultado.Text = "NO SE ENCONTRARON RESULTADOS"
            ElseIf migrilla.Rows.Count = 1 Then
                lbl_resultado.Text = "SE ENCONTRO 1 RESULTADO"
                lbl_resultado.ForeColor = Color.Black
            Else
                lbl_resultado.ForeColor = Color.Black
            End If


            'lbl_resultado.Location = New Point(1024 - lbl_resultado.Width - 7, 30)

            lbl_mensaje.Visible = False
            Me.Enabled = True

            If migrilla.Rows.Count > 0 Then
                migrilla.Focus()
            End If

            Exit Sub
        End If



        '    lbl_resultado.Visible = False
        lbl_mensaje.Visible = False
        Me.Enabled = True



        ' Me.Enabled = True
        migrilla.Focus()
        Exit Sub
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

    Private Sub migrilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles migrilla.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub migrilla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles migrilla.DoubleClick



    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub





    Private Sub migrilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles migrilla.CellContentClick

    End Sub

    Private Sub migrilla_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles migrilla.Enter

    End Sub

    Private Sub migrilla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles migrilla.KeyPress
        'If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
        '    Dim codigo As String

        '    If migrilla.Rows.Count <= 0 Then
        '        Me.Close()
        '        Form_venta.txt_codigo.Focus()
        '        Me.Close()
        '    Else
        '        codigo = migrilla.CurrentRow.Cells(0).Value
        '        Form_venta.limpiar_datos_clientes_enter()
        '        Form_venta.txt_rut.Text = codigo
        '        Form_venta.txt_descto.Text = "0"
        '        Form_venta.mostrar_datos_clientes()
        '        ' Form_venta.llenar_combo_retira()
        '        Form_venta.limpiar_datos_clientes_retira()
        '        Form_venta.guardar_descuento()
        '        Form_venta.grilla_detalle.Rows.Clear()
        '        Form_venta.cargar_descuento()
        '        Form_venta.calcular_totales()
        '        Me.Close()
        '    End If
        'End If
    End Sub





    Private Sub VolveralmenuprincipalToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    'Private Sub txt_giro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_giro.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_giro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_giro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_giro.BackColor = Color.White
    'End Sub

    'Private Sub txt_giro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub txt_correo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_correo.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_correo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_correo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_correo.BackColor = Color.White
    'End Sub

    'Private Sub txt_correo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub txt_telefono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_telefono.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_telefono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_telefono.BackColor = Color.White
    'End Sub

    'Private Sub txt_telefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_nombre.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_nombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_nombre.BackColor = Color.White
    'End Sub

    'Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub txt_direccion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_direccion.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_direccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    Private Sub txt_busqueda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_busqueda.BackColor = Color.White
    End Sub

    Private Sub txt_busqueda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_busqueda.BackColor = Color.Yellow
    End Sub

    Private Sub txt_comuna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_comuna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_comuna.BackColor = Color.White
    'End Sub

    'Private Sub txt_comuna_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_rut.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_rut.BackColor = Color.White
    'End Sub

    'Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub Combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_tipo.BackColor = Color.Yellow
    'End Sub

    Private Sub Combo_tipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    'Private Sub Combo_tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_tipo.BackColor = Color.White
    'End Sub

    Private Sub Combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub migrilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles migrilla.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim codigo As String
            Dim valor As Integer
            If migrilla.Rows.Count <= 0 Then
                Form_ventas_lubricentro.txt_codigo_patente.Focus()
                Me.Close()
                Exit Sub
            End If

            codigo = migrilla.CurrentRow.Cells(0).Value
            valor = codigo
            codigo = String.Format("{0:000000}", valor)

            If buscar_ventas_lubricentro = "FILTRO DE ACEITE" Then
                Form_ventas_lubricentro.txt_codigo_filtro_aceite.Text = codigo
                Form_ventas_lubricentro.mostrar_datos_filtro_de_aceite()
                Form_ventas_lubricentro.txt_codigo_filtro_aceite.Focus()
                Me.Close()
            End If

            If buscar_ventas_lubricentro = "ACEITE DE MOTOR" Then
                Form_ventas_lubricentro.txt_codigo_aceite_motor.Text = codigo
                Form_ventas_lubricentro.mostrar_datos_aceite_de_motor()
                Form_ventas_lubricentro.txt_codigo_aceite_motor.Focus()
                Me.Close()
            End If

            If buscar_ventas_lubricentro = "FILTRO DE AIRE" Then
                Form_ventas_lubricentro.txt_codigo_filtro_aire.Text = codigo
                Form_ventas_lubricentro.mostrar_datos_filtro_de_aire()
                Form_ventas_lubricentro.txt_codigo_filtro_aire.Focus()
                Me.Close()
            End If

            If buscar_ventas_lubricentro = "ACEITE DE COMBUSTIBLE" Then
                Form_ventas_lubricentro.txt_codigo_aceite_combustible.Text = codigo
                Form_ventas_lubricentro.mostrar_datos_aceite_de_combustible()
                Form_ventas_lubricentro.txt_codigo_aceite_combustible.Focus()
                Me.Close()
            End If

            If buscar_ventas_lubricentro = "ACEITE DE CAJA" Then
                Form_ventas_lubricentro.txt_codigo_aceite_caja.Text = codigo
                Form_ventas_lubricentro.mostrar_datos_aceite_de_caja()
                Form_ventas_lubricentro.txt_codigo_aceite_caja.Focus()
                Me.Close()
            End If

            If buscar_ventas_lubricentro = "ACEITE DIFERENCIAL" Then
                Form_ventas_lubricentro.txt_codigo_aceite_diferencial.Text = codigo
                Form_ventas_lubricentro.mostrar_datos_aceite_diferencial()
                Form_ventas_lubricentro.txt_codigo_aceite_diferencial.Focus()
                Me.Close()
            End If

            If buscar_ventas_lubricentro = "OTROS 1" Then
                Form_ventas_lubricentro.txt_codigo_otros_1.Text = codigo
                Form_ventas_lubricentro.mostrar_datos_otros_1()
                Form_ventas_lubricentro.txt_codigo_otros_1.Focus()
                Me.Close()
            End If

            If buscar_ventas_lubricentro = "OTROS 2" Then
                Form_ventas_lubricentro.txt_codigo_otros_2.Text = codigo
                Form_ventas_lubricentro.mostrar_datos_otros_2()
                Form_ventas_lubricentro.txt_codigo_otros_2.Focus()
                Me.Close()
            End If

            If buscar_ventas_lubricentro = "OTROS 3" Then
                Form_ventas_lubricentro.txt_codigo_otros_3.Text = codigo
                Form_ventas_lubricentro.mostrar_datos_otros_3()
                Form_ventas_lubricentro.txt_codigo_otros_3.Focus()
                Me.Close()
            End If

            If buscar_ventas_lubricentro = "OTROS 4" Then
                Form_ventas_lubricentro.txt_codigo_otros_4.Text = codigo
                Form_ventas_lubricentro.mostrar_datos_otros_4()
                Form_ventas_lubricentro.txt_codigo_otros_4.Focus()
                Me.Close()
            End If
        End If
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

            If txt_busqueda.Text = "" Then
                Exit Sub
            End If

            buscar()
        End If
    End Sub

    Private Sub txt_busqueda_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.LostFocus
        txt_busqueda.BackColor = Color.White
    End Sub


    Private Sub txt_busqueda_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.GotFocus
        txt_busqueda.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged

    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub
End Class