Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_buscador_usuarios
    Dim mitexto As String
    Dim micampo As String

    Private Sub form_buscar_usuarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        form_registro_usuarios.WindowState = FormWindowState.Normal
    End Sub

    Private Sub form_buscar_usuarios_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    'damos por defectemos el chekeo al radio todos.
    'llamamos el mostrar malla.
    Private Sub form_buscar_usuarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        radio_nombre.Checked = True
        Combocriterio.Text = "CUALQUIER PARTE DEL CAMPO"
        mostrar_malla()
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    'realizamos la consutla sql para llenar la grilla con los datos.
    Sub mostrar_malla()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select rut_usuario as Rut, nombre_usuario as Nombre, usuario as Usuario, clave as Clave, TIPO as TIPO from usuarios"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        migrilla.DataSource = DS.Tables(DT.TableName)
        conexion.Close()
    End Sub

    'asignamos nos radiobutton con los respectivos campos.
    Sub opciones()
        If radio_rut.Checked = True Then
            micampo = "rut_usuario"
        ElseIf radio_nombre.Checked = True Then
            micampo = "nombre_usuario"
        ElseIf radio_usuario.Checked = True Then
            micampo = "usuario"
        ElseIf radio_clave.Checked = True Then
            micampo = "clave"
        End If
        criterio()
    End Sub

    'indicamos las acciones a seguir segun el valor que se selecicone en el combobox.
    Sub criterio()
        If txt_buscar.Text <> "" Then
            If Combocriterio.Text = "CUALQUIER PARTE DEL CAMPO" Then
                mitexto = "%" & txt_buscar.Text & "%"
            ElseIf Combocriterio.Text = "AL COMIENZO DEL CAMPO" Then
                mitexto = txt_buscar.Text & "%"
            Else
                mitexto = txt_buscar.Text
            End If

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()

            conexion.Open()

            If radio_todos.Checked = True Then

                SC.Connection = conexion
                SC.CommandText = "select rut_usuario as Rut, nombre_usuario as Nombre, usuario as Usuario, clave as Clave, TIPO as TIPO from usuarios"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
            Else
                SC.Connection = conexion
                SC.CommandText = "select rut_usuario as Rut, nombre_usuario as Nombre, usuario as Usuario, clave as Clave, TIPO as TIPO from usuarios where " & (micampo) & "  Like '" & (mitexto) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
            End If
            migrilla.DataSource = DS.Tables(DT.TableName)
            conexion.Close()
        End If
    End Sub

    'volvemos al formuario anterior con los datos encontrados.
    Private Sub btn_volver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_volver.Click

        form_registro_usuarios.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    'llamamos al sub opciones.
    Private Sub opciones_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        opciones()
    End Sub





    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub txt_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar.TextChanged
        opciones()
    End Sub



    Private Sub Combocriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combocriterio.SelectedIndexChanged
        opciones()
    End Sub

    Private Sub radio_rut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_rut.CheckedChanged
        opciones()
    End Sub

    Private Sub radio_nombre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_nombre.CheckedChanged
        opciones()
    End Sub

    Private Sub radio_usuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_usuario.CheckedChanged
        opciones()
    End Sub

    Private Sub radio_clave_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_clave.CheckedChanged
        opciones()
    End Sub

    Private Sub radio_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_todos.CheckedChanged
        opciones()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        form_registro_usuarios.WindowState = FormWindowState.Normal
        Form_menu_principal.WindowState = FormWindowState.Minimized
        Me.Close()
    End Sub

    Private Sub migrilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles migrilla.CellContentClick

    End Sub

    Private Sub migrilla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles migrilla.Click
        form_registro_usuarios.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

End Class