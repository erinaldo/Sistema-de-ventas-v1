Imports MySql.Data
Imports MySql.Data.MySqlClient

Module ModuloConeccion
    Friend lector As MySqlDataReader

    Friend conexion As New MySqlConnection
    Friend SC As New MySqlCommand
    Friend DA As New MySqlDataAdapter
    Friend DS As New DataSet()
    Friend DT As New DataTable

    Friend SC1 As New MySqlCommand
    Friend DA1 As New MySqlDataAdapter
    Friend DS1 As New DataSet()
    Friend DT1 As New DataTable

    Friend SC2 As New MySqlCommand
    Friend DA2 As New MySqlDataAdapter
    Friend DS2 As New DataSet()
    Friend DT2 As New DataTable

    Friend SC3 As New MySqlCommand
    Friend DA3 As New MySqlDataAdapter
    Friend DS3 As New DataSet()
    Friend DT3 As New DataTable

    Friend SC4 As New MySqlCommand
    Friend DA4 As New MySqlDataAdapter
    Friend DS4 As New DataSet()
    Friend DT4 As New DataTable

    Friend SC5 As New MySqlCommand
    Friend DA5 As New MySqlDataAdapter
    Friend DS5 As New DataSet()
    Friend DT5 As New DataTable

    Sub limpiarDS()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
    End Sub

    Sub LimpiarDS2()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
    End Sub

    Sub LimpiarDS3()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
    End Sub

    Sub limpiarDS4()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
    End Sub
End Module
