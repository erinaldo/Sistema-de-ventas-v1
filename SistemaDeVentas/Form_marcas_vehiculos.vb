Public Class Form_marcas_vehiculos
    Private Sub Form_marcas_vehiculos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()
        mostrar_malla_forma_de_pago()
        grilla_forma_de_pago.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
    End Sub

    Private Sub Form_marcas_vehiculos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_marcas_vehiculos_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_malla_forma_de_pago()

        grilla_forma_de_pago.Rows.Clear()
        grilla_forma_de_pago.Columns.Clear()
        grilla_forma_de_pago.Columns.Add("", "MARCA")

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from marcas_vehiculos order by nombre_marca "
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_forma_de_pago.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nombre_marca"))
                'txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(saldo)
            Next
            'grilla_forma_de_pago.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        'If grilla_detalle_cuadratura.Rows.Count <> 0 Then
        '    If grilla_detalle_cuadratura.Columns(0).Width = 80 Then
        '        grilla_detalle_cuadratura.Columns(0).Width = 79
        '    Else
        '        grilla_detalle_cuadratura.Columns(0).Width = 80
        '    End If
        '    grilla_detalle_cuadratura.Columns(2).Width = 80
        '    grilla_detalle_cuadratura.Columns(3).Width = 150
        'End If
    End Sub

    Private Sub Combo_venta_SelectedIndexChanged(sender As Object, e As EventArgs)
        mostrar_malla_forma_de_pago()
    End Sub

    Private Sub btn_agregar_entrada_remuneracion_Click(sender As Object, e As EventArgs) Handles btn_agregar_entrada_remuneracion.Click

        If txt_nombre.Text = "" Then
            MsgBox("CAMPO NOMBRE MARCA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre.Focus()
            Exit Sub
        End If


        conexion.Close()
        Consultas_SQL("select * from marcas_vehiculos where nombre_marca= '" & (txt_nombre.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count = 0 Then

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO `marcas_vehiculos` (`nombre_marca`) VALUES ('" & (txt_nombre.Text) & "');"
            DA.SelectCommand = SC
            DA.Fill(DT)

        End If

        mostrar_malla_forma_de_pago()
        txt_nombre.Text = ""
    End Sub

    Private Sub txt_nombre_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre.TextChanged

    End Sub

    Private Sub txt_nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nombre.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

        If e.KeyChar = "¿" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "?" Then
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

    Private Sub btn_quitar_entrada_remuneracion_Click(sender As Object, e As EventArgs) Handles btn_quitar_entrada_remuneracion.Click
        'Dim VarEstado As String
        If grilla_forma_de_pago.Rows.Count > 0 Then

            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR LA MARCA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")


            If valormensaje = vbYes Then
                Dim Var_marca As String

                Var_marca = grilla_forma_de_pago.CurrentRow.Cells(0).Value

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM marcas_vehiculos WHERE nombre_marca='" & (Var_marca) & "' and cod_auto<>'0'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If
            mostrar_malla_forma_de_pago()
        End If

    End Sub

    Private Sub grilla_detalle_cuadratura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla_forma_de_pago.CellContentClick

    End Sub

    Private Sub grilla_detalle_cuadratura_Click(sender As Object, e As EventArgs) Handles grilla_forma_de_pago.Click
        txt_nombre.Text = grilla_forma_de_pago.CurrentRow.Cells(0).Value()
    End Sub
End Class