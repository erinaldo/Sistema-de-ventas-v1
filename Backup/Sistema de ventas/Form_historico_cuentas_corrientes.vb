Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_historico_cuentas_corrientes
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim alto_cotizacion As String
    Private WithEvents Pd As New PrintDocument
    Dim numero_lineas_total As Integer = 0

    Private Sub Form_historico_cuentas_corrientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_historico_cuentas_corrientes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_historico_cuentas_corrientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        'mostrar_malla_abonos()
        'calcular_totales()

        grilla_cobranzas.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
        grilla_abonos.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
        grilla_estado_de_cuenta.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)

        dtp_desde.Value = dtp_desde.Value.AddYears(Val(-1))
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
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


    Sub calcular_totales()

        Dim totalgrilla As Long

        '//Calcular el total 
        txt_total.Text = 0
        For i = 0 To grilla_abonos.Rows.Count - 1
            totalgrilla = Val(grilla_abonos.Rows(i).Cells(7).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next


    End Sub
    Sub limpiar()
        txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        grilla_abonos.DataSource = Nothing
        dtp_desde.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_hasta.Text = FormatDateTime(Now, DateFormat.ShortDate)

        grilla_cobranzas.Rows.Clear()
        grilla_cobranzas.Columns.Clear()

        grilla_estado_de_cuenta.Rows.Clear()
        grilla_estado_de_cuenta.Columns.Clear()

        txt_rut_cliente.Focus()
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
                txt_nombre_cliente.Text = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_cliente")
                conexion.Close()
                Exit Sub
            ElseIf DS2.Tables(DT2.TableName).Rows.Count < 1 Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
        End If
    End Sub

    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_cliente.Text
        If txt_rut_cliente.Text.Contains("PROPIEDAD") = False Then
            If rut_cliente.Length > 2 Then

                guion = rut_cliente(rut_cliente.Length - 2).ToString()

                If guion <> "-" Then
                    Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                    rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                    rut_cliente = rut_cliente & "-" & fin_rut
                    txt_rut_cliente.Text = rut_cliente
                End If
            End If
        End If
    End Sub

    Sub mostrar_malla_abonos()

        lbl_mensaje.Visible = True
        Me.Enabled = False



        fecha()

        grilla_abonos.DataSource = Nothing

        If txt_nombre_cliente.Text = "" Then

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            'SC3.CommandText = "select fecha as 'FECHA', n_abono as 'NRO.', condicion_abono as 'CONDIC.', detalle_abono as 'DETALLE',  estado as 'ESTADO', nombre_cliente as 'CLIENTE', abono.rut_cliente as 'RUT', monto_abono as 'TOTAL', nombre_usuario as 'USUARIO' from abono, usuarios, clientes  where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and abono.usuario_responsable=usuarios.rut_usuario and abono.rut_cliente=clientes.rut_cliente group by n_abono order by n_abono asc"
            'SC3.CommandText = "select fecha as 'FECHA', n_abono as 'NRO.', condicion_abono as 'CONDIC.', detalle_abono as 'DETALLE',  estado as 'ESTADO', nombre as 'CLIENTE', abono.rut_cliente as 'RUT', monto_abono as 'TOTAL', nombre_usuario as 'USUARIO' from abono, usuarios  where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and abono.usuario_responsable=usuarios.rut_usuario group by n_abono order by n_abono asc"



            If Check_historico.Checked = False Then
                SC3.CommandText = "select fecha as 'FECHA', n_abono as 'NRO.', condicion_abono as 'CONDIC.', detalle_abono as 'DETALLE',  estado as 'ESTADO', nombre as 'CLIENTE', abono.rut_cliente as 'RUT', monto_abono as 'TOTAL', nombre_usuario as 'USUARIO' from abono, usuarios  where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and abono.usuario_responsable=usuarios.rut_usuario group by n_abono order by n_abono asc"
            Else
                SC3.CommandText = "select fecha as 'FECHA', n_abono as 'NRO.', condicion_abono as 'CONDIC.', detalle_abono as 'DETALLE',  estado as 'ESTADO', nombre as 'CLIENTE', abono.rut_cliente as 'RUT', monto_abono as 'TOTAL', nombre_usuario as 'USUARIO' from abono, usuarios  where abono.usuario_responsable=usuarios.rut_usuario group by n_abono order by n_abono asc"
            End If


            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_abonos.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_abonos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_abonos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If

        If txt_nombre_cliente.Text <> "" Then

            conexion.Close()
            Dim DT3 As New DataTable

            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()

            SC3.Connection = conexion

            '  SC3.CommandText = "select fecha as 'FECHA', n_abono as 'NRO.', condicion_abono as 'CONDIC.',   detalle_abono as 'DETALLE',estado as 'ESTADO',  nombre_cliente as 'CLIENTE', abono.rut_cliente as 'RUT', monto_abono as 'TOTAL', nombre_usuario as 'USUARIO' from abono, usuarios, clientes  where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and abono.usuario_responsable=usuarios.rut_usuario and abono.rut_cliente=clientes.rut_cliente  and abono.rut_cliente = '" & (txt_rut_cliente.Text) & "' order by n_abono desc"
            SC3.CommandText = "select fecha as 'FECHA', n_abono as 'NRO.', condicion_abono as 'CONDIC.', detalle_abono as 'DETALLE',  estado as 'ESTADO', nombre_cliente as 'CLIENTE', abono.rut_cliente as 'RUT', monto_abono as 'TOTAL', nombre_usuario as 'USUARIO' from abono, usuarios, clientes  where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and abono.usuario_responsable=usuarios.rut_usuario and abono.rut_cliente=clientes.rut_cliente and abono.rut_cliente = '" & (txt_rut_cliente.Text) & "' group by n_abono order by n_abono asc"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_abonos.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_abonos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_abonos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If
    End Sub

    Private Sub txt_rut_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress

        txt_nombre_cliente.Text = ""

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
        grilla_abonos.DataSource = Nothing
        grilla_cobranzas.Rows.Clear()
        grilla_cobranzas.Columns.Clear()
        grilla_estado_de_cuenta.Rows.Clear()
        grilla_estado_de_cuenta.Columns.Clear()
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            guion_rut_cliente()
            mostrar_datos_clientes()
        End If

    End Sub

    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged

    End Sub

    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet


    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("desde", GetType(String)))
    '    dt.Columns.Add(New DataColumn("hasta", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("numero", GetType(String)))
    '    dt.Columns.Add(New DataColumn("condicion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("cliente_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("total", GetType(String)))
    '    dt.Columns.Add(New DataColumn("usuario", GetType(String)))

    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("ciudad_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))






    '    Dim fecha As String
    '    Dim nuumero As String
    '    Dim condicion As String
    '    Dim detalle As String
    '    Dim cliente As String
    '    Dim rut_cliente As String
    '    Dim total As String
    '    Dim usuario As String




    '    For i = 0 To grilla_documento.Rows.Count - 1


    '        fecha = grilla_documento.Rows(i).Cells(0).Value.ToString
    '        nuumero = grilla_documento.Rows(i).Cells(1).Value.ToString
    '        condicion = grilla_documento.Rows(i).Cells(3).Value.ToString
    '        detalle = grilla_documento.Rows(i).Cells(2).Value.ToString
    '        cliente = grilla_documento.Rows(i).Cells(4).Value.ToString
    '        rut_cliente = grilla_documento.Rows(i).Cells(5).Value.ToString
    '        total = grilla_documento.Rows(i).Cells(6).Value.ToString
    '        usuario = grilla_documento.Rows(i).Cells(7).Value.ToString

    '        dr = dt.NewRow()

    '        Try
    '            dr("Imagen") = ImageToByte(Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_crystal.jpg"))
    '        Catch
    '        End Try

    '        dr("nombre_cliente") = txt_nombre_cliente.Text
    '        dr("rut_cliente") = txt_rut_cliente.Text
    '        dr("desde") = dtp_desde.Text
    '        dr("hasta") = dtp_hasta.Text
    '        dr("fecha") = fecha
    '        dr("numero") = nuumero
    '        dr("condicion") = condicion
    '        dr("detalle") = detalle
    '        dr("cliente_detalle") = cliente
    '        dr("rut_detalle") = rut_cliente
    '        dr("total") = total
    '        dr("usuario") = usuario

    '        dr("nombre_empresa") = minombreempresa
    '        dr("giro_empresa") = migiroempresa
    '        dr("direccion_empresa") = midireccionempresa
    '        dr("ciudad_empresa") = micomunaempresa
    '        dr("telefono_empresa") = mitelefonoempresa
    '        dr("correo_empresa") = micorreoempresa
    '        dr("rut_empresa") = mirutempresa
    '    Next





    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "ListadoAbonos"

    '    Dim iDS As New dsListadoAbonos

    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function
















    Private Function ReturnDataSet() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet




        dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("desde", GetType(String)))
        dt.Columns.Add(New DataColumn("hasta", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(Integer)))
        dt.Columns.Add(New DataColumn("condicion", GetType(String)))
        dt.Columns.Add(New DataColumn("detalle", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente_detalle", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_detalle", GetType(String)))
        dt.Columns.Add(New DataColumn("total", GetType(Integer)))
        dt.Columns.Add(New DataColumn("usuario", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("final", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("ciudad_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))



        Dim fecha As String
        Dim nuumero As String
        Dim condicion As String
        Dim estado As String
        Dim detalle As String
        Dim cliente As String
        Dim rut_cliente As String
        Dim total As String
        Dim usuario As String




        If txt_rut_cliente.Text = "" Then
            txt_rut_cliente.Text = "TODOS"
        End If

        If txt_nombre_cliente.Text = "" Then
            txt_nombre_cliente.Text = "TODOS"
        End If



        For i = 0 To grilla_abonos.Rows.Count - 1


            fecha = grilla_abonos.Rows(i).Cells(0).Value.ToString
            nuumero = grilla_abonos.Rows(i).Cells(1).Value.ToString
            condicion = grilla_abonos.Rows(i).Cells(2).Value.ToString
            detalle = grilla_abonos.Rows(i).Cells(3).Value.ToString
            estado = grilla_abonos.Rows(i).Cells(4).Value.ToString

            cliente = grilla_abonos.Rows(i).Cells(5).Value.ToString
            rut_cliente = grilla_abonos.Rows(i).Cells(6).Value.ToString
            total = grilla_abonos.Rows(i).Cells(7).Value.ToString
            usuario = grilla_abonos.Rows(i).Cells(8).Value.ToString



            dr = dt.NewRow()

            Try
                dr("Imagen") = Imagen_ticket
            Catch
            End Try

            dr("nombre_cliente") = txt_nombre_cliente.Text
            dr("rut_cliente") = txt_rut_cliente.Text
            dr("desde") = dtp_desde.Text
            dr("hasta") = dtp_hasta.Text
            dr("fecha") = fecha
            dr("numero") = nuumero
            dr("condicion") = condicion
            dr("detalle") = detalle
            dr("estado") = estado
            dr("cliente_detalle") = cliente
            dr("rut_detalle") = rut_cliente
            dr("total") = total
            dr("usuario") = usuario
            dr("final") = txt_total.Text
            dr("nombre_empresa") = minombreempresa
            dr("giro_empresa") = migiroempresa
            dr("direccion_empresa") = midireccionempresa
            dr("ciudad_empresa") = micomunaempresa
            dr("telefono_empresa") = mitelefonoempresa
            dr("correo_empresa") = micorreoempresa
            dr("rut_empresa") = mirutempresa

            dt.Rows.Add(dr)




        Next





        ds.Tables.Add(dt)
        '  ds.Tables(0).TableName = "Pedidos"
        ds.Tables(0).TableName = "ListadoAbonos"

        Dim iDS As New dsListadoAbonos
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS


        If txt_rut_cliente.Text = "TODOS" Then
            txt_rut_cliente.Text = ""
        End If

        If txt_nombre_cliente.Text = "TODOS" Then
            txt_nombre_cliente.Text = ""
        End If



    End Function





    Public Function ImageToByte(ByVal pImagen As Image) As Byte()
        Dim mImage() As Byte
        Try
            If Not IsNothing(pImagen) Then
                Dim ms As New System.IO.MemoryStream
                pImagen.Save(ms, pImagen.RawFormat)
                mImage = ms.GetBuffer
                ms.Close()
                Return mImage
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        If grilla_abonos.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

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

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_aviso_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aviso.GotFocus
        btn_aviso.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aviso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aviso.GotFocus
        btn_aviso.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub



    Private Sub txt_rut_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mensaje As String = ""



        If grilla_abonos.Rows.Count = 0 Then
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
            Exportar_Excel(Me.grilla_abonos, save.FileName)
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
        For c As Integer = 0 To grilla_abonos.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_abonos.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_abonos.RowCount - 1
            For c As Integer = 0 To grilla_abonos.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_abonos.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        'mostrar_malla()
        'calcular_totales()

        grilla_abonos.DataSource = Nothing
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        'mostrar_malla()
        'calcular_totales()


        grilla_abonos.DataSource = Nothing
    End Sub


    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_abonos.CellContentClick
        'Abrir()
    End Sub

    Private Sub grilla_documento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_abonos.Click
        ' Abrir()
    End Sub

    Private Sub grilla_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_abonos.DoubleClick
        Form_documentos_abono.Show()
        Me.Enabled = False

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If txt_rut_cliente.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        fecha()
        '  mostrar_datos_clientes()
        mostrar_malla_abonos()
        mostrar_malla_estado_de_cuenta()
        mostrar_malla_avisos_de_cobranza()

        calcular_totales()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub






    Sub mostrar_malla_estado_de_cuenta()

        grilla_estado_de_cuenta.Rows.Clear()
        grilla_estado_de_cuenta.Columns.Clear()
        grilla_estado_de_cuenta.Columns.Add("", "NRO.")
        grilla_estado_de_cuenta.Columns.Add("", "TIPO")
        grilla_estado_de_cuenta.Columns.Add("", "EMISION")
        grilla_estado_de_cuenta.Columns.Add("", "SUCURSAL")
        grilla_estado_de_cuenta.Columns.Add("", "VENC.")
        grilla_estado_de_cuenta.Columns.Add("", "TOTAL")
        grilla_estado_de_cuenta.Columns.Add("", "SALDO")
        grilla_estado_de_cuenta.Columns.Add("", "DEUDA")

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        If Check_historico.Checked = False Then
            SC.CommandText = "select * from creditos  where  rut_cliente = '" & (txt_rut_cliente.Text) & "'  and saldo <> '0' order by fecha_venta asc"
        Else
            SC.CommandText = "select * from creditos  where  rut_cliente = '" & (txt_rut_cliente.Text) & "' order by fecha_venta asc"
        End If

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim mifecha_emision2 As String
                Dim mifecha_vencimiento2 As String
                Dim MiFechaEmision As Date
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                Dim MiFechaVencimiento As Date
                MiFechaVencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                mifecha_vencimiento2 = MiFechaVencimiento.ToString("dd-MM-yyy")

                Dim tipo_detalle As String
                tipo_detalle = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")

                If tipo_detalle = "ABONO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE CREDITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE DEBITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"), _
                                                   mifecha_emision2, _
                                                    DS.Tables(DT.TableName).Rows(i).Item("recinto"), _
                                                     mifecha_vencimiento2, _
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("saldo"), _
                                                        Val(DS.Tables(DT.TableName).Rows(i).Item("saldo")) + Val(txt_total_deuda.Text))

                txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(DS.Tables(DT.TableName).Rows(i).Item("saldo"))
            Next

            grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 80 Then
                grilla_estado_de_cuenta.Columns(0).Width = 79
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 80
            End If
            grilla_estado_de_cuenta.Columns(2).Width = 80
            grilla_estado_de_cuenta.Columns(3).Width = 150
            grilla_estado_de_cuenta.Columns(4).Width = 80
            grilla_estado_de_cuenta.Columns(5).Width = 80
            grilla_estado_de_cuenta.Columns(6).Width = 80
            grilla_estado_de_cuenta.Columns(7).Width = 85
        End If


        Dim saldo As String
        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            saldo = grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString
            If saldo < "0" Then
                grilla_estado_de_cuenta.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
            End If
        Next
    End Sub


    Sub mostrar_malla_avisos_de_cobranza()

        grilla_cobranzas.Rows.Clear()
        grilla_cobranzas.Columns.Clear()
        grilla_cobranzas.Columns.Add("", "CLIENTE")
        grilla_cobranzas.Columns.Add("", "DETALLE")
        grilla_cobranzas.Columns.Add("", "TIPO")
        grilla_cobranzas.Columns.Add("", "FECHA")
        'fecha()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from registro_de_cobranzas, clientes where registro_de_cobranzas.rut_cliente=clientes.rut_cliente and registro_de_cobranzas.rut_cliente='" & (txt_rut_cliente.Text) & "' order by fecha asc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        Dim fecha_cobranza As String


        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                fecha_cobranza = DS.Tables(DT.TableName).Rows(i).Item("fecha")

                If fecha_cobranza.Length > 10 Then
                    fecha_cobranza = fecha_cobranza.Substring(0, 10)
                End If

                grilla_cobranzas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                       fecha_cobranza, _
                                                        DS.Tables(DT.TableName).Rows(i).Item("COD_AUTO"))
            Next
        End If


        If grilla_cobranzas.Rows.Count <> 0 Then
            If grilla_cobranzas.Columns(0).Width = 310 Then
                grilla_cobranzas.Columns(0).Width = 309
            Else
                grilla_cobranzas.Columns(0).Width = 310
            End If
            grilla_cobranzas.Columns(1).Width = 310
            grilla_cobranzas.Columns(2).Width = 200
            grilla_cobranzas.Columns(3).Width = 143
            grilla_cobranzas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_aviso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aviso.Click
        Form_cobranzas.Show()
        Form_cobranzas.txt_rut_cliente.Text = txt_rut_cliente.Text

        If Form_cobranzas.txt_rut_cliente.Text <> "" Then
            Form_cobranzas.cargar_detalle()
            Form_cobranzas.mostrar_datos_clientes()
            Form_cobranzas.combo_tipo.SelectedItem = "-"
            Form_cobranzas.grilla_cobranzas.Columns(0).Width = 300
            Form_cobranzas.grilla_cobranzas.Columns(1).Width = 450
            Form_cobranzas.grilla_cobranzas.Columns(2).Width = 110
            Form_cobranzas.grilla_cobranzas.Columns(3).Width = 108
            Form_cobranzas.grilla_cobranzas.Columns(4).Width = 110
            Form_cobranzas.txt_detalle.Focus()
        End If

        Form_cobranzas.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Check_movimientos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_historico.CheckedChanged
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    Private Sub txt_rut_cliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut_cliente.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            'Form_buscar_clientes_ventas.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub grilla_estado_de_cuenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_estado_de_cuenta.CellContentClick
        Dim tipo_doc As String
        Dim nro_doc As String
        Dim nro_abono As String = ""
        Dim medio_de_pago As String = ""

        tipo_doc = grilla_estado_de_cuenta.CurrentRow.Cells(1).Value
        nro_doc = grilla_estado_de_cuenta.CurrentRow.Cells(0).Value

        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()
        SC2.Connection = conexion
        SC2.CommandText = "select * from detalle_abono where tipo_documento ='" & (tipo_doc) & "' and nro_documento ='" & (nro_doc) & "'"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            nro_abono = DS2.Tables(DT2.TableName).Rows(0).Item("nro_abono")
        End If

        If nro_abono <> "" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from abono where n_abono ='" & (nro_abono) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                medio_de_pago = DS2.Tables(DT2.TableName).Rows(0).Item("condicion_abono")
            End If
        End If
        If medio_de_pago <> "" Then
            MsgBox("LA FORMA DE PAGO DE LA " & tipo_doc & " NUMERO " & nro_doc & " ES " & medio_de_pago & " CON EL ABONO " & nro_abono, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
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

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 55, margen_izquierdo + 810, margen_superior + 45)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 70, margen_izquierdo + 810, margen_superior + 60)

        e.Graphics.DrawString("LISTADO DE ABONOS", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 88, margen_izquierdo + 865, margen_superior + 88)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        If txt_nombre_cliente.Text.Length > 23 Then
            txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 23)
        End If

        e.Graphics.DrawString("DESDE: " & dtp_desde.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 120)
        e.Graphics.DrawString("HASTA: " & dtp_hasta.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 250, margen_superior + 120)
        e.Graphics.DrawString("RUT: " & txt_rut_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 450, margen_superior + 120)
        e.Graphics.DrawString("NOMBRE: " & txt_nombre_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 650, margen_superior + 120)

        e.Graphics.DrawString("FECHA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 150)
        e.Graphics.DrawString("NRO.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 115, margen_superior + 150)
        e.Graphics.DrawString("CONDICION", Font_titulo_columna, Brushes.Black, margen_izquierdo + 155, margen_superior + 150)
        e.Graphics.DrawString("DETALLE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 280, margen_superior + 150)
        e.Graphics.DrawString("ESTADO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 415, margen_superior + 150)
        e.Graphics.DrawString("CLIENTE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 470, margen_superior + 150)
        e.Graphics.DrawString("RUT", Font_titulo_columna, Brushes.Black, margen_izquierdo + 605, margen_superior + 150)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 690, margen_superior + 150)
        e.Graphics.DrawString("USUARIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 745, margen_superior + 150)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 165, margen_izquierdo + 865, margen_superior + 165)

        Dim fecha As String
        Dim nuumero As String
        Dim condicion As String
        Dim estado As String
        Dim detalle As String
        Dim cliente As String
        Dim rut_cliente As String
        Dim total As String
        Dim usuario As String

        If txt_rut_cliente.Text = "" Then
            txt_rut_cliente.Text = "TODOS"
        End If

        If txt_nombre_cliente.Text = "" Then
            txt_nombre_cliente.Text = "TODOS"
        End If

        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10

        For i = numero_lineas_total To grilla_abonos.Rows.Count - 1
            fecha = grilla_abonos.Rows(i).Cells(0).Value.ToString
            nuumero = grilla_abonos.Rows(i).Cells(1).Value.ToString
            condicion = grilla_abonos.Rows(i).Cells(2).Value.ToString
            detalle = grilla_abonos.Rows(i).Cells(3).Value.ToString
            estado = grilla_abonos.Rows(i).Cells(4).Value.ToString
            cliente = grilla_abonos.Rows(i).Cells(5).Value.ToString
            rut_cliente = grilla_abonos.Rows(i).Cells(6).Value.ToString
            total = grilla_abonos.Rows(i).Cells(7).Value.ToString
            usuario = grilla_abonos.Rows(i).Cells(8).Value.ToString

            If total = "" Or total = "0" Then
                total = "0"
            Else
                total = Format(Int(total), "###,###,###")
            End If

            If fecha.Length > 10 Then
                fecha = fecha.Substring(0, 10)
            End If

            If cliente.Length > 20 Then
                cliente = cliente.Substring(0, 20)
            End If

            If usuario.Length > 20 Then
                usuario = usuario.Substring(0, 20)
            End If

            e.Graphics.DrawString(fecha, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(nuumero, Font_texto_impresion, Brushes.Black, margen_izquierdo + 115, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(condicion, Font_texto_impresion, Brushes.Black, margen_izquierdo + 155, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 280, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(estado, Font_texto_impresion, Brushes.Black, margen_izquierdo + 415, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(cliente, Font_texto_impresion, Brushes.Black, margen_izquierdo + 470, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(rut_cliente, Font_texto_impresion, Brushes.Black, margen_izquierdo + 605, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(total, Font_texto_impresion, Brushes.Black, margen_izquierdo + 735, margen_superior + 170 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(usuario, Font_texto_impresion, Brushes.Black, margen_izquierdo + 745, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 85 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 175 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 175 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 175 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 175 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0
    End Sub
End Class