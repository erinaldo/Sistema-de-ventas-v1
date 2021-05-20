Public Class Form_registro_de_actualizaciones

    Private Sub Form_registro_de_actualizaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_registro_de_actualizaciones_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_registro_de_actualizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        SC.CommandText = "select * from detalle_de_actualizaciones group by mensaje order by version desc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim MiFechaEmision As String
                Dim MiFechaActualizacion As Date

                MiFechaActualizacion = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                MiFechaEmision = MiFechaActualizacion.ToString("dd-MM-yyy")

                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("version"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("mensaje"), _
                                                   MiFechaEmision)
            Next

            grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 130 Then
                grilla_estado_de_cuenta.Columns(0).Width = 129
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 130
            End If

            grilla_estado_de_cuenta.Columns(1).Width = 1500
            grilla_estado_de_cuenta.Columns(2).Width = 100

        End If

    End Sub

End Class