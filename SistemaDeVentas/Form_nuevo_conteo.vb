Public Class Form_nuevo_conteo

    Private Sub Form_nuevo_conteo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_conteos_arana.WindowState = FormWindowState.Normal
        Form_conteos_arana.Enabled = True
    End Sub

    Private Sub Form_nuevo_conteo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_nuevo_conteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_familia()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
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
        SC3.CommandText = "select * from familia order by nombre_familia"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        Combo_familia.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_familia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_familia"))
            Next
        End If
        'Combo_familia.SelectedItem = "SIN FAMILIA"
        Combo_familia.SelectedItem = "-"
        conexion.Close()
    End Sub

    Sub mostrar_codigo_familia()
        If Combo_familia.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from familia where nombre_familia ='" & (Combo_familia.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_codigo_familia.Text = DS2.Tables(DT2.TableName).Rows(0).Item("codigo")
            End If
            conexion.Close()
        Else
            txt_codigo_familia.Text = ""
        End If
    End Sub

    Sub llenar_combo_subfamilia()
        If Combo_familia.Text <> "-" Then
            conexion.Close()
            Combo_subfamilia.Items.Clear()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = "select * from subfamilia where codigo_familia='" & (txt_codigo_familia.Text) & "' order by nombre_subfamilia"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            Combo_subfamilia.Items.Add("SIN SUB FAMILIA")
            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                    Combo_subfamilia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
                Next
            End If
            conexion.Close()
            Combo_subfamilia.Items.Add("-")
            Combo_subfamilia.SelectedItem = "-"
        Else
            Combo_subfamilia.Items.Clear()
            Combo_subfamilia.Items.Add("-")
            Combo_subfamilia.SelectedItem = "-"
        End If
    End Sub

    Sub mostrar_codigo_subfamilia()
        If Combo_subfamilia.Text <> "-" Then
            conexion.Close()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = "select * from subfamilia where nombre_subfamilia ='" & (Combo_subfamilia.Text) & "'"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia.Text = DS3.Tables(DT3.TableName).Rows(0).Item("cod_auto")
            End If
            conexion.Close()
        Else
            txt_codigo_subfamilia.Text = ""
        End If
    End Sub

    Sub mostrar_codigo_subfamilia2()
        If Combo_subfamilia_2.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia_dos where nombre_subfamilia ='" & (Combo_subfamilia_2.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia_2.Text = DS2.Tables(DT2.TableName).Rows(0).Item("cod_auto")
            End If
            conexion.Close()
        Else
            txt_codigo_subfamilia_2.Text = ""
        End If
    End Sub

    Sub llenar_combo_subfamilia2()
        If Combo_subfamilia.Text <> "-" Then
            conexion.Close()
            Combo_subfamilia_2.Items.Clear()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = "select * from subfamilia_dos where codigo_subfamilia='" & (txt_codigo_subfamilia.Text) & "' order by nombre_subfamilia"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            Combo_subfamilia_2.Items.Add("SIN SUB FAMILIA DOS")
            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                    Combo_subfamilia_2.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
                Next
            End If
            conexion.Close()
            Combo_subfamilia_2.Items.Add("-")
            Combo_subfamilia_2.SelectedItem = "-"
        Else
            Combo_subfamilia_2.Items.Clear()
            Combo_subfamilia_2.Items.Add("-")
            Combo_subfamilia_2.SelectedItem = "-"
        End If
    End Sub

    Sub mostrar_subfamilia_dos()
        If txt_codigo_subfamilia_2.Text <> "" And txt_codigo_subfamilia_2.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia_dos where cod_auto ='" & (txt_codigo_subfamilia_2.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                Combo_subfamilia_2.SelectedItem = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_subfamilia")
            End If

            conexion.Close()
        End If
    End Sub

    Private Sub Combo_familia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_familia.SelectedIndexChanged
        mostrar_codigo_familia()
        llenar_combo_subfamilia()
        txt_contar.Text = ""
    End Sub

    Private Sub Combo_subfamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.SelectedIndexChanged
        mostrar_codigo_subfamilia()
        llenar_combo_subfamilia2()
        txt_contar.Text = ""
    End Sub

    Private Sub Combo_subfamilia_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia_2.SelectedIndexChanged
        mostrar_codigo_subfamilia2()
        txt_contar.Text = ""
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If Combo_familia.Text = "-" Then
            MsgBox("CAMPO FAMILIA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_familia.Focus()
            Exit Sub
        End If

        If txt_contar.Text = "" Then
            MsgBox("CAMPO CONTAR VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_contar.Focus()
            Exit Sub
        End If

        Me.Enabled = False
        Form_conteos_arana.controles(False, True)
        Form_conteos_arana.Combo_familia.Text = Combo_familia.Text
        Form_conteos_arana.Combo_subfamilia.Text = Combo_subfamilia.Text
        Form_conteos_arana.Combo_subfamilia_2.Text = Combo_subfamilia_2.Text
        Form_conteos_arana.dtp_fecha_conteo.Text = dtp_fecha_conteo.Text
        Form_conteos_arana.dtp_desde.Text = dtp_desde.Text
        Form_conteos_arana.dtp_hasta.Text = dtp_hasta.Text
        Form_conteos_arana.txt_contar.Text = txt_contar.Text

        Form_conteos_arana.fecha()
        Form_conteos_arana.mostrar_malla_negativos()
        Form_conteos_arana.mostrar_malla_mas_rotados()
        Form_conteos_arana.malla_subfamilias_dos_rotadas()
        Form_conteos_arana.mostrar_malla_conteos()
        Form_conteos_arana.calcular_totales()

        Me.Close()
    End Sub
End Class