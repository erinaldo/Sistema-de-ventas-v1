Public Class Form_documentos_abono

    Private Sub Form_documentos_abono_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_historico_cuentas_corrientes.WindowState = FormWindowState.Maximized
        Form_historico_cuentas_corrientes.Enabled = True
    End Sub

    Private Sub Form_documentos_abono_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_documentos_abono_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        cargar_documentos()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub cargar_documentos()
        Dim codigo As String

        codigo = Form_historico_cuentas_corrientes.grilla_abonos.CurrentRow.Cells(1).Value

        grilla_abono.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from `detalle_abono` WHERE NRO_ABONO= '" & (codigo) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                'Dim MiFechaEmision As Date
                'MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                'mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                grilla_abono.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo_documento"), _
                                       DS.Tables(DT.TableName).Rows(i).Item("nro_documento"), _
                                        DS.Tables(DT.TableName).Rows(i).Item("monto_abono"))
            Next
        End If
    End Sub
End Class