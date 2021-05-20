Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_registro_cliente_retira_guias_traslado
    Dim VarSeleccion As Integer
    Dim MiPos As Integer

    Private Sub Form_registro_cliente_retira_guias_traslado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Form_guias_traslado.Enabled = True
        Form_guias_traslado.WindowState = FormWindowState.Normal
        Form_guias_traslado.txt_rut_retira.Focus()
    End Sub

    Private Sub Form_registro_cliente_retira_guias_traslado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

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

    Private Sub Form_registro_cliente_retira_guias_traslado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexion.Close()
        controles(False, True)
        cargar_logo()
        VarSeleccion = 1
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_datos_clientes_retira()
        If txt_rut_cliente_retira.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes_retira where rut_cliente_retira ='" & (txt_rut_cliente_retira.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_cliente_retira.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente_retira")
                txt_nombres.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente_retira")
                txt_rut_cliente_retira.Enabled = False
                txt_nombres.Enabled = True
                txt_apellidos.Enabled = False
                txt_nombres.Focus()
            Else
                MsgBox("RUT NO EXISTENTE", 0 + 16, "ERROR")
                conexion.Close()
            End If
            conexion.Close()
        End If
    End Sub

    'este sub permite realizar el cambio en los controles cuando se necesite.
    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        'btn_eliminar.Enabled = b
        btn_modificar.Enabled = b

        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a

        txt_apellidos.Enabled = a

        txt_nombres.Enabled = a
        txt_rut_cliente_retira.Enabled = a
        ' txt_rut_empresa.Enabled = a
    End Sub

    'limpiamos los datos de la pantalla.
    Sub limpiar()
        txt_nombres.Text = ""
        txt_rut_cliente_retira.Text = ""
        txt_apellidos.Text = ""
    End Sub

    'limpiamos los datos de la pantalla.
    'hacemos un cambio de los controles.
    'seleccionamos varseleccion1 que es para ingresar datos.
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
        controles(True, False)
        VarSeleccion = 1
        txt_rut_cliente_retira.Focus()
    End Sub

    'limpiamos los datos de la pantalla.
    'hacemos un cambio de los controles.
    'seleccionamos varseleccion1 que es para ingresar datos.
    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        controles(True, False)
        VarSeleccion = 2
        txt_rut_cliente_retira.Enabled = True
        txt_nombres.Enabled = False
        txt_apellidos.Enabled = False
        lbl_apellidos.Visible = False
        txt_apellidos.Visible = False

        lbl_rut.Location = New Point(7, 53)
        txt_rut_cliente_retira.Location = New Point(7, 71)
        lbl_nombre.Location = New Point(7, 129)
        txt_nombres.Location = New Point(7, 147)
        txt_rut_cliente_retira.Focus()
    End Sub

    'eliminamos el registro seleccionado donde el rut sea igual al del textbox del cliente que retira.
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

        If valormensaje = vbYes Then
            SC.Connection = conexion
            SC.CommandText = "delete from clientes_retira where rut_cliente_retira = '" & (txt_rut_cliente_retira.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            limpiar()
        End If

    End Sub

    'verificamos que los campos esten correctamente llenados y que no esten vacios, y luego seleccionamos el TIPO de varseleccion que se desee entre modificar y crear nuevo.
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If VarSeleccion = 1 Then

            If txt_rut_cliente_retira.Text = "" Then
                MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
                txt_rut_cliente_retira.Focus()
                Exit Sub
            End If

            If txt_nombres.Text = "" Then
                MsgBox("CAMPO NOMBRES VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
                txt_nombres.Focus()
                Exit Sub
            End If

            If txt_apellidos.Text = "" Then
                MsgBox("CAMPO APELLIDOS VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
                txt_apellidos.Focus()
                Exit Sub
            End If

            If valida_rut(txt_rut_cliente_retira.Text) = False Then
                txt_rut_cliente_retira.Focus()
                txt_rut_cliente_retira.SelectAll()
                Exit Sub
            End If

            conexion.Close()
            Consultas_SQL("select * from clientes_retira where rut_cliente_retira= '" & (txt_rut_cliente_retira.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                MsgBox("REGISTRO YA EXISTE", 0 + 16, "ERROR")
                controles(True, False)
                txt_rut_cliente_retira.Focus()
                txt_rut_cliente_retira.SelectAll()
                Exit Sub
            End If

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO clientes_retira (rut_cliente_retira, nombre_cliente_retira) VALUES  ('" & (txt_rut_cliente_retira.Text) & "','" & (txt_apellidos.Text & " " & txt_nombres.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES QUE RETIRAN','CREACION DE CLIENTE QUE RETIRA','" & (txt_rut_cliente_retira.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            controles(False, True)
            ' MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            Form_guias_traslado.txt_rut_retira.Text = txt_rut_cliente_retira.Text
            Form_guias_traslado.mostrar_datos_retira()
            Me.Close()
        End If


        If VarSeleccion = 2 Then

            If txt_rut_cliente_retira.Text = "" Then
                MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
                txt_rut_cliente_retira.Focus()
                Exit Sub
            End If

            If txt_nombres.Text = "" Then
                MsgBox("CAMPO NOMBRES VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
                txt_nombres.Focus()
                Exit Sub
            End If

            SC.Connection = conexion
            SC.CommandText = "UPDATE clientes_retira SET nombre_cliente_retira='" & (txt_nombres.Text) & "'WHERE rut_cliente_retira = '" & (txt_rut_cliente_retira.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            ' MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            controles(False, True)
            Form_guias_traslado.txt_rut_retira.Text = txt_rut_cliente_retira.Text
            Form_guias_traslado.mostrar_datos_retira()
            Me.Close()
        End If

    End Sub



    'hacemos el cambi de los controles.
    ' volvemos a la posicion 0.
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        lbl_apellidos.Visible = True
        txt_apellidos.Visible = True

        lbl_rut.Location = New Point(7, 36)
        txt_rut_cliente_retira.Location = New Point(7, 54)

        lbl_nombre.Location = New Point(7, 101)
        txt_nombres.Location = New Point(7, 119)

        lbl_apellidos.Location = New Point(7, 166)
        txt_apellidos.Location = New Point(7, 184)
    End Sub

    'salimos de l pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    'llamamos al sub que realizara el filtro al digitar el rut.
    Private Sub combo_rut_empresa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'mostramos los datos de los clientes.
    ' le otorgamos al texbox el valor del combobox.
    Private Sub txt_rut_retira_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente_retira.KeyPress

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
                guion_rut()
                txt_nombres.Focus()
            End If
            If VarSeleccion = 2 Then
                guion_rut()
                mostrar_datos_clientes_retira()
            End If
        End If
    End Sub

    Sub guion_rut()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_cliente_retira.Text
        If rut_cliente.Length > 2 Then
            guion = rut_cliente(rut_cliente.Length - 2).ToString()
            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_cliente_retira.Text = rut_cliente
            End If
        End If
    End Sub

    'validamos el rut que ingresamos en el txtrut.
    Private Sub txt_rut_retira_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente_retira.Validated

    End Sub

    'llamamos al formulario para buscafr el lciente.
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_buscador_clientes_ventas.Show()
        Me.WindowState = FormWindowState.Minimized
        ' Form_buscar_clientes2.txt_buscar.Focus()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub txt_rut_retira_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente_retira.GotFocus
        txt_rut_cliente_retira.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nombre_retira_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombres.GotFocus
        txt_nombres.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_retira_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente_retira.LostFocus
        txt_rut_cliente_retira.BackColor = Color.White
    End Sub

    Private Sub txt_nombres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombres.KeyPress
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

    Private Sub txt_nombre_retira_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombres.LostFocus
        txt_nombres.BackColor = Color.White
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



    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_eliminar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_eliminar.BackColor = Color.WhiteSmoke
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

    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")> _
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Public Function GetInactiveTime() As Nullable(Of TimeSpan)
        Dim info As LASTINPUTINFO = New LASTINPUTINFO
        info.cbSize = CUInt(Marshal.SizeOf(info))
        If (GetLastInputInfo(info)) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
        Else
            Return Nothing
        End If
    End Function



    Private Sub txt_rut_cliente_retira_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente_retira.TextChanged

    End Sub

    Private Sub txt_nombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombres.TextChanged

    End Sub

    Private Sub txt_apellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_apellidos.TextChanged

    End Sub


End Class