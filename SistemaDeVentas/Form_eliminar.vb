Public Class Form_eliminar

    Private Sub Form_eliminar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_consultas.Enabled = True
        Form_consultas.CONSULTAR()
    End Sub

    Private Sub Form_eliminar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Form_eliminar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  
        mostrar_malla()
    End Sub

    Private Sub grilla_eliminar_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_eliminar.CellContentClick

    End Sub

    Private Sub grilla_eliminar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_eliminar.DoubleClick
        Dim codigo As String

        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR LA CUENTA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            codigo = grilla_eliminar.CurrentRow.Cells(0).Value

            SC3.Connection = conexion
            SC3.CommandText = "DELETE FROM clientes WHERE `cod_cliente`='" & (codigo) & " '"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)

            mostrar_malla()


        End If

    End Sub



    Sub mostrar_malla()
        Dim rut As String

        rut = Form_consultas.grilla_documento.CurrentRow.Cells(0).Value

        conexion.Close()
        Dim DT3 As New DataTable
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from clientes where rut_cliente='" & (rut) & "'"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)

        DS3.Tables.Add(DT3)
        grilla_eliminar.DataSource = DS3.Tables(DT3.TableName)
        conexion.Close()
    End Sub
End Class