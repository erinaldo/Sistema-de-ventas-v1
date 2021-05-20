Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_call_center

    Private Sub Forrm_asistencia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_venta.Enabled = True
        Form_venta.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Forrm_asistencia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp


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

    Private Sub Forrm_asistencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_vendedor()

        Combo_asistente.SelectedItem = "-"
        Combo_nivel_asistencia.SelectedItem = "-"
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If Combo_asistente.Text <> "-" Then
            If Combo_nivel_asistencia.Text = "-" Then
                MsgBox("DEBE SELECCIONAR UN NIVEL DE ASISTENCIA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub

            End If
        End If

        If Combo_nivel_asistencia.Text <> "-" Then
            If Combo_asistente.Text = "-" Then
                MsgBox("DEBE SELECCIONAR UN ASISTENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub

            End If
        End If


        If Combo_nivel_asistencia.Text = "-" Then
            Form_venta.lbl_asistencia.Text = "CALL CENTER" & vbCrLf & "-"

            Form_venta.txt_rut_asistente.Text = txt_rut_asistente.Text
            Form_venta.Combo_nivel_asistencia.Text = Combo_nivel_asistencia.Text

        Else

            Form_venta.lbl_asistencia.Text = "NIVEL DE ASISTENCIA " & Combo_nivel_asistencia.Text & vbCrLf & Combo_asistente.Text

            Form_venta.txt_rut_asistente.Text = txt_rut_asistente.Text
            Form_venta.Combo_nivel_asistencia.Text = Combo_nivel_asistencia.Text
        End If
        Me.Close()
    End Sub

    Sub llenar_combo_vendedor()
        'Combo_vendedor.Items.Clear()
        'Combo_vendedor.Items.Add("-")

        Combo_asistente.Items.Clear()
        Combo_asistente.Items.Add("-")

        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios where nombre_USUARIO <> 'SISTEMA' and AREA_usuario LIKE '%CALL CENTER%' order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                'Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
                Combo_asistente.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        conexion.Close()

    End Sub

    Private Sub Combo_asistente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_asistente.SelectedIndexChanged
        If Combo_nivel_asistencia.Text = "-" Then

            Combo_asistente.SelectedItem = "-"
            '  MsgBox("DEBE SELECCIONAR UN NIVEL DE ASISTENCIA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub

        End If

        mostrar_datos_asistente()
    End Sub

    Private Sub Combo_nivel_asistencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_nivel_asistencia.SelectedIndexChanged
        If Combo_nivel_asistencia.Text = "-" Then
            Combo_asistente.SelectedItem = "-"
        End If


        If Form_venta.Combo_venta.Text = "COTIZACION" Then
            Combo_asistente.SelectedItem = minombre
            ' Combo_asistente.Enabled = False
        Else
            'Combo_asistente.SelectedItem = "-"
            ' Combo_asistente.Enabled = True
        End If





    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Sub mostrar_datos_asistente()
        conexion.Close()
        If Combo_asistente.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where nombre_usuario ='" & (Combo_asistente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_asistente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If

            conexion.Close()
        End If

        If Combo_asistente.Text = "-" Then
            txt_rut_asistente.Text = "-"
        End If
    End Sub
End Class