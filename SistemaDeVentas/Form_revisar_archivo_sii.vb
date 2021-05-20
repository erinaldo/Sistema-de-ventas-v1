Imports System.Data.OleDb
Imports System.IO

Public Class Form_revisar_archivo_sii

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        If combo_tipo.Text = "-" Then
            combo_tipo.Focus()
            MsgBox("CAMPO TIPO ARCHIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If combo_tipo.Text = "" Then
            combo_tipo.Focus()
            MsgBox("CAMPO TIPO ARCHIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        grilla_excel.Columns.Clear()
        grilla_base_de_datos.Columns.Clear()
        grilla_faltantes.Columns.Clear()


        txt_cantidad_excel.Text = ""
        txtFic.Text = ""
        txtSelect.Text = ""

        txt_cantidad_excel.Text = ""
        txt_cantidad_bd.Text = ""
        txt_cantidad_faltantes.Text = ""

        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xls;*.xlsx;*.csv)|*.xls;*xlsx;*csv|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                stRuta = .FileName
            End If
        End With
        Try
            Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (stRuta & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";"))) 'este es el codigo que funciona para office 2007 y 2010 
            Dim cnConex As New OleDbConnection(stConexion)
            Dim Cmd As New OleDbCommand("Select * From [Hoja1$]")
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable
            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)
            Me.grilla_excel.Columns.Clear()
            Me.grilla_excel.DataSource = Dt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        txt_cantidad_excel.Text = grilla_excel.Rows.Count

        If grilla_excel.Rows.Count <> 0 Then
            Me.grilla_excel.Columns(0).Visible = False
            Me.grilla_excel.Columns(1).Visible = True
            grilla_excel.Columns(1).HeaderText = "DOC."
            Me.grilla_excel.Columns(2).Visible = False
            Me.grilla_excel.Columns(3).Visible = True
            grilla_excel.Columns(3).HeaderText = "RUT"
            Me.grilla_excel.Columns(4).Visible = False
            Me.grilla_excel.Columns(5).Visible = True
            grilla_excel.Columns(5).HeaderText = "NRO."
            Me.grilla_excel.Columns(6).Visible = True
            grilla_excel.Columns(6).HeaderText = "FECHA"
            Me.grilla_excel.Columns(7).Visible = False
            Me.grilla_excel.Columns(8).Visible = False
            Me.grilla_excel.Columns(9).Visible = False
            Me.grilla_excel.Columns(10).Visible = False
            Me.grilla_excel.Columns(11).Visible = False
            Me.grilla_excel.Columns(12).Visible = False
            Me.grilla_excel.Columns(13).Visible = False
            Me.grilla_excel.Columns(14).Visible = False
            Me.grilla_excel.Columns(15).Visible = False
            Me.grilla_excel.Columns(16).Visible = False
            Me.grilla_excel.Columns(17).Visible = False
            Me.grilla_excel.Columns(18).Visible = False
            Me.grilla_excel.Columns(19).Visible = False
            Me.grilla_excel.Columns(20).Visible = False
            Me.grilla_excel.Columns(21).Visible = False
            Me.grilla_excel.Columns(22).Visible = False
            Me.grilla_excel.Columns(23).Visible = False
            Me.grilla_excel.Columns(24).Visible = False
            Me.grilla_excel.Columns(25).Visible = False
            Me.grilla_excel.Columns(26).Visible = False
            'Me.grilla_excel.Columns(27).Visible = False
            'Me.grilla_excel.Columns(28).Visible = False
            'Me.grilla_excel.Columns(29).Visible = False
            'Me.grilla_excel.Columns(30).Visible = False
            'Me.grilla_excel.Columns(31).Visible = False
            'Me.grilla_excel.Columns(32).Visible = False
        End If
        'tipo_documento = grilla_excel.Rows(i).Cells(1).Value.ToString
        'rut_proveedor = grilla_excel.Rows(i).Cells(3).Value.ToString
        'nro_documento = grilla_excel.Rows(i).Cells(5).Value.ToString
        'fecha_doc = grilla_excel.Rows(i).Cells(7).Value.ToString
        'Me.grilla_base_de_datos.Columns(0).Visible = True







        cargar_periodo_tributario()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_revisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_revisar.Click
        If combo_tipo.Text = "-" Then
            combo_tipo.Focus()
            MsgBox("CAMPO TIPO ARCHIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        If combo_tipo.Text = "" Then
            combo_tipo.Focus()
            MsgBox("CAMPO TIPO ARCHIVO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If grilla_excel.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_tipo.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        grilla_faltantes.Rows.Clear()
        grilla_faltantes.Columns.Clear()
        grilla_faltantes.Columns.Add("", "DOC.")
        grilla_faltantes.Columns.Add("", "RUT")
        grilla_faltantes.Columns.Add("", "NRO.")
        grilla_faltantes.Columns.Add("", "FECHA")

        Dim tipo_documento_bd As String
        Dim nro_documento_bd As String
        Dim rut_proveedor_bd As String
        Dim fecha_doc_bd As String

        Dim tipo_documento_excel As String
        Dim nro_documento_excel As String
        Dim rut_proveedor_excel As String
        Dim fecha_doc_excel As String

        Dim agregar As String

        If combo_tipo.Text = "BUSCAR EN BASE DE DATOS" Then
            For i = 0 To grilla_excel.Rows.Count - 1
                tipo_documento_excel = grilla_excel.Rows(i).Cells(1).Value.ToString
                nro_documento_excel = grilla_excel.Rows(i).Cells(5).Value.ToString
                rut_proveedor_excel = grilla_excel.Rows(i).Cells(3).Value.ToString
                fecha_doc_excel = grilla_excel.Rows(i).Cells(6).Value.ToString

                If tipo_documento_excel = "33" Then
                    tipo_documento_excel = "FACTURA"
                End If

                If tipo_documento_excel = "61" Then
                    tipo_documento_excel = "NOTA DE CREDITO"
                End If

                If tipo_documento_excel = "34" Then
                    tipo_documento_excel = "FACTURA"
                End If

                Dim mifecha As Date
                mifecha = fecha_doc_excel
                fecha_doc_excel = mifecha.ToString("yyy-MM-dd")

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select * from libro_de_compras where documento='" & (tipo_documento_excel) & "' and nro_factura='" & (nro_documento_excel) & "' and rut_proveedor='" & (rut_proveedor_excel) & "' and fecha_factura='" & (fecha_doc_excel) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then

                Else
                    grilla_faltantes.Rows.Add(tipo_documento_excel, rut_proveedor_excel, nro_documento_excel, fecha_doc_excel)
                End If
                conexion.Close()
            Next
        End If





        If combo_tipo.Text = "BUSCAR EN ARCHIVO SII" Then
            For i = 0 To grilla_base_de_datos.Rows.Count - 1
                tipo_documento_bd = grilla_base_de_datos.Rows(i).Cells(0).Value.ToString
                rut_proveedor_bd = grilla_base_de_datos.Rows(i).Cells(1).Value.ToString
                nro_documento_bd = grilla_base_de_datos.Rows(i).Cells(2).Value.ToString
                fecha_doc_bd = grilla_base_de_datos.Rows(i).Cells(3).Value.ToString

                agregar = ""

                If tipo_documento_bd = "33" Then
                    tipo_documento_bd = "FACTURA"
                End If

                If tipo_documento_bd = "61" Then
                    tipo_documento_bd = "NOTA DE CREDITO"
                End If


                If tipo_documento_bd = "34" Then
                    tipo_documento_bd = "FACTURA"
                End If


                Dim mifecha_bd As Date
                mifecha_bd = fecha_doc_bd
                fecha_doc_bd = mifecha_bd.ToString("yyy-MM-dd")


                For x = 0 To grilla_excel.Rows.Count - 1
                    tipo_documento_excel = grilla_excel.Rows(x).Cells(1).Value.ToString
                    nro_documento_excel = grilla_excel.Rows(x).Cells(5).Value.ToString
                    rut_proveedor_excel = grilla_excel.Rows(x).Cells(3).Value.ToString
                    fecha_doc_excel = grilla_excel.Rows(x).Cells(6).Value.ToString

                    If tipo_documento_excel = "33" Then
                        tipo_documento_excel = "FACTURA"
                    End If

                    If tipo_documento_excel = "61" Then
                        tipo_documento_excel = "NOTA DE CREDITO"
                    End If

                    Dim mifecha_excel As Date
                    mifecha_excel = fecha_doc_excel
                    fecha_doc_excel = mifecha_excel.ToString("yyy-MM-dd")

                    If tipo_documento_excel = tipo_documento_bd And nro_documento_excel = nro_documento_bd And rut_proveedor_excel = rut_proveedor_bd And fecha_doc_excel = fecha_doc_bd Then
                        agregar = "SI"
                        Exit For
                    End If
                Next


                If agregar = "" Then
                    grilla_faltantes.Rows.Add(tipo_documento_bd, rut_proveedor_bd, nro_documento_bd, fecha_doc_bd)
                End If

            Next
        End If



        If grilla_faltantes.Rows.Count <> 0 Then
            grilla_faltantes.Columns(0).Width = grilla_faltantes.Columns(0).Width - 1
        End If

        txt_cantidad_faltantes.Text = grilla_faltantes.Rows.Count

        grilla_base_de_datos.Rows(0).Cells(0).Selected = False
        grilla_faltantes.Rows(0).Cells(0).Selected = False

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub Form_revisar_archivo_sii_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_revisar_archivo_sii_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_revisar_archivo_sii_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()

        Dim valor As Integer
        Dim mes As String
        valor = Form_menu_principal.dtp_fecha.Value.Month
        mes = String.Format("{0:00}", valor)


        combo_tipo.Text = "BUSCAR EN BASE DE DATOS"
        Combo_mes.Text = mes
        Combo_año.Text = Form_menu_principal.dtp_fecha.Value.Year
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub








    Sub cargar_periodo_tributario()
        'Dim tipo_documento As String
        'Dim nro_documento As String
        'Dim rut_proveedor As String
        'Dim fecha_doc As String

        'tipo_documento = grilla_excel.Rows(i).Cells(1).Value.ToString
        'rut_proveedor = grilla_excel.Rows(i).Cells(3).Value.ToString
        'nro_documento = grilla_excel.Rows(i).Cells(5).Value.ToString
        'fecha_doc = grilla_excel.Rows(i).Cells(7).Value.ToString

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select documento, rut_proveedor, nro_factura, fecha_factura from libro_de_compras where periodo_tributario='" & (Combo_mes.Text & "-" & Combo_año.Text) & "' order by codigo_folio"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        Me.grilla_base_de_datos.Rows.Clear()
        Me.grilla_base_de_datos.Columns.Clear()
        Me.grilla_base_de_datos.Columns.Add("documento", "DOC.")
        Me.grilla_base_de_datos.Columns.Add("rut_proveedor", "RUT")
        Me.grilla_base_de_datos.Columns.Add("nro_factura", "NRO.")
        Me.grilla_base_de_datos.Columns.Add("fecha_factura", "FECHA")

        'Me.grilla_base_de_datos.Columns(0).Visible = True
        'Form_libro_de_compras.grilla_libro_compras.Columns(0).Width = 85

        Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Me.grilla_base_de_datos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("documento"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("nro_factura"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("fecha_factura"))
                'DS.Tables(DT.TableName).Rows(i).Item("costo"))
            Next

            'Me.grilla_base_de_datos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.grilla_base_de_datos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.grilla_base_de_datos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Me.grilla_base_de_datos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.grilla_base_de_datos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.grilla_base_de_datos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.grilla_base_de_datos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Me.grilla_base_de_datos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            If grilla_base_de_datos.Rows.Count <> 0 Then
                grilla_base_de_datos.Columns(0).Width = grilla_base_de_datos.Columns(0).Width - 1
            End If

        End If

        txt_cantidad_bd.Text = grilla_base_de_datos.Rows.Count
    End Sub

    Private Sub combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_tipo.SelectedIndexChanged
        grilla_excel.Columns.Clear()
        grilla_base_de_datos.Columns.Clear()
        grilla_faltantes.Columns.Clear()
        txt_cantidad_excel.Text = ""
        txt_cantidad_bd.Text = ""
        txt_cantidad_faltantes.Text = ""
    End Sub

    Private Sub Combo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_mes.SelectedIndexChanged
        grilla_excel.Columns.Clear()
        grilla_base_de_datos.Columns.Clear()
        grilla_faltantes.Columns.Clear()
        txt_cantidad_excel.Text = ""
        txt_cantidad_bd.Text = ""
        txt_cantidad_faltantes.Text = ""
    End Sub

    Private Sub Combo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_año.SelectedIndexChanged
        grilla_excel.Columns.Clear()
        grilla_base_de_datos.Columns.Clear()
        grilla_faltantes.Columns.Clear()
        txt_cantidad_excel.Text = ""
        txt_cantidad_bd.Text = ""
        txt_cantidad_faltantes.Text = ""
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_faltantes.Rows.Count = 0 Then
            btn_revisar.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_faltantes, save.FileName)
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
        For c As Integer = 0 To grilla_faltantes.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_faltantes.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_faltantes.RowCount - 1
            For c As Integer = 0 To grilla_faltantes.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_faltantes.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub
End Class