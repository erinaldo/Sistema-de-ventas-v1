Public Class Form_edicion_de_impresion
    Dim xR As Integer
    Dim yR As Integer
    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        xR = e.X
        yR = e.Y
    End Sub
    Private Sub Button1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Button1.Location = New Point(Button1.Left + e.X - xR, Button1.Top + e.Y - yR)
        End If
    End Sub
    Private Sub CheckBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CheckBox1.MouseDown
        xR = e.X
        yR = e.Y
    End Sub
    Private Sub CheckBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CheckBox1.MouseMove
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            CheckBox1.Location = New Point(CheckBox1.Left + e.X - xR, CheckBox1.Top + e.Y - yR)
        End If
    End Sub
    Private Sub ComboBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox1.MouseDown
        xR = e.X
        yR = e.Y
    End Sub
    Private Sub ComboBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox1.MouseMove
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            ComboBox1.Location = New Point(ComboBox1.Left + e.X - xR, ComboBox1.Top + e.Y - yR)
        End If
    End Sub
    Private Sub Label1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Label1.Location = New Point(Label1.Left + e.X - xR, Label1.Top + e.Y - yR)
        End If
    End Sub
    Private Sub Label1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        xR = e.X
        yR = e.Y
    End Sub
    Private Sub Form_edicion_de_impresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class