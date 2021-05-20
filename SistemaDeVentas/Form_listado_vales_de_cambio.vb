Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D

Public Class Form_listado_vales_de_cambio
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private WithEvents Pd As New PrintDocument
    Dim alto_cotizacion As String
    Dim peso As String
    Dim impresora_vales_de_cambio As String

    Private Sub Form_listado_vales_de_cambio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_listado_vales_de_cambio_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_listado_vales_de_cambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        'mostrar_malla()
        llenar_combo_vendedor()

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
            impresora_vales_de_cambio = DS.Tables(DT.TableName).Rows(0).Item("ticket_vales_de_cambio")
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
        Combo_vendedor.SelectedItem = "TODOS"
        grilla_documento.DataSource = Nothing
        dtp_desde.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_hasta.Text = FormatDateTime(Now, DateFormat.ShortDate)

    End Sub

    Sub mostrar_malla()
        grilla_documento.Columns.Clear()
        grilla_documento.Columns.Add("", "NUMERO")
        grilla_documento.Columns.Add("", "FECHA")
        grilla_documento.Columns.Add("", "HORA")
        grilla_documento.Columns.Add("", "SALE")
        grilla_documento.Columns.Add("", "ENTRA")
        grilla_documento.Columns.Add("", "SALDO")
        grilla_documento.Columns.Add("", "DOC. REF.")
        grilla_documento.Columns.Add("", "NRO. REF.")
        grilla_documento.Columns.Add("", "SUBTOTAL")
        grilla_documento.Columns.Add("", "DESCUENTO")
        grilla_documento.Columns.Add("", "TOTAL")

        grilla_documento.Columns(0).Width = 106
        grilla_documento.Columns(1).Width = 120
        grilla_documento.Columns(2).Width = 120
        grilla_documento.Columns(3).Width = 120
        grilla_documento.Columns(4).Width = 120
        grilla_documento.Columns(5).Width = 120
        grilla_documento.Columns(6).Width = 120
        grilla_documento.Columns(7).Width = 120
        grilla_documento.Columns(8).Width = 120
        grilla_documento.Columns(9).Width = 120
        grilla_documento.Columns(10).Width = 120

        grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        If Combo_vendedor.Text = "TODOS" Then
            grilla_documento.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from vale_cambio where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' order by nro_vale asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nro_vale"), _
                                               mifecha_emision2, _
                                                DS.Tables(DT.TableName).Rows(i).Item("hora"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("total_positivo"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("total_negativo"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("saldo_favor_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("documento_referencia"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("nro_referencia"), _
                                                    Val(DS.Tables(DT.TableName).Rows(i).Item("total_positivo")) + Val(DS.Tables(DT.TableName).Rows(i).Item("descuento")), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("total_positivo"))
                Next
            End If
        End If

        If Combo_vendedor.Text <> "TODOS" Then
            grilla_documento.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from vale_cambio where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and usuario_responsable='" & (txt_rut_vendedor.Text) & "' order by nro_vale asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nro_vale"), _
                                               mifecha_emision2, _
                                                DS.Tables(DT.TableName).Rows(i).Item("hora"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("total_positivo"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("total_negativo"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("saldo_favor_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("documento_referencia"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("nro_referencia"))
                Next
            End If
        End If

        grilla_documento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If grilla_documento.Rows.Count <> 0 Then
            If grilla_documento.Columns(0).Width = 106 Then
                grilla_documento.Columns(0).Width = 105
            Else
                grilla_documento.Columns(0).Width = 106
            End If
        End If
    End Sub



    Sub mostrar_malla_todo()
        grilla_todo.Columns.Clear()
        grilla_todo.Columns.Add("", "NUMERO")
        grilla_todo.Columns.Add("", "FECHA")
        grilla_todo.Columns.Add("", "HORA")
        grilla_todo.Columns.Add("", "SALE")
        grilla_todo.Columns.Add("", "ENTRA")
        grilla_todo.Columns.Add("", "SALDO")
        grilla_todo.Columns.Add("", "DOC. REF.")
        grilla_todo.Columns.Add("", "NRO. REF.")
        grilla_todo.Columns.Add("", "CODIGO")
        grilla_todo.Columns.Add("", "NOMBRE")
        grilla_todo.Columns.Add("", "NRO. TECNICO")
        grilla_todo.Columns.Add("", "PRECIO")
        grilla_todo.Columns.Add("", "CANTIDAD")
        grilla_todo.Columns.Add("", "TOTAL")
        grilla_todo.Columns.Add("", "MOVIMIENTO")

        grilla_todo.Columns(0).Width = 106
        grilla_todo.Columns(1).Width = 120
        grilla_todo.Columns(2).Width = 120
        grilla_todo.Columns(3).Width = 120
        grilla_todo.Columns(4).Width = 120
        grilla_todo.Columns(5).Width = 120
        grilla_todo.Columns(6).Width = 120
        grilla_todo.Columns(7).Width = 120

        grilla_todo.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_todo.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_todo.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_todo.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_todo.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_todo.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_todo.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_todo.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_todo.Columns(8).Width = 100
        grilla_todo.Columns(9).Width = 264
        grilla_todo.Columns(10).Width = 200
        grilla_todo.Columns(11).Width = 100
        grilla_todo.Columns(12).Width = 100
        grilla_todo.Columns(13).Width = 100
        grilla_todo.Columns(14).Width = 100

        grilla_todo.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_todo.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_todo.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_todo.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_todo.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_todo.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_todo.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        If Combo_vendedor.Text = "TODOS" Then
            grilla_todo.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from vale_cambio, detalle_vale_cambio where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' group by detalle_vale_cambio.nro_vale, detalle_vale_cambio.cod_producto order by vale_cambio.nro_vale asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                    grilla_todo.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nro_vale"), _
                                               mifecha_emision2, _
                                                DS.Tables(DT.TableName).Rows(i).Item("hora"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("total_positivo"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("total_negativo"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("saldo_favor_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("documento_referencia"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("nro_referencia"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("movimiento"))
                Next
            End If
        End If

        If Combo_vendedor.Text <> "TODOS" Then
            grilla_todo.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from vale_cambio, detalle_vale_cambio where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and usuario_responsable='" & (txt_rut_vendedor.Text) & "'  group by detalle_vale_cambio.nro_vale, detalle_vale_cambio.cod_producto order by vale_cambio.nro_vale asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                    grilla_todo.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nro_vale"), _
                                               mifecha_emision2, _
                                                DS.Tables(DT.TableName).Rows(i).Item("hora"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("total_positivo"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("total_negativo"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("saldo_favor_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("documento_referencia"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("nro_referencia"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("movimiento"))
                Next
            End If
        End If

        grilla_todo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If grilla_todo.Rows.Count <> 0 Then
            If grilla_todo.Columns(0).Width = 106 Then
                grilla_todo.Columns(0).Width = 105
            Else
                grilla_todo.Columns(0).Width = 106
            End If
        End If
    End Sub

    Sub mostrar_malla_detalle()

        Dim nro_vale As String
        nro_vale = grilla_documento.CurrentRow.Cells(0).Value

        grilla_documento_detalle.Columns.Clear()
        grilla_documento_detalle.Columns.Add("", "CODIGO")
        grilla_documento_detalle.Columns.Add("", "NOMBRE")
        grilla_documento_detalle.Columns.Add("", "NRO. TECNICO")
        grilla_documento_detalle.Columns.Add("", "PRECIO")
        grilla_documento_detalle.Columns.Add("", "CANTIDAD")
        grilla_documento_detalle.Columns.Add("", "TOTAL")
        grilla_documento_detalle.Columns.Add("", "MOVIMIENTO")

        grilla_documento_detalle.Columns(0).Width = 100
        grilla_documento_detalle.Columns(1).Width = 264
        grilla_documento_detalle.Columns(2).Width = 200
        grilla_documento_detalle.Columns(3).Width = 100
        grilla_documento_detalle.Columns(4).Width = 100
        grilla_documento_detalle.Columns(5).Width = 100
        grilla_documento_detalle.Columns(6).Width = 100

        grilla_documento_detalle.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento_detalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento_detalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento_detalle.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        grilla_documento_detalle.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_vale_cambio where nro_vale= '" & (nro_vale) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_documento_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_total"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("movimiento"))
            Next
        End If



        grilla_documento_detalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If grilla_documento_detalle.Rows.Count <> 0 Then
            If grilla_documento_detalle.Columns(0).Width = 100 Then
                grilla_documento_detalle.Columns(0).Width = 99
            Else
                grilla_documento_detalle.Columns(0).Width = 100
            End If
        End If
    End Sub







    Sub mostrar_malla_detalle_imprimir()

        Dim nro_vale As String
        nro_vale = grilla_documento.CurrentRow.Cells(0).Value

        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        'Dim VarPorcentaje As Integer
        'Dim VarDescuento As Integer
        'Dim VarTotal As Integer
        'Dim VarPrecioReal As Integer
        'Dim iva_valor As String
        'Dim nombre As String
        'Dim valor As String
        'Dim descuento As String
        'Dim total As String
        'Dim subtotal As String
       

        grilla_detalle_venta.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_vale_cambio where nro_vale= '" & (nro_vale) & "' and movimiento='SALE'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
            Next
        End If



        grilla_detalle_venta_entra.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_vale_cambio where nro_vale= '" & (nro_vale) & "' and movimiento='ENTRA'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_detalle_venta_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
            Next
        End If



      
    End Sub





    Private Sub txt_rut_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)



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

    Sub llenar_combo_vendedor()
        Combo_vendedor.Items.Clear()
        Combo_vendedor.Items.Add("TODOS")
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
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        Combo_vendedor.SelectedItem = "TODOS"
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
                txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub Combo_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.GotFocus
        Combo_vendedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_vendedor.LostFocus
        'Combo_vendedor.BackColor = Color.
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

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_documento.Rows.Count = 0 Then
            dtp_desde.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False

        If RadioButton1.Checked = True Then
            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Me.grilla_documento, save.FileName)
            End If
        End If

        If RadioButton2.Checked = True Then
            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Me.grilla_documento_detalle, save.FileName)
            End If
        End If

        If RadioButton3.Checked = True Then
            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Me.grilla_todo, save.FileName)
            End If
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)
        If RadioButton1.Checked = True Then
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
        End If

        If RadioButton2.Checked = True Then
            Dim xlApp As Object = CreateObject("Excel.Application")
            'crear una nueva hoja de calculo 
            Dim xlWB As Object = xlApp.WorkBooks.add
            Dim xlWS As Object = xlWB.WorkSheets(1)

            'exportamos los caracteres de las columnas 
            For c As Integer = 0 To grilla_documento_detalle.Columns.Count - 1
                xlWS.cells(1, c + 1).value = grilla_documento_detalle.Columns(c).HeaderText
            Next
            'exportamos las cabeceras de columnas 
            For r As Integer = 0 To grilla_documento_detalle.RowCount - 1
                For c As Integer = 0 To grilla_documento_detalle.Columns.Count - 1
                    xlWS.cells(r + 2, c + 1).value = grilla_documento_detalle.Item(c, r).Value
                Next
            Next
            'guardamos la hoja de calculo en la ruta especificada 
            xlWB.saveas(pth)
            xlWS = Nothing
            xlWB = Nothing
            xlApp.quit()
            xlApp = Nothing
        End If

        If RadioButton3.Checked = True Then
            Dim xlApp As Object = CreateObject("Excel.Application")
            'crear una nueva hoja de calculo 
            Dim xlWB As Object = xlApp.WorkBooks.add
            Dim xlWS As Object = xlWB.WorkSheets(1)

            'exportamos los caracteres de las columnas 
            For c As Integer = 0 To grilla_todo.Columns.Count - 1
                xlWS.cells(1, c + 1).value = grilla_todo.Columns(c).HeaderText
            Next
            'exportamos las cabeceras de columnas 
            For r As Integer = 0 To grilla_todo.RowCount - 1
                For c As Integer = 0 To grilla_todo.Columns.Count - 1
                    xlWS.cells(r + 2, c + 1).value = grilla_todo.Item(c, r).Value
                Next
            Next
            'guardamos la hoja de calculo en la ruta especificada 
            xlWB.saveas(pth)
            xlWS = Nothing
            xlWB = Nothing
            xlApp.quit()
            xlApp = Nothing
        End If
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_documento.Columns.Clear()
        grilla_documento_detalle.Columns.Clear()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_documento.Columns.Clear()
        grilla_documento_detalle.Columns.Clear()
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        If mirutempresa = "87686300-6" Then
            If dtp_desde.Value.Year < "2017" Then
                MsgBox("ERROR")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End If
        grilla_documento.DataSource = Nothing
        fecha()
        mostrar_malla()
        mostrar_malla_todo()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub

    Private Sub grilla_documento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.Click

        If grilla_documento.Rows.Count <> 0 Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            grilla_documento.DataSource = Nothing
            mostrar_malla_detalle()
            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If

    End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        mostrar_datos_vendedor()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        mostrar_malla_detalle_imprimir()

        With Pd.PrinterSettings
            .PrinterName = impresora_vales_de_cambio
            .Copies = 1
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.Pd.PrintController = New StandardPrintController
                Me.Pd.DefaultPageSettings.Margins.Left = 10
                Me.Pd.DefaultPageSettings.Margins.Right = 10
                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, alto_cotizacion)
                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()

                If tipo_documento = "VALE DE CAMBIO" Then

                    If grilla_documento.CurrentRow.Cells(3).Value.ToString <> grilla_documento.CurrentRow.Cells(4).Value.ToString Then

                        With Pd.PrinterSettings
                            .PrinterName = impresora_vales_de_cambio
                            .Copies = 2
                            .PrintRange = PrintRange.AllPages
                            If .IsValid Then
                                'Me.Pd.PrintController = New StandardPrintController
                                Dim Custom_Size_cambio As New PaperSize("New Long Roll", 1000, 850)
                                Me.PrintDocument1.DefaultPageSettings.PaperSize = Custom_Size_cambio
                                PrintDocument1.PrintController = New System.Drawing.Printing.StandardPrintController()
                                PrintDocument1.Print()
                            Else
                                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                                lbl_mensaje.Visible = False
                                Me.Enabled = True
                                Exit Sub
                            End If
                        End With
                    End If
                End If
            End If
        End With
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    'Dim Total_letra As Integer
    '    'Dim Comprobar_letra As Integer

    '    'Total_letra = (txt_total.Text) / (txt_cargar.Text)
    '    'Comprobar_letra = (Total_letra) * (txt_cargar.Text)
    '    'Comprobar_letra = (txt_total.Text) - (Comprobar_letra)
    '    'Total_letra = (Total_letra) + (Comprobar_letra)
    '    'Round(Total_letra)

    '    Dim fecha_mas_tres As String

    '    dtp_fecha.Value = grilla_documento.CurrentRow.Cells(1).Value.ToString

    '    fecha_mas_tres = dtp_fecha.Value.AddMonths(Val(+3))

    '    If fecha_mas_tres.Length > 10 Then
    '        fecha_mas_tres = fecha_mas_tres.Substring(0, 10)
    '    End If



    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

    '    dt.Columns.Add(New DataColumn("nro_saldo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("total_saldo", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("referencia_saldo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fecha_saldo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("nombre_vendedor", GetType(String)))
    '    dt.Columns.Add(New DataColumn("desglose", GetType(String)))
    '    dt.Columns.Add(New DataColumn("validez", GetType(String)))
    '    dr = dt.NewRow()

    '    Try
    '        'dr("Imagen") = ImageToByte(Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg"))
    '        dr("Imagen") = Imagen_ticket

    '    Catch
    '    End Try

    '    dr("nro_saldo") = grilla_documento.CurrentRow.Cells(0).Value.ToString
    '    dr("total_saldo") = grilla_documento.CurrentRow.Cells(5).Value.ToString
    '    dr("referencia_saldo") = "VALE DE CAMBIO " & grilla_documento.CurrentRow.Cells(0).Value.ToString
    '    dr("fecha_saldo") = dtp_fecha.Text
    '    dr("nombre_vendedor") = minombre
    '    dr("validez") = "VALIDO HASTA EL " & fecha_mas_tres

    '    'dr("desglose") = desglose_saldo
    '    dr("nombre_empresa") = minombreempresa
    '    dr("giro_empresa") = migiroempresa
    '    dr("direccion_empresa") = midireccionempresa
    '    dr("comuna_empresa") = micomunaempresa
    '    dr("telefono_empresa") = mitelefonoempresa
    '    dr("correo_empresa") = micorreoempresa
    '    dr("rut_empresa") = mirutempresa
    '    dt.Rows.Add(dr)

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "Saldo"

    '    Dim iDS As New dsSaldoafavor

    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function


    Sub imprimir()

        With Pd.PrinterSettings
            ' Especifico el nombre de la impresora 
            ' por donde deseo imprimir. 
            .PrinterName = impresora_vales_de_cambio
            '.PrinterName = "Microsoft Print to PDF"
            ' .PrinterName = "\\SERVER\HP LaserJet Professional P 1102w"
            ' Establezco el número de copias que se imprimirán 
            .Copies = 1

            ' Rango de páginas que se imprimirán 
            .PrintRange = PrintRange.AllPages

            If .IsValid Then

                Me.Enabled = False

                Me.Enabled = False

                Me.Pd.PrintController = New StandardPrintController
                Me.Pd.DefaultPageSettings.Margins.Left = 10
                Me.Pd.DefaultPageSettings.Margins.Right = 10
                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, alto_cotizacion)
                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()



                If tipo_documento = "VALE DE CAMBIO" Then

                    'If Int(lbl_venta.Text) <> 0 Then
                    If Int(grilla_documento.CurrentRow.Cells(0).Value.ToString()) <> 0 Then
                        With Pd.PrinterSettings
                            .PrinterName = impresora_vales_de_cambio
                            .Copies = 2
                            .PrintRange = PrintRange.AllPages
                            If .IsValid Then
                                'Me.Pd.PrintController = New StandardPrintController
                                Dim Custom_Size_cambio As New PaperSize("New Long Roll", 1000, 850)
                                Me.PrintDocument1.DefaultPageSettings.PaperSize = Custom_Size_cambio
                                PrintDocument1.PrintController = New System.Drawing.Printing.StandardPrintController()
                                PrintDocument1.Print()
                            Else
                                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                                lbl_mensaje.Visible = False
                                Me.Enabled = True
                                Exit Sub
                            End If
                        End With
                    End If
                End If
            End If
        End With
    End Sub





    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As String
        Dim VarCantidad As String
        Dim VarPorcentaje As String
        Dim VarDescuento As String
        Dim VarNeto As String
        Dim VarIva As String
        Dim VarSubtotal As String
        Dim VarTotal As String
        Dim cantidad_detalle As String
        Dim valorUnitario_detalle As String
        Dim subtotal_detalle As String
        Dim total_detalle As String

        'If documento_tipo = "1" Then
        Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far
        Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        Dim Font2 As New Font("arial", 14, FontStyle.Regular)
        Dim Font3 As New Font("arial", 8, FontStyle.Regular)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        Try
            Dim p As New PointF(0, 0)
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_ticket), p)
        Catch
        End Try

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim rect1 As New Rectangle(10, 60, 270, 15)
        Dim rect2 As New Rectangle(10, 75, 270, 15)
        Dim rect3 As New Rectangle(10, 90, 270, 15)
        Dim rect4 As New Rectangle(10, 105, 270, 15)
        Dim rect5 As New Rectangle(10, 120, 270, 15)
        Dim rect6 As New Rectangle(10, 135, 270, 15)
        Dim rect7 As New Rectangle(10, 185, 270, 17)
        Dim rect15 As New Rectangle(10, 150, 270, 15)

        e.Graphics.DrawString(minombreempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect15, stringFormat)

        e.Graphics.DrawString("CAMBIO DE PRODUCTO", Font2, Brushes.Black, rect7, stringFormat)
        e.Graphics.DrawString("NRO. CAMBIO", Font4, Brushes.Black, 0, 220)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 220)
        e.Graphics.DrawString(grilla_documento.CurrentRow.Cells(0).Value.ToString, Font3, Brushes.Black, 83, 220)
        e.Graphics.DrawString("FECHA", Font4, Brushes.Black, 0, 235)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 235)
        e.Graphics.DrawString(dtp_fecha.Text, Font3, Brushes.Black, 83, 235)
        e.Graphics.DrawString("REFERENCIA", Font4, Brushes.Black, 0, 250)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 250)
        e.Graphics.DrawString(grilla_documento.CurrentRow.Cells(6).Value.ToString & " NRO. " & grilla_documento.CurrentRow.Cells(7).Value.ToString, Font3, Brushes.Black, 83, 250)
        e.Graphics.DrawString("VENDEDOR", Font4, Brushes.Black, 0, 265)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 265)
        e.Graphics.DrawString(minombre, Font3, Brushes.Black, 83, 265)
        Dim rect_ingresa As New Rectangle(15, 293, 270, 22)
        e.Graphics.DrawString("INGRESA", Font2, Brushes.Black, rect_ingresa, stringFormat)
        e.Graphics.DrawString("CODIGO", Font4, Brushes.Black, 0, 325)
        e.Graphics.DrawString("DESCRIPCION", Font4, Brushes.Black, 55, 325)
        e.Graphics.DrawString("CANT.", Font4, Brushes.Black, 200, 325)
        e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 245, 325)
        e.Graphics.DrawLine(Pens.Black, 1, 340, 295, 340)

        For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta_entra.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta_entra.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta_entra.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta_entra.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta_entra.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta_entra.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta_entra.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString
            cantidad_detalle = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
            valorUnitario_detalle = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
            subtotal_detalle = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
            total_detalle = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString

            Dim cantidad As String
            Dim total As String
            Dim descripcion As String

            cantidad = VarCantidad
            total = total_detalle
            descripcion = varnombre

            If varnombre.Length > 17 Then
                descripcion = varnombre.Substring(0, 17)
            End If

            total = Format(Int(total), "###,###,###")
            VarSubtotal = Format(Int(VarSubtotal), "###,###,###")

            e.Graphics.DrawString(VarCodProducto, Font3, Brushes.Gray, 0, 343 + (i * 30))
            e.Graphics.DrawString(descripcion, Font3, Brushes.Gray, 55, 343 + (i * 30))
            e.Graphics.DrawString(vartecnico, Font3, Brushes.Gray, 55, 353 + (i * 30))
            e.Graphics.DrawString(VarSubtotal & " X " & cantidad, Font3, Brushes.Gray, 235, 353 + (i * 30), format1)
            e.Graphics.DrawString(total, Font3, Brushes.Gray, 285, 353 + (i * 30), format1)
            e.Graphics.DrawLine(Pens.Black, 1, 368 + (i * 30), 295, 368 + (i * 30))
            '  cuenta_ciclo = cuenta_ciclo + 1
        Next

        Dim subtotal_millar As String
        Dim descuento_millar As String
        Dim total_millar As String

        descuento_millar = grilla_documento.CurrentRow.Cells(9).Value.ToString
        subtotal_millar = grilla_documento.CurrentRow.Cells(8).Value.ToString
        total_millar = grilla_documento.CurrentRow.Cells(10).Value.ToString

        subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        descuento_millar = Format(Int(descuento_millar), "###,###,###")
        total_millar = Format(Int(total_millar), "###,###,###")

        Dim var_grilla As Integer
        var_grilla = ((grilla_detalle_venta_entra.Rows.Count) * 30)

        e.Graphics.DrawString("SUBTOTAL", Font4, Brushes.Black, 160, var_grilla + 360)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + 360)
        e.Graphics.DrawString(subtotal_millar, Font3, Brushes.Black, 285, var_grilla + 360, format1)
        e.Graphics.DrawString("DESCUENTO", Font4, Brushes.Black, 160, var_grilla + 375)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + 375)
        e.Graphics.DrawString(descuento_millar, Font3, Brushes.Black, 285, var_grilla + 375, format1)
        e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 160, var_grilla + 390)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + 390)
        e.Graphics.DrawString(total_millar, Font3, Brushes.Black, 285, var_grilla + 390, format1)
        Dim rect_sale As New Rectangle(10, var_grilla + 420, 270, 17)
        e.Graphics.DrawString("SALE", Font2, Brushes.Black, rect_sale, stringFormat)
        e.Graphics.DrawString("CODIGO", Font4, Brushes.Black, 0, var_grilla + 450)
        e.Graphics.DrawString("DESCRIPCION", Font4, Brushes.Black, 55, var_grilla + 450)
        e.Graphics.DrawString("CANT.", Font4, Brushes.Black, 200, var_grilla + 450)
        e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 245, var_grilla + 450)
        e.Graphics.DrawLine(Pens.Black, 1, var_grilla + 465, 295, var_grilla + 465)

        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
            cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            Dim cantidad As String
            Dim total As String
            Dim descripcion As String

            cantidad = VarCantidad
            total = total_detalle

            descripcion = varnombre
            If varnombre.Length > 17 Then
                descripcion = varnombre.Substring(0, 17)
            End If

            total = Format(Int(total), "###,###,###")
            VarSubtotal = Format(Int(VarSubtotal), "###,###,###")

            e.Graphics.DrawString(VarCodProducto, Font3, Brushes.Gray, 0, var_grilla + 468 + (i * 30))
            e.Graphics.DrawString(descripcion, Font3, Brushes.Gray, 55, var_grilla + 468 + (i * 30))
            e.Graphics.DrawString(vartecnico, Font3, Brushes.Gray, 55, var_grilla + 478 + (i * 30))
            e.Graphics.DrawString(VarSubtotal & " X " & cantidad, Font3, Brushes.Gray, 235, var_grilla + 478 + (i * 30), format1)
            e.Graphics.DrawString(total, Font3, Brushes.Gray, 285, var_grilla + 478 + (i * 30), format1)
            e.Graphics.DrawLine(Pens.Black, 1, var_grilla + 493 + (i * 30), 295, var_grilla + 493 + (i * 30))
        Next

        Dim var_grilla_sale As Integer
        var_grilla_sale = ((grilla_detalle_venta.Rows.Count) * 30)

        If var_grilla_sale < "0" Then
            var_grilla_sale = 5
        End If

        If var_grilla_sale = "0" Then
            var_grilla_sale = 5
        End If

        descuento_millar = grilla_documento.CurrentRow.Cells(9).Value.ToString
        subtotal_millar = grilla_documento.CurrentRow.Cells(8).Value.ToString
        total_millar = grilla_documento.CurrentRow.Cells(10).Value.ToString

        subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        descuento_millar = Format(Int(descuento_millar), "###,###,###")
        total_millar = Format(Int(total_millar), "###,###,###")

        e.Graphics.DrawString("SUBTOTAL", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 485)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 485)
        e.Graphics.DrawString(subtotal_millar, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 485, format1)
        e.Graphics.DrawString("DESCUENTO", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 500)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 500)
        e.Graphics.DrawString(descuento_millar, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 500, format1)
        e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 515)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 515)
        e.Graphics.DrawString(total_millar, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 515, format1)

        Dim rect_resumen As New Rectangle(10, var_grilla + var_grilla_sale + 545, 270, 17)

        e.Graphics.DrawString("RESUMEN", Font2, Brushes.Black, rect_resumen, stringFormat)

        subtotal_millar = grilla_documento.CurrentRow.Cells(3).Value.ToString
        descuento_millar = grilla_documento.CurrentRow.Cells(4).Value.ToString
        total_millar = Int(grilla_documento.CurrentRow.Cells(4).Value.ToString) - Int(grilla_documento.CurrentRow.Cells(3).Value.ToString)

        subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        descuento_millar = Format(Int(descuento_millar), "###,###,###")
        total_millar = Format(Int(total_millar), "###,###,###")

        e.Graphics.DrawString("INGRESA", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 580)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 580)
        e.Graphics.DrawString(subtotal_millar, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 580, format1)
        e.Graphics.DrawString("SALE", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 595)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 595)
        e.Graphics.DrawString(descuento_millar, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 595, format1)


        Dim tipo_documento As String
        tipo_documento = grilla_documento.CurrentRow.Cells(6).Value.ToString
        tipo_documento = Mid(tipo_documento, 1, Len(tipo_documento) - 1)


        If tipo_documento.Contains("BOLETA") Then
            'If lbl_venta.Text <> "" Then
            If grilla_documento.CurrentRow.Cells(3).Value.ToString <> grilla_documento.CurrentRow.Cells(4).Value.ToString Then

                Dim total_venta As String
                total_venta = Val(grilla_documento.CurrentRow.Cells(3).Value.ToString) - Val(grilla_documento.CurrentRow.Cells(4).Value.ToString)
                If total_venta = "" Or total_venta = "0" Then
                    total_venta = "0"
                Else
                    total_venta = Format(Int(total_venta), "###,###,###")
                End If

                e.Graphics.DrawString("PAGA", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 610)
                e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 610)
                e.Graphics.DrawString(total_venta, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 610, format1)
                e.Graphics.DrawString("SE GENERA BOLETA " & grilla_documento.CurrentRow.Cells(6).Value.ToString, Font2, Brushes.Black, 10, var_grilla + var_grilla_sale + 625)
            End If
            'If
        End If




        Dim rect8 As New Rectangle(10, var_grilla + var_grilla_sale + 730, 270, 15)
        Dim rect9 As New Rectangle(10, var_grilla + var_grilla_sale + 650, 270, 15)

        e.Graphics.DrawString("AUTORIZA :", Font4, Brushes.Black, 0, var_grilla + var_grilla_sale + 730)
        e.Graphics.DrawLine(Pens.Black, 65, var_grilla + var_grilla_sale + 745, 295, var_grilla + var_grilla_sale + 745)

        Dim fecha_mas_tres As String
        fecha_mas_tres = dtp_fecha.Value.AddMonths(Val(+3))

        If fecha_mas_tres.Length > 10 Then
            fecha_mas_tres = fecha_mas_tres.Substring(0, 10)
        End If

        Dim rect10 As New Rectangle(10, var_grilla + var_grilla_sale + 795, 260, 15)
        e.Graphics.DrawString("-", Font3, Brushes.Gray, rect10, stringFormat)

        alto_cotizacion = var_grilla + var_grilla_sale + 680

        'End If


        'If documento_tipo = "2" Then

        '    Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        '    Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        '    Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        '    Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

        '    Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        '    format1.Alignment = StringAlignment.Far

        '    If mirutempresa = "87686300-6" Then

        '        e.Graphics.DrawString(dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
        '        e.Graphics.DrawString(txt_condiciones.Text, Font10, Brushes.Black, 590, 5)

        '        e.Graphics.DrawString("999999", Font9, Brushes.Black, 50, 75)
        '        e.Graphics.DrawString("CAMBIO DE PRODUCTO, VALE NRO. " & txt_nro_vale_cambio.Text, Font9, Brushes.Black, 120, 75)
        '        e.Graphics.DrawString(txt_sub_total_final.Text, Font9, Brushes.Black, 725, 75, format1)

        '        Dim descuento_millar_final As String
        '        Dim neto_millar_final As String
        '        Dim iva_millar_final As String
        '        Dim total_millar_final As String
        '        Dim subtotal_millar_final As String

        '        descuento_millar_final = txt_desc_final.Text
        '        neto_millar_final = txt_neto_final.Text
        '        iva_millar_final = txt_iva_final.Text
        '        subtotal_millar_final = txt_sub_total_final.Text
        '        total_millar_final = txt_total_final.Text

        '        descuento_millar_final = Format(Int(descuento_millar_final), "###,###,###")
        '        neto_millar_final = Format(Int(neto_millar_final), "###,###,###")
        '        iva_millar_final = Format(Int(iva_millar_final), "###,###,###")
        '        subtotal_millar_final = Format(Int(subtotal_millar_final), "###,###,###")
        '        total_millar_final = Format(Int(total_millar_final), "###,###,###")

        '        Dim nombre_vendedor As String
        '        nombre_vendedor = minombre
        '        If nombre_vendedor.Length > 12 Then
        '            nombre_vendedor = nombre_vendedor.Substring(0, 12)
        '        End If

        '        e.Graphics.DrawString(Val(grilla_documento.CurrentRow.Cells(7).Value.ToString), Font10, Brushes.Black, 60, 270)
        '        e.Graphics.DrawString(nombre_vendedor, Font10, Brushes.Black, 215, 270)
        '        e.Graphics.DrawString(subtotal_millar_final, Font10, Brushes.Black, 385, 270)
        '        e.Graphics.DrawString(descuento_millar_final, Font10, Brushes.Black, 515, 270)
        '        e.Graphics.DrawString(total_millar_final, Font10, Brushes.Black, 630, 270)

        '    End If


        'If mirutempresa <> "87686300-6" Then



        '    ''\\FORMATO ORIGINAL

        '    Dim altura_impresion As Integer
        '    altura_impresion = 0


        '    e.Graphics.DrawString(txt_nro_boleta.Text & "                   " & dtp_fecha.Text, Font10, Brushes.Black, 540, altura_impresion + 0)


        '    ' e.Graphics.DrawString(dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
        '    e.Graphics.DrawString("CAMBIO DE MERCADERIA", Font10, Brushes.Black, 320, 5)
        '    'e.Graphics.DrawString(txt_condiciones.Text, Font10, Brushes.Black, 590, 5)

        '    e.Graphics.DrawString("///ENTRA///", Font10, Brushes.Black, 35, 60)

        '    e.Graphics.DrawString("REFERENCIA: " & txt_tipo_doc_referencia.Text & " NRO. " & txt_nro_doc_referencia.Text, Font10, Brushes.Black, 725, 60, format1)

        '    For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1
        '        VarCodProducto = grilla_detalle_venta_entra.Rows(i).Cells(0).Value.ToString
        '        varnombre = grilla_detalle_venta_entra.Rows(i).Cells(1).Value.ToString
        '        vartecnico = grilla_detalle_venta_entra.Rows(i).Cells(2).Value.ToString
        '        VarValorUnitario = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
        '        VarCantidad = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
        '        VarNeto = grilla_detalle_venta_entra.Rows(i).Cells(5).Value.ToString
        '        VarIva = grilla_detalle_venta_entra.Rows(i).Cells(6).Value.ToString
        '        VarSubtotal = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
        '        VarPorcentaje = grilla_detalle_venta_entra.Rows(i).Cells(8).Value.ToString
        '        VarDescuento = grilla_detalle_venta_entra.Rows(i).Cells(9).Value.ToString
        '        VarTotal = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString

        '        cantidad_detalle = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
        '        valorUnitario_detalle = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
        '        subtotal_detalle = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
        '        total_detalle = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString

        '        '   cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
        '        valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
        '        subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '        total_detalle = Format(Int(total_detalle), "###,###,###")

        '        Dim descripcion_caracteres As String
        '        descripcion_caracteres = varnombre & "        " & vartecnico
        '        If descripcion_caracteres.Length > 55 Then
        '            descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
        '        End If

        '        e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 0, altura_impresion + 75 + (i * 15))
        '        e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, altura_impresion + 75 + (i * 15))
        '        e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 605, altura_impresion + 75 + (i * 15), format1)
        '        e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 695, altura_impresion + 75 + (i * 15), format1)
        '        e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 770, altura_impresion + 75 + (i * 15), format1)
        '    Next

        '    Dim var_grilla_entra As Integer
        '    var_grilla_entra = ((grilla_detalle_venta_entra.Rows.Count) * 15)

        '    e.Graphics.DrawString("///SALE///", Font10, Brushes.Black, 35, 90 + var_grilla_entra)

        '    For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '        VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
        '        varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
        '        vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
        '        VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
        '        VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
        '        VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
        '        VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
        '        VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
        '        VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '        VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
        '        VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

        '        cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
        '        valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
        '        subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
        '        total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

        '        '   cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
        '        valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
        '        subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '        total_detalle = Format(Int(total_detalle), "###,###,###")

        '        Dim descripcion_caracteres As String
        '        descripcion_caracteres = varnombre & "        " & vartecnico
        '        If descripcion_caracteres.Length > 55 Then
        '            descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
        '        End If

        '        e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 0, altura_impresion + 120 + (i * 15))
        '        e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, altura_impresion + 120 + (i * 15))
        '        e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 605, altura_impresion + 120 + (i * 15), format1)
        '        e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 695, altura_impresion + 120 + (i * 15), format1)
        '        e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 770, altura_impresion + 120 + (i * 15), format1)
        '    Next

        '    Dim descuento_millar_final As String
        '    Dim neto_millar_final As String
        '    Dim iva_millar_final As String
        '    Dim total_millar_final As String
        '    Dim subtotal_millar_final As String

        '    descuento_millar_final = txt_desc_final.Text
        '    neto_millar_final = txt_neto_final.Text
        '    iva_millar_final = txt_iva_final.Text
        '    subtotal_millar_final = txt_sub_total_final.Text
        '    total_millar_final = txt_total_final.Text

        '    descuento_millar_final = Format(Int(descuento_millar_final), "###,###,###")
        '    neto_millar_final = Format(Int(neto_millar_final), "###,###,###")
        '    iva_millar_final = Format(Int(iva_millar_final), "###,###,###")
        '    subtotal_millar_final = Format(Int(subtotal_millar_final), "###,###,###")
        '    total_millar_final = Format(Int(total_millar_final), "###,###,###")


        '    Dim nombre_vendedor As String
        '    nombre_vendedor = minombre
        '    If nombre_vendedor.Length > 12 Then
        '        nombre_vendedor = nombre_vendedor.Substring(0, 12)
        '    End If

        '    If nombre_vendedor.Length > 12 Then
        '        nombre_vendedor = nombre_vendedor.Substring(0, 12)
        '    End If

        '    e.Graphics.DrawString("FORMA DE PAGO:", Font10, Brushes.Black, 10, altura_impresion + 400)
        '    e.Graphics.DrawString(txt_condiciones.Text, Font10, Brushes.Black, 140, altura_impresion + 400)
        '    e.Graphics.DrawString(total_millar_final, Font10, Brushes.Black, 770, altura_impresion + 360, format1)
        'End If
        ' End If

    End Sub

    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Dim desglose_saldo As String
        'Dim total_saldo As String

        'total_saldo = grilla_documento.CurrentRow.Cells(5).Value.ToString

        'peso = " PESOS"
        'If CInt(total_saldo) = 1000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & " DE PESOS"
        'ElseIf CInt(total_saldo) = 2000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 3000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 4000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 5000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 6000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 7000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 8000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 9000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 10000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 11000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 12000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 13000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 14000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 15000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 16000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 17000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 18000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 19000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 20000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 21000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 22000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 23000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 24000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 25000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 26000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 27000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 28000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 29000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'ElseIf CInt(total_saldo) = 30000000 Then
        '    desglose_saldo = Num2Text(total_saldo) & "DE PESOS"
        'Else
        '    desglose_saldo = Num2Text(total_saldo) & peso
        'End If

        'Dim fecha_mas_tres As String

        'dtp_fecha.Value = grilla_documento.CurrentRow.Cells(1).Value.ToString

        'fecha_mas_tres = dtp_fecha.Value.AddMonths(Val(+3))

        'If fecha_mas_tres.Length > 10 Then
        '    fecha_mas_tres = fecha_mas_tres.Substring(0, 10)
        'End If

        'Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        'Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        'Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        'Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        'Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        'Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        'Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        'format1.Alignment = StringAlignment.Far

        'Try
        '    e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), -74, 0, 440, 70)
        'Catch
        'End Try

        'Dim stringFormat As New StringFormat()
        'stringFormat.Alignment = StringAlignment.Center
        'stringFormat.LineAlignment = StringAlignment.Center

        'Dim stringFormat_left As New StringFormat()
        'stringFormat_left.Alignment = StringAlignment.Near
        'stringFormat_left.LineAlignment = StringAlignment.Near

        'Dim margen_izquierdo As Integer
        'Dim margen_superior As Integer

        'margen_izquierdo = 0
        'margen_superior = 0

        'Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 270, margen_superior + 15)
        'Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 270, margen_superior + 15)
        'Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 270, margen_superior + 15)
        'Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 270, margen_superior + 15)
        'Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 270, margen_superior + 15)
        'Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 270, margen_superior + 15)
        'Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 270, margen_superior + 15)
        'Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 270, margen_superior + 15)

        'e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        'e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        'e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        'e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        'e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        'e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        'e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        'e.Graphics.DrawString("SALDO A FAVOR", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        'e.Graphics.DrawString("NRO. SALDO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        'e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 245)
        'e.Graphics.DrawString(grilla_documento.CurrentRow.Cells(0).Value.ToString, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 245)

        'e.Graphics.DrawString("VENDEDOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        'e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 260)
        'e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 260)

        'e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        'e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 275)
        'e.Graphics.DrawString(dtp_fecha.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 275)

        'e.Graphics.DrawString("REFERENCIA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        'e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 290)
        'e.Graphics.DrawString("VALE DE CAMBIO " & grilla_documento.CurrentRow.Cells(0).Value.ToString, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 290)

        'e.Graphics.DrawString("TOTAL", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        'e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 305)
        'e.Graphics.DrawString(grilla_documento.CurrentRow.Cells(5).Value.ToString, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 305)

        'e.Graphics.DrawString("DESGLOSE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 320)
        'e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 320)
        ''e.Graphics.DrawString(desglose_saldo, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 320)

        'Dim rect_desglose_saldo As New Rectangle(margen_izquierdo + 85, margen_superior + 320, margen_izquierdo + 200, margen_superior + 15)
        'e.Graphics.DrawString(desglose_saldo, Font_texto_cabecera, Brushes.Black, rect_desglose_saldo, stringFormat_left)
        'Dim texto_validez As String

        'texto_validez = "PARA COBRAR ESTE ABONO AL MOMENTO DE LA ENTREGA DE LA MERCADERÍA, SOLO SE RECIBE ESTE BOLETO ORIGINAL, NO UNA COPIA NI OTRO MEDIO DONDE SE VEA LA IMAGEN."

        'Dim rect_validez As New Rectangle(margen_izquierdo + 0, margen_superior + 365, margen_izquierdo + 300, margen_superior + 60)
        'e.Graphics.DrawString(texto_validez, Font_texto_titulo_detalle, Brushes.Black, rect_validez, stringFormat)



        'Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + 450, margen_izquierdo + 270, margen_superior + 15)
        'e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub
End Class