Public Class Form_asociar_clientes_a_empresas_eliminados

    Private Sub Form_asociar_clientes_a_empresas_eliminados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_asociar_clientes_a_empresas.WindowState = FormWindowState.Normal
        Form_asociar_clientes_a_empresas.Enabled = True
    End Sub

    Private Sub Form_asociar_clientes_a_empresas_eliminados_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_asociar_clientes_a_empresas_eliminados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        mostrar_malla()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_malla()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from clientes_que_retiran_por_empresas_eliminados where codigo_empresa='" & (Form_asociar_clientes_a_empresas.txt_codigo_empresa.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("", "CODIGO")
        grilla_libro_compras.Columns.Add("", "NOMBRE")
        grilla_libro_compras.Columns.Add("", "NRO. TECNICO")
        grilla_libro_compras.Columns.Add("", "APLICACION")
        grilla_libro_compras.Columns.Add("", "FAMILIA")
        grilla_libro_compras.Columns.Add("", "COSTO")
        grilla_libro_compras.Columns.Add("", "PRECIO")
        grilla_libro_compras.Columns.Add("", "CANTIDAD")
        grilla_libro_compras.Columns.Add("", "TOTAL")
        grilla_libro_compras.Columns.Add("", "ULT. COMP.")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("nombre_familia"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("costo"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("precio"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      Int(DS.Tables(DT.TableName).Rows(i).Item("costo")) * Int(DS.Tables(DT.TableName).Rows(i).Item("cantidad")), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("ultima_compra"))
            Next
        End If

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
            grilla_libro_compras.Columns(1).Width = 150
            grilla_libro_compras.Columns(2).Width = 136
            grilla_libro_compras.Columns(3).Width = 100
            grilla_libro_compras.Columns(4).Width = 100
            grilla_libro_compras.Columns(5).Width = 100
            grilla_libro_compras.Columns(6).Width = 100
            grilla_libro_compras.Columns(7).Width = 100
            grilla_libro_compras.Columns(8).Width = 100
            grilla_libro_compras.Columns(9).Width = 100
            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

End Class