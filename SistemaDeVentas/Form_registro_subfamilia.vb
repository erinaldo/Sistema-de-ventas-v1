Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_registro_subfamilia
    Dim VarSeleccion As Integer
    Dim MiPos As Integer
    Private Sub Form_subfamilia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_registro_subfamilia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_subfamilia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'combo_familia.Items.Clear()

        llenar_combo_familia()
        actualizar_tabla()
        mostrar(0)
        controles(False, True)
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_codigo_familia()
        If Combo_familia.Text <> "-" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from familia where nombre_familia ='" & (Combo_familia.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo")
            End If

            conexion.Close()
        End If
    End Sub

    Sub llenar_combo_familia()
        combo_familia.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from familia where nombre_familia <> 'TODOS' order by nombre_familia asc"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_familia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_familia"))
            Next
        End If
        conexion.Close()
    End Sub

    Private Sub combo_especie_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_familia.GotFocus
        combo_familia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_familia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_familia.KeyPress
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

    Private Sub combo_especie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_familia.LostFocus
        combo_familia.BackColor = Color.White
    End Sub



    Sub mostrar(ByVal i As Integer)
        Try
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_codigo_familia.Text = DS2.Tables(DT2.TableName).Rows(i).Item("CODIGO_FAMILIA")
                txt_codigo_subfamilia.Text = DS2.Tables(DT2.TableName).Rows(i).Item("COD_AUTO")
                txt_nombre_subfamilia.Text = DS2.Tables(DT2.TableName).Rows(i).Item("nombre_subfamilia")
            End If
        Catch
        End Try
        mostrar_familia()
    End Sub

    Sub mostrar_familia()
        If txt_codigo_familia.Text <> "" And txt_codigo_familia.Text <> "-" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from familia where codigo ='" & (txt_codigo_familia.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Combo_familia.SelectedItem = DS.Tables(DT.TableName).Rows(0).Item("nombre_familia")
            End If

            conexion.Close()
        End If
    End Sub



    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        btn_eliminar.Enabled = b

        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a

        txt_nombre_subfamilia.Enabled = a
        combo_familia.Enabled = b

        btn_primero.Enabled = b
        btn_ultimo.Enabled = b
        btn_siguiente.Enabled = b
        btn_anterior.Enabled = b
    End Sub

    Sub limpiar()
        txt_nombre_subfamilia.Text = ""
        combo_familia.Text = ""
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        If combo_familia.Text = "" Then
            MsgBox("CAMPO FAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_familia.Focus()
            Exit Sub
        End If

        If combo_familia.Text = "-" Then
            MsgBox("CAMPO FAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_familia.Focus()
            Exit Sub
        End If

        txt_nombre_subfamilia.Text = ""
        controles(True, False)
        VarSeleccion = 1
        btn_eliminar.Enabled = False
        btn_modificar.Enabled = False
        crear_codigo()

        txt_nombre_subfamilia.Focus()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        controles(True, False)
        VarSeleccion = 2
        'txt_codigo_variedad.Enabled = False
        llenar_combo_familia()
    End Sub



    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If combo_familia.Text = "" Then
            MsgBox("CAMPO FAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_familia.Focus()
            Exit Sub
        End If

        If combo_familia.Text = "-" Then
            MsgBox("CAMPO FAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_familia.Focus()
            Exit Sub
        End If

        If txt_nombre_subfamilia.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre_subfamilia.Focus()
            Exit Sub
        End If

        txt_nombre_subfamilia.Text = UCase(txt_nombre_subfamilia.Text)

        If VarSeleccion = 1 Then
            conexion.Close()
            Consultas_SQL("select * from subfamilia where codigo_familia = '" & (txt_codigo_familia.Text) & "' AND  nombre_subfamilia = '" & (txt_nombre_subfamilia.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                MsgBox("REGISTRO YA EXISTE", 0 + 16, "ERROR")
                txt_nombre_subfamilia.Focus()
                controles(True, False)

            Else
                crear_codigo()

                SC.Connection = conexion
                SC.CommandText = "INSERT INTO subfamilia(cod_auto, codigo_familia, nombre_subfamilia, fecha_modificacion) VALUES ('" & (txt_codigo_subfamilia.Text) & "','" & (txt_codigo_familia.Text) & "','" & (txt_nombre_subfamilia.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','CREACION DE SUBFAMILIA','" & (txt_nombre_subfamilia.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                actualizar_tabla()
                controles(False, True)

                MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            End If

        ElseIf VarSeleccion = 2 Then

            SC.Connection = conexion
            SC.CommandText = "UPDATE SUBFAMILIA SET nombre_subfamilia='" & (txt_nombre_subfamilia.Text) & "', fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE cod_auto = '" & (txt_codigo_subfamilia.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE SUBFAMILIA','" & (txt_nombre_subfamilia.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            actualizar_tabla()
            controles(False, True)

            MsgBox("DATOS MODIFICACION CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        End If
        btn_modificar.Enabled = True
        btn_eliminar.Enabled = True
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

        If valormensaje = vbYes Then
            SC.Connection = conexion
            SC.CommandText = "delete from subfamilia where cod_auto = '" & (txt_codigo_subfamilia.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO `registros_eliminados` (`registro`, `codigo`, `fecha`, `usuario_responsable`) VALUES ('SUBFAMILIA', '" & (txt_codigo_subfamilia.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (miusuario) & "');"
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

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        btn_eliminar.Enabled = True
        btn_modificar.Enabled = True
        MiPos = 0
        ' combo_familia.Items.Clear()
        mostrar(MiPos)
    End Sub

    Private Sub btn_primero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.Click
        MiPos = 0
        mostrar(0)
        'mostrar_datos_especie_por_combo()
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
            ' mostrar_datos_especie_por_combo()
        End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        If MiPos < DT2.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
            '   mostrar_datos_especie_por_combo()
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        MiPos = DT2.Rows.Count - 1
        mostrar(MiPos)
        ' mostrar_datos_especie_por_combo()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        ' form_Menu_admin.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    Sub actualizar_tabla()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select * from subfamilia WHERE codigo_familia='" & (txt_codigo_familia.Text) & "' order by nombre_subfamilia"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        conexion.Close()
    End Sub

    Private Sub txt_costo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_minima_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
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

    Private Sub txt_marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txt_numero_tecnico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_subfamilia.GotFocus
        txt_nombre_subfamilia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_familia.GotFocus
        combo_familia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_familia_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_familia.LostFocus
        combo_familia.BackColor = Color.White
    End Sub

    Private Sub txt_nombre_subfamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_subfamilia.KeyPress

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

    Private Sub txt_nombre_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_subfamilia.LostFocus
        txt_nombre_subfamilia.BackColor = Color.White
    End Sub

    Private Sub txt_codigo_variedad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub crear_codigo()
        Dim varcodigo As Integer

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from subfamilia"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varcodigo = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                txt_codigo_subfamilia.Text = varcodigo + 1
            End If
        Catch err As InvalidCastException
            txt_codigo_subfamilia.Text = 1
        End Try
        conexion.Close()
    End Sub














    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
    '    btn_modificar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
    '    btn_modificar.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.GotFocus
        btn_eliminar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.LostFocus
        btn_eliminar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
    '    btn_buscar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
    '    btn_buscar.BackColor = Color.WhiteSmoke
    'End Sub

    'Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
    '    btn_imprimir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
    '    btn_imprimir.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_primero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.GotFocus
        btn_primero.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_primero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.LostFocus
        btn_primero.BackColor = Color.Transparent
    End Sub

    Private Sub btn_anterior_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.GotFocus
        btn_anterior.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_anterior_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.LostFocus
        btn_anterior.BackColor = Color.Transparent
    End Sub

    Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.GotFocus
        btn_siguiente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_siguiente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.LostFocus
        btn_siguiente.BackColor = Color.Transparent
    End Sub

    Private Sub btn_ultimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.GotFocus
        btn_ultimo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_ultimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.LostFocus
        btn_ultimo.BackColor = Color.Transparent
    End Sub

    'Private Sub txt_nombre_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre.LostFocus
    '    txt_nombre.BackColor = Color.White
    'End Sub

    Private Sub combo_familia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_familia.SelectedIndexChanged
        mostrar_codigo_familia()
        txt_nombre_subfamilia.Text = ""
        actualizar_tabla()
        mostrar(0)
    End Sub

    Private Sub txt_nombre_subfamilia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_subfamilia.TextChanged

    End Sub



    Private Sub btn_modificar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        If combo_familia.Text = "" Then
            MsgBox("CAMPO FAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_familia.Focus()
            Exit Sub
        End If

        If combo_familia.Text = "-" Then
            MsgBox("CAMPO FAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_familia.Focus()
            Exit Sub
        End If

        controles(True, False)
        VarSeleccion = 2
        btn_eliminar.Enabled = False
        txt_nombre_subfamilia.Focus()
    End Sub
End Class