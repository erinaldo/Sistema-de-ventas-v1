Imports System.IO

Public Class Form_crear_campo_busqueda

    Private Sub Form_crear_campo_busqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        busqueda()
    End Sub

    Sub busqueda()
        grilla_bucador_productos.DataSource = Nothing

        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION' FROM productos"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_bucador_productos.DataSource = DS.Tables(DT.TableName)
        conexion.Close()
    End Sub

    Sub grabar_detalle()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarAplicacion As String
        Dim detalle_busqueda As String

        For i = 0 To grilla_bucador_productos.Rows.Count - 1
            VarCodProducto = grilla_bucador_productos.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_bucador_productos.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_bucador_productos.Rows(i).Cells(2).Value.ToString
            VarAplicacion = grilla_bucador_productos.Rows(i).Cells(3).Value.ToString
            detalle_busqueda = varnombre & " " & vartecnico & " " & VarAplicacion

            DS1.Tables.Clear()
            DT1.Rows.Clear()
            DT1.Columns.Clear()
            DS1.Clear()
            conexion.Open()

            SC1.Connection = conexion

            SC1.CommandText = "UPDATE productos SET detalle_busqueda='" & (detalle_busqueda) & "' WHERE cod_producto = " & (VarCodProducto) & ""

            DA1.SelectCommand = SC1
            DA1.Fill(DT1)
            conexion.Close()
        Next
        MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        grabar_detalle()
    End Sub
End Class