Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Resources

Public Class Form_consultas
    Dim MiPos As Integer

    Private Sub Form_consultas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_consultas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub Form_consultas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_consultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_sucursales()
        controles(True, False)
        actualizar_tabla()
        mostrar(0)
    End Sub

    Sub llenar_combo_sucursales()
        Combo_sucursal.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from sucursales order by nombre_sucursal"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        ' Combo_sucursal.Items.Add("-")

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
            Next
        End If
        Combo_sucursal.SelectedItem = mirecintoempresa
        conexion.Close()
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
                txt_nombre.Text = DS.Tables(DT.TableName).Rows(i).Item("nombre")
                txt_consulta.Text = DS.Tables(DT.TableName).Rows(i).Item("consulta")
            End If
        Catch
        End Try
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        If txt_consulta.Text = "" Then
            MsgBox("CAMPO CONSULTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_consulta.Focus()
            Exit Sub
        End If

        If txt_consulta.Text.Contains("UPDATE") Then
            MsgBox("EL CONSULTA NO PUEDE CONTENER UN UPDATE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_consulta.Focus()
            Exit Sub
        End If

        If txt_consulta.Text.Contains("DELETE") Then
            MsgBox("EL CONSULTA NO PUEDE CONTENER UN DELETE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_consulta.Focus()
            Exit Sub
        End If

        If txt_consulta.Text.Contains("DROP") Then
            MsgBox("EL CONSULTA NO PUEDE CONTENER UN DROP", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_consulta.Focus()
            Exit Sub
        End If

        If txt_consulta.Text.Contains("TRUNCATE") Then
            MsgBox("EL CONSULTA NO PUEDE CONTENER UN TRUNCATE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_consulta.Focus()
            Exit Sub
        End If



        If Combo_sucursal.Text <> mirecintoempresa Then
            crear_conexion()
            CONSULTAR()
            recuperar_conexion()
        Else
            CONSULTAR()
        End If

    End Sub









    Sub CONSULTAR()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        txt_lineas.Text = ""

        Try
            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = txt_consulta.Text
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()


            If grilla_documento.Rows.Count <> 0 Then
                txt_lineas.Text = grilla_documento.Rows.Count
            End If

            If txt_lineas.Text = "" Or txt_lineas.Text = "0" Then
                txt_lineas.Text = "0"
            Else
                txt_lineas.Text = Format(Int(txt_lineas.Text), "###,###,###")
            End If





        Catch err As MySqlException
            MsgBox("OCURRIO EL SIGUIENTE ERROR EN LA CONSULTA: " & vbCrLf & vbCrLf & ErrorToString(), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        End Try



        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_documento.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            txt_consulta.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_documento, save.FileName)
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True


    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_documento.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_documento.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_documento.RowCount - 1
            For c As Integer = 0 To grilla_documento.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_documento.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_documento.DataSource = Nothing
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub txt_consulta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_consulta.GotFocus
        txt_consulta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_consulta_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_consulta.LostFocus
        txt_consulta.BackColor = Color.White
    End Sub



    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub

    Private Sub grilla_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.DoubleClick
        Form_eliminar.Show()
        Me.Enabled = False
    End Sub

    Sub crear_conexion()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String

        For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1

            nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
            nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
            base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
            clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
            usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
            recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

            recinto = Trim(Replace(recinto, "'", "´"))

            If Combo_sucursal.Text = recinto Then



                conexion.Close()
                conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                Try

                    conexion.Open()
                    conexion.Close()

                Catch

                End Try
                Exit Sub
            End If
        Next
    End Sub

    Sub recuperar_conexion()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String
        Try
            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

                If SucursalSeleccionada = recinto Then
                    Try
                        conexion.Close()
                        conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    Catch
                        conexion.Close()
                        conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    End Try
                End If
            Next
        Catch
            Me.Close()
            Form_menu_principal.Close()
        End Try
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        GroupBox2.Enabled = a
        GroupBox5.Enabled = a
        btn_nueva.Enabled = a
        btn_mostrar.Enabled = a
        btn_exportar_excel.Enabled = a
        btn_cancelar.Enabled = b
        GroupBox_clientes.Enabled = b
        btn_guardar.Enabled = b
    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        controles(False, True)
        txt_nombre.Text = ""
        txt_lineas.Text = ""
        txt_consulta.Text = ""
        txt_nombre.Focus()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(True, False)
        mostrar(MiPos)
    End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre.KeyPress
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

    Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre.TextChanged

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If txt_nombre.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre.Focus()
            Exit Sub
        End If

        If txt_consulta.Text = "" Then
            MsgBox("CAMPO CONSULTA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_consulta.Focus()
            Exit Sub
        End If


        lbl_mensaje.Visible = True
        Me.Enabled = False

        txt_lineas.Text = ""

        Try
            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = txt_consulta.Text
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()


            If grilla_documento.Rows.Count <> 0 Then
                txt_lineas.Text = grilla_documento.Rows.Count
            End If

            If txt_lineas.Text = "" Or txt_lineas.Text = "0" Then
                txt_lineas.Text = "0"
            Else
                txt_lineas.Text = Format(Int(txt_lineas.Text), "###,###,###")
            End If





        Catch err As MySqlException

            lbl_mensaje.Visible = False
            Me.Enabled = True

            MsgBox("OCURRIO EL SIGUIENTE ERROR EN LA CONSULTA: " & vbCrLf & vbCrLf & ErrorToString(), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

            Exit Sub
        End Try

        txt_consulta.Text = Trim(Replace(txt_consulta.Text, "'", "''"))

        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `consultas_sql` (`nombre`, `consulta`) VALUES ('" & (txt_nombre.Text) & "', '" + txt_consulta.Text + "');"
        DA.SelectCommand = SC
        DA.Fill(DT)

        actualizar_tabla()
        mostrar(0)
        controles(True, False)

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Sub actualizar_tabla()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from consultas_sql order by cod_auto desc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub

    Private Sub btn_primero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.Click
        grilla_documento.DataSource = Nothing
        txt_lineas.Text = ""
        MiPos = 0
        mostrar(0)
        'mostrar_datos_especie_por_combo()
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        grilla_documento.DataSource = Nothing
        txt_lineas.Text = ""
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        grilla_documento.DataSource = Nothing
        txt_lineas.Text = ""
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        grilla_documento.DataSource = Nothing
        txt_lineas.Text = ""
        MiPos = DT.Rows.Count - 1
        mostrar(MiPos)
        ' mostrar_datos_especie_por_combo()
    End Sub
End Class