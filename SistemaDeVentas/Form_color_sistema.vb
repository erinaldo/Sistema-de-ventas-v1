Imports System.IO

Public Class Form_color_sistema

    Private Sub Form_color_sistema_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_color_sistema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        '  Me.BackColor = Color.FromArgb(color_fondo)
        ' Me.ForeColor = Color.FromArgb(color_texto)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_gray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gray.Click
        Me.BackColor = Color.Gray
        ' = Me.BackColor.ToArgb()

        Me.BackColor = Color.FromArgb(193, 126, 157)

        ' Me.BackColor = Color.FromArgb("#003399")

        ' Me.BackColor = Color.FromArgb(Right("003399"))

    End Sub

    Private Sub btn_lightskyblue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lightskyblue.Click
        Me.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_Tan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Tan.Click
        Me.BackColor = Color.Tan
    End Sub

    Private Sub btn_ghostwhite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ghostwhite.Click
        Me.BackColor = Color.GhostWhite
    End Sub

    Private Sub btn_pink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pink.Click
        Me.BackColor = Color.Pink
    End Sub

    Private Sub btn_DarkTurquoise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DarkTurquoise.Click
        Me.BackColor = Color.DarkTurquoise
    End Sub

    Private Sub btn_LightGreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LightGreen.Click
        Me.BackColor = Color.LightGreen
    End Sub

    Private Sub btn_gold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gold.Click
        Me.BackColor = Color.Gold
    End Sub

    Private Sub btn_IndianRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_IndianRed.Click
        Me.BackColor = Color.IndianRed
    End Sub

    Private Sub btn_CornflowerBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CornflowerBlue.Click
        Me.BackColor = Color.CornflowerBlue
    End Sub

    Private Sub btn_Yellow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Yellow.Click
        Me.BackColor = Color.Yellow
    End Sub

    Private Sub btn_DarkSeaGreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DarkSeaGreen.Click
        Me.BackColor = Color.DarkSeaGreen
    End Sub

    Private Sub btn_MediumSlateBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MediumSlateBlue.Click
        Me.BackColor = Color.MediumSlateBlue
    End Sub

    Private Sub btn_Beige_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Beige.Click
        Me.BackColor = Color.Beige
    End Sub

    Private Sub btn_Wheat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Wheat.Click
        Me.BackColor = Color.Wheat
    End Sub

    Private Sub btn_DarkOrange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DarkOrange.Click
        Me.BackColor = Color.DarkOrange
    End Sub

    Private Sub btn_MediumSeaGreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MediumSeaGreen.Click
        Me.BackColor = Color.MediumSeaGreen
    End Sub

    Private Sub btn_Silver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Silver.Click
        Me.BackColor = Color.Silver
    End Sub

    Private Sub btn_Maroon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Maroon.Click
        Me.ForeColor = Color.Maroon
    End Sub

    Private Sub btn_black_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_black.Click
        Me.ForeColor = Color.Black
    End Sub

    Private Sub btn_DarkSlateBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DarkSlateBlue.Click
        Me.ForeColor = Color.DarkSlateBlue
    End Sub

    Private Sub btn_MediumBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MediumBlue.Click
        Me.ForeColor = Color.MediumBlue
    End Sub

    Private Sub btn_Indigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Indigo.Click
        Me.ForeColor = Color.Indigo
    End Sub

    Private Sub btn_DarkSlateGray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DarkSlateGray.Click
        Me.ForeColor = Color.DarkSlateGray
    End Sub

    Private Sub btn_SaddleBrown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SaddleBrown.Click
        Me.ForeColor = Color.SaddleBrown
    End Sub

    Private Sub btn_Firebrick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Firebrick.Click
        Me.ForeColor = Color.Firebrick
    End Sub

    Private Sub btn_DarkOliveGreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DarkOliveGreen.Click
        Me.ForeColor = Color.DarkOliveGreen
    End Sub
End Class