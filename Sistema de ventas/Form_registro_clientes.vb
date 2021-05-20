Imports System.IO
Imports System.Drawing.Drawing2D

Public Class form_registro_clientes
    Dim VarSeleccion As Integer
    Dim MiPos As Integer
    Dim Nombre As String
    Dim Comuna As String
    Dim Direccion As String
    Dim email As String
    Dim telefono As String
    Dim Giro As String
    Dim descuento As String
    Private Sub form_registro_clientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub form_registro_clientes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub form_clientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'actualizar_tabla()
        'mostrar(0)
        comunas()
        controles(False, True)
        ' combo_tipo.Text = "TIPO CUENTA"
        cargar_logo()
        tipo_seleccion()
    End Sub

    Sub comunas()
        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        SC4.Connection = conexion
        SC4.CommandText = "select * from comuna order by comuna_nombre asc"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
            For i = 0 To DS4.Tables(0).Rows.Count - 1
                ' Combo_comuna.Items.Add(UCase(DS3.Tables(DT3.TableName).Rows(i).Item("comuna_nombre")))
                col.Add(UCase(DS4.Tables(0).Rows(i)("comuna_nombre").ToString()))
            Next
            txt_comuna.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_comuna.AutoCompleteCustomSource = col
            txt_comuna.AutoCompleteMode = AutoCompleteMode.Suggest

            txt_comuna.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_comuna.AutoCompleteCustomSource = col
            txt_comuna.AutoCompleteMode = AutoCompleteMode.Suggest
        End If
        txt_comuna.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_comuna.AutoCompleteCustomSource = col
        txt_comuna.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub guion_rut_cliente()
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



    Private Sub txt_telefono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_telefono.GotFocus
        txt_telefono.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_telefono.KeyPress
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

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.GotFocus
        txt_rut.BackColor = Color.LightSkyBlue
    End Sub


    Private Sub txt_rut_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.Validated
        'If valida_rut(txt_rut.Text) = False Then
        '    txt_rut.Focus()
        '    txt_rut.SelectAll()
        'End If
    End Sub

    Sub mostrar(ByVal i As Integer)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            combo_tipo.Text = DS.Tables(DT.TableName).Rows(i).Item("tipo_cliente")
            txt_rut.Text = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
            txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(i).Item("cod_cliente")
            txt_nombres.Text = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
            txt_direccion.Text = DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente")
            txt_telefono.Text = DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente")
            txt_email.Text = DS.Tables(DT.TableName).Rows(i).Item("email_cliente")
            txt_comuna.Text = DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente")
            txt_giro.Text = DS.Tables(DT.TableName).Rows(i).Item("giro_cliente")
            txt_dscto.Text = DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO_1")
            Try
                Combo_activo.Text = DS.Tables(DT.TableName).Rows(i).Item("activo")
            Catch
                Combo_activo.Text = ""
            End Try
            'txt_dscto1.Text = DS.Tables(DT.TableName).Rows(i).Item("dscto1")
            'txt_dscto2.Text = DS.Tables(DT.TableName).Rows(i).Item("dscto2")
            'txt_folio.Text = DS.Tables(DT.TableName).Rows(i).Item("folio")
            'If DS.Tables(DT.TableName).Rows(i).Item("cuenta") = "CERRADA" Then
            '    radio_cuenta_cerrada.Checked = True
            'Else
            '    radio_cuenta_abierta.Checked = True
            'End If
        End If
    End Sub

    Sub mostrar_datos_clientes()
        If txt_rut.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                combo_tipo.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cliente")
                txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_nombres.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_email.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
                txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
                txt_dscto.Text = DS.Tables(DT.TableName).Rows(0).Item("DESCUENTO_1")
                Combo_activo.Text = DS.Tables(DT.TableName).Rows(0).Item("activo")

                Nombre = txt_nombres.Text
                Comuna = txt_comuna.Text
                Direccion = txt_direccion.Text
                email = txt_email.Text
                telefono = txt_telefono.Text
                Giro = txt_giro.Text
                descuento = txt_dscto.Text

                txt_rut.Enabled = False
                combo_tipo.Enabled = True
                txt_nombres.Enabled = True
                txt_apellidos.Enabled = True
                txt_direccion.Enabled = True
                txt_telefono.Enabled = True
                txt_email.Enabled = True
                txt_comuna.Enabled = True
                txt_giro.Enabled = True
                txt_dscto.Enabled = True
                Combo_activo.Enabled = True

                txt_nombres.Focus()
                conexion.Close()

                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
                conexion.Close()
                Form_seleccionar_cuenta_clientes.Show()
                Me.Enabled = False
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("RUT NO EXISTENTE", 0 + 16, "ERROR")
                txt_rut.Focus()
                conexion.Close()
            End If
            conexion.Close()
        End If
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        btn_eliminar.Enabled = b
        btn_modificar.Enabled = b
        btn_buscar.Enabled = b
        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a
        'btn_imprimir.Enabled = b
        combo_tipo.Enabled = a
        txt_rut.Enabled = a
        txt_direccion.Enabled = a
        txt_nombres.Enabled = a
        txt_apellidos.Enabled = a
        txt_telefono.Enabled = a
        txt_email.Enabled = a
        ' txt_ciudad.Enabled = a
        txt_comuna.Enabled = a
        txt_giro.Enabled = a
        txt_dscto.Enabled = a
        Combo_activo.Enabled = a
        'btn_primero.Enabled = b
        'btn_ultimo.Enabled = b
        'btn_siguiente.Enabled = b
        'btn_anterior.Enabled = b
        'txt_dscto1.Enabled = a

    End Sub

    Sub limpiar()
        combo_tipo.Text = "TIPO CUENTA"
        txt_rut.Text = ""
        txt_nombres.Text = ""
        txt_apellidos.Text = ""
        txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_email.Text = ""
        'txt_ciudad.Text = ""
        txt_comuna.Text = ""
        txt_giro.Text = ""
        txt_dscto.Text = ""

        txt_codigo_cliente.Text = ""
        Combo_activo.Text = "SI"
    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        limpiar()
        controles(True, False)
        VarSeleccion = 1
        'txt_dscto1.Text = "0"
        combo_tipo.Focus()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.Click

        controles(True, False)
        VarSeleccion = 2
        tipo_seleccion()
        txt_rut.Enabled = True
        combo_tipo.Enabled = False
        txt_nombres.Enabled = False
        txt_apellidos.Enabled = False
        txt_direccion.Enabled = False
        txt_telefono.Enabled = False
        txt_email.Enabled = False
        txt_comuna.Enabled = False
        txt_giro.Enabled = False
        txt_dscto.Enabled = False
        Combo_activo.Enabled = False
        txt_rut.Focus()

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If combo_tipo.Text = "TIPO CUENTA" Then
            MsgBox("CASILLERO TIPO CUENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If Combo_activo.Text = "-" Then
            Combo_activo.Focus()
            MsgBox("CAMPO ESTADO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If


        If VarSeleccion = 1 Then


            If combo_tipo.Text = "EMPRESA" Then
                If combo_tipo.Text = "TIPO CUENTA" Then
                    combo_tipo.Focus()
                    MsgBox("CAMPO TIPO CUENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_rut.Text = "" Then
                    txt_rut.Focus()
                    MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_nombres.Text = "" Then
                    txt_nombres.Focus()
                    MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                'If txt_apellidos.Text = "" Then
                '    txt_apellidos.Focus()
                '    MsgBox("CAMPO APELLIDOS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                '    Exit Sub
                'End If
                If txt_comuna.Text = "" Then
                    txt_comuna.Focus()
                    MsgBox("CAMPO COMUNA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_direccion.Text = "" Then
                    txt_direccion.Focus()
                    MsgBox("CAMPO DIRECCION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_email.Text = "" Then
                    txt_email.Focus()
                    MsgBox("CAMPO E-MAIL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_telefono.Text = "" Then
                    txt_telefono.Focus()
                    MsgBox("CAMPO TELEFONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_giro.Text = "" Then
                    txt_giro.Focus()
                    MsgBox("CAMPO GIRO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If


                If txt_dscto.Text = "" Then
                    txt_dscto.Focus()
                    MsgBox("CAMPO DESCUENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If

            End If

            If combo_tipo.Text = "PERSONA" Then
                If combo_tipo.Text = "TIPO CUENTA" Then
                    combo_tipo.Focus()
                    MsgBox("CAMPO TIPO CUENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_rut.Text = "" Then
                    txt_rut.Focus()
                    MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_nombres.Text = "" Then
                    txt_nombres.Focus()
                    MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_apellidos.Text = "" Then
                    txt_apellidos.Focus()
                    MsgBox("CAMPO APELLIDOS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_comuna.Text = "" Then
                    txt_comuna.Focus()
                    MsgBox("CAMPO COMUNA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_direccion.Text = "" Then
                    txt_direccion.Focus()
                    MsgBox("CAMPO DIRECCION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_email.Text = "" Then
                    txt_email.Focus()
                    MsgBox("CAMPO E-MAIL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_telefono.Text = "" Then
                    txt_telefono.Focus()
                    MsgBox("CAMPO TELEFONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
                If txt_giro.Text = "" Then
                    txt_giro.Focus()
                    MsgBox("CAMPO GIRO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If

                If txt_dscto.Text = "" Then
                    txt_dscto.Focus()
                    MsgBox("CAMPO DESCUENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If
            End If

            If valida_rut(txt_rut.Text) = False Then
                txt_rut.Focus()
                txt_rut.SelectAll()
                Exit Sub
            End If


            conexion.Close()
            Consultas_SQL("select * from comuna where comuna_nombre = '" & (txt_comuna.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count = 0 Then
                MsgBox("DEBE SELECCIONAR UNA COMUNA DEL SISTEMA", 0 + 16, "ERROR")
                txt_comuna.Focus()
                Exit Sub
            End If








            If combo_tipo.Text = "PERSONA" Then
                txt_nombres.Text = txt_apellidos.Text & " " & txt_nombres.Text
            ElseIf combo_tipo.Text = "EMPRESA" Then
                txt_nombres.Text = txt_nombres.Text
            End If


            If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
                Consultas_SQL("select * from clientes where rut_CLIENTE = '" & (txt_rut.Text) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    MsgBox("REGISTRO YA EXISTENTE", 0 + 16, "ERROR")
                    Exit Sub
                End If
            End If


            crear_codigo_cliente()
            ' Try
            SC.Connection = conexion
            SC.CommandText = "INSERT INTO clientes (cod_cliente, tipo_CLIENTE, Rut_cliente, nombre_cliente, direccion_cliente, telefono_cliente, EMAIL_CLIENTE, comuna_cliente, giro_cliente, DESCUENTO_1, CIUDAD_CLIENTE, DESCUENTO_2, FOLIO_CLIENTE, ESTADO_CUENTA, cuenta_cliente, tipo_cuenta, orden_de_compra, mensaje, cupo_cliente, saldo_cliente, fecha_modificacion, ACTIVO) VALUES  ('" & (txt_codigo_cliente.Text) & "','" & (combo_tipo.Text) & "','" & (txt_rut.Text) & "','" & (txt_nombres.Text) & "','" & (txt_direccion.Text) & "','" & (txt_telefono.Text) & "','" & (txt_email.Text) & "','" & (txt_comuna.Text) & "','" & (txt_giro.Text) & "','" & (txt_dscto.Text) & "','" & ("-") & "','" & ("0") & "','" & ("-") & "','" & ("SIN CUENTA") & "', 'NO', '-', 'NO', 'SIN MENSAJE','0','0','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (Combo_activo.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            'SC.CommandText = "INSERT INTO SUCURSAL.clientes (cod_cliente, tipo_CLIENTE, Rut_cliente, nombre_cliente, direccion_cliente, telefono_cliente, EMAIL_CLIENTE, comuna_cliente, giro_cliente, DESCUENTO_1, CIUDAD_CLIENTE, DESCUENTO_2, FOLIO_CLIENTE, ESTADO_CUENTA, cuenta_cliente, tipo_cuenta, orden_de_compra, mensaje, cupo_cliente, saldo_cliente, fecha_modificacion) VALUES  ('" & (txt_codigo_cliente.Text) & "','" & (combo_tipo.Text) & "','" & (txt_rut.Text) & "','" & (txt_nombres.Text) & "','" & (txt_direccion.Text) & "','" & (txt_telefono.Text) & "','" & (txt_email.Text) & "','" & (txt_comuna.Text) & "','" & (txt_giro.Text) & "','" & ("0") & "','" & ("-") & "','" & ("0") & "','" & ("-") & "','" & ("SIN CUENTA") & "', 'NO', '-', 'NO', 'SIN MENSAJE','0','0','" & (form_Menu_admin.dtp_fecha.Text) & "')"
            'DA.SelectCommand = SC
            'DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','CREACION DE CLIENTE','" & (txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
            'Catch err As InvalidCastException

            'End Try

            actualizar_tabla()
            controles(False, True)
            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            ' Form_venta.lbl_rut.Text = Me.txt_rut.Text
            Form_venta.txt_rut_cliente.Text = Me.txt_rut.Text
            Form_venta.mostrar_datos_clientes()

            ' End If
            ' End If



        ElseIf VarSeleccion = 2 Then
            If combo_tipo.Text = "TIPO CUENTA" Then
                combo_tipo.Focus()
                MsgBox("CAMPO TIPO CUENTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
            If txt_rut.Text = "" Then
                txt_rut.Focus()
                MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
            If txt_nombres.Text = "" Then
                txt_nombres.Focus()
                MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
            'If txt_apellidos.Text = "" Then
            '    txt_apellidos.Focus()
            '    MsgBox("CAMPO APELLIDOS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            '    Exit Sub
            'End If
            If txt_comuna.Text = "" Then
                txt_comuna.Focus()
                MsgBox("CAMPO COMUNA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
            If txt_direccion.Text = "" Then
                txt_direccion.Focus()
                MsgBox("CAMPO DIRECCION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
            If txt_email.Text = "" Then
                txt_email.Focus()
                MsgBox("CAMPO E-MAIL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
            If txt_telefono.Text = "" Then
                txt_telefono.Focus()
                MsgBox("CAMPO TELEFONO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If
            If txt_giro.Text = "" Then
                txt_giro.Focus()
                MsgBox("CAMPO GIRO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            conexion.Close()
            Consultas_SQL("select * from comuna where comuna_nombre = '" & (txt_comuna.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count = 0 Then
                MsgBox("DEBE SELECCIONAR UNA COMUNA DEL SISTEMA", 0 + 16, "ERROR")
                txt_comuna.Focus()
                Exit Sub
            End If


            If Nombre <> txt_nombres.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL NOMBRE AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If Comuna <> txt_comuna.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO LA COMUNA AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If Direccion <> txt_direccion.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO LA DIRECCION AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If email <> txt_email.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL EMAIL AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If telefono <> txt_telefono.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL TELEFONO AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If Giro <> txt_giro.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL GIRO AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If descuento <> txt_dscto.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL DESCUENTO AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If


            '   Try
            SC.Connection = conexion
            SC.CommandText = "UPDATE clientes SET NOMBRE_cliente='" & (txt_nombres.Text) & "', direccion_cliente='" & (txt_direccion.Text) & "',telefono_cliente = '" & (txt_telefono.Text) & "',comuna_cliente = '" & (txt_comuna.Text) & "',giro_cliente = '" & (txt_giro.Text) & "',tipo_cliente = '" & (combo_tipo.Text) & "',email_cliente = '" & (txt_email.Text) & "', fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "', descuento_1='" & (txt_dscto.Text) & "', activo='" & (Combo_activo.Text) & "' WHERE RUT_cliente = '" & (txt_rut.Text) & "' and cod_cliente ='" & (txt_codigo_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)




            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTE','" & (txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
            'Catch err As InvalidCastException

            'End Try


            MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            'Form_venta.lbl_rut.Text = Me.txt_rut.Text
            'Form_venta.txt_rut_cliente.Text = Me.txt_rut.Text
            'Form_venta.mostrar_datos_clientes()
            actualizar_tabla()
            controles(False, True)
        End If


    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

        If valormensaje = vbYes Then
            SC.Connection = conexion
            SC.CommandText = "delete from clientes where cod_cliente = '" & (txt_codigo_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        actualizar_tabla()
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            mostrar(0)
        Else
            limpiar()
        End If


    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        controles(False, True)
        MiPos = 0
        mostrar(MiPos)

    End Sub



    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        'form_Menu_admin.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub



    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()

        'conexion.Open()

        'SC.Connection = conexion
        'SC.CommandText = "select * from clientes, EMPRESA where rut = '" & (txt_rut.Text) & "'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'Dim rpt As New Crystal_clientes_sistema

        'rpt.SetDataSource(DS.Tables(DT.TableName))
        'form_informe_clientes.rpt_clientes.ReportSource = rpt
        'form_informe_clientes.Show()
        'conexion.Close()
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()

        Me.Enabled = True
    End Sub

    Sub actualizar_tabla()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from clientes"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    Private Sub txt_dscto2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombres.GotFocus
        txt_nombres.BackColor = Color.LightSkyBlue

    End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombres.KeyPress

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

    Private Sub txt_nombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombres.LostFocus
        txt_nombres.BackColor = Color.White
    End Sub

    Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombres.TextChanged

    End Sub

    Private Sub txt_direccion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_direccion.GotFocus
        txt_direccion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_direccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_direccion.KeyPress
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

    Private Sub txt_direccion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_direccion.LostFocus
        txt_direccion.BackColor = Color.White
    End Sub

    Private Sub txt_direccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_direccion.TextChanged

    End Sub

    'Private Sub txt_ciudad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_ciudad.BackColor = Color.LightBlue
    'End Sub

    Private Sub txt_ciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    'Private Sub txt_ciudad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_ciudad.BackColor = Color.White
    'End Sub

    Private Sub txt_ciudad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_comuna_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_comuna.GotFocus
        txt_comuna.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_comuna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_comuna.KeyPress
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

    Private Sub txt_comuna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_comuna.LostFocus
        txt_comuna.BackColor = Color.White
    End Sub

    Private Sub txt_comuna_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comuna.TextChanged

    End Sub

    Private Sub txt_giro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_giro.GotFocus
        txt_giro.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_giro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_giro.KeyPress
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

    Private Sub txt_giro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_giro.LostFocus
        txt_giro.BackColor = Color.White
    End Sub

    Private Sub txt_giro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_giro.TextChanged

    End Sub

    Private Sub txt_razon_social_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

    End Sub


    Private Sub combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.GotFocus
        combo_tipo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.LostFocus




        combo_tipo.BackColor = Color.White
    End Sub

    Private Sub combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_tipo.SelectedIndexChanged
        tipo_seleccion()
        'If combo_tipo.Enabled = True Then
        '    If combo_tipo.Text = "PERSONA" Then

        '        lbl_apellidos.Visible = True
        '        txt_apellidos.Visible = True

        '        lbl_apellidos.Location = New Point(9, 120)
        '        lbl_direccion.Location = New Point(2, 153)
        '        lbl_telefono.Location = New Point(3, 186)
        '        lbl_email.Location = New Point(32, 219)
        '        lbl_comuna.Location = New Point(16, 252)
        '        lbl_giro.Location = New Point(42, 285)

        '        txt_apellidos.Location = New Point(88, 117)
        '        txt_direccion.Location = New Point(88, 150)
        '        txt_telefono.Location = New Point(88, 183)
        '        txt_email.Location = New Point(88, 216)
        '        txt_comuna.Location = New Point(88, 249)
        '        txt_giro.Location = New Point(88, 282)

        '        btn_guardar.Location = New Point(7, 247)
        '        btn_cancelar.Location = New Point(7, 287)
        '        btn_salir.Location = New Point(7, 327)

        '        GroupBox_clientes.Width = (473)
        '        GroupBox_clientes.Height = (316)

        '        GroupBox_posicion.Location = New Point(7, 372)

        '        GroupBox_botones.Width = (119)
        '        GroupBox_botones.Height = (371)


        '        Me.Width = (617)
        '        Me.Height = (462)

        '    End If
        '    If combo_tipo.Text = "EMPRESA" Then

        '        lbl_apellidos.Visible = False
        '        txt_apellidos.Visible = False

        '        lbl_apellidos.Location = New Point(2, 120)
        '        lbl_direccion.Location = New Point(2, 120)
        '        lbl_telefono.Location = New Point(3, 153)
        '        lbl_email.Location = New Point(32, 186)
        '        lbl_comuna.Location = New Point(16, 219)
        '        lbl_giro.Location = New Point(42, 252)

        '        btn_guardar.Location = New Point(7, 214)
        '        btn_cancelar.Location = New Point(7, 254)
        '        btn_salir.Location = New Point(7, 294)

        '        txt_apellidos.Location = New Point(88, 117)
        '        txt_direccion.Location = New Point(88, 117)
        '        txt_telefono.Location = New Point(88, 150)
        '        txt_email.Location = New Point(88, 183)
        '        txt_comuna.Location = New Point(88, 216)
        '        txt_giro.Location = New Point(88, 249)

        '        GroupBox_clientes.Width = (473)
        '        GroupBox_clientes.Height = (283)

        '        GroupBox_posicion.Location = New Point(7, 339)

        '        GroupBox_botones.Width = (119)
        '        GroupBox_botones.Height = (337)

        '        Me.Width = (617)
        '        Me.Height = (429)

        '    End If
        '    If combo_tipo.Text = "TIPO CUENTA" Then
        '        lbl_apellidos.Visible = False
        '        txt_apellidos.Visible = False

        '        lbl_apellidos.Location = New Point(2, 120)
        '        lbl_direccion.Location = New Point(2, 120)
        '        lbl_telefono.Location = New Point(3, 153)
        '        lbl_email.Location = New Point(32, 186)
        '        lbl_comuna.Location = New Point(16, 219)
        '        lbl_giro.Location = New Point(42, 252)

        '        btn_guardar.Location = New Point(7, 214)
        '        btn_cancelar.Location = New Point(7, 254)
        '        btn_salir.Location = New Point(7, 294)

        '        txt_apellidos.Location = New Point(88, 117)
        '        txt_direccion.Location = New Point(88, 117)
        '        txt_telefono.Location = New Point(88, 150)
        '        txt_email.Location = New Point(88, 183)
        '        txt_comuna.Location = New Point(88, 216)
        '        txt_giro.Location = New Point(88, 249)

        '        GroupBox_clientes.Width = (473)
        '        GroupBox_clientes.Height = (283)

        '        GroupBox_posicion.Location = New Point(7, 339)

        '        GroupBox_botones.Width = (119)
        '        GroupBox_botones.Height = (337)

        '        Me.Width = (617)
        '        Me.Height = (429)
        '    End If
        'End If
    End Sub


    Sub tipo_seleccion()
        If combo_tipo.Enabled = False Then
            lbl_nombre.Text = "NOMBRE:"
            lbl_nombre.Location = New Point(16, 89)
            lbl_apellidos.Location = New Point(16, 89)
            lbl_apellidos.Visible = False
            txt_apellidos.Visible = False
            lbl_apellidos.Location = New Point(2, 122)
            lbl_comuna.Location = New Point(16, 122)
            lbl_telefono.Location = New Point(3, 221)
            lbl_direccion.Location = New Point(2, 155)
            lbl_email.Location = New Point(32, 186)
            lbl_giro.Location = New Point(42, 254)
            lbl_descto.Location = New Point(37, 287)

            btn_guardar.Location = New Point(7, 192)
            btn_cancelar.Location = New Point(7, 237)
            btn_salir.Location = New Point(7, 282)

            txt_apellidos.Location = New Point(88, 120)
            txt_comuna.Location = New Point(88, 120)
            txt_telefono.Location = New Point(88, 219)
            txt_direccion.Location = New Point(88, 153)
            txt_email.Location = New Point(88, 186)
            txt_giro.Location = New Point(88, 251)
            txt_dscto.Location = New Point(88, 285)

            GroupBox_clientes.Width = (488)
            GroupBox_clientes.Height = (330)
            'GroupBox_posicion.Location = New Point(7, 392)
            GroupBox_botones.Width = (109)
            GroupBox_botones.Height = (330)
            Me.Width = (622)
            Me.Height = (443)
            Exit Sub
        End If

        If combo_tipo.Enabled = True Then
            If VarSeleccion = 1 Then
                If combo_tipo.Text = "PERSONA" Then
                    lbl_nombre.Text = "NOMBRES:"
                    lbl_nombre.Location = New Point(7, 87)
                    lbl_apellidos.Visible = True
                    txt_apellidos.Visible = True
                    lbl_apellidos.Location = New Point(9, 120)
                    lbl_comuna.Location = New Point(16, 153)
                    lbl_telefono.Location = New Point(3, 252)
                    lbl_direccion.Location = New Point(2, 186)

                    lbl_email.Location = New Point(32, 219)
                    lbl_giro.Location = New Point(42, 285)
                    lbl_descto.Location = New Point(37, 318)

                    txt_apellidos.Location = New Point(88, 117)
                    txt_comuna.Location = New Point(88, 150)
                    txt_telefono.Location = New Point(88, 249)
                    txt_direccion.Location = New Point(88, 183)
                    txt_email.Location = New Point(88, 216)
                    txt_giro.Location = New Point(88, 282)
                    txt_dscto.Location = New Point(88, 315)
                    'btn_guardar.Location = New Point(7, 247)
                    'btn_cancelar.Location = New Point(7, 287)
                    'btn_salir.Location = New Point(7, 327)

                    btn_guardar.Location = New Point(7, 211)
                    btn_cancelar.Location = New Point(7, 256)
                    btn_salir.Location = New Point(7, 301)



                    GroupBox_clientes.Width = (488)
                    GroupBox_clientes.Height = (349)
                    'GroupBox_posicion.Location = New Point(7, 427)
                    GroupBox_botones.Width = (109)
                    GroupBox_botones.Height = (348)
                    Me.Width = (622)
                    Me.Height = (460)
                End If

                If combo_tipo.Text = "EMPRESA" Then

                    lbl_nombre.Text = "NOMBRE:"
                    lbl_nombre.Location = New Point(16, 89)
                    lbl_apellidos.Location = New Point(16, 89)
                    lbl_apellidos.Visible = False
                    txt_apellidos.Visible = False
                    lbl_apellidos.Location = New Point(2, 122)
                    lbl_comuna.Location = New Point(16, 122)
                    lbl_telefono.Location = New Point(3, 221)
                    lbl_direccion.Location = New Point(2, 155)
                    lbl_email.Location = New Point(32, 186)
                    lbl_giro.Location = New Point(42, 254)
                    lbl_descto.Location = New Point(37, 287)

                    btn_guardar.Location = New Point(7, 192)
                    btn_cancelar.Location = New Point(7, 237)
                    btn_salir.Location = New Point(7, 282)

                    txt_apellidos.Location = New Point(88, 120)
                    txt_comuna.Location = New Point(88, 120)
                    txt_telefono.Location = New Point(88, 219)
                    txt_direccion.Location = New Point(88, 153)
                    txt_email.Location = New Point(88, 186)
                    txt_giro.Location = New Point(88, 251)
                    txt_dscto.Location = New Point(88, 285)

                    GroupBox_clientes.Width = (488)
                    GroupBox_clientes.Height = (330)
                    'GroupBox_posicion.Location = New Point(7, 392)
                    GroupBox_botones.Width = (109)
                    GroupBox_botones.Height = (330)
                    Me.Width = (622)
                    Me.Height = (443)
                End If

                If combo_tipo.Text = "TIPO CUENTA" Then
                    lbl_nombre.Text = "NOMBRE:"
                    lbl_nombre.Location = New Point(16, 89)
                    lbl_apellidos.Location = New Point(16, 89)
                    lbl_apellidos.Visible = False
                    txt_apellidos.Visible = False
                    lbl_apellidos.Location = New Point(2, 122)
                    lbl_comuna.Location = New Point(16, 122)
                    lbl_telefono.Location = New Point(3, 221)
                    lbl_direccion.Location = New Point(2, 155)
                    lbl_email.Location = New Point(32, 186)
                    lbl_giro.Location = New Point(42, 254)
                    lbl_descto.Location = New Point(37, 287)

                    btn_guardar.Location = New Point(7, 192)
                    btn_cancelar.Location = New Point(7, 237)
                    btn_salir.Location = New Point(7, 282)

                    txt_apellidos.Location = New Point(88, 120)
                    txt_comuna.Location = New Point(88, 120)
                    txt_telefono.Location = New Point(88, 219)
                    txt_direccion.Location = New Point(88, 153)
                    txt_email.Location = New Point(88, 186)
                    txt_giro.Location = New Point(88, 251)
                    txt_dscto.Location = New Point(88, 285)

                    GroupBox_clientes.Width = (488)
                    GroupBox_clientes.Height = (330)
                    'GroupBox_posicion.Location = New Point(7, 392)
                    GroupBox_botones.Width = (109)
                    GroupBox_botones.Height = (330)
                    Me.Width = (622)
                    Me.Height = (443)
                End If
            End If
        End If
    End Sub

    Private Sub txt_telefono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_telefono.LostFocus
        txt_telefono.BackColor = Color.White
    End Sub

    Private Sub txt_telefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telefono.TextChanged

    End Sub

    Private Sub txt_email_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_email.GotFocus
        txt_email.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_email_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_email.KeyPress
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

    Private Sub txt_email_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_email.LostFocus
        txt_email.BackColor = Color.White
    End Sub

    Private Sub txt_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox_clientes.Enter

    End Sub

    'Private Sub txt_dscto1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_dscto1.BackColor = Color.LightBlue
    'End Sub

    'Private Sub txt_dscto1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_dscto1.BackColor = Color.White
    'End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
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

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut.KeyPress
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
            If VarSeleccion = 1 Then
                guion_rut_cliente()
                txt_nombres.Focus()
            End If
            If VarSeleccion = 2 Then
                guion_rut_cliente()
                mostrar_datos_clientes()
            End If
        End If

    End Sub



    Private Sub txt_apellidos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_apellidos.GotFocus
        txt_apellidos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_apellidos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_apellidos.KeyPress
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

    Private Sub txt_apellidos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_apellidos.LostFocus
        txt_apellidos.BackColor = Color.White
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 11, FontStyle.Regular)
        Dim Font2 As New Font("arial", 12, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        Dim im As Image
        Try
            im = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
            Dim p As New PointF(535, 10)
            e.Graphics.DrawImage(im, p)
        Catch
        End Try



        Dim rect1 As New Rectangle(10, 15, 250, 15)
        Dim rect2 As New Rectangle(10, 30, 250, 15)
        Dim rect3 As New Rectangle(10, 45, 250, 15)
        Dim rect4 As New Rectangle(10, 60, 250, 15)
        Dim rect5 As New Rectangle(10, 75, 250, 15)
        Dim rect6 As New Rectangle(10, 90, 250, 15)
        Dim rect_titulo As New Rectangle(10, 130, 830, 30)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim stringFormat_logo As New StringFormat()
        stringFormat_logo.Alignment = StringAlignment.Center
        stringFormat_logo.LineAlignment = StringAlignment.Far

        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

        e.Graphics.DrawString("DATOS CLIENTE", Font2, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawLine(Pens.Black, 10, 160, 820, 160)

        e.Graphics.DrawString("TIPO", Font1, Brushes.Black, 30, 200)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 200)
        e.Graphics.DrawString(combo_tipo.Text, Font1, Brushes.Gray, 200, 200)
        e.Graphics.DrawString("RUT", Font1, Brushes.Black, 30, 220)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 220)
        e.Graphics.DrawString(txt_rut.Text, Font1, Brushes.Gray, 200, 220)
        e.Graphics.DrawString("NOMBRE", Font1, Brushes.Black, 30, 240)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 240)
        e.Graphics.DrawString(txt_nombres.Text, Font1, Brushes.Gray, 200, 240)
        e.Graphics.DrawString("DIRECCION", Font1, Brushes.Black, 30, 260)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 260)
        e.Graphics.DrawString(txt_direccion.Text, Font1, Brushes.Gray, 200, 260)
        e.Graphics.DrawString("TELEFONO", Font1, Brushes.Black, 30, 280)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 280)
        e.Graphics.DrawString(txt_telefono.Text, Font1, Brushes.Gray, 200, 280)
        e.Graphics.DrawString("EMAIL", Font1, Brushes.Black, 30, 300)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 300)
        e.Graphics.DrawString(txt_email.Text, Font1, Brushes.Gray, 200, 300)
        e.Graphics.DrawString("COMUNA", Font1, Brushes.Black, 30, 320)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 320)
        e.Graphics.DrawString(txt_comuna.Text, Font1, Brushes.Gray, 200, 320)
        e.Graphics.DrawString("GIRO", Font1, Brushes.Black, 30, 340)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 340)
        e.Graphics.DrawString(txt_giro.Text, Font1, Brushes.Gray, 200, 340)
    End Sub

    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
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


    Private Sub txt_apellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_apellidos.TextChanged

    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
        controles(True, False)
        VarSeleccion = 1
        'txt_dscto1.Text = "0"
        combo_tipo.Focus()
    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        MiPos = 0
        mostrar(MiPos)
        tipo_seleccion()
    End Sub

    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Button1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Form_buscador_clientes_registro_clientes.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub



    Sub crear_codigo_cliente()
        'Dim varnumdoc As Integer
        'conexion.Close()
        'DS2.Tables.Clear()
        'DT2.Rows.Clear()
        'DT2.Columns.Clear()
        'DS2.Clear()
        'conexion.Open()
        'Try
        '    SC2.Connection = conexion
        '    SC2.CommandText = "select max(cod_cliente) as cod_cliente from clientes where cod_cliente >= '" & (inicio_codigo_cliente) & "'"
        '    DA2.SelectCommand = SC2
        '    DA2.Fill(DT2)
        '    DS2.Tables.Add(DT2)
        '    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
        '        varnumdoc = DS2.Tables(DT2.TableName).Rows(0).Item("cod_cliente")
        '        txt_codigo_cliente.Text = varnumdoc + 1
        '    End If
        'Catch err As InvalidCastException
        '    txt_codigo_cliente.Text = inicio_codigo_cliente
        '    Exit Sub
        'End Try
        'conexion.Close()




        Dim VarCodProducto As String

        Dim VarCodBuscar As String


        conexion.Close()
        DS1.Tables.Clear()
        DT1.Rows.Clear()
        DT1.Columns.Clear()
        DS1.Clear()
        conexion.Open()
        SC1.Connection = conexion

        SC1.CommandText = "select cod_cliente from clientes where cod_cliente >= '" & (inicio_codigo_cliente) & "' order by cod_cliente asc"

        DA1.SelectCommand = SC1
        DA1.Fill(DT1)
        DS1.Tables.Add(DT1)
        grilla.DataSource = DS1.Tables(DT1.TableName)
        conexion.Close()


        VarCodBuscar = inicio_codigo_cliente

        For i = 0 To grilla.Rows.Count - 1

            VarCodProducto = grilla.Rows(i).Cells(0).Value.ToString

            If VarCodBuscar <> VarCodProducto Then
                txt_codigo_cliente.Text = VarCodBuscar
                Exit Sub
            End If

            VarCodBuscar = VarCodBuscar + 1

        Next

        'VarCodBuscar = VarCodBuscar + 1

        txt_codigo_cliente.Text = VarCodBuscar

        Exit Sub

    End Sub

    Private Sub grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        crear_codigo_cliente()
    End Sub

    Private Sub txt_dscto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dscto.GotFocus
        txt_dscto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_dscto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dscto.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_dscto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dscto.LostFocus
        txt_dscto.BackColor = Color.White
    End Sub

    Private Sub txt_dscto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dscto.TextChanged

    End Sub
End Class