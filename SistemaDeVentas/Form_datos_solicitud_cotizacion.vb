Public Class Form_datos_solicitud_cotizacion

    Private Sub Form_datos_solicitud_cotizacion_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F12 Then
            'btn_guardar.Focus()
        End If

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

    Private Sub Form_datos_solicitud_cotizacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_solicitar_cotizacion.WindowState = FormWindowState.Normal
        Form_solicitar_cotizacion.Enabled = True
    End Sub

    Private Sub Form_datos_solicitud_cotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()
        'Combo_tipo_motor.Text = "-"

        If Form_solicitar_cotizacion.Combo_tipo_motor.Text = "" Then
            Combo_tipo_motor.Text = "-"
        Else
            Combo_tipo_motor.Text = Form_solicitar_cotizacion.Combo_tipo_motor.Text
        End If



        llenar_combo__marca_vehiculo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub llenar_combo__marca_vehiculo()

        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        SC4.Connection = conexion
        SC4.CommandText = "select * from marcas_vehiculos order by nombre_marca"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
            For i = 0 To DS4.Tables(0).Rows.Count - 1
                ' Combo_comuna.Items.Add(UCase(DS3.Tables(DT3.TableName).Rows(i).Item("comuna_nombre")))
                col.Add(UCase(DS4.Tables(0).Rows(i)("nombre_marca").ToString()))
            Next
            txt_marca_automovil.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_marca_automovil.AutoCompleteCustomSource = col
            txt_marca_automovil.AutoCompleteMode = AutoCompleteMode.Suggest

            txt_marca_automovil.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_marca_automovil.AutoCompleteCustomSource = col
            txt_marca_automovil.AutoCompleteMode = AutoCompleteMode.Suggest
        End If
        txt_marca_automovil.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_marca_automovil.AutoCompleteCustomSource = col
        txt_marca_automovil.AutoCompleteMode = AutoCompleteMode.Suggest

    End Sub

    Private Sub btn_aceptar_Click(sender As Object, e As EventArgs) Handles btn_aceptar.Click

        If txt_marca_automovil.Text = "" Then
            txt_marca_automovil.Focus()
            MsgBox("CAMPO MARCA VEHICULO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_modelo_vehiculo.Text = "" Then
            txt_modelo_vehiculo.Focus()
            MsgBox("CAMPO MODELO VEHICULO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_tipo_motor.Text = "-" Then
            Combo_tipo_motor.Focus()
            MsgBox("CAMPO TIPO MOTOR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_año.Text = "" Then
            txt_año.Focus()
            MsgBox("CAMPO AÑO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_cilindrada.Text = "" Then
            txt_cilindrada.Focus()
            MsgBox("CAMPO CILINDRADA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_nro_chasis.Text = "" Then
            txt_nro_chasis.Focus()
            MsgBox("CAMPO NRO CHASIS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_nombre_cliente.Text = "" Then
            txt_nombre_cliente.Focus()
            MsgBox("CAMPO NOMBRE CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_telefono_cliente.Text = "" Then
            txt_telefono_cliente.Focus()
            MsgBox("CAMPO TELEFONO CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If txt_observacion.Text = "" Then
        '    txt_observacion.Focus()
        '    MsgBox("CAMPO COMENTARIO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        conexion.Close()
        Consultas_SQL("select * from marcas_vehiculos where nombre_marca = '" & (txt_marca_automovil.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count = 0 Then

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO `marcas_vehiculos` (`nombre_marca`) VALUES ('" & (txt_marca_automovil.Text) & "');"
            DA.SelectCommand = SC
            DA.Fill(DT)

        End If

        If txt_marca_automovil.Text = "MAHINDRA" Then
            If txt_nro_motor.Text = "" Then
                txt_nro_motor.Focus()
                MsgBox("CAMPO NRO. MOTOR OBLIGATORIO PARA COTIZAR MAHINDRA VACIO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
        End If

        If txt_nro_chasis.Text.Length <> 17 Then
            txt_nro_chasis.Focus()
            MsgBox("CAMPO NRO CHASIS INCOMPLETO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If


        Form_solicitar_cotizacion.txt_marca_vehiculo.Text = txt_marca_automovil.Text
        Form_solicitar_cotizacion.txt_modelo_vehiculo.Text = txt_modelo_vehiculo.Text
        Form_solicitar_cotizacion.Combo_tipo_motor.Text = Combo_tipo_motor.Text
        Form_solicitar_cotizacion.txt_año.Text = txt_año.Text
        Form_solicitar_cotizacion.txt_cilindrada.Text = txt_cilindrada.Text
        Form_solicitar_cotizacion.txt_nro_chasis.Text = txt_nro_chasis.Text
        Form_solicitar_cotizacion.txt_nro_motor.Text = txt_nro_motor.Text
        Form_solicitar_cotizacion.txt_observacion.Text = txt_observacion.Text

        Form_solicitar_cotizacion.txt_nombre_cliente.Text = txt_nombre_cliente.Text
        Form_solicitar_cotizacion.txt_telefono_cliente.Text = txt_telefono_cliente.Text
        Me.Close()

    End Sub

    Private Sub txt_datos_vehiculo_TextChanged(sender As Object, e As EventArgs) Handles txt_modelo_vehiculo.TextChanged

    End Sub

    Private Sub txt_datos_vehiculo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_modelo_vehiculo.KeyPress
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
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


    End Sub

    Private Sub txt_nro_chasis_TextChanged(sender As Object, e As EventArgs) Handles txt_nro_chasis.TextChanged

    End Sub

    Private Sub txt_nro_chasis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nro_chasis.KeyPress
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
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txt_nombre_cliente_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre_cliente.TextChanged

    End Sub

    Private Sub txt_nombre_cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nombre_cliente.KeyPress
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
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txt_telefono_cliente_TextChanged(sender As Object, e As EventArgs) Handles txt_telefono_cliente.TextChanged

    End Sub

    Private Sub txt_telefono_cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_telefono_cliente.KeyPress
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

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txt_comentario_producto_TextChanged(sender As Object, e As EventArgs) Handles txt_observacion.TextChanged

    End Sub

    Private Sub txt_comentario_producto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_observacion.KeyPress
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
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txt_marca_proveedor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_marca_proveedor_LostFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_nro_motor_TextChanged(sender As Object, e As EventArgs) Handles txt_nro_motor.TextChanged

    End Sub

    Private Sub txt_nro_motor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nro_motor.KeyPress
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
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txt_cilindrada_TextChanged(sender As Object, e As EventArgs) Handles txt_cilindrada.TextChanged

    End Sub

    Private Sub txt_cilindrada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cilindrada.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txt_marca_proveedor_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    Private Sub txt_año_TextChanged(sender As Object, e As EventArgs) Handles txt_año.TextChanged

    End Sub

    Private Sub txt_año_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_año.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txt_marca_vehiculo_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_marca_vehiculo_KeyPress(sender As Object, e As KeyPressEventArgs)

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Combo_tipo_motor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_tipo_motor.SelectedIndexChanged

    End Sub

    Private Sub Combo_tipo_motor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Combo_tipo_motor.KeyPress

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txt_marca_automovil_TextChanged(sender As Object, e As EventArgs) Handles txt_marca_automovil.TextChanged

    End Sub

    Private Sub txt_marca_automovil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_marca_automovil.KeyPress
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
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
End Class