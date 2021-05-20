Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_mensaje_clientes

    Private Sub Form_mensaje_clientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_venta.Enabled = True
        Form_venta.txt_rut_retira.Focus()
    End Sub

    Private Sub Form_mensaje_clientes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_mensaje_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mostrar_datos_clientes()
        cargar_logo()
    End Sub

    Sub mostrar_datos_clientes()
        conexion.Close()
        If Form_venta.txt_rut_cliente.Text <> "" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select mensaje from clientes where cod_cliente ='" & (Form_venta.txt_cod_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            ' If DS.Tables(DT.TableName).Rows.Count > 0 Then
            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                lbl_mensaje.Text = DS.Tables(DT.TableName).Rows(0).Item("mensaje")

            End If
        End If
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
End Class