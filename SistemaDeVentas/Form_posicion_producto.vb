Imports System.IO
Public Class Form_posicion_producto

    Private Sub btn_agregar_entrada_remuneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.Click

        If txt_codigo.Text = "" Then
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo.Focus()
            Exit Sub
        End If

        If txt_posicion.Text = "" Then
            MsgBox("CAMPO POSICION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_posicion.Focus()
            Exit Sub
        End If





        Dim codigo As String
        Dim posicion As String


        For i = 0 To grilla_impuesto_unico.Rows.Count - 1
            codigo = grilla_impuesto_unico.Rows(i).Cells(0).Value.ToString
            posicion = grilla_impuesto_unico.Rows(i).Cells(1).Value.ToString


            If codigo = txt_codigo.Text And posicion = txt_posicion.Text Then
                grilla_impuesto_unico.Rows.Remove(grilla_impuesto_unico.Rows(i))
                Exit For
            End If
        Next



        grilla_impuesto_unico.Rows.Add(txt_codigo.Text, txt_posicion.Text)



        SC3.Connection = conexion
        SC3.CommandText = "delete from posicion_producto where codigo_producto='" & (txt_codigo.Text) & "' and posicion='" & (txt_posicion.Text) & "' "
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)


        SC3.Connection = conexion
        SC3.CommandText = "insert into posicion_producto (codigo_producto, posicion, usuario_responsable) values('" & (txt_codigo.Text) & "','" & (txt_posicion.Text) & "','" & (miusuario) & "')"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)


        txt_posicion.Text = ""
        txt_posicion.Focus()

    End Sub

    Private Sub btn_quitar_entrada_remuneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.Click

        Dim codigo As String
        Dim posicion As String

        codigo = grilla_impuesto_unico.CurrentRow.Cells(0).Value
        posicion = grilla_impuesto_unico.CurrentRow.Cells(1).Value

        SC3.Connection = conexion
        SC3.CommandText = "delete from posicion_producto where codigo_producto='" & (codigo) & "' and posicion='" & (posicion) & "'"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)

        If grilla_impuesto_unico.Rows.Count > 0 Then
            grilla_impuesto_unico.Rows.Remove(grilla_impuesto_unico.CurrentRow)
        End If

    End Sub

    Private Sub Form_posicion_producto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        form_registro_productos.WindowState = FormWindowState.Normal
        form_registro_productos.Enabled = True
    End Sub

    Private Sub Form_posicion_producto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_posicion_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()


        txt_codigo.Text = form_registro_productos.txt_codigo.Text
        cargar_impuesto_unico()

        'dtp_mes.CustomFormat = "MM-yyy"
        grilla_impuesto_unico.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub


    Sub cargar_impuesto_unico()
        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        SC4.Connection = conexion
        SC4.CommandText = "select codigo_producto, posicion from posicion_producto where codigo_producto='" & (txt_codigo.Text) & "'"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)
        grilla_impuesto_unico.Rows.Clear()
        grilla_impuesto_unico.Columns.Clear()
        grilla_impuesto_unico.Columns.Add("codigo_producto", "CODIGO")
        grilla_impuesto_unico.Columns.Add("posicion", "POSICION")


        ' grilla_remuneracion.Columns(2).Visible = False

        If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
            For i = 0 To DS4.Tables(DT4.TableName).Rows.Count - 1
                grilla_impuesto_unico.Rows.Add(DS4.Tables(DT4.TableName).Rows(i).Item("codigo_producto"), _
                                                DS4.Tables(DT4.TableName).Rows(i).Item("posicion"))
            Next
        End If
        conexion.Close()

        'grilla_impuesto_unico.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_impuesto_unico.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_impuesto_unico.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_impuesto_unico.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub txt_posicion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_posicion.GotFocus
        color_foco()
    End Sub

    Private Sub txt_posicion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_posicion.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

    Private Sub txt_posicion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_posicion.TextChanged

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

    Private Sub btn_agregar_entrada_remuneracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.GotFocus
        color_foco()
    End Sub

    Private Sub btn_quitar_entrada_remuneracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub
End Class