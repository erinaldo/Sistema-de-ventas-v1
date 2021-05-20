Public Class Barra_pie
    Private Sub Barra_pie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Bottom
        CambiaColorFondo(Me, mirutempresa)
    End Sub
End Class
