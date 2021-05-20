Partial Class DS_reporte
    Partial Class DS_reporteDataTable

        Private Sub DS_reporteDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DataColumn1Column.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

End Class
