Imports System.Runtime.InteropServices

Public Class Barra_titulo

    Private Sub Barra_titulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Dock = DockStyle.Top
        Me.TabStop = False

        If Me.ParentForm.Name <> "Form_menu_principal" Then
            'CambiaColorFondo(lbl_titulo, mirutempresa)
            CambiaColorFondo(btn_minimize, mirutempresa)
            CambiaColorFondo(btn_close, mirutempresa)
            CambiaColorFondo(Me, mirutempresa)
        End If

        'lbl_titulo.Text = Me.ParentForm.Text
        lbl_titulo.Text = StrConv(Me.ParentForm.Text, vbProperCase)
    End Sub

    Private Sub btn_minimize_Click(sender As Object, e As EventArgs) Handles btn_minimize.Click
        Me.ParentForm.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.ParentForm.Close()
    End Sub

    Private Sub btn_close_MouseMove(sender As Object, e As MouseEventArgs) Handles btn_close.MouseMove
        '    'EN EL FOCO
        btn_close.BackColor = Color.DarkRed
    End Sub

    Private Sub btn_close_MouseLeave(sender As Object, e As EventArgs) Handles btn_close.MouseLeave
        '    'DESPUES DEL FOCO
        If Me.ParentForm.Name <> "Form_menu_principal" Then
            CambiaColorFondo(btn_close, mirutempresa)
        Else
            btn_close.BackColor = SystemColors.WindowFrame
        End If
    End Sub

#Region "Drag Form - Arrastrar/ mover Formulario"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub Barra_titulo_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        ReleaseCapture()
        SendMessage(Me.ParentForm.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub lbl_titulo_Click(sender As Object, e As EventArgs) Handles lbl_titulo.Click
        ReleaseCapture()
        SendMessage(Me.ParentForm.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub lbl_titulo_MouseDown(sender As Object, e As MouseEventArgs) Handles lbl_titulo.MouseDown

    End Sub

    'Private Sub titleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles titleBar.MouseDown
    '    ReleaseCapture()
    '    SendMessage(Me.Handle, &H112&, &HF012&, 0)
    'End Sub
#End Region

End Class
