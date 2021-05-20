Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_buscador_inteligente
    Dim consulta_busqueda As String

    Private Sub Form_buscador_inteligente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_ventas_lubricentro.Visible = True Then
            Form_ventas_lubricentro.WindowState = FormWindowState.Normal
            Form_ventas_lubricentro.Enabled = True

            If buscar_ventas_lubricentro = "1" Then
                Form_ventas_lubricentro.txt_codigo_1.Focus()
            End If

            If buscar_ventas_lubricentro = "2" Then
                Form_ventas_lubricentro.txt_codigo_2.Focus()
            End If

            If buscar_ventas_lubricentro = "3" Then
                Form_ventas_lubricentro.txt_codigo_3.Focus()
            End If

            If buscar_ventas_lubricentro = "4" Then
                Form_ventas_lubricentro.txt_codigo_4.Focus()
            End If

            If buscar_ventas_lubricentro = "5" Then
                Form_ventas_lubricentro.txt_codigo_5.Focus()
            End If

            If buscar_ventas_lubricentro = "6" Then
                Form_ventas_lubricentro.txt_codigo_6.Focus()
            End If

            If buscar_ventas_lubricentro = "7" Then
                Form_ventas_lubricentro.txt_codigo_7.Focus()
            End If

            If buscar_ventas_lubricentro = "8" Then
                Form_ventas_lubricentro.txt_codigo_8.Focus()
            End If

            If buscar_ventas_lubricentro = "9" Then
                Form_ventas_lubricentro.txt_codigo_9.Focus()
            End If

            If buscar_ventas_lubricentro = "10" Then
                Form_ventas_lubricentro.txt_codigo_10.Focus()
            End If

            If buscar_ventas_lubricentro = "11" Then
                Form_ventas_lubricentro.txt_codigo_11.Focus()
            End If

            If buscar_ventas_lubricentro = "12" Then
                Form_ventas_lubricentro.txt_codigo_12.Focus()
            End If

            If buscar_ventas_lubricentro = "13" Then
                Form_ventas_lubricentro.txt_codigo_13.Focus()
            End If

            If buscar_ventas_lubricentro = "14" Then
                Form_ventas_lubricentro.txt_codigo_14.Focus()
            End If

            If buscar_ventas_lubricentro = "15" Then
                Form_ventas_lubricentro.txt_codigo_15.Focus()
            End If
        End If


        If Form_orden_de_trabajo.Visible = True Then
            Form_orden_de_trabajo.WindowState = FormWindowState.Normal
            Form_orden_de_trabajo.Enabled = True

            If buscar_ventas_lubricentro = "1" Then
                Form_orden_de_trabajo.txt_codigo_1.Focus()
            End If

            If buscar_ventas_lubricentro = "2" Then
                Form_orden_de_trabajo.txt_codigo_2.Focus()
            End If

            If buscar_ventas_lubricentro = "3" Then
                Form_orden_de_trabajo.txt_codigo_3.Focus()
            End If

            If buscar_ventas_lubricentro = "4" Then
                Form_orden_de_trabajo.txt_codigo_4.Focus()
            End If

            If buscar_ventas_lubricentro = "5" Then
                Form_orden_de_trabajo.txt_codigo_5.Focus()
            End If

            If buscar_ventas_lubricentro = "6" Then
                Form_orden_de_trabajo.txt_codigo_6.Focus()
            End If

            If buscar_ventas_lubricentro = "7" Then
                Form_orden_de_trabajo.txt_codigo_7.Focus()
            End If

            If buscar_ventas_lubricentro = "8" Then
                Form_orden_de_trabajo.txt_codigo_8.Focus()
            End If

            If buscar_ventas_lubricentro = "9" Then
                Form_orden_de_trabajo.txt_codigo_9.Focus()
            End If

            If buscar_ventas_lubricentro = "10" Then
                Form_orden_de_trabajo.txt_codigo_10.Focus()
            End If

            If buscar_ventas_lubricentro = "11" Then
                Form_orden_de_trabajo.txt_codigo_11.Focus()
            End If

            If buscar_ventas_lubricentro = "12" Then
                Form_orden_de_trabajo.txt_codigo_12.Focus()
            End If

            If buscar_ventas_lubricentro = "13" Then
                Form_orden_de_trabajo.txt_codigo_13.Focus()
            End If

            If buscar_ventas_lubricentro = "14" Then
                Form_orden_de_trabajo.txt_codigo_14.Focus()
            End If

            If buscar_ventas_lubricentro = "15" Then
                Form_orden_de_trabajo.txt_codigo_15.Focus()
            End If
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
            mostrar_cierre_sistema()
            Form_menu_principal.Close()
        End If
    End Sub
    Private Sub Form_buscador_inteligente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        buscar()
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

    Private Sub migrilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles migrilla.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim codigo As String
            Dim valor As Integer

            If Form_ventas_lubricentro.Visible = True Then
                If migrilla.Rows.Count <= 0 Then
                    Form_ventas_lubricentro.txt_codigo_patente.Focus()
                    Me.Close()
                    Exit Sub
                End If

                codigo = migrilla.CurrentRow.Cells(0).Value
                valor = codigo
                codigo = String.Format("{0:000000}", valor)

                If buscar_ventas_lubricentro = "1" Then
                    Form_ventas_lubricentro.txt_codigo_1.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_1.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "2" Then
                    Form_ventas_lubricentro.txt_codigo_2.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_2.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "3" Then
                    Form_ventas_lubricentro.txt_codigo_3.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_3.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "4" Then
                    Form_ventas_lubricentro.txt_codigo_4.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_4.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "5" Then
                    Form_ventas_lubricentro.txt_codigo_5.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_5.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "6" Then
                    Form_ventas_lubricentro.txt_codigo_6.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_6.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "7" Then
                    Form_ventas_lubricentro.txt_codigo_7.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_7.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "8" Then
                    Form_ventas_lubricentro.txt_codigo_8.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_8.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "9" Then
                    Form_ventas_lubricentro.txt_codigo_9.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_9.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "10" Then
                    Form_ventas_lubricentro.txt_codigo_10.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_10.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "11" Then
                    Form_ventas_lubricentro.txt_codigo_11.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_11.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "12" Then
                    Form_ventas_lubricentro.txt_codigo_12.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_12.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "13" Then
                    Form_ventas_lubricentro.txt_codigo_13.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_13.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "14" Then
                    Form_ventas_lubricentro.txt_codigo_14.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_14.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "15" Then
                    Form_ventas_lubricentro.txt_codigo_15.Text = codigo
                    Form_ventas_lubricentro.mostrar_datos_productos()
                    Form_ventas_lubricentro.txt_codigo_15.Focus()
                    Me.Close()
                End If
            End If


            If Form_orden_de_trabajo.Visible = True Then
                If migrilla.Rows.Count <= 0 Then
                    Form_orden_de_trabajo.txt_rut_cliente.Focus()
                    Me.Close()
                    Exit Sub
                End If

                codigo = migrilla.CurrentRow.Cells(0).Value
                valor = codigo
                codigo = String.Format("{0:000000}", valor)

                If buscar_ventas_lubricentro = "1" Then
                    Form_orden_de_trabajo.txt_codigo_1.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_1.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "2" Then
                    Form_orden_de_trabajo.txt_codigo_2.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_2.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "3" Then
                    Form_orden_de_trabajo.txt_codigo_3.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_3.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "4" Then
                    Form_orden_de_trabajo.txt_codigo_4.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_4.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "5" Then
                    Form_orden_de_trabajo.txt_codigo_5.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_5.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "6" Then
                    Form_orden_de_trabajo.txt_codigo_6.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_6.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "7" Then
                    Form_orden_de_trabajo.txt_codigo_7.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_7.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "8" Then
                    Form_orden_de_trabajo.txt_codigo_8.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_8.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "9" Then
                    Form_orden_de_trabajo.txt_codigo_9.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_9.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "10" Then
                    Form_orden_de_trabajo.txt_codigo_10.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_10.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "11" Then
                    Form_orden_de_trabajo.txt_codigo_11.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_11.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "12" Then
                    Form_orden_de_trabajo.txt_codigo_12.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_12.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "13" Then
                    Form_orden_de_trabajo.txt_codigo_13.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_13.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "14" Then
                    Form_orden_de_trabajo.txt_codigo_14.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_14.Focus()
                    Me.Close()
                End If

                If buscar_ventas_lubricentro = "15" Then
                    Form_orden_de_trabajo.txt_codigo_15.Text = codigo
                    Form_orden_de_trabajo.mostrar_datos_productos()
                    Form_orden_de_trabajo.txt_codigo_15.Focus()
                    Me.Close()
                End If
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

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub
End Class