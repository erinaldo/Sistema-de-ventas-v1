Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_comentario_pedido

    Private Sub Form_comentario_pedido_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_pedidos_revision.Enabled = True
    End Sub

    Private Sub Form_comentario_pedido_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_comentario_pedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click

        Me.Enabled = False

        Dim codigo_pedido As String
        Dim codigo_producto As String
        codigo_pedido = Form_pedidos_revision.grilla_revision_pedidos.CurrentRow.Cells(0).Value
        codigo_producto = Form_pedidos_revision.grilla_revision_pedidos.CurrentRow.Cells(2).Value

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "UPDATE DETALLE_pedido SET comentario='" & (txt_comentario.Text) & "' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO= '" & (codigo_producto) & "' "
        DA.SelectCommand = SC
        DA.Fill(DT)
        conexion.Close()
        Form_pedidos_revision.busqueda()




        'If Form_revision_de_pedidos.Combo_vendedor.Text = "" And Form_revision_de_pedidos.Combo_proveedor.Text = "" And Form_revision_de_pedidos.Combo_prioridad.Text = "" And Form_revision_de_pedidos.txt_codigo_pedido.Text = "" Then
        '    Form_revision_de_pedidos.mostrar_pedidos()
        'End If

        'If Form_revision_de_pedidos.Combo_vendedor.Text <> "" Then
        '    Form_revision_de_pedidos.mostrar_pedidos_por_vendedor()
        'End If
        'If Form_revision_de_pedidos.Combo_proveedor.Text <> "" Then
        '    Form_revision_de_pedidos.mostrar_pedidos_por_proveedor()
        'End If
        'If Form_revision_de_pedidos.Combo_prioridad.Text <> "" Then
        '    Form_revision_de_pedidos.mostrar_pedidos_por_prioridad()
        'End If
        'If Form_revision_de_pedidos.txt_codigo_pedido.Text <> "" Then
        '    Form_revision_de_pedidos.mostrar_pedidos_por_codigo()
        'End If

        Me.Close()
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub PictureBox_logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_logo.Click

    End Sub

    Private Sub txt_comentario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_comentario.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "|" Then
            e.KeyChar = ""
        End If



        If e.KeyChar = "}" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "{" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "<" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ">" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If


    End Sub

    Private Sub txt_comentario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comentario.TextChanged

    End Sub

End Class