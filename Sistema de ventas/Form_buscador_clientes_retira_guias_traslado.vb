Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_buscador_clientes_retira_guias_traslado
    Dim campo_nombre As String
    Dim campo_apellido As String
    Dim consulta_busqueda As String
    Private Sub Form_buscador_clientes_retira_guias_traslado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_guias_traslado.Enabled = True
        Form_guias_traslado.txt_rut_retira.Focus()
    End Sub

    Private Sub Form_buscador_clientes_retira_guias_traslado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_buscador_clientes_retira_guias_traslado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        migrilla.Font = New System.Drawing.Font("Arial", 10.25!, System.Drawing.FontStyle.Regular)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub


    Sub buscar()

        Me.Enabled = False
        If txt_busqueda.Text <> "" Then
            consulta_busqueda = "select rut_cliente_retira as RUT, nombre_cliente_retira as NOMBRE from clientes_retira WHERE"
            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_busqueda.Text
            '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")

            For n = 0 To UBound(tabla, 1)
                Dim fin_consulta As String
                fin_consulta = Strings.Right(consulta_busqueda, 5)
                If fin_consulta = "WHERE" Then
                    consulta_busqueda = consulta_busqueda & " CONCAT_WS(' ',rut_cliente_retira, nombre_cliente_retira) LIKE '" & ("%" & tabla(n) & "%") & "'"
                Else
                    consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ',rut_cliente_retira, nombre_cliente_retira) LIKE '" & ("%" & tabla(n) & "%") & "'"
                End If
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

            Me.Enabled = True

            If migrilla.Rows.Count > 0 Then
                migrilla.Focus()
            End If
            Exit Sub
        End If
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        buscar()
    End Sub

    Private Sub migrilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles migrilla.CellContentClick

    End Sub

    Private Sub migrilla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles migrilla.DoubleClick
        Dim codigo As String
        If migrilla.Rows.Count < 0 Then
            Me.Close()
            Form_guias_traslado.txt_rut_retira.Focus()
            Me.Close()
        Else
            codigo = migrilla.CurrentRow.Cells(0).Value
            Form_guias_traslado.limpiar_datos_clientes_retira()
            Form_guias_traslado.txt_rut_retira.Text = codigo
            Form_guias_traslado.mostrar_datos_retira()
            Me.Close()
        End If
    End Sub

    Private Sub migrilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles migrilla.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim codigo As String
            If migrilla.Rows.Count < 0 Then
                Me.Close()
                Form_guias_traslado.txt_rut_retira.Focus()
                Me.Close()
            Else
                codigo = migrilla.CurrentRow.Cells(0).Value
                Form_guias_traslado.limpiar_datos_clientes_retira()
                Form_guias_traslado.txt_rut_retira.Text = codigo
                Form_guias_traslado.mostrar_datos_retira()
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
            buscar()
        End If
    End Sub

    Private Sub txt_busqueda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.LostFocus
        txt_busqueda.BackColor = Color.White
    End Sub

    Private Sub txt_busqueda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.GotFocus
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