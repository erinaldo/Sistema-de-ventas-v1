Public Class Form_forma_de_pago_por_defecto
    Private Sub Form_forma_de_pago_por_defecto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()
        Combo_venta.Text = "BOLETA"
        mostrar_malla_forma_de_pago()
        grilla_forma_de_pago.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
    End Sub

    Private Sub Form_forma_de_pago_por_defecto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_forma_de_pago_por_defecto_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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
        grilla_forma_de_pago.Columns.Add("", "DOCUMENTO")
        grilla_forma_de_pago.Columns.Add("", "FORMA DE PAGO")
        grilla_forma_de_pago.Columns.Add("", "POR DEFECTO")

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from formas_de_pago where tipo_documento= '" & (Combo_venta.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_forma_de_pago.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo_documento"),
                                                  DS.Tables(DT.TableName).Rows(i).Item("forma_de_pago"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("por_defecto"))
                'txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(saldo)
            Next
            grilla_forma_de_pago.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_forma_de_pago.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_forma_de_pago.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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

    Private Sub Combo_venta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_venta.SelectedIndexChanged
        mostrar_malla_forma_de_pago()
    End Sub

    Private Sub btn_agregar_entrada_remuneracion_Click(sender As Object, e As EventArgs) Handles btn_agregar_entrada_remuneracion.Click
        If Combo_venta.Text = "" Then
            MsgBox("CAMPO TIPO DOCUMENTO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_venta.Focus()
            Exit Sub
        End If

        If txt_nombre.Text = "" Then
            MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre.Focus()
            Exit Sub
        End If

        Dim por_defecto As String = "NO"

        If CheckBox1.Checked = True Then
            por_defecto = "SI"
        Else
            por_defecto = "NO"
        End If

        conexion.Close()
        Consultas_SQL("select * from formas_de_pago where tipo_documento= '" & (Combo_venta.Text) & "' and forma_de_pago= '" & (txt_nombre.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count = 0 Then
            If por_defecto = "SI" Then
                SC.Connection = conexion
                SC.CommandText = "Update formas_de_pago Set por_defecto='NO' WHERE tipo_documento= '" & (Combo_venta.Text) & "' and cod_auto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('" & (Combo_venta.Text) & "', '" & (txt_nombre.Text) & "', '" & (por_defecto) & "');"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Else
                SC.Connection = conexion
                SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('" & (Combo_venta.Text) & "', '" & (txt_nombre.Text) & "', '" & (por_defecto) & "');"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        Else

            If por_defecto = "SI" Then
                SC.Connection = conexion
                SC.CommandText = "Update formas_de_pago Set por_defecto='NO' WHERE tipo_documento= '" & (Combo_venta.Text) & "' and cod_auto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "Update formas_de_pago Set por_defecto='" & (por_defecto) & "' WHERE tipo_documento= '" & (Combo_venta.Text) & "' and forma_de_pago='" & (txt_nombre.Text) & "' and cod_auto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Else
                SC.Connection = conexion
                SC.CommandText = "Update formas_de_pago Set por_defecto='" & (por_defecto) & "' WHERE tipo_documento= '" & (Combo_venta.Text) & "' and forma_de_pago='" & (txt_nombre.Text) & "' and cod_auto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
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
            valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR LA FORMA DE PAGO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")


            If valormensaje = vbYes Then
                Dim Var_tipo_documento As String
                Dim Var_forma_de_pago As String

                Var_tipo_documento = grilla_forma_de_pago.CurrentRow.Cells(0).Value
                Var_forma_de_pago = grilla_forma_de_pago.CurrentRow.Cells(1).Value

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM formas_de_pago WHERE tipo_documento='" & (Var_tipo_documento) & "' and forma_de_pago='" & (Var_forma_de_pago) & "' and cod_auto<>'0'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If
            mostrar_malla_forma_de_pago()
        End If

    End Sub

    Private Sub grilla_detalle_cuadratura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla_forma_de_pago.CellContentClick

    End Sub

    Private Sub grilla_detalle_cuadratura_Click(sender As Object, e As EventArgs) Handles grilla_forma_de_pago.Click
        txt_nombre.Text = grilla_forma_de_pago.CurrentRow.Cells(1).Value()
    End Sub
End Class