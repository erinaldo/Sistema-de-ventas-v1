Public Class Form_empresas_relacionadas

    Private Sub Form_empresas_relacionadas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_registro_cuentas_corrientes.WindowState = FormWindowState.Normal
        Form_registro_cuentas_corrientes.Enabled = True
    End Sub

    Private Sub Form_empresas_relacionadas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_empresas_relacionadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        'txt_rut_relacionado.Text = Form_registro_cuentas_corrientes.txt_rut.Text
        cargar_impuesto_unico()
        grilla_impuesto_unico.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
    End Sub
    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub


    Sub cargar_impuesto_unico()
        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        SC4.Connection = conexion
        SC4.CommandText = "select rut_empresa_relacionada, nombre_empresa_relacionada from empresas_relacionadas where rut_empresa='" & (Form_registro_cuentas_corrientes.txt_rut.Text) & "'"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)
        grilla_impuesto_unico.Rows.Clear()
        grilla_impuesto_unico.Columns.Clear()
        grilla_impuesto_unico.Columns.Add("rut_empresa_relacionada", "RUT")
        grilla_impuesto_unico.Columns.Add("nombre_empresa_relacionada", "NOMBRE")


        ' grilla_remuneracion.Columns(2).Visible = False

        If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
            For i = 0 To DS4.Tables(DT4.TableName).Rows.Count - 1
                grilla_impuesto_unico.Rows.Add(DS4.Tables(DT4.TableName).Rows(i).Item("rut_empresa_relacionada"), _
                                                DS4.Tables(DT4.TableName).Rows(i).Item("nombre_empresa_relacionada"))
            Next
        End If
        conexion.Close()

        'grilla_impuesto_unico.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_impuesto_unico.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_impuesto_unico.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_impuesto_unico.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub txt_posicion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_relacionado.GotFocus
        color_foco()
    End Sub

    Private Sub txt_posicion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_relacionado.KeyPress
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

    Private Sub txt_posicion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_relacionado.TextChanged

    End Sub


    Sub color_foco()


        Dim controlcito As Control
        Dim controlChild As Control


        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).ReadOnly = False Then
                    CType(controlcito, TextBox).BackColor = Color.White
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                CType(controlcito, ComboBox).BackColor = Color.White
            End If

            If TypeOf controlcito Is Button Then
                CType(controlcito, Button).BackColor = Color.Transparent
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).ReadOnly = False Then
                            CType(controlChild, TextBox).BackColor = Color.White
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        CType(controlChild, ComboBox).BackColor = Color.White
                    End If

                    If TypeOf controlChild Is Button Then
                        CType(controlChild, Button).BackColor = Color.Transparent
                    End If
                Next
            End If

        Next











        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).Focused Then
                    If CType(controlcito, TextBox).ReadOnly = False Then
                        CType(controlcito, TextBox).BackColor = Color.LightSkyBlue
                        Exit Sub
                    End If
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                If CType(controlcito, ComboBox).Focused Then
                    CType(controlcito, ComboBox).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is Button Then
                If CType(controlcito, Button).Focused Then
                    CType(controlcito, Button).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).Focused Then
                            If CType(controlChild, TextBox).ReadOnly = False Then
                                CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
                                Exit Sub
                            End If
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        If CType(controlChild, ComboBox).Focused Then
                            CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If

                    If TypeOf controlChild Is Button Then
                        If CType(controlChild, Button).Focused Then
                            CType(controlChild, Button).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If
                Next
            End If

        Next
    End Sub

    Private Sub btn_agregar_entrada_remuneracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.GotFocus
        color_foco()
    End Sub

    Private Sub btn_quitar_entrada_remuneracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_relacionado.GotFocus
        color_foco()
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_relacionado.KeyPress
        txt_nombre_relacionado.Text = ""
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
            guion_rut_cliente_relacioanados()
            mostrar_datos_clientes_relacinados()
        End If
    End Sub

    Sub guion_rut_cliente_relacioanados()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_relacionado.Text
        If txt_rut_relacionado.Text.Contains("PROPIEDAD") Then
        Else
            If rut_cliente.Length > 2 Then

                guion = rut_cliente(rut_cliente.Length - 2).ToString()

                If guion <> "-" Then
                    Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                    rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                    rut_cliente = rut_cliente & "-" & fin_rut
                    txt_rut_relacionado.Text = rut_cliente
                End If
            End If
        End If
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_relacionado.TextChanged

    End Sub

    Private Sub btn_agregar_entrada_remuneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.Click
        If txt_rut_relacionado.Text = "" Then
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_relacionado.Focus()
            Exit Sub
        End If

        If txt_nombre_relacionado.Text = "" Then
            MsgBox("CAMPO POSICION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_relacionado.Focus()
            Exit Sub
        End If





        Dim codigo As String
        Dim posicion As String


        For i = 0 To grilla_impuesto_unico.Rows.Count - 1
            codigo = grilla_impuesto_unico.Rows(i).Cells(0).Value.ToString
            posicion = grilla_impuesto_unico.Rows(i).Cells(1).Value.ToString


            If codigo = txt_rut_relacionado.Text And posicion = txt_nombre_relacionado.Text Then
                grilla_impuesto_unico.Rows.Remove(grilla_impuesto_unico.Rows(i))
                Exit For
            End If
        Next



        grilla_impuesto_unico.Rows.Add(txt_rut_relacionado.Text, txt_nombre_relacionado.Text)



        'SC3.Connection = conexion
        'SC3.CommandText = "delete from posicion_producto where codigo_producto='" & (txt_rut_relacionado.Text) & "' and posicion='" & (txt_nombre_relacionado.Text) & "' "
        'DA3.SelectCommand = SC3
        'DA3.Fill(DT3)


        SC3.Connection = conexion
        SC3.CommandText = "INSERT INTO `empresas_relacionadas` (`rut_empresa`, `rut_empresa_relacionada`, `nombre_empresa_relacionada`, `usuario_responable`) VALUES ('" & (Form_registro_cuentas_corrientes.txt_rut.Text) & "', '" & (txt_rut_relacionado.Text) & "', '" & (txt_nombre_relacionado.Text) & "','" & (miusuario) & "');"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)


        txt_nombre_relacionado.Text = ""
        txt_nombre_relacionado.Focus()

    End Sub

    Private Sub btn_quitar_entrada_remuneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.Click
        Dim codigo As String
        Dim posicion As String

        codigo = grilla_impuesto_unico.CurrentRow.Cells(0).Value
        posicion = grilla_impuesto_unico.CurrentRow.Cells(1).Value

        SC3.Connection = conexion
        SC3.CommandText = "DELETE FROM `empresas_relacionadas` WHERE rut_empresa='" & (Form_registro_cuentas_corrientes.txt_rut.Text) & "' and `cod_auto`<>'0';"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)

        If grilla_impuesto_unico.Rows.Count > 0 Then
            grilla_impuesto_unico.Rows.Remove(grilla_impuesto_unico.CurrentRow)
        End If

        Dim rut_empresa_relacionada As String
        Dim nombre_empresa_relacionada As String

        For i = 0 To grilla_impuesto_unico.Rows.Count - 1
            rut_empresa_relacionada = grilla_impuesto_unico.Rows(i).Cells(0).Value.ToString
            nombre_empresa_relacionada = grilla_impuesto_unico.Rows(i).Cells(1).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into empresas_relacionadas (rut_empresa, rut_empresa_relacionada, nombre_empresa_relacionada, usuario_responable) values('" & (Form_registro_cuentas_corrientes.txt_rut.Text) & "','" & (rut_empresa_relacionada) & "','" & (nombre_empresa_relacionada) & "','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next
    End Sub

    Sub mostrar_datos_clientes_relacinados()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut_relacionado.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_rut_relacionado.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            txt_nombre_relacionado.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
        End If
        conexion.Close()
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class