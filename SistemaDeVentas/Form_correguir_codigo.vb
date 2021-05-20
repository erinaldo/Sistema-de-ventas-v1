Imports System.IO
Imports System.Drawing.Drawing2D
Public Class Form_CORREGIR_codigo

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Form_CORREGIR_codigo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_CORREGIR_codigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_CORREGIR_codigo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub


    Sub mostrar_datos_producto()
        If txt_codigo_erroneo.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_erroneo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
            End If

            conexion.Close()
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If txt_codigo_erroneo.Text = "" Then
            MsgBox("CAMPO CODIGO ERRONEO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_codigo_erroneo.Focus()
            Exit Sub
        End If

        If txt_nombre_producto.Text = "" Then
            MsgBox("CAMPO NOMBRE PRODUCTO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre_producto.Focus()
            Exit Sub
        End If

        If txt_codigo_correguido.Text = "" Then
            MsgBox("CAMPO CODIGO CORREGUIDO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_codigo_correguido.Focus()
            Exit Sub
        End If

        SC.Connection = conexion
        SC.CommandText = "UPDATE productos SET cod_producto='" & (txt_codigo_correguido.Text) & "' WHERE cod_producto = '" & (txt_codigo_erroneo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE detalle_boleta SET cod_producto='" & (txt_codigo_correguido.Text) & "' WHERE cod_producto = '" & (txt_codigo_erroneo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE detalle_compra SET cod_producto='" & (txt_codigo_correguido.Text) & "' WHERE cod_producto = '" & (txt_codigo_erroneo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE detalle_guia SET cod_producto='" & (txt_codigo_correguido.Text) & "' WHERE cod_producto = '" & (txt_codigo_erroneo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE detalle_total SET cod_producto='" & (txt_codigo_correguido.Text) & "' WHERE cod_producto = '" & (txt_codigo_erroneo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE detalle_factura SET cod_producto='" & (txt_codigo_correguido.Text) & "' WHERE cod_producto = '" & (txt_codigo_erroneo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

        txt_codigo_correguido.Text = Val(txt_codigo_correguido.Text) + 1
        txt_nombre_producto.Text = ""
        txt_codigo_erroneo.Text = ""
        txt_codigo_erroneo.Focus()
    End Sub

    Private Sub txt_codigo_erroneo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_erroneo.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        txt_nombre_producto.Text = ""

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

        'If e.KeyChar = "*" Then
        '    e.KeyChar = ""
        'End If

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

            mostrar_datos_producto()
            txt_codigo_correguido.Focus()

        End If


    End Sub

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

    Private Sub txt_codigo_correguido_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_correguido.GotFocus
        txt_codigo_correguido.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_correguido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_correguido.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_codigo_correguido_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_correguido.LostFocus
        txt_codigo_correguido.BackColor = Color.White
    End Sub

    Private Sub txt_codigo_erroneo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_erroneo.GotFocus
        txt_codigo_erroneo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_erroneo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_erroneo.LostFocus
        txt_codigo_erroneo.BackColor = Color.White
    End Sub

    Private Sub txt_codigo_erroneo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_erroneo.TextChanged

    End Sub

    Private Sub txt_codigo_correguido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_correguido.TextChanged

    End Sub
End Class