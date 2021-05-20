Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class Form_buscador_clientes_abonos
    Dim mitexto As String
    Dim micampo As String
    Dim consulta_busqueda As String

    Private Sub form_buscar_clientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_agregar_abonos.Visible = True Then
            Form_agregar_abonos.WindowState = FormWindowState.Normal
            Form_agregar_abonos.Enabled = True
            Form_agregar_abonos.txt_rut.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub form_buscar_clientes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub form_buscar_clientes_abonos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    End Sub

    Sub buscar()
        lbl_resultado.Visible = True
        lbl_resultado.Text = "ESPERE POR FAVOR..."
        Me.Enabled = False
        If txt_busqueda.Text <> "" Then
            consulta_busqueda = "select rut_cliente_retira as RUT, nombre_cliente_retira as NOMBRE from clientes_retira WHERE"
            consulta_busqueda = "SELECT RUT_CLIENTE AS RUT,  cod_CLIENTE AS 'COD. CLIENTE', NOMBRE_CLIENTE AS NOMBRE, DIRECCION_CLIENTE AS DIRECCION, EMAIL_CLIENTE AS EMAIL, COMUNA_CLIENTE AS COMUNA, TELEFONO_CLIENTE AS TELEFONO,  GIRO_CLIENTE AS GIRO, CIUDAD_CLIENTE AS CIUDAD FROM CLIENTES WHERE"

            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_busqueda.Text
            'Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")

            For n = 0 To UBound(tabla, 1)
                Dim fin_consulta As String
                fin_consulta = Strings.Right(consulta_busqueda, 5)
                If fin_consulta = "WHERE" Then
                    consulta_busqueda = consulta_busqueda & " CONCAT_WS(' ', RUT_CLIENTE,  cod_CLIENTE, NOMBRE_CLIENTE, DIRECCION_CLIENTE, EMAIL_CLIENTE, COMUNA_CLIENTE, TELEFONO_CLIENTE,  GIRO_CLIENTE, CIUDAD_CLIENTE) LIKE '" & ("%" & tabla(n) & "%") & "'"
                Else
                    consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ', RUT_CLIENTE,  cod_CLIENTE, NOMBRE_CLIENTE, DIRECCION_CLIENTE, EMAIL_CLIENTE, COMUNA_CLIENTE, TELEFONO_CLIENTE,  GIRO_CLIENTE, CIUDAD_CLIENTE) LIKE '" & ("%" & tabla(n) & "%") & "'"
                End If
            Next

            migrilla.DataSource = Nothing
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
            migrilla.DataSource = DS.Tables(DT.TableName)
            conexion.Close()

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

            Me.Enabled = True
            If migrilla.Rows.Count > 0 Then
                migrilla.Focus()
            End If
            Exit Sub
        End If
    End Sub

    Private Sub migrilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles migrilla.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Sub mostrar_datos_clientes()
        If Form_agregar_abonos.Visible = True Then
            Dim codigo As String
            Dim rut As String
            codigo = migrilla.CurrentRow.Cells(1).Value
            rut = migrilla.CurrentRow.Cells(0).Value

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (rut) & "' and cod_cliente ='" & (codigo) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                Form_agregar_abonos.txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_agregar_abonos.txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                Form_agregar_abonos.txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                Form_agregar_abonos.txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                Form_agregar_abonos.txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

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

    Private Sub migrilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles migrilla.KeyDown
        If Form_agregar_abonos.Visible = True Then
            If e.KeyCode = Keys.Enter Then
                Dim codigo As String
                If migrilla.Rows.Count <= 0 Then
                    Me.Close()
                    Form_agregar_abonos.txt_rut.Focus()
                    Me.Close()
                Else
                    codigo = migrilla.CurrentRow.Cells(0).Value
                    Form_agregar_abonos.limpiar_datos_cliente()
                    Form_agregar_abonos.txt_rut.Text = codigo
                    Form_agregar_abonos.Combo_cuotas.Items.Clear()
                    Form_agregar_abonos.grilla_estado_de_cuenta.Rows.Clear()
                    Form_agregar_abonos.calcular_totales()
                    Form_agregar_abonos.txt_rut.Focus()
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

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub
End Class