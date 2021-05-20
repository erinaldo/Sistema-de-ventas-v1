Imports System.IO
Imports System.Drawing.Drawing2D
Public Class Form_cambiar_de_usuario

    Private Sub Form_cambiar_de_usuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_venta.Enabled = True
        Form_venta.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_cambiar_de_usuario_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

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
            '    form_Menu_admin.Enabled = False
            Form_menu_principal.Close()

        End If
    End Sub

    Private Sub Form_cambiar_de_usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_vendedor()
        Combo_vendedor.SelectedItem = minombre
        txt_area.Text = miarea

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub


    Sub llenar_combo_vendedor()

        Dim area_de_usuario As String

        Combo_vendedor.Items.Clear()
        Combo_vendedor.Items.Add("-")

        'Combo_asistente.Items.Clear()
        'Combo_asistente.Items.Add("-")

        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios where nombre_USUARIO <> 'SISTEMA' order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            If miarea <> "ventas" Or miarea <> "ventas y flexibles" Then
                Combo_vendedor.Items.Add(minombre)
                ' Combo_asistente.Items.Add(minombre)
            End If
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                area_de_usuario = DS3.Tables(DT3.TableName).Rows(i).Item("area_usuario")

                If area_de_usuario = "VENTAS" Then
                    Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
                End If
                If area_de_usuario = "CALL CENTER" Then
                    Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
                End If
                ' Combo_asistente.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        conexion.Close()
    End Sub

    Sub mostrar_datos_vendedor()
        conexion.Close()
        If Combo_vendedor.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where nombre_usuario ='" & (Combo_vendedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
                txt_area.Text = DS.Tables(DT.TableName).Rows(0).Item("area_usuario")
            End If

            conexion.Close()
        End If
    End Sub


    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        mostrar_datos_vendedor()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If Combo_vendedor.Text = "-" Then

            Form_venta.lbl_asistencia.Text = ""

            Form_venta.txt_rut_vendedor.Text = miusuario
            Form_venta.txt_nombre_usuario.Text = minombre
            Form_venta.lbl_usuario.Text = minombre & vbCrLf & miarea

        Else

            Form_venta.lbl_usuario.Text = Combo_vendedor.Text & vbCrLf & txt_area.Text
            Form_venta.txt_rut_vendedor.Text = txt_rut_vendedor.Text
            Form_venta.txt_nombre_usuario.Text = Combo_vendedor.Text
        End If
        cargar_foto()
        Me.Close()
    End Sub

    Sub cargar_foto()
        Dim ruta_fotografia As String = ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select ruta_imagen_fotografia from rutas_imagenes"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            ruta_fotografia = DS.Tables(DT.TableName).Rows(0).Item("ruta_imagen_fotografia")
        End If
        conexion.Close()

        ruta_fotografia = ruta_fotografia & txt_rut_vendedor.Text & ".jpg"

        Try
            If File.Exists(ruta_fotografia) = False Then
                Form_venta.PictureBox_imagen.ImageLocation = "C:\Sistema de ventas\Imagenes de usuarios\Usuario.jpg"
            Else
                Form_venta.PictureBox_imagen.ImageLocation = ruta_fotografia
            End If
        Catch

        End Try

    End Sub
End Class