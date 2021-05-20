Imports MySql.Data.MySqlClient

Public Class Form_seleccion_imagen_por_codigo

    Private Sub Form_seleccion_imagen_por_codigo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_registro_de_imagenes_de_productos.WindowState = FormWindowState.Normal
        Form_registro_de_imagenes_de_productos.Enabled = True
    End Sub

    Private Sub Form_seleccion_imagen_por_codigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F3 Then
            Dim forms As FormCollection = Application.OpenForms
            Dim i As Integer
            For i = 0 To forms.Count - 1
                Try
                    For Each form As Form In forms
                        If TypeOf form Is Form_menu_principal Then

                        Else
                            form.Close()
                        End If
                    Next
                Catch err As InvalidOperationException
                End Try
            Next i
            form_Ingreso.Show()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_seleccion_imagen_por_codigo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        conexion.Close()
        mostrar_malla()
        grilla_clientes.Focus()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_malla()
        conexion.Close()
        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        conexion.Open()
        SC4.Connection = conexion
        SC4.CommandText = "SELECT COD_AUTO AS ORDEN, productos_imagenes.COD_PRODUCTO AS CODIGO, NOMBRE FROM `casa_bravo_520`.`productos_imagenes`, `casa_bravo_520`.`productos` WHERE productos_imagenes.COD_PRODUCTO=PRODUCTOS.COD_PRODUCTO AND productos_imagenes.COD_PRODUCTO='" & (Form_registro_de_imagenes_de_productos.txt_codigo_producto.Text) & "' ORDER BY productos_imagenes.COD_AUTO;"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)
        grilla_clientes.DataSource = DS4.Tables(DT4.TableName)
        conexion.Close()
    End Sub

    Private Sub grilla_clientes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_clientes.Click
        If grilla_clientes.Rows.Count <> 0 Then
            mostrar_imagen()
        End If
    End Sub

    Private Sub grilla_clientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla_clientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            If grilla_clientes.Rows.Count <= 0 Then
                Me.Close()
                Form_registro_de_imagenes_de_productos.txt_codigo_producto.Focus()
                Me.Close()
            Else
                Form_registro_de_imagenes_de_productos.txt_cod_auto.Text = grilla_clientes.CurrentRow.Cells(0).Value
                Form_registro_de_imagenes_de_productos.txt_codigo_producto.Text = grilla_clientes.CurrentRow.Cells(1).Value
                Form_registro_de_imagenes_de_productos.txt_nombre_producto.Text = grilla_clientes.CurrentRow.Cells(2).Value
                Form_registro_de_imagenes_de_productos.mostrar_imagen()
                Me.Close()
            End If
        End If
    End Sub

    Sub mostrar_imagen()
        conexion.Close()
        Dim cod_auto As String
        cod_auto = grilla_clientes.CurrentRow.Cells(0).Value
        Me.PictureBox1.Image = Nothing
        Try
            Dim Sql As String = "select * from productos_imagenes where cod_auto='" & (cod_auto) & "'"
            Dim lector As MySqlDataReader
            conexion.Close()
            conexion.Open()
            If conexion.State = ConnectionState.Open Then
                Dim Imag As Byte()
                Dim Comando As New MySqlCommand(Sql, conexion)
                lector = Comando.ExecuteReader
                While lector.Read
                    'txt_cod_auto.Text = lector("cod_auto")
                    Imag = lector("imagen_producto")
                    Me.PictureBox1.Image = Bytes_Imagen(Imag)
                End While
            End If
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grilla_clientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_clientes.CellContentClick

    End Sub
End Class