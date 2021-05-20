Public Class Form_venta_multiple
    Private Sub Form_venta_multiple_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 1024
        Me.Height = 728
        Centrar()
    End Sub

    Public Sub Centrar()
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (tamaño.Width - Me.Width) \ 2
        Dim posicionY As Integer = (tamaño.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
    End Sub
End Class