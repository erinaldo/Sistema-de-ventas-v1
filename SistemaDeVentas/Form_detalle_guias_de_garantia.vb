Imports System.Resources
Imports MySql.Data.MySqlClient

Public Class Form_detalle_guias_de_garantia
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_detalle_guias_de_garantia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_detalle_guias_de_garantia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_guias_de_garantia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grilla_documento.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        llenar_combo_sucursales()
        cargar_logo()
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
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub llenar_combo_sucursales()
        combo_sucursal.Items.Clear()
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
        combo_sucursal.Items.Add("MULTISUCURSAL")

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
            Next
        End If
        combo_sucursal.SelectedItem = "MULTISUCURSAL"
        conexion.Close()
    End Sub

    Sub mostrar_malla()
        Try
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select recinto_empresa as SUCURSAL, guia.fecha_venta as FECHA, HORA AS HORA, guia.TIPO as TIPO, guia.n_guia as 'NRO.',guia.total AS TOTAL,  guia.rut_cliente AS RUT, nombre_cliente AS 'NOMBRE', usuarios.nombre_usuario USUARIO from empresa, guia , usuarios, clientes where tipo='GUIA DE GARANTIA' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND usuarios.rut_usuario =guia.usuario_responsable AND guia.rut_cliente=clientes.rut_cliente GROUP BY n_guia ORDER BY n_guia"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            'grilla_documento.Rows.Clear()
            'grilla_documento.Columns.Clear()
            'grilla_documento.Columns.Add("", "SUCURSAL")
            'grilla_documento.Columns.Add("", "FECHA")
            'grilla_documento.Columns.Add("", "HORA")
            'grilla_documento.Columns.Add("", "TIPO")
            'grilla_documento.Columns.Add("", "NRO.")
            'grilla_documento.Columns.Add("", "TOTAL")
            'grilla_documento.Columns.Add("", "RUT")
            'grilla_documento.Columns.Add("", "NOMBRE")
            'grilla_documento.Columns.Add("", "USUARIO")

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("SUCURSAL"), _
                                               mifecha_emision2, _
                                                DS.Tables(DT.TableName).Rows(i).Item("HORA"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("NRO."), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("USUARIO"))
                Next
            End If

            If grilla_documento.Rows.Count <> 0 Then
                If grilla_documento.Columns(0).Width = 100 Then
                    grilla_documento.Columns(0).Width = 99
                Else
                    grilla_documento.Columns(0).Width = 100
                End If
                grilla_documento.Columns(1).Width = 100
                grilla_documento.Columns(2).Width = 100
                grilla_documento.Columns(3).Width = 100
                grilla_documento.Columns(4).Width = 100
                grilla_documento.Columns(5).Width = 100
                grilla_documento.Columns(6).Width = 100
                grilla_documento.Columns(7).Width = 100
                grilla_documento.Columns(8).Width = 100

                grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            End If

        Catch
        End Try
    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_documento.DataSource = Nothing
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False


        fecha()













        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
        grilla_documento.Columns.Add("", "SUCURSAL")
        grilla_documento.Columns.Add("", "FECHA")
        grilla_documento.Columns.Add("", "HORA")
        grilla_documento.Columns.Add("", "TIPO")
        grilla_documento.Columns.Add("", "NRO.")
        grilla_documento.Columns.Add("", "TOTAL")
        grilla_documento.Columns.Add("", "RUT")
        grilla_documento.Columns.Add("", "NOMBRE")
        grilla_documento.Columns.Add("", "USUARIO")



        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String

        If combo_sucursal.Text = "MULTISUCURSAL" Then
            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString
                recinto = Trim(Replace(recinto, "'", "´"))

                If recinto <> "VALDIVIA 060" Then
                    conexion.Close()
                    conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    'Try

                    mostrar_malla()
                    ' Catch mierror As MySqlException
                    'Catch mierror As MissingManifestResourceException
                    ' End Try
                End If
            Next
        End If

        If combo_sucursal.Text <> "MULTISUCURSAL" Then
            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString
                recinto = Trim(Replace(recinto, "'", "´"))

                If recinto = combo_sucursal.Text Then
                    conexion.Close()
                    conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    'Try
                    mostrar_malla()
                    ' Catch mierror As MySqlException
                    'Catch mierror As MissingManifestResourceException
                    'End Try
                End If
            Next
        End If

        recuperar_conexion_actual()



















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



        If grilla_documento.Rows.Count <> 0 Then

            lbl_mensaje.Visible = True
            Me.Enabled = False


            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Me.grilla_resumen, save.FileName)
            End If
            lbl_mensaje.Visible = False
            Me.Enabled = True



        End If

        'lbl_mensaje.Visible = True
        'Me.Enabled = False
        'Dim save As New SaveFileDialog
        'save.Filter = "Archivo Excel | *.xls"
        'If save.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Exportar_Excel(Me.grilla_documento, save.FileName)
        'End If
        'lbl_mensaje.Visible = False
        'Me.Enabled = True


    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_resumen.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_resumen.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_resumen.RowCount - 1
            For c As Integer = 0 To grilla_resumen.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_resumen.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
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

    Private Sub GroupBox_tipo_venta_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
    End Sub

    Sub mostrar_malla_detalle()
        Dim sucursal As String
        Dim nro_doc As String

        sucursal = grilla_documento.CurrentRow.Cells(0).Value
        nro_doc = grilla_documento.CurrentRow.Cells(4).Value
      
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_guia where n_guia='" & (nro_doc) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_documento_detalle.Rows.Clear()
        grilla_documento_detalle.Columns.Clear()
        grilla_documento_detalle.Columns.Add("", "CODIGO")
        grilla_documento_detalle.Columns.Add("", "NOMBRE")
        grilla_documento_detalle.Columns.Add("", "NRO. TECNICO")
        grilla_documento_detalle.Columns.Add("", "PRECIO")
        grilla_documento_detalle.Columns.Add("", "CANTIDAD")
        grilla_documento_detalle.Columns.Add("", "TOTAL")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                grilla_documento_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
            Next
        End If

        If grilla_documento_detalle.Rows.Count <> 0 Then
            If grilla_documento_detalle.Columns(0).Width = 100 Then
                grilla_documento_detalle.Columns(0).Width = 99
            Else
                grilla_documento_detalle.Columns(0).Width = 100
            End If
            grilla_documento_detalle.Columns(1).Width = 314
            grilla_documento_detalle.Columns(2).Width = 250
            grilla_documento_detalle.Columns(3).Width = 100
            grilla_documento_detalle.Columns(4).Width = 100
            grilla_documento_detalle.Columns(5).Width = 100
           
            grilla_documento_detalle.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento_detalle.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        End If

    End Sub

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub

    Private Sub grilla_documento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.Click
        If grilla_documento.Rows.Count = 0 Then
            Exit Sub
        End If
       



        lbl_mensaje.Visible = True
        Me.Enabled = False


     

        Dim sucursal As String
        Dim nro_doc As String



        sucursal = grilla_documento.CurrentRow.Cells(0).Value
        nro_doc = grilla_documento.CurrentRow.Cells(4).Value

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

            If recinto = sucursal Then
                conexion.Close()
                conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                'Try
                mostrar_malla_detalle()
                ' Catch mierror As MySqlException
                'Catch mierror As MissingManifestResourceException
                'End Try
            End If
        Next

        recuperar_conexion_actual()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub txt_nro_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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



        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub combo_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_sucursal.SelectedIndexChanged
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
    End Sub

    Private Sub grilla_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.DoubleClick

    End Sub
End Class