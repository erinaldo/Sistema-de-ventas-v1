Public Class Form_proveedores_contactos
    Private Sub Form_proveedores_contactos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()
        txt_rut.Focus()
        mostrar_malla_forma_de_pago()
        grilla_contactos.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
    End Sub

    Private Sub Form_proveedores_contactos_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

        grilla_contactos.Rows.Clear()
        grilla_contactos.Columns.Clear()
        grilla_contactos.Columns.Add("", "CODIGO")
        grilla_contactos.Columns.Add("", "NOMBRE")
        grilla_contactos.Columns.Add("", "MAIL")
        grilla_contactos.Columns.Add("", "TELEFONO")
        grilla_contactos.Columns.Add("", "POR DEFECTO")

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from proveedores_contactos where rut_proveedor= '" & (txt_rut.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_contactos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"),
                                           DS.Tables(DT.TableName).Rows(i).Item("nombre_contacto"),
                                            DS.Tables(DT.TableName).Rows(i).Item("mail_contacto"),
                                             DS.Tables(DT.TableName).Rows(i).Item("telefono_contacto"),
                                              DS.Tables(DT.TableName).Rows(i).Item("por_defecto"))
            Next
            grilla_contactos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_contactos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_contactos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_contactos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_contactos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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

    Private Sub btn_agregar_entrada_remuneracion_Click(sender As Object, e As EventArgs)
        If txt_nombre_contacto.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre_contacto.Focus()
            Exit Sub
        End If

        If txt_mail_contacto.Text = "" Then
            MsgBox("CAMPO MAIL VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_mail_contacto.Focus()
            Exit Sub
        End If

        If txt_telefono_contacto.Text = "" Then
            MsgBox("CAMPO TELEFONO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_telefono_contacto.Focus()
            Exit Sub
        End If
        Dim por_defecto As String = "NO"

        If CheckBox1.Checked = True Then
            por_defecto = "SI"
        Else
            por_defecto = "NO"
        End If


        If por_defecto = "SI" Then
            SC.Connection = conexion
            SC.CommandText = "Update proveedores_contactos Set por_defecto='NO' WHERE rut_proveedor= '" & (txt_rut.Text) & "' and cod_auto <> '0';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO `proveedores_contactos` (`rut_proveedor`, `nombre_contacto`, `mail_contacto`, `telefono_contacto`, `por_defecto`) VALUES ('" & (txt_rut.Text) & "', '" & (txt_nombre_contacto.Text) & "', '" & (txt_mail_contacto.Text) & "', '" & (txt_telefono_contacto.Text) & "', '" & (por_defecto) & "');"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "INSERT INTO `proveedores_contactos` (`rut_proveedor`, `nombre_contacto`, `mail_contacto`, `telefono_contacto`, `por_defecto`) VALUES ('" & (txt_rut.Text) & "', '" & (txt_nombre_contacto.Text) & "', '" & (txt_mail_contacto.Text) & "', '" & (txt_telefono_contacto.Text) & "', '" & (por_defecto) & "');"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        mostrar_malla_forma_de_pago()

        txt_nombre_contacto.Text = ""
        txt_mail_contacto.Text = ""
        txt_telefono_contacto.Text = ""

    End Sub

    Private Sub txt_nombre_TextChanged(sender As Object, e As EventArgs) Handles txt_mail_contacto.TextChanged

    End Sub

    Private Sub txt_nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_mail_contacto.KeyPress
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

    Private Sub btn_quitar_entrada_remuneracion_Click(sender As Object, e As EventArgs)
        'Dim VarEstado As String
        If grilla_contactos.Rows.Count > 0 Then

            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR EL REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")


            If valormensaje = vbYes Then
                Dim Var_codigo As String

                Var_codigo = grilla_contactos.CurrentRow.Cells(0).Value

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM proveedores_contactos WHERE cod_auto = '" & (Var_codigo) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If
            mostrar_malla_forma_de_pago()
        End If

    End Sub

    Private Sub grilla_detalle_cuadratura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla_contactos.CellContentClick

    End Sub

    Private Sub grilla_detalle_cuadratura_Click(sender As Object, e As EventArgs) Handles grilla_contactos.Click
        txt_nombre_contacto.Text = grilla_contactos.CurrentRow.Cells(1).Value()
        txt_mail_contacto.Text = grilla_contactos.CurrentRow.Cells(2).Value()
        txt_telefono_contacto.Text = grilla_contactos.CurrentRow.Cells(3).Value()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre_contacto.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nombre_contacto.KeyPress
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

    Private Sub txt_telefono_contacto_TextChanged(sender As Object, e As EventArgs) Handles txt_telefono_contacto.TextChanged

    End Sub

    Private Sub txt_telefono_contacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_telefono_contacto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_rut_TextChanged(sender As Object, e As EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub txt_rut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_rut.KeyPress
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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            guion_rut()
            mostrar_datos_proveedores()
            mostrar_malla_forma_de_pago()
            txt_rut.Focus()
        End If
    End Sub

    Sub guion_rut()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut.Text
        If rut_cliente.Length > 2 Then
            guion = rut_cliente(rut_cliente.Length - 2).ToString()
            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut.Text = rut_cliente
            End If
        End If
    End Sub

    Sub mostrar_datos_proveedores()
        'If Combo_rut.Text <> "" Then
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            txt_mail.Text = DS.Tables(DT.TableName).Rows(0).Item("email_proveedor")

        End If
        conexion.Close()
        ' End If
    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        If txt_nombre_contacto.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre_contacto.Focus()
            Exit Sub
        End If

        If txt_mail_contacto.Text = "" Then
            MsgBox("CAMPO MAIL VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_mail_contacto.Focus()
            Exit Sub
        End If

        If txt_telefono_contacto.Text = "" Then
            MsgBox("CAMPO TELEFONO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_telefono_contacto.Focus()
            Exit Sub
        End If
        Dim por_defecto As String = "NO"

        If CheckBox1.Checked = True Then
            por_defecto = "SI"
        Else
            por_defecto = "NO"
        End If


        If por_defecto = "SI" Then
            SC.Connection = conexion
            SC.CommandText = "Update proveedores_contactos Set por_defecto='NO' WHERE rut_proveedor= '" & (txt_rut.Text) & "' and cod_auto <> '0';"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO `proveedores_contactos` (`rut_proveedor`, `nombre_contacto`, `mail_contacto`, `telefono_contacto`, `por_defecto`) VALUES ('" & (txt_rut.Text) & "', '" & (txt_nombre_contacto.Text) & "', '" & (txt_mail_contacto.Text) & "', '" & (txt_telefono_contacto.Text) & "', '" & (por_defecto) & "');"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "INSERT INTO `proveedores_contactos` (`rut_proveedor`, `nombre_contacto`, `mail_contacto`, `telefono_contacto`, `por_defecto`) VALUES ('" & (txt_rut.Text) & "', '" & (txt_nombre_contacto.Text) & "', '" & (txt_mail_contacto.Text) & "', '" & (txt_telefono_contacto.Text) & "', '" & (por_defecto) & "');"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        mostrar_malla_forma_de_pago()

        txt_nombre_contacto.Text = ""
        txt_mail_contacto.Text = ""
        txt_telefono_contacto.Text = ""

    End Sub

    Private Sub btn_quitar_Click(sender As Object, e As EventArgs) Handles btn_quitar.Click
        'Dim VarEstado As String
        If grilla_contactos.Rows.Count > 0 Then

            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR EL REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")


            If valormensaje = vbYes Then
                Dim Var_codigo As String

                Var_codigo = grilla_contactos.CurrentRow.Cells(0).Value

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM proveedores_contactos WHERE cod_auto = '" & (Var_codigo) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If
            mostrar_malla_forma_de_pago()
        End If

    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Form_buscar_proveedores_contactos.Show()
        Me.Enabled = False
    End Sub

    Private Sub Form_proveedores_contactos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub
End Class