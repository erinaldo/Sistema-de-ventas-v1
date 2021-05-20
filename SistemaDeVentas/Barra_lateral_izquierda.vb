Imports System.Runtime.InteropServices

Public Class Barra_lateral_izquierda
    Private Sub Barra_lateral_izquierda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Width = 1
        Me.Dock = DockStyle.Left
        CambiaColorFondo(Me, mirutempresa)

    End Sub


#Region "Drag Form - Arrastrar/ mover Formulario"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub Barra_lateral_izquierda_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        ReleaseCapture()
        SendMessage(Me.ParentForm.Handle, &H112&, &HF012&, 0)
    End Sub




    'Private Sub titleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles titleBar.MouseDown
    '    ReleaseCapture()
    '    SendMessage(Me.Handle, &H112&, &HF012&, 0)
    'End Sub
#End Region
End Class
