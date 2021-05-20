Public Class Form_buscar_documento_de_cambio_de_producto

    Private Sub Form_buscar_documento_de_cambio_de_producto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_buscar_documento_de_cambio_de_producto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
            mostrar_cierre_sistema()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_buscar_documento_de_cambio_de_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        Combo_documento.Text = "VALE DE CAMBIO"

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_malla()
        If Combo_documento.Text = "VALE DE CAMBIO" Then
            grilla_estado_de_cuenta.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from saldo_a_favor where doc_referencia='VALE DE CAMBIO' and nro_referencia = '" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_saldo")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                    grilla_estado_de_cuenta.Rows.Add("SALDO A FAVOR", _
                                                      DS.Tables(DT.TableName).Rows(i).Item("nro_saldo"), _
                                                       mifecha_emision2)
                    'txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(saldo)
                Next
                grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_estado_de_cuenta.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 170 Then
                grilla_estado_de_cuenta.Columns(0).Width = 169
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 170
            End If
        End If
    End Sub

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.Click
        If Combo_documento.Text = "-" Then
            MsgBox("CAMPO TIPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_documento.Focus()
            Exit Sub
        End If

        If txt_rut_cliente.Text = "" Then
            MsgBox("CAMPO NUMERO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        mostrar_malla()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub Combo_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_documento.SelectedIndexChanged
        txt_rut_cliente.Focus()
    End Sub
End Class