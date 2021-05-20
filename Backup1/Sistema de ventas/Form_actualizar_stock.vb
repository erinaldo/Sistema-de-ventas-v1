Imports System.IO
Public Class Form_actualizar_stock

    Private Sub Form_actualizar_productos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_actualizar_productos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp



















        'If e.KeyCode = Keys.Enter Then
        '    Select Case grilla_stock.CurrentCell.ColumnIndex
        '        Case 0
        '            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)



        '        Case 1
        '            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)
        '        Case 2
        '            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)
        '        Case 3
        '            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)
        '        Case 4
        '            Dim codigo As String
        '            Dim stock_fisico As String
        '            codigo = grilla_stock.CurrentRow.Cells(0).Value
        '            stock_fisico = grilla_stock.CurrentRow.Cells(4).Value

        '            If stock_fisico <> 0 Then
        '                SC.Connection = conexion
        '                SC.CommandText = "UPDATE productos SET stock_fisico='" & (stock_fisico) & "' where cod_producto = " & (codigo) & ""
        '                DA.SelectCommand = SC
        '                DA.Fill(DT)
        '            End If
        '            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)
        '        Case 5
        '            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)
        '        Case 6
        '            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)
        '        Case 7
        '            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)
        '        Case 8
        '            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)
        '        Case 9
        '    End Select
        '    e.SuppressKeyPress = True
        'End If
    End Sub

    Private Sub Form_actualizar_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cargar_logo()

        grilla_stock.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        Combo_descripcion.SelectedItem = "CONTIENE"
        Combo_aplicacion.SelectedItem = "CONTIENE"
        Combo_numero_tecnico.SelectedItem = "CONTIENE"
        Combo_proveedor.SelectedItem = "CONTIENE"


        grilla_stock.Columns(0).Width = 80
        grilla_stock.Columns(1).Width = 267
        grilla_stock.Columns(2).Width = 200
        grilla_stock.Columns(3).Width = 200
        grilla_stock.Columns(4).Width = 100
        grilla_stock.Columns(5).Width = 100
        grilla_stock.Columns(6).Width = 100
        grilla_stock.Columns(7).Width = 200
        grilla_stock.Columns(8).Width = 130
        grilla_stock.Columns(9).Width = 130
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub Form_actualizar_productos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub GroupBox_tipo_venta_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox_tipo_venta.Enter

    End Sub

    Sub buscar()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim consulta_busqueda As String
        ' Dim fin_consulta As String
        consulta_busqueda = ""


        If Combo_descripcion.Text <> "-" And txt_descripcion.Text <> "" Then

            If Combo_descripcion.Text = "COMIENZA POR" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE like '" & (txt_descripcion.Text) & "%" & "'"
            End If

            If Combo_descripcion.Text = "NO COMIENZA POR" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE not like '" & (txt_descripcion.Text) & "%" & "'"
            End If

            If Combo_descripcion.Text = "TERMINA CON" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE like '" & "%" & (txt_descripcion.Text) & "'"
            End If

            If Combo_descripcion.Text = "NO TERMINA CON" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE not like '" & "%" & (txt_descripcion.Text) & "'"
            End If


            If Combo_descripcion.Text = "CONTIENE" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE like '" & "%" & (txt_descripcion.Text) & "%" & "'"
            End If

            If Combo_descripcion.Text = "NO CONTIENE" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE not like '" & "%" & (txt_descripcion.Text) & "%" & "'"
            End If

        End If

















        If Combo_numero_tecnico.Text <> "-" And txt_numero_tecnico.Text <> "" Then

            If Combo_numero_tecnico.Text = "COMIENZA POR" Then
                consulta_busqueda = consulta_busqueda & " and NUMERO_TECNICO like '" & (txt_numero_tecnico.Text) & "%" & "'"
            End If

            If Combo_numero_tecnico.Text = "NO COMIENZA POR" Then
                consulta_busqueda = consulta_busqueda & " and NUMERO_TECNICO not like '" & (txt_numero_tecnico.Text) & "%" & "'"
            End If

            If Combo_numero_tecnico.Text = "TERMINA CON" Then
                consulta_busqueda = consulta_busqueda & " and NUMERO_TECNICO like '" & "%" & (txt_numero_tecnico.Text) & "'"
            End If

            If Combo_numero_tecnico.Text = "NO TERMINA CON" Then
                consulta_busqueda = consulta_busqueda & " and NUMERO_TECNICO not like '" & "%" & (txt_numero_tecnico.Text) & "'"
            End If

            If Combo_numero_tecnico.Text = "CONTIENE" Then
                consulta_busqueda = consulta_busqueda & " and NUMERO_TECNICO like '" & "%" & (txt_numero_tecnico.Text) & "%" & "'"
            End If

            If Combo_numero_tecnico.Text = "NO CONTIENE" Then
                consulta_busqueda = consulta_busqueda & " and NUMERO_TECNICO not like '" & "%" & (txt_numero_tecnico.Text) & "%" & "'"
            End If
        End If









        If Combo_aplicacion.Text <> "-" And txt_aplicacion.Text <> "" Then

            If Combo_aplicacion.Text = "COMIENZA POR" Then
                consulta_busqueda = consulta_busqueda & " and APLICACION like '" & (txt_aplicacion.Text) & "%" & "'"
            End If

            If Combo_aplicacion.Text = "NO COMIENZA POR" Then
                consulta_busqueda = consulta_busqueda & " and APLICACION not like '" & (txt_aplicacion.Text) & "%" & "'"
            End If

            If Combo_aplicacion.Text = "TERMINA CON" Then
                consulta_busqueda = consulta_busqueda & " and APLICACION like '" & "%" & (txt_aplicacion.Text) & "'"
            End If

            If Combo_aplicacion.Text = "NO TERMINA CON" Then
                consulta_busqueda = consulta_busqueda & " and APLICACION not like '" & "%" & (txt_aplicacion.Text) & "'"
            End If

            If Combo_aplicacion.Text = "CONTIENE" Then
                consulta_busqueda = consulta_busqueda & " and APLICACION like '" & "%" & (txt_aplicacion.Text) & "%" & "'"
            End If

            If Combo_aplicacion.Text = "NO CONTIENE" Then
                consulta_busqueda = consulta_busqueda & " and APLICACION not like '" & "%" & (txt_aplicacion.Text) & "%" & "'"
            End If

        End If









        If Combo_proveedor.Text <> "-" And txt_proveedor.Text <> "" Then

            If Combo_proveedor.Text = "COMIENZA POR" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE_PROVEEDOR like '" & (txt_proveedor.Text) & "%" & "'"
            End If

            If Combo_proveedor.Text = "NO COMIENZA POR" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE_PROVEEDOR not like '" & (txt_proveedor.Text) & "%" & "'"
            End If

            If Combo_proveedor.Text = "TERMINA CON" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE_PROVEEDOR like '" & "%" & (txt_proveedor.Text) & "'"
            End If

            If Combo_proveedor.Text = "NO TERMINA CON" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE_PROVEEDOR not like '" & "%" & (txt_proveedor.Text) & "'"
            End If

            If Combo_proveedor.Text = "CONTIENE" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE_PROVEEDOR like '" & "%" & (txt_proveedor.Text) & "%" & "'"
            End If

            If Combo_proveedor.Text = "NO CONTIENE" Then
                consulta_busqueda = consulta_busqueda & " and NOMBRE_PROVEEDOR not like '" & "%" & (txt_proveedor.Text) & "%" & "'"
            End If

        End If






        If txt_busqueda.Text <> "" Then

            ' consulta_busqueda = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', productos.ULTIMA_COMPRA AS 'ULTIMA COMPRA', productos.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA' from productos, proveedores where proveedores.rut_proveedor=productos.proveedor "
            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_busqueda.Text
            '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")

            For n = 0 To UBound(tabla, 1)
                consulta_busqueda = consulta_busqueda & " AND CONCAT_WS(' ',COD_PRODUCTO, NOMBRE, APLICACION, NUMERO_TECNICO, nombre_proveedor) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next

        End If


        grilla_buscador_productos.DataSource = Nothing



        If consulta_busqueda = "" Then
            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If



        Dim DT As New DataTable

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', stock_fisico as stock,cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', productos.ULTIMA_COMPRA AS 'ULTIMA COMPRA', productos.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA' from productos, proveedores where proveedores.rut_proveedor=productos.proveedor " & consulta_busqueda
        DA.SelectCommand = SC

        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_buscador_productos.DataSource = DS.Tables(DT.TableName)
        conexion.Close()


        grilla_buscador_productos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_buscador_productos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_buscador_productos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        lbl_resultado.Visible = True

        lbl_resultado.Text = "SE ENCONTRARON " & grilla_buscador_productos.Rows.Count & " RESULTADOS"

        If grilla_buscador_productos.Rows.Count = 0 Then
            lbl_resultado.ForeColor = Color.Red
            lbl_resultado.Text = "NO SE ENCONTRARON RESULTADOS"
        ElseIf grilla_buscador_productos.Rows.Count = 1 Then
            lbl_resultado.Text = "SE ENCONTRO 1 RESULTADO"
            lbl_resultado.ForeColor = Color.Black
        Else
            lbl_resultado.ForeColor = Color.Black
        End If


        'lbl_resultado.Location = New Point(1024 - lbl_resultado.Width - 7, 30)

        lbl_mensaje.Visible = False
        Me.Enabled = True

        If grilla_buscador_productos.Rows.Count > 0 Then
            grilla_buscador_productos.Focus()
        End If

        Exit Sub

        lbl_mensaje.Visible = False
        Me.Enabled = True



        ' Me.Enabled = True
        grilla_buscador_productos.Focus()
        Exit Sub
    End Sub


    Sub traspasar_datos()
        Dim VarCodProducto As String
        Dim VarDescripcion As String
        Dim VarNumeroTecnico As String
        Dim VarAplicacion As String
        Dim VarStockFisico As String
        Dim VarStockPc As String
        Dim VarPrecio As String
        Dim VarProveedor As String
        Dim VarUltimaCompra As String
        Dim VarCantUltimaCompra As String


        grilla_stock.Rows.Clear()



        If grilla_buscador_productos.Rows.Count = 0 Then
            Exit Sub
        End If

        For i = 0 To grilla_buscador_productos.Rows.Count - 1

            VarCodProducto = grilla_buscador_productos.Rows(i).Cells(0).Value.ToString
            VarDescripcion = grilla_buscador_productos.Rows(i).Cells(1).Value.ToString
            VarNumeroTecnico = grilla_buscador_productos.Rows(i).Cells(2).Value.ToString
            VarAplicacion = grilla_buscador_productos.Rows(i).Cells(3).Value.ToString
            VarStockFisico = grilla_buscador_productos.Rows(i).Cells(4).Value.ToString
            VarStockPc = grilla_buscador_productos.Rows(i).Cells(5).Value.ToString
            VarPrecio = grilla_buscador_productos.Rows(i).Cells(6).Value.ToString
            VarProveedor = grilla_buscador_productos.Rows(i).Cells(7).Value.ToString
            VarUltimaCompra = grilla_buscador_productos.Rows(i).Cells(8).Value.ToString
            VarCantUltimaCompra = grilla_buscador_productos.Rows(i).Cells(9).Value.ToString

            ' VarStockFisico = ""
            grilla_stock.Rows.Add(VarCodProducto, VarDescripcion, VarNumeroTecnico, VarAplicacion, VarStockFisico, VarStockFisico, VarStockPc, VarPrecio, VarProveedor, VarUltimaCompra, VarCantUltimaCompra)

        Next


        grilla_stock.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_stock.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_stock.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_stock.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_stock.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_stock.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_stock.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_stock.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_stock.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_stock.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_stock.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_stock.Columns(0).ReadOnly = True
        grilla_stock.Columns(1).ReadOnly = True
        grilla_stock.Columns(2).ReadOnly = True
        grilla_stock.Columns(3).ReadOnly = True
        grilla_stock.Columns(4).ReadOnly = False
        grilla_stock.Columns(5).ReadOnly = True
        grilla_stock.Columns(6).ReadOnly = True
        grilla_stock.Columns(7).ReadOnly = True
        grilla_stock.Columns(8).ReadOnly = True
        grilla_stock.Columns(9).ReadOnly = True
        grilla_stock.Columns(10).ReadOnly = True

        grilla_stock.Columns(5).Visible = False


        If grilla_stock.Rows.Count <> 0 Then
            Dim Columna As Integer = 4, Fila As Integer = 1
            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, 0)
            grilla_stock.Focus()
        End If

        'grilla_stock.Columns("CODIGO").ReadOnly = False
        'grilla_stock.Columns("DESCRIPCION").ReadOnly = False
        'grilla_stock.Columns("NUMERO TECNICO").ReadOnly = False
        'grilla_stock.Columns("APLICACION").ReadOnly = False
        'grilla_stock.Columns("STOCK FISICO").ReadOnly = True
        'grilla_stock.Columns("STOCK PC").ReadOnly = False
        'grilla_stock.Columns("PRECIO").ReadOnly = False
        'grilla_stock.Columns("PROVEEDOR").ReadOnly = False
        'grilla_stock.Columns("ULT. COMP.").ReadOnly = False
        'grilla_stock.Columns("CANT.ULT. COMP.").ReadOnly = False
    End Sub


    Private Sub txt_descripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descripcion.KeyPress
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

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            TextBoxuno.Text = "1"


            btn_buscar.PerformClick()



        End If
    End Sub


    Private Sub txt_numero_tecnico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_tecnico.KeyPress
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

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            TextBoxuno.Text = "1"


            btn_buscar.PerformClick()


        End If
    End Sub



    Private Sub txt_aplicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_aplicacion.KeyPress
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

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            TextBoxuno.Text = "1"


            btn_buscar.PerformClick()


        End If
    End Sub



    Private Sub txt_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_proveedor.KeyPress
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

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            TextBoxuno.Text = "1"


            btn_buscar.PerformClick()


        End If
    End Sub

    Private Sub txt_descripcion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descripcion.LostFocus
        txt_descripcion.BackColor = Color.White
    End Sub

    Private Sub txt_descripcion_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descripcion.GotFocus
        txt_descripcion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_numero_tecnico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.LostFocus
        txt_numero_tecnico.BackColor = Color.White
    End Sub

    Private Sub txt_numero_tecnico_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.GotFocus
        txt_numero_tecnico.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_aplicacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_aplicacion.LostFocus
        txt_aplicacion.BackColor = Color.White
    End Sub

    Private Sub txt_aplicacion_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_aplicacion.GotFocus
        txt_aplicacion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_proveedor.LostFocus
        txt_proveedor.BackColor = Color.White
    End Sub

    Private Sub txt_proveedor_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_proveedor.GotFocus
        txt_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_busqueda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_busqueda.KeyPress
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

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            TextBoxuno.Text = "1"


            btn_buscar.PerformClick()


        End If
    End Sub

    Private Sub txt_busqueda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.LostFocus
        txt_busqueda.BackColor = Color.White
    End Sub

    Private Sub txt_busqueda_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.GotFocus
        txt_busqueda.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        buscar()
        traspasar_datos()

        'If grilla_stock.Rows.Count <> 0 Then
        '    Dim Columna As Integer = 4, Fila As Integer = 1
        '    Me.grilla_stock.CurrentCell = Me.grilla_stock(4, 0)
        '    grilla_stock.Focus()
        'End If

        'lbl_resultado.Location = New Point(1024 - lbl_resultado.Width - 7, 30)
    End Sub

    Private Sub Combo_descripcion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_descripcion.SelectedIndexChanged
        If Combo_descripcion.SelectedItem = "-" Then
            txt_descripcion.Text = ""
            txt_descripcion.Enabled = False
        Else
            txt_descripcion.Enabled = True
            txt_descripcion.Focus()
        End If
    End Sub

    Private Sub txt_descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descripcion.TextChanged
    End Sub









    Private Sub Combo_descripcion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_descripcion.LostFocus
        Combo_descripcion.BackColor = Color.White
    End Sub

    Private Sub Combo_descripcion_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_descripcion.GotFocus
        Combo_descripcion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_numero_tecnico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_numero_tecnico.LostFocus
        Combo_numero_tecnico.BackColor = Color.White
    End Sub

    Private Sub Combo_numero_tecnico_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_numero_tecnico.GotFocus
        Combo_numero_tecnico.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_aplicacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_aplicacion.LostFocus
        Combo_aplicacion.BackColor = Color.White
    End Sub

    Private Sub Combo_aplicacion_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_aplicacion.GotFocus
        Combo_aplicacion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_proveedor.LostFocus
        Combo_proveedor.BackColor = Color.White
    End Sub

    Private Sub Combo_proveedor_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_proveedor.GotFocus
        Combo_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_busqueda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_busqueda.LostFocus
        txt_busqueda.BackColor = Color.White
    End Sub

    Private Sub grilla_stock_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_stock.CellContentClick

    End Sub

    Private Sub grilla_stock_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_stock.CellValueChanged
        If grilla_stock.Rows.Count = 0 Then
            Exit Sub
        End If




        Dim codigo As String
        Dim stock_fisico As String
        Dim stock_fisico_real As String

        codigo = grilla_stock.CurrentRow.Cells(0).Value
        stock_fisico = grilla_stock.CurrentRow.Cells(4).Value
        stock_fisico_real = grilla_stock.CurrentRow.Cells(5).Value

        If stock_fisico <> stock_fisico_real Then
            SC.Connection = conexion
            SC.CommandText = "UPDATE productos SET stock_fisico='" & (stock_fisico) & "' where cod_producto = " & (codigo) & ""
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

    End Sub

    Private Sub grilla_stock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_stock.Click
        If grilla_stock.Rows.Count = 0 Then
            Exit Sub
        End If


        If grilla_stock.CurrentCell.ColumnIndex <> 4 Then
            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)
        End If


    End Sub



    Private Sub grilla_stock_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_stock.DoubleClick



        If grilla_stock.CurrentCell.ColumnIndex <> 4 Then
            Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex)
        End If


    End Sub

    Private Sub grilla_stock_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grilla_stock.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)

        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress


        TextBoxuno.Text = "2"

    End Sub


    Private Sub validar_Keypress( _
       ByVal sender As Object, _
       ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna  
        Dim columna As Integer = grilla_stock.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna 1 o 3  
        If columna = 1 Or columna = 4 Then

            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' comprobar si el caracter es un número o el retroceso  
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar  
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub



    Private Sub grilla_stock_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla_stock.KeyUp

        'If grilla_stock.Rows.Count = 0 Then
        '    Exit Sub
        'End If



        'If TextBox1.Text = "1" Then
        '    Exit Sub
        'End If




        'If e.KeyCode = Keys.Enter Then
        '    'Select Case grilla_stock.CurrentCell.ColumnIndex
        '    '    Case 0
        '    '        Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex - 1)
        '    '    Case 4
        '    Me.grilla_stock.CurrentCell = grilla_stock(4, grilla_stock.CurrentCell.RowIndex - 1)

        '    Dim codigo As String
        '    Dim stock_fisico As String
        '    codigo = grilla_stock.CurrentRow.Cells(0).Value
        '    stock_fisico = grilla_stock.CurrentRow.Cells(4).Value

        '    If stock_fisico <> 0 Then
        '        SC.Connection = conexion
        '        SC.CommandText = "UPDATE productos SET stock_fisico='" & (stock_fisico) & "' where cod_producto = " & (codigo) & ""
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    End If

        '    Me.grilla_stock.CurrentCell = Me.grilla_stock(4, Me.grilla_stock.CurrentCell.RowIndex + 1)

        '    ' End Select
        '    e.SuppressKeyPress = True
        'End If






    End Sub

    Private Sub grilla_stock_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles grilla_stock.Layout

    End Sub


    Private Sub grilla_stock_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_stock.TabStopChanged

        '  Dim posicicion As String



        If grilla_stock.CurrentRow.Cells(4).Selected = False Then
            grilla_stock.CurrentRow.Cells(4).Selected = True
        End If
    End Sub

    Private Sub Combo_numero_tecnico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_numero_tecnico.SelectedIndexChanged
        If Combo_numero_tecnico.SelectedItem = "-" Then
            txt_numero_tecnico.Text = ""
            txt_numero_tecnico.Enabled = False
        Else
            txt_numero_tecnico.Enabled = True
            txt_numero_tecnico.Focus()
        End If
    End Sub

    Private Sub Combo_aplicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_aplicacion.SelectedIndexChanged
        If Combo_aplicacion.SelectedItem = "-" Then
            txt_aplicacion.Text = ""
            txt_aplicacion.Enabled = False
        Else
            txt_aplicacion.Enabled = True
            txt_aplicacion.Focus()
        End If
    End Sub

    Private Sub Combo_proveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_proveedor.SelectedIndexChanged
        If Combo_proveedor.SelectedItem = "-" Then
            txt_proveedor.Text = ""
            txt_proveedor.Enabled = False
        Else
            txt_proveedor.Enabled = True
            txt_proveedor.Focus()
        End If
    End Sub

    Private Sub txt_numero_tecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.TextChanged

    End Sub

    Private Sub txt_aplicacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_aplicacion.TextChanged

    End Sub

    Private Sub txt_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_proveedor.TextChanged

    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged

    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub
End Class