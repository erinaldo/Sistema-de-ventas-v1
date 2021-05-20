Public Class Form_productos_repetidos_kardex
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim NroDocKardex As String
    Dim TipoDocKardex As String
    Private Sub Form_productos_repetidos_kardex_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_productos_repetidos_kardex_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_productos_repetidos_kardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        mostrar_documentos_repetidos()
        txt_total_documentos.Text = grilla_documentos.Rows.Count
        grilla_documentos.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        grilla_productos.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        combo_venta.SelectedItem = "-"
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

    Sub mostrar_documentos_repetidos()
        grilla_documentos.Rows.Clear()

        If combo_venta.Text = "KARDEX" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "SELECT tipo, n_total, fecha, cod_producto, COUNT(*) Total_productos FROM `detalle_total` where movimiento <> 'AJUSTE' and movimiento = 'SALE' GROUP BY tipo, n_total, cod_producto HAVING COUNT(*) > 1"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_total"), _
                                                 mifecha_emision2, _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("Total_productos"))
                Next
            End If
        End If

        If combo_venta.Text = "COMPRA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "SELECT n_compra, cod_producto, COUNT(*) Total_productos FROM `detalle_compra` GROUP BY n_compra, rut_proveedor, cod_producto HAVING COUNT(*) > 1"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    'Dim MiFechaEmision As Date
                    'Dim mifecha_emision2 As String
                    'MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    'mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("COMPRA", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_compra"), _
                                                 "", _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("Total_productos"))
                Next
            End If
        End If

        If combo_venta.Text = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "SELECT n_boleta, cod_producto, COUNT(*) Total_productos FROM `detalle_boleta` GROUP BY n_boleta, cod_producto HAVING COUNT(*) > 1"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    'Dim MiFechaEmision As Date
                    'Dim mifecha_emision2 As String
                    'MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    'mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("BOLETA", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_boleta"), _
                                                 "", _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("Total_productos"))
                Next
            End If
        End If

        If combo_venta.Text = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "SELECT n_factura, cod_producto, COUNT(*) Total_productos FROM `detalle_factura` GROUP BY n_factura, cod_producto HAVING COUNT(*) > 1"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    'Dim MiFechaEmision As Date
                    'Dim mifecha_emision2 As String
                    'MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    'mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("FACTURA", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_factura"), _
                                                 "", _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("Total_productos"))
                Next
            End If
        End If

        If combo_venta.Text = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "SELECT n_guia, cod_producto, COUNT(*) Total_productos FROM `detalle_guia` GROUP BY n_guia, cod_producto HAVING COUNT(*) > 1"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    'Dim MiFechaEmision As Date
                    'Dim mifecha_emision2 As String
                    'MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    'mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("GUIA", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_guia"), _
                                                 "", _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("Total_productos"))
                Next
            End If
        End If

        If combo_venta.Text = "NOTA DE DEBITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "SELECT n_nota_debito, cod_producto, COUNT(*) Total_productos FROM `detalle_nota_debito` GROUP BY n_nota_debito, cod_producto HAVING COUNT(*) > 1"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    'Dim MiFechaEmision As Date
                    'Dim mifecha_emision2 As String
                    'MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    'mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("NOTA DE DEBITO", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_nota_debito"), _
                                                 "", _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("Total_productos"))
                Next
            End If
        End If

        If combo_venta.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "SELECT n_nota_credito, cod_producto, COUNT(*) Total_productos FROM `detalle_nota_credito` GROUP BY n_nota_credito, cod_producto HAVING COUNT(*) > 1"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    'Dim MiFechaEmision As Date
                    'Dim mifecha_emision2 As String
                    'MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    'mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                    grilla_documentos.Rows.Add("NOTA DE CREDITO", _
                                                DS.Tables(DT.TableName).Rows(i).Item("n_nota_credito"), _
                                                 "", _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("Total_productos"))
                Next
            End If
        End If

        grilla_documentos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documentos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documentos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documentos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documentos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documentos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If grilla_documentos.Rows.Count <> 0 Then
            If grilla_documentos.Columns(0).Width = 160 Then
                grilla_documentos.Columns(0).Width = 159
            Else
                grilla_documentos.Columns(0).Width = 160
            End If
        End If

        grilla_documentos.Columns(1).Width = 150
        grilla_documentos.Columns(2).Width = 150
        grilla_documentos.Columns(3).Width = 150
        grilla_documentos.Columns(4).Width = 150

        txt_total_documentos.Text = grilla_documentos.Rows.Count
    End Sub

    Sub mostrar_detalle_de_documentos_repetidos()
        Dim tipo_doc As String
        Dim nro_doc As String
        Dim cod_producto As String

        tipo_doc = grilla_documentos.CurrentRow.Cells(0).Value
        nro_doc = grilla_documentos.CurrentRow.Cells(1).Value
        cod_producto = grilla_documentos.CurrentRow.Cells(3).Value







        If combo_venta.Text = "COMPRA" Then
            grilla_productos.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_compra WHERE n_compra='" & (nro_doc) & "' and cod_producto='" & (cod_producto) & "'  order by cod_producto"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("total"))
                Next
            End If
        End If


        If combo_venta.Text = "KARDEX" Then
            grilla_productos.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_total  WHERE tipo like '" & ("%" & tipo_doc & "%") & "' and n_total='" & (nro_doc) & "' and cod_producto='" & (cod_producto) & "'  order by cod_producto"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_detalle"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("total"))
                Next
            End If
        End If

        If combo_venta.Text = "BOLETA" Then
            grilla_productos.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta  WHERE n_boleta='" & (nro_doc) & "' and cod_producto='" & (cod_producto) & "'  order by cod_producto"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If

        If combo_venta.Text = "FACTURA" Then
            grilla_productos.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura  WHERE n_factura='" & (nro_doc) & "' and cod_producto='" & (cod_producto) & "'  order by cod_producto"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If

        If combo_venta.Text = "GUIA" Then
            grilla_productos.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_guia  WHERE n_guia='" & (nro_doc) & "' and cod_producto='" & (cod_producto) & "'  order by cod_producto"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If

        If combo_venta.Text = "NOTA DE DEBITO" Then
            grilla_productos.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_nota_debito  WHERE n_nota_debito='" & (nro_doc) & "' and cod_producto='" & (cod_producto) & "'  order by cod_producto"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If

        If combo_venta.Text = "NOTA DE CREDITO" Then
            grilla_productos.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_nota_credito  WHERE n_nota_debito='" & (nro_doc) & "' and cod_producto='" & (cod_producto) & "'  order by cod_producto"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If



























        grilla_productos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_productos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_productos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_productos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_productos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_productos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If grilla_productos.Rows.Count <> 0 Then
            If grilla_productos.Columns(0).Width = 80 Then
                grilla_productos.Columns(0).Width = 79
            Else
                grilla_productos.Columns(0).Width = 80
            End If
        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If combo_venta.Text = "" Then
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_venta.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        fecha()
        mostrar_documentos_repetidos()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_documentos.Rows.Clear()
        grilla_productos.Rows.Clear()
        txt_total_documentos.Text = ""
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_documentos.Rows.Clear()
        grilla_productos.Rows.Clear()
        txt_total_documentos.Text = ""
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim VarCodAuto As String
        Dim VarCodProducto As String

        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR LOS REGISTROS SELECCIONADOS?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then
            If grilla_productos.Rows.Count > 0 Then
                For i = 0 To grilla_productos.Rows.Count - 1
                    VarCodAuto = grilla_productos.Rows(i).Cells(0).Value.ToString
                    VarCodProducto = grilla_productos.Rows(i).Cells(1).Value.ToString

                    If grilla_productos.Rows(i).Cells(6).Value = True Then

              

                        If combo_venta.Text = "KARDEX" Then
                            SC.Connection = conexion
                            SC.CommandText = "DELETE FROM `detalle_total` WHERE `cod_detalle`='" & (VarCodAuto) & "' and `cod_producto`='" & (VarCodProducto) & "';"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                        End If

                        If combo_venta.Text = "COMPRA" Then
                            SC.Connection = conexion
                            SC.CommandText = "DELETE FROM `detalle_compra` WHERE `cod_auto`='" & (VarCodAuto) & "' and `cod_producto`='" & (VarCodProducto) & "';"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                        End If

                        If combo_venta.Text = "BOLETA" Then
                            SC.Connection = conexion
                            SC.CommandText = "DELETE FROM `detalle_boleta` WHERE `cod_auto`='" & (VarCodAuto) & "' and `cod_producto`='" & (VarCodProducto) & "';"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                        End If

                        If combo_venta.Text = "FACTURA" Then
                            SC.Connection = conexion
                            SC.CommandText = "DELETE FROM `detalle_factura` WHERE `cod_auto`='" & (VarCodAuto) & "' and `cod_producto`='" & (VarCodProducto) & "';"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                        End If

                        If combo_venta.Text = "GUIA" Then
                            SC.Connection = conexion
                            SC.CommandText = "DELETE FROM `detalle_guia` WHERE `cod_auto`='" & (VarCodAuto) & "' and `cod_producto`='" & (VarCodProducto) & "';"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                        End If

                        If combo_venta.Text = "NOTA DE DEBITO" Then
                            SC.Connection = conexion
                            SC.CommandText = "DELETE FROM `detalle_nota_debito` WHERE `cod_auto`='" & (VarCodAuto) & "' and `cod_producto`='" & (VarCodProducto) & "';"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                        End If

                        If combo_venta.Text = "NOTA DE CREDITO" Then
                            SC.Connection = conexion
                            SC.CommandText = "DELETE FROM `detalle_nota_credito` WHERE `cod_auto`='" & (VarCodAuto) & "' and `cod_producto`='" & (VarCodProducto) & "';"
                            DA.SelectCommand = SC
                            DA.Fill(DT)
                        End If

                    End If
                Next
            End If
        End If

        grilla_documentos.Rows.Clear()
        grilla_productos.Rows.Clear()
        mostrar_documentos_repetidos()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub grilla_documentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documentos.Click
        If grilla_documentos.Rows.Count <> 0 Then
            mostrar_detalle_de_documentos_repetidos()
        End If
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then
            grilla_documentos.Rows.Clear()
            grilla_productos.Rows.Clear()
            txt_total_documentos.Text = ""
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub combo_venta_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        grilla_documentos.Rows.Clear()
        grilla_productos.Rows.Clear()
        txt_total_documentos.Text = ""
    End Sub

    Private Sub grilla_documentos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documentos.CellContentClick

    End Sub

    Private Sub grilla_documentos_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documentos.ClientSizeChanged

    End Sub
End Class