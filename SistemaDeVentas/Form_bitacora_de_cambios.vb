Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_bitacora_de_cambios
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_bitacora_de_cambios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_bitacora_de_cambios_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_bitacora_de_cambios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_usuario()
        Combo_usuario.SelectedItem = "TODOS"
        Combo_tipo.SelectedItem = "TODOS"
        mostrar_malla()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub llenar_combo_usuario()
        Combo_usuario.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            Combo_usuario.Items.Add("TODOS")
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_usuario.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        conexion.Close()
    End Sub

    Sub mostrar_datos_usuario()
        conexion.Close()
        If Combo_tipo.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where nombre_usuario ='" & (Combo_usuario.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_usuario.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If

            conexion.Close()
        End If
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub mostrar_malla()
        Dim consulta As String
        fecha()

        If Combo_usuario.Text = "TODOS" And Combo_tipo.Text = "TODOS" Then
            consulta = "select COD_AUTO, procedencia, DETALLE, CODIGO AS REFERENCIA, FECHA, TIPO, NOMBRE_USUARIO from bitacora_de_cambios, usuarios where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and bitacora_de_cambios.usuario_responsable=usuarios.rut_usuario"

            If txt_buscar.Text <> "" Then
                consulta = consulta & " and codigo like '" & ("%" & txt_buscar.Text & "%") & "'"
            End If

            consulta = consulta & " order by cod_auto desc"

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = consulta
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_bitacora.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()
        End If

        If Combo_usuario.Text <> "TODOS" And Combo_tipo.Text = "TODOS" Then
            consulta = "select cod_auto, procedencia, DETALLE, CODIGO AS REFERENCIA, FECHA, TIPO, NOMBRE_USUARIO from bitacora_de_cambios, usuarios where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and USUARIO_RESPONSABLE = '" & (txt_rut_usuario.Text) & "' and bitacora_de_cambios.usuario_responsable=usuarios.rut_usuario"

            If txt_buscar.Text <> "" Then
                consulta = consulta & " and codigo like '" & ("%" & txt_buscar.Text & "%") & "'"
            End If

            consulta = consulta & " order by cod_auto desc"

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = consulta
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_bitacora.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()
        End If

        If Combo_usuario.Text = "TODOS" And Combo_tipo.Text <> "TODOS" Then
            consulta = "select COD_AUTO, procedencia, DETALLE, CODIGO AS REFERENCIA, FECHA, TIPO, NOMBRE_USUARIO from bitacora_de_cambios, usuarios where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and TIPO = '" & (Combo_tipo.Text) & "' and bitacora_de_cambios.usuario_responsable=usuarios.rut_usuario"

            If txt_buscar.Text <> "" Then
                consulta = consulta & " and codigo like '" & ("%" & txt_buscar.Text & "%") & "'"
            End If

            consulta = consulta & " order by cod_auto desc"

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = consulta
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_bitacora.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()
        End If

        If Combo_usuario.Text <> "TODOS" And Combo_tipo.Text <> "TODOS" Then
            consulta = "select COD_AUTO, procedencia, DETALLE, CODIGO AS REFERENCIA, FECHA, TIPO, NOMBRE_USUARIO from bitacora_de_cambios, usuarios where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'   and USUARIO_RESPONSABLE = '" & (txt_rut_usuario.Text) & "' and TIPO = '" & (Combo_tipo.Text) & "' and bitacora_de_cambios.usuario_responsable=usuarios.rut_usuario"

            If txt_buscar.Text <> "" Then
                consulta = consulta & " and codigo like '" & ("%" & txt_buscar.Text & "%") & "'"
            End If

            consulta = consulta & " order by cod_auto desc"

            conexion.Close()
            Dim DT3 As New DataTable
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = consulta
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            grilla_bitacora.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()
        End If

        Dim VarCodBitacora As String
        Dim Varprocedencia As String
        Dim VarDetalle As String
        Dim VarReferencia As String
        Dim VarFecha As String
        Dim VarTipo As String
        Dim VarNombre As String

        grilla_detalle_bitacora.Rows.Clear()
        For i = 0 To grilla_bitacora.Rows.Count - 1
            VarCodBitacora = grilla_bitacora.Rows(i).Cells(0).Value.ToString
            Varprocedencia = grilla_bitacora.Rows(i).Cells(1).Value.ToString
            VarDetalle = grilla_bitacora.Rows(i).Cells(2).Value.ToString
            VarReferencia = grilla_bitacora.Rows(i).Cells(3).Value.ToString
            VarFecha = grilla_bitacora.Rows(i).Cells(4).Value.ToString
            VarTipo = grilla_bitacora.Rows(i).Cells(5).Value.ToString
            VarNombre = grilla_bitacora.Rows(i).Cells(6).Value.ToString

            If VarFecha.Length > 10 Then
                VarFecha = VarFecha.Substring(0, 10)
            End If

            grilla_detalle_bitacora.Rows.Add(Varprocedencia, VarDetalle, VarReferencia, VarFecha, VarTipo, VarNombre)
        Next

        If grilla_detalle_bitacora.Rows.Count <> 0 Then
            If grilla_detalle_bitacora.Columns(0).Width = 150 Then
                grilla_detalle_bitacora.Columns(0).Width = 149
            Else
                grilla_detalle_bitacora.Columns(0).Width = 150
            End If
        End If
    End Sub

    Private Sub Combo_usuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_usuario.SelectedIndexChanged
        mostrar_datos_usuario()
        grilla_bitacora.DataSource = Nothing
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_bitacora.DataSource = Nothing
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_bitacora.DataSource = Nothing
    End Sub

    Private Sub Combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_tipo.SelectedIndexChanged
        grilla_bitacora.DataSource = Nothing
    End Sub

    Private Sub Combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo.GotFocus
        Combo_tipo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_tipo_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_tipo.LostFocus
        Combo_tipo.BackColor = Color.White
    End Sub

    Private Sub Combo_usuario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_usuario.GotFocus
        Combo_usuario.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_usuario_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_usuario.LostFocus
        Combo_usuario.BackColor = Color.White
    End Sub



    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_detalle_bitacora.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp_desde.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_detalle_bitacora, save.FileName)
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
        For c As Integer = 0 To grilla_detalle_bitacora.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_detalle_bitacora.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_detalle_bitacora.RowCount - 1
            For c As Integer = 0 To grilla_detalle_bitacora.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_detalle_bitacora.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub




    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub



    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar.KeyPress
        grilla_bitacora.DataSource = Nothing

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

    Private Sub txt_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar.TextChanged

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        mostrar_malla()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub
End Class