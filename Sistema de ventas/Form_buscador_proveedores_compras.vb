﻿Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_buscador_proveedores_compras
    Dim consulta_busqueda As String

    Private Sub Form_buscar_proveedores_compras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_registro_proveedores_compra.WindowState = FormWindowState.Normal
        Form_registro_proveedores_compra.Enabled = True
    End Sub

    Private Sub Form_buscar_proveedores_compras_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_buscar_proveedores_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        migrilla.Font = New System.Drawing.Font("Arial", 10.25!, System.Drawing.FontStyle.Regular)
        txt_busqueda.Focus()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        buscar()
        'lbl_resultado.Location = New Point(1024 - lbl_resultado.Width - 7, 30)
    End Sub







    'Sub buscar()

    '    'If txt_comuna.Text = "" And txt_correo.Text = "" And txt_direccion.Text = "" And txt_giro.Text = "" And txt_nombre.Text = "" And txt_rut.Text = "" And txt_telefono.Text = "" And Combo_tipo.Text = "" Then
    '    '    Exit Sub
    '    'End If

    '    'If txt_nombre.Text = "" Then
    '    '    'MsgBox("COMO MINIMO DEBE ASIGNAR UN NOMBRE A LA BUSQUEDA", MsgBoxStyle.Critical, "INFORMACION")
    '    '    'txt_nombre.Focus()
    '    '    'Exit Sub
    '    '    ' txt_nombre.Text = "*"
    '    'End If


    '    lbl_resultado.Visible = True
    '    lbl_resultado.Text = "ESPERE POR FAVOR..."
    '    Me.Enabled = False

    '    If txt_nombre.Text <> "" Then
    '        campo_nombre = "%" & txt_nombre.Text & "%"
    '    End If

    '    If txt_direccion.Text <> "" Then
    '        campo_direccion = "%" & txt_direccion.Text & "%"
    '    End If

    '    If txt_comuna.Text <> "" Then
    '        campo_comuna = "%" & txt_comuna.Text & "%"
    '    End If

    '    If txt_rut.Text <> "" Then
    '        campo_rut = "%" & txt_rut.Text & "%"
    '    End If

    '    If txt_giro.Text <> "" Then
    '        campo_giro = "%" & txt_giro.Text & "%"
    '    End If

    '    If txt_correo.Text <> "" Then
    '        campo_correo = "%" & txt_correo.Text & "%"
    '    End If

    '    If txt_telefono.Text <> "" Then
    '        campo_telefono = "%" & txt_telefono.Text & "%"
    '    End If

    '    If Combo_tipo.Text <> "" Then
    '        campo_tipo = "%" & Combo_tipo.Text & "%"
    '    End If


    '    consulta_busqueda = "SELECT RUT_CLIENTE AS RUT,  cod_CLIENTE AS 'COD. CLIENTE', NOMBRE_CLIENTE AS NOMBRE, DIRECCION_CLIENTE AS DIRECCION, EMAIL_CLIENTE AS EMAIL, COMUNA_CLIENTE AS COMUNA, TELEFONO_CLIENTE AS TELEFONO,  GIRO_CLIENTE AS GIRO, CIUDAD_CLIENTE AS CIUDAD FROM CLIENTES WHERE"


    '    Dim fin_consulta As String

    '    fin_consulta = Strings.Right(consulta_busqueda, 5)
    '    'If fin_consulta = "WHERE" Then
    '    '    Exit Sub
    '    'End If


    '    ' If txt_nombre.Text <> "" Then
    '    ' End If

    '    'If txt_nombre.Text <> "" Then




    '    '    ' consulta_busqueda = consulta_busqueda & " and NOMBRE_CLIENTE like '" & (campo_nombre) & "'"
    '    'End If


    '    If txt_nombre.Text <> "" Then

    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " NOMBRE_CLIENTE like '" & (campo_nombre) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and NOMBRE_CLIENTE like '" & (campo_nombre) & "'"
    '        End If
    '        '  consulta_busqueda = consulta_busqueda & " and direccion_CLIENTE= '" & (campo_direccion) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If




    '    If txt_direccion.Text <> "" Then

    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " direccion_CLIENTE like '" & (campo_direccion) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and direccion_CLIENTE like '" & (campo_direccion) & "'"
    '        End If
    '        '  consulta_busqueda = consulta_busqueda & " and direccion_CLIENTE= '" & (campo_direccion) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If


    '    If txt_comuna.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " COMUNA_CLIENTE like '" & (campo_comuna) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and COMUNA_CLIENTE like '" & (campo_comuna) & "'"
    '        End If

    '        ' consulta_busqueda = consulta_busqueda & " and COMUNA_CLIENTE like '" & (campo_comuna) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If


    '    If txt_rut.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " rut_CLIENTE like '" & (campo_rut) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and rut_CLIENTE like '" & (campo_rut) & "'"
    '        End If

    '        ' consulta_busqueda = consulta_busqueda & " and rut_CLIENTE like '" & (campo_rut) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If

    '    If txt_giro.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " giro_CLIENTE like '" & (campo_giro) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and giro_CLIENTE like '" & (campo_giro) & "'"
    '        End If

    '        'consulta_busqueda = consulta_busqueda & " and giro_CLIENTE like '" & (campo_giro) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If

    '    If txt_correo.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " EMAIL_CLIENTE like '" & (campo_correo) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and EMAIL_CLIENTE like '" & (campo_correo) & "'"
    '        End If

    '        '  consulta_busqueda = consulta_busqueda & " and EMAIL_CLIENTE like '" & (campo_correo) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If



    '    If txt_telefono.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " telefono_CLIENTE like '" & (campo_telefono) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and telefono_CLIENTE like '" & (campo_telefono) & "'"
    '        End If


    '        '   consulta_busqueda = consulta_busqueda & " and telefono_CLIENTE like '" & (campo_telefono) & "'"

    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If

    '    If Combo_tipo.Text <> "" Then
    '        fin_consulta = Strings.Right(consulta_busqueda, 5)
    '        If fin_consulta = "WHERE" Then
    '            consulta_busqueda = consulta_busqueda & " tipo_CLIENTE like '" & (campo_tipo) & "'"
    '        Else
    '            consulta_busqueda = consulta_busqueda & " and tipo_CLIENTE like '" & (campo_tipo) & "'"
    '        End If

    '        ' consulta_busqueda = consulta_busqueda & " and tipo_CLIENTE like '" & (campo_tipo) & "'"
    '    Else
    '        consulta_busqueda = consulta_busqueda
    '    End If

    '    ' consulta_busqueda = consulta_busqueda & " group by cod_producto"

    '    fin_consulta = Strings.Right(consulta_busqueda, 5)

    '    If fin_consulta = "WHERE" Then
    '        Me.Enabled = True
    '        lbl_resultado.Visible = False
    '        txt_nombre.Focus()
    '        Exit Sub
    '    End If







    '    Dim DT As New DataTable

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = consulta_busqueda
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    migrilla.DataSource = DS.Tables(DT.TableName)
    '    conexion.Close()

    '    lbl_resultado.Visible = True
    '    lbl_resultado.Text = "SE ENCONTRARON " & migrilla.Rows.Count & " RESULTADOS"

    '    If migrilla.Rows.Count = 0 Then
    '        lbl_resultado.ForeColor = Color.Red
    '        lbl_resultado.Text = "NO SE ENCONTRARON RESULTADOS"
    '    ElseIf migrilla.Rows.Count = 1 Then
    '        lbl_resultado.Text = "SE ENCONTRO 1 RESULTADO"
    '        lbl_resultado.ForeColor = Color.Black
    '    Else
    '        lbl_resultado.ForeColor = Color.Black
    '    End If

    '    Combo_tipo.Text = ""

    '    txt_comuna.Text = ""
    '    txt_correo.Text = ""
    '    txt_direccion.Text = ""
    '    txt_giro.Text = ""
    '    txt_nombre.Text = ""
    '    txt_rut.Text = ""
    '    txt_telefono.Text = ""

    '    ' lbl_mensaje.Visible = False
    '    'For i = 0 To migrilla.Rows.Count - 1
    '    '    migrilla.CurrentRow.Cells(0).Selected = True
    '    '    migrilla.Focus()


    '    Me.Enabled = True
    '    migrilla.Focus()
    '    Exit Sub
    'End Sub



    Sub buscar()
        lbl_mensaje.Visible = True
        lbl_resultado.Visible = True
        lbl_resultado.Text = "ESPERE POR FAVOR..."
        Me.Enabled = False
        If txt_busqueda.Text <> "" Then

            consulta_busqueda = "SELECT RUT_PROVEEDOR AS RUT, NOMBRE_PROVEEDOR AS NOMBRE, DIRECCION_PROVEEDOR AS DIRECCION, EMAIL_PROVEEDOR AS EMAIL, COMUNA_PROVEEDOR AS COMUNA, TELEFONO_PROVEEDOR AS TELEFONO,  GIRO_PROVEEDOR AS GIRO, CIUDAD_PROVEEDOR AS CIUDAD ,  GIRO_PROVEEDOR AS GIRO, REPRESENTANTE_PROVEEDOR AS REPRESENTANTE FROM PROVEEDORES WHERE"

            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_busqueda.Text
            '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")
            '  RUT_PROVEEDOR, NOMBRE_PROVEEDOR, DIRECCION_PROVEEDOR, EMAIL_PROVEEDOR, COMUNA_PROVEEDOR, TELEFONO_PROVEEDOR, GIRO_PROVEEDOR, CIUDAD_PROVEEDOR, GIRO_PROVEEDOR, REPRESENTANTE_PROVEEDOR
            For n = 0 To UBound(tabla, 1)
                Dim fin_consulta As String
                fin_consulta = Strings.Right(consulta_busqueda, 5)
                If fin_consulta = "WHERE" Then
                    consulta_busqueda = consulta_busqueda & " CONCAT_WS(' ', RUT_PROVEEDOR, NOMBRE_PROVEEDOR, DIRECCION_PROVEEDOR, EMAIL_PROVEEDOR, COMUNA_PROVEEDOR, TELEFONO_PROVEEDOR, GIRO_PROVEEDOR, CIUDAD_PROVEEDOR, GIRO_PROVEEDOR, REPRESENTANTE_PROVEEDOR) LIKE '" & ("%" & tabla(n) & "%") & "'"
                Else
                    consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ', RUT_PROVEEDOR, NOMBRE_PROVEEDOR, DIRECCION_PROVEEDOR, EMAIL_PROVEEDOR, COMUNA_PROVEEDOR, TELEFONO_PROVEEDOR, GIRO_PROVEEDOR, CIUDAD_PROVEEDOR, GIRO_PROVEEDOR, REPRESENTANTE_PROVEEDOR) LIKE '" & ("%" & tabla(n) & "%") & "'"
                End If
            Next

            migrilla.DataSource = Nothing
            conexion.Close()
            Dim DT As New DataTable

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = consulta_busqueda
            DA.SelectCommand = SC

            DA.Fill(DT)
            DS.Tables.Add(DT)

            migrilla.DataSource = DS.Tables(DT.TableName)
            conexion.Close()




            lbl_resultado.Visible = True
            lbl_resultado.Text = "SE ENCONTRARON " & migrilla.Rows.Count & " RESULTADOS"

            If migrilla.Rows.Count = 0 Then
                lbl_resultado.ForeColor = Color.Red
                lbl_resultado.Text = "NO SE ENCONTRARON RESULTADOS"
            ElseIf migrilla.Rows.Count = 1 Then
                lbl_resultado.Text = "SE ENCONTRO 1 RESULTADO"
                lbl_resultado.ForeColor = Color.Black
            Else
                lbl_resultado.ForeColor = Color.Black
            End If

            ' lbl_resultado.Visible = False
            lbl_mensaje.Visible = False
            Me.Enabled = True




            If migrilla.Rows.Count > 0 Then
                migrilla.Focus()
            End If
            Exit Sub
        End If
    End Sub

    Private Sub migrilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles migrilla.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub migrilla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles migrilla.DoubleClick
        Dim codigo As String
        If migrilla.Rows.Count <= 0 Then
            Form_registro_proveedores_compra.txt_rut.Focus()
            Me.Close()
        Else
            codigo = migrilla.CurrentRow.Cells(0).Value
            Form_registro_proveedores_compra.LIMPIAR()
            Form_registro_proveedores_compra.txt_rut.Text = codigo
            MOSTRAR_DATOS_PROVEEDOR()
            Me.Close()
        End If
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub





    Private Sub migrilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles migrilla.CellContentClick

    End Sub

    Private Sub migrilla_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles migrilla.Enter

    End Sub

    Private Sub migrilla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles migrilla.KeyPress
        'If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
        '    Dim codigo As String

        '    If migrilla.Rows.Count <= 0 Then
        '        Me.Close()
        '        Form_venta.txt_codigo.Focus()
        '        Me.Close()
        '    Else
        '        codigo = migrilla.CurrentRow.Cells(0).Value
        '        Form_venta.limpiar_datos_clientes_enter()
        '        Form_venta.txt_rut.Text = codigo
        '        Form_venta.txt_descto.Text = "0"
        '        Form_venta.mostrar_datos_clientes()
        '        ' Form_venta.llenar_combo_retira()
        '        Form_venta.limpiar_datos_clientes_retira()
        '        Form_venta.guardar_descuento()
        '        Form_venta.grilla_detalle.Rows.Clear()
        '        Form_venta.cargar_descuento()
        '        Form_venta.calcular_totales()
        '        Me.Close()
        '    End If
        'End If
    End Sub



    Sub MOSTRAR_DATOS_PROVEEDOR()

        conexion.Close()


        Dim codigo As String
        Dim rut As String

        codigo = migrilla.CurrentRow.Cells(1).Value
        rut = migrilla.CurrentRow.Cells(0).Value

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from proveedores where rut_proveedor ='" & (rut) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Form_registro_proveedores_compra.txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("RUT_PROVEEDOR")
            Form_registro_proveedores_compra.txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("NOMBRE_PROVEEDOR")
            Form_registro_proveedores_compra.txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("DIRECCION_PROVEEDOR")
            Form_registro_proveedores_compra.txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("TELEFONO_PROVEEDOR")
            Form_registro_proveedores_compra.txt_email.Text = DS.Tables(DT.TableName).Rows(0).Item("EMAIL_PROVEEDOR")
            '  Form_registro_proveedores_compra.txt_ciudad.Text = DS.Tables(DT.TableName).Rows(0).Item("CIUDAD_PROVEEDOR")
            Form_registro_proveedores_compra.txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("COMUNA_PROVEEDOR")
            Form_registro_proveedores_compra.txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("GIRO_PROVEEDOR")
            Form_registro_proveedores_compra.txt_representante.Text = DS.Tables(DT.TableName).Rows(0).Item("REPRESENTANTE_PROVEEDOR")
            Form_registro_proveedores_compra.txt_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("CREDITO_PROVEEDOR")
            ''form_registro_proveedores.txt_rut.Enabled = False
            ''form_registro_proveedores.txt_nombre.Enabled = True
            ''form_registro_proveedores.txt_direccion.Enabled = True
            ''form_registro_proveedores.txt_telefono.Enabled = True
            ''form_registro_proveedores.txt_email.Enabled = True
            ''form_registro_proveedores.txt_ciudad.Enabled = True
            ''form_registro_proveedores.txt_comuna.Enabled = True
            ''form_registro_proveedores.txt_giro.Enabled = True
            ''form_registro_proveedores.txt_representante.Enabled = True
            ''form_registro_proveedores.txt_credito.Enabled = True
            ''form_registro_proveedores.txt_nombre.Enabled = True
            ''form_registro_proveedores.btn_guardar.Enabled = True
            ''form_registro_proveedores.btn_guardar.Enabled = True
            'form_registro_proveedores.txt_nombre.Focus()
        End If
        conexion.Close()





    End Sub


    Private Sub VolveralmenuprincipalToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    'Private Sub txt_giro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_giro.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_giro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_giro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_giro.BackColor = Color.White
    'End Sub

    'Private Sub txt_giro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub txt_correo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_correo.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_correo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_correo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_correo.BackColor = Color.White
    'End Sub

    'Private Sub txt_correo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub txt_telefono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_telefono.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_telefono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_telefono.BackColor = Color.White
    'End Sub

    'Private Sub txt_telefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_nombre.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_nombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_nombre.BackColor = Color.White
    'End Sub

    'Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub txt_direccion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_direccion.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_direccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    Private Sub txt_busqueda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_busqueda.BackColor = Color.White
    End Sub

    Private Sub txt_busqueda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_busqueda.BackColor = Color.Yellow
    End Sub

    Private Sub txt_comuna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_comuna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_comuna.BackColor = Color.White
    'End Sub

    'Private Sub txt_comuna_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_rut.BackColor = Color.Yellow
    'End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            buscar()
        End If
    End Sub

    'Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_rut.BackColor = Color.White
    'End Sub

    'Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub Combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_tipo.BackColor = Color.Yellow
    'End Sub

    Private Sub Combo_tipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
    End Sub

    'Private Sub Combo_tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Combo_tipo.BackColor = Color.White
    'End Sub

    Private Sub Combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub migrilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles migrilla.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim codigo As String
            If migrilla.Rows.Count <= 0 Then
                Form_registro_proveedores_compra.txt_rut.Focus()
                Me.Close()
            Else
                codigo = migrilla.CurrentRow.Cells(0).Value
                Form_registro_proveedores_compra.LIMPIAR()
                Form_registro_proveedores_compra.txt_rut.Text = codigo
                MOSTRAR_DATOS_PROVEEDOR()
                Me.Close()
            End If
        End If
    End Sub


    Private Sub txt_busqueda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_busqueda.KeyPress
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

            If txt_busqueda.Text = "" Then
                Exit Sub
            End If

            buscar()
        End If
    End Sub

    Private Sub txt_busqueda_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.LostFocus
        txt_busqueda.BackColor = Color.White
    End Sub


    Private Sub txt_busqueda_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.GotFocus
        txt_busqueda.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged

    End Sub


    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

End Class