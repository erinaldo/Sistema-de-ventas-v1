Public Class UC_clientes
    Private Sub btn_buscar_productos_Click(sender As Object, e As EventArgs)
        Me.Enabled = False
        conexion.Close()
        txt_codigo.Focus()
        Form_buscador_productos_ventas.Show()
    End Sub
End Class
