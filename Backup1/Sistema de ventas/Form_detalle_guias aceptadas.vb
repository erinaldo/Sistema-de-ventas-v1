Imports CrystalDecisions.CrystalReports.Engine
Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Form_detalle_guias_aceptadas
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_detalle_guias_aceptadas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_detalle_guias_aceptadas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_guias_aceptadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        'mostrar_malla()
        grilla_documento.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()
        llenar_combo_sucursal()
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_malla()
        'conexion.Close()
        'Dim DT3 As New DataTable

        'DS3.Tables.Clear()
        'DT3.Rows.Clear()
        'DT3.Columns.Clear()
        'DS3.Clear()
        'conexion.Open()
        'SC3.Connection = conexion
        'SC3.CommandText = "select DETALLE_GUIA.n_guia as 'NRO. GUIA', GUIA.fecha_venta as 'FECHA', DETALLE_GUIA.COD_PRODUCTO as 'CODIGO',  DETALLE_GUIA.detalle_nombre as 'PRODUCTO', DETALLE_GUIA.NUMERO_TECNICO AS 'NRO. TECNICO', APLICACION, DETALLE_GUIA.VALOR_UNITARIO as 'PRECIO', DETALLE_GUIA.CANTIDAD as 'CANTIDAD' from DETALLE_GUIA, PRODUCTOS, GUIA where  DETALLE_GUIA.N_GUIA=GUIA.N_GUIA AND  DETALLE_GUIA.COD_PRODUCTO=PRODUCTOS.COD_PRODUCTO AND guia.fecha_venta >='" & (mifecha2) & "' and guia.fecha_venta <= '" & (mifecha4) & "'  ORDER BY DETALLE_GUIA.N_guia"
        'DA3.SelectCommand = SC3
        'DA3.Fill(DT3)
        'DS3.Tables.Add(DT3)

        'grilla_documento.DataSource = DS3.Tables(DT3.TableName)
        'conexion.Close()

        'If grilla_documento.Rows.Count <> 0 Then
        '    grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        '    grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        '    grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '    grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '    grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '    grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End If









        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select DETALLE_GUIA.n_guia as 'NRO. GUIA', GUIA.fecha_venta as 'FECHA', DETALLE_GUIA.COD_PRODUCTO as 'CODIGO',  DETALLE_GUIA.detalle_nombre as 'PRODUCTO', DETALLE_GUIA.NUMERO_TECNICO AS 'NRO. TECNICO', APLICACION, DETALLE_GUIA.VALOR_UNITARIO as 'PRECIO', DETALLE_GUIA.CANTIDAD as 'CANTIDAD' from DETALLE_GUIA, PRODUCTOS, GUIA where  DETALLE_GUIA.N_GUIA=GUIA.N_GUIA AND  DETALLE_GUIA.COD_PRODUCTO=PRODUCTOS.COD_PRODUCTO AND guia.codigo_cliente ='" & (txt_codigo_sucursal.Text) & "' and guia.fecha_venta >='" & (mifecha2) & "' and guia.fecha_venta <= '" & (mifecha4) & "'  ORDER BY DETALLE_GUIA.N_guia"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
        grilla_documento.Columns.Add("", "EMISION")
        grilla_documento.Columns.Add("", "DESTINO")
        grilla_documento.Columns.Add("", "NRO. GUIA")
        grilla_documento.Columns.Add("", "FECHA")
        grilla_documento.Columns.Add("", "CODIGO")
        grilla_documento.Columns.Add("", "PRODUCTO")
        grilla_documento.Columns.Add("", "N° TECNICO")
        grilla_documento.Columns.Add("", "APLICACION")
        grilla_documento.Columns.Add("", "PRECIO")
        grilla_documento.Columns.Add("", "ENVIADO")
        grilla_documento.Columns.Add("", "RECIBIDO")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim mifecha_emision2 As String
                Dim MiFechaEmision As Date
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                grilla_documento.Rows.Add(mirecintoempresa, _
                                           combo_sucursal.Text, _
                                            DS.Tables(DT.TableName).Rows(i).Item("NRO. GUIA"), _
                                             mifecha_emision2, _
                                              DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("PRODUCTO"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                    "0")
            Next
        End If

        If grilla_documento.Rows.Count <> 0 Then
            If grilla_documento.Columns(0).Width = 100 Then
                grilla_documento.Columns(0).Width = 99
            Else
                grilla_documento.Columns(0).Width = 100
            End If
            grilla_documento.Columns(1).Width = 150
            grilla_documento.Columns(2).Width = 136
            grilla_documento.Columns(3).Width = 100
            grilla_documento.Columns(4).Width = 100
            grilla_documento.Columns(5).Width = 100
            grilla_documento.Columns(6).Width = 100
            grilla_documento.Columns(7).Width = 100
            grilla_documento.Columns(8).Width = 100
            grilla_documento.Columns(9).Width = 100
            grilla_documento.Columns(10).Width = 100
            grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Sub llenar_combo_sucursal()
        combo_sucursal.Items.Clear()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select * from sucursales ORDER BY nombre_sucursal"

        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                combo_sucursal.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("nombre_sucursal"))
            Next
            conexion.Close()
        End If
        combo_sucursal.Items.Add("-")
        combo_sucursal.SelectedItem = "-"
    End Sub

    Sub mostrar_datos_sucursal()
        If combo_sucursal.Text <> "-" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from sucursales where nombre_sucursal ='" & (combo_sucursal.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_sucursal.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_sucursal.SelectedIndexChanged
        grilla_documento.Columns.Clear()
        mostrar_datos_sucursal()
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If combo_sucursal.Text = "-" Then
            combo_sucursal.Focus()
            MsgBox("CAMPO SUCURSAL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_documento.DataSource = Nothing

        fecha()
        mostrar_malla()
        consultar_producto()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
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

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_documento.Columns.Clear()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_documento.Columns.Clear()
    End Sub



    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_sucursal.GotFocus
        combo_sucursal.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_sucursal.LostFocus
        combo_sucursal.BackColor = Color.White
    End Sub

    Private Sub dtp_desde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.GotFocus
        dtp_desde.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp_desde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.LostFocus
        dtp_desde.BackColor = Color.White
    End Sub

    Private Sub dtp_hasta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.GotFocus
        dtp_hasta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp_hasta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.LostFocus
        dtp_hasta.BackColor = Color.White
    End Sub


    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            combo_sucursal.SelectedItem = "TODOS"
            dtp_desde.Text = FormatDateTime(Now, DateFormat.ShortDate)
            dtp_hasta.Text = FormatDateTime(Now, DateFormat.ShortDate)
            grilla_documento.Columns.Clear()
        End If
    End Sub

    Sub consultar_producto()
        Dim nro_guia As String
        Dim cod_producto As String
        Dim sucursal As String
        Dim enviado As String
        Dim recibido As String

        For i = 0 To grilla_documento.Rows.Count - 1
            nro_guia = grilla_documento.Rows(i).Cells(2).Value.ToString
            cod_producto = grilla_documento.Rows(i).Cells(4).Value.ToString
            sucursal = grilla_documento.Rows(i).Cells(1).Value.ToString
            txt_sucursal.Text = sucursal

            crear_conexion()

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "Select * from detalle_total where n_total = '" & (nro_guia) & "' and TIPO ='VALE DE TRASLADO' and cod_producto='" & (cod_producto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                grilla_documento.Rows(i).Cells(10).Value = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
            End If

            enviado = grilla_documento.Rows(i).Cells(9).Value.ToString
            recibido = grilla_documento.Rows(i).Cells(10).Value.ToString

            If enviado <> recibido Then
                grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If

        Next

        recuperar_conexion()
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

            If txt_sucursal.Text = recinto Then

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
End Class