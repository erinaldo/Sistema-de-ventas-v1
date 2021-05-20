Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_pedidos_proveedor

    Private Sub Form_pedidos_proveedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_pedidos_revision.WindowState = FormWindowState.Normal
        Form_pedidos_revision.Enabled = True
    End Sub

    Private Sub Form_pedidos_proveedor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_pedidos_proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenar_combo_proveedores_mas_pedidos()
        Combo_proveedor.SelectedItem = ("-")
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub
    Sub llenar_combo_proveedores_mas_pedidos()
        Combo_proveedor.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from proveedores_Mas_pedidos order by nombre_proveedor"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        Combo_proveedor.Items.Add("-")

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_proveedor"))
            Next
            Combo_proveedor.Items.Add("OTROS")
        End If
        conexion.Close()
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub


    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If Combo_proveedor.Text = "" Then
            MsgBox("CAMPO PROVEEDOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_proveedor.Text = "-" Then
            MsgBox("CAMPO PROVEEDOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Form_pedidos_revision.grilla_revision_pedidos.Rows.Count = 0 Then
            Exit Sub
        End If

        'If Form_pedidos_revision.grilla_revision_pedidos.CurrentRow.Cells(2).Selected Then
        '    Exit Sub
        'End If

        Dim codigo_pedido As String
        Dim codigo_producto As String

        codigo_pedido = Form_pedidos_revision.grilla_revision_pedidos.CurrentRow.Cells(0).Value
        codigo_producto = Form_pedidos_revision.grilla_revision_pedidos.CurrentRow.Cells(2).Value


        SC.Connection = conexion
        SC.CommandText = "UPDATE DETALLE_pedido SET PROVEEDOR='" & (Combo_proveedor.Text) & "' WHERE codigo_pedido= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        Form_pedidos_revision.busqueda()

        Me.Close()

    End Sub
End Class