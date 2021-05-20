Imports System.IO
Imports System.Math
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_comisiones_por_vendedor
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_comisiones_por_vendedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_comisiones_por_vendedor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_comisiones_por_vendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'miusuario = "11951546-7"
        grilla_detalle_venta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        fecha()
        grilla_comisiones.Rows.Clear()
        mostrar_malla_boletas()
        mostrar_malla_facturas()
        mostrar_malla_guias()
        mostrar_malla_notas_de_credito()
        mostrar_malla_vale_entra()
        mostrar_malla_vale_sale()
        calcular_totales()
        grilla_comisiones.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        grilla_detalle_venta.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()
        negativos()
        Timer_tiempo_espera.Start()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
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
        Dim vartotal As String

        '//Calcular el total de las facturas
        txt_total.Text = 0
        For i = 0 To grilla_comisiones.Rows.Count - 1
            vartotal = (grilla_comisiones.Rows(i).Cells(4).Value.ToString)
            vartotal = Trim(Replace(vartotal, ".", ""))
            txt_total.Text = Val(txt_total.Text) + Val(vartotal)
        Next

        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        txt_neto.Text = Round(txt_total.Text / iva_valor)
        txt_iva.Text = Round((txt_neto.Text) * valor_iva / 100)

        If txt_neto.Text = "" Or txt_neto.Text = "0" Then
            txt_neto.Text = "0"
        Else
            txt_neto.Text = Format(Int(txt_neto.Text), "###,###,###")
        End If
        If txt_iva.Text = "" Or txt_iva.Text = "0" Then
            txt_iva.Text = "0"
        Else
            txt_iva.Text = Format(Int(txt_iva.Text), "###,###,###")
        End If
        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total.Text = "0"
        Else
            txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub

    Sub mostrar_malla_boletas()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select boleta.tipo as TIPO, boleta.n_boleta as NUMERO, boleta.total as TOTAL from boleta where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and boleta.estado <> 'ANULADA'  and boleta.tipo <> 'BOLETA DE CAMBIO' and boleta.usuario_responsable='" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim iva_valor As String
                Dim neto_doc As String
                Dim iva_doc As String
                Dim total_doc As String

                total_doc = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                iva_valor = valor_iva / 100 + 1
                neto_doc = Round(total_doc / iva_valor)
                iva_doc = Round((neto_doc) * valor_iva / 100)

                grilla_comisiones.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                             neto_doc, _
                                              iva_doc, _
                                               total_doc)
            Next
            conexion.Close()
        End If
    End Sub

    Sub mostrar_malla_guias()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select guia.tipo as TIPO, guia.n_guia as NUMERO, guia.total as TOTAL from guia where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and guia.estado <> 'ANULADA' and guia.usuario_responsable='" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim iva_valor As String
                Dim neto_doc As String
                Dim iva_doc As String
                Dim total_doc As String

                total_doc = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                iva_valor = valor_iva / 100 + 1
                neto_doc = Round(total_doc / iva_valor)
                iva_doc = Round((neto_doc) * valor_iva / 100)

                grilla_comisiones.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                             neto_doc, _
                                              iva_doc, _
                                               total_doc)
            Next
            conexion.Close()
        End If
    End Sub

    Sub mostrar_malla_notas_de_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select nota_credito.tipo as TIPO, nota_credito.n_nota_credito as NUMERO, nota_credito.total as TOTAL from nota_credito where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.estado <> 'ANULADA' and nota_credito.vendedor='" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim iva_valor As String
                Dim neto_doc As String
                Dim iva_doc As String
                Dim total_doc As String

                total_doc = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")

                total_doc = "-" & total_doc

                iva_valor = valor_iva / 100 + 1
                neto_doc = Round(total_doc / iva_valor)
                iva_doc = Round((neto_doc) * valor_iva / 100)

                grilla_comisiones.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                             neto_doc, _
                                              iva_doc, _
                                               total_doc)
            Next
            conexion.Close()
        End If
    End Sub

    Sub mostrar_malla_facturas()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select factura.tipo as TIPO, factura.n_factura as NUMERO, factura.total as TOTAL from factura where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and factura.estado <> 'ANULADA' and factura.usuario_responsable='" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim iva_valor As String
                Dim neto_doc As String
                Dim iva_doc As String
                Dim total_doc As String

                total_doc = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                iva_valor = valor_iva / 100 + 1
                neto_doc = Round(total_doc / iva_valor)
                iva_doc = Round((neto_doc) * valor_iva / 100)

                grilla_comisiones.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                             neto_doc, _
                                              iva_doc, _
                                               total_doc)
            Next
            conexion.Close()
        End If
    End Sub

    Sub mostrar_malla_vale_entra()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select vale_cambio.tipo as TIPO, vale_cambio.nro_vale as NUMERO, vale_cambio.total_negativo as TOTAL from vale_cambio where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and vale_cambio.estado <> 'ANULADA' and vale_cambio.vendedor_entra='" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim iva_valor As String
                Dim neto_doc As String
                Dim iva_doc As String
                Dim total_doc As String

                total_doc = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")

                total_doc = "-" & total_doc

                iva_valor = valor_iva / 100 + 1
                neto_doc = Round(total_doc / iva_valor)
                iva_doc = Round((neto_doc) * valor_iva / 100)

                grilla_comisiones.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                             neto_doc, _
                                              iva_doc, _
                                               total_doc)
            Next
            conexion.Close()
        End If
    End Sub

    Sub mostrar_malla_vale_sale()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select vale_cambio.tipo as TIPO, vale_cambio.nro_vale as NUMERO, vale_cambio.total_positivo as TOTAL from vale_cambio where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and vale_cambio.estado <> 'ANULADA' and vale_cambio.usuario_responsable='" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim iva_valor As String
                Dim neto_doc As String
                Dim iva_doc As String
                Dim total_doc As String

                total_doc = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                iva_valor = valor_iva / 100 + 1
                neto_doc = Round(total_doc / iva_valor)
                iva_doc = Round((neto_doc) * valor_iva / 100)

                grilla_comisiones.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("NUMERO"), _
                                             neto_doc, _
                                              iva_doc, _
                                               total_doc)
            Next
            conexion.Close()
        End If
    End Sub

    Sub negativos()
        Dim tipo_doc As String
        Dim total_doc As String

        For i = 0 To grilla_comisiones.Rows.Count - 1
            tipo_doc = grilla_comisiones.Rows(i).Cells(0).Value.ToString
            total_doc = grilla_comisiones.Rows(i).Cells(4).Value.ToString

            If tipo_doc = "NOTA DE CREDITO" Then
                grilla_comisiones.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
            If tipo_doc = "VALE DE CAMBIO" Then
                If total_doc.Contains("-") Then
                    grilla_comisiones.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
            End If
        Next
    End Sub

    'se llama al sub fecha, fecha2, mostrar malla.
    Private Sub dtp2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_comisiones.Rows.Clear()
        txt_iva.Text = "0"
        txt_neto.Text = "0"
        txt_total.Text = "0"
    End Sub

    'se llama al sub fecha, fecha2, mostrar malla.
    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_comisiones.Rows.Clear()
        txt_iva.Text = "0"
        txt_neto.Text = "0"
        txt_total.Text = "0"
    End Sub

    'salir de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    'limpia la pantalla.
    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        If grilla_comisiones.Rows.Count = 0 Then
            ' MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            dtp_desde.Focus()
            Exit Sub
        End If
        grilla_comisiones.Rows.Clear()
        txt_iva.Text = "0"
        txt_neto.Text = "0"
        txt_total.Text = "0"
        dtp_desde.Text = Form_menu_principal.dtp_fecha.Text
        dtp_hasta.Text = Form_menu_principal.dtp_fecha.Text
    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.WhiteSmoke
    End Sub

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

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_comisiones.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            dtp_desde.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_comisiones, save.FileName)
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
        For c As Integer = 0 To grilla_comisiones.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_comisiones.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_comisiones.RowCount - 1
            For c As Integer = 0 To grilla_comisiones.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_comisiones.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        grilla_comisiones.Rows.Clear()
        mostrar_malla_boletas()
        mostrar_malla_facturas()
        mostrar_malla_guias()
        mostrar_malla_notas_de_credito()
        mostrar_malla_vale_entra()
        mostrar_malla_vale_sale()
        calcular_totales()
        negativos()

        If grilla_comisiones.Rows.Count <> 0 Then
            If grilla_comisiones.Columns(0).Width = 150 Then
                grilla_comisiones.Columns(0).Width = 149
            Else
                grilla_comisiones.Columns(0).Width = 150
            End If
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
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

    Private Sub Timer_comisiones_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_tiempo_espera.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub


    Sub cargar_documento()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarTotal As Integer
        Dim VarPrecioReal As Integer
        Dim iva_valor As String
        Dim nombre As String
        Dim valor As String
        Dim descuento As String
        Dim total As String
        Dim subtotal As String
        grilla_detalle_venta.Rows.Clear()

        Dim tipo_doc As String
        Dim nro_doc As String
        Dim total_doc As String

        If grilla_comisiones.Rows.Count = 0 Then
            Exit Sub
        End If

        tipo_doc = grilla_comisiones.CurrentRow.Cells(0).Value
        nro_doc = grilla_comisiones.CurrentRow.Cells(1).Value
        total_doc = grilla_comisiones.CurrentRow.Cells(4).Value



        'If total_doc.Contains("-") Then

        'End If


        If tipo_doc = "VALE DE CAMBIO" Then
            If total_doc.Contains("-") Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                SC.CommandText = "select * from detalle_vale_cambio where detalle_vale_cambio.nro_vale='" & (nro_doc) & "' and movimiento='ENTRA'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                        varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                        vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                        VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                        VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                        VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
                        VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                        'VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                        'VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                        'VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                        VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        conexion.Close()
                        DS2.Tables.Clear()
                        DT2.Rows.Clear()
                        DT2.Columns.Clear()
                        DS2.Clear()
                        conexion.Open()
                        SC2.Connection = conexion
                        SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                        DA2.SelectCommand = SC2
                        DA2.Fill(DT2)
                        DS2.Tables.Add(DT2)
                        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                            VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                        End If
                        conexion.Close()
                        VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                        VarPorcentaje = 100 - VarPorcentaje
                        VarDescuento = VarPrecioReal - VarValorUnitario
                        VarValorUnitario = VarPrecioReal
                        iva_valor = valor_iva / 100 + 1
                        VarNeto = (VarTotal / iva_valor)
                        VarIva = (VarNeto) * valor_iva / 100
                        grilla_detalle_venta.Rows.Add(VarCodProducto, _
                        varnombre, _
                        vartecnico, _
                        VarValorUnitario, _
                        VarCantidad, _
                        VarNeto, _
                        VarIva, _
                        VarSubtotal, _
                        VarPorcentaje, _
                        VarDescuento, _
                        VarTotal)
                    Next
                End If
            Else
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                SC.CommandText = "select * from detalle_vale_cambio where detalle_vale_cambio.nro_vale='" & (nro_doc) & "' and movimiento='SALE'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                        varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                        vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                        VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                        VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                        VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
                        VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                        'VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                        'VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                        'VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                        VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        conexion.Close()
                        DS2.Tables.Clear()
                        DT2.Rows.Clear()
                        DT2.Columns.Clear()
                        DS2.Clear()
                        conexion.Open()
                        SC2.Connection = conexion
                        SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                        DA2.SelectCommand = SC2
                        DA2.Fill(DT2)
                        DS2.Tables.Add(DT2)
                        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                            VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                        End If
                        conexion.Close()
                        VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                        VarPorcentaje = 100 - VarPorcentaje
                        VarDescuento = VarPrecioReal - VarValorUnitario
                        VarValorUnitario = VarPrecioReal
                        iva_valor = valor_iva / 100 + 1
                        VarNeto = (VarTotal / iva_valor)
                        VarIva = (VarNeto) * valor_iva / 100
                        grilla_detalle_venta.Rows.Add(VarCodProducto, _
                        varnombre, _
                        vartecnico, _
                        VarValorUnitario, _
                        VarCantidad, _
                        VarNeto, _
                        VarIva, _
                        VarSubtotal, _
                        VarPorcentaje, _
                        VarDescuento, _
                        VarTotal)
                    Next
                End If
            End If
        End If


        If tipo_doc = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (nro_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                    varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                    VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                    VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
                    VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                    'VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    'VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                    'VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                    VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                    End If
                    conexion.Close()
                    VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                    VarPorcentaje = 100 - VarPorcentaje
                    VarDescuento = VarPrecioReal - VarValorUnitario
                    VarValorUnitario = VarPrecioReal
                    iva_valor = valor_iva / 100 + 1
                    VarNeto = (VarTotal / iva_valor)
                    VarIva = (VarNeto) * valor_iva / 100
                    grilla_detalle_venta.Rows.Add(VarCodProducto, _
                    varnombre, _
                    vartecnico, _
                    VarValorUnitario, _
                    VarCantidad, _
                    VarNeto, _
                    VarIva, _
                    VarSubtotal, _
                    VarPorcentaje, _
                    VarDescuento, _
                    VarTotal)
                Next
            End If
        End If

        If tipo_doc = "BOLETA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (nro_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                    varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                    VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                    VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
                    VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                    'VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    'VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                    'VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                    VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                    conexion.Close()
                    DS2.Tables.Clear()
                    DT2.Rows.Clear()
                    DT2.Columns.Clear()
                    DS2.Clear()
                    conexion.Open()
                    SC2.Connection = conexion
                    SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
                    DA2.SelectCommand = SC2
                    DA2.Fill(DT2)
                    DS2.Tables.Add(DT2)
                    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                        VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
                    End If
                    conexion.Close()
                    VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                    VarPorcentaje = 100 - VarPorcentaje
                    VarDescuento = VarPrecioReal - VarValorUnitario
                    VarValorUnitario = VarPrecioReal
                    iva_valor = valor_iva / 100 + 1
                    VarNeto = (VarTotal / iva_valor)
                    VarIva = (VarNeto) * valor_iva / 100
                    grilla_detalle_venta.Rows.Add(VarCodProducto, _
                    varnombre, _
                    vartecnico, _
                    VarValorUnitario, _
                    VarCantidad, _
                    VarNeto, _
                    VarIva, _
                    VarSubtotal, _
                    VarPorcentaje, _
                    VarDescuento, _
                    VarTotal)
                Next
            End If
        End If

        If tipo_doc = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura where detalle_factura.n_factura='" & (nro_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    nombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    valor = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                    If nombre.Length > 4 Then
                        nombre = nombre.Substring(0, 4)
                    End If
                    If nombre Like "GUIA" Then
                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        descuento = 0
                        valor = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        subtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                    Else
                        valor = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        descuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                        subtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    End If
                    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                    valor, _
                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If

        If tipo_doc = "FACTURA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura where detalle_factura.n_factura='" & (nro_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    nombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    valor = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")

                    If nombre.Length > 4 Then
                        nombre = nombre.Substring(0, 4)
                    End If

                    If nombre Like "GUIA" Then
                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        descuento = 0
                        valor = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        subtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                    Else
                        valor = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        descuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                        subtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    End If

                    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                    valor, _
                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If

        If tipo_doc = "NOTA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_nota_credito where detalle_nota_credito.n_nota_credito='" & (nro_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    nombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    valor = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")

                    If nombre.Length > 4 Then
                        nombre = nombre.Substring(0, 4)
                    End If

                    If nombre Like "GUIA" Then
                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        descuento = 0
                        valor = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        subtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                    Else
                        valor = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                        total = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
                        descuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                        subtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    End If

                    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                    valor, _
                    DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If

        If tipo_doc = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_guia where detalle_guia.n_guia='" & (nro_doc) & "'"
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
                    DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If

        grilla_detalle_venta.Columns(0).Width = 85
        grilla_detalle_venta.Columns(1).Width = 120
        grilla_detalle_venta.Columns(2).Width = 120
        grilla_detalle_venta.Columns(3).Width = 85
        grilla_detalle_venta.Columns(4).Width = 85
        grilla_detalle_venta.Columns(5).Width = 85
        grilla_detalle_venta.Columns(6).Width = 85
        grilla_detalle_venta.Columns(7).Width = 85

        grilla_detalle_venta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_detalle_venta.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_detalle_venta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_detalle_venta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_detalle_venta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_detalle_venta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_detalle_venta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_detalle_venta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Private Sub grilla_comisiones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_comisiones.CellContentClick

    End Sub

    Private Sub grilla_comisiones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_comisiones.Click
        cargar_documento()
    End Sub
End Class