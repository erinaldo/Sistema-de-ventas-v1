Partial Class DS_cuadratura_fin_de_mes
    Partial Class cuadratura_fin_de_mesDataTable

        Private Sub cuadratura_fin_de_mesDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DataColumn10Column.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

End Class
