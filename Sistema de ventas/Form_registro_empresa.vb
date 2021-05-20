Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_registro_empresa

    Private Sub Form_registro_empresa_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_registro_empresa_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_registro_empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from empresa"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        mostrar(0)
        conexion.Close()
        controles(False, True)
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar(ByVal i As Integer)
        ' Try
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_nombre.Text = DS.Tables(DT.TableName).Rows(i).Item("nombre_empresa")
            txt_rut.Text = DS.Tables(DT.TableName).Rows(i).Item("rut_empresa")
            txt_direccion.Text = DS.Tables(DT.TableName).Rows(i).Item("direccion_empresa")
            txt_giro.Text = DS.Tables(DT.TableName).Rows(i).Item("giro_empresa")
            txt_telefono.Text = DS.Tables(DT.TableName).Rows(i).Item("telefono_empresa")
            txt_comuna.Text = DS.Tables(DT.TableName).Rows(i).Item("comuna_empresa")
            txt_recinto.Text = DS.Tables(DT.TableName).Rows(i).Item("recinto_empresa")
            txt_titlular_etiqueta.Text = DS.Tables(DT.TableName).Rows(i).Item("titular_etiqueta")
            txt_pie_menu.Text = DS.Tables(DT.TableName).Rows(i).Item("pie_menu")
            txt_web.Text = DS.Tables(DT.TableName).Rows(i).Item("web_empresa")
            'txt_email.Text = DS.Tables(DT.TableName).Rows(i).Item("CORREO_EMPRESA")
            'txt_clave_email.Text = DS.Tables(DT.TableName).Rows(i).Item("CLAVE_CORREO_EMPRESA")
            'txt_clave_email_repetir.Text = DS.Tables(DT.TableName).Rows(i).Item("CLAVE_CORREO_EMPRESA")
            txt_link_red_social.Text = DS.Tables(DT.TableName).Rows(i).Item("link_red_social")
            txt_tipo_sucursal.Text = DS.Tables(DT.TableName).Rows(i).Item("tipo_sucursal")
            txt_representante_legal.Text = DS.Tables(DT.TableName).Rows(i).Item("representante")
            txt_rut_representante.Text = DS.Tables(DT.TableName).Rows(i).Item("rut_representante")
            'txt_email_administracion.Text = DS.Tables(DT.TableName).Rows(i).Item("CORREO_EMPRESA_administracion")
            'txt_clave_email_administracion.Text = DS.Tables(DT.TableName).Rows(i).Item("CLAVE_CORREO_EMPRESA_administracion")
            'txt_repetir_email_administracion.Text = DS.Tables(DT.TableName).Rows(i).Item("CLAVE_CORREO_EMPRESA_administracion")
        End If
        '  Catch
        '  End Try
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        'btn_nuevo.Enabled = b
        btn_modificar.Enabled = b
        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a
        txt_nombre.Enabled = a
        txt_rut.Enabled = a
        txt_direccion.Enabled = a
        txt_giro.Enabled = a
        txt_web.Enabled = a
        txt_telefono.Enabled = a
        txt_comuna.Enabled = a
        txt_recinto.Enabled = a
        txt_titlular_etiqueta.Enabled = a
        txt_pie_menu.Enabled = a
        txt_link_red_social.Enabled = a
        txt_representante_legal.Enabled = a
        txt_rut_representante.Enabled = a
        'txt_email_administracion.Enabled = a
        'txt_clave_email_administracion.Enabled = a
        'txt_repetir_email_administracion.Enabled = a

        'txt_email.Enabled = a
        'txt_clave_email.Enabled = a
        'txt_clave_email_repetir.Enabled = a
        txt_tipo_sucursal.Enabled = a
    End Sub

    Sub limpiar()
        txt_nombre.Text = ""
        txt_rut.Text = ""
        txt_direccion.Text = ""
        txt_giro.Text = ""
        txt_telefono.Text = ""
        txt_comuna.Text = ""
        txt_recinto.Text = ""
        txt_web.Text = ""
        txt_titlular_etiqueta.Text = ""
        txt_pie_menu.Text = ""
        'txt_email.Text = ""
        'txt_clave_email.Text = ""
        'txt_clave_email_repetir.Text = ""
        txt_tipo_sucursal.Text = ""
        txt_link_red_social.Text = ""
        txt_representante_legal.Text = ""
        txt_rut_representante.Text = ""
        'txt_email_administracion.Text = ""
        'txt_clave_email_administracion.Text = ""
        'txt_repetir_email_administracion.Text = ""
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        controles(True, False)
        txt_rut.Focus()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        mostrar(0)
        controles(False, True)
    End Sub

    Sub actualizar_tabla()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from empresa"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub


    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut.Focus()
            Exit Sub
        End If

        If txt_nombre.Text = "" Then
            txt_nombre.Focus()
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If txt_direccion.Text = "" Then
            txt_direccion.Focus()
            MsgBox("CAMPO DIRECCION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_giro.Text = "" Then
            txt_giro.Focus()
            MsgBox("CAMPO GIRO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_telefono.Text = "" Then
            txt_telefono.Focus()
            MsgBox("CAMPO TELEFONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_comuna.Text = "" Then
            txt_comuna.Focus()
            MsgBox("CAMPO COMUNA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_recinto.Text = "" Then
            txt_recinto.Focus()
            MsgBox("CAMPO RECINTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_web.Text = "" Then
            txt_web.Focus()
            MsgBox("CAMPO WEB VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_titlular_etiqueta.Text = "" Then
            txt_titlular_etiqueta.Focus()
            MsgBox("CAMPO TITULAR ETIQUETA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_pie_menu.Text = "" Then
            txt_pie_menu.Focus()
            MsgBox("CAMPO PIE DE MENU VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_representante_legal.Text = "" Then
            txt_representante_legal.Focus()
            MsgBox("CAMPO NOMBRE REPRESENTANTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_rut_representante.Text = "" Then
            txt_rut_representante.Focus()
            MsgBox("CAMPO RUT REPRESENTANTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_link_red_social.Text = "" Then
            txt_link_red_social.Focus()
            MsgBox("CAMPO LINK RED SOCIAL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If txt_email.Text = "" Then
        '    txt_email.Focus()
        '    MsgBox("CAMPO CORREO DE VENTAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_clave_email.Text = "" Then
        '    txt_clave_email.Focus()
        '    MsgBox("CAMPO CLAVE DE CORREO DE VENTAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_clave_email_repetir.Text = "" Then
        '    txt_clave_email_repetir.Focus()
        '    MsgBox("CAMPO CLAVE DE CORREO DE VENTAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_email_administracion.Text = "" Then
        '    txt_email_administracion.Focus()
        '    MsgBox("CAMPO CORREO DE ADMINISTRACION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_repetir_email_administracion.Text = "" Then
        '    txt_repetir_email_administracion.Focus()
        '    MsgBox("CAMPO CLAVE DE CORREO DE ADMINISTRACION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        If txt_tipo_sucursal.Text = "" Then
            txt_tipo_sucursal.Focus()
            MsgBox("CAMPO TIPO LOCAL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If txt_clave_email.Text <> txt_clave_email_repetir.Text Then
        '    txt_clave_email.Focus()
        '    MsgBox("LAS CLAVES NO COINCIDEN DE VENTAS, FAVOR VERIFICAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_clave_email_administracion.Text <> txt_repetir_email_administracion.Text Then
        '    txt_clave_email_administracion.Focus()
        '    MsgBox("LAS CLAVES NO COINCIDEN DE ADMINISTRACION, FAVOR VERIFICAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        Consultas_SQL("select * from empresa")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

        Else
            SC.Connection = conexion
            SC.CommandText = "INSERT INTO empresa (cod_empresa) VALUES ('1')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        SC.Connection = conexion
        SC.CommandText = "update empresa set link_red_social='" & (txt_link_red_social.Text) & "', nombre_empresa='" & (txt_nombre.Text) & "', direccion_empresa='" & (txt_direccion.Text) & "',rut_empresa='" & (txt_rut.Text) & "', giro_empresa = '" & (txt_giro.Text) & "', comuna_empresa = '" & (txt_comuna.Text) & "', recinto_empresa = '" & (txt_recinto.Text) & "', telefono_empresa = '" & (txt_telefono.Text) & "' , titular_etiqueta = '" & (txt_titlular_etiqueta.Text) & "' , pie_menu = '" & (txt_pie_menu.Text) & "', tipo_sucursal = '" & (txt_tipo_sucursal.Text) & "', web_empresa = '" & (txt_web.Text) & "', representante = '" & (txt_representante_legal.Text) & "', rut_representante = '" & (txt_rut_representante.Text) & "'  where cod_empresa <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)


        SC.Connection = conexion
        SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, tipo, usuario_responsable) values('MI EMPRESA','MODIFICACION DE EMPRESA','" & (txt_nombre.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        conexion.Close()
        MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        actualizar_tabla()


        mirutempresa = txt_rut.Text
        minombreempresa = txt_nombre.Text
        midireccionempresa = txt_direccion.Text
        mitelefonoempresa = txt_telefono.Text
        migiroempresa = txt_giro.Text
        micomunaempresa = txt_comuna.Text
        mirecintoempresa = txt_recinto.Text
        'micorreoempresa = txt_email.Text
        'miclavecorreoempresa = txt_clave_email.Text
        miciudadempresa = txt_comuna.Text
        mititularetiquetaempresa = txt_titlular_etiqueta.Text
        mipiemenuempresa = txt_pie_menu.Text
        mi_tipo_sucursal_empresa = txt_tipo_sucursal.Text
        'MiCorreoEmpresaAdministracion = txt_email_administracion.Text
        'MiClaveCorreoEmpresaAdministracion = txt_clave_email_administracion.Text
        MiWebEmpresa = txt_web.Text
        controles(False, True)

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        color_foco()
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.GotFocus
        color_foco()
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

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
            If txt_rut.Text <> "" Then
                guion_rut()
                txt_nombre.Focus()
            End If
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

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre.KeyPress
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

    Private Sub txt_nombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre.LostFocus
        txt_nombre.BackColor = Color.White
    End Sub

    Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre.TextChanged

    End Sub

    Private Sub txt_direccion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_direccion.GotFocus
        color_foco()
    End Sub

    Private Sub txt_direccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_direccion.KeyPress
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

    Private Sub txt_direccion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_direccion.LostFocus
        txt_direccion.BackColor = Color.White
    End Sub

    Private Sub txt_direccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_direccion.TextChanged

    End Sub

    Private Sub txt_giro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_giro.GotFocus
        color_foco()
    End Sub

    Private Sub txt_giro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_giro.KeyPress
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

    Private Sub txt_giro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_giro.LostFocus
        txt_giro.BackColor = Color.White
    End Sub

    Private Sub txt_giro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_giro.TextChanged

    End Sub



    Private Sub txt_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_telefono.KeyPress
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

    Private Sub txt_telefono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_telefono.GotFocus
        color_foco()
    End Sub

    Private Sub txt_telefono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_telefono.LostFocus
        txt_telefono.BackColor = Color.White
    End Sub

    'Private Sub txt_clave_email_repetir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_clave_email_repetir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_clave_email_repetir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_clave_email_repetir.BackColor = Color.White
    'End Sub



    Private Sub txt_tipo_sucursal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tipo_sucursal.GotFocus
        color_foco()
    End Sub

    Private Sub txt_tipo_sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tipo_sucursal.LostFocus
        txt_tipo_sucursal.BackColor = Color.White
    End Sub

    Private Sub txt_telefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tipo_sucursal.TextChanged

    End Sub

    Private Sub txt_comuna_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_comuna.GotFocus
        color_foco()
    End Sub

    Private Sub txt_comuna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_comuna.KeyPress
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

    Private Sub txt_comuna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_comuna.LostFocus
        txt_comuna.BackColor = Color.White
    End Sub

    Private Sub txt_comuna_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comuna.TextChanged

    End Sub

    Private Sub txt_recinto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_recinto.GotFocus
        color_foco()
    End Sub

    Private Sub txt_recinto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_recinto.KeyPress
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

    Private Sub txt_recinto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_recinto.LostFocus
        txt_recinto.BackColor = Color.White
    End Sub

    Private Sub txt_recinto_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_recinto.Resize

    End Sub

    Private Sub txt_recinto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_recinto.TextChanged

    End Sub

    Private Sub txt_titlular_etiqueta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_titlular_etiqueta.GotFocus
        color_foco()
    End Sub


    Private Sub txt_web_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_web.GotFocus
        color_foco()
    End Sub

    Private Sub txt_web_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_web.LostFocus
        txt_web.BackColor = Color.White
    End Sub




    Private Sub txt_titlular_etiqueta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_titlular_etiqueta.KeyPress
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

    Private Sub txt_titlular_etiqueta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_titlular_etiqueta.LostFocus
        txt_titlular_etiqueta.BackColor = Color.White
    End Sub

    Private Sub txt_titlular_etiqueta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_titlular_etiqueta.TextChanged

    End Sub

    Private Sub txt_pie_menu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pie_menu.GotFocus
        color_foco()
    End Sub

    Private Sub txt_pie_menu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pie_menu.KeyPress
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

    Private Sub txt_pie_menu_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pie_menu.LostFocus
        txt_pie_menu.BackColor = Color.White
    End Sub

    Private Sub txt_pie_menu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pie_menu.TextChanged

    End Sub

    Private Sub txt_email_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txt_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_clave_email_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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



    'Private Sub txt_clave_email_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_clave_email.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_clave_email_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_clave_email.BackColor = Color.White
    'End Sub

    'Private Sub txt_email_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_email.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_email_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_email.BackColor = Color.White
    'End Sub

    Private Sub txt_clave_email_repetir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txt_clave_email_repetir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_tipo_sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_tipo_sucursal.KeyPress
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



    'Private Sub txt_clve_email_administracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_email_administracion.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_clve_email_administracion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_email_administracion.BackColor = Color.White
    'End Sub



    'Private Sub txt_clave_email_administracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_clave_email_administracion.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_clave_email_administracion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_clave_email_administracion.BackColor = Color.White
    'End Sub



    'Private Sub txt_repetir_email_administracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_repetir_email_administracion.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_repetir_email_administracion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_repetir_email_administracion.BackColor = Color.White
    'End Sub

    Private Sub txt_web_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_web.KeyPress
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

    Private Sub txt_link_red_social_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_link_red_social.GotFocus
        color_foco()
    End Sub

    Private Sub txt_link_red_social_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_link_red_social.KeyPress
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

    Private Sub txt_representante_legal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_representante_legal.GotFocus
        color_foco()
    End Sub

    Private Sub txt_representante_legal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_representante_legal.KeyPress
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

    Private Sub txt_representante_legal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_representante_legal.TextChanged

    End Sub

    Private Sub txt_rut_representante_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_representante.GotFocus
        color_foco()
    End Sub

    Private Sub txt_rut_representante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_representante.KeyPress
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

    Private Sub txt_rut_representante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_representante.TextChanged

    End Sub

    Private Sub txt_telefono_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telefono.TextChanged

    End Sub

    Private Sub txt_web_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_web.TextChanged

    End Sub

    Private Sub txt_link_red_social_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_link_red_social.TextChanged

    End Sub
End Class