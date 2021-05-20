Imports System.IO

Public Class Form_comentario_ventas_lubricentro

    Private Sub Form_comentario_ventas_lubricentro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_ventas_lubricentro.Enabled = True
    End Sub

    Private Sub Form_comentario_ventas_lubricentro_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_comentario_ventas_lubricentro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        mostrar_datos_comentario()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
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

            If TypeOf controlcito Is Panel Then
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


            If TypeOf controlcito Is Panel Then
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





    Sub mostrar_datos_comentario()
        If Form_ventas_lubricentro.txt_cod_auto_servicio.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select comentario from servicios_lubricentro where cod_auto ='" & (Form_ventas_lubricentro.txt_cod_auto_servicio.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_comentario.Text = DS.Tables(DT.TableName).Rows(0).Item("comentario")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If txt_comentario.Text = "" Then
            MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_comentario.Focus()
            Exit Sub
        End If




        Me.Enabled = False

   

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "UPDATE servicios_lubricentro SET comentario='" & (txt_comentario.Text) & "' WHERE COD_AUTO= '" & (Form_ventas_lubricentro.txt_cod_auto_servicio.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        conexion.Close()

        Form_ventas_lubricentro.mostrar_malla()


        Me.Close()
    End Sub

    Private Sub txt_comentario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_comentario.GotFocus
        color_foco()
    End Sub

    Private Sub txt_comentario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_comentario.KeyPress
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
   
            btn_grabar.Focus()

        End If
    End Sub

    Private Sub txt_comentario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comentario.TextChanged

    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        color_foco()
    End Sub
End Class