Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_registro_de_autorizaciones
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_registro_de_autorizaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_registro_de_autorizaciones_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_registro_de_autorizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_vendedor()
        llenar_combo_usuario()
        Combo_usuario.SelectedItem = "TODOS"
        Combo_vendedor.SelectedItem = "TODOS"
        fecha()
        mostrar_malla()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub llenar_combo_vendedor()
        Combo_vendedor.Items.Clear()
        Combo_vendedor.Items.Add("TODOS")
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
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        conexion.Close()
    End Sub

    Sub llenar_combo_usuario()
        Combo_usuario.Items.Clear()
        Combo_usuario.Items.Add("TODOS")
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios  where autoriza_venta='SI' order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_usuario.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
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
            End If

            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_usuario()
        conexion.Close()
        If Combo_usuario.Text <> "" Then
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
                txt_usuario.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
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

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_documento.Rows.Count = 0 Then
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

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_documento.DataSource = Nothing
        fecha()
        mostrar_malla()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub



    Sub mostrar_malla()

        If Combo_usuario.Text = "TODOS" And Combo_vendedor.Text = "TODOS" Then
            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select nombre_usuario as ENCARGADO, FECHA as 'FECHA', tipo_DESCUENTO 'TIPO',tipo_doc 'TIPO DOC.', NRO_DOC 'NRO. DOC.', CONDICION_DE_PAGO AS 'CONDICION' , nombre_vendedor AS VENDEDOR, PORCENTAJE_DESCUENTO AS '% DESC.', VALOR_DESCUENTO AS 'VALOR' from registro_de_autorizaciones_ventas, usuarios where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND usuarios.rut_usuario =registro_de_autorizaciones_ventas.usuario_responsable "

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()
        End If

        If Combo_usuario.Text <> "TODOS" And Combo_vendedor.Text = "TODOS" Then
            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select nombre_usuario as ENCARGADO, FECHA as 'FECHA', tipo_DESCUENTO 'TIPO',tipo_doc 'TIPO DOC.', NRO_DOC 'NRO. DOC.', CONDICION_DE_PAGO AS 'CONDICION' , nombre_vendedor AS VENDEDOR, PORCENTAJE_DESCUENTO AS '% DESC.', VALOR_DESCUENTO AS 'VALOR' from registro_de_autorizaciones_ventas, usuarios where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND usuarios.rut_usuario =registro_de_autorizaciones_ventas.usuario_responsable and registro_de_autorizaciones_ventas.usuario_responsable='" & (txt_usuario.Text) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()
        End If

        If Combo_usuario.Text = "TODOS" And Combo_vendedor.Text <> "TODOS" Then
            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select nombre_usuario as ENCARGADO, FECHA as 'FECHA', tipo_DESCUENTO 'TIPO',tipo_doc 'TIPO DOC.', NRO_DOC 'NRO. DOC.', CONDICION_DE_PAGO AS 'CONDICION' , nombre_vendedor AS VENDEDOR, PORCENTAJE_DESCUENTO AS '% DESC.', VALOR_DESCUENTO AS 'VALOR' from registro_de_autorizaciones_ventas, usuarios where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND usuarios.rut_usuario =registro_de_autorizaciones_ventas.usuario_responsable and registro_de_autorizaciones_ventas.nombre_vendedor='" & (Combo_vendedor.Text) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()
        End If

        If Combo_usuario.Text <> "TODOS" And Combo_vendedor.Text <> "TODOS" Then
            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion

            SC3.CommandText = "select nombre_usuario as ENCARGADO, FECHA as 'FECHA', tipo_DESCUENTO 'TIPO',tipo_doc 'TIPO DOC.', NRO_DOC 'NRO. DOC.', CONDICION_DE_PAGO AS 'CONDICION' , nombre_vendedor AS VENDEDOR, PORCENTAJE_DESCUENTO AS '% DESC.', VALOR_DESCUENTO AS 'VALOR' from registro_de_autorizaciones_ventas, usuarios where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND usuarios.rut_usuario =registro_de_autorizaciones_ventas.usuario_responsable and registro_de_autorizaciones_ventas.nombre_vendedor='" & (Combo_vendedor.Text) & "'  and registro_de_autorizaciones_ventas.usuario_responsable='" & (txt_usuario.Text) & "'"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()
        End If

        grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        '  SC3.CommandText = "select usuario_responsable, fecha, tipo_doc, nro_doc, condicion_de_pago, rut_vendedor, nombre_vendedor, porcentaje_descuento, valor_descuento"
    End Sub

    Private Sub Combo_usuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_usuario.SelectedIndexChanged
        mostrar_datos_usuario()
        grilla_documento.DataSource = Nothing
    End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        mostrar_datos_vendedor()
        grilla_documento.DataSource = Nothing
    End Sub
End Class