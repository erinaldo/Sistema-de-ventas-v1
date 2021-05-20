Public Class Form_asociar_clientes_a_empresas
    Dim VarSeleccion As Integer
    Dim MiPos As Integer
    Dim Nombre As String
    Dim Comuna As String
    Dim Direccion As String
    Dim email As String
    Dim telefono As String
    Dim Giro As String
    Dim descuento As String
    Private Sub Form_registrar_clientes_a_empresas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_registrar_clientes_a_empresas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_registrar_clientes_a_empresas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'actualizar_tabla()
        'mostrar(0)
        controles(False, True)
        cargar_logo()
        grilla_estado_de_cuenta.Font = New System.Drawing.Font("Arial", 10.25!, System.Drawing.FontStyle.Regular)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub guion_rut_empresa()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_empresa.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_empresa.Text = rut_cliente
            End If
        End If
    End Sub

    Private Sub txt_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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



        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_empresa.GotFocus
        txt_rut_empresa.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub

    Private Sub txt_rut_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_empresa.Validated
        'If valida_rut(txt_rut.Text) = False Then
        '    txt_rut.Focus()
        '    txt_rut.SelectAll()
        'End If
    End Sub

    Sub mostrar(ByVal i As Integer)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_rut_empresa.Text = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
            txt_codigo_empresa.Text = DS.Tables(DT.TableName).Rows(i).Item("cod_cliente")
            txt_nombre_empresa.Text = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
            mostrar_malla()
        End If
    End Sub

    Sub mostrar_datos_clientes()
        If txt_rut_empresa.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut_empresa.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                txt_rut_empresa.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_codigo_empresa.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_nombre_empresa.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_rut_empresa.Enabled = False
                'txt_nombre_empresa.Enabled = True

                mostrar_malla()

                txt_rut_cliente.Focus()
                conexion.Close()
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
                conexion.Close()
                Form_seleccionar_cuenta_para_asociar.Show()
                Me.Enabled = False
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("RUT NO EXISTENTE", 0 + 16, "ERROR")
                txt_rut_empresa.Focus()
                conexion.Close()
            End If
            conexion.Close()
        End If
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        btn_eliminar.Enabled = a
        btn_buscar.Enabled = a
        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a

        txt_rut_empresa.Enabled = a
        'txt_nombre_empresa.Enabled = a
        txt_rut_cliente.Enabled = a
        txt_nombre_cliente.Enabled = a

        GroupBox_clientes.Enabled = a
        'btn_ultimo.Enabled = b
        'btn_siguiente.Enabled = b
        'btn_anterior.Enabled = b
    End Sub

    Sub limpiar()
        'combo_tipo.Text = "TIPO CUENTA"
        txt_rut_empresa.Text = ""
        txt_nombre_empresa.Text = ""
        'txt_apellidos.Text = ""
        'txt_direccion.Text = ""
        'txt_telefono.Text = ""
        'txt_email.Text = ""
        'txt_ciudad.Text = ""
        'txt_comuna.Text = ""
        'txt_giro.Text = ""
        'txt_dscto.Text = ""
        txt_codigo_empresa.Text = ""
        'Combo_activo.Text = "SI"
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        limpiar()
        controles(True, False)
        VarSeleccion = 1
        'txt_dscto1.Text = "0"
        'combo_tipo.Focus()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        controles(True, False)
        VarSeleccion = 2
        txt_rut_empresa.Enabled = True
        'combo_tipo.Enabled = False
        txt_nombre_empresa.Enabled = False
        'txt_apellidos.Enabled = False
        'txt_direccion.Enabled = False
        'txt_telefono.Enabled = False
        'txt_email.Enabled = False
        'txt_comuna.Enabled = False
        'txt_giro.Enabled = False
        'txt_dscto.Enabled = False
        'Combo_activo.Enabled = False
        txt_rut_empresa.Focus()

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If txt_rut_empresa.Text = "" Then
            txt_rut_empresa.Focus()
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If txt_nombre_empresa.Text = "" Then
            txt_nombre_empresa.Focus()
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_rut_cliente.Text = "" Then
            txt_rut_cliente.Focus()
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If txt_nombre_cliente.Text = "" Then
            txt_nombre_cliente.Focus()
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If valida_rut(txt_rut_cliente.Text) = False Then
            txt_rut_cliente.Focus()
            txt_rut_cliente.SelectAll()
            Exit Sub
        End If

        Consultas_SQL("select * from clientes_que_retiran_por_empresas where rut_empresa = '" & (txt_rut_empresa.Text) & "'  and rut_cliente = '" & (txt_rut_cliente.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            MsgBox("REGISTRO YA EXISTENTE", 0 + 16, "ERROR")
            Exit Sub
        End If

        SC.Connection = conexion
        SC.CommandText = "INSERT INTO clientes_que_retiran_por_empresas (codigo_empresa, rut_empresa, rut_cliente, nombre_cliente, usuario_responsable, fecha_modificacion) VALUES  ('" & (txt_codigo_empresa.Text) & "','" & (txt_rut_empresa.Text) & "','" & (txt_rut_cliente.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','CREACION DE CLIENTE RETIRA','" & (txt_rut_empresa.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'actualizar_tabla()
        mostrar_malla()
        controles(False, True)
        MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If txt_rut_cliente.Text = "" Then
            txt_rut_cliente.Focus()
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If txt_nombre_cliente.Text = "" Then
            txt_nombre_cliente.Focus()
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

        If valormensaje = vbYes Then
            Dim cod_auto As String
            cod_auto = grilla_estado_de_cuenta.CurrentRow.Cells(1).Value

            SC.Connection = conexion
            SC.CommandText = "delete from clientes_que_retiran_por_empresas where rut_cliente = '" & (cod_auto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO clientes_que_retiran_por_empresas_eliminados (codigo_empresa, rut_empresa, rut_cliente, nombre_cliente, usuario_responsable, fecha_modificacion) VALUES  ('" & (txt_codigo_empresa.Text) & "','" & (txt_rut_empresa.Text) & "','" & (txt_rut_cliente.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

        End If

        mostrar_malla()
        txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        controles(False, True)
        MiPos = 0
        mostrar(MiPos)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Sub actualizar_tabla()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from clientes where estado_cuenta <> 'SIN CUENTA' order by nombre_cliente;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_empresa.GotFocus
        txt_nombre_empresa.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_empresa.KeyPress
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

    Private Sub txt_nombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_empresa.LostFocus
        txt_nombre_empresa.BackColor = Color.White
    End Sub

    Private Sub txt_direccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txt_ciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txt_comuna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txt_giro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txt_email_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If
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

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_empresa.LostFocus
        txt_rut_empresa.BackColor = Color.White
    End Sub

    Private Sub btn_primero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MiPos = 0
        mostrar(MiPos)
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MiPos = DT.Rows.Count - 1
        mostrar(MiPos)
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_empresa.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        txt_nombre_empresa.Text = ""
        grilla_estado_de_cuenta.Rows.Clear()
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
            guion_rut_empresa()
            mostrar_datos_clientes()
        End If
    End Sub

    Private Sub txt_apellidos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.GotFocus
        btn_eliminar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.LostFocus
        btn_eliminar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imprimir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imprimir.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_primero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_primero.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_primero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_primero.BackColor = Color.Transparent
    'End Sub

    'Private Sub btn_anterior_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_anterior.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_anterior_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_anterior.BackColor = Color.Transparent
    'End Sub

    'Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_siguiente.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_siguiente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_siguiente.BackColor = Color.Transparent
    'End Sub

    'Private Sub btn_ultimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_ultimo.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_ultimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_ultimo.BackColor = Color.Transparent
    'End Sub


    Private Sub txt_apellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
        controles(True, False)
        VarSeleccion = 1
        txt_rut_empresa.Focus()
    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        limpiar()
        'MiPos = 0
        'mostrar(MiPos)
    End Sub

    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Button1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_listado_eliminados_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_listado_eliminados.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_listado_eliminados_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_listado_eliminados.BackColor = Color.Transparent
    'End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Form_buscador_clientes_para_asociar.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txt_rut_empresa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_empresa.TextChanged

    End Sub

    Sub mostrar_malla()
        grilla_estado_de_cuenta.Rows.Clear()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        SC2.Connection = conexion
        SC2.CommandText = "select * from clientes_que_retiran_por_empresas  where  rut_empresa = '" & (txt_rut_empresa.Text) & "' and  codigo_empresa = '" & (txt_codigo_empresa.Text) & "'  order by nombre_cliente asc"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                grilla_estado_de_cuenta.Rows.Add(DS2.Tables(DT2.TableName).Rows(i).Item("cod_auto"), _
                                                  DS2.Tables(DT2.TableName).Rows(i).Item("rut_cliente"), _
                                                   DS2.Tables(DT2.TableName).Rows(i).Item("nombre_cliente"))
            Next

            grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(1).Width = 100 Then
                grilla_estado_de_cuenta.Columns(1).Width = 99
            Else
                grilla_estado_de_cuenta.Columns(1).Width = 100
            End If
        End If
    End Sub

    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_cliente.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_cliente.Text = rut_cliente
            End If
        End If
    End Sub

    Private Sub txt_rut_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress
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
        txt_nombre_cliente.Text = ""
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            guion_rut_cliente()
            mostrar_datos_retira()
            'btn.Focus()
        End If
    End Sub

    Sub mostrar_datos_retira()
        If txt_rut_cliente.Text <> "" Then
            conexion.Close()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion
            SC3.CommandText = "select * from clientes_retira where rut_cliente_retira ='" & (txt_rut_cliente.Text) & "'"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                txt_nombre_cliente.Text = DS3.Tables(DT3.TableName).Rows(0).Item("nombre_cliente_retira")
            Else
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged

    End Sub

    Private Sub txt_nombre_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_cliente.KeyPress
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

    Private Sub txt_nombre_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.TextChanged

    End Sub

    Private Sub grilla_estado_de_cuenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_estado_de_cuenta.CellContentClick

    End Sub

    Private Sub grilla_estado_de_cuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_estado_de_cuenta.Click
        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            Exit Sub
        End If

        txt_rut_cliente.Text = grilla_estado_de_cuenta.CurrentRow.Cells(1).Value()
        txt_nombre_cliente.Text = grilla_estado_de_cuenta.CurrentRow.Cells(2).Value()
    End Sub
End Class