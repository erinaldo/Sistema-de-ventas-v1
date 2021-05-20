Public Class Barra_lateral_derecha
    Private Sub Barra_lateral_derecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 1
        Me.Dock = DockStyle.Right
        CambiaColorFondo(Me, mirutempresa)

    End Sub
End Class
