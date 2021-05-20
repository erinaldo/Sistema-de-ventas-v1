Public Class Form_detalle_envios
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_detalle_envios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_detalle_envios_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_envios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_sucursales()
        combo_sucursal.Text = "TODOS"

        'Dim d As DateTime = Now()


        'Combo_año.Text = form_Menu_admin.dtp_fecha.Value.Year()
        'Combo_mes.Text = d.ToString("MMMM")
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
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

        fecha()

        'Dim nro_mes As Integer
        'Dim nro_dias As Integer
        'If Combo_mes.Text = "ENERO" Then
        '    nro_mes = 1
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "FEBRERO" Then
        '    nro_mes = 2
        '    nro_dias = 28
        'End If
        'If Combo_mes.Text = "MARZO" Then
        '    nro_mes = 3
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "ABRIL" Then
        '    nro_mes = 4
        '    nro_dias = 30
        'End If
        'If Combo_mes.Text = "MAYO" Then
        '    nro_mes = 5
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "JUNIO" Then
        '    nro_mes = 6
        '    nro_dias = 30
        'End If
        'If Combo_mes.Text = "JULIO" Then
        '    nro_mes = 7
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "AGOSTO" Then
        '    nro_mes = 8
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "SEPTIEMBRE" Then
        '    nro_mes = 9
        '    nro_dias = 30
        'End If
        'If Combo_mes.Text = "OCTUBRE" Then
        '    nro_mes = 10
        '    nro_dias = 31
        'End If
        'If Combo_mes.Text = "NOVIEMBRE" Then
        '    nro_mes = 11
        '    nro_dias = 30
        'End If
        'If Combo_mes.Text = "DICIEMBRE" Then
        '    nro_mes = 12
        '    nro_dias = 31
        'End If

        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()

        grilla_documento.Columns.Add("", "GUIA")
        grilla_documento.Columns.Add("", "FECHA")
        grilla_documento.Columns.Add("", "ORIGEN")
        grilla_documento.Columns.Add("", "DESTINO")
        grilla_documento.Columns.Add("", "CODIGO")
        grilla_documento.Columns.Add("", "NOMBRE")
        grilla_documento.Columns.Add("", "NRO. TECNICO")
        grilla_documento.Columns.Add("", "APLICACION")
        grilla_documento.Columns.Add("", "VALOR")
        grilla_documento.Columns.Add("", "CANTIDAD")

        If combo_sucursal.Text = "TODOS" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "SELECT GUIA.N_GUIA, GUIA.fecha_venta,direccion_cliente as DIRECCION, detalle_guia.cod_producto as 'CODIGO', detalle_guia.detalle_nombre AS NOMBRE, productos.APLICACION as APLICACION, detalle_guia.numero_tecnico as 'NRO. TECNICO',  VALOR_UNITARIO,  detalle_GUIA.cantidad FROM `clientes`,`guia`,`detalle_guia`,`productos` where guia.codigo_cliente=clientes.cod_cliente and guia.n_guia=detalle_guia.n_guia and detalle_guia.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and guia.TIPO <> 'AJUSTE' GROUP BY productos.cod_producto, detalle_guia.n_guia ORDER BY guia.n_guia;"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim fecha_venta As String
                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    If fecha_venta.Length > 10 Then
                        fecha_venta = fecha_venta.Substring(0, 10)
                    End If
                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("N_GUIA"), _
                                               fecha_venta, _
                                                mirecintoempresa, _
                                                 DS.Tables(DT.TableName).Rows(i).Item("DIRECCION"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("VALOR_UNITARIO"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("cantidad"))
                Next
            End If
        End If

        If combo_sucursal.Text <> "TODOS" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "SELECT GUIA.N_GUIA, GUIA.fecha_venta,direccion_cliente as DIRECCION, detalle_guia.cod_producto as 'CODIGO', detalle_guia.detalle_nombre AS NOMBRE,productos.APLICACION as APLICACION, detalle_guia.numero_tecnico as 'NRO. TECNICO',  VALOR_UNITARIO,  detalle_GUIA.cantidad FROM `clientes`,`guia`,`detalle_guia`,`productos` where guia.codigo_cliente=clientes.cod_cliente and guia.n_guia=detalle_guia.n_guia and detalle_guia.cod_producto=productos.cod_producto and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and clientes.direccion_cliente='" & (combo_sucursal.Text) & "'  and guia.TIPO <> 'AJUSTE'  GROUP BY productos.cod_producto, detalle_guia.n_guia ORDER BY guia.n_guia;"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim fecha_venta As String
                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    If fecha_venta.Length > 10 Then
                        fecha_venta = fecha_venta.Substring(0, 10)
                    End If
                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("N_GUIA"), _
                                               fecha_venta, _
                                                mirecintoempresa, _
                                                 DS.Tables(DT.TableName).Rows(i).Item("DIRECCION"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("CODIGO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("VALOR_UNITARIO"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("cantidad"))
                Next
            End If
        End If

        If grilla_documento.Rows.Count <> 0 Then
            If grilla_documento.Columns(0).Width = 100 Then
                grilla_documento.Columns(0).Width = 99
            Else
                grilla_documento.Columns(0).Width = 100
            End If
        End If

        grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_documento.Columns(0).Width = 100
        grilla_documento.Columns(1).Width = 100
        grilla_documento.Columns(2).Width = 200
        grilla_documento.Columns(3).Width = 200
        grilla_documento.Columns(4).Width = 100
        grilla_documento.Columns(5).Width = 200
        grilla_documento.Columns(6).Width = 200
        grilla_documento.Columns(7).Width = 200
        grilla_documento.Columns(8).Width = 100
        grilla_documento.Columns(9).Width = 100
        'grilla_documento.Columns(10).Width = 100
        'grilla_documento.Columns(10).Width = 100
        'grilla_documento.Columns(11).Width = 120

        'Dim codigo As String
        'Dim nombre As String
        'Dim familia As String
        'Dim nro_tecnico As String
        'Dim direccion As String
        'Dim valor_unitario As String
        'Dim guia As String
        'Dim nro_dia As Integer
        'Dim contador As Integer
        'contador = 8
        'While (contador < grilla_documento.ColumnCount - 1)

        '    For i = 0 To grilla_documento.Rows.Count - 1
        '        codigo = grilla_documento.Rows(i).Cells(0).Value.ToString
        '        nombre = grilla_documento.Rows(i).Cells(1).Value.ToString
        '        familia = grilla_documento.Rows(i).Cells(2).Value.ToString
        '        nro_tecnico = grilla_documento.Rows(i).Cells(3).Value.ToString
        '        'mirecintoempresa = grilla_documento.Rows(i).Cells(4).Value.ToString
        '        direccion = grilla_documento.Rows(i).Cells(5).Value.ToString
        '        valor_unitario = grilla_documento.Rows(i).Cells(6).Value.ToString
        '        guia = grilla_documento.Rows(i).Cells(7).Value.ToString
        '        nro_dia = grilla_documento.Columns.Item(contador).HeaderText
        '        conexion.Close()
        '        DS.Tables.Clear()
        '        DT.Rows.Clear()
        '        DT.Columns.Clear()
        '        DS.Clear()
        '        SC.Connection = conexion
        '        SC.CommandText = "SELECT CANTIDAD FROM `guia`, `detalle_guia` where  year(fecha_venta)='" & (Combo_año.Text) & "' and  month(fecha_venta)='" & (nro_mes) & "' and COD_PRODUCTO='" & (codigo) & "' AND detalle_guia.n_guia='" & (guia) & "';"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            For u = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '                Dim cantidad As String
        '                cantidad = DS.Tables(DT.TableName).Rows(u).Item("CANTIDAD")
        '                grilla_documento.Item(contador, i).Value = cantidad
        '            Next
        '        End If
        '    Next
        '    contador = contador + 1
        'End While

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False


        mostrar_malla()

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

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_documento.DataSource = Nothing
            grilla_documento.Rows.Clear()
            combo_sucursal.SelectedItem = "TODOS"
        End If
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

    Sub llenar_combo_sucursales()
        Combo_sucursal.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from sucursales  where nombre_sucursal <> '" & (mirecintoempresa) & "' order by nombre_sucursal"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        combo_sucursal.Items.Add("TODOS")

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
            Next
        End If
        combo_sucursal.SelectedItem = "TODOS"
        conexion.Close()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class