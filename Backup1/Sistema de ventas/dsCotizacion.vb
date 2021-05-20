Partial Class dsCotizacion
    Partial Class CotizacionDataTable

        Private Sub CotizacionDataTable_CotizacionRowChanging(ByVal sender As System.Object, ByVal e As CotizacionRowChangeEvent) Handles Me.CotizacionRowChanging

        End Sub



        Private Sub CotizacionDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.porcentaje_descColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

End Class
