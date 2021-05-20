Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_registro_ruta_documentos_electronicos
    Dim VarSeleccion As Integer
    Dim MiPos As Integer

    Private Sub Form_registro_ruta_documentos_electronicos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_registro_ruta_documentos_electronicos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_registro_ruta_documentos_electronicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


    Sub mostrar(ByVal i As Integer)
        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_ruta.Text = DS.Tables(DT.TableName).Rows(i).Item("archivo_plano_documentos_electronicos")
                txt_ruta_facturacion.Text = DS.Tables(DT.TableName).Rows(i).Item("archivo_plano_facturacion")
            End If
        Catch
        End Try
    End Sub



    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        'btn_eliminar.Enabled = b

        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a
        btnExaminar.Enabled = a
        btn_examinar_facturacion.Enabled = a

        txt_ruta.Enabled = a
        txt_ruta_facturacion.Enabled = a

    End Sub

    Sub limpiar()
        txt_ruta.Text = ""
        txt_ruta_facturacion.Text = ""
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        'limpiar()
        controles(True, False)
        VarSeleccion = 1
        txt_ruta.Focus()
    End Sub



    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If txt_ruta.Text = "" Then
            MsgBox("CAMPO RUTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            txt_ruta.Focus()
            Exit Sub
        End If

        If txt_ruta_facturacion.Text = "" Then
            MsgBox("CAMPO RUTA FACTURACION VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            txt_ruta_facturacion.Focus()
            Exit Sub
        End If

        txt_ruta.Text = Trim(Replace(txt_ruta.Text, "\", "\\"))
        txt_ruta_facturacion.Text = Trim(Replace(txt_ruta_facturacion.Text, "\", "\\"))

        Consultas_SQL("select * from rutas_archivos")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

        Else
            SC.Connection = conexion
            SC.CommandText = "INSERT INTO rutas_archivos (archivo_plano_documentos_electronicos) VALUES ('1')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        SC.Connection = conexion
        SC.CommandText = "UPDATE rutas_archivos SET archivo_plano_documentos_electronicos='" & (txt_ruta.Text) & "', archivo_plano_facturacion='" & (txt_ruta_facturacion.Text) & "' where cod_auto <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)



        actualizar_tabla()
        mostrar(0)
        controles(False, True)
        MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

    End Sub



    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        MiPos = 0

        mostrar(MiPos)
    End Sub

    Private Sub btn_primero_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MiPos = 0
        mostrar(0)
        'mostrar_datos_especie_por_combo()
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
            ' mostrar_datos_especie_por_combo()
        End If

    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
            '   mostrar_datos_especie_por_combo()
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
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
        SC.CommandText = "select * from rutas_archivos"
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

    Private Sub txt_ruta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta.GotFocus
        txt_ruta.BackColor = Color.LightSkyBlue
    End Sub


    Private Sub txt_ruta_HelpRequested(ByVal sender As Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles txt_ruta.HelpRequested

    End Sub

    Private Sub txt_nombre_familia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ruta.KeyPress
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


    Private Sub txt_ruta_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta.LostFocus
        txt_ruta.BackColor = Color.White
    End Sub











    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    Private Sub btnExaminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExaminar.GotFocus
        btnExaminar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btnExaminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExaminar.LostFocus
        btnExaminar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
    '    btn_modificar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
    '    btn_modificar.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'btn_eliminar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ' btn_eliminar.BackColor = Color.WhiteSmoke
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




    Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click
        'Try
        '    Dim openFileDialog1 As New OpenFileDialog()
        '    openFileDialog1.InitialDirectory = "C:\"
        '    openFileDialog1.FilterIndex = 4
        '    openFileDialog1.RestoreDirectory = True

        '    If openFileDialog1.ShowDialog() = DialogResult.OK Then
        '        Dim dir As String = openFileDialog1.FileName
        '        txt_ruta.Text = IO.Path.GetDirectoryName(openFileDialog1.FileName)
        '        'patch = openFileDialog1.FileName
        '        'File.Copy(dir, TextBox2.Text)
        '    Else
        '        If String.IsNullOrEmpty(openFileDialog1.FileName) Then
        '            MessageBox.Show("No ha Seleccionado ningun archivo")
        '            Return
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString())
        'End Try

        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            txt_ruta.Text = OpenFileDialog1.FileName
        End If






    End Sub

    Private Sub txt_ruta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ruta.TextChanged

    End Sub

    Private Sub txt_ruta_facturacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_facturacion.GotFocus
        txt_ruta_facturacion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_ruta_facturacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ruta_facturacion.KeyPress
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

    Private Sub txt_ruta_facturacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ruta_facturacion.LostFocus
        txt_ruta_facturacion.BackColor = Color.White
    End Sub

    Private Sub txt_ruta_facturacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ruta_facturacion.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_examinar_facturacion.Click
        Dim result As DialogResult = OpenFileDialog2.ShowDialog()
        If result = DialogResult.OK Then
            txt_ruta_facturacion.Text = OpenFileDialog2.FileName
        End If
    End Sub


End Class