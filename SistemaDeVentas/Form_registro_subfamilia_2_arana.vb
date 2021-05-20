Imports System.IO
Imports System.Drawing.Drawing2D
Public Class Form_registro_subfamilia_2_arana
    Dim VarSeleccion As Integer
    Dim MiPos As Integer
    Private Sub Form_registro_subfamilia_2_arana_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_registro_subfamilia_2_arana_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_registro_subfamilia_2_arana_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_combo_familia()
        llenar_combo_subfamilia()
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

    Sub mostrar_codigo_subfamilia()
        If Combo_subfamilia.Text <> "-" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from subfamilia where codigo_familia ='" & (txt_codigo_familia.Text) & "' and nombre_subfamilia ='" & (Combo_subfamilia.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
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
        combo_familia.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_familia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_familia"))
            Next
        End If
        combo_familia.SelectedItem = "-"
        conexion.Close()
    End Sub

    Sub llenar_combo_subfamilia()
        Combo_subfamilia.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from subfamilia where codigo_familia='" & (txt_codigo_familia.Text) & "' order by nombre_subfamilia asc"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        Combo_subfamilia.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_subfamilia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
            Next
        End If
        Combo_subfamilia.SelectedItem = "-"

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
            txt_codigo_subfamilia_2.Text = ""
            txt_nombre_subfamilia_dos.Text = ""

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia_2.Text = DS2.Tables(DT2.TableName).Rows(i).Item("cod_auto")
                txt_nombre_subfamilia_dos.Text = DS2.Tables(DT2.TableName).Rows(i).Item("nombre_subfamilia")
                txt_m.Text = DS2.Tables(DT2.TableName).Rows(i).Item("m")
                txt_o.Text = DS2.Tables(DT2.TableName).Rows(i).Item("o")
                txt_medida_1.Text = DS2.Tables(DT2.TableName).Rows(i).Item("medida_1")
                txt_medida_2.Text = DS2.Tables(DT2.TableName).Rows(i).Item("medida_2")
                txt_medida_3.Text = DS2.Tables(DT2.TableName).Rows(i).Item("medida_3")
                txt_volumen.Text = DS2.Tables(DT2.TableName).Rows(i).Item("volumen")
            Else
                txt_codigo_subfamilia_2.Text = ""
                txt_nombre_subfamilia_dos.Text = ""
                txt_m.Text = ""
                txt_o.Text = ""
                txt_medida_1.Text = ""
                txt_medida_2.Text = ""
                txt_medida_3.Text = ""
            End If
        Catch
        End Try
        ' mostrar_familia()
    End Sub

    'Sub mostrar_familia()
    '    If txt_codigo_familia.Text <> "" And txt_codigo_familia.Text <> "-" Then
    '        conexion.Close()
    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from familia where codigo ='" & (txt_codigo_familia.Text) & "'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)

    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Combo_familia.SelectedItem = DS.Tables(DT.TableName).Rows(0).Item("nombre_familia")
    '        End If

    '        conexion.Close()
    '    End If
    'End Sub



    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        btn_eliminar.Enabled = b

        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a

        txt_nombre_subfamilia_dos.Enabled = a

        txt_m.Enabled = a
        txt_o.Enabled = a
        txt_medida_1.Enabled = a
        txt_medida_2.Enabled = a
        txt_medida_3.Enabled = a
        txt_volumen.Enabled = a

        combo_familia.Enabled = b
        Combo_subfamilia.Enabled = b
        btn_primero.Enabled = b
        btn_ultimo.Enabled = b
        btn_siguiente.Enabled = b
        btn_anterior.Enabled = b
        btn_buscar.Enabled = b
    End Sub

    Sub limpiar()
        txt_nombre_subfamilia_dos.Text = ""
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


        If Combo_subfamilia.Text = "" Then
            MsgBox("CAMPO SUBFAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_subfamilia.Focus()
            Exit Sub
        End If

        If Combo_subfamilia.Text = "-" Then
            MsgBox("CAMPO SUBFAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_subfamilia.Focus()
            Exit Sub
        End If



        txt_nombre_subfamilia_dos.Text = ""

        txt_m.Text = ""
        txt_o.Text = ""
        txt_medida_1.Text = ""
        txt_medida_2.Text = ""
        txt_medida_3.Text = ""
        txt_volumen.Text = ""

     
        crear_codigo()
        controles(True, False)
        VarSeleccion = 1
        btn_eliminar.Enabled = False
        btn_modificar.Enabled = False
        'llenar_combo_familia()
        txt_nombre_subfamilia_dos.Focus()
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



        If txt_nombre_subfamilia_dos.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre_subfamilia_dos.Focus()
            Exit Sub
        End If

        If txt_m.Text = "" Then
            MsgBox("CAMPO VALOR M VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_m.Focus()
            Exit Sub
        End If

        If txt_o.Text = "" Then
            MsgBox("CAMPO VALOR O VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_o.Focus()
            Exit Sub
        End If


        If txt_medida_1.Text = "" Then
            MsgBox("CAMPO MEDIDA 1 VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_medida_1.Focus()
            Exit Sub
        End If

        If txt_medida_2.Text = "" Then
            MsgBox("CAMPO MEDIDA 2 VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_medida_2.Focus()
            Exit Sub
        End If

        If txt_medida_3.Text = "" Then
            MsgBox("CAMPO MEDIDA 3 VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_medida_3.Focus()
            Exit Sub
        End If

        If txt_volumen.Text = "" Then
            MsgBox("CAMPO VOLUMEN VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_volumen.Focus()
            Exit Sub
        End If


        txt_nombre_subfamilia_dos.Text = UCase(txt_nombre_subfamilia_dos.Text)

        If VarSeleccion = 1 Then
            conexion.Close()
            Consultas_SQL("select * from subfamilia_dos where codigo_subfamilia = '" & (txt_codigo_subfamilia.Text) & "' AND  nombre_subfamilia = '" & (txt_nombre_subfamilia_dos.Text) & "' ")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                MsgBox("REGISTRO YA EXISTE", 0 + 16, "ERROR")
                txt_nombre_subfamilia_dos.Focus()
                controles(True, False)
                Exit Sub
            Else

                crear_codigo()

                SC.Connection = conexion
                SC.CommandText = "INSERT INTO subfamilia_dos(cod_auto, codigo_subfamilia, nombre_subfamilia, m, o, fecha_modificacion, medida_1, medida_2, medida_3, volumen) VALUES ('" & (txt_codigo_subfamilia_2.Text) & "','" & (txt_codigo_subfamilia.Text) & "','" & (txt_nombre_subfamilia_dos.Text) & "','" & (txt_m.Text) & "','" & (txt_o.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (txt_medida_1.Text) & "','" & (txt_medida_2.Text) & "','" & (txt_medida_3.Text) & "','" & (txt_volumen.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, tipo, usuario_responsable) values('PRODUCTOS','CREACION DE SUBFAMILIA','" & (txt_nombre_subfamilia_dos.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                'combo_familia.Items.Clear()
                actualizar_tabla()
                controles(False, True)

                MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            End If

        ElseIf VarSeleccion = 2 Then
            SC.Connection = conexion
            SC.CommandText = "UPDATE subfamilia_dos SET volumen='" & (txt_volumen.Text) & "', nombre_subfamilia='" & (txt_nombre_subfamilia_dos.Text) & "', m='" & (txt_m.Text) & "',medida_1='" & (txt_medida_1.Text) & "',medida_2='" & (txt_medida_2.Text) & "',medida_3='" & (txt_medida_3.Text) & "',o='" & (txt_o.Text) & "',fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE cod_auto = '" & (txt_codigo_subfamilia_2.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','MODIFICACION DE SUBFAMILIA','" & (txt_nombre_subfamilia_dos.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            actualizar_tabla()
            controles(False, True)

            MsgBox("DATOS MODIFICACION CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

        End If
        btn_eliminar.Enabled = True
        btn_modificar.Enabled = True
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

        If valormensaje = vbYes Then
            SC.Connection = conexion
            SC.CommandText = "delete from subfamilia_dos where cod_auto = '" & (txt_codigo_subfamilia_2.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "UPDATE `productos` SET `subfamilia_dos`='0' WHERE subfamilia_dos='" & (txt_codigo_subfamilia_2.Text) & "' and cod_producto <>'0';"
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
        'combo_familia.Items.Clear()
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
        SC2.CommandText = "select * from subfamilia_dos WHERE codigo_subfamilia='" & (txt_codigo_subfamilia.Text) & "' order by nombre_subfamilia"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        conexion.Close()
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
            SC.CommandText = "select max(cod_auto) as cod_auto from subfamilia_dos"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varcodigo = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                txt_codigo_subfamilia_2.Text = varcodigo + 1
            End If
        Catch err As InvalidCastException
            txt_codigo_subfamilia_2.Text = 1
        End Try
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

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_subfamilia_dos.GotFocus
        txt_nombre_subfamilia_dos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nombre_subfamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_subfamilia_dos.KeyPress

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

    Private Sub combo_familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_familia.GotFocus
        combo_familia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_familia_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_familia.LostFocus
        combo_familia.BackColor = Color.White
    End Sub

    Private Sub Combo_subfamilia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.GotFocus
        Combo_subfamilia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_subfamilia_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.LostFocus
        Combo_subfamilia.BackColor = Color.White
    End Sub


    Private Sub txt_nombre_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_subfamilia_dos.LostFocus
        txt_nombre_subfamilia_dos.BackColor = Color.White
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
        llenar_combo_subfamilia()
        txt_nombre_subfamilia_dos.Text = ""
        actualizar_tabla()
        mostrar(0)
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


        If Combo_subfamilia.Text = "" Then
            MsgBox("CAMPO SUBFAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_subfamilia.Focus()
            Exit Sub
        End If

        If Combo_subfamilia.Text = "-" Then
            MsgBox("CAMPO SUBFAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_subfamilia.Focus()
            Exit Sub
        End If

        controles(True, False)
        VarSeleccion = 2
        btn_eliminar.Enabled = False
        btn_modificar.Enabled = False

        'txt_m.Enabled = False
        'txt_o.Enabled = False
        txt_nombre_subfamilia_dos.Focus()
    End Sub

    Private Sub Combo_subfamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.SelectedIndexChanged
        txt_nombre_subfamilia_dos.Text = ""
        mostrar_codigo_subfamilia()
        actualizar_tabla()
        mostrar(0)
    End Sub

    Private Sub txt_nombre_subfamilia_dos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_subfamilia_dos.TextChanged

    End Sub

    Private Sub txt_m_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_m.KeyPress
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
    End Sub

    Private Sub txt_m_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_m.TextChanged

    End Sub

    Private Sub txt_o_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_o.KeyPress
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
    End Sub

    Private Sub txt_o_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_o.TextChanged

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Form_buscador_subfamilia_dos.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txt_medida_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_medida_3.KeyPress
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

    Private Sub txt_medida_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_medida_3.TextChanged

    End Sub

    Private Sub txt_medida_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_medida_2.KeyPress
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

    Private Sub txt_medida_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_medida_2.TextChanged

    End Sub

    Private Sub txt_medida_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_medida_1.KeyPress
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

    Private Sub txt_medida_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_medida_1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_volumen.KeyPress
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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_volumen.TextChanged

    End Sub
End Class