Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Imports System.Resources
Imports System.Deployment.Application


Public Class Form_caja_dos

    Dim mifecha2 As String
    Dim mifecha4 As String

    Dim tipo_impresion As String


    Dim BOLETAs_nulas As String
    Dim guias_nulas As String
    Dim facturas_nulas As String
    Dim nota_credito_nulas As String
    Dim nota_debito_nulas As String
    Dim abono_nulos As String
    Dim message As New MailMessage
    Dim smtp As New SmtpClient
    Dim nombre_archivo As String

    Private Sub Form_caja_dos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_caja_registradora.Visible = False Then
            Form_menu_principal.WindowState = FormWindowState.Normal
        Else
            Form_caja_registradora.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form_caja_dos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_caja_dos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

    End Sub


   





End Class