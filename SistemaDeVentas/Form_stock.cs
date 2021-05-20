namespace proyecto_sistema_ventas
{
    class _failedMemberConversionMarker1
    {
    }
    /*#error Cannot convert ClassBlockSyntax - see comment for details
        /* Cannot convert ClassBlockSyntax, System.NullReferenceException: Referencia a objeto no establecida como instancia de un objeto.
           en ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<>c.<GetMethodWithHandles>b__50_3(HandledEvent p)
           en System.Linq.Enumerable.WhereSelectArrayIterator`2.MoveNext()
           en System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
           en System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
           en ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.<>c.<GetMethodWithHandles>b__50_1(IMethodSymbol m)
           en System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
           en System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
           en System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
           en System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
           en ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.GetMethodWithHandles(TypeBlockSyntax parentType)
           en ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMembers(SyntaxList`1 members)
           en ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.VisitClassBlock(ClassBlockSyntax node)
           en Microsoft.CodeAnalysis.VisualBasic.Syntax.ClassBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
           en Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
           en ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.WithPortedTrivia[TSource,TDest](SyntaxNode node, Func`3 portExtraTrivia)
           en ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.VisitClassBlock(ClassBlockSyntax node)
           en Microsoft.CodeAnalysis.VisualBasic.Syntax.ClassBlockSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
           en ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.NodesVisitor.ConvertMember(StatementSyntax member)

        Input: 

        Public Class Form_stock
            Dim mifecha2 As String
            Dim mifecha4 As String
            Dim numero_lineas_total As Integer = 0
            'Dim impreso As Integer = 0

            Private Sub Form_stock_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
                Form_menu_principal.WindowState = FormWindowState.Maximized
            End Sub

            Private Sub Form_stock_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
                If e.KeyCode = Keys.Escape Then
                    Me.Close()
                End If

                If e.KeyCode = Keys.F4 Then
                    Form_buscador_proveedores_stock_minimo.Show()
                    Me.Enabled = False
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

            'llenamos el comborut
            'le damos el formato al labelfecha
            Private Sub Form_stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

                'llenar_combo_rut()
                'combo_rut.Text = "TODOS"
                'lblfecha.Text = FormatDateTime(Now, DateFormat.ShortDate)
                combo_estado.SelectedItem = "TODOS"

                cargar_logo()

                dtp_fecha.Value = dtp_fecha.Value.AddDays(Val(-4))
                dtp_fecha.CustomFormat = "yyy-MM-dd"

                malla_productos()

                mostrar_malla()

                grilla_stock.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
            End Sub

            Sub cargar_logo()
                Try
                    PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
                Catch
                End Try
            End Sub

            'sub para limpiar la pantalla.
            Sub limpiar()

                txt_nombre_proveedor.Text = ""
                txt_direccion.Text = ""
                txt_telefono.Text = ""
                txt_rut_proveedor.Text = ""
                grilla_stock.DataSource = Nothing
                grilla_stock_final.Rows.Clear()

            End Sub

            'llenamos el combo rut con los datos de los proveedores.
            'Sub llenar_combo_rut()
            '    combo_rut.Items.Clear()
            '    DS2.Tables.Clear()
            '    DT2.Rows.Clear()
            '    DT2.Columns.Clear()
            '    DS2.Clear()
            '    conexion.Open()

            '    SC2.Connection = conexion
            '    SC2.CommandText = "select * from proveedores"
            '    DA2.SelectCommand = SC2
            '    DA2.Fill(DT2)
            '    DS2.Tables.Add(DT2)

            '    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            '        For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
            '            combo_rut.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("rut_proveedor"))
            '        Next
            '    End If
            '    conexion.Close()
            'End Sub

            'mostramos los datos de los proveedores.
            Sub mostrar_datos_proveedores()
                conexion.Close()
                If txt_rut_proveedor.Text <> "" Then
                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    SC.Connection = conexion
                    SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut_proveedor.Text) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    DS.Tables.Add(DT)

                    If DS.Tables(DT.TableName).Rows.Count > 0 Then
                        txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
                        txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_proveedor")
                        txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_proveedor")

                        btn_mostrar.PerformClick()
                    Else
                        MsgBox("PROVEEDOR NO ENCONTRADO", 0 + 16, "ERROR")
                        txt_rut_proveedor.Focus()
                    End If
                    conexion.Close()
                End If


            End Sub

            Sub limpiar_datos_proveedor()
                txt_nombre_proveedor.Text = ""
                txt_telefono.Text = ""
                txt_direccion.Text = ""
            End Sub

            Sub guion_rut()
                Dim rut_proveedor As String
                Dim guion As String
                rut_proveedor = txt_rut_proveedor.Text
                If rut_proveedor.Length > 2 Then

                    guion = rut_proveedor(rut_proveedor.Length - 2).ToString()

                    If guion <> "-" Then
                        Dim fin_rut As String = rut_proveedor(rut_proveedor.Length - 1).ToString()
                        rut_proveedor = Mid(rut_proveedor, 1, Len(rut_proveedor) - 1)
                        rut_proveedor = rut_proveedor & "-" & fin_rut
                        txt_rut_proveedor.Text = rut_proveedor
                    End If
                End If
            End Sub

            ''realizamos la busqueda de forma directa con el ingreso de los digitos.
            'Sub mostrar_rut()
            '    combo_rut.Items.Clear()
            '    DS.Tables.Clear()
            '    DT.Rows.Clear()
            '    DT.Columns.Clear()
            '    DS.Clear()
            '    conexion.Open()

            '    SC.Connection = conexion
            '    SC.CommandText = "select * from proveedores where rut_proveedor like '" & (combo_rut.Text & "%") & "'"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            '    DS.Tables.Add(DT)

            '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
            '        combo_rut.Items.Clear()
            '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '            combo_rut.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor"))
            '        Next
            '    End If
            '    conexion.Close()
            'End Sub

            Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

                If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End Sub

            'vemos si en la grilla debemos mostrar todas las faltas de productos o solo las de algun proveedor.
            Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

                mostrar_malla()
                mostrar_datos_proveedores()
            End Sub

            'mllamamos el mostrar rut.
            Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
                '  mostrar_rut()
            End Sub

            'malla que muestra las faltas de productos segun el proveedor.
            Sub mostrar_malla()
                conexion.Close()

                grilla_stock.DataSource = Nothing
                grilla_stock_final.Rows.Clear()

                If combo_estado.SelectedItem = "TODOS" Then

                    If txt_rut_proveedor.Text = "" Then
                        conexion.Close()
                        DS3.Tables.Clear()
                        DT3.Rows.Clear()
                        DT3.Columns.Clear()
                        DS3.Clear()
                        conexion.Open()

                        SC3.Connection = conexion
                        SC3.CommandText = "select cod_producto as  CODIGO, productos.nombre as NOMBRE, numero_tecnico As 'N. TECNICO', aplicacion as APLICACION,  cantidad as CANTIDAD, cantidad_minima as MINIMO, costo as COSTO, proveedores.nombre_proveedor as PROVEEDOR, estado_producto from productos, proveedores  where productos.proveedor=proveedores.rut_proveedor and cantidad_minima <> -99999"
                        DA3.SelectCommand = SC3
                        DA3.Fill(DT3)
                        DS3.Tables.Add(DT3)
                        grilla_stock.DataSource = DS3.Tables(DT3.TableName)
                        conexion.Close()
                    Else
                        conexion.Close()
                        DS3.Tables.Clear()
                        DT3.Rows.Clear()
                        DT3.Columns.Clear()
                        DS3.Clear()
                        conexion.Open()

                        SC3.Connection = conexion
                        SC3.CommandText = "select cod_producto as  CODIGO, productos.nombre as NOMBRE, numero_tecnico As 'N. TECNICO',  aplicacion as APLICACION,cantidad as CANTIDAD, cantidad_minima as MINIMO, costo as COSTO, proveedores.nombre_PROVEEDOR as PROVEEDOR, estado_producto from productos, proveedores  where proveedor = '" & (txt_rut_proveedor.Text) & "' AND productos.proveedor=proveedores.rut_proveedor and cantidad_minima <> -99999"
                        DA3.SelectCommand = SC3
                        DA3.Fill(DT3)
                        DS3.Tables.Add(DT3)
                        grilla_stock.DataSource = DS3.Tables(DT3.TableName)
                        conexion.Close()
                    End If

                    Dim VarCodProducto As String
                    Dim VarNombre As String
                    Dim VarAplicacion As String
                    Dim VarNtecnico As String
                    Dim VarCantidad As Integer
                    Dim VarMinimo As String
                    Dim VarCosto As String
                    Dim VarProveedor As String
                    Dim estado_producto As String

                    For i = 0 To grilla_stock.Rows.Count - 1

                        VarCodProducto = grilla_stock.Rows(i).Cells(0).Value.ToString
                        VarNombre = grilla_stock.Rows(i).Cells(1).Value.ToString
                        VarAplicacion = grilla_stock.Rows(i).Cells(2).Value.ToString
                        VarNtecnico = grilla_stock.Rows(i).Cells(3).Value.ToString
                        VarCantidad = grilla_stock.Rows(i).Cells(4).Value.ToString
                        VarMinimo = grilla_stock.Rows(i).Cells(5).Value.ToString
                        VarCosto = grilla_stock.Rows(i).Cells(6).Value.ToString
                        VarProveedor = grilla_stock.Rows(i).Cells(7).Value.ToString
                        estado_producto = grilla_stock.Rows(i).Cells(8).Value.ToString

                        If VarCantidad <= VarMinimo Then
                            grilla_stock_final.Rows.Add(VarCodProducto, VarNombre, VarAplicacion, VarNtecnico, VarCantidad, VarMinimo, VarCosto, VarProveedor, estado_producto)
                        End If
                    Next

                    For i = 0 To grilla_stock_final.Rows.Count - 1
                        estado_producto = grilla_stock_final.Rows(i).Cells(8).Value.ToString
                        If estado_producto = "ENCARGADO" Then
                            grilla_stock_final.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
                        End If
                    Next

                End If











                If combo_estado.SelectedItem = "ENCARGADO" Then

                    If txt_rut_proveedor.Text = "" Then
                        conexion.Close()
                        DS3.Tables.Clear()
                        DT3.Rows.Clear()
                        DT3.Columns.Clear()
                        DS3.Clear()
                        conexion.Open()

                        SC3.Connection = conexion
                        SC3.CommandText = "select cod_producto as  CODIGO, productos.nombre as NOMBRE,numero_tecnico As 'N. TECNICO', aplicacion as APLICACION,  cantidad as CANTIDAD, cantidad_minima as MINIMO, costo as COSTO, proveedores.nombre_proveedor as PROVEEDOR, estado_producto from productos, proveedores  where productos.proveedor=proveedores.rut_proveedor and cantidad_minima <> -99999 AND productos.estado_producto='ENCARGADO'"
                        DA3.SelectCommand = SC3
                        DA3.Fill(DT3)
                        DS3.Tables.Add(DT3)
                        grilla_stock.DataSource = DS3.Tables(DT3.TableName)
                        conexion.Close()
                    Else
                        conexion.Close()
                        DS3.Tables.Clear()
                        DT3.Rows.Clear()
                        DT3.Columns.Clear()
                        DS3.Clear()
                        conexion.Open()

                        SC3.Connection = conexion
                        SC3.CommandText = "select cod_producto as  CODIGO, productos.nombre as NOMBRE,numero_tecnico As 'N. TECNICO', aplicacion as APLICACION,  cantidad as CANTIDAD, cantidad_minima as MINIMO, costo as COSTO, proveedores.nombre_PROVEEDOR as PROVEEDOR, estado_producto from productos, proveedores  where proveedor = '" & (txt_rut_proveedor.Text) & "' and productos.proveedor=proveedores.rut_proveedor and cantidad_minima <> -99999 AND productos.estado_producto='ENCARGADO'"
                        DA3.SelectCommand = SC3
                        DA3.Fill(DT3)
                        DS3.Tables.Add(DT3)
                        grilla_stock.DataSource = DS3.Tables(DT3.TableName)
                        conexion.Close()
                    End If

                    Dim VarCodProducto As String
                    Dim VarNombre As String
                    Dim VarAplicacion As String
                    Dim VarNtecnico As String
                    Dim VarCantidad As Integer
                    Dim VarMinimo As String
                    Dim VarCosto As String
                    Dim VarProveedor As String
                    Dim estado_producto As String

                    For i = 0 To grilla_stock.Rows.Count - 1

                        VarCodProducto = grilla_stock.Rows(i).Cells(0).Value.ToString
                        VarNombre = grilla_stock.Rows(i).Cells(1).Value.ToString
                        VarAplicacion = grilla_stock.Rows(i).Cells(2).Value.ToString
                        VarNtecnico = grilla_stock.Rows(i).Cells(3).Value.ToString
                        VarCantidad = grilla_stock.Rows(i).Cells(4).Value.ToString
                        VarMinimo = grilla_stock.Rows(i).Cells(5).Value.ToString
                        VarCosto = grilla_stock.Rows(i).Cells(6).Value.ToString
                        VarProveedor = grilla_stock.Rows(i).Cells(7).Value.ToString
                        estado_producto = grilla_stock.Rows(i).Cells(8).Value.ToString

                        If VarCantidad <= VarMinimo Then
                            grilla_stock_final.Rows.Add(VarCodProducto, VarNombre, VarAplicacion, VarNtecnico, VarCantidad, VarMinimo, VarCosto, VarProveedor, estado_producto)
                        End If
                    Next

                    For i = 0 To grilla_stock_final.Rows.Count - 1
                        estado_producto = grilla_stock_final.Rows(i).Cells(8).Value.ToString
                        If estado_producto = "ENCARGADO" Then
                            grilla_stock_final.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
                        End If
                    Next

                End If






                If combo_estado.SelectedItem = "NO ENCARGADO" Then

                    If txt_rut_proveedor.Text = "" Then
                        conexion.Close()
                        DS3.Tables.Clear()
                        DT3.Rows.Clear()
                        DT3.Columns.Clear()
                        DS3.Clear()
                        conexion.Open()

                        SC3.Connection = conexion
                        SC3.CommandText = "select cod_producto as  CODIGO, productos.nombre as NOMBRE,numero_tecnico As 'N. TECNICO', aplicacion as APLICACION,  cantidad as CANTIDAD, cantidad_minima as MINIMO, costo as COSTO, proveedores.nombre_proveedor as PROVEEDOR, estado_producto from productos, proveedores  where productos.proveedor=proveedores.rut_proveedor and cantidad_minima <> -99999 AND productos.estado_producto<>'ENCARGADO'"
                        DA3.SelectCommand = SC3
                        DA3.Fill(DT3)
                        DS3.Tables.Add(DT3)
                        grilla_stock.DataSource = DS3.Tables(DT3.TableName)
                        conexion.Close()
                    Else
                        conexion.Close()
                        DS3.Tables.Clear()
                        DT3.Rows.Clear()
                        DT3.Columns.Clear()
                        DS3.Clear()
                        conexion.Open()

                        SC3.Connection = conexion
                        SC3.CommandText = "select cod_producto as  CODIGO, productos.nombre as NOMBRE,numero_tecnico As 'N. TECNICO', aplicacion as APLICACION,  cantidad as CANTIDAD, cantidad_minima as MINIMO, costo as COSTO, proveedores.nombre_PROVEEDOR as PROVEEDOR, estado_producto from productos, proveedores  where proveedor = '" & (txt_rut_proveedor.Text) & "' and productos.proveedor=proveedores.rut_proveedor and cantidad_minima <> -99999 AND productos.estado_producto<>'ENCARGADO'"
                        DA3.SelectCommand = SC3
                        DA3.Fill(DT3)
                        DS3.Tables.Add(DT3)
                        grilla_stock.DataSource = DS3.Tables(DT3.TableName)
                        conexion.Close()
                    End If

                    Dim VarCodProducto As String
                    Dim VarNombre As String
                    Dim VarAplicacion As String
                    Dim VarNtecnico As String
                    Dim VarCantidad As Integer
                    Dim VarMinimo As String
                    Dim VarCosto As String
                    Dim VarProveedor As String
                    Dim estado_producto As String

                    For i = 0 To grilla_stock.Rows.Count - 1

                        VarCodProducto = grilla_stock.Rows(i).Cells(0).Value.ToString
                        VarNombre = grilla_stock.Rows(i).Cells(1).Value.ToString
                        VarAplicacion = grilla_stock.Rows(i).Cells(2).Value.ToString
                        VarNtecnico = grilla_stock.Rows(i).Cells(3).Value.ToString
                        VarCantidad = grilla_stock.Rows(i).Cells(4).Value.ToString
                        VarMinimo = grilla_stock.Rows(i).Cells(5).Value.ToString
                        VarCosto = grilla_stock.Rows(i).Cells(6).Value.ToString
                        VarProveedor = grilla_stock.Rows(i).Cells(7).Value.ToString
                        estado_producto = grilla_stock.Rows(i).Cells(8).Value.ToString

                        If VarCantidad <= VarMinimo Then
                            grilla_stock_final.Rows.Add(VarCodProducto, VarNombre, VarAplicacion, VarNtecnico, VarCantidad, VarMinimo, VarCosto, VarProveedor, estado_producto)
                        End If
                    Next

                    For i = 0 To grilla_stock_final.Rows.Count - 1
                        estado_producto = grilla_stock_final.Rows(i).Cells(8).Value.ToString
                        If estado_producto = "ENCARGADO" Then
                            grilla_stock_final.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
                        End If
                    Next

                End If

                If grilla_stock_final.Rows.Count <> 0 Then

                    If grilla_stock_final.Columns(0).Width = 150 Then
                        grilla_stock_final.Columns(0).Width = 149
                    Else
                        grilla_stock_final.Columns(0).Width = 150
                    End If

                    grilla_stock_final.Columns(0).Width = 150
                    grilla_stock_final.Columns(1).Width = 300
                    grilla_stock_final.Columns(2).Width = 300
                    grilla_stock_final.Columns(3).Width = 200
                    grilla_stock_final.Columns(4).Width = 150
                    grilla_stock_final.Columns(5).Width = 150
                    grilla_stock_final.Columns(6).Width = 150
                    grilla_stock_final.Columns(7).Width = 300
                    grilla_stock_final.Columns(8).Width = 150
                End If
            End Sub



            'grabamos el sotck minimo para posteriormente imprimirlo.
            Sub grabar_stock_minimo()
                Dim Varcodigo As String
                Dim Varnombre As String
                Dim Varmarca As String
                Dim varnumerotecnico As String
                Dim varcantidad As String
                Dim varminima As String
                Dim varcosto As String
                Dim varproveedor As String

                For i = 0 To grilla_stock.Rows.Count - 1

                    Varcodigo = grilla_stock.Rows(i).Cells(0).Value
                    Varnombre = grilla_stock.Rows(i).Cells(1).Value
                    Varmarca = grilla_stock.Rows(i).Cells(2).Value
                    varnumerotecnico = grilla_stock.Rows(i).Cells(3).Value
                    varcantidad = grilla_stock.Rows(i).Cells(4).Value
                    varminima = grilla_stock.Rows(i).Cells(5).Value
                    varcosto = grilla_stock.Rows(i).Cells(6).Value
                    varproveedor = grilla_stock.Rows(i).Cells(7).Value

                    conexion.Close()
                    DS.Tables.Clear()
                    DT.Rows.Clear()
                    DT.Columns.Clear()
                    DS.Clear()
                    conexion.Open()

                    SC.Connection = conexion
                    SC.CommandText = "insert into stock_temporal (codigo, nombre, marca, numero_tecnico,cantidad, cantidad_minima, costo, proveedor, rut, nombre_proveedor, direccion, telefono) values('" & (Varcodigo) & "','" & (Varnombre) & "','" & (Varmarca) & "','" & (varnumerotecnico) & "','" & (varcantidad) & "','" & (varminima) & "','" & (varcosto) & "','" & (varproveedor) & "','" & (txt_rut_proveedor.Text) & "','" & (txt_nombre_proveedor.Text) & "','" & (txt_direccion.Text) & "','" & (txt_telefono.Text) & "')"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                    conexion.Close()

                Next
            End Sub

            'salimos de la pantalla.
            Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
                Form_menu_principal.WindowState = FormWindowState.Normal
                Me.Close()
            End Sub

            'limpiamos la pantalla.
            Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
                Dim valormensaje As Integer
                valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
                If valormensaje = vbYes Then
                    limpiar()
                End If
            End Sub

            Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar.Click
                If grilla_stock.Rows.Count > 0 Then
                    grilla_stock.Rows.Remove(grilla_stock.CurrentRow)
                End If
            End Sub

            Private Sub txt_rut_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_proveedor.KeyPress
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


                grilla_stock.DataSource = Nothing
                grilla_stock_final.Rows.Clear()



                If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
                    guion_rut()
                    mostrar_datos_proveedores()
                End If
            End Sub

            Private Sub txt_rut_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.GotFocus
                txt_rut_proveedor.BackColor = Color.LightSkyBlue
            End Sub

            Private Sub txt_rut_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.LostFocus
                txt_rut_proveedor.BackColor = Color.White
            End Sub

            'Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            '    btn_imprimir.BackColor = Color.LightSkyBlue
            'End Sub

            'Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            '    btn_imprimir.BackColor = Color.White
            'End Sub

            Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
                btn_limpiar.BackColor = Color.LightSkyBlue
            End Sub

            Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
                btn_limpiar.BackColor = Color.Transparent
            End Sub

            Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
                btn_salir.BackColor = Color.LightSkyBlue
            End Sub

            Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
                btn_salir.BackColor = Color.Transparent
            End Sub

            Private Sub btn_quitar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar.GotFocus
                btn_quitar.BackColor = Color.LightSkyBlue
            End Sub

            Private Sub btn_quitar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar.LostFocus
                btn_quitar.BackColor = Color.Transparent
            End Sub


            Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
                btn_buscar.BackColor = Color.LightSkyBlue
            End Sub

            Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
                btn_buscar.BackColor = Color.Transparent
            End Sub

            Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
                btn_mostrar.BackColor = Color.LightSkyBlue
            End Sub

            Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
                btn_mostrar.BackColor = Color.Transparent
            End Sub

            Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
                btn_exportar_excel.BackColor = Color.LightSkyBlue
            End Sub

            Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
                btn_exportar_excel.BackColor = Color.Transparent
            End Sub

            Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
                btn_imprimir.BackColor = Color.LightSkyBlue
            End Sub

            Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
                btn_imprimir.BackColor = Color.Transparent
            End Sub

            Private Sub txt_rut_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.TextChanged
                limpiar_datos_proveedor()
            End Sub

            Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
                Dim mensaje As String = ""



                If grilla_stock_final.Rows.Count = 0 Then
                    mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
                    txt_rut_proveedor.Focus()
                    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If

                Dim save As New SaveFileDialog
                save.Filter = "Archivo Excel | *.xlsx"
                If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Exportar_Excel(Me.grilla_stock_final, save.FileName)
                End If


            End Sub


            Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

                Dim xlApp As Object = CreateObject("Excel.Application")
                'crear una nueva hoja de calculo 
                Dim xlWB As Object = xlApp.WorkBooks.add
                Dim xlWS As Object = xlWB.WorkSheets(1)

                'exportamos los caracteres de las columnas 
                For c As Integer = 0 To grilla_stock_final.Columns.Count - 1
                    xlWS.cells(1, c + 1).value = grilla_stock_final.Columns(c).HeaderText
                Next
                'exportamos las cabeceras de columnas 
                For r As Integer = 0 To grilla_stock_final.RowCount - 1
                    For c As Integer = 0 To grilla_stock_final.Columns.Count - 1
                        xlWS.cells(r + 2, c + 1).value = grilla_stock_final.Item(c, r).Value
                    Next
                Next
                'guardamos la hoja de calculo en la ruta especificada 
                xlWB.saveas(pth)
                xlWS = Nothing
                xlWB = Nothing
                xlApp.quit()
                xlApp = Nothing
            End Sub

            Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

            End Sub



            Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
                lbl_mensaje.Visible = True
                Me.Enabled = False
                grilla_stock.DataSource = Nothing
                grilla_stock_final.Rows.Clear()
                mostrar_malla()

                lbl_mensaje.Visible = False
                Me.Enabled = True
            End Sub

            Private Sub grilla_stock_final_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_stock_final.CellContentClick

            End Sub

            Private Sub grilla_stock_final_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_stock_final.DoubleClick
                If grilla_stock_final.Rows.Count = 0 Then
                    Exit Sub
                End If

                'If grilla_revision_pedidos.CurrentRow.Cells(2).Selected Then
                '    Exit Sub
                'End If

                Dim estado_producto As String
                Dim codigo_producto As String

                codigo_producto = grilla_stock_final.CurrentRow.Cells(0).Value
                estado_producto = grilla_stock_final.CurrentRow.Cells(8).Value



                If estado_producto = "ENCARGADO" Then

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE PRODUCTOS SET estado_producto='-' WHERE COD_PRODUCTO = '" & (codigo_producto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    Dim estado As String

                    grilla_stock_final.CurrentRow.Cells(8).Value = "-"
                    grilla_stock_final.CurrentRow.DefaultCellStyle.BackColor = Color.White
                    estado = grilla_stock_final.CurrentRow.Cells(8).Value

                    If combo_estado.Text <> "" And combo_estado.Text <> "TODOS" Then
                        If combo_estado.Text <> estado Then
                            grilla_stock_final.Rows.Remove(grilla_stock_final.CurrentRow)
                        End If
                    End If

                    '  mostrar_malla()

                Else

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE PRODUCTOS SET estado_producto='ENCARGADO', fecha_pedido='" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE COD_PRODUCTO = '" & (codigo_producto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                    Dim estado As String

                    grilla_stock_final.CurrentRow.Cells(8).Value = "ENCARGADO"
                    grilla_stock_final.CurrentRow.DefaultCellStyle.BackColor = Color.SkyBlue

                    estado = grilla_stock_final.CurrentRow.Cells(8).Value

                    If combo_estado.Text <> "" And combo_estado.Text <> "TODOS" Then
                        If combo_estado.Text <> estado Then
                            grilla_stock_final.Rows.Remove(grilla_stock_final.CurrentRow)
                        End If
                    End If


                    ' mostrar_malla()
                End If


            End Sub

            Private Sub combo_estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_estado.SelectedIndexChanged
                grilla_stock.DataSource = Nothing
                grilla_stock_final.Rows.Clear()
            End Sub

            Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
                Form_buscador_proveedores_stock_minimo.Show()
                Me.Enabled = False
            End Sub



            Sub malla_productos()
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where fecha_pedido <= '" & (dtp_fecha.Text) & "' AND ESTADO_PRODUCTO='ENCARGADO'"
                DA.SelectCommand = SC

                DA.Fill(DT)
                DS.Tables.Add(DT)

                grilla_productos.DataSource = DS.Tables(DT.TableName)
                conexion.Close()

                Dim codigo_producto As String

                For i = 0 To grilla_productos.Rows.Count - 1

                    codigo_producto = grilla_productos.Rows(i).Cells(0).Value.ToString

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE PRODUCTOS SET estado_producto='-' WHERE COD_PRODUCTO = '" & (codigo_producto) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                Next

            End Sub

            Private Sub btn_imprimir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
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

                Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 75, margen_izquierdo + 780, margen_superior + 45)
                Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 780, margen_superior + 60)

                e.Graphics.DrawString("STOCK MINIMO", Font_titulo, Brushes.Black, rect1, stringFormat)
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 108, margen_izquierdo + 810, margen_superior + 108)
                e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

                e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 139)
                e.Graphics.DrawString("TELEFONO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 10, margen_superior + 150)
                e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 70, margen_superior + 139)
                e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 70, margen_superior + 150)
                e.Graphics.DrawString(txt_rut_proveedor.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 80, margen_superior + 139)
                e.Graphics.DrawString(txt_telefono.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 80, margen_superior + 150)

                e.Graphics.DrawString("NOMBRE", Font_campos_superiores, Brushes.Black, margen_izquierdo + 360, margen_superior + 139)
                e.Graphics.DrawString("DIRECCION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 360, margen_superior + 150)
                e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 430, margen_superior + 139)
                e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 430, margen_superior + 150)
                e.Graphics.DrawString(txt_nombre_proveedor.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 440, margen_superior + 139)
                e.Graphics.DrawString(txt_direccion.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 440, margen_superior + 150)

                e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 10, margen_superior + 180)
                e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 60, margen_superior + 180)
                e.Graphics.DrawString("MARCA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 225, margen_superior + 180)
                e.Graphics.DrawString("NRO. TECNICO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 330, margen_superior + 180)
                e.Graphics.DrawString("CANT.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 535, margen_superior + 180, format1)
                e.Graphics.DrawString("MIN.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 585, margen_superior + 180, format1)
                e.Graphics.DrawString("COSTO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 645, margen_superior + 180, format1)
                e.Graphics.DrawString("PROVEEDOR", Font_titulo_columna, Brushes.Black, margen_izquierdo + 660, margen_superior + 180)

                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 195, margen_izquierdo + 810, margen_superior + 195)

                Dim Varcodigo As String
                Dim Varnombre As String
                Dim Varmarca As String
                Dim varnumerotecnico As String
                Dim varcantidad As String
                Dim varminima As String
                Dim varcosto As String
                Dim varproveedor As String

                Dim numero_lineas As Integer = 0
                Dim multiplicador_lineas As Integer = 10

                For i = numero_lineas_total To grilla_stock.Rows.Count - 1

                    Varcodigo = grilla_stock.Rows(i).Cells(0).Value
                    Varnombre = grilla_stock.Rows(i).Cells(1).Value
                    Varmarca = grilla_stock.Rows(i).Cells(2).Value
                    varnumerotecnico = grilla_stock.Rows(i).Cells(3).Value
                    varcantidad = grilla_stock.Rows(i).Cells(4).Value
                    varminima = grilla_stock.Rows(i).Cells(5).Value
                    varcosto = grilla_stock.Rows(i).Cells(6).Value
                    varproveedor = grilla_stock.Rows(i).Cells(7).Value

                    If varcosto = "" Or varcosto = "0" Then
                        varcosto = "0"
                    Else
                        varcosto = Format(Int(varcosto), "###,###,###")
                    End If

                    If Varnombre.Length > 25 Then
                        Varnombre = Varnombre.Substring(0, 25)
                    End If

                    If Varmarca.Length > 15 Then
                        Varmarca = Varmarca.Substring(0, 15)
                    End If

                    If varproveedor.Length > 25 Then
                        varproveedor = varproveedor.Substring(0, 25)
                    End If

                    If varnumerotecnico.Length > 25 Then
                        varnumerotecnico = varnumerotecnico.Substring(0, 25)
                    End If

                    e.Graphics.DrawString(Varcodigo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 10, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
                    '***************************************************************************************************************************************************

                    e.Graphics.DrawString(Varnombre, Font_texto_impresion, Brushes.Black, margen_izquierdo + 60, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
                    '***************************************************************************************************************************************************

                    e.Graphics.DrawString(Varmarca, Font_texto_impresion, Brushes.Black, margen_izquierdo + 225, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
                    '***************************************************************************************************************************************************

                    e.Graphics.DrawString(varnumerotecnico, Font_texto_impresion, Brushes.Black, margen_izquierdo + 330, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
                    '***************************************************************************************************************************************************

                    e.Graphics.DrawString(varcantidad, Font_texto_impresion, Brushes.Black, margen_izquierdo + 535, margen_superior + 200 + (numero_lineas * multiplicador_lineas), format1)
                    '***************************************************************************************************************************************************

                    e.Graphics.DrawString(varminima, Font_texto_impresion, Brushes.Black, margen_izquierdo + 585, margen_superior + 200 + (numero_lineas * multiplicador_lineas), format1)
                    '***************************************************************************************************************************************************

                    e.Graphics.DrawString(varcosto, Font_texto_impresion, Brushes.Black, margen_izquierdo + 645, margen_superior + 200 + (numero_lineas * multiplicador_lineas), format1)
                    '***************************************************************************************************************************************************

                    e.Graphics.DrawString(varproveedor, Font_texto_impresion, Brushes.Black, margen_izquierdo + 660, margen_superior + 200 + (numero_lineas * multiplicador_lineas))
                    '***************************************************************************************************************************************************

                    numero_lineas = numero_lineas + 1
                    numero_lineas_total = numero_lineas_total + 1

                    If numero_lineas > 80 Then
                        'Linea horizontal
                        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 205 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 205 + (numero_lineas * multiplicador_lineas))
                        '***************************************************************************************************************************************************
                        e.HasMorePages = True ' Todavia faltan mas paginas
                        Exit Sub
                    Else
                        e.HasMorePages = False
                    End If
                Next

                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 10, margen_superior + 205 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 810, margen_superior + 205 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                numero_lineas_total = 0
            End Sub
        End Class
         */
}
