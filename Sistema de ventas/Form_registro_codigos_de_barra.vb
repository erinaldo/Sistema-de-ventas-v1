Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_registro_codigos_de_barra

    Private Sub Form_registro_codigos_de_barra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_registro_codigos_de_barra_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_registro_codigos_de_barra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        controles(False, True)
        ' btn_nuevo.PerformClick()

        grilla_estado_de_cuenta.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_datos_productos()

        If txt_codigo.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                '  txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_codigo_barra.Focus()
            Else
                MsgBox("CODIGO NO EXISTENTE", 0 + 16, "ERROR")
                conexion.Close()
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
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


        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            mostrar_datos_productos()
            mostrar_malla()
            txt_codigo.Enabled = False
            '    txt_nombre.Enabled = True
            txt_codigo_barra.Enabled = True



            btn_agregar.Enabled = True
            btn_quitar_elemento.Enabled = True
            grilla_estado_de_cuenta.Enabled = True


            txt_codigo_barra.Focus()
        End If

    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        controles(True, False)
        VarSeleccionproducto = 2
        '{ limpiar_producto()
        txt_codigo.Enabled = True
        txt_nombre.Enabled = False
        txt_codigo_barra.Enabled = False
        txt_codigo.Focus()
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        'btn_imprimir.Enabled = b
        'btn_eliminar.Enabled = b
        'btn_modificar.Enabled = b

        btn_cancelar.Enabled = a

        txt_codigo.Enabled = a
        btn_guardar.Enabled = a
        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a
        grilla_estado_de_cuenta.Enabled = a

        txt_codigo_barra.Enabled = a
        'Combo_marca_automovil.Enabled = a



        If txt_codigo.Enabled = True Then
            txt_codigo.BackColor = Color.White
        Else
            txt_codigo.BackColor = SystemColors.Control
        End If

        If txt_codigo_barra.Enabled = True Then
            txt_codigo_barra.BackColor = Color.White
        Else
            txt_codigo_barra.BackColor = SystemColors.Control
        End If

    End Sub

    Sub limpiar()
        txt_codigo.Text = ""
        txt_nombre.Text = ""

        txt_codigo_barra.Text = ""
        grilla_estado_de_cuenta.Rows.Clear()
        ' txt_modelo_auto.Text = ""
        ' Combo_marca_automovil.Text = ""
        '  combo_familia.Items.Clear()
        'grilla_producto.Rows.Clear()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If txt_nombre.Text = "" Then
            txt_nombre.Focus()
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_codigo.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If txt_codigo_barra.Text = "" Then
        '    txt_codigo_barra.Focus()
        '    MsgBox("CAMPO CODIGO DE BARRA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If



        'If grilla_estado_de_cuenta.Rows.Count = 0 Then
        '    MsgBox("CAMPO CODIGO DE BARRA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    txt_codigo_barra.Focus()
        '    Exit Sub
        'End If


        SC.Connection = conexion
        SC.CommandText = "DELETE FROM codigos_de_barra WHERE codigo_interno='" & (txt_codigo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        Dim VarCodBarra As String

        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

            VarCodBarra = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO codigos_de_barra(codigo_barra, codigo_interno, fecha_modificacion) VALUES ('" & (VarCodBarra) & "','" & (txt_codigo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

        Next

        controles(False, True)
        limpiar()

        MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")


    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
        controles(True, False)

        txt_codigo_barra.Enabled = False

        txt_codigo.Focus()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        limpiar()
        btn_nuevo.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_ultimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_ultimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_modificar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_modificar.BackColor = Color.Transparent
    'End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub

    Private Sub txt_codigo_barra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_barra.GotFocus
        txt_codigo_barra.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_barra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_barra.KeyPress
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


    End Sub

    Private Sub txt_codigo_barra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_barra.LostFocus
        txt_codigo_barra.BackColor = Color.White
    End Sub

    Private Sub txt_codigo_barra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_barra.TextChanged

    End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre.KeyPress
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


    End Sub



    Sub mostrar_malla()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from codigos_de_barra  where codigo_interno = '" & (txt_codigo.Text) & "'"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_estado_de_cuenta.Rows.Clear()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_barra"))
            Next

        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then

            'If grilla_estado_de_cuenta.Columns(0).Width = 489 Then
            '    grilla_estado_de_cuenta.Columns(0).Width = 149
            'Else
            '    grilla_estado_de_cuenta.Columns(0).Width = 150
            'End If

            If grilla_estado_de_cuenta.Width = 489 Then
                grilla_estado_de_cuenta.Width = 488
            Else
                grilla_estado_de_cuenta.Width = 489
            End If

        End If
    End Sub

    Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre.TextChanged

    End Sub


    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_estado_de_cuenta.Rows.Count > 0 Then
            grilla_estado_de_cuenta.Rows.Remove(grilla_estado_de_cuenta.CurrentRow)
            txt_codigo_barra.Focus()
        End If
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click

        If txt_nombre.Text = "" Then
            txt_nombre.Focus()
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_codigo.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If txt_codigo_barra.Text = "" Then
        '    txt_codigo_barra.Focus()
        '    MsgBox("CAMPO CODIGO DE BARRA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If


        If txt_codigo_barra.Text = "" Then
            MsgBox("VERIFIQUE EL CODIGO INGRESADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo_barra.Focus()
            Exit Sub
        End If

        grilla_estado_de_cuenta.Rows.Add(txt_codigo_barra.Text)

    End Sub





    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub

End Class