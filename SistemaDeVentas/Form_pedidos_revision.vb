Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Form_pedidos_revision
    Dim mitexto As String
    Dim micampo As String
    Dim consulta_busqueda As String
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim numero_lineas_total As Integer = 0
    'Dim impreso As Integer = 0

    Private Sub Form_revision_de_pedidos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_revision_de_pedidos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_revision_de_pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dtp1.CustomFormat = "yyy-MM-dd"
        'dtp2.CustomFormat = "yyy-MM-dd"
        dtp3.CustomFormat = "yyy-MM-dd"

        dtp_desde.Value = dtp_desde.Value.AddDays(Val(-7))

        Timer_revision_pedidos.Start()

        busqueda()
        'mostrar_pedidos()
        ' llenar_combo_proveedor()
        llenar_combo_vendedor()
        cargar_logo()
        txt_codigo_pedido.Focus()
        'Me.BackColor = Color.FromArgb(color_fondo)
        'Me.ForeColor = Color.FromArgb(color_texto)
        llenar_combo_proveedores_mas_pedidos()
    End Sub



    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub llenar_combo_proveedores_mas_pedidos()
        Combo_proveedor.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from proveedores_Mas_pedidos order by nombre_proveedor"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_proveedor"))
            Next
            Combo_proveedor.Items.Add("OTROS")
        End If
        conexion.Close()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    'Sub mostrar_pedidos()
    '    grilla_pedido.Rows.Clear()
    '    DS.Tables.Clear()
    '    DT.Columns.Clear()
    '    DT.Rows.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores where fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "' and detalle_pedido.estado <> 'recepcionado' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.proveedor=proveedores.rut_proveedor order by pedido.codigo_pedido asc"
    '    DA.SelectCommand = SC

    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        Dim codigo_pedido As String
    '        Dim vendedor As String
    '        Dim codigo As String
    '        Dim proveedor As String
    '        Dim cantidad As String
    '        Dim descripcion As String
    '        Dim comentario As String
    '        Dim prioridad As String
    '        Dim fecha As String
    '        Dim estado As String
    '        Dim abono As String
    '        Dim fecha_llegada As String
    '        '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '            vendedor = DS.Tables(DT.TableName).Rows(i).Item("NOMBRE_USUARIO")
    '            codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_PRODUCTO")
    '            proveedor = DS.Tables(DT.TableName).Rows(i).Item("NOMBRE_proveedor")
    '            cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '            descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '            comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '            prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '            fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_PEDIDO")
    '            estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '            abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '            fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '            grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada)
    '        Next
    '    End If
    '    conexion.Close()

    '    Dim estado_revision As String
    '    'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '    For i = 0 To grilla_pedido.Rows.Count - 1
    '        estado_revision = grilla_pedido.Rows(i).Cells(9).Value.ToString
    '        If estado_revision = "ENCARGADO" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '        End If

    '        If estado_revision = "NO DISPONIBLE" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '        End If
    '    Next


    '    grilla_pedido.Columns(9).Visible = False
    '    grilla_pedido.Columns(10).Visible = False
    '    grilla_pedido.Columns(11).Visible = False

    'End Sub

    'Sub mostrar_pedidos_por_codigo()
    '    grilla_pedido.Rows.Clear()
    '    DS.Tables.Clear()
    '    DT.Columns.Clear()
    '    DT.Rows.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores where pedido.codigo_pedido ='" & (txt_codigo_pedido.Text) & "' AND ESTADO <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.proveedor=proveedores.rut_proveedor  ORDER BY pedido.codigo_pedido asc"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        Dim codigo_pedido As String
    '        Dim vendedor As String
    '        Dim codigo As String
    '        Dim proveedor As String
    '        Dim cantidad As String
    '        Dim descripcion As String
    '        Dim comentario As String
    '        Dim prioridad As String
    '        Dim fecha As String
    '        Dim estado As String
    '        Dim abono As String
    '        Dim fecha_llegada As String
    '        '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '            vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '            codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_PRODUCTO")
    '            proveedor = DS.Tables(DT.TableName).Rows(i).Item("NOMBRE_proveedor")
    '            cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '            descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '            comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '            prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '            fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_PEDIDO")
    '            estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '            abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '            fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '            grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada)
    '        Next
    '    End If
    '    conexion.Close()

    '    Dim estado_revision As String
    '    'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '    For i = 0 To grilla_pedido.Rows.Count - 1
    '        estado_revision = grilla_pedido.Rows(i).Cells(9).Value.ToString
    '        If estado_revision = "ENCARGADO" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '        End If
    '        If estado_revision = "NO DISPONIBLE" Then
    '            grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '        End If
    '    Next
    '    grilla_pedido.Columns(9).Visible = False
    '    grilla_pedido.Columns(10).Visible = False
    '    grilla_pedido.Columns(11).Visible = False
    'End Sub

    'Sub mostrar_pedidos_por_vendedor()
    '    If Combo_vendedor.Text <> "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores where nombre_usuario ='" & (Combo_vendedor.Text) & "' and  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  AND ESTADO <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.proveedor=proveedores.rut_proveedor   ORDER BY pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String
    '            Dim fecha_llegada As String
    '            '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(9).Value.ToString
    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If

    '    If Combo_vendedor.Text = "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores where fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  AND ESTADO <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.proveedor=proveedores.rut_proveedor   ORDER BY pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String
    '            Dim fecha_llegada As String
    '            '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(9).Value.ToString
    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If

    '    grilla_pedido.Columns(9).Visible = False
    '    grilla_pedido.Columns(10).Visible = False
    '    grilla_pedido.Columns(11).Visible = False
    'End Sub

    'Sub mostrar_pedidos_por_proveedor()
    '    If Combo_proveedor.Text <> "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores where nombre_proveedor ='" & (Combo_proveedor.Text) & "' and  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "' AND ESTADO <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.proveedor=proveedores.rut_proveedor   ORDER BY pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String
    '            Dim fecha_llegada As String
    '            '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(9).Value.ToString
    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If

    '    If Combo_proveedor.Text = "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores where fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  AND ESTADO <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.proveedor=proveedores.rut_proveedor   ORDER BY pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String
    '            Dim fecha_llegada As String
    '            '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(9).Value.ToString
    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If

    '    grilla_pedido.Columns(9).Visible = False
    '    grilla_pedido.Columns(10).Visible = False
    '    grilla_pedido.Columns(11).Visible = False
    'End Sub

    'Sub mostrar_pedidos_por_prioridad()
    '    If Combo_prioridad.Text <> "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores where prioridad ='" & (Combo_prioridad.Text) & "' and  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  AND ESTADO <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.proveedor=proveedores.rut_proveedor  ORDER BY pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String
    '            Dim fecha_llegada As String
    '            '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(9).Value.ToString
    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If

    '    If Combo_prioridad.Text = "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores where  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  AND ESTADO <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.proveedor=proveedores.rut_proveedor  ORDER BY pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String
    '            Dim fecha_llegada As String
    '            '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(9).Value.ToString
    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If

    '    grilla_pedido.Columns(9).Visible = False
    '    grilla_pedido.Columns(10).Visible = False
    '    grilla_pedido.Columns(11).Visible = False
    'End Sub

    'Sub mostrar_pedidos_por_estado()
    '    If Combo_estado.Text <> "TODOS" Then
    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores where estado ='" & (Combo_estado.Text) & "' and  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  AND ESTADO <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.proveedor=proveedores.rut_proveedor  ORDER BY pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String
    '            Dim fecha_llegada As String
    '            '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada)
    '            Next
    '        End If
    '        conexion.Close()

    '        Dim estado_revision As String
    '        'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(9).Value.ToString
    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next
    '    End If

    '    If Combo_estado.Text = "TODOS" Then

    '        grilla_pedido.Rows.Clear()
    '        DS.Tables.Clear()
    '        DT.Columns.Clear()
    '        DT.Rows.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from pedido, detalle_pedido, usuarios, proveedores where  fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "'  AND ESTADO <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.proveedor=proveedores.rut_proveedor  ORDER BY pedido.codigo_pedido asc"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)
    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '            Dim codigo_pedido As String
    '            Dim vendedor As String
    '            Dim codigo As String
    '            Dim proveedor As String
    '            Dim cantidad As String
    '            Dim descripcion As String
    '            Dim comentario As String
    '            Dim prioridad As String
    '            Dim fecha As String
    '            Dim estado As String
    '            Dim abono As String
    '            Dim fecha_llegada As String

    '            '     Dim DgvColumnCheck As DataGridViewCheckBoxColumn

    '            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '                codigo_pedido = DS.Tables(DT.TableName).Rows(i).Item("codigo_pedido")
    '                vendedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario")
    '                codigo = DS.Tables(DT.TableName).Rows(i).Item("codigo_producto")
    '                proveedor = DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor")
    '                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
    '                descripcion = DS.Tables(DT.TableName).Rows(i).Item("descripcion")
    '                comentario = DS.Tables(DT.TableName).Rows(i).Item("comentario")
    '                prioridad = DS.Tables(DT.TableName).Rows(i).Item("prioridad")
    '                fecha = DS.Tables(DT.TableName).Rows(i).Item("fecha_pedido")
    '                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
    '                abono = DS.Tables(DT.TableName).Rows(i).Item("abono")
    '                fecha_llegada = DS.Tables(DT.TableName).Rows(i).Item("fecha_llegada")
    '                grilla_pedido.Rows.Add(codigo_pedido, vendedor, codigo, proveedor, cantidad, descripcion, comentario, prioridad, fecha, estado, abono, fecha_llegada)
    '            Next
    '        End If
    '        conexion.Close()


    '        Dim estado_revision As String
    '        'estado_revision = grilla1.CurrentRow.Cells(9).Value
    '        For i = 0 To grilla_pedido.Rows.Count - 1
    '            estado_revision = grilla_pedido.Rows(i).Cells(9).Value.ToString
    '            If estado_revision = "ENCARGADO" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
    '            End If
    '            If estado_revision = "NO DISPONIBLE" Then
    '                grilla_pedido.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
    '            End If
    '        Next

    '    End If

    '    grilla_pedido.Columns(9).Visible = False
    '    grilla_pedido.Columns(10).Visible = False
    '    grilla_pedido.Columns(11).Visible = False
    'End Sub


    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        'mostrar_pedidos()
        'Combo_vendedor.Text = ""
        'Combo_proveedor.Text = ""
        'Combo_prioridad.Text = ""
        'txt_codigo_pedido.Text = ""

        'If Combo_vendedor.Text = "" And Combo_proveedor.Text = "" And Combo_prioridad.Text = "" And txt_codigo_pedido.Text = "" Then
        '    mostrar_pedidos()
        'End If

        'If Combo_vendedor.Text <> "" Then
        '    mostrar_pedidos_por_vendedor()
        'End If
        'If Combo_proveedor.Text <> "" Then
        '    mostrar_pedidos_por_proveedor()
        'End If
        'If Combo_prioridad.Text <> "" Then
        '    mostrar_pedidos_por_prioridad()
        'End If
        'If txt_codigo_pedido.Text <> "" Then
        '    mostrar_pedidos_por_codigo()
        'End If
        fecha()
        busqueda()
    End Sub

    Private Sub dtp2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        'mostrar_pedidos()
        'Combo_vendedor.Text = ""
        'Combo_proveedor.Text = ""
        'Combo_prioridad.Text = ""
        'txt_codigo_pedido.Text = ""

        'If Combo_vendedor.Text = "" And Combo_proveedor.Text = "" And Combo_prioridad.Text = "" And txt_codigo_pedido.Text = "" Then
        '    mostrar_pedidos()
        'End If

        'If Combo_vendedor.Text <> "" Then
        '    mostrar_pedidos_por_vendedor()
        'End If
        'If Combo_proveedor.Text <> "" Then
        '    mostrar_pedidos_por_proveedor()
        'End If
        'If Combo_prioridad.Text <> "" Then
        '    mostrar_pedidos_por_prioridad()
        'End If
        'If txt_codigo_pedido.Text <> "" Then
        '    mostrar_pedidos_por_codigo()
        'End If
        fecha()
        busqueda()
    End Sub





    Sub llenar_combo_proveedor()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from proveedores order by nombre_proveedor"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"))
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
            Combo_prioridad.Text = ""
            Combo_estado.Text = ""
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
        'mostrar_pedidos_por_proveedor()
        'Combo_vendedor.Text = ""
        'Combo_prioridad.Text = ""
        'Combo_estado.Text = ""
        'txt_codigo_pedido.Text = ""
        fecha()
        busqueda()
    End Sub

    Private Sub Combo_prioridad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_prioridad.KeyPress
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



    Private Sub Combo_prioridad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_prioridad.SelectedIndexChanged
        'mostrar_pedidos_por_prioridad()
        'Combo_vendedor.Text = ""
        'Combo_prioridad.Text = ""
        'Combo_estado.Text = ""
        'txt_codigo_pedido.Text = ""
        fecha()
        busqueda()
    End Sub

    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet


    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("codigo_pedido", GetType(String)))
    '    dt.Columns.Add(New DataColumn("proveedor", GetType(String)))
    '    dt.Columns.Add(New DataColumn("desde", GetType(String)))
    '    dt.Columns.Add(New DataColumn("vendedor", GetType(String)))
    '    dt.Columns.Add(New DataColumn("prioridad", GetType(String)))
    '    dt.Columns.Add(New DataColumn("hasta", GetType(String)))
    '    dt.Columns.Add(New DataColumn("pedido_detalle", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("vendedor_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("codigo_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("proveedor_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("cantidad_detalle", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("prioridad_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("estado_detalle", GetType(String)))
    '    dt.Columns.Add(New DataColumn("abono_detalle", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("llegada_detalle", GetType(String)))

    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("ciudad_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))




    '    Dim pedido_detalle As String
    '    Dim vendedor_detalle As String
    '    Dim codigo_detalle As String
    '    Dim proveedor_detalle As String
    '    Dim cantidad_detalle As String
    '    Dim prioridad_detalle As String
    '    Dim fecha_detalle As String
    '    Dim estado_detalle As String
    '    Dim abono_detalle As String
    '    Dim llegada_detalle As String




    '    If txt_codigo_pedido.Text = "" Then
    '        txt_codigo_pedido.Text = "TODOS"
    '    End If

    '    If Combo_vendedor.Text = "" Then
    '        Combo_vendedor.Text = "TODOS"
    '    End If

    '    If Combo_proveedor.Text = "" Then
    '        Combo_proveedor.Text = "TODOS"
    '    End If

    '    If Combo_prioridad.Text = "" Then
    '        Combo_prioridad.Text = "TODOS"
    '    End If

    '    For i = 0 To grilla_revision_pedidos.Rows.Count - 1
    '        pedido_detalle = grilla_revision_pedidos.Rows(i).Cells(0).Value.ToString
    '        vendedor_detalle = grilla_revision_pedidos.Rows(i).Cells(1).Value.ToString
    '        codigo_detalle = grilla_revision_pedidos.Rows(i).Cells(2).Value.ToString
    '        proveedor_detalle = grilla_revision_pedidos.Rows(i).Cells(3).Value.ToString
    '        cantidad_detalle = grilla_revision_pedidos.Rows(i).Cells(4).Value.ToString
    '        prioridad_detalle = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString
    '        fecha_detalle = grilla_revision_pedidos.Rows(i).Cells(8).Value.ToString
    '        estado_detalle = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
    '        abono_detalle = grilla_revision_pedidos.Rows(i).Cells(10).Value.ToString
    '        llegada_detalle = grilla_revision_pedidos.Rows(i).Cells(11).Value.ToString



    '        'cod_pedido = grilla_revision_pedidos.Rows(i).Cells(0).Value.ToString
    '        'vendedor = grilla_revision_pedidos.Rows(i).Cells(1).Value.ToString
    '        'cod_item = grilla_revision_pedidos.Rows(i).Cells(2).Value.ToString
    '        'proveedor = grilla_revision_pedidos.Rows(i).Cells(3).Value.ToString
    '        'cantidad = grilla_revision_pedidos.Rows(i).Cells(4).Value.ToString
    '        'descripcion = grilla_revision_pedidos.Rows(i).Cells(5).Value.ToString
    '        'comentario = grilla_revision_pedidos.Rows(i).Cells(6).Value.ToString
    '        'prioridad = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString
    '        'fecha = grilla_revision_pedidos.Rows(i).Cells(8).Value.ToString
    '        'estado = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
    '        'abono = grilla_revision_pedidos.Rows(i).Cells(10).Value.ToString
    '        'fecha_llegada = grilla_revision_pedidos.Rows(i).Cells(11).Value.ToString

    '        'Varcoddocumento = grilla_revision_pedidos.Rows(i).Cells(0).Value.ToString
    '        'VarTipo = grilla_revision_pedidos.Rows(i).Cells(1).Value.ToString
    '        'Varfecha = grilla_revision_pedidos.Rows(i).Cells(2).Value
    '        'vartotal = grilla_revision_pedidos.Rows(i).Cells(3).Value.ToString
    '        'varsaldo = grilla_revision_pedidos.Rows(i).Cells(4).Value.ToString

    '        dr = dt.NewRow()

    '        'Try
    '        '    dr("Imagen") = Imagen_reporte
    '        'Catch
    '        'End Try

    '        dr("codigo_pedido") = txt_codigo_pedido.Text
    '        dr("proveedor") = Combo_proveedor.Text
    '        dr("desde") = dtp_desde.Text
    '        dr("vendedor") = Combo_vendedor.Text
    '        dr("prioridad") = Combo_prioridad.Text
    '        dr("hasta") = dtp_hasta.Text

    '        dr("pedido_detalle") = pedido_detalle
    '        dr("vendedor_detalle") = vendedor_detalle
    '        dr("codigo_detalle") = codigo_detalle
    '        dr("proveedor_detalle") = proveedor_detalle
    '        dr("cantidad_detalle") = cantidad_detalle
    '        dr("prioridad_detalle") = prioridad_detalle
    '        dr("fecha_detalle") = fecha_detalle
    '        dr("estado_detalle") = estado_detalle
    '        dr("abono_detalle") = abono_detalle
    '        dr("llegada_detalle") = llegada_detalle

    '        dr("nombre_empresa") = minombreempresa
    '        dr("giro_empresa") = migiroempresa
    '        dr("direccion_empresa") = midireccionempresa
    '        dr("ciudad_empresa") = micomunaempresa
    '        dr("telefono_empresa") = mitelefonoempresa
    '        dr("correo_empresa") = micorreoempresa
    '        dr("rut_empresa") = mirutempresa
    '        'dr("nombre_cliente") = txt_nombre_cliente.Text
    '        'dr("rut_cliente") = txt_rut_cliente.Text
    '        'dr("deuda_total") = txt_total_deuda.Text
    '        'dr("direccion_cliente") = txt_direccion_cliente.Text
    '        'dr("telefono_cliente") = txt_telefono.Text
    '        'dr("ciudad_cliente") = txt_ciudad_cliente.Text
    '        'dr("desglose_palabras") = txt_desglose.Text
    '        'dr("tipo_documento") = VarTipo
    '        'dr("nro_doc") = Varcoddocumento
    '        'dr("fecha_doc") = Varfecha
    '        'dr("total_doc") = vartotal
    '        'dr("saldo") = varsaldo
    '        dt.Rows.Add(dr)




    '    Next





    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "Pedidos"

    '    Dim iDS As New dsPedidos
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS


    '    If txt_codigo_pedido.Text = "TODOS" Then
    '        txt_codigo_pedido.Text = ""
    '    End If

    '    If Combo_vendedor.Text = "TODOS" Then
    '        Combo_vendedor.Text = ""
    '    End If

    '    If Combo_proveedor.Text = "TODOS" Then
    '        Combo_proveedor.Text = ""
    '    End If

    '    If Combo_prioridad.Text = "TODOS" Then
    '        Combo_prioridad.Text = ""
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


        If grilla_revision_pedidos.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo_pedido.Focus()
            Exit Sub
        End If

        'lbl_mensaje.Visible = True
        'Me.Enabled = False

        'Try
        '    Dim iReporte As New VisorReporte

        '    Dim rpt As New Crystal_pedidos_personalizado

        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()

        '    iReporte.Reporte = rpt
        '    iReporte.ShowDialog()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Me.Enabled = True
        'lbl_mensaje.Visible = False







        lbl_mensaje.Visible = True
        Me.Enabled = False



        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = True
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = True
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If


        'PrintPreviewDialog1.Document = PrintDocument1
        'Try
        '    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
        '    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
        '    'PrintPreviewDialog1.Document.DefaultPageSettings.Margins.Left = 100
        'Catch
        'End Try

        'Try
        '    PrintPreviewDialog1.Document.DefaultPageSettings.Landscape = True
        'Catch
        'End Try


        ''If Combo_impresora.Text = "VISUALIZAR LIBRO" Then
        'PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        'PrintPreviewDialog1.ShowDialog()

        'End If

        'If Combo_impresora.Text = "GUARDAR EN PDF" Then
        '    PrintDocument1.PrinterSettings.PrinterName = "Microsoft Print to PDF"
        '    PrintDocument1.Print()
        '    lbl_mensaje.Visible = False
        '    Me.Enabled = True
        '    Exit Sub
        'End If

        'PrintDocument1.PrinterSettings.PrinterName = "Microsoft Print to PDF"
        'PrintDocument1.Print()
        'PageSetupDialog1.ShowDialog()
        'PrintPreviewDialog1.Document = PrintDocument1
        'PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        'PrintPreviewDialog1.ShowDialog()
        lbl_mensaje.Visible = False
        Me.Enabled = True

        'Try
        '    Dim iReporte As New Form_informe_detalle_lote
        '    Dim rpt As New Crystal_existencias_multiple
        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()
        '    iReporte.Reporte = rpt
        '    iReporte.ShowDialog()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'lbl_mensaje.Visible = False
        'Me.Enabled = True

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
        Dim campo_prioridad As String

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

        If Combo_prioridad.Text = "" Then
            campo_prioridad = "TODOS"
        Else
            campo_prioridad = Combo_prioridad.Text
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



    Private Sub btn_comentario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_comentario.Click
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

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        busqueda_por_descripcion()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            busqueda_por_descripcion()
            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If
    End Sub

    Private Sub Combo_estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_estado.KeyPress
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




    Private Sub Combo_estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_estado.SelectedIndexChanged
        'mostrar_pedidos_por_estado()
        'Combo_vendedor.Text = ""
        'Combo_prioridad.Text = ""
        'Combo_estado.Text = ""
        'txt_codigo_pedido.Text = ""
        fecha()
        busqueda()
    End Sub

    Sub busqueda()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim texto_estado As String
        Dim texto_prioridad As String
        Dim texto_proveedor As String
        Dim texto_vendedor As String

        texto_estado = Combo_estado.Text
        texto_prioridad = Combo_prioridad.Text
        texto_proveedor = Combo_proveedor.Text
        texto_vendedor = Combo_vendedor.Text

        If Combo_estado.Text = "TODOS" Then
            Combo_estado.Text = ""
        End If
        If Combo_prioridad.Text = "TODOS" Then
            Combo_prioridad.Text = ""
        End If
        If Combo_proveedor.Text = "TODOS" Then
            Combo_proveedor.Text = ""
        End If
        If Combo_vendedor.Text = "TODOS" Then
            Combo_vendedor.Text = ""
        End If

        If Combo_vendedor.Text <> "" Then
            consulta_busqueda = "select PEDIDO.codigo_pedido as 'PEDIDO',USUARIOS.nombre_usuario as 'VENDEDOR',DETALLE_PEDIDO.codigo_producto as 'CODIGO',PROVEEDOR as 'PROV.',DETALLE_PEDIDO.cantidad as 'CANT.',DETALLE_PEDIDO.descripcion as 'DESCRIP.',DETALLE_PEDIDO.comentario as 'COMENT.',DETALLE_PEDIDO.prioridad as 'PRIORIDAD',PEDIDO.fecha_pedido as 'FECHA',DETALLE_PEDIDO.estado as 'ESTADO',PEDIDO.abono as 'ABONO',DETALLE_PEDIDO.fecha_llegada as 'LLEGADA', PEDIDO.hora as 'HORA', abono AS 'ABONO'  from pedido, detalle_pedido, usuarios where fecha_pedido >='" & (mifecha2) & "' and fecha_pedido <= '" & (mifecha4) & "' and detalle_pedido.estado <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and nombre_usuario ='" & (Combo_vendedor.Text) & "'"
        Else
            consulta_busqueda = "select PEDIDO.codigo_pedido as 'PEDIDO',USUARIOS.nombre_usuario as 'VENDEDOR',DETALLE_PEDIDO.codigo_producto as 'CODIGO',PROVEEDOR as 'PROV.',DETALLE_PEDIDO.cantidad as 'CANT.',DETALLE_PEDIDO.descripcion as 'DESCRIP.',DETALLE_PEDIDO.comentario as 'COMENT.',DETALLE_PEDIDO.prioridad as 'PRIORIDAD',PEDIDO.fecha_pedido as 'FECHA',DETALLE_PEDIDO.estado as 'ESTADO',PEDIDO.abono as 'ABONO',DETALLE_PEDIDO.fecha_llegada as 'LLEGADA', PEDIDO.hora as 'HORA' from pedido, detalle_pedido, usuarios  where fecha_pedido >='" & (mifecha2) & "' and fecha_pedido <= '" & (mifecha4) & "' and detalle_pedido.estado <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario"
        End If

        If Combo_proveedor.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and proveedor ='" & (Combo_proveedor.Text) & "'"
        Else
            consulta_busqueda = consulta_busqueda
        End If

        If Combo_estado.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and estado ='" & (Combo_estado.Text) & "'"
        Else
            consulta_busqueda = consulta_busqueda
        End If

        If Combo_prioridad.Text <> "" Then
            consulta_busqueda = consulta_busqueda & " and prioridad ='" & (Combo_prioridad.Text) & "'"
        Else
            consulta_busqueda = consulta_busqueda
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

        grilla_revision_pedidos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grilla_revision_pedidos.Columns(9).Visible = False
        'grilla_revision_pedidos.Columns(10).Visible = False
        grilla_revision_pedidos.Columns(11).Visible = False











        Dim estado_revision As String
        Dim prioridad As String








        For i = 0 To grilla_revision_pedidos.Rows.Count - 1
            estado_revision = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
            prioridad = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString

            If prioridad = "COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If

            If estado_revision = "ENCARGADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

            If estado_revision = "NO DISPONIBLE" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If

            If prioridad = "COTIZADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If prioridad = "COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If
        Next









        Combo_estado.Text = texto_estado
        Combo_prioridad.Text = texto_prioridad
        Combo_proveedor.Text = texto_proveedor
        Combo_vendedor.Text = texto_vendedor

        lbl_mensaje.Visible = False
        Me.Enabled = True
        Exit Sub
    End Sub

    Sub busqueda_por_descripcion()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        'consulta_busqueda = "select PEDIDO.codigo_pedido as 'PEDIDO',USUARIOS.nombre_usuario as 'VENDEDOR',DETALLE_PEDIDO.codigo_producto as 'CODIGO',proveedor as 'PROV.',DETALLE_PEDIDO.cantidad as 'CANT.',DETALLE_PEDIDO.descripcion as 'DESCRIP.',DETALLE_PEDIDO.comentario as 'COMENT.',DETALLE_PEDIDO.prioridad as 'PRIORIDAD',PEDIDO.fecha_pedido as 'FECHA',DETALLE_PEDIDO.estado as 'ESTADO',PEDIDO.abono as 'ABONO',DETALLE_PEDIDO.fecha_llegada as 'LLEGADA' from pedido, detalle_pedido, usuarios where fecha_pedido >='" & (dtp1.Text) & "' and fecha_pedido <= '" & (dtp2.Text) & "' and detalle_pedido.estado <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and detalle_pedido.descripcion Like " & "'" & ("%" & txt_buscar.Text & "%") & "'"


        'conexion.Close()
        'Dim DT As New DataTable
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()

        'SC.Connection = conexion
        'SC.CommandText = consulta_busqueda
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'grilla_revision_pedidos.DataSource = DS.Tables(DT.TableName)
        'conexion.Close()


        ''For Each col As DataGridViewColumn In Me.grilla_revision_pedidos.Columns
        ''    ' Las columnas sólo se pueden ordenar mediante programaciòn.
        ''    col.SortMode = DataGridViewColumnSortMode.NotSortable
        ''Next
        'grilla_revision_pedidos.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        'grilla_revision_pedidos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_revision_pedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_revision_pedidos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grilla_revision_pedidos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_revision_pedidos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'grilla_revision_pedidos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'grilla_revision_pedidos.Columns(9).Visible = False
        'grilla_revision_pedidos.Columns(10).Visible = False
        'grilla_revision_pedidos.Columns(11).Visible = False

















        'Dim estado_revision As String
        'Dim prioridad As String






        'For i = 0 To grilla_revision_pedidos.Rows.Count - 1
        '    estado_revision = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
        '    prioridad = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString

        '    If prioridad = "COTIZAR" Then
        '        grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
        '    End If

        '    If estado_revision = "ENCARGADO" Then
        '        grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
        '    End If

        '    If estado_revision = "NO DISPONIBLE" Then
        '        grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
        '    End If

        '    If prioridad = "COTIZADO" Then
        '        grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
        '    End If

        '    If prioridad = "COTIZAR" Then
        '        grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
        '    End If
        'Next



















































        consulta_busqueda = "select PEDIDO.codigo_pedido as 'PEDIDO',USUARIOS.nombre_usuario as 'VENDEDOR',DETALLE_PEDIDO.codigo_producto as 'CODIGO',proveedor as 'PROV.',DETALLE_PEDIDO.cantidad as 'CANT.',DETALLE_PEDIDO.descripcion as 'DESCRIP.',DETALLE_PEDIDO.comentario as 'COMENT.',DETALLE_PEDIDO.prioridad as 'PRIORIDAD',PEDIDO.fecha_pedido as 'FECHA',DETALLE_PEDIDO.estado as 'ESTADO',PEDIDO.abono as 'ABONO',DETALLE_PEDIDO.fecha_llegada as 'LLEGADA', PEDIDO.hora as 'HORA'  from pedido, detalle_pedido, usuarios where fecha_pedido >='" & (mifecha2) & "' and fecha_pedido <= '" & (mifecha4) & "' and detalle_pedido.estado <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario "
        Dim cadena As String
        Dim tabla() As String
        Dim n As Integer

        cadena = txt_buscar.Text
        '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
        tabla = Split(cadena, " ")

        For n = 0 To UBound(tabla, 1)
            consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',DETALLE_PEDIDO.codigo_producto, PROVEEDOR, DETALLE_PEDIDO.descripcion, DETALLE_PEDIDO.comentario) LIKE '" & ("%" & tabla(n) & "%") & "'"
        Next

        grilla_revision_pedidos.DataSource = Nothing

        Dim DT As New DataTable

        conexion.Close()
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

        grilla_revision_pedidos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grilla_revision_pedidos.Columns(9).Visible = False
        'grilla_revision_pedidos.Columns(10).Visible = False
        grilla_revision_pedidos.Columns(11).Visible = False










        Dim estado_revision As String
        Dim prioridad As String







        For i = 0 To grilla_revision_pedidos.Rows.Count - 1
            estado_revision = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
            prioridad = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString

            If prioridad = "COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If

            If estado_revision = "ENCARGADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

            If estado_revision = "NO DISPONIBLE" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If

            If prioridad = "COTIZADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If prioridad = "COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If
        Next














        lbl_mensaje.Visible = False
        Me.Enabled = True
        Exit Sub
    End Sub


    Private Sub migrilla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Sub mostrar_pedidos_por_codigo()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        consulta_busqueda = "select PEDIDO.codigo_pedido as 'PEDIDO',USUARIOS.nombre_usuario as 'VENDEDOR',DETALLE_PEDIDO.codigo_producto as 'COD.',proveedor as 'PROV.',DETALLE_PEDIDO.cantidad as 'CANT.',DETALLE_PEDIDO.descripcion as 'DESCRIP.',DETALLE_PEDIDO.comentario as 'COMENT.',DETALLE_PEDIDO.prioridad as 'PRIORIDAD',PEDIDO.fecha_pedido as 'FECHA',DETALLE_PEDIDO.estado as 'ESTADO',PEDIDO.abono as 'ABONO',DETALLE_PEDIDO.fecha_llegada as 'LLEGADA', PEDIDO.hora as 'HORA'  from pedido, detalle_pedido, usuarios where ESTADO <> 'RECEPCIONADO' and pedido.codigo_pedido=detalle_pedido.codigo_pedido and pedido.usuario_responsable=usuarios.rut_usuario and pedido.codigo_pedido ='" & (txt_codigo_pedido.Text) & "'"

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


        'For Each col As DataGridViewColumn In Me.grilla_revision_pedidos.Columns
        '    ' Las columnas sólo se pueden ordenar mediante programaciòn.
        '    col.SortMode = DataGridViewColumnSortMode.NotSortable
        'Next
        grilla_revision_pedidos.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        grilla_revision_pedidos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_revision_pedidos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_revision_pedidos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grilla_revision_pedidos.Columns(9).Visible = False
        'grilla_revision_pedidos.Columns(10).Visible = False
        grilla_revision_pedidos.Columns(11).Visible = False


















        Dim estado_revision As String
        Dim prioridad As String








        For i = 0 To grilla_revision_pedidos.Rows.Count - 1
            estado_revision = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
            prioridad = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString

            If prioridad = "COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If

            If estado_revision = "ENCARGADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

            If estado_revision = "NO DISPONIBLE" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If

            If prioridad = "COTIZADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If prioridad = "COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If
        Next






















        lbl_mensaje.Visible = False
        Me.Enabled = True
        Exit Sub
    End Sub


    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If grilla_revision_pedidos.Rows.Count <> 0 Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            'Dim codigo_pedido As String
            'codigo_pedido = grilla_revision_pedidos.CurrentRow.Cells(0).Value()

            'Dim VALORMENSAJE As Integer
            'VALORMENSAJE = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

            'If VALORMENSAJE = vbYes Then


            '    DS.Tables.Clear()
            '    DT.Rows.Clear()
            '    DT.Columns.Clear()
            '    DS.Clear()
            '    conexion.Open()

            '    SC.Connection = conexion
            '    SC.CommandText = "DELETE FROM pedido WHERE codigo_pedido = '" & (codigo_pedido) & "'"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)


            '    SC.Connection = conexion
            '    SC.CommandText = "DELETE FROM detalle_pedido WHERE codigo_pedido = '" & (codigo_pedido) & "'"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)



            '    DS.Tables.Add(DT)

            '    conexion.Close()


            'End If


















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

                        If grilla_revision_pedidos.Rows.Count > 0 Then

                            conexion.Close()
                            DS.Tables.Clear()
                            DT.Rows.Clear()
                            DT.Columns.Clear()
                            DS.Clear()
                            conexion.Open()

                            'SC.Connection = conexion
                            'SC.CommandText = "insert into registro_de_eliminaciones (tipo_eliminacion,detalle, codigo, fecha_eliminacion, usuario_responsable) values('REVISION DE PEDIDO','" & (detalle_pedido) & "','" & (nro_pedido) & "','" & (dtp3.Text) & "','" & (miusuario) & "')"
                            'DA.SelectCommand = SC
                            'DA.Fill(DT)

                            SC.Connection = conexion
                            SC.CommandText = "delete from detalle_pedido where codigo_producto = '" & (cod_producto) & "' and  codigo_pedido = '" & (nro_pedido) & "' and descripcion = '" & (detalle_pedido) & "'"
                            DA.SelectCommand = SC
                            DA.Fill(DT)


                            SC.Connection = conexion
                            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PEDIDOS','ELIMINACION DE PEDIDO','" & ("PEDIDO NRO. " & (nro_pedido)) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','ELIMINACION','" & (miusuario) & "')"
                            DA.SelectCommand = SC
                            DA.Fill(DT)

                            conexion.Close()

                            '  grilla_revision_pedidos.Rows.Remove(grilla_revision_pedidos.CurrentRow)

                        End If
                    End If
                End If
            End If








            busqueda()

            Me.Enabled = True
            lbl_mensaje.Visible = False

        End If









    End Sub

    Private Sub btn_no_disponible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_no_disponible.Click
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

    Private Sub Combo_estado_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_estado.GotFocus
        Combo_estado.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_estado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_estado.LostFocus
        Combo_estado.BackColor = Color.White
    End Sub

    Private Sub Combo_prioridad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_prioridad.GotFocus
        Combo_prioridad.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_prioridad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_prioridad.LostFocus
        Combo_prioridad.BackColor = Color.White
        'TextBox1.Text = ActiveControl.Name
    End Sub



    Private Sub txt_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_buscar.GotFocus
        txt_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_buscar.LostFocus
        txt_buscar.BackColor = Color.White
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

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_comentario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_comentario.GotFocus
        btn_comentario.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_comentario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_comentario.LostFocus
        btn_comentario.BackColor = Color.Transparent
    End Sub

    Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.GotFocus
        btn_eliminar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.LostFocus
        btn_eliminar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_no_disponible_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_no_disponible.GotFocus
        btn_no_disponible.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_no_disponible_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_no_disponible.LostFocus
        btn_no_disponible.BackColor = Color.Transparent
    End Sub


    Private Sub migrilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub grilla_revision_pedidos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub grilla_revision_pedidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If grilla_revision_pedidos.Rows.Count = 0 Then
            Exit Sub
        End If

        If grilla_revision_pedidos.CurrentRow.Cells(2).Selected Then
            Exit Sub
        End If

        Dim codigo_pedido As String
        Dim estado As String
        Dim codigo_producto As String
        Dim prioridad As String
        Dim estado_revision As String

        codigo_pedido = grilla_revision_pedidos.CurrentRow.Cells(0).Value
        estado = grilla_revision_pedidos.CurrentRow.Cells(9).Value
        codigo_producto = grilla_revision_pedidos.CurrentRow.Cells(2).Value
        prioridad = grilla_revision_pedidos.CurrentRow.Cells(7).Value

        grilla_revision_pedidos.CurrentRow.Cells(9).ReadOnly = False

        If prioridad = "COTIZAR" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "UPDATE DETALLE_pedido SET `PRIORIDAD`='COTIZADO' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
            ' migrilla.EditMode = True
            ''  migrilla.CurrentRow.Cells(9).Value = "NO DISPONIBLE"
            '' migrilla.EditMode = False
            'migrilla.CurrentRow.DefaultCellStyle.BackColor = Color.Tomato
            busqueda()

        ElseIf prioridad = "COTIZADO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "UPDATE DETALLE_pedido SET `PRIORIDAD`='COTIZAR' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
            ' migrilla.EditMode = True
            ''  migrilla.CurrentRow.Cells(9).Value = "NO DISPONIBLE"
            '' migrilla.EditMode = False
            'migrilla.CurrentRow.DefaultCellStyle.BackColor = Color.Tomato
            busqueda()

            'For i = 0 To migrilla.Rows.Count - 1
            '    'estado_revision = migrilla.Rows(i).Cells(9).Value.ToString
            '    prioridad = migrilla.Rows(i).Cells(7).Value.ToString

            '    If prioridad = "COTIZADO" Then
            '        migrilla.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            '    End If

            '    If prioridad = "COTIZAR" Then
            '        migrilla.Rows(i).DefaultCellStyle.BackColor = Color.White
            '    End If
            'Next

            'Exit Sub
        End If


        If estado = "EN ESPERA" And prioridad <> "COTIZAR" And prioridad <> "COTIZADO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "UPDATE DETALLE_pedido SET `estado`='ENCARGADO' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO= '" & (codigo_producto) & "' "
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
            '  migrilla.EditMode = True
            '' migrilla.CurrentRow.Cells(9).Value = "ENCARGADO"
            'migrilla.CurrentRow.DefaultCellStyle.BackColor = Color.SkyBlue
            busqueda()


            ' migrilla.EditMode = False

        ElseIf estado = "ENCARGADO" And prioridad <> "COTIZAR" And prioridad <> "COTIZADO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "UPDATE DETALLE_pedido SET `estado`='NO DISPONIBLE' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
            ' migrilla.EditMode = True
            ''  migrilla.CurrentRow.Cells(9).Value = "NO DISPONIBLE"
            '' migrilla.EditMode = False
            'migrilla.CurrentRow.DefaultCellStyle.BackColor = Color.Tomato
            busqueda()

        ElseIf estado = "NO DISPONIBLE" And prioridad <> "COTIZAR" And prioridad <> "COTIZADO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "UPDATE DETALLE_pedido SET `estado`='EN ESPERA' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
            '  migrilla.EditMode = True
            '' migrilla.CurrentRow.Cells(9).Value = "EN ESPERA"
            '' migrilla.EditMode = False
            'migrilla.CurrentRow.DefaultCellStyle.BackColor = Color.White
            busqueda()
        End If


        ' Dim estado_revision As String
        For i = 0 To grilla_revision_pedidos.Rows.Count - 1
            estado_revision = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
            prioridad = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString
            If estado_revision = "ENCARGADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

            If estado_revision = "NO DISPONIBLE" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If

            If prioridad = "COTIZADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If prioridad = "COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If
        Next
    End Sub

    Private Sub migrilla_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_revision_pedidos.CellContentClick

    End Sub

    Private Sub migrilla_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_revision_pedidos.DoubleClick


        If grilla_revision_pedidos.Rows.Count = 0 Then
            Exit Sub
        End If


        If grilla_revision_pedidos.CurrentRow.Cells(2).Selected Then
            Exit Sub
        End If


        Dim codigo_pedido As String
        Dim estado As String
        Dim codigo_producto As String
        Dim prioridad As String
        'Dim estado_revision As String


        codigo_pedido = grilla_revision_pedidos.CurrentRow.Cells(0).Value
        estado = grilla_revision_pedidos.CurrentRow.Cells(9).Value
        codigo_producto = grilla_revision_pedidos.CurrentRow.Cells(2).Value
        prioridad = grilla_revision_pedidos.CurrentRow.Cells(7).Value


        grilla_revision_pedidos.CurrentRow.Cells(9).ReadOnly = False


        If prioridad = "COTIZAR" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "UPDATE DETALLE_pedido SET `PRIORIDAD`='COTIZADO' AND usuario_responsable = '" & (miusuario) & "'  AND hora = '" & (Form_menu_principal.lbl_hora.Text) & "' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()

            grilla_revision_pedidos.CurrentRow.Cells(9).Value = "COTIZADO"
            grilla_revision_pedidos.CurrentRow.DefaultCellStyle.BackColor = Color.Green
            estado = grilla_revision_pedidos.CurrentRow.Cells(9).Value

            If Combo_estado.Text <> "" And Combo_estado.Text <> "TODOS" Then
                If Combo_estado.Text <> estado Then
                    grilla_revision_pedidos.Rows.Remove(grilla_revision_pedidos.CurrentRow)
                End If
            End If

            'busqueda()

        ElseIf prioridad = "COTIZADO" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "UPDATE DETALLE_pedido SET `PRIORIDAD`='COTIZAR'  AND usuario_responsable = '" & (miusuario) & "'  AND hora = '" & (Form_menu_principal.lbl_hora.Text) & "' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()

            grilla_revision_pedidos.CurrentRow.Cells(9).Value = "COTIZAR"
            grilla_revision_pedidos.CurrentRow.DefaultCellStyle.BackColor = Color.PaleGreen
            estado = grilla_revision_pedidos.CurrentRow.Cells(9).Value

            If Combo_estado.Text <> "" And Combo_estado.Text <> "TODOS" Then
                If Combo_estado.Text <> estado Then
                    grilla_revision_pedidos.Rows.Remove(grilla_revision_pedidos.CurrentRow)
                End If
            End If

            ' busqueda()

        End If


        If estado = "EN ESPERA" And prioridad <> "COTIZAR" And prioridad <> "COTIZADO" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "UPDATE detalle_pedido SET `estado`='ENCARGADO'  , usuario_responsable = '" & (miusuario) & "'  , hora = '" & (Form_menu_principal.lbl_hora.Text) & "'  WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND codigo_producto= '" & (codigo_producto) & "' "


            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()

            grilla_revision_pedidos.CurrentRow.Cells(9).Value = "ENCARGADO"
            grilla_revision_pedidos.CurrentRow.DefaultCellStyle.BackColor = Color.SkyBlue
            estado = grilla_revision_pedidos.CurrentRow.Cells(9).Value

            If Combo_estado.Text <> "" And Combo_estado.Text <> "TODOS" Then
                If Combo_estado.Text <> estado Then
                    grilla_revision_pedidos.Rows.Remove(grilla_revision_pedidos.CurrentRow)
                End If
            End If

            ' busqueda()

        ElseIf estado = "ENCARGADO" And prioridad <> "COTIZAR" And prioridad <> "COTIZADO" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "UPDATE DETALLE_pedido SET `estado`='NO DISPONIBLE' , usuario_responsable = '" & (miusuario) & "'  , hora = '" & (Form_menu_principal.lbl_hora.Text) & "'  WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()

            grilla_revision_pedidos.CurrentRow.Cells(9).Value = "NO DISPONIBLE"
            grilla_revision_pedidos.CurrentRow.DefaultCellStyle.BackColor = Color.Tomato
            estado = grilla_revision_pedidos.CurrentRow.Cells(9).Value

            If Combo_estado.Text <> "" And Combo_estado.Text <> "TODOS" Then
                If Combo_estado.Text <> estado Then
                    grilla_revision_pedidos.Rows.Remove(grilla_revision_pedidos.CurrentRow)
                End If
            End If

            ' busqueda()

        ElseIf estado = "NO DISPONIBLE" And prioridad <> "COTIZAR" And prioridad <> "COTIZADO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "UPDATE DETALLE_pedido SET `estado`='EN ESPERA'  , usuario_responsable = '" & (miusuario) & "'  , hora = '" & (Form_menu_principal.lbl_hora.Text) & "' WHERE `codigo_pedido`= '" & (codigo_pedido) & "' AND CODIGO_PRODUCTO = '" & (codigo_producto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()

            grilla_revision_pedidos.CurrentRow.Cells(9).Value = "EN ESPERA"
            grilla_revision_pedidos.CurrentRow.DefaultCellStyle.BackColor = Color.White
            estado = grilla_revision_pedidos.CurrentRow.Cells(9).Value

            If Combo_estado.Text <> "" And Combo_estado.Text <> "TODOS" Then
                If Combo_estado.Text <> estado Then
                    grilla_revision_pedidos.Rows.Remove(grilla_revision_pedidos.CurrentRow)
                End If
            End If

            ' busqueda()

        End If



    End Sub

    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")> _
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

    Private Sub Timer_revision_pedidos_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_revision_pedidos.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub

    Private Sub txt_codigo_pedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_pedido.TextChanged

    End Sub

    Private Sub txt_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar.TextChanged

    End Sub

    Private Sub grilla_revision_pedidos_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_revision_pedidos.Sorted

        'Dim codigo_pedido As String
        'Dim estado As String
        'Dim codigo_producto As String
        Dim prioridad As String
        Dim estado_revision As String

        For i = 0 To grilla_revision_pedidos.Rows.Count - 1
            estado_revision = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
            prioridad = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString
            If estado_revision = "ENCARGADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
            End If

            If estado_revision = "NO DISPONIBLE" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            End If

            If prioridad = "COTIZADO" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
            End If

            If prioridad = "COTIZAR" Then
                grilla_revision_pedidos.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If

        Next
    End Sub



    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click

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

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 7, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 7, FontStyle.Regular)
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
            Dim posicion_imagen As New PointF(margen_izquierdo + 840, margen_superior + 10)
            e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 75, margen_izquierdo + 1100, margen_superior + 45)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 90, margen_izquierdo + 1100, margen_superior + 60)

        e.Graphics.DrawString("PEDIDOS", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 108, margen_izquierdo + 1120, margen_superior + 108)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        e.Graphics.DrawString("DESDE", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 139)
        e.Graphics.DrawString("HASTA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 150)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 92, margen_superior + 139)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 92, margen_superior + 150)
        e.Graphics.DrawString(dtp_desde.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 102, margen_superior + 139)
        e.Graphics.DrawString(dtp_hasta.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 102, margen_superior + 150)

        e.Graphics.DrawString("COD. PEDIDO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 540, margen_superior + 139)
        e.Graphics.DrawString("VENDEDOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 540, margen_superior + 150)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 622, margen_superior + 139)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 622, margen_superior + 150)
        e.Graphics.DrawString(txt_codigo_pedido.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 632, margen_superior + 139)
        e.Graphics.DrawString(Combo_vendedor.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 632, margen_superior + 150)

        e.Graphics.DrawString("PROVEEDOR", Font_campos_superiores, Brushes.Black, margen_izquierdo + 900, margen_superior + 139)
        e.Graphics.DrawString("PRIORIDAD", Font_campos_superiores, Brushes.Black, margen_izquierdo + 900, margen_superior + 150)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 975, margen_superior + 139)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 975, margen_superior + 150)
        e.Graphics.DrawString(Combo_proveedor.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 985, margen_superior + 139)
        e.Graphics.DrawString(Combo_prioridad.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 985, margen_superior + 150)

        e.Graphics.DrawString("PEDIDO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 180)
        e.Graphics.DrawString("VENDEDOR", Font_titulo_columna, Brushes.Black, margen_izquierdo + 110, margen_superior + 180)
        e.Graphics.DrawString("COD. ITEM", Font_titulo_columna, Brushes.Black, margen_izquierdo + 280, margen_superior + 180)
        e.Graphics.DrawString("PROVEEDOR", Font_titulo_columna, Brushes.Black, margen_izquierdo + 450, margen_superior + 180)
        e.Graphics.DrawString("CANT.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 600, margen_superior + 180)
        e.Graphics.DrawString("PRIORIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 660, margen_superior + 180)
        e.Graphics.DrawString("FECHA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 750, margen_superior + 180)
        e.Graphics.DrawString("ESTADO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 840, margen_superior + 180)
        e.Graphics.DrawString("ABONO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 950, margen_superior + 180)
        e.Graphics.DrawString("LLEGADA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 1030, margen_superior + 180)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 195, margen_izquierdo + 1120, margen_superior + 195)

        Dim pedido_detalle As String
        Dim vendedor_detalle As String
        Dim codigo_detalle As String
        Dim proveedor_detalle As String
        Dim cantidad_detalle As String
        Dim prioridad_detalle As String
        Dim fecha_detalle As String
        Dim estado_detalle As String
        Dim abono_detalle As String
        Dim llegada_detalle As String

        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10

        For i = numero_lineas_total To grilla_revision_pedidos.Rows.Count - 1
            pedido_detalle = grilla_revision_pedidos.Rows(i).Cells(0).Value.ToString
            vendedor_detalle = grilla_revision_pedidos.Rows(i).Cells(1).Value.ToString
            codigo_detalle = grilla_revision_pedidos.Rows(i).Cells(2).Value.ToString
            proveedor_detalle = grilla_revision_pedidos.Rows(i).Cells(3).Value.ToString
            cantidad_detalle = grilla_revision_pedidos.Rows(i).Cells(4).Value.ToString
            prioridad_detalle = grilla_revision_pedidos.Rows(i).Cells(7).Value.ToString
            fecha_detalle = grilla_revision_pedidos.Rows(i).Cells(8).Value.ToString
            estado_detalle = grilla_revision_pedidos.Rows(i).Cells(9).Value.ToString
            abono_detalle = grilla_revision_pedidos.Rows(i).Cells(10).Value.ToString
            llegada_detalle = grilla_revision_pedidos.Rows(i).Cells(11).Value.ToString

            'If especie.Length > 13 Then
            '    especie = especie.Substring(0, 13)
            'End If

            e.Graphics.DrawString(pedido_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(vendedor_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 110, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(codigo_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 280, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(proveedor_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 450, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(cantidad_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 600, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(prioridad_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 660, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(fecha_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 750, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(estado_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 840, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(abono_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 950, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(llegada_detalle, Font_texto_impresion, Brushes.Black, margen_izquierdo + 1030, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 60 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 205 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 1120, margen_superior + 205 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 205 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 1120, margen_superior + 205 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0
    End Sub
End Class