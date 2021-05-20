Imports System.IO
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class Form_abonos_listado
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim alto_cotizacion As String
    Private WithEvents Pd As New PrintDocument
    Dim numero_lineas_total As Integer = 0
    Dim tipo_impresion As Integer = 0
    Dim impresora_abonos As String
    'Dim impreso As Integer = 0

    Private Sub Form_abonos_listado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_abonos_listado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    Private Sub Form_abonos_listado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        fecha()
        mostrar_malla()
        mostrar_impresora()

        Me.Width = 1024
        Me.Height = 728
        Centrar()
    End Sub

    Public Sub Centrar()
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (tamaño.Width - Me.Width) \ 2
        Dim posicionY As Integer = (tamaño.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_impresora()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from impresoras"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            impresora_abonos = DS.Tables(DT.TableName).Rows(0).Item("ticket_abonos")
        End If
        conexion.Close()
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub limpiar()
        txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        grilla_documento.DataSource = Nothing
        dtp_desde.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_hasta.Text = FormatDateTime(Now, DateFormat.ShortDate)
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
    Sub mostrar_malla()

        lbl_mensaje.Visible = True
        Me.Enabled = False



        fecha()



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
            SC3.CommandText = "select fecha as 'FECHA', n_abono as 'NRO.', condicion_abono as 'CONDIC.', detalle_abono as 'DETALLE',  estado as 'ESTADO', nombre as 'CLIENTE', abono.rut_cliente as 'RUT', monto_abono as 'TOTAL', nombre_usuario as 'USUARIO' from abono, usuarios  where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and abono.usuario_responsable=usuarios.rut_usuario group by n_abono order by n_abono asc"

            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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

            grilla_documento.DataSource = DS3.Tables(DT3.TableName)
            conexion.Close()

            grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
        grilla_documento.DataSource = Nothing
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            guion_rut_cliente()
            mostrar_datos_clientes()
            'mostrar_malla()


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
    '    dt.Columns.Add(New DataColumn("numero", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("condicion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("cliente_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("total", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("usuario", GetType(String)))
    '    dt.Columns.Add(New DataColumn("estado", GetType(String)))
    '    dt.Columns.Add(New DataColumn("final", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("ciudad_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("titulo", GetType(String)))


    '    Dim fecha As String
    '    Dim nuumero As String
    '    Dim condicion As String
    '    Dim estado As String
    '    Dim detalle As String
    '    Dim cliente As String
    '    Dim rut_cliente As String
    '    Dim total As String
    '    Dim usuario As String




    '    If txt_rut_cliente.Text = "" Then
    '        txt_rut_cliente.Text = "TODOS"
    '    End If

    '    If txt_nombre_cliente.Text = "" Then
    '        txt_nombre_cliente.Text = "TODOS"
    '    End If



    '    For i = 0 To grilla_documento.Rows.Count - 1


    '        fecha = grilla_documento.Rows(i).Cells(0).Value.ToString
    '        nuumero = grilla_documento.Rows(i).Cells(1).Value.ToString
    '        condicion = grilla_documento.Rows(i).Cells(2).Value.ToString
    '        detalle = grilla_documento.Rows(i).Cells(3).Value.ToString
    '        estado = grilla_documento.Rows(i).Cells(4).Value.ToString

    '        cliente = grilla_documento.Rows(i).Cells(5).Value.ToString
    '        rut_cliente = grilla_documento.Rows(i).Cells(6).Value.ToString
    '        total = grilla_documento.Rows(i).Cells(7).Value.ToString
    '        usuario = grilla_documento.Rows(i).Cells(8).Value.ToString



    '        dr = dt.NewRow()

    '        Try
    '            dr("Imagen") = Imagen_ticket
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
    '        dr("estado") = estado
    '        dr("cliente_detalle") = cliente
    '        dr("rut_detalle") = rut_cliente
    '        dr("total") = total
    '        dr("usuario") = usuario
    '        dr("final") = txt_total.Text
    '        dr("nombre_empresa") = minombreempresa
    '        dr("giro_empresa") = migiroempresa
    '        dr("direccion_empresa") = midireccionempresa
    '        dr("ciudad_empresa") = micomunaempresa
    '        dr("telefono_empresa") = mitelefonoempresa
    '        dr("correo_empresa") = micorreoempresa
    '        dr("rut_empresa") = mirutempresa


    '        If mirutempresa <> "87686300-6" Then
    '            dr("titulo") = "COMPROBANTE DE PAGO"
    '        Else
    '            dr("titulo") = "COMPROBANTE DE INGRESO"
    '        End If

    '        dt.Rows.Add(dr)




    '    Next





    '    ds.Tables.Add(dt)
    '    '  ds.Tables(0).TableName = "Pedidos"
    '    ds.Tables(0).TableName = "ListadoAbonos"

    '    Dim iDS As New dsListadoAbonos
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS


    '    If txt_rut_cliente.Text = "TODOS" Then
    '        txt_rut_cliente.Text = ""
    '    End If

    '    If txt_nombre_cliente.Text = "TODOS" Then
    '        txt_nombre_cliente.Text = ""
    '    End If



    'End Function




    'Private Function ReturnDataSetAbonoTicket() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet




    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("ciudad_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

    '    dt.Columns.Add(New DataColumn("nro_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))

    '    dt.Columns.Add(New DataColumn("detalle_referencia", GetType(String)))
    '    dt.Columns.Add(New DataColumn("abono", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("total_abono", GetType(Integer)))

    '    dt.Columns.Add(New DataColumn("condicion_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("detalle_condicion_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("cajero_abono", GetType(String)))
    '    dt.Columns.Add(New DataColumn("titulo", GetType(String)))





    '    Dim detalle_referencia As String
    '    Dim detalle_abono As String
    '    Dim detalle_saldo As String


    '    If grilla_documento.Rows.Count <> 0 Then

    '        Dim nro_abono As String
    '        Dim fecha_abono As String
    '        Dim rut_abono As String
    '        Dim nombre_abono As String
    '        Dim total_abono As String
    '        Dim condicion_abono As String
    '        Dim detalle_condicion_abono As String
    '        Dim cajero_abono As String

    '        nro_abono = grilla_documento.CurrentRow.Cells(1).Value
    '        fecha_abono = grilla_documento.CurrentRow.Cells(0).Value
    '        rut_abono = grilla_documento.CurrentRow.Cells(6).Value
    '        nombre_abono = grilla_documento.CurrentRow.Cells(5).Value
    '        total_abono = grilla_documento.CurrentRow.Cells(7).Value
    '        condicion_abono = grilla_documento.CurrentRow.Cells(2).Value
    '        detalle_condicion_abono = grilla_documento.CurrentRow.Cells(3).Value
    '        cajero_abono = grilla_documento.CurrentRow.Cells(8).Value


    '        If grilla_abono.Rows.Count = 0 Then
    '            dr = dt.NewRow()

    '            Try
    '                dr("Imagen") = Imagen_ticket
    '            Catch
    '            End Try

    '            dr("nombre_empresa") = minombreempresa
    '            dr("giro_empresa") = migiroempresa
    '            dr("direccion_empresa") = midireccionempresa
    '            dr("ciudad_empresa") = micomunaempresa
    '            dr("telefono_empresa") = mitelefonoempresa
    '            dr("correo_empresa") = micorreoempresa
    '            dr("rut_empresa") = mirutempresa

    '            dr("nro_abono") = nro_abono
    '            dr("fecha_abono") = fecha_abono
    '            dr("nombre_cliente") = nombre_abono
    '            dr("rut_cliente") = rut_abono

    '            dr("detalle_referencia") = "-"
    '            dr("abono") = "0"
    '            dr("saldo") = "0"
    '            dr("total_abono") = total_abono


    '            dr("condicion_abono") = condicion_abono
    '            dr("detalle_condicion_abono") = detalle_condicion_abono
    '            dr("cajero_abono") = cajero_abono

    '            If mirutempresa = "87686300-6" Then
    '                dr("titulo") = "COMPROBANTE DE INGRESO"
    '            Else
    '                dr("titulo") = "COMPROBANTE DE PAGO"
    '            End If

    '            dt.Rows.Add(dr)



    '        Else




    '            For i = 0 To grilla_abono.Rows.Count - 1

    '                detalle_referencia = grilla_abono.Rows(i).Cells(0).Value.ToString & " NRO. " & grilla_abono.Rows(i).Cells(1).Value.ToString
    '                detalle_abono = grilla_abono.Rows(i).Cells(2).Value.ToString
    '                detalle_saldo = grilla_abono.Rows(i).Cells(3).Value.ToString

    '                dr = dt.NewRow()

    '                'Try
    '                '    dr("Imagen") = Imagen_reporte

    '                'Catch
    '                'End Try

    '                If mirutempresa = "87686300-6" Then
    '                    dr("titulo") = "COPIA DE COMPROBANTE DE INGRESO"
    '                Else
    '                    dr("titulo") = "COPIA DE COMPROBANTE DE PAGO"
    '                End If

    '                dr("nombre_empresa") = minombreempresa
    '                dr("giro_empresa") = migiroempresa
    '                dr("direccion_empresa") = midireccionempresa
    '                dr("ciudad_empresa") = micomunaempresa
    '                dr("telefono_empresa") = mitelefonoempresa
    '                dr("correo_empresa") = micorreoempresa
    '                dr("rut_empresa") = mirutempresa
    '                dr("nro_abono") = nro_abono
    '                dr("fecha_abono") = fecha_abono
    '                dr("nombre_cliente") = nombre_abono
    '                dr("rut_cliente") = rut_abono
    '                dr("detalle_referencia") = detalle_referencia
    '                dr("abono") = detalle_abono
    '                dr("saldo") = detalle_saldo
    '                dr("total_abono") = total_abono
    '                dr("condicion_abono") = condicion_abono
    '                dr("detalle_condicion_abono") = detalle_condicion_abono
    '                dr("cajero_abono") = cajero_abono
    '                dt.Rows.Add(dr)
    '            Next
    '        End If

    '    End If

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "Abono"

    '    Dim iDS As New dsAbono
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function


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

    'Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    '    If grilla_documento.Rows.Count = 0 Then
    '        MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
    '        txt_rut_cliente.Focus()
    '        Exit Sub
    '    End If

    '    lbl_mensaje.Visible = True
    '    Me.Enabled = False

    '    Try
    '        Dim iReporte As New VisorReporte

    '        Dim rpt As New Crystal_listado_abono

    '        rpt.Load()
    '        rpt.SetDataSource(ReturnDataSet)
    '        rpt.Refresh()

    '        iReporte.Reporte = rpt
    '        iReporte.ShowDialog()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    Me.Enabled = True
    '    lbl_mensaje.Visible = False
    'End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub



    Private Sub txt_rut_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
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

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        'mostrar_malla()
        'calcular_totales()

        grilla_documento.DataSource = Nothing
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        'mostrar_malla()
        'calcular_totales()


        grilla_documento.DataSource = Nothing
    End Sub

    Sub cargar_abono()
        Dim nro_abono As String
        nro_abono = grilla_documento.CurrentRow.Cells(1).Value

        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        SC2.Connection = conexion
        SC2.CommandText = "select tipo_documento, nro_documento, monto_abono, saldo_documento from detalle_abono where nro_abono='" & (nro_abono) & "' "
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        grilla_abono.Rows.Clear()

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then

            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                grilla_abono.Rows.Add(DS2.Tables(DT2.TableName).Rows(i).Item("tipo_documento"), _
                                                 DS2.Tables(DT2.TableName).Rows(i).Item("nro_documento"), _
                                                  DS2.Tables(DT2.TableName).Rows(i).Item("monto_abono"), _
                                                   DS2.Tables(DT2.TableName).Rows(i).Item("saldo_documento"), _
                                                    "INGRESADO")
            Next

        End If
    End Sub

    Sub calcular_totales()


        Dim totalgrilla As Long



        '//Calcular el total general
        txt_total.Text = 0
        For i = 0 To grilla_documento.Rows.Count - 1
            totalgrilla = Val(grilla_documento.Rows(i).Cells(7).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next






    End Sub

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick
        'Abrir()
    End Sub

    Private Sub grilla_documento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.Click
        ' Abrir()
    End Sub

    Private Sub grilla_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.DoubleClick
        If grilla_documento.Rows.Count = 0 Then
            Exit Sub
        End If

        tipo_impresion = 2

        cargar_abono()
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "IMPRIMIR")
        If valormensaje = vbYes Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            With PrintDocument_ticket.PrinterSettings
                lbl_mensaje.Visible = True
                Me.Enabled = False
                .PrinterName = impresora_abonos
                .Copies = 2
                .PrintRange = PrintRange.AllPages
                If .IsValid Then
                    Me.PrintDocument_ticket.PrintController = New StandardPrintController
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                    Me.PrintDocument_ticket.DefaultPageSettings.PaperSize = pkCustomSize1
                    PrintDocument_ticket.PrintController = New System.Drawing.Printing.StandardPrintController()
                    PrintDocument_ticket.Print()
                Else
                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
                lbl_mensaje.Visible = False
                Me.Enabled = True
            End With
            lbl_mensaje.Visible = False
            Me.Enabled = True
            MsgBox("SE HA IMPRESO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        End If
    End Sub



    'Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage

    '    Dim nro_abono As String
    '    Dim fecha_abono As String
    '    Dim rut_abono As String
    '    Dim nombre_abono As String
    '    Dim total_abono As String
    '    Dim condicion_abono As String
    '    Dim detalle_condicion_abono As String

    '    nro_abono = grilla_documento.CurrentRow.Cells(1).Value
    '    fecha_abono = grilla_documento.CurrentRow.Cells(0).Value
    '    rut_abono = grilla_documento.CurrentRow.Cells(6).Value
    '    nombre_abono = grilla_documento.CurrentRow.Cells(5).Value
    '    total_abono = grilla_documento.CurrentRow.Cells(7).Value
    '    condicion_abono = grilla_documento.CurrentRow.Cells(2).Value
    '    detalle_condicion_abono = grilla_documento.CurrentRow.Cells(3).Value

    '    Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
    '    Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
    '    Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
    '    Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
    '    Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
    '    Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

    '    Dim format1 As New StringFormat(StringFormatFlags.NoClip)
    '    format1.Alignment = StringAlignment.Far

    '    Dim margen_izquierdo As Integer
    '    Dim margen_superior As Integer

    '    margen_izquierdo = 5
    '    margen_superior = 0

    '    Dim Image As Bitmap = Form_menu_principal.PictureBox_ticket.Image
    '    e.Graphics.DrawImage(Image, New Rectangle(margen_izquierdo + 0, 0, Image.Width, Image.Height))

    '    Dim stringFormat As New StringFormat()
    '    stringFormat.Alignment = StringAlignment.Center
    '    stringFormat.LineAlignment = StringAlignment.Center

    '    Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 250, margen_superior + 15)
    '    Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 250, margen_superior + 15)
    '    Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 250, margen_superior + 15)
    '    Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 250, margen_superior + 15)
    '    Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 250, margen_superior + 15)
    '    Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 250, margen_superior + 15)
    '    Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 250, margen_superior + 15)
    '    Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 250, margen_superior + 15)

    '    e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
    '    e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
    '    e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
    '    e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
    '    e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
    '    e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
    '    e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

    '    e.Graphics.DrawString("COMPROBANTE DE INGRESO", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

    '    e.Graphics.DrawString("NRO. ABONO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
    '    e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 245)
    '    e.Graphics.DrawString(nro_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 245)

    '    e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
    '    e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 260)
    '    e.Graphics.DrawString(fecha_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 260)

    '    e.Graphics.DrawString("NOMBRE CLIENTE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
    '    e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 275)
    '    e.Graphics.DrawString(nombre_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 275)

    '    e.Graphics.DrawString("FORMA DE PAGO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
    '    e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 290)
    '    e.Graphics.DrawString(condicion_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 290)

    '    e.Graphics.DrawString("DETALLE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
    '    e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 305)
    '    e.Graphics.DrawString(detalle_condicion_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 305)

    '    e.Graphics.DrawString("USUARIO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 320)
    '    e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 320)
    '    e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 320)

    '    e.Graphics.DrawString("DIRECCION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
    '    e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 335)
    '    e.Graphics.DrawString("-", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 335)

    '    e.Graphics.DrawString("DETALLE REFERENCIA", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 370)
    '    e.Graphics.DrawString("ABONO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 170, margen_superior + 370)
    '    e.Graphics.DrawString("SALDO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 370, format1)

    '    e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 385, margen_izquierdo + 270, margen_superior + 385)

    '    Dim detalle_referencia As String
    '    Dim detalle_abono As String
    '    Dim detalle_saldo As String
    '    Dim multiplicador_lineas As Integer = 15
    '    Dim numero_lineas As Integer = 0

    '    If grilla_abono.Rows.Count <> 0 Then

    '        For i = 0 To grilla_abono.Rows.Count - 1
    '            detalle_referencia = grilla_abono.Rows(i).Cells(0).Value.ToString & " NRO. " & grilla_abono.Rows(i).Cells(1).Value.ToString
    '            detalle_abono = grilla_abono.Rows(i).Cells(2).Value.ToString
    '            detalle_saldo = grilla_abono.Rows(i).Cells(3).Value.ToString

    '            If detalle_abono = "" Or detalle_abono = "0" Then
    '                detalle_abono = "0"
    '            Else
    '                detalle_abono = Format(Int(detalle_abono), "###,###,###")
    '            End If

    '            If detalle_saldo = "" Or detalle_saldo = "0" Then
    '                detalle_saldo = "0"
    '            Else
    '                detalle_saldo = Format(Int(detalle_saldo), "###,###,###")
    '            End If

    '            If detalle_referencia.Length > 23 Then
    '                detalle_referencia = detalle_referencia.Substring(0, 23)
    '            End If

    '            e.Graphics.DrawString(detalle_referencia, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 390 + (i * multiplicador_lineas))
    '            e.Graphics.DrawString(detalle_abono, Font_texto_detalle, Brushes.Black, margen_izquierdo + 210, margen_superior + 390 + (i * multiplicador_lineas), format1)
    '            e.Graphics.DrawString(detalle_saldo, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 390 + (i * multiplicador_lineas), format1)
    '        Next

    '        numero_lineas = ((grilla_abono.Rows.Count - 1) * multiplicador_lineas)

    '        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + numero_lineas + 405, margen_izquierdo + 270, margen_superior + numero_lineas + 405)

    '        'e.Graphics.DrawString("TOTAL INGRESO", Font_texto_totales, Brushes.Black, margen_izquierdo + 100, margen_superior + numero_lineas + 320)
    '        'e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 200, margen_superior + numero_lineas + 320)
    '        e.Graphics.DrawString("TOTAL INGRESO: " & total_abono, Font_texto_totales, Brushes.Black, margen_izquierdo + 295, margen_superior + numero_lineas + 425, format1)

    '        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 350, margen_izquierdo + 250, margen_superior + numero_lineas + 15)
    '        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)

    '    Else
    '        e.Graphics.DrawString("SIN DOCUMENTOS IMPUTADOS", Font_texto_totales, Brushes.Black, margen_izquierdo + 50, margen_superior + 390)
    '        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 410, margen_izquierdo + 295, margen_superior + 410)

    '        If total_abono = "" Or total_abono = "0" Then
    '            total_abono = "0"
    '        Else
    '            total_abono = Format(Int(total_abono), "###,###,###")
    '        End If
    '        e.Graphics.DrawString("TOTAL INGRESO: " & total_abono, Font_texto_totales, Brushes.Black, margen_izquierdo + 295, margen_superior + 430, format1)


    '        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + 490, margen_izquierdo + 250, margen_superior + 15)
    '        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    '    End If

    'End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_documento.DataSource = Nothing
        fecha()
        mostrar_malla()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If grilla_documento.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        tipo_impresion = 1
        PrintDialog1.Document = PrintDocument_carta

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument_carta.DefaultPageSettings.Landscape = False
            PrintDocument_carta.Print()

            Try
                PrintDocument_carta.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PrintDocument_ticket_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument_ticket.PrintPage
        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        'Try
        '    e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), -74, 0, 440, 70)
        'Catch
        'End Try

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Try
            Dim imagen_reporte As Image
            imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
            Dim posicion_imagen As New PointF(margen_izquierdo + 0, margen_superior + 0)
            e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        Catch
        End Try

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 250, margen_superior + 15)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 250, margen_superior + 15)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 250, margen_superior + 15)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 250, margen_superior + 15)
        Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 250, margen_superior + 15)
        Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 250, margen_superior + 15)
        Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 250, margen_superior + 15)
        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 250, margen_superior + 15)

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        Dim nro_abono As String
        Dim fecha_abono As String
        Dim rut_abono As String
        Dim nombre_abono As String
        Dim total_abono As String
        Dim condicion_abono As String
        Dim detalle_condicion_abono As String
        Dim usuario_abono As String
        Dim folio_cliente_abono As String = ""

        nro_abono = grilla_documento.CurrentRow.Cells(1).Value
        fecha_abono = grilla_documento.CurrentRow.Cells(0).Value
        rut_abono = grilla_documento.CurrentRow.Cells(6).Value
        nombre_abono = grilla_documento.CurrentRow.Cells(5).Value
        total_abono = grilla_documento.CurrentRow.Cells(7).Value
        condicion_abono = grilla_documento.CurrentRow.Cells(2).Value
        detalle_condicion_abono = grilla_documento.CurrentRow.Cells(3).Value
        usuario_abono = grilla_documento.CurrentRow.Cells(8).Value

        If mirutempresa = "87686300-6" Then
            If rut_abono <> "-" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select folio_cliente from clientes where rut_cliente ='" & (rut_abono) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    folio_cliente_abono = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                End If

                conexion.Close()
            End If
        End If

        e.Graphics.DrawString("COMPROBANTE DE INGRESO", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NRO. ABONO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 245)
        e.Graphics.DrawString(nro_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 260)
        e.Graphics.DrawString(fecha_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 260)

        If mirutempresa = "87686300-6" Then
            e.Graphics.DrawString("RUT CLIENTE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 275)
            e.Graphics.DrawString(rut_abono + " (FOLIO " + folio_cliente_abono + ")", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 275)
        Else
            e.Graphics.DrawString("RUT CLIENTE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
            e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 275)
            e.Graphics.DrawString(rut_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 275)
        End If

        e.Graphics.DrawString("NOMBRE CLIENTE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 290)
        e.Graphics.DrawString(nombre_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 290)

        e.Graphics.DrawString("FORMA DE PAGO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 305)
        e.Graphics.DrawString(condicion_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 305)

        e.Graphics.DrawString("DETALLE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 320)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 320)
        e.Graphics.DrawString(detalle_condicion_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 320)

        e.Graphics.DrawString("USUARIO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 335)
        e.Graphics.DrawString(usuario_abono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 335)

        e.Graphics.DrawString("DIRECCION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 350)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 350)
        e.Graphics.DrawString("-", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 350)

        e.Graphics.DrawString("DETALLE REFERENCIA", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 385)
        e.Graphics.DrawString("ABONO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 170, margen_superior + 385)
        e.Graphics.DrawString("SALDO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 385, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 400, margen_izquierdo + 270, margen_superior + 400)

        Dim detalle_referencia As String
        Dim detalle_abono As String
        Dim detalle_saldo As String
        Dim multiplicador_lineas As Integer = 15
        Dim numero_lineas As Integer = 0

        If grilla_abono.Rows.Count <> 0 Then
            For i = 0 To grilla_abono.Rows.Count - 1
                detalle_referencia = grilla_abono.Rows(i).Cells(0).Value.ToString & " NRO. " & grilla_abono.Rows(i).Cells(1).Value.ToString
                detalle_abono = grilla_abono.Rows(i).Cells(2).Value.ToString
                detalle_saldo = grilla_abono.Rows(i).Cells(3).Value.ToString

                If detalle_abono = "" Or detalle_abono = "0" Then
                    detalle_abono = "0"
                Else
                    detalle_abono = Format(Int(detalle_abono), "###,###,###")
                End If

                If detalle_saldo = "" Or detalle_saldo = "0" Then
                    detalle_saldo = "0"
                Else
                    detalle_saldo = Format(Int(detalle_saldo), "###,###,###")
                End If

                If detalle_referencia.Length > 23 Then
                    detalle_referencia = detalle_referencia.Substring(0, 23)
                End If

                e.Graphics.DrawString(detalle_referencia, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 405 + (i * multiplicador_lineas))
                e.Graphics.DrawString(detalle_abono, Font_texto_detalle, Brushes.Black, margen_izquierdo + 210, margen_superior + 405 + (i * multiplicador_lineas), format1)
                e.Graphics.DrawString(detalle_saldo, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 405 + (i * multiplicador_lineas), format1)
            Next

            numero_lineas = ((grilla_abono.Rows.Count - 1) * multiplicador_lineas)

            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + numero_lineas + 420, margen_izquierdo + 270, margen_superior + numero_lineas + 420)

            'e.Graphics.DrawString("TOTAL INGRESO", Font_texto_totales, Brushes.Black, margen_izquierdo + 100, margen_superior + numero_lineas + 320)
            'e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 200, margen_superior + numero_lineas + 320)

            If total_abono = "" Or total_abono = "0" Then
                total_abono = "0"
            Else
                total_abono = Format(Int(total_abono), "###,###,###")
            End If

            e.Graphics.DrawString("TOTAL INGRESO: " & total_abono, Font_texto_totales, Brushes.Black, margen_izquierdo + 270, margen_superior + numero_lineas + 435, format1)

            Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 480, margen_izquierdo + 250, margen_superior + numero_lineas + 15)
            e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)




        Else


            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 400, margen_izquierdo + 270, margen_superior + 400)
            e.Graphics.DrawString("SIN DOCUMENTOS IMPUTADOS", Font_texto_totales, Brushes.Black, margen_izquierdo + 30, margen_superior + 405)
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 420, margen_izquierdo + 270, margen_superior + 420)

            If total_abono = "" Or total_abono = "0" Then
                total_abono = "0"
            Else
                total_abono = Format(Int(total_abono), "###,###,###")
            End If

            e.Graphics.DrawString("TOTAL INGRESO: " & total_abono, Font_texto_totales, Brushes.Black, margen_izquierdo + 270, margen_superior + numero_lineas + 435, format1)

            Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 480, margen_izquierdo + 250, margen_superior + numero_lineas + 15)
            e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
        End If
    End Sub

    Private Sub PrintDocument_carta_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument_carta.PrintPage
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

        margen_izquierdo = 0
        margen_superior = 0

        Try
            Dim imagen_reporte As Image
            imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
            Dim posicion_imagen As New PointF(margen_izquierdo + 530, margen_superior + 10)
            e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 10, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 75, margen_izquierdo + 780, margen_superior + 45)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 780, margen_superior + 60)

        e.Graphics.DrawString("LISTADO DE ABONOS", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 108, margen_izquierdo + 810, margen_superior + 108)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        If txt_nombre_cliente.Text.Length > 23 Then
            txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 23)
        End If

        e.Graphics.DrawString("DESDE: " & dtp_desde.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 140)
        e.Graphics.DrawString("HASTA: " & dtp_hasta.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 210, margen_superior + 140)
        e.Graphics.DrawString("RUT: " & txt_rut_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 410, margen_superior + 140)
        e.Graphics.DrawString("NOMBRE: " & txt_nombre_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 140)

        e.Graphics.DrawString("FECHA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 10, margen_superior + 170)
        e.Graphics.DrawString("NRO.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 75, margen_superior + 170)
        e.Graphics.DrawString("CONDICION", Font_titulo_columna, Brushes.Black, margen_izquierdo + 115, margen_superior + 170)
        e.Graphics.DrawString("DETALLE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 240, margen_superior + 170)
        e.Graphics.DrawString("ESTADO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 375, margen_superior + 170)
        e.Graphics.DrawString("CLIENTE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 430, margen_superior + 170)
        e.Graphics.DrawString("RUT", Font_titulo_columna, Brushes.Black, margen_izquierdo + 555, margen_superior + 170)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 680, margen_superior + 170, format1)
        e.Graphics.DrawString("USUARIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 695, margen_superior + 170)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 185, margen_izquierdo + 820, margen_superior + 185)

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

        For i = numero_lineas_total To grilla_documento.Rows.Count - 1

            fecha = grilla_documento.Rows(i).Cells(0).Value.ToString
            nuumero = grilla_documento.Rows(i).Cells(1).Value.ToString
            condicion = grilla_documento.Rows(i).Cells(2).Value.ToString
            detalle = grilla_documento.Rows(i).Cells(3).Value.ToString
            estado = grilla_documento.Rows(i).Cells(4).Value.ToString
            cliente = grilla_documento.Rows(i).Cells(5).Value.ToString
            rut_cliente = grilla_documento.Rows(i).Cells(6).Value.ToString
            total = grilla_documento.Rows(i).Cells(7).Value.ToString
            usuario = grilla_documento.Rows(i).Cells(8).Value.ToString

            If total = "" Or total = "0" Then
                total = "0"
            Else
                total = Format(Int(total), "###,###,###")
            End If

            If fecha.Length > 10 Then
                fecha = fecha.Substring(0, 10)
            End If

            If detalle.Length > 16 Then
                detalle = detalle.Substring(0, 16)
            End If

            If cliente.Length > 16 Then
                cliente = cliente.Substring(0, 16)
            End If

            If usuario.Length > 16 Then
                usuario = usuario.Substring(0, 16)
            End If

            e.Graphics.DrawString(fecha, Font_texto_impresion, Brushes.Black, margen_izquierdo + 10, margen_superior + 190 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(nuumero, Font_texto_impresion, Brushes.Black, margen_izquierdo + 75, margen_superior + 190 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(condicion, Font_texto_impresion, Brushes.Black, margen_izquierdo + 115, margen_superior + 190 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 240, margen_superior + 190 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(estado, Font_texto_impresion, Brushes.Black, margen_izquierdo + 375, margen_superior + 190 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(cliente, Font_texto_impresion, Brushes.Black, margen_izquierdo + 430, margen_superior + 190 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(rut_cliente, Font_texto_impresion, Brushes.Black, margen_izquierdo + 555, margen_superior + 190 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(total, Font_texto_impresion, Brushes.Black, margen_izquierdo + 680, margen_superior + 190 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(usuario, Font_texto_impresion, Brushes.Black, margen_izquierdo + 695, margen_superior + 190 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 85 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 195 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 195 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 195 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 195 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0
    End Sub
End Class