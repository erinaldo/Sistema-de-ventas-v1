Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Form_revision_cotizaciones
    Dim mitexto As String
    Dim micampo As String
    Dim consulta_busqueda As String
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim numero_lineas_total As Integer = 0
    'Dim impreso As Integer = 0

    Private Sub Form_revision_cotizaciones_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
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

    Private Sub Form_revision_cotizaciones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_revision_cotizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dtp1.CustomFormat = "yyy-MM-dd"
        'dtp2.CustomFormat = "yyy-MM-dd"
        dtp3.CustomFormat = "yyy-MM-dd"

        dtp_desde.Value = dtp_desde.Value.AddDays(Val(-7))

        busqueda()
        'mostrar_pedidos()
        ' llenar_combo_proveedor()
        llenar_combo_vendedor()
        llenar_combo_marca()

        cargar_logo()
        txt_codigo_pedido.Focus()
        'Me.BackColor = Color.FromArgb(color_fondo)
        'Me.ForeColor = Color.FromArgb(color_texto)
        llenar_combo_proveedores_mas_pedidos()

        grilla_revision_pedidos.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
        grilla_ofertas.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
        'grilla_detalle_cotizacion.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)


        If miarea = "ADQUISICIONES" Then
            btn_aceptar_oferta.Enabled = False
            btn_editar_oferta.Enabled = True
            btn_encargar_pedido.Enabled = True
        End If

        If miarea = "VENTAS" Then
            btn_aceptar_oferta.Enabled = True
            btn_editar_oferta.Enabled = False
            btn_encargar_pedido.Enabled = False
        End If

        If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
            btn_aceptar_oferta.Enabled = True
            btn_editar_oferta.Enabled = True
            btn_encargar_pedido.Enabled = True
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

    Sub llenar_combo_marca()
        Combo_marca.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select marca_vehiculo from solicitar_cotizacion where fecha_pedido >='" & (mifecha2) & "' and fecha_pedido <= '" & (mifecha4) & "' order by marca_vehiculo"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_marca.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("marca_vehiculo"))
            Next
            Combo_marca.Items.Add("OTROS")
        End If
        conexion.Close()
    End Sub

    Sub llenar_combo_proveedores_mas_pedidos()
        Combo_proveedor.Items.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        'SC.CommandText = "select * from proveedores order by nombre_proveedor"

        SC.CommandText = "select detalle_pedido.proveedor as 'proveedor' from  solicitar_cotizacion, pedido, detalle_pedido where solicitar_cotizacion.codigo_pedido=pedido.codigo_pedido and pedido.fecha_pedido >='" & (mifecha2) & "' and pedido.fecha_pedido <= '" & (mifecha4) & "' and pedido.codigo_pedido=detalle_pedido.codigo_pedido group by detalle_pedido.proveedor"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("proveedor"))
            Next
        End If
        conexion.Close()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        fecha()
        busqueda()
        llenar_combo_marca()
    End Sub

    Private Sub dtp2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        fecha()
        busqueda()
        llenar_combo_marca()
    End Sub

    Sub llenar_combo_proveedor()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        'SC.CommandText = "select * from proveedores order by nombre_proveedor"

        SC.CommandText = "select detalle_pedido.proveedor as '' from  solicitar_cotizacion, pedido, detalle_pedido where solicitar_cotizacion.codigo_pedido=pedido.codigo_pedido and pedido.fecha_pedido >='" & (mifecha2) & "' and pedido.fecha_pedido <= '" & (mifecha4) & "' and pedido.codigo_pedido=detalle_pedido.codigo_pedido "

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("proveedor"))
            Next
        End If
        conexion.Close()
    End Sub

    Sub llenar_combo_vendedor()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select * from usuarios where ACTIVO='SI' order by nombre_usuario"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            Combo_vendedor.Items.Add("TODOS")
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                Combo_vendedor.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        conexion.Close()
    End Sub





    Private Sub txt_codigo_pedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_pedido.KeyPress
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
            mostrar_pedidos_por_codigo()
            Combo_vendedor.Text = ""
            txt_codigo_pedido.Text = ""
        End If
    End Sub

    Private Sub Combo_vendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_vendedor.KeyPress
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





    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        'mostrar_pedidos_por_vendedor()
        'Combo_vendedor.Text = ""
        'Combo_prioridad.Text = ""
        'Combo_estado.Text = ""
        'txt_codigo_pedido.Text = ""
        fecha()
        busqueda()
    End Sub

    Private Sub Combo_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_proveedor.KeyPress
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



    Private Sub Combo_proveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_proveedor.SelectedIndexChanged
        fecha()
        busqueda()
    End Sub

    Private Sub Combo_prioridad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub



    Private Sub Combo_prioridad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fecha()
        busqueda()
    End Sub

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

        If grilla_revision_pedidos.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo_pedido.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Sub grabar_reporte_pedido()
        Dim cod_pedido As String
        Dim vendedor As String
        Dim cod_item As String
        Dim proveedor As String
        Dim cantidad As String
        Dim descripcion As String
        Dim comentario As String
        Dim prioridad As String
        Dim fecha As String
        Dim estado As String
        Dim abono As String
        Dim fecha_llegada As String
        Dim campo_pedido As String
        Dim campo_vendedor As String
        Dim campo_proveedor As String
        Dim campo_prioridad As String = ""

        If txt_codigo_pedido.Text = "" Then
            campo_pedido = "TODOS"
        Else
            campo_pedido = txt_codigo_pedido.Text
        End If

        If Combo_vendedor.Text = "" Then
            campo_vendedor = "TODOS"
        Else
            campo_vendedor = Combo_vendedor.Text
        End If

        If Combo_proveedor.Text = "" Then
            campo_proveedor = "TODOS"
        Else
            campo_proveedor = Combo_proveedor.Text
        End If

        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "delete from reporte_pedido_temporal"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        conexion.Close()

        For i = 0 To grilla_revision_pedidos.Rows.Count - 1
            cod_pedido = grilla_revision_pedidos.Rows(i).Cells(0).Value.ToString
            vendedor = grilla_revision_pedidos.Rows(i).Cells(1).Value.ToString
            cod_item = grilla_revision_pedidos.Rows(i).Cells(2).Value.ToString
            proveedor = grilla_revision_pedidos.Rows(i).Cells(3).Value.ToString
            cantidad = grilla_revision_pedidos.Rows(i).Cells(4).Value.ToString
            descripcion = grilla_revision_pedidos.Rows(i).Cells(5).Value.ToString
            comentario = grilla_revision_pedidos.Rows(i).Cells(6).Value.ToString
            prioridad = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString
            fecha = grilla_revision_pedidos.Rows(i).Cells(8).Value.ToString
            estado = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
            abono = grilla_revision_pedidos.Rows(i).Cells(10).Value.ToString
            fecha_llegada = grilla_revision_pedidos.Rows(i).Cells(11).Value.ToString

            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "insert into reporte_pedido_temporal (cod_pedido, vendedor, cod_item, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada, campo_pedido, campo_vendedor, campo_proveedor, campo_prioridad, desde, hasta) values(" & (cod_pedido) & ",'" & (vendedor) & "','" & (cod_item) & "','" & (proveedor) & "','" & (cantidad) & "','" & (descripcion) & "','" & (comentario) & "','" & (prioridad) & "','" & (fecha) & "', '" & (estado) & "','" & (abono) & "','" & (fecha_llegada) & "','" & (campo_pedido) & "','" & (campo_vendedor) & "','" & (campo_proveedor) & "','" & (campo_prioridad) & "','" & (dtp_desde.Text) & "','" & (dtp_hasta.Text) & "')"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            conexion.Close()
        Next
    End Sub



    Private Sub btn_comentario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grilla_revision_pedidos.Rows.Count <> 0 Then
            Form_comentario_pedido.Show()
            Me.Enabled = False
        Else
            MsgBox("SELECCIONE UN PEDIDO", 0 + 16, "ERROR")
        End If
    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Combo_estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub Combo_estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fecha()
        busqueda()
    End Sub

    Sub busqueda()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim texto_proveedor As String
        Dim texto_vendedor As String

        texto_proveedor = Combo_proveedor.Text
        texto_vendedor = Combo_vendedor.Text

        If Combo_proveedor.Text = "TODOS" Then
            Combo_proveedor.Text = ""
        End If
        If Combo_vendedor.Text = "TODOS" Then
            Combo_vendedor.Text = ""
        End If


        consulta_busqueda = "select pedido.codigo_pedido as 'PEDIDO', USUARIOS.nombre_usuario as 'VENDEDOR', detalle_pedido.codigo_auto as 'CODIGO AUTO.', detalle_pedido.codigo_producto as 'CODIGO', detalle_pedido.PROVEEDOR as 'PROV.', detalle_pedido.cantidad as 'CANT.', detalle_pedido.descripcion as 'DESCRIP.', detalle_pedido.comentario as 'COMENT.', pedido.fecha_pedido as 'FECHA', detalle_pedido.estado as 'ESTADO', pedido.hora as 'HORA' from pedido, detalle_pedido, usuarios, solicitar_cotizacion where solicitar_cotizacion.codigo_pedido=pedido.codigo_pedido and pedido.fecha_pedido >='" & (mifecha2) & "' and pedido.fecha_pedido <= '" & (mifecha4) & "' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario"


        If Combo_vendedor.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and nombre_usuario ='" & (Combo_vendedor.Text) & "'"
        End If

        If Combo_proveedor.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and proveedor ='" & (Combo_proveedor.Text) & "'"
        End If

        If Combo_marca.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and codigo_producto  like '" & ("%" & Combo_marca.Text & "%") & "'"
        End If

        If Combo_prioridad.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and prioridad  = '" & (Combo_prioridad.Text) & "'"
        End If


        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'SC.Connection = conexion
        'SC.CommandText = consulta_busqueda
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'grilla_revision_pedidos.Rows.Clear()

        'Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then

        '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

        '        grilla_revision_pedidos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD. PEDIDO"), _
        '         DS.Tables(DT.TableName).Rows(i).Item("VENDEDOR"), _
        '          DS.Tables(DT.TableName).Rows(i).Item("COD. PRODUCTO"), _
        '           DS.Tables(DT.TableName).Rows(i).Item("PROVEEDOR"), _
        '            DS.Tables(DT.TableName).Rows(i).Item("CANT."), _
        '             DS.Tables(DT.TableName).Rows(i).Item("DESCRIP."), _
        '              DS.Tables(DT.TableName).Rows(i).Item("COMENT."), _
        '               DS.Tables(DT.TableName).Rows(i).Item("PRIORIDAD"), _
        '                DS.Tables(DT.TableName).Rows(i).Item("FECHA PEDIDO"), _
        '                 DS.Tables(DT.TableName).Rows(i).Item("ESTADO"), _
        '                  DS.Tables(DT.TableName).Rows(i).Item("ABONO"), _
        '                   DS.Tables(DT.TableName).Rows(i).Item("LLEGADA"))
        '    Next
        'End If
        conexion.Close()
        Dim DT As New DataTable

        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = consulta_busqueda
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_revision_pedidos.DataSource = DS.Tables(DT.TableName)
        conexion.Close()

        grilla_revision_pedidos.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        grilla_revision_pedidos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grilla_revision_pedidos.Columns(0).Visible = True
        grilla_revision_pedidos.Columns(1).Visible = True
        grilla_revision_pedidos.Columns(2).Visible = False
        grilla_revision_pedidos.Columns(3).Visible = True
        grilla_revision_pedidos.Columns(4).Visible = True
        grilla_revision_pedidos.Columns(5).Visible = True
        grilla_revision_pedidos.Columns(7).Visible = False
        grilla_revision_pedidos.Columns(8).Visible = True
        grilla_revision_pedidos.Columns(9).Visible = False
        grilla_revision_pedidos.Columns(10).Visible = False

        Try
            grilla_revision_pedidos.Columns(0).Width = 70
            grilla_revision_pedidos.Columns(5).Width = 70
            grilla_revision_pedidos.Columns(9).Width = 90
        Catch
        End Try
        '0 pedido.codigo_pedido as 'PEDIDO', 
        '1 USUARIOS.nombre_usuario as 'VENDEDOR', 
        '2 detalle_pedido.codigo_auto as 'CODIGO AUTO.', 
        '3 detalle_pedido.codigo_producto as 'CODIGO', 
        '4 PROVEEDOR as 'PROV.', 
        '5 detalle_pedido.cantidad as 'CANT.', 
        '6 detalle_pedido.descripcion as 'DESCRIP.', 
        '7 detalle_pedido.comentario as 'COMENT.', 
        '8 pedido.fecha_pedido as 'FECHA', 
        '9 detalle_pedido.estado as 'ESTADO', 
        '10 pedido.hora as 'HORA' 


        Dim estado_revision As String

        For i = 0 To grilla_revision_pedidos.Rows.Count - 1
            estado_revision = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString


            If estado_revision = "POR COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If

            If estado_revision = "COTIZADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
            End If

            If estado_revision = "ACEPTADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If estado_revision = "ENCARGADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

        Next


        'grilla_detalle_cotizacion.Columns.Clear()
        grilla_ofertas.Columns.Clear()







        Combo_proveedor.Text = texto_proveedor
        Combo_vendedor.Text = texto_vendedor

        lbl_mensaje.Visible = False
        Me.Enabled = True
        Exit Sub
    End Sub

    Sub mostrar_pedidos_por_codigo()
        lbl_mensaje.Visible = True
        Me.Enabled = False



        consulta_busqueda = "select pedido.codigo_pedido as 'PEDIDO', USUARIOS.nombre_usuario as 'VENDEDOR', detalle_pedido.codigo_auto as 'CODIGO AUTO.', detalle_pedido.codigo_producto as 'CODIGO', detalle_pedido.PROVEEDOR as 'PROV.', detalle_pedido.cantidad as 'CANT.', detalle_pedido.descripcion as 'DESCRIP.', detalle_pedido.comentario as 'COMENT.', pedido.fecha_pedido as 'FECHA', detalle_pedido.estado as 'ESTADO', pedido.hora as 'HORA' from pedido, detalle_pedido, usuarios, solicitar_cotizacion where solicitar_cotizacion.codigo_pedido=pedido.codigo_pedido and pedido.fecha_pedido >='" & (mifecha2) & "' and pedido.fecha_pedido <= '" & (mifecha4) & "' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario"

        consulta_busqueda = consulta_busqueda & " and pedido.codigo_pedido ='" & (txt_codigo_pedido.Text) & "'"

        conexion.Close()
        Dim DT As New DataTable
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = consulta_busqueda
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_revision_pedidos.DataSource = DS.Tables(DT.TableName)
        conexion.Close()


        grilla_revision_pedidos.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        grilla_revision_pedidos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_revision_pedidos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grilla_revision_pedidos.Columns(0).Visible = True
        grilla_revision_pedidos.Columns(1).Visible = True
        grilla_revision_pedidos.Columns(2).Visible = False
        grilla_revision_pedidos.Columns(3).Visible = True
        grilla_revision_pedidos.Columns(4).Visible = True
        grilla_revision_pedidos.Columns(5).Visible = True
        grilla_revision_pedidos.Columns(7).Visible = True
        grilla_revision_pedidos.Columns(8).Visible = True
        grilla_revision_pedidos.Columns(9).Visible = False
        grilla_revision_pedidos.Columns(10).Visible = False

        grilla_revision_pedidos.Columns(0).Width = 70
        grilla_revision_pedidos.Columns(5).Width = 70
        grilla_revision_pedidos.Columns(9).Width = 90

        '0 pedido.codigo_pedido as 'PEDIDO', 
        '1 USUARIOS.nombre_usuario as 'VENDEDOR', 
        '2 detalle_pedido.codigo_auto as 'CODIGO AUTO.', 
        '3 detalle_pedido.codigo_producto as 'CODIGO', 
        '4 PROVEEDOR as 'PROV.', 
        '5 detalle_pedido.cantidad as 'CANT.', 
        '6 detalle_pedido.descripcion as 'DESCRIP.', 
        '7 detalle_pedido.comentario as 'COMENT.', 
        '8 pedido.fecha_pedido as 'FECHA', 
        '9 detalle_pedido.estado as 'ESTADO', 
        '10 pedido.hora as 'HORA' 


        Dim estado_revision As String

        For i = 0 To grilla_revision_pedidos.Rows.Count - 1
            estado_revision = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString


            If estado_revision = "POR COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If

            If estado_revision = "COTIZADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
            End If

            If estado_revision = "ACEPTADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If estado_revision = "ENCARGADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

        Next


        'grilla_detalle_cotizacion.Columns.Clear()
        grilla_ofertas.Columns.Clear()


























        lbl_mensaje.Visible = False
        Me.Enabled = True
        Exit Sub
    End Sub


    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_no_disponible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grilla_revision_pedidos.Rows.Count <> 0 Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            Dim codigo_pedido As String

            Dim codigo_producto As String
            codigo_pedido = grilla_revision_pedidos.CurrentRow.Cells(0).Value()
            codigo_producto = grilla_revision_pedidos.CurrentRow.Cells(2).Value

            Dim VALORMENSAJE As Integer
            VALORMENSAJE = MsgBox("¿DESEA CAMBIAR EL ESTADO A NO DISPONIBLE?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CAMBIAR ESTADO")

            If VALORMENSAJE = vbYes Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "UPDATE detalle_pedido SET `estado`='NO DISPONIBLE' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO= '" & (codigo_producto) & "' "
                DA.SelectCommand = SC
                DA.Fill(DT)
                conexion.Close()
            End If
            busqueda()
            Me.Enabled = True
            lbl_mensaje.Visible = False
        Else
            MsgBox("SELECCIONE LOS PEDIDOS", 0 + 16, "ERROR")
        End If
    End Sub

    Private Sub txt_codigo_pedido_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_pedido.GotFocus
        txt_codigo_pedido.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_pedido_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_pedido.LostFocus
        txt_codigo_pedido.BackColor = Color.White
    End Sub

    Private Sub Combo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.GotFocus
        Combo_vendedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.LostFocus
        Combo_vendedor.BackColor = Color.White
    End Sub

    Private Sub Combo_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_proveedor.GotFocus
        Combo_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_proveedor.LostFocus
        Combo_proveedor.BackColor = Color.White
    End Sub

    Private Sub dtp1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.GotFocus
        dtp_desde.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.LostFocus
        dtp_desde.BackColor = Color.White
    End Sub

    Private Sub dtp2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.GotFocus
        dtp_hasta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.LostFocus
        dtp_hasta.BackColor = Color.White
    End Sub

    Private Sub grilla_revision_pedidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'If grilla_revision_pedidos.Rows.Count = 0 Then
        '    Exit Sub
        'End If

        'If grilla_revision_pedidos.CurrentRow.Cells(2).Selected Then
        '    Exit Sub
        'End If

        'Dim codigo_pedido As String
        'Dim estado As String
        'Dim codigo_producto As String
        'Dim prioridad As String
        'Dim estado_revision As String

        'codigo_pedido = grilla_revision_pedidos.CurrentRow.Cells(0).Value
        'estado = grilla_revision_pedidos.CurrentRow.Cells(9).Value
        'codigo_producto = grilla_revision_pedidos.CurrentRow.Cells(2).Value
        'prioridad = grilla_revision_pedidos.CurrentRow.Cells(7).Value

        'grilla_revision_pedidos.CurrentRow.Cells(9).ReadOnly = False

        'If prioridad = "COTIZAR" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE DETALLE_pedido SET `PRIORIDAD`='COTIZADO' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    conexion.Close()
        '    ' migrilla.EditMode = True
        '    ''  migrilla.CurrentRow.Cells(9).Value = "NO DISPONIBLE"
        '    '' migrilla.EditMode = False
        '    'migrilla.CurrentRow.DefaultCellStyle.BackColor = Color.Tomato
        '    busqueda()

        'ElseIf prioridad = "COTIZADO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE DETALLE_pedido SET `PRIORIDAD`='COTIZAR' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    conexion.Close()
        '    ' migrilla.EditMode = True
        '    ''  migrilla.CurrentRow.Cells(9).Value = "NO DISPONIBLE"
        '    '' migrilla.EditMode = False
        '    'migrilla.CurrentRow.DefaultCellStyle.BackColor = Color.Tomato
        '    busqueda()

        '    'For i = 0 To migrilla.Rows.Count - 1
        '    '    'estado_revision = migrilla.Rows(i).Cells(9).Value.ToString
        '    '    prioridad = migrilla.Rows(i).Cells(7).Value.ToString

        '    '    If prioridad = "COTIZADO" Then
        '    '        migrilla.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
        '    '    End If

        '    '    If prioridad = "COTIZAR" Then
        '    '        migrilla.Rows(i).DefaultCellStyle.BackColor = Color.White
        '    '    End If
        '    'Next

        '    'Exit Sub
        'End If


        'If estado = "EN ESPERA" And prioridad <> "COTIZAR" And prioridad <> "COTIZADO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE DETALLE_pedido SET `estado`='ENCARGADO' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO= '" & (codigo_producto) & "' "
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    conexion.Close()
        '    '  migrilla.EditMode = True
        '    '' migrilla.CurrentRow.Cells(9).Value = "ENCARGADO"
        '    'migrilla.CurrentRow.DefaultCellStyle.BackColor = Color.SkyBlue
        '    busqueda()


        '    ' migrilla.EditMode = False

        'ElseIf estado = "ENCARGADO" And prioridad <> "COTIZAR" And prioridad <> "COTIZADO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE DETALLE_pedido SET `estado`='NO DISPONIBLE' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    conexion.Close()
        '    ' migrilla.EditMode = True
        '    ''  migrilla.CurrentRow.Cells(9).Value = "NO DISPONIBLE"
        '    '' migrilla.EditMode = False
        '    'migrilla.CurrentRow.DefaultCellStyle.BackColor = Color.Tomato
        '    busqueda()

        'ElseIf estado = "NO DISPONIBLE" And prioridad <> "COTIZAR" And prioridad <> "COTIZADO" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE DETALLE_pedido SET `estado`='EN ESPERA' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    conexion.Close()
        '    '  migrilla.EditMode = True
        '    '' migrilla.CurrentRow.Cells(9).Value = "EN ESPERA"
        '    '' migrilla.EditMode = False
        '    'migrilla.CurrentRow.DefaultCellStyle.BackColor = Color.White
        '    busqueda()
        'End If


        '' Dim estado_revision As String
        'For i = 0 To grilla_revision_pedidos.Rows.Count - 1
        '    estado_revision = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
        '    prioridad = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString
        '    'If estado_revision = "ENCARGADO" Then
        '    '    grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
        '    'End If

        '    'If estado_revision = "NO DISPONIBLE" Then
        '    '    grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
        '    'End If

        '    'If prioridad = "COTIZADO" Then
        '    '    grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
        '    'End If

        '    'If prioridad = "COTIZAR" Then
        '    '    grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
        '    'End If

        '    'If prioridad = "ENCARGADO" Then
        '    '    grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Orange
        '    'End If

        'Next
    End Sub

    Private Sub migrilla_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_revision_pedidos.CellContentClick

    End Sub

    Private Sub migrilla_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_revision_pedidos.DoubleClick


        If grilla_revision_pedidos.Rows.Count = 0 Then
            Exit Sub
        End If



    End Sub

    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")>
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Public Function GetInactiveTime() As Nullable(Of TimeSpan)
        Dim info As LASTINPUTINFO = New LASTINPUTINFO
        info.cbSize = CUInt(Marshal.SizeOf(info))
        If (GetLastInputInfo(info)) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
        Else
            Return Nothing
        End If
    End Function

    Private Sub grilla_revision_pedidos_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_revision_pedidos.Sorted

        Dim estado_revision As String

        For i = 0 To grilla_revision_pedidos.Rows.Count - 1
            estado_revision = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString


            If estado_revision = "POR COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If

            If estado_revision = "COTIZADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.BurlyWood
            End If

            If estado_revision = "ACEPTADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If estado_revision = "ENCARGADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

        Next

    End Sub



    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.grilla_revision_pedidos.Rows.Count = 0 Then
            Exit Sub
        End If

        Me.Enabled = False
        Form_pedidos_proveedor.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_revision_pedidos.CurrentRow.Cells(1).Value = "OK"
        grilla_revision_pedidos.CurrentRow.DefaultCellStyle.BackColor = Color.Green
    End Sub

    'Sub mostrar_malla_detalle_cotizacion()

    '    Dim nro_pedido As String = ""

    '    nro_pedido = grilla_revision_pedidos.CurrentRow.Cells(0).Value

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion

    '    SC.CommandText = "SELECT codigo_auto, codigo_producto, cantidad, descripcion FROM basededatos.detalle_pedido where codigo_pedido='" & (nro_pedido) & "';"

    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    grilla_detalle_cotizacion.Rows.Clear()
    '    grilla_detalle_cotizacion.Columns.Clear()
    '    grilla_detalle_cotizacion.Columns.Add("", "CODIGO")
    '    grilla_detalle_cotizacion.Columns.Add("", "DESCRIPCION")
    '    grilla_detalle_cotizacion.Columns.Add("", "CANTIDAD")
    '    grilla_detalle_cotizacion.Columns.Add("", "COMENTARIO")
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_detalle_cotizacion.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_auto"),
    '                                                DS.Tables(DT.TableName).Rows(i).Item("codigo_producto"),
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("cantidad"),
    '                                                  DS.Tables(DT.TableName).Rows(i).Item("descripcion"))
    '        Next
    '    End If

    '    If grilla_detalle_cotizacion.Rows.Count <> 0 Then
    '        If grilla_detalle_cotizacion.Columns(0).Width = 152 Then
    '            grilla_detalle_cotizacion.Columns(0).Width = 151
    '        Else
    '            grilla_detalle_cotizacion.Columns(0).Width = 152
    '        End If
    '        grilla_detalle_cotizacion.Columns(1).Width = 152
    '        grilla_detalle_cotizacion.Columns(2).Width = 152
    '        grilla_detalle_cotizacion.Columns(3).Width = 152
    '        grilla_detalle_cotizacion.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '        grilla_detalle_cotizacion.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '        grilla_detalle_cotizacion.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '        grilla_detalle_cotizacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '    End If
    '    grilla_detalle_cotizacion.ClearSelection()

    '    grilla_ofertas.Columns.Clear()
    'End Sub

    Private Sub grilla_revision_pedidos_Click(sender As Object, e As EventArgs) Handles grilla_revision_pedidos.Click

        If grilla_revision_pedidos.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim nro_solicitud As String = ""
        Dim nro_chasis As String = ""
        Dim marca_vehiculo As String = ""
        Dim modelo_vehiculo As String = ""
        Dim cilindrada As String = ""
        Dim tipo_motor As String = ""
        Dim año As String = ""
        Dim nro_motor As String = ""
        Dim observacion As String = ""

        '"PEDIDO.codigo_pedido as 'PEDIDO',0
        'USUARIOS.nombre_usuario as 'VENDEDOR',1
        'DETALLE_PEDIDO.codigo_auto as 'CODIGO AUTO.'2
        'DETALLE_PEDIDO.codigo_producto as 'CODIGO',3
        'PROVEEDOR as 'PROV.',4
        'DETALLE_PEDIDO.cantidad as 'CANT.',5
        'DETALLE_PEDIDO.descripcion as 'DESCRIP.',6
        'DETALLE_PEDIDO.comentario as 'COMENT.',7
        'DETALLE_PEDIDO.prioridad as 'PRIORIDAD',8
        'PEDIDO.fecha_pedido as 'FECHA',9
        'DETALLE_PEDIDO.estado as 'ESTADO',10
        'PEDIDO.abono as 'ABONO',11
        'DETALLE_PEDIDO.fecha_llegada as 'LLEGADA',12
        'PEDIDO.hora as 'HORA', 13

        nro_solicitud = grilla_revision_pedidos.CurrentRow.Cells(0).Value.ToString


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select *  from solicitar_cotizacion where codigo_pedido='" & (nro_solicitud) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            nro_chasis = DS.Tables(DT.TableName).Rows(0).Item("nro_chasis")
            marca_vehiculo = DS.Tables(DT.TableName).Rows(0).Item("marca_vehiculo")
            modelo_vehiculo = DS.Tables(DT.TableName).Rows(0).Item("modelo_vehiculo")
            cilindrada = DS.Tables(DT.TableName).Rows(0).Item("cilindrada")
            tipo_motor = DS.Tables(DT.TableName).Rows(0).Item("tipo_motor")
            año = DS.Tables(DT.TableName).Rows(0).Item("year")
            nro_motor = DS.Tables(DT.TableName).Rows(0).Item("nro_motor")
            observacion = DS.Tables(DT.TableName).Rows(0).Item("observacion")
        End If
        conexion.Close()


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select *  from pedido where codigo_pedido='" & (nro_solicitud) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            lbl_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
            lbl_telefono_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
        End If
        conexion.Close()



        Dim cadena_copiar As String = ""

        cadena_copiar = cadena_copiar & marca_vehiculo & " " & modelo_vehiculo & " " & cilindrada & " " & tipo_motor & " " & año
        cadena_copiar = cadena_copiar + Chr(13) + Chr(10)

        cadena_copiar = cadena_copiar & nro_chasis
        cadena_copiar = cadena_copiar + Chr(13) + Chr(10)

        If nro_motor <> "" Then
            cadena_copiar = cadena_copiar & "NRO. MOTOR: " & nro_motor
            cadena_copiar = cadena_copiar + Chr(13) + Chr(10)
        End If

        cadena_copiar = cadena_copiar + Chr(13) + Chr(10)

        For i = 0 To grilla_revision_pedidos.Rows.Count - 1

            If grilla_revision_pedidos.Rows(i).Cells(0).Value.ToString = nro_solicitud Then
                cadena_copiar = cadena_copiar & grilla_revision_pedidos.Rows(i).Cells(5).Value.ToString & " " & grilla_revision_pedidos.Rows(i).Cells(6).Value.ToString
                cadena_copiar = cadena_copiar + Chr(13) + Chr(10)
            End If

        Next

        Dim nombre_vendedor As String = grilla_revision_pedidos.CurrentRow.Cells(1).Value.ToString
        Dim nombre_vendedor_separado() As String
        Dim nombre_vendedor_1 As String = ""
        Dim nombre_vendedor_2 As String = ""
        Dim nombre_vendedor_3 As String = ""

        nombre_vendedor_separado = Split(nombre_vendedor, " ")
        For n = 0 To UBound(nombre_vendedor_separado, 1)
            nombre_vendedor_1 = nombre_vendedor_separado(0)
            nombre_vendedor_2 = nombre_vendedor_separado(1)
            nombre_vendedor_3 = nombre_vendedor_separado(2)
        Next

        If nombre_vendedor_1.Length > 1 Then
            nombre_vendedor_1 = nombre_vendedor_1.Substring(0, 1)
        End If
        If nombre_vendedor_2.Length > 1 Then
            nombre_vendedor_2 = nombre_vendedor_2.Substring(0, 1)
        End If
        If nombre_vendedor_3.Length > 1 Then
            nombre_vendedor_3 = nombre_vendedor_3.Substring(0, 1)
        End If

        nombre_vendedor = nombre_vendedor_1 & nombre_vendedor_2 & nombre_vendedor_3

        cadena_copiar = cadena_copiar + Chr(13) + Chr(10)
        cadena_copiar = cadena_copiar & nombre_vendedor
        cadena_copiar = cadena_copiar + Chr(13) + Chr(10)

        cadena_copiar = cadena_copiar + Chr(13) + Chr(10)
        cadena_copiar = cadena_copiar + Chr(13) + Chr(10)


        cadena_copiar = cadena_copiar & "OBS: " & observacion

        txt_copiar_y_pegar.Text = cadena_copiar
        mostrar_malla_ofertas()




    End Sub

    Private Sub btn_aceptar_oferta_Click(sender As Object, e As EventArgs) Handles btn_aceptar_oferta.Click
        If grilla_revision_pedidos.Rows.Count = 0 Then
            Combo_proveedor.Focus()
            MsgBox("SELECCIONE UN REGISTRO DE LA MALLA COTIZACIONES", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If grilla_detalle_cotizacion.Rows.Count = 0 Then
        '    Combo_proveedor.Focus()
        '    MsgBox("SELECCIONE UN REGISTRO DE LA MALLA DETALLE COTIZACIONES", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        If grilla_ofertas.Rows.Count = 0 Then
            Combo_proveedor.Focus()
            MsgBox("SELECCIONE UN REGISTRO DE LA MALLA OFERTAS", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim nro_pedido As String = ""
        Dim nro_pedido_detalle As String = ""
        Dim nro_oferta As String = ""
        Dim proveedor_pedido As String = ""

        Try
            nro_pedido = grilla_revision_pedidos.CurrentRow.Cells(2).Value
        Catch
            MsgBox("DEBE SELECCIONAR UN REGISTRO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End Try



        Try
            nro_oferta = grilla_ofertas.CurrentRow.Cells(0).Value
            proveedor_pedido = grilla_ofertas.CurrentRow.Cells(1).Value
        Catch
            MsgBox("DEBE SELECCIONAR UN REGISTRO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End Try


        SC.Connection = conexion
        SC.CommandText = "UPDATE `ofertas_cotizaciones` SET `estado`='ACEPTADO' WHERE `cod_auto`='" & (nro_oferta) & "';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE `detalle_pedido` SET `estado`='ACEPTADO', `proveedor`='" & (proveedor_pedido) & "' WHERE `codigo_auto`='" & (nro_pedido) & "';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        busqueda()


        mostrar_malla_ofertas()


        MsgBox("OFERTA ACEPTADA CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

    End Sub

    Private Sub btn_editar_oferta_Click(sender As Object, e As EventArgs) Handles btn_editar_oferta.Click
        If grilla_revision_pedidos.Rows.Count = 0 Then
            Combo_proveedor.Focus()
            MsgBox("SELECCIONE UN REGISTRO DE LA MALLA COTIZACIONES", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim estado_pedido As String = ""
        Try
            'nro_pedido = grilla_revision_pedidos.CurrentRow.Cells(2).Value
            estado_pedido = grilla_revision_pedidos.CurrentRow.Cells(9).Value
        Catch
            MsgBox("DEBE SELECCIONAR UN REGISTRO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End Try

        If estado_pedido = "ENCARGADO" Then
            MsgBox("EL PEDIDO YA FUE ENCARGADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If



        Form_editar_ofertas_productos.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_encargar_pedido_Click(sender As Object, e As EventArgs) Handles btn_encargar_pedido.Click
        If grilla_revision_pedidos.Rows.Count = 0 Then
            Combo_proveedor.Focus()
            MsgBox("SELECCIONE UN REGISTRO DE LA MALLA COTIZACIONES", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        'If grilla_detalle_cotizacion.Rows.Count = 0 Then
        '    Combo_proveedor.Focus()
        '    MsgBox("SELECCIONE UN REGISTRO DE LA MALLA DETALLE COTIZACIONES", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        Dim nro_pedido As String = ""
        Dim nro_pedido_detalle As String = ""
        Dim estado_pedido As String = ""

        '0 pedido.codigo_pedido as 'PEDIDO', 
        '1 USUARIOS.nombre_usuario as 'VENDEDOR', 
        '2 detalle_pedido.codigo_auto as 'CODIGO AUTO.', 
        '3 detalle_pedido.codigo_producto as 'CODIGO', 
        '4 PROVEEDOR as 'PROV.', 
        '5 detalle_pedido.cantidad as 'CANT.', 
        '6 detalle_pedido.descripcion as 'DESCRIP.', 
        '7 detalle_pedido.comentario as 'COMENT.', 
        '8 pedido.fecha_pedido as 'FECHA', 
        '9 detalle_pedido.estado as 'ESTADO', 
        '10 pedido.hora as 'HORA' 

        Try
            nro_pedido = grilla_revision_pedidos.CurrentRow.Cells(2).Value
            estado_pedido = grilla_revision_pedidos.CurrentRow.Cells(9).Value
        Catch
            MsgBox("DEBE SELECCIONAR UN REGISTRO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End Try

        'Try
        '    nro_pedido_detalle = grilla_detalle_cotizacion.CurrentRow.Cells(0).Value
        'Catch
        '    MsgBox("DEBE SELECCIONAR UN REGISTRO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End Try
        If estado_pedido <> "ACEPTADO" Then
            MsgBox("EL PEDIDO DEBE SER ACEPTADO POR EL VENDEDOR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If


        SC.Connection = conexion
        SC.CommandText = "UPDATE `detalle_pedido` SET `estado`='ENCARGADO' WHERE `codigo_auto`='" & (nro_pedido) & "';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        busqueda()


    End Sub




    Sub mostrar_malla_ofertas()

        Dim nro_pedido As String = ""
        Dim nro_pedido_detalle As String = ""

        nro_pedido = grilla_revision_pedidos.CurrentRow.Cells(0).Value
        nro_pedido_detalle = grilla_revision_pedidos.CurrentRow.Cells(2).Value

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT cod_auto, proveedor, costo, comentario, estado FROM ofertas_cotizaciones where nro_pedido='" & (nro_pedido) & "' and  nro_pedido_detalle='" & (nro_pedido_detalle) & "';"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_ofertas.Rows.Clear()
        grilla_ofertas.Columns.Clear()
        grilla_ofertas.Columns.Add("", "CODIGO")
        grilla_ofertas.Columns.Add("", "PROVEEDOR")
        grilla_ofertas.Columns.Add("", "COSTO")
        grilla_ofertas.Columns.Add("", "COMENTARIO")
        grilla_ofertas.Columns.Add("", "ESTADO")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_ofertas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("proveedor"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("costo"),
                                                      DS.Tables(DT.TableName).Rows(i).Item("comentario"),
                                                       DS.Tables(DT.TableName).Rows(i).Item("estado"))
            Next
        End If

        If grilla_ofertas.Rows.Count <> 0 Then
            If grilla_ofertas.Columns(0).Width = 300 Then
                grilla_ofertas.Columns(0).Width = 299
            Else
                grilla_ofertas.Columns(0).Width = 300
            End If
            grilla_ofertas.Columns(1).Width = 300
            grilla_ofertas.Columns(2).Width = 100
            grilla_ofertas.Columns(3).Width = 463


            grilla_ofertas.Columns(0).Visible = False
            grilla_ofertas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_ofertas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_ofertas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_ofertas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If
        'grilla_ofertas.ClearSelection()
        'grilla_ofertas.Columns.Clear()

    End Sub

    Private Sub grilla_detalle_cotizacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Combo_marca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_marca.SelectedIndexChanged
        fecha()
        busqueda()
    End Sub

    Private Sub Combo_prioridad_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Combo_prioridad.SelectedIndexChanged
        fecha()
        busqueda()
    End Sub

    Private Sub txt_codigo_pedido_TextChanged(sender As Object, e As EventArgs) Handles txt_codigo_pedido.TextChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If txt_copiar_y_pegar.Text <> "" Then
            Clipboard.SetText(txt_copiar_y_pegar.Text)
        End If

    End Sub

    Private Sub btn_eliminar_Click_1(sender As Object, e As EventArgs) Handles btn_eliminar.Click

        If grilla_revision_pedidos.Rows.Count <> 0 Then
            lbl_mensaje.Visible = True
            Me.Enabled = False


            Dim cod_producto As String
            Dim nro_pedido As String
            Dim detalle_pedido As String
            'Dim codigo_pedido As String
            Dim proveedor As String
            Dim valormensaje As Integer
            Dim mensaje As String = ""

            If grilla_revision_pedidos.Rows.Count = 0 Then
                MsgBox("SELECCIONE UN DOCUMENTO", 0 + 16, "ERROR")
            Else

                valormensaje = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

                If valormensaje = vbYes Then

                    valormensaje = MsgBox("¿ESTA REALMENTE SEGURO QUE DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

                    If valormensaje = vbYes Then

                        nro_pedido = grilla_revision_pedidos.CurrentRow.Cells(0).Value
                        detalle_pedido = grilla_revision_pedidos.CurrentRow.Cells(5).Value
                        proveedor = grilla_revision_pedidos.CurrentRow.Cells(3).Value
                        cod_producto = grilla_revision_pedidos.CurrentRow.Cells(2).Value

                        '0 pedido.codigo_pedido as 'PEDIDO', 
                        '1 USUARIOS.nombre_usuario as 'VENDEDOR', 
                        '2 detalle_pedido.codigo_auto as 'CODIGO AUTO.', 
                        '3 detalle_pedido.codigo_producto as 'CODIGO', 
                        '4 PROVEEDOR as 'PROV.', 
                        '5 detalle_pedido.cantidad as 'CANT.', 
                        '6 detalle_pedido.descripcion as 'DESCRIP.', 
                        '7 detalle_pedido.comentario as 'COMENT.', 
                        '8 pedido.fecha_pedido as 'FECHA', 
                        '9 detalle_pedido.estado as 'ESTADO', 
                        '10 pedido.hora as 'HORA' 

                        If grilla_revision_pedidos.Rows.Count > 0 Then

                            SC.Connection = conexion
                            SC.CommandText = "delete from detalle_pedido where codigo_auto = '" & (cod_producto) & "'"
                            DA.SelectCommand = SC
                            DA.Fill(DT)

                        End If
                    End If
                End If
            End If

            busqueda()

            Me.Enabled = True
            lbl_mensaje.Visible = False

        End If

    End Sub
End Class