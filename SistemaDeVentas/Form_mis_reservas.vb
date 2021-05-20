Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Form_mis_reservas
    Dim consulta_busqueda As String
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim numero_lineas_total As Integer = 0
    'Dim impreso As Integer = 0

    Private Sub Form_mis_reservas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_mis_reservas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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


    Private Sub Form_mis_reservas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar_combo_vendedor()
        cargar_logo()
        dtp_desde.CustomFormat = "yyy-MM-dd"
        dtp_hasta.CustomFormat = "yyy-MM-dd"
        Combo_vendedor.SelectedItem = "TODOS"
        cargar_reservas()
        grilla_mis_pedidos.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
    End Sub

    Sub llenar_combo_vendedor()
        Combo_vendedor.Items.Clear()
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
            Combo_vendedor.Items.Add("TODOS")
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
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
                txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If

            conexion.Close()
        End If
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        mostrar_datos_vendedor()
        cargar_reservas()
    End Sub


    Sub cargar_reservas()


        dtp_desde.Value = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_desde.Value = dtp_desde.Value.AddDays(Val(-7))

        grilla_mis_pedidos.DataSource = Nothing

        If Combo_vendedor.Text = "TODOS" And txt_codigo.Text = "" Then




            conexion.Close()
            Dim DT4 As New DataTable

            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select cod_producto as 'CODIGO', nombre_producto as 'NOMBRE', numero_tecnico as 'N. TECNICO', cantidad  as 'CANT.', precio as 'PRECIO', total as 'TOTAL', Fecha as 'FECHA', nombre_usuario as 'USUARIO' from reservas, usuarios where fecha >='" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and reservas.usuario_responsable=usuarios.rut_usuario order by nombre_usuario"

            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            grilla_mis_pedidos.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()

















            'conexion.Close()
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'SC.Connection = conexion
            'SC.CommandText = "select cod_producto, nombre_producto, numero_tecnico, cantidad, precio, total, Fecha, nombre_usuario from reservas, usuarios where fecha >='" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and reservas.usuario_responsable=usuarios.rut_usuario"

            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            '' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            'If DS.Tables(DT.TableName).Rows.Count > 0 Then

            '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '        '   grilla_detalle_venta.Rows.Clear()


            '        Dim fecha_reserva As String

            '        fecha_reserva = DS.Tables(DT.TableName).Rows(i).Item("fecha")
            '        If fecha_reserva.Length > 10 Then
            '            fecha_reserva = fecha_reserva.Substring(0, 10)
            '        End If


            '        grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
            '                                       DS.Tables(DT.TableName).Rows(i).Item("nombre_producto"), _
            '                                        DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
            '                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
            '                                          DS.Tables(DT.TableName).Rows(i).Item("precio"), _
            '                                           DS.Tables(DT.TableName).Rows(i).Item("total"), _
            '                                            fecha_reserva, _
            '                                             DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))
            '    Next
            'End If
        End If











        If Combo_vendedor.Text <> "TODOS" And txt_codigo.Text = "" Then


            conexion.Close()
            Dim DT4 As New DataTable

            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = consulta_busqueda
            DA4.SelectCommand = SC4
            SC4.CommandText = "select cod_producto as 'CODIGO', nombre_producto as 'NOMBRE', numero_tecnico as 'N. TECNICO', cantidad  as 'CANT.', precio as 'PRECIO', total as 'TOTAL', Fecha as 'FECHA', nombre_usuario as 'USUARIO' from reservas, usuarios where fecha >='" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and usuario_responsable= '" & (txt_rut.Text) & "' and reservas.usuario_responsable=usuarios.rut_usuario order by nombre_usuario"

            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            grilla_mis_pedidos.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()



            'conexion.Close()
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'SC.Connection = conexion
            'SC.CommandText = "select cod_producto, nombre_producto, numero_tecnico, cantidad, precio, total, Fecha, nombre_usuario from reservas, usuarios where fecha >='" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and usuario_responsable= '" & (txt_rut.Text) & "' and reservas.usuario_responsable=usuarios.rut_usuario"

            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            '' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            'If DS.Tables(DT.TableName).Rows.Count > 0 Then

            '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '        '   grilla_detalle_venta.Rows.Clear()


            '        Dim fecha_reserva As String

            '        fecha_reserva = DS.Tables(DT.TableName).Rows(i).Item("fecha")
            '        If fecha_reserva.Length > 10 Then
            '            fecha_reserva = fecha_reserva.Substring(0, 10)
            '        End If


            '        grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
            '                                       DS.Tables(DT.TableName).Rows(i).Item("nombre_producto"), _
            '                                        DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
            '                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
            '                                          DS.Tables(DT.TableName).Rows(i).Item("precio"), _
            '                                           DS.Tables(DT.TableName).Rows(i).Item("total"), _
            '                                            fecha_reserva, _
            '                                             DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))
            '    Next
            'End If
        End If




        If Combo_vendedor.Text = "TODOS" And txt_codigo.Text <> "" Then






            conexion.Close()
            Dim DT4 As New DataTable

            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select cod_producto as 'CODIGO', nombre_producto as 'NOMBRE', numero_tecnico as 'N. TECNICO', cantidad  as 'CANT.', precio as 'PRECIO', total as 'TOTAL', Fecha as 'FECHA', nombre_usuario as 'USUARIO' from reservas, usuarios where fecha >='" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and cod_producto= '" & (txt_codigo.Text) & "' and reservas.usuario_responsable=usuarios.rut_usuario order by nombre_usuario"

            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            grilla_mis_pedidos.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()











            'conexion.Close()
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'SC.Connection = conexion
            'SC.CommandText = "select * from reservas, usuarios where fecha >='" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "' and cod_producto= '" & (txt_codigo.Text) & "' and reservas.usuario_responsable=usuarios.rut_usuario"

            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            '' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            'If DS.Tables(DT.TableName).Rows.Count > 0 Then

            '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '        '   grilla_detalle_venta.Rows.Clear()


            '        Dim fecha_reserva As String

            '        fecha_reserva = DS.Tables(DT.TableName).Rows(i).Item("fecha")
            '        If fecha_reserva.Length > 10 Then
            '            fecha_reserva = fecha_reserva.Substring(0, 10)
            '        End If


            '        grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
            '                                       DS.Tables(DT.TableName).Rows(i).Item("nombre_producto"), _
            '                                        DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
            '                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
            '                                          DS.Tables(DT.TableName).Rows(i).Item("precio"), _
            '                                           DS.Tables(DT.TableName).Rows(i).Item("total"), _
            '                                            fecha_reserva, _
            '                                             DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))
            '    Next
            'End If
        End If


        If Combo_vendedor.Text <> "TODOS" And txt_codigo.Text <> "" Then

            conexion.Close()
            Dim DT4 As New DataTable

            DS4.Tables.Clear()
            DT4.Rows.Clear()
            DT4.Columns.Clear()
            DS4.Clear()
            conexion.Open()

            SC4.Connection = conexion
            SC4.CommandText = "select cod_producto as 'CODIGO', nombre_producto as 'NOMBRE', numero_tecnico as 'N. TECNICO', cantidad  as 'CANT.', precio as 'PRECIO', total as 'TOTAL', Fecha as 'FECHA', nombre_usuario as 'USUARIO' from reservas, usuarios where fecha >='" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "'  and usuario_responsable= '" & (txt_rut.Text) & "' and cod_producto= '" & (txt_codigo.Text) & "' and reservas.usuario_responsable=usuarios.rut_usuario order by nombre_usuario"

            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
            DS4.Tables.Add(DT4)

            grilla_mis_pedidos.DataSource = DS4.Tables(DT4.TableName)
            conexion.Close()




















            'conexion.Close()
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'SC.Connection = conexion
            'SC.CommandText = "select * from reservas, usuarios where fecha >='" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "'  and usuario_responsable= '" & (txt_rut.Text) & "' and cod_producto= '" & (txt_codigo.Text) & "' and reservas.usuario_responsable=usuarios.rut_usuario"

            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)

            '' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            'If DS.Tables(DT.TableName).Rows.Count > 0 Then

            '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '        '   grilla_detalle_venta.Rows.Clear()


            '        Dim fecha_reserva As String

            '        fecha_reserva = DS.Tables(DT.TableName).Rows(i).Item("fecha")
            '        If fecha_reserva.Length > 10 Then
            '            fecha_reserva = fecha_reserva.Substring(0, 10)
            '        End If


            '        grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
            '                                       DS.Tables(DT.TableName).Rows(i).Item("nombre_producto"), _
            '                                        DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
            '                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
            '                                          DS.Tables(DT.TableName).Rows(i).Item("precio"), _
            '                                           DS.Tables(DT.TableName).Rows(i).Item("total"), _
            '                                            fecha_reserva, _
            '                                             DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))
            '    Next
            'End If
        End If
    End Sub


    Sub busqueda_por_descripcion()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        Combo_vendedor.SelectedItem = "TODOS"
        txt_codigo.Text = ""


        dtp_desde.Value = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_desde.Value = dtp_desde.Value.AddDays(Val(-7))

        grilla_mis_pedidos.DataSource = Nothing


        consulta_busqueda = "select cod_producto as 'CODIGO', nombre_producto as 'NOMBRE', numero_tecnico as 'N. TECNICO', cantidad  as 'CANT.', precio as 'PRECIO', total as 'TOTAL', Fecha as 'FECHA', nombre_usuario as 'USUARIO' from reservas, usuarios where fecha >='" & (dtp_desde.Text) & "' and fecha <= '" & (dtp_hasta.Text) & "'and reservas.usuario_responsable=usuarios.rut_usuario "


        Dim cadena As String
        Dim tabla() As String
        Dim n As Integer

        cadena = txt_buscar.Text
        '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
        tabla = Split(cadena, " ")

        For n = 0 To UBound(tabla, 1)
            consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',cod_producto, nombre_producto, numero_tecnico) LIKE '" & ("%" & tabla(n) & "%") & "' order by nombre_usuario"
        Next




        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'SC.Connection = conexion
        'SC.CommandText = consulta_busqueda
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)






        conexion.Close()
        Dim DT4 As New DataTable

        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        conexion.Open()

        SC4.Connection = conexion
        SC4.CommandText = consulta_busqueda
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)

        grilla_mis_pedidos.DataSource = DS4.Tables(DT4.TableName)
        conexion.Close()



        '' Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then

        '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '        '   grilla_detalle_venta.Rows.Clear()


        '        Dim fecha_reserva As String

        '        fecha_reserva = DS.Tables(DT.TableName).Rows(i).Item("fecha")
        '        If fecha_reserva.Length > 10 Then
        '            fecha_reserva = fecha_reserva.Substring(0, 10)
        '        End If


        '        grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
        '                                       DS.Tables(DT.TableName).Rows(i).Item("nombre_producto"), _
        '                                        DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
        '                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
        '                                          DS.Tables(DT.TableName).Rows(i).Item("precio"), _
        '                                           DS.Tables(DT.TableName).Rows(i).Item("total"), _
        '                                            fecha_reserva, _
        '                                             DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))
        '    Next
        'End If




        lbl_mensaje.Visible = False
        Me.Enabled = True
        Exit Sub


    End Sub

    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
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

        'If e.KeyChar = "*" Then
        '    e.KeyChar = ""
        'End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            cargar_reservas()
        End If
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar.KeyPress
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

        'If e.KeyChar = "*" Then
        '    e.KeyChar = ""
        'End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            busqueda_por_descripcion()
        End If
    End Sub

    Private Sub txt_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar.TextChanged

    End Sub


    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub

    Private Sub txt_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_buscar.GotFocus
        txt_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_buscar.LostFocus
        txt_buscar.BackColor = Color.White
    End Sub

    Private Sub Combo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.GotFocus
        Combo_vendedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.LostFocus
        Combo_vendedor.BackColor = Color.White
    End Sub


    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        busqueda_por_descripcion()
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("dd-MM-yyy")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("dd-MM-yyy")
    End Sub


    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    fecha()
    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("codigo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre", GetType(String)))
    '    dt.Columns.Add(New DataColumn("numero_tecnico", GetType(String)))
    '    dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("precio", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("total", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("vendedor", GetType(String)))
    '    dt.Columns.Add(New DataColumn("filtro_vendedor", GetType(String)))
    '    dt.Columns.Add(New DataColumn("filtro_codigo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("filtro_busqueda", GetType(String)))

    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

    '    dt.Columns.Add(New DataColumn("desde", GetType(String)))
    '    dt.Columns.Add(New DataColumn("hasta", GetType(String)))



    '    Dim codigo_detalle As String
    '    Dim nombre_detalle As String
    '    Dim numero_tecnico_detalle As String
    '    Dim cantidad_detalle As String
    '    Dim precio_detalle As String
    '    Dim total_detalle As String
    '    Dim fecha_detalle As String
    '    Dim vendedor_detalle As String

    '    If txt_codigo.Text = "" Then
    '        txt_codigo.Text = "-"
    '    End If

    '    If txt_buscar.Text = "" Then
    '        txt_buscar.Text = "-"
    '    End If

    '    For i = 0 To grilla_mis_pedidos.Rows.Count - 1
    '        codigo_detalle = grilla_mis_pedidos.Rows(i).Cells(0).Value.ToString
    '        nombre_detalle = grilla_mis_pedidos.Rows(i).Cells(1).Value.ToString
    '        numero_tecnico_detalle = grilla_mis_pedidos.Rows(i).Cells(2).Value.ToString
    '        cantidad_detalle = grilla_mis_pedidos.Rows(i).Cells(3).Value.ToString
    '        precio_detalle = grilla_mis_pedidos.Rows(i).Cells(4).Value.ToString
    '        total_detalle = grilla_mis_pedidos.Rows(i).Cells(5).Value.ToString
    '        fecha_detalle = grilla_mis_pedidos.Rows(i).Cells(6).Value.ToString
    '        vendedor_detalle = grilla_mis_pedidos.Rows(i).Cells(7).Value.ToString



    '        dr = dt.NewRow()

    '        'Try
    '        '    dr("Imagen") = Imagen_reporte
    '        'Catch
    '        'End Try



    '        dr("codigo") = codigo_detalle
    '        dr("nombre") = nombre_detalle
    '        dr("numero_tecnico") = numero_tecnico_detalle
    '        dr("cantidad") = cantidad_detalle
    '        dr("precio") = precio_detalle
    '        dr("total") = total_detalle
    '        dr("fecha") = fecha_detalle
    '        dr("vendedor") = vendedor_detalle
    '        dr("filtro_vendedor") = Combo_vendedor.Text
    '        dr("filtro_codigo") = txt_codigo.Text
    '        dr("filtro_busqueda") = txt_buscar.Text





    '        dr("nombre_empresa") = minombreempresa
    '        dr("giro_empresa") = migiroempresa
    '        dr("direccion_empresa") = midireccionempresa
    '        dr("comuna_empresa") = micomunaempresa
    '        dr("telefono_empresa") = mitelefonoempresa
    '        dr("correo_empresa") = micorreoempresa
    '        dr("rut_empresa") = mirutempresa

    '        dr("desde") = mifecha2
    '        dr("hasta") = mifecha4

    '        dt.Rows.Add(dr)




    '    Next





    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "Reservas"

    '    Dim iDS As New dsReservas
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS


    '    If txt_codigo.Text = "-" Then
    '        txt_codigo.Text = ""
    '    End If

    '    If txt_buscar.Text = "-" Then
    '        txt_buscar.Text = ""
    '    End If

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


    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        If grilla_mis_pedidos.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_vendedor.Focus()
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

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
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

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 55, margen_izquierdo + 780, margen_superior + 45)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 70, margen_izquierdo + 780, margen_superior + 60)

        e.Graphics.DrawString("RESERVAS", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 88, margen_izquierdo + 810, margen_superior + 88)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        'If txt_nombre_cliente.Text.Length > 23 Then
        '    txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 23)
        'End If

        e.Graphics.DrawString("DESDE: " & dtp_desde.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 120)
        e.Graphics.DrawString("HASTA: " & dtp_hasta.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 210, margen_superior + 120)
        e.Graphics.DrawString("CODIGO: " & txt_codigo.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 410, margen_superior + 120)
        e.Graphics.DrawString("USUARIO: " & Combo_vendedor.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 610, margen_superior + 120)

        e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 10, margen_superior + 150)
        e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 60, margen_superior + 150)
        e.Graphics.DrawString("NRO. TECNICO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 230, margen_superior + 150)
        e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 460, margen_superior + 150, format1)
        e.Graphics.DrawString("PRECIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 530, margen_superior + 150, format1)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 600, margen_superior + 150, format1)
        e.Graphics.DrawString("FECHA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 620, margen_superior + 150)
        e.Graphics.DrawString("VENDEDOR", Font_titulo_columna, Brushes.Black, margen_izquierdo + 690, margen_superior + 150)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 810, margen_superior + 165)

        Dim codigo_detalle As String
        Dim nombre_detalle As String
        Dim numero_tecnico_detalle As String
        Dim cantidad_detalle As String
        Dim precio_detalle As String
        Dim total_detalle As String
        Dim fecha_detalle As String
        Dim vendedor_detalle As String
        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10

        For i = numero_lineas_total To grilla_mis_pedidos.Rows.Count - 1
            codigo_detalle = grilla_mis_pedidos.Rows(i).Cells(0).Value.ToString
            nombre_detalle = grilla_mis_pedidos.Rows(i).Cells(1).Value.ToString
            numero_tecnico_detalle = grilla_mis_pedidos.Rows(i).Cells(2).Value.ToString
            cantidad_detalle = grilla_mis_pedidos.Rows(i).Cells(3).Value.ToString
            precio_detalle = grilla_mis_pedidos.Rows(i).Cells(4).Value.ToString
            total_detalle = grilla_mis_pedidos.Rows(i).Cells(5).Value.ToString
            fecha_detalle = grilla_mis_pedidos.Rows(i).Cells(6).Value.ToString
            vendedor_detalle = grilla_mis_pedidos.Rows(i).Cells(7).Value.ToString

            If precio_detalle = "" Or precio_detalle = "0" Then
                precio_detalle = "0"
            Else
                precio_detalle = Format(Int(precio_detalle), "###,###,###")
            End If

            If total_detalle = "" Or total_detalle = "0" Then
                total_detalle = "0"
            Else
                total_detalle = Format(Int(total_detalle), "###,###,###")
            End If

            If fecha_detalle.Length > 10 Then
                fecha_detalle = fecha_detalle.Substring(0, 10)
            End If

            If nombre_detalle.Length > 20 Then
                nombre_detalle = nombre_detalle.Substring(0, 20)
            End If

            If numero_tecnico_detalle.Length > 20 Then
                numero_tecnico_detalle = numero_tecnico_detalle.Substring(0, 20)
            End If

            If vendedor_detalle.Length > 20 Then
                vendedor_detalle = vendedor_detalle.Substring(0, 20)
            End If

            e.Graphics.DrawString(codigo_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 10, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(nombre_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 60, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(numero_tecnico_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 230, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(cantidad_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 460, margen_superior + 170 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(precio_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 530, margen_superior + 170 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(total_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 600, margen_superior + 170 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(fecha_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 620, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(vendedor_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 690, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************


            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 85 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 175 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 175 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 175 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 175 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0
    End Sub
End Class