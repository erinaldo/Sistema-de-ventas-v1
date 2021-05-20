Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_registro_marcas
    Dim VarSeleccion As Integer
    Dim MiPos As Integer
    Private Sub Form_registro_marcas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_registro_marcas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_registro_marcas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actualizar_tabla()
        mostrar(0)
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
        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_marca.Text = DS.Tables(DT.TableName).Rows(i).Item("nombre_marca")
            End If
        Catch
        End Try
    End Sub



    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        btn_eliminar.Enabled = b

        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a

        txt_nombre_marca.Enabled = a

        btn_primero.Enabled = b
        btn_ultimo.Enabled = b
        btn_siguiente.Enabled = b
        btn_anterior.Enabled = b
    End Sub

    Sub limpiar()
        txt_nombre_marca.Text = ""
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
        controles(True, False)
        VarSeleccion = 1
        txt_nombre_marca.Focus()
    End Sub



    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim mensaje As String = ""

        If txt_nombre_marca.Text = "" Then mensaje = "CAMPO NOMBRE VACIO, FAVOR LLENAR" + Chr(13) & mensaje

        If mensaje <> "" Then
            MsgBox(mensaje, MessageBoxIcon.Information, "ATENCION")
        Else
            If VarSeleccion = 1 Then
                conexion.Close()
                Consultas_SQL("select * from marcas_productos where nombre_marca = '" & (txt_nombre_marca.Text) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    MsgBox("REGISTRO YA EXISTE", 0 + 16, "ERROR")

                    controles(True, False)

                Else
                    SC.CommandText = "INSERT INTO marcas_productos(nombre_marca) VALUES ('" & (txt_nombre_marca.Text) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    SC.Connection = conexion
                    SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('MARCAS','CREACION DE MARCA','" & (txt_nombre_marca.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    actualizar_tabla()
                    controles(False, True)


                    MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

                End If
            End If

        End If
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

        If valormensaje = vbYes Then
            SC.Connection = conexion
            SC.CommandText = "delete from marcas_productos where nombre_marca = '" & (txt_nombre_marca.Text) & "'"
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
        MiPos = 0
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
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
            '   mostrar_datos_especie_por_combo()
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        MiPos = DT.Rows.Count - 1
        mostrar(MiPos)
        ' mostrar_datos_especie_por_combo()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        ' form_Menu_admin.WindowState = FormWindowState.Normal
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
        SC.CommandText = "select * from marcas_productos where nombre_marca <> 'TODOS' order by nombre_marca"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
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

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_marca.GotFocus
        txt_nombre_marca.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nombre_familia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_marca.KeyPress
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

    Private Sub txt_nombre_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_marca.LostFocus
        txt_nombre_marca.BackColor = Color.White
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
        btn_anterior.BackColor = Color.Transparent
    End Sub

    Private Sub btn_anterior_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.LostFocus
        btn_anterior.BackColor = Color.Transparent
    End Sub

    Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.GotFocus
        btn_siguiente.BackColor = Color.Transparent
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

    Private Sub txt_nombre_familia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_marca.TextChanged

    End Sub

    Private Sub PictureBox_logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_logo.Click

    End Sub


End Class