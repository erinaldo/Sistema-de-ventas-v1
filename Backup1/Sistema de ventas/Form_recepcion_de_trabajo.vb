Imports System.Drawing.Printing
Public Class Form_recepcion_de_trabajo
    Dim MiPos As Integer
    Dim VarSeleccion As Integer
    Dim numero_lineas_total As Integer = 0

    Private Sub Form_recepcion_de_trabajo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_recepcion_de_trabajo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_recepcion_de_trabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cargar_logo()
        llenar_combo_hardware()
        controles(False, True)
        actualizar_tabla()
        mostrar(0)

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_cancelado.CheckedChanged

    End Sub

    Private Sub CheckBox1_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Check_cancelado.TabStopChanged
        Check_cancelado.TabStop = False
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_retirado.CheckedChanged
        Check_retirado.TabStop = False
    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress
        limpiar_datos_clientes()

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
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_clientes()
            guion_rut_cliente()
            mostrar_datos_clientes()
        End If
    End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub

    Private Sub txt_diagnostico_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_diagnostico_cliente.GotFocus
        txt_diagnostico_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_diagnostico_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_diagnostico_cliente.KeyPress
        'e.KeyChar = e.KeyChar.ToString.ToUpper

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
    Private Sub txt_diagnostico_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_diagnostico_cliente.LostFocus
        txt_diagnostico_cliente.BackColor = Color.White
    End Sub

    Private Sub txt_diagnostico_tecnico_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_diagnostico_tecnico.GotFocus
        txt_diagnostico_tecnico.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_diagnostico_tecnico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_diagnostico_tecnico.KeyPress
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
    Private Sub txt_diagnostico_tecnico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_diagnostico_tecnico.LostFocus
        txt_diagnostico_tecnico.BackColor = Color.White
    End Sub

    Private Sub txt_detalle_de_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_detalle_de_pago.GotFocus
        txt_detalle_de_pago.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_detalle_de_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_detalle_de_pago.KeyPress
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
    Private Sub txt_detalle_de_pago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_detalle_de_pago.LostFocus
        txt_detalle_de_pago.BackColor = Color.White
    End Sub

    Private Sub txt_pago_parcial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pago_parcial.GotFocus
        txt_pago_parcial.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_pago_parcial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pago_parcial.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txt_pago_parcial_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pago_parcial.LostFocus
        txt_pago_parcial.BackColor = Color.White
    End Sub

    Private Sub txt_total_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.GotFocus
        txt_total.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_total_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txt_total_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.LostFocus
        txt_total.BackColor = Color.White
    End Sub

    Private Sub txt_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cargar.GotFocus
        txt_cargar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cargar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cargar.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            cargar_documento()
            txt_rut_cliente.Focus()
            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If
    End Sub
    Private Sub txt_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cargar.LostFocus
        txt_cargar.BackColor = Color.White
    End Sub

    'Private Sub txt_nro_doc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.GotFocus
    '    txt_nro_doc.BackColor = Color.LightSkyBlue
    'End Sub
    'Private Sub txt_nro_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.LostFocus
    '    txt_nro_doc.BackColor = Color.White
    'End Sub

    Private Sub btn_agregar_clientes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_clientes.GotFocus
        btn_agregar_clientes.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_agregar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_clientes.LostFocus
        btn_agregar_clientes.BackColor = Color.Transparent
    End Sub

    Private Sub btn_anterior_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.GotFocus
        btn_anterior.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_anterior_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.LostFocus
        btn_anterior.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_clientes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.GotFocus
        btn_buscar_clientes.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_buscar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.LostFocus
        btn_buscar_clientes.BackColor = Color.Transparent
    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_busqueda_recepcion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_busqueda_recepcion.GotFocus
        btn_busqueda_recepcion.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_busqueda_recepcion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_busqueda_recepcion.LostFocus
        btn_busqueda_recepcion.BackColor = Color.Transparent
    End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.GotFocus
        btn_nueva.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.LostFocus
        btn_nueva.BackColor = Color.Transparent
    End Sub

    Private Sub btn_primero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.GotFocus
        btn_primero.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_primero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.LostFocus
        btn_primero.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.GotFocus
        btn_siguiente.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_siguiente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.LostFocus
        btn_siguiente.BackColor = Color.Transparent
    End Sub

    Private Sub btn_ultimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.GotFocus
        btn_ultimo.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub btn_ultimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.LostFocus
        btn_ultimo.BackColor = Color.Transparent
    End Sub

    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub txt_diagnostico_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_diagnostico_cliente.TextChanged
        GroupBox1.Text = "DIAGNOSTICO DEL TECNICO (CARACTERES DISPONIBLES " & txt_diagnostico_cliente.MaxLength - Len(txt_diagnostico_cliente.Text) & ")"
    End Sub

    Private Sub txt_diagnostico_tecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_diagnostico_tecnico.TextChanged
        GroupBox_tecnico.Text = "DIAGNOSTICO DEL TECNICO (CARACTERES DISPONIBLES " & txt_diagnostico_tecnico.MaxLength - Len(txt_diagnostico_tecnico.Text) & ")"
    End Sub

    Private Function ReturnDataSet() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        Dim hardware As String = ""
        For i = 0 To (CheckedListBox_hardware.Items.Count - 1)
            If CheckedListBox_hardware.GetItemChecked(i) = True Then
                If hardware = "" Then
                    hardware = CheckedListBox_hardware.Items(i).ToString
                Else
                    hardware = hardware & ", " & CheckedListBox_hardware.Items(i).ToString
                End If
            End If
        Next

        If hardware <> "" Then
            hardware = hardware & "."
        End If

        dt.Columns.Add(New DataColumn("logo_empresa", GetType(Byte())))
        dt.Columns.Add(New DataColumn("DataColumn1", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn2", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn3", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn4", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn5", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn6", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn7", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn8", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn9", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn10", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn11", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn12", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn13", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
        dr = dt.NewRow()

        If VarSeleccion = 1 Then
            Dim fecha_recepcion As String = Form_menu_principal.dtp_fecha.Text
            Dim mifecha As Date
            mifecha = fecha_recepcion
            fecha_recepcion = mifecha.ToString("yyy-MM-dd")

            txt_hora.Text = Form_menu_principal.lbl_hora.Text
            txt_fecha.Text = fecha_recepcion
        End If

        Try
            dr("logo_empresa") = Imagen_reporte
        Catch
        End Try

        Dim total As String
        Dim pago_parcial As String

        total = txt_total.Text
        pago_parcial = txt_pago_parcial.Text

        If total = "" Or total = "0" Then
            total = "0"
        Else
            total = Format(Int(total), "###,###,###")
        End If

        If pago_parcial = "" Or pago_parcial = "0" Then
            pago_parcial = "0"
        Else
            pago_parcial = Format(Int(pago_parcial), "###,###,###")
        End If

        dr("nombre_empresa") = minombreempresa
        dr("giro_empresa") = migiroempresa
        dr("direccion_empresa") = midireccionempresa
        dr("comuna_empresa") = micomunaempresa
        dr("telefono_empresa") = mitelefonoempresa
        dr("correo_empresa") = micorreoempresa
        dr("rut_empresa") = mirutempresa
        dr("DataColumn1") = txt_rut_cliente.Text
        dr("DataColumn2") = txt_nombre_cliente.Text
        dr("DataColumn3") = txt_direccion_cliente.Text
        dr("DataColumn4") = txt_comuna_cliente.Text
        dr("DataColumn5") = txt_nro_doc.Text
        dr("DataColumn6") = txt_telefono.Text
        dr("DataColumn7") = txt_fecha.Text
        dr("DataColumn8") = txt_hora.Text
        dr("DataColumn9") = txt_diagnostico_cliente.Text
        dr("DataColumn10") = txt_diagnostico_tecnico.Text
        dr("DataColumn11") = total
        dr("DataColumn12") = pago_parcial
        dr("DataColumn13") = hardware
        dt.Rows.Add(dr)

        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "DS_reporte"
        Dim iDS As New DS_reporte
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS
    End Function

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        VarSeleccion = 2

        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = False
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If


        'Try
        '    Dim iReporte As New form_informe_estado_de_cuenta_personalizado
        '    Dim rpt As New Crystal_recepcion_de_trabajo
        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()
        '    iReporte.Reporte = rpt
        '    iReporte.ShowDialog()
        '    'rpt.PrintOptions.PrinterName = impresora_reportes
        '    'rpt.PrintToPrinter(1, False, 0, 0)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Sub crear_numero_documento()
        Dim varnumdoc As Integer

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from recepcion_de_trabajos"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
            End If
        Catch err As InvalidCastException
            txt_nro_doc.Text = 1
            Exit Sub
        End Try
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select n_recepcion from recepcion_de_trabajos where cod_auto='" & (varnumdoc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_recepcion")
                txt_nro_doc.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_doc.Text = 1
        End Try
        conexion.Close()
    End Sub

    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_cliente.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_cliente.Text = rut_cliente
            End If
        End If
    End Sub

    Sub mostrar_datos_clientes()
        conexion.Close()
        If txt_rut_cliente.Text <> "" Then
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_rut_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("rut_cliente")
                txt_nombre_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_cliente")
                txt_direccion_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("direccion_cliente")
                txt_cod_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("cod_cliente")
                txt_giro_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("giro_cliente")
                txt_comuna_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("comuna_cliente")
                txt_telefono.Text = DS2.Tables(DT2.TableName).Rows(0).Item("telefono_cliente")
                txt_correo_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("email_cliente")
                txt_ciudad_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("ciudad_cliente")
                conexion.Close()
            ElseIf DS2.Tables(DT2.TableName).Rows.Count < 1 Then
                Dim valormensaje As Integer
                valormensaje = MsgBox("CLIENTE NO ENCONTRADO ¿DESEA REGISTRARLO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
                If valormensaje = vbYes Then
                    Form_registro_clientes_recepcion.Show()
                    Me.Enabled = False
                End If
                If valormensaje = vbYes Then
                    txt_rut_cliente.Focus()
                    conexion.Close()
                End If
            End If
        End If
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub cargar_documento()
        Dim cancelado As String = ""
        Dim retirado As String = ""

        conexion.Close()
        If txt_cargar.Text <> "" Then
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from recepcion_de_trabajos where n_recepcion ='" & (txt_cargar.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            Try
                If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                    txt_rut_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("rut_cliente")
                    txt_diagnostico_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("diagnostico_cliente")
                    txt_diagnostico_tecnico.Text = DS2.Tables(DT2.TableName).Rows(0).Item("diagnostico_tecnico")
                    txt_detalle_de_pago.Text = DS2.Tables(DT2.TableName).Rows(0).Item("detalle_pago")
                    cancelado = DS2.Tables(DT2.TableName).Rows(0).Item("cancelado")
                    retirado = DS2.Tables(DT2.TableName).Rows(0).Item("retirado")
                    txt_fecha.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha")
                    txt_hora.Text = DS.Tables(DT.TableName).Rows(0).Item("hora")
                    Combo_estado.Text = DS.Tables(DT.TableName).Rows(0).Item("estado")

                    If cancelado = "SI" Then
                        Check_cancelado.Checked = True
                    Else
                        Check_cancelado.Checked = False
                    End If

                    If retirado = "SI" Then
                        Check_retirado.Checked = True
                    Else
                        Check_retirado.Checked = False
                    End If
                    txt_total.Text = DS2.Tables(DT2.TableName).Rows(0).Item("total_presupuesto")
                    txt_pago_parcial.Text = DS2.Tables(DT2.TableName).Rows(0).Item("pago_parcial")
                    txt_nro_doc.Text = DS2.Tables(DT2.TableName).Rows(0).Item("n_recepcion")
                    mostrar_datos_clientes()
                    cargar_combo_hardware()
                ElseIf DS2.Tables(DT2.TableName).Rows.Count < 1 Then
                    MsgBox("DOCUMENTO NO ENCONTRADO", 0 + 16, "ERROR")
                    txt_rut_cliente.Focus()
                    conexion.Close()
                End If
            Catch
            End Try














        End If
    End Sub

    Sub limpiar_datos_clientes()
        txt_nombre_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_giro_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_telefono.Text = ""
        txt_ciudad_cliente.Text = ""
        txt_correo_cliente.Text = ""
    End Sub

    Sub grabar_recepcion()
        Dim cancelado As String = ""
        Dim retirado As String = ""

        If Check_cancelado.Checked = True Then
            cancelado = "SI"
        Else
            cancelado = "NO"
        End If

        If Check_retirado.Checked = True Then
            retirado = "SI"
        Else
            retirado = "NO"
        End If

        If txt_cod_cliente.Text = "" Or txt_rut_cliente.Text = "" Or txt_nombre_cliente.Text = "" Then
            txt_rut_cliente.Text = "11111111-1"
            txt_cod_cliente.Text = "0"
            txt_nombre_cliente.Text = "SIN NOMBRE"
            txt_direccion_cliente.Text = "SIN DIRECCION"
            txt_giro_cliente.Text = "SIN GIRO"
            txt_comuna_cliente.Text = "SIN COMUNA"
            txt_telefono.Text = "000000"
            txt_correo_cliente.Text = "SIN CORREO"
            txt_ciudad_cliente.Text = "SIN CIUDAD"
        End If


        If txt_pago_parcial.Text = "" Then
            txt_pago_parcial.Text = "0"
        End If

        If txt_total.Text = "" Then
            txt_total.Text = "0"
        End If

        If txt_detalle_de_pago.Text = "" Then
            txt_detalle_de_pago.Text = "-"
        End If




        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `recepcion_de_trabajos` (`n_recepcion`, `rut_cliente`, `diagnostico_tecnico`, `diagnostico_cliente`, `detalle_pago`, `cancelado`, `retirado`, `total_presupuesto`, `pago_parcial`, estado, usuario_responsable, fecha, hora) VALUES ('" & (txt_nro_doc.Text) & "', '" & (txt_rut_cliente.Text) & "', '" & (txt_diagnostico_tecnico.Text) & "', '" & (txt_diagnostico_cliente.Text) & "', '" & (txt_detalle_de_pago.Text) & "', '" & (cancelado) & "', '" & (retirado) & "', '" & (txt_total.Text) & "', '" & (txt_pago_parcial.Text) & "', '" & (Combo_estado.Text) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (Form_menu_principal.lbl_hora.Text) & "');"
        DA.SelectCommand = SC
        DA.Fill(DT)
        actualizar_tabla()
    End Sub

    Sub actualizar_recepcion()
        Dim cancelado As String = ""
        Dim retirado As String = ""

        If Check_cancelado.Checked = True Then
            cancelado = "SI"
        Else
            cancelado = "NO"
        End If

        If Check_retirado.Checked = True Then
            retirado = "SI"
        Else
            retirado = "NO"
        End If

        SC.Connection = conexion
        SC.CommandText = "UPDATE recepcion_de_trabajos SET rut_cliente='" & (txt_rut_cliente.Text) & "', diagnostico_tecnico='" & (txt_diagnostico_tecnico.Text) & "', diagnostico_cliente='" & (txt_diagnostico_cliente.Text) & "', detalle_pago='" & (txt_detalle_de_pago.Text) & "', cancelado='" & (cancelado) & "', retirado='" & (retirado) & "', total_presupuesto='" & (txt_total.Text) & "', pago_parcial='" & (txt_pago_parcial.Text) & "', estado='" & (Combo_estado.Text) & "', usuario_responsable='" & (miusuario) & "' WHERE  n_recepcion='" & (txt_nro_doc.Text) & "' and  cod_auto<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)
        actualizar_tabla()
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        CheckedListBox_hardware.Enabled = a
        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a
        btn_imprimir.Enabled = b
        btn_limpiar.Enabled = a
        btn_nueva.Enabled = b
        btn_modificar.Enabled = b
        btn_buscar_clientes.Enabled = a
        btn_agregar_clientes.Enabled = a
        txt_diagnostico_cliente.Enabled = a
        txt_diagnostico_tecnico.Enabled = a

        btn_busqueda_recepcion.Enabled = a

        txt_rut_cliente.Enabled = a
        txt_nombre_cliente.Enabled = a
        txt_direccion_cliente.Enabled = a
        txt_comuna_cliente.Enabled = a
        txt_correo_cliente.Enabled = a
        txt_telefono.Enabled = a
        txt_giro_cliente.Enabled = a
        txt_ciudad_cliente.Enabled = a

        txt_detalle_de_pago.Enabled = a
        Check_cancelado.Enabled = a
        Check_retirado.Enabled = a
        txt_total.Enabled = a
        txt_pago_parcial.Enabled = a
        txt_cargar.Enabled = b
        txt_nro_doc.Enabled = a

        Combo_estado.Enabled = a

        GroupBox_cargar.Enabled = b
        'GroupBox_clientes.Enabled = a
        GroupBox_posicion.Enabled = b
        'GroupBox_tecnico.Enabled = a
        'GroupBox1.Enabled = a
        ' GroupBox3.Enabled = a
        'GroupBox4.Enabled = a
        'GroupBox5.Enabled = a
        'GroupBox6.Enabled = a
        'GroupBox7.Enabled = a

        txt_hora.Enabled = a
        txt_fecha.Enabled = a

        If txt_rut_cliente.Enabled = True Then
            txt_rut_cliente.BackColor = Color.White
        Else
            txt_rut_cliente.BackColor = SystemColors.Control
        End If

        If txt_cargar.Enabled = True Then
            txt_cargar.BackColor = Color.White
        Else
            txt_cargar.BackColor = SystemColors.Control
        End If
    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        controles(True, False)
        limpiar()
        llenar_combo_hardware()
        VarSeleccion = 1
        crear_numero_documento()
        txt_hora.Text = ""
        txt_fecha.Text = ""
        Combo_estado.Text = "EN PROCESO"
        Combo_estado.Enabled = False
        txt_rut_cliente.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        SC.CommandText = "select * from recepcion_de_trabajos order by n_recepcion desc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub

    Sub mostrar(ByVal i As Integer)
        Dim cancelado As String = ""
        Dim retirado As String = ""
        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                txt_diagnostico_cliente.Text = DS.Tables(DT.TableName).Rows(i).Item("diagnostico_cliente")
                txt_diagnostico_tecnico.Text = DS.Tables(DT.TableName).Rows(i).Item("diagnostico_tecnico")
                txt_detalle_de_pago.Text = DS.Tables(DT.TableName).Rows(i).Item("detalle_pago")
                cancelado = DS.Tables(DT.TableName).Rows(i).Item("cancelado")
                retirado = DS.Tables(DT.TableName).Rows(i).Item("retirado")
                txt_fecha.Text = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                txt_hora.Text = DS.Tables(DT.TableName).Rows(i).Item("hora")
                Combo_estado.Text = DS.Tables(DT.TableName).Rows(i).Item("estado")

                If cancelado = "SI" Then
                    Check_cancelado.Checked = True
                Else
                    Check_cancelado.Checked = False
                End If

                If retirado = "SI" Then
                    Check_retirado.Checked = True
                Else
                    Check_retirado.Checked = False
                End If
                txt_total.Text = DS.Tables(DT.TableName).Rows(i).Item("total_presupuesto")
                txt_pago_parcial.Text = DS.Tables(DT.TableName).Rows(i).Item("pago_parcial")
                txt_nro_doc.Text = DS.Tables(DT.TableName).Rows(i).Item("n_recepcion")
                mostrar_datos_clientes()
                cargar_combo_hardware()
            End If
        Catch
        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If txt_rut_cliente.Text = "" Then
            MsgBox("CAMPO RUT CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO NOMBRE CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_cliente.Focus()
            Exit Sub
        End If

        If txt_diagnostico_cliente.Text = "" Then
            MsgBox("CAMPO DIAGNOSTICO DE CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_cliente.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        If VarSeleccion = 1 Then
            crear_numero_documento()
            grabar_recepcion()
            grabar_detalle()



            PrintDialog1.Document = PrintDocument1

            If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintDocument1.Print()

                Try
                    PrintDocument1.DefaultPageSettings.Landscape = False
                    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
                Catch
                End Try
            End If


            'Try
            '    Dim iReporte As New form_informe_estado_de_cuenta_personalizado
            '    Dim rpt As New Crystal_recepcion_de_trabajo
            '    rpt.Load()
            '    rpt.SetDataSource(ReturnDataSet)
            '    rpt.Refresh()
            '    iReporte.Reporte = rpt
            '    iReporte.ShowDialog()
            '    'rpt.PrintOptions.PrinterName = impresora_reportes
            '    'rpt.PrintToPrinter(1, False, 0, 0)
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try

        End If

        If VarSeleccion = 2 Then
            If Combo_estado.Text <> "RETIRADO" Then
                Dim valormensaje As Integer
                valormensaje = MsgBox("¿DESEA CAMBIAR EL ESTADO A RETIRADO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
                If valormensaje = vbYes Then
                    Combo_estado.Text = "RETIRADO"
                End If
            End If

            actualizar_recepcion()
            grabar_detalle()
            MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        End If



        controles(False, True)
        'MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_primero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_primero.Click
        MiPos = 0
        mostrar(0)
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        MiPos = DT.Rows.Count - 1
        mostrar(MiPos)
    End Sub

    Sub limpiar()
        For Each cntrl As Control In Me.Controls
            If (TypeOf (cntrl) Is GroupBox) Then ' Verifico que el control sea un textbox
                For Each myControl In cntrl.Controls

                    If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
                        CType(myControl, TextBox).Text = "" ' Le cambio el valor a la propiedad
                    End If

                    If (TypeOf (myControl) Is DataGridView) Then ' Verifico que el control sea un textbox
                        CType(myControl, DataGridView).Rows.Clear() ' Le cambio el valor a la propiedad
                    End If
                Next
            End If
        Next

        For Each myControl As Control In Me.Controls
            If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
                CType(myControl, TextBox).Text = "" ' Le cambio el valor a la propiedad
            End If

            If (TypeOf (myControl) Is DataGridView) Then ' Verifico que el control sea un textbox
                CType(myControl, DataGridView).Rows.Clear() ' Le cambio el valor a la propiedad
            End If
        Next

        Check_cancelado.Checked = False
        Check_retirado.Checked = False
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub txt_cargar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cargar.TextChanged

    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        VarSeleccion = 2
        controles(True, False)

        If CheckedListBox_hardware.Items.Count = 0 Then
            llenar_combo_hardware()
        End If

        txt_rut_cliente.Focus()
    End Sub

    Sub llenar_combo_hardware()
        conexion.Close()
        CheckedListBox_hardware.Items.Clear()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from hardware where nombre <> 'TODOS' order by nombre"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                CheckedListBox_hardware.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre"))
            Next
        End If
        conexion.Close()
        CheckedListBox_hardware.Items.Add("OTROS")
    End Sub


    Sub cargar_combo_hardware()
        Dim hardware As String

        For i = 0 To (CheckedListBox_hardware.Items.Count - 1)
            CheckedListBox_hardware.SetItemChecked(i, False)
        Next


        conexion.Close()
        'CheckedListBox_hardware.Items.Clear()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from detalle_recepcion_de_trabajos where nro_recepcion='" & (txt_nro_doc.Text) & "'"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                hardware = DS3.Tables(DT3.TableName).Rows(i).Item("hardware")
                For e = 0 To (CheckedListBox_hardware.Items.Count - 1)
                    If hardware = CheckedListBox_hardware.Items(e) Then
                        CheckedListBox_hardware.SetItemChecked(e, True)
                    End If
                Next
            Next
        End If
        conexion.Close()


        'For i = 0 To (CheckedListBox_hardware.Items.Count - 1)
        '    CheckedListBox_hardware.SetItemChecked(i, True)
        'Next

        'conexion.Close()
        ''CheckedListBox_hardware.Items.Clear()
        'DS3.Tables.Clear()
        'DT3.Rows.Clear()
        'DT3.Columns.Clear()
        'DS3.Clear()
        'conexion.Open()
        'SC3.Connection = conexion
        'SC3.CommandText = "select * from hardware where nombre <> 'TODOS' order by nombre"
        'DA3.SelectCommand = SC3
        'DA3.Fill(DT3)
        'DS3.Tables.Add(DT3)
        'If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
        '    For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
        '        CheckedListBox_hardware.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre"))
        '    Next
        'End If
        'conexion.Close()
    End Sub

    Sub grabar_detalle()


        SC3.Connection = conexion
        SC3.CommandText = "DELETE FROM detalle_recepcion_de_trabajos WHERE nro_recepcion='" & (txt_nro_doc.Text) & "' and `cod_auto`<>'1';"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)


        Dim hardware As String
        For i = 0 To (CheckedListBox_hardware.Items.Count - 1)
            If CheckedListBox_hardware.GetItemChecked(i) = True Then
                hardware = CheckedListBox_hardware.Items(i).ToString

                SC3.Connection = conexion
                SC3.CommandText = "INSERT INTO detalle_recepcion_de_trabajos (`hardware`, `nro_recepcion`) VALUES ('" & (hardware) & "', '" & (txt_nro_doc.Text) & "');"
                DA3.SelectCommand = SC3
                DA3.Fill(DT3)

            End If
        Next

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        actualizar_tabla()
        controles(False, True)
        mostrar(MiPos)
    End Sub

    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged

    End Sub

    Private Sub btn_agregar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_clientes.Click
        Form_registro_clientes_recepcion.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.Click
        Form_buscador_clientes_recepcion.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_guardar_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.HandleCreated

    End Sub

    Private Sub btn_busqueda_recepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_busqueda_recepcion.Click
        Form_buscador_recepciones.Show()
        Me.Enabled = False
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If VarSeleccion = 1 Then
            Dim fecha_recepcion As String = Form_menu_principal.dtp_fecha.Text
            Dim mifecha As Date
            mifecha = fecha_recepcion
            fecha_recepcion = mifecha.ToString("yyy-MM-dd")

            txt_hora.Text = Form_menu_principal.lbl_hora.Text
            txt_fecha.Text = fecha_recepcion
        End If

        Dim hardware As String = ""
        For i = 0 To (CheckedListBox_hardware.Items.Count - 1)
            If CheckedListBox_hardware.GetItemChecked(i) = True Then
                If hardware = "" Then
                    hardware = CheckedListBox_hardware.Items(i).ToString
                Else
                    hardware = hardware & ", " & CheckedListBox_hardware.Items(i).ToString
                End If
            End If
        Next

        If hardware <> "" Then
            hardware = hardware & "."
        End If

        Dim total As String
        Dim pago_parcial As String

        total = txt_total.Text
        pago_parcial = txt_pago_parcial.Text

        If total = "" Or total = "0" Then
            total = "0"
        Else
            total = Format(Int(total), "###,###,###")
        End If

        If pago_parcial = "" Or pago_parcial = "0" Then
            pago_parcial = "0"
        Else
            pago_parcial = Format(Int(pago_parcial), "###,###,###")
        End If

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 6.5, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 6.5, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = -30
        margen_superior = 0

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), 560, 10, 260, 70)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 85, margen_izquierdo + 810, margen_superior + 45)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 100, margen_izquierdo + 810, margen_superior + 60)

        e.Graphics.DrawString("PRESUPUESTO DE TRABAJO", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 118, margen_izquierdo + 865, margen_superior + 118)

        If txt_nombre_cliente.Text.Length > 20 Then
            txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 20)
        End If

        If txt_direccion_cliente.Text.Length > 20 Then
            txt_direccion_cliente.Text = txt_direccion_cliente.Text.Substring(0, 20)
        End If

        e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 125)
        e.Graphics.DrawString("SEÑORES", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 140)
        e.Graphics.DrawString("DIRECCION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 155)
        e.Graphics.DrawString("COMUNA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 170)

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 120, margen_superior + 125)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 120, margen_superior + 140)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 120, margen_superior + 155)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 120, margen_superior + 170)

        e.Graphics.DrawString(txt_rut_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 125)
        e.Graphics.DrawString(txt_nombre_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 140)
        e.Graphics.DrawString(txt_direccion_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 155)
        e.Graphics.DrawString(txt_comuna_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 130, margen_superior + 170)

        e.Graphics.DrawString("N° DOCUMENTO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 125)
        e.Graphics.DrawString("TELEFONO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 140)
        e.Graphics.DrawString("FECHA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 155)
        e.Graphics.DrawString("HORA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 170)

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 595, margen_superior + 125)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 595, margen_superior + 140)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 595, margen_superior + 155)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 595, margen_superior + 170)

        e.Graphics.DrawString(txt_nro_doc.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 605, margen_superior + 125)
        e.Graphics.DrawString(txt_telefono.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 605, margen_superior + 140)
        e.Graphics.DrawString(txt_fecha.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 605, margen_superior + 155)
        e.Graphics.DrawString(txt_hora.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 605, margen_superior + 170)

        Dim rect_titulo_columna_1 As New Rectangle(margen_izquierdo + 50, margen_superior + 190, margen_izquierdo + 420, margen_superior + 45)
        Dim rect_titulo_columna_2 As New Rectangle(margen_izquierdo + 440, margen_superior + 190, margen_izquierdo + 450, margen_superior + 45)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 200, margen_izquierdo + 865, margen_superior + 200)

        e.Graphics.DrawString("DIAGNOSTICO CLIENTE", Font_titulo, Brushes.Black, rect_titulo_columna_1, stringFormat)
        e.Graphics.DrawString("DIAGNOSTICO TECNICO", Font_titulo, Brushes.Black, rect_titulo_columna_2, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 225, margen_izquierdo + 865, margen_superior + 225)

        Dim rect_columna_1 As New Rectangle(margen_izquierdo + 50, margen_superior + 230, margen_izquierdo + 420, margen_superior + 130)
        Dim rect_columna_2 As New Rectangle(margen_izquierdo + 440, margen_superior + 230, margen_izquierdo + 450, margen_superior + 130)

        e.Graphics.DrawString(txt_diagnostico_cliente.Text, Font_campos_superiores, Brushes.Black, rect_columna_1, stringFormat)
        e.Graphics.DrawString(txt_diagnostico_tecnico.Text, Font_campos_superiores, Brushes.Black, rect_columna_2, stringFormat)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 370, margen_izquierdo + 865, margen_superior + 370)

        e.Graphics.DrawString("HARDWARE A REVISAR:", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 375)
        e.Graphics.DrawString(hardware, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 390)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 470, margen_izquierdo + 300, margen_superior + 470)
        e.Graphics.DrawString("FIRMA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 150, margen_superior + 475)

        e.Graphics.DrawString("TOTAL PRESUPUESTO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 640, margen_superior + 460)
        e.Graphics.DrawString("PAGO PARCIAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 640, margen_superior + 475)

        e.Graphics.DrawString(":", Font_datos_empresa, Brushes.Black, margen_izquierdo + 770, margen_superior + 460)
        e.Graphics.DrawString(":", Font_datos_empresa, Brushes.Black, margen_izquierdo + 770, margen_superior + 475)

        e.Graphics.DrawString(total, Font_campos_superiores, Brushes.Black, margen_izquierdo + 850, margen_superior + 460, format1)
        e.Graphics.DrawString(pago_parcial, Font_campos_superiores, Brushes.Black, margen_izquierdo + 850, margen_superior + 475, format1)

        e.Graphics.DrawString("NOTA, EL SERVICIO TÉCNICO NO SE HACE RESPONSABLE DE LOS SIGUIENTES CASOS:", Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 490)
        e.Graphics.DrawString("● PÉRDIDA TOTAL O PARCIAL DE INFORMACIÓN ALMACENADA EN EL DISCO DURO.", Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 500)
        e.Graphics.DrawString("● ES RESPONSABILIDAD DEL CLIENTE TENER RESPALDADA ADECUADAMENTE LA INFORMACIÓN.", Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 510)
        e.Graphics.DrawString("● ROTURAS EN LOS SELLOS DE GARANTÍA POR INTERVENCIONES DE TERCEROS.", Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 520)
        e.Graphics.DrawString("● EL CLIENTE TIENE UN PLAZO DE 30 DÍAS PARA RETIRAR EL EQUIPO DESDE LA FECHA DE ACEPTACIÓN DEL PRESUPUESTO EN REPARACIÓN.", Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 530)
        e.Graphics.DrawString("● SI NO TENDRÁ QUE CANCELAR UN BODEGAJE DE 0,05 UF POR DÍA MÁS $3000 PESOS DE COSTOS POR EL TRASLADO A BODEGA.", Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 540)
        e.Graphics.DrawString("● EL SERVICIO TÉCNICO DESPUÉS DE UN PLAZO DE 60 DÍAS NO SE HACE RESPONSABLE DE DAÑOS, PERDIDAS PARCIALES O TOTALES DEL PRODUCTO.", Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 550)
    End Sub
End Class